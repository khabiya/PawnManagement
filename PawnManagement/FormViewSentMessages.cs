
using ExportToExcel11;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
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
  public class FormViewSentMessages : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox textBox1;
    private Label label1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormViewSentMessages() => this.InitializeComponent();

    private void refreshGrid()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblSentSms";
        DataTable dataTable = new DataTable();
        this.dataGridView1.DataSource = (object) SQLHelper.GetDataTable(my_querry, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.refreshgrid1", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshGrid1()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblSentSms where MessageText like @search1 or PhoneNumber like  @search2 or Customercode like @search3 or SentOn like @search4  or SentTime like @search5  or SentBy like @search6";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("search1", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("search2", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("search3", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("search4", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("search5", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        parameters.Add(new OleDbParameter("search6", (object) ("%" + this.textBox1.Text.Trim().ToString() + "%")));
        DataTable dataTable = new DataTable();
        this.dataGridView1.DataSource = (object) SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.refreshgrid1", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormViewSentMessages_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      this.refreshGrid();
    }

    private void textBox1_TextChanged(object sender, EventArgs e) => this.refreshGrid1();

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
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Sent  SMS").ShowDialog();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || !(this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode"))
        return;
      string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["CustomerCode"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
    }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].Name == "CustomerCode")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
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
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.headerPanel1 = new HeaderPanel();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(11, 48);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(992, 546);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 114);
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
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(778, 13);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(217, 29);
      this.textBox1.TabIndex = 0;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(692, 17);
      this.label1.Name = "label1";
      this.label1.Size = new Size(80, 25);
      this.label1.TabIndex = 2;
      this.label1.Text = "Search";
      this.headerPanel1.BorderColor = SystemColors.ActiveCaption;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.MidnightBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Horizontal;
      this.headerPanel1.CaptionHeight = 33;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "View Sent SMS";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.dataGridView1);
      ((Control) this.headerPanel1).Dock = DockStyle.Fill;
      ((Control) this.headerPanel1).Font = new Font("Segoe UI", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.White;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.PowderBlue;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(0, 0);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = true;
      ((Control) this.headerPanel1).Size = new Size(1008, 632);
      ((Control) this.headerPanel1).TabIndex = 3;
      this.headerPanel1.TextAntialias = true;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormViewSentMessages);
      this.Text = nameof (FormViewSentMessages);
      this.Load += new EventHandler(this.FormViewSentMessages_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
