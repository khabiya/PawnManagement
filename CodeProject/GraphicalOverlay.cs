
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace CodeProject
{
  public class GraphicalOverlay : Component
  {
    private Form form;
    private IContainer components = (IContainer) null;

    public event EventHandler<PaintEventArgs> Paint;

    public GraphicalOverlay() => this.InitializeComponent();

    public GraphicalOverlay(IContainer container)
    {
      container.Add((IComponent) this);
      this.InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Form Owner
    {
      get => this.form;
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.form = this.form == null ? value : throw new InvalidOperationException();
        this.form.Resize += new EventHandler(this.Form_Resize);
        this.ConnectPaintEventHandlers((Control) this.form);
      }
    }

    private void Form_Resize(object sender, EventArgs e) => this.form.Invalidate(true);

    private void ConnectPaintEventHandlers(Control control)
    {
      control.Paint -= new PaintEventHandler(this.Control_Paint);
      control.Paint += new PaintEventHandler(this.Control_Paint);
      control.ControlAdded -= new ControlEventHandler(this.Control_ControlAdded);
      control.ControlAdded += new ControlEventHandler(this.Control_ControlAdded);
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
        this.ConnectPaintEventHandlers(control1);
    }

    private void Control_ControlAdded(object sender, ControlEventArgs e) => this.ConnectPaintEventHandlers(e.Control);

    private void Control_Paint(object sender, PaintEventArgs e)
    {
      Control control = sender as Control;
      Point point = control != this.form ? this.form.PointToClient(control.Parent.PointToScreen(control.Location)) + new Size((control.Width - control.ClientSize.Width) / 2, (control.Height - control.ClientSize.Height) / 2) : control.Location;
      if (control != this.form)
        e.Graphics.TranslateTransform((float) -point.X, (float) -point.Y);
      this.OnPaint(sender, e);
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
      if (this.Paint == null)
        return;
      this.Paint(sender, e);
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
