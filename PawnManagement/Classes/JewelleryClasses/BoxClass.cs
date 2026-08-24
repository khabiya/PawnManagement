
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class BoxClass
  {
    public static DataTable getCompleteBoxTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblBox order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblBox where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deleteBoxBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblBox where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBox where SerialNumber = @SerialNumber";
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

    public static string addBox(
      double SerialNumber,
      string BoxCode,
      string BoxName,
      string Description,
      double Weight,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblBox(SerialNumber,BoxCode,BoxName,Description,Weight,EditedBy,EditedOn,createdBy,createdOn) values (@SerialNumber,@BoxCode,@BoxName,@Description,@Weight,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (BoxCode), (object) BoxCode),
        new OleDbParameter(nameof (BoxName), (object) BoxName),
        new OleDbParameter(nameof (Description), (object) Description),
        new OleDbParameter(nameof (Weight), (object) Weight),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editPurchase(
      double SerialNumber,
      string BoxCode,
      string BoxName,
      string Description,
      double Weight,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblBox set BoxCode = @BoxCode,BoxName = @BoxName,Description = @Description,Weight = @Weight, EditedBy = @EditedBy,EditedOn = @EditedOn where SerialNumber  = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BoxCode), (object) BoxCode),
        new OleDbParameter(nameof (BoxName), (object) BoxName),
        new OleDbParameter(nameof (Description), (object) Description),
        new OleDbParameter(nameof (Weight), (object) Weight),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber)
      }, ref strError);
    }
  }
}
