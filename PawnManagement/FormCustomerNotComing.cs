

using ExportToExcel11;
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
  public class FormCustomerNotComing : Form
  {
    private DataTable dtCustomersNotComing = new DataTable();
    private DataTable dtSms = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox textBox1;
    private Label label1;
    private Label label2;
    private Panel panel2;
    private TextBox tbxNotes;
    private TextBox tbxNumber;
    private Label label12;
    private PictureBox pictureBox2;
    private TextBox tbxCustomerName;
    private TextBox tbxCustomerCode;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCell;
    private TextBox tbxAddress1;
    private TextBox tbxAddress2;
    private TextBox tbxCity;
    private TextBox tbxPincode;
    private TextBox tbxAddress3;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel panel1;
    private PictureBox pictureBox1;
    private PictureBox pictureBox5;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormCustomerNotComing() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select [Customer Last appeared on], [Number of days since customer last came],tpp.customercode,tc.CName,tc.CPhone,tc.cno,tc.caddr1,tc.caddr2,tc.caddr3  from(select tp.customercode,tp.mbd as [Customer Last appeared on] ,tp.numberofdays as [Number of days since customer last came] from(select customercode, max(billdate) as mbd, datediff('d', mbd, date()) as numberofdays from tblPledge group by customercode) as tp order by tp.mbd ) as tpp left join tblcustomers tc on tpp.customercode = tc.cid";
      DataTable dataTable = new DataTable();
      this.dtCustomersNotComing = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form customerNotComing.refreshGrid", strError, FormMain.username, DateTime.Now.ToString());
        int num1 = (int) MessageBox.Show("Error in retrieving the data" + strError);
        int num2 = (int) MessageBox.Show("form customerNotComing.refreshGrid()" + strError);
      }
      if (this.dtCustomersNotComing == null || this.dtCustomersNotComing.Rows.Count <= 0)
        return;
      this.dataGridView1.DataSource = (object) this.dtCustomersNotComing;
    }

    private void refreshGrid(string str)
    {
      string strError = "";
      string my_querry = "select [Customer Last appeared on], [Number of days since customer last came],tpp.customercode, tc.CName, tc.CPhone, tc.cno, tc.caddr1, tc.caddr2, tc.caddr3 FROM(select * from(select tp.customercode, tp.mbd as [Customer Last appeared on], tp.numberofdays as [Number of days since customer last came] from(select customercode, max(billdate) as mbd, datediff('d', mbd, date()) as numberofdays from tblPledge group by customercode) as tp order by tp.mbd) as tpp where tpp.[Number of days since customer last came] > " + str + ")  AS tpp LEFT JOIN tblcustomers AS tc ON tpp.customercode = tc.cid ";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form customernotcoming.refreshgrid(string str)", strError, FormMain.username, DateTime.Now.ToString());
        int num1 = (int) MessageBox.Show("Error in retrieving the data" + strError);
        int num2 = (int) MessageBox.Show("form customernotcoming.refreshgrid(string str)" + strError);
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return;
      this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void FormCustomerNotComing_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.textBox1.Text != ""))
        return;
      this.refreshGrid(this.textBox1.Text.Trim().ToString());
    }

    private void getPicture(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customernotcoing.getpicture(stringg customercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getCustomerDetails(string customerCode)
    {
      try
      {
        string strError = "";
        string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,Cnotes from tblCustomers where CID like @cid";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("cid", (object) customerCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form customernotcoing.getcustomerdetails(sting customercode))", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving data" + strError);
        }
        else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        {
          this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CID");
          this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CName");
          this.tbxPhoneNumber.Text = dataTable2.Rows[0].Field<string>("CPhone");
          this.tbxCell.Text = dataTable2.Rows[0].Field<string>("CCell");
          this.tbxNumber.Text = dataTable2.Rows[0].Field<string>("CNo");
          this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("CAddr1");
          this.tbxAddress2.Text = dataTable2.Rows[0].Field<string>("CAddr2");
          this.tbxAddress3.Text = dataTable2.Rows[0].Field<string>("CAddr3");
          this.tbxCity.Text = dataTable2.Rows[0].Field<string>("CCity");
          this.tbxPincode.Text = dataTable2.Rows[0].Field<string>("CPinCode");
          if (dataTable2.Rows[0].Field<string>("CNotes") != null && dataTable2.Rows[0].Field<string>("CNotes").ToString() != "")
          {
            this.tbxNotes.Visible = true;
            this.pictureBox2.Size = new Size(256, 180);
            this.tbxNotes.Text = dataTable2.Rows[0].Field<string>("CNotes").ToString();
          }
          else
          {
            this.pictureBox2.Size = new Size(256, 212);
            this.tbxNotes.Visible = false;
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customernotcoming.getcustomerdeatils(string customerdoe).outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
        return;
      e.Handled = true;
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPhoneNumber.Text != ""))
        return;
      int num = (int) new FormCall(this.tbxPhoneNumber.Text.ToString()).ShowDialog();
    }

    private void pictureBox2_DoubleClick(object sender, EventArgs e) => new Formphoto(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.ToString() + ".png").Show();

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Escape)
          ;
        if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down) || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
          return;
        string customerCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        this.getPicture(customerCode);
        this.getCustomerDetails(customerCode);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customernotcoing.datagridview1_keyup", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPhoneNumber.Text != ""))
        return;
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      this.dtSms.Rows.Clear();
      this.dtSms.Rows.Add((object) this.tbxCustomerCode.Text, (object) this.tbxCustomerName.Text, (object) this.tbxPhoneNumber.Text);
      FieldToBind.Add("Cid");
      FieldToBind.Add("CPhone");
      FieldToBind.Add("CName");
      formSendSms.LoadNotice(this.dtSms, "cid", "cphone", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "Customer Not Coming", FormMain.username);

    private void glassButton2_Click(object sender, EventArgs e)
    {
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      string customerCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
      this.getPicture(customerCode);
      this.getCustomerDetails(customerCode);
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

    private void textBox1_TextChanged(object sender, EventArgs e)
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
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.panel2 = new Panel();
      this.pictureBox1 = new PictureBox();
      this.pictureBox5 = new PictureBox();
      this.tbxNotes = new TextBox();
      this.tbxNumber = new TextBox();
      this.label12 = new Label();
      this.pictureBox2 = new PictureBox();
      this.tbxCustomerName = new TextBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCell = new TextBox();
      this.tbxAddress1 = new TextBox();
      this.tbxAddress2 = new TextBox();
      this.tbxCity = new TextBox();
      this.tbxPincode = new TextBox();
      this.tbxAddress3 = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.panel1 = new Panel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 49);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(529, 496);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.KeyUp += new KeyEventHandler(this.dataGridView1_KeyUp);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 70);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(372, 5);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(98, 30);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
      this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
      this.textBox1.Validating += new CancelEventHandler(this.textBox1_Validating);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(3, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(366, 29);
      this.label1.TabIndex = 2;
      this.label1.Text = "Customers not coming for more than";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(475, 7);
      this.label2.Name = "label2";
      this.label2.Size = new Size(58, 29);
      this.label2.TabIndex = 3;
      this.label2.Text = "days";
      this.panel2.Controls.Add((Control) this.pictureBox1);
      this.panel2.Controls.Add((Control) this.pictureBox5);
      this.panel2.Controls.Add((Control) this.tbxNotes);
      this.panel2.Controls.Add((Control) this.tbxNumber);
      this.panel2.Controls.Add((Control) this.label12);
      this.panel2.Controls.Add((Control) this.pictureBox2);
      this.panel2.Controls.Add((Control) this.tbxCustomerName);
      this.panel2.Controls.Add((Control) this.tbxCustomerCode);
      this.panel2.Controls.Add((Control) this.tbxPhoneNumber);
      this.panel2.Controls.Add((Control) this.tbxCell);
      this.panel2.Controls.Add((Control) this.tbxAddress1);
      this.panel2.Controls.Add((Control) this.tbxAddress2);
      this.panel2.Controls.Add((Control) this.tbxCity);
      this.panel2.Controls.Add((Control) this.tbxPincode);
      this.panel2.Controls.Add((Control) this.tbxAddress3);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(544, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(461, 548);
      this.panel2.TabIndex = 4;
      this.pictureBox1.Image = (Image) Resources.callbutton;
      this.pictureBox1.Location = new Point(388, 258);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(59, 56);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 45;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox5.Image = (Image) Resources.message;
      this.pictureBox5.Location = new Point(323, 258);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(59, 56);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 59;
      this.pictureBox5.TabStop = false;
      this.pictureBox5.Click += new EventHandler(this.pictureBox5_Click);
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(22, 226);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(429, 26);
      this.tbxNotes.TabIndex = 28;
      this.tbxNotes.Visible = false;
      this.tbxNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNumber.Location = new Point(22, 71);
      this.tbxNumber.Name = "tbxNumber";
      this.tbxNumber.Size = new Size(95, 26);
      this.tbxNumber.TabIndex = 27;
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label12.Location = new Point(18, 13);
      this.label12.Name = "label12";
      this.label12.Size = new Size(241, 25);
      this.label12.TabIndex = 26;
      this.label12.Text = "CUSTOMER DETAILS";
      this.pictureBox2.Location = new Point(23, 258);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(236, 212);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
      this.pictureBox2.DoubleClick += new EventHandler(this.pictureBox2_DoubleClick);
      this.tbxCustomerName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(123, 41);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(328, 26);
      this.tbxCustomerName.TabIndex = 0;
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(22, 42);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(95, 26);
      this.tbxCustomerCode.TabIndex = 8;
      this.tbxCustomerCode.TextAlign = HorizontalAlignment.Center;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.Location = new Point(22, 194);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(204, 26);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxCell.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.Location = new Point(233, 194);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(218, 26);
      this.tbxCell.TabIndex = 22;
      this.tbxAddress1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.Location = new Point(123, 71);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(328, 26);
      this.tbxAddress1.TabIndex = 5;
      this.tbxAddress2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.Location = new Point(22, 100);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(429, 26);
      this.tbxAddress2.TabIndex = 6;
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(22, 162);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(204, 26);
      this.tbxCity.TabIndex = 9;
      this.tbxPincode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(232, 162);
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(219, 26);
      this.tbxPincode.TabIndex = 10;
      this.tbxAddress3.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress3.Location = new Point(22, 131);
      this.tbxAddress3.Name = "tbxAddress3";
      this.tbxAddress3.Size = new Size(429, 26);
      this.tbxAddress3.TabIndex = 8;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 467f));
      this.tableLayoutPanel1.Controls.Add((Control) this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 1, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1008, 554);
      this.tableLayoutPanel1.TabIndex = 5;
      this.tableLayoutPanel1.Paint += new PaintEventHandler(this.tableLayoutPanel1_Paint);
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.576642f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 91.42336f));
      this.tableLayoutPanel2.Size = new Size(535, 548);
      this.tableLayoutPanel2.TabIndex = 0;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(529, 40);
      this.panel1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 554);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormCustomerNotComing);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormCustomerNotComing);
      this.Load += new EventHandler(this.FormCustomerNotComing_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
