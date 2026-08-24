

using Glass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormChangeToAes : Form
  {
    private DataTable dt = new DataTable();
    private DataTable dtRedemption = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;
    private GlassButton btn1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private ListBox listBox1;
    private ListBox listBox2;
    private Label label1;
    private GlassButton btn2;
    private GlassButton btn4;
    private GlassButton btn3;
    private GlassButton btn5;

    public FormChangeToAes() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormChangeToAes_Load(object sender, EventArgs e) => this.gettblRedemption();

    private void gettblPledge()
    {
      string strError = "";
      this.dt = SQLHelper.GetDataTable("select * from tblPledge", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form main.checkifpledgetableempty()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
      {
        int num = 0;
        foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
        {
          if (row["temp1"] != null && row["temp1"].ToString() != "" && row["temp1"].ToString() != "0")
          {
            ++num;
            row["temp1"] = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row["temp1"].ToString())));
          }
        }
        this.dataGridView1.DataSource = (object) this.dt;
        this.listBox1.Items.Add((object) ("n of rws temp1 :" + num.ToString()));
      }
    }

    private void gettblRedemption()
    {
      string strError = "";
      this.dtRedemption = SQLHelper.GetDataTable("select * from tblRedemption", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form main.checkifpledgetableempty()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
      {
        this.dataGridView2.DataSource = (object) this.dtRedemption;
        this.listBox2.Items.Add((object) ("n of rws " + (object) this.dataGridView2.Rows.Count));
      }
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.gettblPledge();

    private void updateTablePledge(
      string BillNumber,
      string temp1,
      string temp2,
      string temp3,
      string temp4,
      string temp5)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblPledge set temp1 = @temp1,temp2 = @temp2,temp3 = @temp3,temp4 = @temp4,temp5 = @temp5  where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (temp1), (object) temp1),
        new OleDbParameter(nameof (temp2), (object) temp2),
        new OleDbParameter(nameof (temp3), (object) temp3),
        new OleDbParameter(nameof (temp4), (object) temp4),
        new OleDbParameter(nameof (temp5), (object) temp5),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void updateTableRedemption(
      string BillNumber,
      string temp1,
      string temp2,
      string temp3,
      string temp4)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblRedemption set temp1 = @temp1,temp2 = @temp2,temp3 = @temp3,temp4 = @temp4  where BillNumber = @BillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (temp1), (object) temp1),
        new OleDbParameter(nameof (temp2), (object) temp2),
        new OleDbParameter(nameof (temp3), (object) temp3),
        new OleDbParameter(nameof (temp4), (object) temp4),
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form bank pledge.addInPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding entry in pledge table" + strError);
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        if (row.Cells["temp1"].Value != null && row.Cells["temp1"].Value.ToString() != "")
        {
          ++num;
          this.updateTablePledge(row.Cells["BillNumber"].Value.ToString(), row.Cells["temp1"].Value.ToString(), row.Cells["temp2"].Value.ToString(), row.Cells["temp3"].Value.ToString(), row.Cells["temp4"].Value.ToString(), row.Cells["temp5"].Value.ToString());
        }
      }
      this.listBox1.Items.Add((object) (num.ToString() + " updated"));
    }

    private void glassButton4_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView2.Rows)
      {
        if (row.Cells["temp1"].Value != null && row.Cells["temp1"].Value.ToString() != "" && row.Cells["temp1"].Value.ToString() != "0")
        {
          ++num;
          row.Cells["temp1"].Value = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row.Cells["temp1"].Value.ToString())));
        }
        if (row.Cells["temp2"].Value != null && row.Cells["temp2"].Value.ToString() != "" && row.Cells["temp2"].Value.ToString() != "0")
          row.Cells["temp2"].Value = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row.Cells["temp2"].Value.ToString())));
        if (row.Cells["temp3"].Value != null && row.Cells["temp3"].Value.ToString() != "" && row.Cells["temp3"].Value.ToString() != "0")
          row.Cells["temp3"].Value = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row.Cells["temp3"].Value.ToString())));
        if (row.Cells["temp4"].Value != null && row.Cells["temp4"].Value.ToString() != "" && row.Cells["temp4"].Value.ToString() != "0")
          row.Cells["temp4"].Value = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row.Cells["temp4"].Value.ToString())));
      }
      this.listBox2.Items.Add((object) num.ToString());
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView2.Rows)
      {
        if (row.Cells["temp1"].Value != null && row.Cells["temp1"].Value.ToString() != "")
        {
          ++num;
          this.updateTableRedemption(row.Cells["BillNumber"].Value.ToString(), row.Cells["temp1"].Value.ToString(), row.Cells["temp2"].Value.ToString(), row.Cells["temp3"].Value.ToString(), row.Cells["temp4"].Value.ToString());
        }
      }
      this.listBox2.Items.Add((object) num.ToString());
    }

    private void btn2_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["temp2"] != null && row["temp2"].ToString() != "" && row["temp2"].ToString() != "0")
        {
          ++num;
          row["temp2"] = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row["temp2"].ToString())));
        }
      }
      this.dataGridView1.DataSource = (object) this.dt;
      this.listBox1.Items.Add((object) ("n of rws temp2 :" + num.ToString()));
    }

    private void btn3_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["temp3"] != null && row["temp3"].ToString() != "" && row["temp3"].ToString() != "0")
        {
          ++num;
          row["temp3"] = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row["temp3"].ToString())));
        }
        this.dataGridView1.DataSource = (object) this.dt;
      }
      this.listBox1.Items.Add((object) ("n of rws temp3 :" + num.ToString()));
    }

    private void btn4_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["temp4"] != null && row["temp4"].ToString() != "" && row["temp4"].ToString() != "0")
        {
          ++num;
          row["temp4"] = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row["temp4"].ToString())));
        }
        this.dataGridView1.DataSource = (object) this.dt;
      }
      this.listBox1.Items.Add((object) ("n of rws temp4 :" + num.ToString()));
    }

    private void btn5_Click(object sender, EventArgs e)
    {
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["temp5"] != null && row["temp5"].ToString() != "" && row["temp5"].ToString() != "0")
        {
          ++num;
          row["temp5"] = (object) Convert.ToBase64String(Encoding.UTF8.GetBytes(PawnManagementClass.decrypt(row["temp5"].ToString())));
        }
        this.dataGridView1.DataSource = (object) this.dt;
      }
      this.listBox1.Items.Add((object) ("n of rws temp5 :" + num.ToString()));
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
      this.dataGridView2 = new DataGridView();
      this.btn1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.listBox1 = new ListBox();
      this.listBox2 = new ListBox();
      this.label1 = new Label();
      this.btn2 = new GlassButton();
      this.btn4 = new GlassButton();
      this.btn3 = new GlassButton();
      this.btn5 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 43);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new Size(860, 244);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new Point(12, 293);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.Size = new Size(860, 317);
      this.dataGridView2.TabIndex = 1;
      this.btn1.BackColor = Color.LightBlue;
      this.btn1.FadeOnFocus = true;
      this.btn1.ForeColor = Color.MediumBlue;
      this.btn1.ForeColorOnFocus = Color.Red;
      this.btn1.ForeColorOnLeave = Color.MediumBlue;
      this.btn1.GlowColor = Color.White;
      this.btn1.InnerBorderColor = Color.Transparent;
      ((Control) this.btn1).Location = new Point(310, 9);
      ((Control) this.btn1).Name = "btn1";
      this.btn1.OuterBorderColor = Color.MediumSlateBlue;
      this.btn1.ShineColor = Color.Transparent;
      ((Control) this.btn1).Size = new Size(118, 28);
      ((Control) this.btn1).TabIndex = 4;
      ((Control) this.btn1).Text = "1";
      ((Control) this.btn1).Click += new EventHandler(this.glassButton1_Click);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(878, 131);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(118, 48);
      ((Control) this.glassButton2).TabIndex = 5;
      ((Control) this.glassButton2).Text = "Update";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(878, 370);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(118, 48);
      ((Control) this.glassButton3).TabIndex = 7;
      ((Control) this.glassButton3).Text = "update";
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(878, 316);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(118, 48);
      ((Control) this.glassButton4).TabIndex = 6;
      ((Control) this.glassButton4).Text = "decrypt";
      ((Control) this.glassButton4).Click += new EventHandler(this.glassButton4_Click);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(878, 185);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(120, 121);
      this.listBox1.TabIndex = 8;
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new Point(878, 424);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new Size(120, 186);
      this.listBox2.TabIndex = 9;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(878, 52);
      this.label1.Name = "label1";
      this.label1.Size = new Size(35, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "label1";
      this.btn2.BackColor = Color.LightBlue;
      this.btn2.FadeOnFocus = true;
      this.btn2.ForeColor = Color.MediumBlue;
      this.btn2.ForeColorOnFocus = Color.Red;
      this.btn2.ForeColorOnLeave = Color.MediumBlue;
      this.btn2.GlowColor = Color.White;
      this.btn2.InnerBorderColor = Color.Transparent;
      ((Control) this.btn2).Location = new Point(444, 9);
      ((Control) this.btn2).Name = "btn2";
      this.btn2.OuterBorderColor = Color.MediumSlateBlue;
      this.btn2.ShineColor = Color.Transparent;
      ((Control) this.btn2).Size = new Size(118, 28);
      ((Control) this.btn2).TabIndex = 4;
      ((Control) this.btn2).Text = "2";
      ((Control) this.btn2).Click += new EventHandler(this.btn2_Click);
      this.btn4.BackColor = Color.LightBlue;
      this.btn4.FadeOnFocus = true;
      this.btn4.ForeColor = Color.MediumBlue;
      this.btn4.ForeColorOnFocus = Color.Red;
      this.btn4.ForeColorOnLeave = Color.MediumBlue;
      this.btn4.GlowColor = Color.White;
      this.btn4.InnerBorderColor = Color.Transparent;
      ((Control) this.btn4).Location = new Point(692, 9);
      ((Control) this.btn4).Name = "btn4";
      this.btn4.OuterBorderColor = Color.MediumSlateBlue;
      this.btn4.ShineColor = Color.Transparent;
      ((Control) this.btn4).Size = new Size(118, 28);
      ((Control) this.btn4).TabIndex = 4;
      ((Control) this.btn4).Text = "4";
      ((Control) this.btn4).Click += new EventHandler(this.btn4_Click);
      this.btn3.BackColor = Color.LightBlue;
      this.btn3.FadeOnFocus = true;
      this.btn3.ForeColor = Color.MediumBlue;
      this.btn3.ForeColorOnFocus = Color.Red;
      this.btn3.ForeColorOnLeave = Color.MediumBlue;
      this.btn3.GlowColor = Color.White;
      this.btn3.InnerBorderColor = Color.Transparent;
      ((Control) this.btn3).Location = new Point(568, 9);
      ((Control) this.btn3).Name = "btn3";
      this.btn3.OuterBorderColor = Color.MediumSlateBlue;
      this.btn3.ShineColor = Color.Transparent;
      ((Control) this.btn3).Size = new Size(118, 28);
      ((Control) this.btn3).TabIndex = 4;
      ((Control) this.btn3).Text = "3";
      ((Control) this.btn3).Click += new EventHandler(this.btn3_Click);
      this.btn5.BackColor = Color.LightBlue;
      this.btn5.FadeOnFocus = true;
      this.btn5.ForeColor = Color.MediumBlue;
      this.btn5.ForeColorOnFocus = Color.Red;
      this.btn5.ForeColorOnLeave = Color.MediumBlue;
      this.btn5.GlowColor = Color.White;
      this.btn5.InnerBorderColor = Color.Transparent;
      ((Control) this.btn5).Location = new Point(816, 9);
      ((Control) this.btn5).Name = "btn5";
      this.btn5.OuterBorderColor = Color.MediumSlateBlue;
      this.btn5.ShineColor = Color.Transparent;
      ((Control) this.btn5).Size = new Size(118, 28);
      ((Control) this.btn5).TabIndex = 11;
      ((Control) this.btn5).Text = "5";
      ((Control) this.btn5).Click += new EventHandler(this.btn5_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.btn5);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.listBox2);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.glassButton3);
      this.Controls.Add((Control) this.glassButton4);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.btn3);
      this.Controls.Add((Control) this.btn4);
      this.Controls.Add((Control) this.btn2);
      this.Controls.Add((Control) this.btn1);
      this.Controls.Add((Control) this.dataGridView2);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormChangeToAes);
      this.Text = nameof (FormChangeToAes);
      this.Load += new EventHandler(this.FormChangeToAes_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
