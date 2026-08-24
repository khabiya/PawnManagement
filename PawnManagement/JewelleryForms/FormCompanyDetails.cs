
using Jewellery;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.JewelleryClasses;
using PawnManagement.Properties;
using Square;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.JewelleryForms
{
  public class FormCompanyDetails : Form
  {
    private IContainer components = (IContainer) null;
    private HeaderPanel hp2;
    private HeaderPanel hp1;
    private SquareButton btnDelete;
    private SquareButton btnEdit;
    private SquareButton btnAdd;
    private Label label18;
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
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private TextBox tbxNoOfDecimals;
    private TextBox tbxGst;
    private TextBox tbxWebsite;
    private TextBox tbxEmailId;
    private TextBox tbxFaxNumber;
    private TextBox tbxAlternateNumber;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCountry;
    private TextBox tbxState;
    private TextBox tbxPincode;
    private TextBox tbxCity;
    private TextBox tbxLocation;
    private TextBox tbxAddress2;
    private TextBox tbxAddress1;
    private TextBox tbxDoorNumber;
    private TextBox tbxMailingName;
    private TextBox tbxCompanyName;
    private Label label1;
    private TextBox tbxCompanyCode;
    private SquareButton btnAddEdit;
    private ListBox lvCompanyMaster;
    private SquareButton btnExit;
    private Panel panel2;
    private Label label19;
    private SquareButton squareButton1;

    public FormCompanyDetails() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormCompanyDetails_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      this.getCompanyDetails();
      ((Control) this.hp2).Enabled = false;
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

    private void getCompanyDetails()
    {
      this.lvCompanyMaster.Items.Clear();
      DataTable companyCodes = CompanyDetailsClass.getCompanyCodes();
      if (companyCodes == null || companyCodes.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) companyCodes.Rows)
        this.lvCompanyMaster.Items.Add((object) row["CompanyCode"].ToString());
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      ((Control) this.btnAddEdit).Text = "&ADD";
      this.reset();
      ((Control) this.hp2).Enabled = true;
      ((Control) this.hp1).Enabled = false;
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      if (((Control) this.btnAddEdit).Text == "&ADD")
      {
        if (!this.checkIfAllTheEntriesAreDone())
          return;
        if (CompanyDetailsClass.addCompanyDetails(this.tbxCompanyCode.Text, this.tbxCompanyName.Text, this.tbxMailingName.Text, this.tbxDoorNumber.Text, this.tbxAddress1.Text, this.tbxAddress2.Text, this.tbxLocation.Text, this.tbxCity.Text, this.tbxPincode.Text, this.tbxState.Text, this.tbxCountry.Text, this.tbxPhoneNumber.Text, this.tbxAlternateNumber.Text, this.tbxFaxNumber.Text, this.tbxEmailId.Text, this.tbxWebsite.Text, this.tbxGst.Text, this.tbxNoOfDecimals.Text, FormMain.username, DateTime.Now, FormMain.username, DateTime.Now) == "Done")
          BillNumberSeriesClass.addBillNumberSettings(this.tbxCompanyCode.Text, "INVOICE NUMBER", "", "", 0.0, FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
        this.getCompanyDetails();
        this.reset();
        ((Control) this.hp1).Enabled = true;
        ((Control) this.hp2).Enabled = false;
      }
      else
      {
        if (!(((Control) this.btnAddEdit).Text == "&UPDATE"))
          return;
        if (CompanyDetailsClass.editCompanyDetails(this.tbxCompanyCode.Text, this.tbxCompanyName.Text, this.tbxMailingName.Text, this.tbxDoorNumber.Text, this.tbxAddress1.Text, this.tbxAddress2.Text, this.tbxLocation.Text, this.tbxCity.Text, this.tbxPincode.Text, this.tbxState.Text, this.tbxCountry.Text, this.tbxPhoneNumber.Text, this.tbxAlternateNumber.Text, this.tbxFaxNumber.Text, this.tbxEmailId.Text, this.tbxWebsite.Text, this.tbxGst.Text, this.tbxNoOfDecimals.Text, FormMain.username, DateTime.Now) == "Done")
          BillNumberSeriesClass.editBillNumberSettings(this.tbxCompanyCode.Text, "INVOICE NUMBER", "", "", 0.0, FormMain.username, DateTime.Now);
        this.getCompanyDetails();
        this.tbxCompanyCode.Enabled = true;
        this.reset();
        ((Control) this.hp1).Enabled = true;
        ((Control) this.hp2).Enabled = false;
      }
    }

    private bool checkIfAllTheEntriesAreDone()
    {
      if (this.tbxCompanyCode.Text.Trim() == "")
      {
        this.tbxCompanyCode.Select();
        return false;
      }
      if (CompanyDetailsClass.checkIfCompanyAlreadyExists(this.tbxCompanyCode.Text))
      {
        this.tbxCompanyCode.Select();
        return false;
      }
      if (this.tbxCompanyName.Text.Trim() == "")
      {
        this.tbxCompanyName.Select();
        return false;
      }
      if (this.tbxMailingName.Text.Trim() == "")
      {
        this.tbxMailingName.Select();
        return false;
      }
      if (this.tbxDoorNumber.Text.Trim() == "")
      {
        this.tbxDoorNumber.Select();
        return false;
      }
      if (this.tbxAddress1.Text.Trim() == "")
      {
        this.tbxAddress1.Select();
        return false;
      }
      if (!(this.tbxLocation.Text.Trim() == ""))
        return true;
      this.tbxLocation.Select();
      return false;
    }

    private void tbxCustomerCode_Validating(object sender, CancelEventArgs e)
    {
      if (!CompanyDetailsClass.checkIfCompanyAlreadyExists(this.tbxCompanyCode.Text))
        return;
      this.tbxCompanyCode.Select();
    }

    private void tbxCustomerCode_TextChanged(object sender, EventArgs e)
    {
      if (!CompanyDetailsClass.checkIfCompanyAlreadyExists(this.tbxCompanyCode.Text))
        return;
      this.tbxCompanyCode.ForeColor = Color.Red;
    }

    private void squareButton2_Click(object sender, EventArgs e)
    {
      if (this.lvCompanyMaster.Items.Count <= 0)
        return;
      int selectedIndex = this.lvCompanyMaster.SelectedIndex;
      if (this.lvCompanyMaster.SelectedIndices != null && selectedIndex >= 0)
      {
        string compnayCode = this.lvCompanyMaster.Items[selectedIndex].ToString();
        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete" + compnayCode + "?", "DELETE??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
          CompanyDetailsClass.deleteCompany(compnayCode);
          BillNumberSeriesClass.deleteCompany(compnayCode);
          this.getCompanyDetails();
          this.reset();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Select a company to Delete.");
      }
    }

    private void reset()
    {
      this.tbxCompanyCode.Text = string.Empty;
      this.tbxCompanyName.Text = string.Empty;
      this.tbxMailingName.Text = string.Empty;
      this.tbxDoorNumber.Text = string.Empty;
      this.tbxAddress1.Text = string.Empty;
      this.tbxAddress2.Text = string.Empty;
      this.tbxLocation.Text = string.Empty;
      this.tbxCity.Text = string.Empty;
      this.tbxPincode.Text = string.Empty;
      this.tbxState.Text = string.Empty;
      this.tbxCountry.Text = string.Empty;
      this.tbxPhoneNumber.Text = string.Empty;
      this.tbxAlternateNumber.Text = string.Empty;
      this.tbxFaxNumber.Text = string.Empty;
      this.tbxEmailId.Text = string.Empty;
      this.tbxWebsite.Text = string.Empty;
      this.tbxGst.Text = string.Empty;
      this.tbxNoOfDecimals.Text = string.Empty;
    }

    private void lvCompanyMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lvCompanyMaster.Items.Count <= 0)
        return;
      int selectedIndex = this.lvCompanyMaster.SelectedIndex;
      if (this.lvCompanyMaster.SelectedIndices != null && selectedIndex >= 0)
        this.getCompanyDetails(this.lvCompanyMaster.Items[selectedIndex].ToString());
    }

    private string getSelectedCompany()
    {
      if (this.lvCompanyMaster.Items.Count <= 0)
        return "";
      int selectedIndex = this.lvCompanyMaster.SelectedIndex;
      if (selectedIndex < 0)
        return "";
      return this.lvCompanyMaster.Items[selectedIndex].ToString();
    }

    private void getCompanyDetails(string CompanyCode)
    {
      DataTable companyDetails = CompanyDetailsClass.getCompanyDetails(CompanyCode);
      if (companyDetails == null || companyDetails.Rows.Count <= 0)
        return;
      this.tbxCompanyCode.Text = companyDetails.Rows[0][nameof (CompanyCode)].ToString();
      this.tbxCompanyName.Text = companyDetails.Rows[0]["CompanyName"].ToString();
      this.tbxMailingName.Text = companyDetails.Rows[0]["MailingName"].ToString();
      this.tbxDoorNumber.Text = companyDetails.Rows[0]["DoorNumber"].ToString();
      this.tbxAddress1.Text = companyDetails.Rows[0]["Address1"].ToString();
      this.tbxAddress2.Text = companyDetails.Rows[0]["Address2"].ToString();
      this.tbxLocation.Text = companyDetails.Rows[0]["Location"].ToString();
      this.tbxCity.Text = companyDetails.Rows[0]["City"].ToString();
      this.tbxPincode.Text = companyDetails.Rows[0]["Pincode"].ToString();
      this.tbxState.Text = companyDetails.Rows[0]["State"].ToString();
      this.tbxCountry.Text = companyDetails.Rows[0]["Country"].ToString();
      this.tbxPhoneNumber.Text = companyDetails.Rows[0]["PhoneNumber"].ToString();
      this.tbxAlternateNumber.Text = companyDetails.Rows[0]["AlternateNumber"].ToString();
      this.tbxFaxNumber.Text = companyDetails.Rows[0]["FaxNumber"].ToString();
      this.tbxEmailId.Text = companyDetails.Rows[0]["Email"].ToString();
      this.tbxWebsite.Text = companyDetails.Rows[0]["WebSite"].ToString();
      this.tbxGst.Text = companyDetails.Rows[0]["GstNumber"].ToString();
      this.tbxNoOfDecimals.Text = companyDetails.Rows[0]["NumberOfDecimalPlaces"].ToString();
    }

    private void squareButton1_Click(object sender, EventArgs e)
    {
      if (this.lvCompanyMaster.Items.Count <= 0)
        return;
      int selectedIndex = this.lvCompanyMaster.SelectedIndex;
      if (this.lvCompanyMaster.SelectedIndices != null && selectedIndex >= 0)
      {
        this.reset();
        ((Control) this.btnAddEdit).Text = "&UPDATE";
        this.tbxCompanyCode.Text = this.getSelectedCompany();
        this.getCompanyDetails(this.tbxCompanyCode.Text);
        this.tbxCompanyCode.Enabled = false;
        ((Control) this.hp2).Enabled = true;
        ((Control) this.hp1).Enabled = false;
      }
      else
      {
        int num = (int) MessageBox.Show("Select a company");
      }
    }

    private void lvCompanyMaster_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Up)
      {
        if (this.lvCompanyMaster.Items.Count <= 0 || this.lvCompanyMaster.SelectedItem == null || this.lvCompanyMaster.SelectedIndex != 0)
          return;
        ((Control) this.btnDelete).Focus();
        this.lvCompanyMaster.SetSelected(this.lvCompanyMaster.SelectedIndex, false);
      }
      else
      {
        if (e.KeyCode != Keys.Down || this.lvCompanyMaster.Items.Count <= 0 || this.lvCompanyMaster.SelectedItem == null || this.lvCompanyMaster.SelectedIndex != this.lvCompanyMaster.Items.Count - 1)
          return;
        this.SelectNextControl((Control) sender, true, true, true, true);
        this.lvCompanyMaster.ClearSelected();
        this.lvCompanyMaster.SelectedIndices.Clear();
      }
    }

    private void btnDelete_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down)
        return;
      ((Control) this.btnExit).Focus();
    }

    private void squareButton1_Click_1(object sender, EventArgs e) => this.Close();

    private void btnExit_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.lvCompanyMaster.Items.Count <= 0)
        return;
      this.lvCompanyMaster.ClearSelected();
      this.lvCompanyMaster.SetSelected(0, true);
    }

    private void squareButton1_Click_2(object sender, EventArgs e)
    {
      if (this.lvCompanyMaster.Items.Count <= 0)
        return;
      int selectedIndex = this.lvCompanyMaster.SelectedIndex;
      if (this.lvCompanyMaster.SelectedIndices != null && selectedIndex >= 0)
      {
        CompanyDetailsClass.setDefaultCompany(this.lvCompanyMaster.Items[selectedIndex].ToString());
        this.getCompanyDetails();
        this.reset();
      }
      else
      {
        int num = (int) MessageBox.Show("Select a company to Delete.");
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
      this.panel2 = new Panel();
      this.label19 = new Label();
      this.hp2 = new HeaderPanel();
      this.btnAddEdit = new SquareButton();
      this.label18 = new Label();
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
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.tbxNoOfDecimals = new TextBox();
      this.tbxGst = new TextBox();
      this.tbxWebsite = new TextBox();
      this.tbxEmailId = new TextBox();
      this.tbxFaxNumber = new TextBox();
      this.tbxAlternateNumber = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCountry = new TextBox();
      this.tbxState = new TextBox();
      this.tbxPincode = new TextBox();
      this.tbxCity = new TextBox();
      this.tbxLocation = new TextBox();
      this.tbxAddress2 = new TextBox();
      this.tbxAddress1 = new TextBox();
      this.tbxDoorNumber = new TextBox();
      this.tbxMailingName = new TextBox();
      this.tbxCompanyName = new TextBox();
      this.label1 = new Label();
      this.tbxCompanyCode = new TextBox();
      this.hp1 = new HeaderPanel();
      this.squareButton1 = new SquareButton();
      this.btnExit = new SquareButton();
      this.lvCompanyMaster = new ListBox();
      this.btnDelete = new SquareButton();
      this.btnEdit = new SquareButton();
      this.btnAdd = new SquareButton();
      this.panel2.SuspendLayout();
      ((Control) this.hp2).SuspendLayout();
      ((Control) this.hp1).SuspendLayout();
      this.SuspendLayout();
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label19);
      this.panel2.Location = new Point(4, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(273, 56);
      this.panel2.TabIndex = 16;
      this.label19.AutoSize = true;
      this.label19.BackColor = Color.Transparent;
      this.label19.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.Black;
      this.label19.Location = new Point(16, 12);
      this.label19.Name = "label19";
      this.label19.Size = new Size(240, 29);
      this.label19.TabIndex = 10;
      this.label19.Text = "COMPANY MASTER";
      ((Control) this.hp2).Anchor = AnchorStyles.None;
      ((Control) this.hp2).BackColor = Color.PowderBlue;
      ((Control) this.hp2).BackgroundImageLayout = ImageLayout.Stretch;
      this.hp2.BorderColor = SystemColors.HotTrack;
      this.hp2.BorderStyle = BorderStyles.Single;
      this.hp2.CaptionBeginColor = Color.PowderBlue;
      this.hp2.CaptionEndColor = Color.AliceBlue;
      this.hp2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hp2.CaptionHeight = 22;
      this.hp2.CaptionPosition = CaptionPositions.Top;
      this.hp2.CaptionText = "ENTER COMPANY DETAILS";
      this.hp2.CaptionVisible = true;
      ((Control) this.hp2).Controls.Add((Control) this.btnAddEdit);
      ((Control) this.hp2).Controls.Add((Control) this.label18);
      ((Control) this.hp2).Controls.Add((Control) this.label17);
      ((Control) this.hp2).Controls.Add((Control) this.label16);
      ((Control) this.hp2).Controls.Add((Control) this.label15);
      ((Control) this.hp2).Controls.Add((Control) this.label14);
      ((Control) this.hp2).Controls.Add((Control) this.label13);
      ((Control) this.hp2).Controls.Add((Control) this.label12);
      ((Control) this.hp2).Controls.Add((Control) this.label11);
      ((Control) this.hp2).Controls.Add((Control) this.label10);
      ((Control) this.hp2).Controls.Add((Control) this.label9);
      ((Control) this.hp2).Controls.Add((Control) this.label8);
      ((Control) this.hp2).Controls.Add((Control) this.label7);
      ((Control) this.hp2).Controls.Add((Control) this.label6);
      ((Control) this.hp2).Controls.Add((Control) this.label5);
      ((Control) this.hp2).Controls.Add((Control) this.label4);
      ((Control) this.hp2).Controls.Add((Control) this.label3);
      ((Control) this.hp2).Controls.Add((Control) this.label2);
      ((Control) this.hp2).Controls.Add((Control) this.tbxNoOfDecimals);
      ((Control) this.hp2).Controls.Add((Control) this.tbxGst);
      ((Control) this.hp2).Controls.Add((Control) this.tbxWebsite);
      ((Control) this.hp2).Controls.Add((Control) this.tbxEmailId);
      ((Control) this.hp2).Controls.Add((Control) this.tbxFaxNumber);
      ((Control) this.hp2).Controls.Add((Control) this.tbxAlternateNumber);
      ((Control) this.hp2).Controls.Add((Control) this.tbxPhoneNumber);
      ((Control) this.hp2).Controls.Add((Control) this.tbxCountry);
      ((Control) this.hp2).Controls.Add((Control) this.tbxState);
      ((Control) this.hp2).Controls.Add((Control) this.tbxPincode);
      ((Control) this.hp2).Controls.Add((Control) this.tbxCity);
      ((Control) this.hp2).Controls.Add((Control) this.tbxLocation);
      ((Control) this.hp2).Controls.Add((Control) this.tbxAddress2);
      ((Control) this.hp2).Controls.Add((Control) this.tbxAddress1);
      ((Control) this.hp2).Controls.Add((Control) this.tbxDoorNumber);
      ((Control) this.hp2).Controls.Add((Control) this.tbxMailingName);
      ((Control) this.hp2).Controls.Add((Control) this.tbxCompanyName);
      ((Control) this.hp2).Controls.Add((Control) this.label1);
      ((Control) this.hp2).Controls.Add((Control) this.tbxCompanyCode);
      ((Control) this.hp2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hp2).ForeColor = Color.DarkBlue;
      this.hp2.GradientDirection = LinearGradientMode.Vertical;
      this.hp2.GradientEnd = Color.Azure;
      this.hp2.GradientStart = Color.LightCyan;
      ((Control) this.hp2).Location = new Point(283, 2);
      ((Control) this.hp2).Name = "hp2";
      this.hp2.PanelIcon = (Icon) null;
      this.hp2.PanelIconVisible = false;
      ((Control) this.hp2).Size = new Size(512, 611);
      ((Control) this.hp2).TabIndex = 1;
      this.hp2.TextAntialias = true;
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnAddEdit.GlowColor = Color.White;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(354, 536);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(142, 29);
      ((Control) this.btnAddEdit).TabIndex = 18;
      ((Control) this.btnAddEdit).Text = "&ADD";
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(7, 536);
      this.label18.Name = "label18";
      this.label18.Size = new Size(191, 25);
      this.label18.TabIndex = 36;
      this.label18.Text = "NO OF DECIMALS";
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Transparent;
      this.label17.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(5, 504);
      this.label17.Name = "label17";
      this.label17.Size = new Size(152, 25);
      this.label17.TabIndex = 35;
      this.label17.Text = "GST NUMBER";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Transparent;
      this.label16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(7, 474);
      this.label16.Name = "label16";
      this.label16.Size = new Size(106, 25);
      this.label16.TabIndex = 34;
      this.label16.Text = "WEBSITE";
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(7, 442);
      this.label15.Name = "label15";
      this.label15.Size = new Size(75, 25);
      this.label15.TabIndex = 33;
      this.label15.Text = "EMAIL";
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(7, 409);
      this.label14.Name = "label14";
      this.label14.Size = new Size(150, 25);
      this.label14.TabIndex = 32;
      this.label14.Text = "FAX NUMBER";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(7, 380);
      this.label13.Name = "label13";
      this.label13.Size = new Size(148, 25);
      this.label13.TabIndex = 31;
      this.label13.Text = "ALT NUMBER";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(7, 349);
      this.label12.Name = "label12";
      this.label12.Size = new Size(183, 25);
      this.label12.TabIndex = 30;
      this.label12.Text = "PHONE NUMBER";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(7, 318);
      this.label11.Name = "label11";
      this.label11.Size = new Size(116, 25);
      this.label11.TabIndex = 29;
      this.label11.Text = "COUNTRY";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(7, 287);
      this.label10.Name = "label10";
      this.label10.Size = new Size(80, 25);
      this.label10.TabIndex = 28;
      this.label10.Text = "STATE";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(7, 257);
      this.label9.Name = "label9";
      this.label9.Size = new Size(106, 25);
      this.label9.TabIndex = 27;
      this.label9.Text = "PINCODE";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(7, 225);
      this.label8.Name = "label8";
      this.label8.Size = new Size(60, 25);
      this.label8.TabIndex = 26;
      this.label8.Text = "CITY";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(7, 194);
      this.label7.Name = "label7";
      this.label7.Size = new Size(118, 25);
      this.label7.TabIndex = 25;
      this.label7.Text = "LOCATION";
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(7, 163);
      this.label6.Name = "label6";
      this.label6.Size = new Size(125, 25);
      this.label6.TabIndex = 24;
      this.label6.Text = "ADDRESS2";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(7, 132);
      this.label5.Name = "label5";
      this.label5.Size = new Size(125, 25);
      this.label5.TabIndex = 23;
      this.label5.Text = "ADDRESS1";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(7, 101);
      this.label4.Name = "label4";
      this.label4.Size = new Size(171, 25);
      this.label4.TabIndex = 22;
      this.label4.Text = "DOOR NUMBER";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(7, 70);
      this.label3.Name = "label3";
      this.label3.Size = new Size(164, 25);
      this.label3.TabIndex = 21;
      this.label3.Text = "MAILING NAME";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(7, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(186, 25);
      this.label2.TabIndex = 20;
      this.label2.Text = "COMPANY NAME";
      this.tbxNoOfDecimals.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNoOfDecimals.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNoOfDecimals.Location = new Point(204, 533);
      this.tbxNoOfDecimals.MaxLength = 1;
      this.tbxNoOfDecimals.Name = "tbxNoOfDecimals";
      this.tbxNoOfDecimals.Size = new Size(145, 31);
      this.tbxNoOfDecimals.TabIndex = 17;
      this.tbxNoOfDecimals.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxGst.BorderStyle = BorderStyle.FixedSingle;
      this.tbxGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxGst.Location = new Point(204, 501);
      this.tbxGst.MaxLength = 30;
      this.tbxGst.Name = "tbxGst";
      this.tbxGst.Size = new Size(293, 31);
      this.tbxGst.TabIndex = 16;
      this.tbxWebsite.BorderStyle = BorderStyle.FixedSingle;
      this.tbxWebsite.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxWebsite.Location = new Point(204, 470);
      this.tbxWebsite.Name = "tbxWebsite";
      this.tbxWebsite.Size = new Size(293, 31);
      this.tbxWebsite.TabIndex = 15;
      this.tbxEmailId.BorderStyle = BorderStyle.FixedSingle;
      this.tbxEmailId.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxEmailId.Location = new Point(204, 439);
      this.tbxEmailId.Name = "tbxEmailId";
      this.tbxEmailId.Size = new Size(293, 31);
      this.tbxEmailId.TabIndex = 14;
      this.tbxFaxNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFaxNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFaxNumber.Location = new Point(204, 408);
      this.tbxFaxNumber.Name = "tbxFaxNumber";
      this.tbxFaxNumber.Size = new Size(293, 31);
      this.tbxFaxNumber.TabIndex = 13;
      this.tbxAlternateNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAlternateNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateNumber.Location = new Point(204, 377);
      this.tbxAlternateNumber.MaxLength = 11;
      this.tbxAlternateNumber.Name = "tbxAlternateNumber";
      this.tbxAlternateNumber.Size = new Size(293, 31);
      this.tbxAlternateNumber.TabIndex = 12;
      this.tbxAlternateNumber.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.Location = new Point(204, 346);
      this.tbxPhoneNumber.MaxLength = 11;
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(293, 31);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxPhoneNumber.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxCountry.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCountry.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCountry.Location = new Point(204, 315);
      this.tbxCountry.Name = "tbxCountry";
      this.tbxCountry.Size = new Size(293, 31);
      this.tbxCountry.TabIndex = 10;
      this.tbxState.BorderStyle = BorderStyle.FixedSingle;
      this.tbxState.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxState.Location = new Point(204, 284);
      this.tbxState.Name = "tbxState";
      this.tbxState.Size = new Size(293, 31);
      this.tbxState.TabIndex = 9;
      this.tbxPincode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(204, 253);
      this.tbxPincode.MaxLength = 6;
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(293, 31);
      this.tbxPincode.TabIndex = 8;
      this.tbxPincode.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(204, 222);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(293, 31);
      this.tbxCity.TabIndex = 7;
      this.tbxLocation.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLocation.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLocation.Location = new Point(204, 191);
      this.tbxLocation.Name = "tbxLocation";
      this.tbxLocation.Size = new Size(293, 31);
      this.tbxLocation.TabIndex = 6;
      this.tbxAddress2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress2.Location = new Point(204, 160);
      this.tbxAddress2.Name = "tbxAddress2";
      this.tbxAddress2.Size = new Size(293, 31);
      this.tbxAddress2.TabIndex = 5;
      this.tbxAddress1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddress1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress1.Location = new Point(204, 129);
      this.tbxAddress1.Name = "tbxAddress1";
      this.tbxAddress1.Size = new Size(293, 31);
      this.tbxAddress1.TabIndex = 4;
      this.tbxDoorNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDoorNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDoorNumber.Location = new Point(204, 98);
      this.tbxDoorNumber.Name = "tbxDoorNumber";
      this.tbxDoorNumber.Size = new Size(293, 31);
      this.tbxDoorNumber.TabIndex = 3;
      this.tbxMailingName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMailingName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMailingName.Location = new Point(204, 67);
      this.tbxMailingName.Name = "tbxMailingName";
      this.tbxMailingName.Size = new Size(293, 31);
      this.tbxMailingName.TabIndex = 2;
      this.tbxCompanyName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCompanyName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCompanyName.Location = new Point(204, 36);
      this.tbxCompanyName.Name = "tbxCompanyName";
      this.tbxCompanyName.Size = new Size(293, 31);
      this.tbxCompanyName.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(7, 8);
      this.label1.Name = "label1";
      this.label1.Size = new Size(185, 25);
      this.label1.TabIndex = 19;
      this.label1.Text = "COMPANY CODE";
      this.tbxCompanyCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCompanyCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCompanyCode.Location = new Point(204, 5);
      this.tbxCompanyCode.Name = "tbxCompanyCode";
      this.tbxCompanyCode.Size = new Size(293, 31);
      this.tbxCompanyCode.TabIndex = 0;
      this.tbxCompanyCode.TextChanged += new EventHandler(this.tbxCustomerCode_TextChanged);
      this.tbxCompanyCode.Validating += new CancelEventHandler(this.tbxCustomerCode_Validating);
      ((Control) this.hp1).Anchor = AnchorStyles.None;
      ((Control) this.hp1).BackColor = Color.PowderBlue;
      ((Control) this.hp1).BackgroundImageLayout = ImageLayout.Stretch;
      this.hp1.BorderColor = SystemColors.HotTrack;
      this.hp1.BorderStyle = BorderStyles.Single;
      this.hp1.CaptionBeginColor = Color.PowderBlue;
      this.hp1.CaptionEndColor = Color.AliceBlue;
      this.hp1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hp1.CaptionHeight = 22;
      this.hp1.CaptionPosition = CaptionPositions.Top;
      this.hp1.CaptionText = "SELECT A COMPANY";
      this.hp1.CaptionVisible = true;
      ((Control) this.hp1).Controls.Add((Control) this.squareButton1);
      ((Control) this.hp1).Controls.Add((Control) this.btnExit);
      ((Control) this.hp1).Controls.Add((Control) this.lvCompanyMaster);
      ((Control) this.hp1).Controls.Add((Control) this.btnDelete);
      ((Control) this.hp1).Controls.Add((Control) this.btnEdit);
      ((Control) this.hp1).Controls.Add((Control) this.btnAdd);
      ((Control) this.hp1).Font = new Font("Bookman Old Style", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hp1).ForeColor = Color.DarkBlue;
      this.hp1.GradientDirection = LinearGradientMode.Vertical;
      this.hp1.GradientEnd = Color.Azure;
      this.hp1.GradientStart = Color.AliceBlue;
      ((Control) this.hp1).Location = new Point(4, 61);
      ((Control) this.hp1).Name = "hp1";
      this.hp1.PanelIcon = (Icon) null;
      this.hp1.PanelIconVisible = false;
      ((Control) this.hp1).Size = new Size(273, 550);
      ((Control) this.hp1).TabIndex = 0;
      this.hp1.TextAntialias = true;
      this.squareButton1.BackColor = Color.LightBlue;
      this.squareButton1.FadeOnFocus = true;
      this.squareButton1.ForeColor = Color.MediumBlue;
      this.squareButton1.ForeColorOnFocus = Color.Red;
      this.squareButton1.ForeColorOnLeave = Color.MediumBlue;
      this.squareButton1.GlowColor = Color.White;
      this.squareButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.squareButton1).Location = new Point(7, 438);
      ((Control) this.squareButton1).Name = "squareButton1";
      this.squareButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.squareButton1.ShineColor = Color.Transparent;
      ((Control) this.squareButton1).Size = new Size(258, 41);
      ((Control) this.squareButton1).TabIndex = 3;
      ((Control) this.squareButton1).Text = "&SET AS DEFAULT";
      ((Control) this.squareButton1).Click += new EventHandler(this.squareButton1_Click_2);
      this.btnExit.BackColor = Color.LightBlue;
      this.btnExit.FadeOnFocus = true;
      this.btnExit.ForeColor = Color.MediumBlue;
      this.btnExit.ForeColorOnFocus = Color.Red;
      this.btnExit.ForeColorOnLeave = Color.MediumBlue;
      this.btnExit.GlowColor = Color.White;
      this.btnExit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnExit).Location = new Point(8, 479);
      ((Control) this.btnExit).Name = "btnExit";
      this.btnExit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnExit.ShineColor = Color.Transparent;
      ((Control) this.btnExit).Size = new Size(258, 41);
      ((Control) this.btnExit).TabIndex = 4;
      ((Control) this.btnExit).Text = "&EXIT";
      ((Control) this.btnExit).Click += new EventHandler(this.squareButton1_Click_1);
      ((Control) this.btnExit).KeyDown += new KeyEventHandler(this.btnExit_KeyDown);
      this.lvCompanyMaster.FormattingEnabled = true;
      this.lvCompanyMaster.ItemHeight = 19;
      this.lvCompanyMaster.Location = new Point(5, 5);
      this.lvCompanyMaster.Name = "lvCompanyMaster";
      this.lvCompanyMaster.Size = new Size(261, 308);
      this.lvCompanyMaster.TabIndex = 5;
      this.lvCompanyMaster.SelectedIndexChanged += new EventHandler(this.lvCompanyMaster_SelectedIndexChanged);
      this.lvCompanyMaster.KeyDown += new KeyEventHandler(this.lvCompanyMaster_KeyDown);
      this.btnDelete.BackColor = Color.LightBlue;
      this.btnDelete.FadeOnFocus = true;
      this.btnDelete.ForeColor = Color.MediumBlue;
      this.btnDelete.ForeColorOnFocus = Color.Red;
      this.btnDelete.ForeColorOnLeave = Color.MediumBlue;
      this.btnDelete.GlowColor = Color.White;
      this.btnDelete.InnerBorderColor = Color.Transparent;
      ((Control) this.btnDelete).Location = new Point(8, 397);
      ((Control) this.btnDelete).Name = "btnDelete";
      this.btnDelete.OuterBorderColor = Color.MediumSlateBlue;
      this.btnDelete.ShineColor = Color.Transparent;
      ((Control) this.btnDelete).Size = new Size(258, 41);
      ((Control) this.btnDelete).TabIndex = 2;
      ((Control) this.btnDelete).Text = "&DELETE";
      ((Control) this.btnDelete).Click += new EventHandler(this.squareButton2_Click);
      ((Control) this.btnDelete).KeyDown += new KeyEventHandler(this.btnDelete_KeyDown);
      this.btnEdit.BackColor = Color.LightBlue;
      this.btnEdit.FadeOnFocus = true;
      this.btnEdit.ForeColor = Color.MediumBlue;
      this.btnEdit.ForeColorOnFocus = Color.Red;
      this.btnEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnEdit.GlowColor = Color.White;
      this.btnEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnEdit).Location = new Point(8, 356);
      ((Control) this.btnEdit).Name = "btnEdit";
      this.btnEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnEdit.ShineColor = Color.Transparent;
      ((Control) this.btnEdit).Size = new Size(258, 41);
      ((Control) this.btnEdit).TabIndex = 1;
      ((Control) this.btnEdit).Text = "&EDIT";
      ((Control) this.btnEdit).Click += new EventHandler(this.squareButton1_Click);
      this.btnAdd.BackColor = Color.LightBlue;
      this.btnAdd.FadeOnFocus = true;
      this.btnAdd.ForeColor = Color.MediumBlue;
      this.btnAdd.ForeColorOnFocus = Color.Red;
      this.btnAdd.ForeColorOnLeave = Color.MediumBlue;
      this.btnAdd.GlowColor = Color.White;
      this.btnAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAdd).Location = new Point(8, 315);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.Transparent;
      ((Control) this.btnAdd).Size = new Size(258, 41);
      ((Control) this.btnAdd).TabIndex = 0;
      ((Control) this.btnAdd).Text = "&ADD";
      ((Control) this.btnAdd).Click += new EventHandler(this.btnAdd_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(798, 615);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.hp2);
      this.Controls.Add((Control) this.hp1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormCompanyDetails);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "COMPANY MASTER";
      this.Load += new EventHandler(this.FormCompanyDetails_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((Control) this.hp2).ResumeLayout(false);
      ((Control) this.hp2).PerformLayout();
      ((Control) this.hp1).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
