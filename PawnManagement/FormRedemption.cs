
using CrystalDecisions.CrystalReports.Engine;
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Transitions;

namespace PawnManagement
{
  public class FormRedemption : Form
  {
    private List<string> lstPledgeBillNumbers = new List<string>();
    private List<string> lstRedemptionBillNumbers = new List<string>();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private DataTable dtPaymentDetailsForPledgeBillNumber = new DataTable();
    private string oldValues;
    private string newValues;
    private string redemptionOrEditOrOldRedemption = "";
    private string ch = "a";
    private DataTable dtPaymentDetails = new DataTable();
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
    private ReportDocument rd = new ReportDocument();
    public static double shopInterestRate = 16.0;
    private bool seriesChanged = false;
    private IContainer components = (IContainer) null;
    private TextBox tbxPledgeBillNumber;
    private TextBox tbxAmount;
    private TextBox tbxNoOfMonths;
    private TextBox tbxPledgeDate;
    private TextBox tbxInterestRate;
    private TextBox tbxInterest;
    private TextBox tbxNoticeCharge;
    private TextBox tbxDeductions;
    private TextBox tbxOtherCharge;
    private TextBox tbxFinalInterest;
    private TextBox tbxTotal;
    private TextBox tbxRedemptionBillNumber;
    private Label label5;
    private Label label7;
    private Label label10;
    private Label label4;
    private Label label6;
    private Label label8;
    private Label label9;
    private Label label14;
    private Label label15;
    private Label label16;
    private TextBox tbxRedemptionDate;
    private Label lblMessage;
    private Timer timer1;
    private Timer timer2;
    private TextBox tbxPaymentReceived;
    private Label label17;
    private GlassButton btnPaymentReceivedDetails;
    private Label label18;
    private TextBox tbxInterestLess;
    private GlassButton btnInterestLessDetails;
    private TextBox tbxReceive;
    private Label label19;
    private Panel panel2;
    private Label lblHeading;
    private Panel panel3;
    private Panel panel5;
    private ComboBox cbShopCodes;
    private GlassButton btnReleasedBy;
    private PictureBox pictureBox2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deletePHotoToolStripMenuItem;
    private TextBox tbxReleasedBy;
    private Panel panel10;
    private Label label12;
    private Panel panel9;
    private Label label11;
    private Panel panel8;
    private Label label3;
    private Panel panel7;
    private Label label2;
    private TextBox tbxPureWeight;
    private TextBox tbxNetWeight;
    private TextBox tbxGrossWeight;
    private TextBox tbxDeduction;
    private Label label22;
    private RichTextBox tbxAddress1;
    private Label label23;
    private TextBox tbxCustomerName;
    private PictureBox pictureBox1;
    private TextBox tbxInterest16;
    private TextBox tbxNoOfMonths16;
    private TextBox tbxRedemptionAmount16;
    private Label lblBankBillNumber;
    private Panel panel12;
    private TextBox textBox6;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private Panel panel13;
    private Label label1;
    private Panel panel11;
    private Panel panel6;
    private Label label24;
    private Panel panel4;
    private Label label20;
    private Panel panel1;
    private RichTextBox lblReminder;
    private Panel panel14;
    private Label label13;
    private TextBox tbxCustomerCode;
    private DataGridView dgvArticles;
    private ListBox listBox1;

    public FormRedemption() => this.InitializeComponent();

    public FormRedemption(string str)
    {
      this.redemptionOrEditOrOldRedemption = str;
      this.InitializeComponent();
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        switch (control1)
        {
          case TextBox _:
            TextBox textBox = (TextBox) control1;
            textBox.Enter += new EventHandler(this.textBox_Enter);
            textBox.Leave += new EventHandler(this.textBox_Leave);
            break;
          case ComboBox _:
            ComboBox comboBox = (ComboBox) control1;
            comboBox.Enter += new EventHandler(this.comboBoX_Enter);
            comboBox.Leave += new EventHandler(this.comboBox_Leave);
            break;
          default:
            this.Assign(control1);
            break;
        }
      }
    }

    private void tbxDonAcceptAnyInput(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
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

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      if (e.KeyCode != Keys.Up)
        return;
      this.SelectNextControl(this.ActiveControl, false, true, true, true);
    }

