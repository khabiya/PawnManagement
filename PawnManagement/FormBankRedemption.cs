
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
  public class FormBankRedemption : Form
  {
    private List<string> lstBankBillNumber = new List<string>();
    private string RedemptionOrRedemptionEdit = "";
    private int dotCount = 0;
    private string oldValues;
    private string newValues;
    private IContainer components = (IContainer) null;
    private TextBox tbxBankBillDate;
    private TextBox tbxAmount;
    private Label label9;
    private Label label8;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox tbxSerialNumber;
    private TextBox tbxBranch;
    private TextBox tbxBankBillNumber;
    private TextBox tbxBankName;
    private Label label13;
    private TextBox tbxInterestRate;
    private TextBox tbxRedemptionAmount;
    private TextBox tbxRedemptionDate;
    private TextBox tbxInterest;
    private Label label6;
    private Label label10;
    private Label label11;
    private GlassButton btnRelease;
    private TextBox tbxBankCode;
    private DataGridView dataGridView1;
    private GlassButton btnUpdate;
    private Label label5;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label12;
    private Label label14;
    private Label label15;
    private Label label19;
    private TextBox tbxLedgerCodeInterest;
    private TextBox tbxVoucherCodeInterest;
    private TextBox tbxVoucherNameInterest;
    private TextBox tbxLedgerTypeInterest;
    private TextBox tbxVoucherName;
    private TextBox tbxLedgerType;
    private TextBox tbxLedgerCode;
    private TextBox tbxVoucherCode;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label lblHeading;
    private Panel panel3;
    private HeaderPanel headerPanel1;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel3;
    private HeaderPanel headerPanel4;

    public FormBankRedemption() => this.InitializeComponent();

    public FormBankRedemption(string str)
    {
      this.RedemptionOrRedemptionEdit = str;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getlstBankBillNumberForEdit()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BankBillNumber from tblBankPledge where Released = 'Y'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BankBillNumber" + strError);
          PawnManagementClass.InsertIntoException("Form BankPledge.getBankBillNumber()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
            this.lstBankBillNumber.Add(dataTable2.Rows[index].Field<string>("BankBillNumber"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  addcustomer.getaddress()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getlstBankBillNumber()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BankBillNumber from tblBankPledge where Released = 'N'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BankBillNumber" + strError);
          PawnManagementClass.InsertIntoException("Form BankPledge.getBankBillNumber()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
            this.lstBankBillNumber.Add(dataTable2.Rows[index].Field<string>("BankBillNumber"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  addcustomer.getaddress()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void FormBankRedemption_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatButtonBlue(ref this.btnRelease);
      PawnManagementClass.formatButtonBlue(ref this.btnUpdate);
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      if (this.RedemptionOrRedemptionEdit == "Redemption")
      {
        this.tbxRedemptionDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        this.tbxBankBillNumber.Focus();
        this.tbxBankBillNumber.Select();
        ((Control) this.btnRelease).Visible = true;
        ((Control) this.btnUpdate).Visible = false;
        this.getlstBankBillNumber();
        this.tbxBankBillNumber.AutoCompleteCustomSource.AddRange(this.lstBankBillNumber.ToArray());
        this.lblHeading.Text = "REDEMPTION";
      }
      else
      {
        if (!(this.RedemptionOrRedemptionEdit == "RedemptionEdit"))
          return;
        ((Control) this.btnUpdate).Visible = true;
        ((Control) this.btnRelease).Visible = false;
        this.getlstBankBillNumberForEdit();
        this.tbxBankBillNumber.AutoCompleteCustomSource.AddRange(this.lstBankBillNumber.ToArray());
        this.lblHeading.Text = "REDEMPTION EDIT";
        this.tbxBankBillNumber.Select();
      }
    }

    private void tbxBankBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (this.RedemptionOrRedemptionEdit == "Redemption")
        {
          if (this.tbxBankBillNumber.Text != "")
          {
            if (this.getBankBillNumber())
            {
              if (this.checkBankBillNumberReleasedOrNot())
              {
                string strError = "";
                string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber and Released = 'N'";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
                if (strError != "")
                {
                  PawnManagementClass.InsertIntoException("Form Bank Redemption.tbxbankbillnumber_validating", strError, FormMain.username, DateTime.Now.ToString());
                  int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
                }
                else if (dataTable2 != null & dataTable2.Rows.Count > 0)
                {
                  this.tbxSerialNumber.Text = dataTable2.Rows[0].Field<int>("SerialNumber").ToString();
                  this.tbxBankCode.Text = dataTable2.Rows[0].Field<string>("BankCode").ToString();
                  this.tbxBankName.Text = dataTable2.Rows[0].Field<string>("Bankname").ToString();
                  this.tbxBranch.Text = dataTable2.Rows[0].Field<string>("Branch").ToString();
                  this.tbxBankBillDate.Text = dataTable2.Rows[0].Field<DateTime>("BankBillDate").ToString("dd/MM/yyyy");
                  this.tbxAmount.Text = dataTable2.Rows[0].Field<string>("Amount").ToString();
                  this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
                  double numberOfMonths = (double) PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.tbxBankBillDate.Text.ToString()), DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")));
                  if (dataTable2.Rows[0].Field<string>("InterestType").ToString().Equals("SIMPLE INTEREST"))
                    this.tbxInterest.Text = (double.Parse(this.tbxAmount.Text.ToString()) * numberOfMonths * double.Parse(this.tbxInterestRate.Text.ToString()) / 1200.0).ToString("F");
                  if (dataTable2.Rows[0].Field<string>("InterestType").ToString().Equals("COMPOUND INTEREST YEARLY"))
                    this.tbxInterest.Text = PawnManagementClass.calculateCompundInterest(double.Parse(this.tbxAmount.Text.ToString()), numberOfMonths, double.Parse(this.tbxInterestRate.Text.ToString())).ToString("F");
                  if (dataTable2.Rows[0].Field<string>("InterestType").ToString().Equals("COMPOUND INTEREST MONTHLY"))
                    this.tbxInterest.Text = PawnManagementClass.calculatePeriodicCompundInterest(double.Parse(this.tbxAmount.Text.ToString()), numberOfMonths, double.Parse(this.tbxInterestRate.Text.ToString()), 12.0).ToString("F");
                }
                this.getPledgeNumberAndCustomerName();
              }
              else
              {
                int num = (int) MessageBox.Show("Bill Number already released");
                this.tbxBankBillNumber.Select();
              }
            }
            else
            {
              int num = (int) MessageBox.Show("Invalid Bank Bill Number");
              this.tbxBankBillNumber.Select();
            }
          }
          else
            this.tbxBankBillNumber.Select();
        }
        else
        {
          if (!(this.RedemptionOrRedemptionEdit == "RedemptionEdit"))
            return;
          if (this.getBankBillNumber())
          {
            if (!this.checkBankBillNumberReleasedOrNot())
            {
              string strError = "";
              string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber and Released = 'Y'";
              List<OleDbParameter> parameters = new List<OleDbParameter>();
              parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
              DataTable dataTable3 = new DataTable();
              DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
              if (strError != "")
              {
                PawnManagementClass.InsertIntoException("form bank redemption.tbx_bankbillnumber_validating when redemtionEdit", strError, FormMain.username, DateTime.Now.ToString());
                int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
              }
              else if (dataTable4 != null & dataTable4.Rows.Count > 0)
              {
                this.tbxSerialNumber.Text = dataTable4.Rows[0].Field<int>("SerialNumber").ToString();
                this.tbxBankCode.Text = dataTable4.Rows[0].Field<string>("BankCode").ToString();
                this.tbxBankName.Text = dataTable4.Rows[0].Field<string>("Bankname").ToString();
                this.tbxBranch.Text = dataTable4.Rows[0].Field<string>("Branch").ToString();
                this.tbxBankBillDate.Text = dataTable4.Rows[0].Field<DateTime>("BankBillDate").ToString("dd/MM/yyyy");
                this.tbxAmount.Text = dataTable4.Rows[0].Field<string>("Amount").ToString();
                this.tbxInterestRate.Text = dataTable4.Rows[0]["InterestRate"].ToString();
                this.tbxInterest.Text = dataTable4.Rows[0]["Interest"].ToString();
                this.tbxRedemptionAmount.Text = dataTable4.Rows[0]["RedemptionAmount"].ToString();
                this.tbxRedemptionDate.Text = dataTable4.Rows[0].Field<DateTime>("RedemptionDate").ToString("dd/MM/yyyy");
                this.oldValues = "Old values are Interest =" + this.tbxInterest.Text.Trim().ToString() + " , \n RedemptionAmount =" + this.tbxRedemptionAmount.Text.Trim().ToString() + " , \n RedemptionDate =" + this.tbxRedemptionDate.Text.Trim().ToString();
              }
              this.getPledgeNumberAndCustomerName();
            }
            else
            {
              int num = (int) MessageBox.Show("Bill Number Not released");
              this.tbxBankBillNumber.Select();
            }
          }
          else
          {
            int num = (int) MessageBox.Show("Invalid Bank Bill Number");
            this.tbxBankBillNumber.Select();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form bankRedemption.tbxBankBillNumber_Validating", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPledgeNumberAndCustomerName()
    {
      string strError = "";
      string my_querry = "select PledgeBillNumber,CustomerName,SHOPCODE from tblBankPledgePledgeBills where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("From BankRedemption.getPledgeNumberAndCustomerName", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private bool checkBankBillNumberReleasedOrNot()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber and Released = 'N'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form bankRedemption.checkBankBillNumberReleaseOrnot", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private bool getBankBillNumber()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form BankRedemption.getBankBillNumber", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void deleteBankCodeFromPledgeTable(string BankSerialNumber)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode  where BankSerialNumber=@BankSerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("BankCode", (object) ""),
        new OleDbParameter(nameof (BankSerialNumber), (object) BankSerialNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("FORM bankRedemption.deletebankCodefromPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void reset()
    {
      this.tbxSerialNumber.Text = "";
      this.tbxBankCode.Text = "";
      this.tbxBankName.Text = "";
      this.tbxBranch.Text = "";
      this.tbxAmount.Text = "";
      this.tbxInterestRate.Text = "";
      this.tbxInterest.Text = "";
      this.tbxRedemptionAmount.Text = "";
      this.tbxBankBillNumber.Text = "";
      this.tbxBankBillDate.Text = "";
      for (int index = 0; index < this.dataGridView1.Rows.Count; ++index)
        this.dataGridView1.Rows.RemoveAt(0);
    }

    private void tbxInterest_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxInterest_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxInterest_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxInterest.Text != ""))
        return;
      this.tbxRedemptionAmount.Text = (double.Parse(this.tbxAmount.Text.Trim().ToString()) + double.Parse(this.tbxInterest.Text.Trim().ToString())).ToString();
    }

    private void tbxBankBillNumber_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (this.tbxInterest.Text.Trim() != "" & this.tbxRedemptionAmount.Text.Trim() != "" & this.tbxRedemptionDate.Text.Trim() != "")
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxRedemptionDate.Text))
        {
          DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " Release");
          if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
          {
            if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
            {
              this.updateTableBankPledge();
              if (this.getRokadAutoEntrySettings())
                this.updateTableVouchers();
              this.reset();
              this.Close();
            }
            else if (DialogResult.Yes == MessageBox.Show("Rokad has already been finished for this day...But still do you want to update..???", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              this.updateTableBankPledge();
              this.reset();
              this.Close();
            }
          }
          else
          {
            int num = (int) MessageBox.Show("Invalid Bank BillNumber..........");
          }
        }
        else
          this.tbxRedemptionDate.Select();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Enter all the data");
      }
    }

    private void updateTableBankPledge()
    {
      string strError = "";
      DateTime now;
      if (SQLHelper.RunCommand("Update tblBankPledge set Interest = @Interest,RedemptionAmount=@RedemptionAmount,RedemptionDate = @RedemptionDate where SerialNumber=@SerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("Interest", (object) this.tbxInterest.Text.Trim().ToString()),
        new OleDbParameter("RedemptionAmount", (object) this.tbxRedemptionAmount.Text.Trim().ToString()),
        new OleDbParameter("RedemptionDate", (object) this.tbxRedemptionDate.Text.Trim().ToString()),
        new OleDbParameter("SerialNumber", (object) this.tbxSerialNumber.Text.ToString())
      }, ref strError) != "Done")
      {
        string MessageAnDStackTrace = strError;
        string username = FormMain.username;
        now = DateTime.Now;
        string CreatedOn = now.ToString();
        PawnManagementClass.InsertIntoException("Form BankRedemption.btnUpdate_Click", MessageAnDStackTrace, username, CreatedOn);
        int num = (int) MessageBox.Show("Error in editing BankPledge" + strError);
      }
      this.newValues = "New  values are Interest =" + this.tbxInterest.Text.Trim().ToString() + " , \n RedemptionAmount =" + this.tbxRedemptionAmount.Text.Trim().ToString() + " , \n RedemptionDate =" + this.tbxRedemptionDate.Text.Trim().ToString();
      string ActionDetails = "Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + " Edited";
      string oldValues = this.oldValues;
      string newValues = this.newValues;
      string username1 = FormMain.username;
      now = DateTime.Now;
      string PerformedOn = now.ToString();
      PawnManagementClass.InsertIntoHistory("BANK REDEMPTION EDIT", ActionDetails, oldValues, newValues, username1, PerformedOn);
    }

    private void updateTableVouchers()
    {
      try
      {
        DataTable voucherNumberAndDate1 = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " Release");
        string voucherNumber1 = voucherNumberAndDate1.Rows[0]["voucherNumber"].ToString();
        string str = voucherNumberAndDate1.Rows[0]["voucherDate"].ToString();
        if (PawnManagementClass.checkIfRokadFinished(str))
          return;
        DataTable voucherNumberAndDate2 = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " INTEREST");
        string voucherNumber2 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
        string s = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
        PawnManagementClass.updatetblVouchers(DateTime.Parse(str), voucherNumber1, this.tbxVoucherCode.Text.Trim().ToString(), this.tbxVoucherName.Text.Trim().ToString(), this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " Release", this.tbxLedgerCode.Text.Trim().ToString(), "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
        PawnManagementClass.updatetblVouchers(DateTime.Parse(s), voucherNumber2, this.tbxVoucherCodeInterest.Text.ToString(), this.tbxVoucherNameInterest.Text.ToString(), this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " INTEREST", this.tbxLedgerCodeInterest.Text, "NOVAE", double.Parse(this.tbxInterest.Text.Trim()));
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

    private void tbxBankBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbxRedemptionDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '/')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void btnRelease_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxInterest.Text != "" & this.tbxRedemptionAmount.Text != "" & this.tbxRedemptionDate.Text != "")
        {
          if (this.dataGridView1.CurrentCell != null)
          {
            string strError = "";
            DateTime now;
            if (SQLHelper.RunCommand("Update tblBankPledge set Interest=@Interest,RedemptionAmount = @RedemptionAmount,RedemptionDate = @RedemptionDate,Released = @Released where BankBillNumber=@BankBillNumber", new List<OleDbParameter>()
            {
              new OleDbParameter("Interest", (object) this.tbxInterest.Text.Trim().ToString()),
              new OleDbParameter("RedemptionAmount", (object) this.tbxRedemptionAmount.Text.Trim().ToString()),
              new OleDbParameter("RedemptionDate", (object) this.tbxRedemptionDate.Text.Trim().ToString()),
              new OleDbParameter("Released", (object) "Y"),
              new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.ToString())
            }, ref strError) != "Done")
            {
              string MessageAnDStackTrace = strError;
              string username = FormMain.username;
              now = DateTime.Now;
              string CreatedOn = now.ToString();
              PawnManagementClass.InsertIntoException("Form bankRedemption", MessageAnDStackTrace, username, CreatedOn);
              int num = (int) MessageBox.Show("Error in Bank redemption" + strError);
            }
            if (this.getRokadAutoEntrySettings())
              this.InsertIntotblVouchers();
            string ActionDetails = "Bank bill Number" + this.tbxBankBillNumber.Text.ToString() + "released";
            string username1 = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("BANK RELEASE", ActionDetails, "", "", username1, PerformedOn);
            this.deleteBankCodeFromPledgeTable(this.tbxSerialNumber.Text.Trim().ToString());
            this.reset();
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Enter all the data");
        }
        this.tbxBankBillNumber.Focus();
        this.tbxBankBillNumber.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form bankRedemption.btnRElease_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
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

    private void InsertIntotblVouchers()
    {
      try
      {
        if (!(this.tbxVoucherCode.Text.Trim().ToString() != "") || !(this.tbxLedgerCode.Text.Trim().ToString() != ""))
          return;
        string s = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
        string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), maxOfVoucherNumber, this.tbxVoucherCode.Text.Trim().ToString(), this.tbxVoucherName.Text.Trim().ToString(), this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " Release", this.tbxLedgerCode.Text.Trim().ToString(), "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
        string voucherNumber = (int.Parse(maxOfVoucherNumber) + 1).ToString();
        PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), voucherNumber, this.tbxVoucherCodeInterest.Text, this.tbxVoucherNameInterest.Text, this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " INTEREST", this.tbxLedgerCodeInterest.Text, "NOVAE", double.Parse(this.tbxInterest.Text.Trim()));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Bankpledge.insertIntoTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLegderCodeAndVoucherCode(string BankCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgerCode,VoucherCode from tblLinkBankCodeWithVoucherCode where BankCode =@BankCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (BankCode), (object) BankCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form LinkBankCodeAndVoucherCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving LedgerCode and Vouchercode" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.tbxVoucherCode.Text = dataTable2.Rows[0]["VoucherCode"].ToString();
          this.tbxLedgerCode.Text = dataTable2.Rows[0]["LedgerCode"].ToString();
        }
        else
        {
          this.tbxVoucherCode.Text = "";
          this.tbxLedgerCode.Text = "";
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formBankRedemption.getLedgerCodeAndVouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getVoucherName(string voucherCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblVoucherMaster where voucherCode = @VoucherCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherCode", (object) voucherCode)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form LinkBankcodeAndVoucherCode.getVouchername(string vouchercode)", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving VoucherName" + strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["VoucherName"].ToString() : "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankRedemption.getvouchername(string vouchercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private void tbxBankCode_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where BankCode = @BankCode ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BankCode", (object) this.tbxBankCode.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.combobox1selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in Adding BankPledge" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.tbxBankName.Text = dataTable2.Rows[0]["BankName"].ToString();
          this.tbxBranch.Text = dataTable2.Rows[0]["Branch"].ToString();
          this.tbxLedgerCode.Text = dataTable2.Rows[0]["LedgerCode"].ToString();
          this.tbxLedgerCodeInterest.Text = dataTable2.Rows[0]["LedgerCodeInterest"].ToString();
          this.tbxVoucherCode.Text = dataTable2.Rows[0]["VoucherCode"].ToString();
          this.tbxVoucherCodeInterest.Text = dataTable2.Rows[0]["VoucherCodeInterest"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void headerPanel4_Paint(object sender, PaintEventArgs e)
    {
    }

    private void tbxVoucherCodeInterest_TextChanged(object sender, EventArgs e) => this.tbxVoucherNameInterest.Text = this.getVoucherName(this.tbxVoucherCodeInterest.Text);

    private void tbxLedgerCodeInterest_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxVoucherCode_TextChanged(object sender, EventArgs e) => this.tbxVoucherName.Text = this.getVoucherName(this.tbxVoucherCode.Text);

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "PledgeBillNumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["PledgeBillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "PledgeBillNumber" | this.dataGridView1.Columns[e.ColumnIndex].Name == "customercode" | this.dataGridView1.Columns[e.ColumnIndex].Name == "billnumber")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
    }

    private void tbxRedemptionDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (PawnManagementClass.checkForValidateDate(this.tbxRedemptionDate.Text))
      {
        if (this.RedemptionOrRedemptionEdit == "Redemption")
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
        else if (this.RedemptionOrRedemptionEdit == "RedemptionEdit")
          ((Control) this.btnUpdate).Focus();
      }
      else
        this.tbxRedemptionDate.Select();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxBankBillDate = new TextBox();
      this.tbxAmount = new TextBox();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.tbxSerialNumber = new TextBox();
      this.tbxBranch = new TextBox();
      this.tbxBankBillNumber = new TextBox();
      this.tbxBankName = new TextBox();
      this.label13 = new Label();
      this.tbxInterestRate = new TextBox();
      this.tbxRedemptionAmount = new TextBox();
      this.tbxRedemptionDate = new TextBox();
      this.tbxInterest = new TextBox();
      this.label6 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.tbxBankCode = new TextBox();
      this.dataGridView1 = new DataGridView();
      this.label5 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.label12 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label19 = new Label();
      this.tbxLedgerCodeInterest = new TextBox();
      this.tbxVoucherCodeInterest = new TextBox();
      this.tbxVoucherNameInterest = new TextBox();
      this.tbxLedgerTypeInterest = new TextBox();
      this.tbxVoucherName = new TextBox();
      this.tbxLedgerType = new TextBox();
      this.tbxLedgerCode = new TextBox();
      this.tbxVoucherCode = new TextBox();
      this.btnUpdate = new GlassButton();
      this.btnRelease = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.lblHeading = new Label();
      this.panel3 = new Panel();
      this.headerPanel4 = new HeaderPanel();
      this.headerPanel3 = new HeaderPanel();
      this.headerPanel1 = new HeaderPanel();
      this.headerPanel2 = new HeaderPanel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.tbxBankBillDate.Anchor = AnchorStyles.None;
      this.tbxBankBillDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankBillDate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankBillDate.Location = new Point(278, 79);
      this.tbxBankBillDate.Name = "tbxBankBillDate";
      this.tbxBankBillDate.ReadOnly = true;
      this.tbxBankBillDate.Size = new Size(228, 26);
      this.tbxBankBillDate.TabIndex = 9;
      this.tbxAmount.Anchor = AnchorStyles.None;
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(278, 169);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(228, 26);
      this.tbxAmount.TabIndex = 10;
      this.label9.Anchor = AnchorStyles.None;
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(213, 174);
      this.label9.Name = "label9";
      this.label9.Size = new Size(59, 16);
      this.label9.TabIndex = 85;
      this.label9.Text = "Amount";
      this.label8.Anchor = AnchorStyles.None;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(174, 84);
      this.label8.Name = "label8";
      this.label8.Size = new Size(98, 16);
      this.label8.TabIndex = 84;
      this.label8.Text = "BankBillDate";
      this.label4.Anchor = AnchorStyles.None;
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(42, 101);
      this.label4.Name = "label4";
      this.label4.Size = new Size(56, 16);
      this.label4.TabIndex = 82;
      this.label4.Text = "Branch";
      this.label3.Anchor = AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(10, 65);
      this.label3.Name = "label3";
      this.label3.Size = new Size(88, 16);
      this.label3.TabIndex = 81;
      this.label3.Text = "Bank Name";
      this.label2.Anchor = AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(14, 29);
      this.label2.Name = "label2";
      this.label2.Size = new Size(84, 16);
      this.label2.TabIndex = 80;
      this.label2.Text = "Bank Code";
      this.label1.Anchor = AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(165, 39);
      this.label1.Name = "label1";
      this.label1.Size = new Size(107, 16);
      this.label1.TabIndex = 79;
      this.label1.Text = "Serial Number";
      this.tbxSerialNumber.Anchor = AnchorStyles.None;
      this.tbxSerialNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSerialNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSerialNumber.Location = new Point(278, 34);
      this.tbxSerialNumber.Name = "tbxSerialNumber";
      this.tbxSerialNumber.ReadOnly = true;
      this.tbxSerialNumber.Size = new Size(228, 26);
      this.tbxSerialNumber.TabIndex = 5;
      this.tbxBranch.Anchor = AnchorStyles.None;
      this.tbxBranch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBranch.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBranch.Location = new Point(104, 96);
      this.tbxBranch.Name = "tbxBranch";
      this.tbxBranch.ReadOnly = true;
      this.tbxBranch.Size = new Size(228, 26);
      this.tbxBranch.TabIndex = 8;
      this.tbxBankBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxBankBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBankBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBankBillNumber.Dock = DockStyle.Fill;
      this.tbxBankBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankBillNumber.Location = new Point(0, 0);
      this.tbxBankBillNumber.Name = "tbxBankBillNumber";
      this.tbxBankBillNumber.Size = new Size(360, 28);
      this.tbxBankBillNumber.TabIndex = 0;
      this.tbxBankBillNumber.KeyDown += new KeyEventHandler(this.tbxBankBillNumber_KeyDown);
      this.tbxBankBillNumber.KeyUp += new KeyEventHandler(this.tbxBankBillNumber_KeyUp);
      this.tbxBankBillNumber.Validating += new CancelEventHandler(this.tbxBankBillNumber_Validating);
      this.tbxBankName.Anchor = AnchorStyles.None;
      this.tbxBankName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankName.Location = new Point(104, 60);
      this.tbxBankName.Name = "tbxBankName";
      this.tbxBankName.ReadOnly = true;
      this.tbxBankName.Size = new Size(228, 26);
      this.tbxBankName.TabIndex = 7;
      this.label13.Anchor = AnchorStyles.None;
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(176, 129);
      this.label13.Name = "label13";
      this.label13.Size = new Size(96, 16);
      this.label13.TabIndex = 89;
      this.label13.Text = "Interest Rate";
      this.tbxInterestRate.Anchor = AnchorStyles.None;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(278, 124);
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.ReadOnly = true;
      this.tbxInterestRate.Size = new Size(228, 26);
      this.tbxInterestRate.TabIndex = 11;
      this.tbxRedemptionAmount.Anchor = AnchorStyles.None;
      this.tbxRedemptionAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRedemptionAmount.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionAmount.Location = new Point(278, 259);
      this.tbxRedemptionAmount.Name = "tbxRedemptionAmount";
      this.tbxRedemptionAmount.ReadOnly = true;
      this.tbxRedemptionAmount.Size = new Size(228, 26);
      this.tbxRedemptionAmount.TabIndex = 2;
      this.tbxRedemptionAmount.KeyDown += new KeyEventHandler(this.tbxBankBillNumber_KeyDown);
      this.tbxRedemptionAmount.KeyPress += new KeyPressEventHandler(this.tbxInterest_KeyPress);
      this.tbxRedemptionDate.Anchor = AnchorStyles.None;
      this.tbxRedemptionDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRedemptionDate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionDate.Location = new Point(278, 304);
      this.tbxRedemptionDate.Name = "tbxRedemptionDate";
      this.tbxRedemptionDate.Size = new Size(228, 26);
      this.tbxRedemptionDate.TabIndex = 3;
      this.tbxRedemptionDate.KeyDown += new KeyEventHandler(this.tbxRedemptionDate_KeyDown);
      this.tbxRedemptionDate.KeyPress += new KeyPressEventHandler(this.tbxRedemptionDate_KeyPress);
      this.tbxInterest.Anchor = AnchorStyles.None;
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.Location = new Point(278, 214);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(228, 26);
      this.tbxInterest.TabIndex = 1;
      this.tbxInterest.TextChanged += new EventHandler(this.tbxInterest_TextChanged);
      this.tbxInterest.KeyDown += new KeyEventHandler(this.tbxBankBillNumber_KeyDown);
      this.tbxInterest.KeyPress += new KeyPressEventHandler(this.tbxInterest_KeyPress);
      this.tbxInterest.Validating += new CancelEventHandler(this.tbxInterest_Validating);
      this.label6.Anchor = AnchorStyles.None;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(125, 264);
      this.label6.Name = "label6";
      this.label6.Size = new Size(147, 16);
      this.label6.TabIndex = 96;
      this.label6.Text = "Redemption Amount";
      this.label10.Anchor = AnchorStyles.None;
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(143, 309);
      this.label10.Name = "label10";
      this.label10.Size = new Size(129, 16);
      this.label10.TabIndex = 95;
      this.label10.Text = "Redemption Date";
      this.label11.Anchor = AnchorStyles.None;
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(213, 219);
      this.label11.Name = "label11";
      this.label11.Size = new Size(59, 16);
      this.label11.TabIndex = 94;
      this.label11.Text = "Interest";
      this.tbxBankCode.Anchor = AnchorStyles.None;
      this.tbxBankCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankCode.Location = new Point(104, 24);
      this.tbxBankCode.Name = "tbxBankCode";
      this.tbxBankCode.ReadOnly = true;
      this.tbxBankCode.Size = new Size(228, 26);
      this.tbxBankCode.TabIndex = 6;
      this.tbxBankCode.TextChanged += new EventHandler(this.tbxBankCode_TextChanged);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(360, 152);
      this.dataGridView1.TabIndex = 12;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(76, 492);
      this.label5.Name = "label5";
      this.label5.Size = new Size(97, 16);
      this.label5.TabIndex = 118;
      this.label5.Text = "Ledger Type";
      this.label5.Visible = false;
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(75, 462);
      this.label16.Name = "label16";
      this.label16.Size = new Size(98, 16);
      this.label16.TabIndex = 117;
      this.label16.Text = "Ledger Code";
      this.label16.Visible = false;
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(63, 429);
      this.label17.Name = "label17";
      this.label17.Size = new Size(110, 16);
      this.label17.TabIndex = 116;
      this.label17.Text = "Voucher Name";
      this.label17.Visible = false;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(67, 399);
      this.label18.Name = "label18";
      this.label18.Size = new Size(106, 16);
      this.label18.TabIndex = 115;
      this.label18.Text = "Voucher Code";
      this.label18.Visible = false;
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(56, 367);
      this.label12.Name = "label12";
      this.label12.Size = new Size(117, 16);
      this.label12.TabIndex = 114;
      this.label12.Text = "Ledger Type Int";
      this.label12.Visible = false;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(55, 334);
      this.label14.Name = "label14";
      this.label14.Size = new Size(118, 16);
      this.label14.TabIndex = 113;
      this.label14.Text = "Ledger Code Int";
      this.label14.Visible = false;
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(43, 302);
      this.label15.Name = "label15";
      this.label15.Size = new Size(130, 16);
      this.label15.TabIndex = 112;
      this.label15.Text = "Voucher Name Int";
      this.label15.Visible = false;
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(47, 271);
      this.label19.Name = "label19";
      this.label19.Size = new Size(126, 16);
      this.label19.TabIndex = 111;
      this.label19.Text = "Voucher Code Int";
      this.label19.Visible = false;
      this.tbxLedgerCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCodeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCodeInterest.Location = new Point(182, 329);
      this.tbxLedgerCodeInterest.Name = "tbxLedgerCodeInterest";
      this.tbxLedgerCodeInterest.ReadOnly = true;
      this.tbxLedgerCodeInterest.Size = new Size((int) byte.MaxValue, 26);
      this.tbxLedgerCodeInterest.TabIndex = 110;
      this.tbxLedgerCodeInterest.Visible = false;
      this.tbxLedgerCodeInterest.TextChanged += new EventHandler(this.tbxLedgerCodeInterest_TextChanged);
      this.tbxVoucherCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCodeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCodeInterest.Location = new Point(182, 265);
      this.tbxVoucherCodeInterest.Name = "tbxVoucherCodeInterest";
      this.tbxVoucherCodeInterest.ReadOnly = true;
      this.tbxVoucherCodeInterest.Size = new Size((int) byte.MaxValue, 26);
      this.tbxVoucherCodeInterest.TabIndex = 109;
      this.tbxVoucherCodeInterest.Visible = false;
      this.tbxVoucherCodeInterest.TextChanged += new EventHandler(this.tbxVoucherCodeInterest_TextChanged);
      this.tbxVoucherNameInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNameInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNameInterest.Location = new Point(182, 297);
      this.tbxVoucherNameInterest.Name = "tbxVoucherNameInterest";
      this.tbxVoucherNameInterest.ReadOnly = true;
      this.tbxVoucherNameInterest.Size = new Size((int) byte.MaxValue, 26);
      this.tbxVoucherNameInterest.TabIndex = 107;
      this.tbxVoucherNameInterest.Visible = false;
      this.tbxLedgerTypeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInterest.Location = new Point(182, 361);
      this.tbxLedgerTypeInterest.Name = "tbxLedgerTypeInterest";
      this.tbxLedgerTypeInterest.ReadOnly = true;
      this.tbxLedgerTypeInterest.Size = new Size((int) byte.MaxValue, 26);
      this.tbxLedgerTypeInterest.TabIndex = 108;
      this.tbxLedgerTypeInterest.Visible = false;
      this.tbxVoucherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherName.Location = new Point(182, 425);
      this.tbxVoucherName.Name = "tbxVoucherName";
      this.tbxVoucherName.ReadOnly = true;
      this.tbxVoucherName.Size = new Size((int) byte.MaxValue, 26);
      this.tbxVoucherName.TabIndex = 106;
      this.tbxVoucherName.Visible = false;
      this.tbxLedgerType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerType.Location = new Point(182, 489);
      this.tbxLedgerType.Name = "tbxLedgerType";
      this.tbxLedgerType.ReadOnly = true;
      this.tbxLedgerType.Size = new Size((int) byte.MaxValue, 26);
      this.tbxLedgerType.TabIndex = 105;
      this.tbxLedgerType.Visible = false;
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(182, 457);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.ReadOnly = true;
      this.tbxLedgerCode.Size = new Size((int) byte.MaxValue, 26);
      this.tbxLedgerCode.TabIndex = 103;
      this.tbxLedgerCode.Visible = false;
      this.tbxVoucherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(182, 393);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.ReadOnly = true;
      this.tbxVoucherCode.Size = new Size((int) byte.MaxValue, 26);
      this.tbxVoucherCode.TabIndex = 104;
      this.tbxVoucherCode.Visible = false;
      this.tbxVoucherCode.TextChanged += new EventHandler(this.tbxVoucherCode_TextChanged);
      ((Control) this.btnUpdate).Anchor = AnchorStyles.None;
      this.btnUpdate.BackColor = Color.LightBlue;
      this.btnUpdate.FadeOnFocus = true;
      ((Control) this.btnUpdate).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUpdate.ForeColor = Color.MediumBlue;
      this.btnUpdate.ForeColorOnFocus = Color.Red;
      this.btnUpdate.ForeColorOnLeave = Color.RoyalBlue;
      this.btnUpdate.GlowColor = Color.White;
      ((ButtonBase) this.btnUpdate).Image = (Image) Resources.reset;
      this.btnUpdate.InnerBorderColor = Color.Transparent;
      ((Control) this.btnUpdate).Location = new Point(360, 339);
      ((Control) this.btnUpdate).Name = "btnUpdate";
      this.btnUpdate.OuterBorderColor = Color.MediumSlateBlue;
      this.btnUpdate.ShineColor = Color.Transparent;
      ((Control) this.btnUpdate).Size = new Size(168, 60);
      ((Control) this.btnUpdate).TabIndex = 13;
      ((Control) this.btnUpdate).Text = "&UPDATE";
      ((ButtonBase) this.btnUpdate).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnUpdate).Click += new EventHandler(this.btnUpdate_Click);
      ((Control) this.btnRelease).Anchor = AnchorStyles.None;
      this.btnRelease.BackColor = Color.LightBlue;
      this.btnRelease.FadeOnFocus = true;
      ((Control) this.btnRelease).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnRelease.ForeColor = Color.MediumBlue;
      this.btnRelease.ForeColorOnFocus = Color.Red;
      this.btnRelease.ForeColorOnLeave = Color.RoyalBlue;
      this.btnRelease.GlowColor = Color.White;
      ((ButtonBase) this.btnRelease).Image = (Image) Resources.tick;
      this.btnRelease.InnerBorderColor = Color.Transparent;
      ((Control) this.btnRelease).Location = new Point(163, 339);
      ((Control) this.btnRelease).Name = "btnRelease";
      this.btnRelease.OuterBorderColor = Color.MediumSlateBlue;
      this.btnRelease.ShineColor = Color.Transparent;
      ((Control) this.btnRelease).Size = new Size(168, 60);
      ((Control) this.btnRelease).TabIndex = 4;
      ((Control) this.btnRelease).Text = "&Release";
      ((ButtonBase) this.btnRelease).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnRelease).Click += new EventHandler(this.btnRelease_Click);
      this.tableLayoutPanel1.Anchor = AnchorStyles.None;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Location = new Point(0, 53);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.042553f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90.95744f));
      this.tableLayoutPanel1.Size = new Size(1008, 515);
      this.tableLayoutPanel1.TabIndex = 119;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 40);
      this.panel2.TabIndex = 9;
      this.lblHeading.Anchor = AnchorStyles.None;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.Black;
      this.lblHeading.Location = new Point(373, 3);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(245, 29);
      this.lblHeading.TabIndex = 10;
      this.lblHeading.Text = "BANK REDEMPTION";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.headerPanel4);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 49);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 463);
      this.panel3.TabIndex = 11;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.Azure;
      this.headerPanel4.CaptionEndColor = Color.SkyBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "LOAN DETAILS";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxSerialNumber);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxBankBillDate);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxInterestRate);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label11);
      ((Control) this.headerPanel4).Controls.Add((Control) this.btnUpdate);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label10);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxRedemptionAmount);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.btnRelease);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxRedemptionDate);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label13);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxInterest);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label8);
      ((Control) this.headerPanel4).Controls.Add((Control) this.label9);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.GradientEnd = Color.Azure;
      this.headerPanel4.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel4).Location = new Point(382, 8);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(610, 442);
      ((Control) this.headerPanel4).TabIndex = 120;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.headerPanel4).Paint += new PaintEventHandler(this.headerPanel4_Paint);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.Azure;
      this.headerPanel3.CaptionEndColor = Color.SkyBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "ENTER BANK BILLNUMBER";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxBankBillNumber);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(13, 8);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(362, 52);
      ((Control) this.headerPanel3).TabIndex = 98;
      this.headerPanel3.TextAntialias = true;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.Azure;
      this.headerPanel1.CaptionEndColor = Color.SkyBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "PLEDGE DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.dataGridView1);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(14, 63);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(362, 176);
      ((Control) this.headerPanel1).TabIndex = 33;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.Azure;
      this.headerPanel2.CaptionEndColor = Color.SkyBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "BANK DETAILS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBankCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBankName);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBranch);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(13, 244);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(363, 204);
      ((Control) this.headerPanel2).TabIndex = 97;
      this.headerPanel2.TextAntialias = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.label19);
      this.Controls.Add((Control) this.tbxLedgerCodeInterest);
      this.Controls.Add((Control) this.tbxVoucherCodeInterest);
      this.Controls.Add((Control) this.tbxVoucherNameInterest);
      this.Controls.Add((Control) this.tbxLedgerTypeInterest);
      this.Controls.Add((Control) this.tbxVoucherName);
      this.Controls.Add((Control) this.tbxLedgerType);
      this.Controls.Add((Control) this.tbxLedgerCode);
      this.Controls.Add((Control) this.tbxVoucherCode);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormBankRedemption);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormBankRedemption);
      this.Load += new EventHandler(this.FormBankRedemption_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
