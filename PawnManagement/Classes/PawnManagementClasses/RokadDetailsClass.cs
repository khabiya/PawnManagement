
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class RokadDetailsClass
  {
    public static string getOpeningBalance(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0]["OpeningBalance"].ToString() : "0";
    }

    public static string getOpeningBalance(DateTime d1, DateTime d2)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select OpeningBalance from tblRokadDetails where rokadDate >= @FromDate and rokadDate <=ToDate order by rokaddate";
      parameters.Add(new OleDbParameter("FromDate", (object) d1));
      parameters.Add(new OleDbParameter("ToDate", (object) d2));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0]["OpeningBalance"].ToString() : "0";
    }

    public static DataTable getRokadDetails(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string UpdateJammaSideClosingAndNovaeSideClosing(
      string voucherDate,
      double jammaSideClosing,
      double novaeSideClosing)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblRokadDetails set NovaeSideClosing = @NovaeSideClosing , JammaSideClosing = @JammaSideClosing where voucherDate= @VoucherDate", new List<OleDbParameter>()
      {
        new OleDbParameter("NovaeSideClosing", (object) novaeSideClosing),
        new OleDbParameter("JammaSideClosing", (object) jammaSideClosing),
        new OleDbParameter("VoucherDate", (object) voucherDate)
      }, ref strError) == "Done" ? "Done" : "";
    }
  }
}
