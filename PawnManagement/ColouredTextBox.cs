
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class ColouredTextBox : TextBox
  {
    private BorderDrawer borderDrawer = new BorderDrawer();

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
      this.borderDrawer.DrawBorder(ref m, this.Width, this.Height);
    }

    public Color BorderColor
    {
      get => this.borderDrawer.BorderColor;
      set
      {
        this.borderDrawer.BorderColor = value;
        this.Invalidate();
      }
    }
  }
}
