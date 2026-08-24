

using CSharpCustomPanelControl;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Testing
{
  public class FormAuctionRedemption : Form
  {
    private List<string> lstPledgeBillNumbers = new List<string>();
    public static string defaultShopCode = "";
    private IContainer components = (IContainer) null;
    private CustomPanel customPanel1;
    private Label label1;
    private CustomPanel customPanel4;
    private TextBox tbxPledgeBillNumber;
    private Label lblBillNumber;
    private ComboBox cbShopCodes;
    private CustomPanel customPanel2;
    private TextBox tbxAmount;
    private Label label2;
    private CustomPanel customPanel3;
    private TextBox tbxAuctionDate;
    private Label label3;
    private CustomPanel customPanel5;
    private TextBox tbxAmountSold;
    private Label label4;
    private CustomPanel customPanel7;
    private TextBox tbxAuctionedBy;
    private Label label5;
    private CustomPanel customPanel8;
    private TextBox tbxKdisNumber;
    private Label label7;
    private CustomPanel customPanel9;
    private TextBox tbxPurchasedBy;
    private Label label8;
    private Panel panel2;
    private Timer timer1;
    private Timer timer2;
    private Label lblMessage;
    private GlassButton btnAddArticles;
    private CustomPanel customPanel6;
    private HeaderPanel headerPanel2;
    private TextBox tbxOldBillNumber;
    private TextBox tbxPureWeight;
    private TextBox tbxValue;
    private TextBox tbxAmount1;
    private TextBox tbxInteresRate;
    private TextBox tbxNetWeight;
    private TextBox tbxReminder;
    private TextBox tbxweight;
    private TextBox tbxDeductions;
    private TextBox textBox13;
    private TextBox textBox12;
    private TextBox textBox11;
    private TextBox textBox10;
    private TextBox textBox9;
    private TextBox textBox8;
    private TextBox textBox7;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxBillDate;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxBillNumber;
    private HeaderPanel headerPanel7;
    private TextBox tbxShopCode;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel3;
    private TableLayoutPanel tableLayoutPanel2;
    private HeaderPanel headerPanel1;
    private TextBox tbxBankDetails;
    private Label label6;
    private Label label9;
    private Label label12;
    private RichTextBox tbxAddress;
    private Label label13;
    private TextBox tbxAverageNumberOfDaysForRelease;
    private TextBox tbxNotes;
    private TextBox tbxNumberOfTimesReleaseExceedTwelveMonths;
    private TextBox tbxCustomerName;
    private PictureBox pictureBox1;
    private TextBox tbxCustomerCode;
    private TextBox tbxPhoneNumber;
    private TextBox tbxCell;
    private DataGridView dgvArticles;
    private TextBox tbxType;
    private Panel panel1;
    private Label label10;

    public FormAuctionRedemption(string DEFAULTHOPCODE)
    {
      FormAuctionRedemption.defaultShopCode = DEFAULTHOPCODE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormTesting1_Load(object sender, EventArgs e)
    {
      try
      {
        PawnManagementClass.formatDataGridViewBluePledge(ref this.dgvArticles);
        this.Assign((Control) this);
        this.getShopCodes();
        if (this.cbShopCodes.Items.Count > 0)
          this.cbShopCodes.SelectedIndex = 0;
        this.cbShopCodes.Text = FormAuctionRedemption.defaultShopCode;
        this.cbShopCodes.Select(this.cbShopCodes.Text.Length, 0);
        this.getBillNumbers();
        this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.tbxPledgeBillNumber.AutoCompleteCustomSource.Clear();
        this.tbxPledgeBillNumber.AutoCompleteCustomSource.AddRange(this.lstPledgeBillNumbers.ToArray());
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void getBillNumbers()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblPledge where redeemed = 'N' and ShopCode = @ShopCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form Redemption .getBillNumbers()", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          this.lstPledgeBillNumbers.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstPledgeBillNumbers.Add(row["BillNumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Redemption.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
        this.tbxPledgeBillNumber.Select();
      else
        this.cbShopCodes.Select();
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

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAcceptOnlyDate(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/' || keyChar == '-')
        return;
      e.Handled = true;
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Text != "" && this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.tbxPledgeBillNumber.Text = PawnManagementClass.getPledgeBillNumberSeries(this.cbShopCodes.Text) + "0";
        this.tbxPledgeBillNumber.SelectionStart = this.tbxPledgeBillNumber.Text.Length;
        this.tbxPledgeBillNumber.Select();
      }
      else
        this.cbShopCodes.Select();
    }

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e)
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
      textBox.BackColor = Color.AliceBlue;
      textBox.ForeColor = Color.Black;
    }

    private void tbxBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              this.getBillDetails();
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              this.getBillDetails();
            }
            else
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

    private void getBillDetails()
    {
      string strError = "";
      string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber=@BillNumber and shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Redemption.tbxPledgeBillNumber_Leave ", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving Pledgedetails" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0].Field<string>("Redeemed") == "N")
        {
          this.tbxBillNumber.Text = this.tbxPledgeBillNumber.Text;
          this.tbxShopCode.Text = this.cbShopCodes.Text;
          this.tbxBillDate.Text = DateTime.Parse(dataTable2.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
          this.tbxCustomerCode.Text = dataTable2.Rows[0]["CustomerCode"].ToString();
          this.tbxCustomerName.Text = dataTable2.Rows[0]["customername"].ToString();
          this.tbxAddress.Text = dataTable2.Rows[0]["DoorNumber"].ToString() + " " + dataTable2.Rows[0]["Addr1"].ToString() + " " + dataTable2.Rows[0]["Addr2"].ToString() + " " + dataTable2.Rows[0]["Addr3"].ToString() + " " + dataTable2.Rows[0]["City"].ToString() + " " + dataTable2.Rows[0]["Pincode"].ToString();
          this.tbxPhoneNumber.Text = dataTable2.Rows[0]["PhoneNumber"].ToString();
          this.tbxAmount1.Text = this.tbxAmount.Text = dataTable2.Rows[0]["Amount"].ToString();
          this.tbxType.Text = dataTable2.Rows[0]["Type"].ToString();
          this.tbxOldBillNumber.Text = dataTable2.Rows[0]["OldBillNumber"].ToString();
          this.tbxReminder.Text = dataTable2.Rows[0]["Reminder"].ToString();
          this.tbxValue.Text = dataTable2.Rows[0]["PresentValue"].ToString();
          this.tbxInteresRate.Text = dataTable2.Rows[0]["InterestRate"].ToString();
          this.tbxweight.Text = dataTable2.Rows[0]["GrossWeight"].ToString();
          this.tbxNetWeight.Text = dataTable2.Rows[0]["NetWeight"].ToString();
          this.tbxPureWeight.Text = dataTable2.Rows[0]["PureWeight"].ToString();
          this.tbxDeductions.Text = dataTable2.Rows[0]["Deduction"].ToString();
          this.getPicture(this.tbxCustomerCode.Text.Trim().ToString());
          this.getArticles();
        }
        else if (dataTable2.Rows[0].Field<string>("Redeemed") == "Y")
        {
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.lblMessage.Text = "Bill Number Already released";
          this.tbxPledgeBillNumber.Select();
        }
        else if (dataTable2.Rows[0].Field<string>("Redeemed") == "A")
        {
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.lblMessage.Text = "Bill Number already auctioned";
          this.tbxPledgeBillNumber.Select();
        }
        else
        {
          this.lblMessage.Text = "ENTER VALID BILL NUMBER";
          this.timer1.Enabled = true;
          this.timer1.Start();
          this.tbxPledgeBillNumber.Select();
        }
      }
      else
      {
        this.timer1.Start();
        this.lblMessage.Text = "Enter valid Bill Number";
        this.tbxPledgeBillNumber.Select();
      }
    }

    private void getPicture(string customerCode)
    {
      if (File.Exists(FormMain.startUpPath + "Photos\\" + customerCode + ".png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + customerCode + ".png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
      else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
      {
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
      }
    }

    private void reset()
    {
      this.tbxPledgeBillNumber.Text = "";
      this.tbxAmount.Text = "";
      this.tbxAmountSold.Text = "";
      this.tbxBillNumber.Text = "";
      this.tbxShopCode.Text = "";
      this.tbxBillDate.Text = "";
      this.tbxCustomerCode.Text = "";
      this.tbxCustomerName.Text = "";
      this.tbxAddress.Text = "";
      this.tbxPhoneNumber.Text = "";
      this.tbxAmount1.Text = this.tbxAmount.Text = "";
      this.tbxType.Text = "";
      this.tbxOldBillNumber.Text = "";
      this.tbxReminder.Text = "";
      this.tbxValue.Text = "";
      this.tbxInteresRate.Text = "";
      this.tbxweight.Text = "";
      this.tbxNetWeight.Text = "";
      this.tbxPureWeight.Text = "";
      this.tbxDeductions.Text = "";
      this.dgvArticles.DataSource = (object) null;
    }

    private void getArticles()
    {
      if (FormMain.withIndividualWeight)
      {
        string strError = "";
        string my_querry = "Select Articles,ArticlesDescription,Hr as [Hidden Remarks],Purity,GrossWeight,Deduction,NetWeight,PureWeight,Num from tblPledgeArticles where BillNumber = @BillNumber  and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Redemption.getArticles", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
        }
        else
        {
          this.dgvArticles.DataSource = (object) dataTable2;
          this.dgvArticles.ClearSelection();
        }
      }
      else
      {
        string strError = "";
        string my_querry = "Select Articles,ArticlesDescription,Num from tblPledgeArticles where BillNumber = @BillNumber  and shopCode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text.Trim().ToString()));
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Redemption.getArticles", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving articles" + strError);
        }
        else
        {
          this.dgvArticles.DataSource = (object) dataTable4;
          this.dgvArticles.ClearSelection();
        }
      }
    }

    private void label10_Click(object sender, EventArgs e) => this.Close();

    private void tbxAuctionDate_TextChanged(object sender, EventArgs e)
    {
    }

    private void saveAuctionInPledgeTable()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblPledge set Redeemed = @Redeemed,AuctionDate = @AuctionDate,AuctionAmount = @AuctionAmount,KdisNumber = @KdisNumber,PurchasedBy = @PurchasedBy,AuctionedBy = @AuctionedBy where BillNumber =@BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("Redeemed", (object) "A"),
        new OleDbParameter("AuctionDate", (object) this.tbxAuctionDate.Text),
        new OleDbParameter("AuctionAmount", (object) this.tbxAmountSold.Text),
        new OleDbParameter("KdisNumber", (object) this.tbxKdisNumber.Text),
        new OleDbParameter("PurchasedBy", (object) this.tbxPurchasedBy.Text),
        new OleDbParameter("AuctionedBy", (object) this.tbxAuctionedBy.Text),
        new OleDbParameter("BillNumber", (object) this.tbxPledgeBillNumber.Text),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text.Trim())
      }, ref strError) == "Done")
      {
        this.reset();
      }
      else
      {
        PawnManagementClass.InsertIntoException("form Redemption.saveAuctionInpledgeTable", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in redemption in pledge" + strError);
      }
    }

    private void tbxAuctionDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxAuctionDate.Text))
        return;
      this.tbxAuctionDate.Select();
    }

    private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxAmount_Enter(object sender, EventArgs e)
    {
    }

    private void btnAddArticles_Click(object sender, EventArgs e)
    {
      this.saveAuctionInPledgeTable();
      this.cbShopCodes.Select();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.lblMessage.Visible = true;
      this.timer2.Enabled = true;
      this.timer2.Start();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.lblMessage.Visible = false;
      this.timer2.Stop();
      this.timer1.Enabled = false;
    }

    private void tbxAmountSold_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.tbxAmountSold.Text.Trim() == ""))
        return;
      this.tbxAmountSold.Select();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormAuctionRedemption));
      this.customPanel1 = new CustomPanel();
      this.cbShopCodes = new ComboBox();
      this.label1 = new Label();
      this.customPanel4 = new CustomPanel();
      this.tbxPledgeBillNumber = new TextBox();
      this.lblBillNumber = new Label();
      this.customPanel2 = new CustomPanel();
      this.tbxAmount = new TextBox();
      this.label2 = new Label();
      this.lblMessage = new Label();
      this.customPanel3 = new CustomPanel();
      this.tbxAuctionDate = new TextBox();
      this.label3 = new Label();
      this.customPanel5 = new CustomPanel();
      this.tbxAmountSold = new TextBox();
      this.label4 = new Label();
      this.customPanel7 = new CustomPanel();
      this.tbxAuctionedBy = new TextBox();
      this.label5 = new Label();
      this.customPanel8 = new CustomPanel();
      this.tbxKdisNumber = new TextBox();
      this.label7 = new Label();
      this.customPanel9 = new CustomPanel();
      this.tbxPurchasedBy = new TextBox();
      this.label8 = new Label();
      this.panel2 = new Panel();
      this.headerPanel2 = new HeaderPanel();
      this.tbxType = new TextBox();
      this.tbxOldBillNumber = new TextBox();
      this.tbxPureWeight = new TextBox();
      this.tbxValue = new TextBox();
      this.tbxAmount1 = new TextBox();
      this.tbxInteresRate = new TextBox();
      this.tbxNetWeight = new TextBox();
      this.tbxReminder = new TextBox();
      this.tbxweight = new TextBox();
      this.tbxDeductions = new TextBox();
      this.textBox13 = new TextBox();
      this.textBox12 = new TextBox();
      this.textBox11 = new TextBox();
      this.textBox10 = new TextBox();
      this.textBox9 = new TextBox();
      this.textBox8 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxBillDate = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxBillNumber = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.tbxShopCode = new TextBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.dgvArticles = new DataGridView();
      this.headerPanel1 = new HeaderPanel();
      this.tbxBankDetails = new TextBox();
      this.label6 = new Label();
      this.label9 = new Label();
      this.label12 = new Label();
      this.tbxAddress = new RichTextBox();
      this.label13 = new Label();
      this.tbxAverageNumberOfDaysForRelease = new TextBox();
      this.tbxNotes = new TextBox();
      this.tbxNumberOfTimesReleaseExceedTwelveMonths = new TextBox();
      this.tbxCustomerName = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.tbxCustomerCode = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.tbxCell = new TextBox();
      this.customPanel6 = new CustomPanel();
      this.btnAddArticles = new GlassButton();
      this.timer1 = new Timer(this.components);
      this.timer2 = new Timer(this.components);
      this.panel1 = new Panel();
      this.label10 = new Label();
      ((Control) this.customPanel1).SuspendLayout();
      ((Control) this.customPanel4).SuspendLayout();
      ((Control) this.customPanel2).SuspendLayout();
      ((Control) this.customPanel3).SuspendLayout();
      ((Control) this.customPanel5).SuspendLayout();
      ((Control) this.customPanel7).SuspendLayout();
      ((Control) this.customPanel8).SuspendLayout();
      ((Control) this.customPanel9).SuspendLayout();
      this.panel2.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((ISupportInitialize) this.dgvArticles).BeginInit();
      ((Control) this.headerPanel1).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((Control) this.customPanel6).SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.customPanel1.BackColor = Color.AliceBlue;
      this.customPanel1.BackColor2 = Color.Azure;
      this.customPanel1.BorderColor = Color.MidnightBlue;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.customPanel1).Controls.Add((Control) this.label1);
      this.customPanel1.Curvature = 1;
      this.customPanel1.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(3, 4);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(287, 54);
      ((Control) this.customPanel1).TabIndex = 0;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.FlatStyle = FlatStyle.Flat;
      this.cbShopCodes.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(11, 19);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(271, 32);
      this.cbShopCodes.TabIndex = 0;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Select License";
      this.customPanel4.BackColor = Color.AliceBlue;
      this.customPanel4.BackColor2 = Color.Azure;
      this.customPanel4.BorderColor = Color.MidnightBlue;
      this.customPanel4.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel4).Controls.Add((Control) this.tbxPledgeBillNumber);
      ((Control) this.customPanel4).Controls.Add((Control) this.lblBillNumber);
      this.customPanel4.Curvature = 1;
      this.customPanel4.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel4).Location = new Point(3, 55);
      ((Control) this.customPanel4).Name = "customPanel4";
      ((Control) this.customPanel4).Size = new Size(287, 54);
      ((Control) this.customPanel4).TabIndex = 1;
      this.tbxPledgeBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxPledgeBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxPledgeBillNumber.BackColor = Color.AliceBlue;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.None;
      this.tbxPledgeBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.Location = new Point(4, 23);
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.Size = new Size(280, 28);
      this.tbxPledgeBillNumber.TabIndex = 0;
      this.tbxPledgeBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxPledgeBillNumber.Validating += new CancelEventHandler(this.tbxBillNumber_Validating);
      this.lblBillNumber.AutoSize = true;
      this.lblBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblBillNumber.ForeColor = Color.DarkBlue;
      this.lblBillNumber.Location = new Point(2, 5);
      this.lblBillNumber.Name = "lblBillNumber";
      this.lblBillNumber.Size = new Size(74, 16);
      this.lblBillNumber.TabIndex = 1;
      this.lblBillNumber.Text = "BillNumber";
      this.customPanel2.BackColor = Color.AliceBlue;
      this.customPanel2.BackColor2 = Color.Azure;
      this.customPanel2.BorderColor = Color.MidnightBlue;
      this.customPanel2.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel2).Controls.Add((Control) this.tbxAmount);
      ((Control) this.customPanel2).Controls.Add((Control) this.label2);
      this.customPanel2.Curvature = 1;
      this.customPanel2.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel2).Location = new Point(3, 108);
      ((Control) this.customPanel2).Name = "customPanel2";
      ((Control) this.customPanel2).Size = new Size(287, 54);
      ((Control) this.customPanel2).TabIndex = 2;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(2, 24);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(282, 28);
      this.tbxAmount.TabIndex = 0;
      this.tbxAmount.Enter += new EventHandler(this.tbxAmount_Enter);
      this.tbxAmount.KeyPress += new KeyPressEventHandler(this.tbxAmount_KeyPress);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(4, 4);
      this.label2.Name = "label2";
      this.label2.Size = new Size(53, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "Amount";
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.DarkRed;
      this.lblMessage.Location = new Point(3, 2);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(0, 25);
      this.lblMessage.TabIndex = 2;
      this.customPanel3.BackColor = Color.AliceBlue;
      this.customPanel3.BackColor2 = Color.Azure;
      this.customPanel3.BorderColor = Color.MidnightBlue;
      this.customPanel3.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel3).Controls.Add((Control) this.tbxAuctionDate);
      ((Control) this.customPanel3).Controls.Add((Control) this.label3);
      this.customPanel3.Curvature = 1;
      this.customPanel3.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel3).Location = new Point(3, 214);
      ((Control) this.customPanel3).Name = "customPanel3";
      ((Control) this.customPanel3).Size = new Size(287, 54);
      ((Control) this.customPanel3).TabIndex = 4;
      this.tbxAuctionDate.BackColor = Color.AliceBlue;
      this.tbxAuctionDate.BorderStyle = BorderStyle.None;
      this.tbxAuctionDate.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAuctionDate.Location = new Point(7, 24);
      this.tbxAuctionDate.Name = "tbxAuctionDate";
      this.tbxAuctionDate.Size = new Size(277, 28);
      this.tbxAuctionDate.TabIndex = 0;
      this.tbxAuctionDate.TextChanged += new EventHandler(this.tbxAuctionDate_TextChanged);
      this.tbxAuctionDate.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyDate);
      this.tbxAuctionDate.Validating += new CancelEventHandler(this.tbxAuctionDate_Validating);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(2, 3);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "Auction Date";
      this.customPanel5.BackColor = Color.AliceBlue;
      this.customPanel5.BackColor2 = Color.Azure;
      this.customPanel5.BorderColor = Color.MidnightBlue;
      this.customPanel5.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel5).Controls.Add((Control) this.tbxAmountSold);
      ((Control) this.customPanel5).Controls.Add((Control) this.label4);
      this.customPanel5.Curvature = 1;
      this.customPanel5.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel5).Location = new Point(3, 161);
      ((Control) this.customPanel5).Name = "customPanel5";
      ((Control) this.customPanel5).Size = new Size(287, 54);
      ((Control) this.customPanel5).TabIndex = 3;
      this.tbxAmountSold.BackColor = Color.AliceBlue;
      this.tbxAmountSold.BorderStyle = BorderStyle.None;
      this.tbxAmountSold.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountSold.Location = new Point(4, 23);
      this.tbxAmountSold.Name = "tbxAmountSold";
      this.tbxAmountSold.Size = new Size(281, 28);
      this.tbxAmountSold.TabIndex = 0;
      this.tbxAmountSold.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.tbxAmountSold.Validating += new CancelEventHandler(this.tbxAmountSold_Validating);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(3, 3);
      this.label4.Name = "label4";
      this.label4.Size = new Size(84, 16);
      this.label4.TabIndex = 1;
      this.label4.Text = "Amount Sold";
      this.customPanel7.BackColor = Color.AliceBlue;
      this.customPanel7.BackColor2 = Color.Azure;
      this.customPanel7.BorderColor = Color.MidnightBlue;
      this.customPanel7.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel7).Controls.Add((Control) this.tbxAuctionedBy);
      ((Control) this.customPanel7).Controls.Add((Control) this.label5);
      this.customPanel7.Curvature = 1;
      this.customPanel7.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel7).Location = new Point(3, 373);
      ((Control) this.customPanel7).Name = "customPanel7";
      ((Control) this.customPanel7).Size = new Size(287, 54);
      ((Control) this.customPanel7).TabIndex = 7;
      this.tbxAuctionedBy.BackColor = Color.AliceBlue;
      this.tbxAuctionedBy.BorderStyle = BorderStyle.None;
      this.tbxAuctionedBy.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAuctionedBy.Location = new Point(5, 22);
      this.tbxAuctionedBy.Name = "tbxAuctionedBy";
      this.tbxAuctionedBy.Size = new Size(277, 28);
      this.tbxAuctionedBy.TabIndex = 0;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(5, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(108, 16);
      this.label5.TabIndex = 1;
      this.label5.Text = "AUCTIONED BY";
      this.customPanel8.BackColor = Color.AliceBlue;
      this.customPanel8.BackColor2 = Color.Azure;
      this.customPanel8.BorderColor = Color.MidnightBlue;
      this.customPanel8.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel8).Controls.Add((Control) this.tbxKdisNumber);
      ((Control) this.customPanel8).Controls.Add((Control) this.label7);
      this.customPanel8.Curvature = 1;
      this.customPanel8.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel8).Location = new Point(3, 267);
      ((Control) this.customPanel8).Name = "customPanel8";
      ((Control) this.customPanel8).Size = new Size(287, 54);
      ((Control) this.customPanel8).TabIndex = 5;
      this.tbxKdisNumber.BackColor = Color.AliceBlue;
      this.tbxKdisNumber.BorderStyle = BorderStyle.None;
      this.tbxKdisNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxKdisNumber.Location = new Point(4, 22);
      this.tbxKdisNumber.Name = "tbxKdisNumber";
      this.tbxKdisNumber.Size = new Size(279, 28);
      this.tbxKdisNumber.TabIndex = 0;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkBlue;
      this.label7.Location = new Point(4, 5);
      this.label7.Name = "label7";
      this.label7.Size = new Size(73, 16);
      this.label7.TabIndex = 1;
      this.label7.Text = "K.D.I.S NO:";
      this.customPanel9.BackColor = Color.AliceBlue;
      this.customPanel9.BackColor2 = Color.Azure;
      this.customPanel9.BorderColor = Color.MidnightBlue;
      this.customPanel9.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel9).Controls.Add((Control) this.tbxPurchasedBy);
      ((Control) this.customPanel9).Controls.Add((Control) this.label8);
      this.customPanel9.Curvature = 1;
      this.customPanel9.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel9).Location = new Point(3, 320);
      ((Control) this.customPanel9).Name = "customPanel9";
      ((Control) this.customPanel9).Size = new Size(287, 54);
      ((Control) this.customPanel9).TabIndex = 6;
      this.tbxPurchasedBy.BackColor = Color.AliceBlue;
      this.tbxPurchasedBy.BorderStyle = BorderStyle.None;
      this.tbxPurchasedBy.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPurchasedBy.Location = new Point(6, 22);
      this.tbxPurchasedBy.Name = "tbxPurchasedBy";
      this.tbxPurchasedBy.Size = new Size(276, 28);
      this.tbxPurchasedBy.TabIndex = 0;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkBlue;
      this.label8.Location = new Point(-1, 4);
      this.label8.Name = "label8";
      this.label8.Size = new Size(114, 16);
      this.label8.TabIndex = 1;
      this.label8.Text = "PURCHASED BY";
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BackColor = Color.Ivory;
      this.panel2.Controls.Add((Control) this.headerPanel2);
      this.panel2.Controls.Add((Control) this.headerPanel6);
      this.panel2.Controls.Add((Control) this.headerPanel5);
      this.panel2.Controls.Add((Control) this.headerPanel7);
      this.panel2.Controls.Add((Control) this.headerPanel3);
      this.panel2.Controls.Add((Control) this.headerPanel1);
      this.panel2.Controls.Add((Control) this.customPanel6);
      this.panel2.Controls.Add((Control) this.customPanel7);
      this.panel2.Controls.Add((Control) this.customPanel8);
      this.panel2.Controls.Add((Control) this.customPanel1);
      this.panel2.Controls.Add((Control) this.customPanel9);
      this.panel2.Controls.Add((Control) this.customPanel4);
      this.panel2.Controls.Add((Control) this.customPanel3);
      this.panel2.Controls.Add((Control) this.customPanel5);
      this.panel2.Controls.Add((Control) this.customPanel2);
      this.panel2.Location = new Point(0, 47);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(998, 526);
      this.panel2.TabIndex = 12;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "LOAN DETAILS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxOldBillNumber);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxPureWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxValue);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxAmount1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxInteresRate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxNetWeight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxReminder);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxweight);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxDeductions);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox13);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox12);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox11);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox10);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox9);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox8);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox7);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.textBox4);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(739, 3);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size((int) byte.MaxValue, 280);
      ((Control) this.headerPanel2).TabIndex = 97;
      this.headerPanel2.TextAntialias = true;
      this.tbxType.Anchor = AnchorStyles.Top;
      this.tbxType.BackColor = Color.White;
      this.tbxType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxType.CharacterCasing = CharacterCasing.Upper;
      this.tbxType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxType.ForeColor = Color.DarkBlue;
      this.tbxType.Location = new Point(100, 8);
      this.tbxType.MaxLength = 6;
      this.tbxType.Name = "tbxType";
      this.tbxType.ReadOnly = true;
      this.tbxType.Size = new Size(144, 22);
      this.tbxType.TabIndex = 71;
      this.tbxType.TextAlign = HorizontalAlignment.Right;
      this.tbxOldBillNumber.Anchor = AnchorStyles.Top;
      this.tbxOldBillNumber.BackColor = Color.White;
      this.tbxOldBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOldBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxOldBillNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxOldBillNumber.ForeColor = Color.DarkBlue;
      this.tbxOldBillNumber.Location = new Point(100, 32);
      this.tbxOldBillNumber.MaxLength = 6;
      this.tbxOldBillNumber.Name = "tbxOldBillNumber";
      this.tbxOldBillNumber.ReadOnly = true;
      this.tbxOldBillNumber.Size = new Size(144, 22);
      this.tbxOldBillNumber.TabIndex = 1;
      this.tbxOldBillNumber.TextAlign = HorizontalAlignment.Right;
      this.tbxPureWeight.Anchor = AnchorStyles.Top;
      this.tbxPureWeight.BackColor = Color.White;
      this.tbxPureWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPureWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxPureWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPureWeight.ForeColor = Color.DarkBlue;
      this.tbxPureWeight.Location = new Point(100, 152);
      this.tbxPureWeight.MaxLength = 7;
      this.tbxPureWeight.Name = "tbxPureWeight";
      this.tbxPureWeight.ReadOnly = true;
      this.tbxPureWeight.Size = new Size(144, 22);
      this.tbxPureWeight.TabIndex = 69;
      this.tbxPureWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxValue.Anchor = AnchorStyles.Top;
      this.tbxValue.BackColor = Color.White;
      this.tbxValue.BorderStyle = BorderStyle.FixedSingle;
      this.tbxValue.CharacterCasing = CharacterCasing.Upper;
      this.tbxValue.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxValue.ForeColor = Color.DarkBlue;
      this.tbxValue.Location = new Point(100, 176);
      this.tbxValue.MaxLength = 10;
      this.tbxValue.Name = "tbxValue";
      this.tbxValue.ReadOnly = true;
      this.tbxValue.Size = new Size(144, 22);
      this.tbxValue.TabIndex = 6;
      this.tbxValue.TextAlign = HorizontalAlignment.Right;
      this.tbxAmount1.Anchor = AnchorStyles.Top;
      this.tbxAmount1.BackColor = Color.White;
      this.tbxAmount1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAmount1.CharacterCasing = CharacterCasing.Upper;
      this.tbxAmount1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount1.ForeColor = Color.DarkBlue;
      this.tbxAmount1.Location = new Point(100, 200);
      this.tbxAmount1.MaxLength = 10;
      this.tbxAmount1.Name = "tbxAmount1";
      this.tbxAmount1.ReadOnly = true;
      this.tbxAmount1.Size = new Size(144, 22);
      this.tbxAmount1.TabIndex = 7;
      this.tbxAmount1.TextAlign = HorizontalAlignment.Right;
      this.tbxInteresRate.Anchor = AnchorStyles.Top;
      this.tbxInteresRate.BackColor = Color.White;
      this.tbxInteresRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInteresRate.CharacterCasing = CharacterCasing.Upper;
      this.tbxInteresRate.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInteresRate.ForeColor = Color.DarkBlue;
      this.tbxInteresRate.Location = new Point(100, 224);
      this.tbxInteresRate.MaxLength = 4;
      this.tbxInteresRate.Name = "tbxInteresRate";
      this.tbxInteresRate.ReadOnly = true;
      this.tbxInteresRate.Size = new Size(144, 22);
      this.tbxInteresRate.TabIndex = 8;
      this.tbxInteresRate.TextAlign = HorizontalAlignment.Right;
      this.tbxNetWeight.Anchor = AnchorStyles.Top;
      this.tbxNetWeight.BackColor = Color.White;
      this.tbxNetWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNetWeight.CharacterCasing = CharacterCasing.Upper;
      this.tbxNetWeight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeight.ForeColor = Color.DarkBlue;
      this.tbxNetWeight.Location = new Point(100, 128);
      this.tbxNetWeight.MaxLength = 7;
      this.tbxNetWeight.Name = "tbxNetWeight";
      this.tbxNetWeight.ReadOnly = true;
      this.tbxNetWeight.Size = new Size(144, 22);
      this.tbxNetWeight.TabIndex = 5;
      this.tbxNetWeight.TextAlign = HorizontalAlignment.Right;
      this.tbxReminder.Anchor = AnchorStyles.Top;
      this.tbxReminder.BackColor = Color.White;
      this.tbxReminder.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReminder.CharacterCasing = CharacterCasing.Upper;
      this.tbxReminder.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxReminder.ForeColor = Color.DarkBlue;
      this.tbxReminder.Location = new Point(100, 56);
      this.tbxReminder.MaxLength = 50;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.ReadOnly = true;
      this.tbxReminder.Size = new Size(144, 22);
      this.tbxReminder.TabIndex = 2;
      this.tbxweight.Anchor = AnchorStyles.Top;
      this.tbxweight.BackColor = Color.White;
      this.tbxweight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxweight.CharacterCasing = CharacterCasing.Upper;
      this.tbxweight.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxweight.ForeColor = Color.DarkBlue;
      this.tbxweight.Location = new Point(100, 80);
      this.tbxweight.MaxLength = 7;
      this.tbxweight.Name = "tbxweight";
      this.tbxweight.ReadOnly = true;
      this.tbxweight.Size = new Size(144, 22);
      this.tbxweight.TabIndex = 3;
      this.tbxweight.TextAlign = HorizontalAlignment.Right;
      this.tbxDeductions.Anchor = AnchorStyles.Top;
      this.tbxDeductions.BackColor = Color.White;
      this.tbxDeductions.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeductions.CharacterCasing = CharacterCasing.Upper;
      this.tbxDeductions.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeductions.ForeColor = Color.DarkBlue;
      this.tbxDeductions.Location = new Point(100, 104);
      this.tbxDeductions.MaxLength = 5;
      this.tbxDeductions.Name = "tbxDeductions";
      this.tbxDeductions.ReadOnly = true;
      this.tbxDeductions.Size = new Size(144, 22);
      this.tbxDeductions.TabIndex = 4;
      this.tbxDeductions.Text = "0";
      this.tbxDeductions.TextAlign = HorizontalAlignment.Right;
      this.textBox13.Anchor = AnchorStyles.Top;
      this.textBox13.BackColor = Color.AliceBlue;
      this.textBox13.BorderStyle = BorderStyle.None;
      this.textBox13.CharacterCasing = CharacterCasing.Upper;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox13.ForeColor = Color.DarkBlue;
      this.textBox13.Location = new Point(-27, 154);
      this.textBox13.MaxLength = 4;
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new Size(114, 15);
      this.textBox13.TabIndex = 70;
      this.textBox13.Text = "PURE WT";
      this.textBox13.TextAlign = HorizontalAlignment.Right;
      this.textBox12.Anchor = AnchorStyles.Top;
      this.textBox12.BackColor = Color.AliceBlue;
      this.textBox12.BorderStyle = BorderStyle.None;
      this.textBox12.CharacterCasing = CharacterCasing.Upper;
      this.textBox12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox12.ForeColor = Color.DarkBlue;
      this.textBox12.Location = new Point(-18, 10);
      this.textBox12.MaxLength = 4;
      this.textBox12.Name = "textBox12";
      this.textBox12.Size = new Size(114, 15);
      this.textBox12.TabIndex = 67;
      this.textBox12.Text = "TYPE   ";
      this.textBox12.TextAlign = HorizontalAlignment.Right;
      this.textBox11.Anchor = AnchorStyles.Top;
      this.textBox11.BackColor = Color.AliceBlue;
      this.textBox11.BorderStyle = BorderStyle.None;
      this.textBox11.CharacterCasing = CharacterCasing.Upper;
      this.textBox11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox11.ForeColor = Color.DarkBlue;
      this.textBox11.Location = new Point(-18, 34);
      this.textBox11.MaxLength = 4;
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new Size(114, 15);
      this.textBox11.TabIndex = 66;
      this.textBox11.Text = "OLD NO   ";
      this.textBox11.TextAlign = HorizontalAlignment.Right;
      this.textBox10.Anchor = AnchorStyles.Top;
      this.textBox10.BackColor = Color.AliceBlue;
      this.textBox10.BorderStyle = BorderStyle.None;
      this.textBox10.CharacterCasing = CharacterCasing.Upper;
      this.textBox10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox10.ForeColor = Color.DarkBlue;
      this.textBox10.Location = new Point(-18, 58);
      this.textBox10.MaxLength = 4;
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new Size(114, 15);
      this.textBox10.TabIndex = 65;
      this.textBox10.Text = "REMINDER   ";
      this.textBox10.TextAlign = HorizontalAlignment.Right;
      this.textBox9.Anchor = AnchorStyles.Top;
      this.textBox9.BackColor = Color.AliceBlue;
      this.textBox9.BorderStyle = BorderStyle.None;
      this.textBox9.CharacterCasing = CharacterCasing.Upper;
      this.textBox9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox9.ForeColor = Color.DarkBlue;
      this.textBox9.Location = new Point(-18, 82);
      this.textBox9.MaxLength = 4;
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new Size(114, 15);
      this.textBox9.TabIndex = 64;
      this.textBox9.Text = "GROSS WT   ";
      this.textBox9.TextAlign = HorizontalAlignment.Right;
      this.textBox8.Anchor = AnchorStyles.Top;
      this.textBox8.BackColor = Color.AliceBlue;
      this.textBox8.BorderStyle = BorderStyle.None;
      this.textBox8.CharacterCasing = CharacterCasing.Upper;
      this.textBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox8.ForeColor = Color.DarkBlue;
      this.textBox8.Location = new Point(-18, 106);
      this.textBox8.MaxLength = 4;
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(114, 15);
      this.textBox8.TabIndex = 63;
      this.textBox8.Text = "DEDUCTION   ";
      this.textBox8.TextAlign = HorizontalAlignment.Right;
      this.textBox7.Anchor = AnchorStyles.Top;
      this.textBox7.BackColor = Color.AliceBlue;
      this.textBox7.BorderStyle = BorderStyle.None;
      this.textBox7.CharacterCasing = CharacterCasing.Upper;
      this.textBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox7.ForeColor = Color.DarkBlue;
      this.textBox7.Location = new Point(-18, 130);
      this.textBox7.MaxLength = 4;
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(114, 15);
      this.textBox7.TabIndex = 62;
      this.textBox7.Text = "NET WT   ";
      this.textBox7.TextAlign = HorizontalAlignment.Right;
      this.textBox2.Anchor = AnchorStyles.Top;
      this.textBox2.BackColor = Color.AliceBlue;
      this.textBox2.BorderStyle = BorderStyle.None;
      this.textBox2.CharacterCasing = CharacterCasing.Upper;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox2.ForeColor = Color.DarkBlue;
      this.textBox2.Location = new Point(-18, 178);
      this.textBox2.MaxLength = 4;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(114, 15);
      this.textBox2.TabIndex = 56;
      this.textBox2.Text = "VALUE   ";
      this.textBox2.TextAlign = HorizontalAlignment.Right;
      this.textBox3.Anchor = AnchorStyles.Top;
      this.textBox3.BackColor = Color.AliceBlue;
      this.textBox3.BorderStyle = BorderStyle.None;
      this.textBox3.CharacterCasing = CharacterCasing.Upper;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox3.ForeColor = Color.DarkBlue;
      this.textBox3.Location = new Point(-18, 202);
      this.textBox3.MaxLength = 4;
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(114, 15);
      this.textBox3.TabIndex = 57;
      this.textBox3.Text = "AMOUNT   ";
      this.textBox3.TextAlign = HorizontalAlignment.Right;
      this.textBox4.Anchor = AnchorStyles.Top;
      this.textBox4.BackColor = Color.AliceBlue;
      this.textBox4.BorderStyle = BorderStyle.None;
      this.textBox4.CharacterCasing = CharacterCasing.Upper;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox4.ForeColor = Color.DarkBlue;
      this.textBox4.Location = new Point(-19, 226);
      this.textBox4.MaxLength = 4;
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(114, 15);
      this.textBox4.TabIndex = 58;
      this.textBox4.Text = "ROI    ";
      this.textBox4.TextAlign = HorizontalAlignment.Right;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel6.CaptionEndColor = Color.AliceBlue;
      this.headerPanel6.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "BILL DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxBillDate);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(611, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(121, 47);
      ((Control) this.headerPanel6).TabIndex = 100;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      ((ButtonBase) this.glassButton3).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(-192, 521);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(-58, 520);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxBillDate.BackColor = Color.AliceBlue;
      this.tbxBillDate.BorderStyle = BorderStyle.None;
      this.tbxBillDate.Dock = DockStyle.Fill;
      this.tbxBillDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillDate.Location = new Point(0, 0);
      this.tbxBillDate.MaxLength = 10;
      this.tbxBillDate.Name = "tbxBillDate";
      this.tbxBillDate.Size = new Size(119, 22);
      this.tbxBillDate.TabIndex = 1;
      this.tbxBillDate.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel5.CaptionEndColor = Color.AliceBlue;
      this.headerPanel5.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "BILL NUMBER";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(297, 4);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(98, 47);
      ((Control) this.headerPanel5).TabIndex = 99;
      this.headerPanel5.TextAntialias = true;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(-213, 521);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(-79, 520);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber.BackColor = Color.AliceBlue;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Dock = DockStyle.Fill;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 0);
      this.tbxBillNumber.MaxLength = 6;
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(96, 22);
      this.tbxBillNumber.TabIndex = 79;
      this.tbxBillNumber.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(399, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(207, 47);
      ((Control) this.headerPanel7).TabIndex = 98;
      this.headerPanel7.TextAntialias = true;
      this.tbxShopCode.BackColor = Color.AliceBlue;
      this.tbxShopCode.BorderStyle = BorderStyle.None;
      this.tbxShopCode.Dock = DockStyle.Fill;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(0, 0);
      this.tbxShopCode.MaxLength = 10;
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(205, 22);
      this.tbxShopCode.TabIndex = 2;
      this.tbxShopCode.TextAlign = HorizontalAlignment.Center;
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
      ((Control) this.glassButton8).Location = new Point(-102, 521);
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
      ((Control) this.glassButton9).Location = new Point(32, 520);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.AliceBlue;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel3.CaptionEndColor = Color.Azure;
      this.headerPanel3.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "DETAILED DESCRIPTION OF THE ARTICLES";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.tableLayoutPanel2);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(297, 285);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(696, 238);
      ((Control) this.headerPanel3).TabIndex = 96;
      this.headerPanel3.TextAntialias = true;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel2.Controls.Add((Control) this.dgvArticles, 0, 0);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.Size = new Size(694, 214);
      this.tableLayoutPanel2.TabIndex = 66;
      this.dgvArticles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvArticles.Dock = DockStyle.Fill;
      this.dgvArticles.Location = new Point(3, 3);
      this.dgvArticles.Name = "dgvArticles";
      this.dgvArticles.Size = new Size(689, 208);
      this.dgvArticles.TabIndex = 0;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel1.CaptionEndColor = Color.Azure;
      this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "CUSTOMER DETAILS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxBankDetails);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label6);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label9);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label12);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAddress);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label13);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxAverageNumberOfDaysForRelease);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNotes);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNumberOfTimesReleaseExceedTwelveMonths);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerName);
      ((Control) this.headerPanel1).Controls.Add((Control) this.pictureBox1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxPhoneNumber);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCell);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Azure;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(298, 54);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(434, 230);
      ((Control) this.headerPanel1).TabIndex = 95;
      this.headerPanel1.TextAntialias = true;
      this.tbxBankDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxBankDetails.BackColor = Color.AliceBlue;
      this.tbxBankDetails.BorderStyle = BorderStyle.None;
      this.tbxBankDetails.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankDetails.ForeColor = Color.Maroon;
      this.tbxBankDetails.Location = new Point(166, 188);
      this.tbxBankDetails.Name = "tbxBankDetails";
      this.tbxBankDetails.Size = new Size(261, 15);
      this.tbxBankDetails.TabIndex = 36;
      this.tbxBankDetails.Visible = false;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Location = new Point(169, 150);
      this.label6.Name = "label6";
      this.label6.Size = new Size(66, 15);
      this.label6.TabIndex = 35;
      this.label6.Text = "REMINDER";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Location = new Point(169, 117);
      this.label9.Name = "label9";
      this.label9.Size = new Size(98, 15);
      this.label9.TabIndex = 34;
      this.label9.Text = "PHONE NUMBER";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Location = new Point(169, 41);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 15);
      this.label12.TabIndex = 33;
      this.label12.Text = "ADDRESS";
      this.tbxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddress.BackColor = Color.AliceBlue;
      this.tbxAddress.BorderStyle = BorderStyle.None;
      this.tbxAddress.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAddress.Location = new Point(169, 58);
      this.tbxAddress.Name = "tbxAddress";
      this.tbxAddress.Size = new Size(258, 59);
      this.tbxAddress.TabIndex = 32;
      this.tbxAddress.Text = "";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Location = new Point(169, 7);
      this.label13.Name = "label13";
      this.label13.Size = new Size(106, 15);
      this.label13.TabIndex = 31;
      this.label13.Text = "CUSTOMER NAME";
      this.tbxAverageNumberOfDaysForRelease.BackColor = Color.AliceBlue;
      this.tbxAverageNumberOfDaysForRelease.BorderStyle = BorderStyle.None;
      this.tbxAverageNumberOfDaysForRelease.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAverageNumberOfDaysForRelease.Location = new Point(535, 8);
      this.tbxAverageNumberOfDaysForRelease.Name = "tbxAverageNumberOfDaysForRelease";
      this.tbxAverageNumberOfDaysForRelease.ReadOnly = true;
      this.tbxAverageNumberOfDaysForRelease.Size = new Size(57, 15);
      this.tbxAverageNumberOfDaysForRelease.TabIndex = 10;
      this.tbxAverageNumberOfDaysForRelease.TextAlign = HorizontalAlignment.Center;
      this.tbxNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxNotes.BackColor = Color.AliceBlue;
      this.tbxNotes.BorderStyle = BorderStyle.None;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(169, 167);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(261, 15);
      this.tbxNotes.TabIndex = 28;
      this.tbxNotes.Visible = false;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BackColor = Color.AliceBlue;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.BorderStyle = BorderStyle.None;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Location = new Point(598, 8);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Name = "tbxNumberOfTimesReleaseExceedTwelveMonths";
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.ReadOnly = true;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.Size = new Size(57, 15);
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TabIndex = 9;
      this.tbxNumberOfTimesReleaseExceedTwelveMonths.TextAlign = HorizontalAlignment.Center;
      this.tbxCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerName.BackColor = Color.AliceBlue;
      this.tbxCustomerName.BorderStyle = BorderStyle.None;
      this.tbxCustomerName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerName.Location = new Point(169, 24);
      this.tbxCustomerName.Name = "tbxCustomerName";
      this.tbxCustomerName.Size = new Size(258, 15);
      this.tbxCustomerName.TabIndex = 0;
      this.pictureBox1.Location = new Point(6, 6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(155, 181);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.tbxCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxCustomerCode.BackColor = Color.AliceBlue;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(17, 186);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.ReadOnly = true;
      this.tbxCustomerCode.Size = new Size(123, 15);
      this.tbxCustomerCode.TabIndex = 8;
      this.tbxPhoneNumber.BackColor = Color.AliceBlue;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.None;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.ForeColor = Color.MidnightBlue;
      this.tbxPhoneNumber.Location = new Point(172, 133);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(106, 15);
      this.tbxPhoneNumber.TabIndex = 11;
      this.tbxCell.BackColor = Color.AliceBlue;
      this.tbxCell.BorderStyle = BorderStyle.None;
      this.tbxCell.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCell.ForeColor = Color.MidnightBlue;
      this.tbxCell.Location = new Point(282, 185);
      this.tbxCell.Name = "tbxCell";
      this.tbxCell.Size = new Size(113, 15);
      this.tbxCell.TabIndex = 22;
      this.customPanel6.BackColor = Color.AliceBlue;
      this.customPanel6.BackColor2 = Color.Azure;
      this.customPanel6.BorderColor = Color.MidnightBlue;
      this.customPanel6.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel6).Controls.Add((Control) this.lblMessage);
      ((Control) this.customPanel6).Controls.Add((Control) this.btnAddArticles);
      this.customPanel6.Curvature = 1;
      this.customPanel6.GradientMode = CSharpCustomPanelControl.LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel6).Location = new Point(3, 426);
      ((Control) this.customPanel6).Name = "customPanel6";
      ((Control) this.customPanel6).Size = new Size(287, 97);
      ((Control) this.customPanel6).TabIndex = 94;
      this.btnAddArticles.BackColor = Color.White;
      this.btnAddArticles.FadeOnFocus = true;
      this.btnAddArticles.ForeColor = Color.Black;
      this.btnAddArticles.ForeColorOnFocus = Color.Red;
      this.btnAddArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddArticles.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnAddArticles).Image = (Image) componentResourceManager.GetObject("btnAddArticles.Image");
      this.btnAddArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddArticles).Location = new Point(27, 36);
      ((Control) this.btnAddArticles).Name = "btnAddArticles";
      this.btnAddArticles.OuterBorderColor = Color.MistyRose;
      this.btnAddArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticles).Size = new Size(217, 45);
      ((Control) this.btnAddArticles).TabIndex = 8;
      ((Control) this.btnAddArticles).Text = "SAVE";
      ((ButtonBase) this.btnAddArticles).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticles).Click += new EventHandler(this.btnAddArticles_Click);
      this.timer1.Interval = 500;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.timer2.Interval = 1000;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.White;
      this.panel1.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.Controls.Add((Control) this.label10);
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(992, 45);
      this.panel1.TabIndex = 13;
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.Black;
      this.label10.Location = new Point(361, 9);
      this.label10.Name = "label10";
      this.label10.Size = new Size(288, 29);
      this.label10.TabIndex = 10;
      this.label10.Text = "AUCTION REDEMPTION";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(999, 575);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormAuctionRedemption);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "AUCTION REDEMPTION";
      this.Load += new EventHandler(this.FormTesting1_Load);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      ((Control) this.customPanel4).ResumeLayout(false);
      ((Control) this.customPanel4).PerformLayout();
      ((Control) this.customPanel2).ResumeLayout(false);
      ((Control) this.customPanel2).PerformLayout();
      ((Control) this.customPanel3).ResumeLayout(false);
      ((Control) this.customPanel3).PerformLayout();
      ((Control) this.customPanel5).ResumeLayout(false);
      ((Control) this.customPanel5).PerformLayout();
      ((Control) this.customPanel7).ResumeLayout(false);
      ((Control) this.customPanel7).PerformLayout();
      ((Control) this.customPanel8).ResumeLayout(false);
      ((Control) this.customPanel8).PerformLayout();
      ((Control) this.customPanel9).ResumeLayout(false);
      ((Control) this.customPanel9).PerformLayout();
      this.panel2.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvArticles).EndInit();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((Control) this.customPanel6).ResumeLayout(false);
      ((Control) this.customPanel6).PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
