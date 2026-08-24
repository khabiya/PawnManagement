

using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormSearchCustomer : Form
  {
    private ReportDocument rd = new ReportDocument();
    private DataTable dt = new DataTable();
    private string filterBy = "ALL";
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private bool flag = true;
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem callToolStripMenuItem;
    private ToolStripMenuItem sendSmsToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private DataGridViewImageColumn Photo;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private TextBox tbxSearch;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private ToolStripMenuItem deleteCustomerToolStripMenuItem;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton1;
    private GlassButton glassButton6;
    private ComboBox comboBox1;
    private GlassButton glassButton7;
    private GlassButton glassButton5;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel2;
    private ComboBox cbFilterBy;
    private ComboBox cbSearchBasedOn;
    private TextBox textBox1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private GlassButton glassButton8;

    public FormSearchCustomer() => this.InitializeComponent();

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void textBox2_TextChanged(object sender, EventArgs e) => this.refreshGrid();

    private void refreshGrid()
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string str = !(this.filterBy == "PENDING") ? (!(this.filterBy == "NO PENDING JEWELS BUT REDEEMED JEWELS THERE") ? (!(this.filterBy == "NO PLEDGE ENTRY") ? "select *  from tblcustomers order by cname" : "SELECT cid, cname, cno, cphone, ccell, caddr1, caddr2, caddr3, ccity, cpincode, cintroducer, caadharnumber, cotherproof, crationcard, cemail, cnotes,cinterestrate,cimagepath FROM tblcustomers AS c WHERE NOT EXISTS(SELECT 1 FROM   tblPledge p   WHERE  c.Cid = p.customercode)") : "  SELECT * FROM tblcustomers WHERE CID IN(select distinct customerCode as cid from tblpledge) order by cname") : " SELECT * FROM tblcustomers WHERE CID IN(select distinct customerCode as cid from tblpledge where redeemed = 'N' ) order by cname";
      string my_querry;
      if (this.cbSearchBasedOn.Text == "CUSTOMER CODE")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where Cid like @Cid";
        parameters.Add(new OleDbParameter("Cid", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "CUSTOMER NAME")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CName like @name";
        parameters.Add(new OleDbParameter("CName", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "DOOR NUMBER")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CNo like @CNo";
        parameters.Add(new OleDbParameter("CNo", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "ADDRESS1")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where  CAddr1 like @CAddr1";
        parameters.Add(new OleDbParameter("CAddr1", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "ADDRESS2")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CAddr2 like @CAddr2";
        parameters.Add(new OleDbParameter("CAddr2", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "LOCATION")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CAddr3 like @CAddr3";
        parameters.Add(new OleDbParameter("CAddr3", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "CITY")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CName like  CCity like @CCity";
        parameters.Add(new OleDbParameter("CCity", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "PINCODE")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where  CPinCode like @CPinCode";
        parameters.Add(new OleDbParameter("CPincode", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "MOBILE NUMBER")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CPhone like @CPhone ";
        parameters.Add(new OleDbParameter("CPhone", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "ALTERNATE NUMBER")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where  CCell like @CCell ";
        parameters.Add(new OleDbParameter("CCell", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "NOTES")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CNotes like @CNotes";
        parameters.Add(new OleDbParameter("CNotes", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "AADHAR NUMBER")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CAadharNumber like @CAadharNumber";
        parameters.Add(new OleDbParameter("CAadharNumber", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "EMAIL ID")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CEmail like @Email";
        parameters.Add(new OleDbParameter("CEmail", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else if (this.cbSearchBasedOn.Text == "RATION CARD")
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CRationCard like @CRationCard";
        parameters.Add(new OleDbParameter("CRationCard", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      else
      {
        my_querry = "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cinterestrate,cemail,cimagepath,cnotes from ( " + str + " ) where CName like @CName or CId like @CId or CPhone like @CPhone or CCell like @CCell or CAddr1 like @CAddr1 or CAddr2 like @CAddr2 or CAddr3 like @CAddr3 or CCity like @CCity or CPinCode like @CPinCode  or  CNotes like @CNotes  or CAadharNumber like @CAadharNumber or CEmail like @Email  or CRationCard like @CRationCard ";
        parameters.Add(new OleDbParameter("CName", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CId", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CPhone", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CCell", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CAddr1", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CAddr2", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CAddr3", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CCity", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CPinCode", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CNotes", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CAadharNumber", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CEmail", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
        parameters.Add(new OleDbParameter("CRation", (object) ("%" + this.tbxSearch.Text.ToString() + "%")));
      }
      this.dt = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form searchCustomer textbox2_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dt;
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void SearchCustomer_Load(object sender, EventArgs e)
    {
      this.flag = false;
      this.dataGridView1.RowTemplate.Height = 22;
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
      this.tbxSearch.Select();
      this.refreshGrid();
      this.getPledgeReportTypes();
      if (this.comboBox1.Items.Count <= 0)
        return;
      this.comboBox1.SelectedIndex = 0;
    }

    private void getPledgeReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\IdCards\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.dataGridView1.Select();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void dataGridView1_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      this.dataGridView1.Columns[0].Visible = false;
      this.textBox1.Text = this.dataGridView1.Rows.Count.ToString();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.flag)
      {
        this.dataGridView1.Columns[0].Visible = false;
        this.dataGridView1.RowTemplate.Height = 22;
        this.refreshGrid();
        this.flag = false;
      }
      else
      {
        this.dataGridView1.Columns[0].Visible = true;
        this.dataGridView1.RowTemplate.Height = 200;
        this.refreshGrid();
        this.flag = true;
      }
    }

    private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell.RowIndex <= -1)
        return;
      FormViewCustomerDetails viewCustomerDetails = new FormViewCustomerDetails(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cid"].Value.ToString());
      viewCustomerDetails.MdiParent = this.MdiParent;
      viewCustomerDetails.Show();
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell.RowIndex <= -1)
        return;
      int num = (int) new FormEditCustomer(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cid"].Value.ToString()).ShowDialog();
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      int index = 0;
      if (this.dataGridView1.CurrentRow != null)
        index = this.dataGridView1.CurrentRow.Index;
      string customerCodeForEditing = this.dataGridView1.Rows[index].Cells["CID"].Value.ToString();
      if (customerCodeForEditing != "")
      {
        this.Close();
        Form1 form1 = new Form1("EDIT", customerCodeForEditing);
        if (FormMain.UseFingerPrint && FormMain.m_FPM != null)
        {
          if (FormMain.AutoOnfingerPrint)
            FormMain.m_FPM.EnableAutoOnEvent(true, (int) form1.Handle);
          else
            FormMain.m_FPM.EnableAutoOnEvent(false, 0);
        }
        int num = (int) form1.ShowDialog();
      }
    }

    private void callToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      string str = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["CPhone"].Value.ToString();
      if (str != "" && PawnManagementClass.IsDigitsOnly(str) && str.Count<char>() == 10)
      {
        int num1 = (int) new FormCall(str.ToString()).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void sendSmsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      FieldToBind.Add("cid");
      FieldToBind.Add("CPhone");
      FieldToBind.Add("CName");
      DataTable dtCustomers = this.getdatatabledtdata(this.dt);
      formSendSms.LoadNotice(dtCustomers, "cid", "CPhone", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
      this.refreshGrid();
    }

    private DataTable getdatatabledtdata(DataTable dt2)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = dt2;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
      {
        if (row["cphone"].ToString().Length != 10 || !this.IsDigitsOnly(row["cphone"].ToString()))
          row.Delete();
      }
      return dataTable2;
    }

    private bool IsDigitsOnly(string str)
    {
      if (str == "")
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
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

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Customer Details").ShowDialog();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Select();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Select();
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void newPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || !(this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CID"))
        return;
      string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Cid"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
    }

    private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      string str = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cid"].Value.ToString();
      if (this.checkifCustomerIdIsNotUsedInPledgeTable(str) | this.checkifCustomerIdIsNotUsedInRedemptionTable(str))
      {
        int num = (int) MessageBox.Show("Cannot Deleete.Customer Id is in use");
      }
      else if (DialogResult.Yes == MessageBox.Show("Delete the duplicate customer  - " + str, "Delete Duplicate Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
      {
        this.deleteDupplicateCustomer(str);
        this.refreshGrid();
      }
    }

    private void deleteDupplicateCustomer(string CustomerCode)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Delete from tblCustomers where CId = @CustomerCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (CustomerCode), (object) CustomerCode)
      }, ref strError) == "Done"))
        return;
      if (File.Exists(FormMain.startUpPath + "Photos\\" + CustomerCode + ".png"))
        File.Delete(FormMain.startUpPath + "Photos\\" + CustomerCode + ".png");
      int num = (int) MessageBox.Show("Customer Successfully deleted");
      PawnManagementClass.InsertIntoHistory("Customer Delete", "Customer " + CustomerCode + " delete", "", "", FormMain.username, DateTime.Now.ToString());
    }

    private bool checkifCustomerIdIsNotUsedInPledgeTable(string CustomerId)
    {
      string strError = "";
      string my_querry = "select * from tblPledge where customercode = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) CustomerId));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    private bool checkifCustomerIdIsNotUsedInRedemptionTable(string CustomerId)
    {
      string strError = "";
      string my_querry = "select * from tblRedemption where customercode = @Cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Cid", (object) CustomerId));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    private void glassButton7_Click(object sender, EventArgs e)
    {
      this.rd.Load(this.comboBox1.Text);
      this.rd.SetDataSource(this.dt);
      int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
    }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].Name == "CID")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
    }

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Up || !this.dataGridView1.Rows[0].Selected)
          return;
        this.tbxSearch.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.dgvCustomerDetails_KeyDown", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void cbFilterBy_SelectedValueChanged(object sender, EventArgs e)
    {
      this.filterBy = this.cbFilterBy.Text.Trim();
      this.refreshGrid();
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

    private void glassButton8_Click(object sender, EventArgs e)
    {
      this.rd.Load(this.comboBox1.Text);
      this.rd.SetDataSource(this.dt);
      int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
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
      this.Photo = new DataGridViewImageColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.callToolStripMenuItem = new ToolStripMenuItem();
      this.sendSmsToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.deleteCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.tbxSearch = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.cbSearchBasedOn = new ComboBox();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.glassButton7 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.cbFilterBy = new ComboBox();
      this.textBox1 = new TextBox();
      this.glassButton8 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.BackgroundColor = Color.White;
      this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.ColumnHeadersHeight = 40;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.Photo);
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.GridColor = Color.LightGray;
      this.dataGridView1.Location = new Point(6, 58);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowTemplate.Height = 200;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1005, 544);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.dataGridView1.KeyUp += new KeyEventHandler(this.dataGridView1_KeyUp);
      this.Photo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.Photo.FillWeight = 50f;
      this.Photo.HeaderText = "Photo";
      this.Photo.ImageLayout = DataGridViewImageCellLayout.Stretch;
      this.Photo.Name = "Photo";
      this.Photo.ReadOnly = true;
      this.Photo.Visible = false;
      this.Photo.Width = 200;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.editToolStripMenuItem,
        (ToolStripItem) this.callToolStripMenuItem,
        (ToolStripItem) this.sendSmsToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.deleteCustomerToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 202);
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(194, 22);
      this.editToolStripMenuItem.Text = "Edit Customer Details";
      this.editToolStripMenuItem.Click += new EventHandler(this.editToolStripMenuItem_Click);
      this.callToolStripMenuItem.Name = "callToolStripMenuItem";
      this.callToolStripMenuItem.Size = new Size(194, 22);
      this.callToolStripMenuItem.Text = "Call";
      this.callToolStripMenuItem.Click += new EventHandler(this.callToolStripMenuItem_Click);
      this.sendSmsToolStripMenuItem.Name = "sendSmsToolStripMenuItem";
      this.sendSmsToolStripMenuItem.Size = new Size(194, 22);
      this.sendSmsToolStripMenuItem.Text = "Send Sms";
      this.sendSmsToolStripMenuItem.Click += new EventHandler(this.sendSmsToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
      this.deleteCustomerToolStripMenuItem.Size = new Size(194, 22);
      this.deleteCustomerToolStripMenuItem.Text = "Delete Customer";
      this.deleteCustomerToolStripMenuItem.Click += new EventHandler(this.deleteCustomerToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "SEARCH";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxSearch);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(177, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(166, 50);
      ((Control) this.headerPanel7).TabIndex = 78;
      this.headerPanel7.TextAntialias = true;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      ((ButtonBase) this.glassButton12).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(-131, 513);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(128, 35);
      ((Control) this.glassButton12).TabIndex = 0;
      ((Control) this.glassButton12).Text = "&SAVE";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(3, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSearch.BackColor = Color.AliceBlue;
      this.tbxSearch.BorderStyle = BorderStyle.None;
      this.tbxSearch.Dock = DockStyle.Fill;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(0, 0);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(164, 24);
      this.tbxSearch.TabIndex = 26;
      this.tbxSearch.TextAlign = HorizontalAlignment.Center;
      this.tbxSearch.TextChanged += new EventHandler(this.textBox2_TextChanged);
      this.tbxSearch.KeyDown += new KeyEventHandler(this.textBox2_KeyDown);
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "SEARCH BASED ON";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbSearchBasedOn);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(6, 4);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(165, 50);
      ((Control) this.headerPanel1).TabIndex = 79;
      this.headerPanel1.TextAntialias = true;
      this.cbSearchBasedOn.BackColor = Color.AliceBlue;
      this.cbSearchBasedOn.Dock = DockStyle.Fill;
      this.cbSearchBasedOn.FormattingEnabled = true;
      this.cbSearchBasedOn.Items.AddRange(new object[15]
      {
        (object) "CUSTOMER CODE",
        (object) "CUSTOMER NAME",
        (object) "DOOR NUMBER",
        (object) "ADDRESS1",
        (object) "ADDRESS2",
        (object) "LOCATION",
        (object) "CITY",
        (object) "PINCODE",
        (object) "MOBILE NUMBER",
        (object) "ALTERNATE NUMBER",
        (object) "NOTES",
        (object) "AADHAR NUMBER",
        (object) "EMAIL ID",
        (object) "RATION CARD",
        (object) "OTHER PROOF"
      });
      this.cbSearchBasedOn.Location = new Point(0, 0);
      this.cbSearchBasedOn.Name = "cbSearchBasedOn";
      this.cbSearchBasedOn.Size = new Size(163, 23);
      this.cbSearchBasedOn.TabIndex = 3;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(-134, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(0, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel3.CaptionEndColor = Color.AliceBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "PRINT";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(611, 4);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(400, 50);
      ((Control) this.headerPanel3).TabIndex = 80;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(107, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(241, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(2, 2);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(328, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(332, 3);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(61, 21);
      ((Control) this.glassButton7).TabIndex = 24;
      ((Control) this.glassButton7).Text = "&PRINT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Click += new EventHandler(this.glassButton7_Click);
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(90, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      ((ButtonBase) this.glassButton4).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(-44, 513);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(128, 35);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&SAVE";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "FILTER";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbFilterBy);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(349, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(257, 50);
      ((Control) this.headerPanel2).TabIndex = 79;
      this.headerPanel2.TextAntialias = true;
      this.cbFilterBy.BackColor = Color.AliceBlue;
      this.cbFilterBy.Dock = DockStyle.Fill;
      this.cbFilterBy.FormattingEnabled = true;
      this.cbFilterBy.Items.AddRange(new object[4]
      {
        (object) "ALL",
        (object) "PENDING",
        (object) "NO PENDING JEWELS BUT REDEEMED JEWELS THERE",
        (object) "NO PLEDGE ENTRY"
      });
      this.cbFilterBy.Location = new Point(0, 0);
      this.cbFilterBy.Name = "cbFilterBy";
      this.cbFilterBy.Size = new Size((int) byte.MaxValue, 23);
      this.cbFilterBy.TabIndex = 2;
      this.cbFilterBy.SelectedValueChanged += new EventHandler(this.cbFilterBy_SelectedValueChanged);
      this.textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.textBox1.Location = new Point(911, 582);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 81;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(944, 73);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(61, 21);
      ((Control) this.glassButton8).TabIndex = 25;
      ((Control) this.glassButton8).Text = "&PRINT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton8).Click += new EventHandler(this.glassButton8_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1019, 612);
      this.Controls.Add((Control) this.glassButton8);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormSearchCustomer);
      this.Text = "SearchCustomer";
      this.Load += new EventHandler(this.SearchCustomer_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
