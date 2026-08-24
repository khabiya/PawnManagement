
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

namespace PawnManagement.Forms
{
  public class FormPledgeInLossBasedOnPureWeighttt : Form
  {
    private bool smsclickedOnce = false;
    private DataTable dtPledgeInLoss = new DataTable();
    private DataTable dtLOAD = new DataTable();
    private DataTable dt = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LightBlueFadeDown.jpg");
    private string salePriceGold;
    private string salePriceSilver;
    private IContainer components = (IContainer) null;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxFromDate;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private TextBox tbxRateOfInterest;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton7;
    private TextBox tbxSilverSaleRate;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private TextBox tbxGoldSaleRate;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colSalePrice;
    private DataGridViewTextBoxColumn colWeight;
    private DataGridViewTextBoxColumn colTotalSalePrice;
    private DataGridViewTextBoxColumn colAmountPlusInterest;
    private DataGridViewTextBoxColumn colLosss;
    private ToolStripMenuItem sendSmsToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem callToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private DataGridView dgvNotice;
    private ToolStripMenuItem exportToExcelOptionToolStripMenuItem;

    public FormPledgeInLossBasedOnPureWeighttt() => this.InitializeComponent();

    private void FormPledgeInLossBasedOnPureWeighttt_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvNotice);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.salePriceGold = double.Parse(PawnManagementClass.getKachaRate("GOLD")).ToString();
      this.salePriceSilver = double.Parse(PawnManagementClass.getKachaRate("SILVER")).ToString();
      DataTable unredeemedPledgeRecord = PawnManagementClass.getOldestUnredeemedPledgeRecord();
      DateTime now;
      if (unredeemedPledgeRecord != null && unredeemedPledgeRecord.Rows.Count > 0)
      {
        this.tbxFromDate.Text = DateTime.Parse(unredeemedPledgeRecord.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      }
      else
      {
        TextBox tbxFromDate = this.tbxFromDate;
        now = DateTime.Now;
        string str = now.ToString("dd/MM/yyyy");
        tbxFromDate.Text = str;
      }
      TextBox tbxToDate = this.tbxToDate;
      now = DateTime.Now;
      string str1 = now.ToString("dd/MM/yyyy");
      tbxToDate.Text = str1;
      this.getPledgeInLoss();
    }

    private bool validate()
    {
      if (this.tbxFromDate.Text.Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
      {
        if (this.tbxToDate.Text.Length == 10)
          return true;
        this.tbxToDate.Select();
        return false;
      }
      this.tbxFromDate.Select();
      return false;
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void dgvNotice_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0)
        return;
      if (this.dgvNotice.CurrentCell.OwningColumn.HeaderText == "ID")
      {
        string CUSTOMERCODE = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dgvNotice.CurrentCell.OwningColumn.HeaderText == "NO")
      {
        double num = (double) (this.dgvNotice.Location.Y + this.dgvNotice.Size.Width);
        string BILLNUMBER = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["pledgeBillNumber"].Value.ToString();
        string SHOPCODE = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Pledge in Loss").ShowDialog();
    }

    private void dgvNotice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
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

    private void callToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormCall(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["PHONENUMBER"].Value.ToString()).ShowDialog();
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      int rowCount = this.dgvNotice.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
    }

    private void btnUnselectAll_Click(object sender, EventArgs e)
    {
      int rowCount = this.dgvNotice.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
    }

