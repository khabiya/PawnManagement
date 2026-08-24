
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using SecuGen.SecuSearchSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using WIATest;

namespace PawnManagement
{
  public class Form1 : Form
  {
    private SS_IDInfo idInfo;
    private byte[] minData;
    public bool photoTaken = false;
    public static string newCustomerCodeAdde = "";
    public static string strFormType = "";
    private string oldValues;
    private string newValues;
    private string strCustomerCodeForEditing = "";
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private Button btnResidentialAddress;
    private Button btnPersonalDetails;
    private Panel panel2;
    private Panel SidePanel;
    private Button btnBankDetails;
    private Button btnProofs;
    private LinkLabel llScanCustomerPhoto;
    private LinkLabel llSelectCustomerPhoto;
    private LinkLabel llAddCustomerPhoto;
    private PictureBox pbPhoto;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private TabControl tabControl;
    private TabPage tpPersonalDetails;
    private Panel apnlPersonalDetails;
    private Panel panel11;
    private TextBox tbxEmail;
    private Panel panel10;
    private TextBox tbxNotes;
    private Panel panel9;
    private TextBox tbxAlternateNumber;
    private Panel panel8;
    private TextBox tbxPhone;
    private Panel panel7;
    private TextBox tbxSex;
    private Panel panel6;
    private Panel panel5;
    private TextBox tbxCustomerName;
    private Panel panel4;
    private TextBox tbxCustomerCode;
    private Label lblCustomerCode;
    private Label lblCustomerName;
    private Label label8;
    private Label label5;
    private Label label9;
    private Label lblSex;
    private Label label10;
    private Label label11;
    private TabPage tpResidentialAddress;
    private TabPage tpProof;
    private Panel apnlProof;
    private Panel panel44;
    private PictureBox pbDeleteOthersBack;
    private PictureBox pbCameraOthersBack;
    private PictureBox pbScanOthersBack;
    private PictureBox pbSelectOthersBack;
    private Panel panel45;
    private PictureBox pbDeleteOthersFront;
    private PictureBox pbCameraOthersFront;
    private PictureBox pbScanOthersFront;
    private PictureBox pbSelectOthersFront;
    private Panel panel47;
    private PictureBox pbDeleteRationCardBack;
    private PictureBox pbCameraRationCardBack;
    private PictureBox pbScanRationCardBack;
    private PictureBox pbSelectRationCardBack;
    private Panel panel48;
    private PictureBox pbDeleteRationCardFront;
    private PictureBox pbCameraRationCardFront;
    private PictureBox pbScanRationCardFront;
    private PictureBox pbSelectRationCardFront;
    private Panel panel38;
    private PictureBox pbDeleteDrivingLicenseBack;
    private PictureBox pbCameraDrivingLicenseBack;
    private PictureBox pbScanDrivingLicenseBack;
    private PictureBox pbSelectDrivingLicenseBack;
    private Panel panel39;
    private PictureBox pbDeleteDrivingLicenseFront;
    private PictureBox pbCameraDrivingLicenseFront;
    private PictureBox pbScanDrivingLicenseFront;
    private PictureBox pbSelectDrivingLicenseFront;
    private Panel panel41;
    private PictureBox pbDeleteVoterIdBack;
    private PictureBox pbCameraVoterIdBack;
    private PictureBox pbScanVoterIdBack;
    private PictureBox pbSelectVoterIdBack;
    private Panel panel42;
    private PictureBox pbDeleteVoterIdFront;
    private PictureBox pbCameraVoterIdFront;
    private PictureBox pbScanVoterIdFront;
    private PictureBox pbSelectVoterIdFront;
    private Panel panel35;
    private PictureBox pbDeletePanBack;
    private PictureBox pbCamPanBack;
    private PictureBox pbScanPanBack;
    private PictureBox pbSelectPanBack;
    private Panel panel36;
    private PictureBox pbDeletePanFront;
    private PictureBox pbCameraPanFront;
    private PictureBox pbScanPanFront;
    private PictureBox pbSelectPanFront;
    private Panel panel33;
    private PictureBox pbDeleteAadharBack;
    private PictureBox pbCameraAadharBack;
    private PictureBox pbScanAadharBack;
    private PictureBox pbSelectAadharBack;
    private PictureBox pbPanCardBack;
    private Panel panel49;
    private Label label31;
    private PictureBox pbPanCardFront;
    private PictureBox pbDrivingLicenseBack;
    private Panel panel46;
    private Label label30;
    private PictureBox pbDrivingLicenseFront;
    private PictureBox pbOthersBack;
    private Panel panel43;
    private Label label29;
    private PictureBox pbOthersFront;
    private PictureBox pbRationCardBack;
    private Panel panel40;
    private Label label28;
    private PictureBox pbRationCardFront;
    private PictureBox pbVoterIdBack;
    private Panel panel37;
    private Label label27;
    private PictureBox pbVoterIdFront;
    private PictureBox pbAadharBack;
    private Panel panel12;
    private PictureBox pbDeleteAadharFront;
    private PictureBox pbCameraAadharFront;
    private PictureBox pbScanAadharFront;
    private PictureBox pbSelectAadharFront;
    private Panel panel34;
    private Label label26;
    private PictureBox pbAadharFront;
    private TabPage tpBankDetails;
    private TabPage tpFamilyDetails;
    private TabPage tpKyc;
    private Panel panel3;
    private TextBox tbxMotherName;
    private Panel panel50;
    private TextBox tbxFatherName;
    private Panel panel51;
    private TextBox tbxMaritalStatus;
    private Panel panel53;
    private TextBox tbxIntroducedBy;
    private Panel panel54;
    private TextBox tbxInterestRAte;
    private Panel panel55;
    private TextBox tbxReligion;
    private Panel panel56;
    private TextBox tbxEducation;
    private Label label2;
    private Label label3;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private Label label36;
    private Panel panel57;
    private TextBox tbxRationCard;
    private Panel panel58;
    private TextBox tbxDrivingLicense;
    private Panel panel59;
    private TextBox tbxVoterId;
    private Panel panel60;
    private TextBox tbxPanCard;
    private Panel panel61;
    private TextBox tbxAadharNumber;
    private Label label38;
    private Label label39;
    private Label label40;
    private Label label41;
    private Label label43;
    private Panel panel62;
    private TextBox tbxSpouseName;
    private Label label42;
    private Panel panel63;
    private TextBox tbxOccupation;
    private Label label44;
    private PictureBox pbFingerPrint;
    private Label lblHeading;
    private Label lblHeading2;
    private Panel apnlResidentialAddress;
    private ComboBox pcbLocation;
    private ComboBox pcbHouseType;
    private ComboBox pcbOwnerShip;
    private Label label17;
    private Panel panel23;
    private Label label18;
    private Panel panel24;
    private Panel panel25;
    private TextBox ptbxLandMark;
    private Panel panel27;
    private TextBox ptbxPincode;
    private Panel panel28;
    private TextBox ptbxCity;
    private Panel panel29;
    private Panel panel30;
    private TextBox ptbxAddr2;
    private Panel panel31;
    private TextBox ptbxAddr1;
    private Panel panel32;
    private TextBox ptbxDoorNumber;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label23;
    private Label label24;
    private Label label25;
    private ComboBox cbLocation;
    private ComboBox cbHouseType;
    private ComboBox cbOwnerShip;
    private Label label16;
    private Panel panel22;
    private Label label7;
    private Panel panel21;
    private Panel panel13;
    private TextBox tbxLandMark;
    private Panel panel15;
    private TextBox tbxPincode;
    private Panel panel16;
    private TextBox tbxCity;
    private Panel panel17;
    private Panel panel18;
    private TextBox tbxAddr2;
    private Panel panel19;
    private TextBox tbxAddr1;
    private Panel panel20;
    private TextBox tbxDoorNumber;
    private Label label1;
    private Label label4;
    private Label label6;
    private Label label13;
    private Label label14;
    private Label label15;
    private TextBox tbxSpouseNameSearch;
    private TextBox tbxMotherNameSearch;
    private TextBox tbxFatherNameSearch;
    private Button btnNext;
    private MaskedTextBox tbxDob;
    private LinkLabel linkLabel6;
    private LinkLabel linkLabel5;
    private LinkLabel linkLabel4;
    private DataGridView dgvFatherNameSearch;
    private DataGridView dgvMotherNameSearch;
    private DataGridView dgvSpouseNameSearch;
    private TextBox tbxSpouseCode;
    private TextBox tbxMotherCode;
    private TextBox tbxFatherCode;
    private LinkLabel llTakeFingerPrint;
    private Button btnSave1;
    private Button btnSave2;
    private Button btnPrevious;
    private Panel panel14;
    private TextBox tbxOthers;
    private Label label12;
    private ListBox lbDevices;
    private LinkLabel linkLabel1;
    private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private Button button3;

    public Form1()
    {
      this.InitializeComponent();
      this.SidePanel.Height = this.btnPersonalDetails.Height;
      this.SidePanel.Top = this.btnPersonalDetails.Top;
    }

