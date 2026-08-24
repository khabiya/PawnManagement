

using System.Runtime.InteropServices;
using System.Security;

namespace System.Windows.Forms
{
  internal class SecureTextBox : TextBox
  {
    private SecureString _secureEntry = new SecureString();

    public SecureTextBox() => this.UseSystemPasswordChar = true;

    public SecureString SecureText
    {
      get => this._secureEntry;
      set => this._secureEntry = value;
    }

    public char[] CharacterData
    {
      get
      {
        char[] destination = new char[this._secureEntry.Length];
        IntPtr num = IntPtr.Zero;
        try
        {
          num = Marshal.SecureStringToGlobalAllocUnicode(this._secureEntry);
          destination = new char[this._secureEntry.Length];
          Marshal.Copy(num, destination, 0, this._secureEntry.Length);
        }
        finally
        {
          if (num != IntPtr.Zero)
            Marshal.ZeroFreeGlobalAllocUnicode(num);
        }
        return destination;
      }
    }

    public void SetPlaceholder(string placeHolder)
    {
      if (string.IsNullOrEmpty(placeHolder))
        return;
      foreach (char c in placeHolder.ToCharArray())
        this._secureEntry.AppendChar(c);
      this.Text = placeHolder;
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 769 || m.Msg == 768 || m.Msg == 770 || m.Msg == 123)
        return;
      base.WndProc(ref m);
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      try
      {
        int selectionStart = this.SelectionStart;
        if (e.KeyChar == '\b')
        {
          if (this.SelectionLength == 0 && selectionStart > 0 && selectionStart <= this._secureEntry.Length)
          {
            int index = selectionStart - 1;
            this._secureEntry.RemoveAt(index);
            this.Text = new string('*', this._secureEntry.Length);
            this.SelectionStart = index;
          }
          else if (this.SelectionLength > 0)
          {
            for (int index = 0; index < this.SelectionLength; ++index)
              this._secureEntry.RemoveAt(this.SelectionStart);
            this.Text = new string('*', this._secureEntry.Length);
            this.SelectionStart = selectionStart;
          }
          e.Handled = true;
          return;
        }
        if (!char.IsControl(e.KeyChar) && !char.IsHighSurrogate(e.KeyChar) && !char.IsLowSurrogate(e.KeyChar))
        {
          if (this.IsInputChar(e.KeyChar))
          {
            if (this.SelectionLength > 0)
            {
              for (int index = 0; index < this.SelectionLength; ++index)
                this._secureEntry.RemoveAt(this.SelectionStart);
            }
            if (selectionStart == this._secureEntry.Length)
              this._secureEntry.AppendChar(e.KeyChar);
            else
              this._secureEntry.InsertAt(selectionStart, e.KeyChar);
            this.Text = new string('*', this._secureEntry.Length);
            this.SelectionStart = selectionStart + 1;
            e.Handled = true;
            return;
          }
        }
      }
      catch (ArgumentOutOfRangeException ex)
      {
        this._HandleCritialFailure((Exception) ex);
      }
      base.OnKeyPress(e);
    }

    protected override bool IsInputKey(Keys keyData)
    {
      try
      {
        if ((keyData & Keys.Delete) == Keys.Delete)
        {
          if (this.SelectionLength == this._secureEntry.Length)
            this._secureEntry.Clear();
          else if (this.SelectionLength > 0)
          {
            for (int index = 0; index < this.SelectionLength; ++index)
              this._secureEntry.RemoveAt(this.SelectionStart);
          }
          else if ((keyData & Keys.Delete) == Keys.Delete && this.SelectionStart < this.Text.Length)
            this._secureEntry.RemoveAt(this.SelectionStart);
          return true;
        }
      }
      catch (ArgumentOutOfRangeException ex)
      {
        this._HandleCritialFailure((Exception) ex);
      }
      return base.IsInputKey(keyData);
    }

    private void _HandleCritialFailure(Exception e)
    {
      this._secureEntry.Clear();
      this.Text = string.Empty;
      int num = (int) MessageBox.Show("Secure password error: Reached critical endpoint: " + e.Message);
    }
  }
}
