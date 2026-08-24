

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormPasswordChecker : Form
  {
    public static bool password = false;
    private IContainer components = (IContainer) null;
    private TextBox textBox1;

    public FormPasswordChecker() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.textBox1.Text == "rameshkumar123")
        FormPasswordChecker.password = true;
      this.Close();
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
      this.SuspendLayout();
      this.textBox1.CharacterCasing = CharacterCasing.Lower;
      this.textBox1.Dock = DockStyle.Fill;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(0, 0);
      this.textBox1.Name = "textBox1";
      this.textBox1.PasswordChar = '*';
      this.textBox1.Size = new Size(553, 44);
      this.textBox1.TabIndex = 0;
      this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(553, 45);
      this.Controls.Add((Control) this.textBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormPasswordChecker);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormPasswordChecker);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
