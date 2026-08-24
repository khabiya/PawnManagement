

using CrystalDecisions.CrystalReports.Engine;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
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
  public class FormCashBook : Form
  {
    private DataTable dtjammaAndNovaeSum = new DataTable();
    private DataTable dtCashBook = new DataTable();
    private string rokadDate = "";
    private IContainer components = (IContainer) null;
    private GlassButton glassButton1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private DataGridView dataGridView1;
    private ComboBox comboBox1;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxOpeningBalance;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private TextBox tbxJamma;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private TextBox tbxRokadDate;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private TextBox tbxNovae;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxCashInHand;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton12;
    private GlassButton glassButton13;

    public FormCashBook() => this.InitializeComponent();

    public FormCashBook(string ROKADDATE)
    {
      this.rokadDate = ROKADDATE;
      this.InitializeComponent();
    }

    private void refreshGrid(string voucherDate)
    {
      try
      {
        string strError = "";
        this.dtCashBook = SQLHelper.GetDataTable("select t3.ledgercode,t4.ledgertype,t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.jamma,t3.novae,t3.transactiontime from (SELECT t1.ledgercode,t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription, IIf(t1.jammaornovae='jamma',t1.amount,'') AS jamma, IIf(t1.jammaornovae='novae',t1.amount,'') AS novae, format(t1.createdtime,'hh:mm:ss') AS TransactionTime FROM tblvouchers t1 left join tblvouchermaster t2 on t1.vouchercode = t2.vouchercode where t1.voucherdate = @voucherdate and active = '1' order by t1.createdon,t1.createdtime) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by t3.voucherDate", new List<OleDbParameter>()
        {
          new OleDbParameter("voucherdate", (object) voucherDate)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form cashbook.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in refreshgrid()" + strError);
        }
        else
        {
          if (this.dtCashBook != null && this.dtCashBook.Rows.Count > 0)
          {
            double num1 = 0.0;
            double num2 = 0.0;
            double num3 = double.Parse(this.tbxOpeningBalance.Text);
            this.dtCashBook.Columns.Add("Balance", typeof (double));
            foreach (DataRow row in (InternalDataCollectionBase) this.dtCashBook.Rows)
            {
              if (row["jamma"] != null && PawnManagementClass.IsDigitsOnly(row["jamma"].ToString()))
              {
                num1 += double.Parse(row["jamma"].ToString());
                num3 += double.Parse(row["jamma"].ToString());
              }
              if (row["novae"] != null && PawnManagementClass.IsDigitsOnly(row["novae"].ToString()))
              {
                num2 += double.Parse(row["novae"].ToString());
                num3 -= double.Parse(row["novae"].ToString());
              }
              row["Balance"] = (object) num3;
            }
          }
          this.dataGridView1.DataSource = (object) this.dtCashBook;
          if (this.dataGridView1.Columns.Contains("Balance"))
            this.dataGridView1.Columns["Balance"].DisplayIndex = 9;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CashBook.refreshGrid().outerexception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getJammaSumAndNovaeSum(string voucherDate)
    {
      try
      {
        string strError = "";
        string my_querry = "select sum(jamma) as jammasum ,sum(novae) as novaesum from (SELECT t3.ledgercode, t4.ledgertype, t4.ledgertypeinhindi, t3.voucherdate, t3.vouchernumber, t3.vouchercode, t3.vouchername, t3.voucherdescription, t3.jamma, t3.novae, t3.transactiontime FROM (SELECT t1.ledgercode, t1.voucherdate, t1.vouchernumber, t1.vouchercode, t2.vouchername, t1.voucherdescription, IIf(t1.jammaornovae='jamma',t1.amount,0) AS jamma, IIf(t1.jammaornovae='novae',t1.amount,0) AS novae, format(t1.createdtime,'hh:mm:ss') AS TransactionTime FROM tblvouchers AS t1 LEFT JOIN tblvouchermaster AS t2 ON t1.vouchercode=t2.vouchercode WHERE t1.voucherdate=[@voucherdate] and active = '1' ORDER BY t1.createdon, t1.createdtime)  AS t3 LEFT JOIN tblledgerr AS t4 ON t3.ledgercode=t4.ledgercode) ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("voucherdate", (object) voucherDate));
        DataTable dataTable = new DataTable();
        this.dtjammaAndNovaeSum = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (!(strError != ""))
          return;
        PawnManagementClass.InsertIntoException("form cashbook.getjammasumandnovaesum", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form cashbook.getjammasumandnovaesum" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CashBook.getjammasumandnovaesum(string voucherdate) outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getOpeningBalance(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form cashbook.getopeningbalance(datetime d1)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form cashbook.getopeningbalance(datetime d1)" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        this.tbxOpeningBalance.Text = dataTable.Rows[0]["OpeningBalance"].ToString();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormCashBook_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      if (PawnManagementClass.checkForValidateDate(this.rokadDate))
      {
        if (PawnManagementClass.checkIfRokadFinishedOrNot(this.rokadDate))
        {
          this.getcashBook(DateTime.Parse(this.rokadDate).ToString("dd/MM/yyyy"));
        }
        else
        {
          int num1 = (int) MessageBox.Show("CashBook not available for this date");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid date....");
      }
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\CashBook\\LastUsed.txt")[0].ToString();
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\CashBook\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private bool seeIfVoucherEntryThereOrNot()
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblVouchers where rokadDate = @rokadDate AND active = '1'";
      parameters.Add(new OleDbParameter("rokadDate", (object) this.rokadDate));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form cashbook.seeifcoucherenterythereornot", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form cashbook.seeifcoucherenterythereornot" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        return true;
      return false;
    }

    private void getcashBook(string rokadDate)
    {
      try
      {
        this.getOpeningBalance(DateTime.Parse(rokadDate));
        this.tbxRokadDate.Text = rokadDate;
        this.refreshGrid(rokadDate);
        if (!this.seeIfVoucherEntryThereOrNot())
          return;
        this.dataGridView1.Columns["ledgercode"].Visible = false;
        this.dataGridView1.Columns["vouchercode"].Visible = false;
        this.getJammaSumAndNovaeSum(rokadDate);
        if (this.dtjammaAndNovaeSum != null && this.dtjammaAndNovaeSum.Rows.Count > 0)
        {
          if (this.dtjammaAndNovaeSum.Rows[0]["jammasum"] != null && this.dtjammaAndNovaeSum.Rows[0]["novaesum"].ToString() != null && this.dtjammaAndNovaeSum.Rows[0]["jammasum"] != (object) "" && this.dtjammaAndNovaeSum.Rows[0]["novaesum"].ToString() != "")
          {
            this.tbxCashInHand.Text = (double.Parse(this.tbxOpeningBalance.Text.Trim().ToString()) + (double.Parse(this.dtjammaAndNovaeSum.Rows[0]["jammasum"].ToString()) - double.Parse(this.dtjammaAndNovaeSum.Rows[0]["Novaesum"].ToString()))).ToString();
            TextBox tbxJamma = this.tbxJamma;
            double num = double.Parse(this.dtjammaAndNovaeSum.Rows[0]["jammasum"].ToString());
            string str1 = num.ToString();
            tbxJamma.Text = str1;
            TextBox tbxNovae = this.tbxNovae;
            num = double.Parse(this.dtjammaAndNovaeSum.Rows[0]["novaesum"].ToString());
            string str2 = num.ToString();
            tbxNovae.Text = str2;
          }
          else
          {
            int num1 = (int) MessageBox.Show("Cash book empty..No transactions made");
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form cashbook.getcashbook(string rokaddate)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxRokadDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxRokadDate.Text.Trim().ToString()))
      {
        if (PawnManagementClass.checkIfRokadFinishedOrNot(this.tbxRokadDate.Text.Trim().ToString()))
        {
          this.getcashBook(this.tbxRokadDate.Text.Trim().ToString());
        }
        else
        {
          int num1 = (int) MessageBox.Show("CashBook not available for this date");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid date....");
      }
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text);
      RD.SetDataSource(this.dtCashBook);
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\CashBook\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void glassButton2_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "CashBook", FormMain.username);

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "CashBook", FormMain.username);

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "CASH BOOK").ShowDialog();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    private void tbxRokadDate_TextChanged(object sender, EventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxRokadDate.Text.Trim().ToString()))
      {
        if (PawnManagementClass.checkIfRokadFinishedOrNot(this.tbxRokadDate.Text.Trim().ToString()))
          this.getcashBook(this.tbxRokadDate.Text.Trim().ToString());
        else
          this.dataGridView1.DataSource = (object) null;
      }
      else
        this.dataGridView1.DataSource = (object) null;
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
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.dataGridView1 = new DataGridView();
      this.comboBox1 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxOpeningBalance = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.tbxJamma = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.tbxRokadDate = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.tbxNovae = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxCashInHand = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(160, 48);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(159, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(159, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(8, 66);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(995, 483);
      this.dataGridView1.TabIndex = 24;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 4);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(417, 23);
      this.comboBox1.TabIndex = 58;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(426, 4);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(75, 23);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "PRINT";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click_1);
      ((Control) this.headerPanel4).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.ControlDark;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = SystemColors.Control;
      this.headerPanel4.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "OPENING BALANCE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxOpeningBalance);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(9, 5);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(237, 55);
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
      ((Control) this.glassButton6).Location = new Point(-58, 513);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(128, 35);
      ((Control) this.glassButton6).TabIndex = 0;
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
      ((Control) this.glassButton7).Location = new Point(76, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxOpeningBalance.BackColor = SystemColors.ButtonHighlight;
      this.tbxOpeningBalance.BorderStyle = BorderStyle.None;
      this.tbxOpeningBalance.Dock = DockStyle.Fill;
      this.tbxOpeningBalance.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOpeningBalance.Location = new Point(0, 0);
      this.tbxOpeningBalance.Name = "tbxOpeningBalance";
      this.tbxOpeningBalance.Size = new Size(235, 31);
      this.tbxOpeningBalance.TabIndex = 25;
      this.tbxOpeningBalance.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.ControlDark;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = SystemColors.Control;
      this.headerPanel1.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "JAMMA";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxJamma);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(525, 559);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(237, 55);
      ((Control) this.headerPanel1).TabIndex = 77;
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
      ((Control) this.glassButton2).Location = new Point(-60, 513);
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
      ((Control) this.glassButton3).Location = new Point(74, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxJamma.BackColor = SystemColors.ButtonHighlight;
      this.tbxJamma.BorderStyle = BorderStyle.None;
      this.tbxJamma.Dock = DockStyle.Fill;
      this.tbxJamma.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxJamma.Location = new Point(0, 0);
      this.tbxJamma.Name = "tbxJamma";
      this.tbxJamma.Size = new Size(235, 31);
      this.tbxJamma.TabIndex = 25;
      this.tbxJamma.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel2).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.ControlDark;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = SystemColors.Control;
      this.headerPanel2.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "                    ROKAD DATE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxRokadDate);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(366, 5);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(237, 55);
      ((Control) this.headerPanel2).TabIndex = 78;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton4).Location = new Point(-62, 513);
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
      ((Control) this.glassButton5).Location = new Point(72, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxRokadDate.BackColor = SystemColors.ButtonHighlight;
      this.tbxRokadDate.BorderStyle = BorderStyle.None;
      this.tbxRokadDate.Dock = DockStyle.Fill;
      this.tbxRokadDate.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRokadDate.Location = new Point(0, 0);
      this.tbxRokadDate.Name = "tbxRokadDate";
      this.tbxRokadDate.Size = new Size(235, 31);
      this.tbxRokadDate.TabIndex = 25;
      this.tbxRokadDate.TextAlign = HorizontalAlignment.Center;
      this.tbxRokadDate.TextChanged += new EventHandler(this.tbxRokadDate_TextChanged);
      this.tbxRokadDate.Validating += new CancelEventHandler(this.tbxRokadDate_Validating);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.ControlDark;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = SystemColors.Control;
      this.headerPanel3.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "NOVAE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxNovae);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(768, 559);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(237, 55);
      ((Control) this.headerPanel3).TabIndex = 79;
      this.headerPanel3.TextAntialias = true;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      ((ButtonBase) this.glassButton8).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(-64, 513);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(128, 35);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&SAVE";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(70, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNovae.BackColor = SystemColors.ButtonHighlight;
      this.tbxNovae.BorderStyle = BorderStyle.None;
      this.tbxNovae.Dock = DockStyle.Fill;
      this.tbxNovae.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNovae.Location = new Point(0, 0);
      this.tbxNovae.Name = "tbxNovae";
      this.tbxNovae.Size = new Size(235, 31);
      this.tbxNovae.TabIndex = 25;
      this.tbxNovae.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel5).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.ControlDark;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = SystemColors.Control;
      this.headerPanel5.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "CASH IN HAND";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxCashInHand);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(765, 5);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(237, 55);
      ((Control) this.headerPanel5).TabIndex = 80;
      this.headerPanel5.TextAntialias = true;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      ((ButtonBase) this.glassButton10).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(-66, 513);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(128, 35);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&SAVE";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton11.BackColor = Color.LightBlue;
      this.glassButton11.FadeOnFocus = true;
      ((Control) this.glassButton11).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton11.ForeColor = Color.MediumBlue;
      this.glassButton11.ForeColorOnFocus = Color.Red;
      this.glassButton11.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton11.GlowColor = Color.White;
      this.glassButton11.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton11).Location = new Point(68, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxCashInHand.BackColor = SystemColors.ButtonHighlight;
      this.tbxCashInHand.BorderStyle = BorderStyle.None;
      this.tbxCashInHand.Dock = DockStyle.Fill;
      this.tbxCashInHand.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCashInHand.Location = new Point(0, 0);
      this.tbxCashInHand.Name = "tbxCashInHand";
      this.tbxCashInHand.Size = new Size(235, 31);
      this.tbxCashInHand.TabIndex = 25;
      this.tbxCashInHand.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel6).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.ControlDark;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = SystemColors.Control;
      this.headerPanel6.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "PRINT";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel6).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(12, 559);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(507, 55);
      ((Control) this.headerPanel6).TabIndex = 78;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      ((ButtonBase) this.glassButton12).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(208, 513);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(128, 35);
      ((Control) this.glassButton12).TabIndex = 0;
      ((Control) this.glassButton12).Text = "&SAVE";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(342, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormCashBook);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormCashBook);
      this.Load += new EventHandler(this.FormCashBook_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
