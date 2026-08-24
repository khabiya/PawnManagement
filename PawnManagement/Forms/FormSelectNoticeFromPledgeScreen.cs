
using CrystalDecisions.CrystalReports.Engine;
using CSharpCustomPanelControl;
using Glass;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormSelectNoticeFromPledgeScreen : Form
  {
    private bool noticeClickedOnce = false;
    private DataTable dtPrintNotice = new DataTable();
    private IContainer components = (IContainer) null;
    private CustomPanel customPanel6;
    private TextBox textBox6;
    private Label label6;
    private CustomPanel customPanel1;
    private ComboBox cbNoticeType;
    private Label label1;
    private GlassButton btnPrint;
    private DataGridView dataGridView1;

    public FormSelectNoticeFromPledgeScreen() => this.InitializeComponent();

    public FormSelectNoticeFromPledgeScreen(DataGridView DGV)
    {
      this.dataGridView1 = DGV;
      this.InitializeComponent();
    }

    private void FormSelectNoticeFromPledgeScreen_Load(object sender, EventArgs e)
    {
      this.getReportTypes();
      if (this.cbNoticeType.Items.Count <= 0)
        return;
      this.cbNoticeType.SelectedIndex = 0;
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Notice\\\\", "*.rpt"))
        this.cbNoticeType.Items.Add(file);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      if (!this.noticeClickedOnce)
      {
        this.getDatatabledt();
        this.noticeClickedOnce = true;
      }
      this.getdatatabledtdataNotice();
      PawnManagementClass.InsertIntoHistory("NOTICE PRINT", "NOTICE printed", "", "", FormMain.username, DateTime.Now.ToString());
      DataTable shopDetails = PawnManagementClass.getShopDetails(PawnManagementClass.getDefaultLicenseCode());
      ReportDocument RD = new ReportDocument();
      RD.Load(this.cbNoticeType.Text);
      RD.SetDataSource(this.dtPrintNotice);
      if (!this.cbNoticeType.Text.Contains("Final"))
        RD.Subreports["ShopNameAndAddressHeading"].SetDataSource(shopDetails);
      RD.Subreports["ShopNameAndAddressBottom"].SetDataSource(shopDetails);
      DataTable detailsForNotice = this.getCustomerDetailsForNotice();
      foreach (DataRow row in (InternalDataCollectionBase) detailsForNotice.Rows)
        row["CImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + row["CID"].ToString() + ".png");
      RD.Subreports["ToAddress"].SetDataSource(detailsForNotice);
      new FormCrystalReportViewer(RD).Show();
    }

    private void getDatatabledt()
    {
      this.dtPrintNotice.Columns.Add("BillNumber", typeof (string));
      this.dtPrintNotice.Columns.Add("BillDate", typeof (DateTime));
      this.dtPrintNotice.Columns.Add("CustomerCode", typeof (string));
      this.dtPrintNotice.Columns.Add("CustomerNameAndAddress", typeof (string));
      this.dtPrintNotice.Columns.Add("amount", typeof (int));
      this.dtPrintNotice.Columns.Add("NetWeight", typeof (double));
      this.dtPrintNotice.Columns.Add("PresentValue", typeof (string));
      this.dtPrintNotice.Columns.Add("Articles", typeof (string));
      this.dtPrintNotice.Columns.Add("PblNumber", typeof (string));
      this.dtPrintNotice.Columns.Add("AuctionDate", typeof (DateTime));
      this.dtPrintNotice.Columns.Add("KdisNumber", typeof (string));
      this.dtPrintNotice.Columns.Add("PhoneNumber", typeof (string));
      this.dtPrintNotice.Columns.Add("NoticeType", typeof (string));
    }

    private void getdatatabledtdataNotice()
    {
      this.dtPrintNotice.Rows.Clear();
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["colSelect"].Value != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
        {
          string str1 = row.Cells["BillNumber"].Value.ToString();
          DateTime dateTime = DateTime.Parse(row.Cells["BillDate"].Value.ToString());
          string str2 = row.Cells["CustomerCode"].Value.ToString();
          string str3 = row.Cells["nameAndAddress"].Value.ToString();
          string str4 = row.Cells["amount"].Value.ToString();
          string str5 = row.Cells["netweight"].Value.ToString();
          string str6 = row.Cells["presentvalue"].Value.ToString();
          string str7 = row.Cells["articles"].Value.ToString();
          string str8 = "";
          DateTime now = DateTime.Now;
          string str9 = "";
          string str10 = row.Cells["Phonenumber"].Value.ToString();
          string str11 = "";
          row.Cells["nameAndAddress"].Value.ToString();
          this.dtPrintNotice.Rows.Add((object) str1, (object) dateTime, (object) str2, (object) str3, (object) str4, (object) str5, (object) str6, (object) str7, (object) str8, (object) now, (object) str9, (object) str10, (object) str11);
        }
      }
    }

    private DataTable getCustomerDetailsForNotice()
    {
      string strError = "";
      string my_querry = "select * from tblcustomers";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
      }
      return dataTable2;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.customPanel6 = new CustomPanel();
      this.textBox6 = new TextBox();
      this.label6 = new Label();
      this.customPanel1 = new CustomPanel();
      this.cbNoticeType = new ComboBox();
      this.label1 = new Label();
      this.btnPrint = new GlassButton();
      this.dataGridView1 = new DataGridView();
      ((Control) this.customPanel6).SuspendLayout();
      ((Control) this.customPanel1).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.customPanel6.BackColor = SystemColors.Info;
      this.customPanel6.BackColor2 = SystemColors.Info;
      this.customPanel6.BorderColor = Color.Sienna;
      this.customPanel6.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel6).Controls.Add((Control) this.textBox6);
      ((Control) this.customPanel6).Controls.Add((Control) this.label6);
      this.customPanel6.Curvature = 5;
      this.customPanel6.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel6).Location = new Point(12, 12);
      ((Control) this.customPanel6).Name = "customPanel6";
      ((Control) this.customPanel6).Size = new Size(407, 69);
      ((Control) this.customPanel6).TabIndex = 3;
      this.textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox6.BackColor = SystemColors.Info;
      this.textBox6.BorderStyle = BorderStyle.None;
      this.textBox6.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox6.Location = new Point(2, 29);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size(404, 37);
      this.textBox6.TabIndex = 3;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(2, 3);
      this.label6.Name = "label6";
      this.label6.Size = new Size(70, 25);
      this.label6.TabIndex = 2;
      this.label6.Text = "label6";
      this.customPanel1.BackColor = SystemColors.Info;
      this.customPanel1.BackColor2 = SystemColors.Info;
      this.customPanel1.BorderColor = Color.Sienna;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.cbNoticeType);
      ((Control) this.customPanel1).Controls.Add((Control) this.label1);
      this.customPanel1.Curvature = 5;
      this.customPanel1.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(14, 84);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(407, 69);
      ((Control) this.customPanel1).TabIndex = 4;
      this.cbNoticeType.BackColor = SystemColors.Info;
      this.cbNoticeType.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeType.FormattingEnabled = true;
      this.cbNoticeType.Location = new Point(5, 32);
      this.cbNoticeType.Name = "cbNoticeType";
      this.cbNoticeType.Size = new Size(399, 33);
      this.cbNoticeType.TabIndex = 3;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(2, 3);
      this.label1.Name = "label1";
      this.label1.Size = new Size(70, 25);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.MediumBlue;
      this.btnPrint.GlowColor = Color.White;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(323, 160);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(75, 23);
      ((Control) this.btnPrint).TabIndex = 5;
      ((Control) this.btnPrint).Text = "glassButton1";
      ((Control) this.btnPrint).Click += new EventHandler(this.btnPrint_Click);
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(532, 52);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(240, 150);
      this.dataGridView1.TabIndex = 6;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(767, 262);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.customPanel1);
      this.Controls.Add((Control) this.customPanel6);
      this.Name = nameof (FormSelectNoticeFromPledgeScreen);
      this.Text = nameof (FormSelectNoticeFromPledgeScreen);
      this.Load += new EventHandler(this.FormSelectNoticeFromPledgeScreen_Load);
      ((Control) this.customPanel6).ResumeLayout(false);
      ((Control) this.customPanel6).PerformLayout();
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
