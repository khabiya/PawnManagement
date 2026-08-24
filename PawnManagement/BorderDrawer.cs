
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class BorderDrawer
  {
    private Color borderColor = Color.Black;
    private static int WM_NCPAINT = 133;
    private static int WM_ERASEBKGND = 20;
    private static int WM_PAINT = 15;

    public void DrawBorder(ref Message message, int width, int height)
    {
      if (message.Msg != BorderDrawer.WM_NCPAINT && message.Msg != BorderDrawer.WM_ERASEBKGND && message.Msg != BorderDrawer.WM_PAINT)
        return;
      IntPtr dcEx = BorderDrawer.GetDCEx(message.HWnd, (IntPtr) 1, 33U);
      if (dcEx != IntPtr.Zero)
      {
        ControlPaint.DrawBorder(Graphics.FromHdc(dcEx), new Rectangle(0, 0, width, height), this.borderColor, ButtonBorderStyle.Solid);
        message.Result = (IntPtr) 1;
        BorderDrawer.ReleaseDC(message.HWnd, dcEx);
      }
    }

    public Color BorderColor
    {
      get => this.borderColor;
      set => this.borderColor = value;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
  }
}
