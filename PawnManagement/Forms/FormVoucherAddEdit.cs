

using CSharpCustomPanelControl;
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormVoucherAddEdit : Form
  {
    private string voucherCode = "";
    private string voucherName = "";
    private string ledgerCode = "";
    private string LedgerType = "";
    private string formType = "ADD";
    private List<string> lstName = new List<string>();
    private IContainer components = (IContainer) null;
    private TextBox tbxLedgerCode;
    private TextBox tbxVoucherCode;
    private ComboBox cbLedgerType;
    private Label lblLedgerType;
    private TextBox tbxVoucherName;
    private Label lblVoucherName;
    private CustomPanel customPanel1;
    private Label label2;
    private Label label1;
    private GlassButton btnAddEdit;

    public FormVoucherAddEdit() => this.InitializeComponent();

    public FormVoucherAddEdit(
      string VOUCHERCODE,
      string VOUCHERNAME,
      string LEDGERCODE,
      string LEDGERTYPE,
      string FORMTYPE)
    {
      this.voucherCode = VOUCHERCODE;
      this.voucherName = VOUCHERNAME;
      this.ledgerCode = LEDGERCODE;
      this.LedgerType = LEDGERTYPE;
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormVoucherAddEdit_Load(object sender, EventArgs e)
    {
      this.getAddress();
      this.tbxVoucherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxVoucherName.AutoCompleteCustomSource.AddRange(this.lstName.ToArray());
      this.Assign((Control) this);
      this.tbxVoucherName.Select();
      this.populateLedgerType();
      if (!(this.formType == "EDIT"))
        return;
      ((Control) this.btnAddEdit).Text = "UPDATE";
      this.tbxVoucherName.Text = this.voucherName;
      this.tbxVoucherCode.Text = this.voucherCode;
      this.cbLedgerType.Text = this.LedgerType;
      this.tbxLedgerCode.Text = this.ledgerCode;
      this.cbLedgerType.Enabled = false;
      this.tbxLedgerCode.ReadOnly = true;
    }

    private void populateLedgerType()
    {
      this.cbLedgerType.DataSource = (object) LedgerMaster.getDistinctLedgerType();
      this.cbLedgerType.DisplayMember = "ledgertype";
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        if (control1 is TextBox)
        {
          TextBox textBox = (TextBox) control1;
          textBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
          textBox.Enter += new EventHandler(this.textBox_Enter);
          textBox.Leave += new EventHandler(this.textBox_Leave);
        }
        else
          this.Assign(control1);
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
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.DarkBlue;
    }

    private void getAddress()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct Cname,Cid from tblCustomers";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving address" + strError);
          PawnManagementClass.InsertIntoException("Form AddCustomer.getAddress() innerException", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstName.Add(row["cname"].ToString() + "(" + row["cid"].ToString() + ")");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster.getaddress", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (((Control) this.btnAddEdit).Text == "UPDATE" && DialogResult.Yes == MessageBox.Show("Are you Sure?", "EDIT", MessageBoxButtons.YesNo))
        {
          if (this.tbxVoucherName.Text.Trim() != "" && this.cbLedgerType.Text.Trim() != "" && this.tbxVoucherCode.Text.Trim().ToString() != "" && this.tbxLedgerCode.Text.Trim() != "")
          {
            if ((int) this.tbxVoucherCode.Text[0] == (int) this.tbxVoucherName.Text[0])
            {
              if (!VoucherMasterClass.checkIfVoucherNameAlreadyExists(this.tbxVoucherName.Text))
              {
                VoucherMasterClass.editVoucherMaster(this.tbxVoucherName.Text, this.cbLedgerType.Text, this.tbxLedgerCode.Text, this.tbxVoucherCode.Text);
              }
              else
              {
                int num1 = (int) MessageBox.Show("Voucher Name already exists...Try another");
              }
            }
            else
            {
              int num2 = (int) MessageBox.Show(" Voucher name should begin with " + this.tbxVoucherCode.Text[0].ToString());
            }
          }
          else
          {
            int num3 = (int) MessageBox.Show("Fields cannot be empty");
          }
        }
        if (((Control) this.btnAddEdit).Text == "ADD")
        {
          if (this.tbxVoucherName.Text.Trim() != "" && this.cbLedgerType.Text.Trim() != "" && this.tbxVoucherCode.Text.Trim().ToString() != "" && this.tbxLedgerCode.Text.Trim() != "")
          {
            if ((int) this.tbxVoucherCode.Text[0] == (int) this.tbxVoucherName.Text[0])
            {
              if (DialogResult.Yes == MessageBox.Show("Are you Sure?", "ADD", MessageBoxButtons.YesNo))
              {
                if (!VoucherMasterClass.checkIfVoucherNameAlreadyExists(this.tbxVoucherName.Text))
                {
                  VoucherMasterClass.addvoucherMaster(this.tbxVoucherCode.Text, this.tbxVoucherName.Text, this.tbxLedgerCode.Text, this.cbLedgerType.Text, DateTime.Now, FormMain.username);
                }
                else
                {
                  int num4 = (int) MessageBox.Show("Voucher Name already exists...Try another");
                }
              }
            }
            else
            {
              int num5 = (int) MessageBox.Show("Voucher Name should start with " + this.tbxVoucherCode.Text[0].ToString());
            }
          }
          else
          {
            int num6 = (int) MessageBox.Show("Fields cannot be empty");
          }
        }
        this.tbxVoucherName.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  vouchermaster.btnAddEdit_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxVoucherName_Validating(object sender, CancelEventArgs e)
    {
      if (!(((Control) this.btnAddEdit).Text == "ADD"))
        return;
      try
      {
        if (this.tbxVoucherName.Text.Trim() != "")
        {
          string nextVoucherCode = VoucherMasterClass.getNextVoucherCode(this.tbxVoucherName.Text);
          if (nextVoucherCode != "")
            this.tbxVoucherCode.Text = nextVoucherCode;
        }
        else
          this.tbxVoucherName.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form VoucherMaster.tbxVouchername_validating 2", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbLedgerType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddEdit).Select();
    }

    private void cbLedgerType_SelectedIndexChanged(object sender, EventArgs e) => this.tbxLedgerCode.Text = LedgerMaster.getledgerCode(this.cbLedgerType.Text);

    private void cbLedgerType_Validating(object sender, CancelEventArgs e) => this.tbxLedgerCode.Text = LedgerMaster.getledgerCode(this.cbLedgerType.Text);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxLedgerCode = new TextBox();
      this.tbxVoucherCode = new TextBox();
      this.cbLedgerType = new ComboBox();
      this.lblLedgerType = new Label();
      this.tbxVoucherName = new TextBox();
      this.lblVoucherName = new Label();
      this.customPanel1 = new CustomPanel();
      this.label2 = new Label();
      this.label1 = new Label();
      this.btnAddEdit = new GlassButton();
      ((Control) this.customPanel1).SuspendLayout();
      this.SuspendLayout();
      this.tbxLedgerCode.BackColor = Color.AliceBlue;
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCode.Enabled = false;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(219, 144);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.Size = new Size(350, 31);
      this.tbxLedgerCode.TabIndex = 0;
      this.tbxVoucherCode.BackColor = Color.AliceBlue;
      this.tbxVoucherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(219, 60);
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.Size = new Size(350, 31);
      this.tbxVoucherCode.TabIndex = 8;
      this.cbLedgerType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLedgerType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLedgerType.BackColor = Color.AliceBlue;
      this.cbLedgerType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbLedgerType.FlatStyle = FlatStyle.Popup;
      this.cbLedgerType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbLedgerType.FormattingEnabled = true;
      this.cbLedgerType.Location = new Point(219, 101);
      this.cbLedgerType.Name = "cbLedgerType";
      this.cbLedgerType.Size = new Size(350, 33);
      this.cbLedgerType.TabIndex = 6;
      this.cbLedgerType.SelectedIndexChanged += new EventHandler(this.cbLedgerType_SelectedIndexChanged);
      this.cbLedgerType.KeyDown += new KeyEventHandler(this.cbLedgerType_KeyDown);
      this.cbLedgerType.Validating += new CancelEventHandler(this.cbLedgerType_Validating);
      this.lblLedgerType.AutoSize = true;
      this.lblLedgerType.BackColor = Color.Transparent;
      this.lblLedgerType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblLedgerType.Location = new Point(54, 104);
      this.lblLedgerType.Name = "lblLedgerType";
      this.lblLedgerType.Size = new Size(160, 25);
      this.lblLedgerType.TabIndex = 2;
      this.lblLedgerType.Text = "LEDGER TYPE";
      this.tbxVoucherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxVoucherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxVoucherName.BackColor = Color.AliceBlue;
      this.tbxVoucherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherName.Location = new Point(219, 19);
      this.tbxVoucherName.Name = "tbxVoucherName";
      this.tbxVoucherName.Size = new Size(350, 31);
      this.tbxVoucherName.TabIndex = 5;
      this.tbxVoucherName.Validating += new CancelEventHandler(this.tbxVoucherName_Validating);
      this.lblVoucherName.AutoSize = true;
      this.lblVoucherName.BackColor = Color.Transparent;
      this.lblVoucherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVoucherName.Location = new Point(33, 22);
      this.lblVoucherName.Name = "lblVoucherName";
      this.lblVoucherName.Size = new Size(183, 25);
      this.lblVoucherName.TabIndex = 4;
      this.lblVoucherName.Text = "VOUCHER NAME";
      this.customPanel1.BackColor = Color.LightBlue;
      this.customPanel1.BackColor2 = Color.Azure;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.label2);
      ((Control) this.customPanel1).Controls.Add((Control) this.label1);
      ((Control) this.customPanel1).Controls.Add((Control) this.btnAddEdit);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxVoucherName);
      ((Control) this.customPanel1).Controls.Add((Control) this.lblVoucherName);
      ((Control) this.customPanel1).Controls.Add((Control) this.lblLedgerType);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxLedgerCode);
      ((Control) this.customPanel1).Controls.Add((Control) this.cbLedgerType);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxVoucherCode);
      ((Control) this.customPanel1).Dock = DockStyle.Fill;
      this.customPanel1.GradientMode = LinearGradientMode.Vertical;
      ((Control) this.customPanel1).Location = new Point(0, 0);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(612, 269);
      ((Control) this.customPanel1).TabIndex = 0;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(50, 147);
      this.label2.Name = "label2";
      this.label2.Size = new Size(164, 25);
      this.label2.TabIndex = 1;
      this.label2.Text = "LEDGER CODE";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(34, 63);
      this.label1.Name = "label1";
      this.label1.Size = new Size(182, 25);
      this.label1.TabIndex = 3;
      this.label1.Text = "VOUCHER CODE";
      this.btnAddEdit.BackColor = Color.AliceBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = SystemColors.ControlText;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = SystemColors.ControlText;
      this.btnAddEdit.GlowColor = Color.AliceBlue;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(310, 198);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.AliceBlue;
      ((Control) this.btnAddEdit).Size = new Size(165, 43);
      ((Control) this.btnAddEdit).TabIndex = 7;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(612, 269);
      this.Controls.Add((Control) this.customPanel1);
      this.Name = nameof (FormVoucherAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormVoucherAddEdit);
      this.Load += new EventHandler(this.FormVoucherAddEdit_Load);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
