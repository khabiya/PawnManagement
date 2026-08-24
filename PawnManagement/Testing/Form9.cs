
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class Form9 : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox textBox1;
    private Button button1;

    public Form9() => this.InitializeComponent();

    private void Form9_Load(object sender, EventArgs e)
    {
    }

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (!char.IsLetter(e.KeyChar) || !PawnManagementClass.stringContainALetter((sender as TextBox).Text))
              break;
            e.Handled = true;
            break;
          }
          e.Handled = true;
          break;
        case "DOUBLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (char.IsLetter(e.KeyChar) && PawnManagementClass.stringContainsHowManyLetter((sender as TextBox).Text) >= 2)
              e.Handled = true;
            if ((sender as TextBox).Text.Length < 2 && char.IsDigit(e.KeyChar))
              e.Handled = true;
          }
          else
            e.Handled = true;
          break;
      }
    }

    public static bool validateBillNumber(string BillNumber)
    {
      if (BillNumber == null || !(BillNumber != ""))
        return false;
      char c = BillNumber[0];
      if (BillNumber.Count<char>() != 6 || !(char.IsUpper(c) | c == '0'))
        return false;
      string str = BillNumber.Substring(1);
      if (str.Count<char>() <= 1)
        return false;
      int num = int.Parse(str);
      return !(num > 10000 | num < 1);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (Form9.validateBillNumber(this.textBox1.Text))
      {
        int num1 = (int) MessageBox.Show(this.textBox1.Text);
      }
      else
      {
        int num2 = (int) MessageBox.Show(this.textBox1.Text + "not valid");
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
      this.textBox1 = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.textBox1.Font = new Font("Microsoft Sans Serif", 48f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(311, 102);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(458, 80);
      this.textBox1.TabIndex = 0;
      this.textBox1.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.button1.Location = new Point(387, 214);
      this.button1.Name = "button1";
      this.button1.Size = new Size(304, 94);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 729);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.Name = nameof (Form9);
      this.Text = nameof (Form9);
      this.Load += new EventHandler(this.Form9_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
