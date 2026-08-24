
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class PurchaseClass
  {
    public static DataTable getCompletePurchaseTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblPurchase order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblPurchase where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deletePurchaseBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblPurchase where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblPurchase where SerialNumber = @SerialNumber";
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

    public static string addPurchase(
      double SerialNumber,
      string PurchaseType,
      string ItemType,
      string Quantity,
      string PurchasedFrom,
      string InvoiceNumber,
      string PurchasedBy,
      double Price,
      string BillType,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblPurchase(SerialNumber,PurchaseType,ItemType,Quantity,PurchasedFrom,InvoiceNumber,PurchasedBy,Price,BillType,EditedBy,EditedOn,createdBy,createdOn) values (@SerialNumber,@PurchaseType,@ItemType,@Quantity,@PurchasedFrom,@InvoiceNumber,@PurchasedBy,@Price,@BillType,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (PurchaseType), (object) PurchaseType),
        new OleDbParameter(nameof (ItemType), (object) ItemType),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (PurchasedFrom), (object) PurchasedFrom),
        new OleDbParameter(nameof (InvoiceNumber), (object) InvoiceNumber),
        new OleDbParameter(nameof (PurchasedBy), (object) PurchasedBy),
        new OleDbParameter(nameof (Price), (object) Price),
        new OleDbParameter(nameof (BillType), (object) BillType),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editPurchase(
      double SerialNumber,
      string PurchaseType,
      string ItemType,
      string Quantity,
      string PurchasedFrom,
      string InvoiceNumber,
      string PurchasedBy,
      double Price,
      string BillType,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblPurchase set PurchaseType = @PurchaseType,@ItemType,Quantity = @Quantity,PurchasedFrom = @PurchasedFrom,InvoiceNumber = @InvoiceNumber,PurchasedBy = @PurchasedBy,Price = @Price,BillType = @BillType,EditedBy = @EditedBy,EditedOn = @EditedOn where SerialNumber  = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (PurchaseType), (object) PurchaseType),
        new OleDbParameter(nameof (ItemType), (object) ItemType),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (PurchasedFrom), (object) PurchasedFrom),
        new OleDbParameter(nameof (InvoiceNumber), (object) InvoiceNumber),
        new OleDbParameter(nameof (PurchasedBy), (object) PurchasedBy),
        new OleDbParameter(nameof (Price), (object) Price),
        new OleDbParameter(nameof (BillType), (object) BillType),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber)
      }, ref strError);
    }
  }
}
