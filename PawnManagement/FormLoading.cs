

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormLoading : Form
  {
    private bool flag;
    private IContainer components = (IContainer) null;
    private ProgressBar progressBar1;
    private Timer timer1;
    private Label label1;
    private Timer timer2;

    public FormLoading() => this.InitializeComponent();

    private void Form1_Load(object sender, EventArgs e) => this.flag = true;

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.progressBar1.Value < 99)
      {
        if (this.flag)
        {
          this.flag = false;
          this.label1.Text = "Loading.";
        }
        else
        {
          this.flag = true;
          this.label1.Text = "Loading...";
        }
        this.progressBar1.Value += 10;
        if (this.progressBar1.Value <= 50)
          return;
        this.timer2.Enabled = true;
        this.timer2.Start();
      }
      else
      {
        this.timer1.Stop();
        this.timer1.Enabled = false;
      }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.Opacity -= 0.03;
      if (this.Opacity > 0.0)
        return;
      this.timer2.Enabled = false;
      this.Visible = false;
      new FormLoginOld().Show();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormLoading));
      this.progressBar1 = new ProgressBar();
      this.timer1 = new Timer(this.components);
      this.label1 = new Label();
      this.timer2 = new Timer(this.components);
      this.SuspendLayout();
      this.progressBar1.BackColor = Color.Black;
      this.progressBar1.ForeColor = Color.Blue;
      this.progressBar1.Location = new Point(0, 277);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(504, 10);
      this.progressBar1.Style = ProgressBarStyle.Continuous;
      this.progressBar1.TabIndex = 0;
      this.timer1.Enabled = true;
      this.timer1.Interval = 300;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(7, 260);
      this.label1.Name = "label1";
      this.label1.Size = new Size(71, 15);
      this.label1.TabIndex = 1;
      this.label1.Text = "Loading ..";
      this.timer2.Interval = 50;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.AccessibleRole = AccessibleRole.TitleBar;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(504, 296);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "Form1";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
