
using Glass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.JewelleryForms
{
  public class FormSettings : Form
  {
    private IContainer components = (IContainer) null;
    private ComboBox cbPrintCustomerCopy;
    private Label label7;
    private ComboBox cbPrintOfficeCopy;
    private Label label6;
    private GlassButton glassButton19;
    private Label label4;
    private Label label1;
    private ComboBox cbCustomerCopy;
    private GlassButton glassButton1;
    private CheckBox checkBox1;
    private ComboBox cbOfficeCopy;
    private Panel panel1;
    private Panel panel2;

    public FormSettings() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormSettings_Load(object sender, EventArgs e)
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
      this.cbPrintCustomerCopy = new ComboBox();
      this.label7 = new Label();
      this.cbPrintOfficeCopy = new ComboBox();
      this.label6 = new Label();
      this.glassButton19 = new GlassButton();
      this.label4 = new Label();
      this.label1 = new Label();
      this.cbCustomerCopy = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.checkBox1 = new CheckBox();
      this.cbOfficeCopy = new ComboBox();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.cbPrintCustomerCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrintCustomerCopy.DropDownWidth = 800;
      this.cbPrintCustomerCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrintCustomerCopy.FormattingEnabled = true;
      this.cbPrintCustomerCopy.Items.AddRange(new object[2]
      {
        (object) "YES",
        (object) "NO"
      });
      this.cbPrintCustomerCopy.Location = new Point(866, 87);
      this.cbPrintCustomerCopy.Name = "cbPrintCustomerCopy";
      this.cbPrintCustomerCopy.Size = new Size(111, 28);
      this.cbPrintCustomerCopy.TabIndex = 29;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 12f);
      this.label7.Location = new Point(797, 91);
      this.label7.Name = "label7";
      this.label7.Size = new Size(65, 20);
      this.label7.TabIndex = 28;
      this.label7.Text = "PRINT?";
      this.cbPrintOfficeCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbPrintOfficeCopy.DropDownWidth = 800;
      this.cbPrintOfficeCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPrintOfficeCopy.FormattingEnabled = true;
      this.cbPrintOfficeCopy.Items.AddRange(new object[2]
      {
        (object) "YES",
        (object) "NO"
      });
      this.cbPrintOfficeCopy.Location = new Point(866, 54);
      this.cbPrintOfficeCopy.Name = "cbPrintOfficeCopy";
      this.cbPrintOfficeCopy.Size = new Size(111, 28);
      this.cbPrintOfficeCopy.TabIndex = 27;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 12f);
      this.label6.Location = new Point(797, 58);
      this.label6.Name = "label6";
      this.label6.Size = new Size(65, 20);
      this.label6.TabIndex = 25;
      this.label6.Text = "PRINT?";
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(820, 133);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(76, 26);
      ((Control) this.glassButton19).TabIndex = 24;
      ((Control) this.glassButton19).Text = "REFRESH";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 12f);
      this.label4.Location = new Point(10, 90);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 20);
      this.label4.TabIndex = 23;
      this.label4.Text = "Cust copy";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f);
      this.label1.Location = new Point(5, 55);
      this.label1.Name = "label1";
      this.label1.Size = new Size(88, 20);
      this.label1.TabIndex = 22;
      this.label1.Text = "Office copy";
      this.cbCustomerCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbCustomerCopy.DropDownWidth = 800;
      this.cbCustomerCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbCustomerCopy.FormattingEnabled = true;
      this.cbCustomerCopy.Location = new Point(93, 87);
      this.cbCustomerCopy.Name = "cbCustomerCopy";
      this.cbCustomerCopy.Size = new Size(693, 28);
      this.cbCustomerCopy.TabIndex = 21;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(902, 133);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(76, 26);
      ((Control) this.glassButton1).TabIndex = 20;
      ((Control) this.glassButton1).Text = "SAVE";
      this.checkBox1.AutoSize = true;
      this.checkBox1.BackColor = Color.Transparent;
      this.checkBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox1.Location = new Point(715, 133);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(99, 29);
      this.checkBox1.TabIndex = 19;
      this.checkBox1.Text = "Prompt";
      this.checkBox1.UseVisualStyleBackColor = false;
      this.cbOfficeCopy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbOfficeCopy.DropDownWidth = 800;
      this.cbOfficeCopy.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbOfficeCopy.FormattingEnabled = true;
      this.cbOfficeCopy.Location = new Point(93, 53);
      this.cbOfficeCopy.Name = "cbOfficeCopy";
      this.cbOfficeCopy.Size = new Size(693, 28);
      this.cbOfficeCopy.TabIndex = 0;
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.cbPrintCustomerCopy);
      this.panel1.Controls.Add((Control) this.cbOfficeCopy);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.checkBox1);
      this.panel1.Controls.Add((Control) this.cbPrintOfficeCopy);
      this.panel1.Controls.Add((Control) this.glassButton1);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.cbCustomerCopy);
      this.panel1.Controls.Add((Control) this.glassButton19);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Location = new Point(8, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(988, 182);
      this.panel1.TabIndex = 78;
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(988, 35);
      this.panel2.TabIndex = 30;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 631);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormSettings);
      this.Text = nameof (FormSettings);
      this.Load += new EventHandler(this.FormSettings_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
