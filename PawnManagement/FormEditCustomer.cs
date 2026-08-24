

using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using SecuGen.SecuSearchSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormEditCustomer : Form
  {
    private List<string> lstAddress = new List<string>();
    private List<string> lstAddress2 = new List<string>();
    private List<string> lstName = new List<string>();
    private List<string> lsIntroducer = new List<string>();
    private string[] address = new string[1000];
    private string oldValues;
    private string newValues;
    private string calledBy = "";
    private SS_IDInfo idInfo;
    private byte[] minData;
    private int m_ImageWidth;
    private int m_ImageHeight;
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox textBox1;
    private PictureBox pbCustomerPhoto;
    private ComboBox cbAddr3;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label7;
    private TextBox tbxRationCard;
    private TextBox tbxOtherProof;
    private TextBox tbxAadharNumber;
    private TextBox tbxNo;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox tbxNotes;
    private Label label11;
    private TextBox tbxInterestRate;
    private Label label4;
    private TextBox tbxIntroducer;
    private Label label5;
    private Label label13;
    private Label label10;
    private Label label12;
    private Label label9;
    private Label label6;
    private Label label8;
    private TextBox tbxEmail;
    private TextBox tbxCustomerCode;
    private TextBox tbxAlternateContact;
    private TextBox tbxName;
    private TextBox tbxContactNo;
    private TextBox tbxAddr1;
    private TextBox tbxPinCode;
    private TextBox tbxAddr2;
    private TextBox tbxCity;
    private PictureBox pictureBox2;
    private GlassButton btnChangeProof;
    private GlassButton btnChangePhoto;
    private GlassButton btnSave;
    private Label label14;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem toolStripMenuItem1;
    private TextBox tbxSpouseCode;
    private TextBox tbxMotherCode;
    private TextBox tbxFatherCode;
    private TextBox tbxSpouseNameSearch;
    private TextBox tbxMotherNameSearch;
    private TextBox tbxFatherNameSearch;
    private Label label20;
    private Label label19;
    private Label label18;
    private Label label21;
    private ComboBox cbSex;
    private TextBox tbxSpouseName;
    private TextBox tbxMotherName;
    private TextBox tbxFatherName;
    private DataGridView dgvSpouseNameSearch;
    private DataGridView dgvMotherNameSearch;
    private DataGridView dgvFatherNameSearch;
    private GlassButton btnSpouseNameClear;
    private GlassButton btnMotherNameClear;
    private GlassButton btnFatherNameClear;
    private PictureBox pbFingerPrint;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private Label label22;
    private TextBox tbxMonthlyIncome;

    public FormEditCustomer() => this.InitializeComponent();

    public FormEditCustomer(string customerCode)
    {
      this.calledBy = customerCode;
      this.InitializeComponent();
    }

    private void EditCustomer_Load(object sender, EventArgs e)
    {
    }

    private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
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
      textBox.ForeColor = Color.Black;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "Select CID,CName,CAddr1 from tblCustomers where CID like @cid or CName like @cname";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("cid", (object) (this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("cname", (object) (this.textBox1.Text.Trim().ToString() + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form EditCustomer.textbox1_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else
      {
        this.dataGridView1.Visible = true;
        this.dataGridView1.DataSource = (object) dataTable2;
      }
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Select();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        e.SuppressKeyPress = true;
        this.tbxCustomerCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
        this.dataGridView1.Visible = false;
        this.tbxName.SelectionStart = this.tbxName.TextLength;
        this.tbxName.Select();
      }
      if (e.KeyCode != Keys.Up || !this.dataGridView1.Rows[0].Selected)
        return;
      this.textBox1.Select();
    }

    private void getLocationAndPincode()
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form EditCustomer.getLocationAndPincode", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else
      {
        this.cbAddr3.DataSource = (object) dataTable2;
        this.cbAddr3.DisplayMember = "Location";
      }
    }

    private void tbxCustomerCode_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "Select * from tblCustomers where CID like @cid";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("cid", (object) this.tbxCustomerCode.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("Form EditCustomer.tbxCustomerCode_TExtChanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving data" + strError);
        }
        else
        {
          this.tbxName.Text = dataTable2.Rows[0].Field<string>("CName");
          this.tbxContactNo.Text = dataTable2.Rows[0].Field<string>("CPhone");
          this.tbxAlternateContact.Text = dataTable2.Rows[0].Field<string>("CCell");
          this.tbxNo.Text = dataTable2.Rows[0].Field<string>("CNo");
          this.tbxAddr1.Text = dataTable2.Rows[0].Field<string>("CAddr1");
          this.tbxAddr2.Text = dataTable2.Rows[0].Field<string>("CAddr2");
          this.cbAddr3.Text = dataTable2.Rows[0].Field<string>("CAddr3");
          this.tbxCity.Text = dataTable2.Rows[0].Field<string>("CCity");
          this.tbxPinCode.Text = dataTable2.Rows[0].Field<string>("CPinCode");
          this.tbxIntroducer.Text = dataTable2.Rows[0].Field<string>("CIntroducer");
          this.tbxAadharNumber.Text = dataTable2.Rows[0].Field<string>("CAadharNumber");
          this.tbxOtherProof.Text = dataTable2.Rows[0].Field<string>("COtherProof");
          this.tbxRationCard.Text = dataTable2.Rows[0].Field<string>("CRationCard");
          this.tbxInterestRate.Text = dataTable2.Rows[0].Field<string>("CInterestRate");
          this.tbxEmail.Text = dataTable2.Rows[0].Field<string>("CEmail");
          this.tbxNotes.Text = dataTable2.Rows[0].Field<string>("CNotes");
          this.tbxFatherCode.Text = dataTable2.Rows[0]["FatherName"].ToString();
          this.tbxMotherCode.Text = dataTable2.Rows[0]["MotherName"].ToString();
          this.tbxSpouseCode.Text = dataTable2.Rows[0]["SpouseName"].ToString();
          this.cbSex.Text = dataTable2.Rows[0]["Sex"].ToString();
          this.tbxMonthlyIncome.Text = dataTable2.Rows[0]["MonthlyIncome"].ToString();
          this.oldValues = "Old Values are  \n Name = " + this.tbxName.Text.Trim().ToString() + "\n PhoneNumber= " + this.tbxContactNo.Text.Trim().ToString() + "\n CellNumber= " + this.tbxAlternateContact.Text.Trim().ToString() + "\n DoorNo= " + this.tbxNo.Text.Trim().ToString() + "\n Addr1= " + this.tbxAddr1.Text.Trim().ToString() + "\n Addr2= " + this.tbxAddr2.Text.Trim().ToString() + "\n Location= " + this.cbAddr3.Text.Trim().ToString() + "\n City= " + this.tbxCity.Text.Trim().ToString() + "\n Pincode= " + this.tbxPinCode.Text.Trim().ToString() + "\n Introducer=  " + this.tbxIntroducer.Text.Trim().ToString() + "\n AadharNumber= " + this.tbxAadharNumber.Text.Trim().ToString() + "\n OtherProof= " + this.tbxOtherProof.Text.Trim().ToString() + "\n RationCard= " + this.tbxRationCard.Text.Trim().ToString() + "\n InterestRate= " + this.tbxInterestRate.Text.Trim().ToString() + "\n Email= " + this.tbxEmail.Text.Trim().ToString() + "\n Notes= " + this.tbxNotes.Text.Trim().ToString();
        }
        if (File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          File.Copy(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbCustomerPhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        if (File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        if (dataTable2.Rows[0]["FingerPrint"] == null || !(dataTable2.Rows[0]["FingerPrint"].ToString() != "") || !File.Exists(FormMain.startUpPath + "Photos\\fingerprint.jpg"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\fingerprint.jpg", FileMode.Open, FileAccess.Read))
        {
          this.pbFingerPrint.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editcustomer.tbxCustomerCode_textChanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    public Image byteArrayToImage(byte[] byteArrayIn) => Image.FromStream((Stream) new MemoryStream(byteArrayIn));

    private void DrawImage(byte[] imgData, PictureBox picBox)
    {
      Bitmap bitmap = new Bitmap(this.m_ImageWidth, this.m_ImageHeight);
      picBox.Image = (Image) bitmap;
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          int num = (int) imgData[y * this.m_ImageWidth + x];
          bitmap.SetPixel(x, y, Color.FromArgb(num, num, num));
        }
      }
      picBox.Refresh();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxCustomerCode.Text != ""))
        return;
      int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "customerPhoto").ShowDialog();
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbCustomerPhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        if (File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editCustomer.Editcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void savePhoto()
    {
      try
      {
        File.Delete(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png");
        if (!File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        File.Copy(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form edittCustomer.savePhoto", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getAddress()
    {
      DateTime now;
      try
      {
        string strError = "";
        string my_querry = "Select distinct CAddr1 from tblCustomers";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving address" + strError);
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("Form AddCustomer.getAddress() innerException", MessageAnDStackTrace, username, CreatedOn);
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstAddress.Add(row["CAddr1"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  addcustomer.getaddress()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        string my_querry = "Select distinct CAddr2 from tblCustomers";
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving address" + strError);
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("Form AddCustomer.getAddress() innerException", MessageAnDStackTrace, username, CreatedOn);
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable4.Rows)
            this.lstAddress2.Add(row["CAddr2"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form addcustomer.getaddress", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        string my_querry = "Select distinct Cname,Cid from tblCustomers";
        DataTable dataTable5 = new DataTable();
        DataTable dataTable6 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving address" + strError);
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("Form AddCustomer.getAddress() innerException", MessageAnDStackTrace, username, CreatedOn);
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable6.Rows)
          {
            this.lstName.Add(row["Cname"].ToString());
            this.lsIntroducer.Add(row["Cname"].ToString() + "(" + row["Cid"].ToString() + ")");
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editCustomer.getaddress", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void EditCustomer_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbCustomerPhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        if (!File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editCustomer.Editcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxCustomerCode_TextChanged_1(object sender, EventArgs e)
    {
    }

    private void cbAddr3_SelectedIndexChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode where Location = @Location";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Location", (object) this.cbAddr3.Text.Trim()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form EditCustomer.cbAddr3_selectedIndexChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxCity.Text = dataTable2.Rows[0].Field<string>("City");
        this.tbxPinCode.Text = dataTable2.Rows[0].Field<string>("Pincode");
      }
    }

    private void tbxAddr1_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxName.Text.Trim() == "" || this.tbxCustomerCode.Text.Trim() == "")
        {
          int num1 = (int) MessageBox.Show("Please enter name");
        }
        else if (this.tbxAddr1.Text.Trim() == "")
        {
          int num2 = (int) MessageBox.Show("Enter Address PLEEEEEZ");
          this.tbxAddr1.Focus();
        }
        else if (this.cbSex.Text.Trim() == "")
        {
          this.cbSex.Select();
        }
        else
        {
          if (this.tbxCustomerCode.Text.Trim() == "")
            return;
          if (CustomersClass.getSex(this.tbxSpouseCode.Text) == this.cbSex.Text)
          {
            int num3 = (int) MessageBox.Show("check if Spouse selected is correct. Both are of same sex..");
          }
          else if (this.tbxMonthlyIncome.Text == "")
          {
            this.tbxMonthlyIncome.Text = "0";
            this.tbxMonthlyIncome.Select();
          }
          else if ((int) this.tbxCustomerCode.Text[0] == (int) this.tbxName.Text[0])
          {
            if (FormMain.UseFingerPrint && this.minData != null)
            {
              string text = this.saveWithFingerPrint();
              if (text == "Done")
              {
                FormMain.m_SecuSearch.RegisterFP(this.minData, this.idInfo);
              }
              else
              {
                int num4 = (int) MessageBox.Show(text);
              }
            }
            else
              this.save();
            if (this.tbxSpouseCode.Text != "")
              CustomersClass.updateRelation("SpouseName", this.tbxSpouseCode.Text, this.tbxCustomerCode.Text);
            this.savePhoto();
            this.newValues = "New Values are\n Name = " + this.tbxName.Text.Trim().ToString() + "\n PhoneNumber= " + this.tbxContactNo.Text.Trim().ToString() + "\n CellNumber= " + this.tbxAlternateContact.Text.Trim().ToString() + "\n DoorNo= " + this.tbxNo.Text.Trim().ToString() + "\n Addr1= " + this.tbxAddr1.Text.Trim().ToString() + "\n Addr2= " + this.tbxAddr2.Text.Trim().ToString() + "\n Location= " + this.cbAddr3.Text.Trim().ToString() + "\n City= " + this.tbxCity.Text.Trim().ToString() + "\n Pincode= " + this.tbxPinCode.Text.Trim().ToString() + "\n Introducer=  " + this.tbxIntroducer.Text.Trim().ToString() + "\n AadharNumber= " + this.tbxAadharNumber.Text.Trim().ToString() + "\n OtherProof= " + this.tbxOtherProof.Text.Trim().ToString() + "\n RationCard= " + this.tbxRationCard.Text.Trim().ToString() + "\n InterestRate= " + this.tbxInterestRate.Text.Trim().ToString() + "\n Email= " + this.tbxEmail.Text.Trim().ToString() + "\n Notes= " + this.tbxNotes.Text.Trim().ToString();
            PawnManagementClass.InsertIntoHistory("EditCustomer", "Customer " + this.tbxCustomerCode.Text.Trim().ToString() + "is edited", this.oldValues, this.newValues, FormMain.username, DateTime.Now.ToString());
            this.Dispose();
            this.Close();
          }
          else
          {
            int num5 = (int) MessageBox.Show("Customer name should begin with" + this.tbxCustomerCode.Text[0].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form editcusotmer.button2_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool CheckForm(Form form)
    {
      form = Application.OpenForms[form.Text];
      return form != null;
    }

    private string saveWithFingerPrint()
    {
      string strError = "";
      string base64String = Convert.ToBase64String(this.minData);
      return SQLHelper.RunCommand("update tblCustomers set CName=@CName,Sex = @Sex,CPhone=@CPhone,CCell=@CCell,CNo=@CNo,CAddr1=@CAddr1,CAddr2=@CAddr2,CAddr3=@CAddr3,CCity=@CCity,CPinCode=@CPinCode,CIntroducer=@CIntroducer,CAadharNumber=@CAadharNumber,COtherProof=@COtherProof,CRationCard=@CRationCard,CInterestRate=@CInterestRate,CEmail=@CEmail,CNotes=@CNotes,CreatedBy=@CreatedBy,Fathername = @FatherName,Mothername =@MotherName,SpouseName = @SpouseName,FingerNumber = @FingerNumber,SampleNumber = @SampleNumber,FingerPrint  = @FingerPrint where CID=@CID", new List<OleDbParameter>()
      {
        new OleDbParameter("CName", (object) this.tbxName.Text.Trim()),
        new OleDbParameter("Sex", (object) this.cbSex.Text),
        new OleDbParameter("CPhone", (object) this.tbxContactNo.Text.Trim()),
        new OleDbParameter("CCell", (object) this.tbxAlternateContact.Text.Trim()),
        new OleDbParameter("CNo", (object) this.tbxNo.Text.Trim()),
        new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim()),
        new OleDbParameter("CAddr2", (object) this.tbxAddr2.Text.Trim()),
        new OleDbParameter("CAddr3", (object) this.cbAddr3.Text.Trim()),
        new OleDbParameter("CCity", (object) this.tbxCity.Text.Trim()),
        new OleDbParameter("CPinCode", (object) this.tbxPinCode.Text.Trim()),
        new OleDbParameter("CIntroducer", (object) this.tbxIntroducer.Text.Trim()),
        new OleDbParameter("CAadharNumber", (object) this.tbxAadharNumber.Text.Trim()),
        new OleDbParameter("COtherProof", (object) this.tbxOtherProof.Text.Trim()),
        new OleDbParameter("CRationCard", (object) this.tbxRationCard.Text.Trim()),
        new OleDbParameter("CInterestRate", this.tbxInterestRate.Text == "" ? (object) "0" : (object) this.tbxInterestRate.Text),
        new OleDbParameter("CEmail", (object) this.tbxEmail.Text),
        new OleDbParameter("CNotes", (object) this.tbxNotes.Text),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("FatherName", (object) this.tbxFatherCode.Text),
        new OleDbParameter("MotherName", (object) this.tbxMotherCode.Text),
        new OleDbParameter("SpouseName", (object) this.tbxSpouseCode.Text),
        new OleDbParameter("FingerNumber", (object) this.idInfo.FingerNumber),
        new OleDbParameter("SampleNumber", (object) this.idInfo.SampleNumber),
        new OleDbParameter("FingerPrint", (object) base64String),
        new OleDbParameter("CID", (object) this.tbxCustomerCode.Text.Trim())
      }, ref strError);
    }

    private void save()
    {
      string strError = "";
      string text = SQLHelper.RunCommand("update tblCustomers set CName=@CName,Sex = @Sex,CPhone=@CPhone,CCell=@CCell,CNo=@CNo,CAddr1=@CAddr1,CAddr2=@CAddr2,CAddr3=@CAddr3,CCity=@CCity,CPinCode=@CPinCode,CIntroducer=@CIntroducer,CAadharNumber=@CAadharNumber,COtherProof=@COtherProof,CRationCard=@CRationCard,CInterestRate=@CInterestRate,CEmail=@CEmail,CNotes=@CNotes,CreatedBy=@CreatedBy,Fathername = @FatherName,Mothername =@MotherName,SpouseName = @SpouseName,MonthlyIncome = @MonthlyIncome where CID=@CID", new List<OleDbParameter>()
      {
        new OleDbParameter("CName", (object) this.tbxName.Text.Trim()),
        new OleDbParameter("Sex", (object) this.cbSex.Text),
        new OleDbParameter("CPhone", (object) this.tbxContactNo.Text.Trim()),
        new OleDbParameter("CCell", (object) this.tbxAlternateContact.Text.Trim()),
        new OleDbParameter("CNo", (object) this.tbxNo.Text.Trim()),
        new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim()),
        new OleDbParameter("CAddr2", (object) this.tbxAddr2.Text.Trim()),
        new OleDbParameter("CAddr3", (object) this.cbAddr3.Text.Trim()),
        new OleDbParameter("CCity", (object) this.tbxCity.Text.Trim()),
        new OleDbParameter("CPinCode", (object) this.tbxPinCode.Text.Trim()),
        new OleDbParameter("CIntroducer", (object) this.tbxIntroducer.Text.Trim()),
        new OleDbParameter("CAadharNumber", (object) this.tbxAadharNumber.Text.Trim()),
        new OleDbParameter("COtherProof", (object) this.tbxOtherProof.Text.Trim()),
        new OleDbParameter("CRationCard", (object) this.tbxRationCard.Text.Trim()),
        new OleDbParameter("CInterestRate", this.tbxInterestRate.Text == "" ? (object) "0" : (object) this.tbxInterestRate.Text),
        new OleDbParameter("CEmail", (object) this.tbxEmail.Text),
        new OleDbParameter("CNotes", (object) this.tbxNotes.Text),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("FatherName", (object) this.tbxFatherCode.Text),
        new OleDbParameter("MotherName", (object) this.tbxMotherCode.Text),
        new OleDbParameter("SpouseName", (object) this.tbxSpouseCode.Text),
        new OleDbParameter("MonthlyIncome", (object) this.tbxMonthlyIncome.Text),
        new OleDbParameter("CID", (object) this.tbxCustomerCode.Text.Trim())
      }, ref strError);
      if (text.Equals("Done"))
        return;
      PawnManagementClass.InsertIntoException("Form EditCustomer.save", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxCustomerCode.Text != ""))
        return;
      int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proofPhoto").ShowDialog();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void FormEditCustomer_Load(object sender, EventArgs e)
    {
      this.tbxName.Enter += new EventHandler(this.textBox_Enter);
      this.tbxNo.Enter += new EventHandler(this.textBox_Enter);
      this.tbxAddr1.Enter += new EventHandler(this.textBox_Enter);
      this.tbxAddr2.Enter += new EventHandler(this.textBox_Enter);
      this.tbxCity.Enter += new EventHandler(this.textBox_Enter);
      this.tbxPinCode.Enter += new EventHandler(this.textBox_Enter);
      this.tbxContactNo.Enter += new EventHandler(this.textBox_Enter);
      this.tbxAlternateContact.Enter += new EventHandler(this.textBox_Enter);
      this.tbxEmail.Enter += new EventHandler(this.textBox_Enter);
      this.tbxAadharNumber.Enter += new EventHandler(this.textBox_Enter);
      this.tbxRationCard.Enter += new EventHandler(this.textBox_Enter);
      this.tbxOtherProof.Enter += new EventHandler(this.textBox_Enter);
      this.tbxInterestRate.Enter += new EventHandler(this.textBox_Enter);
      this.tbxIntroducer.Enter += new EventHandler(this.textBox_Enter);
      this.tbxNotes.Enter += new EventHandler(this.textBox_Enter);
      this.tbxFatherNameSearch.Enter += new EventHandler(this.textBox_Enter);
      this.tbxMotherNameSearch.Enter += new EventHandler(this.textBox_Enter);
      this.tbxSpouseNameSearch.Enter += new EventHandler(this.textBox_Enter);
      this.tbxName.Leave += new EventHandler(this.textBox_Leave);
      this.tbxNo.Leave += new EventHandler(this.textBox_Leave);
      this.tbxAddr1.Leave += new EventHandler(this.textBox_Leave);
      this.tbxAddr2.Leave += new EventHandler(this.textBox_Leave);
      this.tbxCity.Leave += new EventHandler(this.textBox_Leave);
      this.tbxPinCode.Leave += new EventHandler(this.textBox_Leave);
      this.tbxContactNo.Leave += new EventHandler(this.textBox_Leave);
      this.tbxAlternateContact.Leave += new EventHandler(this.textBox_Leave);
      this.tbxEmail.Leave += new EventHandler(this.textBox_Leave);
      this.tbxAadharNumber.Leave += new EventHandler(this.textBox_Leave);
      this.tbxRationCard.Leave += new EventHandler(this.textBox_Leave);
      this.tbxOtherProof.Leave += new EventHandler(this.textBox_Leave);
      this.tbxInterestRate.Leave += new EventHandler(this.textBox_Leave);
      this.tbxIntroducer.Leave += new EventHandler(this.textBox_Leave);
      this.tbxNotes.Leave += new EventHandler(this.textBox_Leave);
      this.tbxFatherNameSearch.Leave += new EventHandler(this.textBox_Leave);
      this.tbxMotherNameSearch.Leave += new EventHandler(this.textBox_Leave);
      this.tbxSpouseNameSearch.Leave += new EventHandler(this.textBox_Leave);
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.getLocationAndPincode();
      PawnManagementClass.formatButtonBlue(ref this.btnChangeProof);
      PawnManagementClass.formatButtonBlue(ref this.btnChangePhoto);
      PawnManagementClass.formatButtonBlue(ref this.btnSave);
      if (this.calledBy != "")
        this.tbxCustomerCode.Text = this.calledBy;
      this.getAddress();
      this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr1.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
      this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr2.AutoCompleteCustomSource.AddRange(this.lstAddress2.ToArray());
      this.tbxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxName.AutoCompleteCustomSource.AddRange(this.lstName.ToArray());
      this.tbxIntroducer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxIntroducer.AutoCompleteCustomSource.AddRange(this.lsIntroducer.ToArray());
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvFatherNameSearch);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvMotherNameSearch);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvSpouseNameSearch);
    }

    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void pictureBox2_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\proof\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void tbxContactNo_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAlternateContact_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxInterestRate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxCustomerCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbxContactNo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.tbxContactNo.Text.Trim().Count<char>() == 0 | this.tbxContactNo.Text.Trim().Count<char>() == 10)
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      else
        this.tbxContactNo.Select();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          File.Delete(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png");
          this.pbCustomerPhoto.Image = (Image) null;
        }
        if (!File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        File.Delete(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png");
        this.pbCustomerPhoto.Image = (Image) null;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(FormMain.startUpPath + "Photos\\proof\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        File.Delete(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png");
        this.pictureBox2.Image = (Image) null;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void FormEditCustomer_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F9)
        ((Button) this.btnChangePhoto).PerformClick();
      if (e.KeyCode == Keys.F12)
        ((Button) this.btnChangeProof).PerformClick();
      if (e.KeyCode != Keys.F1)
        return;
      ((Button) this.btnSave).PerformClick();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void cbSex_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Up || this.cbSex.SelectedIndex != 0)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void tbxFatherName_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxFatherNameSearch_KeyDown(object sender, KeyEventArgs e)
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

    private void tbxFatherNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxFatherNameSearch.Text != "")
        this.getFatherNames();
      else
        this.dgvFatherNameSearch.Visible = false;
    }

    private void getFatherNames()
    {
      string strError = "";
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxFatherNameSearch.Text + "%' and (sex <> 'FEMALE' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
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
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxMotherNameSearch.Text + "%' and (sex <> 'MALE' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
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
      string my_querry = "Select CID,CName,CNo,CAddr1,CPhone,CCell,CAddr2,CAddr3,CCity,CPinCode from tblCustomers where CName like '" + this.tbxSpouseNameSearch.Text + "%' and (sex <> '" + this.cbSex.Text + "' OR SEX IS NULL)";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getcustomerdetails()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
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

    private void tbxMotherNameSearch_KeyDown(object sender, KeyEventArgs e)
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

    private void tbxMotherNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxMotherNameSearch.Text != "")
        this.getMotherNames();
      else
        this.dgvMotherNameSearch.Visible = false;
    }

    private void tbxSpouseNameSearch_KeyDown(object sender, KeyEventArgs e)
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

    private void tbxSpouseNameSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxSpouseNameSearch.Text != "")
        this.getSpouseNames();
      else
        this.dgvSpouseNameSearch.Visible = false;
    }

    private void dgvFatherNameSearch_KeyDown(object sender, KeyEventArgs e)
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
          if (this.tbxCustomerCode.Text == this.tbxFatherCode.Text)
          {
            this.tbxFatherCode.Text = "";
            this.tbxFatherName.Text = "";
          }
          else
          {
            this.tbxFatherName.Text = this.dgvFatherNameSearch.Rows[index].Cells["CID"].Value.ToString() + "-" + this.dgvFatherNameSearch.Rows[index].Cells["CName"].Value.ToString();
            this.dgvFatherNameSearch.Visible = false;
            this.tbxMotherNameSearch.Select();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
          this.dgvSpouseNameSearch.Visible = false;
          this.tbxNo.Select();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxFatherCode_TextChanged(object sender, EventArgs e) => this.tbxFatherName.Text = this.tbxFatherCode.Text + "-" + CustomersClass.getName(this.tbxFatherCode.Text);

    private void tbxMotherCode_TextChanged(object sender, EventArgs e) => this.tbxMotherName.Text = this.tbxMotherCode.Text + "-" + CustomersClass.getName(this.tbxMotherCode.Text);

    private void tbxSpouseCode_TextChanged(object sender, EventArgs e) => this.tbxSpouseName.Text = this.tbxSpouseCode.Text + "-" + CustomersClass.getName(this.tbxSpouseCode.Text);

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

    private void glassButton1_Click_1(object sender, EventArgs e) => this.takeFingerPrint();

    private void FormEditCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
      Form openForm = Application.OpenForms["FormMain"];
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) openForm.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void glassButton2_Click(object sender, EventArgs e)
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
        this.pbCustomerPhoto.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
      openFileDialog.Title = "Select the picture";
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        if (openFileDialog.CheckFileExists)
        {
          string destFileName = FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text + ".png";
          File.Copy(openFileDialog.FileName, destFileName, true);
          string empty = string.Empty;
        }
        else
        {
          int num = (int) MessageBox.Show("file does not exist");
        }
      }
      if (!File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        return;
      using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
      {
        this.pictureBox2.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void takeFingerPrint()
    {
      string id = CustomersClass.getId(this.tbxCustomerCode.Text);
      if (!double.TryParse(id, NumberStyles.Integer, (IFormatProvider) CultureInfo.CurrentCulture, out double _))
      {
        int num1 = (int) MessageBox.Show("Please enter number for user id.");
      }
      else
      {
        byte[] numArray = new byte[FormMain.m_ImageWidth * FormMain.m_ImageHeight];
        int imageEx = FormMain.m_FPM.GetImageEx(numArray, 5000, this.pbFingerPrint.Handle.ToInt32(), 50);
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
            this.idInfo.ID = Convert.ToInt32(id);
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.dataGridView1 = new DataGridView();
      this.textBox1 = new TextBox();
      this.pbCustomerPhoto = new PictureBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.cbAddr3 = new ComboBox();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label7 = new Label();
      this.tbxRationCard = new TextBox();
      this.tbxOtherProof = new TextBox();
      this.tbxAadharNumber = new TextBox();
      this.tbxNo = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.tbxNotes = new TextBox();
      this.label11 = new Label();
      this.tbxInterestRate = new TextBox();
      this.label4 = new Label();
      this.tbxIntroducer = new TextBox();
      this.label5 = new Label();
      this.label13 = new Label();
      this.label10 = new Label();
      this.label12 = new Label();
      this.label9 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.tbxEmail = new TextBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxAlternateContact = new TextBox();
      this.tbxName = new TextBox();
      this.tbxContactNo = new TextBox();
      this.tbxAddr1 = new TextBox();
      this.tbxPinCode = new TextBox();
      this.tbxAddr2 = new TextBox();
      this.tbxCity = new TextBox();
      this.pictureBox2 = new PictureBox();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.btnChangeProof = new GlassButton();
      this.btnChangePhoto = new GlassButton();
      this.btnSave = new GlassButton();
      this.label14 = new Label();
      this.tbxSpouseCode = new TextBox();
      this.tbxMotherCode = new TextBox();
      this.tbxFatherCode = new TextBox();
      this.tbxSpouseNameSearch = new TextBox();
      this.tbxMotherNameSearch = new TextBox();
      this.tbxFatherNameSearch = new TextBox();
      this.label20 = new Label();
      this.label19 = new Label();
      this.label18 = new Label();
      this.label21 = new Label();
      this.cbSex = new ComboBox();
      this.tbxSpouseName = new TextBox();
      this.tbxMotherName = new TextBox();
      this.tbxFatherName = new TextBox();
      this.dgvSpouseNameSearch = new DataGridView();
      this.dgvMotherNameSearch = new DataGridView();
      this.dgvFatherNameSearch = new DataGridView();
      this.btnSpouseNameClear = new GlassButton();
      this.btnMotherNameClear = new GlassButton();
      this.btnFatherNameClear = new GlassButton();
      this.pbFingerPrint = new PictureBox();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.label22 = new Label();
      this.tbxMonthlyIncome = new TextBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.pbCustomerPhoto).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.contextMenuStrip2.SuspendLayout();
      ((ISupportInitialize) this.dgvSpouseNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvFatherNameSearch).BeginInit();
      ((ISupportInitialize) this.pbFingerPrint).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(278, 61);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(722, 439);
      this.dataGridView1.TabIndex = 46;
      this.dataGridView1.Visible = false;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.textBox1.CharacterCasing = CharacterCasing.Upper;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(853, 29);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(147, 26);
      this.textBox1.TabIndex = 0;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
      this.pbCustomerPhoto.ContextMenuStrip = this.contextMenuStrip1;
      this.pbCustomerPhoto.Location = new Point(853, 61);
      this.pbCustomerPhoto.Name = "pbCustomerPhoto";
      this.pbCustomerPhoto.Size = new Size(146, 148);
      this.pbCustomerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbCustomerPhoto.TabIndex = 26;
      this.pbCustomerPhoto.TabStop = false;
      this.pbCustomerPhoto.DoubleClick += new EventHandler(this.pictureBox1_DoubleClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deleteToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(108, 26);
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new Size(107, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.cbAddr3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAddr3.Font = new Font("Microsoft Sans Serif", 15.75f);
      this.cbAddr3.FormattingEnabled = true;
      this.cbAddr3.Location = new Point(170, 315);
      this.cbAddr3.Name = "cbAddr3";
      this.cbAddr3.Size = new Size(677, 33);
      this.cbAddr3.TabIndex = 9;
      this.cbAddr3.SelectedIndexChanged += new EventHandler(this.cbAddr3_SelectedIndexChanged);
      this.cbAddr3.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.RoyalBlue;
      this.label15.Location = new Point(384, 481);
      this.label15.Name = "label15";
      this.label15.Size = new Size(119, 20);
      this.label15.TabIndex = 45;
      this.label15.Text = "RATION CARD";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.RoyalBlue;
      this.label16.Location = new Point(41, 514);
      this.label16.Name = "label16";
      this.label16.Size = new Size(125, 20);
      this.label16.TabIndex = 40;
      this.label16.Text = "OTHER PROOF";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.RoyalBlue;
      this.label17.Location = new Point(396, 451);
      this.label17.Name = "label17";
      this.label17.Size = new Size(105, 20);
      this.label17.TabIndex = 44;
      this.label17.Text = "AADHAR NO";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.RoyalBlue;
      this.label7.Location = new Point(132, 226);
      this.label7.Name = "label7";
      this.label7.Size = new Size(32, 20);
      this.label7.TabIndex = 32;
      this.label7.Text = "NO";
      this.tbxRationCard.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRationCard.CharacterCasing = CharacterCasing.Upper;
      this.tbxRationCard.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRationCard.Location = new Point(507, 477);
      this.tbxRationCard.Name = "tbxRationCard";
      this.tbxRationCard.Size = new Size(340, 31);
      this.tbxRationCard.TabIndex = 20;
      this.tbxRationCard.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxOtherProof.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOtherProof.CharacterCasing = CharacterCasing.Upper;
      this.tbxOtherProof.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherProof.Location = new Point(170, 511);
      this.tbxOtherProof.Name = "tbxOtherProof";
      this.tbxOtherProof.Size = new Size(208, 31);
      this.tbxOtherProof.TabIndex = 15;
      this.tbxOtherProof.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAadharNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAadharNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxAadharNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAadharNumber.Location = new Point(507, 445);
      this.tbxAadharNumber.Name = "tbxAadharNumber";
      this.tbxAadharNumber.Size = new Size(340, 31);
      this.tbxAadharNumber.TabIndex = 19;
      this.tbxAadharNumber.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxNo.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxNo.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNo.Location = new Point(170, 219);
      this.tbxNo.Name = "tbxNo";
      this.tbxNo.Size = new Size(677, 31);
      this.tbxNo.TabIndex = 6;
      this.tbxNo.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.RoyalBlue;
      this.label1.Location = new Point(14, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(150, 20);
      this.label1.TabIndex = 26;
      this.label1.Text = "CUSTOMER CODE";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.RoyalBlue;
      this.label2.Location = new Point(109, 52);
      this.label2.Name = "label2";
      this.label2.Size = new Size(55, 20);
      this.label2.TabIndex = 27;
      this.label2.Text = "NAME";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.RoyalBlue;
      this.label3.Location = new Point(75, 259);
      this.label3.Name = "label3";
      this.label3.Size = new Size(89, 20);
      this.label3.TabIndex = 33;
      this.label3.Text = "ADDRESS";
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.CharacterCasing = CharacterCasing.Upper;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(507, 413);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(340, 31);
      this.tbxNotes.TabIndex = 18;
      this.tbxNotes.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.RoyalBlue;
      this.label11.Location = new Point(77, 323);
      this.label11.Name = "label11";
      this.label11.Size = new Size(89, 20);
      this.label11.TabIndex = 34;
      this.label11.Text = "LOCATION";
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(170, 477);
      this.tbxInterestRate.MaxLength = 3;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(208, 31);
      this.tbxInterestRate.TabIndex = 14;
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxInterestRate_KeyPress);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.RoyalBlue;
      this.label4.Location = new Point(117, 357);
      this.label4.Name = "label4";
      this.label4.Size = new Size(45, 20);
      this.label4.TabIndex = 35;
      this.label4.Text = "CITY";
      this.tbxIntroducer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxIntroducer.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxIntroducer.BorderStyle = BorderStyle.FixedSingle;
      this.tbxIntroducer.CharacterCasing = CharacterCasing.Upper;
      this.tbxIntroducer.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxIntroducer.Location = new Point(507, 381);
      this.tbxIntroducer.Name = "tbxIntroducer";
      this.tbxIntroducer.Size = new Size(340, 31);
      this.tbxIntroducer.TabIndex = 17;
      this.tbxIntroducer.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.RoyalBlue;
      this.label5.Location = new Point(85, 385);
      this.label5.Name = "label5";
      this.label5.Size = new Size(81, 20);
      this.label5.TabIndex = 36;
      this.label5.Text = "PINCODE";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.RoyalBlue;
      this.label13.Location = new Point(407, 418);
      this.label13.Name = "label13";
      this.label13.Size = new Size(96, 20);
      this.label13.TabIndex = 43;
      this.label13.Text = "REMINDER";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.RoyalBlue;
      this.label10.Location = new Point(9, 450);
      this.label10.Name = "label10";
      this.label10.Size = new Size(157, 20);
      this.label10.TabIndex = 38;
      this.label10.Text = "CONTACT NUMBER";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.RoyalBlue;
      this.label12.Location = new Point(31, 483);
      this.label12.Name = "label12";
      this.label12.Size = new Size(135, 20);
      this.label12.TabIndex = 39;
      this.label12.Text = "INTEREST RATE";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.RoyalBlue;
      this.label9.Location = new Point(22, 416);
      this.label9.Name = "label9";
      this.label9.Size = new Size(144, 20);
      this.label9.TabIndex = 37;
      this.label9.Text = "MOBILE NUMBER";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.RoyalBlue;
      this.label6.Location = new Point(417, 387);
      this.label6.Name = "label6";
      this.label6.Size = new Size(84, 20);
      this.label6.TabIndex = 42;
      this.label6.Text = "INTRO BY";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.RoyalBlue;
      this.label8.Location = new Point(424, 356);
      this.label8.Name = "label8";
      this.label8.Size = new Size(79, 20);
      this.label8.TabIndex = 41;
      this.label8.Text = "EMAIL ID";
      this.tbxEmail.BorderStyle = BorderStyle.FixedSingle;
      this.tbxEmail.CharacterCasing = CharacterCasing.Upper;
      this.tbxEmail.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxEmail.Location = new Point(507, 349);
      this.tbxEmail.Name = "tbxEmail";
      this.tbxEmail.Size = new Size(340, 31);
      this.tbxEmail.TabIndex = 16;
      this.tbxEmail.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(170, 16);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(677, 31);
      this.tbxCustomerCode.TabIndex = 25;
      this.tbxCustomerCode.TextChanged += new EventHandler(this.tbxCustomerCode_TextChanged);
      this.tbxCustomerCode.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxAlternateContact.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAlternateContact.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateContact.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateContact.Location = new Point(170, 445);
      this.tbxAlternateContact.MaxLength = 11;
      this.tbxAlternateContact.Name = "tbxAlternateContact";
      this.tbxAlternateContact.Size = new Size(208, 31);
      this.tbxAlternateContact.TabIndex = 13;
      this.tbxAlternateContact.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAlternateContact.KeyPress += new KeyPressEventHandler(this.tbxAlternateContact_KeyPress);
      this.tbxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxName.CharacterCasing = CharacterCasing.Upper;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(170, 48);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(677, 31);
      this.tbxName.TabIndex = 1;
      this.tbxName.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxContactNo.BorderStyle = BorderStyle.FixedSingle;
      this.tbxContactNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxContactNo.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxContactNo.Location = new Point(170, 413);
      this.tbxContactNo.MaxLength = 10;
      this.tbxContactNo.Name = "tbxContactNo";
      this.tbxContactNo.Size = new Size(208, 31);
      this.tbxContactNo.TabIndex = 12;
      this.tbxContactNo.KeyDown += new KeyEventHandler(this.tbxContactNo_KeyDown);
      this.tbxContactNo.KeyPress += new KeyPressEventHandler(this.tbxContactNo_KeyPress);
      this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr1.Location = new Point(170, 251);
      this.tbxAddr1.Name = "tbxAddr1";
      this.tbxAddr1.Size = new Size(677, 31);
      this.tbxAddr1.TabIndex = 7;
      this.tbxAddr1.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxPinCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPinCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPinCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPinCode.Location = new Point(170, 381);
      this.tbxPinCode.Name = "tbxPinCode";
      this.tbxPinCode.Size = new Size(208, 31);
      this.tbxPinCode.TabIndex = 11;
      this.tbxPinCode.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxPinCode.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr2.Location = new Point(170, 283);
      this.tbxAddr2.Name = "tbxAddr2";
      this.tbxAddr2.Size = new Size(677, 31);
      this.tbxAddr2.TabIndex = 8;
      this.tbxAddr2.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(170, 349);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(208, 31);
      this.tbxCity.TabIndex = 10;
      this.tbxCity.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxCity.KeyPress += new KeyPressEventHandler(this.tbxCustomerCode_KeyPress);
      this.pictureBox2.ContextMenuStrip = this.contextMenuStrip2;
      this.pictureBox2.Location = new Point(853, 251);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(146, 141);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 73;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.DoubleClick += new EventHandler(this.pictureBox2_DoubleClick);
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem1
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(108, 26);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(107, 22);
      this.toolStripMenuItem1.Text = "Delete";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.btnChangeProof.BackColor = Color.LightBlue;
      ((Control) this.btnChangeProof).ContextMenuStrip = this.contextMenuStrip2;
      this.btnChangeProof.FadeOnFocus = true;
      ((Control) this.btnChangeProof).Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnChangeProof.ForeColor = Color.MediumBlue;
      this.btnChangeProof.ForeColorOnFocus = Color.Red;
      this.btnChangeProof.ForeColorOnLeave = Color.RoyalBlue;
      this.btnChangeProof.GlowColor = Color.White;
      this.btnChangeProof.InnerBorderColor = Color.Transparent;
      ((Control) this.btnChangeProof).Location = new Point(853, 397);
      ((Control) this.btnChangeProof).Name = "btnChangeProof";
      this.btnChangeProof.OuterBorderColor = Color.MediumSlateBlue;
      this.btnChangeProof.ShineColor = Color.Transparent;
      ((Control) this.btnChangeProof).Size = new Size(147, 31);
      ((Control) this.btnChangeProof).TabIndex = 22;
      ((Control) this.btnChangeProof).Text = "CHANGE &PROOF(F12)";
      ((ButtonBase) this.btnChangeProof).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnChangeProof).Click += new EventHandler(this.glassButton1_Click);
      this.btnChangePhoto.BackColor = Color.LightBlue;
      this.btnChangePhoto.FadeOnFocus = true;
      ((Control) this.btnChangePhoto).Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnChangePhoto.ForeColor = Color.MediumBlue;
      this.btnChangePhoto.ForeColorOnFocus = Color.Red;
      this.btnChangePhoto.ForeColorOnLeave = Color.RoyalBlue;
      this.btnChangePhoto.GlowColor = Color.White;
      this.btnChangePhoto.InnerBorderColor = Color.Transparent;
      ((Control) this.btnChangePhoto).Location = new Point(853, 218);
      ((Control) this.btnChangePhoto).Name = "btnChangePhoto";
      this.btnChangePhoto.OuterBorderColor = Color.MediumSlateBlue;
      this.btnChangePhoto.ShineColor = Color.Transparent;
      ((Control) this.btnChangePhoto).Size = new Size(78, 27);
      ((Control) this.btnChangePhoto).TabIndex = 25;
      ((Control) this.btnChangePhoto).Text = "&CHANGE PHOTO(F9)";
      ((ButtonBase) this.btnChangePhoto).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnChangePhoto).Click += new EventHandler(this.button1_Click);
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSave.GlowColor = Color.White;
      ((ButtonBase) this.btnSave).Image = (Image) Resources.SAVE;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(543, 554);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(190, 58);
      ((Control) this.btnSave).TabIndex = 21;
      ((Control) this.btnSave).Text = "&SAVE(F1)";
      ((ButtonBase) this.btnSave).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnSave).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.RoyalBlue;
      this.label14.Location = new Point(849, 6);
      this.label14.Name = "label14";
      this.label14.Size = new Size(94, 20);
      this.label14.TabIndex = 47;
      this.label14.Text = "Enter Name";
      this.tbxSpouseCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSpouseCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseCode.Location = new Point(100, 187);
      this.tbxSpouseCode.Name = "tbxSpouseCode";
      this.tbxSpouseCode.Size = new Size(66, 31);
      this.tbxSpouseCode.TabIndex = 50;
      this.tbxSpouseCode.Visible = false;
      this.tbxSpouseCode.TextChanged += new EventHandler(this.tbxSpouseCode_TextChanged);
      this.tbxMotherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMotherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherCode.Location = new Point(100, 152);
      this.tbxMotherCode.Name = "tbxMotherCode";
      this.tbxMotherCode.Size = new Size(66, 31);
      this.tbxMotherCode.TabIndex = 49;
      this.tbxMotherCode.Visible = false;
      this.tbxMotherCode.TextChanged += new EventHandler(this.tbxMotherCode_TextChanged);
      this.tbxFatherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFatherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherCode.Location = new Point(100, 117);
      this.tbxFatherCode.Name = "tbxFatherCode";
      this.tbxFatherCode.Size = new Size(66, 31);
      this.tbxFatherCode.TabIndex = 48;
      this.tbxFatherCode.Visible = false;
      this.tbxFatherCode.TextChanged += new EventHandler(this.tbxFatherCode_TextChanged);
      this.tbxSpouseNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseNameSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSpouseNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseNameSearch.Location = new Point(532, 186);
      this.tbxSpouseNameSearch.Name = "tbxSpouseNameSearch";
      this.tbxSpouseNameSearch.Size = new Size(315, 31);
      this.tbxSpouseNameSearch.TabIndex = 5;
      this.tbxSpouseNameSearch.TextChanged += new EventHandler(this.tbxSpouseNameSearch_TextChanged);
      this.tbxSpouseNameSearch.KeyDown += new KeyEventHandler(this.tbxSpouseNameSearch_KeyDown);
      this.tbxMotherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherNameSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMotherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherNameSearch.Location = new Point(532, 152);
      this.tbxMotherNameSearch.Name = "tbxMotherNameSearch";
      this.tbxMotherNameSearch.Size = new Size(315, 31);
      this.tbxMotherNameSearch.TabIndex = 4;
      this.tbxMotherNameSearch.TextChanged += new EventHandler(this.tbxMotherNameSearch_TextChanged);
      this.tbxMotherNameSearch.KeyDown += new KeyEventHandler(this.tbxMotherNameSearch_KeyDown);
      this.tbxFatherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherNameSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFatherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherNameSearch.Location = new Point(532, 117);
      this.tbxFatherNameSearch.Name = "tbxFatherNameSearch";
      this.tbxFatherNameSearch.Size = new Size(315, 31);
      this.tbxFatherNameSearch.TabIndex = 3;
      this.tbxFatherNameSearch.TextChanged += new EventHandler(this.tbxFatherNameSearch_TextChanged);
      this.tbxFatherNameSearch.KeyDown += new KeyEventHandler(this.tbxFatherNameSearch_KeyDown);
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.RoyalBlue;
      this.label20.Location = new Point(117, 89);
      this.label20.Name = "label20";
      this.label20.Size = new Size(42, 20);
      this.label20.TabIndex = 28;
      this.label20.Text = "SEX";
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.RoyalBlue;
      this.label19.Location = new Point(4, 189);
      this.label19.Name = "label19";
      this.label19.Size = new Size(150, 20);
      this.label19.TabIndex = 31;
      this.label19.Text = "HUSB/WIFE NAME";
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.RoyalBlue;
      this.label18.Location = new Point(29, 155);
      this.label18.Name = "label18";
      this.label18.Size = new Size(128, 20);
      this.label18.TabIndex = 30;
      this.label18.Text = "MOTHER NAME";
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.RoyalBlue;
      this.label21.Location = new Point(36, 119);
      this.label21.Name = "label21";
      this.label21.Size = new Size(124, 20);
      this.label21.TabIndex = 29;
      this.label21.Text = "FATHER NAME";
      this.cbSex.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbSex.Font = new Font("Microsoft Sans Serif", 15.75f);
      this.cbSex.FormattingEnabled = true;
      this.cbSex.Items.AddRange(new object[2]
      {
        (object) "MALE",
        (object) "FEMALE"
      });
      this.cbSex.Location = new Point(170, 81);
      this.cbSex.Name = "cbSex";
      this.cbSex.Size = new Size(677, 33);
      this.cbSex.TabIndex = 2;
      this.cbSex.KeyDown += new KeyEventHandler(this.cbSex_KeyDown);
      this.tbxSpouseName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSpouseName.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseName.Location = new Point(170, 186);
      this.tbxSpouseName.Name = "tbxSpouseName";
      this.tbxSpouseName.Size = new Size(356, 31);
      this.tbxSpouseName.TabIndex = 53;
      this.tbxSpouseName.KeyPress += new KeyPressEventHandler(this.tbxFatherName_KeyPress);
      this.tbxMotherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMotherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherName.Location = new Point(170, 152);
      this.tbxMotherName.Name = "tbxMotherName";
      this.tbxMotherName.Size = new Size(356, 31);
      this.tbxMotherName.TabIndex = 52;
      this.tbxMotherName.KeyPress += new KeyPressEventHandler(this.tbxFatherName_KeyPress);
      this.tbxFatherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFatherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherName.Location = new Point(170, 117);
      this.tbxFatherName.Name = "tbxFatherName";
      this.tbxFatherName.Size = new Size(356, 31);
      this.tbxFatherName.TabIndex = 51;
      this.tbxFatherName.KeyPress += new KeyPressEventHandler(this.tbxFatherName_KeyPress);
      this.dgvSpouseNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSpouseNameSearch.Location = new Point(64, 220);
      this.dgvSpouseNameSearch.Name = "dgvSpouseNameSearch";
      this.dgvSpouseNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSpouseNameSearch.Size = new Size(782, 281);
      this.dgvSpouseNameSearch.TabIndex = 76;
      this.dgvSpouseNameSearch.Visible = false;
      this.dgvSpouseNameSearch.KeyDown += new KeyEventHandler(this.dgvSpouseNameSearch_KeyDown);
      this.dgvMotherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvMotherNameSearch.Location = new Point(62, 220);
      this.dgvMotherNameSearch.Name = "dgvMotherNameSearch";
      this.dgvMotherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvMotherNameSearch.Size = new Size(785, 280);
      this.dgvMotherNameSearch.TabIndex = 75;
      this.dgvMotherNameSearch.Visible = false;
      this.dgvMotherNameSearch.KeyDown += new KeyEventHandler(this.dgvMotherNameSearch_KeyDown);
      this.dgvFatherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFatherNameSearch.Location = new Point(81, 220);
      this.dgvFatherNameSearch.Name = "dgvFatherNameSearch";
      this.dgvFatherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvFatherNameSearch.Size = new Size(765, 280);
      this.dgvFatherNameSearch.TabIndex = 74;
      this.dgvFatherNameSearch.Visible = false;
      this.dgvFatherNameSearch.KeyDown += new KeyEventHandler(this.dgvFatherNameSearch_KeyDown);
      this.btnSpouseNameClear.BackColor = Color.LightBlue;
      this.btnSpouseNameClear.FadeOnFocus = true;
      this.btnSpouseNameClear.ForeColor = Color.MediumBlue;
      this.btnSpouseNameClear.ForeColorOnFocus = Color.Red;
      this.btnSpouseNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnSpouseNameClear.GlowColor = Color.White;
      this.btnSpouseNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSpouseNameClear).Location = new Point(482, 189);
      ((Control) this.btnSpouseNameClear).Name = "btnSpouseNameClear";
      this.btnSpouseNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSpouseNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnSpouseNameClear).Size = new Size(40, 23);
      ((Control) this.btnSpouseNameClear).TabIndex = 79;
      ((Control) this.btnSpouseNameClear).Text = "Clear";
      ((Control) this.btnSpouseNameClear).Click += new EventHandler(this.btnSpouseNameClear_Click);
      this.btnMotherNameClear.BackColor = Color.LightBlue;
      this.btnMotherNameClear.FadeOnFocus = true;
      this.btnMotherNameClear.ForeColor = Color.MediumBlue;
      this.btnMotherNameClear.ForeColorOnFocus = Color.Red;
      this.btnMotherNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnMotherNameClear.GlowColor = Color.White;
      this.btnMotherNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnMotherNameClear).Location = new Point(482, 155);
      ((Control) this.btnMotherNameClear).Name = "btnMotherNameClear";
      this.btnMotherNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnMotherNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnMotherNameClear).Size = new Size(40, 23);
      ((Control) this.btnMotherNameClear).TabIndex = 78;
      ((Control) this.btnMotherNameClear).Text = "Clear";
      ((Control) this.btnMotherNameClear).Click += new EventHandler(this.btnMotherNameClear_Click);
      this.btnFatherNameClear.BackColor = Color.LightBlue;
      this.btnFatherNameClear.FadeOnFocus = true;
      this.btnFatherNameClear.ForeColor = Color.MediumBlue;
      this.btnFatherNameClear.ForeColorOnFocus = Color.Red;
      this.btnFatherNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnFatherNameClear.GlowColor = Color.White;
      this.btnFatherNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnFatherNameClear).Location = new Point(482, 121);
      ((Control) this.btnFatherNameClear).Name = "btnFatherNameClear";
      this.btnFatherNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnFatherNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnFatherNameClear).Size = new Size(40, 23);
      ((Control) this.btnFatherNameClear).TabIndex = 77;
      ((Control) this.btnFatherNameClear).Text = "Clear";
      ((Control) this.btnFatherNameClear).Click += new EventHandler(this.btnFatherNameClear_Click);
      this.pbFingerPrint.ContextMenuStrip = this.contextMenuStrip2;
      this.pbFingerPrint.Location = new Point(853, 466);
      this.pbFingerPrint.Name = "pbFingerPrint";
      this.pbFingerPrint.Size = new Size(146, 109);
      this.pbFingerPrint.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbFingerPrint.TabIndex = 80;
      this.pbFingerPrint.TabStop = false;
      this.glassButton1.BackColor = Color.LightBlue;
      ((Control) this.glassButton1).ContextMenuStrip = this.contextMenuStrip2;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(853, 581);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(146, 31);
      ((Control) this.glassButton1).TabIndex = 81;
      ((Control) this.glassButton1).Text = "&FINGERPRINT(F12)";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click_1);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(937, 218);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(59, 27);
      ((Control) this.glassButton2).TabIndex = 82;
      ((Control) this.glassButton2).Text = "&SELECT PHOTO";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.glassButton3.BackColor = Color.LightBlue;
      ((Control) this.glassButton3).ContextMenuStrip = this.contextMenuStrip2;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(852, 429);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(147, 31);
      ((Control) this.glassButton3).TabIndex = 83;
      ((Control) this.glassButton3).Text = "SELECT &PROOF";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.ForeColor = Color.RoyalBlue;
      this.label22.Location = new Point(384, 517);
      this.label22.Name = "label22";
      this.label22.Size = new Size(153, 20);
      this.label22.TabIndex = 84;
      this.label22.Text = "MONTHLY INCOME";
      this.tbxMonthlyIncome.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMonthlyIncome.CharacterCasing = CharacterCasing.Upper;
      this.tbxMonthlyIncome.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMonthlyIncome.Location = new Point(543, 511);
      this.tbxMonthlyIncome.Name = "tbxMonthlyIncome";
      this.tbxMonthlyIncome.Size = new Size(304, 31);
      this.tbxMonthlyIncome.TabIndex = 21;
      this.tbxMonthlyIncome.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxMonthlyIncome.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tbxMonthlyIncome);
      this.Controls.Add((Control) this.label22);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.btnSpouseNameClear);
      this.Controls.Add((Control) this.btnMotherNameClear);
      this.Controls.Add((Control) this.btnFatherNameClear);
      this.Controls.Add((Control) this.dgvSpouseNameSearch);
      this.Controls.Add((Control) this.dgvMotherNameSearch);
      this.Controls.Add((Control) this.dgvFatherNameSearch);
      this.Controls.Add((Control) this.tbxSpouseCode);
      this.Controls.Add((Control) this.tbxMotherCode);
      this.Controls.Add((Control) this.tbxFatherCode);
      this.Controls.Add((Control) this.tbxSpouseNameSearch);
      this.Controls.Add((Control) this.tbxMotherNameSearch);
      this.Controls.Add((Control) this.tbxFatherNameSearch);
      this.Controls.Add((Control) this.label20);
      this.Controls.Add((Control) this.label19);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.label21);
      this.Controls.Add((Control) this.cbSex);
      this.Controls.Add((Control) this.tbxSpouseName);
      this.Controls.Add((Control) this.tbxMotherName);
      this.Controls.Add((Control) this.tbxFatherName);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnChangePhoto);
      this.Controls.Add((Control) this.btnChangeProof);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.cbAddr3);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.tbxRationCard);
      this.Controls.Add((Control) this.tbxOtherProof);
      this.Controls.Add((Control) this.tbxAadharNumber);
      this.Controls.Add((Control) this.tbxNo);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.tbxNotes);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.tbxInterestRate);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.tbxIntroducer);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.tbxEmail);
      this.Controls.Add((Control) this.tbxCustomerCode);
      this.Controls.Add((Control) this.tbxAlternateContact);
      this.Controls.Add((Control) this.tbxName);
      this.Controls.Add((Control) this.tbxContactNo);
      this.Controls.Add((Control) this.tbxAddr1);
      this.Controls.Add((Control) this.tbxPinCode);
      this.Controls.Add((Control) this.tbxAddr2);
      this.Controls.Add((Control) this.tbxCity);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.pbCustomerPhoto);
      this.Controls.Add((Control) this.pbFingerPrint);
      this.Controls.Add((Control) this.glassButton3);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = nameof (FormEditCustomer);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "EditCustomer";
      this.FormClosing += new FormClosingEventHandler(this.FormEditCustomer_FormClosing);
      this.Load += new EventHandler(this.FormEditCustomer_Load);
      this.KeyDown += new KeyEventHandler(this.FormEditCustomer_KeyDown);
      this.MouseEnter += new EventHandler(this.EditCustomer_MouseEnter);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.pbCustomerPhoto).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.contextMenuStrip2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvSpouseNameSearch).EndInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).EndInit();
      ((ISupportInitialize) this.dgvFatherNameSearch).EndInit();
      ((ISupportInitialize) this.pbFingerPrint).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
