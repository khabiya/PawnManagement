

using CSharpCustomPanelControl;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormLedgerBook : Form
  {
    private DataTable dtLedger = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private DateTimePicker dateTimePicker2;
    private DateTimePicker dateTimePicker1;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label label3;
    private ToolStripMenuItem fontToolStripMenuItem;
    private ToolStripMenuItem comicSansMsToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel1;
    private ComboBox comboBox1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private CustomPanel customPanel1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;

    public FormLedgerBook() => this.InitializeComponent();

    private void getLedger(DateTime d1, DateTime d2)
    {
      string strError = "";
      string newValue1 = "p." + FormMain.LedgerScreen + " as Articles";
      string newValue2 = "p.CustomerCode + ' ' + p.Customername + ' ' + p.DoorNumber + ' ' + p.Addr1 + ' ' + p.Addr2 + ' ' + p.Addr3 as [Customer Name And Address]";
      string str = OrderClass.getColumnOrderForPledgeBookScreen(this.comboBox1.Text).Replace("nameAndAddress", newValue2).Replace("articles", newValue1);
      this.dtLedger = SQLHelper.GetDataTable(!(this.comboBox1.Text == "2") ? "select  " + str + " from tblPledge p  where (BillDate between @d1 and  @d2) and shopcode = @ShopCode  order By BillNumber" : " select  " + str + " from tblPledge  p where (BillDate between @d1 and  @d2) and shopcode = @ShopCode  order By BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (d1), (object) d1.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (d1), (object) d2.ToString("dd/MM/yyyy")),
        new OleDbParameter("shopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form ledger.getLedger()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the pledge details  .\n" + strError);
      }
      else
      {
        if (!(this.comboBox1.Text == "2"))
          ;
        this.dataGridView1.DataSource = (object) this.dtLedger;
        if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
        {
          foreach (DataGridViewBand column in (BaseCollection) this.dataGridView1.Columns)
            column.Visible = true;
          List<string> stringList = new List<string>();
          foreach (string columnName in !(this.comboBox1.Text == "2") ? OrderClass.getcolumnsToHide("PledgeBookScreen1") : OrderClass.getcolumnsToHide("PledgeBookScreen2"))
          {
            if (this.dataGridView1.Columns.Contains(columnName))
              this.dataGridView1.Columns[columnName].Visible = false;
          }
        }
      }
    }

    private void btnDisplay_Click(object sender, EventArgs e) => this.getLedger(this.dateTimePicker1.Value, this.dateTimePicker2.Value);

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
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

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormLedgerBook_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
      this.comboBox1.Text = "2";
      this.dateTimePicker1.Value = DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["BillDate"].ToString());
    }

    private void fontToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (sender is ToolStripItem toolStripItem && toolStripItem.Owner is ContextMenuStrip owner)
        (owner.SourceControl as DataGridView).Font = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dataGridView1.Refresh();
    }

    private void comicSansMsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      (owner.SourceControl as DataGridView).DefaultCellStyle.Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getLedger(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["Redemption Amount"].Value != null && row.Cells["Redemption Amount"].Value.ToString() != "" && row.Cells["Redemption Amount"].Value.ToString() != "0")
          row.DefaultCellStyle.ForeColor = Color.Red;
        else
          row.DefaultCellStyle.ForeColor = Color.Black;
      }
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Ledger").ShowDialog();
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.dateTimePicker1.Focus();
    }

    private void dataGridView1_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["Redeemed"].Value != null && row.Cells["Redeemed"].Value.ToString() == "Y")
          row.DefaultCellStyle.ForeColor = Color.Red;
        else if (row.Cells["Redeemed"].Value != null && row.Cells["Redeemed"].Value.ToString() == "A")
          row.DefaultCellStyle.ForeColor = Color.DarkViolet;
        else
          row.DefaultCellStyle.ForeColor = Color.Black;
      }
    }

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode")
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

    private void changeColumnOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.comboBox1.Text == "1")
      {
        int num = (int) new FormColumnOrder("PledgeBookScreen1").ShowDialog();
        this.getLedger(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
      }
      else
      {
        int num = (int) new FormColumnOrder("PledgeBookScreen2").ShowDialog();
        this.getLedger(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.customPanel1 = new CustomPanel();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.comboBox1 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.label3 = new Label();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.dateTimePicker1 = new DateTimePicker();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.dateTimePicker2 = new DateTimePicker();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.fontToolStripMenuItem = new ToolStripMenuItem();
      this.comicSansMsToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      ((Control) this.customPanel1).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.customPanel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.58238f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.41762f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 13;
      this.customPanel1.BackColor = Color.AliceBlue;
      this.customPanel1.BackColor2 = Color.Azure;
      this.customPanel1.BorderColor = SystemColors.MenuHighlight;
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel7);
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel1);
      ((Control) this.customPanel1).Controls.Add((Control) this.label3);
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel6);
      ((Control) this.customPanel1).Controls.Add((Control) this.headerPanel8);
      ((Control) this.customPanel1).Dock = DockStyle.Fill;
      this.customPanel1.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(3, 3);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(1002, 67);
      ((Control) this.customPanel1).TabIndex = 96;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "SELECT LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(157, 6);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(267, 58);
      ((Control) this.headerPanel7).TabIndex = 93;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 6);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(263, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.btnDisplay_Click);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
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
      ((Control) this.glassButton8).Location = new Point(-46, 513);
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
      ((Control) this.glassButton9).Location = new Point(88, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "SELECT 1 or 2";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(427, 5);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(98, 58);
      ((Control) this.headerPanel1).TabIndex = 94;
      this.headerPanel1.TextAntialias = true;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "1",
        (object) "2"
      });
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(92, 23);
      this.comboBox1.TabIndex = 24;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.btnDisplay_Click);
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
      ((Control) this.glassButton1).Location = new Point(-217, 513);
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
      ((Control) this.glassButton2).Location = new Point(-83, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.label3.Anchor = AnchorStyles.Top;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Engravers MT", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.MediumBlue;
      this.label3.Location = new Point(177, 6);
      this.label3.Name = "label3";
      this.label3.Size = new Size(250, 28);
      this.label3.TabIndex = 10;
      this.label3.Text = "PLEDGE BOOK";
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel6.CaptionEndColor = Color.AliceBlue;
      this.headerPanel6.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "FROM DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.dateTimePicker1);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(531, 6);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(136, 58);
      ((Control) this.headerPanel6).TabIndex = 94;
      this.headerPanel6.TextAntialias = true;
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
      ((Control) this.glassButton10).Location = new Point(-161, 513);
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
      ((Control) this.glassButton11).Location = new Point(-27, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dateTimePicker1.CustomFormat = "mm/dd/yyyy";
      this.dateTimePicker1.Dock = DockStyle.Fill;
      this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dateTimePicker1.Format = DateTimePickerFormat.Short;
      this.dateTimePicker1.Location = new Point(0, 0);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(134, 29);
      this.dateTimePicker1.TabIndex = 0;
      this.dateTimePicker1.ValueChanged += new EventHandler(this.btnDisplay_Click);
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "TO DATE";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.dateTimePicker2);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(673, 6);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(136, 58);
      ((Control) this.headerPanel8).TabIndex = 95;
      this.headerPanel8.TextAntialias = true;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      ((ButtonBase) this.glassButton14).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(-163, 513);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(128, 35);
      ((Control) this.glassButton14).TabIndex = 0;
      ((Control) this.glassButton14).Text = "&SAVE";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton15).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton15.BackColor = Color.LightBlue;
      this.glassButton15.FadeOnFocus = true;
      ((Control) this.glassButton15).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton15.ForeColor = Color.MediumBlue;
      this.glassButton15.ForeColorOnFocus = Color.Red;
      this.glassButton15.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton15.GlowColor = Color.White;
      this.glassButton15.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton15).Location = new Point(-29, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dateTimePicker2.Dock = DockStyle.Fill;
      this.dateTimePicker2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dateTimePicker2.Format = DateTimePickerFormat.Short;
      this.dateTimePicker2.Location = new Point(0, 0);
      this.dateTimePicker2.Name = "dateTimePicker2";
      this.dateTimePicker2.Size = new Size(134, 29);
      this.dateTimePicker2.TabIndex = 1;
      this.dateTimePicker2.ValueChanged += new EventHandler(this.btnDisplay_Click);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 76);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1002, 553);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.fontToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.fontToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.comicSansMsToolStripMenuItem
      });
      this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
      this.fontToolStripMenuItem.Size = new Size(194, 22);
      this.fontToolStripMenuItem.Text = "Font";
      this.fontToolStripMenuItem.Click += new EventHandler(this.fontToolStripMenuItem_Click);
      this.comicSansMsToolStripMenuItem.Name = "comicSansMsToolStripMenuItem";
      this.comicSansMsToolStripMenuItem.Size = new Size(155, 22);
      this.comicSansMsToolStripMenuItem.Text = "Comic Sans Ms";
      this.comicSansMsToolStripMenuItem.Click += new EventHandler(this.comicSansMsToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(194, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change Column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormLedgerBook);
      this.Text = nameof (FormLedgerBook);
      this.Load += new EventHandler(this.FormLedgerBook_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
