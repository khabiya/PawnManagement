
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormPanel1 : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private SplitContainer splitContainer1;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;

    public FormPanel1() => this.InitializeComponent();

    private void FormPanel1_Load(object sender, EventArgs e)
    {
      string text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.pledgeReport(text);
      this.redemptionReport(text);
    }

    private void pledgeReport(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable = new DataTable();
      this.dataGridView1.DataSource = (object) SQLHelper.GetDataTable("Select shopcode,Amount,temp5 as Interest,BillNumber,customername from tblPledge  where BillDate = @BillDate order by shopcode,billnumber ", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) BILLDATE)
      }, ref strError);
    }

    private void redemptionReport(string BILLDATE)
    {
      string strError = "";
      DataTable dataTable = new DataTable();
      this.dataGridView2.DataSource = (object) SQLHelper.GetDataTable("Select  shopcode,BillNumber,tr.Amount,tr.temp3 as FinalInterest,tr.temp4 as TotalRedemptionAmount ,tc.CName as CustomerName from tblRedemption as tr left join tblcustomers as tc on tr.customercode  = tc.cid where BillDate = @BillDate order by shopcode,billnumber", new List<OleDbParameter>()
      {
        new OleDbParameter("BillDate", (object) BILLDATE)
      }, ref strError);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel1 = new Panel();
      this.splitContainer1 = new SplitContainer();
      this.dataGridView1 = new DataGridView();
      this.dataGridView2 = new DataGridView();
      this.panel1.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.splitContainer1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(284, 261);
      this.panel1.TabIndex = 0;
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.dataGridView1);
      this.splitContainer1.Panel2.Controls.Add((Control) this.dataGridView2);
      this.splitContainer1.Size = new Size(284, 261);
      this.splitContainer1.SplitterDistance = 135;
      this.splitContainer1.SplitterWidth = 1;
      this.splitContainer1.TabIndex = 0;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 55);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(97, 150);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(39, 55);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new Size(97, 150);
      this.dataGridView2.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 261);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormPanel1);
      this.Text = nameof (FormPanel1);
      this.Load += new EventHandler(this.FormPanel1_Load);
      this.panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.ResumeLayout(false);
    }
  }
}
