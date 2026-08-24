

using ExportToExcel11;
using Glass;
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
  public class FormLocation : Form
  {
    private string oldLocation = "";
    private string AddLocation = "";
    private IContainer components = (IContainer) null;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label label5;
    private ToolStripMenuItem setAsDefaultToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel panel5;
    private Panel panel6;
    private Panel panel4;
    private TableLayoutPanel tableLayoutPanel1;
    private DataGridView dataGridView1;
    private Panel panel1;
    private Label label3;
    private Label label2;
    private Label label1;
    private GlassButton btnAddEdit;
    private TextBox tbxPincode;
    private TextBox tbxCity;
    private TextBox tbxLocation;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormLocation(string NEWLOCATION)
    {
      this.AddLocation = NEWLOCATION;
      this.InitializeComponent();
    }

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblPincode";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form locationandpincode.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the tblLocation.\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
      this.dataGridView1.Columns["ID"].Visible = false;
    }

    private void Location_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      PawnManagementClass.formatButtonControl(ref this.btnAddEdit);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.refreshGrid();
      this.tbxLocation.KeyDown += new KeyEventHandler(this.tbxLocation_KeyDown);
      this.tbxCity.KeyDown += new KeyEventHandler(this.tbxLocation_KeyDown);
      this.tbxPincode.KeyDown += new KeyEventHandler(this.tbxLocation_KeyDown);
      this.tbxLocation.Text = this.AddLocation;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void tbxLocation_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows != null && this.dataGridView1.Rows.Count > 1)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
          {
            string strError = "";
            if (SQLHelper.RunCommand("Delete from tblPincode where ID =@ID", new List<OleDbParameter>()
            {
              new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString())
            }, ref strError) != "Done")
            {
              int num = (int) MessageBox.Show("Error in deleting" + strError);
            }
          }
          this.refreshGrid();
        }
        else
        {
          int num1 = (int) MessageBox.Show("Cannot Delete all the records....Atleast one location and pincode is mandatory");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  loacation.deletetoolstripMentiem_click.", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count < 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        this.oldLocation = this.tbxLocation.Text = this.dataGridView1.Rows[rowIndex].Cells["Location"].Value.ToString();
        this.tbxCity.Text = this.dataGridView1.Rows[rowIndex].Cells["City"].Value.ToString();
        this.tbxPincode.Text = this.dataGridView1.Rows[rowIndex].Cells["Pincode"].Value.ToString();
        ((Control) this.btnAddEdit).Text = "UPDATE";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form location.edittoolstripmenuitem_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkIfAllEntriesAreMade() => !(this.tbxLocation.Text == "") && !(this.tbxCity.Text == "") && !(this.tbxPincode.Text == "");

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      if (this.checkIfAllEntriesAreMade())
      {
        if (((Control) this.btnAddEdit).Text == "UPDATE")
        {
          this.editPincode();
          this.tbxLocation.Text = "";
          this.tbxCity.Text = "";
          this.tbxPincode.Text = "";
          this.tbxLocation.Focus();
          this.refreshGrid();
        }
        if (((Control) this.btnAddEdit).Text == "ADD")
        {
          this.addPincode();
          this.tbxLocation.Text = "";
          this.tbxCity.Text = "";
          this.tbxPincode.Text = "";
          this.refreshGrid();
          this.tbxLocation.Focus();
        }
        ((Control) this.btnAddEdit).Text = "ADD";
      }
      else
      {
        int num = (int) MessageBox.Show("Enter all the data");
      }
    }

    private void editPincode()
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count < 0)
          return;
        int rowIndex1 = this.dataGridView1.CurrentCell.RowIndex;
        string strError1 = "";
        string str = SQLHelper.RunCommand("Update tblPincode set Location=@Location,City=@City,Pincode=@Pincode,DefaultValue=@DefaultValue where ID =@ID", new List<OleDbParameter>()
        {
          new OleDbParameter("Location", (object) this.tbxLocation.Text.ToString()),
          new OleDbParameter("City", (object) this.tbxCity.Text.ToString()),
          new OleDbParameter("Pincode", (object) this.tbxPincode.Text.ToString()),
          new OleDbParameter("DefaultValue", (object) "N"),
          new OleDbParameter("ID", (object) int.Parse(this.dataGridView1.Rows[rowIndex1].Cells["ID"].Value.ToString()))
        }, ref strError1);
        if (str != "Done")
        {
          int num1 = (int) MessageBox.Show("Error in editing" + strError1);
        }
        else if (str == "Done")
        {
          int rowIndex2 = this.dataGridView1.CurrentCell.RowIndex;
          string strError2 = "";
          SQLHelper.RunCommand("Update tblPledge set Addr3 = @Addr3,City=@City,Pincode=@Pincode  where Addr3 =@Addr3", new List<OleDbParameter>()
          {
            new OleDbParameter("Addr3", (object) this.tbxLocation.Text.ToString()),
            new OleDbParameter("City", (object) this.tbxCity.Text.ToString()),
            new OleDbParameter("Pincode", (object) this.tbxPincode.Text.ToString()),
            new OleDbParameter("Addr3", (object) this.oldLocation)
          }, ref strError2);
          if (str != "Done")
          {
            int num2 = (int) MessageBox.Show("Error in editing" + strError2);
          }
          else if (!(str == "Done"))
            ;
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form location.editPincode()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addPincode()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblPincode(Location,City,Pincode,DefaultValue) values(@Location,@City,@Pincode,@DefaultValue)", new List<OleDbParameter>()
      {
        new OleDbParameter("Location", (object) this.tbxLocation.Text.ToString()),
        new OleDbParameter("City", (object) this.tbxCity.Text.ToString()),
        new OleDbParameter("Pincode", (object) this.tbxPincode.Text.ToString()),
        new OleDbParameter("DefaultValue", (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form location.addpincode", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void tbxPincode_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxDefaultValue_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'Y' || e.KeyChar == 'N' || e.KeyChar == '\b')
        return;
      e.Handled = true;
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

    private void panel3_Paint(object sender, PaintEventArgs e)
    {
    }

    private void panel3_Resize(object sender, EventArgs e)
    {
    }

    private void setAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count > 0)
      {
        string strError1 = "";
        if (!(SQLHelper.RunCommand("Update tblPincode set DefaultValue='Y' where ID = @ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString())
        }, ref strError1) == "Done"))
        {
          int num1 = (int) MessageBox.Show("Error in updating" + strError1);
        }
        string strError2 = "";
        if (!(SQLHelper.RunCommand("Update tblPincode set DefaultValue='N' where ID <> @ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString())
        }, ref strError2) == "Done"))
        {
          int num2 = (int) MessageBox.Show("Error in updating" + strError2);
        }
      }
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.setAsDefaultToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.label5 = new Label();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.panel5 = new Panel();
      this.panel6 = new Panel();
      this.panel4 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.dataGridView1 = new DataGridView();
      this.panel1 = new Panel();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.btnAddEdit = new GlassButton();
      this.tbxPincode = new TextBox();
      this.tbxCity = new TextBox();
      this.tbxLocation = new TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel4.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.setAsDefaultToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "ExportToExcel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.setAsDefaultToolStripMenuItem.Name = "setAsDefaultToolStripMenuItem";
      this.setAsDefaultToolStripMenuItem.Size = new Size(194, 22);
      this.setAsDefaultToolStripMenuItem.Text = "Set As Default";
      this.setAsDefaultToolStripMenuItem.Click += new EventHandler(this.setAsDefaultToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.label5.Anchor = AnchorStyles.Top;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(290, 5);
      this.label5.Name = "label5";
      this.label5.Size = new Size(413, 29);
      this.label5.TabIndex = 11;
      this.label5.Text = "LOCATION AND PINCODE MASTER";
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel2.Controls.Add((Control) this.panel5, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.panel6, 0, 1);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 41f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel2.Size = new Size(1008, 636);
      this.tableLayoutPanel2.TabIndex = 16;
      this.panel5.BackColor = Color.White;
      this.panel5.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel5.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel5.BorderStyle = BorderStyle.FixedSingle;
      this.panel5.Controls.Add((Control) this.label5);
      this.panel5.Dock = DockStyle.Fill;
      this.panel5.Location = new Point(3, 3);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(1002, 35);
      this.panel5.TabIndex = 9;
      this.panel6.BackColor = Color.AliceBlue;
      this.panel6.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel6.BorderStyle = BorderStyle.FixedSingle;
      this.panel6.Controls.Add((Control) this.panel4);
      this.panel6.Dock = DockStyle.Fill;
      this.panel6.Location = new Point(3, 44);
      this.panel6.Name = "panel6";
      this.panel6.Size = new Size(1002, 589);
      this.panel6.TabIndex = 11;
      this.panel4.BorderStyle = BorderStyle.FixedSingle;
      this.panel4.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel4.Dock = DockStyle.Fill;
      this.panel4.Location = new Point(0, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(1000, 587);
      this.panel4.TabIndex = 14;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Margin = new Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 61.26126f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.73874f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(998, 585);
      this.tableLayoutPanel1.TabIndex = 12;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = SystemColors.ButtonFace;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 3);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(992, 352);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.TabStop = false;
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnAddEdit);
      this.panel1.Controls.Add((Control) this.tbxPincode);
      this.panel1.Controls.Add((Control) this.tbxCity);
      this.panel1.Controls.Add((Control) this.tbxLocation);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 361);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(992, 221);
      this.panel1.TabIndex = 0;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(81, 88);
      this.label3.Name = "label3";
      this.label3.Size = new Size(94, 24);
      this.label3.TabIndex = 7;
      this.label3.Text = "PINCODE";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(124, 54);
      this.label2.Name = "label2";
      this.label2.Size = new Size(51, 24);
      this.label2.TabIndex = 6;
      this.label2.Text = "CITY";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(69, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(106, 24);
      this.label1.TabIndex = 5;
      this.label1.Text = "LOCATION";
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(181, 130);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(315, 48);
      ((Control) this.btnAddEdit).TabIndex = 4;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.tbxPincode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPincode.CharacterCasing = CharacterCasing.Upper;
      this.tbxPincode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPincode.Location = new Point(181, 86);
      this.tbxPincode.MaxLength = 6;
      this.tbxPincode.Name = "tbxPincode";
      this.tbxPincode.Size = new Size(315, 29);
      this.tbxPincode.TabIndex = 2;
      this.tbxPincode.KeyPress += new KeyPressEventHandler(this.tbxPincode_KeyPress);
      this.tbxCity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCity.CharacterCasing = CharacterCasing.Upper;
      this.tbxCity.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCity.Location = new Point(181, 52);
      this.tbxCity.Name = "tbxCity";
      this.tbxCity.Size = new Size(315, 29);
      this.tbxCity.TabIndex = 1;
      this.tbxLocation.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLocation.CharacterCasing = CharacterCasing.Upper;
      this.tbxLocation.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLocation.Location = new Point(181, 18);
      this.tbxLocation.Name = "tbxLocation";
      this.tbxLocation.Size = new Size(315, 29);
      this.tbxLocation.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormLocation);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Location";
      this.Load += new EventHandler(this.Location_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
