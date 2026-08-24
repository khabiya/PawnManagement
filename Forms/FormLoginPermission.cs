
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormLoginPermission : Form
  {
    public static string strLoginName = "";
    private IContainer components = (IContainer) null;

    public FormLoginPermission() => this.InitializeComponent();

    private void ButtonClickOneEvent(object sender, EventArgs e)
    {
      if (!(sender is Button button))
        return;
      switch ((int) button.Tag)
      {
      }
    }

    private void FormLoginPermission_Load(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      DataTable basedOnThisColumn = LoginPermissionClass.getAllTheRecordsBasedOnThisColumn("UserName", FormLoginPermission.strLoginName);
      if (basedOnThisColumn != null && basedOnThisColumn.Columns.Count > 0)
      {
        basedOnThisColumn.Columns.Remove("EditedBy");
        basedOnThisColumn.Columns.Remove("EditedOn");
        basedOnThisColumn.Columns.Remove("CreatedBy");
        basedOnThisColumn.Columns.Remove("CreatedOn");
        basedOnThisColumn.Columns.Remove("ID");
      }
      if (basedOnThisColumn == null || basedOnThisColumn.Rows.Count <= 0)
        return;
      int num = 0;
      foreach (DataColumn column in (InternalDataCollectionBase) basedOnThisColumn.Columns)
      {
        ComboBox comboBox = new ComboBox();
        comboBox.Items.Add((object) "ALLOW");
        comboBox.Items.Add((object) "SHOW SOME ERROR");
        comboBox.Items.Add((object) "ASK FOR PASSWORD");
        comboBox.DropDownStyle = ComboBoxStyle.DropDown;
        comboBox.Name = column.ColumnName;
        comboBox.SelectedIndex = 0;
        int y = 30 * num++ + 10;
        comboBox.Location = new Point(100, y);
        Label label = new Label();
        label.Text = column.ColumnName;
        label.Location = new Point(2, y);
        this.Controls.Add((Control) comboBox);
        this.Controls.Add((Control) label);
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
      this.ClientSize = new Size(611, 746);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormLoginPermission);
      this.Text = nameof (FormLoginPermission);
      this.Load += new EventHandler(this.FormLoginPermission_Load);
      this.ResumeLayout(false);
    }
  }
}
