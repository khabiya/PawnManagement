
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class OldPurchaseClass
  {
    public static DataTable getCompleteOldPurchase(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblOldPurchase order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblOldPurchase where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static DataTable getOldPurchase(string BillNumber, string strCompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblOldPurchase where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("CompanyCode", (object) strCompanyCode)
      }, ref strError);
    }

    public static string deleteOldPurchaseBasedOnThisSerialNumber(double serialNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblOldPurchase where SerialNumber = @SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("SerialNumber", (object) serialNumber)
      }, ref strError);
    }

    public static string deleteOldPurchase(string CompanyCode, string BillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblOldPurchase where CompanyCode = @CompanyCode and BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
    }

    public static bool checkIfSerialNumberAlreadyExists(string strSerialNumber)
    {
      string strError = "";
      string my_querry = "select * from tblOldPurchase where SerialNumber = @SerialNumber";
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

    public static bool checkIfBillNumberAlreadyExists(string strBillNumber, string CompanyCode)
    {
      string strError = "";
      string my_querry = "select * from tblOldPurchase where BillNumber = @BillNumber and CompanyCode = @CompanyCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber", (object) strBillNumber),
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addOldPurchase(
      string CompanyCode,
      double SerialNumber,
      string BillNumber,
      DateTime BillDate,
      string CustomerCode,
      string Metal,
      string ItemName,
      string Description,
      double GrossWeight,
      double Dirt,
      double Arakku,
      double StoneOrEnamel,
      double NetWeight,
      string Purity,
      double PureWeight,
      double Rate,
      double Amount,
      string EditedBy,
      DateTime EditedOn,
      string CreatedBy,
      DateTime CreatedOn)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("insert into tblOldPurchase(CompanyCode,\tSerialNumber,BillNumber,BillDate,CustomerCode,\tMetal,\tItemName,\tDescription,\tGrossWeight,\tDirt\t,Arakku,\tStoneOrEnamel\t,NetWeight,\tPurity,\tPureWeight,\tRate,\tAmount,\tEditedBy,\tEditedOn,\tCreatedBy,\tCreatedOn) values (@CompanyCode,\t@SerialNumber,\t@BillNumber,\t@BillDate,\t@CustomerCode,\t@Metal,\t@ItemName,\t@Description,\t@GrossWeight,\t@Dirt,\t@Arakku,\t@StoneOrEnamel,\t@NetWeight,\t@Purity,\t@PureWeight,\t@Rate,\t@Amount,\t@EditedBy,\t@EditedOn,\t@CreatedBy,\t@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CompanyCode), (object) CompanyCode),
        new OleDbParameter(nameof (SerialNumber), (object) SerialNumber),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (BillDate), (object) BillDate.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode),
        new OleDbParameter(nameof (Metal), (object) Metal),
        new OleDbParameter(nameof (ItemName), (object) ItemName),
        new OleDbParameter(nameof (Description), (object) Description),
        new OleDbParameter("GrossWEight", (object) GrossWeight),
        new OleDbParameter(nameof (Dirt), (object) Dirt),
        new OleDbParameter(nameof (Arakku), (object) Arakku),
        new OleDbParameter(nameof (StoneOrEnamel), (object) StoneOrEnamel),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter(nameof (PureWeight), (object) PureWeight),
        new OleDbParameter(nameof (Rate), (object) Rate),
        new OleDbParameter(nameof (Amount), (object) Amount),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("COMPANYCODE", (object) CompanyCode)
      }, ref strError);
    }

    public static string getMaxSerialNumber(string CompanyCode)
    {
      string strError = "";
      string my_querry = "Select max(SerialNumber) AS MaxSerialNumber from tblOldPurchase where CompanyCode = @CompanyCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CompanyCode), (object) CompanyCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MaxSerialNumber"] != null && dataTable2.Rows[0]["MaxSerialNumber"].ToString() != "" ? dataTable2.Rows[0]["MaxSerialNumber"].ToString() : "";
    }
  }
}
