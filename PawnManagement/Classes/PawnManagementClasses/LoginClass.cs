
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class LoginClass
  {
    public static string getLastUsedUserName()
    {
      string strError = "";
      string my_querry = "select * from tblLogin where LastUsed = 'Y'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["UserName"] != null && dataTable2.Rows[0]["UserName"].ToString() != "" ? dataTable2.Rows[0]["UserName"].ToString() : "";
    }

    public static void UpdateLastUsed(string YesOrNo, string UserName)
    {
      string strError1 = "";
      SQLHelper.RunCommand("update tblLogin set LastUsed = @LastUsed where UserName = @UserName", new List<OleDbParameter>()
      {
        new OleDbParameter("LastUsed", (object) YesOrNo),
        new OleDbParameter(nameof (UserName), (object) UserName)
      }, ref strError1);
      string strError2 = "";
      SQLHelper.RunCommand("update tblLogin set LastUsed = @LastUsed where UserName <> @UserName", new List<OleDbParameter>()
      {
        new OleDbParameter("LastUsed", (object) "N"),
        new OleDbParameter(nameof (UserName), (object) UserName)
      }, ref strError2);
    }

    public static DataTable getCompleteLoginTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * FROM tblLogin order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static List<string> getAllTheUserNames()
    {
      string strError = "";
      List<string> allTheUserNames = new List<string>();
      string my_querry = "select username from tblLogin";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allTheUserNames.Add(row["username"].ToString());
      }
      return allTheUserNames;
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblLogin where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static bool checkIfUserNameAlreadyExists(string strUserName)
    {
      string strError = "";
      string my_querry = "select * from tblLogin where UserName = @UserName";
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

    public static string deleteBillerBasedOnThisSerialNumber(double Id)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblLogin where Id = @Id", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Id), (object) Id)
      }, ref strError);
    }

    public static string addLogin(
      string UserName,
      string Password,
      string MemberId,
      string LastUsed,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblLogin(UserName,Pwd,CreatedBy,CreatedOn,LastUsed) values(@UserName,@Pwd,@CreatedBy,@CreatedOn,@LastUsed)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (UserName), (object) UserName),
        new OleDbParameter("Pwd", (object) PawnManagementClass.encrypt(MemberId + Password)),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (LastUsed), (object) LastUsed)
      }, ref strError);
    }

    public static string editLogin(
      string UserName,
      string Password,
      string MemberId,
      string LastUsed,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update tblLogin set Pwd = @Pwd,EditedBy=@EditedBy,EditedOn = @EditedOn where UserName = @UserName", new List<OleDbParameter>()
      {
        new OleDbParameter("Pwd", (object) PawnManagementClass.encrypt(MemberId + Password)),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (UserName), (object) UserName)
      }, ref strError);
    }

    public static string deleteLogin(string columnName, string strVAlue)
    {
      string strError = "";
      return SQLHelper.RunCommand("dELETE from tblLogin where " + columnName + " =@" + columnName, new List<OleDbParameter>()
      {
        new OleDbParameter(columnName, (object) strVAlue)
      }, ref strError);
    }
  }
}
