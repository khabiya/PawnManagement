

using ExportToExcel11;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormCustomerPendingGirviList : Form
  {
    private DataTable dt = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxFromDate;
    private TextBox tbxToDate;
    private Label label1;
    private Label label2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormCustomerPendingGirviList() => this.InitializeComponent();

    private void FormCustomerPendingGirviList_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.dataGridView1.BackgroundColor = Color.AliceBlue;
      this.dataGridView1.GridColor = Color.CornflowerBlue;
      this.dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
      this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
      this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.tbxFromDate.Text = DateTime.Parse(PawnManagementClass.getOldestUnredeemedPledgeRecord().Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      this.tbxFromDate.Select();
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        if (control1 is TextBox)
        {
          TextBox textBox = (TextBox) control1;
          textBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
          textBox.Enter += new EventHandler(this.textBox_Enter);
          textBox.Leave += new EventHandler(this.textBox_Leave);
        }
        else
          this.Assign(control1);
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.Black;
      textBox.ForeColor = Color.Yellow;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.DarkBlue;
    }

    private void refreshGrid()
    {
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select t2.customercode,t2.amountsum,c.cname,C.cnotes,c.cphone,c.ccell,c.cno,c.caddr1,c.caddr2,c.caddr3,c.cCity,c.cpincode,c.cintroducer from(SELECT t.customercode, t.amountsum FROM (SELECT CUSTOMERCODE, SUM(AMOUNT) AS AMOUNTsum FROM TBLPLEDGE WHERE REDEEMED='N' And (billdate>=[@fromdate] And billdate<=[@todate]) GROUP BY customercode)  AS t ORDER BY t.amountsum DESC) as t2 left join tblcustomers c on t2.customercode = c.cid order by t2.amountsum desc", new List<OleDbParameter>()
      {
        new OleDbParameter("fromdate", (object) this.tbxFromDate.Text.Trim().ToString()),
        new OleDbParameter("todate", (object) this.tbxToDate.Text.Trim().ToString())
      }, ref strError);
      this.dataGridView1.DataSource = (object) this.dt;
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e) => this.getData();

    private void tbxFromDate_TextChanged(object sender, EventArgs e) => this.getData();

    private void getData()
    {
      if (this.tbxFromDate.Text.Length == 10)
      {
        if (this.tbxToDate.Text.Length == 10)
        {
          if (!PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
            return;
          if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
            this.refreshGrid();
          else
            this.tbxToDate.Select();
        }
        else
          this.dataGridView1.DataSource = (object) null;
      }
      else
        this.dataGridView1.DataSource = (object) null;
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

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
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
      this.dataGridView1 = new DataGridView();
      this.tbxFromDate = new TextBox();
      this.tbxToDate = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(12, 44);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(984, 566);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.tbxFromDate.BackColor = Color.AliceBlue;
      this.tbxFromDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromDate.CharacterCasing = CharacterCasing.Upper;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxFromDate.Location = new Point(74, 9);
      this.tbxFromDate.MaxLength = 10;
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(146, 29);
      this.tbxFromDate.TabIndex = 9;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Right;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxToDate.BackColor = Color.AliceBlue;
      this.tbxToDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToDate.CharacterCasing = CharacterCasing.Upper;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.ForeColor = SystemColors.ActiveCaptionText;
      this.tbxToDate.Location = new Point(278, 9);
      this.tbxToDate.MaxLength = 10;
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(146, 29);
      this.tbxToDate.TabIndex = 10;
      this.tbxToDate.TextAlign = HorizontalAlignment.Right;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(13, 17);
      this.label1.Name = "label1";
      this.label1.Size = new Size(56, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "From Date";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(226, 17);
      this.label2.Name = "label2";
      this.label2.Size = new Size(46, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "To Date";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 70);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.tbxToDate);
      this.Controls.Add((Control) this.tbxFromDate);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormCustomerPendingGirviList);
      this.Text = nameof (FormCustomerPendingGirviList);
      this.Load += new EventHandler(this.FormCustomerPendingGirviList_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
