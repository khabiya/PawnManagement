
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PawnManagement.Classes.PawnManagementClasses
{
  internal class SettingsClass
  {
    public static string UpdateRememberUsernameAndPassword(string YesOrNo)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblSettings set RememberUserNameAndPassword = @RememberUserNameAndPassword", new List<OleDbParameter>()
      {
        new OleDbParameter("RememberUserNameAndPassword", (object) YesOrNo)
      }, ref strError);
    }

    public static string getNoticeChargeInPledgeScreen()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblSettings", new List<OleDbParameter>(), ref strError);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return "0";
      return dataTable.Rows[0]["NoticeChargeInPledgeScreen"] != null && dataTable.Rows[0]["NoticeChargeInPledgeScreen"].ToString() != "" ? dataTable.Rows[0]["NoticeChargeInPledgeScreen"].ToString() : dataTable.Rows[0]["NoticeChargeInPledgeScreen"].ToString();
    }

    public static string getNoticeChargeInRedemptionScreen()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblSettings", new List<OleDbParameter>(), ref strError);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return "0";
      return dataTable.Rows[0]["NoticeChargeInRedemptionScreen"] != null && dataTable.Rows[0]["NoticeChargeInRedemptionScreen"].ToString() != "" ? dataTable.Rows[0]["NoticeChargeInRedemptionScreen"].ToString() : dataTable.Rows[0]["NoticeChargeInRedemptionScreen"].ToString();
    }

    public static bool getRememberUserNameAndPassword()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["RememberUserNameAndPassword"] != null && dataTable2.Rows[0]["RememberUserNameAndPassword"].ToString() != "" && dataTable2.Rows[0]["RememberUserNameAndPassword"].ToString() == "Y";
    }

    public static string getCustomerAddEditSetting()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["AddEditCustomerSetting"] != null && dataTable2.Rows[0]["AddEditCustomerSetting"].ToString() != "" ? dataTable2.Rows[0]["AddEditCustomerSetting"].ToString() : "SIMPLE";
    }

    public static bool getCustomerRemindIFNameAndAddressSame()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["RemindIfNameAndAddressSame"] != null && dataTable2.Rows[0]["RemindIfNameAndAddressSame"].ToString() != "" && dataTable2.Rows[0]["RemindIfNameAndAddressSame"].ToString() == "Y";
    }

    public static bool getCustomerRemindIFNameAndAddressAndDoorNumberSame()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"] != null && dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"].ToString() != "" && dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"].ToString() == "Y";
    }

    public static string getMenuSetting()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MenuSettings"] != null ? dataTable2.Rows[0]["MenuSettings"].ToString() : "";
    }

    public static string UpdateMenusetting(string YesOrNo)
    {
      string strError = "";
      return SQLHelper.RunCommand("update tblSettings set Menusettings = @Menusettings", new List<OleDbParameter>()
      {
        new OleDbParameter("Menusettings", (object) YesOrNo)
      }, ref strError);
    }
  }
}
