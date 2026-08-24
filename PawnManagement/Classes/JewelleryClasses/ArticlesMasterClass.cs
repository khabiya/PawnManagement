
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.JewelleryClasses
{
  internal class ArticlesMasterClass
  {
    public static DataTable getCompleteArticlesTable(string OrderByColumnName)
    {
      string strError = "";
      string my_querry = "select * from tblArticlesJewellery order by " + OrderByColumnName;
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static DataTable getAllTheRecordsBasedOnThisColumn(string ColumnName, string strValue)
    {
      string strError = "";
      string my_querry = "select * from tblArticlesJewellery where " + ColumnName + "= @" + ColumnName;
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(ColumnName, (object) strValue)
      }, ref strError);
    }

    public static string deleteArticleBasedOnThisArticleId(double ArticleId)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblArticlesJewellery where ArticleId = @ArticleId", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ArticleId), (object) ArticleId)
      }, ref strError);
    }

    public static bool checkIfArticleIdAlreadyExists(string strArticleId)
    {
      string strError = "";
      string my_querry = "select * from tblArticlesJewellery where ArticleId = @ArticleId";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ArticleId", (object) strArticleId)
      }, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    public static string addArticle(
      double ArticleId,
      string ItemCode,
      string ItemName,
      string BarCode,
      double GrossWeight,
      double StoneWeight,
      double NetWeight,
      double StoneCharge,
      string EditedBy,
      DateTime EditedOn,
      string createdBy,
      DateTime createdOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblArticlesJewellery(ArticleId,ItemCode,ItemName,BarCode,GrossWeight,StoneWeight,NetWeight,StoneCharge, EditedBy,EditedOn,createdBy,createdOn) values(@ArticleId,@ItemCode,@ItemName,@BarCode,@GrossWeight,@StoneWeight,@NetWeight,@StoneCharge,@EditedBy,@EditedOn,@createdBy,@createdOn)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ArticleId), (object) ArticleId),
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (ItemName), (object) ItemName),
        new OleDbParameter(nameof (BarCode), (object) BarCode),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (StoneWeight), (object) StoneWeight),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (StoneCharge), (object) StoneCharge),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) createdBy),
        new OleDbParameter("CreatedOn", (object) createdOn.ToString("dd/MM/yyyy"))
      }, ref strError);
    }

    public static string editArticle(
      double ArticleId,
      string ItemCode,
      string ItemName,
      string BarCode,
      double GrossWeight,
      double StoneWeight,
      double NetWeight,
      double StoneCharge,
      string EditedBy,
      DateTime EditedOn)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblArticlesJewellery set ItemCode = @ItemCode,ItemName  = @ItemName,BarCode = @BarCode,GrossWeight = @GrossWeight,StoneWeight = @StoneWeight,NetWeight = @NetWeight,StoneCharge = @StoneCharge,EditedBy = @EditedBy,EditedOn = @EditedOn where ArticleId = @ArticleId", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ItemCode), (object) ItemCode),
        new OleDbParameter(nameof (ItemName), (object) ItemName),
        new OleDbParameter(nameof (BarCode), (object) BarCode),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (StoneWeight), (object) StoneWeight),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (StoneCharge), (object) StoneCharge),
        new OleDbParameter(nameof (EditedBy), (object) EditedBy),
        new OleDbParameter(nameof (EditedOn), (object) EditedOn.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (ArticleId), (object) ArticleId)
      }, ref strError);
    }
  }
}
