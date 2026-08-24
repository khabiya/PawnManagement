
using System.Collections;

namespace OutlookStyleControls
{
  internal class DataSourceRow : CollectionBase
  {
    private DataSourceManager manager;
    private object boundItem;

    public DataSourceRow(DataSourceManager manager, object boundItem)
    {
      this.manager = manager;
      this.boundItem = boundItem;
    }

    public object this[int index] => this.List[index];

    public object BoundItem => this.boundItem;

    public int Add(object val) => this.List.Add(val);
  }
}
