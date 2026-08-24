

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class Form8 : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private MenuStrip menuStrip1;
    private ToolStrip toolStrip1;

    public Form8() => this.InitializeComponent();

    private void Form8_Load(object sender, EventArgs e)
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
      this.panel1 = new Panel();
      this.menuStrip1 = new MenuStrip();
      this.toolStrip1 = new ToolStrip();
      this.SuspendLayout();
      this.panel1.Dock = DockStyle.Left;
      this.panel1.Location = new Point(0, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(200, 405);
      this.panel1.TabIndex = 1;
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(897, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      this.toolStrip1.Location = new Point(200, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(697, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(897, 429);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form8);
      this.Text = nameof (Form8);
      this.Load += new EventHandler(this.Form8_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
