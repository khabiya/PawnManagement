

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Properties;
using System;
using System.Collections;
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
  public class FormRokadReports : Form
  {
    private DataTable dtRokadReports = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private GlassButton btnShow;
    private TextBox tbxJammaSum;
    private TextBox tbxNovaeSum;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullDetailsToolStripMenuItem;
    private TextBox tbxDifference;
    private TableLayoutPanel tableLayoutPanel1;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private ComboBox cbLedgerType;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private TextBox tbxVoucherCode;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton8;
    private TextBox tbxToVoucherDate;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private TextBox tbxLedgerCode;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxFromVoucherDate;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private ComboBox cbVoucherName;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton2;
    private GlassButton glassButton15;
    private ComboBox comboBox1;
    private GlassButton glassButton16;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton1;
    private GlassButton glassButton17;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton18;
    private GlassButton glassButton19;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton20;
    private GlassButton glassButton21;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormRokadReports() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormRokadReports_Load(object sender, EventArgs e)
    {
      this.getLedgerType();
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\RokadReports\\LastUsed.txt")[0].ToString();
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\RokadReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void refreshGrid(string Query)
    {
      try
      {
        string strError = "";
        string my_querry = Query;
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        if (this.cbLedgerType.Text != "")
          parameters.Add(new OleDbParameter("ledgerCode", (object) this.tbxLedgerCode.Text));
        if (this.cbVoucherName.Text != "")
          parameters.Add(new OleDbParameter("vouchercode", (object) this.tbxVoucherCode.Text));
        if (this.tbxFromVoucherDate.Text != "" && this.tbxToVoucherDate.Text != "")
        {
          parameters.Add(new OleDbParameter("fromvoucherdate", (object) this.tbxFromVoucherDate.Text));
          parameters.Add(new OleDbParameter("tovoucherdate", (object) this.tbxToVoucherDate.Text));
        }
        this.dtRokadReports = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreports.refreshGrid()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreports.refreshGrid()" + strError);
        }
        else if (this.dtRokadReports != null && this.dtRokadReports.Rows.Count > 0)
          this.dataGridView1.DataSource = (object) this.dtRokadReports;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreorts.refreshgrid() 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void gettblVoucherName()
    {
      try
      {
        string strError = "";
        string my_querry = "select VoucherName from tblVoucherMaster where LedgerCode= @LedgerCode order by vouchername asc";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreports.gettblVoucherName", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreports.gettblVoucherName" + strError);
        }
        else
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            this.cbVoucherName.Items.Clear();
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              this.cbVoucherName.Items.Add((object) row["vouchername"].ToString());
          }
          this.cbVoucherName.Items.Add((object) "");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreports.getTableVoucherName", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerTypeInHindi()
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertypeinhindi from tblLedgerr where ledgertype = @ledgertype";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgertype", (object) this.cbLedgerType.Text.Trim().ToString())
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreports.getLedgerTypeInHindi", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreports.getLedgerTypeInHindi" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxLedgerCode.Text = dataTable2.Rows[0]["ledgercode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form form rokadreports.getLedgerTypeInHindi", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerType()
    {
      try
      {
        string strError = "";
        string my_querry = "select distinct(LedgerType),ledgercode,ledgertypeinhindi from tblLedgerr";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreports.getledgertype()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreports.getledgertype()" + strError);
        }
        else
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              this.cbLedgerType.Items.Add((object) row["ledgerType"].ToString());
          }
          this.cbLedgerType.Items.Add((object) "");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreports.getledgertype()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getVoucherCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblvouchermaster where vouchername = @vouchername";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("vouchername", (object) this.cbVoucherName.Text)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreports.getvouchercode()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreports.getvouchercode()" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherCode.Text = dataTable2.Rows[0]["vouchercode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreports.getledgertype()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbLedgerType_SelectedIndexChanged(object sender, EventArgs e) => this.getLedgerTypeInHindi();

    private void tbxLedgerCode_TextChanged(object sender, EventArgs e) => this.gettblVoucherName();

    private void btnShow_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.cbLedgerType.Text != "")
        str = " t1.ledgercode = @ledgerCode";
      if (this.cbVoucherName.Text != "")
        str = !(str != "") ? str + " t1.vouchercode = @vouchercode" : str + " and t1.vouchercode = @vouchercode";
      if (this.tbxFromVoucherDate.Text != "" && this.tbxToVoucherDate.Text != "")
        str = !(str != "") ? str + " (t1.voucherdate >= @fromvoucherdate and t1.voucherdate <= @tovoucherdate)" : str + " and (t1.voucherdate >= @fromvoucherdate and t1.voucherdate <= @tovoucherdate)";
      this.refreshGrid("select t3.ledgercode,t4.ledgertype,t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.jamma,t3.novae,t3.transactiontime from (SELECT t1.ledgercode,t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription, IIf(t1.jammaornovae='jamma',t1.amount,'') AS jamma, IIf(t1.jammaornovae='novae',t1.amount,'') AS novae, format(t1.createdtime,'hh:mm:ss') AS TransactionTime FROM tblvouchers t1 left join tblvouchermaster t2 on t1.vouchercode = t2.vouchercode  " + (!(str != "") ? "where active ='1'" : "where " + str + " and active = '1'") + " order by t1.createdon,t1.createdtime) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode");
      double a1 = 0.0;
      double a2 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["jamma"].Value != null && row.Cells["jamma"].Value.ToString() != "")
          a1 += double.Parse(row.Cells["jamma"].Value.ToString());
        if (row.Cells["novae"].Value != null && row.Cells["novae"].Value.ToString() != "")
          a2 += double.Parse(row.Cells["novae"].Value.ToString());
      }
      this.tbxJammaSum.Text = Math.Round(a1).ToString();
      this.tbxNovaeSum.Text = Math.Round(a2).ToString();
      this.tbxDifference.Text = Math.Round(a1 - a2).ToString("F");
    }

    private void cbVoucherName_SelectedIndexChanged(object sender, EventArgs e) => this.getVoucherCode();

    private void glassButton1_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text);
      RD.SetDataSource(this.dtRokadReports);
      RD.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
      RD.PrintOptions.PaperSize = PaperSize.PaperA4;
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\RokadReports\\\\LastUsed.txt", this.comboBox1.Text);
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

    private void viewFullDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Rokad Reports").ShowDialog();
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
      this.viewFullDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.btnShow = new GlassButton();
      this.tbxJammaSum = new TextBox();
      this.tbxNovaeSum = new TextBox();
      this.tbxDifference = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.cbLedgerType = new ComboBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.tbxVoucherCode = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.tbxToVoucherDate = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tbxLedgerCode = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxFromVoucherDate = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.cbVoucherName = new ComboBox();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.glassButton16 = new GlassButton();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton17 = new GlassButton();
      this.headerPanel9 = new HeaderPanel();
      this.glassButton18 = new GlassButton();
      this.glassButton19 = new GlassButton();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton20 = new GlassButton();
      this.glassButton21 = new GlassButton();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel9).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(5, 67);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(998, 485);
      this.dataGridView1.TabIndex = 10;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullDetailsToolStripMenuItem,
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
      this.viewFullDetailsToolStripMenuItem.Name = "viewFullDetailsToolStripMenuItem";
      this.viewFullDetailsToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullDetailsToolStripMenuItem.Text = "View Full Details";
      this.viewFullDetailsToolStripMenuItem.Click += new EventHandler(this.viewFullDetailsToolStripMenuItem_Click);
      this.btnShow.BackColor = Color.LightBlue;
      ((Control) this.btnShow).Dock = DockStyle.Fill;
      this.btnShow.FadeOnFocus = true;
      ((Control) this.btnShow).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnShow.ForeColor = Color.MediumBlue;
      this.btnShow.ForeColorOnFocus = Color.Red;
      this.btnShow.ForeColorOnLeave = Color.RoyalBlue;
      this.btnShow.GlowColor = Color.White;
      ((ButtonBase) this.btnShow).Image = (Image) Resources.SEARCHGLASS2525;
      this.btnShow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnShow).Location = new Point(873, 3);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(125, 51);
      ((Control) this.btnShow).TabIndex = 6;
      ((Control) this.btnShow).Text = "&show";
      ((ButtonBase) this.btnShow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnShow).Click += new EventHandler(this.btnShow_Click);
      this.tbxJammaSum.BackColor = Color.AliceBlue;
      this.tbxJammaSum.BorderStyle = BorderStyle.None;
      this.tbxJammaSum.Dock = DockStyle.Fill;
      this.tbxJammaSum.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxJammaSum.Location = new Point(0, 0);
      this.tbxJammaSum.Name = "tbxJammaSum";
      this.tbxJammaSum.Size = new Size(205, 31);
      this.tbxJammaSum.TabIndex = 8;
      this.tbxNovaeSum.BackColor = Color.AliceBlue;
      this.tbxNovaeSum.BorderStyle = BorderStyle.None;
      this.tbxNovaeSum.Dock = DockStyle.Fill;
      this.tbxNovaeSum.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNovaeSum.Location = new Point(0, 0);
      this.tbxNovaeSum.Name = "tbxNovaeSum";
      this.tbxNovaeSum.Size = new Size(205, 31);
      this.tbxNovaeSum.TabIndex = 9;
      this.tbxDifference.BackColor = Color.AliceBlue;
      this.tbxDifference.BorderStyle = BorderStyle.None;
      this.tbxDifference.Dock = DockStyle.Fill;
      this.tbxDifference.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDifference.Location = new Point(0, 0);
      this.tbxDifference.Name = "tbxDifference";
      this.tbxDifference.Size = new Size(205, 31);
      this.tbxDifference.TabIndex = 18;
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.ColumnCount = 7;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.94872f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.82051f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.94872f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.82051f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.82051f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.82051f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.82051f));
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel4, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel5, 3, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel3, 5, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel6, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel2, 4, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel1, 2, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.btnShow, 6, 0);
      this.tableLayoutPanel1.Location = new Point(5, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1001, 57);
      this.tableLayoutPanel1.TabIndex = 19;
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
      this.headerPanel4.CaptionText = "LEDGER TYPE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbLedgerType);
      ((Control) this.headerPanel4).Dock = DockStyle.Fill;
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(3, 3);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(173, 51);
      ((Control) this.headerPanel4).TabIndex = 76;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton6).Location = new Point((int) sbyte.MinValue, 513);
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
      ((Control) this.glassButton7).Location = new Point(6, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbLedgerType.BackColor = Color.AliceBlue;
      this.cbLedgerType.Dock = DockStyle.Fill;
      this.cbLedgerType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType.FormattingEnabled = true;
      this.cbLedgerType.Location = new Point(0, 0);
      this.cbLedgerType.Name = "cbLedgerType";
      this.cbLedgerType.Size = new Size(171, 24);
      this.cbLedgerType.TabIndex = 0;
      this.cbLedgerType.SelectedIndexChanged += new EventHandler(this.cbLedgerType_SelectedIndexChanged);
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel5.CaptionEndColor = Color.AliceBlue;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "VOUCHER CODE";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxVoucherCode);
      ((Control) this.headerPanel5).Dock = DockStyle.Fill;
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(489, 3);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(122, 51);
      ((Control) this.headerPanel5).TabIndex = 81;
      this.headerPanel5.TextAntialias = true;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      ((ButtonBase) this.glassButton9).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(-183, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&SAVE";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(-49, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxVoucherCode.BackColor = Color.AliceBlue;
      this.tbxVoucherCode.BorderStyle = BorderStyle.None;
      this.tbxVoucherCode.Dock = DockStyle.Fill;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(0, 0);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.ReadOnly = true;
      this.tbxVoucherCode.Size = new Size(120, 24);
      this.tbxVoucherCode.TabIndex = 0;
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
      this.headerPanel3.CaptionText = "TO DATE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxToVoucherDate);
      ((Control) this.headerPanel3).Dock = DockStyle.Fill;
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(745, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(122, 51);
      ((Control) this.headerPanel3).TabIndex = 79;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton5).Location = new Point(-181, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(-47, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToVoucherDate.BackColor = Color.AliceBlue;
      this.tbxToVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxToVoucherDate.Dock = DockStyle.Fill;
      this.tbxToVoucherDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToVoucherDate.Location = new Point(0, 0);
      this.tbxToVoucherDate.Name = "tbxToVoucherDate";
      this.tbxToVoucherDate.Size = new Size(120, 24);
      this.tbxToVoucherDate.TabIndex = 0;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel6.CaptionEndColor = Color.AliceBlue;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "LEDGER CODE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxLedgerCode);
      ((Control) this.headerPanel6).Dock = DockStyle.Fill;
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(182, 3);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(122, 51);
      ((Control) this.headerPanel6).TabIndex = 80;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton11.BackColor = Color.LightBlue;
      this.glassButton11.FadeOnFocus = true;
      ((Control) this.glassButton11).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton11.ForeColor = Color.MediumBlue;
      this.glassButton11.ForeColorOnFocus = Color.Red;
      this.glassButton11.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton11.GlowColor = Color.White;
      ((ButtonBase) this.glassButton11).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton11.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton11).Location = new Point(-183, 513);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(128, 35);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&SAVE";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(-49, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 0;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxLedgerCode.BackColor = Color.AliceBlue;
      this.tbxLedgerCode.BorderStyle = BorderStyle.None;
      this.tbxLedgerCode.Dock = DockStyle.Fill;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(0, 0);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.ReadOnly = true;
      this.tbxLedgerCode.Size = new Size(120, 24);
      this.tbxLedgerCode.TabIndex = 0;
      this.tbxLedgerCode.TextChanged += new EventHandler(this.tbxLedgerCode_TextChanged);
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
      this.headerPanel2.CaptionText = "FROM DATE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxFromVoucherDate);
      ((Control) this.headerPanel2).Dock = DockStyle.Fill;
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(617, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(122, 51);
      ((Control) this.headerPanel2).TabIndex = 78;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-181, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(-47, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxFromVoucherDate.BackColor = Color.AliceBlue;
      this.tbxFromVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxFromVoucherDate.Dock = DockStyle.Fill;
      this.tbxFromVoucherDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromVoucherDate.Location = new Point(0, 0);
      this.tbxFromVoucherDate.Name = "tbxFromVoucherDate";
      this.tbxFromVoucherDate.Size = new Size(120, 24);
      this.tbxFromVoucherDate.TabIndex = 0;
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
      this.headerPanel1.CaptionText = "VOUCHER TYPE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbVoucherName);
      ((Control) this.headerPanel1).Dock = DockStyle.Fill;
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(310, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(173, 51);
      ((Control) this.headerPanel1).TabIndex = 77;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      ((ButtonBase) this.glassButton13).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(-130, 513);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(128, 35);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&SAVE";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(4, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 0;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbVoucherName.BackColor = Color.AliceBlue;
      this.cbVoucherName.Dock = DockStyle.Fill;
      this.cbVoucherName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbVoucherName.FormattingEnabled = true;
      this.cbVoucherName.Location = new Point(0, 0);
      this.cbVoucherName.Name = "cbVoucherName";
      this.cbVoucherName.Size = new Size(171, 24);
      this.cbVoucherName.TabIndex = 0;
      this.cbVoucherName.SelectedIndexChanged += new EventHandler(this.cbVoucherName_SelectedIndexChanged);
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "PRINT";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel7).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = Color.Azure;
      this.headerPanel7.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel7).Location = new Point(8, 558);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(364, 58);
      ((Control) this.headerPanel7).TabIndex = 74;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton2).Location = new Point(71, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton15).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton15.BackColor = Color.LightBlue;
      this.glassButton15.FadeOnFocus = true;
      ((Control) this.glassButton15).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton15.ForeColor = Color.MediumBlue;
      this.glassButton15.ForeColorOnFocus = Color.Red;
      this.glassButton15.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton15.GlowColor = Color.White;
      this.glassButton15.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton15).Location = new Point(205, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(292, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(296, 4);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(61, 26);
      ((Control) this.glassButton16).TabIndex = 24;
      ((Control) this.glassButton16).Text = "&PRINT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton16).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "JAMMA TOTAL";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxJammaSum);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = Color.Azure;
      this.headerPanel8.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel8).Location = new Point(378, 558);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(207, 58);
      ((Control) this.headerPanel8).TabIndex = 75;
      this.headerPanel8.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(-88, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(46, 512);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(123, 37);
      ((Control) this.glassButton17).TabIndex = 1;
      ((Control) this.glassButton17).Text = "&EXIT";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel9).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel9).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.HotTrack;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel9.CaptionEndColor = Color.AliceBlue;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "NOVAE TOTAL";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel9).Controls.Add((Control) this.tbxNovaeSum);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = Color.Azure;
      this.headerPanel9.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel9).Location = new Point(590, 558);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(207, 58);
      ((Control) this.headerPanel9).TabIndex = 76;
      this.headerPanel9.TextAntialias = true;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      ((ButtonBase) this.glassButton18).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(-90, 513);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(128, 35);
      ((Control) this.glassButton18).TabIndex = 0;
      ((Control) this.glassButton18).Text = "&SAVE";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton19).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      ((Control) this.glassButton19).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(44, 512);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(123, 37);
      ((Control) this.glassButton19).TabIndex = 1;
      ((Control) this.glassButton19).Text = "&EXIT";
      ((ButtonBase) this.glassButton19).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel10).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel10).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.HotTrack;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel10.CaptionEndColor = Color.AliceBlue;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "DIFFERENCE";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel10).Controls.Add((Control) this.tbxDifference);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = Color.Azure;
      this.headerPanel10.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel10).Location = new Point(799, 558);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(207, 58);
      ((Control) this.headerPanel10).TabIndex = 76;
      this.headerPanel10.TextAntialias = true;
      ((Control) this.glassButton20).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton20.BackColor = Color.LightBlue;
      this.glassButton20.FadeOnFocus = true;
      ((Control) this.glassButton20).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton20.ForeColor = Color.MediumBlue;
      this.glassButton20.ForeColorOnFocus = Color.Red;
      this.glassButton20.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton20.GlowColor = Color.White;
      ((ButtonBase) this.glassButton20).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton20.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton20).Location = new Point(-90, 513);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(128, 35);
      ((Control) this.glassButton20).TabIndex = 0;
      ((Control) this.glassButton20).Text = "&SAVE";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton21).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton21.BackColor = Color.LightBlue;
      this.glassButton21.FadeOnFocus = true;
      ((Control) this.glassButton21).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton21.ForeColor = Color.MediumBlue;
      this.glassButton21.ForeColorOnFocus = Color.Red;
      this.glassButton21.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton21.GlowColor = Color.White;
      this.glassButton21.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton21).Location = new Point(44, 512);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(123, 37);
      ((Control) this.glassButton21).TabIndex = 1;
      ((Control) this.glassButton21).Text = "&EXIT";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel10);
      this.Controls.Add((Control) this.headerPanel9);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormRokadReports);
      this.Text = nameof (FormRokadReports);
      this.Load += new EventHandler(this.FormRokadReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel9).PerformLayout();
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel10).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