    private void textBox_Enter(object sender, EventArgs e) => (sender as TextBox).BackColor = Color.Aquamarine;

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.Black;
    }

    private void comboBoX_Enter(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.Aquamarine;

    private void comboBox_Leave(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.White;

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void tbxRoundOFFTo2AndAPPENDZERORES_Validating(object sender, CancelEventArgs e) => (sender as TextBox).Text = PawnManagementClass.appenZeroes(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());

    private void tbxRoundOFFTo1AndAPPENDZERORES2_Validating(object sender, CancelEventArgs e) => (sender as TextBox).Text = PawnManagementClass.appenZeroes2(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 1).ToString());

    private void Redemption_Load(object sender, EventArgs e)
    {
      try
      {
        if (FormMain.BillNumberSeries == "DOUBLE")
        {
          this.tbxPledgeBillNumber.MaxLength = 7;
          this.tbxRedemptionBillNumber.MaxLength = 7;
        }
        this.cbShopCodes.DataSource = (object) FormMain.lstShopCodes;
        this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
        TextBox tbxRedemptionDate1 = this.tbxRedemptionDate;
        DateTime dateTime = DateTime.Today;
        dateTime = dateTime.Date;
        string str1 = dateTime.ToString("dd/MM/yyyy");
        tbxRedemptionDate1.Text = str1;
        this.cbShopCodes.Select();
        if (this.redemptionOrEditOrOldRedemption == "Redemption")
        {
          this.lblHeading.Text = "REDEMPTION";
          if (PawnManagementClass.checkForValidateDate(((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text.ToString()))
          {
            this.tbxRedemptionDate.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text.ToString();
          }
          else
          {
            TextBox tbxRedemptionDate2 = this.tbxRedemptionDate;
            dateTime = DateTime.Now;
            string str2 = dateTime.ToString("dd/MM/yyyy");
            tbxRedemptionDate2.Text = str2;
          }
        }
        else if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
          this.lblHeading.Text = "REDEMPTION OLD";
        else if (this.redemptionOrEditOrOldRedemption == "RedemptionEdit")
          this.lblHeading.Text = "REDEMPTION EDIT";
        FormMain.lsttoRelease.Sort();
        this.refreshtoReleaseList();
        this.Assign((Control) this);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form redemption.redemption_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
          int index = 0;
          this.lstRedemptionBillNumbers.Clear();
          for (; index < dataTable2.Rows.Count; ++index)
            this.lstRedemptionBillNumbers.Add(dataTable2.Rows[index].Field<string>("BillNumber"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
        this.lblBankBillNumber.Text = dataTable2.Rows[0].Field<int>("SerialNumber").ToString() + "," + bankBillNumber + "," + dataTable2.Rows[0].Field<string>("BankCode").ToString() + ", " + dataTable2.Rows[0]["Amount"].ToString();
        this.lblBankBillNumber.Visible = true;
      }
    }

    private string getReminderCustomer(string customerCode)
    {
      string strError = "";
      string my_querry = "select cnotes from tblCustomers where cid= @cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("cid", (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getReminderCustomer", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving reminder of customer" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0].Field<string>("cnotes");
      return "";
    }

    private string getBankBillNumber(string billNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankpledgePledgeBills where shopCode = @shopCode and  PledgeBillNumber = @PledgeBillNumber order by serialNumber desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("shopCode", (object) this.cbShopCodes.Text));
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

    private string saveRedemptionInPledgeTable()
    {
      string strError = "";
      return SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update tblPledge set Redeemed = @Redeemed,NoOfMonths = @NoOfMonths,temp2=@Interest,InterestLess = @InterestLess,NoticeCharge=@NoticeCharge,OtherCharges=@OtherCharge,Discount=@Discount,temp3=@FinalInterest,temp4=@RedemptionAmount,RedemptionDate=@RedemptionDate,NoOfMonths16=@NoOfMonths16,Interest16= @Interest16,RedemptionAmount16=@RedemptionAmount16,RedeemedBy=@RedeemedBy,RedeemedOn=@RedeemedOn,RedemptionBillNumber = @RedemptionBillNumber where BillNumber =@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Redeemed", (object) "Y"),
        new OleDbParameter("NoOfMonths", (object) this.tbxNoOfMonths.Text.Trim().ToString()),
        new OleDbParameter("Interest", (object) this.tbxInterest.Text.Trim().ToString()),
        new OleDbParameter("InterestLess", (object) this.tbxInterestLess.Text.Trim().ToString()),
        new OleDbParameter("NoticeCharge", (object) this.tbxNoticeCharge.Text.Trim().ToString()),
        new OleDbParameter("OtherCharges", (object) this.tbxOtherCharge.Text.Trim().ToString()),
        new OleDbParameter("Discount", (object) this.tbxDeductions.Text.Trim().ToString()),
        new OleDbParameter("FinalInterest", (object) this.tbxFinalInterest.Text.Trim().ToString()),
        new OleDbParameter("RedemptionAmount", (object) this.tbxTotal.Text.Trim().ToString()),
        new OleDbParameter("RedemptionDate", (object) this.tbxRedemptionDate.Text.Trim().ToString()),
        new OleDbParameter("NoOfMonths16", (object) (int.Parse(this.tbxNoOfMonths.Text.Trim().ToString()) + 1).ToString()),
        new OleDbParameter("Interest16", (object) this.tbxInterest16.Text.Trim().ToString()),
        new OleDbParameter("RedemptionAmount16", (object) this.tbxRedemptionAmount16.Text.Trim().ToString()),
        new OleDbParameter("RedeemedBy", (object) FormMain.username),
        new OleDbParameter("RedeemedOn", (object) DateTime.Today.ToString("dd/MM/yyyy")),
        new OleDbParameter("RedemptionBillNumber", (object) this.tbxRedemptionBillNumber.Text),
        new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString())
      }, ref strError) == "Done" ? "Done" : strError;
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

    private string StrGetRedemptionBillNumber()
    {
      string str1 = "'" + PawnManagementClass.getRedemptionBillNumberSeries(this.cbShopCodes.Text) + "%'";
      string strError = "";
      string my_querry = "select max(BillNumber) as BillNumber from tblRedemption  where  shopCode = @ShopCode and  BillNumber like " + str1;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getRedemptionBillNumber ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Redemption bIll number");
      }
      else
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
          PawnManagementClass.InsertIntoException("Form REdemption.getRedemptionBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Try old Redemption first....  Check if billnumber series is right");
        }
      }
      return "";
    }

    private void getRedemptionBillNumber()
    {
      string str1 = "'" + PawnManagementClass.getRedemptionBillNumberSeries(this.cbShopCodes.Text) + "%'";
      string strError = "";
      string my_querry = "select max(BillNumber) as BillNumber from tblRedemption  where  shopCode = @ShopCode and  BillNumber like " + str1;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.getRedemptionBillNumber ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Redemption bIll number");
      }
      else
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
                this.seriesChanged = true;
              }
              if (num2 < 10)
              {
                this.tbxRedemptionBillNumber.Text = this.ch + "0000" + num2.ToString();
                break;
              }
              if (num2 < 100)
              {
                this.tbxRedemptionBillNumber.Text = this.ch + "000" + num2.ToString();
                break;
              }
              if (num2 < 1000)
              {
                this.tbxRedemptionBillNumber.Text = this.ch + "00" + num2.ToString();
                break;
              }
              if (num2 < 10000)
              {
                this.tbxRedemptionBillNumber.Text = this.ch + "0" + num2.ToString();
                break;
              }
              this.tbxRedemptionBillNumber.Text = this.ch + num2.ToString();
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
                this.seriesChanged = true;
              }
              if (num5 < 10)
                this.tbxRedemptionBillNumber.Text = this.ch + "0000" + num5.ToString();
              else if (num5 < 100)
                this.tbxRedemptionBillNumber.Text = this.ch + "000" + num5.ToString();
              else if (num5 < 1000)
                this.tbxRedemptionBillNumber.Text = this.ch + "00" + num5.ToString();
              else if (num5 < 10000)
                this.tbxRedemptionBillNumber.Text = this.ch + "0" + num5.ToString();
              else
                this.tbxRedemptionBillNumber.Text = this.ch + num5.ToString();
              break;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("Form REdemption.getRedemptionBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Try old Redemption first....  Check if billnumber series is right");
        }
      }
    }

    private void changeRedemptionBillNumberSeries(string ch)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblPledgeBillNumberSeries set RedemptionCurrentSeries = @CurrentSeries where ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CurrentSeries", (object) ch.ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form redemption.changePledgerBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private void getShopDetails()
    {
      try
      {
        DataTable shopDetails = PawnManagementClass.getShopDetails(this.cbShopCodes.Text);
        if (shopDetails == null || shopDetails.Rows.Count <= 0)
          return;
        this.Text = shopDetails.Rows[0]["ShopName"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getShopDetails", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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

    private void tbxTotal_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Return || DialogResult.Yes != MessageBox.Show("Redeem Bill", "Are you sure??", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          return;
        if (this.redemptionOrEditOrOldRedemption == "RedemptionEdit")
          this.UpdateRedemption();
        else if (this.redemptionOrEditOrOldRedemption == "Redemption" | this.redemptionOrEditOrOldRedemption == "RedemptionOld")
          this.SaveRedemption();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form redemption.tbxTotal_Keydown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void SaveRedemption()
    {
      if (!this.checkIfAllEntriesAreMade())
        return;
      if (!RedemptionClass.checkIfRedemptionBillNumberAlreadyExists(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text))
      {
        if (!PawnManagement.Classes.PawnManagementClasses.PledgeClass.checkIfBillNumberReleeasedOrNot(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text))
        {
          if (this.redemptionOrEditOrOldRedemption == "Redemption")
          {
            string str = RedemptionClass.saveRedemption(this.cbShopCodes.Text.Trim(), this.tbxRedemptionBillNumber.Text.Trim(), this.tbxRedemptionDate.Text.Trim(), this.tbxPledgeBillNumber.Text.Trim(), this.tbxCustomerCode.Text.Trim(), this.tbxReleasedBy.Text.Trim(), this.tbxPledgeDate.Text.Trim(), this.tbxAmount.Text.Trim(), this.tbxInterestRate.Text.Trim(), this.tbxInterest.Text.Trim(), this.tbxInterestLess.Text.Trim(), this.tbxNoticeCharge.Text.Trim(), this.tbxOtherCharge.Text.Trim(), this.tbxDeductions.Text.Trim(), this.tbxFinalInterest.Text.Trim(), this.tbxTotal.Text.Trim(), this.tbxNoOfMonths.Text.Trim(), this.tbxNoOfMonths16.Text.Trim(), this.tbxInterest16.Text.Trim(), this.tbxRedemptionAmount16.Text.Trim(), DateTime.Now, FormMain.username, FormMain.BillerName);
            if (str == "Done")
            {
              string text = this.saveRedemptionInPledgeTable();
              if (text == "Done")
              {
                if (this.getRokadAutoEntrySettings())
                {
                  this.insertIntoTableVouchers();
                  this.insertIntoTableVouchersPartPayment();
                }
                this.changeRedemptionBillNumberSeries(this.ch);
                this.print();
                this.getRedemptionBillNumber();
                PawnManagementClass.InsertIntoHistory("REDEMPTION NEW", "Bill number " + this.tbxPledgeBillNumber.Text.Trim().ToString() + " redeemed against redemptinobillnumber " + this.tbxRedemptionBillNumber.Text.Trim().ToString(), "", "", FormMain.username, DateTime.Now.ToString());
                if (FormMain.lsttoRelease.Count > 0)
                {
                  FormMain.lsttoRelease.RemoveAt(0);
                  this.refreshtoReleaseList();
                  if (DialogResult.Yes == MessageBox.Show("Reebill", "Are you sure??", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                  {
                    int num = (int) new FormReBill(this.cbShopCodes.Text, DateTime.Parse(((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tstbBillingDate"].Text.ToString())).ShowDialog();
                  }
                }
                this.reset();
                this.tbxPledgeBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
                this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
                this.cbShopCodes.Select();
              }
              else
              {
                int num1 = (int) MessageBox.Show(text);
              }
              this.refreshSidePanel(DateTime.Now.ToString("dd/MM/yyyyy"));
            }
            else
            {
              int num2 = (int) MessageBox.Show("Error While Releasing ::: " + str);
            }
          }
          else if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
          {
            string str1 = RedemptionClass.saveRedemption(this.cbShopCodes.Text.Trim(), this.tbxRedemptionBillNumber.Text.Trim(), this.tbxRedemptionDate.Text.Trim(), this.tbxPledgeBillNumber.Text.Trim(), this.tbxCustomerCode.Text.Trim(), this.tbxReleasedBy.Text.Trim(), this.tbxPledgeDate.Text.Trim(), this.tbxAmount.Text.Trim(), this.tbxInterestRate.Text.Trim(), this.tbxInterest.Text.Trim(), this.tbxInterestLess.Text.Trim(), this.tbxNoticeCharge.Text.Trim(), this.tbxOtherCharge.Text.Trim(), this.tbxDeductions.Text.Trim(), this.tbxFinalInterest.Text.Trim(), this.tbxTotal.Text.Trim(), this.tbxNoOfMonths.Text.Trim(), this.tbxNoOfMonths16.Text.Trim(), this.tbxInterest16.Text.Trim(), this.tbxRedemptionAmount16.Text.Trim(), DateTime.Now, FormMain.username, FormMain.BillerName);
            if (str1 == "Done")
            {
              string str2 = this.saveRedemptionInPledgeTable();
              if (str2 == "Done")
              {
                if (DialogResult.Yes == MessageBox.Show("Do you want to affect the redemption changes in rokad....??? ", "Update the redemption in rokad?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                  this.insertIntoTableVouchers();
                  this.insertIntoTableVouchersPartPayment();
                }
                this.cbShopCodes.Select();
                this.reset();
                PawnManagementClass.InsertIntoHistory("REDEMPTION OLD", "Bill number " + this.tbxPledgeBillNumber.Text.Trim().ToString() + " redeemed against redemptinobillnumber " + this.tbxRedemptionBillNumber.Text.Trim().ToString(), "", "", FormMain.username, DateTime.Now.ToString());
              }
              else
              {
                int num = (int) MessageBox.Show("Error While Releasing ::: " + str2);
              }
              this.refreshSidePanel(DateTime.Now.ToString("dd/MM/yyyyy"));
            }
            else
            {
              int num3 = (int) MessageBox.Show("Error While Releasing ::: " + str1);
            }
          }
        }
        else
        {
          int num4 = (int) MessageBox.Show("BillNumber already Released");
        }
      }
      else
      {
        int num5 = (int) MessageBox.Show("BillNumber already taken..Retry");
      }
    }

    private void refreshtoReleaseList()
    {
      this.listBox1.Items.Clear();
      this.listBox1.Items.AddRange((object[]) FormMain.lsttoRelease.ToArray());
    }

    private void UpdateRedemption()
    {
      DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxRedemptionBillNumber.Text.Trim().ToString() + " RedemptionBillNumber " + this.cbShopCodes.Text);
      if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
      {
        if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
        {
          this.newValues = "New Values are \n Interest =" + this.tbxInterest.Text.Trim().ToString() + " \n NoticeCharge = " + this.tbxNoticeCharge.Text.Trim().ToString() + " \n OtherCharges = " + this.tbxOtherCharge.Text.Trim().ToString() + " \n Discount =  " + this.tbxDeductions.Text.Trim().ToString() + "\n FinalInterest =  " + this.tbxFinalInterest.Text.Trim().ToString() + "\n RedemptionAmount =  " + this.tbxTotal.Text.Trim().ToString();
          this.updateRedemption();
          this.updateRedemptionInPledgeTable();
          if (this.getRokadAutoEntrySettings())
          {
            this.updateTableVouchers();
            this.updateTablePartPayment();
          }
          this.refreshSidePanel(DateTime.Now.ToString("dd/MM/yyyyy"));
          PawnManagementClass.InsertIntoHistory("REDEMPTION EDIT", " Redemption Bill number " + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " edited", this.oldValues, this.newValues, FormMain.username, DateTime.Now.ToString());
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show("Rokad finished for this date.. So changes cannot be made..");
        }
      }
      else
      {
        this.newValues = "New Values are \n Interest =" + this.tbxInterest.Text.Trim().ToString() + " \n NoticeCharge = " + this.tbxNoticeCharge.Text.Trim().ToString() + " \n OtherCharges = " + this.tbxOtherCharge.Text.Trim().ToString() + " \n Discount =  " + this.tbxDeductions.Text.Trim().ToString() + "\n FinalInterest =  " + this.tbxFinalInterest.Text.Trim().ToString() + "\n RedemptionAmount =  " + this.tbxTotal.Text.Trim().ToString();
        this.updateRedemption();
        this.updateRedemptionInPledgeTable();
        PawnManagementClass.InsertIntoHistory("REDEMPTION EDIT", " Redemption Bill number " + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " edited", this.oldValues, this.newValues, FormMain.username, DateTime.Now.ToString());
        this.Close();
      }
    }

    private bool checkIfAllEntriesAreMade()
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        if (this.tbxPledgeBillNumber.Text.Trim() != "")
        {
          if (this.tbxPledgeBillNumber.Text.Trim() != "")
          {
            if (this.tbxRedemptionDate.Text.Trim() != "" && PawnManagementClass.checkForValidateDate(this.tbxRedemptionDate.Text))
            {
              if (this.tbxRedemptionBillNumber.Text.Trim() != "")
              {
                if (this.tbxCustomerCode.Text.Trim() != "")
                {
                  if (this.tbxAmount.Text.Trim() != "")
                  {
                    if (this.tbxReleasedBy.Text.Trim() != "")
                    {
                      if (this.tbxPledgeDate.Text.Trim() != "" && PawnManagementClass.checkForValidateDate(this.tbxPledgeDate.Text))
                      {
                        if (this.tbxInterestRate.Text.Trim() != "" && this.tbxInterestRate.Text != "" && double.Parse(this.tbxInterestRate.Text) >= 0.0)
                        {
                          if (this.tbxInterest.Text.Trim() != "" && this.tbxInterest.Text != "" && double.Parse(this.tbxInterestRate.Text) >= 0.0)
                          {
                            if (this.tbxInterestLess.Text.Trim() != "" && this.tbxInterestLess.Text != "" && double.Parse(this.tbxInterestLess.Text) >= 0.0)
                            {
                              if (this.tbxNoticeCharge.Text.Trim() != "" && this.tbxNoticeCharge.Text != "" && double.Parse(this.tbxNoticeCharge.Text) >= 0.0)
                              {
                                if (this.tbxOtherCharge.Text.Trim() != "" && this.tbxOtherCharge.Text != "" && double.Parse(this.tbxOtherCharge.Text) >= 0.0)
                                {
                                  if (this.tbxDeductions.Text.Trim() != "" && this.tbxDeductions.Text != "" && double.Parse(this.tbxDeductions.Text) >= 0.0)
                                  {
                                    if (this.tbxFinalInterest.Text.Trim() != "" && this.tbxFinalInterest.Text != "" && double.Parse(this.tbxFinalInterest.Text) >= 0.0)
                                    {
                                      if (this.tbxTotal.Text.Trim() != "" && this.tbxTotal.Text != "" && double.Parse(this.tbxTotal.Text) >= 0.0)
                                      {
                                        if (this.tbxNoOfMonths.Text.Trim() != "" && this.tbxNoOfMonths.Text != "" && double.Parse(this.tbxNoOfMonths.Text) >= 0.0)
                                        {
                                          if (this.tbxNoOfMonths16.Text.Trim() != "" && this.tbxNoOfMonths16.Text != "" && double.Parse(this.tbxNoOfMonths16.Text) >= 0.0)
                                          {
                                            if (this.tbxInterest16.Text.Trim() != "" && this.tbxInterest16.Text != "" && double.Parse(this.tbxInterest16.Text) >= 0.0)
                                            {
                                              if (this.tbxRedemptionAmount16.Text.Trim() != "" && this.tbxRedemptionAmount16.Text != "" && double.Parse(this.tbxRedemptionAmount16.Text) >= 0.0)
                                                return true;
                                              Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                              this.tbxPledgeBillNumber.Select();
                                              return false;
                                            }
                                            Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                            this.tbxPledgeBillNumber.Select();
                                            return false;
                                          }
                                          Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                          this.tbxPledgeBillNumber.Select();
                                          return false;
                                        }
                                        Transition.run((object) this.tbxNoOfMonths, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                        this.tbxNoOfMonths.Select();
                                        return false;
                                      }
                                      Transition.run((object) this.tbxTotal, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                      this.tbxTotal.Select();
                                      return false;
                                    }
                                    Transition.run((object) this.tbxFinalInterest, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                    this.tbxFinalInterest.Select();
                                    return false;
                                  }
                                  Transition.run((object) this.tbxDeductions, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                  this.tbxDeductions.Select();
                                  return false;
                                }
                                Transition.run((object) this.tbxOtherCharge, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                                this.tbxOtherCharge.Select();
                                return false;
                              }
                              Transition.run((object) this.tbxNoticeCharge, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                              this.tbxNoticeCharge.Select();
                              return false;
                            }
                            Transition.run((object) this.tbxInterestLess, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                            this.tbxInterestLess.Select();
                            return false;
                          }
                          Transition.run((object) this.tbxInterest, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                          this.tbxInterest.Select();
                          return false;
                        }
                        Transition.run((object) this.tbxInterestRate, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                        this.tbxInterestRate.Select();
                        return false;
                      }
                      Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                      this.tbxPledgeBillNumber.Select();
                      return false;
                    }
                    Transition.run((object) this.tbxReleasedBy, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                    this.tbxReleasedBy.Select();
                    return false;
                  }
                  Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                  this.tbxPledgeBillNumber.Select();
                  return false;
                }
                Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                this.tbxPledgeBillNumber.Select();
                return false;
              }
              Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
              this.tbxRedemptionBillNumber.Select();
              return false;
            }
            Transition.run((object) this.tbxRedemptionDate, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
            this.tbxRedemptionDate.Select();
            return false;
          }
          Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
          this.tbxPledgeBillNumber.Select();
          return false;
        }
        Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
        this.tbxPledgeBillNumber.Select();
        return false;
      }
      this.cbShopCodes.Select();
      return false;
    }

    private void updateTablePartPayment()
    {
      DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxRedemptionBillNumber.Text + "(" + this.cbShopCodes.Text + ")");
      if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
      {
        string voucherNumber = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        string s = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
        if (this.tbxPaymentReceived.Text != "" && double.Parse(this.tbxPaymentReceived.Text) > 0.0)
        {
          PawnManagementClass.updatetblVouchersAmountOnly(voucherNumber, double.Parse(this.tbxPaymentReceived.Text));
        }
        else
        {
          DateTime now = DateTime.Parse(s);
          if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
          {
            string strError = "";
            if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
            {
              new OleDbParameter("Active", (object) "0"),
              new OleDbParameter("VoucherNumber", (object) voucherNumber)
            }, ref strError) == "Done")
            {
              string ActionDetails = "VOUCHER NUMBER " + voucherNumber + " Date " + s + " deleted";
              string username = FormMain.username;
              now = DateTime.Now;
              string PerformedOn = now.ToString();
              PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
              int num = (int) MessageBox.Show("successfully deleted");
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
          }
        }
      }
      else
        this.insertIntoTableVouchersPartPayment();
    }

    private void print()
    {
      if (!PawnManagementClass.getRedemptionBillPrintSettings() || DialogResult.Yes != MessageBox.Show("Print?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      this.rd = PawnManagementClass.getRedemptionBill(this.tbxRedemptionBillNumber.Text, this.cbShopCodes.Text);
      if (this.rd != null)
        this.rd.PrintToPrinter(1, false, 1, 1);
    }

    private void insertIntoTableVouchersPartPayment()
    {
      try
      {
        string s = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
        string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
        if (!(this.tbxPaymentReceived.Text != "") || double.Parse(this.tbxPaymentReceived.Text) <= 0.0)
          return;
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), (int.Parse(maxOfVoucherNumber) + 1).ToString(), this.getVoucherCode(this.tbxPledgeBillNumber.Text + "(" + this.cbShopCodes.Text + ")"), this.tbxPledgeBillNumber.Text + "(" + this.cbShopCodes.Text + ")", this.tbxRedemptionBillNumber.Text.Trim().ToString() + "(" + this.cbShopCodes.Text + ")", "U1", "NOVAE", double.Parse(this.tbxPaymentReceived.Text.Trim().ToString()));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form redemption.insertIntoTableVouchersPartPayment()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getVoucherCode(string BillNumber)
    {
      string strError = "";
      string my_querry = "Select * from tblvouchermaster where vouchername = @vouchername";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("vouchername", (object) BillNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpapyment.getVoucherCode", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form partpapyment.getVoucherCode" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["vouchercode"].ToString();
      return "";
    }

    private void updateTableVouchers()
    {
      try
      {
        DataTable voucherNumberAndDate1 = this.getVoucherNumberAndDate(this.tbxRedemptionBillNumber.Text.Trim().ToString() + " RedemptionBillNumber " + this.cbShopCodes.Text);
        string voucherNumber1 = voucherNumberAndDate1.Rows[0]["voucherNumber"].ToString();
        string str = voucherNumberAndDate1.Rows[0]["voucherDate"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(str))
        {
          DataTable voucherNumberAndDate2 = this.getVoucherNumberAndDate(this.tbxRedemptionBillNumber.Text.Trim().ToString() + " INTEREST CHOOT " + this.cbShopCodes.Text);
          string voucherNumber2 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
          string s1 = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
          string s2 = this.tbxFinalInterest.Text.ToString();
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str), voucherNumber1, this.voucherCode, this.voucherName, this.tbxRedemptionBillNumber.Text.Trim().ToString() + " RedemptionBillNumber " + this.cbShopCodes.Text, "G1", "JAMMA", double.Parse(this.tbxAmount.Text.Trim()));
          PawnManagementClass.updatetblVouchers(DateTime.Parse(s1), voucherNumber2, this.voucherCodeInterestChoot, this.voucherNameInterestChoot, this.tbxRedemptionBillNumber.Text.Trim().ToString() + " INTEREST CHOOT " + this.cbShopCodes.Text, "B1", "JAMMA", double.Parse(s2));
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

    private void insertIntoTableVouchers()
    {
      try
      {
        string s = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
        string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), maxOfVoucherNumber, this.voucherCode, this.voucherName, this.tbxRedemptionBillNumber.Text.Trim().ToString() + " RedemptionBillNumber " + this.cbShopCodes.Text, "G1", "JAMMA", double.Parse(this.tbxAmount.Text.Trim()));
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), (int.Parse(maxOfVoucherNumber) + 1).ToString(), this.voucherCodeInterestChoot, this.voucherNameInterestChoot, this.tbxRedemptionBillNumber.Text.Trim().ToString() + " INTEREST CHOOT " + this.cbShopCodes.Text, "B1", "JAMMA", double.Parse(this.tbxFinalInterest.Text.Trim().ToString()));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.insertIntoTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void updateRedemption()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblRedemption set BillDate= @BillDate,PledgeBillNumber= @PledgeBillNumber,CustomerCode=@CustomerCode,ReleasedBy  = @ReleasedBy,PledgeDate=@PledgeDate,Amount= @Amount,temp1 = @RateOfInterest,temp2=@Interest,InterestLess = @InterestLess,NoticeCharge=@NoticeCharge,OtherCharge=@OtherCharge,Deductions=@Deductions,temp3=@FinalInterest,temp4=@TotalRedemptionAmount,CreatedOn=@CreatedOn,CreatedBy=@CreatedBy where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) this.tbxRedemptionDate.Text.Trim().ToString()),
        new OleDbParameter("PledgeBillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()),
        new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode.Text.Trim().ToString()),
        new OleDbParameter("ReleasedBy", (object) this.tbxReleasedBy.Text.Trim().ToString()),
        new OleDbParameter("PledgeDate", (object) this.tbxPledgeDate.Text.Trim().ToString()),
        new OleDbParameter("Amount", (object) this.tbxAmount.Text.Trim().ToString()),
        new OleDbParameter("RateOfInterest", (object) this.tbxInterestRate.Text.Trim().ToString()),
        new OleDbParameter("Interest", (object) this.tbxInterest.Text.Trim().ToString()),
        new OleDbParameter("InterestLess", (object) this.tbxInterestLess.Text.Trim().ToString()),
        new OleDbParameter("NoiceCharge", (object) this.tbxNoticeCharge.Text.Trim().ToString()),
        new OleDbParameter("OtherCharge", (object) this.tbxOtherCharge.Text.Trim().ToString()),
        new OleDbParameter("Deductions", (object) this.tbxDeductions.Text.Trim().ToString()),
        new OleDbParameter("FinalInterest", (object) this.tbxFinalInterest.Text.Trim().ToString()),
        new OleDbParameter("TotalRedemptionAmount", (object) this.tbxTotal.Text.Trim().ToString()),
        new OleDbParameter("CreatedOn", (object) DateTime.Today.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("BillNumber", (object) this.tbxRedemptionBillNumber.Text.Trim().ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form Redemption. updateRedemption", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in redemption" + strError);
    }

    private void updateRedemptionInPledgeTable()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set Redeemed = @Redeemed,NoOfMonths = @NoOfMonths,temp2=@Interest,InterestLess = @InterestLess,NoticeCharge=@NoticeCharge,OtherCharges=@OtherCharge,Discount=@Discount,temp3=@FinalInterest,temp4=@RedemptionAmount,RedemptionDate=@RedemptionDate,NoOfMonths16=@NoOfMonths16,Interest16= @Interest16,RedemptionAmount16=@RedemptionAmount16,RedeemedBy=@RedeemedBy,RedeemedOn=@RedeemedOn,RedemptionBillNumber = @RedemptionBillNumber where BillNumber =@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Redeemed", (object) "Y"),
        new OleDbParameter("NoOfMonths", (object) this.tbxNoOfMonths.Text.Trim().ToString()),
        new OleDbParameter("Interest", (object) this.tbxInterest.Text.Trim().ToString()),
        new OleDbParameter("InterestLess", (object) this.tbxInterestLess.Text.Trim().ToString()),
        new OleDbParameter("NoticeCharge", (object) this.tbxNoticeCharge.Text.Trim().ToString()),
        new OleDbParameter("OtherCharges", (object) this.tbxOtherCharge.Text.Trim().ToString()),
        new OleDbParameter("Discount", (object) this.tbxDeductions.Text.Trim().ToString()),
        new OleDbParameter("FinalInterest", (object) this.tbxFinalInterest.Text.Trim().ToString()),
        new OleDbParameter("RedemptionAmount", (object) this.tbxTotal.Text.Trim().ToString()),
        new OleDbParameter("RedemptionDate", (object) this.tbxRedemptionDate.Text.Trim().ToString()),
        new OleDbParameter("NoOfMonths16", (object) (int.Parse(this.tbxNoOfMonths.Text.Trim().ToString()) + 1).ToString()),
        new OleDbParameter("Interest16", (object) this.tbxInterest16.Text.Trim().ToString()),
        new OleDbParameter("RedemptionAmount16", (object) this.tbxRedemptionAmount16.Text.Trim().ToString()),
        new OleDbParameter("RedeemedBy", (object) FormMain.username),
        new OleDbParameter("RedeemedOn", (object) DateTime.Today.ToString("dd/MM/yyyy")),
        new OleDbParameter("RedemptionBillNumber", (object) this.tbxRedemptionBillNumber.Text),
        new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form Redemption.UpdateRedemptionInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in redemption in pledge" + strError);
    }

    private void reset()
    {
      this.tbxCustomerCode.Text = string.Empty;
      this.tbxCustomerName.Text = string.Empty;
      this.tbxAddress1.Text = string.Empty;
      this.tbxGrossWeight.Text = string.Empty;
      this.tbxDeduction.Text = string.Empty;
      this.tbxNetWeight.Text = string.Empty;
      this.tbxPureWeight.Text = string.Empty;
      this.tbxAmount.Text = "0";
      this.tbxPledgeDate.Text = string.Empty;
      this.tbxInterestRate.Text = "0";
      this.tbxNoOfMonths.Text = "0";
      this.tbxInterest.Text = "0";
      this.tbxInterest16.Text = "0";
      this.tbxFinalInterest.Text = "0";
      this.tbxTotal.Text = "0";
      this.tbxReceive.Text = "0";
      this.tbxInterestLess.Text = "0";
      this.tbxPaymentReceived.Text = "0";
      this.tbxDeductions.Text = "0";
      this.tbxNoticeCharge.Text = "0";
      this.tbxOtherCharge.Text = "0";
      this.tbxInterestLess.Text = "0";
      this.lblReminder.Text = "";
      this.lblBankBillNumber.Text = "";
      this.dgvArticles.DataSource = (object) null;
      if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
      if (!File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        return;
      using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
        this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
    }

    private void tbxOtherCharge_Leave(object sender, EventArgs e)
    {
      if (!(this.tbxOtherCharge.Text == ""))
        return;
      this.tbxOtherCharge.Text = "0";
    }

    private void tbxDeductions_Leave(object sender, EventArgs e)
    {
      if (!(this.tbxDeductions.Text == ""))
        return;
      this.tbxDeductions.Text = "0";
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

    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void tbxRedemptionDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.redemptionOrEditOrOldRedemption == "Redemption" | this.redemptionOrEditOrOldRedemption == "Auction")
        this.tbxReleasedBy.Select();
      if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            this.tbxRedemptionBillNumber.Select();
            break;
          case "DOUBLE":
            this.tbxRedemptionBillNumber.Select();
            break;
        }
      }
    }

    private void tbxRedemptionBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (FormMain.quickRelease)
        this.tbxTotal.Select();
      else
        this.tbxReleasedBy.Select();
    }

    private void tbxRedemptionBillNumber_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxRedemptionBillNumber_Leave(object sender, EventArgs e)
    {
    }

    private void tbxInterestRate_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (this.tbxInterestRate.Text != "" && double.Parse(this.tbxInterestRate.Text) > 0.0 && double.Parse(this.tbxInterestRate.Text) < 999.0)
        {
          int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
          this.tbxNoOfMonths16.Text = numberOfMonths.ToString();
          if (FormPrintSettings.boolReduceFirstMonthInterest())
            --numberOfMonths;
          this.tbxNoOfMonths.Text = numberOfMonths.ToString();
          double num;
          if (numberOfMonths > 11)
          {
            if (DialogResult.Yes == MessageBox.Show("Caluculate Compound Interest", "Calculate Compound Interest", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              TextBox tbxInterest = this.tbxInterest;
              num = Math.Round(PawnManagementClass.calculateCompundInterest(double.Parse(this.tbxAmount.Text.Trim().ToString()), (double) numberOfMonths, double.Parse(this.tbxInterestRate.Text.Trim().ToString())));
              string str = num.ToString();
              tbxInterest.Text = str;
            }
            else
            {
              TextBox tbxInterest = this.tbxInterest;
              num = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) numberOfMonths * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0, 0);
              string str = num.ToString();
              tbxInterest.Text = str;
            }
          }
          else
            this.tbxInterest.Text = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) numberOfMonths * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0).ToString();
          TextBox tbxInterest16 = this.tbxInterest16;
          num = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) (numberOfMonths + 1) * FormRedemption.shopInterestRate / 1200.0);
          string str1 = num.ToString();
          tbxInterest16.Text = str1;
        }
        else
        {
          this.tbxInterestRate.Text = PawnManagement.Classes.PawnManagementClasses.PledgeClass.getRateOfInterestForThisBillNumber(this.cbShopCodes.Text, this.tbxPledgeBillNumber.Text);
          this.tbxInterestRate.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form redemption.tbxinteresstRate_Validating", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxPaymentReceived_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxPaymentReceived.Text == "")
        this.tbxPaymentReceived.Text = "0";
      DataTable detailsForBillNumber = PawnManagementClass.getPaymentDetailsForBillNumber(this.tbxPledgeBillNumber.Text.Trim(), this.cbShopCodes.Text);
      if (detailsForBillNumber == null || detailsForBillNumber.Rows.Count <= 0)
        return;
      if (DialogResult.Yes == MessageBox.Show("Do you want to less the interest for payment received?", "Less interest for payment Received?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        this.dtPaymentDetails = PawnManagementClass.getPaymentDetailsForBillNumber(this.tbxPledgeBillNumber.Text.Trim(), this.cbShopCodes.Text);
        this.dtPaymentDetails.Columns.Add("PledgeNumber");
        this.dtPaymentDetails.Columns.Add("PledgeAmount");
        this.dtPaymentDetails.Columns.Add("PledgeBillDate");
        this.dtPaymentDetails.Columns.Add("RateOfInterest");
        this.dtPaymentDetails.Columns.Add("N1");
        this.dtPaymentDetails.Columns.Add("InterestPayable");
        this.dtPaymentDetails.Columns.Add("RemainingAmount");
        this.dtPaymentDetails.Columns.Add("N2");
        this.dtPaymentDetails.Columns.Add("Interest");
        foreach (DataRow row in (InternalDataCollectionBase) this.dtPaymentDetails.Rows)
        {
          row["PledgeNumber"] = (object) this.tbxPledgeBillNumber.Text;
          row["PledgeAmount"] = (object) this.tbxAmount.Text;
          row["PledgeBillDate"] = (object) this.tbxPledgeDate.Text;
          row["RateOfInterest"] = (object) this.tbxInterestRate.Text;
        }
        double num = 0.0;
        foreach (DataRow row in (InternalDataCollectionBase) this.dtPaymentDetails.Rows)
        {
          row["N1"] = (object) PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["PledgeBillDate"].ToString()), DateTime.Parse(row["BillDate"].ToString()));
          row["InterestPayable"] = (object) (double.Parse(row["PledgeAmount"].ToString()) * (double.Parse(row["N1"].ToString()) - 1.0) * double.Parse(row["RateOfInterest"].ToString()) / 1200.0).ToString();
          if (double.Parse(row["InterestPayable"].ToString()) < double.Parse(row["Amount"].ToString()))
          {
            row["RemainingAmount"] = (object) (double.Parse(row["Amount"].ToString()) - double.Parse(row["InterestPayable"].ToString()));
            string s = (PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Now) - 1).ToString();
            row["N2"] = double.Parse(s) < 0.0 ? (object) 0 : (object) s;
            row["Interest"] = (object) Math.Round(double.Parse(row["RemainingAmount"].ToString()) * double.Parse(row["N2"].ToString()) * double.Parse(row["RateOfInterest"].ToString()) / 1200.0).ToString();
            num += double.Parse(row["Interest"].ToString());
          }
          else
          {
            row["N2"] = (object) "0";
            row["Interest"] = (object) "0";
          }
        }
        this.tbxInterestLess.Text = num.ToString();
      }
      else
        this.tbxInterestLess.Text = "0";
    }

    private void tbxPledgeBillNumber_Validating(object sender, CancelEventArgs e)
    {
      if (!FormMain.quickRelease)
      {
        if (!(this.redemptionOrEditOrOldRedemption == "Redemption" | this.redemptionOrEditOrOldRedemption == "RedemptionOld" | this.redemptionOrEditOrOldRedemption == "Auction"))
          return;
        if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
          this.tbxRedemptionBillNumber.ReadOnly = false;
        try
        {
          switch (FormMain.BillNumberSeries)
          {
            case "SINGLE":
              if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              {
                this.getBillDetails();
                break;
              }
              Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              break;
            case "DOUBLE":
              if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
              {
                this.getBillDetails();
              }
              else
              {
                Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
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
      else
      {
        if (!FormMain.quickRelease || !(this.redemptionOrEditOrOldRedemption == "Redemption" | this.redemptionOrEditOrOldRedemption == "RedemptionOld"))
          return;
        if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
          this.tbxRedemptionBillNumber.ReadOnly = false;
        try
        {
          switch (FormMain.BillNumberSeries)
          {
            case "SINGLE":
              if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              {
                this.getBillDetails();
                if (this.redemptionOrEditOrOldRedemption == "Redemption")
                {
                  this.tbxRedemptionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                  this.calculateInterestQuick();
                  this.tbxPaymentReceived.Text = PawnManagementClass.getPaymentSum(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text).ToString();
                  this.calculateInterestLessQuick();
                  this.calculateFinalInterestQuick();
                  break;
                }
                this.tbxRedemptionDate.Text = RedemptionClass.getMaxRedemptionDate(this.cbShopCodes.Text).ToString("dd/MM/yyyy");
                break;
              }
              Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              break;
            case "DOUBLE":
              if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
              {
                this.getBillDetails();
              }
              else
              {
                Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
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
    }

    private void calculateFinalInterestQuick()
    {
      this.tbxFinalInterest.Text = (double.Parse(this.tbxInterest.Text.Trim().ToString()) + double.Parse(this.tbxNoticeCharge.Text.Trim().ToString()) + double.Parse(this.tbxOtherCharge.Text.Trim().ToString()) - double.Parse(this.tbxDeductions.Text.Trim().ToString()) - double.Parse(this.tbxInterestLess.Text)).ToString();
      this.tbxTotal.Text = (double.Parse(this.tbxAmount.Text.Trim().ToString()) + double.Parse(this.tbxFinalInterest.Text.Trim().ToString())).ToString();
      this.tbxRedemptionAmount16.Text = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) + double.Parse(this.tbxInterest16.Text.Trim().ToString())).ToString();
      this.tbxReceive.Text = Math.Round(double.Parse(this.tbxTotal.Text) - double.Parse(this.tbxPaymentReceived.Text)).ToString();
    }

    private void calculateInterestQuick()
    {
      try
      {
        if (this.tbxInterestRate.Text != "" && double.Parse(this.tbxInterestRate.Text) > 0.0 && double.Parse(this.tbxInterestRate.Text) < 999.0)
        {
          int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
          this.tbxNoOfMonths16.Text = numberOfMonths.ToString();
          if (FormPrintSettings.boolReduceFirstMonthInterest())
            --numberOfMonths;
          this.tbxNoOfMonths.Text = numberOfMonths.ToString();
          double num;
          if (numberOfMonths > 11)
          {
            if (DialogResult.Yes == MessageBox.Show("Caluculate Compound Interest", "Calculate Compound Interest", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              TextBox tbxInterest = this.tbxInterest;
              num = Math.Round(PawnManagementClass.calculateCompundInterest(double.Parse(this.tbxAmount.Text.Trim().ToString()), (double) numberOfMonths, double.Parse(this.tbxInterestRate.Text.Trim().ToString())));
              string str = num.ToString();
              tbxInterest.Text = str;
            }
            else
            {
              TextBox tbxInterest = this.tbxInterest;
              num = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) numberOfMonths * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0, 0);
              string str = num.ToString();
              tbxInterest.Text = str;
            }
          }
          else
            this.tbxInterest.Text = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) numberOfMonths * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0).ToString();
          TextBox tbxInterest16 = this.tbxInterest16;
          num = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) (numberOfMonths + 1) * FormRedemption.shopInterestRate / 1200.0);
          string str1 = num.ToString();
          tbxInterest16.Text = str1;
        }
        else
        {
          this.tbxInterestRate.Text = PawnManagement.Classes.PawnManagementClasses.PledgeClass.getRateOfInterestForThisBillNumber(this.cbShopCodes.Text, this.tbxPledgeBillNumber.Text);
          this.tbxInterestRate.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form redemption.tbxinteresstRate_Validating", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void calculateInterestLessQuick()
    {
      if (this.tbxPaymentReceived.Text == "")
        this.tbxPaymentReceived.Text = "0";
      DataTable detailsForBillNumber = PawnManagementClass.getPaymentDetailsForBillNumber(this.tbxPledgeBillNumber.Text.Trim(), this.cbShopCodes.Text);
      if (detailsForBillNumber == null || detailsForBillNumber.Rows.Count <= 0)
        return;
      if (DialogResult.Yes == MessageBox.Show("Do you want to less the interest for payment received?", "Less interest for payment Received?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        this.dtPaymentDetails = PawnManagementClass.getPaymentDetailsForBillNumber(this.tbxPledgeBillNumber.Text.Trim(), this.cbShopCodes.Text);
        this.dtPaymentDetails.Columns.Add("PledgeNumber");
        this.dtPaymentDetails.Columns.Add("PledgeAmount");
        this.dtPaymentDetails.Columns.Add("PledgeBillDate");
        this.dtPaymentDetails.Columns.Add("RateOfInterest");
        this.dtPaymentDetails.Columns.Add("N1");
        this.dtPaymentDetails.Columns.Add("InterestPayable");
        this.dtPaymentDetails.Columns.Add("RemainingAmount");
        this.dtPaymentDetails.Columns.Add("N2");
        this.dtPaymentDetails.Columns.Add("Interest");
        foreach (DataRow row in (InternalDataCollectionBase) this.dtPaymentDetails.Rows)
        {
          row["PledgeNumber"] = (object) this.tbxPledgeBillNumber.Text;
          row["PledgeAmount"] = (object) this.tbxAmount.Text;
          row["PledgeBillDate"] = (object) this.tbxPledgeDate.Text;
          row["RateOfInterest"] = (object) this.tbxInterestRate.Text;
        }
        double num = 0.0;
        foreach (DataRow row in (InternalDataCollectionBase) this.dtPaymentDetails.Rows)
        {
          row["N1"] = (object) PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["PledgeBillDate"].ToString()), DateTime.Parse(row["BillDate"].ToString()));
          row["InterestPayable"] = (object) (double.Parse(row["PledgeAmount"].ToString()) * (double.Parse(row["N1"].ToString()) - 1.0) * double.Parse(row["RateOfInterest"].ToString()) / 1200.0).ToString();
          if (double.Parse(row["InterestPayable"].ToString()) < double.Parse(row["Amount"].ToString()))
          {
            row["RemainingAmount"] = (object) (double.Parse(row["Amount"].ToString()) - double.Parse(row["InterestPayable"].ToString()));
            string s = (PawnManagementClass.getNumberOfMonths(DateTime.Parse(row["BillDate"].ToString()), DateTime.Now) - 1).ToString();
            row["N2"] = double.Parse(s) < 0.0 ? (object) 0 : (object) s;
            row["Interest"] = (object) Math.Round(double.Parse(row["RemainingAmount"].ToString()) * double.Parse(row["N2"].ToString()) * double.Parse(row["RateOfInterest"].ToString()) / 1200.0).ToString();
            num += double.Parse(row["Interest"].ToString());
          }
          else
          {
            row["N2"] = (object) "0";
            row["Interest"] = (object) "0";
          }
        }
        this.tbxInterestLess.Text = num.ToString();
      }
      else
        this.tbxInterestLess.Text = "0";
    }

    private void getNoticeChargeQuick()
    {
      if (!PawnManagement.Classes.PawnManagementClasses.PledgeClass.getIntimationLetterSentOrNot(this.cbShopCodes.Text, this.tbxPledgeBillNumber.Text))
        return;
      this.tbxNoticeCharge.Text = SettingsClass.getNoticeChargeInRedemptionScreen();
    }

    private void getBillDetails()
    {
      string strError = "";
      string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.tbxPledgeBillNumber_Leave ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
        this.tbxPledgeBillNumber.Select();
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0].Field<string>("Redeemed") == "N")
        {
          this.tbxCustomerCode.Text = dataTable2.Rows[0].Field<string>("CustomerCode");
          this.tbxCustomerName.Text = dataTable2.Rows[0].Field<string>("CustomerName");
          this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("DoorNumber") + " " + dataTable2.Rows[0].Field<string>("Addr1") + dataTable2.Rows[0].Field<string>("Addr2");
          this.tbxGrossWeight.Text = dataTable2.Rows[0].Field<string>("GrossWeight").ToString();
          this.tbxDeduction.Text = dataTable2.Rows[0].Field<string>("Deduction").ToString();
          this.tbxNetWeight.Text = dataTable2.Rows[0].Field<string>("NetWeight").ToString();
          this.tbxPureWeight.Text = dataTable2.Rows[0].Field<double>("PureWeight").ToString();
          this.tbxAmount.Text = dataTable2.Rows[0].Field<int>("Amount").ToString();
          this.tbxPledgeDate.Text = dataTable2.Rows[0].Field<DateTime>("BillDate").ToString("dd/MM/yyyy");
          this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
          this.lblReminder.Text = this.getReminderCustomer(this.tbxCustomerCode.Text.Trim());
          this.lblReminder.Text += dataTable2.Rows[0].Field<string>("Reminder").ToString();
          this.tbxReleasedBy.Text = dataTable2.Rows[0].Field<string>("CustomerName");
          if (this.lblReminder.Text != "")
            this.lblReminder.Visible = true;
          if (FormMain.memberType == "ak")
            this.tbxInterestRate.Text = PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0].Field<string>("RateOfInterest");
          this.getArticles();
          this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
          if (this.checkIfBankPledgeReleasedOrNot(this.getBankBillNumber(this.tbxPledgeBillNumber.Text.Trim().ToString())))
          {
            this.lblBankBillNumber.Text = "";
            this.lblBankBillNumber.Text = dataTable2.Rows[0]["BankCode"].ToString();
            this.getBankPledgeDetails(this.getBankBillNumber(this.tbxPledgeBillNumber.Text.Trim().ToString()));
            if (!(this.lblBankBillNumber.Text != ""))
              return;
            this.lblBankBillNumber.Visible = true;
          }
        }
        else if (dataTable2.Rows[0].Field<string>("Redeemed") == "Y")
        {
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.lblMessage.Text = "Bill Number Already released";
          this.tbxPledgeBillNumber.Select();
          Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
          Transition.run((object) this.lblMessage, "BackColor", (object) Color.Blue, (ITransitionType) new TransitionType_Flash(4, 200));
        }
        else if (dataTable2.Rows[0].Field<string>("Redeemed") == "A")
        {
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.lblMessage.Text = "Bill Number already auctioned";
          this.tbxPledgeBillNumber.Select();
          Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
        }
        else
        {
          this.lblMessage.Text = "ENTER VALID BILL NUMBER";
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.tbxPledgeBillNumber.Select();
          Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
          Transition.run((object) this.lblMessage, "BackColor", (object) Color.Blue, (ITransitionType) new TransitionType_Flash(4, 200));
        }
      }
      else
      {
        this.timer1.Start();
        this.lblMessage.Text = "Aisa koi bill number aapnae entry kiya hee nahi hay";
        this.tbxPledgeBillNumber.Select();
        Transition.run((object) this.tbxPledgeBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
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

    private void tbxRedemptionBillNumber_Validating(object sender, CancelEventArgs e)
    {
      if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
      {
        try
        {
          switch (FormMain.BillNumberSeries)
          {
            case "SINGLE":
              if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              {
                string strError = "";
                string my_querry = "select *,temp1 as rateofinterest,temp2 as interest,temp3 as finalinterest,temp4 as totalredemptionamount from tblredemption   where BillNumber=@BillNumber and shopcode = @ShopCode";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxRedemptionBillNumber.Text.Trim().ToString()));
                parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
                if (strError != "")
                {
                  PawnManagementClass.InsertIntoException("form Redemption.tbxRedemptionBillNumber_Leave", strError, FormMain.username, DateTime.Now.ToString());
                  int num = (int) MessageBox.Show("Error in retrieving RedemptionBillNumber for checking whether it exists or not" + strError);
                  this.tbxRedemptionBillNumber.Select();
                  break;
                }
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                  Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                  int num = (int) MessageBox.Show("Already a bill is released in this Redemption Bill Number... Please check again");
                  this.tbxRedemptionBillNumber.Select();
                }
                else
                {
                  this.calculateInterestQuick();
                  this.tbxPaymentReceived.Text = PawnManagementClass.getPaymentSum(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text).ToString();
                  this.calculateInterestLessQuick();
                  this.calculateFinalInterestQuick();
                }
                break;
              }
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
              break;
            case "DOUBLE":
              if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
              {
                string strError = "";
                string my_querry = "select *,temp1 as rateofinterest,temp2 as interest,temp3 as finalinterest,temp4 as totalredemptionamount from tblredemption   where BillNumber=@BillNumber and shopcode = @ShopCode";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxRedemptionBillNumber.Text.Trim().ToString()));
                parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
                DataTable dataTable3 = new DataTable();
                DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
                if (strError != "")
                {
                  PawnManagementClass.InsertIntoException("form Redemption.tbxRedemptionBillNumber_Leave", strError, FormMain.username, DateTime.Now.ToString());
                  int num = (int) MessageBox.Show("Error in retrieving RedemptionBillNumber for checking whether it exists or not" + strError);
                  this.tbxRedemptionBillNumber.Select();
                }
                else if (dataTable4 != null && dataTable4.Rows.Count > 0)
                {
                  int num = (int) MessageBox.Show("Already a bill is released in this Redemption Bill Number... Please check again");
                  this.tbxRedemptionBillNumber.Select();
                  Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
                }
                else
                {
                  this.calculateInterestQuick();
                  this.tbxPaymentReceived.Text = PawnManagementClass.getPaymentSum(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text).ToString();
                  this.calculateInterestLessQuick();
                  this.calculateFinalInterestQuick();
                }
              }
              else
              {
                (sender as TextBox).Select();
                (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
                Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
              }
              break;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form oldpledge.tbxBillNumber_Leave", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        }
      }
      if (!(this.redemptionOrEditOrOldRedemption == "RedemptionEdit"))
        return;
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
            Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
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
              Transition.run((object) this.tbxRedemptionBillNumber, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
            }
            break;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form oldpledge.tbxBillNumber_Leave", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
      }
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
            this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("Addr1") + dataTable2.Rows[0].Field<string>("Addr2");
            this.tbxGrossWeight.Text = dataTable2.Rows[0].Field<string>("GrossWeight").ToString();
            this.tbxDeduction.Text = dataTable2.Rows[0].Field<string>("Deduction").ToString();
            this.tbxNetWeight.Text = dataTable2.Rows[0].Field<string>("NetWeight").ToString();
            TextBox tbxAmount = this.tbxAmount;
            int num = dataTable2.Rows[0].Field<int>("Amount");
            string str1 = num.ToString();
            tbxAmount.Text = str1;
            TextBox tbxPledgeDate = this.tbxPledgeDate;
            DateTime dateTime = dataTable2.Rows[0].Field<DateTime>("BillDate");
            string str2 = dateTime.ToString("dd/MM/yyyy");
            tbxPledgeDate.Text = str2;
            this.tbxPledgeDate.Enabled = false;
            this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
            this.tbxPledgeBillNumber.Text = pledgeBillNumber;
            this.tbxPledgeBillNumber.Enabled = false;
            TextBox tbxRedemptionDate = this.tbxRedemptionDate;
            dateTime = dataTable2.Rows[0].Field<DateTime>("RedemptionDate");
            string str3 = dateTime.ToString("dd/MM/yyyy");
            tbxRedemptionDate.Text = str3;
            this.tbxInterest.Text = dataTable2.Rows[0]["Interest"].ToString();
            TextBox tbxInterestLess = this.tbxInterestLess;
            num = dataTable2.Rows[0].Field<int>("InterestLess");
            string str4 = num.ToString();
            tbxInterestLess.Text = str4;
            TextBox tbxNoticeCharge = this.tbxNoticeCharge;
            num = dataTable2.Rows[0].Field<int>("NoticeCharge");
            string str5 = num.ToString();
            tbxNoticeCharge.Text = str5;
            TextBox tbxOtherCharge = this.tbxOtherCharge;
            num = dataTable2.Rows[0].Field<int>("OtherCharges");
            string str6 = num.ToString();
            tbxOtherCharge.Text = str6;
            TextBox tbxDeductions = this.tbxDeductions;
            num = dataTable2.Rows[0].Field<int>("Discount");
            string str7 = num.ToString();
            tbxDeductions.Text = str7;
            this.tbxFinalInterest.Text = dataTable2.Rows[0]["FinalInterest"].ToString();
            this.tbxTotal.Text = dataTable2.Rows[0]["RedemptionAmount"].ToString();
            TextBox tbxNoOfMonths = this.tbxNoOfMonths;
            num = dataTable2.Rows[0].Field<int>("NoOfMonths");
            string str8 = num.ToString();
            tbxNoOfMonths.Text = str8;
            this.oldValues = "Old Values are \n Interest =" + this.tbxInterest.Text.Trim().ToString() + " \n NoticeCharge = " + this.tbxNoticeCharge.Text.Trim().ToString() + " \n OtherCharges = " + this.tbxOtherCharge.Text.Trim().ToString() + " \n Discount =  " + this.tbxDeductions.Text.Trim().ToString() + "\n FinalInterest =  " + this.tbxFinalInterest.Text.Trim().ToString() + "\n RedemptionAmount =  " + this.tbxTotal.Text.Trim().ToString();
            this.getArticles();
            this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
            int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
            this.tbxNoOfMonths16.Text = numberOfMonths.ToString();
            if (FormPrintSettings.boolReduceFirstMonthInterest())
              --numberOfMonths;
            this.tbxNoOfMonths.Text = numberOfMonths.ToString();
            this.tbxInterest.Text = (double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) numberOfMonths * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0).ToString();
            this.tbxInterest16.Text = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) * (double) (numberOfMonths + 1) * FormRedemption.shopInterestRate / 1200.0).ToString();
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

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        FormRedemption.shopInterestRate = ShopDetailsClass.getInterestRate(this.cbShopCodes.Text);
        if (this.redemptionOrEditOrOldRedemption == "Redemption")
        {
          this.lstPledgeBillNumbers = PledgeClass.getUndredeemedBillNumbers(this.cbShopCodes.Text);
          this.getRedemptionBillNumber();
          if (FormMain.lsttoRelease.Count > 0)
          {
            this.tbxPledgeBillNumber.Text = FormMain.lsttoRelease[0].Substring(0, FormMain.lsttoRelease[0].IndexOf(','));
            this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
            this.tbxPledgeBillNumber.Select();
            this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tbxPledgeBillNumber.AutoCompleteCustomSource.Clear();
            this.tbxPledgeBillNumber.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
          }
          else
          {
            this.tbxPledgeBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
            this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
            this.tbxPledgeBillNumber.Select();
            this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tbxPledgeBillNumber.AutoCompleteCustomSource.Clear();
            this.tbxPledgeBillNumber.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
          }
        }
        else if (this.redemptionOrEditOrOldRedemption == "RedemptionOld")
        {
          this.lstPledgeBillNumbers = PledgeClass.getUndredeemedBillNumbers(this.cbShopCodes.Text);
          this.getRedemptionBillNumber();
          this.tbxPledgeBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
          this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
          this.tbxPledgeBillNumber.Select();
          this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
          this.tbxPledgeBillNumber.AutoCompleteCustomSource.Clear();
          this.tbxPledgeBillNumber.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
        }
        else if (this.redemptionOrEditOrOldRedemption == "RedemptionEdit")
        {
          this.BackColor = Color.LightBlue;
          this.getRedemptionBillNumbers();
          this.tbxRedemptionBillNumber.ReadOnly = false;
          this.tbxRedemptionBillNumber.Text = PawnManagementClass.getRedemptionBillNumberSeries(this.cbShopCodes.Text) + "0";
          this.tbxRedemptionBillNumber.Select();
          this.tbxRedemptionBillNumber.SelectionStart = this.tbxRedemptionBillNumber.Text.Length;
          this.tbxRedemptionBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
          this.tbxRedemptionBillNumber.AutoCompleteCustomSource.AddRange(this.lstRedemptionBillNumbers.ToArray());
        }
        this.getLedgerAndVoucherCode();
        this.ledgerName = LedgerMaster.getLedgerName(this.ledgerCode);
        this.ledgerNameInterest = LedgerMaster.getLedgerName(this.ledgerCodeInterest);
        this.voucherName = VoucherMasterClass.getVoucherName(this.voucherCode);
        this.voucherNameInterestChoot = VoucherMasterClass.getVoucherName(this.voucherCodeInterestChoot);
      }
      else
        this.cbShopCodes.Select();
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
          this.voucherCodeInterestChoot = dataTable2.Rows[0]["vouchercodeinterestChoot"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form pledge.getledgerandvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshSidePanel(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable("Select  shopcode,BillNumber,PledgeBillNumber,tr.Amount,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tc.CName as CustomerName,BillDate from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate order by shopcode,billnumber", new List<OleDbParameter>()
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
          num2 += double.Parse(row["FinalInterest"].ToString());
        }
      }
      dataTable2.Rows.Add();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["Amount"] = (object) num1.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["FinalInterest"] = (object) num2.ToString();
      dataTable2.Rows[dataTable2.Rows.Count - 1]["BillNumber"] = (object) (dataTable2.Rows.Count - 1);
      Form mdiParent = this.MdiParent;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).DataSource = (object) dataTable2;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).FirstDisplayedScrollingRowIndex = ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).RowCount - 1;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).Columns["Shopcode"].Visible = false;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).Columns["BillDate"].Visible = false;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      ((mdiParent.Controls["splitContainer1"] as SplitContainer).Panel2.Controls["dataGridView2"] as DataGridView).Columns["FinalInterest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

    private void tbxPledgeBillNumber_KeyPress(object sender, KeyPressEventArgs e)
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

    private void glassButton19_Click(object sender, EventArgs e) => this.TakeReleasedByPhoto();

    private void TakeReleasedByPhoto()
    {
      if (!(this.tbxRedemptionBillNumber.Text.Trim() != ""))
        return;
      int num = (int) new FormCamera(this.tbxRedemptionBillNumber.Text + " " + this.cbShopCodes.Text, "releasedByPhoto").ShowDialog();
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " " + this.cbShopCodes.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + " " + this.cbShopCodes.Text + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      if (this.tbxPledgeBillNumber.Text != "" && DialogResult.Yes == MessageBox.Show("PRINT Form D?", "PRINT Form D???", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        ReportDocument RD = new ReportDocument();
        RD.Load("Reports\\\\DForms\\\\ReportFormD.rpt");
        FormCrystalReportViewer crystalReportViewer = new FormCrystalReportViewer(RD);
        crystalReportViewer.MdiParent = this.MdiParent;
        foreach (Form openForm in (ReadOnlyCollectionBase) Application.OpenForms)
        {
          if (openForm.GetType() == typeof (FormCrystalReportViewer))
          {
            openForm.BringToFront();
            openForm.WindowState = FormWindowState.Maximized;
            return;
          }
        }
        crystalReportViewer.Show();
        crystalReportViewer.WindowState = FormWindowState.Maximized;
      }
      this.tbxReleasedBy.Select();
    }

    private void FormRedemption_MouseEnter(object sender, EventArgs e)
    {
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

    private void FormRedemption_Activated(object sender, EventArgs e)
    {
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

    private void deletePHotoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png"))
          return;
        File.Delete(FormMain.startUpPath + "Photos\\released by\\" + this.tbxRedemptionBillNumber.Text.Trim().ToString() + ".png");
        this.pictureBox2.Image = (Image) null;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void tbxInterest_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxPaymentReceived.Select();
    }

    private void tbxNoticeCharge_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxOtherCharge.Select();
    }

    private void tbxDeductions_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFinalInterest.Select();
    }

    private void tbxOtherCharge_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxDeductions.Select();
    }

    private void tbxFinalInterest_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxTotal.Select();
    }

    private void tbxTotal_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxInterestLess_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxNoticeCharge.Select();
    }

    private void tbxReceive_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxInterestLess_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void dgvArticles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxRedemptionDate_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxRedemptionDate.Text != ""))
        return;
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text.ToString()))
        (sender as TextBox).ForeColor = Color.Red;
      else if (this.tbxPledgeDate.Text != "" && PawnManagementClass.checkForValidateDate(this.tbxPledgeDate.Text) && DateTime.Parse(this.tbxPledgeDate.Text).Subtract(DateTime.Parse(this.tbxRedemptionDate.Text)).TotalDays > 0.0)
        (sender as TextBox).ForeColor = Color.Red;
      else
        (sender as TextBox).ForeColor = Color.RoyalBlue;
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPledgeBillNumber.Text != ""))
        return;
      int num = (int) new FormPaymentDetailsForBillNumber(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text).ShowDialog();
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPledgeBillNumber.Text != ""))
        return;
      int num = (int) new FormPaymentDetailsForBillNumber(this.dtPaymentDetails, this.tbxPledgeBillNumber.Text, "PartPaymentInterest", this.cbShopCodes.Text).ShowDialog();
    }

    private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxPaymentReceived_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxPaymentReceived_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxInterestLess.Select();
    }

    private void tbxInterest_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxInterest.Text != "") || double.Parse(this.tbxInterest.Text) < 0.0)
        this.tbxInterest.Text = "0";
      this.tbxPaymentReceived.Text = PawnManagementClass.getPaymentSum(this.tbxPledgeBillNumber.Text, this.cbShopCodes.Text).ToString();
    }

    private void tbxInterestRate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxInterest.Select();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getShopCodes()
    {
    }

    private void tbxNoticeCharge_Leave(object sender, EventArgs e)
    {
      if (!(this.tbxNoticeCharge.Text == ""))
        return;
      this.tbxNoticeCharge.Text = "0";
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxPledgeBillNumber.Select();
    }

    private void tbxGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxRedemptionDate_Enter(object sender, EventArgs e)
    {
      if (!(this.redemptionOrEditOrOldRedemption == "RedemptionOld"))
        return;
      this.tbxRedemptionDate.Text = RedemptionClass.getMaxRedemptionDate(this.cbShopCodes.Text).ToString("dd/MM/yyyy");
      this.tbxRedemptionDate.Select(0, this.tbxRedemptionDate.Text.IndexOf("/"));
    }

    private void tbxRedemptionBillNumber_Enter(object sender, EventArgs e)
    {
      if (!(this.redemptionOrEditOrOldRedemption == "RedemptionOld") || this.tbxRedemptionBillNumber.Text.Length <= 3)
        return;
      this.tbxRedemptionBillNumber.Select(this.tbxRedemptionBillNumber.Text.Length - 2, 2);
    }

    private void tbxRedemptionAmount16_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxNoOfMonths_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxNoOfMonths.Text != "" && double.Parse(this.tbxNoOfMonths.Text) >= 0.0)
        return;
      int numberOfMonths = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxPledgeDate.Text.Trim().ToString()), DateTime.Parse(this.tbxRedemptionDate.Text.Trim()));
      if (FormPrintSettings.boolReduceFirstMonthInterest())
        --numberOfMonths;
      this.tbxNoOfMonths.Text = numberOfMonths.ToString();
      this.tbxNoOfMonths.Select();
    }

    private void lblHeading_Click(object sender, EventArgs e)
    {
      this.tbxNoOfMonths16.Visible = true;
      this.tbxInterest16.Visible = true;
      this.tbxRedemptionAmount16.Visible = true;
    }

    private void tbxNoticeCharge_Enter(object sender, EventArgs e)
    {
      if (!PawnManagement.Classes.PawnManagementClasses.PledgeClass.getIntimationLetterSentOrNot(this.cbShopCodes.Text, this.tbxPledgeBillNumber.Text))
        return;
      this.tbxNoticeCharge.Text = SettingsClass.getNoticeChargeInRedemptionScreen();
    }

    private void tbxPledgeBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (FormMain.quickRelease)
      {
        if (this.redemptionOrEditOrOldRedemption == "Redemption")
          this.tbxTotal.Select();
        else
          this.tbxRedemptionDate.Select();
      }
      else
        this.tbxRedemptionDate.Select();
    }

    private void cbShopCodes_Enter(object sender, EventArgs e)
    {
      if (this.cbShopCodes.Items.Count == 1)
      {
        this.cbShopCodes.SelectedIndex = 0;
        SendKeys.Send("{Enter}");
      }
      else if (FormMain.lsttoRelease.Count > 0)
        this.cbShopCodes.Text = FormMain.lsttoRelease[0].Substring(FormMain.lsttoRelease[0].IndexOf(',') + 1);
    }

    private void tbxRedemptionDate_Validating(object sender, CancelEventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text.ToString()))
      {
        (sender as TextBox).Select();
        Transition.run((object) this.tbxRedemptionDate, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
      }
      else if (DateTime.Parse(this.tbxPledgeDate.Text).Subtract(DateTime.Parse(this.tbxRedemptionDate.Text)).TotalDays > 0.0)
      {
        Transition.run((object) this.tbxRedemptionDate, "BackColor", (object) Color.Red, (ITransitionType) new TransitionType_Flash(4, 200));
        Transition.run((object) this.tbxPledgeDate, "BackColor", (object) Color.DarkBlue, (ITransitionType) new TransitionType_Flash(4, 200));
        (sender as TextBox).Select();
        this.tbxPledgeDate.ForeColor = Color.Red;
        int num = (int) MessageBox.Show("Redemption Date Pledge date sae kam nahi ho saktha");
      }
      else
        this.tbxPledgeDate.ForeColor = Color.Black;
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void tbxFinalInterest_Enter(object sender, EventArgs e)
    {
      this.tbxFinalInterest.Text = (double.Parse(this.tbxInterest.Text.Trim().ToString()) + double.Parse(this.tbxNoticeCharge.Text.Trim().ToString()) + double.Parse(this.tbxOtherCharge.Text.Trim().ToString()) - double.Parse(this.tbxDeductions.Text.Trim().ToString()) - double.Parse(this.tbxInterestLess.Text)).ToString();
      this.tbxTotal.Text = (double.Parse(this.tbxAmount.Text.Trim().ToString()) + double.Parse(this.tbxFinalInterest.Text.Trim().ToString())).ToString();
      this.tbxRedemptionAmount16.Text = Math.Round(double.Parse(this.tbxAmount.Text.Trim().ToString()) + double.Parse(this.tbxInterest16.Text.Trim().ToString())).ToString();
      this.tbxReceive.Text = Math.Round(double.Parse(this.tbxTotal.Text) - double.Parse(this.tbxPaymentReceived.Text)).ToString();
    }

    private void tbxReleasedBy_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxReleasedBy.Text.Trim() == ""))
        return;
      this.tbxReleasedBy.Text = this.tbxCustomerName.Text;
    }

    private void tbxReleasedBy_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.tbxReleasedBy.Text != this.tbxCustomerName.Text && DialogResult.Yes == MessageBox.Show("Do you want to Take photo of the person releasing the jewel?", "Do you want to Take photo of the person releasing the jewel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
        this.TakeReleasedByPhoto();
      this.tbxInterestRate.Select();
    }

    private void tbxInterestLess_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxInterestLess.Text == ""))
        return;
      this.tbxInterestLess.Text = "0";
    }

    private void tbxFinalInterest_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxFinalInterest.Text.Trim() != ""))
        return;
      if (double.Parse(this.tbxFinalInterest.Text) < 0.0)
        this.tbxFinalInterest.ForeColor = Color.Red;
      else
        this.tbxFinalInterest.ForeColor = Color.Black;
    }

    private void tbxPledgeDate_KeyPress(object sender, KeyPressEventArgs e)
    {
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
      this.tbxPledgeBillNumber = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxNoOfMonths = new TextBox();
      this.tbxPledgeDate = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.tbxInterest = new TextBox();
      this.tbxNoticeCharge = new TextBox();
      this.tbxDeductions = new TextBox();
      this.tbxOtherCharge = new TextBox();
      this.tbxFinalInterest = new TextBox();
      this.tbxTotal = new TextBox();
      this.tbxRedemptionBillNumber = new TextBox();
      this.label5 = new Label();
      this.label7 = new Label();
      this.label10 = new Label();
      this.label4 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.tbxRedemptionDate = new TextBox();
      this.lblMessage = new Label();
      this.timer1 = new Timer(this.components);
      this.timer2 = new Timer(this.components);
      this.tbxPaymentReceived = new TextBox();
      this.label17 = new Label();
      this.btnPaymentReceivedDetails = new GlassButton();
      this.label18 = new Label();
      this.tbxInterestLess = new TextBox();
      this.btnInterestLessDetails = new GlassButton();
      this.tbxReceive = new TextBox();
      this.label19 = new Label();
      this.panel2 = new Panel();
      this.lblHeading = new Label();
      this.panel3 = new Panel();
      this.panel12 = new Panel();
      this.listBox1 = new ListBox();
      this.lblBankBillNumber = new Label();
      this.dgvArticles = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deletePHotoToolStripMenuItem = new ToolStripMenuItem();
      this.tbxPureWeight = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.tbxGrossWeight = new TextBox();
      this.tbxDeduction = new TextBox();
      this.textBox6 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.panel13 = new Panel();
      this.label1 = new Label();
      this.panel11 = new Panel();
      this.pictureBox2 = new PictureBox();
      this.tbxReleasedBy = new TextBox();
      this.panel6 = new Panel();
      this.label24 = new Label();
      this.panel7 = new Panel();
      this.label2 = new Label();
      this.panel4 = new Panel();
      this.label20 = new Label();
      this.btnReleasedBy = new GlassButton();
      this.panel8 = new Panel();
      this.label3 = new Label();
      this.panel1 = new Panel();
      this.tbxCustomerCode = new TextBox();
      this.lblReminder = new RichTextBox();
      this.pictureBox1 = new PictureBox();
      this.label22 = new Label();
      this.label23 = new Label();
      this.tbxAddress1 = new RichTextBox();
      this.tbxCustomerName = new TextBox();
      this.tbxInterest16 = new TextBox();
      this.tbxNoOfMonths16 = new TextBox();
      this.panel5 = new Panel();
      this.panel14 = new Panel();
      this.label13 = new Label();
      this.tbxRedemptionAmount16 = new TextBox();
      this.panel10 = new Panel();
      this.cbShopCodes = new ComboBox();
      this.label12 = new Label();
      this.panel9 = new Panel();
      this.label11 = new Label();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel12.SuspendLayout();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel13.SuspendLayout();
      this.panel11.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.panel6.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel8.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel5.SuspendLayout();
      this.panel14.SuspendLayout();
      this.panel10.SuspendLayout();
      this.panel9.SuspendLayout();
      this.SuspendLayout();
      this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxPledgeBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPledgeBillNumber.BackColor = Color.AliceBlue;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.None;
      this.tbxPledgeBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxPledgeBillNumber.Dock = DockStyle.Bottom;
      this.tbxPledgeBillNumber.Font = new Font("Arial Rounded MT Bold", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.ForeColor = Color.Black;
      this.tbxPledgeBillNumber.Location = new Point(0, 27);
      this.tbxPledgeBillNumber.MaxLength = 6;
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.Size = new Size(202, 41);
      this.tbxPledgeBillNumber.TabIndex = 0;
      this.tbxPledgeBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxPledgeBillNumber.KeyDown += new KeyEventHandler(this.tbxPledgeBillNumber_KeyDown);
      this.tbxPledgeBillNumber.KeyPress += new KeyPressEventHandler(this.tbxPledgeBillNumber_KeyPress);
      this.tbxPledgeBillNumber.Validating += new CancelEventHandler(this.tbxPledgeBillNumber_Validating);
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = SystemColors.MenuHighlight;
      this.tbxAmount.Location = new Point(195, 74);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(167, 35);
      this.tbxAmount.TabIndex = 10;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
      this.tbxNoOfMonths.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoOfMonths.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfMonths.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoOfMonths.Location = new Point(195, 148);
      this.tbxNoOfMonths.MaxLength = 2;
      this.tbxNoOfMonths.Name = "tbxNoOfMonths";
      this.tbxNoOfMonths.Size = new Size(167, 35);
      this.tbxNoOfMonths.TabIndex = 9;
      this.tbxNoOfMonths.Text = "0";
      this.tbxNoOfMonths.TextAlign = HorizontalAlignment.Right;
      this.tbxNoOfMonths.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxNoOfMonths.Validating += new CancelEventHandler(this.tbxNoOfMonths_Validating);
      this.tbxPledgeDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeDate.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeDate.ForeColor = SystemColors.MenuHighlight;
      this.tbxPledgeDate.Location = new Point(195, 37);
      this.tbxPledgeDate.MaxLength = 10;
      this.tbxPledgeDate.Name = "tbxPledgeDate";
      this.tbxPledgeDate.ReadOnly = true;
      this.tbxPledgeDate.Size = new Size(167, 35);
      this.tbxPledgeDate.TabIndex = 12;
      this.tbxPledgeDate.TextAlign = HorizontalAlignment.Right;
      this.tbxPledgeDate.KeyPress += new KeyPressEventHandler(this.tbxPledgeDate_KeyPress);
      this.tbxInterestRate.BackColor = SystemColors.ButtonHighlight;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.ForeColor = Color.RoyalBlue;
      this.tbxInterestRate.Location = new Point(195, 111);
      this.tbxInterestRate.MaxLength = 6;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(167, 35);
      this.tbxInterestRate.TabIndex = 2;
      this.tbxInterestRate.Text = "0";
      this.tbxInterestRate.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxInterestRate_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxInterestRate.Validating += new CancelEventHandler(this.tbxInterestRate_Validating);
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.ForeColor = SystemColors.ControlText;
      this.tbxInterest.Location = new Point(195, 185);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(167, 35);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.Text = "0";
      this.tbxInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxInterest.KeyDown += new KeyEventHandler(this.tbxInterest_KeyDown);
      this.tbxInterest.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxInterest.Validating += new CancelEventHandler(this.tbxInterest_Validating);
      this.tbxNoticeCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoticeCharge.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNoticeCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxNoticeCharge.Location = new Point(195, 296);
      this.tbxNoticeCharge.Name = "tbxNoticeCharge";
      this.tbxNoticeCharge.Size = new Size(167, 35);
      this.tbxNoticeCharge.TabIndex = 4;
      this.tbxNoticeCharge.Text = "0";
      this.tbxNoticeCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxNoticeCharge.Enter += new EventHandler(this.tbxNoticeCharge_Enter);
      this.tbxNoticeCharge.KeyDown += new KeyEventHandler(this.tbxNoticeCharge_KeyDown);
      this.tbxNoticeCharge.KeyPress += new KeyPressEventHandler(this.tbxGrossWeight_KeyPress);
      this.tbxNoticeCharge.Leave += new EventHandler(this.tbxNoticeCharge_Leave);
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.ForeColor = SystemColors.MenuHighlight;
      this.tbxDeductions.Location = new Point(195, 370);
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.Size = new Size(167, 35);
      this.tbxDeductions.TabIndex = 6;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.KeyDown += new KeyEventHandler(this.tbxDeductions_KeyDown);
      this.tbxDeductions.KeyPress += new KeyPressEventHandler(this.tbxGrossWeight_KeyPress);
      this.tbxDeductions.Leave += new EventHandler(this.tbxDeductions_Leave);
      this.tbxOtherCharge.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherCharge.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherCharge.ForeColor = SystemColors.MenuHighlight;
      this.tbxOtherCharge.Location = new Point(195, 333);
      this.tbxOtherCharge.Name = "tbxOtherCharge";
      this.tbxOtherCharge.Size = new Size(167, 35);
      this.tbxOtherCharge.TabIndex = 5;
      this.tbxOtherCharge.Text = "0";
      this.tbxOtherCharge.TextAlign = HorizontalAlignment.Right;
      this.tbxOtherCharge.KeyDown += new KeyEventHandler(this.tbxOtherCharge_KeyDown);
      this.tbxOtherCharge.KeyPress += new KeyPressEventHandler(this.tbxGrossWeight_KeyPress);
      this.tbxOtherCharge.Leave += new EventHandler(this.tbxOtherCharge_Leave);
      this.tbxFinalInterest.BackColor = Color.Moccasin;
      this.tbxFinalInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFinalInterest.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFinalInterest.ForeColor = Color.Firebrick;
      this.tbxFinalInterest.Location = new Point(195, 407);
      this.tbxFinalInterest.Name = "tbxFinalInterest";
      this.tbxFinalInterest.ReadOnly = true;
      this.tbxFinalInterest.Size = new Size(167, 35);
      this.tbxFinalInterest.TabIndex = 7;
      this.tbxFinalInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxFinalInterest.TextChanged += new EventHandler(this.tbxFinalInterest_TextChanged);
      this.tbxFinalInterest.Enter += new EventHandler(this.tbxFinalInterest_Enter);
      this.tbxFinalInterest.KeyDown += new KeyEventHandler(this.tbxFinalInterest_KeyDown);
      this.tbxFinalInterest.KeyPress += new KeyPressEventHandler(this.tbxGrossWeight_KeyPress);
      this.tbxTotal.BackColor = Color.Moccasin;
      this.tbxTotal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.ForeColor = Color.Firebrick;
      this.tbxTotal.Location = new Point(195, 444);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(167, 35);
      this.tbxTotal.TabIndex = 8;
      this.tbxTotal.TextAlign = HorizontalAlignment.Right;
      this.tbxTotal.KeyDown += new KeyEventHandler(this.tbxTotal_KeyDown);
      this.tbxTotal.KeyPress += new KeyPressEventHandler(this.tbxTotal_KeyPress);
      this.tbxRedemptionBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxRedemptionBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxRedemptionBillNumber.BackColor = Color.AliceBlue;
      this.tbxRedemptionBillNumber.BorderStyle = BorderStyle.None;
      this.tbxRedemptionBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxRedemptionBillNumber.Dock = DockStyle.Bottom;
      this.tbxRedemptionBillNumber.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionBillNumber.ForeColor = Color.Black;
      this.tbxRedemptionBillNumber.Location = new Point(0, 28);
      this.tbxRedemptionBillNumber.MaxLength = 6;
      this.tbxRedemptionBillNumber.Name = "tbxRedemptionBillNumber";
      this.tbxRedemptionBillNumber.ReadOnly = true;
      this.tbxRedemptionBillNumber.Size = new Size(218, 40);
      this.tbxRedemptionBillNumber.TabIndex = 45;
      this.tbxRedemptionBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionBillNumber.Enter += new EventHandler(this.tbxRedemptionBillNumber_Enter);
      this.tbxRedemptionBillNumber.KeyDown += new KeyEventHandler(this.tbxRedemptionBillNumber_KeyDown);
      this.tbxRedemptionBillNumber.KeyPress += new KeyPressEventHandler(this.tbxRedemptionBillNumber_KeyPress);
      this.tbxRedemptionBillNumber.Leave += new EventHandler(this.tbxRedemptionBillNumber_Leave);
      this.tbxRedemptionBillNumber.Validating += new CancelEventHandler(this.tbxRedemptionBillNumber_Validating);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(93, 80);
      this.label5.Name = "label5";
      this.label5.Size = new Size(93, 24);
      this.label5.TabIndex = 51;
      this.label5.Text = "AMOUNT";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkBlue;
      this.label7.Location = new Point(49, 43);
      this.label7.Name = "label7";
      this.label7.Size = new Size(141, 24);
      this.label7.TabIndex = 53;
      this.label7.Text = "PLEDGE DATE";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkBlue;
      this.label10.Location = new Point(27, 117);
      this.label10.Name = "label10";
      this.label10.Size = new Size(159, 24);
      this.label10.TabIndex = 56;
      this.label10.Text = "INTEREST RATE";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(27, 154);
      this.label4.Name = "label4";
      this.label4.Size = new Size(159, 24);
      this.label4.TabIndex = 60;
      this.label4.Text = "NO OF MONTHS";
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(83, 191);
      this.label6.Name = "label6";
      this.label6.Size = new Size(103, 24);
      this.label6.TabIndex = 61;
      this.label6.Text = "INTEREST";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkBlue;
      this.label8.Location = new Point(20, 302);
      this.label8.Name = "label8";
      this.label8.Size = new Size(166, 24);
      this.label8.TabIndex = 62;
      this.label8.Text = "NOTICE CHARGE";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.DarkBlue;
      this.label9.Location = new Point(24, 339);
      this.label9.Name = "label9";
      this.label9.Size = new Size(162, 24);
      this.label9.TabIndex = 63;
      this.label9.Text = "OTHER CHARGE";
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.DarkBlue;
      this.label14.Location = new Point(66, 376);
      this.label14.Name = "label14";
      this.label14.Size = new Size(120, 24);
      this.label14.TabIndex = 64;
      this.label14.Text = "DEDUCTION";
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.DarkBlue;
      this.label15.Location = new Point(25, 413);
      this.label15.Name = "label15";
      this.label15.Size = new Size(161, 24);
      this.label15.TabIndex = 65;
      this.label15.Text = "FINAL INTEREST";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Transparent;
      this.label16.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.DarkBlue;
      this.label16.Location = new Point(114, 450);
      this.label16.Name = "label16";
      this.label16.Size = new Size(72, 24);
      this.label16.TabIndex = 66;
      this.label16.Text = "TOTAL";
      this.tbxRedemptionDate.BackColor = Color.AliceBlue;
      this.tbxRedemptionDate.BorderStyle = BorderStyle.None;
      this.tbxRedemptionDate.Dock = DockStyle.Bottom;
      this.tbxRedemptionDate.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionDate.ForeColor = Color.Black;
      this.tbxRedemptionDate.Location = new Point(0, 28);
      this.tbxRedemptionDate.MaxLength = 10;
      this.tbxRedemptionDate.Name = "tbxRedemptionDate";
      this.tbxRedemptionDate.Size = new Size(185, 40);
      this.tbxRedemptionDate.TabIndex = 1;
      this.tbxRedemptionDate.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionDate.TextChanged += new EventHandler(this.tbxRedemptionDate_TextChanged);
      this.tbxRedemptionDate.Enter += new EventHandler(this.tbxRedemptionDate_Enter);
      this.tbxRedemptionDate.KeyDown += new KeyEventHandler(this.tbxRedemptionDate_KeyDown);
      this.tbxRedemptionDate.Validating += new CancelEventHandler(this.tbxRedemptionDate_Validating);
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.Tomato;
      this.lblMessage.Location = new Point(7, 37);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(0, 16);
      this.lblMessage.TabIndex = 70;
      this.timer1.Interval = 500;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.timer2.Interval = 4000;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.tbxPaymentReceived.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPaymentReceived.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPaymentReceived.ForeColor = SystemColors.MenuHighlight;
      this.tbxPaymentReceived.Location = new Point(195, 222);
      this.tbxPaymentReceived.Name = "tbxPaymentReceived";
      this.tbxPaymentReceived.Size = new Size(167, 35);
      this.tbxPaymentReceived.TabIndex = 77;
      this.tbxPaymentReceived.Text = "0";
      this.tbxPaymentReceived.TextAlign = HorizontalAlignment.Right;
      this.tbxPaymentReceived.KeyDown += new KeyEventHandler(this.tbxPaymentReceived_KeyDown);
      this.tbxPaymentReceived.KeyPress += new KeyPressEventHandler(this.tbxPaymentReceived_KeyPress);
      this.tbxPaymentReceived.Validating += new CancelEventHandler(this.tbxPaymentReceived_Validating);
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Transparent;
      this.label17.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.DarkBlue;
      this.label17.Location = new Point(14, 228);
      this.label17.Name = "label17";
      this.label17.Size = new Size(172, 24);
      this.label17.TabIndex = 78;
      this.label17.Text = "PAYMENT RECVD";
      this.btnPaymentReceivedDetails.BackColor = Color.LightBlue;
      this.btnPaymentReceivedDetails.FadeOnFocus = true;
      this.btnPaymentReceivedDetails.ForeColor = Color.Black;
      this.btnPaymentReceivedDetails.ForeColorOnFocus = Color.Red;
      this.btnPaymentReceivedDetails.ForeColorOnLeave = Color.MediumBlue;
      this.btnPaymentReceivedDetails.GlowColor = Color.White;
      this.btnPaymentReceivedDetails.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPaymentReceivedDetails).Location = new Point(200, 228);
      ((Control) this.btnPaymentReceivedDetails).Name = "btnPaymentReceivedDetails";
      this.btnPaymentReceivedDetails.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPaymentReceivedDetails.ShineColor = Color.Transparent;
      ((Control) this.btnPaymentReceivedDetails).Size = new Size(52, 23);
      ((Control) this.btnPaymentReceivedDetails).TabIndex = 79;
      ((Control) this.btnPaymentReceivedDetails).Text = "&Details";
      ((Control) this.btnPaymentReceivedDetails).Click += new EventHandler(this.glassButton1_Click);
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.DarkBlue;
      this.label18.Location = new Point(31, 265);
      this.label18.Name = "label18";
      this.label18.Size = new Size(155, 24);
      this.label18.TabIndex = 81;
      this.label18.Text = "INTEREST LESS";
      this.tbxInterestLess.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestLess.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestLess.ForeColor = SystemColors.MenuHighlight;
      this.tbxInterestLess.Location = new Point(195, 259);
      this.tbxInterestLess.Name = "tbxInterestLess";
      this.tbxInterestLess.Size = new Size(167, 35);
      this.tbxInterestLess.TabIndex = 80;
      this.tbxInterestLess.Text = "0";
      this.tbxInterestLess.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestLess.KeyDown += new KeyEventHandler(this.tbxInterestLess_KeyDown);
      this.tbxInterestLess.KeyPress += new KeyPressEventHandler(this.tbxInterestLess_KeyPress);
      this.tbxInterestLess.Validating += new CancelEventHandler(this.tbxInterestLess_Validating);
      this.btnInterestLessDetails.BackColor = Color.LightBlue;
      this.btnInterestLessDetails.FadeOnFocus = true;
      this.btnInterestLessDetails.ForeColor = Color.Black;
      this.btnInterestLessDetails.ForeColorOnFocus = Color.Red;
      this.btnInterestLessDetails.ForeColorOnLeave = Color.MediumBlue;
      this.btnInterestLessDetails.GlowColor = Color.White;
      this.btnInterestLessDetails.InnerBorderColor = Color.Transparent;
      ((Control) this.btnInterestLessDetails).Location = new Point(201, 264);
      ((Control) this.btnInterestLessDetails).Name = "btnInterestLessDetails";
      this.btnInterestLessDetails.OuterBorderColor = Color.MediumSlateBlue;
      this.btnInterestLessDetails.ShineColor = Color.Transparent;
      ((Control) this.btnInterestLessDetails).Size = new Size(52, 22);
      ((Control) this.btnInterestLessDetails).TabIndex = 82;
      ((Control) this.btnInterestLessDetails).Text = "D&etails";
      ((Control) this.btnInterestLessDetails).Click += new EventHandler(this.glassButton2_Click);
      this.tbxReceive.BackColor = Color.Moccasin;
      this.tbxReceive.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReceive.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxReceive.ForeColor = Color.Firebrick;
      this.tbxReceive.Location = new Point(195, 481);
      this.tbxReceive.Name = "tbxReceive";
      this.tbxReceive.ReadOnly = true;
      this.tbxReceive.Size = new Size(167, 35);
      this.tbxReceive.TabIndex = 83;
      this.tbxReceive.TextAlign = HorizontalAlignment.Right;
      this.tbxReceive.KeyPress += new KeyPressEventHandler(this.tbxReceive_KeyPress);
      this.label19.AutoSize = true;
      this.label19.BackColor = Color.Transparent;
      this.label19.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.DarkBlue;
      this.label19.Location = new Point(98, 487);
      this.label19.Name = "label19";
      this.label19.Size = new Size(92, 24);
      this.label19.TabIndex = 84;
      this.label19.Text = "RECEIVE";
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Location = new Point(1, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(191, 70);
      this.panel2.TabIndex = 9;
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.DarkBlue;
      this.lblHeading.Location = new Point(7, 18);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(174, 29);
      this.lblHeading.TabIndex = 10;
      this.lblHeading.Text = "REDEMPTION";
      this.lblHeading.Click += new EventHandler(this.lblHeading_Click);
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.panel12);
      this.panel3.Controls.Add((Control) this.panel11);
      this.panel3.Controls.Add((Control) this.panel6);
      this.panel3.Controls.Add((Control) this.panel2);
      this.panel3.Controls.Add((Control) this.panel7);
      this.panel3.Controls.Add((Control) this.panel4);
      this.panel3.Controls.Add((Control) this.panel8);
      this.panel3.Controls.Add((Control) this.panel1);
      this.panel3.Controls.Add((Control) this.tbxInterest16);
      this.panel3.Controls.Add((Control) this.tbxNoOfMonths16);
      this.panel3.Controls.Add((Control) this.panel5);
      this.panel3.Controls.Add((Control) this.tbxRedemptionAmount16);
      this.panel3.Controls.Add((Control) this.panel10);
      this.panel3.Controls.Add((Control) this.panel9);
      this.panel3.Location = new Point(6, 10);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1015, 598);
      this.panel3.TabIndex = 11;
      this.panel12.BackColor = Color.AliceBlue;
      this.panel12.BorderStyle = BorderStyle.FixedSingle;
      this.panel12.Controls.Add((Control) this.listBox1);
      this.panel12.Controls.Add((Control) this.lblBankBillNumber);
      this.panel12.Controls.Add((Control) this.dgvArticles);
      this.panel12.Controls.Add((Control) this.tbxPureWeight);
      this.panel12.Controls.Add((Control) this.tbxNetWeight);
      this.panel12.Controls.Add((Control) this.tbxGrossWeight);
      this.panel12.Controls.Add((Control) this.tbxDeduction);
      this.panel12.Controls.Add((Control) this.textBox6);
      this.panel12.Controls.Add((Control) this.textBox3);
      this.panel12.Controls.Add((Control) this.textBox4);
      this.panel12.Controls.Add((Control) this.textBox5);
      this.panel12.Controls.Add((Control) this.panel13);
      this.panel12.Location = new Point(3, 281);
      this.panel12.Name = "panel12";
      this.panel12.Size = new Size(639, 312);
      this.panel12.TabIndex = 119;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(4, 36);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(120, 147);
      this.listBox1.TabIndex = 119;
      this.lblBankBillNumber.AutoSize = true;
      this.lblBankBillNumber.BackColor = Color.GhostWhite;
      this.lblBankBillNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblBankBillNumber.ForeColor = Color.MidnightBlue;
      this.lblBankBillNumber.Location = new Point(5, 206);
      this.lblBankBillNumber.Name = "lblBankBillNumber";
      this.lblBankBillNumber.Size = new Size(238, 25);
      this.lblBankBillNumber.TabIndex = 112;
      this.lblBankBillNumber.Text = "BANK BILL  NUMBER";
      this.lblBankBillNumber.Visible = false;
      this.dgvArticles.AllowUserToAddRows = false;
      this.dgvArticles.AllowUserToDeleteRows = false;
      this.dgvArticles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvArticles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgvArticles.BackgroundColor = Color.Honeydew;
      this.dgvArticles.BorderStyle = BorderStyle.None;
      this.dgvArticles.CellBorderStyle = DataGridViewCellBorderStyle.None;
      this.dgvArticles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.BackColor = Color.Azure;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.ControlLightLight;
      gridViewCellStyle.SelectionForeColor = SystemColors.Highlight;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dgvArticles.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dgvArticles.ColumnHeadersHeight = 25;
      this.dgvArticles.ContextMenuStrip = this.contextMenuStrip1;
      this.dgvArticles.EnableHeadersVisualStyles = false;
      this.dgvArticles.GridColor = SystemColors.ControlLight;
      this.dgvArticles.Location = new Point(1, 32);
      this.dgvArticles.Name = "dgvArticles";
      this.dgvArticles.ReadOnly = true;
      this.dgvArticles.RowHeadersVisible = false;
      this.dgvArticles.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dgvArticles.Size = new Size(637, 205);
      this.dgvArticles.TabIndex = 118;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deletePHotoToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(145, 26);
      this.deletePHotoToolStripMenuItem.Name = "deletePHotoToolStripMenuItem";
      this.deletePHotoToolStripMenuItem.Size = new Size(144, 22);
      this.deletePHotoToolStripMenuItem.Text = "Delete PHoto";
      this.deletePHotoToolStripMenuItem.Click += new EventHandler(this.deletePHotoToolStripMenuItem_Click);
      this.tbxPureWeight.BackColor = Color.Azure;
      this.tbxPureWeight.BorderStyle = BorderStyle.None;
      this.tbxPureWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxPureWeight.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPureWeight.ForeColor = Color.Black;
      this.tbxPureWeight.Location = new Point(450, 278);
      this.tbxPureWeight.MaxLength = 7;
      this.tbxPureWeight.Name = "tbxPureWeight";
      this.tbxPureWeight.ReadOnly = true;
      this.tbxPureWeight.Size = new Size(181, 31);
      this.tbxPureWeight.TabIndex = 69;
      this.tbxPureWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.BackColor = Color.Azure;
      this.tbxNetWeight.BorderStyle = BorderStyle.None;
      this.tbxNetWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxNetWeight.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.ForeColor = Color.Black;
      this.tbxNetWeight.Location = new Point(450, 242);
      this.tbxNetWeight.MaxLength = 7;
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.ReadOnly = true;
      this.tbxNetWeight.Size = new Size(181, 31);
      this.tbxNetWeight.TabIndex = 5;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxGrossWeight.BackColor = Color.Azure;
      this.tbxGrossWeight.BorderStyle = BorderStyle.None;
      this.tbxGrossWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxGrossWeight.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxGrossWeight.ForeColor = Color.Black;
      this.tbxGrossWeight.Location = new Point(142, 243);
      this.tbxGrossWeight.MaxLength = 7;
      this.tbxGrossWeight.Name = "tbxGrossWeight";
      this.tbxGrossWeight.ReadOnly = true;
      this.tbxGrossWeight.Size = new Size(197, 31);
      this.tbxGrossWeight.TabIndex = 3;
      this.tbxGrossWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxDeduction.BackColor = Color.Azure;
      this.tbxDeduction.BorderStyle = BorderStyle.None;
      this.tbxDeduction.CharacterCasing = CharacterCasing.Upper;
      this.tbxDeduction.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeduction.ForeColor = Color.Black;
      this.tbxDeduction.Location = new Point(142, 273);
      this.tbxDeduction.MaxLength = 5;
      this.tbxDeduction.Name = "tbxDeduction";
      this.tbxDeduction.ReadOnly = true;
      this.tbxDeduction.Size = new Size(197, 31);
      this.tbxDeduction.TabIndex = 4;
      this.tbxDeduction.Text = "0";
      this.tbxDeduction.TextAlign = HorizontalAlignment.Right;
      this.textBox6.BackColor = Color.AliceBlue;
      this.textBox6.BorderStyle = BorderStyle.None;
      this.textBox6.CharacterCasing = CharacterCasing.Upper;
      this.textBox6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox6.ForeColor = Color.DarkBlue;
      this.textBox6.Location = new Point(4, 248);
      this.textBox6.MaxLength = 7;
      this.textBox6.Name = "textBox6";
      this.textBox6.ReadOnly = true;
      this.textBox6.Size = new Size(140, 22);
      this.textBox6.TabIndex = 114;
      this.textBox6.Text = "G WT :";
      this.textBox6.TextAlign = HorizontalAlignment.Right;
      this.textBox3.BackColor = Color.AliceBlue;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.CharacterCasing = CharacterCasing.Upper;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.ForeColor = Color.DarkBlue;
      this.textBox3.Location = new Point(284, 283);
      this.textBox3.MaxLength = 7;
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(165, 22);
      this.textBox3.TabIndex = 117;
      this.textBox3.Text = "PURE WT :";
      this.textBox3.TextAlign = HorizontalAlignment.Right;
      this.textBox4.BackColor = Color.AliceBlue;
      this.textBox4.BorderStyle = BorderStyle.None;
      this.textBox4.CharacterCasing = CharacterCasing.Upper;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox4.ForeColor = Color.DarkBlue;
      this.textBox4.Location = new Point(9, 278);
      this.textBox4.MaxLength = 5;
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      this.textBox4.Size = new Size(135, 22);
      this.textBox4.TabIndex = 115;
      this.textBox4.Text = "DEDN :";
      this.textBox4.TextAlign = HorizontalAlignment.Right;
      this.textBox5.BackColor = Color.AliceBlue;
      this.textBox5.BorderStyle = BorderStyle.None;
      this.textBox5.CharacterCasing = CharacterCasing.Upper;
      this.textBox5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox5.ForeColor = Color.DarkBlue;
      this.textBox5.Location = new Point(288, 247);
      this.textBox5.MaxLength = 7;
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(161, 22);
      this.textBox5.TabIndex = 116;
      this.textBox5.Text = "NET WT :";
      this.textBox5.TextAlign = HorizontalAlignment.Right;
      this.panel13.BackColor = Color.PowderBlue;
      this.panel13.Controls.Add((Control) this.label1);
      this.panel13.Dock = DockStyle.Top;
      this.panel13.Location = new Point(0, 0);
      this.panel13.Name = "panel13";
      this.panel13.Size = new Size(637, 30);
      this.panel13.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(7, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(289, 16);
      this.label1.TabIndex = 2;
      this.label1.Text = "DETAILED DESCRIPTION OF ARTICLES";
      this.panel11.BackColor = Color.AliceBlue;
      this.panel11.BorderStyle = BorderStyle.FixedSingle;
      this.panel11.Controls.Add((Control) this.pictureBox2);
      this.panel11.Controls.Add((Control) this.tbxReleasedBy);
      this.panel11.Location = new Point(419, 100);
      this.panel11.Name = "panel11";
      this.panel11.Size = new Size(222, 180);
      this.panel11.TabIndex = 118;
      this.pictureBox2.BackColor = Color.AliceBlue;
      this.pictureBox2.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox2.Dock = DockStyle.Top;
      this.pictureBox2.Location = new Point(0, 0);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(220, 153);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 86;
      this.pictureBox2.TabStop = false;
      this.tbxReleasedBy.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReleasedBy.Dock = DockStyle.Bottom;
      this.tbxReleasedBy.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxReleasedBy.ForeColor = SystemColors.MenuHighlight;
      this.tbxReleasedBy.Location = new Point(0, 154);
      this.tbxReleasedBy.MaxLength = 200;
      this.tbxReleasedBy.Name = "tbxReleasedBy";
      this.tbxReleasedBy.Size = new Size(220, 24);
      this.tbxReleasedBy.TabIndex = 88;
      this.tbxReleasedBy.KeyDown += new KeyEventHandler(this.tbxReleasedBy_KeyDown);
      this.tbxReleasedBy.Validating += new CancelEventHandler(this.tbxReleasedBy_Validating);
      this.panel6.BackColor = Color.PowderBlue;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.label24);
      this.panel6.Location = new Point(1, 73);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(415, 27);
      this.panel6.TabIndex = 117;
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label24.ForeColor = Color.DarkBlue;
      this.label24.Location = new Point(3, 5);
      this.label24.Name = "label24";
      this.label24.Size = new Size(103, 16);
      this.label24.TabIndex = 1;
      this.label24.Text = "PLEDGED BY";
      this.panel7.BackColor = Color.PowderBlue;
      this.panel7.BorderStyle = BorderStyle.FixedSingle;
      this.panel7.Controls.Add((Control) this.tbxRedemptionBillNumber);
      this.panel7.Controls.Add((Control) this.label2);
      this.panel7.Location = new Point(193, 1);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(220, 70);
      this.panel7.TabIndex = 26;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new Size(211, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "REDEMPTION BILL NUMBER";
      this.panel4.BackColor = Color.PowderBlue;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.label20);
      this.panel4.Controls.Add((Control) this.btnReleasedBy);
      this.panel4.Location = new Point(419, 73);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(222, 29);
      this.panel4.TabIndex = 116;
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.DarkBlue;
      this.label20.Location = new Point(3, 5);
      this.label20.Name = "label20";
      this.label20.Size = new Size(112, 16);
      this.label20.TabIndex = 1;
      this.label20.Text = "RELEASED BY";
      this.btnReleasedBy.BackColor = Color.LightBlue;
      this.btnReleasedBy.FadeOnFocus = true;
      this.btnReleasedBy.ForeColor = Color.MediumBlue;
      this.btnReleasedBy.ForeColorOnFocus = Color.Red;
      this.btnReleasedBy.ForeColorOnLeave = Color.MediumBlue;
      this.btnReleasedBy.GlowColor = Color.White;
      this.btnReleasedBy.InnerBorderColor = Color.Transparent;
      ((Control) this.btnReleasedBy).Location = new Point(140, 2);
      ((Control) this.btnReleasedBy).Name = "btnReleasedBy";
      this.btnReleasedBy.OuterBorderColor = Color.MediumSlateBlue;
      this.btnReleasedBy.ShineColor = Color.Transparent;
      ((Control) this.btnReleasedBy).Size = new Size(75, 23);
      ((Control) this.btnReleasedBy).TabIndex = 87;
      ((Control) this.btnReleasedBy).Text = "&Take photo";
      ((Control) this.btnReleasedBy).Click += new EventHandler(this.glassButton19_Click);
      this.panel8.BackColor = Color.PowderBlue;
      this.panel8.BorderStyle = BorderStyle.FixedSingle;
      this.panel8.Controls.Add((Control) this.tbxRedemptionDate);
      this.panel8.Controls.Add((Control) this.label3);
      this.panel8.Location = new Point(415, 0);
      this.panel8.Name = "panel8";
      this.panel8.Size = new Size(187, 70);
      this.panel8.TabIndex = 27;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(3, 5);
      this.label3.Name = "label3";
      this.label3.Size = new Size(153, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "REDEMPTION DATE";
      this.panel1.BackColor = Color.AliceBlue;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.tbxCustomerCode);
      this.panel1.Controls.Add((Control) this.lblReminder);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.label22);
      this.panel1.Controls.Add((Control) this.label23);
      this.panel1.Controls.Add((Control) this.tbxAddress1);
      this.panel1.Controls.Add((Control) this.tbxCustomerName);
      this.panel1.Location = new Point(2, 99);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(414, 180);
      this.panel1.TabIndex = 115;
      this.tbxCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerCode.BackColor = Color.AliceBlue;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(158, 23);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(65, 15);
      this.tbxCustomerCode.TabIndex = 113;
      this.lblReminder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblReminder.BackColor = Color.AliceBlue;
      this.lblReminder.BorderStyle = BorderStyle.None;
      this.lblReminder.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblReminder.ForeColor = Color.Maroon;
      this.lblReminder.Location = new Point(158, 116);
      this.lblReminder.Name = "lblReminder";
      this.lblReminder.Size = new Size(235, 59);
      this.lblReminder.TabIndex = 112;
      this.lblReminder.Text = "";
      this.pictureBox1.Location = new Point(2, 2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(143, 173);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.label22.AutoSize = true;
      this.label22.BackColor = Color.Transparent;
      this.label22.ForeColor = Color.DarkBlue;
      this.label22.Location = new Point(155, 41);
      this.label22.Name = "label22";
      this.label22.Size = new Size(59, 13);
      this.label22.TabIndex = 33;
      this.label22.Text = "ADDRESS";
      this.label23.AutoSize = true;
      this.label23.BackColor = Color.Transparent;
      this.label23.ForeColor = Color.DarkBlue;
      this.label23.Location = new Point(155, 7);
      this.label23.Name = "label23";
      this.label23.Size = new Size(102, 13);
      this.label23.TabIndex = 31;
      this.label23.Text = "CUSTOMER NAME";
      this.tbxAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddress1.BackColor = Color.AliceBlue;
      this.tbxAddress1.BorderStyle = BorderStyle.None;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.Location = new Point(155, 58);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(237, 59);
      this.tbxAddress1.TabIndex = 32;
      this.tbxAddress1.Text = "";
      this.tbxCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerName.BackColor = Color.AliceBlue;
      this.tbxCustomerName.BorderStyle = BorderStyle.None;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(238, 24);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(161, 15);
      this.tbxCustomerName.TabIndex = 0;
      this.tbxInterest16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest16.ForeColor = Color.Red;
      this.tbxInterest16.Location = new Point(581, 547);
      this.tbxInterest16.Name = "tbxInterest16";
      this.tbxInterest16.ReadOnly = true;
      this.tbxInterest16.Size = new Size(26, 31);
      this.tbxInterest16.TabIndex = 109;
      this.tbxInterest16.Visible = false;
      this.tbxNoOfMonths16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfMonths16.ForeColor = Color.Red;
      this.tbxNoOfMonths16.Location = new Point(577, 548);
      this.tbxNoOfMonths16.Name = "tbxNoOfMonths16";
      this.tbxNoOfMonths16.ReadOnly = true;
      this.tbxNoOfMonths16.Size = new Size(30, 31);
      this.tbxNoOfMonths16.TabIndex = 113;
      this.tbxNoOfMonths16.Visible = false;
      this.panel5.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.lblMessage);
      this.panel5.Controls.Add((Control) this.panel14);
      this.panel5.Controls.Add((Control) this.btnInterestLessDetails);
      this.panel5.Controls.Add((Control) this.label18);
      this.panel5.Controls.Add((Control) this.btnPaymentReceivedDetails);
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
      this.panel5.Location = new Point(643, 73);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(367, 520);
      this.panel5.TabIndex = 88;
      this.panel14.BackColor = Color.PowderBlue;
      this.panel14.Controls.Add((Control) this.label13);
      this.panel14.Dock = DockStyle.Top;
      this.panel14.Location = new Point(0, 0);
      this.panel14.Name = "panel14";
      this.panel14.Size = new Size(365, 25);
      this.panel14.TabIndex = 113;
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.DarkBlue;
      this.label13.Location = new Point(4, 4);
      this.label13.Name = "label13";
      this.label13.Size = new Size(191, 16);
      this.label13.TabIndex = 2;
      this.label13.Text = "INTEREST CALCULATION";
      this.tbxRedemptionAmount16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionAmount16.ForeColor = Color.Red;
      this.tbxRedemptionAmount16.Location = new Point(588, 547);
      this.tbxRedemptionAmount16.Name = "tbxRedemptionAmount16";
      this.tbxRedemptionAmount16.ReadOnly = true;
      this.tbxRedemptionAmount16.Size = new Size(26, 31);
      this.tbxRedemptionAmount16.TabIndex = 110;
      this.tbxRedemptionAmount16.Visible = false;
      this.panel10.BackColor = Color.PowderBlue;
      this.panel10.BorderStyle = BorderStyle.FixedSingle;
      this.panel10.Controls.Add((Control) this.cbShopCodes);
      this.panel10.Controls.Add((Control) this.label12);
      this.panel10.Location = new Point(809, 2);
      this.panel10.Name = "panel10";
      this.panel10.Size = new Size(201, 70);
      this.panel10.TabIndex = 27;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Bottom;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 27);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(199, 41);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.Enter += new EventHandler(this.cbShopCodes_Enter);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.DarkBlue;
      this.label12.Location = new Point(3, 5);
      this.label12.Name = "label12";
      this.label12.Size = new Size(133, 16);
      this.label12.TabIndex = 1;
      this.label12.Text = "SELECT LICENSE";
      this.panel9.BackColor = Color.PowderBlue;
      this.panel9.BorderStyle = BorderStyle.FixedSingle;
      this.panel9.Controls.Add((Control) this.tbxPledgeBillNumber);
      this.panel9.Controls.Add((Control) this.label11);
      this.panel9.Location = new Point(604, 1);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(204, 70);
      this.panel9.TabIndex = 81;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkBlue;
      this.label11.Location = new Point(3, 5);
      this.label11.Name = "label11";
      this.label11.Size = new Size(171, 16);
      this.label11.TabIndex = 1;
      this.label11.Text = "PLEDGE BILL NUMBER";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Azure;
      this.ClientSize = new Size(1025, 640);
      this.Controls.Add((Control) this.panel3);
      this.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.ForeColor = Color.Black;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormRedemption);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Redemption";
      this.Activated += new EventHandler(this.FormRedemption_Activated);
      this.Load += new EventHandler(this.Redemption_Load);
      this.MouseEnter += new EventHandler(this.FormRedemption_MouseEnter);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel12.ResumeLayout(false);
      this.panel12.PerformLayout();
      ((ISupportInitialize) this.dgvArticles).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel13.ResumeLayout(false);
      this.panel13.PerformLayout();
      this.panel11.ResumeLayout(false);
      this.panel11.PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel14.ResumeLayout(false);
      this.panel14.PerformLayout();
      this.panel10.ResumeLayout(false);
      this.panel10.PerformLayout();
      this.panel9.ResumeLayout(false);
      this.panel9.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
