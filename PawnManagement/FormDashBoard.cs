

using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormDashBoard : Form
  {
    private DataTable dtHistoryReminder = new DataTable();
    private DataTable dtreminder = new DataTable();
    private DataTable dtBankRenewalReminder = new DataTable();
    private DataTable dtPledgeExpiringThisMonth = new DataTable();
    private DataTable dtPledgeExpriringToday = new DataTable();
    private string formType = "";
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private TabControl tcDashBoard;
    private TabPage tbHistoryReminder;
    private DataGridView dgvHistoryReminder;
    private TabPage tpBankRenewalReminder;
    private DataGridView dgvBankRenewalReminder;
    private TabPage tpReminder;
    private DataGridView dgvReminder;
    private TabPage tpBankPledgeToBeReleasedToday;
    private DataGridView dgvBankPledgeToBeReleasedToday;
    private TabPage tpPledgeExpiringToday;
    private GlassButton btnSendSmsPledgeExpriringToday;
    private DataGridView dgvPledgeExpiringToday;
    private TabPage tpPledgeExpiringThisMonth;
    private GlassButton btnSendSms;
    private DataGridView dgvPledgeExpiringThisMonth;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem cALLToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;

    public FormDashBoard() => this.InitializeComponent();

    public FormDashBoard(string FORMTYPE)
    {
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    public FormDashBoard(DataTable dt) => this.InitializeComponent();

    private void tabPage1_Click(object sender, EventArgs e)
    {
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormDashBoard_Load(object sender, EventArgs e)
    {
      try
      {
        this.checkForHistoryReminder();
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvHistoryReminder);
        this.dgvHistoryReminder.DataSource = (object) this.dtHistoryReminder;
        this.checkForBankRenewalReminder();
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvBankRenewalReminder);
        this.dgvBankRenewalReminder.DataSource = (object) this.dtBankRenewalReminder;
        this.checkForReminder();
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvReminder);
        this.checkForBankPledgeToBeReleasedToday();
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvBankPledgeToBeReleasedToday);
        this.checkForPledgeExpiringToday();
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvPledgeExpiringToday);
        PawnManagementClass.formatDataGridViewBlue(ref this.dgvPledgeExpiringThisMonth);
        PawnManagementClass.formatButtonBlue(ref this.btnSendSms);
        this.checkForPledgeExpiringThisMonth();
        if (!(this.formType == "Reminder"))
          return;
        this.tcDashBoard.SelectTab(this.tpReminder);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form DashBoard.FormDashBoard_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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

    private void checkForHistoryReminderInHistoryTable(string selectedHistoryItems)
    {
      string strError = "";
      this.dtHistoryReminder = SQLHelper.GetDataTable("select * from  tblHistory where   (ActionPipe in(" + selectedHistoryItems + ")) and ( performedOn like '" + DateTime.Now.ToString("dd/MM/yyyy") + "%')", ref strError);
      if (!(strError != ""))
        return;
      PawnManagementClass.InsertIntoException("form DashBoard.checkForHistoryReminderInHistroryTable(string selectedhistoryItems)", strError, FormMain.username, DateTime.Now.ToString());
      PawnManagementClass.InsertIntoException("form DashBoard.getHistoryREminder()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in fetching the data from tabel history " + strError);
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
      this.dgvBankRenewalReminder.DataSource = (object) this.dtBankRenewalReminder;
    }

    private void checkForReminder()
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
      int num1 = DateTime.Now.Day;
      string str1 = num1.ToString();
      num1 = DateTime.Now.Month;
      string str2 = num1.ToString();
      OleDbParameter oleDbParameter = new OleDbParameter("ReminderTypeValueYearly", (object) (str1 + "," + str2));
      oleDbParameterList.Add(oleDbParameter);
      this.dtreminder = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForREminder()", strError, FormMain.username, DateTime.Now.ToString());
        int num2 = (int) MessageBox.Show(strError);
      }
      else
        this.dgvReminder.DataSource = (object) this.dtreminder;
    }

    private void checkForBankPledgeToBeReleasedToday()
    {
      try
      {
        string strError = "";
        string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where (BankCode is not null and BankCode <> '') and redemptiondate = @redemptionDate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        DataTable dataTable1 = new DataTable();
        List<OleDbParameter> oleDbParameterList = parameters;
        DateTime dateTime = DateTime.Now;
        dateTime = dateTime.AddDays(-1.0);
        OleDbParameter oleDbParameter = new OleDbParameter("redemptionDate", (object) dateTime.ToString("dd/MM/yyyy"));
        oleDbParameterList.Add(oleDbParameter);
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form DashBoard.checkForBankPledgeToBeReleasedToday", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the  bank pledge to be released today \n" + strError);
        }
        else
        {
          this.dgvBankPledgeToBeReleasedToday.DataSource = (object) dataTable2;
          this.dgvBankPledgeToBeReleasedToday.Columns["bankcode"].DisplayIndex = 2;
          this.dgvBankPledgeToBeReleasedToday.Columns["bankSerialNumber"].DisplayIndex = 3;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tpBankPledgeToBeReleasedToday_Click(object sender, EventArgs e)
    {
    }

    private void checkForPledgeExpiringToday()
    {
      string strError = "";
      string my_querry = "select p.customercode,c.cName as Name,c.CNo  as DoorNumber,c.caddr1 as Addr1,c.caddr2 as Addr2,cphone as PhoneNumber,ccell as AlternateNumber,c.caddr3 as Addr3,c.ccity as city,c.cpincode as pincode,p.BillNumber,p.BillDate,p.type,p.grossweight,p.deduction,p.netweight,p.amount,p.presentvalue,p.oldbillnumber,p.reminder,p.temp1 as interestrate,p.redeemed from tblpledge p left join tblcustomers c on p.customercode = c.cid where p.billdate = @billdate and p.redeemed = 'N' order by p.billnumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      List<OleDbParameter> oleDbParameterList = parameters;
      DateTime dateTime = DateTime.Now;
      dateTime = dateTime.AddYears(-1);
      OleDbParameter oleDbParameter = new OleDbParameter("billdate", (object) dateTime.ToString("dd/MM/yyyy"));
      oleDbParameterList.Add(oleDbParameter);
      this.dtPledgeExpriringToday = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForPledgeExpiringToday()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the  pledge expiring today \n" + strError);
      }
      else
        this.dgvPledgeExpiringToday.DataSource = (object) this.dtPledgeExpriringToday;
    }

    private void checkForPledgeExpiringThisMonth()
    {
      string strError = "";
      this.dtPledgeExpiringThisMonth = SQLHelper.GetDataTable("select p.customercode,c.cName as Name,c.CNo  as DoorNumber,c.caddr1 as Addr1,c.caddr2 as Addr2,cphone as PhoneNumber,ccell as AlternateNumber,c.caddr3 as Addr3,c.ccity as city,c.cpincode as pincode,p.BillNumber,p.BillDate,p.type,p.grossweight,p.deduction,p.netweight,p.amount,p.presentvalue,p.oldbillnumber,p.reminder,p.temp1 as interestrate,p.redeemed from tblpledge p left join tblcustomers c on p.customercode = c.cid where   month(p.billdate) = @month and year(p.billdate) = @year and p.redeemed = 'N' order by p.billnumber", new List<OleDbParameter>()
      {
        new OleDbParameter("month", (object) DateTime.Now.Month.ToString()),
        new OleDbParameter("year", (object) (DateTime.Now.Year - 1).ToString())
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForPledgeExpiringThisMonth()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the  pledge expiring this month \n" + strError);
      }
      else
        this.dgvPledgeExpiringThisMonth.DataSource = (object) this.dtPledgeExpiringThisMonth;
    }

    private void btnSendSms_Click(object sender, EventArgs e)
    {
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      FieldToBind.Add("customercode");
      FieldToBind.Add("Phonenumber");
      FieldToBind.Add("Name");
      FieldToBind.Add("billnumber");
      FieldToBind.Add("Amount");
      DataTable dtCustomers = this.getdatatabledtdata(this.dtPledgeExpiringThisMonth);
      formSendSms.LoadNotice(dtCustomers, "customerCode", "PhoneNumber", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
      this.checkForPledgeExpiringThisMonth();
    }

    private void btnSendSmsPledgeExpriringToday_Click(object sender, EventArgs e)
    {
      try
      {
        FormSendSMS formSendSms = new FormSendSMS();
        List<string> FieldToBind = new List<string>();
        foreach (DataColumn column in (InternalDataCollectionBase) this.dtPledgeExpriringToday.Columns)
          FieldToBind.Add(column.ColumnName);
        DataTable dtCustomers = this.getdatatabledtdata(this.dtPledgeExpriringToday);
        formSendSms.LoadNotice(dtCustomers, "customerCode", "PhoneNumber", FieldToBind);
        int num = (int) formSendSms.ShowDialog();
        this.checkForPledgeExpiringToday();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form dashBoard.btnSendSmsPledgeExpriringToday_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private DataTable getdatatabledtdata(DataTable dt2)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = dt2;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
      {
        if (row["PhoneNumber"].ToString().Length != 10 || !this.IsDigitsOnly(row["PhoneNumber"].ToString()))
          row.Delete();
      }
      return dataTable2;
    }

    private bool IsDigitsOnly(string str)
    {
      if (str == "")
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void cALLToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (sourceControl is DataGridView && (sourceControl as DataGridView).Rows.Count > 0)
      {
        int rowIndex = (sourceControl as DataGridView).CurrentCell.RowIndex;
        int num = (int) new FormCall((sourceControl as DataGridView).Rows[rowIndex].Cells["phoneNumber"].Value.ToString()).ShowDialog();
      }
    }

    private void dgvPledgeExpiringToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
    {
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.tcDashBoard = new TabControl();
      this.tbHistoryReminder = new TabPage();
      this.dgvHistoryReminder = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.cALLToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.tpBankRenewalReminder = new TabPage();
      this.dgvBankRenewalReminder = new DataGridView();
      this.tpReminder = new TabPage();
      this.dgvReminder = new DataGridView();
      this.tpBankPledgeToBeReleasedToday = new TabPage();
      this.dgvBankPledgeToBeReleasedToday = new DataGridView();
      this.tpPledgeExpiringToday = new TabPage();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.dgvPledgeExpiringToday = new DataGridView();
      this.btnSendSmsPledgeExpriringToday = new GlassButton();
      this.tpPledgeExpiringThisMonth = new TabPage();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.dgvPledgeExpiringThisMonth = new DataGridView();
      this.btnSendSms = new GlassButton();
      this.tableLayoutPanel1.SuspendLayout();
      this.tcDashBoard.SuspendLayout();
      this.tbHistoryReminder.SuspendLayout();
      ((ISupportInitialize) this.dgvHistoryReminder).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tpBankRenewalReminder.SuspendLayout();
      ((ISupportInitialize) this.dgvBankRenewalReminder).BeginInit();
      this.tpReminder.SuspendLayout();
      ((ISupportInitialize) this.dgvReminder).BeginInit();
      this.tpBankPledgeToBeReleasedToday.SuspendLayout();
      ((ISupportInitialize) this.dgvBankPledgeToBeReleasedToday).BeginInit();
      this.tpPledgeExpiringToday.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((ISupportInitialize) this.dgvPledgeExpiringToday).BeginInit();
      this.tpPledgeExpiringThisMonth.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ((ISupportInitialize) this.dgvPledgeExpiringThisMonth).BeginInit();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.tcDashBoard, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(1008, 636);
      this.tableLayoutPanel1.TabIndex = 6;
      this.tcDashBoard.Controls.Add((Control) this.tbHistoryReminder);
      this.tcDashBoard.Controls.Add((Control) this.tpBankRenewalReminder);
      this.tcDashBoard.Controls.Add((Control) this.tpReminder);
      this.tcDashBoard.Controls.Add((Control) this.tpBankPledgeToBeReleasedToday);
      this.tcDashBoard.Controls.Add((Control) this.tpPledgeExpiringToday);
      this.tcDashBoard.Controls.Add((Control) this.tpPledgeExpiringThisMonth);
      this.tcDashBoard.Dock = DockStyle.Fill;
      this.tcDashBoard.Location = new Point(3, 3);
      this.tcDashBoard.Name = "tcDashBoard";
      this.tcDashBoard.SelectedIndex = 0;
      this.tcDashBoard.Size = new Size(1002, 630);
      this.tcDashBoard.TabIndex = 5;
      this.tbHistoryReminder.Controls.Add((Control) this.dgvHistoryReminder);
      this.tbHistoryReminder.Location = new Point(4, 22);
      this.tbHistoryReminder.Name = "tbHistoryReminder";
      this.tbHistoryReminder.Padding = new Padding(3);
      this.tbHistoryReminder.Size = new Size(994, 604);
      this.tbHistoryReminder.TabIndex = 0;
      this.tbHistoryReminder.Text = "HISTORY REMINDER";
      this.tbHistoryReminder.UseVisualStyleBackColor = true;
      this.tbHistoryReminder.Click += new EventHandler(this.tabPage1_Click);
      this.dgvHistoryReminder.AllowUserToAddRows = false;
      this.dgvHistoryReminder.AllowUserToDeleteRows = false;
      this.dgvHistoryReminder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvHistoryReminder.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvHistoryReminder.Dock = DockStyle.Fill;
      this.dgvHistoryReminder.Location = new Point(3, 3);
      this.dgvHistoryReminder.Name = "dgvHistoryReminder";
      this.dgvHistoryReminder.ReadOnly = true;
      this.dgvHistoryReminder.Size = new Size(988, 598);
      this.dgvHistoryReminder.TabIndex = 0;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.cALLToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(151, 48);
      this.cALLToolStripMenuItem.Name = "cALLToolStripMenuItem";
      this.cALLToolStripMenuItem.Size = new Size(150, 22);
      this.cALLToolStripMenuItem.Text = "CALL";
      this.cALLToolStripMenuItem.Click += new EventHandler(this.cALLToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(150, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.tpBankRenewalReminder.Controls.Add((Control) this.dgvBankRenewalReminder);
      this.tpBankRenewalReminder.Location = new Point(4, 22);
      this.tpBankRenewalReminder.Name = "tpBankRenewalReminder";
      this.tpBankRenewalReminder.Padding = new Padding(3);
      this.tpBankRenewalReminder.Size = new Size(994, 604);
      this.tpBankRenewalReminder.TabIndex = 1;
      this.tpBankRenewalReminder.Text = "BANK RENEWAL REMINDER";
      this.tpBankRenewalReminder.UseVisualStyleBackColor = true;
      this.dgvBankRenewalReminder.AllowUserToAddRows = false;
      this.dgvBankRenewalReminder.AllowUserToDeleteRows = false;
      this.dgvBankRenewalReminder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvBankRenewalReminder.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvBankRenewalReminder.Dock = DockStyle.Fill;
      this.dgvBankRenewalReminder.Location = new Point(3, 3);
      this.dgvBankRenewalReminder.Name = "dgvBankRenewalReminder";
      this.dgvBankRenewalReminder.ReadOnly = true;
      this.dgvBankRenewalReminder.Size = new Size(988, 598);
      this.dgvBankRenewalReminder.TabIndex = 1;
      this.tpReminder.Controls.Add((Control) this.dgvReminder);
      this.tpReminder.Location = new Point(4, 22);
      this.tpReminder.Name = "tpReminder";
      this.tpReminder.Padding = new Padding(3);
      this.tpReminder.Size = new Size(994, 604);
      this.tpReminder.TabIndex = 2;
      this.tpReminder.Text = "REMINDER";
      this.tpReminder.UseVisualStyleBackColor = true;
      this.dgvReminder.AllowUserToAddRows = false;
      this.dgvReminder.AllowUserToDeleteRows = false;
      this.dgvReminder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvReminder.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvReminder.Dock = DockStyle.Fill;
      this.dgvReminder.Location = new Point(3, 3);
      this.dgvReminder.Name = "dgvReminder";
      this.dgvReminder.ReadOnly = true;
      this.dgvReminder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvReminder.Size = new Size(988, 598);
      this.dgvReminder.TabIndex = 1;
      this.tpBankPledgeToBeReleasedToday.Controls.Add((Control) this.dgvBankPledgeToBeReleasedToday);
      this.tpBankPledgeToBeReleasedToday.Location = new Point(4, 22);
      this.tpBankPledgeToBeReleasedToday.Name = "tpBankPledgeToBeReleasedToday";
      this.tpBankPledgeToBeReleasedToday.Padding = new Padding(3);
      this.tpBankPledgeToBeReleasedToday.Size = new Size(994, 604);
      this.tpBankPledgeToBeReleasedToday.TabIndex = 4;
      this.tpBankPledgeToBeReleasedToday.Text = "BANK PLEDGE TO BE RELEASED TODAY";
      this.tpBankPledgeToBeReleasedToday.UseVisualStyleBackColor = true;
      this.tpBankPledgeToBeReleasedToday.Click += new EventHandler(this.tpBankPledgeToBeReleasedToday_Click);
      this.dgvBankPledgeToBeReleasedToday.AllowUserToAddRows = false;
      this.dgvBankPledgeToBeReleasedToday.AllowUserToDeleteRows = false;
      this.dgvBankPledgeToBeReleasedToday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvBankPledgeToBeReleasedToday.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvBankPledgeToBeReleasedToday.Dock = DockStyle.Fill;
      this.dgvBankPledgeToBeReleasedToday.Location = new Point(3, 3);
      this.dgvBankPledgeToBeReleasedToday.Name = "dgvBankPledgeToBeReleasedToday";
      this.dgvBankPledgeToBeReleasedToday.ReadOnly = true;
      this.dgvBankPledgeToBeReleasedToday.Size = new Size(988, 598);
      this.dgvBankPledgeToBeReleasedToday.TabIndex = 2;
      this.tpPledgeExpiringToday.Controls.Add((Control) this.tableLayoutPanel2);
      this.tpPledgeExpiringToday.Location = new Point(4, 22);
      this.tpPledgeExpiringToday.Name = "tpPledgeExpiringToday";
      this.tpPledgeExpiringToday.Padding = new Padding(3);
      this.tpPledgeExpiringToday.Size = new Size(994, 604);
      this.tpPledgeExpiringToday.TabIndex = 5;
      this.tpPledgeExpiringToday.Text = "PLEDGE EXPIRING TODAY";
      this.tpPledgeExpiringToday.UseVisualStyleBackColor = true;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.Controls.Add((Control) this.dgvPledgeExpiringToday, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.btnSendSmsPledgeExpriringToday, 0, 1);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.80267f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.197325f));
      this.tableLayoutPanel2.Size = new Size(988, 598);
      this.tableLayoutPanel2.TabIndex = 7;
      this.tableLayoutPanel2.Paint += new PaintEventHandler(this.tableLayoutPanel2_Paint);
      this.dgvPledgeExpiringToday.AllowUserToAddRows = false;
      this.dgvPledgeExpiringToday.AllowUserToDeleteRows = false;
      this.dgvPledgeExpiringToday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPledgeExpiringToday.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPledgeExpiringToday.Dock = DockStyle.Fill;
      this.dgvPledgeExpiringToday.Location = new Point(3, 3);
      this.dgvPledgeExpiringToday.Name = "dgvPledgeExpiringToday";
      this.dgvPledgeExpiringToday.ReadOnly = true;
      this.dgvPledgeExpiringToday.Size = new Size(982, 536);
      this.dgvPledgeExpiringToday.TabIndex = 3;
      this.dgvPledgeExpiringToday.CellContentClick += new DataGridViewCellEventHandler(this.dgvPledgeExpiringToday_CellContentClick);
      this.btnSendSmsPledgeExpriringToday.BackColor = Color.LightBlue;
      this.btnSendSmsPledgeExpriringToday.FadeOnFocus = true;
      this.btnSendSmsPledgeExpriringToday.ForeColor = Color.MediumBlue;
      this.btnSendSmsPledgeExpriringToday.ForeColorOnFocus = Color.Red;
      this.btnSendSmsPledgeExpriringToday.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSendSmsPledgeExpriringToday.GlowColor = Color.White;
      ((ButtonBase) this.btnSendSmsPledgeExpriringToday).Image = (Image) Resources.sms;
      this.btnSendSmsPledgeExpriringToday.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSendSmsPledgeExpriringToday).Location = new Point(3, 545);
      ((Control) this.btnSendSmsPledgeExpriringToday).Name = "btnSendSmsPledgeExpriringToday";
      this.btnSendSmsPledgeExpriringToday.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSendSmsPledgeExpriringToday.ShineColor = Color.Transparent;
      ((Control) this.btnSendSmsPledgeExpriringToday).Size = new Size(137, 50);
      ((Control) this.btnSendSmsPledgeExpriringToday).TabIndex = 6;
      ((Control) this.btnSendSmsPledgeExpriringToday).Text = "SEND SMS";
      ((ButtonBase) this.btnSendSmsPledgeExpriringToday).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSendSmsPledgeExpriringToday).Click += new EventHandler(this.btnSendSmsPledgeExpriringToday_Click);
      this.tpPledgeExpiringThisMonth.Controls.Add((Control) this.tableLayoutPanel3);
      this.tpPledgeExpiringThisMonth.Location = new Point(4, 22);
      this.tpPledgeExpiringThisMonth.Name = "tpPledgeExpiringThisMonth";
      this.tpPledgeExpiringThisMonth.Padding = new Padding(3);
      this.tpPledgeExpiringThisMonth.Size = new Size(994, 604);
      this.tpPledgeExpiringThisMonth.TabIndex = 6;
      this.tpPledgeExpiringThisMonth.Text = "PLEDGE EXPIRING THIS MONTH";
      this.tpPledgeExpiringThisMonth.UseVisualStyleBackColor = true;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel3.Controls.Add((Control) this.dgvPledgeExpiringThisMonth, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.btnSendSms, 0, 1);
      this.tableLayoutPanel3.Dock = DockStyle.Fill;
      this.tableLayoutPanel3.Location = new Point(3, 3);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 91.13712f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.862876f));
      this.tableLayoutPanel3.Size = new Size(988, 598);
      this.tableLayoutPanel3.TabIndex = 6;
      this.dgvPledgeExpiringThisMonth.AllowUserToAddRows = false;
      this.dgvPledgeExpiringThisMonth.AllowUserToDeleteRows = false;
      this.dgvPledgeExpiringThisMonth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPledgeExpiringThisMonth.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPledgeExpiringThisMonth.Dock = DockStyle.Fill;
      this.dgvPledgeExpiringThisMonth.Location = new Point(3, 3);
      this.dgvPledgeExpiringThisMonth.Name = "dgvPledgeExpiringThisMonth";
      this.dgvPledgeExpiringThisMonth.ReadOnly = true;
      this.dgvPledgeExpiringThisMonth.Size = new Size(982, 538);
      this.dgvPledgeExpiringThisMonth.TabIndex = 4;
      this.btnSendSms.BackColor = Color.LightBlue;
      this.btnSendSms.FadeOnFocus = true;
      this.btnSendSms.ForeColor = Color.MediumBlue;
      this.btnSendSms.ForeColorOnFocus = Color.Red;
      this.btnSendSms.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSendSms.GlowColor = Color.White;
      ((ButtonBase) this.btnSendSms).Image = (Image) Resources.sms;
      ((ButtonBase) this.btnSendSms).ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSendSms.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSendSms).Location = new Point(3, 547);
      ((Control) this.btnSendSms).Name = "btnSendSms";
      this.btnSendSms.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSendSms.ShineColor = Color.Transparent;
      ((Control) this.btnSendSms).Size = new Size(137, 43);
      ((Control) this.btnSendSms).TabIndex = 5;
      ((Control) this.btnSendSms).Text = "SEND SMS";
      ((ButtonBase) this.btnSendSms).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSendSms).Click += new EventHandler(this.btnSendSms_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormDashBoard);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormDashBoard);
      this.Load += new EventHandler(this.FormDashBoard_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tcDashBoard.ResumeLayout(false);
      this.tbHistoryReminder.ResumeLayout(false);
      ((ISupportInitialize) this.dgvHistoryReminder).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tpBankRenewalReminder.ResumeLayout(false);
      ((ISupportInitialize) this.dgvBankRenewalReminder).EndInit();
      this.tpReminder.ResumeLayout(false);
      ((ISupportInitialize) this.dgvReminder).EndInit();
      this.tpBankPledgeToBeReleasedToday.ResumeLayout(false);
      ((ISupportInitialize) this.dgvBankPledgeToBeReleasedToday).EndInit();
      this.tpPledgeExpiringToday.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPledgeExpiringToday).EndInit();
      this.tpPledgeExpiringThisMonth.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPledgeExpiringThisMonth).EndInit();
      this.ResumeLayout(false);
    }
  }
}
