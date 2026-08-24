		
	
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class BankPledgeClass
  {
    public static List<string> getListOfAllReleasedBankBillNumbers()
    {
      string strError = "";
      List<string> releasedBankBillNumbers = new List<string>();
      string my_querry = "Select distinct BankBillNumber from tblBankPledge where Released = 'Y'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          releasedBankBillNumbers.Add(row["BankBillNumber"].ToString());
      }
      return releasedBankBillNumbers;
    }

    public static bool checkIfBankBillNumberExists(string BankBillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null & dataTable2.Rows.Count > 0;
    }

    public static string deleteBankPledge(string BankBillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("Delete from tblBankPledge where BankBillNumber = @BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError);
    }

    public static string undoRedemption(string BankBillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("Update tblBankPledge set Interest=@Interest,RedemptionAmount = @RedemptionAmount,RedemptionDate = @RedemptionDate,Released = @Released where BankBillNumber=@BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("Interest", (object) DBNull.Value),
        new OleDbParameter("RedemptionAmount", (object) DBNull.Value),
        new OleDbParameter("RedemptionDate", (object) DBNull.Value),
        new OleDbParameter("Released", (object) "N"),
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError);
    }
  }
}
