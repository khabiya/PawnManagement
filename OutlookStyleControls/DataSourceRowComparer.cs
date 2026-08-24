

using System.Collections;

namespace OutlookStyleControls
{
  internal class DataSourceRowComparer : IComparer
  {
    private IComparer baseComparer;

    public DataSourceRowComparer(IComparer baseComparer) => this.baseComparer = baseComparer;

    public int Compare(object x, object y) => this.baseComparer.Compare(((DataSourceRow) x).BoundItem, ((DataSourceRow) y).BoundItem);
  }
}
