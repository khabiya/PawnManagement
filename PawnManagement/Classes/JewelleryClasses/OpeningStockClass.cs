
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class OpeningStockClass
  {
    public static DataTable getCompleteOpeningStockTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblOpeningStock order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblOpeningStock where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deleteOpeningStockBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblOpeningStock where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblOpeningStock where SerialNumber = @SerialNumber";
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

    public static string addOpeningStock(
      double SerialNumber,
      string FinYearCode,
      string ItemCode,
      double OpeningStock,
      string CompanyName,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblOpeningStock(SerialNumber,PurchaseType,ItemType,Quantity,PurchasedFrom,InvoiceNumber,PurchasedBy,Price,BillType,EditedBy,EditedOn,createdBy,createdOn) values (@SerialNumber,@PurchaseType,@ItemType,@Quantity,@PurchasedFrom,@InvoiceNumber,@PurchasedBy,@Price,@BillType,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (OpeningStock), (object) OpeningStock),
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editOpeningStock(
      double SerialNumber,
      string FinYearCode,
      string ItemCode,
      double OpeningStock,
      string CompanyName,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblOpeningStock set FinYearCode = @FinYearCode,ItemCode = @ItemCode,OpeningStock = @OpeningStock,CompanyName = @CompanyName, EditedBy = @EditedBy,EditedOn = @EditedOn where SerialNumber  = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (OpeningStock), (object) OpeningStock),
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber)
      }, ref strError);
    }
  }
}
