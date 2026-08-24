
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class VoucherMasterClass
  {
    public static string DELETEVOUCHER(string voucherNumber)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("Active", (object) "0"),
        new OleDbParameter("VoucherNumber", (object) voucherNumber)
      }, ref strError) == "Done"))
        return "";
      PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", "VOUCHER NUMBER " + voucherNumber + " deleted", "", "", FormMain.username, DateTime.Now.ToString());
      return "Done";
    }

    public static string addvoucherMaster(
      string voucherCode,
      string VoucherName,
      string Ledgercode,
      string LedgerType,
      DateTime createdOn,
      string createdBy)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblVoucherMaster(VoucherCode,VoucherName,LedgerCode,LedgerType,CreatedOn,CreatedBy) values(@VoucherCode,@VoucherName,@LedgerCode,@LedgerType,@CreatedOn,@CreatedBy)", new List<OleDbParameter>()
      {
        new OleDbParameter("Vouchercode", (object) voucherCode),
        new OleDbParameter(nameof (VoucherName), (object) VoucherName),
        new OleDbParameter("LedgerCode", (object) Ledgercode),
        new OleDbParameter(nameof (LedgerType), (object) LedgerType),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString()),
        new OleDbParameter("CreatedBy", (object) createdBy)
      }, ref strError);
    }

    public static string editVoucherMaster(
      string vouchername,
      string ledgertype,
      string ledgercode,
      string vouchercode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update tblVoucherMaster set VoucherName = @VoucherName,LedgerType = @LedgerType,LedgerCode = @LedgerCode where vouchercode = @vouchercode", new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherName", (object) vouchername),
        new OleDbParameter("LedgerType", (object) ledgertype),
        new OleDbParameter("LedgerCode", (object) ledgercode),
        new OleDbParameter(nameof (vouchercode), (object) vouchercode)
      }, ref strError);
    }

    public static bool checkIfVoucherNameAlreadyExists(string voucherName)
    {
      string strError = "";
      string my_querry = "select * from tblVoucherMaster where VoucherName = @VoucherName ";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("VoucherName", (object) voucherName)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form vouchermaster.checkifcouchernamealreadyexists()", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string getVoucherName(string voucherCode)
    {
      string strError = "";
      string my_querry = "select * from tblVoucherMaster where VoucherCode = @VoucherCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("VoucherCode", (object) voucherCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException(nameof (getVoucherName), strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["vouchername"].ToString();
      return "";
    }

    public static string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["VOUCHERCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
    }

    public static bool checkIfVoucherCodeIsUsed(string VoucherCode)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherCode = @VoucherCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (VoucherCode), (object) VoucherCode)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form VoucherMaster.checkifVoucherCodeIsUsed(string Vouchercode)", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string getNextVoucherCode(string vouchername)
    {
      char ch = vouchername[0];
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblVoucherMaster where VoucherCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form voucherMaster.tbxvouchername_validating", strError, FormMain.username, DateTime.Now.ToString());
      if (dataTable == null)
        return "";
      if (dataTable.Rows.Count <= 0)
        return ch.ToString() + "1";
      return ch.ToString() + VoucherMasterClass.NextCustomerCode(dataTable);
    }

    public static DataTable getVoucherNames(string LedgerCode)
    {
      string strError = "";
      string my_querry = "select VoucherName from tblVoucherMaster where LedgerCode= @LedgerCode order by vouchername";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (LedgerCode), (object) LedgerCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string getledgerCode(string VoucherCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode from tblvouchermaster where voucherCode = @voucherCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("voucherCode", (object) VoucherCode)
        }, ref strError);
        return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["Ledgercode"].ToString() : "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster..getledercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        return "";
      }
    }
  }
}
