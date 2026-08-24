

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing2
{
  public class Form2 : Form
  {
    private IContainer components = (IContainer) null;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem customersToolStripMenuItem;
    private ToolStripMenuItem pledgeToolStripMenuItem;
    private ToolStripMenuItem redeemToolStripMenuItem;

    public Form2() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.menuStrip1 = new MenuStrip();
      this.customersToolStripMenuItem = new ToolStripMenuItem();
      this.pledgeToolStripMenuItem = new ToolStripMenuItem();
      this.redeemToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.customersToolStripMenuItem,
        (ToolStripItem) this.pledgeToolStripMenuItem,
        (ToolStripItem) this.redeemToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(800, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
      this.customersToolStripMenuItem.Size = new Size(74, 20);
      this.customersToolStripMenuItem.Text = "customers";
      this.pledgeToolStripMenuItem.Name = "pledgeToolStripMenuItem";
      this.pledgeToolStripMenuItem.Size = new Size(55, 20);
      this.pledgeToolStripMenuItem.Text = "Pledge";
      this.redeemToolStripMenuItem.Name = "redeemToolStripMenuItem";
      this.redeemToolStripMenuItem.Size = new Size(62, 20);
      this.redeemToolStripMenuItem.Text = "Redeem";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add((Control) this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form2);
      this.Text = nameof (Form2);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
