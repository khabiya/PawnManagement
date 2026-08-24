

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

namespace PawnManagement.Testing
{
  public class Form10 : Form
  {
    private const string STRING_SHORT = "Hello, World!";
    private const string STRING_LONG = "A longer piece of text.";
    private IContainer components = (IContainer) null;
    private TextBox textBox1;
    private Label lblTextTransition1;
    private Button button1;
    private Label lblTextTransition2;

    public Form10() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      string destinationValue1;
      Color destinationValue2;
      string destinationValue3;
      Color destinationValue4;
      if (this.lblTextTransition1.Text == "Hello, World!")
      {
        destinationValue1 = "A longer piece of text.";
        destinationValue2 = Color.Red;
        destinationValue3 = "Hello, World!";
        destinationValue4 = Color.Blue;
      }
      else
      {
        destinationValue1 = "Hello, World!";
        destinationValue2 = Color.Blue;
        destinationValue3 = "A longer piece of text.";
        destinationValue4 = Color.Red;
      }
      Transition transition = new Transition((ITransitionType) new TransitionType_Linear(1000));
      transition.add((object) this.lblTextTransition1, "Text", (object) destinationValue1);
      transition.add((object) this.lblTextTransition1, "ForeColor", (object) destinationValue2);
      transition.add((object) this.lblTextTransition2, "Text", (object) destinationValue3);
      transition.add((object) this.lblTextTransition2, "ForeColor", (object) destinationValue4);
      transition.run();
    }

    private void Form10_Load(object sender, EventArgs e)
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
      this.textBox1 = new TextBox();
      this.lblTextTransition1 = new Label();
      this.button1 = new Button();
      this.lblTextTransition2 = new Label();
      this.SuspendLayout();
      this.textBox1.Location = new Point(351, 210);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 0;
      this.lblTextTransition1.AutoSize = true;
      this.lblTextTransition1.Location = new Point(359, 124);
      this.lblTextTransition1.Name = "lblTextTransition1";
      this.lblTextTransition1.Size = new Size(35, 13);
      this.lblTextTransition1.TabIndex = 1;
      this.lblTextTransition1.Text = "label1";
      this.button1.Location = new Point(323, 66);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.lblTextTransition2.AutoSize = true;
      this.lblTextTransition2.Location = new Point(359, 163);
      this.lblTextTransition2.Name = "lblTextTransition2";
      this.lblTextTransition2.Size = new Size(35, 13);
      this.lblTextTransition2.TabIndex = 3;
      this.lblTextTransition2.Text = "label1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.lblTextTransition2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.lblTextTransition1);
      this.Controls.Add((Control) this.textBox1);
      this.Name = nameof (Form10);
      this.Text = nameof (Form10);
      this.Load += new EventHandler(this.Form10_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
