
using System.Collections;
using System.ComponentModel;

namespace OutlookStyleControls
{
  internal class OutlookGridRowComparer : IComparer
  {
    private ListSortDirection direction;
    private int columnIndex;

    public OutlookGridRowComparer(int columnIndex, ListSortDirection direction)
    {
      this.columnIndex = columnIndex;
      this.direction = direction;
    }

    public int Compare(object x, object y)
    {
      OutlookGridRow outlookGridRow1 = (OutlookGridRow) x;
      OutlookGridRow outlookGridRow2 = (OutlookGridRow) y;
      return string.Compare(outlookGridRow1.Cells[this.columnIndex].Value.ToString(), outlookGridRow2.Cells[this.columnIndex].Value.ToString()) * (this.direction == ListSortDirection.Ascending ? 1 : -1);
    }
  }
}