    private void getPledgeInLoss()
    {
      double num1;
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text) && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
      {
        if (this.tbxGoldSaleRate.Text != "")
        {
          this.salePriceGold = this.tbxGoldSaleRate.Text;
          this.salePriceSilver = double.Parse(PawnManagementClass.getSaleRate("SILVER")).ToString();
        }
        if (this.tbxSilverSaleRate.Text != "")
        {
          num1 = double.Parse(PawnManagementClass.getSaleRate("GOLD"));
          this.salePriceGold = num1.ToString();
          this.salePriceSilver = this.tbxSilverSaleRate.Text;
        }
        if (this.tbxGoldSaleRate.Text != "" && this.tbxSilverSaleRate.Text != "")
        {
          this.salePriceGold = this.tbxGoldSaleRate.Text;
          this.salePriceSilver = this.tbxSilverSaleRate.Text;
        }
        if (this.tbxGoldSaleRate.Text == "" && this.tbxSilverSaleRate.Text == "")
        {
          num1 = double.Parse(PawnManagementClass.getSaleRate("SILVER"));
          this.salePriceSilver = num1.ToString();
          num1 = double.Parse(PawnManagementClass.getSaleRate("GOLD"));
          this.salePriceGold = num1.ToString();
        }
      }
      string strError = "";
      string str1 = "";
      string str2 = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["PledgeInLossScreen"] != null)
        str2 = "p." + articlesSettings.Rows[0]["PledgeInLossScreen"].ToString() + " as Articles";
      if (this.cbShopCodes.Text != "")
        str1 = " where shopCode = @ShopCode ";
      string my_querry = "SELECT p.ShopCode,p.BillNumber, p.BillDate, p.CustomerCode,c.cphone as phonenumber, c.cname+' '+c.cno+'  '+c.caddr1+'  '+c.caddr2 +'  '+c.caddr3 as NameAndAddress, p.amount, p.PresentValue, p.NetWeight, p.pureweight, p.InterestRate, p.TYPE, p.articles FROM( SELECT p.ShopCode,p.BillNumber,p.PhoneNumber, p.BillDate, p.CustomerCode, p.amount, p.PresentValue, p.NetWeight, p.pureweight, p.temp1 as InterestRate, p.TYPE,p.Redeemed ," + str2 + " FROM tblPledge AS p" + str1 + ") AS p LEFT JOIN tblcustomers AS c ON p.customercode=c.cid where  (p.redeemed = 'N') and (p.Billdate >= @BillDate1 and p.Billdate <= @BillDate2) order by p.customercode,p.amount";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.cbShopCodes.Text != "")
        parameters.Add(new OleDbParameter("shopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("BillDate1", (object) this.tbxFromDate.Text));
      parameters.Add(new OleDbParameter("BillDate2", (object) this.tbxToDate.Text));
      this.dtLOAD = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num2 = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        try
        {
          if (this.dtLOAD != null && this.dtLOAD.Rows.Count > 0)
          {
            this.dtLOAD.Columns.Add("NumberOfMonths", typeof (double));
            this.dtLOAD.Columns.Add("Interest", typeof (double));
            this.dtLOAD.Columns.Add("InterestPlusPrincipal", typeof (double));
            this.dtLOAD.Columns.Add("PerGram", typeof (double));
            this.dtLOAD.Columns.Add("MarketValue", typeof (double));
            this.dtLOAD.Columns.Add("Loss", typeof (double));
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            foreach (DataRow row in (InternalDataCollectionBase) this.dtLOAD.Rows)
            {
              DateTime.Parse(row["BillDate"].ToString());
              int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
              row["NumberOfMonths"] = (object) numberOfMonths;
              int num11 = numberOfMonths - 1;
              if (num11 != -1)
              {
                int num12;
                if (this.tbxRateOfInterest.Text == "")
                {
                  DataRow dataRow = row;
                  num12 = int.Parse(row["amount"].ToString()) * int.Parse(row["InterestRate"].ToString()) * num11 / 1200;
                  string str3 = num12.ToString("F");
                  dataRow["Interest"] = (object) str3;
                }
                else
                {
                  DataRow dataRow = row;
                  num12 = int.Parse(row["amount"].ToString()) * int.Parse(this.tbxRateOfInterest.Text.Trim()) * num11 / 1200;
                  string str4 = num12.ToString("F");
                  dataRow["interest"] = (object) str4;
                }
                DataRow dataRow1 = row;
                num12 = int.Parse(row["amount"].ToString()) + int.Parse(row["interest"].ToString());
                string str5 = num12.ToString("F");
                dataRow1["interestPlusPrincipal"] = (object) str5;
                row["perGram"] = (object) Math.Round((double) int.Parse(row["interestPlusPrincipal"].ToString()) / double.Parse(row["pureWeight"].ToString()));
                if (row["type"].ToString() == "GOLD")
                {
                  DataRow dataRow2 = row;
                  num1 = (double) int.Parse(this.salePriceGold) * double.Parse(row["pureWeight"].ToString());
                  string str6 = num1.ToString("F");
                  dataRow2["MarketValue"] = (object) str6;
                  row["Loss"] = (object) Math.Round(double.Parse(row["interestPlusPrincipal"].ToString()) - (double) int.Parse(this.salePriceGold) * double.Parse(row["pureWeight"].ToString()));
                  if (double.Parse(row["Loss"].ToString()) > 0.0)
                  {
                    num6 += double.Parse(row["pureweight"].ToString());
                    num3 += double.Parse(row["amount"].ToString());
                    num4 += double.Parse(row["interest"].ToString());
                    num5 += double.Parse(row["Loss"].ToString());
                  }
                  if (double.Parse(row["Loss"].ToString()) < 0.0)
                    row.Delete();
                }
                else if (row["type"].ToString() == "SILVER")
                {
                  DataRow dataRow3 = row;
                  num1 = (double) int.Parse(this.salePriceSilver) * double.Parse(row["pureWeight"].ToString());
                  string str7 = num1.ToString("F");
                  dataRow3["MarketValue"] = (object) str7;
                  row["Loss"] = (object) Math.Round(double.Parse(row["interestPlusPrincipal"].ToString()) - (double) int.Parse(this.salePriceSilver) * double.Parse(row["pureWeight"].ToString()));
                  if (double.Parse(row["Loss"].ToString()) > 0.0)
                  {
                    num10 += double.Parse(row["pureweight"].ToString());
                    num7 += double.Parse(row["amount"].ToString());
                    num8 += double.Parse(row["interest"].ToString());
                    num9 += double.Parse(row["Loss"].ToString());
                  }
                  if (double.Parse(row["Loss"].ToString()) < 0.0)
                    row.Delete();
                }
                else if (row["type"].ToString() == "OTHERS")
                  row.Delete();
              }
            }
            this.dgvNotice.DataSource = (object) this.dtLOAD;
            this.dgvNotice.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["PureWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["NumberOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["InterestPlusPrincipal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["PerGram"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["MarketValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNotice.Columns["Loss"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Rows.Add(2);
            this.dataGridView1.Rows[0].Cells["colWeight"].Value = (object) num6.ToString("F");
            this.dataGridView1.Rows[1].Cells["colWeight"].Value = (object) num10.ToString("F");
            this.dataGridView1.Rows[0].Cells["colType"].Value = (object) "GOLD";
            this.dataGridView1.Rows[1].Cells["colType"].Value = (object) "SILVER";
            this.dataGridView1.Rows[2].Cells["colType"].Value = (object) "TOTAL";
            this.dataGridView1.Rows[0].Cells["colSalePrice"].Value = (object) this.salePriceGold;
            this.dataGridView1.Rows[1].Cells["colSalePrice"].Value = (object) this.salePriceSilver;
            this.dataGridView1.Rows[0].Cells["colTotalSalePrice"].Value = (object) (num6 * double.Parse(this.salePriceGold)).ToString();
            this.dataGridView1.Rows[1].Cells["colTotalSalePrice"].Value = (object) (num10 * double.Parse(this.salePriceSilver)).ToString();
            this.dataGridView1.Rows[0].Cells["colAmountPlusInterest"].Value = (object) (num3 + num4).ToString("F");
            this.dataGridView1.Rows[1].Cells["colAmountPlusInterest"].Value = (object) (num7 + num8).ToString("F");
            this.dataGridView1.Rows[0].Cells["colLosss"].Value = (object) num5.ToString("F");
            this.dataGridView1.Rows[1].Cells["colLosss"].Value = (object) num9.ToString("F");
            this.dataGridView1.Rows[2].Cells["colLosss"].Value = (object) (num5 + num9).ToString("F");
          }
          else
          {
            this.dgvNotice.DataSource = (object) null;
            this.dataGridView1.DataSource = (object) null;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
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

    private void tbxFromDate_TextChanged(object sender, EventArgs e)
    {
      if (!this.validate())
        return;
      this.getPledgeInLoss();
    }

    private void exportToExcelOptionToolStripMenuItem_Click(object sender, EventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxRateOfInterest = new TextBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.tbxToDate = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxSilverSaleRate = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.tbxGoldSaleRate = new TextBox();
      this.dataGridView1 = new DataGridView();
      this.colType = new DataGridViewTextBoxColumn();
      this.colSalePrice = new DataGridViewTextBoxColumn();
      this.colWeight = new DataGridViewTextBoxColumn();
      this.colTotalSalePrice = new DataGridViewTextBoxColumn();
      this.colAmountPlusInterest = new DataGridViewTextBoxColumn();
      this.colLosss = new DataGridViewTextBoxColumn();
      this.sendSmsToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.dgvNotice = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.callToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOptionToolStripMenuItem = new ToolStripMenuItem();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((ISupportInitialize) this.dgvNotice).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(188, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top;
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
      ((Control) this.headerPanel7).Location = new Point(724, 8);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(278, 47);
      ((Control) this.headerPanel7).TabIndex = 92;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(276, 23);
      this.cbShopCodes.TabIndex = 24;
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
      ((Control) this.glassButton8).Location = new Point(-29, 513);
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
      ((Control) this.glassButton9).Location = new Point(105, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top;
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
      this.headerPanel6.CaptionText = "FROM DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(4, 6);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(137, 49);
      ((Control) this.headerPanel6).TabIndex = 93;
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
      ((Control) this.glassButton10).Location = new Point(-162, 513);
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
      ((Control) this.glassButton11).Location = new Point(-28, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxFromDate.BackColor = Color.AliceBlue;
      this.tbxFromDate.BorderStyle = BorderStyle.None;
      this.tbxFromDate.Dock = DockStyle.Fill;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(0, 0);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(135, 24);
      this.tbxFromDate.TabIndex = 36;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
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
      this.headerPanel3.CaptionText = "RATE OF INTEREST";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxRateOfInterest);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(580, 6);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(137, 49);
      ((Control) this.headerPanel3).TabIndex = 97;
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
      ((Control) this.glassButton5).Location = new Point(-168, 513);
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
      ((Control) this.glassButton6).Location = new Point(-34, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxRateOfInterest.BackColor = Color.AliceBlue;
      this.tbxRateOfInterest.BorderStyle = BorderStyle.None;
      this.tbxRateOfInterest.Dock = DockStyle.Fill;
      this.tbxRateOfInterest.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRateOfInterest.Location = new Point(0, 0);
      this.tbxRateOfInterest.MaxLength = 2;
      this.tbxRateOfInterest.Name = "tbxRateOfInterest";
      this.tbxRateOfInterest.Size = new Size(135, 24);
      this.tbxRateOfInterest.TabIndex = 49;
      this.tbxRateOfInterest.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxRateOfInterest.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "TO DATE";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(148, 6);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(137, 49);
      ((Control) this.headerPanel8).TabIndex = 94;
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
      ((Control) this.glassButton14).Location = new Point(-164, 513);
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
      ((Control) this.glassButton15).Location = new Point(-30, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToDate.BackColor = Color.AliceBlue;
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Fill;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(0, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(135, 24);
      this.tbxToDate.TabIndex = 38;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
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
      this.headerPanel2.CaptionText = "SILVER SALE RATE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxSilverSaleRate);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(436, 6);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(137, 49);
      ((Control) this.headerPanel2).TabIndex = 96;
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
      ((Control) this.glassButton4).Location = new Point(-166, 513);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(128, 35);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&SAVE";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(-32, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSilverSaleRate.BackColor = Color.AliceBlue;
      this.tbxSilverSaleRate.BorderStyle = BorderStyle.None;
      this.tbxSilverSaleRate.Dock = DockStyle.Fill;
      this.tbxSilverSaleRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSilverSaleRate.Location = new Point(0, 0);
      this.tbxSilverSaleRate.Name = "tbxSilverSaleRate";
      this.tbxSilverSaleRate.Size = new Size(135, 24);
      this.tbxSilverSaleRate.TabIndex = 46;
      this.tbxSilverSaleRate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxSilverSaleRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top;
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
      this.headerPanel4.CaptionText = "GOLD SALE RATE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxGoldSaleRate);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(292, 6);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(137, 49);
      ((Control) this.headerPanel4).TabIndex = 95;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton12).Location = new Point(-164, 513);
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
      ((Control) this.glassButton13).Location = new Point(-30, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxGoldSaleRate.BackColor = Color.AliceBlue;
      this.tbxGoldSaleRate.BorderStyle = BorderStyle.None;
      this.tbxGoldSaleRate.Dock = DockStyle.Fill;
      this.tbxGoldSaleRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxGoldSaleRate.Location = new Point(0, 0);
      this.tbxGoldSaleRate.Name = "tbxGoldSaleRate";
      this.tbxGoldSaleRate.Size = new Size(135, 24);
      this.tbxGoldSaleRate.TabIndex = 45;
      this.tbxGoldSaleRate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxGoldSaleRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colType, (DataGridViewColumn) this.colSalePrice, (DataGridViewColumn) this.colWeight, (DataGridViewColumn) this.colTotalSalePrice, (DataGridViewColumn) this.colAmountPlusInterest, (DataGridViewColumn) this.colLosss);
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 449);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(995, 114);
      this.dataGridView1.TabIndex = 90;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.colType.HeaderText = "TYPE";
      this.colType.Name = "colType";
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colSalePrice.DefaultCellStyle = gridViewCellStyle1;
      this.colSalePrice.HeaderText = "SALE PRICE";
      this.colSalePrice.Name = "colSalePrice";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colWeight.DefaultCellStyle = gridViewCellStyle2;
      this.colWeight.HeaderText = "WEIGHT";
      this.colWeight.Name = "colWeight";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colTotalSalePrice.DefaultCellStyle = gridViewCellStyle3;
      this.colTotalSalePrice.HeaderText = "TOTAL SALE PRICE";
      this.colTotalSalePrice.Name = "colTotalSalePrice";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colAmountPlusInterest.DefaultCellStyle = gridViewCellStyle4;
      this.colAmountPlusInterest.HeaderText = "AMOUNT PLUS INTEREST";
      this.colAmountPlusInterest.Name = "colAmountPlusInterest";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colLosss.DefaultCellStyle = gridViewCellStyle5;
      this.colLosss.HeaderText = "LOSS";
      this.colLosss.Name = "colLosss";
      this.sendSmsToolStripMenuItem.Name = "sendSmsToolStripMenuItem";
      this.sendSmsToolStripMenuItem.Size = new Size(188, 22);
      this.sendSmsToolStripMenuItem.Text = "SendSms";
      this.sendSmsToolStripMenuItem.Visible = false;
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1001f));
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.dgvNotice, 0, 0);
      this.tableLayoutPanel1.Location = new Point(4, 61);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
      this.tableLayoutPanel1.Size = new Size(1001, 566);
      this.tableLayoutPanel1.TabIndex = 98;
      this.dgvNotice.AllowUserToAddRows = false;
      this.dgvNotice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvNotice.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvNotice.Dock = DockStyle.Fill;
      this.dgvNotice.Location = new Point(3, 3);
      this.dgvNotice.Name = "dgvNotice";
      this.dgvNotice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvNotice.Size = new Size(995, 440);
      this.dgvNotice.TabIndex = 91;
      this.dgvNotice.CellClick += new DataGridViewCellEventHandler(this.dgvNotice_CellClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.callToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.sendSmsToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOptionToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(189, 136);
      this.callToolStripMenuItem.Name = "callToolStripMenuItem";
      this.callToolStripMenuItem.Size = new Size(188, 22);
      this.callToolStripMenuItem.Text = "Call";
      this.callToolStripMenuItem.Click += new EventHandler(this.callToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(188, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(188, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.exportToExcelOptionToolStripMenuItem.Name = "exportToExcelOptionToolStripMenuItem";
      this.exportToExcelOptionToolStripMenuItem.Size = new Size(188, 22);
      this.exportToExcelOptionToolStripMenuItem.Text = "Export to Excel option";
      this.exportToExcelOptionToolStripMenuItem.Click += new EventHandler(this.exportToExcelOptionToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormPledgeInLossBasedOnPureWeighttt);
      this.Text = nameof (FormPledgeInLossBasedOnPureWeighttt);
      this.Load += new EventHandler(this.FormPledgeInLossBasedOnPureWeighttt_Load);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.dgvNotice).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
