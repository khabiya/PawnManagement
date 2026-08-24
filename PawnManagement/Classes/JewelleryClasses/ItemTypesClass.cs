
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class ItemTypesClass
  {
    public static DataTable getCompleteItemTypeTable()
    {
      string strError = "";
      string my_querry = "select ItemType,Type,Metal,RateType,HsnCode from tblItemType order by CreatedOn";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheItemTypesBasedOnItemType(string ItemType)
    {
      string strError = "";
      string my_querry = "select * from tblItemType where ItemType = @ItemType";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
    }

    public static List<string> getAllTheItemTypes()
    {
      string strError = "";
      List<string> allTheItemTypes = new List<string>();
      string my_querry = "select ItemType from tblItemType";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allTheItemTypes.Add(row["ItemType"].ToString());
      }
      return allTheItemTypes;
    }

    public static List<string> getAllTheTypes()
    {
      string strError = "";
      List<string> allTheTypes = new List<string>();
      string my_querry = "select Type from tblItemType";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allTheTypes.Add(row["Type"].ToString());
      }
      return allTheTypes;
    }

    public static List<string> getAllTheItemRateTypes()
    {
      string strError = "";
      List<string> theItemRateTypes = new List<string>();
      string my_querry = "select RateType from tblItemType";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          theItemRateTypes.Add(row["RateType"].ToString());
      }
      return theItemRateTypes;
    }

    public static string getTypeBasedOnItemType(string ItemType)
    {
      string strError = "";
      string my_querry = "select Type from tblItemType where ItemType = @ItemType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["Type"].ToString() : "";
    }

    public static DataTable getAllTheItemsBasedOnHsnCode(string HsnCode)
    {
      string strError = "";
      string my_querry = "select * from tblItemType where HsnCode = @HsnCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (HsnCode), (object) HsnCode)
      }, ref strError);
    }

    public static string deleteItemType(string ItemType)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblItemType where ItemType = @ItemType", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
    }

    public static bool checkIfItemTypeAlreadyExists(string ItemType)
    {
      string strError = "";
      string my_querry = "select * from tblItemType where ItemType = @ItemType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addItemType(
      string ItemType,
      string Type,
      string Metal,
      string RateType,
      string HsnCode,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblItemType(ItemType,Type,Metal,RateType,HsnCode,EditedBy,EditedOn,createdBy,createdOn) values (@ItemType,@Type,@Metal,@RateType,@HsnCode,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemType), (object) ItemType),
        new OleDbParameter(nameof (Type), (object) Type),
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (RateType), (object) RateType),
        new OleDbParameter(nameof (HsnCode), (object) HsnCode),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editItemType(
      string ItemType,
      string Type,
      string Metal,
      string RateType,
      string HsnCode,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblItemType set Type = @Type,Metal = @Metal,RateType = @RateType,HsnCode = @HsnCode,EditedBy = @EditedBy,EditedOn = @EditedOn  where ItemType = @ItemType", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (Type), (object) Type),
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (RateType), (object) RateType),
        new OleDbParameter(nameof (HsnCode), (object) HsnCode),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ItemType), (object) ItemType)
      }, ref strError);
    }
  }
}
