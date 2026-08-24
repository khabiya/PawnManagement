
using CSharpCustomPanelControl;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPrintSettings : Form
  {
    private IContainer components = (IContainer) null;
    private ComboBox cbOfficeCopy;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private CheckBox cbEnterIndividualWeight;
    private CheckBox cbHistoryReminderPrompt;
    private CheckBox cbBankRenewalReminder;
    private CheckBox cbBankPledgeToBeReleasedtoday;
    private TextBox tbxValueAutoAdjust;
    private Label label2;
    private CheckBox cbPendingGirvi;
    private CustomPanel customPanel1;
    private GlassButton glassButton1;
    private Label label4;
    private Label label1;
    private ComboBox cbCustomerCopy;
    private HeaderPanel headerPanel11;
    private Label label5;
    private ComboBox cbRedemptionBillFormats;
    private GlassButton btnRedemptionBillSettings;
    private CheckBox cbRedemptionBillPrintPrompt;
    private GlassButton glassButton3;
    private GlassButton glassButton10;
    private CheckBox cbAutoFillAmount;
    private GlassButton glassButton19;
    private GlassButton glassButton22;
    private CheckBox cbMaintainOldestBillNumber;
    private CheckBox cbReduceFirstMonthInterest;
    private CheckBox cbFingerPrint;
    private CheckBox cbAutoOnFingerPrint;
    private CheckBox cbMainFormFullScreen;
    private CheckBox cbPledgeScreenSimple;
    private ComboBox comboBox1;
    private CheckBox cbIncludeNoticeChargeInPledgeScreen;
    private TextBox tbxIncludeNoticeChargeInPledgeScreen;
    private CheckBox cbIncludeNoticeChargeInRedemptionScreen;
    private TextBox tbxIncludeNoticeChargeInRedemptionScreen;
    private ComboBox cbPrintCustomerCopy;
    private Label label7;
    private ComboBox cbPrintOfficeCopy;
    private Label label6;
    private CheckBox checkBox4;
    private CheckBox cbViewPledgeAndRedemptionInSide;
    private Label label8;
    private CheckBox cbPledgeWithoutBackgroundWorker;
    private CheckBox cbQuickRelease;

    public FormPrintSettings() => this.InitializeComponent();

    private void gettblSettings()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbEnterIndividualWeight.Checked = dataTable2.Rows[0]["WithIndividualWeight"].ToString() == "Y";
        if (dataTable2.Rows[0]["ValueAutoAdjustSetting"] != null)
        {
          if (dataTable2.Rows[0]["ValueAutoAdjustSetting"].ToString() != "")
            this.tbxValueAutoAdjust.Text = dataTable2.Rows[0]["ValueAutoAdjustSetting"].ToString();
          else
            this.tbxValueAutoAdjust.Text = "0";
        }
        else
          this.tbxValueAutoAdjust.Text = "0";
        if (dataTable2.Rows[0]["MaintainOldestBillNumber"] != null)
        {
          if (dataTable2.Rows[0]["MaintainOldestBillNumber"].ToString() != "")
          {
            if (dataTable2.Rows[0]["MaintainOldestBillNumber"].ToString() == "Y")
              this.cbMaintainOldestBillNumber.Checked = true;
          }
          else
            this.cbMaintainOldestBillNumber.Checked = false;
        }
        else
          this.cbMaintainOldestBillNumber.Checked = false;
        if (dataTable2.Rows[0]["ReduceFirstMonthInterest"] != null)
        {
          if (dataTable2.Rows[0]["ReduceFirstMonthInterest"].ToString() != "")
          {
            if (dataTable2.Rows[0]["ReduceFirstMonthInterest"].ToString() == "Y")
              this.cbReduceFirstMonthInterest.Checked = true;
          }
          else
            this.cbReduceFirstMonthInterest.Checked = false;
        }
        else
          this.cbReduceFirstMonthInterest.Checked = false;
        if (dataTable2.Rows[0]["UseFingerPrint"] != null)
        {
          if (dataTable2.Rows[0]["UseFingerPrint"].ToString() != "")
          {
            if (dataTable2.Rows[0]["UseFingerPrint"].ToString() == "Y")
              this.cbFingerPrint.Checked = true;
          }
          else
            this.cbFingerPrint.Checked = false;
        }
        else
          this.cbFingerPrint.Checked = false;
        if (dataTable2.Rows[0]["AutoOnFingerPrint"] != null)
        {
          if (dataTable2.Rows[0]["AutoOnFingerPrint"].ToString() != "")
          {
            if (dataTable2.Rows[0]["AutoOnFingerPrint"].ToString() == "Y")
              this.cbAutoOnFingerPrint.Checked = true;
          }
          else
            this.cbAutoOnFingerPrint.Checked = false;
        }
        else
          this.cbAutoOnFingerPrint.Checked = false;
        if (dataTable2.Rows[0]["MainFormFullScreen"] != null)
        {
          if (dataTable2.Rows[0]["MainFormFullScreen"].ToString() != "")
          {
            if (dataTable2.Rows[0]["MainFormFullScreen"].ToString() == "Y")
              this.cbMainFormFullScreen.Checked = true;
          }
          else
            this.cbMainFormFullScreen.Checked = false;
        }
        else
          this.cbMainFormFullScreen.Checked = false;
        if (dataTable2.Rows[0]["PledgeScreenSimple"] != null)
        {
          if (dataTable2.Rows[0]["PledgeScreenSimple"].ToString() != "")
          {
            if (dataTable2.Rows[0]["PledgeScreenSimple"].ToString() == "Y")
              this.cbPledgeScreenSimple.Checked = true;
          }
          else
            this.cbPledgeScreenSimple.Checked = false;
        }
        else
          this.cbPledgeScreenSimple.Checked = false;
        if (dataTable2.Rows[0]["PledgeWithoutbackgroundWorker"] != null)
        {
          if (dataTable2.Rows[0]["PledgeWithoutbackgroundWorker"].ToString() != "")
          {
            if (dataTable2.Rows[0]["PledgeWithoutbackgroundWorker"].ToString() == "Y")
              this.cbPledgeWithoutBackgroundWorker.Checked = true;
          }
          else
            this.cbPledgeWithoutBackgroundWorker.Checked = false;
        }
        else
          this.cbPledgeWithoutBackgroundWorker.Checked = false;
        if (dataTable2.Rows[0]["AddEditCustomerSetting"] != null && dataTable2.Rows[0]["AddEditCustomerSetting"].ToString() != "")
          this.comboBox1.Text = dataTable2.Rows[0]["aDDEDITCUSTOMERSETTING"].ToString();
        else
          this.comboBox1.Text = "SIMPLE";
        if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"] != null)
        {
          if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"].ToString() != "")
          {
            if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"].ToString() == "Y")
              this.cbIncludeNoticeChargeInPledgeScreen.Checked = true;
          }
          else
            this.cbIncludeNoticeChargeInPledgeScreen.Checked = false;
        }
        else
          this.cbIncludeNoticeChargeInPledgeScreen.Checked = false;
        if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"] != null)
        {
          if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"].ToString() != "")
          {
            if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"].ToString() == "Y")
              this.cbIncludeNoticeChargeInRedemptionScreen.Checked = true;
          }
          else
            this.cbIncludeNoticeChargeInRedemptionScreen.Checked = false;
        }
        else
          this.cbIncludeNoticeChargeInRedemptionScreen.Checked = false;
        if (dataTable2.Rows[0]["NoticeChargeInPledgeScreen"] != null)
        {
          if (dataTable2.Rows[0]["NoticeChargeInPledgeScreen"].ToString() != "")
            this.tbxIncludeNoticeChargeInPledgeScreen.Text = dataTable2.Rows[0]["NoticeChargeInPledgeScreen"].ToString();
          else
            this.tbxIncludeNoticeChargeInPledgeScreen.Text = "0";
        }
        else
          this.tbxIncludeNoticeChargeInPledgeScreen.Text = "0";
        if (dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"] != null)
        {
          if (dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"].ToString() != "")
            this.tbxIncludeNoticeChargeInRedemptionScreen.Text = dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"].ToString();
          else
            this.tbxIncludeNoticeChargeInRedemptionScreen.Text = "0";
        }
        else
          this.tbxIncludeNoticeChargeInRedemptionScreen.Text = "0";
        if (dataTable2.Rows[0]["PrintOFFiceCopy"] != null)
        {
          if (dataTable2.Rows[0]["PrintOFFiceCopy"].ToString() != "")
            this.cbPrintOfficeCopy.Text = dataTable2.Rows[0]["PrintOFFiceCopy"].ToString();
          else
            this.cbPrintOfficeCopy.Text = "YES AFTER ASKING";
        }
        else
          this.cbPrintOfficeCopy.Text = "YES AFTER ASKING";
        if (dataTable2.Rows[0]["PrintCustomerCopy"] != null)
        {
          if (dataTable2.Rows[0]["PrintCustomerCopy"].ToString() != "")
            this.cbPrintCustomerCopy.Text = dataTable2.Rows[0]["PrintCustomerCopy"].ToString();
          else
            this.cbPrintCustomerCopy.Text = "YES AFTER ASKING";
        }
        else
          this.cbPrintCustomerCopy.Text = "YES AFTER ASKING";
        if (dataTable2.Rows[0]["ViewPledgeAndRedemptionInSide"] != null)
        {
          if (dataTable2.Rows[0]["ViewPledgeAndRedemptionInSide"].ToString() != "")
          {
            if (dataTable2.Rows[0]["ViewPledgeAndRedemptionInSide"].ToString() == "Y")
              this.cbViewPledgeAndRedemptionInSide.Checked = true;
          }
          else
            this.cbViewPledgeAndRedemptionInSide.Checked = false;
        }
        else
          this.cbViewPledgeAndRedemptionInSide.Checked = false;
        if (dataTable2.Rows[0]["QuickRelease"] != null)
        {
          if (dataTable2.Rows[0]["QuickRelease"].ToString() != "")
          {
            if (dataTable2.Rows[0]["QuickRelease"].ToString() == "Y")
              this.cbQuickRelease.Checked = true;
          }
          else
            this.cbQuickRelease.Checked = false;
        }
        else
          this.cbQuickRelease.Checked = false;
      }
    }

    private void gettblPrintSettings()
    {
      string strError = "";
      string my_querry = "select * from tblprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.gethistoryremindersettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.gethistoryremidnersettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbHistoryReminderPrompt.Checked = dataTable2.Rows[0]["HistoryReminderPrompt"] != null && dataTable2.Rows[0]["HistoryReminderPrompt"].ToString() == "Y";
        this.cbAutoFillAmount.Checked = dataTable2.Rows[0]["AutoFillAmount"].ToString() == "Y";
        this.cbPendingGirvi.Checked = dataTable2.Rows[0]["PendingGirviTotalPrompt"] != null && dataTable2.Rows[0]["PendingGirviTotalPrompt"].ToString() == "Y";
        this.cbBankRenewalReminder.Checked = dataTable2.Rows[0]["BankRenewalReminderPrompt"] != null && dataTable2.Rows[0]["BankRenewalReminderPrompt"].ToString() == "Y";
        this.cbBankPledgeToBeReleasedtoday.Checked = dataTable2.Rows[0]["BankPledgeToBeReleasedTodayPrompt"] != null && dataTable2.Rows[0]["BankPledgeToBeReleasedTodayPrompt"].ToString() == "Y";
        this.checkBox2.Checked = dataTable2.Rows[0]["jewelphotoprompt"].ToString().Equals("Y");
      }
    }

    public static bool getAutoFillAmountt()
    {
      string strError = "";
      string my_querry = "select * from TBLPRINTSETTINGS";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["AutoFillAmount"].ToString() == "Y")
        return true;
      return false;
    }

    private void getPrintSettings()
    {
      string strError = "";
      string my_querry = "select * from tblPledgePrintSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbOfficeCopy.Items.Clear();
        this.cbCustomerCopy.Items.Clear();
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          if (row["PrintFormats"].ToString() != "")
          {
            this.cbOfficeCopy.Items.Add((object) row["PrintFormats"].ToString());
            this.cbCustomerCopy.Items.Add((object) row["PrintFormats"].ToString());
          }
        }
      }
    }

    private void getRedemptionBillPrintSettings()
    {
      string strError = "";
      string my_querry = "select * from tblredemptionprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbRedemptionBillFormats.Items.Clear();
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          if (row["RedemptionBillPrintFormats"].ToString() != "")
            this.cbRedemptionBillFormats.Items.Add((object) row["RedemptionBillPrintFormats"].ToString());
        }
        this.cbRedemptionBillPrintPrompt.Checked = dataTable2.Rows[0]["RedemptionBillprintprompt"].ToString().Equals("Y");
      }
    }

    private void getAutoEntryRokad()
    {
      string strError = "";
      string my_querry = "select * from tblAutoDeleteRokad";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getAutoEntryRokad()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getAutoEntryRokad()");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.checkBox3.Checked = dataTable2.Rows[0]["AutoEntry"].ToString().Equals("Y");
    }

    public static string getDefaultPrintFormat()
    {
      string strError = "";
      string my_querry = "select * from tblpledgeprintSettings where printformatsdefaultvalue = @printformatsdefaultvalue";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("printformatsdefaultvalue", (object) "Y"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["printformats"].ToString();
      return "";
    }

    public static string getDefaultRedemptionBillPrintFormat()
    {
      string strError = "";
      string my_querry = "select * from tblredemptionprintSettings where RedemptionBillPrintFormatsDefaultValue = @RedemptionBillPrintFormatsDefaultValue";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("RedemptionBillPrintFormatsDefaultValue", (object) "Y"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["RedemptionBillPrintFormats"].ToString();
      return "";
    }

    public static string getDefaultPrintFormatCustomerCopy()
    {
      string strError = "";
      string my_querry = "select * from tblpledgeprintSettings where PrintFormatsCustomerCopyDefaultValue = @PrintFormatsCustomerCopyDefaultValue";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("PrintFormatsCustomerCopyDefaultValue", (object) "Y"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["PrintFormats"].ToString();
      return "";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPrintSettings_Load(object sender, EventArgs e)
    {
      this.gettblPrintSettings();
      this.gettblSettings();
      this.getPrintSettings();
      this.getRedemptionBillPrintSettings();
      this.getAutoEntryRokad();
      this.cbOfficeCopy.Text = FormPrintSettings.getDefaultPrintFormat();
      this.cbCustomerCopy.Text = FormPrintSettings.getDefaultPrintFormatCustomerCopy();
      this.cbRedemptionBillFormats.Text = FormPrintSettings.getDefaultRedemptionBillPrintFormat();
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void setRedemptionBillPrintPrompt()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblredemptionprintsettings set RedemptionBillPrintPrompt = @RedemptionBillPrintPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("RedemptionBillPrintPrompt", this.cbRedemptionBillPrintPrompt.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setprintprompt", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setJewelPhotoPrompt()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblprintsettings set jewelPhotoPrompt = @jewelPhotoPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("jewelPhotoPrompt", this.checkBox2.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setjewelphotoprompt", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setRokadAutoEntry()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblautodeleterokad set autoentry = @autoentry", new List<OleDbParameter>()
      {
        new OleDbParameter("autoentry", this.checkBox3.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setRokadAutoEntry()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setHistoryReminderPrompt()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblPrintSettings set HistoryReminderPrompt = @HistoryReminderPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("HistoryReminderPrompt", this.cbHistoryReminderPrompt.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setHistoryReminderPrompt()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setPendingGirviTotalPrompt()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblPrintSettings set PendingGirviTotalPrompt = @PendingGirviTotalPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("PendingGirviTotalPrompt", this.cbPendingGirvi.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setHistoryReminderPrompt()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setBankRenewalReminder()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblPrintSettings set BankRenewalReminderPrompt = @BankRenewalReminderPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("BankRenewalReminderPrompt", this.cbBankRenewalReminder.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setHistoryReminderPrompt()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setBankPledgeToBeReleasedToday()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblPrintSettings set BankPledgeToBeReleasedTodayPrompt = @BankPledgeToBeReleasedTodayPrompt", new List<OleDbParameter>()
      {
        new OleDbParameter("BankPledgeToBeReleasedTodayPrompt", this.cbBankPledgeToBeReleasedtoday.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setHistoryReminderPrompt()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void setRedemptionBillDefaultPrintFormat()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblredemptionprintsettings  set RedemptionBillPrintFormatsDefaultValue = @RedemptionBillPrintFormatsDefaultValue where RedemptionBillPrintFormats = @RedemptionBillPrintFormats", new List<OleDbParameter>()
      {
        new OleDbParameter("RedemptionBillPrintFormatsDefaultValue", (object) "Y"),
        new OleDbParameter("RedemptionBillPrintFormats", (object) this.cbRedemptionBillFormats.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setDefaultPrintFormat1()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblpledgeprintsettings set printformatsdefaultValue = @printformatsdefaultvalue where PrintFormats = @PrintFormats", new List<OleDbParameter>()
      {
        new OleDbParameter("PrintFormatsdefaultvalue", (object) "Y"),
        new OleDbParameter("PrintFormats", (object) this.cbOfficeCopy.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setDefaultPrintFormat2()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("UPDATE tblpledgeprintsettings SET printformatsdefaultValue = [@printformatsdefaultvalue] WHERE PrintFormats<>[@PrintFormats]", new List<OleDbParameter>()
      {
        new OleDbParameter("printformatsdefaultvalue", (object) "N"),
        new OleDbParameter("PrintFormats", (object) this.cbOfficeCopy.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setRedemptionBillDefaultPrintFormat2()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("UPDATE tblredemptionprintsettings  SET RedemptionBillPrintFormatsDefaultValue = [@RedemptionBillPrintFormatsDefaultValue] WHERE RedemptionBillPrintFormats<>[@RedemptionBillPrintFormats]", new List<OleDbParameter>()
      {
        new OleDbParameter("RedemptionBillPrintFormatsDefaultValue", (object) "N"),
        new OleDbParameter("RedemptionBillPrintFormats", (object) this.cbRedemptionBillFormats.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setDefaultPrintFormat1CustomerCopy()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblpledgeprintsettings set printformatsCustomerCopydefaultValue = @printformatsCustomerCopydefaultValue where PrintFormats = @PrintFormats", new List<OleDbParameter>()
      {
        new OleDbParameter("printformatsCustomerCopydefaultValue", (object) "Y"),
        new OleDbParameter("PrintFormats", (object) this.cbCustomerCopy.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setDefaultPrintFormat2CustomerCopy()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("UPDATE tblpledgeprintsettings  SET printformatsCustomerCopydefaultValue = [@printformatsCustomerCopydefaultValue] WHERE PrintFormats<>[@PrintFormats]", new List<OleDbParameter>()
      {
        new OleDbParameter("printformatsCustomerCopydefaultValue", (object) "N"),
        new OleDbParameter("PrintFormats", (object) this.cbCustomerCopy.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setDefaultPrintFormat()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setDefaultPrintFormat()");
    }

    private void setIndividualWeightEntry()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblsettings set WithIndividualWeight = @WithIndividualWeight", new List<OleDbParameter>()
      {
        new OleDbParameter("WithIndividualWeight", this.cbEnterIndividualWeight.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.individualWeightEntry", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void getIndividualWeight()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        FormMain.withIndividualWeight = dataTable2.Rows[0]["WithIndividualWeight"].ToString() == "Y";
    }

    private void setFingerPrintSetting()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblsettings set UseFingerPrint = @UseFingerPrint", new List<OleDbParameter>()
      {
        new OleDbParameter("UseFingerPrint", this.cbFingerPrint.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      if (this.cbFingerPrint.Checked)
        FormMain.UseFingerPrint = true;
      else
        FormMain.UseFingerPrint = false;
    }

    private void setAutoFingerPrintOn()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblsettings set AutoOnFingerPrint = @AutoOnFingerPrint", new List<OleDbParameter>()
      {
        new OleDbParameter("AutoOnFingerPrint", this.cbAutoOnFingerPrint.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      if (this.cbAutoOnFingerPrint.Checked)
        FormMain.UseFingerPrint = true;
      else
        FormMain.UseFingerPrint = false;
    }

    private void setMainFormFullScreen()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblsettings set MainFormFullScreen = @MainFormFullScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("MainFormFullScreen", this.cbMainFormFullScreen.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      if (this.cbMainFormFullScreen.Checked)
        FormMain.UseFingerPrint = true;
      else
        FormMain.UseFingerPrint = false;
    }

    private void setPledgeScreenSimple()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblsettings set PledgeScreenSimple = @PledgeScreenSimple", new List<OleDbParameter>()
      {
        new OleDbParameter("PledgeScreenSimple", this.cbPledgeScreenSimple.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
    }

    private void setPledgeWithoutBackgroundWorker()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblsettings set PledgeWithoutBackgroundWorker = @PledgeWithoutBackgroundWorker", new List<OleDbParameter>()
      {
        new OleDbParameter("PledgeWithoutBackgroundWorker", this.cbPledgeWithoutBackgroundWorker.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
    }

    private void setQuickRelease()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblsettings set QuickRelease = @QuickRelease", new List<OleDbParameter>()
      {
        new OleDbParameter("QuickRelease", this.cbQuickRelease.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
    }

    private void setAddEditCustomerSetting()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblsettings set AddEditCustomerSetting = @AddEditCustomerSetting", new List<OleDbParameter>()
      {
        new OleDbParameter("AddEditCustomerSetting", (object) this.comboBox1.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
    }

    private void setAutoAdjustValueTo()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set ValueAutoAdjustSetting= @ValueAutoAdjustSetting", new List<OleDbParameter>()
      {
        new OleDbParameter("ValueAutoAdjustSetting", (object) this.tbxValueAutoAdjust.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setAutoAdjustValueTo()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      this.setRokadAutoEntry();
      if (PawnManagementClass.getRokadAutoEntrySettings())
      {
        ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tslAutoEntryRokad"].Text = "";
      }
      else
      {
        ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tslAutoEntryRokad"].Text = "Auto Entry Rokad is OFF";
        ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tslAutoEntryRokad"].ForeColor = Color.Red;
      }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e) => this.setJewelPhotoPrompt();

    private void cbEnterIndividualWeight_CheckedChanged(object sender, EventArgs e)
    {
      this.setIndividualWeightEntry();
      this.getIndividualWeight();
    }

    private void cbHistoryReminderPrompt_CheckedChanged(object sender, EventArgs e) => this.setHistoryReminderPrompt();

    private void cbBankRenewalReminder_CheckedChanged(object sender, EventArgs e) => this.setBankRenewalReminder();

    private void cbBankPledgeToBeReleasedtoday_CheckedChanged(object sender, EventArgs e) => this.setBankPledgeToBeReleasedToday();

    private void tbxValueAutoAdjust_TextChanged(object sender, EventArgs e) => this.setAutoAdjustValueTo();

    private void cbPendingGirvi_CheckedChanged(object sender, EventArgs e) => this.setPendingGirviTotalPrompt();

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
      this.setDefaultPrintFormat1();
      this.setDefaultPrintFormat2();
      this.setDefaultPrintFormat1CustomerCopy();
      this.setDefaultPrintFormat2CustomerCopy();
      this.setOFFICEandcustomercopyprintornot();
    }

    private void setOFFICEandcustomercopyprintornot()
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("update tblsettings set printofficeCopy = @printofficeCopy", new List<OleDbParameter>()
      {
        new OleDbParameter("printofficeCopy", (object) this.cbPrintOfficeCopy.Text)
      }, ref strError1) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError1, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      string strError2 = "";
      if (SQLHelper.RunCommand("update tblsettings set printCustomerCopy = @printCustomerCopy", new List<OleDbParameter>()
      {
        new OleDbParameter("printCustomerCopy", (object) this.cbPrintCustomerCopy.Text)
      }, ref strError2) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError2, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      FormMain.strPrintOfficeCopy = this.cbPrintOfficeCopy.Text;
      FormMain.strPrintCustomerCopy = this.cbPrintCustomerCopy.Text;
    }

    private void btnRedemptionBillSettings_Click(object sender, EventArgs e)
    {
      this.setRedemptionBillPrintPrompt();
      this.setRedemptionBillDefaultPrintFormat();
      this.setRedemptionBillDefaultPrintFormat2();
    }

    private void cbAutoFillAmount_CheckedChanged(object sender, EventArgs e) => this.setAutoFillAmount();

    private void setAutoFillAmount()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update TBLPRINTSETTINGS set AutoFillAmount= @AutoFillAmount", new List<OleDbParameter>()
      {
        new OleDbParameter("AutoFillAmount", this.cbAutoFillAmount.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.individualWeightEntry", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void glassButton19_Click_1(object sender, EventArgs e)
    {
      this.getPledgeReportTypes();
      this.getPrintSettings();
    }

    private void getPledgeReportTypes()
    {
      string[] files = Directory.GetFiles("Reports\\\\PledgeBill\\\\", "*.rpt");
      for (int index = 0; index < files.Length; ++index)
        files[index] = files[index].Substring(files[index].IndexOf("ReportPledge"));
      this.deltePrintFormats();
      foreach (string strPrintFormat in files)
        this.insertIntoPrintFormats(strPrintFormat);
    }

    private void getRedemptionReportTypes()
    {
      string[] files = Directory.GetFiles("Reports\\\\RedemptionBill\\\\", "*.rpt");
      for (int index = 0; index < files.Length; ++index)
        files[index] = files[index].Substring(files[index].IndexOf("ReportRedemption"));
      this.deleteRedemptionPrintFormats();
      foreach (string strPrintFormat in files)
        this.insertIntoRedemptionPrintFormats(strPrintFormat);
    }

    public void deltePrintFormats()
    {
      string strError = "";
      SQLHelper.RunCommand("Delete from tblPledgePrintSettings", new List<OleDbParameter>(), ref strError);
    }

    public void deleteRedemptionPrintFormats()
    {
      string strError = "";
      SQLHelper.RunCommand("Delete from tblRedemptionPrintSettings", new List<OleDbParameter>(), ref strError);
    }

    private void insertIntoPrintFormats(string strPrintFormat)
    {
      string strError = "";
      SQLHelper.RunCommand("insert into tblPledgePrintSettings(PrintFormats) values (@PrintFormats)", new List<OleDbParameter>()
      {
        new OleDbParameter("PrintFormats", (object) strPrintFormat)
      }, ref strError);
    }

    private void insertIntoRedemptionPrintFormats(string strPrintFormat)
    {
      string strError = "";
      SQLHelper.RunCommand("insert into tblRedemptionPrintSettings(RedemptionBillPrintFormats) values (@RedemptionBillPrintFormats)", new List<OleDbParameter>()
      {
        new OleDbParameter("RedemptionBillPrintFormats", (object) strPrintFormat)
      }, ref strError);
    }

    private void glassButton22_Click_1(object sender, EventArgs e)
    {
      this.getRedemptionReportTypes();
      this.getRedemptionBillPrintSettings();
    }

    private void MaintainOldestBillNumber()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set MaintainOldestBillNumber = @MaintainOldestBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (MaintainOldestBillNumber), this.cbMaintainOldestBillNumber.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form billnumberseriessettings.setbillnumberseries()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void ReduceFirstMonthInterest()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set ReduceFirstMonthInterest= @ReduceFirstMonthInterest", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ReduceFirstMonthInterest), this.cbReduceFirstMonthInterest.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form billnumberseriessettings.setbillnumberseries()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void ViewPledgeAndRedemptionInSide()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set ViewPledgeAndRedemptionInSide= @ViewPledgeAndRedemptionInSide", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ViewPledgeAndRedemptionInSide), this.cbViewPledgeAndRedemptionInSide.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form billnumberseriessettings.setbillnumberseries()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void cbMaintainOldestBillNumber_CheckedChanged(object sender, EventArgs e) => this.MaintainOldestBillNumber();

    public static bool boolMaintainOldestBillNumber()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MaintainOldestBillNumber"] != null && dataTable2.Rows[0]["MaintainOldestBillNumber"].ToString() == "Y")
        return true;
      return false;
    }

    public static bool boolReduceFirstMonthInterest()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["ReduceFirstMonthInterest"] != null && dataTable2.Rows[0]["ReduceFirstMonthInterest"].ToString() == "Y")
        return true;
      return false;
    }

    public static bool boolPledgeScreenSimple()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["PledgeScreenSimple"] != null && dataTable2.Rows[0]["PledgeScreenSimple"].ToString() == "Y")
        return true;
      return false;
    }

    public static bool boolGetMainFormFullScreen()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["MainFormFullScreen"] != null && dataTable2.Rows[0]["MainFormFullScreen"].ToString() == "Y")
        return true;
      return false;
    }

    private void cbReduceFirstMonthInterest_CheckedChanged(object sender, EventArgs e) => this.ReduceFirstMonthInterest();

    private void cbFingerPrint_CheckedChanged(object sender, EventArgs e) => this.setFingerPrintSetting();

    private void cbAutoOnFingerPrint_CheckedChanged(object sender, EventArgs e) => this.setAutoFingerPrintOn();

    private void cbMainFormFullScreen_CheckedChanged(object sender, EventArgs e) => this.setMainFormFullScreen();

    private void cbPledgeScreenSimple_CheckedChanged(object sender, EventArgs e) => this.setPledgeScreenSimple();

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.setAddEditCustomerSetting();
      FormMain.addEditCustomerSetting = this.comboBox1.Text;
    }

    private void cbIncludeNoticeChargeInRedemptionScreen_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbIncludeNoticeChargeInRedemptionScreen.Checked)
        this.tbxIncludeNoticeChargeInRedemptionScreen.Enabled = true;
      else
        this.tbxIncludeNoticeChargeInRedemptionScreen.Enabled = false;
      this.setIncludeNoticeCharge();
    }

    private void cbIncludeNoticeChargeInPledgeScreen_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbIncludeNoticeChargeInPledgeScreen.Checked)
        this.tbxIncludeNoticeChargeInPledgeScreen.Enabled = true;
      else
        this.tbxIncludeNoticeChargeInPledgeScreen.Enabled = false;
      this.setIncludeNoticeCharge();
    }

    private void setIncludeNoticeCharge()
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("update tblsettings set IncludeNoticeChargeInRedemptionScreen = @IncludeNoticeChargeInRedemptionScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("IncludeNoticeChargeInRedemptionScreen", this.cbIncludeNoticeChargeInRedemptionScreen.Checked ? (object) "Y" : (object) "N")
      }, ref strError1) != "Done")
      {
        PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError1, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
      }
      string strError2 = "";
      if (!(SQLHelper.RunCommand("update tblsettings set IncludeNoticeChargeInPledgeScreen = @IncludeNoticeChargeInPledgeScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("IncludeNoticeChargeInPledgeScreen", this.cbIncludeNoticeChargeInPledgeScreen.Checked ? (object) "Y" : (object) "N")
      }, ref strError2) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setFingerPrintSEttings", strError2, FormMain.username, DateTime.Now.ToString());
      int num1 = (int) MessageBox.Show("form printsettings.setFingerprintsettings");
    }

    private void tbxIncludeNoticeChargeInRedemptionScreen_TextChanged(object sender, EventArgs e)
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("update  tblSettings set NoticeChargeInPledgeScreen= @VNoticeChargeInPledgeScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("NoticeChargeInPledgeScreen", (object) this.tbxIncludeNoticeChargeInPledgeScreen.Text)
      }, ref strError1) != "Done")
        PawnManagementClass.InsertIntoException("form printsettings.setAutoAdjustValueTo()", strError1, FormMain.username, DateTime.Now.ToString());
      string strError2 = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set NoticeChargeInRedemptionScreen= @VNoticeChargeInRedemptionScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("NoticeChargeInRedemptionScreen", (object) this.tbxIncludeNoticeChargeInRedemptionScreen.Text)
      }, ref strError2) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form printsettings.setAutoAdjustValueTo()", strError2, FormMain.username, DateTime.Now.ToString());
    }

    private void cbViewPledgeAndRedemptionInSide_CheckedChanged(object sender, EventArgs e) => this.ViewPledgeAndRedemptionInSide();

    private void checkBox1_CheckedChanged(object sender, EventArgs e) => this.setPledgeWithoutBackgroundWorker();

    private void cbQuickRelease_CheckedChanged(object sender, EventArgs e) => this.setQuickRelease();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.cbOfficeCopy = new ComboBox();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.headerPanel4 = new HeaderPanel();
      this.cbPrintCustomerCopy = new ComboBox();
      this.label7 = new Label();
      this.cbPrintOfficeCopy = new ComboBox();
      this.label6 = new Label();
      this.glassButton19 = new GlassButton();
      this.label4 = new Label();
      this.label1 = new Label();
      this.cbCustomerCopy = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.cbEnterIndividualWeight = new CheckBox();
      this.cbHistoryReminderPrompt = new CheckBox();
      this.cbBankRenewalReminder = new CheckBox();
      this.cbBankPledgeToBeReleasedtoday = new CheckBox();
      this.label2 = new Label();
      this.tbxValueAutoAdjust = new TextBox();
      this.cbPendingGirvi = new CheckBox();
      this.customPanel1 = new CustomPanel();
      this.cbPledgeWithoutBackgroundWorker = new CheckBox();
      this.label8 = new Label();
      this.comboBox1 = new ComboBox();
      this.cbViewPledgeAndRedemptionInSide = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.cbIncludeNoticeChargeInPledgeScreen = new CheckBox();
      this.cbPledgeScreenSimple = new CheckBox();
      this.tbxIncludeNoticeChargeInPledgeScreen = new TextBox();
      this.cbMainFormFullScreen = new CheckBox();
      this.cbIncludeNoticeChargeInRedemptionScreen = new CheckBox();
      this.cbAutoOnFingerPrint = new CheckBox();
      this.tbxIncludeNoticeChargeInRedemptionScreen = new TextBox();
      this.cbReduceFirstMonthInterest = new CheckBox();
      this.cbFingerPrint = new CheckBox();
      this.cbMaintainOldestBillNumber = new CheckBox();
      this.cbAutoFillAmount = new CheckBox();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton22 = new GlassButton();
      this.label5 = new Label();
      this.cbRedemptionBillFormats = new ComboBox();
      this.btnRedemptionBillSettings = new GlassButton();
      this.cbRedemptionBillPrintPrompt = new CheckBox();
      this.glassButton3 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.cbQuickRelease = new CheckBox();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.customPanel1).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      this.SuspendLayout();
      this.cbOfficeCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbOfficeCopy.DropDownWidth = 800;
      this.cbOfficeCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbOfficeCopy.FormattingEnabled = true;
      this.cbOfficeCopy.Location = new Point(93, 6);
      this.cbOfficeCopy.Name = "cbOfficeCopy";
      this.cbOfficeCopy.Size = new Size(884, 28);
      this.cbOfficeCopy.TabIndex = 0;
      this.checkBox2.AutoSize = true;
      this.checkBox2.BackColor = Color.Transparent;
      this.checkBox2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox2.Location = new Point(20, 471);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(226, 21);
      this.checkBox2.TabIndex = 20;
      this.checkBox2.Text = "Prompt for taking jewel photo??";
      this.checkBox2.UseVisualStyleBackColor = false;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.BackColor = Color.Transparent;
      this.checkBox3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox3.Location = new Point(20, 444);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(154, 21);
      this.checkBox3.TabIndex = 20;
      this.checkBox3.Text = "Auto Entry Rokad??";
      this.checkBox3.UseVisualStyleBackColor = false;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel4.CaptionEndColor = Color.AliceBlue;
      this.headerPanel4.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "PLEDGE BIL PRINT SETTINGS";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbPrintCustomerCopy);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbPrintOfficeCopy);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbCustomerCopy);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbOfficeCopy);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(8, 4);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(988, 156);
      ((Control) this.headerPanel4).TabIndex = 76;
      this.headerPanel4.TextAntialias = true;
      this.cbPrintCustomerCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrintCustomerCopy.DropDownWidth = 800;
      this.cbPrintCustomerCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrintCustomerCopy.FormattingEnabled = true;
      this.cbPrintCustomerCopy.Items.AddRange(new object[3]
      {
        (object) "YES AFTER ASKING",
        (object) "YES WITHOUT ASKING",
        (object) "NO"
      });
      this.cbPrintCustomerCopy.Location = new Point(257, 101);
      this.cbPrintCustomerCopy.Name = "cbPrintCustomerCopy";
      this.cbPrintCustomerCopy.Size = new Size(511, 28);
      this.cbPrintCustomerCopy.TabIndex = 29;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 12f);
      this.label7.Location = new Point(15, 108);
      this.label7.Name = "label7";
      this.label7.Size = new Size(221, 20);
      this.label7.TabIndex = 28;
      this.label7.Text = "PRINT CUSTOMER COPY ??";
      this.cbPrintOfficeCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrintOfficeCopy.DropDownWidth = 800;
      this.cbPrintOfficeCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrintOfficeCopy.FormattingEnabled = true;
      this.cbPrintOfficeCopy.Items.AddRange(new object[3]
      {
        (object) "YES AFTER ASKING",
        (object) "YES WITHOUT ASKING",
        (object) "NO"
      });
      this.cbPrintOfficeCopy.Location = new Point(257, 70);
      this.cbPrintOfficeCopy.Name = "cbPrintOfficeCopy";
      this.cbPrintOfficeCopy.Size = new Size(511, 28);
      this.cbPrintOfficeCopy.TabIndex = 27;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 12f);
      this.label6.Location = new Point(15, 75);
      this.label6.Name = "label6";
      this.label6.Size = new Size(189, 20);
      this.label6.TabIndex = 25;
      this.label6.Text = "PRINT OFFICE COPY ??";
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(799, 86);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(76, 26);
      ((Control) this.glassButton19).TabIndex = 24;
      ((Control) this.glassButton19).Text = "REFRESH";
      ((Control) this.glassButton19).Click += new EventHandler(this.glassButton19_Click_1);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 12f);
      this.label4.Location = new Point(10, 42);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 20);
      this.label4.TabIndex = 23;
      this.label4.Text = "Cust copy";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f);
      this.label1.Location = new Point(2, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(88, 20);
      this.label1.TabIndex = 22;
      this.label1.Text = "Office copy";
      this.cbCustomerCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbCustomerCopy.DropDownWidth = 800;
      this.cbCustomerCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCustomerCopy.FormattingEnabled = true;
      this.cbCustomerCopy.Location = new Point(93, 38);
      this.cbCustomerCopy.Name = "cbCustomerCopy";
      this.cbCustomerCopy.Size = new Size(884, 28);
      this.cbCustomerCopy.TabIndex = 21;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(892, 87);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(76, 26);
      ((Control) this.glassButton1).TabIndex = 20;
      ((Control) this.glassButton1).Text = "SAVE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click_1);
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      ((ButtonBase) this.glassButton6).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(689, 513);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(128, 35);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&SAVE";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(823, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbEnterIndividualWeight.AutoSize = true;
      this.cbEnterIndividualWeight.BackColor = Color.Transparent;
      this.cbEnterIndividualWeight.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbEnterIndividualWeight.Location = new Point(20, 309);
      this.cbEnterIndividualWeight.Name = "cbEnterIndividualWeight";
      this.cbEnterIndividualWeight.Size = new Size(243, 21);
      this.cbEnterIndividualWeight.TabIndex = 20;
      this.cbEnterIndividualWeight.Text = "Enter Individual Weight for Articles";
      this.cbEnterIndividualWeight.UseVisualStyleBackColor = false;
      this.cbEnterIndividualWeight.CheckedChanged += new EventHandler(this.cbEnterIndividualWeight_CheckedChanged);
      this.cbHistoryReminderPrompt.AutoSize = true;
      this.cbHistoryReminderPrompt.BackColor = Color.Transparent;
      this.cbHistoryReminderPrompt.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbHistoryReminderPrompt.Location = new Point(20, 336);
      this.cbHistoryReminderPrompt.Name = "cbHistoryReminderPrompt";
      this.cbHistoryReminderPrompt.Size = new Size(176, 21);
      this.cbHistoryReminderPrompt.TabIndex = 20;
      this.cbHistoryReminderPrompt.Text = "Remind while logging??";
      this.cbHistoryReminderPrompt.UseVisualStyleBackColor = false;
      this.cbHistoryReminderPrompt.CheckedChanged += new EventHandler(this.cbHistoryReminderPrompt_CheckedChanged);
      this.cbBankRenewalReminder.AutoSize = true;
      this.cbBankRenewalReminder.BackColor = Color.Transparent;
      this.cbBankRenewalReminder.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbBankRenewalReminder.Location = new Point(20, 363);
      this.cbBankRenewalReminder.Name = "cbBankRenewalReminder";
      this.cbBankRenewalReminder.Size = new Size(180, 21);
      this.cbBankRenewalReminder.TabIndex = 20;
      this.cbBankRenewalReminder.Text = "Remind  while logging??";
      this.cbBankRenewalReminder.UseVisualStyleBackColor = false;
      this.cbBankRenewalReminder.CheckedChanged += new EventHandler(this.cbBankRenewalReminder_CheckedChanged);
      this.cbBankPledgeToBeReleasedtoday.AutoSize = true;
      this.cbBankPledgeToBeReleasedtoday.BackColor = Color.Transparent;
      this.cbBankPledgeToBeReleasedtoday.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbBankPledgeToBeReleasedtoday.Location = new Point(20, 390);
      this.cbBankPledgeToBeReleasedtoday.Name = "cbBankPledgeToBeReleasedtoday";
      this.cbBankPledgeToBeReleasedtoday.Size = new Size(180, 21);
      this.cbBankPledgeToBeReleasedtoday.TabIndex = 20;
      this.cbBankPledgeToBeReleasedtoday.Text = "Remind  while logging??";
      this.cbBankPledgeToBeReleasedtoday.UseVisualStyleBackColor = false;
      this.cbBankPledgeToBeReleasedtoday.CheckedChanged += new EventHandler(this.cbBankPledgeToBeReleasedtoday_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 12f);
      this.label2.Location = new Point(614, 340);
      this.label2.Name = "label2";
      this.label2.Size = new Size(183, 20);
      this.label2.TabIndex = 4;
      this.label2.Text = "Auto Adjust Value to (%)";
      this.tbxValueAutoAdjust.Location = new Point(793, 340);
      this.tbxValueAutoAdjust.Name = "tbxValueAutoAdjust";
      this.tbxValueAutoAdjust.Size = new Size(45, 20);
      this.tbxValueAutoAdjust.TabIndex = 3;
      this.tbxValueAutoAdjust.TextChanged += new EventHandler(this.tbxValueAutoAdjust_TextChanged);
      this.tbxValueAutoAdjust.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.cbPendingGirvi.AutoSize = true;
      this.cbPendingGirvi.BackColor = Color.Transparent;
      this.cbPendingGirvi.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPendingGirvi.Location = new Point(20, 283);
      this.cbPendingGirvi.Name = "cbPendingGirvi";
      this.cbPendingGirvi.Size = new Size(231, 20);
      this.cbPendingGirvi.TabIndex = 20;
      this.cbPendingGirvi.Text = "Show Pending Girvi while logging?";
      this.cbPendingGirvi.UseVisualStyleBackColor = false;
      this.cbPendingGirvi.CheckedChanged += new EventHandler(this.cbPendingGirvi_CheckedChanged);
      this.customPanel1.BackColor = Color.Honeydew;
      this.customPanel1.BackColor2 = Color.PaleTurquoise;
      this.customPanel1.BorderColor = SystemColors.MenuHighlight;
      ((Control) this.customPanel1).Controls.Add((Control) this.cbQuickRelease);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbPledgeWithoutBackgroundWorker);
      ((Control) this.customPanel1).Controls.Add((Control) this.label8);
      ((Control) this.customPanel1).Controls.Add((Control) this.comboBox1);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbViewPledgeAndRedemptionInSide);
      ((Control) this.customPanel1).Controls.Add((Control) this.checkBox4);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbIncludeNoticeChargeInPledgeScreen);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbPledgeScreenSimple);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxIncludeNoticeChargeInPledgeScreen);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbMainFormFullScreen);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbIncludeNoticeChargeInRedemptionScreen);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbAutoOnFingerPrint);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxIncludeNoticeChargeInRedemptionScreen);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbReduceFirstMonthInterest);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbFingerPrint);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbMaintainOldestBillNumber);
      ((Control) this.customPanel1).Controls.Add((Control) this.checkBox2);
      ((Control) this.customPanel1).Controls.Add((Control) this.checkBox3);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbAutoFillAmount);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbPendingGirvi);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbEnterIndividualWeight);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbHistoryReminderPrompt);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbBankRenewalReminder);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbBankPledgeToBeReleasedtoday);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxValueAutoAdjust);
      ((Control) this.customPanel1).Controls.Add((Control) this.label2);
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel11);
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel4);
      ((Control) this.customPanel1).Dock = DockStyle.Fill;
      this.customPanel1.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(0, 0);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(1008, 622);
      ((Control) this.customPanel1).TabIndex = 84;
      this.cbPledgeWithoutBackgroundWorker.AutoSize = true;
      this.cbPledgeWithoutBackgroundWorker.BackColor = Color.Transparent;
      this.cbPledgeWithoutBackgroundWorker.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPledgeWithoutBackgroundWorker.Location = new Point(305, 395);
      this.cbPledgeWithoutBackgroundWorker.Name = "cbPledgeWithoutBackgroundWorker";
      this.cbPledgeWithoutBackgroundWorker.Size = new Size(244, 21);
      this.cbPledgeWithoutBackgroundWorker.TabIndex = 93;
      this.cbPledgeWithoutBackgroundWorker.Text = "Pledge without background worker";
      this.cbPledgeWithoutBackgroundWorker.UseVisualStyleBackColor = false;
      this.cbPledgeWithoutBackgroundWorker.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 12f);
      this.label8.Location = new Point(610, 374);
      this.label8.Name = "label8";
      this.label8.Size = new Size(225, 20);
      this.label8.TabIndex = 92;
      this.label8.Text = "ADD/EDIT CUSTOMER TYPE";
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.DropDownWidth = 800;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "SIMPLE",
        (object) "ADVANCED"
      });
      this.comboBox1.Location = new Point(614, 400);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(221, 28);
      this.comboBox1.TabIndex = 21;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.cbViewPledgeAndRedemptionInSide.AutoSize = true;
      this.cbViewPledgeAndRedemptionInSide.BackColor = Color.Transparent;
      this.cbViewPledgeAndRedemptionInSide.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbViewPledgeAndRedemptionInSide.Location = new Point(20, 552);
      this.cbViewPledgeAndRedemptionInSide.Name = "cbViewPledgeAndRedemptionInSide";
      this.cbViewPledgeAndRedemptionInSide.Size = new Size(267, 21);
      this.cbViewPledgeAndRedemptionInSide.TabIndex = 20;
      this.cbViewPledgeAndRedemptionInSide.Text = "View Pledge and Redemption in Side?";
      this.cbViewPledgeAndRedemptionInSide.UseVisualStyleBackColor = false;
      this.cbViewPledgeAndRedemptionInSide.CheckedChanged += new EventHandler(this.cbViewPledgeAndRedemptionInSide_CheckedChanged);
      this.checkBox4.AutoSize = true;
      this.checkBox4.BackColor = Color.Transparent;
      this.checkBox4.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox4.Location = new Point(20, 579);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(225, 21);
      this.checkBox4.TabIndex = 20;
      this.checkBox4.Text = "Open software In Full Screen??";
      this.checkBox4.UseVisualStyleBackColor = false;
      this.cbIncludeNoticeChargeInPledgeScreen.AutoSize = true;
      this.cbIncludeNoticeChargeInPledgeScreen.BackColor = Color.Transparent;
      this.cbIncludeNoticeChargeInPledgeScreen.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbIncludeNoticeChargeInPledgeScreen.Location = new Point(618, 312);
      this.cbIncludeNoticeChargeInPledgeScreen.Name = "cbIncludeNoticeChargeInPledgeScreen";
      this.cbIncludeNoticeChargeInPledgeScreen.Size = new Size(170, 21);
      this.cbIncludeNoticeChargeInPledgeScreen.TabIndex = 23;
      this.cbIncludeNoticeChargeInPledgeScreen.Text = "Include notice charge?";
      this.cbIncludeNoticeChargeInPledgeScreen.UseVisualStyleBackColor = false;
      this.cbIncludeNoticeChargeInPledgeScreen.CheckedChanged += new EventHandler(this.cbIncludeNoticeChargeInPledgeScreen_CheckedChanged);
      this.cbPledgeScreenSimple.AutoSize = true;
      this.cbPledgeScreenSimple.BackColor = Color.Transparent;
      this.cbPledgeScreenSimple.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPledgeScreenSimple.Location = new Point(305, 368);
      this.cbPledgeScreenSimple.Name = "cbPledgeScreenSimple";
      this.cbPledgeScreenSimple.Size = new Size(260, 21);
      this.cbPledgeScreenSimple.TabIndex = 20;
      this.cbPledgeScreenSimple.Text = "Pledge screen search option simple?";
      this.cbPledgeScreenSimple.UseVisualStyleBackColor = false;
      this.cbPledgeScreenSimple.CheckedChanged += new EventHandler(this.cbPledgeScreenSimple_CheckedChanged);
      this.tbxIncludeNoticeChargeInPledgeScreen.Location = new Point(792, 311);
      this.tbxIncludeNoticeChargeInPledgeScreen.Name = "tbxIncludeNoticeChargeInPledgeScreen";
      this.tbxIncludeNoticeChargeInPledgeScreen.Size = new Size(46, 20);
      this.tbxIncludeNoticeChargeInPledgeScreen.TabIndex = 22;
      this.tbxIncludeNoticeChargeInPledgeScreen.TextChanged += new EventHandler(this.tbxIncludeNoticeChargeInRedemptionScreen_TextChanged);
      this.tbxIncludeNoticeChargeInPledgeScreen.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.cbMainFormFullScreen.AutoSize = true;
      this.cbMainFormFullScreen.BackColor = Color.Transparent;
      this.cbMainFormFullScreen.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMainFormFullScreen.Location = new Point(305, 340);
      this.cbMainFormFullScreen.Name = "cbMainFormFullScreen";
      this.cbMainFormFullScreen.Size = new Size(225, 21);
      this.cbMainFormFullScreen.TabIndex = 20;
      this.cbMainFormFullScreen.Text = "Open software In Full Screen??";
      this.cbMainFormFullScreen.UseVisualStyleBackColor = false;
      this.cbMainFormFullScreen.CheckedChanged += new EventHandler(this.cbMainFormFullScreen_CheckedChanged);
      this.cbIncludeNoticeChargeInRedemptionScreen.AutoSize = true;
      this.cbIncludeNoticeChargeInRedemptionScreen.BackColor = Color.Transparent;
      this.cbIncludeNoticeChargeInRedemptionScreen.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbIncludeNoticeChargeInRedemptionScreen.Location = new Point(618, 284);
      this.cbIncludeNoticeChargeInRedemptionScreen.Name = "cbIncludeNoticeChargeInRedemptionScreen";
      this.cbIncludeNoticeChargeInRedemptionScreen.Size = new Size(170, 21);
      this.cbIncludeNoticeChargeInRedemptionScreen.TabIndex = 21;
      this.cbIncludeNoticeChargeInRedemptionScreen.Text = "Include notice charge?";
      this.cbIncludeNoticeChargeInRedemptionScreen.UseVisualStyleBackColor = false;
      this.cbIncludeNoticeChargeInRedemptionScreen.CheckedChanged += new EventHandler(this.cbIncludeNoticeChargeInRedemptionScreen_CheckedChanged);
      this.cbAutoOnFingerPrint.AutoSize = true;
      this.cbAutoOnFingerPrint.BackColor = Color.Transparent;
      this.cbAutoOnFingerPrint.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbAutoOnFingerPrint.Location = new Point(305, 284);
      this.cbAutoOnFingerPrint.Name = "cbAutoOnFingerPrint";
      this.cbAutoOnFingerPrint.Size = new Size(228, 21);
      this.cbAutoOnFingerPrint.TabIndex = 20;
      this.cbAutoOnFingerPrint.Text = "Automatically Read Fingerprint?";
      this.cbAutoOnFingerPrint.UseVisualStyleBackColor = false;
      this.cbAutoOnFingerPrint.CheckedChanged += new EventHandler(this.cbAutoOnFingerPrint_CheckedChanged);
      this.tbxIncludeNoticeChargeInRedemptionScreen.Location = new Point(793, 286);
      this.tbxIncludeNoticeChargeInRedemptionScreen.Name = "tbxIncludeNoticeChargeInRedemptionScreen";
      this.tbxIncludeNoticeChargeInRedemptionScreen.Size = new Size(46, 20);
      this.tbxIncludeNoticeChargeInRedemptionScreen.TabIndex = 5;
      this.tbxIncludeNoticeChargeInRedemptionScreen.TextChanged += new EventHandler(this.tbxIncludeNoticeChargeInRedemptionScreen_TextChanged);
      this.tbxIncludeNoticeChargeInRedemptionScreen.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.cbReduceFirstMonthInterest.AutoSize = true;
      this.cbReduceFirstMonthInterest.BackColor = Color.Transparent;
      this.cbReduceFirstMonthInterest.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbReduceFirstMonthInterest.Location = new Point(20, 525);
      this.cbReduceFirstMonthInterest.Name = "cbReduceFirstMonthInterest";
      this.cbReduceFirstMonthInterest.Size = new Size(209, 21);
      this.cbReduceFirstMonthInterest.TabIndex = 20;
      this.cbReduceFirstMonthInterest.Text = "Reduce First Month Interest?";
      this.cbReduceFirstMonthInterest.UseVisualStyleBackColor = false;
      this.cbReduceFirstMonthInterest.CheckedChanged += new EventHandler(this.cbReduceFirstMonthInterest_CheckedChanged);
      this.cbFingerPrint.AutoSize = true;
      this.cbFingerPrint.BackColor = Color.Transparent;
      this.cbFingerPrint.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbFingerPrint.Location = new Point(305, 312);
      this.cbFingerPrint.Name = "cbFingerPrint";
      this.cbFingerPrint.Size = new Size(229, 21);
      this.cbFingerPrint.TabIndex = 20;
      this.cbFingerPrint.Text = "Do you want to use FingerPrint?";
      this.cbFingerPrint.UseVisualStyleBackColor = false;
      this.cbFingerPrint.CheckedChanged += new EventHandler(this.cbFingerPrint_CheckedChanged);
      this.cbMaintainOldestBillNumber.AutoSize = true;
      this.cbMaintainOldestBillNumber.BackColor = Color.Transparent;
      this.cbMaintainOldestBillNumber.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMaintainOldestBillNumber.Location = new Point(20, 498);
      this.cbMaintainOldestBillNumber.Name = "cbMaintainOldestBillNumber";
      this.cbMaintainOldestBillNumber.Size = new Size(209, 21);
      this.cbMaintainOldestBillNumber.TabIndex = 20;
      this.cbMaintainOldestBillNumber.Text = "Maintain Oldest Bill Number?";
      this.cbMaintainOldestBillNumber.UseVisualStyleBackColor = false;
      this.cbMaintainOldestBillNumber.CheckedChanged += new EventHandler(this.cbMaintainOldestBillNumber_CheckedChanged);
      this.cbAutoFillAmount.AutoSize = true;
      this.cbAutoFillAmount.BackColor = Color.Transparent;
      this.cbAutoFillAmount.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbAutoFillAmount.Location = new Point(20, 417);
      this.cbAutoFillAmount.Name = "cbAutoFillAmount";
      this.cbAutoFillAmount.Size = new Size(145, 21);
      this.cbAutoFillAmount.TabIndex = 20;
      this.cbAutoFillAmount.Text = "Auto Fill Amount??";
      this.cbAutoFillAmount.UseVisualStyleBackColor = false;
      this.cbAutoFillAmount.CheckedChanged += new EventHandler(this.cbAutoFillAmount_CheckedChanged);
      ((Control) this.headerPanel11).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel11).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.HotTrack;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel11.CaptionEndColor = Color.AliceBlue;
      this.headerPanel11.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "REDEMPTION BIL PRINT SETTINGS";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton22);
      ((Control) this.headerPanel11).Controls.Add((Control) this.label5);
      ((Control) this.headerPanel11).Controls.Add((Control) this.cbRedemptionBillFormats);
      ((Control) this.headerPanel11).Controls.Add((Control) this.btnRedemptionBillSettings);
      ((Control) this.headerPanel11).Controls.Add((Control) this.cbRedemptionBillPrintPrompt);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = SystemColors.ControlLight;
      this.headerPanel11.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).Location = new Point(8, 166);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(988, 109);
      ((Control) this.headerPanel11).TabIndex = 77;
      this.headerPanel11.TextAntialias = true;
      this.glassButton22.BackColor = Color.LightBlue;
      this.glassButton22.FadeOnFocus = true;
      this.glassButton22.ForeColor = Color.MediumBlue;
      this.glassButton22.ForeColorOnFocus = Color.Red;
      this.glassButton22.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton22.GlowColor = Color.White;
      this.glassButton22.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton22).Location = new Point(804, 50);
      ((Control) this.glassButton22).Name = "glassButton22";
      this.glassButton22.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton22.ShineColor = Color.Transparent;
      ((Control) this.glassButton22).Size = new Size(76, 26);
      ((Control) this.glassButton22).TabIndex = 25;
      ((Control) this.glassButton22).Text = "REFRESH";
      ((Control) this.glassButton22).Click += new EventHandler(this.glassButton22_Click_1);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 12f);
      this.label5.Location = new Point(22, 12);
      this.label5.Name = "label5";
      this.label5.Size = new Size(60, 20);
      this.label5.TabIndex = 23;
      this.label5.Text = "Format";
      this.cbRedemptionBillFormats.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRedemptionBillFormats.DropDownWidth = 800;
      this.cbRedemptionBillFormats.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRedemptionBillFormats.FormattingEnabled = true;
      this.cbRedemptionBillFormats.Location = new Point(91, 9);
      this.cbRedemptionBillFormats.Name = "cbRedemptionBillFormats";
      this.cbRedemptionBillFormats.Size = new Size(868, 28);
      this.cbRedemptionBillFormats.TabIndex = 21;
      this.btnRedemptionBillSettings.BackColor = Color.LightBlue;
      this.btnRedemptionBillSettings.FadeOnFocus = true;
      this.btnRedemptionBillSettings.ForeColor = Color.MediumBlue;
      this.btnRedemptionBillSettings.ForeColorOnFocus = Color.Red;
      this.btnRedemptionBillSettings.ForeColorOnLeave = Color.RoyalBlue;
      this.btnRedemptionBillSettings.GlowColor = Color.White;
      this.btnRedemptionBillSettings.InnerBorderColor = Color.Transparent;
      ((Control) this.btnRedemptionBillSettings).Location = new Point(880, 50);
      ((Control) this.btnRedemptionBillSettings).Name = "btnRedemptionBillSettings";
      this.btnRedemptionBillSettings.OuterBorderColor = Color.MediumSlateBlue;
      this.btnRedemptionBillSettings.ShineColor = Color.Transparent;
      ((Control) this.btnRedemptionBillSettings).Size = new Size(76, 26);
      ((Control) this.btnRedemptionBillSettings).TabIndex = 20;
      ((Control) this.btnRedemptionBillSettings).Text = "SAVE";
      ((Control) this.btnRedemptionBillSettings).Click += new EventHandler(this.btnRedemptionBillSettings_Click);
      this.cbRedemptionBillPrintPrompt.AutoSize = true;
      this.cbRedemptionBillPrintPrompt.BackColor = Color.Transparent;
      this.cbRedemptionBillPrintPrompt.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRedemptionBillPrintPrompt.Location = new Point(705, 47);
      this.cbRedemptionBillPrintPrompt.Name = "cbRedemptionBillPrintPrompt";
      this.cbRedemptionBillPrintPrompt.Size = new Size(99, 29);
      this.cbRedemptionBillPrintPrompt.TabIndex = 19;
      this.cbRedemptionBillPrintPrompt.Text = "Prompt";
      this.cbRedemptionBillPrintPrompt.UseVisualStyleBackColor = false;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      ((ButtonBase) this.glassButton3).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(687, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(821, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbQuickRelease.AutoSize = true;
      this.cbQuickRelease.BackColor = Color.Transparent;
      this.cbQuickRelease.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbQuickRelease.Location = new Point(305, 422);
      this.cbQuickRelease.Name = "cbQuickRelease";
      this.cbQuickRelease.Size = new Size((int) sbyte.MaxValue, 21);
      this.cbQuickRelease.TabIndex = 94;
      this.cbQuickRelease.Text = "Quick Release?";
      this.cbQuickRelease.UseVisualStyleBackColor = false;
      this.cbQuickRelease.CheckedChanged += new EventHandler(this.cbQuickRelease_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.customPanel1);
      this.Name = nameof (FormPrintSettings);
      this.Text = "PrintSettings";
      this.Load += new EventHandler(this.FormPrintSettings_Load);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel11).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
