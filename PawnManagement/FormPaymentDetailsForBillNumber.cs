

using ExportToExcel11;
using PawnManagement.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPaymentDetailsForBillNumber : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LightBlueFadeDown.jpg");
    private string billNumber = "";
    private string PartPaymentDetails = "";
    private string shopCode = "";
    private DataTable dtPPD = new DataTable();
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label lblHeading;
    private Panel panel3;
    private DataGridView dataGridView1;
    private TextBox tbxTotal;
    private Label label1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormPaymentDetailsForBillNumber(string BillNumber, string SHOPCODE)
    {
      this.billNumber = BillNumber;
      this.shopCode = SHOPCODE;
      this.InitializeComponent();
    }

    public FormPaymentDetailsForBillNumber(
      DataTable dtppd,
      string BillNumber,
      string PPD,
      string SHOPCODE)
    {
      this.PartPaymentDetails = PPD;
      this.dtPPD = dtppd;
      this.billNumber = BillNumber;
      this.shopCode = SHOPCODE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPaymentDetailsForBillNumber_Load(object sender, EventArgs e)
    {
      if (this.PartPaymentDetails == "")
      {
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        this.lblHeading.Text = "Payment details for [" + this.billNumber + "]";
        this.dataGridView1.DataSource = (object) PawnManagementClass.getPaymentDetailsForBillNumber(this.billNumber, this.shopCode);
        this.tbxTotal.Text = PawnManagementClass.getPaymentSum(this.billNumber, this.shopCode).ToString();
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      }
      else
      {
        if (!(this.PartPaymentDetails == "PartPaymentInterest"))
          return;
        PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
        this.lblHeading.Text = "Payment details for [" + this.billNumber + "]";
        this.dataGridView1.DataSource = (object) this.dtPPD;
      }
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
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

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void dataGridView1_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      double num = 0.0;
      if (this.PartPaymentDetails == "PartPaymentInterest")
      {
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
          num += double.Parse(row.Cells["Interest"].Value.ToString());
      }
      this.tbxTotal.Text = num.ToString();
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Payment Details").ShowDialog();
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.lblHeading = new Label();
      this.panel3 = new Panel();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tbxTotal = new TextBox();
      this.label1 = new Label();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.59627f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85.40372f));
      this.tableLayoutPanel1.Size = new Size(811, 505);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(805, 67);
      this.panel2.TabIndex = 9;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.Black;
      this.lblHeading.Location = new Point(209, 19);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(298, 29);
      this.lblHeading.TabIndex = 10;
      this.lblHeading.Text = "PAYMENT DETAILS FOR ";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Controls.Add((Control) this.tbxTotal);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 76);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(805, 426);
      this.panel3.TabIndex = 11;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(13, 7);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(777, 372);
      this.dataGridView1.TabIndex = 14;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
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
      this.tbxTotal.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.Location = new Point(553, 385);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(237, 31);
      this.tbxTotal.TabIndex = 0;
      this.tbxTotal.TextAlign = HorizontalAlignment.Right;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(482, 387);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 25);
      this.label1.TabIndex = 7;
      this.label1.Text = "Total";
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(811, 505);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormPaymentDetailsForBillNumber);
      this.Text = nameof (FormPaymentDetailsForBillNumber);
      this.Load += new EventHandler(this.FormPaymentDetailsForBillNumber_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
