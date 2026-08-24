
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
using System.IO;
using System.Windows.Forms;
using ZeeUIUtility;

namespace PawnManagement.Forms
{
  public class FormViewPledgeBillNew : Form
  {
    private string BillNumber = "";
    private string ShopCode = "";
    private string y = "";
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private HeaderPanel headerPanel2;
    private TextBox tbxOldBillNumber;
    private TextBox tbxPureWeight;
    private TextBox tbxValue;
    private TextBox tbxAmount;
    private TextBox tbxInteresRate;
    private TextBox tbxNetWeight;
    private TextBox tbxTotalInterest;
    private TextBox tbxReminder;
    private TextBox tbxweight;
    private TextBox tbxDeductions;
    private ComboBox cbType;
    private TextBox textBox13;
    private TextBox textBox12;
    private TextBox textBox11;
    private TextBox textBox10;
    private TextBox textBox9;
    private TextBox textBox8;
    private TextBox textBox7;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox5;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxBillDate;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxBillNumber;
    private HeaderPanel headerPanel7;
    private TextBox tbxShopCode;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel3;
    private DataGridViewEx dgvArticles;
    private HeaderPanel headerPanel1;
    private Label label5;
    private Label label4;
    private Label label3;
    private RichTextBox richTextBox1;
    private Label label2;
    private TextBox tbxAverageNumberOfDaysForRelease;
    private TextBox tbxNotes;
    private TextBox tbxNumberOfTimesReleaseExceedTwelveMonths;
    private TextBox tbxCustomerName;
    private PictureBox pictureBox2;
    private TextBox tbxCustomerCode;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCell;
    private HeaderPanel hpREdemptionDetails;
    private Label label13;
    private PictureBox pictureBox1;
    private TextBox tbxRedemptionBillNumber;
    private TextBox tbxRedemptionDate;
    private Label label10;
    private Label label12;
    private TextBox tbxNoOfMonths;
    private Label label18;
    private TextBox tbxInterest;
    private TextBox tbxNoticeCharge;
    private Label label17;
    private TextBox tbxDiscount;
    private Label label19;
    private TextBox tbxOtherCharge;
    private TextBox tbxReceive;
    private TextBox tbxFinalInterest;
    private Label label15;
    private TextBox tbxPaymentReceived;
    private Label label14;
    private TextBox tbxTotal;
    private Label label9;
    private Label label11;
    private Label label8;
    private TextBox tbxInterestLess;
    private Label label7;
    private Label label16;
    private TextBox tbxBankDetails;
    private GlassButton btnPaymentReceivedDetails;

    public FormViewPledgeBillNew() => this.InitializeComponent();

    public FormViewPledgeBillNew(string BILLNUMBER, string SHOPCODE)
    {
      this.BillNumber = BILLNUMBER;
      this.ShopCode = SHOPCODE;
      this.InitializeComponent();
    }

    public FormViewPledgeBillNew(string BILLNUMBER, string SHOPCODE, string Y)
    {
      this.BillNumber = BILLNUMBER;
      this.ShopCode = SHOPCODE;
      this.y = Y;
      this.InitializeComponent();
    }

    private void getBillDetails(string BillNumber)
    {
      string strError = "";
      string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeedit.tbxbillnumber_leave", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
        this.tbxBillNumber.Select();
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxBillNumber.ForeColor = Color.Black;
        this.tbxCustomerCode.Text = dataTable2.Rows[0]["CustomerCode"].ToString();
        this.tbxCustomerName.Text = dataTable2.Rows[0]["CustomerName"].ToString();
        this.richTextBox1.Text = dataTable2.Rows[0]["DoorNumber"].ToString() + dataTable2.Rows[0]["Addr1"].ToString() + dataTable2.Rows[0]["Addr2"].ToString();
        this.cbType.Text = dataTable2.Rows[0]["Type"].ToString();
        this.tbxweight.Text = dataTable2.Rows[0]["GrossWeight"].ToString();
        this.tbxDeductions.Text = dataTable2.Rows[0]["Deduction"].ToString();
        this.tbxNetWeight.Text = dataTable2.Rows[0]["NetWeight"].ToString();
        this.tbxPureWeight.Text = dataTable2.Rows[0]["PureWeight"].ToString();
        this.tbxValue.Text = dataTable2.Rows[0].Field<int>("PresentValue").ToString();
        this.tbxAmount.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
        this.tbxBillDate.Text = dataTable2.Rows[0].Field<DateTime>("BillDate").ToString("dd/MM/yyyy");
        this.tbxInteresRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
        this.tbxTotalInterest.Text = dataTable2.Rows[0]["temp5"].ToString();
        this.tbxShopCode.Text = dataTable2.Rows[0]["ShopCode"].ToString();
        this.tbxNotes.Text = dataTable2.Rows[0]["Reminder"].ToString();
        this.getdgvArticles(BillNumber);
        this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
        if (this.checkIfBankPledgeReleasedOrNot(this.getBankBillNumber(BillNumber)))
        {
          this.tbxBankDetails.Text = "";
          this.tbxBankDetails.Text = dataTable2.Rows[0]["BankCode"].ToString();
          this.getBankPledgeDetails(this.getBankBillNumber(BillNumber));
          if (this.tbxBankDetails.Text != "")
            this.tbxBankDetails.Visible = true;
        }
        if (dataTable2.Rows[0]["Redeemed"].ToString() == "Y")
        {
          DataTable redemptionBill = this.getRedemptionBill(this.tbxBillNumber.Text);
          if (redemptionBill != null && redemptionBill.Rows.Count > 0)
          {
            this.tbxBillNumber.ForeColor = Color.Red;
            this.tbxRedemptionBillNumber.Text = redemptionBill.Rows[0][nameof (BillNumber)].ToString();
            this.tbxRedemptionDate.Text = DateTime.Parse(redemptionBill.Rows[0]["BillDate"].ToString()).ToShortDateString();
            this.tbxNoOfMonths.Text = redemptionBill.Rows[0]["Noofmonths"].ToString();
            this.tbxInterest.Text = redemptionBill.Rows[0]["TEMP2"].ToString();
            this.tbxPaymentReceived.Text = "";
            this.tbxInterestLess.Text = "";
            this.tbxNoticeCharge.Text = redemptionBill.Rows[0]["NoticeCharge"].ToString();
            this.tbxOtherCharge.Text = redemptionBill.Rows[0]["OtherCharge"].ToString();
            this.tbxDiscount.Text = redemptionBill.Rows[0]["Deductions"].ToString();
            this.tbxFinalInterest.Text = redemptionBill.Rows[0]["temp3"].ToString();
            this.tbxTotal.Text = redemptionBill.Rows[0]["temp4"].ToString();
            this.getReleasedByWhomPicture(this.tbxRedemptionBillNumber.Text);
          }
          else
          {
            this.tbxBillNumber.ForeColor = Color.Black;
            this.resetRedemptionDetails();
          }
        }
        else if (dataTable2.Rows[0]["Redeemed"].ToString() == "A")
        {
          this.tbxBillNumber.ForeColor = Color.Red;
        }
        else
        {
          this.tbxBillNumber.ForeColor = Color.Black;
          this.resetRedemptionDetails();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Enter valid Bill Number");
        this.tbxBillNumber.Select();
      }
    }

