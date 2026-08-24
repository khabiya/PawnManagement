
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormMultipleRelease : Form
  {
    public static double shopInterestRate = 16.0;
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
    private List<string> lstPledgeBillNumbers = new List<string>();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn colShopCode;
    private DataGridViewTextBoxColumn colVoucherDate;
    private DataGridViewTextBoxColumn colVoucherNumber;
    private DataGridViewTextBoxColumn colVoucherCode;
    private DataGridViewTextBoxColumn colVoucherName;
    private DataGridViewTextBoxColumn colVoucherDescription;
    private DataGridViewTextBoxColumn colLedgerCode;
    private DataGridViewTextBoxColumn colJammaNovae;
    private DataGridViewTextBoxColumn colVoucherCodeInterest;
    private DataGridViewTextBoxColumn colVoucherNameInterest;
    private DataGridViewTextBoxColumn colVoucherDescriptionInterest;
    private DataGridViewTextBoxColumn colLedgerCodeInterest;
    private DataGridViewTextBoxColumn colJammaOrNovaeInterest;
    private DataGridViewTextBoxColumn colRedemptionBillNumber;
    private DataGridViewTextBoxColumn colBillDate;
    private DataGridViewTextBoxColumn colPledgeBillNumber;
    private DataGridViewTextBoxColumn colCustomerCode;
    private DataGridViewTextBoxColumn colReleasedBy;
    private DataGridViewTextBoxColumn colPledgeDate;
    private DataGridViewTextBoxColumn colAmount;
    private DataGridViewTextBoxColumn colRateOfInterest;
    private DataGridViewTextBoxColumn colInterest;
    private DataGridViewTextBoxColumn colInterestLess;
    private DataGridViewTextBoxColumn colNoticeCharge;
    private DataGridViewTextBoxColumn colOtherCharge;
    private DataGridViewTextBoxColumn colDeductions;
    private DataGridViewTextBoxColumn colFinalInterest;
    private DataGridViewTextBoxColumn colTotalRedemptionAmount;
    private DataGridViewTextBoxColumn colNoOfMonths;
    private DataGridViewTextBoxColumn colNoOfMonths16;
    private DataGridViewTextBoxColumn colInterest16;
    private DataGridViewTextBoxColumn colRedemptionAmount16;
    private DataGridViewTextBoxColumn colCreatedOn;
    private DataGridViewTextBoxColumn colCreatedBy;
    private DataGridViewTextBoxColumn colBilledBy;
    private Panel panel10;
    private ComboBox cbShopCodes;
    private Label label12;
    private Panel panel9;
    private TextBox tbxPledgeBillNumber;
    private Label label11;
    private Panel panel1;
    private ComboBox cbSelectAction;
    private Label label1;
    private Panel panel2;
    private ComboBox cbPrintFormD3;
    private Label label2;
    private Panel panel3;
    private TextBox tbxAmount;
    private Label label3;
    private Panel panel4;
    private TextBox tbxRoi;
    private Label label4;
    private Button btnAdd;
    private Panel panel5;
    private Label label5;
    private ComboBox cbPrint;

    public FormMultipleRelease() => this.InitializeComponent();

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

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxPledgeBillNumber.Select();
    }

    private void cbSelectAction_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbPrintFormD3.Select();
    }

    private void cbPrintFormD3_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxAmount.Select();
    }

    private void cbPrint_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnAdd.Focus();
    }

    private void btnAdd_Click(object sender, EventArgs e) => this.dataGridView1.Rows.Add();

    private void tbxPledgeBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              break;
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (!PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
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

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void tbxRoundOFFTo2AndAPPENDZERORES_Validating(object sender, CancelEventArgs e) => (sender as TextBox).Text = PawnManagementClass.appenZeroes(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 2).ToString());

    private void tbxRoundOFFTo1AndAPPENDZERORES2_Validating(object sender, CancelEventArgs e) => (sender as TextBox).Text = PawnManagementClass.appenZeroes2(Math.Round(double.Parse((sender as TextBox).Text.Trim() == "" | (sender as TextBox).Text.Trim() == "." ? "0" : (sender as TextBox).Text), 1).ToString());

    private void FormMultipleRelease_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxPledgeBillNumber.MaxLength = 7;
      this.cbShopCodes.DataSource = (object) FormMain.lstShopCodes;
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.cbShopCodes.Select();
      this.cbSelectAction.SelectedIndex = 0;
      this.cbPrintFormD3.SelectedIndex = 0;
      this.cbPrint.SelectedIndex = 0;
      this.Assign((Control) this);
    }

    private void cbShopCodes_Enter(object sender, EventArgs e)
    {
      if (this.cbShopCodes.Items.Count != 1)
        return;
      this.cbShopCodes.SelectedIndex = 0;
      SendKeys.Send("{Enter}");
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        FormMultipleRelease.shopInterestRate = ShopDetailsClass.getInterestRate(this.cbShopCodes.Text);
        this.lstPledgeBillNumbers = PawnManagement.PledgeClass.getUndredeemedBillNumbers(this.cbShopCodes.Text);
        this.tbxPledgeBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
        this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
        this.tbxPledgeBillNumber.Select();
        this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxPledgeBillNumber.AutoCompleteCustomSource.Clear();
        this.tbxPledgeBillNumber.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
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
        DataTable basedOnThisColumn = ShopDetailsClass.getAllTheRecordsBasedOnThisColumn("shopcode", this.cbShopCodes.Text);
        if (basedOnThisColumn == null || basedOnThisColumn.Rows.Count <= 0)
          return;
        this.ledgerCode = basedOnThisColumn.Rows[0]["ledgercode"].ToString();
        this.voucherCode = basedOnThisColumn.Rows[0]["vouchercode"].ToString();
        this.ledgerCodeInterest = basedOnThisColumn.Rows[0]["ledgercodeinterest"].ToString();
        this.voucherCodeInterestGirvi = basedOnThisColumn.Rows[0]["vouchercodeinterestgirvi"].ToString();
        this.voucherCodeInterestChoot = basedOnThisColumn.Rows[0]["vouchercodeinterestChoot"].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException(" form pledge.getledgerandvouchercode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormMultipleRelease));
      this.dataGridView1 = new DataGridView();
      this.colShopCode = new DataGridViewTextBoxColumn();
      this.colVoucherDate = new DataGridViewTextBoxColumn();
      this.colVoucherNumber = new DataGridViewTextBoxColumn();
      this.colVoucherCode = new DataGridViewTextBoxColumn();
      this.colVoucherName = new DataGridViewTextBoxColumn();
      this.colVoucherDescription = new DataGridViewTextBoxColumn();
      this.colLedgerCode = new DataGridViewTextBoxColumn();
      this.colJammaNovae = new DataGridViewTextBoxColumn();
      this.colVoucherCodeInterest = new DataGridViewTextBoxColumn();
      this.colVoucherNameInterest = new DataGridViewTextBoxColumn();
      this.colVoucherDescriptionInterest = new DataGridViewTextBoxColumn();
      this.colLedgerCodeInterest = new DataGridViewTextBoxColumn();
      this.colJammaOrNovaeInterest = new DataGridViewTextBoxColumn();
      this.colRedemptionBillNumber = new DataGridViewTextBoxColumn();
      this.colBillDate = new DataGridViewTextBoxColumn();
      this.colPledgeBillNumber = new DataGridViewTextBoxColumn();
      this.colCustomerCode = new DataGridViewTextBoxColumn();
      this.colReleasedBy = new DataGridViewTextBoxColumn();
      this.colPledgeDate = new DataGridViewTextBoxColumn();
      this.colAmount = new DataGridViewTextBoxColumn();
      this.colRateOfInterest = new DataGridViewTextBoxColumn();
      this.colInterest = new DataGridViewTextBoxColumn();
      this.colInterestLess = new DataGridViewTextBoxColumn();
      this.colNoticeCharge = new DataGridViewTextBoxColumn();
      this.colOtherCharge = new DataGridViewTextBoxColumn();
      this.colDeductions = new DataGridViewTextBoxColumn();
      this.colFinalInterest = new DataGridViewTextBoxColumn();
      this.colTotalRedemptionAmount = new DataGridViewTextBoxColumn();
      this.colNoOfMonths = new DataGridViewTextBoxColumn();
      this.colNoOfMonths16 = new DataGridViewTextBoxColumn();
      this.colInterest16 = new DataGridViewTextBoxColumn();
      this.colRedemptionAmount16 = new DataGridViewTextBoxColumn();
      this.colCreatedOn = new DataGridViewTextBoxColumn();
      this.colCreatedBy = new DataGridViewTextBoxColumn();
      this.colBilledBy = new DataGridViewTextBoxColumn();
      this.panel10 = new Panel();
      this.cbShopCodes = new ComboBox();
      this.label12 = new Label();
      this.panel9 = new Panel();
      this.tbxPledgeBillNumber = new TextBox();
      this.label11 = new Label();
      this.panel1 = new Panel();
      this.cbSelectAction = new ComboBox();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.cbPrintFormD3 = new ComboBox();
      this.label2 = new Label();
      this.panel3 = new Panel();
      this.tbxAmount = new TextBox();
      this.label3 = new Label();
      this.panel4 = new Panel();
      this.tbxRoi = new TextBox();
      this.label4 = new Label();
      this.btnAdd = new Button();
      this.panel5 = new Panel();
      this.label5 = new Label();
      this.cbPrint = new ComboBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panel10.SuspendLayout();
      this.panel9.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel5.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colShopCode, (DataGridViewColumn) this.colVoucherDate, (DataGridViewColumn) this.colVoucherNumber, (DataGridViewColumn) this.colVoucherCode, (DataGridViewColumn) this.colVoucherName, (DataGridViewColumn) this.colVoucherDescription, (DataGridViewColumn) this.colLedgerCode, (DataGridViewColumn) this.colJammaNovae, (DataGridViewColumn) this.colVoucherCodeInterest, (DataGridViewColumn) this.colVoucherNameInterest, (DataGridViewColumn) this.colVoucherDescriptionInterest, (DataGridViewColumn) this.colLedgerCodeInterest, (DataGridViewColumn) this.colJammaOrNovaeInterest, (DataGridViewColumn) this.colRedemptionBillNumber, (DataGridViewColumn) this.colBillDate, (DataGridViewColumn) this.colPledgeBillNumber, (DataGridViewColumn) this.colCustomerCode, (DataGridViewColumn) this.colReleasedBy, (DataGridViewColumn) this.colPledgeDate, (DataGridViewColumn) this.colAmount, (DataGridViewColumn) this.colRateOfInterest, (DataGridViewColumn) this.colInterest, (DataGridViewColumn) this.colInterestLess, (DataGridViewColumn) this.colNoticeCharge, (DataGridViewColumn) this.colOtherCharge, (DataGridViewColumn) this.colDeductions, (DataGridViewColumn) this.colFinalInterest, (DataGridViewColumn) this.colTotalRedemptionAmount, (DataGridViewColumn) this.colNoOfMonths, (DataGridViewColumn) this.colNoOfMonths16, (DataGridViewColumn) this.colInterest16, (DataGridViewColumn) this.colRedemptionAmount16, (DataGridViewColumn) this.colCreatedOn, (DataGridViewColumn) this.colCreatedBy, (DataGridViewColumn) this.colBilledBy);
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(28, 183);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new Size(941, 286);
      this.dataGridView1.TabIndex = 8;
      this.colShopCode.HeaderText = "ShopCode";
      this.colShopCode.Name = "colShopCode";
      this.colVoucherDate.HeaderText = "VoucherDate";
      this.colVoucherDate.Name = "colVoucherDate";
      this.colVoucherNumber.HeaderText = "VoucherNumber";
      this.colVoucherNumber.Name = "colVoucherNumber";
      this.colVoucherCode.HeaderText = "VoucherCode";
      this.colVoucherCode.Name = "colVoucherCode";
      this.colVoucherName.HeaderText = "VoucherName";
      this.colVoucherName.Name = "colVoucherName";
      this.colVoucherDescription.HeaderText = "VoucherDescription";
      this.colVoucherDescription.Name = "colVoucherDescription";
      this.colLedgerCode.HeaderText = "LedgerCode";
      this.colLedgerCode.Name = "colLedgerCode";
      this.colJammaNovae.HeaderText = "JammaOrNovae";
      this.colJammaNovae.Name = "colJammaNovae";
      this.colVoucherCodeInterest.HeaderText = "VoucherCodeInterest";
      this.colVoucherCodeInterest.Name = "colVoucherCodeInterest";
      this.colVoucherNameInterest.HeaderText = "VoucherNameInterest";
      this.colVoucherNameInterest.Name = "colVoucherNameInterest";
      this.colVoucherDescriptionInterest.HeaderText = "VoucherDescriptionInterest";
      this.colVoucherDescriptionInterest.Name = "colVoucherDescriptionInterest";
      this.colLedgerCodeInterest.HeaderText = "LedgerCodeInterest";
      this.colLedgerCodeInterest.Name = "colLedgerCodeInterest";
      this.colJammaOrNovaeInterest.HeaderText = "JammaOrNovaeInterest";
      this.colJammaOrNovaeInterest.Name = "colJammaOrNovaeInterest";
      this.colRedemptionBillNumber.HeaderText = "RedemptionBillNumber";
      this.colRedemptionBillNumber.Name = "colRedemptionBillNumber";
      this.colBillDate.HeaderText = "BillDate";
      this.colBillDate.Name = "colBillDate";
      this.colPledgeBillNumber.HeaderText = "PledgeBillNumber";
      this.colPledgeBillNumber.Name = "colPledgeBillNumber";
      this.colCustomerCode.HeaderText = "CustomerCode";
      this.colCustomerCode.Name = "colCustomerCode";
      this.colReleasedBy.HeaderText = "ReleasedBy";
      this.colReleasedBy.Name = "colReleasedBy";
      this.colPledgeDate.HeaderText = "PledgeDate";
      this.colPledgeDate.Name = "colPledgeDate";
      this.colAmount.HeaderText = "Amount";
      this.colAmount.Name = "colAmount";
      this.colRateOfInterest.HeaderText = "RateOfInterest";
      this.colRateOfInterest.Name = "colRateOfInterest";
      this.colInterest.HeaderText = "Interest";
      this.colInterest.Name = "colInterest";
      this.colInterestLess.HeaderText = "InterestLess";
      this.colInterestLess.Name = "colInterestLess";
      this.colNoticeCharge.HeaderText = "NoticeCharge";
      this.colNoticeCharge.Name = "colNoticeCharge";
      this.colOtherCharge.HeaderText = "OtherCharge";
      this.colOtherCharge.Name = "colOtherCharge";
      this.colDeductions.HeaderText = "Deductions";
      this.colDeductions.Name = "colDeductions";
      this.colFinalInterest.HeaderText = "FinalInterest";
      this.colFinalInterest.Name = "colFinalInterest";
      this.colTotalRedemptionAmount.HeaderText = "TotalRedemptionAmount";
      this.colTotalRedemptionAmount.Name = "colTotalRedemptionAmount";
      this.colNoOfMonths.HeaderText = "NoOfMonths";
      this.colNoOfMonths.Name = "colNoOfMonths";
      this.colNoOfMonths16.HeaderText = "NoOfMonths16";
      this.colNoOfMonths16.Name = "colNoOfMonths16";
      this.colInterest16.HeaderText = "Interest16";
      this.colInterest16.Name = "colInterest16";
      this.colRedemptionAmount16.HeaderText = "RedemptionAmount16";
      this.colRedemptionAmount16.Name = "colRedemptionAmount16";
      this.colCreatedOn.HeaderText = "CreatedOn";
      this.colCreatedOn.Name = "colCreatedOn";
      this.colCreatedBy.HeaderText = "CreatedBy";
      this.colCreatedBy.Name = "colCreatedBy";
      this.colBilledBy.HeaderText = "BilledBy";
      this.colBilledBy.Name = "colBilledBy";
      this.panel10.BackColor = Color.PowderBlue;
      this.panel10.BorderStyle = BorderStyle.FixedSingle;
      this.panel10.Controls.Add((Control) this.cbShopCodes);
      this.panel10.Controls.Add((Control) this.label12);
      this.panel10.Location = new Point(8, 12);
      this.panel10.Name = "panel10";
      this.panel10.Size = new Size(201, 70);
      this.panel10.TabIndex = 0;
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
      this.cbShopCodes.TabIndex = 0;
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
      this.panel9.Location = new Point(215, 12);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(204, 70);
      this.panel9.TabIndex = 1;
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
      this.tbxPledgeBillNumber.KeyPress += new KeyPressEventHandler(this.tbxPledgeBillNumber_KeyPress);
      this.tbxPledgeBillNumber.Validating += new CancelEventHandler(this.tbxPledgeBillNumber_Validating);
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkBlue;
      this.label11.Location = new Point(3, 5);
      this.label11.Name = "label11";
      this.label11.Size = new Size(171, 16);
      this.label11.TabIndex = 1;
      this.label11.Text = "PLEDGE BILL NUMBER";
      this.panel1.BackColor = Color.PowderBlue;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.cbSelectAction);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(425, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(201, 70);
      this.panel1.TabIndex = 2;
      this.cbSelectAction.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbSelectAction.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSelectAction.BackColor = Color.AliceBlue;
      this.cbSelectAction.Dock = DockStyle.Bottom;
      this.cbSelectAction.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbSelectAction.DropDownWidth = 600;
      this.cbSelectAction.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbSelectAction.FormattingEnabled = true;
      this.cbSelectAction.Items.AddRange(new object[2]
      {
        (object) "RELEASE",
        (object) "RELEASEANDREBILL"
      });
      this.cbSelectAction.Location = new Point(0, 27);
      this.cbSelectAction.Name = "cbSelectAction";
      this.cbSelectAction.Size = new Size(199, 41);
      this.cbSelectAction.TabIndex = 0;
      this.cbSelectAction.KeyDown += new KeyEventHandler(this.cbSelectAction_KeyDown);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(3, 5);
      this.label1.Name = "label1";
      this.label1.Size = new Size(126, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "SELECT ACTION";
      this.panel2.BackColor = Color.PowderBlue;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbPrintFormD3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Location = new Point(632, 11);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(201, 70);
      this.panel2.TabIndex = 3;
      this.cbPrintFormD3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbPrintFormD3.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbPrintFormD3.BackColor = Color.AliceBlue;
      this.cbPrintFormD3.Dock = DockStyle.Bottom;
      this.cbPrintFormD3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrintFormD3.DropDownWidth = 600;
      this.cbPrintFormD3.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrintFormD3.FormattingEnabled = true;
      this.cbPrintFormD3.Items.AddRange(new object[2]
      {
        (object) "YES",
        (object) "NO"
      });
      this.cbPrintFormD3.Location = new Point(0, 27);
      this.cbPrintFormD3.Name = "cbPrintFormD3";
      this.cbPrintFormD3.Size = new Size(199, 41);
      this.cbPrintFormD3.TabIndex = 0;
      this.cbPrintFormD3.KeyDown += new KeyEventHandler(this.cbPrintFormD3_KeyDown);
      this.cbPrintFormD3.KeyPress += new KeyPressEventHandler(this.tbxDonAcceptAnyInput);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new Size(132, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "PRINT FORM D3?";
      this.panel3.BackColor = Color.PowderBlue;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.tbxAmount);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Location = new Point(12, 88);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(201, 70);
      this.panel3.TabIndex = 4;
      this.tbxAmount.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxAmount.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.CharacterCasing = CharacterCasing.Upper;
      this.tbxAmount.Dock = DockStyle.Bottom;
      this.tbxAmount.Font = new Font("Arial Rounded MT Bold", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.ForeColor = Color.Black;
      this.tbxAmount.Location = new Point(0, 27);
      this.tbxAmount.MaxLength = 6;
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(199, 41);
      this.tbxAmount.TabIndex = 0;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(3, 5);
      this.label3.Name = "label3";
      this.label3.Size = new Size(73, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "AMOUNT";
      this.panel4.BackColor = Color.PowderBlue;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.tbxRoi);
      this.panel4.Controls.Add((Control) this.label4);
      this.panel4.Location = new Point(222, 87);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(201, 70);
      this.panel4.TabIndex = 5;
      this.tbxRoi.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxRoi.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxRoi.BackColor = Color.AliceBlue;
      this.tbxRoi.BorderStyle = BorderStyle.None;
      this.tbxRoi.CharacterCasing = CharacterCasing.Upper;
      this.tbxRoi.Dock = DockStyle.Bottom;
      this.tbxRoi.Font = new Font("Arial Rounded MT Bold", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRoi.ForeColor = Color.Black;
      this.tbxRoi.Location = new Point(0, 27);
      this.tbxRoi.MaxLength = 6;
      this.tbxRoi.Name = "tbxRoi";
      this.tbxRoi.Size = new Size(199, 41);
      this.tbxRoi.TabIndex = 0;
      this.tbxRoi.TextAlign = HorizontalAlignment.Center;
      this.tbxRoi.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(3, 5);
      this.label4.Name = "label4";
      this.label4.Size = new Size(34, 16);
      this.label4.TabIndex = 1;
      this.label4.Text = "ROI";
      this.btnAdd.BackColor = Color.Transparent;
      this.btnAdd.FlatAppearance.BorderColor = Color.Black;
      this.btnAdd.FlatAppearance.BorderSize = 0;
      this.btnAdd.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnAdd.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnAdd.FlatStyle = FlatStyle.Popup;
      this.btnAdd.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAdd.ForeColor = Color.Black;
      this.btnAdd.Image = (Image) componentResourceManager.GetObject("btnAdd.Image");
      this.btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAdd.Location = new Point(659, 94);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(159, 51);
      this.btnAdd.TabIndex = 7;
      this.btnAdd.Text = "       &Add";
      this.btnAdd.TextAlign = ContentAlignment.MiddleRight;
      this.btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
      this.panel5.BackColor = Color.PowderBlue;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.cbPrint);
      this.panel5.Controls.Add((Control) this.label5);
      this.panel5.Location = new Point(426, 88);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(201, 70);
      this.panel5.TabIndex = 6;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(3, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(74, 16);
      this.label5.TabIndex = 1;
      this.label5.Text = "PRINT ??";
      this.cbPrint.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbPrint.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbPrint.BackColor = Color.AliceBlue;
      this.cbPrint.Dock = DockStyle.Bottom;
      this.cbPrint.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrint.DropDownWidth = 600;
      this.cbPrint.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrint.FormattingEnabled = true;
      this.cbPrint.Items.AddRange(new object[2]
      {
        (object) "YES",
        (object) "NO"
      });
      this.cbPrint.Location = new Point(0, 27);
      this.cbPrint.Name = "cbPrint";
      this.cbPrint.Size = new Size(199, 41);
      this.cbPrint.TabIndex = 2;
      this.cbPrint.KeyDown += new KeyEventHandler(this.cbPrint_KeyDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 621);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.panel4);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel10);
      this.Controls.Add((Control) this.panel9);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormMultipleRelease);
      this.Text = nameof (FormMultipleRelease);
      this.Load += new EventHandler(this.FormMultipleRelease_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel10.ResumeLayout(false);
      this.panel10.PerformLayout();
      this.panel9.ResumeLayout(false);
      this.panel9.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
