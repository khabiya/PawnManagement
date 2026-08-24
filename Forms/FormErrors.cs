
using Glass;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormErrors : Form
  {
    private IContainer components = (IContainer) null;
    private RichTextBox richTextBox1;
    private GlassButton glassButton1;
    private DataGridView dataGridView1;
    private ComboBox comboBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;

    public FormErrors() => this.InitializeComponent();

    private void glassButton1_Click(object sender, EventArgs e) => this.dataGridView1.DataSource = (object) this.getDatatable(this.richTextBox1.Text);

    private DataTable getDatatable(string Query)
    {
      try
      {
        string strError = "";
        DataTable dataTable = new DataTable();
        return SQLHelper.GetDataTable(Query, ref strError);
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormErrors_Load(object sender, EventArgs e) => PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => this.richTextBox1.Text = this.comboBox1.Text;

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "CASH BOOK").ShowDialog();
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.richTextBox1 = new RichTextBox();
      this.glassButton1 = new GlassButton();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.comboBox1 = new ComboBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.richTextBox1.Location = new Point(8, 12);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(893, 50);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(907, 12);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(89, 83);
      ((Control) this.glassButton1).TabIndex = 1;
      ((Control) this.glassButton1).Text = "Query";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(7, 101);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(993, 519);
      this.dataGridView1.TabIndex = 2;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(160, 70);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(159, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(159, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(159, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[6]
      {
        (object) "SELECT * FROM TBLPLEDGE WHERE BILLDATE >= ##",
        (object) "SELECT * FROM TBLREDEMPTION WHERE BILLDATE >= ##",
        (object) "SELECT BILLNUMBER FROM TBLPLEDGE GROUP BY BILLNUMBER HAVING COUNT(BILLNUMBER) > 1",
        (object) "SELECT BILLNUMBER FROM TBLREDEMPTION GROUP BY BILLNUMBER HAVING COUNT(BILLNUMBER) > 1",
        (object) "SELECT rokaddate FROM TBLROKADDETAILS GROUP BY rokaddate HAVING COUNT(rokaddate) > 1",
        (object) "select * from tblpledge where netweight is null"
      });
      this.comboBox1.Location = new Point(7, 68);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(894, 21);
      this.comboBox1.TabIndex = 3;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.richTextBox1);
      this.Name = nameof (FormErrors);
      this.Text = nameof (FormErrors);
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.FormErrors_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
