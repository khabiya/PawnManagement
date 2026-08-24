

using System;
using System.Collections.Generic;

namespace PawnManagement
{
  public class WaitWindowEventArgs : EventArgs
  {
    private WaitWindow _Window;
    private List<object> _Arguments;
    private object _Result;

    public WaitWindowEventArgs(WaitWindow GUI, List<object> args)
    {
      this._Window = GUI;
      this._Arguments = args;
    }

    public WaitWindow Window => this._Window;

    public List<object> Arguments => this._Arguments;

    public object Result
    {
      get => this._Result;
      set => this._Result = value;
    }
  }
}
