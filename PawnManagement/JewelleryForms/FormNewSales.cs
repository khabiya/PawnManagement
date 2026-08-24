
using Jewellery;
using PawnManagement.Classes.JewelleryClasses;
using PawnManagement.Classes.PawnManagementClasses;
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

namespace PawnManagement.JewelleryForms
{
  public class FormNewSales : Form
  {
    public static string formType = "";
    public static string InvoiceBillNumberSeriesLetterType = "";
    public static string InvoiceBillNumberSeriesLetter = "";
    public static double InvoiceBillNumberRange = 0.0;
    public int iItemNameEnterKeyCount = 0;
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private TextBox tbxItemName;
    private TextBox tbxQuantity;
    private TextBox tbxStoneWeight;
    private TextBox tbxNetWeight;
    private TextBox tbxWastage;
    private TextBox tbxMakingCharge;
    private TextBox tbxStoneCharge;
    private TextBox tbxHallMark;
    private TextBox tbxAmount;
    private TextBox tbxGst;
    private TextBox tbxGstAmount;
    private TextBox tbxTotal;
    private Label label6;
    private TextBox tbxCustomerNameSearch;
    private Label label4;
    private Label label5;
    private TextBox tbxSalesPerson;
    private TextBox tbxBilledBy;
    private Label label3;
    private Label label2;
    private Label label1;
    private ComboBox cbBillType;
    private TextBox tbxBillNumber;
    private Label label19;
    private Label lblQuantity;
    private Label label17;
    private Label label16;
    private Label label15;
    private Label label14;
    private Label label13;
    private Label label12;
    private Label label11;
    private Label label10;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label25;
    private Label label26;
    private Label label27;
    private TextBox tbxBalance;
    private TextBox tbxAmountReceived;
    private Label label20;
    private TextBox tbxNetPayable;
    private Label label21;
    private Label label22;
    private TextBox tbxOldPurchase;
    private TextBox tbxRoundOff;
    private Label label23;
    private Label label24;
    private TextBox tbxDiscount;
    private TextBox tbxGrandTotal;
    private DataGridView dgvSalesDetails;
    private Button btnOldPurchase;
    private Label label28;
    private ComboBox cbCompanyCode;
    private DataGridView dgvCustomerDetails;
    private MaskedTextBox mtbxBillDate;
    private PictureBox pictureBox1;
    private Label label30;
    private RichTextBox rtbxAddress;
    private Label label29;
    private TextBox tbxCustomerName;
    private Panel panel2;
    private TextBox tbxCity;
    private TextBox tbxNumber;
    private TextBox tbxAddress1;
    private TextBox tbxPincode;
    private TextBox tbxAddress2;
    private TextBox tbxCell;
    private TextBox tbxCustomerCode;
    private TextBox tbxPhoneNumber;
    private TextBox tbxAddress3;
    private TextBox tbxNotes;
    private DataGridView dgvItemNames;
    private Label lblRate;
    private TextBox tbxRate;
    private TextBox tbxItemCode;
    private TextBox tbxItemType;
    private MaskedTextBox mtbCommitDate;
    private Button btnSave;
    private TextBox tbxMetal;
    private TextBox tbxTotalGstAmount;
    private TextBox tbxTotalAmount;
    private Button btnClose;
    private Button btnNext;
    private Button btnNewBill;
    private Button btnPrevious;
    private Button btnDelete;
    private Button btnPrint;
    private Panel panel4;
    private Panel panel3;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colHsnCode;
    private DataGridViewTextBoxColumn colItemCode;
    private DataGridViewTextBoxColumn colItemName;
    private DataGridViewTextBoxColumn colQuantity;
    private DataGridViewTextBoxColumn colStoneWeight;
    private DataGridViewTextBoxColumn colNetWeight;
    private DataGridViewTextBoxColumn colWastage;
    private DataGridViewTextBoxColumn colMakingCharge;
    private DataGridViewTextBoxColumn colStoneCharge;
    private DataGridViewTextBoxColumn colHallMark;
    private DataGridViewTextBoxColumn colRate;
    private DataGridViewTextBoxColumn colAmount;
    private DataGridViewTextBoxColumn colGst;
    private DataGridViewTextBoxColumn colGstAmount;
    private DataGridViewTextBoxColumn colTotal;
    private TextBox tbxHsnCode;

    public FormNewSales() => this.InitializeComponent();

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

    private void textBox_Enter(object sender, EventArgs e) => (sender as TextBox).BackColor = Color.GreenYellow;

    private void textBox_Leave(object sender, EventArgs e) => (sender as TextBox).BackColor = Color.White;

    private void comboBoX_Enter(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.GreenYellow;

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

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormNewSales_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      List<string> stringList1 = new List<string>();
      this.cbCompanyCode.Items.AddRange((object[]) CompanyDetailsClass.getCompanyNames().ToArray());
      List<string> stringList2 = new List<string>();
      this.tbxSalesPerson.AutoCompleteCustomSource.AddRange(BillerClass.getBillerNamesBasedOnThisColumn("UserType", "SALES PERSON").ToArray());
      this.mtbxBillDate.Text = DateTime.Now.ToShortDateString();
      DataGridView dgvCustomerDetails = this.dgvCustomerDetails;
      Point location = this.tbxCustomerNameSearch.Location;
      int x = location.X - 80;
      location = this.tbxCustomerNameSearch.Location;
      int y = location.Y + 30;
      Point point = new Point(x, y);
      dgvCustomerDetails.Location = point;
      this.cbCompanyCode.Text = CompanyDetailsClass.getDefaultCompanyCode();
    }

