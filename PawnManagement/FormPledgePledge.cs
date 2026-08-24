
using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using SecuGen.SecuSearchSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Transitions;
using ZeeUIUtility;

namespace PawnManagement
{
  public class FormPledgePledge : Form
  {
    private bool calculateCompoundInterest = false;
    private string formType = "";
    private int pledgeBillNumberCharacterCount = 0;
    private DataTable dtPrintNotice = new DataTable();
    private string pledgeAmountForEdit = "";
    private ReportDocument rd = new ReportDocument();
    private string oldValuesArticles = "";
    private string newValuesArticles = "";
    private string BILLNUMBER;
    private string oldValues;
    private string newValues;
    private string ch = "a";
    private bool flag = true;
    private int count = 0;
    private int comboboxEnterCount = 0;
    private double totalAmount = 0.0;
    private double totalInterest = 0.0;
    private double totalRedemptionAmount = 0.0;
    private DataTable tblA = new DataTable();
    private List<string> lstArticles = new List<string>();
    private List<string> lstPurpose = new List<string>();
    private object value = (object) "";
    private object valueNo = (object) "";
    private string symbolToPrintAsInterestRate = "";
    private List<string> lstAddress = new List<string>();
    private List<string> articlesDescription = new List<string>();
    private string ledgerCode;
    private string voucherCode;
    private string ledgerCodeInterest;
    private string voucherCodeInterestGirvi;
    private string voucherCodeInterestChoot;
    private string ledgerName;
    private string voucherName;
    private string ledgerNameInterest;
    private string voucherNameInterestGirvi;
    private string voucherNameInterestChoot;
    private int escapeCount = 0;
    private DataTable dtNotice = new DataTable();
    private bool noticeClickedOnce = false;
    private string InterestSetting = "";
    private SS_IDInfo idInfo;
    private byte[] minData;
    private string defaultCustomerCode = "";
    private IContainer components = (IContainer) null;
    private DataGridView dgvAuctionedPledges;
    private DataGridView dgvRedeemedPledges;
    private DataGridView dgvCustomerPledgeDetails;
    private DataGridViewEx dgvArticles;
    private System.Windows.Forms.Timer timer1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private DataGridViewTextBoxColumn colArticles;
    private DataGridViewTextBoxColumn colArticlesDetails;
    private DataGridViewTextBoxColumn colNo;
    private DataGridViewTextBoxColumn colGrossWeight;
    private DataGridViewTextBoxColumn colDeduction;
    private DataGridViewTextBoxColumn colNetWeight;
    private DataGridViewTextBoxColumn colPurity;
    private DataGridViewTextBoxColumn colHiddenRemarks;
    private DataGridViewTextBoxColumn colPureWeight;
    private DataGridView dgvCustomerDetails;
    private TextBox tbxPay;
    private DataGridView dgvPendingPledges;
    private TextBox tbxTotalInterest;
    private TextBox tbxOldBillNumber;
    private TextBox tbxChit;
    private TextBox tbxweight;
    private TextBox tbxInteresRate;
    private TextBox tbxDeductions;
    private ComboBox cbType;
    private TextBox tbxNetWeight;
    private TextBox tbxReminder;
    private TextBox tbxAmount;
    private TextBox tbxValue;
    private TextBox textBox6;
    private TextBox textBox5;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private TextBox textBox12;
    private TextBox textBox11;
    private TextBox textBox10;
    private TextBox textBox9;
    private TextBox textBox8;
    private TextBox textBox7;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel panel2;
    private TextBox textBox13;
    private TextBox tbxPureWeight;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem selectAllToolStripMenuItem;
    private ToolStripMenuItem unSelectAllToolStripMenuItem;
    private ToolStripMenuItem printNoticeToolStripMenuItem;
    private ToolStripMenuItem printCustomerDetailsToolStripMenuItem;
    private BackgroundWorker backgroundWorker1;
    private DataGridViewCheckBoxColumn colSelect;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;
    private BackgroundWorker backgroundWorker2;
    private ContextMenuStrip cmsDeletePledge;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem releaseToolStripMenuItem;
    private ToolStripMenuItem receivePartPaymentToolStripMenuItem;
    private ToolStripMenuItem calculateCompoundInterestToolStripMenuItem;
    private ToolStripMenuItem setIntimationLetterAsGivenInPersonToolStripMenuItem;
    private TextBox textBox14;
    private TextBox tbxTotalAmount;
    private TextBox textBox15;
    private TextBox tbxtotalPendingInterest;
    private TextBox textBox16;
    private TextBox tbxTotalAmountPlusInterest;
    private TextBox textBox17;
    private ComboBox cbView;
    private Panel panel4;
    private Button btnSave;
    private Panel panel1;
    private Label label3;
    private TextBox tbxBillDate;
    private Panel panel5;
    private Label label2;
    private ComboBox cbShopCodes;
    private Panel panel6;
    private Label label1;
    private TextBox tbxBillNumber;
    private Panel panel3;
    private TextBox tbxPincode;
    private TextBox tbxCell;
    private TextBox tbxCustomerCode;
    private TextBox tbxAddress1;
    private TextBox tbxNumber;
    private TextBox tbxAddress2;
    private TextBox tbxAddress3;
    private TextBox textBox18;
    private TextBox textBox20;
    private TextBox textBox21;
    private TextBox textBox22;
    private TextBox textBox23;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox tbxCustomerName;
    private TextBox tbxNotes;
    private GlassButton btnAdd;
    private PictureBox pbFingerPrint;
    private GlassButton btnEdit;
    private PictureBox pictureBox2;
    private TextBox tbxAverageNumberOfDaysForRelease;
    private TextBox tbxNumberOfTimesReleaseExceedTwelveMonths;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCity;
    private Panel panel8;
    private TextBox textBox19;
    private Panel panel9;
    private Label label5;
    private Panel panel7;
    private Label label4;
    private Panel panel10;
    private Label label6;
    private GlassButton btnJewelPhoto;
    private PictureBox pbJewelPhoto;
    private DataGridView dgvAllPledge;
    private TextBox textBox26;
    private TextBox tbxReleaseDate;
    private TextBox textBox27;
    private TextBox tbxPurpose;
    private TextBox textBox28;
    private TextBox tbxIncome;
    private ContextMenuStrip contextMenuStrip3;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem1;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem1;

    public FormPledgePledge() => this.InitializeComponent();

    public FormPledgePledge(string FORMTYPE)
    {
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    public FormPledgePledge(string FORMTYPE, string DefaultCstomerCode)
    {
      this.defaultCustomerCode = DefaultCstomerCode;
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    private void getBillNumbers(string shopCode)
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblPledge where shopcode = @ShopCode and redeemed  = 'N'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) shopCode)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form Duplicate Bill print", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          this.lstAddress.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstAddress.Add(row["BillNumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form duplicateBill.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbShopCodes_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void getShopDetails()
    {
      try
      {
        DataTable shopDetails = PawnManagementClass.getShopDetails(this.cbShopCodes.Text);
        if (shopDetails == null || shopDetails.Rows.Count <= 0)
          return;
        this.Text = shopDetails.Rows[0].Field<string>("ShopName");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getShopDetails", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getCustomerDetails(string customerCode)
    {
      string strError = "";
      string my_querry = "Select tc.CID,tc.CName,tc.CNo,tc.CAddr1,tc.CPhone,tc.CCell,tc.CAddr2,tc.CAddr3,tc.CCity,tc.CPinCode,tc.Cnotes,tc.MonthlyIncome from (select * from tblcustomers order by cname) tc where tc.CID like @cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("cid", (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormPledge.getCustomerDetails(string customerdoed)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else
      {
        try
        {
          this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CID");
          this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CName");
          this.tbxPhoneNumber.Text = dataTable2.Rows[0].Field<string>("CPhone");
          this.tbxCell.Text = dataTable2.Rows[0].Field<string>("CCell");
          this.tbxNumber.Text = dataTable2.Rows[0].Field<string>("CNo");
          this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("CAddr1");
          this.tbxAddress2.Text = dataTable2.Rows[0].Field<string>("CAddr2");
          this.tbxAddress3.Text = dataTable2.Rows[0].Field<string>("CAddr3");
          this.tbxCity.Text = dataTable2.Rows[0].Field<string>("CCity");
          this.tbxPincode.Text = dataTable2.Rows[0].Field<string>("CPinCode");
          this.tbxNumberOfTimesReleaseExceedTwelveMonths.Text = PawnManagementClass.numberOfTimesReleaseExceededTwelveMonths(this.tbxCustomerCode.Text);
          this.tbxAverageNumberOfDaysForRelease.Text = PawnManagementClass.averageOfNumberOfMonthsForRelease(this.tbxCustomerCode.Text);
          this.tbxIncome.Text = dataTable2.Rows[0]["MonthlyIncome"].ToString();
          if (dataTable2.Rows[0].Field<string>("CNotes").ToString() != "")
          {
            this.tbxNotes.Visible = true;
            this.tbxNotes.Text = dataTable2.Rows[0].Field<string>("CNotes").ToString();
            Transition.run((object) this.tbxNotes, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(20, 700));
          }
          else
            this.tbxNotes.Visible = false;
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.getCustomerDeatils(customerCode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void getCustomerDetails()
    {
      string strError = "";
      string my_querry = "(Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cid like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cname like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cno like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where caddr1 like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where caddr2 like '" + this.tbxCustomerName.Text + "%') union all (Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cphone like '%" + this.tbxCustomerName.Text + "%') ";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvCustomerDetails.BringToFront();
        this.dgvCustomerDetails.Visible = true;
        this.dgvCustomerDetails.DataSource = (object) dataTable2;
        this.dgvCustomerDetails.ClearSelection();
      }
      else
      {
        this.tbxCustomerName.Text = this.tbxCustomerName.Text.Substring(0, this.tbxCustomerName.Text.Length - 1);
        this.tbxCustomerName.Select(this.tbxCustomerName.Text.Length, 0);
      }
    }

    private void getCustomerDetailsSimple()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cid like '" + this.tbxCustomerName.Text + "%' or CName like '" + this.tbxCustomerName.Text + "%' or CPhone like '%" + this.tbxCustomerName.Text + "%'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvCustomerDetails.BringToFront();
        this.dgvCustomerDetails.Visible = true;
        this.dgvCustomerDetails.DataSource = (object) dataTable2;
        this.dgvCustomerDetails.ClearSelection();
      }
      else
      {
        this.tbxCustomerName.Text = this.tbxCustomerName.Text.Substring(0, this.tbxCustomerName.Text.Length - 1);
        this.tbxCustomerName.Select(this.tbxCustomerName.Text.Length, 0);
      }
    }

    private string strGetPledgeBillNumber()
    {
      if (!PledgeClass.checkifpledgetableempty(this.cbShopCodes.Text))
      {
        string str1 = "'" + PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "%'";
        string strError = "";
        string my_querry = "select max(BillNumber) as BillNumber from tblPledge where ShopCode = @ShopCode and BillNumber like " + str1;
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
        }
        if (dataTable2 != null && dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "")
        {
          try
          {
            switch (FormMain.BillNumberSeries)
            {
              case "DOUBLE":
                string str2 = dataTable2.Rows[0].Field<string>("BillNumber");
                this.ch = str2.Substring(0, 2);
                int num1 = int.Parse(str2.Substring(2));
                int num2;
                if (num1 != 10000)
                {
                  num2 = num1 + 1;
                }
                else
                {
                  char ch1 = (char) ((uint) str2[1] + 1U);
                  string str3 = str2[0].ToString();
                  int num3 = (int) ch1;
                  char ch2 = (char) (num3 + 1);
                  string str4 = ((char) num3).ToString();
                  this.ch = str3 + str4;
                  num2 = 1;
                }
                if (num2 < 10)
                  return this.ch + "0000" + num2.ToString();
                if (num2 < 100)
                  return this.ch + "000" + num2.ToString();
                if (num2 < 1000)
                  return this.ch + "00" + num2.ToString();
                return num2 < 10000 ? this.ch + "0" + num2.ToString() : this.ch + num2.ToString();
              case "SINGLE":
                string str5 = dataTable2.Rows[0].Field<string>("BillNumber");
                this.ch = str5[0].ToString();
                int num4 = int.Parse(str5.Substring(1));
                int num5;
                if (num4 != 10000)
                {
                  num5 = num4 + 1;
                }
                else
                {
                  this.ch = ((char) ((uint) this.ch[0] + 1U)).ToString();
                  num5 = 1;
                }
                if (num5 < 10)
                  return this.ch + "0000" + num5.ToString();
                if (num5 < 100)
                  return this.ch + "000" + num5.ToString();
                if (num5 < 1000)
                  return this.ch + "00" + num5.ToString();
                return num5 < 10000 ? this.ch + "0" + num5.ToString() : this.ch + num5.ToString();
            }
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form Plege.getPledgeBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        }
        else
        {
          int num = (int) MessageBox.Show("No Bills found in this serial Number...check bill number series in options or Try oldPledge first");
          this.cbShopCodes.Select();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("No Bills Found ...try oldPledge first");
        this.cbShopCodes.Select();
      }
      return "";
    }

    private void getPledgeBillNumber()
    {
      string billNumberSeries = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text);
      string str1 = "'" + billNumberSeries + "%'";
      if (!PledgeClass.checkifpledgetableempty(this.cbShopCodes.Text))
      {
        string strError = "";
        string my_querry = "select max(BillNumber) as BillNumber from tblPledge where ShopCode = @ShopCode and BillNumber like " + str1;
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledgerBillNumber.getPledgeBillNumber", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
        }
        if (dataTable2 != null && dataTable2.Rows[0]["BillNumber"] != null && dataTable2.Rows[0]["BillNumber"].ToString() != "")
        {
          try
          {
            switch (FormMain.BillNumberSeries)
            {
              case "DOUBLE":
                string str2 = dataTable2.Rows[0].Field<string>("BillNumber");
                this.ch = str2.Substring(0, 2);
                int num1 = int.Parse(str2.Substring(2));
                int num2;
                if (num1 != 10000)
                {
                  num2 = num1 + 1;
                }
                else
                {
                  char ch1 = (char) ((uint) str2[1] + 1U);
                  string str3 = str2[0].ToString();
                  int num3 = (int) ch1;
                  char ch2 = (char) (num3 + 1);
                  string str4 = ((char) num3).ToString();
                  this.ch = str3 + str4;
                  num2 = 1;
                }
                if (num2 < 10)
                {
                  this.tbxBillNumber.Text = this.ch + "0000" + num2.ToString();
                  break;
                }
                if (num2 < 100)
                {
                  this.tbxBillNumber.Text = this.ch + "000" + num2.ToString();
                  break;
                }
                if (num2 < 1000)
                {
                  this.tbxBillNumber.Text = this.ch + "00" + num2.ToString();
                  break;
                }
                if (num2 < 10000)
                {
                  this.tbxBillNumber.Text = this.ch + "0" + num2.ToString();
                  break;
                }
                this.tbxBillNumber.Text = this.ch + num2.ToString();
                break;
              case "SINGLE":
                string str5 = dataTable2.Rows[0].Field<string>("BillNumber");
                this.ch = str5[0].ToString();
                int num4 = int.Parse(str5.Substring(1));
                int num5;
                if (num4 != 10000)
                {
                  num5 = num4 + 1;
                }
                else
                {
                  char ch = this.ch[0];
                  this.ch = (ch != '0' ? (char) ((uint) ch + 1U) : 'A').ToString();
                  num5 = 1;
                }
                if (num5 < 10)
                  this.tbxBillNumber.Text = this.ch + "0000" + num5.ToString();
                else if (num5 < 100)
                  this.tbxBillNumber.Text = this.ch + "000" + num5.ToString();
                else if (num5 < 1000)
                  this.tbxBillNumber.Text = this.ch + "00" + num5.ToString();
                else if (num5 < 10000)
                  this.tbxBillNumber.Text = this.ch + "0" + num5.ToString();
                else
                  this.tbxBillNumber.Text = this.ch + num5.ToString();
                break;
            }
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form Plege.getPledgeBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        }
        else
          this.tbxBillNumber.Text = billNumberSeries + "00001";
      }
      else
        this.tbxBillNumber.Text = billNumberSeries + "00001";
    }

    private void changePledgeBillNumberSeries(string ch)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblPledgeBillNumberSeries set CurrentSeries = @CurrentSeries where shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CurrentSeries", (object) ch.ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.changePledgerBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private void textBoxAmount_Leave(object sender, EventArgs e)
    {
      if (this.tbxAmount.Text.Trim() != "")
      {
        if (double.Parse(this.tbxValue.Text) <= double.Parse(this.tbxAmount.Text))
        {
          TextBox textBox = sender as TextBox;
          textBox.BackColor = Color.White;
          textBox.ForeColor = Color.Red;
          string autoAdjustSetting = PawnManagementClass.getValueAutoAdjustSetting();
          if (autoAdjustSetting != "0")
            this.tbxValue.Text = (Math.Round((double.Parse(this.tbxAmount.Text) + double.Parse(this.tbxAmount.Text) * double.Parse(autoAdjustSetting) / 100.0) / 100.0) * 100.0).ToString();
          else
            this.tbxAmount.Select();
        }
        if (double.Parse(this.tbxValue.Text) <= double.Parse(this.tbxAmount.Text))
          return;
        TextBox textBox1 = sender as TextBox;
        textBox1.BackColor = Color.White;
        textBox1.ForeColor = Color.Blue;
      }
      else
        this.tbxAmount.Select();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        ++this.escapeCount;
      if (this.escapeCount > 2)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getDeduction()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblGramRate where Type=@Type";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("Type", (object) this.cbType.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getDeduction", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form ledge.getDeduction" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxDeductions.Text = double.Parse(dataTable2.Rows[0]["deduction"].ToString()).ToString();
        else
          this.tbxDeductions.Text = "0";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getdeduction()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void Pledge_Load(object sender, EventArgs e)
    {
      try
      {
        this.SuspendLayout();
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        if (FormMain.BillNumberSeries == "DOUBLE")
          this.tbxBillNumber.MaxLength = 7;
        this.Text = this.formType;
        PawnManagementClass.formatDataGridViewBluePledge(ref this.dgvCustomerDetails);
        PawnManagementClass.formatDataGridViewBluePledge(ref this.dgvPendingPledges);
        PawnManagementClass.formatDataGridViewBluePledge(ref this.dgvRedeemedPledges);
        PawnManagementClass.formatDataGridViewBluePledge(ref this.dgvAuctionedPledges);
        PawnManagementClass.formatDataGridViewControl(ref this.dgvCustomerPledgeDetails);
        PawnManagementClass.formatButtonBlue(ref this.btnEdit);
        ((DataGridView) this.dgvArticles).BackgroundColor = Color.Azure;
        ((DataGridView) this.dgvArticles).GridColor = Color.CornflowerBlue;
        ((DataGridView) this.dgvArticles).DefaultCellStyle.BackColor = Color.Azure;
        ((DataGridView) this.dgvArticles).ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
        ((DataGridView) this.dgvArticles).AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        ((DataGridView) this.dgvArticles).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        ((DataGridView) this.dgvArticles).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCustomerPledgeDetails.ForeColor = Color.Black;
        this.dgvCustomerPledgeDetails.EnableHeadersVisualStyles = false;
        this.dgvCustomerPledgeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.dgvCustomerPledgeDetails.RowHeadersVisible = false;
        this.dgvCustomerPledgeDetails.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        this.dgvCustomerPledgeDetails.RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        this.dgvCustomerPledgeDetails.ScrollBars = ScrollBars.Both;
        this.dgvCustomerPledgeDetails.BackgroundColor = Color.Azure;
        this.dgvCustomerPledgeDetails.DefaultCellStyle.BackColor = Color.Azure;
        this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.PowderBlue;
        this.dgvCustomerPledgeDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        this.dgvCustomerPledgeDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        this.dgvCustomerPledgeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
        this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
        this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        this.dgvCustomerPledgeDetails.ColumnHeadersHeight = 25;
        this.dgvPendingPledges.GridColor = Color.PowderBlue;
        this.dgvPendingPledges.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        this.dgvPendingPledges.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        this.dgvCustomerDetails.GridColor = Color.PowderBlue;
        this.dgvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        this.dgvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        if (this.cbView.Items.Count > 0)
          this.cbView.SelectedIndex = 0;
        this.getShopCodes();
        if (this.cbShopCodes.Items.Count > 0)
          this.cbShopCodes.SelectedIndex = 0;
        this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
        this.getShopDetails();
        this.dgvCustomerDetails.Width = 890;
        this.dgvCustomerDetails.Height = 500;
        this.getArticles();
        this.getArticlesDescription();
        ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colArticles);
        ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colArticlesDetails);
        ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colHiddenRemarks);
        if (FormMain.withIndividualWeight)
        {
          ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colPurity);
          ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colGrossWeight);
          ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colDeduction);
          ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colNetWeight);
          ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colPureWeight);
          this.colPurity.MaxInputLength = 3;
          this.colGrossWeight.MaxInputLength = 9;
          this.colDeduction.MaxInputLength = 9;
          this.colNetWeight.MaxInputLength = 9;
          this.colPureWeight.MaxInputLength = 9;
          this.colPurity.FillWeight = 20f;
          this.colGrossWeight.FillWeight = 50f;
          this.colDeduction.FillWeight = 50f;
          this.colNetWeight.FillWeight = 50f;
          this.colPureWeight.FillWeight = 50f;
          this.colPurity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colGrossWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colDeduction.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colNetWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colPureWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          this.colHiddenRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          ((DataGridView) this.dgvArticles).RowsDefaultCellStyle.Font = new Font("cambria", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        }
        else
        {
          ((DataGridView) this.dgvArticles).RowTemplate.Height = 20;
          ((DataGridView) this.dgvArticles).DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        }
        ((DataGridView) this.dgvArticles).Columns.Add((DataGridViewColumn) this.colNo);
        this.colNo.MaxInputLength = 2;
        this.colNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.colHiddenRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.colArticlesDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.colHiddenRemarks.FillWeight = 50f;
        if (this.cbType.Items.Count > 0)
          this.cbType.SelectedIndex = 0;
        this.tbxweight.Enter += new EventHandler(this.textBox_Enter);
        this.tbxOldBillNumber.Enter += new EventHandler(this.textBox_Enter);
        this.tbxReminder.Enter += new EventHandler(this.textBox_Enter);
        this.tbxPureWeight.Enter += new EventHandler(this.textBox_Enter);
        this.tbxDeductions.Enter += new EventHandler(this.textBox_Enter);
        this.tbxNetWeight.Enter += new EventHandler(this.textBox_Enter);
        this.tbxValue.Enter += new EventHandler(this.textBox_Enter);
        this.tbxAmount.Enter += new EventHandler(this.textBox_Enter);
        this.tbxChit.Enter += new EventHandler(this.textBox_Enter);
        this.tbxInteresRate.Enter += new EventHandler(this.textBox_Enter);
        this.tbxTotalInterest.Enter += new EventHandler(this.textBox_Enter);
        this.tbxPay.Enter += new EventHandler(this.textBox_Enter);
        this.tbxBillNumber.Enter += new EventHandler(this.textBox_Enter);
        this.tbxBillDate.Enter += new EventHandler(this.textBox_Enter);
        this.tbxCustomerName.Enter += new EventHandler(this.textBox_Enter);
        this.tbxReleaseDate.Enter += new EventHandler(this.textBox_Enter);
        this.tbxweight.Leave += new EventHandler(this.textBox_Leave);
        this.tbxOldBillNumber.Leave += new EventHandler(this.textBox_Leave);
        this.tbxReminder.Leave += new EventHandler(this.textBox_Leave);
        this.tbxPureWeight.Leave += new EventHandler(this.textBox_Leave);
        this.tbxDeductions.Leave += new EventHandler(this.textBox_Leave);
        this.tbxNetWeight.Leave += new EventHandler(this.textBox_Leave);
        this.tbxValue.Leave += new EventHandler(this.textBox_Leave);
        this.tbxAmount.Leave += new EventHandler(this.textBoxAmount_Leave);
        this.tbxChit.Leave += new EventHandler(this.textBox_Leave);
        this.tbxInteresRate.Leave += new EventHandler(this.textBox_Leave);
        this.tbxPay.Leave += new EventHandler(this.textBox_Leave);
        this.tbxBillNumber.Leave += new EventHandler(this.textBox_Leave);
        this.tbxBillDate.Leave += new EventHandler(this.textBox_Leave);
        this.tbxCustomerName.Leave += new EventHandler(this.textBox_Leave);
        this.tbxReleaseDate.Leave += new EventHandler(this.textBox_Leave);
        if (FormMain.memberType == "ak")
        {
          this.dgvCustomerPledgeDetails.Visible = false;
          this.tbxTotalAmount.Visible = false;
          this.tbxTotalInterest.Visible = false;
          this.tbxTotalAmountPlusInterest.Visible = false;
        }
        this.colArticles.FillWeight = 100f;
        this.colArticlesDetails.FillWeight = 40f;
        if (this.formType == "NEW PLEDGE")
        {
          if (PawnManagementClass.checkForValidateDate(((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text.ToString()))
            this.tbxBillDate.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text.ToString();
          else
            this.tbxBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
          this.cbShopCodes.Select();
        }
        if (this.formType == "OLD PLEDGE")
        {
          this.tbxBillNumber.ReadOnly = false;
          this.cbShopCodes.Select();
        }
        if (this.formType == "PLEDGE EDIT")
        {
          this.tbxBillNumber.ReadOnly = false;
          this.cbShopCodes.Select();
        }
        this.backgroundWorker2.RunWorkerAsync();
        if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
        {
          if (FormMain.AutoOnfingerPrint)
            FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
          else
            FormMain.m_FPM.EnableAutoOnEvent(false, 0);
        }
        if (!FormPrintSettings.boolReduceFirstMonthInterest())
        {
          this.tbxChit.ReadOnly = true;
          this.tbxTotalInterest.ReadOnly = true;
          this.tbxPay.ReadOnly = true;
        }
        this.lstPurpose = PawnManagement.Classes.PawnManagementClasses.PledgeClass.getPurposeList();
        this.tbxPurpose.CharacterCasing = CharacterCasing.Upper;
        this.tbxPurpose.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxPurpose.AutoCompleteSource = AutoCompleteSource.CustomSource;
        this.tbxPurpose.AutoCompleteCustomSource.Clear();
        this.tbxPurpose.AutoCompleteCustomSource.AddRange(this.lstPurpose.ToArray());
        this.ResumeLayout();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.pledgeLoad", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
        if (dataTable2.Rows[0]["PledgeScreen"] != null && dataTable2.Rows[0]["PledgeScreen"].ToString() != "")
        {
          this.InterestSetting = dataTable2.Rows[0]["PledgeScreen"].ToString();
          if (dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"] != null && dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"].ToString() != "" && dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"].ToString() == "COMPOUND")
            this.calculateCompoundInterest = true;
        }
      }
      else
        this.InterestSetting = "Interest Setting";
    }

    private bool getPrintSettings()
    {
      string strError = "";
      string my_querry = "select * from tblpLEDGEprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && !dataTable2.Rows[0]["printprompt"].ToString().Equals("Y"))
        return false;
      return true;
    }

    private int GetDataGridViewHeight(DataGridView dataGridView) => (dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0) + dataGridView.Rows.OfType<DataGridViewRow>().Where<DataGridViewRow>((System.Func<DataGridViewRow, bool>) (r => r.Visible)).Sum<DataGridViewRow>((System.Func<DataGridViewRow, int>) (r => r.Height));

    private bool getjewelphotoSettings()
    {
      string strError = "";
      string my_querry = "select * from tblprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getjewelphotosettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getjewelphotosettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && !dataTable2.Rows[0]["jewelphotoprompt"].ToString().Equals("Y"))
        return false;
      return true;
    }

