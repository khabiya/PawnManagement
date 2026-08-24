

using CSharpCustomPanelControl;
using ExportToExcel11;
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormVoucherMaster : Form
  {
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private DataTable dtrefreshGrid = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private TextBox tbxSearch;
    private Label label2;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label lblHeading;
    private Panel panel1;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem viewFuToolStripMenuItem;
    private CustomPanel customPanel1;
    private GlassButton btnAdd;
    private ToolStripMenuItem aDDToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    private void FormVoucherMaster_Load(object sender, EventArgs e)
    {
      try
      {
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        this.dataGridView1.BackgroundColor = Color.AliceBlue;
        this.dataGridView1.GridColor = Color.CornflowerBlue;
        this.dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
        this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
        this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.refreshGrid();
        if (!(FormMain.memberid == "1"))
          return;
        this.dELETEToolStripMenuItem.Visible = true;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster.formvouchermaster_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public FormVoucherMaster() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select VoucherCode,VoucherName,LedgerType,CreatedOn from tblVoucherMaster", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form tblVoucherMaster.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching data from table voucherMaster.\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dtrefreshGrid;
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

    private void viewFuToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Voucher Master").ShowDialog();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormVoucherAddEdit().ShowDialog();
      this.refreshGrid();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select  * from tblvoucherMaster where vouchercode like @vouchercode or vouchername like @vouchername  or ledgercode like @ledgercode or  ledgertype  like @LedgerType";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("vouchercode", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("vouchername", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("ledgercode", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("ledgername", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form voucherMaster.textBox2_textchanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in searchding and retrieving..." + strError);
        }
        else
          this.dataGridView1.DataSource = (object) dataTable2;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster.textbox2_textchanged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAdd_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Up)
        return;
      this.dataGridView1.Select();
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (!VoucherMasterClass.checkIfVoucherCodeIsUsed(this.dataGridView1.Rows[rowIndex].Cells["VoucherCode"].Value.ToString()))
        {
          if (DialogResult.Yes == MessageBox.Show("Are you sure ......Cannot Be Undone???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
          {
            string strError = "";
            DateTime now;
            if (SQLHelper.RunCommand("Delete from tblVoucherMaster where VoucherCode =@VoucherCode", new List<OleDbParameter>()
            {
              new OleDbParameter("VoucherCode", (object) this.dataGridView1.Rows[rowIndex].Cells["Vouchercode"].Value.ToString())
            }, ref strError) != "Done")
            {
              int num = (int) MessageBox.Show("Error in deleting voucher Code" + strError);
              string MessageAnDStackTrace = strError;
              string username = FormMain.username;
              now = DateTime.Now;
              string CreatedOn = now.ToString();
              PawnManagementClass.InsertIntoException("form vouchermaster.Error in deleting voucherCode", MessageAnDStackTrace, username, CreatedOn);
            }
            string ActionDetails = "VOUCHER CODE" + this.dataGridView1.Rows[rowIndex].Cells["VOUCHERCODE"].Value.ToString() + "deleted";
            string username1 = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER CODE DELETED", ActionDetails, "", "", username1, PerformedOn);
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("VOUCHER CODE Already in Use...Cannot be deleted");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster.dELETEToolsstripmenuitemclick", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          string VOUCHERNAME = this.dataGridView1.Rows[rowIndex].Cells["VoucherName"].Value.ToString();
          string str = this.dataGridView1.Rows[rowIndex].Cells["LedgerType"].Value.ToString();
          string VOUCHERCODE = this.dataGridView1.Rows[rowIndex].Cells["VoucherCode"].Value.ToString();
          string LEDGERCODE = LedgerMaster.getledgerCode(str);
          int num = (int) new FormVoucherAddEdit(VOUCHERCODE, VOUCHERNAME, LEDGERCODE, str, "EDIT").ShowDialog();
          this.refreshGrid();
        }
        else
        {
          int num1 = (int) MessageBox.Show("Table is empty");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form vouchermaster.edittoolsstripmenuitemclick", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormVoucherAddEdit().ShowDialog();
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
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.aDDToolStripMenuItem = new ToolStripMenuItem();
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFuToolStripMenuItem = new ToolStripMenuItem();
      this.tbxSearch = new TextBox();
      this.label2 = new Label();
      this.lblHeading = new Label();
      this.panel1 = new Panel();
      this.customPanel1 = new CustomPanel();
      this.btnAdd = new GlassButton();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((Control) this.customPanel1).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(997, 589);
      this.dataGridView1.TabIndex = 1;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.aDDToolStripMenuItem,
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFuToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 180);
      this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
      this.aDDToolStripMenuItem.Size = new Size(194, 22);
      this.aDDToolStripMenuItem.Text = "ADD";
      this.aDDToolStripMenuItem.Click += new EventHandler(this.aDDToolStripMenuItem_Click);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Visible = false;
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFuToolStripMenuItem.Name = "viewFuToolStripMenuItem";
      this.viewFuToolStripMenuItem.Size = new Size(194, 22);
      this.viewFuToolStripMenuItem.Text = "View full Screen";
      this.viewFuToolStripMenuItem.Click += new EventHandler(this.viewFuToolStripMenuItem_Click);
      this.tbxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.tbxSearch.BackColor = Color.AliceBlue;
      this.tbxSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSearch.CharacterCasing = CharacterCasing.Upper;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(668, 5);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(286, 31);
      this.tbxSearch.TabIndex = 3;
      this.tbxSearch.TextChanged += new EventHandler(this.textBox2_TextChanged);
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(584, 8);
      this.label2.Name = "label2";
      this.label2.Size = new Size(80, 25);
      this.label2.TabIndex = 9;
      this.label2.Text = "Search";
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Algerian", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.Black;
      this.lblHeading.Location = new Point(4, 7);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(215, 26);
      this.lblHeading.TabIndex = 10;
      this.lblHeading.Text = "VOUCHER MASTER";
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackColor = Color.MintCream;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.dataGridView1);
      this.panel1.Location = new Point(5, 44);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(999, 591);
      this.panel1.TabIndex = 13;
      ((Control) this.customPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.customPanel1.BackColor = Color.LightCyan;
      this.customPanel1.BackColor2 = Color.MintCream;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.btnAdd);
      ((Control) this.customPanel1).Controls.Add((Control) this.lblHeading);
      ((Control) this.customPanel1).Controls.Add((Control) this.tbxSearch);
      ((Control) this.customPanel1).Controls.Add((Control) this.label2);
      this.customPanel1.Curvature = 3;
      this.customPanel1.CurveMode = CornerCurveMode.TopLeft_TopRight;
      this.customPanel1.GradientMode = LinearGradientMode.Vertical;
      ((Control) this.customPanel1).Location = new Point(5, 2);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(999, 66);
      ((Control) this.customPanel1).TabIndex = 2;
      ((Control) this.btnAdd).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.BackColor = Color.AliceBlue;
      this.btnAdd.FadeOnFocus = true;
      ((Control) this.btnAdd).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAdd.ForeColor = SystemColors.ControlText;
      this.btnAdd.ForeColorOnFocus = Color.Red;
      this.btnAdd.ForeColorOnLeave = SystemColors.ControlText;
      this.btnAdd.GlowColor = Color.AliceBlue;
      ((ButtonBase) this.btnAdd).Image = (Image) PawnManagement.Properties.Resources.plus;
      this.btnAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAdd).Location = new Point(958, 4);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.AliceBlue;
      ((Control) this.btnAdd).Size = new Size(36, 33);
      ((Control) this.btnAdd).TabIndex = 11;
      ((ButtonBase) this.btnAdd).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAdd).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAdd).Click += new EventHandler(this.btnAdd_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.customPanel1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormVoucherMaster);
      this.Text = nameof (FormVoucherMaster);
      this.Load += new EventHandler(this.FormVoucherMaster_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
