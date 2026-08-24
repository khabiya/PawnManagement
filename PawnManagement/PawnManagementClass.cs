

using CrystalDecisions.CrystalReports.Engine;
using Glass;
using JR.Utils.GUI.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZeeUIUtility;

namespace PawnManagement
{
  internal class PawnManagementClass
  {
    public static string ENCRYPT(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

    public static string DECRYPT(string str) => Encoding.UTF8.GetString(Convert.FromBase64String(str));

    public static string getDefaultLicenseCode()
    {
      string strError = "";
      string my_querry = "select * from tblShopDetails where DefaultShop = 'Y'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("pawn management class.getDefaultLicenseCode", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["ShopCode"].ToString();
      return "";
    }

    public static DataTable getTableNameS()
    {
      string strError = "";
      return SQLHelper.getTableNames(ref strError);
    }

    public static DataTable getDataTable(string tableName)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select * from " + tableName, ref strError);
    }

    public static string appenZeroes(string str)
    {
      if (str.Contains<char>('.'))
      {
        int num = str.IndexOf('.');
        if (str.Length - num == 1)
          str += "000";
        if (str.Length - num == 2)
          str += "00";
        if (str.Length - num == 3)
          str += "0";
      }
      else
        str = !(str != "") ? str + "0" : str + ".000";
      return str;
    }

    public static string appenZeroes2(string str)
    {
      if (str.Contains<char>('.'))
      {
        int num = str.IndexOf('.');
        if (str.Length - num == 1)
          str += "00";
        if (str.Length - num == 2)
          str += "0";
      }
      else
        str = !(str != "") ? str + "0" : str + ".00";
      return str;
    }

