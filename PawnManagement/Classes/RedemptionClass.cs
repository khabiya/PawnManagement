
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes
{
  internal class RedemptionClass
  {
    public static bool checkifRedemptionTableEmpty(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where shopCode = @ShopCode";
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

    public static bool checkifRedemptionTableEmpty()
    {
      string strError = "";
      string my_querry = "select * from tblRedemption";
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

    public static string getMaxRedemptionNumber(string ShopCode)
    {
      string strError = "";
      string my_querry = "select max(billnumber) as MaxBillNumber from tblRedemption where shopcode = @ShopCode";
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

    public static DataTable getLastBilledRedemptionNumber()
    {
      string strError = "";
      string my_querry = "select shopcode,billnumber,PledgeBillNumber from tblRedemption order by createdon desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getRedemptionBill(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber = @BillNumber  and  shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Billnumber", (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }
  }
}
