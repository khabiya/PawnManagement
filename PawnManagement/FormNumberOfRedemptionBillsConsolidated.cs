

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
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
  public class FormNumberOfRedemptionBillsConsolidated : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\bluelight.jpg");
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel3;
    private Panel panel1;
    private ComboBox cbYear;
    private TextBox textBox1;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;

    public FormNumberOfRedemptionBillsConsolidated() => this.InitializeComponent();

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

    private void FormNumberOfRedemptionBillsConsolidated_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      this.loadcbYear();
    }

    private DataTable billReport(int year)
    {
      string my_querry = !(this.cbShopCodes.Text == "") ? string.Format("select tblDates.BDate, January, February, March, April, May, June, July, August, September, October, November, December from \r\n\r\n                                (((((((((((tblDates left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as January FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=1 and Year([BillDate])={0} order by Day([BillDate])) as tbl1 on tblDates.BDate = tbl1.BDate) \r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as February FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=2 and Year([BillDate])={0} order by Day([BillDate])) as tbl2 on tblDates.BDate = tbl2.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as March FROM tblRedemption {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=3 and Year([BillDate])={0} order by Day([BillDate])) as tbl3 on tblDates.BDate = tbl3.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as April FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=4 and Year([BillDate])={0} order by Day([BillDate])) as tbl4 on tblDates.BDate = tbl4.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as May FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=5 and Year([BillDate])={0} order by Day([BillDate])) as tbl5 on tblDates.BDate = tbl5.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as June FROM tblRedemption {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=6 and Year([BillDate])={0} order by Day([BillDate])) as tbl6 on tblDates.BDate = tbl6.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as July FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=7 and Year([BillDate])={0} order by Day([BillDate])) as tbl7 on tblDates.BDate = tbl7.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as August FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=8 and Year([BillDate])={0} order by Day([BillDate])) as tbl8 on tblDates.BDate = tbl8.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as September FROM tblRedemption {1}  group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=9 and Year([BillDate])={0} order by Day([BillDate])) as tbl9 on tblDates.BDate = tbl9.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as October FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=10 and Year([BillDate])={0} order by Day([BillDate])) as tbl10 on tblDates.BDate = tbl10.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as November FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=11 and Year([BillDate])={0} order by Day([BillDate])) as tbl11 on tblDates.BDate = tbl11.BDate)\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as December FROM tblRedemption  {1} group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=12 and Year([BillDate])={0} order by Day([BillDate])) as tbl12 on tblDates.BDate = tbl12.BDate", (object) year, (object) " where shopcode = @ShopCode ") : string.Format("select tblDates.BDate, January, February, March, April, May, June, July, August, September, October, November, December from \r\n\r\n                                (((((((((((tblDates left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as January FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=1 and Year([BillDate])={0} order by Day([BillDate])) as tbl1 on tblDates.BDate = tbl1.BDate) \r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as February FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=2 and Year([BillDate])={0} order by Day([BillDate])) as tbl2 on tblDates.BDate = tbl2.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as March FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=3 and Year([BillDate])={0} order by Day([BillDate])) as tbl3 on tblDates.BDate = tbl3.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as April FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=4 and Year([BillDate])={0} order by Day([BillDate])) as tbl4 on tblDates.BDate = tbl4.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as May FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=5 and Year([BillDate])={0} order by Day([BillDate])) as tbl5 on tblDates.BDate = tbl5.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as June FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=6 and Year([BillDate])={0} order by Day([BillDate])) as tbl6 on tblDates.BDate = tbl6.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as July FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=7 and Year([BillDate])={0} order by Day([BillDate])) as tbl7 on tblDates.BDate = tbl7.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as August FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=8 and Year([BillDate])={0} order by Day([BillDate])) as tbl8 on tblDates.BDate = tbl8.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as September FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=9 and Year([BillDate])={0} order by Day([BillDate])) as tbl9 on tblDates.BDate = tbl9.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as October FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=10 and Year([BillDate])={0} order by Day([BillDate])) as tbl10 on tblDates.BDate = tbl10.BDate)\r\n\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as November FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=11 and Year([BillDate])={0} order by Day([BillDate])) as tbl11 on tblDates.BDate = tbl11.BDate)\r\n                                left outer join\r\n\r\n                                (SELECT Day([BillDate]) AS BDate, count(*) as December FROM tblRedemption group by Day([BillDate]), Month([BillDate]), Year([BillDate]) having Month([BillDate])=12 and Year([BillDate])={0} order by Day([BillDate])) as tbl12 on tblDates.BDate = tbl12.BDate", (object) year);
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        for (int index = 0; index < 31; ++index)
        {
          for (int columnIndex = 1; columnIndex < 13; ++columnIndex)
          {
            if (dataTable.Rows[index][columnIndex].ToString() == "")
              dataTable.Rows[index][columnIndex] = (object) "0";
          }
        }
        dataTable.Rows.Add();
        int num1 = 0;
        for (int columnIndex = 1; columnIndex < 13; ++columnIndex)
        {
          int num2 = 0;
          for (int index = 0; index < 31; ++index)
            num2 += int.Parse(dataTable.Rows[index][columnIndex].ToString());
          dataTable.Rows[31][columnIndex] = (object) num2;
        }
        for (int columnIndex = 1; columnIndex < 13; ++columnIndex)
          num1 += int.Parse(dataTable.Rows[31][columnIndex].ToString());
        this.textBox1.Text = num1.ToString();
      }
      return dataTable;
    }

    private void loadcbYear()
    {
      string strError = "";
      string my_querry = "select distinct(year(billdate))  as distinctyears from tblRedemption";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbYear.DataSource = (object) dataTable2;
        this.cbYear.DisplayMember = "distinctyears";
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

    private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.IsDigitsOnly(this.cbYear.Text.ToString()))
        return;
      this.dataGridView1.DataSource = (object) this.billReport(int.Parse(this.cbYear.Text.Trim().ToString()));
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
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Number of Redemption Bills consolidated").ShowDialog();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex == -1)
      {
        e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
        e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
        e.Handled = true;
      }
      if (e.RowIndex != 0)
        return;
      e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!this.IsDigitsOnly(this.cbYear.Text.ToString()))
        return;
      this.dataGridView1.DataSource = (object) this.billReport(int.Parse(this.cbYear.Text.Trim().ToString()));
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
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel3 = new Panel();
      this.panel1 = new Panel();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.textBox1 = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.cbYear = new ComboBox();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView1.RowsDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1000, 563);
      this.dataGridView1.TabIndex = 9;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(157, 70);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(156, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(156, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(156, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View FullScreen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 61f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 13;
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 3);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 565);
      this.panel3.TabIndex = 11;
      this.panel1.Controls.Add((Control) this.headerPanel2);
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 574);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 55);
      this.panel1.TabIndex = 12;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel2.CaptionText = "GRAND TOTAL";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(681, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(318, 47);
      ((Control) this.headerPanel2).TabIndex = 81;
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
      ((Control) this.glassButton3).Location = new Point(9, 513);
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
      ((Control) this.glassButton4).Location = new Point(143, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.textBox1.BackColor = Color.AliceBlue;
      this.textBox1.Dock = DockStyle.Fill;
      this.textBox1.Location = new Point(0, 0);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(316, 23);
      this.textBox1.TabIndex = 27;
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
      this.headerPanel1.CaptionText = "SELECT YEAR";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbYear);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(3, 4);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(247, 47);
      ((Control) this.headerPanel1).TabIndex = 80;
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
      ((Control) this.glassButton1).Location = new Point(-60, 513);
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
      ((Control) this.glassButton2).Location = new Point(74, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbYear.BackColor = Color.AliceBlue;
      this.cbYear.Dock = DockStyle.Fill;
      this.cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbYear.FlatStyle = FlatStyle.Popup;
      this.cbYear.FormattingEnabled = true;
      this.cbYear.Location = new Point(0, 0);
      this.cbYear.Name = "cbYear";
      this.cbYear.Size = new Size(245, 23);
      this.cbYear.TabIndex = 26;
      this.cbYear.SelectedIndexChanged += new EventHandler(this.cbYear_SelectedIndexChanged);
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
      this.headerPanel7.CaptionText = "SELECT LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point((int) byte.MaxValue, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(420, 47);
      ((Control) this.headerPanel7).TabIndex = 79;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(418, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
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
      ((Control) this.glassButton8).Location = new Point(115, 513);
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
      ((Control) this.glassButton9).Location = new Point(249, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormNumberOfRedemptionBillsConsolidated);
      this.Text = nameof (FormNumberOfRedemptionBillsConsolidated);
      this.Load += new EventHandler(this.FormNumberOfRedemptionBillsConsolidated_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
