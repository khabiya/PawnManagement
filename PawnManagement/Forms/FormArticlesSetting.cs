
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
  public class FormArticlesSetting : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private GlassButton glassButton1;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton22;
    private GlassButton glassButton23;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton20;
    private GlassButton glassButton21;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton18;
    private GlassButton glassButton19;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton16;
    private GlassButton glassButton17;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private ComboBox cbPledgeExpiringToday;
    private ComboBox cbBankInsideOutsideScreen;
    private ComboBox cbRedemptionReportsScreen;
    private ComboBox cbNoticeScreen;
    private ComboBox cbPledgeInLossScreen;
    private ComboBox cbLedgerScreen;
    private ComboBox cbPledgeReportsScreen;
    private ComboBox cbPledgeScreen;
    private ComboBox cbRemoveDuplicateCustomer;
    private ComboBox cbViewCustomersScreen;
    private ComboBox cbPledgeExpiringThisMonth;
    private HeaderPanel headerPanel12;
    private ComboBox cbAuctionReportsScreen;
    private GlassButton glassButton24;
    private GlassButton glassButton25;

    public FormArticlesSetting() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblArticlesSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Articlessettings.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form articlessettings.refreshgrid()");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["PledgeExpiringToday"] != null && dataTable2.Rows[0]["PledgeExpiringToday"].ToString() != "")
          this.cbPledgeExpiringToday.Text = this.getArticle(dataTable2.Rows[0]["PledgeExpiringToday"].ToString());
        if (dataTable2.Rows[0]["PledgeExpiringThisMonth"] != null && dataTable2.Rows[0]["PledgeExpiringThisMonth"].ToString() != "")
          this.cbPledgeExpiringThisMonth.Text = this.getArticle(dataTable2.Rows[0]["PledgeExpiringThisMonth"].ToString());
        if (dataTable2.Rows[0]["ViewCustomersScreen"] != null && dataTable2.Rows[0]["ViewCustomersScreen"].ToString() != "")
          this.cbViewCustomersScreen.Text = this.getArticle(dataTable2.Rows[0]["ViewCustomersScreen"].ToString());
        if (dataTable2.Rows[0]["RemoveDuplicateCustomerScreen"] != null && dataTable2.Rows[0]["RemoveDuplicateCustomerScreen"].ToString() != "")
          this.cbRemoveDuplicateCustomer.Text = this.getArticle(dataTable2.Rows[0]["RemoveDuplicateCustomerScreen"].ToString());
        if (dataTable2.Rows[0]["PledgeScreen"] != null && dataTable2.Rows[0]["PledgeScreen"].ToString() != "")
          this.cbPledgeScreen.Text = this.getArticle(dataTable2.Rows[0]["PledgeScreen"].ToString());
        if (dataTable2.Rows[0]["PledgeReportsScreen"] != null && dataTable2.Rows[0]["PledgeReportsScreen"].ToString() != "")
          this.cbPledgeReportsScreen.Text = this.getArticle(dataTable2.Rows[0]["PledgeReportsScreen"].ToString());
        if (dataTable2.Rows[0]["LedgerScreen"] != null && dataTable2.Rows[0]["LedgerScreen"].ToString() != "")
          this.cbLedgerScreen.Text = this.getArticle(dataTable2.Rows[0]["LedgerScreen"].ToString());
        if (dataTable2.Rows[0]["PledgeInLossScreen"] != null && dataTable2.Rows[0]["PledgeInLossScreen"].ToString() != "")
          this.cbPledgeInLossScreen.Text = this.getArticle(dataTable2.Rows[0]["PledgeInLossScreen"].ToString());
        if (dataTable2.Rows[0]["NoticeScreen"] != null && dataTable2.Rows[0]["NoticeScreen"].ToString() != "")
          this.cbNoticeScreen.Text = this.getArticle(dataTable2.Rows[0]["NoticeScreen"].ToString());
        if (dataTable2.Rows[0]["RedemptionReportsScreen"] != null && dataTable2.Rows[0]["RedemptionReportsScreen"].ToString() != "")
          this.cbRedemptionReportsScreen.Text = this.getArticle(dataTable2.Rows[0]["RedemptionReportsScreen"].ToString());
        if (dataTable2.Rows[0]["AuctionReportsScreen"] != null && dataTable2.Rows[0]["AuctionReportsScreen"].ToString() != "")
          this.cbAuctionReportsScreen.Text = this.getArticle(dataTable2.Rows[0]["AuctionReportsScreen"].ToString());
        if (dataTable2.Rows[0]["BankInsideOutsideScreen"] != null && dataTable2.Rows[0]["BankInsideOutsideScreen"].ToString() != "")
          this.cbBankInsideOutsideScreen.Text = this.getArticle(dataTable2.Rows[0]["BankInsideOutsideScreen"].ToString());
      }
      else
        this.insertIntoTableArticles();
    }

    private void insertIntoTableArticles()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Insert into tblArticlesSETTINGS(PledgeExpiringtoday,pledgeexpiringthismonth,viewcustomersscreen,RemoveDuplicateCustomerScreen,pledgescreen,pledgereportsscreen,ledgerscreen,pledgeinlossscreen,noticescreen,redemptionreportsscreen,auctionreportsscreen,bankinsideoutsidescreen) values(@PledgeExpiringtoday,@pledgeexpiringthismonth,@viewcustomersscreen,@RemoveDuplicateCustomerScreen,@pledgescreen,@pledgereportsscreen,@ledgerscreen,@pledgeinlossscreen,@noticescreen,@redemptionreportsscreen,@auctionreportsscreen,@bankinsideoutsidescreen)", new List<OleDbParameter>()
      {
        new OleDbParameter("PledgeExpiringToday", (object) "Articles"),
        new OleDbParameter("PledgeExpiringThisMonth", (object) "Articles"),
        new OleDbParameter("ViewCustomersScreen", (object) "Articles"),
        new OleDbParameter("RemoveDuplicateCustomerScreen", (object) "Articles"),
        new OleDbParameter("PledgeScreen", (object) "Articles"),
        new OleDbParameter("PledgeReportsScreen", (object) "Articles"),
        new OleDbParameter("LedgerScreen", (object) "Articles"),
        new OleDbParameter("PledgeInLossScreen", (object) "Articles"),
        new OleDbParameter("NoticeScreen", (object) "Articles"),
        new OleDbParameter("RedemptionReportsScreen", (object) "Articles"),
        new OleDbParameter("AuctionREportsScreen", (object) "Articles"),
        new OleDbParameter("BankInsideOutsideScreen", (object) "Articles")
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Successfully Updated");
    }

    private string getArticle(string str)
    {
      switch (str)
      {
        case "Articles":
          return "ARTICLESWITHOUTINDIVIDUALWEIGHT";
        case "ArticlesWithoutHr":
          return "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS";
        case "ArticlesWithHr":
          return "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS";
        default:
          return "ARTICLESWITHOUTINDIVIDUALWEIGHT";
      }
    }

    private string getArticleFromComboBox(string str)
    {
      switch (str)
      {
        case "ARTICLESWITHOUTINDIVIDUALWEIGHT":
          return "Articles";
        case "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS":
          return "ArticlesWithoutHr";
        case "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS":
          return "ArticlesWithHr";
        default:
          return "Articles";
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormArticlesSetting_Load(object sender, EventArgs e) => this.refreshGrid();

    private void glassButton1_Click(object sender, EventArgs e)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblArticlesSettings set PledgeExpiringToday=@PledgeExpiringToday,PledgeExpiringThisMonth=@PledgeExpiringThisMonth,ViewCustomersScreen=@ViewCustomersScreen,RemoveDuplicateCustomerScreen=@RemoveDuplicateCustomerScreen,PledgeScreen=@PledgeScreen,PledgeReportsScreen=@PledgeReportsScreen,LedgerScreen=@LedgerScreen,PledgeInLossScreen=@PledgeInLossScreen,NoticeScreen=@NoticeScreen,RedemptionReportsScreen=@RedemptionReportsScreen,AuctionReportsScreen=@AuctionReportsScreen,BankInsideOutsideScreen=@BankInsideOutsideScreen", new List<OleDbParameter>()
      {
        new OleDbParameter("PledgeExpiringToday", (object) this.getArticleFromComboBox(this.cbPledgeExpiringToday.Text)),
        new OleDbParameter("PledgeExpiringThisMonth", (object) this.getArticleFromComboBox(this.cbPledgeExpiringThisMonth.Text)),
        new OleDbParameter("ViewCustomersScreen", (object) this.getArticleFromComboBox(this.cbViewCustomersScreen.Text)),
        new OleDbParameter("RemoveDuplicateCustomerScreen", (object) this.getArticleFromComboBox(this.cbRemoveDuplicateCustomer.Text)),
        new OleDbParameter("PledgeScreen", (object) this.getArticleFromComboBox(this.cbPledgeScreen.Text)),
        new OleDbParameter("PledgeReportsScreen", (object) this.getArticleFromComboBox(this.cbPledgeReportsScreen.Text)),
        new OleDbParameter("LedgerScreen", (object) this.getArticleFromComboBox(this.cbLedgerScreen.Text)),
        new OleDbParameter("PledgeInLoss", (object) this.getArticleFromComboBox(this.cbPledgeInLossScreen.Text)),
        new OleDbParameter("NoticeScreen", (object) this.getArticleFromComboBox(this.cbNoticeScreen.Text)),
        new OleDbParameter("RedemptionReportsScreen", (object) this.getArticleFromComboBox(this.cbRedemptionReportsScreen.Text)),
        new OleDbParameter("AuctionReportsScreen", (object) this.getArticleFromComboBox(this.cbAuctionReportsScreen.Text)),
        new OleDbParameter("BankInsideOutsideScreen", (object) this.getArticleFromComboBox(this.cbBankInsideOutsideScreen.Text))
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Successfull updated");
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
      this.headerPanel12 = new HeaderPanel();
      this.cbAuctionReportsScreen = new ComboBox();
      this.glassButton24 = new GlassButton();
      this.glassButton25 = new GlassButton();
      this.headerPanel11 = new HeaderPanel();
      this.cbBankInsideOutsideScreen = new ComboBox();
      this.glassButton22 = new GlassButton();
      this.glassButton23 = new GlassButton();
      this.headerPanel10 = new HeaderPanel();
      this.cbRedemptionReportsScreen = new ComboBox();
      this.glassButton20 = new GlassButton();
      this.glassButton21 = new GlassButton();
      this.headerPanel9 = new HeaderPanel();
      this.cbNoticeScreen = new ComboBox();
      this.glassButton18 = new GlassButton();
      this.glassButton19 = new GlassButton();
      this.headerPanel8 = new HeaderPanel();
      this.cbPledgeInLossScreen = new ComboBox();
      this.glassButton16 = new GlassButton();
      this.glassButton17 = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.cbLedgerScreen = new ComboBox();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.cbPledgeReportsScreen = new ComboBox();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.cbPledgeScreen = new ComboBox();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.cbRemoveDuplicateCustomer = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.cbViewCustomersScreen = new ComboBox();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.cbPledgeExpiringThisMonth = new ComboBox();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.cbPledgeExpiringToday = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel12).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      ((Control) this.headerPanel9).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
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
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(1069, 399);
      this.tableLayoutPanel1.TabIndex = 14;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1063, 31);
      this.panel2.TabIndex = 9;
      this.label7.Anchor = AnchorStyles.Top;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkBlue;
      this.label7.Location = new Point(398, -5);
      this.label7.Name = "label7";
      this.label7.Size = new Size(263, 37);
      this.label7.TabIndex = 10;
      this.label7.Text = "ARTICLES SETTINGS";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.headerPanel12);
      this.panel3.Controls.Add((Control) this.headerPanel11);
      this.panel3.Controls.Add((Control) this.headerPanel10);
      this.panel3.Controls.Add((Control) this.headerPanel9);
      this.panel3.Controls.Add((Control) this.headerPanel8);
      this.panel3.Controls.Add((Control) this.headerPanel7);
      this.panel3.Controls.Add((Control) this.headerPanel6);
      this.panel3.Controls.Add((Control) this.headerPanel5);
      this.panel3.Controls.Add((Control) this.headerPanel4);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 40);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1063, 356);
      this.panel3.TabIndex = 11;
      ((Control) this.headerPanel12).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel12).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel12).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel12.BorderColor = SystemColors.HotTrack;
      this.headerPanel12.BorderStyle = BorderStyles.Single;
      this.headerPanel12.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel12.CaptionEndColor = Color.AliceBlue;
      this.headerPanel12.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.CaptionHeight = 22;
      this.headerPanel12.CaptionPosition = CaptionPositions.Top;
      this.headerPanel12.CaptionText = "AUCTION REPORTS SCREEN";
      this.headerPanel12.CaptionVisible = true;
      ((Control) this.headerPanel12).Controls.Add((Control) this.cbAuctionReportsScreen);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton25);
      ((Control) this.headerPanel12).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel12).ForeColor = Color.DarkBlue;
      this.headerPanel12.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.GradientEnd = Color.Azure;
      this.headerPanel12.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel12).Location = new Point(532, 211);
      ((Control) this.headerPanel12).Name = "headerPanel12";
      this.headerPanel12.PanelIcon = (Icon) null;
      this.headerPanel12.PanelIconVisible = false;
      ((Control) this.headerPanel12).Size = new Size(518, 48);
      ((Control) this.headerPanel12).TabIndex = 83;
      this.headerPanel12.TextAntialias = true;
      this.cbAuctionReportsScreen.BackColor = Color.AliceBlue;
      this.cbAuctionReportsScreen.Dock = DockStyle.Fill;
      this.cbAuctionReportsScreen.DropDownWidth = 600;
      this.cbAuctionReportsScreen.FormattingEnabled = true;
      this.cbAuctionReportsScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbAuctionReportsScreen.Location = new Point(0, 0);
      this.cbAuctionReportsScreen.Name = "cbAuctionReportsScreen";
      this.cbAuctionReportsScreen.Size = new Size(516, 23);
      this.cbAuctionReportsScreen.TabIndex = 24;
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
      ((Control) this.glassButton24).Location = new Point(221, 513);
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
      ((Control) this.glassButton25).Location = new Point(355, 512);
      ((Control) this.glassButton25).Name = "glassButton25";
      this.glassButton25.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton25.ShineColor = Color.Transparent;
      ((Control) this.glassButton25).Size = new Size(123, 37);
      ((Control) this.glassButton25).TabIndex = 1;
      ((Control) this.glassButton25).Text = "&EXIT";
      ((ButtonBase) this.glassButton25).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel11).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel11).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.HotTrack;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel11.CaptionEndColor = Color.AliceBlue;
      this.headerPanel11.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "BANK INSIDE OUTSIDE SCREEN";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.cbBankInsideOutsideScreen);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton22);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton23);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = Color.Azure;
      this.headerPanel11.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel11).Location = new Point(532, 263);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(518, 48);
      ((Control) this.headerPanel11).TabIndex = 88;
      this.headerPanel11.TextAntialias = true;
      this.cbBankInsideOutsideScreen.BackColor = Color.AliceBlue;
      this.cbBankInsideOutsideScreen.Dock = DockStyle.Fill;
      this.cbBankInsideOutsideScreen.DropDownWidth = 600;
      this.cbBankInsideOutsideScreen.FormattingEnabled = true;
      this.cbBankInsideOutsideScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbBankInsideOutsideScreen.Location = new Point(0, 0);
      this.cbBankInsideOutsideScreen.Name = "cbBankInsideOutsideScreen";
      this.cbBankInsideOutsideScreen.Size = new Size(516, 23);
      this.cbBankInsideOutsideScreen.TabIndex = 24;
      ((Control) this.glassButton22).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton22.BackColor = Color.LightBlue;
      this.glassButton22.FadeOnFocus = true;
      ((Control) this.glassButton22).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton22.ForeColor = Color.MediumBlue;
      this.glassButton22.ForeColorOnFocus = Color.Red;
      this.glassButton22.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton22.GlowColor = Color.White;
      ((ButtonBase) this.glassButton22).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton22.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton22).Location = new Point(223, 513);
      ((Control) this.glassButton22).Name = "glassButton22";
      this.glassButton22.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton22.ShineColor = Color.Transparent;
      ((Control) this.glassButton22).Size = new Size(128, 35);
      ((Control) this.glassButton22).TabIndex = 0;
      ((Control) this.glassButton22).Text = "&SAVE";
      ((ButtonBase) this.glassButton22).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton23).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton23.BackColor = Color.LightBlue;
      this.glassButton23.FadeOnFocus = true;
      ((Control) this.glassButton23).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton23.ForeColor = Color.MediumBlue;
      this.glassButton23.ForeColorOnFocus = Color.Red;
      this.glassButton23.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton23.GlowColor = Color.White;
      this.glassButton23.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton23).Location = new Point(357, 512);
      ((Control) this.glassButton23).Name = "glassButton23";
      this.glassButton23.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton23.ShineColor = Color.Transparent;
      ((Control) this.glassButton23).Size = new Size(123, 37);
      ((Control) this.glassButton23).TabIndex = 1;
      ((Control) this.glassButton23).Text = "&EXIT";
      ((ButtonBase) this.glassButton23).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel10).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel10).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.HotTrack;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel10.CaptionEndColor = Color.AliceBlue;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "REDEMPTION REPORTS SCREEN";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.cbRedemptionReportsScreen);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = Color.Azure;
      this.headerPanel10.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel10).Location = new Point(532, 159);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(518, 48);
      ((Control) this.headerPanel10).TabIndex = 87;
      this.headerPanel10.TextAntialias = true;
      this.cbRedemptionReportsScreen.BackColor = Color.AliceBlue;
      this.cbRedemptionReportsScreen.Dock = DockStyle.Fill;
      this.cbRedemptionReportsScreen.DropDownWidth = 600;
      this.cbRedemptionReportsScreen.FormattingEnabled = true;
      this.cbRedemptionReportsScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbRedemptionReportsScreen.Location = new Point(0, 0);
      this.cbRedemptionReportsScreen.Name = "cbRedemptionReportsScreen";
      this.cbRedemptionReportsScreen.Size = new Size(516, 23);
      this.cbRedemptionReportsScreen.TabIndex = 24;
      ((Control) this.glassButton20).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton20.BackColor = Color.LightBlue;
      this.glassButton20.FadeOnFocus = true;
      ((Control) this.glassButton20).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton20.ForeColor = Color.MediumBlue;
      this.glassButton20.ForeColorOnFocus = Color.Red;
      this.glassButton20.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton20.GlowColor = Color.White;
      ((ButtonBase) this.glassButton20).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton20.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton20).Location = new Point(223, 513);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(128, 35);
      ((Control) this.glassButton20).TabIndex = 0;
      ((Control) this.glassButton20).Text = "&SAVE";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton21).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton21.BackColor = Color.LightBlue;
      this.glassButton21.FadeOnFocus = true;
      ((Control) this.glassButton21).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton21.ForeColor = Color.MediumBlue;
      this.glassButton21.ForeColorOnFocus = Color.Red;
      this.glassButton21.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton21.GlowColor = Color.White;
      this.glassButton21.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton21).Location = new Point(357, 512);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(123, 37);
      ((Control) this.glassButton21).TabIndex = 1;
      ((Control) this.glassButton21).Text = "&EXIT";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel9).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel9).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.HotTrack;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel9.CaptionEndColor = Color.AliceBlue;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "NOTICE SCREEN";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbNoticeScreen);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = Color.Azure;
      this.headerPanel9.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel9).Location = new Point(532, 107);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(518, 48);
      ((Control) this.headerPanel9).TabIndex = 86;
      this.headerPanel9.TextAntialias = true;
      this.cbNoticeScreen.BackColor = Color.AliceBlue;
      this.cbNoticeScreen.Dock = DockStyle.Fill;
      this.cbNoticeScreen.DropDownWidth = 600;
      this.cbNoticeScreen.FormattingEnabled = true;
      this.cbNoticeScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbNoticeScreen.Location = new Point(0, 0);
      this.cbNoticeScreen.Name = "cbNoticeScreen";
      this.cbNoticeScreen.Size = new Size(516, 23);
      this.cbNoticeScreen.TabIndex = 24;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      ((ButtonBase) this.glassButton18).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(223, 513);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(128, 35);
      ((Control) this.glassButton18).TabIndex = 0;
      ((Control) this.glassButton18).Text = "&SAVE";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton19).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      ((Control) this.glassButton19).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(357, 512);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(123, 37);
      ((Control) this.glassButton19).TabIndex = 1;
      ((Control) this.glassButton19).Text = "&EXIT";
      ((ButtonBase) this.glassButton19).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel8.CaptionText = "PLEDGE IN LOSS SCREEN";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbPledgeInLossScreen);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = Color.Azure;
      this.headerPanel8.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel8).Location = new Point(532, 55);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(518, 48);
      ((Control) this.headerPanel8).TabIndex = 85;
      this.headerPanel8.TextAntialias = true;
      this.cbPledgeInLossScreen.BackColor = Color.AliceBlue;
      this.cbPledgeInLossScreen.Dock = DockStyle.Fill;
      this.cbPledgeInLossScreen.DropDownWidth = 600;
      this.cbPledgeInLossScreen.FormattingEnabled = true;
      this.cbPledgeInLossScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbPledgeInLossScreen.Location = new Point(0, 0);
      this.cbPledgeInLossScreen.Name = "cbPledgeInLossScreen";
      this.cbPledgeInLossScreen.Size = new Size(516, 23);
      this.cbPledgeInLossScreen.TabIndex = 24;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      ((ButtonBase) this.glassButton16).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(223, 513);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(128, 35);
      ((Control) this.glassButton16).TabIndex = 0;
      ((Control) this.glassButton16).Text = "&SAVE";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(357, 512);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(123, 37);
      ((Control) this.glassButton17).TabIndex = 1;
      ((Control) this.glassButton17).Text = "&EXIT";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel7.CaptionText = "LEDGER SCREEN";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbLedgerScreen);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = Color.Azure;
      this.headerPanel7.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel7).Location = new Point(532, 3);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(518, 48);
      ((Control) this.headerPanel7).TabIndex = 84;
      this.headerPanel7.TextAntialias = true;
      this.cbLedgerScreen.BackColor = Color.AliceBlue;
      this.cbLedgerScreen.Dock = DockStyle.Fill;
      this.cbLedgerScreen.DropDownWidth = 600;
      this.cbLedgerScreen.FormattingEnabled = true;
      this.cbLedgerScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbLedgerScreen.Location = new Point(0, 0);
      this.cbLedgerScreen.Name = "cbLedgerScreen";
      this.cbLedgerScreen.Size = new Size(516, 23);
      this.cbLedgerScreen.TabIndex = 24;
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
      ((Control) this.glassButton14).Location = new Point(223, 513);
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
      ((Control) this.glassButton15).Location = new Point(357, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel6.CaptionText = "PLEDGE REPORTS SCREEN";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.cbPledgeReportsScreen);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = Color.Azure;
      this.headerPanel6.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel6).Location = new Point(9, 263);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(518, 48);
      ((Control) this.headerPanel6).TabIndex = 83;
      this.headerPanel6.TextAntialias = true;
      this.cbPledgeReportsScreen.BackColor = Color.AliceBlue;
      this.cbPledgeReportsScreen.Dock = DockStyle.Fill;
      this.cbPledgeReportsScreen.DropDownWidth = 600;
      this.cbPledgeReportsScreen.FormattingEnabled = true;
      this.cbPledgeReportsScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbPledgeReportsScreen.Location = new Point(0, 0);
      this.cbPledgeReportsScreen.Name = "cbPledgeReportsScreen";
      this.cbPledgeReportsScreen.Size = new Size(516, 23);
      this.cbPledgeReportsScreen.TabIndex = 24;
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
      ((Control) this.glassButton12).Location = new Point(223, 513);
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
      ((Control) this.glassButton13).Location = new Point(357, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel5.CaptionText = "PLEDGE SCREEN";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.cbPledgeScreen);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = Color.Azure;
      this.headerPanel5.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel5).Location = new Point(9, 211);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(518, 48);
      ((Control) this.headerPanel5).TabIndex = 82;
      this.headerPanel5.TextAntialias = true;
      this.cbPledgeScreen.BackColor = Color.AliceBlue;
      this.cbPledgeScreen.Dock = DockStyle.Fill;
      this.cbPledgeScreen.DropDownWidth = 600;
      this.cbPledgeScreen.FormattingEnabled = true;
      this.cbPledgeScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbPledgeScreen.Location = new Point(0, 0);
      this.cbPledgeScreen.Name = "cbPledgeScreen";
      this.cbPledgeScreen.Size = new Size(516, 23);
      this.cbPledgeScreen.TabIndex = 24;
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
      ((Control) this.glassButton10).Location = new Point(223, 513);
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
      ((Control) this.glassButton11).Location = new Point(357, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel4.CaptionText = "REMOVE DUPLICATE CUSTOMER";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbRemoveDuplicateCustomer);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = Color.Azure;
      this.headerPanel4.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel4).Location = new Point(9, 159);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(518, 48);
      ((Control) this.headerPanel4).TabIndex = 81;
      this.headerPanel4.TextAntialias = true;
      this.cbRemoveDuplicateCustomer.BackColor = Color.AliceBlue;
      this.cbRemoveDuplicateCustomer.Dock = DockStyle.Fill;
      this.cbRemoveDuplicateCustomer.DropDownWidth = 600;
      this.cbRemoveDuplicateCustomer.FormattingEnabled = true;
      this.cbRemoveDuplicateCustomer.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbRemoveDuplicateCustomer.Location = new Point(0, 0);
      this.cbRemoveDuplicateCustomer.Name = "cbRemoveDuplicateCustomer";
      this.cbRemoveDuplicateCustomer.Size = new Size(516, 23);
      this.cbRemoveDuplicateCustomer.TabIndex = 24;
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
      ((Control) this.glassButton8).Location = new Point(223, 513);
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
      ((Control) this.glassButton9).Location = new Point(357, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel2.CaptionText = "VIEW CUSTOMERS SCREEN";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbViewCustomersScreen);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(9, 107);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(518, 48);
      ((Control) this.headerPanel2).TabIndex = 80;
      this.headerPanel2.TextAntialias = true;
      this.cbViewCustomersScreen.BackColor = Color.AliceBlue;
      this.cbViewCustomersScreen.Dock = DockStyle.Fill;
      this.cbViewCustomersScreen.DropDownWidth = 600;
      this.cbViewCustomersScreen.FormattingEnabled = true;
      this.cbViewCustomersScreen.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbViewCustomersScreen.Location = new Point(0, 0);
      this.cbViewCustomersScreen.Name = "cbViewCustomersScreen";
      this.cbViewCustomersScreen.Size = new Size(516, 23);
      this.cbViewCustomersScreen.TabIndex = 24;
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
      ((Control) this.glassButton6).Location = new Point(223, 513);
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
      ((Control) this.glassButton7).Location = new Point(357, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
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
      this.headerPanel1.CaptionText = "PLEDGE EXPIRING THIS MONTH";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbPledgeExpiringThisMonth);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(9, 55);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(518, 48);
      ((Control) this.headerPanel1).TabIndex = 79;
      this.headerPanel1.TextAntialias = true;
      this.cbPledgeExpiringThisMonth.BackColor = Color.AliceBlue;
      this.cbPledgeExpiringThisMonth.Dock = DockStyle.Fill;
      this.cbPledgeExpiringThisMonth.DropDownWidth = 600;
      this.cbPledgeExpiringThisMonth.FormattingEnabled = true;
      this.cbPledgeExpiringThisMonth.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbPledgeExpiringThisMonth.Location = new Point(0, 0);
      this.cbPledgeExpiringThisMonth.Name = "cbPledgeExpiringThisMonth";
      this.cbPledgeExpiringThisMonth.Size = new Size(516, 23);
      this.cbPledgeExpiringThisMonth.TabIndex = 24;
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
      ((Control) this.glassButton2).Location = new Point(223, 513);
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
      ((Control) this.glassButton3).Location = new Point(357, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel3.CaptionText = "PLEDGE EXPIRING TODAY";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.cbPledgeExpiringToday);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(9, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(518, 48);
      ((Control) this.headerPanel3).TabIndex = 78;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton4).Location = new Point(225, 513);
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
      ((Control) this.glassButton5).Location = new Point(359, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbPledgeExpiringToday.BackColor = Color.AliceBlue;
      this.cbPledgeExpiringToday.Dock = DockStyle.Fill;
      this.cbPledgeExpiringToday.DropDownWidth = 600;
      this.cbPledgeExpiringToday.FormattingEnabled = true;
      this.cbPledgeExpiringToday.Items.AddRange(new object[3]
      {
        (object) "ARTICLESWITHOUTINDIVIDUALWEIGHT",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHHIDDENREMARKS",
        (object) "ARTICLESWITHINDIVIDUALWEIGHTWITHOUTHIDDENREMARKS"
      });
      this.cbPledgeExpiringToday.Location = new Point(0, 0);
      this.cbPledgeExpiringToday.Name = "cbPledgeExpiringToday";
      this.cbPledgeExpiringToday.Size = new Size(516, 23);
      this.cbPledgeExpiringToday.TabIndex = 23;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(974, 317);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(75, 29);
      ((Control) this.glassButton1).TabIndex = 17;
      ((Control) this.glassButton1).Text = "&Save";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1069, 399);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormArticlesSetting);
      this.Text = nameof (FormArticlesSetting);
      this.Load += new EventHandler(this.FormArticlesSetting_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel12).ResumeLayout(false);
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
