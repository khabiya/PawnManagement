

using ExportToExcel11;
using Glass;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormKhaatho : Form
  {
    private string oldValues = "";
    private string newValues = "";
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView2;
    private TextBox tbxReleaseDate;
    private TextBox tbxPledgeBillNumberSearch;
    private TextBox tbxWeight;
    private TextBox tbxPledgeDate;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private GlassButton btnAddEdit;
    private ComboBox comboBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private GlassButton btnRelease;
    private ToolStripMenuItem rELEASEToolStripMenuItem;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private TextBox tbxPledgeBillNumber;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private Panel panel1;
    private DataGridView dataGridView1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem1;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem1;
    private Label label6;
    private TextBox textBox1;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private Label label7;
    private TextBox tbxShopCode;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem1;

    public FormKhaatho() => this.InitializeComponent();

    private void getBankCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where Active = 1 and type = 'KHAATHO'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form khatho.getbankCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving BankPledge" + strError);
        }
        else
        {
          this.comboBox1.Items.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.comboBox1.Items.Add((object) row.Field<string>("BankCode"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.getbankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblKhaatho order By pledgeBillNumber";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form khaatho.refreshgrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the data from tblkhaatho .\n" + strError);
      }
      else
        this.dataGridView2.DataSource = (object) dataTable2;
      this.dataGridView2.Columns["ID"].Visible = false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormKhaatho_Load(object sender, EventArgs e)
    {
      try
      {
        this.getBankCode();
        if (this.comboBox1.Items.Count > 0)
          this.comboBox1.SelectedIndex = 0;
        this.refreshGrid();
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView2);
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        this.tbxPledgeDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.groupBox1.Enabled = true;
        this.groupBox2.Enabled = false;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.khatho_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView2.CurrentCell.RowIndex < 0)
          return;
        int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
        this.comboBox1.Text = this.dataGridView2.Rows[rowIndex].Cells["BankCode"].Value.ToString();
        this.tbxPledgeBillNumberSearch.Text = this.dataGridView2.Rows[rowIndex].Cells["PledgeBillNumber"].Value.ToString();
        this.tbxPledgeDate.Text = DateTime.Parse(this.dataGridView2.Rows[rowIndex].Cells["PledgeDate"].Value.ToString()).ToString("dd/MM/yyyy");
        this.tbxWeight.Text = this.dataGridView2.Rows[rowIndex].Cells["Weight"].Value.ToString();
        this.tbxShopCode.Text = this.dataGridView2.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
        ((Control) this.btnAddEdit).Text = "UPDATE";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.edittToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView2.CurrentCell.RowIndex >= 0)
          this.deleteBankCodeFromPledgeTable(this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["PledgeBillNumber"].Value.ToString(), this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString());
        if (this.dataGridView2.CurrentCell.RowIndex >= 0)
        {
          int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
          {
            string strError = "";
            if (SQLHelper.RunCommand("Delete from tblKhaatho where ID =@ID", new List<OleDbParameter>()
            {
              new OleDbParameter("ID", (object) this.dataGridView2.Rows[rowIndex].Cells["ID"].Value.ToString())
            }, ref strError) != "Done")
            {
              PawnManagementClass.InsertIntoException("form khathoo.deletetoolstipmenuitem_click", strError, FormMain.username, DateTime.Now.ToString());
              int num = (int) MessageBox.Show("Error in deleting" + strError);
            }
          }
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khaatho.deleteToolstipMenuitem_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (((Control) this.btnAddEdit).Text == "UPDATE")
        {
          if (this.tbxPledgeBillNumber.Text != "" && this.tbxPledgeDate.Text != "" && this.tbxWeight.Text != "" && this.comboBox1.Text != "")
          {
            this.edit();
            if (this.comboBox1.Items.Count > 0)
              this.comboBox1.SelectedIndex = 0;
            this.tbxPledgeBillNumberSearch.Text = "";
            this.tbxReleaseDate.Text = "";
            this.tbxWeight.Text = "";
            this.tbxShopCode.Text = "";
          }
          else
          {
            int num1 = (int) MessageBox.Show("Enter all the data");
          }
        }
        if (((Control) this.btnAddEdit).Text == "ADD")
        {
          if (this.tbxPledgeBillNumber.Text != "" && this.tbxPledgeDate.Text != "" && this.tbxWeight.Text != "" && this.comboBox1.Text != "")
          {
            this.oldValues = "Values are\n PledgeBillNumber  = " + this.tbxPledgeBillNumber.Text.Trim().ToString();
            this.add();
            PawnManagementClass.InsertIntoHistory("KHATHO ADD", "ITEM ADDED TO KHATHO " + this.comboBox1.Text.Trim().ToString(), "", this.oldValues, FormMain.username, DateTime.Now.ToString());
            if (this.comboBox1.Items.Count > 0)
              this.comboBox1.SelectedIndex = 0;
            this.tbxPledgeBillNumberSearch.Text = "";
            this.tbxReleaseDate.Text = "";
            this.tbxWeight.Text = "";
            this.tbxShopCode.Text = "";
            this.refreshGrid();
            this.tbxPledgeBillNumberSearch.Select();
          }
          else
          {
            int num2 = (int) MessageBox.Show("Enter all the data");
          }
        }
        ((Control) this.btnAddEdit).Text = "ADD";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formm khatho.btnAddAndEdit_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void edit()
    {
      try
      {
        if (this.dataGridView2.CurrentCell.RowIndex < 0)
          return;
        int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
        string strError = "";
        if (SQLHelper.RunCommand("Update tblkhaatho set ShopCode = @ShopCode,PledgeBillNumber = @PledgeBillNumber,PledgeDate = @PledgeDate,BankCode = @Bankcode,Weight = @Weight where ID =@ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) this.tbxShopCode.Text.ToString()),
          new OleDbParameter("PldegeBillNumber", (object) this.tbxPledgeBillNumber.Text.ToString()),
          new OleDbParameter("PledgeDate", (object) this.tbxPledgeDate.Text.ToString()),
          new OleDbParameter("Bankcode", (object) this.comboBox1.Text.ToString()),
          new OleDbParameter("Weight", (object) this.tbxWeight.Text.ToString()),
          new OleDbParameter("ID", (object) int.Parse(this.dataGridView2.Rows[rowIndex].Cells["ID"].Value.ToString()))
        }, ref strError) != "Done")
        {
          int num = (int) MessageBox.Show("Error in editing tblKhaatho" + strError);
        }
        this.addInPledgeTable(this.tbxPledgeBillNumber.Text.Trim().ToString());
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.edit()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void add()
    {
      try
      {
        string strError = "";
        if (SQLHelper.RunCommand("insert into tblKhaatho(ShopCode,PledgeBillNumber,PledgeDate,BankCode,Weight) values(@ShopCode,@PledgeBillNumber,@PledgeDate,@BankCode,@Weight)", new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) this.tbxShopCode.Text.ToString()),
          new OleDbParameter("PldegeBillNumber", (object) this.tbxPledgeBillNumber.Text.ToString()),
          new OleDbParameter("PledgeDate", (object) this.tbxPledgeDate.Text.ToString()),
          new OleDbParameter("Bankcode", (object) this.comboBox1.Text.ToString()),
          new OleDbParameter("Weight", (object) float.Parse(this.tbxWeight.Text.ToString()))
        }, ref strError) != "Done")
        {
          int num = (int) MessageBox.Show("Error in Adding" + strError);
        }
        this.addInPledgeTable(this.tbxPledgeBillNumber.Text.Trim().ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.add()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addInPledgeTable(string BillNumber)
    {
      try
      {
        string strError = "";
        if (!(SQLHelper.RunCommand("update tblPledge set BankCode = @BankCode,BankSerialNumber=@BankSerialNumber  where BillNumber = @BillNumber and ShopCode  = @ShopCode", new List<OleDbParameter>()
        {
          new OleDbParameter("BankCode", (object) this.comboBox1.Text.Trim().ToString()),
          new OleDbParameter("BankSerialNumber", (object) ""),
          new OleDbParameter(nameof (BillNumber), (object) BillNumber),
          new OleDbParameter("ShopCode", (object) this.tbxShopCode.Text)
        }, ref strError) != "Done"))
          return;
        int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khattho.addInPledgeTable", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxPledgeBillNumber_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select  ShopCode,BillNumber,BillDate,Amount,NetWeight,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3 from tblPledge where BillNumber like @BillNumber and (BankCode is null or BankCode ='')  and (Redeemed = 'N')";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("BillNumber", (object) (this.tbxPledgeBillNumberSearch.Text.Trim().ToString() + "%")));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving the pledge details" + strError);
        }
        else
        {
          this.dataGridView1.Visible = true;
          this.dataGridView1.DataSource = (object) dataTable2;
        }
        if (!(this.tbxPledgeBillNumberSearch.Text == ""))
          return;
        this.dataGridView1.Visible = false;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.tbxpledgebillnumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxPledgeDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate((sender as TextBox).Text.ToString()))
        return;
      (sender as TextBox).Select();
    }

    private void tbxReleaseDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate((sender as TextBox).Text.ToString()))
        return;
      (sender as TextBox).Select();
    }

    private void tbxPledgeBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || !(this.dataGridView1 != null & this.dataGridView1.Rows.Count > 0))
        return;
      this.dataGridView1.Rows[0].Selected = true;
      this.dataGridView1.Focus();
      this.dataGridView1.Select();
    }

    private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Return)
        {
          this.tbxWeight.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["netWeight"].Value.ToString();
          this.tbxPledgeBillNumber.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
          this.tbxShopCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
          this.tbxPledgeDate.Focus();
          this.tbxPledgeDate.Select();
          this.dataGridView1.Visible = false;
        }
        if (e.KeyCode != Keys.Escape)
          return;
        this.dataGridView1.Visible = false;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.dataGridView2_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxPledgeBillNumber_KeyUp_1(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (!PawnManagementClass.checkForValidateDate(this.tbxPledgeDate.Text))
        this.tbxPledgeDate.Select();
      else
        ((Control) this.btnAddEdit).Focus();
    }

    private void btnRelease_Click(object sender, EventArgs e)
    {
      try
      {
        if (!PawnManagementClass.checkForValidateDate(this.tbxReleaseDate.Text.ToString()))
        {
          this.tbxReleaseDate.Select();
        }
        else
        {
          this.oldValues = "Values are\n PledgeBillNumber  = " + this.tbxPledgeBillNumber.Text.Trim().ToString();
          PawnManagementClass.InsertIntoHistory("KHATHO RELEASE", "Item released from khatho", "", this.oldValues, FormMain.username, DateTime.Now.ToString());
          this.releaseFromKhaatho();
          this.groupBox2.Enabled = false;
          this.groupBox1.Enabled = true;
          this.dataGridView1.Visible = false;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.btnrelease_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void releaseFromKhaatho()
    {
      int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
      string strError = "";
      if (SQLHelper.RunCommand("Update tblkhaatho set ReleaseDate = @ReleaseDate where ID =@ID", new List<OleDbParameter>()
      {
        new OleDbParameter("ReleaseDate", (object) this.tbxReleaseDate.Text.ToString()),
        new OleDbParameter("ID", (object) int.Parse(this.dataGridView2.Rows[rowIndex].Cells["ID"].Value.ToString()))
      }, ref strError) != "Done")
      {
        int num = (int) MessageBox.Show("Error in editing tblKhaatho" + strError);
      }
      this.refreshGrid();
      this.deleteBankCodeFromPledgeTable(this.tbxPledgeBillNumber.Text.Trim().ToString(), this.tbxShopCode.Text);
    }

    private void deleteBankCodeFromPledgeTable(string BillNumber, string ShopCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set  ShopCode = @ShopCode, BankCode = @BankCode,BankSerialNumber=@BankSerialNumber  where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (ShopCode), (object) ShopCode),
        new OleDbParameter("BankCode", (object) ""),
        new OleDbParameter("BankSerialNumber", (object) ""),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form khatho.deelteBankCodeFromPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void rELEASEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView2.CurrentCell.RowIndex < 0)
          return;
        int rowIndex = this.dataGridView2.CurrentCell.RowIndex;
        this.comboBox1.Text = this.dataGridView2.Rows[rowIndex].Cells["BankCode"].Value.ToString();
        this.tbxPledgeBillNumber.Text = this.dataGridView2.Rows[rowIndex].Cells["PledgeBillNumber"].Value.ToString();
        this.tbxPledgeDate.Text = DateTime.Parse(this.dataGridView2.Rows[rowIndex].Cells["PledgeDate"].Value.ToString()).ToString("dd/MM/yyyy");
        this.tbxWeight.Text = this.dataGridView2.Rows[rowIndex].Cells["Weight"].Value.ToString();
        this.tbxShopCode.Text = this.dataGridView2.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
        this.groupBox1.Enabled = false;
        this.groupBox2.Enabled = true;
        this.tbxReleaseDate.Select();
        this.tbxReleaseDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form khatho.releaseToolsStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxReleaseDate_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void exportToExcelToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void wrapToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void tbxPledgeBillNumberSearch_Enter(object sender, EventArgs e) => this.tbxPledgeBillNumberSearch.SelectionStart = this.tbxPledgeBillNumberSearch.Text.Length;

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select ID,ShopCode,PledgeBillNumber,PledgeDate,BankCode,Weight,ReleaseDate from tblKhaatho where PledgeBillNumber like @PledgeBillNumber or PledgeDate like @PledgeDate or BankCode like @BankCode or Weight like @Weight or ReleaseDate like @ReleaseDate order by PledgeBillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("PledgeBillNumber", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("PledgeDate", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("BankCode", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("Weight", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      parameters.Add(new OleDbParameter("ReleaseDate", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form searchCustomer textbox2_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView2.DataSource = (object) dataTable2;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "khatho").ShowDialog();
    }

    private void tbxPledgeBillNumberSearch_KeyPress(object sender, KeyPressEventArgs e)
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

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0 || (sender as DataGridView).Columns.Count <= 0)
        return;
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "PledgeBillNumber")
      {
        double num = (double) ((sender as DataGridView).Location.Y + (sender as DataGridView).Size.Width);
        string BILLNUMBER = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["PledgeBillNumber"].Value.ToString();
        string SHOPCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0 || (sender as DataGridView).Columns.Count <= 0)
        return;
      if ((sender as DataGridView).Columns[e.ColumnIndex].HeaderText == "PledgeBillNumber" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "customercode" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "billnumber")
        (sender as DataGridView).Cursor = Cursors.Hand;
      else
        (sender as DataGridView).Cursor = Cursors.Default;
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0)
        return;
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if ((sender as DataGridView).CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) ((sender as DataGridView).Location.Y + (sender as DataGridView).Size.Width);
        string BILLNUMBER = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void exportToExcelOption2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
          CreateExcelFile.CreateExcelDocument((sourceControl as DataGridView).DataSource as DataTable, folderBrowserDialog.SelectedPath + "\\" + (sourceControl as DataGridView).Name + ".xlsx");
      }
    }

    private void exportToExcelOption2ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
          CreateExcelFile.CreateExcelDocument((sourceControl as DataGridView).DataSource as DataTable, folderBrowserDialog.SelectedPath + "\\" + (sourceControl as DataGridView).Name + ".xlsx");
      }
    }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if ((sender as DataGridView).Rows.Count <= 0)
        return;
      if ((sender as DataGridView).Columns[e.ColumnIndex].HeaderText == "BillNumber" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "customercode" | (sender as DataGridView).Columns[e.ColumnIndex].Name == "billnumber")
        (sender as DataGridView).Cursor = Cursors.Hand;
      else
        (sender as DataGridView).Cursor = Cursors.Default;
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
      this.dataGridView2 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.rELEASEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem1 = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tbxReleaseDate = new TextBox();
      this.tbxPledgeBillNumberSearch = new TextBox();
      this.tbxWeight = new TextBox();
      this.tbxPledgeDate = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.btnAddEdit = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.btnRelease = new GlassButton();
      this.groupBox1 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.tbxPledgeBillNumber = new TextBox();
      this.label7 = new Label();
      this.tbxShopCode = new TextBox();
      this.groupBox2 = new GroupBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.panel1 = new Panel();
      this.label6 = new Label();
      this.textBox1 = new TextBox();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem1 = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem1 = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.groupBox2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.contextMenuStrip2.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.Location = new Point(3, 49);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView2.Size = new Size(568, 574);
      this.dataGridView2.TabIndex = 7;
      this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView2.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.rELEASEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem1,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.rELEASEToolStripMenuItem.Name = "rELEASEToolStripMenuItem";
      this.rELEASEToolStripMenuItem.Size = new Size(194, 22);
      this.rELEASEToolStripMenuItem.Text = "RELEASE";
      this.rELEASEToolStripMenuItem.Click += new EventHandler(this.rELEASEToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem1.Name = "exportToExcelToolStripMenuItem1";
      this.exportToExcelToolStripMenuItem1.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem1.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem1.Click += new EventHandler(this.exportToExcelToolStripMenuItem1_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tbxReleaseDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxReleaseDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxReleaseDate.Location = new Point(170, 33);
      this.tbxReleaseDate.Name = "tbxReleaseDate";
      this.tbxReleaseDate.Size = new Size(198, 29);
      this.tbxReleaseDate.TabIndex = 5;
      this.tbxReleaseDate.KeyUp += new KeyEventHandler(this.tbxReleaseDate_KeyUp);
      this.tbxReleaseDate.Validating += new CancelEventHandler(this.tbxReleaseDate_Validating);
      this.tbxPledgeBillNumberSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeBillNumberSearch.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumberSearch.Location = new Point(324, 77);
      this.tbxPledgeBillNumberSearch.Name = "tbxPledgeBillNumberSearch";
      this.tbxPledgeBillNumberSearch.Size = new Size(81, 29);
      this.tbxPledgeBillNumberSearch.TabIndex = 1;
      this.tbxPledgeBillNumberSearch.TextChanged += new EventHandler(this.tbxPledgeBillNumber_TextChanged);
      this.tbxPledgeBillNumberSearch.Enter += new EventHandler(this.tbxPledgeBillNumberSearch_Enter);
      this.tbxPledgeBillNumberSearch.KeyDown += new KeyEventHandler(this.tbxPledgeBillNumber_KeyDown);
      this.tbxPledgeBillNumberSearch.KeyPress += new KeyPressEventHandler(this.tbxPledgeBillNumberSearch_KeyPress);
      this.tbxWeight.BorderStyle = BorderStyle.FixedSingle;
      this.tbxWeight.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxWeight.Location = new Point(207, 112);
      this.tbxWeight.Name = "tbxWeight";
      this.tbxWeight.ReadOnly = true;
      this.tbxWeight.Size = new Size(198, 29);
      this.tbxWeight.TabIndex = 2;
      this.tbxWeight.KeyUp += new KeyEventHandler(this.tbxPledgeBillNumber_KeyUp_1);
      this.tbxPledgeDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeDate.Location = new Point(207, 151);
      this.tbxPledgeDate.Name = "tbxPledgeDate";
      this.tbxPledgeDate.Size = new Size(198, 29);
      this.tbxPledgeDate.TabIndex = 3;
      this.tbxPledgeDate.KeyUp += new KeyEventHandler(this.tbxPledgeBillNumber_KeyUp_1);
      this.tbxPledgeDate.Validating += new CancelEventHandler(this.tbxPledgeDate_Validating);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(28, 36);
      this.label1.Name = "label1";
      this.label1.Size = new Size(98, 24);
      this.label1.TabIndex = 12;
      this.label1.Text = "BankCode";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(28, 75);
      this.label2.Name = "label2";
      this.label2.Size = new Size(173, 24);
      this.label2.TabIndex = 11;
      this.label2.Text = "Pledge Bill Number";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(28, 114);
      this.label3.Name = "label3";
      this.label3.Size = new Size(69, 24);
      this.label3.TabIndex = 10;
      this.label3.Text = "Weight";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(28, 153);
      this.label4.Name = "label4";
      this.label4.Size = new Size(48, 24);
      this.label4.TabIndex = 9;
      this.label4.Text = "Date";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(42, 38);
      this.label5.Name = "label5";
      this.label5.Size = new Size(122, 24);
      this.label5.TabIndex = 8;
      this.label5.Text = "Release Date";
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(243, 221);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(138, 49);
      ((Control) this.btnAddEdit).TabIndex = 4;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(207, 34);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(198, 32);
      this.comboBox1.TabIndex = 0;
      this.btnRelease.BackColor = Color.LightBlue;
      this.btnRelease.FadeOnFocus = true;
      this.btnRelease.ForeColor = Color.MediumBlue;
      this.btnRelease.ForeColorOnFocus = Color.Red;
      this.btnRelease.ForeColorOnLeave = Color.RoyalBlue;
      this.btnRelease.GlowColor = Color.White;
      ((ButtonBase) this.btnRelease).Image = (Image) Resources.tick;
      this.btnRelease.InnerBorderColor = Color.Transparent;
      ((Control) this.btnRelease).Location = new Point(134, 78);
      ((Control) this.btnRelease).Name = "btnRelease";
      this.btnRelease.OuterBorderColor = Color.MediumSlateBlue;
      this.btnRelease.ShineColor = Color.Transparent;
      ((Control) this.btnRelease).Size = new Size(184, 59);
      ((Control) this.btnRelease).TabIndex = 14;
      ((Control) this.btnRelease).Text = "&RELEASE";
      ((ButtonBase) this.btnRelease).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnRelease).Click += new EventHandler(this.btnRelease_Click);
      this.groupBox1.Controls.Add((Control) this.dataGridView1);
      this.groupBox1.Controls.Add((Control) this.tbxPledgeBillNumber);
      this.groupBox1.Controls.Add((Control) this.comboBox1);
      this.groupBox1.Controls.Add((Control) this.btnAddEdit);
      this.groupBox1.Controls.Add((Control) this.tbxPledgeBillNumberSearch);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.tbxWeight);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.tbxPledgeDate);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.tbxShopCode);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBox1.Location = new Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(416, 307);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Pledge";
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(18, 112);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(387, 174);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.Visible = false;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView2_KeyDown);
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.Location = new Point(207, 77);
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.ReadOnly = true;
      this.tbxPledgeBillNumber.Size = new Size(111, 29);
      this.tbxPledgeBillNumber.TabIndex = 13;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(28, 188);
      this.label7.Name = "label7";
      this.label7.Size = new Size(101, 24);
      this.label7.TabIndex = 15;
      this.label7.Text = "ShopCode";
      this.tbxShopCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(207, 186);
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(198, 29);
      this.tbxShopCode.TabIndex = 14;
      this.groupBox2.Controls.Add((Control) this.btnRelease);
      this.groupBox2.Controls.Add((Control) this.tbxReleaseDate);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBox2.Location = new Point(3, 316);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(416, 307);
      this.groupBox2.TabIndex = 16;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Release";
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.46032f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.53968f));
      this.tableLayoutPanel1.Controls.Add((Control) this.tableLayoutPanel3, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 14;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel3.Controls.Add((Control) this.dataGridView2, 0, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel3.Dock = DockStyle.Fill;
      this.tableLayoutPanel3.Location = new Point(431, 3);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 7.348243f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 92.65176f));
      this.tableLayoutPanel3.Size = new Size(574, 626);
      this.tableLayoutPanel3.TabIndex = 14;
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(568, 40);
      this.panel1.TabIndex = 14;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(157, 7);
      this.label6.Name = "label6";
      this.label6.Size = new Size(70, 24);
      this.label6.TabIndex = 12;
      this.label6.Text = "Search";
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(233, 5);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(329, 29);
      this.textBox1.TabIndex = 2;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.Controls.Add((Control) this.groupBox1, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.groupBox2, 0, 1);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel2.Size = new Size(422, 626);
      this.tableLayoutPanel2.TabIndex = 17;
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem1,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem1
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(195, 92);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(150, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.wrapToolStripMenuItem1.Name = "wrapToolStripMenuItem1";
      this.wrapToolStripMenuItem1.Size = new Size(150, 22);
      this.wrapToolStripMenuItem1.Text = "Wrap";
      this.wrapToolStripMenuItem1.Click += new EventHandler(this.wrapToolStripMenuItem1_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem1.Name = "exportToExcelOption2ToolStripMenuItem1";
      this.exportToExcelOption2ToolStripMenuItem1.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem1.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem1.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem1_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormKhaatho);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormKhaatho);
      this.Load += new EventHandler(this.FormKhaatho_Load);
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.contextMenuStrip2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
