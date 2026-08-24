
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormErrorsJewelsReleasedButStillInBank : Form
  {
    private DataTable dtrefreshGrid = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;

    public FormErrorsJewelsReleasedButStillInBank() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select BankCode,BankSerialNumber, BillNumber,BillDate,CustomerCode,CustomerName,Type,NetWeight,Amount,presentValue,temp1 as interestRate,temp2 as Interest,temp3 as finalinterest,temp4 as redemptionamount  from tblpledge where redeemed = 'Y' and (BankCode is not null and BankCode <> '')", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form interest.refresGrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
      }
      else
      {
        if (this.dtrefreshGrid == null || this.dtrefreshGrid.Rows.Count <= 0)
          ;
        this.dataGridView1.DataSource = (object) this.dtrefreshGrid;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormErrorsJewelsReleasedButStillInBank_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
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
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 16);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(984, 604);
      this.dataGridView1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormErrorsJewelsReleasedButStillInBank);
      this.Text = "JewelsReleasedButStillInBank";
      this.Load += new EventHandler(this.FormErrorsJewelsReleasedButStillInBank_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
