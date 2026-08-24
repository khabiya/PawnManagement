
namespace OutlookStyleControls
{
  public class OutlookGridAlphabeticGroup : OutlookgGridDefaultGroup
  {
    public override string Text
    {
      get => string.Format("Alphabetic: {1} ({2})", (object) this.column.HeaderText, (object) this.Value.ToString(), this.itemCount == 1 ? (object) "1 item" : (object) (this.itemCount.ToString() + " items"));
      set => this.text = value;
    }

    public override object Value
    {
      get => this.val;
      set => this.val = (object) value.ToString().Substring(0, 1).ToUpper();
    }

    public override object Clone()
    {
      OutlookGridAlphabeticGroup gridAlphabeticGroup = new OutlookGridAlphabeticGroup();
      gridAlphabeticGroup.column = this.column;
      gridAlphabeticGroup.val = this.val;
      gridAlphabeticGroup.collapsed = this.collapsed;
      gridAlphabeticGroup.text = this.text;
      gridAlphabeticGroup.height = this.height;
      return (object) gridAlphabeticGroup;
    }

    public override int CompareTo(object obj) => string.Compare(this.val.ToString(), obj.ToString().Substring(0, 1).ToUpper());
  }
}
