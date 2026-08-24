
using CrystalDecisions.CrystalReports.Engine;
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
  public class FormReBill : Form
  {
    private string ch = "";
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
    private ReportDocument rdCustomerCopy = new ReportDocument();
    private ReportDocument rdOfficeCopy = new ReportDocument();
    private string currentShopCode = "";
    private DateTime currentBillingDate;
    private IContainer components = (IContainer) null;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel5;
    private TextBox tbxOldBillNumber;
    private GlassButton btnSave;
    private HeaderPanel headerPanel1;
    private TextBox tbxAmount;
    private HeaderPanel headerPanel2;
    private TextBox tbxNewBillNumber;
    private ComboBox cbShopCodes;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private HeaderPanel headerPanel3;
    private TextBox tbxInterestRate;
    private GlassButton glassButton1;

    public FormReBill() => this.InitializeComponent();

    public FormReBill(string CURRENTSHOPCODE, DateTime CURRENTBILLINGDATE)
    {
      this.currentShopCode = CURRENTSHOPCODE;
      this.currentBillingDate = CURRENTBILLINGDATE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormReBill_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
      {
        this.tbxNewBillNumber.MaxLength = 7;
        this.tbxOldBillNumber.MaxLength = 7;
      }
      this.getShopCodes();
      this.cbShopCodes.Text = this.currentShopCode;
      this.cbShopCodes.Select();
    }

    private string strGetPledgeBillNumber()
    {
      if (!PawnManagement.PledgeClass.checkifpledgetableempty(this.cbShopCodes.Text))
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
                  char ch = this.ch[0];
                  this.ch = (ch != '0' ? (char) ((uint) ch + 1U) : 'A').ToString();
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

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void printPledge(string BillNumber)
    {
      try
      {
        string defaultPrintFormat = FormPrintSettings.getDefaultPrintFormat();
        string formatCustomerCopy = FormPrintSettings.getDefaultPrintFormatCustomerCopy();
        string filePath1 = "Reports\\PledgeBill\\" + defaultPrintFormat;
        string filePath2 = "Reports\\PledgeBill\\" + formatCustomerCopy;
        this.rdOfficeCopy = FormDuplicateBill.getPledgeReportDocument(defaultPrintFormat, BillNumber, this.cbShopCodes.Text.Trim(), filePath1);
        this.rdCustomerCopy = FormDuplicateBill.getPledgeReportDocument(formatCustomerCopy, BillNumber, this.cbShopCodes.Text.Trim(), filePath2);
        this.rdOfficeCopy.PrintToPrinter(1, false, 1, 1);
        this.rdCustomerCopy.PrintToPrinter(1, false, 1, 1);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        if (this.validateBillNumber(this.tbxOldBillNumber.Text))
        {
          if (this.validateBillNumber(this.tbxNewBillNumber.Text))
          {
            if (this.tbxAmount.Text != "" && double.Parse(this.tbxAmount.Text) > 0.0)
            {
              if (this.tbxInterestRate.Text != "" && double.Parse(this.tbxInterestRate.Text) > 0.0)
              {
                if (DialogResult.Yes == MessageBox.Show("Save?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                  this.SAVE();
                  this.InsertIntoVouchersTable();
                  if (DialogResult.Yes == MessageBox.Show("Print?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    this.printPledge(this.tbxNewBillNumber.Text);
                  this.reset();
                }
              }
              else
                this.tbxInterestRate.Select();
            }
            else
              this.tbxAmount.Select();
          }
          else
            this.tbxNewBillNumber.Select();
        }
        else
          this.tbxOldBillNumber.Select();
      }
      else
      {
        this.cbShopCodes.Select();
        this.cbShopCodes.ForeColor = Color.Red;
      }
      this.refreshSidePanel();
    }

    private void reset()
    {
      this.cbShopCodes.Text = this.currentShopCode;
      this.tbxOldBillNumber.Text = "";
      this.tbxNewBillNumber.Text = "";
      this.tbxAmount.Text = "";
      this.cbShopCodes.Select();
    }

    public void refreshSidePanel() => this.currentBillingDate.ToString("dd/MM/yyyy");

    private void InsertIntoVouchersTable()
    {
      try
      {
        DataTable voucherNumberAndDate1 = this.getVoucherNumberAndDate(this.tbxOldBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text);
        if (voucherNumberAndDate1 != null && voucherNumberAndDate1.Rows.Count > 0)
        {
          string str = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
          string voucherCode1 = voucherNumberAndDate1.Rows[0]["voucherCode"].ToString();
          string voucherName1 = voucherNumberAndDate1.Rows[0]["voucherName"].ToString();
          string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
          if (!PawnManagementClass.checkIfRokadFinished(str))
          {
            PawnManagementClass.insertIntotblVouchers(DateTime.Parse(str), maxOfVoucherNumber, voucherCode1, voucherName1, this.tbxNewBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text, "G1", "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
            DataTable voucherNumberAndDate2 = this.getVoucherNumberAndDate(this.tbxOldBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text);
            if (voucherNumberAndDate2 == null || voucherNumberAndDate2.Rows.Count <= 0)
              return;
            voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
            string voucherCode2 = voucherNumberAndDate2.Rows[0]["voucherCode"].ToString();
            string voucherName2 = voucherNumberAndDate2.Rows[0]["voucherName"].ToString();
            string s = (int.Parse(this.tbxAmount.Text.Trim().ToString()) * int.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200).ToString();
            if (FormPrintSettings.boolReduceFirstMonthInterest())
              PawnManagementClass.insertIntotblVouchers(DateTime.Parse(str), (int.Parse(maxOfVoucherNumber) + 1).ToString(), voucherCode2, voucherName2, this.tbxNewBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text, "B1", "JAMMA", double.Parse(s));
          }
          else
          {
            int num = (int) MessageBox.Show("Cannot be updated in Rokad, as rokad has already been finished for this day");
          }
        }
        else
        {
          int num = int.Parse(this.tbxAmount.Text.Trim().ToString()) * int.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200;
          string s1 = num.ToString();
          string s2 = !(PawnManagementClass.getRokadDate() != "") ? DateTime.Now.ToString("dd/MM/yyyy") : DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy");
          string maxOfVoucherNumber = VoucherClass.getMaxOfVoucherNumber();
          PawnManagementClass.insertIntotblVouchers(DateTime.Parse(s2), maxOfVoucherNumber, this.voucherCode, this.voucherName, this.tbxNewBillNumber.Text.Trim().ToString() + " PledgeBillNumber " + this.cbShopCodes.Text, "G1", "NOVAE", double.Parse(this.tbxAmount.Text.Trim()));
          if (FormPrintSettings.boolReduceFirstMonthInterest())
          {
            DateTime voucherDate = DateTime.Parse(s2);
            num = int.Parse(maxOfVoucherNumber) + 1;
            string voucherNumber = num.ToString();
            string codeInterestGirvi = this.voucherCodeInterestGirvi;
            string nameInterestGirvi = this.voucherNameInterestGirvi;
            string voucherDesription = this.tbxNewBillNumber.Text.Trim().ToString() + " INTEREST GIRVI " + this.cbShopCodes.Text;
            double amount = double.Parse(s1);
            PawnManagementClass.insertIntotblVouchers(voucherDate, voucherNumber, codeInterestGirvi, nameInterestGirvi, voucherDesription, "B1", "JAMMA", amount);
          }
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

    public bool checkIfBillNumberIsRelease(string BillNumber, string ShopCode)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblPledge where BillNumber=@BillNumber AND ShopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber.Trim().ToString()));
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
          return false;
        }
        return dataTable2 != null && dataTable2.Rows.Count > 0 && !(dataTable2.Rows[0]["Redeemed"].ToString() == "N") && dataTable2.Rows[0]["Redeemed"].ToString() == "Y";
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private bool validateBillNumber(string BillNumber) => FormMain.BillNumberSeries == "SINGLE" ? PawnManagementClass.validateBillNumber(BillNumber) : PawnManagementClass.validateBillNumberDouble(BillNumber);

    private void SAVE()
    {
      DataTable pledgeBill = PawnManagement.PledgeClass.getPledgeBill(this.tbxOldBillNumber.Text, this.cbShopCodes.Text);
      DataTable pledgeArticlesClass = PledgeArticlesClass.getPledgeArticlesClass(this.tbxOldBillNumber.Text, this.cbShopCodes.Text);
      if (pledgeBill != null && pledgeBill.Rows.Count > 0)
      {
        string ShopCode = pledgeBill.Rows[0]["ShopCode"].ToString();
        string BillNumber = this.tbxNewBillNumber.Text.Trim();
        string BillDate = !PawnManagementClass.checkForValidateDate(this.currentBillingDate.ToString("dd/MM/yyyy")) ? DateTime.Now.ToString("dd/MM/yyyy") : this.currentBillingDate.ToString("dd/MM/yyyy");
        string customerCode = pledgeBill.Rows[0]["CustomerCode"].ToString();
        string CustomerName = pledgeBill.Rows[0]["CustomerName"].ToString();
        string DoorNumber = pledgeBill.Rows[0]["DoorNumber"].ToString();
        string Addr1 = pledgeBill.Rows[0]["Addr1"].ToString();
        string Addr2 = pledgeBill.Rows[0]["Addr2"].ToString();
        string Addr3 = pledgeBill.Rows[0]["Addr3"].ToString();
        string City = pledgeBill.Rows[0]["City"].ToString();
        string Pincode = pledgeBill.Rows[0]["Pincode"].ToString();
        string PhoneNumber = pledgeBill.Rows[0]["PhoneNumber"].ToString();
        string AmountInWords = ConvertNumbersToWords.ConvertNumberAsText(int.Parse(this.tbxAmount.Text));
        string Type = pledgeBill.Rows[0]["Type"].ToString();
        string GrossWeight = pledgeBill.Rows[0]["GrossWeight"].ToString();
        string Deduction = pledgeBill.Rows[0]["Deduction"].ToString();
        string NetWeight = pledgeBill.Rows[0]["NetWeight"].ToString();
        string PureWeight = pledgeBill.Rows[0]["PureWeight"].ToString();
        string text = this.tbxAmount.Text;
        string PresentValue = pledgeBill.Rows[0]["PresentValue"].ToString();
        string OldBillNumber;
        if (FormPrintSettings.boolMaintainOldestBillNumber())
        {
          OldBillNumber = pledgeBill.Rows[0]["OldBillNumber"].ToString();
          if (OldBillNumber.Trim() == "")
            OldBillNumber = pledgeBill.Rows[0]["BillNumber"].ToString() + "[" + pledgeBill.Rows[0]["Amount"].ToString() + "]";
        }
        else
          OldBillNumber = pledgeBill.Rows[0]["BillNumber"].ToString() + "[" + pledgeBill.Rows[0]["Amount"].ToString() + "]";
        string Reminder = pledgeBill.Rows[0]["Reminder"].ToString();
        string InterestRate = pledgeBill.Rows[0]["TEMP1"].ToString();
        string InterestRateDisplaySymbol = pledgeBill.Rows[0]["InterestRateDisplaySymbol"].ToString();
        string Redeemed = "N";
        string PledgeCreatedBy = pledgeBill.Rows[0]["PledgeCreatedBy"].ToString();
        string PledgeCreatedOn = pledgeBill.Rows[0]["PledgeCreatedOn"].ToString();
        string Temp5 = (double.Parse(this.tbxAmount.Text.Trim().ToString()) * double.Parse(this.tbxInterestRate.Text.Trim().ToString()) / 1200.0).ToString();
        string ArticlesWithoutHr = pledgeBill.Rows[0]["ArticlesWithoutHr"].ToString();
        string ArticlesWithHr = pledgeBill.Rows[0]["ArticlesWithHr"].ToString();
        string Articles = pledgeBill.Rows[0]["Articles"].ToString();
        string BilledBy = pledgeBill.Rows[0]["BilledbY"].ToString();
        this.savePledge(ShopCode, BillNumber, BillDate, customerCode, CustomerName, DoorNumber, Addr1, Addr2, Addr3, City, Pincode, PhoneNumber, AmountInWords, Type, GrossWeight, Deduction, NetWeight, PureWeight, text, PresentValue, OldBillNumber, Reminder, InterestRate, InterestRateDisplaySymbol, Redeemed, PledgeCreatedBy, PledgeCreatedOn, Temp5, ArticlesWithoutHr, ArticlesWithHr, Articles, BilledBy);
      }
      if (pledgeArticlesClass == null || pledgeArticlesClass.Rows.Count <= 0)
        return;
      PledgeArticlesClass.insertIntoPledgeArticles(this.cbShopCodes.Text, this.tbxNewBillNumber.Text, pledgeArticlesClass);
    }

    private void savePledge(
      string ShopCode,
      string BillNumber,
      string BillDate,
      string customerCode,
      string CustomerName,
      string DoorNumber,
      string Addr1,
      string Addr2,
      string Addr3,
      string City,
      string Pincode,
      string PhoneNumber,
      string AmountInWords,
      string Type,
      string GrossWeight,
      string Deduction,
      string NetWeight,
      string PureWeight,
      string amount,
      string PresentValue,
      string OldBillNumber,
      string Reminder,
      string InterestRate,
      string InterestRateDisplaySymbol,
      string Redeemed,
      string PledgeCreatedBy,
      string PledgeCreatedOn,
      string Temp5,
      string ArticlesWithoutHr,
      string ArticlesWithHr,
      string Articles,
      string BilledBy)
    {
      string strError = "";
      string text = SQLHelper.RunCommand("insert into tblPledge(ShopCode,BillNumber,BillDate,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3,City,Pincode,PhoneNumber,AmountInWords,Type,GrossWeight,Deduction,NetWeight,PureWeight,Amount,PresentValue,OldBillNumber,Reminder,temp1,InterestRateDisplaySymbol,Redeemed,PledgeCreatedBy,PledgeCreatedOn,temp5,ArticlesWithoutHr,ArticlesWithHr,Articles,BilledBy) values(@ShopCode,@BillNumber,@BillDate,@CustomerCode,@CustomerName,@DoorNumber,@Addr1,@Addr2,@Addr3,@City,@Pincode,@PhoneNumber,@AmountInWords,@Type,@GrossWeight,@Deduction,@NetWeight,@PureWeight,@Amount,@PresentValue,@OldBillNumber,@Reminder,@InterestRate,@InterestRateDisplaySymbol,@Redeemed,@PledgeCreatedBy,@PledgeCreatedOn,@temp5,@ArticlesWithoutHr,@ArticlesWithHr,@Articles,@BilledBy)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (BillDate), (object) BillDate),
        new OleDbParameter("CustomerCode", (object) customerCode),
        new OleDbParameter(nameof (CustomerName), (object) CustomerName),
        new OleDbParameter(nameof (DoorNumber), (object) DoorNumber),
        new OleDbParameter(nameof (Addr1), (object) Addr1),
        new OleDbParameter(nameof (Addr2), (object) Addr2),
        new OleDbParameter(nameof (Addr3), (object) Addr3),
        new OleDbParameter(nameof (City), (object) City),
        new OleDbParameter(nameof (Pincode), (object) Pincode),
        new OleDbParameter(nameof (PhoneNumber), (object) PhoneNumber),
        new OleDbParameter(nameof (AmountInWords), (object) AmountInWords),
        new OleDbParameter(nameof (Type), (object) Type),
        new OleDbParameter(nameof (GrossWeight), (object) GrossWeight),
        new OleDbParameter(nameof (Deduction), (object) Deduction),
        new OleDbParameter(nameof (NetWeight), (object) NetWeight),
        new OleDbParameter(nameof (PureWeight), (object) PureWeight),
        new OleDbParameter("Amount", (object) amount),
        new OleDbParameter(nameof (PresentValue), (object) PresentValue),
        new OleDbParameter(nameof (OldBillNumber), (object) OldBillNumber),
        new OleDbParameter(nameof (Reminder), (object) Reminder),
        new OleDbParameter(nameof (InterestRate), (object) InterestRate),
        new OleDbParameter(nameof (InterestRateDisplaySymbol), (object) InterestRateDisplaySymbol),
        new OleDbParameter(nameof (Redeemed), (object) Redeemed),
        new OleDbParameter(nameof (PledgeCreatedBy), (object) PledgeCreatedBy),
        new OleDbParameter(nameof (PledgeCreatedOn), (object) DateTime.Parse(PledgeCreatedOn.ToString())),
        new OleDbParameter("temp5", (object) Temp5),
        new OleDbParameter(nameof (ArticlesWithoutHr), (object) ArticlesWithoutHr),
        new OleDbParameter(nameof (ArticlesWithHr), (object) ArticlesWithHr),
        new OleDbParameter(nameof (Articles), (object) Articles),
        new OleDbParameter(nameof (BilledBy), (object) BilledBy)
      }, ref strError);
      if (text == "Done")
        return;
      PawnManagementClass.InsertIntoException("form pledge.savepledge()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.Close();

    private void tbxLicense_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxAmount.Select();
    }

    private void tbxAmount_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxInterestRate.Select();
    }

    private void tbxOldBillNumber_KeyPress(object sender, KeyPressEventArgs e)
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

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (FormMain.BillNumberSeries == "SINGLE")
      {
        this.tbxOldBillNumber.Select();
        this.tbxOldBillNumber.Select(2, this.tbxOldBillNumber.Text.Length);
      }
      if (FormMain.BillNumberSeries == "DOUBLE")
      {
        this.tbxOldBillNumber.Select();
        this.tbxOldBillNumber.Select(3, this.tbxOldBillNumber.Text.Length);
      }
    }

    private void tbxOldBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxNewBillNumber.Select();
    }

    private void tbxOldBillNumber_Validating(object sender, CancelEventArgs e)
    {
      if (!PawnManagement.PledgeClass.checkIfBillNumberIsValid(this.tbxOldBillNumber.Text, this.cbShopCodes.Text.Trim()))
      {
        this.tbxOldBillNumber.Select();
      }
      else
      {
        this.tbxNewBillNumber.Text = this.strGetPledgeBillNumber();
        DataTable pledgeBill = PawnManagement.PledgeClass.getPledgeBill(this.tbxOldBillNumber.Text, this.cbShopCodes.Text);
        if (pledgeBill != null && pledgeBill.Rows.Count > 0)
        {
          this.tbxAmount.Text = pledgeBill.Rows[0]["Amount"].ToString();
          this.tbxInterestRate.Text = pledgeBill.Rows[0]["temp1"].ToString();
        }
        else
          this.tbxAmount.Text = "0";
      }
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.cbShopCodes.Select();
      }
      else
      {
        string redemptionNumber = PawnManagement.Classes.RedemptionClass.getMaxRedemptionNumber(this.cbShopCodes.Text);
        if (redemptionNumber != "")
        {
          DataTable redemptionBill = PawnManagement.Classes.RedemptionClass.getRedemptionBill(redemptionNumber, this.cbShopCodes.Text);
          if (redemptionBill != null && redemptionBill.Rows.Count > 0)
            this.tbxOldBillNumber.Text = redemptionBill.Rows[0]["pLEDGEBillNumber"].ToString();
        }
      }
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

    private void tbxNewBillNumber_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxInterestRate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnSave).Focus();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.headerPanel2 = new HeaderPanel();
      this.tbxNewBillNumber = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.tbxAmount = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.tbxOldBillNumber = new TextBox();
      this.btnSave = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.glassButton1 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.tbxInterestRate = new TextBox();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.SuspendLayout();
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
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
      this.headerPanel2.CaptionText = "NEW BILL NUMBER";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxNewBillNumber);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(31, 117);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(335, 48);
      ((Control) this.headerPanel2).TabIndex = 83;
      this.headerPanel2.TextAntialias = true;
      this.tbxNewBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxNewBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxNewBillNumber.BackColor = Color.AliceBlue;
      this.tbxNewBillNumber.BorderStyle = BorderStyle.None;
      this.tbxNewBillNumber.Dock = DockStyle.Fill;
      this.tbxNewBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNewBillNumber.Location = new Point(0, 0);
      this.tbxNewBillNumber.MaxLength = 6;
      this.tbxNewBillNumber.Name = "tbxNewBillNumber";
      this.tbxNewBillNumber.Size = new Size(333, 22);
      this.tbxNewBillNumber.TabIndex = 79;
      this.tbxNewBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxNewBillNumber.KeyDown += new KeyEventHandler(this.tbxLicense_KeyDown);
      this.tbxNewBillNumber.KeyPress += new KeyPressEventHandler(this.tbxNewBillNumber_KeyPress);
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top;
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
      this.headerPanel7.CaptionText = "SELECT LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(31, 11);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(335, 48);
      ((Control) this.headerPanel7).TabIndex = 79;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.Font = new Font("Arial Rounded MT Bold", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(333, 26);
      this.cbShopCodes.TabIndex = 25;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
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
      ((Control) this.glassButton8).Location = new Point(28, 513);
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
      ((Control) this.glassButton9).Location = new Point(162, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
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
      this.headerPanel1.CaptionText = "AMOUNT";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(31, 170);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(335, 48);
      ((Control) this.headerPanel1).TabIndex = 81;
      this.headerPanel1.TextAntialias = true;
      this.tbxAmount.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAmount.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Dock = DockStyle.Fill;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(0, 0);
      this.tbxAmount.MaxLength = 15;
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(333, 22);
      this.tbxAmount.TabIndex = 79;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      this.tbxAmount.KeyDown += new KeyEventHandler(this.tbxAmount_KeyDown);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top;
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
      this.headerPanel5.CaptionText = "OLD BILL NUMBER";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxOldBillNumber);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(31, 64);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(335, 48);
      ((Control) this.headerPanel5).TabIndex = 80;
      this.headerPanel5.TextAntialias = true;
      this.tbxOldBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxOldBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxOldBillNumber.BackColor = Color.AliceBlue;
      this.tbxOldBillNumber.BorderStyle = BorderStyle.None;
      this.tbxOldBillNumber.Dock = DockStyle.Fill;
      this.tbxOldBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOldBillNumber.Location = new Point(0, 0);
      this.tbxOldBillNumber.MaxLength = 6;
      this.tbxOldBillNumber.Name = "tbxOldBillNumber";
      this.tbxOldBillNumber.Size = new Size(333, 22);
      this.tbxOldBillNumber.TabIndex = 79;
      this.tbxOldBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxOldBillNumber.KeyDown += new KeyEventHandler(this.tbxOldBillNumber_KeyDown);
      this.tbxOldBillNumber.KeyPress += new KeyPressEventHandler(this.tbxOldBillNumber_KeyPress);
      this.tbxOldBillNumber.Validating += new CancelEventHandler(this.tbxOldBillNumber_Validating);
      ((Control) this.btnSave).Anchor = AnchorStyles.Top;
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.MediumBlue;
      this.btnSave.GlowColor = Color.White;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(33, 275);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(162, 35);
      ((Control) this.btnSave).TabIndex = 82;
      ((Control) this.btnSave).Text = "&SAVE";
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.tableLayoutPanel1.Anchor = AnchorStyles.None;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Location = new Point(8, 5);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(390, 395);
      this.tableLayoutPanel1.TabIndex = 84;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(384, 45);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(145, 6);
      this.label7.Name = "label7";
      this.label7.Size = new Size(100, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "RE BILL";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Controls.Add((Control) this.headerPanel7);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Controls.Add((Control) this.headerPanel5);
      this.panel3.Controls.Add((Control) this.btnSave);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 54);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(384, 338);
      this.panel3.TabIndex = 11;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(201, 275);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(166, 35);
      ((Control) this.glassButton1).TabIndex = 85;
      ((Control) this.glassButton1).Text = "&EXIT";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top;
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
      this.headerPanel3.CaptionText = "ROI";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxInterestRate);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(32, 221);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(335, 48);
      ((Control) this.headerPanel3).TabIndex = 84;
      this.headerPanel3.TextAntialias = true;
      this.tbxInterestRate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxInterestRate.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxInterestRate.BackColor = Color.AliceBlue;
      this.tbxInterestRate.BorderStyle = BorderStyle.None;
      this.tbxInterestRate.Dock = DockStyle.Fill;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(0, 0);
      this.tbxInterestRate.MaxLength = 3;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(333, 22);
      this.tbxInterestRate.TabIndex = 79;
      this.tbxInterestRate.TextAlign = HorizontalAlignment.Center;
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxInterestRate_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Azure;
      this.ClientSize = new Size(406, 407);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormReBill);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "ReBill";
      this.Load += new EventHandler(this.FormReBill_Load);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
