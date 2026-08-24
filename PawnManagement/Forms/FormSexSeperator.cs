

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormSexSeperator : Form
  {
    private int count = 0;
    private string strSex = "";
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private DataGridViewCheckBoxColumn colSelect;
    private Button button1;
    private TextBox textBox1;
    private Label label1;
    private ComboBox comboBox1;

    public FormSexSeperator() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormSexSeperator_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.refreshGrid();
      this.radioButton1.Checked = true;
    }

    private void refreshGrid()
    {
      if (this.comboBox1.Text == "")
        this.refreshGrid2();
      else
        this.refreshGrid3();
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.CurrentRow == null || this.dataGridView1.Rows.Count <= 0 || e.KeyCode != Keys.Return)
        return;
      if (this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["colSelect"].Value != null && bool.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["colSelect"].Value.ToString()))
        this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["colSelect"].Value = (object) false;
      else
        this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["colSelect"].Value = (object) true;
    }

    private void button1_Click(object sender, EventArgs e) => this.save();

    private void save()
    {
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["colSelect"].Value != null && bool.Parse(row.Cells["colSelect"].Value.ToString()))
          this.update(this.strSex, row.Cells["CID"].Value.ToString());
      }
      int num = (int) MessageBox.Show(this.count.ToString());
    }

    private void update(string strSex, string strCustomerCode)
    {
      string strError = "";
      string text = SQLHelper.RunCommand("update tblCustomers set Sex = @Sex where CID=@CID", new List<OleDbParameter>()
      {
        new OleDbParameter("Sex", (object) strSex),
        new OleDbParameter("CID", (object) strCustomerCode)
      }, ref strError);
      if (text.Equals("Done"))
      {
        ++this.count;
      }
      else
      {
        PawnManagementClass.InsertIntoException("Form EditCustomer.save", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(text);
      }
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton1.Checked)
      {
        this.strSex = "MALE";
      }
      else
      {
        if (!this.radioButton1.Checked)
          return;
        this.strSex = "FEMALE";
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e) => this.refreshGrid();

    private void refreshGrid2()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select top 100  * from tblCustomers where (sex  = '' OR SEX IS NULL) and cname like @CustomerName order by cid", new List<OleDbParameter>()
      {
        new OleDbParameter("CustomerName", (object) ("%" + this.textBox1.Text.Trim() + "%"))
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form searchCustomer  refreshgrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable;
    }

    private void refreshGrid3()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select top 100  * from tblCustomers where sex = '" + this.comboBox1.Text + "' and cname like @CustomerName order by cid", new List<OleDbParameter>()
      {
        new OleDbParameter("CustomerName", (object) ("%" + this.textBox1.Text.Trim() + "%"))
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form searchCustomer  refreshgrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable;
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton1.Checked)
      {
        this.strSex = "MALE";
      }
      else
      {
        if (!this.radioButton2.Checked)
          return;
        this.strSex = "FEMALE";
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
      this.dataGridView1 = new DataGridView();
      this.colSelect = new DataGridViewCheckBoxColumn();
      this.radioButton1 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.button1 = new Button();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colSelect);
      this.dataGridView1.Location = new Point(12, 54);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(980, 392);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.colSelect.HeaderText = "select";
      this.colSelect.Name = "colSelect";
      this.radioButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new Point(13, 466);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(54, 17);
      this.radioButton1.TabIndex = 1;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "MALE";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
      this.radioButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(104, 466);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(67, 17);
      this.radioButton2.TabIndex = 2;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "FEMALE";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.button1.Location = new Point(193, 461);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "change";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.textBox1.Location = new Point(85, 15);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(290, 20);
      this.textBox1.TabIndex = 4;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(16, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(61, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "FILTER BY";
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "MALE",
        (object) "FEMALE",
        (object) ""
      });
      this.comboBox1.Location = new Point(394, 15);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(121, 21);
      this.comboBox1.TabIndex = 6;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1004, 496);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.radioButton2);
      this.Controls.Add((Control) this.radioButton1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormSexSeperator);
      this.Text = nameof (FormSexSeperator);
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.FormSexSeperator_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
