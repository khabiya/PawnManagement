

using Square;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class Form7 : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private SquareButton squareButton1;

    public Form7() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblPledge where ";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Biller.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching shop Details....\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void Form7_Load(object sender, EventArgs e)
    {
    }

    private void squareButton1_Click(object sender, EventArgs e)
    {
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
      this.squareButton1 = new SquareButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 313);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(842, 26);
      this.dataGridView1.TabIndex = 0;
      this.squareButton1.BackColor = Color.LightBlue;
      this.squareButton1.FadeOnFocus = true;
      this.squareButton1.ForeColor = Color.MediumBlue;
      this.squareButton1.ForeColorOnFocus = Color.Red;
      this.squareButton1.ForeColorOnLeave = Color.MediumBlue;
      this.squareButton1.GlowColor = Color.White;
      this.squareButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.squareButton1).Location = new Point(727, 345);
      ((Control) this.squareButton1).Name = "squareButton1";
      this.squareButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.squareButton1.ShineColor = Color.Transparent;
      ((Control) this.squareButton1).Size = new Size((int) sbyte.MaxValue, 23);
      ((Control) this.squareButton1).TabIndex = 1;
      ((Control) this.squareButton1).Text = "squareButton1";
      ((Control) this.squareButton1).Click += new EventHandler(this.squareButton1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(866, 380);
      this.Controls.Add((Control) this.squareButton1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (Form7);
      this.Text = nameof (Form7);
      this.Load += new EventHandler(this.Form7_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
