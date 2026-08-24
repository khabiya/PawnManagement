
using System;
using System.Windows.Forms;

namespace OutlookStyleControls
{
  public class OutlookgGridDefaultGroup : IOutlookGridGroup, IComparable, ICloneable
  {
    protected object val;
    protected string text;
    protected bool collapsed;
    protected DataGridViewColumn column;
    protected int itemCount;
    protected int height;

    public OutlookgGridDefaultGroup()
    {
      this.val = (object) null;
      this.column = (DataGridViewColumn) null;
      this.height = 34;
    }

    public virtual string Text
    {
      get => this.column == null ? string.Format("Unbound group: {0} ({1})", (object) this.Value.ToString(), this.itemCount == 1 ? (object) "1 item" : (object) (this.itemCount.ToString() + " items")) : string.Format("{0}: {1} ({2})", (object) this.column.HeaderText, (object) this.Value.ToString(), this.itemCount == 1 ? (object) "1 item" : (object) (this.itemCount.ToString() + " items"));
      set => this.text = value;
    }

    public virtual object Value
    {
      get => this.val;
      set => this.val = value;
    }

    public virtual bool Collapsed
    {
      get => this.collapsed;
      set => this.collapsed = value;
    }

    public virtual DataGridViewColumn Column
    {
      get => this.column;
      set => this.column = value;
    }

    public virtual int ItemCount
    {
      get => this.itemCount;
      set => this.itemCount = value;
    }

    public virtual int Height
    {
      get => this.height;
      set => this.height = value;
    }

    public virtual object Clone() => (object) new OutlookgGridDefaultGroup()
    {
      column = this.column,
      val = this.val,
      collapsed = this.collapsed,
      text = this.text,
      height = this.height
    };

    public virtual int CompareTo(object obj) => string.Compare(this.val.ToString(), obj.ToString());
  }
}
