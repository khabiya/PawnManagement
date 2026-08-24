
using System.Drawing;

namespace System.Windows.Forms
{
  public static class Extensions
  {
    public static Rectangle Coordinates(this Control control)
    {
      Form topLevelControl = (Form) control.TopLevelControl;
      return control != topLevelControl ? topLevelControl.RectangleToClient(control.Parent.RectangleToScreen(control.Bounds)) : topLevelControl.ClientRectangle;
    }
  }
}
