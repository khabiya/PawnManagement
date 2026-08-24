
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPartPayment : Form
  {
    private string InitialBillNumber = "";
    private string InitialShopCode = "";
    private string serialNumber = "";
    private string formType = "";
    private List<string> lstAddress = new List<string>();
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
    private DataGridView dataGridView1;
    private Label label2;
    private TextBox tbxBillNumber;
    private TextBox tbxAmount;
    private GlassButton btnReceivePayment;
    private Label label3;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private TextBox tbxAmountReceivable;
    private TextBox tbxPaymentsAlreadyReceived;
    private TextBox tbxInterestPlusPrincipal;
    private TextBox tbxInterest;
    private TextBox tbxPrincipal;
    private Label label7;
    private Label label9;
    private Label label8;
    private Label label6;
    private Label label5;
    private ToolStripMenuItem deletePaymentToolStripMenuItem;
    private Label label10;
    private TextBox tbxSerialNumber;
    private Label lblReceivedOnDate;
    private TextBox tbxReceivedDate;
    private ComboBox cbShopCodes;
    private Label label11;
    private DataGridView dataGridView2;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel hpRedemptionDate;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormPartPayment(string paymentType)
    {
      this.formType = paymentType;
      this.InitializeComponent();
    }

    public FormPartPayment(string paymentType, string BILLNUMBER, string SHOPCODE)
    {
      this.InitialBillNumber = BILLNUMBER;
      this.InitialShopCode = SHOPCODE;
      this.formType = paymentType;
      this.InitializeComponent();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
          {
            this.getBillNumberDetails();
            break;
          }
          (sender as TextBox).Select();
          (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
          break;
        case "DOUBLE":
          if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
          {
            this.getBillNumberDetails();
          }
          else
          {
            (sender as TextBox).Select();
            (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
          }
          break;
      }
    }

    private void getBillNumberDetails()
    {
      DataTable dataTable = this.checkIfPledgeReleasedOrNot(this.tbxBillNumber.Text);
      this.dataGridView2.DataSource = (object) dataTable;
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        if (dataTable.Rows[0]["Redeemed"].Equals((object) "A"))
        {
          int num = (int) MessageBox.Show("Bill Number Already Auctioned");
          this.tbxBillNumber.Select();
        }
        else if (dataTable.Rows[0]["Redeemed"].Equals((object) "Y"))
        {
          int num = (int) MessageBox.Show("Bill Number Already Released");
          this.tbxBillNumber.Select();
        }
        else
        {
          if (!dataTable.Rows[0]["Redeemed"].Equals((object) "N"))
            return;
          DataTable detailsForBillNumber = this.getPaymentDetailsForBillNumber(this.tbxBillNumber.Text);
          DateTime d1 = DateTime.Parse(dataTable.Rows[0]["BillDate"].ToString());
          string s = dataTable.Rows[0]["Amount"].ToString();
          this.tbxPrincipal.Text = s;
          double num1 = double.Parse(dataTable.Rows[0]["temp1"].ToString());
          try
          {
            int num2 = PawnManagementClass.getNumberOfMonths(d1, DateTime.Now) - 1;
            double num3;
            if (num2 > 11)
            {
              TextBox tbxInterest = this.tbxInterest;
              num3 = (double) (int.Parse(s) * num2) * num1 / 1200.0;
              string str1 = num3.ToString();
              tbxInterest.Text = str1;
              TextBox interestPlusPrincipal = this.tbxInterestPlusPrincipal;
              num3 = double.Parse(this.tbxPrincipal.Text) + double.Parse(this.tbxInterest.Text);
              string str2 = num3.ToString();
              interestPlusPrincipal.Text = str2;
            }
            else
            {
              TextBox tbxInterest = this.tbxInterest;
              num3 = (double) (int.Parse(s) * num2) * num1 / 1200.0;
              string str3 = num3.ToString();
              tbxInterest.Text = str3;
              TextBox interestPlusPrincipal = this.tbxInterestPlusPrincipal;
              num3 = double.Parse(this.tbxPrincipal.Text) + double.Parse(this.tbxInterest.Text);
              string str4 = num3.ToString();
              interestPlusPrincipal.Text = str4;
            }
            TextBox paymentsAlreadyReceived = this.tbxPaymentsAlreadyReceived;
            num3 = this.getPaymentSum(this.tbxBillNumber.Text);
            string str5 = num3.ToString();
            paymentsAlreadyReceived.Text = str5;
            TextBox amountReceivable = this.tbxAmountReceivable;
            num3 = double.Parse(this.tbxInterestPlusPrincipal.Text) - double.Parse(this.tbxPaymentsAlreadyReceived.Text);
            string str6 = num3.ToString();
            amountReceivable.Text = str6;
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form partpayment.textbox1_validating ", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
          this.dataGridView1.DataSource = (object) detailsForBillNumber;
          this.tbxAmount.Select();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Bill Number does not exist");
        this.tbxBillNumber.SelectionStart = 2;
        this.tbxBillNumber.SelectionLength = 4;
        this.tbxBillNumber.Select();
      }
    }

    private void addIntoVoucherMaster(
      string voucherCode,
      string voucherName,
      string LedgerCode,
      string LedgerType)
    {
      try
      {
        string strError = "";
        if (!(SQLHelper.RunCommand("insert into tblVoucherMaster(VoucherCode,VoucherName,LedgerCode,LedgerType,CreatedOn,CreatedBy) values(@VoucherCode,@VoucherName,@LedgerCode,@LedgerType,@CreatedOn,@CreatedBy)", new List<OleDbParameter>()
        {
          new OleDbParameter("Vouchercode", (object) voucherCode),
          new OleDbParameter("VoucherName", (object) voucherName),
          new OleDbParameter(nameof (LedgerCode), (object) LedgerCode),
          new OleDbParameter(nameof (LedgerType), (object) LedgerType),
          new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString()),
          new OleDbParameter("CreatedBy", (object) FormMain.username)
        }, ref strError) != "Done"))
          return;
        PawnManagementClass.InsertIntoException("form voucherMaster.addVoucherMaster()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankmaster.addcouvhermaster", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private double getPaymentSum(string BillNumber)
    {
      string strError = "";
      string my_querry = "Select sum(amount) as AmountReceived from tblInterestReceived where BillNumber  = @BillNumber  and ShopCode = @ShopCode and active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpayment.getPaymentSum", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form form partpayment.getPaymentSum" + strError);
        return 0.0;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["AmountReceived"] != null && FormPartPayment.IsDigitsOnly(dataTable2.Rows[0]["AmountReceived"].ToString()) ? double.Parse(dataTable2.Rows[0]["AmountReceived"].ToString()) : 0.0;
    }

    public static bool IsDigitsOnly(string str)
    {
      if (str.Length == 0)
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private DataTable checkIfPledgeReleasedOrNot(string BillNumber)
    {
      string strError = "";
      string my_querry = "Select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form partpapyment.checkifpledgereleasedornot", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in retrieving data form partpapyment.checkifpledgereleasedornot" + strError);
      return dataTable2;
    }

    private DataTable getPaymentDetailsForBillNumber(string BillNumber)
    {
      string strError = "";
      string my_querry = "Select ShopCode,SerialNumber,BillNumber,BillDate,Amount,PaymentType from tblInterestReceived where BillNumber = @BillNumber and ShopCode = @ShopCode and active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (!(strError != ""))
        return dataTable2;
      PawnManagementClass.InsertIntoException("form partpapyment.getpaymentdetailsforbillNumber", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in retrieving data form partpapyment.getpaymentdetailsforbillNumber" + strError);
      return dataTable2;
    }

    private void btnAddArticles_Click(object sender, EventArgs e)
    {
      if (this.formType == "New")
      {
        if (this.tbxAmount.Text != "")
        {
          this.insertIntoTableInterestReceived();
          this.tbxAmount.Text = "";
          this.cbShopCodes.Select();
        }
        else
          this.tbxAmount.Select();
      }
      else if (this.tbxAmount.Text != "")
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxReceivedDate.Text))
        {
          if (this.checkIfDateIsNotBeforePledgeDateAndNotOutsideTodayDate(this.tbxBillNumber.Text, this.cbShopCodes.Text, this.tbxReceivedDate.Text))
          {
            this.insertIntoTableInterestReceived();
            this.tbxAmount.Text = "";
            this.cbShopCodes.Select();
          }
          else
            this.tbxReceivedDate.Select();
        }
        else
          this.tbxReceivedDate.Select();
      }
      else
        this.tbxAmount.Select();
    }

    private bool checkIfDateIsNotBeforePledgeDateAndNotOutsideTodayDate(
      string BillNumber,
      string ShopCode,
      string Date1)
    {
      string strError = "";
      string my_querry = "Select * from tblPledge where BillNumber = @BillNumber and ShopCode = @ShopCode ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpapyment.bool checkIfDateIsNotBeforePledgeDateAndNotOutsideTodayDate(string BillNumber)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form partpapyment.bool checkIfDateIsNotBeforePledgeDateAndNotOutsideTodayDate(string BillNumber)" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && (!(DateTime.Parse(Date1) >= DateTime.Parse(dataTable2.Rows[0]["BillDate"].ToString())) || !(DateTime.Parse(Date1) <= DateTime.Today)))
        return false;
      return true;
    }

    private string getMaxOfSerialNumber()
    {
      try
      {
        string strError = "";
        string my_querry = "Select max(serialnumber) AS SERIALNUMBER from tblInterestReceived";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("FormPartPayment.getMaxOfSerialNumber()" + strError);
          PawnManagementClass.InsertIntoException("FormPartPayment.getMaxOfSerialNumber()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["SerialNumber"] != null && dataTable2.Rows[0]["serialNumber"].ToString() != "")
          return dataTable2.Rows[0]["SerialNumber"].ToString();
        return "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form partpayment.getMaxOfSerialNumber()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void insertIntoTableInterestReceived()
    {
      string strError = "";
      string my_querry = "insert into tblInterestReceived(ShopCode,SerialNumber,BillNumber,Amount,PaymentType,BillDate,CreatedOn,CreatedBy,Active) values(@ShopCode,@SerialNumber,@BillNumber,@Amount,@PaymentType,@BillDate,@CreatedOn,@CreatedBy,@Active)";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("SerialNumber", (object) this.tbxSerialNumber.Text));
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text));
      parameters.Add(new OleDbParameter("Amount", (object) this.tbxAmount.Text));
      parameters.Add(new OleDbParameter("PaymentType", (object) "PARTPAYMENT"));
      DateTime now;
      if (this.formType == "New")
      {
        List<OleDbParameter> oleDbParameterList = parameters;
        now = DateTime.Now;
        OleDbParameter oleDbParameter = new OleDbParameter("BillDate", (object) now.ToString("dd/MM/yyyy"));
        oleDbParameterList.Add(oleDbParameter);
      }
      else if (this.formType == "Old")
      {
        List<OleDbParameter> oleDbParameterList = parameters;
        now = DateTime.Parse(this.tbxReceivedDate.Text);
        OleDbParameter oleDbParameter = new OleDbParameter("BillDate", (object) now.ToString("dd/MM/yyyy"));
        oleDbParameterList.Add(oleDbParameter);
      }
      List<OleDbParameter> oleDbParameterList1 = parameters;
      now = DateTime.Now;
      OleDbParameter oleDbParameter1 = new OleDbParameter("CreatedOn", (object) now.ToShortDateString());
      oleDbParameterList1.Add(oleDbParameter1);
      parameters.Add(new OleDbParameter("CreatedBy", (object) FormMain.username));
      parameters.Add(new OleDbParameter("Active", (object) "1"));
      if (SQLHelper.RunCommand(my_querry, parameters, ref strError) != "Done")
      {
        int num = (int) MessageBox.Show("form partpayment.insertIntoTableInterestReceived" + strError);
        string MessageAnDStackTrace = strError;
        string username = FormMain.username;
        now = DateTime.Now;
        string CreatedOn = now.ToString();
        PawnManagementClass.InsertIntoException("form partpayment.insertIntoTableInterestReceived", MessageAnDStackTrace, username, CreatedOn);
      }
      else if (PawnManagementClass.getRokadAutoEntrySettings())
      {
        this.dataGridView1.DataSource = (object) this.getPaymentDetailsForBillNumber(this.tbxBillNumber.Text);
        string voucherCode1 = this.getVoucherCode(this.tbxBillNumber.Text + "(" + this.cbShopCodes.Text + ")");
        if (voucherCode1 == "")
        {
          string voucherCode2 = this.createVoucherCode(this.tbxBillNumber.Text + "(" + this.cbShopCodes.Text + ")");
          if (voucherCode2 != "")
          {
            this.addIntoVoucherMaster(voucherCode2, this.tbxBillNumber.Text + "(" + this.cbShopCodes.Text + ")", "U1", "UDHRATH");
            if (this.formType == "New")
            {
              PawnManagementClass.insertIntotblVouchers(DateTime.Parse(PawnManagementClass.getRokadDate()), (double.Parse(VoucherClass.getMaxOfVoucherNumber()) + 1.0).ToString(), voucherCode2, this.tbxBillNumber.Text + "(" + this.cbShopCodes.Text + ")", this.tbxSerialNumber.Text + "," + this.tbxBillNumber.Text, "U1", "JAMMA", double.Parse(this.tbxAmount.Text));
              int num = (int) MessageBox.Show("Successlly received Payment");
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show("Close this form and try again");
          }
        }
        else if (voucherCode1 != "")
        {
          if (this.formType == "New")
          {
            PawnManagementClass.insertIntotblVouchers(DateTime.Parse(PawnManagementClass.getRokadDate()), (double.Parse(VoucherClass.getMaxOfVoucherNumber()) + 1.0).ToString(), voucherCode1, this.tbxBillNumber.Text + "(" + this.cbShopCodes.Text + ")", this.tbxSerialNumber.Text + "," + this.tbxBillNumber.Text, "U1", "JAMMA", double.Parse(this.tbxAmount.Text));
            int num = (int) MessageBox.Show("Successlly received Payment");
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Close this form and try again");
        }
        string maxOfSerialNumber = this.getMaxOfSerialNumber();
        this.tbxSerialNumber.Text = maxOfSerialNumber == "" ? "1" : (int.Parse(maxOfSerialNumber) + 1).ToString();
      }
    }

    private string createVoucherCode(string BillNumber)
    {
      char ch = BillNumber[0];
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblVoucherMaster where VoucherCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form voucherMaster.tbxvouchername_validating", strError, FormMain.username, DateTime.Now.ToString());
      if (dataTable != null)
      {
        if (dataTable.Rows.Count <= 0)
          return ch.ToString() + "1";
        return ch.ToString() + this.NextCustomerCode(dataTable);
      }
      int num = (int) MessageBox.Show("Error while setting voucherCode Restart - " + strError);
      return "";
    }

    private string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["VOUCHERCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
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

    private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void getBillNumbers()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblPledge where redeemed = 'N' and ShopCode = @ShopCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form partpayment .getBillNumbers()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstAddress.Add(row["billnumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form partpayment.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void Form4_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxBillNumber.MaxLength = 7;
      this.getShopCodes();
      this.cbShopCodes.Select();
      if (this.InitialShopCode != "")
        this.cbShopCodes.Text = this.InitialShopCode;
      else
        this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
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

    private void tbxBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxAmount.Select();
    }

    private void tbxAmount_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.formType == "New")
        ((Control) this.btnReceivePayment).Focus();
      else if (this.formType == "Old")
        this.tbxReceivedDate.Select();
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.Close();

    private void tbxAmount_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxAmount.Text == "")
        this.tbxAmount.Select();
      else if (!PawnManagementClass.IsDigitsOnly(this.tbxAmount.Text))
        this.tbxAmount.Select();
      if (this.tbxAmount.Text != "" && this.tbxAmountReceivable.Text != "" && double.Parse(this.tbxAmount.Text) > double.Parse(this.tbxAmountReceivable.Text))
      {
        int num = (int) MessageBox.Show("Amount is greater than the amount receivable...Please check again");
        this.tbxAmount.ForeColor = Color.Red;
      }
      else
        this.tbxAmount.ForeColor = Color.Black;
    }

    private void tbxBillNumber_Enter(object sender, EventArgs e)
    {
      this.tbxAmount.Text = "";
      if (!(this.InitialBillNumber != ""))
        return;
      this.tbxBillNumber.Text = this.InitialBillNumber;
    }

    private void tbxAmount_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxAmount.Text != "") || !(this.tbxAmountReceivable.Text != ""))
        return;
      if (double.Parse(this.tbxAmount.Text) > double.Parse(this.tbxAmountReceivable.Text))
        this.tbxAmount.ForeColor = Color.Red;
      else
        this.tbxAmount.ForeColor = Color.Black;
    }

    private void tbxPrincipal_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private DataTable getVoucherNumberAndDate(string VoucherDescription)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherDescription=@VoucherDescription AND active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (VoucherDescription), (object) VoucherDescription));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpayment.getVoucherName(string voucherdescription)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form partpayment.getVoucherName(string voucherdescription)" + strError);
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

    private void deletePaymentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count > 0)
      {
        if (this.dataGridView1.CurrentCell.RowIndex > -1)
        {
          if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillDate"].Value.ToString()).ToShortDateString()))
          {
            string strError1 = "";
            if (SQLHelper.RunCommand("update tblInterestReceived set Active = @Active where serialNumber = @serialNumber", new List<OleDbParameter>()
            {
              new OleDbParameter("Active", (object) "0"),
              new OleDbParameter("serialNumber", (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["serialNumber"].Value.ToString())
            }, ref strError1) == "Done")
            {
              int num1 = (int) MessageBox.Show("successfully deleted");
            }
            DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["serialNumber"].Value.ToString() + "," + this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString());
            if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
            {
              string str1 = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
              string str2 = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
              string strError2 = "";
              if (!(SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
              {
                new OleDbParameter("Active", (object) "0"),
                new OleDbParameter("VoucherNumber", (object) str1)
              }, ref strError2) == "Done"))
                return;
              PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", "VOUCHER NUMBER " + str1 + " Date " + str2 + " deleted", "", "", FormMain.username, DateTime.Now.ToString());
              int num2 = (int) MessageBox.Show("successfully deleted FROM ROKAD");
              this.tbxAmount.Text = "0";
              this.tbxBillNumber.Select();
              this.tbxAmount.Text = "";
              this.dataGridView1.DataSource = (object) this.getPaymentDetailsForBillNumber(this.tbxBillNumber.Text);
            }
            else
            {
              int num3 = (int) MessageBox.Show("No Entry in rokad...");
            }
          }
          else
          {
            int num4 = (int) MessageBox.Show("Rokad finished .. Cannot undo payment");
          }
        }
        else
        {
          int num5 = (int) MessageBox.Show("No row Selected. Please select a row");
        }
      }
      else
      {
        int num6 = (int) MessageBox.Show("Table is empty");
      }
    }

    private void tbxReceivedDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxReceivedDate.Text))
        return;
      this.tbxReceivedDate.Select();
    }

    private void tbxReceivedDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnReceivePayment).Focus();
    }

    private void tbxReceivedDate_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxReceivedDate.Text != "") || !PawnManagementClass.checkForValidateDate(this.tbxReceivedDate.Text))
        return;
      if (this.checkIfDateIsNotBeforePledgeDateAndNotOutsideTodayDate(this.tbxBillNumber.Text, this.cbShopCodes.Text, this.tbxReceivedDate.Text))
        this.tbxReceivedDate.ForeColor = Color.Black;
      else
        this.tbxReceivedDate.ForeColor = Color.Red;
    }

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
      {
        if (this.formType == "New")
        {
          PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
          PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView2);
          this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
          this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
          this.tbxBillNumber.Select();
          string maxOfSerialNumber = this.getMaxOfSerialNumber();
          this.tbxSerialNumber.Text = maxOfSerialNumber == "" ? "1" : (int.Parse(maxOfSerialNumber) + 1).ToString();
          this.lblReceivedOnDate.Visible = false;
          this.tbxReceivedDate.Visible = false;
        }
        else if (this.formType == "Old")
        {
          PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
          PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView2);
          this.tbxBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
          this.tbxBillNumber.SelectionStart = this.tbxBillNumber.Text.Length;
          this.tbxBillNumber.Select();
          string maxOfSerialNumber = this.getMaxOfSerialNumber();
          this.tbxSerialNumber.Text = maxOfSerialNumber == "" ? "1" : (int.Parse(maxOfSerialNumber) + 1).ToString();
        }
        this.getBillNumbers();
        this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxBillNumber.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
      }
      else
        this.cbShopCodes.Select();
    }

    private void cbShopCodes_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillNumber.Select();
    }

    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView2.Rows.Count <= 0 || !(this.dataGridView2.CurrentCell.OwningColumn.HeaderText == "CustomerCode"))
        return;
      string CUSTOMERCODE = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormPartPayment));
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.deletePaymentToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.dataGridView2 = new DataGridView();
      this.hpRedemptionDate = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxSerialNumber = new TextBox();
      this.label11 = new Label();
      this.tbxBillNumber = new TextBox();
      this.cbShopCodes = new ComboBox();
      this.label2 = new Label();
      this.lblReceivedOnDate = new Label();
      this.btnReceivePayment = new GlassButton();
      this.tbxReceivedDate = new TextBox();
      this.tbxAmount = new TextBox();
      this.label10 = new Label();
      this.label3 = new Label();
      this.tbxPrincipal = new TextBox();
      this.label7 = new Label();
      this.tbxInterest = new TextBox();
      this.label9 = new Label();
      this.tbxInterestPlusPrincipal = new TextBox();
      this.label8 = new Label();
      this.tbxPaymentsAlreadyReceived = new TextBox();
      this.label6 = new Label();
      this.tbxAmountReceivable = new TextBox();
      this.label5 = new Label();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((Control) this.hpRedemptionDate).SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.544304f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.4557f));
      this.tableLayoutPanel1.Size = new Size(1024, 632);
      this.tableLayoutPanel1.TabIndex = 1;
      this.panel1.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1018, 47);
      this.panel1.TabIndex = 1;
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Rockwell", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.MediumBlue;
      this.label1.Location = new Point(367, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(250, 36);
      this.label1.TabIndex = 0;
      this.label1.Text = "PART PAYMENT";
      this.panel2.BackColor = Color.AliceBlue;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.hpRedemptionDate);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.panel2.Location = new Point(3, 56);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1018, 573);
      this.panel2.TabIndex = 0;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel2.CaptionText = "PREVIOUS PAYMENTS RECEIVED";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel2).Controls.Add((Control) this.dataGridView1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(484, 161);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(527, 374);
      ((Control) this.headerPanel2).TabIndex = 88;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton5).Location = new Point(222, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(356, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 0;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.GridColor = SystemColors.HotTrack;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(525, 350);
      this.dataGridView1.TabIndex = 10;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.deletePaymentToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 114);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.deletePaymentToolStripMenuItem.Name = "deletePaymentToolStripMenuItem";
      this.deletePaymentToolStripMenuItem.Size = new Size(194, 22);
      this.deletePaymentToolStripMenuItem.Text = "Delete Payment";
      this.deletePaymentToolStripMenuItem.Click += new EventHandler(this.deletePaymentToolStripMenuItem_Click);
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      this.headerPanel1.CaptionText = "BILL DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.dataGridView2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(483, 15);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(527, 140);
      ((Control) this.headerPanel1).TabIndex = 78;
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
      ((Control) this.glassButton1).Location = new Point(224, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 1;
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
      ((Control) this.glassButton2).Location = new Point(358, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.GridColor = SystemColors.HotTrack;
      this.dataGridView2.Location = new Point(0, 0);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(525, 116);
      this.dataGridView2.TabIndex = 85;
      this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
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
      this.hpRedemptionDate.CaptionText = "PART PAYMENT";
      this.hpRedemptionDate.CaptionVisible = true;
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.glassButton3);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.glassButton4);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxSerialNumber);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label11);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label2);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.lblReceivedOnDate);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.btnReceivePayment);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxReceivedDate);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxAmount);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label10);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label3);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxPrincipal);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label7);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxInterest);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label9);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxInterestPlusPrincipal);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label8);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxPaymentsAlreadyReceived);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label6);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.tbxAmountReceivable);
      ((Control) this.hpRedemptionDate).Controls.Add((Control) this.label5);
      ((Control) this.hpRedemptionDate).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpRedemptionDate).ForeColor = Color.DarkBlue;
      this.hpRedemptionDate.GradientDirection = LinearGradientMode.Vertical;
      this.hpRedemptionDate.GradientEnd = SystemColors.ControlLight;
      this.hpRedemptionDate.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpRedemptionDate).Location = new Point(7, 15);
      ((Control) this.hpRedemptionDate).Name = "hpRedemptionDate";
      this.hpRedemptionDate.PanelIcon = (Icon) null;
      this.hpRedemptionDate.PanelIconVisible = false;
      ((Control) this.hpRedemptionDate).Size = new Size(470, 520);
      ((Control) this.hpRedemptionDate).TabIndex = 87;
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
      ((Control) this.glassButton3).Location = new Point(167, 513);
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
      ((Control) this.glassButton4).Location = new Point(301, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSerialNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSerialNumber.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSerialNumber.Location = new Point(180, 13);
      this.tbxSerialNumber.Name = "tbxSerialNumber";
      this.tbxSerialNumber.Size = new Size(267, 30);
      this.tbxSerialNumber.TabIndex = 0;
      this.tbxSerialNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxSerialNumber.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.MediumBlue;
      this.label11.Location = new Point(96, 56);
      this.label11.Name = "label11";
      this.label11.Size = new Size(75, 22);
      this.label11.TabIndex = 84;
      this.label11.Text = "License";
      this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBillNumber.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(180, 91);
      this.tbxBillNumber.MaxLength = 6;
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(267, 30);
      this.tbxBillNumber.TabIndex = 1;
      this.tbxBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber.Enter += new EventHandler(this.tbxBillNumber_Enter);
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.tbxBillNumber_KeyDown);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.Validating += new CancelEventHandler(this.textBox1_Validating);
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.White;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(180, 55);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(264, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.MediumBlue;
      this.label2.Location = new Point(61, 95);
      this.label2.Name = "label2";
      this.label2.Size = new Size(111, 22);
      this.label2.TabIndex = 13;
      this.label2.Text = "BillNumber";
      this.lblReceivedOnDate.AutoSize = true;
      this.lblReceivedOnDate.BackColor = Color.Transparent;
      this.lblReceivedOnDate.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblReceivedOnDate.ForeColor = Color.MediumBlue;
      this.lblReceivedOnDate.Location = new Point(15, 381);
      this.lblReceivedOnDate.Name = "lblReceivedOnDate";
      this.lblReceivedOnDate.Size = new Size(159, 22);
      this.lblReceivedOnDate.TabIndex = 20;
      this.lblReceivedOnDate.Text = "Received On Date";
      this.btnReceivePayment.BackColor = Color.White;
      this.btnReceivePayment.FadeOnFocus = true;
      ((Control) this.btnReceivePayment).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnReceivePayment.ForeColor = Color.DarkBlue;
      this.btnReceivePayment.ForeColorOnFocus = Color.Red;
      this.btnReceivePayment.ForeColorOnLeave = Color.RoyalBlue;
      this.btnReceivePayment.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnReceivePayment).Image = (Image) componentResourceManager.GetObject("btnReceivePayment.Image");
      this.btnReceivePayment.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnReceivePayment).Location = new Point(177, 419);
      ((Control) this.btnReceivePayment).Name = "btnReceivePayment";
      this.btnReceivePayment.OuterBorderColor = Color.MistyRose;
      this.btnReceivePayment.ShineColor = Color.MistyRose;
      ((Control) this.btnReceivePayment).Size = new Size(267, 45);
      ((Control) this.btnReceivePayment).TabIndex = 9;
      ((Control) this.btnReceivePayment).Text = "&Receive Payment";
      ((ButtonBase) this.btnReceivePayment).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnReceivePayment).Click += new EventHandler(this.btnAddArticles_Click);
      this.tbxReceivedDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReceivedDate.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReceivedDate.Location = new Point(180, 377);
      this.tbxReceivedDate.Name = "tbxReceivedDate";
      this.tbxReceivedDate.Size = new Size(267, 30);
      this.tbxReceivedDate.TabIndex = 8;
      this.tbxReceivedDate.TextAlign = HorizontalAlignment.Center;
      this.tbxReceivedDate.TextChanged += new EventHandler(this.tbxReceivedDate_TextChanged);
      this.tbxReceivedDate.KeyDown += new KeyEventHandler(this.tbxReceivedDate_KeyDown);
      this.tbxReceivedDate.Validating += new CancelEventHandler(this.tbxReceivedDate_Validating);
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(180, 333);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(267, 30);
      this.tbxAmount.TabIndex = 7;
      this.tbxAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount.TextChanged += new EventHandler(this.tbxAmount_TextChanged);
      this.tbxAmount.KeyDown += new KeyEventHandler(this.tbxAmount_KeyDown);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
      this.tbxAmount.Validating += new CancelEventHandler(this.tbxAmount_Validating);
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.MediumBlue;
      this.label10.Location = new Point(37, 17);
      this.label10.Name = "label10";
      this.label10.Size = new Size(136, 22);
      this.label10.TabIndex = 12;
      this.label10.Text = "Serial Number";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.MediumBlue;
      this.label3.Location = new Point(24, 337);
      this.label3.Name = "label3";
      this.label3.Size = new Size(149, 22);
      this.label3.TabIndex = 19;
      this.label3.Text = "Receive Amount";
      this.tbxPrincipal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPrincipal.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPrincipal.Location = new Point(180, 132);
      this.tbxPrincipal.Name = "tbxPrincipal";
      this.tbxPrincipal.Size = new Size(267, 30);
      this.tbxPrincipal.TabIndex = 2;
      this.tbxPrincipal.TextAlign = HorizontalAlignment.Right;
      this.tbxPrincipal.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.MediumBlue;
      this.label7.Location = new Point(11, 296);
      this.label7.Name = "label7";
      this.label7.Size = new Size(161, 22);
      this.label7.TabIndex = 18;
      this.label7.Text = "Payment Pending";
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.Location = new Point(180, 172);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(267, 30);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.TextAlign = HorizontalAlignment.Right;
      this.tbxInterest.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.MediumBlue;
      this.label9.Location = new Point(9, 256);
      this.label9.Name = "label9";
      this.label9.Size = new Size(163, 22);
      this.label9.TabIndex = 17;
      this.label9.Text = "PaymentReceived";
      this.tbxInterestPlusPrincipal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestPlusPrincipal.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestPlusPrincipal.Location = new Point(180, 212);
      this.tbxInterestPlusPrincipal.Name = "tbxInterestPlusPrincipal";
      this.tbxInterestPlusPrincipal.Size = new Size(267, 30);
      this.tbxInterestPlusPrincipal.TabIndex = 4;
      this.tbxInterestPlusPrincipal.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestPlusPrincipal.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.MediumBlue;
      this.label8.Location = new Point(92, 176);
      this.label8.Name = "label8";
      this.label8.Size = new Size(80, 22);
      this.label8.TabIndex = 15;
      this.label8.Text = "Interest";
      this.tbxPaymentsAlreadyReceived.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPaymentsAlreadyReceived.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPaymentsAlreadyReceived.Location = new Point(180, 252);
      this.tbxPaymentsAlreadyReceived.Name = "tbxPaymentsAlreadyReceived";
      this.tbxPaymentsAlreadyReceived.Size = new Size(267, 30);
      this.tbxPaymentsAlreadyReceived.TabIndex = 5;
      this.tbxPaymentsAlreadyReceived.TextAlign = HorizontalAlignment.Right;
      this.tbxPaymentsAlreadyReceived.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.MediumBlue;
      this.label6.Location = new Point(118, 216);
      this.label6.Name = "label6";
      this.label6.Size = new Size(54, 22);
      this.label6.TabIndex = 16;
      this.label6.Text = "Total";
      this.tbxAmountReceivable.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmountReceivable.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountReceivable.Location = new Point(180, 292);
      this.tbxAmountReceivable.Name = "tbxAmountReceivable";
      this.tbxAmountReceivable.Size = new Size(267, 30);
      this.tbxAmountReceivable.TabIndex = 6;
      this.tbxAmountReceivable.TextAlign = HorizontalAlignment.Right;
      this.tbxAmountReceivable.KeyPress += new KeyPressEventHandler(this.tbxPrincipal_KeyPress);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Cambria", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.MediumBlue;
      this.label5.Location = new Point(93, 136);
      this.label5.Name = "label5";
      this.label5.Size = new Size(79, 22);
      this.label5.TabIndex = 14;
      this.label5.Text = "Amount";
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1024, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormPartPayment);
      this.Text = "Form4";
      this.Load += new EventHandler(this.Form4_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((Control) this.hpRedemptionDate).ResumeLayout(false);
      ((Control) this.hpRedemptionDate).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
