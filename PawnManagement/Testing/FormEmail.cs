

using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class FormEmail : Form
  {
    private IContainer components = (IContainer) null;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox textBox1;
    private GlassButton glassButton3;
    private TextBox textBox2;
    private GlassButton glassButton4;

    public FormEmail() => this.InitializeComponent();

    private void FormEmail_Load(object sender, EventArgs e)
    {
    }

    private void sendEmail()
    {
      MailAddress from = new MailAddress("pawnstarramesh@gmail.com", "asdf");
      MailAddress to = new MailAddress("ramesh.kumar.knows@gmail.com", "Ramesh kumar.b");
      using (MailMessage message = new MailMessage(from, to)
      {
        Subject = "testing",
        Body = "Email BOdy"
      })
        new SmtpClient()
        {
          Host = "smtp.gmail.com",
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = ((ICredentialsByHost) new NetworkCredential(from.Address, "pawnstar12345"))
        }.Send(message);
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.sendEmail();

    private void glassButton2_Click(object sender, EventArgs e) => this.textBox1.Text = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " - " + CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern;

    private void glassButton3_Click(object sender, EventArgs e) => this.textBox2.Text = new Thread((ThreadStart) (() => { })).CurrentCulture.DateTimeFormat.ShortDatePattern;

    private void glassButton4_Click(object sender, EventArgs e)
    {
      if (((IEnumerable<string>) new string[16]
      {
        "dd/MM/yyyy",
        "d/M/yyyy",
        "dd/M/yyyy",
        "d/MM/yyyy",
        "dd/MM/yy",
        "d/M/yy",
        "dd/M/yy",
        "d/MM/yy",
        "dd-MM-yyyy",
        "d-M-yyyy",
        "dd-M-yyyy",
        "d-MM-yyyy",
        "dd-MM-yy",
        "d-M-yy",
        "dd-M-yy",
        "d-MM-yy"
      }).Contains<string>(this.textBox2.Text))
      {
        int num1 = (int) MessageBox.Show("OK");
      }
      else
      {
        int num2 = (int) MessageBox.Show(new Thread((ThreadStart) (() => { })).CurrentCulture.DateTimeFormat.ShortDatePattern);
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
      this.glassButton2 = new GlassButton();
      this.textBox1 = new TextBox();
      this.glassButton3 = new GlassButton();
      this.textBox2 = new TextBox();
      this.glassButton4 = new GlassButton();
      this.SuspendLayout();
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(421, 133);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(75, 23);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "glassButton1";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(132, 197);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size((int) sbyte.MaxValue, 23);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "glassButton2";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.textBox1.Location = new Point(314, 200);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(332, 20);
      this.textBox1.TabIndex = 2;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(207, 294);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size((int) sbyte.MaxValue, 23);
      ((Control) this.glassButton3).TabIndex = 3;
      ((Control) this.glassButton3).Text = "glassButton3";
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      this.textBox2.Location = new Point(358, 314);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(332, 20);
      this.textBox2.TabIndex = 4;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(421, 367);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size((int) sbyte.MaxValue, 23);
      ((Control) this.glassButton4).TabIndex = 5;
      ((Control) this.glassButton4).Text = "glassButton4";
      ((Control) this.glassButton4).Click += new EventHandler(this.glassButton4_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(735, 433);
      this.Controls.Add((Control) this.glassButton4);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.glassButton3);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.glassButton1);
      this.Name = nameof (FormEmail);
      this.Text = nameof (FormEmail);
      this.Load += new EventHandler(this.FormEmail_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
