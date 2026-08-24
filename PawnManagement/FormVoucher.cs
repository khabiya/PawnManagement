
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
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
  public class FormVoucher : Form
  {
    private string formType = "";
    private string voucherNumber = "";
    private string ledgerCode = "";
    private string jammaNovae = "";
    private string keyPreview = "";
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private IContainer components = (IContainer) null;
    private ComboBox cbLedgerType;
    private ComboBox cbVoucherName;
    private GlassButton btnAddEdit;
    private TextBox textBox1;
    private Label label1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private Panel panel1;
    private HeaderPanel headerPanel3;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton7;
    private GlassButton glassButton8;
    private TextBox tbxAmount;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private TextBox tbxVoucherDescription;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxLedgerTypeInHindi;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxVoucherDate;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxVoucherNumber;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton19;
    private GlassButton glassButton20;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton15;
    private GlassButton glassButton18;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private TextBox tbxVoucherCode;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton16;
    private GlassButton glassButton17;
    private ComboBox cbJammaOrNovae;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton9;
    private GlassButton glassButton12;
    private TextBox tbxLedgerCode;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;

    public FormVoucher(string FORMTYPE, string VOUCHERNUMBER)
    {
      this.InitializeComponent();
      this.formType = FORMTYPE;
      this.voucherNumber = VOUCHERNUMBER;
    }

    public FormVoucher(
      string FORMTYPE,
      string VOUCHERNUMBER,
      string LEDGERCODE,
      string JAMMAORNOVAE)
    {
      this.InitializeComponent();
      this.formType = FORMTYPE;
      this.voucherNumber = VOUCHERNUMBER;
      this.ledgerCode = LEDGERCODE;
      this.jammaNovae = JAMMAORNOVAE;
    }

    private void refreshGrid()
    {
      try
      {
        string strError = "";
        string my_querry = "select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi,t3.jammaornovae from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.jammaornovae,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1') as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Vocher.refreshGrid()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Vocher.refreshGrid()" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.dataGridView1.DataSource = (object) dataTable2;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Voucher.refreshGrid()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getVoucherDetails(string voucherNumber)
    {
      try
      {
        string strError = "";
        string my_querry = "select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi,t3.jammaornovae from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.jammaornovae,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1' and vouchernumber = @voucherNumber) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (voucherNumber), (object) voucherNumber));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Vocher.gettblVoucherDetails", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Vocher.gettblVoucherDetails" + strError);
        }
        else
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            this.dataGridView1.DataSource = (object) dataTable2;
          try
          {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
              this.tbxVoucherDate.Text = DateTime.Parse(this.dataGridView1.Rows[0].Cells["voucherdate"].Value.ToString()).ToString("dd/MM/yyyy");
              this.tbxVoucherNumber.Text = this.dataGridView1.Rows[0].Cells[nameof (voucherNumber)].Value.ToString();
              this.cbJammaOrNovae.Text = this.dataGridView1.Rows[0].Cells["jammaornovae"].Value.ToString();
              this.cbLedgerType.Text = this.dataGridView1.Rows[0].Cells["ledgertype"].Value.ToString();
              this.cbVoucherName.Text = this.dataGridView1.Rows[0].Cells["voucherName"].Value.ToString();
              this.tbxVoucherCode.Text = this.dataGridView1.Rows[0].Cells["voucherCode"].Value.ToString();
              this.tbxVoucherDescription.Text = this.dataGridView1.Rows[0].Cells["voucherDescription"].Value.ToString();
              this.tbxLedgerCode.Text = this.dataGridView1.Rows[0].Cells["LedgerCode"].Value.ToString();
              this.tbxLedgerTypeInHindi.Text = this.dataGridView1.Rows[0].Cells["LedgerTypeInHindi"].Value.ToString();
              this.tbxAmount.Text = this.dataGridView1.Rows[0].Cells["Amount"].Value.ToString();
              ((Control) this.btnAddEdit).Text = "UPDATE";
            }
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form voucher.getvoucherDetails 2 ", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getvoucherDetails 3", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerType(string ledgerCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertype from tblLedgerr where ledgercode = @ledgercode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgercode", (object) ledgerCode)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucher.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form voucher.getLedgerType" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.cbLedgerType.Text = dataTable2.Rows[0]["ledgertype"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getLedgerType", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getLedgerTypee(string ledgerCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertype from tblLedgerr where ledgercode = @ledgercode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgercode", (object) ledgerCode)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucher.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form voucher.getLedgerType" + strError);
          return "";
        }
        return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["ledgertype"].ToString() : "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getLedgerType", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void populatecbVoucherName()
    {
      try
      {
        this.cbVoucherName.Items.Clear();
        DataTable voucherNames = VoucherMasterClass.getVoucherNames(this.tbxLedgerCode.Text);
        if (voucherNames == null || voucherNames.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) voucherNames.Rows)
          this.cbVoucherName.Items.Add((object) row["vouchername"].ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.gettblvouchername", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerType()
    {
      try
      {
        string strError = "";
        string my_querry = "select distinct(LedgerType),ledgercode,ledgertypeinhindi from tblLedgerr where jammaOrNovae in('" + this.cbJammaOrNovae.Text.Trim().ToString() + "','jammanovae')";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Voucher.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Voucher.getLedgerType" + strError);
        }
        else
        {
          this.cbLedgerType.Text = string.Empty;
          this.cbLedgerType.Items.Clear();
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              this.cbLedgerType.Items.Add((object) row["LedgerType"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getledgertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerTypeInHindi()
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertypeinhindi from tblLedgerr where ledgertype = @ledgertype";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgertype", (object) this.cbLedgerType.Text.Trim().ToString())
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form voucher.getLedgerTypeInHindi" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.tbxLedgerCode.Text = dataTable2.Rows[0]["ledgercode"].ToString();
          this.tbxLedgerTypeInHindi.Text = dataTable2.Rows[0]["ledgertypeinhindi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getMaxOfVoucherNumber()
    {
      string str = "";
      str = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
      this.tbxVoucherNumber.Text = VoucherClass.getMaxOfVoucherNumber();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormVoucher_Load(object sender, EventArgs e)
    {
      try
      {
        this.cbJammaOrNovae.Select();
        this.refreshGrid();
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView2);
        PawnManagementClass.formatButtonControl(ref this.btnAddEdit);
        if (this.dataGridView1.Rows.Count > 0)
          this.dataGridView1.Columns["Amount"].DefaultCellStyle.ForeColor = Color.Blue;
        if (this.formType == "EDITVOUCHER")
        {
          this.getVoucherDetails(this.voucherNumber);
          this.tbxVoucherDate.ReadOnly = false;
        }
        if (!(this.formType == "ADDVOUCHER"))
          return;
        if (PawnManagementClass.getRokadDate() != "")
          this.tbxVoucherDate.Text = DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
        else
          this.tbxVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.tbxVoucherNumber.Text = VoucherClass.getMaxOfVoucherNumber();
        ((Control) this.btnAddEdit).Text = "ADD";
        if (this.jammaNovae != "")
          this.cbJammaOrNovae.Text = this.jammaNovae;
        if (this.ledgerCode != "")
        {
          this.getLedgerType(this.ledgerCode);
          this.cbVoucherName.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.formvoucher_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public static DataTable getVoucherNumberAndDate(string VoucherDescription)
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

    private void selectNEXTControl(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void reset()
    {
      this.tbxVoucherDescription.Text = "";
      this.tbxAmount.Text = "";
    }

    private bool checkIfVoucherNameAndLedgerNameAndcodeMatch() => this.cbVoucherName.Text == this.getVoucherName(this.tbxVoucherCode.Text) && this.cbLedgerType.Text == this.getLedgerTypee(this.tbxLedgerCode.Text);

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
          return "";
        }
        return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["VoucherName"].ToString() : "";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form LinkBankCodeAndVoucherCode.getvouchername(string vouchercode)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      if (this.checkIfVoucherNameAndLedgerNameAndcodeMatch())
      {
        if (((Control) this.btnAddEdit).Text == "ADD")
        {
          if (this.tbxAmount.Text != "")
          {
            if (this.fieldsnotempty())
            {
              if (DateTime.Parse(PawnManagementClass.getRokadDate()).Equals(DateTime.Parse(this.tbxVoucherDate.Text.ToString())))
              {
                if (!this.checkIfVoucherNumberExists(this.tbxVoucherNumber.Text))
                {
                  if (DialogResult.Yes != MessageBox.Show("Are  you sure", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    return;
                  PawnManagementClass.insertIntotblVouchers(DateTime.Parse(this.tbxVoucherDate.Text.Trim().ToString()), this.tbxVoucherNumber.Text.Trim().ToString(), this.tbxVoucherCode.Text.Trim().ToString(), this.cbVoucherName.Text.Trim().ToString(), this.tbxVoucherDescription.Text.Trim().ToString(), this.tbxLedgerCode.Text.Trim().ToString(), this.cbJammaOrNovae.Text.ToString(), double.Parse(this.tbxAmount.Text.ToString()));
                  this.getMaxOfVoucherNumber();
                  this.reset();
                  this.tbxVoucherDate.Select();
                }
                else
                  this.getMaxOfVoucherNumber();
              }
              else
              {
                int num1 = (int) MessageBox.Show("Date cannot be changed");
              }
            }
            else
            {
              int num2 = (int) MessageBox.Show("Fields cannot be empty... Fill all the fields");
            }
          }
          else
            this.tbxAmount.Select();
        }
        else
        {
          if (!(((Control) this.btnAddEdit).Text == "UPDATE"))
            return;
          if (this.tbxAmount.Text != "")
          {
            if (this.fieldsnotempty())
            {
              if (!PawnManagementClass.checkIfRokadFinished(this.tbxVoucherDate.Text))
              {
                if (DialogResult.Yes == MessageBox.Show("Are  you sure", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                  PawnManagementClass.updatetblVouchers(DateTime.Parse(this.tbxVoucherDate.Text.Trim().ToString()), this.tbxVoucherNumber.Text.Trim().ToString(), this.tbxVoucherCode.Text.Trim().ToString(), this.cbVoucherName.Text.Trim().ToString(), this.tbxVoucherDescription.Text.Trim().ToString(), this.tbxLedgerCode.Text.Trim().ToString(), this.cbJammaOrNovae.Text.ToString(), double.Parse(this.tbxAmount.Text.ToString()));
                  this.getMaxOfVoucherNumber();
                  this.reset();
                  this.tbxVoucherDate.Select();
                  ((Control) this.btnAddEdit).Text = "ADD";
                }
              }
              else
              {
                int num3 = (int) MessageBox.Show("Rokad Already frinished for this date");
              }
            }
            else
            {
              int num4 = (int) MessageBox.Show("Fields cannot be empty... Fill all the fields");
            }
          }
          else
            this.tbxAmount.Select();
        }
      }
      else
      {
        int num5 = (int) MessageBox.Show("Please select the Ledger and voucher names again...");
      }
    }

    private bool checkIfVoucherNumberExists(string voucherNumber)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherNumber = @VoucherNumber ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("VoucherNumber", (object) voucherNumber));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form Vocher.cbvouchername_selectedIndexChanged" + strError);
        return false;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    private bool fieldsnotempty() => this.tbxVoucherDate.Text.Trim() != "" && this.tbxVoucherNumber.Text.Trim() != "" && this.cbLedgerType.Text.Trim() != "" && this.tbxVoucherCode.Text.Trim() != "" && this.cbVoucherName.Text.Trim() != "" && this.tbxAmount.Text.Trim() != "";

    private void tbxVoucherNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
        return;
      e.Handled = true;
    }

    private void tbxVoucherDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxVoucherDate.Text.ToString()))
        return;
      this.tbxVoucherDate.Select();
    }

    private void cbJammaOrNovae_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'J' | e.KeyChar == 'j')
      {
        this.cbJammaOrNovae.Text = "JAMMA";
        this.cbLedgerType.Select();
      }
      else if (e.KeyChar == 'N' | e.KeyChar == 'n')
      {
        this.cbJammaOrNovae.Text = "NOVAE";
        this.cbLedgerType.Select();
      }
      else
        e.Handled = true;
    }

    private void cbLedgerType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getLedgerTypeInHindi();
      this.populatecbVoucherName();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLedgerDetails().ShowDialog();
    }

    private void cbVoucherName_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select VoucherCode from tblVoucherMaster where VoucherName = @VoucherName and LedgerCode= @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("VoucherName", (object) this.cbVoucherName.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Vocher.cbvouchername_selectedIndexChanged" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherCode.Text = dataTable2.Rows[0]["VoucherCode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
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

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      int num = (int) new FormVoucherMaster().ShowDialog();
    }

    private void cbLedgerType_Validating(object sender, CancelEventArgs e)
    {
      string text = this.cbLedgerType.Text;
      if ((sender as ComboBox).Items.Count <= 0)
        return;
      if ((sender as ComboBox).Text.Trim() != "")
      {
        if (!(sender as ComboBox).Items.Contains((object) (sender as ComboBox).Text.Trim().ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          {
            string nextLedgerCode = LedgerMaster.getNextLedgerCode(this.cbLedgerType.Text.Trim());
            if (nextLedgerCode != "" && LedgerMaster.addLedgerDetails(nextLedgerCode, this.cbLedgerType.Text, "JAMMANOVAE", this.cbLedgerType.Text, "Y", FormMain.username, DateTime.Now) == "Done")
            {
              this.cbLedgerType.Items.Clear();
              this.getLedgerType();
              this.cbLedgerType.Text = text;
            }
          }
          else
            (sender as ComboBox).Select();
        }
      }
      else
        (sender as ComboBox).Select();
    }

    private void cbJammaOrNovae_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.cbLedgerType.Text = string.Empty;
      this.getLedgerType();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.textBox1.Text.Trim() != "")
        {
          string strError = "";
          string my_querry = "select * from(select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi,t3.jammaornovae from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.amount,t1.jammaornovae from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1') as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode ) as t5 where t5.voucherDate like @voucherDate or t5.vouchernumber like @voucherNumber or t5.vouchercode like @voucherCode or  t5.vouchername like @voucherName or t5.voucherdescription like @voucherDescription or t5.ledgercode like @ledgerCode or t5.ledgertypeinhindi like @ledgerTypeInHindi or t5.ledgertype like @ledgerType or t5.jammaornovae like @jammaOrNovae or t5.amount like @amount";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter("voucherDate", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("voucherNumber", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("voucherCode", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("voucherName", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("voucherDescription", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("ledgerCode", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("ledgerTypeInHindi", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("ledgerType", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("jammaOrNovae", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          parameters.Add(new OleDbParameter("amount", (object) ("%" + this.textBox1.Text.ToString() + "%")));
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            PawnManagementClass.InsertIntoException("form Vocher.textBox1_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("form Vocher.textBox1_TextChanged" + strError);
          }
          else
            this.dataGridView1.DataSource = dataTable2 == null || dataTable2.Rows.Count <= 0 ? (object) null : (object) dataTable2;
        }
        else
          this.dataGridView1.DataSource = (object) null;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.textBox1_TextChanged 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (DialogResult.Yes != MessageBox.Show("Are you sure", "EDIT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        DateTime dateTime = DateTime.Parse(this.dataGridView1.Rows[rowIndex].Cells["voucherDate"].Value.ToString());
        if (!PawnManagementClass.checkIfRokadFinished(dateTime.ToString("dd/MM/yyyy")))
        {
          TextBox tbxVoucherDate = this.tbxVoucherDate;
          dateTime = DateTime.Parse(this.dataGridView1.Rows[rowIndex].Cells["voucherdate"].Value.ToString());
          string str = dateTime.ToString("dd/MM/yyyy");
          tbxVoucherDate.Text = str;
          this.tbxVoucherNumber.Text = this.dataGridView1.Rows[rowIndex].Cells["voucherNumber"].Value.ToString();
          this.cbJammaOrNovae.Text = this.dataGridView1.Rows[rowIndex].Cells["jammaornovae"].Value.ToString();
          this.cbLedgerType.Text = this.dataGridView1.Rows[rowIndex].Cells["ledgertype"].Value.ToString();
          this.cbVoucherName.Text = this.dataGridView1.Rows[rowIndex].Cells["voucherName"].Value.ToString();
          this.tbxVoucherCode.Text = this.dataGridView1.Rows[rowIndex].Cells["voucherCode"].Value.ToString();
          this.tbxVoucherDescription.Text = this.dataGridView1.Rows[rowIndex].Cells["voucherDescription"].Value.ToString();
          this.tbxLedgerCode.Text = this.dataGridView1.Rows[rowIndex].Cells["LedgerCode"].Value.ToString();
          this.tbxLedgerTypeInHindi.Text = this.dataGridView1.Rows[rowIndex].Cells["LedgerTypeInHindi"].Value.ToString();
          this.tbxAmount.Text = this.dataGridView1.Rows[rowIndex].Cells["Amount"].Value.ToString();
          ((Control) this.btnAddEdit).Text = "UPDATE";
          this.tbxVoucherDate.ReadOnly = false;
        }
        else
        {
          int num = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Edited");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.editToolstripmenuItem_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Are you sure", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(this.dataGridView1.Rows[rowIndex].Cells["voucherDate"].Value.ToString()).ToString("dd/MM/yyyy")))
      {
        VoucherClass.DeleteVoucherNumber(this.dataGridView1.Rows[rowIndex].Cells["vouchernumber"].Value.ToString());
        this.refreshGrid();
      }
      else
      {
        int num = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void cbVoucherName_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbVoucherName.Items.Count > 0)
      {
        if (this.cbVoucherName.Text.Trim() != "")
        {
          if (!this.cbVoucherName.Items.Contains((object) this.cbVoucherName.Text.Trim().ToString()))
            this.requestToAddNewVoucherName();
          else
            this.dataGridView2.DataSource = (object) this.getVoucherReport(this.tbxLedgerCode.Text, this.tbxVoucherCode.Text);
        }
        else
          this.cbVoucherName.Select();
      }
      else
        this.requestToAddNewVoucherName();
    }

    private void requestToAddNewVoucherName()
    {
      if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
      {
        string nextVoucherCode = VoucherMasterClass.getNextVoucherCode(this.cbVoucherName.Text);
        if (nextVoucherCode != "")
          VoucherMasterClass.addvoucherMaster(nextVoucherCode, this.cbVoucherName.Text, this.tbxLedgerCode.Text, this.cbLedgerType.Text, DateTime.Now, FormMain.username);
        string text = this.cbVoucherName.Text;
        this.cbVoucherName.Items.Clear();
        this.populatecbVoucherName();
        this.cbVoucherName.Text = text;
      }
      else
        this.cbVoucherName.Select();
    }

    private DataTable getVoucherReport(string ledgerCode, string VoucherCode)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select t3.jamma,t3.novae,t3.voucherdate,t3.voucherdescription,t3.ledgercode,t4.ledgertype,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.transactiontime from (SELECT t1.ledgercode,t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription, IIf(t1.jammaornovae='jamma',t1.amount,'') AS jamma, IIf(t1.jammaornovae='novae',t1.amount,'') AS novae, format(t1.createdtime,'hh:mm:ss') AS TransactionTime FROM tblvouchers t1 left join tblvouchermaster t2 on t1.vouchercode = t2.vouchercode  where  t1.ledgercode = @ledgerCode  and  t1.vouchercode = @vouchercode and  active = '1' order by t1.createdon,t1.createdtime) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by t3.voucherDate", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ledgerCode), (object) ledgerCode),
        new OleDbParameter("vouchercode", (object) VoucherCode)
      }, ref strError);
      dataTable.Columns.Add("Balance", typeof (double));
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        dataTable.Rows.Add();
        dataTable.Rows[dataTable.Rows.Count - 1]["jamma"] = (object) "0";
        dataTable.Rows[dataTable.Rows.Count - 1]["novae"] = (object) "0";
      }
      return dataTable;
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

    private void cbJammaOrNovae_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbJammaOrNovae.Text == ""))
        return;
      this.cbJammaOrNovae.Select();
    }

    private void FormVoucher_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.keyPreview = e.KeyChar != '\b' ? this.keyPreview + e.KeyChar.ToString() : "";
      if (!(this.keyPreview == "udhrath" | this.keyPreview == "UDHRATH"))
        return;
      int num = (int) MessageBox.Show(" hello");
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "vouchers").ShowDialog();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxVoucherNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxVoucherDate.Select();
    }

    private void tbxVoucherDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbJammaOrNovae.Select();
    }

    private void cbJammaOrNovae_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbLedgerType.Select();
    }

    private void cbLedgerType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !(this.cbLedgerType.Text.Trim() != ""))
        return;
      this.cbVoucherName.Select();
    }

    private void cbVoucherName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxVoucherDescription.Select();
    }

    private void tbxVoucherDescription_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxAmount.Select();
    }

    private void tbxAmount_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddEdit).Focus();
    }

    private void tbxLedgerTypeInHindi_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void dataGridView2_DataSourceChanged(object sender, EventArgs e)
    {
      double num1 = 0.0;
      if (this.dataGridView2.Rows.Count <= 0)
        return;
      double num2 = 0.0;
      double num3 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView2.Rows)
      {
        if (row.Cells["jamma"].Value != null && PawnManagementClass.IsDigitsOnly(row.Cells["jamma"].Value.ToString()))
        {
          num2 += double.Parse(row.Cells["jamma"].Value.ToString());
          num1 += double.Parse(row.Cells["jamma"].Value.ToString());
        }
        if (row.Cells["novae"].Value != null && PawnManagementClass.IsDigitsOnly(row.Cells["novae"].Value.ToString()))
        {
          num3 += double.Parse(row.Cells["novae"].Value.ToString());
          num1 -= double.Parse(row.Cells["novae"].Value.ToString());
        }
        row.Cells["Balance"].Value = (object) num1;
      }
      this.dataGridView2.Rows[this.dataGridView2.Rows.Count - 1].Cells["jamma"].Value = (object) num2.ToString("F");
      this.dataGridView2.Rows[this.dataGridView2.Rows.Count - 1].Cells["novae"].Value = (object) num3.ToString("F");
      this.dataGridView2.Columns["Balance"].DisplayIndex = 2;
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
      this.cbLedgerType = new ComboBox();
      this.cbVoucherName = new ComboBox();
      this.btnAddEdit = new GlassButton();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.panel1 = new Panel();
      this.dataGridView2 = new DataGridView();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton19 = new GlassButton();
      this.glassButton20 = new GlassButton();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton15 = new GlassButton();
      this.glassButton18 = new GlassButton();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.tbxVoucherCode = new TextBox();
      this.headerPanel9 = new HeaderPanel();
      this.glassButton16 = new GlassButton();
      this.glassButton17 = new GlassButton();
      this.cbJammaOrNovae = new ComboBox();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tbxLedgerCode = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton7 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.tbxAmount = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxVoucherDescription = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxLedgerTypeInHindi = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxVoucherDate = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxVoucherNumber = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel9).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.cbLedgerType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLedgerType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLedgerType.BackColor = Color.AliceBlue;
      this.cbLedgerType.Dock = DockStyle.Fill;
      this.cbLedgerType.FlatStyle = FlatStyle.Popup;
      this.cbLedgerType.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType.ForeColor = Color.Blue;
      this.cbLedgerType.FormattingEnabled = true;
      this.cbLedgerType.Location = new Point(0, 0);
      this.cbLedgerType.Name = "cbLedgerType";
      this.cbLedgerType.Size = new Size(412, 23);
      this.cbLedgerType.TabIndex = 0;
      this.cbLedgerType.SelectedIndexChanged += new EventHandler(this.cbLedgerType_SelectedIndexChanged);
      this.cbLedgerType.KeyDown += new KeyEventHandler(this.cbLedgerType_KeyDown);
      this.cbLedgerType.Validating += new CancelEventHandler(this.cbLedgerType_Validating);
      this.cbVoucherName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbVoucherName.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbVoucherName.BackColor = Color.AliceBlue;
      this.cbVoucherName.Dock = DockStyle.Fill;
      this.cbVoucherName.FlatStyle = FlatStyle.Popup;
      this.cbVoucherName.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbVoucherName.FormattingEnabled = true;
      this.cbVoucherName.Location = new Point(0, 0);
      this.cbVoucherName.Name = "cbVoucherName";
      this.cbVoucherName.Size = new Size(414, 23);
      this.cbVoucherName.TabIndex = 0;
      this.cbVoucherName.SelectedIndexChanged += new EventHandler(this.cbVoucherName_SelectedIndexChanged);
      this.cbVoucherName.KeyDown += new KeyEventHandler(this.cbVoucherName_KeyDown);
      this.cbVoucherName.Validating += new CancelEventHandler(this.cbVoucherName_Validating);
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(375, 321);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(164, 51);
      ((Control) this.btnAddEdit).TabIndex = 8;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(158, 114);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(157, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(157, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(157, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(157, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(157, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(740, 604);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(265, 29);
      this.textBox1.TabIndex = 2;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(652, 602);
      this.label1.Name = "label1";
      this.label1.Size = new Size(82, 29);
      this.label1.TabIndex = 2;
      this.label1.Text = "Search";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.panel1.BackColor = Color.Transparent;
      this.panel1.Controls.Add((Control) this.dataGridView2);
      this.panel1.Controls.Add((Control) this.headerPanel11);
      this.panel1.Controls.Add((Control) this.headerPanel10);
      this.panel1.Controls.Add((Control) this.headerPanel8);
      this.panel1.Controls.Add((Control) this.headerPanel9);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.headerPanel5);
      this.panel1.Controls.Add((Control) this.headerPanel4);
      this.panel1.Controls.Add((Control) this.headerPanel2);
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.btnAddEdit);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1008, 378);
      this.panel1.TabIndex = 0;
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView2.Location = new Point(546, 3);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new Size(459, 371);
      this.dataGridView2.TabIndex = 11;
      this.dataGridView2.DataSourceChanged += new EventHandler(this.dataGridView2_DataSourceChanged);
      this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
      ((Control) this.headerPanel11).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel11).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.HotTrack;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel11.CaptionEndColor = Color.AliceBlue;
      this.headerPanel11.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "VOUCHER NAME";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel11).Controls.Add((Control) this.cbVoucherName);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = SystemColors.ControlLight;
      this.headerPanel11.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).Location = new Point(3, 215);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(416, 51);
      ((Control) this.headerPanel11).TabIndex = 5;
      this.headerPanel11.TextAntialias = true;
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
      ((Control) this.glassButton19).Location = new Point(113, 513);
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
      ((Control) this.glassButton20).Location = new Point(247, 512);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(123, 37);
      ((Control) this.glassButton20).TabIndex = 1;
      ((Control) this.glassButton20).Text = "&EXIT";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel10).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel10).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.HotTrack;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel10.CaptionEndColor = Color.AliceBlue;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "LEDGER TYPE";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel10).Controls.Add((Control) this.cbLedgerType);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = SystemColors.ControlLight;
      this.headerPanel10.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).Location = new Point(3, 108);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(414, 51);
      ((Control) this.headerPanel10).TabIndex = 3;
      this.headerPanel10.TextAntialias = true;
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
      ((Control) this.glassButton15).Location = new Point(113, 513);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(128, 35);
      ((Control) this.glassButton15).TabIndex = 0;
      ((Control) this.glassButton15).Text = "&SAVE";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(247, 512);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(123, 37);
      ((Control) this.glassButton18).TabIndex = 1;
      ((Control) this.glassButton18).Text = "&EXIT";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "VOUCHER CODE";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxVoucherCode);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(421, 215);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(119, 51);
      ((Control) this.headerPanel8).TabIndex = 10;
      this.headerPanel8.TextAntialias = true;
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
      ((Control) this.glassButton13).Location = new Point(-178, 513);
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
      ((Control) this.glassButton14).Location = new Point(-44, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 1;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxVoucherCode.BackColor = Color.AliceBlue;
      this.tbxVoucherCode.BorderStyle = BorderStyle.None;
      this.tbxVoucherCode.Dock = DockStyle.Fill;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(0, 0);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.Size = new Size(117, 24);
      this.tbxVoucherCode.TabIndex = 0;
      this.tbxVoucherCode.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel9).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel9).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.HotTrack;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel9.CaptionEndColor = Color.AliceBlue;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "JAMMA OR NOVAE";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbJammaOrNovae);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = SystemColors.ControlLight;
      this.headerPanel9.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).Location = new Point(3, 55);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(537, 51);
      ((Control) this.headerPanel9).TabIndex = 2;
      this.headerPanel9.TextAntialias = true;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      ((ButtonBase) this.glassButton16).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(238, 513);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(128, 35);
      ((Control) this.glassButton16).TabIndex = 0;
      ((Control) this.glassButton16).Text = "&SAVE";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(372, 512);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(123, 37);
      ((Control) this.glassButton17).TabIndex = 1;
      ((Control) this.glassButton17).Text = "&EXIT";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbJammaOrNovae.BackColor = Color.AliceBlue;
      this.cbJammaOrNovae.Dock = DockStyle.Fill;
      this.cbJammaOrNovae.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbJammaOrNovae.FlatStyle = FlatStyle.Popup;
      this.cbJammaOrNovae.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbJammaOrNovae.FormattingEnabled = true;
      this.cbJammaOrNovae.Items.AddRange(new object[2]
      {
        (object) "JAMMA",
        (object) "NOVAE"
      });
      this.cbJammaOrNovae.Location = new Point(0, 0);
      this.cbJammaOrNovae.Name = "cbJammaOrNovae";
      this.cbJammaOrNovae.Size = new Size(535, 24);
      this.cbJammaOrNovae.TabIndex = 0;
      this.cbJammaOrNovae.SelectedIndexChanged += new EventHandler(this.cbJammaOrNovae_SelectedIndexChanged);
      this.cbJammaOrNovae.KeyDown += new KeyEventHandler(this.cbJammaOrNovae_KeyDown);
      this.cbJammaOrNovae.KeyPress += new KeyPressEventHandler(this.cbJammaOrNovae_KeyPress);
      this.cbJammaOrNovae.Validating += new CancelEventHandler(this.cbJammaOrNovae_Validating);
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
      this.headerPanel7.CaptionText = "LEDGER CODE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxLedgerCode);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(421, 109);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(119, 51);
      ((Control) this.headerPanel7).TabIndex = 9;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton9).Location = new Point(-178, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 0;
      ((Control) this.glassButton9).Text = "&SAVE";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(-44, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxLedgerCode.BackColor = Color.AliceBlue;
      this.tbxLedgerCode.BorderStyle = BorderStyle.None;
      this.tbxLedgerCode.Dock = DockStyle.Fill;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(0, 0);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.Size = new Size(117, 24);
      this.tbxLedgerCode.TabIndex = 0;
      this.tbxLedgerCode.TextAlign = HorizontalAlignment.Center;
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
      this.headerPanel5.CaptionText = "AMOUNT";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(3, 321);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(368, 51);
      ((Control) this.headerPanel5).TabIndex = 7;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton7).Location = new Point(69, 513);
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
      ((Control) this.glassButton8).Location = new Point(203, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 1;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Dock = DockStyle.Fill;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(0, 0);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(366, 24);
      this.tbxAmount.TabIndex = 0;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      this.tbxAmount.KeyDown += new KeyEventHandler(this.tbxAmount_KeyDown);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
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
      this.headerPanel4.CaptionText = "VOUCHER DESCRIPTION";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxVoucherDescription);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(3, 268);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(536, 51);
      ((Control) this.headerPanel4).TabIndex = 6;
      this.headerPanel4.TextAntialias = true;
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
      ((Control) this.glassButton5).Location = new Point(237, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 0;
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
      ((Control) this.glassButton6).Location = new Point(371, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxVoucherDescription.BackColor = Color.AliceBlue;
      this.tbxVoucherDescription.BorderStyle = BorderStyle.None;
      this.tbxVoucherDescription.Dock = DockStyle.Fill;
      this.tbxVoucherDescription.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDescription.Location = new Point(0, 0);
      this.tbxVoucherDescription.Name = "tbxVoucherDescription";
      this.tbxVoucherDescription.Size = new Size(534, 24);
      this.tbxVoucherDescription.TabIndex = 0;
      this.tbxVoucherDescription.TextAlign = HorizontalAlignment.Center;
      this.tbxVoucherDescription.KeyDown += new KeyEventHandler(this.tbxVoucherDescription_KeyDown);
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
      this.headerPanel2.CaptionText = "LEDGER TYPE IN HINDI";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxLedgerTypeInHindi);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(3, 162);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(537, 51);
      ((Control) this.headerPanel2).TabIndex = 4;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(240, 513);
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
      ((Control) this.glassButton4).Location = new Point(374, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxLedgerTypeInHindi.BackColor = Color.AliceBlue;
      this.tbxLedgerTypeInHindi.BorderStyle = BorderStyle.None;
      this.tbxLedgerTypeInHindi.Dock = DockStyle.Fill;
      this.tbxLedgerTypeInHindi.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInHindi.Location = new Point(0, 0);
      this.tbxLedgerTypeInHindi.Name = "tbxLedgerTypeInHindi";
      this.tbxLedgerTypeInHindi.Size = new Size(535, 24);
      this.tbxLedgerTypeInHindi.TabIndex = 0;
      this.tbxLedgerTypeInHindi.TextAlign = HorizontalAlignment.Center;
      this.tbxLedgerTypeInHindi.KeyPress += new KeyPressEventHandler(this.tbxLedgerTypeInHindi_KeyPress);
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
      this.headerPanel1.CaptionText = "VOUCHER DATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxVoucherDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(279, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(261, 51);
      ((Control) this.headerPanel1).TabIndex = 1;
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
      ((Control) this.glassButton1).Location = new Point(-34, 513);
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
      ((Control) this.glassButton2).Location = new Point(100, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxVoucherDate.BackColor = Color.AliceBlue;
      this.tbxVoucherDate.BorderStyle = BorderStyle.None;
      this.tbxVoucherDate.Dock = DockStyle.Fill;
      this.tbxVoucherDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDate.Location = new Point(0, 0);
      this.tbxVoucherDate.Name = "tbxVoucherDate";
      this.tbxVoucherDate.Size = new Size(259, 24);
      this.tbxVoucherDate.TabIndex = 0;
      this.tbxVoucherDate.TextAlign = HorizontalAlignment.Center;
      this.tbxVoucherDate.KeyDown += new KeyEventHandler(this.tbxVoucherDate_KeyDown);
      this.tbxVoucherDate.Validating += new CancelEventHandler(this.tbxVoucherDate_Validating);
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
      this.headerPanel6.CaptionText = "VOUCHER NUMBER";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxVoucherNumber);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(3, 3);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(274, 51);
      ((Control) this.headerPanel6).TabIndex = 0;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      ((ButtonBase) this.glassButton10).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(-21, 513);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(128, 35);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&SAVE";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton11.BackColor = Color.LightBlue;
      this.glassButton11.FadeOnFocus = true;
      ((Control) this.glassButton11).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton11.ForeColor = Color.MediumBlue;
      this.glassButton11.ForeColorOnFocus = Color.Red;
      this.glassButton11.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton11.GlowColor = Color.White;
      this.glassButton11.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton11).Location = new Point(113, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxVoucherNumber.BackColor = Color.AliceBlue;
      this.tbxVoucherNumber.BorderStyle = BorderStyle.None;
      this.tbxVoucherNumber.Dock = DockStyle.Fill;
      this.tbxVoucherNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNumber.Location = new Point(0, 0);
      this.tbxVoucherNumber.Name = "tbxVoucherNumber";
      this.tbxVoucherNumber.Size = new Size(272, 24);
      this.tbxVoucherNumber.TabIndex = 0;
      this.tbxVoucherNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxVoucherNumber.KeyDown += new KeyEventHandler(this.tbxVoucherNumber_KeyDown);
      this.tbxVoucherNumber.KeyPress += new KeyPressEventHandler(this.tbxVoucherNumber_KeyPress);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.Cyan;
      ((Control) this.headerPanel3).BackgroundImage = (Image) Resources.background_gradient_blue;
      this.headerPanel3.BorderColor = Color.RoyalBlue;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel3.CaptionEndColor = Color.AliceBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "VOUCHER DETAILS";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.panel1);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.LightYellow;
      this.headerPanel3.GradientStart = Color.NavajoWhite;
      ((Control) this.headerPanel3).Location = new Point(0, 0);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(1010, 402);
      ((Control) this.headerPanel3).TabIndex = 0;
      this.headerPanel3.TextAntialias = true;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(2, 403);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1005, 194);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox1);
      this.ForeColor = Color.Firebrick;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.Name = nameof (FormVoucher);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormVoucher);
      this.Load += new EventHandler(this.FormVoucher_Load);
      this.KeyPress += new KeyPressEventHandler(this.FormVoucher_KeyPress);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
