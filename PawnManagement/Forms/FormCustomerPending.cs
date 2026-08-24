
using ExportToExcel11;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormCustomerPending : Form
  {
    private DataTable dt = new DataTable();
    private string filterBy = "ALL";
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
    private Label label2;
    private ComboBox cbFilterBy;
    private Label label3;
    private TextBox textBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem callToolStripMenuItem;
    private ToolStripMenuItem sendSmsToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem deleteCustomerToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormCustomerPending() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private DataTable getdatatabledtdata(DataTable dt2)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = dt2;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
      {
        if (row["cphone"].ToString().Length != 10 || !FormCustomerPending.IsDigitsOnly(row["cphone"].ToString()))
          row.Delete();
      }
      return dataTable2;
    }

    private void FormCustomerPending_Load(object sender, EventArgs e) => this.refreshGrid();

    public static bool IsDigitsOnly(string str)
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

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void refreshGrid()
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable = SQLHelper.GetDataTable(!(this.filterBy == "PENDING") ? (!(this.filterBy == "NO PENDING JEWELS BUT REDEEMED JEWELS THERE") ? (!(this.filterBy == "NO PLEDGE ENTRY") ? "select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cemail,cnotes from tblcustomers order by cname" : " SELECT  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cemail,cnotes FROM tblcustomers AS c WHERE NOT EXISTS (SELECT 1 FROM   tblPledge p   WHERE  c.Cid = p.customercode);") : "  select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cemail,cnotes from tblcustomers WHERE CID IN(select distinct customerCode as cid from tblpledge) order by cname") : " select  cid,cname,cno,cphone,ccell,caddr1,caddr2,caddr3,ccity,cpincode,cintroducer,caadharnumber,cotherproof,crationcard,cemail,cnotes from tblcustomers WHERE CID IN(select distinct customerCode as cid from tblpledge where redeemed = 'N' ) order by cname", parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form searchCustomer textbox2_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable;
    }

    private void cbFilterBy_SelectedValueChanged(object sender, EventArgs e)
    {
      this.filterBy = this.cbFilterBy.Text.Trim();
      this.refreshGrid();
    }

    private void dataGridView1_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      this.textBox1.Text = this.dataGridView1.Rows.Count.ToString();
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell.RowIndex <= -1)
        return;
      int num = (int) new FormEditCustomer(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cid"].Value.ToString()).ShowDialog();
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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Customer Details").ShowDialog();
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
      int num = (int) MessageBox.Show("Customer Successfully deleted");
      PawnManagementClass.InsertIntoHistory("Customer Delete", "Customer " + CustomerCode + " delete", "", "", FormMain.username, DateTime.Now.ToString());
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
      this.panel1 = new Panel();
      this.label2 = new Label();
      this.cbFilterBy = new ComboBox();
      this.label1 = new Label();
      this.panel2 = new Panel();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.callToolStripMenuItem = new ToolStripMenuItem();
      this.sendSmsToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.deleteCustomerToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.BackgroundColor = Color.White;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeight = 35;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1080, 469);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.cbFilterBy);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(8, 6);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1081, 40);
      this.panel1.TabIndex = 7;
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(481, 12);
      this.label2.Name = "label2";
      this.label2.Size = new Size(84, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "FILTER BY";
      this.cbFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbFilterBy.BackColor = Color.AliceBlue;
      this.cbFilterBy.FormattingEnabled = true;
      this.cbFilterBy.Items.AddRange(new object[4]
      {
        (object) "ALL",
        (object) "PENDING",
        (object) "NO PENDING JEWELS BUT REDEEMED JEWELS THERE",
        (object) "NO PLEDGE ENTRY"
      });
      this.cbFilterBy.Location = new Point(571, 9);
      this.cbFilterBy.Name = "cbFilterBy";
      this.cbFilterBy.Size = new Size(257, 21);
      this.cbFilterBy.TabIndex = 2;
      this.cbFilterBy.SelectedValueChanged += new EventHandler(this.cbFilterBy_SelectedValueChanged);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(4, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size((int) byte.MaxValue, 25);
      this.label1.TabIndex = 1;
      this.label1.Text = "CUSTOMER REPORTS";
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Location = new Point(8, 44);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1082, 471);
      this.panel2.TabIndex = 8;
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.textBox1.Location = new Point(976, 9);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 82;
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(838, 12);
      this.label3.Name = "label3";
      this.label3.Size = new Size(132, 16);
      this.label3.TabIndex = 83;
      this.label3.Text = "NO OF RECORDS";
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
      this.contextMenuStrip1.Size = new Size(195, 180);
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
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1097, 521);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.Name = nameof (FormCustomerPending);
      this.Text = nameof (FormCustomerPending);
      this.Load += new EventHandler(this.FormCustomerPending_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
