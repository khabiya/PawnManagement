
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
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
  public class FormAddCustomer : Form
  {
    private SS_IDInfo idInfo;
    private byte[] minData;
    private List<string> lstAddress = new List<string>();
    private List<string> lstAddress2 = new List<string>();
    private List<string> lstName = new List<string>();
    private List<string> lsIntroducer = new List<string>();
    public static string newCustomerCodeAdde = "";
    public bool photoTaken = false;
    private IContainer components = (IContainer) null;
    private Label label6;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private TextBox tbxCustomerCode;
    private TextBox tbxAddr2;
    private TextBox tbxAddr1;
    private TextBox tbxName;
    private Label label11;
    private TextBox tbxCity;
    private Label label13;
    private Label label12;
    private TextBox tbxEmail;
    private TextBox tbxAlternateContact;
    private TextBox tbxContactNo;
    private TextBox tbxPinCode;
    private TextBox tbxIntroducer;
    private TextBox tbxNotes;
    private TextBox tbxInterestRate;
    private PictureBox pbPhoto;
    private TextBox tbxNo;
    private TextBox tbxRationCard;
    private TextBox tbxOtherProof;
    private TextBox tbxAadharNumber;
    private Label label7;
    private Label label15;
    private Label label16;
    private Label label17;
    private ComboBox cbAddr3;
    private GlassButton btnTakePhoto;
    private GlassButton btnSaveAndClose;
    private GlassButton btnProof;
    private PictureBox pbProof;
    private GlassButton btnLocationAdd;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private TextBox tbxFatherName;
    private TextBox tbxMotherName;
    private TextBox tbxSpouseName;
    private ComboBox cbSex;
    private Label label14;
    private Label label18;
    private Label label19;
    private Label label20;
    private DataGridView dgvFatherNameSearch;
    private TextBox tbxSpouseNameSearch;
    private TextBox tbxMotherNameSearch;
    private TextBox tbxFatherNameSearch;
    private DataGridView dgvMotherNameSearch;
    private TextBox tbxSpouseCode;
    private TextBox tbxMotherCode;
    private TextBox tbxFatherCode;
    private GlassButton btnFatherNameClear;
    private GlassButton btnMotherNameClear;
    private DataGridView dgvSpouseNameSearch;
    private GlassButton btnSpouseNameClear;
    internal PictureBox pbFingerPrint;
    private ExtendedDotNET.Controls.Panels.Panel panel1;
    private GlassButton btnTakeFingerPrint;
    private GlassButton btnPhotoSelect;
    private GlassButton btnProofSelect;
    private Label label22;
    private TextBox tbxMonthlyIncome;
    private Label label21;

    private void Form1_Closed(object sender, EventArgs e)
    {
    }

    public FormAddCustomer()
    {
      this.InitializeComponent();
      this.CenterToScreen();
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.GreenYellow;
      textBox.ForeColor = Color.Black;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.Black;
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
        PawnManagementClass.InsertIntoException("form addcustomer.getaddress", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape && DialogResult.Yes == MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo))
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void AddCustomer_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatButtonBlue(ref this.btnTakePhoto);
      PawnManagementClass.formatButtonBlue(ref this.btnSaveAndClose);
      PawnManagementClass.formatButtonRed(ref this.btnProof);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvFatherNameSearch);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvMotherNameSearch);
      PawnManagementClass.formatDataGridViewControl(ref this.dgvSpouseNameSearch);
      try
      {
        this.tbxName.Focus();
        this.tbxName.LostFocus += new EventHandler(this.tbxName_LostFocus);
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
        this.getAddress();
        this.getLocationAndPincode();
        this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxAddr1.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
        this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxAddr2.AutoCompleteCustomSource.AddRange(this.lstAddress2.ToArray());
        this.tbxName.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxName.AutoCompleteCustomSource.AddRange(this.lstName.ToArray());
        this.tbxIntroducer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxIntroducer.AutoCompleteCustomSource.AddRange(this.lsIntroducer.ToArray());
        this.getDefaultLocationAndPincode();
        this.cbSex.SelectedIndex = 0;
        if (FormMain.UseFingerPrint)
          ((Control) this.btnTakeFingerPrint).Enabled = true;
        try
        {
          Array.ForEach<string>(Directory.GetFiles(FormMain.startUpPath + "Photos\\temp\\"), new Action<string>(File.Delete));
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form addcustomer.addcustomer_load firstexception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("FormAddCustomer.AddCustomer_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getLocationAndPincode()
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode order by location asc";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormAddCustomer.getLocationAndPincode", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else
      {
        this.cbAddr3.Items.Clear();
        if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.cbAddr3.Items.Add((object) row["Location"].ToString());
        }
      }
    }

    private void getDefaultLocationAndPincode()
    {
      string strError = "";
      string my_querry = "select Location,City,Pincode from tblPincode where DefaultValue = 'Y'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormAddCustomer.getLocationAndPincode", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else
      {
        if (dataTable2 == null || dataTable2.Rows.Count <= 0)
          return;
        this.cbAddr3.Text = dataTable2.Rows[0].Field<string>("Location");
      }
    }

    private void tbxName_LostFocus(object sender, EventArgs e)
    {
      try
      {
        if (!(this.tbxName.Text.Trim() != ""))
          return;
        char ch = this.tbxName.Text.Trim()[0];
        DataTable dataTable1 = new DataTable();
        string strError = "";
        DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblCustomers where CID like '" + ch.ToString() + "%' order by createdOn desc", ref strError);
        if (dataTable2 != null)
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            this.tbxCustomerCode.Text = ch.ToString() + this.NextCustomerCode(dataTable2);
          else
            this.tbxCustomerCode.Text = ch.ToString() + "1";
        }
        else
        {
          int num = (int) MessageBox.Show("Error while setting customer code. Retry again - " + strError);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form Add Customer.tbxName_Lostfocus", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string getCustomerCode()
    {
      try
      {
        if (this.tbxName.Text.Trim() != "")
        {
          char ch = this.tbxName.Text.Trim()[0];
          DataTable dataTable1 = new DataTable();
          string strError = "";
          DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblCustomers where CID like '" + ch.ToString() + "%' order by createdOn desc", ref strError);
          if (dataTable2 != null)
          {
            if (dataTable2 == null || dataTable2.Rows.Count <= 0)
              return ch.ToString() + "1";
            return ch.ToString() + this.NextCustomerCode(dataTable2);
          }
          int num = (int) MessageBox.Show("Error while setting customer code. Retry again - " + strError);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form Add Customer.tbxName_Lostfocus", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["cid"].ToString().Substring(1)));
      }
      intList.Sort();
      IEnumerable<int> source = Enumerable.Range(1, intList.Max()).Except<int>((IEnumerable<int>) intList);
      return source.Count<int>() > 0 ? source.ElementAt<int>(0).ToString() : (intList.Max() + 1).ToString();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      int num = (int) new FormAddCustomer().ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "customerPhoto").ShowDialog();
        this.photoTaken = true;
        try
        {
          if (this.photoTaken && File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          if (File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbProof.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
        ((Control) this.btnSaveAndClose).Focus();
      }
      else
        this.tbxName.Select();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this.tbxCustomerCode.Text.ToString());
    }

    private void AddCustomer_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        if (this.photoTaken && File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        if (!File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pbProof.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxAddr1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
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
        PawnManagementClass.InsertIntoException("form add customer.cbaddr3_selectedindexChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxCity.Text = dataTable2.Rows[0].Field<string>("City");
        this.tbxPinCode.Text = dataTable2.Rows[0].Field<string>("Pincode");
      }
    }

    private void AddCustomer_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.F9)
        ;
      if (e.KeyCode == Keys.F12)
        ((Button) this.btnTakePhoto).PerformClick();
      if (e.KeyCode != Keys.F1)
        return;
      ((Button) this.btnSaveAndClose).PerformClick();
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      if (this.tbxCustomerCode.Text.Trim() != "")
      {
        int num = (int) new FormCamera(this.tbxCustomerCode.Text.Trim().ToString(), "proofPhoto").ShowDialog();
        try
        {
          if (this.photoTaken && File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbPhoto.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
          if (File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          {
            using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            {
              this.pbProof.Image = Image.FromStream((Stream) fileStream);
              fileStream.Dispose();
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form add customer.addcustomer_MouseEnter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Enter name first");
      }
      ((Control) this.btnSaveAndClose).Focus();
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
      if (char.IsDigit(keyChar) || keyChar == '\b')
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

    private void tbxPinCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

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
        if (this.tbxContactNo.Text.Trim().Count<char>() == 0 | this.tbxContactNo.Text.Trim().Count<char>() == 10)
          this.SelectNextControl(this.ActiveControl, true, true, true, true);
        else
          this.tbxContactNo.Select();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void btnSaveAndClose_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxName.Text.Trim() == "" || this.tbxCustomerCode.Text.Trim() == "")
        {
          int num = (int) MessageBox.Show("Please enter name");
          this.tbxName.Select();
        }
        else if (this.tbxNo.Text.Trim() == "")
        {
          int num = (int) MessageBox.Show("Enter Number please");
          this.tbxNo.Focus();
        }
        else if (this.tbxAddr1.Text.Trim() == "")
        {
          int num = (int) MessageBox.Show("Enter Address PLEEEEEZ");
          this.tbxAddr1.Focus();
        }
        else
        {
          if (this.cbAddr3.Text == "")
            this.getDefaultLocationAndPincode();
          else if (!(this.cbAddr3.Text != "") || !this.cbAddr3.Items.Contains((object) this.cbAddr3.Text))
          {
            this.cbAddr3.Select();
            return;
          }
          if (this.tbxMonthlyIncome.Text.Trim() == "")
          {
            this.tbxMonthlyIncome.Select();
          }
          else
          {
            if (this.checkifCustomerAlreadyAdded())
              return;
            if (!this.checkifCustomerAlreadyExists(this.tbxCustomerCode.Text))
            {
              DateTime now;
              if (FormMain.UseFingerPrint && this.minData != null)
              {
                string customerCode = this.tbxCustomerCode.Text.Trim();
                string CustomerName = this.tbxName.Text.Trim();
                string Sex = this.cbSex.Text.Trim();
                string Fathername = this.tbxFatherCode.Text.Trim();
                string MotherName = this.tbxMotherCode.Text.Trim();
                string SpouseName = this.tbxSpouseCode.Text.Trim();
                string CPhone = this.tbxContactNo.Text.Trim();
                string AlternateNumber = this.tbxAlternateContact.Text.Trim();
                string CNo = this.tbxNo.Text.Trim();
                string CAddr1 = this.tbxAddr1.Text.Trim();
                string Caddr2 = this.tbxAddr2.Text.Trim();
                string CAddr3 = this.cbAddr3.Text.Trim();
                string City = this.tbxCity.Text.Trim();
                string Pincode = this.tbxPinCode.Text.Trim();
                string Introducer = this.tbxIntroducer.Text.Trim();
                string AdharNumber = this.tbxAadharNumber.Text.Trim();
                string OtherProof = this.tbxOtherProof.Text.Trim();
                string RationCard = this.tbxRationCard.Text.Trim();
                string InterestRate = this.tbxInterestRate.Text.Trim() == "" ? "0" : this.tbxInterestRate.Text.Trim();
                string Email = this.tbxEmail.Text.Trim();
                string Notes = this.tbxNotes.Text.Trim();
                string username = FormMain.username;
                now = DateTime.Now;
                string CreatedOn = now.ToString();
                byte[] minData = this.minData;
                int fingerNumber = (int) this.idInfo.FingerNumber;
                int sampleNumber = (int) this.idInfo.SampleNumber;
                string text = CustomersClass.saveFingerPrint(customerCode, CustomerName, Sex, Fathername, MotherName, SpouseName, CPhone, AlternateNumber, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Introducer, AdharNumber, OtherProof, RationCard, InterestRate, Email, Notes, username, CreatedOn, minData, fingerNumber, sampleNumber);
                if (text == "Done")
                {
                  FormMain.m_SecuSearch.RegisterFP(this.minData, this.idInfo);
                }
                else
                {
                  int num = (int) MessageBox.Show(text);
                }
              }
              else
              {
                string customerCode = this.tbxCustomerCode.Text.Trim();
                string CustomerName = this.tbxName.Text.Trim();
                string Sex = this.cbSex.Text.Trim();
                string Fathername = this.tbxFatherCode.Text.Trim();
                string MotherName = this.tbxMotherCode.Text.Trim();
                string SpouseName = this.tbxSpouseCode.Text.Trim();
                string CPhone = this.tbxContactNo.Text.Trim();
                string AlternateNumber = this.tbxAlternateContact.Text.Trim();
                string CNo = this.tbxNo.Text.Trim();
                string CAddr1 = this.tbxAddr1.Text.Trim();
                string Caddr2 = this.tbxAddr2.Text.Trim();
                string CAddr3 = this.cbAddr3.Text.Trim();
                string City = this.tbxCity.Text.Trim();
                string Pincode = this.tbxPinCode.Text.Trim();
                string Introducer = this.tbxIntroducer.Text.Trim();
                string AdharNumber = this.tbxAadharNumber.Text.Trim();
                string OtherProof = this.tbxOtherProof.Text.Trim();
                string RationCard = this.tbxRationCard.Text.Trim();
                string InterestRate = this.tbxInterestRate.Text.Trim() == "" ? "0" : this.tbxInterestRate.Text.Trim();
                string Email = this.tbxEmail.Text.Trim();
                string Notes = this.tbxNotes.Text.Trim();
                double MonthlyIncome = double.Parse(this.tbxMonthlyIncome.Text);
                string username = FormMain.username;
                now = DateTime.Now;
                string CreatedOn = now.ToString();
                if (CustomersClass.Save(customerCode, CustomerName, Sex, Fathername, MotherName, SpouseName, CPhone, AlternateNumber, CNo, CAddr1, Caddr2, CAddr3, City, Pincode, Introducer, AdharNumber, OtherProof, RationCard, InterestRate, Email, Notes, MonthlyIncome, username, CreatedOn) == "Done" && this.tbxSpouseCode.Text != "")
                  CustomersClass.updateRelation("SpouseName", this.tbxSpouseCode.Text, this.tbxCustomerCode.Text);
              }
              if (File.Exists(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
                File.Copy(FormMain.startUpPath + "Photos\\temp\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", true);
              string ActionDetails = "New Customer " + this.tbxCustomerCode.Text.Trim().ToString() + " Added";
              string username1 = FormMain.username;
              now = DateTime.Now;
              string PerformedOn = now.ToString();
              PawnManagementClass.InsertIntoHistory("AddCustomer", ActionDetails, "", "", username1, PerformedOn);
              FormAddCustomer.newCustomerCodeAdde = this.tbxCustomerCode.Text;
              this.Dispose();
              this.Close();
            }
            else
              this.tbxCustomerCode.Text = this.getCustomerCode();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form add customer.btnsaveandclose_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkifCustomerAlreadyExists(string CustomerCode)
    {
      string strError = "";
      string my_querry = "select * from tblcustomers where Cid = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form add customer.checkIfcustomerAlreadyAdded" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private bool checkifCustomerAlreadyAdded()
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry;
      if (FormMain.RemindIfNameAndAddressSame)
      {
        my_querry = "select * from tblcustomers where Cname = @Cname AND CAddr1 = @CAddr1";
        parameters.Add(new OleDbParameter("Cname", (object) this.tbxName.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim().ToString()));
      }
      else
      {
        if (!FormMain.RemindIfNameAddressAndDoorNumberSame)
          return false;
        my_querry = "select * from tblcustomers where Cname = @Cname AND CAddr1 = @CAddr1 AND CNo = @CNo ";
        parameters.Add(new OleDbParameter("Cname", (object) this.tbxName.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CAddr1", (object) this.tbxAddr1.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("CNo", (object) this.tbxNo.Text.Trim().ToString()));
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

    private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar))
        return;
      e.Handled = true;
    }

    private void tbxAddr1_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxAddr1.Text.Trim() != ""))
        return;
      string strError = "";
      string my_querry = "select * from tblcustomers where caddr1 = @addr1 order by createdon desc";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("addr1", (object) this.tbxAddr1.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.tbxAddr1_validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form add customer.tbxAddr1_validating" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxAddr2.Text = dataTable2.Rows[0]["caddr2"].ToString();
        if (this.cbAddr3.Items.Contains((object) dataTable2.Rows[0]["caddr3"].ToString()))
          this.cbAddr3.Text = dataTable2.Rows[0]["caddr3"].ToString();
      }
    }

    private void tbxNo_Enter(object sender, EventArgs e) => this.tbxNo.SelectionStart = this.tbxNo.Text.Length;

    private void cbAddr3_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Up || this.cbAddr3.SelectedIndex != 0)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLocation(this.cbAddr3.Text).ShowDialog();
      this.getLocationAndPincode();
      this.cbAddr3.Select();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
          return;
        File.Delete(FormMain.startUpPath + "Photos\\OthersFront\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png");
        this.pbProof.Image = (Image) null;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void tbxContactNo_Validated(object sender, EventArgs e)
    {
      if (!(this.tbxContactNo.Text.Trim() != ""))
        return;
      string strError = "";
      string my_querry = "select * from tblcustomers where CPhone = @CPhone";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CPhone", (object) this.tbxContactNo.Text.Trim()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.cbaddr3_selectedindexChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving location and pincode" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.tbxContactNo.ForeColor = Color.Red;
        if (DialogResult.Yes == MessageBox.Show("Do you want to see the customer with the same phone number?", "Customer with same phone number exists...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          new FormCustomerNew(dataTable2.Rows[0]["CID"].ToString()).Show();
      }
      else
        this.tbxContactNo.ForeColor = Color.Black;
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
            this.tbxNo.Text = customerDetails.Rows[0]["CNo"].ToString();
            this.tbxAddr1.Text = customerDetails.Rows[0]["CAddr1"].ToString();
            this.tbxAddr2.Text = customerDetails.Rows[0]["CAddr2"].ToString();
            this.cbAddr3.Text = customerDetails.Rows[0]["CAddr3"].ToString();
          }
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

    private void cbSex_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void cbSex_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbSex.Text == ""))
        return;
      this.cbSex.SelectedIndex = 0;
    }

    private void cbAddr3_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void cbAddr3_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbAddr3.Text == "")
        this.getDefaultLocationAndPincode();
      else if (!(this.cbAddr3.Text != "") || !this.cbAddr3.Items.Contains((object) this.cbAddr3.Text))
      {
        if (DialogResult.Yes == MessageBox.Show("New Location. ADD ?", "New Location.Add?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        {
          int num = (int) new FormLocation(this.cbAddr3.Text).ShowDialog();
          this.getLocationAndPincode();
          this.cbAddr3.Select();
        }
        else
          this.cbAddr3.Select();
      }
    }

    private void cbAddr3_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
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
        int imageEx = FormMain.m_FPM.GetImageEx(numArray, 1000, this.pbFingerPrint.Handle.ToInt32(), 50);
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

    private void btnTakeFingerPrint_Click(object sender, EventArgs e) => this.takeFingerPrint();

    private void FormAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
      Form openForm = Application.OpenForms["FormMain"];
      if (!FormMain.UseFingerPrint || FormMain.m_FPM == null)
        return;
      if (FormMain.AutoOnfingerPrint)
        FormMain.m_FPM.EnableAutoOnEvent(true, (int) openForm.Handle);
      else
        FormMain.m_FPM.EnableAutoOnEvent(false, 0);
    }

    private void cbAddr3_Enter(object sender, EventArgs e) => this.cbAddr3.BackColor = Color.GreenYellow;

    private void cbAddr3_Leave(object sender, EventArgs e) => this.cbAddr3.BackColor = Color.White;

    private void cbSex_Enter(object sender, EventArgs e) => this.cbSex.BackColor = Color.GreenYellow;

    private void cbSex_Leave(object sender, EventArgs e) => this.cbSex.BackColor = Color.White;

    private void tbxMonthlyIncome_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return | e.KeyCode == Keys.Down)
      {
        ((Control) this.btnSaveAndClose).Focus();
      }
      else
      {
        if (e.KeyCode != Keys.Up)
          return;
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
    }

    private void glassButton1_Click_1(object sender, EventArgs e)
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

    private void glassButton3_Click_1(object sender, EventArgs e)
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
        this.pbProof.Image = Image.FromStream((Stream) fileStream);
        fileStream.Dispose();
      }
    }

    private void tbxName_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxName.Text.Trim() != ""))
        return;
      string nextCustomerCode = CustomersClass.getNextCustomerCode(this.tbxName.Text.Trim()[0]);
      if (nextCustomerCode != "")
      {
        this.tbxCustomerCode.Text = nextCustomerCode;
      }
      else
      {
        int num = (int) MessageBox.Show("ERror. Please Enter Name Correctly");
      }
      if (this.tbxName.Text.Contains("S/O"))
        this.cbSex.Text = "MALE";
      else if (this.tbxName.Text.Contains("D/O") | this.tbxName.Text.Contains("W/O"))
        this.cbSex.Text = "FEMALE";
      else
        this.cbSex.Text = "MALE";
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
      this.tbxNotes = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.tbxIntroducer = new TextBox();
      this.tbxEmail = new TextBox();
      this.tbxAlternateContact = new TextBox();
      this.tbxContactNo = new TextBox();
      this.tbxPinCode = new TextBox();
      this.tbxCity = new TextBox();
      this.tbxAddr2 = new TextBox();
      this.tbxAddr1 = new TextBox();
      this.tbxName = new TextBox();
      this.tbxCustomerCode = new TextBox();
      this.label13 = new Label();
      this.label12 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label11 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.tbxNo = new TextBox();
      this.tbxRationCard = new TextBox();
      this.tbxOtherProof = new TextBox();
      this.tbxAadharNumber = new TextBox();
      this.label7 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.cbAddr3 = new ComboBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.btnProof = new GlassButton();
      this.btnTakePhoto = new GlassButton();
      this.tbxFatherName = new TextBox();
      this.tbxMotherName = new TextBox();
      this.tbxSpouseName = new TextBox();
      this.cbSex = new ComboBox();
      this.label14 = new Label();
      this.label18 = new Label();
      this.label19 = new Label();
      this.label20 = new Label();
      this.dgvFatherNameSearch = new DataGridView();
      this.tbxSpouseNameSearch = new TextBox();
      this.tbxMotherNameSearch = new TextBox();
      this.tbxFatherNameSearch = new TextBox();
      this.dgvMotherNameSearch = new DataGridView();
      this.tbxSpouseCode = new TextBox();
      this.tbxMotherCode = new TextBox();
      this.tbxFatherCode = new TextBox();
      this.btnFatherNameClear = new GlassButton();
      this.btnMotherNameClear = new GlassButton();
      this.dgvSpouseNameSearch = new DataGridView();
      this.btnSpouseNameClear = new GlassButton();
      this.panel1 = new ExtendedDotNET.Controls.Panels.Panel();
      this.label22 = new Label();
      this.tbxMonthlyIncome = new TextBox();
      this.label21 = new Label();
      this.btnProofSelect = new GlassButton();
      this.btnPhotoSelect = new GlassButton();
      this.btnTakeFingerPrint = new GlassButton();
      this.pbFingerPrint = new PictureBox();
      this.pbProof = new PictureBox();
      this.pbPhoto = new PictureBox();
      this.btnSaveAndClose = new GlassButton();
      this.btnLocationAdd = new GlassButton();
      this.contextMenuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dgvFatherNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).BeginInit();
      ((ISupportInitialize) this.dgvSpouseNameSearch).BeginInit();
      ((Control) this.panel1).SuspendLayout();
      ((ISupportInitialize) this.pbFingerPrint).BeginInit();
      ((ISupportInitialize) this.pbProof).BeginInit();
      ((ISupportInitialize) this.pbPhoto).BeginInit();
      this.SuspendLayout();
      this.tbxNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxNotes.CharacterCasing = CharacterCasing.Upper;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(574, 521);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(192, 31);
      this.tbxNotes.TabIndex = 16;
      this.tbxNotes.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxInterestRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxInterestRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(225, 482);
      this.tbxInterestRate.MaxLength = 3;
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(192, 31);
      this.tbxInterestRate.TabIndex = 13;
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxInterestRate_KeyPress);
      this.tbxIntroducer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxIntroducer.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxIntroducer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxIntroducer.CharacterCasing = CharacterCasing.Upper;
      this.tbxIntroducer.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxIntroducer.Location = new Point(225, 521);
      this.tbxIntroducer.Name = "tbxIntroducer";
      this.tbxIntroducer.Size = new Size(192, 31);
      this.tbxIntroducer.TabIndex = 15;
      this.tbxIntroducer.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxEmail.CharacterCasing = CharacterCasing.Upper;
      this.tbxEmail.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxEmail.Location = new Point(574, 483);
      this.tbxEmail.Name = "tbxEmail";
      this.tbxEmail.Size = new Size(192, 31);
      this.tbxEmail.TabIndex = 14;
      this.tbxEmail.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAlternateContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxAlternateContact.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateContact.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateContact.Location = new Point(574, 444);
      this.tbxAlternateContact.MaxLength = 11;
      this.tbxAlternateContact.Name = "tbxAlternateContact";
      this.tbxAlternateContact.Size = new Size(192, 31);
      this.tbxAlternateContact.TabIndex = 12;
      this.tbxAlternateContact.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAlternateContact.KeyPress += new KeyPressEventHandler(this.tbxAlternateContact_KeyPress);
      this.tbxContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxContactNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxContactNo.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxContactNo.Location = new Point(225, 444);
      this.tbxContactNo.MaxLength = 10;
      this.tbxContactNo.Name = "tbxContactNo";
      this.tbxContactNo.Size = new Size(192, 31);
      this.tbxContactNo.TabIndex = 11;
      this.tbxContactNo.KeyDown += new KeyEventHandler(this.tbxContactNo_KeyDown);
      this.tbxContactNo.KeyPress += new KeyPressEventHandler(this.tbxContactNo_KeyPress);
      this.tbxContactNo.Validated += new EventHandler(this.tbxContactNo_Validated);
      this.tbxPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxPinCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPinCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPinCode.Location = new Point(575, 407);
      this.tbxPinCode.Name = "tbxPinCode";
      this.tbxPinCode.Size = new Size(192, 31);
      this.tbxPinCode.TabIndex = 10;
      this.tbxPinCode.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxPinCode.KeyPress += new KeyPressEventHandler(this.tbxPinCode_KeyPress);
      this.tbxCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(225, 407);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(192, 31);
      this.tbxCity.TabIndex = 9;
      this.tbxCity.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxCity.KeyPress += new KeyPressEventHandler(this.tbxPinCode_KeyPress);
      this.tbxAddr2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxAddr2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr2.Location = new Point(226, 333);
      this.tbxAddr2.Name = "tbxAddr2";
      this.tbxAddr2.Size = new Size(540, 31);
      this.tbxAddr2.TabIndex = 7;
      this.tbxAddr2.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAddr1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxAddr1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxAddr1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr1.Location = new Point(226, 296);
      this.tbxAddr1.Name = "tbxAddr1";
      this.tbxAddr1.Size = new Size(540, 31);
      this.tbxAddr1.TabIndex = 6;
      this.tbxAddr1.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAddr1.Validating += new CancelEventHandler(this.tbxAddr1_Validating);
      this.tbxName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxName.CharacterCasing = CharacterCasing.Upper;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(226, 70);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(540, 31);
      this.tbxName.TabIndex = 0;
      this.tbxName.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxName.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxName.Validating += new CancelEventHandler(this.tbxName_Validating);
      this.tbxCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxCustomerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(226, 33);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(541, 31);
      this.tbxCustomerCode.TabIndex = 24;
      this.tbxCustomerCode.KeyPress += new KeyPressEventHandler(this.tbxPinCode_KeyPress);
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.MidnightBlue;
      this.label13.Location = new Point(448, 524);
      this.label13.Name = "label13";
      this.label13.Size = new Size(123, 25);
      this.label13.TabIndex = 32;
      this.label13.Text = "REMINDER";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.MidnightBlue;
      this.label12.Location = new Point(44, 484);
      this.label12.Name = "label12";
      this.label12.Size = new Size(177, 25);
      this.label12.TabIndex = 29;
      this.label12.Text = "INTEREST RATE";
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.MidnightBlue;
      this.label6.Location = new Point(33, 524);
      this.label6.Name = "label6";
      this.label6.Size = new Size(185, 25);
      this.label6.TabIndex = 31;
      this.label6.Text = "INTRODUCED BY";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.MidnightBlue;
      this.label8.Location = new Point(470, 486);
      this.label8.Name = "label8";
      this.label8.Size = new Size(101, 25);
      this.label8.TabIndex = 30;
      this.label8.Text = "EMAIL ID";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.MidnightBlue;
      this.label9.Location = new Point(33, 448);
      this.label9.Name = "label9";
      this.label9.Size = new Size(188, 25);
      this.label9.TabIndex = 27;
      this.label9.Text = "MOBILE NUMBER";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.MidnightBlue;
      this.label10.Location = new Point(423, 448);
      this.label10.Name = "label10";
      this.label10.Size = new Size(148, 25);
      this.label10.TabIndex = 28;
      this.label10.Text = "ALT NUMBER";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.MidnightBlue;
      this.label5.Location = new Point(465, 410);
      this.label5.Name = "label5";
      this.label5.Size = new Size(106, 25);
      this.label5.TabIndex = 26;
      this.label5.Text = "PINCODE";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.MidnightBlue;
      this.label4.Location = new Point(161, 410);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 25);
      this.label4.TabIndex = 25;
      this.label4.Text = "CITY";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.MidnightBlue;
      this.label11.Location = new Point(103, 371);
      this.label11.Name = "label11";
      this.label11.Size = new Size(118, 25);
      this.label11.TabIndex = 24;
      this.label11.Text = "LOCATION";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.MidnightBlue;
      this.label3.Location = new Point(108, 299);
      this.label3.Name = "label3";
      this.label3.Size = new Size(113, 25);
      this.label3.TabIndex = 23;
      this.label3.Text = "ADDRESS";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.MidnightBlue;
      this.label2.Location = new Point(147, 73);
      this.label2.Name = "label2";
      this.label2.Size = new Size(73, 25);
      this.label2.TabIndex = 22;
      this.label2.Text = "NAME";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.MidnightBlue;
      this.label1.Location = new Point(22, 35);
      this.label1.Name = "label1";
      this.label1.Size = new Size(198, 25);
      this.label1.TabIndex = 21;
      this.label1.Text = "CUSTOMER CODE";
      this.tbxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxNo.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNo.Location = new Point(225, 259);
      this.tbxNo.Name = "tbxNo";
      this.tbxNo.Size = new Size(541, 31);
      this.tbxNo.TabIndex = 5;
      this.tbxNo.Text = "NO : ";
      this.tbxNo.Enter += new EventHandler(this.tbxNo_Enter);
      this.tbxNo.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxRationCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxRationCard.CharacterCasing = CharacterCasing.Upper;
      this.tbxRationCard.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRationCard.Location = new Point(574, 558);
      this.tbxRationCard.Name = "tbxRationCard";
      this.tbxRationCard.Size = new Size(193, 31);
      this.tbxRationCard.TabIndex = 18;
      this.tbxRationCard.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxOtherProof.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxOtherProof.CharacterCasing = CharacterCasing.Upper;
      this.tbxOtherProof.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOtherProof.Location = new Point(226, 595);
      this.tbxOtherProof.Name = "tbxOtherProof";
      this.tbxOtherProof.Size = new Size(191, 31);
      this.tbxOtherProof.TabIndex = 19;
      this.tbxOtherProof.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxAadharNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxAadharNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxAadharNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAadharNumber.Location = new Point(225, 557);
      this.tbxAadharNumber.Name = "tbxAadharNumber";
      this.tbxAadharNumber.Size = new Size(192, 31);
      this.tbxAadharNumber.TabIndex = 17;
      this.tbxAadharNumber.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.MidnightBlue;
      this.label7.Location = new Point(178, 262);
      this.label7.Name = "label7";
      this.label7.Size = new Size(43, 25);
      this.label7.TabIndex = 36;
      this.label7.Text = "NO";
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.MidnightBlue;
      this.label15.Location = new Point(416, 561);
      this.label15.Name = "label15";
      this.label15.Size = new Size(155, 25);
      this.label15.TabIndex = 34;
      this.label15.Text = "RATION CARD";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Transparent;
      this.label16.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label16.ForeColor = Color.MidnightBlue;
      this.label16.Location = new Point(57, 598);
      this.label16.Name = "label16";
      this.label16.Size = new Size(165, 25);
      this.label16.TabIndex = 35;
      this.label16.Text = "OTHER PROOF";
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Transparent;
      this.label17.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.MidnightBlue;
      this.label17.Location = new Point(26, 559);
      this.label17.Name = "label17";
      this.label17.Size = new Size(196, 25);
      this.label17.TabIndex = 33;
      this.label17.Text = "AADHAR NUMBER";
      this.cbAddr3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbAddr3.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbAddr3.Font = new Font("Microsoft Sans Serif", 15.75f);
      this.cbAddr3.FormattingEnabled = true;
      this.cbAddr3.Location = new Point(225, 368);
      this.cbAddr3.Name = "cbAddr3";
      this.cbAddr3.Size = new Size(436, 33);
      this.cbAddr3.TabIndex = 8;
      this.cbAddr3.SelectedIndexChanged += new EventHandler(this.cbAddr3_SelectedIndexChanged);
      this.cbAddr3.Enter += new EventHandler(this.cbAddr3_Enter);
      this.cbAddr3.KeyDown += new KeyEventHandler(this.cbAddr3_KeyDown);
      this.cbAddr3.KeyPress += new KeyPressEventHandler(this.cbAddr3_KeyPress);
      this.cbAddr3.KeyUp += new KeyEventHandler(this.cbAddr3_KeyUp);
      this.cbAddr3.Leave += new EventHandler(this.cbAddr3_Leave);
      this.cbAddr3.Validating += new CancelEventHandler(this.cbAddr3_Validating);
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
      this.btnProof.BackColor = Color.LightBlue;
      this.btnProof.FadeOnFocus = true;
      ((Control) this.btnProof).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnProof.ForeColor = Color.MediumBlue;
      this.btnProof.ForeColorOnFocus = Color.Red;
      this.btnProof.ForeColorOnLeave = Color.RoyalBlue;
      this.btnProof.GlowColor = Color.White;
      this.btnProof.InnerBorderColor = Color.Transparent;
      ((Control) this.btnProof).Location = new Point(781, 465);
      ((Control) this.btnProof).Name = "btnProof";
      this.btnProof.OuterBorderColor = Color.MediumSlateBlue;
      this.btnProof.ShineColor = Color.Transparent;
      ((Control) this.btnProof).Size = new Size(88, 30);
      ((Control) this.btnProof).TabIndex = 21;
      ((Control) this.btnProof).Text = "&PROOF";
      ((ButtonBase) this.btnProof).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnProof).Click += new EventHandler(this.glassButton3_Click);
      this.btnTakePhoto.BackColor = Color.LightBlue;
      ((Control) this.btnTakePhoto).BackgroundImageLayout = ImageLayout.Center;
      this.btnTakePhoto.FadeOnFocus = true;
      ((Control) this.btnTakePhoto).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTakePhoto.ForeColor = Color.MediumBlue;
      this.btnTakePhoto.ForeColorOnFocus = Color.Red;
      this.btnTakePhoto.ForeColorOnLeave = Color.RoyalBlue;
      this.btnTakePhoto.GlowColor = Color.White;
      this.btnTakePhoto.InnerBorderColor = Color.Transparent;
      ((Control) this.btnTakePhoto).Location = new Point(782, 205);
      ((Control) this.btnTakePhoto).Name = "btnTakePhoto";
      this.btnTakePhoto.OuterBorderColor = Color.MediumSlateBlue;
      this.btnTakePhoto.ShineColor = Color.Transparent;
      ((Control) this.btnTakePhoto).Size = new Size(190, 28);
      ((Control) this.btnTakePhoto).TabIndex = 20;
      ((Control) this.btnTakePhoto).Text = "&TAKE PHOTO (F12)";
      ((ButtonBase) this.btnTakePhoto).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnTakePhoto).Click += new EventHandler(this.button2_Click);
      this.tbxFatherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxFatherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherName.Location = new Point(226, 148);
      this.tbxFatherName.Name = "tbxFatherName";
      this.tbxFatherName.Size = new Size(333, 31);
      this.tbxFatherName.TabIndex = 66;
      this.tbxFatherName.KeyPress += new KeyPressEventHandler(this.fatherMotherSpouse_keyPress);
      this.tbxMotherName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxMotherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherName.Location = new Point(226, 185);
      this.tbxMotherName.Name = "tbxMotherName";
      this.tbxMotherName.Size = new Size(333, 31);
      this.tbxMotherName.TabIndex = 67;
      this.tbxMotherName.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxMotherName.KeyPress += new KeyPressEventHandler(this.fatherMotherSpouse_keyPress);
      this.tbxSpouseName.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseName.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxSpouseName.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseName.Location = new Point(226, 222);
      this.tbxSpouseName.Name = "tbxSpouseName";
      this.tbxSpouseName.Size = new Size(333, 31);
      this.tbxSpouseName.TabIndex = 68;
      this.tbxSpouseName.KeyDown += new KeyEventHandler(this.tbxName_KeyDown);
      this.tbxSpouseName.KeyPress += new KeyPressEventHandler(this.fatherMotherSpouse_keyPress);
      this.cbSex.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbSex.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbSex.Font = new Font("Microsoft Sans Serif", 15.75f);
      this.cbSex.FormattingEnabled = true;
      this.cbSex.Items.AddRange(new object[2]
      {
        (object) "MALE",
        (object) "FEMALE"
      });
      this.cbSex.Location = new Point(226, 108);
      this.cbSex.Name = "cbSex";
      this.cbSex.Size = new Size(541, 33);
      this.cbSex.TabIndex = 1;
      this.cbSex.Enter += new EventHandler(this.cbSex_Enter);
      this.cbSex.KeyDown += new KeyEventHandler(this.cbSex_KeyDown);
      this.cbSex.KeyPress += new KeyPressEventHandler(this.cbSex_KeyPress);
      this.cbSex.Leave += new EventHandler(this.cbSex_Leave);
      this.cbSex.Validating += new CancelEventHandler(this.cbSex_Validating);
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.MidnightBlue;
      this.label14.Location = new Point(58, 150);
      this.label14.Name = "label14";
      this.label14.Size = new Size(163, 25);
      this.label14.TabIndex = 50;
      this.label14.Text = "FATHER NAME";
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label18.ForeColor = Color.MidnightBlue;
      this.label18.Location = new Point(51, 188);
      this.label18.Name = "label18";
      this.label18.Size = new Size(170, 25);
      this.label18.TabIndex = 51;
      this.label18.Text = "MOTHER NAME";
      this.label19.AutoSize = true;
      this.label19.BackColor = Color.Transparent;
      this.label19.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.ForeColor = Color.MidnightBlue;
      this.label19.Location = new Point(26, 225);
      this.label19.Name = "label19";
      this.label19.Size = new Size(195, 25);
      this.label19.TabIndex = 52;
      this.label19.Text = "HUSB/WIFE NAME";
      this.label20.AutoSize = true;
      this.label20.BackColor = Color.Transparent;
      this.label20.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.ForeColor = Color.MidnightBlue;
      this.label20.Location = new Point(166, 112);
      this.label20.Name = "label20";
      this.label20.Size = new Size(54, 25);
      this.label20.TabIndex = 53;
      this.label20.Text = "SEX";
      this.dgvFatherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFatherNameSearch.Location = new Point(27, 265);
      this.dgvFatherNameSearch.Name = "dgvFatherNameSearch";
      this.dgvFatherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvFatherNameSearch.Size = new Size(738, 280);
      this.dgvFatherNameSearch.TabIndex = 54;
      this.dgvFatherNameSearch.Visible = false;
      this.dgvFatherNameSearch.KeyDown += new KeyEventHandler(this.dgvCustomerDetails_KeyDown);
      this.tbxSpouseNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxSpouseNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseNameSearch.Location = new Point(565, 222);
      this.tbxSpouseNameSearch.Name = "tbxSpouseNameSearch";
      this.tbxSpouseNameSearch.Size = new Size(201, 31);
      this.tbxSpouseNameSearch.TabIndex = 4;
      this.tbxSpouseNameSearch.TextChanged += new EventHandler(this.tbxSpouseNameSearch_TextChanged);
      this.tbxSpouseNameSearch.KeyDown += new KeyEventHandler(this.tbxSpouseName_KeyDown);
      this.tbxMotherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxMotherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherNameSearch.Location = new Point(565, 185);
      this.tbxMotherNameSearch.Name = "tbxMotherNameSearch";
      this.tbxMotherNameSearch.Size = new Size(201, 31);
      this.tbxMotherNameSearch.TabIndex = 3;
      this.tbxMotherNameSearch.TextChanged += new EventHandler(this.tbxMotherNameSearch_TextChanged);
      this.tbxMotherNameSearch.KeyDown += new KeyEventHandler(this.tbxMotherName_KeyDown);
      this.tbxFatherNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxFatherNameSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherNameSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherNameSearch.Location = new Point(565, 148);
      this.tbxFatherNameSearch.Name = "tbxFatherNameSearch";
      this.tbxFatherNameSearch.Size = new Size(201, 31);
      this.tbxFatherNameSearch.TabIndex = 2;
      this.tbxFatherNameSearch.TextChanged += new EventHandler(this.tbxFatherNameSearch_TextChanged);
      this.tbxFatherNameSearch.KeyDown += new KeyEventHandler(this.tbxFatherName_KeyDown);
      this.dgvMotherNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvMotherNameSearch.Location = new Point(27, 265);
      this.dgvMotherNameSearch.Name = "dgvMotherNameSearch";
      this.dgvMotherNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvMotherNameSearch.Size = new Size(738, 279);
      this.dgvMotherNameSearch.TabIndex = 69;
      this.dgvMotherNameSearch.Visible = false;
      this.dgvMotherNameSearch.KeyDown += new KeyEventHandler(this.dgvMotherNameSearch_KeyDown);
      this.tbxSpouseCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxSpouseCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxSpouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxSpouseCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxSpouseCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSpouseCode.Location = new Point(153, 222);
      this.tbxSpouseCode.Name = "tbxSpouseCode";
      this.tbxSpouseCode.Size = new Size(66, 31);
      this.tbxSpouseCode.TabIndex = 73;
      this.tbxSpouseCode.Visible = false;
      this.tbxMotherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxMotherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxMotherCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxMotherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxMotherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMotherCode.Location = new Point(153, 185);
      this.tbxMotherCode.Name = "tbxMotherCode";
      this.tbxMotherCode.Size = new Size(66, 31);
      this.tbxMotherCode.TabIndex = 72;
      this.tbxMotherCode.Visible = false;
      this.tbxFatherCode.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.tbxFatherCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxFatherCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxFatherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxFatherCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFatherCode.Location = new Point(153, 148);
      this.tbxFatherCode.Name = "tbxFatherCode";
      this.tbxFatherCode.Size = new Size(66, 31);
      this.tbxFatherCode.TabIndex = 71;
      this.tbxFatherCode.Visible = false;
      this.btnFatherNameClear.BackColor = Color.LightBlue;
      this.btnFatherNameClear.FadeOnFocus = true;
      ((Control) this.btnFatherNameClear).Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFatherNameClear.ForeColor = Color.MediumBlue;
      this.btnFatherNameClear.ForeColorOnFocus = Color.Red;
      this.btnFatherNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnFatherNameClear.GlowColor = Color.White;
      this.btnFatherNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnFatherNameClear).Location = new Point(516, 151);
      ((Control) this.btnFatherNameClear).Name = "btnFatherNameClear";
      this.btnFatherNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnFatherNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnFatherNameClear).Size = new Size(40, 25);
      ((Control) this.btnFatherNameClear).TabIndex = 74;
      ((Control) this.btnFatherNameClear).Text = "Clear";
      ((Control) this.btnFatherNameClear).Click += new EventHandler(this.btnFatherNameClear_Click);
      this.btnMotherNameClear.BackColor = Color.LightBlue;
      this.btnMotherNameClear.FadeOnFocus = true;
      ((Control) this.btnMotherNameClear).Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnMotherNameClear.ForeColor = Color.MediumBlue;
      this.btnMotherNameClear.ForeColorOnFocus = Color.Red;
      this.btnMotherNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnMotherNameClear.GlowColor = Color.White;
      this.btnMotherNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnMotherNameClear).Location = new Point(516, 188);
      ((Control) this.btnMotherNameClear).Name = "btnMotherNameClear";
      this.btnMotherNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnMotherNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnMotherNameClear).Size = new Size(40, 26);
      ((Control) this.btnMotherNameClear).TabIndex = 75;
      ((Control) this.btnMotherNameClear).Text = "Clear";
      ((Control) this.btnMotherNameClear).Click += new EventHandler(this.btnMotherNameClear_Click);
      this.dgvSpouseNameSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSpouseNameSearch.Location = new Point(27, 262);
      this.dgvSpouseNameSearch.Name = "dgvSpouseNameSearch";
      this.dgvSpouseNameSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSpouseNameSearch.Size = new Size(738, 280);
      this.dgvSpouseNameSearch.TabIndex = 70;
      this.dgvSpouseNameSearch.Visible = false;
      this.dgvSpouseNameSearch.KeyDown += new KeyEventHandler(this.dgvSpouseNameSearch_KeyDown);
      this.btnSpouseNameClear.BackColor = Color.LightBlue;
      this.btnSpouseNameClear.FadeOnFocus = true;
      ((Control) this.btnSpouseNameClear).Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSpouseNameClear.ForeColor = Color.MediumBlue;
      this.btnSpouseNameClear.ForeColorOnFocus = Color.Red;
      this.btnSpouseNameClear.ForeColorOnLeave = Color.MediumBlue;
      this.btnSpouseNameClear.GlowColor = Color.White;
      this.btnSpouseNameClear.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSpouseNameClear).Location = new Point(516, 225);
      ((Control) this.btnSpouseNameClear).Name = "btnSpouseNameClear";
      this.btnSpouseNameClear.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSpouseNameClear.ShineColor = Color.Transparent;
      ((Control) this.btnSpouseNameClear).Size = new Size(40, 25);
      ((Control) this.btnSpouseNameClear).TabIndex = 76;
      ((Control) this.btnSpouseNameClear).Text = "Clear";
      ((Control) this.btnSpouseNameClear).Click += new EventHandler(this.btnSpouseNameClear_Click);
      this.panel1.Border = true;
      this.panel1.BorderColor = SystemColors.ActiveCaption;
      ((System.Windows.Forms.Panel) this.panel1).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.BorderWidth = 1;
      this.panel1.Caption = true;
      this.panel1.CaptionBeginColor = Color.PowderBlue;
      this.panel1.CaptionEndColor = Color.AliceBlue;
      this.panel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.panel1.CaptionHeight = 30;
      this.panel1.CaptionText = "ADD NEW CUSTOMER";
      this.panel1.CaptionTextAlignment = StringAlignment.Near;
      this.panel1.CaptionTextColor = Color.Black;
      ((Control) this.panel1).Controls.Add((Control) this.label22);
      ((Control) this.panel1).Controls.Add((Control) this.tbxMonthlyIncome);
      ((Control) this.panel1).Controls.Add((Control) this.label21);
      ((Control) this.panel1).Controls.Add((Control) this.btnProofSelect);
      ((Control) this.panel1).Controls.Add((Control) this.btnPhotoSelect);
      ((Control) this.panel1).Controls.Add((Control) this.btnTakeFingerPrint);
      ((Control) this.panel1).Controls.Add((Control) this.dgvSpouseNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.dgvMotherNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.dgvFatherNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.label14);
      ((Control) this.panel1).Controls.Add((Control) this.label19);
      ((Control) this.panel1).Controls.Add((Control) this.label18);
      ((Control) this.panel1).Controls.Add((Control) this.tbxCity);
      ((Control) this.panel1).Controls.Add((Control) this.pbFingerPrint);
      ((Control) this.panel1).Controls.Add((Control) this.tbxAddr2);
      ((Control) this.panel1).Controls.Add((Control) this.btnSpouseNameClear);
      ((Control) this.panel1).Controls.Add((Control) this.tbxPinCode);
      ((Control) this.panel1).Controls.Add((Control) this.btnMotherNameClear);
      ((Control) this.panel1).Controls.Add((Control) this.tbxAddr1);
      ((Control) this.panel1).Controls.Add((Control) this.pbProof);
      ((Control) this.panel1).Controls.Add((Control) this.btnFatherNameClear);
      ((Control) this.panel1).Controls.Add((Control) this.pbPhoto);
      ((Control) this.panel1).Controls.Add((Control) this.tbxContactNo);
      ((Control) this.panel1).Controls.Add((Control) this.tbxSpouseCode);
      ((Control) this.panel1).Controls.Add((Control) this.tbxName);
      ((Control) this.panel1).Controls.Add((Control) this.tbxMotherCode);
      ((Control) this.panel1).Controls.Add((Control) this.tbxAlternateContact);
      ((Control) this.panel1).Controls.Add((Control) this.tbxFatherCode);
      ((Control) this.panel1).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.panel1).Controls.Add((Control) this.tbxEmail);
      ((Control) this.panel1).Controls.Add((Control) this.label8);
      ((Control) this.panel1).Controls.Add((Control) this.tbxSpouseNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.label6);
      ((Control) this.panel1).Controls.Add((Control) this.tbxMotherNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.label9);
      ((Control) this.panel1).Controls.Add((Control) this.tbxFatherNameSearch);
      ((Control) this.panel1).Controls.Add((Control) this.label12);
      ((Control) this.panel1).Controls.Add((Control) this.label10);
      ((Control) this.panel1).Controls.Add((Control) this.tbxAadharNumber);
      ((Control) this.panel1).Controls.Add((Control) this.label13);
      ((Control) this.panel1).Controls.Add((Control) this.label20);
      ((Control) this.panel1).Controls.Add((Control) this.label5);
      ((Control) this.panel1).Controls.Add((Control) this.tbxIntroducer);
      ((Control) this.panel1).Controls.Add((Control) this.label4);
      ((Control) this.panel1).Controls.Add((Control) this.tbxInterestRate);
      ((Control) this.panel1).Controls.Add((Control) this.cbSex);
      ((Control) this.panel1).Controls.Add((Control) this.label11);
      ((Control) this.panel1).Controls.Add((Control) this.tbxSpouseName);
      ((Control) this.panel1).Controls.Add((Control) this.tbxNotes);
      ((Control) this.panel1).Controls.Add((Control) this.tbxMotherName);
      ((Control) this.panel1).Controls.Add((Control) this.label3);
      ((Control) this.panel1).Controls.Add((Control) this.tbxFatherName);
      ((Control) this.panel1).Controls.Add((Control) this.label2);
      ((Control) this.panel1).Controls.Add((Control) this.tbxRationCard);
      ((Control) this.panel1).Controls.Add((Control) this.label1);
      ((Control) this.panel1).Controls.Add((Control) this.tbxNo);
      ((Control) this.panel1).Controls.Add((Control) this.tbxOtherProof);
      ((Control) this.panel1).Controls.Add((Control) this.btnProof);
      ((Control) this.panel1).Controls.Add((Control) this.label7);
      ((Control) this.panel1).Controls.Add((Control) this.btnSaveAndClose);
      ((Control) this.panel1).Controls.Add((Control) this.label17);
      ((Control) this.panel1).Controls.Add((Control) this.btnTakePhoto);
      ((Control) this.panel1).Controls.Add((Control) this.label16);
      ((Control) this.panel1).Controls.Add((Control) this.cbAddr3);
      ((Control) this.panel1).Controls.Add((Control) this.label15);
      ((Control) this.panel1).Controls.Add((Control) this.btnLocationAdd);
      ((Control) this.panel1).Dock = DockStyle.Fill;
      ((Control) this.panel1).Font = new Font("Arial", 14f);
      this.panel1.GradientDirection = LinearGradientMode.Vertical;
      this.panel1.GradientEnd = Color.AliceBlue;
      this.panel1.GradientStart = Color.Azure;
      this.panel1.IconVisible = false;
      ((Control) this.panel1).Location = new Point(0, 0);
      ((Control) this.panel1).Name = "panel1";
      this.panel1.PanelIcon = (Icon) null;
      ((Control) this.panel1).Size = new Size(980, 700);
      this.panel1.Style = ExtendedDotNET.Controls.BorderStyle.Single;
      ((Control) this.panel1).TabIndex = 78;
      this.panel1.TextAntialias = true;
      ((Control) this.panel1).Paint += new PaintEventHandler(this.panel1_Paint);
      this.label22.AutoSize = true;
      this.label22.BackColor = Color.Transparent;
      this.label22.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.ForeColor = Color.MidnightBlue;
      this.label22.Location = new Point(417, 597);
      this.label22.Name = "label22";
      this.label22.Size = new Size(205, 25);
      this.label22.TabIndex = 83;
      this.label22.Text = "MONTHLY INCOME";
      this.tbxMonthlyIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxMonthlyIncome.CharacterCasing = CharacterCasing.Upper;
      this.tbxMonthlyIncome.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMonthlyIncome.Location = new Point(623, 593);
      this.tbxMonthlyIncome.Name = "tbxMonthlyIncome";
      this.tbxMonthlyIncome.Size = new Size(143, 31);
      this.tbxMonthlyIncome.TabIndex = 20;
      this.tbxMonthlyIncome.Text = "0";
      this.tbxMonthlyIncome.KeyDown += new KeyEventHandler(this.tbxMonthlyIncome_KeyDown);
      this.tbxMonthlyIncome.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.label21.AutoSize = true;
      this.label21.BackColor = Color.Transparent;
      this.label21.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = Color.MidnightBlue;
      this.label21.Location = new Point(417, 597);
      this.label21.Name = "label21";
      this.label21.Size = new Size(0, 25);
      this.label21.TabIndex = 81;
      this.btnProofSelect.BackColor = Color.LightBlue;
      ((Control) this.btnProofSelect).BackgroundImageLayout = ImageLayout.Center;
      this.btnProofSelect.FadeOnFocus = true;
      ((Control) this.btnProofSelect).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnProofSelect.ForeColor = Color.MediumBlue;
      this.btnProofSelect.ForeColorOnFocus = Color.Red;
      this.btnProofSelect.ForeColorOnLeave = Color.RoyalBlue;
      this.btnProofSelect.GlowColor = Color.White;
      ((ButtonBase) this.btnProofSelect).ImageAlign = ContentAlignment.MiddleLeft;
      this.btnProofSelect.InnerBorderColor = Color.Transparent;
      ((Control) this.btnProofSelect).Location = new Point(875, 465);
      ((Control) this.btnProofSelect).Name = "btnProofSelect";
      this.btnProofSelect.OuterBorderColor = Color.MediumSlateBlue;
      this.btnProofSelect.ShineColor = Color.Transparent;
      ((Control) this.btnProofSelect).Size = new Size(97, 30);
      ((Control) this.btnProofSelect).TabIndex = 80;
      ((Control) this.btnProofSelect).Text = "SELECT PHOTO";
      ((ButtonBase) this.btnProofSelect).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnProofSelect).Click += new EventHandler(this.glassButton3_Click_1);
      this.btnPhotoSelect.BackColor = Color.LightBlue;
      ((Control) this.btnPhotoSelect).BackgroundImageLayout = ImageLayout.Center;
      this.btnPhotoSelect.FadeOnFocus = true;
      ((Control) this.btnPhotoSelect).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPhotoSelect.ForeColor = Color.MediumBlue;
      this.btnPhotoSelect.ForeColorOnFocus = Color.Red;
      this.btnPhotoSelect.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPhotoSelect.GlowColor = Color.White;
      ((ButtonBase) this.btnPhotoSelect).ImageAlign = ContentAlignment.MiddleLeft;
      this.btnPhotoSelect.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPhotoSelect).Location = new Point(782, 239);
      ((Control) this.btnPhotoSelect).Name = "btnPhotoSelect";
      this.btnPhotoSelect.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPhotoSelect.ShineColor = Color.Transparent;
      ((Control) this.btnPhotoSelect).Size = new Size(190, 30);
      ((Control) this.btnPhotoSelect).TabIndex = 79;
      ((Control) this.btnPhotoSelect).Text = "SELECT PHOTO";
      ((ButtonBase) this.btnPhotoSelect).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPhotoSelect).Click += new EventHandler(this.glassButton1_Click_1);
      this.btnTakeFingerPrint.BackColor = Color.LightBlue;
      ((Control) this.btnTakeFingerPrint).Enabled = false;
      this.btnTakeFingerPrint.FadeOnFocus = true;
      ((Control) this.btnTakeFingerPrint).Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTakeFingerPrint.ForeColor = Color.MediumBlue;
      this.btnTakeFingerPrint.ForeColorOnFocus = Color.Red;
      this.btnTakeFingerPrint.ForeColorOnLeave = Color.RoyalBlue;
      this.btnTakeFingerPrint.GlowColor = Color.White;
      this.btnTakeFingerPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnTakeFingerPrint).Location = new Point(781, 657);
      ((Control) this.btnTakeFingerPrint).Name = "btnTakeFingerPrint";
      this.btnTakeFingerPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnTakeFingerPrint.ShineColor = Color.Transparent;
      ((Control) this.btnTakeFingerPrint).Size = new Size(190, 28);
      ((Control) this.btnTakeFingerPrint).TabIndex = 78;
      ((Control) this.btnTakeFingerPrint).Text = "&TAKE FINGERPRINT";
      ((ButtonBase) this.btnTakeFingerPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnTakeFingerPrint).Click += new EventHandler(this.btnTakeFingerPrint_Click);
      this.pbFingerPrint.BackColor = Color.AliceBlue;
      this.pbFingerPrint.Location = new Point(781, 499);
      this.pbFingerPrint.Name = "pbFingerPrint";
      this.pbFingerPrint.Size = new Size(190, 152);
      this.pbFingerPrint.TabIndex = 77;
      this.pbFingerPrint.TabStop = false;
      this.pbProof.BackColor = Color.AliceBlue;
      this.pbProof.ContextMenuStrip = this.contextMenuStrip1;
      this.pbProof.Location = new Point(781, 275);
      this.pbProof.Name = "pbProof";
      this.pbProof.Size = new Size(190, 185);
      this.pbProof.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbProof.TabIndex = 44;
      this.pbProof.TabStop = false;
      this.pbPhoto.BackColor = Color.AliceBlue;
      this.pbPhoto.Location = new Point(782, 35);
      this.pbPhoto.Name = "pbPhoto";
      this.pbPhoto.Size = new Size(189, 164);
      this.pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbPhoto.TabIndex = 26;
      this.pbPhoto.TabStop = false;
      this.btnSaveAndClose.BackColor = Color.LightBlue;
      this.btnSaveAndClose.FadeOnFocus = true;
      ((Control) this.btnSaveAndClose).Font = new Font("Comic Sans MS", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSaveAndClose.ForeColor = Color.MediumBlue;
      this.btnSaveAndClose.ForeColorOnFocus = Color.Red;
      this.btnSaveAndClose.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSaveAndClose.GlowColor = Color.White;
      ((ButtonBase) this.btnSaveAndClose).Image = (Image) Resources.SAVE;
      this.btnSaveAndClose.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSaveAndClose).Location = new Point(560, 632);
      ((Control) this.btnSaveAndClose).Name = "btnSaveAndClose";
      this.btnSaveAndClose.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSaveAndClose.ShineColor = Color.Transparent;
      ((Control) this.btnSaveAndClose).Size = new Size(206, 53);
      ((Control) this.btnSaveAndClose).TabIndex = 22;
      ((Control) this.btnSaveAndClose).Text = "&SAVE (F1)";
      ((ButtonBase) this.btnSaveAndClose).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSaveAndClose).Click += new EventHandler(this.btnSaveAndClose_Click);
      this.btnLocationAdd.BackColor = Color.LightBlue;
      this.btnLocationAdd.FadeOnFocus = true;
      ((Control) this.btnLocationAdd).Font = new Font("Comic Sans MS", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnLocationAdd.ForeColor = Color.MediumBlue;
      this.btnLocationAdd.ForeColorOnFocus = Color.Red;
      this.btnLocationAdd.ForeColorOnLeave = Color.RoyalBlue;
      this.btnLocationAdd.GlowColor = Color.White;
      ((ButtonBase) this.btnLocationAdd).Image = (Image) Resources.plus;
      this.btnLocationAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnLocationAdd).Location = new Point(665, 368);
      ((Control) this.btnLocationAdd).Name = "btnLocationAdd";
      this.btnLocationAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnLocationAdd.ShineColor = Color.Transparent;
      ((Control) this.btnLocationAdd).Size = new Size(100, 33);
      ((Control) this.btnLocationAdd).TabIndex = 45;
      ((Control) this.btnLocationAdd).Text = "&ADD";
      ((ButtonBase) this.btnLocationAdd).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnLocationAdd).Click += new EventHandler(this.glassButton2_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(980, 700);
      this.Controls.Add((Control) this.panel1);
      this.ForeColor = Color.Blue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.KeyPreview = true;
      this.Name = nameof (FormAddCustomer);
      this.Text = "AddCustomer";
      this.FormClosing += new FormClosingEventHandler(this.FormAddCustomer_FormClosing);
      this.Load += new EventHandler(this.AddCustomer_Load);
      this.KeyDown += new KeyEventHandler(this.AddCustomer_KeyDown);
      this.MouseEnter += new EventHandler(this.AddCustomer_MouseEnter);
      this.contextMenuStrip1.ResumeLayout(false);
      ((ISupportInitialize) this.dgvFatherNameSearch).EndInit();
      ((ISupportInitialize) this.dgvMotherNameSearch).EndInit();
      ((ISupportInitialize) this.dgvSpouseNameSearch).EndInit();
      ((Control) this.panel1).ResumeLayout(false);
      ((Control) this.panel1).PerformLayout();
      ((ISupportInitialize) this.pbFingerPrint).EndInit();
      ((ISupportInitialize) this.pbProof).EndInit();
      ((ISupportInitialize) this.pbPhoto).EndInit();
      this.ResumeLayout(false);
    }
  }
}
