

using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormTestingDataGridView : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private GlassButton glassButton1;
    private FontDialog fontDialog1;
    private TextBox textBox1;
    private GlassButton glassButton2;

    public FormTestingDataGridView() => this.InitializeComponent();

    private void glassButton1_Click(object sender, EventArgs e)
    {
      FontDialog fontDialog = new FontDialog();
      int num1 = (int) fontDialog.ShowDialog();
      Font font = fontDialog.Font;
      this.textBox1.Font = font;
      string strError = "";
      string str = SQLHelper.RunCommand("update tblImage set Font = @Font", new List<OleDbParameter>()
      {
        new OleDbParameter("path", (object) font)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.insertpictureboxpath", strError, FormMain.username, DateTime.Now.ToString());
        int num2 = (int) MessageBox.Show("Error in insertingg the image path" + strError);
      }
      else if (str == "done")
      {
        int num3 = (int) MessageBox.Show("successfully changed");
      }
    }

    private void FormTestingDataGridView_Load(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select * from tblImage";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.getLanguage", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        ;
    }

    private void glassButton2_Click(object sender, EventArgs e)
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
      this.glassButton1 = new GlassButton();
      this.fontDialog1 = new FontDialog();
      this.textBox1 = new TextBox();
      this.glassButton2 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(984, 435);
      this.dataGridView1.TabIndex = 0;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(13, 454);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(130, 29);
      ((Control) this.glassButton1).TabIndex = 1;
      ((Control) this.glassButton1).Text = "Open Font";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.textBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(320, 487);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(197, 31);
      this.textBox1.TabIndex = 2;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(79, 527);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(130, 29);
      ((Control) this.glassButton2).TabIndex = 3;
      ((Control) this.glassButton2).Text = "Save Font";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormTestingDataGridView);
      this.Text = nameof (FormTestingDataGridView);
      this.Load += new EventHandler(this.FormTestingDataGridView_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
