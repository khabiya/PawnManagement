
using CrystalDecisions.Shared;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormNumberOfPledgeBills : Form
  {
    private DataTable dt = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView2;
    private DataGridView dataGridView3;
    private ComboBox cbYearly1;
    private ComboBox cbMonthly;
    private ComboBox cbYearly2;
    private DataGridView dataGridView4;
    private DataGridView dataGridView1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel4;
    private Panel panel2;
    private Panel panel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private HeaderPanel headerPanel2;
    private GlassButton btnSave;
    private GlassButton btnExit;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private ComboBox cbShopCodes;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormNumberOfPledgeBills() => this.InitializeComponent();

    private void refreshGrid1()
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2;
      if (this.cbShopCodes.Text != "")
        dataTable2 = SQLHelper.GetDataTable("(SELECT tp.ybd, sum(numberofbills) as BillCount FROM ((select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p where shopCode = @ShopCode  group by billdate) AS tp ) GROUP BY tp.ybd)", new List<OleDbParameter>()
        {
          new OleDbParameter("shopCode", (object) this.cbShopCodes.Text)
        }, ref strError);
      else
        dataTable2 = SQLHelper.GetDataTable("(SELECT tp.ybd, sum(numberofbills) as BillCount FROM ((select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p  group by billdate) AS tp) GROUP BY tp.ybd)", ref strError);
      this.dataGridView1.DataSource = (object) dataTable2;
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      if (this.dataGridView1.ColumnCount <= 0)
        return;
      this.dataGridView1.Columns[0].HeaderText = "YEAR";
    }

    private void refreshGrid2(string YBD)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable2;
      if (YBD == "")
      {
        if (this.cbShopCodes.Text == "")
        {
          dataTable2 = SQLHelper.GetDataTable("SELECT tp.ybd, tp.mbd,sum(numberofbills) as BillCount FROM (select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p  group by billdate)  AS tp GROUP BY tp.ybd, tp.mbd", ref strError);
        }
        else
        {
          string my_querry = "SELECT tp.ybd, tp.mbd,sum(numberofbills) as BillCount FROM (select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p  where shopCode = @ShopCode group by billdate)  AS tp GROUP BY tp.ybd, tp.mbd";
          parameters.Add(new OleDbParameter("shopCode", (object) this.cbShopCodes.Text.Trim()));
          dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
      }
      else if (this.cbShopCodes.Text == "")
      {
        string my_querry = "select * from (SELECT tp.ybd, tp.mbd,sum(numberofbills) as BillCount FROM (select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p group by billdate)  AS tp  GROUP BY tp.ybd, tp.mbd) where ybd = @YBD ";
        parameters.Add(new OleDbParameter(nameof (YBD), (object) this.cbYearly1.Text.Trim()));
        dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      }
      else
      {
        string my_querry = "select * from (SELECT tp.ybd, tp.mbd,sum(numberofbills) as BillCount FROM (select  billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p where shopCode = @ShopCode group by billdate)  AS tp  GROUP BY tp.ybd, tp.mbd) where ybd = @YBD ";
        parameters.Add(new OleDbParameter("shopCode", (object) this.cbShopCodes.Text.Trim()));
        parameters.Add(new OleDbParameter(nameof (YBD), (object) this.cbYearly1.Text.Trim()));
        dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      }
      this.dataGridView2.DataSource = (object) dataTable2;
      this.dataGridView2.Columns["ybd"].HeaderText = "YEAR";
      this.dataGridView2.Columns["mbd"].HeaderText = "MONTH";
      if (!(strError != ""))
        return;
      int num = (int) MessageBox.Show(strError);
    }

    private void refreshGrid3(string MBD, string YBD)
    {
      string strError = "";
      DataTable dataTable = new DataTable();
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (MBD == "" && YBD == "")
      {
        if (this.cbShopCodes.Text == "")
        {
          dataTable = SQLHelper.GetDataTable("select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p group by billdate order by billdate", ref strError);
        }
        else
        {
          string my_querry = "select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p  where shopcode  = @ShopCode group by billdate order by billdate";
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim()));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
      }
      else if (MBD != "" && YBD != "")
      {
        if (this.cbShopCodes.Text == "")
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p group by billdate) where mbd = @mbd and ybd = @ybd";
          parameters.Add(new OleDbParameter("mbd", (object) MBD));
          parameters.Add(new OleDbParameter("ybd", (object) YBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
        else
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p where shopCode = @shopCode group by billdate) where mbd = @mbd and ybd = @ybd";
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim()));
          parameters.Add(new OleDbParameter("mbd", (object) MBD));
          parameters.Add(new OleDbParameter("ybd", (object) YBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
      }
      else if (MBD != "" && YBD == "")
      {
        if (this.cbShopCodes.Text == "")
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p group by billdate) where mbd = @mbd";
          parameters.Add(new OleDbParameter("mbd", (object) MBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
        else
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p where shopCode = @shopCode group by billdate) where mbd = @mbd";
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim()));
          parameters.Add(new OleDbParameter("mbd", (object) MBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
      }
      else if (MBD == "" && YBD != "")
      {
        if (this.cbShopCodes.Text == "")
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p group by billdate) where  ybd = @ybd";
          parameters.Add(new OleDbParameter("ybd", (object) YBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
        else
        {
          string my_querry = " select * from (select billdate,count(*) as numberOfBills ,month(billdate) as mbd,year(billdate) as ybd from  tblpledge p where shopCode = @shopCode group by billdate) where ybd = @ybd";
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim()));
          parameters.Add(new OleDbParameter("ybd", (object) YBD));
          dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        }
      }
      this.dataGridView3.DataSource = (object) dataTable;
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      this.dataGridView3.Columns[2].Visible = false;
      this.dataGridView3.Columns[3].Visible = false;
    }

    private void loadcbYear()
    {
      string strError = "";
      string my_querry = "select distinct(year(billdate))  as distinctyears from tblpledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          this.cbYearly1.Items.Add((object) row["distinctyears"].ToString());
          this.cbYearly2.Items.Add((object) row["distinctyears"].ToString());
        }
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void FormNumberOfBills_Load(object sender, EventArgs e)
    {
      try
      {
        this.getShopCodes();
        PawnManagementClass.formatDataGridViewBrownPledge(ref this.dataGridView1);
        PawnManagementClass.formatDataGridViewBrownPledge(ref this.dataGridView2);
        PawnManagementClass.formatDataGridViewBrownPledge(ref this.dataGridView3);
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.loadcbYear();
        this.refreshGrid1();
        this.refreshGrid2("");
        this.refreshGrid3("", "");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form numberofpledgebills.formnumberofbills_load", ex.StackTrace + ex.Message, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbMonthly_SelectedIndexChanged(object sender, EventArgs e) => this.refreshGrid3(this.cbMonthly.Text.ToString(), this.cbYearly2.Text.Trim().ToString());

    private void cbYearly1_SelectedIndexChanged(object sender, EventArgs e) => this.refreshGrid2(this.cbYearly1.Text.Trim());

    private void glassButton1_Click(object sender, EventArgs e)
    {
      this.getDatatabledt();
      this.getdatatabledtdata(this.dataGridView1);
      new FormCrystalReportViewer("Reports\\ReportsNumberOfPledgeBills.rpt", this.dt, PaperSize.PaperA4, PaperOrientation.Portrait).Show();
    }

    private void getDatatabledt()
    {
      this.dt.Columns.Add("billdate", typeof (DateTime));
      this.dt.Columns.Add("numberofBills", typeof (string));
    }

    private void getdatatabledtdata(DataGridView dataGridView)
    {
      this.dt.Clear();
      foreach (DataGridViewRow row in (IEnumerable) dataGridView.Rows)
        this.dt.Rows.Add((object) DateTime.Parse(row.Cells["billdate"].Value.ToString()), (object) row.Cells["numberofBills"].Value.ToString());
      this.dt.TableName = "NumberOfBills";
      this.dt.WriteXmlSchema("NumberofBills.xml");
    }

    private void panel4_Paint(object sender, PaintEventArgs e)
    {
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      this.getDatatabledt();
      this.getdatatabledtdata(this.dataGridView2);
      new FormCrystalReportViewer("Reports\\ReportsNumberOfPledgeBills.rpt", this.dt, PaperSize.PaperA4, PaperOrientation.Portrait).Show();
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      this.getDatatabledt();
      this.getdatatabledtdata(this.dataGridView3);
      new FormCrystalReportViewer("Reports\\ReportsNumberOfPledgeBills.rpt", this.dt, PaperSize.PaperA4, PaperOrientation.Portrait).Show();
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

    private void cbShopCodes_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      this.refreshGrid1();
      this.refreshGrid2(this.cbYearly1.Text.Trim());
      this.refreshGrid3(this.cbMonthly.Text.ToString(), this.cbYearly2.Text.Trim().ToString());
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
      this.dataGridView2 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.dataGridView3 = new DataGridView();
      this.cbYearly1 = new ComboBox();
      this.cbMonthly = new ComboBox();
      this.cbYearly2 = new ComboBox();
      this.dataGridView1 = new DataGridView();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel4 = new Panel();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.panel2 = new Panel();
      this.headerPanel2 = new HeaderPanel();
      this.btnSave = new GlassButton();
      this.btnExit = new GlassButton();
      this.panel1 = new Panel();
      this.headerPanel4 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView3).BeginInit();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel4.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.Location = new Point(287, 69);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.Size = new Size(343, 560);
      this.dataGridView2.TabIndex = 1;
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
      this.dataGridView3.AllowUserToAddRows = false;
      this.dataGridView3.AllowUserToDeleteRows = false;
      this.dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView3.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView3.Dock = DockStyle.Fill;
      this.dataGridView3.Location = new Point(636, 69);
      this.dataGridView3.Name = "dataGridView3";
      this.dataGridView3.ReadOnly = true;
      this.dataGridView3.Size = new Size(369, 560);
      this.dataGridView3.TabIndex = 2;
      this.cbYearly1.BackColor = Color.Ivory;
      this.cbYearly1.Dock = DockStyle.Fill;
      this.cbYearly1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbYearly1.FormattingEnabled = true;
      this.cbYearly1.Location = new Point(0, 0);
      this.cbYearly1.Name = "cbYearly1";
      this.cbYearly1.Size = new Size(341, 32);
      this.cbYearly1.TabIndex = 0;
      this.cbYearly1.SelectedIndexChanged += new EventHandler(this.cbYearly1_SelectedIndexChanged);
      this.cbYearly1.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbYearly1.KeyPress += new KeyPressEventHandler(this.cbShopCodes_KeyPress);
      this.cbMonthly.BackColor = Color.Ivory;
      this.cbMonthly.Dock = DockStyle.Fill;
      this.cbMonthly.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMonthly.FormattingEnabled = true;
      this.cbMonthly.Items.AddRange(new object[12]
      {
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12"
      });
      this.cbMonthly.Location = new Point(0, 0);
      this.cbMonthly.Name = "cbMonthly";
      this.cbMonthly.Size = new Size(178, 32);
      this.cbMonthly.TabIndex = 0;
      this.cbMonthly.SelectedIndexChanged += new EventHandler(this.cbMonthly_SelectedIndexChanged);
      this.cbMonthly.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbMonthly.KeyPress += new KeyPressEventHandler(this.cbShopCodes_KeyPress);
      this.cbYearly2.BackColor = Color.Ivory;
      this.cbYearly2.Dock = DockStyle.Fill;
      this.cbYearly2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbYearly2.FormattingEnabled = true;
      this.cbYearly2.Location = new Point(0, 0);
      this.cbYearly2.Name = "cbYearly2";
      this.cbYearly2.Size = new Size(170, 32);
      this.cbYearly2.TabIndex = 1;
      this.cbYearly2.SelectedIndexChanged += new EventHandler(this.cbMonthly_SelectedIndexChanged);
      this.cbYearly2.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbYearly2.KeyPress += new KeyPressEventHandler(this.cbShopCodes_KeyPress);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 69);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new Size(278, 560);
      this.dataGridView1.TabIndex = 12;
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.24579f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.68781f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.06641f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel4, 2, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView3, 2, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView2, 1, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 66f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 13;
      this.panel4.Controls.Add((Control) this.headerPanel3);
      this.panel4.Controls.Add((Control) this.headerPanel1);
      this.panel4.Dock = DockStyle.Fill;
      this.panel4.Location = new Point(636, 3);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(369, 60);
      this.panel4.TabIndex = 15;
      this.panel4.Paint += new PaintEventHandler(this.panel4_Paint);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel3.CaptionEndColor = Color.PeachPuff;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "SELECT YEAR";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel3).Controls.Add((Control) this.cbYearly2);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Ivory;
      this.headerPanel3.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel3).Location = new Point(192, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(172, 53);
      ((Control) this.headerPanel3).TabIndex = 71;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-117, 513);
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
      ((Control) this.glassButton4).Location = new Point(17, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel1.CaptionEndColor = Color.PeachPuff;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "SELECT MONTH";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbMonthly);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Ivory;
      this.headerPanel1.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel1).Location = new Point(7, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(180, 53);
      ((Control) this.headerPanel1).TabIndex = 70;
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
      ((Control) this.glassButton1).Location = new Point(-109, 513);
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
      ((Control) this.glassButton2).Location = new Point(25, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(287, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(343, 60);
      this.panel2.TabIndex = 0;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel2.CaptionEndColor = Color.PeachPuff;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "SELECT YEAR";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnSave);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbYearly1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnExit);
      ((Control) this.headerPanel2).Dock = DockStyle.Fill;
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Ivory;
      this.headerPanel2.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel2).Location = new Point(0, 0);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(343, 60);
      ((Control) this.headerPanel2).TabIndex = 70;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.btnSave).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSave.GlowColor = Color.White;
      ((ButtonBase) this.btnSave).ImageAlign = ContentAlignment.TopLeft;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(54, 513);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(128, 35);
      ((Control) this.btnSave).TabIndex = 0;
      ((Control) this.btnSave).Text = "&SAVE";
      ((ButtonBase) this.btnSave).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnExit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExit.BackColor = Color.LightBlue;
      this.btnExit.FadeOnFocus = true;
      ((Control) this.btnExit).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnExit.ForeColor = Color.MediumBlue;
      this.btnExit.ForeColorOnFocus = Color.Red;
      this.btnExit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnExit.GlowColor = Color.White;
      this.btnExit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnExit).Location = new Point(188, 512);
      ((Control) this.btnExit).Name = "btnExit";
      this.btnExit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnExit.ShineColor = Color.Transparent;
      ((Control) this.btnExit).Size = new Size(123, 37);
      ((Control) this.btnExit).TabIndex = 1;
      ((Control) this.btnExit).Text = "&EXIT";
      ((ButtonBase) this.btnExit).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.panel1.Controls.Add((Control) this.headerPanel4);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(278, 60);
      this.panel1.TabIndex = 14;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel4.CaptionEndColor = Color.PeachPuff;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "SELECT LICENSE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Dock = DockStyle.Fill;
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.GradientEnd = Color.Ivory;
      this.headerPanel4.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel4).Location = new Point(0, 0);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(278, 60);
      ((Control) this.headerPanel4).TabIndex = 70;
      this.headerPanel4.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.Ivory;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(7, 6);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(263, 23);
      this.cbShopCodes.TabIndex = 25;
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbShopCodes.KeyPress += new KeyPressEventHandler(this.cbShopCodes_KeyPress);
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
      ((Control) this.glassButton5).Location = new Point(-11, 513);
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
      ((Control) this.glassButton6).Location = new Point(123, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Ivory;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormNumberOfPledgeBills);
      this.Text = "NumberOfBills - Pledge";
      this.Load += new EventHandler(this.FormNumberOfBills_Load);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView3).EndInit();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
