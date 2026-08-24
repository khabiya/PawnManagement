// Decompiled with JetBrains decompiler
// Type: PawnManagement.Classes.PawnManagementClasses.LocationAndPincodeClass
// Assembly: PawnManagement, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF38565-09F5-4945-B63E-4A76BB004257
// Assembly location: E:\Ramesh Pawn Soft\Pawnstar\Release\PawnManagement.exe

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class LocationAndPincodeClass
  {
    public static List<string> getDistinctLocation()
    {
      string strError = "";
      List<string> distinctLocation = new List<string>();
      string my_querry = "select Location,City,Pincode from tblPincode order by location asc";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          distinctLocation.Add(row["Location"].ToString());
      }
      return distinctLocation;
    }

    public static string getDefaultLocation()
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode where DefaultValue = 'Y'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0].Field<string>("Location") : "";
    }

    public static DataTable getCityAndPincode(string location)
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode where Location = @Location";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Location", (object) location));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }
  }
}
