
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OutlookStyleControls
{
  public class OutlookGridRow : DataGridViewRow
  {
    private bool isGroupRow;
    private IOutlookGridGroup group;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IOutlookGridGroup Group
    {
      get => this.group;
      set => this.group = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsGroupRow
    {
      get => this.isGroupRow;
      set => this.isGroupRow = value;
    }

    public OutlookGridRow()
      : this((IOutlookGridGroup) null, false)
    {
    }

    public OutlookGridRow(IOutlookGridGroup group)
      : this(group, false)
    {
    }

    public OutlookGridRow(IOutlookGridGroup group, bool isGroupRow)
    {
      this.group = group;
      this.isGroupRow = isGroupRow;
    }

    public override DataGridViewElementStates GetState(int rowIndex) => !this.IsGroupRow && this.group != null && this.group.Collapsed ? base.GetState(rowIndex) & DataGridViewElementStates.Selected : base.GetState(rowIndex);

    protected override void Paint(
      Graphics graphics,
      Rectangle clipBounds,
      Rectangle rowBounds,
      int rowIndex,
      DataGridViewElementStates rowState,
      bool isFirstDisplayedRow,
      bool isLastVisibleRow)
    {
      if (this.isGroupRow)
      {
        OutlookGrid dataGridView = (OutlookGrid) this.DataGridView;
        int num = dataGridView.RowHeadersVisible ? dataGridView.RowHeadersWidth : 0;
        Brush brush1 = (Brush) new SolidBrush(dataGridView.DefaultCellStyle.BackColor);
        Brush brush2 = (Brush) new SolidBrush(Color.FromKnownColor(KnownColor.GradientActiveCaption));
        int columnsWidth = dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
        dataGridView.GetRowDisplayRectangle(this.Index, true);
        graphics.FillRectangle(brush1, rowBounds.Left + num - dataGridView.HorizontalScrollingOffset, rowBounds.Top, columnsWidth, rowBounds.Height - 1);
        graphics.DrawString(this.group.Text, dataGridView.Font, Brushes.Black, (float) (num - dataGridView.HorizontalScrollingOffset + 23), (float) (rowBounds.Bottom - 18));
        graphics.FillRectangle(brush2, rowBounds.Left + num - dataGridView.HorizontalScrollingOffset, rowBounds.Bottom - 2, columnsWidth - 1, 2);
        if (dataGridView.CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical || dataGridView.CellBorderStyle == DataGridViewCellBorderStyle.Single)
          graphics.FillRectangle(brush2, rowBounds.Left + num - dataGridView.HorizontalScrollingOffset + columnsWidth - 1, rowBounds.Top, 1, rowBounds.Height);
        if (this.group.Collapsed)
        {
          if (dataGridView.ExpandIcon != null)
            graphics.DrawImage(dataGridView.ExpandIcon, rowBounds.Left + num - dataGridView.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
        }
        else if (dataGridView.CollapseIcon != null)
          graphics.DrawImage(dataGridView.CollapseIcon, rowBounds.Left + num - dataGridView.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
        brush1.Dispose();
        brush2.Dispose();
      }
      base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
    }

    protected override void PaintCells(
      Graphics graphics,
      Rectangle clipBounds,
      Rectangle rowBounds,
      int rowIndex,
      DataGridViewElementStates rowState,
      bool isFirstDisplayedRow,
      bool isLastVisibleRow,
      DataGridViewPaintParts paintParts)
    {
      if (this.isGroupRow)
        return;
      base.PaintCells(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts);
    }

    internal bool IsIconHit(DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex < 0)
        return false;
      OutlookGrid dataGridView = (OutlookGrid) this.DataGridView;
      Rectangle displayRectangle = dataGridView.GetRowDisplayRectangle(this.Index, false);
      int x = e.X;
      DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
      return this.isGroupRow && column.DisplayIndex == 0 && x > displayRectangle.Left + 4 && x < displayRectangle.Left + 16 && e.Y > displayRectangle.Height - 18 && e.Y < displayRectangle.Height - 7;
    }
  }
}
