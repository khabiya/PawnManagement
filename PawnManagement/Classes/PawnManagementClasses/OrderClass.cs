
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class OrderClass
  {
    public static string getColumnOrderForLedgerScreen1()
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) "LedgerScreen1")
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the LedgerDetails\n" + strError);
        return " p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,RedemptionAmount16 as RedemptionAmount,REdemptionDate,RedemptionBillNumber";
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return " p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,RedemptionAmount16 as RedemptionAmount,REdemptionDate,RedemptionBillNumber";
      return ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) != 0 ? " p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles, strconcat( RedemptionAmount16 ,AuctionAmount) as RedemptionAmount,REdemptionDate,RedemptionBillNumber" : dataTable2.Rows[0]["ColumnOrder"].ToString();
    }

    public static bool checkIfFormNameExists(string strFormName)
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) strFormName)
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the LedgerDetails\n" + strError);
        return false;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    public static string getColumnOrderForLedgerScreen2()
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) "LedgerScreen2")
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the LedgerDetails\n" + strError);
        return " p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,temp4 as RedemptionAmount,REdemptionDate,RedemptionBillNumber";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0 ? dataTable2.Rows[0]["ColumnOrder"].ToString() : " p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,temp4 as RedemptionAmount,REdemptionDate,RedemptionBillNumber";
    }

    public static string getColumnOrderForPledgeBookScreen(string type)
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (type == "2")
        parameters.Add(new OleDbParameter("FormName", (object) "PledgeBookScreen2"));
      else
        parameters.Add(new OleDbParameter("FormName", (object) "PledgeBookScreen1"));
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the LedgerDetails\n" + strError);
        return type == "1" ? " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.redemptionamount16 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber" : " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.temp4 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber";
      }
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0)
          return dataTable2.Rows[0]["ColumnOrder"].ToString();
        return type == "1" ? " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.redemptionamount16 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber" : " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.temp4 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber";
      }
      return type == "1" ? " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.redemptionamount16 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber" : " p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight,  articles ,p.temp4 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber";
    }

    public static string getColumnOrderForPledgeReportsScreen()
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) "PledgeReports")
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the LedgerDetails\n" + strError);
        return " p2.ShopCode,p2.BillNumber,p2.OldBillNumber, p2.BillDate, p2.CustomerCode,nameAndAddress,p2.amount, p2.PresentValue, p2.NetWeight, p2.InterestRate, p2.TYPE,articles,p2.BankCode,p2.BankSerialNumber,p2.redeemed,p2.FinalInterest,p2.RedemptionAmount,p2.RedemptionDate";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0 ? dataTable2.Rows[0]["ColumnOrder"].ToString() : " p2.ShopCode,p2.BillNumber,p2.OldBillNumber, p2.BillDate, p2.CustomerCode,nameAndAddress,p2.amount, p2.PresentValue, p2.NetWeight, p2.InterestRate, p2.TYPE,articles,p2.BankCode,p2.BankSerialNumber,p2.redeemed,p2.FinalInterest,p2.RedemptionAmount,p2.RedemptionDate";
    }

    public static List<string> getcolumnsToHide(string FormName)
    {
      string strError = "";
      List<string> hide = new List<string>();
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FormName), (object) FormName)
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      else
      {
        if (dataTable2 == null || dataTable2.Rows.Count <= 0 || ((dataTable2.Rows[0]["HideColumns"] == null ? 1 : 0) | (dataTable2.Rows[0]["HideColumns"] == null ? 0 : (dataTable2.Rows[0]["HideColumns"].ToString() == "" ? 1 : 0))) != 0)
          return hide;
        string str1 = dataTable2.Rows[0]["HideColumns"].ToString();
        if (str1 == "")
          return hide;
        string str2 = str1;
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
          hide.Add(str3.Trim());
      }
      return hide;
    }
  }
}
