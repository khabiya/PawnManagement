
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class LedgerMaster
  {
    public static DataTable getDataRowFromALedgerCode(string LedgerCode)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerType", (object) LedgerCode)
      }, ref strError);
    }

    public static string getLedgerName(string ledgerCode)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("LedgerCode", (object) ledgerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form getledgername", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["ledgertype"].ToString();
      return "";
    }

    public static string getLedgerNameInHindi(string ledgerCode)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("LedgerCode", (object) ledgerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form getledgername", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["ledgertypeInHindi"].ToString();
      return "";
    }

    public static string deleteLedger(string ID)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblLedgerr where ID =@ID", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ID), (object) ID)
      }, ref strError);
    }

    public static bool checkifLedgerTypeAlreadyExists(string LedgerType)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerType = @LedgerType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (LedgerType), (object) LedgerType)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addLedgerDetails(
      string LedgerCode,
      string LedgerType,
      string jammaOrNovae,
      string LedgerTypeInHindi,
      string Deletable,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblLedgerr(LedgerCode,LedgerType,jammaornovae,LedgerTypeInHindi,Deletable,CreatedBy,CreatedOn) values(@LedgerCode,@LedgerType,@jammaornovae,@LedgerTypeInHindi,@Deletable,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
        new OleDbParameter(nameof (LedgerType), (object) LedgerType),
        new OleDbParameter("jammaornovae", (object) jammaOrNovae),
        new OleDbParameter(nameof (LedgerTypeInHindi), (object) LedgerTypeInHindi),
        new OleDbParameter(nameof (Deletable), (object) Deletable),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editLedgerDetails(
      string ledgerType,
      string jammaOrNovae,
      string deletable,
      string ledgerTypeInHindi,
      string CreatedBy,
      string CreatedOn,
      string LedgerCode)
    {
      string strError = "";
      return SQLHelper.RunCommand("Update tblLedgerr set LedgerType=@LedgerType,jammaornovae = @jammaornovae,Deletable = @Deletable,LedgerTypeInHindi = @LedgerTypeInHindi,CreatedBy = @CreatedBy,CreatedOn = @CreatedOn where Ledgercode = @LedgerCode", new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerType", (object) ledgerType),
        new OleDbParameter("jammaornovae", (object) jammaOrNovae),
        new OleDbParameter("Deletable", (object) deletable),
        new OleDbParameter("LedgerTypeInHindi", (object) ledgerTypeInHindi),
        new OleDbParameter(nameof (CreatedBy), (object) CreatedBy),
        new OleDbParameter(nameof (CreatedOn), (object) CreatedOn),
        new OleDbParameter(nameof (LedgerCode), (object) LedgerCode)
      }, ref strError);
    }

    public static string getNextLedgerCode(string ledgerType)
    {
      if (!(ledgerType != ""))
        return "";
      char ch = ledgerType[0];
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblLedgerr where LedgerCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form LedgerDetails.tbxLedgerTyp_validating", strError, FormMain.username, DateTime.Now.ToString());
      if (dataTable == null)
        return "";
      if (dataTable.Rows.Count <= 0)
        return ch.ToString() + "1";
      return ch.ToString() + LedgerMaster.NextCustomerCode(dataTable);
    }

    public static string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["ledgerCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
    }

    public static DataTable getLedgerType()
    {
      string strError = "";
      string my_querry = "select distinct(LedgerType) from tblLedgerr";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form VocherMaster.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
      return dataTable2;
    }

    public static string getledgerCode(string LedgerType)
    {
      string strError = "";
      string my_querry = "select ledgercode,ledgertypeinhindi from tblLedgerr where ledgertype = @ledgertype";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ledgertype", (object) LedgerType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["ledgercode"].ToString() : "";
    }

    public static DataTable getDistinctLedgerType()
    {
      string strError = "";
      string my_querry = "select distinct(ledgertype) from tblLedgerr";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, ref strError);
    }
  }
}
