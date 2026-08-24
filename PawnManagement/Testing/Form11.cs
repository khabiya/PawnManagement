
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class Form11 : Form
  {
    private IContainer components = (IContainer) null;

    public Form11() => this.InitializeComponent();

    private void Form11_Load(object sender, EventArgs e)
    {
    }

    private void parsing(string strString)
    {
      List<string> stringList = new List<string>();
      int lastMatch = 0;
      while (true)
      {
        string between = Form11.StringUtilities.GetBetween(strString, "<img id", "/>", lastMatch, out lastMatch);
        if (!(between == string.Empty))
          stringList.Add(between);
        else
          break;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Name = nameof (Form11);
      this.Text = nameof (Form11);
      this.Load += new EventHandler(this.Form11_Load);
      this.ResumeLayout(false);
    }

    public class StringUtilities
    {
      public static string GetBetween(
        string source,
        string start,
        string end,
        int startMatch,
        out int lastMatch)
      {
        int startIndex = source.IndexOf(start, startMatch);
        if (startIndex == -1)
        {
          lastMatch = -1;
          return string.Empty;
        }
        int num = source.IndexOf(end, startIndex + start.Length + 1);
        if (num == -1)
        {
          lastMatch = -1;
          return string.Empty;
        }
        lastMatch = num;
        int length = num - startIndex + end.Length;
        return source.Substring(startIndex, length);
      }

      public static void GetBetweenExcludeTokens(
        string source,
        string start,
        string searchEnd,
        ref int begin,
        out int end)
      {
        end = -1;
        begin = source.IndexOf(start, begin) + start.Length;
        if (begin == -1)
          return;
        end = source.IndexOf(searchEnd, begin);
      }

      public static string GetBetweenExcludeTokens(
        string source,
        string start,
        string end,
        int startMatch,
        out int lastMatch)
      {
        lastMatch = -1;
        int num = source.IndexOf(start, startMatch);
        if (num == -1)
          return string.Empty;
        int startIndex = num + start.Length;
        lastMatch = source.IndexOf(end, startIndex);
        return lastMatch == -1 ? string.Empty : source.Substring(startIndex, lastMatch - startIndex);
      }
    }
  }
}
