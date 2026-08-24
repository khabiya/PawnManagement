

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
  public class FormAdminPassword : Form
  {
    public static string AdminPassword = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxCureentPassword;
    private TextBox tbxNewPassword;
    private Label label1;
    private Label label2;
    private GlassButton glassButton1;

    public FormAdminPassword() => this.InitializeComponent();

    private void FormAdminPassword_Load(object sender, EventArgs e) => FormAdminPassword.AdminPassword = FormAdminPassword.getAdminPasswrod();

    public static string getAdminPasswrod()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("form billnumberseriessettings.getbillnumberseriessettings  " + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["AdminPassword"] != null && dataTable2.Rows[0]["AdminPassword"].ToString() != "")
        return dataTable2.Rows[0]["AdminPassword"].ToString();
      return "";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.tbxCureentPassword.Text == FormAdminPassword.AdminPassword)
        this.updateAdminPassword();
      else
        this.tbxCureentPassword.Select();
    }

    private void updateAdminPassword()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblSettings set AdminPassword = @AdminPassword", new List<OleDbParameter>()
      {
        new OleDbParameter("AdminPassword", (object) this.tbxNewPassword.Text)
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Successfully updated");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxCureentPassword = new TextBox();
      this.tbxNewPassword = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.glassButton1 = new GlassButton();
      this.SuspendLayout();
      this.tbxCureentPassword.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCureentPassword.Location = new Point(281, 23);
      this.tbxCureentPassword.Name = "tbxCureentPassword";
      this.tbxCureentPassword.Size = new Size(340, 38);
      this.tbxCureentPassword.TabIndex = 0;
      this.tbxNewPassword.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNewPassword.Location = new Point(281, 70);
      this.tbxNewPassword.Name = "tbxNewPassword";
      this.tbxNewPassword.Size = new Size(340, 38);
      this.tbxNewPassword.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(111, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(168, 25);
      this.label1.TabIndex = 2;
      this.label1.Text = "Current Password";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(142, 74);
      this.label2.Name = "label2";
      this.label2.Size = new Size(137, 25);
      this.label2.TabIndex = 3;
      this.label2.Text = "NewPassword";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(321, 124);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(211, 36);
      ((Control) this.glassButton1).TabIndex = 4;
      ((Control) this.glassButton1).Text = "&UPDATE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(733, 177);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.tbxNewPassword);
      this.Controls.Add((Control) this.tbxCureentPassword);
      this.Name = nameof (FormAdminPassword);
      this.Text = nameof (FormAdminPassword);
      this.Load += new EventHandler(this.FormAdminPassword_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