    private bool checkIfBankPledgeReleasedOrNot(string BankBillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) BankBillNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != "") && dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["Released"] != null && dataTable2.Rows[0]["Released"].ToString() == "N")
          return true;
        if (dataTable2.Rows[0]["Released"] != null && dataTable2.Rows[0]["Released"].ToString() == "Y")
          return false;
      }
      return false;
    }

    private void getBankPledgeDetails(string bankBillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankBillNumber", (object) bankBillNumber.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption. getBankPledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
      {
        this.tbxBankDetails.Text = dataTable2.Rows[0].Field<int>("SerialNumber").ToString() + "," + bankBillNumber + "," + dataTable2.Rows[0].Field<string>("BankCode").ToString() + ", " + dataTable2.Rows[0]["Amount"].ToString();
        this.tbxBankDetails.Visible = true;
      }
    }

    private string getBankBillNumber(string billNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankpledgePledgeBills where shopCode = @shopCode and  PledgeBillNumber = @PledgeBillNumber order by serialNumber desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("shopCode", (object) this.tbxShopCode.Text));
      parameters.Add(new OleDbParameter("PledgeBillNumber", (object) billNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBankBillNumber(string billNumber)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving the Bank bill number from tbl bankpledgepledgebills" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0].Field<string>("BankBillNumber");
      return "";
    }

    private void resetRedemptionDetails()
    {
      this.tbxRedemptionBillNumber.Text = "";
      this.tbxRedemptionDate.Text = "";
      this.tbxNoOfMonths.Text = "";
      this.tbxInterest.Text = "";
      this.tbxPaymentReceived.Text = "";
      this.tbxInterestLess.Text = "";
      this.tbxNoticeCharge.Text = "";
      this.tbxOtherCharge.Text = "";
      this.tbxDiscount.Text = "";
      this.tbxFinalInterest.Text = "";
      this.tbxTotal.Text = "";
    }

    private DataTable getRedemptionBill(string PledgeBillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where PledgeBillNumber=@PledgeBillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.tbxShopCode.Text.Trim().ToString()));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    private void getReleasedByWhomPicture(string RedemptionBillNumber)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\Released By\\" + RedemptionBillNumber + " " + this.tbxShopCode.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\Released By\\" + RedemptionBillNumber + " " + this.tbxShopCode.Text + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else
          this.getPictureReleasedBy(this.tbxCustomerCode.Text);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPictureReleasedBy(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
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

    private void getPicture(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
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

    private void getdgvArticles(string BillNumber)
    {
      string strError = "";
      string my_querry = !FormMain.withIndividualWeight ? "Select  Articles,ArticlesDescription,Hr, Num from tblPledgeArticles where BillNumber = @BillNumber AND ShopCode = @ShopCode" : "Select Articles, ArticlesDescription,Hr,Purity,GrossWeight,Deduction,NetWeight,PureWeight,Num from tblPledgeArticles where BillNumber = @BillNumber AND ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeeidt.getdgvarticles()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            ((DataGridView) this.dgvArticles).DataSource = (object) dataTable2;
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledgeEdit.getdgvArticles()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void FormViewPledgeBillNew_Load(object sender, EventArgs e)
    {
      this.tbxBillNumber.Text = this.BillNumber;
      this.getBillDetails(this.BillNumber);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormViewPledgeBillNew_MouseLeave(object sender, EventArgs e)
    {
    }

    private void FormViewPledgeBillNew_Leave(object sender, EventArgs e)
    {
    }

    private void panel1_MouseLeave(object sender, EventArgs e)
    {
    }

    private void btnPaymentReceivedDetails_Click(object sender, EventArgs e)
    {
      if (!(this.tbxBillNumber.Text.Trim() != ""))
        return;
      int num = (int) new FormPaymentDetailsForBillNumber(this.tbxBillNumber.Text, this.tbxShopCode.Text).ShowDialog();
    }

    private void tbxBillNumber_TextChanged(object sender, EventArgs e)
    {
    }

    private void glassButton6_Click(object sender, EventArgs e) => new FormDuplicateBill(this.tbxBillNumber.Text, this.tbxShopCode.Text).Show();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.panel1 = new Panel();
      this.hpREdemptionDetails = new HeaderPanel();
      this.label13 = new Label();
      this.pictureBox1 = new PictureBox();
      this.tbxRedemptionBillNumber = new TextBox();
      this.tbxRedemptionDate = new TextBox();
      this.label10 = new Label();
      this.label12 = new Label();
      this.tbxNoOfMonths = new TextBox();
      this.label18 = new Label();
      this.tbxInterest = new TextBox();
      this.tbxNoticeCharge = new TextBox();
      this.label17 = new Label();
      this.tbxDiscount = new TextBox();
      this.label19 = new Label();
      this.tbxOtherCharge = new TextBox();
      this.tbxReceive = new TextBox();
      this.tbxFinalInterest = new TextBox();
      this.label15 = new Label();
      this.tbxPaymentReceived = new TextBox();
      this.label14 = new Label();
      this.tbxTotal = new TextBox();
      this.label9 = new Label();
      this.label11 = new Label();
      this.label8 = new Label();
      this.tbxInterestLess = new TextBox();
      this.label7 = new Label();
      this.label16 = new Label();
      this.headerPanel2 = new HeaderPanel();
      this.tbxOldBillNumber = new TextBox();
      this.tbxPureWeight = new TextBox();
      this.tbxValue = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxInteresRate = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.tbxTotalInterest = new TextBox();
      this.tbxReminder = new TextBox();
      this.tbxweight = new TextBox();
      this.tbxDeductions = new TextBox();
      this.cbType = new ComboBox();
      this.textBox13 = new TextBox();
      this.textBox12 = new TextBox();
      this.textBox11 = new TextBox();
      this.textBox10 = new TextBox();
      this.textBox9 = new TextBox();
      this.textBox8 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox5 = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxBillDate = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxBillNumber = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.tbxShopCode = new TextBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.btnPaymentReceivedDetails = new GlassButton();
      this.dgvArticles = new DataGridViewEx();
      this.headerPanel1 = new HeaderPanel();
      this.tbxBankDetails = new TextBox();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.richTextBox1 = new RichTextBox();
      this.label2 = new Label();
      this.tbxAverageNumberOfDaysForRelease = new TextBox();
      this.tbxNotes = new TextBox();
      this.tbxNumberOfTimesReleaseExceedTwelveMonths = new TextBox();
      this.tbxCustomerName = new TextBox();
      this.pictureBox2 = new PictureBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCell = new TextBox();
      this.panel1.SuspendLayout();
      ((Control) this.hpREdemptionDetails).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      ((Control) this.headerPanel1).SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.Transparent;
      this.panel1.Controls.Add((Control) this.hpREdemptionDetails);
      this.panel1.Controls.Add((Control) this.headerPanel2);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.headerPanel5);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.headerPanel3);
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1008, 480);
      this.panel1.TabIndex = 58;
      this.panel1.MouseLeave += new EventHandler(this.panel1_MouseLeave);
      ((Control) this.hpREdemptionDetails).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.hpREdemptionDetails).BackColor = Color.AliceBlue;
      this.hpREdemptionDetails.BorderColor = SystemColors.HotTrack;
      this.hpREdemptionDetails.BorderStyle = BorderStyles.Single;
      this.hpREdemptionDetails.CaptionBeginColor = Color.Azure;
      this.hpREdemptionDetails.CaptionEndColor = Color.SkyBlue;
      this.hpREdemptionDetails.CaptionGradientDirection = LinearGradientMode.BackwardDiagonal;
      this.hpREdemptionDetails.CaptionHeight = 22;
      this.hpREdemptionDetails.CaptionPosition = CaptionPositions.Top;
      this.hpREdemptionDetails.CaptionText = "REDEMPTION DETAILS";
      this.hpREdemptionDetails.CaptionVisible = true;
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label13);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.pictureBox1);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxRedemptionBillNumber);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxRedemptionDate);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label10);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label12);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxNoOfMonths);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label18);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxInterest);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxNoticeCharge);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label17);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxDiscount);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label19);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxOtherCharge);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxReceive);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxFinalInterest);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label15);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxPaymentReceived);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label14);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxTotal);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label9);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label11);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label8);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxInterestLess);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label7);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label16);
      ((Control) this.hpREdemptionDetails).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpREdemptionDetails).ForeColor = Color.DarkBlue;
      this.hpREdemptionDetails.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.hpREdemptionDetails.GradientEnd = Color.Azure;
      this.hpREdemptionDetails.GradientStart = Color.AliceBlue;
      ((Control) this.hpREdemptionDetails).Location = new Point(710, 4);
      ((Control) this.hpREdemptionDetails).Name = "hpREdemptionDetails";
      this.hpREdemptionDetails.PanelIcon = (Icon) null;
      this.hpREdemptionDetails.PanelIconVisible = false;
      ((Control) this.hpREdemptionDetails).Size = new Size(292, 467);
      ((Control) this.hpREdemptionDetails).TabIndex = 91;
      this.hpREdemptionDetails.TextAntialias = true;
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(41, 314);
      this.label13.Name = "label13";
      this.label13.Size = new Size(101, 16);
      this.label13.TabIndex = 89;
      this.label13.Text = "RELEASED BY";
      this.pictureBox1.Location = new Point(146, 310);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(137, 130);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 36;
      this.pictureBox1.TabStop = false;
      this.tbxRedemptionBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRedemptionBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionBillNumber.ForeColor = SystemColors.MenuHighlight;
      this.tbxRedemptionBillNumber.Location = new Point(146, 8);
      this.tbxRedemptionBillNumber.MaxLength = 2;
      this.tbxRedemptionBillNumber.Name = "tbxRedemptionBillNumber";
      this.tbxRedemptionBillNumber.Size = new Size(136, 22);
      this.tbxRedemptionBillNumber.TabIndex = 86;
      this.tbxRedemptionBillNumber.TextAlign = HorizontalAlignment.Right;
      this.tbxRedemptionDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRedemptionDate.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionDate.ForeColor = SystemColors.ControlText;
      this.tbxRedemptionDate.Location = new Point(146, 33);
      this.tbxRedemptionDate.Name = "tbxRedemptionDate";
      this.tbxRedemptionDate.Size = new Size(136, 22);
      this.tbxRedemptionDate.TabIndex = 85;
      this.tbxRedemptionDate.TextAlign = HorizontalAlignment.Right;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(4, 13);
      this.label10.Name = "label10";
      this.label10.Size = new Size(139, 16);
      this.label10.TabIndex = 87;
      this.label10.Text = "REDEMTION BILL No";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(5, 40);
      this.label12.Name = "label12";
      this.label12.Size = new Size(138, 16);
      this.label12.TabIndex = 88;
      this.label12.Text = "REDEMPTION DATE";
      this.tbxNoOfMonths.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoOfMonths.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfMonths.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoOfMonths.Location = new Point(146, 62);
      this.tbxNoOfMonths.MaxLength = 2;
      this.tbxNoOfMonths.Name = "tbxNoOfMonths";
      this.tbxNoOfMonths.Size = new Size(136, 22);
      this.tbxNoOfMonths.TabIndex = 9;
      this.tbxNoOfMonths.TextAlign = HorizontalAlignment.Right;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(29, 141);
      this.label18.Name = "label18";
      this.label18.Size = new Size(113, 16);
      this.label18.TabIndex = 81;
      this.label18.Text = "INTEREST LESS";
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.ForeColor = SystemColors.ControlText;
      this.tbxInterest.Location = new Point(146, 87);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(136, 22);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxNoticeCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeCharge.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoticeCharge.Location = new Point(146, 162);
      this.tbxNoticeCharge.Name = "tbxNoticeCharge";
      this.tbxNoticeCharge.Size = new Size(136, 22);
      this.tbxNoticeCharge.TabIndex = 4;
      this.tbxNoticeCharge.Text = "0";
      this.tbxNoticeCharge.TextAlign = HorizontalAlignment.Right;
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(18, 118);
      this.label17.Name = "label17";
      this.label17.Size = new Size(124, 16);
      this.label17.TabIndex = 78;
      this.label17.Text = "PAYMENT RECVD";
      this.tbxDiscount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDiscount.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDiscount.ForeColor = SystemColors.MenuHighlight;
      this.tbxDiscount.Location = new Point(146, 212);
      this.tbxDiscount.Name = "tbxDiscount";
      this.tbxDiscount.Size = new Size(136, 22);
      this.tbxDiscount.TabIndex = 6;
      this.tbxDiscount.Text = "0";
      this.tbxDiscount.TextAlign = HorizontalAlignment.Right;
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(76, 291);
      this.label19.Name = "label19";
      this.label19.Size = new Size(66, 16);
      this.label19.TabIndex = 84;
      this.label19.Text = "RECEIVE";
      this.tbxOtherCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherCharge.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxOtherCharge.Location = new Point(146, 187);
      this.tbxOtherCharge.Name = "tbxOtherCharge";
      this.tbxOtherCharge.Size = new Size(136, 22);
      this.tbxOtherCharge.TabIndex = 5;
      this.tbxOtherCharge.Text = "0";
      this.tbxOtherCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxReceive.BackColor = Color.Moccasin;
      this.tbxReceive.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReceive.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxReceive.ForeColor = Color.Firebrick;
      this.tbxReceive.Location = new Point(146, 287);
      this.tbxReceive.Name = "tbxReceive";
      this.tbxReceive.Size = new Size(136, 22);
      this.tbxReceive.TabIndex = 83;
      this.tbxReceive.TextAlign = HorizontalAlignment.Right;
      this.tbxFinalInterest.BackColor = Color.Moccasin;
      this.tbxFinalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFinalInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFinalInterest.ForeColor = Color.Firebrick;
      this.tbxFinalInterest.Location = new Point(146, 237);
      this.tbxFinalInterest.Name = "tbxFinalInterest";
      this.tbxFinalInterest.ReadOnly = true;
      this.tbxFinalInterest.Size = new Size(136, 22);
      this.tbxFinalInterest.TabIndex = 7;
      this.tbxFinalInterest.TextAlign = HorizontalAlignment.Right;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(26, 242);
      this.label15.Name = "label15";
      this.label15.Size = new Size(116, 16);
      this.label15.TabIndex = 65;
      this.label15.Text = "FINAL INTEREST";
      this.tbxPaymentReceived.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPaymentReceived.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPaymentReceived.ForeColor = SystemColors.MenuHighlight;
      this.tbxPaymentReceived.Location = new Point(146, 112);
      this.tbxPaymentReceived.Name = "tbxPaymentReceived";
      this.tbxPaymentReceived.Size = new Size(136, 22);
      this.tbxPaymentReceived.TabIndex = 77;
      this.tbxPaymentReceived.Text = "0";
      this.tbxPaymentReceived.TextAlign = HorizontalAlignment.Right;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(54, 217);
      this.label14.Name = "label14";
      this.label14.Size = new Size(88, 16);
      this.label14.TabIndex = 64;
      this.label14.Text = "DEDUCTION";
      this.tbxTotal.BackColor = Color.Moccasin;
      this.tbxTotal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.ForeColor = Color.Firebrick;
      this.tbxTotal.Location = new Point(146, 262);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(136, 22);
      this.tbxTotal.TabIndex = 8;
      this.tbxTotal.TextAlign = HorizontalAlignment.Right;
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(26, 191);
      this.label9.Name = "label9";
      this.label9.Size = new Size(116, 16);
      this.label9.TabIndex = 63;
      this.label9.Text = "OTHER CHARGE";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(31, 67);
      this.label11.Name = "label11";
      this.label11.Size = new Size(111, 16);
      this.label11.TabIndex = 60;
      this.label11.Text = "NO OF MONTHS";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(24, 166);
      this.label8.Name = "label8";
      this.label8.Size = new Size(118, 16);
      this.label8.TabIndex = 62;
      this.label8.Text = "NOTICE CHARGE";
      this.tbxInterestLess.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestLess.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestLess.ForeColor = SystemColors.MenuHighlight;
      this.tbxInterestLess.Location = new Point(146, 137);
      this.tbxInterestLess.Name = "tbxInterestLess";
      this.tbxInterestLess.Size = new Size(136, 22);
      this.tbxInterestLess.TabIndex = 80;
      this.tbxInterestLess.Text = "0";
      this.tbxInterestLess.TextAlign = HorizontalAlignment.Right;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(66, 94);
      this.label7.Name = "label7";
      this.label7.Size = new Size(76, 16);
      this.label7.TabIndex = 61;
      this.label7.Text = "INTEREST";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(90, 267);
      this.label16.Name = "label16";
      this.label16.Size = new Size(52, 16);
      this.label16.TabIndex = 66;
      this.label16.Text = "TOTAL";
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "LOAN DETAILS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxOldBillNumber);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxPureWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxValue);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxInteresRate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxNetWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxTotalInterest);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxReminder);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxweight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxDeductions);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox13);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox12);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox11);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox10);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox9);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox8);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox7);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox5);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(449, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size((int) byte.MaxValue, 280);
      ((Control) this.headerPanel2).TabIndex = 68;
      this.headerPanel2.TextAntialias = true;
      this.tbxOldBillNumber.Anchor = AnchorStyles.Top;
      this.tbxOldBillNumber.BackColor = Color.White;
      this.tbxOldBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOldBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxOldBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOldBillNumber.ForeColor = Color.DarkBlue;
      this.tbxOldBillNumber.Location = new Point(101, 30);
      this.tbxOldBillNumber.MaxLength = 6;
      this.tbxOldBillNumber.Name = "tbxOldBillNumber";
      this.tbxOldBillNumber.ReadOnly = true;
      this.tbxOldBillNumber.Size = new Size(144, 22);
      this.tbxOldBillNumber.TabIndex = 1;
      this.tbxOldBillNumber.TextAlign = HorizontalAlignment.Right;
      this.tbxPureWeight.Anchor = AnchorStyles.Top;
      this.tbxPureWeight.BackColor = Color.White;
      this.tbxPureWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPureWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxPureWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPureWeight.ForeColor = Color.DarkBlue;
      this.tbxPureWeight.Location = new Point(101, 140);
      this.tbxPureWeight.MaxLength = 7;
      this.tbxPureWeight.Name = "tbxPureWeight";
      this.tbxPureWeight.ReadOnly = true;
      this.tbxPureWeight.Size = new Size(144, 22);
      this.tbxPureWeight.TabIndex = 69;
      this.tbxPureWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxValue.Anchor = AnchorStyles.Top;
      this.tbxValue.BackColor = Color.White;
      this.tbxValue.BorderStyle = BorderStyle.FixedSingle;
      this.tbxValue.CharacterCasing = CharacterCasing.Upper;
      this.tbxValue.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxValue.ForeColor = Color.DarkBlue;
      this.tbxValue.Location = new Point(101, 162);
      this.tbxValue.MaxLength = 10;
      this.tbxValue.Name = "tbxValue";
      this.tbxValue.ReadOnly = true;
      this.tbxValue.Size = new Size(144, 22);
      this.tbxValue.TabIndex = 6;
      this.tbxValue.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount.Anchor = AnchorStyles.Top;
      this.tbxAmount.BackColor = Color.White;
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.CharacterCasing = CharacterCasing.Upper;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = Color.DarkBlue;
      this.tbxAmount.Location = new Point(101, 184);
      this.tbxAmount.MaxLength = 10;
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(144, 22);
      this.tbxAmount.TabIndex = 7;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxInteresRate.Anchor = AnchorStyles.Top;
      this.tbxInteresRate.BackColor = Color.White;
      this.tbxInteresRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInteresRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInteresRate.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInteresRate.ForeColor = Color.DarkBlue;
      this.tbxInteresRate.Location = new Point(101, 206);
      this.tbxInteresRate.MaxLength = 4;
      this.tbxInteresRate.Name = "tbxInteresRate";
      this.tbxInteresRate.ReadOnly = true;
      this.tbxInteresRate.Size = new Size(144, 22);
      this.tbxInteresRate.TabIndex = 8;
      this.tbxInteresRate.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.Anchor = AnchorStyles.Top;
      this.tbxNetWeight.BackColor = Color.White;
      this.tbxNetWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNetWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxNetWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.ForeColor = Color.DarkBlue;
      this.tbxNetWeight.Location = new Point(101, 118);
      this.tbxNetWeight.MaxLength = 7;
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.ReadOnly = true;
      this.tbxNetWeight.Size = new Size(144, 22);
      this.tbxNetWeight.TabIndex = 5;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxTotalInterest.Anchor = AnchorStyles.Top;
      this.tbxTotalInterest.BackColor = Color.White;
      this.tbxTotalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotalInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxTotalInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalInterest.ForeColor = Color.DarkBlue;
      this.tbxTotalInterest.Location = new Point(101, 228);
      this.tbxTotalInterest.MaxLength = 4;
      this.tbxTotalInterest.Name = "tbxTotalInterest";
      this.tbxTotalInterest.Size = new Size(144, 22);
      this.tbxTotalInterest.TabIndex = 55;
      this.tbxTotalInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxReminder.Anchor = AnchorStyles.Top;
      this.tbxReminder.BackColor = Color.White;
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.CharacterCasing = CharacterCasing.Upper;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.ForeColor = Color.DarkBlue;
      this.tbxReminder.Location = new Point(101, 52);
      this.tbxReminder.MaxLength = 50;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.ReadOnly = true;
      this.tbxReminder.Size = new Size(144, 22);
      this.tbxReminder.TabIndex = 2;
      this.tbxweight.Anchor = AnchorStyles.Top;
      this.tbxweight.BackColor = Color.White;
      this.tbxweight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxweight.CharacterCasing = CharacterCasing.Upper;
      this.tbxweight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxweight.ForeColor = Color.DarkBlue;
      this.tbxweight.Location = new Point(101, 74);
      this.tbxweight.MaxLength = 7;
      this.tbxweight.Name = "tbxweight";
      this.tbxweight.ReadOnly = true;
      this.tbxweight.Size = new Size(144, 22);
      this.tbxweight.TabIndex = 3;
      this.tbxweight.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.Anchor = AnchorStyles.Top;
      this.tbxDeductions.BackColor = Color.White;
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.CharacterCasing = CharacterCasing.Upper;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.ForeColor = Color.DarkBlue;
      this.tbxDeductions.Location = new Point(101, 96);
      this.tbxDeductions.MaxLength = 5;
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.ReadOnly = true;
      this.tbxDeductions.Size = new Size(144, 22);
      this.tbxDeductions.TabIndex = 4;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.cbType.Anchor = AnchorStyles.Top;
      this.cbType.BackColor = Color.White;
      this.cbType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbType.ForeColor = Color.DarkBlue;
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[3]
      {
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(101, 6);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(144, 24);
      this.cbType.TabIndex = 0;
      this.textBox13.Anchor = AnchorStyles.Top;
      this.textBox13.BackColor = Color.AliceBlue;
      this.textBox13.BorderStyle = BorderStyle.None;
      this.textBox13.CharacterCasing = CharacterCasing.Upper;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox13.ForeColor = Color.DarkBlue;
      this.textBox13.Location = new Point(-26, 144);
      this.textBox13.MaxLength = 4;
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new Size(114, 15);
      this.textBox13.TabIndex = 70;
      this.textBox13.Text = "PURE WT";
      this.textBox13.TextAlign = HorizontalAlignment.Right;
      this.textBox12.Anchor = AnchorStyles.Top;
      this.textBox12.BackColor = Color.AliceBlue;
      this.textBox12.BorderStyle = BorderStyle.None;
      this.textBox12.CharacterCasing = CharacterCasing.Upper;
      this.textBox12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox12.ForeColor = Color.DarkBlue;
      this.textBox12.Location = new Point(-17, 10);
      this.textBox12.MaxLength = 4;
      this.textBox12.Name = "textBox12";
      this.textBox12.Size = new Size(114, 15);
      this.textBox12.TabIndex = 67;
      this.textBox12.Text = "TYPE   ";
      this.textBox12.TextAlign = HorizontalAlignment.Right;
      this.textBox11.Anchor = AnchorStyles.Top;
      this.textBox11.BackColor = Color.AliceBlue;
      this.textBox11.BorderStyle = BorderStyle.None;
      this.textBox11.CharacterCasing = CharacterCasing.Upper;
      this.textBox11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox11.ForeColor = Color.DarkBlue;
      this.textBox11.Location = new Point(-17, 34);
      this.textBox11.MaxLength = 4;
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new Size(114, 15);
      this.textBox11.TabIndex = 66;
      this.textBox11.Text = "OLD NO   ";
      this.textBox11.TextAlign = HorizontalAlignment.Right;
      this.textBox10.Anchor = AnchorStyles.Top;
      this.textBox10.BackColor = Color.AliceBlue;
      this.textBox10.BorderStyle = BorderStyle.None;
      this.textBox10.CharacterCasing = CharacterCasing.Upper;
      this.textBox10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox10.ForeColor = Color.DarkBlue;
      this.textBox10.Location = new Point(-17, 57);
      this.textBox10.MaxLength = 4;
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new Size(114, 15);
      this.textBox10.TabIndex = 65;
      this.textBox10.Text = "REMINDER   ";
      this.textBox10.TextAlign = HorizontalAlignment.Right;
      this.textBox9.Anchor = AnchorStyles.Top;
      this.textBox9.BackColor = Color.AliceBlue;
      this.textBox9.BorderStyle = BorderStyle.None;
      this.textBox9.CharacterCasing = CharacterCasing.Upper;
      this.textBox9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox9.ForeColor = Color.DarkBlue;
      this.textBox9.Location = new Point(-17, 78);
      this.textBox9.MaxLength = 4;
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new Size(114, 15);
      this.textBox9.TabIndex = 64;
      this.textBox9.Text = "GROSS WT   ";
      this.textBox9.TextAlign = HorizontalAlignment.Right;
      this.textBox8.Anchor = AnchorStyles.Top;
      this.textBox8.BackColor = Color.AliceBlue;
      this.textBox8.BorderStyle = BorderStyle.None;
      this.textBox8.CharacterCasing = CharacterCasing.Upper;
      this.textBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox8.ForeColor = Color.DarkBlue;
      this.textBox8.Location = new Point(-17, 99);
      this.textBox8.MaxLength = 4;
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(114, 15);
      this.textBox8.TabIndex = 63;
      this.textBox8.Text = "DEDUCTION   ";
      this.textBox8.TextAlign = HorizontalAlignment.Right;
      this.textBox7.Anchor = AnchorStyles.Top;
      this.textBox7.BackColor = Color.AliceBlue;
      this.textBox7.BorderStyle = BorderStyle.None;
      this.textBox7.CharacterCasing = CharacterCasing.Upper;
      this.textBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox7.ForeColor = Color.DarkBlue;
      this.textBox7.Location = new Point(-17, 121);
      this.textBox7.MaxLength = 4;
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(114, 15);
      this.textBox7.TabIndex = 62;
      this.textBox7.Text = "NET WT   ";
      this.textBox7.TextAlign = HorizontalAlignment.Right;
      this.textBox1.Anchor = AnchorStyles.Top;
      this.textBox1.BackColor = Color.AliceBlue;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.CharacterCasing = CharacterCasing.Upper;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.DarkBlue;
      this.textBox1.Location = new Point(-17, 166);
      this.textBox1.MaxLength = 4;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(114, 15);
      this.textBox1.TabIndex = 56;
      this.textBox1.Text = "VALUE   ";
      this.textBox1.TextAlign = HorizontalAlignment.Right;
      this.textBox2.Anchor = AnchorStyles.Top;
      this.textBox2.BackColor = Color.AliceBlue;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.CharacterCasing = CharacterCasing.Upper;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox2.ForeColor = Color.DarkBlue;
      this.textBox2.Location = new Point(-17, 187);
      this.textBox2.MaxLength = 4;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(114, 15);
      this.textBox2.TabIndex = 57;
      this.textBox2.Text = "AMOUNT   ";
      this.textBox2.TextAlign = HorizontalAlignment.Right;
      this.textBox3.Anchor = AnchorStyles.Top;
      this.textBox3.BackColor = Color.AliceBlue;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.CharacterCasing = CharacterCasing.Upper;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.ForeColor = Color.DarkBlue;
      this.textBox3.Location = new Point(-18, 209);
      this.textBox3.MaxLength = 4;
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(114, 15);
      this.textBox3.TabIndex = 58;
      this.textBox3.Text = "ROI    ";
      this.textBox3.TextAlign = HorizontalAlignment.Right;
      this.textBox5.Anchor = AnchorStyles.Top;
      this.textBox5.BackColor = Color.AliceBlue;
      this.textBox5.BorderStyle = BorderStyle.None;
      this.textBox5.CharacterCasing = CharacterCasing.Upper;
      this.textBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox5.ForeColor = Color.DarkBlue;
      this.textBox5.Location = new Point(-17, 232);
      this.textBox5.MaxLength = 4;
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(114, 15);
      this.textBox5.TabIndex = 60;
      this.textBox5.Text = "INTEREST   ";
      this.textBox5.TextAlign = HorizontalAlignment.Right;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel6.CaptionText = "BILL DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxBillDate);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(322, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(121, 47);
      ((Control) this.headerPanel6).TabIndex = 80;
      this.headerPanel6.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-190, 521);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
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
      ((Control) this.glassButton4).Location = new Point(-56, 520);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxBillDate.BackColor = Color.AliceBlue;
      this.tbxBillDate.BorderStyle = BorderStyle.None;
      this.tbxBillDate.Dock = DockStyle.Fill;
      this.tbxBillDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillDate.Location = new Point(0, 0);
      this.tbxBillDate.MaxLength = 10;
      this.tbxBillDate.Name = "tbxBillDate";
      this.tbxBillDate.Size = new Size(119, 22);
      this.tbxBillDate.TabIndex = 1;
      this.tbxBillDate.TextAlign = HorizontalAlignment.Center;
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
      this.headerPanel5.CaptionText = "BILL NUMBER";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(7, 4);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(98, 47);
      ((Control) this.headerPanel5).TabIndex = 79;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(-211, 521);
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
      ((Control) this.glassButton2).Location = new Point(-77, 520);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber.BackColor = Color.AliceBlue;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Dock = DockStyle.Fill;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 0);
      this.tbxBillNumber.MaxLength = 6;
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(96, 22);
      this.tbxBillNumber.TabIndex = 79;
      this.tbxBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber.TextChanged += new EventHandler(this.tbxBillNumber_TextChanged);
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
      this.headerPanel7.CaptionText = "LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(109, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(208, 47);
      ((Control) this.headerPanel7).TabIndex = 78;
      this.headerPanel7.TextAntialias = true;
      this.tbxShopCode.BackColor = Color.AliceBlue;
      this.tbxShopCode.BorderStyle = BorderStyle.None;
      this.tbxShopCode.Dock = DockStyle.Fill;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(0, 0);
      this.tbxShopCode.MaxLength = 10;
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(206, 22);
      this.tbxShopCode.TabIndex = 2;
      this.tbxShopCode.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton8).Location = new Point(-99, 521);
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
      ((Control) this.glassButton9).Location = new Point(35, 520);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.AliceBlue;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.Azure;
      this.headerPanel3.CaptionEndColor = Color.SkyBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.BackwardDiagonal;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "DETAILED DESCRIPTION OF THE ARTICLES";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.btnPaymentReceivedDetails);
      ((Control) this.headerPanel3).Controls.Add((Control) this.dgvArticles);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(7, 285);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(697, 186);
      ((Control) this.headerPanel3).TabIndex = 58;
      this.headerPanel3.TextAntialias = true;
      this.btnPaymentReceivedDetails.BackColor = Color.LightBlue;
      this.btnPaymentReceivedDetails.FadeOnFocus = true;
      this.btnPaymentReceivedDetails.ForeColor = Color.MediumBlue;
      this.btnPaymentReceivedDetails.ForeColorOnFocus = Color.Red;
      this.btnPaymentReceivedDetails.ForeColorOnLeave = Color.MediumBlue;
      this.btnPaymentReceivedDetails.GlowColor = Color.White;
      this.btnPaymentReceivedDetails.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPaymentReceivedDetails).Location = new Point(536, 129);
      ((Control) this.btnPaymentReceivedDetails).Name = "btnPaymentReceivedDetails";
      this.btnPaymentReceivedDetails.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPaymentReceivedDetails.ShineColor = Color.Transparent;
      ((Control) this.btnPaymentReceivedDetails).Size = new Size(155, 28);
      ((Control) this.btnPaymentReceivedDetails).TabIndex = 90;
      ((Control) this.btnPaymentReceivedDetails).Text = "PaymentReceivedDetails";
      ((Control) this.btnPaymentReceivedDetails).Click += new EventHandler(this.btnPaymentReceivedDetails_Click);
      ((DataGridView) this.dgvArticles).AllowUserToAddRows = false;
      ((DataGridView) this.dgvArticles).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      ((DataGridView) this.dgvArticles).BackgroundColor = SystemColors.ButtonHighlight;
      ((DataGridView) this.dgvArticles).BorderStyle = BorderStyle.None;
      ((DataGridView) this.dgvArticles).CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.SkyBlue;
      gridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.DarkBlue;
      gridViewCellStyle1.Padding = new Padding(5);
      ((DataGridView) this.dgvArticles).ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      ((DataGridView) this.dgvArticles).ColumnHeadersHeight = 30;
      ((Control) this.dgvArticles).Dock = DockStyle.Fill;
      ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;
      ((DataGridView) this.dgvArticles).EnableHeadersVisualStyles = false;
      ((DataGridView) this.dgvArticles).GridColor = Color.LightBlue;
      ((Control) this.dgvArticles).Location = new Point(0, 0);
      ((Control) this.dgvArticles).Name = "dgvArticles";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Info;
      gridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.WindowText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      ((DataGridView) this.dgvArticles).RowHeadersDefaultCellStyle = gridViewCellStyle2;
      ((DataGridView) this.dgvArticles).RowHeadersVisible = false;
      ((Control) this.dgvArticles).Size = new Size(695, 162);
      ((Control) this.dgvArticles).TabIndex = 0;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel1.CaptionEndColor = Color.Azure;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "CUSTOMER DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxBankDetails);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label5);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.richTextBox1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAverageNumberOfDaysForRelease);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNotes);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNumberOfTimesReleaseExceedTwelveMonths);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerName);
      ((Control) this.headerPanel1).Controls.Add((Control) this.pictureBox2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPhoneNumber);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCell);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(8, 54);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(435, 230);
      ((Control) this.headerPanel1).TabIndex = 30;
      this.headerPanel1.TextAntialias = true;
      this.tbxBankDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxBankDetails.BackColor = Color.AliceBlue;
      this.tbxBankDetails.BorderStyle = BorderStyle.None;
      this.tbxBankDetails.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankDetails.ForeColor = Color.Maroon;
      this.tbxBankDetails.Location = new Point(166, 188);
      this.tbxBankDetails.Name = "tbxBankDetails";
      this.tbxBankDetails.Size = new Size(264, 15);
      this.tbxBankDetails.TabIndex = 36;
      this.tbxBankDetails.Visible = false;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Location = new Point(169, 150);
      this.label5.Name = "label5";
      this.label5.Size = new Size(66, 15);
      this.label5.TabIndex = 35;
      this.label5.Text = "REMINDER";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Location = new Point(169, 117);
      this.label4.Name = "label4";
      this.label4.Size = new Size(98, 15);
      this.label4.TabIndex = 34;
      this.label4.Text = "PHONE NUMBER";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Location = new Point(169, 41);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 15);
      this.label3.TabIndex = 33;
      this.label3.Text = "ADDRESS";
      this.richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.richTextBox1.BackColor = Color.AliceBlue;
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox1.Location = new Point(169, 58);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(261, 59);
      this.richTextBox1.TabIndex = 32;
      this.richTextBox1.Text = "";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Location = new Point(169, 7);
      this.label2.Name = "label2";
      this.label2.Size = new Size(106, 15);
      this.label2.TabIndex = 31;
      this.label2.Text = "CUSTOMER NAME";
      this.tbxAverageNumberOfDaysForRelease.BackColor = Color.AliceBlue;
      this.tbxAverageNumberOfDaysForRelease.BorderStyle = BorderStyle.None;
      this.tbxAverageNumberOfDaysForRelease.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAverageNumberOfDaysForRelease.Location = new Point(535, 8);
      this.tbxAverageNumberOfDaysForRelease.Name = "tbxAverageNumberOfDaysForRelease";
      this.tbxAverageNumberOfDaysForRelease.ReadOnly = true;
      this.tbxAverageNumberOfDaysForRelease.Size = new Size(57, 15);
      this.tbxAverageNumberOfDaysForRelease.TabIndex = 10;
      this.tbxAverageNumberOfDaysForRelease.TextAlign = HorizontalAlignment.Center;
      this.tbxNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxNotes.BackColor = Color.AliceBlue;
      this.tbxNotes.BorderStyle = BorderStyle.None;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(169, 167);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(264, 15);
      this.tbxNotes.TabIndex = 28;
      this.tbxNotes.Visible = false;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BackColor = Color.AliceBlue;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BorderStyle = BorderStyle.None;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Location = new Point(598, 8);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Name = "tbxNumberOfTimesReleaseExceedTwelveMonths";
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.ReadOnly = true;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Size = new Size(57, 15);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TabIndex = 9;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TextAlign = HorizontalAlignment.Center;
      this.tbxCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerName.BackColor = Color.AliceBlue;
      this.tbxCustomerName.BorderStyle = BorderStyle.None;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(169, 24);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(261, 15);
      this.tbxCustomerName.TabIndex = 0;
      this.pictureBox2.Location = new Point(6, 6);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(155, 181);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.tbxCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerCode.BackColor = Color.AliceBlue;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(17, 186);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(126, 15);
      this.tbxCustomerCode.TabIndex = 8;
      this.tbxPhoneNumber.BackColor = Color.AliceBlue;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.None;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.ForeColor = Color.MidnightBlue;
      this.tbxPhoneNumber.Location = new Point(172, 133);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(106, 15);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxCell.BackColor = Color.AliceBlue;
      this.tbxCell.BorderStyle = BorderStyle.None;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.ForeColor = Color.MidnightBlue;
      this.tbxCell.Location = new Point(282, 185);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(113, 15);
      this.tbxCell.TabIndex = 22;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 480);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormViewPledgeBillNew);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormViewPledgeBillNew);
      this.Load += new EventHandler(this.FormViewPledgeBillNew_Load);
      this.Leave += new EventHandler(this.FormViewPledgeBillNew_Leave);
      this.MouseLeave += new EventHandler(this.FormViewPledgeBillNew_MouseLeave);
      this.panel1.ResumeLayout(false);
      ((Control) this.hpREdemptionDetails).ResumeLayout(false);
      ((Control) this.hpREdemptionDetails).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((ISupportInitialize) this.dgvArticles).EndInit();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
    }
  }
}
