
using Glass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PawnManagement
{
  public class formEncryptionDecryption : Form
  {
    private IContainer components = (IContainer) null;
    private SecureTextBox secureTextBox1;
    private GlassButton glassButton1;
    private TextBox textBox1;
    private ListBox listBox1;
    private ListBox listBox2;
    private TextBox textBox2;
    private GlassButton glassButton2;
    private TextBox textBox3;

    public formEncryptionDecryption() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      this.listBox1.Items.Add((object) AES.Encrypt(this.textBox1.Text, this.GetPasswordBytes()));
      this.textBox3.Text = AES.Encrypt(this.textBox1.Text, this.GetPasswordBytes());
      this.listBox1.Items.Add((object) AES.Encrypt(this.textBox1.Text, this.secureTextBox1.SecureText));
      this.textBox3.Text = AES.Encrypt(this.textBox1.Text, this.secureTextBox1.SecureText);
    }

    private unsafe byte[] GetPasswordBytes()
    {
      byte[] buffer = (byte[]) null;
      if (this.secureTextBox1.Text.Length == 0)
      {
        buffer = new byte[8]
        {
          (byte) 1,
          (byte) 2,
          (byte) 3,
          (byte) 4,
          (byte) 5,
          (byte) 6,
          (byte) 7,
          (byte) 8
        };
      }
      else
      {
        IntPtr globalAllocAnsi = Marshal.SecureStringToGlobalAllocAnsi(this.secureTextBox1.SecureText);
        try
        {
          byte* pointer = (byte*) globalAllocAnsi.ToPointer();
          byte* numPtr = pointer;
          do
            ;
          while (*numPtr++ > (byte) 0);
          int length = (int) (numPtr - pointer - 1L);
          buffer = new byte[length];
          for (int index = 0; index < length; ++index)
          {
            byte num = pointer[index];
            buffer[index] = num;
          }
        }
        finally
        {
          Marshal.ZeroFreeGlobalAllocAnsi(globalAllocAnsi);
        }
      }
      return SHA256.Create().ComputeHash(buffer);
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (this.textBox3.Text == "")
      {
        if (this.listBox1.Items.Count > 0 && this.listBox1.SelectedItem != null)
        {
          this.listBox2.Items.Add((object) AES.Decrypt(this.listBox1.SelectedItem.ToString(), this.GetPasswordBytes()));
          this.listBox2.Items.Add((object) AES.Decrypt(this.listBox1.SelectedItem.ToString(), this.secureTextBox1.SecureText));
          this.textBox2.Text = AES.Decrypt(this.textBox3.Text, this.secureTextBox1.SecureText);
        }
        else
        {
          int num = (int) MessageBox.Show("select a list item");
        }
      }
      else
      {
        this.listBox2.Items.Add((object) AES.Decrypt(this.textBox3.Text, this.GetPasswordBytes()));
        this.listBox2.Items.Add((object) AES.Decrypt(this.textBox3.Text, this.secureTextBox1.SecureText));
        this.textBox2.Text = AES.Decrypt(this.textBox3.Text, this.secureTextBox1.SecureText);
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
      SecureString secureString = new SecureString();
      this.glassButton1 = new GlassButton();
      this.textBox1 = new TextBox();
      this.listBox1 = new ListBox();
      this.listBox2 = new ListBox();
      this.textBox2 = new TextBox();
      this.glassButton2 = new GlassButton();
      this.secureTextBox1 = new SecureTextBox();
      this.textBox3 = new TextBox();
      this.SuspendLayout();
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(22, 86);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(458, 67);
      ((Control) this.glassButton1).TabIndex = 3;
      ((Control) this.glassButton1).Text = "glassButton1";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.textBox1.Location = new Point(22, 56);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(458, 20);
      this.textBox1.TabIndex = 2;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(22, 159);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(458, 316);
      this.listBox1.TabIndex = 4;
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new Point(495, 56);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new Size(458, 303);
      this.listBox2.TabIndex = 7;
      this.textBox2.Location = new Point(495, 381);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(458, 20);
      this.textBox2.TabIndex = 6;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(573, 407);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(278, 67);
      ((Control) this.glassButton2).TabIndex = 8;
      ((Control) this.glassButton2).Text = "glassButton2";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.secureTextBox1.BorderStyle = BorderStyle.FixedSingle;
      this.secureTextBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.secureTextBox1.Location = new Point((int) byte.MaxValue, 12);
      this.secureTextBox1.Name = "secureTextBox1";
      this.secureTextBox1.SecureText = secureString;
      this.secureTextBox1.Size = new Size(458, 31);
      this.secureTextBox1.TabIndex = 0;
      this.secureTextBox1.UseSystemPasswordChar = true;
      this.textBox3.Location = new Point(22, 480);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(458, 20);
      this.textBox3.TabIndex = 9;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.listBox2);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.secureTextBox1);
      this.Name = nameof (formEncryptionDecryption);
      this.Text = "Form1";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
