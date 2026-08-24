
using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormDeleteDuplicateCustomer : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox tbxCustomerCode;
    private TextBox tbxAlternateContact;
    private Label label9;
    private Label label5;
    private TextBox tbxPinCode;
    private Label label11;
    private TextBox tbxCity;
    private Label label6;
    private TextBox tbxAddr3;
    private Label label7;
    private TextBox tbxAddr2;
    private TextBox tbxAddr1;
    private TextBox tbxDoorNumber;
    private Label label29;
    private TextBox tbxName;
    private TextBox tbxPhoneNumber;
    private Label label34;
    private Label label1;
    private GlassButton glassButton1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private TextBox tbxName2;
    private TextBox tbxCustomerCode2;
    private Label label2;
    private TextBox tbxDoorNumber2;
    private TextBox tbxAddr12;
    private TextBox tbxAddr22;
    private Label label3;
    private Label label4;
    private TextBox tbxPhoneNumber2;
    private TextBox tbxAddr32;
    private Label label8;
    private TextBox tbxCity2;
    private Label label10;
    private TextBox tbxPincode2;
    private Label label12;
    private Label label13;
    private Label label14;
    private TextBox tbxAlternateNumber2;
    private TableLayoutPanel tableLayoutPanel1;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel panel2;
    private Label label15;
    private Panel panel3;

    public FormDeleteDuplicateCustomer() => this.InitializeComponent();

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      this.tbxCustomerCode2.Select();
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from tblCustomers where CId = @Cid", new List<OleDbParameter>()
      {
        new OleDbParameter("Cid", (object) this.tbxCustomerCode.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DeleteDuplicateCustomer.textBox1_Validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
      {
        this.tbxName.Text = dataTable.Rows[0]["CName"].ToString();
        this.tbxDoorNumber.Text = dataTable.Rows[0]["CNo"].ToString();
        this.tbxAddr1.Text = dataTable.Rows[0]["CAddr1"].ToString();
        this.tbxAddr2.Text = dataTable.Rows[0]["CAddr2"].ToString();
        this.tbxAddr3.Text = dataTable.Rows[0]["CAddr3"].ToString();
        this.tbxCity.Text = dataTable.Rows[0]["CCity"].ToString();
        this.tbxPinCode.Text = dataTable.Rows[0]["CPincode"].ToString();
        this.tbxPhoneNumber.Text = dataTable.Rows[0]["CPhone"].ToString();
        this.tbxAlternateContact.Text = dataTable.Rows[0]["CCell"].ToString();
        this.getPendingPledgeDetails(this.tbxCustomerCode.Text);
      }
      else
        this.tbxCustomerCode.Select();
    }

    private void textBox2_Validating(object sender, CancelEventArgs e)
    {
      ((Control) this.glassButton1).Focus();
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from tblCustomers where CId = @Cid", new List<OleDbParameter>()
      {
        new OleDbParameter("Cid", (object) this.tbxCustomerCode2.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DeleteDuplicateCustomer.textBox2_Validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
      {
        this.tbxName2.Text = dataTable.Rows[0]["CName"].ToString();
        this.tbxDoorNumber2.Text = dataTable.Rows[0]["CNo"].ToString();
        this.tbxAddr12.Text = dataTable.Rows[0]["CAddr1"].ToString();
        this.tbxAddr22.Text = dataTable.Rows[0]["CAddr2"].ToString();
        this.tbxAddr32.Text = dataTable.Rows[0]["CAddr3"].ToString();
        this.tbxCity2.Text = dataTable.Rows[0]["CCity"].ToString();
        this.tbxPincode2.Text = dataTable.Rows[0]["CPincode"].ToString();
        this.tbxPhoneNumber2.Text = dataTable.Rows[0]["CPhone"].ToString();
        this.tbxAlternateNumber2.Text = dataTable.Rows[0]["CCell"].ToString();
        this.getPendingPledgeDetails2(this.tbxCustomerCode2.Text);
      }
      else
        this.tbxCustomerCode2.Select();
    }

    private bool checkIfCustomercodeExists() => false;

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.tbxName.Text != "" && this.tbxCustomerCode.Text != "")
      {
        if (this.tbxName2.Text != "" && this.tbxCustomerCode2.Text != "")
        {
          if (this.tbxCustomerCode.Text != this.tbxCustomerCode2.Text)
          {
            if (DialogResult.Yes != MessageBox.Show("Delete the duplicate customer  - " + this.tbxCustomerCode2.Text, "Delete Duplicate Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
              return;
            this.deleteDuplicateCustomer();
          }
          else
          {
            int num1 = (int) MessageBox.Show(" Both the customers are same");
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Please select the duplicate customer");
        }
      }
      else
      {
        int num3 = (int) MessageBox.Show("Please select the original customer");
      }
    }

    private void deleteDuplicateCustomer()
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("Update tblPledge set CustomerCode = @CustomerCode1,CustomerName = @CustomerName,DoorNumber = @DoorNumber,Addr1=@Addr1,Addr2=@Addr2,Addr3=@Addr3,city = @city,pincode = @pincode,phonenumber = @phonenumber where CustomerCode = @CustomerCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CustomerCode1", (object) this.tbxCustomerCode.Text.Trim()),
        new OleDbParameter("CustomerName", (object) this.tbxName.Text.Trim()),
        new OleDbParameter("DoorNumber", (object) this.tbxDoorNumber.Text.Trim()),
        new OleDbParameter("Addr1", (object) this.tbxAddr1.Text.Trim()),
        new OleDbParameter("Addr2", (object) this.tbxAddr2.Text.Trim()),
        new OleDbParameter("Addr3", (object) this.tbxAddr3.Text.Trim()),
        new OleDbParameter("city", (object) this.tbxCity.Text.Trim()),
        new OleDbParameter("pincode", (object) this.tbxPinCode.Text.Trim()),
        new OleDbParameter("phonemumber", (object) this.tbxPhoneNumber.Text.Trim()),
        new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode2.Text.Trim())
      }, ref strError1) != "Done")
      {
        PawnManagementClass.InsertIntoException("form deleteDuplicateCustomer", strError1, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in updating" + strError1);
      }
      string strError2 = "";
      if (SQLHelper.RunCommand("Update tblRedemption set CustomerCode = @CustomerCode1 where CustomerCode = @CustomerCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CustomerCode1", (object) this.tbxCustomerCode.Text.Trim()),
        new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode2.Text.Trim())
      }, ref strError2) != "Done")
      {
        PawnManagementClass.InsertIntoException("form deleteDuplicateCustomer.error in updating customercode in reemption table", strError2, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in updating" + strError2);
      }
      if (!this.checkCustomerExist(this.tbxCustomerCode2.Text))
        return;
      string strError3 = "";
      if (SQLHelper.RunCommand("Delete from tblCustomers where CId = @CustomerCode", new List<OleDbParameter>()
      {
        new OleDbParameter("CustomerCode", (object) this.tbxCustomerCode2.Text)
      }, ref strError3) == "Done")
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode2.Text.Trim().ToString() + ".png"))
          File.Delete(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode2.Text.Trim().ToString() + ".png");
        int num = (int) MessageBox.Show("Customer Successfully deleted");
        PawnManagementClass.InsertIntoHistory("Customer Delete", "Customer " + this.tbxCustomerCode2.Text + " delete", "", "", FormMain.username, DateTime.Now.ToString());
        this.Close();
      }
    }

    private bool checkCustomerExist(string customerCode)
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from tblCustomers where CId = @Cid", new List<OleDbParameter>()
      {
        new OleDbParameter("Cid", (object) customerCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form DeleteDuplicateCustomer.textBox2_Validating", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        return true;
      return false;
    }

    private void getPendingPledgeDetails(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      string my_querry = "select p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber," + str + ",p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate from tblPledge p where p.CustomerCode =@CustomerCode and p.Redeemed ='N'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form customerPledgeDetails.getCstomerPledgeDetails(stirng customerCode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
      }
      this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void getPendingPledgeDetails2(string CustomerCode)
    {
      string strError = "";
      string str = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["ViewCustomersScreen"] != null)
        str = "p." + articlesSettings.Rows[0]["ViewCustomersScreen"].ToString() + " as Articles";
      string my_querry = "select p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber," + str + ",p.PresentValue,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate from tblPledge p where p.CustomerCode =@CustomerCode and p.Redeemed ='N'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (CustomerCode), (object) CustomerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form customerPledgeDetails.getCstomerPledgeDetails(stirng customerCode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details  .\n" + strError);
      }
      this.dataGridView2.DataSource = (object) dataTable2;
    }

    private void tbxName_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxCustomerCode_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxCustomerCode2.Select();
    }

    private void tbxCustomerCode2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.glassButton1).Focus();
    }

    private void tbxCustomerCode_Enter(object sender, EventArgs e)
    {
      this.tbxName.Text = "";
      this.tbxDoorNumber.Text = "";
      this.tbxAddr1.Text = "";
      this.tbxAddr2.Text = "";
      this.tbxAddr3.Text = "";
      this.tbxCity.Text = "";
      this.tbxPinCode.Text = "";
      this.tbxPhoneNumber.Text = "";
      this.tbxAlternateContact.Text = "";
    }

    private void tbxCustomerCode2_Enter(object sender, EventArgs e)
    {
      this.tbxName2.Text = "";
      this.tbxDoorNumber2.Text = "";
      this.tbxAddr12.Text = "";
      this.tbxAddr22.Text = "";
      this.tbxAddr32.Text = "";
      this.tbxCity2.Text = "";
      this.tbxPincode2.Text = "";
      this.tbxPhoneNumber2.Text = "";
      this.tbxAlternateNumber2.Text = "";
    }

    private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void tbxCustomerCode_TextChanged(object sender, EventArgs e)
    {
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormDeleteDuplicateCustomer_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView2);
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxCustomerCode = new TextBox();
      this.tbxAlternateContact = new TextBox();
      this.label9 = new Label();
      this.label5 = new Label();
      this.tbxPinCode = new TextBox();
      this.label11 = new Label();
      this.tbxCity = new TextBox();
      this.label6 = new Label();
      this.tbxAddr3 = new TextBox();
      this.label7 = new Label();
      this.tbxAddr2 = new TextBox();
      this.tbxAddr1 = new TextBox();
      this.tbxDoorNumber = new TextBox();
      this.label29 = new Label();
      this.tbxName = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.label34 = new Label();
      this.label1 = new Label();
      this.glassButton1 = new GlassButton();
      this.groupBox1 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.groupBox2 = new GroupBox();
      this.dataGridView2 = new DataGridView();
      this.tbxName2 = new TextBox();
      this.tbxCustomerCode2 = new TextBox();
      this.label2 = new Label();
      this.tbxDoorNumber2 = new TextBox();
      this.tbxAddr12 = new TextBox();
      this.tbxAddr22 = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.tbxPhoneNumber2 = new TextBox();
      this.tbxAddr32 = new TextBox();
      this.label8 = new Label();
      this.tbxCity2 = new TextBox();
      this.label10 = new Label();
      this.tbxPincode2 = new TextBox();
      this.label12 = new Label();
      this.label13 = new Label();
      this.label14 = new Label();
      this.tbxAlternateNumber2 = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label15 = new Label();
      this.panel3 = new Panel();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.tbxCustomerCode.Anchor = AnchorStyles.None;
      this.tbxCustomerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(380, 45);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(101, 22);
      this.tbxCustomerCode.TabIndex = 0;
      this.tbxCustomerCode.TextChanged += new EventHandler(this.tbxCustomerCode_TextChanged);
      this.tbxCustomerCode.Enter += new EventHandler(this.tbxCustomerCode_Enter);
      this.tbxCustomerCode.KeyDown += new KeyEventHandler(this.tbxCustomerCode_KeyDown);
      this.tbxCustomerCode.Validating += new CancelEventHandler(this.textBox1_Validating);
      this.tbxAlternateContact.Anchor = AnchorStyles.None;
      this.tbxAlternateContact.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAlternateContact.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateContact.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateContact.Location = new Point(99, 267);
      this.tbxAlternateContact.Name = "tbxAlternateContact";
      this.tbxAlternateContact.Size = new Size(382, 22);
      this.tbxAlternateContact.TabIndex = 89;
      this.tbxAlternateContact.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label9.Anchor = AnchorStyles.None;
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.RoyalBlue;
      this.label9.Location = new Point(24, 269);
      this.label9.Name = "label9";
      this.label9.Size = new Size(73, 23);
      this.label9.TabIndex = 88;
      this.label9.Text = "ALT NO";
      this.label5.Anchor = AnchorStyles.None;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.RoyalBlue;
      this.label5.Location = new Point(7, 106);
      this.label5.Name = "label5";
      this.label5.Size = new Size(89, 23);
      this.label5.TabIndex = 74;
      this.label5.Text = "ADDRESS";
      this.tbxPinCode.Anchor = AnchorStyles.None;
      this.tbxPinCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPinCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPinCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPinCode.Location = new Point(99, 211);
      this.tbxPinCode.Name = "tbxPinCode";
      this.tbxPinCode.Size = new Size(382, 22);
      this.tbxPinCode.TabIndex = 82;
      this.tbxPinCode.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label11.Anchor = AnchorStyles.None;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.RoyalBlue;
      this.label11.Location = new Point(0, 162);
      this.label11.Name = "label11";
      this.label11.Size = new Size(100, 23);
      this.label11.TabIndex = 75;
      this.label11.Text = "LOCATION";
      this.tbxCity.Anchor = AnchorStyles.None;
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(99, 184);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(382, 22);
      this.tbxCity.TabIndex = 81;
      this.tbxCity.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label6.Anchor = AnchorStyles.None;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.RoyalBlue;
      this.label6.Location = new Point(46, 188);
      this.label6.Name = "label6";
      this.label6.Size = new Size(51, 23);
      this.label6.TabIndex = 76;
      this.label6.Text = "CITY";
      this.tbxAddr3.Anchor = AnchorStyles.None;
      this.tbxAddr3.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr3.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr3.Location = new Point(99, 157);
      this.tbxAddr3.Name = "tbxAddr3";
      this.tbxAddr3.Size = new Size(382, 22);
      this.tbxAddr3.TabIndex = 80;
      this.tbxAddr3.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label7.Anchor = AnchorStyles.None;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.RoyalBlue;
      this.label7.Location = new Point(11, 215);
      this.label7.Name = "label7";
      this.label7.Size = new Size(85, 23);
      this.label7.TabIndex = 77;
      this.label7.Text = "PINCODE";
      this.tbxAddr2.Anchor = AnchorStyles.None;
      this.tbxAddr2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr2.Location = new Point(99, 130);
      this.tbxAddr2.Name = "tbxAddr2";
      this.tbxAddr2.Size = new Size(382, 22);
      this.tbxAddr2.TabIndex = 79;
      this.tbxAddr2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxAddr1.Anchor = AnchorStyles.None;
      this.tbxAddr1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr1.Location = new Point(182, 102);
      this.tbxAddr1.Name = "tbxAddr1";
      this.tbxAddr1.Size = new Size(299, 22);
      this.tbxAddr1.TabIndex = 78;
      this.tbxAddr1.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxDoorNumber.Anchor = AnchorStyles.None;
      this.tbxDoorNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDoorNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxDoorNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDoorNumber.Location = new Point(99, 102);
      this.tbxDoorNumber.Name = "tbxDoorNumber";
      this.tbxDoorNumber.Size = new Size(77, 22);
      this.tbxDoorNumber.TabIndex = 83;
      this.tbxDoorNumber.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label29.Anchor = AnchorStyles.None;
      this.label29.AutoSize = true;
      this.label29.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label29.ForeColor = Color.RoyalBlue;
      this.label29.Location = new Point(200, 47);
      this.label29.Name = "label29";
      this.label29.Size = new Size(163, 23);
      this.label29.TabIndex = 135;
      this.label29.Text = "Enter Customer Code";
      this.tbxName.Anchor = AnchorStyles.None;
      this.tbxName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(99, 71);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(382, 22);
      this.tbxName.TabIndex = 140;
      this.tbxName.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxPhoneNumber.Anchor = AnchorStyles.None;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.Location = new Point(99, 237);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(382, 22);
      this.tbxPhoneNumber.TabIndex = 142;
      this.tbxPhoneNumber.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label34.Anchor = AnchorStyles.None;
      this.label34.AutoSize = true;
      this.label34.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label34.ForeColor = Color.RoyalBlue;
      this.label34.Location = new Point(30, 240);
      this.label34.Name = "label34";
      this.label34.Size = new Size(61, 23);
      this.label34.TabIndex = 143;
      this.label34.Text = "PH NO";
      this.label1.Anchor = AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.RoyalBlue;
      this.label1.Location = new Point(38, 73);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 23);
      this.label1.TabIndex = 146;
      this.label1.Text = "NAME";
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      ((Control) this.glassButton1).BackgroundImageLayout = ImageLayout.Stretch;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.RoyalBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.arrow_up;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.MiddleLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(205, 474);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(271, 57);
      ((Control) this.glassButton1).TabIndex = 2;
      ((Control) this.glassButton1).Text = "Delete This Customer";
      ((ButtonBase) this.glassButton1).TextAlign = ContentAlignment.MiddleRight;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.groupBox1.Controls.Add((Control) this.dataGridView1);
      this.groupBox1.Controls.Add((Control) this.tbxName);
      this.groupBox1.Controls.Add((Control) this.tbxCustomerCode);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.tbxDoorNumber);
      this.groupBox1.Controls.Add((Control) this.tbxAddr1);
      this.groupBox1.Controls.Add((Control) this.tbxAddr2);
      this.groupBox1.Controls.Add((Control) this.label34);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.tbxPhoneNumber);
      this.groupBox1.Controls.Add((Control) this.tbxAddr3);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.tbxCity);
      this.groupBox1.Controls.Add((Control) this.label11);
      this.groupBox1.Controls.Add((Control) this.tbxPinCode);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.label29);
      this.groupBox1.Controls.Add((Control) this.tbxAlternateContact);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBox1.ForeColor = Color.RoyalBlue;
      this.groupBox1.Location = new Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(484, 551);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Original Customer";
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(15, 309);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(463, 154);
      this.dataGridView1.TabIndex = 147;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.groupBox2.Controls.Add((Control) this.dataGridView2);
      this.groupBox2.Controls.Add((Control) this.tbxName2);
      this.groupBox2.Controls.Add((Control) this.glassButton1);
      this.groupBox2.Controls.Add((Control) this.tbxCustomerCode2);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.tbxDoorNumber2);
      this.groupBox2.Controls.Add((Control) this.tbxAddr12);
      this.groupBox2.Controls.Add((Control) this.tbxAddr22);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.tbxPhoneNumber2);
      this.groupBox2.Controls.Add((Control) this.tbxAddr32);
      this.groupBox2.Controls.Add((Control) this.label8);
      this.groupBox2.Controls.Add((Control) this.tbxCity2);
      this.groupBox2.Controls.Add((Control) this.label10);
      this.groupBox2.Controls.Add((Control) this.tbxPincode2);
      this.groupBox2.Controls.Add((Control) this.label12);
      this.groupBox2.Controls.Add((Control) this.label13);
      this.groupBox2.Controls.Add((Control) this.label14);
      this.groupBox2.Controls.Add((Control) this.tbxAlternateNumber2);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Font = new Font("Comic Sans MS", 12f);
      this.groupBox2.Location = new Point(493, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(484, 551);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Duplicate Customer";
      this.dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(11, 312);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(463, 151);
      this.dataGridView2.TabIndex = 148;
      this.dataGridView2.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
      this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.tbxName2.Anchor = AnchorStyles.None;
      this.tbxName2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxName2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxName2.Location = new Point(104, 71);
      this.tbxName2.Name = "tbxName2";
      this.tbxName2.Size = new Size(372, 22);
      this.tbxName2.TabIndex = 140;
      this.tbxName2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxCustomerCode2.Anchor = AnchorStyles.None;
      this.tbxCustomerCode2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCustomerCode2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode2.Location = new Point(385, 45);
      this.tbxCustomerCode2.Name = "tbxCustomerCode2";
      this.tbxCustomerCode2.Size = new Size(91, 22);
      this.tbxCustomerCode2.TabIndex = 0;
      this.tbxCustomerCode2.Enter += new EventHandler(this.tbxCustomerCode2_Enter);
      this.tbxCustomerCode2.KeyDown += new KeyEventHandler(this.tbxCustomerCode2_KeyDown);
      this.tbxCustomerCode2.Validating += new CancelEventHandler(this.textBox2_Validating);
      this.label2.Anchor = AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.RoyalBlue;
      this.label2.Location = new Point(31, 77);
      this.label2.Name = "label2";
      this.label2.Size = new Size(60, 23);
      this.label2.TabIndex = 146;
      this.label2.Text = "NAME";
      this.tbxDoorNumber2.Anchor = AnchorStyles.None;
      this.tbxDoorNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDoorNumber2.CharacterCasing = CharacterCasing.Upper;
      this.tbxDoorNumber2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDoorNumber2.Location = new Point(104, 102);
      this.tbxDoorNumber2.Name = "tbxDoorNumber2";
      this.tbxDoorNumber2.Size = new Size(77, 22);
      this.tbxDoorNumber2.TabIndex = 83;
      this.tbxDoorNumber2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxAddr12.Anchor = AnchorStyles.None;
      this.tbxAddr12.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr12.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr12.Location = new Point(187, 102);
      this.tbxAddr12.Name = "tbxAddr12";
      this.tbxAddr12.Size = new Size(289, 22);
      this.tbxAddr12.TabIndex = 78;
      this.tbxAddr12.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxAddr22.Anchor = AnchorStyles.None;
      this.tbxAddr22.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr22.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr22.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr22.Location = new Point(104, 130);
      this.tbxAddr22.Name = "tbxAddr22";
      this.tbxAddr22.Size = new Size(372, 22);
      this.tbxAddr22.TabIndex = 79;
      this.tbxAddr22.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label3.Anchor = AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.RoyalBlue;
      this.label3.Location = new Point(32, 240);
      this.label3.Name = "label3";
      this.label3.Size = new Size(61, 23);
      this.label3.TabIndex = 143;
      this.label3.Text = "PH NO";
      this.label4.Anchor = AnchorStyles.None;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.RoyalBlue;
      this.label4.Location = new Point(11, 215);
      this.label4.Name = "label4";
      this.label4.Size = new Size(85, 23);
      this.label4.TabIndex = 77;
      this.label4.Text = "PINCODE";
      this.tbxPhoneNumber2.Anchor = AnchorStyles.None;
      this.tbxPhoneNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber2.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber2.Location = new Point(104, 237);
      this.tbxPhoneNumber2.Name = "tbxPhoneNumber2";
      this.tbxPhoneNumber2.Size = new Size(372, 22);
      this.tbxPhoneNumber2.TabIndex = 142;
      this.tbxPhoneNumber2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tbxAddr32.Anchor = AnchorStyles.None;
      this.tbxAddr32.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddr32.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddr32.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddr32.Location = new Point(104, 157);
      this.tbxAddr32.Name = "tbxAddr32";
      this.tbxAddr32.Size = new Size(372, 22);
      this.tbxAddr32.TabIndex = 80;
      this.tbxAddr32.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label8.Anchor = AnchorStyles.None;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.RoyalBlue;
      this.label8.Location = new Point(44, 188);
      this.label8.Name = "label8";
      this.label8.Size = new Size(51, 23);
      this.label8.TabIndex = 76;
      this.label8.Text = "CITY";
      this.tbxCity2.Anchor = AnchorStyles.None;
      this.tbxCity2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity2.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxCity2.Location = new Point(104, 184);
      this.tbxCity2.Name = "tbxCity2";
      this.tbxCity2.Size = new Size(372, 22);
      this.tbxCity2.TabIndex = 81;
      this.tbxCity2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label10.Anchor = AnchorStyles.None;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.RoyalBlue;
      this.label10.Location = new Point(3, 162);
      this.label10.Name = "label10";
      this.label10.Size = new Size(100, 23);
      this.label10.TabIndex = 75;
      this.label10.Text = "LOCATION";
      this.tbxPincode2.Anchor = AnchorStyles.None;
      this.tbxPincode2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode2.CharacterCasing = CharacterCasing.Upper;
      this.tbxPincode2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode2.Location = new Point(104, 211);
      this.tbxPincode2.Name = "tbxPincode2";
      this.tbxPincode2.Size = new Size(372, 22);
      this.tbxPincode2.TabIndex = 82;
      this.tbxPincode2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.label12.Anchor = AnchorStyles.None;
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.RoyalBlue;
      this.label12.Location = new Point(5, 106);
      this.label12.Name = "label12";
      this.label12.Size = new Size(89, 23);
      this.label12.TabIndex = 74;
      this.label12.Text = "ADDRESS";
      this.label13.Anchor = AnchorStyles.None;
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.RoyalBlue;
      this.label13.Location = new Point(24, 269);
      this.label13.Name = "label13";
      this.label13.Size = new Size(73, 23);
      this.label13.TabIndex = 88;
      this.label13.Text = "ALT NO";
      this.label14.Anchor = AnchorStyles.None;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Comic Sans MS", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.RoyalBlue;
      this.label14.Location = new Point(211, 47);
      this.label14.Name = "label14";
      this.label14.Size = new Size(163, 23);
      this.label14.TabIndex = 135;
      this.label14.Text = "Enter Customer Code";
      this.tbxAlternateNumber2.Anchor = AnchorStyles.None;
      this.tbxAlternateNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAlternateNumber2.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateNumber2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateNumber2.Location = new Point(104, 267);
      this.tbxAlternateNumber2.Name = "tbxAlternateNumber2";
      this.tbxAlternateNumber2.Size = new Size(372, 22);
      this.tbxAlternateNumber2.TabIndex = 89;
      this.tbxAlternateNumber2.KeyPress += new KeyPressEventHandler(this.tbxName_KeyPress);
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.groupBox2, 1, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(980, 557);
      this.tableLayoutPanel1.TabIndex = 138;
      this.tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel2.Location = new Point(8, 8);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.163987f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.83601f));
      this.tableLayoutPanel2.Size = new Size(988, 622);
      this.tableLayoutPanel2.TabIndex = 139;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label15);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(982, 51);
      this.panel2.TabIndex = 9;
      this.label15.Anchor = AnchorStyles.Top;
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.ForeColor = Color.Black;
      this.label15.Location = new Point(298, 11);
      this.label15.Name = "label15";
      this.label15.Size = new Size(399, 29);
      this.label15.TabIndex = 10;
      this.label15.Text = "REMOVE DUPLICATE CUSTOMER";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 60);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(982, 559);
      this.panel3.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel2);
      this.ForeColor = Color.RoyalBlue;
      this.Name = nameof (FormDeleteDuplicateCustomer);
      this.Text = nameof (FormDeleteDuplicateCustomer);
      this.Load += new EventHandler(this.FormDeleteDuplicateCustomer_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
