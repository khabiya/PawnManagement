
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class VoucherClass
  {
    public static string getMaxOfVoucherNumber(DateTime voucherDate)
    {
      try
      {
        string strError = "";
        string my_querry = "select max(VoucherNumber) as VoucherNumber from tblVouchers where voucherDate = @VoucherDate";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate", (object) voucherDate.ToString("dd/MM/yyyy"))
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form VocherAdd.getmaxofVoucherNumber", strError, FormMain.username, DateTime.Now.ToString());
          return "";
        }
        if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0][0] != null && dataTable2.Rows[0][0].ToString() != "")
          return (int.Parse(dataTable2.Rows[0]["VoucherNumber"].ToString()) + 1).ToString();
        string str1 = voucherDate.Year.ToString().Substring(2);
        int num = voucherDate.Month;
        string str2;
        if (num.ToString().Length != 1)
        {
          num = voucherDate.Month;
          str2 = num.ToString();
        }
        else
        {
          num = voucherDate.Month;
          str2 = "0" + num.ToString();
        }
        num = voucherDate.Day;
        string str3;
        if (num.ToString().Length != 1)
        {
          num = voucherDate.Day;
          str3 = num.ToString();
        }
        else
        {
          num = voucherDate.Day;
          str3 = "0" + num.ToString();
        }
        return str1 + str2 + str3 + "0001";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form AddVoucher.getMaxOfVoucherNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return "";
      }
    }

    public static string deleteFromVouchersTableBasedOnBankSerialNumberAndBankBillNumber(
      string serialNumber,
      string BankBillNumber)
    {
      DataTable voucherNumberAndDate1 = VoucherClass.getVoucherNumberAndDate(serialNumber + "," + BankBillNumber + " Release");
      string str1 = voucherNumberAndDate1.Rows[0]["voucherNumber"].ToString();
      if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate1.Rows[0]["voucherDate"].ToString()))
      {
        string strError = "";
        SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str1)
        }, ref strError);
      }
      else
      {
        int num1 = (int) MessageBox.Show("Cannot be updated in Rokad, as rokad has already been finished for this day");
      }
      DataTable voucherNumberAndDate2 = VoucherClass.getVoucherNumberAndDate(serialNumber + "," + BankBillNumber + " INTEREST");
      string str2 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
      if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate2.Rows[0]["voucherDate"].ToString()))
      {
        string strError = "";
        return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str2)
        }, ref strError);
      }
      int num2 = (int) MessageBox.Show("Cannot be updated in Rokad, as rokad has already been finished for this day");
      return "";
    }

    public static DataTable getVoucherNumberAndDate(string VoucherDescription)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherDescription=@VoucherDescription AND Active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (VoucherDescription), (object) VoucherDescription));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static void deleteFromVoucherTable(string RedemptionBillNumber, string ShopCode)
    {
      DataTable voucherNumberAndDate1 = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + " RedemptionBillNumber " + ShopCode);
      if (voucherNumberAndDate1 == null || voucherNumberAndDate1.Rows.Count <= 0)
        return;
      DataTable voucherNumberAndDate2 = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + " RedemptionBillNumber " + ShopCode);
      string str1 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
      string s1 = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
      if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(s1).ToShortDateString()))
      {
        string strError = "";
        if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str1)
        }, ref strError) == "Done")
          PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", "VOUCHER NUMBER " + str1 + " Date " + s1 + " deleted", "", "", FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        int num1 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
      DataTable voucherNumberAndDate3 = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + " INTEREST CHOOT " + ShopCode);
      DateTime now;
      if (voucherNumberAndDate3 != null && voucherNumberAndDate3.Rows.Count > 0)
      {
        string str2 = voucherNumberAndDate3.Rows[0]["voucherNumber"].ToString();
        string s2 = voucherNumberAndDate3.Rows[0]["voucherDate"].ToString();
        now = DateTime.Parse(s2);
        if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
        {
          string strError = "";
          if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
          {
            new OleDbParameter("Active", (object) "0"),
            new OleDbParameter("VoucherNumber", (object) str2)
          }, ref strError) == "Done")
          {
            string ActionDetails = "VOUCHER NUMBER " + str2 + " Date " + s2 + " deleted";
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
        }
      }
      DataTable voucherNumberAndDate4 = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + "(" + ShopCode + ")");
      if (voucherNumberAndDate4 != null && voucherNumberAndDate4.Rows.Count > 0)
      {
        string str3 = voucherNumberAndDate4.Rows[0]["voucherNumber"].ToString();
        string s3 = voucherNumberAndDate4.Rows[0]["voucherDate"].ToString();
        now = DateTime.Parse(s3);
        if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
        {
          string strError = "";
          if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
          {
            new OleDbParameter("Active", (object) "0"),
            new OleDbParameter("VoucherNumber", (object) str3)
          }, ref strError) == "Done")
          {
            string ActionDetails = "VOUCHER NUMBER " + str3 + " Date " + s3 + " deleted";
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
          }
        }
        else
        {
          int num3 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
        }
      }
    }

    public static string getMaxOfVoucherNumber()
    {
      try
      {
        DateTime now;
        string s;
        if (PawnManagementClass.getRokadDate() != "")
        {
          now = DateTime.Parse(PawnManagementClass.getRokadDate());
          s = now.ToString("dd/MM/yyyy");
        }
        else
          s = DateTime.Now.ToString("dd/MM/yyyy");
        DateTime dateTime = DateTime.Parse(s);
        string strError = "";
        string my_querry = "select max(VoucherNumber) as VoucherNumber from tblVouchers where voucherDate = @VoucherDate";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate", (object) dateTime.ToString("dd/MM/yyyy"))
        }, ref strError);
        if (strError != "")
        {
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("form VocherAdd.getmaxofVoucherNumber", MessageAnDStackTrace, username, CreatedOn);
          return "";
        }
        if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0][0] != null && dataTable2.Rows[0][0].ToString() != "")
          return (int.Parse(dataTable2.Rows[0]["VoucherNumber"].ToString()) + 1).ToString();
        string str1 = dateTime.Year.ToString().Substring(2);
        int num;
        string str2;
        if (dateTime.Month.ToString().Length != 1)
        {
          num = dateTime.Month;
          str2 = num.ToString();
        }
        else
        {
          num = dateTime.Month;
          str2 = "0" + num.ToString();
        }
        num = dateTime.Day;
        string str3;
        if (num.ToString().Length != 1)
        {
          num = dateTime.Day;
          str3 = num.ToString();
        }
        else
        {
          num = dateTime.Day;
          str3 = "0" + num.ToString();
        }
        return str1 + str2 + str3 + "0001";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form AddVoucher.getMaxOfVoucherNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return "";
      }
    }

    public static DataTable getVoucherDetails(string voucherNumber)
    {
      string strError = "";
      string my_querry = "select * from tblVoucherS where voucherNumber = @voucherNumber";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (voucherNumber), (object) voucherNumber)
      }, ref strError);
    }

    public static string DeleteVoucherNumber(string voucherNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("Active", (object) "0"),
        new OleDbParameter("VoucherNumber", (object) voucherNumber)
      }, ref strError);
    }

    public static string getTotalNovaeSum(
      string formType,
      DateTime rokadDate,
      DateTime fromDate,
      DateTime toDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "";
      if (formType == "singleDay")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'novae' and voucherdate = @voucherDate and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("VoucherDate", (object) rokadDate));
      }
      if (formType == "currentDay")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'novae' and voucherdate = @voucherDate and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("VoucherDate", (object) rokadDate));
      }
      if (formType == "betweenDays")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'novae'  and (voucherdate >= @date1 and voucherdate <= @date2) and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("date1", (object) fromDate));
        parameters.Add(new OleDbParameter("date2", (object) toDate));
      }
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0][0] != null && dataTable.Rows[0][0].ToString() != "" ? dataTable.Rows[0][0].ToString() : "0";
    }

    public static string getTotalJammaSum(
      string formType,
      DateTime rokadDate,
      DateTime fromDate,
      DateTime toDate)
    {
      string strError = "";
      string my_querry = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (formType == "singleDay")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'jamma' and voucherdate = @voucherDate and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("VoucherDate", (object) rokadDate));
      }
      if (formType == "currentDay")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'jamma' and voucherdate = @voucherDate and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("VoucherDate", (object) rokadDate));
      }
      if (formType == "betweenDays")
      {
        my_querry = "SELECT  sum(jammasum) as totalnovaesum from (select  ledgercode,sum(amount) as jammasum FROM tblvouchers WHERE jammaornovae = 'jamma'  and (voucherdate >= @date1 and voucherdate <= @date2) and active = '1' group by ledgercode)";
        parameters.Add(new OleDbParameter("date1", (object) fromDate));
        parameters.Add(new OleDbParameter("date2", (object) toDate));
      }
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0][0] != null && dataTable.Rows[0][0].ToString() != "" ? dataTable.Rows[0][0].ToString() : "0";
    }

    public static DataTable getVouchers(
      string formType,
      string ledgertype,
      string voucherdate,
      string novaeOrJamma,
      DateTime fromDate,
      DateTime toDate)
    {
      string strError = "";
      string my_querry = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (formType == "singleDay")
      {
        my_querry = "select Amount,voucherdescription,voucherdate,VoucherName,vouchernumber,vouchercode from tblvouchers where ledgerCode = @ledgertype and jammaornovae = @novaeOrJamma and voucherdate = @voucherDate and active = '1' order by vouchernumber";
        parameters.Add(new OleDbParameter(nameof (ledgertype), (object) ledgertype));
        parameters.Add(new OleDbParameter(nameof (novaeOrJamma), (object) novaeOrJamma));
        parameters.Add(new OleDbParameter("VoucherDate", (object) voucherdate));
      }
      if (formType == "currentDay")
      {
        my_querry = "select Amount,voucherdescription,voucherdate,VoucherName,vouchernumber,vouchercode from tblvouchers where ledgerCode = @ledgertype and jammaornovae = @novaeOrJamma and voucherdate = @voucherDate and active ='1' order by vouchernumber";
        parameters.Add(new OleDbParameter(nameof (ledgertype), (object) ledgertype));
        parameters.Add(new OleDbParameter(nameof (novaeOrJamma), (object) novaeOrJamma));
        parameters.Add(new OleDbParameter("VoucherDate", (object) voucherdate));
      }
      if (formType == "betweenDays")
      {
        my_querry = "select Amount,voucherdescription,voucherdate,VoucherName,vouchernumber,vouchercode from tblvouchers where ledgerCode = @ledgertype and jammaornovae = @novaeOrJamma and (voucherdate >= @fromDate and voucherdate <= toDate and active ='1') order by vouchernumber";
        parameters.Add(new OleDbParameter(nameof (ledgertype), (object) ledgertype));
        parameters.Add(new OleDbParameter(nameof (novaeOrJamma), (object) novaeOrJamma));
        parameters.Add(new OleDbParameter(nameof (fromDate), (object) fromDate));
        parameters.Add(new OleDbParameter(nameof (toDate), (object) toDate));
      }
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getVouchersSingleDay(
      string ledgertype,
      string voucherdate,
      string novaeOrJamma)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select Amount,voucherdate,VoucherName,vouchernumber,vouchercode,voucherdescription from tblvouchers where ledgercode = @ledgertype and jammaornovae = @novaeOrJamma and voucherdate = @voucherDate and active ='1'";
      parameters.Add(new OleDbParameter(nameof (ledgertype), (object) ledgertype));
      parameters.Add(new OleDbParameter(nameof (novaeOrJamma), (object) novaeOrJamma));
      parameters.Add(new OleDbParameter("VoucherDate", (object) voucherdate));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getMainVouchers(
      string ledgertype,
      string novaeOrJamma,
      DateTime fromDate,
      DateTime toDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select  sum(amount) as Amount,voucherdate from tblvouchers where ledgercode = @ledgertype and jammaornovae = @novaeorjamma and (voucherdate >= @fromdate and voucherdate <= todate) and active = '1' group by voucherdate";
      parameters.Add(new OleDbParameter(nameof (ledgertype), (object) ledgertype));
      parameters.Add(new OleDbParameter("novaeorjamma", (object) novaeOrJamma));
      parameters.Add(new OleDbParameter("fromdate", (object) fromDate));
      parameters.Add(new OleDbParameter("todate", (object) toDate));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }
  }
}
