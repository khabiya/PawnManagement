

using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
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
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPartPaymentReports : Form
  {
    private DataTable dt = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\bluelight.jpg");
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ComboBox comboBox1;
    private GlassButton glassButton1;
    private ComboBox cbReleased;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private TextBox tbxFromVoucherDate;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private TextBox tbxToVoucherDate;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxSearch;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormPartPaymentReports() => this.InitializeComponent();

    private void refreshGrid(string FromDate, string toDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (this.cbShopCodes.Text != "")
      {
        my_querry = !(this.tbxSearch.Text != "") ? "select ShopCode,SerialNumber,BillNumber,Amount,BillDate from tblInterestReceived where Active ='1'  AND (BillDate >= @FromDate and BillDate <= @ToDate) AND shopCode = @ShopCode " : "select ShopCode,SerialNumber,BillNumber,Amount,BillDate from tblInterestReceived where Active ='1'  AND (BillDate >= @FromDate and BillDate <= @ToDate) AND shopCode = @ShopCode AND (SerialNumber like @SerialNumber or BillNumber like @BillNumber or  Amount like @Amount or  BillDate like @BillDate)";
        parameters.Add(new OleDbParameter(nameof (FromDate), (object) DateTime.Parse(FromDate)));
        parameters.Add(new OleDbParameter("ToDate", (object) DateTime.Parse(toDate)));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        if (this.tbxSearch.Text != "")
        {
          parameters.Add(new OleDbParameter("SerialNumber", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("BillNumber", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("Amount", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("BillDate", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        }
      }
      else
      {
        my_querry = !(this.tbxSearch.Text != "") ? "select ShopCode,SerialNumber,BillNumber,Amount,BillDate from tblInterestReceived where Active ='1'  and (BillDate >= @FromDate and BillDate <= @ToDate) " : "select ShopCode,SerialNumber,BillNumber,Amount,BillDate from tblInterestReceived where Active ='1'  and (BillDate >= @FromDate and BillDate <= @ToDate) AND (SerialNumber like @SerialNumber or BillNumber like @BillNumber or  Amount like @Amount or  BillDate like @BillDate)";
        parameters.Add(new OleDbParameter(nameof (FromDate), (object) DateTime.Parse(FromDate)));
        parameters.Add(new OleDbParameter("ToDate", (object) DateTime.Parse(toDate)));
        if (this.tbxSearch.Text != "")
        {
          parameters.Add(new OleDbParameter("SerialNumber", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("BillNumber", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("Amount", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
          parameters.Add(new OleDbParameter("BillDate", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        }
      }
      this.dt = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form PartPaymentReports.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form PartPaymentReports.refreshgrid() \n" + strError);
      }
      else
      {
        if (this.cbReleased.Text == "RELEASED")
        {
          List<int> intList = new List<int>();
          for (int index = this.dt.Rows.Count - 1; index >= 0; --index)
          {
            if (PawnManagementClass.checkIfBillNumberIsNotRelease(this.dt.Rows[index]["BillNumber"].ToString(), this.dt.Rows[index]["ShopCode"].ToString()))
              intList.Add(index);
          }
          foreach (int index in intList)
            this.dt.Rows.RemoveAt(index);
        }
        else if (this.cbReleased.Text == "PENDING")
        {
          List<int> intList = new List<int>();
          for (int index = this.dt.Rows.Count - 1; index >= 0; --index)
          {
            if (!PawnManagementClass.checkIfBillNumberIsNotRelease(this.dt.Rows[index]["BillNumber"].ToString(), this.dt.Rows[index]["ShopCode"].ToString()))
              intList.Add(index);
          }
          foreach (int index in intList)
            this.dt.Rows.RemoveAt(index);
        }
        this.dataGridView1.DataSource = (object) this.dt;
      }
    }

    private void btnShow_Click(object sender, EventArgs e) => this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);

    private void refressh(object sender, WaitWindowEventArgs e)
    {
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPartPaymentReports_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      this.tbxFromVoucherDate.Text = DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxToVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\PartPayment\\LastUsed.txt")[0].ToString();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\PartPayment\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
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

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text.Trim()))
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text.Trim()))
          this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
        else
          this.tbxToVoucherDate.Select();
      }
      else
        this.tbxFromVoucherDate.Select();
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Part Payment Reports").ShowDialog();
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text);
      RD.SetDataSource(this.dt);
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\PartPayment\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFromVoucherDate.Select();
    }

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == "") || !PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text))
        return;
      this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
    }

    private void tbxFromVoucherDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text))
        return;
      this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
    }

    private void tbxToVoucherDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text))
        return;
      this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
    }

    private void cbReleased_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text))
        return;
      this.refreshGrid(this.tbxFromVoucherDate.Text, this.tbxToVoucherDate.Text);
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
      this.comboBox1 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.cbReleased = new ComboBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.tbxFromVoucherDate = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.tbxToVoucherDate = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxSearch = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(12, 68);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(984, 488);
      this.dataGridView1.TabIndex = 6;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
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
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.Font = new Font("Arial", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(1, 1);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(525, 30);
      this.comboBox1.TabIndex = 26;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(532, 4);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(73, 27);
      ((Control) this.glassButton1).TabIndex = 27;
      ((Control) this.glassButton1).Text = "&PRINT";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.cbReleased.BackColor = Color.AliceBlue;
      this.cbReleased.Dock = DockStyle.Fill;
      this.cbReleased.FlatStyle = FlatStyle.Popup;
      this.cbReleased.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbReleased.FormattingEnabled = true;
      this.cbReleased.Items.AddRange(new object[3]
      {
        (object) "",
        (object) "RELEASED",
        (object) "PENDING"
      });
      this.cbReleased.Location = new Point(0, 0);
      this.cbReleased.Name = "cbReleased";
      this.cbReleased.Size = new Size(117, 33);
      this.cbReleased.TabIndex = 28;
      this.cbReleased.SelectedIndexChanged += new EventHandler(this.cbReleased_SelectedIndexChanged);
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top;
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
      this.headerPanel5.CaptionText = "FROM DATE";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxFromVoucherDate);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(258, 4);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(169, 58);
      ((Control) this.headerPanel5).TabIndex = 76;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton8).Location = new Point(-124, 513);
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
      ((Control) this.glassButton9).Location = new Point(10, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxFromVoucherDate.BackColor = Color.AliceBlue;
      this.tbxFromVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxFromVoucherDate.Dock = DockStyle.Fill;
      this.tbxFromVoucherDate.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromVoucherDate.Location = new Point(0, 0);
      this.tbxFromVoucherDate.Name = "tbxFromVoucherDate";
      this.tbxFromVoucherDate.Size = new Size(167, 31);
      this.tbxFromVoucherDate.TabIndex = 26;
      this.tbxFromVoucherDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromVoucherDate.TextChanged += new EventHandler(this.tbxFromVoucherDate_TextChanged);
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
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
      this.headerPanel1.CaptionText = "TO DATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxToVoucherDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(431, 4);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(156, 58);
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
      ((Control) this.glassButton2).Location = new Point(-139, 513);
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
      ((Control) this.glassButton3).Location = new Point(-5, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToVoucherDate.BackColor = Color.AliceBlue;
      this.tbxToVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxToVoucherDate.Dock = DockStyle.Fill;
      this.tbxToVoucherDate.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToVoucherDate.Location = new Point(0, 0);
      this.tbxToVoucherDate.Name = "tbxToVoucherDate";
      this.tbxToVoucherDate.Size = new Size(154, 31);
      this.tbxToVoucherDate.TabIndex = 26;
      this.tbxToVoucherDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToVoucherDate.TextChanged += new EventHandler(this.tbxToVoucherDate_TextChanged);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
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
      this.headerPanel2.CaptionText = "RELEASED / PENDING";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbReleased);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(589, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(119, 58);
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
      ((Control) this.glassButton4).Location = new Point(-178, 513);
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
      ((Control) this.glassButton5).Location = new Point(-44, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top;
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
      this.headerPanel3.CaptionText = "SEARCH";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxSearch);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(712, 4);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(284, 58);
      ((Control) this.headerPanel3).TabIndex = 78;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton6).Location = new Point(-13, 513);
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
      ((Control) this.glassButton7).Location = new Point(121, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSearch.BackColor = Color.AliceBlue;
      this.tbxSearch.BorderStyle = BorderStyle.None;
      this.tbxSearch.Dock = DockStyle.Fill;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(0, 0);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(282, 31);
      this.tbxSearch.TabIndex = 26;
      this.tbxSearch.TextAlign = HorizontalAlignment.Center;
      this.tbxSearch.TextChanged += new EventHandler(this.textBox1_TextChanged);
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
      this.headerPanel4.CaptionText = "PRINT";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel4).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(13, 562);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(610, 58);
      ((Control) this.headerPanel4).TabIndex = 79;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton10).Location = new Point(311, 513);
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
      ((Control) this.glassButton11).Location = new Point(445, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = Color.AliceBlue;
      this.headerPanel7.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel7).Location = new Point(12, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(240, 58);
      ((Control) this.headerPanel7).TabIndex = 81;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 6);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(236, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
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
      ((Control) this.glassButton12).Location = new Point(-65, 513);
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
      ((Control) this.glassButton13).Location = new Point(69, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Honeydew;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormPartPaymentReports);
      this.Text = nameof (FormPartPaymentReports);
      this.Load += new EventHandler(this.FormPartPaymentReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
