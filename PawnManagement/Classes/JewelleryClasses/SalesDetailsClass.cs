
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class SalesDetailsClass
  {
    public static DataTable getCompleteSalesDetailsTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static DataTable getBill(string BillNumber, string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
    }

    public static DataTable getBillIncludingHsnCode(string BillNumber, string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails   where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
    }

    public static string deleteSalesDetailsBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblSalesDetails where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static string deleteSalesDetails(string CompanyCode, string BillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblSalesDetails where CompanyCode = @CompanyCode and BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails where SerialNumber = @SerialNumber";
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

    public static bool checkIfInvoiceNumberAlreadyExists(
      string strInvoiceNumber,
      string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblSalesDetails where InvoiceNumber = @InvoiceNumber and CompanyCode = @CompanyCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("InvoiceNumber", (object) strInvoiceNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addSalesDetails(
      string BillNumber,
      string Type,
      string ItemCode,
      string Itemname,
      double Quantity,
      double GrossWeight,
      double StoneWeight,
      double NetWeight,
      double Wastage,
      double MakingCharge,
      double StoneCharge,
      double HallMark,
      double RAte,
      double Amount,
      double Gst,
      double GstAmount,
      double TotalAmount,
      string EditedBy,
      DateTime EditedOn,
      string CreatedBy,
      DateTime CreatedOn)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblSalesDetails(BillNumber,Type,  ItemCode, Itemname, Quantity, GrossWeight, StoneWeight, NetWeight, Wastage, MakingCharge, StoneCharge, HallMark, Rate,Amount, Gst, GstAmount, TotalAmount,  EditedBy,  EditedOn,  CreatedBy,  CreatedOn) values (@BillNumber,@Type, @ItemCode, @Itemname, @Quantity, @GrossWeight, @StoneWeight, @NetWeight, @Wastage, @MakingCharge, @StoneCharge, @HallMark,@Rate, @Amount, @Gst, @GstAmount, @TotalAmount,  @EditedBy, @EditedOn,  @CreatedBy, @CreatedOn) ", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (Type), (object) Type),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter("ItemName", (object) Itemname),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (StoneWeight), (object) StoneWeight),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (Wastage), (object) Wastage),
        new OleDbParameter(nameof (MakingCharge), (object) MakingCharge),
        new OleDbParameter(nameof (StoneCharge), (object) StoneCharge),
        new OleDbParameter(nameof (HallMark), (object) HallMark),
        new OleDbParameter("Rate", (object) RAte),
        new OleDbParameter(nameof (Amount), (object) Amount),
        new OleDbParameter(nameof (Gst), (object) Gst),
        new OleDbParameter(nameof (GstAmount), (object) GstAmount),
        new OleDbParameter(nameof (TotalAmount), (object) TotalAmount),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editSales(
      string BillNumber,
      string Type,
      string ItemCode,
      string Itemname,
      string Description,
      double Quantity,
      double GrossWeight,
      double StoneWeight,
      double NetWeight,
      double Wastage,
      double MakingCharge,
      double StoneCharge,
      double HallMark,
      double Rate,
      double Amount,
      double Gst,
      double GstAmount,
      double TotalAmount,
      string EditedBy,
      DateTime EditedOn,
      string CreatedBy,
      DateTime CreatedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblSalesDetails  set Type = @Type, ItemCode = @ItemCode,ItemName = @ItemName,Quantity = @Quantity,GrossWeight = @GrossWeight,StoneWeight = @StoneWeight,NetWeight = @NetWeightWastage = @Wastage,MakingCharge = @MakingCharge,StoneCharge = @StoneCharge,HallMark = @HallMark,Rate = @Rate,Amount = @Amount,Gst = @Gst ,GstAmount = @GstAmount TotalAmount = @TotalAmount  EditedBy = @EditedBy,EditedOn = @EditedOn where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Type), (object) Type),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter("ItemName", (object) Itemname),
        new OleDbParameter(nameof (Quantity), (object) Quantity),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (StoneWeight), (object) StoneWeight),
        new OleDbParameter(nameof (NetWeight), (object) TotalAmount),
        new OleDbParameter(nameof (Wastage), (object) Wastage),
        new OleDbParameter(nameof (MakingCharge), (object) MakingCharge),
        new OleDbParameter(nameof (StoneCharge), (object) StoneCharge),
        new OleDbParameter(nameof (HallMark), (object) HallMark),
        new OleDbParameter(nameof (Rate), (object) Rate),
        new OleDbParameter(nameof (Amount), (object) Amount),
        new OleDbParameter(nameof (Gst), (object) Gst),
        new OleDbParameter(nameof (GstAmount), (object) GstAmount),
        new OleDbParameter(nameof (TotalAmount), (object) TotalAmount),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
    }
  }
}
