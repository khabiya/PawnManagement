
using ExportToExcel11;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormException : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox textBox1;
    private TableLayoutPanel tableLayoutPanel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem addRowHeightToolStripMenuItem;
    private ToolStripMenuItem reduceRowHeightToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Panel panel1;
    private RichTextBox richTextBox1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormException() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblExceptions order by createdOn";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form exception.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (this.textBox1.Text != "")
      {
        string strError = "";
        string my_querry = "select * from tblExceptions where Message like @Message or Source like @Source or StackTrace like @StackTrace or CreatedBy like @CreatedBy or CreatedOn like @CreatedOn";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("Message", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("Source", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("StackTrace", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("CreatedBy", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("CreatedOn", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form exception.textbox1_textchanged", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving data" + strError);
        }
        else
          this.dataGridView1.DataSource = (object) dataTable2;
      }
      else
        this.refreshGrid();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormException_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.refreshGrid();
    }

    private void addRowHeightToolStripMenuItem_Click(object sender, EventArgs e) => this.dataGridView1.RowTemplate.Height += 10;

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

    private void reduceRowHeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.dataGridView1.RowTemplate.Height -= 10;
      this.dataGridView1.Refresh();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) => this.richTextBox1.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["STACKTRACE"].Value.ToString();

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
      this.addRowHeightToolStripMenuItem = new ToolStripMenuItem();
      this.reduceRowHeightToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.textBox1 = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel1 = new Panel();
      this.richTextBox1 = new RichTextBox();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(3, 17);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 35;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1002, 381);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.addRowHeightToolStripMenuItem,
        (ToolStripItem) this.reduceRowHeightToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.addRowHeightToolStripMenuItem.Name = "addRowHeightToolStripMenuItem";
      this.addRowHeightToolStripMenuItem.Size = new Size(194, 22);
      this.addRowHeightToolStripMenuItem.Text = "add row height";
      this.addRowHeightToolStripMenuItem.Click += new EventHandler(this.addRowHeightToolStripMenuItem_Click);
      this.reduceRowHeightToolStripMenuItem.Name = "reduceRowHeightToolStripMenuItem";
      this.reduceRowHeightToolStripMenuItem.Size = new Size(194, 22);
      this.reduceRowHeightToolStripMenuItem.Text = "reduce row height";
      this.reduceRowHeightToolStripMenuItem.Click += new EventHandler(this.reduceRowHeightToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.textBox1.Dock = DockStyle.Fill;
      this.textBox1.Location = new Point(3, 3);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(1002, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.textBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 3.571429f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 96.42857f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 234f));
      this.tableLayoutPanel1.Size = new Size(1008, 636);
      this.tableLayoutPanel1.TabIndex = 2;
      this.panel1.Controls.Add((Control) this.richTextBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 404);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 229);
      this.panel1.TabIndex = 3;
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Location = new Point(0, 0);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(1002, 229);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "export to excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormException);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormException);
      this.Load += new EventHandler(this.FormException_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
