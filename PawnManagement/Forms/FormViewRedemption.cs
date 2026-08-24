

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

namespace PawnManagement.Forms
{
  public class FormViewRedemption : Form
  {
    private List<string> lstBillNumbers = new List<string>();
    private IContainer components = (IContainer) null;
    private Panel panel3;
    private Panel panel1;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private TextBox tbxPledgeBillNumber;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxRedemptionBillNumber;
    private HeaderPanel hpRedemptionDate;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxRedemptionDate;
    private HeaderPanel hpAuctionDate;
    private TextBox tbxAuctionDate;
    private GlassButton glassButton5;
    private GlassButton glassButton8;
    private Panel panel5;
    private GlassButton glassButton2;
    private Label lblMessage;
    private Label label18;
    private GlassButton glassButton1;
    private Label label17;
    private Label label10;
    private Label label19;
    private TextBox tbxReceive;
    private Label label15;
    private Label label14;
    private Label label9;
    private Label label8;
    private Label label6;
    private Label label16;
    private TextBox tbxInterestLess;
    private Label label4;
    private TextBox tbxTotal;
    private Label label7;
    private Label lblValue;
    private Label label5;
    private TextBox tbxPaymentReceived;
    private TextBox tbxAmount;
    private TextBox tbxFinalInterest;
    private TextBox tbxInterestRate;
    private TextBox tbxOtherCharge;
    private TextBox tbxDeductions;
    private TextBox tbxNoticeCharge;
    private TextBox tbxInterest;
    private TextBox tbxNoOfMonths;
    private TextBox tbxPledgeDate;
    private TextBox tbxValue;
    private Panel panel6;
    private HeaderPanel headerPanel5;
    private TextBox tbxPureWeight;
    private GlassButton glassButton15;
    private GlassButton glassButton16;
    private HeaderPanel headerPanel1;
    private TextBox tbxDeduction;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private HeaderPanel headerPanel6;
    private TextBox tbxNetWeight;
    private GlassButton glassButton17;
    private GlassButton glassButton18;
    private HeaderPanel headerPanel2;
    private TextBox tbxGrossWeight;
    private GlassButton btnSave;
    private GlassButton btnExit;
    private TextBox tbxInterest16;
    private TextBox tbxRedemptionAmount16;
    private Label lblReminder;
    private DataGridView dgvArticles;
    private Panel panel4;
    private PictureBox pictureBox2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deletePHotoToolStripMenuItem;
    private Label label20;
    private TextBox tbxCustomerName;
    private PictureBox pictureBox1;
    private Label lblBankBillNumber;
    private TextBox tbxCustomerCode;
    private TextBox tbxAddress2;
    private TextBox tbxAddress1;
    private Label lblHeading;
    private Panel panel2;
    private TableLayoutPanel tableLayoutPanel1;
    private Timer timer2;
    private Timer timer1;
    private LinkLabel linkLabel2;
    private LinkLabel linkLabel1;
    private HeaderPanel headerPanel8;
    private TextBox tbxShopCode;
    private GlassButton glassButton20;
    private GlassButton glassButton21;
    private TextBox tbxReleasedBy;

    public FormViewRedemption() => this.InitializeComponent();

    private string getNextBillNumber(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "Select * from tblRedemption where BillNumber > @BillNumber AND ShopCode = @ShopCode order by billnumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) this.tbxRedemptionBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) this.cbShopCodes.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeeidt.getdgvarticles()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0][nameof (BillNumber)].ToString();
      return "";
    }

