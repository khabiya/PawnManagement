

using ExportToExcel11;
using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormReminder : Form
  {
    private string reminderType = "onetime";
    private string strdisplay = "";
    private string reminderTypeValue = "";
    private DataTable dtReminder = new DataTable();
    private IContainer components = (IContainer) null;
    private TextBox tbxReminder;
    private TextBox tbxReminderDetails;
    private Label label1;
    private Label label2;
    private Label label4;
    private DateTimePicker dtpDate;
    private GlassButton btnAdd;
    private RadioButton rbYearly;
    private RadioButton rbOneTime;
    private RadioButton rbWeekly;
    private RadioButton rbMonthly;
    private Label lblType;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private TextBox textBox1;
    private Label label3;
    private Panel panel1;
    private Panel panel2;
    private TableLayoutPanel tableLayoutPanel1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormReminder() => this.InitializeComponent();

    public FormReminder(string str, DataTable dt)
    {
      this.strdisplay = str;
      this.dtReminder = dt;
      this.InitializeComponent();
    }

    private void display()
    {
      ((Control) this.btnAdd).Visible = false;
      this.tbxReminder.Visible = false;
      this.tbxReminderDetails.Visible = false;
      this.dtpDate.Visible = false;
      this.textBox1.Visible = false;
      this.rbOneTime.Visible = false;
      this.rbWeekly.Visible = false;
      this.rbMonthly.Visible = false;
      this.rbYearly.Visible = false;
      this.lblType.Visible = false;
      this.label1.Visible = false;
      this.label2.Visible = false;
      this.label3.Visible = false;
      this.label4.Visible = false;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      this.getReminderType();
      if (((Control) this.btnAdd).Text == "ADD")
      {
        if (this.tbxReminder.Text != "" && this.tbxReminderDetails.Text != "")
        {
          this.addReminder();
          this.tbxReminder.Text = "";
          this.tbxReminderDetails.Text = "";
          this.refreshGrid();
        }
      }
      else if (((Control) this.btnAdd).Text == "UPDATE" && this.tbxReminder.Text != "" && this.tbxReminderDetails.Text != "")
      {
        this.editReminder();
        this.tbxReminder.Text = "";
        this.tbxReminderDetails.Text = "";
        this.refreshGrid();
      }
      ((Control) this.btnAdd).Text = "ADD";
    }

    private void editReminder()
    {
      try
      {
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        string strError = "";
        if (SQLHelper.RunCommand("Update tblReminder set Reminder = @Reminder,ReminderDetails = @ReminderDetails,ReminderDate=@ReminderDate,ReminderType = @ReminderType ,ReminderTypeValue = @ReminderTypeValue where ID =@ID", new List<OleDbParameter>()
        {
          new OleDbParameter("Reminder", (object) this.tbxReminder.Text.Trim().ToString()),
          new OleDbParameter("ReminderDetails", (object) this.tbxReminderDetails.Text.Trim().ToString()),
          new OleDbParameter("ReminderDate", (object) this.dtpDate.Value.ToString("dd/MM/yyyy")),
          new OleDbParameter("ReminderType", (object) this.reminderType),
          new OleDbParameter("ReminderTypeValue", (object) this.reminderTypeValue),
          new OleDbParameter("ID", (object) int.Parse(this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString()))
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("form reminder.editReminder", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in editing" + strError);
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form Reminder.EditReminder", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addReminder()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblReminder(Reminder,ReminderDetails,ReminderDate,ReminderType,ReminderTypeValue) values(@Reminder,@ReminderDetails,@ReminderDate,@ReminderType,@ReminderTypeValue)", new List<OleDbParameter>()
      {
        new OleDbParameter("Reminder", (object) this.tbxReminder.Text.Trim().ToString()),
        new OleDbParameter("ReminderDetails", (object) this.tbxReminderDetails.Text.Trim().ToString()),
        new OleDbParameter("ReminderDate", (object) this.dtpDate.Value.ToString("dd/MM/yyyy")),
        new OleDbParameter("ReminderType", (object) this.reminderType),
        new OleDbParameter("ReminderTypeValue", (object) this.reminderTypeValue)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form reminder.addReminder", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void refreshGrid()
    {
      try
      {
        if (this.strdisplay == "display")
        {
          this.dataGridView1.DataSource = (object) this.dtReminder;
        }
        else
        {
          string strError = "";
          string my_querry = "select * from tblReminder";
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
          if (strError != "")
          {
            PawnManagementClass.InsertIntoException("form reminder.regreshgrid", strError, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
          }
          else
            this.dataGridView1.DataSource = (object) dataTable2;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form reminder.refreshGrid", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void displayReminder()
    {
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormReminder_Load(object sender, EventArgs e)
    {
      try
      {
        this.refreshGrid();
        this.rbOneTime.Checked = true;
        PawnManagementClass.formatDataGridViewBlack(ref this.dataGridView1);
        PawnManagementClass.formatButtonBlue(ref this.btnAdd);
        if (!(this.strdisplay == "display"))
          return;
        this.display();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form formreminder_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void rbOneTime_Click(object sender, EventArgs e)
    {
      if (!this.rbOneTime.Checked)
        return;
      this.reminderType = "onetime";
    }

    private void rbWeekly_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.rbWeekly.Checked)
        return;
      this.reminderType = this.dtpDate.Value.DayOfWeek.ToString();
    }

    private void rbMonthly_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.rbMonthly.Checked)
        return;
      this.reminderType = "monthly";
      this.reminderTypeValue = this.dtpDate.Value.Day.ToString();
    }

    private void rbYearly_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.rbYearly.Checked)
        return;
      this.reminderType = "yearly";
      this.reminderTypeValue = this.dtpDate.Value.Day.ToString() + "," + this.dtpDate.Value.Month.ToString();
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
    }

    private void aSDFToolStripMenuItem_Click(object sender, EventArgs e) => ((Control) this.btnAdd).Visible = true;

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e) => ((Control) this.btnAdd).Visible = false;

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e) => ((Control) this.btnAdd).Visible = false;

    private void eDITToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows.Count <= 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        this.tbxReminder.Text = this.dataGridView1.Rows[rowIndex].Cells["Reminder"].Value.ToString();
        this.tbxReminderDetails.Text = this.dataGridView1.Rows[rowIndex].Cells["ReminderDetails"].Value.ToString();
        this.dtpDate.Value = DateTime.Parse(this.dataGridView1.Rows[rowIndex].Cells["ReminderDate"].Value.ToString());
        if (this.dataGridView1.Rows[rowIndex].Cells["ReminderType"].Value.ToString().Equals("onetime"))
          this.rbOneTime.Checked = true;
        if (this.dataGridView1.Rows[rowIndex].Cells["ReminderType"].Value.ToString().Equals("weekly"))
          this.rbWeekly.Checked = true;
        if (this.dataGridView1.Rows[rowIndex].Cells["ReminderType"].Value.ToString().Equals("monthly"))
          this.rbMonthly.Checked = true;
        if (this.dataGridView1.Rows[rowIndex].Cells["ReminderType"].Value.ToString().Equals("yearly"))
          this.rbYearly.Checked = true;
        ((Control) this.btnAdd).Text = "UPDATE";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form reminder_edittoolstripreminder_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dELETEToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
      {
        string strError = "";
        if (SQLHelper.RunCommand("Delete from tblReminder where ID =@ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString())
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("form deleteToolStripMenuItem_Click", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in deleting" + strError);
        }
      }
      this.refreshGrid();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select * from tblReminder where Reminder like @Reminder or ReminderDetails like @ReminderDetails or ReminderDate like @ReminderDate or ReminderType like @ReminderType";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Reminder", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("ReminderDetails", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("ReminderDate", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("ReminderType", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form reminder.textbox1_textchainged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void getReminderType()
    {
      try
      {
        if (this.rbOneTime.Checked)
          this.reminderType = "onetime";
        DateTime dateTime;
        if (this.rbWeekly.Checked)
        {
          dateTime = this.dtpDate.Value;
          this.reminderType = dateTime.DayOfWeek.ToString();
        }
        if (this.rbMonthly.Checked)
        {
          this.reminderType = "monthly";
          dateTime = this.dtpDate.Value;
          this.reminderTypeValue = dateTime.Day.ToString();
        }
        if (!this.rbYearly.Checked)
          return;
        this.reminderType = "yearly";
        dateTime = this.dtpDate.Value;
        string str1 = dateTime.Day.ToString();
        dateTime = this.dtpDate.Value;
        string str2 = dateTime.Month.ToString();
        this.reminderTypeValue = str1 + "," + str2;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form reminder.getremindertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void tbxReminder_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void rbOneTime_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAdd).Focus();
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void viewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Reminder").ShowDialog();
    }

    private void exportToExcelOption2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
          CreateExcelFile.CreateExcelDocument((sourceControl as DataGridView).DataSource as DataTable, folderBrowserDialog.SelectedPath + "\\" + (sourceControl as DataGridView).Name + ".xlsx");
      }
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
      this.tbxReminder = new TextBox();
      this.tbxReminderDetails = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label4 = new Label();
      this.dtpDate = new DateTimePicker();
      this.btnAdd = new GlassButton();
      this.rbYearly = new RadioButton();
      this.rbOneTime = new RadioButton();
      this.rbWeekly = new RadioButton();
      this.rbMonthly = new RadioButton();
      this.lblType = new Label();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.Location = new Point(201, 10);
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.Size = new Size(338, 29);
      this.tbxReminder.TabIndex = 0;
      this.tbxReminder.KeyDown += new KeyEventHandler(this.tbxReminder_KeyDown);
      this.tbxReminderDetails.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminderDetails.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminderDetails.Location = new Point(201, 46);
      this.tbxReminderDetails.Name = "tbxReminderDetails";
      this.tbxReminderDetails.Size = new Size(338, 29);
      this.tbxReminderDetails.TabIndex = 1;
      this.tbxReminderDetails.KeyDown += new KeyEventHandler(this.tbxReminder_KeyDown);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(85, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(101, 24);
      this.label1.TabIndex = 3;
      this.label1.Text = "Reminder";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(17, 46);
      this.label2.Name = "label2";
      this.label2.Size = new Size(169, 24);
      this.label2.TabIndex = 4;
      this.label2.Text = "Reminder Details";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(134, 83);
      this.label4.Name = "label4";
      this.label4.Size = new Size(52, 24);
      this.label4.TabIndex = 6;
      this.label4.Text = "Date";
      this.dtpDate.CustomFormat = "";
      this.dtpDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dtpDate.Format = DateTimePickerFormat.Short;
      this.dtpDate.Location = new Point(201, 83);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.RightToLeft = RightToLeft.No;
      this.dtpDate.RightToLeftLayout = true;
      this.dtpDate.Size = new Size(338, 29);
      this.dtpDate.TabIndex = 2;
      this.dtpDate.KeyDown += new KeyEventHandler(this.tbxReminder_KeyDown);
      this.btnAdd.BackColor = Color.LightBlue;
      this.btnAdd.FadeOnFocus = true;
      ((Control) this.btnAdd).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAdd.ForeColor = Color.MediumBlue;
      this.btnAdd.ForeColorOnFocus = Color.Red;
      this.btnAdd.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAdd.GlowColor = Color.White;
      this.btnAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAdd).Location = new Point(558, 68);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.Transparent;
      ((Control) this.btnAdd).Size = new Size(106, 44);
      ((Control) this.btnAdd).TabIndex = 7;
      ((Control) this.btnAdd).Text = "ADD";
      ((Control) this.btnAdd).Click += new EventHandler(this.btnAdd_Click);
      this.rbYearly.AutoSize = true;
      this.rbYearly.Location = new Point(474, 129);
      this.rbYearly.Name = "rbYearly";
      this.rbYearly.Size = new Size(54, 17);
      this.rbYearly.TabIndex = 6;
      this.rbYearly.TabStop = true;
      this.rbYearly.Text = "Yearly";
      this.rbYearly.UseVisualStyleBackColor = true;
      this.rbYearly.CheckedChanged += new EventHandler(this.rbYearly_CheckedChanged);
      this.rbYearly.KeyDown += new KeyEventHandler(this.rbOneTime_KeyDown);
      this.rbOneTime.AutoSize = true;
      this.rbOneTime.Location = new Point(199, 129);
      this.rbOneTime.Name = "rbOneTime";
      this.rbOneTime.Size = new Size(71, 17);
      this.rbOneTime.TabIndex = 3;
      this.rbOneTime.TabStop = true;
      this.rbOneTime.Text = "One Time";
      this.rbOneTime.UseVisualStyleBackColor = true;
      this.rbOneTime.Click += new EventHandler(this.rbOneTime_Click);
      this.rbOneTime.KeyDown += new KeyEventHandler(this.rbOneTime_KeyDown);
      this.rbWeekly.AutoSize = true;
      this.rbWeekly.Location = new Point(290, 129);
      this.rbWeekly.Name = "rbWeekly";
      this.rbWeekly.Size = new Size(61, 17);
      this.rbWeekly.TabIndex = 4;
      this.rbWeekly.TabStop = true;
      this.rbWeekly.Text = "Weekly";
      this.rbWeekly.UseVisualStyleBackColor = true;
      this.rbWeekly.CheckedChanged += new EventHandler(this.rbWeekly_CheckedChanged);
      this.rbWeekly.KeyDown += new KeyEventHandler(this.rbOneTime_KeyDown);
      this.rbMonthly.AutoSize = true;
      this.rbMonthly.Location = new Point(379, 129);
      this.rbMonthly.Name = "rbMonthly";
      this.rbMonthly.Size = new Size(62, 17);
      this.rbMonthly.TabIndex = 5;
      this.rbMonthly.TabStop = true;
      this.rbMonthly.Text = "Monthly";
      this.rbMonthly.UseVisualStyleBackColor = true;
      this.rbMonthly.CheckedChanged += new EventHandler(this.rbMonthly_CheckedChanged);
      this.rbMonthly.KeyDown += new KeyEventHandler(this.rbOneTime_KeyDown);
      this.lblType.AutoSize = true;
      this.lblType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblType.Location = new Point(124, 122);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(57, 24);
      this.lblType.TabIndex = 13;
      this.lblType.Text = "Type";
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 56);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new Size(1002, 408);
      this.dataGridView1.TabIndex = 17;
      this.dataGridView1.TabStop = false;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 158);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click_1);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click_1);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(194, 22);
      this.viewToolStripMenuItem.Text = "View Full Screen";
      this.viewToolStripMenuItem.Click += new EventHandler(this.viewToolStripMenuItem_Click);
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(92, 11);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(197, 29);
      this.textBox1.TabIndex = 0;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(12, 15);
      this.label3.Name = "label3";
      this.label3.Size = new Size(76, 24);
      this.label3.TabIndex = 19;
      this.label3.Text = "Search";
      this.panel1.Controls.Add((Control) this.rbOneTime);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.rbMonthly);
      this.panel1.Controls.Add((Control) this.dtpDate);
      this.panel1.Controls.Add((Control) this.rbYearly);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.lblType);
      this.panel1.Controls.Add((Control) this.rbWeekly);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.tbxReminderDetails);
      this.panel1.Controls.Add((Control) this.tbxReminder);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 470);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 159);
      this.panel1.TabIndex = 20;
      this.panel2.Controls.Add((Control) this.textBox1);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 47);
      this.panel2.TabIndex = 21;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 2);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.48936f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.51064f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 164f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 22;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormReminder);
      this.RightToLeft = RightToLeft.No;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormReminder);
      this.Load += new EventHandler(this.FormReminder_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
