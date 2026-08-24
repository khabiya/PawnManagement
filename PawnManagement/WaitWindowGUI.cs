
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  internal class WaitWindowGUI : Form
  {
    private WaitWindow _Parent;
    internal object _Result;
    internal Exception _Error;
    private IAsyncResult threadResult;
    private IContainer components = (IContainer) null;
    public Label MessageLabel;
    private ProgressBar Marque;

    public WaitWindowGUI(WaitWindow parent)
    {
      this.InitializeComponent();
      this._Parent = parent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Flat);
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      WaitWindowGUI.FunctionInvoker<object> functionInvoker = new WaitWindowGUI.FunctionInvoker<object>(this.DoWork);
      this.threadResult = functionInvoker.BeginInvoke(new AsyncCallback(this.WorkComplete), (object) functionInvoker);
    }

    internal object DoWork()
    {
      WaitWindowEventArgs e = new WaitWindowEventArgs(this._Parent, this._Parent._Args);
      if (this._Parent._WorkerMethod != null)
        this._Parent._WorkerMethod((object) this, e);
      return e.Result;
    }

    private void WorkComplete(IAsyncResult results)
    {
      if (this.IsDisposed)
        return;
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new WaitWindow.MethodInvoker<IAsyncResult>(this.WorkComplete), (object) results);
      }
      else
      {
        try
        {
          this._Result = ((WaitWindowGUI.FunctionInvoker<object>) results.AsyncState).EndInvoke(results);
        }
        catch (Exception ex)
        {
          this._Error = ex;
        }
        this.Close();
      }
    }

    internal void SetMessage(string message) => this.MessageLabel.Text = message;

    internal void Cancel() => this.Invoke((Delegate) new MethodInvoker(((Form) this).Close), (object[]) null);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.Marque = new ProgressBar();
      this.MessageLabel = new Label();
      this.SuspendLayout();
      this.Marque.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Marque.BackColor = Color.MediumBlue;
      this.Marque.Location = new Point(12, 46);
      this.Marque.MarqueeAnimationSpeed = 1;
      this.Marque.Name = "Marque";
      this.Marque.Size = new Size(725, 24);
      this.Marque.Style = ProgressBarStyle.Marquee;
      this.Marque.TabIndex = 0;
      this.MessageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.MessageLabel.BackColor = Color.Transparent;
      this.MessageLabel.Font = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.MessageLabel.ForeColor = Color.DarkBlue;
      this.MessageLabel.Location = new Point(12, 12);
      this.MessageLabel.Name = "MessageLabel";
      this.MessageLabel.Size = new Size(725, 23);
      this.MessageLabel.TabIndex = 1;
      this.MessageLabel.Text = "Please wait ...";
      this.MessageLabel.TextAlign = ContentAlignment.MiddleLeft;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = SystemColors.WindowText;
      this.BackgroundImage = (Image) Resources.BLUEBACKGROUND;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(749, 84);
      this.Controls.Add((Control) this.MessageLabel);
      this.Controls.Add((Control) this.Marque);
      this.Font = new Font("Comic Sans MS", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.ForeColor = Color.RoyalBlue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (WaitWindowGUI);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (WaitWindowGUI);
      this.ResumeLayout(false);
    }

    private delegate T FunctionInvoker<T>();
  }
}
