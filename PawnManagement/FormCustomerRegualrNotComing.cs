
using ExportToExcel11;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormCustomerRegualrNotComing : Form
  {
    private DataTable dtSms = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxNotes;
    private TextBox tbxNumber;
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
    private PictureBox pictureBox1;
    private PictureBox pictureBox5;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormCustomerRegualrNotComing() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "SELECT customercode, maxbilldate as [Customer's Last Appearance],numberofbills as [Number of bills pledged by the customer], averagenumberofdays as [Average number of days customer appears], numberofdayscustomerdidnotcome as  [Number of days customer did not come] FROM (SELECT customercode, numberofbills, maxbilldate, minbilldate, numberofdays, round(numberofdays/numberofbills,0) AS averageNumberOfDays, datediff('d',maxbilldate,date()) AS numberofdayscustomerdidnotcome FROM (SELECT customercode, NumberofBills, MaxBilldate, minbilldate, datediff('d',minbilldate,maxbilldate) AS NumberOfDays FROM (SELECT customercode, count(*) AS NumberOfBills, max(billdate) AS MaxBillDate, min(billdate) AS MinBillDate FROM tblpledge GROUP BY customercode)  AS [%$##@_Alias])  AS [%$##@_Alias])  AS p order by p.numberofbills desc,p.averagenumberofdays";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in retrieving the data" + strError);
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return;
      PawnManagementClass.InsertIntoException("form customerRegularNotComing.refreshGrid", strError, FormMain.username, DateTime.Now.ToString());
      this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
          return;
        string customerCode = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["customercode"].Value.ToString();
        this.getPicture(customerCode);
        this.getCustomerDetails(customerCode);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerRegularNotComing", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPicture(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
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
        PawnManagementClass.InsertIntoException("form CustomerRegularNotComing.getPicture(string customercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getCustomerDetails(string customerCode)
    {
      try
      {
        string strError = "";
        string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,Cnotes from tblCustomers where CID = @cid";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("cid", (object) customerCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form customerRegularnotComing", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving data" + strError);
        }
        else
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
            this.tbxNotes.Text = dataTable2.Rows[0].Field<string>("CNotes").ToString();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customerRegularNotComing.getCustomerDetails(string customercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void FormCustomerRegualrNotComing_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
      this.dataGridView1.ColumnHeadersHeight = 50;
      this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPhoneNumber.Text != ""))
        return;
      int num = (int) new FormCall(this.tbxPhoneNumber.Text.ToString()).ShowDialog();
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

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "CustomerRegularNotComing", FormMain.username);

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      string customerCode = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["customercode"].Value.ToString();
      this.getPicture(customerCode);
      this.getCustomerDetails(customerCode);
    }

    private void pictureBox2_DoubleClick(object sender, EventArgs e) => new Formphoto(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.ToString() + ".png").Show();

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
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "REGULAR CUSTOMER NOT COMING").ShowDialog();
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
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tbxNotes = new TextBox();
      this.tbxNumber = new TextBox();
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
      this.pictureBox1 = new PictureBox();
      this.pictureBox5 = new PictureBox();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(12, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(985, 430);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.KeyUp += new KeyEventHandler(this.dataGridView1_KeyUp);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 114);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tbxNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(182, 570);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(429, 26);
      this.tbxNotes.TabIndex = 28;
      this.tbxNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNumber.Location = new Point(182, 480);
      this.tbxNumber.Name = "tbxNumber";
      this.tbxNumber.Size = new Size(95, 26);
      this.tbxNumber.TabIndex = 27;
      this.pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox2.Location = new Point(12, 448);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(158, 176);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.DoubleClick += new EventHandler(this.pictureBox2_DoubleClick);
      this.tbxCustomerName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxCustomerName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(283, 450);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(328, 26);
      this.tbxCustomerName.TabIndex = 0;
      this.tbxCustomerCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(182, 451);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(95, 26);
      this.tbxCustomerCode.TabIndex = 8;
      this.tbxCustomerCode.TextAlign = HorizontalAlignment.Center;
      this.tbxPhoneNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.Location = new Point(626, 451);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(204, 26);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxCell.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxCell.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.Location = new Point(626, 483);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(204, 26);
      this.tbxCell.TabIndex = 22;
      this.tbxAddress1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxAddress1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.Location = new Point(283, 480);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(328, 26);
      this.tbxAddress1.TabIndex = 5;
      this.tbxAddress2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxAddress2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.Location = new Point(182, 509);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(429, 26);
      this.tbxAddress2.TabIndex = 6;
      this.tbxCity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(182, 598);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(204, 26);
      this.tbxCity.TabIndex = 9;
      this.tbxPincode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxPincode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(393, 598);
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(218, 26);
      this.tbxPincode.TabIndex = 10;
      this.tbxAddress3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxAddress3.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress3.Location = new Point(182, 540);
      this.tbxAddress3.Name = "tbxAddress3";
      this.tbxAddress3.Size = new Size(429, 26);
      this.tbxAddress3.TabIndex = 8;
      this.pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox1.Image = (Image) Resources.callbutton;
      this.pictureBox1.Location = new Point(836, 453);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(59, 56);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 45;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox5.Image = (Image) Resources.message;
      this.pictureBox5.Location = new Point(901, 453);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(59, 56);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 60;
      this.pictureBox5.TabStop = false;
      this.pictureBox5.Click += new EventHandler(this.pictureBox5_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.pictureBox5);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.tbxNotes);
      this.Controls.Add((Control) this.tbxNumber);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.tbxCustomerName);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.tbxCustomerCode);
      this.Controls.Add((Control) this.tbxAddress3);
      this.Controls.Add((Control) this.tbxPhoneNumber);
      this.Controls.Add((Control) this.tbxPincode);
      this.Controls.Add((Control) this.tbxCell);
      this.Controls.Add((Control) this.tbxCity);
      this.Controls.Add((Control) this.tbxAddress1);
      this.Controls.Add((Control) this.tbxAddress2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormCustomerRegualrNotComing);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormCustomerRegualrNotComing);
      this.Load += new EventHandler(this.FormCustomerRegualrNotComing_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
