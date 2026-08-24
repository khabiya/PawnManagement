

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PawnManagement
{
  public sealed class WaitWindow
  {
    private WaitWindowGUI _GUI;
    internal EventHandler<WaitWindowEventArgs> _WorkerMethod;
    internal List<object> _Args;

    public static object Show(EventHandler<WaitWindowEventArgs> workerMethod) => WaitWindow.Show(workerMethod, (string) null);

    public static object Show(EventHandler<WaitWindowEventArgs> workerMethod, string message) => new WaitWindow().Show(workerMethod, message, new List<object>());

    public static object Show(
      EventHandler<WaitWindowEventArgs> workerMethod,
      string message,
      params object[] args)
    {
      List<object> args1 = new List<object>();
      args1.AddRange((IEnumerable<object>) args);
      return new WaitWindow().Show(workerMethod, message, args1);
    }

    private WaitWindow()
    {
    }

    public string Message
    {
      set => this._GUI.Invoke((Delegate) new WaitWindow.MethodInvoker<string>(this._GUI.SetMessage), (object) value);
    }

    public void Cancel() => this._GUI.Invoke((Delegate) new MethodInvoker(this._GUI.Cancel), (object[]) null);

    private object Show(
      EventHandler<WaitWindowEventArgs> workerMethod,
      string message,
      List<object> args)
    {
      this._WorkerMethod = workerMethod != null ? workerMethod : throw new ArgumentException("No worker method has been specified.", nameof (workerMethod));
      this._Args = args;
      if (string.IsNullOrEmpty(message))
        message = "Please wait...";
      this._GUI = new WaitWindowGUI(this);
      this._GUI.MessageLabel.Text = message;
      int num = (int) this._GUI.ShowDialog();
      object result = this._GUI._Result;
      Exception error = this._GUI._Error;
      this._GUI.Dispose();
      return error != null ? result : result;
    }

    internal delegate void MethodInvoker<T>(T parameter1);
  }
}
