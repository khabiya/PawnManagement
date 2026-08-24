
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormToken : Form
  {
    private string billNumberssList = "";
    private Image imagesRows = Image.FromFile("Photos\\Resources\\BLUELIGHT.jpg");
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private ReportDocument rd = new ReportDocument();
    private DataTable dt = new DataTable();
    private DataTable dt1 = new DataTable();
    private DataTable dtReport = new DataTable();
    private DataTable dtReport1 = new DataTable();
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private IContainer components = (IContainer) null;
    private CrystalReportViewer crystalReportViewer1;
    private TextBox tbxBillNumber;
    private ListBox listBox1;
    private DataGridView dgvPledge;
    private ComboBox cbTokanPrintFormats;
    private GlassButton btnShow;
    private GlassButton btnPrint;
    private HeaderPanel headerPanel6;
    private HeaderPanel headerPanel1;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;

    public FormToken() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Token_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dgvPledge);
      if (this.cbTokanPrintFormats.Items.Count > 0)
        this.cbTokanPrintFormats.SelectedIndex = 0;
      this.crystalReportViewer1.ShowPrintButton = false;
      this.getTodayPledgeBills();
      this.getReportTypes();
      if (this.cbTokanPrintFormats.Items.Count > 0)
        this.cbTokanPrintFormats.SelectedIndex = 0;
      this.getShopCodes();
      if (this.cbShopCodes.Items.Count > 0)
        this.cbShopCodes.SelectedIndex = 0;
      this.cbShopCodes.Text = PawnManagementClass.getDefaultLicenseCode();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
      this.cbTokanPrintFormats.Text = File.ReadAllLines("Reports\\Tokens\\LastUsed.txt")[0].ToString();
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Tokens\\\\", "*.rpt"))
        this.cbTokanPrintFormats.Items.Add(file);
    }

    private void getTodayPledgeBills()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select ShopCode,BillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where BillDate = @BillDate", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) DateTime.Now.ToShortDateString())
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (!this.listBox1.Items.Contains((object) row["BillNumber"].ToString()) && !this.checkifTokenPrinted(row["BillNumber"].ToString()))
            this.listBox1.Items.Add((object) row["BillNumber"].ToString());
        }
      }
    }

    private void getTokenPrintFormats()
    {
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select * from tblPrintSettings", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.getTokenPrintFormats second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(" form token.getTokenPrintFormats second exception " + strError);
      }
      else if (this.dt != null && this.dt.Rows.Count > 0)
      {
        this.cbTokanPrintFormats.Items.Clear();
        foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        {
          if (row["TokenPrintFormats"] != null && row["TokenPrintFormats"].ToString() != "")
            this.cbTokanPrintFormats.Items.Add((object) row["TokenPrintFormats"].ToString());
        }
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select ShopCode,BillNumber,BillDate,Amount,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,NetWeight from tblPledge where BillNumber like @BillNumber AND shopCode = @ShopCode", new List<OleDbParameter>()
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
        this.dgvPledge.Visible = true;
        this.dgvPledge.DataSource = (object) this.dt;
      }
    }

    private void dgvPledge_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void dgvPledge_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || this.listBox1.Items.Contains((object) this.dgvPledge.Rows[this.dgvPledge.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString()))
        return;
      if (this.checkifTokenPrinted(this.dgvPledge.Rows[this.dgvPledge.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString()))
      {
        if (DialogResult.Yes == MessageBox.Show("Token for BillNumber " + this.dgvPledge.Rows[this.dgvPledge.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString() + " already printed..print again?", "print token again??", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          this.listBox1.Items.Add((object) this.dgvPledge.Rows[this.dgvPledge.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString());
      }
      else
        this.listBox1.Items.Add((object) this.dgvPledge.Rows[this.dgvPledge.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString());
    }

    private void tbxBillNumber_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dgvPledge == null || this.dgvPledge.Rows[0] == null)
        return;
      this.dgvPledge.Focus();
      this.dgvPledge.Rows[0].Selected = true;
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void dgvPledge_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      this.tbxBillNumber.Select();
    }

    private void listBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete || this.listBox1.Items.Count <= 0 || this.listBox1.SelectedIndex < 0)
        return;
      this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void dgvPledge_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Are you sure", "Print", MessageBoxButtons.YesNo))
        return;
      this.crystalReportViewer1.PrintReport();
      foreach (string BillNumber in this.listBox1.Items)
        this.updateTokensThatWerePrinted(BillNumber);
      PawnManagementClass.InsertIntoHistory("TOKENS", "Tokens" + this.billNumberssList + " were printed", "", "", FormMain.username, DateTime.Now.ToString());
      File.WriteAllText("Reports\\\\Tokens\\\\LastUsed.txt", this.cbTokanPrintFormats.Text);
    }

    private bool checkifTokenPrinted(string BillNumber)
    {
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select BillNumber,tokenprinted from tblPledge where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form token.textbox_textchanged second exception", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else if (this.dt != null && this.dt.Rows.Count > 0 && this.dt.Rows[0]["tokenprinted"] != null && this.dt.Rows[0]["tokenprinted"].ToString() == "Y")
        return true;
      return false;
    }

    private void updateTokensThatWerePrinted(string BillNumber)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set TokenPrinted = @TokenPrinted  where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("TokenPrinted", (object) "Y"),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void dgvPledge_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.listBox1.Items.Count > 0)
        {
          if (this.cbTokanPrintFormats.Text.ToString().Contains("Combined"))
            this.printReportTokenArticlesCombined();
          else
            this.printReportTokenArticles();
        }
        else
        {
          int num = (int) MessageBox.Show("Select Bill Numbers");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form token.btnShow_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void printReportTokenArticlesCombined()
    {
      string str1 = "";
      foreach (string str2 in this.listBox1.Items)
        str1 = str1 + ",'" + str2 + "'";
      this.billNumberssList = str1.Substring(1, str1.Length - 1);
      this.dgvPledge.Visible = false;
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select p.billnumber,p.billdate,p.amount,p.netWeight,p.customerName,p.articles from tblPledge p where p.BillNumber in(" + str1.Substring(1, str1.Length - 1) + ")   order by BillNumber ", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
      }
      else if (this.dt != null && this.dt.Rows.Count > 0)
      {
        this.rd.Load(this.cbTokanPrintFormats.Text.ToString());
        this.rd.SetDataSource(this.dt);
        this.crystalReportViewer1.ReportSource = (object) this.rd;
      }
    }

    private void printReportTokenArticles()
    {
      string str1 = "";
      foreach (string str2 in this.listBox1.Items)
        str1 = str1 + ",'" + str2 + "'";
      this.billNumberssList = str1.Substring(1, str1.Length - 1);
      this.dgvPledge.Visible = false;
      string strError1 = "";
      this.dtReport1 = SQLHelper.GetDataTable("select * from tblPledgeArticles where BillNumber in(" + str1.Substring(1, str1.Length - 1) + ")", ref strError1);
      if (strError1 != "")
      {
        PawnManagementClass.InsertIntoException("form token", strError1, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError1);
      }
      string strError2 = "";
      this.dtReport = SQLHelper.GetDataTable("select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber in(" + str1.Substring(1, str1.Length - 1) + ") order by billnumber", ref strError2);
      if (strError2 != "")
      {
        PawnManagementClass.InsertIntoException("", strError2, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError2);
      }
      else
      {
        this.rd.Load(this.cbTokanPrintFormats.Text.ToString());
        this.rd.Subreports[0].SetDataSource(this.dtReport1);
        this.rd.SetDataSource(this.dtReport);
        this.crystalReportViewer1.ReportSource = (object) this.rd;
      }
    }

    private void cbTokanPrintFormats_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e)
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

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
        return;
      this.cbShopCodes.Select();
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text);
        this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
        this.tbxBillNumber.Select();
      }
      else
        this.tbxBillNumber.Select();
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
        return;
      this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text);
      this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
      this.tbxBillNumber.Select();
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Are you sure", "Print", MessageBoxButtons.YesNo))
        return;
      this.rd.PrintOptions.CustomPaperSource = new PrintDocument().PrinterSettings.PaperSources[1];
      this.rd.PrintToPrinter(1, false, 1, 1);
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Are you sure", "Print", MessageBoxButtons.YesNo))
        return;
      this.rd.PrintOptions.CustomPaperSource.RawKind = new PrintDocument().PrinterSettings.PaperSources[0].RawKind;
      this.rd.PrintToPrinter(1, false, 1, 1);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.tbxBillNumber = new TextBox();
      this.listBox1 = new ListBox();
      this.dgvPledge = new DataGridView();
      this.cbTokanPrintFormats = new ComboBox();
      this.btnPrint = new GlassButton();
      this.btnShow = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.headerPanel1 = new HeaderPanel();
      this.headerPanel2 = new HeaderPanel();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      ((ISupportInitialize) this.dgvPledge).BeginInit();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.SuspendLayout();
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((Control) this.crystalReportViewer1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Location = new Point(233, 8);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(771, 558);
      ((Control) this.crystalReportViewer1).TabIndex = 8;
      this.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
      this.tbxBillNumber.BackColor = Color.AliceBlue;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Dock = DockStyle.Fill;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 0);
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(222, 28);
      this.tbxBillNumber.TabIndex = 0;
      this.tbxBillNumber.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.KeyUp += new KeyEventHandler(this.tbxBillNumber_KeyUp);
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.Font = new Font("Consolas", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.listBox1.ForeColor = SystemColors.MenuHighlight;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 24;
      this.listBox1.Location = new Point(0, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(223, 486);
      this.listBox1.TabIndex = 4;
      this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
      this.dgvPledge.AllowUserToAddRows = false;
      this.dgvPledge.AllowUserToDeleteRows = false;
      this.dgvPledge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvPledge.CellBorderStyle = DataGridViewCellBorderStyle.None;
      this.dgvPledge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPledge.Location = new Point(233, 58);
      this.dgvPledge.Name = "dgvPledge";
      this.dgvPledge.ReadOnly = true;
      this.dgvPledge.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvPledge.Size = new Size(763, 315);
      this.dgvPledge.TabIndex = 5;
      this.dgvPledge.Visible = false;
      this.dgvPledge.CellContentClick += new DataGridViewCellEventHandler(this.dgvPledge_CellContentClick);
      this.dgvPledge.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvPledge_CellPainting);
      this.dgvPledge.KeyDown += new KeyEventHandler(this.dgvPledge_KeyDown);
      this.dgvPledge.KeyPress += new KeyPressEventHandler(this.dgvPledge_KeyPress);
      this.dgvPledge.KeyUp += new KeyEventHandler(this.dgvPledge_KeyUp);
      this.cbTokanPrintFormats.BackColor = Color.AliceBlue;
      this.cbTokanPrintFormats.Dock = DockStyle.Fill;
      this.cbTokanPrintFormats.DropDownWidth = 450;
      this.cbTokanPrintFormats.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbTokanPrintFormats.FormattingEnabled = true;
      this.cbTokanPrintFormats.Location = new Point(0, 0);
      this.cbTokanPrintFormats.Name = "cbTokanPrintFormats";
      this.cbTokanPrintFormats.Size = new Size(538, 28);
      this.cbTokanPrintFormats.TabIndex = 1;
      this.cbTokanPrintFormats.KeyPress += new KeyPressEventHandler(this.cbTokanPrintFormats_KeyPress);
      ((Control) this.btnPrint).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      ((Control) this.btnPrint).Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrint.GlowColor = Color.White;
      ((ButtonBase) this.btnPrint).Image = (Image) PawnManagement.Properties.Resources.PRINT;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(891, 577);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(110, 29);
      ((Control) this.btnPrint).TabIndex = 3;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((ButtonBase) this.btnPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrint).Click += new EventHandler(this.btnPrint_Click);
      ((Control) this.btnShow).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnShow.BackColor = Color.LightBlue;
      this.btnShow.FadeOnFocus = true;
      ((Control) this.btnShow).Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnShow.ForeColor = Color.MediumBlue;
      this.btnShow.ForeColorOnFocus = Color.Red;
      this.btnShow.ForeColorOnLeave = Color.RoyalBlue;
      this.btnShow.GlowColor = Color.White;
      ((ButtonBase) this.btnShow).Image = (Image) PawnManagement.Properties.Resources.SEARCHGLASS2525;
      this.btnShow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnShow).Location = new Point(778, 577);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(110, 29);
      ((Control) this.btnShow).TabIndex = 2;
      ((Control) this.btnShow).Text = "&SHOW";
      ((ButtonBase) this.btnShow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnShow).Click += new EventHandler(this.btnShow_Click);
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
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
      ((Control) this.headerPanel6).Location = new Point(2, 114);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(225, 510);
      ((Control) this.headerPanel6).TabIndex = 9;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
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
      ((Control) this.headerPanel1).Location = new Point(3, 58);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(224, 52);
      ((Control) this.headerPanel1).TabIndex = 10;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "PRINT";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbTokanPrintFormats);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(232, 572);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(540, 52);
      ((Control) this.headerPanel2).TabIndex = 11;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
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
      ((Control) this.headerPanel7).Location = new Point(4, 8);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(223, 47);
      ((Control) this.headerPanel7).TabIndex = 78;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(221, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
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
      ((Control) this.glassButton8).Location = new Point(-80, 513);
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
      ((Control) this.glassButton9).Location = new Point(54, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 626);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.dgvPledge);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.btnShow);
      this.Controls.Add((Control) this.crystalReportViewer1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormToken);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Token";
      this.Load += new EventHandler(this.Token_Load);
      ((ISupportInitialize) this.dgvPledge).EndInit();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
