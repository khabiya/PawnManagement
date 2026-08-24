
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormDayReportCustomerWise : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;

    public FormDayReportCustomerWise() => this.InitializeComponent();

    private void FormDayReportCustomerWise_Load(object sender, EventArgs e)
    {
      DataTable dataTable = SQLHelper.GetDataTable("(select CustomerCode,CustomerName,BillDate,Amount,temp5 as Interest from tblPledge where customerCode = @CustomerCode and BillDate = @BillDate)");
      if (dataTable == null || dataTable.Rows.Count <= 0)
        ;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridView1 = new DataGridView();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(800, 450);
      this.dataGridView1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormDayReportCustomerWise);
      this.Text = nameof (FormDayReportCustomerWise);
      this.Load += new EventHandler(this.FormDayReportCustomerWise_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
