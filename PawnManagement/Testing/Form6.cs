

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class Form6 : Form
  {
    private IContainer components = (IContainer) null;
    private Button button1;

    public Form6() => this.InitializeComponent();

    private void button6_Click(object sender, EventArgs e)
    {
      string strError = "";
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      string my_querry = "select * from tblcustomers";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return;
      foreach (DataColumn column in (InternalDataCollectionBase) dataTable2.Columns)
        SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("update TBLCUSTOMERS set " + column.ColumnName + "= '' where " + column.ColumnName + " is null", new List<OleDbParameter>(), ref strError);
    }

    private void Form6_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.SuspendLayout();
      this.button1.Location = new Point(296, 165);
      this.button1.Name = "button1";
      this.button1.Size = new Size(304, 109);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button6_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(952, 526);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (Form6);
      this.Text = nameof (Form6);
      this.Load += new EventHandler(this.Form6_Load);
      this.ResumeLayout(false);
    }
  }
}