    private void cbCompanyCode_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbCompanyCode.Items.Contains((object) this.cbCompanyCode.Text))
      {
        this.cbCompanyCode.Select();
      }
      else
      {
        DataTable basedOnThisColumn = BillNumberSeriesClass.getAllTheRecordsBasedOnThisColumn("CompanyCode", "FormType", this.cbCompanyCode.Text, "INVOICE NUMBER");
        if (basedOnThisColumn != null && basedOnThisColumn.Rows.Count > 0)
        {
          FormNewSales.InvoiceBillNumberSeriesLetterType = basedOnThisColumn.Rows[0]["SerialType"].ToString();
          FormNewSales.InvoiceBillNumberSeriesLetter = basedOnThisColumn.Rows[0]["SerialLetter"].ToString();
          FormNewSales.InvoiceBillNumberRange = double.Parse(basedOnThisColumn.Rows[0]["Range"].ToString());
        }
      }
    }

    private void cbBillType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbBillType.Text == "ESTIMATE" | this.cbBillType.Text == "CASH")
      {
        this.tbxAmountReceived.ReadOnly = true;
      }
      else
      {
        if (!(this.cbBillType.Text == "CREDIT"))
          return;
        this.tbxAmountReceived.ReadOnly = false;
      }
    }

    private void cbBillType_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbBillType.Items.Contains((object) this.cbBillType.Text))
      {
        this.cbBillType.Select();
      }
      else
      {
        if (this.cbBillType.Text == "ESTIMATE")
        {
          this.tbxAmountReceived.ReadOnly = true;
          this.mtbCommitDate.Enabled = false;
          this.tbxBalance.Enabled = false;
          this.mtbCommitDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else if (this.cbBillType.Text == "CASH")
        {
          this.tbxAmountReceived.ReadOnly = true;
          this.mtbCommitDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
          this.mtbCommitDate.Enabled = false;
          this.tbxBalance.Enabled = false;
        }
        else if (this.cbBillType.Text == "CREDIT")
        {
          this.tbxAmountReceived.ReadOnly = false;
          this.mtbCommitDate.Enabled = true;
          this.tbxBalance.Enabled = true;
        }
        string nextBillNumber = SalesClass.getNextBillNumber(this.cbCompanyCode.Text);
        if (this.tbxBillNumber.Enabled)
          this.tbxBillNumber.Text = nextBillNumber;
      }
    }

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (FormNewSales.InvoiceBillNumberSeriesLetterType)
      {
        case "NO SERIAL LETTER":
          if (char.IsDigit(e.KeyChar) | e.KeyChar == '\b')
            break;
          e.Handled = true;
          break;
        case "SINGLE LETTER":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (char.IsLetter(e.KeyChar) && PawnManagementClass.stringContainsHowManyLetter((sender as TextBox).Text) >= 1)
              e.Handled = true;
            if ((sender as TextBox).Text.Length >= 1 || !char.IsDigit(e.KeyChar))
              break;
            e.Handled = true;
            break;
          }
          e.Handled = true;
          break;
        case "DOUBLE LETTER":
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

    private void tbxBillNumber_Validating(object sender, CancelEventArgs e)
    {
      if (!BillNumberSeriesClass.validateBillNumber(FormNewSales.InvoiceBillNumberSeriesLetterType, this.tbxBillNumber.Text, FormNewSales.InvoiceBillNumberRange))
        this.tbxBillNumber.Select();
      else if (SalesClass.checkIfBillNumberAlreadyExists(this.tbxBillNumber.Text, this.cbCompanyCode.Text))
      {
        this.getBill(this.cbCompanyCode.Text, this.tbxBillNumber.Text);
        this.tbxBillNumber.Enabled = false;
        this.cbCompanyCode.Enabled = false;
        this.cbBillType.Select();
      }
    }

    private void mtbxBillDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBilledBy.Select();
    }

    private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
    {
      if (this.mtbxBillDate.Text != "")
      {
        if (PawnManagementClass.checkForValidateDate(this.mtbxBillDate.Text))
        {
          if (DateTime.Parse(this.mtbxBillDate.Text) > DateTime.Now)
          {
            this.mtbxBillDate.ForeColor = Color.White;
            this.mtbxBillDate.BackColor = Color.Firebrick;
          }
          else
          {
            this.mtbxBillDate.ForeColor = Color.Black;
            this.mtbxBillDate.BackColor = Color.White;
          }
        }
        else
        {
          this.mtbxBillDate.ForeColor = Color.White;
          this.mtbxBillDate.BackColor = Color.Firebrick;
        }
      }
      else
      {
        this.mtbxBillDate.ForeColor = Color.White;
        this.mtbxBillDate.BackColor = Color.Firebrick;
      }
    }

    private void tbxBilledBy_Enter(object sender, EventArgs e) => this.tbxBilledBy.Text = FormMain.BillerName;

    private void tbxCustomerNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxCustomerNameSearch.Text != "")
        this.getCustomerDetailsSimple();
      else
        this.dgvCustomerDetails.Visible = false;
    }

    private void tbxCustomerNameSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down)
      {
        if (this.dgvCustomerDetails == null || this.dgvCustomerDetails.Rows.Count <= 0)
          return;
        this.dgvCustomerDetails.Select();
        this.dgvCustomerDetails.Rows[0].Selected = true;
      }
      else
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.dgvCustomerDetails.Visible = false;
        this.tbxItemName.Select();
      }
    }

    private void dgvCustomerDetails_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvCustomerDetails.Rows[0].Selected)
          this.tbxCustomerNameSearch.Select();
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

    private void dgvCustomerDetails_KeyUp(object sender, KeyEventArgs e)
    {
      if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
        return;
      this.getPicture(this.dgvCustomerDetails.Rows[this.dgvCustomerDetails.CurrentRow.Index].Cells["CID"].Value.ToString());
    }

    private void dgvCustomerDetails_Leave(object sender, EventArgs e) => this.dgvCustomerDetails.ClearSelection();

    private void tbxItemName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down)
      {
        if (this.dgvItemNames == null || this.dgvItemNames.Rows.Count <= 0)
          return;
        this.dgvItemNames.Select();
        this.dgvItemNames.Rows[0].Selected = true;
        this.dgvItemNames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      }
      else
      {
        if (e.KeyCode != Keys.Return)
          return;
        ++this.iItemNameEnterKeyCount;
        if (this.iItemNameEnterKeyCount >= 3 && this.checkIfSalesDetailsDatagridViewValid())
        {
          this.tbxGrandTotal.Select();
          this.iItemNameEnterKeyCount = 0;
          this.calculateGrandTotal();
        }
      }
    }

    private void tbxItemName_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxItemName.Text != "")
        this.getItemNames();
      else
        this.dgvItemNames.Visible = false;
    }

    private void dgvItemNames_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up)
        {
          if (!this.dgvItemNames.Rows[0].Selected)
            return;
          this.tbxItemName.Select();
        }
        else
        {
          if (e.KeyCode != Keys.Return)
            return;
          int index = 0;
          if (this.dgvItemNames.CurrentRow != null)
            index = this.dgvItemNames.CurrentRow.Index;
          string type;
          this.tbxItemType.Text = type = this.dgvItemNames.Rows[index].Cells["Type"].Value.ToString();
          this.tbxMetal.Text = this.dgvItemNames.Rows[index].Cells["Metal"].Value.ToString();
          this.tbxItemCode.Text = this.dgvItemNames.Rows[index].Cells["ItemCode"].Value.ToString();
          this.getItemAndFillAllTheTextBox(this.tbxItemCode.Text, type);
          this.dgvItemNames.Visible = false;
          switch (type)
          {
            case "LIVE RATE":
              this.lblQuantity.Text = "GROSS WEIGHT";
              break;
            case "PER GRAM":
              this.lblQuantity.Text = "GROSS WEIGHT";
              this.tbxQuantity.Select();
              break;
            case "MRP":
              this.lblQuantity.Text = "QUANTITY";
              break;
          }
          this.tbxQuantity.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbx_TextChanged(object sender, EventArgs e) => this.calculateTotal();

    private void tbxQuantity_Validating(object sender, CancelEventArgs e) => (sender as TextBox).Text = PawnManagementClass.appenZeroes(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());

    private void tbxRate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !this.checkIfAllTheEntriesAreMade())
        return;
      this.dgvSalesDetails.Rows.Add((object) this.tbxItemType.Text, (object) this.tbxHsnCode.Text, (object) this.tbxItemCode.Text, (object) this.tbxItemName.Text, (object) this.tbxQuantity.Text, (object) this.tbxStoneWeight.Text, (object) this.tbxNetWeight.Text, (object) this.tbxWastage.Text, (object) this.tbxMakingCharge.Text, (object) this.tbxStoneCharge.Text, (object) this.tbxHallMark.Text, (object) this.tbxRate.Text, (object) this.tbxAmount.Text, (object) this.tbxGst.Text, (object) this.tbxGstAmount.Text, (object) this.tbxTotal.Text);
      this.reset();
      this.tbxItemName.Select();
    }

    private void tbxDiscount_Validating(object sender, CancelEventArgs e)
    {
      this.tbxNetPayable.Text = ((this.tbxGrandTotal.Text.Trim() == "" | this.tbxGrandTotal.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGrandTotal.Text)) - (this.tbxDiscount.Text.Trim() == "" | this.tbxDiscount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxDiscount.Text)) - (this.tbxRoundOff.Text.Trim() == "" | this.tbxRoundOff.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxRoundOff.Text))).ToString("F");
      this.tbxAmountReceived.Text = this.tbxNetPayable.Text;
      (sender as TextBox).Text = PawnManagementClass.appenZeroes2(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());
    }

    private void tbxRoundOff_Validating(object sender, CancelEventArgs e)
    {
      this.tbxNetPayable.Text = ((this.tbxGrandTotal.Text.Trim() == "" | this.tbxGrandTotal.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGrandTotal.Text)) - (this.tbxDiscount.Text.Trim() == "" | this.tbxDiscount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxDiscount.Text)) - (this.tbxRoundOff.Text.Trim() == "" | this.tbxRoundOff.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxRoundOff.Text))).ToString("F");
      this.tbxAmountReceived.Text = this.tbxNetPayable.Text;
      (sender as TextBox).Text = PawnManagementClass.appenZeroes2(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());
    }

    private void tbxAmountReceived_TextChanged(object sender, EventArgs e)
    {
      double num = this.tbxAmountReceived.Text.Trim() == "" | this.tbxAmountReceived.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxAmountReceived.Text);
      this.tbxBalance.Text = ((this.tbxNetPayable.Text.Trim() == "" | this.tbxNetPayable.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxNetPayable.Text)) - num).ToString("F");
      (sender as TextBox).Text = PawnManagementClass.appenZeroes2(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());
    }

    private void tbxAmountReceived_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.cbBillType.Text == "ESTIMATE" | this.cbBillType.Text == "CASH")
      {
        e.Handled = true;
      }
      else
      {
        if (!(this.cbBillType.Text == "CREDIT"))
          return;
        char keyChar = e.KeyChar;
        if (!char.IsDigit(keyChar) && keyChar != '\b')
          e.Handled = true;
      }
    }

    private void mtbCommitDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnSave.Select();
    }

    private void mtbCommitDate_Validating(object sender, CancelEventArgs e)
    {
      if (this.mtbCommitDate.Text != "")
      {
        if (PawnManagementClass.checkForValidateDate(this.mtbCommitDate.Text))
        {
          if (DateTime.Parse(this.mtbCommitDate.Text) < DateTime.Now)
          {
            this.mtbCommitDate.ForeColor = Color.White;
            this.mtbCommitDate.BackColor = Color.Firebrick;
          }
          else
          {
            this.mtbCommitDate.ForeColor = Color.Black;
            this.mtbCommitDate.BackColor = Color.White;
          }
        }
        else
        {
          this.mtbCommitDate.ForeColor = Color.White;
          this.mtbCommitDate.BackColor = Color.Firebrick;
          this.mtbCommitDate.Select();
        }
      }
      else
      {
        this.mtbCommitDate.ForeColor = Color.White;
        this.mtbCommitDate.BackColor = Color.Firebrick;
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!SalesClass.checkIfBillNumberAlreadyExists(this.tbxBillNumber.Text, this.cbCompanyCode.Text))
      {
        if (this.checkIfSalesDetailsDatagridViewValid())
        {
          if (!this.checkIfAllTheEnteriesAreMadeBeforeSaving() || !(this.cbBillType.Text != "ESTIMATE") || DialogResult.Yes != MessageBox.Show("Save?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) || !(SalesClass.addSales(SalesClass.getMaxSerialNumber(), DateTime.Parse(this.mtbxBillDate.Text), this.cbBillType.Text, this.tbxBillNumber.Text, "", this.tbxBilledBy.Text, this.tbxSalesPerson.Text, this.tbxCustomerCode.Text, double.Parse(this.tbxTotalAmount.Text), double.Parse(this.tbxTotalGstAmount.Text), double.Parse(this.tbxGrandTotal.Text), double.Parse(this.tbxDiscount.Text), double.Parse(this.tbxRoundOff.Text), double.Parse(this.tbxOldPurchase.Text), double.Parse(this.tbxNetPayable.Text), double.Parse(this.tbxAmountReceived.Text), double.Parse(this.tbxBalance.Text), DateTime.Parse(this.mtbCommitDate.Text), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now, this.cbCompanyCode.Text) == "Done"))
            return;
          if (this.saveDataGridView())
          {
            this.resetForm();
            this.cbCompanyCode.Enabled = true;
            this.tbxBillNumber.Enabled = true;
            this.cbCompanyCode.Select();
          }
          if (DialogResult.Yes != MessageBox.Show("Print?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            ;
        }
        else
          this.tbxItemName.Select();
      }
      else if (this.checkIfSalesDetailsDatagridViewValid())
      {
        if (this.checkIfAllTheEnteriesAreMadeBeforeSaving() && DialogResult.Yes == MessageBox.Show("Save?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) && SalesClass.editSales(DateTime.Parse(this.mtbxBillDate.Text), this.cbBillType.Text, this.tbxBillNumber.Text, "", this.tbxBilledBy.Text, this.tbxSalesPerson.Text, this.tbxCustomerCode.Text, double.Parse(this.tbxTotalAmount.Text), double.Parse(this.tbxTotalGstAmount.Text), double.Parse(this.tbxGrandTotal.Text), double.Parse(this.tbxDiscount.Text), double.Parse(this.tbxRoundOff.Text), double.Parse(this.tbxOldPurchase.Text), double.Parse(this.tbxNetPayable.Text), double.Parse(this.tbxAmountReceived.Text), double.Parse(this.tbxBalance.Text), DateTime.Parse(this.mtbCommitDate.Text), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now, this.cbCompanyCode.Text) == "Done")
        {
          if (SalesDetailsClass.deleteSalesDetails(this.cbCompanyCode.Text, this.tbxBillNumber.Text) == "Done" && this.saveDataGridView())
          {
            this.resetForm();
            this.cbCompanyCode.Enabled = true;
            this.tbxBillNumber.Enabled = true;
            this.cbCompanyCode.Select();
            if (DialogResult.Yes != MessageBox.Show("Print?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
              ;
          }
          this.cbCompanyCode.Select();
        }
      }
      else
        this.tbxItemName.Select();
    }

    private bool saveDataGridView()
    {
      int num = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvSalesDetails.Rows)
      {
        if (row.Cells["colType"].Value.ToString() == "LIVE RATE")
        {
          if (SalesDetailsClass.addSalesDetails(this.tbxBillNumber.Text, row.Cells["colType"].Value.ToString(), row.Cells["colItemCode"].Value.ToString(), row.Cells["colItemname"].Value.ToString(), 0.0, double.Parse(row.Cells["colQuantity"].Value.ToString()), double.Parse(row.Cells["colStoneWeight"].Value.ToString()), double.Parse(row.Cells["colNetWeight"].Value.ToString()), double.Parse(row.Cells["colWastage"].Value.ToString()), double.Parse(row.Cells["colMakingCharge"].Value.ToString()), double.Parse(row.Cells["colStoneCharge"].Value.ToString()), double.Parse(row.Cells["colHallMark"].Value.ToString()), double.Parse(row.Cells["colRate"].Value.ToString()), double.Parse(row.Cells["colAmount"].Value.ToString()), double.Parse(row.Cells["colGst"].Value.ToString()), double.Parse(row.Cells["colGstAmount"].Value.ToString()), double.Parse(row.Cells["colTotal"].Value.ToString()), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now) == "Done")
            ++num;
        }
        else if (row.Cells["colType"].Value.ToString() == "PER GRAM")
        {
          if (SalesDetailsClass.addSalesDetails(this.tbxBillNumber.Text, row.Cells["colType"].Value.ToString(), row.Cells["colItemCode"].Value.ToString(), row.Cells["colItemname"].Value.ToString(), 0.0, double.Parse(row.Cells["colQuantity"].Value.ToString()), double.Parse(row.Cells["colStoneWeight"].Value.ToString()), double.Parse(row.Cells["colNetWeight"].Value.ToString()), double.Parse(row.Cells["colWastage"].Value.ToString()), double.Parse(row.Cells["colMakingCharge"].Value.ToString()), double.Parse(row.Cells["colStoneCharge"].Value.ToString()), double.Parse(row.Cells["colHallMark"].Value.ToString()), double.Parse(row.Cells["colRate"].Value.ToString()), double.Parse(row.Cells["colAmount"].Value.ToString()), double.Parse(row.Cells["colGst"].Value.ToString()), double.Parse(row.Cells["colGstAmount"].Value.ToString()), double.Parse(row.Cells["colTotal"].Value.ToString()), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now) == "Done")
            ++num;
        }
        else if (row.Cells["colType"].Value.ToString() == "MRP" && SalesDetailsClass.addSalesDetails(this.tbxBillNumber.Text, row.Cells["colType"].Value.ToString(), row.Cells["colItemCode"].Value.ToString(), row.Cells["colItemname"].Value.ToString(), double.Parse(row.Cells["colQuantity"].Value.ToString()), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, double.Parse(row.Cells["colRate"].Value.ToString()), double.Parse(row.Cells["colAmount"].Value.ToString()), double.Parse(row.Cells["colGst"].Value.ToString()), double.Parse(row.Cells["colGstAmount"].Value.ToString()), double.Parse(row.Cells["colTotal"].Value.ToString()), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now) == "Done")
          ++num;
      }
      return num == this.dgvSalesDetails.Rows.Count;
    }

    private void calculateTotal()
    {
      if (this.tbxItemType.Text == "LIVE RATE")
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = 0.0;
        double num5 = this.tbxQuantity.Text.Trim() == "" | this.tbxQuantity.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxQuantity.Text);
        num1 = this.tbxNetWeight.Text.Trim() == "" | this.tbxNetWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxNetWeight.Text);
        double num6 = this.tbxStoneWeight.Text.Trim() == "" | this.tbxStoneWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneWeight.Text);
        double num7 = this.tbxWastage.Text.Trim() == "" | this.tbxWastage.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxWastage.Text);
        double num8 = this.tbxMakingCharge.Text.Trim() == "" | this.tbxMakingCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxMakingCharge.Text);
        double num9 = this.tbxStoneCharge.Text.Trim() == "" | this.tbxStoneCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneCharge.Text);
        double num10 = this.tbxHallMark.Text.Trim() == "" | this.tbxHallMark.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxHallMark.Text);
        double num11 = this.tbxRate.Text.Trim() == "" | this.tbxRate.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxRate.Text);
        num2 = this.tbxAmount.Text.Trim() == "" | this.tbxAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxAmount.Text);
        double num12 = this.tbxGst.Text.Trim() == "" | this.tbxGst.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGst.Text);
        num3 = this.tbxGstAmount.Text.Trim() == "" | this.tbxGstAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGstAmount.Text);
        num4 = this.tbxTotal.Text.Trim() == "" | this.tbxTotal.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxTotal.Text);
        double num13 = num5 - num6;
        this.tbxNetWeight.Text = num13.ToString();
        double num14 = (num13 + num13 * num7 / 100.0) * num11 + num8 + num9 + num10;
        TextBox tbxAmount = this.tbxAmount;
        double num15 = Math.Round(double.Parse(num14.ToString()), 0);
        string str1 = num15.ToString();
        tbxAmount.Text = str1;
        double num16 = num14 * num12 / 100.0;
        TextBox tbxGstAmount = this.tbxGstAmount;
        num15 = Math.Round(double.Parse(num16.ToString()), 0);
        string str2 = num15.ToString();
        tbxGstAmount.Text = str2;
        double num17 = num14 + num16;
        TextBox tbxTotal = this.tbxTotal;
        num15 = Math.Round(double.Parse(num17.ToString()), 0);
        string str3 = num15.ToString();
        tbxTotal.Text = str3;
      }
      else if (this.tbxItemType.Text == "PER GRAM")
      {
        double num18 = 0.0;
        double num19 = 0.0;
        double num20 = 0.0;
        double num21 = 0.0;
        double num22 = 0.0;
        double num23 = 0.0;
        double num24 = 0.0;
        double num25 = 0.0;
        double num26 = this.tbxQuantity.Text.Trim() == "" | this.tbxQuantity.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxQuantity.Text);
        num18 = this.tbxNetWeight.Text.Trim() == "" | this.tbxNetWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxNetWeight.Text);
        double num27 = this.tbxStoneWeight.Text.Trim() == "" | this.tbxStoneWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneWeight.Text);
        num19 = this.tbxWastage.Text.Trim() == "" | this.tbxWastage.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxWastage.Text);
        num20 = this.tbxMakingCharge.Text.Trim() == "" | this.tbxMakingCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxMakingCharge.Text);
        num21 = this.tbxStoneCharge.Text.Trim() == "" | this.tbxStoneCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneCharge.Text);
        num22 = this.tbxHallMark.Text.Trim() == "" | this.tbxHallMark.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxHallMark.Text);
        double num28 = this.tbxRate.Text.Trim() == "" | this.tbxRate.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxRate.Text);
        num23 = this.tbxAmount.Text.Trim() == "" | this.tbxAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxAmount.Text);
        double num29 = this.tbxGst.Text.Trim() == "" | this.tbxGst.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGst.Text);
        num24 = this.tbxGstAmount.Text.Trim() == "" | this.tbxGstAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGstAmount.Text);
        num25 = this.tbxTotal.Text.Trim() == "" | this.tbxTotal.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxTotal.Text);
        double num30 = num26 - num27;
        this.tbxNetWeight.Text = num30.ToString();
        double num31 = num30 * num28;
        TextBox tbxAmount = this.tbxAmount;
        double num32 = Math.Round(double.Parse(num31.ToString()), 0);
        string str4 = num32.ToString();
        tbxAmount.Text = str4;
        double num33 = num31 * num29 / 100.0;
        TextBox tbxGstAmount = this.tbxGstAmount;
        num32 = Math.Round(double.Parse(num33.ToString()), 0);
        string str5 = num32.ToString();
        tbxGstAmount.Text = str5;
        double num34 = num31 + num33;
        TextBox tbxTotal = this.tbxTotal;
        num32 = Math.Round(double.Parse(num34.ToString()), 0);
        string str6 = num32.ToString();
        tbxTotal.Text = str6;
      }
      else
      {
        if (!(this.tbxItemType.Text == "MRP"))
          return;
        double num35 = 0.0;
        double num36 = 0.0;
        double num37 = 0.0;
        double num38 = 0.0;
        double num39 = 0.0;
        double num40 = 0.0;
        double num41 = 0.0;
        double num42 = 0.0;
        double num43 = this.tbxQuantity.Text.Trim() == "" | this.tbxQuantity.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxQuantity.Text);
        num35 = this.tbxNetWeight.Text.Trim() == "" | this.tbxNetWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxNetWeight.Text);
        double num44 = this.tbxStoneWeight.Text.Trim() == "" | this.tbxStoneWeight.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneWeight.Text);
        num36 = this.tbxWastage.Text.Trim() == "" | this.tbxWastage.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxWastage.Text);
        num37 = this.tbxMakingCharge.Text.Trim() == "" | this.tbxMakingCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxMakingCharge.Text);
        num38 = this.tbxStoneCharge.Text.Trim() == "" | this.tbxStoneCharge.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxStoneCharge.Text);
        num39 = this.tbxHallMark.Text.Trim() == "" | this.tbxHallMark.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxHallMark.Text);
        double num45 = this.tbxRate.Text.Trim() == "" | this.tbxRate.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxRate.Text);
        num40 = this.tbxAmount.Text.Trim() == "" | this.tbxAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxAmount.Text);
        double num46 = this.tbxGst.Text.Trim() == "" | this.tbxGst.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGst.Text);
        num41 = this.tbxGstAmount.Text.Trim() == "" | this.tbxGstAmount.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxGstAmount.Text);
        num42 = this.tbxTotal.Text.Trim() == "" | this.tbxTotal.Text.Trim() == "." ? 0.0 : double.Parse(this.tbxTotal.Text);
        this.tbxNetWeight.Text = (num43 - num44).ToString();
        double num47 = num43 * num45;
        TextBox tbxAmount = this.tbxAmount;
        double num48 = Math.Round(double.Parse(num47.ToString()), 0);
        string str7 = num48.ToString();
        tbxAmount.Text = str7;
        double num49 = num47 * num46 / 100.0;
        TextBox tbxGstAmount = this.tbxGstAmount;
        num48 = Math.Round(double.Parse(num49.ToString()), 0);
        string str8 = num48.ToString();
        tbxGstAmount.Text = str8;
        double num50 = num47 + num49;
        TextBox tbxTotal = this.tbxTotal;
        num48 = Math.Round(double.Parse(num50.ToString()), 0);
        string str9 = num48.ToString();
        tbxTotal.Text = str9;
      }
    }

    private void getCustomerDetailssssss(string customerCode)
    {
      string customerCode1 = customerCode;
      this.getPicture(customerCode1);
      this.getCustomerDetails(customerCode1);
      this.dgvCustomerDetails.Visible = false;
      this.tbxItemName.Select();
    }

    private void getCustomerDetails(string customerCode)
    {
      string strError = "";
      string my_querry = "Select tc.CID,tc.CName,tc.CNo,tc.CAddr1,tc.CPhone,tc.CCell,tc.CAddr2,tc.CAddr3,tc.CCity,tc.CPinCode,tc.Cnotes from tblCustomers  tc where tc.CID like @cid  order by CID ";
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
          this.tbxCustomerName.Text = this.tbxCustomerNameSearch.Text = dataTable2.Rows[0].Field<string>("CName");
          this.tbxPhoneNumber.Text = dataTable2.Rows[0].Field<string>("CPhone");
          this.tbxCell.Text = dataTable2.Rows[0].Field<string>("CCell");
          this.tbxNumber.Text = dataTable2.Rows[0].Field<string>("CNo");
          this.tbxAddress1.Text = dataTable2.Rows[0].Field<string>("CAddr1");
          this.tbxAddress2.Text = dataTable2.Rows[0].Field<string>("CAddr2");
          this.tbxAddress3.Text = dataTable2.Rows[0].Field<string>("CAddr3");
          this.tbxCity.Text = dataTable2.Rows[0].Field<string>("CCity");
          this.tbxPincode.Text = dataTable2.Rows[0].Field<string>("CPinCode");
          this.rtbxAddress.Text = dataTable2.Rows[0].Field<string>("CNo") + "," + dataTable2.Rows[0].Field<string>("CAddr1") + "," + dataTable2.Rows[0].Field<string>("CAddr2") + "," + dataTable2.Rows[0].Field<string>("CAddr3") + "," + dataTable2.Rows[0].Field<string>("CCity") + "-" + dataTable2.Rows[0].Field<string>("CPinCode") + "\n" + dataTable2.Rows[0].Field<string>("CPhone");
          if (dataTable2.Rows[0].Field<string>("CNotes").ToString() != "")
          {
            this.tbxNotes.Visible = true;
            this.tbxNotes.Text = dataTable2.Rows[0].Field<string>("CNotes").ToString();
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

    private void getPicture(string customerCode)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
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

    private void getItemNames()
    {
      string strError = "";
      string my_querry = "Select *,t2.Type,t2.Metal from tblItemNames t1 left join tblItemType t2 on t1.ItemType = t2.ItemType where t1.ItemCode like '" + this.tbxItemName.Text + "%' or t1.ItemType like '" + this.tbxItemName.Text + "%'   or t1.ItemName like '" + this.tbxItemName.Text + "%'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvItemNames.BringToFront();
        this.dgvItemNames.Visible = true;
        this.dgvItemNames.DataSource = (object) dataTable2;
        this.dgvItemNames.ClearSelection();
      }
      else
      {
        this.tbxItemName.Text = this.tbxItemName.Text.Substring(0, this.tbxItemName.Text.Length - 1);
        this.tbxItemName.Select(this.tbxItemName.Text.Length, 0);
      }
    }

    private void getItemAndFillAllTheTextBox(string ItemCode, string type)
    {
      DataTable codeBasedOnItemCode = ItemNamesMasterClass.getAllTheItemsIncludingHsnCodeBasedOnItemCode(ItemCode);
      switch (type)
      {
        case "LIVE RATE":
          if (codeBasedOnItemCode == null || codeBasedOnItemCode.Rows.Count <= 0)
            break;
          this.tbxItemName.Text = codeBasedOnItemCode.Rows[0]["ItemName"].ToString();
          this.tbxWastage.Text = codeBasedOnItemCode.Rows[0]["Wastage"].ToString();
          this.tbxMakingCharge.Text = codeBasedOnItemCode.Rows[0]["MakingCharge"].ToString();
          this.tbxStoneCharge.Text = codeBasedOnItemCode.Rows[0]["StoneCharge"].ToString();
          this.tbxHallMark.Text = codeBasedOnItemCode.Rows[0]["HallMark"].ToString();
          this.tbxHsnCode.Text = codeBasedOnItemCode.Rows[0]["HsnCode"].ToString();
          this.tbxWastage.Enabled = true;
          this.tbxMakingCharge.Enabled = true;
          this.tbxStoneCharge.Enabled = true;
          this.tbxHallMark.Enabled = true;
          this.tbxStoneWeight.Enabled = true;
          this.tbxNetWeight.Enabled = true;
          if (PawnManagementClass.checkForValidateDate(this.mtbxBillDate.Text))
            this.tbxRate.Text = RateClass.getTodaysRate(this.tbxMetal.Text, DateTime.Parse(this.mtbxBillDate.Text));
          RateClass.getAllTheDatesInADay(this.mtbxBillDate.Text.Trim());
          this.tbxGst.Text = (double.Parse(codeBasedOnItemCode.Rows[0]["CGst"].ToString()) * 2.0).ToString();
          break;
        case "MRP":
          if (codeBasedOnItemCode == null || codeBasedOnItemCode.Rows.Count <= 0)
            break;
          this.tbxItemName.Text = codeBasedOnItemCode.Rows[0]["ItemName"].ToString();
          this.tbxWastage.Enabled = false;
          this.tbxMakingCharge.Enabled = false;
          this.tbxStoneCharge.Enabled = false;
          this.tbxHallMark.Enabled = false;
          this.tbxStoneWeight.Enabled = false;
          this.tbxNetWeight.Enabled = false;
          this.tbxRate.Text = codeBasedOnItemCode.Rows[0]["SellingPrice"].ToString();
          this.tbxGst.Text = (double.Parse(codeBasedOnItemCode.Rows[0]["CGst"].ToString()) * 2.0).ToString();
          this.tbxHsnCode.Text = codeBasedOnItemCode.Rows[0]["HsnCode"].ToString();
          break;
        case "PER GRAM":
          if (codeBasedOnItemCode != null && codeBasedOnItemCode.Rows.Count > 0)
          {
            this.tbxItemName.Text = codeBasedOnItemCode.Rows[0]["ItemName"].ToString();
            this.tbxWastage.Enabled = false;
            this.tbxMakingCharge.Enabled = false;
            this.tbxStoneCharge.Enabled = false;
            this.tbxHallMark.Enabled = false;
            this.tbxStoneWeight.Enabled = true;
            this.tbxNetWeight.Enabled = true;
            this.tbxRate.Text = codeBasedOnItemCode.Rows[0]["SellingPrice"].ToString();
            this.tbxGst.Text = codeBasedOnItemCode.Rows[0]["CGst"].ToString();
            this.tbxHsnCode.Text = codeBasedOnItemCode.Rows[0]["HsnCode"].ToString();
          }
          break;
      }
    }

    private void reset()
    {
      this.tbxItemCode.Text = string.Empty;
      this.tbxItemName.Text = string.Empty;
      this.tbxQuantity.Text = string.Empty;
      this.tbxStoneWeight.Text = string.Empty;
      this.tbxNetWeight.Text = string.Empty;
      this.tbxMakingCharge.Text = string.Empty;
      this.tbxStoneCharge.Text = string.Empty;
      this.tbxHallMark.Text = string.Empty;
      this.tbxRate.Text = string.Empty;
      this.tbxAmount.Text = string.Empty;
      this.tbxGst.Text = string.Empty;
      this.tbxGstAmount.Text = string.Empty;
      this.tbxTotal.Text = string.Empty;
    }

    private void resetForm()
    {
      this.tbxBillNumber.Text = string.Empty;
      this.tbxItemType.Text = string.Empty;
      this.tbxBilledBy.Text = string.Empty;
      this.tbxSalesPerson.Text = string.Empty;
      this.tbxCustomerNameSearch.Text = string.Empty;
      this.tbxCustomerName.Text = string.Empty;
      this.tbxCustomerCode.Text = string.Empty;
      this.rtbxAddress.Text = string.Empty;
      this.tbxGrandTotal.Text = string.Empty;
      this.tbxDiscount.Text = string.Empty;
      this.tbxRoundOff.Text = string.Empty;
      this.tbxOldPurchase.Text = string.Empty;
      this.tbxNetPayable.Text = string.Empty;
      this.tbxAmountReceived.Text = string.Empty;
      this.tbxBalance.Text = string.Empty;
      this.mtbCommitDate.Text = string.Empty;
      this.tbxItemCode.Text = string.Empty;
      this.tbxItemName.Text = string.Empty;
      this.tbxQuantity.Text = string.Empty;
      this.tbxStoneWeight.Text = string.Empty;
      this.tbxNetWeight.Text = string.Empty;
      this.tbxWastage.Text = string.Empty;
      this.tbxMakingCharge.Text = string.Empty;
      this.tbxStoneCharge.Text = string.Empty;
      this.tbxHallMark.Text = string.Empty;
      this.tbxRate.Text = string.Empty;
      this.tbxAmount.Text = string.Empty;
      this.tbxGst.Text = string.Empty;
      this.tbxGstAmount.Text = string.Empty;
      this.tbxTotal.Text = string.Empty;
      this.dgvSalesDetails.Rows.Clear();
    }

    private bool checkIfSalesDetailsDatagridViewValid()
    {
      if (this.dgvSalesDetails == null || this.dgvSalesDetails.Rows.Count <= 0)
        return false;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvSalesDetails.Rows)
      {
        if (row.Cells["colAmount"] != null && row.Cells["colAmount"].Value != null && row.Cells["colAmount"].Value.ToString() != "" && row.Cells["colGst"] != null && row.Cells["colGst"].Value != null && row.Cells["colGst"].Value.ToString() != "" && row.Cells["colGstAmount"] != null && row.Cells["colGstAmount"].Value != null && row.Cells["colGstAmount"].Value.ToString() != "" && row.Cells["colTotal"] != null && row.Cells["colTotal"].Value != null && row.Cells["colTotal"].Value.ToString() != "")
          return true;
      }
      return false;
    }

    private void calculateGrandTotal()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvSalesDetails.Rows)
      {
        if (row.Cells["colAmount"] != null && row.Cells["colAmount"].Value != null && row.Cells["colAmount"].Value.ToString() != "" && row.Cells["colGst"] != null && row.Cells["colGst"].Value != null && row.Cells["colGst"].Value.ToString() != "" && row.Cells["colGstAmount"] != null && row.Cells["colGstAmount"].Value != null && row.Cells["colGstAmount"].Value.ToString() != "" && row.Cells["colTotal"] != null && row.Cells["colTotal"].Value != null && row.Cells["colTotal"].Value.ToString() != "")
        {
          num1 += double.Parse(row.Cells["colAmount"].Value.ToString());
          num2 += double.Parse(row.Cells["colGstAmount"].Value.ToString());
          num3 += double.Parse(row.Cells["colTotal"].Value.ToString());
          this.tbxTotalAmount.Text = num1.ToString("F");
          this.tbxTotalGstAmount.Text = num2.ToString("F");
          this.tbxGrandTotal.Text = num3.ToString("F");
        }
      }
    }

    private void getCustomerDetailsSimple()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where cid like '" + this.tbxCustomerNameSearch.Text + "%' or CName like '" + this.tbxCustomerNameSearch.Text + "%' or CPhone like '%" + this.tbxCustomerNameSearch.Text + "%'";
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
        this.tbxCustomerNameSearch.Text = this.tbxCustomerNameSearch.Text.Substring(0, this.tbxCustomerNameSearch.Text.Length - 1);
        this.tbxCustomerNameSearch.Select(this.tbxCustomerNameSearch.Text.Length, 0);
      }
    }

    private void btnPrevious_Click(object sender, EventArgs e)
    {
      string str1 = this.tbxBillNumber.Text.Trim();
      string CompanyCode = this.cbCompanyCode.Text.Trim();
      if (CompanyCode == "" | !this.cbCompanyCode.Items.Contains((object) this.cbCompanyCode.Text))
      {
        this.cbCompanyCode.Select();
      }
      else
      {
        string str2 = !(str1 != "") || !(CompanyCode != "") || !SalesClass.checkIfBillNumberAlreadyExists(str1, CompanyCode) ? SalesClass.getMaxtBillNumber(this.cbCompanyCode.Text) : SalesClass.getPreviousBillNumber1(this.cbCompanyCode.Text, str1);
        if (SalesClass.checkIfBillNumberAlreadyExists(str2, CompanyCode))
        {
          this.getBill(CompanyCode, str2);
          this.tbxBillNumber.Enabled = false;
          this.cbCompanyCode.Enabled = false;
          this.cbBillType.Select();
        }
        else
        {
          int num = (int) MessageBox.Show(str2 + "DOES NOT EXIST");
        }
      }
    }

    private void getBill(string CompanyCode, string BillNumber)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable bill1 = SalesClass.getBill(BillNumber, CompanyCode);
      DataTable bill2 = SalesDetailsClass.getBill(BillNumber, CompanyCode);
      if (bill1 == null || bill2 == null || bill1.Rows.Count <= 0 || bill2.Rows.Count <= 0)
        return;
      this.cbCompanyCode.Text = bill1.Rows[0]["Companycode"].ToString();
      this.cbBillType.Text = bill1.Rows[0]["BillType"].ToString();
      this.tbxBillNumber.Text = bill1.Rows[0][nameof (BillNumber)].ToString();
      this.mtbxBillDate.Text = bill1.Rows[0]["BillDate"].ToString();
      this.tbxBilledBy.Text = bill1.Rows[0]["BilledBy"].ToString();
      this.tbxSalesPerson.Text = bill1.Rows[0]["SalesPerson"].ToString();
      this.tbxCustomerCode.Text = bill1.Rows[0]["CustomerCode"].ToString();
      this.tbxGrandTotal.Text = bill1.Rows[0]["GrandTotal"].ToString();
      this.tbxTotalAmount.Text = bill1.Rows[0]["Totalamount"].ToString();
      this.tbxTotalGstAmount.Text = bill1.Rows[0]["TotalGstAmount"].ToString();
      this.tbxDiscount.Text = bill1.Rows[0]["Discount"].ToString();
      this.tbxRoundOff.Text = bill1.Rows[0]["RoundOff"].ToString();
      this.tbxOldPurchase.Text = bill1.Rows[0]["OldPurchase"].ToString();
      this.tbxNetPayable.Text = bill1.Rows[0]["NetPayable"].ToString();
      this.tbxAmountReceived.Text = bill1.Rows[0]["Amountreceived"].ToString();
      this.tbxBalance.Text = bill1.Rows[0]["Balance"].ToString();
      this.mtbCommitDate.Text = bill1.Rows[0]["CommitDate"].ToString();
      DataTable customerDetails = CustomersClass.getCustomerDetails(this.tbxCustomerCode.Text);
      if (customerDetails != null && customerDetails.Rows.Count > 0)
      {
        this.tbxCustomerName.Text = customerDetails.Rows[0]["CName"].ToString();
        this.rtbxAddress.Text = customerDetails.Rows[0].Field<string>("CNo") + "," + customerDetails.Rows[0].Field<string>("CAddr1") + "," + customerDetails.Rows[0].Field<string>("CAddr2") + "," + customerDetails.Rows[0].Field<string>("CAddr3") + "," + customerDetails.Rows[0].Field<string>("CCity") + "-" + customerDetails.Rows[0].Field<string>("CPinCode") + "\n" + customerDetails.Rows[0].Field<string>("CPhone");
      }
      else
      {
        this.tbxCustomerName.Text = "";
        this.rtbxAddress.Text = "";
      }
      this.populateDataGridViewSalesDEtails(BillNumber, CompanyCode);
    }

    private void populateDataGridViewSalesDEtails(string BillNumber, string CompanyCode)
    {
      this.dgvSalesDetails.Rows.Clear();
      DataTable dataTable = new DataTable();
      DataTable bill = SalesDetailsClass.getBill(BillNumber, CompanyCode);
      if (bill == null || bill.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) bill.Rows)
      {
        if (row["Type"].ToString() == "MRP")
          this.dgvSalesDetails.Rows.Add((object) row["Type"].ToString(), (object) row["HsnCode"].ToString(), (object) row["ItemCode"].ToString(), (object) row["Itemname"].ToString(), (object) row["Quantity"].ToString(), (object) row["StoneWeight"].ToString(), (object) row["NetWeight"].ToString(), (object) row["Wastage"].ToString(), (object) row["MakingCharge"].ToString(), (object) row["StoneCharge"].ToString(), (object) row["HallMark"].ToString(), (object) row["Rate"].ToString(), (object) row["Amount"].ToString(), (object) row["Gst"].ToString(), (object) row["GstAmount"].ToString(), (object) row["TotalAmount"].ToString());
        else
          this.dgvSalesDetails.Rows.Add((object) row["Type"].ToString(), (object) row["HsnCode"].ToString(), (object) row["ItemCode"].ToString(), (object) row["Itemname"].ToString(), (object) row["GrossWEight"].ToString(), (object) row["StoneWeight"].ToString(), (object) row["NetWeight"].ToString(), (object) row["Wastage"].ToString(), (object) row["MakingCharge"].ToString(), (object) row["StoneCharge"].ToString(), (object) row["HallMark"].ToString(), (object) row["Rate"].ToString(), (object) row["Amount"].ToString(), (object) row["Gst"].ToString(), (object) row["GstAmount"].ToString(), (object) row["TotalAmount"].ToString());
      }
    }

    private void tbxAmountReceived_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.cbBillType.Text == "CREDIT")
      {
        if (e.KeyCode == Keys.Return)
        {
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }
        else
        {
          if (e.KeyCode != Keys.Up)
            return;
          this.SelectNextControl(this.ActiveControl, false, true, true, true);
        }
      }
      else if (e.KeyCode == Keys.Return)
        this.btnSave.Select();
      else if (e.KeyCode == Keys.Up)
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      string str = this.tbxBillNumber.Text.Trim();
      string CompanyCode = this.cbCompanyCode.Text.Trim();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      if (CompanyCode == "" | !this.cbCompanyCode.Items.Contains((object) this.cbCompanyCode.Text))
      {
        this.cbCompanyCode.Select();
      }
      else
      {
        if (str != "" && CompanyCode != "" && SalesClass.checkIfBillNumberAlreadyExists(str, CompanyCode))
          str = SalesClass.getNextBillNumber1(this.cbCompanyCode.Text, str);
        if (SalesClass.checkIfBillNumberAlreadyExists(str, CompanyCode))
        {
          this.getBill(CompanyCode, str);
          this.tbxBillNumber.Enabled = false;
          this.cbCompanyCode.Enabled = false;
          this.cbBillType.Select();
        }
        else
        {
          int num = (int) MessageBox.Show(str + "DOES NOT EXIST");
        }
      }
    }

    private void btnNewBill_Click(object sender, EventArgs e)
    {
      if (this.dgvSalesDetails != null && this.dgvSalesDetails.Rows.Count > 0)
      {
        if (!SalesClass.checkIfBillNumberAlreadyExists(this.tbxBillNumber.Text, this.cbCompanyCode.Text))
        {
          if (DialogResult.Yes == MessageBox.Show("DatatEntered Will Be lost.Want to Continue?", "DatatEntered Will Be lost.Want to Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          {
            this.resetForm();
            this.cbCompanyCode.Enabled = true;
            this.tbxBillNumber.Enabled = true;
            this.cbCompanyCode.Select();
          }
          else
            this.tbxItemName.Select();
        }
        else
        {
          this.resetForm();
          this.cbCompanyCode.Enabled = true;
          this.tbxBillNumber.Enabled = true;
          this.cbCompanyCode.Select();
        }
      }
      else
      {
        this.resetForm();
        this.cbCompanyCode.Enabled = true;
        this.tbxBillNumber.Enabled = true;
        this.cbCompanyCode.Select();
      }
    }

    private void cbCompanyCode_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbBillType.Select();
    }

    private void cbBillType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.tbxBillNumber.Enabled)
        this.tbxBillNumber.Select();
      else
        this.mtbxBillDate.Select();
    }

    private void FormNewSales_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
        this.btnNewBill.PerformClick();
      else if (e.KeyCode == Keys.F2)
        this.btnPrevious.PerformClick();
      else if (e.KeyCode == Keys.F3)
        this.btnNext.PerformClick();
      else if (e.KeyCode == Keys.F4)
        this.btnClose.PerformClick();
      else if (e.KeyCode == Keys.F5)
      {
        this.btnSave.PerformClick();
      }
      else
      {
        if (e.KeyCode != Keys.F6)
          return;
        this.btnDelete.PerformClick();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.cbCompanyCode.Text != "" && this.cbCompanyCode.Items.Contains((object) this.cbCompanyCode.Text))
      {
        if (SalesClass.checkIfBillNumberAlreadyExists(this.tbxBillNumber.Text, this.cbCompanyCode.Text))
        {
          if (DialogResult.Yes != MessageBox.Show("Delete?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            return;
          SalesClass.deleteSales(this.cbCompanyCode.Text, this.tbxBillNumber.Text);
          this.cbCompanyCode.Enabled = true;
          this.tbxBillNumber.Enabled = true;
          this.resetForm();
          this.cbCompanyCode.Select();
        }
        else
        {
          int num = (int) MessageBox.Show("BillNumber Does Not Exits ...Select correct BillNumber..");
          this.tbxBillNumber.Select();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("select Company..");
        this.cbCompanyCode.Select();
      }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Print?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      int num = (int) new FormDuplicateBill().ShowDialog();
    }

    private void dgvSalesDetails_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        if (this.dgvSalesDetails == null || this.dgvSalesDetails.Rows.Count <= 0 || this.dgvSalesDetails.CurrentCell == null)
          return;
        this.dgvSalesDetails.Rows.RemoveAt(this.dgvSalesDetails.CurrentCell.RowIndex);
        this.calculateGrandTotal();
      }
      else
      {
        if (e.KeyCode != Keys.Up || this.dgvSalesDetails == null || this.dgvSalesDetails.Rows.Count <= 0 || this.dgvSalesDetails.CurrentCell == null || this.dgvSalesDetails.CurrentCell.RowIndex != 0)
          return;
        this.tbxItemName.Select();
      }
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.tbxItemType.Text == "LIVE RATE")
      {
        if (this.tbxItemCode.Text.Trim() != "")
        {
          if (this.tbxItemName.Text.Trim() != "")
          {
            if (this.tbxQuantity.Text.Trim() != "" && double.Parse(this.tbxQuantity.Text) > 0.0)
            {
              if (this.tbxNetWeight.Text.Trim() != "" && double.Parse(this.tbxNetWeight.Text) > 0.0)
              {
                if (this.tbxWastage.Text.Trim() != "")
                {
                  if (this.tbxRate.Text.Trim() != "" && double.Parse(this.tbxRate.Text) > 0.0)
                  {
                    if (this.tbxAmount.Text.Trim() != "" && double.Parse(this.tbxAmount.Text) >= 0.0)
                    {
                      if (this.tbxGst.Text.Trim() != "" && double.Parse(this.tbxGst.Text) >= 0.0)
                      {
                        if (this.tbxGstAmount.Text.Trim() != "" && double.Parse(this.tbxGstAmount.Text) >= 0.0)
                        {
                          if (this.tbxTotal.Text.Trim() != "" && double.Parse(this.tbxTotal.Text) >= 0.0)
                            return true;
                          this.tbxRate.Select();
                          return false;
                        }
                        this.tbxRate.Select();
                        return false;
                      }
                      this.tbxRate.Select();
                      return false;
                    }
                    this.tbxRate.Select();
                    return false;
                  }
                  this.tbxRate.Select();
                  return false;
                }
                this.tbxWastage.Select();
                return false;
              }
              this.tbxStoneWeight.Select();
              return false;
            }
            this.tbxQuantity.Select();
            return false;
          }
          this.tbxItemName.Select();
          return false;
        }
        this.tbxItemCode.Select();
        return false;
      }
      if (this.tbxItemType.Text == "PER GRAM")
      {
        if (this.tbxItemCode.Text.Trim() != "")
        {
          if (this.tbxItemName.Text.Trim() != "")
          {
            if (this.tbxQuantity.Text.Trim() != "" && double.Parse(this.tbxQuantity.Text) > 0.0)
            {
              if (this.tbxNetWeight.Text.Trim() != "" && double.Parse(this.tbxNetWeight.Text) > 0.0)
              {
                if (this.tbxRate.Text.Trim() != "" && double.Parse(this.tbxRate.Text) > 0.0)
                {
                  if (this.tbxAmount.Text.Trim() != "" && double.Parse(this.tbxAmount.Text) >= 0.0)
                  {
                    if (this.tbxGst.Text.Trim() != "" && double.Parse(this.tbxGst.Text) >= 0.0)
                    {
                      if (this.tbxGstAmount.Text.Trim() != "" && double.Parse(this.tbxGstAmount.Text) >= 0.0)
                      {
                        if (this.tbxTotal.Text.Trim() != "" && double.Parse(this.tbxTotal.Text) >= 0.0)
                          return true;
                        this.tbxRate.Select();
                        return false;
                      }
                      this.tbxRate.Select();
                      return false;
                    }
                    this.tbxRate.Select();
                    return false;
                  }
                  this.tbxRate.Select();
                  return false;
                }
                this.tbxRate.Select();
                return false;
              }
              this.tbxStoneWeight.Select();
              return false;
            }
            this.tbxQuantity.Select();
            return false;
          }
          this.tbxItemName.Select();
          return false;
        }
        this.tbxItemCode.Select();
        return false;
      }
      if (!(this.tbxItemType.Text == "MRP"))
        return false;
      if (this.tbxItemCode.Text.Trim() != "")
      {
        if (this.tbxItemName.Text.Trim() != "")
        {
          if (this.tbxQuantity.Text.Trim() != "" && double.Parse(this.tbxQuantity.Text) > 0.0)
          {
            if (this.tbxRate.Text.Trim() != "" && double.Parse(this.tbxRate.Text) > 0.0)
            {
              if (this.tbxAmount.Text.Trim() != "" && double.Parse(this.tbxAmount.Text) >= 0.0)
              {
                if (this.tbxGst.Text.Trim() != "" && double.Parse(this.tbxGst.Text) >= 0.0)
                {
                  if (this.tbxGstAmount.Text.Trim() != "" && double.Parse(this.tbxGstAmount.Text) >= 0.0)
                  {
                    if (this.tbxTotal.Text.Trim() != "" && double.Parse(this.tbxTotal.Text) >= 0.0)
                      return true;
                    this.tbxRate.Select();
                    return false;
                  }
                  this.tbxRate.Select();
                  return false;
                }
                this.tbxRate.Select();
                return false;
              }
              this.tbxRate.Select();
              return false;
            }
            this.tbxRate.Select();
            return false;
          }
          this.tbxQuantity.Select();
          return false;
        }
        this.tbxItemName.Select();
        return false;
      }
      this.tbxItemCode.Select();
      return false;
    }

    private bool checkIfAllTheEnteriesAreMadeBeforeSaving()
    {
      if (this.cbCompanyCode.Text != null && this.cbCompanyCode.Text != "" && CompanyDetailsClass.checkIfCompanyAlreadyExists(this.cbCompanyCode.Text))
      {
        if (this.cbBillType.Text != "" && this.cbBillType.Items.Contains((object) this.cbBillType.Text))
        {
          if (this.tbxBillNumber.Text != "")
          {
            if (this.mtbxBillDate.Text != "" && PawnManagementClass.checkForValidateDate(this.mtbxBillDate.Text))
            {
              if (this.tbxBilledBy.Text != "" && BillerClass.checkIfBillerAlreadyExists(this.tbxBilledBy.Text))
              {
                if (this.tbxTotalAmount.Text != "" && double.Parse(this.tbxTotalAmount.Text) > 0.0)
                {
                  if (this.tbxTotalGstAmount.Text != "" && double.Parse(this.tbxTotalGstAmount.Text) > 0.0)
                  {
                    if (this.tbxGrandTotal.Text != "" && double.Parse(this.tbxGrandTotal.Text) > 0.0)
                    {
                      if (this.tbxDiscount.Text != "" && double.Parse(this.tbxDiscount.Text) < double.Parse(this.tbxGrandTotal.Text))
                      {
                        if (this.tbxRoundOff.Text != "" && double.Parse(this.tbxRoundOff.Text) < double.Parse(this.tbxGrandTotal.Text))
                        {
                          if (this.tbxNetPayable.Text != "" && double.Parse(this.tbxNetPayable.Text) >= 0.0)
                          {
                            if (this.tbxAmountReceived.Text != "" && double.Parse(this.tbxAmountReceived.Text) >= 0.0)
                            {
                              if (this.tbxBalance.Text != "")
                              {
                                if (PawnManagementClass.checkForValidateDate(this.mtbCommitDate.Text) && DateTime.Parse(this.mtbCommitDate.Text) >= DateTime.Parse(this.mtbxBillDate.Text))
                                  return true;
                                this.mtbCommitDate.Select();
                                return false;
                              }
                              this.tbxBalance.Select();
                              return false;
                            }
                            this.tbxAmountReceived.Select();
                            return false;
                          }
                          this.tbxNetPayable.Select();
                          return false;
                        }
                        this.tbxRoundOff.Select();
                        return false;
                      }
                      this.tbxDiscount.Select();
                      return false;
                    }
                    this.tbxGrandTotal.Select();
                    return false;
                  }
                  this.tbxTotalGstAmount.Select();
                  return false;
                }
                this.tbxTotalAmount.Select();
                return false;
              }
              this.tbxBilledBy.Select();
              return false;
            }
            this.mtbxBillDate.Select();
            return false;
          }
          this.tbxBillNumber.Select();
          return false;
        }
        this.cbBillType.Select();
        return false;
      }
      this.cbCompanyCode.Select();
      return false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormNewSales));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      this.panel1 = new Panel();
      this.tbxHsnCode = new TextBox();
      this.panel4 = new Panel();
      this.panel3 = new Panel();
      this.btnPrint = new Button();
      this.btnDelete = new Button();
      this.btnNewBill = new Button();
      this.btnPrevious = new Button();
      this.btnNext = new Button();
      this.btnClose = new Button();
      this.tbxTotalGstAmount = new TextBox();
      this.tbxTotalAmount = new TextBox();
      this.tbxMetal = new TextBox();
      this.btnSave = new Button();
      this.mtbCommitDate = new MaskedTextBox();
      this.tbxItemType = new TextBox();
      this.tbxItemCode = new TextBox();
      this.lblRate = new Label();
      this.tbxRate = new TextBox();
      this.dgvItemNames = new DataGridView();
      this.tbxNotes = new TextBox();
      this.panel2 = new Panel();
      this.tbxCity = new TextBox();
      this.tbxNumber = new TextBox();
      this.tbxAddress1 = new TextBox();
      this.tbxPincode = new TextBox();
      this.tbxAddress2 = new TextBox();
      this.tbxCell = new TextBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxAddress3 = new TextBox();
      this.label30 = new Label();
      this.rtbxAddress = new RichTextBox();
      this.label29 = new Label();
      this.tbxCustomerName = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.mtbxBillDate = new MaskedTextBox();
      this.dgvCustomerDetails = new DataGridView();
      this.label28 = new Label();
      this.cbCompanyCode = new ComboBox();
      this.btnOldPurchase = new Button();
      this.label25 = new Label();
      this.label26 = new Label();
      this.label27 = new Label();
      this.tbxBalance = new TextBox();
      this.tbxAmountReceived = new TextBox();
      this.label20 = new Label();
      this.tbxNetPayable = new TextBox();
      this.label21 = new Label();
      this.label22 = new Label();
      this.tbxOldPurchase = new TextBox();
      this.tbxRoundOff = new TextBox();
      this.label23 = new Label();
      this.label24 = new Label();
      this.tbxDiscount = new TextBox();
      this.tbxGrandTotal = new TextBox();
      this.dgvSalesDetails = new DataGridView();
      this.colType = new DataGridViewTextBoxColumn();
      this.colHsnCode = new DataGridViewTextBoxColumn();
      this.colItemCode = new DataGridViewTextBoxColumn();
      this.colItemName = new DataGridViewTextBoxColumn();
      this.colQuantity = new DataGridViewTextBoxColumn();
      this.colStoneWeight = new DataGridViewTextBoxColumn();
      this.colNetWeight = new DataGridViewTextBoxColumn();
      this.colWastage = new DataGridViewTextBoxColumn();
      this.colMakingCharge = new DataGridViewTextBoxColumn();
      this.colStoneCharge = new DataGridViewTextBoxColumn();
      this.colHallMark = new DataGridViewTextBoxColumn();
      this.colRate = new DataGridViewTextBoxColumn();
      this.colAmount = new DataGridViewTextBoxColumn();
      this.colGst = new DataGridViewTextBoxColumn();
      this.colGstAmount = new DataGridViewTextBoxColumn();
      this.colTotal = new DataGridViewTextBoxColumn();
      this.label19 = new Label();
      this.lblQuantity = new Label();
      this.label17 = new Label();
      this.label16 = new Label();
      this.label15 = new Label();
      this.label14 = new Label();
      this.label13 = new Label();
      this.label12 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.tbxItemName = new TextBox();
      this.tbxQuantity = new TextBox();
      this.tbxStoneWeight = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.tbxWastage = new TextBox();
      this.tbxMakingCharge = new TextBox();
      this.tbxStoneCharge = new TextBox();
      this.tbxHallMark = new TextBox();
      this.tbxAmount = new TextBox();
      this.tbxGst = new TextBox();
      this.tbxGstAmount = new TextBox();
      this.tbxTotal = new TextBox();
      this.label6 = new Label();
      this.tbxCustomerNameSearch = new TextBox();
      this.label4 = new Label();
      this.label5 = new Label();
      this.tbxSalesPerson = new TextBox();
      this.tbxBilledBy = new TextBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.cbBillType = new ComboBox();
      this.tbxBillNumber = new TextBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dgvItemNames).BeginInit();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.dgvCustomerDetails).BeginInit();
      ((ISupportInitialize) this.dgvSalesDetails).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.WhiteSmoke;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.tbxHsnCode);
      this.panel1.Controls.Add((Control) this.panel4);
      this.panel1.Controls.Add((Control) this.panel3);
      this.panel1.Controls.Add((Control) this.btnPrint);
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Controls.Add((Control) this.btnNewBill);
      this.panel1.Controls.Add((Control) this.btnPrevious);
      this.panel1.Controls.Add((Control) this.btnNext);
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.tbxTotalGstAmount);
      this.panel1.Controls.Add((Control) this.tbxTotalAmount);
      this.panel1.Controls.Add((Control) this.tbxMetal);
      this.panel1.Controls.Add((Control) this.btnSave);
      this.panel1.Controls.Add((Control) this.mtbCommitDate);
      this.panel1.Controls.Add((Control) this.tbxItemType);
      this.panel1.Controls.Add((Control) this.tbxItemCode);
      this.panel1.Controls.Add((Control) this.lblRate);
      this.panel1.Controls.Add((Control) this.tbxRate);
      this.panel1.Controls.Add((Control) this.dgvItemNames);
      this.panel1.Controls.Add((Control) this.tbxNotes);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label30);
      this.panel1.Controls.Add((Control) this.rtbxAddress);
      this.panel1.Controls.Add((Control) this.label29);
      this.panel1.Controls.Add((Control) this.tbxCustomerName);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.mtbxBillDate);
      this.panel1.Controls.Add((Control) this.dgvCustomerDetails);
      this.panel1.Controls.Add((Control) this.label28);
      this.panel1.Controls.Add((Control) this.cbCompanyCode);
      this.panel1.Controls.Add((Control) this.btnOldPurchase);
      this.panel1.Controls.Add((Control) this.label25);
      this.panel1.Controls.Add((Control) this.label26);
      this.panel1.Controls.Add((Control) this.label27);
      this.panel1.Controls.Add((Control) this.tbxBalance);
      this.panel1.Controls.Add((Control) this.tbxAmountReceived);
      this.panel1.Controls.Add((Control) this.label20);
      this.panel1.Controls.Add((Control) this.tbxNetPayable);
      this.panel1.Controls.Add((Control) this.label21);
      this.panel1.Controls.Add((Control) this.label22);
      this.panel1.Controls.Add((Control) this.tbxOldPurchase);
      this.panel1.Controls.Add((Control) this.tbxRoundOff);
      this.panel1.Controls.Add((Control) this.label23);
      this.panel1.Controls.Add((Control) this.label24);
      this.panel1.Controls.Add((Control) this.tbxDiscount);
      this.panel1.Controls.Add((Control) this.tbxGrandTotal);
      this.panel1.Controls.Add((Control) this.dgvSalesDetails);
      this.panel1.Controls.Add((Control) this.label19);
      this.panel1.Controls.Add((Control) this.lblQuantity);
      this.panel1.Controls.Add((Control) this.label17);
      this.panel1.Controls.Add((Control) this.label16);
      this.panel1.Controls.Add((Control) this.label15);
      this.panel1.Controls.Add((Control) this.label14);
      this.panel1.Controls.Add((Control) this.label13);
      this.panel1.Controls.Add((Control) this.label12);
      this.panel1.Controls.Add((Control) this.label11);
      this.panel1.Controls.Add((Control) this.label10);
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label8);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.tbxItemName);
      this.panel1.Controls.Add((Control) this.tbxQuantity);
      this.panel1.Controls.Add((Control) this.tbxStoneWeight);
      this.panel1.Controls.Add((Control) this.tbxNetWeight);
      this.panel1.Controls.Add((Control) this.tbxWastage);
      this.panel1.Controls.Add((Control) this.tbxMakingCharge);
      this.panel1.Controls.Add((Control) this.tbxStoneCharge);
      this.panel1.Controls.Add((Control) this.tbxHallMark);
      this.panel1.Controls.Add((Control) this.tbxAmount);
      this.panel1.Controls.Add((Control) this.tbxGst);
      this.panel1.Controls.Add((Control) this.tbxGstAmount);
      this.panel1.Controls.Add((Control) this.tbxTotal);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.tbxCustomerNameSearch);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.tbxSalesPerson);
      this.panel1.Controls.Add((Control) this.tbxBilledBy);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.cbBillType);
      this.panel1.Controls.Add((Control) this.tbxBillNumber);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.ForeColor = Color.FromArgb(238, 26, 74);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1024, 670);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.tbxHsnCode.Location = new Point(647, 143);
      this.tbxHsnCode.Name = "tbxHsnCode";
      this.tbxHsnCode.Size = new Size(74, 20);
      this.tbxHsnCode.TabIndex = 86;
      this.panel4.Dock = DockStyle.Bottom;
      this.panel4.Location = new Point(0, 657);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(1022, 11);
      this.panel4.TabIndex = 85;
      this.panel3.Dock = DockStyle.Top;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1022, 10);
      this.panel3.TabIndex = 84;
      this.btnPrint.Anchor = AnchorStyles.Bottom;
      this.btnPrint.BackColor = Color.Transparent;
      this.btnPrint.FlatAppearance.BorderColor = Color.Black;
      this.btnPrint.FlatAppearance.BorderSize = 0;
      this.btnPrint.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnPrint.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnPrint.FlatStyle = FlatStyle.Popup;
      this.btnPrint.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPrint.ForeColor = Color.Black;
      this.btnPrint.Image = (Image) componentResourceManager.GetObject("btnPrint.Image");
      this.btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnPrint.Location = new Point(591, 549);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(120, 51);
      this.btnPrint.TabIndex = 83;
      this.btnPrint.Text = "&Print(F7)";
      this.btnPrint.TextAlign = ContentAlignment.MiddleRight;
      this.btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnPrint.UseVisualStyleBackColor = false;
      this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
      this.btnDelete.Anchor = AnchorStyles.Bottom;
      this.btnDelete.BackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.BorderColor = Color.Black;
      this.btnDelete.FlatAppearance.BorderSize = 0;
      this.btnDelete.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnDelete.FlatStyle = FlatStyle.Popup;
      this.btnDelete.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDelete.ForeColor = Color.Black;
      this.btnDelete.Image = (Image) componentResourceManager.GetObject("btnDelete.Image");
      this.btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnDelete.Location = new Point(404, 549);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(136, 51);
      this.btnDelete.TabIndex = 82;
      this.btnDelete.Text = "&Delete(F6)";
      this.btnDelete.TextAlign = ContentAlignment.MiddleRight;
      this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
      this.btnNewBill.Anchor = AnchorStyles.Bottom;
      this.btnNewBill.BackColor = Color.Transparent;
      this.btnNewBill.FlatAppearance.BorderColor = Color.Black;
      this.btnNewBill.FlatAppearance.BorderSize = 0;
      this.btnNewBill.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnNewBill.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnNewBill.FlatStyle = FlatStyle.Popup;
      this.btnNewBill.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnNewBill.ForeColor = Color.Black;
      this.btnNewBill.Image = (Image) componentResourceManager.GetObject("btnNewBill.Image");
      this.btnNewBill.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnNewBill.Location = new Point(32, 606);
      this.btnNewBill.Name = "btnNewBill";
      this.btnNewBill.Size = new Size(145, 51);
      this.btnNewBill.TabIndex = 81;
      this.btnNewBill.Text = "&New Bill (F1)";
      this.btnNewBill.TextAlign = ContentAlignment.MiddleRight;
      this.btnNewBill.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnNewBill.UseVisualStyleBackColor = false;
      this.btnNewBill.Click += new EventHandler(this.btnNewBill_Click);
      this.btnPrevious.Anchor = AnchorStyles.Bottom;
      this.btnPrevious.BackColor = Color.Transparent;
      this.btnPrevious.FlatAppearance.BorderColor = Color.Black;
      this.btnPrevious.FlatAppearance.BorderSize = 0;
      this.btnPrevious.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnPrevious.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnPrevious.FlatStyle = FlatStyle.Popup;
      this.btnPrevious.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPrevious.ForeColor = Color.Black;
      this.btnPrevious.Image = (Image) componentResourceManager.GetObject("btnPrevious.Image");
      this.btnPrevious.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnPrevious.Location = new Point(219, 606);
      this.btnPrevious.Name = "btnPrevious";
      this.btnPrevious.Size = new Size(160, 51);
      this.btnPrevious.TabIndex = 80;
      this.btnPrevious.Text = "&Previous (F2)";
      this.btnPrevious.TextAlign = ContentAlignment.MiddleRight;
      this.btnPrevious.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnPrevious.UseVisualStyleBackColor = false;
      this.btnPrevious.Click += new EventHandler(this.btnPrevious_Click);
      this.btnNext.Anchor = AnchorStyles.Bottom;
      this.btnNext.BackColor = Color.Transparent;
      this.btnNext.FlatAppearance.BorderColor = Color.Black;
      this.btnNext.FlatAppearance.BorderSize = 0;
      this.btnNext.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnNext.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnNext.FlatStyle = FlatStyle.Popup;
      this.btnNext.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnNext.ForeColor = Color.Black;
      this.btnNext.Image = (Image) componentResourceManager.GetObject("btnNext.Image");
      this.btnNext.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnNext.Location = new Point(404, 606);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new Size(120, 51);
      this.btnNext.TabIndex = 79;
      this.btnNext.Text = "&Next (F3)";
      this.btnNext.TextAlign = ContentAlignment.MiddleRight;
      this.btnNext.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnNext.UseVisualStyleBackColor = false;
      this.btnNext.Click += new EventHandler(this.btnNext_Click);
      this.btnClose.Anchor = AnchorStyles.Bottom;
      this.btnClose.BackColor = Color.Transparent;
      this.btnClose.FlatAppearance.BorderColor = Color.Black;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnClose.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnClose.FlatStyle = FlatStyle.Popup;
      this.btnClose.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnClose.ForeColor = Color.Black;
      this.btnClose.Image = (Image) componentResourceManager.GetObject("btnClose.Image");
      this.btnClose.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnClose.Location = new Point(778, 606);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(137, 51);
      this.btnClose.TabIndex = 78;
      this.btnClose.Text = " &Close(F4)";
      this.btnClose.TextAlign = ContentAlignment.MiddleRight;
      this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnClose.UseVisualStyleBackColor = false;
      this.tbxTotalGstAmount.Anchor = AnchorStyles.Bottom;
      this.tbxTotalGstAmount.Location = new Point(580, 440);
      this.tbxTotalGstAmount.Name = "tbxTotalGstAmount";
      this.tbxTotalGstAmount.ReadOnly = true;
      this.tbxTotalGstAmount.Size = new Size(74, 20);
      this.tbxTotalGstAmount.TabIndex = 75;
      this.tbxTotalAmount.Anchor = AnchorStyles.Bottom;
      this.tbxTotalAmount.Location = new Point(491, 440);
      this.tbxTotalAmount.Name = "tbxTotalAmount";
      this.tbxTotalAmount.ReadOnly = true;
      this.tbxTotalAmount.Size = new Size(74, 20);
      this.tbxTotalAmount.TabIndex = 74;
      this.tbxMetal.Anchor = AnchorStyles.Bottom;
      this.tbxMetal.Location = new Point(20, 440);
      this.tbxMetal.Name = "tbxMetal";
      this.tbxMetal.Size = new Size(74, 20);
      this.tbxMetal.TabIndex = 73;
      this.btnSave.Anchor = AnchorStyles.Bottom;
      this.btnSave.BackColor = Color.Transparent;
      this.btnSave.FlatAppearance.BorderColor = Color.Black;
      this.btnSave.FlatAppearance.BorderSize = 0;
      this.btnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnSave.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnSave.FlatStyle = FlatStyle.Popup;
      this.btnSave.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.Black;
      this.btnSave.Image = (Image) componentResourceManager.GetObject("btnSave.Image");
      this.btnSave.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSave.Location = new Point(591, 606);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(130, 51);
      this.btnSave.TabIndex = 28;
      this.btnSave.Text = "&Save (F5)";
      this.btnSave.TextAlign = ContentAlignment.MiddleRight;
      this.btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.mtbCommitDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.mtbCommitDate.BeepOnError = true;
      this.mtbCommitDate.BorderStyle = BorderStyle.FixedSingle;
      this.mtbCommitDate.Location = new Point(870, 576);
      this.mtbCommitDate.Mask = "00/00/0000";
      this.mtbCommitDate.Name = "mtbCommitDate";
      this.mtbCommitDate.Size = new Size(121, 20);
      this.mtbCommitDate.TabIndex = 27;
      this.mtbCommitDate.ValidatingType = typeof (DateTime);
      this.mtbCommitDate.KeyDown += new KeyEventHandler(this.mtbCommitDate_KeyDown);
      this.mtbCommitDate.Validating += new CancelEventHandler(this.mtbCommitDate_Validating);
      this.tbxItemType.Anchor = AnchorStyles.Bottom;
      this.tbxItemType.Enabled = false;
      this.tbxItemType.Location = new Point(20, 492);
      this.tbxItemType.Name = "tbxItemType";
      this.tbxItemType.Size = new Size(74, 20);
      this.tbxItemType.TabIndex = 71;
      this.tbxItemCode.Anchor = AnchorStyles.Bottom;
      this.tbxItemCode.Enabled = false;
      this.tbxItemCode.Location = new Point(20, 466);
      this.tbxItemCode.Name = "tbxItemCode";
      this.tbxItemCode.Size = new Size(74, 20);
      this.tbxItemCode.TabIndex = 70;
      this.lblRate.AutoSize = true;
      this.lblRate.Location = new Point(617, 186);
      this.lblRate.Name = "lblRate";
      this.lblRate.Size = new Size(36, 13);
      this.lblRate.TabIndex = 69;
      this.lblRate.Text = "RATE";
      this.tbxRate.Location = new Point(616, 206);
      this.tbxRate.Name = "tbxRate";
      this.tbxRate.Size = new Size(74, 20);
      this.tbxRate.TabIndex = 15;
      this.tbxRate.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxRate.KeyDown += new KeyEventHandler(this.tbxRate_KeyDown);
      this.tbxRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxRate.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.dgvItemNames.AllowUserToAddRows = false;
      this.dgvItemNames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvItemNames.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.Silver;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvItemNames.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvItemNames.ColumnHeadersHeight = 25;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.WhiteSmoke;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.FromArgb(238, 26, 74);
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvItemNames.DefaultCellStyle = gridViewCellStyle2;
      this.dgvItemNames.EnableHeadersVisualStyles = false;
      this.dgvItemNames.Location = new Point(16, 232);
      this.dgvItemNames.Name = "dgvItemNames";
      this.dgvItemNames.RowHeadersVisible = false;
      this.dgvItemNames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvItemNames.Size = new Size(974, 197);
      this.dgvItemNames.TabIndex = 67;
      this.dgvItemNames.Visible = false;
      this.dgvItemNames.KeyDown += new KeyEventHandler(this.dgvItemNames_KeyDown);
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(269, 150);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(124, 22);
      this.tbxNotes.TabIndex = 66;
      this.tbxNotes.Visible = false;
      this.panel2.Controls.Add((Control) this.tbxCity);
      this.panel2.Controls.Add((Control) this.tbxNumber);
      this.panel2.Controls.Add((Control) this.tbxAddress1);
      this.panel2.Controls.Add((Control) this.tbxPincode);
      this.panel2.Controls.Add((Control) this.tbxAddress2);
      this.panel2.Controls.Add((Control) this.tbxCell);
      this.panel2.Controls.Add((Control) this.tbxCustomerCode);
      this.panel2.Controls.Add((Control) this.tbxPhoneNumber);
      this.panel2.Controls.Add((Control) this.tbxAddress3);
      this.panel2.Location = new Point(15, 44);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(18, 19);
      this.panel2.TabIndex = 65;
      this.panel2.Visible = false;
      this.tbxCity.BackColor = Color.AliceBlue;
      this.tbxCity.BorderStyle = BorderStyle.None;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.ForeColor = Color.MidnightBlue;
      this.tbxCity.Location = new Point(-82, 104);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(201, 15);
      this.tbxCity.TabIndex = 32;
      this.tbxNumber.BackColor = Color.AliceBlue;
      this.tbxNumber.BorderStyle = BorderStyle.None;
      this.tbxNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumber.ForeColor = Color.MidnightBlue;
      this.tbxNumber.Location = new Point(-82, 32);
      this.tbxNumber.Name = "tbxNumber";
      this.tbxNumber.Size = new Size(130, 15);
      this.tbxNumber.TabIndex = 36;
      this.tbxAddress1.BackColor = Color.AliceBlue;
      this.tbxAddress1.BorderStyle = BorderStyle.None;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.ForeColor = Color.MidnightBlue;
      this.tbxAddress1.Location = new Point(54, 32);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(314, 15);
      this.tbxAddress1.TabIndex = 3;
      this.tbxPincode.BackColor = Color.AliceBlue;
      this.tbxPincode.BorderStyle = BorderStyle.None;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.ForeColor = Color.MidnightBlue;
      this.tbxPincode.Location = new Point((int) sbyte.MaxValue, 104);
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(240, 15);
      this.tbxPincode.TabIndex = 3;
      this.tbxAddress2.BackColor = Color.AliceBlue;
      this.tbxAddress2.BorderStyle = BorderStyle.None;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.ForeColor = Color.MidnightBlue;
      this.tbxAddress2.Location = new Point(-82, 55);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(450, 15);
      this.tbxAddress2.TabIndex = 2;
      this.tbxCell.BackColor = Color.AliceBlue;
      this.tbxCell.BorderStyle = BorderStyle.None;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.ForeColor = Color.MidnightBlue;
      this.tbxCell.Location = new Point(128, 128);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(239, 15);
      this.tbxCell.TabIndex = 35;
      this.tbxCustomerCode.BackColor = Color.AliceBlue;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(-82, 8);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(95, 15);
      this.tbxCustomerCode.TabIndex = 30;
      this.tbxCustomerCode.TextAlign = HorizontalAlignment.Center;
      this.tbxPhoneNumber.BackColor = Color.AliceBlue;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.None;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.ForeColor = Color.MidnightBlue;
      this.tbxPhoneNumber.Location = new Point(-82, 129);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(204, 15);
      this.tbxPhoneNumber.TabIndex = 34;
      this.tbxAddress3.BackColor = Color.AliceBlue;
      this.tbxAddress3.BorderStyle = BorderStyle.None;
      this.tbxAddress3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress3.ForeColor = Color.MidnightBlue;
      this.tbxAddress3.Location = new Point(-82, 80);
      this.tbxAddress3.Name = "tbxAddress3";
      this.tbxAddress3.Size = new Size(450, 15);
      this.tbxAddress3.TabIndex = 2;
      this.label30.AutoSize = true;
      this.label30.Location = new Point(406, 89);
      this.label30.Name = "label30";
      this.label30.Size = new Size(59, 13);
      this.label30.TabIndex = 64;
      this.label30.Text = "ADDRESS";
      this.rtbxAddress.BorderStyle = BorderStyle.None;
      this.rtbxAddress.Location = new Point(407, 105);
      this.rtbxAddress.Name = "rtbxAddress";
      this.rtbxAddress.Size = new Size(211, 64);
      this.rtbxAddress.TabIndex = 63;
      this.rtbxAddress.Text = "";
      this.label29.AutoSize = true;
      this.label29.Location = new Point(406, 43);
      this.label29.Name = "label29";
      this.label29.Size = new Size(38, 13);
      this.label29.TabIndex = 62;
      this.label29.Text = "NAME";
      this.tbxCustomerName.Location = new Point(407, 59);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(211, 20);
      this.tbxCustomerName.TabIndex = 61;
      this.pictureBox1.Location = new Point(269, 42);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(124, 130);
      this.pictureBox1.TabIndex = 60;
      this.pictureBox1.TabStop = false;
      this.mtbxBillDate.BeepOnError = true;
      this.mtbxBillDate.BorderStyle = BorderStyle.FixedSingle;
      this.mtbxBillDate.Location = new Point(119, 99);
      this.mtbxBillDate.Mask = "00/00/0000";
      this.mtbxBillDate.Name = "mtbxBillDate";
      this.mtbxBillDate.Size = new Size(121, 20);
      this.mtbxBillDate.TabIndex = 3;
      this.mtbxBillDate.ValidatingType = typeof (DateTime);
      this.mtbxBillDate.KeyDown += new KeyEventHandler(this.mtbxBillDate_KeyDown);
      this.mtbxBillDate.Validating += new CancelEventHandler(this.maskedTextBox1_Validating);
      this.dgvCustomerDetails.AllowUserToAddRows = false;
      this.dgvCustomerDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = Color.Silver;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dgvCustomerDetails.ColumnHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dgvCustomerDetails.ColumnHeadersHeight = 25;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = Color.WhiteSmoke;
      gridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.FromArgb(238, 26, 74);
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.False;
      this.dgvCustomerDetails.DefaultCellStyle = gridViewCellStyle4;
      this.dgvCustomerDetails.EnableHeadersVisualStyles = false;
      this.dgvCustomerDetails.Location = new Point(16, 232);
      this.dgvCustomerDetails.Name = "dgvCustomerDetails";
      this.dgvCustomerDetails.RowHeadersVisible = false;
      this.dgvCustomerDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvCustomerDetails.Size = new Size(974, 197);
      this.dgvCustomerDetails.TabIndex = 59;
      this.dgvCustomerDetails.Visible = false;
      this.dgvCustomerDetails.KeyDown += new KeyEventHandler(this.dgvCustomerDetails_KeyDown);
      this.dgvCustomerDetails.KeyUp += new KeyEventHandler(this.dgvCustomerDetails_KeyUp);
      this.dgvCustomerDetails.Leave += new EventHandler(this.dgvCustomerDetails_Leave);
      this.label28.AutoSize = true;
      this.label28.Location = new Point(12, 20);
      this.label28.Name = "label28";
      this.label28.Size = new Size(104, 13);
      this.label28.TabIndex = 58;
      this.label28.Text = "SELECT COMPANY";
      this.cbCompanyCode.FormattingEnabled = true;
      this.cbCompanyCode.Location = new Point(119, 16);
      this.cbCompanyCode.Name = "cbCompanyCode";
      this.cbCompanyCode.Size = new Size(121, 21);
      this.cbCompanyCode.TabIndex = 0;
      this.cbCompanyCode.KeyDown += new KeyEventHandler(this.cbCompanyCode_KeyDown);
      this.cbCompanyCode.Validating += new CancelEventHandler(this.cbCompanyCode_Validating);
      this.btnOldPurchase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOldPurchase.Location = new Point(869, 495);
      this.btnOldPurchase.Name = "btnOldPurchase";
      this.btnOldPurchase.Size = new Size(29, 23);
      this.btnOldPurchase.TabIndex = 35;
      this.btnOldPurchase.Text = "+";
      this.btnOldPurchase.UseVisualStyleBackColor = true;
      this.label25.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label25.AutoSize = true;
      this.label25.Location = new Point(783, 579);
      this.label25.Name = "label25";
      this.label25.Size = new Size(82, 13);
      this.label25.TabIndex = 55;
      this.label25.Text = "COMMIT DATE";
      this.label26.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label26.AutoSize = true;
      this.label26.Location = new Point(809, 559);
      this.label26.Name = "label26";
      this.label26.Size = new Size(56, 13);
      this.label26.TabIndex = 53;
      this.label26.Text = "BALANCE";
      this.label27.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label27.AutoSize = true;
      this.label27.Location = new Point(771, 540);
      this.label27.Name = "label27";
      this.label27.Size = new Size(94, 13);
      this.label27.TabIndex = 52;
      this.label27.Text = "AMOUNT RECVD";
      this.tbxBalance.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxBalance.Location = new Point(870, 556);
      this.tbxBalance.Name = "tbxBalance";
      this.tbxBalance.ReadOnly = true;
      this.tbxBalance.Size = new Size(121, 20);
      this.tbxBalance.TabIndex = 26;
      this.tbxBalance.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxAmountReceived.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxAmountReceived.Location = new Point(870, 536);
      this.tbxAmountReceived.Name = "tbxAmountReceived";
      this.tbxAmountReceived.Size = new Size(121, 20);
      this.tbxAmountReceived.TabIndex = 25;
      this.tbxAmountReceived.TextChanged += new EventHandler(this.tbxAmountReceived_TextChanged);
      this.tbxAmountReceived.KeyDown += new KeyEventHandler(this.tbxAmountReceived_KeyDown);
      this.tbxAmountReceived.KeyPress += new KeyPressEventHandler(this.tbxAmountReceived_KeyPress);
      this.tbxAmountReceived.Validating += new CancelEventHandler(this.tbxRoundOFFTo2AndAPPENDZERORES_Validating);
      this.label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label20.AutoSize = true;
      this.label20.Location = new Point(785, 519);
      this.label20.Name = "label20";
      this.label20.Size = new Size(80, 13);
      this.label20.TabIndex = 49;
      this.label20.Text = "NET PAYABLE";
      this.tbxNetPayable.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxNetPayable.Location = new Point(870, 516);
      this.tbxNetPayable.Name = "tbxNetPayable";
      this.tbxNetPayable.Size = new Size(121, 20);
      this.tbxNetPayable.TabIndex = 24;
      this.tbxNetPayable.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxNetPayable.Validating += new CancelEventHandler(this.tbxRoundOff_Validating);
      this.label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label21.AutoSize = true;
      this.label21.Location = new Point(774, 499);
      this.label21.Name = "label21";
      this.label21.Size = new Size(91, 13);
      this.label21.TabIndex = 47;
      this.label21.Text = "OLD PURCHASE";
      this.label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label22.AutoSize = true;
      this.label22.Location = new Point(795, 480);
      this.label22.Name = "label22";
      this.label22.Size = new Size(70, 13);
      this.label22.TabIndex = 46;
      this.label22.Text = "ROUND OFF";
      this.tbxOldPurchase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxOldPurchase.Location = new Point(898, 496);
      this.tbxOldPurchase.Name = "tbxOldPurchase";
      this.tbxOldPurchase.Size = new Size(93, 20);
      this.tbxOldPurchase.TabIndex = 23;
      this.tbxOldPurchase.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxOldPurchase.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.tbxRoundOff.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxRoundOff.Location = new Point(870, 476);
      this.tbxRoundOff.Name = "tbxRoundOff";
      this.tbxRoundOff.Size = new Size(121, 20);
      this.tbxRoundOff.TabIndex = 22;
      this.tbxRoundOff.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxRoundOff.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxRoundOff.Validating += new CancelEventHandler(this.tbxRoundOff_Validating);
      this.label23.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label23.AutoSize = true;
      this.label23.Location = new Point(802, 459);
      this.label23.Name = "label23";
      this.label23.Size = new Size(63, 13);
      this.label23.TabIndex = 43;
      this.label23.Text = "DISCOUNT";
      this.label24.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label24.AutoSize = true;
      this.label24.Location = new Point(781, 440);
      this.label24.Name = "label24";
      this.label24.Size = new Size(84, 13);
      this.label24.TabIndex = 42;
      this.label24.Text = "GRAND TOTAL";
      this.tbxDiscount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxDiscount.Location = new Point(870, 456);
      this.tbxDiscount.Name = "tbxDiscount";
      this.tbxDiscount.Size = new Size(121, 20);
      this.tbxDiscount.TabIndex = 21;
      this.tbxDiscount.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxDiscount.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxDiscount.Validating += new CancelEventHandler(this.tbxDiscount_Validating);
      this.tbxGrandTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbxGrandTotal.Location = new Point(870, 436);
      this.tbxGrandTotal.Name = "tbxGrandTotal";
      this.tbxGrandTotal.ReadOnly = true;
      this.tbxGrandTotal.Size = new Size(121, 20);
      this.tbxGrandTotal.TabIndex = 20;
      this.tbxGrandTotal.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.dgvSalesDetails.AllowUserToAddRows = false;
      this.dgvSalesDetails.AllowUserToDeleteRows = false;
      this.dgvSalesDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvSalesDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSalesDetails.ColumnHeadersHeight = 25;
      this.dgvSalesDetails.Columns.AddRange((DataGridViewColumn) this.colType, (DataGridViewColumn) this.colHsnCode, (DataGridViewColumn) this.colItemCode, (DataGridViewColumn) this.colItemName, (DataGridViewColumn) this.colQuantity, (DataGridViewColumn) this.colStoneWeight, (DataGridViewColumn) this.colNetWeight, (DataGridViewColumn) this.colWastage, (DataGridViewColumn) this.colMakingCharge, (DataGridViewColumn) this.colStoneCharge, (DataGridViewColumn) this.colHallMark, (DataGridViewColumn) this.colRate, (DataGridViewColumn) this.colAmount, (DataGridViewColumn) this.colGst, (DataGridViewColumn) this.colGstAmount, (DataGridViewColumn) this.colTotal);
      this.dgvSalesDetails.EnableHeadersVisualStyles = false;
      this.dgvSalesDetails.Location = new Point(16, 232);
      this.dgvSalesDetails.Name = "dgvSalesDetails";
      this.dgvSalesDetails.ReadOnly = true;
      this.dgvSalesDetails.RowHeadersVisible = false;
      this.dgvSalesDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSalesDetails.Size = new Size(975, 199);
      this.dgvSalesDetails.TabIndex = 39;
      this.dgvSalesDetails.KeyDown += new KeyEventHandler(this.dgvSalesDetails_KeyDown);
      this.colType.HeaderText = "Type";
      this.colType.Name = "colType";
      this.colType.ReadOnly = true;
      this.colType.Visible = false;
      this.colHsnCode.HeaderText = "HsnCode";
      this.colHsnCode.Name = "colHsnCode";
      this.colHsnCode.ReadOnly = true;
      this.colItemCode.HeaderText = "ItemCode";
      this.colItemCode.Name = "colItemCode";
      this.colItemCode.ReadOnly = true;
      this.colItemName.HeaderText = "ItemName";
      this.colItemName.Name = "colItemName";
      this.colItemName.ReadOnly = true;
      this.colQuantity.HeaderText = "Quantity";
      this.colQuantity.Name = "colQuantity";
      this.colQuantity.ReadOnly = true;
      this.colStoneWeight.HeaderText = "StoneWeight";
      this.colStoneWeight.Name = "colStoneWeight";
      this.colStoneWeight.ReadOnly = true;
      this.colNetWeight.HeaderText = "NetWeight";
      this.colNetWeight.Name = "colNetWeight";
      this.colNetWeight.ReadOnly = true;
      this.colWastage.HeaderText = "Wastage";
      this.colWastage.Name = "colWastage";
      this.colWastage.ReadOnly = true;
      this.colMakingCharge.HeaderText = "MakingCharge";
      this.colMakingCharge.Name = "colMakingCharge";
      this.colMakingCharge.ReadOnly = true;
      this.colStoneCharge.HeaderText = "StoneCharge";
      this.colStoneCharge.Name = "colStoneCharge";
      this.colStoneCharge.ReadOnly = true;
      this.colHallMark.HeaderText = "HallMark";
      this.colHallMark.Name = "colHallMark";
      this.colHallMark.ReadOnly = true;
      this.colRate.HeaderText = "Rate";
      this.colRate.Name = "colRate";
      this.colRate.ReadOnly = true;
      this.colAmount.HeaderText = "Amount";
      this.colAmount.Name = "colAmount";
      this.colAmount.ReadOnly = true;
      this.colGst.HeaderText = "Gst";
      this.colGst.Name = "colGst";
      this.colGst.ReadOnly = true;
      this.colGstAmount.HeaderText = "GstAmount";
      this.colGstAmount.Name = "colGstAmount";
      this.colGstAmount.ReadOnly = true;
      this.colTotal.HeaderText = "Total";
      this.colTotal.Name = "colTotal";
      this.colTotal.ReadOnly = true;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(16, 186);
      this.label19.Name = "label19";
      this.label19.Size = new Size(67, 13);
      this.label19.TabIndex = 38;
      this.label19.Text = "ITEM NAME";
      this.lblQuantity.AutoSize = true;
      this.lblQuantity.Location = new Point(92, 186);
      this.lblQuantity.Name = "lblQuantity";
      this.lblQuantity.Size = new Size(62, 13);
      this.lblQuantity.TabIndex = 37;
      this.lblQuantity.Text = "QUANTITY";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(93, 186);
      this.label17.Name = "label17";
      this.label17.Size = new Size(66, 13);
      this.label17.TabIndex = 36;
      this.label17.Text = "GROSS WT";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(167, 186);
      this.label16.Name = "label16";
      this.label16.Size = new Size(65, 13);
      this.label16.TabIndex = 35;
      this.label16.Text = "STONE WT";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(241, 186);
      this.label15.Name = "label15";
      this.label15.Size = new Size(50, 13);
      this.label15.TabIndex = 34;
      this.label15.Text = "NET WT";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(318, 186);
      this.label14.Name = "label14";
      this.label14.Size = new Size(61, 13);
      this.label14.TabIndex = 33;
      this.label14.Text = "WASTAGE";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(392, 186);
      this.label13.Name = "label13";
      this.label13.Size = new Size(23, 13);
      this.label13.TabIndex = 32;
      this.label13.Text = "MC";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(466, 186);
      this.label12.Name = "label12";
      this.label12.Size = new Size(21, 13);
      this.label12.TabIndex = 31;
      this.label12.Text = "SC";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(542, 186);
      this.label11.Name = "label11";
      this.label11.Size = new Size(65, 13);
      this.label11.TabIndex = 30;
      this.label11.Text = "HALLMARK";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(691, 186);
      this.label10.Name = "label10";
      this.label10.Size = new Size(54, 13);
      this.label10.TabIndex = 29;
      this.label10.Text = "AMOUNT";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(767, 186);
      this.label9.Name = "label9";
      this.label9.Size = new Size(29, 13);
      this.label9.TabIndex = 28;
      this.label9.Text = "GST";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(839, 186);
      this.label8.Name = "label8";
      this.label8.Size = new Size(79, 13);
      this.label8.TabIndex = 27;
      this.label8.Text = "GST AMOUNT";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(917, 186);
      this.label7.Name = "label7";
      this.label7.Size = new Size(42, 13);
      this.label7.TabIndex = 26;
      this.label7.Text = "TOTAL";
      this.tbxItemName.Location = new Point(16, 206);
      this.tbxItemName.Name = "tbxItemName";
      this.tbxItemName.Size = new Size(74, 20);
      this.tbxItemName.TabIndex = 7;
      this.tbxItemName.TextChanged += new EventHandler(this.tbxItemName_TextChanged);
      this.tbxItemName.KeyDown += new KeyEventHandler(this.tbxItemName_KeyDown);
      this.tbxQuantity.Location = new Point(91, 206);
      this.tbxQuantity.Name = "tbxQuantity";
      this.tbxQuantity.Size = new Size(74, 20);
      this.tbxQuantity.TabIndex = 8;
      this.tbxQuantity.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxQuantity.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxQuantity.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxQuantity.Validating += new CancelEventHandler(this.tbxQuantity_Validating);
      this.tbxStoneWeight.Location = new Point(166, 206);
      this.tbxStoneWeight.Name = "tbxStoneWeight";
      this.tbxStoneWeight.Size = new Size(74, 20);
      this.tbxStoneWeight.TabIndex = 9;
      this.tbxStoneWeight.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxStoneWeight.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxStoneWeight.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxStoneWeight.Validating += new CancelEventHandler(this.tbxRoundOFFTo2AndAPPENDZERORES_Validating);
      this.tbxNetWeight.Location = new Point(241, 206);
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.Size = new Size(74, 20);
      this.tbxNetWeight.TabIndex = 10;
      this.tbxNetWeight.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxNetWeight.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxNetWeight.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxNetWeight.Validating += new CancelEventHandler(this.tbxRoundOFFTo2AndAPPENDZERORES_Validating);
      this.tbxWastage.Location = new Point(316, 206);
      this.tbxWastage.Name = "tbxWastage";
      this.tbxWastage.Size = new Size(74, 20);
      this.tbxWastage.TabIndex = 11;
      this.tbxWastage.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxWastage.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxWastage.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxWastage.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.tbxMakingCharge.Location = new Point(391, 206);
      this.tbxMakingCharge.Name = "tbxMakingCharge";
      this.tbxMakingCharge.Size = new Size(74, 20);
      this.tbxMakingCharge.TabIndex = 12;
      this.tbxMakingCharge.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxMakingCharge.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxMakingCharge.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxMakingCharge.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.tbxStoneCharge.Location = new Point(466, 206);
      this.tbxStoneCharge.Name = "tbxStoneCharge";
      this.tbxStoneCharge.Size = new Size(74, 20);
      this.tbxStoneCharge.TabIndex = 13;
      this.tbxStoneCharge.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxStoneCharge.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxStoneCharge.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxStoneCharge.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.tbxHallMark.Location = new Point(541, 206);
      this.tbxHallMark.Name = "tbxHallMark";
      this.tbxHallMark.Size = new Size(74, 20);
      this.tbxHallMark.TabIndex = 14;
      this.tbxHallMark.TextChanged += new EventHandler(this.tbx_TextChanged);
      this.tbxHallMark.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxHallMark.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxHallMark.Validating += new CancelEventHandler(this.tbxRoundOFFTo1AndAPPENDZERORES2_Validating);
      this.tbxAmount.Location = new Point(691, 206);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.ReadOnly = true;
      this.tbxAmount.Size = new Size(74, 20);
      this.tbxAmount.TabIndex = 16;
      this.tbxAmount.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxDonAcceptAnyInput);
      this.tbxGst.Location = new Point(766, 206);
      this.tbxGst.Name = "tbxGst";
      this.tbxGst.ReadOnly = true;
      this.tbxGst.Size = new Size(74, 20);
      this.tbxGst.TabIndex = 17;
      this.tbxGst.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxGst.KeyPress += new KeyPressEventHandler(this.tbxDonAcceptAnyInput);
      this.tbxGstAmount.Location = new Point(841, 206);
      this.tbxGstAmount.Name = "tbxGstAmount";
      this.tbxGstAmount.ReadOnly = true;
      this.tbxGstAmount.Size = new Size(74, 20);
      this.tbxGstAmount.TabIndex = 18;
      this.tbxGstAmount.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxGstAmount.KeyPress += new KeyPressEventHandler(this.tbxDonAcceptAnyInput);
      this.tbxTotal.Location = new Point(916, 206);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.ReadOnly = true;
      this.tbxTotal.Size = new Size(74, 20);
      this.tbxTotal.TabIndex = 19;
      this.tbxTotal.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxTotal.KeyPress += new KeyPressEventHandler(this.tbxDonAcceptAnyInput);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(308, 20);
      this.label6.Name = "label6";
      this.label6.Size = new Size(83, 13);
      this.label6.TabIndex = 12;
      this.label6.Text = "CUST SEARCH";
      this.tbxCustomerNameSearch.Location = new Point(404, 16);
      this.tbxCustomerNameSearch.Name = "tbxCustomerNameSearch";
      this.tbxCustomerNameSearch.Size = new Size(211, 20);
      this.tbxCustomerNameSearch.TabIndex = 6;
      this.tbxCustomerNameSearch.TextChanged += new EventHandler(this.tbxCustomerNameSearch_TextChanged);
      this.tbxCustomerNameSearch.KeyDown += new KeyEventHandler(this.tbxCustomerNameSearch_KeyDown);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(22, 159);
      this.label4.Name = "label4";
      this.label4.Size = new Size(89, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "SALES PERSON";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(50, 132);
      this.label5.Name = "label5";
      this.label5.Size = new Size(61, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "BILLED BY";
      this.tbxSalesPerson.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxSalesPerson.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSalesPerson.Location = new Point(119, 153);
      this.tbxSalesPerson.Name = "tbxSalesPerson";
      this.tbxSalesPerson.Size = new Size(121, 20);
      this.tbxSalesPerson.TabIndex = 5;
      this.tbxSalesPerson.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxBilledBy.Location = new Point(119, 126);
      this.tbxBilledBy.Name = "tbxBilledBy";
      this.tbxBilledBy.Size = new Size(121, 20);
      this.tbxBilledBy.TabIndex = 4;
      this.tbxBilledBy.Enter += new EventHandler(this.tbxBilledBy_Enter);
      this.tbxBilledBy.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(50, 103);
      this.label3.Name = "label3";
      this.label3.Size = new Size(61, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "BILL DATE";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(32, 76);
      this.label2.Name = "label2";
      this.label2.Size = new Size(79, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "BILL NUMBER";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(51, 46);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "BILL TYPE";
      this.cbBillType.FormattingEnabled = true;
      this.cbBillType.Items.AddRange(new object[3]
      {
        (object) "CASH",
        (object) "CREDIT",
        (object) "ESTIMATE"
      });
      this.cbBillType.Location = new Point(119, 44);
      this.cbBillType.Name = "cbBillType";
      this.cbBillType.Size = new Size(121, 21);
      this.cbBillType.TabIndex = 1;
      this.cbBillType.Text = "CASH";
      this.cbBillType.SelectedIndexChanged += new EventHandler(this.cbBillType_SelectedIndexChanged);
      this.cbBillType.KeyDown += new KeyEventHandler(this.cbBillType_KeyDown);
      this.cbBillType.Validating += new CancelEventHandler(this.cbBillType_Validating);
      this.tbxBillNumber.Location = new Point(119, 72);
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(121, 20);
      this.tbxBillNumber.TabIndex = 2;
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.Validating += new CancelEventHandler(this.tbxBillNumber_Validating);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1024, 670);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.Name = nameof (FormNewSales);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "New Sales";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.FormNewSales_Load);
      this.KeyDown += new KeyEventHandler(this.FormNewSales_KeyDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.dgvItemNames).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.dgvCustomerDetails).EndInit();
      ((ISupportInitialize) this.dgvSalesDetails).EndInit();
      this.ResumeLayout(false);
    }
  }
}