    private bool getRokadAutoEntrySettings()
    {
      string strError = "";
      string my_querry = "select * from tblAutodeleterokad";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getrokadautoentrysettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getrokadautoentrysettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && !dataTable2.Rows[0]["autoentry"].ToString().Equals("Y"))
        return false;
      return true;
    }

    private void Form2_Validating(object sender, CancelEventArgs e)
    {
    }

    private bool checkIfPledgeBillNumberAlreadyExists(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getrokadautoentrysettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getrokadautoentrysettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void finishedentry()
    {
      try
      {
        if (DialogResult.Yes != MessageBox.Show("save?", "are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
          return;
        if (!this.checkIfPledgeBillNumberAlreadyExists(this.tbxBillNumber.Text, this.cbShopCodes.Text))
        {
          this.savePledge();
          this.savePledgeArticles();
          if (this.formType == "NEW PLEDGE")
            this.changePledgeBillNumberSeries(this.ch);
          if (this.formType == "NEW PLEDGE")
          {
            if (this.getRokadAutoEntrySettings())
              this.insertIntoTableVouchers();
            PawnManagementClass.InsertIntoHistory("PLEDGE NEW", "New pledge" + this.tbxBillNumber.Text + " created for " + this.tbxCustomerCode.Text.Trim().ToString(), "", "", FormMain.username, DateTime.Now.ToString());
            this.printPledge();
            if (this.getjewelphotoSettings() && DialogResult.Yes == MessageBox.Show("Take Jewwel PHoto?", "Take Jewel Photo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
              new FormJewelPhoto(this.tbxBillNumber.Text, this.cbShopCodes.Text).Show();
            if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
            {
              if (FormMain.AutoOnfingerPrint)
                FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
              else
                FormMain.m_FPM.EnableAutoOnEvent(false, 0);
            }
            this.reset();
            this.cbShopCodes.Select();
          }
          else if (this.formType == "OLD PLEDGE")
          {
            if (this.getRokadAutoEntrySettings() && DialogResult.Yes == MessageBox.Show("Enter Data to Rokad", "Are you sure?", MessageBoxButtons.YesNo))
              this.insertIntoTableVouchers();
            this.reset();
            this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
            this.tbxBillNumber.Select();
            switch (FormMain.BillNumberSeries)
            {
              case "SINGLE":
                this.tbxBillNumber.Select(2, this.tbxBillNumber.Text.Length);
                break;
              case "DOUBLE":
                this.tbxBillNumber.Select(3, this.tbxBillNumber.Text.Length);
                break;
            }
            this.getPledgeBillNumber();
            this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length - 2;
            this.tbxBillNumber.Select(this.tbxBillNumber.Text.Length - 2, 2);
          }
          this.refreshSidePanel();
        }
        else if (DialogResult.Yes == MessageBox.Show("Bill Number Already Exists..!!! want to use next Number???", "Bill Number Already Exists..!!! want to use next Number???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
        {
          this.tbxBillNumber.Text = this.strGetPledgeBillNumber();
          this.tbxBillNumber.Select();
        }
        else
        {
          string text = this.tbxBillNumber.Text;
          this.tbxBillNumber.Text = "";
          this.tbxBillNumber.Text = text;
          this.tbxBillNumber.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.finishedEntry()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public void refreshSidePanel() => this.pledgeReport(((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text);

    private void pledgeReport(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("Select ShopCode,Billnumber,Amount,temp5 as Interest,customername,BillDate from tblPledge  where BillDate = @BillDate order by shopcode,billnumber ", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) BILLDATE)
      }, ref strError);
      double num1 = 0.0;
      double num2 = 0.0;
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          num1 += double.Parse(row["Amount"].ToString());
          num2 += double.Parse(row["Interest"].ToString());
        }
      }
      dataTable2.Rows.Add();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Amount"] = (object) num1.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Interest"] = (object) num2.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["BillNumber"] = (object) (dataTable2.Rows.Count - 1);
      Form mdiParent = this.MdiParent;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).DataSource = (object) dataTable2;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).FirstDisplayedScrollingRowIndex = ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).RowCount - 1;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).Columns["Shopcode"].Visible = false;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).Columns["BillDate"].Visible = false;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel1.Controls["dataGridView1"] as DataGridView).Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void reset()
    {
      this.tbxBillNumber.Text = "";
      this.tbxCustomerName.Text = "";
      this.tbxAddress1.Text = "";
      this.tbxAddress2.Text = "";
      this.tbxAddress3.Text = "";
      this.tbxCell.Text = "";
      this.tbxPhoneNumber.Text = "";
      this.tbxCity.Text = "";
      this.tbxValue.Text = "";
      this.tbxPincode.Text = "";
      this.tbxOldBillNumber.Text = "";
      this.tbxReminder.Text = "";
      this.tbxweight.Text = "";
      this.tbxDeductions.Text = "";
      this.tbxNetWeight.Text = "";
      this.tbxPureWeight.Text = "";
      ((DataGridView) this.dgvArticles).Rows.Clear();
      this.tbxAmount.Text = "";
      this.tbxInteresRate.Text = "";
      this.tbxTotalAmount.Text = "";
      this.tbxTotalInterest.Text = "";
      this.tbxTotalAmountPlusInterest.Text = "";
      this.dgvCustomerPledgeDetails.DataSource = (object) null;
      this.tbxCustomerCode.Text = "";
      this.tbxNumber.Text = "";
      this.tbxChit.Text = "";
      this.tbxtotalPendingInterest.Text = "";
      this.tbxPay.Text = "";
      this.tbxNotes.Text = "";
      this.tbxReleaseDate.Text = "";
      this.tbxNotes.Visible = false;
      this.tbxPurpose.Text = "";
      this.tbxIncome.Text = "";
      if (!File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        return;
      using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
      {
        this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void insertIntoTableVouchers()
    {
      try
      {
        string s = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
        string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), maxOfVoucherNumber, this.voucherCode, this.voucherName, this.tbxBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text, "G1", "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
        if (!FormPrintSettings.boolReduceFirstMonthInterest())
          return;
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), (int.Parse(maxOfVoucherNumber) + 1).ToString(), this.voucherCodeInterestGirvi, this.voucherNameInterestGirvi, this.tbxBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text, "B1", "JAMMA", double.Parse(this.tbxTotalInterest.Text.Trim().ToString()));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.insertIntoTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getPledgeArticlesCombinedWithHr()
    {
      string articlesCombinedWithHr = "";
      for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
      {
        string str1 = ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString();
        string str2 = ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString();
        string str3 = ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value.ToString();
        double num1 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? "0" : ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString());
        double num2 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value.ToString());
        double num3 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value.ToString());
        double num4 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value.ToString());
        double num5 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value.ToString());
        string str4 = ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString();
        if (str2 != "")
          str2 = "(" + str2 + ")";
        if (str3 != "")
          str3 = "(" + str3 + ")";
        if (articlesCombinedWithHr == "")
          articlesCombinedWithHr = articlesCombinedWithHr + str1 + str2 + str3 + " (" + (object) num1 + "% Wt: " + (object) num2 + " Dedn:" + (object) num3 + " NetWt" + (object) num4 + " PWt:" + (object) num5 + ") - " + str4;
        else
          articlesCombinedWithHr = articlesCombinedWithHr + "," + str1 + str2 + str3 + " (" + (object) num1 + "% Wt: " + (object) num2 + " Dedn:" + (object) num3 + " NetWt" + (object) num4 + " PWt:" + (object) num5 + ") - " + str4;
      }
      return articlesCombinedWithHr;
    }

    private string getPledgeArticlesCombined()
    {
      string articlesCombined = "";
      for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
      {
        string str1 = ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString();
        string str2 = ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString();
        string str3 = !FormMain.withIndividualWeight ? ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString() : ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString();
        if (str2 != "")
          str2 = "(" + str2 + ")";
        if (articlesCombined == "")
          articlesCombined = articlesCombined + str1 + str2 + "- " + str3;
        else
          articlesCombined = articlesCombined + "," + str1 + str2 + "- " + str3;
      }
      return articlesCombined;
    }

    private string getPledgeArticlesCombinedWithouthHr()
    {
      string combinedWithouthHr = "";
      for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
      {
        string str1 = ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString();
        string str2 = ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString();
        double num1 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? "0" : ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString());
        double num2 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value.ToString());
        double num3 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value.ToString());
        double num4 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value.ToString());
        double num5 = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value.ToString());
        string str3 = ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString();
        if (str2 != "")
          str2 = "(" + str2 + ")";
        if (combinedWithouthHr == "")
          combinedWithouthHr = combinedWithouthHr + str1 + str2 + " (" + (object) num1 + "% Wt: " + (object) num2 + " Dedn:" + (object) num3 + " NetWt" + (object) num4 + " PWt:" + (object) num5 + ") - " + str3;
        else
          combinedWithouthHr = combinedWithouthHr + "," + str1 + str2 + " (" + (object) num1 + "% Wt: " + (object) num2 + " Dedn:" + (object) num3 + " NetWt" + (object) num4 + " PWt:" + (object) num5 + ") - " + str3;
      }
      return combinedWithouthHr;
    }

    private void insertPledgeArticles(
      string BillNumber,
      string Articles,
      string ArticlesDescription,
      string HiddenRemarks,
      double Purity,
      double GrossWeight,
      double Deduction,
      double NetWeight,
      double PureWeight,
      string no)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("insert into tblPledgeArticles(ShopCode,BillNumber,Articles,ArticlesDescription,Purity,Hr,GrossWeight,Deduction,NetWeight,PureWeight,Num,CreatedBy,CreatedOn) values(@ShopCode,@BillNumber,@Articles,@ArticlesDescription,@Purity,@Hr,@GrossWeight,@Deduction,@NetWeight,@PureWEight,@Num,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (Articles), (object) Articles),
        new OleDbParameter(nameof (ArticlesDescription), (object) ArticlesDescription),
        new OleDbParameter(nameof (Purity), (object) Purity),
        new OleDbParameter("Hr", (object) HiddenRemarks),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (Deduction), (object) Deduction),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (PureWeight), (object) PureWeight),
        new OleDbParameter("Num", (object) int.Parse(no)),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Today)
      }, ref strError);
      if (str == "Done")
        return;
      PawnManagementClass.InsertIntoException("form pledge.insertPledgeArticles", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in inserting into articles table       :" + str);
    }

    private void insertPledgeArticles(
      string BillNumber,
      string Articles,
      string ArticlesDescription,
      string HiddenRemarks,
      string no)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("insert into tblPledgeArticles(ShopCode,BillNumber,Articles,ArticlesDescription,Hr,Num,CreatedBy,CreatedOn) values(@ShopCode,@BillNumber,@Articles,@ArticlesDescription,@Hr,@Num,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (Articles), (object) Articles),
        new OleDbParameter(nameof (ArticlesDescription), (object) ArticlesDescription),
        new OleDbParameter("Hr", (object) HiddenRemarks),
        new OleDbParameter("Num", (object) int.Parse(no)),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Today)
      }, ref strError);
      if (!(str != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.insertPledgeArticles", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in inserting into articles table       :" + str);
    }

    private void savePledgeArticles()
    {
      try
      {
        if (FormMain.withIndividualWeight)
        {
          for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
            this.insertPledgeArticles(this.tbxBillNumber.Text, ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString(), ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString(), ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value.ToString(), double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString()), double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value.ToString()), double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value.ToString()), double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value.ToString()), double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value.ToString()), ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString());
        }
        else
        {
          for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
            this.insertPledgeArticles(this.tbxBillNumber.Text, ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString(), ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString(), ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value.ToString(), ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.savePledgeArticle", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void savePledge()
    {
      string str = "N";
      string strError = "";
      string my_querry = "insert into tblPledge(ShopCode,BillNumber,BillDate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,AmountInWords,Type,GrossWeight,Deduction,NetWeight,PureWeight,Amount,PresentValue,OldBillNumber,Reminder,temp1,InterestRateDisplaySymbol,Redeemed,PledgeCreatedBy,PledgeCreatedOn,temp5,ArticlesWithoutHr,ArticlesWithHr,Articles,ReleaseDate,BilledBy,Purpose,MonthlyIncome) values(@ShopCode,@BillNumber,@BillDate,@CustomerCode,@CustomerName,@DoorNumber,@Addr1,@Addr2,@Addr3,@City,@Pincode,@PhoneNumber,@AmountInWords,@Type,@GrossWeight,@Deduction,@NetWeight,@PureWeight,@Amount,@PresentValue,@OldBillNumber,@Reminder,@InterestRate,@InterestRateDisplaySymbol,@Redeemed,@PledgeCreatedBy,@PledgeCreatedOn,@temp5,@ArticlesWithoutHr,@ArticlesWithHr,@Articles,@ReleaseDate,@BilledBy,@Purpose,@MonthlyIncome)";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text));
      parameters.Add(new OleDbParameter("BillDate", (object) this.tbxBillDate.Text));
      parameters.Add(new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode.Text));
      parameters.Add(new OleDbParameter("CustomerName", (object) this.tbxCustomerName.Text));
      parameters.Add(new OleDbParameter("DoorNumber", (object) this.tbxNumber.Text));
      parameters.Add(new OleDbParameter("Addr1", (object) this.tbxAddress1.Text));
      parameters.Add(new OleDbParameter("Addr2", (object) this.tbxAddress2.Text));
      parameters.Add(new OleDbParameter("Addr3", (object) this.tbxAddress3.Text));
      parameters.Add(new OleDbParameter("City", (object) this.tbxCity.Text));
      parameters.Add(new OleDbParameter("Pincode", (object) this.tbxPincode.Text));
      parameters.Add(new OleDbParameter("PhoneNumber", (object) this.tbxPhoneNumber.Text));
      parameters.Add(new OleDbParameter("AmountInWords", (object) ConvertNumbersToWords.NumberToWords(int.Parse(this.tbxAmount.Text.Trim().ToString()))));
      parameters.Add(new OleDbParameter("Type", (object) this.cbType.Text.ToString()));
      parameters.Add(new OleDbParameter("GrossWeight", (object) this.tbxweight.Text));
      parameters.Add(new OleDbParameter("Deduction", (object) this.tbxDeductions.Text));
      parameters.Add(new OleDbParameter("NetWeight", (object) this.tbxNetWeight.Text));
      parameters.Add(new OleDbParameter("PureWeight", (object) this.tbxPureWeight.Text));
      parameters.Add(new OleDbParameter("Amount", (object) this.tbxAmount.Text));
      parameters.Add(new OleDbParameter("PresentValue", (object) this.tbxValue.Text));
      parameters.Add(new OleDbParameter("OldBillNumber", (object) this.tbxOldBillNumber.Text));
      parameters.Add(new OleDbParameter("Reminder", (object) this.tbxReminder.Text));
      parameters.Add(new OleDbParameter("InterestRate", (object) this.tbxInteresRate.Text));
      parameters.Add(new OleDbParameter("InterestRateDisplaySymbol", (object) this.symbolToPrintAsInterestRate));
      parameters.Add(new OleDbParameter("Redeemed", (object) str));
      parameters.Add(new OleDbParameter("PledgeCreatedBy", (object) FormMain.username));
      parameters.Add(new OleDbParameter("PledgeCreatedOn", (object) DateTime.Now.ToString()));
      parameters.Add(new OleDbParameter("temp5", (object) this.tbxTotalInterest.Text.Trim().ToString()));
      if (FormMain.withIndividualWeight)
      {
        parameters.Add(new OleDbParameter("ArticlesWithoutHr", (object) this.getPledgeArticlesCombinedWithouthHr()));
        parameters.Add(new OleDbParameter("ArticlesWithHr", (object) this.getPledgeArticlesCombinedWithHr()));
      }
      else
      {
        parameters.Add(new OleDbParameter("ArticlesWithoutHr", (object) this.getPledgeArticlesCombined()));
        parameters.Add(new OleDbParameter("ArticlesWithHr", (object) this.getPledgeArticlesCombined()));
      }
      parameters.Add(new OleDbParameter("Articles", (object) this.getPledgeArticlesCombined()));
      parameters.Add(new OleDbParameter("ReleaseDate", (object) this.tbxReleaseDate.Text));
      parameters.Add(new OleDbParameter("BilledBy", (object) FormMain.BillerName));
      parameters.Add(new OleDbParameter("Purpose", (object) this.tbxPurpose.Text));
      parameters.Add(new OleDbParameter("MonthlyIncome", (object) this.tbxIncome.Text));
      string text = SQLHelper.RunCommand(my_querry, parameters, ref strError);
      if (text == "Done")
        return;
      PawnManagementClass.InsertIntoException("form pledge.savepledge()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    private bool printerConnectedOrNot()
    {
      new ManagementScope("\\root\\cimv2").Connect();
      ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
      string str = "";
      using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          ManagementObject current = (ManagementObject) enumerator.Current;
          str = current["Name"].ToString().ToLower();
          return !current["WorkOffline"].ToString().ToLower().Equals("true");
        }
      }
      return false;
    }

    private void printPledge()
    {
      try
      {
        ReportDocument reportDocument = new ReportDocument();
        string defaultPrintFormat = FormPrintSettings.getDefaultPrintFormat();
        string filePath1 = "Reports\\PledgeBill\\" + defaultPrintFormat;
        ReportDocument pledgeReportDocument1 = FormDuplicateBill.getPledgeReportDocument(defaultPrintFormat, this.tbxBillNumber.Text.Trim().ToString(), this.cbShopCodes.Text.Trim(), filePath1);
        string formatCustomerCopy = FormPrintSettings.getDefaultPrintFormatCustomerCopy();
        string filePath2 = "Reports\\PledgeBill\\" + formatCustomerCopy;
        ReportDocument pledgeReportDocument2 = FormDuplicateBill.getPledgeReportDocument(formatCustomerCopy, this.tbxBillNumber.Text.Trim().ToString(), this.cbShopCodes.Text.Trim(), filePath2);
        switch (FormMain.strPrintOfficeCopy)
        {
          case "YES AFTER ASKING":
            if (DialogResult.Yes == MessageBox.Show("Print Office Copy ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
              pledgeReportDocument1.PrintToPrinter(1, false, 1, 1);
              break;
            }
            break;
          case "YES WITHOUT ASKING":
            pledgeReportDocument1.PrintToPrinter(1, false, 1, 1);
            break;
        }
        switch (FormMain.strPrintCustomerCopy)
        {
          case "YES AFTER ASKING":
            if (DialogResult.Yes != MessageBox.Show("Print Customer Copy ?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
              break;
            pledgeReportDocument2.PrintToPrinter(1, false, 1, 1);
            break;
          case "YES WITHOUT ASKING":
            pledgeReportDocument2.PrintToPrinter(1, false, 1, 1);
            break;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public static string getDefaultPrintFormatCustomerCopy()
    {
      string strError = "";
      string my_querry = "select * from tblprintSettings where PrintFormatsCustomerCopyDefaultValue = @PrintFormatsCustomerCopyDefaultValue";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("PrintFormatsCustomerCopyDefaultValue", (object) "Y"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["PrintFormatsCustomerCopy"].ToString();
      return "";
    }

    private DataTable getArticles(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeArticles where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form duplicateBill.getArticles()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form duplicateBill.getArticles()" + strError);
      }
      return dataTable2;
    }

    private void insertNewArticle(string value)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblArticles(Article) values(@newArticle)", new List<OleDbParameter>()
      {
        new OleDbParameter("newArticle", (object) value)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.insertNewArticle(string value)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("form pledge.insertNewArticle(string value) ..Error in adding new article");
    }

    private void getArticles()
    {
      try
      {
        string strError = "";
        this.tblA = SQLHelper.GetDataTable("select  distinct Article from tblArticles", ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getArticles", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Errorr in retrieving articles");
        }
        foreach (DataRow row in (InternalDataCollectionBase) this.tblA.Rows)
          this.lstArticles.Add(row["Article"].ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getArticles", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getInterest()
    {
      string strError = "";
      string my_querry = "select * from tblInterest where Type=@Type";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Type", (object) this.cbType.Text.ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getInterest", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching interest" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
              if (double.Parse(dataTable2.Rows[index]["FromAmount"].ToString()) < double.Parse(this.tbxAmount.Text.ToString()) && double.Parse(dataTable2.Rows[index]["ToAmount"].ToString()) >= double.Parse(this.tbxAmount.Text.ToString()))
              {
                this.tbxInteresRate.Text = dataTable2.Rows[index]["Interest"].ToString();
                this.tbxChit.Text = dataTable2.Rows[index]["Chit"].ToString();
                this.symbolToPrintAsInterestRate = dataTable2.Rows[index]["SymbolToDisplay"].ToString();
              }
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.getInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void getValueandAmount()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblGramRate where Type=@Type";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("Type", (object) this.cbType.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getValueandAmount", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching Value and amount" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          if (this.formType != "PLEDGE EDIT")
          {
            TextBox tbxValue = this.tbxValue;
            double num1 = double.Parse(this.tbxNetWeight.Text.Trim());
            int num2 = dataTable2.Rows[0].Field<int>("SaleRate");
            double num3 = double.Parse(num2.ToString());
            string str1 = (Math.Round(num1 * num3 / 100.0) * 100.0).ToString();
            tbxValue.Text = str1;
            if (FormPrintSettings.getAutoFillAmountt())
            {
              TextBox tbxAmount = this.tbxAmount;
              double num4 = double.Parse(this.tbxNetWeight.Text.Trim());
              num2 = dataTable2.Rows[0].Field<int>("PledgeRate");
              double num5 = double.Parse(num2.ToString());
              string str2 = (Math.Round(num4 * num5 / 100.0) * 100.0).ToString();
              tbxAmount.Text = str2;
            }
            else
              this.tbxAmount.Text = "0";
          }
        }
        else
        {
          this.tbxValue.Text = "0";
          this.tbxAmount.Text = "0";
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(ex.Message, ex.StackTrace.ToString(), FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPendingPledge(string CustomerCode)
    {
      string strError = "";
      string my_querry = "select ShopCode,BillNumber,OldBillNumber,BillDate,Amount,PresentValue,GrossWeight,Deduction,NetWeight,PureWeight,temp1 as InterestRate,ArticlesWithHr,BankCode,BankSerialNumber from tblPledge where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getPendingPledge", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            this.dgvPendingPledges.Show();
            this.dgvPendingPledges.Visible = true;
            this.dgvPendingPledges.DataSource = (object) dataTable2;
            this.dgvPendingPledges.Focus();
            this.dgvPendingPledges.Rows[0].Selected = true;
            this.dgvPendingPledges.BringToFront();
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.getPendinggPledge(string customercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void getCustomerPledgeDetails(string CustomerCode)
    {
      string strError = "";
      string newValue = "Articles as Articles";
      string my_querry = "select " + this.getQuery("PledgeScreenPendingPledge").Replace("articles", newValue) + " from tblPledge where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getCustomerpledgeDetails", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
      }
      else
      {
        if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          if (this.InterestSetting == "INTEREST SETTING")
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              row["InterestRate"] = (object) FormInterestDummy.getInterestRate(row["Type"].ToString(), row["Amount"].ToString());
          }
          this.dgvCustomerPledgeDetails.DataSource = (object) dataTable2;
          this.dgvCustomerPledgeDetails.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          this.dgvCustomerPledgeDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          this.dgvCustomerPledgeDetails.Visible = true;
          this.dgvCustomerPledgeDetails.BringToFront();
          if (this.formType != "PLEDGE EDIT")
            this.cbView.Text = "PENDING";
        }
        this.dgvCustomerPledgeDetails.DataSource = (object) dataTable2;
        this.dgvCustomerPledgeDetails.Visible = true;
        this.dgvCustomerPledgeDetails.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
          row.Cells["colselect"].Value = (object) true;
        this.dgvCustomerPledgeDetails.Columns["Presentvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["customercode"].Visible = false;
        this.dgvCustomerPledgeDetails.Columns["nameAndAddress"].Visible = false;
        if (this.dgvCustomerPledgeDetails != null && this.dgvCustomerPledgeDetails.Rows.Count > 0)
        {
          foreach (string columnName in OrderClass.getcolumnsToHide("PledgeScreenPendingPledge"))
          {
            if (this.dgvCustomerPledgeDetails.Columns.Contains(columnName))
              this.dgvCustomerPledgeDetails.Columns[columnName].Visible = false;
          }
        }
      }
    }

    public string getQuery(string strScreenType)
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) strScreenType)
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        return "BillNumber,BillDate,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight, articles,BankCode,BankSerialNumber,SHOPCODE,customerCode,customername as nameAndAddress,type,Redeemed,temp2 as Interest,temp3 as FinalInterest,temp4 as RedemptionAmount";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0 ? dataTable2.Rows[0]["ColumnOrder"].ToString() : "BillNumber,BillDate,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight, articles,BankCode,BankSerialNumber,SHOPCODE,customerCode,customername as nameAndAddress,type,Redeemed,temp2 as Interest,temp3 as FinalInterest,temp4 as RedemptionAmount";
    }

    private void getRedeemedPledges(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["PledgeScreen"] != null)
        str = articlesSettings.Rows[0]["PledgeScreen"].ToString() + " as Articles";
      string my_querry = "select BillNumber,BillDate,Amount,temp3 as FinalInterest,temp4 as RedemptionAmount,RedemptionDate,temp1 as InterestRate,PresentValue,GrossWeight,Deduction,NetWeight," + str + ",shopcode from tblPledge where CustomerCode =@CustomerCode and Redeemed ='Y' order by billdate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getRedeemedPledges", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
      }
      else
      {
        if (dataTable2 == null || dataTable2.Rows.Count <= 0)
          ;
        this.dgvRedeemedPledges.DataSource = (object) dataTable2;
        this.dgvRedeemedPledges.Visible = true;
      }
    }

    private void getAuctionedPledges(string CustomerCode)
    {
      try
      {
        string strError = "";
        string str = "";
        DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
        if (articlesSettings.Rows[0]["PledgeScreen"] != null)
          str = articlesSettings.Rows[0]["PledgeScreen"].ToString() + " as Articles";
        string my_querry = "select BillNumber,BillDate,Amount,AuctionAmount,AuctionDate,kdisnumber,purchasedby,AuctionedBy,temp1 as InterestRate,PresentValue,GrossWeight,Deduction,NetWeight," + str + ",shopcode from tblPledge where CustomerCode =@CustomerCode and Redeemed ='A' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getAuctionPledges", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
        }
        else
        {
          if (dataTable2 == null || dataTable2.Rows.Count <= 0)
            ;
          this.dgvAuctionedPledges.DataSource = (object) dataTable2;
          this.dgvAuctionedPledges.Visible = true;
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void getAllPledge(string CustomerCode)
    {
      try
      {
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery("PledgeScreenAll").Replace("articles", newValue) + " from tblPledge where CustomerCode =@CustomerCode  order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
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
          dataTable2.Columns.Add("PaymentReceived", typeof (double));
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
              if (row["Redeemed"] != null && row["Redeemed"].ToString() == "N")
              {
                DateTime.Parse(row["BillDate"].ToString());
                int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Today);
                row["NoOfMonths"] = (object) numberOfMonths;
                int n = numberOfMonths - 1;
                if (n != -1)
                  row["Interest"] = n <= 11 ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (!this.calculateCompoundInterest ? (!FormMain.IncludeNoticeChargeInPledgeScreen ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (object) (Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) + double.Parse(FormMain.NoticeChargeInPledgeScreen))) : (!FormMain.IncludeNoticeChargeInPledgeScreen ? (object) PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString())).ToString() : (object) (PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString())) + double.Parse(FormMain.NoticeChargeInPledgeScreen)).ToString()));
                row["PaymentReceived"] = (object) PawnManagementClass.getPaymentSum(row["BillNumber"].ToString(), row["ShopCode"].ToString());
              }
            }
          }
          this.calculateCompoundInterest = false;
        }
        this.dgvAllPledge.DataSource = (object) dataTable2;
      }
      catch (Exception ex)
      {
      }
    }

    private void getTotalPendingPledges()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        for (int index = 0; index < this.dgvCustomerPledgeDetails.RowCount; ++index)
        {
          DateTime.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["BillDate"].Value.ToString());
          int num = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["BillDate"].Value.ToString()), DateTime.Today) - 1;
          if (num != -1)
          {
            this.dgvCustomerPledgeDetails.Rows[index].Cells["Interest"].Value = (object) Math.Round(double.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["Amount"].Value.ToString()) * double.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["InterestRate"].Value.ToString()) * (double) num / 1200.0);
            if (num > 9)
              this.dgvCustomerPledgeDetails.Rows[index].DefaultCellStyle.ForeColor = Color.Blue;
            if (num > 11)
              this.dgvCustomerPledgeDetails.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
          }
          this.totalAmount += double.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["Amount"].Value.ToString());
          this.totalInterest += double.Parse(this.dgvCustomerPledgeDetails.Rows[index].Cells["Interest"].Value.ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getTotalPendingPledges()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getTotalRedeemedPledges()
    {
      try
      {
        this.totalAmount = this.totalInterest = this.totalRedemptionAmount = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvRedeemedPledges.Rows)
        {
          this.totalAmount += double.Parse(row.Cells["amount"].Value.ToString());
          this.totalInterest += double.Parse(row.Cells["FinalInterest"].Value.ToString());
          this.totalRedemptionAmount += double.Parse(row.Cells["RedemptionAmount"].Value.ToString());
        }
        this.tbxTotalAmount.Text = this.totalAmount.ToString();
        this.tbxtotalPendingInterest.Text = this.totalInterest.ToString();
        this.tbxTotalAmountPlusInterest.Text = this.totalRedemptionAmount.ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getTotalRedeemedPledges", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getTotalAuctionedPledges()
    {
    }

    private void getArticlesDescription()
    {
      try
      {
        string strError = "";
        string my_querry = "Select ArticlesDescription from tblArticlesDescription";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("forrm pledge.getArtticlesDescription", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving Artciles description fromt the database" + strError);
        }
        else
        {
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
            this.articlesDescription.Add(dataTable2.Rows[index].Field<string>("ArticlesDescription"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.getArtcilesDesctiption", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in gettign the articles description" + ex.Message);
        throw;
      }
    }

    private void PrintReport(string reportPath, DataTable dt)
    {
    }

    private void dataGridViewEx2_EditingControlShowing(
      object sender,
      DataGridViewEditingControlShowingEventArgs e)
    {
      if (!(e.Control is DataGridViewTextBoxEditingControl))
        return;
      if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colArticles")
      {
        ((TextBox) e.Control).CharacterCasing = CharacterCasing.Upper;
        ((TextBox) e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        ((TextBox) e.Control).AutoCompleteSource = AutoCompleteSource.CustomSource;
        ((TextBox) e.Control).AutoCompleteCustomSource.Clear();
        ((TextBox) e.Control).AutoCompleteCustomSource.AddRange(this.lstArticles.ToArray());
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
        e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
        e.Control.Validating += new CancelEventHandler(this.colArticles_Validating);
      }
      else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colNo")
      {
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
        e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
        ((TextBox) e.Control).CharacterCasing = CharacterCasing.Upper;
        e.Control.Enter += new EventHandler(this.no_Enter);
        e.Control.KeyDown += new KeyEventHandler(this.dgvTextBox_KeyDown);
        e.Control.KeyPress += new KeyPressEventHandler(this.no_KeyPress);
        e.Control.Validating += new CancelEventHandler(this.colNo_Validating);
      }
      else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colArticlesDetails")
      {
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
        e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
        ((TextBox) e.Control).CharacterCasing = CharacterCasing.Upper;
        ((TextBox) e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        ((TextBox) e.Control).AutoCompleteSource = AutoCompleteSource.CustomSource;
        ((TextBox) e.Control).AutoCompleteCustomSource.AddRange(this.articlesDescription.ToArray());
        ((TextBox) e.Control).AutoCompleteCustomSource.Clear();
        ((TextBox) e.Control).AutoCompleteCustomSource.AddRange(this.articlesDescription.ToArray());
        e.Control.Validating += new CancelEventHandler(this.colArticlesDetails_Validating);
      }
      else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colHiddenRemarks")
      {
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
        e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.Enter -= new EventHandler(this.no_Enter);
        e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
        e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
        ((TextBox) e.Control).CharacterCasing = CharacterCasing.Upper;
        ((TextBox) e.Control).AutoCompleteMode = AutoCompleteMode.None;
        e.Control.Validating += new CancelEventHandler(this.colHiddenREmarks_Validating);
      }
      if (FormMain.withIndividualWeight)
      {
        if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colPurity")
        {
          e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
          e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
          e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
          e.Control.KeyPress += new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating += new CancelEventHandler(this.colPurity_Validating);
        }
        else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colGrossWeight")
        {
          e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
          e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
          e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
          e.Control.KeyPress += new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.Validating += new CancelEventHandler(this.colGrossWeight_Validating);
        }
        else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colDeduction")
        {
          e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
          e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
          e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
          e.Control.KeyPress += new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.Validating += new CancelEventHandler(this.colDeduction_Validating);
          e.Control.GotFocus += new EventHandler(this.colDeduction_Enter);
        }
        else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colNetWeight")
        {
          e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
          e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
          e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
          e.Control.KeyPress += new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.GotFocus += new EventHandler(this.colNetWeight_Enter);
          e.Control.Validating += new CancelEventHandler(this.colNetWeightPureWEight_Validating);
        }
        else if (((DataGridView) this.dgvArticles).CurrentCell.OwningColumn.Name == "colPureWeight")
        {
          e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.no_KeyPress);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colNetWeightPureWEight_Validating);
          e.Control.KeyDown -= new KeyEventHandler(this.dgvTextBox_KeyDown);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.GotFocus -= new EventHandler(this.colNetWeight_Enter);
          e.Control.GotFocus -= new EventHandler(this.colPuresWeight_Enter);
          e.Control.KeyPress -= new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.Validating -= new CancelEventHandler(this.colDeduction_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPurity_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
          e.Control.Enter -= new EventHandler(this.no_Enter);
          e.Control.Validating -= new CancelEventHandler(this.colArticles_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colNo_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colArticlesDetails_Validating);
          e.Control.Validating -= new CancelEventHandler(this.colHiddenREmarks_Validating);
          e.Control.KeyPress += new KeyPressEventHandler(this.colNetWeight_KeyPress);
          e.Control.GotFocus += new EventHandler(this.colPuresWeight_Enter);
          e.Control.Validating += new CancelEventHandler(this.colPureWeight_Validating);
        }
      }
    }

    private void colPuresWeight_Enter(object sender, EventArgs e) => (sender as TextBox).Text = (double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[3].Value.ToString()) * double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[6].Value.ToString()) / 100.0).ToString();

    private void colDeduction_Enter(object sender, EventArgs e)
    {
      try
      {
        if (double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[4].Value.ToString()) > 0.0)
          return;
        ((DataGridView) this.dgvArticles).CurrentCell = ((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells["colGrossWeight"];
      }
      catch (Exception ex)
      {
      }
    }

    private void no_Enter(object sender, EventArgs e) => (sender as TextBox).Text = (sender as TextBox).Text != "" ? (sender as TextBox).Text : "1";

    private void FormPledgePledge_Validating(object sender, CancelEventArgs e) => ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;

    private void colHiddenREmarks_Validating(object sender, CancelEventArgs e) => ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;

    private void colArticlesDetails_Validating(object sender, CancelEventArgs e) => ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;

    private void colNo_Validating(object sender, CancelEventArgs e) => ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;

    private void colNetWeight_Enter(object sender, EventArgs e) => (sender as TextBox).Text = (double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[4].Value.ToString()) - double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[5].Value.ToString())).ToString();

    private void colArticles_Validating(object sender, CancelEventArgs e)
    {
      if (((DataGridView) this.dgvArticles).CurrentCell.Value != null && ((DataGridView) this.dgvArticles).CurrentCell.Value.ToString() != "" && !ArticlesClass.checkIfArticleExists(((DataGridView) this.dgvArticles).CurrentCell.Value.ToString()))
      {
        if (DialogResult.Yes == MessageBox.Show("New ITEM", "Are you sure?", MessageBoxButtons.YesNo))
        {
          this.insertNewArticle(((DataGridView) this.dgvArticles).CurrentCell.Value.ToString().Trim());
          this.lstArticles.Add(((DataGridView) this.dgvArticles).CurrentCell.Value.ToString().Trim());
        }
        else
          SendKeys.Send("{LEFT}");
      }
      if (((DataGridView) this.dgvArticles).CurrentCell.Value != null && ((DataGridView) this.dgvArticles).CurrentCell.Value.ToString() != "" && ((DataGridView) this.dgvArticles).CurrentCell.Value.ToString().Contains("silver") | ((DataGridView) this.dgvArticles).CurrentCell.Value.ToString().Contains("SILVER"))
        this.cbType.Text = "SILVER";
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;
    }

    private void colPureWeight_Validating(object sender, CancelEventArgs e)
    {
      string text = (sender as TextBox).Text;
      if (text == "")
        text = (double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[3].Value.ToString()) * double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[6].Value.ToString()) / 100.0).ToString();
      ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) this.appendZeroes(text);
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;
    }

    private void colPurity_Validating(object sender, CancelEventArgs e)
    {
      if ((sender as TextBox).Text == "")
        ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) this.getDefaultPurity(this.cbType.Text);
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;
    }

    private void colGrossWeight_Validating(object sender, CancelEventArgs e)
    {
      if ((sender as TextBox).Text.Contains<char>('.'))
      {
        int num = (sender as TextBox).Text.IndexOf('.');
        if ((sender as TextBox).Text.Length - num == 1)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "000");
        if ((sender as TextBox).Text.Length - num == 2)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "00");
        if ((sender as TextBox).Text.Length - num == 3)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "0");
      }
      else
        ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + ".000");
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;
    }

    private void colDeduction_Validating(object sender, CancelEventArgs e)
    {
      if ((sender as TextBox).Text.Contains<char>('.'))
      {
        int num = (sender as TextBox).Text.IndexOf('.');
        if ((sender as TextBox).Text.Length - num == 1)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "000");
        if ((sender as TextBox).Text.Length - num == 2)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "00");
        if ((sender as TextBox).Text.Length - num == 3)
          ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + "0");
      }
      else
        ((DataGridView) this.dgvArticles).CurrentCell.Value = (object) ((sender as TextBox).Text + ".000");
      if (double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[4].Value.ToString()) <= double.Parse(((DataGridView) this.dgvArticles).Rows[((DataGridView) this.dgvArticles).CurrentCell.RowIndex].Cells[5].Value.ToString()))
        SendKeys.Send("+{TAB}");
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;
    }

    private void colNetWeight_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void dgvArticles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
    }

    private void colGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void colNetWeightPureWEight_Validating(object sender, CancelEventArgs e) => ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.AliceBlue;

    private string appendZeroes(string str)
    {
      if (str.Contains<char>('.'))
      {
        int num = str.IndexOf('.');
        if (str.Length - num == 1)
          str += "000";
        if (str.Length - num == 2)
          str += "00";
        if (str.Length - num == 3)
          str += "0";
      }
      else
        str += ".000";
      return str;
    }

    private void colPurity_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void dgvTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((DataGridView) this.dgvArticles).Rows.Add();
    }

    private string getDefaultPurity(string Type)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblGramRate where Type=@Type";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (Type), (object) Type));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getDefaultPurity", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching Value and amount" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          return dataTable2.Rows[0]["DefaultPurity"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(ex.Message, ex.StackTrace.ToString(), FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "0";
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

    private void tbxCustomerName_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxCustomerName.Text != ""))
        return;
      if (FormMain.boolPledgeScreenSimple)
        this.getCustomerDetailsSimple();
      else
        this.getCustomerDetails();
    }

    private void tbxCustomerName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down)
      {
        if (this.dgvCustomerDetails == null || this.dgvCustomerDetails.Rows.Count <= 0)
          return;
        this.dgvCustomerDetails.Select();
        this.dgvCustomerDetails.Rows[0].Selected = true;
        this.dgvCustomerDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      }
      else if (e.KeyCode != Keys.Return)
        ;
    }

    private void getFingerPrint()
    {
      if (!FormMain.UseFingerPrint)
        return;
      if (!double.TryParse(CustomersClass.getMaxId().ToString(), NumberStyles.Integer, (IFormatProvider) CultureInfo.CurrentCulture, out double _))
      {
        int num1 = (int) MessageBox.Show("Please enter number for user id.");
      }
      else
      {
        byte[] numArray = new byte[FormMain.m_ImageWidth * FormMain.m_ImageHeight];
        int imageEx = FormMain.m_FPM.GetImageEx(numArray, 5000, this.pbFingerPrint.Handle.ToInt32(), 50);
        if (imageEx != 0)
        {
          int num2 = (int) MessageBox.Show("Image Capture Error: " + Convert.ToString(imageEx));
        }
        else
        {
          this.minData = new byte[400];
          int template = FormMain.m_FPM.CreateTemplate(numArray, this.minData);
          if (template != 0)
          {
            int num3 = (int) MessageBox.Show("Get Minutiae Error: " + Convert.ToString(template));
          }
          else
          {
            this.idInfo = new SS_IDInfo();
            this.idInfo.ID = Convert.ToInt32(CustomersClass.getMaxId());
            this.idInfo.FingerNumber = (byte) 1;
            this.idInfo.SampleNumber = Convert.ToByte(1);
            SS_IDInfo basedOnFingerPrint = FingerPrintClass.getCustomerIdBasedOnFingerPrint(this.minData);
            if (basedOnFingerPrint != null)
            {
              string customerCode = CustomersClass.getCustomerCode(basedOnFingerPrint.ID.ToString());
              if (customerCode != "")
                this.getCustomerDetailssssss(customerCode);
              else if (DialogResult.Yes == MessageBox.Show("New Customer.   Add?", "Add New Customer", MessageBoxButtons.YesNo))
              {
                FormAddCustomer formAddCustomer = new FormAddCustomer();
                if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
                {
                  if (FormMain.AutoOnfingerPrint)
                    FormMain.m_FPM.EnableAutoOnEvent(true, (int) formAddCustomer.Handle);
                  else
                    FormMain.m_FPM.EnableAutoOnEvent(false, 0);
                }
                int num4 = (int) formAddCustomer.ShowDialog();
                if (FormAddCustomer.newCustomerCodeAdde != "")
                {
                  this.getCustomerDetailssssss(FormAddCustomer.newCustomerCodeAdde);
                }
                else
                {
                  int num5 = (int) MessageBox.Show("Error in adding customer... Try again");
                }
                if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
                {
                  if (FormMain.AutoOnfingerPrint)
                    FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
                  else
                    FormMain.m_FPM.EnableAutoOnEvent(false, 0);
                }
              }
              else if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
              {
                if (FormMain.AutoOnfingerPrint)
                  FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
                else
                  FormMain.m_FPM.EnableAutoOnEvent(false, 0);
              }
            }
            else
            {
              int num6 = (int) MessageBox.Show("Try again");
            }
          }
        }
      }
    }

    private void colArticles_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsLetter(e.KeyChar))
        return;
      e.KeyChar = char.ToUpper(e.KeyChar);
    }

    private void selectNextControl(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void no_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxCustomerCode_TextChanged(object sender, EventArgs e)
    {
      this.tbxweight.ReadOnly = false;
      ((DataGridView) this.dgvArticles).ReadOnly = false;
      this.tbxDeductions.ReadOnly = false;
      this.tbxNetWeight.ReadOnly = false;
      this.tbxInteresRate.ReadOnly = false;
      this.tbxReminder.ReadOnly = false;
      this.tbxValue.ReadOnly = false;
      this.tbxAmount.ReadOnly = false;
      this.tbxOldBillNumber.ReadOnly = false;
      this.tbxPureWeight.ReadOnly = false;
    }

    private void dgvArticles_Enter(object sender, EventArgs e)
    {
      this.count = 0;
      if (((DataGridView) this.dgvArticles).Rows.Count < 1)
        ((DataGridView) this.dgvArticles).Rows.Add();
      ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.GreenYellow;
    }

    private void tbxweight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '.')
        return;
      e.Handled = true;
    }

    private void tbxDeductions_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void dgvCustomerDetails_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvCustomerDetails.Rows[0].Selected)
          this.tbxCustomerName.Select();
        if (e.KeyCode != Keys.Return)
          return;
        int index = 0;
        if (this.dgvCustomerDetails.CurrentRow != null)
          index = this.dgvCustomerDetails.CurrentRow.Index;
        this.getCustomerDetailssssss(this.dgvCustomerDetails.Rows[index].Cells["CID"].Value.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getCustomerDetailssssss(string customerCode)
    {
      string customerCode1 = customerCode;
      this.getPicture(customerCode1);
      this.getCustomerDetails(customerCode1);
      if (FormMain.memberType != "ak" && this.formType != "PLEDGE EDIT")
      {
        if (FormMain.strPledgeWithoutBackgroundWorker == "Y")
          this.getPendingDetails();
        else
          this.backgroundWorker1.RunWorkerAsync((object) new object[1]
          {
            (object) this.tbxCustomerCode.Text
          });
      }
      this.cbType.Focus();
      this.dgvCustomerDetails.Visible = false;
      this.pbFingerPrint.BringToFront();
    }

    private void getPendingDetails()
    {
      try
      {
        string text = this.tbxCustomerCode.Text;
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery("PledgeScreenPendingPledge").Replace("articles", newValue) + " from tblPledge where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) text));
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
          dataTable2.Columns.Add("PaymentReceived", typeof (double));
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
              double num;
              if (n != -1)
              {
                if (n > 11)
                {
                  if (this.calculateCompoundInterest)
                  {
                    if (FormMain.IncludeNoticeChargeInPledgeScreen)
                    {
                      DataRow dataRow = row;
                      num = PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString())) + double.Parse(FormMain.NoticeChargeInPledgeScreen);
                      string str = num.ToString();
                      dataRow["Interest"] = (object) str;
                    }
                    else
                    {
                      DataRow dataRow = row;
                      num = PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString()));
                      string str = num.ToString();
                      dataRow["Interest"] = (object) str;
                    }
                  }
                  else
                    row["Interest"] = !FormMain.IncludeNoticeChargeInPledgeScreen ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (object) (Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) + double.Parse(FormMain.NoticeChargeInPledgeScreen));
                }
                else
                  row["Interest"] = (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0);
              }
              row["PaymentReceived"] = (object) PawnManagementClass.getPaymentSum(row["BillNumber"].ToString(), row["ShopCode"].ToString());
            }
          }
          this.calculateCompoundInterest = false;
        }
        this.dgvCustomerPledgeDetails.DataSource = (object) dataTable2;
        this.dgvCustomerPledgeDetails.Visible = true;
        this.dgvCustomerPledgeDetails.Columns["Interest"].DisplayIndex = 1;
        this.dgvCustomerPledgeDetails.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvCustomerPledgeDetails.Columns["PaymentReceived"].DisplayIndex = 3;
        this.dgvCustomerPledgeDetails.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
        {
          row.Cells["colSelect"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvCustomerPledgeDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        if (this.dgvCustomerPledgeDetails != null && this.dgvCustomerPledgeDetails.Rows.Count > 0)
        {
          foreach (string columnName in OrderClass.getcolumnsToHide("PledgeScreenPendingPledge"))
          {
            if (this.dgvCustomerPledgeDetails.Columns.Contains(columnName))
              this.dgvCustomerPledgeDetails.Columns[columnName].Visible = false;
          }
        }
        this.getPendingPledgesCompleteTotal();
      }
      catch (Exception ex)
      {
      }
    }

    private void dgvCustomerDetails_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        this.escapeCount = 0;
        this.tbxCustomerName.Select();
      }
      if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
        return;
      this.getPicture(this.dgvCustomerDetails.Rows[this.dgvCustomerDetails.CurrentRow.Index].Cells["CID"].Value.ToString());
    }

    private bool CheckForm(Form form)
    {
      form = Application.OpenForms[form.Text];
      return form != null;
    }

    private void cbType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxOldBillNumber.Select();
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        ++this.comboboxEnterCount;
        if (this.comboboxEnterCount == 2)
          this.tbxReminder.Focus();
      }
      if (e.KeyCode != Keys.Down)
        return;
      this.getPendingPledge(this.tbxCustomerCode.Text.Trim().ToString());
    }

    private void textBox1_Enter(object sender, EventArgs e) => this.comboboxEnterCount = 0;

    private void tbxweight_KeyPress_1(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxInteresRate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxValue_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxNetWeight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxNetWeight_Enter(object sender, EventArgs e)
    {
      try
      {
        if (double.Parse(this.tbxweight.Text.ToString()) - double.Parse(this.tbxDeductions.Text.ToString()) > 0.0)
          this.tbxNetWeight.Text = Math.Round(double.Parse(this.tbxweight.Text.ToString()) - double.Parse(this.tbxDeductions.Text.ToString()), 3).ToString();
        else
          this.tbxDeductions.Focus();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.tbxNetweight_enter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxInteresRate_Enter(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxAmount.Text != null && this.tbxAmount.Text != "")
        {
          if (FormMain.memberType != "ak")
          {
            this.getInterest();
          }
          else
          {
            DataTable shopDetails = PawnManagementClass.getShopDetails(this.cbShopCodes.Text);
            if (shopDetails != null && shopDetails.Rows.Count > 0)
            {
              this.tbxInteresRate.Text = shopDetails.Rows[0].Field<string>("RateOfInterest").ToString();
            }
            else
            {
              int num = (int) MessageBox.Show("Interest Rate Setting Error...Kindly set it right in ShopDetails->RateOfInterst");
            }
          }
        }
        else
          this.tbxAmount.Focus();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.tbxInterestrate_enter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxValue_Enter(object sender, EventArgs e) => this.getValueandAmount();

    private void tbxAmount_Enter(object sender, EventArgs e)
    {
      if (!(this.tbxValue.Text == null | this.tbxValue.Text == ""))
        return;
      this.tbxValue.Focus();
    }

    private void dgvPendingPledges_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Escape)
        {
          this.escapeCount = 0;
          this.dgvPendingPledges.Visible = false;
          this.tbxOldBillNumber.Select();
        }
        if (e.KeyCode == Keys.Up && this.dgvPendingPledges.Rows[0].Selected)
          this.tbxOldBillNumber.Select();
        if (e.KeyCode != Keys.Return)
          return;
        int rowIndex = this.dgvPendingPledges.CurrentCell.RowIndex;
        this.tbxweight.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["GrossWeight"].Value.ToString();
        this.tbxDeductions.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["Deduction"].Value.ToString();
        this.tbxNetWeight.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["NetWeight"].Value.ToString();
        this.tbxPureWeight.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["PureWeight"].Value.ToString();
        this.tbxValue.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["PresentValue"].Value.ToString();
        this.tbxAmount.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["Amount"].Value.ToString();
        if (FormPrintSettings.boolMaintainOldestBillNumber())
        {
          if (this.dgvPendingPledges.Rows[rowIndex].Cells["oldbillnumber"].Value != null && this.dgvPendingPledges.Rows[rowIndex].Cells["OldBillNumber"].Value.ToString() != "")
            this.tbxOldBillNumber.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["OldBillNumber"].Value.ToString();
          else
            this.tbxOldBillNumber.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["BillNumber"].Value.ToString() + "[" + this.dgvPendingPledges.Rows[rowIndex].Cells["Amount"].Value.ToString() + "]";
        }
        else
          this.tbxOldBillNumber.Text = this.dgvPendingPledges.Rows[rowIndex].Cells["BillNumber"].Value.ToString() + "[" + this.dgvPendingPledges.Rows[rowIndex].Cells["Amount"].Value.ToString() + "]";
        string strError = "";
        string my_querry = "Select * from tblPledgeArticles where BillNumber = @BillNumber  and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.dgvPendingPledges.Rows[rowIndex].Cells["BillNumber"].Value.ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.dgvPendingPledges.Rows[rowIndex].Cells["ShopCode"].Value.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        DateTime dateTime;
        if (strError != "")
        {
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          dateTime = DateTime.Now;
          string CreatedOn = dateTime.ToString();
          PawnManagementClass.InsertIntoException("form pledge.", MessageAnDStackTrace, username, CreatedOn);
          int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          ((DataGridView) this.dgvArticles).Rows.Clear();
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
          {
            ((DataGridView) this.dgvArticles).Rows.Add();
            ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value = (object) dataTable2.Rows[index]["Articles"].ToString();
            ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value = (object) dataTable2.Rows[index]["ArticlesDescription"].ToString();
            ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value = (object) dataTable2.Rows[index]["Hr"].ToString();
            if (FormMain.withIndividualWeight)
            {
              ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value = (object) dataTable2.Rows[index]["Purity"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value = (object) dataTable2.Rows[index]["GrossWeight"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value = (object) dataTable2.Rows[index]["Deduction"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value = (object) dataTable2.Rows[index]["NetWeight"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value = (object) dataTable2.Rows[index]["PureWeight"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value = (object) dataTable2.Rows[index]["Num"].ToString();
            }
            else
              ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value = (object) dataTable2.Rows[index]["Num"].ToString();
          }
        }
        this.dgvPendingPledges.Visible = false;
        TextBox tbxReleaseDate = this.tbxReleaseDate;
        dateTime = DateTime.Parse(this.tbxBillDate.Text);
        dateTime = dateTime.AddYears(1);
        string str = dateTime.ToString("dd/MM/yyyy");
        tbxReleaseDate.Text = str;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvPendingpledges_keydown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (((DataGridView) this.dgvArticles).CurrentCell.RowIndex <= 0)
        return;
      ((DataGridView) this.dgvArticles).Rows.Remove(((DataGridView) this.dgvArticles).CurrentRow);
    }

    private void dgvCustomerPledgeDetails_DataSourceChanged(object sender, EventArgs e)
    {
    }

    private void dgvCustomerPledgeDetails_Enter(object sender, EventArgs e) => this.dgvCustomerPledgeDetails.Rows[0].Selected = true;

    private void dgvCustomerPledgeDetails_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void cbType_Enter(object sender, EventArgs e)
    {
      this.cbType.Select(this.cbType.Text.Length, 0);
      this.cbType.BackColor = Color.Black;
      this.cbType.ForeColor = Color.White;
    }

    private void tbxChit_Leave(object sender, EventArgs e)
    {
      if (this.tbxChit.Text == "")
        this.tbxChit.Text = "0";
      double num;
      if (FormPrintSettings.boolReduceFirstMonthInterest())
      {
        TextBox tbxTotalInterest = this.tbxTotalInterest;
        num = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * double.Parse(this.tbxInteresRate.Text.Trim().ToString()) / 1200.0 + double.Parse(this.tbxChit.Text.Trim().ToString()), 0);
        string str = num.ToString();
        tbxTotalInterest.Text = str;
      }
      else
        this.tbxTotalInterest.Text = "0";
      TextBox tbxPay = this.tbxPay;
      num = double.Parse(this.tbxAmount.Text.Trim().ToString()) - double.Parse(this.tbxTotalInterest.Text.Trim().ToString());
      string str1 = num.ToString();
      tbxPay.Text = str1;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private bool checkIfArticlesTableIsNull()
    {
      if (((DataGridView) this.dgvArticles).Rows.Count <= 0)
        return false;
      int index1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) ((DataGridView) this.dgvArticles).Rows)
      {
        for (int index2 = 0; index2 < ((DataGridView) this.dgvArticles).Columns.Count; ++index2)
        {
          if (!(index2 == 1 | index2 == 2) && ((row.Cells[index2].Value == null ? 1 : 0) | (row.Cells[index2].Value == null ? 0 : (row.Cells[index2].Value.ToString() == "" ? 1 : 0))) != 0)
          {
            ((DataGridView) this.dgvArticles).CurrentCell = ((DataGridView) this.dgvArticles).Rows[index1].Cells[index2];
            ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;
            return false;
          }
        }
        ++index1;
      }
      return true;
    }

    private void checkIfArticlesTableIsNull1()
    {
      if (((DataGridView) this.dgvArticles).Rows.Count <= 0)
        return;
      int index1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) ((DataGridView) this.dgvArticles).Rows)
      {
        for (int index2 = 0; index2 < ((DataGridView) this.dgvArticles).Columns.Count; ++index2)
        {
          if (!(index2 == 1 | index2 == 2) && row.Cells[index2].Value == null)
          {
            ((DataGridView) this.dgvArticles).CurrentCell = ((DataGridView) this.dgvArticles).Rows[index1].Cells[index2];
            ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;
            return;
          }
        }
        ++index1;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Transition.run((object) this.btnSave, "BackColor", (object) Color.Pink, (ITransitionType) new TransitionType_Flash(2, 300));
      TimeSpan timeSpan;
      if (this.formType == "NEW PLEDGE" | this.formType == "OLD PLEDGE")
      {
        try
        {
          if (this.checkIfAllEntriesEntered())
          {
            if (this.dgvArticles != null && ((DataGridView) this.dgvArticles).Rows.Count > 0)
            {
              if (!this.checkIfArticlesTableIsNull())
              {
                ((Control) this.dgvArticles).Focus();
              }
              else
              {
                timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(FormMain.licenceValidTill);
                if (timeSpan.TotalDays < 0.0)
                {
                  this.finishedentry();
                  this.defaultCustomerCode = "";
                }
                else
                {
                  int num = (int) MessageBox.Show("Licence expired....valid till :" + FormMain.licenceValidTill.ToString("dd/MM/yyyy"));
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.button2_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      if (!(this.formType == "PLEDGE EDIT"))
        return;
      try
      {
        if (this.checkIfAllEntriesEntered() && this.dgvArticles != null && ((DataGridView) this.dgvArticles).Rows.Count > 0)
        {
          if (!this.checkIfArticlesTableIsNull())
          {
            int num = (int) MessageBox.Show("Enter articles");
            ((Control) this.dgvArticles).Focus();
          }
          else
          {
            timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(FormMain.licenceValidTill);
            if (timeSpan.TotalDays < 0.0)
            {
              this.finishedEntryOnEditing();
            }
            else
            {
              int num = (int) MessageBox.Show("Licence expired....valid till :" + FormMain.licenceValidTill.ToString("dd/MM/yyyy"));
            }
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.button2_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void finishedEntryOnEditing()
    {
      try
      {
        if (DialogResult.Yes != MessageBox.Show("save?", "are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
          return;
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text);
        if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
        {
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
          {
            this.newValues = "New values are \n customerCode = " + this.tbxCustomerCode.Text.Trim().ToString() + "\ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nAddress1 = " + this.tbxAddress1.Text.Trim().ToString() + "\nAddress2 = " + this.tbxAddress2.Text.Trim().ToString() + "\nWeight = " + this.tbxweight.Text.Trim().ToString() + "\ndeductions = " + this.tbxDeductions.Text.Trim().ToString() + "\nnetweight = " + this.tbxNetWeight.Text.Trim().ToString() + "\nPureweight = " + this.tbxPureWeight.Text.Trim().ToString() + "\nvalue = " + this.tbxValue.Text.Trim().ToString() + "\nAmount = " + this.tbxAmount.Text.Trim().ToString() + "\nBillDate = " + this.tbxBillDate.Text.Trim().ToString() + "\nInterestRate = " + this.tbxInteresRate.Text.Trim().ToString() + "\nArticles are \n";
            this.updatePledge();
            this.updatePledgeArticles();
            this.UpdateTableVouchers();
            PawnManagementClass.InsertIntoHistory("PLEDGE EDIT", "Pledge Bill Number" + this.tbxBillNumber.Text.Trim().ToString() + " edited", this.oldValues + this.oldValuesArticles, this.newValues + this.newValuesArticles, FormMain.username, DateTime.Now.ToString());
            this.Close();
          }
          else if (this.tbxAmount.Text == this.pledgeAmountForEdit)
          {
            this.newValues = "New values are \n customerCode = " + this.tbxCustomerCode.Text.Trim().ToString() + "\ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nAddress1 = " + this.tbxAddress1.Text.Trim().ToString() + "\nAddress2 = " + this.tbxAddress2.Text.Trim().ToString() + "\nWeight = " + this.tbxweight.Text.Trim().ToString() + "\ndeductions = " + this.tbxDeductions.Text.Trim().ToString() + "\nnetweight = " + this.tbxNetWeight.Text.Trim().ToString() + "\nPureweight = " + this.tbxPureWeight.Text.Trim().ToString() + "\nvalue = " + this.tbxValue.Text.Trim().ToString() + "\nAmount = " + this.tbxAmount.Text.Trim().ToString() + "\nBillDate = " + this.tbxBillDate.Text.Trim().ToString() + "\nInterestRate = " + this.tbxInteresRate.Text.Trim().ToString() + "\nArticles are \n";
            this.updatePledge();
            this.updatePledgeArticles();
            PawnManagementClass.InsertIntoHistory("PLEDGE EDIT", "Pledge Bill Number" + this.tbxBillNumber.Text.Trim().ToString() + " edited", this.oldValues + this.oldValuesArticles, this.newValues + this.newValuesArticles, FormMain.username, DateTime.Now.ToString());
            this.Close();
          }
          else
          {
            this.tbxAmount.Select();
            int num = (int) MessageBox.Show("Rokad finished for this date... Changes cannot be made to AMOUNT");
          }
        }
        else
        {
          this.newValues = "New values are \n customerCode = " + this.tbxCustomerCode.Text.Trim().ToString() + "\ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nAddress1 = " + this.tbxAddress1.Text.Trim().ToString() + "\nAddress2 = " + this.tbxAddress2.Text.Trim().ToString() + "\nWeight = " + this.tbxweight.Text.Trim().ToString() + "\ndeductions = " + this.tbxDeductions.Text.Trim().ToString() + "\nnetweight = " + this.tbxNetWeight.Text.Trim().ToString() + "\nPureweight = " + this.tbxPureWeight.Text.Trim().ToString() + "\nvalue = " + this.tbxValue.Text.Trim().ToString() + "\nAmount = " + this.tbxAmount.Text.Trim().ToString() + "\nBillDate = " + this.tbxBillDate.Text.Trim().ToString() + "\nInterestRate = " + this.tbxInteresRate.Text.Trim().ToString() + "\nArticles are \n";
          this.updatePledge();
          this.updatePledgeArticles();
          PawnManagementClass.InsertIntoHistory("PLEDGE EDIT", "Pledge Bill Number" + this.tbxBillNumber.Text.Trim().ToString() + " edited", this.oldValues + this.oldValuesArticles, this.newValues + this.newValuesArticles, FormMain.username, DateTime.Now.ToString());
          this.Close();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledgeEdit.finishedentry()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void deletePledgeArticles(string BillNumber)
    {
      string strError = "";
      string text = SQLHelper.RunCommand("delete from tblPledgeArticles where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (!(text != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledgeedit.deleterpledgearticles", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    private void updatePledgeArticles()
    {
      try
      {
        this.deletePledgeArticles(this.tbxBillNumber.Text.Trim());
        for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
        {
          string Articles = ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString();
          string ArticlesDescription = ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value.ToString();
          string HiddenRemarks = ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value.ToString();
          if (FormMain.withIndividualWeight)
          {
            double Purity = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? "" : ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString());
            double GrossWeight = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value.ToString());
            double Deduction = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value.ToString());
            double NetWeight = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value.ToString());
            double PureWeight = double.Parse(((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value.ToString());
            string no = ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString();
            this.insertPledgeArticles(this.tbxBillNumber.Text, Articles, ArticlesDescription, HiddenRemarks, Purity, GrossWeight, Deduction, NetWeight, PureWeight, no);
            this.newValuesArticles = this.newValuesArticles + ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString() + " " + ArticlesDescription + " " + HiddenRemarks + " " + (object) Purity + " " + (object) GrossWeight + " " + (object) Deduction + " " + (object) NetWeight + " " + (object) PureWeight + " " + no + "\n";
          }
          else
          {
            string no = ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString();
            this.insertPledgeArticles(this.tbxBillNumber.Text, Articles, ArticlesDescription, HiddenRemarks, no);
            this.newValuesArticles = this.newValuesArticles + ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString() + " " + ArticlesDescription + " " + HiddenRemarks + " " + no + "\n";
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledgeEdit.savePledgeArticles()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void updatePledge()
    {
      string str = "N";
      string strError = "";
      string text = SQLHelper.RunCommand("update tblPledge set BillDate=@BillDate,CustomerCode=@CustomerCode,CustomerName=@CustomerName,DoorNumber = @DoorNumber,Addr1=@Addr1,Addr2=@Addr2,Addr3=@Addr3,City=@City,Pincode=@Pincode,PhoneNumber=@PhoneNumber,AmountInWords=@AmountInWords,Type=@Type,GrossWeight=@GrossWeight,Deduction=@Deduction,NetWeight=@NetWeight,PureWeight = @PureWeight,Amount=@Amount,PresentValue=@PresentValue,OldBillNumber=@OldBillNumber,Reminder=@Reminder,temp1=@InterestRate,InterestRateDisplaySymbol = @InterestRateDisplaySymbol,Redeemed=@Redeemed,PledgeCreatedBy=@PledgeCreatedBy,PledgeCreatedOn=@PledgeCreatedOn,temp5 = @temp5,ArticlesWithoutHr=@ArticlesWithoutHr,ArticlesWithHr=@ArticlesWithHr,Articles=@Articles,ReleaseDate = @ReleaseDate,MonthlyIncome = @MonthlyIncome,Purpose = @Purpose where BillNumber=@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) this.tbxBillDate.Text),
        new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode.Text),
        new OleDbParameter("CustomerName", (object) this.tbxCustomerName.Text),
        new OleDbParameter("DoorNumber", (object) this.tbxNumber.Text),
        new OleDbParameter("Addr1", (object) this.tbxAddress1.Text),
        new OleDbParameter("Addr2", (object) this.tbxAddress2.Text),
        new OleDbParameter("Addr3", (object) this.tbxAddress3.Text),
        new OleDbParameter("City", (object) this.tbxCity.Text),
        new OleDbParameter("Pincode", (object) this.tbxPincode.Text),
        new OleDbParameter("PhoneNumber", (object) this.tbxPhoneNumber.Text),
        new OleDbParameter("AmountInWords", (object) ConvertNumbersToWords.NumberToWords(int.Parse(this.tbxAmount.Text.Trim().ToString()))),
        new OleDbParameter("Type", (object) this.cbType.Text.Trim()),
        new OleDbParameter("GrossWeight", (object) this.tbxweight.Text),
        new OleDbParameter("Deduction", (object) this.tbxDeductions.Text),
        new OleDbParameter("NetWeight", (object) this.tbxNetWeight.Text),
        new OleDbParameter("PureWeight", (object) this.tbxPureWeight.Text),
        new OleDbParameter("Amount", (object) this.tbxAmount.Text),
        new OleDbParameter("PresentValue", (object) this.tbxValue.Text),
        new OleDbParameter("OldBillNumber", (object) this.tbxOldBillNumber.Text),
        new OleDbParameter("Reminder", (object) this.tbxReminder.Text),
        new OleDbParameter("InterestRate", (object) this.tbxInteresRate.Text),
        new OleDbParameter("InterestRateDisplaySymbol", (object) this.symbolToPrintAsInterestRate),
        new OleDbParameter("Redeemed", (object) str),
        new OleDbParameter("PledgeCreatedBy", (object) FormMain.username),
        new OleDbParameter("PledgeCreatedOn", (object) DateTime.Now.ToString()),
        new OleDbParameter("temp5", (object) this.tbxTotalInterest.Text.Trim().ToString()),
        new OleDbParameter("ArticlesWithoutHr", (object) this.getPledgeArticlesCombined()),
        new OleDbParameter("ArticlesWithHr", (object) this.getPledgeArticlesCombined()),
        new OleDbParameter("Articles", (object) this.getPledgeArticlesCombined()),
        new OleDbParameter("ReleaseDate", (object) this.tbxReleaseDate.Text),
        new OleDbParameter("MonthlyIncome", (object) this.tbxIncome.Text),
        new OleDbParameter("Purpose", (object) this.tbxPurpose.Text),
        new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (text == "Done")
        return;
      PawnManagementClass.InsertIntoException("form pledge edit.savepledge", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    private void UpdateTableVouchers()
    {
      try
      {
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text);
        string str1 = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        string str2 = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(str2))
        {
          this.getVoucherNumberAndDate(this.tbxBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text);
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str2), str1, this.voucherCode, this.voucherName, this.tbxBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text, "G1", "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
          if (!FormPrintSettings.boolReduceFirstMonthInterest())
            return;
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str2), (int.Parse(str1) + 1).ToString(), this.voucherCodeInterestGirvi, this.voucherNameInterestGirvi, this.tbxBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text, "B1", "JAMMA", double.Parse(this.tbxTotalInterest.Text));
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot be updated in Rokad, as rokad has already been finished for this day");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledgeEdit.UpdateTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private DataTable getVoucherNumberAndDate(string VoucherDescription)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherDescription=@VoucherDescription and active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (VoucherDescription), (object) VoucherDescription));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeedit.getVoucherName(string voucherdescription)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledgeedit.getVoucherName(string voucherdescription)" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            return dataTable2;
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledgeEdit.getInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      return dataTable2;
    }

    private bool checkIfAllEntriesEntered()
    {
      if (!this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.cbShopCodes.Select();
        return false;
      }
      if (this.tbxBillNumber.Text == "")
      {
        this.tbxBillNumber.Select();
        return false;
      }
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (!PawnManagementClass.validateBillNumber(this.tbxBillNumber.Text))
          {
            this.tbxBillNumber.Select();
            return false;
          }
          break;
        case "DOUBLE":
          if (!PawnManagementClass.validateBillNumberDouble(this.tbxBillNumber.Text))
          {
            this.tbxBillNumber.Select();
            return false;
          }
          break;
      }
      if (this.tbxBillDate.Text == "")
      {
        this.tbxBillDate.Select();
        return false;
      }
      if (!PawnManagementClass.checkForValidateDate(this.tbxBillDate.Text))
      {
        this.tbxBillDate.Select();
        return false;
      }
      if (this.tbxCustomerCode.Text.Trim() == "")
      {
        this.tbxCustomerName.Select();
        return false;
      }
      if (this.cbType.Text.Trim() == "")
      {
        this.cbType.Select();
        return false;
      }
      if (this.tbxweight.Text.Trim() == "")
      {
        this.tbxweight.Select();
        return false;
      }
      if (this.tbxNetWeight.Text.Trim() == "")
      {
        this.tbxNetWeight.Select();
        return false;
      }
      if (this.tbxDeductions.Text.Trim() == "")
      {
        this.tbxDeductions.Select();
        return false;
      }
      if (this.tbxPureWeight.Text.Trim() == "")
      {
        this.tbxPureWeight.Select();
        return false;
      }
      if (this.tbxValue.Text.Trim() == "")
      {
        this.tbxValue.Select();
        return false;
      }
      if (this.tbxAmount.Text.Trim() == "")
      {
        this.tbxAmount.Select();
        return false;
      }
      if (this.tbxInteresRate.Text.Trim() == "")
      {
        this.tbxInteresRate.Select();
        return false;
      }
      if (this.tbxChit.Text.Trim() == "")
      {
        this.tbxChit.Select();
        return false;
      }
      if (this.tbxTotalInterest.Text.Trim() == "")
      {
        this.tbxInteresRate.Select();
        return false;
      }
      if (this.tbxPay.Text.Trim() == "")
      {
        this.tbxInteresRate.Select();
        return false;
      }
      if (double.Parse(this.tbxTotalInterest.Text) >= double.Parse(this.tbxAmount.Text))
      {
        this.tbxTotalInterest.Select();
        return false;
      }
      if (!PawnManagementClass.checkForValidateDate(this.tbxReleaseDate.Text))
      {
        this.tbxReleaseDate.Select();
        return false;
      }
      if (!(DateTime.Parse(this.tbxReleaseDate.Text) <= DateTime.Parse(this.tbxBillDate.Text)))
        return true;
      this.tbxReleaseDate.Select();
      return false;
    }

    private void dgvArticles_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Escape)
          return;
        this.escapeCount = 0;
        if (((DataGridView) this.dgvArticles).Rows.Count > 0)
        {
          int rowIndex = ((DataGridView) this.dgvArticles).CurrentCell.RowIndex;
          if (((((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[0].Value != null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[0].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[0].Value.ToString() == "" ? 1 : 0))) != 0)
          {
            if (!this.checkIfArticlesTableContainsNullValues())
            {
              if (FormMain.withIndividualWeight)
                this.getWeight();
              this.tbxweight.Select();
            }
          }
          else if (((((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[2].Value != null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[2].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[rowIndex].Cells[2].Value.ToString() == "" ? 1 : 0))) != 0)
          {
            if (!this.checkIfArticlesTableContainsNullValues())
            {
              if (FormMain.withIndividualWeight)
                this.getWeight();
              this.tbxweight.Select();
            }
          }
          else
          {
            ((DataGridView) this.dgvArticles).Rows.RemoveAt(rowIndex);
            if (!this.checkIfArticlesTableContainsNullValues())
            {
              if (FormMain.withIndividualWeight)
                this.getWeight();
              this.tbxweight.Select();
            }
            else
              this.checkIfArticlesTableIsNull1();
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void getWeight()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) ((DataGridView) this.dgvArticles).Rows)
      {
        num1 += double.Parse(row.Cells["COLGrossWeight"].Value.ToString());
        num3 += double.Parse(row.Cells["COLDeduction"].Value.ToString());
        num2 += double.Parse(row.Cells["COLNetWeight"].Value.ToString());
        num4 += double.Parse(row.Cells["COLPureWeight"].Value.ToString());
      }
      this.tbxweight.Text = num1.ToString();
      this.tbxDeductions.Text = num3.ToString();
      this.tbxNetWeight.Text = num2.ToString();
      this.tbxPureWeight.Text = num4.ToString();
    }

    private bool checkIfArticlesTableContainsNullValues()
    {
      if (FormMain.withIndividualWeight)
      {
        for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
        {
          if (((((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value.ToString() == "" ? 1 : 0))) != 0 || ((((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value == null ? 1 : 0) | (((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value == null ? 0 : (((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value.ToString() == "" ? 1 : 0))) != 0)
            return true;
        }
        return false;
      }
      if (FormMain.withIndividualWeight)
        return false;
      for (int index = 0; index < ((DataGridView) this.dgvArticles).RowCount; ++index)
      {
        if (((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value == null || ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value == null)
          return true;
      }
      return false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void tbxweight_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxweight.Text == "")
      {
        Transition.run((object) this.tbxweight, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 400));
        this.tbxweight.BackColor = Color.Red;
        this.tbxweight.Select();
      }
      else
      {
        if (this.tbxweight.Text.Contains<char>('.'))
        {
          int num = this.tbxweight.Text.IndexOf('.');
          if (this.tbxweight.Text.Length - num == 1)
            this.tbxweight.Text += "000";
          if (this.tbxweight.Text.Length - num == 2)
            this.tbxweight.Text += "00";
          if (this.tbxweight.Text.Length - num == 3)
            this.tbxweight.Text += "0";
        }
        else
          this.tbxweight.Text += ".000";
        if (double.Parse(this.tbxweight.Text) <= 0.0)
        {
          Transition.run((object) this.tbxweight, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 400));
          this.tbxweight.Select();
        }
      }
    }

    private void tbxDeductions_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxDeductions.Text == "")
        this.tbxDeductions.Select();
      else if (this.tbxDeductions.Text.Contains<char>('.'))
      {
        int num = this.tbxDeductions.Text.IndexOf('.');
        if (this.tbxDeductions.Text.Length - num == 1)
          this.tbxDeductions.Text += "000";
        if (this.tbxDeductions.Text.Length - num == 2)
          this.tbxDeductions.Text += "00";
        if (this.tbxDeductions.Text.Length - num != 3)
          return;
        this.tbxDeductions.Text += "0";
      }
      else
        this.tbxDeductions.Text += ".000";
    }

    private void tbxNetWeight_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxNetWeight.Text.Trim() != "")
      {
        if (double.Parse(this.tbxNetWeight.Text) > double.Parse(this.tbxweight.Text))
          this.tbxNetWeight.Select();
        else
          this.tbxNetWeight.Text = PawnManagementClass.appenZeroes(this.tbxNetWeight.Text.Trim());
      }
      else
        this.tbxNetWeight.Select();
    }

    private void pictureBox2_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void tbxChit_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void dgvCustomerPledgeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      this.dgvCustomerPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      if (this.dgvCustomerPledgeDetails.Rows.Count <= 0)
        return;
      if (this.dgvCustomerPledgeDetails.Columns[e.ColumnIndex].Name == "BillNumber")
      {
        double num = (double) (this.dgvCustomerPledgeDetails.Location.Y + this.dgvCustomerPledgeDetails.Size.Width);
        string BILLNUMBER = this.dgvCustomerPledgeDetails.Rows[this.dgvCustomerPledgeDetails.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dgvCustomerPledgeDetails.Rows[this.dgvCustomerPledgeDetails.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
      else if (this.dgvCustomerPledgeDetails.Columns[e.ColumnIndex].Name == "")
      {
        double num = (double) (this.dgvCustomerPledgeDetails.Location.Y + this.dgvCustomerPledgeDetails.Size.Width);
        string BILLNUMBER = this.dgvCustomerPledgeDetails.Rows[this.dgvCustomerPledgeDetails.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dgvCustomerPledgeDetails.Rows[this.dgvCustomerPledgeDetails.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void cbView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbView.Text == "PENDING")
      {
        this.dgvCustomerPledgeDetails.BringToFront();
        this.getPendingPledgesCompleteTotal();
      }
      else if (this.cbView.Text == "RELEASED")
      {
        this.getRedeemedPledges(this.tbxCustomerCode.Text);
        this.dgvRedeemedPledges.BringToFront();
        this.getTotalRedeemedPledges();
      }
      else if (this.cbView.Text == "AUCTIONED")
      {
        this.getAuctionedPledges(this.tbxCustomerCode.Text);
        this.dgvAuctionedPledges.BringToFront();
        this.getTotalAuctionedPledges();
      }
      else
      {
        if (!(this.cbView.Text == "ALL"))
          return;
        this.getAllPledge(this.tbxCustomerCode.Text);
        this.dgvAllPledge.BringToFront();
      }
    }

    private void dgvAuctionedPledges_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvAuctionedPledges.Rows.Count <= 0 || this.dgvAuctionedPledges.CurrentCell.ColumnIndex != 0)
        return;
      double num = (double) (this.dgvAuctionedPledges.Location.Y + this.dgvAuctionedPledges.Size.Width);
      string BILLNUMBER = this.dgvAuctionedPledges.Rows[this.dgvAuctionedPledges.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dgvAuctionedPledges.Rows[this.dgvAuctionedPledges.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "")
        new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
    }

    private void dgvRedeemedPledges_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvRedeemedPledges.Rows.Count <= 0 || this.dgvRedeemedPledges.CurrentCell.ColumnIndex != 0)
        return;
      double num = (double) (this.dgvRedeemedPledges.Location.Y + this.dgvRedeemedPledges.Size.Width);
      string BILLNUMBER = this.dgvRedeemedPledges.Rows[this.dgvRedeemedPledges.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dgvRedeemedPledges.Rows[this.dgvRedeemedPledges.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "")
        new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
    }

    private void dgvRedeemedPledges_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void dgvAuctionedPledges_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void dgvRedeemedPledges_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      try
      {
        this.getTotalRedeemedPledges();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formPledge.dgvrRedeemedPledges_DataBindingComplete", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dgvAuctionedPledges_DataSourceChanged(object sender, EventArgs e) => this.getTotalAuctionedPledges();

    private void dgvAuctionedPledges_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
    }

    private void dgvCustomerPledgeDetails_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
    }

    private void tbxPay_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxPincode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxCell_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (this.tbxCustomerCode.Text != "")
      {
        this.tbxCustomerName.SelectionStart = this.tbxCustomerName.Text.Length;
        this.tbxCustomerName.Select();
        switch (FormMain.addEditCustomerSetting)
        {
          case "ADVANCED":
            Form1 form1 = new Form1("EDIT", this.tbxCustomerCode.Text);
            if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
            {
              if (FormMain.AutoOnfingerPrint)
                FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
              else
                FormMain.m_FPM.EnableAutoOnEvent(false, 0);
            }
            int num1 = (int) form1.ShowDialog();
            break;
          case "SIMPLE":
            FormEditCustomer formEditCustomer = new FormEditCustomer(this.tbxCustomerCode.Text);
            if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
            {
              if (FormMain.AutoOnfingerPrint)
                FormMain.m_FPM.EnableAutoOnEvent(true, (int) formEditCustomer.Handle);
              else
                FormMain.m_FPM.EnableAutoOnEvent(false, 0);
            }
            int num2 = (int) formEditCustomer.ShowDialog();
            break;
        }
        this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
      }
      else
      {
        int num = (int) MessageBox.Show("select customer");
      }
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void tbxBillDate_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.formType == "OLD PLEDGE" | this.formType == "PLEDGE EDIT") || !(this.tbxBillDate.Text != "") || !PawnManagementClass.checkForValidateDate(this.tbxBillDate.Text))
        return;
      if (DateTime.Parse(this.tbxBillDate.Text) > DateTime.Now)
      {
        this.tbxBillDate.ForeColor = Color.White;
        this.tbxBillDate.BackColor = Color.Firebrick;
      }
      DataTable previousBillExact = this.getPreviousBillExact(this.tbxBillNumber.Text);
      if (previousBillExact != null && previousBillExact.Rows.Count > 0)
      {
        int num1 = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBillExact.Rows[0]["BillDate"].ToString())).TotalDays > 10.0 ? 1 : 0;
        TimeSpan timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBillExact.Rows[0]["BillDate"].ToString()));
        int num2 = timeSpan.TotalDays < -10.0 ? 1 : 0;
        if ((num1 | num2) != 0)
        {
          this.tbxBillDate.ForeColor = Color.White;
          this.tbxBillDate.BackColor = Color.Firebrick;
        }
        else
        {
          DataTable previousBill = this.getPreviousBill(this.tbxBillNumber.Text);
          if (previousBill != null && previousBill.Rows.Count > 0)
          {
            timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBill.Rows[0]["BillDate"].ToString()));
            int num3 = timeSpan.TotalDays > 60.0 ? 1 : 0;
            timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBill.Rows[0]["BillDate"].ToString()));
            int num4 = timeSpan.TotalDays < -60.0 ? 1 : 0;
            if ((num3 | num4) != 0)
            {
              this.tbxBillDate.ForeColor = Color.White;
              this.tbxBillDate.BackColor = Color.Firebrick;
            }
            else
            {
              this.tbxBillDate.ForeColor = Color.Navy;
              this.tbxBillDate.BackColor = Color.White;
            }
          }
        }
      }
      this.tbxReleaseDate.Text = DateTime.Parse(this.tbxBillDate.Text).AddYears(1).ToString("dd/MM/yyyy");
    }

    private void cbType_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\u001E' || e.KeyChar == '\u001F')
        return;
      e.Handled = true;
    }

    private void dgvArticles_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbType.SelectedIndex == 0)
        this.cbType.ForeColor = Color.Gold;
      if (this.cbType.SelectedIndex == 1)
        this.cbType.ForeColor = Color.Silver;
      if (this.cbType.SelectedIndex != 2)
        return;
      this.cbType.ForeColor = Color.Black;
    }

    private void button2_Enter(object sender, EventArgs e) => this.btnSave.ForeColor = Color.Red;

    private void button2_Leave(object sender, EventArgs e) => this.btnSave.ForeColor = Color.RoyalBlue;

    private void tbxChit_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxTotalInterest.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxInteresRate.Select();
    }

    private void tbxInteresRate_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxInteresRate.Text == ""))
        return;
      this.tbxInteresRate.Select();
    }

    private void glassButton1_Click(object sender, EventArgs e) => new FormJewelPhoto(this.tbxBillNumber.Text, this.cbShopCodes.Text).Show();

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

    private void tbxReminder_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxReleaseDate.Select();
    }

    private void tbxNetWeight_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxPureWeight.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxDeductions.Select();
    }

    private void tbxValue_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxAmount.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxPureWeight.Select();
    }

    private void tbxAmount_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxInteresRate.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxValue.Select();
    }

    private void tbxweight_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxDeductions.Select();
    }

    private void tbxDeductions_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxNetWeight.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxweight.Select();
    }

    private void tbxInteresRate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxChit.Select();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxAmount.Select();
    }

    private void dgvArticles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      if (((DataGridView) this.dgvArticles).Rows.Count >= 10)
        return;
      ((Control) this.dgvArticles).Height = this.GetDataGridViewHeight((DataGridView) this.dgvArticles);
      this.panel2.Height = (int) this.tableLayoutPanel2.RowStyles[1].Height;
    }

    private void tbxPureWeight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxPureWeight_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void tbxPureWeight_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxPureWeight.Text != "")
      {
        if (double.Parse(this.tbxPureWeight.Text) < double.Parse(this.tbxNetWeight.Text))
        {
          if (double.Parse(this.tbxPureWeight.Text) != 0.0)
          {
            if (this.tbxPureWeight.Text.Contains<char>('.'))
            {
              int num = this.tbxPureWeight.Text.IndexOf('.');
              if (this.tbxPureWeight.Text.Length - num == 1)
                this.tbxPureWeight.Text += ".000";
              if (this.tbxPureWeight.Text.Length - num == 2)
                this.tbxPureWeight.Text += "00";
              if (this.tbxPureWeight.Text.Length - num != 3)
                return;
              this.tbxPureWeight.Text += "0";
            }
            else
              this.tbxPureWeight.Text += ".000";
          }
          else
            this.tbxPureWeight.Select();
        }
        else
        {
          int num = (int) MessageBox.Show("Pure Weight cannot be greater than net weight");
          this.tbxPureWeight.Select();
        }
      }
      else
      {
        if (!(this.tbxPureWeight.Text == ""))
          return;
        this.tbxPureWeight.Text = "0";
        this.tbxPureWeight.Select();
      }
    }

    private void dgvArticles_Validating(object sender, CancelEventArgs e)
    {
      if (!FormMain.withIndividualWeight || this.checkIfArticlesTableContainsNullValues())
        return;
      foreach (DataGridViewRow row in (IEnumerable) ((DataGridView) this.dgvArticles).Rows)
      {
        row.Cells["colnetweight"].Value = (object) this.appendZeroes((double.Parse(row.Cells["colgrossweight"].Value.ToString()) - double.Parse(row.Cells["coldeduction"].Value.ToString())).ToString());
        row.Cells["colpureweight"].Value = (object) this.appendZeroes((double.Parse(row.Cells["colPurity"].Value.ToString()) * double.Parse(row.Cells["colnetweight"].Value.ToString()) / 100.0).ToString());
      }
      this.getWeight();
    }

    private void dgvArticles_CellClick(object sender, DataGridViewCellEventArgs e) => ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;

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

    private void tbxBillNumber_TextChanged(object sender, EventArgs e)
    {
      if (this.formType == "OLD PLEDGE")
      {
        try
        {
          string strError = "";
          string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber AND shopCode = @ShopCode";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
          }
          else if (dataTable2 != null && dataTable2.Rows.Count > 0)
            this.tbxBillNumber.ForeColor = Color.Red;
          else
            this.tbxBillNumber.ForeColor = Color.Navy;
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.tbxBillNumber_TextChanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      if (!(this.formType == "PLEDGE EDIT"))
        return;
      try
      {
        string strError = "";
        string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and redeemed = 'N' and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
        }
        else if (dataTable4 != null && dataTable4.Rows.Count > 0)
          this.tbxBillNumber.ForeColor = Color.Navy;
        else
          this.tbxBillNumber.ForeColor = Color.Red;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.tbxBillNumber_TextChanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxBillNumber_Validating(object sender, CancelEventArgs e)
    {
      if (this.formType == "OLD PLEDGE")
      {
        try
        {
          switch (FormMain.BillNumberSeries)
          {
            case "SINGLE":
              if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              {
                this.checkWhetherPledgeBillNumberAlreadyExists();
                break;
              }
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              break;
            case "DOUBLE":
              if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
              {
                this.checkWhetherPledgeBillNumberAlreadyExists();
              }
              else
              {
                (sender as TextBox).Select();
                (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
              }
              break;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form oldpledge.tbxBillNumber_Leave", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          this.tbxBillNumber.ResetText();
          this.tbxBillNumber.Select();
          this.Refresh();
        }
      }
      if (this.formType == "PLEDGE EDIT")
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              this.getBillDetails(this.tbxBillNumber.Text);
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              this.getBillDetails(this.tbxBillNumber.Text);
            }
            else
            {
              (sender as TextBox).Select();
              (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
            }
            break;
        }
      }
      if (!(this.formType == "NEW PLEDGE"))
        return;
      this.getPledgeBillNumber();
    }

    private void getBillDetails(string BillNumber)
    {
      string strError = "";
      string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) this.tbxBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
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
        if (dataTable2.Rows[0].Field<string>("Redeemed") == "N")
        {
          this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CustomerCode");
          this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CustomerName");
          this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("Addr1");
          this.tbxAddress2.Text = dataTable2.Rows[0].Field<string>("Addr2");
          this.cbType.Text = dataTable2.Rows[0].Field<string>("Type");
          this.tbxweight.Text = dataTable2.Rows[0].Field<string>("GrossWeight").ToString();
          this.tbxDeductions.Text = dataTable2.Rows[0].Field<string>("Deduction").ToString();
          this.tbxNetWeight.Text = dataTable2.Rows[0].Field<string>("NetWeight").ToString();
          this.tbxPureWeight.Text = dataTable2.Rows[0]["PureWeight"].ToString();
          this.tbxValue.Text = dataTable2.Rows[0].Field<int>("PresentValue").ToString();
          this.tbxAmount.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
          this.pledgeAmountForEdit = dataTable2.Rows[0].Field<int>("Amount").ToString();
          this.tbxBillDate.Text = dataTable2.Rows[0].Field<DateTime>("BillDate").ToString("dd/MM/yyyy");
          this.tbxInteresRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
          this.tbxOldBillNumber.Text = dataTable2.Rows[0]["OldBillNumber"].ToString();
          this.oldValues = "old values are \n customerCode = " + this.tbxCustomerCode.Text.Trim().ToString() + "\ncustomerName = " + this.tbxCustomerName.Text.Trim().ToString() + "\nAddress1 = " + this.tbxAddress1.Text.Trim().ToString() + "\nAddress2 = " + this.tbxAddress2.Text.Trim().ToString() + "\nWeight = " + this.tbxweight.Text.Trim().ToString() + "\ndeductions = " + this.tbxDeductions.Text.Trim().ToString() + "\nnetweight = " + this.tbxNetWeight.Text.Trim().ToString() + "\nvalue = " + this.tbxValue.Text.Trim().ToString() + "\nAmount = " + this.tbxAmount.Text.Trim().ToString() + "\nBillDate = " + this.tbxBillDate.Text.Trim().ToString() + "\nInterestRate = " + this.tbxInteresRate.Text.Trim().ToString() + "\nArticles are \n";
          this.getdgvArticles();
          this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
          this.tbxReleaseDate.Text = dataTable2.Rows[0].Field<DateTime>("BillDate").ToString("dd/MM/yyyy");
          this.tbxPurpose.Text = dataTable2.Rows[0]["Purpose"].ToString();
          this.tbxIncome.Text = dataTable2.Rows[0]["MonthlyIncome"].ToString();
        }
        else if (dataTable2.Rows[0].Field<string>("Redeemed") == "Y")
        {
          int num = (int) MessageBox.Show("Bill Number Already released");
          this.tbxBillNumber.Select();
        }
        else
        {
          int num = (int) MessageBox.Show("ENTER VALID BILL NUMBER");
          this.tbxBillNumber.Select();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Enter valid Bill Number");
        this.tbxBillNumber.Select();
      }
    }

    private void getdgvArticles()
    {
      string strError = "";
      string my_querry = "Select * from tblPledgeArticles where BillNumber = @BillNumber AND ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
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
          {
            this.oldValuesArticles = "";
            ((DataGridView) this.dgvArticles).Rows.Clear();
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
              ((DataGridView) this.dgvArticles).Rows.Add();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value = (object) dataTable2.Rows[index]["Articles"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value = (object) dataTable2.Rows[index]["ArticlesDescription"].ToString();
              ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value = (object) dataTable2.Rows[index]["Hr"].ToString();
              if (FormMain.withIndividualWeight)
              {
                ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value = (object) dataTable2.Rows[index]["Purity"].ToString();
                ((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value = (object) dataTable2.Rows[index]["GrossWeight"].ToString();
                ((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value = (object) dataTable2.Rows[index]["Deduction"].ToString();
                ((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value = (object) dataTable2.Rows[index]["NetWeight"].ToString();
                ((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value = (object) dataTable2.Rows[index]["PureWeight"].ToString();
                ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value = (object) dataTable2.Rows[index]["Num"].ToString();
                this.oldValuesArticles = this.oldValuesArticles + ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[4].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[5].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[6].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[7].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[8].Value + "\n";
              }
              else
              {
                ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value = (object) dataTable2.Rows[index]["Num"].ToString();
                this.oldValuesArticles = this.oldValuesArticles + ((DataGridView) this.dgvArticles).Rows[index].Cells[0].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[1].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[2].Value + " " + ((DataGridView) this.dgvArticles).Rows[index].Cells[3].Value + "\n";
              }
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledgeEdit.getdgvArticles()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void checkWhetherPledgeBillNumberAlreadyExists()
    {
      try
      {
        string strError = "";
        string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and ShopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgebillnumberalreadyexists()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          int num = (int) MessageBox.Show(" BillNumber already exits");
          this.tbxBillNumber.Select();
          this.tbxBillNumber.Select(2, this.tbxBillNumber.Text.Length);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgeBillNumberAlreadyExists", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxBillDate_Enter(object sender, EventArgs e)
    {
      if (!(this.formType == "OLD PLEDGE") || !(this.tbxBillDate.Text.Trim() == ""))
        return;
      DataTable previousBillExact2 = this.getPreviousBillExact2(this.tbxBillNumber.Text);
      if (previousBillExact2 != null && previousBillExact2.Rows.Count > 0)
        this.tbxBillDate.Text = DateTime.Parse(previousBillExact2.Rows[0]["billDate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxBillDate.Select(0, this.tbxBillDate.Text.IndexOf("/"));
    }

    private DataTable getPreviousBill(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where (BillNumber  like @BillNumber) and shopCode = @ShopCode order by BillNumber asc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) (BillNumber.Substring(0, 4) + "%")));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form oldpledge.void getPreviousBill(string BillNumber)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("void getPreviousBill(string BillNumber) \n" + strError);
      return dataTable2;
    }

    private DataTable getPreviousBillExact(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber  like @BillNumber  and ShopCode = @ShopCode order by BillNumber asc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) (BillNumber.Substring(0, 5) + "%")));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form oldpledge.void getPreviousBill(string BillNumber)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("void getPreviousBill(string BillNumber) \n" + strError);
      return dataTable2;
    }

    private DataTable getPreviousBillExact2(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where BillNumber  like @BillNumber  and ShopCode = @ShopCode order by BillNumber desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) (BillNumber.Substring(0, 5) + "%")));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form oldpledge.void getPreviousBill(string BillNumber)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("void getPreviousBill(string BillNumber) \n" + strError);
      return dataTable2;
    }

    private void tbxBillDate_TextChanged(object sender, EventArgs e)
    {
      if (!(this.formType == "OLD PLEDGE") || !(this.tbxBillDate.Text != "") || !PawnManagementClass.checkForValidateDate(this.tbxBillDate.Text))
        return;
      if (DateTime.Parse(this.tbxBillDate.Text) > DateTime.Now)
      {
        this.tbxBillDate.ForeColor = Color.White;
        this.tbxBillDate.BackColor = Color.Firebrick;
      }
      else
      {
        DataTable previousBillExact = this.getPreviousBillExact(this.tbxBillNumber.Text);
        if (previousBillExact != null && previousBillExact.Rows.Count > 0)
        {
          TimeSpan timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBillExact.Rows[0]["BillDate"].ToString()));
          int num1 = timeSpan.TotalDays > 10.0 ? 1 : 0;
          timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBillExact.Rows[0]["BillDate"].ToString()));
          int num2 = timeSpan.TotalDays < -10.0 ? 1 : 0;
          if ((num1 | num2) != 0)
          {
            this.tbxBillDate.ForeColor = Color.White;
            this.tbxBillDate.BackColor = Color.Firebrick;
          }
          else
          {
            this.tbxBillDate.ForeColor = Color.Navy;
            this.tbxBillDate.BackColor = Color.White;
          }
        }
        else
        {
          DataTable previousBill = this.getPreviousBill(this.tbxBillNumber.Text);
          if (previousBill != null && previousBill.Rows.Count > 0)
          {
            TimeSpan timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBill.Rows[0]["BillDate"].ToString()));
            int num3 = timeSpan.TotalDays > 60.0 ? 1 : 0;
            timeSpan = DateTime.Parse(this.tbxBillDate.Text).Subtract(DateTime.Parse(previousBill.Rows[0]["BillDate"].ToString()));
            int num4 = timeSpan.TotalDays < -60.0 ? 1 : 0;
            if ((num3 | num4) != 0)
            {
              this.tbxBillDate.ForeColor = Color.White;
              this.tbxBillDate.BackColor = Color.Firebrick;
            }
            else
            {
              this.tbxBillDate.ForeColor = Color.Navy;
              this.tbxBillDate.BackColor = Color.White;
            }
          }
          else
          {
            this.tbxBillDate.ForeColor = Color.Navy;
            this.tbxBillDate.BackColor = Color.White;
          }
        }
      }
    }

    private void cbType_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbType.Text == ""))
        return;
      this.cbType.Select();
    }

    private void cbType_KeyPress_1(object sender, KeyPressEventArgs e) => e.Handled = true;

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
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.DisplayedCells)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "").ShowDialog();
    }

    private void tbxPureWeight_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        if (this.tbxPureWeight.Text != "" && double.Parse(this.tbxPureWeight.Text) > 0.0)
        {
          this.tbxValue.Select();
        }
        else
        {
          FormPurityCalculator purityCalculator = new FormPurityCalculator();
          FormPurityCalculator.strInitialWeight = this.tbxNetWeight.Text.Trim();
          int num = (int) purityCalculator.ShowDialog();
          this.tbxPureWeight.Text = FormPurityCalculator.strFinalWeight;
        }
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.tbxNetWeight.Select();
      }
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.formType == "NEW PLEDGE")
      {
        if (this.cbShopCodes.Text != "")
          this.tbxCustomerName.Select();
      }
      else if (this.cbShopCodes.Text != "")
      {
        this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
        this.tbxBillNumber.Select();
      }
    }

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getLedgerAndVoucherCode();
      this.ledgerName = LedgerMaster.getLedgerName(this.ledgerCode);
      this.ledgerNameInterest = LedgerMaster.getLedgerName(this.ledgerCodeInterest);
      this.voucherName = VoucherMasterClass.getVoucherName(this.voucherCode);
      this.voucherNameInterestGirvi = VoucherMasterClass.getVoucherName(this.voucherCodeInterestGirvi);
    }

    private void getLedgerAndVoucherCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblShopDetails where shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getledgerandvouchercode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form pledge.getledgerandvouchercode" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.ledgerCode = dataTable2.Rows[0]["ledgercode"].ToString();
          this.voucherCode = dataTable2.Rows[0]["vouchercode"].ToString();
          this.ledgerCodeInterest = dataTable2.Rows[0]["ledgercodeinterest"].ToString();
          this.voucherCodeInterestGirvi = dataTable2.Rows[0]["vouchercodeinterestgirvi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form pledge.getledgerandvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        if (this.formType == "NEW PLEDGE")
          this.getPledgeBillNumber();
        else if (this.formType == "OLD PLEDGE")
        {
          this.getPledgeBillNumber();
          this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length - 2;
          this.tbxBillNumber.Select(this.tbxBillNumber.Text.Length - 2, 2);
        }
        else if (this.formType == "PLEDGE EDIT")
        {
          this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
          this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
          this.tbxBillNumber.Select();
          this.getBillNumbers(this.cbShopCodes.Text);
          this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
          this.tbxBillNumber.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
        }
        this.getLedgerAndVoucherCode();
        this.ledgerName = LedgerMaster.getLedgerName(this.ledgerCode);
        this.ledgerNameInterest = LedgerMaster.getLedgerName(this.ledgerCodeInterest);
        this.voucherName = VoucherMasterClass.getVoucherName(this.voucherCode);
        this.voucherNameInterestGirvi = VoucherMasterClass.getVoucherName(this.voucherCodeInterestGirvi);
      }
      else
        this.cbShopCodes.Select();
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.GreenYellow;
      textBox.ForeColor = Color.Black;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.Black;
    }

    private void tbxPureWeight_Enter(object sender, EventArgs e)
    {
      if (FormMain.withIndividualWeight)
        return;
      this.tbxPureWeight.Text = (double.Parse(this.tbxNetWeight.Text) * double.Parse(this.getDefaultPurity(this.cbType.Text)) / 100.0).ToString();
    }

    private void tbxBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillDate.Select();
    }

    private void dgvCustomerPledgeDetails_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvCustomerPledgeDetails.Rows.Count <= 0)
        return;
      if (this.dgvCustomerPledgeDetails.Columns[e.ColumnIndex].Name == "BillNumber" | this.dgvCustomerPledgeDetails.Columns[e.ColumnIndex].Name == "CustomerCode")
        this.dgvCustomerPledgeDetails.Cursor = Cursors.Hand;
      else
        this.dgvCustomerPledgeDetails.Cursor = Cursors.Default;
    }

    private void dgvRedeemedPledges_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvRedeemedPledges.Rows.Count <= 0)
        return;
      if (e.ColumnIndex == 0)
        this.dgvRedeemedPledges.Cursor = Cursors.Hand;
      else
        this.dgvRedeemedPledges.Cursor = Cursors.Default;
    }

    private void dgvAuctionedPledges_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvAuctionedPledges.Rows.Count <= 0)
        return;
      if (e.ColumnIndex == 0)
        this.dgvAuctionedPledges.Cursor = Cursors.Hand;
      else
        this.dgvAuctionedPledges.Cursor = Cursors.Default;
    }

    private void dgvCustomerPledgeDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (this.dgvCustomerPledgeDetails.IsCurrentCellDirty)
        this.dgvCustomerPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void getPendingPledgesCompleteTotal()
    {
      try
      {
        this.totalAmount = 0.0;
        this.totalInterest = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
        {
          if (row.Cells["colSelect"] != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
          {
            this.totalAmount += Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()));
            this.totalInterest += Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()));
          }
        }
        this.tbxTotalAmount.Text = this.totalAmount.ToString("F");
        this.tbxtotalPendingInterest.Text = this.totalInterest.ToString("F");
        this.tbxTotalAmountPlusInterest.Text = (this.totalAmount + this.totalInterest).ToString("F");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form CustomerPledgeDetails.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvCustomerPledgeDetails.Rows.Count; ++index)
        this.dgvCustomerPledgeDetails.Rows[index].Cells["COLselect"].Value = (object) true;
      this.dgvCustomerPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void unSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvCustomerPledgeDetails.Rows.Count; ++index)
        this.dgvCustomerPledgeDetails.Rows[index].Cells["COLselect"].Value = (object) false;
      this.dgvCustomerPledgeDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
      this.getPendingPledgesCompleteTotal();
    }

    private void glassButton15_Click(object sender, EventArgs e)
    {
      if (this.printerConnectedOrNot())
      {
        int num1 = (int) MessageBox.Show("connected");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Not connected");
      }
    }

    private void tbxAmount_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxAmount.Text.Trim() != "" && double.Parse(this.tbxAmount.Text.Trim()) > 0.0)
        return;
      this.tbxAmount.Select();
    }

    private void cbShopCodes_Enter(object sender, EventArgs e)
    {
      if (this.cbShopCodes.Items.Count != 1)
        return;
      SendKeys.Send("{Enter}");
    }

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxDeductions_Enter(object sender, EventArgs e)
    {
      if (FormMain.withIndividualWeight || !(this.tbxDeductions.Text == ""))
        return;
      this.getDeduction();
    }

    private void FormPledgePledge_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F12)
        ((Button) this.btnAdd).PerformClick();
      if (e.KeyCode != Keys.F1)
        return;
      int num = (int) new FormPurityCalculator().ShowDialog();
    }

    private void printNoticeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormSelectNoticeFromPledgeScreen(this.dgvCustomerPledgeDetails).ShowDialog();
    }

    private void getReportTypesNotice()
    {
      string[] files = Directory.GetFiles("Reports\\\\Notice\\\\", "*.rpt");
      string[] strArray = File.ReadAllLines("Reports\\Notice\\LastUsed.txt");
      foreach (string text in files)
        this.printNoticeToolStripMenuItem.DropDownItems.Add((ToolStripItem) new ToolStripMenuItem(text));
      foreach (ToolStripDropDownItem dropDownItem in (ArrangedElementCollection) this.printNoticeToolStripMenuItem.DropDownItems)
      {
        if (dropDownItem.Text == strArray[0].ToString())
          dropDownItem.ForeColor = Color.Blue;
      }
      foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) this.printNoticeToolStripMenuItem.DropDownItems)
        dropDownItem.Click += new EventHandler(this.t_Click);
    }

    private void t_Click(object sender, EventArgs e)
    {
      this.printNotice((sender as ToolStripMenuItem).Text);
      File.WriteAllText("Reports\\Notice\\LastUsed.txt", (sender as ToolStripMenuItem).Text);
    }

    private void printNotice(string ReportName)
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
      RD.Load(ReportName);
      RD.SetDataSource(this.dtPrintNotice);
      if (!ReportName.Contains("Final"))
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
      foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
      {
        if (row.Cells["colSelect"].Value != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
          this.dtPrintNotice.Rows.Add((object) row.Cells["BillNumber"].Value.ToString(), (object) DateTime.Parse(row.Cells["BillDate"].Value.ToString()), (object) row.Cells["CustomerCode"].Value.ToString(), (object) row.Cells["nameAndAddress"].Value.ToString(), (object) row.Cells["amount"].Value.ToString(), (object) row.Cells["netweight"].Value.ToString(), (object) row.Cells["presentvalue"].Value.ToString(), (object) row.Cells["articles"].Value.ToString(), (object) "", (object) DateTime.Now, (object) "", (object) this.tbxPhoneNumber.Text, (object) "");
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

    private void getReportTypesCustomerReports()
    {
      string[] files = Directory.GetFiles("Reports\\\\CustomerReports\\\\All\\\\", "*.rpt");
      string[] strArray = File.ReadAllLines("Reports\\CustomerReports\\All\\LastUsed.txt");
      foreach (string text in files)
        this.printCustomerDetailsToolStripMenuItem.DropDownItems.Add((ToolStripItem) new ToolStripMenuItem(text));
      foreach (ToolStripDropDownItem dropDownItem in (ArrangedElementCollection) this.printCustomerDetailsToolStripMenuItem.DropDownItems)
      {
        if (dropDownItem.Text == strArray[0].ToString())
          dropDownItem.ForeColor = Color.Blue;
      }
      foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) this.printCustomerDetailsToolStripMenuItem.DropDownItems)
        dropDownItem.Click += new EventHandler(this.tt_Click);
    }

    private void tt_Click(object sender, EventArgs e)
    {
      this.printcustomerDetails((sender as ToolStripMenuItem).Text);
      File.WriteAllText("Reports\\\\CustomerReports\\\\All\\\\LastUsed.txt", (sender as ToolStripMenuItem).Text);
    }

    private void printcustomerDetails(string ReportName)
    {
      string strError = "";
      string my_querry = "select * from tblCustomers where Cid = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) this.tbxCustomerCode.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        row["CImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + row["CID"].ToString() + ".png");
      this.rd.Load(ReportName);
      this.rd.SetDataSource(dataTable2);
      if (ReportName.Contains("Pending"))
        this.rd.Subreports[0].SetDataSource(this.getPendingPledgeDetails(this.tbxCustomerCode.Text));
      else if (ReportName.Contains("Redeemed"))
        this.rd.Subreports["subreportRedeemedPledges"].SetDataSource(this.getRedeemedPledgesDatatable(this.tbxCustomerCode.Text));
      else if (ReportName.Contains("Auctioned"))
      {
        this.rd.Subreports["subreportAuctionedPledges"].SetDataSource(this.getAuctionedPledgesDAtatable(this.tbxCustomerCode.Text));
      }
      else
      {
        this.rd.Subreports[0].SetDataSource(this.getPendingPledgeDetails(this.tbxCustomerCode.Text));
        this.rd.Subreports["subreportRedeemedPledges"].SetDataSource(this.getRedeemedPledgesDatatable(this.tbxCustomerCode.Text));
        this.rd.Subreports["subreportAuctionedPledges"].SetDataSource(this.getAuctionedPledgesDAtatable(this.tbxCustomerCode.Text));
      }
      int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
    }

    private void printCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private DataTable getPendingPledgeDetails(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      string my_querry = "select p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber," + str + ",p.PresentValue ,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.CustomerCode,p.customername as nameandaddress,P.PHONENUMBER from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='N' order by p.billdate";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    private DataTable getRedeemedPledgesDatatable(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      return SQLHelper.GetDataTable("select p.shopCode,p.BillNumber,p.BillDate,p.Amount," + str + ",p.temp3 as FinalInterest,p.temp4 as RedemptionAmount,p.RedemptionDate,p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.temp2 as Interest,noticecharge,otherchargeS,InterestLess,Discount from tblPledge p where p.CustomerCode =@CustomerCode and p.Redeemed ='Y' order by p.BillDate", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
      }, ref strError);
    }

    private DataTable getAuctionedPledgesDAtatable(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      return SQLHelper.GetDataTable("select p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.temp3 as FinalInterest,p.temp4 as redemptionamount," + str + ",p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.temp2 as Interest,AuctionDate from tblPledge p  where p.CustomerCode =@CustomerCode and p.Redeemed ='A'", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
      }, ref strError);
    }

    private void tbxBillDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxCustomerName.Select();
    }

    private void tbxCustomerName_Enter(object sender, EventArgs e)
    {
      if (!(this.defaultCustomerCode != "") || !(this.tbxCustomerCode.Text == ""))
        return;
      this.getCustomerDetailssssss(this.defaultCustomerCode);
    }

    private void FormPledgePledge_Activated(object sender, EventArgs e)
    {
    }

    private void FormPledgePledge_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.MdiParent.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
    }

    private void deleteFromVoucherTable(string BillNumber, string ShopCode)
    {
      DataTable voucherNumberAndDate1 = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      if (voucherNumberAndDate1 == null || voucherNumberAndDate1.Rows.Count <= 0)
        return;
      DataTable voucherNumberAndDate2 = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      string str1 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
      string s1 = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
      DateTime now = DateTime.Parse(s1);
      if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
      {
        string strError = "";
        if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str1)
        }, ref strError) == "Done")
        {
          string ActionDetails = "VOUCHER NUMBER " + str1 + " Date " + s1 + " deleted";
          string username = FormMain.username;
          now = DateTime.Now;
          string PerformedOn = now.ToString();
          PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
      DataTable voucherNumberAndDate3 = this.getVoucherNumberAndDate(BillNumber + " INTEREST GIRVI " + ShopCode);
      if (voucherNumberAndDate3 != null && voucherNumberAndDate3.Rows.Count > 0)
      {
        string str2 = voucherNumberAndDate3.Rows[0]["voucherNumber"].ToString();
        string s2 = voucherNumberAndDate3.Rows[0]["voucherDate"].ToString();
        now = DateTime.Parse(s2);
        if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
        {
          string strError = "";
          if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
          {
            new OleDbParameter("Active", (object) "0"),
            new OleDbParameter("VoucherNumber", (object) str2)
          }, ref strError) == "Done")
          {
            string ActionDetails = "VOUCHER NUMBER " + str2 + " Date " + s2 + " deleted";
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
        }
      }
    }

    private void deleteFromPledgeAndPledgeArticlesTable(string BillNumber, string ShopCode)
    {
      string strError1 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledge where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError1) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError1);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError1, FormMain.username, DateTime.Now.ToString());
      }
      string strError2 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledgearticles where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError2) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError2);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError2, FormMain.username, DateTime.Now.ToString());
      }
      string strError3 = "";
      if (SQLHelper.RunCommand("Delete from tblInterestReceived where BillNumber = @BillNumber AND shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError3) != "Done")
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError3);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError3, FormMain.username, DateTime.Now.ToString());
      }
      PawnManagementClass.InsertIntoHistory("PLEDGE DELETE", BillNumber + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dgvCustomerPledgeDetails.Rows.Count <= 0 || this.dgvCustomerPledgeDetails.CurrentCell == null)
        return;
      int rowIndex = this.dgvCustomerPledgeDetails.CurrentCell.RowIndex;
      string BillNumber = this.dgvCustomerPledgeDetails.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      string ShopCode = this.dgvCustomerPledgeDetails.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
      this.dgvCustomerPledgeDetails.Rows[rowIndex].Cells["BillDate"].Value.ToString();
      DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
      {
        voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("Delete Pledge BillNumber : " + BillNumber + "?", "Delete Pledge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          {
            this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
            this.deleteFromVoucherTable(BillNumber, ShopCode);
            this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot Delete as Rokad has been finished for this date");
        }
      }
      else if (DialogResult.Yes == MessageBox.Show("Delete Pledge?", "Delete Pledge", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
      {
        this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
        this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
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

    private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
      {
        if (row.Cells["colSelect"].Value != null && bool.Parse(row.Cells["colSelect"].Value.ToString()) && row.Cells["BillNumber"] != null && row.Cells["BillNumber"].Value != null && row.Cells["BillNumber"].Value.ToString().Trim() != "" && row.Cells["shopcode"] != null && row.Cells["shopcode"].Value != null && row.Cells["shopcode"].Value.ToString().Trim() != "")
          FormMain.lsttoRelease.Add(row.Cells["BillNumber"].Value.ToString() + "," + row.Cells["ShopCode"].Value.ToString());
      }
    }

    private void receivePartPaymentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dgvCustomerPledgeDetails == null || this.dgvCustomerPledgeDetails.Rows.Count <= 0 || this.dgvCustomerPledgeDetails.CurrentCell == null || this.dgvCustomerPledgeDetails.CurrentCell.RowIndex < 0)
        return;
      int rowIndex = this.dgvCustomerPledgeDetails.CurrentCell.RowIndex;
      string BILLNUMBER = this.dgvCustomerPledgeDetails.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      string SHOPCODE = this.dgvCustomerPledgeDetails.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
      if (BILLNUMBER != "" && SHOPCODE != "")
      {
        int num = (int) new FormPartPayment("New", BILLNUMBER, SHOPCODE).ShowDialog();
        this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
      }
    }

    private void calculateCompoundInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.calculateCompoundInterest = true;
      this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
    }

    private void printNoticeToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
    }

    private void tbxBillDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(this.tbxBillDate.Text.Trim() == "") || e.KeyChar != '\b')
        return;
      this.tbxBillNumber.Select();
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          this.tbxBillNumber.Select(2, this.tbxBillNumber.Text.Length);
          break;
        case "DOUBLE":
          this.tbxBillNumber.Select(3, this.tbxBillNumber.Text.Length);
          break;
      }
    }

    private void btnJewelPhoto_Click(object sender, EventArgs e)
    {
      int num = (int) new FormJewelPhoto(this.tbxBillNumber.Text, this.cbShopCodes.Text).ShowDialog();
      if (!File.Exists(FormMain.startUpPath + "Photos\\Jewels\\" + this.tbxBillNumber.Text + " " + this.cbShopCodes.Text + ".png"))
        return;
      using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\Jewels\\" + this.tbxBillNumber.Text + " " + this.cbShopCodes.Text + ".png", FileMode.Open, FileAccess.Read))
      {
        this.pbJewelPhoto.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void tbxReleaseDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return | e.KeyCode == Keys.Down)
      {
        this.tbxPurpose.Select();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.tbxReminder.Select();
      }
    }

    private void tbxReleaseDate_Enter(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxBillDate.Text))
        return;
      TextBox tbxReleaseDate = this.tbxReleaseDate;
      DateTime dateTime = DateTime.Parse(this.tbxBillDate.Text);
      dateTime = dateTime.AddYears(1);
      string str = dateTime.ToString("dd/MM/yyyy");
      tbxReleaseDate.Text = str;
    }

    private void tbxPurpose_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return | e.KeyCode == Keys.Down)
      {
        this.tbxIncome.Select();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.tbxReleaseDate.Select();
      }
    }

    private void tbxIncome_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        ((Control) this.dgvArticles).Select();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.tbxPurpose.Select();
      }
    }

    private void changeColumnOrderToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormColumnOrder("PledgeScreenAll").ShowDialog();
      this.Close();
    }

    private void setIntimationLetterAsGivenInPersonToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
      {
        if (row.Cells["colSelect"].Value != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
          PawnManagement.Classes.PawnManagementClasses.PledgeClass.setIntimationLetterSentToYesOrNo(row.Cells["ShopCode"].Value.ToString(), row.Cells["BillNumber"].Value.ToString(), "Y", DateTime.Now, "SELF", "");
      }
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        string str1 = ((object[]) e.Argument)[0].ToString();
        string strError = "";
        string newValue = "Articles as Articles";
        string my_querry = "select " + this.getQuery("PledgeScreenPendingPledge").Replace("articles", newValue) + " from tblPledge where CustomerCode =@CustomerCode and Redeemed ='N' order by billdate";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("CustomerCode", (object) str1));
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
          dataTable2.Columns.Add("PaymentReceived", typeof (double));
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
              double num;
              if (n != -1)
              {
                if (n > 11)
                {
                  if (this.calculateCompoundInterest)
                  {
                    if (FormMain.IncludeNoticeChargeInPledgeScreen)
                    {
                      DataRow dataRow = row;
                      num = PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString())) + double.Parse(FormMain.NoticeChargeInPledgeScreen);
                      string str2 = num.ToString();
                      dataRow["Interest"] = (object) str2;
                    }
                    else
                    {
                      DataRow dataRow = row;
                      num = PawnManagementClass.calculateCompundInterest(double.Parse(row["Amount"].ToString()), (double) n, double.Parse(row["InterestRate"].ToString()));
                      string str3 = num.ToString();
                      dataRow["Interest"] = (object) str3;
                    }
                  }
                  else
                    row["Interest"] = !FormMain.IncludeNoticeChargeInPledgeScreen ? (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) : (object) (Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0) + double.Parse(FormMain.NoticeChargeInPledgeScreen));
                }
                else
                  row["Interest"] = (object) Math.Round(double.Parse(row["Amount"].ToString()) * double.Parse(row["InterestRate"].ToString()) * (double) n / 1200.0);
              }
              row["PaymentReceived"] = (object) PawnManagementClass.getPaymentSum(row["BillNumber"].ToString(), row["ShopCode"].ToString());
            }
          }
          this.calculateCompoundInterest = false;
        }
        e.Result = (object) dataTable2;
      }
      catch (Exception ex)
      {
        e.Result = (object) ex;
      }
    }

    private void dgvCustomerDetails_Leave(object sender, EventArgs e) => this.dgvCustomerDetails.ClearSelection();

    private void cbType_Leave(object sender, EventArgs e)
    {
      this.cbType.ForeColor = Color.Black;
      this.cbType.BackColor = Color.White;
    }

    private void dgvArticles_CurrentCellChanged(object sender, EventArgs e)
    {
      if (((DataGridView) this.dgvArticles).CurrentCell == null)
        return;
      ((DataGridView) this.dgvArticles).CurrentCell.Style.BackColor = Color.GreenYellow;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result is DataTable)
      {
        this.dgvCustomerPledgeDetails.DataSource = (object) (e.Result as DataTable);
        this.dgvCustomerPledgeDetails.Visible = true;
        this.dgvCustomerPledgeDetails.Columns["Interest"].DisplayIndex = 1;
        this.dgvCustomerPledgeDetails.Columns["NoOfMonths"].DisplayIndex = 2;
        this.dgvCustomerPledgeDetails.Columns["PaymentReceived"].DisplayIndex = 3;
        this.dgvCustomerPledgeDetails.BringToFront();
        foreach (DataGridViewRow row in (IEnumerable) this.dgvCustomerPledgeDetails.Rows)
        {
          row.Cells["colSelect"].Value = (object) true;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 9.0)
            row.DefaultCellStyle.ForeColor = Color.Blue;
          if (double.Parse(row.Cells["NoOfMonths"].Value.ToString()) > 11.0)
            row.DefaultCellStyle.ForeColor = Color.Red;
        }
        this.dgvCustomerPledgeDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["GrossWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["Deduction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dgvCustomerPledgeDetails.Columns["NoOfMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        if (this.dgvCustomerPledgeDetails != null && this.dgvCustomerPledgeDetails.Rows.Count > 0)
        {
          foreach (string columnName in OrderClass.getcolumnsToHide("PledgeScreenPendingPledge"))
          {
            if (this.dgvCustomerPledgeDetails.Columns.Contains(columnName))
              this.dgvCustomerPledgeDetails.Columns[columnName].Visible = false;
          }
        }
        this.getPendingPledgesCompleteTotal();
      }
      else if (!(e.Result is Exception))
        ;
    }

    private void changeColumnOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormColumnOrder("PledgeScreenPendingPledge").ShowDialog();
      this.Close();
    }

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
      int num = (int) new FormAddCustomer().ShowDialog();
      this.tbxCustomerCode.Text = FormAddCustomer.newCustomerCodeAdde;
      this.getCustomerDetailssssss(this.tbxCustomerCode.Text);
    }

    private void glassButton1_Click_2(object sender, EventArgs e)
    {
      switch (FormMain.addEditCustomerSetting)
      {
        case "SIMPLE":
          FormAddCustomer formAddCustomer = new FormAddCustomer();
          if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
          {
            if (FormMain.AutoOnfingerPrint)
              FormMain.m_FPM.EnableAutoOnEvent(true, (int) formAddCustomer.Handle);
            else
              FormMain.m_FPM.EnableAutoOnEvent(false, 0);
          }
          int num1 = (int) formAddCustomer.ShowDialog();
          if (FormAddCustomer.newCustomerCodeAdde != "")
          {
            this.getCustomerDetailssssss(FormAddCustomer.newCustomerCodeAdde);
            break;
          }
          int num2 = (int) MessageBox.Show("Error in adding customer... Try again");
          break;
        case "ADVANCED":
          Form1 form1 = new Form1("ADD", "");
          if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
          {
            if (FormMain.AutoOnfingerPrint)
              FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
            else
              FormMain.m_FPM.EnableAutoOnEvent(false, 0);
          }
          int num3 = (int) form1.ShowDialog();
          if (Form1.newCustomerCodeAdde != "")
          {
            this.getCustomerDetailssssss(Form1.newCustomerCodeAdde);
          }
          else
          {
            int num4 = (int) MessageBox.Show("Error in adding customer... Try again");
          }
          break;
      }
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void tbxTotalInterest_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.btnSave.Focus();
      if (e.KeyCode != Keys.Up)
        return;
      this.tbxChit.Select();
    }

    private void tbxTotalInterest_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxChit.Text == "")
        this.tbxChit.Text = "0";
      if (this.tbxAmount.Text == "")
        this.tbxAmount.Text = "0";
      if (this.tbxInteresRate.Text == "")
        this.tbxInteresRate.Text = "0";
      if (this.tbxTotalInterest.Text == "")
      {
        this.tbxTotalInterest.Text = "0";
        this.tbxTotalInterest.Select(0, this.tbxTotalInterest.TextLength);
      }
      double num1;
      if (double.Parse(this.tbxTotalInterest.Text) >= double.Parse(this.tbxAmount.Text))
      {
        TextBox tbxTotalInterest = this.tbxTotalInterest;
        num1 = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * double.Parse(this.tbxInteresRate.Text.Trim().ToString()) / 1200.0 + double.Parse(this.tbxChit.Text.Trim().ToString()), 0);
        string str = num1.ToString();
        tbxTotalInterest.Text = str;
        this.tbxTotalInterest.Select(0, this.tbxTotalInterest.TextLength);
      }
      TextBox tbxPay = this.tbxPay;
      num1 = double.Parse(this.tbxAmount.Text.Trim().ToString()) - double.Parse(this.tbxTotalInterest.Text.Trim().ToString());
      string str1 = num1.ToString();
      tbxPay.Text = str1;
      double num2 = double.Parse(this.tbxTotalInterest.Text);
      num1 = double.Parse(this.tbxAmount.Text.Trim().ToString()) * double.Parse(this.tbxInteresRate.Text.Trim().ToString()) / 1200.0 + double.Parse(this.tbxChit.Text.Trim().ToString());
      double num3 = double.Parse(num1.ToString());
      double num4 = num2 - num3;
      if (num4 < -10.0 | num4 > 10.0)
        this.tbxTotalInterest.ForeColor = Color.Red;
      else
        this.tbxTotalInterest.ForeColor = Color.Yellow;
    }

    private void tbxTotalInterest_Leave(object sender, EventArgs e)
    {
      double num = double.Parse(this.tbxTotalInterest.Text) - double.Parse((double.Parse(this.tbxAmount.Text.Trim().ToString()) * double.Parse(this.tbxInteresRate.Text.Trim().ToString()) / 1200.0 + double.Parse(this.tbxChit.Text.Trim().ToString())).ToString());
      if (num < -10.0 | num > 10.0)
      {
        this.tbxTotalInterest.ForeColor = Color.Red;
        this.tbxTotalInterest.BackColor = Color.White;
      }
      else
      {
        this.tbxTotalInterest.ForeColor = Color.Black;
        this.tbxTotalInterest.BackColor = Color.White;
      }
    }

    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.getReportTypesNotice();
      this.getReportTypesCustomerReports();
      this.getInterestSetting();
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
      DataGridViewCellStyle gridViewCellStyle17 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle18 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle19 = new DataGridViewCellStyle();
      this.colArticles = new DataGridViewTextBoxColumn();
      this.colArticlesDetails = new DataGridViewTextBoxColumn();
      this.colNo = new DataGridViewTextBoxColumn();
      this.colGrossWeight = new DataGridViewTextBoxColumn();
      this.colDeduction = new DataGridViewTextBoxColumn();
      this.colNetWeight = new DataGridViewTextBoxColumn();
      this.colPurity = new DataGridViewTextBoxColumn();
      this.colHiddenRemarks = new DataGridViewTextBoxColumn();
      this.colPureWeight = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new ToolStripMenuItem();
      this.unSelectAllToolStripMenuItem = new ToolStripMenuItem();
      this.printNoticeToolStripMenuItem = new ToolStripMenuItem();
      this.printCustomerDetailsToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.closeToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.releaseToolStripMenuItem = new ToolStripMenuItem();
      this.receivePartPaymentToolStripMenuItem = new ToolStripMenuItem();
      this.calculateCompoundInterestToolStripMenuItem = new ToolStripMenuItem();
      this.setIntimationLetterAsGivenInPersonToolStripMenuItem = new ToolStripMenuItem();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.backgroundWorker1 = new BackgroundWorker();
      this.textBox14 = new TextBox();
      this.cbType = new ComboBox();
      this.textBox13 = new TextBox();
      this.tbxValue = new TextBox();
      this.tbxPureWeight = new TextBox();
      this.tbxAmount = new TextBox();
      this.textBox12 = new TextBox();
      this.tbxInteresRate = new TextBox();
      this.textBox11 = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.textBox10 = new TextBox();
      this.tbxChit = new TextBox();
      this.textBox9 = new TextBox();
      this.tbxTotalInterest = new TextBox();
      this.textBox8 = new TextBox();
      this.tbxPay = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox1 = new TextBox();
      this.tbxReminder = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox6 = new TextBox();
      this.tbxweight = new TextBox();
      this.tbxOldBillNumber = new TextBox();
      this.textBox3 = new TextBox();
      this.tbxDeductions = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.tbxTotalAmount = new TextBox();
      this.textBox15 = new TextBox();
      this.tbxtotalPendingInterest = new TextBox();
      this.textBox16 = new TextBox();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.dgvAllPledge = new DataGridView();
      this.dgvAuctionedPledges = new DataGridView();
      this.dgvRedeemedPledges = new DataGridView();
      this.dgvCustomerPledgeDetails = new DataGridView();
      this.colSelect = new DataGridViewCheckBoxColumn();
      this.dgvArticles = new DataGridViewEx();
      this.tbxTotalAmountPlusInterest = new TextBox();
      this.textBox17 = new TextBox();
      this.cbView = new ComboBox();
      this.dgvCustomerDetails = new DataGridView();
      this.dgvPendingPledges = new DataGridView();
      this.backgroundWorker2 = new BackgroundWorker();
      this.cmsDeletePledge = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.panel4 = new Panel();
      this.textBox28 = new TextBox();
      this.tbxIncome = new TextBox();
      this.textBox27 = new TextBox();
      this.tbxPurpose = new TextBox();
      this.textBox26 = new TextBox();
      this.tbxReleaseDate = new TextBox();
      this.btnJewelPhoto = new GlassButton();
      this.pbJewelPhoto = new PictureBox();
      this.panel9 = new Panel();
      this.label5 = new Label();
      this.btnSave = new Button();
      this.panel1 = new Panel();
      this.label3 = new Label();
      this.tbxBillDate = new TextBox();
      this.panel5 = new Panel();
      this.label2 = new Label();
      this.cbShopCodes = new ComboBox();
      this.panel6 = new Panel();
      this.label1 = new Label();
      this.tbxBillNumber = new TextBox();
      this.panel3 = new Panel();
      this.panel7 = new Panel();
      this.label4 = new Label();
      this.tbxCustomerName = new TextBox();
      this.textBox19 = new TextBox();
      this.tbxPincode = new TextBox();
      this.tbxCell = new TextBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxAddress1 = new TextBox();
      this.tbxNumber = new TextBox();
      this.tbxAddress2 = new TextBox();
      this.tbxAddress3 = new TextBox();
      this.textBox18 = new TextBox();
      this.textBox20 = new TextBox();
      this.textBox21 = new TextBox();
      this.textBox22 = new TextBox();
      this.textBox23 = new TextBox();
      this.textBox24 = new TextBox();
      this.textBox25 = new TextBox();
      this.pbFingerPrint = new PictureBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCity = new TextBox();
      this.tbxNotes = new TextBox();
      this.btnAdd = new GlassButton();
      this.btnEdit = new GlassButton();
      this.pictureBox2 = new PictureBox();
      this.tbxAverageNumberOfDaysForRelease = new TextBox();
      this.tbxNumberOfTimesReleaseExceedTwelveMonths = new TextBox();
      this.panel8 = new Panel();
      this.panel10 = new Panel();
      this.label6 = new Label();
      this.contextMenuStrip3 = new ContextMenuStrip(this.components);
      this.changeColumnOrderToolStripMenuItem1 = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem1 = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem1 = new ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.contextMenuStrip2.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.dgvAllPledge).BeginInit();
      ((ISupportInitialize) this.dgvAuctionedPledges).BeginInit();
      ((ISupportInitialize) this.dgvRedeemedPledges).BeginInit();
      ((ISupportInitialize) this.dgvCustomerPledgeDetails).BeginInit();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      ((ISupportInitialize) this.dgvCustomerDetails).BeginInit();
      ((ISupportInitialize) this.dgvPendingPledges).BeginInit();
      this.cmsDeletePledge.SuspendLayout();
      this.panel4.SuspendLayout();
      ((ISupportInitialize) this.pbJewelPhoto).BeginInit();
      this.panel9.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel7.SuspendLayout();
      ((ISupportInitialize) this.pbFingerPrint).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.panel8.SuspendLayout();
      this.panel10.SuspendLayout();
      this.contextMenuStrip3.SuspendLayout();
      this.SuspendLayout();
      this.colArticles.HeaderText = "ARTICLES";
      this.colArticles.Name = "colArticles";
      this.colArticles.Resizable = DataGridViewTriState.True;
      this.colArticlesDetails.FillWeight = 60f;
      this.colArticlesDetails.HeaderText = "DESCRIPTION";
      this.colArticlesDetails.Name = "colArticlesDetails";
      this.colArticlesDetails.Resizable = DataGridViewTriState.True;
      this.colArticlesDetails.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colNo.FillWeight = 20f;
      this.colNo.HeaderText = "NO";
      this.colNo.Name = "colNo";
      this.colGrossWeight.HeaderText = "GROSS WEIGHT";
      this.colGrossWeight.Name = "colGrossWeight";
      this.colDeduction.HeaderText = "DEDUCTION";
      this.colDeduction.Name = "colDeduction";
      this.colNetWeight.HeaderText = "NETWEIGHT";
      this.colNetWeight.Name = "colNetWeight";
      this.colPurity.HeaderText = "%";
      this.colPurity.Name = "colPurity";
      this.colHiddenRemarks.HeaderText = "HIDDENREMARKS";
      this.colHiddenRemarks.Name = "colHiddenRemarks";
      this.colPureWeight.HeaderText = "PUREWEIGHT";
      this.colPureWeight.Name = "colPureWeight";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deleteToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(108, 26);
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new Size(107, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.selectAllToolStripMenuItem,
        (ToolStripItem) this.unSelectAllToolStripMenuItem,
        (ToolStripItem) this.printNoticeToolStripMenuItem,
        (ToolStripItem) this.printCustomerDetailsToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem,
        (ToolStripItem) this.closeToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.releaseToolStripMenuItem,
        (ToolStripItem) this.receivePartPaymentToolStripMenuItem,
        (ToolStripItem) this.calculateCompoundInterestToolStripMenuItem,
        (ToolStripItem) this.setIntimationLetterAsGivenInPersonToolStripMenuItem
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(280, 334);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(279, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(279, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(279, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new Size(279, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
      this.unSelectAllToolStripMenuItem.Name = "unSelectAllToolStripMenuItem";
      this.unSelectAllToolStripMenuItem.Size = new Size(279, 22);
      this.unSelectAllToolStripMenuItem.Text = "UnSelect All";
      this.unSelectAllToolStripMenuItem.Click += new EventHandler(this.unSelectAllToolStripMenuItem_Click);
      this.printNoticeToolStripMenuItem.Name = "printNoticeToolStripMenuItem";
      this.printNoticeToolStripMenuItem.Size = new Size(279, 22);
      this.printNoticeToolStripMenuItem.Text = "Print Notice";
      this.printNoticeToolStripMenuItem.Click += new EventHandler(this.printNoticeToolStripMenuItem_Click_1);
      this.printCustomerDetailsToolStripMenuItem.Name = "printCustomerDetailsToolStripMenuItem";
      this.printCustomerDetailsToolStripMenuItem.Size = new Size(279, 22);
      this.printCustomerDetailsToolStripMenuItem.Text = "Print Customer Details";
      this.printCustomerDetailsToolStripMenuItem.Click += new EventHandler(this.printCustomerDetailsToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(279, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change Column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new Size(279, 22);
      this.closeToolStripMenuItem.Text = "Delete Pledge";
      this.closeToolStripMenuItem.Click += new EventHandler(this.closeToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(279, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
      this.releaseToolStripMenuItem.Size = new Size(279, 22);
      this.releaseToolStripMenuItem.Text = "Add to Release List";
      this.releaseToolStripMenuItem.Click += new EventHandler(this.releaseToolStripMenuItem_Click);
      this.receivePartPaymentToolStripMenuItem.Name = "receivePartPaymentToolStripMenuItem";
      this.receivePartPaymentToolStripMenuItem.Size = new Size(279, 22);
      this.receivePartPaymentToolStripMenuItem.Text = "Receive Part Payment";
      this.receivePartPaymentToolStripMenuItem.Click += new EventHandler(this.receivePartPaymentToolStripMenuItem_Click);
      this.calculateCompoundInterestToolStripMenuItem.Name = "calculateCompoundInterestToolStripMenuItem";
      this.calculateCompoundInterestToolStripMenuItem.Size = new Size(279, 22);
      this.calculateCompoundInterestToolStripMenuItem.Text = "Calculate Compound Interest";
      this.calculateCompoundInterestToolStripMenuItem.Click += new EventHandler(this.calculateCompoundInterestToolStripMenuItem_Click);
      this.setIntimationLetterAsGivenInPersonToolStripMenuItem.Name = "setIntimationLetterAsGivenInPersonToolStripMenuItem";
      this.setIntimationLetterAsGivenInPersonToolStripMenuItem.Size = new Size(279, 22);
      this.setIntimationLetterAsGivenInPersonToolStripMenuItem.Text = "Set Intimation Letter as given in Person";
      this.setIntimationLetterAsGivenInPersonToolStripMenuItem.Click += new EventHandler(this.setIntimationLetterAsGivenInPersonToolStripMenuItem_Click);
      this.timer1.Enabled = true;
      this.timer1.Interval = 500;
      this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.textBox14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.textBox14.BackColor = Color.PowderBlue;
      this.textBox14.BorderStyle = BorderStyle.FixedSingle;
      this.textBox14.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox14.Location = new Point(10, 579);
      this.textBox14.Name = "textBox14";
      this.textBox14.Size = new Size(185, 29);
      this.textBox14.TabIndex = 93;
      this.textBox14.Text = "AMOUNT";
      this.textBox14.TextAlign = HorizontalAlignment.Center;
      this.cbType.Anchor = AnchorStyles.None;
      this.cbType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbType.ForeColor = Color.Gold;
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[3]
      {
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(134, 30);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(144, 32);
      this.cbType.TabIndex = 0;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
      this.cbType.Enter += new EventHandler(this.cbType_Enter);
      this.cbType.KeyDown += new KeyEventHandler(this.cbType_KeyDown);
      this.cbType.KeyPress += new KeyPressEventHandler(this.cbType_KeyPress_1);
      this.cbType.Leave += new EventHandler(this.cbType_Leave);
      this.cbType.Validating += new CancelEventHandler(this.cbType_Validating);
      this.textBox13.Anchor = AnchorStyles.None;
      this.textBox13.BackColor = Color.Azure;
      this.textBox13.BorderStyle = BorderStyle.None;
      this.textBox13.CharacterCasing = CharacterCasing.Upper;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox13.ForeColor = Color.DarkBlue;
      this.textBox13.Location = new Point(2, 319);
      this.textBox13.MaxLength = 4;
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new Size(114, 22);
      this.textBox13.TabIndex = 70;
      this.textBox13.Text = "PURE WT";
      this.textBox13.TextAlign = HorizontalAlignment.Right;
      this.tbxValue.Anchor = AnchorStyles.None;
      this.tbxValue.BorderStyle = BorderStyle.FixedSingle;
      this.tbxValue.CharacterCasing = CharacterCasing.Upper;
      this.tbxValue.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxValue.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxValue.Location = new Point(134, 343);
      this.tbxValue.MaxLength = 10;
      this.tbxValue.Name = "tbxValue";
      this.tbxValue.ReadOnly = true;
      this.tbxValue.Size = new Size(144, 29);
      this.tbxValue.TabIndex = 6;
      this.tbxValue.TextAlign = HorizontalAlignment.Right;
      this.tbxValue.Enter += new EventHandler(this.tbxValue_Enter);
      this.tbxValue.KeyDown += new KeyEventHandler(this.tbxValue_KeyDown);
      this.tbxValue.KeyPress += new KeyPressEventHandler(this.tbxValue_KeyPress);
      this.tbxPureWeight.Anchor = AnchorStyles.None;
      this.tbxPureWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPureWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxPureWeight.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPureWeight.Location = new Point(134, 313);
      this.tbxPureWeight.MaxLength = 7;
      this.tbxPureWeight.Name = "tbxPureWeight";
      this.tbxPureWeight.ReadOnly = true;
      this.tbxPureWeight.Size = new Size(144, 29);
      this.tbxPureWeight.TabIndex = 69;
      this.tbxPureWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxPureWeight.Enter += new EventHandler(this.tbxPureWeight_Enter);
      this.tbxPureWeight.KeyDown += new KeyEventHandler(this.tbxPureWeight_KeyDown);
      this.tbxPureWeight.KeyPress += new KeyPressEventHandler(this.tbxPureWeight_KeyPress);
      this.tbxPureWeight.KeyUp += new KeyEventHandler(this.tbxPureWeight_KeyUp);
      this.tbxPureWeight.Validating += new CancelEventHandler(this.tbxPureWeight_Validating);
      this.tbxAmount.Anchor = AnchorStyles.None;
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.CharacterCasing = CharacterCasing.Upper;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxAmount.Location = new Point(134, 374);
      this.tbxAmount.MaxLength = 10;
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(144, 29);
      this.tbxAmount.TabIndex = 7;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount.Enter += new EventHandler(this.tbxAmount_Enter);
      this.tbxAmount.KeyDown += new KeyEventHandler(this.tbxAmount_KeyDown);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
      this.tbxAmount.Validating += new CancelEventHandler(this.tbxAmount_Validating);
      this.textBox12.Anchor = AnchorStyles.None;
      this.textBox12.BackColor = Color.Azure;
      this.textBox12.BorderStyle = BorderStyle.None;
      this.textBox12.CharacterCasing = CharacterCasing.Upper;
      this.textBox12.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox12.ForeColor = Color.DarkBlue;
      this.textBox12.Location = new Point(16, 35);
      this.textBox12.MaxLength = 4;
      this.textBox12.Name = "textBox12";
      this.textBox12.Size = new Size(114, 22);
      this.textBox12.TabIndex = 67;
      this.textBox12.Text = "TYPE   ";
      this.textBox12.TextAlign = HorizontalAlignment.Right;
      this.tbxInteresRate.Anchor = AnchorStyles.None;
      this.tbxInteresRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInteresRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInteresRate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInteresRate.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxInteresRate.Location = new Point(134, 405);
      this.tbxInteresRate.MaxLength = 4;
      this.tbxInteresRate.Name = "tbxInteresRate";
      this.tbxInteresRate.ReadOnly = true;
      this.tbxInteresRate.Size = new Size(144, 29);
      this.tbxInteresRate.TabIndex = 8;
      this.tbxInteresRate.TextAlign = HorizontalAlignment.Right;
      this.tbxInteresRate.Enter += new EventHandler(this.tbxInteresRate_Enter);
      this.tbxInteresRate.KeyDown += new KeyEventHandler(this.tbxInteresRate_KeyDown);
      this.tbxInteresRate.KeyPress += new KeyPressEventHandler(this.tbxInteresRate_KeyPress);
      this.tbxInteresRate.Validating += new CancelEventHandler(this.tbxInteresRate_Validating);
      this.textBox11.Anchor = AnchorStyles.None;
      this.textBox11.BackColor = Color.Azure;
      this.textBox11.BorderStyle = BorderStyle.None;
      this.textBox11.CharacterCasing = CharacterCasing.Upper;
      this.textBox11.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox11.ForeColor = Color.DarkBlue;
      this.textBox11.Location = new Point(13, 67);
      this.textBox11.MaxLength = 4;
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new Size(114, 22);
      this.textBox11.TabIndex = 66;
      this.textBox11.Text = "OLD NO   ";
      this.textBox11.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.Anchor = AnchorStyles.None;
      this.tbxNetWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNetWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxNetWeight.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.Location = new Point(134, 282);
      this.tbxNetWeight.MaxLength = 7;
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.ReadOnly = true;
      this.tbxNetWeight.Size = new Size(144, 29);
      this.tbxNetWeight.TabIndex = 5;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.Enter += new EventHandler(this.tbxNetWeight_Enter);
      this.tbxNetWeight.KeyDown += new KeyEventHandler(this.tbxNetWeight_KeyDown);
      this.tbxNetWeight.KeyPress += new KeyPressEventHandler(this.tbxNetWeight_KeyPress);
      this.tbxNetWeight.Validating += new CancelEventHandler(this.tbxNetWeight_Validating);
      this.textBox10.Anchor = AnchorStyles.None;
      this.textBox10.BackColor = Color.Azure;
      this.textBox10.BorderStyle = BorderStyle.None;
      this.textBox10.CharacterCasing = CharacterCasing.Upper;
      this.textBox10.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox10.ForeColor = Color.DarkBlue;
      this.textBox10.Location = new Point(16, 97);
      this.textBox10.MaxLength = 4;
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new Size(114, 22);
      this.textBox10.TabIndex = 65;
      this.textBox10.Text = "REMINDER   ";
      this.textBox10.TextAlign = HorizontalAlignment.Right;
      this.tbxChit.Anchor = AnchorStyles.None;
      this.tbxChit.BorderStyle = BorderStyle.FixedSingle;
      this.tbxChit.CharacterCasing = CharacterCasing.Upper;
      this.tbxChit.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxChit.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxChit.Location = new Point(134, 436);
      this.tbxChit.MaxLength = 4;
      this.tbxChit.Name = "tbxChit";
      this.tbxChit.Size = new Size(144, 29);
      this.tbxChit.TabIndex = 9;
      this.tbxChit.TextAlign = HorizontalAlignment.Right;
      this.tbxChit.KeyDown += new KeyEventHandler(this.tbxChit_KeyDown);
      this.tbxChit.KeyPress += new KeyPressEventHandler(this.tbxChit_KeyPress);
      this.tbxChit.Leave += new EventHandler(this.tbxChit_Leave);
      this.textBox9.Anchor = AnchorStyles.None;
      this.textBox9.BackColor = Color.Azure;
      this.textBox9.BorderStyle = BorderStyle.None;
      this.textBox9.CharacterCasing = CharacterCasing.Upper;
      this.textBox9.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox9.ForeColor = Color.DarkBlue;
      this.textBox9.Location = new Point(16, 228);
      this.textBox9.MaxLength = 4;
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new Size(114, 22);
      this.textBox9.TabIndex = 64;
      this.textBox9.Text = "GROSS WT   ";
      this.textBox9.TextAlign = HorizontalAlignment.Right;
      this.tbxTotalInterest.Anchor = AnchorStyles.None;
      this.tbxTotalInterest.BackColor = SystemColors.ControlLightLight;
      this.tbxTotalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotalInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxTotalInterest.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalInterest.ForeColor = Color.Black;
      this.tbxTotalInterest.Location = new Point(134, 467);
      this.tbxTotalInterest.MaxLength = 10;
      this.tbxTotalInterest.Name = "tbxTotalInterest";
      this.tbxTotalInterest.Size = new Size(144, 29);
      this.tbxTotalInterest.TabIndex = 55;
      this.tbxTotalInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxTotalInterest.TextChanged += new EventHandler(this.tbxTotalInterest_TextChanged);
      this.tbxTotalInterest.KeyDown += new KeyEventHandler(this.tbxTotalInterest_KeyDown);
      this.tbxTotalInterest.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
      this.tbxTotalInterest.Leave += new EventHandler(this.tbxTotalInterest_Leave);
      this.textBox8.Anchor = AnchorStyles.None;
      this.textBox8.BackColor = Color.Azure;
      this.textBox8.BorderStyle = BorderStyle.None;
      this.textBox8.CharacterCasing = CharacterCasing.Upper;
      this.textBox8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox8.ForeColor = Color.DarkBlue;
      this.textBox8.Location = new Point(8, 257);
      this.textBox8.MaxLength = 4;
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(114, 22);
      this.textBox8.TabIndex = 63;
      this.textBox8.Text = "DEDUCTION   ";
      this.textBox8.TextAlign = HorizontalAlignment.Right;
      this.tbxPay.Anchor = AnchorStyles.None;
      this.tbxPay.BackColor = SystemColors.ControlLightLight;
      this.tbxPay.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPay.CharacterCasing = CharacterCasing.Upper;
      this.tbxPay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPay.ForeColor = Color.Black;
      this.tbxPay.Location = new Point(134, 498);
      this.tbxPay.MaxLength = 4;
      this.tbxPay.Name = "tbxPay";
      this.tbxPay.Size = new Size(144, 29);
      this.tbxPay.TabIndex = 53;
      this.tbxPay.TextAlign = HorizontalAlignment.Right;
      this.tbxPay.KeyPress += new KeyPressEventHandler(this.tbxPay_KeyPress);
      this.textBox7.Anchor = AnchorStyles.None;
      this.textBox7.BackColor = Color.Azure;
      this.textBox7.BorderStyle = BorderStyle.None;
      this.textBox7.CharacterCasing = CharacterCasing.Upper;
      this.textBox7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox7.ForeColor = Color.DarkBlue;
      this.textBox7.Location = new Point(16, 287);
      this.textBox7.MaxLength = 4;
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(114, 22);
      this.textBox7.TabIndex = 62;
      this.textBox7.Text = "NET WT   ";
      this.textBox7.TextAlign = HorizontalAlignment.Right;
      this.textBox1.Anchor = AnchorStyles.None;
      this.textBox1.BackColor = Color.Azure;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.CharacterCasing = CharacterCasing.Upper;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.DarkBlue;
      this.textBox1.Location = new Point(16, 347);
      this.textBox1.MaxLength = 4;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(114, 22);
      this.textBox1.TabIndex = 56;
      this.textBox1.Text = "VALUE   ";
      this.textBox1.TextAlign = HorizontalAlignment.Right;
      this.tbxReminder.Anchor = AnchorStyles.None;
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.CharacterCasing = CharacterCasing.Upper;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.Location = new Point(134, 93);
      this.tbxReminder.MaxLength = 50;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.ReadOnly = true;
      this.tbxReminder.Size = new Size(144, 29);
      this.tbxReminder.TabIndex = 2;
      this.tbxReminder.KeyDown += new KeyEventHandler(this.tbxReminder_KeyDown);
      this.textBox2.Anchor = AnchorStyles.None;
      this.textBox2.BackColor = Color.Azure;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.CharacterCasing = CharacterCasing.Upper;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox2.ForeColor = Color.DarkBlue;
      this.textBox2.Location = new Point(16, 379);
      this.textBox2.MaxLength = 4;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(114, 22);
      this.textBox2.TabIndex = 57;
      this.textBox2.Text = "AMOUNT   ";
      this.textBox2.TextAlign = HorizontalAlignment.Right;
      this.textBox6.Anchor = AnchorStyles.None;
      this.textBox6.BackColor = Color.Azure;
      this.textBox6.BorderStyle = BorderStyle.None;
      this.textBox6.CharacterCasing = CharacterCasing.Upper;
      this.textBox6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox6.ForeColor = Color.DarkBlue;
      this.textBox6.Location = new Point(16, 503);
      this.textBox6.MaxLength = 4;
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size(114, 22);
      this.textBox6.TabIndex = 61;
      this.textBox6.Text = "PAY   ";
      this.textBox6.TextAlign = HorizontalAlignment.Right;
      this.tbxweight.Anchor = AnchorStyles.None;
      this.tbxweight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxweight.CharacterCasing = CharacterCasing.Upper;
      this.tbxweight.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxweight.Location = new Point(134, 221);
      this.tbxweight.MaxLength = 7;
      this.tbxweight.Name = "tbxweight";
      this.tbxweight.ReadOnly = true;
      this.tbxweight.Size = new Size(144, 29);
      this.tbxweight.TabIndex = 3;
      this.tbxweight.TextAlign = HorizontalAlignment.Right;
      this.tbxweight.KeyDown += new KeyEventHandler(this.tbxweight_KeyDown);
      this.tbxweight.KeyPress += new KeyPressEventHandler(this.tbxweight_KeyPress);
      this.tbxweight.Validating += new CancelEventHandler(this.tbxweight_Validating);
      this.tbxOldBillNumber.Anchor = AnchorStyles.None;
      this.tbxOldBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOldBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxOldBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOldBillNumber.Location = new Point(134, 63);
      this.tbxOldBillNumber.MaxLength = 6;
      this.tbxOldBillNumber.Name = "tbxOldBillNumber";
      this.tbxOldBillNumber.ReadOnly = true;
      this.tbxOldBillNumber.Size = new Size(144, 29);
      this.tbxOldBillNumber.TabIndex = 1;
      this.tbxOldBillNumber.TextAlign = HorizontalAlignment.Right;
      this.tbxOldBillNumber.Enter += new EventHandler(this.textBox1_Enter);
      this.tbxOldBillNumber.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
      this.textBox3.Anchor = AnchorStyles.None;
      this.textBox3.BackColor = Color.Azure;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.CharacterCasing = CharacterCasing.Upper;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.ForeColor = Color.DarkBlue;
      this.textBox3.Location = new Point(16, 410);
      this.textBox3.MaxLength = 4;
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(114, 22);
      this.textBox3.TabIndex = 58;
      this.textBox3.Text = "ROI    ";
      this.textBox3.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.Anchor = AnchorStyles.None;
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.CharacterCasing = CharacterCasing.Upper;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.Location = new Point(134, 251);
      this.tbxDeductions.MaxLength = 5;
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.ReadOnly = true;
      this.tbxDeductions.Size = new Size(144, 29);
      this.tbxDeductions.TabIndex = 4;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.Enter += new EventHandler(this.tbxDeductions_Enter);
      this.tbxDeductions.KeyDown += new KeyEventHandler(this.tbxDeductions_KeyDown);
      this.tbxDeductions.KeyPress += new KeyPressEventHandler(this.tbxDeductions_KeyPress);
      this.tbxDeductions.Validating += new CancelEventHandler(this.tbxDeductions_Validating);
      this.textBox4.Anchor = AnchorStyles.None;
      this.textBox4.BackColor = Color.Azure;
      this.textBox4.BorderStyle = BorderStyle.None;
      this.textBox4.CharacterCasing = CharacterCasing.Upper;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox4.ForeColor = Color.DarkBlue;
      this.textBox4.Location = new Point(16, 442);
      this.textBox4.MaxLength = 4;
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(114, 22);
      this.textBox4.TabIndex = 59;
      this.textBox4.Text = "CHIT   ";
      this.textBox4.TextAlign = HorizontalAlignment.Right;
      this.textBox5.Anchor = AnchorStyles.None;
      this.textBox5.BackColor = Color.Azure;
      this.textBox5.BorderStyle = BorderStyle.None;
      this.textBox5.CharacterCasing = CharacterCasing.Upper;
      this.textBox5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox5.ForeColor = Color.DarkBlue;
      this.textBox5.Location = new Point(16, 474);
      this.textBox5.MaxLength = 4;
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(114, 22);
      this.textBox5.TabIndex = 60;
      this.textBox5.Text = "INTEREST   ";
      this.textBox5.TextAlign = HorizontalAlignment.Right;
      this.tbxTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxTotalAmount.BackColor = Color.Azure;
      this.tbxTotalAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotalAmount.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmount.Location = new Point(10, 607);
      this.tbxTotalAmount.Name = "tbxTotalAmount";
      this.tbxTotalAmount.Size = new Size(185, 29);
      this.tbxTotalAmount.TabIndex = 90;
      this.tbxTotalAmount.TextAlign = HorizontalAlignment.Center;
      this.textBox15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.textBox15.BackColor = Color.PowderBlue;
      this.textBox15.BorderStyle = BorderStyle.FixedSingle;
      this.textBox15.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox15.Location = new Point(194, 579);
      this.textBox15.Name = "textBox15";
      this.textBox15.Size = new Size(189, 29);
      this.textBox15.TabIndex = 94;
      this.textBox15.Text = "INTEREST";
      this.textBox15.TextAlign = HorizontalAlignment.Center;
      this.tbxtotalPendingInterest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxtotalPendingInterest.BackColor = Color.Azure;
      this.tbxtotalPendingInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxtotalPendingInterest.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxtotalPendingInterest.Location = new Point(194, 607);
      this.tbxtotalPendingInterest.Name = "tbxtotalPendingInterest";
      this.tbxtotalPendingInterest.Size = new Size(189, 29);
      this.tbxtotalPendingInterest.TabIndex = 91;
      this.tbxtotalPendingInterest.TextAlign = HorizontalAlignment.Center;
      this.textBox16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.textBox16.BackColor = Color.PowderBlue;
      this.textBox16.BorderStyle = BorderStyle.FixedSingle;
      this.textBox16.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox16.Location = new Point(382, 579);
      this.textBox16.Name = "textBox16";
      this.textBox16.Size = new Size(189, 29);
      this.textBox16.TabIndex = 95;
      this.textBox16.Text = "AMT + INT";
      this.textBox16.TextAlign = HorizontalAlignment.Center;
      this.tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel2.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.dgvArticles, 0, 0);
      this.tableLayoutPanel2.Location = new Point(0, 28);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.Size = new Size(707, 268);
      this.tableLayoutPanel2.TabIndex = 66;
      this.panel2.Controls.Add((Control) this.dgvAllPledge);
      this.panel2.Controls.Add((Control) this.dgvAuctionedPledges);
      this.panel2.Controls.Add((Control) this.dgvRedeemedPledges);
      this.panel2.Controls.Add((Control) this.dgvCustomerPledgeDetails);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 22);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(701, 340);
      this.panel2.TabIndex = 67;
      this.dgvAllPledge.AllowUserToAddRows = false;
      this.dgvAllPledge.AllowUserToDeleteRows = false;
      this.dgvAllPledge.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvAllPledge.BackgroundColor = Color.AliceBlue;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvAllPledge.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvAllPledge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAllPledge.ContextMenuStrip = this.contextMenuStrip2;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.Black;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvAllPledge.DefaultCellStyle = gridViewCellStyle2;
      this.dgvAllPledge.Dock = DockStyle.Fill;
      this.dgvAllPledge.GridColor = Color.OldLace;
      this.dgvAllPledge.Location = new Point(0, 0);
      this.dgvAllPledge.Name = "dgvAllPledge";
      this.dgvAllPledge.ReadOnly = true;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dgvAllPledge.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dgvAllPledge.Size = new Size(701, 340);
      this.dgvAllPledge.TabIndex = 61;
      this.dgvAuctionedPledges.AllowUserToAddRows = false;
      this.dgvAuctionedPledges.AllowUserToDeleteRows = false;
      this.dgvAuctionedPledges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = SystemColors.Control;
      gridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = SystemColors.WindowText;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.dgvAuctionedPledges.ColumnHeadersDefaultCellStyle = gridViewCellStyle4;
      this.dgvAuctionedPledges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAuctionedPledges.ContextMenuStrip = this.contextMenuStrip2;
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle5.BackColor = SystemColors.Window;
      gridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.Black;
      gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle5.WrapMode = DataGridViewTriState.False;
      this.dgvAuctionedPledges.DefaultCellStyle = gridViewCellStyle5;
      this.dgvAuctionedPledges.Dock = DockStyle.Fill;
      this.dgvAuctionedPledges.GridColor = Color.OldLace;
      this.dgvAuctionedPledges.Location = new Point(0, 0);
      this.dgvAuctionedPledges.Name = "dgvAuctionedPledges";
      this.dgvAuctionedPledges.ReadOnly = true;
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle6.BackColor = SystemColors.Control;
      gridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = SystemColors.WindowText;
      gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
      this.dgvAuctionedPledges.RowHeadersDefaultCellStyle = gridViewCellStyle6;
      this.dgvAuctionedPledges.Size = new Size(701, 340);
      this.dgvAuctionedPledges.TabIndex = 58;
      this.dgvAuctionedPledges.CellClick += new DataGridViewCellEventHandler(this.dgvAuctionedPledges_CellClick);
      this.dgvAuctionedPledges.CellMouseEnter += new DataGridViewCellEventHandler(this.dgvAuctionedPledges_CellMouseEnter);
      this.dgvAuctionedPledges.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvAuctionedPledges_DataBindingComplete);
      this.dgvAuctionedPledges.KeyUp += new KeyEventHandler(this.dgvAuctionedPledges_KeyUp);
      this.dgvRedeemedPledges.AllowUserToAddRows = false;
      this.dgvRedeemedPledges.AllowUserToDeleteRows = false;
      this.dgvRedeemedPledges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle7.BackColor = SystemColors.Control;
      gridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = SystemColors.WindowText;
      gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
      this.dgvRedeemedPledges.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
      this.dgvRedeemedPledges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRedeemedPledges.ContextMenuStrip = this.contextMenuStrip2;
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle8.BackColor = SystemColors.Window;
      gridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = Color.Black;
      gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
      this.dgvRedeemedPledges.DefaultCellStyle = gridViewCellStyle8;
      this.dgvRedeemedPledges.Dock = DockStyle.Fill;
      this.dgvRedeemedPledges.Location = new Point(0, 0);
      this.dgvRedeemedPledges.Name = "dgvRedeemedPledges";
      this.dgvRedeemedPledges.ReadOnly = true;
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle9.BackColor = SystemColors.Control;
      gridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle9.ForeColor = SystemColors.WindowText;
      gridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
      this.dgvRedeemedPledges.RowHeadersDefaultCellStyle = gridViewCellStyle9;
      this.dgvRedeemedPledges.Size = new Size(701, 340);
      this.dgvRedeemedPledges.TabIndex = 1;
      this.dgvRedeemedPledges.Visible = false;
      this.dgvRedeemedPledges.CellClick += new DataGridViewCellEventHandler(this.dgvRedeemedPledges_CellClick);
      this.dgvRedeemedPledges.CellMouseEnter += new DataGridViewCellEventHandler(this.dgvRedeemedPledges_CellMouseEnter);
      this.dgvRedeemedPledges.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvRedeemedPledges_DataBindingComplete);
      this.dgvRedeemedPledges.KeyUp += new KeyEventHandler(this.dgvRedeemedPledges_KeyUp);
      this.dgvCustomerPledgeDetails.AllowUserToAddRows = false;
      this.dgvCustomerPledgeDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvCustomerPledgeDetails.BorderStyle = BorderStyle.None;
      this.dgvCustomerPledgeDetails.CellBorderStyle = DataGridViewCellBorderStyle.None;
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle10.BackColor = SystemColors.Control;
      gridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle10.ForeColor = SystemColors.WindowText;
      gridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle10.WrapMode = DataGridViewTriState.True;
      this.dgvCustomerPledgeDetails.ColumnHeadersDefaultCellStyle = gridViewCellStyle10;
      this.dgvCustomerPledgeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvCustomerPledgeDetails.Columns.AddRange((DataGridViewColumn) this.colSelect);
      this.dgvCustomerPledgeDetails.ContextMenuStrip = this.contextMenuStrip2;
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle11.BackColor = SystemColors.Window;
      gridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle11.ForeColor = Color.Black;
      gridViewCellStyle11.SelectionBackColor = Color.LawnGreen;
      gridViewCellStyle11.SelectionForeColor = Color.Black;
      gridViewCellStyle11.WrapMode = DataGridViewTriState.False;
      this.dgvCustomerPledgeDetails.DefaultCellStyle = gridViewCellStyle11;
      this.dgvCustomerPledgeDetails.Dock = DockStyle.Fill;
      this.dgvCustomerPledgeDetails.Location = new Point(0, 0);
      this.dgvCustomerPledgeDetails.Name = "dgvCustomerPledgeDetails";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle12.BackColor = SystemColors.Control;
      gridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = SystemColors.WindowText;
      gridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle12.WrapMode = DataGridViewTriState.True;
      this.dgvCustomerPledgeDetails.RowHeadersDefaultCellStyle = gridViewCellStyle12;
      this.dgvCustomerPledgeDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dgvCustomerPledgeDetails.Size = new Size(701, 340);
      this.dgvCustomerPledgeDetails.TabIndex = 60;
      this.dgvCustomerPledgeDetails.Visible = false;
      this.dgvCustomerPledgeDetails.CellClick += new DataGridViewCellEventHandler(this.dgvCustomerPledgeDetails_CellClick);
      this.dgvCustomerPledgeDetails.CellMouseEnter += new DataGridViewCellEventHandler(this.dgvCustomerPledgeDetails_CellMouseEnter);
      this.dgvCustomerPledgeDetails.CurrentCellDirtyStateChanged += new EventHandler(this.dgvCustomerPledgeDetails_CurrentCellDirtyStateChanged);
      this.dgvCustomerPledgeDetails.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomerPledgeDetails_DataBindingComplete);
      this.dgvCustomerPledgeDetails.Enter += new EventHandler(this.dgvCustomerPledgeDetails_Enter);
      this.dgvCustomerPledgeDetails.KeyUp += new KeyEventHandler(this.dgvCustomerPledgeDetails_KeyUp);
      this.colSelect.HeaderText = "Select";
      this.colSelect.IndeterminateValue = (object) "false";
      this.colSelect.Name = "colSelect";
      this.colSelect.Width = 43;
      ((DataGridView) this.dgvArticles).AllowUserToAddRows = false;
      ((DataGridView) this.dgvArticles).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      ((DataGridView) this.dgvArticles).BackgroundColor = SystemColors.ButtonHighlight;
      ((DataGridView) this.dgvArticles).BorderStyle = BorderStyle.None;
      ((DataGridView) this.dgvArticles).CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle13.BackColor = Color.SkyBlue;
      gridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle13.ForeColor = Color.DarkBlue;
      gridViewCellStyle13.Padding = new Padding(5);
      ((DataGridView) this.dgvArticles).ColumnHeadersDefaultCellStyle = gridViewCellStyle13;
      ((DataGridView) this.dgvArticles).ColumnHeadersHeight = 30;
      ((Control) this.dgvArticles).ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle14.BackColor = SystemColors.Window;
      gridViewCellStyle14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle14.ForeColor = Color.Black;
      gridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle14.WrapMode = DataGridViewTriState.False;
      ((DataGridView) this.dgvArticles).DefaultCellStyle = gridViewCellStyle14;
      ((Control) this.dgvArticles).Dock = DockStyle.Fill;
      ((DataGridView) this.dgvArticles).EditMode = DataGridViewEditMode.EditOnEnter;
      ((DataGridView) this.dgvArticles).EnableHeadersVisualStyles = false;
      ((DataGridView) this.dgvArticles).GridColor = Color.LightBlue;
      ((Control) this.dgvArticles).Location = new Point(3, 3);
      ((Control) this.dgvArticles).Name = "dgvArticles";
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle15.BackColor = SystemColors.Info;
      gridViewCellStyle15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle15.ForeColor = SystemColors.WindowText;
      gridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle15.WrapMode = DataGridViewTriState.True;
      ((DataGridView) this.dgvArticles).RowHeadersDefaultCellStyle = gridViewCellStyle15;
      ((DataGridView) this.dgvArticles).RowHeadersVisible = false;
      ((Control) this.dgvArticles).Size = new Size(701, 13);
      ((Control) this.dgvArticles).TabIndex = 0;
      ((DataGridView) this.dgvArticles).CellClick += new DataGridViewCellEventHandler(this.dgvArticles_CellClick);
      ((DataGridView) this.dgvArticles).CurrentCellChanged += new EventHandler(this.dgvArticles_CurrentCellChanged);
      ((DataGridView) this.dgvArticles).EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewEx2_EditingControlShowing);
      ((DataGridView) this.dgvArticles).RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvArticles_RowsAdded);
      ((Control) this.dgvArticles).Enter += new EventHandler(this.dgvArticles_Enter);
      ((Control) this.dgvArticles).KeyUp += new KeyEventHandler(this.dgvArticles_KeyUp);
      ((Control) this.dgvArticles).Validating += new CancelEventHandler(this.dgvArticles_Validating);
      this.tbxTotalAmountPlusInterest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.tbxTotalAmountPlusInterest.BackColor = Color.Azure;
      this.tbxTotalAmountPlusInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotalAmountPlusInterest.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmountPlusInterest.Location = new Point(382, 607);
      this.tbxTotalAmountPlusInterest.Name = "tbxTotalAmountPlusInterest";
      this.tbxTotalAmountPlusInterest.Size = new Size(189, 29);
      this.tbxTotalAmountPlusInterest.TabIndex = 92;
      this.tbxTotalAmountPlusInterest.TextAlign = HorizontalAlignment.Center;
      this.textBox17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox17.BackColor = Color.PowderBlue;
      this.textBox17.BorderStyle = BorderStyle.FixedSingle;
      this.textBox17.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox17.Location = new Point(569, 579);
      this.textBox17.Name = "textBox17";
      this.textBox17.Size = new Size(150, 29);
      this.textBox17.TabIndex = 96;
      this.textBox17.Text = "VIEW";
      this.textBox17.TextAlign = HorizontalAlignment.Center;
      this.cbView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbView.BackColor = Color.Azure;
      this.cbView.DropDownWidth = 600;
      this.cbView.Font = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbView.FormattingEnabled = true;
      this.cbView.Items.AddRange(new object[4]
      {
        (object) "ALL",
        (object) "PENDING",
        (object) "RELEASED",
        (object) "AUCTIONED"
      });
      this.cbView.Location = new Point(569, 607);
      this.cbView.Name = "cbView";
      this.cbView.Size = new Size(150, 28);
      this.cbView.TabIndex = 89;
      this.cbView.SelectedIndexChanged += new EventHandler(this.cbView_SelectedIndexChanged);
      this.dgvCustomerDetails.AllowUserToAddRows = false;
      this.dgvCustomerDetails.AllowUserToDeleteRows = false;
      this.dgvCustomerDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle16.BackColor = SystemColors.Control;
      gridViewCellStyle16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle16.ForeColor = SystemColors.WindowText;
      gridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle16.WrapMode = DataGridViewTriState.True;
      this.dgvCustomerDetails.ColumnHeadersDefaultCellStyle = gridViewCellStyle16;
      this.dgvCustomerDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle17.BackColor = SystemColors.Window;
      gridViewCellStyle17.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle17.ForeColor = Color.Black;
      gridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle17.WrapMode = DataGridViewTriState.False;
      this.dgvCustomerDetails.DefaultCellStyle = gridViewCellStyle17;
      this.dgvCustomerDetails.GridColor = Color.OldLace;
      this.dgvCustomerDetails.Location = new Point(150, 116);
      this.dgvCustomerDetails.Name = "dgvCustomerDetails";
      this.dgvCustomerDetails.ReadOnly = true;
      this.dgvCustomerDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvCustomerDetails.Size = new Size(850, 452);
      this.dgvCustomerDetails.TabIndex = 99;
      this.dgvCustomerDetails.Visible = false;
      this.dgvCustomerDetails.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvCustomerDetails_DataBindingComplete);
      this.dgvCustomerDetails.KeyDown += new KeyEventHandler(this.dgvCustomerDetails_KeyDown);
      this.dgvCustomerDetails.KeyUp += new KeyEventHandler(this.dgvCustomerDetails_KeyUp);
      this.dgvCustomerDetails.Leave += new EventHandler(this.dgvCustomerDetails_Leave);
      this.dgvPendingPledges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      gridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle18.BackColor = SystemColors.Control;
      gridViewCellStyle18.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle18.ForeColor = SystemColors.WindowText;
      gridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle18.WrapMode = DataGridViewTriState.True;
      this.dgvPendingPledges.ColumnHeadersDefaultCellStyle = gridViewCellStyle18;
      this.dgvPendingPledges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle19.BackColor = SystemColors.Window;
      gridViewCellStyle19.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle19.ForeColor = Color.Black;
      gridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle19.WrapMode = DataGridViewTriState.False;
      this.dgvPendingPledges.DefaultCellStyle = gridViewCellStyle19;
      this.dgvPendingPledges.GridColor = Color.OldLace;
      this.dgvPendingPledges.Location = new Point(331, 133);
      this.dgvPendingPledges.Name = "dgvPendingPledges";
      this.dgvPendingPledges.Size = new Size(615, 314);
      this.dgvPendingPledges.TabIndex = 41;
      this.dgvPendingPledges.Visible = false;
      this.dgvPendingPledges.KeyDown += new KeyEventHandler(this.dgvPendingPledges_KeyDown);
      this.backgroundWorker2.DoWork += new DoWorkEventHandler(this.backgroundWorker2_DoWork);
      this.backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
      this.cmsDeletePledge.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem1
      });
      this.cmsDeletePledge.Name = "contextMenuStrip1";
      this.cmsDeletePledge.Size = new Size(108, 26);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(107, 22);
      this.toolStripMenuItem1.Text = "Delete";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.panel4.BackColor = Color.Azure;
      this.panel4.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.textBox28);
      this.panel4.Controls.Add((Control) this.tbxIncome);
      this.panel4.Controls.Add((Control) this.textBox27);
      this.panel4.Controls.Add((Control) this.tbxPurpose);
      this.panel4.Controls.Add((Control) this.textBox26);
      this.panel4.Controls.Add((Control) this.tbxReleaseDate);
      this.panel4.Controls.Add((Control) this.btnJewelPhoto);
      this.panel4.Controls.Add((Control) this.pbJewelPhoto);
      this.panel4.Controls.Add((Control) this.panel9);
      this.panel4.Controls.Add((Control) this.btnSave);
      this.panel4.Controls.Add((Control) this.cbType);
      this.panel4.Controls.Add((Control) this.textBox5);
      this.panel4.Controls.Add((Control) this.textBox13);
      this.panel4.Controls.Add((Control) this.textBox4);
      this.panel4.Controls.Add((Control) this.tbxValue);
      this.panel4.Controls.Add((Control) this.tbxDeductions);
      this.panel4.Controls.Add((Control) this.tbxPureWeight);
      this.panel4.Controls.Add((Control) this.textBox3);
      this.panel4.Controls.Add((Control) this.tbxAmount);
      this.panel4.Controls.Add((Control) this.tbxOldBillNumber);
      this.panel4.Controls.Add((Control) this.textBox12);
      this.panel4.Controls.Add((Control) this.tbxweight);
      this.panel4.Controls.Add((Control) this.tbxInteresRate);
      this.panel4.Controls.Add((Control) this.textBox6);
      this.panel4.Controls.Add((Control) this.textBox11);
      this.panel4.Controls.Add((Control) this.textBox2);
      this.panel4.Controls.Add((Control) this.tbxNetWeight);
      this.panel4.Controls.Add((Control) this.tbxReminder);
      this.panel4.Controls.Add((Control) this.textBox10);
      this.panel4.Controls.Add((Control) this.textBox1);
      this.panel4.Controls.Add((Control) this.tbxChit);
      this.panel4.Controls.Add((Control) this.textBox7);
      this.panel4.Controls.Add((Control) this.textBox9);
      this.panel4.Controls.Add((Control) this.tbxPay);
      this.panel4.Controls.Add((Control) this.tbxTotalInterest);
      this.panel4.Controls.Add((Control) this.textBox8);
      this.panel4.Location = new Point(725, 8);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(292, 630);
      this.panel4.TabIndex = 97;
      this.textBox28.Anchor = AnchorStyles.None;
      this.textBox28.BackColor = Color.Azure;
      this.textBox28.BorderStyle = BorderStyle.None;
      this.textBox28.CharacterCasing = CharacterCasing.Upper;
      this.textBox28.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox28.ForeColor = Color.DarkBlue;
      this.textBox28.Location = new Point(-14, 192);
      this.textBox28.MaxLength = 4;
      this.textBox28.Name = "textBox28";
      this.textBox28.Size = new Size(131, 22);
      this.textBox28.TabIndex = 107;
      this.textBox28.Text = "INCOME";
      this.textBox28.TextAlign = HorizontalAlignment.Right;
      this.tbxIncome.Anchor = AnchorStyles.None;
      this.tbxIncome.BackColor = SystemColors.ControlLightLight;
      this.tbxIncome.BorderStyle = BorderStyle.FixedSingle;
      this.tbxIncome.CharacterCasing = CharacterCasing.Upper;
      this.tbxIncome.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxIncome.ForeColor = Color.Black;
      this.tbxIncome.Location = new Point(133, 188);
      this.tbxIncome.MaxLength = 10;
      this.tbxIncome.Name = "tbxIncome";
      this.tbxIncome.Size = new Size(144, 29);
      this.tbxIncome.TabIndex = 106;
      this.tbxIncome.TextAlign = HorizontalAlignment.Right;
      this.tbxIncome.KeyDown += new KeyEventHandler(this.tbxIncome_KeyDown);
      this.textBox27.Anchor = AnchorStyles.None;
      this.textBox27.BackColor = Color.Azure;
      this.textBox27.BorderStyle = BorderStyle.None;
      this.textBox27.CharacterCasing = CharacterCasing.Upper;
      this.textBox27.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox27.ForeColor = Color.DarkBlue;
      this.textBox27.Location = new Point(-14, 160);
      this.textBox27.MaxLength = 4;
      this.textBox27.Name = "textBox27";
      this.textBox27.Size = new Size(131, 22);
      this.textBox27.TabIndex = 105;
      this.textBox27.Text = "PURPOSE";
      this.textBox27.TextAlign = HorizontalAlignment.Right;
      this.tbxPurpose.Anchor = AnchorStyles.None;
      this.tbxPurpose.BackColor = SystemColors.ControlLightLight;
      this.tbxPurpose.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPurpose.CharacterCasing = CharacterCasing.Upper;
      this.tbxPurpose.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPurpose.ForeColor = Color.Black;
      this.tbxPurpose.Location = new Point(133, 157);
      this.tbxPurpose.MaxLength = 10;
      this.tbxPurpose.Name = "tbxPurpose";
      this.tbxPurpose.Size = new Size(144, 29);
      this.tbxPurpose.TabIndex = 104;
      this.tbxPurpose.TextAlign = HorizontalAlignment.Right;
      this.tbxPurpose.KeyDown += new KeyEventHandler(this.tbxPurpose_KeyDown);
      this.textBox26.Anchor = AnchorStyles.None;
      this.textBox26.BackColor = Color.Azure;
      this.textBox26.BorderStyle = BorderStyle.None;
      this.textBox26.CharacterCasing = CharacterCasing.Upper;
      this.textBox26.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox26.ForeColor = Color.DarkBlue;
      this.textBox26.Location = new Point(-13, 129);
      this.textBox26.MaxLength = 4;
      this.textBox26.Name = "textBox26";
      this.textBox26.Size = new Size(131, 22);
      this.textBox26.TabIndex = 103;
      this.textBox26.Text = "RELEASE DT";
      this.textBox26.TextAlign = HorizontalAlignment.Right;
      this.tbxReleaseDate.Anchor = AnchorStyles.None;
      this.tbxReleaseDate.BackColor = SystemColors.ControlLightLight;
      this.tbxReleaseDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReleaseDate.CharacterCasing = CharacterCasing.Upper;
      this.tbxReleaseDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReleaseDate.ForeColor = Color.Black;
      this.tbxReleaseDate.Location = new Point(133, 125);
      this.tbxReleaseDate.MaxLength = 10;
      this.tbxReleaseDate.Name = "tbxReleaseDate";
      this.tbxReleaseDate.Size = new Size(144, 29);
      this.tbxReleaseDate.TabIndex = 102;
      this.tbxReleaseDate.TextAlign = HorizontalAlignment.Right;
      this.tbxReleaseDate.Enter += new EventHandler(this.tbxReleaseDate_Enter);
      this.tbxReleaseDate.KeyDown += new KeyEventHandler(this.tbxReleaseDate_KeyDown);
      ((Control) this.btnJewelPhoto).Anchor = AnchorStyles.None;
      this.btnJewelPhoto.BackColor = Color.Transparent;
      this.btnJewelPhoto.FadeOnFocus = true;
      this.btnJewelPhoto.ForeColor = Color.MediumBlue;
      this.btnJewelPhoto.ForeColorOnFocus = Color.Red;
      this.btnJewelPhoto.ForeColorOnLeave = Color.RoyalBlue;
      this.btnJewelPhoto.GlowColor = Color.Transparent;
      this.btnJewelPhoto.InnerBorderColor = Color.Transparent;
      ((Control) this.btnJewelPhoto).Location = new Point(4, 598);
      ((Control) this.btnJewelPhoto).Name = "btnJewelPhoto";
      this.btnJewelPhoto.OuterBorderColor = Color.MediumSlateBlue;
      this.btnJewelPhoto.ShineColor = Color.Transparent;
      ((Control) this.btnJewelPhoto).Size = new Size(76, 23);
      ((Control) this.btnJewelPhoto).TabIndex = 101;
      ((Control) this.btnJewelPhoto).Text = "&Jewel Photo";
      ((Control) this.btnJewelPhoto).Click += new EventHandler(this.btnJewelPhoto_Click);
      this.pbJewelPhoto.Anchor = AnchorStyles.None;
      this.pbJewelPhoto.Location = new Point(8, 503);
      this.pbJewelPhoto.Name = "pbJewelPhoto";
      this.pbJewelPhoto.Size = new Size(65, 91);
      this.pbJewelPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbJewelPhoto.TabIndex = 100;
      this.pbJewelPhoto.TabStop = false;
      this.panel9.BackColor = Color.PowderBlue;
      this.panel9.Controls.Add((Control) this.label5);
      this.panel9.Location = new Point(-1, -1);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(299, 26);
      this.panel9.TabIndex = 99;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(2, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(115, 16);
      this.label5.TabIndex = 2;
      this.label5.Text = "LOAN DETAILS";
      this.btnSave.Anchor = AnchorStyles.None;
      this.btnSave.BackColor = Color.AliceBlue;
      this.btnSave.FlatStyle = FlatStyle.Flat;
      this.btnSave.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MidnightBlue;
      this.btnSave.Location = new Point(134, 533);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(144, 34);
      this.btnSave.TabIndex = 71;
      this.btnSave.Text = "&SAVE";
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new EventHandler(this.button2_Click);
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel1.BackColor = Color.PowderBlue;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.tbxBillDate);
      this.panel1.Location = new Point(507, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(214, 50);
      this.panel1.TabIndex = 6;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(3, 5);
      this.label3.Name = "label3";
      this.label3.Size = new Size(83, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "BILL DATE";
      this.tbxBillDate.BackColor = Color.Azure;
      this.tbxBillDate.BorderStyle = BorderStyle.None;
      this.tbxBillDate.Dock = DockStyle.Bottom;
      this.tbxBillDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillDate.Location = new Point(0, 26);
      this.tbxBillDate.MaxLength = 10;
      this.tbxBillDate.Name = "tbxBillDate";
      this.tbxBillDate.Size = new Size(212, 22);
      this.tbxBillDate.TabIndex = 0;
      this.tbxBillDate.TextAlign = HorizontalAlignment.Center;
      this.tbxBillDate.TextChanged += new EventHandler(this.tbxBillDate_TextChanged);
      this.tbxBillDate.Enter += new EventHandler(this.tbxBillDate_Enter);
      this.tbxBillDate.KeyDown += new KeyEventHandler(this.tbxBillDate_KeyDown);
      this.tbxBillDate.KeyPress += new KeyPressEventHandler(this.tbxBillDate_KeyPress);
      this.tbxBillDate.Validating += new CancelEventHandler(this.tbxBillDate_Validating);
      this.panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel5.BackColor = Color.PowderBlue;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.label2);
      this.panel5.Controls.Add((Control) this.cbShopCodes);
      this.panel5.Location = new Point(209, 8);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(296, 50);
      this.panel5.TabIndex = 5;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new Size(133, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "SELECT LICENSE";
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.Azure;
      this.cbShopCodes.Dock = DockStyle.Bottom;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FlatStyle = FlatStyle.Popup;
      this.cbShopCodes.Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 25);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(294, 23);
      this.cbShopCodes.TabIndex = 0;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbShopCodes.Enter += new EventHandler(this.cbShopCodes_Enter);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      this.panel6.BackColor = Color.PowderBlue;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.label1);
      this.panel6.Controls.Add((Control) this.tbxBillNumber);
      this.panel6.Location = new Point(10, 8);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(197, 50);
      this.panel6.TabIndex = 25;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(3, 5);
      this.label1.Name = "label1";
      this.label1.Size = new Size(107, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "BILL NUMBER";
      this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber.BackColor = Color.Azure;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Dock = DockStyle.Bottom;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 26);
      this.tbxBillNumber.MaxLength = 6;
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(195, 22);
      this.tbxBillNumber.TabIndex = 0;
      this.tbxBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber.TextChanged += new EventHandler(this.tbxBillNumber_TextChanged);
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.tbxBillNumber_KeyDown);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.Validating += new CancelEventHandler(this.tbxBillNumber_Validating);
      this.panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.panel7);
      this.panel3.Controls.Add((Control) this.tbxCustomerName);
      this.panel3.Controls.Add((Control) this.textBox19);
      this.panel3.Controls.Add((Control) this.tbxPincode);
      this.panel3.Controls.Add((Control) this.tbxCell);
      this.panel3.Controls.Add((Control) this.tbxCustomerCode);
      this.panel3.Controls.Add((Control) this.tbxAddress1);
      this.panel3.Controls.Add((Control) this.tbxNumber);
      this.panel3.Controls.Add((Control) this.tbxAddress2);
      this.panel3.Controls.Add((Control) this.tbxAddress3);
      this.panel3.Controls.Add((Control) this.textBox18);
      this.panel3.Controls.Add((Control) this.textBox20);
      this.panel3.Controls.Add((Control) this.textBox21);
      this.panel3.Controls.Add((Control) this.textBox22);
      this.panel3.Controls.Add((Control) this.textBox23);
      this.panel3.Controls.Add((Control) this.textBox24);
      this.panel3.Controls.Add((Control) this.textBox25);
      this.panel3.Controls.Add((Control) this.pbFingerPrint);
      this.panel3.Controls.Add((Control) this.tbxPhoneNumber);
      this.panel3.Controls.Add((Control) this.tbxCity);
      this.panel3.Controls.Add((Control) this.tbxNotes);
      this.panel3.Controls.Add((Control) this.btnAdd);
      this.panel3.Controls.Add((Control) this.btnEdit);
      this.panel3.Controls.Add((Control) this.pictureBox2);
      this.panel3.Controls.Add((Control) this.tbxAverageNumberOfDaysForRelease);
      this.panel3.Controls.Add((Control) this.tbxNumberOfTimesReleaseExceedTwelveMonths);
      this.panel3.Location = new Point(10, 62);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(711, 208);
      this.panel3.TabIndex = 86;
      this.panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel7.BackColor = Color.PowderBlue;
      this.panel7.Controls.Add((Control) this.label4);
      this.panel7.Location = new Point(-1, -1);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(713, 26);
      this.panel7.TabIndex = 98;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(2, 5);
      this.label4.Name = "label4";
      this.label4.Size = new Size(160, 16);
      this.label4.TabIndex = 2;
      this.label4.Text = "CUSTOMER DETAILS";
      this.tbxCustomerName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(268, 30);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(281, 22);
      this.tbxCustomerName.TabIndex = 0;
      this.tbxCustomerName.TextChanged += new EventHandler(this.tbxCustomerName_TextChanged);
      this.tbxCustomerName.Enter += new EventHandler(this.tbxCustomerName_Enter);
      this.tbxCustomerName.KeyDown += new KeyEventHandler(this.tbxCustomerName_KeyDown);
      this.textBox19.BackColor = Color.Azure;
      this.textBox19.BorderStyle = BorderStyle.None;
      this.textBox19.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox19.ForeColor = Color.MidnightBlue;
      this.textBox19.Location = new Point(138, 33);
      this.textBox19.Name = "textBox19";
      this.textBox19.Size = new Size(130, 15);
      this.textBox19.TabIndex = 97;
      this.textBox19.Text = "CUSTOMER NAME";
      this.tbxPincode.BackColor = Color.Azure;
      this.tbxPincode.BorderStyle = BorderStyle.None;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.ForeColor = Color.MidnightBlue;
      this.tbxPincode.Location = new Point(486, 159);
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(201, 15);
      this.tbxPincode.TabIndex = 10;
      this.tbxCell.BackColor = Color.Azure;
      this.tbxCell.BorderStyle = BorderStyle.None;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.ForeColor = Color.MidnightBlue;
      this.tbxCell.Location = new Point(486, 180);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(201, 15);
      this.tbxCell.TabIndex = 22;
      this.tbxCustomerCode.BackColor = Color.Azure;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.ForeColor = Color.MidnightBlue;
      this.tbxCustomerCode.Location = new Point(268, 54);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(419, 15);
      this.tbxCustomerCode.TabIndex = 94;
      this.tbxCustomerCode.TextChanged += new EventHandler(this.tbxCustomerCode_TextChanged);
      this.tbxAddress1.BackColor = Color.Azure;
      this.tbxAddress1.BorderStyle = BorderStyle.None;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.ForeColor = Color.MidnightBlue;
      this.tbxAddress1.Location = new Point(268, 96);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(419, 15);
      this.tbxAddress1.TabIndex = 5;
      this.tbxNumber.BackColor = Color.Azure;
      this.tbxNumber.BorderStyle = BorderStyle.None;
      this.tbxNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumber.ForeColor = Color.MidnightBlue;
      this.tbxNumber.Location = new Point(268, 75);
      this.tbxNumber.Name = "tbxNumber";
      this.tbxNumber.Size = new Size(419, 15);
      this.tbxNumber.TabIndex = 27;
      this.tbxAddress2.BackColor = Color.Azure;
      this.tbxAddress2.BorderStyle = BorderStyle.None;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.ForeColor = Color.MidnightBlue;
      this.tbxAddress2.Location = new Point(268, 117);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(419, 15);
      this.tbxAddress2.TabIndex = 6;
      this.tbxAddress3.BackColor = Color.Azure;
      this.tbxAddress3.BorderStyle = BorderStyle.None;
      this.tbxAddress3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress3.ForeColor = Color.MidnightBlue;
      this.tbxAddress3.Location = new Point(268, 138);
      this.tbxAddress3.Name = "tbxAddress3";
      this.tbxAddress3.Size = new Size(419, 15);
      this.tbxAddress3.TabIndex = 8;
      this.textBox18.BackColor = Color.Azure;
      this.textBox18.BorderStyle = BorderStyle.None;
      this.textBox18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox18.ForeColor = Color.MidnightBlue;
      this.textBox18.Location = new Point(139, 54);
      this.textBox18.Name = "textBox18";
      this.textBox18.Size = new Size(130, 15);
      this.textBox18.TabIndex = 95;
      this.textBox18.Text = "CUSTOMER CODE";
      this.textBox20.BackColor = Color.Azure;
      this.textBox20.BorderStyle = BorderStyle.None;
      this.textBox20.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox20.ForeColor = Color.MidnightBlue;
      this.textBox20.Location = new Point(139, 180);
      this.textBox20.Name = "textBox20";
      this.textBox20.Size = new Size(130, 15);
      this.textBox20.TabIndex = 91;
      this.textBox20.Text = "MOBILE NO";
      this.textBox21.BackColor = Color.Azure;
      this.textBox21.BorderStyle = BorderStyle.None;
      this.textBox21.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox21.ForeColor = Color.MidnightBlue;
      this.textBox21.Location = new Point(139, 159);
      this.textBox21.Name = "textBox21";
      this.textBox21.Size = new Size(130, 15);
      this.textBox21.TabIndex = 90;
      this.textBox21.Text = "CITY";
      this.textBox22.BackColor = Color.Azure;
      this.textBox22.BorderStyle = BorderStyle.None;
      this.textBox22.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox22.ForeColor = Color.MidnightBlue;
      this.textBox22.Location = new Point(139, 138);
      this.textBox22.Name = "textBox22";
      this.textBox22.Size = new Size(130, 15);
      this.textBox22.TabIndex = 89;
      this.textBox22.Text = "LOCATION";
      this.textBox23.BackColor = Color.Azure;
      this.textBox23.BorderStyle = BorderStyle.None;
      this.textBox23.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox23.ForeColor = Color.MidnightBlue;
      this.textBox23.Location = new Point(139, 117);
      this.textBox23.Name = "textBox23";
      this.textBox23.Size = new Size(130, 15);
      this.textBox23.TabIndex = 88;
      this.textBox23.Text = "ADDRESS2";
      this.textBox24.BackColor = Color.Azure;
      this.textBox24.BorderStyle = BorderStyle.None;
      this.textBox24.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox24.ForeColor = Color.MidnightBlue;
      this.textBox24.Location = new Point(139, 96);
      this.textBox24.Name = "textBox24";
      this.textBox24.Size = new Size(130, 15);
      this.textBox24.TabIndex = 87;
      this.textBox24.Text = "ADDRESS1";
      this.textBox25.BackColor = Color.Azure;
      this.textBox25.BorderStyle = BorderStyle.None;
      this.textBox25.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox25.ForeColor = Color.MidnightBlue;
      this.textBox25.Location = new Point(139, 75);
      this.textBox25.Name = "textBox25";
      this.textBox25.Size = new Size(130, 15);
      this.textBox25.TabIndex = 86;
      this.textBox25.Text = "NO";
      this.pbFingerPrint.Location = new Point(560, 59);
      this.pbFingerPrint.Name = "pbFingerPrint";
      this.pbFingerPrint.Size = new Size(133, 148);
      this.pbFingerPrint.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbFingerPrint.TabIndex = 31;
      this.pbFingerPrint.TabStop = false;
      this.pbFingerPrint.Visible = false;
      this.tbxPhoneNumber.BackColor = Color.Azure;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.None;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.ForeColor = Color.MidnightBlue;
      this.tbxPhoneNumber.Location = new Point(268, 180);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(221, 15);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxCity.BackColor = Color.Azure;
      this.tbxCity.BorderStyle = BorderStyle.None;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.ForeColor = Color.MidnightBlue;
      this.tbxCity.Location = new Point(268, 159);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(221, 15);
      this.tbxCity.TabIndex = 9;
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(0, 185);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(135, 22);
      this.tbxNotes.TabIndex = 28;
      this.tbxNotes.Visible = false;
      this.btnAdd.BackColor = Color.LightBlue;
      this.btnAdd.FadeOnFocus = true;
      this.btnAdd.ForeColor = Color.MediumBlue;
      this.btnAdd.ForeColorOnFocus = Color.Red;
      this.btnAdd.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAdd.GlowColor = Color.White;
      this.btnAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAdd).Location = new Point(615, 30);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.Transparent;
      ((Control) this.btnAdd).Size = new Size(80, 23);
      ((Control) this.btnAdd).TabIndex = 30;
      ((Control) this.btnAdd).Text = "&Add(f12)";
      ((Control) this.btnAdd).Click += new EventHandler(this.glassButton1_Click_2);
      this.btnEdit.BackColor = Color.LightBlue;
      this.btnEdit.FadeOnFocus = true;
      this.btnEdit.ForeColor = Color.MediumBlue;
      this.btnEdit.ForeColorOnFocus = Color.Red;
      this.btnEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnEdit.GlowColor = Color.White;
      this.btnEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnEdit).Location = new Point(562, 30);
      ((Control) this.btnEdit).Name = "btnEdit";
      this.btnEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnEdit.ShineColor = Color.Transparent;
      ((Control) this.btnEdit).Size = new Size(49, 23);
      ((Control) this.btnEdit).TabIndex = 29;
      ((Control) this.btnEdit).Text = "E&dit";
      ((Control) this.btnEdit).Click += new EventHandler(this.btnEdit_Click);
      this.pictureBox2.Location = new Point(-1, 27);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(136, 159);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.DoubleClick += new EventHandler(this.pictureBox2_DoubleClick);
      this.tbxAverageNumberOfDaysForRelease.BackColor = Color.AliceBlue;
      this.tbxAverageNumberOfDaysForRelease.BorderStyle = BorderStyle.None;
      this.tbxAverageNumberOfDaysForRelease.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAverageNumberOfDaysForRelease.Location = new Point(40, 76);
      this.tbxAverageNumberOfDaysForRelease.Name = "tbxAverageNumberOfDaysForRelease";
      this.tbxAverageNumberOfDaysForRelease.ReadOnly = true;
      this.tbxAverageNumberOfDaysForRelease.Size = new Size(57, 15);
      this.tbxAverageNumberOfDaysForRelease.TabIndex = 10;
      this.tbxAverageNumberOfDaysForRelease.TextAlign = HorizontalAlignment.Center;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BackColor = Color.AliceBlue;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BorderStyle = BorderStyle.None;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Location = new Point(40, 97);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Name = "tbxNumberOfTimesReleaseExceedTwelveMonths";
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.ReadOnly = true;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Size = new Size(57, 15);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TabIndex = 9;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TextAlign = HorizontalAlignment.Center;
      this.panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel8.BackColor = Color.AliceBlue;
      this.panel8.BorderStyle = BorderStyle.FixedSingle;
      this.panel8.Controls.Add((Control) this.panel10);
      this.panel8.Controls.Add((Control) this.tableLayoutPanel2);
      this.panel8.Location = new Point(10, 272);
      this.panel8.Name = "panel8";
      this.panel8.Size = new Size(709, 301);
      this.panel8.TabIndex = 61;
      this.panel10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel10.BackColor = Color.PowderBlue;
      this.panel10.Controls.Add((Control) this.label6);
      this.panel10.Location = new Point(-1, -1);
      this.panel10.Name = "panel10";
      this.panel10.Size = new Size(711, 26);
      this.panel10.TabIndex = 99;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(2, 5);
      this.label6.Name = "label6";
      this.label6.Size = new Size(324, 16);
      this.label6.TabIndex = 2;
      this.label6.Text = "DETAILED DESCRIPTION OF THE ARTICLES";
      this.contextMenuStrip3.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem1,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem1,
        (ToolStripItem) this.exportToExcelToolStripMenuItem1
      });
      this.contextMenuStrip3.Name = "contextMenuStrip3";
      this.contextMenuStrip3.Size = new Size(189, 70);
      this.changeColumnOrderToolStripMenuItem1.Name = "changeColumnOrderToolStripMenuItem1";
      this.changeColumnOrderToolStripMenuItem1.Size = new Size(188, 22);
      this.changeColumnOrderToolStripMenuItem1.Text = "ChangeColumnOrder";
      this.changeColumnOrderToolStripMenuItem1.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem1_Click);
      this.viewFullScreenToolStripMenuItem1.Name = "viewFullScreenToolStripMenuItem1";
      this.viewFullScreenToolStripMenuItem1.Size = new Size(188, 22);
      this.viewFullScreenToolStripMenuItem1.Text = "View Full Screen";
      this.exportToExcelToolStripMenuItem1.Name = "exportToExcelToolStripMenuItem1";
      this.exportToExcelToolStripMenuItem1.Size = new Size(188, 22);
      this.exportToExcelToolStripMenuItem1.Text = "Export To Excel";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Azure;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1022, 640);
      this.Controls.Add((Control) this.textBox14);
      this.Controls.Add((Control) this.textBox15);
      this.Controls.Add((Control) this.tbxTotalAmount);
      this.Controls.Add((Control) this.textBox16);
      this.Controls.Add((Control) this.tbxtotalPendingInterest);
      this.Controls.Add((Control) this.panel4);
      this.Controls.Add((Control) this.tbxTotalAmountPlusInterest);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.textBox17);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.cbView);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.panel6);
      this.Controls.Add((Control) this.dgvCustomerDetails);
      this.Controls.Add((Control) this.dgvPendingPledges);
      this.Controls.Add((Control) this.panel8);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = Color.Black;
      this.FormBorderStyle = FormBorderStyle.None;
      this.KeyPreview = true;
      this.MinimumSize = new Size(1022, 620);
      this.Name = nameof (FormPledgePledge);
      this.Text = "PLEDGE";
      this.Activated += new EventHandler(this.FormPledgePledge_Activated);
      this.FormClosing += new FormClosingEventHandler(this.FormPledgePledge_FormClosing);
      this.Load += new EventHandler(this.Pledge_Load);
      this.KeyDown += new KeyEventHandler(this.FormPledgePledge_KeyDown);
      this.contextMenuStrip1.ResumeLayout(false);
      this.contextMenuStrip2.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvAllPledge).EndInit();
      ((ISupportInitialize) this.dgvAuctionedPledges).EndInit();
      ((ISupportInitialize) this.dgvRedeemedPledges).EndInit();
      ((ISupportInitialize) this.dgvCustomerPledgeDetails).EndInit();
      ((ISupportInitialize) this.dgvArticles).EndInit();
      ((ISupportInitialize) this.dgvCustomerDetails).EndInit();
      ((ISupportInitialize) this.dgvPendingPledges).EndInit();
      this.cmsDeletePledge.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((ISupportInitialize) this.pbJewelPhoto).EndInit();
      this.panel9.ResumeLayout(false);
      this.panel9.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      ((ISupportInitialize) this.pbFingerPrint).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.panel8.ResumeLayout(false);
      this.panel10.ResumeLayout(false);
      this.panel10.PerformLayout();
      this.contextMenuStrip3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
