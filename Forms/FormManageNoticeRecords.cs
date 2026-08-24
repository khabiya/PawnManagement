

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormManageNoticeRecords : Form
  {
    private IContainer components = (IContainer) null;

    public FormManageNoticeRecords() => this.InitializeComponent();

    private void FormManageNoticeRecords_Load(object sender, EventArgs e)
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
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 261);
      this.Name = nameof (FormManageNoticeRecords);
      this.Text = nameof (FormManageNoticeRecords);
      this.Load += new EventHandler(this.FormManageNoticeRecords_Load);
      this.ResumeLayout(false);
    }
  }
}