    public static string getBillNumberSEriesSEttings()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form billnumberseriessettings.getbillnumberseriessettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form billnumberseriessettings.getbillnumberseriessettings  " + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BillNumberSeries"] != null && dataTable2.Rows[0]["BillNumberSeries"].ToString() != "")
        return dataTable2.Rows[0]["BillNumberSeries"].ToString();
      return "SINGLE";
    }

    public static DataTable getBillerTable()
    {
      string strError = "";
      string my_querry = "select * from tblBiller";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, ref strError);
    }

    public static string getValueAutoAdjustSetting()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getvalueautoadjustsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getvalueautoadjustsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["ValueAutoAdjustSetting"] != null && dataTable2.Rows[0]["ValueAutoAdjustSetting"].ToString() != "")
        return dataTable2.Rows[0]["ValueAutoAdjustSetting"].ToString();
      return "0";
    }

    public static DataTable getArticlesSettings()
    {
      string strError = "";
      string my_querry = "select * from tblArticlesSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("pawn management class.getarticlessettings", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2;
      return dataTable2;
    }

    public static bool stringContainALetter(string s)
    {
      foreach (char c in s)
      {
        if (char.IsLetter(c))
          return true;
      }
      return false;
    }

    public static int stringContainsHowManyLetter(string s)
    {
      int num = 0;
      foreach (char c in s)
      {
        if (char.IsLetter(c))
          ++num;
      }
      return num;
    }

    public static DataTable getShopCodes()
    {
      string strError = "";
      string my_querry = !(FormMain.HideLicense == "true") ? "select * from tblShopDetails where Active = '1'" : "select * from tblShopDetails where Active = '1' and Hidden  = 'N'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("pawn management class.getShopCodes", strError, FormMain.username, DateTime.Now.ToString());
      return dataTable2;
    }

    public static bool validateBillNumber(string BillNumber)
    {
      if (BillNumber == null || !(BillNumber != ""))
        return false;
      char c = BillNumber[0];
      if (BillNumber.Count<char>() != 6 || !(char.IsUpper(c) | c == '0'))
        return false;
      string str = BillNumber.Substring(1);
      if (str.Count<char>() <= 1)
        return false;
      int num = int.Parse(str);
      return !(num > 10000 | num < 1);
    }

    public static bool validateBillNumberDouble(string BillNumber)
    {
      if (BillNumber == null || !(BillNumber != ""))
        return false;
      char c1 = BillNumber[0];
      char c2 = BillNumber[1];
      if (BillNumber.Count<char>() != 7 | !char.IsUpper(c1) | !char.IsLetter(c1) | !char.IsUpper(c2) | !char.IsLetter(c2))
        return false;
      string str = BillNumber.Substring(2);
      if (str.Count<char>() <= 1)
        return false;
      int num = int.Parse(str);
      return !(num > 10000 | num < 0);
    }

    public static double getPaymentSum(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "Select sum(amount) as AmountReceived from tblInterestReceived where BillNumber  = @BillNumber AND shopCode = @ShopCode AND active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpayment.getPaymentSum", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form form partpayment.getPaymentSum" + strError);
        return 0.0;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["AmountReceived"] != null && PawnManagementClass.IsDigitsOnly(dataTable2.Rows[0]["AmountReceived"].ToString()) ? double.Parse(dataTable2.Rows[0]["AmountReceived"].ToString()) : 0.0;
    }

    public static bool getRokadAutoEntrySettings()
    {
      string strError = "";
      string my_querry = "select * from tblAutodeleterokad";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getrokadautoentrysettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getrokadautoentrysettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && !dataTable2.Rows[0]["autoentry"].ToString().Equals("Y"))
        return false;
      return true;
    }

    public static DataTable getPaymentDetailsForBillNumber(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "Select SerialNumber,BillNumber,BillDate,Amount,PaymentType from tblInterestReceived where BillNumber = @BillNumber AND active = '1' AND shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form partpapyment.getpaymentdetailsforbillNumber", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in retrieving data form partpapyment.getpaymentdetailsforbillNumber" + strError);
      return dataTable2;
    }

    public static int getNumberOfMonths(DateTime d1, DateTime d2)
    {
      if (d2.Year - d1.Year == 0)
      {
        int numberOfMonths = d2.Month - d1.Month;
        int num = d2.Day - d1.Day;
        if (numberOfMonths == 0 && num == 0)
          ++numberOfMonths;
        if (num > 0)
          ++numberOfMonths;
        return numberOfMonths;
      }
      if (d2.Year - d1.Year > 0)
      {
        int num1 = d2.Year - d1.Year;
        if (d2.Month - d1.Month > -1)
        {
          int num2 = d2.Month - d1.Month;
          if (d2.Day - d1.Day > 0)
            ++num2;
          return num1 * 12 + num2;
        }
        if (d2.Month - d1.Month < 0)
        {
          int num3 = 12 - d1.Month + d2.Month;
          if (d2.Day - d1.Day > 0)
            ++num3;
          return (num1 - 1) * 12 + num3;
        }
      }
      return -1;
    }

    public static DataTable getOldestUnredeemedPledgeRecord(string shopCode)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblpledge where redeemed = 'N' and ShopCode = @ShopCode  order by billdate,billnumber ", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode)
      }, ref strError);
    }

    public static DataTable getOldestRedemptionRecord(string shopCode)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblRedemption where ShopCode = @ShopCode  order by billnumber", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode)
      }, ref strError);
    }

    public static DataTable getOldestRedemptionRecord()
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblRedemption order by BILLDATE,billnumber", ref strError);
    }

    public static DataTable getLatestPledgeRecord(string shopCode)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblpledge where ShopCode = @ShopCode  order by billdate desc,billnumber desc ", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode)
      }, ref strError);
    }

    public static DataTable getLatestRedemptionRecord(string shopCode)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblRedemption where ShopCode = @ShopCode  order by billdate desc,billnumber desc ", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode)
      }, ref strError);
    }

    public static DataTable getOldestUnredeemedPledgeRecord()
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblpledge where redeemed = 'N' order by billdate ", ref strError);
    }

    public static DataTable getOldestPledgeRecord()
    {
      string strError = "";
      return SQLHelper.GetDataTable("select top 1 *  from  tblpledge  order by billdate ", ref strError);
    }

    public static bool IsDigitsOnly(string str)
    {
      if (str == "")
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    public static string insertIntotblVouchers(
      DateTime voucherDate,
      string voucherNumber,
      string voucherCode,
      string voucherName,
      string voucherDesription,
      string LedgerCode,
      string LedgerTypeInHindi,
      string LedgerType,
      string jammaOrNovae,
      double amount)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblVouchers(VoucherDate,VoucherNumber,VoucherCode,VoucherName,VoucherDescription,LedgerCode,LedgerTypeInHindi,LedgerType,JammaOrNovae,Amount,Active,CreatedBy,CreatedOn,CreatedTime) values (@VoucherDate,@VoucherNumber,@VoucherCode,@VoucherName,@VoucherDescription,@LedgerCode,@LedgerTypeInHindi,@LedgerType,@JammaOrNovae,@Amount,@Active,@CreatedBy,@CreatedOn,@CreatedTime)", new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherDate", (object) voucherDate),
        new OleDbParameter("VoucherNumber", (object) voucherNumber),
        new OleDbParameter("VoucherCode", (object) voucherCode),
        new OleDbParameter("VoucherName", (object) voucherName),
        new OleDbParameter("VoucherDescription", (object) voucherDesription),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter(nameof (LedgerTypeInHindi), (object) LedgerTypeInHindi),
        new OleDbParameter(nameof (LedgerType), (object) LedgerType),
        new OleDbParameter("JammaOrNovae", (object) jammaOrNovae),
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter("Active", (object) "1"),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedTime", (object) DateTime.Now.ToString())
      }, ref strError) == "Done" ? "Done" : strError;
    }

    public static string updatetblVouchers(
      DateTime voucherDate,
      string voucherNumber,
      string voucherCode,
      string voucherName,
      string voucherDesription,
      string LedgerCode,
      string LedgerTypeInHindi,
      string LedgerType,
      string jammaOrNovae,
      double amount)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblVouchers set VoucherDate = @VoucherDate,VoucherCode = @Vouchercode,VoucherName=@VoucherName,VoucherDescription=@VoucherDescription,LedgerCode = @LedgerCode,LedgerTypeInHindi = @LedgerTypeInHindi,LedgerType=@LedgerType,JammaOrNovae=@JammaOrNovae,Amount=@Amount where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherDate", (object) voucherDate),
        new OleDbParameter("VoucherCode", (object) voucherCode),
        new OleDbParameter("VoucherName", (object) voucherName),
        new OleDbParameter("VoucherDescription", (object) voucherDesription),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter(nameof (LedgerTypeInHindi), (object) LedgerTypeInHindi),
        new OleDbParameter(nameof (LedgerType), (object) LedgerType),
        new OleDbParameter("JammaOrNovae", (object) jammaOrNovae),
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter("VoucherNumber", (object) voucherNumber)
      }, ref strError) == "Done" ? "Done" : strError;
    }

    public static string insertIntotblVouchers(
      DateTime voucherDate,
      string voucherNumber,
      string voucherCode,
      string voucherName,
      string voucherDesription,
      string LedgerCode,
      string jammaOrNovae,
      double amount)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblVouchers(VoucherDate,VoucherNumber,VoucherCode,VoucherName,VoucherDescription,LedgerCode,JammaOrNovae,Amount,Active,CreatedBy,CreatedOn,CreatedTime) values (@VoucherDate,@VoucherNumber,@VoucherCode,@VoucherName,@VoucherDescription,@LedgerCode,@JammaOrNovae,@Amount,@Active,@CreatedBy,@CreatedOn,@CreatedTime)", new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherDate", (object) voucherDate),
        new OleDbParameter("VoucherNumber", (object) voucherNumber),
        new OleDbParameter("VoucherCode", (object) voucherCode),
        new OleDbParameter("VoucherName", (object) voucherName),
        new OleDbParameter("VoucherDescription", (object) voucherDesription),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter("JammaOrNovae", (object) jammaOrNovae),
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter("Active", (object) "1"),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedTime", (object) DateTime.Now.ToString())
      }, ref strError) == "Done" ? "Done" : strError;
    }

    public static string updatetblVouchers(
      DateTime voucherDate,
      string voucherNumber,
      string voucherCode,
      string voucherName,
      string voucherDesription,
      string LedgerCode,
      string jammaOrNovae,
      double amount)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblVouchers set VoucherDate = @VoucherDate,VoucherCode = @Vouchercode,VoucherName=@VoucherName,VoucherDescription=@VoucherDescription,LedgerCode = @LedgerCode,JammaOrNovae=@JammaOrNovae,Amount=@Amount where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherDate", (object) voucherDate),
        new OleDbParameter("VoucherCode", (object) voucherCode),
        new OleDbParameter("VoucherName", (object) voucherName),
        new OleDbParameter("VoucherDescription", (object) voucherDesription),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter("JammaOrNovae", (object) jammaOrNovae),
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter("VoucherNumber", (object) voucherNumber)
      }, ref strError) == "Done" ? "Done" : strError;
    }

    public static string updatetblVouchersAmountOnly(string voucherNumber, double amount)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblVouchers set Amount=@Amount where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter("VoucherNumber", (object) voucherNumber)
      }, ref strError) == "Done" ? "Done" : strError;
    }

    public static string getRokadDate()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblrokaddetails where CurrentDay = 'Y'";
        DataTable dataTable1 = new DataTable();
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form VocherAdd.gettblLedger", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving ledgertable" + strError);
        }
        else
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            return dataTable2.Rows[0]["RokadDate"].ToString();
          PawnManagementClass.insertIntoTabletblRokadDetails();
          return DateTime.Now.ToString("dd/MM/yyyy");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form AddVoucher.gettblledgertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private static void insertIntoTabletblRokadDetails()
    {
      string strError = "";
      if (SQLHelper.RunCommand("insert into tblRokadDetails (RokadDate,OpeningBalance,CurrentDay) values (@RokadDate,@OpeningBalance,@CurrentDay)", new List<OleDbParameter>()
      {
        new OleDbParameter("RokadDate", (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter("OpeningBalance", (object) "0"),
        new OleDbParameter("CurrentDay", (object) "Y")
      }, ref strError) == "Done")
      {
        int num1 = (int) MessageBox.Show("Successfully Rokad Date  Updated");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error ... Try from beginning");
      }
    }

    public static bool checkIfRokadFinishedOrNot(string rokadDate)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblrokadDetails where rokaddate = @rokadDate", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (rokadDate), (object) rokadDate)
      }, ref strError);
      return !(strError != "") && dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["rokadfinished"].ToString() == "Y" | dataTable2.Rows[0]["currentday"].ToString() == "Y";
    }

    public static bool checkIfRokadFinished(string rokadDate)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblrokadDetails where rokaddate = @rokadDate", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (rokadDate), (object) rokadDate)
      }, ref strError);
      return !(strError != "") && dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["rokadfinished"].ToString() == "Y" | dataTable2.Rows[0]["currentday"].ToString() == "N";
    }

    public static DataTable getAutoDeleteRokad()
    {
      string strError = "";
      string my_querry = "Select * from tblAutoDeleteRokad";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormPledge.getCustomerDetails(string customerdoed)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      return dataTable2;
    }

    public static bool checkForValidateDate(string date)
    {
      string[] formats = new string[16]
      {
        "dd/MM/yyyy",
        "d/M/yyyy",
        "dd/M/yyyy",
        "d/MM/yyyy",
        "dd/MM/yy",
        "d/M/yy",
        "dd/M/yy",
        "d/MM/yy",
        "dd-MM-yyyy",
        "d-M-yyyy",
        "dd-M-yyyy",
        "d-MM-yyyy",
        "dd-MM-yy",
        "d-M-yy",
        "dd-M-yy",
        "d-MM-yy"
      };
      return DateTime.TryParseExact(date, formats, (IFormatProvider) new CultureInfo("en-GB"), DateTimeStyles.None, out DateTime _);
    }

    public static double calculateCompundInterest(double p, double n, double r)
    {
      double num = p;
      double a = 0.0;
      for (; n > 0.0; n -= 12.0)
      {
        a = n <= 12.0 ? p + p * n * r / 1200.0 : p + p * 12.0 * r / 1200.0;
        p = a;
      }
      return Math.Round(a) - num;
    }

    public static double calculatePeriodicCompundInterest(double p, double n, double r, double t) => Math.Round(p * Math.Pow(1.0 + r / (t * 100.0), n / 12.0 * t) - p);

    public static string encrypt(string str)
    {
      SecureString secureString = PawnManagementClass.convertToSecureString("#9790743017*9790787347#");
      return AES.Encrypt(str, secureString);
    }

    public static string decrypt(string str)
    {
      SecureString secureString = PawnManagementClass.convertToSecureString("#9790743017*9790787347#");
      return AES.Decrypt(str, secureString);
    }

    public static SecureString convertToSecureString(string strPassword)
    {
      SecureString secureString = new SecureString();
      if (strPassword.Length > 0)
      {
        foreach (char c in strPassword.ToCharArray())
          secureString.AppendChar(c);
      }
      return secureString;
    }

    public static DialogResult customMessageBox(
      string message,
      string messageheading,
      MessageBoxButtons mbb,
      MessageBoxIcon mbi)
    {
      FlexibleMessageBox.FONT = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ResourceManager resourceManager = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
      return FormMain.Language == "Hindi" ? FlexibleMessageBox.Show(resourceManager.GetString(message), messageheading, mbb, mbi) : FlexibleMessageBox.Show(message, messageheading, mbb, mbi);
    }

    public static DialogResult customMessageBox(
      string message,
      string messageheading,
      MessageBoxButtons mbb,
      MessageBoxIcon mbi,
      MessageBoxDefaultButton mbdb)
    {
      FlexibleMessageBox.FONT = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ResourceManager resourceManager = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
      if (!(FormMain.Language == "Hindi"))
        return FlexibleMessageBox.Show(message, messageheading, mbb, mbi, mbdb);
      Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
      return FlexibleMessageBox.Show(resourceManager.GetString(message), messageheading, mbb, mbi, mbdb);
    }

    public static DialogResult customMessageBox(
      string message,
      string messageheading,
      MessageBoxButtons mbb)
    {
      FlexibleMessageBox.FONT = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ResourceManager resourceManager = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
      if (!(FormMain.Language == "Hindi"))
        return FlexibleMessageBox.Show(message, messageheading, mbb);
      Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
      return FlexibleMessageBox.Show(resourceManager.GetString(message), messageheading, mbb);
    }

    public static void customMessageBox(string message)
    {
      FlexibleMessageBox.FONT = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ResourceManager resourceManager = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
      if (FormMain.Language == "Hindi")
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
        int num = (int) FlexibleMessageBox.Show(resourceManager.GetString(message));
      }
      else
      {
        int num1 = (int) FlexibleMessageBox.Show(message);
      }
    }

    public static void customMessageBox(string message, string messageHeading)
    {
      FlexibleMessageBox.FONT = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ResourceManager resourceManager = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
      if (FormMain.Language == "Hindi")
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
        int num = (int) FlexibleMessageBox.Show(resourceManager.GetString(message), messageHeading);
      }
      else
      {
        int num1 = (int) FlexibleMessageBox.Show(message, messageHeading);
      }
    }

    public static string getSaleRate(string str)
    {
      string strError = "";
      string my_querry = "select * from tblGramRate";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        return "";
      switch (str)
      {
        case "GOLD":
          return dataTable2.Rows[0].Field<int>("salerate").ToString();
        case "SILVER":
          return dataTable2.Rows[1].Field<int>("salerate").ToString();
        default:
          return "";
      }
    }

    public static string getKachaRate(string str)
    {
      string strError = "";
      string my_querry = "select * from tblGramRate";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        return "";
      switch (str)
      {
        case "GOLD":
          return dataTable2.Rows[0].Field<int>("kacharate").ToString();
        case "SILVER":
          return dataTable2.Rows[1].Field<int>("kacharate").ToString();
        default:
          return "";
      }
    }

    public static void InsertIntoHistory(
      string ActionPipe,
      string ActionDetails,
      string OldValues,
      string Newvalues,
      string PerformedBy,
      string PerformedOn)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblHistory(ActionPipe,ActionDetails,OldValues,NewValues,PerformedBy,PerformedOn) values(@ActionPipe,@ActionDetails,@OldValues,@NewValues,@PerformedBy,@PerformedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ActionPipe), (object) ActionPipe),
        new OleDbParameter(nameof (ActionDetails), (object) ActionDetails),
        new OleDbParameter(nameof (OldValues), (object) OldValues),
        new OleDbParameter(nameof (Newvalues), (object) Newvalues),
        new OleDbParameter(nameof (PerformedBy), (object) PerformedBy),
        new OleDbParameter(nameof (PerformedOn), (object) PerformedOn)
      }, ref strError) == "Done"))
        ;
    }

    public static void InsertIntoException(
      string source,
      string MessageAnDStackTrace,
      string CreatedBy,
      string CreatedOn)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblExceptions(Message,StackTrace,CreatedBy,CreatedOn) values (@Source,@StackTrace,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("Source", (object) source),
        new OleDbParameter("StackTrace", (object) MessageAnDStackTrace),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn)
      }, ref strError) == "Done"))
        ;
    }

    public static void InsertIntoException(
      string source,
      string Message,
      string StackTrace,
      string CreatedBy,
      string CreatedOn)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblExceptions(source,Message,StackTrace,CreatedBy,CreatedOn) values(@source,@Message,@StackTrace,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (source), (object) source),
        new OleDbParameter(nameof (Message), (object) Message),
        new OleDbParameter(nameof (StackTrace), (object) StackTrace),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn)
      }, ref strError) == "Done"))
        ;
    }

    public static DataTable getColour()
    {
      string strError = "";
      string my_querry = "select * from tblColours";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      return strError != "" ? dataTable2 : dataTable2;
    }

    public static void formatDataGridViewBlack(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.DarkBlue;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 35;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    }

    public static void formatDataGridViewExBlack(ref DataGridViewEx dgv)
    {
      ((Control) dgv).ForeColor = Color.DarkBlue;
      ((DataGridView) dgv).EnableHeadersVisualStyles = false;
      ((DataGridView) dgv).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      ((DataGridView) dgv).ColumnHeadersHeight = 35;
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      ((Control) dgv).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((DataGridView) dgv).RowHeadersVisible = false;
      ((DataGridView) dgv).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      ((DataGridView) dgv).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);
      ((DataGridView) dgv).AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      ((DataGridView) dgv).RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    }

    public static void formatDataGridViewControl(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 35;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.ControlLight);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Control);
      dgv.ScrollBars = ScrollBars.Both;
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.ControlLightLight);
    }

    public static void formatDataGridViewControl9(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 35;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Control);
      dgv.ScrollBars = ScrollBars.Both;
    }

    public static bool checkIfBillNumberIsNotRelease(string BillNumber, string ShopCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber AND ShopCode = @ShopCode and redeemed = 'N'";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber.Trim().ToString()));
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
          return false;
        }
        return dataTable2 != null && dataTable2.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public static void formatDataGridViewControlPledgeForm(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 25;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.MidnightBlue;
      dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.PeachPuff;
      dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Chocolate);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.AliceBlue);
      dgv.ScrollBars = ScrollBars.Both;
    }

    public static void formatDataGridViewControl10(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 25;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
      dgv.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.AliceBlue;
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Control);
      dgv.ScrollBars = ScrollBars.Both;
    }

    public static void formatDataGridViewGreen(ref DataGridView dgv)
    {
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      dgv.BackgroundColor = Color.Ivory;
      dgv.BorderStyle = BorderStyle.Fixed3D;
      dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = Color.PeachPuff;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = Color.DarkBlue;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      dgv.ColumnHeadersHeight = 40;
      dgv.EnableHeadersVisualStyles = false;
      dgv.GridColor = Color.Chocolate;
      dgv.RowHeadersVisible = false;
      dgv.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.RowTemplate.DefaultCellStyle.BackColor = Color.Ivory;
      dgv.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.RowTemplate.DefaultCellStyle.ForeColor = Color.Teal;
      dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
      dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    public static void formatButtonBlue(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.AliceBlue;
      glassButton.ForeColor = Color.MediumBlue;
      glassButton.GlowColor = Color.RoyalBlue;
      glassButton.ShineColor = Color.Transparent;
      glassButton.OuterBorderColor = Color.MediumSlateBlue;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatButtonControl(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.LightBlue;
      glassButton.ForeColor = Color.MediumBlue;
      glassButton.GlowColor = Color.White;
      glassButton.ShineColor = Color.Transparent;
      glassButton.OuterBorderColor = Color.MediumSlateBlue;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatButtonControl2(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.FromKnownColor(KnownColor.Control);
      glassButton.ForeColor = Color.Black;
      glassButton.GlowColor = Color.Transparent;
      glassButton.ShineColor = Color.WhiteSmoke;
      glassButton.OuterBorderColor = Color.Black;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatButtonRed(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.AliceBlue;
      glassButton.ForeColor = Color.MediumBlue;
      glassButton.GlowColor = Color.Red;
      glassButton.ShineColor = Color.Transparent;
      glassButton.OuterBorderColor = Color.MediumSlateBlue;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatButtonExit(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.PaleVioletRed;
      glassButton.ForeColor = Color.White;
      glassButton.GlowColor = Color.Red;
      glassButton.ShineColor = Color.Transparent;
      glassButton.OuterBorderColor = Color.MediumSlateBlue;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatButtonBlack(ref GlassButton glassButton)
    {
      glassButton.BackColor = Color.AliceBlue;
      glassButton.ForeColor = Color.Black;
      glassButton.GlowColor = Color.Firebrick;
      glassButton.ShineColor = Color.Transparent;
      glassButton.OuterBorderColor = Color.LightBlue;
      glassButton.InnerBorderColor = Color.Transparent;
      glassButton.FadeOnFocus = true;
    }

    public static void formatDataGridViewBlue(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 35;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.MintCream,
        Font = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.Navy,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
      dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.RoyalBlue;
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Azure);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
    }

    public static void formatDataGridViewBluePledge(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 20;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.BorderStyle = BorderStyle.Fixed3D;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.MintCream,
        Font = new Font("Comic Sans MS", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.Navy,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Azure);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
    }

    public static void formatDataGridViewBluePledge(ref DataGridViewEx dgv)
    {
      ((Control) dgv).ForeColor = Color.Black;
      ((DataGridView) dgv).EnableHeadersVisualStyles = false;
      ((DataGridView) dgv).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      ((DataGridView) dgv).ColumnHeadersHeight = 20;
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((DataGridView) dgv).BorderStyle = BorderStyle.Fixed3D;
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((DataGridView) dgv).ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.MintCream,
        Font = new Font("Comic Sans MS", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.Navy,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      ((DataGridView) dgv).RowHeadersVisible = false;
      ((DataGridView) dgv).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      ((DataGridView) dgv).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
      ((DataGridView) dgv).RowsDefaultCellStyle.Font = new Font("cambria", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((DataGridView) dgv).GridColor = Color.FromKnownColor(KnownColor.Azure);
      ((DataGridView) dgv).BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
    }

    public static void formatDataGridViewBluePledgeAutoWrapRow(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 25;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.BorderStyle = BorderStyle.Fixed3D;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.MintCream,
        Font = new Font("Comic Sans MS", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.Navy,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      dgv.RowHeadersVisible = false;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Azure);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
    }

    public static void formatDataGridViewBluePledgeCambriaFont(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 20;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.BorderStyle = BorderStyle.Fixed3D;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("cambria", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.MintCream,
        Font = new Font("cambria", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.Navy,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.Azure);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
    }

    public static void formatDataGridViewBrownPledge(ref DataGridView dgv)
    {
      dgv.ForeColor = Color.Black;
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      dgv.ColumnHeadersHeight = 35;
      dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
      dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
      dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Comic sans ms", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
      {
        Alignment = DataGridViewContentAlignment.MiddleCenter,
        BackColor = Color.PeachPuff,
        Font = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
        ForeColor = Color.DarkBlue,
        SelectionBackColor = SystemColors.Highlight,
        SelectionForeColor = SystemColors.HighlightText,
        WrapMode = DataGridViewTriState.True
      };
      dgv.RowHeadersVisible = false;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.LightYellow);
      dgv.RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      dgv.GridColor = Color.FromKnownColor(KnownColor.SandyBrown);
      dgv.BackgroundColor = Color.FromKnownColor(KnownColor.Ivory);
    }

    public static ReportDocument getRedemptionBill(string BillNumber, string ShopCode)
    {
      ReportDocument redemptionBill = new ReportDocument();
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber = @BillNumber and shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Enter Valid BillNumber");
        return redemptionBill;
      }
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        DataTable pledgeRecord = PawnManagementClass.getPledgeRecord(dataTable2.Rows[0]["PledgeBillNumber"].ToString(), ShopCode);
        if (pledgeRecord != null && pledgeRecord.Rows.Count > 0)
        {
          dataTable2.Columns.Add("CustomerName", typeof (string));
          dataTable2.Columns.Add("Articles", typeof (string));
          dataTable2.Rows[0]["CustomerName"] = (object) pledgeRecord.Rows[0]["CustomerName"].ToString();
          dataTable2.Rows[0]["Articles"] = (object) pledgeRecord.Rows[0]["Articles"].ToString();
        }
        dataTable2.Columns.Add("customerImagePath", typeof (string));
        dataTable2.Columns.Add("ReleasedByImagePath", typeof (string));
        dataTable2.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable2.Rows[0]["customercode"].ToString() + ".png");
        if (File.Exists(FormMain.startUpPath + "\\Photos\\Released By\\" + dataTable2.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable2.Rows[0][nameof (ShopCode)].ToString() + ".png"))
          dataTable2.Rows[0]["ReleasedByImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Released By\\" + dataTable2.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable2.Rows[0][nameof (ShopCode)].ToString() + ".png");
        else
          dataTable2.Rows[0]["ReleasedByImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable2.Rows[0]["customercode"].ToString() + ".png");
      }
      DataTable shopDetails1 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails1.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
      shopDetails1.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
      DataTable shopDetails2 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails2.Rows[0]["BilledBy"] = (object) (FormMain.startUpPath + "\\PHOTOS\\BILLER\\" + dataTable2.Rows[0]["BilledBy"] + ".png");
      string redemptionBillPrintFormat = FormPrintSettings.getDefaultRedemptionBillPrintFormat();
      redemptionBill.Load("Reports\\\\RedemptionBill\\\\" + redemptionBillPrintFormat);
      redemptionBill.SetDataSource(dataTable2);
      redemptionBill.Subreports[0].SetDataSource(shopDetails1);
      redemptionBill.Subreports[1].SetDataSource(shopDetails2);
      return redemptionBill;
    }

    public static ReportDocument getEmptyRedemptionBill1(string ShopCode)
    {
      ReportDocument emptyRedemptionBill1 = new ReportDocument();
      string strError = "";
      string my_querry = "select * from tblRedemption where  shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Enter Valid BillNumber");
        return emptyRedemptionBill1;
      }
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        DataTable pledgeRecord = PawnManagementClass.getPledgeRecord(dataTable2.Rows[0]["PledgeBillNumber"].ToString(), ShopCode);
        if (pledgeRecord != null && pledgeRecord.Rows.Count > 0)
        {
          dataTable2.Columns.Add("CustomerName", typeof (string));
          dataTable2.Columns.Add("Articles", typeof (string));
          dataTable2.Rows[0]["CustomerName"] = (object) pledgeRecord.Rows[0]["CustomerName"].ToString();
          dataTable2.Rows[0]["Articles"] = (object) pledgeRecord.Rows[0]["Articles"].ToString();
        }
        dataTable2.Rows.Clear();
        pledgeRecord.Rows.Clear();
        dataTable2.Rows.Add();
        pledgeRecord.Rows.Add();
        dataTable2.Columns.Add("customerImagePath", typeof (string));
        dataTable2.Columns.Add("ReleasedByImagePath", typeof (string));
      }
      DataTable shopDetails1 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails1.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
      shopDetails1.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
      DataTable shopDetails2 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails2.Rows[0]["BilledBy"] = (object) "";
      string redemptionBillPrintFormat = FormPrintSettings.getDefaultRedemptionBillPrintFormat();
      emptyRedemptionBill1.Load("Reports\\\\RedemptionBill\\\\" + redemptionBillPrintFormat);
      emptyRedemptionBill1.SetDataSource(dataTable2);
      emptyRedemptionBill1.Subreports[0].SetDataSource(shopDetails1);
      emptyRedemptionBill1.Subreports[1].SetDataSource(shopDetails2);
      return emptyRedemptionBill1;
    }

    public static ReportDocument getEmptytRedemptionBill(string ShopCode)
    {
      ReportDocument emptytRedemptionBill = new ReportDocument();
      DataTable shopDetails1 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails1.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
      shopDetails1.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
      DataTable shopDetails2 = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails2.Rows[0]["BilledBy"] = (object) "";
      string redemptionBillPrintFormat = FormPrintSettings.getDefaultRedemptionBillPrintFormat();
      emptytRedemptionBill.Load("Reports\\\\RedemptionBill\\\\" + redemptionBillPrintFormat);
      emptytRedemptionBill.Subreports[0].SetDataSource(shopDetails1);
      emptytRedemptionBill.Subreports[1].SetDataSource(shopDetails2);
      return emptytRedemptionBill;
    }

    public static bool getRedemptionBillPrintSettings()
    {
      string strError = "";
      string my_querry = "select * from tblredemptionprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["RedemptionBillprintprompt"].ToString().Equals("Y"))
        return true;
      return false;
    }

    public static DataTable getPledgeRecord(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblpLEDGE where shopcode = @ShopCode and BillNumber = @BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getShopDetails(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblShopDetails where ShopCode = @ShopCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
    }

    public static DataTable getFullShopDetailsTable()
    {
      string strError = "";
      string my_querry = "select * from tblShopDetails where Active  = @Active";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Active", (object) "1")
      }, ref strError);
    }

    public static DataGridView CopyDataGridView(DataGridView dgv_org)
    {
      DataGridView dataGridView = new DataGridView();
      try
      {
        if (dataGridView.Columns.Count == 0)
        {
          foreach (DataGridViewColumn column in (BaseCollection) dgv_org.Columns)
            dataGridView.Columns.Add(column.Clone() as DataGridViewColumn);
        }
        DataGridViewRow dataGridViewRow1 = new DataGridViewRow();
        for (int index1 = 0; index1 < dgv_org.Rows.Count; ++index1)
        {
          DataGridViewRow dataGridViewRow2 = (DataGridViewRow) dgv_org.Rows[index1].Clone();
          int index2 = 0;
          foreach (DataGridViewCell cell in (BaseCollection) dgv_org.Rows[index1].Cells)
          {
            dataGridViewRow2.Cells[index2].Value = cell.Value;
            ++index2;
          }
          dataGridView.Rows.Add(dataGridViewRow2);
        }
        dataGridView.AllowUserToAddRows = false;
        dataGridView.Refresh();
      }
      catch (Exception ex)
      {
      }
      return dataGridView;
    }

    public static DataTable DataGridView2DataTable(DataGridView dgv, string tblName, int minRow = 0)
    {
      DataTable dataTable = new DataTable(tblName);
      foreach (DataGridViewColumn column1 in (BaseCollection) dgv.Columns)
      {
        DataColumn column2 = new DataColumn(column1.Name.ToString());
        dataTable.Columns.Add(column2);
      }
      for (int index1 = 0; index1 < dgv.Rows.Count; ++index1)
      {
        DataGridViewRow row1 = dgv.Rows[index1];
        DataRow row2 = dataTable.NewRow();
        for (int index2 = 0; index2 < dgv.Columns.Count; ++index2)
          row2[index2] = row1.Cells[index2].Value == null ? (object) "" : (object) row1.Cells[index2].Value.ToString();
        dataTable.Rows.Add(row2);
      }
      for (int count = dgv.Rows.Count; count < minRow; ++count)
      {
        DataRow row = dataTable.NewRow();
        for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; ++columnIndex)
          row[columnIndex] = (object) "  ";
        dataTable.Rows.Add(row);
      }
      return dataTable;
    }

    public static string averageOfNumberOfMonthsForRelease(string customerCode)
    {
      string strError = "";
      string my_querry = "select * from  ( SELECT customercode, round(avg(noofmonths)) AS avgOfNoOfMonths FROM tblpledge WHERE redeemed='Y' Or redeemed='A' GROUP BY customercode) as tp where tp.customercode = @customercode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in retrieving average of number of months for release" + strError);
        return "";
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return "";
      return dataTable2.Rows[0]["avgofnoofmonths"] != null && dataTable2.Rows[0]["avgofnoofmonths"].ToString().Trim() != "" ? dataTable2.Rows[0].Field<double>("avgOfNoOfMonths").ToString() : "0";
    }

    public static string numberOfTimesReleaseExceededTwelveMonths(string customerCode)
    {
      string strError = "";
      string my_querry = "select customercode,noOfTimes from (SELECT customercode, count(*)  as noOfTimes FROM tblpledge WHERE noofmonths>12 GROUP BY customercode) as tp where customercode = @customercode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (customerCode), (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in retrieving number of times release has exceeded twelve months" + strError);
        return "";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0].Field<int>("noOfTimes").ToString() : "";
    }

    public static string getPledgeBillNumberSeries(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeBillNumberSeries where ShopCode = @ShopCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pawnmangaement class.getPledgerBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving bill number");
      }
      return dataTable2.Rows[0]["CurrentSeries"].ToString();
    }

    public static string getRedemptionBillNumberSeries(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeBillNumberSeries where ShopCode = @ShopCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pawnmangaementclass.getRedemptionrBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving bill number");
      }
      return dataTable2.Rows[0].Field<string>("RedemptionCurrentSeries");
    }
  }
}
