using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace JR.Utils.GUI.Forms
{
  public class FlexibleMessageBox
  {
    public static double MAX_WIDTH_FACTOR = 0.7;
    public static double MAX_HEIGHT_FACTOR = 0.9;
    public static Font FONT = SystemFonts.MessageBoxFont;

    public static DialogResult Show(string text) => FlexibleMessageBox.FlexibleMessageBoxForm.Show((IWin32Window) null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

    public static DialogResult Show(IWin32Window owner, string text) => FlexibleMessageBox.FlexibleMessageBoxForm.Show(owner, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

    public static DialogResult Show(string text, string caption) => FlexibleMessageBox.FlexibleMessageBoxForm.Show((IWin32Window) null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

    public static DialogResult Show(IWin32Window owner, string text, string caption) => FlexibleMessageBox.FlexibleMessageBoxForm.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons) => FlexibleMessageBox.FlexibleMessageBoxForm.Show((IWin32Window) null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

    public static DialogResult Show(
      IWin32Window owner,
      string text,
      string caption,
      MessageBoxButtons buttons)
    {
      return FlexibleMessageBox.FlexibleMessageBoxForm.Show(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
    }

    public static DialogResult Show(
      string text,
      string caption,
      MessageBoxButtons buttons,
      MessageBoxIcon icon)
    {
      return FlexibleMessageBox.FlexibleMessageBoxForm.Show((IWin32Window) null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
    }

    public static DialogResult Show(
      IWin32Window owner,
      string text,
      string caption,
      MessageBoxButtons buttons,
      MessageBoxIcon icon)
    {
      return FlexibleMessageBox.FlexibleMessageBoxForm.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
    }

    public static DialogResult Show(
      string text,
      string caption,
      MessageBoxButtons buttons,
      MessageBoxIcon icon,
      MessageBoxDefaultButton defaultButton)
    {
      return FlexibleMessageBox.FlexibleMessageBoxForm.Show((IWin32Window) null, text, caption, buttons, icon, defaultButton);
    }

    public static DialogResult Show(
      IWin32Window owner,
      string text,
      string caption,
      MessageBoxButtons buttons,
      MessageBoxIcon icon,
      MessageBoxDefaultButton defaultButton)
    {
      return FlexibleMessageBox.FlexibleMessageBoxForm.Show(owner, text, caption, buttons, icon, defaultButton);
    }

    private class FlexibleMessageBoxForm : Form
    {
      private IContainer components = (IContainer) null;
      private Button button1;
      private BindingSource FlexibleMessageBoxFormBindingSource;
      private RichTextBox richTextBoxMessage;
      private Panel panel1;
      private PictureBox pictureBoxForIcon;
      private Button button2;
      private Button button3;
      private static readonly string STANDARD_MESSAGEBOX_SEPARATOR_LINES = "---------------------------\n";
      private static readonly string STANDARD_MESSAGEBOX_SEPARATOR_SPACES = "   ";
      private static readonly string[] BUTTON_TEXTS_ENGLISH_EN = new string[7]
      {
        "OK",
        "Cancel",
        "&Yes",
        "&No",
        "&Abort",
        "&Retry",
        "&Ignore"
      };
      private static readonly string[] BUTTON_TEXTS_GERMAN_DE = new string[7]
      {
        "OK",
        "Abbrechen",
        "&Ja",
        "&Nein",
        "&Abbrechen",
        "&Wiederholen",
        "&Ignorieren"
      };
      private static readonly string[] BUTTON_TEXTS_SPANISH_ES = new string[7]
      {
        "Aceptar",
        "Cancelar",
        "&Sí",
        "&No",
        "&Abortar",
        "&Reintentar",
        "&Ignorar"
      };
      private static readonly string[] BUTTON_TEXTS_ITALIAN_IT = new string[7]
      {
        "OK",
        "Annulla",
        "&Sì",
        "&No",
        "&Interrompi",
        "&Riprova",
        "&Ignora"
      };
      private MessageBoxDefaultButton defaultButton;
      private int visibleButtonsCount;
      private FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID languageID = FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID.en;

      protected override void Dispose(bool disposing)
      {
        if (disposing && this.components != null)
          this.components.Dispose();
        base.Dispose(disposing);
      }

      private void InitializeComponent()
      {
        this.components = (IContainer) new Container();
        this.button1 = new Button();
        this.richTextBoxMessage = new RichTextBox();
        this.FlexibleMessageBoxFormBindingSource = new BindingSource(this.components);
        this.panel1 = new Panel();
        this.pictureBoxForIcon = new PictureBox();
        this.button2 = new Button();
        this.button3 = new Button();
        ((ISupportInitialize) this.FlexibleMessageBoxFormBindingSource).BeginInit();
        this.panel1.SuspendLayout();
        ((ISupportInitialize) this.pictureBoxForIcon).BeginInit();
        this.SuspendLayout();
        this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.button1.AutoSize = true;
        this.button1.DialogResult = DialogResult.OK;
        this.button1.Location = new Point(11, 67);
        this.button1.MinimumSize = new Size(0, 24);
        this.button1.Name = "button1";
        this.button1.Size = new Size(75, 24);
        this.button1.TabIndex = 2;
        this.button1.Text = "OK";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Visible = false;
        this.richTextBoxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.richTextBoxMessage.BackColor = Color.White;
        this.richTextBoxMessage.BorderStyle = BorderStyle.None;
        this.richTextBoxMessage.DataBindings.Add(new Binding("Text", (object) this.FlexibleMessageBoxFormBindingSource, "MessageText", true, DataSourceUpdateMode.OnPropertyChanged));
        this.richTextBoxMessage.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        this.richTextBoxMessage.Location = new Point(50, 26);
        this.richTextBoxMessage.Margin = new Padding(0);
        this.richTextBoxMessage.Name = "richTextBoxMessage";
        this.richTextBoxMessage.ReadOnly = true;
        this.richTextBoxMessage.ScrollBars = RichTextBoxScrollBars.Vertical;
        this.richTextBoxMessage.Size = new Size(200, 20);
        this.richTextBoxMessage.TabIndex = 0;
        this.richTextBoxMessage.TabStop = false;
        this.richTextBoxMessage.Text = "<Message>";
        this.richTextBoxMessage.LinkClicked += new LinkClickedEventHandler(this.richTextBoxMessage_LinkClicked);
        this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.panel1.BackColor = Color.White;
        this.panel1.Controls.Add((Control) this.pictureBoxForIcon);
        this.panel1.Controls.Add((Control) this.richTextBoxMessage);
        this.panel1.Location = new Point(-3, -4);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(268, 59);
        this.panel1.TabIndex = 1;
        this.pictureBoxForIcon.BackColor = Color.Transparent;
        this.pictureBoxForIcon.Location = new Point(15, 19);
        this.pictureBoxForIcon.Name = "pictureBoxForIcon";
        this.pictureBoxForIcon.Size = new Size(32, 32);
        this.pictureBoxForIcon.TabIndex = 8;
        this.pictureBoxForIcon.TabStop = false;
        this.button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.button2.DialogResult = DialogResult.OK;
        this.button2.Location = new Point(92, 67);
        this.button2.MinimumSize = new Size(0, 24);
        this.button2.Name = "button2";
        this.button2.Size = new Size(75, 24);
        this.button2.TabIndex = 3;
        this.button2.Text = "OK";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Visible = false;
        this.button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.button3.AutoSize = true;
        this.button3.DialogResult = DialogResult.OK;
        this.button3.Location = new Point(173, 67);
        this.button3.MinimumSize = new Size(0, 24);
        this.button3.Name = "button3";
        this.button3.Size = new Size(75, 24);
        this.button3.TabIndex = 0;
        this.button3.Text = "OK";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Visible = false;
        this.AutoScaleDimensions = new SizeF(6f, 13f);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(260, 102);
        this.Controls.Add((Control) this.button3);
        this.Controls.Add((Control) this.button2);
        this.Controls.Add((Control) this.panel1);
        this.Controls.Add((Control) this.button1);
        this.DataBindings.Add(new Binding("Text", (object) this.FlexibleMessageBoxFormBindingSource, "CaptionText", true));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new Size(276, 140);
        this.Name = nameof (FlexibleMessageBoxForm);
        this.ShowIcon = false;
        this.SizeGripStyle = SizeGripStyle.Show;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "<Caption>";
        this.Shown += new EventHandler(this.FlexibleMessageBoxForm_Shown);
        ((ISupportInitialize) this.FlexibleMessageBoxFormBindingSource).EndInit();
        this.panel1.ResumeLayout(false);
        ((ISupportInitialize) this.pictureBoxForIcon).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
      }

      private FlexibleMessageBoxForm()
      {
        this.InitializeComponent();
        Enum.TryParse<FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID>(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, out this.languageID);
        this.KeyPreview = true;
        this.KeyUp += new KeyEventHandler(this.FlexibleMessageBoxForm_KeyUp);
      }

      private static string[] GetStringRows(string message)
      {
        if (string.IsNullOrEmpty(message))
          return (string[]) null;
        return message.Split(new char[1]{ '\n' }, StringSplitOptions.None);
      }

      private string GetButtonText(
        FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID buttonID)
      {
        int int32 = Convert.ToInt32((object) buttonID);
        switch (this.languageID)
        {
          case FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID.de:
            return FlexibleMessageBox.FlexibleMessageBoxForm.BUTTON_TEXTS_GERMAN_DE[int32];
          case FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID.es:
            return FlexibleMessageBox.FlexibleMessageBoxForm.BUTTON_TEXTS_SPANISH_ES[int32];
          case FlexibleMessageBox.FlexibleMessageBoxForm.TwoLetterISOLanguageID.it:
            return FlexibleMessageBox.FlexibleMessageBoxForm.BUTTON_TEXTS_ITALIAN_IT[int32];
          default:
            return FlexibleMessageBox.FlexibleMessageBoxForm.BUTTON_TEXTS_ENGLISH_EN[int32];
        }
      }

      private static double GetCorrectedWorkingAreaFactor(double workingAreaFactor)
      {
        if (workingAreaFactor < 0.2)
          return 0.2;
        return workingAreaFactor > 1.0 ? 1.0 : workingAreaFactor;
      }

      private static void SetDialogStartPosition(
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm,
        IWin32Window owner)
      {
        if (owner != null)
          return;
        Screen screen = Screen.FromPoint(Cursor.Position);
        flexibleMessageBoxForm.StartPosition = FormStartPosition.Manual;
        flexibleMessageBoxForm.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - flexibleMessageBoxForm.Width / 2;
        flexibleMessageBoxForm.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - flexibleMessageBoxForm.Height / 2;
      }

      private static void SetDialogSizes(
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm,
        string text,
        string caption)
      {
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm1 = flexibleMessageBoxForm;
        Rectangle workingArea = SystemInformation.WorkingArea;
        int int32_1 = Convert.ToInt32((double) workingArea.Width * FlexibleMessageBox.FlexibleMessageBoxForm.GetCorrectedWorkingAreaFactor(FlexibleMessageBox.MAX_WIDTH_FACTOR));
        workingArea = SystemInformation.WorkingArea;
        int int32_2 = Convert.ToInt32((double) workingArea.Height * FlexibleMessageBox.FlexibleMessageBoxForm.GetCorrectedWorkingAreaFactor(FlexibleMessageBox.MAX_HEIGHT_FACTOR));
        Size size1 = new Size(int32_1, int32_2);
        flexibleMessageBoxForm1.MaximumSize = size1;
        string[] stringRows = FlexibleMessageBox.FlexibleMessageBoxForm.GetStringRows(text);
        if (stringRows == null)
          return;
        Size size2 = TextRenderer.MeasureText(text, FlexibleMessageBox.FONT);
        int height = size2.Height;
        int num1 = ((IEnumerable<string>) stringRows).Max<string>((Func<string, int>) (textForRow => TextRenderer.MeasureText(textForRow, FlexibleMessageBox.FONT).Width));
        size2 = TextRenderer.MeasureText(caption, SystemFonts.CaptionFont);
        int width = size2.Width;
        int num2 = Math.Max(num1 + 15, width);
        int num3 = flexibleMessageBoxForm.Width - flexibleMessageBoxForm.richTextBoxMessage.Width;
        int num4 = flexibleMessageBoxForm.Height - flexibleMessageBoxForm.richTextBoxMessage.Height;
        flexibleMessageBoxForm.Size = new Size(num2 + num3, height + num4);
      }

      private static void SetDialogIcon(
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm,
        MessageBoxIcon icon)
      {
        switch (icon)
        {
          case MessageBoxIcon.Hand:
            flexibleMessageBoxForm.pictureBoxForIcon.Image = (Image) SystemIcons.Error.ToBitmap();
            break;
          case MessageBoxIcon.Question:
            flexibleMessageBoxForm.pictureBoxForIcon.Image = (Image) SystemIcons.Question.ToBitmap();
            break;
          case MessageBoxIcon.Exclamation:
            flexibleMessageBoxForm.pictureBoxForIcon.Image = (Image) SystemIcons.Warning.ToBitmap();
            break;
          case MessageBoxIcon.Asterisk:
            flexibleMessageBoxForm.pictureBoxForIcon.Image = (Image) SystemIcons.Information.ToBitmap();
            break;
          default:
            flexibleMessageBoxForm.pictureBoxForIcon.Visible = false;
            flexibleMessageBoxForm.richTextBoxMessage.Left -= flexibleMessageBoxForm.pictureBoxForIcon.Width;
            flexibleMessageBoxForm.richTextBoxMessage.Width += flexibleMessageBoxForm.pictureBoxForIcon.Width;
            break;
        }
      }

      private static void SetDialogButtons(
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm,
        MessageBoxButtons buttons,
        MessageBoxDefaultButton defaultButton)
      {
        switch (buttons)
        {
          case MessageBoxButtons.OKCancel:
            flexibleMessageBoxForm.visibleButtonsCount = 2;
            flexibleMessageBoxForm.button2.Visible = true;
            flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.OK);
            flexibleMessageBoxForm.button2.DialogResult = DialogResult.OK;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.CANCEL);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel;
            flexibleMessageBoxForm.CancelButton = (IButtonControl) flexibleMessageBoxForm.button3;
            break;
          case MessageBoxButtons.AbortRetryIgnore:
            flexibleMessageBoxForm.visibleButtonsCount = 3;
            flexibleMessageBoxForm.button1.Visible = true;
            flexibleMessageBoxForm.button1.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.ABORT);
            flexibleMessageBoxForm.button1.DialogResult = DialogResult.Abort;
            flexibleMessageBoxForm.button2.Visible = true;
            flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.RETRY);
            flexibleMessageBoxForm.button2.DialogResult = DialogResult.Retry;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.IGNORE);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.Ignore;
            flexibleMessageBoxForm.ControlBox = false;
            break;
          case MessageBoxButtons.YesNoCancel:
            flexibleMessageBoxForm.visibleButtonsCount = 3;
            flexibleMessageBoxForm.button1.Visible = true;
            flexibleMessageBoxForm.button1.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.YES);
            flexibleMessageBoxForm.button1.DialogResult = DialogResult.Yes;
            flexibleMessageBoxForm.button2.Visible = true;
            flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.NO);
            flexibleMessageBoxForm.button2.DialogResult = DialogResult.No;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.CANCEL);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel;
            flexibleMessageBoxForm.CancelButton = (IButtonControl) flexibleMessageBoxForm.button3;
            break;
          case MessageBoxButtons.YesNo:
            flexibleMessageBoxForm.visibleButtonsCount = 2;
            flexibleMessageBoxForm.button2.Visible = true;
            flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.YES);
            flexibleMessageBoxForm.button2.DialogResult = DialogResult.Yes;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.NO);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.No;
            flexibleMessageBoxForm.ControlBox = false;
            break;
          case MessageBoxButtons.RetryCancel:
            flexibleMessageBoxForm.visibleButtonsCount = 2;
            flexibleMessageBoxForm.button2.Visible = true;
            flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.RETRY);
            flexibleMessageBoxForm.button2.DialogResult = DialogResult.Retry;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.CANCEL);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel;
            flexibleMessageBoxForm.CancelButton = (IButtonControl) flexibleMessageBoxForm.button3;
            break;
          default:
            flexibleMessageBoxForm.visibleButtonsCount = 1;
            flexibleMessageBoxForm.button3.Visible = true;
            flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(FlexibleMessageBox.FlexibleMessageBoxForm.ButtonID.OK);
            flexibleMessageBoxForm.button3.DialogResult = DialogResult.OK;
            flexibleMessageBoxForm.CancelButton = (IButtonControl) flexibleMessageBoxForm.button3;
            break;
        }
        flexibleMessageBoxForm.defaultButton = defaultButton;
      }

      private void FlexibleMessageBoxForm_Shown(object sender, EventArgs e)
      {
        int num;
        switch (this.defaultButton)
        {
          case MessageBoxDefaultButton.Button2:
            num = 2;
            break;
          case MessageBoxDefaultButton.Button3:
            num = 3;
            break;
          default:
            num = 1;
            break;
        }
        if (num > this.visibleButtonsCount)
          num = this.visibleButtonsCount;
        Button button;
        switch (num)
        {
          case 2:
            button = this.button2;
            break;
          case 3:
            button = this.button3;
            break;
          default:
            button = this.button1;
            break;
        }
        button.Focus();
      }

      private void richTextBoxMessage_LinkClicked(object sender, LinkClickedEventArgs e)
      {
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          Process.Start(e.LinkText);
        }
        catch (Exception ex)
        {
          throw;
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }

      private void FlexibleMessageBoxForm_KeyUp(object sender, KeyEventArgs e)
      {
        if (!e.Control || e.KeyCode != Keys.C && e.KeyCode != Keys.Insert)
          return;
        string str = (this.button1.Visible ? this.button1.Text + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty) + (this.button2.Visible ? this.button2.Text + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty) + (this.button3.Visible ? this.button3.Text + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty);
        Clipboard.SetText(FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_LINES + this.Text + Environment.NewLine + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_LINES + this.richTextBoxMessage.Text + Environment.NewLine + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_LINES + str.Replace("&", string.Empty) + Environment.NewLine + FlexibleMessageBox.FlexibleMessageBoxForm.STANDARD_MESSAGEBOX_SEPARATOR_LINES);
      }

      public string CaptionText { get; set; }

      public string MessageText { get; set; }

      public static DialogResult Show(
        IWin32Window owner,
        string text,
        string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton)
      {
        FlexibleMessageBox.FlexibleMessageBoxForm flexibleMessageBoxForm = new FlexibleMessageBox.FlexibleMessageBoxForm();
        flexibleMessageBoxForm.ShowInTaskbar = false;
        flexibleMessageBoxForm.CaptionText = caption;
        flexibleMessageBoxForm.MessageText = text;
        flexibleMessageBoxForm.FlexibleMessageBoxFormBindingSource.DataSource = (object) flexibleMessageBoxForm;
        FlexibleMessageBox.FlexibleMessageBoxForm.SetDialogButtons(flexibleMessageBoxForm, buttons, defaultButton);
        FlexibleMessageBox.FlexibleMessageBoxForm.SetDialogIcon(flexibleMessageBoxForm, icon);
        flexibleMessageBoxForm.Font = FlexibleMessageBox.FONT;
        flexibleMessageBoxForm.richTextBoxMessage.Font = FlexibleMessageBox.FONT;
        FlexibleMessageBox.FlexibleMessageBoxForm.SetDialogSizes(flexibleMessageBoxForm, text, caption);
        FlexibleMessageBox.FlexibleMessageBoxForm.SetDialogStartPosition(flexibleMessageBoxForm, owner);
        return flexibleMessageBoxForm.ShowDialog(owner);
      }

      private enum ButtonID
      {
        OK,
        CANCEL,
        YES,
        NO,
        ABORT,
        RETRY,
        IGNORE,
      }

      private enum TwoLetterISOLanguageID
      {
        en,
        de,
        es,
        it,
      }
    }
  }
}
