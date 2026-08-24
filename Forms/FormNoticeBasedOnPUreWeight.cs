

using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
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
using System.Text;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormNoticeBasedOnPUreWeight : Form
  {
    private bool calculateCompoundInterest = false;
    private bool smsclickedOnce = false;
    private bool noticeClickedOnce = false;
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LightBlueFadeDown.jpg");
    private DataTable dt = new DataTable();
    private DataTable dtLOAD = new DataTable();
    private ReportDocument rd = new ReportDocument();
    private double totalamount;
    private double totalInterest;
    private int i = 0;
    private string[] strcustomerCode = new string[4000];
    private string pblNumber = "";
    private List<string> strCustomerCodeNotice = new List<string>();
    private double totalWeightSilver;
    private double totalWeightGold;
    private double totalWeightOthers;
    private string InterestSetting = "";
    private IContainer components = (IContainer) null;
    private Label label10;
    private TextBox tbxAmountSilver;
    private TextBox tbxSalePriceSilver;
    private Label label8;
    private TextBox tbxSalePriceGold;
    private Label label7;
    private Label label9;
    private TextBox tbxAmountGold;
    private Timer timer1;
    private Label label11;
    private TextBox tbxNoticeType;
    private Label label14;
    private Label label13;
    private Label label12;
    private TextBox tbxKdisNo;
    private TextBox tbxAuctionDate;
    private TextBox tbxPblNo;
    private GlassButton button2;
    private TextBox tbxFromDate;
    private TextBox tbxToDate;
    private GlassButton btnDisplay;
    private Label label3;
    private ComboBox comboBox1;
    private Label label1;
    private Timer timer2;
    private DataGridView dgvNotice;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem cALLToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private PictureBox pictureBox1;
    private DataGridView dataGridView2;
    private Label label2;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel1;
    private HeaderPanel headerPanel3;
    private HeaderPanel headerPanel4;
    private ComboBox cbShopCodes;
    private Label label15;
    private ToolStripMenuItem selectAllToolStripMenuItem;
    private ToolStripMenuItem unSelectAllToolStripMenuItem;
    private ToolStripMenuItem sendSmsToolStripMenuItem;
    private Panel panel2;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton2;
    private ComboBox cbCustomerLabels;
    private GlassButton glassButton1;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton8;
    private ComboBox cbNoticeType;
    private GlassButton glassButton9;
    private GlassButton btnPrintNotice;
    private DataGridViewCheckBoxColumn select;
    private DataGridViewTextBoxColumn PhoneNumber;
    private DataGridViewTextBoxColumn ShopCode;
    private DataGridViewTextBoxColumn pledgeBillNumber;
    private DataGridViewTextBoxColumn pledgeBillDate;
    private DataGridViewTextBoxColumn customerCode;
    private DataGridViewTextBoxColumn nameAndAddress;
    private DataGridViewTextBoxColumn netWeight;
    private DataGridViewTextBoxColumn pureWeight;
    private DataGridViewTextBoxColumn amount;
    private DataGridViewTextBoxColumn value;
    private DataGridViewTextBoxColumn Articles;
    private DataGridViewTextBoxColumn InterestRate;
    private DataGridViewTextBoxColumn interest;
    private DataGridViewTextBoxColumn interestPlusPrincipal;
    private DataGridViewTextBoxColumn perGram;
    private DataGridViewTextBoxColumn type;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton4;
    private ComboBox cbNoticeRecords;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem setIntimationLetterSentToolStripMenuItem;
    private ToolStripMenuItem setAuctionLetterSentToolStripMenuItem;
    private HeaderPanel headerPanel8;
    private Label lblNoticeCharge;
    private TextBox tbxNoticeCharge;
    private Label label17;
    private ComboBox cbIntimationOrAuction;
    private Label label18;
    private ComboBox cbLanguage;
    private CheckBox cbIncludePhoto;
    private CheckBox cbIncludeAmountTotal;
    private CheckBox cbIncludeNetWeight;
    private CheckBox cbIncludeSameCustomer;

    public FormNoticeBasedOnPUreWeight() => this.InitializeComponent();

    private void FormNoticeBasedOnPUreWeight_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      if (this.cbShopCodes.Items.Count > 0)
        this.cbShopCodes.SelectedIndex = 0;
      this.cbShopCodes.Text = PawnManagementClass.getDefaultLicenseCode();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
      this.tbxFromDate.Text = DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["Billdate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxToDate.Text = DateTime.Parse(DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + (DateTime.Today.Year - 1).ToString()).ToString("dd/MM/yyyy");
      if (this.comboBox1.Items.Count == 4)
        this.comboBox1.SelectedIndex = 3;
      this.getPblNumber();
      this.dgvNotice.RowHeadersVisible = false;
      this.getReportTypes();
      this.getReportTypesLabels();
      this.getReportNoticeRecords();
      if (this.cbNoticeType.Items.Count > 0)
        this.cbNoticeType.SelectedIndex = 0;
      this.cbNoticeType.Text = File.ReadAllLines("Reports\\Notice\\LastUsed.txt")[0].ToString();
      this.cbCustomerLabels.Text = File.ReadAllLines("Reports\\MailLabel\\LastUsed.txt")[0].ToString();
      this.cbNoticeRecords.Text = File.ReadAllLines("Reports\\NoticeRecords\\LastUsed.txt")[0].ToString();
      this.getInterestSetting();
      this.dgvNotice.GridColor = Color.PowderBlue;
      this.dgvNotice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dgvNotice.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
      this.cbIntimationOrAuction.SelectedIndex = 0;
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
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

    private void getInterestSetting()
    {
      string strError = "";
      string my_querry = "select * from tblInterestSetting";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Articlessettings.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form articlessettings.refreshgrid()");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["NoticeScreen"] != null && dataTable2.Rows[0]["NoticeScreen"].ToString() != "")
        {
          this.InterestSetting = dataTable2.Rows[0]["NoticeScreen"].ToString();
          if (dataTable2.Rows[0]["NoticeScreenSimpleOrCompound"].ToString() == "COMPOUND")
            this.calculateCompoundInterest = true;
        }
      }
      else
        this.InterestSetting = "Interest Setting";
    }

    private void mainLoad()
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["NoticeScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["NoticeScreen"].ToString() + " as Articles";
      string my_querry = !(this.cbShopCodes.Text.Trim() != "") ? "SELECT p.ShopCode,p.BillNumber, p.BillDate, p.CustomerCode,c.cphone as phonenumber, c.cname+' '+c.cno+'  '+c.caddr1+'  '+c.caddr2 +'  '+c.caddr3 as NameAndAddress, p.amount, p.PresentValue, p.NetWeight,p.PureWeight, p.InterestRate, p.TYPE, P.ARTICLES FROM ( SELECT p.ShopCode,p.BillNumber,p.PhoneNumber, p.BillDate, p.CustomerCode, p.amount, p.PresentValue, p.NetWeight,p.pureWeight, p.temp1 as InterestRate, p.TYPE,p.Redeemed ," + str + " FROM tblPledge AS p ) AS p LEFT JOIN tblcustomers AS c ON p.customercode=c.cid where (p.redeemed = 'N') and (p.Billdate >= @BillDate1 and p.Billdate <= @BillDate2) and (p.Type in(@type1) or p.type in(@type2) or p.type in (@type3))  order by p.customercode,p.BillDate,p.BillNumber" : "SELECT p.ShopCode,p.BillNumber, p.BillDate, p.CustomerCode,c.cphone as phonenumber, c.cname+' '+c.cno+'  '+c.caddr1+'  '+c.caddr2 +'  '+c.caddr3 as NameAndAddress, p.amount, p.PresentValue, p.NetWeight,p.PureWeight, p.InterestRate, p.TYPE, P.ARTICLES FROM ( SELECT p.ShopCode,p.BillNumber,p.PhoneNumber, p.BillDate, p.CustomerCode, p.amount, p.PresentValue, p.NetWeight,p.pureWeight, p.temp1 as InterestRate, p.TYPE,p.Redeemed ," + str + " FROM tblPledge AS p ) AS p LEFT JOIN tblcustomers AS c ON p.customercode=c.cid where ShopCode = @ShopCode and (p.redeemed = 'N') and (p.Billdate >= @BillDate1 and p.Billdate <= @BillDate2) and (p.Type in(@type1) or p.type in(@type2) or p.type in (@type3))  order by p.customercode,p.BillDate,p.BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.cbShopCodes.Text.Trim() != "")
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("BillDate1", (object) this.tbxFromDate.Text));
      parameters.Add(new OleDbParameter("BillDate2", (object) this.tbxToDate.Text));
      parameters.Add(new OleDbParameter("Type1", this.comboBox1.Text == "ALL" ? (object) "GOLD" : (object) this.comboBox1.Text));
      parameters.Add(new OleDbParameter("Type2", this.comboBox1.Text == "ALL" ? (object) "SILVER" : (object) this.comboBox1.Text));
      parameters.Add(new OleDbParameter("Type3", this.comboBox1.Text == "ALL" ? (object) "OTHERS" : (object) this.comboBox1.Text));
      this.dtLOAD = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        try
        {
          int count = this.dtLOAD.Rows.Count;
          this.dgvNotice.Rows.Clear();
          if (this.dtLOAD.Rows.Count > 0)
          {
            foreach (DataRow row in (InternalDataCollectionBase) this.dtLOAD.Rows)
            {
              if (this.InterestSetting == "INTEREST SETTING")
                row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
            }
            this.dgvNotice.Rows.Add(this.dtLOAD.Rows.Count);
            for (int index = 0; index < this.dtLOAD.Rows.Count; ++index)
            {
              this.dgvNotice.Rows[index].Cells["pledgeBillNumber"].Value = (object) this.dtLOAD.Rows[index]["BillNumber"].ToString();
              this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value = (object) DateTime.Parse(this.dtLOAD.Rows[index]["BillDate"].ToString()).ToString("dd/MM/yyyy");
              this.dgvNotice.Rows[index].Cells["CustomerCode"].Value = (object) this.dtLOAD.Rows[index]["CustomerCode"].ToString();
              this.dgvNotice.Rows[index].Cells["netweight"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["NetWeight"].ToString());
              this.dgvNotice.Rows[index].Cells["pureweight"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["PureWeight"].ToString());
              this.dgvNotice.Rows[index].Cells["amount"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["amount"].ToString());
              this.dgvNotice.Rows[index].Cells["value"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["presentValue"].ToString());
              this.dgvNotice.Rows[index].Cells["nameAndAddress"].Value = (object) this.dtLOAD.Rows[index]["NameAndAddress"].ToString();
              this.dgvNotice.Rows[index].Cells["InterestRate"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["InterestRate"].ToString());
              this.dgvNotice.Rows[index].Cells["type"].Value = (object) this.dtLOAD.Rows[index]["Type"].ToString();
              this.dgvNotice.Rows[index].Cells["Articles"].Value = (object) this.dtLOAD.Rows[index]["Articles"].ToString();
              this.dgvNotice.Rows[index].Cells["PhoneNumber"].Value = (object) this.dtLOAD.Rows[index]["PhoneNumber"].ToString();
              this.dgvNotice.Rows[index].Cells["ShopCode"].Value = (object) this.dtLOAD.Rows[index]["ShopCode"].ToString();
            }
            this.dgvNotice.Columns["type"].Visible = false;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void loaddataGridView()
    {
    }

    private void getNoticeType()
    {
      string strError = "";
      string my_querry = "SELECT * from tblprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          if (row["NoticePrintFormats"].ToString() != "")
            this.cbNoticeType.Items.Add((object) row["NoticePrintFormats"].ToString());
          this.cbNoticeType.SelectedIndex = 0;
        }
      }
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Notice\\\\", "*.rpt"))
        this.cbNoticeType.Items.Add(file);
    }

    private void getReportTypesLabels()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\MailLabel\\\\", "*.rpt"))
        this.cbCustomerLabels.Items.Add(file);
    }

    private void getReportNoticeRecords()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\NoticeRecords\\\\", "*.rpt"))
        this.cbNoticeRecords.Items.Add(file);
    }

    private void getPblNumber()
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = !(this.cbShopCodes.Text.Trim() != "") ? PawnManagementClass.getShopDetails(PawnManagementClass.getDefaultLicenseCode()) : PawnManagementClass.getShopDetails(this.cbShopCodes.Text);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.pblNumber = dataTable2.Rows[0].Field<string>("PblNumber");
        this.tbxPblNo.Text = this.pblNumber;
      }
      this.tbxAuctionDate.Text = this.tbxToDate.Text;
    }

    private void btnDisplay_Click(object sender, EventArgs e)
    {
      this.select.FillWeight = 28f;
      this.pledgeBillNumber.FillWeight = 53f;
      this.pledgeBillDate.FillWeight = 84f;
      this.customerCode.FillWeight = 50f;
      this.nameAndAddress.FillWeight = 280f;
      this.amount.FillWeight = 65f;
      this.value.FillWeight = 65f;
      this.Articles.FillWeight = 230f;
      this.netWeight.FillWeight = 60f;
      this.pureWeight.FillWeight = 60f;
      this.InterestRate.FillWeight = 25f;
      this.interest.FillWeight = 50f;
      this.interestPlusPrincipal.FillWeight = 70f;
      this.perGram.FillWeight = 61f;
      this.mainLoad();
      this.getTotal();
      for (int index = 0; index < this.dgvNotice.RowCount; ++index)
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
    }

    private void setColours()
    {
      List<int> intList = new List<int>();
      string s1 = this.tbxSalePriceGold.Text == "" ? "0" : this.tbxSalePriceGold.Text.Trim().ToString();
      string s2 = this.tbxSalePriceSilver.Text == "" ? "0" : this.tbxSalePriceSilver.Text.Trim().ToString();
      string s3 = this.tbxAmountGold.Text == "" ? "0" : this.tbxAmountGold.Text.Trim().ToString();
      string s4 = this.tbxAmountSilver.Text == "" ? "0" : this.tbxAmountSilver.Text.Trim().ToString();
      for (int index = 0; index < this.dgvNotice.RowCount; ++index)
      {
        if (this.dgvNotice.Rows[index].Cells["Type"].Value.ToString().Equals("GOLD"))
        {
          if (s1.Equals("0"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) > double.Parse(s3))
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
              intList.Add(index);
            }
            else
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
            }
          }
          else if (s3.Equals("0"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(s1))
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
              intList.Add(index);
            }
            else
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
            }
          }
          else if (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) > double.Parse(s3) || double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(s1))
          {
            this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
            this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
            intList.Add(index);
          }
          else
          {
            this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
            this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
          }
        }
        if (this.dgvNotice.Rows[index].Cells["Type"].Value.ToString().Equals("SILVER"))
        {
          if (s2.Equals("0"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) > double.Parse(s4))
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
              intList.Add(index);
            }
            else
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
            }
          }
          else if (s4.Equals("0"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(s2))
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
              intList.Add(index);
            }
            else
            {
              this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
            }
          }
          else if (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) > double.Parse(s4) || double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(s2))
          {
            this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
            this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
            intList.Add(index);
          }
          else
          {
            this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
            this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
          }
        }
      }
      if (!this.cbIncludeSameCustomer.Checked)
        return;
      foreach (int rowIndex in intList)
        this.SetChildRows(rowIndex);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dgvNotice, "pledgeBook", FormMain.username);

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void getPicture(string customerCode)
    {
      if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
      else
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
    }

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
      if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
        return;
      this.getPicture(this.dgvNotice.Rows[this.dgvNotice.CurrentRow.Index].Cells["CustomerCode"].Value.ToString());
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
    }

    private void btnUnselectAll_Click(object sender, EventArgs e)
    {
    }

    private void dataGridView1_DataSourceChanged(object sender, EventArgs e) => this.getTotal();

    private void getTotal()
    {
      this.totalamount = 0.0;
      this.totalInterest = 0.0;
      this.totalWeightGold = this.totalWeightSilver = this.totalWeightOthers = 0.0;
      for (int index = 0; index < this.dgvNotice.RowCount; ++index)
      {
        DateTime.Parse(this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value.ToString());
        int n = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value.ToString()), DateTime.Today) - 1;
        if (n != -1)
        {
          this.dgvNotice.Rows[index].Cells["interest"].Value = !(FormMain.memberType == "ak") ? (n <= 11 ? (object) (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * double.Parse(this.dgvNotice.Rows[index].Cells["InterestRate"].Value.ToString()) * (double) n / 1200.0) : (!this.calculateCompoundInterest ? (object) (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * double.Parse(this.dgvNotice.Rows[index].Cells["InterestRate"].Value.ToString()) * (double) n / 1200.0) : (object) PawnManagementClass.calculateCompundInterest(double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()), (double) n, double.Parse(this.dgvNotice.Rows[index].Cells["InterestRate"].Value.ToString())))) : (!(this.cbShopCodes.Text.Trim() != "") ? (object) (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * double.Parse(PawnManagementClass.getShopDetails(PawnManagementClass.getDefaultLicenseCode()).Rows[0].Field<string>("RateOfInterest").ToString()) * (double) n / 1200.0) : (object) (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * double.Parse(PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0].Field<string>("RateOfInterest").ToString()) * (double) n / 1200.0));
          this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value = (object) (double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) + double.Parse(this.dgvNotice.Rows[index].Cells["interest"].Value.ToString()));
          this.dgvNotice.Rows[index].Cells["perGram"].Value = (object) Math.Round(double.Parse(this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value.ToString()) / double.Parse(this.dgvNotice.Rows[index].Cells["pureWeight"].Value.ToString()));
        }
        this.totalamount += double.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString());
        this.totalInterest += double.Parse(this.dgvNotice.Rows[index].Cells["interest"].Value.ToString());
        if (this.dgvNotice.Rows[index].Cells["type"].Value.ToString().Equals("GOLD"))
          this.totalWeightGold += double.Parse(this.dgvNotice.Rows[index].Cells["netweight"].Value.ToString());
        if (this.dgvNotice.Rows[index].Cells["type"].Value.ToString().Equals("SILVER"))
          this.totalWeightSilver += double.Parse(this.dgvNotice.Rows[index].Cells["netweight"].Value.ToString());
        if (this.dgvNotice.Rows[index].Cells["type"].Value.ToString().Equals("OTHERS"))
          this.totalWeightOthers += double.Parse(this.dgvNotice.Rows[index].Cells["netweight"].Value.ToString());
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.setColours();
      this.cbNoticeType.Select();
    }

    private void dgvNotice_EditingControlShowing(
      object sender,
      DataGridViewEditingControlShowingEventArgs e)
    {
    }

    private void select_MouseClick(object sender, MouseEventArgs e)
    {
    }

    private void dgvNotice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (!this.dgvNotice.IsCurrentCellDirty)
        return;
      this.dgvNotice.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void SetChildRows(int rowIndex)
    {
      string str = this.dgvNotice.Rows[rowIndex].Cells["customerCode"].Value.ToString();
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["CustomerCode"].Value.ToString().Equals(str))
        {
          row.Cells["select"].Value = (object) true;
          row.DefaultCellStyle.ForeColor = Color.RoyalBlue;
        }
      }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0)
        return;
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\" + this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["CustomerCode"].Value.ToString() + ".png").ShowDialog();
    }

    private void Notice_ResizeEnd(object sender, EventArgs e)
    {
    }

    private void dgvNotice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (!(this.dgvNotice.Columns[e.ColumnIndex].Name == "select"))
        return;
      if (bool.Parse(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["select"].Value.ToString()))
      {
        this.strcustomerCode[this.i++] = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["customerCode"].Value.ToString();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
        {
          if (row.Cells["CustomerCode"].Value.ToString().Equals(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["customerCode"].Value.ToString()))
          {
            row.Cells["select"].Value = (object) true;
            row.DefaultCellStyle.ForeColor = Color.RoyalBlue;
          }
        }
      }
      if (!bool.Parse(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["select"].Value.ToString()))
        this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
    }

    private void addColumnsToDataTabledt()
    {
      this.dt.Columns.Add("BillNumber", typeof (string));
      this.dt.Columns.Add("BillDate", typeof (DateTime));
      this.dt.Columns.Add("CustomerCode", typeof (string));
      this.dt.Columns.Add("CustomerNameAndAddress", typeof (string));
      this.dt.Columns.Add("amount", typeof (int));
      this.dt.Columns.Add("NetWeight", typeof (double));
      this.dt.Columns.Add("PresentValue", typeof (string));
      this.dt.Columns.Add("Articles", typeof (string));
      this.dt.Columns.Add("PblNumber", typeof (string));
      this.dt.Columns.Add("AuctionDate", typeof (DateTime));
      this.dt.Columns.Add("KdisNumber", typeof (string));
      this.dt.Columns.Add("PhoneNumber", typeof (string));
      this.dt.Columns.Add("NoticeType", typeof (string));
    }

    private void getdatatabledtdata()
    {
      int num = 0;
      this.dt.Clear();
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()) && row.Cells["PhoneNumber"].Value.ToString().Length == 10 && this.IsDigitsOnly(row.Cells["PhoneNumber"].Value.ToString()) && !this.checkIfDataTableAlreadyContains(row.Cells["CustomerCode"].Value.ToString()))
        {
          ++num;
          this.dt.Rows.Add((object) row.Cells["pledgeBillNumber"].Value.ToString(), (object) DateTime.Parse(row.Cells["pledgeBillDate"].Value.ToString()), (object) row.Cells["CustomerCode"].Value.ToString(), (object) row.Cells["nameAndAddress"].Value.ToString(), (object) double.Parse(row.Cells["amount"].Value.ToString()), (object) double.Parse(row.Cells["netweight"].Value.ToString()), (object) row.Cells["Value"].Value.ToString(), (object) row.Cells["Articles"].Value.ToString(), (object) this.tbxPblNo.Text.Trim().ToString(), (object) this.tbxAuctionDate.Text.Trim().ToString(), (object) this.tbxKdisNo.Text.Trim().ToString(), (object) row.Cells["PhoneNumber"].Value.ToString(), (object) this.tbxNoticeType.Text);
        }
      }
    }

    private bool checkIfDataTableAlreadyContains(string customerCode)
    {
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["customercode"].ToString() == customerCode)
          return true;
      }
      return false;
    }

    private void getdatatabledtdataNotice()
    {
      this.dt.Clear();
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()))
          this.dt.Rows.Add((object) row.Cells["pledgeBillNumber"].Value.ToString(), (object) DateTime.Parse(row.Cells["pledgeBillDate"].Value.ToString()), (object) row.Cells["CustomerCode"].Value.ToString(), (object) row.Cells["nameAndAddress"].Value.ToString(), (object) double.Parse(row.Cells["amount"].Value.ToString()), (object) double.Parse(row.Cells["netweight"].Value.ToString()), (object) row.Cells["Value"].Value.ToString(), (object) row.Cells["Articles"].Value.ToString(), (object) this.tbxPblNo.Text.Trim().ToString(), (object) this.tbxAuctionDate.Text.Trim().ToString(), (object) this.tbxKdisNo.Text.Trim().ToString(), (object) row.Cells["PhoneNumber"].Value.ToString(), (object) this.tbxNoticeType.Text);
      }
    }

    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
      Hashtable hashtable = new Hashtable();
      ArrayList arrayList = new ArrayList();
      foreach (DataRow row in (InternalDataCollectionBase) dTable.Rows)
      {
        if (hashtable.Contains(row[colName]))
          arrayList.Add((object) row);
        else
          hashtable.Add(row[colName], (object) string.Empty);
      }
      foreach (DataRow row in arrayList)
        dTable.Rows.Remove(row);
      return dTable;
    }

    private bool IsDigitsOnly(string str)
    {
      if (str == "")
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void btnPrintNotice_Click(object sender, EventArgs e)
    {
      if (!this.smsclickedOnce && !this.noticeClickedOnce)
      {
        this.addColumnsToDataTabledt();
        this.noticeClickedOnce = true;
      }
      this.getdatatabledtdataNotice();
      PawnManagementClass.InsertIntoHistory("NOTICE PRINT", "NOTICE printed", "", "", FormMain.username, DateTime.Now.ToString());
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = !(this.cbShopCodes.Text.Trim() == "") ? PawnManagementClass.getShopDetails(this.cbShopCodes.Text) : PawnManagementClass.getShopDetails(PawnManagementClass.getDefaultLicenseCode());
      ReportDocument RD = new ReportDocument();
      RD.Load(this.cbNoticeType.Text);
      RD.SetDataSource(this.dt);
      if (!this.cbNoticeType.Text.Contains("Final"))
        RD.Subreports["ShopNameAndAddressHeading"].SetDataSource(dataTable2);
      RD.Subreports["ShopNameAndAddressBottom"].SetDataSource(dataTable2);
      DataTable customerDetails = this.getCustomerDetails();
      foreach (DataRow row in (InternalDataCollectionBase) customerDetails.Rows)
        row["CImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + row["CID"].ToString() + ".png");
      RD.Subreports["ToAddress"].SetDataSource(customerDetails);
      new FormCrystalReportViewer(RD).Show();
      File.WriteAllText("Reports\\\\Notice\\\\LastUsed.txt", this.cbNoticeType.Text);
    }

    private void getNoticeTypes()
    {
      StringBuilder stringBuilder = new StringBuilder("Reports\\\\Notice\\\\ReportNotice");
      if (this.cbIntimationOrAuction.Text == "AUCTION NOTICE")
        stringBuilder.Append("Final");
      if (this.cbLanguage.Text == "ENGLISH")
        stringBuilder.Append("English");
      if (this.cbIncludeNetWeight.Checked)
        stringBuilder.Append("WithWeight");
      else
        stringBuilder.Append("WithoutWeight");
      if (this.cbIncludePhoto.Checked)
        stringBuilder.Append("WithPhoto");
      else
        stringBuilder.Append("WithoutPhoto");
      if (!this.cbIncludeAmountTotal.Checked)
        stringBuilder.Append("WithoutTotal");
      stringBuilder.Append(".rpt");
      this.cbNoticeType.Text = stringBuilder.ToString();
    }

    private DataTable getCustomerDetails()
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

    private void cbNoticeType_SelectedValueChanged(object sender, EventArgs e)
    {
    }

    private void dgvNotice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxSalePriceGold_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void button3_Click(object sender, EventArgs e)
    {
    }

    private void cALLToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dgvNotice == null || this.dgvNotice.Rows.Count <= 0)
        return;
      int num = (int) new FormCall(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["phoneNumber"].Value.ToString()).ShowDialog();
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim()))
        return;
      this.tbxFromDate.Select();
    }

    private void textBox2_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim()))
        return;
      this.tbxToDate.Select();
    }

    private void selectNextControL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
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

    private void FormNotice_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      int num = (int) new FormDataGridView(this.dtLOAD, "notice").ShowDialog();
    }

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFromDate.Select();
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == "")
        return;
      if (this.cbShopCodes.Items.Count > 0)
        this.cbShopCodes.Text = PawnManagementClass.getDefaultLicenseCode();
      this.cbShopCodes.Select();
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      List<string> stringList = new List<string>();
      string str1 = "";
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()) && !stringList.Contains(row.Cells["customercode"].Value.ToString()))
          stringList.Add(row.Cells["customercode"].Value.ToString());
      }
      foreach (string str2 in stringList)
        str1 = str1 + ",'" + str2 + "'";
      if (str1 != "")
      {
        string strError = "";
        DataTable dataTable = SQLHelper.GetDataTable("select * from tblcustomers  where cid in(" + str1.Substring(1, str1.Length - 1) + ") order by cid ", ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the billNNumber " + strError);
        }
        else if (dataTable != null && dataTable.Rows.Count > 0)
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
            row["CImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + row["CID"].ToString() + ".png");
          this.rd.Load(this.cbCustomerLabels.Text);
          this.rd.SetDataSource(dataTable);
          int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Select Customers ");
      }
      File.WriteAllText("Reports\\\\MailLabel\\\\LastUsed.txt", this.cbCustomerLabels.Text);
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvNotice.Rows.Count; ++index)
      {
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
        this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
      }
    }

    private void unSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvNotice.Rows.Count; ++index)
      {
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
        this.dgvNotice.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
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

    private void setIntimationLetterSentToolStripMenuItem_Click(object sender, EventArgs e) => WaitWindow.Show(new EventHandler<WaitWindowEventArgs>(this.sendingIntimationLetter));

    private void sendingIntimationLetter(object sender, WaitWindowEventArgs e)
    {
      int num1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()) && PawnManagement.Classes.PawnManagementClasses.PledgeClass.setIntimationLetterSentToYesOrNo(row.Cells["ShopCode"].Value.ToString(), row.Cells["PledgeBillNumber"].Value.ToString(), "Y", DateTime.Now, this.tbxNoticeType.Text, "") == "Done")
          ++num1;
      }
      int num2 = (int) MessageBox.Show("successfully updated -- " + num1.ToString());
    }

    private void sendingAuctionLetter(object sender, WaitWindowEventArgs e)
    {
      int num1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()) && PawnManagement.Classes.PawnManagementClasses.PledgeClass.setAuctionLetterSentToYesOrNo(row.Cells["ShopCode"].Value.ToString(), row.Cells["PledgeBillNumber"].Value.ToString(), "Y", DateTime.Now, this.tbxNoticeType.Text, "") == "Done")
          ++num1;
      }
      int num2 = (int) MessageBox.Show("successfully update -- " + num1.ToString());
    }

    private void setAuctionLetterSentToolStripMenuItem_Click(object sender, EventArgs e) => WaitWindow.Show(new EventHandler<WaitWindowEventArgs>(this.sendingAuctionLetter));

    private void cbIntimationOrAuction_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbIntimationOrAuction.Text == "AUCTION NOTICE")
      {
        this.tbxPblNo.Enabled = true;
        this.tbxAuctionDate.Enabled = true;
        this.tbxKdisNo.Enabled = true;
        this.cbLanguage.Enabled = false;
        this.cbLanguage.Text = "TAMIL";
      }
      else
      {
        this.tbxPblNo.Enabled = false;
        this.tbxAuctionDate.Enabled = false;
        this.tbxKdisNo.Enabled = false;
        this.cbLanguage.Enabled = true;
      }
    }

    private void settingsChanged_CheckedChanged(object sender, EventArgs e) => this.getNoticeTypes();

    private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e) => this.getNoticeTypes();

    private void sendSmsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      FieldToBind.Add("CustomerNameAndAddress");
      FieldToBind.Add("PhoneNumber");
      FieldToBind.Add("BillNumber");
      FieldToBind.Add("BillDate");
      FieldToBind.Add("CustomerCode");
      FieldToBind.Add("amount");
      FieldToBind.Add("NetWeight");
      FieldToBind.Add("PresentValue");
      FieldToBind.Add("Articles");
      FieldToBind.Add("PblNumber");
      FieldToBind.Add("AuctionDate");
      FieldToBind.Add("KdisNumber");
      if (!this.smsclickedOnce && !this.noticeClickedOnce)
      {
        this.addColumnsToDataTabledt();
        this.smsclickedOnce = true;
      }
      this.getdatatabledtdata();
      formSendSms.LoadNotice(this.dt, "CustomerCode", "PhoneNumber", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
    }

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0)
        return;
      string customerCode = this.dgvNotice.Rows[this.dgvNotice.CurrentRow.Index].Cells["CustomerCode"].Value.ToString();
      this.getPicture(customerCode);
      if (this.dgvNotice.CurrentCell.OwningColumn.HeaderText == "ID")
      {
        string CUSTOMERCODE = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (customerCode != "")
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

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0 || this.dgvNotice.Columns.Count <= 0)
        return;
      if (this.dgvNotice.Columns[e.ColumnIndex].HeaderText == "NO" | this.dgvNotice.Columns[e.ColumnIndex].HeaderText == "ID")
        this.dgvNotice.Cursor = Cursors.Hand;
      else
        this.dgvNotice.Cursor = Cursors.Default;
    }

    private void glassButton6_Click(object sender, EventArgs e)
    {
      if (!(this.cbNoticeRecords.Text.Trim() != ""))
        return;
      DataSet dataSet = new DataSet();
      if (!this.smsclickedOnce && !this.noticeClickedOnce)
      {
        this.addColumnsToDataTabledt();
        this.noticeClickedOnce = true;
      }
      this.getdatatabledtdataNotice();
      PawnManagementClass.InsertIntoHistory("NOTICE PRINT", "NOTICE printed", "", "", FormMain.username, DateTime.Now.ToString());
      DataTable dataTable = new DataTable();
      dataTable = !(this.cbShopCodes.Text.Trim() == "") ? PawnManagementClass.getShopDetails(this.cbShopCodes.Text) : PawnManagementClass.getShopDetails(PawnManagementClass.getDefaultLicenseCode());
      DataTable table = this.dt.DefaultView.ToTable("dt", true, "CUSTOMERCODE", "customerNameAndAddress");
      ReportDocument RD = new ReportDocument();
      RD.Load(this.cbNoticeRecords.Text);
      RD.Subreports[0].SetDataSource(this.dt);
      RD.SetDataSource(table);
      new FormCrystalReportViewer(RD).Show();
      File.WriteAllText("Reports\\\\NoticeRecords\\\\LastUsed.txt", this.cbNoticeRecords.Text);
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
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle16 = new DataGridViewCellStyle();
      this.label10 = new Label();
      this.tbxAmountSilver = new TextBox();
      this.tbxSalePriceSilver = new TextBox();
      this.label8 = new Label();
      this.tbxSalePriceGold = new TextBox();
      this.label7 = new Label();
      this.label9 = new Label();
      this.tbxAmountGold = new TextBox();
      this.timer1 = new Timer(this.components);
      this.label11 = new Label();
      this.tbxNoticeType = new TextBox();
      this.label14 = new Label();
      this.label13 = new Label();
      this.label12 = new Label();
      this.tbxKdisNo = new TextBox();
      this.tbxAuctionDate = new TextBox();
      this.tbxPblNo = new TextBox();
      this.button2 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.tbxToDate = new TextBox();
      this.btnDisplay = new GlassButton();
      this.label3 = new Label();
      this.comboBox1 = new ComboBox();
      this.label1 = new Label();
      this.timer2 = new Timer(this.components);
      this.dgvNotice = new DataGridView();
      this.select = new DataGridViewCheckBoxColumn();
      this.PhoneNumber = new DataGridViewTextBoxColumn();
      this.ShopCode = new DataGridViewTextBoxColumn();
      this.pledgeBillNumber = new DataGridViewTextBoxColumn();
      this.pledgeBillDate = new DataGridViewTextBoxColumn();
      this.customerCode = new DataGridViewTextBoxColumn();
      this.nameAndAddress = new DataGridViewTextBoxColumn();
      this.netWeight = new DataGridViewTextBoxColumn();
      this.pureWeight = new DataGridViewTextBoxColumn();
      this.amount = new DataGridViewTextBoxColumn();
      this.value = new DataGridViewTextBoxColumn();
      this.Articles = new DataGridViewTextBoxColumn();
      this.InterestRate = new DataGridViewTextBoxColumn();
      this.interest = new DataGridViewTextBoxColumn();
      this.interestPlusPrincipal = new DataGridViewTextBoxColumn();
      this.perGram = new DataGridViewTextBoxColumn();
      this.type = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.cALLToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new ToolStripMenuItem();
      this.unSelectAllToolStripMenuItem = new ToolStripMenuItem();
      this.sendSmsToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.setIntimationLetterSentToolStripMenuItem = new ToolStripMenuItem();
      this.setAuctionLetterSentToolStripMenuItem = new ToolStripMenuItem();
      this.pictureBox1 = new PictureBox();
      this.dataGridView2 = new DataGridView();
      this.label2 = new Label();
      this.headerPanel2 = new HeaderPanel();
      this.label15 = new Label();
      this.cbShopCodes = new ComboBox();
      this.headerPanel1 = new HeaderPanel();
      this.headerPanel3 = new HeaderPanel();
      this.label17 = new Label();
      this.cbIntimationOrAuction = new ComboBox();
      this.headerPanel4 = new HeaderPanel();
      this.panel2 = new Panel();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.cbNoticeType = new ComboBox();
      this.glassButton9 = new GlassButton();
      this.btnPrintNotice = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.cbNoticeRecords = new ComboBox();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.cbCustomerLabels = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel8 = new HeaderPanel();
      this.cbIncludePhoto = new CheckBox();
      this.cbIncludeAmountTotal = new CheckBox();
      this.cbIncludeNetWeight = new CheckBox();
      this.cbLanguage = new ComboBox();
      this.tbxNoticeCharge = new TextBox();
      this.label18 = new Label();
      this.lblNoticeCharge = new Label();
      this.cbIncludeSameCustomer = new CheckBox();
      ((ISupportInitialize) this.dgvNotice).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      this.SuspendLayout();
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.AliceBlue;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(94, 14);
      this.label10.Name = "label10";
      this.label10.Size = new Size(49, 16);
      this.label10.TabIndex = 43;
      this.label10.Text = "GOLD";
      this.tbxAmountSilver.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmountSilver.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountSilver.Location = new Point(194, 66);
      this.tbxAmountSilver.Name = "tbxAmountSilver";
      this.tbxAmountSilver.Size = new Size(80, 26);
      this.tbxAmountSilver.TabIndex = 3;
      this.tbxAmountSilver.TextAlign = HorizontalAlignment.Right;
      this.tbxAmountSilver.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxAmountSilver.KeyPress += new KeyPressEventHandler(this.tbxSalePriceGold_KeyPress);
      this.tbxSalePriceSilver.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSalePriceSilver.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSalePriceSilver.Location = new Point(194, 35);
      this.tbxSalePriceSilver.Name = "tbxSalePriceSilver";
      this.tbxSalePriceSilver.Size = new Size(80, 26);
      this.tbxSalePriceSilver.TabIndex = 1;
      this.tbxSalePriceSilver.TextAlign = HorizontalAlignment.Right;
      this.tbxSalePriceSilver.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxSalePriceSilver.KeyPress += new KeyPressEventHandler(this.tbxSalePriceGold_KeyPress);
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.AliceBlue;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(18, 71);
      this.label8.Name = "label8";
      this.label8.Size = new Size(73, 16);
      this.label8.TabIndex = 39;
      this.label8.Text = "AMOUNT";
      this.tbxSalePriceGold.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSalePriceGold.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSalePriceGold.Location = new Point(94, 35);
      this.tbxSalePriceGold.Name = "tbxSalePriceGold";
      this.tbxSalePriceGold.Size = new Size(91, 26);
      this.tbxSalePriceGold.TabIndex = 0;
      this.tbxSalePriceGold.TextAlign = HorizontalAlignment.Right;
      this.tbxSalePriceGold.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxSalePriceGold.KeyPress += new KeyPressEventHandler(this.tbxSalePriceGold_KeyPress);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.AliceBlue;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(2, 40);
      this.label7.Name = "label7";
      this.label7.Size = new Size(95, 16);
      this.label7.TabIndex = 38;
      this.label7.Text = "SALE PRICE";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.AliceBlue;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(194, 16);
      this.label9.Name = "label9";
      this.label9.Size = new Size(61, 16);
      this.label9.TabIndex = 42;
      this.label9.Text = "SILVER";
      this.tbxAmountGold.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmountGold.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountGold.Location = new Point(94, 66);
      this.tbxAmountGold.Name = "tbxAmountGold";
      this.tbxAmountGold.Size = new Size(91, 26);
      this.tbxAmountGold.TabIndex = 2;
      this.tbxAmountGold.TextAlign = HorizontalAlignment.Right;
      this.tbxAmountGold.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxAmountGold.KeyPress += new KeyPressEventHandler(this.tbxSalePriceGold_KeyPress);
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.AliceBlue;
      this.label11.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(-2, 124);
      this.label11.Name = "label11";
      this.label11.Size = new Size(105, 15);
      this.label11.TabIndex = 55;
      this.label11.Text = "Notice Heading";
      this.tbxNoticeType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeType.Font = new Font("MS Reference Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeType.Location = new Point(103, 119);
      this.tbxNoticeType.Name = "tbxNoticeType";
      this.tbxNoticeType.Size = new Size(154, 23);
      this.tbxNoticeType.TabIndex = 54;
      this.tbxNoticeType.Text = "SPEEDPOST/RLAD";
      this.tbxNoticeType.TextAlign = HorizontalAlignment.Right;
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.AliceBlue;
      this.label14.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(30, 99);
      this.label14.Name = "label14";
      this.label14.Size = new Size(57, 15);
      this.label14.TabIndex = 53;
      this.label14.Text = "Kdis No";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.AliceBlue;
      this.label13.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(30, 67);
      this.label13.Name = "label13";
      this.label13.Size = new Size(56, 30);
      this.label13.TabIndex = 52;
      this.label13.Text = "Auction\r\n date";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.AliceBlue;
      this.label12.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(30, 48);
      this.label12.Name = "label12";
      this.label12.Size = new Size(56, 15);
      this.label12.TabIndex = 51;
      this.label12.Text = "Pbl.No:";
      this.tbxKdisNo.BorderStyle = BorderStyle.FixedSingle;
      this.tbxKdisNo.Font = new Font("MS Reference Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxKdisNo.Location = new Point(103, 94);
      this.tbxKdisNo.Name = "tbxKdisNo";
      this.tbxKdisNo.Size = new Size(154, 23);
      this.tbxKdisNo.TabIndex = 3;
      this.tbxKdisNo.TextAlign = HorizontalAlignment.Right;
      this.tbxKdisNo.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxAuctionDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAuctionDate.Font = new Font("MS Reference Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAuctionDate.Location = new Point(103, 69);
      this.tbxAuctionDate.Name = "tbxAuctionDate";
      this.tbxAuctionDate.Size = new Size(154, 23);
      this.tbxAuctionDate.TabIndex = 2;
      this.tbxAuctionDate.TextAlign = HorizontalAlignment.Right;
      this.tbxAuctionDate.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxPblNo.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPblNo.Font = new Font("MS Reference Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPblNo.Location = new Point(103, 44);
      this.tbxPblNo.Name = "tbxPblNo";
      this.tbxPblNo.Size = new Size(154, 23);
      this.tbxPblNo.TabIndex = 1;
      this.tbxPblNo.TextAlign = HorizontalAlignment.Right;
      this.tbxPblNo.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.button2.BackColor = Color.LightBlue;
      this.button2.FadeOnFocus = true;
      this.button2.ForeColor = Color.MediumBlue;
      this.button2.ForeColorOnFocus = Color.Red;
      this.button2.ForeColorOnLeave = Color.RoyalBlue;
      this.button2.GlowColor = Color.White;
      ((ButtonBase) this.button2).Image = (Image) Resources.SEARCHGLASS2525;
      this.button2.InnerBorderColor = Color.Transparent;
      ((Control) this.button2).Location = new Point(70, 120);
      ((Control) this.button2).Name = "button2";
      this.button2.OuterBorderColor = Color.MediumSlateBlue;
      this.button2.ShineColor = Color.Transparent;
      ((Control) this.button2).Size = new Size(182, 34);
      ((Control) this.button2).TabIndex = 4;
      ((Control) this.button2).Text = "&FILTER";
      ((ButtonBase) this.button2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.button2).Click += new EventHandler(this.button2_Click);
      this.tbxFromDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(73, 41);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(109, 26);
      this.tbxFromDate.TabIndex = 1;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Right;
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxFromDate.Validating += new CancelEventHandler(this.textBox1_Validating);
      this.tbxToDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(73, 70);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(109, 26);
      this.tbxToDate.TabIndex = 2;
      this.tbxToDate.TextAlign = HorizontalAlignment.Right;
      this.tbxToDate.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.tbxToDate.Validating += new CancelEventHandler(this.textBox2_Validating);
      this.btnDisplay.BackColor = Color.LightBlue;
      this.btnDisplay.FadeOnFocus = true;
      this.btnDisplay.ForeColor = Color.MediumBlue;
      this.btnDisplay.ForeColorOnFocus = Color.Red;
      this.btnDisplay.ForeColorOnLeave = Color.RoyalBlue;
      this.btnDisplay.GlowColor = Color.White;
      this.btnDisplay.InnerBorderColor = Color.Transparent;
      ((Control) this.btnDisplay).Location = new Point(41, 128);
      ((Control) this.btnDisplay).Name = "btnDisplay";
      this.btnDisplay.OuterBorderColor = Color.MediumSlateBlue;
      this.btnDisplay.ShineColor = Color.Transparent;
      ((Control) this.btnDisplay).Size = new Size(109, 23);
      ((Control) this.btnDisplay).TabIndex = 4;
      ((Control) this.btnDisplay).Text = "&SHOW";
      ((ButtonBase) this.btnDisplay).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnDisplay).Click += new EventHandler(this.btnDisplay_Click);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.AliceBlue;
      this.label3.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(26, 104);
      this.label3.Name = "label3";
      this.label3.Size = new Size(43, 15);
      this.label3.TabIndex = 17;
      this.label3.Text = "TYPE";
      this.comboBox1.BackColor = SystemColors.ButtonHighlight;
      this.comboBox1.FlatStyle = FlatStyle.Flat;
      this.comboBox1.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[4]
      {
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS",
        (object) "ALL"
      });
      this.comboBox1.Location = new Point(75, 99);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(107, 23);
      this.comboBox1.TabIndex = 3;
      this.comboBox1.KeyDown += new KeyEventHandler(this.selectNextControL);
      this.comboBox1.KeyPress += new KeyPressEventHandler(this.comboBox1_KeyPress);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.AliceBlue;
      this.label1.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(20, 47);
      this.label1.Name = "label1";
      this.label1.Size = new Size(49, 15);
      this.label1.TabIndex = 14;
      this.label1.Text = "FROM";
      this.dgvNotice.AllowUserToAddRows = false;
      this.dgvNotice.AllowUserToOrderColumns = true;
      gridViewCellStyle1.BackColor = Color.Snow;
      gridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.DarkBlue;
      this.dgvNotice.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      this.dgvNotice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvNotice.BackgroundColor = Color.White;
      this.dgvNotice.BorderStyle = BorderStyle.Fixed3D;
      this.dgvNotice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      this.dgvNotice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = Color.PaleTurquoise;
      gridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.MediumBlue;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.dgvNotice.ColumnHeadersDefaultCellStyle = gridViewCellStyle2;
      this.dgvNotice.ColumnHeadersHeight = 40;
      this.dgvNotice.Columns.AddRange((DataGridViewColumn) this.select, (DataGridViewColumn) this.PhoneNumber, (DataGridViewColumn) this.ShopCode, (DataGridViewColumn) this.pledgeBillNumber, (DataGridViewColumn) this.pledgeBillDate, (DataGridViewColumn) this.customerCode, (DataGridViewColumn) this.nameAndAddress, (DataGridViewColumn) this.netWeight, (DataGridViewColumn) this.pureWeight, (DataGridViewColumn) this.amount, (DataGridViewColumn) this.value, (DataGridViewColumn) this.Articles, (DataGridViewColumn) this.InterestRate, (DataGridViewColumn) this.interest, (DataGridViewColumn) this.interestPlusPrincipal, (DataGridViewColumn) this.perGram, (DataGridViewColumn) this.type);
      this.dgvNotice.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = Color.AliceBlue;
      gridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = Color.DarkBlue;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      this.dgvNotice.DefaultCellStyle = gridViewCellStyle3;
      this.dgvNotice.Dock = DockStyle.Fill;
      this.dgvNotice.GridColor = Color.Khaki;
      this.dgvNotice.Location = new Point(0, 0);
      this.dgvNotice.Name = "dgvNotice";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = SystemColors.Info;
      gridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Black;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.dgvNotice.RowHeadersDefaultCellStyle = gridViewCellStyle4;
      this.dgvNotice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvNotice.Size = new Size(994, 347);
      this.dgvNotice.TabIndex = 20;
      this.dgvNotice.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
      this.dgvNotice.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dgvNotice.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dgvNotice.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvNotice_CellPainting);
      this.dgvNotice.CellValueChanged += new DataGridViewCellEventHandler(this.dgvNotice_CellValueChanged);
      this.dgvNotice.CurrentCellDirtyStateChanged += new EventHandler(this.dgvNotice_CurrentCellDirtyStateChanged);
      this.dgvNotice.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvNotice_EditingControlShowing);
      this.dgvNotice.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.dgvNotice.KeyUp += new KeyEventHandler(this.dataGridView1_KeyUp);
      this.select.HeaderText = "tick";
      this.select.Name = "select";
      this.select.Resizable = DataGridViewTriState.True;
      this.select.SortMode = DataGridViewColumnSortMode.Automatic;
      this.PhoneNumber.HeaderText = "PhoneNumber";
      this.PhoneNumber.Name = "PhoneNumber";
      this.ShopCode.HeaderText = "ShopCode";
      this.ShopCode.Name = "ShopCode";
      this.ShopCode.Visible = false;
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.pledgeBillNumber.DefaultCellStyle = gridViewCellStyle5;
      this.pledgeBillNumber.FillWeight = 10f;
      this.pledgeBillNumber.HeaderText = "NO";
      this.pledgeBillNumber.MaxInputLength = 6;
      this.pledgeBillNumber.Name = "pledgeBillNumber";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.pledgeBillDate.DefaultCellStyle = gridViewCellStyle6;
      this.pledgeBillDate.FillWeight = 10f;
      this.pledgeBillDate.HeaderText = "Bill Date";
      this.pledgeBillDate.Name = "pledgeBillDate";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.customerCode.DefaultCellStyle = gridViewCellStyle7;
      this.customerCode.HeaderText = "ID";
      this.customerCode.Name = "customerCode";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.nameAndAddress.DefaultCellStyle = gridViewCellStyle8;
      this.nameAndAddress.HeaderText = "NAME AND ADDRESS";
      this.nameAndAddress.Name = "nameAndAddress";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.netWeight.DefaultCellStyle = gridViewCellStyle9;
      this.netWeight.HeaderText = "Wt";
      this.netWeight.Name = "netWeight";
      this.pureWeight.HeaderText = "PURE WT";
      this.pureWeight.Name = "pureWeight";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.amount.DefaultCellStyle = gridViewCellStyle10;
      this.amount.HeaderText = "Amount";
      this.amount.Name = "amount";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.value.DefaultCellStyle = gridViewCellStyle11;
      this.value.HeaderText = "Value";
      this.value.Name = "value";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.Articles.DefaultCellStyle = gridViewCellStyle12;
      this.Articles.HeaderText = "Articles";
      this.Articles.Name = "Articles";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.InterestRate.DefaultCellStyle = gridViewCellStyle13;
      this.InterestRate.HeaderText = "INTEREST RATE";
      this.InterestRate.Name = "InterestRate";
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.interest.DefaultCellStyle = gridViewCellStyle14;
      this.interest.HeaderText = "INTEREST";
      this.interest.Name = "interest";
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.interestPlusPrincipal.DefaultCellStyle = gridViewCellStyle15;
      this.interestPlusPrincipal.HeaderText = "AMOUNT + INTEREST";
      this.interestPlusPrincipal.Name = "interestPlusPrincipal";
      gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.perGram.DefaultCellStyle = gridViewCellStyle16;
      this.perGram.HeaderText = "Sale Rate";
      this.perGram.Name = "perGram";
      this.type.HeaderText = "Type";
      this.type.Name = "type";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.cALLToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.selectAllToolStripMenuItem,
        (ToolStripItem) this.unSelectAllToolStripMenuItem,
        (ToolStripItem) this.sendSmsToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.setIntimationLetterSentToolStripMenuItem,
        (ToolStripItem) this.setAuctionLetterSentToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(208, 224);
      this.cALLToolStripMenuItem.Name = "cALLToolStripMenuItem";
      this.cALLToolStripMenuItem.Size = new Size(207, 22);
      this.cALLToolStripMenuItem.Text = "CALL";
      this.cALLToolStripMenuItem.Click += new EventHandler(this.cALLToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(207, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(207, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(207, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new Size(207, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
      this.unSelectAllToolStripMenuItem.Name = "unSelectAllToolStripMenuItem";
      this.unSelectAllToolStripMenuItem.Size = new Size(207, 22);
      this.unSelectAllToolStripMenuItem.Text = "UnSelect All";
      this.unSelectAllToolStripMenuItem.Click += new EventHandler(this.unSelectAllToolStripMenuItem_Click);
      this.sendSmsToolStripMenuItem.Name = "sendSmsToolStripMenuItem";
      this.sendSmsToolStripMenuItem.Size = new Size(207, 22);
      this.sendSmsToolStripMenuItem.Text = "Send Sms";
      this.sendSmsToolStripMenuItem.Click += new EventHandler(this.sendSmsToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(207, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.setIntimationLetterSentToolStripMenuItem.Name = "setIntimationLetterSentToolStripMenuItem";
      this.setIntimationLetterSentToolStripMenuItem.Size = new Size(207, 22);
      this.setIntimationLetterSentToolStripMenuItem.Text = "Set Intimation Letter Sent";
      this.setIntimationLetterSentToolStripMenuItem.Click += new EventHandler(this.setIntimationLetterSentToolStripMenuItem_Click);
      this.setAuctionLetterSentToolStripMenuItem.Name = "setAuctionLetterSentToolStripMenuItem";
      this.setAuctionLetterSentToolStripMenuItem.Size = new Size(207, 22);
      this.setAuctionLetterSentToolStripMenuItem.Text = "Set Auction Letter Sent";
      this.setAuctionLetterSentToolStripMenuItem.Click += new EventHandler(this.setAuctionLetterSentToolStripMenuItem_Click);
      this.pictureBox1.Anchor = AnchorStyles.Top;
      this.pictureBox1.Location = new Point(881, 66);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(46, 55);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 22;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(64, 238);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new Size(691, 157);
      this.dataGridView2.TabIndex = 21;
      this.dataGridView2.Visible = false;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.AliceBlue;
      this.label2.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(42, 75);
      this.label2.Name = "label2";
      this.label2.Size = new Size(27, 15);
      this.label2.TabIndex = 23;
      this.label2.Text = "TO";
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.Azure;
      this.headerPanel2.CaptionEndColor = Color.SkyBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "FETCH RECORDS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.label15);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnDisplay);
      ((Control) this.headerPanel2).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(6, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(192, 181);
      ((Control) this.headerPanel2).TabIndex = 0;
      this.headerPanel2.TextAntialias = true;
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.AliceBlue;
      this.label15.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(4, 16);
      this.label15.Name = "label15";
      this.label15.Size = new Size(65, 15);
      this.label15.TabIndex = 24;
      this.label15.Text = "LICENSE";
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(73, 12);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(109, 23);
      this.cbShopCodes.TabIndex = 0;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.Azure;
      this.headerPanel1.CaptionEndColor = Color.SkyBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "FILTER RECORDS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbIncludeSameCustomer);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label9);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxSalePriceGold);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label10);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAmountGold);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAmountSilver);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label7);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxSalePriceSilver);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label8);
      ((Control) this.headerPanel1).Controls.Add((Control) this.button2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(203, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(286, 181);
      ((Control) this.headerPanel1).TabIndex = 33;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.Azure;
      this.headerPanel3.CaptionEndColor = Color.SkyBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "NOTICE TYPE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.label17);
      ((Control) this.headerPanel3).Controls.Add((Control) this.cbIntimationOrAuction);
      ((Control) this.headerPanel3).Controls.Add((Control) this.label11);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxPblNo);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxNoticeType);
      ((Control) this.headerPanel3).Controls.Add((Control) this.label14);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxAuctionDate);
      ((Control) this.headerPanel3).Controls.Add((Control) this.label13);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxKdisNo);
      ((Control) this.headerPanel3).Controls.Add((Control) this.label12);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(492, 3);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(270, 181);
      ((Control) this.headerPanel3).TabIndex = 34;
      this.headerPanel3.TextAntialias = true;
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.AliceBlue;
      this.label17.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(15, 22);
      this.label17.Name = "label17";
      this.label17.Size = new Size(83, 15);
      this.label17.TabIndex = 56;
      this.label17.Text = "Notice Type";
      this.cbIntimationOrAuction.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbIntimationOrAuction.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbIntimationOrAuction.BackColor = Color.AliceBlue;
      this.cbIntimationOrAuction.DropDownWidth = 600;
      this.cbIntimationOrAuction.FormattingEnabled = true;
      this.cbIntimationOrAuction.Items.AddRange(new object[2]
      {
        (object) "INTIMATION NOTICE",
        (object) "AUCTION NOTICE"
      });
      this.cbIntimationOrAuction.Location = new Point(103, 18);
      this.cbIntimationOrAuction.Name = "cbIntimationOrAuction";
      this.cbIntimationOrAuction.Size = new Size(156, 23);
      this.cbIntimationOrAuction.TabIndex = 25;
      this.cbIntimationOrAuction.SelectedIndexChanged += new EventHandler(this.cbIntimationOrAuction_SelectedIndexChanged);
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.Azure;
      this.headerPanel4.CaptionEndColor = Color.SkyBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "PENDING PLEDGES LIST";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.dgvNotice);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.GradientEnd = Color.Azure;
      this.headerPanel4.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel4).Location = new Point(6, 190);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(996, 371);
      ((Control) this.headerPanel4).TabIndex = 35;
      this.headerPanel4.TextAntialias = true;
      this.panel2.Anchor = AnchorStyles.Bottom;
      this.panel2.BackColor = Color.Transparent;
      this.panel2.Controls.Add((Control) this.headerPanel7);
      this.panel2.Controls.Add((Control) this.headerPanel5);
      this.panel2.Controls.Add((Control) this.headerPanel6);
      this.panel2.Location = new Point(6, 563);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(996, 60);
      this.panel2.TabIndex = 37;
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
      this.headerPanel7.CaptionText = "PRINT NOTICE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbNoticeType);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Controls.Add((Control) this.btnPrintNotice);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(6, 5);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(307, 52);
      ((Control) this.headerPanel7).TabIndex = 79;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton8).Location = new Point(2, 513);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(128, 35);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&SAVE";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbNoticeType.BackColor = SystemColors.ButtonHighlight;
      this.cbNoticeType.DropDownWidth = 800;
      this.cbNoticeType.FlatStyle = FlatStyle.Flat;
      this.cbNoticeType.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeType.FormattingEnabled = true;
      this.cbNoticeType.Location = new Point(3, 2);
      this.cbNoticeType.Name = "cbNoticeType";
      this.cbNoticeType.Size = new Size(237, 23);
      this.cbNoticeType.TabIndex = 35;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(136, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrintNotice).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrintNotice.BackColor = Color.LightBlue;
      this.btnPrintNotice.FadeOnFocus = true;
      this.btnPrintNotice.ForeColor = Color.MediumBlue;
      this.btnPrintNotice.ForeColorOnFocus = Color.Red;
      this.btnPrintNotice.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrintNotice.GlowColor = Color.White;
      this.btnPrintNotice.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrintNotice).Location = new Point(246, 2);
      ((Control) this.btnPrintNotice).Name = "btnPrintNotice";
      this.btnPrintNotice.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrintNotice.ShineColor = Color.Transparent;
      ((Control) this.btnPrintNotice).Size = new Size(54, 26);
      ((Control) this.btnPrintNotice).TabIndex = 3;
      ((Control) this.btnPrintNotice).Text = "&PRINT";
      ((Control) this.btnPrintNotice).Click += new EventHandler(this.btnPrintNotice_Click);
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel5.CaptionText = "PRINT NOTICE RECORDS";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel5).Controls.Add((Control) this.cbNoticeRecords);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(319, 4);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(351, 52);
      ((Control) this.headerPanel5).TabIndex = 81;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton4).Location = new Point(44, 513);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(128, 35);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&SAVE";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbNoticeRecords.BackColor = SystemColors.ButtonHighlight;
      this.cbNoticeRecords.DropDownWidth = 400;
      this.cbNoticeRecords.FlatStyle = FlatStyle.Flat;
      this.cbNoticeRecords.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeRecords.FormattingEnabled = true;
      this.cbNoticeRecords.Location = new Point(3, 2);
      this.cbNoticeRecords.Name = "cbNoticeRecords";
      this.cbNoticeRecords.Size = new Size(279, 23);
      this.cbNoticeRecords.TabIndex = 35;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(178, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(288, 3);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(55, 20);
      ((Control) this.glassButton6).TabIndex = 3;
      ((Control) this.glassButton6).Text = "&PRINT";
      ((Control) this.glassButton6).Click += new EventHandler(this.glassButton6_Click);
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel6.CaptionText = "PRINT LABELS";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel6).Controls.Add((Control) this.cbCustomerLabels);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(676, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(315, 52);
      ((Control) this.headerPanel6).TabIndex = 80;
      this.headerPanel6.TextAntialias = true;
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
      ((Control) this.glassButton2).Location = new Point(8, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbCustomerLabels.BackColor = SystemColors.ButtonHighlight;
      this.cbCustomerLabels.DropDownWidth = 400;
      this.cbCustomerLabels.FlatStyle = FlatStyle.Flat;
      this.cbCustomerLabels.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbCustomerLabels.FormattingEnabled = true;
      this.cbCustomerLabels.Location = new Point(3, 2);
      this.cbCustomerLabels.Name = "cbCustomerLabels";
      this.cbCustomerLabels.Size = new Size(202, 23);
      this.cbCustomerLabels.TabIndex = 35;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(211, 4);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(96, 20);
      ((Control) this.glassButton1).TabIndex = 34;
      ((Control) this.glassButton1).Text = "PRINT &LABELS";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(142, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.Azure;
      this.headerPanel8.CaptionEndColor = Color.SkyBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "NOTICE SETTING";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbIncludePhoto);
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbIncludeAmountTotal);
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbIncludeNetWeight);
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbLanguage);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxNoticeCharge);
      ((Control) this.headerPanel8).Controls.Add((Control) this.label18);
      ((Control) this.headerPanel8).Controls.Add((Control) this.lblNoticeCharge);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel8.GradientEnd = Color.Azure;
      this.headerPanel8.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel8).Location = new Point(765, 3);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(237, 181);
      ((Control) this.headerPanel8).TabIndex = 56;
      this.headerPanel8.TextAntialias = true;
      this.cbIncludePhoto.AutoSize = true;
      this.cbIncludePhoto.BackColor = Color.Azure;
      this.cbIncludePhoto.Location = new Point(80, 107);
      this.cbIncludePhoto.Name = "cbIncludePhoto";
      this.cbIncludePhoto.Size = new Size(101, 19);
      this.cbIncludePhoto.TabIndex = 61;
      this.cbIncludePhoto.Text = "Include Photo";
      this.cbIncludePhoto.UseVisualStyleBackColor = false;
      this.cbIncludePhoto.CheckedChanged += new EventHandler(this.settingsChanged_CheckedChanged);
      this.cbIncludeAmountTotal.AutoSize = true;
      this.cbIncludeAmountTotal.BackColor = Color.Azure;
      this.cbIncludeAmountTotal.Location = new Point(80, 86);
      this.cbIncludeAmountTotal.Name = "cbIncludeAmountTotal";
      this.cbIncludeAmountTotal.Size = new Size(142, 19);
      this.cbIncludeAmountTotal.TabIndex = 60;
      this.cbIncludeAmountTotal.Text = "Include Amount Total";
      this.cbIncludeAmountTotal.UseVisualStyleBackColor = false;
      this.cbIncludeAmountTotal.CheckedChanged += new EventHandler(this.settingsChanged_CheckedChanged);
      this.cbIncludeNetWeight.AutoSize = true;
      this.cbIncludeNetWeight.BackColor = Color.Azure;
      this.cbIncludeNetWeight.Checked = true;
      this.cbIncludeNetWeight.CheckState = CheckState.Checked;
      this.cbIncludeNetWeight.Location = new Point(80, 65);
      this.cbIncludeNetWeight.Name = "cbIncludeNetWeight";
      this.cbIncludeNetWeight.Size = new Size((int) sbyte.MaxValue, 19);
      this.cbIncludeNetWeight.TabIndex = 59;
      this.cbIncludeNetWeight.Text = "Include NetWeight";
      this.cbIncludeNetWeight.UseVisualStyleBackColor = false;
      this.cbIncludeNetWeight.CheckedChanged += new EventHandler(this.settingsChanged_CheckedChanged);
      this.cbLanguage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLanguage.BackColor = Color.AliceBlue;
      this.cbLanguage.DropDownWidth = 600;
      this.cbLanguage.FormattingEnabled = true;
      this.cbLanguage.Items.AddRange(new object[3]
      {
        (object) "TAMIL",
        (object) "ENGLISH",
        (object) "BOTH"
      });
      this.cbLanguage.Location = new Point(104, 8);
      this.cbLanguage.Name = "cbLanguage";
      this.cbLanguage.Size = new Size(126, 23);
      this.cbLanguage.TabIndex = 57;
      this.cbLanguage.SelectedIndexChanged += new EventHandler(this.cbLanguage_SelectedIndexChanged);
      this.tbxNoticeCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeCharge.Font = new Font("MS Reference Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeCharge.Location = new Point(104, 33);
      this.tbxNoticeCharge.Name = "tbxNoticeCharge";
      this.tbxNoticeCharge.Size = new Size(126, 23);
      this.tbxNoticeCharge.TabIndex = 54;
      this.tbxNoticeCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxNoticeCharge.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.AliceBlue;
      this.label18.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(34, 12);
      this.label18.Name = "label18";
      this.label18.Size = new Size(70, 15);
      this.label18.TabIndex = 58;
      this.label18.Text = "Language";
      this.lblNoticeCharge.AutoSize = true;
      this.lblNoticeCharge.BackColor = Color.AliceBlue;
      this.lblNoticeCharge.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblNoticeCharge.Location = new Point(6, 36);
      this.lblNoticeCharge.Name = "lblNoticeCharge";
      this.lblNoticeCharge.Size = new Size(98, 15);
      this.lblNoticeCharge.TabIndex = 55;
      this.lblNoticeCharge.Text = "Notice Charge";
      this.cbIncludeSameCustomer.AutoSize = true;
      this.cbIncludeSameCustomer.Location = new Point(57, 97);
      this.cbIncludeSameCustomer.Name = "cbIncludeSameCustomer";
      this.cbIncludeSameCustomer.Size = new Size(215, 19);
      this.cbIncludeSameCustomer.TabIndex = 44;
      this.cbIncludeSameCustomer.Text = "Include same customers other bills?";
      this.cbIncludeSameCustomer.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.dataGridView2);
      this.Name = nameof (FormNoticeBasedOnPUreWeight);
      this.Text = "NOTICE";
      this.Load += new EventHandler(this.FormNoticeBasedOnPUreWeight_Load);
      ((ISupportInitialize) this.dgvNotice).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
