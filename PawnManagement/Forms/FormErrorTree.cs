
using ControlTreeView;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormErrorTree : Form
  {
    private IContainer components = (IContainer) null;
    private CTreeView ctvJamma;

    public FormErrorTree() => this.InitializeComponent();

    private void FormErrorTree_Load(object sender, EventArgs e)
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
      this.ctvJamma = new CTreeView();
      this.SuspendLayout();
      ((Control) this.ctvJamma).BackColor = Color.Azure;
      ((Panel) this.ctvJamma).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.ctvJamma).Dock = DockStyle.Fill;
      this.ctvJamma.DrawStyle = CTreeViewDrawStyle.LinearTree;
      ((Control) this.ctvJamma).ForeColor = Color.Maroon;
      this.ctvJamma.IndentDepth = 20;
      ((Control) this.ctvJamma).Location = new Point(0, 0);
      ((Control) this.ctvJamma).Name = "ctvJamma";
      ((Control) this.ctvJamma).Size = new Size(970, 477);
      ((Control) this.ctvJamma).TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(970, 477);
      this.Controls.Add((Control) this.ctvJamma);
      this.Name = nameof (FormErrorTree);
      this.Text = nameof (FormErrorTree);
      this.Load += new EventHandler(this.FormErrorTree_Load);
      this.ResumeLayout(false);
    }
  }
}
