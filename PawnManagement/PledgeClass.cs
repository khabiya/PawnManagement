
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class PledgeClass
  {
    public static bool checkifpledgetableempty(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return false;
      return true;
    }

    public static List<string> getUndredeemedBillNumbers(string shopCode)
    {
      List<string> undredeemedBillNumbers = new List<string>();
      string strError = "";
      string my_querry = "Select distinct BillNumber from tblPledge where redeemed = 'N' and ShopCode = @ShopCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode)
      }, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          undredeemedBillNumbers.Add(row["BillNumber"].ToString());
      }
      return undredeemedBillNumbers;
    }

    public static bool checkifpledgetableempty()
    {
      string strError = "";
      string my_querry = "select * from tblPledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return false;
      return true;
    }

    public static DataTable getPledgeBill(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getPledgeBillAfterRenamingColumns(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static bool returnTrueIfPledgeBillREleased(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["Redeemed"].ToString() == "Y" | dataTable2.Rows[0]["Redeemed"].ToString() == "A";
    }

    public static string getMaxBillNumber(string ShopCode)
    {
      string str = "'" + PawnManagementClass.getPledgeBillNumberSeries(ShopCode) + "%'";
      string strError = "";
      string my_querry = "select max(billnumber) as MaxBillNumber from tblPledge where shopcode = @ShopCode and BillNumber Like " + str;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["MaxBillNumber"].ToString();
      return "";
    }

    public static DataTable getLastBilledBillNumber()
    {
      string strError = "";
      string my_querry = "select BillNumber,shopcode from tblPledge order by pledgecreatedon desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static bool checkIfBillNumberIsValid(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    public static DataTable getDatatablePledgeBill(string ShopDetails, string BillNumber)
    {
      string strError = "";
      return SQLHelper.GetDataTable("select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber =@BillNumber AND ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("ShopCode", (object) ShopDetails)
      }, ref strError);
    }
  }
}
