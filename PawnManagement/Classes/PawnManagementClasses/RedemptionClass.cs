
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class RedemptionClass
  {
    public static DataTable redemptionReport(string ShopCode, string BILLDATE, string type)
    {
      string strError = "";
      string my_querry = !(ShopCode == "") ? (!(type == "1") ? "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate and shopcode = @ShopCode order by shopcode,billnumber" : "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.Interest16 as FinalInterest,tr.RedemptionAmount16 as TotalRedemptionAmount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate and shopcode = @ShopCode order by shopcode,billnumber") : (!(type == "1") ? "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate order by shopcode,billnumber" : "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.Interest16 as FinalInterest,tr.RedemptionAmount16 as TotalRedemptionAmount ,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate order by shopcode,billnumber");
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillDate", (object) BILLDATE));
      if (ShopCode != "")
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable redemptionReport(
      string ShopCode,
      string fromBillDate,
      string ToBillDate,
      string type)
    {
      string strError = "";
      string my_querry = !(ShopCode == "") ? (!(type == "1") ? "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where (BillDate >= @FromBillDate and BillDate <= @ToBillDdate) and shopCode = @ShopCode order by shopcode,BillDate,BillNumber" : "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.Interest16 as FinalInterest,tr.RedemptionAmount16 as TotalRedemptionAmount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where (BillDate >= @FromBillDate and BillDate <= @ToBillDdate) and shopCode = @ShopCode order by shopcode,BillDate,BillNumber") : (!(type == "1") ? "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate >= @FromBillDate and BillDate <= @ToBillDdate order by shopcode,BillDate,BillNumber" : "Select  shopcode,BillNumber,BillDate,tr.Amount,tr.Interest16 as FinalInterest,tr.RedemptionAmount16 as TotalRedemptionAmount ,tr.temp2 as Interest,NoticeCharge,OtherCharge,  Deductions as InterestLess,tr.customercode ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate >= @FromBillDate and BillDate <= @ToBillDdate order by shopcode,BillDate,BillNumber");
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("FromBillDate", (object) fromBillDate));
      parameters.Add(new OleDbParameter(nameof (ToBillDate), (object) ToBillDate));
      if (ShopCode != "")
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable redemptionreportTotal(
      string ShopCode,
      string FromBillDate,
      string ToBillDate,
      string type)
    {
      string strError = "";
      DataTable dataTable = new DataTable();
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (FromBillDate), (object) FromBillDate));
      parameters.Add(new OleDbParameter(nameof (ToBillDate), (object) ToBillDate));
      string my_querry;
      if (ShopCode == "")
      {
        my_querry = !(type == "1") ? "Select SHOPCODE, SUM(Amount ) as Amount, sum(temp3) as FinalInterest from tblRedemption  where (BillDate >= @FromBillDate and BillDate <= @ToBillDdate)  GROUP by shopcode " : "Select SHOPCODE, SUM(Amount ) as Amount, sum(interest16) as FinalInterest from tblRedemption  where (BillDate >= @FromBillDate and BillDate <= @ToBillDdate)  GROUP by shopcode ";
      }
      else
      {
        my_querry = !(type == "1") ? "Select  SHOPCODE, SUM(Amount ) as Amount, sum(temp3) as FinalInterest from tblRedemption  where BillDate >= @FromBillDate and BillDate <= @ToBillDdate and ShopCode = @ShopCode GROUP by shopcode " : "Select  SHOPCODE, SUM(Amount ) as Amount, sum(interest16) as FinalInterest from tblRedemption  where BillDate >= @FromBillDate and BillDate <= @ToBillDdate and ShopCode = @ShopCode GROUP by shopcode ";
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      }
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string deleteFromRedemptionTable(string REdemptionBillNumber, string ShopCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("delete from tblRedemption where BillNumber=@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber", (object) REdemptionBillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static bool checkIfShopCodeUsedInRedemption(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where shopCode = @ShopCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form LicenseMaster.checkifShopcodeusedinRRedemption(string shopcode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form LicenseMaster.checkifShopcodeusedinRedemption(string shopcode) \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string getPledgeBillNumber(string RedemptionBillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select *,temp1 as rateofinterest,temp2 as interest,temp3 as finalinterest,temp4 as totalredemptionamount from tblredemption   where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) RedemptionBillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getPldegeBillNumber ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0].Field<string>("PledgeBillNumber").ToString();
      return "";
    }

    public static DateTime getMaxRedemptionDate(string ShopCode)
    {
      string strError = "";
      string my_querry = "Select max(BillDate) AS BillDate from  tblRedemption where ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["BillDate"] == null ? 1 : 0) | (dataTable2.Rows[0]["BillDate"] == null ? 0 : (dataTable2.Rows[0]["BillDate"].ToString() == "" ? 1 : 0))) == 0 ? DateTime.Parse(dataTable2.Rows[0]["BillDate"].ToString()) : DateTime.Now;
    }

    public static string getMaxRedemptionNumber(string ShopCode)
    {
      string strError = "";
      string my_querry = "Select max(BillNumber) AS BillNumber from  tblRedemption where ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["BillNumber"].ToString() : "";
    }

    public static string saveRedemption(
      string ShopCode,
      string BillNumber,
      string BillDate,
      string PledgeBillNumber,
      string CustomerCode,
      string ReleasedBy,
      string PledgeDate,
      string Amount,
      string RateOfInterest,
      string Interest,
      string InterestLess,
      string NoticeCharge,
      string OtherCharge,
      string Deductions,
      string FinalInterest,
      string TotalRedemptionAmount,
      string NoOfMonths,
      string NoOfMonths16,
      string Interest16,
      string RedemptionAmount16,
      DateTime CreatedOn,
      string CreatedBy,
      string BilledBy)
    {
      string strError = "";
      string str = SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblRedemption(ShopCode,BillNumber,BillDate,PledgeBillNumber,CustomerCode,ReleasedBy,PledgeDate,Amount,temp1,temp2,InterestLess,NoticeCharge,OtherCharge,Deductions,temp3,temp4,NoOfMonths,NoOfMonths16,Interest16,RedemptionAmount16,CreatedOn,CreatedBy,BilledBy) values(@ShopCode,@BillNumber,@BillDate,@PledgeBillNumber,@CustomerCode,@ReleasedBy,@PledgeDate,@Amount,@RateOfInterest,@Interest,@InterestLess,@NoticeCharge,@OtherCharge,@Deductions,@FinalInterest,@TotalRedemptionAmount,@NoOfMonths,@NoOfMonths16,@Interest16,@RedemptionAmount16,@CreatedOn,@CreatedBy,@BilledBy)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (BillDate), (object) BillDate),
        new OleDbParameter(nameof (PledgeBillNumber), (object) PledgeBillNumber),
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode),
        new OleDbParameter(nameof (ReleasedBy), (object) ReleasedBy),
        new OleDbParameter(nameof (PledgeDate), (object) PledgeDate),
        new OleDbParameter(nameof (Amount), (object) Amount),
        new OleDbParameter(nameof (RateOfInterest), (object) RateOfInterest),
        new OleDbParameter(nameof (Interest), (object) Interest),
        new OleDbParameter(nameof (InterestLess), (object) InterestLess),
        new OleDbParameter("NoiceCharge", (object) NoticeCharge),
        new OleDbParameter(nameof (OtherCharge), (object) OtherCharge),
        new OleDbParameter(nameof (Deductions), (object) Deductions),
        new OleDbParameter(nameof (FinalInterest), (object) FinalInterest),
        new OleDbParameter(nameof (TotalRedemptionAmount), (object) TotalRedemptionAmount),
        new OleDbParameter(nameof (NoOfMonths), (object) NoOfMonths),
        new OleDbParameter(nameof (NoOfMonths16), (object) NoOfMonths16),
        new OleDbParameter(nameof (Interest16), (object) Interest16),
        new OleDbParameter(nameof (RedemptionAmount16), (object) RedemptionAmount16),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn.ToString()),
        new OleDbParameter(nameof (CreatedBy), (object) FormMain.username),
        new OleDbParameter(nameof (BilledBy), (object) FormMain.BillerName)
      }, ref strError);
      return str == "Done" ? str : strError;
    }

    public static bool checkIfRedemptionBillNumberAlreadyExists(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getrokadautoentrysettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getrokadautoentrysettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }
  }
}
