
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class MetalMaster
  {
    public static DataTable getCompleteMetalMasterTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select Metal,ShortName,Description from tblMetalMaster order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static List<string> getAllTheMetals()
    {
      string strError = "";
      List<string> allTheMetals = new List<string>();
      string my_querry = "select Metal from tblMetalMaster";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allTheMetals.Add(row["Metal"].ToString());
      }
      return allTheMetals;
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblMetalMaster where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deleteThisMetal(string strMetal)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblMetalMaster where Metal = @Metal", new List<OleDbParameter>()
      {
        new OleDbParameter("Metal", (object) strMetal)
      }, ref strError);
    }

    public static bool checkIfMetalAlreadyExists(string strMetal)
    {
      string strError = "";
      string my_querry = "select * from tblMetalMaster where Metal = @Metal";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Metal", (object) strMetal)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addMetalMaster(
      string Metal,
      string ShortName,
      string Description,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblMetalMaster( Metal,ShortName,Description, EditedBy,EditedOn,createdBy,createdOn) values ( @Metal,@ShortName,@Description, @EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (ShortName), (object) ShortName),
        new OleDbParameter(nameof (Description), (object) Description),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editMetalMaster(
      string Metal,
      string ShortName,
      string Description,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblMetalMaster set ShortName = @ShortName,Description = @Description, EditedBy = @EditedBy,EditedOn = @EditedOn where Metal  = @Metal", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShortName), (object) ShortName),
        new OleDbParameter(nameof (Description), (object) Description),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (Metal), (object) Metal)
      }, ref strError);
    }
  }
}
