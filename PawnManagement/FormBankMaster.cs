

using ExportToExcel11;
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormBankMaster : Form
  {
    private string bankCode = string.Empty;
    private string oldValues;
    private string newValues;
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxBankCode;
    private TextBox tbxBankName;
    private TextBox tbxBranch;
    private TextBox tbxIfscCode;
    private TextBox tbxPhoneNumber1;
    private TextBox tbxPhoneNumber2;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ComboBox cbType;
    private Label label7;
    private Label label8;
    private Label label9;
    private TextBox tbxVoucherName;
    private TextBox tbxLedgerCode;
    private TextBox tbxVoucherCode;
    private TextBox tbxLedgerType;
    private TextBox tbxLedgerTypeInterest;
    private TextBox tbxVoucherCodeInterest;
    private Label label10;
    private Label label11;
    private TextBox tbxVoucherNameInterest;
    private TextBox tbxLedgerCodeInterest;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label12;
    private Panel panel3;
    private GlassButton btnAddEdit;
    private HeaderPanel headerPanel2;
    private HeaderPanel headerPanel1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormBankMaster() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select BankCode,BankName,Branch,LedgerCode,VoucherCode,LedgerCodeInterest,VoucherCodeInterest,IfscCode,PhoneNumber1,PhoneNumber2,type from tblBankMaster where Active =1";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form bank master.refreshgrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the bank details\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void BankMaster_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatButtonControl(ref this.btnAddEdit);
      PawnManagementClass.formatDataGridViewBlack(ref this.dataGridView1);
      if (this.cbType.Items.Count > 0)
        this.cbType.SelectedIndex = 0;
      this.getLedgerType();
      this.getLedgerTypeInterest();
    }

    private void getLedgerType()
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form BankMaster.getLedgerType()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form BankMaster.getLedgerType() \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.tbxLedgerType.Text = dataTable2.Rows[0]["ledgertype"].ToString();
    }

    private void getLedgerTypeInterest()
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerCode", (object) this.tbxLedgerCodeInterest.Text)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form BankMaster.getLedgerType()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form BankMaster.getLedgerType() \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.tbxLedgerTypeInterest.Text = dataTable2.Rows[0]["ledgertype"].ToString();
    }

    private void addBankMaster()
    {
      string strError = "";
      if (SQLHelper.RunCommand("insert into tblBankMaster(BankCode,BankName,Branch,IfscCode,PhoneNumber1,PhoneNumber2,LedgerCode,VoucherCode,LedgerCodeInterest,VoucherCodeInterest,Type,Active,CreatedBy,CreatedOn) values(@BankCode,@BankName,@Branch,@IfscCode,@PhoneNumber1,@PhoneNumber2,@LedgerCode,@VoucherCode,@LedgerCodeInterest,@VoucherCodeInterest,@Type,@Active,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("BankCode", (object) this.tbxBankCode.Text.ToString()),
        new OleDbParameter("BankName", (object) this.tbxBankName.Text.ToString()),
        new OleDbParameter("Branch", (object) this.tbxBranch.Text.ToString()),
        new OleDbParameter("IfscCode", (object) this.tbxIfscCode.Text.ToString()),
        new OleDbParameter("PhoneNumber1", (object) this.tbxPhoneNumber1.Text.ToString()),
        new OleDbParameter("PhoneNumber2", (object) this.tbxPhoneNumber2.Text.Trim().ToString()),
        new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()),
        new OleDbParameter("VoucherCode", (object) this.tbxVoucherCode.Text.Trim().ToString()),
        new OleDbParameter("LedgerCodeInterest", (object) this.tbxLedgerCodeInterest.Text.Trim().ToString()),
        new OleDbParameter("VoucherCodeInterest", (object) this.tbxVoucherCodeInterest.Text.Trim().ToString()),
        new OleDbParameter("Type", (object) this.cbType.Text.Trim().ToString()),
        new OleDbParameter("Active", (object) "1"),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy"))
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form bank master.addBankMaster", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding BankMaster" + strError);
      }
      this.refreshGrid();
    }

    private void editBankMaster()
    {
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      string strError = "";
      if (SQLHelper.RunCommand("Update tblBankMaster set BankName=@BankName,Branch=@Branch,IfscCode=@IfscCode,PhoneNumber1=@PhoneNumber1,PhoneNumber2 = @PhoneNumber2 where BankCode =@BankCode", new List<OleDbParameter>()
      {
        new OleDbParameter("BankName", (object) this.tbxBankName.Text.ToString()),
        new OleDbParameter("Branch", (object) this.tbxBranch.Text.ToString()),
        new OleDbParameter("IfscCode", (object) this.tbxIfscCode.Text.ToString()),
        new OleDbParameter("PhoneNumber1", (object) this.tbxPhoneNumber1.Text.ToString()),
        new OleDbParameter("PhoneNumber2", (object) this.tbxPhoneNumber2.Text.Trim().ToString()),
        new OleDbParameter("BankCode", (object) this.bankCode)
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form bank master.editBankMaster", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in editing BankMaster" + strError);
      }
      this.refreshGrid();
    }

    private bool checkIfBankCodeUsedInBankPledge(string BankCode)
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge where BankCode = @BankCode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankCode), (object) BankCode)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form BankMaster.checkifbankcodeusedinbankpledge(string bankcode)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form BankMaster.checkIfBankCodeUsedInBankPledge \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (!this.checkIfBankCodeUsedInBankPledge(this.dataGridView1.Rows[rowIndex].Cells["BankCode"].Value.ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
          {
            string strError = "";
            if (SQLHelper.RunCommand("update tblBankMaster set Active=@Active where BankCode =@ID", new List<OleDbParameter>()
            {
              new OleDbParameter("Active", (object) "0"),
              new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["BankCode"].Value.ToString())
            }, ref strError) != "Done")
            {
              int num = (int) MessageBox.Show("Error in deleting BankMaster" + strError);
              PawnManagementClass.InsertIntoException("form bankmaster.deletetoolstripmenuitem_click", strError, FormMain.username, DateTime.Now.ToString());
            }
            PawnManagementClass.InsertIntoHistory("BANK MASTER DELETED", "Bank code " + this.tbxBankCode.Text.Trim().ToString() + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("BankCode Already in Use...Cannot be deleted");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank master deletetoolStripMentuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        this.bankCode = this.tbxBankCode.Text = this.dataGridView1.Rows[rowIndex].Cells["BankCode"].Value.ToString();
        this.tbxBankName.Text = this.dataGridView1.Rows[rowIndex].Cells["BankName"].Value.ToString();
        this.tbxBranch.Text = this.dataGridView1.Rows[rowIndex].Cells["Branch"].Value.ToString();
        this.tbxIfscCode.Text = this.dataGridView1.Rows[rowIndex].Cells["IfscCode"].Value.ToString();
        this.tbxPhoneNumber1.Text = this.dataGridView1.Rows[rowIndex].Cells["PhoneNumber1"].Value.ToString();
        this.tbxPhoneNumber2.Text = this.dataGridView1.Rows[rowIndex].Cells["PhoneNumber2"].Value.ToString();
        this.cbType.Text = this.dataGridView1.Rows[rowIndex].Cells["Type"].Value.ToString();
        this.oldValues = "Old values are BankCode =" + this.tbxBankCode.Text.Trim().ToString() + " , \n BankName =" + this.tbxBankName.Text.Trim().ToString() + " ,\n Branch =" + this.tbxBranch.Text.Trim().ToString() + ",\n IFSCcode =" + this.tbxIfscCode.Text.Trim().ToString() + ",\n PhoneNumber1 =" + this.tbxPhoneNumber1.Text.Trim().ToString() + ",\n PhoneNumber2 =" + this.tbxPhoneNumber2.Text.Trim().ToString();
        ((Control) this.btnAddEdit).Text = "UPDATE";
        this.tbxBankCode.ReadOnly = true;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank master.editToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkDuplicateBankCode()
    {
      string strError = "";
      string my_querry = "select * from tblBankMaster where BankCode = @BankCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BankCode", (object) this.tbxBankCode.Text.ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form bank master checkDuplicateBankCode", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding BankMaster" + strError);
        return false;
      }
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return true;
      int num1 = (int) MessageBox.Show("BankCode already taken");
      return false;
    }

    private void tbxBankCode_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbxPhoneNumber1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxPhoneNumber2_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.checkEntries())
        {
          DateTime now;
          if (((Control) this.btnAddEdit).Text == "UPDATE")
          {
            this.editBankMaster();
            this.newValues = "New values are BankCode =" + this.tbxBankCode.Text.Trim().ToString() + " , \n BankName =" + this.tbxBankName.Text.Trim().ToString() + " ,\n Branch =" + this.tbxBranch.Text.Trim().ToString() + ",\n IFSCcode =" + this.tbxIfscCode.Text.Trim().ToString() + ",\n PhoneNumber1 =" + this.tbxPhoneNumber1.Text.Trim().ToString() + ",\n PhoneNumber2 =" + this.tbxPhoneNumber2.Text.Trim().ToString();
            string ActionDetails = this.tbxBankCode.Text.Trim().ToString() + " edited";
            string oldValues = this.oldValues;
            string newValues = this.newValues;
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("BANK MASTER", ActionDetails, oldValues, newValues, username, PerformedOn);
            this.tbxBankCode.Text = "";
            this.tbxBankName.Text = "";
            this.tbxBranch.Text = "";
            this.tbxIfscCode.Text = "";
            this.tbxPhoneNumber1.Text = "";
            this.tbxPhoneNumber2.Text = "";
            this.tbxBankCode.ReadOnly = false;
          }
          if (((Control) this.btnAddEdit).Text == "ADD" && this.checkDuplicateBankCode())
          {
            this.addvoucherMaster();
            this.addBankMaster();
            string ActionDetails = "Bank master entry " + this.tbxBankCode.Text.Trim().ToString() + " created";
            string Newvalues = "BankCode =" + this.tbxBankCode.Text.Trim().ToString() + " , \n BankName =" + this.tbxBankName.Text.Trim().ToString() + " ,\n Branch =" + this.tbxBranch.Text.Trim().ToString() + ",\n IFSCcode =" + this.tbxIfscCode.Text.Trim().ToString() + ",\n PhoneNumber1 =" + this.tbxPhoneNumber1.Text.Trim().ToString() + ",\n PhoneNumber2 =" + this.tbxPhoneNumber2.Text.Trim().ToString();
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("BANK MASTER", ActionDetails, "", Newvalues, username, PerformedOn);
            this.tbxBankCode.Text = "";
            this.tbxBankName.Text = "";
            this.tbxBranch.Text = "";
            this.tbxIfscCode.Text = "";
            this.tbxPhoneNumber1.Text = "";
            this.tbxPhoneNumber2.Text = "";
          }
          ((Control) this.btnAddEdit).Text = "ADD";
        }
        else
        {
          int num = (int) MessageBox.Show("Fill all the details");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bank master.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkEntries()
    {
      if (this.tbxBankCode.Text.Trim() != "")
      {
        if (this.tbxBankName.Text.Trim() != "")
        {
          if (this.tbxBranch.Text.Trim() != "")
            return true;
          this.tbxBranch.Select();
          return false;
        }
        this.tbxBankName.Select();
        return false;
      }
      this.tbxBankCode.Select();
      return false;
    }

    private void addvoucherMaster()
    {
      try
      {
        string strError = "";
        if (SQLHelper.RunCommand("insert into tblVoucherMaster(VoucherCode,VoucherName,LedgerCode,LedgerType,CreatedOn,CreatedBy) values(@VoucherCode,@VoucherName,@LedgerCode,@LedgerType,@CreatedOn,@CreatedBy)", new List<OleDbParameter>()
        {
          new OleDbParameter("Vouchercode", (object) this.tbxVoucherCode.Text.Trim().ToString()),
          new OleDbParameter("VoucherName", (object) this.tbxVoucherName.Text.Trim().ToString()),
          new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()),
          new OleDbParameter("LedgerType", (object) this.tbxLedgerType.Text.Trim().ToString()),
          new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString()),
          new OleDbParameter("CreatedBy", (object) FormMain.username)
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("form voucherMaster.addVoucherMaster()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in Adding" + strError);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankmaster.addcouvhermaster", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      try
      {
        string strError = "";
        if (!(SQLHelper.RunCommand("insert into tblVoucherMaster(VoucherCode,VoucherName,LedgerCode,LedgerType,CreatedOn,CreatedBy) values(@VoucherCode,@VoucherName,@LedgerCode,@LedgerType,@CreatedOn,@CreatedBy)", new List<OleDbParameter>()
        {
          new OleDbParameter("Vouchercode", (object) this.tbxVoucherCodeInterest.Text.Trim().ToString()),
          new OleDbParameter("VoucherName", (object) this.tbxVoucherNameInterest.Text.Trim().ToString()),
          new OleDbParameter("LedgerCode", (object) this.tbxLedgerCodeInterest.Text.Trim().ToString()),
          new OleDbParameter("LedgerType", (object) this.tbxLedgerTypeInterest.Text.Trim().ToString()),
          new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString()),
          new OleDbParameter("CreatedBy", (object) FormMain.username)
        }, ref strError) != "Done"))
          return;
        PawnManagementClass.InsertIntoException("form voucherMaster.addVoucherMaster()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form bankmaster.addcouvhermaster", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxLedgerCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void textBox2_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxBankCode_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (!(((Control) this.btnAddEdit).Text == "ADD"))
          return;
        if (this.checkDuplicateBankCode())
        {
          if (this.tbxBankCode.Text.Trim() != "")
          {
            char ch = this.tbxBankCode.Text.Trim()[0];
            string strError = "";
            DataTable dataTable = SQLHelper.GetDataTable("select * from tblVoucherMaster where VoucherCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
            if (strError != "")
              PawnManagementClass.InsertIntoException("form voucherMaster.tbxBankCode_Leave", strError, FormMain.username, DateTime.Now.ToString());
            if (dataTable != null)
            {
              if (dataTable.Rows.Count > 0)
              {
                string str = ch.ToString();
                this.tbxVoucherCode.Text = str + this.NextCustomerCode(dataTable);
                this.tbxVoucherCodeInterest.Text = str + (int.Parse(this.NextCustomerCode(dataTable)) + 1).ToString();
              }
              else
              {
                this.tbxVoucherCode.Text = ch.ToString() + "1";
                this.tbxVoucherCodeInterest.Text = ch.ToString() + "2";
              }
            }
            else
            {
              int num = (int) MessageBox.Show("Error while setting voucherCode Restart - " + strError);
            }
          }
        }
        else
          this.tbxBankCode.Select();
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

    private void tbxBankCode_TextChanged(object sender, EventArgs e)
    {
      this.tbxVoucherName.Text = this.tbxBankCode.Text;
      this.tbxVoucherNameInterest.Text = this.tbxBankCode.Text + " INTEREST";
    }

    private void tbxVoucherName_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxLedgerType_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void glassButton1_Click(object sender, EventArgs e)
    {
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "Bank Master", FormMain.username);

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

    private void cbType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddEdit).Focus();
    }

    private void tbxBankName_TextChanged(object sender, EventArgs e)
    {
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "BANK MASTER").ShowDialog();
    }

    private void label12_Click(object sender, EventArgs e)
    {
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
      this.components = (IContainer) new System.ComponentModel.Container();
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tbxBankCode = new TextBox();
      this.tbxBankName = new TextBox();
      this.tbxBranch = new TextBox();
      this.tbxIfscCode = new TextBox();
      this.tbxPhoneNumber1 = new TextBox();
      this.tbxPhoneNumber2 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.cbType = new ComboBox();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.tbxVoucherName = new TextBox();
      this.tbxLedgerCode = new TextBox();
      this.tbxVoucherCode = new TextBox();
      this.tbxLedgerType = new TextBox();
      this.tbxLedgerTypeInterest = new TextBox();
      this.tbxVoucherCodeInterest = new TextBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.tbxVoucherNameInterest = new TextBox();
      this.tbxLedgerCodeInterest = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label12 = new Label();
      this.panel3 = new Panel();
      this.headerPanel1 = new HeaderPanel();
      this.headerPanel2 = new HeaderPanel();
      this.btnAddEdit = new GlassButton();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = SystemColors.Control;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.ColumnHeadersHeight = 35;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(6, 4);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(989, 306);
      this.dataGridView1.TabIndex = 12;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 158);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export  To Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tbxBankCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxBankCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankCode.Location = new Point(149, 8);
      this.tbxBankCode.Name = "tbxBankCode";
      this.tbxBankCode.Size = new Size(352, 22);
      this.tbxBankCode.TabIndex = 0;
      this.tbxBankCode.TextChanged += new EventHandler(this.tbxBankCode_TextChanged);
      this.tbxBankCode.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.tbxBankCode.Validating += new CancelEventHandler(this.tbxBankCode_Validating);
      this.tbxBankName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBankName.CharacterCasing = CharacterCasing.Upper;
      this.tbxBankName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBankName.Location = new Point(149, 36);
      this.tbxBankName.Name = "tbxBankName";
      this.tbxBankName.Size = new Size(352, 22);
      this.tbxBankName.TabIndex = 1;
      this.tbxBankName.TextChanged += new EventHandler(this.tbxBankName_TextChanged);
      this.tbxBankName.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.tbxBranch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxBranch.CharacterCasing = CharacterCasing.Upper;
      this.tbxBranch.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBranch.Location = new Point(149, 63);
      this.tbxBranch.Name = "tbxBranch";
      this.tbxBranch.Size = new Size(352, 22);
      this.tbxBranch.TabIndex = 2;
      this.tbxBranch.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.tbxIfscCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxIfscCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxIfscCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxIfscCode.Location = new Point(149, 89);
      this.tbxIfscCode.Name = "tbxIfscCode";
      this.tbxIfscCode.Size = new Size(352, 22);
      this.tbxIfscCode.TabIndex = 3;
      this.tbxIfscCode.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.tbxPhoneNumber1.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber1.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber1.Location = new Point(149, 115);
      this.tbxPhoneNumber1.MaxLength = 11;
      this.tbxPhoneNumber1.Name = "tbxPhoneNumber1";
      this.tbxPhoneNumber1.Size = new Size(352, 22);
      this.tbxPhoneNumber1.TabIndex = 4;
      this.tbxPhoneNumber1.KeyPress += new KeyPressEventHandler(this.tbxPhoneNumber1_KeyPress);
      this.tbxPhoneNumber1.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.tbxPhoneNumber2.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber2.CharacterCasing = CharacterCasing.Upper;
      this.tbxPhoneNumber2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber2.Location = new Point(149, 143);
      this.tbxPhoneNumber2.MaxLength = 11;
      this.tbxPhoneNumber2.Name = "tbxPhoneNumber2";
      this.tbxPhoneNumber2.Size = new Size(352, 22);
      this.tbxPhoneNumber2.TabIndex = 5;
      this.tbxPhoneNumber2.KeyPress += new KeyPressEventHandler(this.tbxPhoneNumber2_KeyPress);
      this.tbxPhoneNumber2.KeyUp += new KeyEventHandler(this.tbxBankCode_KeyUp);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(58, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(85, 16);
      this.label1.TabIndex = 14;
      this.label1.Text = "BANK CODE";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(57, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 16);
      this.label2.TabIndex = 13;
      this.label2.Text = "BANK NAME";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(78, 68);
      this.label3.Name = "label3";
      this.label3.Size = new Size(65, 16);
      this.label3.TabIndex = 12;
      this.label3.Text = "BRANCH";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(65, 91);
      this.label4.Name = "label4";
      this.label4.Size = new Size(78, 16);
      this.label4.TabIndex = 11;
      this.label4.Text = "IFSC CODE";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(15, 121);
      this.label5.Name = "label5";
      this.label5.Size = new Size(128, 16);
      this.label5.TabIndex = 10;
      this.label5.Text = "PHONE NUMBER 1";
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(18, 147);
      this.label6.Name = "label6";
      this.label6.Size = new Size(125, 16);
      this.label6.TabIndex = 9;
      this.label6.Text = "PHONE NUMBER2";
      this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[2]
      {
        (object) "BANK",
        (object) "KHAATHO"
      });
      this.cbType.Location = new Point(149, 170);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(209, 32);
      this.cbType.TabIndex = 6;
      this.cbType.KeyDown += new KeyEventHandler(this.cbType_KeyDown);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(99, 175);
      this.label7.Name = "label7";
      this.label7.Size = new Size(44, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "TYPE";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(23, 65);
      this.label8.Name = "label8";
      this.label8.Size = new Size(116, 16);
      this.label8.TabIndex = 19;
      this.label8.Text = "VOUCHER CODE";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(23, 17);
      this.label9.Name = "label9";
      this.label9.Size = new Size(104, 16);
      this.label9.TabIndex = 18;
      this.label9.Text = "LEDGER CODE";
      this.tbxVoucherName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherName.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherName.Location = new Point(134, 85);
      this.tbxVoucherName.MaxLength = 11;
      this.tbxVoucherName.Name = "tbxVoucherName";
      this.tbxVoucherName.Size = new Size(310, 22);
      this.tbxVoucherName.TabIndex = 17;
      this.tbxVoucherName.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(66, 38);
      this.tbxLedgerCode.MaxLength = 11;
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.Size = new Size(62, 22);
      this.tbxLedgerCode.TabIndex = 16;
      this.tbxLedgerCode.Text = "B2";
      this.tbxLedgerCode.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCode.Location = new Point(66, 86);
      this.tbxVoucherCode.MaxLength = 11;
      this.tbxVoucherCode.Name = "tbxVoucherCode";
      this.tbxVoucherCode.Size = new Size(62, 22);
      this.tbxVoucherCode.TabIndex = 20;
      this.tbxVoucherCode.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerType.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerType.Location = new Point(134, 37);
      this.tbxLedgerType.MaxLength = 11;
      this.tbxLedgerType.Name = "tbxLedgerType";
      this.tbxLedgerType.Size = new Size(310, 22);
      this.tbxLedgerType.TabIndex = 22;
      this.tbxLedgerType.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerTypeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerTypeInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInterest.Location = new Point(134, 135);
      this.tbxLedgerTypeInterest.MaxLength = 11;
      this.tbxLedgerTypeInterest.Name = "tbxLedgerTypeInterest";
      this.tbxLedgerTypeInterest.Size = new Size(310, 22);
      this.tbxLedgerTypeInterest.TabIndex = 28;
      this.tbxLedgerTypeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxVoucherCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherCodeInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherCodeInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherCodeInterest.Location = new Point(66, 182);
      this.tbxVoucherCodeInterest.MaxLength = 11;
      this.tbxVoucherCodeInterest.Name = "tbxVoucherCodeInterest";
      this.tbxVoucherCodeInterest.Size = new Size(62, 22);
      this.tbxVoucherCodeInterest.TabIndex = 27;
      this.tbxVoucherCodeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(23, 161);
      this.label10.Name = "label10";
      this.label10.Size = new Size(141, 16);
      this.label10.TabIndex = 26;
      this.label10.Text = "VOUCHER CODE INT";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(23, 113);
      this.label11.Name = "label11";
      this.label11.Size = new Size(132, 16);
      this.label11.TabIndex = 25;
      this.label11.Text = "LEDGER  CODE INT";
      this.tbxVoucherNameInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxVoucherNameInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxVoucherNameInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxVoucherNameInterest.Location = new Point(134, 182);
      this.tbxVoucherNameInterest.MaxLength = 11;
      this.tbxVoucherNameInterest.Name = "tbxVoucherNameInterest";
      this.tbxVoucherNameInterest.Size = new Size(310, 22);
      this.tbxVoucherNameInterest.TabIndex = 24;
      this.tbxVoucherNameInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tbxLedgerCodeInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCodeInterest.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCodeInterest.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCodeInterest.Location = new Point(66, 134);
      this.tbxLedgerCodeInterest.MaxLength = 11;
      this.tbxLedgerCodeInterest.Name = "tbxLedgerCodeInterest";
      this.tbxLedgerCodeInterest.Size = new Size(62, 22);
      this.tbxLedgerCodeInterest.TabIndex = 23;
      this.tbxLedgerCodeInterest.Text = "B1";
      this.tbxLedgerCodeInterest.KeyPress += new KeyPressEventHandler(this.tbxLedgerType_KeyPress);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.169934f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.83006f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 29;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label12);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1002, 45);
      this.panel2.TabIndex = 9;
      this.label12.Anchor = AnchorStyles.None;
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.Black;
      this.label12.Location = new Point(417, 8);
      this.label12.Name = "label12";
      this.label12.Size = new Size(184, 29);
      this.label12.TabIndex = 10;
      this.label12.Text = "BANK MASTER";
      this.label12.Click += new EventHandler(this.label12_Click);
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 54);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1002, 575);
      this.panel3.TabIndex = 11;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel1.CaptionEndColor = Color.Azure;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "VOUCHER AND LEDGER CODE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxLedgerType);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxLedgerCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxLedgerTypeInterest);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxVoucherName);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxVoucherCodeInterest);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label9);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label10);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label8);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label11);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxVoucherCode);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxVoucherNameInterest);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxLedgerCodeInterest);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = Color.MintCream;
      this.headerPanel1.GradientStart = Color.Azure;
      ((Control) this.headerPanel1).Location = new Point(532, 316);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(460, 249);
      ((Control) this.headerPanel1).TabIndex = 34;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SkyBlue;
      this.headerPanel2.CaptionEndColor = Color.Azure;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "BANK DETAILS";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.btnAddEdit);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBankCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label7);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBankName);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbType);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label6);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxBranch);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxIfscCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxPhoneNumber2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxPhoneNumber1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = Color.MintCream;
      this.headerPanel2.GradientStart = Color.Azure;
      ((Control) this.headerPanel2).Location = new Point(8, 316);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(518, 249);
      ((Control) this.headerPanel2).TabIndex = 0;
      this.headerPanel2.TextAntialias = true;
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(364, 170);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(137, 33);
      ((Control) this.btnAddEdit).TabIndex = 7;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormBankMaster);
      this.Text = "BankMaster";
      this.Load += new EventHandler(this.BankMaster_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
