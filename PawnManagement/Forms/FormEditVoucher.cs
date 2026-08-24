
using cSouza.WinForms.Controls;
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormEditVoucher : Form
  {
    private string voucherNumber1;
    private string voucherNumber2 = "";
    private string oldvoucherNumber = "";
    private string voucherDate1;
    private string voucherdate2 = "";
    private string jammaOrNovae1;
    private string jammaOrNovae2 = "";
    private string ledgercode1;
    private string ledgercode2;
    private string ledgertype1;
    private string ledgertype2;
    private string ledgertypeinhindi1;
    private string ledgertypeinhindi2 = "";
    private string vouchercode1;
    private string vouchercode2 = "";
    private string voucherdescription1;
    private string voucherdescription2 = "";
    private string amount1;
    private string amount2 = "";
    private double oldAmount = 0.0;
    private string oldJammaOrNovae = "";
    private DateTime oldDateTime = new DateTime();
    private IContainer components = (IContainer) null;
    private TextBox tbxVoucherCode1;
    private TextBox tbxLedgerCode1;
    private TextBox tbxAmount1;
    private TextBox tbxVoucherDescription1;
    private TextBox tbxLedgerTypeInHindi1;
    private TextBox tbxVoucherDate1;
    private TextBox tbxVoucherNumber1;
    private GlassButton btnAddEdit1;
    private BorderLabel borderLabel11;
    private BorderLabel borderLabel10;
    private BorderLabel borderLabel9;
    private BorderLabel borderLabel8;
    private BorderLabel borderLabel7;
    private BorderLabel borderLabel6;
    private BorderLabel borderLabel5;
    private BorderLabel borderLabel4;
    private BorderLabel borderLabel19;
    private BorderLabel borderLabel18;
    private ComboBox cbVoucherName1;
    private ComboBox cbLedgerType1;
    private ComboBox cbJammaOrNovae1;
    private ComboBox cbVoucherName2;
    private ComboBox cbLedgerType2;
    private ComboBox cbJammaOrNovae2;
    private BorderLabel borderLabel2;
    private BorderLabel borderLabel3;
    private BorderLabel borderLabel12;
    private BorderLabel borderLabel13;
    private BorderLabel borderLabel14;
    private BorderLabel borderLabel15;
    private BorderLabel borderLabel16;
    private BorderLabel borderLabel17;
    private BorderLabel borderLabel20;
    private BorderLabel borderLabel21;
    private TextBox tbxVoucherNumber2;
    private TextBox tbxVoucherDate2;
    private TextBox tbxLedgerCode2;
    private TextBox tbxLedgerTypeInHindi2;
    private TextBox tbxVoucherCode2;
    private TextBox tbxVoucherDescription2;
    private TextBox tbxAmount2;
    private GlassButton btnAddEdit2;
    private HeaderPanel panel1;
    private HeaderPanel panel2;

    public FormEditVoucher(string voucherNumber)
    {
      this.oldvoucherNumber = voucherNumber;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        switch (control1)
        {
          case TextBox _:
            TextBox textBox = (TextBox) control1;
            textBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
            textBox.Enter += new EventHandler(this.textBox_Enter);
            textBox.Leave += new EventHandler(this.textBox_Leave);
            break;
          case ComboBox _:
            control1.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
            break;
          default:
            this.Assign(control1);
            break;
        }
      }
    }

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.Black;
      textBox.ForeColor = Color.Yellow;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.FromKnownColor(KnownColor.Info);
      textBox.ForeColor = Color.Black;
    }

    private void FormEditVoucher_Load(object sender, EventArgs e)
    {
      this.getVoucherDetails(this.oldvoucherNumber);
      this.Assign((Control) this);
      this.cbJammaOrNovae1.Select();
    }

    private void getVoucherDetails(string voucherNumber)
    {
      DataTable voucherDetails1 = VoucherClass.getVoucherDetails(voucherNumber);
      if (voucherDetails1 != null && voucherDetails1.Rows.Count > 0)
      {
        TextBox tbxVoucherDate2 = this.tbxVoucherDate2;
        TextBox tbxVoucherDate1 = this.tbxVoucherDate1;
        DateTime dateTime = DateTime.Parse(voucherDetails1.Rows[0]["voucherDate"].ToString());
        string str1;
        string str2 = str1 = dateTime.ToString("dd/MM/yyyy");
        tbxVoucherDate1.Text = str1;
        string str3 = str2;
        tbxVoucherDate2.Text = str3;
        this.tbxVoucherNumber1.Text = VoucherClass.getMaxOfVoucherNumber(DateTime.Parse(this.tbxVoucherDate1.Text));
        this.tbxVoucherNumber2.Text = (double.Parse(this.tbxVoucherNumber1.Text) + 1.0).ToString();
        this.cbJammaOrNovae1.Text = voucherDetails1.Rows[0]["jammaornovae"].ToString();
        this.cbLedgerType1.Text = LedgerMaster.getLedgerName(voucherDetails1.Rows[0]["ledgerCode"].ToString());
        this.tbxLedgerCode1.Text = voucherDetails1.Rows[0]["LEDGERCODE"].ToString();
        this.tbxLedgerTypeInHindi1.Text = LedgerMaster.getLedgerNameInHindi(voucherDetails1.Rows[0]["ledgerCode"].ToString());
        this.cbVoucherName1.Text = voucherDetails1.Rows[0]["voucherName"].ToString();
        this.tbxVoucherCode1.Text = voucherDetails1.Rows[0]["voucherCode"].ToString();
        this.oldDateTime = DateTime.Parse(voucherDetails1.Rows[0]["voucherDate"].ToString());
        this.tbxVoucherDescription1.Text = voucherDetails1.Rows[0]["voucherDescription"].ToString();
        this.oldJammaOrNovae = voucherDetails1.Rows[0]["jammaOrNovae"].ToString();
        if (this.oldJammaOrNovae == "JAMMA")
          this.tbxAmount1.Text = (this.oldAmount = double.Parse(voucherDetails1.Rows[0]["amount"].ToString())).ToString();
        else if (this.oldJammaOrNovae == "NOVAE")
        {
          this.oldAmount = -double.Parse(voucherDetails1.Rows[0]["amount"].ToString());
          this.tbxAmount1.Text = double.Parse(voucherDetails1.Rows[0]["amount"].ToString()).ToString();
        }
        DataTable voucherDetails2 = VoucherClass.getVoucherDetails(this.tbxVoucherNumber1.Text);
        if (voucherDetails2 == null || voucherDetails2.Rows.Count <= 0)
          return;
        int num = (int) MessageBox.Show("Cannot update old data");
        this.Close();
      }
      else
      {
        int num = (int) MessageBox.Show("Error in fetching details of the Old BILL NUMBER...PLEASE retry");
        this.Close();
      }
    }

    private void cbJammaOrNovae1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'J' | e.KeyChar == 'j')
      {
        this.cbJammaOrNovae1.Text = "JAMMA";
        this.cbLedgerType1.Select();
      }
      else if (e.KeyChar == 'N' | e.KeyChar == 'n')
      {
        this.cbJammaOrNovae1.Text = "NOVAE";
        this.cbLedgerType1.Select();
      }
      else
        e.Handled = true;
    }

    private void cbJammaOrNovae2_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'J' | e.KeyChar == 'j')
      {
        this.cbJammaOrNovae2.Text = "JAMMA";
        this.cbLedgerType2.Select();
      }
      else if (e.KeyChar == 'N' | e.KeyChar == 'n')
      {
        this.cbJammaOrNovae2.Text = "NOVAE";
        this.cbLedgerType2.Select();
      }
      else
        e.Handled = true;
    }

    private void cbJammaOrNovae1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.cbLedgerType1.Text = string.Empty;
      this.getLedgerType1();
    }

    private void cbJammaOrNovae2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.cbLedgerType2.Text = string.Empty;
      this.getLedgerType2();
    }

    private void getLedgerType1()
    {
      try
      {
        string strError = "";
        string my_querry = "select distinct(LedgerType),ledgercode,ledgertypeinhindi from tblLedgerr where jammaOrNovae in('" + this.cbJammaOrNovae1.Text.Trim().ToString() + "','jammanovae')";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Voucher.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Voucher.getLedgerType" + strError);
        }
        else
        {
          this.cbLedgerType1.Text = string.Empty;
          this.cbLedgerType1.Items.Clear();
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              this.cbLedgerType1.Items.Add((object) row["LedgerType"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getledgertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerType2()
    {
      try
      {
        string strError = "";
        string my_querry = "select distinct(LedgerType),ledgercode,ledgertypeinhindi from tblLedgerr where jammaOrNovae in('" + this.cbJammaOrNovae2.Text.Trim().ToString() + "','jammanovae')";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Voucher.getLedgerType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Voucher.getLedgerType" + strError);
        }
        else
        {
          this.cbLedgerType2.Text = string.Empty;
          this.cbLedgerType2.Items.Clear();
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              this.cbLedgerType2.Items.Add((object) row["LedgerType"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getledgertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbJammaOrNovae1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbJammaOrNovae1.Text == ""))
        return;
      this.cbJammaOrNovae1.Select();
    }

    private void cbJammaOrNovae2_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbJammaOrNovae2.Text == ""))
        return;
      this.cbJammaOrNovae2.Select();
    }

    private void cbLedgerType1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !(this.cbLedgerType1.Text.Trim() != ""))
        return;
      this.cbVoucherName1.Select();
    }

    private void cbLedgerType2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !(this.cbLedgerType2.Text.Trim() != ""))
        return;
      this.cbVoucherName2.Select();
    }

    private void cbLedgerType1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getLedgerTypeInHindi1();
      this.populatecbVoucherName1();
    }

    private void cbLedgerType2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getLedgerTypeInHindi2();
      this.populatecbVoucherName2();
    }

    private void getLedgerTypeInHindi1()
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertypeinhindi from tblLedgerr where ledgertype = @ledgertype";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgertype", (object) this.cbLedgerType1.Text.Trim().ToString())
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form voucher.getLedgerTypeInHindi" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.tbxLedgerCode1.Text = dataTable2.Rows[0]["ledgercode"].ToString();
          this.tbxLedgerTypeInHindi1.Text = dataTable2.Rows[0]["ledgertypeinhindi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerTypeInHindi2()
    {
      try
      {
        string strError = "";
        string my_querry = "select ledgercode,ledgertypeinhindi from tblLedgerr where ledgertype = @ledgertype";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ledgertype", (object) this.cbLedgerType2.Text.Trim().ToString())
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form voucher.getLedgerTypeInHindi" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.tbxLedgerCode2.Text = dataTable2.Rows[0]["ledgercode"].ToString();
          this.tbxLedgerTypeInHindi2.Text = dataTable2.Rows[0]["ledgertypeinhindi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form voucher.getLedgerTypeInHindi", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void populatecbVoucherName1()
    {
      try
      {
        this.cbVoucherName1.Items.Clear();
        DataTable voucherNames = VoucherMasterClass.getVoucherNames(this.tbxLedgerCode1.Text);
        if (voucherNames == null || voucherNames.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) voucherNames.Rows)
          this.cbVoucherName1.Items.Add((object) row["vouchername"].ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.gettblvouchername", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void populatecbVoucherName2()
    {
      try
      {
        this.cbVoucherName2.Items.Clear();
        DataTable voucherNames = VoucherMasterClass.getVoucherNames(this.tbxLedgerCode2.Text);
        if (voucherNames == null || voucherNames.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) voucherNames.Rows)
          this.cbVoucherName2.Items.Add((object) row["vouchername"].ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.gettblvouchername", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbLedgerType1_Validating(object sender, CancelEventArgs e)
    {
      string text = this.cbLedgerType1.Text;
      if ((sender as ComboBox).Items.Count <= 0)
        return;
      if ((sender as ComboBox).Text.Trim() != "")
      {
        if (!(sender as ComboBox).Items.Contains((object) (sender as ComboBox).Text.Trim().ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          {
            string nextLedgerCode = LedgerMaster.getNextLedgerCode(this.cbLedgerType1.Text.Trim());
            if (nextLedgerCode != "" && LedgerMaster.addLedgerDetails(nextLedgerCode, this.cbLedgerType1.Text, "JAMMANOVAE", this.cbLedgerType1.Text, "Y", FormMain.username, DateTime.Now) == "Done")
            {
              this.cbLedgerType1.Items.Clear();
              this.getLedgerType1();
              this.cbLedgerType1.Text = text;
            }
          }
          else
            (sender as ComboBox).Select();
        }
      }
      else
        (sender as ComboBox).Select();
    }

    private void cbLedgerType2_Validating(object sender, CancelEventArgs e)
    {
      string text = this.cbLedgerType2.Text;
      if ((sender as ComboBox).Items.Count <= 0)
        return;
      if ((sender as ComboBox).Text.Trim() != "")
      {
        if (!(sender as ComboBox).Items.Contains((object) (sender as ComboBox).Text.Trim().ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          {
            string nextLedgerCode = LedgerMaster.getNextLedgerCode(this.cbLedgerType2.Text.Trim());
            if (nextLedgerCode != "" && LedgerMaster.addLedgerDetails(nextLedgerCode, this.cbLedgerType2.Text, "JAMMANOVAE", this.cbLedgerType2.Text, "Y", FormMain.username, DateTime.Now) == "Done")
            {
              this.cbLedgerType2.Items.Clear();
              this.getLedgerType2();
              this.cbLedgerType2.Text = text;
            }
          }
          else
            (sender as ComboBox).Select();
        }
      }
      else
        (sender as ComboBox).Select();
    }

    private void tbxLedgerTypeInHindi1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxLedgerTypeInHindi2_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxLedgerTypeInHindi2_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void cbVoucherName1_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select VoucherCode from tblVoucherMaster where VoucherName = @VoucherName and LedgerCode= @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("VoucherName", (object) this.cbVoucherName1.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode1.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Vocher.cbvouchername_selectedIndexChanged" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherCode1.Text = dataTable2.Rows[0]["VoucherCode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbVoucherName2_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select VoucherCode from tblVoucherMaster where VoucherName = @VoucherName and LedgerCode= @LedgerCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("VoucherName", (object) this.cbVoucherName2.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode2.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form Vocher.cbvouchername_selectedIndexChanged" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.tbxVoucherCode2.Text = dataTable2.Rows[0]["VoucherCode"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Vocher.cbvouchername_selectedIndexChanged 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbVoucherName1_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbVoucherName1.Items.Count <= 0)
        return;
      if (this.cbVoucherName1.Text.Trim() != "")
      {
        if (!this.cbVoucherName1.Items.Contains((object) this.cbVoucherName1.Text.Trim().ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          {
            string nextVoucherCode = VoucherMasterClass.getNextVoucherCode(this.cbVoucherName1.Text);
            if (nextVoucherCode != "")
              VoucherMasterClass.addvoucherMaster(nextVoucherCode, this.cbVoucherName1.Text, this.tbxLedgerCode1.Text, this.cbLedgerType1.Text, DateTime.Now, FormMain.username);
            string text = this.cbVoucherName1.Text;
            this.cbVoucherName1.Items.Clear();
            this.populatecbVoucherName1();
            this.cbVoucherName1.Text = text;
          }
          else
            this.cbVoucherName1.Select();
        }
      }
      else
        this.cbVoucherName1.Select();
    }

    private void cbVoucherName2_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbVoucherName2.Items.Count <= 0)
        return;
      if (this.cbVoucherName2.Text.Trim() != "")
      {
        if (!this.cbVoucherName2.Items.Contains((object) this.cbVoucherName2.Text.Trim().ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("New Entry..Do you want to Add", "Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          {
            string nextVoucherCode = VoucherMasterClass.getNextVoucherCode(this.cbVoucherName2.Text);
            if (nextVoucherCode != "")
              VoucherMasterClass.addvoucherMaster(nextVoucherCode, this.cbVoucherName2.Text, this.tbxLedgerCode2.Text, this.cbLedgerType2.Text, DateTime.Now, FormMain.username);
            string text = this.cbVoucherName2.Text;
            this.cbVoucherName2.Items.Clear();
            this.populatecbVoucherName2();
            this.cbVoucherName2.Text = text;
          }
          else
            this.cbVoucherName2.Select();
        }
      }
      else
        this.cbVoucherName2.Select();
    }

    private void tbxAmount1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxVoucherNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void tbxVoucherNumber1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxVoucherDate1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxVoucherDate2_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxLedgerCode1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxLedgerCode1_Enter(object sender, EventArgs e)
    {
    }

    private void btnAddEdit1_Click(object sender, EventArgs e)
    {
      if (!this.validateData1())
        return;
      if (this.cbJammaOrNovae1.Text == this.oldJammaOrNovae)
      {
        if (this.oldAmount <= 0.0)
          this.oldAmount = -this.oldAmount;
        if (this.oldAmount == double.Parse(this.tbxAmount1.Text))
        {
          PawnManagementClass.updatetblVouchers(this.oldDateTime, this.oldvoucherNumber, this.tbxVoucherCode1.Text.Trim().ToString(), this.cbVoucherName1.Text.Trim().ToString(), this.tbxVoucherDescription1.Text.Trim().ToString(), this.tbxLedgerCode1.Text.Trim().ToString(), this.cbJammaOrNovae1.Text.ToString(), double.Parse(this.tbxAmount1.Text.ToString()));
          int num = (int) MessageBox.Show("Successfully updated");
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show("Error...Retry  aMOUNT NOT SAME");
          this.Close();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Error...Retry  AS JAMMA OR NOVAE NOT SAME");
        this.Close();
      }
    }

    private bool validateData1()
    {
      if (this.tbxVoucherNumber1.Text.Trim() != "")
      {
        if (this.tbxVoucherDate1.Text.Trim() != "" && PawnManagementClass.checkForValidateDate(this.tbxVoucherDate2.Text))
        {
          if (this.cbJammaOrNovae1.Text.Trim() != "")
          {
            if (this.cbLedgerType1.Text.Trim() != "")
            {
              if (this.tbxLedgerCode1.Text.Trim() != "")
              {
                if (this.cbVoucherName1.Text.Trim() != "")
                {
                  if (this.tbxVoucherCode1.Text.Trim() != "")
                  {
                    if (this.tbxVoucherDescription1.Text.Trim() != "")
                    {
                      if (this.tbxAmount1.Text.Trim() != "")
                        return true;
                      this.tbxAmount1.Select();
                      return false;
                    }
                    this.tbxVoucherDescription1.Select();
                    return false;
                  }
                  this.tbxVoucherCode1.Select();
                  return false;
                }
                this.cbVoucherName1.Select();
                return false;
              }
              this.tbxLedgerCode1.Select();
              return false;
            }
            this.cbLedgerType1.Select();
            return false;
          }
          this.cbJammaOrNovae1.Select();
          return false;
        }
        this.tbxVoucherDate1.Select();
        return false;
      }
      this.tbxVoucherNumber1.Select();
      return false;
    }

    private bool validateData2()
    {
      if (this.tbxVoucherNumber2.Text.Trim() != "")
      {
        if (this.tbxVoucherDate2.Text.Trim() != "" && PawnManagementClass.checkForValidateDate(this.tbxVoucherDate2.Text))
        {
          if (this.cbJammaOrNovae2.Text.Trim() != "")
          {
            if (this.cbLedgerType2.Text.Trim() != "")
            {
              if (this.tbxLedgerCode2.Text.Trim() != "")
              {
                if (this.cbVoucherName2.Text.Trim() != "")
                {
                  if (this.tbxVoucherCode2.Text.Trim() != "")
                  {
                    if (this.tbxVoucherDescription2.Text.Trim() != "")
                    {
                      if (this.tbxAmount2.Text.Trim() != "")
                        return true;
                      this.tbxAmount2.Select();
                      return false;
                    }
                    this.tbxVoucherDescription2.Select();
                    return false;
                  }
                  this.tbxVoucherCode2.Select();
                  return false;
                }
                this.cbVoucherName2.Select();
                return false;
              }
              this.tbxLedgerCode2.Select();
              return false;
            }
            this.cbLedgerType2.Select();
            return false;
          }
          this.cbJammaOrNovae2.Select();
          return false;
        }
        this.tbxVoucherDate2.Select();
        return false;
      }
      this.tbxVoucherNumber2.Select();
      return false;
    }

    private void tbxAmount1_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxAmount1.Text.Trim() != ""))
        return;
      double num = 0.0;
      if (this.cbJammaOrNovae1.Text == "JAMMA")
        num = this.oldAmount - double.Parse(this.tbxAmount1.Text);
      else if (this.cbJammaOrNovae1.Text == "NOVAE")
        num = this.oldAmount + double.Parse(this.tbxAmount1.Text);
      if (num == 0.0)
      {
        ((Control) this.panel2).Visible = false;
        ((Control) this.btnAddEdit1).Enabled = true;
      }
      else if (num < 0.0)
      {
        ((Control) this.panel2).Visible = true;
        this.cbJammaOrNovae2.Text = "NOVAE";
        this.cbJammaOrNovae2.Enabled = false;
        this.tbxAmount2.Text = (-num).ToString();
        this.tbxAmount2.ReadOnly = true;
        ((Control) this.btnAddEdit1).Enabled = false;
      }
      else
      {
        ((Control) this.panel2).Visible = true;
        this.cbJammaOrNovae2.Text = "JAMMA";
        this.cbJammaOrNovae2.Enabled = false;
        this.tbxAmount2.Text = num.ToString();
        this.tbxAmount2.ReadOnly = true;
        ((Control) this.btnAddEdit1).Enabled = false;
      }
    }

    private void btnAddEdit2_Click(object sender, EventArgs e)
    {
      if (!this.validateData1() || !this.validateData2())
        return;
      if (this.oldAmount + (!(this.cbJammaOrNovae1.Text == "JAMMA") ? double.Parse(this.tbxAmount1.Text) : -double.Parse(this.tbxAmount1.Text)) + (!(this.cbJammaOrNovae2.Text == "JAMMA") ? double.Parse(this.tbxAmount2.Text) : -double.Parse(this.tbxAmount2.Text)) == 0.0)
      {
        double jammaSideClosing = 0.0;
        double novaeSideClosing = 0.0;
        double num1 = 0.0;
        double num2 = 0.0;
        DataTable rokadDetails = RokadDetailsClass.getRokadDetails(DateTime.Parse(this.tbxVoucherDate1.Text));
        if (rokadDetails != null && rokadDetails.Rows.Count > 0)
        {
          double num3 = double.Parse(rokadDetails.Rows[0]["Jammasideclosing"].ToString());
          double num4 = double.Parse(rokadDetails.Rows[0]["Novaesideclosing"].ToString());
          if (this.cbJammaOrNovae1.Text == "JAMMA")
            num1 = double.Parse(this.tbxAmount1.Text);
          else
            num2 = double.Parse(this.tbxAmount1.Text);
          if (this.cbJammaOrNovae2.Text == "JAMMA")
            num1 += double.Parse(this.tbxAmount2.Text);
          else
            num2 += double.Parse(this.tbxAmount2.Text);
          if (this.oldJammaOrNovae == "JAMMA")
          {
            jammaSideClosing = num3 - this.oldAmount + num1;
            novaeSideClosing = num4 + num2;
          }
          else if (this.oldJammaOrNovae == "NOVAE")
          {
            novaeSideClosing = num4 + this.oldAmount + num2;
            jammaSideClosing = num3 + num1;
          }
          int num5 = (int) MessageBox.Show(jammaSideClosing.ToString() + " " + novaeSideClosing.ToString());
        }
        if (VoucherClass.DeleteVoucherNumber(this.oldvoucherNumber) == "Done" && PawnManagementClass.insertIntotblVouchers(DateTime.Parse(this.tbxVoucherDate1.Text), this.tbxVoucherNumber1.Text, this.tbxVoucherCode1.Text, this.cbVoucherName1.Text, this.tbxVoucherCode1.Text, this.tbxLedgerCode1.Text, this.cbJammaOrNovae1.Text, double.Parse(this.tbxAmount1.Text)) == "Done" && PawnManagementClass.insertIntotblVouchers(DateTime.Parse(this.tbxVoucherDate2.Text), this.tbxVoucherNumber2.Text, this.tbxVoucherCode2.Text, this.cbVoucherName2.Text, this.tbxVoucherCode2.Text, this.tbxLedgerCode2.Text, this.cbJammaOrNovae2.Text, double.Parse(this.tbxAmount2.Text)) == "Done" && RokadDetailsClass.UpdateJammaSideClosingAndNovaeSideClosing(this.tbxVoucherDate1.Text, jammaSideClosing, novaeSideClosing) == "Done")
        {
          int num6 = (int) MessageBox.Show("Successfully updated");
          this.Close();
        }
      }
    }

    private void tbxAmount1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxAmount1.Text.Trim() != ""))
        return;
      double num = 0.0;
      if (this.cbJammaOrNovae1.Text == "JAMMA")
        num = this.oldAmount - double.Parse(this.tbxAmount1.Text);
      else if (this.cbJammaOrNovae1.Text == "NOVAE")
        num = this.oldAmount + double.Parse(this.tbxAmount1.Text);
      if (num == 0.0)
      {
        ((Control) this.panel2).Visible = false;
        ((Control) this.btnAddEdit1).Enabled = true;
      }
      else if (num < 0.0)
      {
        ((Control) this.panel2).Visible = true;
        this.cbJammaOrNovae2.Text = "NOVAE";
        this.cbJammaOrNovae2.Enabled = false;
        this.tbxAmount2.Text = (-num).ToString();
        this.tbxAmount2.ReadOnly = true;
        ((Control) this.btnAddEdit1).Enabled = false;
      }
      else
      {
        ((Control) this.panel2).Visible = true;
        this.cbJammaOrNovae2.Text = "JAMMA";
        this.cbJammaOrNovae2.Enabled = false;
        this.tbxAmount2.Text = num.ToString();
        this.tbxAmount2.ReadOnly = true;
        ((Control) this.btnAddEdit1).Enabled = false;
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
      this.cbVoucherName2 = new ComboBox();
      this.cbLedgerType2 = new ComboBox();
      this.cbJammaOrNovae2 = new ComboBox();
      this.borderLabel2 = new BorderLabel();
      this.borderLabel3 = new BorderLabel();
      this.borderLabel12 = new BorderLabel();
      this.borderLabel13 = new BorderLabel();
      this.borderLabel14 = new BorderLabel();
      this.borderLabel15 = new BorderLabel();
      this.borderLabel16 = new BorderLabel();
      this.borderLabel17 = new BorderLabel();
      this.borderLabel20 = new BorderLabel();
      this.borderLabel21 = new BorderLabel();
      this.tbxVoucherNumber2 = new TextBox();
      this.tbxVoucherDate2 = new TextBox();
      this.tbxLedgerCode2 = new TextBox();
      this.tbxLedgerTypeInHindi2 = new TextBox();
      this.tbxVoucherCode2 = new TextBox();
      this.tbxVoucherDescription2 = new TextBox();
      this.tbxAmount2 = new TextBox();
      this.btnAddEdit2 = new GlassButton();
      this.cbVoucherName1 = new ComboBox();
      this.cbLedgerType1 = new ComboBox();
      this.cbJammaOrNovae1 = new ComboBox();
      this.borderLabel19 = new BorderLabel();
      this.borderLabel18 = new BorderLabel();
      this.borderLabel11 = new BorderLabel();
      this.borderLabel10 = new BorderLabel();
      this.borderLabel9 = new BorderLabel();
      this.borderLabel8 = new BorderLabel();
      this.borderLabel7 = new BorderLabel();
      this.borderLabel6 = new BorderLabel();
      this.borderLabel5 = new BorderLabel();
      this.borderLabel4 = new BorderLabel();
      this.tbxVoucherNumber1 = new TextBox();
      this.tbxVoucherDate1 = new TextBox();
      this.tbxLedgerCode1 = new TextBox();
      this.tbxLedgerTypeInHindi1 = new TextBox();
      this.tbxVoucherCode1 = new TextBox();
      this.tbxVoucherDescription1 = new TextBox();
      this.tbxAmount1 = new TextBox();
      this.btnAddEdit1 = new GlassButton();
      this.panel1 = new HeaderPanel();
      this.panel2 = new HeaderPanel();
      ((Control) this.panel1).SuspendLayout();
      ((Control) this.panel2).SuspendLayout();
      this.SuspendLayout();
      this.cbVoucherName2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbVoucherName2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbVoucherName2.BackColor = SystemColors.Window;
      this.cbVoucherName2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbVoucherName2.FlatStyle = FlatStyle.Popup;
      this.cbVoucherName2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbVoucherName2.FormattingEnabled = true;
      this.cbVoucherName2.Location = new Point(206, 312);
      this.cbVoucherName2.Name = "cbVoucherName2";
      this.cbVoucherName2.Size = new Size(262, 28);
      this.cbVoucherName2.TabIndex = 27;
      this.cbVoucherName2.SelectedIndexChanged += new EventHandler(this.cbVoucherName2_SelectedIndexChanged);
      this.cbVoucherName2.Validating += new CancelEventHandler(this.cbVoucherName2_Validating);
      this.cbLedgerType2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLedgerType2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLedgerType2.BackColor = SystemColors.Window;
      this.cbLedgerType2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLedgerType2.FlatStyle = FlatStyle.Popup;
      this.cbLedgerType2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType2.FormattingEnabled = true;
      this.cbLedgerType2.Location = new Point(206, 174);
      this.cbLedgerType2.Name = "cbLedgerType2";
      this.cbLedgerType2.Size = new Size(262, 28);
      this.cbLedgerType2.TabIndex = 24;
      this.cbLedgerType2.SelectedIndexChanged += new EventHandler(this.cbLedgerType2_SelectedIndexChanged);
      this.cbLedgerType2.KeyDown += new KeyEventHandler(this.cbLedgerType2_KeyDown);
      this.cbLedgerType2.Validating += new CancelEventHandler(this.cbLedgerType2_Validating);
      this.cbJammaOrNovae2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbJammaOrNovae2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbJammaOrNovae2.BackColor = SystemColors.Window;
      this.cbJammaOrNovae2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbJammaOrNovae2.FlatStyle = FlatStyle.Popup;
      this.cbJammaOrNovae2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbJammaOrNovae2.FormattingEnabled = true;
      this.cbJammaOrNovae2.Items.AddRange(new object[2]
      {
        (object) "JAMMA",
        (object) "NOVAE"
      });
      this.cbJammaOrNovae2.Location = new Point(206, 128);
      this.cbJammaOrNovae2.Name = "cbJammaOrNovae2";
      this.cbJammaOrNovae2.Size = new Size(262, 28);
      this.cbJammaOrNovae2.TabIndex = 23;
      this.cbJammaOrNovae2.SelectedIndexChanged += new EventHandler(this.cbJammaOrNovae2_SelectedIndexChanged);
      this.cbJammaOrNovae2.KeyPress += new KeyPressEventHandler(this.cbJammaOrNovae2_KeyPress);
      this.cbJammaOrNovae2.Validating += new CancelEventHandler(this.cbJammaOrNovae2_Validating);
      ((Control) this.borderLabel2).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel2).AutoSize = true;
      ((Control) this.borderLabel2).BackColor = Color.Transparent;
      this.borderLabel2.BorderColor = Color.MidnightBlue;
      this.borderLabel2.BorderSize = 0.0f;
      ((Label) this.borderLabel2).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel2).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel2).Location = new Point(84, 363);
      ((Control) this.borderLabel2).Name = "borderLabel2";
      ((Control) this.borderLabel2).Size = new Size(116, 15);
      ((Control) this.borderLabel2).TabIndex = 39;
      ((Control) this.borderLabel2).Text = "VOUCHER CODE";
      ((Control) this.borderLabel3).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel3).AutoSize = true;
      ((Control) this.borderLabel3).BackColor = Color.Transparent;
      this.borderLabel3.BorderColor = Color.MidnightBlue;
      this.borderLabel3.BorderSize = 0.0f;
      ((Label) this.borderLabel3).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel3).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel3).Location = new Point(96, 226);
      ((Control) this.borderLabel3).Name = "borderLabel3";
      ((Control) this.borderLabel3).Size = new Size(104, 15);
      ((Control) this.borderLabel3).TabIndex = 36;
      ((Control) this.borderLabel3).Text = "LEDGER CODE";
      ((Control) this.borderLabel12).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel12).AutoSize = true;
      ((Control) this.borderLabel12).BackColor = Color.Transparent;
      this.borderLabel12.BorderColor = Color.MidnightBlue;
      this.borderLabel12.BorderSize = 0.0f;
      ((Label) this.borderLabel12).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel12).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel12).Location = new Point(65, 42);
      ((Control) this.borderLabel12).Name = "borderLabel12";
      ((Control) this.borderLabel12).Size = new Size(135, 15);
      ((Control) this.borderLabel12).TabIndex = 32;
      ((Control) this.borderLabel12).Text = "VOUCHER NUMBER";
      ((Control) this.borderLabel13).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel13).AutoSize = true;
      ((Control) this.borderLabel13).BackColor = Color.Transparent;
      this.borderLabel13.BorderColor = Color.MidnightBlue;
      this.borderLabel13.BorderSize = 0.0f;
      ((Label) this.borderLabel13).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel13).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel13).Location = new Point(135, 454);
      ((Control) this.borderLabel13).Name = "borderLabel13";
      ((Control) this.borderLabel13).Size = new Size(65, 15);
      ((Control) this.borderLabel13).TabIndex = 41;
      ((Control) this.borderLabel13).Text = "AMOUNT";
      ((Control) this.borderLabel14).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel14).AutoSize = true;
      ((Control) this.borderLabel14).BackColor = Color.Transparent;
      this.borderLabel14.BorderColor = Color.MidnightBlue;
      this.borderLabel14.BorderSize = 0.0f;
      ((Label) this.borderLabel14).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel14).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel14).Location = new Point(31, 409);
      ((Control) this.borderLabel14).Name = "borderLabel14";
      ((Control) this.borderLabel14).Size = new Size(169, 15);
      ((Control) this.borderLabel14).TabIndex = 40;
      ((Control) this.borderLabel14).Text = "VOUCHER DESCRIPTION";
      ((Control) this.borderLabel15).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel15).AutoSize = true;
      ((Control) this.borderLabel15).BackColor = Color.Transparent;
      this.borderLabel15.BorderColor = Color.MidnightBlue;
      this.borderLabel15.BorderSize = 0.0f;
      ((Label) this.borderLabel15).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel15).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel15).Location = new Point(84, 317);
      ((Control) this.borderLabel15).Name = "borderLabel15";
      ((Control) this.borderLabel15).Size = new Size(116, 15);
      ((Control) this.borderLabel15).TabIndex = 38;
      ((Control) this.borderLabel15).Text = "VOUCHER NAME";
      ((Control) this.borderLabel16).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel16).AutoSize = true;
      ((Control) this.borderLabel16).BackColor = Color.Transparent;
      this.borderLabel16.BorderColor = Color.MidnightBlue;
      this.borderLabel16.BorderSize = 0.0f;
      ((Label) this.borderLabel16).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel16).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel16).Location = new Point(43, 272);
      ((Control) this.borderLabel16).Name = "borderLabel16";
      ((Control) this.borderLabel16).Size = new Size(157, 15);
      ((Control) this.borderLabel16).TabIndex = 37;
      ((Control) this.borderLabel16).Text = "LEDGER TYPE IN HINDI";
      ((Control) this.borderLabel17).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel17).AutoSize = true;
      ((Control) this.borderLabel17).BackColor = Color.Transparent;
      this.borderLabel17.BorderColor = Color.MidnightBlue;
      this.borderLabel17.BorderSize = 0.0f;
      ((Label) this.borderLabel17).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel17).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel17).Location = new Point(101, 180);
      ((Control) this.borderLabel17).Name = "borderLabel17";
      ((Control) this.borderLabel17).Size = new Size(99, 15);
      ((Control) this.borderLabel17).TabIndex = 35;
      ((Control) this.borderLabel17).Text = "LEDGER TYPE";
      ((Control) this.borderLabel20).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel20).AutoSize = true;
      ((Control) this.borderLabel20).BackColor = Color.Transparent;
      this.borderLabel20.BorderColor = Color.MidnightBlue;
      this.borderLabel20.BorderSize = 0.0f;
      ((Label) this.borderLabel20).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel20).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel20).Location = new Point(74, 134);
      ((Control) this.borderLabel20).Name = "borderLabel20";
      ((Control) this.borderLabel20).Size = new Size(126, 15);
      ((Control) this.borderLabel20).TabIndex = 34;
      ((Control) this.borderLabel20).Text = "JAMMA OR NOVAE";
      ((Control) this.borderLabel21).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel21).AutoSize = true;
      ((Control) this.borderLabel21).BackColor = Color.Transparent;
      this.borderLabel21.BorderColor = Color.MidnightBlue;
      this.borderLabel21.BorderSize = 0.0f;
      ((Label) this.borderLabel21).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel21).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel21).Location = new Point(87, 89);
      ((Control) this.borderLabel21).Name = "borderLabel21";
      ((Control) this.borderLabel21).Size = new Size(113, 15);
      ((Control) this.borderLabel21).TabIndex = 33;
      ((Control) this.borderLabel21).Text = "VOUCHER DATE";
      this.tbxVoucherNumber2.BackColor = SystemColors.Window;
      this.tbxVoucherNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNumber2.Enabled = false;
      this.tbxVoucherNumber2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNumber2.Location = new Point(206, 37);
      this.tbxVoucherNumber2.Name = "tbxVoucherNumber2";
      this.tbxVoucherNumber2.Size = new Size(262, 31);
      this.tbxVoucherNumber2.TabIndex = 21;
      this.tbxVoucherNumber2.KeyPress += new KeyPressEventHandler(this.tbxVoucherNumber_KeyPress);
      this.tbxVoucherDate2.BackColor = SystemColors.Window;
      this.tbxVoucherDate2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherDate2.Enabled = false;
      this.tbxVoucherDate2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDate2.Location = new Point(206, 85);
      this.tbxVoucherDate2.Name = "tbxVoucherDate2";
      this.tbxVoucherDate2.Size = new Size(262, 31);
      this.tbxVoucherDate2.TabIndex = 22;
      this.tbxVoucherDate2.KeyPress += new KeyPressEventHandler(this.tbxVoucherDate2_KeyPress);
      this.tbxLedgerCode2.BackColor = SystemColors.Window;
      this.tbxLedgerCode2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode2.Enabled = false;
      this.tbxLedgerCode2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode2.Location = new Point(206, 221);
      this.tbxLedgerCode2.Name = "tbxLedgerCode2";
      this.tbxLedgerCode2.Size = new Size(262, 31);
      this.tbxLedgerCode2.TabIndex = 25;
      this.tbxLedgerCode2.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxLedgerTypeInHindi2.BackColor = SystemColors.Window;
      this.tbxLedgerTypeInHindi2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInHindi2.Enabled = false;
      this.tbxLedgerTypeInHindi2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInHindi2.Location = new Point(206, 266);
      this.tbxLedgerTypeInHindi2.Name = "tbxLedgerTypeInHindi2";
      this.tbxLedgerTypeInHindi2.Size = new Size(262, 31);
      this.tbxLedgerTypeInHindi2.TabIndex = 26;
      this.tbxLedgerTypeInHindi2.TextChanged += new EventHandler(this.tbxLedgerTypeInHindi2_TextChanged);
      this.tbxLedgerTypeInHindi2.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxVoucherCode2.BackColor = SystemColors.Window;
      this.tbxVoucherCode2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode2.Enabled = false;
      this.tbxVoucherCode2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode2.Location = new Point(206, 359);
      this.tbxVoucherCode2.Name = "tbxVoucherCode2";
      this.tbxVoucherCode2.Size = new Size(262, 31);
      this.tbxVoucherCode2.TabIndex = 28;
      this.tbxVoucherCode2.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxVoucherDescription2.BackColor = SystemColors.Window;
      this.tbxVoucherDescription2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherDescription2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDescription2.Location = new Point(206, 405);
      this.tbxVoucherDescription2.Name = "tbxVoucherDescription2";
      this.tbxVoucherDescription2.Size = new Size(262, 31);
      this.tbxVoucherDescription2.TabIndex = 29;
      this.tbxAmount2.BackColor = SystemColors.Window;
      this.tbxAmount2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount2.Location = new Point(206, 450);
      this.tbxAmount2.Name = "tbxAmount2";
      this.tbxAmount2.Size = new Size(262, 31);
      this.tbxAmount2.TabIndex = 30;
      this.tbxAmount2.KeyPress += new KeyPressEventHandler(this.tbxAmount1_KeyPress);
      this.btnAddEdit2.BackColor = Color.LightBlue;
      this.btnAddEdit2.FadeOnFocus = true;
      ((Control) this.btnAddEdit2).Font = new Font("Arial Rounded MT Bold", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit2.ForeColor = Color.MediumBlue;
      this.btnAddEdit2.ForeColorOnFocus = Color.Red;
      this.btnAddEdit2.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit2.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit2).Image = (Image) Resources.plus;
      this.btnAddEdit2.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit2).Location = new Point(258, 491);
      ((Control) this.btnAddEdit2).Name = "btnAddEdit2";
      this.btnAddEdit2.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit2.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit2).Size = new Size(179, 39);
      ((Control) this.btnAddEdit2).TabIndex = 31;
      ((Control) this.btnAddEdit2).Text = "UPDATE";
      ((ButtonBase) this.btnAddEdit2).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit2).Click += new EventHandler(this.btnAddEdit2_Click);
      this.cbVoucherName1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbVoucherName1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbVoucherName1.BackColor = SystemColors.Window;
      this.cbVoucherName1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbVoucherName1.FlatStyle = FlatStyle.Popup;
      this.cbVoucherName1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbVoucherName1.FormattingEnabled = true;
      this.cbVoucherName1.Location = new Point(176, 316);
      this.cbVoucherName1.Name = "cbVoucherName1";
      this.cbVoucherName1.Size = new Size(304, 28);
      this.cbVoucherName1.TabIndex = 6;
      this.cbVoucherName1.SelectedIndexChanged += new EventHandler(this.cbVoucherName1_SelectedIndexChanged);
      this.cbVoucherName1.Validating += new CancelEventHandler(this.cbVoucherName1_Validating);
      this.cbLedgerType1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLedgerType1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLedgerType1.BackColor = SystemColors.Window;
      this.cbLedgerType1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLedgerType1.FlatStyle = FlatStyle.Popup;
      this.cbLedgerType1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType1.FormattingEnabled = true;
      this.cbLedgerType1.Location = new Point(176, 178);
      this.cbLedgerType1.Name = "cbLedgerType1";
      this.cbLedgerType1.Size = new Size(304, 28);
      this.cbLedgerType1.TabIndex = 3;
      this.cbLedgerType1.SelectedIndexChanged += new EventHandler(this.cbLedgerType1_SelectedIndexChanged);
      this.cbLedgerType1.KeyDown += new KeyEventHandler(this.cbLedgerType1_KeyDown);
      this.cbLedgerType1.Validating += new CancelEventHandler(this.cbLedgerType1_Validating);
      this.cbJammaOrNovae1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbJammaOrNovae1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbJammaOrNovae1.BackColor = SystemColors.Window;
      this.cbJammaOrNovae1.FlatStyle = FlatStyle.System;
      this.cbJammaOrNovae1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbJammaOrNovae1.FormattingEnabled = true;
      this.cbJammaOrNovae1.Items.AddRange(new object[2]
      {
        (object) "JAMMA",
        (object) "NOVAE"
      });
      this.cbJammaOrNovae1.Location = new Point(176, 132);
      this.cbJammaOrNovae1.Name = "cbJammaOrNovae1";
      this.cbJammaOrNovae1.Size = new Size(304, 28);
      this.cbJammaOrNovae1.TabIndex = 2;
      this.cbJammaOrNovae1.SelectedIndexChanged += new EventHandler(this.cbJammaOrNovae1_SelectedIndexChanged);
      this.cbJammaOrNovae1.KeyPress += new KeyPressEventHandler(this.cbJammaOrNovae1_KeyPress);
      this.cbJammaOrNovae1.Validating += new CancelEventHandler(this.cbJammaOrNovae1_Validating);
      ((Control) this.borderLabel19).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel19).AutoSize = true;
      ((Control) this.borderLabel19).BackColor = Color.Transparent;
      this.borderLabel19.BorderColor = Color.MidnightBlue;
      this.borderLabel19.BorderSize = 0.0f;
      ((Label) this.borderLabel19).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel19).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel19).Location = new Point(54, 367);
      ((Control) this.borderLabel19).Name = "borderLabel19";
      ((Control) this.borderLabel19).Size = new Size(116, 15);
      ((Control) this.borderLabel19).TabIndex = 18;
      ((Control) this.borderLabel19).Text = "VOUCHER CODE";
      ((Control) this.borderLabel18).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel18).AutoSize = true;
      ((Control) this.borderLabel18).BackColor = Color.Transparent;
      this.borderLabel18.BorderColor = Color.MidnightBlue;
      this.borderLabel18.BorderSize = 0.0f;
      ((Label) this.borderLabel18).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel18).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel18).Location = new Point(66, 230);
      ((Control) this.borderLabel18).Name = "borderLabel18";
      ((Control) this.borderLabel18).Size = new Size(104, 15);
      ((Control) this.borderLabel18).TabIndex = 15;
      ((Control) this.borderLabel18).Text = "LEDGER CODE";
      ((Control) this.borderLabel11).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel11).AutoSize = true;
      ((Control) this.borderLabel11).BackColor = Color.Transparent;
      this.borderLabel11.BorderColor = Color.MidnightBlue;
      this.borderLabel11.BorderSize = 0.0f;
      ((Label) this.borderLabel11).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel11).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel11).Location = new Point(35, 46);
      ((Control) this.borderLabel11).Name = "borderLabel11";
      ((Control) this.borderLabel11).Size = new Size(135, 15);
      ((Control) this.borderLabel11).TabIndex = 11;
      ((Control) this.borderLabel11).Text = "VOUCHER NUMBER";
      ((Control) this.borderLabel10).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel10).AutoSize = true;
      ((Control) this.borderLabel10).BackColor = Color.Transparent;
      this.borderLabel10.BorderColor = Color.MidnightBlue;
      this.borderLabel10.BorderSize = 0.0f;
      ((Label) this.borderLabel10).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel10).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel10).Location = new Point(105, 458);
      ((Control) this.borderLabel10).Name = "borderLabel10";
      ((Control) this.borderLabel10).Size = new Size(65, 15);
      ((Control) this.borderLabel10).TabIndex = 20;
      ((Control) this.borderLabel10).Text = "AMOUNT";
      ((Control) this.borderLabel9).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel9).AutoSize = true;
      ((Control) this.borderLabel9).BackColor = Color.Transparent;
      this.borderLabel9.BorderColor = Color.MidnightBlue;
      this.borderLabel9.BorderSize = 0.0f;
      ((Label) this.borderLabel9).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel9).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel9).Location = new Point(1, 413);
      ((Control) this.borderLabel9).Name = "borderLabel9";
      ((Control) this.borderLabel9).Size = new Size(169, 15);
      ((Control) this.borderLabel9).TabIndex = 19;
      ((Control) this.borderLabel9).Text = "VOUCHER DESCRIPTION";
      ((Control) this.borderLabel8).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel8).AutoSize = true;
      ((Control) this.borderLabel8).BackColor = Color.Transparent;
      this.borderLabel8.BorderColor = Color.MidnightBlue;
      this.borderLabel8.BorderSize = 0.0f;
      ((Label) this.borderLabel8).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel8).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel8).Location = new Point(54, 321);
      ((Control) this.borderLabel8).Name = "borderLabel8";
      ((Control) this.borderLabel8).Size = new Size(116, 15);
      ((Control) this.borderLabel8).TabIndex = 17;
      ((Control) this.borderLabel8).Text = "VOUCHER NAME";
      ((Control) this.borderLabel7).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel7).AutoSize = true;
      ((Control) this.borderLabel7).BackColor = Color.Transparent;
      this.borderLabel7.BorderColor = Color.MidnightBlue;
      this.borderLabel7.BorderSize = 0.0f;
      ((Label) this.borderLabel7).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel7).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel7).Location = new Point(13, 276);
      ((Control) this.borderLabel7).Name = "borderLabel7";
      ((Control) this.borderLabel7).Size = new Size(157, 15);
      ((Control) this.borderLabel7).TabIndex = 16;
      ((Control) this.borderLabel7).Text = "LEDGER TYPE IN HINDI";
      ((Control) this.borderLabel6).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel6).AutoSize = true;
      ((Control) this.borderLabel6).BackColor = Color.Transparent;
      this.borderLabel6.BorderColor = Color.MidnightBlue;
      this.borderLabel6.BorderSize = 0.0f;
      ((Label) this.borderLabel6).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel6).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel6).Location = new Point(71, 184);
      ((Control) this.borderLabel6).Name = "borderLabel6";
      ((Control) this.borderLabel6).Size = new Size(99, 15);
      ((Control) this.borderLabel6).TabIndex = 14;
      ((Control) this.borderLabel6).Text = "LEDGER TYPE";
      ((Control) this.borderLabel5).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel5).AutoSize = true;
      ((Control) this.borderLabel5).BackColor = Color.Transparent;
      this.borderLabel5.BorderColor = Color.MidnightBlue;
      this.borderLabel5.BorderSize = 0.0f;
      ((Label) this.borderLabel5).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel5).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel5).Location = new Point(44, 138);
      ((Control) this.borderLabel5).Name = "borderLabel5";
      ((Control) this.borderLabel5).Size = new Size(126, 15);
      ((Control) this.borderLabel5).TabIndex = 13;
      ((Control) this.borderLabel5).Text = "JAMMA OR NOVAE";
      ((Control) this.borderLabel4).Anchor = AnchorStyles.Top;
      ((Control) this.borderLabel4).AutoSize = true;
      ((Control) this.borderLabel4).BackColor = Color.Transparent;
      this.borderLabel4.BorderColor = Color.MidnightBlue;
      this.borderLabel4.BorderSize = 0.0f;
      ((Label) this.borderLabel4).FlatStyle = FlatStyle.Popup;
      ((Control) this.borderLabel4).Font = new Font("Arial Rounded MT Bold", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.borderLabel4).Location = new Point(57, 93);
      ((Control) this.borderLabel4).Name = "borderLabel4";
      ((Control) this.borderLabel4).Size = new Size(113, 15);
      ((Control) this.borderLabel4).TabIndex = 12;
      ((Control) this.borderLabel4).Text = "VOUCHER DATE";
      this.tbxVoucherNumber1.BackColor = SystemColors.Window;
      this.tbxVoucherNumber1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNumber1.Enabled = false;
      this.tbxVoucherNumber1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNumber1.Location = new Point(176, 41);
      this.tbxVoucherNumber1.Name = "tbxVoucherNumber1";
      this.tbxVoucherNumber1.Size = new Size(304, 31);
      this.tbxVoucherNumber1.TabIndex = 0;
      this.tbxVoucherNumber1.KeyPress += new KeyPressEventHandler(this.tbxVoucherNumber1_KeyPress);
      this.tbxVoucherDate1.BackColor = SystemColors.Window;
      this.tbxVoucherDate1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherDate1.Enabled = false;
      this.tbxVoucherDate1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDate1.Location = new Point(176, 89);
      this.tbxVoucherDate1.Name = "tbxVoucherDate1";
      this.tbxVoucherDate1.Size = new Size(304, 31);
      this.tbxVoucherDate1.TabIndex = 1;
      this.tbxVoucherDate1.KeyPress += new KeyPressEventHandler(this.tbxVoucherDate1_KeyPress);
      this.tbxLedgerCode1.BackColor = SystemColors.Window;
      this.tbxLedgerCode1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode1.Enabled = false;
      this.tbxLedgerCode1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode1.Location = new Point(176, 225);
      this.tbxLedgerCode1.Name = "tbxLedgerCode1";
      this.tbxLedgerCode1.Size = new Size(304, 31);
      this.tbxLedgerCode1.TabIndex = 4;
      this.tbxLedgerCode1.Enter += new EventHandler(this.tbxLedgerCode1_Enter);
      this.tbxLedgerCode1.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxLedgerTypeInHindi1.BackColor = SystemColors.Window;
      this.tbxLedgerTypeInHindi1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInHindi1.Enabled = false;
      this.tbxLedgerTypeInHindi1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInHindi1.Location = new Point(176, 270);
      this.tbxLedgerTypeInHindi1.Name = "tbxLedgerTypeInHindi1";
      this.tbxLedgerTypeInHindi1.Size = new Size(304, 31);
      this.tbxLedgerTypeInHindi1.TabIndex = 5;
      this.tbxLedgerTypeInHindi1.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxVoucherCode1.BackColor = SystemColors.Window;
      this.tbxVoucherCode1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode1.Enabled = false;
      this.tbxVoucherCode1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode1.Location = new Point(176, 363);
      this.tbxVoucherCode1.Name = "tbxVoucherCode1";
      this.tbxVoucherCode1.Size = new Size(304, 31);
      this.tbxVoucherCode1.TabIndex = 7;
      this.tbxVoucherCode1.KeyPress += new KeyPressEventHandler(this.tbxLedgerCode1_KeyPress);
      this.tbxVoucherDescription1.BackColor = SystemColors.Window;
      this.tbxVoucherDescription1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherDescription1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherDescription1.Location = new Point(176, 409);
      this.tbxVoucherDescription1.Name = "tbxVoucherDescription1";
      this.tbxVoucherDescription1.Size = new Size(304, 31);
      this.tbxVoucherDescription1.TabIndex = 8;
      this.tbxAmount1.BackColor = SystemColors.Window;
      this.tbxAmount1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount1.Location = new Point(176, 454);
      this.tbxAmount1.Name = "tbxAmount1";
      this.tbxAmount1.Size = new Size(304, 31);
      this.tbxAmount1.TabIndex = 9;
      this.tbxAmount1.TextChanged += new EventHandler(this.tbxAmount1_TextChanged);
      this.tbxAmount1.KeyPress += new KeyPressEventHandler(this.tbxAmount1_KeyPress);
      this.tbxAmount1.Validating += new CancelEventHandler(this.tbxAmount1_Validating);
      this.btnAddEdit1.BackColor = Color.LightBlue;
      this.btnAddEdit1.FadeOnFocus = true;
      ((Control) this.btnAddEdit1).Font = new Font("Arial Rounded MT Bold", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit1.ForeColor = Color.MediumBlue;
      this.btnAddEdit1.ForeColorOnFocus = Color.Red;
      this.btnAddEdit1.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit1.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit1).Image = (Image) Resources.plus;
      this.btnAddEdit1.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit1).Location = new Point(246, 495);
      ((Control) this.btnAddEdit1).Name = "btnAddEdit1";
      this.btnAddEdit1.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit1.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit1).Size = new Size(179, 39);
      ((Control) this.btnAddEdit1).TabIndex = 10;
      ((Control) this.btnAddEdit1).Text = "UPDATE";
      ((ButtonBase) this.btnAddEdit1).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit1).Click += new EventHandler(this.btnAddEdit1_Click);
      ((Control) this.panel1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.panel1).BackColor = Color.PowderBlue;
      ((Control) this.panel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.panel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderColor = SystemColors.HotTrack;
      this.panel1.BorderStyle = BorderStyles.Single;
      this.panel1.CaptionBeginColor = Color.PowderBlue;
      this.panel1.CaptionEndColor = Color.AliceBlue;
      this.panel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.panel1.CaptionHeight = 22;
      this.panel1.CaptionPosition = CaptionPositions.Top;
      this.panel1.CaptionText = "EDIT VOUCHER";
      this.panel1.CaptionVisible = true;
      ((Control) this.panel1).Controls.Add((Control) this.cbVoucherName1);
      ((Control) this.panel1).Controls.Add((Control) this.cbLedgerType1);
      ((Control) this.panel1).Controls.Add((Control) this.tbxVoucherNumber1);
      ((Control) this.panel1).Controls.Add((Control) this.cbJammaOrNovae1);
      ((Control) this.panel1).Controls.Add((Control) this.btnAddEdit1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel19);
      ((Control) this.panel1).Controls.Add((Control) this.tbxAmount1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel18);
      ((Control) this.panel1).Controls.Add((Control) this.tbxVoucherDescription1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel11);
      ((Control) this.panel1).Controls.Add((Control) this.tbxVoucherCode1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel10);
      ((Control) this.panel1).Controls.Add((Control) this.tbxLedgerTypeInHindi1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel9);
      ((Control) this.panel1).Controls.Add((Control) this.tbxLedgerCode1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel8);
      ((Control) this.panel1).Controls.Add((Control) this.tbxVoucherDate1);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel7);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel4);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel6);
      ((Control) this.panel1).Controls.Add((Control) this.borderLabel5);
      ((Control) this.panel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.panel1).ForeColor = Color.DarkBlue;
      this.panel1.GradientDirection = LinearGradientMode.Vertical;
      this.panel1.GradientEnd = SystemColors.ControlLight;
      this.panel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.panel1).Location = new Point(10, 9);
      ((Control) this.panel1).Name = "panel1";
      this.panel1.PanelIcon = (Icon) null;
      this.panel1.PanelIconVisible = false;
      ((Control) this.panel1).Size = new Size(492, 611);
      ((Control) this.panel1).TabIndex = 74;
      this.panel1.TextAntialias = true;
      ((Control) this.panel2).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.panel2).BackColor = Color.PowderBlue;
      ((Control) this.panel2).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.panel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderColor = SystemColors.HotTrack;
      this.panel2.BorderStyle = BorderStyles.Single;
      this.panel2.CaptionBeginColor = Color.PowderBlue;
      this.panel2.CaptionEndColor = Color.AliceBlue;
      this.panel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.panel2.CaptionHeight = 22;
      this.panel2.CaptionPosition = CaptionPositions.Top;
      this.panel2.CaptionText = "ADD ADJUSTMENT VOUCHER";
      this.panel2.CaptionVisible = true;
      ((Control) this.panel2).Controls.Add((Control) this.cbVoucherName2);
      ((Control) this.panel2).Controls.Add((Control) this.cbLedgerType2);
      ((Control) this.panel2).Controls.Add((Control) this.tbxVoucherNumber2);
      ((Control) this.panel2).Controls.Add((Control) this.cbJammaOrNovae2);
      ((Control) this.panel2).Controls.Add((Control) this.btnAddEdit2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel2);
      ((Control) this.panel2).Controls.Add((Control) this.tbxAmount2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel3);
      ((Control) this.panel2).Controls.Add((Control) this.tbxVoucherDescription2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel12);
      ((Control) this.panel2).Controls.Add((Control) this.tbxVoucherCode2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel13);
      ((Control) this.panel2).Controls.Add((Control) this.tbxLedgerTypeInHindi2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel14);
      ((Control) this.panel2).Controls.Add((Control) this.tbxLedgerCode2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel15);
      ((Control) this.panel2).Controls.Add((Control) this.tbxVoucherDate2);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel16);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel21);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel17);
      ((Control) this.panel2).Controls.Add((Control) this.borderLabel20);
      ((Control) this.panel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.panel2).ForeColor = Color.DarkBlue;
      this.panel2.GradientDirection = LinearGradientMode.Vertical;
      this.panel2.GradientEnd = SystemColors.ControlLight;
      this.panel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.panel2).Location = new Point(508, 9);
      ((Control) this.panel2).Name = "panel2";
      this.panel2.PanelIcon = (Icon) null;
      this.panel2.PanelIconVisible = false;
      ((Control) this.panel2).Size = new Size(488, 611);
      ((Control) this.panel2).TabIndex = 75;
      this.panel2.TextAntialias = true;
      ((Control) this.panel2).Visible = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormEditVoucher);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "EDIT VOUCHER";
      this.Load += new EventHandler(this.FormEditVoucher_Load);
      ((Control) this.panel1).ResumeLayout(false);
      ((Control) this.panel1).PerformLayout();
      ((Control) this.panel2).ResumeLayout(false);
      ((Control) this.panel2).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
