

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormLicenseInformation : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox textBox1;

    public FormLicenseInformation() => this.InitializeComponent();

    private void FormLicenseInformation_Load(object sender, EventArgs e) => this.fetchDetails();

    private void fetchDetails() => this.textBox1.Text = ShopDetailsClass.getOldestCreatedLicenseDate();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.textBox1 = new TextBox();
      this.SuspendLayout();
      this.textBox1.Location = new Point(92, 73);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.textBox1);
      this.Name = nameof (FormLicenseInformation);
      this.Text = nameof (FormLicenseInformation);
      this.Load += new EventHandler(this.FormLicenseInformation_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
