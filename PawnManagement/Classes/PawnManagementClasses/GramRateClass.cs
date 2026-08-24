
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class GramRateClass
  {
    public static DataTable getCompleteGramRateTable()
    {
      string strError = "";
      string my_querry = "select * from tblGramRate";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, ref strError);
    }

    public static string getDefaultPurity(string Type)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblGramRate where Type=@Type";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (Type), (object) Type));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledgeCalculator.getDefaultPurity", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching Value and amount" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          return dataTable2.Rows[0]["DefaultPurity"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(ex.Message, ex.StackTrace.ToString(), FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "0";
    }

    public static DataTable getRecordForThisType(string Type)
    {
      string strError = "";
      string my_querry = "select * from tblGramRate where Type=@Type";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (Type), (object) Type));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string UpdateGramRate(
      string KachaRate,
      string PledgeRate,
      string SaleRate,
      string Deduction,
      string DefaultPurity,
      string Type)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblGramRate set KachaRate= @KachaRate,PledgeRate = @PledgeRate,SaleRate = @SaleRate,Deduction = @Deduction,DefaultPurity = @DefaultPurity where Type = @Type", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (KachaRate), (object) KachaRate),
        new OleDbParameter(nameof (PledgeRate), (object) PledgeRate),
        new OleDbParameter(nameof (SaleRate), (object) SaleRate),
        new OleDbParameter(nameof (Deduction), (object) Deduction),
        new OleDbParameter(nameof (DefaultPurity), (object) DefaultPurity),
        new OleDbParameter(nameof (Type), (object) Type)
      }, ref strError);
    }
  }
}
