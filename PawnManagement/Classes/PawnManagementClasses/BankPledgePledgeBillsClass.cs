
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class BankPledgePledgeBillsClass
  {
    public static DataTable getPledgeBillsForBankBillNumber(string BankBillNumber)
    {
      string strError = "";
      return new DataTable() = SQLHelper.GetDataTable("select PledgeBillNumber,CustomerName,SHOPCODE from tblBankPledgePledgeBills where BankBillNumber = @BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError);
    }

    private void addBankPledgePledgeBillNumbers(
      string serialNumber,
      string bankBillNumber,
      string pledgeBillNumber,
      string customerName,
      string shopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblBankPledgePledgeBills(ShopCode,SerialNumber,BankBillNumber,PledgeBillNumber,CustomerName) values (@ShopCode,@SerialNumber,@BankBillNumber,@PledgeBillNumber,@CustomerName)", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode),
        new OleDbParameter("SerialNumber", (object) serialNumber),
        new OleDbParameter("BankBillNumber", (object) bankBillNumber),
        new OleDbParameter("PledgeBillNumber", (object) pledgeBillNumber),
        new OleDbParameter("CustomerName", (object) customerName)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addBankPledgePledgeBillNumbers", strError, FormMain.username, DateTime.Now.ToString());
    }

    public static string deleteBankPledgeArticles(string BankBillNumber)
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("delete from tblBankPledgePledgeBills where BankBillNumber = @BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError);
    }
  }
}
