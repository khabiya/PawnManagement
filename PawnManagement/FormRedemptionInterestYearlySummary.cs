
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
  public class FormRedemptionInterestYearlySummary : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\bluelight.jpg");
    private DataTable dt = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn billdate;
    private DataGridViewTextBoxColumn january;
    private DataGridViewTextBoxColumn february;
    private DataGridViewTextBoxColumn march;
    private DataGridViewTextBoxColumn april;
    private DataGridViewTextBoxColumn may;
    private DataGridViewTextBoxColumn june;
    private DataGridViewTextBoxColumn july;
    private DataGridViewTextBoxColumn august;
    private DataGridViewTextBoxColumn september;
    private DataGridViewTextBoxColumn october;
    private DataGridViewTextBoxColumn november;
    private DataGridViewTextBoxColumn december;
    private ComboBox cbYear;
    private ComboBox comboBox1;
    private TextBox textBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullSCrenToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Panel panel3;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton1;
    private GlassButton glassButton6;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;

    public FormRedemptionInterestYearlySummary() => this.InitializeComponent();

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.cbShopCodes.Text == "")
      {
        if (this.comboBox1.Text == "INTEREST")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate,temp3 as finalinterest FROM tblredemption WHERE year(billdate) =@year ORDER BY billdate; ";
        if (this.comboBox1.Text == "REDEMPTION AMOUNT")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate,temp4 as  RedemptionAmount FROM tblredemption WHERE year(billdate) =@year ORDER BY billdate;";
        if (this.comboBox1.Text == "AMOUNT")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate, Amount FROM tblredemption WHERE year(billdate) =@year ORDER BY billdate;";
        parameters.Add(new OleDbParameter("year", (object) this.cbYear.Text.Trim().ToString()));
      }
      else
      {
        if (this.comboBox1.Text == "INTEREST")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate,temp3 as finalinterest FROM tblredemption WHERE year(billdate) =@year  AND shopcode = @ShopCode ORDER BY billdate; ";
        if (this.comboBox1.Text == "REDEMPTION AMOUNT")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate,temp4 as  RedemptionAmount FROM tblredemption WHERE year(billdate) =@year  AND shopcode = @ShopCode ORDER BY billdate;";
        if (this.comboBox1.Text == "AMOUNT")
          my_querry = "SELECT  billnumber,month(billdate) AS mbd, day(billdate) AS dbd, billdate, Amount FROM tblredemption WHERE year(billdate)= @year AND shopcode = @ShopCode ORDER BY billdate;";
        parameters.Add(new OleDbParameter("year", (object) this.cbYear.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
      }
      this.dt = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(this.comboBox1.Text == "INTEREST") || this.dt == null || this.dt.Rows.Count <= 0)
        ;
      if (!(this.comboBox1.Text == "REDEMPTION AMOUNT") || this.dt == null || this.dt.Rows.Count <= 0)
        ;
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.getREdemptionReports();

    private void getREdemptionReports()
    {
      double num1 = 0.0;
      this.refreshGrid();
      for (int index1 = 0; index1 < 31; ++index1)
      {
        for (int index2 = 1; index2 < 13; ++index2)
        {
          string str = this.getSum(index2.ToString(), (index1 + 1).ToString()).ToString();
          this.dataGridView1.Rows[index1].Cells[index2].Value = (object) str;
        }
      }
      for (int index3 = 1; index3 < 13; ++index3)
      {
        double num2 = 0.0;
        for (int index4 = 0; index4 < 31; ++index4)
          num2 += double.Parse(this.dataGridView1.Rows[index4].Cells[index3].Value.ToString());
        this.dataGridView1.Rows[31].Cells[index3].Value = (object) num2;
      }
      for (int index = 1; index < 13; ++index)
        num1 += double.Parse(this.dataGridView1.Rows[31].Cells[index].Value.ToString());
      this.textBox1.Text = num1.ToString();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      this.loadcbYear();
      for (int index = 0; index < 31; ++index)
      {
        this.dataGridView1.Rows.Add();
        this.dataGridView1.Rows[index].Cells[0].Value = (object) (index + 1);
      }
      this.dataGridView1.Rows.Add();
      this.dataGridView1.Rows[31].Cells[0].Value = (object) "Total";
      if (this.comboBox1.Items.Count <= 0)
        return;
      this.comboBox1.SelectedIndex = 0;
    }

    private double getSum(string month, string day)
    {
      double sum = 0.0;
      if (this.comboBox1.Text == "INTEREST" && this.dt != null && this.dt.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        {
          if (row["mbd"].ToString() == month && row["dbd"].ToString() == day)
            sum += double.Parse(row["finalinterest"].ToString());
        }
      }
      if (this.comboBox1.Text == "REDEMPTION AMOUNT" && this.dt != null && this.dt.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        {
          if (row["mbd"].ToString() == month && row["dbd"].ToString() == day)
            sum += double.Parse(row["redemptionAmount"].ToString());
        }
      }
      if (this.comboBox1.Text == "AMOUNT" && this.dt != null && this.dt.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        {
          if (row["mbd"].ToString() == month && row["dbd"].ToString() == day)
            sum += double.Parse(row["Amount"].ToString());
        }
      }
      return sum;
    }

    private void loadcbYear()
    {
      string strError = "";
      string my_querry = "select distinct(year(billdate)) as distinctyears from tblRedemption";
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

    private void viewFullSCrenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Redemption INterest Yearly summary").ShowDialog();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.comboBox1.Text != ""))
        return;
      this.getREdemptionReports();
    }

    private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.cbYear.Text != ""))
        return;
      this.getREdemptionReports();
    }

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == ""))
        return;
      this.getREdemptionReports();
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
      this.billdate = new DataGridViewTextBoxColumn();
      this.january = new DataGridViewTextBoxColumn();
      this.february = new DataGridViewTextBoxColumn();
      this.march = new DataGridViewTextBoxColumn();
      this.april = new DataGridViewTextBoxColumn();
      this.may = new DataGridViewTextBoxColumn();
      this.june = new DataGridViewTextBoxColumn();
      this.july = new DataGridViewTextBoxColumn();
      this.august = new DataGridViewTextBoxColumn();
      this.september = new DataGridViewTextBoxColumn();
      this.october = new DataGridViewTextBoxColumn();
      this.november = new DataGridViewTextBoxColumn();
      this.december = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullSCrenToolStripMenuItem = new ToolStripMenuItem();
      this.cbYear = new ComboBox();
      this.comboBox1 = new ComboBox();
      this.textBox1 = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.panel3 = new Panel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.billdate, (DataGridViewColumn) this.january, (DataGridViewColumn) this.february, (DataGridViewColumn) this.march, (DataGridViewColumn) this.april, (DataGridViewColumn) this.may, (DataGridViewColumn) this.june, (DataGridViewColumn) this.july, (DataGridViewColumn) this.august, (DataGridViewColumn) this.september, (DataGridViewColumn) this.october, (DataGridViewColumn) this.november, (DataGridViewColumn) this.december);
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView1.RowsDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1000, 573);
      this.dataGridView1.TabIndex = 5;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.billdate.HeaderText = "billdate";
      this.billdate.Name = "billdate";
      this.billdate.ReadOnly = true;
      this.january.HeaderText = "january";
      this.january.Name = "january";
      this.january.ReadOnly = true;
      this.february.HeaderText = "february";
      this.february.Name = "february";
      this.february.ReadOnly = true;
      this.march.HeaderText = "march";
      this.march.Name = "march";
      this.march.ReadOnly = true;
      this.april.HeaderText = "april";
      this.april.Name = "april";
      this.april.ReadOnly = true;
      this.may.HeaderText = "may";
      this.may.Name = "may";
      this.may.ReadOnly = true;
      this.june.HeaderText = "june";
      this.june.Name = "june";
      this.june.ReadOnly = true;
      this.july.HeaderText = "july";
      this.july.Name = "july";
      this.july.ReadOnly = true;
      this.august.HeaderText = "august";
      this.august.Name = "august";
      this.august.ReadOnly = true;
      this.september.HeaderText = "september";
      this.september.Name = "september";
      this.september.ReadOnly = true;
      this.october.HeaderText = "october";
      this.october.Name = "october";
      this.october.ReadOnly = true;
      this.november.HeaderText = "november";
      this.november.Name = "november";
      this.november.ReadOnly = true;
      this.december.HeaderText = "december";
      this.december.Name = "december";
      this.december.ReadOnly = true;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullSCrenToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(156, 70);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(155, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(155, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullSCrenToolStripMenuItem.Name = "viewFullSCrenToolStripMenuItem";
      this.viewFullSCrenToolStripMenuItem.Size = new Size(155, 22);
      this.viewFullSCrenToolStripMenuItem.Text = "View Full SCren";
      this.viewFullSCrenToolStripMenuItem.Click += new EventHandler(this.viewFullSCrenToolStripMenuItem_Click);
      this.cbYear.BackColor = Color.AliceBlue;
      this.cbYear.Dock = DockStyle.Fill;
      this.cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbYear.FlatStyle = FlatStyle.Popup;
      this.cbYear.FormattingEnabled = true;
      this.cbYear.Location = new Point(0, 0);
      this.cbYear.Name = "cbYear";
      this.cbYear.Size = new Size(153, 23);
      this.cbYear.TabIndex = 6;
      this.cbYear.SelectedIndexChanged += new EventHandler(this.cbYear_SelectedIndexChanged);
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.Dock = DockStyle.Fill;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.Popup;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "AMOUNT",
        (object) "INTEREST",
        (object) "REDEMPTION AMOUNT"
      });
      this.comboBox1.Location = new Point(0, 0);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(153, 23);
      this.comboBox1.TabIndex = 7;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.textBox1.BackColor = Color.AliceBlue;
      this.textBox1.Dock = DockStyle.Fill;
      this.textBox1.Location = new Point(0, 0);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(296, 23);
      this.textBox1.TabIndex = 8;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1008, 636);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.headerPanel3);
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.headerPanel7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 49);
      this.panel2.TabIndex = 9;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel3.CaptionText = "GRAND TOTAL";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(702, 0);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(298, 47);
      ((Control) this.headerPanel3).TabIndex = 81;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(-11, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel2.CaptionText = "SELECT YEAR";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbYear);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(544, 0);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(155, 47);
      ((Control) this.headerPanel2).TabIndex = 80;
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
      ((Control) this.glassButton4).Location = new Point(-152, 513);
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
      ((Control) this.glassButton5).Location = new Point(-18, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel1.CaptionText = "SELECT";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(387, 0);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(155, 47);
      ((Control) this.headerPanel1).TabIndex = 79;
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
      ((Control) this.glassButton2).Location = new Point(-150, 513);
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
      ((Control) this.glassButton3).Location = new Point(-16, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.headerPanel7).Location = new Point(1, 0);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(381, 47);
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
      this.cbShopCodes.Size = new Size(379, 23);
      this.cbShopCodes.TabIndex = 24;
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
      ((Control) this.glassButton8).Location = new Point(76, 513);
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
      ((Control) this.glassButton9).Location = new Point(210, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 58);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 575);
      this.panel3.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormRedemptionInterestYearlySummary);
      this.Text = "redemption Interest summary";
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