    public Form1(string formType, string customerCodeForEditing)
    {
      this.InitializeComponent();
      Form1.strFormType = formType;
      this.strCustomerCodeForEditing = customerCodeForEditing;
      this.SidePanel.Height = this.btnPersonalDetails.Height;
      this.SidePanel.Top = this.btnPersonalDetails.Top;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = this.btnPersonalDetails.Height;
      this.SidePanel.Top = this.btnPersonalDetails.Top;
      this.tpPersonalDetails.Show();
      this.tpPersonalDetails.BringToFront();
      this.lblHeading.Text = "Personal Details";
      this.lblHeading2.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = this.btnResidentialAddress.Height;
      this.SidePanel.Top = this.btnResidentialAddress.Top;
      this.tpResidentialAddress.Show();
      this.tpResidentialAddress.BringToFront();
      this.tbxDoorNumber.Select();
      this.lblHeading.Text = "Residential Address";
      this.lblHeading2.Text = "Permananent Address";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape && DialogResult.Yes == MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo))
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      switch (Form1.strFormType)
      {
        case "EDIT":
          this.getCustomerDetails(this.strCustomerCodeForEditing);
          this.getAllThePhotos();
          break;
      }
      this.Assign((Control) this);
      this.setAuctoCustomSources();
      this.populatecbLocation();
      this.tbxCustomerName.Select();
      this.clearPhotosInTemp();
    }

    private void clearPhotosInTemp()
    {
      try
      {
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\AadharFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\AadharBack\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\RationCardFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\RationCardBack\\temp"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\VoterIdFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\VoterIdBack\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\PanCardFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\PanCardBack\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\DrivingLicenseFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\DrivingLicenseBack\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\OthersFront\\temp\\"), new Action<string>(File.Delete));
        Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\OthersBack\\temp\\"), new Action<string>(File.Delete));
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form addcustomer.addcustomer_load firstexception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getCustomerDetails(string CustomerCode)
    {
      try
      {
        DataTable customerDetails = CustomersClass.getCustomerDetails(CustomerCode);
        if (customerDetails != null && customerDetails.Rows.Count > 0)
        {
          this.tbxCustomerCode.Text = CustomerCode;
          this.tbxCustomerName.Text = customerDetails.Rows[0].Field<string>("CName");
          this.tbxDob.Text = customerDetails.Rows[0]["Dob"].ToString();
          this.tbxSex.Text = customerDetails.Rows[0]["Sex"].ToString();
          this.tbxPhone.Text = customerDetails.Rows[0]["CPhone"].ToString();
          this.tbxAlternateNumber.Text = customerDetails.Rows[0].Field<string>("CCell");
          this.tbxNotes.Text = customerDetails.Rows[0].Field<string>("CNotes");
          this.tbxEmail.Text = customerDetails.Rows[0].Field<string>("CEmail");
          this.tbxOccupation.Text = customerDetails.Rows[0]["Occupation"].ToString();
          this.tbxFatherCode.Text = customerDetails.Rows[0]["FatherName"].ToString();
          this.tbxMotherCode.Text = customerDetails.Rows[0]["MotherName"].ToString();
          this.tbxSpouseCode.Text = customerDetails.Rows[0]["SpouseName"].ToString();
          this.tbxIntroducedBy.Text = customerDetails.Rows[0].Field<string>("CIntroducer");
          this.tbxMaritalStatus.Text = customerDetails.Rows[0]["MaritalStatus"].ToString();
          this.tbxEducation.Text = customerDetails.Rows[0]["Education"].ToString();
          this.tbxReligion.Text = customerDetails.Rows[0]["Religion"].ToString();
          this.tbxInterestRAte.Text = customerDetails.Rows[0].Field<string>("CInterestRate");
          this.tbxDoorNumber.Text = customerDetails.Rows[0].Field<string>("CNo");
          this.tbxAddr1.Text = customerDetails.Rows[0].Field<string>("CAddr1");
          this.tbxAddr2.Text = customerDetails.Rows[0].Field<string>("CAddr2");
          this.cbLocation.Text = customerDetails.Rows[0].Field<string>("CAddr3");
          this.tbxCity.Text = customerDetails.Rows[0].Field<string>("CCity");
          this.tbxPincode.Text = customerDetails.Rows[0].Field<string>("CPinCode");
          this.tbxLandMark.Text = customerDetails.Rows[0]["Landmark"].ToString();
          this.cbHouseType.Text = customerDetails.Rows[0]["HouseType"].ToString();
          this.cbOwnerShip.Text = customerDetails.Rows[0]["OwnerShip"].ToString();
          this.tbxAadharNumber.Text = customerDetails.Rows[0].Field<string>("CAadharNumber");
          this.tbxPanCard.Text = customerDetails.Rows[0]["PanCard"].ToString();
          this.tbxVoterId.Text = customerDetails.Rows[0]["VoterId"].ToString();
          this.tbxDrivingLicense.Text = customerDetails.Rows[0]["DrivingLicense"].ToString();
          this.tbxOthers.Text = customerDetails.Rows[0].Field<string>("COtherProof");
          this.tbxRationCard.Text = customerDetails.Rows[0].Field<string>("CRationCard");
          this.oldValues = "Old Values are  \n Name = " + this.tbxCustomerName.Text.Trim().ToString() + "\n PhoneNumber= " + this.tbxPhone.Text.Trim().ToString() + "\n CellNumber= " + this.tbxAlternateNumber.Text.Trim().ToString() + "\n DoorNo= " + this.tbxDoorNumber.Text.Trim().ToString() + "\n Addr1= " + this.tbxAddr1.Text.Trim().ToString() + "\n Addr2= " + this.tbxAddr2.Text.Trim().ToString() + "\n Location= " + this.cbLocation.Text.Trim().ToString() + "\n City= " + this.tbxCity.Text.Trim().ToString() + "\n Pincode= " + this.tbxPincode.Text.Trim().ToString() + "\n Introducer=  " + this.tbxIntroducedBy.Text.Trim().ToString() + "\n AadharNumber= " + this.tbxAadharNumber.Text.Trim().ToString() + "\n OtherProof= " + this.tbxOthers.Text.Trim().ToString() + "\n RationCard= " + this.tbxRationCard.Text.Trim().ToString() + "\n InterestRate= " + this.tbxInterestRAte.Text.Trim().ToString() + "\n Email= " + this.tbxEmail.Text.Trim().ToString() + "\n Notes= " + this.tbxNotes.Text.Trim().ToString();
        }
        if (!File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        File.Copy(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editcustomer.tbxCustomerCode_textChanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getDefaultLocation()
    {
      string defaultLocation = LocationAndPincodeClass.getDefaultLocation();
      if (this.cbLocation.Items.Contains((object) defaultLocation))
        this.cbLocation.Text = defaultLocation;
      if (!this.cbLocation.Items.Contains((object) defaultLocation))
        return;
      this.cbLocation.Text = defaultLocation;
    }

    private void getDefaultLocationp()
    {
      string defaultLocation = LocationAndPincodeClass.getDefaultLocation();
      if (this.pcbLocation.Items.Contains((object) defaultLocation))
        this.pcbLocation.Text = defaultLocation;
      if (!this.pcbLocation.Items.Contains((object) defaultLocation))
        return;
      this.pcbLocation.Text = defaultLocation;
    }

    private void setAuctoCustomSources()
    {
      List<string> valuesOfThisColumn1 = CustomersClass.getDistinctValuesOfThisColumn("CName");
      List<string> valuesOfThisColumn2 = CustomersClass.getDistinctValuesOfThisColumn("CAddr1");
      List<string> valuesOfThisColumn3 = CustomersClass.getDistinctValuesOfThisColumn("CAddr2");
      List<string> valuesOfThisColumn4 = CustomersClass.getDistinctValuesOfThisColumn("Occupation");
      List<string> valuesOfThisColumn5 = CustomersClass.getDistinctValuesOfThisColumn("MaritalStatus");
      List<string> valuesOfThisColumn6 = CustomersClass.getDistinctValuesOfThisColumn("Education");
      List<string> valuesOfThisColumn7 = CustomersClass.getDistinctValuesOfThisColumn("Religion");
      this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr1.AutoCompleteCustomSource.AddRange(valuesOfThisColumn2.ToArray());
      this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr2.AutoCompleteCustomSource.AddRange(valuesOfThisColumn3.ToArray());
      this.ptbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.ptbxAddr1.AutoCompleteCustomSource.AddRange(valuesOfThisColumn2.ToArray());
      this.ptbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.ptbxAddr2.AutoCompleteCustomSource.AddRange(valuesOfThisColumn3.ToArray());
      this.tbxCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxCustomerName.AutoCompleteCustomSource.AddRange(valuesOfThisColumn1.ToArray());
      this.tbxIntroducedBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxIntroducedBy.AutoCompleteCustomSource.AddRange(valuesOfThisColumn1.ToArray());
      this.tbxOccupation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxOccupation.AutoCompleteCustomSource.AddRange(valuesOfThisColumn4.ToArray());
      this.tbxMaritalStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxMaritalStatus.AutoCompleteCustomSource.AddRange(valuesOfThisColumn5.ToArray());
      this.tbxEducation.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxEducation.AutoCompleteCustomSource.AddRange(valuesOfThisColumn6.ToArray());
      this.tbxReligion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxReligion.AutoCompleteCustomSource.AddRange(valuesOfThisColumn7.ToArray());
    }

    private void populatecbLocation()
    {
      List<string> distinctLocation = LocationAndPincodeClass.getDistinctLocation();
      this.cbLocation.Items.AddRange((object[]) distinctLocation.ToArray());
      this.pcbLocation.Items.AddRange((object[]) distinctLocation.ToArray());
    }

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
            comboBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
            comboBox.Enter += new EventHandler(this.comboBoX_Enter);
            comboBox.Leave += new EventHandler(this.comboBox_Leave);
            break;
          default:
            this.Assign(control1);
            break;
        }
      }
    }

    private void comboBoX_Enter(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.GreenYellow;

    private void comboBox_Leave(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.White;

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAcceptNoINPUT(object sender, KeyPressEventArgs e) => e.Handled = true;

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
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void textBox_Enter(object sender, EventArgs e) => (sender as TextBox).BackColor = Color.GreenYellow;

    private void textBox_Leave(object sender, EventArgs e) => (sender as TextBox).BackColor = this.BackColor;

    private void tbxEmail_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !this.checkIfPersonalDetailsEntered())
        return;
      this.btnResidentialAddress.PerformClick();
    }

    private bool checkIfPersonalDetailsEntered()
    {
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        if (this.tbxCustomerName.Text.Trim() != "")
        {
          if (this.tbxSex.Text.Trim() != "")
          {
            if (this.tbxSex.Text.Trim() == "MALE" | this.tbxSex.Text.Trim() == "FEMALE")
            {
              if (this.tbxDob.Text.Trim() == "/  /" || PawnManagementClass.checkForValidateDate(this.tbxDob.Text.Trim()))
                return true;
              this.tpPersonalDetails.Show();
              this.tpPersonalDetails.BringToFront();
              this.tbxDob.Select();
              return false;
            }
            this.tpPersonalDetails.Show();
            this.tpPersonalDetails.BringToFront();
            this.tbxSex.Select();
            return false;
          }
          this.tpPersonalDetails.Show();
          this.tpPersonalDetails.BringToFront();
          this.tbxSex.Select();
          return false;
        }
        this.tpPersonalDetails.Show();
        this.tpPersonalDetails.BringToFront();
        this.tbxCustomerName.Select();
        return false;
      }
      this.tpPersonalDetails.Show();
      this.tpPersonalDetails.BringToFront();
      this.tbxCustomerName.Select();
      return false;
    }

    private void btnProofs_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = (sender as Button).Height;
      this.SidePanel.Top = (sender as Button).Top;
      this.tpProof.Show();
      this.tpProof.BringToFront();
      this.lblHeading.Text = "Proof";
      this.lblHeading2.Text = "";
      this.tbxAadharNumber.Select();
    }

    private void btnBankDetails_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = (sender as Button).Height;
      this.SidePanel.Top = (sender as Button).Top;
      this.tpBankDetails.Show();
      this.tpBankDetails.BringToFront();
      this.lblHeading.Text = "Bank Details";
    }

    private void btnFamilyDetails_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = (sender as Button).Height;
      this.SidePanel.Top = (sender as Button).Top;
      this.tpFamilyDetails.Show();
      this.tpFamilyDetails.BringToFront();
    }

    private void btnKYC_Click(object sender, EventArgs e)
    {
      this.SidePanel.Height = (sender as Button).Height;
      this.SidePanel.Top = (sender as Button).Top;
      this.tpKyc.Show();
      this.tpKyc.BringToFront();
    }

    private void picHover(object sender, EventArgs e) => (sender as PictureBox).BackColor = Color.Gainsboro;

    private void pictureBox62_MouseLeave(object sender, EventArgs e) => (sender as PictureBox).BackColor = Color.Transparent;

    private void tbxSex_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      int num;
      switch (keyChar)
      {
        case 'A':
        case 'E':
        case 'F':
        case 'L':
        case 'M':
          num = 0;
          break;
        default:
          num = keyChar != '\b' ? 1 : 0;
          break;
      }
      if (num == 0)
        return;
      e.Handled = true;
    }

    private void tbxSex_Validating(object sender, CancelEventArgs e)
    {
      if (this.tbxSex.Text.Trim() == "")
      {
        this.tbxSex.Select();
      }
      else
      {
        if (!(this.tbxSex.Text != "MALE") || !(this.tbxSex.Text != "FEMALE"))
          return;
        this.tbxSex.Select();
      }
    }

    private void tbxCustomerName_Validating(object sender, CancelEventArgs e)
    {
      if (!(Form1.strFormType == "ADD") || !(this.tbxCustomerName.Text.Trim() != ""))
        return;
      string nextCustomerCode = CustomersClass.getNextCustomerCode(this.tbxCustomerName.Text.Trim()[0]);
      if (nextCustomerCode != "")
      {
        this.tbxCustomerCode.Text = nextCustomerCode;
      }
      else
      {
        int num = (int) MessageBox.Show("ERror. Please Enter Name Correctly");
      }
      if (this.tbxCustomerName.Text.Contains("S/O"))
        this.tbxSex.Text = "MALE";
      else if (this.tbxCustomerName.Text.Contains("D/O") | this.tbxCustomerName.Text.Contains("W/O"))
        this.tbxSex.Text = "FEMALE";
      else
        this.tbxSex.Text = "MALE";
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "customerPhoto").ShowDialog();
        try
        {
          if (!File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      else
        this.tbxCustomerName.Select();
    }

    private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      DataTable cityAndPincode = LocationAndPincodeClass.getCityAndPincode(this.cbLocation.Text);
      if (cityAndPincode == null || cityAndPincode.Rows.Count <= 0)
        return;
      this.tbxCity.Text = cityAndPincode.Rows[0]["City"].ToString();
      this.tbxPincode.Text = cityAndPincode.Rows[0]["Pincode"].ToString();
    }

    private void pcbLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      DataTable cityAndPincode = LocationAndPincodeClass.getCityAndPincode(this.pcbLocation.Text);
      if (cityAndPincode == null || cityAndPincode.Rows.Count <= 0)
        return;
      this.ptbxCity.Text = cityAndPincode.Rows[0]["City"].ToString();
      this.ptbxPincode.Text = cityAndPincode.Rows[0]["Pincode"].ToString();
    }

    private void tbxName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return | e.KeyCode == Keys.Down)
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

    private void tbxFatherName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        this.dgvFatherNameSearch.Visible = false;
      }
      else if (e.KeyCode == Keys.Down)
      {
        if (this.dgvFatherNameSearch.Visible && this.dgvFatherNameSearch != null && this.dgvFatherNameSearch.Rows.Count > 0)
        {
          this.dgvFatherNameSearch.Select();
          this.dgvFatherNameSearch.Rows[0].Selected = true;
          this.dgvFatherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        else
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void tbxMotherName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        this.dgvMotherNameSearch.Visible = false;
      }
      else if (e.KeyCode == Keys.Down)
      {
        if (this.dgvMotherNameSearch.Visible && this.dgvMotherNameSearch != null && this.dgvMotherNameSearch.Rows.Count > 0)
        {
          this.dgvMotherNameSearch.Select();
          this.dgvMotherNameSearch.Rows[0].Selected = true;
          this.dgvMotherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        else
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void tbxSpouseName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        this.dgvSpouseNameSearch.Visible = false;
      }
      else if (e.KeyCode == Keys.Down)
      {
        if (this.dgvSpouseNameSearch.Visible && this.dgvSpouseNameSearch != null && this.dgvSpouseNameSearch.Rows.Count > 0)
        {
          this.dgvSpouseNameSearch.Select();
          this.dgvSpouseNameSearch.Rows[0].Selected = true;
          this.dgvSpouseNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        else
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void tbxContactNo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return | e.KeyCode == Keys.Down)
      {
        if (this.tbxPhone.Text.Trim().Count<char>() == 0 | this.tbxPhone.Text.Trim().Count<char>() == 10)
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
        else
          this.tbxPhone.Select();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private bool checkifCustomerAlreadyAdded()
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (FormMain.RemindIfNameAndAddressSame)
      {
        my_querry = "select * from tblcustomers where Cname = @Cname AND CAddr1 = @CAddr1";
        parameters.Add(new OleDbParameter("Cname", (object) this.tbxCustomerName.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim().ToString()));
      }
      else
      {
        if (!FormMain.RemindIfNameAddressAndDoorNumberSame)
          return false;
        my_querry = "select * from tblcustomers where Cname = @Cname AND CAddr1 = @CAddr1 AND CNo = @CNo ";
        parameters.Add(new OleDbParameter("Cname", (object) this.tbxCustomerName.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CNo", (object) this.tbxDoorNumber.Text.Trim().ToString()));
      }
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form add customer.checkIfcustomerAlreadyAdded" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (DialogResult.Yes == MessageBox.Show("Customer With the same name and address already exists...View details???", "Duplicate Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num = (int) new FormViewCustomerDetails(dataTable2.Rows[0]["Cid"].ToString()).ShowDialog();
        }
        return true;
      }
      return false;
    }

    private void tbxAddr1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxAddr1.Text.Trim() != ""))
        return;
      DataTable tableWhereAddr1Is = CustomersClass.getDataTableWhereAddr1Is(this.tbxAddr1.Text);
      if (tableWhereAddr1Is != null && tableWhereAddr1Is.Rows.Count > 0)
      {
        this.tbxAddr2.Text = tableWhereAddr1Is.Rows[0]["caddr2"].ToString();
        if (this.cbLocation.Items.Contains((object) tableWhereAddr1Is.Rows[0]["caddr3"].ToString()))
          this.cbLocation.Text = tableWhereAddr1Is.Rows[0]["caddr3"].ToString();
      }
    }

    private void tbxDoorNumber_Enter(object sender, EventArgs e) => (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;

    private void cbLocation_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbLocation.Text == "")
        this.getDefaultLocation();
      else if (!(this.cbLocation.Text != "") || !this.cbLocation.Items.Contains((object) this.cbLocation.Text))
      {
        if (DialogResult.Yes == MessageBox.Show("New Location. ADD ?", "New Location.Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num = (int) new FormLocation(this.cbLocation.Text).ShowDialog();
          this.getDefaultLocation();
          this.cbLocation.Select();
        }
        else
          this.cbLocation.Select();
      }
    }

    private void tbxPhone_Validated(object sender, EventArgs e)
    {
      if (!(Form1.strFormType == "ADD") || !(this.tbxPhone.Text.Trim() != ""))
        return;
      string idBelongingToThis = CustomersClass.getTheCustomerIdBelongingToThis(this.tbxPhone.Text);
      if (idBelongingToThis != "")
      {
        this.tbxPhone.ForeColor = Color.Red;
        if (DialogResult.Yes == MessageBox.Show("Do you want to see the customer with the same phone number?", "Customer with same phone number exists...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          new FormCustomerNew(idBelongingToThis).Show();
      }
      else
        this.tbxPhone.ForeColor = Color.Black;
    }

    private void fatherMotherSpouse_keyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxFatherNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxFatherNameSearch.Text != "")
        this.getFatherNames();
      else
        this.dgvFatherNameSearch.Visible = false;
    }

    private void tbxMotherNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxMotherNameSearch.Text != "")
        this.getMotherNames();
      else
        this.dgvMotherNameSearch.Visible = false;
    }

    private void tbxSpouseNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxSpouseNameSearch.Text != "")
        this.getSpouseNames();
      else
        this.dgvSpouseNameSearch.Visible = false;
    }

    private void dgvMotherNameSearch_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvMotherNameSearch.Rows[0].Selected)
          this.tbxMotherNameSearch.Select();
        if (e.KeyCode != Keys.Return)
          return;
        if (this.dgvMotherNameSearch.CurrentRow != null)
        {
          int index = this.dgvMotherNameSearch.CurrentRow.Index;
          this.tbxMotherCode.Text = this.dgvMotherNameSearch.Rows[index].Cells["CID"].Value.ToString();
          if (this.tbxFatherCode.Text == this.tbxMotherCode.Text)
          {
            this.tbxFatherCode.Text = "";
            this.tbxFatherName.Text = "";
          }
          if (this.tbxSpouseCode.Text == this.tbxMotherCode.Text)
          {
            this.tbxSpouseCode.Text = "";
            this.tbxSpouseName.Text = "";
          }
          this.tbxMotherName.Text = this.dgvMotherNameSearch.Rows[index].Cells["CID"].Value.ToString() + "-" + this.dgvMotherNameSearch.Rows[index].Cells["CName"].Value.ToString();
          this.dgvMotherNameSearch.Visible = false;
          this.tbxSpouseNameSearch.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dgvSpouseNameSearch_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvSpouseNameSearch.Rows[0].Selected)
          this.tbxSpouseNameSearch.Select();
        if (e.KeyCode != Keys.Return)
          return;
        if (this.dgvSpouseNameSearch.CurrentRow != null)
        {
          int index = this.dgvSpouseNameSearch.CurrentRow.Index;
          this.tbxSpouseCode.Text = this.dgvSpouseNameSearch.Rows[index].Cells["CID"].Value.ToString();
          if (this.tbxFatherCode.Text == this.tbxSpouseCode.Text)
          {
            this.tbxFatherCode.Text = "";
            this.tbxFatherName.Text = "";
          }
          if (this.tbxMotherCode.Text == this.tbxSpouseCode.Text)
          {
            this.tbxMotherCode.Text = "";
            this.tbxMotherName.Text = "";
          }
          this.tbxSpouseName.Text = this.dgvSpouseNameSearch.Rows[index].Cells["CID"].Value.ToString() + "-" + this.dgvSpouseNameSearch.Rows[index].Cells["CName"].Value.ToString();
          DataTable customerDetails = CustomersClass.getCustomerDetails(this.tbxSpouseCode.Text);
          if (customerDetails != null && customerDetails.Rows.Count > 0 && this.tbxAddr1.Text.Trim() == "")
          {
            this.tbxDoorNumber.Text = customerDetails.Rows[0]["CNo"].ToString();
            this.tbxAddr1.Text = customerDetails.Rows[0]["CAddr1"].ToString();
            this.tbxAddr2.Text = customerDetails.Rows[0]["CAddr2"].ToString();
            this.cbLocation.Text = customerDetails.Rows[0]["CAddr3"].ToString();
          }
          this.dgvSpouseNameSearch.Visible = false;
          this.tbxIntroducedBy.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnFatherNameClear_Click(object sender, EventArgs e)
    {
      this.tbxFatherCode.Text = "";
      this.tbxFatherName.Text = "";
    }

    private void btnMotherNameClear_Click(object sender, EventArgs e)
    {
      this.tbxMotherCode.Text = "";
      this.tbxMotherName.Text = "";
    }

    private void btnSpouseNameClear_Click(object sender, EventArgs e)
    {
      this.tbxSpouseCode.Text = "";
      this.tbxSpouseName.Text = "";
    }

    private void dgvCustomerDetails_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up && this.dgvFatherNameSearch.Rows[0].Selected)
          this.tbxFatherNameSearch.Select();
        if (e.KeyCode != Keys.Return)
          return;
        if (this.dgvFatherNameSearch.CurrentRow != null)
        {
          int index = this.dgvFatherNameSearch.CurrentRow.Index;
          this.tbxFatherCode.Text = this.dgvFatherNameSearch.Rows[index].Cells["CID"].Value.ToString();
          if (this.tbxMotherCode.Text == this.tbxFatherCode.Text)
          {
            this.tbxMotherCode.Text = "";
            this.tbxMotherName.Text = "";
          }
          if (this.tbxSpouseCode.Text == this.tbxFatherCode.Text)
          {
            this.tbxSpouseCode.Text = "";
            this.tbxSpouseName.Text = "";
          }
          this.tbxFatherName.Text = this.dgvFatherNameSearch.Rows[index].Cells["CID"].Value.ToString() + "-" + this.dgvFatherNameSearch.Rows[index].Cells["CName"].Value.ToString();
          this.dgvFatherNameSearch.Visible = false;
          this.tbxMotherNameSearch.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getFatherNames()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxFatherNameSearch.Text + "%' or Cid like '" + this.tbxFatherNameSearch.Text + "%' and (sex <> 'FEMALE' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvFatherNameSearch.Size = new Size(740, 340);
        this.dgvFatherNameSearch.BringToFront();
        this.dgvFatherNameSearch.Visible = true;
        this.dgvFatherNameSearch.DataSource = (object) dataTable2;
        this.dgvFatherNameSearch.ClearSelection();
      }
      else
      {
        this.tbxFatherNameSearch.Text = this.tbxFatherNameSearch.Text.Substring(0, this.tbxFatherNameSearch.Text.Length - 1);
        this.tbxFatherNameSearch.Select(this.tbxFatherNameSearch.Text.Length, 0);
      }
    }

    private void getMotherNames()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxMotherNameSearch.Text + "%' or Cid like '" + this.tbxMotherNameSearch.Text + "%' and (sex <> 'MALE' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvMotherNameSearch.Size = new Size(740, 340);
        this.dgvMotherNameSearch.BringToFront();
        this.dgvMotherNameSearch.Visible = true;
        this.dgvMotherNameSearch.DataSource = (object) dataTable2;
        this.dgvMotherNameSearch.ClearSelection();
      }
      else
      {
        this.tbxMotherNameSearch.Text = this.tbxMotherNameSearch.Text.Substring(0, this.tbxMotherNameSearch.Text.Length - 1);
        this.tbxMotherNameSearch.Select(this.tbxMotherNameSearch.Text.Length, 0);
      }
    }

    private string oppositeOfSex(string sex)
    {
      switch (sex)
      {
        case "MALE":
          return "FEMALE";
        case "FEMALE":
          return "MALE";
        default:
          return "";
      }
    }

    private void getSpouseNames()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxSpouseNameSearch.Text + "%' or Cid like '" + this.tbxSpouseNameSearch.Text + "%' and (sex <> '" + this.tbxSex.Text + "' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.dgvSpouseNameSearch.Size = new Size(740, 340);
        this.dgvSpouseNameSearch.BringToFront();
        this.dgvSpouseNameSearch.Visible = true;
        this.dgvSpouseNameSearch.DataSource = (object) dataTable2;
        this.dgvSpouseNameSearch.ClearSelection();
      }
      else
      {
        this.tbxSpouseNameSearch.Text = this.tbxSpouseNameSearch.Text.Substring(0, this.tbxSpouseNameSearch.Text.Length - 1);
        this.tbxSpouseNameSearch.Select(this.tbxSpouseNameSearch.Text.Length, 0);
      }
    }

    private void takeFingerPrint()
    {
      if (!double.TryParse(CustomersClass.getMaxId().ToString(), NumberStyles.Integer, (IFormatProvider) CultureInfo.CurrentCulture, out double _))
      {
        int num1 = (int) MessageBox.Show("Please enter number for user id.");
      }
      else
      {
        byte[] numArray = new byte[FormMain.m_ImageWidth * FormMain.m_ImageHeight];
        int imageEx = FormMain.m_FPM.GetImageEx(numArray, 10000, this.pbFingerPrint.Handle.ToInt32(), 50);
        MemoryStream memoryStream = new MemoryStream();
        byte[] buffer = numArray;
        try
        {
          memoryStream.Write(buffer, 0, Convert.ToInt32(buffer.Length));
          Bitmap bitmap = new Bitmap((Stream) memoryStream, false);
          memoryStream.Dispose();
          this.pbFingerPrint.Image = (Image) bitmap;
          this.pbFingerPrint.Image.Save(FormMain.startUpPath + "photos\\fingerprints\\" + this.tbxCustomerCode.Text + ".png");
        }
        catch (Exception ex)
        {
          throw;
        }
        if (imageEx != 0)
        {
          int num2 = (int) MessageBox.Show("Image Capture Error: " + Convert.ToString(imageEx));
        }
        else
        {
          this.minData = new byte[400];
          int template = FormMain.m_FPM.CreateTemplate(numArray, this.minData);
          if (template != 0)
          {
            int num3 = (int) MessageBox.Show("Get Minutiae Error: " + Convert.ToString(template));
          }
          else
          {
            this.idInfo = new SS_IDInfo();
            this.idInfo.ID = Convert.ToInt32(CustomersClass.getMaxId());
            this.idInfo.FingerNumber = (byte) 1;
            this.idInfo.SampleNumber = Convert.ToByte(1);
            SS_IDInfo basedOnFingerPrint = FingerPrintClass.getCustomerIdBasedOnFingerPrint(this.minData);
            if (basedOnFingerPrint == null || !(basedOnFingerPrint.ID.ToString() != "0"))
              return;
            int num4 = (int) MessageBox.Show("fingerprint already exits");
            this.minData = (byte[]) null;
          }
        }
      }
    }

    public void ByteToImage(byte[] blob)
    {
      MemoryStream memoryStream = new MemoryStream();
      byte[] buffer = blob;
      try
      {
        memoryStream.Write(buffer, 0, Convert.ToInt32(buffer.Length));
        Bitmap bitmap = new Bitmap((Stream) memoryStream, false);
        memoryStream.Dispose();
        this.pbFingerPrint.Image = (Image) bitmap;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    protected override void WndProc(ref Message message)
    {
      if (message.Msg == 33024)
      {
        if (message.WParam.ToInt32() == 1)
          this.takeFingerPrint();
        else if (message.WParam.ToInt32() != 0)
          ;
      }
      base.WndProc(ref message);
    }

    private void llTakeFingerPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.takeFingerPrint();

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Form openForm = Application.OpenForms["FormMain"];
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) openForm.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void llSelectCustomerPhoto_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
      openFileDialog.Title = "Select the picture";
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        if (openFileDialog.CheckFileExists)
        {
          string destFileName = FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text + ".png";
          File.Copy(openFileDialog.FileName, destFileName, true);
          string empty = string.Empty;
        }
        else
        {
          int num = (int) MessageBox.Show("file does not exist");
        }
      }
      if (!File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        return;
      using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
      {
        this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void tbxCustomerName_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar))
        return;
      e.Handled = true;
    }

    private void Form1_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        if (!this.photoTaken || !File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void button4_Enter(object sender, EventArgs e) => this.btnNext.BackColor = Color.Gray;

    private void button3_Enter(object sender, EventArgs e) => this.btnNext.BackColor = Color.Gray;

    private void btnNext_Leave(object sender, EventArgs e) => this.btnNext.BackColor = Color.Transparent;

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (!this.checkIfPersonalDetailsEntered())
        return;
      this.btnResidentialAddress.PerformClick();
    }

    private void ptbxAddr1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.ptbxAddr1.Text.Trim() != ""))
        return;
      DataTable tableWhereAddr1Is = CustomersClass.getDataTableWhereAddr1Is(this.ptbxAddr1.Text);
      if (tableWhereAddr1Is != null && tableWhereAddr1Is.Rows.Count > 0)
      {
        this.ptbxAddr2.Text = tableWhereAddr1Is.Rows[0]["caddr2"].ToString();
        if (this.pcbLocation.Items.Contains((object) tableWhereAddr1Is.Rows[0]["caddr3"].ToString()))
          this.pcbLocation.Text = tableWhereAddr1Is.Rows[0]["caddr3"].ToString();
      }
    }

    private void pcbLocation_Validating(object sender, CancelEventArgs e)
    {
      if (this.pcbLocation.Text == "")
      {
        this.ptbxCity.Text = "";
        this.ptbxPincode.Text = "";
      }
      else if (!(this.pcbLocation.Text != "") || !this.pcbLocation.Items.Contains((object) this.pcbLocation.Text))
      {
        if (DialogResult.Yes == MessageBox.Show("New Location. ADD ?", "New Location.Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num = (int) new FormLocation(this.pcbLocation.Text).ShowDialog();
          this.getDefaultLocationp();
          this.pcbLocation.Select();
        }
        else
          this.pcbLocation.Select();
      }
    }

    private void btnPrevious_Click(object sender, EventArgs e) => this.btnPersonalDetails.PerformClick();

    private void btnSave2_Click(object sender, EventArgs e)
    {
      switch (Form1.strFormType)
      {
        case "ADD":
          this.save();
          break;
        case "EDIT":
          this.update();
          break;
      }
    }

    private void tbxFatherCode_TextChanged(object sender, EventArgs e)
    {
      if (!(Form1.strFormType == "EDIT"))
        return;
      this.tbxFatherName.Text = this.tbxFatherCode.Text + "-" + CustomersClass.getName(this.tbxFatherCode.Text);
    }

    private void tbxMotherCode_TextChanged(object sender, EventArgs e)
    {
      if (!(Form1.strFormType == "EDIT"))
        return;
      this.tbxMotherName.Text = this.tbxMotherCode.Text + "-" + CustomersClass.getName(this.tbxMotherCode.Text);
    }

    private void tbxSpouseCode_TextChanged(object sender, EventArgs e)
    {
      if (!(Form1.strFormType == "EDIT"))
        return;
      this.tbxSpouseName.Text = this.tbxSpouseCode.Text + "-" + CustomersClass.getName(this.tbxSpouseCode.Text);
    }

    private void save()
    {
      try
      {
        if (!this.checkIfPersonalDetailsEntered() || !this.checkIfAddressDetailsCorrectlyAdded() || !this.checkIfPermanentAddressDetailsCorrectlyAdded() || this.checkifCustomerAlreadyAdded())
          return;
        if (!CustomersClass.checkifCustomerAlreadyExists(this.tbxCustomerCode.Text))
        {
          if (FormMain.UseFingerPrint && this.minData != null)
          {
            string customerCode = this.tbxCustomerCode.Text.Trim();
            string CustomerName = this.tbxCustomerName.Text.Trim();
            DateTime now;
            string Dob;
            if (!(this.tbxDob.Text.Trim() == "/  /"))
            {
              now = DateTime.Parse(this.tbxDob.Text.Trim());
              Dob = now.ToString("dd/MM/yyyy");
            }
            else
              Dob = "";
            string text1 = this.tbxSex.Text;
            string CPhone = this.tbxPhone.Text.Trim();
            string AlternateNumber = this.tbxAlternateNumber.Text.Trim();
            string Notes = this.tbxNotes.Text.Trim();
            string EmaildId = this.tbxEmail.Text.Trim();
            string Occupation = this.tbxOccupation.Text.Trim();
            string Fathername = this.tbxFatherCode.Text.Trim();
            string MotherName = this.tbxMotherCode.Text.Trim();
            string SpouseName = this.tbxSpouseCode.Text.Trim();
            string IntroducedBy = this.tbxIntroducedBy.Text.Trim();
            string MaritalStatus = this.tbxMaritalStatus.Text.Trim();
            string Education = this.tbxEducation.Text.Trim();
            string Religion = this.tbxReligion.Text.Trim();
            string InterestRate = this.tbxInterestRAte.Text.Trim();
            string CNo = this.tbxDoorNumber.Text.Trim();
            string CAddr1 = this.tbxAddr1.Text.Trim();
            string Caddr2 = this.tbxAddr2.Text.Trim();
            string CAddr3 = this.cbLocation.Text.Trim();
            string City = this.tbxCity.Text.Trim();
            string Pincode = this.tbxPincode.Text.Trim();
            string Landmark = this.tbxLandMark.Text.Trim();
            string HouseType = this.cbHouseType.Text.Trim();
            string OwnerShip = this.cbOwnerShip.Text.Trim();
            string text2 = this.ptbxDoorNumber.Text;
            string text3 = this.ptbxAddr1.Text;
            string pCaddr2 = this.ptbxAddr2.Text.Trim();
            string pCAddr3 = this.pcbLocation.Text.Trim();
            string pCity = this.ptbxCity.Text.Trim();
            string pPincode = this.ptbxPincode.Text.Trim();
            string pLandmark = this.ptbxLandMark.Text.Trim();
            string pHouseType = this.pcbHouseType.Text.Trim();
            string pOwnerShip = this.pcbOwnerShip.Text.Trim();
            string AadharNumber = this.tbxAadharNumber.Text.Trim();
            string PanCard = this.tbxPanCard.Text.Trim();
            string VoterId = this.tbxVoterId.Text.Trim();
            string DrivingLicense = this.tbxDrivingLicense.Text.Trim();
            string RationCard = this.tbxRationCard.Text.Trim();
            string Others = this.tbxOthers.Text.Trim();
            string username = FormMain.username;
            now = DateTime.Now;
            string CreatedOn = now.ToString();
            byte[] minData = this.minData;
            int fingerNumber = (int) this.idInfo.FingerNumber;
            int sampleNumber = (int) this.idInfo.SampleNumber;
            string text4 = CustomersClass.SaveNewWithFingerPrint(customerCode, CustomerName, Dob, text1, CPhone, AlternateNumber, Notes, EmaildId, Occupation, Fathername, MotherName, SpouseName, IntroducedBy, MaritalStatus, Education, Religion, InterestRate, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Landmark, HouseType, OwnerShip, text2, text3, pCaddr2, pCAddr3, pCity, pPincode, pLandmark, pHouseType, pOwnerShip, AadharNumber, PanCard, VoterId, DrivingLicense, RationCard, Others, username, CreatedOn, minData, fingerNumber, sampleNumber);
            if (text4 == "Done")
            {
              FormMain.m_SecuSearch.RegisterFP(this.minData, this.idInfo);
            }
            else
            {
              int num = (int) MessageBox.Show(text4);
            }
          }
          else
          {
            string customerCode = this.tbxCustomerCode.Text.Trim();
            string CustomerName = this.tbxCustomerName.Text.Trim();
            DateTime now;
            string Dob;
            if (!(this.tbxDob.Text.Trim() == "/  /"))
            {
              now = DateTime.Parse(this.tbxDob.Text.Trim());
              Dob = now.ToString("dd/MM/yyyy");
            }
            else
              Dob = "";
            string text5 = this.tbxSex.Text;
            string CPhone = this.tbxPhone.Text.Trim();
            string AlternateNumber = this.tbxAlternateNumber.Text.Trim();
            string Notes = this.tbxNotes.Text.Trim();
            string EmaildId = this.tbxEmail.Text.Trim();
            string Occupation = this.tbxOccupation.Text.Trim();
            string Fathername = this.tbxFatherCode.Text.Trim();
            string MotherName = this.tbxMotherCode.Text.Trim();
            string SpouseName = this.tbxSpouseCode.Text.Trim();
            string IntroducedBy = this.tbxIntroducedBy.Text.Trim();
            string MaritalStatus = this.tbxMaritalStatus.Text.Trim();
            string Education = this.tbxEducation.Text.Trim();
            string Religion = this.tbxReligion.Text.Trim();
            string InterestRate = this.tbxInterestRAte.Text.Trim();
            string CNo = this.tbxDoorNumber.Text.Trim();
            string CAddr1 = this.tbxAddr1.Text.Trim();
            string Caddr2 = this.tbxAddr2.Text.Trim();
            string CAddr3 = this.cbLocation.Text.Trim();
            string City = this.tbxCity.Text.Trim();
            string Pincode = this.tbxPincode.Text.Trim();
            string Landmark = this.tbxLandMark.Text.Trim();
            string HouseType = this.cbHouseType.Text.Trim();
            string OwnerShip = this.cbOwnerShip.Text.Trim();
            string text6 = this.ptbxDoorNumber.Text;
            string text7 = this.ptbxAddr1.Text;
            string pCaddr2 = this.ptbxAddr2.Text.Trim();
            string pCAddr3 = this.pcbLocation.Text.Trim();
            string pCity = this.ptbxCity.Text.Trim();
            string pPincode = this.ptbxPincode.Text.Trim();
            string pLandmark = this.ptbxLandMark.Text.Trim();
            string pHouseType = this.pcbHouseType.Text.Trim();
            string pOwnerShip = this.pcbOwnerShip.Text.Trim();
            string AadharNumber = this.tbxAadharNumber.Text.Trim();
            string PanCard = this.tbxPanCard.Text.Trim();
            string VoterId = this.tbxVoterId.Text.Trim();
            string DrivingLicense = this.tbxDrivingLicense.Text.Trim();
            string RationCard = this.tbxRationCard.Text.Trim();
            string Others = this.tbxOthers.Text.Trim();
            string username = FormMain.username;
            now = DateTime.Now;
            string CreatedOn = now.ToString();
            if (CustomersClass.SaveNew(customerCode, CustomerName, Dob, text5, CPhone, AlternateNumber, Notes, EmaildId, Occupation, Fathername, MotherName, SpouseName, IntroducedBy, MaritalStatus, Education, Religion, InterestRate, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Landmark, HouseType, OwnerShip, text6, text7, pCaddr2, pCAddr3, pCity, pPincode, pLandmark, pHouseType, pOwnerShip, AadharNumber, PanCard, VoterId, DrivingLicense, RationCard, Others, username, CreatedOn) == "Done")
            {
              if (this.tbxSpouseCode.Text != "")
                CustomersClass.updateRelation("SpouseName", this.tbxSpouseCode.Text, this.tbxCustomerCode.Text);
              Form1.newCustomerCodeAdde = this.tbxCustomerCode.Text;
              this.copyPhotos();
              Form1.newCustomerCodeAdde = this.tbxCustomerCode.Text;
              this.Dispose();
              this.Close();
            }
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("ERror. ...Retry");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.btnsaveandclose_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void copyPhotos()
    {
      if (File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\AadharBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\AadharBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\AadharBack\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\AadharFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\AadharFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\AadharFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\DrivingLicenseBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\DrivingLicenseBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\DrivingLicenseBack\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\PanCardBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\PanCardBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\PanCardBack\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\PanCardFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\PanCardFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\PanCardFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\RationCardBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\RationCardBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\RationCardBack\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\RationCardFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\RationCardFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\RationCardFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\DrivingLicenseFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\DrivingLicenseFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\DrivingLicenseFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\VoterIdFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\VoterIdFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\VoterIdFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\VoterIdBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\VoterIdBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\VoterIdBack" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        File.Copy(FormMain.startUpPath + "Photos\\OthersFront\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      if (!File.Exists(FormMain.startUpPath + "Photos\\OthersBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        return;
      File.Copy(FormMain.startUpPath + "Photos\\OthersBack\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\OthersBack\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
    }

    private void update()
    {
      try
      {
        if ((int) this.tbxCustomerCode.Text[0] == (int) this.tbxCustomerName.Text[0])
        {
          if (!this.checkIfPersonalDetailsEntered() || !this.checkIfAddressDetailsCorrectlyAdded() || !this.checkIfPermanentAddressDetailsCorrectlyAdded() || this.checkifCustomerAlreadyAdded())
            return;
          if (CustomersClass.checkifCustomerAlreadyExists(this.tbxCustomerCode.Text))
          {
            DateTime now;
            if (FormMain.UseFingerPrint && this.minData != null)
            {
              string customerCode = this.tbxCustomerCode.Text.Trim();
              string CustomerName = this.tbxCustomerName.Text.Trim();
              string Dob;
              if (!(this.tbxDob.Text.Trim() == "/  /"))
              {
                now = DateTime.Parse(this.tbxDob.Text.Trim());
                Dob = now.ToString("dd/MM/yyyy");
              }
              else
                Dob = "";
              string text1 = this.tbxSex.Text;
              string CPhone = this.tbxPhone.Text.Trim();
              string AlternateNumber = this.tbxAlternateNumber.Text.Trim();
              string Notes = this.tbxNotes.Text.Trim();
              string EmaildId = this.tbxEmail.Text.Trim();
              string Occupation = this.tbxOccupation.Text.Trim();
              string Fathername = this.tbxFatherCode.Text.Trim();
              string MotherName = this.tbxMotherCode.Text.Trim();
              string SpouseName = this.tbxSpouseCode.Text.Trim();
              string IntroducedBy = this.tbxIntroducedBy.Text.Trim();
              string MaritalStatus = this.tbxMaritalStatus.Text.Trim();
              string Education = this.tbxEducation.Text.Trim();
              string Religion = this.tbxReligion.Text.Trim();
              string InterestRate = this.tbxInterestRAte.Text.Trim();
              string CNo = this.tbxDoorNumber.Text.Trim();
              string CAddr1 = this.tbxAddr1.Text.Trim();
              string Caddr2 = this.tbxAddr2.Text.Trim();
              string CAddr3 = this.cbLocation.Text.Trim();
              string City = this.tbxCity.Text.Trim();
              string Pincode = this.tbxPincode.Text.Trim();
              string Landmark = this.tbxLandMark.Text.Trim();
              string HouseType = this.cbHouseType.Text.Trim();
              string OwnerShip = this.cbOwnerShip.Text.Trim();
              string text2 = this.ptbxDoorNumber.Text;
              string text3 = this.ptbxAddr1.Text;
              string pCaddr2 = this.ptbxAddr2.Text.Trim();
              string pCAddr3 = this.pcbLocation.Text.Trim();
              string pCity = this.ptbxCity.Text.Trim();
              string pPincode = this.ptbxPincode.Text.Trim();
              string pLandmark = this.ptbxLandMark.Text.Trim();
              string pHouseType = this.pcbHouseType.Text.Trim();
              string pOwnerShip = this.pcbOwnerShip.Text.Trim();
              string AadharNumber = this.tbxAadharNumber.Text.Trim();
              string PanCard = this.tbxPanCard.Text.Trim();
              string VoterId = this.tbxVoterId.Text.Trim();
              string DrivingLicense = this.tbxDrivingLicense.Text.Trim();
              string RationCard = this.tbxRationCard.Text.Trim();
              string Others = this.tbxOthers.Text.Trim();
              string username = FormMain.username;
              now = DateTime.Now;
              string CreatedOn = now.ToString();
              byte[] minData = this.minData;
              int fingerNumber = (int) this.idInfo.FingerNumber;
              int sampleNumber = (int) this.idInfo.SampleNumber;
              string text4 = CustomersClass.UpdateCustomerWithFingerPrint(customerCode, CustomerName, Dob, text1, CPhone, AlternateNumber, Notes, EmaildId, Occupation, Fathername, MotherName, SpouseName, IntroducedBy, MaritalStatus, Education, Religion, InterestRate, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Landmark, HouseType, OwnerShip, text2, text3, pCaddr2, pCAddr3, pCity, pPincode, pLandmark, pHouseType, pOwnerShip, AadharNumber, PanCard, VoterId, DrivingLicense, RationCard, Others, username, CreatedOn, minData, fingerNumber, sampleNumber);
              if (text4 == "Done")
              {
                FormMain.m_SecuSearch.RegisterFP(this.minData, this.idInfo);
                if (this.tbxSpouseCode.Text != "")
                  CustomersClass.updateRelation("SpouseName", this.tbxSpouseCode.Text, this.tbxCustomerCode.Text);
                this.copyPhotos();
              }
              else
              {
                int num = (int) MessageBox.Show(text4);
              }
            }
            else
            {
              string customerCode = this.tbxCustomerCode.Text.Trim();
              string CustomerName = this.tbxCustomerName.Text.Trim();
              string Dob;
              if (!(this.tbxDob.Text.Trim() == "/  /"))
              {
                now = DateTime.Parse(this.tbxDob.Text.Trim());
                Dob = now.ToString("dd/MM/yyyy");
              }
              else
                Dob = "";
              string text5 = this.tbxSex.Text;
              string CPhone = this.tbxPhone.Text.Trim();
              string AlternateNumber = this.tbxAlternateNumber.Text.Trim();
              string Notes = this.tbxNotes.Text.Trim();
              string EmaildId = this.tbxEmail.Text.Trim();
              string Occupation = this.tbxOccupation.Text.Trim();
              string Fathername = this.tbxFatherCode.Text.Trim();
              string MotherName = this.tbxMotherCode.Text.Trim();
              string SpouseName = this.tbxSpouseCode.Text.Trim();
              string IntroducedBy = this.tbxIntroducedBy.Text.Trim();
              string MaritalStatus = this.tbxMaritalStatus.Text.Trim();
              string Education = this.tbxEducation.Text.Trim();
              string Religion = this.tbxReligion.Text.Trim();
              string InterestRate = this.tbxInterestRAte.Text.Trim();
              string CNo = this.tbxDoorNumber.Text.Trim();
              string CAddr1 = this.tbxAddr1.Text.Trim();
              string Caddr2 = this.tbxAddr2.Text.Trim();
              string CAddr3 = this.cbLocation.Text.Trim();
              string City = this.tbxCity.Text.Trim();
              string Pincode = this.tbxPincode.Text.Trim();
              string Landmark = this.tbxLandMark.Text.Trim();
              string HouseType = this.cbHouseType.Text.Trim();
              string OwnerShip = this.cbOwnerShip.Text.Trim();
              string text6 = this.ptbxDoorNumber.Text;
              string text7 = this.ptbxAddr1.Text;
              string pCaddr2 = this.ptbxAddr2.Text.Trim();
              string pCAddr3 = this.pcbLocation.Text.Trim();
              string pCity = this.ptbxCity.Text.Trim();
              string pPincode = this.ptbxPincode.Text.Trim();
              string pLandmark = this.ptbxLandMark.Text.Trim();
              string pHouseType = this.pcbHouseType.Text.Trim();
              string pOwnerShip = this.pcbOwnerShip.Text.Trim();
              string AadharNumber = this.tbxAadharNumber.Text.Trim();
              string PanCard = this.tbxPanCard.Text.Trim();
              string VoterId = this.tbxVoterId.Text.Trim();
              string DrivingLicense = this.tbxDrivingLicense.Text.Trim();
              string RationCard = this.tbxRationCard.Text.Trim();
              string Others = this.tbxOthers.Text.Trim();
              string username = FormMain.username;
              now = DateTime.Now;
              string CreatedOn = now.ToString();
              if (CustomersClass.UpdateCustomer(customerCode, CustomerName, Dob, text5, CPhone, AlternateNumber, Notes, EmaildId, Occupation, Fathername, MotherName, SpouseName, IntroducedBy, MaritalStatus, Education, Religion, InterestRate, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Landmark, HouseType, OwnerShip, text6, text7, pCaddr2, pCAddr3, pCity, pPincode, pLandmark, pHouseType, pOwnerShip, AadharNumber, PanCard, VoterId, DrivingLicense, RationCard, Others, username, CreatedOn) == "Done")
              {
                if (this.tbxSpouseCode.Text != "")
                  CustomersClass.updateRelation("SpouseName", this.tbxSpouseCode.Text, this.tbxCustomerCode.Text);
                this.copyPhotos();
              }
            }
            string ActionDetails = "New Customer " + this.tbxCustomerCode.Text.Trim().ToString() + " Added";
            string username1 = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("AddCustomer", ActionDetails, "", "", username1, PerformedOn);
            Form1.newCustomerCodeAdde = this.tbxCustomerCode.Text;
            this.Dispose();
            this.Close();
          }
          else if (this.tbxCustomerName.Text.Trim() != "")
          {
            string nextCustomerCode = CustomersClass.getNextCustomerCode(this.tbxCustomerName.Text.Trim()[0]);
            if (nextCustomerCode != "")
            {
              this.tbxCustomerCode.Text = nextCustomerCode;
            }
            else
            {
              int num = (int) MessageBox.Show("ERror. Please Enter Name Correctly");
            }
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Customer Name Should start with" + this.tbxCustomerCode.Text[0].ToString());
          this.tbxCustomerName.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.btnsaveandclose_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkIfAddressDetailsCorrectlyAdded()
    {
      if (this.tbxDoorNumber.Text.Trim() != "")
      {
        if (this.tbxAddr1.Text.Trim() != "")
        {
          if (this.cbLocation.Text.Trim() != "" && this.cbLocation.Items.Contains((object) this.cbLocation.Text))
          {
            if (this.tbxCity.Text.Trim() != "")
            {
              if (this.tbxPincode.Text.Trim() != "")
                return true;
              this.tpResidentialAddress.Show();
              this.tpResidentialAddress.BringToFront();
              this.tbxPincode.Select();
              return false;
            }
            this.tpResidentialAddress.Show();
            this.tpResidentialAddress.BringToFront();
            this.tbxCity.Select();
            return false;
          }
          this.tpResidentialAddress.Show();
          this.tpResidentialAddress.BringToFront();
          this.getDefaultLocation();
          this.cbLocation.Select();
          return false;
        }
        this.tpResidentialAddress.Show();
        this.tpResidentialAddress.BringToFront();
        this.tbxAddr1.Select();
        return false;
      }
      this.tpResidentialAddress.Show();
      this.tpResidentialAddress.BringToFront();
      this.tbxDoorNumber.Select();
      return false;
    }

    private bool checkIfPermanentAddressDetailsCorrectlyAdded()
    {
      if (!(this.ptbxAddr1.Text != ""))
        return true;
      if (this.ptbxDoorNumber.Text.Trim() != "")
      {
        if (this.ptbxAddr1.Text.Trim() != "")
        {
          if (this.pcbLocation.Text.Trim() != "" && this.pcbLocation.Items.Contains((object) this.pcbLocation.Text))
          {
            if (this.ptbxCity.Text.Trim() != "")
            {
              if (this.ptbxPincode.Text.Trim() != "")
                return true;
              this.tpResidentialAddress.Show();
              this.tpResidentialAddress.BringToFront();
              this.ptbxPincode.Select();
              return false;
            }
            this.tpResidentialAddress.Show();
            this.tpResidentialAddress.BringToFront();
            this.ptbxCity.Select();
            return false;
          }
          this.tpResidentialAddress.Show();
          this.tpResidentialAddress.BringToFront();
          this.getDefaultLocationp();
          this.pcbLocation.Select();
          return false;
        }
        this.tpResidentialAddress.Show();
        this.tpResidentialAddress.BringToFront();
        this.ptbxAddr1.Select();
        return false;
      }
      this.tpResidentialAddress.Show();
      this.tpResidentialAddress.BringToFront();
      this.ptbxDoorNumber.Select();
      return false;
    }

    private void ProofsSeletButtonClicked_Click(object sender, EventArgs e)
    {
      string strCustomerCode = this.tbxCustomerCode.Text.Trim();
      if (!(strCustomerCode != ""))
        return;
      if ((sender as PictureBox).Name.Contains("Front"))
      {
        if ((sender as PictureBox).Name.Contains("Aadhar"))
        {
          string strFolderName = "Photos\\AadharFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (!File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbAadharFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if ((sender as PictureBox).Name.Contains("VoterId"))
        {
          string strFolderName = "Photos\\VoterIdFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (!File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbVoterIdFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if ((sender as PictureBox).Name.Contains("Pan"))
        {
          string strFolderName = "Photos\\PanCardFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (!File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbPanCardFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if ((sender as PictureBox).Name.Contains("DrivingLicense"))
        {
          string strFolderName = "Photos\\DrivingLicenseFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (!File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbDrivingLicenseFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if ((sender as PictureBox).Name.Contains("RationCard"))
        {
          string strFolderName = "Photos\\RationCardFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (!File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbRationCardFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else
        {
          if (!(sender as PictureBox).Name.Contains("Others"))
            return;
          string strFolderName = "Photos\\OthersFront\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbOthersFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
      }
      else
      {
        if (!(sender as PictureBox).Name.Contains("Back"))
          return;
        if ((sender as PictureBox).Name.Contains("Aadhar"))
        {
          string strFolderName = "Photos\\AadharBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbAadharBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        else if ((sender as PictureBox).Name.Contains("VoterId"))
        {
          string strFolderName = "Photos\\VoterIdBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbVoterIdBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        else if ((sender as PictureBox).Name.Contains("Pan"))
        {
          string strFolderName = "Photos\\PanCardBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbPanCardBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        else if ((sender as PictureBox).Name.Contains("DrivingLicense"))
        {
          string strFolderName = "Photos\\DrivingLicenseBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbDrivingLicenseBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        else if ((sender as PictureBox).Name.Contains("RationCard"))
        {
          string strFolderName = "Photos\\RationCardBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbRationCardBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        else if ((sender as PictureBox).Name.Contains("Others"))
        {
          string strFolderName = "Photos\\OthersBack\\temp\\";
          this.selectPhoto(strFolderName, strCustomerCode);
          if (File.Exists(FormMain.startUpPath + strFolderName + strCustomerCode + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFolderName + strCustomerCode + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbOthersBack.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
      }
    }

    private void selectPhoto(string strFolderName, string strCustomerCode)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
      openFileDialog.Title = "Select the picture";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      if (openFileDialog.CheckFileExists)
      {
        string destFileName = FormMain.startUpPath + strFolderName + strCustomerCode + ".png";
        File.Copy(openFileDialog.FileName, destFileName, true);
      }
      else
      {
        int num = (int) MessageBox.Show("file does not exist");
      }
    }

    private void getAllThePhotos()
    {
      string text = this.tbxCustomerCode.Text;
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        string str1 = "Photos\\AadharFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str1))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str1, FileMode.Open, FileAccess.Read))
          {
            this.pbAadharFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str2 = "Photos\\VoterIdFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str2))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str2, FileMode.Open, FileAccess.Read))
          {
            this.pbVoterIdFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str3 = "Photos\\PanCardFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str3))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str3, FileMode.Open, FileAccess.Read))
          {
            this.pbPanCardFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str4 = "Photos\\DrivingLicenseFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str4))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str4, FileMode.Open, FileAccess.Read))
          {
            this.pbDrivingLicenseFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str5 = "Photos\\RationCardFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str5))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str5, FileMode.Open, FileAccess.Read))
          {
            this.pbRationCardFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str6 = "Photos\\OthersFront\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str6))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str6, FileMode.Open, FileAccess.Read))
          {
            this.pbOthersFront.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str7 = "Photos\\AadharBack\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str7))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str7, FileMode.Open, FileAccess.Read))
          {
            this.pbAadharBack.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str8 = "Photos\\VoterIdBack\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str8))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str8, FileMode.Open, FileAccess.Read))
          {
            this.pbVoterIdBack.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str9 = "Photos\\PanCardBack\\ " + text + ".png";
        if (File.Exists(FormMain.startUpPath + str9))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str9, FileMode.Open, FileAccess.Read))
          {
            this.pbPanCardBack.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str10 = "Photos\\DrivingLicenseBack\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str10))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str10, FileMode.Open, FileAccess.Read))
          {
            this.pbDrivingLicenseBack.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str11 = "Photos\\RationCardBack\\" + text + ".png";
        if (File.Exists(FormMain.startUpPath + str11))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + str11, FileMode.Open, FileAccess.Read))
          {
            this.pbRationCardBack.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        string str12 = "Photos\\OthersBack\\" + text + ".png";
        if (!File.Exists(FormMain.startUpPath + str12))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + str12, FileMode.Open, FileAccess.Read))
        {
          this.pbOthersBack.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      else
        this.tbxCustomerName.Select();
    }

    private void pbProofCameraButtonClicked(object sender, EventArgs e)
    {
      string text = this.tbxCustomerCode.Text;
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        if ((sender as PictureBox).Name.Contains("Front"))
        {
          if ((sender as PictureBox).Name.Contains("Aadhar"))
          {
            string strFilePath = "Photos\\AadharFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (!File.Exists(FormMain.startUpPath + strFilePath))
              return;
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
            {
              this.pbAadharFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          else if ((sender as PictureBox).Name.Contains("VoterId"))
          {
            string strFilePath = "Photos\\VoterIdFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (!File.Exists(FormMain.startUpPath + strFilePath))
              return;
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
            {
              this.pbVoterIdFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          else if ((sender as PictureBox).Name.Contains("Pan"))
          {
            string strFilePath = "Photos\\PanCardFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (!File.Exists(FormMain.startUpPath + strFilePath))
              return;
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
            {
              this.pbPanCardFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          else if ((sender as PictureBox).Name.Contains("DrivingLicense"))
          {
            string strFilePath = "Photos\\DrivingLicenseFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (!File.Exists(FormMain.startUpPath + strFilePath))
              return;
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
            {
              this.pbDrivingLicenseFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          else if ((sender as PictureBox).Name.Contains("RationCard"))
          {
            string strFilePath = "Photos\\RationCardFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (!File.Exists(FormMain.startUpPath + strFilePath))
              return;
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
            {
              this.pbRationCardFront.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          else
          {
            if (!(sender as PictureBox).Name.Contains("Others"))
              return;
            string strFilePath = "Photos\\OthersFront\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbOthersFront.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
        }
        else
        {
          if (!(sender as PictureBox).Name.Contains("Back"))
            return;
          if ((sender as PictureBox).Name.Contains("Aadhar"))
          {
            string strFilePath = "Photos\\AadharBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbAadharBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
          else if ((sender as PictureBox).Name.Contains("VoterId"))
          {
            string strFilePath = "Photos\\VoterIdBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbVoterIdBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
          else if ((sender as PictureBox).Name.Contains("Pan"))
          {
            string strFilePath = "Photos\\PanCardBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbPanCardBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
          else if ((sender as PictureBox).Name.Contains("DrivingLicense"))
          {
            string strFilePath = "Photos\\DrivingLicenseBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbDrivingLicenseBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
          else if ((sender as PictureBox).Name.Contains("RationCard"))
          {
            string strFilePath = "Photos\\RationCardBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbRationCardBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
          else if ((sender as PictureBox).Name.Contains("Others"))
          {
            string strFilePath = "Photos\\OthersBack\\temp\\" + text + ".png";
            int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proof", strFilePath).ShowDialog();
            if (File.Exists(FormMain.startUpPath + strFilePath))
            {
              using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
              {
                this.pbOthersBack.Image = Image.FromStream((Stream) fileStream);
                fileStream.Dispose();
              }
            }
          }
        }
      }
      else
        this.tbxCustomerName.Select();
    }

    private void ProofScanButtonClicked(object sender, EventArgs e)
    {
      string strFilePath = "";
      string text = this.tbxCustomerCode.Text;
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        PictureBox pictureBox = this.getPictureBox((object) (sender as PictureBox), ref strFilePath, text);
        this.Scan(FormMain.startUpPath + strFilePath, (object) pictureBox);
        if (!File.Exists(FormMain.startUpPath + strFilePath))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + strFilePath, FileMode.Open, FileAccess.Read))
        {
          pictureBox.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      else
        this.tbxCustomerName.Select();
    }

    private PictureBox getPictureBoxWithoutTemp(
      object sender,
      ref string strFilePath,
      string strCustomerCode)
    {
      if ((sender as PictureBox).Name.Contains("Front"))
      {
        if ((sender as PictureBox).Name.Contains("Aadhar"))
        {
          strFilePath = "Photos\\AadharFront\\" + strCustomerCode + ".png";
          return this.pbAadharFront;
        }
        if ((sender as PictureBox).Name.Contains("VoterId"))
        {
          strFilePath = "Photos\\VoterIdFront\\" + strCustomerCode + ".png";
          return this.pbVoterIdFront;
        }
        if ((sender as PictureBox).Name.Contains("Pan"))
        {
          strFilePath = "Photos\\PanCardFront\\" + strCustomerCode + ".png";
          return this.pbPanCardFront;
        }
        if ((sender as PictureBox).Name.Contains("DrivingLicense"))
        {
          strFilePath = "Photos\\DrivingLicenseFront\\" + strCustomerCode + ".png";
          return this.pbDrivingLicenseFront;
        }
        if ((sender as PictureBox).Name.Contains("RationCard"))
        {
          strFilePath = "Photos\\RationCardFront\\" + strCustomerCode + ".png";
          return this.pbRationCardFront;
        }
        strFilePath = "Photos\\OthersFront\\" + strCustomerCode + ".png";
        return this.pbOthersFront;
      }
      if (!(sender as PictureBox).Name.Contains("Back"))
        return this.pbOthersFront;
      if ((sender as PictureBox).Name.Contains("Aadhar"))
      {
        strFilePath = "Photos\\AadharBack\\" + strCustomerCode + ".png";
        return this.pbAadharBack;
      }
      if ((sender as PictureBox).Name.Contains("VoterId"))
      {
        strFilePath = "Photos\\VoterIdBack\\" + strCustomerCode + ".png";
        return this.pbVoterIdBack;
      }
      if ((sender as PictureBox).Name.Contains("Pan"))
      {
        strFilePath = "Photos\\PanCardBack\\" + strCustomerCode + ".png";
        return this.pbPanCardBack;
      }
      if ((sender as PictureBox).Name.Contains("DrivingLicense"))
      {
        strFilePath = "Photos\\DrivingLicenseBack\\" + strCustomerCode + ".png";
        return this.pbDrivingLicenseBack;
      }
      if ((sender as PictureBox).Name.Contains("RationCard"))
      {
        strFilePath = "Photos\\RationCardBack\\" + strCustomerCode + ".png";
        return this.pbRationCardBack;
      }
      strFilePath = "Photos\\OthersBack\\" + strCustomerCode + ".png";
      return this.pbOthersBack;
    }

    private PictureBox getPictureBox(object sender, ref string strFilePath, string strCustomerCode)
    {
      if ((sender as PictureBox).Name.Contains("Front"))
      {
        if ((sender as PictureBox).Name.Contains("Aadhar"))
        {
          strFilePath = "Photos\\AadharFront\\temp\\" + strCustomerCode + ".png";
          return this.pbAadharFront;
        }
        if ((sender as PictureBox).Name.Contains("VoterId"))
        {
          strFilePath = "Photos\\VoterIdFront\\temp\\" + strCustomerCode + ".png";
          return this.pbVoterIdFront;
        }
        if ((sender as PictureBox).Name.Contains("Pan"))
        {
          strFilePath = "Photos\\PanCardFront\\temp\\" + strCustomerCode + ".png";
          return this.pbPanCardFront;
        }
        if ((sender as PictureBox).Name.Contains("DrivingLicense"))
        {
          strFilePath = "Photos\\DrivingLicenseFront\\temp\\" + strCustomerCode + ".png";
          return this.pbDrivingLicenseFront;
        }
        if ((sender as PictureBox).Name.Contains("RationCard"))
        {
          strFilePath = "Photos\\RationCardFront\\temp\\" + strCustomerCode + ".png";
          return this.pbRationCardFront;
        }
        strFilePath = "Photos\\OthersFront\\temp\\" + strCustomerCode + ".png";
        return this.pbOthersFront;
      }
      if (!(sender as PictureBox).Name.Contains("Back"))
        return this.pbOthersFront;
      if ((sender as PictureBox).Name.Contains("Aadhar"))
      {
        strFilePath = "Photos\\AadharBack\\temp\\" + strCustomerCode + ".png";
        return this.pbAadharBack;
      }
      if ((sender as PictureBox).Name.Contains("VoterId"))
      {
        strFilePath = "Photos\\VoterIdBack\\temp\\" + strCustomerCode + ".png";
        return this.pbVoterIdBack;
      }
      if ((sender as PictureBox).Name.Contains("Pan"))
      {
        strFilePath = "Photos\\PanCardBack\\temp\\" + strCustomerCode + ".png";
        return this.pbPanCardBack;
      }
      if ((sender as PictureBox).Name.Contains("DrivingLicense"))
      {
        strFilePath = "Photos\\DrivingLicenseBack\\temp\\" + strCustomerCode + ".png";
        return this.pbDrivingLicenseBack;
      }
      if ((sender as PictureBox).Name.Contains("RationCard"))
      {
        strFilePath = "Photos\\RationCardBack\\temp\\" + strCustomerCode + ".png";
        return this.pbRationCardBack;
      }
      strFilePath = "Photos\\OthersBack\\temp\\" + strCustomerCode + ".png";
      return this.pbOthersBack;
    }

    public void Scan(string strFilePath, object obj)
    {
      List<Image> imageList = new List<Image>();
      try
      {
        foreach (object device in WIAScanner.GetDevices())
          this.lbDevices.Items.Add(device);
        if (this.lbDevices.Items.Count == 0)
        {
          int num = (int) MessageBox.Show("You do not have any WIA devices.");
        }
        else
        {
          this.lbDevices.SelectedIndex = 0;
          foreach (Image image in WIAScanner.Scan((string) this.lbDevices.SelectedItem))
          {
            (obj as PictureBox).Image = image;
            (obj as PictureBox).Show();
            (obj as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            image.Save(strFilePath, ImageFormat.Png);
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void button1_Click_1(object sender, EventArgs e) => this.btnResidentialAddress.PerformClick();

    private void pbDeleteAadharFront_Click(object sender, EventArgs e)
    {
      string strFilePath = "";
      string text = this.tbxCustomerCode.Text;
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        switch (Form1.strFormType)
        {
          case "ADD":
            PictureBox pictureBox1 = this.getPictureBox((object) (sender as PictureBox), ref strFilePath, text);
            if (DialogResult.Yes != MessageBox.Show("Are you sure you want to Delete?", "Are you sure?", MessageBoxButtons.YesNo))
              break;
            try
            {
              if (File.Exists(FormMain.startUpPath + strFilePath))
              {
                File.Delete(FormMain.startUpPath + strFilePath);
                pictureBox1.Image = (Image) null;
              }
            }
            catch (Exception ex)
            {
              throw;
            }
            break;
          case "EDIT":
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Delete?", "Are you sure?", MessageBoxButtons.YesNo))
            {
              PictureBox pictureBoxWithoutTemp = this.getPictureBoxWithoutTemp((object) (sender as PictureBox), ref strFilePath, text);
              try
              {
                if (File.Exists(FormMain.startUpPath + strFilePath))
                {
                  File.Delete(FormMain.startUpPath + strFilePath);
                  pictureBoxWithoutTemp.Image = (Image) null;
                }
              }
              catch (Exception ex)
              {
                throw;
              }
              PictureBox pictureBox2 = this.getPictureBox((object) (sender as PictureBox), ref strFilePath, text);
              try
              {
                if (File.Exists(FormMain.startUpPath + strFilePath))
                {
                  File.Delete(FormMain.startUpPath + strFilePath);
                  pictureBox2.Image = (Image) null;
                }
              }
              catch (Exception ex)
              {
                throw;
              }
            }
            break;
        }
      }
      else
        this.tbxCustomerName.Select();
    }

    private void button3_Click(object sender, EventArgs e) => this.btnProofs.PerformClick();

    private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void pbScanPanFront_Click(object sender, EventArgs e)
    {
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.panel1 = new Panel();
      this.pictureBox1 = new PictureBox();
      this.llTakeFingerPrint = new LinkLabel();
      this.pbFingerPrint = new PictureBox();
      this.llScanCustomerPhoto = new LinkLabel();
      this.llSelectCustomerPhoto = new LinkLabel();
      this.llAddCustomerPhoto = new LinkLabel();
      this.pbPhoto = new PictureBox();
      this.SidePanel = new Panel();
      this.btnBankDetails = new Button();
      this.btnProofs = new Button();
      this.btnResidentialAddress = new Button();
      this.btnPersonalDetails = new Button();
      this.panel2 = new Panel();
      this.linkLabel1 = new LinkLabel();
      this.lblHeading2 = new Label();
      this.lblHeading = new Label();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.tabControl = new TabControl();
      this.tpPersonalDetails = new TabPage();
      this.apnlPersonalDetails = new Panel();
      this.btnSave1 = new Button();
      this.tbxSpouseCode = new TextBox();
      this.tbxMotherCode = new TextBox();
      this.tbxFatherCode = new TextBox();
      this.dgvFatherNameSearch = new DataGridView();
      this.dgvMotherNameSearch = new DataGridView();
      this.dgvSpouseNameSearch = new DataGridView();
      this.tbxDob = new MaskedTextBox();
      this.linkLabel6 = new LinkLabel();
      this.linkLabel5 = new LinkLabel();
      this.linkLabel4 = new LinkLabel();
      this.tbxSpouseNameSearch = new TextBox();
      this.tbxMotherNameSearch = new TextBox();
      this.tbxFatherNameSearch = new TextBox();
      this.btnNext = new Button();
      this.panel62 = new Panel();
      this.tbxSpouseName = new TextBox();
      this.label42 = new Label();
      this.panel63 = new Panel();
      this.tbxOccupation = new TextBox();
      this.label44 = new Label();
      this.panel3 = new Panel();
      this.tbxMotherName = new TextBox();
      this.panel50 = new Panel();
      this.tbxFatherName = new TextBox();
      this.panel51 = new Panel();
      this.tbxMaritalStatus = new TextBox();
      this.panel53 = new Panel();
      this.tbxIntroducedBy = new TextBox();
      this.panel54 = new Panel();
      this.tbxInterestRAte = new TextBox();
      this.panel55 = new Panel();
      this.tbxReligion = new TextBox();
      this.panel56 = new Panel();
      this.tbxEducation = new TextBox();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label32 = new Label();
      this.label33 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.label36 = new Label();
      this.panel11 = new Panel();
      this.tbxEmail = new TextBox();
      this.panel10 = new Panel();
      this.tbxNotes = new TextBox();
      this.panel9 = new Panel();
      this.tbxAlternateNumber = new TextBox();
      this.panel8 = new Panel();
      this.tbxPhone = new TextBox();
      this.panel7 = new Panel();
      this.tbxSex = new TextBox();
      this.panel6 = new Panel();
      this.panel5 = new Panel();
      this.tbxCustomerName = new TextBox();
      this.panel4 = new Panel();
      this.tbxCustomerCode = new TextBox();
      this.lblCustomerCode = new Label();
      this.lblCustomerName = new Label();
      this.label8 = new Label();
      this.label5 = new Label();
      this.label9 = new Label();
      this.lblSex = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.tpResidentialAddress = new TabPage();
      this.apnlResidentialAddress = new Panel();
      this.button3 = new Button();
      this.btnPrevious = new Button();
      this.btnSave2 = new Button();
      this.pcbLocation = new ComboBox();
      this.pcbHouseType = new ComboBox();
      this.pcbOwnerShip = new ComboBox();
      this.label17 = new Label();
      this.panel23 = new Panel();
      this.label18 = new Label();
      this.panel24 = new Panel();
      this.panel25 = new Panel();
      this.ptbxLandMark = new TextBox();
      this.panel27 = new Panel();
      this.ptbxPincode = new TextBox();
      this.panel28 = new Panel();
      this.ptbxCity = new TextBox();
      this.panel29 = new Panel();
      this.panel30 = new Panel();
      this.ptbxAddr2 = new TextBox();
      this.panel31 = new Panel();
      this.ptbxAddr1 = new TextBox();
      this.panel32 = new Panel();
      this.ptbxDoorNumber = new TextBox();
      this.label19 = new Label();
      this.label20 = new Label();
      this.label21 = new Label();
      this.label23 = new Label();
      this.label24 = new Label();
      this.label25 = new Label();
      this.cbLocation = new ComboBox();
      this.cbHouseType = new ComboBox();
      this.cbOwnerShip = new ComboBox();
      this.label16 = new Label();
      this.panel22 = new Panel();
      this.label7 = new Label();
      this.panel21 = new Panel();
      this.panel13 = new Panel();
      this.tbxLandMark = new TextBox();
      this.panel15 = new Panel();
      this.tbxPincode = new TextBox();
      this.panel16 = new Panel();
      this.tbxCity = new TextBox();
      this.panel17 = new Panel();
      this.panel18 = new Panel();
      this.tbxAddr2 = new TextBox();
      this.panel19 = new Panel();
      this.tbxAddr1 = new TextBox();
      this.panel20 = new Panel();
      this.tbxDoorNumber = new TextBox();
      this.label1 = new Label();
      this.label4 = new Label();
      this.label6 = new Label();
      this.label13 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.tpProof = new TabPage();
      this.apnlProof = new Panel();
      this.button1 = new Button();
      this.button2 = new Button();
      this.lbDevices = new ListBox();
      this.panel14 = new Panel();
      this.tbxOthers = new TextBox();
      this.label12 = new Label();
      this.panel57 = new Panel();
      this.tbxRationCard = new TextBox();
      this.panel58 = new Panel();
      this.tbxDrivingLicense = new TextBox();
      this.panel59 = new Panel();
      this.tbxVoterId = new TextBox();
      this.panel60 = new Panel();
      this.tbxPanCard = new TextBox();
      this.panel61 = new Panel();
      this.tbxAadharNumber = new TextBox();
      this.label38 = new Label();
      this.label39 = new Label();
      this.label40 = new Label();
      this.label41 = new Label();
      this.label43 = new Label();
      this.panel44 = new Panel();
      this.pbDeleteOthersBack = new PictureBox();
      this.pbCameraOthersBack = new PictureBox();
      this.pbScanOthersBack = new PictureBox();
      this.pbSelectOthersBack = new PictureBox();
      this.panel45 = new Panel();
      this.pbDeleteOthersFront = new PictureBox();
      this.pbCameraOthersFront = new PictureBox();
      this.pbScanOthersFront = new PictureBox();
      this.pbSelectOthersFront = new PictureBox();
      this.panel47 = new Panel();
      this.pbDeleteRationCardBack = new PictureBox();
      this.pbCameraRationCardBack = new PictureBox();
      this.pbScanRationCardBack = new PictureBox();
      this.pbSelectRationCardBack = new PictureBox();
      this.panel48 = new Panel();
      this.pbDeleteRationCardFront = new PictureBox();
      this.pbCameraRationCardFront = new PictureBox();
      this.pbScanRationCardFront = new PictureBox();
      this.pbSelectRationCardFront = new PictureBox();
      this.panel38 = new Panel();
      this.pbDeleteDrivingLicenseBack = new PictureBox();
      this.pbCameraDrivingLicenseBack = new PictureBox();
      this.pbScanDrivingLicenseBack = new PictureBox();
      this.pbSelectDrivingLicenseBack = new PictureBox();
      this.panel39 = new Panel();
      this.pbDeleteDrivingLicenseFront = new PictureBox();
      this.pbCameraDrivingLicenseFront = new PictureBox();
      this.pbScanDrivingLicenseFront = new PictureBox();
      this.pbSelectDrivingLicenseFront = new PictureBox();
      this.panel41 = new Panel();
      this.pbDeleteVoterIdBack = new PictureBox();
      this.pbCameraVoterIdBack = new PictureBox();
      this.pbScanVoterIdBack = new PictureBox();
      this.pbSelectVoterIdBack = new PictureBox();
      this.panel42 = new Panel();
      this.pbDeleteVoterIdFront = new PictureBox();
      this.pbCameraVoterIdFront = new PictureBox();
      this.pbScanVoterIdFront = new PictureBox();
      this.pbSelectVoterIdFront = new PictureBox();
      this.panel35 = new Panel();
      this.pbDeletePanBack = new PictureBox();
      this.pbCamPanBack = new PictureBox();
      this.pbScanPanBack = new PictureBox();
      this.pbSelectPanBack = new PictureBox();
      this.panel36 = new Panel();
      this.pbDeletePanFront = new PictureBox();
      this.pbCameraPanFront = new PictureBox();
      this.pbScanPanFront = new PictureBox();
      this.pbSelectPanFront = new PictureBox();
      this.panel33 = new Panel();
      this.pbDeleteAadharBack = new PictureBox();
      this.pbCameraAadharBack = new PictureBox();
      this.pbScanAadharBack = new PictureBox();
      this.pbSelectAadharBack = new PictureBox();
      this.pbPanCardBack = new PictureBox();
      this.panel49 = new Panel();
      this.label31 = new Label();
      this.pbPanCardFront = new PictureBox();
      this.pbDrivingLicenseBack = new PictureBox();
      this.panel46 = new Panel();
      this.label30 = new Label();
      this.pbDrivingLicenseFront = new PictureBox();
      this.pbOthersBack = new PictureBox();
      this.panel43 = new Panel();
      this.label29 = new Label();
      this.pbOthersFront = new PictureBox();
      this.pbRationCardBack = new PictureBox();
      this.panel40 = new Panel();
      this.label28 = new Label();
      this.pbRationCardFront = new PictureBox();
      this.pbVoterIdBack = new PictureBox();
      this.panel37 = new Panel();
      this.label27 = new Label();
      this.pbVoterIdFront = new PictureBox();
      this.pbAadharBack = new PictureBox();
      this.panel12 = new Panel();
      this.pbDeleteAadharFront = new PictureBox();
      this.pbCameraAadharFront = new PictureBox();
      this.pbScanAadharFront = new PictureBox();
      this.pbSelectAadharFront = new PictureBox();
      this.panel34 = new Panel();
      this.label26 = new Label();
      this.pbAadharFront = new PictureBox();
      this.tpBankDetails = new TabPage();
      this.tpFamilyDetails = new TabPage();
      this.tpKyc = new TabPage();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pbFingerPrint).BeginInit();
      ((ISupportInitialize) this.pbPhoto).BeginInit();
      this.panel2.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tpPersonalDetails.SuspendLayout();
      this.apnlPersonalDetails.SuspendLayout();
      ((ISupportInitialize) this.dgvFatherNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvSpouseNameSearch).BeginInit();
      this.tpResidentialAddress.SuspendLayout();
      this.apnlResidentialAddress.SuspendLayout();
      this.tpProof.SuspendLayout();
      this.apnlProof.SuspendLayout();
      this.panel44.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteOthersBack).BeginInit();
      ((ISupportInitialize) this.pbCameraOthersBack).BeginInit();
      ((ISupportInitialize) this.pbScanOthersBack).BeginInit();
      ((ISupportInitialize) this.pbSelectOthersBack).BeginInit();
      this.panel45.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteOthersFront).BeginInit();
      ((ISupportInitialize) this.pbCameraOthersFront).BeginInit();
      ((ISupportInitialize) this.pbScanOthersFront).BeginInit();
      ((ISupportInitialize) this.pbSelectOthersFront).BeginInit();
      this.panel47.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteRationCardBack).BeginInit();
      ((ISupportInitialize) this.pbCameraRationCardBack).BeginInit();
      ((ISupportInitialize) this.pbScanRationCardBack).BeginInit();
      ((ISupportInitialize) this.pbSelectRationCardBack).BeginInit();
      this.panel48.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteRationCardFront).BeginInit();
      ((ISupportInitialize) this.pbCameraRationCardFront).BeginInit();
      ((ISupportInitialize) this.pbScanRationCardFront).BeginInit();
      ((ISupportInitialize) this.pbSelectRationCardFront).BeginInit();
      this.panel38.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteDrivingLicenseBack).BeginInit();
      ((ISupportInitialize) this.pbCameraDrivingLicenseBack).BeginInit();
      ((ISupportInitialize) this.pbScanDrivingLicenseBack).BeginInit();
      ((ISupportInitialize) this.pbSelectDrivingLicenseBack).BeginInit();
      this.panel39.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteDrivingLicenseFront).BeginInit();
      ((ISupportInitialize) this.pbCameraDrivingLicenseFront).BeginInit();
      ((ISupportInitialize) this.pbScanDrivingLicenseFront).BeginInit();
      ((ISupportInitialize) this.pbSelectDrivingLicenseFront).BeginInit();
      this.panel41.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteVoterIdBack).BeginInit();
      ((ISupportInitialize) this.pbCameraVoterIdBack).BeginInit();
      ((ISupportInitialize) this.pbScanVoterIdBack).BeginInit();
      ((ISupportInitialize) this.pbSelectVoterIdBack).BeginInit();
      this.panel42.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteVoterIdFront).BeginInit();
      ((ISupportInitialize) this.pbCameraVoterIdFront).BeginInit();
      ((ISupportInitialize) this.pbScanVoterIdFront).BeginInit();
      ((ISupportInitialize) this.pbSelectVoterIdFront).BeginInit();
      this.panel35.SuspendLayout();
      ((ISupportInitialize) this.pbDeletePanBack).BeginInit();
      ((ISupportInitialize) this.pbCamPanBack).BeginInit();
      ((ISupportInitialize) this.pbScanPanBack).BeginInit();
      ((ISupportInitialize) this.pbSelectPanBack).BeginInit();
      this.panel36.SuspendLayout();
      ((ISupportInitialize) this.pbDeletePanFront).BeginInit();
      ((ISupportInitialize) this.pbCameraPanFront).BeginInit();
      ((ISupportInitialize) this.pbScanPanFront).BeginInit();
      ((ISupportInitialize) this.pbSelectPanFront).BeginInit();
      this.panel33.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteAadharBack).BeginInit();
      ((ISupportInitialize) this.pbCameraAadharBack).BeginInit();
      ((ISupportInitialize) this.pbScanAadharBack).BeginInit();
      ((ISupportInitialize) this.pbSelectAadharBack).BeginInit();
      ((ISupportInitialize) this.pbPanCardBack).BeginInit();
      this.panel49.SuspendLayout();
      ((ISupportInitialize) this.pbPanCardFront).BeginInit();
      ((ISupportInitialize) this.pbDrivingLicenseBack).BeginInit();
      this.panel46.SuspendLayout();
      ((ISupportInitialize) this.pbDrivingLicenseFront).BeginInit();
      ((ISupportInitialize) this.pbOthersBack).BeginInit();
      this.panel43.SuspendLayout();
      ((ISupportInitialize) this.pbOthersFront).BeginInit();
      ((ISupportInitialize) this.pbRationCardBack).BeginInit();
      this.panel40.SuspendLayout();
      ((ISupportInitialize) this.pbRationCardFront).BeginInit();
      ((ISupportInitialize) this.pbVoterIdBack).BeginInit();
      this.panel37.SuspendLayout();
      ((ISupportInitialize) this.pbVoterIdFront).BeginInit();
      ((ISupportInitialize) this.pbAadharBack).BeginInit();
      this.panel12.SuspendLayout();
      ((ISupportInitialize) this.pbDeleteAadharFront).BeginInit();
      ((ISupportInitialize) this.pbCameraAadharFront).BeginInit();
      ((ISupportInitialize) this.pbScanAadharFront).BeginInit();
      ((ISupportInitialize) this.pbSelectAadharFront).BeginInit();
      this.panel34.SuspendLayout();
      ((ISupportInitialize) this.pbAadharFront).BeginInit();
      this.SuspendLayout();
      this.panel1.BackColor = Color.FromArgb(41, 39, 40);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.llTakeFingerPrint);
      this.panel1.Controls.Add((Control) this.pbFingerPrint);
      this.panel1.Controls.Add((Control) this.llScanCustomerPhoto);
      this.panel1.Controls.Add((Control) this.llSelectCustomerPhoto);
      this.panel1.Controls.Add((Control) this.llAddCustomerPhoto);
      this.panel1.Controls.Add((Control) this.pbPhoto);
      this.panel1.Controls.Add((Control) this.SidePanel);
      this.panel1.Controls.Add((Control) this.btnBankDetails);
      this.panel1.Controls.Add((Control) this.btnProofs);
      this.panel1.Controls.Add((Control) this.btnResidentialAddress);
      this.panel1.Controls.Add((Control) this.btnPersonalDetails);
      this.panel1.Dock = DockStyle.Left;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(209, 650);
      this.panel1.TabIndex = 0;
      this.pictureBox1.Location = new Point(3, 435);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(50, 58);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 32;
      this.pictureBox1.TabStop = false;
      this.llTakeFingerPrint.AutoSize = true;
      this.llTakeFingerPrint.LinkColor = Color.White;
      this.llTakeFingerPrint.Location = new Point(71, 621);
      this.llTakeFingerPrint.Name = "llTakeFingerPrint";
      this.llTakeFingerPrint.Size = new Size(85, 13);
      this.llTakeFingerPrint.TabIndex = 31;
      this.llTakeFingerPrint.TabStop = true;
      this.llTakeFingerPrint.Text = "Take FingerPrint";
      this.llTakeFingerPrint.LinkClicked += new LinkLabelLinkClickedEventHandler(this.llTakeFingerPrint_LinkClicked);
      this.pbFingerPrint.Location = new Point(14, 444);
      this.pbFingerPrint.Name = "pbFingerPrint";
      this.pbFingerPrint.Size = new Size(180, 194);
      this.pbFingerPrint.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbFingerPrint.TabIndex = 30;
      this.pbFingerPrint.TabStop = false;
      this.llScanCustomerPhoto.AutoSize = true;
      this.llScanCustomerPhoto.LinkColor = Color.White;
      this.llScanCustomerPhoto.Location = new Point(141, 188);
      this.llScanCustomerPhoto.Name = "llScanCustomerPhoto";
      this.llScanCustomerPhoto.Size = new Size(63, 13);
      this.llScanCustomerPhoto.TabIndex = 29;
      this.llScanCustomerPhoto.TabStop = true;
      this.llScanCustomerPhoto.Text = "Scan Photo";
      this.llSelectCustomerPhoto.AutoSize = true;
      this.llSelectCustomerPhoto.LinkColor = Color.White;
      this.llSelectCustomerPhoto.Location = new Point(71, 188);
      this.llSelectCustomerPhoto.Name = "llSelectCustomerPhoto";
      this.llSelectCustomerPhoto.Size = new Size(68, 13);
      this.llSelectCustomerPhoto.TabIndex = 28;
      this.llSelectCustomerPhoto.TabStop = true;
      this.llSelectCustomerPhoto.Text = "Select Photo";
      this.llSelectCustomerPhoto.Click += new EventHandler(this.llSelectCustomerPhoto_Click);
      this.llAddCustomerPhoto.AutoSize = true;
      this.llAddCustomerPhoto.LinkColor = Color.White;
      this.llAddCustomerPhoto.Location = new Point(15, 188);
      this.llAddCustomerPhoto.Name = "llAddCustomerPhoto";
      this.llAddCustomerPhoto.Size = new Size(57, 13);
      this.llAddCustomerPhoto.TabIndex = 27;
      this.llAddCustomerPhoto.TabStop = true;
      this.llAddCustomerPhoto.Text = "Add Photo";
      this.llAddCustomerPhoto.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.pbPhoto.Image = (Image) componentResourceManager.GetObject("pbPhoto.Image");
      this.pbPhoto.Location = new Point(15, 18);
      this.pbPhoto.Name = "pbPhoto";
      this.pbPhoto.Size = new Size(183, 163);
      this.pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbPhoto.TabIndex = 26;
      this.pbPhoto.TabStop = false;
      this.SidePanel.BackColor = Color.FromArgb(178, 8, 55);
      this.SidePanel.Location = new Point(1, 212);
      this.SidePanel.Name = "SidePanel";
      this.SidePanel.Size = new Size(10, 54);
      this.SidePanel.TabIndex = 4;
      this.btnBankDetails.FlatAppearance.BorderSize = 0;
      this.btnBankDetails.FlatStyle = FlatStyle.Flat;
      this.btnBankDetails.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBankDetails.ForeColor = Color.White;
      this.btnBankDetails.Image = (Image) componentResourceManager.GetObject("btnBankDetails.Image");
      this.btnBankDetails.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnBankDetails.Location = new Point(12, 389);
      this.btnBankDetails.Name = "btnBankDetails";
      this.btnBankDetails.Size = new Size(197, 54);
      this.btnBankDetails.TabIndex = 4;
      this.btnBankDetails.Text = "       Bank Details";
      this.btnBankDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnBankDetails.UseVisualStyleBackColor = true;
      this.btnBankDetails.Click += new EventHandler(this.btnBankDetails_Click);
      this.btnProofs.FlatAppearance.BorderSize = 0;
      this.btnProofs.FlatStyle = FlatStyle.Flat;
      this.btnProofs.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnProofs.ForeColor = Color.White;
      this.btnProofs.Image = (Image) componentResourceManager.GetObject("btnProofs.Image");
      this.btnProofs.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnProofs.Location = new Point(12, 327);
      this.btnProofs.Name = "btnProofs";
      this.btnProofs.Size = new Size(197, 54);
      this.btnProofs.TabIndex = 4;
      this.btnProofs.Text = "       Proofs";
      this.btnProofs.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnProofs.UseVisualStyleBackColor = true;
      this.btnProofs.Click += new EventHandler(this.btnProofs_Click);
      this.btnResidentialAddress.FlatAppearance.BorderSize = 0;
      this.btnResidentialAddress.FlatStyle = FlatStyle.Flat;
      this.btnResidentialAddress.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnResidentialAddress.ForeColor = Color.White;
      this.btnResidentialAddress.Image = (Image) componentResourceManager.GetObject("btnResidentialAddress.Image");
      this.btnResidentialAddress.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnResidentialAddress.Location = new Point(12, 268);
      this.btnResidentialAddress.Name = "btnResidentialAddress";
      this.btnResidentialAddress.Size = new Size(197, 54);
      this.btnResidentialAddress.TabIndex = 4;
      this.btnResidentialAddress.Text = "       Address";
      this.btnResidentialAddress.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnResidentialAddress.UseVisualStyleBackColor = true;
      this.btnResidentialAddress.Click += new EventHandler(this.button2_Click);
      this.btnPersonalDetails.FlatAppearance.BorderSize = 0;
      this.btnPersonalDetails.FlatStyle = FlatStyle.Flat;
      this.btnPersonalDetails.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnPersonalDetails.ForeColor = Color.White;
      this.btnPersonalDetails.Image = (Image) componentResourceManager.GetObject("btnPersonalDetails.Image");
      this.btnPersonalDetails.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnPersonalDetails.Location = new Point(12, 214);
      this.btnPersonalDetails.Name = "btnPersonalDetails";
      this.btnPersonalDetails.Size = new Size(197, 54);
      this.btnPersonalDetails.TabIndex = 4;
      this.btnPersonalDetails.Text = "       Personal Details";
      this.btnPersonalDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnPersonalDetails.UseVisualStyleBackColor = true;
      this.btnPersonalDetails.Click += new EventHandler(this.button1_Click);
      this.panel2.BackColor = Color.Maroon;
      this.panel2.Controls.Add((Control) this.linkLabel1);
      this.panel2.Controls.Add((Control) this.lblHeading2);
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(209, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(815, 30);
      this.panel2.TabIndex = 1;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.LinkColor = Color.White;
      this.linkLabel1.Location = new Point(776, 8);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(33, 13);
      this.linkLabel1.TabIndex = 32;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Close";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
      this.lblHeading2.AutoSize = true;
      this.lblHeading2.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading2.ForeColor = Color.White;
      this.lblHeading2.Location = new Point(412, 4);
      this.lblHeading2.Name = "lblHeading2";
      this.lblHeading2.Size = new Size(0, 21);
      this.lblHeading2.TabIndex = 76;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.White;
      this.lblHeading.Location = new Point(7, 4);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(130, 21);
      this.lblHeading.TabIndex = 75;
      this.lblHeading.Text = "Personal Details";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.dELETEToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(114, 26);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(113, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.tabControl.Appearance = TabAppearance.FlatButtons;
      this.tabControl.Controls.Add((Control) this.tpPersonalDetails);
      this.tabControl.Controls.Add((Control) this.tpResidentialAddress);
      this.tabControl.Controls.Add((Control) this.tpProof);
      this.tabControl.Controls.Add((Control) this.tpBankDetails);
      this.tabControl.Controls.Add((Control) this.tpFamilyDetails);
      this.tabControl.Controls.Add((Control) this.tpKyc);
      this.tabControl.Dock = DockStyle.Fill;
      this.tabControl.ItemSize = new Size(0, 1);
      this.tabControl.Location = new Point(209, 30);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new Size(815, 620);
      this.tabControl.SizeMode = TabSizeMode.Fixed;
      this.tabControl.TabIndex = 5;
      this.tpPersonalDetails.Controls.Add((Control) this.apnlPersonalDetails);
      this.tpPersonalDetails.Location = new Point(4, 5);
      this.tpPersonalDetails.Name = "tpPersonalDetails";
      this.tpPersonalDetails.Padding = new Padding(3);
      this.tpPersonalDetails.Size = new Size(807, 611);
      this.tpPersonalDetails.TabIndex = 0;
      this.tpPersonalDetails.Text = "tabPage1";
      this.tpPersonalDetails.UseVisualStyleBackColor = true;
      this.apnlPersonalDetails.BackColor = Color.WhiteSmoke;
      this.apnlPersonalDetails.Controls.Add((Control) this.btnSave1);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxSpouseCode);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxMotherCode);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxFatherCode);
      this.apnlPersonalDetails.Controls.Add((Control) this.dgvFatherNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.dgvMotherNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.dgvSpouseNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxDob);
      this.apnlPersonalDetails.Controls.Add((Control) this.linkLabel6);
      this.apnlPersonalDetails.Controls.Add((Control) this.linkLabel5);
      this.apnlPersonalDetails.Controls.Add((Control) this.linkLabel4);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxSpouseNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxMotherNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxFatherNameSearch);
      this.apnlPersonalDetails.Controls.Add((Control) this.btnNext);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel62);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxSpouseName);
      this.apnlPersonalDetails.Controls.Add((Control) this.label42);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel63);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxOccupation);
      this.apnlPersonalDetails.Controls.Add((Control) this.label44);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel3);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxMotherName);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel50);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxFatherName);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel51);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxMaritalStatus);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel53);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxIntroducedBy);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel54);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxInterestRAte);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel55);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxReligion);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel56);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxEducation);
      this.apnlPersonalDetails.Controls.Add((Control) this.label2);
      this.apnlPersonalDetails.Controls.Add((Control) this.label3);
      this.apnlPersonalDetails.Controls.Add((Control) this.label32);
      this.apnlPersonalDetails.Controls.Add((Control) this.label33);
      this.apnlPersonalDetails.Controls.Add((Control) this.label34);
      this.apnlPersonalDetails.Controls.Add((Control) this.label35);
      this.apnlPersonalDetails.Controls.Add((Control) this.label36);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel11);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxEmail);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel10);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxNotes);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel9);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxAlternateNumber);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel8);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxPhone);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel7);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxSex);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel6);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel5);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxCustomerName);
      this.apnlPersonalDetails.Controls.Add((Control) this.panel4);
      this.apnlPersonalDetails.Controls.Add((Control) this.tbxCustomerCode);
      this.apnlPersonalDetails.Controls.Add((Control) this.lblCustomerCode);
      this.apnlPersonalDetails.Controls.Add((Control) this.lblCustomerName);
      this.apnlPersonalDetails.Controls.Add((Control) this.label8);
      this.apnlPersonalDetails.Controls.Add((Control) this.label5);
      this.apnlPersonalDetails.Controls.Add((Control) this.label9);
      this.apnlPersonalDetails.Controls.Add((Control) this.lblSex);
      this.apnlPersonalDetails.Controls.Add((Control) this.label10);
      this.apnlPersonalDetails.Controls.Add((Control) this.label11);
      this.apnlPersonalDetails.Dock = DockStyle.Fill;
      this.apnlPersonalDetails.Location = new Point(3, 3);
      this.apnlPersonalDetails.Name = "apnlPersonalDetails";
      this.apnlPersonalDetails.Size = new Size(801, 605);
      this.apnlPersonalDetails.TabIndex = 0;
      this.btnSave1.BackColor = Color.Transparent;
      this.btnSave1.FlatAppearance.BorderColor = Color.Black;
      this.btnSave1.FlatAppearance.BorderSize = 0;
      this.btnSave1.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnSave1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnSave1.FlatStyle = FlatStyle.Popup;
      this.btnSave1.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave1.ForeColor = Color.Black;
      this.btnSave1.Image = (Image) componentResourceManager.GetObject("btnSave1.Image");
      this.btnSave1.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSave1.Location = new Point(610, 545);
      this.btnSave1.Name = "btnSave1";
      this.btnSave1.Size = new Size(159, 51);
      this.btnSave1.TabIndex = 18;
      this.btnSave1.Text = "       &Save";
      this.btnSave1.TextAlign = ContentAlignment.MiddleRight;
      this.btnSave1.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnSave1.UseVisualStyleBackColor = false;
      this.btnSave1.Click += new EventHandler(this.btnSave2_Click);
      this.btnSave1.Enter += new EventHandler(this.button3_Enter);
      this.btnSave1.Leave += new EventHandler(this.btnNext_Leave);
      this.tbxSpouseCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSpouseCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseCode.Location = new Point(345, 84);
      this.tbxSpouseCode.Name = "tbxSpouseCode";
      this.tbxSpouseCode.Size = new Size(66, 31);
      this.tbxSpouseCode.TabIndex = 79;
      this.tbxSpouseCode.Visible = false;
      this.tbxSpouseCode.TextChanged += new EventHandler(this.tbxSpouseCode_TextChanged);
      this.tbxMotherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMotherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherCode.Location = new Point(345, 47);
      this.tbxMotherCode.Name = "tbxMotherCode";
      this.tbxMotherCode.Size = new Size(66, 31);
      this.tbxMotherCode.TabIndex = 78;
      this.tbxMotherCode.Visible = false;
      this.tbxMotherCode.TextChanged += new EventHandler(this.tbxMotherCode_TextChanged);
      this.tbxFatherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFatherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherCode.Location = new Point(345, 10);
      this.tbxFatherCode.Name = "tbxFatherCode";
      this.tbxFatherCode.Size = new Size(66, 31);
      this.tbxFatherCode.TabIndex = 77;
      this.tbxFatherCode.Visible = false;
      this.tbxFatherCode.TextChanged += new EventHandler(this.tbxFatherCode_TextChanged);
      this.dgvFatherNameSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvFatherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFatherNameSearch.Location = new Point(15, 84);
      this.dgvFatherNameSearch.Name = "dgvFatherNameSearch";
      this.dgvFatherNameSearch.RowHeadersVisible = false;
      this.dgvFatherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvFatherNameSearch.Size = new Size(73, 47);
      this.dgvFatherNameSearch.TabIndex = 76;
      this.dgvFatherNameSearch.Visible = false;
      this.dgvFatherNameSearch.KeyDown += new KeyEventHandler(this.dgvCustomerDetails_KeyDown);
      this.dgvMotherNameSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvMotherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvMotherNameSearch.Location = new Point(16, 145);
      this.dgvMotherNameSearch.Name = "dgvMotherNameSearch";
      this.dgvMotherNameSearch.RowHeadersVisible = false;
      this.dgvMotherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvMotherNameSearch.Size = new Size(73, 47);
      this.dgvMotherNameSearch.TabIndex = 75;
      this.dgvMotherNameSearch.Visible = false;
      this.dgvMotherNameSearch.KeyDown += new KeyEventHandler(this.dgvMotherNameSearch_KeyDown);
      this.dgvSpouseNameSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgvSpouseNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSpouseNameSearch.Location = new Point(15, 201);
      this.dgvSpouseNameSearch.Name = "dgvSpouseNameSearch";
      this.dgvSpouseNameSearch.RowHeadersVisible = false;
      this.dgvSpouseNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSpouseNameSearch.Size = new Size(73, 47);
      this.dgvSpouseNameSearch.TabIndex = 74;
      this.dgvSpouseNameSearch.Visible = false;
      this.dgvSpouseNameSearch.KeyDown += new KeyEventHandler(this.dgvSpouseNameSearch_KeyDown);
      this.tbxDob.BackColor = Color.WhiteSmoke;
      this.tbxDob.BorderStyle = BorderStyle.None;
      this.tbxDob.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDob.Location = new Point(15, 171);
      this.tbxDob.Mask = "00/00/0000";
      this.tbxDob.Name = "tbxDob";
      this.tbxDob.Size = new Size(359, 24);
      this.tbxDob.TabIndex = 2;
      this.tbxDob.ValidatingType = typeof (DateTime);
      this.tbxDob.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.linkLabel6.AutoSize = true;
      this.linkLabel6.LinkColor = Color.Maroon;
      this.linkLabel6.Location = new Point(522, 151);
      this.linkLabel6.Name = "linkLabel6";
      this.linkLabel6.Size = new Size(82, 13);
      this.linkLabel6.TabIndex = 73;
      this.linkLabel6.TabStop = true;
      this.linkLabel6.Text = "(Clear Selected)";
      this.linkLabel6.Click += new EventHandler(this.btnSpouseNameClear_Click);
      this.linkLabel5.AutoSize = true;
      this.linkLabel5.LinkColor = Color.Maroon;
      this.linkLabel5.Location = new Point(522, 84);
      this.linkLabel5.Name = "linkLabel5";
      this.linkLabel5.Size = new Size(82, 13);
      this.linkLabel5.TabIndex = 72;
      this.linkLabel5.TabStop = true;
      this.linkLabel5.Text = "(Clear Selected)";
      this.linkLabel5.Click += new EventHandler(this.btnMotherNameClear_Click);
      this.linkLabel4.AutoSize = true;
      this.linkLabel4.LinkColor = Color.Maroon;
      this.linkLabel4.Location = new Point(522, 18);
      this.linkLabel4.Name = "linkLabel4";
      this.linkLabel4.Size = new Size(82, 13);
      this.linkLabel4.TabIndex = 31;
      this.linkLabel4.TabStop = true;
      this.linkLabel4.Text = "(Clear Selected)";
      this.linkLabel4.Click += new EventHandler(this.btnFatherNameClear_Click);
      this.tbxSpouseNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseNameSearch.BackColor = Color.WhiteSmoke;
      this.tbxSpouseNameSearch.BorderStyle = BorderStyle.None;
      this.tbxSpouseNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseNameSearch.Location = new Point(681, 169);
      this.tbxSpouseNameSearch.Name = "tbxSpouseNameSearch";
      this.tbxSpouseNameSearch.Size = new Size(79, 24);
      this.tbxSpouseNameSearch.TabIndex = 11;
      this.tbxSpouseNameSearch.TextChanged += new EventHandler(this.tbxSpouseNameSearch_TextChanged);
      this.tbxSpouseNameSearch.KeyDown += new KeyEventHandler(this.tbxSpouseName_KeyDown);
      this.tbxMotherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherNameSearch.BackColor = Color.WhiteSmoke;
      this.tbxMotherNameSearch.BorderStyle = BorderStyle.None;
      this.tbxMotherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherNameSearch.Location = new Point(680, 111);
      this.tbxMotherNameSearch.Name = "tbxMotherNameSearch";
      this.tbxMotherNameSearch.Size = new Size(79, 24);
      this.tbxMotherNameSearch.TabIndex = 10;
      this.tbxMotherNameSearch.TextChanged += new EventHandler(this.tbxMotherNameSearch_TextChanged);
      this.tbxMotherNameSearch.KeyDown += new KeyEventHandler(this.tbxMotherName_KeyDown);
      this.tbxFatherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherNameSearch.BackColor = Color.WhiteSmoke;
      this.tbxFatherNameSearch.BorderStyle = BorderStyle.None;
      this.tbxFatherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherNameSearch.Location = new Point(681, 47);
      this.tbxFatherNameSearch.Name = "tbxFatherNameSearch";
      this.tbxFatherNameSearch.Size = new Size(79, 24);
      this.tbxFatherNameSearch.TabIndex = 9;
      this.tbxFatherNameSearch.TextChanged += new EventHandler(this.tbxFatherNameSearch_TextChanged);
      this.tbxFatherNameSearch.KeyDown += new KeyEventHandler(this.tbxFatherName_KeyDown);
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
      this.btnNext.Location = new Point(445, 545);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new Size(159, 51);
      this.btnNext.TabIndex = 17;
      this.btnNext.Text = "       &Next";
      this.btnNext.TextAlign = ContentAlignment.MiddleRight;
      this.btnNext.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnNext.UseVisualStyleBackColor = false;
      this.btnNext.Click += new EventHandler(this.btnNext_Click);
      this.btnNext.Enter += new EventHandler(this.button4_Enter);
      this.btnNext.Leave += new EventHandler(this.btnNext_Leave);
      this.panel62.BackColor = Color.OrangeRed;
      this.panel62.Location = new Point(402, 196);
      this.panel62.Name = "panel62";
      this.panel62.Size = new Size(359, 1);
      this.panel62.TabIndex = 65;
      this.tbxSpouseName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseName.BackColor = Color.WhiteSmoke;
      this.tbxSpouseName.BorderStyle = BorderStyle.None;
      this.tbxSpouseName.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseName.Location = new Point(402, 169);
      this.tbxSpouseName.Name = "tbxSpouseName";
      this.tbxSpouseName.Size = new Size(274, 24);
      this.tbxSpouseName.TabIndex = 21;
      this.tbxSpouseName.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.label42.AutoSize = true;
      this.label42.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label42.ForeColor = Color.FromArgb(238, 26, 74);
      this.label42.Location = new Point(399, 145);
      this.label42.Name = "label42";
      this.label42.Size = new Size(117, 21);
      this.label42.TabIndex = 64;
      this.label42.Text = "Spouse Name";
      this.panel63.BackColor = Color.OrangeRed;
      this.panel63.Location = new Point(16, 572);
      this.panel63.Name = "panel63";
      this.panel63.Size = new Size(359, 1);
      this.panel63.TabIndex = 62;
      this.tbxOccupation.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxOccupation.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxOccupation.BackColor = Color.WhiteSmoke;
      this.tbxOccupation.BorderStyle = BorderStyle.None;
      this.tbxOccupation.CharacterCasing = CharacterCasing.Upper;
      this.tbxOccupation.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOccupation.Location = new Point(16, 545);
      this.tbxOccupation.Name = "tbxOccupation";
      this.tbxOccupation.Size = new Size(359, 24);
      this.tbxOccupation.TabIndex = 8;
      this.tbxOccupation.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label44.AutoSize = true;
      this.label44.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label44.ForeColor = Color.FromArgb(238, 26, 74);
      this.label44.Location = new Point(13, 521);
      this.label44.Name = "label44";
      this.label44.Size = new Size(106, 21);
      this.label44.TabIndex = 61;
      this.label44.Text = "Occupation";
      this.panel3.BackColor = Color.OrangeRed;
      this.panel3.Location = new Point(401, 138);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(359, 1);
      this.panel3.TabIndex = 59;
      this.tbxMotherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherName.BackColor = Color.WhiteSmoke;
      this.tbxMotherName.BorderStyle = BorderStyle.None;
      this.tbxMotherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherName.Location = new Point(401, 110);
      this.tbxMotherName.Name = "tbxMotherName";
      this.tbxMotherName.Size = new Size(275, 24);
      this.tbxMotherName.TabIndex = 20;
      this.tbxMotherName.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel50.BackColor = Color.OrangeRed;
      this.panel50.Location = new Point(402, 73);
      this.panel50.Name = "panel50";
      this.panel50.Size = new Size(359, 1);
      this.panel50.TabIndex = 58;
      this.tbxFatherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherName.BackColor = Color.WhiteSmoke;
      this.tbxFatherName.BorderStyle = BorderStyle.None;
      this.tbxFatherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherName.Location = new Point(402, 46);
      this.tbxFatherName.Name = "tbxFatherName";
      this.tbxFatherName.Size = new Size(274, 24);
      this.tbxFatherName.TabIndex = 19;
      this.tbxFatherName.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel51.BackColor = Color.OrangeRed;
      this.panel51.Location = new Point(402, 327);
      this.panel51.Name = "panel51";
      this.panel51.Size = new Size(359, 1);
      this.panel51.TabIndex = 57;
      this.tbxMaritalStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMaritalStatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMaritalStatus.BackColor = Color.WhiteSmoke;
      this.tbxMaritalStatus.BorderStyle = BorderStyle.None;
      this.tbxMaritalStatus.CharacterCasing = CharacterCasing.Upper;
      this.tbxMaritalStatus.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMaritalStatus.Location = new Point(402, 300);
      this.tbxMaritalStatus.Name = "tbxMaritalStatus";
      this.tbxMaritalStatus.Size = new Size(359, 24);
      this.tbxMaritalStatus.TabIndex = 13;
      this.tbxMaritalStatus.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel53.BackColor = Color.OrangeRed;
      this.panel53.Location = new Point(403, 260);
      this.panel53.Name = "panel53";
      this.panel53.Size = new Size(359, 1);
      this.panel53.TabIndex = 55;
      this.tbxIntroducedBy.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxIntroducedBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxIntroducedBy.BackColor = Color.WhiteSmoke;
      this.tbxIntroducedBy.BorderStyle = BorderStyle.None;
      this.tbxIntroducedBy.CharacterCasing = CharacterCasing.Upper;
      this.tbxIntroducedBy.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxIntroducedBy.Location = new Point(403, 233);
      this.tbxIntroducedBy.Name = "tbxIntroducedBy";
      this.tbxIntroducedBy.Size = new Size(359, 24);
      this.tbxIntroducedBy.TabIndex = 12;
      this.tbxIntroducedBy.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel54.BackColor = Color.OrangeRed;
      this.panel54.Location = new Point(403, 519);
      this.panel54.Name = "panel54";
      this.panel54.Size = new Size(359, 1);
      this.panel54.TabIndex = 49;
      this.tbxInterestRAte.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxInterestRAte.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxInterestRAte.BackColor = Color.WhiteSmoke;
      this.tbxInterestRAte.BorderStyle = BorderStyle.None;
      this.tbxInterestRAte.CharacterCasing = CharacterCasing.Upper;
      this.tbxInterestRAte.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRAte.Location = new Point(403, 492);
      this.tbxInterestRAte.MaxLength = 3;
      this.tbxInterestRAte.Name = "tbxInterestRAte";
      this.tbxInterestRAte.Size = new Size(359, 24);
      this.tbxInterestRAte.TabIndex = 16;
      this.tbxInterestRAte.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxInterestRAte.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.panel55.BackColor = Color.OrangeRed;
      this.panel55.Location = new Point(404, 451);
      this.panel55.Name = "panel55";
      this.panel55.Size = new Size(359, 1);
      this.panel55.TabIndex = 54;
      this.tbxReligion.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxReligion.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxReligion.BackColor = Color.WhiteSmoke;
      this.tbxReligion.BorderStyle = BorderStyle.None;
      this.tbxReligion.CharacterCasing = CharacterCasing.Upper;
      this.tbxReligion.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReligion.Location = new Point(404, 424);
      this.tbxReligion.Name = "tbxReligion";
      this.tbxReligion.Size = new Size(359, 24);
      this.tbxReligion.TabIndex = 15;
      this.tbxReligion.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel56.BackColor = Color.OrangeRed;
      this.panel56.Location = new Point(403, 386);
      this.panel56.Name = "panel56";
      this.panel56.Size = new Size(359, 1);
      this.panel56.TabIndex = 43;
      this.tbxEducation.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxEducation.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxEducation.BackColor = Color.WhiteSmoke;
      this.tbxEducation.BorderStyle = BorderStyle.None;
      this.tbxEducation.CharacterCasing = CharacterCasing.Upper;
      this.tbxEducation.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxEducation.Location = new Point(403, 359);
      this.tbxEducation.Name = "tbxEducation";
      this.tbxEducation.Size = new Size(359, 24);
      this.tbxEducation.TabIndex = 14;
      this.tbxEducation.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.FromArgb(238, 26, 74);
      this.label2.Location = new Point(399, 331);
      this.label2.Name = "label2";
      this.label2.Size = new Size(91, 21);
      this.label2.TabIndex = 45;
      this.label2.Text = "Education";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.FromArgb(238, 26, 74);
      this.label3.Location = new Point(400, 392);
      this.label3.Name = "label3";
      this.label3.Size = new Size(70, 21);
      this.label3.TabIndex = 46;
      this.label3.Text = "Religion";
      this.label32.AutoSize = true;
      this.label32.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label32.ForeColor = Color.FromArgb(238, 26, 74);
      this.label32.Location = new Point(398, 78);
      this.label32.Name = "label32";
      this.label32.Size = new Size(119, 21);
      this.label32.TabIndex = 53;
      this.label32.Text = "Mother Name";
      this.label33.AutoSize = true;
      this.label33.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label33.ForeColor = Color.FromArgb(238, 26, 74);
      this.label33.Location = new Point(400, 458);
      this.label33.Name = "label33";
      this.label33.Size = new Size(112, 21);
      this.label33.TabIndex = 48;
      this.label33.Text = "Interest Rate";
      this.label34.AutoSize = true;
      this.label34.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label34.ForeColor = Color.FromArgb(238, 26, 74);
      this.label34.Location = new Point(398, 12);
      this.label34.Name = "label34";
      this.label34.Size = new Size(113, 21);
      this.label34.TabIndex = 52;
      this.label34.Text = "Father Name";
      this.label35.AutoSize = true;
      this.label35.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label35.ForeColor = Color.FromArgb(238, 26, 74);
      this.label35.Location = new Point(397, 203);
      this.label35.Name = "label35";
      this.label35.Size = new Size(120, 21);
      this.label35.TabIndex = 47;
      this.label35.Text = "Introduced By";
      this.label36.AutoSize = true;
      this.label36.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label36.ForeColor = Color.FromArgb(238, 26, 74);
      this.label36.Location = new Point(399, 265);
      this.label36.Name = "label36";
      this.label36.Size = new Size(114, 21);
      this.label36.TabIndex = 51;
      this.label36.Text = "MaritalStatus";
      this.panel11.BackColor = Color.OrangeRed;
      this.panel11.Location = new Point(15, 514);
      this.panel11.Name = "panel11";
      this.panel11.Size = new Size(359, 1);
      this.panel11.TabIndex = 35;
      this.tbxEmail.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxEmail.BackColor = Color.WhiteSmoke;
      this.tbxEmail.BorderStyle = BorderStyle.None;
      this.tbxEmail.CharacterCasing = CharacterCasing.Upper;
      this.tbxEmail.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxEmail.Location = new Point(15, 487);
      this.tbxEmail.Name = "tbxEmail";
      this.tbxEmail.Size = new Size(359, 24);
      this.tbxEmail.TabIndex = 7;
      this.tbxEmail.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel10.BackColor = Color.OrangeRed;
      this.panel10.Location = new Point(16, 458);
      this.panel10.Name = "panel10";
      this.panel10.Size = new Size(359, 1);
      this.panel10.TabIndex = 33;
      this.tbxNotes.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxNotes.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxNotes.BackColor = Color.WhiteSmoke;
      this.tbxNotes.BorderStyle = BorderStyle.None;
      this.tbxNotes.CharacterCasing = CharacterCasing.Upper;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(16, 431);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(359, 24);
      this.tbxNotes.TabIndex = 6;
      this.tbxNotes.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel9.BackColor = Color.OrangeRed;
      this.panel9.Location = new Point(15, 393);
      this.panel9.Name = "panel9";
      this.panel9.Size = new Size(359, 1);
      this.panel9.TabIndex = 31;
      this.tbxAlternateNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxAlternateNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAlternateNumber.BackColor = Color.WhiteSmoke;
      this.tbxAlternateNumber.BorderStyle = BorderStyle.None;
      this.tbxAlternateNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateNumber.Location = new Point(15, 366);
      this.tbxAlternateNumber.MaxLength = 11;
      this.tbxAlternateNumber.Name = "tbxAlternateNumber";
      this.tbxAlternateNumber.Size = new Size(359, 24);
      this.tbxAlternateNumber.TabIndex = 5;
      this.tbxAlternateNumber.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxAlternateNumber.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.panel8.BackColor = Color.OrangeRed;
      this.panel8.Location = new Point(16, 326);
      this.panel8.Name = "panel8";
      this.panel8.Size = new Size(359, 1);
      this.panel8.TabIndex = 29;
      this.tbxPhone.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPhone.BackColor = Color.WhiteSmoke;
      this.tbxPhone.BorderStyle = BorderStyle.None;
      this.tbxPhone.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhone.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhone.Location = new Point(16, 299);
      this.tbxPhone.MaxLength = 10;
      this.tbxPhone.Name = "tbxPhone";
      this.tbxPhone.Size = new Size(359, 24);
      this.tbxPhone.TabIndex = 4;
      this.tbxPhone.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxPhone.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxPhone.Validated += new EventHandler(this.tbxPhone_Validated);
      this.panel7.BackColor = Color.OrangeRed;
      this.panel7.Location = new Point(16, 260);
      this.panel7.Name = "panel7";
      this.panel7.Size = new Size(359, 1);
      this.panel7.TabIndex = 27;
      this.tbxSex.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSex.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSex.BackColor = Color.WhiteSmoke;
      this.tbxSex.BorderStyle = BorderStyle.None;
      this.tbxSex.CharacterCasing = CharacterCasing.Upper;
      this.tbxSex.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSex.Location = new Point(16, 233);
      this.tbxSex.Name = "tbxSex";
      this.tbxSex.Size = new Size(359, 24);
      this.tbxSex.TabIndex = 3;
      this.tbxSex.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxSex.KeyPress += new KeyPressEventHandler(this.tbxSex_KeyPress);
      this.tbxSex.Validating += new CancelEventHandler(this.tbxSex_Validating);
      this.panel6.BackColor = Color.OrangeRed;
      this.panel6.Location = new Point(15, 198);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(359, 1);
      this.panel6.TabIndex = 11;
      this.panel5.BackColor = Color.OrangeRed;
      this.panel5.Location = new Point(16, 130);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(359, 1);
      this.panel5.TabIndex = 23;
      this.tbxCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxCustomerName.BackColor = Color.WhiteSmoke;
      this.tbxCustomerName.BorderStyle = BorderStyle.None;
      this.tbxCustomerName.CharacterCasing = CharacterCasing.Upper;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(16, 103);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(359, 24);
      this.tbxCustomerName.TabIndex = 1;
      this.tbxCustomerName.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxCustomerName.KeyPress += new KeyPressEventHandler(this.tbxCustomerName_KeyPress);
      this.tbxCustomerName.Validating += new CancelEventHandler(this.tbxCustomerName_Validating);
      this.panel4.BackColor = Color.OrangeRed;
      this.panel4.Location = new Point(15, 65);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(359, 1);
      this.panel4.TabIndex = 6;
      this.tbxCustomerCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxCustomerCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxCustomerCode.BackColor = Color.WhiteSmoke;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(15, 38);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(359, 24);
      this.tbxCustomerCode.TabIndex = 0;
      this.tbxCustomerCode.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxCustomerCode.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.lblCustomerCode.AutoSize = true;
      this.lblCustomerCode.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblCustomerCode.ForeColor = Color.FromArgb(238, 26, 74);
      this.lblCustomerCode.Location = new Point(11, 10);
      this.lblCustomerCode.Name = "lblCustomerCode";
      this.lblCustomerCode.Size = new Size(144, 21);
      this.lblCustomerCode.TabIndex = 8;
      this.lblCustomerCode.Text = "Customer Code *";
      this.lblCustomerName.AutoSize = true;
      this.lblCustomerName.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblCustomerName.ForeColor = Color.FromArgb(238, 26, 74);
      this.lblCustomerName.Location = new Point(12, 71);
      this.lblCustomerName.Name = "lblCustomerName";
      this.lblCustomerName.Size = new Size(148, 21);
      this.lblCustomerName.TabIndex = 9;
      this.lblCustomerName.Text = "Customer Name *";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.FromArgb(238, 26, 74);
      this.label8.Location = new Point(12, 463);
      this.label8.Name = "label8";
      this.label8.Size = new Size(55, 21);
      this.label8.TabIndex = 15;
      this.label8.Text = "Email:";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.FromArgb(238, 26, 74);
      this.label5.Location = new Point(12, 137);
      this.label5.Name = "label5";
      this.label5.Size = new Size(111, 21);
      this.label5.TabIndex = 10;
      this.label5.Text = "Date Of Birth";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.FromArgb(238, 26, 74);
      this.label9.Location = new Point(12, 397);
      this.label9.Name = "label9";
      this.label9.Size = new Size((int) sbyte.MaxValue, 21);
      this.label9.TabIndex = 14;
      this.label9.Text = "Notes/Remarks";
      this.lblSex.AutoSize = true;
      this.lblSex.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSex.ForeColor = Color.FromArgb(238, 26, 74);
      this.lblSex.Location = new Point(12, 203);
      this.lblSex.Name = "lblSex";
      this.lblSex.Size = new Size(46, 21);
      this.lblSex.TabIndex = 10;
      this.lblSex.Text = "Sex *";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.FromArgb(238, 26, 74);
      this.label10.Location = new Point(12, 331);
      this.label10.Name = "label10";
      this.label10.Size = new Size(153, 21);
      this.label10.TabIndex = 13;
      this.label10.Text = "Alternate Number";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.FromArgb(238, 26, 74);
      this.label11.Location = new Point(12, 265);
      this.label11.Name = "label11";
      this.label11.Size = new Size(129, 21);
      this.label11.TabIndex = 12;
      this.label11.Text = "Mobile Number";
      this.tpResidentialAddress.BackColor = Color.Transparent;
      this.tpResidentialAddress.Controls.Add((Control) this.apnlResidentialAddress);
      this.tpResidentialAddress.Location = new Point(4, 5);
      this.tpResidentialAddress.Name = "tpResidentialAddress";
      this.tpResidentialAddress.Padding = new Padding(3);
      this.tpResidentialAddress.Size = new Size(807, 611);
      this.tpResidentialAddress.TabIndex = 1;
      this.tpResidentialAddress.Text = "tabPage2";
      this.apnlResidentialAddress.BackColor = Color.WhiteSmoke;
      this.apnlResidentialAddress.Controls.Add((Control) this.button3);
      this.apnlResidentialAddress.Controls.Add((Control) this.btnPrevious);
      this.apnlResidentialAddress.Controls.Add((Control) this.btnSave2);
      this.apnlResidentialAddress.Controls.Add((Control) this.pcbLocation);
      this.apnlResidentialAddress.Controls.Add((Control) this.pcbHouseType);
      this.apnlResidentialAddress.Controls.Add((Control) this.pcbOwnerShip);
      this.apnlResidentialAddress.Controls.Add((Control) this.label17);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel23);
      this.apnlResidentialAddress.Controls.Add((Control) this.label18);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel24);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel25);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxLandMark);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel27);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxPincode);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel28);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxCity);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel29);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel30);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxAddr2);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel31);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxAddr1);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel32);
      this.apnlResidentialAddress.Controls.Add((Control) this.ptbxDoorNumber);
      this.apnlResidentialAddress.Controls.Add((Control) this.label19);
      this.apnlResidentialAddress.Controls.Add((Control) this.label20);
      this.apnlResidentialAddress.Controls.Add((Control) this.label21);
      this.apnlResidentialAddress.Controls.Add((Control) this.label23);
      this.apnlResidentialAddress.Controls.Add((Control) this.label24);
      this.apnlResidentialAddress.Controls.Add((Control) this.label25);
      this.apnlResidentialAddress.Controls.Add((Control) this.cbLocation);
      this.apnlResidentialAddress.Controls.Add((Control) this.cbHouseType);
      this.apnlResidentialAddress.Controls.Add((Control) this.cbOwnerShip);
      this.apnlResidentialAddress.Controls.Add((Control) this.label16);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel22);
      this.apnlResidentialAddress.Controls.Add((Control) this.label7);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel21);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel13);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxLandMark);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel15);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxPincode);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel16);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxCity);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel17);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel18);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxAddr2);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel19);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxAddr1);
      this.apnlResidentialAddress.Controls.Add((Control) this.panel20);
      this.apnlResidentialAddress.Controls.Add((Control) this.tbxDoorNumber);
      this.apnlResidentialAddress.Controls.Add((Control) this.label1);
      this.apnlResidentialAddress.Controls.Add((Control) this.label4);
      this.apnlResidentialAddress.Controls.Add((Control) this.label6);
      this.apnlResidentialAddress.Controls.Add((Control) this.label13);
      this.apnlResidentialAddress.Controls.Add((Control) this.label14);
      this.apnlResidentialAddress.Controls.Add((Control) this.label15);
      this.apnlResidentialAddress.Dock = DockStyle.Fill;
      this.apnlResidentialAddress.Location = new Point(3, 3);
      this.apnlResidentialAddress.Name = "apnlResidentialAddress";
      this.apnlResidentialAddress.Size = new Size(801, 605);
      this.apnlResidentialAddress.TabIndex = 0;
      this.button3.BackColor = Color.Transparent;
      this.button3.FlatAppearance.BorderColor = Color.Black;
      this.button3.FlatAppearance.BorderSize = 0;
      this.button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.button3.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.button3.FlatStyle = FlatStyle.Popup;
      this.button3.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button3.ForeColor = Color.Black;
      this.button3.Image = (Image) componentResourceManager.GetObject("button3.Image");
      this.button3.ImageAlign = ContentAlignment.MiddleLeft;
      this.button3.Location = new Point(279, 548);
      this.button3.Name = "button3";
      this.button3.Size = new Size(159, 51);
      this.button3.TabIndex = 18;
      this.button3.Text = "       &Next";
      this.button3.TextAlign = ContentAlignment.MiddleRight;
      this.button3.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
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
      this.btnPrevious.Location = new Point(440, 548);
      this.btnPrevious.Name = "btnPrevious";
      this.btnPrevious.Size = new Size(159, 51);
      this.btnPrevious.TabIndex = 19;
      this.btnPrevious.Text = "       &Previous";
      this.btnPrevious.TextAlign = ContentAlignment.MiddleRight;
      this.btnPrevious.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnPrevious.UseVisualStyleBackColor = false;
      this.btnPrevious.Click += new EventHandler(this.btnPrevious_Click);
      this.btnSave2.BackColor = Color.Transparent;
      this.btnSave2.FlatAppearance.BorderColor = Color.Black;
      this.btnSave2.FlatAppearance.BorderSize = 0;
      this.btnSave2.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnSave2.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnSave2.FlatStyle = FlatStyle.Popup;
      this.btnSave2.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave2.ForeColor = Color.Black;
      this.btnSave2.Image = (Image) componentResourceManager.GetObject("btnSave2.Image");
      this.btnSave2.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSave2.Location = new Point(603, 548);
      this.btnSave2.Name = "btnSave2";
      this.btnSave2.Size = new Size(159, 51);
      this.btnSave2.TabIndex = 20;
      this.btnSave2.Text = "       &Save";
      this.btnSave2.TextAlign = ContentAlignment.MiddleRight;
      this.btnSave2.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnSave2.UseVisualStyleBackColor = false;
      this.btnSave2.Click += new EventHandler(this.btnSave2_Click);
      this.pcbLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.pcbLocation.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.pcbLocation.BackColor = Color.WhiteSmoke;
      this.pcbLocation.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.pcbLocation.FormattingEnabled = true;
      this.pcbLocation.Location = new Point(409, 206);
      this.pcbLocation.Name = "pcbLocation";
      this.pcbLocation.Size = new Size(358, 28);
      this.pcbLocation.TabIndex = 12;
      this.pcbLocation.SelectedIndexChanged += new EventHandler(this.pcbLocation_SelectedIndexChanged);
      this.pcbLocation.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.pcbLocation.Validating += new CancelEventHandler(this.pcbLocation_Validating);
      this.pcbHouseType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.pcbHouseType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.pcbHouseType.BackColor = Color.WhiteSmoke;
      this.pcbHouseType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.pcbHouseType.FormattingEnabled = true;
      this.pcbHouseType.Items.AddRange(new object[6]
      {
        (object) "INDIVIDUAL HOUSE",
        (object) "FLATS",
        (object) "VILLA",
        (object) "HOUSING BOARD",
        (object) "GATED COMMUNITY",
        (object) "HOSTEL"
      });
      this.pcbHouseType.Location = new Point(408, 452);
      this.pcbHouseType.Name = "pcbHouseType";
      this.pcbHouseType.Size = new Size(358, 28);
      this.pcbHouseType.TabIndex = 16;
      this.pcbHouseType.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.pcbOwnerShip.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.pcbOwnerShip.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.pcbOwnerShip.BackColor = Color.WhiteSmoke;
      this.pcbOwnerShip.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.pcbOwnerShip.FormattingEnabled = true;
      this.pcbOwnerShip.Items.AddRange(new object[2]
      {
        (object) "OWN",
        (object) "RENT"
      });
      this.pcbOwnerShip.Location = new Point(406, 514);
      this.pcbOwnerShip.Name = "pcbOwnerShip";
      this.pcbOwnerShip.Size = new Size(358, 28);
      this.pcbOwnerShip.TabIndex = 17;
      this.pcbOwnerShip.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.FromArgb(238, 26, 74);
      this.label17.Location = new Point(402, 491);
      this.label17.Name = "label17";
      this.label17.Size = new Size(95, 21);
      this.label17.TabIndex = 70;
      this.label17.Text = "OwnerShip";
      this.panel23.BackColor = Color.OrangeRed;
      this.panel23.Location = new Point(405, 544);
      this.panel23.Name = "panel23";
      this.panel23.Size = new Size(359, 1);
      this.panel23.TabIndex = 69;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.FromArgb(238, 26, 74);
      this.label18.Location = new Point(405, 429);
      this.label18.Name = "label18";
      this.label18.Size = new Size(180, 21);
      this.label18.TabIndex = 68;
      this.label18.Text = "Individual House/Flats";
      this.panel24.BackColor = Color.OrangeRed;
      this.panel24.Location = new Point(408, 482);
      this.panel24.Name = "panel24";
      this.panel24.Size = new Size(359, 1);
      this.panel24.TabIndex = 67;
      this.panel25.BackColor = Color.OrangeRed;
      this.panel25.Location = new Point(408, 424);
      this.panel25.Name = "panel25";
      this.panel25.Size = new Size(359, 1);
      this.panel25.TabIndex = 66;
      this.ptbxLandMark.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxLandMark.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxLandMark.BackColor = Color.WhiteSmoke;
      this.ptbxLandMark.BorderStyle = BorderStyle.None;
      this.ptbxLandMark.CharacterCasing = CharacterCasing.Upper;
      this.ptbxLandMark.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxLandMark.Location = new Point(408, 397);
      this.ptbxLandMark.Name = "ptbxLandMark";
      this.ptbxLandMark.Size = new Size(359, 24);
      this.ptbxLandMark.TabIndex = 15;
      this.ptbxLandMark.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel27.BackColor = Color.OrangeRed;
      this.panel27.Location = new Point(408, 367);
      this.panel27.Name = "panel27";
      this.panel27.Size = new Size(359, 1);
      this.panel27.TabIndex = 64;
      this.ptbxPincode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxPincode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxPincode.BackColor = Color.WhiteSmoke;
      this.ptbxPincode.BorderStyle = BorderStyle.None;
      this.ptbxPincode.CharacterCasing = CharacterCasing.Upper;
      this.ptbxPincode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxPincode.Location = new Point(408, 340);
      this.ptbxPincode.MaxLength = 6;
      this.ptbxPincode.Name = "ptbxPincode";
      this.ptbxPincode.Size = new Size(359, 24);
      this.ptbxPincode.TabIndex = 14;
      this.ptbxPincode.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.ptbxPincode.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel28.BackColor = Color.OrangeRed;
      this.panel28.Location = new Point(409, 300);
      this.panel28.Name = "panel28";
      this.panel28.Size = new Size(359, 1);
      this.panel28.TabIndex = 63;
      this.ptbxCity.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxCity.BackColor = Color.WhiteSmoke;
      this.ptbxCity.BorderStyle = BorderStyle.None;
      this.ptbxCity.CharacterCasing = CharacterCasing.Upper;
      this.ptbxCity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxCity.Location = new Point(409, 271);
      this.ptbxCity.Name = "ptbxCity";
      this.ptbxCity.Size = new Size(359, 24);
      this.ptbxCity.TabIndex = 13;
      this.ptbxCity.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.ptbxCity.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel29.BackColor = Color.OrangeRed;
      this.panel29.Location = new Point(409, 236);
      this.panel29.Name = "panel29";
      this.panel29.Size = new Size(359, 1);
      this.panel29.TabIndex = 62;
      this.panel30.BackColor = Color.OrangeRed;
      this.panel30.Location = new Point(408, 174);
      this.panel30.Name = "panel30";
      this.panel30.Size = new Size(359, 1);
      this.panel30.TabIndex = 56;
      this.ptbxAddr2.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxAddr2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxAddr2.BackColor = Color.WhiteSmoke;
      this.ptbxAddr2.BorderStyle = BorderStyle.None;
      this.ptbxAddr2.CharacterCasing = CharacterCasing.Upper;
      this.ptbxAddr2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxAddr2.Location = new Point(408, 147);
      this.ptbxAddr2.Name = "ptbxAddr2";
      this.ptbxAddr2.Size = new Size(359, 24);
      this.ptbxAddr2.TabIndex = 11;
      this.ptbxAddr2.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel31.BackColor = Color.OrangeRed;
      this.panel31.Location = new Point(409, 130);
      this.panel31.Name = "panel31";
      this.panel31.Size = new Size(359, 1);
      this.panel31.TabIndex = 61;
      this.ptbxAddr1.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxAddr1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxAddr1.BackColor = Color.WhiteSmoke;
      this.ptbxAddr1.BorderStyle = BorderStyle.None;
      this.ptbxAddr1.CharacterCasing = CharacterCasing.Upper;
      this.ptbxAddr1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxAddr1.Location = new Point(409, 103);
      this.ptbxAddr1.Name = "ptbxAddr1";
      this.ptbxAddr1.Size = new Size(359, 24);
      this.ptbxAddr1.TabIndex = 10;
      this.ptbxAddr1.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.ptbxAddr1.Validating += new CancelEventHandler(this.ptbxAddr1_Validating);
      this.panel32.BackColor = Color.OrangeRed;
      this.panel32.Location = new Point(408, 65);
      this.panel32.Name = "panel32";
      this.panel32.Size = new Size(359, 1);
      this.panel32.TabIndex = 49;
      this.ptbxDoorNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.ptbxDoorNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.ptbxDoorNumber.BackColor = Color.WhiteSmoke;
      this.ptbxDoorNumber.BorderStyle = BorderStyle.None;
      this.ptbxDoorNumber.CharacterCasing = CharacterCasing.Upper;
      this.ptbxDoorNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ptbxDoorNumber.Location = new Point(408, 38);
      this.ptbxDoorNumber.Name = "ptbxDoorNumber";
      this.ptbxDoorNumber.Size = new Size(359, 24);
      this.ptbxDoorNumber.TabIndex = 9;
      this.ptbxDoorNumber.Text = "NO : ";
      this.ptbxDoorNumber.Enter += new EventHandler(this.tbxDoorNumber_Enter);
      this.ptbxDoorNumber.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.FromArgb(238, 26, 74);
      this.label19.Location = new Point(404, 10);
      this.label19.Name = "label19";
      this.label19.Size = new Size(120, 21);
      this.label19.TabIndex = 51;
      this.label19.Text = "DoorNumber *";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.FromArgb(238, 26, 74);
      this.label20.Location = new Point(405, 71);
      this.label20.Name = "label20";
      this.label20.Size = new Size(82, 21);
      this.label20.TabIndex = 53;
      this.label20.Text = "Address *";
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.FromArgb(238, 26, 74);
      this.label21.Location = new Point(405, 373);
      this.label21.Name = "label21";
      this.label21.Size = new Size(88, 21);
      this.label21.TabIndex = 60;
      this.label21.Text = "LandMark";
      this.label23.AutoSize = true;
      this.label23.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label23.ForeColor = Color.FromArgb(238, 26, 74);
      this.label23.Location = new Point(405, 179);
      this.label23.Name = "label23";
      this.label23.Size = new Size(88, 21);
      this.label23.TabIndex = 55;
      this.label23.Text = "Location *";
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label24.ForeColor = Color.FromArgb(238, 26, 74);
      this.label24.Location = new Point(405, 305);
      this.label24.Name = "label24";
      this.label24.Size = new Size(73, 21);
      this.label24.TabIndex = 58;
      this.label24.Text = "Pincode";
      this.label25.AutoSize = true;
      this.label25.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label25.ForeColor = Color.FromArgb(238, 26, 74);
      this.label25.Location = new Point(405, 243);
      this.label25.Name = "label25";
      this.label25.Size = new Size(41, 21);
      this.label25.TabIndex = 57;
      this.label25.Text = "City";
      this.cbLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbLocation.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbLocation.BackColor = Color.WhiteSmoke;
      this.cbLocation.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbLocation.FormattingEnabled = true;
      this.cbLocation.Location = new Point(16, 206);
      this.cbLocation.Name = "cbLocation";
      this.cbLocation.Size = new Size(358, 28);
      this.cbLocation.TabIndex = 3;
      this.cbLocation.SelectedIndexChanged += new EventHandler(this.cbLocation_SelectedIndexChanged);
      this.cbLocation.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.cbLocation.Validating += new CancelEventHandler(this.cbLocation_Validating);
      this.cbHouseType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbHouseType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbHouseType.BackColor = Color.WhiteSmoke;
      this.cbHouseType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbHouseType.FormattingEnabled = true;
      this.cbHouseType.Items.AddRange(new object[6]
      {
        (object) "INDIVIDUAL HOUSE",
        (object) "FLATS",
        (object) "VILLA",
        (object) "HOUSING BOARD",
        (object) "GATED COMMUNITY",
        (object) "HOSTEL"
      });
      this.cbHouseType.Location = new Point(15, 452);
      this.cbHouseType.Name = "cbHouseType";
      this.cbHouseType.Size = new Size(358, 28);
      this.cbHouseType.TabIndex = 7;
      this.cbHouseType.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.cbOwnerShip.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbOwnerShip.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbOwnerShip.BackColor = Color.WhiteSmoke;
      this.cbOwnerShip.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbOwnerShip.FormattingEnabled = true;
      this.cbOwnerShip.Items.AddRange(new object[2]
      {
        (object) "OWN",
        (object) "RENT"
      });
      this.cbOwnerShip.Location = new Point(13, 514);
      this.cbOwnerShip.Name = "cbOwnerShip";
      this.cbOwnerShip.Size = new Size(358, 28);
      this.cbOwnerShip.TabIndex = 8;
      this.cbOwnerShip.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.FromArgb(238, 26, 74);
      this.label16.Location = new Point(9, 491);
      this.label16.Name = "label16";
      this.label16.Size = new Size(95, 21);
      this.label16.TabIndex = 41;
      this.label16.Text = "OwnerShip";
      this.panel22.BackColor = Color.OrangeRed;
      this.panel22.Location = new Point(12, 544);
      this.panel22.Name = "panel22";
      this.panel22.Size = new Size(359, 1);
      this.panel22.TabIndex = 40;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.FromArgb(238, 26, 74);
      this.label7.Location = new Point(12, 429);
      this.label7.Name = "label7";
      this.label7.Size = new Size(180, 21);
      this.label7.TabIndex = 38;
      this.label7.Text = "Individual House/Flats";
      this.panel21.BackColor = Color.OrangeRed;
      this.panel21.Location = new Point(15, 482);
      this.panel21.Name = "panel21";
      this.panel21.Size = new Size(359, 1);
      this.panel21.TabIndex = 37;
      this.panel13.BackColor = Color.OrangeRed;
      this.panel13.Location = new Point(15, 424);
      this.panel13.Name = "panel13";
      this.panel13.Size = new Size(359, 1);
      this.panel13.TabIndex = 35;
      this.tbxLandMark.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxLandMark.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxLandMark.BackColor = Color.WhiteSmoke;
      this.tbxLandMark.BorderStyle = BorderStyle.None;
      this.tbxLandMark.CharacterCasing = CharacterCasing.Upper;
      this.tbxLandMark.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxLandMark.Location = new Point(15, 397);
      this.tbxLandMark.Name = "tbxLandMark";
      this.tbxLandMark.Size = new Size(359, 24);
      this.tbxLandMark.TabIndex = 6;
      this.tbxLandMark.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel15.BackColor = Color.OrangeRed;
      this.panel15.Location = new Point(15, 367);
      this.panel15.Name = "panel15";
      this.panel15.Size = new Size(359, 1);
      this.panel15.TabIndex = 31;
      this.tbxPincode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxPincode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPincode.BackColor = Color.WhiteSmoke;
      this.tbxPincode.BorderStyle = BorderStyle.None;
      this.tbxPincode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(15, 340);
      this.tbxPincode.MaxLength = 6;
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(359, 24);
      this.tbxPincode.TabIndex = 5;
      this.tbxPincode.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxPincode.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel16.BackColor = Color.OrangeRed;
      this.panel16.Location = new Point(16, 300);
      this.panel16.Name = "panel16";
      this.panel16.Size = new Size(359, 1);
      this.panel16.TabIndex = 29;
      this.tbxCity.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxCity.BackColor = Color.WhiteSmoke;
      this.tbxCity.BorderStyle = BorderStyle.None;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(16, 268);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(359, 24);
      this.tbxCity.TabIndex = 4;
      this.tbxCity.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxCity.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoINPUT);
      this.panel17.BackColor = Color.OrangeRed;
      this.panel17.Location = new Point(16, 236);
      this.panel17.Name = "panel17";
      this.panel17.Size = new Size(359, 1);
      this.panel17.TabIndex = 27;
      this.panel18.BackColor = Color.OrangeRed;
      this.panel18.Location = new Point(15, 174);
      this.panel18.Name = "panel18";
      this.panel18.Size = new Size(359, 1);
      this.panel18.TabIndex = 11;
      this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxAddr2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr2.BackColor = Color.WhiteSmoke;
      this.tbxAddr2.BorderStyle = BorderStyle.None;
      this.tbxAddr2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr2.Location = new Point(15, 147);
      this.tbxAddr2.Name = "tbxAddr2";
      this.tbxAddr2.Size = new Size(359, 24);
      this.tbxAddr2.TabIndex = 2;
      this.tbxAddr2.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel19.BackColor = Color.OrangeRed;
      this.panel19.Location = new Point(16, 130);
      this.panel19.Name = "panel19";
      this.panel19.Size = new Size(359, 1);
      this.panel19.TabIndex = 23;
      this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxAddr1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr1.BackColor = Color.WhiteSmoke;
      this.tbxAddr1.BorderStyle = BorderStyle.None;
      this.tbxAddr1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr1.Location = new Point(16, 103);
      this.tbxAddr1.Name = "tbxAddr1";
      this.tbxAddr1.Size = new Size(359, 24);
      this.tbxAddr1.TabIndex = 1;
      this.tbxAddr1.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.tbxAddr1.Validating += new CancelEventHandler(this.tbxAddr1_Validating);
      this.panel20.BackColor = Color.OrangeRed;
      this.panel20.Location = new Point(15, 65);
      this.panel20.Name = "panel20";
      this.panel20.Size = new Size(359, 1);
      this.panel20.TabIndex = 6;
      this.tbxDoorNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxDoorNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxDoorNumber.BackColor = Color.WhiteSmoke;
      this.tbxDoorNumber.BorderStyle = BorderStyle.None;
      this.tbxDoorNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxDoorNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDoorNumber.Location = new Point(15, 38);
      this.tbxDoorNumber.Name = "tbxDoorNumber";
      this.tbxDoorNumber.Size = new Size(359, 24);
      this.tbxDoorNumber.TabIndex = 0;
      this.tbxDoorNumber.Text = "NO : ";
      this.tbxDoorNumber.Enter += new EventHandler(this.tbxDoorNumber_Enter);
      this.tbxDoorNumber.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.FromArgb(238, 26, 74);
      this.label1.Location = new Point(11, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(120, 21);
      this.label1.TabIndex = 8;
      this.label1.Text = "DoorNumber *";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.FromArgb(238, 26, 74);
      this.label4.Location = new Point(12, 71);
      this.label4.Name = "label4";
      this.label4.Size = new Size(82, 21);
      this.label4.TabIndex = 9;
      this.label4.Text = "Address *";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.FromArgb(238, 26, 74);
      this.label6.Location = new Point(12, 373);
      this.label6.Name = "label6";
      this.label6.Size = new Size(88, 21);
      this.label6.TabIndex = 15;
      this.label6.Text = "LandMark";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.FromArgb(238, 26, 74);
      this.label13.Location = new Point(12, 179);
      this.label13.Name = "label13";
      this.label13.Size = new Size(88, 21);
      this.label13.TabIndex = 10;
      this.label13.Text = "Location *";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.FromArgb(238, 26, 74);
      this.label14.Location = new Point(12, 305);
      this.label14.Name = "label14";
      this.label14.Size = new Size(73, 21);
      this.label14.TabIndex = 13;
      this.label14.Text = "Pincode";
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.FromArgb(238, 26, 74);
      this.label15.Location = new Point(12, 243);
      this.label15.Name = "label15";
      this.label15.Size = new Size(41, 21);
      this.label15.TabIndex = 12;
      this.label15.Text = "City";
      this.tpProof.Controls.Add((Control) this.apnlProof);
      this.tpProof.Location = new Point(4, 5);
      this.tpProof.Name = "tpProof";
      this.tpProof.Padding = new Padding(3);
      this.tpProof.Size = new Size(807, 611);
      this.tpProof.TabIndex = 3;
      this.tpProof.Text = "tabPage4";
      this.tpProof.UseVisualStyleBackColor = true;
      this.apnlProof.BackColor = Color.WhiteSmoke;
      this.apnlProof.Controls.Add((Control) this.button1);
      this.apnlProof.Controls.Add((Control) this.button2);
      this.apnlProof.Controls.Add((Control) this.lbDevices);
      this.apnlProof.Controls.Add((Control) this.panel14);
      this.apnlProof.Controls.Add((Control) this.tbxOthers);
      this.apnlProof.Controls.Add((Control) this.label12);
      this.apnlProof.Controls.Add((Control) this.panel57);
      this.apnlProof.Controls.Add((Control) this.tbxRationCard);
      this.apnlProof.Controls.Add((Control) this.panel58);
      this.apnlProof.Controls.Add((Control) this.tbxDrivingLicense);
      this.apnlProof.Controls.Add((Control) this.panel59);
      this.apnlProof.Controls.Add((Control) this.tbxVoterId);
      this.apnlProof.Controls.Add((Control) this.panel60);
      this.apnlProof.Controls.Add((Control) this.tbxPanCard);
      this.apnlProof.Controls.Add((Control) this.panel61);
      this.apnlProof.Controls.Add((Control) this.tbxAadharNumber);
      this.apnlProof.Controls.Add((Control) this.label38);
      this.apnlProof.Controls.Add((Control) this.label39);
      this.apnlProof.Controls.Add((Control) this.label40);
      this.apnlProof.Controls.Add((Control) this.label41);
      this.apnlProof.Controls.Add((Control) this.label43);
      this.apnlProof.Controls.Add((Control) this.panel44);
      this.apnlProof.Controls.Add((Control) this.panel45);
      this.apnlProof.Controls.Add((Control) this.panel47);
      this.apnlProof.Controls.Add((Control) this.panel48);
      this.apnlProof.Controls.Add((Control) this.panel38);
      this.apnlProof.Controls.Add((Control) this.panel39);
      this.apnlProof.Controls.Add((Control) this.panel41);
      this.apnlProof.Controls.Add((Control) this.panel42);
      this.apnlProof.Controls.Add((Control) this.panel35);
      this.apnlProof.Controls.Add((Control) this.panel36);
      this.apnlProof.Controls.Add((Control) this.panel33);
      this.apnlProof.Controls.Add((Control) this.pbPanCardBack);
      this.apnlProof.Controls.Add((Control) this.panel49);
      this.apnlProof.Controls.Add((Control) this.pbPanCardFront);
      this.apnlProof.Controls.Add((Control) this.pbDrivingLicenseBack);
      this.apnlProof.Controls.Add((Control) this.panel46);
      this.apnlProof.Controls.Add((Control) this.pbDrivingLicenseFront);
      this.apnlProof.Controls.Add((Control) this.pbOthersBack);
      this.apnlProof.Controls.Add((Control) this.panel43);
      this.apnlProof.Controls.Add((Control) this.pbOthersFront);
      this.apnlProof.Controls.Add((Control) this.pbRationCardBack);
      this.apnlProof.Controls.Add((Control) this.panel40);
      this.apnlProof.Controls.Add((Control) this.pbRationCardFront);
      this.apnlProof.Controls.Add((Control) this.pbVoterIdBack);
      this.apnlProof.Controls.Add((Control) this.panel37);
      this.apnlProof.Controls.Add((Control) this.pbVoterIdFront);
      this.apnlProof.Controls.Add((Control) this.pbAadharBack);
      this.apnlProof.Controls.Add((Control) this.panel12);
      this.apnlProof.Controls.Add((Control) this.panel34);
      this.apnlProof.Controls.Add((Control) this.pbAadharFront);
      this.apnlProof.Dock = DockStyle.Fill;
      this.apnlProof.Location = new Point(3, 3);
      this.apnlProof.Name = "apnlProof";
      this.apnlProof.Size = new Size(801, 605);
      this.apnlProof.TabIndex = 43;
      this.button1.BackColor = Color.Transparent;
      this.button1.FlatAppearance.BorderColor = Color.Black;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.button1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.button1.FlatStyle = FlatStyle.Popup;
      this.button1.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.Black;
      this.button1.Image = (Image) componentResourceManager.GetObject("button1.Image");
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(623, 488);
      this.button1.Name = "button1";
      this.button1.Size = new Size(159, 51);
      this.button1.TabIndex = 114;
      this.button1.Text = "       &Previous";
      this.button1.TextAlign = ContentAlignment.MiddleRight;
      this.button1.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click_1);
      this.button2.BackColor = Color.Transparent;
      this.button2.FlatAppearance.BorderColor = Color.Black;
      this.button2.FlatAppearance.BorderSize = 0;
      this.button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.button2.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.button2.FlatStyle = FlatStyle.Popup;
      this.button2.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = Color.Black;
      this.button2.Image = (Image) componentResourceManager.GetObject("button2.Image");
      this.button2.ImageAlign = ContentAlignment.MiddleLeft;
      this.button2.Location = new Point(623, 545);
      this.button2.Name = "button2";
      this.button2.Size = new Size(159, 51);
      this.button2.TabIndex = 113;
      this.button2.Text = "       &Save";
      this.button2.TextAlign = ContentAlignment.MiddleRight;
      this.button2.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.btnSave2_Click);
      this.lbDevices.FormattingEnabled = true;
      this.lbDevices.Location = new Point(623, 397);
      this.lbDevices.Name = "lbDevices";
      this.lbDevices.Size = new Size(159, 82);
      this.lbDevices.TabIndex = 112;
      this.panel14.BackColor = Color.OrangeRed;
      this.panel14.Location = new Point(519, 385);
      this.panel14.Name = "panel14";
      this.panel14.Size = new Size(263, 1);
      this.panel14.TabIndex = 111;
      this.tbxOthers.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxOthers.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxOthers.BackColor = Color.WhiteSmoke;
      this.tbxOthers.BorderStyle = BorderStyle.None;
      this.tbxOthers.CharacterCasing = CharacterCasing.Upper;
      this.tbxOthers.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOthers.Location = new Point(519, 358);
      this.tbxOthers.Name = "tbxOthers";
      this.tbxOthers.Size = new Size(263, 24);
      this.tbxOthers.TabIndex = 5;
      this.tbxOthers.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.FromArgb(238, 26, 74);
      this.label12.Location = new Point(515, 324);
      this.label12.Name = "label12";
      this.label12.Size = new Size(62, 21);
      this.label12.TabIndex = 110;
      this.label12.Text = "Others";
      this.panel57.BackColor = Color.OrangeRed;
      this.panel57.Location = new Point(520, 320);
      this.panel57.Name = "panel57";
      this.panel57.Size = new Size(263, 1);
      this.panel57.TabIndex = 108;
      this.tbxRationCard.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxRationCard.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxRationCard.BackColor = Color.WhiteSmoke;
      this.tbxRationCard.BorderStyle = BorderStyle.None;
      this.tbxRationCard.CharacterCasing = CharacterCasing.Upper;
      this.tbxRationCard.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRationCard.Location = new Point(520, 293);
      this.tbxRationCard.Name = "tbxRationCard";
      this.tbxRationCard.Size = new Size(263, 24);
      this.tbxRationCard.TabIndex = 4;
      this.tbxRationCard.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel58.BackColor = Color.OrangeRed;
      this.panel58.Location = new Point(520, 254);
      this.panel58.Name = "panel58";
      this.panel58.Size = new Size(263, 1);
      this.panel58.TabIndex = 107;
      this.tbxDrivingLicense.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxDrivingLicense.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxDrivingLicense.BackColor = Color.WhiteSmoke;
      this.tbxDrivingLicense.BorderStyle = BorderStyle.None;
      this.tbxDrivingLicense.CharacterCasing = CharacterCasing.Upper;
      this.tbxDrivingLicense.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDrivingLicense.Location = new Point(520, 227);
      this.tbxDrivingLicense.Name = "tbxDrivingLicense";
      this.tbxDrivingLicense.Size = new Size(263, 24);
      this.tbxDrivingLicense.TabIndex = 3;
      this.tbxDrivingLicense.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel59.BackColor = Color.OrangeRed;
      this.panel59.Location = new Point(519, 192);
      this.panel59.Name = "panel59";
      this.panel59.Size = new Size(263, 1);
      this.panel59.TabIndex = 103;
      this.tbxVoterId.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxVoterId.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxVoterId.BackColor = Color.WhiteSmoke;
      this.tbxVoterId.BorderStyle = BorderStyle.None;
      this.tbxVoterId.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoterId.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxVoterId.Location = new Point(519, 165);
      this.tbxVoterId.Name = "tbxVoterId";
      this.tbxVoterId.Size = new Size(263, 24);
      this.tbxVoterId.TabIndex = 2;
      this.tbxVoterId.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel60.BackColor = Color.OrangeRed;
      this.panel60.Location = new Point(520, 124);
      this.panel60.Name = "panel60";
      this.panel60.Size = new Size(263, 1);
      this.panel60.TabIndex = 106;
      this.tbxPanCard.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxPanCard.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPanCard.BackColor = Color.WhiteSmoke;
      this.tbxPanCard.BorderStyle = BorderStyle.None;
      this.tbxPanCard.CharacterCasing = CharacterCasing.Upper;
      this.tbxPanCard.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPanCard.Location = new Point(520, 97);
      this.tbxPanCard.Name = "tbxPanCard";
      this.tbxPanCard.Size = new Size(263, 24);
      this.tbxPanCard.TabIndex = 1;
      this.tbxPanCard.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.panel61.BackColor = Color.OrangeRed;
      this.panel61.Location = new Point(519, 59);
      this.panel61.Name = "panel61";
      this.panel61.Size = new Size(263, 1);
      this.panel61.TabIndex = 98;
      this.tbxAadharNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxAadharNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAadharNumber.BackColor = Color.WhiteSmoke;
      this.tbxAadharNumber.BorderStyle = BorderStyle.None;
      this.tbxAadharNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxAadharNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAadharNumber.Location = new Point(519, 32);
      this.tbxAadharNumber.Name = "tbxAadharNumber";
      this.tbxAadharNumber.Size = new Size(263, 24);
      this.tbxAadharNumber.TabIndex = 0;
      this.tbxAadharNumber.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
      this.label38.AutoSize = true;
      this.label38.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label38.ForeColor = Color.FromArgb(238, 26, 74);
      this.label38.Location = new Point(515, 4);
      this.label38.Name = "label38";
      this.label38.Size = new Size((int) sbyte.MaxValue, 21);
      this.label38.TabIndex = 99;
      this.label38.Text = "Adhar Number";
      this.label39.AutoSize = true;
      this.label39.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label39.ForeColor = Color.FromArgb(238, 26, 74);
      this.label39.Location = new Point(516, 65);
      this.label39.Name = "label39";
      this.label39.Size = new Size(84, 21);
      this.label39.TabIndex = 100;
      this.label39.Text = "Pan Card";
      this.label40.AutoSize = true;
      this.label40.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label40.ForeColor = Color.FromArgb(238, 26, 74);
      this.label40.Location = new Point(516, 131);
      this.label40.Name = "label40";
      this.label40.Size = new Size(73, 21);
      this.label40.TabIndex = 102;
      this.label40.Text = "Voter Id";
      this.label41.AutoSize = true;
      this.label41.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label41.ForeColor = Color.FromArgb(238, 26, 74);
      this.label41.Location = new Point(516, 197);
      this.label41.Name = "label41";
      this.label41.Size = new Size(124, 21);
      this.label41.TabIndex = 101;
      this.label41.Text = "Driving License";
      this.label43.AutoSize = true;
      this.label43.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label43.ForeColor = Color.FromArgb(238, 26, 74);
      this.label43.Location = new Point(516, 259);
      this.label43.Name = "label43";
      this.label43.Size = new Size(105, 21);
      this.label43.TabIndex = 104;
      this.label43.Text = "Ration Card";
      this.panel44.BackColor = Color.WhiteSmoke;
      this.panel44.Controls.Add((Control) this.pbDeleteOthersBack);
      this.panel44.Controls.Add((Control) this.pbCameraOthersBack);
      this.panel44.Controls.Add((Control) this.pbScanOthersBack);
      this.panel44.Controls.Add((Control) this.pbSelectOthersBack);
      this.panel44.Location = new Point(387, 578);
      this.panel44.Name = "panel44";
      this.panel44.Size = new Size(122, 30);
      this.panel44.TabIndex = 92;
      this.pbDeleteOthersBack.BackColor = Color.Transparent;
      this.pbDeleteOthersBack.Cursor = Cursors.Hand;
      this.pbDeleteOthersBack.Image = (Image) componentResourceManager.GetObject("pbDeleteOthersBack.Image");
      this.pbDeleteOthersBack.Location = new Point(91, 2);
      this.pbDeleteOthersBack.Name = "pbDeleteOthersBack";
      this.pbDeleteOthersBack.Size = new Size(25, 23);
      this.pbDeleteOthersBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteOthersBack.TabIndex = 61;
      this.pbDeleteOthersBack.TabStop = false;
      this.pbDeleteOthersBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraOthersBack.BackColor = Color.Transparent;
      this.pbCameraOthersBack.Cursor = Cursors.Hand;
      this.pbCameraOthersBack.Image = (Image) componentResourceManager.GetObject("pbCameraOthersBack.Image");
      this.pbCameraOthersBack.Location = new Point(60, 2);
      this.pbCameraOthersBack.Name = "pbCameraOthersBack";
      this.pbCameraOthersBack.Size = new Size(25, 23);
      this.pbCameraOthersBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraOthersBack.TabIndex = 58;
      this.pbCameraOthersBack.TabStop = false;
      this.pbCameraOthersBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanOthersBack.BackColor = Color.Transparent;
      this.pbScanOthersBack.Cursor = Cursors.Hand;
      this.pbScanOthersBack.Image = (Image) componentResourceManager.GetObject("pbScanOthersBack.Image");
      this.pbScanOthersBack.Location = new Point(32, 2);
      this.pbScanOthersBack.Name = "pbScanOthersBack";
      this.pbScanOthersBack.Size = new Size(25, 23);
      this.pbScanOthersBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanOthersBack.TabIndex = 57;
      this.pbScanOthersBack.TabStop = false;
      this.pbScanOthersBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectOthersBack.BackColor = Color.Transparent;
      this.pbSelectOthersBack.Cursor = Cursors.Hand;
      this.pbSelectOthersBack.Image = (Image) componentResourceManager.GetObject("pbSelectOthersBack.Image");
      this.pbSelectOthersBack.Location = new Point(5, 2);
      this.pbSelectOthersBack.Name = "pbSelectOthersBack";
      this.pbSelectOthersBack.Size = new Size(25, 23);
      this.pbSelectOthersBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectOthersBack.TabIndex = 56;
      this.pbSelectOthersBack.TabStop = false;
      this.pbSelectOthersBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel45.BackColor = Color.WhiteSmoke;
      this.panel45.Controls.Add((Control) this.pbDeleteOthersFront);
      this.panel45.Controls.Add((Control) this.pbCameraOthersFront);
      this.panel45.Controls.Add((Control) this.pbScanOthersFront);
      this.panel45.Controls.Add((Control) this.pbSelectOthersFront);
      this.panel45.Location = new Point(259, 578);
      this.panel45.Name = "panel45";
      this.panel45.Size = new Size(122, 30);
      this.panel45.TabIndex = 91;
      this.pbDeleteOthersFront.BackColor = Color.Transparent;
      this.pbDeleteOthersFront.Cursor = Cursors.Hand;
      this.pbDeleteOthersFront.Image = (Image) componentResourceManager.GetObject("pbDeleteOthersFront.Image");
      this.pbDeleteOthersFront.Location = new Point(91, 2);
      this.pbDeleteOthersFront.Name = "pbDeleteOthersFront";
      this.pbDeleteOthersFront.Size = new Size(25, 23);
      this.pbDeleteOthersFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteOthersFront.TabIndex = 61;
      this.pbDeleteOthersFront.TabStop = false;
      this.pbDeleteOthersFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraOthersFront.BackColor = Color.Transparent;
      this.pbCameraOthersFront.Cursor = Cursors.Hand;
      this.pbCameraOthersFront.Image = (Image) componentResourceManager.GetObject("pbCameraOthersFront.Image");
      this.pbCameraOthersFront.Location = new Point(60, 2);
      this.pbCameraOthersFront.Name = "pbCameraOthersFront";
      this.pbCameraOthersFront.Size = new Size(25, 23);
      this.pbCameraOthersFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraOthersFront.TabIndex = 58;
      this.pbCameraOthersFront.TabStop = false;
      this.pbCameraOthersFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanOthersFront.BackColor = Color.Transparent;
      this.pbScanOthersFront.Cursor = Cursors.Hand;
      this.pbScanOthersFront.Image = (Image) componentResourceManager.GetObject("pbScanOthersFront.Image");
      this.pbScanOthersFront.Location = new Point(32, 2);
      this.pbScanOthersFront.Name = "pbScanOthersFront";
      this.pbScanOthersFront.Size = new Size(25, 23);
      this.pbScanOthersFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanOthersFront.TabIndex = 57;
      this.pbScanOthersFront.TabStop = false;
      this.pbScanOthersFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectOthersFront.BackColor = Color.Transparent;
      this.pbSelectOthersFront.Cursor = Cursors.Hand;
      this.pbSelectOthersFront.Image = (Image) componentResourceManager.GetObject("pbSelectOthersFront.Image");
      this.pbSelectOthersFront.Location = new Point(5, 2);
      this.pbSelectOthersFront.Name = "pbSelectOthersFront";
      this.pbSelectOthersFront.Size = new Size(25, 23);
      this.pbSelectOthersFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectOthersFront.TabIndex = 56;
      this.pbSelectOthersFront.TabStop = false;
      this.pbSelectOthersFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel47.BackColor = Color.WhiteSmoke;
      this.panel47.Controls.Add((Control) this.pbDeleteRationCardBack);
      this.panel47.Controls.Add((Control) this.pbCameraRationCardBack);
      this.panel47.Controls.Add((Control) this.pbScanRationCardBack);
      this.panel47.Controls.Add((Control) this.pbSelectRationCardBack);
      this.panel47.Location = new Point(131, 578);
      this.panel47.Name = "panel47";
      this.panel47.Size = new Size(122, 30);
      this.panel47.TabIndex = 90;
      this.pbDeleteRationCardBack.BackColor = Color.Transparent;
      this.pbDeleteRationCardBack.Cursor = Cursors.Hand;
      this.pbDeleteRationCardBack.Image = (Image) componentResourceManager.GetObject("pbDeleteRationCardBack.Image");
      this.pbDeleteRationCardBack.Location = new Point(91, 2);
      this.pbDeleteRationCardBack.Name = "pbDeleteRationCardBack";
      this.pbDeleteRationCardBack.Size = new Size(25, 23);
      this.pbDeleteRationCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteRationCardBack.TabIndex = 61;
      this.pbDeleteRationCardBack.TabStop = false;
      this.pbDeleteRationCardBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraRationCardBack.BackColor = Color.Transparent;
      this.pbCameraRationCardBack.Cursor = Cursors.Hand;
      this.pbCameraRationCardBack.Image = (Image) componentResourceManager.GetObject("pbCameraRationCardBack.Image");
      this.pbCameraRationCardBack.Location = new Point(60, 2);
      this.pbCameraRationCardBack.Name = "pbCameraRationCardBack";
      this.pbCameraRationCardBack.Size = new Size(25, 23);
      this.pbCameraRationCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraRationCardBack.TabIndex = 58;
      this.pbCameraRationCardBack.TabStop = false;
      this.pbCameraRationCardBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanRationCardBack.BackColor = Color.Transparent;
      this.pbScanRationCardBack.Cursor = Cursors.Hand;
      this.pbScanRationCardBack.Image = (Image) componentResourceManager.GetObject("pbScanRationCardBack.Image");
      this.pbScanRationCardBack.Location = new Point(32, 2);
      this.pbScanRationCardBack.Name = "pbScanRationCardBack";
      this.pbScanRationCardBack.Size = new Size(25, 23);
      this.pbScanRationCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanRationCardBack.TabIndex = 57;
      this.pbScanRationCardBack.TabStop = false;
      this.pbScanRationCardBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectRationCardBack.BackColor = Color.Transparent;
      this.pbSelectRationCardBack.Cursor = Cursors.Hand;
      this.pbSelectRationCardBack.Image = (Image) componentResourceManager.GetObject("pbSelectRationCardBack.Image");
      this.pbSelectRationCardBack.Location = new Point(5, 2);
      this.pbSelectRationCardBack.Name = "pbSelectRationCardBack";
      this.pbSelectRationCardBack.Size = new Size(25, 23);
      this.pbSelectRationCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectRationCardBack.TabIndex = 56;
      this.pbSelectRationCardBack.TabStop = false;
      this.pbSelectRationCardBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel48.BackColor = Color.WhiteSmoke;
      this.panel48.Controls.Add((Control) this.pbDeleteRationCardFront);
      this.panel48.Controls.Add((Control) this.pbCameraRationCardFront);
      this.panel48.Controls.Add((Control) this.pbScanRationCardFront);
      this.panel48.Controls.Add((Control) this.pbSelectRationCardFront);
      this.panel48.Location = new Point(3, 578);
      this.panel48.Name = "panel48";
      this.panel48.Size = new Size(122, 30);
      this.panel48.TabIndex = 89;
      this.pbDeleteRationCardFront.BackColor = Color.Transparent;
      this.pbDeleteRationCardFront.Cursor = Cursors.Hand;
      this.pbDeleteRationCardFront.Image = (Image) componentResourceManager.GetObject("pbDeleteRationCardFront.Image");
      this.pbDeleteRationCardFront.Location = new Point(91, 2);
      this.pbDeleteRationCardFront.Name = "pbDeleteRationCardFront";
      this.pbDeleteRationCardFront.Size = new Size(25, 23);
      this.pbDeleteRationCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteRationCardFront.TabIndex = 61;
      this.pbDeleteRationCardFront.TabStop = false;
      this.pbDeleteRationCardFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraRationCardFront.BackColor = Color.Transparent;
      this.pbCameraRationCardFront.Cursor = Cursors.Hand;
      this.pbCameraRationCardFront.Image = (Image) componentResourceManager.GetObject("pbCameraRationCardFront.Image");
      this.pbCameraRationCardFront.Location = new Point(60, 2);
      this.pbCameraRationCardFront.Name = "pbCameraRationCardFront";
      this.pbCameraRationCardFront.Size = new Size(25, 23);
      this.pbCameraRationCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraRationCardFront.TabIndex = 58;
      this.pbCameraRationCardFront.TabStop = false;
      this.pbCameraRationCardFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanRationCardFront.BackColor = Color.Transparent;
      this.pbScanRationCardFront.Cursor = Cursors.Hand;
      this.pbScanRationCardFront.Image = (Image) componentResourceManager.GetObject("pbScanRationCardFront.Image");
      this.pbScanRationCardFront.Location = new Point(32, 2);
      this.pbScanRationCardFront.Name = "pbScanRationCardFront";
      this.pbScanRationCardFront.Size = new Size(25, 23);
      this.pbScanRationCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanRationCardFront.TabIndex = 57;
      this.pbScanRationCardFront.TabStop = false;
      this.pbScanRationCardFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectRationCardFront.BackColor = Color.Transparent;
      this.pbSelectRationCardFront.Cursor = Cursors.Hand;
      this.pbSelectRationCardFront.Image = (Image) componentResourceManager.GetObject("pbSelectRationCardFront.Image");
      this.pbSelectRationCardFront.Location = new Point(5, 2);
      this.pbSelectRationCardFront.Name = "pbSelectRationCardFront";
      this.pbSelectRationCardFront.Size = new Size(25, 23);
      this.pbSelectRationCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectRationCardFront.TabIndex = 56;
      this.pbSelectRationCardFront.TabStop = false;
      this.pbSelectRationCardFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel38.BackColor = Color.WhiteSmoke;
      this.panel38.Controls.Add((Control) this.pbDeleteDrivingLicenseBack);
      this.panel38.Controls.Add((Control) this.pbCameraDrivingLicenseBack);
      this.panel38.Controls.Add((Control) this.pbScanDrivingLicenseBack);
      this.panel38.Controls.Add((Control) this.pbSelectDrivingLicenseBack);
      this.panel38.Location = new Point(387, 374);
      this.panel38.Name = "panel38";
      this.panel38.Size = new Size(122, 30);
      this.panel38.TabIndex = 88;
      this.pbDeleteDrivingLicenseBack.BackColor = Color.Transparent;
      this.pbDeleteDrivingLicenseBack.Cursor = Cursors.Hand;
      this.pbDeleteDrivingLicenseBack.Image = (Image) componentResourceManager.GetObject("pbDeleteDrivingLicenseBack.Image");
      this.pbDeleteDrivingLicenseBack.Location = new Point(91, 2);
      this.pbDeleteDrivingLicenseBack.Name = "pbDeleteDrivingLicenseBack";
      this.pbDeleteDrivingLicenseBack.Size = new Size(25, 23);
      this.pbDeleteDrivingLicenseBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteDrivingLicenseBack.TabIndex = 61;
      this.pbDeleteDrivingLicenseBack.TabStop = false;
      this.pbDeleteDrivingLicenseBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraDrivingLicenseBack.BackColor = Color.Transparent;
      this.pbCameraDrivingLicenseBack.Cursor = Cursors.Hand;
      this.pbCameraDrivingLicenseBack.Image = (Image) componentResourceManager.GetObject("pbCameraDrivingLicenseBack.Image");
      this.pbCameraDrivingLicenseBack.Location = new Point(60, 2);
      this.pbCameraDrivingLicenseBack.Name = "pbCameraDrivingLicenseBack";
      this.pbCameraDrivingLicenseBack.Size = new Size(25, 23);
      this.pbCameraDrivingLicenseBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraDrivingLicenseBack.TabIndex = 58;
      this.pbCameraDrivingLicenseBack.TabStop = false;
      this.pbCameraDrivingLicenseBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanDrivingLicenseBack.BackColor = Color.Transparent;
      this.pbScanDrivingLicenseBack.Cursor = Cursors.Hand;
      this.pbScanDrivingLicenseBack.Image = (Image) componentResourceManager.GetObject("pbScanDrivingLicenseBack.Image");
      this.pbScanDrivingLicenseBack.Location = new Point(32, 2);
      this.pbScanDrivingLicenseBack.Name = "pbScanDrivingLicenseBack";
      this.pbScanDrivingLicenseBack.Size = new Size(25, 23);
      this.pbScanDrivingLicenseBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanDrivingLicenseBack.TabIndex = 57;
      this.pbScanDrivingLicenseBack.TabStop = false;
      this.pbScanDrivingLicenseBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectDrivingLicenseBack.BackColor = Color.Transparent;
      this.pbSelectDrivingLicenseBack.Cursor = Cursors.Hand;
      this.pbSelectDrivingLicenseBack.Image = (Image) componentResourceManager.GetObject("pbSelectDrivingLicenseBack.Image");
      this.pbSelectDrivingLicenseBack.Location = new Point(5, 2);
      this.pbSelectDrivingLicenseBack.Name = "pbSelectDrivingLicenseBack";
      this.pbSelectDrivingLicenseBack.Size = new Size(25, 23);
      this.pbSelectDrivingLicenseBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectDrivingLicenseBack.TabIndex = 56;
      this.pbSelectDrivingLicenseBack.TabStop = false;
      this.pbSelectDrivingLicenseBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel39.BackColor = Color.WhiteSmoke;
      this.panel39.Controls.Add((Control) this.pbDeleteDrivingLicenseFront);
      this.panel39.Controls.Add((Control) this.pbCameraDrivingLicenseFront);
      this.panel39.Controls.Add((Control) this.pbScanDrivingLicenseFront);
      this.panel39.Controls.Add((Control) this.pbSelectDrivingLicenseFront);
      this.panel39.Location = new Point(259, 374);
      this.panel39.Name = "panel39";
      this.panel39.Size = new Size(122, 30);
      this.panel39.TabIndex = 87;
      this.pbDeleteDrivingLicenseFront.BackColor = Color.Transparent;
      this.pbDeleteDrivingLicenseFront.Cursor = Cursors.Hand;
      this.pbDeleteDrivingLicenseFront.Image = (Image) componentResourceManager.GetObject("pbDeleteDrivingLicenseFront.Image");
      this.pbDeleteDrivingLicenseFront.Location = new Point(91, 2);
      this.pbDeleteDrivingLicenseFront.Name = "pbDeleteDrivingLicenseFront";
      this.pbDeleteDrivingLicenseFront.Size = new Size(25, 23);
      this.pbDeleteDrivingLicenseFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteDrivingLicenseFront.TabIndex = 61;
      this.pbDeleteDrivingLicenseFront.TabStop = false;
      this.pbDeleteDrivingLicenseFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraDrivingLicenseFront.BackColor = Color.Transparent;
      this.pbCameraDrivingLicenseFront.Cursor = Cursors.Hand;
      this.pbCameraDrivingLicenseFront.Image = (Image) componentResourceManager.GetObject("pbCameraDrivingLicenseFront.Image");
      this.pbCameraDrivingLicenseFront.Location = new Point(60, 2);
      this.pbCameraDrivingLicenseFront.Name = "pbCameraDrivingLicenseFront";
      this.pbCameraDrivingLicenseFront.Size = new Size(25, 23);
      this.pbCameraDrivingLicenseFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraDrivingLicenseFront.TabIndex = 58;
      this.pbCameraDrivingLicenseFront.TabStop = false;
      this.pbCameraDrivingLicenseFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanDrivingLicenseFront.BackColor = Color.Transparent;
      this.pbScanDrivingLicenseFront.Cursor = Cursors.Hand;
      this.pbScanDrivingLicenseFront.Image = (Image) componentResourceManager.GetObject("pbScanDrivingLicenseFront.Image");
      this.pbScanDrivingLicenseFront.Location = new Point(32, 2);
      this.pbScanDrivingLicenseFront.Name = "pbScanDrivingLicenseFront";
      this.pbScanDrivingLicenseFront.Size = new Size(25, 23);
      this.pbScanDrivingLicenseFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanDrivingLicenseFront.TabIndex = 57;
      this.pbScanDrivingLicenseFront.TabStop = false;
      this.pbScanDrivingLicenseFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectDrivingLicenseFront.BackColor = Color.Transparent;
      this.pbSelectDrivingLicenseFront.Cursor = Cursors.Hand;
      this.pbSelectDrivingLicenseFront.Image = (Image) componentResourceManager.GetObject("pbSelectDrivingLicenseFront.Image");
      this.pbSelectDrivingLicenseFront.Location = new Point(5, 2);
      this.pbSelectDrivingLicenseFront.Name = "pbSelectDrivingLicenseFront";
      this.pbSelectDrivingLicenseFront.Size = new Size(25, 23);
      this.pbSelectDrivingLicenseFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectDrivingLicenseFront.TabIndex = 56;
      this.pbSelectDrivingLicenseFront.TabStop = false;
      this.pbSelectDrivingLicenseFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel41.BackColor = Color.WhiteSmoke;
      this.panel41.Controls.Add((Control) this.pbDeleteVoterIdBack);
      this.panel41.Controls.Add((Control) this.pbCameraVoterIdBack);
      this.panel41.Controls.Add((Control) this.pbScanVoterIdBack);
      this.panel41.Controls.Add((Control) this.pbSelectVoterIdBack);
      this.panel41.Location = new Point(131, 374);
      this.panel41.Name = "panel41";
      this.panel41.Size = new Size(122, 30);
      this.panel41.TabIndex = 86;
      this.pbDeleteVoterIdBack.BackColor = Color.Transparent;
      this.pbDeleteVoterIdBack.Cursor = Cursors.Hand;
      this.pbDeleteVoterIdBack.Image = (Image) componentResourceManager.GetObject("pbDeleteVoterIdBack.Image");
      this.pbDeleteVoterIdBack.Location = new Point(91, 2);
      this.pbDeleteVoterIdBack.Name = "pbDeleteVoterIdBack";
      this.pbDeleteVoterIdBack.Size = new Size(25, 23);
      this.pbDeleteVoterIdBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteVoterIdBack.TabIndex = 61;
      this.pbDeleteVoterIdBack.TabStop = false;
      this.pbDeleteVoterIdBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraVoterIdBack.BackColor = Color.Transparent;
      this.pbCameraVoterIdBack.Cursor = Cursors.Hand;
      this.pbCameraVoterIdBack.Image = (Image) componentResourceManager.GetObject("pbCameraVoterIdBack.Image");
      this.pbCameraVoterIdBack.Location = new Point(60, 2);
      this.pbCameraVoterIdBack.Name = "pbCameraVoterIdBack";
      this.pbCameraVoterIdBack.Size = new Size(25, 23);
      this.pbCameraVoterIdBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraVoterIdBack.TabIndex = 58;
      this.pbCameraVoterIdBack.TabStop = false;
      this.pbCameraVoterIdBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanVoterIdBack.BackColor = Color.Transparent;
      this.pbScanVoterIdBack.Cursor = Cursors.Hand;
      this.pbScanVoterIdBack.Image = (Image) componentResourceManager.GetObject("pbScanVoterIdBack.Image");
      this.pbScanVoterIdBack.Location = new Point(32, 2);
      this.pbScanVoterIdBack.Name = "pbScanVoterIdBack";
      this.pbScanVoterIdBack.Size = new Size(25, 23);
      this.pbScanVoterIdBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanVoterIdBack.TabIndex = 57;
      this.pbScanVoterIdBack.TabStop = false;
      this.pbScanVoterIdBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectVoterIdBack.BackColor = Color.Transparent;
      this.pbSelectVoterIdBack.Cursor = Cursors.Hand;
      this.pbSelectVoterIdBack.Image = (Image) componentResourceManager.GetObject("pbSelectVoterIdBack.Image");
      this.pbSelectVoterIdBack.Location = new Point(5, 2);
      this.pbSelectVoterIdBack.Name = "pbSelectVoterIdBack";
      this.pbSelectVoterIdBack.Size = new Size(25, 23);
      this.pbSelectVoterIdBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectVoterIdBack.TabIndex = 56;
      this.pbSelectVoterIdBack.TabStop = false;
      this.pbSelectVoterIdBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel42.BackColor = Color.WhiteSmoke;
      this.panel42.Controls.Add((Control) this.pbDeleteVoterIdFront);
      this.panel42.Controls.Add((Control) this.pbCameraVoterIdFront);
      this.panel42.Controls.Add((Control) this.pbScanVoterIdFront);
      this.panel42.Controls.Add((Control) this.pbSelectVoterIdFront);
      this.panel42.Location = new Point(3, 374);
      this.panel42.Name = "panel42";
      this.panel42.Size = new Size(122, 30);
      this.panel42.TabIndex = 85;
      this.pbDeleteVoterIdFront.BackColor = Color.Transparent;
      this.pbDeleteVoterIdFront.Cursor = Cursors.Hand;
      this.pbDeleteVoterIdFront.Image = (Image) componentResourceManager.GetObject("pbDeleteVoterIdFront.Image");
      this.pbDeleteVoterIdFront.Location = new Point(91, 2);
      this.pbDeleteVoterIdFront.Name = "pbDeleteVoterIdFront";
      this.pbDeleteVoterIdFront.Size = new Size(25, 23);
      this.pbDeleteVoterIdFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteVoterIdFront.TabIndex = 61;
      this.pbDeleteVoterIdFront.TabStop = false;
      this.pbDeleteVoterIdFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraVoterIdFront.BackColor = Color.Transparent;
      this.pbCameraVoterIdFront.Cursor = Cursors.Hand;
      this.pbCameraVoterIdFront.Image = (Image) componentResourceManager.GetObject("pbCameraVoterIdFront.Image");
      this.pbCameraVoterIdFront.Location = new Point(60, 2);
      this.pbCameraVoterIdFront.Name = "pbCameraVoterIdFront";
      this.pbCameraVoterIdFront.Size = new Size(25, 23);
      this.pbCameraVoterIdFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraVoterIdFront.TabIndex = 58;
      this.pbCameraVoterIdFront.TabStop = false;
      this.pbCameraVoterIdFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanVoterIdFront.BackColor = Color.Transparent;
      this.pbScanVoterIdFront.Cursor = Cursors.Hand;
      this.pbScanVoterIdFront.Image = (Image) componentResourceManager.GetObject("pbScanVoterIdFront.Image");
      this.pbScanVoterIdFront.Location = new Point(32, 2);
      this.pbScanVoterIdFront.Name = "pbScanVoterIdFront";
      this.pbScanVoterIdFront.Size = new Size(25, 23);
      this.pbScanVoterIdFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanVoterIdFront.TabIndex = 57;
      this.pbScanVoterIdFront.TabStop = false;
      this.pbScanVoterIdFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectVoterIdFront.BackColor = Color.Transparent;
      this.pbSelectVoterIdFront.Cursor = Cursors.Hand;
      this.pbSelectVoterIdFront.Image = (Image) componentResourceManager.GetObject("pbSelectVoterIdFront.Image");
      this.pbSelectVoterIdFront.Location = new Point(5, 2);
      this.pbSelectVoterIdFront.Name = "pbSelectVoterIdFront";
      this.pbSelectVoterIdFront.Size = new Size(25, 23);
      this.pbSelectVoterIdFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectVoterIdFront.TabIndex = 56;
      this.pbSelectVoterIdFront.TabStop = false;
      this.pbSelectVoterIdFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel35.BackColor = Color.WhiteSmoke;
      this.panel35.Controls.Add((Control) this.pbDeletePanBack);
      this.panel35.Controls.Add((Control) this.pbCamPanBack);
      this.panel35.Controls.Add((Control) this.pbScanPanBack);
      this.panel35.Controls.Add((Control) this.pbSelectPanBack);
      this.panel35.Location = new Point(387, 170);
      this.panel35.Name = "panel35";
      this.panel35.Size = new Size(122, 30);
      this.panel35.TabIndex = 84;
      this.pbDeletePanBack.BackColor = Color.Transparent;
      this.pbDeletePanBack.Cursor = Cursors.Hand;
      this.pbDeletePanBack.Image = (Image) componentResourceManager.GetObject("pbDeletePanBack.Image");
      this.pbDeletePanBack.Location = new Point(91, 2);
      this.pbDeletePanBack.Name = "pbDeletePanBack";
      this.pbDeletePanBack.Size = new Size(25, 23);
      this.pbDeletePanBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeletePanBack.TabIndex = 61;
      this.pbDeletePanBack.TabStop = false;
      this.pbDeletePanBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCamPanBack.BackColor = Color.Transparent;
      this.pbCamPanBack.Cursor = Cursors.Hand;
      this.pbCamPanBack.Image = (Image) componentResourceManager.GetObject("pbCamPanBack.Image");
      this.pbCamPanBack.Location = new Point(60, 2);
      this.pbCamPanBack.Name = "pbCamPanBack";
      this.pbCamPanBack.Size = new Size(25, 23);
      this.pbCamPanBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCamPanBack.TabIndex = 58;
      this.pbCamPanBack.TabStop = false;
      this.pbCamPanBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanPanBack.BackColor = Color.Transparent;
      this.pbScanPanBack.Cursor = Cursors.Hand;
      this.pbScanPanBack.Image = (Image) componentResourceManager.GetObject("pbScanPanBack.Image");
      this.pbScanPanBack.Location = new Point(32, 2);
      this.pbScanPanBack.Name = "pbScanPanBack";
      this.pbScanPanBack.Size = new Size(25, 23);
      this.pbScanPanBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanPanBack.TabIndex = 57;
      this.pbScanPanBack.TabStop = false;
      this.pbScanPanBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectPanBack.BackColor = Color.Transparent;
      this.pbSelectPanBack.Cursor = Cursors.Hand;
      this.pbSelectPanBack.Image = (Image) componentResourceManager.GetObject("pbSelectPanBack.Image");
      this.pbSelectPanBack.Location = new Point(5, 2);
      this.pbSelectPanBack.Name = "pbSelectPanBack";
      this.pbSelectPanBack.Size = new Size(25, 23);
      this.pbSelectPanBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectPanBack.TabIndex = 56;
      this.pbSelectPanBack.TabStop = false;
      this.pbSelectPanBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel36.BackColor = Color.WhiteSmoke;
      this.panel36.Controls.Add((Control) this.pbDeletePanFront);
      this.panel36.Controls.Add((Control) this.pbCameraPanFront);
      this.panel36.Controls.Add((Control) this.pbScanPanFront);
      this.panel36.Controls.Add((Control) this.pbSelectPanFront);
      this.panel36.Location = new Point(259, 170);
      this.panel36.Name = "panel36";
      this.panel36.Size = new Size(122, 30);
      this.panel36.TabIndex = 83;
      this.pbDeletePanFront.BackColor = Color.Transparent;
      this.pbDeletePanFront.Cursor = Cursors.Hand;
      this.pbDeletePanFront.Image = (Image) componentResourceManager.GetObject("pbDeletePanFront.Image");
      this.pbDeletePanFront.Location = new Point(91, 2);
      this.pbDeletePanFront.Name = "pbDeletePanFront";
      this.pbDeletePanFront.Size = new Size(25, 23);
      this.pbDeletePanFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeletePanFront.TabIndex = 61;
      this.pbDeletePanFront.TabStop = false;
      this.pbDeletePanFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraPanFront.BackColor = Color.Transparent;
      this.pbCameraPanFront.Cursor = Cursors.Hand;
      this.pbCameraPanFront.Image = (Image) componentResourceManager.GetObject("pbCameraPanFront.Image");
      this.pbCameraPanFront.Location = new Point(60, 2);
      this.pbCameraPanFront.Name = "pbCameraPanFront";
      this.pbCameraPanFront.Size = new Size(25, 23);
      this.pbCameraPanFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraPanFront.TabIndex = 58;
      this.pbCameraPanFront.TabStop = false;
      this.pbCameraPanFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanPanFront.BackColor = Color.Transparent;
      this.pbScanPanFront.Cursor = Cursors.Hand;
      this.pbScanPanFront.Image = (Image) componentResourceManager.GetObject("pbScanPanFront.Image");
      this.pbScanPanFront.Location = new Point(32, 2);
      this.pbScanPanFront.Name = "pbScanPanFront";
      this.pbScanPanFront.Size = new Size(25, 23);
      this.pbScanPanFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanPanFront.TabIndex = 57;
      this.pbScanPanFront.TabStop = false;
      this.pbScanPanFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectPanFront.BackColor = Color.Transparent;
      this.pbSelectPanFront.Cursor = Cursors.Hand;
      this.pbSelectPanFront.Image = (Image) componentResourceManager.GetObject("pbSelectPanFront.Image");
      this.pbSelectPanFront.Location = new Point(5, 2);
      this.pbSelectPanFront.Name = "pbSelectPanFront";
      this.pbSelectPanFront.Size = new Size(25, 23);
      this.pbSelectPanFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectPanFront.TabIndex = 56;
      this.pbSelectPanFront.TabStop = false;
      this.pbSelectPanFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel33.BackColor = Color.WhiteSmoke;
      this.panel33.Controls.Add((Control) this.pbDeleteAadharBack);
      this.panel33.Controls.Add((Control) this.pbCameraAadharBack);
      this.panel33.Controls.Add((Control) this.pbScanAadharBack);
      this.panel33.Controls.Add((Control) this.pbSelectAadharBack);
      this.panel33.Location = new Point(131, 170);
      this.panel33.Name = "panel33";
      this.panel33.Size = new Size(122, 30);
      this.panel33.TabIndex = 62;
      this.pbDeleteAadharBack.BackColor = Color.Transparent;
      this.pbDeleteAadharBack.Cursor = Cursors.Hand;
      this.pbDeleteAadharBack.Image = (Image) componentResourceManager.GetObject("pbDeleteAadharBack.Image");
      this.pbDeleteAadharBack.Location = new Point(91, 2);
      this.pbDeleteAadharBack.Name = "pbDeleteAadharBack";
      this.pbDeleteAadharBack.Size = new Size(25, 23);
      this.pbDeleteAadharBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteAadharBack.TabIndex = 61;
      this.pbDeleteAadharBack.TabStop = false;
      this.pbDeleteAadharBack.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraAadharBack.BackColor = Color.Transparent;
      this.pbCameraAadharBack.Cursor = Cursors.Hand;
      this.pbCameraAadharBack.Image = (Image) componentResourceManager.GetObject("pbCameraAadharBack.Image");
      this.pbCameraAadharBack.Location = new Point(60, 2);
      this.pbCameraAadharBack.Name = "pbCameraAadharBack";
      this.pbCameraAadharBack.Size = new Size(25, 23);
      this.pbCameraAadharBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraAadharBack.TabIndex = 58;
      this.pbCameraAadharBack.TabStop = false;
      this.pbCameraAadharBack.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanAadharBack.BackColor = Color.Transparent;
      this.pbScanAadharBack.Cursor = Cursors.Hand;
      this.pbScanAadharBack.Image = (Image) componentResourceManager.GetObject("pbScanAadharBack.Image");
      this.pbScanAadharBack.Location = new Point(32, 2);
      this.pbScanAadharBack.Name = "pbScanAadharBack";
      this.pbScanAadharBack.Size = new Size(25, 23);
      this.pbScanAadharBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanAadharBack.TabIndex = 57;
      this.pbScanAadharBack.TabStop = false;
      this.pbScanAadharBack.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectAadharBack.BackColor = Color.Transparent;
      this.pbSelectAadharBack.Cursor = Cursors.Hand;
      this.pbSelectAadharBack.Image = (Image) componentResourceManager.GetObject("pbSelectAadharBack.Image");
      this.pbSelectAadharBack.Location = new Point(5, 2);
      this.pbSelectAadharBack.Name = "pbSelectAadharBack";
      this.pbSelectAadharBack.Size = new Size(25, 23);
      this.pbSelectAadharBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectAadharBack.TabIndex = 56;
      this.pbSelectAadharBack.TabStop = false;
      this.pbSelectAadharBack.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.pbPanCardBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbPanCardBack.Location = new Point(387, 25);
      this.pbPanCardBack.Name = "pbPanCardBack";
      this.pbPanCardBack.Size = new Size(122, 142);
      this.pbPanCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbPanCardBack.TabIndex = 82;
      this.pbPanCardBack.TabStop = false;
      this.panel49.BackColor = Color.Black;
      this.panel49.Controls.Add((Control) this.label31);
      this.panel49.Location = new Point(259, -1);
      this.panel49.Name = "panel49";
      this.panel49.Size = new Size(250, 24);
      this.panel49.TabIndex = 80;
      this.label31.AutoSize = true;
      this.label31.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label31.ForeColor = Color.Snow;
      this.label31.Location = new Point(87, 0);
      this.label31.Name = "label31";
      this.label31.Size = new Size(96, 21);
      this.label31.TabIndex = 10;
      this.label31.Text = "PAN CARD";
      this.pbPanCardFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbPanCardFront.Location = new Point(259, 25);
      this.pbPanCardFront.Name = "pbPanCardFront";
      this.pbPanCardFront.Size = new Size(122, 142);
      this.pbPanCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbPanCardFront.TabIndex = 79;
      this.pbPanCardFront.TabStop = false;
      this.pbDrivingLicenseBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbDrivingLicenseBack.Location = new Point(387, 229);
      this.pbDrivingLicenseBack.Name = "pbDrivingLicenseBack";
      this.pbDrivingLicenseBack.Size = new Size(122, 142);
      this.pbDrivingLicenseBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDrivingLicenseBack.TabIndex = 77;
      this.pbDrivingLicenseBack.TabStop = false;
      this.panel46.BackColor = Color.Navy;
      this.panel46.Controls.Add((Control) this.label30);
      this.panel46.Location = new Point(259, 203);
      this.panel46.Name = "panel46";
      this.panel46.Size = new Size(250, 24);
      this.panel46.TabIndex = 75;
      this.label30.AutoSize = true;
      this.label30.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label30.ForeColor = Color.Snow;
      this.label30.Location = new Point(87, 0);
      this.label30.Name = "label30";
      this.label30.Size = new Size(146, 21);
      this.label30.TabIndex = 10;
      this.label30.Text = "DRIVING LICENSE";
      this.pbDrivingLicenseFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbDrivingLicenseFront.Location = new Point(259, 229);
      this.pbDrivingLicenseFront.Name = "pbDrivingLicenseFront";
      this.pbDrivingLicenseFront.Size = new Size(122, 142);
      this.pbDrivingLicenseFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDrivingLicenseFront.TabIndex = 74;
      this.pbDrivingLicenseFront.TabStop = false;
      this.pbOthersBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbOthersBack.Location = new Point(387, 433);
      this.pbOthersBack.Name = "pbOthersBack";
      this.pbOthersBack.Size = new Size(122, 142);
      this.pbOthersBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbOthersBack.TabIndex = 72;
      this.pbOthersBack.TabStop = false;
      this.panel43.BackColor = Color.Navy;
      this.panel43.Controls.Add((Control) this.label29);
      this.panel43.Location = new Point(259, 407);
      this.panel43.Name = "panel43";
      this.panel43.Size = new Size(250, 24);
      this.panel43.TabIndex = 70;
      this.label29.AutoSize = true;
      this.label29.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label29.ForeColor = Color.Snow;
      this.label29.Location = new Point(87, 0);
      this.label29.Name = "label29";
      this.label29.Size = new Size(70, 21);
      this.label29.TabIndex = 10;
      this.label29.Text = "OTHERS";
      this.pbOthersFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbOthersFront.Location = new Point(259, 433);
      this.pbOthersFront.Name = "pbOthersFront";
      this.pbOthersFront.Size = new Size(122, 142);
      this.pbOthersFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbOthersFront.TabIndex = 69;
      this.pbOthersFront.TabStop = false;
      this.pbRationCardBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbRationCardBack.Location = new Point(131, 433);
      this.pbRationCardBack.Name = "pbRationCardBack";
      this.pbRationCardBack.Size = new Size(122, 142);
      this.pbRationCardBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbRationCardBack.TabIndex = 67;
      this.pbRationCardBack.TabStop = false;
      this.panel40.BackColor = Color.Navy;
      this.panel40.Controls.Add((Control) this.label28);
      this.panel40.Location = new Point(3, 407);
      this.panel40.Name = "panel40";
      this.panel40.Size = new Size(250, 24);
      this.panel40.TabIndex = 65;
      this.label28.AutoSize = true;
      this.label28.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label28.ForeColor = Color.Snow;
      this.label28.Location = new Point(87, 0);
      this.label28.Name = "label28";
      this.label28.Size = new Size(124, 21);
      this.label28.TabIndex = 10;
      this.label28.Text = "RATION CARD";
      this.pbRationCardFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbRationCardFront.Location = new Point(3, 433);
      this.pbRationCardFront.Name = "pbRationCardFront";
      this.pbRationCardFront.Size = new Size(122, 142);
      this.pbRationCardFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbRationCardFront.TabIndex = 64;
      this.pbRationCardFront.TabStop = false;
      this.pbVoterIdBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbVoterIdBack.Location = new Point(131, 229);
      this.pbVoterIdBack.Name = "pbVoterIdBack";
      this.pbVoterIdBack.Size = new Size(122, 142);
      this.pbVoterIdBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbVoterIdBack.TabIndex = 62;
      this.pbVoterIdBack.TabStop = false;
      this.panel37.BackColor = Color.Navy;
      this.panel37.Controls.Add((Control) this.label27);
      this.panel37.Location = new Point(3, 203);
      this.panel37.Name = "panel37";
      this.panel37.Size = new Size(250, 24);
      this.panel37.TabIndex = 60;
      this.label27.AutoSize = true;
      this.label27.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label27.ForeColor = Color.Snow;
      this.label27.Location = new Point(87, 0);
      this.label27.Name = "label27";
      this.label27.Size = new Size(83, 21);
      this.label27.TabIndex = 10;
      this.label27.Text = "VOTER ID";
      this.pbVoterIdFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbVoterIdFront.Location = new Point(3, 229);
      this.pbVoterIdFront.Name = "pbVoterIdFront";
      this.pbVoterIdFront.Size = new Size(122, 142);
      this.pbVoterIdFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbVoterIdFront.TabIndex = 59;
      this.pbVoterIdFront.TabStop = false;
      this.pbAadharBack.BorderStyle = BorderStyle.FixedSingle;
      this.pbAadharBack.Location = new Point(124, 25);
      this.pbAadharBack.Name = "pbAadharBack";
      this.pbAadharBack.Size = new Size(122, 142);
      this.pbAadharBack.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbAadharBack.TabIndex = 57;
      this.pbAadharBack.TabStop = false;
      this.panel12.BackColor = Color.WhiteSmoke;
      this.panel12.Controls.Add((Control) this.pbDeleteAadharFront);
      this.panel12.Controls.Add((Control) this.pbCameraAadharFront);
      this.panel12.Controls.Add((Control) this.pbScanAadharFront);
      this.panel12.Controls.Add((Control) this.pbSelectAadharFront);
      this.panel12.Location = new Point(3, 170);
      this.panel12.Name = "panel12";
      this.panel12.Size = new Size(122, 30);
      this.panel12.TabIndex = 56;
      this.pbDeleteAadharFront.BackColor = Color.Transparent;
      this.pbDeleteAadharFront.Cursor = Cursors.Hand;
      this.pbDeleteAadharFront.Image = (Image) componentResourceManager.GetObject("pbDeleteAadharFront.Image");
      this.pbDeleteAadharFront.Location = new Point(91, 2);
      this.pbDeleteAadharFront.Name = "pbDeleteAadharFront";
      this.pbDeleteAadharFront.Size = new Size(25, 23);
      this.pbDeleteAadharFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbDeleteAadharFront.TabIndex = 61;
      this.pbDeleteAadharFront.TabStop = false;
      this.pbDeleteAadharFront.Click += new EventHandler(this.pbDeleteAadharFront_Click);
      this.pbCameraAadharFront.BackColor = Color.Transparent;
      this.pbCameraAadharFront.Cursor = Cursors.Hand;
      this.pbCameraAadharFront.Image = (Image) componentResourceManager.GetObject("pbCameraAadharFront.Image");
      this.pbCameraAadharFront.Location = new Point(60, 2);
      this.pbCameraAadharFront.Name = "pbCameraAadharFront";
      this.pbCameraAadharFront.Size = new Size(25, 23);
      this.pbCameraAadharFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCameraAadharFront.TabIndex = 58;
      this.pbCameraAadharFront.TabStop = false;
      this.pbCameraAadharFront.Click += new EventHandler(this.pbProofCameraButtonClicked);
      this.pbScanAadharFront.BackColor = Color.Transparent;
      this.pbScanAadharFront.Cursor = Cursors.Hand;
      this.pbScanAadharFront.Image = (Image) componentResourceManager.GetObject("pbScanAadharFront.Image");
      this.pbScanAadharFront.Location = new Point(32, 2);
      this.pbScanAadharFront.Name = "pbScanAadharFront";
      this.pbScanAadharFront.Size = new Size(25, 23);
      this.pbScanAadharFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbScanAadharFront.TabIndex = 57;
      this.pbScanAadharFront.TabStop = false;
      this.pbScanAadharFront.Click += new EventHandler(this.ProofScanButtonClicked);
      this.pbSelectAadharFront.BackColor = Color.Transparent;
      this.pbSelectAadharFront.Cursor = Cursors.Hand;
      this.pbSelectAadharFront.Image = (Image) componentResourceManager.GetObject("pbSelectAadharFront.Image");
      this.pbSelectAadharFront.Location = new Point(5, 2);
      this.pbSelectAadharFront.Name = "pbSelectAadharFront";
      this.pbSelectAadharFront.Size = new Size(25, 23);
      this.pbSelectAadharFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbSelectAadharFront.TabIndex = 56;
      this.pbSelectAadharFront.TabStop = false;
      this.pbSelectAadharFront.Click += new EventHandler(this.ProofsSeletButtonClicked_Click);
      this.panel34.BackColor = Color.Maroon;
      this.panel34.Controls.Add((Control) this.label26);
      this.panel34.Location = new Point(3, 2);
      this.panel34.Name = "panel34";
      this.panel34.Size = new Size(243, 24);
      this.panel34.TabIndex = 34;
      this.label26.AutoSize = true;
      this.label26.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label26.ForeColor = Color.Transparent;
      this.label26.Location = new Point(87, 1);
      this.label26.Name = "label26";
      this.label26.Size = new Size(82, 21);
      this.label26.TabIndex = 10;
      this.label26.Text = "AADHAR";
      this.pbAadharFront.BorderStyle = BorderStyle.FixedSingle;
      this.pbAadharFront.Location = new Point(3, 25);
      this.pbAadharFront.Name = "pbAadharFront";
      this.pbAadharFront.Size = new Size(122, 142);
      this.pbAadharFront.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbAadharFront.TabIndex = 27;
      this.pbAadharFront.TabStop = false;
      this.tpBankDetails.Location = new Point(4, 5);
      this.tpBankDetails.Name = "tpBankDetails";
      this.tpBankDetails.Padding = new Padding(3);
      this.tpBankDetails.Size = new Size(807, 611);
      this.tpBankDetails.TabIndex = 4;
      this.tpBankDetails.Text = "tabPage5";
      this.tpBankDetails.UseVisualStyleBackColor = true;
      this.tpFamilyDetails.Location = new Point(4, 5);
      this.tpFamilyDetails.Name = "tpFamilyDetails";
      this.tpFamilyDetails.Padding = new Padding(3);
      this.tpFamilyDetails.Size = new Size(807, 611);
      this.tpFamilyDetails.TabIndex = 5;
      this.tpFamilyDetails.Text = "tabPage1";
      this.tpFamilyDetails.UseVisualStyleBackColor = true;
      this.tpKyc.Location = new Point(4, 5);
      this.tpKyc.Name = "tpKyc";
      this.tpKyc.Size = new Size(807, 611);
      this.tpKyc.TabIndex = 6;
      this.tpKyc.Text = "tabPage1";
      this.tpKyc.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1024, 650);
      this.Controls.Add((Control) this.tabControl);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Form1);
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new EventHandler(this.Form1_Load);
      this.MouseEnter += new EventHandler(this.Form1_MouseEnter);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pbFingerPrint).EndInit();
      ((ISupportInitialize) this.pbPhoto).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.tpPersonalDetails.ResumeLayout(false);
      this.apnlPersonalDetails.ResumeLayout(false);
      this.apnlPersonalDetails.PerformLayout();
      ((ISupportInitialize) this.dgvFatherNameSearch).EndInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).EndInit();
      ((ISupportInitialize) this.dgvSpouseNameSearch).EndInit();
      this.tpResidentialAddress.ResumeLayout(false);
      this.apnlResidentialAddress.ResumeLayout(false);
      this.apnlResidentialAddress.PerformLayout();
      this.tpProof.ResumeLayout(false);
      this.apnlProof.ResumeLayout(false);
      this.apnlProof.PerformLayout();
      this.panel44.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteOthersBack).EndInit();
      ((ISupportInitialize) this.pbCameraOthersBack).EndInit();
      ((ISupportInitialize) this.pbScanOthersBack).EndInit();
      ((ISupportInitialize) this.pbSelectOthersBack).EndInit();
      this.panel45.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteOthersFront).EndInit();
      ((ISupportInitialize) this.pbCameraOthersFront).EndInit();
      ((ISupportInitialize) this.pbScanOthersFront).EndInit();
      ((ISupportInitialize) this.pbSelectOthersFront).EndInit();
      this.panel47.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteRationCardBack).EndInit();
      ((ISupportInitialize) this.pbCameraRationCardBack).EndInit();
      ((ISupportInitialize) this.pbScanRationCardBack).EndInit();
      ((ISupportInitialize) this.pbSelectRationCardBack).EndInit();
      this.panel48.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteRationCardFront).EndInit();
      ((ISupportInitialize) this.pbCameraRationCardFront).EndInit();
      ((ISupportInitialize) this.pbScanRationCardFront).EndInit();
      ((ISupportInitialize) this.pbSelectRationCardFront).EndInit();
      this.panel38.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteDrivingLicenseBack).EndInit();
      ((ISupportInitialize) this.pbCameraDrivingLicenseBack).EndInit();
      ((ISupportInitialize) this.pbScanDrivingLicenseBack).EndInit();
      ((ISupportInitialize) this.pbSelectDrivingLicenseBack).EndInit();
      this.panel39.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteDrivingLicenseFront).EndInit();
      ((ISupportInitialize) this.pbCameraDrivingLicenseFront).EndInit();
      ((ISupportInitialize) this.pbScanDrivingLicenseFront).EndInit();
      ((ISupportInitialize) this.pbSelectDrivingLicenseFront).EndInit();
      this.panel41.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteVoterIdBack).EndInit();
      ((ISupportInitialize) this.pbCameraVoterIdBack).EndInit();
      ((ISupportInitialize) this.pbScanVoterIdBack).EndInit();
      ((ISupportInitialize) this.pbSelectVoterIdBack).EndInit();
      this.panel42.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteVoterIdFront).EndInit();
      ((ISupportInitialize) this.pbCameraVoterIdFront).EndInit();
      ((ISupportInitialize) this.pbScanVoterIdFront).EndInit();
      ((ISupportInitialize) this.pbSelectVoterIdFront).EndInit();
      this.panel35.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeletePanBack).EndInit();
      ((ISupportInitialize) this.pbCamPanBack).EndInit();
      ((ISupportInitialize) this.pbScanPanBack).EndInit();
      ((ISupportInitialize) this.pbSelectPanBack).EndInit();
      this.panel36.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeletePanFront).EndInit();
      ((ISupportInitialize) this.pbCameraPanFront).EndInit();
      ((ISupportInitialize) this.pbScanPanFront).EndInit();
      ((ISupportInitialize) this.pbSelectPanFront).EndInit();
      this.panel33.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteAadharBack).EndInit();
      ((ISupportInitialize) this.pbCameraAadharBack).EndInit();
      ((ISupportInitialize) this.pbScanAadharBack).EndInit();
      ((ISupportInitialize) this.pbSelectAadharBack).EndInit();
      ((ISupportInitialize) this.pbPanCardBack).EndInit();
      this.panel49.ResumeLayout(false);
      this.panel49.PerformLayout();
      ((ISupportInitialize) this.pbPanCardFront).EndInit();
      ((ISupportInitialize) this.pbDrivingLicenseBack).EndInit();
      this.panel46.ResumeLayout(false);
      this.panel46.PerformLayout();
      ((ISupportInitialize) this.pbDrivingLicenseFront).EndInit();
      ((ISupportInitialize) this.pbOthersBack).EndInit();
      this.panel43.ResumeLayout(false);
      this.panel43.PerformLayout();
      ((ISupportInitialize) this.pbOthersFront).EndInit();
      ((ISupportInitialize) this.pbRationCardBack).EndInit();
      this.panel40.ResumeLayout(false);
      this.panel40.PerformLayout();
      ((ISupportInitialize) this.pbRationCardFront).EndInit();
      ((ISupportInitialize) this.pbVoterIdBack).EndInit();
      this.panel37.ResumeLayout(false);
      this.panel37.PerformLayout();
      ((ISupportInitialize) this.pbVoterIdFront).EndInit();
      ((ISupportInitialize) this.pbAadharBack).EndInit();
      this.panel12.ResumeLayout(false);
      ((ISupportInitialize) this.pbDeleteAadharFront).EndInit();
      ((ISupportInitialize) this.pbCameraAadharFront).EndInit();
      ((ISupportInitialize) this.pbScanAadharFront).EndInit();
      ((ISupportInitialize) this.pbSelectAadharFront).EndInit();
      this.panel34.ResumeLayout(false);
      this.panel34.PerformLayout();
      ((ISupportInitialize) this.pbAadharFront).EndInit();
      this.ResumeLayout(false);
    }
  }
}
