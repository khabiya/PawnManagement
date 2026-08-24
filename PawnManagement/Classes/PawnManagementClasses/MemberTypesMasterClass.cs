

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class MemberTypesMasterClass
  {
    public static int getMaxMemberId()
    {
      string strError = "";
      string my_querry = "Select max(MemberId) AS MemberId from  tblMemberType ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MemberId"] != null && dataTable2.Rows[0]["MemberId"].ToString() != "" ? int.Parse(dataTable2.Rows[0]["MemberId"].ToString()) + 1 : 1;
    }

    public static List<string> getAllTheMemberTypes()
    {
      string strError = "";
      List<string> allTheMemberTypes = new List<string>();
      string my_querry = "select MemberType from tblMemberType";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          allTheMemberTypes.Add(row["MemberType"].ToString());
      }
      return allTheMemberTypes;
    }

    public static DataTable getMemberTypeTable()
    {
      string strError = "";
      string my_querry = "select * from tblMemberType order by MemberId";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    public static string getMemberIdForThisType(string MemberType)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where Membertype = @MemberType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberType), (object) MemberType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["MemberId"].ToString() : "";
    }

    public static string getMemberTypeForThisId(string MemberId)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where MemberId = @MemberId";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberId), (object) MemberId)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["Membertype"].ToString() : "";
    }

    public static DataTable getMemberTypeDataTableForThisId(string MemberId)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where MemberId = @MemberId";
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberId), (object) MemberId)
      }, ref strError);
    }

    public static string deleteMemberId(string MemberId)
    {
      string strError = "";
      return SQLHelper.RunCommand("Delete from tblMemberType where MemberId = @MemberId", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberId), (object) MemberId)
      }, ref strError);
    }

    public static bool checkIfMemberIdAlreadyExists(string MemberId)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where MemberId = @MemberId";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberId), (object) MemberId)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    public static bool checkIfMemberTypeAlreadyExists(string MemberType)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where MemberType = @MemberType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberType), (object) MemberType)
      }, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    public static string addMemberType(string MemberId, string MemberType)
    {
      string strError = "";
      return SQLHelper.RunCommand("insert into tblMemberType(MemberId,MemberType) values(@MemberId,@MemberType)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberId), (object) MemberId),
        new OleDbParameter(nameof (MemberType), (object) MemberType)
      }, ref strError);
    }

    public static string editMemberType(string MemberId, string MemberType)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblMemberType set MemberType = @MemberType  where MemberId  = @MemberId", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MemberType), (object) MemberType),
        new OleDbParameter(nameof (MemberId), (object) MemberId)
      }, ref strError);
    }
  }
}
