
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class BillerClass
  {
    public static DataTable getCompleteBillerTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblBiller order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblBiller where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static bool checkIfBillerAlreadyExists(string strBillerName)
    {
      string strError = "";
      string my_querry = "select * from tblBiller where BillerName = BillerName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("BillerName", (object) strBillerName)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string deleteBillerBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblBiller where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static string addBiller(
      string BillerName,
      string BillerDetails,
      string BillerPhoneNumber,
      string UserType,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblBiller(BillerName,BillerDetails,BillerPhoneNumber,UserType) values(@BillerName,@BillerDetails,@BillerPhoneNumber,@UserType)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillerName), (object) BillerName),
        new OleDbParameter(nameof (BillerDetails), (object) BillerDetails),
        new OleDbParameter(nameof (BillerPhoneNumber), (object) BillerPhoneNumber),
        new OleDbParameter(nameof (UserType), (object) UserType)
      }, ref strError);
    }

    public static string editBiller(
      string BillerName,
      string BillerDetails,
      string BillerPhoneNumber,
      string UserType,
      string ID,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update TBLbILLER set BillerName = @BillerName,BillerDetails = @BillerDetails,BillerPhoneNumber=@BillerPhoneNumber,UserType = @UserType where ID = @ID", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillerName), (object) BillerName),
        new OleDbParameter(nameof (BillerDetails), (object) BillerDetails),
        new OleDbParameter(nameof (BillerPhoneNumber), (object) BillerPhoneNumber),
        new OleDbParameter(nameof (UserType), (object) UserType),
        new OleDbParameter(nameof (ID), (object) ID)
      }, ref strError);
    }

    public static string deleteBiller(string columnName, string strVAlue)
    {
      string strError = "";
      return SQLHelper.RunCommand("dELETE from tblBiller where " + columnName + " =@" + columnName, new List<OleDbParameter>()
      {
        new OleDbParameter(columnName, (object) strVAlue)
      }, ref strError);
    }

    public static string getDefaultValue()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblbiller where defaultvalue = 'Y'", ref strError);
      return strError == "" && dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0]["BillerName"].ToString() : "";
    }

    public static List<string> getBillerNamesBasedOnThisColumn(string columnName, string strValue)
    {
      string strError = "";
      List<string> basedOnThisColumn = new List<string>();
      string my_querry = "select BillerName from tblBiller where " + columnName + "=@" + columnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(columnName, (object) strValue));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          basedOnThisColumn.Add(row["BillerName"].ToString());
      }
      return basedOnThisColumn;
    }
  }
}
