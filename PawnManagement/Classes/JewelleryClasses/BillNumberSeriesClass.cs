
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class BillNumberSeriesClass
  {
    public static DataTable getCompleteBillNumberSeriesTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string deleteCompany(string compnayCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblBillNumberSettings where companyCode  =@CompanyCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) compnayCode)
      }, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string getSerialLetterForThisCompany(string strCompanyCode, string strFormType)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings where CompanyCode = @CompanyCode and FormType = @FormType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) strCompanyCode),
        new OleDbParameter("FormType", (object) strFormType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["SerialLetter"] != null ? dataTable2.Rows[0]["SerialLetter"].ToString() : "";
    }

    public static string getRangeForThisCompany(string strCompanyCode, string strFormType)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings where CompanyCode = @CompanyCode and FormType = @FormType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) strCompanyCode),
        new OleDbParameter("FormType", (object) strFormType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Range"] != null ? dataTable2.Rows[0]["Range"].ToString() : "";
    }

    public static string getSerialTypeForThisCompany(string strCompanyCode, string strFormType)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings where CompanyCode = @CompanyCode and FormType = @FormType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("CompanyCode", (object) strCompanyCode),
        new OleDbParameter("FormType", (object) strFormType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["SerialType"] != null ? dataTable2.Rows[0]["SerialType"].ToString() : "";
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(
      string ColumnName1,
      string ColumnName2,
      string strValue1,
      string strValue2)
    {
      string strError = "";
      string my_querry = "select * from tblBillNumberSettings where " + ColumnName1 + "= @" + ColumnName1 + " and " + ColumnName2 + "= @" + ColumnName2;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName1, (object) strValue1),
        new OleDbParameter(ColumnName2, (object) strValue2)
      }, ref strError);
    }

    public static string addBillNumberSettings(
      string CompanyCode,
      string FormType,
      string SerialType,
      string SerialLetter,
      double Range,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblBillNumberSettings(CompanyCode,FormType,SerialType,SerialLetter,Range,EditedBy,EditedOn,createdBy,createdOn) values (@CompanyCode,@FormType,@SerialType,@SerialLetter,@Range,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (FormType), (object) FormType),
        new OleDbParameter(nameof (SerialType), (object) SerialType),
        new OleDbParameter(nameof (SerialLetter), (object) SerialLetter),
        new OleDbParameter(nameof (Range), (object) Range),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editBillNumberSettings(
      string CompanyCode,
      string FormType,
      string SerialType,
      string SerialLetter,
      double Range,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblBillNumberSettings set   SerialType = @SerialType,SerialLetter = @SerialLetter,Range = @Range, EditedBy = @EditedBy,EditedOn = @EditedOn where CompanyCode = @CompanyCode and FormType = @FormType", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialType), (object) SerialType),
        new OleDbParameter(nameof (SerialLetter), (object) SerialLetter),
        new OleDbParameter(nameof (Range), (object) Range),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (FormType), (object) FormType)
      }, ref strError);
    }

    public static bool validateBillNumberNoSerial(string BillNumber, double range) => BillNumber != null && BillNumber != "" && !PawnManagementClass.stringContainALetter(BillNumber) && BillNumber.Length <= range.ToString().Length && double.Parse(BillNumber) < range;

    public static bool validateBillNumberSingleLetter(string BillNumber, double Range)
    {
      if (BillNumber == null || !(BillNumber != ""))
        return false;
      char c = BillNumber[0];
      if ((double) BillNumber.Count<char>() != Range + 1.0 | !char.IsUpper(c) | !char.IsLetter(c))
        return false;
      string str = BillNumber.Substring(1);
      if (str.Count<char>() <= 1)
        return false;
      int num = int.Parse(str);
      return !((double) num > Range | num < 0);
    }

    public static bool validateBillNumberDoubleLetter(string BillNumber, double Range)
    {
      if (BillNumber == null || !(BillNumber != ""))
        return false;
      char c1 = BillNumber[0];
      char c2 = BillNumber[1];
      if ((double) BillNumber.Count<char>() != Range + 1.0 | !char.IsUpper(c1) | !char.IsLetter(c1) | !char.IsUpper(c2) | !char.IsLetter(c2))
        return false;
      string str = BillNumber.Substring(2);
      if (str.Count<char>() <= 1)
        return false;
      int num = int.Parse(str);
      return !((double) num > Range | num < 0);
    }

    public static bool validateBillNumber(string SerialLetterType, string BillNumber, double Range)
    {
      switch (SerialLetterType)
      {
        case "NO SERIAL LETTER":
          return BillNumber != null && BillNumber != "" && !PawnManagementClass.stringContainALetter(BillNumber) && BillNumber.Length <= Range.ToString().Length && double.Parse(BillNumber) <= Range && double.Parse(BillNumber) > 0.0;
        case "SINGLE LETTER":
          if (BillNumber == null || !(BillNumber != ""))
            return false;
          char c1 = BillNumber[0];
          if (BillNumber.Count<char>() != Range.ToString().Length + 1 | !char.IsUpper(c1) | !char.IsLetter(c1))
            return false;
          string str1 = BillNumber.Substring(1);
          if (str1.Count<char>() <= 1)
            return false;
          int num1 = int.Parse(str1);
          return !((double) num1 > Range | num1 <= 0);
        case "DOUBLE LETTER":
          if (BillNumber == null || !(BillNumber != ""))
            return false;
          char c2 = BillNumber[0];
          char c3 = BillNumber[1];
          if (BillNumber.Count<char>() != Range.ToString().Length + 2 | !char.IsUpper(c2) | !char.IsLetter(c2) | !char.IsUpper(c3) | !char.IsLetter(c3))
            return false;
          string str2 = BillNumber.Substring(2);
          if (str2.Count<char>() <= 1)
            return false;
          int num2 = int.Parse(str2);
          return !((double) num2 > Range | num2 <= 0);
        default:
          return false;
      }
    }
  }
}
