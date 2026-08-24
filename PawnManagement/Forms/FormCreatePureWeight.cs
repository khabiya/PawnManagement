

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
  public class FormCreatePureWeight : Form
  {
    private IContainer components = (IContainer) null;
    private GlassButton glassButton1;
    private TextBox textBox1;

    public FormCreatePureWeight() => this.InitializeComponent();

    private void FormCreatePureWeight_Load(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!(this.textBox1.Text != "") || this.textBox1.Text.Length <= 0)
        return;
      WaitWindow.Show(new EventHandler<WaitWindowEventArgs>(this.updatePureWeight));
    }

    private void updatePureWeight(object sender, WaitWindowEventArgs e)
    {
      string strError = "";
      string my_querry = "Select * from tblpledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.updatePledge(dataTable2);
      }
      else
      {
        int num = (int) MessageBox.Show("DataBase Null ba");
      }
    }

    private void updatePledge(DataTable dt)
    {
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        string strError = "";
        string text = SQLHelper.RunCommand("update tblPledge set PureWeight = @PureWeight where BillNumber=@BillNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("PureWeight", (object) (double.Parse(row["NetWeight"].ToString()) * double.Parse(this.textBox1.Text) / 100.0)),
          new OleDbParameter("BillNumber", (object) row["BillNumber"].ToString())
        }, ref strError);
        if (text != "Done")
        {
          int num = (int) MessageBox.Show(text);
        }
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
      this.glassButton1 = new GlassButton();
      this.textBox1 = new TextBox();
      this.SuspendLayout();
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(50, 57);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(287, 44);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "UPDATE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.textBox1.Location = new Point(88, 20);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(203, 20);
      this.textBox1.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(359, 120);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.glassButton1);
      this.Name = nameof (FormCreatePureWeight);
      this.Text = nameof (FormCreatePureWeight);
      this.Load += new EventHandler(this.FormCreatePureWeight_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
