

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

namespace PawnManagement.Forms
{
  public class FormChangeShopCode : Form
  {
    private List<string> lstPledgeBillNumbers = new List<string>();
    private string ledgerCode1;
    private string voucherCode1;
    private string ledgerCodeInterest1;
    private string voucherCodeInterestGirvi1;
    private string voucherCodeInterestChoot1;
    private string ledgerName1;
    private string voucherName1;
    private string ledgerNameInterest1;
    private string voucherNameInterestGirvi1;
    private string voucherNameInterestChoot1;
    private string ledgerCode2;
    private string voucherCode2;
    private string ledgerCodeInterest2;
    private string voucherCodeInterestGirvi2;
    private string voucherCodeInterestChoot2;
    private string ledgerName2;
    private string voucherName2;
    private string ledgerNameInterest2;
    private string voucherNameInterestGirvi2;
    private string voucherNameInterestChoot2;
    private IContainer components = (IContainer) null;
    private HeaderPanel headerPanel4;
    private ComboBox cbShopCodes1;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private HeaderPanel headerPanel1;
    private ComboBox cbShopCodes2;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel2;
    private TextBox tbxBillNumber1;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel3;
    private TextBox tbxBillNumber2;
    private GlassButton glassButton7;
    private GlassButton glassButton8;
    private GlassButton btnChange;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private GlassButton glassButton12;
    private GlassButton glassButton11;
    private HeaderPanel headerPanel6;

    public FormChangeShopCode() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormChangeShopCode_Load(object sender, EventArgs e)
    {
      this.cbShopCodes1.Select();
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxBillNumber1.MaxLength = 7;
      else
        this.tbxBillNumber1.MaxLength = 6;
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxBillNumber2.MaxLength = 7;
      else
        this.tbxBillNumber2.MaxLength = 6;
      this.getShopCodes1();
      this.getShopCodes2();
    }

    private void UpdateTableVouchers()
    {
      try
      {
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxBillNumber1.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes1.Text);
        string str1 = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        string str2 = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
        string s1 = voucherNumberAndDate.Rows[0]["Amount"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(str2))
        {
          this.getVoucherNumberAndDate(this.tbxBillNumber1.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes1.Text);
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
          string s2 = voucherNumberAndDate.Rows[0]["Amount"].ToString();
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str2), str1, this.voucherCode2, this.voucherName2, this.tbxBillNumber2.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes2.Text, "G1", "NOVAE", double.Parse(s1));
          if (!FormPrintSettings.boolReduceFirstMonthInterest())
            return;
          PawnManagementClass.updatetblVouchers(DateTime.Parse(str2), (int.Parse(str1) + 1).ToString(), this.voucherCodeInterestGirvi2, this.voucherNameInterestGirvi2, this.tbxBillNumber2.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes2.Text, "B1", "JAMMA", double.Parse(s2));
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

    private void getLedgerAndVoucherCode1()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblShopDetails where shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes1.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getledgerandvouchercode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form pledge.getledgerandvouchercode" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.ledgerCode1 = dataTable2.Rows[0]["ledgercode"].ToString();
          this.voucherCode1 = dataTable2.Rows[0]["vouchercode"].ToString();
          this.ledgerCodeInterest1 = dataTable2.Rows[0]["ledgercodeinterest"].ToString();
          this.voucherCodeInterestGirvi1 = dataTable2.Rows[0]["vouchercodeinterestgirvi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form pledge.getledgerandvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLedgerAndVoucherCode2()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblShopDetails where shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes2.Text.ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.getledgerandvouchercode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in form pledge.getledgerandvouchercode" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          this.ledgerCode2 = dataTable2.Rows[0]["ledgercode"].ToString();
          this.voucherCode2 = dataTable2.Rows[0]["vouchercode"].ToString();
          this.ledgerCodeInterest2 = dataTable2.Rows[0]["ledgercodeinterest"].ToString();
          this.voucherCodeInterestGirvi2 = dataTable2.Rows[0]["vouchercodeinterestgirvi"].ToString();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form pledge.getledgerandvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
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

    private void getShopCodes1()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes1.Items.Add((object) row["ShopCode"].ToString());
    }

