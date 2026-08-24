
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class SalesClass
  {
    public static DataTable getCompleteSalesTable(string OrderByColumnName, string CompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSales where CompanyCode = @CompanyCode order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblSales where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static DataTable getBill(string BillNumber, string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSales where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
    }

    public static string deleteSalesBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblSales where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static string deleteSales(string CompanyCode, string BillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblSales where CompanyCode = @CompanyCode and BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblSales where SerialNumber = @SerialNumber";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) strSerialNumber)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static bool checkIfBillNumberAlreadyExists(string strBillNumber, string CompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSales where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber", (object) strBillNumber),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static bool checkIfInvoiceNumberAlreadyExists(
      string strBillNumber,
      string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSales where Billnumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Billnumber", (object) strBillNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addSales(
      double SerialNumber,
      DateTime BillDate,
      string BillType,
      string BillNumber,
      string LocationOfCounter,
      string BilledBy,
      string SalesPerson,
      string CustomerCode,
      double TotalAmount,
      double TotalGstAmount,
      double GrandTotal,
      double Discount,
      double RoundOff,
      double oldPurchase,
      double NetPayable,
      double AmountReceived,
      double Balance,
      DateTime commitDate,
      string EditedBy,
      DateTime EditedOn,
      string CreatedBy,
      DateTime CreatedOn,
      string CompanyCode)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblSales(SerialNumber,  BillDate,  BillType, BillNumber, LocationOfCounter, BilledBy, SalesPerson, CustomerCode, TotalAmount, TotalGstAmount, GrandTotal, Discount, RoundOff, oldPurchase, NetPayable, AmountReceived, Balance, commitDate,  EditedBy,  EditedOn, CreatedBy, CreatedOn,COMPANYCODE) values (@SerialNumber,  @BillDate,  @BillType, @BillNumber, @LocationOfCounter, @BilledBy, @SalesPerson, @CustomerCode, @TotalAmount, @TotalGstAmount, @GrandTotal, @Discount, @RoundOff, @oldPurchase, @NetPayable, @AmountReceived, @Balance, @commitDate,  @EditedBy,  @EditedOn, @CreatedBy, @CreatedOn,@COMPANYCODE)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (BillDate), (object) BillDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (BillType), (object) BillType),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (LocationOfCounter), (object) LocationOfCounter),
        new OleDbParameter(nameof (BilledBy), (object) BilledBy),
        new OleDbParameter(nameof (SalesPerson), (object) SalesPerson),
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode),
        new OleDbParameter(nameof (TotalAmount), (object) TotalAmount),
        new OleDbParameter(nameof (TotalGstAmount), (object) TotalGstAmount),
        new OleDbParameter(nameof (GrandTotal), (object) GrandTotal),
        new OleDbParameter(nameof (Discount), (object) Discount),
        new OleDbParameter(nameof (RoundOff), (object) RoundOff),
        new OleDbParameter("OldPurchase", (object) oldPurchase),
        new OleDbParameter(nameof (NetPayable), (object) NetPayable),
        new OleDbParameter(nameof (AmountReceived), (object) AmountReceived),
        new OleDbParameter(nameof (Balance), (object) Balance),
        new OleDbParameter("CommitDate", (object) commitDate),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("COMPANYCODE", (object) CompanyCode)
      }, ref strError);
    }

    public static string editSales(
      DateTime BillDate,
      string BillType,
      string BillNumber,
      string LocationOfCounter,
      string BilledBy,
      string SalesPerson,
      string CustomerCode,
      double TotalAmount,
      double TotalGstAmount,
      double GrandTotal,
      double Discount,
      double RoundOff,
      double oldPurchase,
      double NetPayable,
      double AmountReceived,
      double Balance,
      DateTime commitDate,
      string EditedBy,
      DateTime EditedOn,
      string CreatedBy,
      DateTime CreatedOn,
      string CompanyCode)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblSales set  BillDate =  @BillDate,  BillType =  @BillType,LocationOfCounter =  @LocationOfCounter,BilledBy =  @BilledBy,  SalesPerson = @SalesPerson, CustomerCode = @CustomerCode,TotalAmount = @TotalAmount,TotalGstAmount = @TotalGstAmount, GrandTotal = @GrandTotal, Discount =  @Discount,RoundOff = @RoundOff, OldPurchase =  @oldPurchase,NetPayable = @NetPayable,AmountReceived = @AmountReceived, Balance = @Balance,CommitDate = @commitDate, EditedBy = @EditedBy,EditedOn = @EditedOn where @CompanyCode = @CompanyCode and BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillDate), (object) BillDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (BillType), (object) BillType),
        new OleDbParameter(nameof (LocationOfCounter), (object) LocationOfCounter),
        new OleDbParameter(nameof (BilledBy), (object) BilledBy),
        new OleDbParameter(nameof (SalesPerson), (object) SalesPerson),
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode),
        new OleDbParameter(nameof (TotalAmount), (object) TotalAmount),
        new OleDbParameter(nameof (TotalGstAmount), (object) TotalGstAmount),
        new OleDbParameter(nameof (GrandTotal), (object) GrandTotal),
        new OleDbParameter(nameof (Discount), (object) Discount),
        new OleDbParameter(nameof (RoundOff), (object) RoundOff),
        new OleDbParameter("OldPurchase", (object) oldPurchase),
        new OleDbParameter(nameof (NetPayable), (object) NetPayable),
        new OleDbParameter(nameof (AmountReceived), (object) AmountReceived),
        new OleDbParameter(nameof (Balance), (object) Balance),
        new OleDbParameter("CommitDate", (object) commitDate),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
    }

    public static string getNextBillNumber(string CompanyCode)
    {
      string str1 = "";
      string strError = "";
      string my_querry = "Select max(BillNumber) AS MaxBillNumber from tblSales where CompanyCode = @CompanyCode and BillNumber Like '" + BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER") + "%'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["MaxBillNumber"] != null && dataTable2.Rows[0]["MaxBillNumber"].ToString() != "")
        {
          str1 = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
          string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
          string typeForThisCompany = BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER");
          switch (typeForThisCompany)
          {
            case "NO SERIAL LETTER":
              return dataTable2.Rows[0]["MaxBillNumber"] != null && dataTable2.Rows[0]["MaxBillNumber"].ToString() != "" ? (double.Parse(dataTable2.Rows[0]["MaxBillNumber"].ToString()) + 1.0).ToString() : 1.ToString();
            case "SINGLE LETTER":
              return SalesClass.getNextNumber(dataTable2.Rows[0]["MaxBillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
            case "DOUBLE LETTER":
              return SalesClass.getNextNumber(dataTable2.Rows[0]["MaxBillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
            default:
              return "";
          }
        }
        else
        {
          string letterForThisCompany = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
          string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
          switch (BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER"))
          {
            case "NO SERIAL LETTER":
              return "1";
            case "SINGLE LETTER":
              string str2 = StringClass.appendZeroes(rangeForThisCompany);
              return letterForThisCompany + str2 + "1";
            case "DOUBLE LETTER":
              string str3 = StringClass.appendZeroes(rangeForThisCompany);
              return letterForThisCompany + str3 + "1";
            default:
              return "";
          }
        }
      }
      else
      {
        string letterForThisCompany = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
        string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
        switch (BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER"))
        {
          case "NO SERIAL LETTER":
            return "1";
          case "SINGLE LETTER":
            string str4 = StringClass.appendZeroes(rangeForThisCompany);
            return letterForThisCompany + str4 + "1";
          case "DOUBLE LETTER":
            string str5 = StringClass.appendZeroes(rangeForThisCompany);
            return letterForThisCompany + str5 + "1";
          default:
            return "";
        }
      }
    }

    public static string getNextBillNumber1(string CompanyCode, string BILLNUMBER)
    {
      string strError = "";
      string my_querry = "Select * from tblSales where CompanyCode = @CompanyCode and BillNumber > @BillNumber ORDER bY BillNumber asc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      parameters.Add(new OleDbParameter("BillNumber", (object) BILLNUMBER));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "" ? dataTable2.Rows[0]["BillNumber"].ToString() : "";
    }

    public static string getNextBillNumber(string CompanyCode, string BILLNUMBER)
    {
      string str1 = "";
      string strError = "";
      string my_querry = "Select * from tblSales where CompanyCode = @CompanyCode and BillNumber = @BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      parameters.Add(new OleDbParameter("BillNumber", (object) BILLNUMBER));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "")
        {
          str1 = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
          string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
          string typeForThisCompany = BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER");
          switch (typeForThisCompany)
          {
            case "NO SERIAL LETTER":
              return (double.Parse(dataTable2.Rows[0]["BillNumber"].ToString()) + 1.0).ToString();
            case "SINGLE LETTER":
              return SalesClass.getNextNumber(dataTable2.Rows[0]["BillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
            case "DOUBLE LETTER":
              return SalesClass.getNextNumber(dataTable2.Rows[0]["BillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
            default:
              return "";
          }
        }
        else
        {
          string letterForThisCompany = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
          string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
          switch (BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER"))
          {
            case "NO SERIAL LETTER":
              return "1";
            case "SINGLE LETTER":
              string str2 = StringClass.appendZeroes(rangeForThisCompany);
              return letterForThisCompany + str2 + "1";
            case "DOUBLE LETTER":
              string str3 = StringClass.appendZeroes(rangeForThisCompany);
              return letterForThisCompany + str3 + "1";
            default:
              return "";
          }
        }
      }
      else
      {
        string letterForThisCompany = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
        string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
        switch (BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER"))
        {
          case "NO SERIAL LETTER":
            return "1";
          case "SINGLE LETTER":
            string str4 = StringClass.appendZeroes(rangeForThisCompany);
            return letterForThisCompany + str4 + "1";
          case "DOUBLE LETTER":
            string str5 = StringClass.appendZeroes(rangeForThisCompany);
            return letterForThisCompany + str5 + "1";
          default:
            return "";
        }
      }
    }

    public static string getPreviousBillNumber1(string CompanyCode, string BILLNUMBER)
    {
      string strError = "";
      string my_querry = "Select * from tblSales where CompanyCode = @CompanyCode  and BillNumber < @BillNumber order by billNumber desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      parameters.Add(new OleDbParameter("BillNumber", (object) BILLNUMBER));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "" ? dataTable2.Rows[0]["BillNumber"].ToString() : "";
    }

    public static string getPreviousBillNumber(string CompanyCode, string BILLNUMBER)
    {
      string str = "";
      string strError = "";
      string my_querry = "Select * from tblSales where CompanyCode = @CompanyCode and BillNumber = @BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      parameters.Add(new OleDbParameter("BillNumber", (object) BILLNUMBER));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 == null || dataTable2.Rows.Count <= 0 || dataTable2.Rows[0]["BillNumber"] == null || !(dataTable2.Rows[0]["BillNumber"].ToString() != ""))
        return "";
      str = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
      string rangeForThisCompany = BillNumberSeriesClass.getRangeForThisCompany(CompanyCode, "INVOICE NUMBER");
      string typeForThisCompany = BillNumberSeriesClass.getSerialTypeForThisCompany(CompanyCode, "INVOICE NUMBER");
      switch (typeForThisCompany)
      {
        case "NO SERIAL LETTER":
          return (double.Parse(dataTable2.Rows[0]["BillNumber"].ToString()) - 1.0).ToString();
        case "SINGLE LETTER":
          return SalesClass.getPreviousNumber(dataTable2.Rows[0]["BillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
        case "DOUBLE LETTER":
          return SalesClass.getPreviousNumber(dataTable2.Rows[0]["BillNumber"].ToString(), typeForThisCompany, double.Parse(rangeForThisCompany));
        default:
          return "";
      }
    }

    public static string getMaxtBillNumber(string CompanyCode)
    {
      string strError = "";
      string my_querry = "Select max(BillNumber) AS MaxBillNumber from tblSales where CompanyCode = @CompanyCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MaxBillNumber"] != null && dataTable2.Rows[0]["MaxBillNumber"].ToString() != "" ? dataTable2.Rows[0]["MaxBillNumber"].ToString() : "";
    }

    public static string getMaxtBillNumberInSameSeries(string CompanyCode)
    {
      string strError = "";
      string str = "";
      str = BillNumberSeriesClass.getSerialLetterForThisCompany(CompanyCode, "INVOICE NUMBER");
      string my_querry = "Select max(BillNumber) AS MaxBillNumber from tblSales where CompanyCode = @CompanyCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MaxBillNumber"] != null && dataTable2.Rows[0]["MaxBillNumber"].ToString() != "" ? dataTable2.Rows[0]["MaxBillNumber"].ToString() : "";
    }

    public static string getPreviousNumber(
      string BILLNUMBER,
      string SerialLetterType,
      double Range)
    {
      string s = BILLNUMBER;
      switch (SerialLetterType)
      {
        case "NO SERIAL LETTER":
          return (double.Parse(s) - 1.0).ToString();
        case "SINGLE LETTER":
          char ch1 = s[0];
          double num1 = double.Parse(s.Substring(1));
          if (num1 == 1.0)
            return ch1 == 'A' ? "" : ((char) ((uint) ch1 - 1U)).ToString() + (object) Range;
          if (num1 <= Range)
          {
            double num2 = num1 - 1.0;
            string str = StringClass.appendZeroesBasedOnLength((Range.ToString().Length - num2.ToString().Length).ToString());
            return ch1.ToString() + str + num2.ToString();
          }
          break;
        case "DOUBLE LETTER":
          char ch2 = s[0];
          char ch3 = s[1];
          double num3 = double.Parse(s.Substring(2));
          if (num3 == 1.0)
          {
            char ch4 = (char) ((uint) ch3 - 1U);
            StringClass.appendZeroes(Range.ToString());
            return ch2.ToString() + ch4.ToString() + (object) Range;
          }
          if (num3 < Range)
          {
            double num4 = num3 - 1.0;
            string str = StringClass.appendZeroesBasedOnLength((Range.ToString().Length - num4.ToString().Length).ToString());
            return ch2.ToString() + ch3.ToString() + str + num4.ToString();
          }
          break;
      }
      return "";
    }

    public static string getNextNumber(string BILLNUMBER, string SerialLetterType, double Range)
    {
      string s = BILLNUMBER;
      switch (SerialLetterType)
      {
        case "NO SERIAL LETTER":
          return (double.Parse(s) + 1.0).ToString();
        case "SINGLE LETTER":
          char ch1 = s[0];
          double num1 = double.Parse(s.Substring(1));
          if (num1 == Range)
          {
            char ch2 = (char) ((uint) ch1 + 1U);
            string str = StringClass.appendZeroes(Range.ToString());
            return ch2.ToString() + str + "1";
          }
          if (num1 < Range)
          {
            double num2 = num1 + 1.0;
            string str = StringClass.appendZeroesBasedOnLength((Range.ToString().Length - num2.ToString().Length).ToString());
            return ch1.ToString() + str + num2.ToString();
          }
          break;
        case "DOUBLE LETTER":
          char ch3 = s[0];
          char ch4 = s[1];
          double num3 = double.Parse(s.Substring(2));
          if (num3 == Range)
          {
            char ch5 = (char) ((uint) ch4 + 1U);
            string str = StringClass.appendZeroes(Range.ToString());
            return ch3.ToString() + ch5.ToString() + str + "1";
          }
          if (num3 < Range)
          {
            double num4 = num3 + 1.0;
            string str = StringClass.appendZeroesBasedOnLength((Range.ToString().Length - num4.ToString().Length).ToString());
            return ch3.ToString() + ch4.ToString() + str + num4.ToString();
          }
          break;
      }
      return "";
    }

    public static double getMaxSerialNumber()
    {
      string strError = "";
      string my_querry = "Select max(SerialNumber) AS MaxSerialNumber from tblSales";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["mAXSerialNumber"] != null && dataTable2.Rows[0]["MAXSerialNumber"].ToString() != "" ? double.Parse(dataTable2.Rows[0]["MAXSerialNumber"].ToString()) + 1.0 : 1.0;
    }
  }
}
