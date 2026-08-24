

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class FinancialYearsClass
  {
    public static DataTable getCompleteFinancialYearsTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblFinancialYears order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblFinancialYears where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deleteFinancialYearBasedOnThisFinYearCode(string strFinYearCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblFinancialYears where FinYearCode = @FinYearCode", new List<OleDbParameter>()
      {
        new OleDbParameter("FinYearCode", (object) strFinYearCode)
      }, ref strError);
    }

    public static bool checkIfFinanCialYearCodeAlreadyExists(string strFinancialYearCode)
    {
      string strError = "";
      string my_querry = "select * from tblFinancialYears where FinYearCode = @FinYearCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FinYearCode", (object) strFinancialYearCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addFinancialYear(
      string FinYearCode,
      DateTime FromDate,
      DateTime ToDate,
      string Company,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblFinancialYears(FinYearCode,FromDate,ToDate,Company,EditedBy,EditedOn,createdBy,createdOn) values(@FinYearCode,@FromDate,@ToDate,@Company,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode),
        new OleDbParameter(nameof (FromDate), (object) FromDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ToDate), (object) ToDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (Company), (object) Company),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editPurchase(
      string FinYearCode,
      DateTime FromDate,
      DateTime ToDate,
      string Company,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblFinancialYears set FromDate = @FromDate,ToDate = @ToDate,Company = @Company, EditedBy = @EditedBy,EditedOn = @EditedOn where SerialNumber  = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FromDate), (object) FromDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ToDate), (object) ToDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (Company), (object) Company),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode)
      }, ref strError);
    }
  }
}
