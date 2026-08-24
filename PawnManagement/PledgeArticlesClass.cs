

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class PledgeArticlesClass
  {
    public static DataTable getPledgeArticlesClass(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeArticles where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static void insertIntoPledgeArticles(
      string ShopCode,
      string BillNumber,
      DataTable dgvArticles)
    {
      try
      {
        if (FormMain.withIndividualWeight)
        {
          for (int index = 0; index < dgvArticles.Rows.Count; ++index)
          {
            string Articles = dgvArticles.Rows[index]["Articles"].ToString();
            string ArticlesDescription = dgvArticles.Rows[index]["ArticlesDescription"] == null ? "" : dgvArticles.Rows[index]["ArticlesDescription"].ToString();
            string HiddenRemarks = dgvArticles.Rows[index]["Hr"] == null ? "" : dgvArticles.Rows[index]["hr"].ToString();
            double Purity = double.Parse(((dgvArticles.Rows[index]["Purity"] == null ? 1 : 0) | (dgvArticles.Rows[index]["Purity"] == null ? 0 : (dgvArticles.Rows[index]["Purity"].ToString() == "" ? 1 : 0))) != 0 ? "0" : dgvArticles.Rows[index]["Purity"].ToString());
            double GrossWeight = double.Parse(((dgvArticles.Rows[index]["GrossWeight"] == null ? 1 : 0) | (dgvArticles.Rows[index]["GrossWeight"] == null ? 0 : (dgvArticles.Rows[index]["GrossWeight"].ToString() == "" ? 1 : 0))) != 0 ? "0" : dgvArticles.Rows[index]["GrossWeight"].ToString());
            double Deduction = double.Parse(((dgvArticles.Rows[index]["Deduction"] == null ? 1 : 0) | (dgvArticles.Rows[index]["Deduction"] == null ? 0 : (dgvArticles.Rows[index]["Deduction"].ToString() == "" ? 1 : 0))) != 0 ? "0" : dgvArticles.Rows[index]["Deduction"].ToString());
            double NetWeight = double.Parse(((dgvArticles.Rows[index]["NetWeight"] == null ? 1 : 0) | (dgvArticles.Rows[index]["NetWeight"] == null ? 0 : (dgvArticles.Rows[index]["NetWeight"].ToString() == "" ? 1 : 0))) != 0 ? "0" : dgvArticles.Rows[index]["NetWeight"].ToString());
            double PureWeight = double.Parse(((dgvArticles.Rows[index]["PureWeight"] == null ? 1 : 0) | (dgvArticles.Rows[index]["PureWeight"] == null ? 0 : (dgvArticles.Rows[index]["PureWeight"].ToString() == "" ? 1 : 0))) != 0 ? "0" : dgvArticles.Rows[index]["PureWeight"].ToString());
            string no = dgvArticles.Rows[index]["Num"].ToString();
            PledgeArticlesClass.insertPledgeArticles(ShopCode, BillNumber, Articles, ArticlesDescription, HiddenRemarks, Purity, GrossWeight, Deduction, NetWeight, PureWeight, no);
          }
        }
        else
        {
          for (int index = 0; index < dgvArticles.Rows.Count; ++index)
          {
            string Articles = dgvArticles.Rows[index]["Articles"].ToString();
            string ArticlesDescription = dgvArticles.Rows[index]["ArticlesDescription"] == null ? "" : dgvArticles.Rows[index]["ArticlesDescription"].ToString();
            string HiddenRemarks = dgvArticles.Rows[index]["Hr"] == null ? "" : dgvArticles.Rows[index]["Hr"].ToString();
            string no = dgvArticles.Rows[index]["num"].ToString();
            PledgeArticlesClass.insertPledgeArticles(ShopCode, BillNumber, Articles, ArticlesDescription, HiddenRemarks, no);
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.savePledgeArticle", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public static void insertPledgeArticles(
      string ShopCode,
      string BillNumber,
      string Articles,
      string ArticlesDescription,
      string HiddenRemarks,
      double Purity,
      double GrossWeight,
      double Deduction,
      double NetWeight,
      double PureWeight,
      string no)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("insert into tblPledgeArticles(ShopCode,BillNumber,Articles,ArticlesDescription,Purity,Hr,GrossWeight,Deduction,NetWeight,PureWeight,Num,CreatedBy,CreatedOn) values(@ShopCode,@BillNumber,@Articles,@ArticlesDescription,@Purity,@Hr,@GrossWeight,@Deduction,@NetWeight,@PureWEight,@Num,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (Articles), (object) Articles),
        new OleDbParameter(nameof (ArticlesDescription), (object) ArticlesDescription),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter("Hr", (object) HiddenRemarks),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (Deduction), (object) Deduction),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (PureWeight), (object) PureWeight),
        new OleDbParameter("Num", (object) int.Parse(no)),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Today)
      }, ref strError);
      if (str == "Done")
        return;
      PawnManagementClass.InsertIntoException("form pledge.insertPledgeArticles", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in inserting into articles table       :" + str);
    }

    public static void insertPledgeArticles(
      string ShopCode,
      string BillNumber,
      string Articles,
      string ArticlesDescription,
      string HiddenRemarks,
      string no)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("insert into tblPledgeArticles(ShopCode,BillNumber,Articles,ArticlesDescription,Hr,Num,CreatedBy,CreatedOn) values(@ShopCode,@BillNumber,@Articles,@ArticlesDescription,@Hr,@Num,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (Articles), (object) Articles),
        new OleDbParameter(nameof (ArticlesDescription), (object) ArticlesDescription),
        new OleDbParameter("Hr", (object) HiddenRemarks),
        new OleDbParameter("Num", (object) int.Parse(no)),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Today)
      }, ref strError);
      if (!(str != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.insertPledgeArticles", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in inserting into articles table       :" + str);
    }
  }
}
