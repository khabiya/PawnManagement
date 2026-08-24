

using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormDayReport : Form
  {
    private string BillDate = "";
    private string formType = "";
    private string FromBillDate = "";
    private string ToBillDate = "";
    private DataTable dt1 = new DataTable();
    private DataTable dtRedemptionReort = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private DataGridView dataGridView3;
    private DataGridView dataGridView4;
    private TextBox tbxAmount;
    private TextBox tbxInterest;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxInterestRedemption;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private TextBox tbxAmountRedemption;
    private ComboBox comboBox1;
    private GlassButton btnPrint;
    private TextBox tbxToDate;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ComboBox cbShopCodes;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private Panel panel1;
    private Label label3;
    private Panel panel5;
    private Label label2;
    private Panel panel6;
    private Label label1;
    private Panel panel2;
    private Label label4;
    private TextBox tbxFromDate;
    private Panel panel3;
    private ComboBox cbType;
    private Label label5;
    private SplitContainer splitContainer1;
    private GlassButton btnRefresh;
    private DataGridView dataGridView2;

    public FormDayReport(string BILLDATE)
    {
      this.BillDate = BILLDATE;
      this.InitializeComponent();
    }

    public FormDayReport(string FromDate, string ToDate)
    {
      this.FromBillDate = FromDate;
      this.ToBillDate = ToDate;
      this.InitializeComponent();
    }

    public FormDayReport() => this.InitializeComponent();

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormDayReport_Load(object sender, EventArgs e)
    {
      this.tbxFromDate.Text = this.BillDate;
      this.tbxToDate.Text = this.BillDate;
      this.getDataGridViews("SINGLE", this.cbType.Text);
      this.getShopCodes();
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      string[] source = File.ReadAllLines("Reports\\DayReport\\LastUsed.txt");
      if (((IEnumerable<string>) source).Count<string>() > 0)
        this.comboBox1.Text = source[0].ToString();
      this.cbShopCodes.Select();
    }

    private void pledgeReportTotal(string fromBillDate, string toBillDate)
    {
      DataTable dataTable = PawnManagement.Classes.PawnManagementClasses.PledgeClass.pledgeReportTotal(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text, this.cbType.Text);
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          num1 += double.Parse(row["Total"].ToString());
          num2 += double.Parse(row["Interest"].ToString());
        }
        this.tbxAmount.Text = num1.ToString("F");
        this.tbxInterest.Text = num2.ToString("F");
      }
      this.dataGridView3.DataSource = (object) dataTable;
      if (this.dataGridView3.Columns.Count > 2)
      {
        this.dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      }
      this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void RedemptionReportTodal(string ShopCode, string FromDate, string ToDate)
    {
      double num1 = 0.0;
      double num2 = 0.0;
      DataTable dataTable = RedemptionClass.redemptionreportTotal(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text, this.cbType.Text);
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          num1 += double.Parse(row["Amount"].ToString());
          num2 += double.Parse(row["FinalInterest"].ToString());
        }
      }
      this.dataGridView4.DataSource = (object) dataTable;
      this.tbxAmountRedemption.Text = num1.ToString("F");
      this.tbxInterestRedemption.Text = num2.ToString("F");
    }

    private int GetDataGridViewHeight(DataGridView dataGridView) => (dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0) + dataGridView.Rows.OfType<DataGridViewRow>().Where<DataGridViewRow>((System.Func<DataGridViewRow, bool>) (r => r.Visible)).Sum<DataGridViewRow>((System.Func<DataGridViewRow, int>) (r => r.Height));

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.ColumnIndex == 3)
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
      if (this.dataGridView1.CurrentCell.ColumnIndex == 5)
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["CustomerCode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell.ColumnIndex != 3)
        return;
      double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
      string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "")
        new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
    }

    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView2.Rows.Count <= 0)
        return;
      if (this.dataGridView2.CurrentCell.ColumnIndex == 1)
      {
        double num = (double) (this.dataGridView2.Location.Y + this.dataGridView2.Size.Width);
        string REDEMPTIONBILLNUMBER = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (REDEMPTIONBILLNUMBER != "")
          new FormViewRedemptionBillNew(REDEMPTIONBILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
      if (this.dataGridView2.CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
    }

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void glassButton7_Click(object sender, EventArgs e)
    {
      if (!(this.comboBox1.Text != ""))
        return;
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text);
      RD.Subreports[0].SetDataSource(this.dt1);
      RD.Subreports[1].SetDataSource(this.dtRedemptionReort);
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\DayReport\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\DayReport\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void tbxFromDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
        this.tbxToDate.Select();
      else
        this.tbxFromDate.Select();
    }

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        ((Control) this.btnPrint).Focus();
      else
        this.tbxToDate.Select();
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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "PLEDGE REPORTS").ShowDialog();
    }

    private void btnRefresh_Click(object sender, EventArgs e) => this.show();

    private void show()
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == "") || !PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        return;
      if (DateTime.Parse(this.tbxFromDate.Text) == DateTime.Parse(this.tbxToDate.Text))
        this.getDataGridViews("SINGLE", this.cbType.Text);
      else if (DateTime.Parse(this.tbxFromDate.Text) < DateTime.Parse(this.tbxToDate.Text))
        this.getDataGridViews("DOUBLE", this.cbType.Text);
    }

    private void getDataGridViews(string formType, string type)
    {
      switch (formType)
      {
        case "SINGLE":
          this.dataGridView1.DataSource = (object) (this.dt1 = PawnManagement.Classes.PawnManagementClasses.PledgeClass.getPledgeReport(this.cbShopCodes.Text, this.tbxFromDate.Text, this.cbType.Text));
          this.dataGridView2.DataSource = (object) (this.dtRedemptionReort = RedemptionClass.redemptionReport(this.cbShopCodes.Text, this.tbxFromDate.Text, this.cbType.Text));
          this.pledgeReportTotal(this.tbxFromDate.Text, this.tbxToDate.Text);
          this.RedemptionReportTodal(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text);
          break;
        case "DOUBLE":
          this.dataGridView1.DataSource = (object) (this.dt1 = PawnManagement.Classes.PawnManagementClasses.PledgeClass.pledgeReport(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text, this.cbType.Text));
          this.dataGridView2.DataSource = (object) (this.dtRedemptionReort = RedemptionClass.redemptionReport(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text, this.cbType.Text));
          this.pledgeReportTotal(this.tbxFromDate.Text, this.tbxToDate.Text);
          this.RedemptionReportTodal(this.cbShopCodes.Text, this.tbxFromDate.Text, this.tbxToDate.Text);
          break;
        default:
          this.dataGridView1.DataSource = (object) null;
          this.dataGridView2.DataSource = (object) null;
          break;
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
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.dataGridView3 = new DataGridView();
      this.dataGridView4 = new DataGridView();
      this.tbxAmount = new TextBox();
      this.tbxInterest = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxInterestRedemption = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxAmountRedemption = new TextBox();
      this.comboBox1 = new ComboBox();
      this.btnPrint = new GlassButton();
      this.panel6 = new Panel();
      this.label1 = new Label();
      this.tbxFromDate = new TextBox();
      this.tbxToDate = new TextBox();
      this.cbShopCodes = new ComboBox();
      this.panel1 = new Panel();
      this.label3 = new Label();
      this.panel5 = new Panel();
      this.label2 = new Label();
      this.panel2 = new Panel();
      this.label4 = new Label();
      this.panel3 = new Panel();
      this.cbType = new ComboBox();
      this.label5 = new Label();
      this.splitContainer1 = new SplitContainer();
      this.btnRefresh = new GlassButton();
      this.dataGridView2 = new DataGridView();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView3).BeginInit();
      ((ISupportInitialize) this.dataGridView4).BeginInit();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Cursor = Cursors.Default;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.AliceBlue;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(395, 371);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 92);
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
      this.viewFullScreenToolStripMenuItem.Text = "View full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.dataGridView3.AllowUserToAddRows = false;
      this.dataGridView3.AllowUserToDeleteRows = false;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dataGridView3.ColumnHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView3.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = Color.AliceBlue;
      gridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = SystemColors.ControlText;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.False;
      this.dataGridView3.DefaultCellStyle = gridViewCellStyle4;
      this.dataGridView3.Dock = DockStyle.Bottom;
      this.dataGridView3.Location = new Point(0, 371);
      this.dataGridView3.Name = "dataGridView3";
      this.dataGridView3.ReadOnly = true;
      this.dataGridView3.RowHeadersVisible = false;
      this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView3.Size = new Size(395, 141);
      this.dataGridView3.TabIndex = 0;
      this.dataGridView4.AllowUserToAddRows = false;
      this.dataGridView4.AllowUserToDeleteRows = false;
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle5.BackColor = SystemColors.Control;
      gridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = SystemColors.WindowText;
      gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle5.WrapMode = DataGridViewTriState.True;
      this.dataGridView4.ColumnHeadersDefaultCellStyle = gridViewCellStyle5;
      this.dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView4.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle6.BackColor = Color.AliceBlue;
      gridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = SystemColors.ControlText;
      gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle6.WrapMode = DataGridViewTriState.False;
      this.dataGridView4.DefaultCellStyle = gridViewCellStyle6;
      this.dataGridView4.Dock = DockStyle.Bottom;
      this.dataGridView4.Location = new Point(0, 371);
      this.dataGridView4.Name = "dataGridView4";
      this.dataGridView4.ReadOnly = true;
      this.dataGridView4.RowHeadersVisible = false;
      this.dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView4.Size = new Size(579, 141);
      this.dataGridView4.TabIndex = 1;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Dock = DockStyle.Fill;
      this.tbxAmount.Font = new Font("Segoe UI Symbol", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = Color.Navy;
      this.tbxAmount.Location = new Point(0, 0);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(175, 32);
      this.tbxAmount.TabIndex = 4;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      this.tbxInterest.BackColor = Color.AliceBlue;
      this.tbxInterest.BorderStyle = BorderStyle.None;
      this.tbxInterest.Dock = DockStyle.Fill;
      this.tbxInterest.Font = new Font("Segoe UI Symbol", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.ForeColor = Color.Navy;
      this.tbxInterest.Location = new Point(0, 0);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(174, 32);
      this.tbxInterest.TabIndex = 5;
      this.tbxInterest.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
      this.headerPanel7.CaptionText = "AMOUNT TOTAL";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(14, 560);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(177, 58);
      ((Control) this.headerPanel7).TabIndex = 94;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton8).Location = new Point(-138, 513);
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
      ((Control) this.glassButton9).Location = new Point(-4, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
      this.headerPanel1.CaptionText = "INTEREST TOTAL";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxInterest);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(198, 560);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(176, 58);
      ((Control) this.headerPanel1).TabIndex = 95;
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
      ((Control) this.glassButton1).Location = new Point(-141, 513);
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
      ((Control) this.glassButton2).Location = new Point(-7, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel2.CaptionText = "INTEREST TOTAL";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxInterestRedemption);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(817, 560);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(176, 58);
      ((Control) this.headerPanel2).TabIndex = 97;
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
      ((Control) this.glassButton3).Location = new Point(-143, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
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
      ((Control) this.glassButton4).Location = new Point(-9, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxInterestRedemption.BackColor = Color.AliceBlue;
      this.tbxInterestRedemption.BorderStyle = BorderStyle.None;
      this.tbxInterestRedemption.Dock = DockStyle.Fill;
      this.tbxInterestRedemption.Font = new Font("Segoe UI Symbol", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRedemption.ForeColor = Color.Navy;
      this.tbxInterestRedemption.Location = new Point(0, 0);
      this.tbxInterestRedemption.Name = "tbxInterestRedemption";
      this.tbxInterestRedemption.Size = new Size(174, 32);
      this.tbxInterestRedemption.TabIndex = 5;
      this.tbxInterestRedemption.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel3.CaptionText = "AMOUNT TOTAL";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxAmountRedemption);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(633, 560);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(177, 58);
      ((Control) this.headerPanel3).TabIndex = 96;
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
      ((Control) this.glassButton5).Location = new Point(-140, 513);
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
      ((Control) this.glassButton6).Location = new Point(-6, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAmountRedemption.BackColor = Color.AliceBlue;
      this.tbxAmountRedemption.BorderStyle = BorderStyle.None;
      this.tbxAmountRedemption.Dock = DockStyle.Fill;
      this.tbxAmountRedemption.Font = new Font("Segoe UI Symbol", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountRedemption.ForeColor = Color.Navy;
      this.tbxAmountRedemption.Location = new Point(0, 0);
      this.tbxAmountRedemption.Name = "tbxAmountRedemption";
      this.tbxAmountRedemption.Size = new Size(175, 32);
      this.tbxAmountRedemption.TabIndex = 4;
      this.tbxAmountRedemption.TextAlign = HorizontalAlignment.Center;
      this.comboBox1.BackColor = Color.MintCream;
      this.comboBox1.Dock = DockStyle.Bottom;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(0, 35);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(246, 21);
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
      ((Control) this.btnPrint).Location = new Point(182, 3);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(61, 26);
      ((Control) this.btnPrint).TabIndex = 24;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((ButtonBase) this.btnPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrint).Click += new EventHandler(this.glassButton7_Click);
      this.panel6.BackColor = Color.PowderBlue;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.label1);
      this.panel6.Controls.Add((Control) this.tbxFromDate);
      this.panel6.Location = new Point(309, 9);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(216, 27);
      this.panel6.TabIndex = 113;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(3, 5);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "FROM DATE";
      this.tbxFromDate.BackColor = Color.MintCream;
      this.tbxFromDate.BorderStyle = BorderStyle.None;
      this.tbxFromDate.Dock = DockStyle.Right;
      this.tbxFromDate.Font = new Font("Segoe UI Symbol", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.ForeColor = Color.RoyalBlue;
      this.tbxFromDate.Location = new Point(105, 0);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(109, 26);
      this.tbxFromDate.TabIndex = 104;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxFromDate_KeyDown);
      this.tbxToDate.BackColor = Color.MintCream;
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Right;
      this.tbxToDate.Font = new Font("Segoe UI Symbol", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.ForeColor = Color.RoyalBlue;
      this.tbxToDate.Location = new Point(81, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(107, 26);
      this.tbxToDate.TabIndex = 105;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.MintCream;
      this.cbShopCodes.Dock = DockStyle.Right;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Items.AddRange(new object[1]
      {
        (object) ""
      });
      this.cbShopCodes.Location = new Point(138, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(156, 24);
      this.cbShopCodes.TabIndex = 24;
      this.panel1.BackColor = Color.PowderBlue;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.tbxToDate);
      this.panel1.Location = new Point(531, 9);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(190, 27);
      this.panel1.TabIndex = 115;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(3, 5);
      this.label3.Name = "label3";
      this.label3.Size = new Size(74, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "TO DATE";
      this.panel5.BackColor = Color.PowderBlue;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.cbShopCodes);
      this.panel5.Controls.Add((Control) this.label2);
      this.panel5.Location = new Point(12, 9);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(296, 27);
      this.panel5.TabIndex = 114;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new Size(133, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "SELECT LICENSE";
      this.panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BackColor = Color.PowderBlue;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.comboBox1);
      this.panel2.Controls.Add((Control) this.btnPrint);
      this.panel2.Location = new Point(379, 560);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(248, 58);
      this.panel2.TabIndex = 116;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(3, 5);
      this.label4.Name = "label4";
      this.label4.Size = new Size(54, 16);
      this.label4.TabIndex = 1;
      this.label4.Text = "PRINT";
      this.panel3.BackColor = Color.PowderBlue;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.cbType);
      this.panel3.Controls.Add((Control) this.label5);
      this.panel3.Location = new Point(726, 10);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(158, 27);
      this.panel3.TabIndex = 117;
      this.cbType.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbType.BackColor = Color.MintCream;
      this.cbType.Dock = DockStyle.Right;
      this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbType.DropDownWidth = 600;
      this.cbType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[2]
      {
        (object) "1",
        (object) "2"
      });
      this.cbType.Location = new Point(61, 0);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(95, 24);
      this.cbType.TabIndex = 24;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(3, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(48, 16);
      this.label5.TabIndex = 1;
      this.label5.Text = "TYPE";
      this.splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.splitContainer1.Location = new Point(14, 42);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.dataGridView1);
      this.splitContainer1.Panel1.Controls.Add((Control) this.dataGridView3);
      this.splitContainer1.Panel2.Controls.Add((Control) this.dataGridView2);
      this.splitContainer1.Panel2.Controls.Add((Control) this.dataGridView4);
      this.splitContainer1.Size = new Size(978, 512);
      this.splitContainer1.SplitterDistance = 395;
      this.splitContainer1.TabIndex = 118;
      this.btnRefresh.BackColor = Color.LightBlue;
      this.btnRefresh.FadeOnFocus = true;
      ((Control) this.btnRefresh).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRefresh.ForeColor = Color.MediumBlue;
      this.btnRefresh.ForeColorOnFocus = Color.Red;
      this.btnRefresh.ForeColorOnLeave = Color.RoyalBlue;
      this.btnRefresh.GlowColor = Color.White;
      this.btnRefresh.InnerBorderColor = Color.Transparent;
      ((Control) this.btnRefresh).Location = new Point(890, 10);
      ((Control) this.btnRefresh).Name = "btnRefresh";
      this.btnRefresh.OuterBorderColor = Color.MediumSlateBlue;
      this.btnRefresh.ShineColor = Color.Transparent;
      ((Control) this.btnRefresh).Size = new Size(102, 26);
      ((Control) this.btnRefresh).TabIndex = 119;
      ((Control) this.btnRefresh).Text = "&RERESH";
      ((ButtonBase) this.btnRefresh).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnRefresh).Click += new EventHandler(this.btnRefresh_Click);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle7.BackColor = SystemColors.Control;
      gridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = SystemColors.WindowText;
      gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
      this.dataGridView2.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView2.Cursor = Cursors.Default;
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle8.BackColor = Color.AliceBlue;
      gridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = SystemColors.ControlText;
      gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
      this.dataGridView2.DefaultCellStyle = gridViewCellStyle8;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.Location = new Point(0, 0);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.RowHeadersVisible = false;
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(579, 371);
      this.dataGridView2.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Azure;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.btnRefresh);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel6);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel7);
      this.Name = nameof (FormDayReport);
      this.Text = nameof (FormDayReport);
      this.Load += new EventHandler(this.FormDayReport_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView3).EndInit();
      ((ISupportInitialize) this.dataGridView4).EndInit();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.ResumeLayout(false);
    }
  }
}
