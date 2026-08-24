
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.JewelleryForms
{
  public class FormSalesReport : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dgvSales;
    private Button btnDelete;
    private ComboBox comboBox1;

    public FormSalesReport() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormSalesReport_Load(object sender, EventArgs e) => this.refreshGrid();

    private void refreshGrid() => this.dgvSales.DataSource = (object) SalesClass.getCompleteSalesTable("CompanyCode,BillNumber", this.comboBox1.Text);

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dgvSales == null || this.dgvSales.DataSource == null || this.dgvSales.Rows.Count <= 0 || this.dgvSales.CurrentCell == null)
        return;
      int rowIndex = this.dgvSales.CurrentCell.RowIndex;
      string CompanyCode = this.dgvSales.Rows[rowIndex].Cells["CompanyCode"].Value.ToString();
      string BillNumber = this.dgvSales.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      if (DialogResult.Yes == MessageBox.Show("Delete?", "Are you Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) && SalesClass.deleteSales(CompanyCode, BillNumber) == "Done" && SalesDetailsClass.deleteSalesDetails(CompanyCode, BillNumber) == "Done")
        this.refreshGrid();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormSalesReport));
      this.dgvSales = new DataGridView();
      this.btnDelete = new Button();
      this.comboBox1 = new ComboBox();
      ((ISupportInitialize) this.dgvSales).BeginInit();
      this.SuspendLayout();
      this.dgvSales.AllowUserToAddRows = false;
      this.dgvSales.AllowUserToDeleteRows = false;
      this.dgvSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvSales.BorderStyle = BorderStyle.None;
      this.dgvSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.Wheat;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvSales.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvSales.ColumnHeadersHeight = 40;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.Ivory;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvSales.DefaultCellStyle = gridViewCellStyle2;
      this.dgvSales.EnableHeadersVisualStyles = false;
      this.dgvSales.GridColor = Color.Khaki;
      this.dgvSales.Location = new Point(5, 69);
      this.dgvSales.Name = "dgvSales";
      this.dgvSales.ReadOnly = true;
      this.dgvSales.RowHeadersVisible = false;
      this.dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSales.Size = new Size(1007, 603);
      this.dgvSales.TabIndex = 0;
      this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.BackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.BorderColor = Color.Black;
      this.btnDelete.FlatAppearance.BorderSize = 0;
      this.btnDelete.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnDelete.FlatStyle = FlatStyle.Popup;
      this.btnDelete.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDelete.ForeColor = Color.Black;
      this.btnDelete.Image = (Image) componentResourceManager.GetObject("btnDelete.Image");
      this.btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnDelete.Location = new Point(853, 12);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(159, 51);
      this.btnDelete.TabIndex = 73;
      this.btnDelete.Text = "       &Delete";
      this.btnDelete.TextAlign = ContentAlignment.MiddleRight;
      this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(701, 29);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(121, 21);
      this.comboBox1.TabIndex = 74;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1024, 670);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.dgvSales);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormSalesReport);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormSalesReport);
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.FormSalesReport_Load);
      ((ISupportInitialize) this.dgvSales).EndInit();
      this.ResumeLayout(false);
    }
  }
}
