
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class LoginPermissionClass
  {
    public static DataTable getCompleteLoginPermissionTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblLoginPermission order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblLoginPermission where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static bool checkIfuserNameAlreadyExists(string strUserName)
    {
      string strError = "";
      string my_querry = "select * from tbxLoginPermission where UserName = @UserName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("UserName", (object) strUserName)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string deleteUserName(string strUsername)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblLoginPermission where Username = @UserName", new List<OleDbParameter>()
      {
        new OleDbParameter("UserName", (object) strUsername)
      }, ref strError);
    }

    public static string addUserName(
      string userName,
      string EditedBy,
      string EditedOn,
      string CreatedBy,
      string CreatedOn,
      List<string> permissions)
    {
      string strError = "";
      string my_querry = "insert into tblLoginPermission(UserName,EditedBy,EditedOn,CreatedBy,CreatedOn) values(@UserName,@EditedBy,@EditedOn,@CreatedBy,@CreatedOn)";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Username", (object) userName));
      parameters.Add(new OleDbParameter(nameof (EditedBy), (object) EditedBy));
      parameters.Add(new OleDbParameter(nameof (EditedOn), (object) EditedOn));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      foreach (string permission in permissions)
        parameters.Add(new OleDbParameter("", (object) permission));
      return SQLHelper.RunCommand(my_querry, parameters, ref strError);
    }

    public static string editUserName(
      string userName,
      string EditedBy,
      string EditedOn,
      string CreatedBy,
      string CreatedOn,
      List<string> permissions)
    {
      string strError = "";
      string my_querry = "Update tblLoginPermission set EditedBy = @EditedBy,EditedOn = @EditedOn,CreatedBy = @CreatedBy,CreatedOn = @CreatedOn where UserName = @UserName";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (EditedBy), (object) EditedBy));
      parameters.Add(new OleDbParameter(nameof (EditedOn), (object) EditedOn));
      parameters.Add(new OleDbParameter(nameof (CreatedBy), (object) CreatedBy));
      parameters.Add(new OleDbParameter(nameof (CreatedOn), (object) CreatedOn));
      foreach (string permission in permissions)
        parameters.Add(new OleDbParameter("", (object) permission));
      parameters.Add(new OleDbParameter("Username", (object) userName));
      return SQLHelper.RunCommand(my_querry, parameters, ref strError);
    }
  }
}
