
using System.ComponentModel;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormPledgeErrorFinder : Form
  {
    private IContainer components = (IContainer) null;

    public FormPledgeErrorFinder() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Text = nameof (FormPledgeErrorFinder);
    }
  }
}
