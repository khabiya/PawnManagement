

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class FormStockCheck : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private DataGridView dataGridView1;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel1;
    private TextBox tbxFromBillNumber;
    private HeaderPanel headerPanel3;
    private CheckBox checkBox1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel2;
    private TextBox tbxToBillNumber;
    private GlassButton btnShow;
    private DataGridViewTextBoxColumn ShopCode;
    private DataGridViewTextBoxColumn BillNumber;
    private DataGridViewTextBoxColumn OldBillNumber;
    private DataGridViewTextBoxColumn BillDate;
    private DataGridViewTextBoxColumn Amount;
    private DataGridViewTextBoxColumn CustomerCode;
    private DataGridViewTextBoxColumn CustomerName;
    private DataGridViewTextBoxColumn DoorNumber;
    private DataGridViewTextBoxColumn Addr1;
    private DataGridViewTextBoxColumn Addr2;
    private DataGridViewTextBoxColumn NetWeight;

    public FormStockCheck() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      else if (keyData != Keys.Return)
        ;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void regreshGrid()
    {
      switch (FormMain.BillNumberSeries)
      {
        case "DOUBLE":
          if (PawnManagementClass.validateBillNumberDouble(this.tbxFromBillNumber.Text))
          {
            if (PawnManagementClass.validateBillNumberDouble(this.tbxToBillNumber.Text))
            {
              this.SHOW();
              break;
            }
            this.tbxToBillNumber.Select();
            break;
          }
          this.tbxFromBillNumber.Select();
          break;
        case "SINGLE":
          if (PawnManagementClass.validateBillNumber(this.tbxFromBillNumber.Text))
          {
            if (PawnManagementClass.validateBillNumber(this.tbxToBillNumber.Text))
              this.SHOW();
            else
              this.tbxToBillNumber.Select();
          }
          else
            this.tbxFromBillNumber.Select();
          break;
      }
    }

    private void SHOW()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable(!this.checkBox1.Checked ? "select ShopCode,BillNumber,OldBillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where (shopCode = @ShopCode) AND (BillNumber >= @BillNumber1 AND  BillNumber <= @BillNumber2) AND Redeemed = 'N' order by BillNumber" : "select ShopCode,BillNumber,OldBillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where (shopCode = @ShopCode) AND (BillNumber >= @BillNumber1 AND  BillNumber <= @BillNumber2) order by BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()),
        new OleDbParameter("BillNumber1", (object) this.tbxFromBillNumber.Text.Trim().ToString()),
        new OleDbParameter("BillNumber2", (object) this.tbxToBillNumber.Text.Trim().ToString())
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
      {
        this.dataGridView1.Visible = true;
        this.dataGridView1.Rows.Clear();
        for (int index = 0; index < dataTable.Rows.Count; ++index)
          this.dataGridView1.Rows.Add((object) dataTable.Rows[index]["ShopCode"].ToString(), (object) dataTable.Rows[index]["BillNumber"].ToString(), (object) dataTable.Rows[index]["OldBillNumber"].ToString(), (object) DateTime.Parse(dataTable.Rows[index]["BillDate"].ToString()).ToShortDateString(), (object) dataTable.Rows[index]["Amount"].ToString(), (object) dataTable.Rows[index]["CustomerCode"].ToString(), (object) dataTable.Rows[index]["CustomerName"].ToString(), (object) dataTable.Rows[index]["DoorNumber"].ToString(), (object) dataTable.Rows[index]["Addr1"].ToString(), (object) dataTable.Rows[index]["Addr2"].ToString(), (object) dataTable.Rows[index]["NetWeight"].ToString());
      }
    }

    private void FormStockCheck_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.tbxFromBillNumber.Select();
      this.regreshGrid();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void tbxBillNumber_TextChanged(object sender, EventArgs e)
    {
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
        this.tbxFromBillNumber.Select();
      if (e.KeyCode != Keys.Return || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.Columns.Count <= 0 || this.dataGridView1.CurrentCell == null)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      this.dataGridView1.Rows.RemoveAt(rowIndex);
      this.selectRow();
    }

    private void selectRow()
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.Columns.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex <= 0)
        return;
      this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex - 1].Selected = true;
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
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
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      this.dataGridView1.Rows.RemoveAt(rowIndex);
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click_1(object sender, EventArgs e) => this.regreshGrid();

    private void tbxFromBillNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (!char.IsLetter(e.KeyChar) || !PawnManagementClass.stringContainALetter((sender as TextBox).Text))
              break;
            e.Handled = true;
            break;
          }
          e.Handled = true;
          break;
        case "DOUBLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (char.IsLetter(e.KeyChar) && PawnManagementClass.stringContainsHowManyLetter((sender as TextBox).Text) >= 2)
              e.Handled = true;
            if ((sender as TextBox).Text.Length < 2 && char.IsDigit(e.KeyChar))
              e.Handled = true;
          }
          else
            e.Handled = true;
          break;
      }
    }

    private void tbxToBillNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (!char.IsLetter(e.KeyChar) || !PawnManagementClass.stringContainALetter((sender as TextBox).Text))
              break;
            e.Handled = true;
            break;
          }
          e.Handled = true;
          break;
        case "DOUBLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (char.IsLetter(e.KeyChar) && PawnManagementClass.stringContainsHowManyLetter((sender as TextBox).Text) >= 2)
              e.Handled = true;
            if ((sender as TextBox).Text.Length < 2 && char.IsDigit(e.KeyChar))
              e.Handled = true;
          }
          else
            e.Handled = true;
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.dataGridView1 = new DataGridView();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.tbxFromBillNumber = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.tbxToBillNumber = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.checkBox1 = new CheckBox();
      this.btnShow = new GlassButton();
      this.ShopCode = new DataGridViewTextBoxColumn();
      this.BillNumber = new DataGridViewTextBoxColumn();
      this.OldBillNumber = new DataGridViewTextBoxColumn();
      this.BillDate = new DataGridViewTextBoxColumn();
      this.Amount = new DataGridViewTextBoxColumn();
      this.CustomerCode = new DataGridViewTextBoxColumn();
      this.CustomerName = new DataGridViewTextBoxColumn();
      this.DoorNumber = new DataGridViewTextBoxColumn();
      this.Addr1 = new DataGridViewTextBoxColumn();
      this.Addr2 = new DataGridViewTextBoxColumn();
      this.NetWeight = new DataGridViewTextBoxColumn();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
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
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnShow);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Controls.Add((Control) this.headerPanel7);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 47);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 572);
      this.panel3.TabIndex = 11;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.ShopCode, (DataGridViewColumn) this.BillNumber, (DataGridViewColumn) this.OldBillNumber, (DataGridViewColumn) this.BillDate, (DataGridViewColumn) this.Amount, (DataGridViewColumn) this.CustomerCode, (DataGridViewColumn) this.CustomerName, (DataGridViewColumn) this.DoorNumber, (DataGridViewColumn) this.Addr1, (DataGridViewColumn) this.Addr2, (DataGridViewColumn) this.NetWeight);
      this.dataGridView1.Location = new Point(8, 62);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(984, 500);
      this.dataGridView1.TabIndex = 82;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
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
      ((Control) this.headerPanel7).Location = new Point(9, 3);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(288, 53);
      ((Control) this.headerPanel7).TabIndex = 81;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 4);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(283, 23);
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
      ((Control) this.glassButton8).Location = new Point(-17, 513);
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
      ((Control) this.glassButton9).Location = new Point(117, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel1.CaptionText = "BILL NUMBER FROM";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxFromBillNumber);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(302, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(224, 52);
      ((Control) this.headerPanel1).TabIndex = 80;
      this.headerPanel1.TextAntialias = true;
      this.tbxFromBillNumber.BackColor = Color.AliceBlue;
      this.tbxFromBillNumber.BorderStyle = BorderStyle.None;
      this.tbxFromBillNumber.Dock = DockStyle.Fill;
      this.tbxFromBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromBillNumber.Location = new Point(0, 0);
      this.tbxFromBillNumber.Name = "tbxFromBillNumber";
      this.tbxFromBillNumber.Size = new Size(222, 28);
      this.tbxFromBillNumber.TabIndex = 0;
      this.tbxFromBillNumber.TextChanged += new EventHandler(this.tbxBillNumber_TextChanged);
      this.tbxFromBillNumber.KeyDown += new KeyEventHandler(this.tbxBillNumber_KeyDown);
      this.tbxFromBillNumber.KeyPress += new KeyPressEventHandler(this.tbxFromBillNumber_KeyPress);
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
      this.headerPanel2.CaptionText = "BILL NUMBER TO";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxToBillNumber);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(531, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(224, 52);
      ((Control) this.headerPanel2).TabIndex = 81;
      this.headerPanel2.TextAntialias = true;
      this.tbxToBillNumber.BackColor = Color.AliceBlue;
      this.tbxToBillNumber.BorderStyle = BorderStyle.None;
      this.tbxToBillNumber.Dock = DockStyle.Fill;
      this.tbxToBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToBillNumber.Location = new Point(0, 0);
      this.tbxToBillNumber.Name = "tbxToBillNumber";
      this.tbxToBillNumber.Size = new Size(222, 28);
      this.tbxToBillNumber.TabIndex = 0;
      this.tbxToBillNumber.KeyPress += new KeyPressEventHandler(this.tbxToBillNumber_KeyPress);
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
      this.headerPanel3.CaptionText = "Include Redeemed?";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.checkBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(761, 4);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(146, 53);
      ((Control) this.headerPanel3).TabIndex = 82;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton2).Location = new Point(-161, 513);
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
      ((Control) this.glassButton3).Location = new Point(-27, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.checkBox1.AutoSize = true;
      this.checkBox1.BackColor = Color.Transparent;
      this.checkBox1.Location = new Point(15, 6);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(124, 19);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "Include Redeemed";
      this.checkBox1.UseVisualStyleBackColor = false;
      ((Control) this.btnShow).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnShow.BackColor = Color.LightBlue;
      this.btnShow.FadeOnFocus = true;
      ((Control) this.btnShow).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnShow.ForeColor = Color.MediumBlue;
      this.btnShow.ForeColorOnFocus = Color.Red;
      this.btnShow.ForeColorOnLeave = Color.MediumBlue;
      this.btnShow.GlowColor = Color.White;
      this.btnShow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnShow).Location = new Point(913, 34);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(75, 23);
      ((Control) this.btnShow).TabIndex = 83;
      ((Control) this.btnShow).Text = "&Show";
      ((Control) this.btnShow).Click += new EventHandler(this.glassButton1_Click_1);
      this.ShopCode.HeaderText = "ShopCode";
      this.ShopCode.Name = "ShopCode";
      this.ShopCode.ReadOnly = true;
      this.BillNumber.HeaderText = "BillNumber";
      this.BillNumber.Name = "BillNumber";
      this.BillNumber.ReadOnly = true;
      this.OldBillNumber.HeaderText = "OldBillNumber";
      this.OldBillNumber.Name = "OldBillNumber";
      this.OldBillNumber.ReadOnly = true;
      this.BillDate.HeaderText = "BillDate";
      this.BillDate.Name = "BillDate";
      this.BillDate.ReadOnly = true;
      this.Amount.HeaderText = "Amount";
      this.Amount.Name = "Amount";
      this.Amount.ReadOnly = true;
      this.CustomerCode.HeaderText = "CustomerCode";
      this.CustomerCode.Name = "CustomerCode";
      this.CustomerCode.ReadOnly = true;
      this.CustomerName.HeaderText = "CustomerName";
      this.CustomerName.Name = "CustomerName";
      this.CustomerName.ReadOnly = true;
      this.DoorNumber.HeaderText = "DoorNumber";
      this.DoorNumber.Name = "DoorNumber";
      this.DoorNumber.ReadOnly = true;
      this.Addr1.HeaderText = "Addr1";
      this.Addr1.Name = "Addr1";
      this.Addr1.ReadOnly = true;
      this.Addr2.HeaderText = "Addr2";
      this.Addr2.Name = "Addr2";
      this.Addr2.ReadOnly = true;
      this.NetWeight.HeaderText = "NetWeight";
      this.NetWeight.Name = "NetWeight";
      this.NetWeight.ReadOnly = true;
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
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