    private string getPreviousBillNumber(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "Select * from tblRedemption where BillNumber < @BillNumber AND ShopCode = @ShopCode order by billnumber desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber.ToString()));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeeidt.getdgvarticles()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0][nameof (BillNumber)].ToString();
      return "";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Escape:
          this.Close();
          break;
        case Keys.Left:
          string previousBillNumber = this.getPreviousBillNumber(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text);
          if (this.checkifBillNumberExists(previousBillNumber))
            this.tbxRedemptionBillNumber.Text = previousBillNumber;
          break;
        case Keys.Right:
          string nextBillNumber = this.getNextBillNumber(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text);
          if (this.checkifBillNumberExists(nextBillNumber))
          {
            this.tbxRedemptionBillNumber.Text = nextBillNumber;
            break;
          }
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private bool checkifBillNumberExists(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber=@BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeedit.tbxbillnumber_leave", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
        this.tbxRedemptionBillNumber.Select();
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void FormViewRedemption_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
    }

    private void getReleasedBy()
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxRedemptionBillNumber.Text));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.redemptionBillNumberLeave_when redemtionEdit", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxReleasedBy.Text = dataTable2.Rows[0]["ReleasedBy"].ToString();
        if (File.Exists(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
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
      else
      {
        this.tbxReleasedBy.Text = "";
        if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void getBillNumbers()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblRedemption where ShopCode = @ShopCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form Redemption .getBillNumbers()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          int index = 0;
          this.lstBillNumbers.Clear();
          for (; index < dataTable2.Rows.Count; ++index)
            this.lstBillNumbers.Add(dataTable2.Rows[index].Field<string>("BillNumber"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxRedemptionBillNumber_TextChanged(object sender, EventArgs e)
    {
      if (!this.checkifBillNumberExists(this.tbxRedemptionBillNumber.Text))
        return;
      this.getPledgeBill();
    }

    private string getPledgeBillNumber(string RedemptionBillNumber)
    {
      string strError = "";
      string my_querry = "select *,temp1 as rateofinterest,temp2 as interest,temp3 as finalinterest,temp4 as totalredemptionamount from tblredemption   where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) RedemptionBillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getPldegeBillNumber ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0].Field<string>("PledgeBillNumber").ToString();
      return "";
    }

    private void getPledgeBill()
    {
      string pledgeBillNumber = this.getPledgeBillNumber(this.tbxRedemptionBillNumber.Text.Trim().ToString());
      if (pledgeBillNumber != "")
      {
        string strError = "";
        string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) pledgeBillNumber));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Redemption.redemptionBillNumberLeave_when redemtionEdit", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          if (dataTable2.Rows[0].Field<string>("Redeemed") == "Y")
          {
            this.tbxShopCode.Text = dataTable2.Rows[0]["ShopCode"].ToString();
            this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CustomerCode");
            this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CustomerName");
            this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("Addr1");
            this.tbxAddress2.Text = dataTable2.Rows[0].Field<string>("Addr2");
            this.tbxGrossWeight.Text = dataTable2.Rows[0].Field<string>("GrossWeight").ToString();
            this.tbxDeduction.Text = dataTable2.Rows[0].Field<string>("Deduction").ToString();
            this.tbxNetWeight.Text = dataTable2.Rows[0].Field<string>("NetWeight").ToString();
            this.tbxValue.Text = dataTable2.Rows[0].Field<int>("PresentValue").ToString();
            this.tbxAmount.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
            this.tbxPledgeDate.Text = dataTable2.Rows[0].Field<DateTime>("BillDate").ToString("dd/MM/yyyy");
            this.tbxPledgeDate.Enabled = false;
            this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
            this.tbxPledgeBillNumber.Text = pledgeBillNumber;
            this.tbxPledgeBillNumber.Enabled = false;
            this.tbxRedemptionDate.Text = dataTable2.Rows[0].Field<DateTime>("RedemptionDate").ToString("dd/MM/yyyy");
            this.tbxInterest.Text = dataTable2.Rows[0]["Interest"].ToString();
            this.tbxInterestLess.Text = dataTable2.Rows[0].Field<int>("InterestLess").ToString();
            this.tbxNoticeCharge.Text = dataTable2.Rows[0].Field<int>("NoticeCharge").ToString();
            this.tbxOtherCharge.Text = dataTable2.Rows[0].Field<int>("OtherCharges").ToString();
            this.tbxDeductions.Text = dataTable2.Rows[0].Field<int>("Discount").ToString();
            this.tbxFinalInterest.Text = dataTable2.Rows[0]["FinalInterest"].ToString();
            this.tbxTotal.Text = dataTable2.Rows[0]["RedemptionAmount"].ToString();
            this.tbxNoOfMonths.Text = dataTable2.Rows[0].Field<int>("NoOfMonths").ToString();
            this.getArticles();
            this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
            int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
            if (FormPrintSettings.boolReduceFirstMonthInterest())
              --numberOfMonths;
            this.tbxNoOfMonths.Text = numberOfMonths.ToString();
            TextBox tbxInterest = this.tbxInterest;
            int num = int.Parse(this.tbxAmount.Text.Trim().ToString()) * numberOfMonths * int.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200;
            string str1 = num.ToString();
            tbxInterest.Text = str1;
            TextBox tbxInterest16 = this.tbxInterest16;
            num = int.Parse(this.tbxAmount.Text.Trim().ToString()) * (numberOfMonths + 1) * 16 / 1200;
            string str2 = num.ToString();
            tbxInterest16.Text = str2;
            this.lblMessage.Text = "";
            this.getReleasedBy();
          }
          else if (dataTable2.Rows[0].Field<string>("Redeemed") == "N")
          {
            int num = (int) MessageBox.Show("Bill not released");
            this.tbxRedemptionBillNumber.Select();
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Bill not released");
          this.tbxRedemptionBillNumber.Select();
        }
      }
      else
        this.tbxRedemptionBillNumber.Select();
    }

    private void getArticles()
    {
      if (FormMain.withIndividualWeight)
      {
        string strError = "";
        string my_querry = "Select Articles,ArticlesDescription,Hr as [Hidden Remarks],Purity,GrossWeight,Deduction,NetWeight,PureWeight,Num from tblPledgeArticles where BillNumber = @BillNumber  and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Redemption.getArticles", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
        }
        else
          this.dgvArticles.DataSource = (object) dataTable2;
      }
      else
      {
        string strError = "";
        string my_querry = "Select Articles,ArticlesDescription,Num from tblPledgeArticles where BillNumber = @BillNumber  and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Redemption.getArticles", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
        }
        else
          this.dgvArticles.DataSource = (object) dataTable4;
      }
    }

