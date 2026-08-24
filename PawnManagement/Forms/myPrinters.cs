

using System.Runtime.InteropServices;

namespace PawnManagement.Forms
{
  public static class myPrinters
  {
    [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetDefaultPrinter(string Name);
  }
}
