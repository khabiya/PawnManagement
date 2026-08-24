
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class PurityMasterClass
  {
    public static DataTable getCompletePurityMasterTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select Metal,Purity,PurityLabel,Melting from tblPurityMaster order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblPurityMaster where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static double getTheMeltingForThisPurity(string purity)
    {
      string strError = "";
      string my_querry = "select * from tblPurityMaster where Purity = @Purity";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Purity", (object) purity)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? double.Parse(dataTable2.Rows[0]["Melting"].ToString()) : 0.0;
    }

    public static List<string> getAllThePurity()
    {
      string strError = "";
      List<string> allThePurity = new List<string>();
      string my_querry = "select Purity from tblPurityMaster";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allThePurity.Add(row["Purity"].ToString());
      }
      return allThePurity;
    }

    public static string deleteRecordBasedOnThisPurity(string Purity)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblPurityMaster where Purity = @Purity", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Purity), (object) Purity)
      }, ref strError);
    }

    public static bool checkIfPurityAlreadyExists(string strPurity)
    {
      string strError = "";
      string my_querry = "select * from tblPurityMaster where Purity = @Purity";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Purity", (object) strPurity)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addPurity(
      string Metal,
      string Purity,
      string PurityLabel,
      double Melting,
      string deletable,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblPurityMaster(Metal,Purity,PurityLabel,Melting,Deletable,EditedBy,EditedOn,createdBy,createdOn) values (  @Metal,@Purity,@PurityLabel,@Melting,@Deletable, @EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter(nameof (PurityLabel), (object) PurityLabel),
        new OleDbParameter(nameof (Melting), (object) Melting),
        new OleDbParameter("Deletable", (object) deletable),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editPurity(
      string Metal,
      string Purity,
      string PurityLabel,
      double Melting,
      string deletable,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblPurityMaster set Metal = @Metal,PurityLabel = @PurityLabel,Melting = @Melting,Deletable = @Deletable, EditedBy = @EditedBy,EditedOn = @EditedOn where Purity = @Purity", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (PurityLabel), (object) PurityLabel),
        new OleDbParameter(nameof (Melting), (object) Melting),
        new OleDbParameter("Deletable", (object) deletable),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (Purity), (object) Purity)
      }, ref strError);
    }
  }
}
