

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormShopDetailsAddEdit : Form
  {
    private string formType = "";
    private string ShopCode = "";
    private string oldValues = "";
    private IContainer components = (IContainer) null;
    private HeaderPanel headerPanel1;
    private Label label14;
    private GlassButton btnAddEdit;
    private TextBox tbxShopCode;
    private TextBox tbxShopName;
    private Label label12;
    private Label label13;
    private TextBox tbxRateOfInterest;
    private TextBox tbxProprietor;
    private Label label2;
    private Label label11;
    private TextBox tbxAddress1;
    private TextBox tbxShopNameTamil;
    private Label label3;
    private Label label10;
    private TextBox tbxAddress2;
    private TextBox tbxPhoneNumber2;
    private Label label4;
    private Label label9;
    private TextBox tbxLocation;
    private TextBox tbxPhoneNumber1;
    private Label label5;
    private Label label8;
    private TextBox tbxCity;
    private TextBox tbxPblNumber;
    private Label label6;
    private Label label1;
    private TextBox tbxPincode;
    private HeaderPanel headerPanel2;
    private Label label23;
    private TextBox tbxVoucherCodeIntChoot;
    private Label label25;
    private TextBox tbxVoucherNameInterestChoot;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label22;
    private TextBox tbxLedgerType;
    private TextBox tbxLedgerCode;
    private TextBox tbxLedgerTypeInterestGirvi;
    private TextBox tbxVoucherName;
    private TextBox tbxVoucherCodeInterestGirvi;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label18;
    private TextBox tbxVoucherCode;
    private TextBox tbxVoucherNameInterestGirvi;
    private TextBox tbxLedgerCodeInterestGirvi;
    private LinkLabel linkLabel1;

    public FormShopDetailsAddEdit() => this.InitializeComponent();

    public FormShopDetailsAddEdit(string FORMTYPE, string SHOPCODE)
    {
      this.formType = FORMTYPE;
      this.ShopCode = SHOPCODE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        return createParams;
      }
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

    private void tbxAcceptNoInput(object sender, KeyPressEventArgs e) => e.Handled = true;

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

    private bool checkEntries()
    {
      if (this.tbxShopCode.Text.Trim() != "")
      {
        if (this.tbxShopName.Text.Trim() != "")
        {
          if (this.tbxShopNameTamil.Text.Trim() != "")
          {
            if (this.tbxProprietor.Text.Trim() != "")
            {
              if (this.tbxRateOfInterest.Text.Trim() != "")
                return true;
              this.tbxRateOfInterest.Select();
              return false;
            }
            this.tbxProprietor.Select();
            return false;
          }
          this.tbxShopNameTamil.Select();
          return false;
        }
        this.tbxShopName.Select();
        return false;
      }
      this.tbxShopCode.Select();
      return false;
    }

    private void FormShopDetailsAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnAddEdit).Text = "&ADD";
        ((Control) this.headerPanel1).Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        this.tbxShopCode.ReadOnly = true;
        DataTable basedOnThisColumn = ShopDetailsClass.getAllTheRecordsBasedOnThisColumn("ShopCode", this.ShopCode);
        if (basedOnThisColumn != null && basedOnThisColumn.Rows.Count > 0)
        {
          int index = 0;
          this.ShopCode = this.tbxShopCode.Text = basedOnThisColumn.Rows[index]["ShopCode"].ToString();
          this.tbxShopName.Text = basedOnThisColumn.Rows[index]["ShopName"].ToString();
          this.tbxShopNameTamil.Text = basedOnThisColumn.Rows[index]["ShopNameTamil"].ToString();
          this.tbxProprietor.Text = basedOnThisColumn.Rows[index]["Proprietor"].ToString();
          this.tbxAddress1.Text = basedOnThisColumn.Rows[index]["Address1"].ToString();
          this.tbxAddress2.Text = basedOnThisColumn.Rows[index]["Address2"].ToString();
          this.tbxLocation.Text = basedOnThisColumn.Rows[index]["Location"].ToString();
          this.tbxCity.Text = basedOnThisColumn.Rows[index]["City"].ToString();
          this.tbxPincode.Text = basedOnThisColumn.Rows[index]["Pincode"].ToString();
          this.tbxPblNumber.Text = basedOnThisColumn.Rows[index]["PblNumber"].ToString();
          this.tbxPhoneNumber1.Text = basedOnThisColumn.Rows[index]["PhoneNumber1"].ToString();
          this.tbxPhoneNumber2.Text = basedOnThisColumn.Rows[index]["PhoneNumber2"].ToString();
          this.tbxRateOfInterest.Text = basedOnThisColumn.Rows[index]["RateOfInterest"].ToString();
          this.oldValues = "Old values are \n Shop Code = " + this.tbxShopCode.Text.ToString() + "\n Shop Name = " + this.tbxShopName.Text.Trim().ToString() + ", \n Shop Name Tamil = " + this.tbxShopNameTamil.Text.Trim().ToString() + ", \n proprietor = " + this.tbxProprietor.Text.Trim().ToString() + ", \n address1 = " + this.tbxAddress1.Text.Trim().ToString() + ", \n address2  = " + this.tbxAddress2.Text.Trim().ToString() + ", \nlocation = " + this.tbxLocation.Text.Trim().ToString() + ", \n City = " + this.tbxCity.Text.Trim().ToString() + ", \n Pincode = " + this.tbxPincode.Text.Trim().ToString() + ", \n PblNumber = " + this.tbxPblNumber.Text.Trim().ToString() + ", \n PhoneNumber1 = " + this.tbxPhoneNumber1.Text.Trim().ToString() + ", \n PhoneNumber2 = " + this.tbxPhoneNumber2.Text.Trim().ToString() + ",\n RateOfInterest = " + this.tbxRateOfInterest.Text.Trim();
          ((Control) this.btnAddEdit).Text = "&UPDATE";
          ((Control) this.headerPanel1).Text = "EDIT";
        }
      }
      else
        ((Control) this.btnAddEdit).Enabled = false;
      this.tbxLedgerType.Text = LedgerMaster.getLedgerName(this.tbxLedgerCode.Text);
      this.tbxLedgerTypeInterestGirvi.Text = LedgerMaster.getLedgerName(this.tbxLedgerCodeInterestGirvi.Text);
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.checkEntries())
        {
          if (((Control) this.btnAddEdit).Text == "&UPDATE" && ShopDetailsClass.editShopDetails(this.tbxShopCode.Text, this.tbxShopName.Text, this.tbxShopNameTamil.Text, this.tbxProprietor.Text, this.tbxAddress1.Text, this.tbxAddress2.Text, this.tbxLocation.Text, this.tbxCity.Text, this.tbxPincode.Text, this.tbxPblNumber.Text, this.tbxPhoneNumber1.Text, this.tbxPhoneNumber2.Text, this.tbxRateOfInterest.Text) == "Done")
          {
            int num = (int) MessageBox.Show("Successfully Updated");
            this.Close();
          }
          if (!(((Control) this.btnAddEdit).Text == "&ADD"))
            return;
          if (ShopDetailsClass.checkDuplicateShopName(this.tbxShopCode.Text))
          {
            this.addvoucherMaster();
            if (ShopDetailsClass.addShopDetails(this.tbxShopCode.Text, this.tbxShopName.Text, this.tbxShopNameTamil.Text, this.tbxProprietor.Text, this.tbxAddress1.Text, this.tbxAddress2.Text, this.tbxLocation.Text, this.tbxCity.Text, this.tbxPincode.Text, this.tbxPblNumber.Text, this.tbxPhoneNumber1.Text, this.tbxPhoneNumber2.Text, this.tbxRateOfInterest.Text, FormMain.username, DateTime.Now, this.tbxLedgerCode.Text, this.tbxVoucherCode.Text, this.tbxLedgerCodeInterestGirvi.Text, this.tbxVoucherCodeInterestGirvi.Text, this.tbxVoucherCodeIntChoot.Text) == "Done")
              PledgeBillNumberSeriesClass.addShopCodeInBillNumberSEriesTable(this.tbxShopCode.Text);
            PawnManagementClass.InsertIntoHistory("LICENSE MASTER", "License master entry " + this.tbxShopName.Text.Trim().ToString() + " created", "", "Shop Code =" + this.tbxShopCode.Text.Trim().ToString() + "Shop Name =" + this.tbxShopName.Text.Trim().ToString() + " , \n ShopNameTamil =" + this.tbxShopNameTamil.Text.Trim().ToString() + " ,\n Proprietor =" + this.tbxProprietor.Text.Trim().ToString() + ",\n Address1 =" + this.tbxAddress1.Text.Trim().ToString() + ",\n Address2 =" + this.tbxAddress2.Text.Trim().ToString() + ",\n Location =" + this.tbxLocation.Text.Trim().ToString() + ",\n City =" + this.tbxCity.Text.Trim().ToString() + ",\n Pincode =" + this.tbxPincode.Text.Trim().ToString() + ",\n PblNumber =" + this.tbxPblNumber.Text.Trim().ToString() + ",\n PhoneNumber1 =" + this.tbxPhoneNumber1.Text.Trim().ToString() + ",\n PhoneNumber2 =" + this.tbxPhoneNumber2.Text.Trim().ToString() + ",\n Rate Of Interest =" + this.tbxRateOfInterest.Text.Trim().ToString(), FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("Successfully added");
            this.Close();
          }
          else
          {
            int num1 = (int) MessageBox.Show("Shop Code already taken");
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Fill all the details");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addvoucherMaster()
    {
      try
      {
        VoucherMasterClass.addvoucherMaster(this.tbxVoucherCode.Text.Trim(), this.tbxVoucherName.Text.Trim(), this.tbxLedgerCode.Text.Trim(), this.tbxLedgerType.Text.Trim(), DateTime.Now, FormMain.username);
        VoucherMasterClass.addvoucherMaster(this.tbxVoucherCodeIntChoot.Text.Trim(), this.tbxVoucherNameInterestChoot.Text.Trim(), this.tbxLedgerCodeInterestGirvi.Text.Trim(), this.tbxLedgerTypeInterestGirvi.Text.Trim(), DateTime.Now, FormMain.username);
        VoucherMasterClass.addvoucherMaster(this.tbxVoucherCodeInterestGirvi.Text.Trim(), this.tbxVoucherNameInterestGirvi.Text.Trim(), this.tbxLedgerCodeInterestGirvi.Text.Trim(), this.tbxLedgerTypeInterestGirvi.Text.Trim(), DateTime.Now, FormMain.username);
      }
      catch (Exception ex)
      {
      }
    }

    private void tbxShopCode_TextChanged(object sender, EventArgs e)
    {
      this.tbxVoucherName.Text = this.tbxShopCode.Text;
      this.tbxVoucherNameInterestGirvi.Text = this.tbxShopCode.Text + "-GIRVI";
      this.tbxVoucherNameInterestChoot.Text = this.tbxShopCode.Text + "-CHOOT";
      if (ShopDetailsClass.checkDuplicateShopName(this.tbxShopCode.Text))
        this.tbxShopCode.ForeColor = Color.White;
      else
        this.tbxShopCode.ForeColor = Color.Red;
    }

    private void reset()
    {
      this.tbxShopCode.Text = "";
      this.tbxShopName.Text = "";
      this.tbxShopNameTamil.Text = "";
      this.tbxAddress1.Text = "";
      this.tbxAddress2.Text = "";
      this.tbxLocation.Text = "";
      this.tbxCity.Text = "";
      this.tbxPblNumber.Text = "";
      this.tbxPhoneNumber1.Text = "";
      this.tbxPhoneNumber2.Text = "";
      this.tbxPincode.Text = "";
      this.tbxProprietor.Text = "";
      this.tbxRateOfInterest.Text = "";
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void tbxShopCode_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (!(((Control) this.btnAddEdit).Text == "&ADD"))
          return;
        if (ShopDetailsClass.checkDuplicateShopName(this.tbxShopCode.Text))
        {
          if (this.tbxShopCode.Text.Trim() != "")
          {
            char ch = this.tbxShopCode.Text.Trim()[0];
            string strError = "";
            DataTable dataTable = SQLHelper.GetDataTable("select * from tblVoucherMaster where VoucherCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
            if (strError != "")
              PawnManagementClass.InsertIntoException("form licensemaster.tbxshopcode_Leave", strError, FormMain.username, DateTime.Now.ToString());
            if (dataTable != null)
            {
              if (dataTable.Rows.Count > 0)
              {
                string str1 = ch.ToString();
                this.tbxVoucherCode.Text = str1 + this.NextCustomerCode(dataTable);
                TextBox voucherCodeIntChoot = this.tbxVoucherCodeIntChoot;
                string str2 = str1;
                int num = int.Parse(this.NextCustomerCode(dataTable)) + 1;
                string str3 = num.ToString();
                string str4 = str2 + str3;
                voucherCodeIntChoot.Text = str4;
                TextBox codeInterestGirvi = this.tbxVoucherCodeInterestGirvi;
                string str5 = str1;
                num = int.Parse(this.NextCustomerCode(dataTable)) + 2;
                string str6 = num.ToString();
                string str7 = str5 + str6;
                codeInterestGirvi.Text = str7;
              }
              else
              {
                this.tbxVoucherCode.Text = ch.ToString() + "1";
                this.tbxVoucherCodeIntChoot.Text = ch.ToString() + "2";
                this.tbxVoucherCodeInterestGirvi.Text = ch.ToString() + "3";
              }
            }
            else
            {
              int num1 = (int) MessageBox.Show("Error while setting voucherCode Restart - " + strError);
            }
          }
        }
        else
          this.tbxShopCode.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form VoucherMaster.tbxBankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.headerPanel1 = new HeaderPanel();
      this.linkLabel1 = new LinkLabel();
      this.label14 = new Label();
      this.btnAddEdit = new GlassButton();
      this.tbxShopCode = new TextBox();
      this.tbxShopName = new TextBox();
      this.label12 = new Label();
      this.label13 = new Label();
      this.tbxRateOfInterest = new TextBox();
      this.tbxProprietor = new TextBox();
      this.label2 = new Label();
      this.label11 = new Label();
      this.tbxAddress1 = new TextBox();
      this.tbxShopNameTamil = new TextBox();
      this.label3 = new Label();
      this.label10 = new Label();
      this.tbxAddress2 = new TextBox();
      this.tbxPhoneNumber2 = new TextBox();
      this.label4 = new Label();
      this.label9 = new Label();
      this.tbxLocation = new TextBox();
      this.tbxPhoneNumber1 = new TextBox();
      this.label5 = new Label();
      this.label8 = new Label();
      this.tbxCity = new TextBox();
      this.tbxPblNumber = new TextBox();
      this.label6 = new Label();
      this.label1 = new Label();
      this.tbxPincode = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.label23 = new Label();
      this.tbxVoucherCodeIntChoot = new TextBox();
      this.label25 = new Label();
      this.tbxVoucherNameInterestChoot = new TextBox();
      this.label19 = new Label();
      this.label20 = new Label();
      this.label21 = new Label();
      this.label22 = new Label();
      this.tbxLedgerType = new TextBox();
      this.tbxLedgerCode = new TextBox();
      this.tbxLedgerTypeInterestGirvi = new TextBox();
      this.tbxVoucherName = new TextBox();
      this.tbxVoucherCodeInterestGirvi = new TextBox();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.tbxVoucherCode = new TextBox();
      this.tbxVoucherNameInterestGirvi = new TextBox();
      this.tbxLedgerCodeInterestGirvi = new TextBox();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.headerPanel1.BorderColor = SystemColors.ActiveCaption;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "ENTER LICENSE DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.linkLabel1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label14);
      ((Control) this.headerPanel1).Controls.Add((Control) this.btnAddEdit);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxShopName);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label12);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label13);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxRateOfInterest);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxProprietor);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label11);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAddress1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxShopNameTamil);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label10);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAddress2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPhoneNumber2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label9);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxLocation);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPhoneNumber1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label5);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label8);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCity);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPblNumber);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label6);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPincode);
      ((Control) this.headerPanel1).Dock = DockStyle.Fill;
      ((Control) this.headerPanel1).Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkSlateBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.BackwardDiagonal;
      this.headerPanel1.GradientEnd = Color.AliceBlue;
      this.headerPanel1.GradientStart = Color.Azure;
      ((Control) this.headerPanel1).Location = new Point(0, 0);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(527, 494);
      ((Control) this.headerPanel1).TabIndex = 1;
      this.headerPanel1.TextAntialias = true;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Transparent;
      this.linkLabel1.Location = new Point(451, 14);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(61, 15);
      this.linkLabel1.TabIndex = 54;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Close(Esc)";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.MidnightBlue;
      this.label14.Location = new Point(48, 48);
      this.label14.Margin = new Padding(6, 0, 6, 0);
      this.label14.Name = "label14";
      this.label14.Size = new Size(76, 16);
      this.label14.TabIndex = 53;
      this.label14.Text = "Shop Code";
      ((Control) this.btnAddEdit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Cambria", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(131, 387);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(376, 46);
      ((Control) this.btnAddEdit).TabIndex = 13;
      ((Control) this.btnAddEdit).Text = "&ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.tbxShopCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxShopCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxShopCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(126, 45);
      this.tbxShopCode.Margin = new Padding(6);
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(391, 22);
      this.tbxShopCode.TabIndex = 0;
      this.tbxShopCode.TextChanged += new EventHandler(this.tbxShopCode_TextChanged);
      this.tbxShopCode.Validating += new CancelEventHandler(this.tbxShopCode_Validating);
      this.tbxShopName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxShopName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxShopName.CharacterCasing = CharacterCasing.Upper;
      this.tbxShopName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxShopName.Location = new Point(126, 72);
      this.tbxShopName.Margin = new Padding(6);
      this.tbxShopName.Name = "tbxShopName";
      this.tbxShopName.Size = new Size(391, 22);
      this.tbxShopName.TabIndex = 1;
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.MidnightBlue;
      this.label12.Location = new Point(27, 204);
      this.label12.Margin = new Padding(6, 0, 6, 0);
      this.label12.Name = "label12";
      this.label12.Size = new Size(97, 16);
      this.label12.TabIndex = 51;
      this.label12.Text = "Rate of Interest";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.MidnightBlue;
      this.label13.Location = new Point(44, 75);
      this.label13.Margin = new Padding(6, 0, 6, 0);
      this.label13.Name = "label13";
      this.label13.Size = new Size(80, 16);
      this.label13.TabIndex = 29;
      this.label13.Text = "Shop Name";
      this.tbxRateOfInterest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxRateOfInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRateOfInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxRateOfInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRateOfInterest.Location = new Point(126, 202);
      this.tbxRateOfInterest.Margin = new Padding(6);
      this.tbxRateOfInterest.MaxLength = 12;
      this.tbxRateOfInterest.Name = "tbxRateOfInterest";
      this.tbxRateOfInterest.Size = new Size(391, 22);
      this.tbxRateOfInterest.TabIndex = 6;
      this.tbxRateOfInterest.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxProprietor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxProprietor.BorderStyle = BorderStyle.FixedSingle;
      this.tbxProprietor.CharacterCasing = CharacterCasing.Upper;
      this.tbxProprietor.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxProprietor.Location = new Point(126, 98);
      this.tbxProprietor.Margin = new Padding(6);
      this.tbxProprietor.Name = "tbxProprietor";
      this.tbxProprietor.Size = new Size(391, 22);
      this.tbxProprietor.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.MidnightBlue;
      this.label2.Location = new Point(57, 101);
      this.label2.Margin = new Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(67, 16);
      this.label2.TabIndex = 31;
      this.label2.Text = "Proprietor";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.MidnightBlue;
      this.label11.Location = new Point(9, 231);
      this.label11.Margin = new Padding(6, 0, 6, 0);
      this.label11.Name = "label11";
      this.label11.Size = new Size(114, 16);
      this.label11.TabIndex = 48;
      this.label11.Text = "ShopName Tamil";
      this.tbxAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddress1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.Location = new Point(126, 254);
      this.tbxAddress1.Margin = new Padding(6);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(391, 22);
      this.tbxAddress1.TabIndex = 8;
      this.tbxShopNameTamil.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxShopNameTamil.BorderStyle = BorderStyle.FixedSingle;
      this.tbxShopNameTamil.CharacterCasing = CharacterCasing.Upper;
      this.tbxShopNameTamil.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxShopNameTamil.Location = new Point(126, 228);
      this.tbxShopNameTamil.Margin = new Padding(6);
      this.tbxShopNameTamil.Name = "tbxShopNameTamil";
      this.tbxShopNameTamil.Size = new Size(391, 22);
      this.tbxShopNameTamil.TabIndex = 7;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.MidnightBlue;
      this.label3.Location = new Point(57, 258);
      this.label3.Margin = new Padding(6, 0, 6, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(66, 16);
      this.label3.TabIndex = 34;
      this.label3.Text = "Address1";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.MidnightBlue;
      this.label10.Location = new Point(22, 179);
      this.label10.Margin = new Padding(6, 0, 6, 0);
      this.label10.Name = "label10";
      this.label10.Size = new Size(102, 16);
      this.label10.TabIndex = 47;
      this.label10.Text = "PhoneNumber2";
      this.tbxAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddress2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.Location = new Point(126, 280);
      this.tbxAddress2.Margin = new Padding(6);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(391, 22);
      this.tbxAddress2.TabIndex = 9;
      this.tbxPhoneNumber2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxPhoneNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber2.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber2.Location = new Point(126, 176);
      this.tbxPhoneNumber2.Margin = new Padding(6);
      this.tbxPhoneNumber2.MaxLength = 12;
      this.tbxPhoneNumber2.Name = "tbxPhoneNumber2";
      this.tbxPhoneNumber2.Size = new Size(391, 22);
      this.tbxPhoneNumber2.TabIndex = 5;
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.MidnightBlue;
      this.label4.Location = new Point(57, 283);
      this.label4.Margin = new Padding(6, 0, 6, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(66, 16);
      this.label4.TabIndex = 37;
      this.label4.Text = "Address2";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.MidnightBlue;
      this.label9.Location = new Point(23, 153);
      this.label9.Margin = new Padding(6, 0, 6, 0);
      this.label9.Name = "label9";
      this.label9.Size = new Size(102, 16);
      this.label9.TabIndex = 46;
      this.label9.Text = "PhoneNumber1";
      this.tbxLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxLocation.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLocation.CharacterCasing = CharacterCasing.Upper;
      this.tbxLocation.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLocation.Location = new Point(126, 306);
      this.tbxLocation.Margin = new Padding(6);
      this.tbxLocation.Name = "tbxLocation";
      this.tbxLocation.Size = new Size(391, 22);
      this.tbxLocation.TabIndex = 10;
      this.tbxPhoneNumber1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxPhoneNumber1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber1.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber1.Location = new Point(126, 150);
      this.tbxPhoneNumber1.Margin = new Padding(6);
      this.tbxPhoneNumber1.MaxLength = 12;
      this.tbxPhoneNumber1.Name = "tbxPhoneNumber1";
      this.tbxPhoneNumber1.Size = new Size(391, 22);
      this.tbxPhoneNumber1.TabIndex = 4;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.MidnightBlue;
      this.label5.Location = new Point(64, 309);
      this.label5.Margin = new Padding(6, 0, 6, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(59, 16);
      this.label5.TabIndex = 40;
      this.label5.Text = "Location";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.MidnightBlue;
      this.label8.Location = new Point(48, (int) sbyte.MaxValue);
      this.label8.Margin = new Padding(6, 0, 6, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(76, 16);
      this.label8.TabIndex = 45;
      this.label8.Text = "PblNumber";
      this.tbxCity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(126, 332);
      this.tbxCity.Margin = new Padding(6);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(391, 22);
      this.tbxCity.TabIndex = 11;
      this.tbxPblNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxPblNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPblNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxPblNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPblNumber.Location = new Point(126, 124);
      this.tbxPblNumber.Margin = new Padding(6);
      this.tbxPblNumber.MaxLength = 10;
      this.tbxPblNumber.Name = "tbxPblNumber";
      this.tbxPblNumber.Size = new Size(391, 22);
      this.tbxPblNumber.TabIndex = 3;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.MidnightBlue;
      this.label6.Location = new Point(93, 335);
      this.label6.Margin = new Padding(6, 0, 6, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(30, 16);
      this.label6.TabIndex = 43;
      this.label6.Text = "City";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.MidnightBlue;
      this.label1.Location = new Point(65, 361);
      this.label1.Margin = new Padding(6, 0, 6, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(58, 16);
      this.label1.TabIndex = 44;
      this.label1.Text = "Pincode";
      this.tbxPincode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxPincode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(126, 358);
      this.tbxPincode.Margin = new Padding(6);
      this.tbxPincode.MaxLength = 6;
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(391, 22);
      this.tbxPincode.TabIndex = 12;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.ActiveCaption;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "VOUCHER AND LEDGER CODE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.label23);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherCodeIntChoot);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label25);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherNameInterestChoot);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label19);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label20);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label21);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label22);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxLedgerType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxLedgerCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxLedgerTypeInterestGirvi);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherName);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherCodeInterestGirvi);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label15);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label16);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label17);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label18);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxVoucherNameInterestGirvi);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxLedgerCodeInterestGirvi);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(-103, 344);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(21, 43);
      ((Control) this.headerPanel2).TabIndex = 2;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.headerPanel2).Visible = false;
      this.label23.AutoSize = true;
      this.label23.BackColor = Color.Transparent;
      this.label23.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label23.Location = new Point(11, 305);
      this.label23.Name = "label23";
      this.label23.Size = new Size(236, 16);
      this.label23.TabIndex = 40;
      this.label23.Text = "VOUCHER TYPE INTEREST CHOOT";
      this.tbxVoucherCodeIntChoot.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCodeIntChoot.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherCodeIntChoot.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCodeIntChoot.Location = new Point(253, 272);
      this.tbxVoucherCodeIntChoot.MaxLength = 11;
      this.tbxVoucherCodeIntChoot.Name = "tbxVoucherCodeIntChoot";
      this.tbxVoucherCodeIntChoot.Size = new Size(232, 22);
      this.tbxVoucherCodeIntChoot.TabIndex = 10;
      this.label25.AutoSize = true;
      this.label25.BackColor = Color.Transparent;
      this.label25.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label25.Location = new Point(57, 275);
      this.label25.Name = "label25";
      this.label25.Size = new Size(192, 16);
      this.label25.TabIndex = 36;
      this.label25.Text = "VOUCHER CODE INT CHOOT";
      this.tbxVoucherNameInterestChoot.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNameInterestChoot.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherNameInterestChoot.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNameInterestChoot.Location = new Point(254, 302);
      this.tbxVoucherNameInterestChoot.MaxLength = 11;
      this.tbxVoucherNameInterestChoot.Name = "tbxVoucherNameInterestChoot";
      this.tbxVoucherNameInterestChoot.Size = new Size(232, 22);
      this.tbxVoucherNameInterestChoot.TabIndex = 11;
      this.label19.AutoSize = true;
      this.label19.BackColor = Color.Transparent;
      this.label19.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(146, 65);
      this.label19.Name = "label19";
      this.label19.Size = new Size(102, 16);
      this.label19.TabIndex = 29;
      this.label19.Text = "LEDGER TYPE";
      this.label20.AutoSize = true;
      this.label20.BackColor = Color.Transparent;
      this.label20.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(61, 245);
      this.label20.Name = "label20";
      this.label20.Size = new Size(185, 16);
      this.label20.TabIndex = 32;
      this.label20.Text = "VOUCHER TYPE INTEREST";
      this.label21.AutoSize = true;
      this.label21.BackColor = Color.Transparent;
      this.label21.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.Location = new Point(134, 125);
      this.label21.Name = "label21";
      this.label21.Size = new Size(114, 16);
      this.label21.TabIndex = 30;
      this.label21.Text = "VOUCHER TYPE";
      this.label22.AutoSize = true;
      this.label22.BackColor = Color.Transparent;
      this.label22.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.Location = new Point(73, 185);
      this.label22.Name = "label22";
      this.label22.Size = new Size(173, 16);
      this.label22.TabIndex = 31;
      this.label22.Text = "LEDGER TYPE INTEREST";
      this.tbxLedgerType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerType.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerType.Location = new Point(254, 62);
      this.tbxLedgerType.MaxLength = 11;
      this.tbxLedgerType.Name = "tbxLedgerType";
      this.tbxLedgerType.Size = new Size(232, 22);
      this.tbxLedgerType.TabIndex = 3;
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(254, 32);
      this.tbxLedgerCode.MaxLength = 11;
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.Size = new Size(232, 22);
      this.tbxLedgerCode.TabIndex = 2;
      this.tbxLedgerCode.Text = "G1";
      this.tbxLedgerTypeInterestGirvi.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInterestGirvi.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerTypeInterestGirvi.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInterestGirvi.Location = new Point(254, 182);
      this.tbxLedgerTypeInterestGirvi.MaxLength = 11;
      this.tbxLedgerTypeInterestGirvi.Name = "tbxLedgerTypeInterestGirvi";
      this.tbxLedgerTypeInterestGirvi.Size = new Size(232, 22);
      this.tbxLedgerTypeInterestGirvi.TabIndex = 7;
      this.tbxVoucherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherName.Location = new Point(254, 122);
      this.tbxVoucherName.MaxLength = 11;
      this.tbxVoucherName.Name = "tbxVoucherName";
      this.tbxVoucherName.Size = new Size(232, 22);
      this.tbxVoucherName.TabIndex = 5;
      this.tbxVoucherCodeInterestGirvi.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCodeInterestGirvi.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherCodeInterestGirvi.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCodeInterestGirvi.Location = new Point(254, 212);
      this.tbxVoucherCodeInterestGirvi.MaxLength = 11;
      this.tbxVoucherCodeInterestGirvi.Name = "tbxVoucherCodeInterestGirvi";
      this.tbxVoucherCodeInterestGirvi.Size = new Size(232, 22);
      this.tbxVoucherCodeInterestGirvi.TabIndex = 8;
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(144, 35);
      this.label15.Name = "label15";
      this.label15.Size = new Size(104, 16);
      this.label15.TabIndex = 18;
      this.label15.Text = "LEDGER CODE";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Transparent;
      this.label16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(107, 215);
      this.label16.Name = "label16";
      this.label16.Size = new Size(141, 16);
      this.label16.TabIndex = 26;
      this.label16.Text = "VOUCHER CODE INT";
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Transparent;
      this.label17.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(132, 95);
      this.label17.Name = "label17";
      this.label17.Size = new Size(116, 16);
      this.label17.TabIndex = 19;
      this.label17.Text = "VOUCHER CODE";
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(116, 155);
      this.label18.Name = "label18";
      this.label18.Size = new Size(132, 16);
      this.label18.TabIndex = 25;
      this.label18.Text = "LEDGER  CODE INT";
      this.tbxVoucherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(254, 92);
      this.tbxVoucherCode.MaxLength = 11;
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.Size = new Size(232, 22);
      this.tbxVoucherCode.TabIndex = 4;
      this.tbxVoucherNameInterestGirvi.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNameInterestGirvi.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherNameInterestGirvi.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNameInterestGirvi.Location = new Point(253, 242);
      this.tbxVoucherNameInterestGirvi.MaxLength = 11;
      this.tbxVoucherNameInterestGirvi.Name = "tbxVoucherNameInterestGirvi";
      this.tbxVoucherNameInterestGirvi.Size = new Size(232, 22);
      this.tbxVoucherNameInterestGirvi.TabIndex = 9;
      this.tbxLedgerCodeInterestGirvi.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCodeInterestGirvi.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCodeInterestGirvi.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCodeInterestGirvi.Location = new Point(254, 152);
      this.tbxLedgerCodeInterestGirvi.MaxLength = 11;
      this.tbxLedgerCodeInterestGirvi.Name = "tbxLedgerCodeInterestGirvi";
      this.tbxLedgerCodeInterestGirvi.Size = new Size(232, 22);
      this.tbxLedgerCodeInterestGirvi.TabIndex = 6;
      this.tbxLedgerCodeInterestGirvi.Text = "B1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(527, 494);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormShopDetailsAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormShopDetailsAddEdit);
      this.Load += new EventHandler(this.FormShopDetailsAddEdit_Load);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
