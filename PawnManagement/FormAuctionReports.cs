

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections;
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
  public class FormAuctionReports : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private DataTable dt = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton3;
    private TextBox tbxFromDate;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxAuctionDate;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton24;
    private GlassButton glassButton25;
    private TextBox tbxInterest;
    private HeaderPanel headerPanel13;
    private GlassButton glassButton26;
    private GlassButton glassButton27;
    private TextBox tbxAmount;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxNumberOfBills;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private ComboBox comboBox1;
    private GlassButton glassButton14;
    private HeaderPanel headerPanel14;
    private ComboBox cbShopCodes;
    private GlassButton glassButton28;
    private GlassButton glassButton29;
    private ToolStripMenuItem undoAuctionRedemptionToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    private void FormAuctionReports_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      DataTable redemptionRecord = PawnManagementClass.getOldestRedemptionRecord();
      DateTime now;
      if (redemptionRecord != null && redemptionRecord.Rows.Count > 0)
      {
        TextBox tbxFromDate = this.tbxFromDate;
        now = DateTime.Parse(redemptionRecord.Rows[0]["BillDate"].ToString());
        string str = now.ToString("dd/MM/yyyy");
        tbxFromDate.Text = str;
      }
      TextBox tbxToDate = this.tbxToDate;
      now = DateTime.Now;
      string str1 = now.ToString("dd/MM/yyyy");
      tbxToDate.Text = str1;
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.tbxFromDate.Select();
      this.comboBox1.Text = File.ReadAllLines("Reports\\AuctionReports\\LastUsed.txt")[0].ToString();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
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

    public FormAuctionReports() => this.InitializeComponent();

    private void refreshGrid(string query)
    {
      try
      {
        if (!(this.tbxFromDate.Text.Trim().ToString() != "") || !(this.tbxToDate.Text.Trim().ToString() != "") || this.tbxFromDate.Text.Trim().Length != 10 || this.tbxToDate.Text.Trim().Length != 10 || !PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim().ToString()) || !PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.Trim().ToString()) || !(DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()) <= DateTime.Parse(this.tbxToDate.Text.Trim().ToString())))
          return;
        string strError = "";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("FromDate", (object) DateTime.Parse(this.tbxFromDate.Text).ToString("dd/MM/yyyy")));
        List<OleDbParameter> oleDbParameterList1 = parameters;
        DateTime now = DateTime.Parse(this.tbxToDate.Text);
        OleDbParameter oleDbParameter1 = new OleDbParameter("ToDate", (object) now.ToString("dd/MM/yyyy"));
        oleDbParameterList1.Add(oleDbParameter1);
        if (this.tbxAuctionDate.Text.Trim() != "")
        {
          List<OleDbParameter> oleDbParameterList2 = parameters;
          now = DateTime.Parse(this.tbxAuctionDate.Text.Trim());
          OleDbParameter oleDbParameter2 = new OleDbParameter("AuctionDate", (object) now.ToString("dd/MM/yyyy"));
          oleDbParameterList2.Add(oleDbParameter2);
        }
        if (this.cbShopCodes.Text != "")
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        this.dt = SQLHelper.GetDataTable(query, parameters, ref strError);
        if (strError != "")
        {
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("form AuctionReports.refresGrid", MessageAnDStackTrace, username, CreatedOn);
          int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
        }
        else
        {
          if (this.dt == null || this.dt.Rows.Count <= 0)
            ;
          this.dataGridView1.DataSource = (object) this.dt;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form auctionReports.refreshGrid()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
    {
      try
      {
        int num1 = 0;
        int num2 = 0;
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          num1 += int.Parse(row.Cells["amount"].Value.ToString());
          num2 += int.Parse(row.Cells["aUCTIONAMOUNT"].Value.ToString());
        }
        this.tbxNumberOfBills.Text = this.dataGridView1.Rows.Count.ToString();
        this.tbxAmount.Text = num1.ToString();
        this.tbxInterest.Text = num2.ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form auctionReports.datagriview1_datasourcechanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void SHOW()
    {
      if (this.tbxFromDate.Text.Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
      {
        if (this.tbxToDate.Text.Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        {
          if (this.tbxAuctionDate.Text.Trim() != "")
          {
            if (this.tbxAuctionDate.Text.Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxAuctionDate.Text.Trim().ToString()))
            {
              string str = "";
              DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
              if (articlesSettings.Rows[0]["AuctionReportsScreen"] != null)
                str = articlesSettings.Rows[0]["AuctionReportsScreen"].ToString() + " as Articles";
              if (this.cbShopCodes.Text != "")
                this.refreshGrid("select ShopCode,BillNumber,Billdate,Redeemed, IIF(ISNULL(AuctionAmount),'0',AuctionAmount) AS  AuctionAmount,KdisNumber,PurchasedBy,AuctionedBy ,auctiondate,temp1 as InterestRate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,Type,GrossWeight,Deduction,NetWeight,Amount,PresentValue," + str + " from tblpledge where redeemed = 'A' and (BillDate >= @fromdate and BillDate <= @todate) and auctiondate = @AuctionDate and shopCode = @ShopCode");
              else
                this.refreshGrid("select ShopCode,BillNumber,Billdate,Redeemed,IIF(ISNULL(AuctionAmount),'0',AuctionAmount) AS  AuctionAmount,KdisNumber,PurchasedBy,AuctionedBy,auctiondate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,Type,GrossWeight,Deduction,NetWeight,Amount,PresentValue," + str + ",temp1 as InterestRate from tblpledge where redeemed = 'A' and (BillDate >= @fromdate and BillDate <= @todate) and auctiondate = @AuctionDate");
            }
            else
            {
              this.dataGridView1.DataSource = (object) null;
              this.tbxAuctionDate.Select();
              int num = (int) MessageBox.Show("Invalid date");
            }
          }
          else
          {
            string str = "";
            DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
            if (articlesSettings.Rows[0]["AuctionReportsScreen"] != null)
              str = articlesSettings.Rows[0]["AuctionReportsScreen"].ToString() + " as Articles";
            if (this.cbShopCodes.Text != "")
              this.refreshGrid("select ShopCode,BillNumber,Billdate,Redeemed,IIF(ISNULL(AuctionAmount),'0',AuctionAmount) AS AuctionAmount,KdisNumber,PurchasedBy,AuctionedBy,auctiondate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,Type,GrossWeight,Deduction,NetWeight,Amount,PresentValue," + str + ",temp1 as InterestRate from tblpledge where (redeemed = 'A' )and  (BillDate >= @fromdate and Billdate <= @todate ) and shopCode  = @ShopCode");
            else
              this.refreshGrid("select ShopCode,BillNumber,Billdate,Redeemed,IIF(ISNULL(AuctionAmount),'0',AuctionAmount) AS AuctionAmount,KdisNumber,PurchasedBy,AuctionedBy,auctiondate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,Type,GrossWeight,Deduction,NetWeight,Amount,PresentValue," + str + ",temp1 as InterestRate from tblpledge where (redeemed = 'A' )and  (BillDate >= @fromdate and Billdate <= @todate )");
          }
        }
        else
          this.dataGridView1.DataSource = (object) null;
      }
      else
        this.dataGridView1.DataSource = (object) null;
    }

    private void btnShow_Click_1(object sender, EventArgs e) => this.SHOW();

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\AuctionReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (!(this.comboBox1.Text != ""))
        return;
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text);
      RD.SetDataSource(this.dt);
      RD.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
      RD.PrintOptions.PaperSize = PaperSize.PaperA4;
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\AuctionReports\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "Auction Reports", FormMain.username);

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "AUCTION REPORTS").ShowDialog();
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

    private void tbxFromDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
        this.tbxFromDate.Select();
      else
        this.tbxToDate.Select();
    }

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (!PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        this.tbxAuctionDate.Select();
      else
        this.tbxToDate.Select();
    }

    private void tbxAuctionDate_ImeModeChanged(object sender, EventArgs e)
    {
    }

    private void tbxAuctionDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbShopCodes.Select();
    }

    private void undoAuctionRedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      this.updateAuctionInPledgeTable(this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString(), this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString());
    }

    private void updateAuctionInPledgeTable(string BillNumber, string ShopCode)
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblPledge set Redeemed = @Redeemed,RedeemedBy=@RedeemedBy,RedeemedOn=@RedeemedOn ,KdisNumber = @KdisNumber,PurchasedBy = @PurchasedBy,AuctionDate = @AuctionDate,AuctionedBy = @AuctionedBy where BillNumber =@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Redeemed", (object) "N"),
        new OleDbParameter("RedeemedBy", (object) DBNull.Value),
        new OleDbParameter("RedeemedOn", (object) DBNull.Value),
        new OleDbParameter("KdisNumber", (object) DBNull.Value),
        new OleDbParameter("PurchasedBy", (object) DBNull.Value),
        new OleDbParameter("AuctionDate", (object) DBNull.Value),
        new OleDbParameter("AuctionedBy", (object) DBNull.Value),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form AuctionReports.saveAuctionInpledgeTable", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in redemption in pledge" + strError);
      }
      this.SHOW();
    }

    private void cbShopCodes_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxFromDate_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void tbxToDate_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void tbxAuctionDate_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == ""))
        return;
      this.SHOW();
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0)
        return;
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "CustomerCode")
      {
        string CUSTOMERCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["CustomerCode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) ((sender as DataGridView).Location.Y + (sender as DataGridView).Size.Width);
        string BILLNUMBER = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0)
        return;
      if ((sender as DataGridView).Columns[e.ColumnIndex].HeaderText == "BillNumber" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "CustomerCode" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "billnumber")
        (sender as DataGridView).Cursor = Cursors.Hand;
      else
        (sender as DataGridView).Cursor = Cursors.Default;
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
      this.undoAuctionRedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.tbxToDate = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxAuctionDate = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton24 = new GlassButton();
      this.glassButton25 = new GlassButton();
      this.tbxInterest = new TextBox();
      this.headerPanel13 = new HeaderPanel();
      this.glassButton26 = new GlassButton();
      this.glassButton27 = new GlassButton();
      this.tbxAmount = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxNumberOfBills = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.glassButton14 = new GlassButton();
      this.headerPanel14 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton28 = new GlassButton();
      this.glassButton29 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel13).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel14).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(3, 64);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1003, 503);
      this.dataGridView1.TabIndex = 10;
      this.dataGridView1.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.undoAuctionRedemptionToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(217, 114);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(216, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(216, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(216, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.undoAuctionRedemptionToolStripMenuItem.Name = "undoAuctionRedemptionToolStripMenuItem";
      this.undoAuctionRedemptionToolStripMenuItem.Size = new Size(216, 22);
      this.undoAuctionRedemptionToolStripMenuItem.Text = "Undo Auction Redemption";
      this.undoAuctionRedemptionToolStripMenuItem.Click += new EventHandler(this.undoAuctionRedemptionToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(216, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
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
      this.headerPanel1.CaptionText = "FROM";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(7, 6);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(195, 52);
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
      ((Control) this.glassButton1).Location = new Point(-106, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(28, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxFromDate.BackColor = Color.AliceBlue;
      this.tbxFromDate.BorderStyle = BorderStyle.None;
      this.tbxFromDate.Dock = DockStyle.Fill;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(0, 0);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(193, 24);
      this.tbxFromDate.TabIndex = 26;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxFromDate_KeyDown);
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
      this.headerPanel2.CaptionText = "TO";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(207, 6);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(195, 52);
      ((Control) this.headerPanel2).TabIndex = 81;
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
      ((Control) this.glassButton4).Location = new Point(-108, 513);
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
      ((Control) this.glassButton5).Location = new Point(26, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToDate.BackColor = Color.AliceBlue;
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Fill;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(0, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(193, 24);
      this.tbxToDate.TabIndex = 26;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
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
      this.headerPanel3.CaptionText = "AUCTION DAATE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxAuctionDate);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(407, 6);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(195, 52);
      ((Control) this.headerPanel3).TabIndex = 82;
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
      ((Control) this.glassButton6).Location = new Point(-110, 513);
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
      ((Control) this.glassButton7).Location = new Point(24, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAuctionDate.BackColor = Color.AliceBlue;
      this.tbxAuctionDate.BorderStyle = BorderStyle.None;
      this.tbxAuctionDate.Dock = DockStyle.Fill;
      this.tbxAuctionDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAuctionDate.Location = new Point(0, 0);
      this.tbxAuctionDate.Name = "tbxAuctionDate";
      this.tbxAuctionDate.Size = new Size(193, 24);
      this.tbxAuctionDate.TabIndex = 26;
      this.tbxAuctionDate.TextAlign = HorizontalAlignment.Center;
      this.tbxAuctionDate.TextChanged += new EventHandler(this.tbxAuctionDate_TextChanged);
      this.tbxAuctionDate.KeyDown += new KeyEventHandler(this.tbxAuctionDate_KeyDown);
      this.tbxAuctionDate.ImeModeChanged += new EventHandler(this.tbxAuctionDate_ImeModeChanged);
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel4.CaptionText = "TOTAL AUCTION AMOUNT";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton25);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxInterest);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(747, 573);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(259, 58);
      ((Control) this.headerPanel4).TabIndex = 87;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton24).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton24.BackColor = Color.LightBlue;
      this.glassButton24.FadeOnFocus = true;
      ((Control) this.glassButton24).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton24.ForeColor = Color.MediumBlue;
      this.glassButton24.ForeColorOnFocus = Color.Red;
      this.glassButton24.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton24.GlowColor = Color.White;
      ((ButtonBase) this.glassButton24).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton24.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton24).Location = new Point(-36, 513);
      ((Control) this.glassButton24).Name = "glassButton24";
      this.glassButton24.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton24.ShineColor = Color.Transparent;
      ((Control) this.glassButton24).Size = new Size(128, 35);
      ((Control) this.glassButton24).TabIndex = 0;
      ((Control) this.glassButton24).Text = "&SAVE";
      ((ButtonBase) this.glassButton24).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton25).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton25.BackColor = Color.LightBlue;
      this.glassButton25.FadeOnFocus = true;
      ((Control) this.glassButton25).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton25.ForeColor = Color.MediumBlue;
      this.glassButton25.ForeColorOnFocus = Color.Red;
      this.glassButton25.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton25.GlowColor = Color.White;
      this.glassButton25.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton25).Location = new Point(98, 512);
      ((Control) this.glassButton25).Name = "glassButton25";
      this.glassButton25.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton25.ShineColor = Color.Transparent;
      ((Control) this.glassButton25).Size = new Size(123, 37);
      ((Control) this.glassButton25).TabIndex = 1;
      ((Control) this.glassButton25).Text = "&EXIT";
      ((ButtonBase) this.glassButton25).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxInterest.BackColor = Color.AliceBlue;
      this.tbxInterest.BorderStyle = BorderStyle.None;
      this.tbxInterest.Dock = DockStyle.Fill;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.Location = new Point(0, 0);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(257, 31);
      this.tbxInterest.TabIndex = 26;
      this.tbxInterest.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel13).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel13).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel13).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel13).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel13.BorderColor = SystemColors.HotTrack;
      this.headerPanel13.BorderStyle = BorderStyles.Single;
      this.headerPanel13.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel13.CaptionEndColor = Color.AliceBlue;
      this.headerPanel13.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.CaptionHeight = 22;
      this.headerPanel13.CaptionPosition = CaptionPositions.Top;
      this.headerPanel13.CaptionText = "AMOUNT";
      this.headerPanel13.CaptionVisible = true;
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton26);
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton27);
      ((Control) this.headerPanel13).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel13).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel13).ForeColor = Color.DarkBlue;
      this.headerPanel13.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.GradientEnd = SystemColors.ControlLight;
      this.headerPanel13.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).Location = new Point(485, 573);
      ((Control) this.headerPanel13).Name = "headerPanel13";
      this.headerPanel13.PanelIcon = (Icon) null;
      this.headerPanel13.PanelIconVisible = false;
      ((Control) this.headerPanel13).Size = new Size(256, 58);
      ((Control) this.headerPanel13).TabIndex = 86;
      this.headerPanel13.TextAntialias = true;
      ((Control) this.glassButton26).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton26.BackColor = Color.LightBlue;
      this.glassButton26.FadeOnFocus = true;
      ((Control) this.glassButton26).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton26.ForeColor = Color.MediumBlue;
      this.glassButton26.ForeColorOnFocus = Color.Red;
      this.glassButton26.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton26.GlowColor = Color.White;
      ((ButtonBase) this.glassButton26).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton26.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton26).Location = new Point(-39, 513);
      ((Control) this.glassButton26).Name = "glassButton26";
      this.glassButton26.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton26.ShineColor = Color.Transparent;
      ((Control) this.glassButton26).Size = new Size(128, 35);
      ((Control) this.glassButton26).TabIndex = 0;
      ((Control) this.glassButton26).Text = "&SAVE";
      ((ButtonBase) this.glassButton26).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton27).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton27.BackColor = Color.LightBlue;
      this.glassButton27.FadeOnFocus = true;
      ((Control) this.glassButton27).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton27.ForeColor = Color.MediumBlue;
      this.glassButton27.ForeColorOnFocus = Color.Red;
      this.glassButton27.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton27.GlowColor = Color.White;
      this.glassButton27.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton27).Location = new Point(95, 512);
      ((Control) this.glassButton27).Name = "glassButton27";
      this.glassButton27.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton27.ShineColor = Color.Transparent;
      ((Control) this.glassButton27).Size = new Size(123, 37);
      ((Control) this.glassButton27).TabIndex = 1;
      ((Control) this.glassButton27).Text = "&EXIT";
      ((ButtonBase) this.glassButton27).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Dock = DockStyle.Fill;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(0, 0);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(254, 31);
      this.tbxAmount.TabIndex = 25;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel6.CaptionText = "NUMBER OF BILLS";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxNumberOfBills);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(329, 573);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(150, 58);
      ((Control) this.headerPanel6).TabIndex = 84;
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
      ((Control) this.glassButton10).Location = new Point(-143, 513);
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
      ((Control) this.glassButton11).Location = new Point(-9, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNumberOfBills.BackColor = Color.AliceBlue;
      this.tbxNumberOfBills.BorderStyle = BorderStyle.None;
      this.tbxNumberOfBills.Dock = DockStyle.Fill;
      this.tbxNumberOfBills.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfBills.Location = new Point(0, 0);
      this.tbxNumberOfBills.Name = "tbxNumberOfBills";
      this.tbxNumberOfBills.Size = new Size(148, 31);
      this.tbxNumberOfBills.TabIndex = 25;
      this.tbxNumberOfBills.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel7.CaptionText = "PRINT";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = Color.Azure;
      this.headerPanel7.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel7).Location = new Point(3, 573);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(320, 58);
      ((Control) this.headerPanel7).TabIndex = 83;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton12).Location = new Point(27, 513);
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
      ((Control) this.glassButton13).Location = new Point(161, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(248, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(252, 4);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(61, 26);
      ((Control) this.glassButton14).TabIndex = 24;
      ((Control) this.glassButton14).Text = "&PRINT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton14).Click += new EventHandler(this.glassButton2_Click);
      ((Control) this.headerPanel14).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel14).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel14).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel14).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel14.BorderColor = SystemColors.HotTrack;
      this.headerPanel14.BorderStyle = BorderStyles.Single;
      this.headerPanel14.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel14.CaptionEndColor = Color.AliceBlue;
      this.headerPanel14.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.CaptionHeight = 22;
      this.headerPanel14.CaptionPosition = CaptionPositions.Top;
      this.headerPanel14.CaptionText = "SELECT LICENSE";
      this.headerPanel14.CaptionVisible = true;
      ((Control) this.headerPanel14).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton28);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton29);
      ((Control) this.headerPanel14).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel14).ForeColor = Color.DarkBlue;
      this.headerPanel14.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.GradientEnd = SystemColors.ControlLight;
      this.headerPanel14.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel14).Location = new Point(607, 6);
      ((Control) this.headerPanel14).Name = "headerPanel14";
      this.headerPanel14.PanelIcon = (Icon) null;
      this.headerPanel14.PanelIconVisible = false;
      ((Control) this.headerPanel14).Size = new Size(399, 52);
      ((Control) this.headerPanel14).TabIndex = 90;
      this.headerPanel14.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(397, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      ((Control) this.glassButton28).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton28.BackColor = Color.LightBlue;
      this.glassButton28.FadeOnFocus = true;
      ((Control) this.glassButton28).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton28.ForeColor = Color.MediumBlue;
      this.glassButton28.ForeColorOnFocus = Color.Red;
      this.glassButton28.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton28.GlowColor = Color.White;
      ((ButtonBase) this.glassButton28).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton28.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton28).Location = new Point(88, 513);
      ((Control) this.glassButton28).Name = "glassButton28";
      this.glassButton28.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton28.ShineColor = Color.Transparent;
      ((Control) this.glassButton28).Size = new Size(128, 35);
      ((Control) this.glassButton28).TabIndex = 0;
      ((Control) this.glassButton28).Text = "&SAVE";
      ((ButtonBase) this.glassButton28).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton29).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton29.BackColor = Color.LightBlue;
      this.glassButton29.FadeOnFocus = true;
      ((Control) this.glassButton29).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton29.ForeColor = Color.MediumBlue;
      this.glassButton29.ForeColorOnFocus = Color.Red;
      this.glassButton29.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton29.GlowColor = Color.White;
      this.glassButton29.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton29).Location = new Point(222, 512);
      ((Control) this.glassButton29).Name = "glassButton29";
      this.glassButton29.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton29.ShineColor = Color.Transparent;
      ((Control) this.glassButton29).Size = new Size(123, 37);
      ((Control) this.glassButton29).TabIndex = 1;
      ((Control) this.glassButton29).Text = "&EXIT";
      ((ButtonBase) this.glassButton29).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel14);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel13);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormAuctionReports);
      this.Text = nameof (FormAuctionReports);
      this.Load += new EventHandler(this.FormAuctionReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel13).ResumeLayout(false);
      ((Control) this.headerPanel13).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel14).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
