

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormSendSMS : Form
  {
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private string strADBLocation = "C:\\adb\\adb.exe";
    private DataTable dtrefreshGrid = new DataTable();
    private int formType = 0;
    private string _MobileField;
    private string customerCode;
    private List<string> _lstFields;
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxMessage;
    private Label lblSMSLength;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private DataGridView dataGridView2;
    private Label lblNumberOfContactsSelected;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem selectAlllToolStripMenuItem;
    private ToolStripMenuItem unSelectAllToolStripMenuItem;
    private HeaderPanel headerPanel5;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private HeaderPanel headerPanel2;

    public FormSendSMS()
    {
      try
      {
        this.InitializeComponent();
        this.lblSMSLength.Text = "";
        this.tbxMessage.MaxLength = 320;
        this.tbxMessage.Text = "  ";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.formsendsms", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public string MobileField
    {
      get => this._MobileField;
      set => this._MobileField = value;
    }

    public string CustomerCode
    {
      get => this.customerCode;
      set => this.customerCode = value;
    }

    public List<string> FieldsToShow
    {
      get => this._lstFields;
      set => this._lstFields = value;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.formType == 2)
        {
          this.sendNotice(this.FieldsToShow);
        }
        else
        {
          int num = 0;
          List<string> lstNumbers = new List<string>();
          foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
          {
            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower() == "true")
            {
              if (row.Cells[this.MobileField].Value != null && row.Cells[this.MobileField].Value.ToString() != "")
                lstNumbers.Add(row.Cells[this.MobileField].Value.ToString());
              ++num;
            }
          }
          if (num <= 25)
            this.sendNotice(lstNumbers);
          else if (DialogResult.Yes == MessageBox.Show("You have selected " + num.ToString() + " Contacts...which is not recommeded  ..Are you sure to send?", "You have selected " + num.ToString() + " Contacts...which is not recommeded  ..Are you sure to send?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            this.sendNotice(lstNumbers);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.button2_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxMessage_TextChanged(object sender, EventArgs e) => this.lblSMSLength.Text = "SMS Length: " + (object) this.tbxMessage.Text.Length + "/" + (this.tbxMessage.Text.Length > 160 ? (object) "320" : (object) "160") + " chars - " + (this.tbxMessage.Text.Length > 160 ? (object) "2" : (object) "1") + " message";

    public void LoadNotice(DataTable dtCustomers, string _MobileField, List<string> FieldToBind)
    {
      try
      {
        this.formType = 1;
        this.MobileField = _MobileField;
        this.FieldsToShow = FieldToBind;
        this.BindTable(dtCustomers);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form senesms.LoadNotice", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public void LoadNotice(
      DataTable dtCustomers,
      string CUSTOMERCODE,
      string _MobileField,
      List<string> FieldToBind)
    {
      try
      {
        this.formType = 1;
        this.CustomerCode = CUSTOMERCODE;
        this.MobileField = _MobileField;
        this.FieldsToShow = FieldToBind;
        this.BindTable(dtCustomers);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form senesms.LoadNotice", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public void LoadNotice(
      DataGridView dgvCustomers,
      string _MobileField,
      List<string> FieldToBind)
    {
      try
      {
        this.formType = 1;
        this.MobileField = _MobileField;
        this.FieldsToShow = FieldToBind;
        this.BindTable(dgvCustomers);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.loadnotice", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void BindTable(DataTable dtCustomers)
    {
      try
      {
        this.dataGridView1.AutoGenerateColumns = false;
        this.dataGridView1.ColumnCount = this.FieldsToShow.Count;
        for (int index = 0; index < this.FieldsToShow.Count; ++index)
        {
          this.dataGridView1.Columns[index].Name = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].HeaderText = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].DataPropertyName = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].ReadOnly = true;
        }
        this.dataGridView1.DataSource = (object) dtCustomers;
        DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
        viewCheckBoxColumn.ReadOnly = false;
        viewCheckBoxColumn.HeaderText = " ";
        viewCheckBoxColumn.Name = "chk";
        viewCheckBoxColumn.Width = 40;
        this.dataGridView1.Columns[0].Width = 40;
        this.dataGridView1.Columns.Insert(0, (DataGridViewColumn) viewCheckBoxColumn);
        this.dataGridView1.ReadOnly = false;
        this.dataGridView1.Enabled = true;
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          if (row.Cells[this.MobileField] == null || row.Cells[this.MobileField].ToString() == "")
          {
            row.Cells[this.MobileField].ToString();
            row.Cells[0].ReadOnly = true;
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.bindtable", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void BindTable(DataGridView dgvCustomers)
    {
      try
      {
        this.dataGridView1.AutoGenerateColumns = false;
        this.dataGridView1.ColumnCount = this.FieldsToShow.Count;
        for (int index = 0; index < this.FieldsToShow.Count; ++index)
        {
          this.dataGridView1.Columns[index].Name = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].HeaderText = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].DataPropertyName = this.FieldsToShow[index];
          this.dataGridView1.Columns[index].ReadOnly = true;
        }
        this.dataGridView1.DataSource = (object) (dgvCustomers.DataSource as DataTable);
        DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
        viewCheckBoxColumn.ReadOnly = false;
        viewCheckBoxColumn.HeaderText = " ";
        viewCheckBoxColumn.Name = "chk";
        viewCheckBoxColumn.Width = 40;
        this.dataGridView1.Columns[0].Width = 40;
        this.dataGridView1.Columns.Insert(0, (DataGridViewColumn) viewCheckBoxColumn);
        this.dataGridView1.ReadOnly = false;
        this.dataGridView1.Enabled = true;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public void LoadNotice(List<string> lstNumbers)
    {
      this.FieldsToShow = lstNumbers;
      this.formType = 2;
      this.dataGridView1.Visible = false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void sendNotice(List<string> lstNumbers)
    {
      try
      {
        if (lstNumbers.Count == 0)
        {
          int num1 = (int) MessageBox.Show("Please select atleast one customer to send SMS");
        }
        else if (MessageBox.Show("Are you sure to send this SMS? Once sent can't revert back", "Send SMS?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          StringBuilder stringBuilder = new StringBuilder();
          string str1 = "";
          foreach (string lstNumber in lstNumbers)
            str1 = !(str1 == "") ? str1 + "," + lstNumber : lstNumber;
          int num2 = (int) MessageBox.Show("Sending message to " + str1.ToString());
          stringBuilder.Append(" shell am start -n com.javacodegeeks.android.RameshPawnSmsCenter/com.javacodegeeks.android.RameshPawnSmsCenter.MainActivity -e act sms -e number " + str1 + " -e msg \"" + this.tbxMessage.Text + "\"");
          ProcessStartInfo processStartInfo1 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
          processStartInfo1.CreateNoWindow = true;
          processStartInfo1.RedirectStandardOutput = true;
          processStartInfo1.RedirectStandardError = true;
          processStartInfo1.UseShellExecute = false;
          Process process1 = new Process();
          process1.StartInfo = processStartInfo1;
          StringBuilder output = new StringBuilder();
          StringBuilder error = new StringBuilder();
          process1.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process1.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process1.Start();
          process1.BeginOutputReadLine();
          process1.BeginErrorReadLine();
          process1.WaitForExit();
          process1.Close();
          string str2 = error.ToString();
          string str3 = output.ToString();
          process1.Dispose();
          int num3 = 3;
          bool noticeSent = false;
          bool errorShown = false;
          for (; !str3.Contains("device") && num3 > 0; --num3)
          {
            ProcessStartInfo processStartInfo2 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
            processStartInfo2.CreateNoWindow = true;
            processStartInfo2.RedirectStandardOutput = true;
            processStartInfo2.RedirectStandardError = true;
            processStartInfo2.UseShellExecute = false;
            Process process2 = new Process();
            process2.StartInfo = processStartInfo2;
            output = new StringBuilder();
            error = new StringBuilder();
            process2.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
            process2.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
            process2.Start();
            process2.BeginOutputReadLine();
            process2.BeginErrorReadLine();
            process2.WaitForExit();
            process2.Close();
            str2 = error.ToString();
            str3 = output.ToString();
            process2.Dispose();
            Thread.Sleep(2000);
          }
          if (num3 <= 0)
          {
            int num4 = (int) MessageBox.Show("Make sure an Android device is connected.", "Unable to send SMS");
          }
          else
          {
            ProcessStartInfo processStartInfo3 = new ProcessStartInfo(" " + this.strADBLocation + " ", " shell pm clear com.javacodegeeks.android.RameshPawnSmsCenter");
            processStartInfo3.CreateNoWindow = true;
            processStartInfo3.RedirectStandardOutput = true;
            processStartInfo3.RedirectStandardError = true;
            processStartInfo3.UseShellExecute = false;
            Process process3 = new Process();
            process3.StartInfo = processStartInfo3;
            output = new StringBuilder();
            error = new StringBuilder();
            process3.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
            process3.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
            process3.Start();
            process3.BeginOutputReadLine();
            process3.BeginErrorReadLine();
            process3.WaitForExit();
            process3.Close();
            str2 = error.ToString();
            string str4 = output.ToString();
            process3.Dispose();
            ProcessStartInfo processStartInfo4 = new ProcessStartInfo(" " + this.strADBLocation + " ", stringBuilder.ToString());
            processStartInfo4.CreateNoWindow = true;
            processStartInfo4.RedirectStandardOutput = true;
            processStartInfo4.RedirectStandardError = true;
            processStartInfo4.UseShellExecute = false;
            Process process4 = new Process();
            process4.StartInfo = processStartInfo4;
            output = new StringBuilder();
            error = new StringBuilder();
            process4.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) =>
            {
              if (noticeSent)
                return;
              noticeSent = true;
              output.Append(ef.Data);
              int num5 = (int) MessageBox.Show("Sms sent");
              foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
              {
                if (row.Cells[0].Value != null && bool.Parse(row.Cells[0].Value.ToString()))
                {
                  string messageText = this.tbxMessage.Text.Trim().ToString();
                  string phoneNumber = row.Cells[this.MobileField].Value.ToString();
                  string customerCode = row.Cells[this.CustomerCode].Value.ToString();
                  DateTime now = DateTime.Now;
                  string SentOn = now.ToString("dd/MM/yyyy");
                  now = DateTime.Now;
                  string SentTime = now.ToString();
                  this.insertIntoSentSms(messageText, phoneNumber, customerCode, SentOn, SentTime);
                }
              }
            });
            process4.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) =>
            {
              if (errorShown)
                return;
              errorShown = true;
              if (ef.Data != null)
              {
                error.Append(ef.Data);
                int num6 = (int) MessageBox.Show("Error while sending SMS. " + ef.Data);
              }
            });
            process4.Start();
            process4.BeginOutputReadLine();
            process4.BeginErrorReadLine();
            process4.WaitForExit();
            process4.Close();
            str2 = error.ToString();
            str4 = output.ToString();
            process4.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.sendNotice", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void frmSendSMSNotice_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView2);
      PawnManagementClass.formatButtonBlue(ref this.glassButton1);
      PawnManagementClass.formatButtonBlue(ref this.glassButton2);
      for (int index = 0; index < this.dataGridView1.Rows.Count; ++index)
        this.dataGridView1.Rows[index].Cells["chk"].Value = (object) false;
    }

    private void getMessages()
    {
      try
      {
        string strError = "";
        this.dtrefreshGrid = SQLHelper.GetDataTable("select * from tblMessage", ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("FormSmsMessages.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the Messages from  the Message table.\n" + strError);
        }
        else
        {
          this.dataGridView2.Visible = true;
          this.dataGridView2.DataSource = (object) this.dtrefreshGrid;
          if (this.dataGridView2.RowCount > 0)
          {
            this.dataGridView2.Focus();
            this.dataGridView2.Rows[0].Selected = true;
          }
        }
        this.dataGridView2.Columns["ID"].Visible = false;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.getMessages()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.getMessages();

    private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Escape)
          this.dataGridView2.Visible = false;
        if (e.KeyCode != Keys.Return)
          return;
        if (this.dataGridView2 != null && this.dataGridView2.RowCount > 0)
        {
          this.dataGridView2.Rows[0].Selected = true;
          if (this.dataGridView2.CurrentCell.RowIndex >= 0)
          {
            this.tbxMessage.Text = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["MessageText"].Value.ToString();
            this.dataGridView2.Visible = false;
          }
        }
        else
        {
          int num = (int) MessageBox.Show("NO Messages");
        }
        this.dataGridView2.Visible = false;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.datagridview2_keydown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void checkforNumber()
    {
      try
      {
        this.lblNumberOfContactsSelected.Text = "";
        int num = 0;
        int rowCount = this.dataGridView1.RowCount;
        for (int index = 0; index < rowCount; ++index)
        {
          if (this.dataGridView1.Rows[index].Cells["chk"].Value != null)
          {
            DataGridViewRow row = this.dataGridView1.Rows[index];
            if (row.Cells[this.MobileField].Value.ToString().Length == 10 && this.IsDigitsOnly(row.Cells[this.MobileField].Value.ToString()))
            {
              row.DefaultCellStyle.ForeColor = Color.Black;
              if (this.dataGridView1.Rows[index].Cells["chk"].Value != null && bool.Parse(this.dataGridView1.Rows[index].Cells["chk"].Value.ToString()))
                ++num;
            }
            else
              this.dataGridView1.Rows[index].Cells["chk"].Value = (object) false;
          }
        }
        this.lblNumberOfContactsSelected.Text = num.ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form sendsms.checkForNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool IsDigitsOnly(string str)
    {
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void dataGridView1_Click(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.checkforNumber();
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
    }

    private void btnUnselectAll_Click(object sender, EventArgs e)
    {
    }

    private void insertIntoSentSms(
      string messageText,
      string phoneNumber,
      string customerCode,
      string SentOn,
      string SentTime)
    {
      string strError = "";
      SQLHelper.RunCommand("insert into tblSentSms(MessageText,PhoneNumber,CustomerCode,SentOn,SentTime,SentBy) values(@MessageText,@PhoneNumber,@CustomerCode,@SentOn,@SentTime,@SentBy)", new List<OleDbParameter>()
      {
        new OleDbParameter("MessageText", (object) messageText),
        new OleDbParameter("PhoneNumber", (object) phoneNumber),
        new OleDbParameter("CustomerCode", (object) customerCode),
        new OleDbParameter(nameof (SentOn), (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (SentTime), (object) DateTime.Now.ToShortTimeString()),
        new OleDbParameter("SentBy", (object) FormMain.username)
      }, ref strError);
    }

    private void selectAlllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int rowCount = this.dataGridView1.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dataGridView1.Rows[index].Cells["chk"].Value = (object) true;
    }

    private void unSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int rowCount = this.dataGridView1.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dataGridView1.Rows[index].Cells["chk"].Value = (object) false;
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.selectAlllToolStripMenuItem = new ToolStripMenuItem();
      this.unSelectAllToolStripMenuItem = new ToolStripMenuItem();
      this.tbxMessage = new TextBox();
      this.lblSMSLength = new Label();
      this.glassButton2 = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.dataGridView2 = new DataGridView();
      this.lblNumberOfContactsSelected = new Label();
      this.headerPanel5 = new HeaderPanel();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(510, 597);
      this.dataGridView1.TabIndex = 3;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
      this.dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
      this.dataGridView1.Click += new EventHandler(this.dataGridView1_Click);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.selectAlllToolStripMenuItem,
        (ToolStripItem) this.unSelectAllToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(138, 48);
      this.selectAlllToolStripMenuItem.Name = "selectAlllToolStripMenuItem";
      this.selectAlllToolStripMenuItem.Size = new Size(137, 22);
      this.selectAlllToolStripMenuItem.Text = "Select Alll";
      this.selectAlllToolStripMenuItem.Click += new EventHandler(this.selectAlllToolStripMenuItem_Click);
      this.unSelectAllToolStripMenuItem.Name = "unSelectAllToolStripMenuItem";
      this.unSelectAllToolStripMenuItem.Size = new Size(137, 22);
      this.unSelectAllToolStripMenuItem.Text = "UnSelect All";
      this.unSelectAllToolStripMenuItem.Click += new EventHandler(this.unSelectAllToolStripMenuItem_Click);
      this.tbxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxMessage.Font = new Font("Arial Narrow", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxMessage.Location = new Point(19, 57);
      this.tbxMessage.Multiline = true;
      this.tbxMessage.Name = "tbxMessage";
      this.tbxMessage.Size = new Size(447, 364);
      this.tbxMessage.TabIndex = 5;
      this.tbxMessage.TextChanged += new EventHandler(this.tbxMessage_TextChanged);
      this.lblSMSLength.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblSMSLength.AutoSize = true;
      this.lblSMSLength.BackColor = Color.Transparent;
      this.lblSMSLength.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSMSLength.Location = new Point(168, 424);
      this.lblSMSLength.Name = "lblSMSLength";
      this.lblSMSLength.Size = new Size(298, 20);
      this.lblSMSLength.TabIndex = 6;
      this.lblSMSLength.Text = "SMS Length: 100/160 chars - 1 message";
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(274, 12);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(192, 39);
      ((Control) this.glassButton2).TabIndex = 9;
      ((Control) this.glassButton2).Text = "Select &Message";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.glassButton1.BackColor = Color.Transparent;
      ((Control) this.glassButton1).BackgroundImage = (Image) PawnManagement.Properties.Resources.SENDSMS;
      ((Control) this.glassButton1).BackgroundImageLayout = ImageLayout.Stretch;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(62, 454);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(347, 68);
      ((Control) this.glassButton1).TabIndex = 8;
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.button2_Click);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = Color.MintCream;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = Color.Navy;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView2.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(12, 82);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(984, 297);
      this.dataGridView2.TabIndex = 9;
      this.dataGridView2.Visible = false;
      this.dataGridView2.KeyDown += new KeyEventHandler(this.dataGridView2_KeyDown);
      this.lblNumberOfContactsSelected.Anchor = AnchorStyles.Top;
      this.lblNumberOfContactsSelected.AutoSize = true;
      this.lblNumberOfContactsSelected.BackColor = Color.Transparent;
      this.lblNumberOfContactsSelected.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblNumberOfContactsSelected.Location = new Point(215, 5);
      this.lblNumberOfContactsSelected.Name = "lblNumberOfContactsSelected";
      this.lblNumberOfContactsSelected.Size = new Size(24, 25);
      this.lblNumberOfContactsSelected.TabIndex = 12;
      this.lblNumberOfContactsSelected.Text = "0";
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel5.CaptionEndColor = Color.AliceBlue;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "SELECT THE CONTACTS";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.dataGridView1);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(495, 3);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(512, 621);
      ((Control) this.headerPanel5).TabIndex = 80;
      this.headerPanel5.TextAntialias = true;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "NUMBER OF CONTACTS SELECTED";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel1).Controls.Add((Control) this.lblNumberOfContactsSelected);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(3, 563);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(490, 61);
      ((Control) this.headerPanel1).TabIndex = 81;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      ((ButtonBase) this.glassButton5).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(183, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 0;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(317, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "SMS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxMessage);
      ((Control) this.headerPanel2).Controls.Add((Control) this.lblSMSLength);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(2, 2);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(491, 555);
      ((Control) this.headerPanel2).TabIndex = 82;
      this.headerPanel2.TextAntialias = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 626);
      this.Controls.Add((Control) this.dataGridView2);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel5);
      this.Name = nameof (FormSendSMS);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "frmSendSMSNotice";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.frmSendSMSNotice_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
