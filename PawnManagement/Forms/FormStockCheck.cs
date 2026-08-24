
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

namespace PawnManagement.Forms
{
  public class FormStockCheck : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private HeaderPanel headerPanel3;
    private TextBox tbxVerifiedDate;
    private HeaderPanel headerPanel2;
    private TextBox tbxVerifiedBy;
    private DataGridView dataGridView1;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel1;
    private TextBox tbxBillNumber;
    private HeaderPanel headerPanel6;
    private ListBox listBox1;
    private GlassButton glassButton1;

    public FormStockCheck() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void regreshGrid()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select ShopCode,BillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where (shopCode = @ShopCode) AND (stockcheckedOn is null) order by BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString())
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else
      {
        if (dataTable != null && dataTable.Rows.Count > 0)
          this.dataGridView1.Visible = true;
        this.dataGridView1.DataSource = (object) dataTable;
      }
    }

    private void FormStockCheck_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.tbxVerifiedBy.Text = FormMain.username;
      this.tbxVerifiedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      this.tbxBillNumber.Select();
      this.regreshGrid();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void tbxBillNumber_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select ShopCode,BillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where (BillNumber like @BillNumber) AND (shopCode = @ShopCode) AND (stockcheckedOn is null) order by BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber", (object) (this.tbxBillNumber.Text.Trim().ToString() + "%")),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString())
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else
      {
        if (dataTable != null && dataTable.Rows.Count > 0)
          this.dataGridView1.Visible = true;
        this.dataGridView1.DataSource = (object) dataTable;
      }
    }

    private void tbxBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Focus();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private bool checkifTokenPrinted(string BillNumber)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select BillNumber,stockCheckedOn from tblPledge where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["stockCheckedOn"] != null && dataTable.Rows[0]["stockCheckedOn"].ToString() != "")
        return true;
      return false;
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Up && this.dataGridView1.Rows[0].Selected)
        this.tbxBillNumber.Select();
      if (e.KeyCode != Keys.Return || this.listBox1.Items.Contains((object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString()))
        return;
      if (this.checkifTokenPrinted(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString()))
      {
        if (DialogResult.Yes == MessageBox.Show("Bill Number already  stock veriried." + this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString(), "Verify Bill Number again??", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          this.listBox1.Items.Add((object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString());
      }
      else
        this.listBox1.Items.Add((object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString());
    }

    private void listBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete || this.listBox1.Items.Count <= 0 || this.listBox1.SelectedIndex < 0)
        return;
      this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
    }

    private void updateStockThatWerePrinted(string BillNumber, ref int COUNT)
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblPledge set stockCheckedOn = @StockCheckedOn,stockCheckedBy  = @StockCheckedBy where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("StockCheckedOn", (object) DateTime.Parse(this.tbxVerifiedDate.Text).ToString("dd/MM/yyyy")),
        new OleDbParameter("StockCheckedBy", (object) this.tbxVerifiedBy.Text),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
      }
      else
        ++COUNT;
    }

    private void updateStockThatWerePrinted(string BillNumber, DateTime dateVerfiendDate)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set stockCheckedOn = @StockCheckedOn,stockCheckedBy  = @StockCheckedBy where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("StockCheckedOn", (object) dateVerfiendDate.ToString("dd/MM/yyyy")),
        new OleDbParameter("StockCheckedBy", (object) this.tbxVerifiedBy.Text),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      int COUNT = 0;
      foreach (string BillNumber in this.listBox1.Items)
        this.updateStockThatWerePrinted(BillNumber, ref COUNT);
      int num = (int) MessageBox.Show("successfully Updated " + COUNT.ToString() + " rows");
      this.listBox1.Items.Clear();
      this.dataGridView1.DataSource = (object) null;
      this.regreshGrid();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || !(this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode"))
        return;
      string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
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

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "BillNumber" | this.dataGridView1.Columns[e.ColumnIndex].Name == "CustomerCode")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.Columns.Count <= 0 || this.dataGridView1.CurrentCell == null)
        return;
      string BillNumber = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      if (PawnManagementClass.checkForValidateDate(this.tbxVerifiedDate.Text.Trim()))
      {
        this.updateStockThatWerePrinted(BillNumber, DateTime.Parse(this.tbxVerifiedDate.Text));
        this.regreshGrid();
      }
      else
        this.tbxVerifiedDate.Select();
    }

    private void tbxVerifiedDate_TextChanged(object sender, EventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxVerifiedDate.Text))
        this.tbxVerifiedDate.ForeColor = Color.Black;
      else
        this.tbxVerifiedDate.ForeColor = Color.Red;
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e) => this.regreshGrid();

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.glassButton1 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.tbxVerifiedDate = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.tbxVerifiedBy = new TextBox();
      this.dataGridView1 = new DataGridView();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.tbxBillNumber = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.listBox1 = new ListBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1008, 622);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 38);
      this.panel2.TabIndex = 9;
      this.label7.Anchor = AnchorStyles.Top;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(393, 2);
      this.label7.Name = "label7";
      this.label7.Size = new Size(186, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "STOCK CHECK";
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Controls.Add((Control) this.headerPanel7);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Controls.Add((Control) this.headerPanel6);
      this.panel3.Location = new Point(3, 47);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 572);
      this.panel3.TabIndex = 11;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(693, 539);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(75, 23);
      ((Control) this.glassButton1).TabIndex = 85;
      ((Control) this.glassButton1).Text = "Save";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
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
      this.headerPanel3.CaptionText = "VERIFIED DATE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxVerifiedDate);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(625, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(131, 52);
      ((Control) this.headerPanel3).TabIndex = 84;
      this.headerPanel3.TextAntialias = true;
      this.tbxVerifiedDate.BackColor = Color.AliceBlue;
      this.tbxVerifiedDate.BorderStyle = BorderStyle.None;
      this.tbxVerifiedDate.Dock = DockStyle.Fill;
      this.tbxVerifiedDate.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVerifiedDate.Location = new Point(0, 0);
      this.tbxVerifiedDate.Name = "tbxVerifiedDate";
      this.tbxVerifiedDate.Size = new Size(129, 28);
      this.tbxVerifiedDate.TabIndex = 0;
      this.tbxVerifiedDate.TextChanged += new EventHandler(this.tbxVerifiedDate_TextChanged);
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
      this.headerPanel2.CaptionText = "VERIFIED BY";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVerifiedBy);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(462, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(157, 52);
      ((Control) this.headerPanel2).TabIndex = 83;
      this.headerPanel2.TextAntialias = true;
      this.tbxVerifiedBy.BackColor = Color.AliceBlue;
      this.tbxVerifiedBy.BorderStyle = BorderStyle.None;
      this.tbxVerifiedBy.Dock = DockStyle.Fill;
      this.tbxVerifiedBy.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVerifiedBy.Location = new Point(0, 0);
      this.tbxVerifiedBy.Name = "tbxVerifiedBy";
      this.tbxVerifiedBy.Size = new Size(155, 28);
      this.tbxVerifiedBy.TabIndex = 0;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(8, 62);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(759, 470);
      this.dataGridView1.TabIndex = 82;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
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
      ((Control) this.headerPanel7).Location = new Point(3, 3);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(223, 53);
      ((Control) this.headerPanel7).TabIndex = 81;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 4);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(221, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
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
      ((Control) this.glassButton8).Location = new Point(-82, 513);
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
      ((Control) this.glassButton9).Location = new Point(52, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel1.CaptionText = "ENTER BILL NUMBER";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(232, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(224, 52);
      ((Control) this.headerPanel1).TabIndex = 80;
      this.headerPanel1.TextAntialias = true;
      this.tbxBillNumber.BackColor = Color.AliceBlue;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Dock = DockStyle.Fill;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 0);
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(222, 28);
      this.tbxBillNumber.TabIndex = 0;
      this.tbxBillNumber.TextChanged += new EventHandler(this.tbxBillNumber_TextChanged);
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.tbxBillNumber_KeyDown);
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
      this.headerPanel6.CaptionText = "BILL NUMBERS SELECTED";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.listBox1);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(773, 3);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(225, 564);
      ((Control) this.headerPanel6).TabIndex = 79;
      this.headerPanel6.TextAntialias = true;
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.Font = new Font("Consolas", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.listBox1.ForeColor = SystemColors.MenuHighlight;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 24;
      this.listBox1.Location = new Point(0, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(223, 540);
      this.listBox1.TabIndex = 4;
      this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormStockCheck);
      this.Text = nameof (FormStockCheck);
      this.Load += new EventHandler(this.FormStockCheck_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
