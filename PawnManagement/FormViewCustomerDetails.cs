

using CrystalDecisions.CrystalReports.Engine;
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
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement
{
  public class FormViewCustomerDetails : Form
  {
    private bool calculateCompoundInterest = false;
    private ReportDocument rd = new ReportDocument();
    private bool noticeClickedOnce = false;
    private DataTable dtCustomerDetails = new DataTable();
    private double totalAmount = 0.0;
    private double totalInterest = 0.0;
    private double totalAmountRedemption = 0.0;
    private double totalInterestRedemption = 0.0;
    private string CustomerCode = string.Empty;
    private string customerCodeFather = string.Empty;
    private string customerCodeMother = string.Empty;
    private string customerCodeSpouse = string.Empty;
    private string InterestSetting = "";
    private DataTable dtPendingPledgeDetails = new DataTable();
    private DataTable dtRedeemedPledgeDetails = new DataTable();
    private DataTable dtAuctionedPledgeDetails = new DataTable();
    private DataTable dt = new DataTable();
    private DataTable dtPrintNotice = new DataTable();
    private IContainer components = (IContainer) null;
    private TabControl tcSelfDetails;
    private TabPage tpPendingPledges;
    private TabPage tpRedeemedPledges;
    private Panel panel1;
    private Panel panel2;
    private TabPage tpAuctionedPledges;
    private TextBox tbxCustomerCode;
    private PictureBox pictureBox2;
    private DataGridView dgvPendingPledgeDetails;
    private DataGridView dgvRedeemedPledges;
    private DataGridView dgvAuctionedPledges;
    private DataGridView dgvCustomerDetails;
    private TabPage tpCustomerDetails;
    private TextBox tbxName;
    private Label label15;
    private Label label14;
    private Label label8;
    private TextBox tbxOtherProof;
    private TextBox tbxRationCard;
    private TextBox tbxAadharNumber;
    private TextBox tbxInterestRate;
    private TextBox tbxIntroducer;
    private TextBox tbxEmail;
    private Label label12;
    private Label label16;
    private Label label17;
    private PictureBox picProfilePhoto;
    private PictureBox picProofPhoto;
    private PictureBox pictureBox5;
    private TextBox tbxContactNo;
    private PictureBox pictureBox3;
    private TabPage tpSentSms;
    private DataGridView dgvSentSms;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private TabPage tpInterestDeductions;
    private DataGridView dgvInterestDeductions;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton3;
    private GlassButton glassButton6;
    private TextBox textBox3;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox textBox2;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private TextBox textBox1;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton17;
    private GlassButton glassButton18;
    private TextBox tbxAlternateContact;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton15;
    private GlassButton glassButton16;
    private HeaderPanel headerPanel7;
    private RichTextBox richTextBox1;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton7;
    private GlassButton glassButton8;
    private HeaderPanel headerPanel12;
    private GlassButton glassButton23;
    private GlassButton glassButton24;
    private TextBox tbxAverageOfNoOfMonthsForRelease;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton21;
    private GlassButton glassButton22;
    private TextBox tbxNumberOfTimesReleaseExceededTwelveMonths;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton19;
    private GlassButton glassButton20;
    private TextBox tbxNotes;
    private PictureBox pictureBox1;
    private PictureBox pictureBox4;
    private HeaderPanel headerPanel13;
    private GlassButton glassButton25;
    private GlassButton glassButton26;
    private TextBox tbxCustomerName;
    private HeaderPanel headerPanel14;
    private GlassButton glassButton27;
    private ComboBox cbNoticeType;
    private GlassButton glassButton28;
    private GlassButton btnPrintNotice;
    private ToolStripMenuItem selectAllToolStripMenuItem;
    private ToolStripMenuItem unSelectAllToolStripMenuItem;
    private ToolStripMenuItem printToolStripMenuItem;
    private DataGridViewCheckBoxColumn colSelect;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;
    private TabPage tabPage1;
    private DataGridView dgvLastViewed;
    private Panel panel3;
    private TabControl tcSelfFatherMotherSpouse;
    private TabPage tbSelf;
    private TabPage tbFather;
    private TabControl tcFatherDetails;
    private TabPage tabPage2;
    private DataGridView dgvPendingPledgesFather;
    private PictureBox pictureBox6;
    private TabPage tabPage3;
    private DataGridView dgvRedeemedPledgesFather;
    private TabPage tabPage4;
    private DataGridView dgvAuctionedPledgesFather;
    private TabPage tabPage5;
    private TextBox textBox4;
    private PictureBox pictureBox7;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private TextBox textBox9;
    private Label label4;
    private Label label5;
    private Label label6;
    private TabPage tabPage6;
    private DataGridView dgvSentSmsFather;
    private TabPage tabPage7;
    private DataGridView dgvInterestDeductionsFAther;
    private TabPage tabPage8;
    private DataGridView dgvLastViewedFather;
    private TabPage tbMother;
    private TabControl tcMotherDetails;
    private TabPage tabPage9;
    private DataGridView dgvPendingPledgesMother;
    private PictureBox pictureBox8;
    private TabPage tabPage10;
    private DataGridView dgvRedeemedPledgesMother;
    private TabPage tabPage11;
    private DataGridView dgvAuctionedPledgesMother;
    private TabPage tabPage12;
    private TextBox textBox10;
    private PictureBox pictureBox9;
    private Label label7;
    private Label label9;
    private Label label10;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox15;
    private Label label11;
    private Label label13;
    private Label label18;
    private TabPage tabPage13;
    private DataGridView dgvSentSmsMother;
    private TabPage tabPage14;
    private DataGridView dgvInterestDeductionsMother;
    private TabPage tabPage15;
    private DataGridView dgvLastViewedMother;
    private TabPage tpSpouse;
    private TabControl tcSpouseDetails;
    private TabPage tabPage16;
    private DataGridView dgvPendingPledgesSpouse;
    private PictureBox pictureBox10;
    private TabPage tabPage17;
    private DataGridView dgvRedeemedPledgesSpouse;
    private TabPage tabPage18;
    private DataGridView dgvAuctionedPledgesSpouse;
    private TabPage tabPage19;
    private TextBox textBox16;
    private PictureBox pictureBox11;
    private Label label19;
    private Label label20;
    private Label label21;
    private TextBox textBox17;
    private TextBox textBox18;
    private TextBox textBox19;
    private TextBox textBox20;
    private TextBox textBox21;
    private Label label22;
    private Label label23;
    private Label label24;
    private TabPage tabPage20;
    private DataGridView dgvSentSmsSpouse;
    private TabPage tabPage21;
    private DataGridView dgvInterestDeductionsSpouse;
    private TabPage tabPage22;
    private DataGridView dgvLastViewedSpouse;
    private BackgroundWorker bwSelf;
    private BackgroundWorker bwFather;
    private BackgroundWorker bwMother;
    private BackgroundWorker bwSpouse;
    private DataGridViewCheckBoxColumn colSelectFather;
    private DataGridViewCheckBoxColumn colSelectMother;
    private DataGridViewCheckBoxColumn colSelectSpouse;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem calculateCompoundInterestToolStripMenuItem;

    public FormViewCustomerDetails() => this.InitializeComponent();

    public FormViewCustomerDetails(string customerCODE)
    {
      this.CustomerCode = customerCODE;
      this.InitializeComponent();
    }

    private void dgvCustomerDetails_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
          return;
        this.getPicture(this.dgvCustomerDetails.Rows[this.dgvCustomerDetails.CurrentRow.Index].Cells["CID"].Value.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customerPledgeDetails.dgvCustomerDetails_KeyUp", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPicture(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public string getQuery()
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) "ViewCustomer")
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        return " p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber,p.articles,p.PresentValue ,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.CustomerCode,p.customername as nameandaddress,P.PHONENUMBER,p.type";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0 ? dataTable2.Rows[0]["ColumnOrder"].ToString() : " p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber,p.articles,p.PresentValue ,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.CustomerCode,p.customername as nameandaddress,P.PHONENUMBER,p.type";
    }

    private void getCustomerDetails()
    {
      try
      {
        string strError = "";
        this.dt = SQLHelper.GetDataTable("(Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where cid like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where cname like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where cno like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where caddr1 like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where caddr2 like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode,FatherName,Mothername,SpouseName from tblCustomers where cphone like '" + this.tbxCustomerName.Text + "%') ", new List<OleDbParameter>()
        {
          new OleDbParameter("cid", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("cname", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("CPhone", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("CCell", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("CAddr1", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("CAddr2", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%")),
          new OleDbParameter("CAddr3", (object) (this.tbxCustomerName.Text.Trim().ToString() + "%"))
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving data" + strError);
        }
        else if (this.dt != null && this.dt.Rows.Count > 0)
        {
          this.dgvCustomerDetails.Visible = true;
          this.pictureBox2.Visible = true;
          this.dgvCustomerDetails.BringToFront();
          this.dgvCustomerDetails.DataSource = (object) this.dt;
        }
        else
        {
          this.tbxCustomerName.Text = this.tbxCustomerName.Text.Substring(0, this.tbxCustomerName.Text.Length - 1);
          this.tbxCustomerName.Select(this.tbxCustomerName.Text.Length, 0);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxCustomerName_TextChanged(object sender, EventArgs e)
    {
      this.tcSelfDetails.SelectedIndex = 0;
      this.tbxCustomerName.Select();
      if (this.tbxCustomerName.Text != "")
        this.getCustomerDetails();
      else
        this.dgvCustomerDetails.Visible = false;
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormCustomerPledgeDetailss_Load(object sender, EventArgs e)
    {
      this.tbxCustomerName.Select();
      PawnManagementClass.formatDataGridViewControl(ref this.dgvCustomerDetails);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvPendingPledgeDetails);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvAuctionedPledges);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvRedeemedPledges);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvSentSms);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvInterestDeductions);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvLastViewed);
      if (this.CustomerCode != "")
      {
        this.tbxCustomerCode.Text = this.CustomerCode;
        this.getCustomerDetails(this.CustomerCode);
        this.getDataGridViews();
      }
      this.getReportTypes();
      this.getReportTypesCustomerReports();
      this.getInterestSetting();
      if (this.cbNoticeType.Items.Count <= 0)
        return;
      this.cbNoticeType.SelectedIndex = 0;
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
        if (dataTable2.Rows[0]["ViewCustomerScreen"] != null && dataTable2.Rows[0]["ViewCustomerScreen"].ToString() != "")
        {
          this.InterestSetting = dataTable2.Rows[0]["ViewCustomerScreen"].ToString();
          if (dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"] != null && dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"].ToString() != "" && dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"].ToString() == "COMPOUND")
            this.calculateCompoundInterest = true;
        }
      }
      else
        this.InterestSetting = "Interest Setting";
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Notice\\\\", "*.rpt"))
        this.cbNoticeType.Items.Add(file);
    }

    private void getReportTypesCustomerReports()
    {
      string[] files = Directory.GetFiles("Reports\\\\CustomerReports\\\\All\\\\", "*.rpt");
      string[] strArray = File.ReadAllLines("Reports\\CustomerReports\\All\\LastUsed.txt");
      foreach (string text in files)
        this.printToolStripMenuItem.DropDownItems.Add((ToolStripItem) new ToolStripMenuItem(text));
      foreach (ToolStripDropDownItem dropDownItem in (ArrangedElementCollection) this.printToolStripMenuItem.DropDownItems)
      {
        if (dropDownItem.Text == strArray[0].ToString())
          dropDownItem.ForeColor = Color.Blue;
      }
      foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) this.printToolStripMenuItem.DropDownItems)
        dropDownItem.Click += new EventHandler(this.t_Click);
    }

    private void t_Click(object sender, EventArgs e)
    {
      this.printcustomerDetails((sender as ToolStripMenuItem).Text);
      File.WriteAllText("Reports\\\\CustomerReports\\\\All\\\\LastUsed.txt", (sender as ToolStripMenuItem).Text);
    }

    private void getCustomerDetails(string customerCode)
    {
      try
      {
        string strError = "";
        this.dtCustomerDetails = SQLHelper.GetDataTable("Select * from tblcustomers where cid = @cid", new List<OleDbParameter>()
        {
          new OleDbParameter("cid", (object) customerCode)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails(string customecode)", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form customerPledgeDetails.getCustomerDetails(string customecode)" + strError);
        }
        else
        {
          this.tbxName.Text = this.dtCustomerDetails.Rows[0].Field<string>("CName");
          this.richTextBox1.Text = this.dtCustomerDetails.Rows[0].Field<string>("Cno") + " " + this.dtCustomerDetails.Rows[0].Field<string>("CAddr1") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CAddr2") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CAddr3") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CCity") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CPinCode");
          this.tbxContactNo.Text = this.dtCustomerDetails.Rows[0].Field<string>("CPhone");
          this.tbxAlternateContact.Text = this.dtCustomerDetails.Rows[0].Field<string>("CCell");
          this.tbxEmail.Text = this.dtCustomerDetails.Rows[0].Field<string>("CEmail");
          this.tbxInterestRate.Text = this.dtCustomerDetails.Rows[0].Field<string>("CInterestRate");
          this.tbxIntroducer.Text = this.dtCustomerDetails.Rows[0].Field<string>("CIntroducer");
          this.tbxNotes.Text = this.dtCustomerDetails.Rows[0].Field<string>("CNotes");
          this.tbxAadharNumber.Text = this.dtCustomerDetails.Rows[0].Field<string>("Caadharnumber");
          this.tbxRationCard.Text = this.dtCustomerDetails.Rows[0].Field<string>("Crationcard");
          this.tbxOtherProof.Text = this.dtCustomerDetails.Rows[0].Field<string>("Cotherproof");
        }
        this.tbxAverageOfNoOfMonthsForRelease.Text = PawnManagementClass.averageOfNumberOfMonthsForRelease(this.tbxCustomerCode.Text.Trim().ToString());
        this.tbxNumberOfTimesReleaseExceededTwelveMonths.Text = PawnManagementClass.numberOfTimesReleaseExceededTwelveMonths(this.tbxCustomerCode.Text.Trim().ToString());
        if (File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
        }
        if (File.Exists(FormMain.startUpPath + "Photos\\proof\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\proof\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            this.picProofPhoto.Image = Image.FromStream((Stream) fileStream);
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
            this.picProofPhoto.Image = Image.FromStream((Stream) fileStream);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails(string customecode) outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dgvCustomerDetails_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvCustomerDetails.Rows[0].Selected)
          this.tbxCustomerName.Select();
        if (e.KeyCode != Keys.Return)
          return;
        int index = this.dgvCustomerDetails.CurrentRow.Index;
        this.CustomerCode = this.dgvCustomerDetails.Rows[index].Cells["CID"].Value.ToString();
        this.customerCodeFather = this.dgvCustomerDetails.Rows[index].Cells["FatherName"].Value.ToString();
        this.customerCodeMother = this.dgvCustomerDetails.Rows[index].Cells["MotherName"].Value.ToString();
        this.customerCodeSpouse = this.dgvCustomerDetails.Rows[index].Cells["SpousenAME"].Value.ToString();
        this.tbxCustomerCode.Text = this.CustomerCode;
        this.getCustomerDetails(this.CustomerCode);
        this.dgvCustomerDetails.Visible = false;
        this.pictureBox2.Visible = false;
        this.getDataGridViews();
        PawnManagementClass.InsertIntoHistory("VIEW CUSTOMER PLEDGE DETAILS", this.tbxCustomerCode.Text.Trim().ToString() + "Customer pledge Details  Viewed", "", "", FormMain.username, DateTime.Now.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getDataGridViewsFather()
    {
      if (!(this.customerCodeFather != ""))
        return;
      this.dgvAuctionedPledgesFather.DataSource = (object) this.getAuctionedPledgeDetails(this.customerCodeFather);
      this.dgvRedeemedPledgesFather.DataSource = (object) this.getRedeemedPledges(this.customerCodeFather);
      this.bwFather.RunWorkerAsync((object) new object[1]
      {
        (object) this.customerCodeFather
      });
      this.dgvSentSmsFather.DataSource = (object) this.getSentSms(this.customerCodeFather);
      this.dgvInterestDeductionsFAther.DataSource = (object) this.getInterestDeductionsByCustomer(this.customerCodeFather);
      this.dgvLastViewedFather.DataSource = (object) this.getLastViewedDetails(this.customerCodeFather);
    }

    private void getDataGridViewsMother()
    {
      if (!(this.customerCodeMother != ""))
        return;
      this.dgvAuctionedPledgesMother.DataSource = (object) this.getAuctionedPledgeDetails(this.customerCodeMother);
      this.dgvRedeemedPledgesMother.DataSource = (object) this.getRedeemedPledges(this.customerCodeMother);
      this.bwMother.RunWorkerAsync((object) new object[1]
      {
        (object) this.customerCodeMother
      });
      this.dgvSentSmsMother.DataSource = (object) this.getSentSms(this.customerCodeMother);
      this.dgvInterestDeductionsMother.DataSource = (object) this.getInterestDeductionsByCustomer(this.customerCodeMother);
      this.dgvLastViewedMother.DataSource = (object) this.getLastViewedDetails(this.customerCodeMother);
    }

    private void getDataGridViewsSpouse()
    {
      if (!(this.customerCodeSpouse != ""))
        return;
      this.dgvAuctionedPledgesSpouse.DataSource = (object) this.getAuctionedPledgeDetails(this.customerCodeSpouse);
      this.dgvRedeemedPledgesSpouse.DataSource = (object) this.getRedeemedPledges(this.customerCodeSpouse);
      this.bwSpouse.RunWorkerAsync((object) new object[1]
      {
        (object) this.customerCodeSpouse
      });
      this.dgvSentSmsSpouse.DataSource = (object) this.getSentSms(this.customerCodeSpouse);
      this.dgvInterestDeductionsSpouse.DataSource = (object) this.getInterestDeductionsByCustomer(this.customerCodeSpouse);
      this.dgvLastViewedSpouse.DataSource = (object) this.getLastViewedDetails(this.customerCodeSpouse);
    }

    private void getDataGridViews()
    {
      if (this.CustomerCode == null || !(this.CustomerCode != ""))
        return;
      this.dgvAuctionedPledges.DataSource = (object) this.getAuctionedPledgeDetails(this.CustomerCode);
      this.dgvRedeemedPledges.DataSource = (object) this.getRedeemedPledges(this.CustomerCode);
      this.bwSelf.RunWorkerAsync((object) new object[1]
      {
        (object) this.CustomerCode
      });
      this.dgvSentSms.DataSource = (object) this.getSentSms(this.CustomerCode);
      this.dgvInterestDeductions.DataSource = (object) this.getInterestDeductionsByCustomer(this.CustomerCode);
      this.dgvLastViewed.DataSource = (object) this.getLastViewedDetails(this.CustomerCode);
    }

    private DataTable getLastViewedDetails(string customerCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select *  from tblHistory where ActionPipe = @ActionPipe  and ActionDetails like @ActionDetails order by performedon desc";
        DataTable dataTable = new DataTable();
        return SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ActionPipe", (object) "VIEW CUSTOMER PLEDGE DETAILS"),
          new OleDbParameter("ActionDetails", (object) (customerCode + "%"))
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.refreshgrid1", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private DataTable getInterestDeductionsByCustomer(string customerCode)
    {
      string strError = "";
      string my_querry = "select BillNumber,BillDate,temp2 as interest,noticecharge,othercharges,Discount, temp3 as finalinterest from tblPledge where CustomerCode = @customerCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (customerCode), (object) this.CustomerCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form viewcustomerDetails.void getInterestDeductionsByCustomer(string customerCode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form viewcustomerDetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        double num = 0.0;
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          if (row["Discount"] == null | !PawnManagementClass.IsDigitsOnly(row["discount"].ToString()))
            row["Discount"] = (object) 0;
          num += double.Parse(row["discount"].ToString());
        }
        dataTable2.Rows.Add();
        dataTable2.Rows[dataTable2.Rows.Count - 1]["BILLNUMBER"] = (object) "TOTAL";
        dataTable2.Rows[dataTable2.Rows.Count - 1]["discount"] = (object) num.ToString();
      }
      return dataTable2;
    }

    private DataTable getSentSms(string customerCode)
    {
      string strError = "";
      string my_querry = "select * from tblSentSms where CustomerCode = @customerCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (customerCode), (object) customerCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form viewcustomerDetails.getsentsms()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form viewcustomerDetails.getsentsms()");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          row["senttime"] = (object) DateTime.Parse(row["senttime"].ToString()).ToShortTimeString();
      }
      return dataTable2;
    }

    private DataTable getRedeemedPledges(string CustomerCode)
    {
      if (FormMain.memberType != "ak")
      {
        string strError = "";
        string str = "";
        DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
        if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
          str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
        this.dtRedeemedPledgeDetails = SQLHelper.GetDataTable("select p.shopCode,p.BillNumber,p.BillDate,p.Amount," + str + ",p.temp3 as FinalInterest,p.temp4 as RedemptionAmount,p.RedemptionDate,p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.temp2 as Interest,noticecharge,otherchargeS,InterestLess,Discount from tblPledge p where p.CustomerCode =@CustomerCode and p.Redeemed ='Y' order by p.BillDate", new List<OleDbParameter>()
        {
          new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
        }, ref strError);
        return this.dtRedeemedPledgeDetails;
      }
      if (!(FormMain.memberType == "ak"))
        return this.dtRedeemedPledgeDetails;
      string strError1 = "";
      string str1 = "";
      DataTable articlesSettings1 = PawnManagementClass.getArticlesSettings();
      if (articlesSettings1.Rows[0]["ViewCustomersScreen"] != null)
        str1 = "p." + articlesSettings1.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      string my_querry = "select p.shopCode,p.BillNumber,p.BillDate,p.Amount," + str1 + ",p.Interest16 as Interest,p.RedemptionAmount16 as  redemptionamount,p.RedemptionDate,p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='Y'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable = new DataTable();
      this.dtRedeemedPledgeDetails = SQLHelper.GetDataTable(my_querry, parameters, ref strError1);
      return this.dtRedeemedPledgeDetails;
    }

    private DataTable getPendingPledgeDetails(string CustomerCode)
    {
      string strError = "";
      string newValue = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        newValue = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      string my_querry = "select " + this.getQuery().Replace("p.articles", newValue) + " from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='N' order by p.billdate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable = new DataTable();
      this.dtPendingPledgeDetails = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form customerPledgeDetails.getCstomerPledgeDetails(stirng customerCode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        return this.dtPendingPledgeDetails;
      }
      if (this.dtPendingPledgeDetails != null && this.dtPendingPledgeDetails.Rows.Count > 0 && this.InterestSetting == "INTEREST SETTING")
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dtPendingPledgeDetails.Rows)
          row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
      }
      this.dtPendingPledgeDetails.Columns.Add("Interest", typeof (double));
      for (int index = 0; index < this.dtPendingPledgeDetails.Rows.Count; ++index)
      {
        DateTime.Parse(this.dtPendingPledgeDetails.Rows[index]["BillDate"].ToString());
        int num = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.dtPendingPledgeDetails.Rows[index]["BillDate"].ToString()), DateTime.Today) - 1;
        if (num != -1)
          this.dtPendingPledgeDetails.Rows[index]["Interest"] = (object) Math.Round(double.Parse(this.dtPendingPledgeDetails.Rows[index]["Amount"].ToString()) * double.Parse(this.dtPendingPledgeDetails.Rows[index]["InterestRate"].ToString()) * (double) num / 1200.0, 2);
      }
      return this.dtPendingPledgeDetails;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        this.dgvPendingPledgeDetails.DataSource = (object) (e.Result as DataTable);
        this.dgvPendingPledgeDetails.Visible = true;
        this.dgvPendingPledgeDetails.Columns["Interest"].DisplayIndex = 1;
        this.dgvPendingPledgeDetails.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvPendingPledgeDetails.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgeDetails.Rows)
        {
          row.Cells["colSelect"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvPendingPledgeDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgeDetails.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.getPendingPledgesCompleteTotal();
      }
      else if (!(e.Result is Exception))
        ;
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        string str = ((object[]) e.Argument)[0].ToString();
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery().Replace("articles", newValue) + " from tblPledge P where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) str));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getCustomerpledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        }
        else
        {
          dataTable2.Columns.Add("Interest", typeof (double));
          dataTable2.Columns.Add("NoOfMonths", typeof (double));
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            if (this.InterestSetting == "INTEREST SETTING")
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
                row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
            }
            this.totalAmount = 0.0;
            this.totalInterest = 0.0;
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            {
              DateTime.Parse(row["BillDate"].ToString());
              int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
              row["NoOfMonths"] = (object) numberOfMonths;
              int n = numberOfMonths - 1;
              if (n != -1)
                row["Interest"] = n <= 11 ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (!this.calculateCompoundInterest ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (object) PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString())).ToString());
            }
          }
        }
        e.Result = (object) dataTable2;
      }
      catch (Exception ex)
      {
        e.Result = (object) ex;
      }
    }

    private void bwFather_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        this.dgvPendingPledgesFather.DataSource = (object) (e.Result as DataTable);
        this.dgvPendingPledgesFather.Visible = true;
        this.dgvPendingPledgesFather.Columns["Interest"].DisplayIndex = 1;
        this.dgvPendingPledgesFather.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvPendingPledgesFather.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesFather.Rows)
        {
          row.Cells["colSelectFather"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvPendingPledgesFather.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesFather.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.getPendingPledgesCompleteTotalFather();
      }
      else if (!(e.Result is Exception))
        ;
    }

    private void bwFather_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        string str = ((object[]) e.Argument)[0].ToString();
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery().Replace("articles", newValue) + " from tblPledge P where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) str));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getCustomerpledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        }
        else
        {
          dataTable2.Columns.Add("Interest", typeof (double));
          dataTable2.Columns.Add("NoOfMonths", typeof (double));
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            if (this.InterestSetting == "INTEREST SETTING")
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
                row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
            }
            this.totalAmount = 0.0;
            this.totalInterest = 0.0;
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            {
              DateTime.Parse(row["BillDate"].ToString());
              int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
              row["NoOfMonths"] = (object) numberOfMonths;
              int num = numberOfMonths - 1;
              if (num != -1)
                row["Interest"] = (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) num / 1200.0);
            }
          }
        }
        e.Result = (object) dataTable2;
      }
      catch (Exception ex)
      {
        e.Result = (object) ex;
      }
    }

    private void bwMother_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        this.dgvPendingPledgesMother.DataSource = (object) (e.Result as DataTable);
        this.dgvPendingPledgesMother.Visible = true;
        this.dgvPendingPledgesMother.Columns["Interest"].DisplayIndex = 1;
        this.dgvPendingPledgesMother.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvPendingPledgesMother.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesMother.Rows)
        {
          row.Cells["colSelectMother"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvPendingPledgesMother.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesMother.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.getPendingPledgesCompleteTotalMother();
      }
      else if (!(e.Result is Exception))
        ;
    }

    private void bwMother_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        string str = ((object[]) e.Argument)[0].ToString();
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery().Replace("articles", newValue) + " from tblPledge P where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) str));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getCustomerpledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        }
        else
        {
          dataTable2.Columns.Add("Interest", typeof (double));
          dataTable2.Columns.Add("NoOfMonths", typeof (double));
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            if (this.InterestSetting == "INTEREST SETTING")
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
                row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
            }
            this.totalAmount = 0.0;
            this.totalInterest = 0.0;
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            {
              DateTime.Parse(row["BillDate"].ToString());
              int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
              row["NoOfMonths"] = (object) numberOfMonths;
              int num = numberOfMonths - 1;
              if (num != -1)
                row["Interest"] = (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) num / 1200.0);
            }
          }
        }
        e.Result = (object) dataTable2;
      }
      catch (Exception ex)
      {
        e.Result = (object) ex;
      }
    }

    private void bwSpouse_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        this.dgvPendingPledgesSpouse.DataSource = (object) (e.Result as DataTable);
        this.dgvPendingPledgesSpouse.Visible = true;
        this.dgvPendingPledgesSpouse.Columns["Interest"].DisplayIndex = 1;
        this.dgvPendingPledgesSpouse.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvPendingPledgesSpouse.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesSpouse.Rows)
        {
          row.Cells["colSelectSpouse"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvPendingPledgesSpouse.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvPendingPledgesSpouse.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.getPendingPledgesCompleteTotalSpouse();
      }
      else if (!(e.Result is Exception))
        ;
    }

    private void bwSpouse_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        string str = ((object[]) e.Argument)[0].ToString();
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery().Replace("articles", newValue) + " from tblPledge P where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) str));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getCustomerpledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        }
        else
        {
          dataTable2.Columns.Add("Interest", typeof (double));
          dataTable2.Columns.Add("NoOfMonths", typeof (double));
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            if (this.InterestSetting == "INTEREST SETTING")
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
                row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
            }
            this.totalAmount = 0.0;
            this.totalInterest = 0.0;
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            {
              DateTime.Parse(row["BillDate"].ToString());
              int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
              row["NoOfMonths"] = (object) numberOfMonths;
              int num = numberOfMonths - 1;
              if (num != -1)
                row["Interest"] = (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) num / 1200.0);
            }
          }
        }
        e.Result = (object) dataTable2;
      }
      catch (Exception ex)
      {
        e.Result = (object) ex;
      }
    }

    private DataTable getAuctionedPledgeDetails(string CustomerCode)
    {
      if (FormMain.memberType != "ak")
      {
        string strError = "";
        string str = "";
        DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
        if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
          str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
        this.dtAuctionedPledgeDetails = SQLHelper.GetDataTable("select p.shopCode,p.BillNumber,p.BillDate,p.Amount," + str + ",p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.temp2 as Interest,AuctionDate,AuctionAmount,KdisNumber,PurchasedBy,AuctionedBy from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='A'", new List<OleDbParameter>()
        {
          new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
        }, ref strError);
        return this.dtAuctionedPledgeDetails;
      }
      if (!(FormMain.memberType == "ak"))
        return this.dtAuctionedPledgeDetails;
      string strError1 = "";
      string str1 = "";
      DataTable articlesSettings1 = PawnManagementClass.getArticlesSettings();
      if (articlesSettings1.Rows[0]["ViewCustomersScreen"] != null)
        str1 = "p." + articlesSettings1.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      this.dtAuctionedPledgeDetails = SQLHelper.GetDataTable("select p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.INTEREST16 as interest," + str1 + ",p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='A'", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
      }, ref strError1);
      return this.dtAuctionedPledgeDetails;
    }

    private void tbxCustomerName_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dgvCustomerDetails == null || this.dgvCustomerDetails.Rows.Count <= 0)
        return;
      this.dgvCustomerDetails.Select();
      this.dgvCustomerDetails.Rows[0].Selected = true;
    }

    private void getRedeemedPledgesTotal()
    {
      this.totalAmountRedemption = 0.0;
      this.totalInterestRedemption = 0.0;
      if (FormMain.memberType != "ak")
      {
        foreach (DataGridViewRow row in (IEnumerable) this.dgvRedeemedPledges.Rows)
        {
          this.totalAmountRedemption += double.Parse(row.Cells["amount"].Value.ToString());
          this.totalInterestRedemption += double.Parse(row.Cells["finalinterest"].Value.ToString());
        }
        this.textBox1.Text = this.totalAmountRedemption.ToString("F");
        this.textBox2.Text = this.totalInterestRedemption.ToString("F");
        this.textBox3.Text = (this.totalAmountRedemption + this.totalInterestRedemption).ToString("F");
      }
      if (!(FormMain.memberType == "ak"))
        return;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvRedeemedPledges.Rows)
      {
        this.totalAmountRedemption += double.Parse(row.Cells["amount"].Value.ToString());
        this.totalInterestRedemption += double.Parse(row.Cells["interest"].Value.ToString());
      }
      this.textBox1.Text = this.totalAmountRedemption.ToString("F");
      this.textBox2.Text = this.totalInterestRedemption.ToString("F");
      this.textBox3.Text = (this.totalAmountRedemption + this.totalInterestRedemption).ToString("F");
    }

    private void tpRedeemedPledges_Click(object sender, EventArgs e) => this.getRedeemedPledgesTotal();

    private void pictureBox3_Click(object sender, EventArgs e)
    {
      if (this.tbxContactNo.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxContactNo.Text) && this.tbxContactNo.Text.Count<char>() == 10)
      {
        int num1 = (int) new FormCall(this.tbxContactNo.Text.ToString()).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      if (this.tbxContactNo.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxContactNo.Text) && this.tbxContactNo.Text.Count<char>() == 10)
      {
        FormSendSMS formSendSms = new FormSendSMS();
        formSendSms.LoadNotice(this.dtCustomerDetails, "cid", "CPhone", new List<string>()
        {
          "cid",
          "CPhone",
          "CName"
        });
        int num = (int) formSendSms.ShowDialog();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) && new FolderBrowserDialog().ShowDialog() == DialogResult.OK)
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void picProfilePhoto_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void picProofPhoto_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\proof\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void pictureBox3_MouseEnter(object sender, EventArgs e)
    {
      (sender as PictureBox).Height = (sender as PictureBox).Height + 10;
      (sender as PictureBox).Width = (sender as PictureBox).Width + 10;
    }

    private void pictureBox3_MouseLeave(object sender, EventArgs e)
    {
      (sender as PictureBox).Height = (sender as PictureBox).Height - 10;
      (sender as PictureBox).Width = (sender as PictureBox).Width - 10;
    }

    private void pictureBox5_MouseEnter(object sender, EventArgs e)
    {
      (sender as PictureBox).Height = (sender as PictureBox).Height + 10;
      (sender as PictureBox).Width = (sender as PictureBox).Width + 10;
    }

    private void pictureBox5_MouseLeave_1(object sender, EventArgs e)
    {
      (sender as PictureBox).Height = (sender as PictureBox).Height - 10;
      (sender as PictureBox).Width = (sender as PictureBox).Width - 10;
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.DisplayedCells)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void dgvCustomerRedeemedDetails_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      this.getRedeemedPledgesTotal();
    }

    private void dgvCustomerDetails_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerDetails.Rows)
      {
        if (!row.Cells["CName"].Value.ToString().StartsWith(this.tbxCustomerName.Text))
          break;
        row.DefaultCellStyle.ForeColor = Color.Blue;
      }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (this.tbxAlternateContact.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxAlternateContact.Text) && this.tbxAlternateContact.Text.Count<char>() == 10)
      {
        FormSendSMS formSendSms = new FormSendSMS();
        formSendSms.LoadNotice(this.dtCustomerDetails, "cid", "CCell", new List<string>()
        {
          "cid",
          "CCell",
          "CName"
        });
        int num = (int) formSendSms.ShowDialog();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      if (this.tbxAlternateContact.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxAlternateContact.Text) && this.tbxAlternateContact.Text.Count<char>() == 10)
      {
        int num1 = (int) new FormCall(this.tbxAlternateContact.Text.ToString()).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid Mobile Number");
      }
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
      foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgeDetails.Rows)
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

    private void btnPrintNotice_Click(object sender, EventArgs e)
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

    private void dgvPendingPledgeDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (this.dgvPendingPledgeDetails.IsCurrentCellDirty)
        this.dgvPendingPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void getPendingPledgesCompleteTotal()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgeDetails.Rows)
        {
          if (row.Cells["colSelect"] != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
          {
            this.totalAmount += Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()));
            this.totalInterest += Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()));
          }
        }
        this.textBox1.Text = this.totalAmount.ToString("F");
        this.textBox2.Text = this.totalInterest.ToString("F");
        this.textBox3.Text = (this.totalAmount + this.totalInterest).ToString("F");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPendingPledgesCompleteTotalFather()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesFather.Rows)
        {
          if (row.Cells["colSelectFAther"] != null && bool.Parse(row.Cells["colSelectFather"].Value.ToString()))
          {
            this.totalAmount += Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()));
            this.totalInterest += Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()));
          }
        }
        this.textBox1.Text = this.totalAmount.ToString("F");
        this.textBox2.Text = this.totalInterest.ToString("F");
        this.textBox3.Text = (this.totalAmount + this.totalInterest).ToString("F");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPendingPledgesCompleteTotalMother()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesMother.Rows)
        {
          if (row.Cells["colSelectMother"] != null && bool.Parse(row.Cells["colSelectMother"].Value.ToString()))
          {
            this.totalAmount += Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()));
            this.totalInterest += Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()));
          }
        }
        this.textBox1.Text = this.totalAmount.ToString("F");
        this.textBox2.Text = this.totalInterest.ToString("F");
        this.textBox3.Text = (this.totalAmount + this.totalInterest).ToString("F");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPendingPledgesCompleteTotalSpouse()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvPendingPledgesSpouse.Rows)
        {
          if (row.Cells["colSelectSpouse"] != null && bool.Parse(row.Cells["colSelectSpouse"].Value.ToString()))
          {
            this.totalAmount += Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()));
            this.totalInterest += Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()));
          }
        }
        this.textBox1.Text = this.totalAmount.ToString("F");
        this.textBox2.Text = this.totalInterest.ToString("F");
        this.textBox3.Text = (this.totalAmount + this.totalInterest).ToString("F");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvPendingPledgeDetails.Rows.Count; ++index)
      {
        this.dgvPendingPledgeDetails.Rows[index].Cells["COLselect"].Value = (object) true;
        this.dgvPendingPledgeDetails.Rows[index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
      }
      this.dgvPendingPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void unSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvPendingPledgeDetails.Rows.Count; ++index)
      {
        this.dgvPendingPledgeDetails.Rows[index].Cells["COLselect"].Value = (object) false;
        this.dgvPendingPledgeDetails.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
      }
      this.dgvPendingPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      this.dgvPendingPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      if (this.dgvPendingPledgeDetails.Rows.Count <= 0)
        return;
      if (this.dgvPendingPledgeDetails.CurrentCell.OwningColumn.HeaderText == "CustomerCode")
      {
        string CUSTOMERCODE = this.dgvPendingPledgeDetails.Rows[this.dgvPendingPledgeDetails.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dgvPendingPledgeDetails.CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) (this.dgvPendingPledgeDetails.Location.Y + this.dgvPendingPledgeDetails.Size.Width);
        string BILLNUMBER = this.dgvPendingPledgeDetails.Rows[this.dgvPendingPledgeDetails.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dgvPendingPledgeDetails.Rows[this.dgvPendingPledgeDetails.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvPendingPledgeDetails.Rows.Count <= 0)
        return;
      if (this.dgvPendingPledgeDetails.Columns[e.ColumnIndex].HeaderText == "BillNumber" | this.dgvPendingPledgeDetails.Columns[e.ColumnIndex].Name == "CustomerCode" | this.dgvPendingPledgeDetails.Columns[e.ColumnIndex].Name == "billnumber")
        this.dgvPendingPledgeDetails.Cursor = Cursors.Hand;
      else
        this.dgvPendingPledgeDetails.Cursor = Cursors.Default;
    }

    private void dgvCustomerRedeemedDetails_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvRedeemedPledges.Rows.Count <= 0 || !(this.dgvRedeemedPledges.CurrentCell.OwningColumn.HeaderText == "BillNumber"))
        return;
      double num = (double) (this.dgvRedeemedPledges.Location.Y + this.dgvRedeemedPledges.Size.Width);
      string BILLNUMBER = this.dgvRedeemedPledges.Rows[this.dgvRedeemedPledges.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dgvRedeemedPledges.Rows[this.dgvRedeemedPledges.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "")
        new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
    }

    private void dgvCustomerRedeemedDetails_CellMouseEnter(
      object sender,
      DataGridViewCellEventArgs e)
    {
      if (this.dgvRedeemedPledges.Rows.Count <= 0)
        return;
      if (this.dgvRedeemedPledges.Columns[e.ColumnIndex].HeaderText == "BillNumber" | this.dgvRedeemedPledges.Columns[e.ColumnIndex].Name == "CustomerCode" | this.dgvRedeemedPledges.Columns[e.ColumnIndex].Name == "billnumber")
        this.dgvRedeemedPledges.Cursor = Cursors.Hand;
      else
        this.dgvRedeemedPledges.Cursor = Cursors.Default;
    }

    private void dgvAuctionedPledges_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvAuctionedPledges.Rows.Count <= 0 || !(this.dgvAuctionedPledges.CurrentCell.OwningColumn.HeaderText == "BillNumber"))
        return;
      double num = (double) (this.dgvAuctionedPledges.Location.Y + this.dgvAuctionedPledges.Size.Width);
      string BILLNUMBER = this.dgvAuctionedPledges.Rows[this.dgvAuctionedPledges.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dgvAuctionedPledges.Rows[this.dgvAuctionedPledges.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "")
        new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
    }

    private void dgvAuctionedPledges_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvAuctionedPledges.Rows.Count <= 0)
        return;
      if (this.dgvAuctionedPledges.Columns[e.ColumnIndex].HeaderText == "BillNumber" | this.dgvAuctionedPledges.Columns[e.ColumnIndex].Name == "CustomerCode" | this.dgvAuctionedPledges.Columns[e.ColumnIndex].Name == "billnumber")
        this.dgvAuctionedPledges.Cursor = Cursors.Hand;
      else
        this.dgvAuctionedPledges.Cursor = Cursors.Default;
    }

    private void printToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void printcustomerDetails(string ReportName)
    {
      string strError = "";
      string my_querry = "select * from tblCustomers where Cid = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) this.tbxCustomerCode.Text));
      this.dt = new DataTable();
      this.dt = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        row["CImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + row["CID"].ToString() + ".png");
      this.rd.Load(ReportName);
      this.rd.SetDataSource(this.dt);
      if (ReportName.Contains("Pending"))
        this.rd.Subreports[0].SetDataSource(this.dtPendingPledgeDetails);
      else if (ReportName.Contains("Redeemed"))
        this.rd.Subreports["subreportRedeemedPledges"].SetDataSource(this.dtRedeemedPledgeDetails);
      else if (ReportName.Contains("Auctioned"))
      {
        this.rd.Subreports["subreportAuctionedPledges"].SetDataSource(this.dtAuctionedPledgeDetails);
      }
      else
      {
        this.rd.Subreports[0].SetDataSource(this.dtPendingPledgeDetails);
        this.rd.Subreports["subreportRedeemedPledges"].SetDataSource(this.dtRedeemedPledgeDetails);
        this.rd.Subreports["subreportAuctionedPledges"].SetDataSource(this.dtAuctionedPledgeDetails);
      }
      int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
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

    private void calculateCompoundInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.calculateCompoundInterest = true;
      this.getDataGridViews();
    }

    private void changeColumnOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormColumnOrder("ViewCustomer").ShowDialog();
      this.Close();
    }

    private void tbMother_Click(object sender, EventArgs e) => this.getDataGridViewsMother();

    private void tbFather_Click(object sender, EventArgs e) => this.getDataGridViewsFather();

    private void tpSpouse_Click(object sender, EventArgs e) => this.getDataGridViewsSpouse();

    private void tcFather_Click(object sender, EventArgs e)
    {
      if (this.tcSelfFatherMotherSpouse.SelectedTab == this.tbFather)
        this.getDataGridViewsFather();
      else if (this.tcSelfFatherMotherSpouse.SelectedTab == this.tbMother)
      {
        this.getDataGridViewsMother();
      }
      else
      {
        if (this.tcSelfFatherMotherSpouse.SelectedTab != this.tpSpouse)
          return;
        this.getDataGridViewsSpouse();
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
      this.tcSelfDetails = new TabControl();
      this.tpPendingPledges = new TabPage();
      this.dgvPendingPledgeDetails = new DataGridView();
      this.colSelect = new DataGridViewCheckBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new ToolStripMenuItem();
      this.unSelectAllToolStripMenuItem = new ToolStripMenuItem();
      this.printToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.calculateCompoundInterestToolStripMenuItem = new ToolStripMenuItem();
      this.pictureBox2 = new PictureBox();
      this.tpRedeemedPledges = new TabPage();
      this.dgvRedeemedPledges = new DataGridView();
      this.tpAuctionedPledges = new TabPage();
      this.dgvAuctionedPledges = new DataGridView();
      this.tpCustomerDetails = new TabPage();
      this.tbxEmail = new TextBox();
      this.picProofPhoto = new PictureBox();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label12 = new Label();
      this.tbxIntroducer = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.tbxAadharNumber = new TextBox();
      this.tbxRationCard = new TextBox();
      this.tbxOtherProof = new TextBox();
      this.label15 = new Label();
      this.label8 = new Label();
      this.label14 = new Label();
      this.tpSentSms = new TabPage();
      this.dgvSentSms = new DataGridView();
      this.tpInterestDeductions = new TabPage();
      this.dgvInterestDeductions = new DataGridView();
      this.tabPage1 = new TabPage();
      this.dgvLastViewed = new DataGridView();
      this.dgvCustomerDetails = new DataGridView();
      this.picProfilePhoto = new PictureBox();
      this.panel1 = new Panel();
      this.headerPanel13 = new HeaderPanel();
      this.glassButton25 = new GlassButton();
      this.glassButton26 = new GlassButton();
      this.tbxCustomerName = new TextBox();
      this.headerPanel12 = new HeaderPanel();
      this.glassButton23 = new GlassButton();
      this.glassButton24 = new GlassButton();
      this.tbxAverageOfNoOfMonthsForRelease = new TextBox();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton21 = new GlassButton();
      this.glassButton22 = new GlassButton();
      this.tbxNumberOfTimesReleaseExceededTwelveMonths = new TextBox();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton19 = new GlassButton();
      this.glassButton20 = new GlassButton();
      this.tbxNotes = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.headerPanel9 = new HeaderPanel();
      this.glassButton17 = new GlassButton();
      this.glassButton18 = new GlassButton();
      this.tbxAlternateContact = new TextBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton15 = new GlassButton();
      this.glassButton16 = new GlassButton();
      this.tbxContactNo = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.richTextBox1 = new RichTextBox();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tbxCustomerCode = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.tbxName = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton7 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.pictureBox5 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.panel2 = new Panel();
      this.headerPanel14 = new HeaderPanel();
      this.glassButton27 = new GlassButton();
      this.cbNoticeType = new ComboBox();
      this.glassButton28 = new GlassButton();
      this.btnPrintNotice = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.textBox3 = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.textBox2 = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.textBox1 = new TextBox();
      this.panel3 = new Panel();
      this.tcSelfFatherMotherSpouse = new TabControl();
      this.tbSelf = new TabPage();
      this.tbFather = new TabPage();
      this.tcFatherDetails = new TabControl();
      this.tabPage2 = new TabPage();
      this.dgvPendingPledgesFather = new DataGridView();
      this.colSelectFather = new DataGridViewCheckBoxColumn();
      this.pictureBox6 = new PictureBox();
      this.tabPage3 = new TabPage();
      this.dgvRedeemedPledgesFather = new DataGridView();
      this.tabPage4 = new TabPage();
      this.dgvAuctionedPledgesFather = new DataGridView();
      this.tabPage5 = new TabPage();
      this.textBox4 = new TextBox();
      this.pictureBox7 = new PictureBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.textBox5 = new TextBox();
      this.textBox6 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox8 = new TextBox();
      this.textBox9 = new TextBox();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.tabPage6 = new TabPage();
      this.dgvSentSmsFather = new DataGridView();
      this.tabPage7 = new TabPage();
      this.dgvInterestDeductionsFAther = new DataGridView();
      this.tabPage8 = new TabPage();
      this.dgvLastViewedFather = new DataGridView();
      this.tbMother = new TabPage();
      this.tcMotherDetails = new TabControl();
      this.tabPage9 = new TabPage();
      this.dgvPendingPledgesMother = new DataGridView();
      this.colSelectMother = new DataGridViewCheckBoxColumn();
      this.pictureBox8 = new PictureBox();
      this.tabPage10 = new TabPage();
      this.dgvRedeemedPledgesMother = new DataGridView();
      this.tabPage11 = new TabPage();
      this.dgvAuctionedPledgesMother = new DataGridView();
      this.tabPage12 = new TabPage();
      this.textBox10 = new TextBox();
      this.pictureBox9 = new PictureBox();
      this.label7 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.textBox11 = new TextBox();
      this.textBox12 = new TextBox();
      this.textBox13 = new TextBox();
      this.textBox14 = new TextBox();
      this.textBox15 = new TextBox();
      this.label11 = new Label();
      this.label13 = new Label();
      this.label18 = new Label();
      this.tabPage13 = new TabPage();
      this.dgvSentSmsMother = new DataGridView();
      this.tabPage14 = new TabPage();
      this.dgvInterestDeductionsMother = new DataGridView();
      this.tabPage15 = new TabPage();
      this.dgvLastViewedMother = new DataGridView();
      this.tpSpouse = new TabPage();
      this.tcSpouseDetails = new TabControl();
      this.tabPage16 = new TabPage();
      this.dgvPendingPledgesSpouse = new DataGridView();
      this.colSelectSpouse = new DataGridViewCheckBoxColumn();
      this.pictureBox10 = new PictureBox();
      this.tabPage17 = new TabPage();
      this.dgvRedeemedPledgesSpouse = new DataGridView();
      this.tabPage18 = new TabPage();
      this.dgvAuctionedPledgesSpouse = new DataGridView();
      this.tabPage19 = new TabPage();
      this.textBox16 = new TextBox();
      this.pictureBox11 = new PictureBox();
      this.label19 = new Label();
      this.label20 = new Label();
      this.label21 = new Label();
      this.textBox17 = new TextBox();
      this.textBox18 = new TextBox();
      this.textBox19 = new TextBox();
      this.textBox20 = new TextBox();
      this.textBox21 = new TextBox();
      this.label22 = new Label();
      this.label23 = new Label();
      this.label24 = new Label();
      this.tabPage20 = new TabPage();
      this.dgvSentSmsSpouse = new DataGridView();
      this.tabPage21 = new TabPage();
      this.dgvInterestDeductionsSpouse = new DataGridView();
      this.tabPage22 = new TabPage();
      this.dgvLastViewedSpouse = new DataGridView();
      this.bwSelf = new BackgroundWorker();
      this.bwFather = new BackgroundWorker();
      this.bwMother = new BackgroundWorker();
      this.bwSpouse = new BackgroundWorker();
      this.tcSelfDetails.SuspendLayout();
      this.tpPendingPledges.SuspendLayout();
      ((ISupportInitialize) this.dgvPendingPledgeDetails).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.tpRedeemedPledges.SuspendLayout();
      ((ISupportInitialize) this.dgvRedeemedPledges).BeginInit();
      this.tpAuctionedPledges.SuspendLayout();
      ((ISupportInitialize) this.dgvAuctionedPledges).BeginInit();
      this.tpCustomerDetails.SuspendLayout();
      ((ISupportInitialize) this.picProofPhoto).BeginInit();
      this.tpSentSms.SuspendLayout();
      ((ISupportInitialize) this.dgvSentSms).BeginInit();
      this.tpInterestDeductions.SuspendLayout();
      ((ISupportInitialize) this.dgvInterestDeductions).BeginInit();
      this.tabPage1.SuspendLayout();
      ((ISupportInitialize) this.dgvLastViewed).BeginInit();
      ((ISupportInitialize) this.dgvCustomerDetails).BeginInit();
      ((ISupportInitialize) this.picProfilePhoto).BeginInit();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel13).SuspendLayout();
      ((Control) this.headerPanel12).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((Control) this.headerPanel9).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel14).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.panel3.SuspendLayout();
      this.tcSelfFatherMotherSpouse.SuspendLayout();
      this.tbSelf.SuspendLayout();
      this.tbFather.SuspendLayout();
      this.tcFatherDetails.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((ISupportInitialize) this.dgvPendingPledgesFather).BeginInit();
      ((ISupportInitialize) this.pictureBox6).BeginInit();
      this.tabPage3.SuspendLayout();
      ((ISupportInitialize) this.dgvRedeemedPledgesFather).BeginInit();
      this.tabPage4.SuspendLayout();
      ((ISupportInitialize) this.dgvAuctionedPledgesFather).BeginInit();
      this.tabPage5.SuspendLayout();
      ((ISupportInitialize) this.pictureBox7).BeginInit();
      this.tabPage6.SuspendLayout();
      ((ISupportInitialize) this.dgvSentSmsFather).BeginInit();
      this.tabPage7.SuspendLayout();
      ((ISupportInitialize) this.dgvInterestDeductionsFAther).BeginInit();
      this.tabPage8.SuspendLayout();
      ((ISupportInitialize) this.dgvLastViewedFather).BeginInit();
      this.tbMother.SuspendLayout();
      this.tcMotherDetails.SuspendLayout();
      this.tabPage9.SuspendLayout();
      ((ISupportInitialize) this.dgvPendingPledgesMother).BeginInit();
      ((ISupportInitialize) this.pictureBox8).BeginInit();
      this.tabPage10.SuspendLayout();
      ((ISupportInitialize) this.dgvRedeemedPledgesMother).BeginInit();
      this.tabPage11.SuspendLayout();
      ((ISupportInitialize) this.dgvAuctionedPledgesMother).BeginInit();
      this.tabPage12.SuspendLayout();
      ((ISupportInitialize) this.pictureBox9).BeginInit();
      this.tabPage13.SuspendLayout();
      ((ISupportInitialize) this.dgvSentSmsMother).BeginInit();
      this.tabPage14.SuspendLayout();
      ((ISupportInitialize) this.dgvInterestDeductionsMother).BeginInit();
      this.tabPage15.SuspendLayout();
      ((ISupportInitialize) this.dgvLastViewedMother).BeginInit();
      this.tpSpouse.SuspendLayout();
      this.tcSpouseDetails.SuspendLayout();
      this.tabPage16.SuspendLayout();
      ((ISupportInitialize) this.dgvPendingPledgesSpouse).BeginInit();
      ((ISupportInitialize) this.pictureBox10).BeginInit();
      this.tabPage17.SuspendLayout();
      ((ISupportInitialize) this.dgvRedeemedPledgesSpouse).BeginInit();
      this.tabPage18.SuspendLayout();
      ((ISupportInitialize) this.dgvAuctionedPledgesSpouse).BeginInit();
      this.tabPage19.SuspendLayout();
      ((ISupportInitialize) this.pictureBox11).BeginInit();
      this.tabPage20.SuspendLayout();
      ((ISupportInitialize) this.dgvSentSmsSpouse).BeginInit();
      this.tabPage21.SuspendLayout();
      ((ISupportInitialize) this.dgvInterestDeductionsSpouse).BeginInit();
      this.tabPage22.SuspendLayout();
      ((ISupportInitialize) this.dgvLastViewedSpouse).BeginInit();
      this.SuspendLayout();
      this.tcSelfDetails.Controls.Add((Control) this.tpPendingPledges);
      this.tcSelfDetails.Controls.Add((Control) this.tpRedeemedPledges);
      this.tcSelfDetails.Controls.Add((Control) this.tpAuctionedPledges);
      this.tcSelfDetails.Controls.Add((Control) this.tpCustomerDetails);
      this.tcSelfDetails.Controls.Add((Control) this.tpSentSms);
      this.tcSelfDetails.Controls.Add((Control) this.tpInterestDeductions);
      this.tcSelfDetails.Controls.Add((Control) this.tabPage1);
      this.tcSelfDetails.Dock = DockStyle.Fill;
      this.tcSelfDetails.Location = new Point(3, 3);
      this.tcSelfDetails.Name = "tcSelfDetails";
      this.tcSelfDetails.SelectedIndex = 0;
      this.tcSelfDetails.Size = new Size(988, 227);
      this.tcSelfDetails.TabIndex = 0;
      this.tpPendingPledges.Controls.Add((Control) this.dgvPendingPledgeDetails);
      this.tpPendingPledges.Controls.Add((Control) this.pictureBox2);
      this.tpPendingPledges.Location = new Point(4, 22);
      this.tpPendingPledges.Name = "tpPendingPledges";
      this.tpPendingPledges.Padding = new Padding(3);
      this.tpPendingPledges.Size = new Size(980, 201);
      this.tpPendingPledges.TabIndex = 0;
      this.tpPendingPledges.Text = "PENDING PLEDGES";
      this.tpPendingPledges.UseVisualStyleBackColor = true;
      this.dgvPendingPledgeDetails.AllowUserToAddRows = false;
      this.dgvPendingPledgeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPendingPledgeDetails.Columns.AddRange((DataGridViewColumn) this.colSelect);
      this.dgvPendingPledgeDetails.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPendingPledgeDetails.Dock = DockStyle.Fill;
      this.dgvPendingPledgeDetails.Location = new Point(3, 3);
      this.dgvPendingPledgeDetails.Name = "dgvPendingPledgeDetails";
      this.dgvPendingPledgeDetails.Size = new Size(974, 195);
      this.dgvPendingPledgeDetails.TabIndex = 5;
      this.dgvPendingPledgeDetails.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dgvPendingPledgeDetails.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dgvPendingPledgeDetails.CurrentCellDirtyStateChanged += new EventHandler(this.dgvPendingPledgeDetails_CurrentCellDirtyStateChanged);
      this.colSelect.HeaderText = "Select";
      this.colSelect.IndeterminateValue = (object) "false";
      this.colSelect.Name = "colSelect";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.selectAllToolStripMenuItem,
        (ToolStripItem) this.unSelectAllToolStripMenuItem,
        (ToolStripItem) this.printToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.calculateCompoundInterestToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(230, 180);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(229, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(229, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new Size(229, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
      this.unSelectAllToolStripMenuItem.Name = "unSelectAllToolStripMenuItem";
      this.unSelectAllToolStripMenuItem.Size = new Size(229, 22);
      this.unSelectAllToolStripMenuItem.Text = "UnSelect All";
      this.unSelectAllToolStripMenuItem.Click += new EventHandler(this.unSelectAllToolStripMenuItem_Click);
      this.printToolStripMenuItem.Name = "printToolStripMenuItem";
      this.printToolStripMenuItem.Size = new Size(229, 22);
      this.printToolStripMenuItem.Text = "Print";
      this.printToolStripMenuItem.Click += new EventHandler(this.printToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(229, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change Column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(229, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.calculateCompoundInterestToolStripMenuItem.Name = "calculateCompoundInterestToolStripMenuItem";
      this.calculateCompoundInterestToolStripMenuItem.Size = new Size(229, 22);
      this.calculateCompoundInterestToolStripMenuItem.Text = "Calculate Compound Interest";
      this.calculateCompoundInterestToolStripMenuItem.Click += new EventHandler(this.calculateCompoundInterestToolStripMenuItem_Click);
      this.pictureBox2.Location = new Point(769, 2);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(214, 224);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 4;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Visible = false;
      this.tpRedeemedPledges.Controls.Add((Control) this.dgvRedeemedPledges);
      this.tpRedeemedPledges.Location = new Point(4, 22);
      this.tpRedeemedPledges.Name = "tpRedeemedPledges";
      this.tpRedeemedPledges.Padding = new Padding(3);
      this.tpRedeemedPledges.Size = new Size(980, 201);
      this.tpRedeemedPledges.TabIndex = 1;
      this.tpRedeemedPledges.Text = "REDEEMED PLEDGES";
      this.tpRedeemedPledges.UseVisualStyleBackColor = true;
      this.tpRedeemedPledges.Enter += new EventHandler(this.tpRedeemedPledges_Click);
      this.dgvRedeemedPledges.AllowUserToAddRows = false;
      this.dgvRedeemedPledges.AllowUserToDeleteRows = false;
      this.dgvRedeemedPledges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvRedeemedPledges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRedeemedPledges.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvRedeemedPledges.Dock = DockStyle.Fill;
      this.dgvRedeemedPledges.Location = new Point(3, 3);
      this.dgvRedeemedPledges.Name = "dgvRedeemedPledges";
      this.dgvRedeemedPledges.ReadOnly = true;
      this.dgvRedeemedPledges.Size = new Size(974, 195);
      this.dgvRedeemedPledges.TabIndex = 25;
      this.dgvRedeemedPledges.CellClick += new DataGridViewCellEventHandler(this.dgvCustomerRedeemedDetails_CellClick);
      this.dgvRedeemedPledges.CellMouseEnter += new DataGridViewCellEventHandler(this.dgvCustomerRedeemedDetails_CellMouseEnter);
      this.dgvRedeemedPledges.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomerRedeemedDetails_DataBindingComplete);
      this.tpAuctionedPledges.Controls.Add((Control) this.dgvAuctionedPledges);
      this.tpAuctionedPledges.Location = new Point(4, 22);
      this.tpAuctionedPledges.Name = "tpAuctionedPledges";
      this.tpAuctionedPledges.Padding = new Padding(3);
      this.tpAuctionedPledges.Size = new Size(980, 201);
      this.tpAuctionedPledges.TabIndex = 2;
      this.tpAuctionedPledges.Text = "AUCTIONED PLEDGES";
      this.tpAuctionedPledges.UseVisualStyleBackColor = true;
      this.dgvAuctionedPledges.AllowUserToAddRows = false;
      this.dgvAuctionedPledges.AllowUserToDeleteRows = false;
      this.dgvAuctionedPledges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAuctionedPledges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAuctionedPledges.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvAuctionedPledges.Dock = DockStyle.Fill;
      this.dgvAuctionedPledges.Location = new Point(3, 3);
      this.dgvAuctionedPledges.Name = "dgvAuctionedPledges";
      this.dgvAuctionedPledges.ReadOnly = true;
      this.dgvAuctionedPledges.Size = new Size(974, 195);
      this.dgvAuctionedPledges.TabIndex = 26;
      this.dgvAuctionedPledges.CellClick += new DataGridViewCellEventHandler(this.dgvAuctionedPledges_CellClick);
      this.dgvAuctionedPledges.CellMouseEnter += new DataGridViewCellEventHandler(this.dgvAuctionedPledges_CellMouseEnter);
      this.tpCustomerDetails.BackColor = SystemColors.Control;
      this.tpCustomerDetails.Controls.Add((Control) this.tbxEmail);
      this.tpCustomerDetails.Controls.Add((Control) this.picProofPhoto);
      this.tpCustomerDetails.Controls.Add((Control) this.label16);
      this.tpCustomerDetails.Controls.Add((Control) this.label17);
      this.tpCustomerDetails.Controls.Add((Control) this.label12);
      this.tpCustomerDetails.Controls.Add((Control) this.tbxIntroducer);
      this.tpCustomerDetails.Controls.Add((Control) this.tbxInterestRate);
      this.tpCustomerDetails.Controls.Add((Control) this.tbxAadharNumber);
      this.tpCustomerDetails.Controls.Add((Control) this.tbxRationCard);
      this.tpCustomerDetails.Controls.Add((Control) this.tbxOtherProof);
      this.tpCustomerDetails.Controls.Add((Control) this.label15);
      this.tpCustomerDetails.Controls.Add((Control) this.label8);
      this.tpCustomerDetails.Controls.Add((Control) this.label14);
      this.tpCustomerDetails.Location = new Point(4, 22);
      this.tpCustomerDetails.Name = "tpCustomerDetails";
      this.tpCustomerDetails.Padding = new Padding(3);
      this.tpCustomerDetails.Size = new Size(980, 201);
      this.tpCustomerDetails.TabIndex = 3;
      this.tpCustomerDetails.Text = "CUSTOMER  DETAILS";
      this.tbxEmail.BorderStyle = BorderStyle.FixedSingle;
      this.tbxEmail.CharacterCasing = CharacterCasing.Upper;
      this.tbxEmail.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxEmail.Location = new Point(275, 46);
      this.tbxEmail.Name = "tbxEmail";
      this.tbxEmail.Size = new Size((int) byte.MaxValue, 20);
      this.tbxEmail.TabIndex = 58;
      this.picProofPhoto.Location = new Point(683, 6);
      this.picProofPhoto.Name = "picProofPhoto";
      this.picProofPhoto.Size = new Size(304, 243);
      this.picProofPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picProofPhoto.TabIndex = 73;
      this.picProofPhoto.TabStop = false;
      this.picProofPhoto.DoubleClick += new EventHandler(this.picProofPhoto_DoubleClick);
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(172, 72);
      this.label16.Name = "label16";
      this.label16.Size = new Size(100, 15);
      this.label16.TabIndex = 52;
      this.label16.Text = "INTEREST RATE";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(167, 93);
      this.label17.Name = "label17";
      this.label17.Size = new Size(105, 15);
      this.label17.TabIndex = 50;
      this.label17.Text = "INTRODUCED BY";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(214, 49);
      this.label12.Name = "label12";
      this.label12.Size = new Size(58, 15);
      this.label12.TabIndex = 53;
      this.label12.Text = "EMAIL ID";
      this.tbxIntroducer.BorderStyle = BorderStyle.FixedSingle;
      this.tbxIntroducer.CharacterCasing = CharacterCasing.Upper;
      this.tbxIntroducer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxIntroducer.Location = new Point(275, 90);
      this.tbxIntroducer.Name = "tbxIntroducer";
      this.tbxIntroducer.Size = new Size((int) byte.MaxValue, 20);
      this.tbxIntroducer.TabIndex = 59;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(275, 68);
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size((int) byte.MaxValue, 20);
      this.tbxInterestRate.TabIndex = 60;
      this.tbxAadharNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAadharNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxAadharNumber.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAadharNumber.Location = new Point(275, 116);
      this.tbxAadharNumber.Name = "tbxAadharNumber";
      this.tbxAadharNumber.Size = new Size((int) byte.MaxValue, 20);
      this.tbxAadharNumber.TabIndex = 62;
      this.tbxRationCard.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRationCard.CharacterCasing = CharacterCasing.Upper;
      this.tbxRationCard.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRationCard.Location = new Point(275, 140);
      this.tbxRationCard.Name = "tbxRationCard";
      this.tbxRationCard.Size = new Size((int) byte.MaxValue, 20);
      this.tbxRationCard.TabIndex = 63;
      this.tbxOtherProof.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherProof.CharacterCasing = CharacterCasing.Upper;
      this.tbxOtherProof.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherProof.Location = new Point(274, 163);
      this.tbxOtherProof.Name = "tbxOtherProof";
      this.tbxOtherProof.Size = new Size((int) byte.MaxValue, 20);
      this.tbxOtherProof.TabIndex = 64;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(158, 119);
      this.label15.Name = "label15";
      this.label15.Size = new Size(112, 15);
      this.label15.TabIndex = 67;
      this.label15.Text = "AADHAR NUMBER";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(175, 167);
      this.label8.Name = "label8";
      this.label8.Size = new Size(94, 15);
      this.label8.TabIndex = 65;
      this.label8.Text = "OTHER PROOF";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(183, 142);
      this.label14.Name = "label14";
      this.label14.Size = new Size(87, 15);
      this.label14.TabIndex = 66;
      this.label14.Text = "RATION CARD";
      this.tpSentSms.Controls.Add((Control) this.dgvSentSms);
      this.tpSentSms.Location = new Point(4, 22);
      this.tpSentSms.Name = "tpSentSms";
      this.tpSentSms.Padding = new Padding(3);
      this.tpSentSms.Size = new Size(980, 201);
      this.tpSentSms.TabIndex = 4;
      this.tpSentSms.Text = "SENT SMS";
      this.tpSentSms.UseVisualStyleBackColor = true;
      this.dgvSentSms.AllowUserToAddRows = false;
      this.dgvSentSms.AllowUserToDeleteRows = false;
      this.dgvSentSms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSentSms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSentSms.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvSentSms.Dock = DockStyle.Fill;
      this.dgvSentSms.Location = new Point(3, 3);
      this.dgvSentSms.Name = "dgvSentSms";
      this.dgvSentSms.ReadOnly = true;
      this.dgvSentSms.Size = new Size(974, 195);
      this.dgvSentSms.TabIndex = 27;
      this.tpInterestDeductions.Controls.Add((Control) this.dgvInterestDeductions);
      this.tpInterestDeductions.Location = new Point(4, 22);
      this.tpInterestDeductions.Name = "tpInterestDeductions";
      this.tpInterestDeductions.Padding = new Padding(3);
      this.tpInterestDeductions.Size = new Size(980, 201);
      this.tpInterestDeductions.TabIndex = 5;
      this.tpInterestDeductions.Text = "INTEREST DEDUCTIONS";
      this.tpInterestDeductions.UseVisualStyleBackColor = true;
      this.dgvInterestDeductions.AllowUserToAddRows = false;
      this.dgvInterestDeductions.AllowUserToDeleteRows = false;
      this.dgvInterestDeductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvInterestDeductions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvInterestDeductions.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvInterestDeductions.Dock = DockStyle.Fill;
      this.dgvInterestDeductions.Location = new Point(3, 3);
      this.dgvInterestDeductions.Name = "dgvInterestDeductions";
      this.dgvInterestDeductions.ReadOnly = true;
      this.dgvInterestDeductions.Size = new Size(974, 195);
      this.dgvInterestDeductions.TabIndex = 28;
      this.tabPage1.Controls.Add((Control) this.dgvLastViewed);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(980, 201);
      this.tabPage1.TabIndex = 6;
      this.tabPage1.Text = "LAST VIEWED";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.dgvLastViewed.AllowUserToAddRows = false;
      this.dgvLastViewed.AllowUserToDeleteRows = false;
      this.dgvLastViewed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvLastViewed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLastViewed.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvLastViewed.Dock = DockStyle.Fill;
      this.dgvLastViewed.Location = new Point(3, 3);
      this.dgvLastViewed.Name = "dgvLastViewed";
      this.dgvLastViewed.ReadOnly = true;
      this.dgvLastViewed.Size = new Size(974, 195);
      this.dgvLastViewed.TabIndex = 29;
      this.dgvCustomerDetails.AllowUserToAddRows = false;
      this.dgvCustomerDetails.AllowUserToDeleteRows = false;
      this.dgvCustomerDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvCustomerDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvCustomerDetails.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvCustomerDetails.Location = new Point(279, 58);
      this.dgvCustomerDetails.Name = "dgvCustomerDetails";
      this.dgvCustomerDetails.ReadOnly = true;
      this.dgvCustomerDetails.Size = new Size(719, 216);
      this.dgvCustomerDetails.TabIndex = 8;
      this.dgvCustomerDetails.Visible = false;
      this.dgvCustomerDetails.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomerDetails_DataBindingComplete);
      this.dgvCustomerDetails.KeyDown += new KeyEventHandler(this.dgvCustomerDetails_KeyDown);
      this.dgvCustomerDetails.KeyUp += new KeyEventHandler(this.dgvCustomerDetails_KeyUp);
      this.picProfilePhoto.Dock = DockStyle.Fill;
      this.picProfilePhoto.Location = new Point(0, 0);
      this.picProfilePhoto.Name = "picProfilePhoto";
      this.picProfilePhoto.Size = new Size(270, 242);
      this.picProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picProfilePhoto.TabIndex = 68;
      this.picProfilePhoto.TabStop = false;
      this.picProfilePhoto.DoubleClick += new EventHandler(this.picProfilePhoto_DoubleClick);
      this.panel1.Controls.Add((Control) this.dgvCustomerDetails);
      this.panel1.Controls.Add((Control) this.headerPanel13);
      this.panel1.Controls.Add((Control) this.headerPanel12);
      this.panel1.Controls.Add((Control) this.headerPanel11);
      this.panel1.Controls.Add((Control) this.headerPanel10);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.pictureBox4);
      this.panel1.Controls.Add((Control) this.headerPanel9);
      this.panel1.Controls.Add((Control) this.headerPanel8);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.headerPanel5);
      this.panel1.Controls.Add((Control) this.headerPanel4);
      this.panel1.Controls.Add((Control) this.pictureBox5);
      this.panel1.Controls.Add((Control) this.pictureBox3);
      this.panel1.Location = new Point(3, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 277);
      this.panel1.TabIndex = 1;
      ((Control) this.headerPanel13).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel13.BorderColor = SystemColors.ControlDark;
      this.headerPanel13.BorderStyle = BorderStyles.Single;
      this.headerPanel13.CaptionBeginColor = SystemColors.Control;
      this.headerPanel13.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel13.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.CaptionHeight = 22;
      this.headerPanel13.CaptionPosition = CaptionPositions.Top;
      this.headerPanel13.CaptionText = "SEARCH";
      this.headerPanel13.CaptionVisible = true;
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton25);
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton26);
      ((Control) this.headerPanel13).Controls.Add((Control) this.tbxCustomerName);
      ((Control) this.headerPanel13).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel13).ForeColor = Color.DarkBlue;
      this.headerPanel13.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.GradientEnd = SystemColors.ControlLight;
      this.headerPanel13.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).Location = new Point(281, 6);
      ((Control) this.headerPanel13).Name = "headerPanel13";
      this.headerPanel13.PanelIcon = (Icon) null;
      this.headerPanel13.PanelIconVisible = false;
      ((Control) this.headerPanel13).Size = new Size(285, 49);
      ((Control) this.headerPanel13).TabIndex = 93;
      this.headerPanel13.TextAntialias = true;
      ((Control) this.glassButton25).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton25.BackColor = Color.LightBlue;
      this.glassButton25.FadeOnFocus = true;
      ((Control) this.glassButton25).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton25.ForeColor = Color.MediumBlue;
      this.glassButton25.ForeColorOnFocus = Color.Red;
      this.glassButton25.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton25.GlowColor = Color.White;
      ((ButtonBase) this.glassButton25).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton25.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton25).Location = new Point(-26, 513);
      ((Control) this.glassButton25).Name = "glassButton25";
      this.glassButton25.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton25.ShineColor = Color.Transparent;
      ((Control) this.glassButton25).Size = new Size(128, 35);
      ((Control) this.glassButton25).TabIndex = 0;
      ((Control) this.glassButton25).Text = "&SAVE";
      ((ButtonBase) this.glassButton25).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton26).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton26.BackColor = Color.LightBlue;
      this.glassButton26.FadeOnFocus = true;
      ((Control) this.glassButton26).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton26.ForeColor = Color.MediumBlue;
      this.glassButton26.ForeColorOnFocus = Color.Red;
      this.glassButton26.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton26.GlowColor = Color.White;
      this.glassButton26.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton26).Location = new Point(108, 512);
      ((Control) this.glassButton26).Name = "glassButton26";
      this.glassButton26.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton26.ShineColor = Color.Transparent;
      ((Control) this.glassButton26).Size = new Size(123, 37);
      ((Control) this.glassButton26).TabIndex = 1;
      ((Control) this.glassButton26).Text = "&EXIT";
      ((ButtonBase) this.glassButton26).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxCustomerName.BorderStyle = BorderStyle.None;
      this.tbxCustomerName.Dock = DockStyle.Fill;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.ForeColor = SystemColors.MenuHighlight;
      this.tbxCustomerName.Location = new Point(0, 0);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(283, 24);
      this.tbxCustomerName.TabIndex = 6;
      this.tbxCustomerName.TextChanged += new EventHandler(this.tbxCustomerName_TextChanged);
      this.tbxCustomerName.KeyDown += new KeyEventHandler(this.tbxCustomerName_KeyUp);
      ((Control) this.headerPanel12).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel12).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel12.BorderColor = SystemColors.ControlDark;
      this.headerPanel12.BorderStyle = BorderStyles.Single;
      this.headerPanel12.CaptionBeginColor = SystemColors.Control;
      this.headerPanel12.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel12.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.CaptionHeight = 22;
      this.headerPanel12.CaptionPosition = CaptionPositions.Top;
      this.headerPanel12.CaptionText = "Avg of no of months for release";
      this.headerPanel12.CaptionVisible = true;
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton23);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel12).Controls.Add((Control) this.tbxAverageOfNoOfMonthsForRelease);
      ((Control) this.headerPanel12).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel12).ForeColor = Color.DarkBlue;
      this.headerPanel12.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.GradientEnd = SystemColors.ControlLight;
      this.headerPanel12.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel12).Location = new Point(701, 60);
      ((Control) this.headerPanel12).Name = "headerPanel12";
      this.headerPanel12.PanelIcon = (Icon) null;
      this.headerPanel12.PanelIconVisible = false;
      ((Control) this.headerPanel12).Size = new Size(298, 49);
      ((Control) this.headerPanel12).TabIndex = 92;
      this.headerPanel12.TextAntialias = true;
      ((Control) this.glassButton23).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton23.BackColor = Color.LightBlue;
      this.glassButton23.FadeOnFocus = true;
      ((Control) this.glassButton23).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton23.ForeColor = Color.MediumBlue;
      this.glassButton23.ForeColorOnFocus = Color.Red;
      this.glassButton23.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton23.GlowColor = Color.White;
      ((ButtonBase) this.glassButton23).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton23.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton23).Location = new Point(-15, 513);
      ((Control) this.glassButton23).Name = "glassButton23";
      this.glassButton23.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton23.ShineColor = Color.Transparent;
      ((Control) this.glassButton23).Size = new Size(128, 35);
      ((Control) this.glassButton23).TabIndex = 0;
      ((Control) this.glassButton23).Text = "&SAVE";
      ((ButtonBase) this.glassButton23).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton24).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton24.BackColor = Color.LightBlue;
      this.glassButton24.FadeOnFocus = true;
      ((Control) this.glassButton24).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton24.ForeColor = Color.MediumBlue;
      this.glassButton24.ForeColorOnFocus = Color.Red;
      this.glassButton24.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton24.GlowColor = Color.White;
      this.glassButton24.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton24).Location = new Point(119, 512);
      ((Control) this.glassButton24).Name = "glassButton24";
      this.glassButton24.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton24.ShineColor = Color.Transparent;
      ((Control) this.glassButton24).Size = new Size(123, 37);
      ((Control) this.glassButton24).TabIndex = 1;
      ((Control) this.glassButton24).Text = "&EXIT";
      ((ButtonBase) this.glassButton24).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAverageOfNoOfMonthsForRelease.BorderStyle = BorderStyle.None;
      this.tbxAverageOfNoOfMonthsForRelease.Dock = DockStyle.Fill;
      this.tbxAverageOfNoOfMonthsForRelease.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAverageOfNoOfMonthsForRelease.Location = new Point(0, 0);
      this.tbxAverageOfNoOfMonthsForRelease.Name = "tbxAverageOfNoOfMonthsForRelease";
      this.tbxAverageOfNoOfMonthsForRelease.Size = new Size(296, 24);
      this.tbxAverageOfNoOfMonthsForRelease.TabIndex = 6;
      ((Control) this.headerPanel11).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.ControlDark;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = SystemColors.Control;
      this.headerPanel11.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel11.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "NO OF TIMES RELEASE > 12 MNTHS";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton22);
      ((Control) this.headerPanel11).Controls.Add((Control) this.tbxNumberOfTimesReleaseExceededTwelveMonths);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = SystemColors.ControlLight;
      this.headerPanel11.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).Location = new Point(701, 115);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(298, 49);
      ((Control) this.headerPanel11).TabIndex = 91;
      this.headerPanel11.TextAntialias = true;
      ((Control) this.glassButton21).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton21.BackColor = Color.LightBlue;
      this.glassButton21.FadeOnFocus = true;
      ((Control) this.glassButton21).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton21.ForeColor = Color.MediumBlue;
      this.glassButton21.ForeColorOnFocus = Color.Red;
      this.glassButton21.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton21.GlowColor = Color.White;
      ((ButtonBase) this.glassButton21).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton21.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton21).Location = new Point(-15, 513);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(128, 35);
      ((Control) this.glassButton21).TabIndex = 0;
      ((Control) this.glassButton21).Text = "&SAVE";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton22).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton22.BackColor = Color.LightBlue;
      this.glassButton22.FadeOnFocus = true;
      ((Control) this.glassButton22).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton22.ForeColor = Color.MediumBlue;
      this.glassButton22.ForeColorOnFocus = Color.Red;
      this.glassButton22.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton22.GlowColor = Color.White;
      this.glassButton22.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton22).Location = new Point(119, 512);
      ((Control) this.glassButton22).Name = "glassButton22";
      this.glassButton22.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton22.ShineColor = Color.Transparent;
      ((Control) this.glassButton22).Size = new Size(123, 37);
      ((Control) this.glassButton22).TabIndex = 1;
      ((Control) this.glassButton22).Text = "&EXIT";
      ((ButtonBase) this.glassButton22).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.BorderStyle = BorderStyle.None;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Dock = DockStyle.Fill;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Location = new Point(0, 0);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Name = "tbxNumberOfTimesReleaseExceededTwelveMonths";
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Size = new Size(296, 24);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.TabIndex = 6;
      ((Control) this.headerPanel10).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.ControlDark;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = SystemColors.Control;
      this.headerPanel10.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "REMINDER";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel10).Controls.Add((Control) this.tbxNotes);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = SystemColors.ControlLight;
      this.headerPanel10.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).Location = new Point(701, 6);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(298, 49);
      ((Control) this.headerPanel10).TabIndex = 90;
      this.headerPanel10.TextAntialias = true;
      ((Control) this.glassButton19).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      ((Control) this.glassButton19).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      ((ButtonBase) this.glassButton19).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(-13, 513);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(128, 35);
      ((Control) this.glassButton19).TabIndex = 0;
      ((Control) this.glassButton19).Text = "&SAVE";
      ((ButtonBase) this.glassButton19).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton20).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton20.BackColor = Color.LightBlue;
      this.glassButton20.FadeOnFocus = true;
      ((Control) this.glassButton20).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton20.ForeColor = Color.MediumBlue;
      this.glassButton20.ForeColorOnFocus = Color.Red;
      this.glassButton20.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton20.GlowColor = Color.White;
      this.glassButton20.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton20).Location = new Point(121, 512);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(123, 37);
      ((Control) this.glassButton20).TabIndex = 1;
      ((Control) this.glassButton20).Text = "&EXIT";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNotes.BorderStyle = BorderStyle.None;
      this.tbxNotes.Dock = DockStyle.Fill;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(0, 0);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(296, 24);
      this.tbxNotes.TabIndex = 6;
      this.pictureBox1.Image = (Image) Resources.message;
      this.pictureBox1.Location = new Point(889, 222);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(53, 46);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 89;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox4.Image = (Image) Resources.callbutton;
      this.pictureBox4.Location = new Point(948, 222);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(48, 46);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox4.TabIndex = 88;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Click += new EventHandler(this.pictureBox4_Click);
      ((Control) this.headerPanel9).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.ControlDark;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = SystemColors.Control;
      this.headerPanel9.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "ALTERNATE NUMBER";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel9).Controls.Add((Control) this.tbxAlternateContact);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = SystemColors.ControlLight;
      this.headerPanel9.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).Location = new Point(703, 222);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(181, 46);
      ((Control) this.headerPanel9).TabIndex = 86;
      this.headerPanel9.TextAntialias = true;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      ((ButtonBase) this.glassButton17).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(-132, 513);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(128, 35);
      ((Control) this.glassButton17).TabIndex = 0;
      ((Control) this.glassButton17).Text = "&SAVE";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(2, 512);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(123, 37);
      ((Control) this.glassButton18).TabIndex = 1;
      ((Control) this.glassButton18).Text = "&EXIT";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAlternateContact.BorderStyle = BorderStyle.None;
      this.tbxAlternateContact.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateContact.Dock = DockStyle.Fill;
      this.tbxAlternateContact.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateContact.Location = new Point(0, 0);
      this.tbxAlternateContact.Name = "tbxAlternateContact";
      this.tbxAlternateContact.Size = new Size(179, 22);
      this.tbxAlternateContact.TabIndex = 57;
      this.tbxAlternateContact.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel8).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.ControlDark;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = SystemColors.Control;
      this.headerPanel8.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "PHONE NUMBER";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxContactNo);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(703, 169);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(180, 48);
      ((Control) this.headerPanel8).TabIndex = 85;
      this.headerPanel8.TextAntialias = true;
      ((Control) this.glassButton15).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton15.BackColor = Color.LightBlue;
      this.glassButton15.FadeOnFocus = true;
      ((Control) this.glassButton15).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton15.ForeColor = Color.MediumBlue;
      this.glassButton15.ForeColorOnFocus = Color.Red;
      this.glassButton15.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton15.GlowColor = Color.White;
      ((ButtonBase) this.glassButton15).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton15.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton15).Location = new Point(-131, 513);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(128, 35);
      ((Control) this.glassButton15).TabIndex = 0;
      ((Control) this.glassButton15).Text = "&SAVE";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(3, 512);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(123, 37);
      ((Control) this.glassButton16).TabIndex = 1;
      ((Control) this.glassButton16).Text = "&EXIT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxContactNo.BorderStyle = BorderStyle.None;
      this.tbxContactNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxContactNo.Dock = DockStyle.Fill;
      this.tbxContactNo.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxContactNo.Location = new Point(0, 0);
      this.tbxContactNo.Name = "tbxContactNo";
      this.tbxContactNo.Size = new Size(178, 22);
      this.tbxContactNo.TabIndex = 57;
      this.tbxContactNo.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.ControlDark;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = SystemColors.Control;
      this.headerPanel7.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "ADDRESS";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.richTextBox1);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(279, 115);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(416, 152);
      ((Control) this.headerPanel7).TabIndex = 84;
      this.headerPanel7.TextAntialias = true;
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Location = new Point(0, 0);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(414, 128);
      this.richTextBox1.TabIndex = 2;
      this.richTextBox1.Text = "";
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      ((ButtonBase) this.glassButton13).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(105, 513);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(128, 35);
      ((Control) this.glassButton13).TabIndex = 0;
      ((Control) this.glassButton13).Text = "&SAVE";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(239, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 1;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.ControlDark;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = SystemColors.Control;
      this.headerPanel6.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "CUSTOMER CODE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(571, 6);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(125, 49);
      ((Control) this.headerPanel6).TabIndex = 83;
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
      ((Control) this.glassButton11).Location = new Point(-184, 513);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(128, 35);
      ((Control) this.glassButton11).TabIndex = 0;
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
      ((Control) this.glassButton12).Location = new Point(-50, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Dock = DockStyle.Fill;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(0, 0);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(123, 24);
      this.tbxCustomerCode.TabIndex = 6;
      ((Control) this.headerPanel5).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.ControlDark;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = SystemColors.Control;
      this.headerPanel5.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "NAME";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxName);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(279, 60);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(415, 50);
      ((Control) this.headerPanel5).TabIndex = 82;
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
      ((Control) this.glassButton9).Location = new Point(108, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 0;
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
      ((Control) this.glassButton10).Location = new Point(242, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 1;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxName.BorderStyle = BorderStyle.None;
      this.tbxName.Dock = DockStyle.Fill;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(0, 0);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(413, 24);
      this.tbxName.TabIndex = 9;
      ((Control) this.headerPanel4).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.ControlDark;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = SystemColors.Control;
      this.headerPanel4.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "PHOTO";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel4).Controls.Add((Control) this.picProfilePhoto);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(4, 5);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(272, 266);
      ((Control) this.headerPanel4).TabIndex = 81;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      ((ButtonBase) this.glassButton7).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(-33, 513);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(128, 35);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&SAVE";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(101, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 1;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.pictureBox5.Image = (Image) Resources.message;
      this.pictureBox5.Location = new Point(889, 171);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(53, 46);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 58;
      this.pictureBox5.TabStop = false;
      this.pictureBox5.Click += new EventHandler(this.pictureBox5_Click);
      this.pictureBox5.MouseEnter += new EventHandler(this.pictureBox5_MouseEnter);
      this.pictureBox5.MouseLeave += new EventHandler(this.pictureBox5_MouseLeave_1);
      this.pictureBox3.Image = (Image) Resources.callbutton;
      this.pictureBox3.Location = new Point(948, 171);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(48, 46);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 45;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Click += new EventHandler(this.pictureBox3_Click);
      this.pictureBox3.MouseEnter += new EventHandler(this.pictureBox3_MouseEnter);
      this.pictureBox3.MouseLeave += new EventHandler(this.pictureBox3_MouseLeave);
      this.panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.headerPanel14);
      this.panel2.Controls.Add((Control) this.headerPanel3);
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Location = new Point(2, 542);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 58);
      this.panel2.TabIndex = 2;
      ((Control) this.headerPanel14).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel14).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel14).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel14).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel14.BorderColor = SystemColors.ControlDarkDark;
      this.headerPanel14.BorderStyle = BorderStyles.Single;
      this.headerPanel14.CaptionBeginColor = SystemColors.Control;
      this.headerPanel14.CaptionEndColor = SystemColors.ButtonHighlight;
      this.headerPanel14.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.CaptionHeight = 22;
      this.headerPanel14.CaptionPosition = CaptionPositions.Top;
      this.headerPanel14.CaptionText = "PRINT NOTICE";
      this.headerPanel14.CaptionVisible = true;
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton27);
      ((Control) this.headerPanel14).Controls.Add((Control) this.cbNoticeType);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton28);
      ((Control) this.headerPanel14).Controls.Add((Control) this.btnPrintNotice);
      ((Control) this.headerPanel14).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel14).ForeColor = Color.DarkBlue;
      this.headerPanel14.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.GradientEnd = SystemColors.ControlLight;
      this.headerPanel14.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel14).Location = new Point(622, 3);
      ((Control) this.headerPanel14).Name = "headerPanel14";
      this.headerPanel14.PanelIcon = (Icon) null;
      this.headerPanel14.PanelIconVisible = false;
      ((Control) this.headerPanel14).Size = new Size(376, 52);
      ((Control) this.headerPanel14).TabIndex = 81;
      this.headerPanel14.TextAntialias = true;
      ((Control) this.glassButton27).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton27.BackColor = Color.LightBlue;
      this.glassButton27.FadeOnFocus = true;
      ((Control) this.glassButton27).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton27.ForeColor = Color.MediumBlue;
      this.glassButton27.ForeColorOnFocus = Color.Red;
      this.glassButton27.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton27.GlowColor = Color.White;
      ((ButtonBase) this.glassButton27).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton27.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton27).Location = new Point(69, 513);
      ((Control) this.glassButton27).Name = "glassButton27";
      this.glassButton27.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton27.ShineColor = Color.Transparent;
      ((Control) this.glassButton27).Size = new Size(128, 35);
      ((Control) this.glassButton27).TabIndex = 0;
      ((Control) this.glassButton27).Text = "&SAVE";
      ((ButtonBase) this.glassButton27).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbNoticeType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbNoticeType.BackColor = SystemColors.ButtonHighlight;
      this.cbNoticeType.DropDownWidth = 400;
      this.cbNoticeType.FlatStyle = FlatStyle.Flat;
      this.cbNoticeType.Font = new Font("Rockwell", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeType.FormattingEnabled = true;
      this.cbNoticeType.Location = new Point(3, 2);
      this.cbNoticeType.Name = "cbNoticeType";
      this.cbNoticeType.Size = new Size(278, 23);
      this.cbNoticeType.TabIndex = 35;
      ((Control) this.glassButton28).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton28.BackColor = Color.LightBlue;
      this.glassButton28.FadeOnFocus = true;
      ((Control) this.glassButton28).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton28.ForeColor = Color.MediumBlue;
      this.glassButton28.ForeColorOnFocus = Color.Red;
      this.glassButton28.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton28.GlowColor = Color.White;
      this.glassButton28.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton28).Location = new Point(203, 512);
      ((Control) this.glassButton28).Name = "glassButton28";
      this.glassButton28.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton28.ShineColor = Color.Transparent;
      ((Control) this.glassButton28).Size = new Size(123, 37);
      ((Control) this.glassButton28).TabIndex = 1;
      ((Control) this.glassButton28).Text = "&EXIT";
      ((ButtonBase) this.glassButton28).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrintNotice).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrintNotice.BackColor = Color.LightBlue;
      this.btnPrintNotice.FadeOnFocus = true;
      this.btnPrintNotice.ForeColor = Color.MediumBlue;
      this.btnPrintNotice.ForeColorOnFocus = Color.Red;
      this.btnPrintNotice.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrintNotice.GlowColor = Color.White;
      this.btnPrintNotice.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrintNotice).Location = new Point(280, 4);
      ((Control) this.btnPrintNotice).Name = "btnPrintNotice";
      this.btnPrintNotice.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrintNotice.ShineColor = Color.Transparent;
      ((Control) this.btnPrintNotice).Size = new Size(96, 20);
      ((Control) this.btnPrintNotice).TabIndex = 3;
      ((Control) this.btnPrintNotice).Text = "&PRINT NOTICE";
      ((Control) this.btnPrintNotice).Click += new EventHandler(this.btnPrintNotice_Click);
      ((Control) this.headerPanel3).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.ControlDark;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = SystemColors.Control;
      this.headerPanel3.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "                   TOTAL AMOUNT";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.textBox3);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(416, 1);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(200, 55);
      ((Control) this.headerPanel3).TabIndex = 80;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-103, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(31, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.textBox3.BackColor = SystemColors.ButtonHighlight;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.Dock = DockStyle.Fill;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.Location = new Point(0, 0);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(198, 31);
      this.textBox3.TabIndex = 25;
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel1).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.ControlDark;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = SystemColors.Control;
      this.headerPanel1.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "                   INTEREST";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.textBox2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(223, 1);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(188, 55);
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
      ((Control) this.glassButton1).Location = new Point(-115, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
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
      ((Control) this.glassButton2).Location = new Point(19, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.textBox2.BackColor = SystemColors.ButtonHighlight;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.Dock = DockStyle.Fill;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox2.Location = new Point(0, 0);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(186, 31);
      this.textBox2.TabIndex = 25;
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel2).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.ControlDark;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = SystemColors.Control;
      this.headerPanel2.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "                   PRINCIPAL";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(5, 1);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(212, 55);
      ((Control) this.headerPanel2).TabIndex = 79;
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
      ((Control) this.glassButton4).Location = new Point(-89, 513);
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
      ((Control) this.glassButton5).Location = new Point(45, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.textBox1.BackColor = SystemColors.ButtonHighlight;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Dock = DockStyle.Fill;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(0, 0);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(210, 31);
      this.textBox1.TabIndex = 25;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel3.Controls.Add((Control) this.tcSelfFatherMotherSpouse);
      this.panel3.Location = new Point(2, 280);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 259);
      this.panel3.TabIndex = 3;
      this.tcSelfFatherMotherSpouse.Controls.Add((Control) this.tbSelf);
      this.tcSelfFatherMotherSpouse.Controls.Add((Control) this.tbFather);
      this.tcSelfFatherMotherSpouse.Controls.Add((Control) this.tbMother);
      this.tcSelfFatherMotherSpouse.Controls.Add((Control) this.tpSpouse);
      this.tcSelfFatherMotherSpouse.Dock = DockStyle.Fill;
      this.tcSelfFatherMotherSpouse.Location = new Point(0, 0);
      this.tcSelfFatherMotherSpouse.Name = "tcSelfFatherMotherSpouse";
      this.tcSelfFatherMotherSpouse.SelectedIndex = 0;
      this.tcSelfFatherMotherSpouse.Size = new Size(1002, 259);
      this.tcSelfFatherMotherSpouse.TabIndex = 1;
      this.tcSelfFatherMotherSpouse.Click += new EventHandler(this.tcFather_Click);
      this.tbSelf.Controls.Add((Control) this.tcSelfDetails);
      this.tbSelf.Location = new Point(4, 22);
      this.tbSelf.Name = "tbSelf";
      this.tbSelf.Padding = new Padding(3);
      this.tbSelf.Size = new Size(994, 233);
      this.tbSelf.TabIndex = 0;
      this.tbSelf.Text = "SELF";
      this.tbSelf.UseVisualStyleBackColor = true;
      this.tbFather.Controls.Add((Control) this.tcFatherDetails);
      this.tbFather.Location = new Point(4, 22);
      this.tbFather.Name = "tbFather";
      this.tbFather.Padding = new Padding(3);
      this.tbFather.Size = new Size(994, 233);
      this.tbFather.TabIndex = 1;
      this.tbFather.Text = "Father";
      this.tbFather.UseVisualStyleBackColor = true;
      this.tbFather.Click += new EventHandler(this.tbFather_Click);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage2);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage3);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage4);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage5);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage6);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage7);
      this.tcFatherDetails.Controls.Add((Control) this.tabPage8);
      this.tcFatherDetails.Dock = DockStyle.Fill;
      this.tcFatherDetails.Location = new Point(3, 3);
      this.tcFatherDetails.Name = "tcFatherDetails";
      this.tcFatherDetails.SelectedIndex = 0;
      this.tcFatherDetails.Size = new Size(988, 227);
      this.tcFatherDetails.TabIndex = 1;
      this.tabPage2.Controls.Add((Control) this.dgvPendingPledgesFather);
      this.tabPage2.Controls.Add((Control) this.pictureBox6);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(980, 201);
      this.tabPage2.TabIndex = 0;
      this.tabPage2.Text = "PENDING PLEDGES";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.dgvPendingPledgesFather.AllowUserToAddRows = false;
      this.dgvPendingPledgesFather.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPendingPledgesFather.Columns.AddRange((DataGridViewColumn) this.colSelectFather);
      this.dgvPendingPledgesFather.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPendingPledgesFather.Dock = DockStyle.Fill;
      this.dgvPendingPledgesFather.Location = new Point(3, 3);
      this.dgvPendingPledgesFather.Name = "dgvPendingPledgesFather";
      this.dgvPendingPledgesFather.Size = new Size(974, 195);
      this.dgvPendingPledgesFather.TabIndex = 5;
      this.colSelectFather.HeaderText = "Select";
      this.colSelectFather.IndeterminateValue = (object) "false";
      this.colSelectFather.Name = "colSelectFather";
      this.pictureBox6.Location = new Point(769, 2);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(214, 224);
      this.pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox6.TabIndex = 4;
      this.pictureBox6.TabStop = false;
      this.pictureBox6.Visible = false;
      this.tabPage3.Controls.Add((Control) this.dgvRedeemedPledgesFather);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(3);
      this.tabPage3.Size = new Size(980, 201);
      this.tabPage3.TabIndex = 1;
      this.tabPage3.Text = "REDEEMED PLEDGES";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.dgvRedeemedPledgesFather.AllowUserToAddRows = false;
      this.dgvRedeemedPledgesFather.AllowUserToDeleteRows = false;
      this.dgvRedeemedPledgesFather.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvRedeemedPledgesFather.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRedeemedPledgesFather.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvRedeemedPledgesFather.Dock = DockStyle.Fill;
      this.dgvRedeemedPledgesFather.Location = new Point(3, 3);
      this.dgvRedeemedPledgesFather.Name = "dgvRedeemedPledgesFather";
      this.dgvRedeemedPledgesFather.ReadOnly = true;
      this.dgvRedeemedPledgesFather.Size = new Size(974, 195);
      this.dgvRedeemedPledgesFather.TabIndex = 25;
      this.tabPage4.Controls.Add((Control) this.dgvAuctionedPledgesFather);
      this.tabPage4.Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new Padding(3);
      this.tabPage4.Size = new Size(980, 201);
      this.tabPage4.TabIndex = 2;
      this.tabPage4.Text = "AUCTIONED PLEDGES";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.dgvAuctionedPledgesFather.AllowUserToAddRows = false;
      this.dgvAuctionedPledgesFather.AllowUserToDeleteRows = false;
      this.dgvAuctionedPledgesFather.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAuctionedPledgesFather.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAuctionedPledgesFather.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvAuctionedPledgesFather.Dock = DockStyle.Fill;
      this.dgvAuctionedPledgesFather.Location = new Point(3, 3);
      this.dgvAuctionedPledgesFather.Name = "dgvAuctionedPledgesFather";
      this.dgvAuctionedPledgesFather.ReadOnly = true;
      this.dgvAuctionedPledgesFather.Size = new Size(974, 195);
      this.dgvAuctionedPledgesFather.TabIndex = 26;
      this.tabPage5.BackColor = SystemColors.Control;
      this.tabPage5.Controls.Add((Control) this.textBox4);
      this.tabPage5.Controls.Add((Control) this.pictureBox7);
      this.tabPage5.Controls.Add((Control) this.label1);
      this.tabPage5.Controls.Add((Control) this.label2);
      this.tabPage5.Controls.Add((Control) this.label3);
      this.tabPage5.Controls.Add((Control) this.textBox5);
      this.tabPage5.Controls.Add((Control) this.textBox6);
      this.tabPage5.Controls.Add((Control) this.textBox7);
      this.tabPage5.Controls.Add((Control) this.textBox8);
      this.tabPage5.Controls.Add((Control) this.textBox9);
      this.tabPage5.Controls.Add((Control) this.label4);
      this.tabPage5.Controls.Add((Control) this.label5);
      this.tabPage5.Controls.Add((Control) this.label6);
      this.tabPage5.Location = new Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(3);
      this.tabPage5.Size = new Size(980, 201);
      this.tabPage5.TabIndex = 3;
      this.tabPage5.Text = "CUSTOMER  DETAILS";
      this.textBox4.BorderStyle = BorderStyle.FixedSingle;
      this.textBox4.CharacterCasing = CharacterCasing.Upper;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox4.Location = new Point(275, 46);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size((int) byte.MaxValue, 20);
      this.textBox4.TabIndex = 58;
      this.pictureBox7.Location = new Point(683, 6);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(304, 243);
      this.pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox7.TabIndex = 73;
      this.pictureBox7.TabStop = false;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(172, 72);
      this.label1.Name = "label1";
      this.label1.Size = new Size(100, 15);
      this.label1.TabIndex = 52;
      this.label1.Text = "INTEREST RATE";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(167, 93);
      this.label2.Name = "label2";
      this.label2.Size = new Size(105, 15);
      this.label2.TabIndex = 50;
      this.label2.Text = "INTRODUCED BY";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(214, 49);
      this.label3.Name = "label3";
      this.label3.Size = new Size(58, 15);
      this.label3.TabIndex = 53;
      this.label3.Text = "EMAIL ID";
      this.textBox5.BorderStyle = BorderStyle.FixedSingle;
      this.textBox5.CharacterCasing = CharacterCasing.Upper;
      this.textBox5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox5.Location = new Point(275, 90);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size((int) byte.MaxValue, 20);
      this.textBox5.TabIndex = 59;
      this.textBox6.BorderStyle = BorderStyle.FixedSingle;
      this.textBox6.CharacterCasing = CharacterCasing.Upper;
      this.textBox6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox6.Location = new Point(275, 68);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size((int) byte.MaxValue, 20);
      this.textBox6.TabIndex = 60;
      this.textBox7.BorderStyle = BorderStyle.FixedSingle;
      this.textBox7.CharacterCasing = CharacterCasing.Upper;
      this.textBox7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox7.Location = new Point(275, 116);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size((int) byte.MaxValue, 20);
      this.textBox7.TabIndex = 62;
      this.textBox8.BorderStyle = BorderStyle.FixedSingle;
      this.textBox8.CharacterCasing = CharacterCasing.Upper;
      this.textBox8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox8.Location = new Point(275, 140);
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size((int) byte.MaxValue, 20);
      this.textBox8.TabIndex = 63;
      this.textBox9.BorderStyle = BorderStyle.FixedSingle;
      this.textBox9.CharacterCasing = CharacterCasing.Upper;
      this.textBox9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox9.Location = new Point(274, 163);
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new Size((int) byte.MaxValue, 20);
      this.textBox9.TabIndex = 64;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(158, 119);
      this.label4.Name = "label4";
      this.label4.Size = new Size(112, 15);
      this.label4.TabIndex = 67;
      this.label4.Text = "AADHAR NUMBER";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(175, 167);
      this.label5.Name = "label5";
      this.label5.Size = new Size(94, 15);
      this.label5.TabIndex = 65;
      this.label5.Text = "OTHER PROOF";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(183, 142);
      this.label6.Name = "label6";
      this.label6.Size = new Size(87, 15);
      this.label6.TabIndex = 66;
      this.label6.Text = "RATION CARD";
      this.tabPage6.Controls.Add((Control) this.dgvSentSmsFather);
      this.tabPage6.Location = new Point(4, 22);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(3);
      this.tabPage6.Size = new Size(980, 201);
      this.tabPage6.TabIndex = 4;
      this.tabPage6.Text = "SENT SMS";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.dgvSentSmsFather.AllowUserToAddRows = false;
      this.dgvSentSmsFather.AllowUserToDeleteRows = false;
      this.dgvSentSmsFather.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSentSmsFather.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSentSmsFather.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvSentSmsFather.Dock = DockStyle.Fill;
      this.dgvSentSmsFather.Location = new Point(3, 3);
      this.dgvSentSmsFather.Name = "dgvSentSmsFather";
      this.dgvSentSmsFather.ReadOnly = true;
      this.dgvSentSmsFather.Size = new Size(974, 195);
      this.dgvSentSmsFather.TabIndex = 27;
      this.tabPage7.Controls.Add((Control) this.dgvInterestDeductionsFAther);
      this.tabPage7.Location = new Point(4, 22);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(980, 201);
      this.tabPage7.TabIndex = 5;
      this.tabPage7.Text = "INTEREST DEDUCTIONS";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.dgvInterestDeductionsFAther.AllowUserToAddRows = false;
      this.dgvInterestDeductionsFAther.AllowUserToDeleteRows = false;
      this.dgvInterestDeductionsFAther.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvInterestDeductionsFAther.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvInterestDeductionsFAther.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvInterestDeductionsFAther.Dock = DockStyle.Fill;
      this.dgvInterestDeductionsFAther.Location = new Point(3, 3);
      this.dgvInterestDeductionsFAther.Name = "dgvInterestDeductionsFAther";
      this.dgvInterestDeductionsFAther.ReadOnly = true;
      this.dgvInterestDeductionsFAther.Size = new Size(974, 195);
      this.dgvInterestDeductionsFAther.TabIndex = 28;
      this.tabPage8.Controls.Add((Control) this.dgvLastViewedFather);
      this.tabPage8.Location = new Point(4, 22);
      this.tabPage8.Name = "tabPage8";
      this.tabPage8.Padding = new Padding(3);
      this.tabPage8.Size = new Size(980, 201);
      this.tabPage8.TabIndex = 6;
      this.tabPage8.Text = "LAST VIEWED";
      this.tabPage8.UseVisualStyleBackColor = true;
      this.dgvLastViewedFather.AllowUserToAddRows = false;
      this.dgvLastViewedFather.AllowUserToDeleteRows = false;
      this.dgvLastViewedFather.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvLastViewedFather.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLastViewedFather.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvLastViewedFather.Dock = DockStyle.Fill;
      this.dgvLastViewedFather.Location = new Point(3, 3);
      this.dgvLastViewedFather.Name = "dgvLastViewedFather";
      this.dgvLastViewedFather.ReadOnly = true;
      this.dgvLastViewedFather.Size = new Size(974, 195);
      this.dgvLastViewedFather.TabIndex = 29;
      this.tbMother.Controls.Add((Control) this.tcMotherDetails);
      this.tbMother.Location = new Point(4, 22);
      this.tbMother.Name = "tbMother";
      this.tbMother.Padding = new Padding(3);
      this.tbMother.Size = new Size(994, 233);
      this.tbMother.TabIndex = 2;
      this.tbMother.Text = "Mother";
      this.tbMother.UseVisualStyleBackColor = true;
      this.tbMother.Click += new EventHandler(this.tbMother_Click);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage9);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage10);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage11);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage12);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage13);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage14);
      this.tcMotherDetails.Controls.Add((Control) this.tabPage15);
      this.tcMotherDetails.Dock = DockStyle.Fill;
      this.tcMotherDetails.Location = new Point(3, 3);
      this.tcMotherDetails.Name = "tcMotherDetails";
      this.tcMotherDetails.SelectedIndex = 0;
      this.tcMotherDetails.Size = new Size(988, 227);
      this.tcMotherDetails.TabIndex = 2;
      this.tabPage9.Controls.Add((Control) this.dgvPendingPledgesMother);
      this.tabPage9.Controls.Add((Control) this.pictureBox8);
      this.tabPage9.Location = new Point(4, 22);
      this.tabPage9.Name = "tabPage9";
      this.tabPage9.Padding = new Padding(3);
      this.tabPage9.Size = new Size(980, 201);
      this.tabPage9.TabIndex = 0;
      this.tabPage9.Text = "PENDING PLEDGES";
      this.tabPage9.UseVisualStyleBackColor = true;
      this.dgvPendingPledgesMother.AllowUserToAddRows = false;
      this.dgvPendingPledgesMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPendingPledgesMother.Columns.AddRange((DataGridViewColumn) this.colSelectMother);
      this.dgvPendingPledgesMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPendingPledgesMother.Dock = DockStyle.Fill;
      this.dgvPendingPledgesMother.Location = new Point(3, 3);
      this.dgvPendingPledgesMother.Name = "dgvPendingPledgesMother";
      this.dgvPendingPledgesMother.Size = new Size(974, 195);
      this.dgvPendingPledgesMother.TabIndex = 5;
      this.colSelectMother.HeaderText = "Select";
      this.colSelectMother.IndeterminateValue = (object) "false";
      this.colSelectMother.Name = "colSelectMother";
      this.pictureBox8.Location = new Point(769, 2);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(214, 224);
      this.pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox8.TabIndex = 4;
      this.pictureBox8.TabStop = false;
      this.pictureBox8.Visible = false;
      this.tabPage10.Controls.Add((Control) this.dgvRedeemedPledgesMother);
      this.tabPage10.Location = new Point(4, 22);
      this.tabPage10.Name = "tabPage10";
      this.tabPage10.Padding = new Padding(3);
      this.tabPage10.Size = new Size(980, 201);
      this.tabPage10.TabIndex = 1;
      this.tabPage10.Text = "REDEEMED PLEDGES";
      this.tabPage10.UseVisualStyleBackColor = true;
      this.dgvRedeemedPledgesMother.AllowUserToAddRows = false;
      this.dgvRedeemedPledgesMother.AllowUserToDeleteRows = false;
      this.dgvRedeemedPledgesMother.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvRedeemedPledgesMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRedeemedPledgesMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvRedeemedPledgesMother.Dock = DockStyle.Fill;
      this.dgvRedeemedPledgesMother.Location = new Point(3, 3);
      this.dgvRedeemedPledgesMother.Name = "dgvRedeemedPledgesMother";
      this.dgvRedeemedPledgesMother.ReadOnly = true;
      this.dgvRedeemedPledgesMother.Size = new Size(974, 195);
      this.dgvRedeemedPledgesMother.TabIndex = 25;
      this.tabPage11.Controls.Add((Control) this.dgvAuctionedPledgesMother);
      this.tabPage11.Location = new Point(4, 22);
      this.tabPage11.Name = "tabPage11";
      this.tabPage11.Padding = new Padding(3);
      this.tabPage11.Size = new Size(980, 201);
      this.tabPage11.TabIndex = 2;
      this.tabPage11.Text = "AUCTIONED PLEDGES";
      this.tabPage11.UseVisualStyleBackColor = true;
      this.dgvAuctionedPledgesMother.AllowUserToAddRows = false;
      this.dgvAuctionedPledgesMother.AllowUserToDeleteRows = false;
      this.dgvAuctionedPledgesMother.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAuctionedPledgesMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAuctionedPledgesMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvAuctionedPledgesMother.Dock = DockStyle.Fill;
      this.dgvAuctionedPledgesMother.Location = new Point(3, 3);
      this.dgvAuctionedPledgesMother.Name = "dgvAuctionedPledgesMother";
      this.dgvAuctionedPledgesMother.ReadOnly = true;
      this.dgvAuctionedPledgesMother.Size = new Size(974, 195);
      this.dgvAuctionedPledgesMother.TabIndex = 26;
      this.tabPage12.BackColor = SystemColors.Control;
      this.tabPage12.Controls.Add((Control) this.textBox10);
      this.tabPage12.Controls.Add((Control) this.pictureBox9);
      this.tabPage12.Controls.Add((Control) this.label7);
      this.tabPage12.Controls.Add((Control) this.label9);
      this.tabPage12.Controls.Add((Control) this.label10);
      this.tabPage12.Controls.Add((Control) this.textBox11);
      this.tabPage12.Controls.Add((Control) this.textBox12);
      this.tabPage12.Controls.Add((Control) this.textBox13);
      this.tabPage12.Controls.Add((Control) this.textBox14);
      this.tabPage12.Controls.Add((Control) this.textBox15);
      this.tabPage12.Controls.Add((Control) this.label11);
      this.tabPage12.Controls.Add((Control) this.label13);
      this.tabPage12.Controls.Add((Control) this.label18);
      this.tabPage12.Location = new Point(4, 22);
      this.tabPage12.Name = "tabPage12";
      this.tabPage12.Padding = new Padding(3);
      this.tabPage12.Size = new Size(980, 201);
      this.tabPage12.TabIndex = 3;
      this.tabPage12.Text = "CUSTOMER  DETAILS";
      this.textBox10.BorderStyle = BorderStyle.FixedSingle;
      this.textBox10.CharacterCasing = CharacterCasing.Upper;
      this.textBox10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox10.Location = new Point(275, 46);
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new Size((int) byte.MaxValue, 20);
      this.textBox10.TabIndex = 58;
      this.pictureBox9.Location = new Point(683, 6);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new Size(304, 243);
      this.pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox9.TabIndex = 73;
      this.pictureBox9.TabStop = false;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(172, 72);
      this.label7.Name = "label7";
      this.label7.Size = new Size(100, 15);
      this.label7.TabIndex = 52;
      this.label7.Text = "INTEREST RATE";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(167, 93);
      this.label9.Name = "label9";
      this.label9.Size = new Size(105, 15);
      this.label9.TabIndex = 50;
      this.label9.Text = "INTRODUCED BY";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(214, 49);
      this.label10.Name = "label10";
      this.label10.Size = new Size(58, 15);
      this.label10.TabIndex = 53;
      this.label10.Text = "EMAIL ID";
      this.textBox11.BorderStyle = BorderStyle.FixedSingle;
      this.textBox11.CharacterCasing = CharacterCasing.Upper;
      this.textBox11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox11.Location = new Point(275, 90);
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new Size((int) byte.MaxValue, 20);
      this.textBox11.TabIndex = 59;
      this.textBox12.BorderStyle = BorderStyle.FixedSingle;
      this.textBox12.CharacterCasing = CharacterCasing.Upper;
      this.textBox12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox12.Location = new Point(275, 68);
      this.textBox12.Name = "textBox12";
      this.textBox12.Size = new Size((int) byte.MaxValue, 20);
      this.textBox12.TabIndex = 60;
      this.textBox13.BorderStyle = BorderStyle.FixedSingle;
      this.textBox13.CharacterCasing = CharacterCasing.Upper;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox13.Location = new Point(275, 116);
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new Size((int) byte.MaxValue, 20);
      this.textBox13.TabIndex = 62;
      this.textBox14.BorderStyle = BorderStyle.FixedSingle;
      this.textBox14.CharacterCasing = CharacterCasing.Upper;
      this.textBox14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox14.Location = new Point(275, 140);
      this.textBox14.Name = "textBox14";
      this.textBox14.Size = new Size((int) byte.MaxValue, 20);
      this.textBox14.TabIndex = 63;
      this.textBox15.BorderStyle = BorderStyle.FixedSingle;
      this.textBox15.CharacterCasing = CharacterCasing.Upper;
      this.textBox15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox15.Location = new Point(274, 163);
      this.textBox15.Name = "textBox15";
      this.textBox15.Size = new Size((int) byte.MaxValue, 20);
      this.textBox15.TabIndex = 64;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(158, 119);
      this.label11.Name = "label11";
      this.label11.Size = new Size(112, 15);
      this.label11.TabIndex = 67;
      this.label11.Text = "AADHAR NUMBER";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(175, 167);
      this.label13.Name = "label13";
      this.label13.Size = new Size(94, 15);
      this.label13.TabIndex = 65;
      this.label13.Text = "OTHER PROOF";
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(183, 142);
      this.label18.Name = "label18";
      this.label18.Size = new Size(87, 15);
      this.label18.TabIndex = 66;
      this.label18.Text = "RATION CARD";
      this.tabPage13.Controls.Add((Control) this.dgvSentSmsMother);
      this.tabPage13.Location = new Point(4, 22);
      this.tabPage13.Name = "tabPage13";
      this.tabPage13.Padding = new Padding(3);
      this.tabPage13.Size = new Size(980, 201);
      this.tabPage13.TabIndex = 4;
      this.tabPage13.Text = "SENT SMS";
      this.tabPage13.UseVisualStyleBackColor = true;
      this.dgvSentSmsMother.AllowUserToAddRows = false;
      this.dgvSentSmsMother.AllowUserToDeleteRows = false;
      this.dgvSentSmsMother.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSentSmsMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSentSmsMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvSentSmsMother.Dock = DockStyle.Fill;
      this.dgvSentSmsMother.Location = new Point(3, 3);
      this.dgvSentSmsMother.Name = "dgvSentSmsMother";
      this.dgvSentSmsMother.ReadOnly = true;
      this.dgvSentSmsMother.Size = new Size(974, 195);
      this.dgvSentSmsMother.TabIndex = 27;
      this.tabPage14.Controls.Add((Control) this.dgvInterestDeductionsMother);
      this.tabPage14.Location = new Point(4, 22);
      this.tabPage14.Name = "tabPage14";
      this.tabPage14.Padding = new Padding(3);
      this.tabPage14.Size = new Size(980, 201);
      this.tabPage14.TabIndex = 5;
      this.tabPage14.Text = "INTEREST DEDUCTIONS";
      this.tabPage14.UseVisualStyleBackColor = true;
      this.dgvInterestDeductionsMother.AllowUserToAddRows = false;
      this.dgvInterestDeductionsMother.AllowUserToDeleteRows = false;
      this.dgvInterestDeductionsMother.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvInterestDeductionsMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvInterestDeductionsMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvInterestDeductionsMother.Dock = DockStyle.Fill;
      this.dgvInterestDeductionsMother.Location = new Point(3, 3);
      this.dgvInterestDeductionsMother.Name = "dgvInterestDeductionsMother";
      this.dgvInterestDeductionsMother.ReadOnly = true;
      this.dgvInterestDeductionsMother.Size = new Size(974, 195);
      this.dgvInterestDeductionsMother.TabIndex = 28;
      this.tabPage15.Controls.Add((Control) this.dgvLastViewedMother);
      this.tabPage15.Location = new Point(4, 22);
      this.tabPage15.Name = "tabPage15";
      this.tabPage15.Padding = new Padding(3);
      this.tabPage15.Size = new Size(980, 201);
      this.tabPage15.TabIndex = 6;
      this.tabPage15.Text = "LAST VIEWED";
      this.tabPage15.UseVisualStyleBackColor = true;
      this.dgvLastViewedMother.AllowUserToAddRows = false;
      this.dgvLastViewedMother.AllowUserToDeleteRows = false;
      this.dgvLastViewedMother.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvLastViewedMother.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLastViewedMother.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvLastViewedMother.Dock = DockStyle.Fill;
      this.dgvLastViewedMother.Location = new Point(3, 3);
      this.dgvLastViewedMother.Name = "dgvLastViewedMother";
      this.dgvLastViewedMother.ReadOnly = true;
      this.dgvLastViewedMother.Size = new Size(974, 195);
      this.dgvLastViewedMother.TabIndex = 29;
      this.tpSpouse.Controls.Add((Control) this.tcSpouseDetails);
      this.tpSpouse.Location = new Point(4, 22);
      this.tpSpouse.Name = "tpSpouse";
      this.tpSpouse.Padding = new Padding(3);
      this.tpSpouse.Size = new Size(994, 233);
      this.tpSpouse.TabIndex = 3;
      this.tpSpouse.Text = "Spouse";
      this.tpSpouse.UseVisualStyleBackColor = true;
      this.tpSpouse.Click += new EventHandler(this.tpSpouse_Click);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage16);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage17);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage18);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage19);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage20);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage21);
      this.tcSpouseDetails.Controls.Add((Control) this.tabPage22);
      this.tcSpouseDetails.Dock = DockStyle.Fill;
      this.tcSpouseDetails.Location = new Point(3, 3);
      this.tcSpouseDetails.Name = "tcSpouseDetails";
      this.tcSpouseDetails.SelectedIndex = 0;
      this.tcSpouseDetails.Size = new Size(988, 227);
      this.tcSpouseDetails.TabIndex = 2;
      this.tabPage16.Controls.Add((Control) this.dgvPendingPledgesSpouse);
      this.tabPage16.Controls.Add((Control) this.pictureBox10);
      this.tabPage16.Location = new Point(4, 22);
      this.tabPage16.Name = "tabPage16";
      this.tabPage16.Padding = new Padding(3);
      this.tabPage16.Size = new Size(980, 201);
      this.tabPage16.TabIndex = 0;
      this.tabPage16.Text = "PENDING PLEDGES";
      this.tabPage16.UseVisualStyleBackColor = true;
      this.dgvPendingPledgesSpouse.AllowUserToAddRows = false;
      this.dgvPendingPledgesSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPendingPledgesSpouse.Columns.AddRange((DataGridViewColumn) this.colSelectSpouse);
      this.dgvPendingPledgesSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvPendingPledgesSpouse.Dock = DockStyle.Fill;
      this.dgvPendingPledgesSpouse.Location = new Point(3, 3);
      this.dgvPendingPledgesSpouse.Name = "dgvPendingPledgesSpouse";
      this.dgvPendingPledgesSpouse.Size = new Size(974, 195);
      this.dgvPendingPledgesSpouse.TabIndex = 5;
      this.colSelectSpouse.HeaderText = "Select";
      this.colSelectSpouse.IndeterminateValue = (object) "false";
      this.colSelectSpouse.Name = "colSelectSpouse";
      this.pictureBox10.Location = new Point(769, 2);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new Size(214, 224);
      this.pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox10.TabIndex = 4;
      this.pictureBox10.TabStop = false;
      this.pictureBox10.Visible = false;
      this.tabPage17.Controls.Add((Control) this.dgvRedeemedPledgesSpouse);
      this.tabPage17.Location = new Point(4, 22);
      this.tabPage17.Name = "tabPage17";
      this.tabPage17.Padding = new Padding(3);
      this.tabPage17.Size = new Size(980, 201);
      this.tabPage17.TabIndex = 1;
      this.tabPage17.Text = "REDEEMED PLEDGES";
      this.tabPage17.UseVisualStyleBackColor = true;
      this.dgvRedeemedPledgesSpouse.AllowUserToAddRows = false;
      this.dgvRedeemedPledgesSpouse.AllowUserToDeleteRows = false;
      this.dgvRedeemedPledgesSpouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvRedeemedPledgesSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRedeemedPledgesSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvRedeemedPledgesSpouse.Dock = DockStyle.Fill;
      this.dgvRedeemedPledgesSpouse.Location = new Point(3, 3);
      this.dgvRedeemedPledgesSpouse.Name = "dgvRedeemedPledgesSpouse";
      this.dgvRedeemedPledgesSpouse.ReadOnly = true;
      this.dgvRedeemedPledgesSpouse.Size = new Size(974, 195);
      this.dgvRedeemedPledgesSpouse.TabIndex = 25;
      this.tabPage18.Controls.Add((Control) this.dgvAuctionedPledgesSpouse);
      this.tabPage18.Location = new Point(4, 22);
      this.tabPage18.Name = "tabPage18";
      this.tabPage18.Padding = new Padding(3);
      this.tabPage18.Size = new Size(980, 201);
      this.tabPage18.TabIndex = 2;
      this.tabPage18.Text = "AUCTIONED PLEDGES";
      this.tabPage18.UseVisualStyleBackColor = true;
      this.dgvAuctionedPledgesSpouse.AllowUserToAddRows = false;
      this.dgvAuctionedPledgesSpouse.AllowUserToDeleteRows = false;
      this.dgvAuctionedPledgesSpouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAuctionedPledgesSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAuctionedPledgesSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvAuctionedPledgesSpouse.Dock = DockStyle.Fill;
      this.dgvAuctionedPledgesSpouse.Location = new Point(3, 3);
      this.dgvAuctionedPledgesSpouse.Name = "dgvAuctionedPledgesSpouse";
      this.dgvAuctionedPledgesSpouse.ReadOnly = true;
      this.dgvAuctionedPledgesSpouse.Size = new Size(974, 195);
      this.dgvAuctionedPledgesSpouse.TabIndex = 26;
      this.tabPage19.BackColor = SystemColors.Control;
      this.tabPage19.Controls.Add((Control) this.textBox16);
      this.tabPage19.Controls.Add((Control) this.pictureBox11);
      this.tabPage19.Controls.Add((Control) this.label19);
      this.tabPage19.Controls.Add((Control) this.label20);
      this.tabPage19.Controls.Add((Control) this.label21);
      this.tabPage19.Controls.Add((Control) this.textBox17);
      this.tabPage19.Controls.Add((Control) this.textBox18);
      this.tabPage19.Controls.Add((Control) this.textBox19);
      this.tabPage19.Controls.Add((Control) this.textBox20);
      this.tabPage19.Controls.Add((Control) this.textBox21);
      this.tabPage19.Controls.Add((Control) this.label22);
      this.tabPage19.Controls.Add((Control) this.label23);
      this.tabPage19.Controls.Add((Control) this.label24);
      this.tabPage19.Location = new Point(4, 22);
      this.tabPage19.Name = "tabPage19";
      this.tabPage19.Padding = new Padding(3);
      this.tabPage19.Size = new Size(980, 201);
      this.tabPage19.TabIndex = 3;
      this.tabPage19.Text = "CUSTOMER  DETAILS";
      this.textBox16.BorderStyle = BorderStyle.FixedSingle;
      this.textBox16.CharacterCasing = CharacterCasing.Upper;
      this.textBox16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox16.Location = new Point(275, 46);
      this.textBox16.Name = "textBox16";
      this.textBox16.Size = new Size((int) byte.MaxValue, 20);
      this.textBox16.TabIndex = 58;
      this.pictureBox11.Location = new Point(683, 6);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new Size(304, 243);
      this.pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox11.TabIndex = 73;
      this.pictureBox11.TabStop = false;
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(172, 72);
      this.label19.Name = "label19";
      this.label19.Size = new Size(100, 15);
      this.label19.TabIndex = 52;
      this.label19.Text = "INTEREST RATE";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(167, 93);
      this.label20.Name = "label20";
      this.label20.Size = new Size(105, 15);
      this.label20.TabIndex = 50;
      this.label20.Text = "INTRODUCED BY";
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.Location = new Point(214, 49);
      this.label21.Name = "label21";
      this.label21.Size = new Size(58, 15);
      this.label21.TabIndex = 53;
      this.label21.Text = "EMAIL ID";
      this.textBox17.BorderStyle = BorderStyle.FixedSingle;
      this.textBox17.CharacterCasing = CharacterCasing.Upper;
      this.textBox17.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox17.Location = new Point(275, 90);
      this.textBox17.Name = "textBox17";
      this.textBox17.Size = new Size((int) byte.MaxValue, 20);
      this.textBox17.TabIndex = 59;
      this.textBox18.BorderStyle = BorderStyle.FixedSingle;
      this.textBox18.CharacterCasing = CharacterCasing.Upper;
      this.textBox18.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox18.Location = new Point(275, 68);
      this.textBox18.Name = "textBox18";
      this.textBox18.Size = new Size((int) byte.MaxValue, 20);
      this.textBox18.TabIndex = 60;
      this.textBox19.BorderStyle = BorderStyle.FixedSingle;
      this.textBox19.CharacterCasing = CharacterCasing.Upper;
      this.textBox19.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox19.Location = new Point(275, 116);
      this.textBox19.Name = "textBox19";
      this.textBox19.Size = new Size((int) byte.MaxValue, 20);
      this.textBox19.TabIndex = 62;
      this.textBox20.BorderStyle = BorderStyle.FixedSingle;
      this.textBox20.CharacterCasing = CharacterCasing.Upper;
      this.textBox20.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox20.Location = new Point(275, 140);
      this.textBox20.Name = "textBox20";
      this.textBox20.Size = new Size((int) byte.MaxValue, 20);
      this.textBox20.TabIndex = 63;
      this.textBox21.BorderStyle = BorderStyle.FixedSingle;
      this.textBox21.CharacterCasing = CharacterCasing.Upper;
      this.textBox21.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox21.Location = new Point(274, 163);
      this.textBox21.Name = "textBox21";
      this.textBox21.Size = new Size((int) byte.MaxValue, 20);
      this.textBox21.TabIndex = 64;
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.Location = new Point(158, 119);
      this.label22.Name = "label22";
      this.label22.Size = new Size(112, 15);
      this.label22.TabIndex = 67;
      this.label22.Text = "AADHAR NUMBER";
      this.label23.AutoSize = true;
      this.label23.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label23.Location = new Point(175, 167);
      this.label23.Name = "label23";
      this.label23.Size = new Size(94, 15);
      this.label23.TabIndex = 65;
      this.label23.Text = "OTHER PROOF";
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label24.Location = new Point(183, 142);
      this.label24.Name = "label24";
      this.label24.Size = new Size(87, 15);
      this.label24.TabIndex = 66;
      this.label24.Text = "RATION CARD";
      this.tabPage20.Controls.Add((Control) this.dgvSentSmsSpouse);
      this.tabPage20.Location = new Point(4, 22);
      this.tabPage20.Name = "tabPage20";
      this.tabPage20.Padding = new Padding(3);
      this.tabPage20.Size = new Size(980, 201);
      this.tabPage20.TabIndex = 4;
      this.tabPage20.Text = "SENT SMS";
      this.tabPage20.UseVisualStyleBackColor = true;
      this.dgvSentSmsSpouse.AllowUserToAddRows = false;
      this.dgvSentSmsSpouse.AllowUserToDeleteRows = false;
      this.dgvSentSmsSpouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSentSmsSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSentSmsSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvSentSmsSpouse.Dock = DockStyle.Fill;
      this.dgvSentSmsSpouse.Location = new Point(3, 3);
      this.dgvSentSmsSpouse.Name = "dgvSentSmsSpouse";
      this.dgvSentSmsSpouse.ReadOnly = true;
      this.dgvSentSmsSpouse.Size = new Size(974, 195);
      this.dgvSentSmsSpouse.TabIndex = 27;
      this.tabPage21.Controls.Add((Control) this.dgvInterestDeductionsSpouse);
      this.tabPage21.Location = new Point(4, 22);
      this.tabPage21.Name = "tabPage21";
      this.tabPage21.Padding = new Padding(3);
      this.tabPage21.Size = new Size(980, 201);
      this.tabPage21.TabIndex = 5;
      this.tabPage21.Text = "INTEREST DEDUCTIONS";
      this.tabPage21.UseVisualStyleBackColor = true;
      this.dgvInterestDeductionsSpouse.AllowUserToAddRows = false;
      this.dgvInterestDeductionsSpouse.AllowUserToDeleteRows = false;
      this.dgvInterestDeductionsSpouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvInterestDeductionsSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvInterestDeductionsSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvInterestDeductionsSpouse.Dock = DockStyle.Fill;
      this.dgvInterestDeductionsSpouse.Location = new Point(3, 3);
      this.dgvInterestDeductionsSpouse.Name = "dgvInterestDeductionsSpouse";
      this.dgvInterestDeductionsSpouse.ReadOnly = true;
      this.dgvInterestDeductionsSpouse.Size = new Size(974, 195);
      this.dgvInterestDeductionsSpouse.TabIndex = 28;
      this.tabPage22.Controls.Add((Control) this.dgvLastViewedSpouse);
      this.tabPage22.Location = new Point(4, 22);
      this.tabPage22.Name = "tabPage22";
      this.tabPage22.Padding = new Padding(3);
      this.tabPage22.Size = new Size(980, 201);
      this.tabPage22.TabIndex = 6;
      this.tabPage22.Text = "LAST VIEWED";
      this.tabPage22.UseVisualStyleBackColor = true;
      this.dgvLastViewedSpouse.AllowUserToAddRows = false;
      this.dgvLastViewedSpouse.AllowUserToDeleteRows = false;
      this.dgvLastViewedSpouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvLastViewedSpouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLastViewedSpouse.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvLastViewedSpouse.Dock = DockStyle.Fill;
      this.dgvLastViewedSpouse.Location = new Point(3, 3);
      this.dgvLastViewedSpouse.Name = "dgvLastViewedSpouse";
      this.dgvLastViewedSpouse.ReadOnly = true;
      this.dgvLastViewedSpouse.Size = new Size(974, 195);
      this.dgvLastViewedSpouse.TabIndex = 29;
      this.bwSelf.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.bwSelf.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.bwFather.DoWork += new DoWorkEventHandler(this.bwFather_DoWork);
      this.bwFather.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwFather_RunWorkerCompleted);
      this.bwMother.DoWork += new DoWorkEventHandler(this.bwMother_DoWork);
      this.bwMother.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwMother_RunWorkerCompleted);
      this.bwSpouse.DoWork += new DoWorkEventHandler(this.bwSpouse_DoWork);
      this.bwSpouse.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwSpouse_RunWorkerCompleted);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1009, 601);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel3);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormViewCustomerDetails);
      this.Text = "Customer Details";
      this.Load += new EventHandler(this.FormCustomerPledgeDetailss_Load);
      this.tcSelfDetails.ResumeLayout(false);
      this.tpPendingPledges.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPendingPledgeDetails).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.tpRedeemedPledges.ResumeLayout(false);
      ((ISupportInitialize) this.dgvRedeemedPledges).EndInit();
      this.tpAuctionedPledges.ResumeLayout(false);
      ((ISupportInitialize) this.dgvAuctionedPledges).EndInit();
      this.tpCustomerDetails.ResumeLayout(false);
      this.tpCustomerDetails.PerformLayout();
      ((ISupportInitialize) this.picProofPhoto).EndInit();
      this.tpSentSms.ResumeLayout(false);
      ((ISupportInitialize) this.dgvSentSms).EndInit();
      this.tpInterestDeductions.ResumeLayout(false);
      ((ISupportInitialize) this.dgvInterestDeductions).EndInit();
      this.tabPage1.ResumeLayout(false);
      ((ISupportInitialize) this.dgvLastViewed).EndInit();
      ((ISupportInitialize) this.dgvCustomerDetails).EndInit();
      ((ISupportInitialize) this.picProfilePhoto).EndInit();
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel13).ResumeLayout(false);
      ((Control) this.headerPanel13).PerformLayout();
      ((Control) this.headerPanel12).ResumeLayout(false);
      ((Control) this.headerPanel12).PerformLayout();
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel11).PerformLayout();
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel10).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel9).PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel14).ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.panel3.ResumeLayout(false);
      this.tcSelfFatherMotherSpouse.ResumeLayout(false);
      this.tbSelf.ResumeLayout(false);
      this.tbFather.ResumeLayout(false);
      this.tcFatherDetails.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPendingPledgesFather).EndInit();
      ((ISupportInitialize) this.pictureBox6).EndInit();
      this.tabPage3.ResumeLayout(false);
      ((ISupportInitialize) this.dgvRedeemedPledgesFather).EndInit();
      this.tabPage4.ResumeLayout(false);
      ((ISupportInitialize) this.dgvAuctionedPledgesFather).EndInit();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      ((ISupportInitialize) this.pictureBox7).EndInit();
      this.tabPage6.ResumeLayout(false);
      ((ISupportInitialize) this.dgvSentSmsFather).EndInit();
      this.tabPage7.ResumeLayout(false);
      ((ISupportInitialize) this.dgvInterestDeductionsFAther).EndInit();
      this.tabPage8.ResumeLayout(false);
      ((ISupportInitialize) this.dgvLastViewedFather).EndInit();
      this.tbMother.ResumeLayout(false);
      this.tcMotherDetails.ResumeLayout(false);
      this.tabPage9.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPendingPledgesMother).EndInit();
      ((ISupportInitialize) this.pictureBox8).EndInit();
      this.tabPage10.ResumeLayout(false);
      ((ISupportInitialize) this.dgvRedeemedPledgesMother).EndInit();
      this.tabPage11.ResumeLayout(false);
      ((ISupportInitialize) this.dgvAuctionedPledgesMother).EndInit();
      this.tabPage12.ResumeLayout(false);
      this.tabPage12.PerformLayout();
      ((ISupportInitialize) this.pictureBox9).EndInit();
      this.tabPage13.ResumeLayout(false);
      ((ISupportInitialize) this.dgvSentSmsMother).EndInit();
      this.tabPage14.ResumeLayout(false);
      ((ISupportInitialize) this.dgvInterestDeductionsMother).EndInit();
      this.tabPage15.ResumeLayout(false);
      ((ISupportInitialize) this.dgvLastViewedMother).EndInit();
      this.tpSpouse.ResumeLayout(false);
      this.tcSpouseDetails.ResumeLayout(false);
      this.tabPage16.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPendingPledgesSpouse).EndInit();
      ((ISupportInitialize) this.pictureBox10).EndInit();
      this.tabPage17.ResumeLayout(false);
      ((ISupportInitialize) this.dgvRedeemedPledgesSpouse).EndInit();
      this.tabPage18.ResumeLayout(false);
      ((ISupportInitialize) this.dgvAuctionedPledgesSpouse).EndInit();
      this.tabPage19.ResumeLayout(false);
      this.tabPage19.PerformLayout();
      ((ISupportInitialize) this.pictureBox11).EndInit();
      this.tabPage20.ResumeLayout(false);
      ((ISupportInitialize) this.dgvSentSmsSpouse).EndInit();
      this.tabPage21.ResumeLayout(false);
      ((ISupportInitialize) this.dgvInterestDeductionsSpouse).EndInit();
      this.tabPage22.ResumeLayout(false);
      ((ISupportInitialize) this.dgvLastViewedSpouse).EndInit();
      this.ResumeLayout(false);
    }
  }
}
