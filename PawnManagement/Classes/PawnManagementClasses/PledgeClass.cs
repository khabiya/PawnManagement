

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class PledgeClass
  {
    public static DataTable getPledgeReport(string ShopCode, string BillDate, string type)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (ShopCode == "")
      {
        my_querry = !(type == "2") ? "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where BillDate = @BillDate order by shopcode,billnumber " : "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where BillDate = @BillDate order by shopcode,billnumber ";
      }
      else
      {
        my_querry = !(type == "2") ? "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where  shopcode = @ShopCode and  BillDate = @BillDate order by shopcode,billnumber " : "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where  shopcode = @ShopCode and  BillDate = @BillDate order by shopcode,billnumber ";
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      }
      parameters.Add(new OleDbParameter(nameof (BillDate), (object) BillDate));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getNoticeDetails(DateTime FromDate, DateTime ToDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "Select * from tblPledge  where BillDate >= @FromDate and BillDate <= @ToDate order by shopcode,billnumber ";
      parameters.Add(new OleDbParameter(nameof (FromDate), (object) FromDate));
      parameters.Add(new OleDbParameter(nameof (ToDate), (object) ToDate));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable pledgeReport(
      string ShopCode,
      string FromBillDate,
      string ToDate,
      string type)
    {
      string strError = "";
      string my_querry = !(ShopCode == "") ? "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where (BillDate >= @FromBillDate)  and (BillDate <= @ToBillDate) and shopcode = @ShopCode order by shopcode,BillDate,BillNumber " : "Select shopcode,Amount,temp5 as Interest,BillNumber,customername,customercode,BillDate from tblPledge  where BillDate >= @FromBillDate  and BillDate <= @ToBillDate order by shopcode,BillDate,BillNumber ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (FromBillDate), (object) FromBillDate));
      parameters.Add(new OleDbParameter("ToBillDate", (object) ToDate));
      if (ShopCode != "")
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable pledgeReportTotal(
      string ShopCode,
      string FromDate,
      string ToDate,
      string type)
    {
      string strError = "";
      DataTable dataTable = new DataTable();
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("FromBillDate", (object) FromDate));
      parameters.Add(new OleDbParameter("ToBillDate", (object) ToDate));
      string my_querry;
      if (ShopCode == "")
      {
        my_querry = "select shopcode , sum(amount)  as Total ,sum(temp5) as Interest from tblpledge  where BillDate  >= @FromDate and BillDate <= @ToDate  group by shopcode";
      }
      else
      {
        my_querry = "select shopcode , sum(amount)  as Total ,sum(temp5) as Interest from tblpledge  where BillDate  >= @FromDate and BillDate <= @ToDate and ShopCode = @ShopCode group by shopcode";
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      }
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static List<string> getDistinctYears()
    {
      string strError = "";
      List<string> distinctYears = new List<string>();
      string my_querry = "select distinct(year(billdate))  as distinctyears from tblpledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        distinctYears.Clear();
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          distinctYears.Add(row["distinctyears"].ToString());
      }
      return distinctYears;
    }

    public static List<string> getPurposeList()
    {
      List<string> purposeList = new List<string>();
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select  distinct Purpose from tblPledge", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("pledgeclass.getpurposelist()", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
          purposeList.Add(row["Purpose"].ToString());
      }
      return purposeList;
    }

    public static bool checkIfShopCodeUsedInPledge(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where shopCode = @ShopCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form LicenseMaster.checkifShopcodeusedinpledge(string shopcode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form LicenseMaster.checkifShopcodeusedinpledge(string shopcode) \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string UndoRedemptionInPledgeTable(string PledgeBillNumber, string ShopCode)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set Redeemed = @Redeemed,NoOfMonths = @NoOfMonths,temp2=@Interest,InterestLess=@InterestLess,NoticeCharge=@NoticeCharge,OtherCharges=@OtherCharge,Discount=@Discount,temp3=@FinalInterest,temp4=@RedemptionAmount,RedemptionDate= @RedemptionDate,NoOfMonths16=@NoOfMonths16,Interest16= @Interest16,RedemptionAmount16=@RedemptionAmount16,RedeemedBy=@RedeemedBy,RedeemedOn = @RedeemedOn,RedemptionBillNumber = @RedemptionBillNumber where BillNumber =@BillNumber AND ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Redeemed", (object) "N"),
        new OleDbParameter("NoOfMonths", (object) DBNull.Value),
        new OleDbParameter("Interest", (object) DBNull.Value),
        new OleDbParameter("InterestLess", (object) DBNull.Value),
        new OleDbParameter("NoticeCharge", (object) DBNull.Value),
        new OleDbParameter("OtherCharges", (object) DBNull.Value),
        new OleDbParameter("Discount", (object) DBNull.Value),
        new OleDbParameter("FinalInterest", (object) DBNull.Value),
        new OleDbParameter("RedemptionAmount", (object) DBNull.Value),
        new OleDbParameter("RedemptionDate", (object) DBNull.Value),
        new OleDbParameter("NoOfMonths16", (object) DBNull.Value),
        new OleDbParameter("Interest16", (object) DBNull.Value),
        new OleDbParameter("RedemptionAmount16", (object) DBNull.Value),
        new OleDbParameter("RedeemedBy", (object) DBNull.Value),
        new OleDbParameter("RedeemedOn", (object) DBNull.Value),
        new OleDbParameter("RedemptionBillNumber", (object) DBNull.Value),
        new OleDbParameter("BillNumber", (object) PledgeBillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static void UpdateBankCodeAndBankSerialNumberInPledgeTable(
      string BankCode,
      string BankSerialNumber,
      string BillNumber,
      string ShopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode, BankSerialNumber = @BankSerialNumber  where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankCode), (object) BankCode),
        new OleDbParameter(nameof (BankSerialNumber), (object) BankSerialNumber),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    public static void ResetBankCodeAndBankSerialNumberInPledgeTable(
      string BillNumber,
      string ShopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode, BankSerialNumber = @BankSerialNumber  where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BankCode", (object) DBNull.Value),
        new OleDbParameter("BankSerialNumber", (object) DBNull.Value),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    public static bool checkIfBillNumberReleeasedOrNot(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.tbxPledgeBillNumber_Leave ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
        return true;
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return true;
      if (dataTable2.Rows[0].Field<string>("Redeemed") == "N")
        return false;
      return !(dataTable2.Rows[0].Field<string>("Redeemed") == "Y") && dataTable2.Rows[0].Field<string>("Redeemed") == "A" || true;
    }

    public static string getRateOfInterestForThisBillNumber(string ShopCode, string BillNumber)
    {
      string strError = "";
      string my_querry = "select temp1 as RateOfInterest from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.tbxPledgeBillNumber_Leave ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["RateOfInterest"] != null)
        return dataTable2.Rows[0]["RateOfInterest"].ToString();
      return "";
    }

    public static string setIntimationLetterSentToYesOrNo(
      string ShopCode,
      string BillNumber,
      string IntimationLetterSent,
      DateTime IntimationLetterSentOn,
      string IntimationLetterPostalId,
      string IntimationLetterReceivedBy)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set IntimationLetterSent = @IntimationLetterSent,IntimationLetterSentOn = @IntimationLetterSentOn,IntimationLetterPostalId = @IntimationLetterPostalId,IntimationLetterReceivedBy = @IntimationLetterReceivedBy where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (IntimationLetterSent), (object) IntimationLetterSent),
        new OleDbParameter(nameof (IntimationLetterSentOn), (object) IntimationLetterSentOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (IntimationLetterPostalId), (object) IntimationLetterPostalId),
        new OleDbParameter("IntimationLetterReceived", (object) IntimationLetterReceivedBy),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static string setIntimationLetterPostalId(
      string ShopCode,
      string BillNumber,
      string IntimationLetterPostalId)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set IntimationLetterPostalId = @IntimationLetterPostalId where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (IntimationLetterPostalId), (object) IntimationLetterPostalId),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static string setIntimationLetterSentToYesOrNo(
      string ShopCode,
      string BillNumber,
      string IntimationLetterReceivedBy)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set IntimationLetterSent = @IntimationLetterSent,IntimationLetterSentOn = @IntimationLetterSentOn,IntimationLetterPostalId = @IntimationLetterPostalId,IntimationLetterReceived = @IntimationLetterReceived where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (IntimationLetterReceivedBy), (object) IntimationLetterReceivedBy),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static bool getIntimationLetterSentOrNot(string ShopCode, string BillNumber)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblPledge where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      return dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["IntimationLetterSent"] != null && dataTable.Rows[0]["IntimationLetterSent"].ToString() != "" && dataTable.Rows[0]["IntimationLetterSent"].ToString() == "Y";
    }

    public static string setAuctionLetterSentToYesOrNo(
      string ShopCode,
      string BillNumber,
      string AuctionLetterSent,
      DateTime AuctionLetterSentOn,
      string AuctionLetterPostalId,
      string AuctionLetterReceivedBy)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set AuctionLetterSent = @AuctionLetterSent,AuctionLetterSentOn = @AuctionLetterSentOn,AuctionLetterPostalId = @AuctionLetterPostalId,AuctionLetterReceivedBy = @AuctionLetterReceivedBy where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (AuctionLetterSent), (object) AuctionLetterSent),
        new OleDbParameter(nameof (AuctionLetterSentOn), (object) AuctionLetterSentOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (AuctionLetterPostalId), (object) AuctionLetterPostalId),
        new OleDbParameter("AuctionLetterReceived", (object) AuctionLetterReceivedBy),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static string setAuctionLetterPostalId(
      string ShopCode,
      string BillNumber,
      string AuctionLetterPostalId)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set AuctionLetterPostalId = @AuctionLetterPostalId where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (AuctionLetterPostalId), (object) AuctionLetterPostalId),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static string setAuctionLetterSentToYesOrNo(
      string ShopCode,
      string BillNumber,
      string AuctionLetterReceivedBy)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set AuctionLetterSent = @AuctionLetterSent,AuctionLetterSentOn = @AuctionLetterSentOn,AuctionLetterPostalId = @AuctionLetterPostalId,AuctionLetterReceived = @AuctionLetterReceived where  BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (AuctionLetterReceivedBy), (object) AuctionLetterReceivedBy),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static DataTable billReport(int year, string ShopCode, string ColumnName)
    {
      DataTable dataTable1 = new DataTable();
      string strError = "";
      DataTable dataTable2;
      if (ShopCode == "")
        dataTable2 = SQLHelper.GetDataTable(string.Format("select tblDates.BDate, January, February, March, April, May, June, July, August, September, October, November, December from \r\n\r\n                                (((((((((((tblDates left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as January FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=1 and Year([BillDate])={0} order by Day([BillDate])) as tbl1 on tblDates.BDate = tbl1.BDate) \r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as February FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=2 and Year([BillDate])={0} order by Day([BillDate])) as tbl2 on tblDates.BDate = tbl2.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as March FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=3 and Year([BillDate])={0} order by Day([BillDate])) as tbl3 on tblDates.BDate = tbl3.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as April FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=4 and Year([BillDate])={0} order by Day([BillDate])) as tbl4 on tblDates.BDate = tbl4.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as May FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=5 and Year([BillDate])={0} order by Day([BillDate])) as tbl5 on tblDates.BDate = tbl5.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as June FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=6 and Year([BillDate])={0} order by Day([BillDate])) as tbl6 on tblDates.BDate = tbl6.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as July FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=7 and Year([BillDate])={0} order by Day([BillDate])) as tbl7 on tblDates.BDate = tbl7.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as August FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=8 and Year([BillDate])={0} order by Day([BillDate])) as tbl8 on tblDates.BDate = tbl8.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as September FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=9 and Year([BillDate])={0} order by Day([BillDate])) as tbl9 on tblDates.BDate = tbl9.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as October FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=10 and Year([BillDate])={0} order by Day([BillDate])) as tbl10 on tblDates.BDate = tbl10.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as November FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=11 and Year([BillDate])={0} order by Day([BillDate])) as tbl11 on tblDates.BDate = tbl11.BDate)\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as December FROM TBLREDEMPTION group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=12 and Year([BillDate])={0} order by Day([BillDate])) as tbl12 on tblDates.BDate = tbl12.BDate", (object) year), ref strError);
      else
        dataTable2 = SQLHelper.GetDataTable(string.Format("select tblDates.BDate, January, February, March, April, May, June, July, August, September, October, November, December from \r\n\r\n                                (((((((((((tblDates left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as January FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=1 and Year([BillDate])={0} order by Day([BillDate])) as tbl1 on tblDates.BDate = tbl1.BDate) \r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as February FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=2 and Year([BillDate])={0} order by Day([BillDate])) as tbl2 on tblDates.BDate = tbl2.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as March FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=3 and Year([BillDate])={0} order by Day([BillDate])) as tbl3 on tblDates.BDate = tbl3.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as April FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=4 and Year([BillDate])={0} order by Day([BillDate])) as tbl4 on tblDates.BDate = tbl4.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as May FROM TBLREDEMPTION  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=5 and Year([BillDate])={0} order by Day([BillDate])) as tbl5 on tblDates.BDate = tbl5.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as June FROM TBLREDEMPTION  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=6 and Year([BillDate])={0} order by Day([BillDate])) as tbl6 on tblDates.BDate = tbl6.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as July FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=7 and Year([BillDate])={0} order by Day([BillDate])) as tbl7 on tblDates.BDate = tbl7.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as August FROM TBLREDEMPTION  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=8 and Year([BillDate])={0} order by Day([BillDate])) as tbl8 on tblDates.BDate = tbl8.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as September FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=9 and Year([BillDate])={0} order by Day([BillDate])) as tbl9 on tblDates.BDate = tbl9.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as October FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=10 and Year([BillDate])={0} order by Day([BillDate])) as tbl10 on tblDates.BDate = tbl10.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as November FROM TBLREDEMPTION  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=11 and Year([BillDate])={0} order by Day([BillDate])) as tbl11 on tblDates.BDate = tbl11.BDate)\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, Sum([" + ColumnName + "]) as December FROM TBLREDEMPTION {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=12 and Year([BillDate])={0} order by Day([BillDate])) as tbl12 on tblDates.BDate = tbl12.BDate", (object) year, (object) " where shopcode = @ShopCode "), new List<OleDbParameter>()
        {
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode),
          new OleDbParameter(nameof (ShopCode), (object) ShopCode)
        }, ref strError);
      return dataTable2;
    }
  }
}
