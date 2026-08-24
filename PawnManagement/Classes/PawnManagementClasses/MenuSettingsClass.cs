
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class MenuSettingsClass
  {
    public static DataTable gettblMenuSettings()
    {
      string strError = "";
      string my_querry = "select * from tblMenuSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }
  }
}
