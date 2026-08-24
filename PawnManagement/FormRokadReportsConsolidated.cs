

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
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormRokadReportsConsolidated : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxToVoucherDate;
    private TextBox tbxVoucherCode;
    private GlassButton btnShow;
    private TextBox tbxLedgerCode;
    private TextBox tbxFromVoucherDate;
    private ComboBox cbVoucherName;
    private ComboBox cbLedgerType;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton8;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private TableLayoutPanel tableLayoutPanel1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormRokadReportsConsolidated() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.getLedgerType();
      this.cbLedgerType.Select();
    }

    private void SELECTNextControl(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
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
          PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getledgertype()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreportsconsolidated.getledgertype()" + strError);
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
        PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getledgertype() 2 ", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshGrid(string strQuery)
    {
      string strError = "";
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
      DataTable dataTable = SQLHelper.GetDataTable(strQuery, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = dataTable == null || dataTable.Rows.Count <= 0 ? (object) dataTable : (object) dataTable;
    }

    private void glassButton5_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("  ");
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      int num = (int) MessageBox.Show("escape keydown");
    }

    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\u001B')
        return;
      int num = (int) MessageBox.Show("  ");
    }

    private void cbLedgerType_SelectedIndexChanged(object sender, EventArgs e) => this.getLedgerCode();

    private void getLedgerCode()
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
          PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getledgercode()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreportsconsolidated.getledgercode()" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxLedgerCode.Text = dataTable2.Rows[0]["ledgercode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getledgercode() 2 ", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbVoucherName_SelectedIndexChanged(object sender, EventArgs e) => this.getVoucherCode();

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
          PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getvouchercode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreportsconsolidated.getvouchercode" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherCode.Text = dataTable2.Rows[0]["vouchercode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.getvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxLedgerCode_TextChanged(object sender, EventArgs e) => this.gettblVoucherName();

    private void gettblVoucherName()
    {
      try
      {
        string strError = "";
        string my_querry = "select VoucherName from tblVoucherMaster where LedgerCode= @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.gettblvouchername()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokadreportsconsolidated.gettblvouchername()" + strError);
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
        PawnManagementClass.InsertIntoException("form rokadreportsconsolidated.gettblvouchername()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
      if (this.tbxFromVoucherDate.Text.Trim() != "" && !PawnManagementClass.checkForValidateDate(this.tbxFromVoucherDate.Text))
        this.tbxFromVoucherDate.Select();
      else if (this.tbxToVoucherDate.Text.Trim() != "" && !PawnManagementClass.checkForValidateDate(this.tbxToVoucherDate.Text))
      {
        this.tbxToVoucherDate.Select();
      }
      else
      {
        string str = "";
        if (this.cbLedgerType.Text != "")
          str = " t1.ledgercode = @ledgerCode";
        if (this.cbVoucherName.Text != "")
          str = !(str != "") ? str + " t1.vouchercode = @vouchercode" : str + " and t1.vouchercode = @vouchercode";
        if (this.tbxFromVoucherDate.Text != "" && this.tbxToVoucherDate.Text != "")
          str = !(str != "") ? str + " (t1.voucherdate >= @fromvoucherdate and t1.voucherdate <= @tovoucherdate)" : str + " and (t1.voucherdate >= @fromvoucherdate and t1.voucherdate <= @tovoucherdate)";
        this.refreshGrid("select * from (select vouchername,sum(IIf(t1.jammaornovae='jamma',t1.amount,0)) as jammasum, sum(IIf(t1.jammaornovae='novae',t1.amount,0)) as novaesum,sum( IIf(t1.jammaornovae='jamma',t1.amount,0)) - sum(IIf(t1.jammaornovae='novae',t1.amount,0))  as amount from tblvouchers t1 " + (!(str != "") ? "where active ='1'" : "where " + str + " and active = '1'") + " group by vouchercode,vouchername) order by amount");
      }
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

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Rokad Reports Consolidated").ShowDialog();
    }

    private void cbLedgerType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbVoucherName.Select();
    }

    private void cbVoucherName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFromVoucherDate.Select();
    }

    private void tbxFromVoucherDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxToVoucherDate.Select();
    }

    private void tbxToVoucherDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnShow).Focus();
    }

    private void tbxAcceptDecimal(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
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
      this.tbxToVoucherDate = new TextBox();
      this.tbxVoucherCode = new TextBox();
      this.btnShow = new GlassButton();
      this.tbxLedgerCode = new TextBox();
      this.tbxFromVoucherDate = new TextBox();
      this.cbVoucherName = new ComboBox();
      this.cbLedgerType = new ComboBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(12, 75);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(984, 545);
      this.dataGridView1.TabIndex = 1;
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
      this.exportToExcelToolStripMenuItem.Text = "ExportToExcel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tbxToVoucherDate.BackColor = Color.AliceBlue;
      this.tbxToVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxToVoucherDate.Dock = DockStyle.Fill;
      this.tbxToVoucherDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToVoucherDate.Location = new Point(0, 0);
      this.tbxToVoucherDate.Name = "tbxToVoucherDate";
      this.tbxToVoucherDate.Size = new Size(118, 24);
      this.tbxToVoucherDate.TabIndex = 0;
      this.tbxToVoucherDate.KeyDown += new KeyEventHandler(this.tbxToVoucherDate_KeyDown);
      this.tbxVoucherCode.BackColor = Color.AliceBlue;
      this.tbxVoucherCode.BorderStyle = BorderStyle.None;
      this.tbxVoucherCode.Dock = DockStyle.Fill;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(0, 0);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.ReadOnly = true;
      this.tbxVoucherCode.Size = new Size(118, 24);
      this.tbxVoucherCode.TabIndex = 0;
      this.tbxVoucherCode.KeyDown += new KeyEventHandler(this.SELECTNextControl);
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
      ((Control) this.btnShow).Location = new Point(859, 3);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(122, 51);
      ((Control) this.btnShow).TabIndex = 0;
      ((Control) this.btnShow).Text = "&show";
      ((ButtonBase) this.btnShow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnShow).Click += new EventHandler(this.btnShow_Click);
      this.tbxLedgerCode.BackColor = Color.AliceBlue;
      this.tbxLedgerCode.BorderStyle = BorderStyle.None;
      this.tbxLedgerCode.Dock = DockStyle.Fill;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(0, 0);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.ReadOnly = true;
      this.tbxLedgerCode.Size = new Size(118, 24);
      this.tbxLedgerCode.TabIndex = 0;
      this.tbxLedgerCode.TextChanged += new EventHandler(this.tbxLedgerCode_TextChanged);
      this.tbxLedgerCode.KeyDown += new KeyEventHandler(this.SELECTNextControl);
      this.tbxFromVoucherDate.BackColor = Color.AliceBlue;
      this.tbxFromVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxFromVoucherDate.Dock = DockStyle.Fill;
      this.tbxFromVoucherDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromVoucherDate.Location = new Point(0, 0);
      this.tbxFromVoucherDate.Name = "tbxFromVoucherDate";
      this.tbxFromVoucherDate.Size = new Size(118, 24);
      this.tbxFromVoucherDate.TabIndex = 0;
      this.tbxFromVoucherDate.KeyDown += new KeyEventHandler(this.tbxFromVoucherDate_KeyDown);
      this.cbVoucherName.BackColor = Color.AliceBlue;
      this.cbVoucherName.Dock = DockStyle.Fill;
      this.cbVoucherName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbVoucherName.FormattingEnabled = true;
      this.cbVoucherName.Location = new Point(0, 0);
      this.cbVoucherName.Name = "cbVoucherName";
      this.cbVoucherName.Size = new Size(168, 24);
      this.cbVoucherName.TabIndex = 0;
      this.cbVoucherName.SelectedIndexChanged += new EventHandler(this.cbVoucherName_SelectedIndexChanged);
      this.cbVoucherName.KeyDown += new KeyEventHandler(this.cbVoucherName_KeyDown);
      this.cbLedgerType.BackColor = Color.AliceBlue;
      this.cbLedgerType.Dock = DockStyle.Fill;
      this.cbLedgerType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType.FormattingEnabled = true;
      this.cbLedgerType.Location = new Point(0, 0);
      this.cbLedgerType.Name = "cbLedgerType";
      this.cbLedgerType.Size = new Size(168, 24);
      this.cbLedgerType.TabIndex = 0;
      this.cbLedgerType.SelectedIndexChanged += new EventHandler(this.cbLedgerType_SelectedIndexChanged);
      this.cbLedgerType.KeyDown += new KeyEventHandler(this.cbLedgerType_KeyDown);
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
      ((Control) this.headerPanel4).Size = new Size(170, 51);
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
      ((Control) this.glassButton6).Location = new Point(-129, 513);
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
      ((Control) this.glassButton7).Location = new Point(5, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbVoucherName);
      ((Control) this.headerPanel1).Dock = DockStyle.Fill;
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(305, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(170, 51);
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
      ((Control) this.glassButton1).Location = new Point(-131, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 1;
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
      ((Control) this.glassButton2).Location = new Point(3, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.headerPanel2).Location = new Point(607, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(120, 51);
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
      ((Control) this.headerPanel3).Location = new Point(733, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(120, 51);
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
      ((Control) this.headerPanel5).Location = new Point(481, 3);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(120, 51);
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
      ((Control) this.headerPanel6).Location = new Point(179, 3);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(120, 51);
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
      this.tableLayoutPanel1.Controls.Add((Control) this.btnShow, 6, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel3, 5, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel6, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel2, 4, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.headerPanel1, 2, 0);
      this.tableLayoutPanel1.Location = new Point(12, 12);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(984, 57);
      this.tableLayoutPanel1.TabIndex = 0;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.dataGridView1);
      this.KeyPreview = true;
      this.Name = nameof (FormRokadReportsConsolidated);
      this.Text = "Rokad REports Consolidated";
      this.Load += new EventHandler(this.Form1_Load);
      this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
      this.KeyPress += new KeyPressEventHandler(this.Form1_KeyPress);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
