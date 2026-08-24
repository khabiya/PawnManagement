

using System;
using System.Threading;
using System.Windows.Forms;

namespace PawnManagement
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      try
      {
        Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new FormLoginOld());
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message + " ---- " + (object) ex.Data + " ----- " + ex.Source + " ----- " + ex.HelpLink);
      }
    }

    private static void CurrentDomain_UnhandledException(
      object sender,
      UnhandledExceptionEventArgs e)
    {
      int num = (int) MessageBox.Show("e.isterminating :" + e.IsTerminating.ToString());
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      int num = (int) MessageBox.Show("Message :" + e.Exception.Message + "Source : " + e.Exception.Source + "Stack :" + e.Exception.StackTrace + "HelpLink:  " + e.Exception.HelpLink);
    }
  }
}