    private void getShopCodes2()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes2.Items.Add((object) row["ShopCode"].ToString());
    }

    private void cbShopCodes1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillNumber1.Select();
    }

    private void cbShopCodes1_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbShopCodes1.Items.Contains((object) this.cbShopCodes1.Text))
      {
        this.cbShopCodes1.Select();
      }
      else
      {
        this.getBillNumbers();
        this.tbxBillNumber1.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxBillNumber1.AutoCompleteCustomSource.Clear();
        this.tbxBillNumber1.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
        this.getLedgerAndVoucherCode1();
        this.ledgerName1 = LedgerMaster.getLedgerName(this.ledgerCode1);
        this.ledgerNameInterest1 = LedgerMaster.getLedgerName(this.ledgerCodeInterest1);
        this.voucherName1 = VoucherMasterClass.getVoucherName(this.voucherCode1);
        this.voucherNameInterestGirvi1 = VoucherMasterClass.getVoucherName(this.voucherCodeInterestGirvi1);
      }
    }

    private void tbxBillNumber1_KeyPress(object sender, KeyPressEventArgs e)
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

    private bool checkWhetherPledgeBillNumberAlreadyExists()
    {
      try
      {
        string strError = "";
        string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and  redeemed = 'N' and ShopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber1.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes1.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgebillnumberalreadyexists()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgeBillNumberAlreadyExists", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return false;
    }

    private bool checkWhetherPledgeBillNumberAlreadyExists2()
    {
      try
      {
        string strError = "";
        string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and ShopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber2.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes2.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgebillnumberalreadyexists()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.checkwhetherpledgeBillNumberAlreadyExists", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return false;
    }

    private void tbxBillNumber1_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              if (this.checkWhetherPledgeBillNumberAlreadyExists())
                break;
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              if (!this.checkWhetherPledgeBillNumberAlreadyExists())
              {
                (sender as TextBox).Select();
                (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              }
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
        this.tbxBillNumber1.ResetText();
        this.tbxBillNumber1.Select();
        this.Refresh();
      }
    }

    private void tbxBillNumber1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and redeemed = 'N' and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber1.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes1.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.tbxBillNumber1.ForeColor = Color.Navy;
      else
        this.tbxBillNumber1.ForeColor = Color.Red;
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
          new OleDbParameter("ShopCode", (object) this.cbShopCodes1.Text)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form Redemption .getBillNumbers()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          int index = 0;
          this.lstPledgeBillNumbers.Clear();
          for (; index < dataTable2.Rows.Count; ++index)
            this.lstPledgeBillNumbers.Add(dataTable2.Rows[index].Field<string>("BillNumber"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbShopCodes2_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbShopCodes2.Items.Contains((object) this.cbShopCodes2.Text))
      {
        this.cbShopCodes2.Select();
      }
      else
      {
        this.getBillNumbers();
        this.tbxBillNumber2.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxBillNumber2.AutoCompleteCustomSource.Clear();
        this.tbxBillNumber2.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
        this.getLedgerAndVoucherCode2();
        this.ledgerName2 = LedgerMaster.getLedgerName(this.ledgerCode2);
        this.ledgerNameInterest2 = LedgerMaster.getLedgerName(this.ledgerCodeInterest2);
        this.voucherName2 = VoucherMasterClass.getVoucherName(this.voucherCode2);
        this.voucherNameInterestGirvi2 = VoucherMasterClass.getVoucherName(this.voucherCodeInterestGirvi2);
      }
    }

    private void tbxBillNumber2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnChange).Focus();
    }

    private void tbxBillNumber2_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber2.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes2.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.tbxBillNumber2.ForeColor = Color.Red;
      else
        this.tbxBillNumber2.ForeColor = Color.Navy;
    }

    private void tbxBillNumber1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbShopCodes2.Select();
    }

    private void tbxBillNumber2_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              if (!this.checkWhetherPledgeBillNumberAlreadyExists2())
                break;
              (sender as TextBox).Select();
              (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              if (this.checkWhetherPledgeBillNumberAlreadyExists2())
              {
                (sender as TextBox).Select();
                (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
              }
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
        this.tbxBillNumber2.ResetText();
        this.tbxBillNumber2.Select();
        this.Refresh();
      }
    }

    private void cbShopCodes2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillNumber2.Select();
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      if (!this.checkWhetherPledgeBillNumberAlreadyExists() || this.checkWhetherPledgeBillNumberAlreadyExists2())
        return;
      this.change();
      this.reset();
    }

    private void reset()
    {
      this.cbShopCodes1.Text = "";
      this.tbxBillNumber1.Text = "";
      this.tbxBillNumber2.Text = "";
      this.cbShopCodes2.Text = "";
      this.cbShopCodes1.Select();
    }

    private void change()
    {
      try
      {
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(this.tbxBillNumber1.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes1.Text);
        if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
        {
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          string rokadDate = voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
          voucherNumberAndDate.Rows[0]["Amount"].ToString();
          if (!PawnManagementClass.checkIfRokadFinished(rokadDate))
          {
            this.updateTablePledge();
            this.updateTablePledgeArticles();
            this.UpdateTableVouchers();
          }
          else
          {
            int num = (int) MessageBox.Show("Cannot be updated in Rokad, as rokad has already been finished for this day");
          }
        }
        else
        {
          this.updateTablePledge();
          this.updateTablePledgeArticles();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledgeEdit.UpdateTableVouchers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void updateTablePledge()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblPledge set BillNumber = @BillNumber2,ShopCode = @ShopCode2 where shopCode = @ShopCode1 and BillNumber = @BillNumber1", new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber2", (object) this.tbxBillNumber2.Text),
        new OleDbParameter("ShopCode2", (object) this.cbShopCodes2.Text),
        new OleDbParameter("ShopCode1", (object) this.cbShopCodes1.Text),
        new OleDbParameter("BillNumber1", (object) this.tbxBillNumber1.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.changePledgerBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private void updateTablePledgeArticles()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblPledgeArticles set BillNumber = @BillNumber2,ShopCode = @ShopCode2 where shopCode = @ShopCode1 and BillNumber = @BillNumber1", new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumber2", (object) this.tbxBillNumber2.Text),
        new OleDbParameter("ShopCode2", (object) this.cbShopCodes2.Text),
        new OleDbParameter("ShopCode1", (object) this.cbShopCodes1.Text),
        new OleDbParameter("BillNumber1", (object) this.tbxBillNumber1.Text)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form pledge.changePledgerBillNumberSeries", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private void cbShopCodes1_SelectedIndexChanged(object sender, EventArgs e) => this.getLedgerAndVoucherCode1();

    private void cbShopCodes2_SelectedIndexChanged(object sender, EventArgs e) => this.getLedgerAndVoucherCode2();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.headerPanel4 = new HeaderPanel();
      this.cbShopCodes1 = new ComboBox();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.cbShopCodes2 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.tbxBillNumber1 = new TextBox();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.tbxBillNumber2 = new TextBox();
      this.glassButton7 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.btnChange = new GlassButton();
      this.pictureBox1 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      this.SuspendLayout();
      ((Control) this.headerPanel4).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel4.CaptionEndColor = Color.PeachPuff;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "SELECT LICENSE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbShopCodes1);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.GradientEnd = Color.Ivory;
      this.headerPanel4.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel4).Location = new Point(11, 31);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(330, 60);
      ((Control) this.headerPanel4).TabIndex = 71;
      this.headerPanel4.TextAntialias = true;
      this.cbShopCodes1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes1.BackColor = Color.Ivory;
      this.cbShopCodes1.DropDownWidth = 600;
      this.cbShopCodes1.FormattingEnabled = true;
      this.cbShopCodes1.Location = new Point(7, 6);
      this.cbShopCodes1.Name = "cbShopCodes1";
      this.cbShopCodes1.Size = new Size(313, 23);
      this.cbShopCodes1.TabIndex = 25;
      this.cbShopCodes1.SelectedIndexChanged += new EventHandler(this.cbShopCodes1_SelectedIndexChanged);
      this.cbShopCodes1.KeyDown += new KeyEventHandler(this.cbShopCodes1_KeyDown);
      this.cbShopCodes1.Validating += new CancelEventHandler(this.cbShopCodes1_Validating);
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
      ((Control) this.glassButton5).Location = new Point(39, 513);
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
      ((Control) this.glassButton6).Location = new Point(173, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel1.CaptionEndColor = Color.PeachPuff;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "SELECT LICENSE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbShopCodes2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Ivory;
      this.headerPanel1.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel1).Location = new Point(11, 33);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(301, 60);
      ((Control) this.headerPanel1).TabIndex = 72;
      this.headerPanel1.TextAntialias = true;
      this.cbShopCodes2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes2.BackColor = Color.Ivory;
      this.cbShopCodes2.DropDownWidth = 600;
      this.cbShopCodes2.FormattingEnabled = true;
      this.cbShopCodes2.Location = new Point(7, 6);
      this.cbShopCodes2.Name = "cbShopCodes2";
      this.cbShopCodes2.Size = new Size(282, 23);
      this.cbShopCodes2.TabIndex = 25;
      this.cbShopCodes2.SelectedIndexChanged += new EventHandler(this.cbShopCodes2_SelectedIndexChanged);
      this.cbShopCodes2.KeyDown += new KeyEventHandler(this.cbShopCodes2_KeyDown);
      this.cbShopCodes2.Validating += new CancelEventHandler(this.cbShopCodes2_Validating);
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
      ((Control) this.glassButton1).Location = new Point(8, 513);
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
      ((Control) this.glassButton2).Location = new Point(142, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel2.CaptionEndColor = Color.PeachPuff;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "BILL NUMBER";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBillNumber1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Ivory;
      this.headerPanel2.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel2).Location = new Point(12, 107);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(330, 60);
      ((Control) this.headerPanel2).TabIndex = 72;
      this.headerPanel2.TextAntialias = true;
      this.tbxBillNumber1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxBillNumber1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber1.BackColor = SystemColors.Info;
      this.tbxBillNumber1.BorderStyle = BorderStyle.None;
      this.tbxBillNumber1.Dock = DockStyle.Fill;
      this.tbxBillNumber1.Font = new Font("Segoe UI", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber1.Location = new Point(0, 0);
      this.tbxBillNumber1.Name = "tbxBillNumber1";
      this.tbxBillNumber1.Size = new Size(328, 32);
      this.tbxBillNumber1.TabIndex = 2;
      this.tbxBillNumber1.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber1.TextChanged += new EventHandler(this.tbxBillNumber1_TextChanged);
      this.tbxBillNumber1.KeyDown += new KeyEventHandler(this.tbxBillNumber1_KeyDown);
      this.tbxBillNumber1.KeyPress += new KeyPressEventHandler(this.tbxBillNumber1_KeyPress);
      this.tbxBillNumber1.Validating += new CancelEventHandler(this.tbxBillNumber1_Validating);
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
      ((Control) this.glassButton3).Location = new Point(37, 513);
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
      ((Control) this.glassButton4).Location = new Point(171, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel3.CaptionEndColor = Color.PeachPuff;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "BILL NUMBER";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxBillNumber2);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Ivory;
      this.headerPanel3.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel3).Location = new Point(11, 98);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(301, 60);
      ((Control) this.headerPanel3).TabIndex = 73;
      this.headerPanel3.TextAntialias = true;
      this.tbxBillNumber2.BackColor = SystemColors.Info;
      this.tbxBillNumber2.BorderStyle = BorderStyle.None;
      this.tbxBillNumber2.Dock = DockStyle.Fill;
      this.tbxBillNumber2.Font = new Font("Segoe UI", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber2.Location = new Point(0, 0);
      this.tbxBillNumber2.Name = "tbxBillNumber2";
      this.tbxBillNumber2.Size = new Size(299, 32);
      this.tbxBillNumber2.TabIndex = 2;
      this.tbxBillNumber2.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber2.TextChanged += new EventHandler(this.tbxBillNumber2_TextChanged);
      this.tbxBillNumber2.KeyDown += new KeyEventHandler(this.tbxBillNumber2_KeyDown);
      this.tbxBillNumber2.KeyPress += new KeyPressEventHandler(this.tbxBillNumber1_KeyPress);
      this.tbxBillNumber2.Validating += new CancelEventHandler(this.tbxBillNumber2_Validating);
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
      ((Control) this.glassButton7).Location = new Point(6, 513);
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
      ((Control) this.glassButton8).Location = new Point(140, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 1;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnChange).Anchor = AnchorStyles.None;
      this.btnChange.BackColor = Color.LightBlue;
      this.btnChange.FadeOnFocus = true;
      ((Control) this.btnChange).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnChange.ForeColor = Color.MediumBlue;
      this.btnChange.ForeColorOnFocus = Color.Red;
      this.btnChange.ForeColorOnLeave = Color.MediumBlue;
      this.btnChange.GlowColor = Color.White;
      this.btnChange.InnerBorderColor = Color.Transparent;
      ((Control) this.btnChange).Location = new Point(350, 271);
      ((Control) this.btnChange).Name = "btnChange";
      this.btnChange.OuterBorderColor = Color.MediumSlateBlue;
      this.btnChange.ShineColor = Color.Transparent;
      ((Control) this.btnChange).Size = new Size(150, 40);
      ((Control) this.btnChange).TabIndex = 76;
      ((Control) this.btnChange).Text = "CHANGE";
      ((Control) this.btnChange).Click += new EventHandler(this.btnChange_Click);
      this.pictureBox1.Anchor = AnchorStyles.None;
      this.pictureBox1.Image = (Image) Resources.rightarrow31;
      this.pictureBox1.Location = new Point(389, 86);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(71, 50);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 77;
      this.pictureBox1.TabStop = false;
      this.pictureBox2.Anchor = AnchorStyles.None;
      this.pictureBox2.Image = (Image) Resources.rightarrow31;
      this.pictureBox2.Location = new Point(389, 152);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(71, 50);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 78;
      this.pictureBox2.TabStop = false;
      ((Control) this.headerPanel5).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel5.CaptionEndColor = Color.PeachPuff;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "From";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.headerPanel2);
      ((Control) this.headerPanel5).Controls.Add((Control) this.headerPanel4);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel5.GradientEnd = Color.Ivory;
      this.headerPanel5.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel5).Location = new Point(22, 29);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(356, 226);
      ((Control) this.headerPanel5).TabIndex = 79;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton9).Location = new Point(61, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 0;
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
      ((Control) this.glassButton10).Location = new Point(195, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 1;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(165, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.glassButton11).Location = new Point(31, 513);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(128, 35);
      ((Control) this.glassButton11).TabIndex = 0;
      ((Control) this.glassButton11).Text = "&SAVE";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.None;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel6.CaptionEndColor = Color.PeachPuff;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "To";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.headerPanel3);
      ((Control) this.headerPanel6).Controls.Add((Control) this.headerPanel1);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel6.GradientEnd = Color.Ivory;
      this.headerPanel6.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel6).Location = new Point(470, 29);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(330, 226);
      ((Control) this.headerPanel6).TabIndex = 80;
      this.headerPanel6.TextAntialias = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackgroundImage = (Image) Resources.yellow1;
      this.ClientSize = new Size(829, 383);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.btnChange);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.headerPanel6);
      this.Name = nameof (FormChangeShopCode);
      this.Text = nameof (FormChangeShopCode);
      this.Load += new EventHandler(this.FormChangeShopCode_Load);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
