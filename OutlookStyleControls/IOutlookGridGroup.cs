
using System;
using System.Windows.Forms;

namespace OutlookStyleControls
{
  public interface IOutlookGridGroup : IComparable, ICloneable
  {
    string Text { get; set; }

    object Value { get; set; }

    bool Collapsed { get; set; }

    DataGridViewColumn Column { get; set; }

    int ItemCount { get; set; }

    int Height { get; set; }
  }
}
