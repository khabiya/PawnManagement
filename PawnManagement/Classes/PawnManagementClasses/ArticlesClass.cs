

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class ArticlesClass
  {
    public static DataTable getEmptyArticles(string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeArticles where shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static bool checkIfArticleExists(string strArticleName)
    {
      string strError = "";
      string my_querry = "Select * from tblArticles where article = @Article";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Article", (object) strArticleName));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeeidt. checkAndAddIfArticlesNotFoundInArticlesTable(DataTable dt1)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(" checkAndAddIfArticlesNotFoundInArticlesTable(DataTable dt1)" + strError);
        return false;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }
  }
}
