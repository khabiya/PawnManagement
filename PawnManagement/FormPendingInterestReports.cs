

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPendingInterestReports : Form
  {
    private DataTable dt = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LightBlueFadeDown.jpg");
    private double totalAmount;
    private double totalInterest;
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private DataGridView dgvCustomerPledgeDetails;
    private Label label4;
    private Label label3;
    private Label label2;
    private ComboBox cbType;
    private TextBox tbxToDate;
    private TextBox tbxFromDate;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private ComboBox comboBox1;
    private GlassButton btnPrint;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxtotalPendingInterest;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton3;
    private GlassButton glassButton6;
    private TextBox tbxTotalAmountPlusInterest;
    private HeaderPanel headerPanel13;
    private GlassButton glassButton26;
    private GlassButton glassButton27;
    private TextBox tbxTotalAmount;
    private Label label1;
    private ComboBox cbShopCodes;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormPendingInterestReports() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getCustomerPledgeDetails(DateTime d1, DateTime d2)
    {
      string strError = "";
      string my_querry = !(this.cbType.Text == "") ? (!(this.cbShopCodes.Text == "") ? "select BillNumber,BillDate,CustomerCode,CustomerName,doornumber + addr1 + addr2 + addr3 as Address,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight,BankCode,BankSerialNumber from tblPledge where (BillDate between @BillDate1 and @BillDate2) and (Redeemed ='N') and  (type in ('" + this.cbType.Text + "')) and shopcode = @ShopCode order by billdate" : "select BillNumber,BillDate,CustomerCode,CustomerName,doornumber + addr1 + addr2 + addr3 as Address,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight,BankCode,BankSerialNumber from tblPledge where (BillDate between @BillDate1 and @BillDate2) and (Redeemed ='N') and  (type in ('" + this.cbType.Text + "')) order by billdate") : (!(this.cbShopCodes.Text == "") ? "select tp.BillNumber,BillDate,CustomerCode,CustomerName,doornumber + addr1 + addr2 + addr3 as Address,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight,BankCode,BankSerialNumber,articles from tblPledge tp where (BillDate between @BillDate1 and @BillDate2) and (Redeemed ='N') and shopcode = @ShopCode order by billdate" : "select tp.BillNumber,BillDate,CustomerCode,CustomerName,doornumber + addr1 + addr2 + addr3 as Address,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight,BankCode,BankSerialNumber,articles from tblPledge tp where (BillDate between @BillDate1 and @BillDate2) and (Redeemed ='N') order by billdate");
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillDate1", (object) d1.ToShortDateString()));
      parameters.Add(new OleDbParameter("BillDate2", (object) d2.ToShortDateString()));
      if (this.cbShopCodes.Text != "")
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      this.dt = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pendingInterest.getcustomerpledgedetails", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching form pendingInterest.getcustomerpledgedetails .\n" + strError);
      }
      else
      {
        this.dt.Columns.Add("Interest", typeof (double));
        if (this.dt == null || this.dt.Rows.Count <= 0)
          ;
        this.getTotalPendingPledges();
        this.dgvCustomerPledgeDetails.DataSource = (object) this.dt;
      }
    }

    private void getTotalPendingPledges()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        for (int index = 0; index < this.dt.Rows.Count; ++index)
        {
          DateTime.Parse(this.dt.Rows[index]["BillDate"].ToString());
          int num = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.dt.Rows[index]["BillDate"].ToString()), DateTime.Today) - 1;
          string s1 = this.dt.Rows[index]["Amount"].ToString();
          string s2 = this.dt.Rows[index]["InterestRate"].ToString();
          string s3 = "";
          if (num != -1)
          {
            this.dt.Rows[index]["Interest"] = (object) Math.Round(double.Parse(s1) * double.Parse(s2) * (double) num / 1200.0);
            s3 = this.dt.Rows[index]["Interest"].ToString();
          }
          this.totalAmount += double.Parse(s1);
          this.totalInterest += double.Parse(s3);
        }
        this.tbxTotalAmount.Text = Math.Round(this.totalAmount).ToString();
        this.tbxtotalPendingInterest.Text = Math.Round(this.totalInterest).ToString();
        this.tbxTotalAmountPlusInterest.Text = Math.Round(this.totalAmount + this.totalInterest).ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getTotalPendingPledges()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void Form3_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.tbxFromDate.Text = DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      this.getCustomerPledgeDetails(DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["BillDate"].ToString()), DateTime.Now);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvCustomerPledgeDetails);
      this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
      this.getPledgeReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\PendingInterestReports\\LastUsed.txt")[0].ToString();
    }

    private void dgvCustomerPledgeDetails_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      this.dgvCustomerPledgeDetails.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dgvCustomerPledgeDetails.Columns["InterestRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dgvCustomerPledgeDetails.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dgvCustomerPledgeDetails.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dgvCustomerPledgeDetails.Columns["presentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dgvCustomerPledgeDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void SHOW()
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        {
          if (!(DateTime.Parse(this.tbxFromDate.Text) < DateTime.Parse(this.tbxToDate.Text)))
            return;
          this.getCustomerPledgeDetails(DateTime.Parse(this.tbxFromDate.Text), DateTime.Parse(this.tbxToDate.Text));
        }
        else
          this.tbxToDate.Select();
      }
      else
        this.tbxFromDate.Select();
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.comboBox1.Text != "")
      {
        ReportDocument RD = new ReportDocument();
        RD.Load(this.comboBox1.Text);
        RD.SetDataSource((DataTable) this.dgvCustomerPledgeDetails.DataSource);
        RD.PrintOptions.PaperSize = PaperSize.PaperA4;
        int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please select a report format");
      }
      File.WriteAllText("Reports\\\\PendingInterestReports\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
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
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Pending INterest Reports").ShowDialog();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void dgvCustomerPledgeDetails_CellPainting(
      object sender,
      DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void getPledgeReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\PendingInterestReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void tbxFromDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.SHOW();
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.SHOW();
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e) => this.SHOW();

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == ""))
        return;
      this.SHOW();
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

    private void dgvCustomerPledgeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvCustomerPledgeDetails.Rows.Count <= 0 || !(this.dgvCustomerPledgeDetails.CurrentCell.OwningColumn.HeaderText == "CustomerCode"))
        return;
      string CUSTOMERCODE = this.dgvCustomerPledgeDetails.Rows[this.dgvCustomerPledgeDetails.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
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
      this.panel2 = new Panel();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxtotalPendingInterest = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxTotalAmountPlusInterest = new TextBox();
      this.headerPanel13 = new HeaderPanel();
      this.glassButton26 = new GlassButton();
      this.glassButton27 = new GlassButton();
      this.tbxTotalAmount = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.btnPrint = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.label1 = new Label();
      this.cbShopCodes = new ComboBox();
      this.tbxFromDate = new TextBox();
      this.tbxToDate = new TextBox();
      this.cbType = new ComboBox();
      this.label4 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.dgvCustomerPledgeDetails = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel13).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((ISupportInitialize) this.dgvCustomerPledgeDetails).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 616f));
      this.tableLayoutPanel1.Size = new Size(1008, 616);
      this.tableLayoutPanel1.TabIndex = 0;
      this.panel2.BackColor = Color.AliceBlue;
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.headerPanel4);
      this.panel2.Controls.Add((Control) this.headerPanel13);
      this.panel2.Controls.Add((Control) this.headerPanel3);
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Controls.Add((Control) this.dgvCustomerPledgeDetails);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 610);
      this.panel2.TabIndex = 1;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel1.CaptionText = "INTEREST";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxtotalPendingInterest);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(603, 546);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(195, 58);
      ((Control) this.headerPanel1).TabIndex = 77;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(-100, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(34, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxtotalPendingInterest.BackColor = Color.AliceBlue;
      this.tbxtotalPendingInterest.BorderStyle = BorderStyle.None;
      this.tbxtotalPendingInterest.Dock = DockStyle.Fill;
      this.tbxtotalPendingInterest.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxtotalPendingInterest.Location = new Point(0, 0);
      this.tbxtotalPendingInterest.Name = "tbxtotalPendingInterest";
      this.tbxtotalPendingInterest.Size = new Size(193, 31);
      this.tbxtotalPendingInterest.TabIndex = 25;
      this.tbxtotalPendingInterest.TextAlign = HorizontalAlignment.Center;
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
      this.headerPanel4.CaptionText = "TOTAL";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxTotalAmountPlusInterest);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(803, 546);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(195, 58);
      ((Control) this.headerPanel4).TabIndex = 77;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-100, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(34, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxTotalAmountPlusInterest.BackColor = Color.AliceBlue;
      this.tbxTotalAmountPlusInterest.BorderStyle = BorderStyle.None;
      this.tbxTotalAmountPlusInterest.Dock = DockStyle.Fill;
      this.tbxTotalAmountPlusInterest.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmountPlusInterest.Location = new Point(0, 0);
      this.tbxTotalAmountPlusInterest.Name = "tbxTotalAmountPlusInterest";
      this.tbxTotalAmountPlusInterest.Size = new Size(193, 31);
      this.tbxTotalAmountPlusInterest.TabIndex = 25;
      this.tbxTotalAmountPlusInterest.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel13).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel13).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel13).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel13.BorderColor = SystemColors.HotTrack;
      this.headerPanel13.BorderStyle = BorderStyles.Single;
      this.headerPanel13.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel13.CaptionEndColor = Color.AliceBlue;
      this.headerPanel13.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.CaptionHeight = 22;
      this.headerPanel13.CaptionPosition = CaptionPositions.Top;
      this.headerPanel13.CaptionText = "AMOUNT";
      this.headerPanel13.CaptionVisible = true;
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton26);
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton27);
      ((Control) this.headerPanel13).Controls.Add((Control) this.tbxTotalAmount);
      ((Control) this.headerPanel13).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel13).ForeColor = Color.DarkBlue;
      this.headerPanel13.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.GradientEnd = SystemColors.ControlLight;
      this.headerPanel13.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).Location = new Point(403, 546);
      ((Control) this.headerPanel13).Name = "headerPanel13";
      this.headerPanel13.PanelIcon = (Icon) null;
      this.headerPanel13.PanelIconVisible = false;
      ((Control) this.headerPanel13).Size = new Size(195, 58);
      ((Control) this.headerPanel13).TabIndex = 77;
      this.headerPanel13.TextAntialias = true;
      ((Control) this.glassButton26).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton26.BackColor = Color.LightBlue;
      this.glassButton26.FadeOnFocus = true;
      ((Control) this.glassButton26).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton26.ForeColor = Color.MediumBlue;
      this.glassButton26.ForeColorOnFocus = Color.Red;
      this.glassButton26.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton26.GlowColor = Color.White;
      ((ButtonBase) this.glassButton26).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton26.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton26).Location = new Point(-100, 513);
      ((Control) this.glassButton26).Name = "glassButton26";
      this.glassButton26.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton26.ShineColor = Color.Transparent;
      ((Control) this.glassButton26).Size = new Size(128, 35);
      ((Control) this.glassButton26).TabIndex = 0;
      ((Control) this.glassButton26).Text = "&SAVE";
      ((ButtonBase) this.glassButton26).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton27).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton27.BackColor = Color.LightBlue;
      this.glassButton27.FadeOnFocus = true;
      ((Control) this.glassButton27).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton27.ForeColor = Color.MediumBlue;
      this.glassButton27.ForeColorOnFocus = Color.Red;
      this.glassButton27.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton27.GlowColor = Color.White;
      this.glassButton27.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton27).Location = new Point(34, 512);
      ((Control) this.glassButton27).Name = "glassButton27";
      this.glassButton27.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton27.ShineColor = Color.Transparent;
      ((Control) this.glassButton27).Size = new Size(123, 37);
      ((Control) this.glassButton27).TabIndex = 1;
      ((Control) this.glassButton27).Text = "&EXIT";
      ((ButtonBase) this.glassButton27).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxTotalAmount.BackColor = Color.AliceBlue;
      this.tbxTotalAmount.BorderStyle = BorderStyle.None;
      this.tbxTotalAmount.Dock = DockStyle.Fill;
      this.tbxTotalAmount.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmount.Location = new Point(0, 0);
      this.tbxTotalAmount.Name = "tbxTotalAmount";
      this.tbxTotalAmount.Size = new Size(193, 31);
      this.tbxTotalAmount.TabIndex = 25;
      this.tbxTotalAmount.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel3.CaptionText = "PRINT";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.btnPrint);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(6, 546);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(392, 58);
      ((Control) this.headerPanel3).TabIndex = 74;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton4).Location = new Point(99, 513);
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
      ((Control) this.glassButton5).Location = new Point(233, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(320, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.btnPrint).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      ((Control) this.btnPrint).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrint.GlowColor = Color.White;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(324, 4);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(61, 26);
      ((Control) this.btnPrint).TabIndex = 24;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((ButtonBase) this.btnPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrint).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.Azure;
      this.headerPanel2.CaptionEndColor = Color.SkyBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "SELECT DATE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(3, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(996, 67);
      ((Control) this.headerPanel2).TabIndex = 33;
      this.headerPanel2.TextAntialias = true;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(617, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(87, 25);
      this.label1.TabIndex = 69;
      this.label1.Text = "License";
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(706, 15);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(283, 23);
      this.cbShopCodes.TabIndex = 68;
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.tbxFromDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(75, 7);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(122, 31);
      this.tbxFromDate.TabIndex = 62;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxToDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(248, 7);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size((int) sbyte.MaxValue, 31);
      this.tbxToDate.TabIndex = 63;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbType.FlatStyle = FlatStyle.Popup;
      this.cbType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[4]
      {
        (object) "",
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(460, 5);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(145, 33);
      this.cbType.TabIndex = 64;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(395, 13);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 25);
      this.label4.TabIndex = 67;
      this.label4.Text = "Type";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(13, 13);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 25);
      this.label2.TabIndex = 65;
      this.label2.Text = "From";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(208, 13);
      this.label3.Name = "label3";
      this.label3.Size = new Size(37, 25);
      this.label3.TabIndex = 66;
      this.label3.Text = "To";
      this.dgvCustomerPledgeDetails.AllowUserToAddRows = false;
      this.dgvCustomerPledgeDetails.AllowUserToDeleteRows = false;
      this.dgvCustomerPledgeDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvCustomerPledgeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvCustomerPledgeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvCustomerPledgeDetails.Location = new Point(4, 74);
      this.dgvCustomerPledgeDetails.Name = "dgvCustomerPledgeDetails";
      this.dgvCustomerPledgeDetails.ReadOnly = true;
      this.dgvCustomerPledgeDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvCustomerPledgeDetails.Size = new Size(995, 466);
      this.dgvCustomerPledgeDetails.TabIndex = 61;
      this.dgvCustomerPledgeDetails.CellClick += new DataGridViewCellEventHandler(this.dgvCustomerPledgeDetails_CellClick);
      this.dgvCustomerPledgeDetails.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvCustomerPledgeDetails_CellPainting);
      this.dgvCustomerPledgeDetails.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomerPledgeDetails_DataBindingComplete);
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
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 616);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormPendingInterestReports);
      this.Text = "Form3";
      this.Load += new EventHandler(this.Form3_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel13).ResumeLayout(false);
      ((Control) this.headerPanel13).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((ISupportInitialize) this.dgvCustomerPledgeDetails).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