    private void getPicture(string customerCode)
    {
      if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
      else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
      try
      {
        if (!File.Exists(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (PawnManagementClass.getLatestRedemptionRecord(this.cbShopCodes.Text) == null || PawnManagementClass.getLatestRedemptionRecord(this.cbShopCodes.Text).Rows.Count <= 0)
        return;
      this.tbxRedemptionBillNumber.Text = PawnManagementClass.getLatestRedemptionRecord(this.cbShopCodes.Text).Rows[0]["BillNumber"].ToString();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string previousBillNumber = this.getPreviousBillNumber(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text);
      if (!this.checkifBillNumberExists(previousBillNumber))
        return;
      this.tbxRedemptionBillNumber.Text = previousBillNumber;
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string nextBillNumber = this.getNextBillNumber(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text);
      if (!this.checkifBillNumberExists(nextBillNumber))
        return;
      this.tbxRedemptionBillNumber.Text = nextBillNumber;
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
      this.panel3 = new Panel();
      this.panel1 = new Panel();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.tbxPledgeBillNumber = new TextBox();
      this.headerPanel8 = new HeaderPanel();
      this.tbxShopCode = new TextBox();
      this.glassButton20 = new GlassButton();
      this.glassButton21 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxRedemptionBillNumber = new TextBox();
      this.hpRedemptionDate = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxRedemptionDate = new TextBox();
      this.hpAuctionDate = new HeaderPanel();
      this.tbxAuctionDate = new TextBox();
      this.glassButton5 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.panel5 = new Panel();
      this.glassButton2 = new GlassButton();
      this.lblMessage = new Label();
      this.label18 = new Label();
      this.glassButton1 = new GlassButton();
      this.label17 = new Label();
      this.label10 = new Label();
      this.label19 = new Label();
      this.tbxReceive = new TextBox();
      this.label15 = new Label();
      this.label14 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label6 = new Label();
      this.label16 = new Label();
      this.tbxInterestLess = new TextBox();
      this.label4 = new Label();
      this.tbxTotal = new TextBox();
      this.label7 = new Label();
      this.lblValue = new Label();
      this.label5 = new Label();
      this.tbxPaymentReceived = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxFinalInterest = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.tbxOtherCharge = new TextBox();
      this.tbxDeductions = new TextBox();
      this.tbxNoticeCharge = new TextBox();
      this.tbxInterest = new TextBox();
      this.tbxNoOfMonths = new TextBox();
      this.tbxPledgeDate = new TextBox();
      this.tbxValue = new TextBox();
      this.panel6 = new Panel();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.linkLabel2 = new LinkLabel();
      this.linkLabel1 = new LinkLabel();
      this.headerPanel5 = new HeaderPanel();
      this.tbxPureWeight = new TextBox();
      this.glassButton15 = new GlassButton();
      this.glassButton16 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.tbxDeduction = new TextBox();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.tbxNetWeight = new TextBox();
      this.glassButton17 = new GlassButton();
      this.glassButton18 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.tbxGrossWeight = new TextBox();
      this.btnSave = new GlassButton();
      this.btnExit = new GlassButton();
      this.tbxInterest16 = new TextBox();
      this.tbxRedemptionAmount16 = new TextBox();
      this.lblReminder = new Label();
      this.dgvArticles = new DataGridView();
      this.panel4 = new Panel();
      this.tbxReleasedBy = new TextBox();
      this.pictureBox2 = new PictureBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deletePHotoToolStripMenuItem = new ToolStripMenuItem();
      this.label20 = new Label();
      this.tbxCustomerName = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.lblBankBillNumber = new Label();
      this.tbxCustomerCode = new TextBox();
      this.tbxAddress2 = new TextBox();
      this.tbxAddress1 = new TextBox();
      this.lblHeading = new Label();
      this.panel2 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.timer2 = new Timer(this.components);
      this.timer1 = new Timer(this.components);
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.hpRedemptionDate).SuspendLayout();
      ((Control) this.hpAuctionDate).SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel6.SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      this.panel4.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.Controls.Add((Control) this.panel1);
      this.panel3.Controls.Add((Control) this.panel5);
      this.panel3.Controls.Add((Control) this.panel6);
      this.panel3.Controls.Add((Control) this.panel4);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 50);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1001, 567);
      this.panel3.TabIndex = 11;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.headerPanel3);
      this.panel1.Controls.Add((Control) this.headerPanel8);
      this.panel1.Controls.Add((Control) this.headerPanel4);
      this.panel1.Controls.Add((Control) this.hpRedemptionDate);
      this.panel1.Controls.Add((Control) this.hpAuctionDate);
      this.panel1.Location = new Point(5, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(992, 80);
      this.panel1.TabIndex = 86;
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
      this.headerPanel3.CaptionText = "PLEDGE BILL NUMBER";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxPledgeBillNumber);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(547, 5);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(176, 68);
      ((Control) this.headerPanel3).TabIndex = 79;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton9).Location = new Point(-131, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 1;
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
      ((Control) this.glassButton10).Location = new Point(3, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxPledgeBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPledgeBillNumber.BackColor = Color.AliceBlue;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.None;
      this.tbxPledgeBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxPledgeBillNumber.Dock = DockStyle.Fill;
      this.tbxPledgeBillNumber.Font = new Font("Arial Rounded MT Bold", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.ForeColor = Color.RoyalBlue;
      this.tbxPledgeBillNumber.Location = new Point(0, 0);
      this.tbxPledgeBillNumber.MaxLength = 6;
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.Size = new Size(174, 43);
      this.tbxPledgeBillNumber.TabIndex = 0;
      this.tbxPledgeBillNumber.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "LICENSE";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = Color.AliceBlue;
      this.headerPanel8.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel8).Location = new Point(729, 5);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(250, 70);
      ((Control) this.headerPanel8).TabIndex = 90;
      this.headerPanel8.TextAntialias = true;
      this.tbxShopCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxShopCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxShopCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxShopCode.BackColor = Color.AliceBlue;
      this.tbxShopCode.BorderStyle = BorderStyle.None;
      this.tbxShopCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxShopCode.Font = new Font("Arial Rounded MT Bold", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.ForeColor = Color.RoyalBlue;
      this.tbxShopCode.Location = new Point(7, 14);
      this.tbxShopCode.MaxLength = 6;
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(235, 19);
      this.tbxShopCode.TabIndex = 2;
      this.tbxShopCode.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton20).Location = new Point(-57, 513);
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
      ((Control) this.glassButton21).Location = new Point(77, 512);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(123, 37);
      ((Control) this.glassButton21).TabIndex = 1;
      ((Control) this.glassButton21).Text = "&EXIT";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel4.CaptionText = "REDEMPTION BILL NUMBER";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxRedemptionBillNumber);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(6, 5);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(247, 68);
      ((Control) this.headerPanel4).TabIndex = 76;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton6).Location = new Point(-54, 513);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(128, 35);
      ((Control) this.glassButton6).TabIndex = 1;
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
      ((Control) this.glassButton7).Location = new Point(80, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxRedemptionBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxRedemptionBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxRedemptionBillNumber.BackColor = Color.AliceBlue;
      this.tbxRedemptionBillNumber.BorderStyle = BorderStyle.None;
      this.tbxRedemptionBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxRedemptionBillNumber.Dock = DockStyle.Fill;
      this.tbxRedemptionBillNumber.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionBillNumber.ForeColor = Color.RoyalBlue;
      this.tbxRedemptionBillNumber.Location = new Point(0, 0);
      this.tbxRedemptionBillNumber.MaxLength = 6;
      this.tbxRedemptionBillNumber.Name = "tbxRedemptionBillNumber";
      this.tbxRedemptionBillNumber.ReadOnly = true;
      this.tbxRedemptionBillNumber.Size = new Size(245, 42);
      this.tbxRedemptionBillNumber.TabIndex = 45;
      this.tbxRedemptionBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionBillNumber.TextChanged += new EventHandler(this.tbxRedemptionBillNumber_TextChanged);
      ((Control) this.hpRedemptionDate).BackColor = Color.PowderBlue;
      ((Control) this.hpRedemptionDate).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpRedemptionDate).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpRedemptionDate.BorderColor = SystemColors.HotTrack;
      this.hpRedemptionDate.BorderStyle = BorderStyles.Single;
      this.hpRedemptionDate.CaptionBeginColor = Color.PowderBlue;
      this.hpRedemptionDate.CaptionEndColor = Color.AliceBlue;
      this.hpRedemptionDate.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpRedemptionDate.CaptionHeight = 22;
      this.hpRedemptionDate.CaptionPosition = CaptionPositions.Top;
      this.hpRedemptionDate.CaptionText = "REDEMPTION DATE";
      this.hpRedemptionDate.CaptionVisible = true;
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.glassButton3);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.glassButton4);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxRedemptionDate);
      ((Control) this.hpRedemptionDate).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpRedemptionDate).ForeColor = Color.DarkBlue;
      this.hpRedemptionDate.GradientDirection = LinearGradientMode.Vertical;
      this.hpRedemptionDate.GradientEnd = SystemColors.ControlLight;
      this.hpRedemptionDate.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpRedemptionDate).Location = new Point(262, 5);
      ((Control) this.hpRedemptionDate).Name = "hpRedemptionDate";
      this.hpRedemptionDate.PanelIcon = (Icon) null;
      this.hpRedemptionDate.PanelIconVisible = false;
      ((Control) this.hpRedemptionDate).Size = new Size(280, 68);
      ((Control) this.hpRedemptionDate).TabIndex = 77;
      this.hpRedemptionDate.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-23, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 1;
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
      ((Control) this.glassButton4).Location = new Point(111, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxRedemptionDate.BackColor = Color.AliceBlue;
      this.tbxRedemptionDate.BorderStyle = BorderStyle.None;
      this.tbxRedemptionDate.Dock = DockStyle.Fill;
      this.tbxRedemptionDate.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionDate.ForeColor = Color.RoyalBlue;
      this.tbxRedemptionDate.Location = new Point(0, 0);
      this.tbxRedemptionDate.MaxLength = 10;
      this.tbxRedemptionDate.Name = "tbxRedemptionDate";
      this.tbxRedemptionDate.Size = new Size(278, 42);
      this.tbxRedemptionDate.TabIndex = 1;
      this.tbxRedemptionDate.TextAlign = HorizontalAlignment.Center;
      ((Control) this.hpAuctionDate).BackColor = Color.PowderBlue;
      ((Control) this.hpAuctionDate).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpAuctionDate).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpAuctionDate.BorderColor = SystemColors.HotTrack;
      this.hpAuctionDate.BorderStyle = BorderStyles.Single;
      this.hpAuctionDate.CaptionBeginColor = Color.PowderBlue;
      this.hpAuctionDate.CaptionEndColor = Color.AliceBlue;
      this.hpAuctionDate.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpAuctionDate.CaptionHeight = 22;
      this.hpAuctionDate.CaptionPosition = CaptionPositions.Top;
      this.hpAuctionDate.CaptionText = "AUCTION DATE";
      this.hpAuctionDate.CaptionVisible = true;
      ((Control) this.hpAuctionDate).Controls.Add((Control) this.tbxAuctionDate);
      ((Control) this.hpAuctionDate).Controls.Add((Control) this.glassButton5);
      ((Control) this.hpAuctionDate).Controls.Add((Control) this.glassButton8);
      ((Control) this.hpAuctionDate).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpAuctionDate).ForeColor = Color.DarkBlue;
      this.hpAuctionDate.GradientDirection = LinearGradientMode.Vertical;
      this.hpAuctionDate.GradientEnd = SystemColors.ControlLight;
      this.hpAuctionDate.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpAuctionDate).Location = new Point(262, 5);
      ((Control) this.hpAuctionDate).Name = "hpAuctionDate";
      this.hpAuctionDate.PanelIcon = (Icon) null;
      this.hpAuctionDate.PanelIconVisible = false;
      ((Control) this.hpAuctionDate).Size = new Size(280, 68);
      ((Control) this.hpAuctionDate).TabIndex = 78;
      this.hpAuctionDate.TextAntialias = true;
      this.tbxAuctionDate.BackColor = Color.AliceBlue;
      this.tbxAuctionDate.BorderStyle = BorderStyle.None;
      this.tbxAuctionDate.Dock = DockStyle.Fill;
      this.tbxAuctionDate.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAuctionDate.ForeColor = Color.RoyalBlue;
      this.tbxAuctionDate.Location = new Point(0, 0);
      this.tbxAuctionDate.MaxLength = 10;
      this.tbxAuctionDate.Name = "tbxAuctionDate";
      this.tbxAuctionDate.Size = new Size(278, 42);
      this.tbxAuctionDate.TabIndex = 73;
      this.tbxAuctionDate.TextAlign = HorizontalAlignment.Right;
      this.tbxAuctionDate.Visible = false;
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
      ((Control) this.glassButton5).Location = new Point(-25, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(109, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.glassButton2);
      this.panel5.Controls.Add((Control) this.lblMessage);
      this.panel5.Controls.Add((Control) this.label18);
      this.panel5.Controls.Add((Control) this.glassButton1);
      this.panel5.Controls.Add((Control) this.label17);
      this.panel5.Controls.Add((Control) this.label10);
      this.panel5.Controls.Add((Control) this.label19);
      this.panel5.Controls.Add((Control) this.tbxReceive);
      this.panel5.Controls.Add((Control) this.label15);
      this.panel5.Controls.Add((Control) this.label14);
      this.panel5.Controls.Add((Control) this.label9);
      this.panel5.Controls.Add((Control) this.label8);
      this.panel5.Controls.Add((Control) this.label6);
      this.panel5.Controls.Add((Control) this.label16);
      this.panel5.Controls.Add((Control) this.tbxInterestLess);
      this.panel5.Controls.Add((Control) this.label4);
      this.panel5.Controls.Add((Control) this.tbxTotal);
      this.panel5.Controls.Add((Control) this.label7);
      this.panel5.Controls.Add((Control) this.lblValue);
      this.panel5.Controls.Add((Control) this.label5);
      this.panel5.Controls.Add((Control) this.tbxPaymentReceived);
      this.panel5.Controls.Add((Control) this.tbxAmount);
      this.panel5.Controls.Add((Control) this.tbxFinalInterest);
      this.panel5.Controls.Add((Control) this.tbxInterestRate);
      this.panel5.Controls.Add((Control) this.tbxOtherCharge);
      this.panel5.Controls.Add((Control) this.tbxDeductions);
      this.panel5.Controls.Add((Control) this.tbxNoticeCharge);
      this.panel5.Controls.Add((Control) this.tbxInterest);
      this.panel5.Controls.Add((Control) this.tbxNoOfMonths);
      this.panel5.Controls.Add((Control) this.tbxPledgeDate);
      this.panel5.Controls.Add((Control) this.tbxValue);
      this.panel5.Location = new Point(636, 83);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(361, 474);
      this.panel5.TabIndex = 88;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(184, 229);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(52, 22);
      ((Control) this.glassButton2).TabIndex = 82;
      ((Control) this.glassButton2).Text = "D&etails";
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.Tomato;
      this.lblMessage.Location = new Point(3, 5);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(0, 16);
      this.lblMessage.TabIndex = 70;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(24, 230);
      this.label18.Name = "label18";
      this.label18.Size = new Size(155, 24);
      this.label18.TabIndex = 81;
      this.label18.Text = "INTEREST LESS";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(183, 197);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(52, 23);
      ((Control) this.glassButton1).TabIndex = 79;
      ((Control) this.glassButton1).Text = "&Details";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(7, 198);
      this.label17.Name = "label17";
      this.label17.Size = new Size(172, 24);
      this.label17.TabIndex = 78;
      this.label17.Text = "PAYMENT RECVD";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(20, 108);
      this.label10.Name = "label10";
      this.label10.Size = new Size(159, 24);
      this.label10.TabIndex = 56;
      this.label10.Text = "INTEREST RATE";
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(87, 436);
      this.label19.Name = "label19";
      this.label19.Size = new Size(92, 24);
      this.label19.TabIndex = 84;
      this.label19.Text = "RECEIVE";
      this.tbxReceive.BackColor = Color.Moccasin;
      this.tbxReceive.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReceive.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReceive.ForeColor = Color.Firebrick;
      this.tbxReceive.Location = new Point(181, 430);
      this.tbxReceive.Name = "tbxReceive";
      this.tbxReceive.Size = new Size(167, 35);
      this.tbxReceive.TabIndex = 83;
      this.tbxReceive.TextAlign = HorizontalAlignment.Right;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(18, 357);
      this.label15.Name = "label15";
      this.label15.Size = new Size(161, 24);
      this.label15.TabIndex = 65;
      this.label15.Text = "FINAL INTEREST";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(59, 321);
      this.label14.Name = "label14";
      this.label14.Size = new Size(120, 24);
      this.label14.TabIndex = 64;
      this.label14.Text = "DEDUCTION";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(17, 291);
      this.label9.Name = "label9";
      this.label9.Size = new Size(162, 24);
      this.label9.TabIndex = 63;
      this.label9.Text = "OTHER CHARGE";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(13, 261);
      this.label8.Name = "label8";
      this.label8.Size = new Size(166, 24);
      this.label8.TabIndex = 62;
      this.label8.Text = "NOTICE CHARGE";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(76, 167);
      this.label6.Name = "label6";
      this.label6.Size = new Size(103, 24);
      this.label6.TabIndex = 61;
      this.label6.Text = "INTEREST";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(107, 392);
      this.label16.Name = "label16";
      this.label16.Size = new Size(72, 24);
      this.label16.TabIndex = 66;
      this.label16.Text = "TOTAL";
      this.tbxInterestLess.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestLess.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestLess.ForeColor = SystemColors.MenuHighlight;
      this.tbxInterestLess.Location = new Point(181, 225);
      this.tbxInterestLess.Name = "tbxInterestLess";
      this.tbxInterestLess.Size = new Size(167, 31);
      this.tbxInterestLess.TabIndex = 80;
      this.tbxInterestLess.Text = "0";
      this.tbxInterestLess.TextAlign = HorizontalAlignment.Right;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(20, 136);
      this.label4.Name = "label4";
      this.label4.Size = new Size(159, 24);
      this.label4.TabIndex = 60;
      this.label4.Text = "NO OF MONTHS";
      this.tbxTotal.BackColor = Color.Moccasin;
      this.tbxTotal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.ForeColor = Color.Firebrick;
      this.tbxTotal.Location = new Point(181, 390);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(167, 35);
      this.tbxTotal.TabIndex = 8;
      this.tbxTotal.TextAlign = HorizontalAlignment.Right;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(38, 13);
      this.label7.Name = "label7";
      this.label7.Size = new Size(141, 24);
      this.label7.TabIndex = 53;
      this.label7.Text = "PLEDGE DATE";
      this.lblValue.AutoSize = true;
      this.lblValue.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblValue.Location = new Point(107, 42);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new Size(72, 24);
      this.lblValue.TabIndex = 52;
      this.lblValue.Text = "VALUE";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(86, 74);
      this.label5.Name = "label5";
      this.label5.Size = new Size(93, 24);
      this.label5.TabIndex = 51;
      this.label5.Text = "AMOUNT";
      this.tbxPaymentReceived.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPaymentReceived.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPaymentReceived.ForeColor = SystemColors.MenuHighlight;
      this.tbxPaymentReceived.Location = new Point(181, 194);
      this.tbxPaymentReceived.Name = "tbxPaymentReceived";
      this.tbxPaymentReceived.Size = new Size(167, 31);
      this.tbxPaymentReceived.TabIndex = 77;
      this.tbxPaymentReceived.Text = "0";
      this.tbxPaymentReceived.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = SystemColors.MenuHighlight;
      this.tbxAmount.Location = new Point(181, 70);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(167, 31);
      this.tbxAmount.TabIndex = 10;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxFinalInterest.BackColor = Color.Moccasin;
      this.tbxFinalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFinalInterest.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFinalInterest.ForeColor = Color.Firebrick;
      this.tbxFinalInterest.Location = new Point(181, 354);
      this.tbxFinalInterest.Name = "tbxFinalInterest";
      this.tbxFinalInterest.ReadOnly = true;
      this.tbxFinalInterest.Size = new Size(167, 31);
      this.tbxFinalInterest.TabIndex = 7;
      this.tbxFinalInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestRate.BackColor = SystemColors.ButtonHighlight;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.ForeColor = Color.RoyalBlue;
      this.tbxInterestRate.Location = new Point(181, 101);
      this.tbxInterestRate.MaxLength = 2;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(167, 31);
      this.tbxInterestRate.TabIndex = 2;
      this.tbxInterestRate.TextAlign = HorizontalAlignment.Right;
      this.tbxOtherCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxOtherCharge.Location = new Point(181, 287);
      this.tbxOtherCharge.Name = "tbxOtherCharge";
      this.tbxOtherCharge.Size = new Size(167, 31);
      this.tbxOtherCharge.TabIndex = 5;
      this.tbxOtherCharge.Text = "0";
      this.tbxOtherCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.ForeColor = SystemColors.MenuHighlight;
      this.tbxDeductions.Location = new Point(181, 318);
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.Size = new Size(167, 31);
      this.tbxDeductions.TabIndex = 6;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.tbxNoticeCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoticeCharge.Location = new Point(181, 256);
      this.tbxNoticeCharge.Name = "tbxNoticeCharge";
      this.tbxNoticeCharge.Size = new Size(167, 31);
      this.tbxNoticeCharge.TabIndex = 4;
      this.tbxNoticeCharge.Text = "0";
      this.tbxNoticeCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.ForeColor = SystemColors.ControlText;
      this.tbxInterest.Location = new Point(181, 163);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(167, 31);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxNoOfMonths.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoOfMonths.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfMonths.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoOfMonths.Location = new Point(181, 132);
      this.tbxNoOfMonths.MaxLength = 2;
      this.tbxNoOfMonths.Name = "tbxNoOfMonths";
      this.tbxNoOfMonths.Size = new Size(167, 31);
      this.tbxNoOfMonths.TabIndex = 9;
      this.tbxNoOfMonths.TextAlign = HorizontalAlignment.Right;
      this.tbxPledgeDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeDate.ForeColor = SystemColors.MenuHighlight;
      this.tbxPledgeDate.Location = new Point(181, 7);
      this.tbxPledgeDate.MaxLength = 10;
      this.tbxPledgeDate.Name = "tbxPledgeDate";
      this.tbxPledgeDate.Size = new Size(167, 31);
      this.tbxPledgeDate.TabIndex = 12;
      this.tbxPledgeDate.TextAlign = HorizontalAlignment.Right;
      this.tbxValue.BorderStyle = BorderStyle.FixedSingle;
      this.tbxValue.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxValue.ForeColor = SystemColors.MenuHighlight;
      this.tbxValue.Location = new Point(181, 39);
      this.tbxValue.Name = "tbxValue";
      this.tbxValue.Size = new Size(167, 31);
      this.tbxValue.TabIndex = 11;
      this.tbxValue.TextAlign = HorizontalAlignment.Right;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.headerPanel7);
      this.panel6.Controls.Add((Control) this.linkLabel2);
      this.panel6.Controls.Add((Control) this.linkLabel1);
      this.panel6.Controls.Add((Control) this.headerPanel5);
      this.panel6.Controls.Add((Control) this.headerPanel1);
      this.panel6.Controls.Add((Control) this.headerPanel6);
      this.panel6.Controls.Add((Control) this.headerPanel2);
      this.panel6.Controls.Add((Control) this.tbxInterest16);
      this.panel6.Controls.Add((Control) this.tbxRedemptionAmount16);
      this.panel6.Controls.Add((Control) this.lblReminder);
      this.panel6.Controls.Add((Control) this.dgvArticles);
      this.panel6.Location = new Point(5, 250);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(633, 307);
      this.panel6.TabIndex = 89;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = Color.AliceBlue;
      this.headerPanel7.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel7).Location = new Point(8, 233);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(513, 67);
      ((Control) this.headerPanel7).TabIndex = 80;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 10);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(509, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
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
      ((Control) this.glassButton11).Location = new Point(208, 513);
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
      ((Control) this.glassButton12).Location = new Point(342, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.linkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.BackColor = Color.Transparent;
      this.linkLabel2.Location = new Point(589, 285);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(36, 13);
      this.linkLabel2.TabIndex = 89;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "NEXT";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Transparent;
      this.linkLabel1.Location = new Point(527, 285);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(62, 13);
      this.linkLabel1.TabIndex = 88;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "PREVIOUS";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.Ivory;
      this.headerPanel5.CaptionEndColor = Color.White;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "Pure Weight";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxPureWeight);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = Color.White;
      this.headerPanel5.GradientStart = Color.White;
      ((Control) this.headerPanel5).Location = new Point(465, 160);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(159, 49);
      ((Control) this.headerPanel5).TabIndex = 77;
      this.headerPanel5.TextAntialias = true;
      this.tbxPureWeight.BorderStyle = BorderStyle.None;
      this.tbxPureWeight.Dock = DockStyle.Fill;
      this.tbxPureWeight.Font = new Font("Arial Rounded MT Bold", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPureWeight.Location = new Point(0, 0);
      this.tbxPureWeight.Name = "tbxPureWeight";
      this.tbxPureWeight.Size = new Size(157, 22);
      this.tbxPureWeight.TabIndex = 2;
      this.tbxPureWeight.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton15).Location = new Point(-136, 513);
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
      ((Control) this.glassButton16).Location = new Point(-2, 512);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(123, 37);
      ((Control) this.glassButton16).TabIndex = 1;
      ((Control) this.glassButton16).Text = "&EXIT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.Ivory;
      this.headerPanel1.CaptionEndColor = Color.White;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "Deduction";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxDeduction);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = Color.White;
      this.headerPanel1.GradientStart = Color.White;
      ((Control) this.headerPanel1).Location = new Point(466, 58);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(159, 49);
      ((Control) this.headerPanel1).TabIndex = 75;
      this.headerPanel1.TextAntialias = true;
      this.tbxDeduction.BorderStyle = BorderStyle.None;
      this.tbxDeduction.Dock = DockStyle.Fill;
      this.tbxDeduction.Font = new Font("Arial Rounded MT Bold", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeduction.Location = new Point(0, 0);
      this.tbxDeduction.Name = "tbxDeduction";
      this.tbxDeduction.Size = new Size(157, 22);
      this.tbxDeduction.TabIndex = 2;
      this.tbxDeduction.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton13).Location = new Point(-134, 513);
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
      ((Control) this.glassButton14).Location = new Point(0, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 1;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.Ivory;
      this.headerPanel6.CaptionEndColor = Color.White;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "Net Weight";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxNetWeight);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = Color.White;
      this.headerPanel6.GradientStart = Color.White;
      ((Control) this.headerPanel6).Location = new Point(465, 109);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(159, 49);
      ((Control) this.headerPanel6).TabIndex = 76;
      this.headerPanel6.TextAntialias = true;
      this.tbxNetWeight.BorderStyle = BorderStyle.None;
      this.tbxNetWeight.Dock = DockStyle.Fill;
      this.tbxNetWeight.Font = new Font("Arial Rounded MT Bold", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.Location = new Point(0, 0);
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.Size = new Size(157, 22);
      this.tbxNetWeight.TabIndex = 2;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton17).Location = new Point(-134, 513);
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
      ((Control) this.glassButton18).Location = new Point(0, 512);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(123, 37);
      ((Control) this.glassButton18).TabIndex = 1;
      ((Control) this.glassButton18).Text = "&EXIT";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.Ivory;
      this.headerPanel2.CaptionEndColor = Color.White;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "Gross Weight";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxGrossWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnSave);
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnExit);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = Color.White;
      this.headerPanel2.GradientStart = Color.White;
      ((Control) this.headerPanel2).Location = new Point(466, 7);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(159, 49);
      ((Control) this.headerPanel2).TabIndex = 74;
      this.headerPanel2.TextAntialias = true;
      this.tbxGrossWeight.BorderStyle = BorderStyle.None;
      this.tbxGrossWeight.Dock = DockStyle.Fill;
      this.tbxGrossWeight.Font = new Font("Arial Rounded MT Bold", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxGrossWeight.Location = new Point(0, 0);
      this.tbxGrossWeight.Name = "tbxGrossWeight";
      this.tbxGrossWeight.Size = new Size(157, 22);
      this.tbxGrossWeight.TabIndex = 2;
      this.tbxGrossWeight.TextAlign = HorizontalAlignment.Center;
      ((Control) this.btnSave).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSave.GlowColor = Color.White;
      ((ButtonBase) this.btnSave).ImageAlign = ContentAlignment.TopLeft;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(-132, 513);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(128, 35);
      ((Control) this.btnSave).TabIndex = 0;
      ((Control) this.btnSave).Text = "&SAVE";
      ((ButtonBase) this.btnSave).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnExit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExit.BackColor = Color.LightBlue;
      this.btnExit.FadeOnFocus = true;
      ((Control) this.btnExit).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnExit.ForeColor = Color.MediumBlue;
      this.btnExit.ForeColorOnFocus = Color.Red;
      this.btnExit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnExit.GlowColor = Color.White;
      this.btnExit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnExit).Location = new Point(2, 512);
      ((Control) this.btnExit).Name = "btnExit";
      this.btnExit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnExit.ShineColor = Color.Transparent;
      ((Control) this.btnExit).Size = new Size(123, 37);
      ((Control) this.btnExit).TabIndex = 1;
      ((Control) this.btnExit).Text = "&EXIT";
      ((ButtonBase) this.btnExit).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxInterest16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest16.ForeColor = Color.Red;
      this.tbxInterest16.Location = new Point(280, 174);
      this.tbxInterest16.Name = "tbxInterest16";
      this.tbxInterest16.ReadOnly = true;
      this.tbxInterest16.Size = new Size(167, 31);
      this.tbxInterest16.TabIndex = 68;
      this.tbxInterest16.Visible = false;
      this.tbxRedemptionAmount16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionAmount16.ForeColor = Color.Red;
      this.tbxRedemptionAmount16.Location = new Point(107, 172);
      this.tbxRedemptionAmount16.Name = "tbxRedemptionAmount16";
      this.tbxRedemptionAmount16.ReadOnly = true;
      this.tbxRedemptionAmount16.Size = new Size(167, 31);
      this.tbxRedemptionAmount16.TabIndex = 69;
      this.tbxRedemptionAmount16.Visible = false;
      this.lblReminder.AutoSize = true;
      this.lblReminder.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblReminder.ForeColor = Color.Red;
      this.lblReminder.Location = new Point(3, 212);
      this.lblReminder.Name = "lblReminder";
      this.lblReminder.Size = new Size(85, 25);
      this.lblReminder.TabIndex = 71;
      this.lblReminder.Text = "TOTAL";
      this.lblReminder.Visible = false;
      this.dgvArticles.AllowUserToAddRows = false;
      this.dgvArticles.AllowUserToDeleteRows = false;
      this.dgvArticles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvArticles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgvArticles.BackgroundColor = SystemColors.ButtonHighlight;
      this.dgvArticles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.NavajoWhite;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f);
      gridViewCellStyle1.ForeColor = Color.Firebrick;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      this.dgvArticles.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvArticles.ColumnHeadersHeight = 35;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f);
      gridViewCellStyle2.ForeColor = Color.MidnightBlue;
      gridViewCellStyle2.SelectionBackColor = Color.Azure;
      gridViewCellStyle2.SelectionForeColor = Color.Navy;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvArticles.DefaultCellStyle = gridViewCellStyle2;
      this.dgvArticles.EnableHeadersVisualStyles = false;
      this.dgvArticles.Location = new Point(2, 6);
      this.dgvArticles.Name = "dgvArticles";
      this.dgvArticles.ReadOnly = true;
      this.dgvArticles.RowHeadersVisible = false;
      this.dgvArticles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvArticles.Size = new Size(458, 203);
      this.dgvArticles.TabIndex = 38;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.tbxReleasedBy);
      this.panel4.Controls.Add((Control) this.pictureBox2);
      this.panel4.Controls.Add((Control) this.label20);
      this.panel4.Controls.Add((Control) this.tbxCustomerName);
      this.panel4.Controls.Add((Control) this.pictureBox1);
      this.panel4.Controls.Add((Control) this.lblBankBillNumber);
      this.panel4.Controls.Add((Control) this.tbxCustomerCode);
      this.panel4.Controls.Add((Control) this.tbxAddress2);
      this.panel4.Controls.Add((Control) this.tbxAddress1);
      this.panel4.Location = new Point(5, 83);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(634, 177);
      this.panel4.TabIndex = 87;
      this.tbxReleasedBy.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReleasedBy.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReleasedBy.ForeColor = Color.RoyalBlue;
      this.tbxReleasedBy.Location = new Point(465, 140);
      this.tbxReleasedBy.Name = "tbxReleasedBy";
      this.tbxReleasedBy.Size = new Size(160, 21);
      this.tbxReleasedBy.TabIndex = 87;
      this.pictureBox2.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox2.Location = new Point(464, 5);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(163, 158);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 86;
      this.pictureBox2.TabStop = false;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deletePHotoToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(145, 26);
      this.deletePHotoToolStripMenuItem.Name = "deletePHotoToolStripMenuItem";
      this.deletePHotoToolStripMenuItem.Size = new Size(144, 22);
      this.deletePHotoToolStripMenuItem.Text = "Delete PHoto";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(174, 9);
      this.label20.Name = "label20";
      this.label20.Size = new Size(188, 20);
      this.label20.TabIndex = 85;
      this.label20.Text = "CUSTOMER DETAILS";
      this.tbxCustomerName.BackColor = SystemColors.ButtonHighlight;
      this.tbxCustomerName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.ForeColor = Color.RoyalBlue;
      this.tbxCustomerName.Location = new Point(262, 32);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(198, 21);
      this.tbxCustomerName.TabIndex = 8;
      this.pictureBox1.Location = new Point(6, 5);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(163, 155);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 11;
      this.pictureBox1.TabStop = false;
      this.lblBankBillNumber.AutoSize = true;
      this.lblBankBillNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblBankBillNumber.ForeColor = Color.MidnightBlue;
      this.lblBankBillNumber.Location = new Point(174, 134);
      this.lblBankBillNumber.Name = "lblBankBillNumber";
      this.lblBankBillNumber.Size = new Size(238, 25);
      this.lblBankBillNumber.TabIndex = 76;
      this.lblBankBillNumber.Text = "BANK BILL  NUMBER";
      this.lblBankBillNumber.Visible = false;
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.ForeColor = Color.RoyalBlue;
      this.tbxCustomerCode.Location = new Point(174, 32);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(84, 21);
      this.tbxCustomerCode.TabIndex = 9;
      this.tbxCustomerCode.TextAlign = HorizontalAlignment.Center;
      this.tbxAddress2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.ForeColor = Color.RoyalBlue;
      this.tbxAddress2.Location = new Point(174, 82);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(286, 21);
      this.tbxAddress2.TabIndex = 11;
      this.tbxAddress1.BackColor = SystemColors.ButtonHighlight;
      this.tbxAddress1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.ForeColor = Color.RoyalBlue;
      this.tbxAddress1.Location = new Point(174, 57);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(286, 21);
      this.tbxAddress1.TabIndex = 10;
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.Black;
      this.lblHeading.Location = new Point(394, 6);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(174, 29);
      this.lblHeading.TabIndex = 10;
      this.lblHeading.Text = "REDEMPTION";
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1001, 41);
      this.panel2.TabIndex = 9;
      this.tableLayoutPanel1.Anchor = AnchorStyles.None;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Location = new Point(1, 1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.68f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.32f));
      this.tableLayoutPanel1.Size = new Size(1007, 620);
      this.tableLayoutPanel1.TabIndex = 86;
      this.timer2.Interval = 1000;
      this.timer1.Interval = 500;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormViewRedemption);
      this.Text = nameof (FormViewRedemption);
      this.Load += new EventHandler(this.FormViewRedemption_Load);
      this.panel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.hpRedemptionDate).ResumeLayout(false);
      ((Control) this.hpRedemptionDate).PerformLayout();
      ((Control) this.hpAuctionDate).ResumeLayout(false);
      ((Control) this.hpAuctionDate).PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((ISupportInitialize) this.dgvArticles).EndInit();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
