
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OutlookStyleControls
{
  public class OutlookGrid : DataGridView
  {
    private IOutlookGridGroup groupTemplate;
    private Image iconCollapse;
    private Image iconExpand;
    private DataSourceManager dataSource;
    private IContainer components = (IContainer) null;

    public OutlookGrid()
    {
      this.InitializeComponent();
      this.RowTemplate = (DataGridViewRow) new OutlookGridRow();
      this.groupTemplate = (IOutlookGridGroup) new OutlookgGridDefaultGroup();
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewRow RowTemplate => base.RowTemplate;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IOutlookGridGroup GroupTemplate
    {
      get => this.groupTemplate;
      set => this.groupTemplate = value;
    }

    [Category("Appearance")]
    public Image CollapseIcon
    {
      get => this.iconCollapse;
      set => this.iconCollapse = value;
    }

    [Category("Appearance")]
    public Image ExpandIcon
    {
      get => this.iconExpand;
      set => this.iconExpand = value;
    }

    public new object DataSource => this.dataSource == null || this.dataSource.DataSource.Equals((object) this) ? (object) null : this.dataSource.DataSource;

    public void CollapseAll() => this.SetGroupCollapse(true);

    public void ExpandAll() => this.SetGroupCollapse(false);

    public void ClearGroups()
    {
      this.groupTemplate.Column = (DataGridViewColumn) null;
      this.FillGrid((IOutlookGridGroup) null);
    }

    public void BindData(object dataSource, string dataMember)
    {
      this.DataMember = this.DataMember;
      if (dataSource == null)
      {
        this.dataSource = (DataSourceManager) null;
        this.Columns.Clear();
      }
      else
      {
        this.dataSource = new DataSourceManager(dataSource, dataMember);
        this.SetupColumns();
        this.FillGrid((IOutlookGridGroup) null);
      }
    }

    public override void Sort(IComparer comparer)
    {
      if (this.dataSource == null)
        this.dataSource = new DataSourceManager((object) this, (string) null);
      this.dataSource.Sort(comparer);
      this.FillGrid(this.groupTemplate);
    }

    public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
    {
      if (this.dataSource == null)
        this.dataSource = new DataSourceManager((object) this, (string) null);
      this.dataSource.Sort((IComparer) new OutlookGridRowComparer(dataGridViewColumn.Index, direction));
      this.FillGrid(this.groupTemplate);
    }

    protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
    {
      if (((OutlookGridRow) this.Rows[e.RowIndex]).IsGroupRow)
        e.Cancel = true;
      else
        base.OnCellBeginEdit(e);
    }

    protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        OutlookGridRow row = (OutlookGridRow) this.Rows[e.RowIndex];
        if (row.IsGroupRow)
        {
          row.Group.Collapsed = !row.Group.Collapsed;
          row.Visible = false;
          row.Visible = true;
          return;
        }
      }
      this.OnCellClick(e);
    }

    protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex < 0)
        return;
      OutlookGridRow row = (OutlookGridRow) this.Rows[e.RowIndex];
      if (row.IsGroupRow && row.IsIconHit(e))
      {
        row.Group.Collapsed = !row.Group.Collapsed;
        row.Visible = false;
        row.Visible = true;
      }
      else
        base.OnCellMouseDown(e);
    }

    private void SetGroupCollapse(bool collapsed)
    {
      if (this.Rows.Count == 0 || this.groupTemplate == null)
        return;
      this.groupTemplate.Collapsed = collapsed;
      foreach (OutlookGridRow row in (IEnumerable) this.Rows)
      {
        if (row.IsGroupRow)
          row.Group.Collapsed = collapsed;
      }
      this.Rows[0].Visible = !this.Rows[0].Visible;
      this.Rows[0].Visible = !this.Rows[0].Visible;
    }

    private void SetupColumns()
    {
      this.Columns.Clear();
      if (this.dataSource == null || this.dataSource.Rows.Count <= 0)
        return;
      foreach (string column1 in this.dataSource.Columns)
      {
        DataGridViewColumn column2 = this.Columns[column1];
        this.Columns[column2 != null ? column2.Index : this.Columns.Add(column1, column1)].SortMode = DataGridViewColumnSortMode.Programmatic;
      }
    }

    private void FillGrid(IOutlookGridGroup groupingStyle)
    {
      this.Rows.Clear();
      if (this.dataSource == null)
        return;
      ArrayList rows = this.dataSource.Rows;
      if (rows.Count <= 0)
        return;
      if (groupingStyle == null)
      {
        foreach (DataSourceRow dataSourceRow in rows)
        {
          OutlookGridRow outlookGridRow = (OutlookGridRow) this.RowTemplate.Clone();
          foreach (object obj in (CollectionBase) dataSourceRow)
          {
            DataGridViewCell dataGridViewCell = (DataGridViewCell) new DataGridViewTextBoxCell();
            dataGridViewCell.Value = (object) obj.ToString();
            outlookGridRow.Cells.Add(dataGridViewCell);
          }
          this.Rows.Add((DataGridViewRow) outlookGridRow);
        }
      }
      else
      {
        IOutlookGridGroup outlookGridGroup = (IOutlookGridGroup) null;
        int num = 0;
        foreach (DataSourceRow dataSourceRow in rows)
        {
          OutlookGridRow outlookGridRow = (OutlookGridRow) this.RowTemplate.Clone();
          object obj1 = dataSourceRow[groupingStyle.Column.Index];
          if (outlookGridGroup != null && outlookGridGroup.CompareTo(obj1) == 0)
          {
            outlookGridRow.Group = outlookGridGroup;
            ++num;
          }
          else
          {
            if (outlookGridGroup != null)
              outlookGridGroup.ItemCount = num;
            outlookGridGroup = (IOutlookGridGroup) groupingStyle.Clone();
            outlookGridGroup.Value = obj1;
            outlookGridRow.Group = outlookGridGroup;
            outlookGridRow.IsGroupRow = true;
            outlookGridRow.Height = outlookGridGroup.Height;
            outlookGridRow.CreateCells((DataGridView) this, outlookGridGroup.Value);
            this.Rows.Add((DataGridViewRow) outlookGridRow);
            outlookGridRow = (OutlookGridRow) this.RowTemplate.Clone();
            outlookGridRow.Group = outlookGridGroup;
            num = 1;
          }
          foreach (object obj2 in (CollectionBase) dataSourceRow)
          {
            DataGridViewCell dataGridViewCell = (DataGridViewCell) new DataGridViewTextBoxCell();
            dataGridViewCell.Value = (object) obj2.ToString();
            outlookGridRow.Cells.Add(dataGridViewCell);
          }
          this.Rows.Add((DataGridViewRow) outlookGridRow);
          outlookGridGroup.ItemCount = num;
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();
  }
}
