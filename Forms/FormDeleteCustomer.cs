
using CSharpCustomPanelControl;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormDeleteCustomer : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private CustomPanel customPanel1;
    private Label label1;
    private ComboBox comboBox1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private Label label2;
    private Label label3;
    private Label label4;
    private CustomPanel customPanel2;

    public FormDeleteCustomer() => this.InitializeComponent();

    private void FormDeleteCustomer_Load(object sender, EventArgs e) => this.refreshGrid();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "SELECT * FROM tblcustomers WHERE CID not in (select distinct customerCode as cid from tblpledge) ";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form shopdetails.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching shop Details....\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
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
      this.customPanel1 = new CustomPanel();
      this.label1 = new Label();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.customPanel2 = new CustomPanel();
      this.comboBox1 = new ComboBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.customPanel1).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dataGridView1.ColumnHeadersHeight = 35;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(4, 80);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new Size(1001, 466);
      this.dataGridView1.TabIndex = 0;
      ((Control) this.customPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.customPanel1.BorderColor = Color.DarkGray;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.comboBox1);
      ((Control) this.customPanel1).Controls.Add((Control) this.label1);
      ((Control) this.customPanel1).Location = new Point(4, 4);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(1001, 38);
      ((Control) this.customPanel1).TabIndex = 1;
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(377, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(289, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "CUSTOMERS WITHOUT ANY PENDING PLEDGE";
      this.textBox1.Location = new Point(828, 553);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(177, 20);
      this.textBox1.TabIndex = 2;
      this.textBox2.Location = new Point(828, 579);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(177, 20);
      this.textBox2.TabIndex = 3;
      this.textBox3.Location = new Point(828, 605);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(177, 20);
      this.textBox3.TabIndex = 4;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(689, 557);
      this.label2.Name = "label2";
      this.label2.Size = new Size(135, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Total Number of Customers";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(689, 582);
      this.label3.Name = "label3";
      this.label3.Size = new Size(250, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Total Number of Customers Having Pending Pledge";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(687, 608);
      this.label4.Name = "label4";
      this.label4.Size = new Size(135, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Total Number of Customers";
      ((Control) this.customPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.customPanel2.BorderColor = Color.DarkGray;
      this.customPanel2.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel2).Location = new Point(4, 41);
      ((Control) this.customPanel2).Name = "customPanel2";
      ((Control) this.customPanel2).Size = new Size(1001, 38);
      ((Control) this.customPanel2).TabIndex = 2;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(672, 7);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(207, 21);
      this.comboBox1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 631);
      this.Controls.Add((Control) this.customPanel2);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.customPanel1);
      this.Name = nameof (FormDeleteCustomer);
      this.Load += new EventHandler(this.FormDeleteCustomer_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel1).PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
