
using CrystalDecisions.CrystalReports.Engine;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.JewelleryForms;
using PawnManagement.Testing;
using SecuGen.FDxSDKPro.Windows;
using SecuGen.SecuSearchSDK;
using SmsTextLcoal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using UserInactivityMonitoring;

namespace PawnManagement
{
  public class FormMain : Form
  {
    public static bool boolPledgeScreenSimple = false;
    public static bool boolShowSidePanel = false;
    private DataTable dtArticlesSettings = new DataTable();
    public static string PledgeExpiringTodayScreen = "Articles";
    public static string PledgeExpriringThisMonthScreen = "Articles";
    public static string ViewCustomersScreen = "Articles";
    public static string RemoveDuplicateCustomerScreen = "Articles";
    public static string PledgeScreen = "Articles";
    public static string PledgeReportsScreen = "Articles";
    public static string LedgerScreen = "Articles";
    public static string PledgeInLossScreen = "Articles";
    public static string NoticeScreen = "Articles";
    public static string RedemptionReportsScreen = "Articles";
    public static string AuctionReportsScreen = "Articles";
    public static string BankInsideOutsideScreen = "Articles";
    public static SecuSearch m_SecuSearch;
    public static int MAX_NUM_CAND_LIST = 30;
    public static int DEFAULT_NUM_CAND_LIST = 30;
    public static int SIZE_MEMORY_POOL = 50;
    public static string SECUSEARCH_LICENSE_FILE = "C:\\Program Files\\SecuGen\\SecuSearch SDK Pro\\License\\temp_license.dat";
    public static string SECUSEARCH_CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = PawnManagement.accdb;Jet OLEDB:Database Password = (&()&$#)!&";
    private SS_IDInfo idInfo;
    private byte[] minData;
    public static string SECUSEARCH_LICENSE_FILE_x64 = "C:\\Program Files (x86)\\SecuGen\\SecuSearch SDK Pro\\License\\temp_license.dat";
    public static string SECUSEARCH_CONNECTION_STRING_x64 = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = PawnManagement.accdb;Jet OLEDB:Database Password = (&()&$#)!&";
    public static int m_NumCandList;
    public static SGFingerPrintManager m_FPM;
    public static int m_ImageWidth;
    public static int m_ImageHeight;
    public static SS_EngineParam pEngineParam;
    public static bool AutoOnfingerPrint = false;
    public static bool quickRelease = false;
    public static string startUpPath = "";
    public static DataTable dtShopCodes = new DataTable();
    public static string strMenuSetting = "OFF";
    public static string strPledgeWithoutBackgroundWorker = "";
    public static List<string> lsttoRelease = new List<string>();
    public static bool withIndividualWeight = false;
    public static bool RemindIfNameAndAddressSame = false;
    public static bool RemindIfNameAddressAndDoorNumberSame = false;
    public static bool IncludeNoticeChargeInRedemptionScreen = false;
    public static bool IncludeNoticeChargeInPledgeScreen = false;
    public static string strPrintOfficeCopy = "YES AFTER ASKING";
    public static string strPrintCustomerCopy = "YES AFTER ASKING";
    public static bool UseFingerPrint = false;
    private string adminPassword = "";
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private DataTable dtReminder = new DataTable();
    private DataTable dtBankRenewalReminder = new DataTable();
    private List<string> menuitems = new List<string>();
    private List<string> menuitemsSelected = new List<string>();
    public static string username;
    public static string memberid;
    public static string memberType = "";
    public static string Language = "";
    public static string BillNumberSeries = "";
    public static DateTime licenceValidTill;
    private DataTable dtHistoryReminder = new DataTable();
    public static string HideLicense = "";
    public static string BillerName = "";
    public static string addEditCustomerSetting = "SIMPLE";
    public static string NoticeChargeInPledgeScreen = "0";
    public static string NoticeChargeInRedemptionScreen = "0";
    public static List<string> lstShopCodes = new List<string>();
    private IContainer components = (IContainer) null;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem pledgeReportsToolStripMenuItem;
    private ToolStripMenuItem redeemReportsToolStripMenuItem;
    private ToolStripMenuItem customersToolStripMenuItem;
    private ToolStripMenuItem viewCustomersToolStripMenuItem;
    private ToolStripMenuItem addCustomerToolStripMenuItem;
    private ToolStripMenuItem editCustomerToolStripMenuItem;
    private ToolStripMenuItem pledgeToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem articlesToolStripMenuItem1;
    private ToolStripMenuItem searchCustomerToolStripMenuItem;
    private ToolStripMenuItem loginDetailsToolStripMenuItem;
    private ToolStripMenuItem interestToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem oldPledgeToolStripMenuItem;
    private ToolStripMenuItem redemptionToolStripMenuItem;
    private ToolStripMenuItem gramRateToolStripMenuItem;
    private ToolStripMenuItem ledgerToolStripMenuItem;
    private ToolStripMenuItem locationAndPincodeToolStripMenuItem;
    private ToolStripMenuItem pledgeEditToolStripMenuItem;
    private ToolStripMenuItem noticeToolStripMenuItem;
    private ToolStripMenuItem printsToolStripMenuItem;
    private ToolStripMenuItem fORMD3ToolStripMenuItem;
    private ToolStripMenuItem duplicateBillToolStripMenuItem;
    private ToolStripMenuItem tOKENSToolStripMenuItem;
    private ToolStripMenuItem redemptionEditToolStripMenuItem;
    private ToolStripMenuItem formCToolStripMenuItem;
    private ToolStripMenuItem fORMDToolStripMenuItem;
    private ToolStripMenuItem bankToolStripMenuItem;
    private ToolStripMenuItem bankMasterToolStripMenuItem;
    private ToolStripMenuItem bankPledgeToolStripMenuItem;
    private ToolStrip toolStrip1;
    private ToolStripMenuItem bankReleaseToolStripMenuItem;
    private ToolStripMenuItem oldRedemptionToolStripMenuItem;
    private ToolStripMenuItem historyToolStripMenuItem;
    private ToolStripMenuItem reminderToolStripMenuItem;
    private ToolStripMenuItem menuSettingsToolStripMenuItem;
    private ToolStripMenuItem shopDetailsToolStripMenuItem;
    private ToolStripLabel tslRemiinder;
    private ToolStripMenuItem autoBackupToolStripMenuItem;
    private ToolStripMenuItem billNumberSeriesToolStripMenuItem;
    private ToolStripMenuItem exceptionsToolStripMenuItem;
    private ToolStripMenuItem historyReminderSettingsToolStripMenuItem;
    private ToolStripLabel toolStripLabel2;
    private ToolStripMenuItem jewelPhotoToolStripMenuItem1;
    private ToolStripMenuItem khaathoToolStripMenuItem;
    private ToolStripMenuItem viewKhaathoToolStripMenuItem;
    private ToolStripMenuItem bankReportsToolStripMenuItem;
    private ToolStripMenuItem outsidePledgeListToolStripMenuItem;
    private ToolStripMenuItem auctionRedemptionToolStripMenuItem;
    private ToolStripMenuItem pledgeReportsToolStripMenuItem1;
    private ToolStripMenuItem customerRemindersToolStripMenuItem;
    private ToolStripMenuItem smsToolStripMenuItem1;
    private ToolStripMenuItem smsMessagesToolStripMenuItem;
    private ToolStripMenuItem numberOfBillsToolStripMenuItem1;
    private ToolStripMenuItem numberOfBillsToolStripMenuItem2;
    private ToolStripMenuItem customersNotComingToolStripMenuItem;
    private ToolStripMenuItem CustomersStreetReport;
    private ToolStripMenuItem regularCustomersWhoAreNotComingToolStripMenuItem;
    private ToolStripMenuItem accountsToolStripMenuItem;
    private ToolStripMenuItem ledgerDetailsToolStripMenuItem;
    private ToolStripMenuItem pledgeAmountSummaryToolStripMenuItem;
    private ToolStripMenuItem voucherEntryToolStripMenuItem;
    private ToolStripMenuItem voucherMasterToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem rokadToolStripMenuItem;
    private ToolStripMenuItem changeRokadDateToolStripMenuItem;
    private ToolStripMenuItem autoDeleteRokadToolStripMenuItem;
    private ToolStripMenuItem rokadReportsToolStripMenuItem;
    private ToolStripMenuItem pledgeInLossToolStripMenuItem;
    private ToolStripMenuItem redemptionReportsToolStripMenuItem;
    private ToolStripMenuItem viewSentMessagesToolStripMenuItem;
    private ToolStripMenuItem numberOfBillsConsolidatedToolStripMenuItem;
    private ToolStripMenuItem customersInterestSummaryToolStripMenuItem;
    private ToolStripMenuItem redemptionINTERESTMonthlySummaryToolStripMenuItem;
    private ToolStripLabel toolStripLabel3;
    private ToolStripMenuItem auctionReportsToolStripMenuItem;
    private ToolStripMenuItem printSettingsToolStripMenuItem;
    private ToolStripMenuItem notepadToolStripMenuItem;
    private ToolStripMenuItem printRokadToolStripMenuItem;
    private StatusStrip statusStrip1;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripStatusLabel slblAutoDeleteRokad;
    private ToolStripStatusLabel slblAutoBackUp;
    private ToolStripStatusLabel tsslblCurrentDate;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripStatusLabel slblRokadDate;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private ToolStripMenuItem pledgeReportTodayToolStripMenuItem;
    private ToolStripMenuItem pledgeReportToolStripMenuItem;
    private ToolStripMenuItem rokadReportsConsolidatedToolStripMenuItem;
    private System.Windows.Forms.Timer timer1;
    private ToolStripMenuItem inactivityMonitorToolStripMenuItem;
    private ToolStripMenuItem removeDuplicateCustomersToolStripMenuItem;
    private ToolStripButton toolStripButton1;
    private ToolStripMenuItem changeInterestToolStripMenuItem;
    private ToolStripMenuItem pledgeInterestReportToolStripMenuItem;
    private ToolStripMenuItem completeSummaryToolStripMenuItem;
    private ToolStripLabel tslAutoEntryRokad;
    private ToolStripMenuItem printLedgerToolStripMenuItem;
    private ToolStripMenuItem pledgeBookToolStripMenuItem;
    private ToolStripMenuItem pendingInterestReportsToolStripMenuItem;
    private ToolStripMenuItem partPaymentToolStripMenuItem;
    private ToolStripMenuItem partPaymentToolStripMenuItem1;
    private ToolStripMenuItem partPaymentReportsToolStripMenuItem;
    private ToolStripMenuItem partPaymentOldEntryToolStripMenuItem;
    private ToolStripMenuItem denominationToolStripMenuItem;
    private ToolStripMenuItem removeDuplicateAddressToolStripMenuItem;
    private ToolStripMenuItem basedOnNetWeightToolStripMenuItem;
    private ToolStripMenuItem basedOnPureWeightToolStripMenuItem;
    private ToolStripTextBox tstbBillingDate;
    private ToolStripMenuItem changeOpeningBalanceToolStripMenuItem;
    private ToolStripMenuItem articlesSettingsToolStripMenuItem;
    private ToolStripMenuItem pledgeExpiringTodayToolStripMenuItem;
    private ToolStripMenuItem pledgeExpiringThisMonthToolStripMenuItem;
    private ToolStripMenuItem viewPledgeToolStripMenuItem;
    private ToolStripMenuItem generalSettingsToolStripMenuItem;
    private ToolStripComboBox tscbShopCode;
    private ToolStripLabel toolStripLabel4;
    private ToolStripMenuItem stockMasterToolStripMenuItem;
    private ToolStripMenuItem stockCheckToolStripMenuItem;
    private ToolStripMenuItem manageStockToolStripMenuItem;
    private ToolStripMenuItem deleteRedemptionTillToolStripMenuItem;
    private ToolStripMenuItem numberOfBillsToolStripMenuItem;
    private ToolStripMenuItem numberOfBillsConsolidatedToolStripMenuItem2;
    private ToolStripMenuItem pledgeAmountSummaryToolStripMenuItem1;
    private ToolStripMenuItem pledgeAmountSummaryYearlyToolStripMenuItem1;
    private ToolStripMenuItem numberOfBillsToolStripMenuItem3;
    private ToolStripMenuItem numberOfBillsConsolidatedToolStripMenuItem3;
    private ToolStripMenuItem redemptionInterestYearlySummaryToolStripMenuItem;
    private ToolStripMenuItem redemptionInterestMonthlySummaryToolStripMenuItem3;
    private ToolStripMenuItem redemptionINTERESTYearlySummaryToolStripMenuItem1;
    private ToolStripMenuItem redemptionINTERESTMonthlySummaryToolStripMenuItem2;
    private ToolStripMenuItem redemptionReportsTodayToolStripMenuItem;
    private ToolStripMenuItem redemptionReportsToolStripMenuItem1;
    private ToolStripMenuItem viewRedemptionToolStripMenuItem;
    private ToolStripLabel toolStripLabel5;
    private ToolStripMenuItem duplicateRedemptionBillToolStripMenuItem;
    private ToolStripMenuItem dayReportToolStripMenuItem;
    private ToolStripMenuItem changeABillFromOneLicenseToOtherToolStripMenuItem;
    private ToolStripMenuItem jewelsReleasedButStillInBankToolStripMenuItem1;
    private ToolStripMenuItem billerMasterToolStripMenuItem;
    private ToolStripComboBox tscbBillerName;
    private ToolStripLabel toolStripLabel6;
    private ToolStripButton toolStripButton2;
    private ToolStripMenuItem pendingGirviTotalToolStripMenuItem;
    private ToolStripButton toolStripButton3;
    private ToolStripButton toolStripButton4;
    private ToolStripButton toolStripButton5;
    private ToolStripButton toolStripButton6;
    private ToolStripButton toolStripButton7;
    private ToolStripButton toolStripButton8;
    private ToolStripButton toolStripButton9;
    private ToolStripMenuItem stockCheckToolStripMenuItem1;
    private ToolStripMenuItem reBillToolStripMenuItem;
    private ToolStripMenuItem findCustomersWithSamePhoneNumberToolStripMenuItem;
    private ToolStripMenuItem interestSettingToolStripMenuItem;
    private ToolStripMenuItem iNTERESTSETTINGToolStripMenuItem1;
    private ToolStripMenuItem interestSettingsToolStripMenuItem;
    private ToolStripMenuItem customersPendingGirviListToolStripMenuItem;
    private ToolStripMenuItem printCustomerCopyBackSideToolStripMenuItem;
    private ToolStripMenuItem printOfficeCopyBackSideToolStripMenuItem;
    private ToolStripLabel tslFingerPrint;
    private BackgroundWorker backgroundWorker1;
    private BackgroundWorker backgroundWorker2;
    private BackgroundWorker backgroundWorker3;
    private BackgroundWorker backgroundWorker4;
    private BackgroundWorker backgroundWorker5;
    private ToolStripMenuItem tesingToolStripMenuItem;
    private ToolStripMenuItem deletePledgeToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem3;
    private PictureBox pbFingerPrint;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem jewelleryToolStripMenuItem;
    private ToolStripMenuItem shopDetailsToolStripMenuItem1;
    private ToolStripMenuItem rateMasterToolStripMenuItem;
    private ToolStripMenuItem memberTypeMasterToolStripMenuItem;
    private ToolStripMenuItem customersWithoutPendingPledgeToolStripMenuItem;
    private ToolStripMenuItem itemsNamesMasterToolStripMenuItem;
    private ToolStripMenuItem itemTypeMasterToolStripMenuItem;
    private ToolStripMenuItem tsmIUndoRedemption;
    private ToolStripMenuItem form2ToolStripMenuItem;
    private ToolStripMenuItem metalMasterToolStripMenuItem;
    private ToolStripMenuItem purityMasterToolStripMenuItem;
    private ToolStripMenuItem oldPledgeToolStripMenuItem1;
    private ToolStripMenuItem bankNewPledgeToolStripMenuItem;
    private ToolStripMenuItem bankPledgeEditToolStripMenuItem1;
    private ToolStripMenuItem bankReleaseToolStripMenuItem1;
    private ToolStripMenuItem undoRedemptionToolStripMenuItem1;
    private ToolStripMenuItem bankReleaseEditToolStripMenuItem;
    private ToolStripMenuItem formPLEDGEEToolStripMenuItem;
    private ToolStripMenuItem testingOldpledgeToolStripMenuItem;
    private ToolStripMenuItem customerSettingsToolStripMenuItem;
    private ToolStripMenuItem customersLocationReportToolStripMenuItem;
    private ToolStripMenuItem newSaleToolStripMenuItem;
    private ToolStripMenuItem billNumberSettingsToolStripMenuItem;
    private ToolStripMenuItem emailToolStripMenuItem;
    private ToolStripMenuItem hELLOToolStripMenuItem;
    private ToolStripMenuItem newAaddCustomerToolStripMenuItem;
    private ToolStripMenuItem form4ToolStripMenuItem;
    private ToolStripMenuItem panelToolStripMenuItem;
    private ToolStripMenuItem asdfToolStripMenuItem;
    private ToolStripMenuItem fdsdfsdfToolStripMenuItem;
    private ToolStrip ts2;
    private ToolStripButton toolStripButton10;
    private ToolStripButton toolStripButton11;
    private ToolStripButton toolStripButton12;
    private ToolStripButton toolStripButton15;
    private ToolStripButton toolStripButton16;
    private ToolStripButton toolStripButton17;
    private ToolStripButton toolStripButton14;
    private ToolStripButton toolStripButton13;
    private ToolStripButton toolStripButton19;
    private ToolStripButton toolStripButton18;
    private ToolStripMenuItem noticeChargeSummaryToolStripMenuItem;
    private ToolStripMenuItem salesReportToolStripMenuItem;
    private ToolStripMenuItem form9ToolStripMenuItem;
    private ToolStripMenuItem printLastBilllCustomerCopyToolStripMenuItem;
    private ToolStripMenuItem printLastBillOfficeCopyToolStripMenuItem;
    private ToolStripMenuItem printLastRedemptionBillToolStripMenuItem;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;
    private SplitContainer splitContainer1;
    private ToolStripButton toolStripButton20;
    private ToolStripMenuItem multipleReleaseAndReBillToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deletePledgeToolStripMenuItem1;
    private ToolStripMenuItem printCustomerCopyToolStripMenuItem;
    private ToolStripMenuItem printOfficeCopyToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem toolStripMenuItem4;
    private ToolStripMenuItem toolStripMenuItem5;
    private ToolStripMenuItem xmlSchemaToolStripMenuItem;
    private ToolStripMenuItem viewCustomerType2ToolStripMenuItem;
    private ToolStripMenuItem viewCustomer2ToolStripMenuItem;
    private ToolStripMenuItem shortcutsToolStripMenuItem;
    private ToolStripMenuItem calculatorToolStripMenuItem1;
    private ToolStripMenuItem deviceMangerToolStripMenuItem;
    private ToolStripMenuItem printersToolStripMenuItem;
    private ToolStripMenuItem deletePledgeTillToolStripMenuItem;
    private ToolStripMenuItem asdfasdfToolStripMenuItem;
    private ToolStripMenuItem printLastRedemptionBillFormD3ToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip3;
    private ToolStripMenuItem changeBackgroundToolStripMenuItem;

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetModuleHandle(string moduleName);

    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

    [DllImport("user32.dll")]
    internal static extern short GetKeyState(int keyCode);

    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    public FormMain(string UserName, string memberId, string memberTYpe, string language)
    {
      this.InitializeComponent();
      this.menuStrip1.Renderer = (ToolStripRenderer) new FormMain.MyRenderer();
      FormMain.username = UserName;
      FormMain.memberid = memberId;
      FormMain.memberType = memberTYpe;
      FormMain.Language = language;
    }

    public FormMain(
      string UserName,
      string memberId,
      string memberTYpe,
      string language,
      DateTime validTill)
    {
      this.InitializeComponent();
      this.menuStrip1.Renderer = (ToolStripRenderer) new FormMain.MyRenderer();
      FormMain.username = UserName;
      FormMain.memberid = memberId;
      FormMain.memberType = memberTYpe;
      FormMain.Language = language;
      FormMain.licenceValidTill = validTill;
    }

    private void getFingerPrintSettings()
    {
      FormMain.m_NumCandList = FormMain.DEFAULT_NUM_CAND_LIST;
      FormMain.pEngineParam = new SS_EngineParam();
      FormMain.pEngineParam.CandidateNumber = FormMain.m_NumCandList;
      FormMain.pEngineParam.MemPoolSizeMB = FormMain.SIZE_MEMORY_POOL;
      FormMain.pEngineParam.szLicenseFile = !FormMain.IsWow64() ? FormMain.SECUSEARCH_LICENSE_FILE : FormMain.SECUSEARCH_LICENSE_FILE_x64;
      FormMain.m_SecuSearch = new SecuSearch();
      int num1 = FormMain.m_SecuSearch.InitializeEngine(FormMain.pEngineParam);
      if (num1 == 0)
      {
        try
        {
          string strError = "";
          string my_querry = "SELECT ID,FingerNumber,SampleNumber,FingerPrint FROM tblCustomers";
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
          if (strError != "")
          {
            PawnManagementClass.InsertIntoException("FormAddCustomer.getLocationAndPincode", strError, FormMain.username, DateTime.Now.ToString());
            int num2 = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
          }
          else
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            {
              if (row["FingerNumber"] != null && row["SampleNumber"] != null && row["FingerPrint"] != null && row["FingerNumber"].ToString() != "" && row["SampleNumber"].ToString() != "" && row["FingerPrint"].ToString() != "")
              {
                SS_IDInfo userID = new SS_IDInfo();
                userID.ID = Convert.ToInt32(row["ID"]);
                userID.FingerNumber = Convert.ToByte(row["FingerNumber"]);
                userID.SampleNumber = Convert.ToByte(row["SampleNumber"]);
                byte[] minData = Convert.FromBase64String(row["FingerPrint"].ToString());
                FormMain.m_SecuSearch.RegisterFP(minData, userID);
              }
            }
          }
        }
        catch (OleDbException ex)
        {
          int num3 = (int) MessageBox.Show(ex.ToString());
        }
        this.RefreshDBListView();
      }
      else
      {
        int num4 = (int) MessageBox.Show("InitializeEngine() Error" + Convert.ToString(num1));
      }
    }

    public static bool IsWow64()
    {
      bool wow64Process = false;
      if (FormMain.DoesWin32MethodExist("kernel32.dll", "IsWow64Process"))
        FormMain.IsWow64Process(FormMain.GetCurrentProcess(), out wow64Process);
      return wow64Process;
    }

    private static bool DoesWin32MethodExist(string moduleName, string methodName)
    {
      IntPtr moduleHandle = FormMain.GetModuleHandle(moduleName);
      return !(moduleHandle == IntPtr.Zero) && FormMain.GetProcAddress(moduleHandle, methodName) != IntPtr.Zero;
    }

    private void RefreshDBListView()
    {
    }

    private void mainLoad(object sender, WaitWindowEventArgs e)
    {
      try
      {
        this.getMenuItems();
        string text1 = "";
        foreach (string str in this.menuitemsSelected)
          text1 += str;
        int num1 = (int) MessageBox.Show(text1);
        foreach (ToolStripMenuItem toolStripMenuItem in (ArrangedElementCollection) this.menuStrip1.Items)
        {
          if (toolStripMenuItem.HasDropDownItems)
          {
            foreach (ToolStripMenuItem dropDownItem in (ArrangedElementCollection) toolStripMenuItem.DropDownItems)
            {
              this.menuitems.Add(dropDownItem.Text.ToString());
              if (!this.menuitemsSelected.Contains(dropDownItem.Text.ToString()))
              {
                dropDownItem.Visible = false;
              }
              else
              {
                int num2 = (int) MessageBox.Show(dropDownItem.Text.ToString() + " true");
              }
            }
          }
        }
        string text2 = "";
        foreach (string menuitem in this.menuitems)
          text2 += menuitem;
        int num3 = (int) MessageBox.Show(text2);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private DataTable getHistoryReminder()
    {
      string strError = "";
      string my_querry = "select * from tblHistoryReminder";
      List<OleDbParameter> oleDbParameterList = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.getHistoryREminder()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      return dataTable2;
    }

    private void checkForHistoryReminder()
    {
      try
      {
        string str = "";
        DataTable dataTable = new DataTable();
        foreach (DataRow row in (InternalDataCollectionBase) this.getHistoryReminder().Rows)
          str = str + ",'" + row.Field<string>("history") + "'";
        this.checkForHistoryReminderInHistoryTable(str.Substring(1, str.Length - 1));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForHistoryReminder", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void checkForHistoryReminderInHistoryTable(string selectedHistoryItems)
    {
      string strError = "";
      this.dtHistoryReminder = SQLHelper.GetDataTable("select * from  tblHistory where   (ActionPipe in(" + selectedHistoryItems + ")) and ( performedOn like '" + DateTime.Now.ToString("dd/MM/yyyy") + "%')", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForHistoryReminderInHistroryTable(string selectedhistoryItems)", strError, FormMain.username, DateTime.Now.ToString());
        PawnManagementClass.InsertIntoException("form DashBoard.getHistoryREminder()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the data from tabel history " + strError);
      }
      FormDataGridView formDataGridView = new FormDataGridView(this.dtHistoryReminder, "History REminder");
      formDataGridView.MdiParent = (Form) this;
      formDataGridView.Show();
    }

    private void checkForBankPledgeToBeReleasedToday()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select BankCode,BankSerialNumber, BillNumber,BillDate,CustomerCode,CustomerName,Type,NetWeight,Amount,presentValue,temp1 as interestRate,temp2 as Interest,temp3 as finalinterest,temp4 as redemptionamount  from tblpledge where redeemed = 'Y' and (BankCode is not null and BankCode <> '')", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form interest.refresGrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
      }
      else
      {
        FormDataGridView formDataGridView = new FormDataGridView(dataTable, "Bank Pledge To be Released Today");
        formDataGridView.MdiParent = (Form) this;
        formDataGridView.Show();
      }
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) (FormMain.dtShopCodes = PawnManagementClass.getShopCodes()).Rows)
      {
        this.tscbShopCode.Items.Add((object) row["ShopCode"].ToString());
        FormMain.lstShopCodes.Add(row["ShopCode"].ToString());
      }
    }

    private void Main_Load(object sender, EventArgs e)
    {
      try
      {
        this.Left = this.Top = 0;
        this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        this.backgroundWorker1.RunWorkerAsync((object) new object[0]);
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView2);
        this.getPicture();
        this.gettblSettings();
        if (FormMain.boolShowSidePanel)
          this.splitContainer1.Visible = true;
        else
          this.splitContainer1.Visible = false;
        this.getArticlesSettings();
        try
        {
          if (FormMain.strMenuSetting == "ON")
          {
            this.getMenuItems();
            foreach (ToolStripMenuItem toolStripMenuItem in (ArrangedElementCollection) this.menuStrip1.Items)
            {
              if (toolStripMenuItem.HasDropDownItems)
              {
                foreach (ToolStripMenuItem dropDownItem in (ArrangedElementCollection) toolStripMenuItem.DropDownItems)
                {
                  this.menuitems.Add(dropDownItem.Text.ToString());
                  if (!this.menuitemsSelected.Contains(dropDownItem.Text.ToString()))
                  {
                    dropDownItem.Visible = false;
                    dropDownItem.Enabled = false;
                  }
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          throw;
        }
        if (!FormMain.UseFingerPrint)
          return;
        this.getAutoOnFingerPrint();
        this.getFingerPrintSettings();
        this.InitializeFingerPrintDevice();
        if (FormMain.AutoOnfingerPrint)
          FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
        else
          FormMain.m_FPM.EnableAutoOnEvent(false, 0);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form main.main_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public void pledgeReport(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("Select shopcode,BillNumber,Amount,temp5 as Interest,customername,BillDate from tblPledge  where BillDate = @BillDate order by shopcode,billnumber ", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) BILLDATE)
      }, ref strError);
      double num1 = 0.0;
      double num2 = 0.0;
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          num1 += double.Parse(row["Amount"].ToString());
          num2 += double.Parse(row["Interest"].ToString());
        }
      }
      dataTable2.Rows.Add();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Amount"] = (object) num1.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Interest"] = (object) num2.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["BillNumber"] = (object) (dataTable2.Rows.Count - 1);
      this.dataGridView1.DataSource = (object) dataTable2;
      this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount - 1;
      this.dataGridView1.Columns["ShopCode"].Visible = false;
      this.dataGridView1.Columns["BillDate"].Visible = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView1.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    public void redemptionReport(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("Select  shopcode,BillNumber,PledgeBillnumber,tr.Amount,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tc.CName as CustomerName,BillDate from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate order by shopcode,billnumber", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) BILLDATE)
      }, ref strError);
      double num1 = 0.0;
      double num2 = 0.0;
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          num1 += double.Parse(row["Amount"].ToString());
          num2 += double.Parse(row["FinalInterest"].ToString());
        }
      }
      dataTable2.Rows.Add();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Amount"] = (object) num1.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["FinalInterest"] = (object) num2.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["BillNumber"] = (object) (dataTable2.Rows.Count - 1).ToString();
      this.dataGridView2.DataSource = (object) dataTable2;
      this.dataGridView2.FirstDisplayedScrollingRowIndex = this.dataGridView2.RowCount - 1;
      this.dataGridView2.Columns["ShopCode"].Visible = false;
      this.dataGridView2.Columns["BillDate"].Visible = false;
      this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      this.dataGridView2.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView2.Columns["FinalInterest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void getArticlesSettings()
    {
      this.dtArticlesSettings = PawnManagementClass.getArticlesSettings();
      if (this.dtArticlesSettings == null || this.dtArticlesSettings.Rows.Count <= 0)
        return;
      if (this.dtArticlesSettings.Rows[0]["PledgeExpiringToday"] != null && this.dtArticlesSettings.Rows[0]["PledgeExpiringToday"].ToString() != "")
        FormMain.PledgeExpiringTodayScreen = this.dtArticlesSettings.Rows[0]["PledgeExpiringToday"].ToString();
      if (this.dtArticlesSettings.Rows[0]["PledgeExpiringThisMonth"] != null && this.dtArticlesSettings.Rows[0]["PledgeExpiringThisMonth"].ToString() != "")
        FormMain.PledgeExpriringThisMonthScreen = this.dtArticlesSettings.Rows[0]["PledgeExpiringThisMonth"].ToString();
      if (this.dtArticlesSettings.Rows[0]["ViewCustomersScreen"] != null && this.dtArticlesSettings.Rows[0]["ViewCustomersScreen"].ToString() != "")
        FormMain.ViewCustomersScreen = this.dtArticlesSettings.Rows[0]["ViewCustomersScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["RemoveDuplicateCustomerScreen"] != null && this.dtArticlesSettings.Rows[0]["RemoveDuplicateCustomerScreen"].ToString() != "")
        FormMain.RemoveDuplicateCustomerScreen = this.dtArticlesSettings.Rows[0]["RemoveDuplicateCustomerScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["PledgeScreen"] != null && this.dtArticlesSettings.Rows[0]["PledgeScreen"].ToString() != "")
        FormMain.PledgeScreen = this.dtArticlesSettings.Rows[0]["PledgeScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["PledgeReportsScreen"] != null && this.dtArticlesSettings.Rows[0]["PledgeReportsScreen"].ToString() != "")
        FormMain.PledgeReportsScreen = this.dtArticlesSettings.Rows[0]["PledgeReportsScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["LedgerScreen"] != null && this.dtArticlesSettings.Rows[0]["LedgerScreen"].ToString() != "")
        FormMain.LedgerScreen = this.dtArticlesSettings.Rows[0]["LedgerScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["PledgeInLossScreen"] != null && this.dtArticlesSettings.Rows[0]["PledgeInLossScreen"].ToString() != "")
        FormMain.PledgeInLossScreen = this.dtArticlesSettings.Rows[0]["PledgeInLossScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["NoticeScreen"] != null && this.dtArticlesSettings.Rows[0]["NoticeScreen"].ToString() != "")
        FormMain.NoticeScreen = this.dtArticlesSettings.Rows[0]["NoticeScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["RedemptionReportsScreen"] != null && this.dtArticlesSettings.Rows[0]["RedemptionReportsScreen"].ToString() != "")
        FormMain.RedemptionReportsScreen = this.dtArticlesSettings.Rows[0]["RedemptionReportsScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["AuctionReportsScreen"] != null && this.dtArticlesSettings.Rows[0]["AuctionReportsScreen"].ToString() != "")
        FormMain.AuctionReportsScreen = this.dtArticlesSettings.Rows[0]["AuctionReportsScreen"].ToString();
      if (this.dtArticlesSettings.Rows[0]["BankInsideOutsideScreen"] != null && this.dtArticlesSettings.Rows[0]["BankInsideOutsideScreen"].ToString() != "")
        FormMain.BankInsideOutsideScreen = this.dtArticlesSettings.Rows[0]["BankInsideOutsideScreen"].ToString();
    }

    private void getFingerPrint()
    {
      if (!FormMain.UseFingerPrint)
        return;
      if (!double.TryParse(CustomersClass.getMaxId().ToString(), NumberStyles.Integer, (IFormatProvider) CultureInfo.CurrentCulture, out double _))
      {
        int num1 = (int) MessageBox.Show("Please enter number for user id.");
      }
      else
      {
        byte[] numArray = new byte[FormMain.m_ImageWidth * FormMain.m_ImageHeight];
        int imageEx = FormMain.m_FPM.GetImageEx(numArray, 5000, this.pbFingerPrint.Handle.ToInt32(), 50);
        if (imageEx != 0)
        {
          int num2 = (int) MessageBox.Show("Image Capture Error: " + Convert.ToString(imageEx));
        }
        else
        {
          this.minData = new byte[400];
          int template = FormMain.m_FPM.CreateTemplate(numArray, this.minData);
          if (template != 0)
          {
            int num3 = (int) MessageBox.Show("Get Minutiae Error: " + Convert.ToString(template));
          }
          else
          {
            this.idInfo = new SS_IDInfo();
            this.idInfo.ID = Convert.ToInt32(CustomersClass.getMaxId());
            this.idInfo.FingerNumber = (byte) 1;
            this.idInfo.SampleNumber = Convert.ToByte(1);
            SS_IDInfo basedOnFingerPrint = FingerPrintClass.getCustomerIdBasedOnFingerPrint(this.minData);
            if (basedOnFingerPrint != null)
            {
              string customerCode = CustomersClass.getCustomerCode(basedOnFingerPrint.ID.ToString());
              if (customerCode != "")
              {
                FormPledgePledge formPledgePledge = new FormPledgePledge("NEW PLEDGE", customerCode);
                formPledgePledge.MdiParent = (Form) this;
                foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
                {
                  if (openForm.GetType() == typeof (FormPledgePledge))
                  {
                    openForm.BringToFront();
                    openForm.WindowState = FormWindowState.Maximized;
                    return;
                  }
                }
                formPledgePledge.Show();
                formPledgePledge.WindowState = FormWindowState.Maximized;
              }
              else if (DialogResult.Yes == MessageBox.Show("New Customer.   Add?", "Add New Customer", MessageBoxButtons.YesNo))
              {
                FormAddCustomer formAddCustomer = new FormAddCustomer();
                if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
                {
                  if (FormMain.AutoOnfingerPrint)
                    FormMain.m_FPM.EnableAutoOnEvent(true, (int) formAddCustomer.Handle);
                  else
                    FormMain.m_FPM.EnableAutoOnEvent(false, 0);
                }
                int num4 = (int) formAddCustomer.ShowDialog();
              }
            }
            else
            {
              int num5 = (int) MessageBox.Show("Try again");
            }
          }
        }
      }
    }

    private void InitializeFingerPrintDevice()
    {
      FormMain.m_FPM = new SGFingerPrintManager();
      int num1 = FormMain.m_FPM.Init(SGFPMDeviceName.DEV_AUTO);
      if (num1 == 0)
      {
        int num2 = FormMain.m_FPM.OpenDevice(0);
        if (num2 != 0)
        {
          int num3 = (int) MessageBox.Show("FDx SDK OpenDevice Error" + Convert.ToString(num2));
        }
        else
        {
          SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
          FormMain.m_FPM.GetDeviceInfo(pInfo);
          FormMain.m_ImageWidth = pInfo.ImageWidth;
          FormMain.m_ImageHeight = pInfo.ImageHeight;
          this.tslFingerPrint.Text = "FINGERPRINT IS ON";
        }
      }
      else
      {
        this.tslFingerPrint.Text = "FINGERPRINT ERROR " + Convert.ToString(num1);
        FormMain.UseFingerPrint = false;
      }
    }

    private void getBillerNames()
    {
      DataTable billerTable = PawnManagementClass.getBillerTable();
      this.tscbBillerName.Items.Clear();
      if (billerTable == null || billerTable.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) billerTable.Rows)
        this.tscbBillerName.Items.Add((object) row["BillerName"].ToString());
    }

    private bool getBankPledgeToBeReleasedToday()
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
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BankPledgeToBeReleasedTodayPrompt"] != null && dataTable2.Rows[0]["BankPledgeToBeReleasedTodayPrompt"].ToString() == "Y")
        return true;
      return false;
    }

    private void setLanguage()
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
      this.customersToolStripMenuItem.Text = this.LocRM.GetString("Customers");
      this.viewCustomersToolStripMenuItem.Text = this.LocRM.GetString("ViewCustomer");
      this.addCustomerToolStripMenuItem.Text = this.LocRM.GetString("AddCustomer");
      this.searchCustomerToolStripMenuItem.Text = this.LocRM.GetString("SearchCustomer");
      this.customerRemindersToolStripMenuItem.Text = this.LocRM.GetString("CustomerReminder");
      this.editCustomerToolStripMenuItem.Text = this.LocRM.GetString("EditCustomer");
      this.customersNotComingToolStripMenuItem.Text = this.LocRM.GetString("CustomersNotComing");
      this.CustomersStreetReport.Text = this.LocRM.GetString("CustomerStreetReport");
      this.regularCustomersWhoAreNotComingToolStripMenuItem.Text = this.LocRM.GetString("RegularCustomersWhoAreNotComing");
      this.pledgeToolStripMenuItem.Text = this.LocRM.GetString("Pledge");
      this.oldPledgeToolStripMenuItem.Text = this.LocRM.GetString("OldPledge");
      this.pledgeEditToolStripMenuItem.Text = this.LocRM.GetString("PledgeEdit");
      this.pledgeReportsToolStripMenuItem1.Text = this.LocRM.GetString("PledgeReport");
      this.pledgeReportsToolStripMenuItem.Text = this.LocRM.GetString("PledgeReport");
      this.numberOfBillsToolStripMenuItem1.Text = this.LocRM.GetString("NumberOfBills");
      this.numberOfBillsToolStripMenuItem2.Text = this.LocRM.GetString("NumberOfBills");
      this.ledgerToolStripMenuItem.Text = this.LocRM.GetString("Ledger");
      this.noticeToolStripMenuItem.Text = this.LocRM.GetString("Notice");
      this.pledgeAmountSummaryToolStripMenuItem.Text = this.LocRM.GetString("PledgeAmountSummary");
      this.redemptionToolStripMenuItem.Text = this.LocRM.GetString("Redemption");
      this.oldRedemptionToolStripMenuItem.Text = this.LocRM.GetString("OldRedemption");
      this.redemptionEditToolStripMenuItem.Text = this.LocRM.GetString("RedemptionEdit");
      this.auctionRedemptionToolStripMenuItem.Text = this.LocRM.GetString("Auction");
      this.redeemReportsToolStripMenuItem.Text = this.LocRM.GetString("Redemption");
      this.bankToolStripMenuItem.Text = this.LocRM.GetString("Bank");
      this.bankMasterToolStripMenuItem.Text = this.LocRM.GetString("BankMaster");
      this.bankPledgeToolStripMenuItem.Text = this.LocRM.GetString("BankPledge");
      this.bankReleaseToolStripMenuItem.Text = this.LocRM.GetString("BankRelease");
      this.khaathoToolStripMenuItem.Text = this.LocRM.GetString("Khaatho");
      this.viewKhaathoToolStripMenuItem.Text = this.LocRM.GetString("ViewKhatho");
      this.bankReportsToolStripMenuItem.Text = this.LocRM.GetString("BankReport");
      this.outsidePledgeListToolStripMenuItem.Text = this.LocRM.GetString("OutsidePledgeList");
      this.smsMessagesToolStripMenuItem.Text = this.LocRM.GetString("SmsMessages");
      this.fORMD3ToolStripMenuItem.Text = this.LocRM.GetString("FormD3");
      this.duplicateBillToolStripMenuItem.Text = this.LocRM.GetString("DuplicateBill");
      this.fORMDToolStripMenuItem.Text = this.LocRM.GetString("FormD");
      this.formCToolStripMenuItem.Text = this.LocRM.GetString("FormC");
      this.smsToolStripMenuItem1.Text = this.LocRM.GetString("Sms");
      this.shopDetailsToolStripMenuItem.Text = this.LocRM.GetString("ShopDetails");
      this.articlesToolStripMenuItem1.Text = this.LocRM.GetString("Articles");
      this.loginDetailsToolStripMenuItem.Text = this.LocRM.GetString("LoginDetails");
      this.interestToolStripMenuItem.Text = this.LocRM.GetString("Interest");
      this.gramRateToolStripMenuItem.Text = this.LocRM.GetString("GramRate");
      this.locationAndPincodeToolStripMenuItem.Text = this.LocRM.GetString("LocationAndPincode");
      this.menuSettingsToolStripMenuItem.Text = this.LocRM.GetString("MenuSettings");
      this.historyReminderSettingsToolStripMenuItem.Text = this.LocRM.GetString("HistoryReminderSettings");
      this.historyToolStripMenuItem.Text = this.LocRM.GetString("History");
      this.autoBackupToolStripMenuItem.Text = this.LocRM.GetString("AutoBackUp");
      this.jewelPhotoToolStripMenuItem1.Text = this.LocRM.GetString("JewelPhoto");
      this.exceptionsToolStripMenuItem.Text = this.LocRM.GetString("Exceptions");
      this.reminderToolStripMenuItem.Text = this.LocRM.GetString("Reminder");
      this.billNumberSeriesToolStripMenuItem.Text = this.LocRM.GetString("BillNumberSeries");
      this.optionsToolStripMenuItem.Text = this.LocRM.GetString("Options");
      this.exitToolStripMenuItem.Text = this.LocRM.GetString("Exit");
      this.printsToolStripMenuItem.Text = this.LocRM.GetString("Prints");
      this.accountsToolStripMenuItem.Text = this.LocRM.GetString("Accounts");
      this.ledgerDetailsToolStripMenuItem.Text = this.LocRM.GetString("LedgerDetails");
    }

    private bool getBankRenewalReminderSettings()
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
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["BankRenewalReminderPrompt"] != null && dataTable2.Rows[0]["BankRenewalReminderPrompt"].ToString() == "Y")
        return true;
      return false;
    }

    private bool getPendingGirviTotalSettings()
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
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["PendingGirviTotalPrompt"] != null && dataTable2.Rows[0]["PendingGirviTotalPrompt"].ToString() == "Y")
        return true;
      return false;
    }

    private void checkForBankRenewalReminder()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where Released = 'N' and BankBillDate < @BankBillDate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      List<OleDbParameter> oleDbParameterList = parameters;
      DateTime dateTime = DateTime.Now;
      dateTime = dateTime.AddYears(-1);
      OleDbParameter oleDbParameter = new OleDbParameter("BankBillDate", (object) dateTime.ToString("dd/MM/yyyy"));
      oleDbParameterList.Add(oleDbParameter);
      this.dtBankRenewalReminder = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForbankRenewalReminder()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      FormDataGridView formDataGridView = new FormDataGridView(this.dtBankRenewalReminder, "BANK RENEWAL REMINDER");
      formDataGridView.MdiParent = (Form) this;
      formDataGridView.Show();
    }

    private bool getHistoryReminderSettings()
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
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["HistoryReminderPrompt"] != null && dataTable2.Rows[0]["HistoryReminderPrompt"].ToString() == "Y")
        return true;
      return false;
    }

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
        FormMain.withIndividualWeight = dataTable2.Rows[0]["WithIndividualWeight"] != null && dataTable2.Rows[0]["WithIndividualWeight"].ToString() == "Y";
        FormMain.UseFingerPrint = dataTable2.Rows[0]["UseFingerPrint"] != null && dataTable2.Rows[0]["UseFingerPrint"].ToString() == "Y";
        FormMain.boolPledgeScreenSimple = dataTable2.Rows[0]["PledgeScreenSimple"] != null && dataTable2.Rows[0]["PledgeScreenSimple"].ToString() == "Y";
        FormMain.boolShowSidePanel = dataTable2.Rows[0]["ViewPledgeAndRedemptionInSide"] != null && dataTable2.Rows[0]["ViewPledgeAndRedemptionInSide"].ToString() == "Y";
        FormMain.RemindIfNameAndAddressSame = dataTable2.Rows[0]["RemindIfNameAndAddressSame"] != null && dataTable2.Rows[0]["RemindIfNameAndAddressSame"].ToString() == "Y";
        FormMain.RemindIfNameAddressAndDoorNumberSame = dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"] != null && dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"].ToString() == "Y";
        FormMain.addEditCustomerSetting = dataTable2.Rows[0]["AddEditCustomerSetting"] == null || !(dataTable2.Rows[0]["AddEditCustomerSetting"].ToString() != "") ? "SIMPLE" : dataTable2.Rows[0]["aDDEDITCUSTOMERSETTING"].ToString();
        if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"] != null)
        {
          if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"].ToString() != "")
          {
            if (dataTable2.Rows[0]["IncludeNoticeChargeInPledgeScreen"].ToString() == "Y")
              FormMain.IncludeNoticeChargeInPledgeScreen = true;
          }
          else
            FormMain.IncludeNoticeChargeInPledgeScreen = false;
        }
        else
          FormMain.IncludeNoticeChargeInPledgeScreen = false;
        if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"] != null)
        {
          if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"].ToString() != "")
          {
            if (dataTable2.Rows[0]["IncludeNoticeChargeInRedemptionScreen"].ToString() == "Y")
              FormMain.IncludeNoticeChargeInRedemptionScreen = true;
          }
          else
            FormMain.IncludeNoticeChargeInRedemptionScreen = false;
        }
        else
          FormMain.IncludeNoticeChargeInRedemptionScreen = false;
        FormMain.NoticeChargeInPledgeScreen = dataTable2.Rows[0]["NoticeChargeInPledgeScreen"] == null ? "0" : (!(dataTable2.Rows[0]["NoticeChargeInPledgeScreen"].ToString() != "") ? "0" : dataTable2.Rows[0]["NoticeChargeInPledgeScreen"].ToString());
        FormMain.NoticeChargeInRedemptionScreen = dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"] == null ? "0" : (!(dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"].ToString() != "") ? "0" : dataTable2.Rows[0]["NoticeChargeInRedemptionScreen"].ToString());
        if (dataTable2.Rows[0]["PrintOFFiceCopy"] != null && dataTable2.Rows[0]["PrintOFFiceCopy"].ToString() != "")
          FormMain.strPrintOfficeCopy = dataTable2.Rows[0]["PrintOFFiceCopy"].ToString();
        if (dataTable2.Rows[0]["PrintCustomerCopy"] != null && dataTable2.Rows[0]["PrintCustomerCopy"].ToString() != "")
          FormMain.strPrintCustomerCopy = dataTable2.Rows[0]["PrintCustomerCopy"].ToString();
        if (dataTable2.Rows[0]["PledgeWithoutBackgroundWorker"] != null && dataTable2.Rows[0]["PledgeWithoutBackgroundWorker"].ToString() != "")
          FormMain.strPledgeWithoutBackgroundWorker = dataTable2.Rows[0]["PledgeWithoutBackgroundWorker"].ToString();
        if (dataTable2.Rows[0]["Menusettings"] != null && dataTable2.Rows[0]["Menusettings"].ToString() != "")
          FormMain.strMenuSetting = !(dataTable2.Rows[0]["Menusettings"].ToString() == "ON") ? "OFF" : dataTable2.Rows[0]["Menusettings"].ToString();
        if (dataTable2.Rows[0]["quickRelease"] != null)
        {
          if (dataTable2.Rows[0]["quickRelease"].ToString() != "")
          {
            if (dataTable2.Rows[0]["quickRelease"].ToString() == "Y")
              FormMain.quickRelease = true;
          }
          else
            FormMain.quickRelease = false;
        }
        else
          FormMain.quickRelease = false;
      }
    }

    private void getAutoOnFingerPrint()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        FormMain.AutoOnfingerPrint = dataTable2.Rows[0]["AutoOnFingerPrint"].ToString() == "Y";
    }

    private void im_Elapsed(object sender, ElapsedEventArgs e)
    {
      int num = (int) MessageBox.Show("closing because of inactivity");
      this.Close();
    }

    private void autoDeleteRokad()
    {
      string deleteRokadBefore = "";
      DataTable autoDeleteRokad1 = PawnManagementClass.getAutoDeleteRokad();
      if (autoDeleteRokad1 == null || autoDeleteRokad1.Rows.Count <= 0)
        return;
      string str = autoDeleteRokad1.Rows[0]["autodeleteRokad"].ToString();
      if (str != "NEVER")
      {
        string rokadDate = PawnManagementClass.getRokadDate();
        DateTime dateTime;
        string s;
        if (rokadDate == "")
        {
          dateTime = DateTime.Now;
          s = dateTime.ToString("dd/MM/yyyy");
        }
        else
          s = DateTime.Parse(rokadDate).ToString("dd/MM/yyyy");
        if (str == "DAILY")
        {
          dateTime = DateTime.Parse(s);
          dateTime = dateTime.AddDays(-1.0);
          deleteRokadBefore = dateTime.ToString("dd/MM/yyyy");
        }
        if (str == "WEEKLY")
        {
          dateTime = DateTime.Parse(s);
          dateTime = dateTime.AddDays(-8.0);
          deleteRokadBefore = dateTime.ToString("dd/MM/yyyy");
        }
        if (str == "MONTHLY")
        {
          dateTime = DateTime.Parse(s);
          dateTime = dateTime.AddDays(-35.0);
          deleteRokadBefore = dateTime.ToString("dd/MM/yyyy");
        }
        DataTable autoDeleteRokad2 = PawnManagementClass.getAutoDeleteRokad();
        if (autoDeleteRokad2 != null && autoDeleteRokad2.Rows.Count > 0)
        {
          if (autoDeleteRokad2.Rows[0]["prompt"].ToString().Equals("Y"))
          {
            if (DialogResult.Yes == MessageBox.Show("Delete Rokad before " + deleteRokadBefore, "Delete Rokad", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              this.deleteFromtblVouchers(deleteRokadBefore);
              this.deleteFromtblRokadDetails(deleteRokadBefore);
            }
          }
          else
          {
            this.deleteFromtblVouchers(deleteRokadBefore);
            this.deleteFromtblRokadDetails(deleteRokadBefore);
          }
        }
      }
    }

    private void deleteFromtblVouchers(string deleteRokadBefore)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Delete from tblvouchers where voucherdate <= @voucherdate", new List<OleDbParameter>()
      {
        new OleDbParameter("voucherdate", (object) deleteRokadBefore)
      }, ref strError) == "Done"))
        return;
      this.slblAutoDeleteRokad.Text = "Rokad Successfullly Deleted till ." + deleteRokadBefore;
    }

    private void deleteFromtblRokadDetails(string deleteRokadBefore)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Delete from tblRokadDetails where RokadDate <= @voucherdate", new List<OleDbParameter>()
      {
        new OleDbParameter("voucherdate", (object) deleteRokadBefore)
      }, ref strError) == "Done"))
        return;
      this.slblAutoDeleteRokad.Text = "Rokad Successfullly Deleted till .. " + deleteRokadBefore;
    }

    private void autoBackUp()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBackUp";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
          PawnManagementClass.InsertIntoException("form main.autoBackUp", strError, FormMain.username, DateTime.Now.ToString());
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          string path = dataTable2.Rows[0].Field<string>("BackUpPath");
          if (Directory.Exists(path))
          {
            DateTime dateTime = DateTime.Parse(dataTable2.Rows[0].Field<string>("LastBackUpDate"));
            if (dataTable2.Rows[0].Field<string>("BackUpMode") == "DAILY")
            {
              DateTime now = DateTime.Now;
              if (now.Subtract(dateTime).Days > 0)
              {
                Directory.GetAccessControl(path).AddAccessRule(new FileSystemAccessRule((IdentityReference) new SecurityIdentifier(WellKnownSidType.WorldSid, (SecurityIdentifier) null), FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                if (Directory.Exists(path))
                {
                  string str = path;
                  now = DateTime.Now;
                  string longDateString = now.ToLongDateString();
                  Directory.CreateDirectory(str + longDateString);
                }
                string str1 = path;
                now = DateTime.Now;
                string longDateString1 = now.ToLongDateString();
                this.takeBackUp(str1 + "\\" + longDateString1 + "\\PawnManagement.accdb");
              }
              else
                this.slblAutoBackUp.Text = "Last  Database  Back up taken on " + dateTime.ToString("dd/MM/yyyy");
            }
            else if (dataTable2.Rows[0].Field<string>("BackUpMode") == "WEEKLY")
            {
              DateTime now = DateTime.Now;
              if (now.Subtract(dateTime).Days > 6)
              {
                if (Directory.Exists(path))
                {
                  string str = path;
                  now = DateTime.Now;
                  string longDateString = now.ToLongDateString();
                  Directory.CreateDirectory(str + longDateString);
                }
                string str2 = path;
                now = DateTime.Now;
                string longDateString2 = now.ToLongDateString();
                this.takeBackUp(str2 + "\\" + longDateString2 + "\\PawnManagement.accdb");
              }
              else
                this.slblAutoBackUp.Text = "Last Database  Back up taken on " + dateTime.ToString("dd/MM/yyyy");
            }
            else if (dataTable2.Rows[0].Field<string>("BackUpMode") == "MONTHLY")
            {
              DateTime now = DateTime.Now;
              if (now.Subtract(dateTime).Days > 30)
              {
                if (Directory.Exists(path))
                {
                  string str = path;
                  now = DateTime.Now;
                  string longDateString = now.ToLongDateString();
                  Directory.CreateDirectory(str + longDateString);
                }
                string str3 = path;
                now = DateTime.Now;
                string longDateString3 = now.ToLongDateString();
                this.takeBackUp(str3 + "\\" + longDateString3 + "\\PawnManagement.accdb");
              }
              else
                this.slblAutoBackUp.Text = " Last  Database Back up taken on " + dateTime.ToString("dd/MM/yyyy");
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show("Please change the autobackup path correctly");
            int num2 = (int) new FormAutoBackUp().ShowDialog();
          }
        }
        else if (DialogResult.Yes == MessageBox.Show("Auto BackUp has not been set...Do you want to set?", "AutoBackUp...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num = (int) new FormAutoBackUp().ShowDialog();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("FORM MAIN.autoBackUP", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void takeBackUp(string backUpPath)
    {
      if (File.Exists("PawnManagement.accdb"))
      {
        try
        {
          File.Copy("PawnManagement.accdb", backUpPath, true);
          string strError = "";
          string my_querry = "update tblBackUp set LastBackUpDate = @LastBackUpDate";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          List<OleDbParameter> oleDbParameterList = parameters;
          DateTime now = DateTime.Now;
          OleDbParameter oleDbParameter = new OleDbParameter("LastBackUpDate", (object) now.ToString("dd/MM/yyyy"));
          oleDbParameterList.Add(oleDbParameter);
          if (SQLHelper.RunCommand(my_querry, parameters, ref strError) != "Done")
          {
            string MessageAnDStackTrace = strError;
            string username = FormMain.username;
            now = DateTime.Now;
            string CreatedOn = now.ToString();
            PawnManagementClass.InsertIntoException("form main.takebackup inner exception", MessageAnDStackTrace, username, CreatedOn);
            int num = (int) MessageBox.Show("Error in Adding" + strError);
          }
          else
            this.slblAutoBackUp.Text = "Database backUp Successfull";
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form main.takeBackUp(string backUpPath)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Database missing");
      }
    }

    private void getMenuItems()
    {
      try
      {
        DataTable dataTable = MenuSettingsClass.gettblMenuSettings();
        if (dataTable == null || dataTable.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
          row["menuitems"] = (object) PawnManagementClass.decrypt(row["menuitems"].ToString());
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row["menuitems"].ToString()[0].ToString() == FormMain.memberid)
            this.menuitemsSelected.Add(row["menuitems"].ToString().Substring(1));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form main.getMenuItems()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewCustomerDetails viewCustomerDetails = new FormViewCustomerDetails();
      viewCustomerDetails.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewCustomerDetails))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      viewCustomerDetails.Show();
      viewCustomerDetails.WindowState = FormWindowState.Maximized;
    }

    private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (FormMain.addEditCustomerSetting)
      {
        case "SIMPLE":
          FormAddCustomer formAddCustomer = new FormAddCustomer();
          if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
          {
            if (FormMain.AutoOnfingerPrint)
              FormMain.m_FPM.EnableAutoOnEvent(true, (int) formAddCustomer.Handle);
            else
              FormMain.m_FPM.EnableAutoOnEvent(false, 0);
          }
          int num1 = (int) formAddCustomer.ShowDialog();
          break;
        case "ADVANCED":
          Form1 form1 = new Form1("ADD", "");
          if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
          {
            if (FormMain.AutoOnfingerPrint)
              FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
            else
              FormMain.m_FPM.EnableAutoOnEvent(false, 0);
          }
          int num2 = (int) form1.ShowDialog();
          break;
      }
    }

    private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (FormMain.addEditCustomerSetting)
      {
        case "SIMPLE":
          FormEditCustomer formEditCustomer = new FormEditCustomer();
          if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
          {
            if (FormMain.AutoOnfingerPrint)
              FormMain.m_FPM.EnableAutoOnEvent(true, (int) formEditCustomer.Handle);
            else
              FormMain.m_FPM.EnableAutoOnEvent(false, 0);
          }
          int num = (int) formEditCustomer.ShowDialog();
          break;
        case "ADVANCED":
          FormSearchCustomer formSearchCustomer = new FormSearchCustomer();
          formSearchCustomer.MdiParent = (Form) this;
          formSearchCustomer.Show();
          formSearchCustomer.WindowState = FormWindowState.Maximized;
          break;
      }
    }

    private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void shopDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void articlesToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormArticles formArticles = new FormArticles();
      formArticles.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == formArticles.GetType())
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formArticles.Show();
      formArticles.WindowState = FormWindowState.Maximized;
    }

    private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormSearchCustomer formSearchCustomer = new FormSearchCustomer();
      formSearchCustomer.MdiParent = (Form) this;
      formSearchCustomer.Show();
      formSearchCustomer.WindowState = FormWindowState.Maximized;
    }

    private void loginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new Form_Login_Details().ShowDialog();
    }

    private bool checkifpledgetableempty()
    {
      string strError = "";
      string my_querry = "select * from tblPledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form main.checkifpledgetableempty()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return false;
      return true;
    }

    private void pledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable shopDetailsTable = PawnManagementClass.getFullShopDetailsTable();
      if (shopDetailsTable != null && shopDetailsTable.Rows.Count > 0)
      {
        if (!PledgeClass.checkifpledgetableempty())
        {
          FormPledgePledge formPledgePledge = new FormPledgePledge("NEW PLEDGE");
          formPledgePledge.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormPledgePledge))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formPledgePledge.Show();
          formPledgePledge.WindowState = FormWindowState.Maximized;
        }
        else
        {
          FormPledgePledge formPledgePledge = new FormPledgePledge("OLD PLEDGE");
          formPledgePledge.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormPledgePledge))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formPledgePledge.Show();
          formPledgePledge.WindowState = FormWindowState.Maximized;
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Before beginning to create a pledge you need to create a SHOP...");
        FormShopDetailss formShopDetailss = new FormShopDetailss();
        formShopDetailss.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormShopDetailss))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formShopDetailss.Show();
        formShopDetailss.WindowState = FormWindowState.Maximized;
      }
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

    private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void customerPledgeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      if (FormMain.GetKeyState(20) != (short) 0)
        this.PressKeyboardButton(Keys.Capital);
      Application.Exit();
    }

    private void oldPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgePledge formPledgePledge = new FormPledgePledge("OLD PLEDGE");
      formPledgePledge.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgePledge))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgePledge.Show();
      formPledgePledge.WindowState = FormWindowState.Maximized;
    }

    private void redemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable shopDetailsTable = PawnManagementClass.getFullShopDetailsTable();
      if (shopDetailsTable != null && shopDetailsTable.Rows.Count > 0)
      {
        if (!PawnManagement.Classes.RedemptionClass.checkifRedemptionTableEmpty())
        {
          FormRedemption formRedemption = new FormRedemption("Redemption");
          formRedemption.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormRedemption))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formRedemption.Show();
          formRedemption.WindowState = FormWindowState.Maximized;
        }
        else
        {
          FormRedemption formRedemption = new FormRedemption("RedemptionOld");
          formRedemption.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormRedemption))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formRedemption.Show();
          formRedemption.WindowState = FormWindowState.Maximized;
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Before beginning to Release, you need to create a SHOP...");
        FormShopDetailss formShopDetailss = new FormShopDetailss();
        formShopDetailss.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormShopDetailss))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formShopDetailss.Show();
        formShopDetailss.WindowState = FormWindowState.Maximized;
      }
    }

    private void gramRateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormGramRate().ShowDialog();
    }

    private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void locationAndPincodeToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void locationAndPincodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormLocation formLocation = new FormLocation("");
      formLocation.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormLocation))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formLocation.Show();
      formLocation.WindowState = FormWindowState.Maximized;
    }

    private void noticeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormNoticeBasedOnPUreWeight basedOnPureWeight = new FormNoticeBasedOnPUreWeight();
      basedOnPureWeight.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormNoticeBasedOnPUreWeight))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      basedOnPureWeight.Show();
      basedOnPureWeight.WindowState = FormWindowState.Maximized;
    }

    private void pledgeEditToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable shopDetailsTable = PawnManagementClass.getFullShopDetailsTable();
      if (shopDetailsTable != null && shopDetailsTable.Rows.Count > 0)
      {
        if (!PledgeClass.checkifpledgetableempty())
        {
          FormPledgePledge formPledgePledge = new FormPledgePledge("PLEDGE EDIT");
          formPledgePledge.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormPledgePledge))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formPledgePledge.Show();
          formPledgePledge.WindowState = FormWindowState.Maximized;
        }
        else
        {
          int num = (int) MessageBox.Show("No Bills Have been entered.");
        }
      }
      else
      {
        FormShopDetailss formShopDetailss = new FormShopDetailss();
        formShopDetailss.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormShopDetailss))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formShopDetailss.Show();
        formShopDetailss.WindowState = FormWindowState.Maximized;
      }
    }

    private void form2ToolStripMenuItem_Click(object sender, EventArgs e) => new FormChangeToAes().Show();

    private void smsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void FormToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new Form().ShowDialog();
    }

    private void form4ToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private bool CheckForm(Form form)
    {
      form = Application.OpenForms[form.Name];
      return form != null && form.Name != "";
    }

    private void fORMD3ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormD3 formD3 = new FormD3();
      formD3.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormD3))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formD3.Show();
      formD3.WindowState = FormWindowState.Maximized;
    }

    private void tOKENSToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormToken formToken = new FormToken();
      formToken.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormToken))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formToken.Show();
      formToken.WindowState = FormWindowState.Maximized;
    }

    private void redemptionEditToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable shopDetailsTable = PawnManagementClass.getFullShopDetailsTable();
      if (shopDetailsTable != null && shopDetailsTable.Rows.Count > 0)
      {
        if (!PawnManagement.Classes.RedemptionClass.checkifRedemptionTableEmpty())
        {
          FormRedemption formRedemption = new FormRedemption("RedemptionEdit");
          formRedemption.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormRedemption))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formRedemption.Show();
          formRedemption.WindowState = FormWindowState.Maximized;
        }
        else
        {
          int num1 = (int) MessageBox.Show("None of the pledge bills are redeemed");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Before beginning to Release, you need to create a SHOP...");
        FormShopDetailss formShopDetailss = new FormShopDetailss();
        formShopDetailss.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormShopDetailss))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formShopDetailss.Show();
        formShopDetailss.WindowState = FormWindowState.Maximized;
      }
    }

    private void fORMCToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load("Reports\\\\DForms\\\\ReportFormC.rpt");
      FormCrystalReportViewer crystalReportViewer = new FormCrystalReportViewer(RD);
      crystalReportViewer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCrystalReportViewer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      crystalReportViewer.Show();
      crystalReportViewer.WindowState = FormWindowState.Maximized;
    }

    private void fORMDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load("Reports\\\\DForms\\\\ReportFormD.rpt");
      FormCrystalReportViewer crystalReportViewer = new FormCrystalReportViewer(RD);
      crystalReportViewer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCrystalReportViewer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      crystalReportViewer.Show();
      crystalReportViewer.WindowState = FormWindowState.Maximized;
    }

    private void bankMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormBankMaster formBankMaster = new FormBankMaster();
      formBankMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormBankMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formBankMaster.Show();
      formBankMaster.WindowState = FormWindowState.Maximized;
    }

    private void bankPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private bool getBankCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where Active = 1 and type = 'BANK'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form main.getbankCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving BankPledge" + strError);
          return false;
        }
        return dataTable2 != null && dataTable2.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form main.getBankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void bankReleaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private bool getBankPledge()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form BankRedemption main.getbankpledge", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void editEntryToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void redemptionEditToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void oldRedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DataTable shopDetailsTable = PawnManagementClass.getFullShopDetailsTable();
      if (shopDetailsTable != null && shopDetailsTable.Rows.Count > 0)
      {
        FormRedemption formRedemption = new FormRedemption("RedemptionOld");
        formRedemption.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormRedemption))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formRedemption.Show();
        formRedemption.WindowState = FormWindowState.Maximized;
      }
      else
      {
        int num = (int) MessageBox.Show("Before beginning to Release, you need to create a SHOP...");
        FormShopDetailss formShopDetailss = new FormShopDetailss();
        formShopDetailss.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormShopDetailss))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formShopDetailss.Show();
        formShopDetailss.WindowState = FormWindowState.Maximized;
      }
    }

    private void duplicateBillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDuplicateBill formDuplicateBill = new FormDuplicateBill();
      formDuplicateBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDuplicateBill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDuplicateBill.Show();
      formDuplicateBill.WindowState = FormWindowState.Maximized;
    }

    private void historyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormHistory formHistory = new FormHistory();
      formHistory.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormHistory))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formHistory.Show();
      formHistory.WindowState = FormWindowState.Maximized;
    }

    private void jewelPhotoToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void menuSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormMenusettin(this.menuitems).ShowDialog();
    }

    private void shopDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      int num = (int) new FormShopDetailss().ShowDialog();
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormReminder formReminder = new FormReminder();
      formReminder.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormReminder))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formReminder.Show();
      formReminder.WindowState = FormWindowState.Maximized;
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
      FormDashBoard formDashBoard = new FormDashBoard("Reminder");
      formDashBoard.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInLoss))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDashBoard.Show();
      formDashBoard.WindowState = FormWindowState.Maximized;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private void autoBackupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormAutoBackUp().ShowDialog();
    }

    private void billNumberSeriesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormPledgeAndRedemptionSeries().ShowDialog();
    }

    private void exceptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormException formException = new FormException();
      formException.WindowState = FormWindowState.Maximized;
      int num = (int) formException.ShowDialog();
    }

    private void calculatorToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("calc");

    private void historyReminderSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormHistoryReminderSettings().ShowDialog();
    }

    private void toolStripLabel2_Click(object sender, EventArgs e)
    {
    }

    private void homeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void hOMEToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormDashBoard formDashBoard = new FormDashBoard();
      formDashBoard.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInLoss))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDashBoard.Show();
      formDashBoard.WindowState = FormWindowState.Maximized;
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void jewelPhotoToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormJewelPhoto formJewelPhoto = new FormJewelPhoto();
      formJewelPhoto.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormJewelPhoto))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formJewelPhoto.Show();
      formJewelPhoto.WindowState = FormWindowState.Maximized;
    }

    private bool getKhathoCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where Active = 1 and type = 'KHAATHO'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form khatho.getbankCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving BankPledge" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          return true;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.getbankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return false;
    }

    private void khaathoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.getKhathoCode())
      {
        FormKhaatho formKhaatho = new FormKhaatho();
        formKhaatho.MdiParent = (Form) this;
        formKhaatho.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormKhaatho))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formKhaatho.Show();
        formKhaatho.WindowState = FormWindowState.Maximized;
      }
      else
      {
        int num = (int) MessageBox.Show("Create a khatho account before proceeding");
      }
    }

    private void viewKhaathoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormKhaathoReport formKhaathoReport = new FormKhaathoReport();
      formKhaathoReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormKhaathoReport))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formKhaathoReport.Show();
      formKhaathoReport.WindowState = FormWindowState.Maximized;
    }

    private void bankReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormBankReports formBankReports = new FormBankReports();
      formBankReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormBankReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formBankReports.Show();
      formBankReports.WindowState = FormWindowState.Maximized;
    }

    private void outsidePledgeListToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormJewelsOutside formJewelsOutside = new FormJewelsOutside();
      formJewelsOutside.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormJewelsOutside))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formJewelsOutside.Show();
      formJewelsOutside.WindowState = FormWindowState.Maximized;
    }

    private void auctionRedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormAuctionRedemption auctionRedemption = new FormAuctionRedemption(this.tscbShopCode.Text);
      auctionRedemption.Show();
      auctionRedemption.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormAuctionRedemption))
        {
          openForm.BringToFront();
          auctionRedemption.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      auctionRedemption.Show();
      auctionRedemption.WindowState = FormWindowState.Maximized;
    }

    private void pledgeReportsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void customerRemindersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerReminder customerReminder = new FormCustomerReminder();
      customerReminder.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerReminder))
        {
          openForm.BringToFront();
          customerReminder.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerReminder.Show();
      customerReminder.WindowState = FormWindowState.Maximized;
    }

    private void sendSmsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormSendSMS formSendSms = new FormSendSMS();
      formSendSms.MdiParent = (Form) this;
      if (!this.CheckForm((Form) formSendSms))
      {
        formSendSms.Show();
      }
      else
      {
        formSendSms.WindowState = FormWindowState.Normal;
        formSendSms.BringToFront();
        formSendSms.Activate();
      }
    }

    private void smsMessagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormSmsMessages formSmsMessages = new FormSmsMessages();
      formSmsMessages.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormSmsMessages))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formSmsMessages.Show();
      formSmsMessages.WindowState = FormWindowState.Maximized;
    }

    private void menuStrip1_MouseEnter(object sender, EventArgs e) => this.menuStrip1.ForeColor = Color.Black;

    private void numberOfBillsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void numberOfBillsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void numberOfBillsToolStripMenuItem2_Click(object sender, EventArgs e)
    {
    }

    private void customersNotComingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerNotComing customerNotComing = new FormCustomerNotComing();
      customerNotComing.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerNotComing))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerNotComing.Show();
      customerNotComing.WindowState = FormWindowState.Maximized;
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      FormCustomerStreetReport customerStreetReport = new FormCustomerStreetReport();
      customerStreetReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerStreetReport))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerStreetReport.Show();
      customerStreetReport.WindowState = FormWindowState.Maximized;
    }

    private void regularCustomersWhoAreNotComingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerRegualrNotComing regualrNotComing = new FormCustomerRegualrNotComing();
      regualrNotComing.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerRegualrNotComing))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      regualrNotComing.Show();
      regualrNotComing.WindowState = FormWindowState.Maximized;
    }

    private void customerGoodOrBadToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void form1ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void noOfBillsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void ledgerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormLedgerDetails formLedgerDetails = new FormLedgerDetails();
      formLedgerDetails.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormLedgerDetails))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formLedgerDetails.Show();
      formLedgerDetails.WindowState = FormWindowState.Maximized;
    }

    private void pledgeAmountSummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void voucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormVoucher formVoucher = new FormVoucher("ADDVOUCHER", "");
      formVoucher.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormVoucher))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formVoucher.Show();
      formVoucher.WindowState = FormWindowState.Maximized;
    }

    private void voucherMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormVoucherMaster formVoucherMaster = new FormVoucherMaster();
      formVoucherMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormVoucherMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formVoucherMaster.Show();
      formVoucherMaster.WindowState = FormWindowState.Maximized;
    }

    private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
    {
      FormRokadDateSelect formRokadDateSelect = new FormRokadDateSelect();
      formRokadDateSelect.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRokadDateSelect))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formRokadDateSelect.Show();
      formRokadDateSelect.WindowState = FormWindowState.Maximized;
    }

    private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
    {
      string rokadDate = PawnManagementClass.getRokadDate();
      DateTime now;
      if (rokadDate == "")
      {
        now = DateTime.Now;
        rokadDate = now.ToString("dd/MM/yyyy");
      }
      now = DateTime.Parse(rokadDate);
      FormCashBook formCashBook = new FormCashBook(now.ToString("dd/MM/yyyy"));
      formCashBook.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == formCashBook.GetType())
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formCashBook.Show();
      formCashBook.WindowState = FormWindowState.Maximized;
    }

    private void rokadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRokad formRokad = new FormRokad(DateTime.Parse((!(PawnManagementClass.getRokadDate() != "") ? (object) DateTime.Now.ToString("dd/MM/yyyy") : (object) PawnManagementClass.getRokadDate()).ToString()), "currentDay");
      formRokad.WindowState = FormWindowState.Maximized;
      int num = (int) formRokad.ShowDialog();
    }

    private void changeRokadDateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormChangeRokadDate().ShowDialog();
    }

    private void autoDeleteRokadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormRokadAutoDelete().ShowDialog();
    }

    private void rokadReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRokadReports formRokadReports = new FormRokadReports();
      formRokadReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRokadReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formRokadReports.Show();
      formRokadReports.WindowState = FormWindowState.Maximized;
    }

    private void pledgeInLossToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void redemptionReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void viewSentMessagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewSentMessages viewSentMessages = new FormViewSentMessages();
      viewSentMessages.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewSentMessages))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      viewSentMessages.Show();
      viewSentMessages.WindowState = FormWindowState.Maximized;
    }

    private void numberOfBillsConsolidatedToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void customersInterestSummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerInterestSummary customerInterestSummary = new FormCustomerInterestSummary();
      customerInterestSummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerInterestSummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerInterestSummary.Show();
      customerInterestSummary.WindowState = FormWindowState.Maximized;
    }

    private void redemptionINTERESTMonthlySummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void pledgeAmountSummaryYearlyToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void redemptionInterestMonthlySummaryToolStripMenuItem1_Click(
      object sender,
      EventArgs e)
    {
    }

    private void redemptionINTERESTMonthlySummaryToolStripMenuItem2_Click(
      object sender,
      EventArgs e)
    {
    }

    private void numberOfBillsConsolidatedToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void auctionReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormAuctionReports formAuctionReports = new FormAuctionReports();
      formAuctionReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormAuctionReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formAuctionReports.Show();
      formAuctionReports.WindowState = FormWindowState.Maximized;
    }

    private void notepadToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("notepad.exe");

    private void printRokadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPrintRokad formPrintRokad = new FormPrintRokad();
      formPrintRokad.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPrintRokad))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPrintRokad.Show();
      formPrintRokad.WindowState = FormWindowState.Maximized;
    }

    private void pledgeReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormAboutBox().ShowDialog();
    }

    private void pledgeReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeReports formPledgeReports = new FormPledgeReports();
      formPledgeReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeReports.Show();
      formPledgeReports.WindowState = FormWindowState.Maximized;
    }

    private void pledgeReportTodayToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeReports formPledgeReports = new FormPledgeReports("today");
      formPledgeReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeReports.Show();
      formPledgeReports.WindowState = FormWindowState.Maximized;
    }

    private void bankOldPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void rokadReportsConsolidatedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRokadReportsConsolidated reportsConsolidated = new FormRokadReportsConsolidated();
      reportsConsolidated.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRokadReportsConsolidated))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      reportsConsolidated.Show();
      reportsConsolidated.WindowState = FormWindowState.Maximized;
    }

    private void aboutToolStripMenuItem_DoubleClick(object sender, EventArgs e)
    {
    }

    private void timer1_Tick_1(object sender, EventArgs e) => this.tsslblCurrentDate.Text = DateTime.Now.ToString();

    private void inactivityMonitorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormInactivityMonitor().ShowDialog();
    }

    private void changeBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
        openFileDialog.Title = "Select the picture";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        if (openFileDialog.CheckFileExists)
        {
          string str = FormMain.startUpPath + "Photos\\Login\\" + openFileDialog.SafeFileName + ".png";
          this.insertPictureBoxPath(str);
          File.Copy(openFileDialog.FileName, str, true);
          string empty = string.Empty;
          this.getPicture();
        }
        else
        {
          int num = (int) MessageBox.Show("file does not exist");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form login.changeImaggeToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void insertPictureBoxPath(string filePath)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("update tblsettings set MainScreenPictureBoxPath = @path where SerialNumber = 1 ", new List<OleDbParameter>()
      {
        new OleDbParameter("path", (object) filePath)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Main.insertpictureboxpath", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in insertingg the image path" + strError);
      }
      else if (str == "done")
      {
        int num1 = (int) MessageBox.Show("successfully changed");
      }
    }

    private void getPicture()
    {
      string empty = string.Empty;
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select  * from tblsettings", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form main.getpicture", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the picturebox path");
      }
      else
      {
        try
        {
          string path = dataTable.Rows[0].Field<string>("MainScreenPictureBoxPath");
          if (File.Exists(path))
          {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
              this.BackgroundImage = Image.FromStream((Stream) fileStream);
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form main.getpicture second exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\b')
        this.adminPassword = "";
      else
        this.adminPassword += e.KeyChar.ToString();
    }

    private void encryptionToolStripMenuItem_Click(object sender, EventArgs e) => new formEncryptionDecryption().Show();

    private void deletePledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void deleteSinglePledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void deleteManyPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void removeDuplicateCustomersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDeleteDuplicateCustomer duplicateCustomer = new FormDeleteDuplicateCustomer();
      duplicateCustomer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDeleteDuplicateCustomer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      duplicateCustomer.Show();
      duplicateCustomer.WindowState = FormWindowState.Maximized;
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormReminder().ShowDialog();
    }

    private void PressKeyboardButton(Keys keyCode)
    {
      FormMain.keybd_event((byte) keyCode, (byte) 69, 1U, 0);
      FormMain.keybd_event((byte) keyCode, (byte) 69, 3U, 0);
    }

    private void changeInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormChangeInterest().ShowDialog();
    }

    private void pledgeInterestReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeInterest formPledgeInterest = new FormPledgeInterest();
      formPledgeInterest.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInterest))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeInterest.Show();
      formPledgeInterest.WindowState = FormWindowState.Maximized;
    }

    private void completeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCompleteSummary formCompleteSummary = new FormCompleteSummary();
      formCompleteSummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInterest))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formCompleteSummary.Show();
      formCompleteSummary.WindowState = FormWindowState.Maximized;
    }

    private void printLedgerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormLedger formLedger = new FormLedger();
      formLedger.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormLedger))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formLedger.Show();
      formLedger.WindowState = FormWindowState.Maximized;
    }

    private void pledgeBookToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormLedgerBook formLedgerBook = new FormLedgerBook();
      formLedgerBook.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormLedgerBook))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formLedgerBook.Show();
      formLedgerBook.WindowState = FormWindowState.Maximized;
    }

    private void udhrathToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void pendingInterestReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPendingInterestReports pendingInterestReports = new FormPendingInterestReports();
      pendingInterestReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPendingInterestReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      pendingInterestReports.Show();
      pendingInterestReports.WindowState = FormWindowState.Maximized;
    }

    private void partPaymentToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void partPaymentReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPartPaymentReports partPaymentReports = new FormPartPaymentReports();
      partPaymentReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPendingInterestReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      partPaymentReports.Show();
      partPaymentReports.WindowState = FormWindowState.Maximized;
    }

    private void partPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormPartPayment formPartPayment = new FormPartPayment("New");
      formPartPayment.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPartPayment))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPartPayment.Show();
      formPartPayment.WindowState = FormWindowState.Maximized;
    }

    private void partPaymentOldEntryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPartPayment formPartPayment = new FormPartPayment("Old");
      formPartPayment.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPartPayment))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPartPayment.Show();
      formPartPayment.WindowState = FormWindowState.Maximized;
    }

    private void jewelsReleasedButStillInBankToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void denominationToolStripMenuItem_Click(object sender, EventArgs e) => new FormMoneyCalculator().Show();

    private void removeDuplicateAddressToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormReplaceDuplicateAddress duplicateAddress = new FormReplaceDuplicateAddress();
      duplicateAddress.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormReplaceDuplicateAddress))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      duplicateAddress.Show();
      duplicateAddress.WindowState = FormWindowState.Maximized;
    }

    private void basedOnNetWeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeInLoss formPledgeInLoss = new FormPledgeInLoss();
      formPledgeInLoss.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInLoss))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeInLoss.Show();
      formPledgeInLoss.WindowState = FormWindowState.Maximized;
    }

    private void basedOnPureWeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeInLossBasedOnPureWeighttt basedOnPureWeighttt = new FormPledgeInLossBasedOnPureWeighttt();
      basedOnPureWeighttt.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeInLossBasedOnPureWeighttt))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      basedOnPureWeighttt.Show();
      basedOnPureWeighttt.WindowState = FormWindowState.Maximized;
    }

    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private string getPledgeBillNumber()
    {
      if (!this.checkifpledgetableempty())
      {
        string str1 = "'" + PawnManagementClass.getPledgeBillNumberSeries(PawnManagementClass.getDefaultLicenseCode()) + "%'";
        string strError = "";
        string my_querry = "select max(BillNumber) as BillNumber from tblPledge where BillNumber like " + str1;
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
        }
        if (dataTable2 != null && dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "")
        {
          try
          {
            string str2 = dataTable2.Rows[0].Field<string>("BillNumber");
            char ch = str2[0];
            int num = int.Parse(str2.Substring(1));
            if (num < 10)
              return ch.ToString() + "0000" + num.ToString();
            if (num < 100)
              return ch.ToString() + "000" + num.ToString();
            if (num < 1000)
              return ch.ToString() + "00" + num.ToString();
            return num < 10000 ? ch.ToString() + "0" + num.ToString() : ch.ToString() + num.ToString();
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form Plege.getPledgeBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Database empty..  . try oldPledge first");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Database empty..  . try oldPledge first");
      }
      return "";
    }

    private void changeOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormChangeOpeningBalancee().ShowDialog();
    }

    private void articlesSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormArticlesSetting().ShowDialog();
    }

    private void pledgeExpiringTodayToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeReports formPledgeReports = new FormPledgeReports("PLEDGEEXPIRINGTODAY");
      formPledgeReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeReports.Show();
      formPledgeReports.WindowState = FormWindowState.Maximized;
    }

    private void pledgeExpiringThisMonthToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPledgeReports formPledgeReports = new FormPledgeReports("PLEDGEEXPIRINGTHISMONTH");
      formPledgeReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeReports.Show();
      formPledgeReports.WindowState = FormWindowState.Maximized;
    }

    private void viewPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewPledgeBill formViewPledgeBill = new FormViewPledgeBill();
      formViewPledgeBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewPledgeBill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formViewPledgeBill.Show();
      formViewPledgeBill.WindowState = FormWindowState.Maximized;
    }

    private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPrintSettings formPrintSettings = new FormPrintSettings();
      formPrintSettings.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPrintSettings))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPrintSettings.Show();
      formPrintSettings.WindowState = FormWindowState.Maximized;
    }

    private void tscbShopCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void stockMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void stockCheckToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PawnManagement.Forms.FormStockCheck formStockCheck = new PawnManagement.Forms.FormStockCheck();
      formStockCheck.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (PawnManagement.Forms.FormStockCheck))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formStockCheck.Show();
      formStockCheck.WindowState = FormWindowState.Maximized;
    }

    private void manageStockToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormStockMaster formStockMaster = new FormStockMaster();
      formStockMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (PawnManagement.Forms.FormStockCheck))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formStockMaster.Show();
      formStockMaster.WindowState = FormWindowState.Maximized;
    }

    private void deleteRedemptionTillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDeleteRedemptionTill deleteRedemptionTill = new FormDeleteRedemptionTill();
      deleteRedemptionTill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDeleteRedemptionTill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      deleteRedemptionTill.Show();
      deleteRedemptionTill.WindowState = FormWindowState.Maximized;
    }

    private void numberOfBillsToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      FormNumberOfPledgeBills numberOfPledgeBills = new FormNumberOfPledgeBills();
      numberOfPledgeBills.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormNumberOfPledgeBills))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      numberOfPledgeBills.Show();
      numberOfPledgeBills.WindowState = FormWindowState.Maximized;
    }

    private void numberOfBillsConsolidatedToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      FormNumberOfPledgeBillsConsolidated billsConsolidated = new FormNumberOfPledgeBillsConsolidated();
      billsConsolidated.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormNumberOfPledgeBillsConsolidated))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      billsConsolidated.Show();
      billsConsolidated.WindowState = FormWindowState.Maximized;
    }

    private void pledgeAmountSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormPledgeAmountSummary pledgeAmountSummary = new FormPledgeAmountSummary();
      pledgeAmountSummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeAmountSummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      pledgeAmountSummary.Show();
      pledgeAmountSummary.WindowState = FormWindowState.Maximized;
    }

    private void pledgeAmountSummaryYearlyToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormPledgeAmountSummaryYearly amountSummaryYearly = new FormPledgeAmountSummaryYearly();
      amountSummaryYearly.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeAmountSummaryYearly))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      amountSummaryYearly.Show();
      amountSummaryYearly.WindowState = FormWindowState.Maximized;
    }

    private void numberOfBillsToolStripMenuItem3_Click(object sender, EventArgs e)
    {
      FormNumberOfRedemptionBills ofRedemptionBills = new FormNumberOfRedemptionBills();
      ofRedemptionBills.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormNumberOfRedemptionBills))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      ofRedemptionBills.Show();
      ofRedemptionBills.WindowState = FormWindowState.Maximized;
    }

    private void numberOfBillsConsolidatedToolStripMenuItem3_Click(object sender, EventArgs e)
    {
      FormNumberOfRedemptionBillsConsolidated billsConsolidated = new FormNumberOfRedemptionBillsConsolidated();
      billsConsolidated.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeAmountSummaryYearly))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      billsConsolidated.Show();
      billsConsolidated.WindowState = FormWindowState.Maximized;
    }

    private void redemptionInterestYearlySummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRedemptionInterestYearlySummary interestYearlySummary = new FormRedemptionInterestYearlySummary();
      interestYearlySummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionInterestYearlySummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      interestYearlySummary.Show();
      interestYearlySummary.WindowState = FormWindowState.Maximized;
    }

    private void redemptionInterestMonthlySummaryToolStripMenuItem3_Click(
      object sender,
      EventArgs e)
    {
      FormRedemptionInterestMonthlySummary interestMonthlySummary = new FormRedemptionInterestMonthlySummary();
      interestMonthlySummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionInterestMonthlySummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      interestMonthlySummary.Show();
      interestMonthlySummary.WindowState = FormWindowState.Maximized;
    }

    private void redemptionINTERESTYearlySummaryToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormRedemptionINTEREST16YearlySummary t16YearlySummary = new FormRedemptionINTEREST16YearlySummary();
      t16YearlySummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionINTEREST16YearlySummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      t16YearlySummary.Show();
      t16YearlySummary.WindowState = FormWindowState.Maximized;
    }

    private void redemptionINTERESTMonthlySummaryToolStripMenuItem2_Click_1(
      object sender,
      EventArgs e)
    {
      FormRedemptionINTEREST16MonthlySummary t16MonthlySummary = new FormRedemptionINTEREST16MonthlySummary();
      t16MonthlySummary.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionINTEREST16MonthlySummary))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      t16MonthlySummary.Show();
      t16MonthlySummary.WindowState = FormWindowState.Maximized;
    }

    private void redemptionReportsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormRedemptionReports redemptionReports = new FormRedemptionReports("");
      redemptionReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      redemptionReports.Show();
      redemptionReports.WindowState = FormWindowState.Maximized;
    }

    private void redemptionReportsTodayToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRedemptionReports redemptionReports = new FormRedemptionReports("TODAY");
      redemptionReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      redemptionReports.Show();
      redemptionReports.WindowState = FormWindowState.Maximized;
    }

    private void viewRedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewRedemption formViewRedemption = new FormViewRedemption();
      formViewRedemption.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewRedemption))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formViewRedemption.Show();
      formViewRedemption.WindowState = FormWindowState.Maximized;
    }

    private void duplicateRedemptionBillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDuplicateRedemptionBill duplicateRedemptionBill = new FormDuplicateRedemptionBill();
      duplicateRedemptionBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDuplicateRedemptionBill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      duplicateRedemptionBill.Show();
      duplicateRedemptionBill.WindowState = FormWindowState.Maximized;
    }

    private void dayReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDayReport formDayReport = new FormDayReport(DateTime.Now.ToShortDateString());
      formDayReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDayReport))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDayReport.Show();
      formDayReport.WindowState = FormWindowState.Maximized;
    }

    private void reportBetweenDaysToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDayReport formDayReport = new FormDayReport("", "");
      formDayReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDayReport))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDayReport.Show();
      formDayReport.WindowState = FormWindowState.Maximized;
    }

    private void changeABillFromOneLicenseToOtherToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormChangeShopCode formChangeShopCode = new FormChangeShopCode();
      formChangeShopCode.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormChangeShopCode))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formChangeShopCode.Show();
      formChangeShopCode.WindowState = FormWindowState.Maximized;
    }

    private void jewelsReleasedButStillInBankToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormErrorsJewelsReleasedButStillInBank releasedButStillInBank = new FormErrorsJewelsReleasedButStillInBank();
      releasedButStillInBank.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPartPayment))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      releasedButStillInBank.Show();
      releasedButStillInBank.WindowState = FormWindowState.Maximized;
    }

    private void billerMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormBiller().ShowDialog();
    }

    private void tscbBillerName_TextChanged(object sender, EventArgs e) => FormMain.BillerName = this.tscbBillerName.Text.Trim();

    private void tscbBillerName_Validating(object sender, CancelEventArgs e)
    {
      if (this.tscbBillerName.Items.Contains((object) this.tscbBillerName.Text))
        return;
      this.tscbBillerName.Select();
      this.tscbBillerName.Focus();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      FormPrintSettings formPrintSettings = new FormPrintSettings();
      formPrintSettings.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPrintSettings))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPrintSettings.Show();
      formPrintSettings.WindowState = FormWindowState.Maximized;
    }

    private void tstbBillingDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as ToolStripTextBox).Text))
        return;
      if (DateTime.Parse((sender as ToolStripTextBox).Text).Subtract(DateTime.Now).Days != 0)
        this.tstbBillingDate.ForeColor = Color.Red;
      else
        this.tstbBillingDate.ForeColor = Color.Black;
    }

    private void pendingGirviTotalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormPendingGirviTotal().ShowDialog();
    }

    private void toolStripButton3_Click(object sender, EventArgs e) => Process.Start("calc");

    private void toolStripButton4_Click(object sender, EventArgs e) => Process.Start("notepad.exe");

    private void toolStripButton5_Click(object sender, EventArgs e)
    {
      int num = (int) new FormListOfPrinters().ShowDialog();
    }

    private void toolStripButton6_Click(object sender, EventArgs e) => Process.Start("WinWord.exe");

    private void toolStripButton7_Click(object sender, EventArgs e)
    {
      PawnManagement.JewelleryForms.FormDuplicateBill formDuplicateBill = new PawnManagement.JewelleryForms.FormDuplicateBill();
      formDuplicateBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDuplicateBill.Show();
      formDuplicateBill.WindowState = FormWindowState.Maximized;
    }

    private void toolStripButton8_Click(object sender, EventArgs e) => Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "control.exe"), "/name Microsoft.DevicesAndPrinters");

    private void toolStripButton9_Click(object sender, EventArgs e) => new FormMoneyCalculator().Show();

    private void stockCheckToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      PawnManagement.Testing.FormStockCheck formStockCheck = new PawnManagement.Testing.FormStockCheck();
      formStockCheck.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (PawnManagement.Testing.FormStockCheck))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formStockCheck.Show();
      formStockCheck.WindowState = FormWindowState.Maximized;
    }

    private void tscbBillerName_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void reBillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormReBill formReBill = new FormReBill(this.tscbShopCode.Text, DateTime.Parse(this.tstbBillingDate.Text));
      formReBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemption))
        {
          openForm.Close();
          break;
        }
      }
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormReBill))
        {
          openForm.Close();
          break;
        }
      }
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormReBill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formReBill.Show();
    }

    private void findCustomersWithSamePhoneNumberToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomersWithDuplicatePhoneNumbers duplicatePhoneNumbers = new FormCustomersWithDuplicatePhoneNumbers();
      duplicatePhoneNumbers.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomersWithDuplicatePhoneNumbers))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      duplicatePhoneNumbers.Show();
      duplicatePhoneNumbers.WindowState = FormWindowState.Maximized;
    }

    private void iNTERESTSETTINGToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormInterestDummy().ShowDialog();
    }

    private void interestSettingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormInterest().ShowDialog();
    }

    private void interestSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormInterestSetting().ShowDialog();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      string strError = "";
      string my_querry = "select * from tblReminder where (ReminderDate = @ReminderDate and ReminderType = 'onetime') or (ReminderType = @ReminderTypeWeekly) or (ReminderType = @ReminderTypeMonthly  and ReminderTypeValue = @ReminderTypeValueMonthly) or(ReminderType = @ReminderTypeYearly  and ReminderTypeValue = @ReminderTypeValueYearly)";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("ReminderDate", (object) DateTime.Now.ToString("dd/MM/yyyy")));
      parameters.Add(new OleDbParameter("ReminderTypeWeekly", (object) DateTime.Now.DayOfWeek.ToString()));
      parameters.Add(new OleDbParameter("ReminderTypeMonthly", (object) "monthly"));
      parameters.Add(new OleDbParameter("ReminderTypeValueMonthly", (object) DateTime.Now.Day.ToString()));
      parameters.Add(new OleDbParameter("ReminderTypeValueYearly", (object) "yearly"));
      List<OleDbParameter> oleDbParameterList = parameters;
      int num = DateTime.Now.Day;
      string str1 = num.ToString();
      num = DateTime.Now.Month;
      string str2 = num.ToString();
      OleDbParameter oleDbParameter = new OleDbParameter("ReminderTypeValueYearly", (object) (str1 + "," + str2));
      oleDbParameterList.Add(oleDbParameter);
      this.dtReminder = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      e.Result = (object) this.dtReminder;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        if (e.Result is DataTable result && result.Rows.Count > 0)
          this.tslRemiinder.ForeColor = Color.Red;
        foreach (DataRow row in (InternalDataCollectionBase) result.Rows)
          this.tslRemiinder.Text = this.tslRemiinder.Text + " " + row["Reminder"].ToString();
      }
      else if (!(e.Result is Exception))
        ;
      this.getShopCodes();
      if (this.tscbShopCode.Items.Count > 0)
        this.tscbShopCode.SelectedIndex = 0;
      this.tscbShopCode.Text = PawnManagementClass.getDefaultLicenseCode();
      string rokadDate = PawnManagementClass.getRokadDate();
      DateTime now;
      if (rokadDate == "")
      {
        now = DateTime.Now;
        rokadDate = now.ToString("dd/MM/yyyy");
      }
      now = DateTime.Parse(rokadDate);
      this.slblRokadDate.Text = "Rokad Date: " + now.ToString("dd/MM/yyyy");
      FormMain.BillNumberSeries = PawnManagementClass.getBillNumberSEriesSEttings();
      this.getBillerNames();
      string defaultValue = BillerClass.getDefaultValue();
      if (defaultValue == "")
      {
        if (this.tscbBillerName.Items.Count > 0)
          this.tscbBillerName.SelectedIndex = 0;
      }
      else
        this.tscbBillerName.Text = defaultValue;
      this.autoBackUp();
      this.autoDeleteRokad();
      if (PawnManagementClass.getRokadAutoEntrySettings())
      {
        this.tslAutoEntryRokad.Text = "";
      }
      else
      {
        this.tslAutoEntryRokad.Text = "Auto Entry Rokad is OFF";
        this.tslAutoEntryRokad.ForeColor = Color.Red;
      }
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblMonitor", ref strError);
      if (!(strError != "") && dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["inactivity"].ToString() == "ON")
      {
        IInactivityMonitor instance = MonitorCreator.CreateInstance((Control) this, MonitorType.LastInputMonitor);
        instance.Interval = double.Parse(dataTable.Rows[0]["monitorInterval"].ToString());
        instance.Elapsed += new ElapsedEventHandler(this.im_Elapsed);
        instance.SynchronizingObject = (ISynchronizeInvoke) this;
        instance.Enabled = true;
      }
      if (FormMain.GetKeyState(20) == (short) 0)
        this.PressKeyboardButton(Keys.Capital);
      if (FormMain.GetKeyState(144) == (short) 0)
        this.PressKeyboardButton(Keys.NumLock);
      FormMain.HideLicense = "true";
      ToolStripTextBox tstbBillingDate = this.tstbBillingDate;
      now = DateTime.Now;
      string shortDateString = now.ToShortDateString();
      tstbBillingDate.Text = shortDateString;
      string text = this.tstbBillingDate.Text;
      this.pledgeReport(text);
      this.redemptionReport(text);
    }

    private void tesingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormTextlocal().ShowDialog();
    }

    private void deletePledgeToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      FormDeletePledge formDeletePledge = new FormDeletePledge(this.tscbShopCode.Text);
      formDeletePledge.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerPendingGirviList))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDeletePledge.Show();
      formDeletePledge.WindowState = FormWindowState.Maximized;
    }

    private void itemsNamesMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormItemNamesMaster formItemNamesMaster = new FormItemNamesMaster();
      formItemNamesMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormItemNamesMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formItemNamesMaster.Show();
      formItemNamesMaster.WindowState = FormWindowState.Maximized;
    }

    private void itemTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormItemTypeMaster formItemTypeMaster = new FormItemTypeMaster();
      formItemTypeMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormItemTypeMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formItemTypeMaster.Show();
      formItemTypeMaster.WindowState = FormWindowState.Maximized;
    }

    private void tsmIUndoRedemption_Click(object sender, EventArgs e)
    {
      FormUndoRedemption formUndoRedemption = new FormUndoRedemption();
      formUndoRedemption.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormUndoRedemption))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formUndoRedemption.Show();
      formUndoRedemption.WindowState = FormWindowState.Maximized;
    }

    private void form2ToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      int num = (int) new Form6().ShowDialog();
    }

    private void metalMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormMetalMaster formMetalMaster = new FormMetalMaster();
      formMetalMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormMetalMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formMetalMaster.Show();
      formMetalMaster.WindowState = FormWindowState.Maximized;
    }

    private void purityMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormPurityMaster formPurityMaster = new FormPurityMaster();
      formPurityMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPurityMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPurityMaster.Show();
      formPurityMaster.WindowState = FormWindowState.Maximized;
    }

    private void bankNewPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.getBankCode())
      {
        FormBankPledgee formBankPledgee = new FormBankPledgee("pledge");
        formBankPledgee.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormBankPledgee))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formBankPledgee.Show();
        formBankPledgee.WindowState = FormWindowState.Maximized;
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please create a bank master entry before proceeding");
        if (DialogResult.Yes == MessageBox.Show("Do you want to create Bank Entry", "Create Bank master", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num2 = (int) new FormBankMaster().ShowDialog();
        }
      }
    }

    private void oldPledgeToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (this.getBankCode())
      {
        FormBankPledgee formBankPledgee = new FormBankPledgee("oldpledge");
        formBankPledgee.MdiParent = (Form) this;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormBankPledgee))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        formBankPledgee.Show();
        formBankPledgee.WindowState = FormWindowState.Maximized;
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please create a bank master entry before proceeding");
        if (DialogResult.Yes == MessageBox.Show("Do you want to create Bank Entry", "Create Bank master", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num2 = (int) new FormBankMaster().ShowDialog();
        }
      }
    }

    private void bankPledgeEditToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      FormBankPledgee formBankPledgee = new FormBankPledgee("PledgeEdit");
      formBankPledgee.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormBankPledgee))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formBankPledgee.Show();
      formBankPledgee.WindowState = FormWindowState.Maximized;
    }

    private void bankReleaseToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (this.getBankCode())
      {
        if (this.getBankPledge())
        {
          FormBankRedemption formBankRedemption = new FormBankRedemption("Redemption");
          formBankRedemption.MdiParent = (Form) this;
          foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
          {
            if (openForm.GetType() == typeof (FormBankRedemption))
            {
              openForm.BringToFront();
              openForm.WindowState = FormWindowState.Maximized;
              return;
            }
          }
          formBankRedemption.Show();
          formBankRedemption.WindowState = FormWindowState.Maximized;
        }
        else
        {
          int num1 = (int) MessageBox.Show("You cannot release any bills...No Bank pledge Bills exist");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Bank Master not created");
      }
    }

    private void undoRedemptionToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormBankPledgee("UndoRedemption").ShowDialog();
    }

    private void bankReleaseEditToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormBankRedemption formBankRedemption = new FormBankRedemption("RedemptionEdit");
      formBankRedemption.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormBankRedemption))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formBankRedemption.Show();
      formBankRedemption.WindowState = FormWindowState.Maximized;
    }

    private void formPLEDGEEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PawnManagement.a.FormPledgePledge formPledgePledge = new PawnManagement.a.FormPledgePledge("NEW PLEDGE");
      formPledgePledge.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (PawnManagement.a.FormPledgePledge))
        {
          openForm.BringToFront();
          return;
        }
      }
      formPledgePledge.Show();
    }

    private void customersLocationReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerLocationReport customerLocationReport = new FormCustomerLocationReport();
      customerLocationReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerLocationReport))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerLocationReport.Show();
      customerLocationReport.WindowState = FormWindowState.Maximized;
    }

    private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormNewSales().ShowDialog();
    }

    private void billNumberSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormBillNumberSetting().ShowDialog();
    }

    private void emailToolStripMenuItem_Click(object sender, EventArgs e) => new FormEmail().Show();

    private void hELLOToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Scannerapplication.Form1 form1 = new Scannerapplication.Form1();
      form1.MdiParent = (Form) this;
      form1.Show();
    }

    private void newAaddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form1 form1 = new Form1("ADD", "");
      if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
      {
        if (FormMain.AutoOnfingerPrint)
          FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
        else
          FormMain.m_FPM.EnableAutoOnEvent(false, 0);
      }
      int num = (int) form1.ShowDialog();
    }

    private void FormMain_MdiChildActivate(object sender, EventArgs e)
    {
    }

    private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e) => ((sender as Form).Tag as TabPage).Dispose();

    private void form4ToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
    }

    private void toolStripButton10_Click(object sender, EventArgs e)
    {
      FormPrintSettings formPrintSettings = new FormPrintSettings();
      formPrintSettings.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPrintSettings))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPrintSettings.Show();
      formPrintSettings.WindowState = FormWindowState.Maximized;
    }

    private void toolStripButton11_Click(object sender, EventArgs e) => Process.Start("calc");

    private void toolStripButton12_Click(object sender, EventArgs e) => Process.Start("notepad.exe");

    private void toolStripButton17_Click(object sender, EventArgs e) => Process.Start("Excel.exe");

    private void toolStripButton16_Click(object sender, EventArgs e) => Process.Start("WinWord.exe");

    private void toolStripButton15_Click(object sender, EventArgs e) => Process.Start("Mspaint.exe");

    private void toolStripButton14_Click(object sender, EventArgs e)
    {
      ProcessStartInfo processStartInfo = new ProcessStartInfo(FormMain.startUpPath + "dap.bat", "control printers");
      new Process() { StartInfo = processStartInfo }.Start();
    }

    private void toolStripButton13_Click(object sender, EventArgs e) => new FormMoneyCalculator().Show();

    private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
    {
      int num = (int) new FormPledgeReports().ShowDialog();
    }

    private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormSalesReport().ShowDialog();
    }

    private void form9ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PawnManagement.JewelleryForms.FormDuplicateBill formDuplicateBill = new PawnManagement.JewelleryForms.FormDuplicateBill();
      formDuplicateBill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDuplicateBill.Show();
      formDuplicateBill.WindowState = FormWindowState.Maximized;
    }

    private void toolStripButton18_Click(object sender, EventArgs e)
    {
      FormPledgeReports formPledgeReports = new FormPledgeReports();
      formPledgeReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormPledgeReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgeReports.Show();
      formPledgeReports.WindowState = FormWindowState.Maximized;
    }

    private void printLastBilllCustomerCopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        ReportDocument reportDocument = new ReportDocument();
        string BillNumber = "";
        string ShopCode = "";
        DataTable billedBillNumber = PledgeClass.getLastBilledBillNumber();
        if (billedBillNumber != null && billedBillNumber.Rows.Count > 0)
        {
          BillNumber = billedBillNumber.Rows[0]["BillNumber"].ToString();
          ShopCode = billedBillNumber.Rows[0]["ShopCode"].ToString();
        }
        string formatCustomerCopy = FormPrintSettings.getDefaultPrintFormatCustomerCopy();
        string filePath = "Reports\\PledgeBill\\" + formatCustomerCopy;
        ReportDocument pledgeReportDocument = FormDuplicateBill.getPledgeReportDocument(formatCustomerCopy, BillNumber, ShopCode, filePath);
        if (DialogResult.Yes != MessageBox.Show("Print customer Copy (" + BillNumber + ") ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          return;
        pledgeReportDocument.PrintToPrinter(1, false, 1, 1);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void printLastBillOfficeCopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        ReportDocument reportDocument = new ReportDocument();
        string BillNumber = "";
        string ShopCode = "";
        DataTable billedBillNumber = PledgeClass.getLastBilledBillNumber();
        if (billedBillNumber != null && billedBillNumber.Rows.Count > 0)
        {
          BillNumber = billedBillNumber.Rows[0]["BillNumber"].ToString();
          ShopCode = billedBillNumber.Rows[0]["ShopCode"].ToString();
        }
        string defaultPrintFormat = FormPrintSettings.getDefaultPrintFormat();
        string filePath = "Reports\\PledgeBill\\" + defaultPrintFormat;
        ReportDocument pledgeReportDocument = FormDuplicateBill.getPledgeReportDocument(defaultPrintFormat, BillNumber, ShopCode, filePath);
        if (DialogResult.Yes != MessageBox.Show("Print office Copy (" + BillNumber + ")  ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          return;
        pledgeReportDocument.PrintToPrinter(1, false, 1, 1);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void printLastRedemptionBillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string BillNumber = "";
      string ShopCode = "";
      DataTable dataTable = new DataTable();
      DataTable redemptionNumber = PawnManagement.Classes.RedemptionClass.getLastBilledRedemptionNumber();
      if (redemptionNumber != null && redemptionNumber.Rows.Count > 0)
      {
        BillNumber = redemptionNumber.Rows[0]["BillNumber"].ToString();
        ShopCode = redemptionNumber.Rows[0]["ShopCode"].ToString();
      }
      ReportDocument reportDocument = new ReportDocument();
      ReportDocument redemptionBill = PawnManagementClass.getRedemptionBill(BillNumber, ShopCode);
      if (DialogResult.Yes != MessageBox.Show("Print Redemption Bill Duplicate Copy ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      redemptionBill.PrintToPrinter(1, false, 1, 1);
    }

    private void button1_Click(object sender, EventArgs e) => this.splitContainer1.Visible = false;

    private void toolStripButton20_Click(object sender, EventArgs e)
    {
      if (!this.splitContainer1.Visible)
      {
        this.splitContainer1.Visible = true;
        string text = this.tstbBillingDate.Text;
        this.pledgeReport(text);
        this.redemptionReport(text);
      }
      else
      {
        if (!this.splitContainer1.Visible)
          return;
        this.splitContainer1.Visible = false;
      }
    }

    private void multipleReleaseAndReBillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormMultipleRelease formMultipleRelease = new FormMultipleRelease();
      formMultipleRelease.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormMultipleRelease))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formMultipleRelease.Show();
      formMultipleRelease.WindowState = FormWindowState.Maximized;
    }

    private void deletePledgeToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 1 || this.dataGridView1.CurrentCell == null)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (rowIndex != this.dataGridView1.Rows.Count - 1)
      {
        string BillNumber = this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
        string ShopCode = this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
        string BILLDATE = this.dataGridView1.Rows[rowIndex].Cells["BillDate"].Value.ToString();
        DataTable voucherNumberAndDate = VoucherClass.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
        if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
        {
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
          {
            if (DialogResult.Yes == MessageBox.Show("Delete Pledge BillNumber : " + BillNumber + "?", "Delete Pledge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
              this.deleteFromVoucherTable(BillNumber, ShopCode);
              this.pledgeReport(BILLDATE);
            }
          }
          else
          {
            int num = (int) MessageBox.Show("Cannot Delete as Rokad has been finished for this date");
          }
        }
        else if (DialogResult.Yes == MessageBox.Show("Delete Pledge?", "Delete Pledge", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please select the BillNumber correctly");
      }
    }

    private void deleteFromVoucherTable(string BillNumber, string ShopCode)
    {
      DataTable voucherNumberAndDate1 = VoucherClass.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      if (voucherNumberAndDate1 == null || voucherNumberAndDate1.Rows.Count <= 0)
        return;
      DataTable voucherNumberAndDate2 = VoucherClass.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      string str1 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
      string s1 = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
      if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(s1).ToShortDateString()))
      {
        string strError = "";
        if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str1)
        }, ref strError) == "Done")
          PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", "VOUCHER NUMBER " + str1 + " Date " + s1 + " deleted", "", "", FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        int num1 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
      DataTable voucherNumberAndDate3 = VoucherClass.getVoucherNumberAndDate(BillNumber + " INTEREST GIRVI " + ShopCode);
      if (voucherNumberAndDate3 != null && voucherNumberAndDate3.Rows.Count > 0)
      {
        string str2 = voucherNumberAndDate3.Rows[0]["voucherNumber"].ToString();
        string s2 = voucherNumberAndDate3.Rows[0]["voucherDate"].ToString();
        DateTime now = DateTime.Parse(s2);
        if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
        {
          string strError = "";
          if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
          {
            new OleDbParameter("Active", (object) "0"),
            new OleDbParameter("VoucherNumber", (object) str2)
          }, ref strError) == "Done")
          {
            string ActionDetails = "VOUCHER NUMBER " + str2 + " Date " + s2 + " deleted";
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
        }
      }
    }

    private void deleteFromPledgeAndPledgeArticlesTable(string BillNumber, string ShopCode)
    {
      string strError1 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledge where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError1) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError1);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError1, FormMain.username, DateTime.Now.ToString());
      }
      string strError2 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledgearticles where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError2) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError2);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError2, FormMain.username, DateTime.Now.ToString());
      }
      string strError3 = "";
      if (SQLHelper.RunCommand("Delete from tblInterestReceived where BillNumber = @BillNumber AND shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError3) != "Done")
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError3);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError3, FormMain.username, DateTime.Now.ToString());
      }
      PawnManagementClass.InsertIntoHistory("PLEDGE DELETE", BillNumber + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
    }

    private void printCustomerCopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows.Count <= 1 || this.dataGridView1.CurrentCell == null)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (rowIndex != this.dataGridView1.Rows.Count - 1)
        {
          string BillNumber = this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
          string ShopCode = this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
          ReportDocument reportDocument = new ReportDocument();
          string formatCustomerCopy = FormPrintSettings.getDefaultPrintFormatCustomerCopy();
          string filePath = "Reports\\PledgeBill\\" + formatCustomerCopy;
          ReportDocument pledgeReportDocument = FormDuplicateBill.getPledgeReportDocument(formatCustomerCopy, BillNumber, ShopCode, filePath);
          if (DialogResult.Yes == MessageBox.Show("Print customer Copy (" + BillNumber + ") ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            pledgeReportDocument.PrintToPrinter(1, false, 1, 1);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void printOfficeCopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows.Count <= 1 || this.dataGridView1.CurrentCell == null)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (rowIndex != this.dataGridView1.Rows.Count - 1)
        {
          ReportDocument reportDocument = new ReportDocument();
          string BillNumber = this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
          string ShopCode = this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
          string defaultPrintFormat = FormPrintSettings.getDefaultPrintFormat();
          string filePath = "Reports\\PledgeBill\\" + defaultPrintFormat;
          ReportDocument pledgeReportDocument = FormDuplicateBill.getPledgeReportDocument(defaultPrintFormat, BillNumber, ShopCode, filePath);
          if (DialogResult.Yes == MessageBox.Show("Print office Copy (" + BillNumber + ")  ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            pledgeReportDocument.PrintToPrinter(1, false, 1, 1);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void toolStripMenuItem4_Click(object sender, EventArgs e)
    {
      if (this.dataGridView2.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
      if (this.dataGridView2.Rows.Count > 1 && this.dataGridView2.CurrentCell != null && rowIndex != this.dataGridView2.Rows.Count - 1)
      {
        this.dataGridView2.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
        string ShopCode = this.dataGridView2.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
        string BILLDATE = this.dataGridView2.Rows[rowIndex].Cells["BillDate"].Value.ToString();
        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to undo the redemption", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand))
        {
          string RedemptionBillNumber = this.dataGridView2.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
          string PledgeBillNumber = this.dataGridView2.Rows[rowIndex].Cells["PledgeBillNumber"].Value.ToString();
          FormMain.UndoRedemption(ShopCode, RedemptionBillNumber, PledgeBillNumber);
          this.redemptionReport(BILLDATE);
        }
      }
    }

    public static string UndoRedemption(
      string ShopCode,
      string RedemptionBillNumber,
      string PledgeBillNumber)
    {
      DataTable voucherNumberAndDate = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + " RedemptionBillNumber " + ShopCode);
      if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
      {
        voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()).ToShortDateString()))
        {
          PawnManagement.Classes.PawnManagementClasses.RedemptionClass.deleteFromRedemptionTable(RedemptionBillNumber, ShopCode);
          PawnManagement.Classes.PawnManagementClasses.PledgeClass.UndoRedemptionInPledgeTable(PledgeBillNumber, ShopCode);
          if (PawnManagementClass.getRokadAutoEntrySettings())
            VoucherClass.deleteFromVoucherTable(RedemptionBillNumber, ShopCode);
          if (File.Exists(FormMain.startUpPath + "Photos\\released by\\" + RedemptionBillNumber + " " + ShopCode + ".png"))
            File.Delete(FormMain.startUpPath + "Photos\\released by\\" + RedemptionBillNumber + " " + ShopCode + ".png");
          PawnManagementClass.InsertIntoHistory("REDEMPTION DELETE", "Redemption Bill Number" + RedemptionBillNumber + "against pledgeBillNumber " + PledgeBillNumber + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
          return "Done";
        }
        int num = (int) MessageBox.Show("Rokad finished for this date...Cannot undo");
        return "";
      }
      PawnManagement.Classes.PawnManagementClasses.PledgeClass.UndoRedemptionInPledgeTable(PledgeBillNumber, ShopCode);
      return PawnManagement.Classes.PawnManagementClasses.RedemptionClass.deleteFromRedemptionTable(RedemptionBillNumber, ShopCode);
    }

    private void xmlSchemaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormCreateXmlSchema().ShowDialog();
    }

    private void viewCustomerType2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewCustomerDetailss customerDetailss = new FormViewCustomerDetailss();
      customerDetailss.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewCustomerDetailss))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerDetailss.Show();
      customerDetailss.WindowState = FormWindowState.Maximized;
    }

    private void viewCustomer2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormViewCustomerDetailss customerDetailss = new FormViewCustomerDetailss();
      customerDetailss.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormViewCustomerDetailss))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      customerDetailss.Show();
      customerDetailss.WindowState = FormWindowState.Maximized;
    }

    private void deviceMangerToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("devmgmt.msc");

    private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e) => Process.Start("calc");

    private void printersToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "control.exe"), "/name Microsoft.DevicesAndPrinters");

    private void deletePledgeTillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDeletePledgeTill deletePledgeTill = new FormDeletePledgeTill();
      deletePledgeTill.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDeletePledgeTill))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      deletePledgeTill.Show();
      deletePledgeTill.WindowState = FormWindowState.Maximized;
    }

    private void asdfToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void changeBackgroundToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
    }

    private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
    {
    }

    private void printLastRedemptionBillFormD3ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        string ReportName = File.ReadAllLines("Reports\\DForms\\FormD3\\LastUsed.txt")[0].ToString();
        string BillNumber = "";
        string ShopName = "";
        DataTable dataTable = new DataTable();
        DataTable redemptionNumber = PawnManagement.Classes.RedemptionClass.getLastBilledRedemptionNumber();
        if (redemptionNumber != null && redemptionNumber.Rows.Count > 0)
        {
          BillNumber = redemptionNumber.Rows[0]["PledgeBillNumber"].ToString();
          ShopName = redemptionNumber.Rows[0]["ShopCode"].ToString();
        }
        FormD3.getFormD3(ShopName, BillNumber, ReportName).PrintToPrinter(1, false, 1, 1);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form d3.btnShow_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void asdfasdfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new Form10().ShowDialog();
    }

    private void toolStripMenuItem5_Click(object sender, EventArgs e)
    {
      if (this.dataGridView2.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
      if (this.dataGridView2.Rows.Count > 1 && this.dataGridView2.CurrentCell != null && rowIndex != this.dataGridView2.Rows.Count - 1)
      {
        string BillNumber = this.dataGridView2.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
        string ShopCode = this.dataGridView2.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
        ReportDocument reportDocument = new ReportDocument();
        ReportDocument redemptionBill = PawnManagementClass.getRedemptionBill(BillNumber, ShopCode);
        if (DialogResult.Yes == MessageBox.Show("Print Redemption Bill Duplicate Copy ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          redemptionBill.PrintToPrinter(1, false, 1, 1);
      }
    }

    private void noticeChargeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormNoticeChargesReport noticeChargesReport = new FormNoticeChargesReport();
      noticeChargesReport.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      noticeChargesReport.Show();
      noticeChargesReport.WindowState = FormWindowState.Maximized;
    }

    private void toolStripButton19_Click(object sender, EventArgs e)
    {
      FormRedemptionReports redemptionReports = new FormRedemptionReports("");
      redemptionReports.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRedemptionReports))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      redemptionReports.Show();
      redemptionReports.WindowState = FormWindowState.Maximized;
    }

    private void panelToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void asdfToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void fdsdfsdfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new Form6().ShowDialog();
    }

    private void addCustomerAdvancedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form1 form1 = new Form1("ADD", "");
      if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
      {
        if (FormMain.AutoOnfingerPrint)
          FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
        else
          FormMain.m_FPM.EnableAutoOnEvent(false, 0);
      }
      int num = (int) form1.ShowDialog();
    }

    private void testingOldpledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PawnManagement.a.FormPledgePledge formPledgePledge = new PawnManagement.a.FormPledgePledge("OLD PLEDGE");
      formPledgePledge.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (PawnManagement.a.FormPledgePledge))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formPledgePledge.Show();
      formPledgePledge.WindowState = FormWindowState.Maximized;
    }

    private void customerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new PawnManagement.Forms.FormSettings().ShowDialog();
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
      FormPasswordChecker.password = false;
      int num1 = (int) new FormPasswordChecker().ShowDialog();
      if (!FormPasswordChecker.password)
        return;
      int num2 = (int) new FormAdminTools(this.tscbShopCode.Text).ShowDialog();
    }

    private void tslAutoEntryRokad_Click(object sender, EventArgs e)
    {
    }

    private void FormMain_Enter(object sender, EventArgs e)
    {
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void FormMain_Shown(object sender, EventArgs e)
    {
    }

    private void customersWithoutAnyPendingPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormDeleteCustomer formDeleteCustomer = new FormDeleteCustomer();
      formDeleteCustomer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormDeleteCustomer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formDeleteCustomer.Show();
      formDeleteCustomer.WindowState = FormWindowState.Maximized;
    }

    private void shopDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormCompanyDetails().ShowDialog();
    }

    private void undoRedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void rateMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormRate formRate = new FormRate();
      formRate.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormRate))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formRate.Show();
      formRate.WindowState = FormWindowState.Maximized;
    }

    private void memberTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormMemberTypesMaster memberTypesMaster = new FormMemberTypesMaster();
      memberTypesMaster.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormMemberTypesMaster))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      memberTypesMaster.Show();
      memberTypesMaster.WindowState = FormWindowState.Maximized;
    }

    private void customersWithoutPendingPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerPending formCustomerPending = new FormCustomerPending();
      formCustomerPending.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerPendingGirviList))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      formCustomerPending.Show();
      formCustomerPending.WindowState = FormWindowState.Maximized;
    }

    private void customersPendingGirviListToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormCustomerPendingGirviList pendingGirviList = new FormCustomerPendingGirviList();
      pendingGirviList.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCustomerPendingGirviList))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      pendingGirviList.Show();
      pendingGirviList.WindowState = FormWindowState.Maximized;
    }

    private void tableColumnsOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormRedemptionReportsOrder().ShowDialog();
    }

    private void printCustomerCopyBackSideToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load("Reports\\\\DForms\\\\ReportCustomerCopyBackSide.rpt");
      FormCrystalReportViewer crystalReportViewer = new FormCrystalReportViewer(RD);
      crystalReportViewer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCrystalReportViewer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      crystalReportViewer.Show();
      crystalReportViewer.WindowState = FormWindowState.Maximized;
    }

    private void printOfficeCopyBackSideToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load("Reports\\\\DForms\\\\ReportOfficeCopyBackSide.rpt");
      FormCrystalReportViewer crystalReportViewer = new FormCrystalReportViewer(RD);
      crystalReportViewer.MdiParent = (Form) this;
      foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
      {
        if (openForm.GetType() == typeof (FormCrystalReportViewer))
        {
          openForm.BringToFront();
          openForm.WindowState = FormWindowState.Maximized;
          return;
        }
      }
      crystalReportViewer.Show();
      crystalReportViewer.WindowState = FormWindowState.Maximized;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormMain));
      this.menuStrip1 = new MenuStrip();
      this.customersToolStripMenuItem = new ToolStripMenuItem();
      this.viewCustomersToolStripMenuItem = new ToolStripMenuItem();
      this.viewCustomer2ToolStripMenuItem = new ToolStripMenuItem();
      this.addCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.editCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.searchCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.customerRemindersToolStripMenuItem = new ToolStripMenuItem();
      this.customersNotComingToolStripMenuItem = new ToolStripMenuItem();
      this.CustomersStreetReport = new ToolStripMenuItem();
      this.customersLocationReportToolStripMenuItem = new ToolStripMenuItem();
      this.regularCustomersWhoAreNotComingToolStripMenuItem = new ToolStripMenuItem();
      this.customersInterestSummaryToolStripMenuItem = new ToolStripMenuItem();
      this.removeDuplicateCustomersToolStripMenuItem = new ToolStripMenuItem();
      this.removeDuplicateAddressToolStripMenuItem = new ToolStripMenuItem();
      this.findCustomersWithSamePhoneNumberToolStripMenuItem = new ToolStripMenuItem();
      this.customersPendingGirviListToolStripMenuItem = new ToolStripMenuItem();
      this.customersWithoutPendingPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeReportsToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeToolStripMenuItem = new ToolStripMenuItem();
      this.oldPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeEditToolStripMenuItem = new ToolStripMenuItem();
      this.reBillToolStripMenuItem = new ToolStripMenuItem();
      this.deletePledgeToolStripMenuItem = new ToolStripMenuItem();
      this.viewPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeReportsToolStripMenuItem1 = new ToolStripMenuItem();
      this.pledgeReportTodayToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeReportToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeExpiringTodayToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeExpiringThisMonthToolStripMenuItem = new ToolStripMenuItem();
      this.pendingGirviTotalToolStripMenuItem = new ToolStripMenuItem();
      this.ledgerToolStripMenuItem = new ToolStripMenuItem();
      this.printLedgerToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeBookToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeInLossToolStripMenuItem = new ToolStripMenuItem();
      this.basedOnNetWeightToolStripMenuItem = new ToolStripMenuItem();
      this.basedOnPureWeightToolStripMenuItem = new ToolStripMenuItem();
      this.noticeToolStripMenuItem = new ToolStripMenuItem();
      this.numberOfBillsToolStripMenuItem1 = new ToolStripMenuItem();
      this.numberOfBillsToolStripMenuItem = new ToolStripMenuItem();
      this.numberOfBillsConsolidatedToolStripMenuItem2 = new ToolStripMenuItem();
      this.pledgeAmountSummaryToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeAmountSummaryToolStripMenuItem1 = new ToolStripMenuItem();
      this.pledgeAmountSummaryYearlyToolStripMenuItem1 = new ToolStripMenuItem();
      this.stockMasterToolStripMenuItem = new ToolStripMenuItem();
      this.stockCheckToolStripMenuItem = new ToolStripMenuItem();
      this.manageStockToolStripMenuItem = new ToolStripMenuItem();
      this.dayReportToolStripMenuItem = new ToolStripMenuItem();
      this.changeABillFromOneLicenseToOtherToolStripMenuItem = new ToolStripMenuItem();
      this.stockCheckToolStripMenuItem1 = new ToolStripMenuItem();
      this.deletePledgeTillToolStripMenuItem = new ToolStripMenuItem();
      this.redeemReportsToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionEditToolStripMenuItem = new ToolStripMenuItem();
      this.oldRedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.tsmIUndoRedemption = new ToolStripMenuItem();
      this.auctionRedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.numberOfBillsToolStripMenuItem2 = new ToolStripMenuItem();
      this.numberOfBillsToolStripMenuItem3 = new ToolStripMenuItem();
      this.numberOfBillsConsolidatedToolStripMenuItem3 = new ToolStripMenuItem();
      this.redemptionReportsToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionReportsTodayToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionReportsToolStripMenuItem1 = new ToolStripMenuItem();
      this.numberOfBillsConsolidatedToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionInterestYearlySummaryToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionInterestMonthlySummaryToolStripMenuItem3 = new ToolStripMenuItem();
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem = new ToolStripMenuItem();
      this.redemptionINTERESTYearlySummaryToolStripMenuItem1 = new ToolStripMenuItem();
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem2 = new ToolStripMenuItem();
      this.auctionReportsToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeInterestReportToolStripMenuItem = new ToolStripMenuItem();
      this.completeSummaryToolStripMenuItem = new ToolStripMenuItem();
      this.pendingInterestReportsToolStripMenuItem = new ToolStripMenuItem();
      this.partPaymentToolStripMenuItem = new ToolStripMenuItem();
      this.partPaymentToolStripMenuItem1 = new ToolStripMenuItem();
      this.partPaymentReportsToolStripMenuItem = new ToolStripMenuItem();
      this.partPaymentOldEntryToolStripMenuItem = new ToolStripMenuItem();
      this.deleteRedemptionTillToolStripMenuItem = new ToolStripMenuItem();
      this.viewRedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.noticeChargeSummaryToolStripMenuItem = new ToolStripMenuItem();
      this.multipleReleaseAndReBillToolStripMenuItem = new ToolStripMenuItem();
      this.bankToolStripMenuItem = new ToolStripMenuItem();
      this.bankMasterToolStripMenuItem = new ToolStripMenuItem();
      this.bankPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.oldPledgeToolStripMenuItem1 = new ToolStripMenuItem();
      this.bankNewPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.bankPledgeEditToolStripMenuItem1 = new ToolStripMenuItem();
      this.bankReleaseToolStripMenuItem = new ToolStripMenuItem();
      this.bankReleaseToolStripMenuItem1 = new ToolStripMenuItem();
      this.undoRedemptionToolStripMenuItem1 = new ToolStripMenuItem();
      this.bankReleaseEditToolStripMenuItem = new ToolStripMenuItem();
      this.khaathoToolStripMenuItem = new ToolStripMenuItem();
      this.viewKhaathoToolStripMenuItem = new ToolStripMenuItem();
      this.bankReportsToolStripMenuItem = new ToolStripMenuItem();
      this.outsidePledgeListToolStripMenuItem = new ToolStripMenuItem();
      this.jewelsReleasedButStillInBankToolStripMenuItem1 = new ToolStripMenuItem();
      this.jewelleryToolStripMenuItem = new ToolStripMenuItem();
      this.shopDetailsToolStripMenuItem1 = new ToolStripMenuItem();
      this.rateMasterToolStripMenuItem = new ToolStripMenuItem();
      this.itemsNamesMasterToolStripMenuItem = new ToolStripMenuItem();
      this.itemTypeMasterToolStripMenuItem = new ToolStripMenuItem();
      this.metalMasterToolStripMenuItem = new ToolStripMenuItem();
      this.purityMasterToolStripMenuItem = new ToolStripMenuItem();
      this.newSaleToolStripMenuItem = new ToolStripMenuItem();
      this.billNumberSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.salesReportToolStripMenuItem = new ToolStripMenuItem();
      this.accountsToolStripMenuItem = new ToolStripMenuItem();
      this.voucherEntryToolStripMenuItem = new ToolStripMenuItem();
      this.ledgerDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.voucherMasterToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripMenuItem();
      this.rokadToolStripMenuItem = new ToolStripMenuItem();
      this.changeRokadDateToolStripMenuItem = new ToolStripMenuItem();
      this.autoDeleteRokadToolStripMenuItem = new ToolStripMenuItem();
      this.rokadReportsToolStripMenuItem = new ToolStripMenuItem();
      this.printRokadToolStripMenuItem = new ToolStripMenuItem();
      this.rokadReportsConsolidatedToolStripMenuItem = new ToolStripMenuItem();
      this.changeOpeningBalanceToolStripMenuItem = new ToolStripMenuItem();
      this.smsToolStripMenuItem1 = new ToolStripMenuItem();
      this.smsMessagesToolStripMenuItem = new ToolStripMenuItem();
      this.viewSentMessagesToolStripMenuItem = new ToolStripMenuItem();
      this.tesingToolStripMenuItem = new ToolStripMenuItem();
      this.form2ToolStripMenuItem = new ToolStripMenuItem();
      this.formPLEDGEEToolStripMenuItem = new ToolStripMenuItem();
      this.testingOldpledgeToolStripMenuItem = new ToolStripMenuItem();
      this.emailToolStripMenuItem = new ToolStripMenuItem();
      this.hELLOToolStripMenuItem = new ToolStripMenuItem();
      this.newAaddCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.form4ToolStripMenuItem = new ToolStripMenuItem();
      this.panelToolStripMenuItem = new ToolStripMenuItem();
      this.asdfToolStripMenuItem = new ToolStripMenuItem();
      this.fdsdfsdfToolStripMenuItem = new ToolStripMenuItem();
      this.form9ToolStripMenuItem = new ToolStripMenuItem();
      this.xmlSchemaToolStripMenuItem = new ToolStripMenuItem();
      this.viewCustomerType2ToolStripMenuItem = new ToolStripMenuItem();
      this.asdfasdfToolStripMenuItem = new ToolStripMenuItem();
      this.printsToolStripMenuItem = new ToolStripMenuItem();
      this.duplicateBillToolStripMenuItem = new ToolStripMenuItem();
      this.duplicateRedemptionBillToolStripMenuItem = new ToolStripMenuItem();
      this.tOKENSToolStripMenuItem = new ToolStripMenuItem();
      this.fORMD3ToolStripMenuItem = new ToolStripMenuItem();
      this.formCToolStripMenuItem = new ToolStripMenuItem();
      this.fORMDToolStripMenuItem = new ToolStripMenuItem();
      this.printCustomerCopyBackSideToolStripMenuItem = new ToolStripMenuItem();
      this.printOfficeCopyBackSideToolStripMenuItem = new ToolStripMenuItem();
      this.printLastBilllCustomerCopyToolStripMenuItem = new ToolStripMenuItem();
      this.printLastBillOfficeCopyToolStripMenuItem = new ToolStripMenuItem();
      this.printLastRedemptionBillToolStripMenuItem = new ToolStripMenuItem();
      this.printLastRedemptionBillFormD3ToolStripMenuItem = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.shopDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.articlesToolStripMenuItem1 = new ToolStripMenuItem();
      this.loginDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.interestToolStripMenuItem = new ToolStripMenuItem();
      this.interestSettingToolStripMenuItem = new ToolStripMenuItem();
      this.iNTERESTSETTINGToolStripMenuItem1 = new ToolStripMenuItem();
      this.shortcutsToolStripMenuItem = new ToolStripMenuItem();
      this.calculatorToolStripMenuItem1 = new ToolStripMenuItem();
      this.deviceMangerToolStripMenuItem = new ToolStripMenuItem();
      this.printersToolStripMenuItem = new ToolStripMenuItem();
      this.gramRateToolStripMenuItem = new ToolStripMenuItem();
      this.locationAndPincodeToolStripMenuItem = new ToolStripMenuItem();
      this.menuSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.historyToolStripMenuItem = new ToolStripMenuItem();
      this.reminderToolStripMenuItem = new ToolStripMenuItem();
      this.autoBackupToolStripMenuItem = new ToolStripMenuItem();
      this.billNumberSeriesToolStripMenuItem = new ToolStripMenuItem();
      this.exceptionsToolStripMenuItem = new ToolStripMenuItem();
      this.historyReminderSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.jewelPhotoToolStripMenuItem1 = new ToolStripMenuItem();
      this.printSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.articlesSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.generalSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.interestSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripMenuItem();
      this.customerSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.notepadToolStripMenuItem = new ToolStripMenuItem();
      this.inactivityMonitorToolStripMenuItem = new ToolStripMenuItem();
      this.changeInterestToolStripMenuItem = new ToolStripMenuItem();
      this.denominationToolStripMenuItem = new ToolStripMenuItem();
      this.billerMasterToolStripMenuItem = new ToolStripMenuItem();
      this.memberTypeMasterToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip1 = new ToolStrip();
      this.tslRemiinder = new ToolStripLabel();
      this.toolStripLabel2 = new ToolStripLabel();
      this.toolStripLabel3 = new ToolStripLabel();
      this.toolStripButton1 = new ToolStripButton();
      this.tslAutoEntryRokad = new ToolStripLabel();
      this.tscbShopCode = new ToolStripComboBox();
      this.toolStripLabel5 = new ToolStripLabel();
      this.tstbBillingDate = new ToolStripTextBox();
      this.toolStripLabel4 = new ToolStripLabel();
      this.tscbBillerName = new ToolStripComboBox();
      this.toolStripLabel6 = new ToolStripLabel();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripButton3 = new ToolStripButton();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripButton5 = new ToolStripButton();
      this.toolStripButton6 = new ToolStripButton();
      this.toolStripButton7 = new ToolStripButton();
      this.toolStripButton8 = new ToolStripButton();
      this.toolStripButton9 = new ToolStripButton();
      this.tslFingerPrint = new ToolStripLabel();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton20 = new ToolStripButton();
      this.statusStrip1 = new StatusStrip();
      this.tsslblCurrentDate = new ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new ToolStripStatusLabel();
      this.slblAutoDeleteRokad = new ToolStripStatusLabel();
      this.slblAutoBackUp = new ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.slblRokadDate = new ToolStripStatusLabel();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.backgroundWorker2 = new BackgroundWorker();
      this.backgroundWorker3 = new BackgroundWorker();
      this.backgroundWorker4 = new BackgroundWorker();
      this.backgroundWorker5 = new BackgroundWorker();
      this.pbFingerPrint = new PictureBox();
      this.ts2 = new ToolStrip();
      this.toolStripButton10 = new ToolStripButton();
      this.toolStripButton11 = new ToolStripButton();
      this.toolStripButton12 = new ToolStripButton();
      this.toolStripButton15 = new ToolStripButton();
      this.toolStripButton16 = new ToolStripButton();
      this.toolStripButton17 = new ToolStripButton();
      this.toolStripButton14 = new ToolStripButton();
      this.toolStripButton13 = new ToolStripButton();
      this.toolStripButton19 = new ToolStripButton();
      this.toolStripButton18 = new ToolStripButton();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deletePledgeToolStripMenuItem1 = new ToolStripMenuItem();
      this.printCustomerCopyToolStripMenuItem = new ToolStripMenuItem();
      this.printOfficeCopyToolStripMenuItem = new ToolStripMenuItem();
      this.dataGridView2 = new DataGridView();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem4 = new ToolStripMenuItem();
      this.toolStripMenuItem5 = new ToolStripMenuItem();
      this.splitContainer1 = new SplitContainer();
      this.contextMenuStrip3 = new ContextMenuStrip(this.components);
      this.changeBackgroundToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((ISupportInitialize) this.pbFingerPrint).BeginInit();
      this.ts2.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.contextMenuStrip2.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.contextMenuStrip3.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.BackColor = Color.Ivory;
      this.menuStrip1.BackgroundImageLayout = ImageLayout.Stretch;
      this.menuStrip1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.menuStrip1.Items.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.customersToolStripMenuItem,
        (ToolStripItem) this.pledgeReportsToolStripMenuItem,
        (ToolStripItem) this.redeemReportsToolStripMenuItem,
        (ToolStripItem) this.bankToolStripMenuItem,
        (ToolStripItem) this.jewelleryToolStripMenuItem,
        (ToolStripItem) this.accountsToolStripMenuItem,
        (ToolStripItem) this.smsToolStripMenuItem1,
        (ToolStripItem) this.printsToolStripMenuItem,
        (ToolStripItem) this.optionsToolStripMenuItem,
        (ToolStripItem) this.aboutToolStripMenuItem,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.RenderMode = ToolStripRenderMode.Professional;
      this.menuStrip1.Size = new Size(1202, 29);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.MouseEnter += new EventHandler(this.menuStrip1_MouseEnter);
      this.customersToolStripMenuItem.BackColor = Color.Ivory;
      this.customersToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.customersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[16]
      {
        (ToolStripItem) this.viewCustomersToolStripMenuItem,
        (ToolStripItem) this.viewCustomer2ToolStripMenuItem,
        (ToolStripItem) this.addCustomerToolStripMenuItem,
        (ToolStripItem) this.editCustomerToolStripMenuItem,
        (ToolStripItem) this.searchCustomerToolStripMenuItem,
        (ToolStripItem) this.customerRemindersToolStripMenuItem,
        (ToolStripItem) this.customersNotComingToolStripMenuItem,
        (ToolStripItem) this.CustomersStreetReport,
        (ToolStripItem) this.customersLocationReportToolStripMenuItem,
        (ToolStripItem) this.regularCustomersWhoAreNotComingToolStripMenuItem,
        (ToolStripItem) this.customersInterestSummaryToolStripMenuItem,
        (ToolStripItem) this.removeDuplicateCustomersToolStripMenuItem,
        (ToolStripItem) this.removeDuplicateAddressToolStripMenuItem,
        (ToolStripItem) this.findCustomersWithSamePhoneNumberToolStripMenuItem,
        (ToolStripItem) this.customersPendingGirviListToolStripMenuItem,
        (ToolStripItem) this.customersWithoutPendingPledgeToolStripMenuItem
      });
      this.customersToolStripMenuItem.ForeColor = Color.DarkBlue;
      this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
      this.customersToolStripMenuItem.Size = new Size(103, 25);
      this.customersToolStripMenuItem.Text = "Customers";
      this.viewCustomersToolStripMenuItem.Name = "viewCustomersToolStripMenuItem";
      this.viewCustomersToolStripMenuItem.Size = new Size(398, 26);
      this.viewCustomersToolStripMenuItem.Text = "View Customer Details 1";
      this.viewCustomersToolStripMenuItem.Click += new EventHandler(this.viewCustomersToolStripMenuItem_Click);
      this.viewCustomer2ToolStripMenuItem.Name = "viewCustomer2ToolStripMenuItem";
      this.viewCustomer2ToolStripMenuItem.Size = new Size(398, 26);
      this.viewCustomer2ToolStripMenuItem.Text = "View Customer Details 2";
      this.viewCustomer2ToolStripMenuItem.Click += new EventHandler(this.viewCustomer2ToolStripMenuItem_Click);
      this.addCustomerToolStripMenuItem.Image = (Image) PawnManagement.Properties.Resources.plus;
      this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
      this.addCustomerToolStripMenuItem.Size = new Size(398, 26);
      this.addCustomerToolStripMenuItem.Text = "Add Customer";
      this.addCustomerToolStripMenuItem.Click += new EventHandler(this.addCustomerToolStripMenuItem_Click);
      this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
      this.editCustomerToolStripMenuItem.ShortcutKeys = Keys.F11;
      this.editCustomerToolStripMenuItem.Size = new Size(398, 26);
      this.editCustomerToolStripMenuItem.Text = "Edit Customer";
      this.editCustomerToolStripMenuItem.Click += new EventHandler(this.editCustomerToolStripMenuItem_Click);
      this.searchCustomerToolStripMenuItem.Image = (Image) PawnManagement.Properties.Resources.searchglass;
      this.searchCustomerToolStripMenuItem.Name = "searchCustomerToolStripMenuItem";
      this.searchCustomerToolStripMenuItem.Size = new Size(398, 26);
      this.searchCustomerToolStripMenuItem.Text = "Search Customer";
      this.searchCustomerToolStripMenuItem.Click += new EventHandler(this.searchCustomerToolStripMenuItem_Click);
      this.customerRemindersToolStripMenuItem.Name = "customerRemindersToolStripMenuItem";
      this.customerRemindersToolStripMenuItem.Size = new Size(398, 26);
      this.customerRemindersToolStripMenuItem.Text = "Customer Reminders";
      this.customerRemindersToolStripMenuItem.Click += new EventHandler(this.customerRemindersToolStripMenuItem_Click);
      this.customersNotComingToolStripMenuItem.Name = "customersNotComingToolStripMenuItem";
      this.customersNotComingToolStripMenuItem.Size = new Size(398, 26);
      this.customersNotComingToolStripMenuItem.Text = "Customers Not Coming";
      this.customersNotComingToolStripMenuItem.Click += new EventHandler(this.customersNotComingToolStripMenuItem_Click);
      this.CustomersStreetReport.Name = "CustomersStreetReport";
      this.CustomersStreetReport.Size = new Size(398, 26);
      this.CustomersStreetReport.Text = "Customers Street Report";
      this.CustomersStreetReport.Click += new EventHandler(this.toolStripMenuItem2_Click);
      this.customersLocationReportToolStripMenuItem.Name = "customersLocationReportToolStripMenuItem";
      this.customersLocationReportToolStripMenuItem.Size = new Size(398, 26);
      this.customersLocationReportToolStripMenuItem.Text = "Customers Location Report";
      this.customersLocationReportToolStripMenuItem.Click += new EventHandler(this.customersLocationReportToolStripMenuItem_Click);
      this.regularCustomersWhoAreNotComingToolStripMenuItem.Name = "regularCustomersWhoAreNotComingToolStripMenuItem";
      this.regularCustomersWhoAreNotComingToolStripMenuItem.Size = new Size(398, 26);
      this.regularCustomersWhoAreNotComingToolStripMenuItem.Text = "Regular Customers who are not coming";
      this.regularCustomersWhoAreNotComingToolStripMenuItem.Click += new EventHandler(this.regularCustomersWhoAreNotComingToolStripMenuItem_Click);
      this.customersInterestSummaryToolStripMenuItem.Name = "customersInterestSummaryToolStripMenuItem";
      this.customersInterestSummaryToolStripMenuItem.Size = new Size(398, 26);
      this.customersInterestSummaryToolStripMenuItem.Text = "Customers interest summary";
      this.customersInterestSummaryToolStripMenuItem.Click += new EventHandler(this.customersInterestSummaryToolStripMenuItem_Click);
      this.removeDuplicateCustomersToolStripMenuItem.Name = "removeDuplicateCustomersToolStripMenuItem";
      this.removeDuplicateCustomersToolStripMenuItem.Size = new Size(398, 26);
      this.removeDuplicateCustomersToolStripMenuItem.Text = "Remove Duplicate Customers";
      this.removeDuplicateCustomersToolStripMenuItem.Click += new EventHandler(this.removeDuplicateCustomersToolStripMenuItem_Click);
      this.removeDuplicateAddressToolStripMenuItem.Name = "removeDuplicateAddressToolStripMenuItem";
      this.removeDuplicateAddressToolStripMenuItem.Size = new Size(398, 26);
      this.removeDuplicateAddressToolStripMenuItem.Text = "Remove Duplicate Address";
      this.removeDuplicateAddressToolStripMenuItem.Click += new EventHandler(this.removeDuplicateAddressToolStripMenuItem_Click);
      this.findCustomersWithSamePhoneNumberToolStripMenuItem.Name = "findCustomersWithSamePhoneNumberToolStripMenuItem";
      this.findCustomersWithSamePhoneNumberToolStripMenuItem.Size = new Size(398, 26);
      this.findCustomersWithSamePhoneNumberToolStripMenuItem.Text = "Find Customers With Same PhoneNumber";
      this.findCustomersWithSamePhoneNumberToolStripMenuItem.Click += new EventHandler(this.findCustomersWithSamePhoneNumberToolStripMenuItem_Click);
      this.customersPendingGirviListToolStripMenuItem.Name = "customersPendingGirviListToolStripMenuItem";
      this.customersPendingGirviListToolStripMenuItem.Size = new Size(398, 26);
      this.customersPendingGirviListToolStripMenuItem.Text = "Customers Pending Girvi List";
      this.customersPendingGirviListToolStripMenuItem.Click += new EventHandler(this.customersPendingGirviListToolStripMenuItem_Click);
      this.customersWithoutPendingPledgeToolStripMenuItem.Name = "customersWithoutPendingPledgeToolStripMenuItem";
      this.customersWithoutPendingPledgeToolStripMenuItem.Size = new Size(398, 26);
      this.customersWithoutPendingPledgeToolStripMenuItem.Text = "Customers Without Pending Pledge";
      this.customersWithoutPendingPledgeToolStripMenuItem.Click += new EventHandler(this.customersWithoutPendingPledgeToolStripMenuItem_Click);
      this.pledgeReportsToolStripMenuItem.BackColor = Color.Ivory;
      this.pledgeReportsToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.pledgeReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[17]
      {
        (ToolStripItem) this.pledgeToolStripMenuItem,
        (ToolStripItem) this.oldPledgeToolStripMenuItem,
        (ToolStripItem) this.pledgeEditToolStripMenuItem,
        (ToolStripItem) this.reBillToolStripMenuItem,
        (ToolStripItem) this.deletePledgeToolStripMenuItem,
        (ToolStripItem) this.viewPledgeToolStripMenuItem,
        (ToolStripItem) this.pledgeReportsToolStripMenuItem1,
        (ToolStripItem) this.ledgerToolStripMenuItem,
        (ToolStripItem) this.pledgeInLossToolStripMenuItem,
        (ToolStripItem) this.noticeToolStripMenuItem,
        (ToolStripItem) this.numberOfBillsToolStripMenuItem1,
        (ToolStripItem) this.pledgeAmountSummaryToolStripMenuItem,
        (ToolStripItem) this.stockMasterToolStripMenuItem,
        (ToolStripItem) this.dayReportToolStripMenuItem,
        (ToolStripItem) this.changeABillFromOneLicenseToOtherToolStripMenuItem,
        (ToolStripItem) this.stockCheckToolStripMenuItem1,
        (ToolStripItem) this.deletePledgeTillToolStripMenuItem
      });
      this.pledgeReportsToolStripMenuItem.ForeColor = Color.Navy;
      this.pledgeReportsToolStripMenuItem.Name = "pledgeReportsToolStripMenuItem";
      this.pledgeReportsToolStripMenuItem.Size = new Size(72, 25);
      this.pledgeReportsToolStripMenuItem.Text = "Pledge";
      this.pledgeReportsToolStripMenuItem.Click += new EventHandler(this.pledgeReportsToolStripMenuItem_Click);
      this.pledgeToolStripMenuItem.Name = "pledgeToolStripMenuItem";
      this.pledgeToolStripMenuItem.ShortcutKeys = Keys.F1;
      this.pledgeToolStripMenuItem.Size = new Size(369, 26);
      this.pledgeToolStripMenuItem.Text = "Pledge";
      this.pledgeToolStripMenuItem.Click += new EventHandler(this.pledgeToolStripMenuItem_Click);
      this.oldPledgeToolStripMenuItem.Name = "oldPledgeToolStripMenuItem";
      this.oldPledgeToolStripMenuItem.ShortcutKeys = Keys.F2;
      this.oldPledgeToolStripMenuItem.Size = new Size(369, 26);
      this.oldPledgeToolStripMenuItem.Text = "Old Pledge";
      this.oldPledgeToolStripMenuItem.Click += new EventHandler(this.oldPledgeToolStripMenuItem_Click);
      this.pledgeEditToolStripMenuItem.Name = "pledgeEditToolStripMenuItem";
      this.pledgeEditToolStripMenuItem.ShortcutKeys = Keys.F3;
      this.pledgeEditToolStripMenuItem.Size = new Size(369, 26);
      this.pledgeEditToolStripMenuItem.Text = "Pledge Edit";
      this.pledgeEditToolStripMenuItem.Click += new EventHandler(this.pledgeEditToolStripMenuItem_Click);
      this.reBillToolStripMenuItem.Name = "reBillToolStripMenuItem";
      this.reBillToolStripMenuItem.ShortcutKeys = Keys.F4;
      this.reBillToolStripMenuItem.Size = new Size(369, 26);
      this.reBillToolStripMenuItem.Text = "ReBill";
      this.reBillToolStripMenuItem.Click += new EventHandler(this.reBillToolStripMenuItem_Click);
      this.deletePledgeToolStripMenuItem.Name = "deletePledgeToolStripMenuItem";
      this.deletePledgeToolStripMenuItem.Size = new Size(369, 26);
      this.deletePledgeToolStripMenuItem.Text = "Delete Pledge";
      this.deletePledgeToolStripMenuItem.Click += new EventHandler(this.deletePledgeToolStripMenuItem_Click_1);
      this.viewPledgeToolStripMenuItem.Name = "viewPledgeToolStripMenuItem";
      this.viewPledgeToolStripMenuItem.Size = new Size(369, 26);
      this.viewPledgeToolStripMenuItem.Text = "View Pledge";
      this.viewPledgeToolStripMenuItem.Click += new EventHandler(this.viewPledgeToolStripMenuItem_Click);
      this.pledgeReportsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.pledgeReportTodayToolStripMenuItem,
        (ToolStripItem) this.pledgeReportToolStripMenuItem,
        (ToolStripItem) this.pledgeExpiringTodayToolStripMenuItem,
        (ToolStripItem) this.pledgeExpiringThisMonthToolStripMenuItem,
        (ToolStripItem) this.pendingGirviTotalToolStripMenuItem
      });
      this.pledgeReportsToolStripMenuItem1.Name = "pledgeReportsToolStripMenuItem1";
      this.pledgeReportsToolStripMenuItem1.Size = new Size(369, 26);
      this.pledgeReportsToolStripMenuItem1.Text = "Pledge Reports";
      this.pledgeReportsToolStripMenuItem1.Click += new EventHandler(this.pledgeReportsToolStripMenuItem1_Click);
      this.pledgeReportTodayToolStripMenuItem.Name = "pledgeReportTodayToolStripMenuItem";
      this.pledgeReportTodayToolStripMenuItem.Size = new Size(289, 26);
      this.pledgeReportTodayToolStripMenuItem.Text = "Pledge Report Today";
      this.pledgeReportTodayToolStripMenuItem.Click += new EventHandler(this.pledgeReportTodayToolStripMenuItem_Click);
      this.pledgeReportToolStripMenuItem.Name = "pledgeReportToolStripMenuItem";
      this.pledgeReportToolStripMenuItem.Size = new Size(289, 26);
      this.pledgeReportToolStripMenuItem.Text = "Pledge Report";
      this.pledgeReportToolStripMenuItem.Click += new EventHandler(this.pledgeReportToolStripMenuItem_Click);
      this.pledgeExpiringTodayToolStripMenuItem.Name = "pledgeExpiringTodayToolStripMenuItem";
      this.pledgeExpiringTodayToolStripMenuItem.Size = new Size(289, 26);
      this.pledgeExpiringTodayToolStripMenuItem.Text = "Pledge Expiring Today";
      this.pledgeExpiringTodayToolStripMenuItem.Click += new EventHandler(this.pledgeExpiringTodayToolStripMenuItem_Click);
      this.pledgeExpiringThisMonthToolStripMenuItem.Name = "pledgeExpiringThisMonthToolStripMenuItem";
      this.pledgeExpiringThisMonthToolStripMenuItem.Size = new Size(289, 26);
      this.pledgeExpiringThisMonthToolStripMenuItem.Text = "Pledge Expiring This Month";
      this.pledgeExpiringThisMonthToolStripMenuItem.Click += new EventHandler(this.pledgeExpiringThisMonthToolStripMenuItem_Click);
      this.pendingGirviTotalToolStripMenuItem.Name = "pendingGirviTotalToolStripMenuItem";
      this.pendingGirviTotalToolStripMenuItem.Size = new Size(289, 26);
      this.pendingGirviTotalToolStripMenuItem.Text = "Pending Girvi Total";
      this.pendingGirviTotalToolStripMenuItem.Click += new EventHandler(this.pendingGirviTotalToolStripMenuItem_Click);
      this.ledgerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.printLedgerToolStripMenuItem,
        (ToolStripItem) this.pledgeBookToolStripMenuItem
      });
      this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
      this.ledgerToolStripMenuItem.Size = new Size(369, 26);
      this.ledgerToolStripMenuItem.Text = "Ledger";
      this.ledgerToolStripMenuItem.Click += new EventHandler(this.ledgerToolStripMenuItem_Click);
      this.printLedgerToolStripMenuItem.Name = "printLedgerToolStripMenuItem";
      this.printLedgerToolStripMenuItem.Size = new Size(176, 26);
      this.printLedgerToolStripMenuItem.Text = "Print Ledger";
      this.printLedgerToolStripMenuItem.Click += new EventHandler(this.printLedgerToolStripMenuItem_Click);
      this.pledgeBookToolStripMenuItem.Name = "pledgeBookToolStripMenuItem";
      this.pledgeBookToolStripMenuItem.Size = new Size(176, 26);
      this.pledgeBookToolStripMenuItem.Text = "Pledge Book";
      this.pledgeBookToolStripMenuItem.Click += new EventHandler(this.pledgeBookToolStripMenuItem_Click);
      this.pledgeInLossToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.basedOnNetWeightToolStripMenuItem,
        (ToolStripItem) this.basedOnPureWeightToolStripMenuItem
      });
      this.pledgeInLossToolStripMenuItem.Name = "pledgeInLossToolStripMenuItem";
      this.pledgeInLossToolStripMenuItem.Size = new Size(369, 26);
      this.pledgeInLossToolStripMenuItem.Text = "Pledge in Loss";
      this.pledgeInLossToolStripMenuItem.Click += new EventHandler(this.pledgeInLossToolStripMenuItem_Click);
      this.basedOnNetWeightToolStripMenuItem.Name = "basedOnNetWeightToolStripMenuItem";
      this.basedOnNetWeightToolStripMenuItem.Size = new Size(244, 26);
      this.basedOnNetWeightToolStripMenuItem.Text = "Based On NetWeight";
      this.basedOnNetWeightToolStripMenuItem.Click += new EventHandler(this.basedOnNetWeightToolStripMenuItem_Click);
      this.basedOnPureWeightToolStripMenuItem.Name = "basedOnPureWeightToolStripMenuItem";
      this.basedOnPureWeightToolStripMenuItem.Size = new Size(244, 26);
      this.basedOnPureWeightToolStripMenuItem.Text = "Based On PureWeight";
      this.basedOnPureWeightToolStripMenuItem.Click += new EventHandler(this.basedOnPureWeightToolStripMenuItem_Click);
      this.noticeToolStripMenuItem.Name = "noticeToolStripMenuItem";
      this.noticeToolStripMenuItem.Size = new Size(369, 26);
      this.noticeToolStripMenuItem.Text = "Notice";
      this.noticeToolStripMenuItem.Click += new EventHandler(this.noticeToolStripMenuItem_Click);
      this.numberOfBillsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.numberOfBillsToolStripMenuItem,
        (ToolStripItem) this.numberOfBillsConsolidatedToolStripMenuItem2
      });
      this.numberOfBillsToolStripMenuItem1.Name = "numberOfBillsToolStripMenuItem1";
      this.numberOfBillsToolStripMenuItem1.Size = new Size(369, 26);
      this.numberOfBillsToolStripMenuItem1.Text = "Number of Bills";
      this.numberOfBillsToolStripMenuItem1.Click += new EventHandler(this.numberOfBillsToolStripMenuItem1_Click);
      this.numberOfBillsToolStripMenuItem.Name = "numberOfBillsToolStripMenuItem";
      this.numberOfBillsToolStripMenuItem.Size = new Size(314, 26);
      this.numberOfBillsToolStripMenuItem.Text = "Number of Bills";
      this.numberOfBillsToolStripMenuItem.Click += new EventHandler(this.numberOfBillsToolStripMenuItem_Click_1);
      this.numberOfBillsConsolidatedToolStripMenuItem2.Name = "numberOfBillsConsolidatedToolStripMenuItem2";
      this.numberOfBillsConsolidatedToolStripMenuItem2.Size = new Size(314, 26);
      this.numberOfBillsConsolidatedToolStripMenuItem2.Text = "Number of Bills (Consolidated)";
      this.numberOfBillsConsolidatedToolStripMenuItem2.Click += new EventHandler(this.numberOfBillsConsolidatedToolStripMenuItem2_Click);
      this.pledgeAmountSummaryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.pledgeAmountSummaryToolStripMenuItem1,
        (ToolStripItem) this.pledgeAmountSummaryYearlyToolStripMenuItem1
      });
      this.pledgeAmountSummaryToolStripMenuItem.Name = "pledgeAmountSummaryToolStripMenuItem";
      this.pledgeAmountSummaryToolStripMenuItem.Size = new Size(369, 26);
      this.pledgeAmountSummaryToolStripMenuItem.Text = "Pledge Amount Summary";
      this.pledgeAmountSummaryToolStripMenuItem.Click += new EventHandler(this.pledgeAmountSummaryToolStripMenuItem_Click);
      this.pledgeAmountSummaryToolStripMenuItem1.Name = "pledgeAmountSummaryToolStripMenuItem1";
      this.pledgeAmountSummaryToolStripMenuItem1.Size = new Size(320, 26);
      this.pledgeAmountSummaryToolStripMenuItem1.Text = "Pledge Amount Summary";
      this.pledgeAmountSummaryToolStripMenuItem1.Click += new EventHandler(this.pledgeAmountSummaryToolStripMenuItem1_Click);
      this.pledgeAmountSummaryYearlyToolStripMenuItem1.Name = "pledgeAmountSummaryYearlyToolStripMenuItem1";
      this.pledgeAmountSummaryYearlyToolStripMenuItem1.Size = new Size(320, 26);
      this.pledgeAmountSummaryYearlyToolStripMenuItem1.Text = "Pledge Amount Summary Yearly";
      this.pledgeAmountSummaryYearlyToolStripMenuItem1.Click += new EventHandler(this.pledgeAmountSummaryYearlyToolStripMenuItem1_Click);
      this.stockMasterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.stockCheckToolStripMenuItem,
        (ToolStripItem) this.manageStockToolStripMenuItem
      });
      this.stockMasterToolStripMenuItem.Name = "stockMasterToolStripMenuItem";
      this.stockMasterToolStripMenuItem.Size = new Size(369, 26);
      this.stockMasterToolStripMenuItem.Text = "Stock Master";
      this.stockMasterToolStripMenuItem.Click += new EventHandler(this.stockMasterToolStripMenuItem_Click);
      this.stockCheckToolStripMenuItem.Name = "stockCheckToolStripMenuItem";
      this.stockCheckToolStripMenuItem.Size = new Size(189, 26);
      this.stockCheckToolStripMenuItem.Text = "Stock check";
      this.stockCheckToolStripMenuItem.Click += new EventHandler(this.stockCheckToolStripMenuItem_Click);
      this.manageStockToolStripMenuItem.Name = "manageStockToolStripMenuItem";
      this.manageStockToolStripMenuItem.Size = new Size(189, 26);
      this.manageStockToolStripMenuItem.Text = "Manage stock ";
      this.manageStockToolStripMenuItem.Click += new EventHandler(this.manageStockToolStripMenuItem_Click);
      this.dayReportToolStripMenuItem.Name = "dayReportToolStripMenuItem";
      this.dayReportToolStripMenuItem.ShortcutKeys = Keys.D | Keys.Control;
      this.dayReportToolStripMenuItem.Size = new Size(369, 26);
      this.dayReportToolStripMenuItem.Text = "Day Report";
      this.dayReportToolStripMenuItem.Click += new EventHandler(this.dayReportToolStripMenuItem_Click);
      this.changeABillFromOneLicenseToOtherToolStripMenuItem.Name = "changeABillFromOneLicenseToOtherToolStripMenuItem";
      this.changeABillFromOneLicenseToOtherToolStripMenuItem.Size = new Size(369, 26);
      this.changeABillFromOneLicenseToOtherToolStripMenuItem.Text = "Change a Bill from one license to other";
      this.changeABillFromOneLicenseToOtherToolStripMenuItem.Click += new EventHandler(this.changeABillFromOneLicenseToOtherToolStripMenuItem_Click);
      this.stockCheckToolStripMenuItem1.Name = "stockCheckToolStripMenuItem1";
      this.stockCheckToolStripMenuItem1.Size = new Size(369, 26);
      this.stockCheckToolStripMenuItem1.Text = "Stock Check";
      this.stockCheckToolStripMenuItem1.Click += new EventHandler(this.stockCheckToolStripMenuItem1_Click);
      this.deletePledgeTillToolStripMenuItem.Name = "deletePledgeTillToolStripMenuItem";
      this.deletePledgeTillToolStripMenuItem.Size = new Size(369, 26);
      this.deletePledgeTillToolStripMenuItem.Text = "Delete Pledge Till";
      this.deletePledgeTillToolStripMenuItem.Click += new EventHandler(this.deletePledgeTillToolStripMenuItem_Click);
      this.redeemReportsToolStripMenuItem.BackColor = Color.Ivory;
      this.redeemReportsToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.redeemReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.redemptionToolStripMenuItem,
        (ToolStripItem) this.redemptionEditToolStripMenuItem,
        (ToolStripItem) this.oldRedemptionToolStripMenuItem,
        (ToolStripItem) this.tsmIUndoRedemption,
        (ToolStripItem) this.auctionRedemptionToolStripMenuItem,
        (ToolStripItem) this.numberOfBillsToolStripMenuItem2,
        (ToolStripItem) this.redemptionReportsToolStripMenuItem,
        (ToolStripItem) this.numberOfBillsConsolidatedToolStripMenuItem,
        (ToolStripItem) this.redemptionINTERESTMonthlySummaryToolStripMenuItem,
        (ToolStripItem) this.auctionReportsToolStripMenuItem,
        (ToolStripItem) this.pledgeInterestReportToolStripMenuItem,
        (ToolStripItem) this.completeSummaryToolStripMenuItem,
        (ToolStripItem) this.pendingInterestReportsToolStripMenuItem,
        (ToolStripItem) this.partPaymentToolStripMenuItem,
        (ToolStripItem) this.deleteRedemptionTillToolStripMenuItem,
        (ToolStripItem) this.viewRedemptionToolStripMenuItem,
        (ToolStripItem) this.noticeChargeSummaryToolStripMenuItem,
        (ToolStripItem) this.multipleReleaseAndReBillToolStripMenuItem
      });
      this.redeemReportsToolStripMenuItem.ForeColor = Color.Navy;
      this.redeemReportsToolStripMenuItem.Name = "redeemReportsToolStripMenuItem";
      this.redeemReportsToolStripMenuItem.Size = new Size(83, 25);
      this.redeemReportsToolStripMenuItem.Text = "Redeem";
      this.redemptionToolStripMenuItem.Name = "redemptionToolStripMenuItem";
      this.redemptionToolStripMenuItem.ShortcutKeys = Keys.F5;
      this.redemptionToolStripMenuItem.Size = new Size(288, 26);
      this.redemptionToolStripMenuItem.Text = "Redemption";
      this.redemptionToolStripMenuItem.Click += new EventHandler(this.redemptionToolStripMenuItem_Click);
      this.redemptionEditToolStripMenuItem.Name = "redemptionEditToolStripMenuItem";
      this.redemptionEditToolStripMenuItem.Size = new Size(288, 26);
      this.redemptionEditToolStripMenuItem.Text = "Redemption Edit";
      this.redemptionEditToolStripMenuItem.Click += new EventHandler(this.redemptionEditToolStripMenuItem_Click);
      this.oldRedemptionToolStripMenuItem.Name = "oldRedemptionToolStripMenuItem";
      this.oldRedemptionToolStripMenuItem.ShortcutKeys = Keys.F6;
      this.oldRedemptionToolStripMenuItem.Size = new Size(288, 26);
      this.oldRedemptionToolStripMenuItem.Text = "Old Redemption";
      this.oldRedemptionToolStripMenuItem.Click += new EventHandler(this.oldRedemptionToolStripMenuItem_Click);
      this.tsmIUndoRedemption.Name = "tsmIUndoRedemption";
      this.tsmIUndoRedemption.Size = new Size(288, 26);
      this.tsmIUndoRedemption.Text = "UNDO REDEMPTION";
      this.tsmIUndoRedemption.Click += new EventHandler(this.tsmIUndoRedemption_Click);
      this.auctionRedemptionToolStripMenuItem.Name = "auctionRedemptionToolStripMenuItem";
      this.auctionRedemptionToolStripMenuItem.Size = new Size(288, 26);
      this.auctionRedemptionToolStripMenuItem.Text = "Auction Redemption";
      this.auctionRedemptionToolStripMenuItem.Click += new EventHandler(this.auctionRedemptionToolStripMenuItem_Click);
      this.numberOfBillsToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.numberOfBillsToolStripMenuItem3,
        (ToolStripItem) this.numberOfBillsConsolidatedToolStripMenuItem3
      });
      this.numberOfBillsToolStripMenuItem2.Name = "numberOfBillsToolStripMenuItem2";
      this.numberOfBillsToolStripMenuItem2.Size = new Size(288, 26);
      this.numberOfBillsToolStripMenuItem2.Text = "Number of Bills";
      this.numberOfBillsToolStripMenuItem2.Click += new EventHandler(this.numberOfBillsToolStripMenuItem2_Click);
      this.numberOfBillsToolStripMenuItem3.Name = "numberOfBillsToolStripMenuItem3";
      this.numberOfBillsToolStripMenuItem3.Size = new Size(314, 26);
      this.numberOfBillsToolStripMenuItem3.Text = "Number of Bills";
      this.numberOfBillsToolStripMenuItem3.Click += new EventHandler(this.numberOfBillsToolStripMenuItem3_Click);
      this.numberOfBillsConsolidatedToolStripMenuItem3.Name = "numberOfBillsConsolidatedToolStripMenuItem3";
      this.numberOfBillsConsolidatedToolStripMenuItem3.Size = new Size(314, 26);
      this.numberOfBillsConsolidatedToolStripMenuItem3.Text = "Number of Bills (Consolidated)";
      this.numberOfBillsConsolidatedToolStripMenuItem3.Click += new EventHandler(this.numberOfBillsConsolidatedToolStripMenuItem3_Click);
      this.redemptionReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.redemptionReportsTodayToolStripMenuItem,
        (ToolStripItem) this.redemptionReportsToolStripMenuItem1
      });
      this.redemptionReportsToolStripMenuItem.Name = "redemptionReportsToolStripMenuItem";
      this.redemptionReportsToolStripMenuItem.Size = new Size(288, 26);
      this.redemptionReportsToolStripMenuItem.Text = "Redemption Reports";
      this.redemptionReportsToolStripMenuItem.Click += new EventHandler(this.redemptionReportsToolStripMenuItem_Click);
      this.redemptionReportsTodayToolStripMenuItem.Name = "redemptionReportsTodayToolStripMenuItem";
      this.redemptionReportsTodayToolStripMenuItem.Size = new Size(289, 26);
      this.redemptionReportsTodayToolStripMenuItem.Text = "Redemption Reports Today";
      this.redemptionReportsTodayToolStripMenuItem.Click += new EventHandler(this.redemptionReportsTodayToolStripMenuItem_Click);
      this.redemptionReportsToolStripMenuItem1.Name = "redemptionReportsToolStripMenuItem1";
      this.redemptionReportsToolStripMenuItem1.Size = new Size(289, 26);
      this.redemptionReportsToolStripMenuItem1.Text = "Redemption Reports";
      this.redemptionReportsToolStripMenuItem1.Click += new EventHandler(this.redemptionReportsToolStripMenuItem1_Click);
      this.numberOfBillsConsolidatedToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.redemptionInterestYearlySummaryToolStripMenuItem,
        (ToolStripItem) this.redemptionInterestMonthlySummaryToolStripMenuItem3
      });
      this.numberOfBillsConsolidatedToolStripMenuItem.Name = "numberOfBillsConsolidatedToolStripMenuItem";
      this.numberOfBillsConsolidatedToolStripMenuItem.Size = new Size(288, 26);
      this.numberOfBillsConsolidatedToolStripMenuItem.Text = "Redemption Interest";
      this.numberOfBillsConsolidatedToolStripMenuItem.Click += new EventHandler(this.numberOfBillsConsolidatedToolStripMenuItem_Click);
      this.redemptionInterestYearlySummaryToolStripMenuItem.Name = "redemptionInterestYearlySummaryToolStripMenuItem";
      this.redemptionInterestYearlySummaryToolStripMenuItem.Size = new Size(374, 26);
      this.redemptionInterestYearlySummaryToolStripMenuItem.Text = "Redemption Interest Yearly Summary";
      this.redemptionInterestYearlySummaryToolStripMenuItem.Click += new EventHandler(this.redemptionInterestYearlySummaryToolStripMenuItem_Click);
      this.redemptionInterestMonthlySummaryToolStripMenuItem3.Name = "redemptionInterestMonthlySummaryToolStripMenuItem3";
      this.redemptionInterestMonthlySummaryToolStripMenuItem3.Size = new Size(374, 26);
      this.redemptionInterestMonthlySummaryToolStripMenuItem3.Text = "Redemption Interest Monthly Summary";
      this.redemptionInterestMonthlySummaryToolStripMenuItem3.Click += new EventHandler(this.redemptionInterestMonthlySummaryToolStripMenuItem3_Click);
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.redemptionINTERESTYearlySummaryToolStripMenuItem1,
        (ToolStripItem) this.redemptionINTERESTMonthlySummaryToolStripMenuItem2
      });
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem.Name = "redemptionINTERESTMonthlySummaryToolStripMenuItem";
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem.Size = new Size(288, 26);
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem.Text = "Redemption InTeresT";
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem.Click += new EventHandler(this.redemptionINTERESTMonthlySummaryToolStripMenuItem_Click);
      this.redemptionINTERESTYearlySummaryToolStripMenuItem1.Name = "redemptionINTERESTYearlySummaryToolStripMenuItem1";
      this.redemptionINTERESTYearlySummaryToolStripMenuItem1.Size = new Size(408, 26);
      this.redemptionINTERESTYearlySummaryToolStripMenuItem1.Text = "Redemption INTEREST Yearly Summary";
      this.redemptionINTERESTYearlySummaryToolStripMenuItem1.Click += new EventHandler(this.redemptionINTERESTYearlySummaryToolStripMenuItem1_Click);
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem2.Name = "redemptionINTERESTMonthlySummaryToolStripMenuItem2";
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem2.Size = new Size(408, 26);
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem2.Text = "Redemption INTEREST Monthly Summary";
      this.redemptionINTERESTMonthlySummaryToolStripMenuItem2.Click += new EventHandler(this.redemptionINTERESTMonthlySummaryToolStripMenuItem2_Click_1);
      this.auctionReportsToolStripMenuItem.Name = "auctionReportsToolStripMenuItem";
      this.auctionReportsToolStripMenuItem.Size = new Size(288, 26);
      this.auctionReportsToolStripMenuItem.Text = "Auction Reports";
      this.auctionReportsToolStripMenuItem.Click += new EventHandler(this.auctionReportsToolStripMenuItem_Click);
      this.pledgeInterestReportToolStripMenuItem.Name = "pledgeInterestReportToolStripMenuItem";
      this.pledgeInterestReportToolStripMenuItem.Size = new Size(288, 26);
      this.pledgeInterestReportToolStripMenuItem.Text = "Pledge Interest Report";
      this.pledgeInterestReportToolStripMenuItem.Click += new EventHandler(this.pledgeInterestReportToolStripMenuItem_Click);
      this.completeSummaryToolStripMenuItem.Name = "completeSummaryToolStripMenuItem";
      this.completeSummaryToolStripMenuItem.Size = new Size(288, 26);
      this.completeSummaryToolStripMenuItem.Text = "Complete Summary";
      this.completeSummaryToolStripMenuItem.Click += new EventHandler(this.completeSummaryToolStripMenuItem_Click);
      this.pendingInterestReportsToolStripMenuItem.Name = "pendingInterestReportsToolStripMenuItem";
      this.pendingInterestReportsToolStripMenuItem.Size = new Size(288, 26);
      this.pendingInterestReportsToolStripMenuItem.Text = "Pending Interest Reports";
      this.pendingInterestReportsToolStripMenuItem.Click += new EventHandler(this.pendingInterestReportsToolStripMenuItem_Click);
      this.partPaymentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.partPaymentToolStripMenuItem1,
        (ToolStripItem) this.partPaymentReportsToolStripMenuItem,
        (ToolStripItem) this.partPaymentOldEntryToolStripMenuItem
      });
      this.partPaymentToolStripMenuItem.Name = "partPaymentToolStripMenuItem";
      this.partPaymentToolStripMenuItem.Size = new Size(288, 26);
      this.partPaymentToolStripMenuItem.Text = "Part Payment";
      this.partPaymentToolStripMenuItem.Click += new EventHandler(this.partPaymentToolStripMenuItem_Click);
      this.partPaymentToolStripMenuItem1.Name = "partPaymentToolStripMenuItem1";
      this.partPaymentToolStripMenuItem1.Size = new Size(264, 26);
      this.partPaymentToolStripMenuItem1.Text = "Part Payment";
      this.partPaymentToolStripMenuItem1.Click += new EventHandler(this.partPaymentToolStripMenuItem1_Click);
      this.partPaymentReportsToolStripMenuItem.Name = "partPaymentReportsToolStripMenuItem";
      this.partPaymentReportsToolStripMenuItem.Size = new Size(264, 26);
      this.partPaymentReportsToolStripMenuItem.Text = "Part Payment Reports";
      this.partPaymentReportsToolStripMenuItem.Click += new EventHandler(this.partPaymentReportsToolStripMenuItem_Click);
      this.partPaymentOldEntryToolStripMenuItem.Name = "partPaymentOldEntryToolStripMenuItem";
      this.partPaymentOldEntryToolStripMenuItem.Size = new Size(264, 26);
      this.partPaymentOldEntryToolStripMenuItem.Text = "Part Payment(Old Entry)";
      this.partPaymentOldEntryToolStripMenuItem.Click += new EventHandler(this.partPaymentOldEntryToolStripMenuItem_Click);
      this.deleteRedemptionTillToolStripMenuItem.Name = "deleteRedemptionTillToolStripMenuItem";
      this.deleteRedemptionTillToolStripMenuItem.Size = new Size(288, 26);
      this.deleteRedemptionTillToolStripMenuItem.Text = "Delete Redemption Till";
      this.deleteRedemptionTillToolStripMenuItem.Click += new EventHandler(this.deleteRedemptionTillToolStripMenuItem_Click);
      this.viewRedemptionToolStripMenuItem.Name = "viewRedemptionToolStripMenuItem";
      this.viewRedemptionToolStripMenuItem.Size = new Size(288, 26);
      this.viewRedemptionToolStripMenuItem.Text = "View Redemption";
      this.viewRedemptionToolStripMenuItem.Click += new EventHandler(this.viewRedemptionToolStripMenuItem_Click);
      this.noticeChargeSummaryToolStripMenuItem.Name = "noticeChargeSummaryToolStripMenuItem";
      this.noticeChargeSummaryToolStripMenuItem.Size = new Size(288, 26);
      this.noticeChargeSummaryToolStripMenuItem.Text = "NoticeChargeSummary";
      this.noticeChargeSummaryToolStripMenuItem.Click += new EventHandler(this.noticeChargeSummaryToolStripMenuItem_Click);
      this.multipleReleaseAndReBillToolStripMenuItem.Name = "multipleReleaseAndReBillToolStripMenuItem";
      this.multipleReleaseAndReBillToolStripMenuItem.Size = new Size(288, 26);
      this.multipleReleaseAndReBillToolStripMenuItem.Text = "Multiple Release And ReBill";
      this.multipleReleaseAndReBillToolStripMenuItem.Click += new EventHandler(this.multipleReleaseAndReBillToolStripMenuItem_Click);
      this.bankToolStripMenuItem.BackColor = Color.Ivory;
      this.bankToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.bankToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.bankMasterToolStripMenuItem,
        (ToolStripItem) this.bankPledgeToolStripMenuItem,
        (ToolStripItem) this.bankReleaseToolStripMenuItem,
        (ToolStripItem) this.khaathoToolStripMenuItem,
        (ToolStripItem) this.viewKhaathoToolStripMenuItem,
        (ToolStripItem) this.bankReportsToolStripMenuItem,
        (ToolStripItem) this.outsidePledgeListToolStripMenuItem,
        (ToolStripItem) this.jewelsReleasedButStillInBankToolStripMenuItem1
      });
      this.bankToolStripMenuItem.ForeColor = Color.Navy;
      this.bankToolStripMenuItem.Name = "bankToolStripMenuItem";
      this.bankToolStripMenuItem.Size = new Size(60, 25);
      this.bankToolStripMenuItem.Text = "Bank";
      this.bankMasterToolStripMenuItem.Name = "bankMasterToolStripMenuItem";
      this.bankMasterToolStripMenuItem.Size = new Size(325, 26);
      this.bankMasterToolStripMenuItem.Text = "BankMaster";
      this.bankMasterToolStripMenuItem.Click += new EventHandler(this.bankMasterToolStripMenuItem_Click);
      this.bankPledgeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.oldPledgeToolStripMenuItem1,
        (ToolStripItem) this.bankNewPledgeToolStripMenuItem,
        (ToolStripItem) this.bankPledgeEditToolStripMenuItem1
      });
      this.bankPledgeToolStripMenuItem.Name = "bankPledgeToolStripMenuItem";
      this.bankPledgeToolStripMenuItem.Size = new Size(325, 26);
      this.bankPledgeToolStripMenuItem.Text = "Bank Pledge";
      this.bankPledgeToolStripMenuItem.Click += new EventHandler(this.bankPledgeToolStripMenuItem_Click);
      this.oldPledgeToolStripMenuItem1.Name = "oldPledgeToolStripMenuItem1";
      this.oldPledgeToolStripMenuItem1.Size = new Size(212, 26);
      this.oldPledgeToolStripMenuItem1.Text = "Bank Old Pledge";
      this.oldPledgeToolStripMenuItem1.Click += new EventHandler(this.oldPledgeToolStripMenuItem1_Click);
      this.bankNewPledgeToolStripMenuItem.Name = "bankNewPledgeToolStripMenuItem";
      this.bankNewPledgeToolStripMenuItem.Size = new Size(212, 26);
      this.bankNewPledgeToolStripMenuItem.Text = "Bank New Pledge";
      this.bankNewPledgeToolStripMenuItem.Click += new EventHandler(this.bankNewPledgeToolStripMenuItem_Click);
      this.bankPledgeEditToolStripMenuItem1.Name = "bankPledgeEditToolStripMenuItem1";
      this.bankPledgeEditToolStripMenuItem1.Size = new Size(212, 26);
      this.bankPledgeEditToolStripMenuItem1.Text = "Bank Pledge Edit";
      this.bankPledgeEditToolStripMenuItem1.Click += new EventHandler(this.bankPledgeEditToolStripMenuItem1_Click);
      this.bankReleaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.bankReleaseToolStripMenuItem1,
        (ToolStripItem) this.undoRedemptionToolStripMenuItem1,
        (ToolStripItem) this.bankReleaseEditToolStripMenuItem
      });
      this.bankReleaseToolStripMenuItem.Name = "bankReleaseToolStripMenuItem";
      this.bankReleaseToolStripMenuItem.Size = new Size(325, 26);
      this.bankReleaseToolStripMenuItem.Text = "Bank Release";
      this.bankReleaseToolStripMenuItem.Click += new EventHandler(this.bankReleaseToolStripMenuItem_Click);
      this.bankReleaseToolStripMenuItem1.Name = "bankReleaseToolStripMenuItem1";
      this.bankReleaseToolStripMenuItem1.Size = new Size(218, 26);
      this.bankReleaseToolStripMenuItem1.Text = "Bank Release";
      this.bankReleaseToolStripMenuItem1.Click += new EventHandler(this.bankReleaseToolStripMenuItem1_Click);
      this.undoRedemptionToolStripMenuItem1.Name = "undoRedemptionToolStripMenuItem1";
      this.undoRedemptionToolStripMenuItem1.Size = new Size(218, 26);
      this.undoRedemptionToolStripMenuItem1.Text = "Undo Redemption";
      this.undoRedemptionToolStripMenuItem1.Click += new EventHandler(this.undoRedemptionToolStripMenuItem1_Click);
      this.bankReleaseEditToolStripMenuItem.Name = "bankReleaseEditToolStripMenuItem";
      this.bankReleaseEditToolStripMenuItem.Size = new Size(218, 26);
      this.bankReleaseEditToolStripMenuItem.Text = "Bank Release Edit";
      this.bankReleaseEditToolStripMenuItem.Click += new EventHandler(this.bankReleaseEditToolStripMenuItem_Click);
      this.khaathoToolStripMenuItem.Name = "khaathoToolStripMenuItem";
      this.khaathoToolStripMenuItem.Size = new Size(325, 26);
      this.khaathoToolStripMenuItem.Text = "Khaatho";
      this.khaathoToolStripMenuItem.Click += new EventHandler(this.khaathoToolStripMenuItem_Click);
      this.viewKhaathoToolStripMenuItem.Name = "viewKhaathoToolStripMenuItem";
      this.viewKhaathoToolStripMenuItem.Size = new Size(325, 26);
      this.viewKhaathoToolStripMenuItem.Text = "View khaatho";
      this.viewKhaathoToolStripMenuItem.Click += new EventHandler(this.viewKhaathoToolStripMenuItem_Click);
      this.bankReportsToolStripMenuItem.Name = "bankReportsToolStripMenuItem";
      this.bankReportsToolStripMenuItem.Size = new Size(325, 26);
      this.bankReportsToolStripMenuItem.Text = "Bank Reports";
      this.bankReportsToolStripMenuItem.Click += new EventHandler(this.bankReportsToolStripMenuItem_Click);
      this.outsidePledgeListToolStripMenuItem.Name = "outsidePledgeListToolStripMenuItem";
      this.outsidePledgeListToolStripMenuItem.Size = new Size(325, 26);
      this.outsidePledgeListToolStripMenuItem.Text = "Outside Pledge List";
      this.outsidePledgeListToolStripMenuItem.Click += new EventHandler(this.outsidePledgeListToolStripMenuItem_Click);
      this.jewelsReleasedButStillInBankToolStripMenuItem1.Name = "jewelsReleasedButStillInBankToolStripMenuItem1";
      this.jewelsReleasedButStillInBankToolStripMenuItem1.Size = new Size(325, 26);
      this.jewelsReleasedButStillInBankToolStripMenuItem1.Text = "Jewels Released But Still in Bank";
      this.jewelsReleasedButStillInBankToolStripMenuItem1.Click += new EventHandler(this.jewelsReleasedButStillInBankToolStripMenuItem1_Click);
      this.jewelleryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.shopDetailsToolStripMenuItem1,
        (ToolStripItem) this.rateMasterToolStripMenuItem,
        (ToolStripItem) this.itemsNamesMasterToolStripMenuItem,
        (ToolStripItem) this.itemTypeMasterToolStripMenuItem,
        (ToolStripItem) this.metalMasterToolStripMenuItem,
        (ToolStripItem) this.purityMasterToolStripMenuItem,
        (ToolStripItem) this.newSaleToolStripMenuItem,
        (ToolStripItem) this.billNumberSettingsToolStripMenuItem,
        (ToolStripItem) this.salesReportToolStripMenuItem
      });
      this.jewelleryToolStripMenuItem.Name = "jewelleryToolStripMenuItem";
      this.jewelleryToolStripMenuItem.Size = new Size(89, 25);
      this.jewelleryToolStripMenuItem.Text = "Jewellery";
      this.shopDetailsToolStripMenuItem1.Name = "shopDetailsToolStripMenuItem1";
      this.shopDetailsToolStripMenuItem1.Size = new Size(233, 26);
      this.shopDetailsToolStripMenuItem1.Text = "ShopDetails";
      this.shopDetailsToolStripMenuItem1.Click += new EventHandler(this.shopDetailsToolStripMenuItem1_Click);
      this.rateMasterToolStripMenuItem.Name = "rateMasterToolStripMenuItem";
      this.rateMasterToolStripMenuItem.Size = new Size(233, 26);
      this.rateMasterToolStripMenuItem.Text = "RateMaster";
      this.rateMasterToolStripMenuItem.Click += new EventHandler(this.rateMasterToolStripMenuItem_Click);
      this.itemsNamesMasterToolStripMenuItem.Name = "itemsNamesMasterToolStripMenuItem";
      this.itemsNamesMasterToolStripMenuItem.Size = new Size(233, 26);
      this.itemsNamesMasterToolStripMenuItem.Text = "Items Names Master";
      this.itemsNamesMasterToolStripMenuItem.Click += new EventHandler(this.itemsNamesMasterToolStripMenuItem_Click);
      this.itemTypeMasterToolStripMenuItem.Name = "itemTypeMasterToolStripMenuItem";
      this.itemTypeMasterToolStripMenuItem.Size = new Size(233, 26);
      this.itemTypeMasterToolStripMenuItem.Text = "Item Type Master";
      this.itemTypeMasterToolStripMenuItem.Click += new EventHandler(this.itemTypeMasterToolStripMenuItem_Click);
      this.metalMasterToolStripMenuItem.Name = "metalMasterToolStripMenuItem";
      this.metalMasterToolStripMenuItem.Size = new Size(233, 26);
      this.metalMasterToolStripMenuItem.Text = "Metal Master";
      this.metalMasterToolStripMenuItem.Click += new EventHandler(this.metalMasterToolStripMenuItem_Click);
      this.purityMasterToolStripMenuItem.Name = "purityMasterToolStripMenuItem";
      this.purityMasterToolStripMenuItem.Size = new Size(233, 26);
      this.purityMasterToolStripMenuItem.Text = "Purity Master";
      this.purityMasterToolStripMenuItem.Click += new EventHandler(this.purityMasterToolStripMenuItem_Click);
      this.newSaleToolStripMenuItem.Name = "newSaleToolStripMenuItem";
      this.newSaleToolStripMenuItem.Size = new Size(233, 26);
      this.newSaleToolStripMenuItem.Text = "New Sale";
      this.newSaleToolStripMenuItem.Click += new EventHandler(this.newSaleToolStripMenuItem_Click);
      this.billNumberSettingsToolStripMenuItem.Name = "billNumberSettingsToolStripMenuItem";
      this.billNumberSettingsToolStripMenuItem.Size = new Size(233, 26);
      this.billNumberSettingsToolStripMenuItem.Text = "Bill Number Settings";
      this.billNumberSettingsToolStripMenuItem.Click += new EventHandler(this.billNumberSettingsToolStripMenuItem_Click);
      this.salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
      this.salesReportToolStripMenuItem.Size = new Size(233, 26);
      this.salesReportToolStripMenuItem.Text = "Sales Report";
      this.salesReportToolStripMenuItem.Click += new EventHandler(this.salesReportToolStripMenuItem_Click);
      this.accountsToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.accountsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.voucherEntryToolStripMenuItem,
        (ToolStripItem) this.ledgerDetailsToolStripMenuItem,
        (ToolStripItem) this.voucherMasterToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.rokadToolStripMenuItem,
        (ToolStripItem) this.changeRokadDateToolStripMenuItem,
        (ToolStripItem) this.autoDeleteRokadToolStripMenuItem,
        (ToolStripItem) this.rokadReportsToolStripMenuItem,
        (ToolStripItem) this.printRokadToolStripMenuItem,
        (ToolStripItem) this.rokadReportsConsolidatedToolStripMenuItem,
        (ToolStripItem) this.changeOpeningBalanceToolStripMenuItem
      });
      this.accountsToolStripMenuItem.ForeColor = Color.MidnightBlue;
      this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
      this.accountsToolStripMenuItem.Size = new Size(94, 25);
      this.accountsToolStripMenuItem.Text = "Accounts";
      this.voucherEntryToolStripMenuItem.Name = "voucherEntryToolStripMenuItem";
      this.voucherEntryToolStripMenuItem.ShortcutKeys = Keys.F7;
      this.voucherEntryToolStripMenuItem.Size = new Size(299, 26);
      this.voucherEntryToolStripMenuItem.Text = "Voucher Entry";
      this.voucherEntryToolStripMenuItem.Click += new EventHandler(this.voucherEntryToolStripMenuItem_Click);
      this.ledgerDetailsToolStripMenuItem.Name = "ledgerDetailsToolStripMenuItem";
      this.ledgerDetailsToolStripMenuItem.Size = new Size(299, 26);
      this.ledgerDetailsToolStripMenuItem.Text = "Ledger Master";
      this.ledgerDetailsToolStripMenuItem.Click += new EventHandler(this.ledgerDetailsToolStripMenuItem_Click);
      this.voucherMasterToolStripMenuItem.Name = "voucherMasterToolStripMenuItem";
      this.voucherMasterToolStripMenuItem.Size = new Size(299, 26);
      this.voucherMasterToolStripMenuItem.Text = "VoucherMaster";
      this.voucherMasterToolStripMenuItem.Click += new EventHandler(this.voucherMasterToolStripMenuItem_Click);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(299, 26);
      this.toolStripMenuItem1.Text = "View Rokad";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click_1);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.ShortcutKeys = Keys.F9;
      this.toolStripMenuItem2.Size = new Size(299, 26);
      this.toolStripMenuItem2.Text = "Cash Book";
      this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click_1);
      this.rokadToolStripMenuItem.Name = "rokadToolStripMenuItem";
      this.rokadToolStripMenuItem.ShortcutKeys = Keys.F10;
      this.rokadToolStripMenuItem.Size = new Size(299, 26);
      this.rokadToolStripMenuItem.Text = "Rokad";
      this.rokadToolStripMenuItem.Click += new EventHandler(this.rokadToolStripMenuItem_Click);
      this.changeRokadDateToolStripMenuItem.Name = "changeRokadDateToolStripMenuItem";
      this.changeRokadDateToolStripMenuItem.Size = new Size(299, 26);
      this.changeRokadDateToolStripMenuItem.Text = "Change Rokad Date";
      this.changeRokadDateToolStripMenuItem.Click += new EventHandler(this.changeRokadDateToolStripMenuItem_Click);
      this.autoDeleteRokadToolStripMenuItem.Name = "autoDeleteRokadToolStripMenuItem";
      this.autoDeleteRokadToolStripMenuItem.Size = new Size(299, 26);
      this.autoDeleteRokadToolStripMenuItem.Text = "Auto Delete Rokad";
      this.autoDeleteRokadToolStripMenuItem.Click += new EventHandler(this.autoDeleteRokadToolStripMenuItem_Click);
      this.rokadReportsToolStripMenuItem.Name = "rokadReportsToolStripMenuItem";
      this.rokadReportsToolStripMenuItem.Size = new Size(299, 26);
      this.rokadReportsToolStripMenuItem.Text = "Rokad Reports";
      this.rokadReportsToolStripMenuItem.Click += new EventHandler(this.rokadReportsToolStripMenuItem_Click);
      this.printRokadToolStripMenuItem.Name = "printRokadToolStripMenuItem";
      this.printRokadToolStripMenuItem.Size = new Size(299, 26);
      this.printRokadToolStripMenuItem.Text = "Print Rokad";
      this.printRokadToolStripMenuItem.Click += new EventHandler(this.printRokadToolStripMenuItem_Click);
      this.rokadReportsConsolidatedToolStripMenuItem.Name = "rokadReportsConsolidatedToolStripMenuItem";
      this.rokadReportsConsolidatedToolStripMenuItem.Size = new Size(299, 26);
      this.rokadReportsConsolidatedToolStripMenuItem.Text = "Rokad Reports Consolidated";
      this.rokadReportsConsolidatedToolStripMenuItem.Click += new EventHandler(this.rokadReportsConsolidatedToolStripMenuItem_Click);
      this.changeOpeningBalanceToolStripMenuItem.Name = "changeOpeningBalanceToolStripMenuItem";
      this.changeOpeningBalanceToolStripMenuItem.Size = new Size(299, 26);
      this.changeOpeningBalanceToolStripMenuItem.Text = "Change opening Balance";
      this.changeOpeningBalanceToolStripMenuItem.Click += new EventHandler(this.changeOpeningBalanceToolStripMenuItem_Click);
      this.smsToolStripMenuItem1.BackColor = Color.Ivory;
      this.smsToolStripMenuItem1.BackgroundImageLayout = ImageLayout.None;
      this.smsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[17]
      {
        (ToolStripItem) this.smsMessagesToolStripMenuItem,
        (ToolStripItem) this.viewSentMessagesToolStripMenuItem,
        (ToolStripItem) this.tesingToolStripMenuItem,
        (ToolStripItem) this.form2ToolStripMenuItem,
        (ToolStripItem) this.formPLEDGEEToolStripMenuItem,
        (ToolStripItem) this.testingOldpledgeToolStripMenuItem,
        (ToolStripItem) this.emailToolStripMenuItem,
        (ToolStripItem) this.hELLOToolStripMenuItem,
        (ToolStripItem) this.newAaddCustomerToolStripMenuItem,
        (ToolStripItem) this.form4ToolStripMenuItem,
        (ToolStripItem) this.panelToolStripMenuItem,
        (ToolStripItem) this.asdfToolStripMenuItem,
        (ToolStripItem) this.fdsdfsdfToolStripMenuItem,
        (ToolStripItem) this.form9ToolStripMenuItem,
        (ToolStripItem) this.xmlSchemaToolStripMenuItem,
        (ToolStripItem) this.viewCustomerType2ToolStripMenuItem,
        (ToolStripItem) this.asdfasdfToolStripMenuItem
      });
      this.smsToolStripMenuItem1.ForeColor = Color.Navy;
      this.smsToolStripMenuItem1.Name = "smsToolStripMenuItem1";
      this.smsToolStripMenuItem1.Size = new Size(55, 25);
      this.smsToolStripMenuItem1.Text = "Sms";
      this.smsMessagesToolStripMenuItem.Name = "smsMessagesToolStripMenuItem";
      this.smsMessagesToolStripMenuItem.Size = new Size(239, 26);
      this.smsMessagesToolStripMenuItem.Text = "Sms Messages";
      this.smsMessagesToolStripMenuItem.Click += new EventHandler(this.smsMessagesToolStripMenuItem_Click);
      this.viewSentMessagesToolStripMenuItem.Name = "viewSentMessagesToolStripMenuItem";
      this.viewSentMessagesToolStripMenuItem.Size = new Size(239, 26);
      this.viewSentMessagesToolStripMenuItem.Text = "View Sent Messages";
      this.viewSentMessagesToolStripMenuItem.Click += new EventHandler(this.viewSentMessagesToolStripMenuItem_Click);
      this.tesingToolStripMenuItem.Name = "tesingToolStripMenuItem";
      this.tesingToolStripMenuItem.Size = new Size(239, 26);
      this.tesingToolStripMenuItem.Text = "tesing";
      this.tesingToolStripMenuItem.Click += new EventHandler(this.tesingToolStripMenuItem_Click);
      this.form2ToolStripMenuItem.Name = "form2ToolStripMenuItem";
      this.form2ToolStripMenuItem.Size = new Size(239, 26);
      this.form2ToolStripMenuItem.Text = "form2";
      this.form2ToolStripMenuItem.Click += new EventHandler(this.form2ToolStripMenuItem_Click_1);
      this.formPLEDGEEToolStripMenuItem.Name = "formPLEDGEEToolStripMenuItem";
      this.formPLEDGEEToolStripMenuItem.Size = new Size(239, 26);
      this.formPLEDGEEToolStripMenuItem.Text = "formPLEDGEE";
      this.formPLEDGEEToolStripMenuItem.Click += new EventHandler(this.formPLEDGEEToolStripMenuItem_Click);
      this.testingOldpledgeToolStripMenuItem.Name = "testingOldpledgeToolStripMenuItem";
      this.testingOldpledgeToolStripMenuItem.Size = new Size(239, 26);
      this.testingOldpledgeToolStripMenuItem.Text = "testing oldpledge";
      this.testingOldpledgeToolStripMenuItem.Click += new EventHandler(this.testingOldpledgeToolStripMenuItem_Click);
      this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
      this.emailToolStripMenuItem.Size = new Size(239, 26);
      this.emailToolStripMenuItem.Text = "Email";
      this.emailToolStripMenuItem.Click += new EventHandler(this.emailToolStripMenuItem_Click);
      this.hELLOToolStripMenuItem.Name = "hELLOToolStripMenuItem";
      this.hELLOToolStripMenuItem.Size = new Size(239, 26);
      this.hELLOToolStripMenuItem.Text = "hELLO";
      this.hELLOToolStripMenuItem.Click += new EventHandler(this.hELLOToolStripMenuItem_Click);
      this.newAaddCustomerToolStripMenuItem.Name = "newAaddCustomerToolStripMenuItem";
      this.newAaddCustomerToolStripMenuItem.Size = new Size(239, 26);
      this.newAaddCustomerToolStripMenuItem.Text = "new aadd customer";
      this.newAaddCustomerToolStripMenuItem.Click += new EventHandler(this.newAaddCustomerToolStripMenuItem_Click);
      this.form4ToolStripMenuItem.Name = "form4ToolStripMenuItem";
      this.form4ToolStripMenuItem.Size = new Size(239, 26);
      this.form4ToolStripMenuItem.Text = "form4";
      this.form4ToolStripMenuItem.Click += new EventHandler(this.form4ToolStripMenuItem_Click_1);
      this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
      this.panelToolStripMenuItem.Size = new Size(239, 26);
      this.panelToolStripMenuItem.Text = "panel";
      this.panelToolStripMenuItem.Click += new EventHandler(this.panelToolStripMenuItem_Click);
      this.asdfToolStripMenuItem.Name = "asdfToolStripMenuItem";
      this.asdfToolStripMenuItem.Size = new Size(239, 26);
      this.asdfToolStripMenuItem.Text = "asdf";
      this.asdfToolStripMenuItem.Click += new EventHandler(this.asdfToolStripMenuItem_Click);
      this.fdsdfsdfToolStripMenuItem.Name = "fdsdfsdfToolStripMenuItem";
      this.fdsdfsdfToolStripMenuItem.Size = new Size(239, 26);
      this.fdsdfsdfToolStripMenuItem.Text = "form6";
      this.fdsdfsdfToolStripMenuItem.Click += new EventHandler(this.fdsdfsdfToolStripMenuItem_Click);
      this.form9ToolStripMenuItem.Name = "form9ToolStripMenuItem";
      this.form9ToolStripMenuItem.Size = new Size(239, 26);
      this.form9ToolStripMenuItem.Text = "form9";
      this.form9ToolStripMenuItem.Click += new EventHandler(this.form9ToolStripMenuItem_Click);
      this.xmlSchemaToolStripMenuItem.Name = "xmlSchemaToolStripMenuItem";
      this.xmlSchemaToolStripMenuItem.Size = new Size(239, 26);
      this.xmlSchemaToolStripMenuItem.Text = "xml schema";
      this.xmlSchemaToolStripMenuItem.Click += new EventHandler(this.xmlSchemaToolStripMenuItem_Click);
      this.viewCustomerType2ToolStripMenuItem.Name = "viewCustomerType2ToolStripMenuItem";
      this.viewCustomerType2ToolStripMenuItem.Size = new Size(239, 26);
      this.viewCustomerType2ToolStripMenuItem.Text = "view customer type 2";
      this.viewCustomerType2ToolStripMenuItem.Click += new EventHandler(this.viewCustomerType2ToolStripMenuItem_Click);
      this.asdfasdfToolStripMenuItem.Name = "asdfasdfToolStripMenuItem";
      this.asdfasdfToolStripMenuItem.Size = new Size(239, 26);
      this.asdfasdfToolStripMenuItem.Text = "asdfasdf";
      this.asdfasdfToolStripMenuItem.Click += new EventHandler(this.asdfasdfToolStripMenuItem_Click);
      this.printsToolStripMenuItem.BackColor = Color.Ivory;
      this.printsToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.printsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.duplicateBillToolStripMenuItem,
        (ToolStripItem) this.duplicateRedemptionBillToolStripMenuItem,
        (ToolStripItem) this.tOKENSToolStripMenuItem,
        (ToolStripItem) this.fORMD3ToolStripMenuItem,
        (ToolStripItem) this.formCToolStripMenuItem,
        (ToolStripItem) this.fORMDToolStripMenuItem,
        (ToolStripItem) this.printCustomerCopyBackSideToolStripMenuItem,
        (ToolStripItem) this.printOfficeCopyBackSideToolStripMenuItem,
        (ToolStripItem) this.printLastBilllCustomerCopyToolStripMenuItem,
        (ToolStripItem) this.printLastBillOfficeCopyToolStripMenuItem,
        (ToolStripItem) this.printLastRedemptionBillToolStripMenuItem,
        (ToolStripItem) this.printLastRedemptionBillFormD3ToolStripMenuItem
      });
      this.printsToolStripMenuItem.ForeColor = Color.Navy;
      this.printsToolStripMenuItem.Name = "printsToolStripMenuItem";
      this.printsToolStripMenuItem.Size = new Size(65, 25);
      this.printsToolStripMenuItem.Text = "Prints";
      this.duplicateBillToolStripMenuItem.Name = "duplicateBillToolStripMenuItem";
      this.duplicateBillToolStripMenuItem.ShortcutKeys = Keys.F1 | Keys.Control;
      this.duplicateBillToolStripMenuItem.Size = new Size(373, 26);
      this.duplicateBillToolStripMenuItem.Text = "Duplicate Bill";
      this.duplicateBillToolStripMenuItem.Click += new EventHandler(this.duplicateBillToolStripMenuItem_Click);
      this.duplicateRedemptionBillToolStripMenuItem.Name = "duplicateRedemptionBillToolStripMenuItem";
      this.duplicateRedemptionBillToolStripMenuItem.ShortcutKeys = Keys.F5 | Keys.Control;
      this.duplicateRedemptionBillToolStripMenuItem.Size = new Size(373, 26);
      this.duplicateRedemptionBillToolStripMenuItem.Text = "Duplicate Redemption Bill";
      this.duplicateRedemptionBillToolStripMenuItem.Click += new EventHandler(this.duplicateRedemptionBillToolStripMenuItem_Click);
      this.tOKENSToolStripMenuItem.Name = "tOKENSToolStripMenuItem";
      this.tOKENSToolStripMenuItem.Size = new Size(373, 26);
      this.tOKENSToolStripMenuItem.Text = "TOKENS";
      this.tOKENSToolStripMenuItem.Click += new EventHandler(this.tOKENSToolStripMenuItem_Click);
      this.fORMD3ToolStripMenuItem.Name = "fORMD3ToolStripMenuItem";
      this.fORMD3ToolStripMenuItem.Size = new Size(373, 26);
      this.fORMD3ToolStripMenuItem.Text = "FORM D-3";
      this.fORMD3ToolStripMenuItem.Click += new EventHandler(this.fORMD3ToolStripMenuItem_Click);
      this.formCToolStripMenuItem.Name = "formCToolStripMenuItem";
      this.formCToolStripMenuItem.Size = new Size(373, 26);
      this.formCToolStripMenuItem.Text = "FORM-C";
      this.formCToolStripMenuItem.Click += new EventHandler(this.fORMCToolStripMenuItem_Click);
      this.fORMDToolStripMenuItem.Name = "fORMDToolStripMenuItem";
      this.fORMDToolStripMenuItem.Size = new Size(373, 26);
      this.fORMDToolStripMenuItem.Text = "FORM-D";
      this.fORMDToolStripMenuItem.Click += new EventHandler(this.fORMDToolStripMenuItem_Click);
      this.printCustomerCopyBackSideToolStripMenuItem.Name = "printCustomerCopyBackSideToolStripMenuItem";
      this.printCustomerCopyBackSideToolStripMenuItem.Size = new Size(373, 26);
      this.printCustomerCopyBackSideToolStripMenuItem.Text = "Print Customer Copy Back Side";
      this.printCustomerCopyBackSideToolStripMenuItem.Click += new EventHandler(this.printCustomerCopyBackSideToolStripMenuItem_Click);
      this.printOfficeCopyBackSideToolStripMenuItem.Name = "printOfficeCopyBackSideToolStripMenuItem";
      this.printOfficeCopyBackSideToolStripMenuItem.Size = new Size(373, 26);
      this.printOfficeCopyBackSideToolStripMenuItem.Text = "Print Office Copy Back side";
      this.printOfficeCopyBackSideToolStripMenuItem.Click += new EventHandler(this.printOfficeCopyBackSideToolStripMenuItem_Click);
      this.printLastBilllCustomerCopyToolStripMenuItem.Name = "printLastBilllCustomerCopyToolStripMenuItem";
      this.printLastBilllCustomerCopyToolStripMenuItem.ShortcutKeys = Keys.F2 | Keys.Control;
      this.printLastBilllCustomerCopyToolStripMenuItem.Size = new Size(373, 26);
      this.printLastBilllCustomerCopyToolStripMenuItem.Text = "Print last billl - customer copy";
      this.printLastBilllCustomerCopyToolStripMenuItem.Click += new EventHandler(this.printLastBilllCustomerCopyToolStripMenuItem_Click);
      this.printLastBillOfficeCopyToolStripMenuItem.Name = "printLastBillOfficeCopyToolStripMenuItem";
      this.printLastBillOfficeCopyToolStripMenuItem.ShortcutKeys = Keys.F3 | Keys.Control;
      this.printLastBillOfficeCopyToolStripMenuItem.Size = new Size(373, 26);
      this.printLastBillOfficeCopyToolStripMenuItem.Text = "Print last bill - office copy";
      this.printLastBillOfficeCopyToolStripMenuItem.Click += new EventHandler(this.printLastBillOfficeCopyToolStripMenuItem_Click);
      this.printLastRedemptionBillToolStripMenuItem.Name = "printLastRedemptionBillToolStripMenuItem";
      this.printLastRedemptionBillToolStripMenuItem.ShortcutKeys = Keys.F6 | Keys.Control;
      this.printLastRedemptionBillToolStripMenuItem.Size = new Size(373, 26);
      this.printLastRedemptionBillToolStripMenuItem.Text = "Print last Redemption Bill";
      this.printLastRedemptionBillToolStripMenuItem.Click += new EventHandler(this.printLastRedemptionBillToolStripMenuItem_Click);
      this.printLastRedemptionBillFormD3ToolStripMenuItem.Name = "printLastRedemptionBillFormD3ToolStripMenuItem";
      this.printLastRedemptionBillFormD3ToolStripMenuItem.ShortcutKeys = Keys.F7 | Keys.Control;
      this.printLastRedemptionBillFormD3ToolStripMenuItem.Size = new Size(373, 26);
      this.printLastRedemptionBillFormD3ToolStripMenuItem.Text = "Print last Form D3";
      this.printLastRedemptionBillFormD3ToolStripMenuItem.Click += new EventHandler(this.printLastRedemptionBillFormD3ToolStripMenuItem_Click);
      this.optionsToolStripMenuItem.BackColor = Color.Ivory;
      this.optionsToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[22]
      {
        (ToolStripItem) this.shopDetailsToolStripMenuItem,
        (ToolStripItem) this.articlesToolStripMenuItem1,
        (ToolStripItem) this.loginDetailsToolStripMenuItem,
        (ToolStripItem) this.interestToolStripMenuItem,
        (ToolStripItem) this.shortcutsToolStripMenuItem,
        (ToolStripItem) this.gramRateToolStripMenuItem,
        (ToolStripItem) this.locationAndPincodeToolStripMenuItem,
        (ToolStripItem) this.menuSettingsToolStripMenuItem,
        (ToolStripItem) this.historyToolStripMenuItem,
        (ToolStripItem) this.reminderToolStripMenuItem,
        (ToolStripItem) this.autoBackupToolStripMenuItem,
        (ToolStripItem) this.billNumberSeriesToolStripMenuItem,
        (ToolStripItem) this.exceptionsToolStripMenuItem,
        (ToolStripItem) this.historyReminderSettingsToolStripMenuItem,
        (ToolStripItem) this.jewelPhotoToolStripMenuItem1,
        (ToolStripItem) this.printSettingsToolStripMenuItem,
        (ToolStripItem) this.notepadToolStripMenuItem,
        (ToolStripItem) this.inactivityMonitorToolStripMenuItem,
        (ToolStripItem) this.changeInterestToolStripMenuItem,
        (ToolStripItem) this.denominationToolStripMenuItem,
        (ToolStripItem) this.billerMasterToolStripMenuItem,
        (ToolStripItem) this.memberTypeMasterToolStripMenuItem
      });
      this.optionsToolStripMenuItem.ForeColor = Color.Navy;
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(82, 25);
      this.optionsToolStripMenuItem.Text = "Options";
      this.shopDetailsToolStripMenuItem.Name = "shopDetailsToolStripMenuItem";
      this.shopDetailsToolStripMenuItem.Size = new Size(276, 26);
      this.shopDetailsToolStripMenuItem.Text = "Shop Details";
      this.shopDetailsToolStripMenuItem.Click += new EventHandler(this.shopDetailsToolStripMenuItem_Click_1);
      this.articlesToolStripMenuItem1.Name = "articlesToolStripMenuItem1";
      this.articlesToolStripMenuItem1.Size = new Size(276, 26);
      this.articlesToolStripMenuItem1.Text = "Articles";
      this.articlesToolStripMenuItem1.Click += new EventHandler(this.articlesToolStripMenuItem1_Click);
      this.loginDetailsToolStripMenuItem.Name = "loginDetailsToolStripMenuItem";
      this.loginDetailsToolStripMenuItem.Size = new Size(276, 26);
      this.loginDetailsToolStripMenuItem.Text = "Login Details";
      this.loginDetailsToolStripMenuItem.Click += new EventHandler(this.loginDetailsToolStripMenuItem_Click);
      this.interestToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.interestSettingToolStripMenuItem,
        (ToolStripItem) this.iNTERESTSETTINGToolStripMenuItem1
      });
      this.interestToolStripMenuItem.Name = "interestToolStripMenuItem";
      this.interestToolStripMenuItem.Size = new Size(276, 26);
      this.interestToolStripMenuItem.Text = "Interest";
      this.interestSettingToolStripMenuItem.Name = "interestSettingToolStripMenuItem";
      this.interestSettingToolStripMenuItem.Size = new Size(253, 26);
      this.interestSettingToolStripMenuItem.Text = "Interest Setting";
      this.interestSettingToolStripMenuItem.Click += new EventHandler(this.interestSettingToolStripMenuItem_Click);
      this.iNTERESTSETTINGToolStripMenuItem1.Name = "iNTERESTSETTINGToolStripMenuItem1";
      this.iNTERESTSETTINGToolStripMenuItem1.Size = new Size(253, 26);
      this.iNTERESTSETTINGToolStripMenuItem1.Text = "INTEREST SETTING";
      this.iNTERESTSETTINGToolStripMenuItem1.Click += new EventHandler(this.iNTERESTSETTINGToolStripMenuItem1_Click);
      this.shortcutsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.calculatorToolStripMenuItem1,
        (ToolStripItem) this.deviceMangerToolStripMenuItem,
        (ToolStripItem) this.printersToolStripMenuItem
      });
      this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
      this.shortcutsToolStripMenuItem.Size = new Size(276, 26);
      this.shortcutsToolStripMenuItem.Text = "Shortcuts";
      this.calculatorToolStripMenuItem1.Name = "calculatorToolStripMenuItem1";
      this.calculatorToolStripMenuItem1.Size = new Size(192, 26);
      this.calculatorToolStripMenuItem1.Text = "Calculator";
      this.calculatorToolStripMenuItem1.Click += new EventHandler(this.calculatorToolStripMenuItem1_Click);
      this.deviceMangerToolStripMenuItem.Name = "deviceMangerToolStripMenuItem";
      this.deviceMangerToolStripMenuItem.Size = new Size(192, 26);
      this.deviceMangerToolStripMenuItem.Text = "Device Manger";
      this.deviceMangerToolStripMenuItem.Click += new EventHandler(this.deviceMangerToolStripMenuItem_Click);
      this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
      this.printersToolStripMenuItem.Size = new Size(192, 26);
      this.printersToolStripMenuItem.Text = "Printers";
      this.printersToolStripMenuItem.Click += new EventHandler(this.printersToolStripMenuItem_Click);
      this.gramRateToolStripMenuItem.Name = "gramRateToolStripMenuItem";
      this.gramRateToolStripMenuItem.Size = new Size(276, 26);
      this.gramRateToolStripMenuItem.Text = "GramRate";
      this.gramRateToolStripMenuItem.Click += new EventHandler(this.gramRateToolStripMenuItem_Click);
      this.locationAndPincodeToolStripMenuItem.Name = "locationAndPincodeToolStripMenuItem";
      this.locationAndPincodeToolStripMenuItem.Size = new Size(276, 26);
      this.locationAndPincodeToolStripMenuItem.Text = "Location and Pincode";
      this.locationAndPincodeToolStripMenuItem.Click += new EventHandler(this.locationAndPincodeToolStripMenuItem_Click);
      this.menuSettingsToolStripMenuItem.Name = "menuSettingsToolStripMenuItem";
      this.menuSettingsToolStripMenuItem.Size = new Size(276, 26);
      this.menuSettingsToolStripMenuItem.Text = "Menu Settings";
      this.menuSettingsToolStripMenuItem.Click += new EventHandler(this.menuSettingsToolStripMenuItem_Click);
      this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
      this.historyToolStripMenuItem.ShortcutKeys = Keys.H | Keys.Alt;
      this.historyToolStripMenuItem.Size = new Size(276, 26);
      this.historyToolStripMenuItem.Text = "History";
      this.historyToolStripMenuItem.Click += new EventHandler(this.historyToolStripMenuItem_Click);
      this.reminderToolStripMenuItem.Name = "reminderToolStripMenuItem";
      this.reminderToolStripMenuItem.Size = new Size(276, 26);
      this.reminderToolStripMenuItem.Text = "Reminder";
      this.reminderToolStripMenuItem.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.autoBackupToolStripMenuItem.Name = "autoBackupToolStripMenuItem";
      this.autoBackupToolStripMenuItem.Size = new Size(276, 26);
      this.autoBackupToolStripMenuItem.Text = "Auto Backup";
      this.autoBackupToolStripMenuItem.Click += new EventHandler(this.autoBackupToolStripMenuItem_Click);
      this.billNumberSeriesToolStripMenuItem.Name = "billNumberSeriesToolStripMenuItem";
      this.billNumberSeriesToolStripMenuItem.Size = new Size(276, 26);
      this.billNumberSeriesToolStripMenuItem.Text = "Bill Number Series";
      this.billNumberSeriesToolStripMenuItem.Click += new EventHandler(this.billNumberSeriesToolStripMenuItem_Click);
      this.exceptionsToolStripMenuItem.Name = "exceptionsToolStripMenuItem";
      this.exceptionsToolStripMenuItem.Size = new Size(276, 26);
      this.exceptionsToolStripMenuItem.Text = "Exceptions";
      this.exceptionsToolStripMenuItem.Click += new EventHandler(this.exceptionsToolStripMenuItem_Click);
      this.historyReminderSettingsToolStripMenuItem.Name = "historyReminderSettingsToolStripMenuItem";
      this.historyReminderSettingsToolStripMenuItem.Size = new Size(276, 26);
      this.historyReminderSettingsToolStripMenuItem.Text = "History Reminder Settings";
      this.historyReminderSettingsToolStripMenuItem.Click += new EventHandler(this.historyReminderSettingsToolStripMenuItem_Click);
      this.jewelPhotoToolStripMenuItem1.Name = "jewelPhotoToolStripMenuItem1";
      this.jewelPhotoToolStripMenuItem1.Size = new Size(276, 26);
      this.jewelPhotoToolStripMenuItem1.Text = "Jewel Photo";
      this.jewelPhotoToolStripMenuItem1.Click += new EventHandler(this.jewelPhotoToolStripMenuItem1_Click);
      this.printSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.articlesSettingsToolStripMenuItem,
        (ToolStripItem) this.generalSettingsToolStripMenuItem,
        (ToolStripItem) this.interestSettingsToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.customerSettingsToolStripMenuItem
      });
      this.printSettingsToolStripMenuItem.Name = "printSettingsToolStripMenuItem";
      this.printSettingsToolStripMenuItem.Size = new Size(276, 26);
      this.printSettingsToolStripMenuItem.Text = "Settings";
      this.articlesSettingsToolStripMenuItem.Name = "articlesSettingsToolStripMenuItem";
      this.articlesSettingsToolStripMenuItem.Size = new Size(217, 26);
      this.articlesSettingsToolStripMenuItem.Text = "Articles Settings";
      this.articlesSettingsToolStripMenuItem.Click += new EventHandler(this.articlesSettingsToolStripMenuItem_Click);
      this.generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
      this.generalSettingsToolStripMenuItem.Size = new Size(217, 26);
      this.generalSettingsToolStripMenuItem.Text = "General Settings";
      this.generalSettingsToolStripMenuItem.Click += new EventHandler(this.generalSettingsToolStripMenuItem_Click);
      this.interestSettingsToolStripMenuItem.Name = "interestSettingsToolStripMenuItem";
      this.interestSettingsToolStripMenuItem.Size = new Size(217, 26);
      this.interestSettingsToolStripMenuItem.Text = "Interest Settings";
      this.interestSettingsToolStripMenuItem.Click += new EventHandler(this.interestSettingsToolStripMenuItem_Click);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(217, 26);
      this.toolStripMenuItem3.Text = "Admin Settings";
      this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
      this.customerSettingsToolStripMenuItem.Name = "customerSettingsToolStripMenuItem";
      this.customerSettingsToolStripMenuItem.Size = new Size(217, 26);
      this.customerSettingsToolStripMenuItem.Text = "Customer Settings";
      this.customerSettingsToolStripMenuItem.Click += new EventHandler(this.customerSettingsToolStripMenuItem_Click);
      this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
      this.notepadToolStripMenuItem.Size = new Size(276, 26);
      this.notepadToolStripMenuItem.Text = "Notepad";
      this.notepadToolStripMenuItem.Click += new EventHandler(this.notepadToolStripMenuItem_Click);
      this.inactivityMonitorToolStripMenuItem.Name = "inactivityMonitorToolStripMenuItem";
      this.inactivityMonitorToolStripMenuItem.Size = new Size(276, 26);
      this.inactivityMonitorToolStripMenuItem.Text = "Inactivity Monitor";
      this.inactivityMonitorToolStripMenuItem.Click += new EventHandler(this.inactivityMonitorToolStripMenuItem_Click);
      this.changeInterestToolStripMenuItem.Name = "changeInterestToolStripMenuItem";
      this.changeInterestToolStripMenuItem.Size = new Size(276, 26);
      this.changeInterestToolStripMenuItem.Text = "Change Interest";
      this.changeInterestToolStripMenuItem.Click += new EventHandler(this.changeInterestToolStripMenuItem_Click);
      this.denominationToolStripMenuItem.Name = "denominationToolStripMenuItem";
      this.denominationToolStripMenuItem.Size = new Size(276, 26);
      this.denominationToolStripMenuItem.Text = "Denomination";
      this.denominationToolStripMenuItem.Click += new EventHandler(this.denominationToolStripMenuItem_Click);
      this.billerMasterToolStripMenuItem.Name = "billerMasterToolStripMenuItem";
      this.billerMasterToolStripMenuItem.Size = new Size(276, 26);
      this.billerMasterToolStripMenuItem.Text = "Biller Master";
      this.billerMasterToolStripMenuItem.Click += new EventHandler(this.billerMasterToolStripMenuItem_Click);
      this.memberTypeMasterToolStripMenuItem.Name = "memberTypeMasterToolStripMenuItem";
      this.memberTypeMasterToolStripMenuItem.Size = new Size(276, 26);
      this.memberTypeMasterToolStripMenuItem.Text = "Member Type master";
      this.memberTypeMasterToolStripMenuItem.Click += new EventHandler(this.memberTypeMasterToolStripMenuItem_Click);
      this.aboutToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.aboutToolStripMenuItem.ForeColor = Color.MidnightBlue;
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(69, 25);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
      this.aboutToolStripMenuItem.DoubleClick += new EventHandler(this.aboutToolStripMenuItem_DoubleClick);
      this.exitToolStripMenuItem.BackColor = Color.Ivory;
      this.exitToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
      this.exitToolStripMenuItem.ForeColor = Color.Navy;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(51, 25);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.toolStrip1.BackColor = Color.Ivory;
      this.toolStrip1.BackgroundImageLayout = ImageLayout.Stretch;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip1.ImageScalingSize = new Size(25, 25);
      this.toolStrip1.Items.AddRange(new ToolStripItem[22]
      {
        (ToolStripItem) this.tslRemiinder,
        (ToolStripItem) this.toolStripLabel2,
        (ToolStripItem) this.toolStripLabel3,
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.tslAutoEntryRokad,
        (ToolStripItem) this.tscbShopCode,
        (ToolStripItem) this.toolStripLabel5,
        (ToolStripItem) this.tstbBillingDate,
        (ToolStripItem) this.toolStripLabel4,
        (ToolStripItem) this.tscbBillerName,
        (ToolStripItem) this.toolStripLabel6,
        (ToolStripItem) this.toolStripButton2,
        (ToolStripItem) this.toolStripButton3,
        (ToolStripItem) this.toolStripButton4,
        (ToolStripItem) this.toolStripButton5,
        (ToolStripItem) this.toolStripButton6,
        (ToolStripItem) this.toolStripButton7,
        (ToolStripItem) this.toolStripButton8,
        (ToolStripItem) this.toolStripButton9,
        (ToolStripItem) this.tslFingerPrint,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton20
      });
      this.toolStrip1.Location = new Point(0, 29);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1202, 32);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      this.tslRemiinder.Name = "tslRemiinder";
      this.tslRemiinder.Size = new Size(70, 29);
      this.tslRemiinder.Text = "Reminder :  ";
      this.tslRemiinder.Click += new EventHandler(this.toolStripLabel1_Click);
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new Size(0, 29);
      this.toolStripLabel2.Click += new EventHandler(this.toolStripLabel2_Click);
      this.toolStripLabel3.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.toolStripLabel3.Name = "toolStripLabel3";
      this.toolStripLabel3.Size = new Size(0, 29);
      this.toolStripLabel3.TextAlign = ContentAlignment.MiddleRight;
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = (Image) PawnManagement.Properties.Resources.plus;
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(29, 29);
      this.toolStripButton1.Text = "toolStripButton1";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.tslAutoEntryRokad.Name = "tslAutoEntryRokad";
      this.tslAutoEntryRokad.Size = new Size(0, 29);
      this.tslAutoEntryRokad.Click += new EventHandler(this.tslAutoEntryRokad_Click);
      this.tscbShopCode.Alignment = ToolStripItemAlignment.Right;
      this.tscbShopCode.Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tscbShopCode.Name = "tscbShopCode";
      this.tscbShopCode.Size = new Size(201, 32);
      this.tscbShopCode.KeyPress += new KeyPressEventHandler(this.tscbShopCode_KeyPress);
      this.toolStripLabel5.Alignment = ToolStripItemAlignment.Right;
      this.toolStripLabel5.Name = "toolStripLabel5";
      this.toolStripLabel5.Size = new Size(87, 29);
      this.toolStripLabel5.Text = "Default License";
      this.tstbBillingDate.Alignment = ToolStripItemAlignment.Right;
      this.tstbBillingDate.AutoCompleteCustomSource.AddRange(new string[1]
      {
        "PRINT LAST BILL"
      });
      this.tstbBillingDate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tstbBillingDate.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tstbBillingDate.Name = "tstbBillingDate";
      this.tstbBillingDate.Size = new Size(75, 32);
      this.tstbBillingDate.KeyDown += new KeyEventHandler(this.toolStripTextBox1_KeyDown);
      this.tstbBillingDate.TextChanged += new EventHandler(this.tstbBillingDate_TextChanged);
      this.toolStripLabel4.Alignment = ToolStripItemAlignment.Right;
      this.toolStripLabel4.Name = "toolStripLabel4";
      this.toolStripLabel4.Size = new Size(67, 29);
      this.toolStripLabel4.Text = "Billing Date";
      this.tscbBillerName.Alignment = ToolStripItemAlignment.Right;
      this.tscbBillerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tscbBillerName.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.tscbBillerName.FlatStyle = FlatStyle.Standard;
      this.tscbBillerName.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tscbBillerName.Name = "tscbBillerName";
      this.tscbBillerName.Size = new Size(201, 32);
      this.tscbBillerName.KeyPress += new KeyPressEventHandler(this.tscbBillerName_KeyPress);
      this.tscbBillerName.Validating += new CancelEventHandler(this.tscbBillerName_Validating);
      this.tscbBillerName.TextChanged += new EventHandler(this.tscbBillerName_TextChanged);
      this.toolStripLabel6.Alignment = ToolStripItemAlignment.Right;
      this.toolStripLabel6.Name = "toolStripLabel6";
      this.toolStripLabel6.Size = new Size(68, 29);
      this.toolStripLabel6.Text = "Biller Name";
      this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton2.Image = (Image) PawnManagement.Properties.Resources.unnamed;
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(29, 29);
      this.toolStripButton2.Text = "Settings";
      this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
      this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton3.Image = (Image) componentResourceManager.GetObject("toolStripButton3.Image");
      this.toolStripButton3.ImageTransparentColor = Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new Size(29, 29);
      this.toolStripButton3.Text = "Calculator";
      this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
      this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(29, 29);
      this.toolStripButton4.Text = "New Text Document";
      this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
      this.toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton5.Image = (Image) PawnManagement.Properties.Resources.excel1;
      this.toolStripButton5.ImageTransparentColor = Color.Magenta;
      this.toolStripButton5.Name = "toolStripButton5";
      this.toolStripButton5.Size = new Size(29, 29);
      this.toolStripButton5.Text = "Excel";
      this.toolStripButton5.Click += new EventHandler(this.toolStripButton5_Click);
      this.toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton6.Image = (Image) PawnManagement.Properties.Resources.winword;
      this.toolStripButton6.ImageTransparentColor = Color.Magenta;
      this.toolStripButton6.Name = "toolStripButton6";
      this.toolStripButton6.Size = new Size(29, 29);
      this.toolStripButton6.Text = "Word";
      this.toolStripButton6.Click += new EventHandler(this.toolStripButton6_Click);
      this.toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton7.Image = (Image) componentResourceManager.GetObject("toolStripButton7.Image");
      this.toolStripButton7.ImageTransparentColor = Color.Magenta;
      this.toolStripButton7.Name = "toolStripButton7";
      this.toolStripButton7.Size = new Size(29, 29);
      this.toolStripButton7.Text = "MsPaint";
      this.toolStripButton7.Click += new EventHandler(this.toolStripButton7_Click);
      this.toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton8.Image = (Image) PawnManagement.Properties.Resources.command;
      this.toolStripButton8.ImageTransparentColor = Color.Magenta;
      this.toolStripButton8.Name = "toolStripButton8";
      this.toolStripButton8.Size = new Size(29, 29);
      this.toolStripButton8.Text = "Command";
      this.toolStripButton8.Click += new EventHandler(this.toolStripButton8_Click);
      this.toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton9.Image = (Image) componentResourceManager.GetObject("toolStripButton9.Image");
      this.toolStripButton9.ImageTransparentColor = Color.Magenta;
      this.toolStripButton9.Name = "toolStripButton9";
      this.toolStripButton9.Size = new Size(29, 29);
      this.toolStripButton9.Text = "toolStripButton9";
      this.toolStripButton9.Click += new EventHandler(this.toolStripButton9_Click);
      this.tslFingerPrint.Name = "tslFingerPrint";
      this.tslFingerPrint.Size = new Size(0, 29);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 32);
      this.toolStripButton20.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton20.Image = (Image) componentResourceManager.GetObject("toolStripButton20.Image");
      this.toolStripButton20.ImageTransparentColor = Color.Magenta;
      this.toolStripButton20.Name = "toolStripButton20";
      this.toolStripButton20.Size = new Size(29, 29);
      this.toolStripButton20.Text = "toolStripButton9";
      this.toolStripButton20.Click += new EventHandler(this.toolStripButton20_Click);
      this.statusStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.tsslblCurrentDate,
        (ToolStripItem) this.toolStripStatusLabel2,
        (ToolStripItem) this.slblAutoDeleteRokad,
        (ToolStripItem) this.slblAutoBackUp,
        (ToolStripItem) this.toolStripStatusLabel1,
        (ToolStripItem) this.slblRokadDate
      });
      this.statusStrip1.Location = new Point(0, 609);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(1202, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      this.tsslblCurrentDate.BackColor = Color.Transparent;
      this.tsslblCurrentDate.BackgroundImage = (Image) PawnManagement.Properties.Resources.GREYGRADIENTHORIZONTAL;
      this.tsslblCurrentDate.BackgroundImageLayout = ImageLayout.Stretch;
      this.tsslblCurrentDate.Name = "tsslblCurrentDate";
      this.tsslblCurrentDate.Size = new Size(0, 17);
      this.toolStripStatusLabel2.BackgroundImage = (Image) componentResourceManager.GetObject("toolStripStatusLabel2.BackgroundImage");
      this.toolStripStatusLabel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new Size(458, 17);
      this.toolStripStatusLabel2.Spring = true;
      this.toolStripStatusLabel2.Text = "                           ";
      this.slblAutoDeleteRokad.BackgroundImage = (Image) componentResourceManager.GetObject("slblAutoDeleteRokad.BackgroundImage");
      this.slblAutoDeleteRokad.BackgroundImageLayout = ImageLayout.Stretch;
      this.slblAutoDeleteRokad.Name = "slblAutoDeleteRokad";
      this.slblAutoDeleteRokad.Size = new Size(103, 17);
      this.slblAutoDeleteRokad.Text = "Rokad not deleted";
      this.slblAutoBackUp.BackgroundImage = (Image) componentResourceManager.GetObject("slblAutoBackUp.BackgroundImage");
      this.slblAutoBackUp.BackgroundImageLayout = ImageLayout.Stretch;
      this.slblAutoBackUp.Name = "slblAutoBackUp";
      this.slblAutoBackUp.Size = new Size(152, 17);
      this.slblAutoBackUp.Text = "Please set autoBackUp path";
      this.toolStripStatusLabel1.BackgroundImage = (Image) componentResourceManager.GetObject("toolStripStatusLabel1.BackgroundImage");
      this.toolStripStatusLabel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(458, 17);
      this.toolStripStatusLabel1.Spring = true;
      this.slblRokadDate.BackgroundImage = (Image) componentResourceManager.GetObject("slblRokadDate.BackgroundImage");
      this.slblRokadDate.BackgroundImageLayout = ImageLayout.Stretch;
      this.slblRokadDate.Name = "slblRokadDate";
      this.slblRokadDate.Size = new Size(16, 17);
      this.slblRokadDate.Text = "   ";
      this.timer1.Interval = 1;
      this.timer1.Tick += new EventHandler(this.timer1_Tick_1);
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.pbFingerPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.pbFingerPrint.Location = new Point(727, 368);
      this.pbFingerPrint.Name = "pbFingerPrint";
      this.pbFingerPrint.Size = new Size(117, 117);
      this.pbFingerPrint.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbFingerPrint.TabIndex = 32;
      this.pbFingerPrint.TabStop = false;
      this.pbFingerPrint.Visible = false;
      this.ts2.Dock = DockStyle.Left;
      this.ts2.GripStyle = ToolStripGripStyle.Hidden;
      this.ts2.ImageScalingSize = new Size(32, 32);
      this.ts2.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.toolStripButton10,
        (ToolStripItem) this.toolStripButton11,
        (ToolStripItem) this.toolStripButton12,
        (ToolStripItem) this.toolStripButton15,
        (ToolStripItem) this.toolStripButton16,
        (ToolStripItem) this.toolStripButton17,
        (ToolStripItem) this.toolStripButton14,
        (ToolStripItem) this.toolStripButton13,
        (ToolStripItem) this.toolStripButton19,
        (ToolStripItem) this.toolStripButton18
      });
      this.ts2.Location = new Point(0, 61);
      this.ts2.Name = "ts2";
      this.ts2.Size = new Size(151, 647);
      this.ts2.TabIndex = 34;
      this.ts2.Text = "toolStrip2";
      this.ts2.Visible = false;
      this.toolStripButton10.Image = (Image) PawnManagement.Properties.Resources.unnamed;
      this.toolStripButton10.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton10.ImageTransparentColor = Color.Magenta;
      this.toolStripButton10.Name = "toolStripButton10";
      this.toolStripButton10.Size = new Size(148, 36);
      this.toolStripButton10.Text = "Settings";
      this.toolStripButton10.Click += new EventHandler(this.toolStripButton10_Click);
      this.toolStripButton11.Image = (Image) componentResourceManager.GetObject("toolStripButton11.Image");
      this.toolStripButton11.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton11.ImageTransparentColor = Color.Magenta;
      this.toolStripButton11.Name = "toolStripButton11";
      this.toolStripButton11.Size = new Size(148, 36);
      this.toolStripButton11.Text = "Calculator";
      this.toolStripButton11.Click += new EventHandler(this.toolStripButton11_Click);
      this.toolStripButton12.Image = (Image) componentResourceManager.GetObject("toolStripButton12.Image");
      this.toolStripButton12.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton12.ImageTransparentColor = Color.Magenta;
      this.toolStripButton12.Name = "toolStripButton12";
      this.toolStripButton12.Size = new Size(148, 36);
      this.toolStripButton12.Text = "New Text Document";
      this.toolStripButton12.Click += new EventHandler(this.toolStripButton12_Click);
      this.toolStripButton15.Image = (Image) componentResourceManager.GetObject("toolStripButton15.Image");
      this.toolStripButton15.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton15.ImageTransparentColor = Color.Magenta;
      this.toolStripButton15.Name = "toolStripButton15";
      this.toolStripButton15.Size = new Size(148, 36);
      this.toolStripButton15.Text = "MsPaint";
      this.toolStripButton15.Click += new EventHandler(this.toolStripButton15_Click);
      this.toolStripButton16.Image = (Image) PawnManagement.Properties.Resources.winword;
      this.toolStripButton16.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton16.ImageTransparentColor = Color.Magenta;
      this.toolStripButton16.Name = "toolStripButton16";
      this.toolStripButton16.Size = new Size(148, 36);
      this.toolStripButton16.Text = "Word";
      this.toolStripButton16.Click += new EventHandler(this.toolStripButton16_Click);
      this.toolStripButton17.Image = (Image) PawnManagement.Properties.Resources.excel1;
      this.toolStripButton17.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton17.ImageTransparentColor = Color.Magenta;
      this.toolStripButton17.Name = "toolStripButton17";
      this.toolStripButton17.Size = new Size(148, 36);
      this.toolStripButton17.Text = "Excel";
      this.toolStripButton17.Click += new EventHandler(this.toolStripButton17_Click);
      this.toolStripButton14.Image = (Image) componentResourceManager.GetObject("toolStripButton14.Image");
      this.toolStripButton14.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton14.ImageTransparentColor = Color.Magenta;
      this.toolStripButton14.Name = "toolStripButton14";
      this.toolStripButton14.Size = new Size(148, 36);
      this.toolStripButton14.Text = "Printers";
      this.toolStripButton14.Click += new EventHandler(this.toolStripButton14_Click);
      this.toolStripButton13.Image = (Image) componentResourceManager.GetObject("toolStripButton13.Image");
      this.toolStripButton13.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton13.ImageTransparentColor = Color.Magenta;
      this.toolStripButton13.Name = "toolStripButton13";
      this.toolStripButton13.Size = new Size(148, 36);
      this.toolStripButton13.Text = "Denomination";
      this.toolStripButton13.Click += new EventHandler(this.toolStripButton13_Click);
      this.toolStripButton19.Image = (Image) componentResourceManager.GetObject("toolStripButton19.Image");
      this.toolStripButton19.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton19.ImageTransparentColor = Color.Magenta;
      this.toolStripButton19.Name = "toolStripButton19";
      this.toolStripButton19.Size = new Size(148, 36);
      this.toolStripButton19.Text = "Redmtn Reports";
      this.toolStripButton19.Click += new EventHandler(this.toolStripButton19_Click);
      this.toolStripButton18.Image = (Image) componentResourceManager.GetObject("toolStripButton18.Image");
      this.toolStripButton18.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton18.ImageTransparentColor = Color.Magenta;
      this.toolStripButton18.Name = "toolStripButton18";
      this.toolStripButton18.Size = new Size(148, 36);
      this.toolStripButton18.Text = "Pledge Reports";
      this.toolStripButton18.Click += new EventHandler(this.toolStripButton18_Click);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new Size(348, 298);
      this.dataGridView1.TabIndex = 36;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.deletePledgeToolStripMenuItem1,
        (ToolStripItem) this.printCustomerCopyToolStripMenuItem,
        (ToolStripItem) this.printOfficeCopyToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(186, 70);
      this.deletePledgeToolStripMenuItem1.Name = "deletePledgeToolStripMenuItem1";
      this.deletePledgeToolStripMenuItem1.Size = new Size(185, 22);
      this.deletePledgeToolStripMenuItem1.Text = "Delete Pledge";
      this.deletePledgeToolStripMenuItem1.Click += new EventHandler(this.deletePledgeToolStripMenuItem1_Click);
      this.printCustomerCopyToolStripMenuItem.Name = "printCustomerCopyToolStripMenuItem";
      this.printCustomerCopyToolStripMenuItem.Size = new Size(185, 22);
      this.printCustomerCopyToolStripMenuItem.Text = "Print Customer Copy";
      this.printCustomerCopyToolStripMenuItem.Click += new EventHandler(this.printCustomerCopyToolStripMenuItem_Click);
      this.printOfficeCopyToolStripMenuItem.Name = "printOfficeCopyToolStripMenuItem";
      this.printOfficeCopyToolStripMenuItem.Size = new Size(185, 22);
      this.printOfficeCopyToolStripMenuItem.Text = "Print Office Copy";
      this.printOfficeCopyToolStripMenuItem.Click += new EventHandler(this.printOfficeCopyToolStripMenuItem_Click);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.Location = new Point(0, 0);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.RowHeadersVisible = false;
      this.dataGridView2.Size = new Size(348, 242);
      this.dataGridView2.TabIndex = 37;
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItem4,
        (ToolStripItem) this.toolStripMenuItem5
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(172, 48);
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(171, 22);
      this.toolStripMenuItem4.Text = "Undo Redemption";
      this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem4_Click);
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new Size(171, 22);
      this.toolStripMenuItem5.Text = "Print Bill";
      this.toolStripMenuItem5.Click += new EventHandler(this.toolStripMenuItem5_Click);
      this.splitContainer1.BorderStyle = BorderStyle.FixedSingle;
      this.splitContainer1.Dock = DockStyle.Right;
      this.splitContainer1.Location = new Point(852, 61);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = Orientation.Horizontal;
      this.splitContainer1.Panel1.Controls.Add((Control) this.dataGridView1);
      this.splitContainer1.Panel1MinSize = 100;
      this.splitContainer1.Panel2.Controls.Add((Control) this.dataGridView2);
      this.splitContainer1.Size = new Size(350, 548);
      this.splitContainer1.SplitterDistance = 300;
      this.splitContainer1.TabIndex = 39;
      this.splitContainer1.Visible = false;
      this.contextMenuStrip3.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.changeBackgroundToolStripMenuItem
      });
      this.contextMenuStrip3.Name = "contextMenuStrip3";
      this.contextMenuStrip3.Size = new Size(183, 26);
      this.contextMenuStrip3.Opening += new CancelEventHandler(this.contextMenuStrip3_Opening);
      this.changeBackgroundToolStripMenuItem.Name = "changeBackgroundToolStripMenuItem";
      this.changeBackgroundToolStripMenuItem.Size = new Size(182, 22);
      this.changeBackgroundToolStripMenuItem.Text = "Change Background";
      this.changeBackgroundToolStripMenuItem.Click += new EventHandler(this.changeBackgroundToolStripMenuItem_Click);
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.Orange;
      this.BackgroundImage = (Image) PawnManagement.Properties.Resources.blue_abstract_background_310971;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1202, 631);
      this.ContextMenuStrip = this.contextMenuStrip3;
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.ts2);
      this.Controls.Add((Control) this.pbFingerPrint);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.menuStrip1);
      this.ForeColor = Color.Navy;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (FormMain);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "PAWN STAR";
      this.TransparencyKey = Color.White;
      this.FormClosing += new FormClosingEventHandler(this.Main_FormClosing);
      this.Load += new EventHandler(this.Main_Load);
      this.MdiChildActivate += new EventHandler(this.FormMain_MdiChildActivate);
      this.Enter += new EventHandler(this.FormMain_Enter);
      this.KeyPress += new KeyPressEventHandler(this.FormMain_KeyPress);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((ISupportInitialize) this.pbFingerPrint).EndInit();
      this.ts2.ResumeLayout(false);
      this.ts2.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.contextMenuStrip2.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.contextMenuStrip3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class MyRenderer : ToolStripProfessionalRenderer
    {
      public MyRenderer()
        : base((ProfessionalColorTable) new FormMain.MyColors())
      {
      }
    }

    private class MyColors : ProfessionalColorTable
    {
      public override Color MenuItemSelected => Color.LightBlue;

      public override Color MenuItemSelectedGradientBegin => Color.LightGray;

      public override Color MenuItemSelectedGradientEnd => Color.White;
    }
  }
}
