

using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormCustomerReminder : Form
  {
    private DataTable dtSms = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private string oldValues = "";
    private string newValues = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxCustomerCode;
    private TextBox tbxCustomerName;
    private TextBox tbxReminder;
    private Label label1;
    private Label label2;
    private Label label3;
    private GlassButton glassButton1;
    private TextBox tbxSearch;
    private Panel panel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem viewCustomerDetailsToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem callToolStripMenuItem;
    private ToolStripMenuItem smsToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private DataGridView dataGridView1;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel3;
    private HeaderPanel headerPanel4;
    private CheckBox cbExcludeNoReminders;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormCustomerReminder() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select cid,cname,cnotes,cphone,cno,caddr1,caddr2,caddr3 from tblCustomers";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form CustomerReminder.refreshGrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving cid,cname,cnotes from tblcustomers" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void FormCustomerReminder_Load(object sender, EventArgs e)
    {
      this.tbxSearch.Select();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.dataGridView1.BackgroundColor = Color.AliceBlue;
      this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.PowderBlue;
      this.refreshGrid();
      this.dtSms.Columns.Add("Cid");
      this.dtSms.Columns.Add("Cname");
      this.dtSms.Columns.Add("Cphone");
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows.Count >= 0)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          this.tbxCustomerCode.Text = this.dataGridView1.Rows[rowIndex].Cells["Cid"].Value.ToString();
          this.tbxCustomerName.Text = this.dataGridView1.Rows[rowIndex].Cells["CName"].Value.ToString();
          this.tbxReminder.Text = this.dataGridView1.Rows[rowIndex].Cells["cNotes"].Value.ToString();
          this.oldValues = "Old Values are \n customerCode =" + this.tbxCustomerCode.Text.Trim().ToString() + " \ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nReminder = " + this.tbxReminder.Text.Trim().ToString();
        }
        if (this.dataGridView1.Rows.Count <= 0 || !(this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "cid"))
          return;
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cid"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerReminder.dataGridView1_CellClick", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
      }
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      this.save();
      this.newValues = "New Values are \n customerCode =" + this.tbxCustomerCode.Text.Trim().ToString() + " \ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nReminder = " + this.tbxReminder.Text.Trim().ToString();
      PawnManagementClass.InsertIntoHistory("CUSTOMER REMINDER UPDATED", "CUSTOMER REMINDER UPDATED", this.oldValues, this.newValues, FormMain.username, DateTime.Now.ToString());
      this.refreshGrid();
      this.tbxSearch.Select();
    }

    private void save()
    {
      string strError = "";
      SQLHelper.RunCommand("update tblCustomers set cnotes = @CNotes where cid = @cid", new List<OleDbParameter>()
      {
        new OleDbParameter("CNotes", (object) this.tbxReminder.Text.Trim().ToString()),
        new OleDbParameter("cid", (object) this.tbxCustomerCode.Text.Trim())
      }, ref strError);
    }

    private void tbxCustomerCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = this.cbExcludeNoReminders.Checked ? "select Cid,cname,cno,caddr1,caddr2,caddr3,cnotes,CPHONE from tblCustomers where (cid like @cid or cname like @cname or cnotes like @cnotes) and (cnotes <> null and cnotes <> '')" : "select Cid,cname,cno,caddr1,caddr2,caddr3,cnotes,CPHONE from tblCustomers where cid like @cid or cname like @cname or cnotes like @cnotes";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("cid", (object) ("%" + this.tbxSearch.Text + "%")));
      parameters.Add(new OleDbParameter("cname", (object) ("%" + this.tbxSearch.Text + "%")));
      parameters.Add(new OleDbParameter("cnotes", (object) ("%" + this.tbxSearch.Text + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form CustomerReminder.textbox1_TExxtChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void viewCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      FormViewCustomerDetails viewCustomerDetails = new FormViewCustomerDetails(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cid"].Value.ToString());
      viewCustomerDetails.MdiParent = this.MdiParent;
      viewCustomerDetails.Show();
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "Customer Reminder", FormMain.username);

    private void callToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormCall(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cphone"].Value.ToString()).ShowDialog();
    }

    private void smsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cphone"].Value.ToString() != "") || !PawnManagementClass.IsDigitsOnly(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cphone"].Value.ToString()) || this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cphone"].Value.ToString().Length != 10)
        return;
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      this.dtSms.Rows.Clear();
      this.dtSms.Rows.Add((object) this.tbxCustomerCode.Text, (object) this.tbxCustomerName.Text, (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cphone"].Value.ToString());
      FieldToBind.Add("Cid");
      FieldToBind.Add("CPhone");
      FieldToBind.Add("CName");
      formSendSms.LoadNotice(this.dtSms, "cid", "cphone", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Customer Reminders").ShowDialog();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Select();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Up && this.dataGridView1.Rows[0].Selected)
        this.tbxSearch.Select();
      if (e.KeyCode != Keys.Return)
        return;
      if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
      {
        try
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          this.tbxCustomerCode.Text = this.dataGridView1.Rows[rowIndex].Cells["Cid"].Value.ToString();
          this.tbxCustomerName.Text = this.dataGridView1.Rows[rowIndex].Cells["CName"].Value.ToString();
          this.tbxReminder.Text = this.dataGridView1.Rows[rowIndex].Cells["cNotes"].Value.ToString();
          this.oldValues = "Old Values are \n customerCode =" + this.tbxCustomerCode.Text.Trim().ToString() + " \ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nReminder = " + this.tbxReminder.Text.Trim().ToString();
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form CustomerReminder.dataGridView1_CellClick", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        }
        this.tbxReminder.Select();
      }
    }

    private void tbxReminder_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.glassButton1).Focus();
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

    private void cbExcludeNoReminders_CheckedChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = this.cbExcludeNoReminders.Checked ? "select Cid,cname,cnotes,CPHONE,cno,caddr1,caddr2,caddr3 from tblCustomers where (cid like @cid or cname like @cname or cnotes like @cnotes) and (cnotes <> null and cnotes <> '')" : "select Cid,cname,cnotes,CPHONE,cno,caddr1,caddr2,caddr3 from tblCustomers where cid like @cid or cname like @cname or cnotes like @cnotes";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("cid", (object) ("%" + this.tbxSearch.Text + "%")));
      parameters.Add(new OleDbParameter("cname", (object) ("%" + this.tbxSearch.Text + "%")));
      parameters.Add(new OleDbParameter("cnotes", (object) ("%" + this.tbxSearch.Text + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form CustomerReminder.textbox1_TExxtChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
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
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.viewCustomerDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.callToolStripMenuItem = new ToolStripMenuItem();
      this.smsToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.tbxCustomerCode = new TextBox();
      this.tbxCustomerName = new TextBox();
      this.tbxReminder = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.glassButton1 = new GlassButton();
      this.tbxSearch = new TextBox();
      this.panel1 = new Panel();
      this.dataGridView1 = new DataGridView();
      this.headerPanel2 = new HeaderPanel();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.headerPanel4 = new HeaderPanel();
      this.cbExcludeNoReminders = new CheckBox();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.viewCustomerDetailsToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.callToolStripMenuItem,
        (ToolStripItem) this.smsToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 158);
      this.viewCustomerDetailsToolStripMenuItem.Name = "viewCustomerDetailsToolStripMenuItem";
      this.viewCustomerDetailsToolStripMenuItem.Size = new Size(194, 22);
      this.viewCustomerDetailsToolStripMenuItem.Text = "View Customer Details";
      this.viewCustomerDetailsToolStripMenuItem.Click += new EventHandler(this.viewCustomerDetailsToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export  To Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.callToolStripMenuItem.Name = "callToolStripMenuItem";
      this.callToolStripMenuItem.Size = new Size(194, 22);
      this.callToolStripMenuItem.Text = "Call";
      this.callToolStripMenuItem.Click += new EventHandler(this.callToolStripMenuItem_Click);
      this.smsToolStripMenuItem.Name = "smsToolStripMenuItem";
      this.smsToolStripMenuItem.Size = new Size(194, 22);
      this.smsToolStripMenuItem.Text = "Sms";
      this.smsToolStripMenuItem.Click += new EventHandler(this.smsToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(33, 60);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(323, 31);
      this.tbxCustomerCode.TabIndex = 1;
      this.tbxCustomerCode.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxCustomerName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(33, 132);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(323, 31);
      this.tbxCustomerName.TabIndex = 2;
      this.tbxCustomerName.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.Location = new Point(33, 208);
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.Size = new Size(323, 31);
      this.tbxReminder.TabIndex = 3;
      this.tbxReminder.KeyDown += new KeyEventHandler(this.tbxReminder_KeyDown);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(28, 22);
      this.label1.Name = "label1";
      this.label1.Size = new Size(161, 25);
      this.label1.TabIndex = 4;
      this.label1.Text = "Customer Code";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(28, 94);
      this.label2.Name = "label2";
      this.label2.Size = new Size(166, 25);
      this.label2.TabIndex = 5;
      this.label2.Text = "Customer Name";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(28, 170);
      this.label3.Name = "label3";
      this.label3.Size = new Size(104, 25);
      this.label3.TabIndex = 6;
      this.label3.Text = "Reminder";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.reset;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(30, 265);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(326, 56);
      ((Control) this.glassButton1).TabIndex = 7;
      ((Control) this.glassButton1).Text = "&UPDATE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.tbxSearch.Dock = DockStyle.Fill;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(0, 0);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(444, 31);
      this.tbxSearch.TabIndex = 8;
      this.tbxSearch.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.tbxSearch.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.panel1.BackColor = Color.Transparent;
      this.panel1.Controls.Add((Control) this.glassButton1);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.tbxReminder);
      this.panel1.Controls.Add((Control) this.tbxCustomerName);
      this.panel1.Controls.Add((Control) this.tbxCustomerCode);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(388, 601);
      this.panel1.TabIndex = 10;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(606, 541);
      this.dataGridView1.TabIndex = 10;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "CUSTOMER REMIINDERS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.dataGridView1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(3, 65);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(608, 565);
      ((Control) this.headerPanel2).TabIndex = 70;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "SEARCH";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxSearch);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(3, 5);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(446, 53);
      ((Control) this.headerPanel1).TabIndex = 71;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(157, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(291, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel3.CaptionEndColor = Color.AliceBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "ADD & EDIIT REMINDERS";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.panel1);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(617, 5);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(390, 625);
      ((Control) this.headerPanel3).TabIndex = 72;
      this.headerPanel3.TextAntialias = true;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel4.CaptionEndColor = Color.AliceBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "SEARCH";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbExcludeNoReminders);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(455, 5);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(157, 53);
      ((Control) this.headerPanel4).TabIndex = 72;
      this.headerPanel4.TextAntialias = true;
      this.cbExcludeNoReminders.AutoSize = true;
      this.cbExcludeNoReminders.BackColor = Color.Transparent;
      this.cbExcludeNoReminders.Location = new Point(8, 5);
      this.cbExcludeNoReminders.Name = "cbExcludeNoReminders";
      this.cbExcludeNoReminders.Size = new Size(143, 19);
      this.cbExcludeNoReminders.TabIndex = 2;
      this.cbExcludeNoReminders.Text = "Exclude no Reminders";
      this.cbExcludeNoReminders.UseVisualStyleBackColor = false;
      this.cbExcludeNoReminders.CheckedChanged += new EventHandler(this.cbExcludeNoReminders_CheckedChanged);
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      ((ButtonBase) this.glassButton4).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(-134, 513);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(128, 35);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&SAVE";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(0, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel2);
      this.Name = nameof (FormCustomerReminder);
      this.Text = nameof (FormCustomerReminder);
      this.Load += new EventHandler(this.FormCustomerReminder_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
