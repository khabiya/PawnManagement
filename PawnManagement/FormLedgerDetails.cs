

using CSharpCustomPanelControl;
using ExportToExcel11;
using Glass;
using PawnManagement.Properties;
using Rokad.FORMS;
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
  public class FormLedgerDetails : Form
  {
    private string oldLedgerType = "";
    private DataTable dtrefreshGrid = new DataTable();
    private IContainer components = (IContainer) null;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private Panel panel1;
    private GlassButton btnAddArticles;
    private GlassButton btnDeleteArticles;
    private GlassButton glassButton1;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn colSerialNumber;
    private DataGridViewComboBoxColumn colType;
    private DataGridViewTextBoxColumn colAmount;
    private DataGridViewTextBoxColumn colCd;
    private DataGridViewTextBoxColumn colGrossWeight;
    private DataGridViewTextBoxColumn colTouch;
    private DataGridViewTextBoxColumn colRate;
    private DataGridViewTextBoxColumn colTotal;
    private CustomPanel customPanel1;
    private PictureBox pictureBox1;
    private TextBox tbxSearch;
    private CustomPanel customPanel3;
    private PictureBox pbAdd;
    private PictureBox pbEdit;
    private PictureBox pbDelete;
    private Label label1;
    private PictureBox pbSearch;
    private ToolStripMenuItem exportToExcelOptionToolStripMenuItem;

    public FormLedgerDetails() => this.InitializeComponent();

    private void FormLedgerDetails_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.refreshGrid();
      this.dELETEToolStripMenuItem.Visible = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.tbxSearch.Select();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public static string getLedgerName(string ledgerCode)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerCode = @LedgerCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("LedgerCode", (object) ledgerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form getledgername", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getledgername" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["ledgertype"].ToString();
      return "";
    }

    private void refreshGrid()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select LedgerCode,JammaOrNovae,LedgerTypeInHindi,LedgerType,Deletable,ID from tblLedgerr", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  ledgerDetails.refreshgrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("refreshGrid() Error in fetching the ledgerr details .\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dtrefreshGrid;
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private bool checkifLedgerTypeAlreadyExists(string LedgerType)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerType = @LedgerType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (LedgerType), (object) LedgerType)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form  ledgerDetails..checkifledgetypealreadyExists \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
    }

    private string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["ledgerCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
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
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Ledger Details").ShowDialog();
    }

    private void btnAddArticles_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLedgerMasterAddUpdate("").ShowDialog();
      this.refreshGrid();
    }

    private void btnDeleteArticles_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count < 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (!this.dataGridView1.Rows[rowIndex].Cells["Deletable"].Value.ToString().Equals("N"))
        {
          if (DialogResult.Yes == MessageBox.Show("Are you sure ..???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
          {
            string strError = "";
            if (SQLHelper.RunCommand("Delete from tblLedgerr where ID =@ID", new List<OleDbParameter>()
            {
              new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString())
            }, ref strError) != "Done")
            {
              int num = (int) MessageBox.Show("Error in deleting tblLedgerr" + strError);
            }
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("You cannot delete these DEFAULT Ledger type..");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form ledgerdetails.deleteToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void label9_Click(object sender, EventArgs e) => this.Close();

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.FromKnownColor(KnownColor.GradientInactiveCaption), Color.AliceBlue, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string strError = "";
        string my_querry = "select  * from tblLedgerr where LedgerCode like @LedgerCode or LedgerType like @LedgerType";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("LedgerCode", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("LedgerType", (object) ("%" + this.tbxSearch.Text.Trim().ToString() + "%")));
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

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex <= 0)
        return;
      int num = (int) new FormLedgerMasterAddUpdate(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["LedgerCode"].Value.ToString()).ShowDialog();
      this.refreshGrid();
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLedgerMasterAddUpdate("").ShowDialog();
      this.refreshGrid();
    }

    private void pictureBox2_MouseEnter(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\add.png"))
        return;
      this.pbAdd.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\add.png");
    }

    private void pictureBox2_MouseLeave(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\addunselected.png"))
        return;
      this.pbAdd.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\addunselected.png");
    }

    private void pbEdit_MouseEnter(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\edit.png"))
        return;
      this.pbEdit.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\edit.png");
    }

    private void pbEdit_MouseLeave(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\editunselected.png"))
        return;
      this.pbEdit.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\editunselected.png");
    }

    private void pbDelete_MouseEnter(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\delete.png"))
        return;
      this.pbDelete.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\delete.png");
    }

    private void pbDelete_MouseLeave(object sender, EventArgs e)
    {
      if (!File.Exists(FormMain.startUpPath + "Photos\\Resources\\deleteunselected.png"))
        return;
      this.pbDelete.Image = Image.FromFile(FormMain.startUpPath + "Photos\\Resources\\deleteunselected.png");
    }

    private void exportToExcelOptionToolStripMenuItem_Click(object sender, EventArgs e)
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
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle16 = new DataGridViewCellStyle();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      this.colSerialNumber = new DataGridViewTextBoxColumn();
      this.colType = new DataGridViewComboBoxColumn();
      this.colAmount = new DataGridViewTextBoxColumn();
      this.colCd = new DataGridViewTextBoxColumn();
      this.colGrossWeight = new DataGridViewTextBoxColumn();
      this.colTouch = new DataGridViewTextBoxColumn();
      this.colRate = new DataGridViewTextBoxColumn();
      this.colTotal = new DataGridViewTextBoxColumn();
      this.panel1 = new Panel();
      this.dataGridView1 = new DataGridView();
      this.customPanel3 = new CustomPanel();
      this.pbSearch = new PictureBox();
      this.tbxSearch = new TextBox();
      this.label1 = new Label();
      this.pbDelete = new PictureBox();
      this.pbAdd = new PictureBox();
      this.pbEdit = new PictureBox();
      this.customPanel1 = new CustomPanel();
      this.pictureBox1 = new PictureBox();
      this.btnAddArticles = new GlassButton();
      this.btnDeleteArticles = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.exportToExcelOptionToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.customPanel3).SuspendLayout();
      ((ISupportInitialize) this.pbSearch).BeginInit();
      ((ISupportInitialize) this.pbDelete).BeginInit();
      ((ISupportInitialize) this.pbAdd).BeginInit();
      ((ISupportInitialize) this.pbEdit).BeginInit();
      ((Control) this.customPanel1).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOptionToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(189, 158);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(188, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(188, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(188, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(188, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(188, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = gridViewCellStyle1;
      this.dataGridViewTextBoxColumn1.HeaderText = "Sl.No";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.dataGridViewComboBoxColumn1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridViewComboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
      this.dataGridViewComboBoxColumn1.FlatStyle = FlatStyle.Flat;
      this.dataGridViewComboBoxColumn1.HeaderText = "Type";
      this.dataGridViewComboBoxColumn1.Items.AddRange((object) "1.BILL", (object) "2.JAMMA", (object) "3.KACHA", (object) "4.CHEQUE", (object) "5.KACHA RETURN", (object) "6.TAX", (object) "7.BYAAJ");
      this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
      this.dataGridViewComboBoxColumn1.Resizable = DataGridViewTriState.True;
      this.dataGridViewComboBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn2.DefaultCellStyle = gridViewCellStyle3;
      this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn3.DefaultCellStyle = gridViewCellStyle4;
      this.dataGridViewTextBoxColumn3.HeaderText = "CD";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn4.DefaultCellStyle = gridViewCellStyle5;
      this.dataGridViewTextBoxColumn4.HeaderText = "Gross Weight";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn5.DefaultCellStyle = gridViewCellStyle6;
      this.dataGridViewTextBoxColumn5.HeaderText = "Touch";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn6.DefaultCellStyle = gridViewCellStyle7;
      this.dataGridViewTextBoxColumn6.HeaderText = "Rate";
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridViewTextBoxColumn7.DefaultCellStyle = gridViewCellStyle8;
      this.dataGridViewTextBoxColumn7.HeaderText = "Total";
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.colSerialNumber.DefaultCellStyle = gridViewCellStyle9;
      this.colSerialNumber.HeaderText = "Sl.No";
      this.colSerialNumber.Name = "colSerialNumber";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.colType.DefaultCellStyle = gridViewCellStyle10;
      this.colType.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
      this.colType.FlatStyle = FlatStyle.Flat;
      this.colType.HeaderText = "Type";
      this.colType.Items.AddRange((object) "1.BILL", (object) "2.JAMMA", (object) "3.KACHA", (object) "4.CHEQUE", (object) "5.KACHA RETURN", (object) "6.TAX", (object) "7.BYAAJ");
      this.colType.Name = "colType";
      this.colType.Resizable = DataGridViewTriState.True;
      this.colType.SortMode = DataGridViewColumnSortMode.Automatic;
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colAmount.DefaultCellStyle = gridViewCellStyle11;
      this.colAmount.HeaderText = "Amount";
      this.colAmount.Name = "colAmount";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colCd.DefaultCellStyle = gridViewCellStyle12;
      this.colCd.HeaderText = "CD";
      this.colCd.Name = "colCd";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colGrossWeight.DefaultCellStyle = gridViewCellStyle13;
      this.colGrossWeight.HeaderText = "Gross Weight";
      this.colGrossWeight.Name = "colGrossWeight";
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colTouch.DefaultCellStyle = gridViewCellStyle14;
      this.colTouch.HeaderText = "Touch";
      this.colTouch.Name = "colTouch";
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colRate.DefaultCellStyle = gridViewCellStyle15;
      this.colRate.HeaderText = "Rate";
      this.colRate.Name = "colRate";
      gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colTotal.DefaultCellStyle = gridViewCellStyle16;
      this.colTotal.HeaderText = "Total";
      this.colTotal.Name = "colTotal";
      this.panel1.BackColor = SystemColors.GradientInactiveCaption;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.Controls.Add((Control) this.dataGridView1);
      this.panel1.Controls.Add((Control) this.customPanel3);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1008, 626);
      this.panel1.TabIndex = 0;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.GridColor = SystemColors.GradientInactiveCaption;
      this.dataGridView1.Location = new Point(5, 46);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(999, 577);
      this.dataGridView1.TabIndex = 16;
      this.dataGridView1.TabStop = false;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.customPanel3.BackColor = Color.PowderBlue;
      this.customPanel3.BackColor2 = Color.AliceBlue;
      this.customPanel3.BorderColor = SystemColors.MenuHighlight;
      this.customPanel3.BorderWidth = 2;
      ((Control) this.customPanel3).Controls.Add((Control) this.pbSearch);
      ((Control) this.customPanel3).Controls.Add((Control) this.tbxSearch);
      ((Control) this.customPanel3).Controls.Add((Control) this.label1);
      ((Control) this.customPanel3).Controls.Add((Control) this.pbDelete);
      ((Control) this.customPanel3).Controls.Add((Control) this.pbAdd);
      ((Control) this.customPanel3).Controls.Add((Control) this.pbEdit);
      ((Control) this.customPanel3).Controls.Add((Control) this.customPanel1);
      ((Control) this.customPanel3).Controls.Add((Control) this.btnAddArticles);
      ((Control) this.customPanel3).Controls.Add((Control) this.btnDeleteArticles);
      ((Control) this.customPanel3).Controls.Add((Control) this.glassButton1);
      this.customPanel3.CurveMode = CornerCurveMode.TopLeft_TopRight;
      ((Control) this.customPanel3).Dock = DockStyle.Fill;
      this.customPanel3.GradientMode = CSharpCustomPanelControl.LinearGradientMode.Vertical;
      ((Control) this.customPanel3).Location = new Point(0, 0);
      ((Control) this.customPanel3).Margin = new Padding(0);
      ((Control) this.customPanel3).Name = "customPanel3";
      ((Control) this.customPanel3).Size = new Size(1008, 626);
      ((Control) this.customPanel3).TabIndex = 18;
      this.pbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbSearch.Image = (Image) Resources.searchfileicon30110112;
      this.pbSearch.Location = new Point(720, 8);
      this.pbSearch.Name = "pbSearch";
      this.pbSearch.Size = new Size(30, 30);
      this.pbSearch.TabIndex = 5;
      this.pbSearch.TabStop = false;
      this.tbxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.tbxSearch.BackColor = SystemColors.InactiveBorder;
      this.tbxSearch.BorderStyle = BorderStyle.None;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(756, 8);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(246, 31);
      this.tbxSearch.TabIndex = 0;
      this.tbxSearch.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Rockwell", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(8, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(208, 27);
      this.label1.TabIndex = 8;
      this.label1.Text = "LEDGER MASTER";
      this.pbDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbDelete.Location = new Point(684, 8);
      this.pbDelete.Name = "pbDelete";
      this.pbDelete.Size = new Size(30, 30);
      this.pbDelete.TabIndex = 6;
      this.pbDelete.TabStop = false;
      this.pbDelete.Visible = false;
      this.pbDelete.Click += new EventHandler(this.btnDeleteArticles_Click);
      this.pbDelete.MouseEnter += new EventHandler(this.pbDelete_MouseEnter);
      this.pbDelete.MouseLeave += new EventHandler(this.pbDelete_MouseLeave);
      this.pbAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbAdd.Image = (Image) Resources.ADDUNSELECTED;
      this.pbAdd.Location = new Point(612, 8);
      this.pbAdd.Name = "pbAdd";
      this.pbAdd.Size = new Size(30, 30);
      this.pbAdd.TabIndex = 4;
      this.pbAdd.TabStop = false;
      this.pbAdd.Click += new EventHandler(this.pictureBox2_Click);
      this.pbAdd.MouseEnter += new EventHandler(this.pictureBox2_MouseEnter);
      this.pbAdd.MouseLeave += new EventHandler(this.pictureBox2_MouseLeave);
      this.pbEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbEdit.Image = (Image) Resources.editunselected;
      this.pbEdit.Location = new Point(648, 8);
      this.pbEdit.Name = "pbEdit";
      this.pbEdit.Size = new Size(30, 30);
      this.pbEdit.TabIndex = 5;
      this.pbEdit.TabStop = false;
      this.pbEdit.Click += new EventHandler(this.glassButton1_Click);
      this.pbEdit.MouseEnter += new EventHandler(this.pbEdit_MouseEnter);
      this.pbEdit.MouseLeave += new EventHandler(this.pbEdit_MouseLeave);
      ((Control) this.customPanel1).Anchor = AnchorStyles.Bottom;
      this.customPanel1.BackColor2 = Color.Firebrick;
      this.customPanel1.BorderColor = Color.Firebrick;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.pictureBox1);
      this.customPanel1.Curvature = 3;
      this.customPanel1.CurveMode = CornerCurveMode.BottomRight_TopRight_BottomLeft;
      ((Control) this.customPanel1).Location = new Point(96, 385);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(256, 40);
      ((Control) this.customPanel1).TabIndex = 3;
      this.pictureBox1.Location = new Point(5, 2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(38, 35);
      this.pictureBox1.TabIndex = 21;
      this.pictureBox1.TabStop = false;
      ((Control) this.btnAddArticles).Anchor = AnchorStyles.Bottom;
      this.btnAddArticles.BackColor = Color.White;
      ((Control) this.btnAddArticles).BackgroundImageLayout = ImageLayout.Center;
      this.btnAddArticles.FadeOnFocus = true;
      this.btnAddArticles.ForeColor = Color.Black;
      this.btnAddArticles.ForeColorOnFocus = Color.Red;
      this.btnAddArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddArticles.GlowColor = Color.LightPink;
      this.btnAddArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddArticles).Location = new Point(360, 382);
      ((Control) this.btnAddArticles).Name = "btnAddArticles";
      this.btnAddArticles.OuterBorderColor = Color.MistyRose;
      this.btnAddArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticles).Size = new Size(151, 45);
      ((Control) this.btnAddArticles).TabIndex = 0;
      ((Control) this.btnAddArticles).Text = "ADD";
      ((ButtonBase) this.btnAddArticles).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticles).Click += new EventHandler(this.btnAddArticles_Click);
      ((Control) this.btnDeleteArticles).Anchor = AnchorStyles.Bottom;
      this.btnDeleteArticles.BackColor = Color.White;
      ((Control) this.btnDeleteArticles).BackgroundImageLayout = ImageLayout.Center;
      this.btnDeleteArticles.FadeOnFocus = true;
      ((Control) this.btnDeleteArticles).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDeleteArticles.ForeColor = SystemColors.ActiveCaptionText;
      this.btnDeleteArticles.ForeColorOnFocus = Color.Red;
      this.btnDeleteArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnDeleteArticles.GlowColor = Color.LightPink;
      this.btnDeleteArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnDeleteArticles).Location = new Point(673, 382);
      ((Control) this.btnDeleteArticles).Name = "btnDeleteArticles";
      this.btnDeleteArticles.OuterBorderColor = Color.MistyRose;
      this.btnDeleteArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnDeleteArticles).Size = new Size(151, 45);
      ((Control) this.btnDeleteArticles).TabIndex = 2;
      ((Control) this.btnDeleteArticles).Text = "DELETE";
      ((ButtonBase) this.btnDeleteArticles).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnDeleteArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnDeleteArticles).Click += new EventHandler(this.btnDeleteArticles_Click);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Bottom;
      this.glassButton1.BackColor = Color.White;
      ((Control) this.glassButton1).BackgroundImageLayout = ImageLayout.Center;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.Black;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.LightPink;
      this.glassButton1.InnerBorderColor = Color.Firebrick;
      ((Control) this.glassButton1).Location = new Point(517, 382);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MistyRose;
      this.glassButton1.ShineColor = Color.MistyRose;
      ((Control) this.glassButton1).Size = new Size(151, 45);
      ((Control) this.glassButton1).TabIndex = 1;
      ((Control) this.glassButton1).Text = "EDIT";
      ((ButtonBase) this.glassButton1).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.exportToExcelOptionToolStripMenuItem.Name = "exportToExcelOptionToolStripMenuItem";
      this.exportToExcelOptionToolStripMenuItem.Size = new Size(188, 22);
      this.exportToExcelOptionToolStripMenuItem.Text = "Export to Excel option";
      this.exportToExcelOptionToolStripMenuItem.Click += new EventHandler(this.exportToExcelOptionToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.GradientInactiveCaption;
      this.ClientSize = new Size(1008, 626);
      this.Controls.Add((Control) this.panel1);
      this.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = Color.Firebrick;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(4, 5, 4, 5);
      this.MinimizeBox = false;
      this.Name = nameof (FormLedgerDetails);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormLedgerDetails);
      this.Load += new EventHandler(this.FormLedgerDetails_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.customPanel3).ResumeLayout(false);
      ((Control) this.customPanel3).PerformLayout();
      ((ISupportInitialize) this.pbSearch).EndInit();
      ((ISupportInitialize) this.pbDelete).EndInit();
      ((ISupportInitialize) this.pbAdd).EndInit();
      ((ISupportInitialize) this.pbEdit).EndInit();
      ((Control) this.customPanel1).ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
