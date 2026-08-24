

using CSharpCustomPanelControl;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormUndoRedemption : Form
  {
    private List<string> lstRedemptionBillNumbers = new List<string>();
    private IContainer components = (IContainer) null;
    private TextBox tbxRedemptionDate;
    private TextBox tbxRedemptionBillNumber;
    private TextBox tbxReleasedBy;
    private PictureBox pictureBox2;
    private ComboBox cbShopCodes;
    private Panel panel2;
    private HeaderPanel headerPanel2;
    private TextBox tbxType;
    private TextBox tbxOldBillNumber;
    private TextBox tbxPureWeight;
    private TextBox tbxValue;
    private TextBox tbxAmount;
    private TextBox tbxInterestRate;
    private TextBox tbxNetWeight;
    private TextBox tbxReminder;
    private TextBox tbxGrossWeight;
    private TextBox tbxDeduction;
    private TextBox textBox13;
    private TextBox textBox12;
    private TextBox textBox11;
    private TextBox textBox10;
    private TextBox textBox9;
    private TextBox textBox8;
    private TextBox textBox7;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private Label label1;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxPledgeDate;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxPledgeBillNumber;
    private HeaderPanel headerPanel7;
    private TextBox tbxShopCode;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel3;
    private TableLayoutPanel tableLayoutPanel2;
    private HeaderPanel headerPanel1;
    private TextBox tbxBankDetails;
    private Label label2;
    private Label label3;
    private Label label12;
    private RichTextBox tbxAddress;
    private Label label13;
    private TextBox tbxAverageNumberOfDaysForRelease;
    private TextBox tbxNotes;
    private TextBox tbxNumberOfTimesReleaseExceedTwelveMonths;
    private TextBox tbxCustomerName;
    private PictureBox pictureBox1;
    private TextBox tbxCustomerCode;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCell;
    private CustomPanel customPanel1;
    private Label label11;
    private CustomPanel customPanel4;
    private Label lblBillNumber;
    private GlassButton btnDelete;
    private Panel panel1;
    private Label label21;
    private CustomPanel customPanel2;
    private Label label22;
    private CustomPanel customPanel3;
    private HeaderPanel hpREdemptionDetails;
    private TextBox tbxNoOfMonths;
    private Label label18;
    private TextBox tbxInterest;
    private TextBox tbxNoticeCharge;
    private Label label17;
    private TextBox tbxDeductions;
    private Label label19;
    private TextBox tbxOtherCharge;
    private TextBox tbxReceive;
    private TextBox tbxFinalInterest;
    private Label label15;
    private TextBox tbxPaymentReceived;
    private Label label14;
    private TextBox tbxTotal;
    private Label label9;
    private Label label6;
    private Label label8;
    private TextBox tbxInterestLess;
    private Label label7;
    private Label label16;
    private CustomPanel customPanel5;
    private Label label4;
    private TextBox tbxAmount1;
    private Label lblMessage;
    private Timer timer2;
    private Timer timer1;
    private DataGridView dgvArticles;

    public FormUndoRedemption() => this.InitializeComponent();

    private void FormUndoRedemption_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
      {
        this.tbxPledgeBillNumber.MaxLength = 7;
        this.tbxRedemptionBillNumber.MaxLength = 7;
      }
      this.cbShopCodes.Select();
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.lblMessage.Visible = true;
      this.timer2.Enabled = true;
      this.timer2.Start();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.lblMessage.Visible = false;
      this.timer2.Stop();
      this.timer1.Enabled = false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
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

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxRedemptionBillNumber.Select();
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.BackColor = Color.LightBlue;
        this.getRedemptionBillNumbers();
        this.tbxRedemptionBillNumber.Text = PawnManagementClass.getRedemptionBillNumberSeries(this.cbShopCodes.Text) + "0";
        this.tbxRedemptionBillNumber.Select();
        this.tbxRedemptionBillNumber.SelectionStart = this.tbxRedemptionBillNumber.Text.Length;
        this.tbxRedemptionBillNumber.AutoCompleteCustomSource.Clear();
        this.tbxRedemptionBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxRedemptionBillNumber.AutoCompleteCustomSource.AddRange(this.lstRedemptionBillNumbers.ToArray());
        this.tbxShopCode.Text = this.cbShopCodes.Text;
      }
      else
        this.cbShopCodes.Select();
    }

    private void getRedemptionBillNumbers()
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
          this.lstRedemptionBillNumbers.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstRedemptionBillNumbers.Add(row["BillNumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxRedemptionBillNumber_KeyPress(object sender, KeyPressEventArgs e)
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

    private void tbxRedemptionBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnDelete).Select();
    }

    private void tbxRedemptionBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              this.getPledgeBill();
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              this.getPledgeBill();
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
      }
    }

    private void getPledgeBill()
    {
      string pledgeBillNumber = RedemptionClass.getPledgeBillNumber(this.tbxRedemptionBillNumber.Text.Trim().ToString(), this.cbShopCodes.Text);
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
            this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CustomerCode");
            this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CustomerName");
            this.tbxAddress.Text = dataTable2.Rows[0].Field<string>("Addr1") + dataTable2.Rows[0].Field<string>("Addr2");
            this.tbxGrossWeight.Text = dataTable2.Rows[0].Field<string>("GrossWeight").ToString();
            this.tbxDeduction.Text = dataTable2.Rows[0].Field<string>("Deduction").ToString();
            this.tbxNetWeight.Text = dataTable2.Rows[0].Field<string>("NetWeight").ToString();
            this.tbxPureWeight.Text = dataTable2.Rows[0]["PureWeight"].ToString();
            this.tbxValue.Text = dataTable2.Rows[0].Field<int>("PresentValue").ToString();
            this.tbxAmount.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
            this.tbxAmount1.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
            TextBox tbxPledgeDate = this.tbxPledgeDate;
            DateTime dateTime = dataTable2.Rows[0].Field<DateTime>("BillDate");
            string str1 = dateTime.ToString("dd/MM/yyyy");
            tbxPledgeDate.Text = str1;
            this.tbxPledgeDate.Enabled = false;
            this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
            this.tbxPledgeBillNumber.Text = pledgeBillNumber;
            this.tbxPledgeBillNumber.Enabled = false;
            TextBox tbxRedemptionDate = this.tbxRedemptionDate;
            dateTime = dataTable2.Rows[0].Field<DateTime>("RedemptionDate");
            string str2 = dateTime.ToString("dd/MM/yyyy");
            tbxRedemptionDate.Text = str2;
            this.tbxInterest.Text = dataTable2.Rows[0]["Interest"].ToString();
            this.tbxInterestLess.Text = dataTable2.Rows[0].Field<int>("InterestLess").ToString();
            this.tbxNoticeCharge.Text = dataTable2.Rows[0].Field<int>("NoticeCharge").ToString();
            this.tbxOtherCharge.Text = dataTable2.Rows[0].Field<int>("OtherCharges").ToString();
            this.tbxDeductions.Text = dataTable2.Rows[0].Field<int>("Discount").ToString();
            this.tbxFinalInterest.Text = dataTable2.Rows[0]["FinalInterest"].ToString();
            this.tbxTotal.Text = dataTable2.Rows[0]["RedemptionAmount"].ToString();
            this.tbxNoOfMonths.Text = dataTable2.Rows[0].Field<int>("NoOfMonths").ToString();
            this.tbxType.Text = dataTable2.Rows[0]["Type"].ToString();
            this.getArticles();
            this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
            int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
            if (FormPrintSettings.boolReduceFirstMonthInterest())
              --numberOfMonths;
            this.tbxNoOfMonths.Text = numberOfMonths.ToString();
            this.tbxInterest.Text = (int.Parse(this.tbxAmount.Text.Trim().ToString()) * numberOfMonths * int.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200).ToString();
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
        if (File.Exists(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " " + this.cbShopCodes.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " " + this.cbShopCodes.Text + ".png", FileMode.Open, FileAccess.Read))
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

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        if (RedemptionClass.checkIfRedemptionBillNumberAlreadyExists(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text))
        {
          if (DialogResult.Yes != MessageBox.Show("Delete Pledge BillNumber : " + this.tbxRedemptionBillNumber.Text + "?", "Delete Pledge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) || !(FormRedemptionReports.UndoRedemption(this.cbShopCodes.Text, this.tbxRedemptionBillNumber.Text, this.tbxPledgeBillNumber.Text) == "Done"))
            return;
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.reset();
          this.lblMessage.Text = "Bill Number SuccessFully deleted";
          this.cbShopCodes.Select();
        }
        else
          this.tbxRedemptionBillNumber.Select();
      }
      else
        this.cbShopCodes.Select();
    }

    private void reset()
    {
      this.tbxPledgeBillNumber.Text = "";
      this.tbxAmount.Text = "";
      this.tbxPledgeBillNumber.Text = "";
      this.tbxShopCode.Text = "";
      this.tbxPledgeDate.Text = "";
      this.tbxCustomerCode.Text = "";
      this.tbxCustomerName.Text = "";
      this.tbxAddress.Text = "";
      this.tbxPhoneNumber.Text = "";
      this.tbxAmount1.Text = this.tbxAmount.Text = "";
      this.tbxType.Text = "";
      this.tbxOldBillNumber.Text = "";
      this.tbxReminder.Text = "";
      this.tbxValue.Text = "";
      this.tbxInterestRate.Text = "";
      this.tbxGrossWeight.Text = "";
      this.tbxNetWeight.Text = "";
      this.tbxPureWeight.Text = "";
      this.tbxDeductions.Text = "";
      this.tbxRedemptionDate.Text = "";
      this.tbxAmount1.Text = "";
      this.tbxDeduction.Text = "";
      this.tbxTotal.Text = "";
      this.tbxRedemptionBillNumber.Text = "";
      this.tbxNoOfMonths.Text = "";
      this.tbxPaymentReceived.Text = "";
      this.tbxNoticeCharge.Text = "";
      this.tbxOtherCharge.Text = "";
      this.tbxDeductions.Text = "";
      this.tbxFinalInterest.Text = "";
      this.tbxInterestLess.Text = "";
      this.dgvArticles.DataSource = (object) null;
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.tbxRedemptionDate = new TextBox();
      this.tbxRedemptionBillNumber = new TextBox();
      this.cbShopCodes = new ComboBox();
      this.tbxReleasedBy = new TextBox();
      this.pictureBox2 = new PictureBox();
      this.panel2 = new Panel();
      this.lblMessage = new Label();
      this.customPanel5 = new CustomPanel();
      this.label4 = new Label();
      this.tbxAmount1 = new TextBox();
      this.customPanel3 = new CustomPanel();
      this.btnDelete = new GlassButton();
      this.hpREdemptionDetails = new HeaderPanel();
      this.tbxNoOfMonths = new TextBox();
      this.label18 = new Label();
      this.tbxInterest = new TextBox();
      this.tbxNoticeCharge = new TextBox();
      this.label17 = new Label();
      this.tbxDeductions = new TextBox();
      this.label19 = new Label();
      this.tbxOtherCharge = new TextBox();
      this.tbxReceive = new TextBox();
      this.tbxFinalInterest = new TextBox();
      this.label15 = new Label();
      this.tbxPaymentReceived = new TextBox();
      this.label14 = new Label();
      this.tbxTotal = new TextBox();
      this.label9 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.tbxInterestLess = new TextBox();
      this.label7 = new Label();
      this.label16 = new Label();
      this.customPanel2 = new CustomPanel();
      this.label22 = new Label();
      this.headerPanel2 = new HeaderPanel();
      this.tbxType = new TextBox();
      this.tbxOldBillNumber = new TextBox();
      this.tbxPureWeight = new TextBox();
      this.tbxValue = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.tbxReminder = new TextBox();
      this.tbxGrossWeight = new TextBox();
      this.tbxDeduction = new TextBox();
      this.textBox13 = new TextBox();
      this.textBox12 = new TextBox();
      this.textBox11 = new TextBox();
      this.textBox10 = new TextBox();
      this.textBox9 = new TextBox();
      this.textBox8 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.label1 = new Label();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxPledgeDate = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxPledgeBillNumber = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.tbxShopCode = new TextBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.dgvArticles = new DataGridView();
      this.headerPanel1 = new HeaderPanel();
      this.tbxBankDetails = new TextBox();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label12 = new Label();
      this.tbxAddress = new RichTextBox();
      this.label13 = new Label();
      this.tbxAverageNumberOfDaysForRelease = new TextBox();
      this.tbxNotes = new TextBox();
      this.tbxNumberOfTimesReleaseExceedTwelveMonths = new TextBox();
      this.tbxCustomerName = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCell = new TextBox();
      this.customPanel1 = new CustomPanel();
      this.label11 = new Label();
      this.customPanel4 = new CustomPanel();
      this.lblBillNumber = new Label();
      this.panel1 = new Panel();
      this.label21 = new Label();
      this.timer2 = new Timer(this.components);
      this.timer1 = new Timer(this.components);
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.panel2.SuspendLayout();
      ((Control) this.customPanel5).SuspendLayout();
      ((Control) this.customPanel3).SuspendLayout();
      ((Control) this.hpREdemptionDetails).SuspendLayout();
      ((Control) this.customPanel2).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      ((Control) this.headerPanel1).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((Control) this.customPanel1).SuspendLayout();
      ((Control) this.customPanel4).SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxRedemptionDate.BackColor = Color.AliceBlue;
      this.tbxRedemptionDate.BorderStyle = BorderStyle.None;
      this.tbxRedemptionDate.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionDate.ForeColor = Color.RoyalBlue;
      this.tbxRedemptionDate.Location = new Point(3, 20);
      this.tbxRedemptionDate.MaxLength = 10;
      this.tbxRedemptionDate.Name = "tbxRedemptionDate";
      this.tbxRedemptionDate.Size = new Size(279, 33);
      this.tbxRedemptionDate.TabIndex = 1;
      this.tbxRedemptionDate.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxRedemptionBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxRedemptionBillNumber.BackColor = Color.AliceBlue;
      this.tbxRedemptionBillNumber.BorderStyle = BorderStyle.None;
      this.tbxRedemptionBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxRedemptionBillNumber.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionBillNumber.ForeColor = Color.RoyalBlue;
      this.tbxRedemptionBillNumber.Location = new Point(3, 20);
      this.tbxRedemptionBillNumber.MaxLength = 6;
      this.tbxRedemptionBillNumber.Name = "tbxRedemptionBillNumber";
      this.tbxRedemptionBillNumber.Size = new Size(279, 33);
      this.tbxRedemptionBillNumber.TabIndex = 45;
      this.tbxRedemptionBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionBillNumber.KeyDown += new KeyEventHandler(this.tbxRedemptionBillNumber_KeyDown);
      this.tbxRedemptionBillNumber.KeyPress += new KeyPressEventHandler(this.tbxRedemptionBillNumber_KeyPress);
      this.tbxRedemptionBillNumber.Validating += new CancelEventHandler(this.tbxRedemptionBillNumber_Validating);
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(3, 23);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(279, 28);
      this.cbShopCodes.TabIndex = 25;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      this.tbxReleasedBy.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReleasedBy.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReleasedBy.ForeColor = Color.RoyalBlue;
      this.tbxReleasedBy.Location = new Point(646, 286);
      this.tbxReleasedBy.Name = "tbxReleasedBy";
      this.tbxReleasedBy.Size = new Size(160, 21);
      this.tbxReleasedBy.TabIndex = 87;
      this.pictureBox2.Location = new Point(645, 151);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(163, 158);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 86;
      this.pictureBox2.TabStop = false;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BackColor = Color.WhiteSmoke;
      this.panel2.Controls.Add((Control) this.lblMessage);
      this.panel2.Controls.Add((Control) this.customPanel5);
      this.panel2.Controls.Add((Control) this.customPanel3);
      this.panel2.Controls.Add((Control) this.hpREdemptionDetails);
      this.panel2.Controls.Add((Control) this.customPanel2);
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.headerPanel6);
      this.panel2.Controls.Add((Control) this.headerPanel5);
      this.panel2.Controls.Add((Control) this.headerPanel7);
      this.panel2.Controls.Add((Control) this.headerPanel3);
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.customPanel1);
      this.panel2.Controls.Add((Control) this.customPanel4);
      this.panel2.Controls.Add((Control) this.panel1);
      this.panel2.Location = new Point(3, 20);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(998, 586);
      this.panel2.TabIndex = 89;
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.DarkRed;
      this.lblMessage.Location = new Point(9, 345);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(0, 20);
      this.lblMessage.TabIndex = 104;
      this.customPanel5.BackColor = Color.AliceBlue;
      this.customPanel5.BackColor2 = Color.Azure;
      this.customPanel5.BorderColor = Color.MidnightBlue;
      this.customPanel5.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel5).Controls.Add((Control) this.label4);
      ((Control) this.customPanel5).Controls.Add((Control) this.tbxAmount1);
      this.customPanel5.Curvature = 1;
      this.customPanel5.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel5).Location = new Point(3, 207);
      ((Control) this.customPanel5).Name = "customPanel5";
      ((Control) this.customPanel5).Size = new Size(287, 54);
      ((Control) this.customPanel5).TabIndex = 103;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(2, 5);
      this.label4.Name = "label4";
      this.label4.Size = new Size(53, 16);
      this.label4.TabIndex = 1;
      this.label4.Text = "Amount";
      this.tbxAmount1.BackColor = Color.AliceBlue;
      this.tbxAmount1.BorderStyle = BorderStyle.None;
      this.tbxAmount1.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount1.ForeColor = Color.RoyalBlue;
      this.tbxAmount1.Location = new Point(3, 20);
      this.tbxAmount1.MaxLength = 10;
      this.tbxAmount1.Name = "tbxAmount1";
      this.tbxAmount1.Size = new Size(279, 33);
      this.tbxAmount1.TabIndex = 1;
      this.tbxAmount1.TextAlign = HorizontalAlignment.Center;
      this.customPanel3.BackColor = Color.AliceBlue;
      this.customPanel3.BackColor2 = Color.Azure;
      this.customPanel3.BorderColor = Color.MidnightBlue;
      this.customPanel3.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel3).Controls.Add((Control) this.btnDelete);
      this.customPanel3.Curvature = 1;
      this.customPanel3.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel3).Location = new Point(3, 259);
      ((Control) this.customPanel3).Name = "customPanel3";
      ((Control) this.customPanel3).Size = new Size(287, 78);
      ((Control) this.customPanel3).TabIndex = 102;
      this.btnDelete.BackColor = Color.White;
      this.btnDelete.FadeOnFocus = true;
      ((Control) this.btnDelete).Font = new Font("Comic Sans MS", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDelete.ForeColor = Color.RoyalBlue;
      this.btnDelete.ForeColorOnFocus = Color.Red;
      this.btnDelete.ForeColorOnLeave = Color.RoyalBlue;
      this.btnDelete.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnDelete).Image = (Image) Resources.deletesymboll;
      this.btnDelete.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnDelete).Location = new Point(30, 11);
      ((Control) this.btnDelete).Name = "btnDelete";
      this.btnDelete.OuterBorderColor = Color.MistyRose;
      this.btnDelete.ShineColor = Color.MistyRose;
      ((Control) this.btnDelete).Size = new Size(228, 53);
      ((Control) this.btnDelete).TabIndex = 9;
      ((Control) this.btnDelete).Text = "&UNDO REDEMPTION";
      ((ButtonBase) this.btnDelete).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnDelete).Click += new EventHandler(this.btnDelete_Click);
      ((Control) this.hpREdemptionDetails).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.hpREdemptionDetails).BackColor = Color.AliceBlue;
      this.hpREdemptionDetails.BorderColor = Color.MidnightBlue;
      this.hpREdemptionDetails.BorderStyle = BorderStyles.Single;
      this.hpREdemptionDetails.CaptionBeginColor = Color.Azure;
      this.hpREdemptionDetails.CaptionEndColor = Color.SkyBlue;
      this.hpREdemptionDetails.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
      this.hpREdemptionDetails.CaptionHeight = 22;
      this.hpREdemptionDetails.CaptionPosition = CaptionPositions.Top;
      this.hpREdemptionDetails.CaptionText = "REDEMPTION DETAILS";
      this.hpREdemptionDetails.CaptionVisible = true;
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxNoOfMonths);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label18);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxInterest);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxNoticeCharge);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label17);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxDeductions);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label19);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxOtherCharge);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxReceive);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxFinalInterest);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label15);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxPaymentReceived);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label14);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxTotal);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label9);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label6);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label8);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.tbxInterestLess);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label7);
      ((Control) this.hpREdemptionDetails).Controls.Add((Control) this.label16);
      ((Control) this.hpREdemptionDetails).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpREdemptionDetails).ForeColor = Color.DarkBlue;
      this.hpREdemptionDetails.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.hpREdemptionDetails.GradientEnd = Color.Azure;
      this.hpREdemptionDetails.GradientStart = Color.AliceBlue;
      ((Control) this.hpREdemptionDetails).Location = new Point(739, 286);
      ((Control) this.hpREdemptionDetails).Name = "hpREdemptionDetails";
      this.hpREdemptionDetails.PanelIcon = (Icon) null;
      this.hpREdemptionDetails.PanelIconVisible = false;
      ((Control) this.hpREdemptionDetails).Size = new Size((int) byte.MaxValue, 288);
      ((Control) this.hpREdemptionDetails).TabIndex = 101;
      this.hpREdemptionDetails.TextAntialias = true;
      this.tbxNoOfMonths.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoOfMonths.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfMonths.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoOfMonths.Location = new Point(138, 4);
      this.tbxNoOfMonths.MaxLength = 2;
      this.tbxNoOfMonths.Name = "tbxNoOfMonths";
      this.tbxNoOfMonths.Size = new Size(111, 22);
      this.tbxNoOfMonths.TabIndex = 9;
      this.tbxNoOfMonths.TextAlign = HorizontalAlignment.Right;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(21, 83);
      this.label18.Name = "label18";
      this.label18.Size = new Size(113, 16);
      this.label18.TabIndex = 81;
      this.label18.Text = "INTEREST LESS";
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.ForeColor = SystemColors.ControlText;
      this.tbxInterest.Location = new Point(138, 29);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(111, 22);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxNoticeCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeCharge.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoticeCharge.Location = new Point(138, 104);
      this.tbxNoticeCharge.Name = "tbxNoticeCharge";
      this.tbxNoticeCharge.Size = new Size(111, 22);
      this.tbxNoticeCharge.TabIndex = 4;
      this.tbxNoticeCharge.Text = "0";
      this.tbxNoticeCharge.TextAlign = HorizontalAlignment.Right;
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(10, 60);
      this.label17.Name = "label17";
      this.label17.Size = new Size(124, 16);
      this.label17.TabIndex = 78;
      this.label17.Text = "PAYMENT RECVD";
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.ForeColor = SystemColors.MenuHighlight;
      this.tbxDeductions.Location = new Point(138, 154);
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.Size = new Size(111, 22);
      this.tbxDeductions.TabIndex = 6;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(68, 233);
      this.label19.Name = "label19";
      this.label19.Size = new Size(66, 16);
      this.label19.TabIndex = 84;
      this.label19.Text = "RECEIVE";
      this.tbxOtherCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherCharge.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxOtherCharge.Location = new Point(138, 129);
      this.tbxOtherCharge.Name = "tbxOtherCharge";
      this.tbxOtherCharge.Size = new Size(111, 22);
      this.tbxOtherCharge.TabIndex = 5;
      this.tbxOtherCharge.Text = "0";
      this.tbxOtherCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxReceive.BackColor = Color.Moccasin;
      this.tbxReceive.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReceive.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxReceive.ForeColor = Color.Firebrick;
      this.tbxReceive.Location = new Point(138, 229);
      this.tbxReceive.Name = "tbxReceive";
      this.tbxReceive.Size = new Size(111, 22);
      this.tbxReceive.TabIndex = 83;
      this.tbxReceive.TextAlign = HorizontalAlignment.Right;
      this.tbxFinalInterest.BackColor = Color.Moccasin;
      this.tbxFinalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFinalInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFinalInterest.ForeColor = Color.Firebrick;
      this.tbxFinalInterest.Location = new Point(138, 179);
      this.tbxFinalInterest.Name = "tbxFinalInterest";
      this.tbxFinalInterest.ReadOnly = true;
      this.tbxFinalInterest.Size = new Size(111, 22);
      this.tbxFinalInterest.TabIndex = 7;
      this.tbxFinalInterest.TextAlign = HorizontalAlignment.Right;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(18, 184);
      this.label15.Name = "label15";
      this.label15.Size = new Size(116, 16);
      this.label15.TabIndex = 65;
      this.label15.Text = "FINAL INTEREST";
      this.tbxPaymentReceived.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPaymentReceived.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPaymentReceived.ForeColor = SystemColors.MenuHighlight;
      this.tbxPaymentReceived.Location = new Point(138, 54);
      this.tbxPaymentReceived.Name = "tbxPaymentReceived";
      this.tbxPaymentReceived.Size = new Size(111, 22);
      this.tbxPaymentReceived.TabIndex = 77;
      this.tbxPaymentReceived.Text = "0";
      this.tbxPaymentReceived.TextAlign = HorizontalAlignment.Right;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(46, 159);
      this.label14.Name = "label14";
      this.label14.Size = new Size(88, 16);
      this.label14.TabIndex = 64;
      this.label14.Text = "DEDUCTION";
      this.tbxTotal.BackColor = Color.Moccasin;
      this.tbxTotal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.ForeColor = Color.Firebrick;
      this.tbxTotal.Location = new Point(138, 204);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(111, 22);
      this.tbxTotal.TabIndex = 8;
      this.tbxTotal.TextAlign = HorizontalAlignment.Right;
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(18, 133);
      this.label9.Name = "label9";
      this.label9.Size = new Size(116, 16);
      this.label9.TabIndex = 63;
      this.label9.Text = "OTHER CHARGE";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(23, 9);
      this.label6.Name = "label6";
      this.label6.Size = new Size(111, 16);
      this.label6.TabIndex = 60;
      this.label6.Text = "NO OF MONTHS";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(16, 108);
      this.label8.Name = "label8";
      this.label8.Size = new Size(118, 16);
      this.label8.TabIndex = 62;
      this.label8.Text = "NOTICE CHARGE";
      this.tbxInterestLess.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestLess.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestLess.ForeColor = SystemColors.MenuHighlight;
      this.tbxInterestLess.Location = new Point(138, 79);
      this.tbxInterestLess.Name = "tbxInterestLess";
      this.tbxInterestLess.Size = new Size(111, 22);
      this.tbxInterestLess.TabIndex = 80;
      this.tbxInterestLess.Text = "0";
      this.tbxInterestLess.TextAlign = HorizontalAlignment.Right;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(58, 36);
      this.label7.Name = "label7";
      this.label7.Size = new Size(76, 16);
      this.label7.TabIndex = 61;
      this.label7.Text = "INTEREST";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(82, 209);
      this.label16.Name = "label16";
      this.label16.Size = new Size(52, 16);
      this.label16.TabIndex = 66;
      this.label16.Text = "TOTAL";
      this.customPanel2.BackColor = Color.AliceBlue;
      this.customPanel2.BackColor2 = Color.Azure;
      this.customPanel2.BorderColor = Color.MidnightBlue;
      this.customPanel2.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel2).Controls.Add((Control) this.label22);
      ((Control) this.customPanel2).Controls.Add((Control) this.tbxRedemptionDate);
      this.customPanel2.Curvature = 1;
      this.customPanel2.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel2).Location = new Point(3, 154);
      ((Control) this.customPanel2).Name = "customPanel2";
      ((Control) this.customPanel2).Size = new Size(287, 54);
      ((Control) this.customPanel2).TabIndex = 46;
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.ForeColor = Color.DarkBlue;
      this.label22.Location = new Point(2, 5);
      this.label22.Name = "label22";
      this.label22.Size = new Size(135, 16);
      this.label22.TabIndex = 1;
      this.label22.Text = "Redemption Bill Date";
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "LOAN DETAILS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxOldBillNumber);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxPureWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxValue);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxInterestRate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxNetWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxReminder);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxGrossWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxDeduction);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox13);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox12);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox11);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox10);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox9);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox8);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox7);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox4);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(739, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size((int) byte.MaxValue, 280);
      ((Control) this.headerPanel2).TabIndex = 97;
      this.headerPanel2.TextAntialias = true;
      this.tbxType.Anchor = AnchorStyles.Top;
      this.tbxType.BackColor = Color.White;
      this.tbxType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxType.CharacterCasing = CharacterCasing.Upper;
      this.tbxType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxType.ForeColor = Color.DarkBlue;
      this.tbxType.Location = new Point(98, 8);
      this.tbxType.MaxLength = 6;
      this.tbxType.Name = "tbxType";
      this.tbxType.ReadOnly = true;
      this.tbxType.Size = new Size(144, 22);
      this.tbxType.TabIndex = 71;
      this.tbxType.TextAlign = HorizontalAlignment.Right;
      this.tbxOldBillNumber.Anchor = AnchorStyles.Top;
      this.tbxOldBillNumber.BackColor = Color.White;
      this.tbxOldBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOldBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxOldBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOldBillNumber.ForeColor = Color.DarkBlue;
      this.tbxOldBillNumber.Location = new Point(98, 32);
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
      this.tbxPureWeight.Location = new Point(98, 152);
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
      this.tbxValue.Location = new Point(98, 176);
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
      this.tbxAmount.Location = new Point(98, 200);
      this.tbxAmount.MaxLength = 10;
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(144, 22);
      this.tbxAmount.TabIndex = 7;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestRate.Anchor = AnchorStyles.Top;
      this.tbxInterestRate.BackColor = Color.White;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.ForeColor = Color.DarkBlue;
      this.tbxInterestRate.Location = new Point(98, 224);
      this.tbxInterestRate.MaxLength = 4;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.ReadOnly = true;
      this.tbxInterestRate.Size = new Size(144, 22);
      this.tbxInterestRate.TabIndex = 8;
      this.tbxInterestRate.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.Anchor = AnchorStyles.Top;
      this.tbxNetWeight.BackColor = Color.White;
      this.tbxNetWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNetWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxNetWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.ForeColor = Color.DarkBlue;
      this.tbxNetWeight.Location = new Point(98, 128);
      this.tbxNetWeight.MaxLength = 7;
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.ReadOnly = true;
      this.tbxNetWeight.Size = new Size(144, 22);
      this.tbxNetWeight.TabIndex = 5;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxReminder.Anchor = AnchorStyles.Top;
      this.tbxReminder.BackColor = Color.White;
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.CharacterCasing = CharacterCasing.Upper;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.ForeColor = Color.DarkBlue;
      this.tbxReminder.Location = new Point(98, 56);
      this.tbxReminder.MaxLength = 50;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.ReadOnly = true;
      this.tbxReminder.Size = new Size(144, 22);
      this.tbxReminder.TabIndex = 2;
      this.tbxGrossWeight.Anchor = AnchorStyles.Top;
      this.tbxGrossWeight.BackColor = Color.White;
      this.tbxGrossWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxGrossWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxGrossWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxGrossWeight.ForeColor = Color.DarkBlue;
      this.tbxGrossWeight.Location = new Point(98, 80);
      this.tbxGrossWeight.MaxLength = 7;
      this.tbxGrossWeight.Name = "tbxGrossWeight";
      this.tbxGrossWeight.ReadOnly = true;
      this.tbxGrossWeight.Size = new Size(144, 22);
      this.tbxGrossWeight.TabIndex = 3;
      this.tbxGrossWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxDeduction.Anchor = AnchorStyles.Top;
      this.tbxDeduction.BackColor = Color.White;
      this.tbxDeduction.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeduction.CharacterCasing = CharacterCasing.Upper;
      this.tbxDeduction.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeduction.ForeColor = Color.DarkBlue;
      this.tbxDeduction.Location = new Point(98, 104);
      this.tbxDeduction.MaxLength = 5;
      this.tbxDeduction.Name = "tbxDeduction";
      this.tbxDeduction.ReadOnly = true;
      this.tbxDeduction.Size = new Size(144, 22);
      this.tbxDeduction.TabIndex = 4;
      this.tbxDeduction.Text = "0";
      this.tbxDeduction.TextAlign = HorizontalAlignment.Right;
      this.textBox13.Anchor = AnchorStyles.Top;
      this.textBox13.BackColor = Color.AliceBlue;
      this.textBox13.BorderStyle = BorderStyle.None;
      this.textBox13.CharacterCasing = CharacterCasing.Upper;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox13.ForeColor = Color.DarkBlue;
      this.textBox13.Location = new Point(-29, 154);
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
      this.textBox12.Location = new Point(-20, 10);
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
      this.textBox11.Location = new Point(-20, 34);
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
      this.textBox10.Location = new Point(-20, 58);
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
      this.textBox9.Location = new Point(-20, 82);
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
      this.textBox8.Location = new Point(-20, 106);
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
      this.textBox7.Location = new Point(-20, 130);
      this.textBox7.MaxLength = 4;
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(114, 15);
      this.textBox7.TabIndex = 62;
      this.textBox7.Text = "NET WT   ";
      this.textBox7.TextAlign = HorizontalAlignment.Right;
      this.textBox2.Anchor = AnchorStyles.Top;
      this.textBox2.BackColor = Color.AliceBlue;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.CharacterCasing = CharacterCasing.Upper;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox2.ForeColor = Color.DarkBlue;
      this.textBox2.Location = new Point(-20, 178);
      this.textBox2.MaxLength = 4;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(114, 15);
      this.textBox2.TabIndex = 56;
      this.textBox2.Text = "VALUE   ";
      this.textBox2.TextAlign = HorizontalAlignment.Right;
      this.textBox3.Anchor = AnchorStyles.Top;
      this.textBox3.BackColor = Color.AliceBlue;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.CharacterCasing = CharacterCasing.Upper;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.ForeColor = Color.DarkBlue;
      this.textBox3.Location = new Point(-20, 202);
      this.textBox3.MaxLength = 4;
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(114, 15);
      this.textBox3.TabIndex = 57;
      this.textBox3.Text = "AMOUNT   ";
      this.textBox3.TextAlign = HorizontalAlignment.Right;
      this.textBox4.Anchor = AnchorStyles.Top;
      this.textBox4.BackColor = Color.AliceBlue;
      this.textBox4.BorderStyle = BorderStyle.None;
      this.textBox4.CharacterCasing = CharacterCasing.Upper;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox4.ForeColor = Color.DarkBlue;
      this.textBox4.Location = new Point(-21, 226);
      this.textBox4.MaxLength = 4;
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(114, 15);
      this.textBox4.TabIndex = 58;
      this.textBox4.Text = "ROI    ";
      this.textBox4.TextAlign = HorizontalAlignment.Right;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkRed;
      this.label1.Location = new Point(9, 301);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 20);
      this.label1.TabIndex = 2;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel6.CaptionEndColor = Color.AliceBlue;
      this.headerPanel6.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "BILL DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxPledgeDate);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(611, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(121, 47);
      ((Control) this.headerPanel6).TabIndex = 100;
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
      ((Control) this.glassButton3).Location = new Point(-196, 521);
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
      ((Control) this.glassButton4).Location = new Point(-62, 520);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxPledgeDate.BackColor = Color.AliceBlue;
      this.tbxPledgeDate.BorderStyle = BorderStyle.None;
      this.tbxPledgeDate.Dock = DockStyle.Fill;
      this.tbxPledgeDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeDate.Location = new Point(0, 0);
      this.tbxPledgeDate.MaxLength = 10;
      this.tbxPledgeDate.Name = "tbxPledgeDate";
      this.tbxPledgeDate.Size = new Size(119, 22);
      this.tbxPledgeDate.TabIndex = 1;
      this.tbxPledgeDate.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel5.CaptionEndColor = Color.AliceBlue;
      this.headerPanel5.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "BILL NUMBER";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxPledgeBillNumber);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(297, 4);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(98, 47);
      ((Control) this.headerPanel5).TabIndex = 99;
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
      ((Control) this.glassButton1).Location = new Point(-217, 521);
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
      ((Control) this.glassButton2).Location = new Point(-83, 520);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxPledgeBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPledgeBillNumber.BackColor = Color.AliceBlue;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.None;
      this.tbxPledgeBillNumber.Dock = DockStyle.Fill;
      this.tbxPledgeBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.Location = new Point(0, 0);
      this.tbxPledgeBillNumber.MaxLength = 6;
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.ReadOnly = true;
      this.tbxPledgeBillNumber.Size = new Size(96, 22);
      this.tbxPledgeBillNumber.TabIndex = 79;
      this.tbxPledgeBillNumber.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(399, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(207, 47);
      ((Control) this.headerPanel7).TabIndex = 98;
      this.headerPanel7.TextAntialias = true;
      this.tbxShopCode.BackColor = Color.AliceBlue;
      this.tbxShopCode.BorderStyle = BorderStyle.None;
      this.tbxShopCode.Dock = DockStyle.Fill;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(0, 0);
      this.tbxShopCode.MaxLength = 10;
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(205, 22);
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
      ((Control) this.glassButton8).Location = new Point(-106, 521);
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
      ((Control) this.glassButton9).Location = new Point(28, 520);
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
      this.headerPanel3.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel3.CaptionEndColor = Color.Azure;
      this.headerPanel3.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "DETAILED DESCRIPTION OF THE ARTICLES";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tableLayoutPanel2);
      ((Control) this.headerPanel3).Enabled = false;
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(298, 285);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(433, 289);
      ((Control) this.headerPanel3).TabIndex = 96;
      this.headerPanel3.TextAntialias = true;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel2.Controls.Add((Control) this.dgvArticles, 0, 0);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.Size = new Size(431, 265);
      this.tableLayoutPanel2.TabIndex = 66;
      this.dgvArticles.AllowUserToAddRows = false;
      this.dgvArticles.AllowUserToDeleteRows = false;
      this.dgvArticles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvArticles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.BackColor = Color.PowderBlue;
      gridViewCellStyle.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dgvArticles.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dgvArticles.ColumnHeadersHeight = 40;
      this.dgvArticles.EnableHeadersVisualStyles = false;
      this.dgvArticles.Location = new Point(3, 3);
      this.dgvArticles.Name = "dgvArticles";
      this.dgvArticles.ReadOnly = true;
      this.dgvArticles.RowHeadersVisible = false;
      this.dgvArticles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvArticles.Size = new Size(425, 259);
      this.dgvArticles.TabIndex = 2;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel1.CaptionEndColor = Color.Azure;
      this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "CUSTOMER DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxBankDetails);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label12);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAddress);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label13);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAverageNumberOfDaysForRelease);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNotes);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNumberOfTimesReleaseExceedTwelveMonths);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerName);
      ((Control) this.headerPanel1).Controls.Add((Control) this.pictureBox1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPhoneNumber);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCell);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(298, 54);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(434, 230);
      ((Control) this.headerPanel1).TabIndex = 95;
      this.headerPanel1.TextAntialias = true;
      this.tbxBankDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxBankDetails.BackColor = Color.AliceBlue;
      this.tbxBankDetails.BorderStyle = BorderStyle.None;
      this.tbxBankDetails.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankDetails.ForeColor = Color.Maroon;
      this.tbxBankDetails.Location = new Point(166, 188);
      this.tbxBankDetails.Name = "tbxBankDetails";
      this.tbxBankDetails.Size = new Size(257, 15);
      this.tbxBankDetails.TabIndex = 36;
      this.tbxBankDetails.Visible = false;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Location = new Point(169, 150);
      this.label2.Name = "label2";
      this.label2.Size = new Size(66, 15);
      this.label2.TabIndex = 35;
      this.label2.Text = "REMINDER";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Location = new Point(169, 117);
      this.label3.Name = "label3";
      this.label3.Size = new Size(98, 15);
      this.label3.TabIndex = 34;
      this.label3.Text = "PHONE NUMBER";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Location = new Point(169, 41);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 15);
      this.label12.TabIndex = 33;
      this.label12.Text = "ADDRESS";
      this.tbxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddress.BackColor = Color.AliceBlue;
      this.tbxAddress.BorderStyle = BorderStyle.None;
      this.tbxAddress.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress.Location = new Point(169, 58);
      this.tbxAddress.Name = "tbxAddress";
      this.tbxAddress.Size = new Size(254, 59);
      this.tbxAddress.TabIndex = 32;
      this.tbxAddress.Text = "";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Location = new Point(169, 7);
      this.label13.Name = "label13";
      this.label13.Size = new Size(106, 15);
      this.label13.TabIndex = 31;
      this.label13.Text = "CUSTOMER NAME";
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
      this.tbxNotes.Size = new Size(257, 15);
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
      this.tbxCustomerName.Size = new Size(254, 15);
      this.tbxCustomerName.TabIndex = 0;
      this.pictureBox1.Location = new Point(6, 6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(155, 181);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.tbxCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerCode.BackColor = Color.AliceBlue;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(17, 186);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(119, 15);
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
      this.customPanel1.BackColor = Color.AliceBlue;
      this.customPanel1.BackColor2 = Color.Azure;
      this.customPanel1.BorderColor = Color.MidnightBlue;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.label11);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbShopCodes);
      this.customPanel1.Curvature = 1;
      this.customPanel1.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(3, 50);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(287, 54);
      ((Control) this.customPanel1).TabIndex = 0;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkBlue;
      this.label11.Location = new Point(3, 3);
      this.label11.Name = "label11";
      this.label11.Size = new Size(96, 16);
      this.label11.TabIndex = 1;
      this.label11.Text = "Select License";
      this.customPanel4.BackColor = Color.AliceBlue;
      this.customPanel4.BackColor2 = Color.Azure;
      this.customPanel4.BorderColor = Color.MidnightBlue;
      this.customPanel4.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel4).Controls.Add((Control) this.lblBillNumber);
      ((Control) this.customPanel4).Controls.Add((Control) this.tbxRedemptionBillNumber);
      this.customPanel4.Curvature = 1;
      this.customPanel4.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel4).Location = new Point(3, 101);
      ((Control) this.customPanel4).Name = "customPanel4";
      ((Control) this.customPanel4).Size = new Size(287, 54);
      ((Control) this.customPanel4).TabIndex = 1;
      this.lblBillNumber.AutoSize = true;
      this.lblBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblBillNumber.ForeColor = Color.DarkBlue;
      this.lblBillNumber.Location = new Point(2, 5);
      this.lblBillNumber.Name = "lblBillNumber";
      this.lblBillNumber.Size = new Size(154, 16);
      this.lblBillNumber.TabIndex = 1;
      this.lblBillNumber.Text = "Redemption Bill Number";
      this.panel1.BackColor = Color.White;
      this.panel1.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label21);
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(287, 53);
      this.panel1.TabIndex = 15;
      this.label21.AutoSize = true;
      this.label21.BackColor = Color.Transparent;
      this.label21.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.Black;
      this.label21.Location = new Point(5, 9);
      this.label21.Name = "label21";
      this.label21.Size = new Size(274, 29);
      this.label21.TabIndex = 10;
      this.label21.Text = "DELETE REDEMPTION";
      this.timer2.Interval = 1000;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.timer1.Interval = 500;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 631);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.tbxReleasedBy);
      this.Controls.Add((Control) this.pictureBox2);
      this.Name = nameof (FormUndoRedemption);
      this.Text = nameof (FormUndoRedemption);
      this.Load += new EventHandler(this.FormUndoRedemption_Load);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((Control) this.customPanel5).ResumeLayout(false);
      ((Control) this.customPanel5).PerformLayout();
      ((Control) this.customPanel3).ResumeLayout(false);
      ((Control) this.hpREdemptionDetails).ResumeLayout(false);
      ((Control) this.hpREdemptionDetails).PerformLayout();
      ((Control) this.customPanel2).ResumeLayout(false);
      ((Control) this.customPanel2).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvArticles).EndInit();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      ((Control) this.customPanel4).ResumeLayout(false);
      ((Control) this.customPanel4).PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
