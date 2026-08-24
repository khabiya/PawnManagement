

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class ItemNamesMasterClass
  {
    public static DataTable getCompleteItemNamesTable()
    {
      string strError = "";
      string my_querry = "select ItemType,ItemCode,ItemName,PurchasePurity,StoneCharge,Melting,Wastage,MakingCharge,HallMark,Purity,StoneChargeType,MakingChargeType,CGst,Sgst,Igst,PurchasePrice,SellingPrice,Mrp from tblItemNames order by CreatedOn";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheItemsBasedOnItemType(string ItemType)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemType = @ItemType";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
    }

    public static DataTable getAllTheItemsBasedOnTheseColumns(List<string> lstColumns)
    {
      string strError = "";
      string str = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      foreach (string lstColumn in lstColumns)
      {
        str = str + lstColumn + "=@" + lstColumn;
        parameters.Add(new OleDbParameter(lstColumn, (object) lstColumn));
      }
      return SQLHelper.GetDataTable("select * from tblItemNames where " + str, parameters, ref strError);
    }

    public static DataTable getAllTheItemsBasedOnTheSearch(string strSearch)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      string my_querry = "select * from tblItemNames where ItemType like @ItemType OR ItemName like @ItemName OR PurchasePurity like @PurchasePurity OR StoneCharge like @StoneCharge OR Melting like @Melting OR Wastage like @Wastage OR MakingCharge like @MakingCharge OR HallMark like @Hallmark OR ItemCode like @ItemCode OR Purity like @Purity OR StoneChargeType like @StoneChargeType OR MakingChargeType like @MakingChargeType OR CGst like @CGst OR SGst like @SGst OR IGst like @IGst OR PurchasePrice like @PurchasePrice OR SellingPrice like @SellingPrice OR Mrp like @Mrp";
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      parameters.Add(new OleDbParameter("", (object) ("%" + strSearch + "%")));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheItemsBasedOnItemCode(string ItemCode)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemCode = @ItemCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode)
      }, ref strError);
    }

    public static DataTable getAllTheItemsIncludingHsnCodeBasedOnItemCode(string ItemCode)
    {
      string strError = "";
      string my_querry = "select *,tit.HsnCode from tblItemNames tin left join tblItemType tit  on tin.ItemType  = tit.ItemType  where ItemCode = @ItemCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode)
      }, ref strError);
    }

    public static DataTable getAllTheItemsBasedOnItemName(string ItemName)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemName = @ItemName";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemName), (object) ItemName)
      }, ref strError);
    }

    public static string deleteItem(string ItemName)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblItemNames where ItemName = @ItemName", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemName), (object) ItemName)
      }, ref strError);
    }

    public static string deleteItemCode(string ItemCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblItemNames where ItemCode = @ItemCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode)
      }, ref strError);
    }

    public static bool checkIfItemNameAlreadyExists(string ItemName)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemName = @ItemName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemName), (object) ItemName)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static bool checkIfItemNameAlreadyExistsExceptThisItemCode(
      string ItemName,
      string ItemCode)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemName = @ItemName  AND ItemCode <> '" + ItemCode + "'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemName), (object) ItemName)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
        return false;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    public static bool checkIfItemCodeAlreadyExists(string ItemCode)
    {
      string strError = "";
      string my_querry = "select * from tblItemNames where ItemCode = @ItemCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addItem(
      string ItemCode,
      string ItemType,
      string ItemName,
      double PurchasePurity,
      string Purity,
      double Melting,
      double Wastage,
      string stoneChargeType,
      double stoneCharge,
      string makingChargeType,
      double MakingCharge,
      double HallMark,
      double CGst,
      double SGst,
      double IGst,
      double PurchasePrice,
      double SellingPrice,
      double Mrp,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblItemNames(ItemType,ItemCode,ItemName,PurchasePurity,Purity,Melting,Wastage,StoneChargeType,StoneCharge,MakingChargeType,MakingCharge,HallMark,CGst,SGst,IGst,    PurchasePrice,SellingPrice,Mrp,EditedBy,EditedOn,CreatedBy,CreatedOn) values (@ItemType,@ItemCode,@ItemName,@PurchasePurity,@Purity,@Melting,@Wastage,@StoneChargeType,@StoneCharge,@MakingChargeType,@MakingCharge,@HallMark,@CGst,@SGst,@IGst,@PurchasePrice,@SellingPrice,@Mrp,@EditedBy,@EditedOn,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (ItemName), (object) ItemName),
        new OleDbParameter(nameof (PurchasePurity), (object) PurchasePurity),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter(nameof (Melting), (object) Melting),
        new OleDbParameter(nameof (Wastage), (object) Wastage),
        new OleDbParameter("StoneChargeType", (object) stoneChargeType),
        new OleDbParameter("StoneCharge", (object) stoneCharge),
        new OleDbParameter("MakingChargeType", (object) makingChargeType),
        new OleDbParameter(nameof (MakingCharge), (object) MakingCharge),
        new OleDbParameter(nameof (HallMark), (object) HallMark),
        new OleDbParameter(nameof (CGst), (object) CGst),
        new OleDbParameter(nameof (SGst), (object) SGst),
        new OleDbParameter(nameof (IGst), (object) IGst),
        new OleDbParameter(nameof (PurchasePrice), (object) PurchasePrice),
        new OleDbParameter(nameof (SellingPrice), (object) SellingPrice),
        new OleDbParameter(nameof (Mrp), (object) Mrp),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editItem(
      string ItemCode,
      string ItemType,
      string ItemName,
      double PurchasePurity,
      string Purity,
      double Melting,
      double Wastage,
      string stoneChargeType,
      double stoneCharge,
      string makingChargeType,
      double MakingCharge,
      double HallMark,
      double CGst,
      double SGst,
      double IGst,
      double PurchasePrice,
      double SellingPrice,
      double Mrp,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblItemNames set  ItemType = @ItemType,ItemName =  @ItemName,PurchasePurity = @PurchasePurity,Purity = @Purity,Melting = @Melting,Wastage = @Wastage,StoneChargeType = @StoneChargeType,StoneCharge = @StoneCharge,MakingChargeType = @MakingChargeType,MakingCharge = @MakingCharge,Hallmark = @HallMark,CGst = @CGst,SGst = @SGst,IGst = @IGst,PurchasePrice = @PurchasePrice,SellingPrice = @SellingPrice,Mrp = @Mrp,EditedBy = @EditedBy,EditedOn = @EditedOn where ItemCode  = @ItemCode ", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType),
        new OleDbParameter(nameof (ItemName), (object) ItemName),
        new OleDbParameter(nameof (PurchasePurity), (object) PurchasePurity),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter(nameof (Melting), (object) Melting),
        new OleDbParameter(nameof (Wastage), (object) Wastage),
        new OleDbParameter("StoneChargeType", (object) stoneChargeType),
        new OleDbParameter("StoneCharge", (object) stoneCharge),
        new OleDbParameter("MakingChargeType", (object) makingChargeType),
        new OleDbParameter(nameof (MakingCharge), (object) MakingCharge),
        new OleDbParameter(nameof (HallMark), (object) HallMark),
        new OleDbParameter(nameof (CGst), (object) CGst),
        new OleDbParameter(nameof (SGst), (object) SGst),
        new OleDbParameter(nameof (IGst), (object) IGst),
        new OleDbParameter(nameof (PurchasePrice), (object) PurchasePrice),
        new OleDbParameter(nameof (SellingPrice), (object) SellingPrice),
        new OleDbParameter(nameof (Mrp), (object) Mrp),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode)
      }, ref strError);
    }
  }
}
