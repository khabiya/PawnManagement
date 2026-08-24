
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormBankPledgee : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LightBlueFadeDown.jpg");
    private string PLEDGEOREDIT = "";
    private string oldValues;
    private string newValues;
    private string oldValuesPledgeBillNumber = "";
    private string newValuesPledgeBillNumber = "";
    private int escapecount = 0;
    private List<string> lstBankBillNumber = new List<string>();
    private IContainer components = (IContainer) null;
    private ComboBox cbBankCode;
    private Label label13;
    private TextBox tbxBankBillDate;
    private TextBox tbxAmount;
    private TextBox tbxInterestRate;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox tbxSerialNumber;
    private TextBox tbxBranch;
    private TextBox tbxPledgeBillNumber;
    private TextBox tbxBankBillNumber;
    private TextBox tbxBankName;
    private DataGridView dataGridView2;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ComboBox cbInterestType;
    private Label label6;
    private TextBox tbxLedgerCode;
    private TextBox tbxVoucherCode;
    private TextBox tbxLedgerType;
    private TextBox tbxVoucherName;
    private TextBox tbxLedgerCodeInterest;
    private TextBox tbxVoucherCodeInterest;
    private TextBox tbxVoucherNameInterest;
    private TextBox tbxLedgerTypeInterest;
    private Label label11;
    private Label label12;
    private Label label14;
    private Label label15;
    private Label label10;
    private Label label16;
    private Label label17;
    private Label label18;
    private Panel panel1;
    private Panel panel2;
    private GlassButton btnUpdate;
    private GlassButton btnExit;
    private GlassButton btnAddEdit;
    private Panel panel4;
    private Panel panel3;
    private Label lblHeading;
    private Panel panel5;
    private DataGridViewTextBoxColumn colSerialNumber;
    private DataGridViewTextBoxColumn colBankBillNumber;
    private DataGridViewTextBoxColumn colPledgeBillNumber;
    private DataGridViewTextBoxColumn colCustomerName;
    private DataGridViewTextBoxColumn colShopCode;
    private GlassButton btnUndoRedemption;

    public FormBankPledgee() => this.InitializeComponent();

    public FormBankPledgee(string pledgeOrEdit)
    {
      this.PLEDGEOREDIT = pledgeOrEdit;
      this.InitializeComponent();
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.Yellow;
      textBox.ForeColor = Color.Black;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.Black;
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

    private string StrGetMaxSerialNumber()
    {
      try
      {
        string strError = "";
        string my_querry = "select max(SerialNumber) as SerialNumber from tblBankPledge";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getmaxserialnumber", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving maxSerialNumber" + strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0][0] != null && dataTable2.Rows[0][0].ToString() != "" ? (dataTable2.Rows[0].Field<int>("SerialNumber") + 1).ToString() : "1";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.getmaxserialnumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private void getMaxSerialNumber()
    {
      try
      {
        string strError = "";
        string my_querry = "select max(SerialNumber) as SerialNumber from tblBankPledge";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getmaxserialnumber", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving maxSerialNumber" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0][0] != null && dataTable2.Rows[0][0].ToString() != "")
          this.tbxSerialNumber.Text = (dataTable2.Rows[0].Field<int>("SerialNumber") + 1).ToString();
        else
          this.tbxSerialNumber.Text = "1";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.getmaxserialnumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getBankCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where Active = 1 and type = 'BANK'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getbankCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving BankPledge" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.cbBankCode.Items.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.cbBankCode.Items.Add((object) row.Field<string>("BankCode"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.getBankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        ++this.escapecount;
      if (this.escapecount > 2)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormBankPledgee_Load(object sender, EventArgs e)
    {
      try
      {
        this.getBankCode();
        if (this.cbBankCode.Items.Count > 0)
        {
          if (this.cbBankCode.Items.Count > 0)
            this.cbBankCode.SelectedIndex = 0;
          this.cbBankCode.Focus();
          if (this.cbInterestType.Items.Count > 0)
            this.cbInterestType.SelectedIndex = 0;
          if (this.PLEDGEOREDIT == "pledge")
          {
            this.lblHeading.Text = "PLEDGE";
            this.tbxBankBillDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            this.getMaxSerialNumber();
            ((Control) this.btnAddEdit).Visible = true;
            ((Control) this.btnUpdate).Visible = false;
            ((Control) this.btnUndoRedemption).Visible = false;
          }
          else if (this.PLEDGEOREDIT == "PledgeEdit")
          {
            this.getlstBankBillNumber();
            this.tbxBankBillNumber.AutoCompleteCustomSource.AddRange(this.lstBankBillNumber.ToArray());
            this.lblHeading.Text = "PLEDGE EDIT";
            this.tbxBankBillNumber.Select();
            ((Control) this.btnAddEdit).Visible = false;
            ((Control) this.btnUndoRedemption).Visible = false;
            ((Control) this.btnUpdate).Visible = true;
          }
          else if (this.PLEDGEOREDIT == "oldpledge")
          {
            ((Control) this.btnAddEdit).Visible = true;
            ((Control) this.btnUpdate).Visible = false;
            ((Control) this.btnUndoRedemption).Visible = false;
            this.tbxSerialNumber.ReadOnly = false;
          }
          else if (this.PLEDGEOREDIT == "UndoRedemption")
          {
            ((Control) this.btnAddEdit).Visible = false;
            ((Control) this.btnUpdate).Visible = false;
            this.tbxSerialNumber.Enabled = false;
            this.cbBankCode.Enabled = false;
            this.tbxBankBillDate.Enabled = false;
            this.cbInterestType.Enabled = false;
            this.tbxPledgeBillNumber.Enabled = false;
            this.dataGridView1.Enabled = false;
            this.dataGridView2.Enabled = false;
            this.tbxInterestRate.Enabled = false;
            this.tbxAmount.Enabled = false;
            ((Control) this.btnUndoRedemption).Visible = true;
            this.tbxSerialNumber.ReadOnly = true;
            this.tbxBankBillNumber.Select();
            this.lstBankBillNumber = BankPledgeClass.getListOfAllReleasedBankBillNumbers();
            this.tbxBankBillNumber.AutoCompleteCustomSource.AddRange(this.lstBankBillNumber.ToArray());
          }
        }
        else
        {
          ((Control) this.btnAddEdit).Visible = false;
          ((Control) this.btnUpdate).Visible = false;
          int num = (int) MessageBox.Show("Create Bank Master Entry before proceeding");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankpledge.formbankpledge_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where BankCode = @BankCode ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BankCode", (object) this.cbBankCode.Text.ToString()));
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
          this.getLedgerCodeLedgerCodeInterestVoucherCodeVoucherCodeInterest();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerCodeLedgerCodeInterestVoucherCodeVoucherCodeInterest()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblVoucherMaster where VoucherCode = @VoucherCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("VoucherCode", (object) this.tbxVoucherCode.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherName.Text = dataTable2.Rows[0]["vouchername"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        string my_querry = "select * from tblVoucherMaster where VoucherCode = @VoucherCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("VoucherCode", (object) this.tbxVoucherCodeInterest.Text.Trim().ToString()));
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest" + strError);
        }
        else if (dataTable4 != null && dataTable4.Rows.Count > 0)
          this.tbxVoucherNameInterest.Text = dataTable4.Rows[0]["vouchername"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()));
        DataTable dataTable5 = new DataTable();
        DataTable dataTable6 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest" + strError);
        }
        else if (dataTable6 != null && dataTable6.Rows.Count > 0)
          this.tbxLedgerType.Text = dataTable6.Rows[0]["ledgertype"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCodeInterest.Text.Trim().ToString()));
        DataTable dataTable7 = new DataTable();
        DataTable dataTable8 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form bank pledge.getLedgerCodeLedgercodeinterestvouchercodevvouchercodeinterest" + strError);
        }
        else if (dataTable8 != null && dataTable8.Rows.Count > 0)
          this.tbxLedgerTypeInterest.Text = dataTable8.Rows[0]["ledgertype"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form bank pledge.combobox1selectedindexchangedOUter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxBankBillDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void tbxBankBillDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate((sender as TextBox).Text.ToString()))
        return;
      (sender as TextBox).Select();
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

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxSerialNumber.Text != "" & this.tbxBankName.Text != "" & this.tbxBranch.Text != "" & this.tbxPledgeBillNumber.Text != "" & this.tbxBankBillNumber.Text != "" & this.tbxBankBillDate.Text != "" & this.tbxAmount.Text != "" & this.tbxInterestRate.Text != "" & this.dataGridView1.Rows.Count > 0)
        {
          if (DialogResult.Yes != MessageBox.Show("Are you sure??", "ADD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            return;
          if (!this.checkifSerialNumberTaken())
          {
            this.addBankPledge();
            this.saveBankPledgePledgeBillNumbers();
            if (this.getRokadAutoEntrySettings())
            {
              if (this.PLEDGEOREDIT == "oldpledge")
              {
                if (DialogResult.Yes == MessageBox.Show("Add to Rokad???", "Add to Rokad???", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                  this.InsertIntotblVouchers();
              }
              else
                this.InsertIntotblVouchers();
            }
            string ActionDetails = "New Bank pledge " + this.tbxBankBillNumber.Text.Trim().ToString();
            string Newvalues = "Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
            string username = FormMain.username;
            DateTime dateTime = DateTime.Now;
            string PerformedOn = dateTime.ToString();
            PawnManagementClass.InsertIntoHistory("BANK PLEDGE NEW", ActionDetails, "", Newvalues, username, PerformedOn);
            this.tbxSerialNumber.Text = "";
            this.tbxPledgeBillNumber.Text = "";
            this.tbxBankBillNumber.Text = "";
            this.tbxBankBillDate.Text = "";
            this.tbxAmount.Text = "";
            this.tbxInterestRate.Text = "";
            this.clearDatagridView();
            this.getMaxSerialNumber();
            this.cbBankCode.Focus();
            TextBox tbxBankBillDate = this.tbxBankBillDate;
            dateTime = DateTime.Today;
            string str = dateTime.ToString("dd/MM/yyyy");
            tbxBankBillDate.Text = str;
            if (this.cbBankCode.Items.Count > 0)
              this.cbBankCode.SelectedIndex = 0;
          }
          else
          {
            this.tbxSerialNumber.Select();
            int num = (int) MessageBox.Show("Serial number already taken.");
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Enter all the data");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkifSerialNumberTaken()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblbankpledge where serialnumber = @serialnumber";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("serialnumber", (object) this.tbxSerialNumber.Text)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bankpledgee.checkifserialnumbertaken()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show(strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form BankPledge.checkifserialnumbertaken()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return false;
    }

    private void addBankPledge()
    {
      try
      {
        string strError = "";
        if (SQLHelper.RunCommand("insert into tblBankPledge(SerialNumber,BankCode,Bankname,Branch,BankBillNumber,BankBillDate,Amount,InterestRate,InterestType,Released,Active,CreatedBy,PledgeBillNumbers) values (@SerialNumber,@BankCode,@Bankname,@Branch,@BankBillNumber,@BankBillDate,@Amount,@InterestRate,@InterestType,@Released,@Active,@CreatedBy,@PledgeBillNumbers)", new List<OleDbParameter>()
        {
          new OleDbParameter("SerialNumber", (object) this.tbxSerialNumber.Text.ToString()),
          new OleDbParameter("BankCode", (object) this.cbBankCode.Text.ToString()),
          new OleDbParameter("BankName", (object) this.tbxBankName.Text.ToString()),
          new OleDbParameter("Branch", (object) this.tbxBranch.Text.ToString()),
          new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()),
          new OleDbParameter("BankBilDate", (object) this.tbxBankBillDate.Text.Trim().ToString()),
          new OleDbParameter("Amount", (object) this.tbxAmount.Text.Trim().ToString()),
          new OleDbParameter("InterestRate", (object) this.tbxInterestRate.Text.Trim().ToString()),
          new OleDbParameter("InterestType", (object) this.cbInterestType.Text.Trim().ToString()),
          new OleDbParameter("Released", (object) "N"),
          new OleDbParameter("Active", (object) "1"),
          new OleDbParameter("CreatedBy", (object) FormMain.username),
          new OleDbParameter("PledgeBillNumbers", (object) this.getPledgeBillNumbers())
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.addbankPledge", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in Adding BankPledge" + strError);
        }
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
          this.addInPledgeTable(row.Cells["colPledgeBillNumber"].Value.ToString(), row.Cells["colShopCode"].Value.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.addbankpledge outer", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void InsertIntotblVouchers()
    {
      try
      {
        if (this.tbxVoucherCode.Text.Trim().ToString() != "" && this.tbxLedgerCode.Text.Trim().ToString() != "")
        {
          string s = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
          string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
          PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s), maxOfVoucherNumber, this.tbxVoucherCode.Text.Trim().ToString(), this.tbxVoucherName.Text.Trim().ToString(), this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString(), this.tbxLedgerCode.Text.Trim().ToString(), "JAMMA", double.Parse(this.tbxAmount.Text.Trim()));
        }
        else
        {
          int num = (int) MessageBox.Show("Rokad entry not done due to some error..please check");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Bankpledge.insertIntoTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getVoucherName(string voucherCode)
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
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherName.Text = dataTable2.Rows[0]["VoucherName"].ToString();
        else
          this.tbxVoucherName.Text = "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form LinkBankCodeAndVoucherCode.getvouchername(string vouchercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getPledgeBillNumbers()
    {
      string pledgeBillNumbers = "";
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (pledgeBillNumbers != "")
          pledgeBillNumbers += "  ";
        pledgeBillNumbers = pledgeBillNumbers + "[" + row.Cells["colShopCode"].Value.ToString() + " " + row.Cells["colPledgeBillNumber"].Value.ToString() + " " + row.Cells["colCustomerName"].Value.ToString() + "]";
      }
      return pledgeBillNumbers;
    }

    private void addInPledgeTable(string BillNumber, string ShopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode, BankSerialNumber = @BankSerialNumber  where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BankCode", (object) this.cbBankCode.Text.Trim().ToString()),
        new OleDbParameter("BankSerialNumber", (object) this.tbxSerialNumber.Text.Trim().ToString()),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void saveBankPledgePledgeBillNumbers()
    {
      try
      {
        for (int index = 0; index < this.dataGridView1.RowCount; ++index)
        {
          this.addBankPledgePledgeBillNumbers(this.dataGridView1.Rows[index].Cells[0].Value.ToString(), this.dataGridView1.Rows[index].Cells[1].Value.ToString(), this.dataGridView1.Rows[index].Cells[2].Value.ToString(), this.dataGridView1.Rows[index].Cells[3].Value.ToString(), this.dataGridView1.Rows[index].Cells[4].Value.ToString());
          this.newValuesPledgeBillNumber = this.newValuesPledgeBillNumber + "\n" + this.dataGridView1.Rows[index].Cells[2].Value.ToString() + " " + this.dataGridView1.Rows[index].Cells[3].Value.ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.saveBankPledgePledgeBillNumbers", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void clearDatagridView()
    {
      try
      {
        int count = this.dataGridView1.Rows.Count;
        for (int index = 0; index < count; ++index)
          this.dataGridView1.Rows.RemoveAt(0);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankpledge.cleardatagridview", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addBankPledgePledgeBillNumbers(
      string serialNumber,
      string bankBillNumber,
      string pledgeBillNumber,
      string customerName,
      string shopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblBankPledgePledgeBills(ShopCode,SerialNumber,BankBillNumber,PledgeBillNumber,CustomerName) values (@ShopCode,@SerialNumber,@BankBillNumber,@PledgeBillNumber,@CustomerName)", new List<OleDbParameter>()
      {
        new OleDbParameter("ShopCode", (object) shopCode),
        new OleDbParameter("SerialNumber", (object) serialNumber),
        new OleDbParameter("BankBillNumber", (object) bankBillNumber),
        new OleDbParameter("PledgeBillNumber", (object) pledgeBillNumber),
        new OleDbParameter("CustomerName", (object) customerName)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addBankPledgePledgeBillNumbers", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding BankPledgePledgeArticle" + strError);
    }

    private void tbxPledgeBillNumber_TextChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxBankBillNumber.Text != "")
        {
          if (this.tbxAmount.Text != "")
          {
            if (this.tbxInterestRate.Text != "")
            {
              string strError = "";
              string my_querry = "select  ShopCode,BillNumber,BillDate,Amount,NetWeight,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3 from tblPledge where (BillNumber like @BillNumber) and (BankCode is null or BankCode ='')  and (Redeemed = 'N')";
              List<OleDbParameter> parameters = new List<OleDbParameter>();
              parameters.Add(new OleDbParameter("BillNumber", (object) (this.tbxPledgeBillNumber.Text.Trim().ToString() + "%")));
              DataTable dataTable1 = new DataTable();
              DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
              dataTable2.Rows.Add();
              dataTable2.Rows[dataTable2.Rows.Count - 1]["bILLnUMBER"] = (object) "OWN";
              dataTable2.Rows[dataTable2.Rows.Count - 1]["customerName"] = (object) "OWN";
              if (strError != "")
              {
                PawnManagementClass.InsertIntoException("form bank pledge.tbxPledgebillnumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
                int num = (int) MessageBox.Show("Error in retrieving the pledge details" + strError);
              }
              else
              {
                this.dataGridView2.Visible = true;
                this.dataGridView2.DataSource = (object) dataTable2;
                this.dataGridView2.ClearSelection();
              }
              if (!(this.tbxPledgeBillNumber.Text == ""))
                return;
              this.dataGridView2.Visible = false;
            }
            else
              this.tbxInterestRate.Select();
          }
          else
            this.tbxAmount.Select();
        }
        else
          this.tbxBankBillNumber.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge txbpledgeBillNumber_textChanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkPledgeAlreadyAddedOrNot(string pledgeBillNumber)
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["colPledgeBillNumber"].Value.ToString().Equals(pledgeBillNumber))
          return true;
      }
      return false;
    }

    private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Return)
        {
          if (this.tbxBankBillNumber.Text.Trim() != "")
          {
            if (!this.checkPledgeAlreadyAddedOrNot(this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString()))
              this.dataGridView1.Rows.Add((object) this.tbxSerialNumber.Text.Trim().ToString(), (object) this.tbxBankBillNumber.Text.Trim().ToString(), (object) this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString(), (object) this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["CustomerName"].Value.ToString(), (object) this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString());
            this.tbxPledgeBillNumber.Select();
            this.dataGridView2.Visible = false;
          }
          else
          {
            this.tbxBankBillNumber.Focus();
            this.tbxBankBillNumber.Select();
          }
        }
        if (e.KeyCode == Keys.Escape)
        {
          this.escapecount = 0;
          this.dataGridView2.Visible = false;
          if (this.PLEDGEOREDIT == "pledge")
            ((Control) this.btnAddEdit).Focus();
        }
        if (e.KeyCode != Keys.Up || !this.dataGridView2.Rows[0].Selected)
          return;
        this.tbxPledgeBillNumber.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.datagridvview2_keydown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void tbxPledgeBillNumber_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void tbxSerialNumber_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.PLEDGEOREDIT != "UndoRedemption")
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else if (e.KeyCode == Keys.Return)
        ((Control) this.btnUndoRedemption).Select();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (FormMain.memberid == "1")
        {
          int index = -1;
          if (this.dataGridView1 != null & this.dataGridView1.Rows.Count > 0)
            index = this.dataGridView1.CurrentCell.RowIndex;
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) && index >= 0)
            this.dataGridView1.Rows.RemoveAt(index);
          this.dataGridView1.Refresh();
        }
        else
        {
          int num = (int) MessageBox.Show("Sorry, failed to delete... Try again");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.deletetoolstripmenuItemClicked", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void getPledgeNumberAndCustomerName()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankPledgePledgeBills where BankBillNumber = @BankBillNumber";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form bank pledge.getpledgenumberandcustomername", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
        }
        if (!(this.tbxBankBillNumber.Text.Trim() != ""))
          return;
        int rowCount = this.dataGridView1.RowCount;
        for (int index = 0; index < rowCount; ++index)
          this.dataGridView1.Rows.RemoveAt(0);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          this.dataGridView1.Rows.Add((object) row.Field<string>("SerialNumber").ToString(), (object) row.Field<string>("BankBillNumber"), (object) row.Field<string>("PledgeBillNumber").ToString(), (object) row.Field<string>("CustomerName").ToString(), (object) row["ShopCode"].ToString());
          this.oldValuesPledgeBillNumber = this.oldValuesPledgeBillNumber + "\n" + row.Field<string>("PledgeBillNumber").ToString() + " " + row.Field<string>("CustomerName").ToString() + " " + row["ShopCode"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.getpledgenumberandcustomername outer", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
        PawnManagementClass.InsertIntoException("frombankpledge.checkBankBillNumberReleaseOrNot", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void tbxBankBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (this.PLEDGEOREDIT == "PledgeEdit")
        {
          if (BankPledgeClass.checkIfBankBillNumberExists(this.tbxBankBillNumber.Text))
          {
            if (this.checkBankBillNumberReleasedOrNot())
            {
              this.getPledgeDetailsForThisPledge(this.tbxBankBillNumber.Text);
            }
            else
            {
              int num1 = (int) MessageBox.Show("Bill Number allready released");
            }
          }
          else
          {
            int num2 = (int) MessageBox.Show("Invalid Bank Bill Number");
            this.tbxBankBillNumber.Select();
          }
        }
        else if (this.PLEDGEOREDIT == "pledge" | this.PLEDGEOREDIT == "oldpledge")
        {
          if (!BankPledgeClass.checkIfBankBillNumberExists(this.tbxBankBillNumber.Text.Trim()))
            return;
          this.tbxBankBillNumber.Select();
        }
        else
        {
          if (!(this.PLEDGEOREDIT == "UndoRedemption"))
            return;
          if (BankPledgeClass.checkIfBankBillNumberExists(this.tbxBankBillNumber.Text))
          {
            if (!this.checkBankBillNumberReleasedOrNot())
            {
              this.getPledgeDetailsForThisPledge(this.tbxBankBillNumber.Text);
            }
            else
            {
              int num3 = (int) MessageBox.Show("Enter Valid BillNumber");
            }
          }
          else
            this.tbxBankBillNumber.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank pledge.bankBillNumber_Validating", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getPledgeDetailsForThisPledge(string BankBillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form bank pledge.tbxBankBillNumber_Validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
      {
        this.tbxSerialNumber.Text = dataTable2.Rows[0].Field<int>("SerialNumber").ToString();
        this.cbBankCode.Text = dataTable2.Rows[0].Field<string>("BankCode").ToString();
        this.tbxBankName.Text = dataTable2.Rows[0].Field<string>("Bankname").ToString();
        this.tbxBranch.Text = dataTable2.Rows[0].Field<string>("Branch").ToString();
        this.tbxBankBillDate.Text = dataTable2.Rows[0].Field<DateTime>("BankBillDate").ToString("dd/MM/yyyy");
        this.tbxAmount.Text = dataTable2.Rows[0].Field<string>("Amount").ToString();
        this.tbxInterestRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
        this.oldValues = "Old Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
      }
      this.getPledgeNumberAndCustomerName();
    }

    private void editBankPledge()
    {
      try
      {
        string strError = "";
        if (!(SQLHelper.RunCommand("Update tblBankPledge set BankCode=@BankCode,Bankname=@Bankname,Branch=@Branch,BankBillNumber=@BankBillNumber,BankBillDate=@BankBillDate,Amount=@Amount,InterestRate=@InterestRate,InterestType = @InterestType,PledgeBillNumbers = @PledgeBillNumbers where SerialNumber=@SerialNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("BankCode", (object) this.cbBankCode.Text.ToString()),
          new OleDbParameter("BankName", (object) this.tbxBankName.Text.ToString()),
          new OleDbParameter("Branch", (object) this.tbxBranch.Text.ToString()),
          new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()),
          new OleDbParameter("BankBillDate", (object) this.tbxBankBillDate.Text.Trim().ToString()),
          new OleDbParameter("Amount", (object) this.tbxAmount.Text.Trim().ToString()),
          new OleDbParameter("InterestRate", (object) this.tbxInterestRate.Text.Trim().ToString()),
          new OleDbParameter("InterestType", (object) this.cbInterestType.Text.Trim().ToString()),
          new OleDbParameter("PledgeBillNumbers", (object) this.getPledgeBillNumbers()),
          new OleDbParameter("SerialNumber", (object) this.tbxSerialNumber.Text.ToString())
        }, ref strError) != "Done"))
          return;
        PawnManagementClass.InsertIntoException("form bannk pledge.editBankPledege inner", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in editing BankPledge" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Bank Pledge.editBankPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void deleteBankCodeFromPledgeTable(string BankSerialNumber)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode where BankSerialNumber=@BankSerialNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("BankCode", (object) ""),
        new OleDbParameter(nameof (BankSerialNumber), (object) BankSerialNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.deleteBankCodeFromPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void tbxAmount_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxInterestRate_TextChanged(object sender, EventArgs e)
    {
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxSerialNumber.Text != "" & this.tbxBankName.Text != "" & this.tbxBranch.Text != "" & this.tbxBankBillNumber.Text != "" & this.tbxBankBillDate.Text != "" & this.tbxAmount.Text != "" & this.tbxInterestRate.Text != "" & this.dataGridView1.Rows.Count > 0)
        {
          if (DialogResult.Yes != MessageBox.Show("Are you sure??", "EDIT", MessageBoxButtons.YesNo))
            return;
          DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString());
          if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
          {
            voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
            if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
            {
              this.newValues = "New Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
              this.editBankPledge();
              BankPledgePledgeBillsClass.deleteBankPledgeArticles(this.tbxBankBillNumber.Text.Trim());
              this.deleteBankCodeFromPledgeTable(this.tbxSerialNumber.Text.Trim().ToString());
              this.saveBankPledgePledgeBillNumbers();
              if (this.getRokadAutoEntrySettings())
                this.UpdateTableVouchers();
              foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
                this.addInPledgeTable(row.Cells["colPledgeBillNumber"].Value.ToString(), row.Cells["colShopCode"].Value.ToString());
              PawnManagementClass.InsertIntoHistory("BANK PLEDGE EDIT", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
              this.reset();
              this.Close();
            }
            else if (DialogResult.Yes == MessageBox.Show("Rokad finished for this date...Do you still want to continue.......Are you sure??", "EDIT", MessageBoxButtons.YesNo))
            {
              this.newValues = "New Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
              this.editBankPledge();
              BankPledgePledgeBillsClass.deleteBankPledgeArticles(this.tbxBankBillNumber.Text.Trim());
              this.deleteBankCodeFromPledgeTable(this.tbxSerialNumber.Text.Trim().ToString());
              this.saveBankPledgePledgeBillNumbers();
              foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
                this.addInPledgeTable(row.Cells["colPledgeBillNumber"].Value.ToString(), row.Cells["colShopCode"].Value.ToString());
              PawnManagementClass.InsertIntoHistory("BANK PLEDGE EDIT", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
              this.reset();
              this.Close();
            }
          }
          else
          {
            this.newValues = "New Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
            this.editBankPledge();
            BankPledgePledgeBillsClass.deleteBankPledgeArticles(this.tbxBankBillNumber.Text.Trim());
            this.deleteBankCodeFromPledgeTable(this.tbxSerialNumber.Text.Trim().ToString());
            this.saveBankPledgePledgeBillNumbers();
            foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
              this.addInPledgeTable(row.Cells["colPledgeBillNumber"].Value.ToString(), row.Cells["colShopCode"].Value.ToString());
            PawnManagementClass.InsertIntoHistory("BANK PLEDGE EDIT", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
            this.reset();
            this.Close();
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Enter all the data");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void reset()
    {
      this.tbxSerialNumber.Text = "";
      this.tbxBankName.Text = "";
      this.tbxBranch.Text = "";
      this.tbxPledgeBillNumber.Text = "";
      this.tbxBankBillNumber.Text = "";
      this.tbxBankBillDate.Text = "";
      this.tbxAmount.Text = "";
      this.tbxInterestRate.Text = "";
      this.clearDatagridView();
    }

    private void UpdateTableVouchers()
    {
      try
      {
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString());
        string voucherNumber = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        string str = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(str))
        {
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str), voucherNumber, this.tbxVoucherCode.Text.Trim().ToString(), this.tbxVoucherName.Text.Trim().ToString(), this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString(), this.tbxLedgerCode.Text.Trim().ToString(), "JAMMA", double.Parse(this.tbxAmount.Text.Trim()));
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

    private void FormBankPledgee_Shown(object sender, EventArgs e)
    {
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Exit", "Are You Sure", MessageBoxButtons.YesNo))
        return;
      this.Close();
    }

    private void tbxLedgerType_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxSerialNumber.Text.Trim() != ""))
        return;
      if (this.PLEDGEOREDIT == "pledge" | this.PLEDGEOREDIT == "oldpledge")
      {
        if (this.checkifSerialNumberTaken())
          this.tbxSerialNumber.BackColor = Color.Red;
        else
          this.tbxSerialNumber.BackColor = Color.Yellow;
      }
      else if (this.PLEDGEOREDIT == "PledgeEdit")
      {
        if (this.checkifSerialNumberTaken())
          this.tbxSerialNumber.BackColor = Color.Yellow;
        else
          this.tbxSerialNumber.BackColor = Color.Red;
      }
    }

    private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void panel5_Paint(object sender, PaintEventArgs e)
    {
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void tbxBankBillNumber_TextChanged(object sender, EventArgs e)
    {
      if (this.PLEDGEOREDIT == "pledge" | this.PLEDGEOREDIT == "oldpledge")
      {
        if (this.checkIfBankBillNumberExists())
          this.tbxBankBillNumber.BackColor = Color.Red;
        else
          this.tbxBankBillNumber.BackColor = Color.Yellow;
      }
      else
      {
        if (!(this.PLEDGEOREDIT == "PledgeEdit"))
          return;
        if (this.checkIfBankBillNumberExists())
          this.tbxBankBillNumber.BackColor = Color.Yellow;
        else
          this.tbxBankBillNumber.BackColor = Color.Red;
      }
    }

    private bool checkIfBankBillNumberExists()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankBillNumber = @BankBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankBillNumber", (object) this.tbxBankBillNumber.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form bank pledge.tbxBankBillNumber_Validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the serial number from  BankPledge" + strError);
        return false;
      }
      return dataTable2 != null & dataTable2.Rows.Count > 0;
    }

    private void tbxSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
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
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "Pledge Bill Number")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ColPledgeBillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["COLShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "Pledge Bill Number" | this.dataGridView1.Columns[e.ColumnIndex].Name == "customercode" | this.dataGridView1.Columns[e.ColumnIndex].Name == "billnumber")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
    }

    private void btnUndoRedemption_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxSerialNumber.Text != "" & this.tbxBankName.Text != "" & this.tbxBranch.Text != "" & this.tbxBankBillNumber.Text != "" & this.tbxBankBillDate.Text != "" & this.tbxAmount.Text != "" & this.tbxInterestRate.Text != "" & this.dataGridView1.Rows.Count > 0)
        {
          if (DialogResult.Yes != MessageBox.Show("Are you sure??", "UNDO REDEMPTION", MessageBoxButtons.YesNo))
            return;
          DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxSerialNumber.Text.Trim().ToString() + "," + this.tbxBankBillNumber.Text.Trim().ToString() + " Release");
          if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
          {
            voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
            if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
            {
              BankPledgeClass.undoRedemption(this.tbxBankBillNumber.Text);
              if (this.getRokadAutoEntrySettings())
                VoucherClass.deleteFromVouchersTableBasedOnBankSerialNumberAndBankBillNumber(this.tbxSerialNumber.Text, this.tbxBankBillNumber.Text);
              PawnManagementClass.InsertIntoHistory("BANK UNDO REDEMPTION", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
              this.reset();
              this.Close();
            }
            else if (DialogResult.Yes == MessageBox.Show("Rokad finished for this date...Do you still want to continue.......Are you sure??", "EDIT", MessageBoxButtons.YesNo))
            {
              this.newValues = "New Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
              BankPledgeClass.undoRedemption(this.tbxBankBillNumber.Text);
              PawnManagementClass.InsertIntoHistory("BANK UNDO REDEMPTION", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
              this.reset();
              this.Close();
            }
          }
          else
          {
            this.newValues = "New Values are Serial Number =" + this.tbxSerialNumber.Text.Trim().ToString() + " , \n Bank Code =" + this.cbBankCode.Text.Trim().ToString() + " ,\n Bank Name = " + this.tbxBankName.Text.Trim().ToString() + ",\n Branch =" + this.tbxBranch.Text.Trim().ToString() + " ,\n bankBillDate= " + this.tbxBankBillDate.Text.Trim().ToString() + ",\n Amount= " + this.tbxAmount.Text.Trim().ToString() + ",\n InterestRate=" + this.tbxInterestRate.Text.Trim().ToString();
            BankPledgeClass.undoRedemption(this.tbxBankBillNumber.Text);
            PawnManagementClass.InsertIntoHistory("BANK UNDO REDEMPTION", " Bank Bill Number" + this.tbxBankBillNumber.Text.Trim().ToString() + "edited", this.oldValues + this.oldValuesPledgeBillNumber, this.newValues + this.newValuesPledgeBillNumber, FormMain.username, DateTime.Now.ToString());
            this.reset();
            this.Close();
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Enter all the data");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxBankBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.PLEDGEOREDIT != "UndoRedemption")
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else if (e.KeyCode == Keys.Return)
        ((Control) this.btnUndoRedemption).Select();
    }

    private void tbxBankBillDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.PLEDGEOREDIT != "UndoRedemption")
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else if (e.KeyCode == Keys.Return)
        ((Control) this.btnUndoRedemption).Select();
    }

    private void tbxAmount_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.PLEDGEOREDIT != "UndoRedemption")
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else if (e.KeyCode == Keys.Return)
        ((Control) this.btnUndoRedemption).Select();
    }

    private void tbxInterestRate_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.PLEDGEOREDIT != "UndoRedemption")
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else if (e.KeyCode == Keys.Return)
        ((Control) this.btnUndoRedemption).Select();
    }

    private void cbInterestType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbxSerialNumber_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.PLEDGEOREDIT == "oldpledge"))
        return;
      if (this.tbxSerialNumber.Text.Trim() == "")
        this.tbxSerialNumber.Select();
      else if (this.checkifSerialNumberTaken())
        this.tbxSerialNumber.Select();
    }

    private void tbxPledgeBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return && this.dataGridView1.Rows.Count > 0)
      {
        if (this.PLEDGEOREDIT == "pledge" | this.PLEDGEOREDIT == "oldpledge")
        {
          if (((Control) this.btnAddEdit).Visible)
            ((Control) this.btnAddEdit).Focus();
          this.dataGridView2.Visible = false;
        }
        else if (this.PLEDGEOREDIT == "PledgeEdit")
        {
          ((Control) this.btnUpdate).Focus();
          this.dataGridView2.Visible = false;
        }
      }
      if (e.KeyCode != Keys.Down || !(this.dataGridView2 != null & this.dataGridView2.Rows.Count > 0))
        return;
      this.dataGridView2.Rows[0].Selected = true;
      this.dataGridView2.Focus();
      this.dataGridView2.Select();
    }

    private void tbxPledgeBillNumber_Validating(object sender, CancelEventArgs e)
    {
    }

    private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.cbBankCode = new ComboBox();
      this.label13 = new Label();
      this.tbxBankBillDate = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.tbxSerialNumber = new TextBox();
      this.tbxBranch = new TextBox();
      this.tbxPledgeBillNumber = new TextBox();
      this.tbxBankBillNumber = new TextBox();
      this.tbxBankName = new TextBox();
      this.dataGridView2 = new DataGridView();
      this.dataGridView1 = new DataGridView();
      this.colSerialNumber = new DataGridViewTextBoxColumn();
      this.colBankBillNumber = new DataGridViewTextBoxColumn();
      this.colPledgeBillNumber = new DataGridViewTextBoxColumn();
      this.colCustomerName = new DataGridViewTextBoxColumn();
      this.colShopCode = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.cbInterestType = new ComboBox();
      this.label6 = new Label();
      this.tbxLedgerCode = new TextBox();
      this.tbxVoucherCode = new TextBox();
      this.tbxLedgerType = new TextBox();
      this.tbxVoucherName = new TextBox();
      this.tbxLedgerCodeInterest = new TextBox();
      this.tbxVoucherCodeInterest = new TextBox();
      this.tbxVoucherNameInterest = new TextBox();
      this.tbxLedgerTypeInterest = new TextBox();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label10 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.btnUpdate = new GlassButton();
      this.btnExit = new GlassButton();
      this.btnAddEdit = new GlassButton();
      this.panel4 = new Panel();
      this.panel5 = new Panel();
      this.lblHeading = new Label();
      this.panel3 = new Panel();
      this.btnUndoRedemption = new GlassButton();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.cbBankCode.BackColor = SystemColors.InactiveBorder;
      this.cbBankCode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbBankCode.FlatStyle = FlatStyle.Popup;
      this.cbBankCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbBankCode.FormattingEnabled = true;
      this.cbBankCode.Location = new Point(140, 51);
      this.cbBankCode.Name = "cbBankCode";
      this.cbBankCode.Size = new Size(339, 28);
      this.cbBankCode.TabIndex = 1;
      this.cbBankCode.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.cbBankCode.KeyDown += new KeyEventHandler(this.tbxBankBillDate_KeyDown);
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(35, 186);
      this.label13.Name = "label13";
      this.label13.Size = new Size(96, 16);
      this.label13.TabIndex = 75;
      this.label13.Text = "Interest Rate";
      this.tbxBankBillDate.BackColor = SystemColors.InactiveBorder;
      this.tbxBankBillDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankBillDate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBankBillDate.Location = new Point(140, 117);
      this.tbxBankBillDate.Name = "tbxBankBillDate";
      this.tbxBankBillDate.Size = new Size(339, 26);
      this.tbxBankBillDate.TabIndex = 5;
      this.tbxBankBillDate.Enter += new EventHandler(this.textBox_Enter);
      this.tbxBankBillDate.KeyDown += new KeyEventHandler(this.tbxBankBillDate_KeyDown);
      this.tbxBankBillDate.KeyPress += new KeyPressEventHandler(this.tbxBankBillDate_KeyPress);
      this.tbxBankBillDate.Leave += new EventHandler(this.textBox_Leave);
      this.tbxBankBillDate.Validating += new CancelEventHandler(this.tbxBankBillDate_Validating);
      this.tbxAmount.BackColor = SystemColors.InactiveBorder;
      this.tbxAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(140, 149);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(339, 26);
      this.tbxAmount.TabIndex = 6;
      this.tbxAmount.TextChanged += new EventHandler(this.tbxAmount_TextChanged);
      this.tbxAmount.Enter += new EventHandler(this.textBox_Enter);
      this.tbxAmount.KeyDown += new KeyEventHandler(this.tbxAmount_KeyDown);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
      this.tbxAmount.Leave += new EventHandler(this.textBox_Leave);
      this.tbxInterestRate.BackColor = SystemColors.InactiveBorder;
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(140, 181);
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(339, 26);
      this.tbxInterestRate.TabIndex = 7;
      this.tbxInterestRate.TextChanged += new EventHandler(this.tbxInterestRate_TextChanged);
      this.tbxInterestRate.Enter += new EventHandler(this.textBox_Enter);
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxInterestRate_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxInterest_KeyPress);
      this.tbxInterestRate.Leave += new EventHandler(this.textBox_Leave);
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(72, 154);
      this.label9.Name = "label9";
      this.label9.Size = new Size(59, 16);
      this.label9.TabIndex = 71;
      this.label9.Text = "Amount";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(33, 123);
      this.label8.Name = "label8";
      this.label8.Size = new Size(98, 16);
      this.label8.TabIndex = 70;
      this.label8.Text = "BankBillDate";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(4, 91);
      this.label7.Name = "label7";
      this.label7.Size = new Size((int) sbyte.MaxValue, 16);
      this.label7.TabIndex = 69;
      this.label7.Text = "Bank Bill Number";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(23, 251);
      this.label5.Name = "label5";
      this.label5.Size = new Size(108, 16);
      this.label5.TabIndex = 67;
      this.label5.Text = "Pledge Bill No";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(84, 56);
      this.label4.Name = "label4";
      this.label4.Size = new Size(56, 16);
      this.label4.TabIndex = 66;
      this.label4.Text = "Branch";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(50, 27);
      this.label3.Name = "label3";
      this.label3.Size = new Size(88, 16);
      this.label3.TabIndex = 65;
      this.label3.Text = "Bank Name";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(47, 56);
      this.label2.Name = "label2";
      this.label2.Size = new Size(84, 16);
      this.label2.TabIndex = 64;
      this.label2.Text = "Bank Code";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(24, 23);
      this.label1.Name = "label1";
      this.label1.Size = new Size(107, 16);
      this.label1.TabIndex = 63;
      this.label1.Text = "Serial Number";
      this.tbxSerialNumber.BackColor = SystemColors.InactiveBorder;
      this.tbxSerialNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSerialNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSerialNumber.Location = new Point(140, 19);
      this.tbxSerialNumber.Name = "tbxSerialNumber";
      this.tbxSerialNumber.ReadOnly = true;
      this.tbxSerialNumber.Size = new Size(339, 26);
      this.tbxSerialNumber.TabIndex = 0;
      this.tbxSerialNumber.TextChanged += new EventHandler(this.tbxSerialNumber_TextChanged);
      this.tbxSerialNumber.Enter += new EventHandler(this.textBox_Enter);
      this.tbxSerialNumber.KeyDown += new KeyEventHandler(this.tbxBankBillDate_KeyDown);
      this.tbxSerialNumber.KeyPress += new KeyPressEventHandler(this.tbxSerialNumber_KeyPress);
      this.tbxSerialNumber.Leave += new EventHandler(this.textBox_Leave);
      this.tbxSerialNumber.Validating += new CancelEventHandler(this.tbxSerialNumber_Validating);
      this.tbxBranch.BackColor = SystemColors.InactiveBorder;
      this.tbxBranch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBranch.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBranch.Location = new Point(144, 53);
      this.tbxBranch.Name = "tbxBranch";
      this.tbxBranch.ReadOnly = true;
      this.tbxBranch.Size = new Size(293, 26);
      this.tbxBranch.TabIndex = 3;
      this.tbxBranch.Enter += new EventHandler(this.textBox_Enter);
      this.tbxBranch.KeyUp += new KeyEventHandler(this.tbxSerialNumber_KeyUp);
      this.tbxBranch.Leave += new EventHandler(this.textBox_Leave);
      this.tbxPledgeBillNumber.BackColor = SystemColors.InactiveBorder;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeBillNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.Location = new Point(140, 247);
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.Size = new Size(339, 26);
      this.tbxPledgeBillNumber.TabIndex = 9;
      this.tbxPledgeBillNumber.TextChanged += new EventHandler(this.tbxPledgeBillNumber_TextChanged);
      this.tbxPledgeBillNumber.Enter += new EventHandler(this.textBox_Enter);
      this.tbxPledgeBillNumber.KeyDown += new KeyEventHandler(this.tbxPledgeBillNumber_KeyDown);
      this.tbxPledgeBillNumber.KeyPress += new KeyPressEventHandler(this.tbxPledgeBillNumber_KeyPress);
      this.tbxPledgeBillNumber.KeyUp += new KeyEventHandler(this.tbxPledgeBillNumber_KeyUp);
      this.tbxPledgeBillNumber.Leave += new EventHandler(this.textBox_Leave);
      this.tbxPledgeBillNumber.Validating += new CancelEventHandler(this.tbxPledgeBillNumber_Validating);
      this.tbxBankBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxBankBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBankBillNumber.BackColor = SystemColors.InactiveBorder;
      this.tbxBankBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankBillNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBankBillNumber.Location = new Point(140, 85);
      this.tbxBankBillNumber.Name = "tbxBankBillNumber";
      this.tbxBankBillNumber.Size = new Size(339, 26);
      this.tbxBankBillNumber.TabIndex = 4;
      this.tbxBankBillNumber.TextChanged += new EventHandler(this.tbxBankBillNumber_TextChanged);
      this.tbxBankBillNumber.Enter += new EventHandler(this.textBox_Enter);
      this.tbxBankBillNumber.KeyDown += new KeyEventHandler(this.tbxBankBillNumber_KeyDown);
      this.tbxBankBillNumber.Leave += new EventHandler(this.textBox_Leave);
      this.tbxBankBillNumber.Validating += new CancelEventHandler(this.tbxBankBillNumber_Validating);
      this.tbxBankName.BackColor = SystemColors.InactiveBorder;
      this.tbxBankName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBankName.Location = new Point(144, 24);
      this.tbxBankName.Name = "tbxBankName";
      this.tbxBankName.ReadOnly = true;
      this.tbxBankName.Size = new Size(293, 26);
      this.tbxBankName.TabIndex = 2;
      this.tbxBankName.Enter += new EventHandler(this.textBox_Enter);
      this.tbxBankName.KeyUp += new KeyEventHandler(this.tbxSerialNumber_KeyUp);
      this.tbxBankName.Leave += new EventHandler(this.textBox_Leave);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(7, 281);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(451, 192);
      this.dataGridView2.TabIndex = 79;
      this.dataGridView2.Visible = false;
      this.dataGridView2.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
      this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
      this.dataGridView2.KeyDown += new KeyEventHandler(this.dataGridView2_KeyDown);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colSerialNumber, (DataGridViewColumn) this.colBankBillNumber, (DataGridViewColumn) this.colPledgeBillNumber, (DataGridViewColumn) this.colCustomerName, (DataGridViewColumn) this.colShopCode);
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(7, 290);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(472, 183);
      this.dataGridView1.TabIndex = 80;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView3_CellPainting);
      this.colSerialNumber.HeaderText = "Serial Number";
      this.colSerialNumber.Name = "colSerialNumber";
      this.colSerialNumber.ReadOnly = true;
      this.colSerialNumber.Visible = false;
      this.colBankBillNumber.HeaderText = "Bank Bill Number";
      this.colBankBillNumber.Name = "colBankBillNumber";
      this.colBankBillNumber.ReadOnly = true;
      this.colBankBillNumber.Visible = false;
      this.colPledgeBillNumber.HeaderText = "Pledge Bill Number";
      this.colPledgeBillNumber.Name = "colPledgeBillNumber";
      this.colPledgeBillNumber.ReadOnly = true;
      this.colCustomerName.HeaderText = "Customer Name";
      this.colCustomerName.Name = "colCustomerName";
      this.colCustomerName.ReadOnly = true;
      this.colShopCode.HeaderText = "ShopCode";
      this.colShopCode.Name = "colShopCode";
      this.colShopCode.ReadOnly = true;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deleteToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(108, 26);
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new Size(107, 22);
      this.deleteToolStripMenuItem.Text = "&Delete";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.cbInterestType.BackColor = SystemColors.InactiveBorder;
      this.cbInterestType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbInterestType.FlatStyle = FlatStyle.Popup;
      this.cbInterestType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbInterestType.FormattingEnabled = true;
      this.cbInterestType.Items.AddRange(new object[3]
      {
        (object) "SIMPLE INTEREST",
        (object) "COMPOUND INTEREST YEARLY",
        (object) "COMPOUND INTEREST MONTHLY"
      });
      this.cbInterestType.Location = new Point(140, 213);
      this.cbInterestType.Name = "cbInterestType";
      this.cbInterestType.Size = new Size(339, 28);
      this.cbInterestType.TabIndex = 8;
      this.cbInterestType.KeyDown += new KeyEventHandler(this.cbInterestType_KeyDown);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(32, 219);
      this.label6.Name = "label6";
      this.label6.Size = new Size(99, 16);
      this.label6.TabIndex = 84;
      this.label6.Text = "Interest Type";
      this.tbxLedgerCode.BackColor = SystemColors.InactiveBorder;
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(144, 256);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.Size = new Size(293, 26);
      this.tbxLedgerCode.TabIndex = 86;
      this.tbxLedgerCode.Enter += new EventHandler(this.textBox_Enter);
      this.tbxLedgerCode.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerCode.Leave += new EventHandler(this.textBox_Leave);
      this.tbxVoucherCode.BackColor = SystemColors.InactiveBorder;
      this.tbxVoucherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(144, 198);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.Size = new Size(293, 26);
      this.tbxVoucherCode.TabIndex = 88;
      this.tbxVoucherCode.Enter += new EventHandler(this.textBox_Enter);
      this.tbxVoucherCode.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherCode.Leave += new EventHandler(this.textBox_Leave);
      this.tbxLedgerType.BackColor = SystemColors.InactiveBorder;
      this.tbxLedgerType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerType.Location = new Point(144, 285);
      this.tbxLedgerType.Name = "tbxLedgerType";
      this.tbxLedgerType.Size = new Size(293, 26);
      this.tbxLedgerType.TabIndex = 89;
      this.tbxLedgerType.Enter += new EventHandler(this.textBox_Enter);
      this.tbxLedgerType.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerType.Leave += new EventHandler(this.textBox_Leave);
      this.tbxVoucherName.BackColor = SystemColors.InactiveBorder;
      this.tbxVoucherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherName.Location = new Point(144, 227);
      this.tbxVoucherName.Name = "tbxVoucherName";
      this.tbxVoucherName.Size = new Size(293, 26);
      this.tbxVoucherName.TabIndex = 90;
      this.tbxVoucherName.Enter += new EventHandler(this.textBox_Enter);
      this.tbxVoucherName.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherName.Leave += new EventHandler(this.textBox_Leave);
      this.tbxLedgerCodeInterest.BackColor = SystemColors.InactiveBorder;
      this.tbxLedgerCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCodeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCodeInterest.Location = new Point(144, 140);
      this.tbxLedgerCodeInterest.Name = "tbxLedgerCodeInterest";
      this.tbxLedgerCodeInterest.Size = new Size(293, 26);
      this.tbxLedgerCodeInterest.TabIndex = 94;
      this.tbxLedgerCodeInterest.Enter += new EventHandler(this.textBox_Enter);
      this.tbxLedgerCodeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerCodeInterest.Leave += new EventHandler(this.textBox_Leave);
      this.tbxVoucherCodeInterest.BackColor = SystemColors.InactiveBorder;
      this.tbxVoucherCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCodeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCodeInterest.Location = new Point(144, 82);
      this.tbxVoucherCodeInterest.Name = "tbxVoucherCodeInterest";
      this.tbxVoucherCodeInterest.Size = new Size(293, 26);
      this.tbxVoucherCodeInterest.TabIndex = 93;
      this.tbxVoucherCodeInterest.Enter += new EventHandler(this.textBox_Enter);
      this.tbxVoucherCodeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherCodeInterest.Leave += new EventHandler(this.textBox_Leave);
      this.tbxVoucherNameInterest.BackColor = SystemColors.InactiveBorder;
      this.tbxVoucherNameInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNameInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNameInterest.Location = new Point(144, 111);
      this.tbxVoucherNameInterest.Name = "tbxVoucherNameInterest";
      this.tbxVoucherNameInterest.Size = new Size(293, 26);
      this.tbxVoucherNameInterest.TabIndex = 91;
      this.tbxVoucherNameInterest.Enter += new EventHandler(this.textBox_Enter);
      this.tbxVoucherNameInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherNameInterest.Leave += new EventHandler(this.textBox_Leave);
      this.tbxLedgerTypeInterest.BackColor = SystemColors.InactiveBorder;
      this.tbxLedgerTypeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInterest.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInterest.Location = new Point(144, 169);
      this.tbxLedgerTypeInterest.Name = "tbxLedgerTypeInterest";
      this.tbxLedgerTypeInterest.Size = new Size(293, 26);
      this.tbxLedgerTypeInterest.TabIndex = 92;
      this.tbxLedgerTypeInterest.Enter += new EventHandler(this.textBox_Enter);
      this.tbxLedgerTypeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerTypeInterest.Leave += new EventHandler(this.textBox_Leave);
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(22, 174);
      this.label11.Name = "label11";
      this.label11.Size = new Size(117, 16);
      this.label11.TabIndex = 98;
      this.label11.Text = "Ledger Type Int";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(19, 145);
      this.label12.Name = "label12";
      this.label12.Size = new Size(118, 16);
      this.label12.TabIndex = 97;
      this.label12.Text = "Ledger Code Int";
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(8, 116);
      this.label14.Name = "label14";
      this.label14.Size = new Size(130, 16);
      this.label14.TabIndex = 96;
      this.label14.Text = "Voucher Name Int";
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(11, 87);
      this.label15.Name = "label15";
      this.label15.Size = new Size(126, 16);
      this.label15.TabIndex = 95;
      this.label15.Text = "Voucher Code Int";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(42, 288);
      this.label10.Name = "label10";
      this.label10.Size = new Size(97, 16);
      this.label10.TabIndex = 102;
      this.label10.Text = "Ledger Type";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Transparent;
      this.label16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(39, 259);
      this.label16.Name = "label16";
      this.label16.Size = new Size(98, 16);
      this.label16.TabIndex = 101;
      this.label16.Text = "Ledger Code";
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Transparent;
      this.label17.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(28, 230);
      this.label17.Name = "label17";
      this.label17.Size = new Size(110, 16);
      this.label17.TabIndex = 100;
      this.label17.Text = "Voucher Name";
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(31, 201);
      this.label18.Name = "label18";
      this.label18.Size = new Size(106, 16);
      this.label18.TabIndex = 99;
      this.label18.Text = "Voucher Code";
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackColor = Color.Transparent;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.tbxPledgeBillNumber);
      this.panel1.Controls.Add((Control) this.dataGridView2);
      this.panel1.Controls.Add((Control) this.cbInterestType);
      this.panel1.Controls.Add((Control) this.dataGridView1);
      this.panel1.Controls.Add((Control) this.tbxBankBillNumber);
      this.panel1.Controls.Add((Control) this.cbBankCode);
      this.panel1.Controls.Add((Control) this.tbxSerialNumber);
      this.panel1.Controls.Add((Control) this.label13);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.tbxBankBillDate);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.tbxAmount);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.tbxInterestRate);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label8);
      this.panel1.Location = new Point(12, 52);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(504, 488);
      this.panel1.TabIndex = 105;
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label10);
      this.panel2.Controls.Add((Control) this.label16);
      this.panel2.Controls.Add((Control) this.label17);
      this.panel2.Controls.Add((Control) this.label18);
      this.panel2.Controls.Add((Control) this.tbxLedgerCodeInterest);
      this.panel2.Controls.Add((Control) this.label11);
      this.panel2.Controls.Add((Control) this.tbxVoucherCodeInterest);
      this.panel2.Controls.Add((Control) this.label12);
      this.panel2.Controls.Add((Control) this.tbxVoucherNameInterest);
      this.panel2.Controls.Add((Control) this.label14);
      this.panel2.Controls.Add((Control) this.tbxLedgerTypeInterest);
      this.panel2.Controls.Add((Control) this.label15);
      this.panel2.Controls.Add((Control) this.tbxVoucherName);
      this.panel2.Controls.Add((Control) this.tbxLedgerType);
      this.panel2.Controls.Add((Control) this.tbxLedgerCode);
      this.panel2.Controls.Add((Control) this.tbxVoucherCode);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.tbxBranch);
      this.panel2.Controls.Add((Control) this.tbxBankName);
      this.panel2.Location = new Point(510, 52);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(461, 429);
      this.panel2.TabIndex = 106;
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.btnUpdate.BackColor = Color.LightBlue;
      this.btnUpdate.FadeOnFocus = true;
      ((Control) this.btnUpdate).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUpdate.ForeColor = Color.MediumBlue;
      this.btnUpdate.ForeColorOnFocus = Color.Red;
      this.btnUpdate.ForeColorOnLeave = Color.RoyalBlue;
      this.btnUpdate.GlowColor = Color.White;
      ((ButtonBase) this.btnUpdate).Image = (Image) Resources.reset;
      this.btnUpdate.InnerBorderColor = Color.Transparent;
      ((Control) this.btnUpdate).Location = new Point(34, 16);
      ((Control) this.btnUpdate).Name = "btnUpdate";
      this.btnUpdate.OuterBorderColor = Color.MediumSlateBlue;
      this.btnUpdate.ShineColor = Color.Transparent;
      ((Control) this.btnUpdate).Size = new Size(393, 60);
      ((Control) this.btnUpdate).TabIndex = 82;
      ((Control) this.btnUpdate).Text = "&UPDATE";
      ((ButtonBase) this.btnUpdate).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnUpdate).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnUpdate).Click += new EventHandler(this.btnUpdate_Click);
      this.btnExit.BackColor = Color.LightBlue;
      this.btnExit.FadeOnFocus = true;
      ((Control) this.btnExit).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnExit.ForeColor = Color.MediumBlue;
      this.btnExit.ForeColorOnFocus = Color.Red;
      this.btnExit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnExit.GlowColor = Color.White;
      ((ButtonBase) this.btnExit).Image = (Image) Resources.EXIT;
      this.btnExit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnExit).Location = new Point(34, 82);
      ((Control) this.btnExit).Name = "btnExit";
      this.btnExit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnExit.ShineColor = Color.Transparent;
      ((Control) this.btnExit).Size = new Size(402, 60);
      ((Control) this.btnExit).TabIndex = 103;
      ((Control) this.btnExit).Text = "&EXIT";
      ((ButtonBase) this.btnExit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnExit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnExit).Click += new EventHandler(this.button1_Click_1);
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(34, 16);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(402, 60);
      ((Control) this.btnAddEdit).TabIndex = 10;
      ((Control) this.btnAddEdit).Text = "&PLEDGE SAVE";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.panel4.Anchor = AnchorStyles.None;
      this.panel4.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel4.Controls.Add((Control) this.panel5);
      this.panel4.Controls.Add((Control) this.panel1);
      this.panel4.Controls.Add((Control) this.panel3);
      this.panel4.Controls.Add((Control) this.panel2);
      this.panel4.Location = new Point(20, 46);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(984, 560);
      this.panel4.TabIndex = 107;
      this.panel5.Anchor = AnchorStyles.None;
      this.panel5.BackColor = Color.DarkGray;
      this.panel5.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.lblHeading);
      this.panel5.Location = new Point(12, 11);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(959, 41);
      this.panel5.TabIndex = 108;
      this.lblHeading.Anchor = AnchorStyles.None;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(421, 5);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(191, 29);
      this.lblHeading.TabIndex = 103;
      this.lblHeading.Text = "BANK PLEDGE";
      this.panel3.BackColor = Color.Transparent;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnUndoRedemption);
      this.panel3.Controls.Add((Control) this.btnUpdate);
      this.panel3.Controls.Add((Control) this.btnExit);
      this.panel3.Controls.Add((Control) this.btnAddEdit);
      this.panel3.Location = new Point(510, 383);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(461, 157);
      this.panel3.TabIndex = 107;
      this.btnUndoRedemption.BackColor = Color.LightBlue;
      this.btnUndoRedemption.FadeOnFocus = true;
      ((Control) this.btnUndoRedemption).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnUndoRedemption.ForeColor = Color.MediumBlue;
      this.btnUndoRedemption.ForeColorOnFocus = Color.Red;
      this.btnUndoRedemption.ForeColorOnLeave = Color.RoyalBlue;
      this.btnUndoRedemption.GlowColor = Color.White;
      ((ButtonBase) this.btnUndoRedemption).Image = (Image) Resources.reset;
      this.btnUndoRedemption.InnerBorderColor = Color.Transparent;
      ((Control) this.btnUndoRedemption).Location = new Point(42, 16);
      ((Control) this.btnUndoRedemption).Name = "btnUndoRedemption";
      this.btnUndoRedemption.OuterBorderColor = Color.MediumSlateBlue;
      this.btnUndoRedemption.ShineColor = Color.Transparent;
      ((Control) this.btnUndoRedemption).Size = new Size(393, 60);
      ((Control) this.btnUndoRedemption).TabIndex = 104;
      ((Control) this.btnUndoRedemption).Text = "&UNDO REDEMPTION";
      ((ButtonBase) this.btnUndoRedemption).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnUndoRedemption).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnUndoRedemption).Click += new EventHandler(this.btnUndoRedemption_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.MenuBar;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1024, 650);
      this.Controls.Add((Control) this.panel4);
      this.ForeColor = Color.DarkBlue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormBankPledgee);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormBankPledgee);
      this.Load += new EventHandler(this.FormBankPledgee_Load);
      this.Shown += new EventHandler(this.FormBankPledgee_Shown);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
