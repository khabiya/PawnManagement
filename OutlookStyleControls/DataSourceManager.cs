using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace OutlookStyleControls
{
  internal class DataSourceManager
  {
    private object dataSource;
    private string dataMember;
    public ArrayList Columns;
    public ArrayList Rows;

    public DataSourceManager(object dataSource, string dataMember)
    {
      this.dataSource = dataSource;
      this.dataMember = dataMember;
      this.InitManager();
    }

    public string DataMember => this.dataMember;

    public object DataSource => this.dataSource;

    private void InitManager()
    {
      if (this.dataSource is IListSource)
        this.InitDataSet();
      if (this.dataSource is IList)
        this.InitList();
      if (!(this.dataSource is OutlookGrid))
        return;
      this.InitGrid();
    }

    private void InitDataSet()
    {
      this.Columns = new ArrayList();
      this.Rows = new ArrayList();
      DataTable table = ((DataSet) this.dataSource).Tables[this.dataMember];
      foreach (DataColumn column in (InternalDataCollectionBase) table.Columns)
        this.Columns.Add((object) column.ColumnName);
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        DataSourceRow dataSourceRow = new DataSourceRow(this, (object) row);
        for (int columnIndex = 0; columnIndex < this.Columns.Count; ++columnIndex)
          dataSourceRow.Add(row[columnIndex]);
        this.Rows.Add((object) dataSourceRow);
      }
    }

    private void InitGrid()
    {
      this.Columns = new ArrayList();
      this.Rows = new ArrayList();
      OutlookGrid dataSource = (OutlookGrid) this.dataSource;
      foreach (DataGridViewColumn column in (BaseCollection) dataSource.Columns)
        this.Columns.Add((object) column.Name);
      foreach (OutlookGridRow row in (IEnumerable) dataSource.Rows)
      {
        if (!row.IsGroupRow && !row.IsNewRow)
        {
          DataSourceRow dataSourceRow = new DataSourceRow(this, (object) row);
          for (int index = 0; index < this.Columns.Count; ++index)
            dataSourceRow.Add(row.Cells[index].Value);
          this.Rows.Add((object) dataSourceRow);
        }
      }
    }

    private void InitList()
    {
      this.Columns = new ArrayList();
      this.Rows = new ArrayList();
      IList dataSource = (IList) this.dataSource;
      BindingFlags invokeAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty;
      PropertyInfo[] properties = dataSource[0].GetType().GetProperties();
      foreach (MemberInfo memberInfo in properties)
        this.Columns.Add((object) memberInfo.Name);
      foreach (object obj in (IEnumerable) dataSource)
      {
        DataSourceRow dataSourceRow = new DataSourceRow(this, obj);
        foreach (PropertyInfo propertyInfo in properties)
        {
          object val = obj.GetType().InvokeMember(propertyInfo.Name, invokeAttr, (Binder) null, obj, (object[]) null);
          dataSourceRow.Add(val);
        }
        this.Rows.Add((object) dataSourceRow);
      }
    }

    public void Sort(IComparer comparer) => this.Rows.Sort((IComparer) new DataSourceRowComparer(comparer));
  }
}
