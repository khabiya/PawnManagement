
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class StockClass
  {
    public static DataTable getCompleteStockTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblStock order by " + OrderByColumnName;
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

    public static string deleteStockBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblStock where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblStock where SerialNumber = @SerialNumber";
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

    public static string addStock(
      double SerialNumber,
      string ItemCode,
      double Quantity,
      string PurchasedFrom,
      string PurchasedBy,
      DateTime PurchasedOn,
      string FinYearCode,
      string CompanyName,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblStock(SerialNumber,ItemCode,Quantity,PurchasedFrom,PurchasedBy,PurchasedOn,FinYearCode,Company,EditedBy,EditedOn,createdBy,createdOn) values (@SerialNumber,@ItemCode,@Quantity,@PurchasedFrom,@PurchasedBy,@PurchasedOn,@FinYearCode,@Company,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (PurchasedFrom), (object) PurchasedFrom),
        new OleDbParameter(nameof (PurchasedBy), (object) PurchasedBy),
        new OleDbParameter(nameof (PurchasedOn), (object) PurchasedOn),
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode),
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editStock(
      double SerialNumber,
      string ItemCode,
      double Quantity,
      string PurchasedFrom,
      string PurchasedBy,
      DateTime PurchasedOn,
      string FinYearCode,
      string CompanyName,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblStock set ItemCode = @ItemCode,Quantity = @Quantity,PurchasedFrom = @PurchasedFrom,PurchasedBy = @PurchasedBy,PurchasedOn = @PurchasedOn,FinYearCode = @FinYearCode,CompanyName = @CompanyName, EditedBy = @EditedBy,EditedOn = @EditedOn where SerialNumber  = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (PurchasedFrom), (object) PurchasedFrom),
        new OleDbParameter(nameof (PurchasedBy), (object) PurchasedBy),
        new OleDbParameter(nameof (PurchasedOn), (object) PurchasedOn),
        new OleDbParameter(nameof (FinYearCode), (object) FinYearCode),
        new OleDbParameter(nameof (CompanyName), (object) CompanyName),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber)
      }, ref strError);
    }
  }
}
