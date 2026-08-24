

using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormHistoryReminderSettings : Form
  {
    private IContainer components = (IContainer) null;
    private CheckedListBox checkedListBox1;
    private GlassButton btnSave;

    public FormHistoryReminderSettings() => this.InitializeComponent();

    public void getActionPipe()
    {
      try
      {
        string strError = "";
        string my_querry = "select DISTINCT ActionPipe from tblHistory ";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form history reminder settings.getActionPipe", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show(strError);
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          {
            if (row.Field<string>("ActionPipe") != null)
              this.checkedListBox1.Items.Add((object) row.Field<string>("ActionPipe"));
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form history reminder settings.getActionpipe outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getSelectedActionPipe()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblHistoryReminder";
        List<OleDbParameter> oleDbParameterList = new List<OleDbParameter>();
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form history reminder settings.getselecttedActionPipe", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show(strError);
        }
        else
        {
          List<int> intList = new List<int>();
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            foreach (string str in (ListBox.ObjectCollection) this.checkedListBox1.Items)
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              {
                if (row.Field<string>("history").Equals(str.ToString()))
                  intList.Add(this.checkedListBox1.Items.IndexOf((object) str.ToString()));
              }
            }
          }
          int count = this.checkedListBox1.Items.Count;
          for (int index = 0; index < count; ++index)
            this.checkedListBox1.SetItemChecked(index, false);
          foreach (int index in intList)
            this.checkedListBox1.SetItemChecked(index, true);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form history reminder settings.getselectedActionpipe", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormHistoryReminderSettings_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatButtonBlue(ref this.btnSave);
      this.checkedListBox1.ForeColor = Color.RoyalBlue;
      this.getActionPipe();
      this.getSelectedActionPipe();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.deleteHistory();
        string Newvalues = "";
        foreach (string menuItem in (ListBox.ObjectCollection) this.checkedListBox1.Items)
        {
          Newvalues = Newvalues + "\n" + menuItem;
          if (this.checkedListBox1.CheckedItems.Contains((object) menuItem))
            this.insertHistory(menuItem);
        }
        int num = (int) MessageBox.Show("Successfully saved");
        PawnManagementClass.InsertIntoHistory("HISTORY REMINDER SETTINGS", "HISTORY REMINDER SETTINGS CHANGED", "", Newvalues, FormMain.username, DateTime.Now.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form history reminderSettings.btnSave_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void insertHistory(string menuItem)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblHistoryReminder(history) values(@history)", new List<OleDbParameter>()
      {
        new OleDbParameter("menuItems", (object) menuItem)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form historyremindersettings.insertHistory", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void deleteHistory()
    {
      string strError = "";
      string my_querry = "delete from tblHistoryReminder";
      List<OleDbParameter> oleDbParameterList = new List<OleDbParameter>();
      string text = SQLHelper.RunCommand(my_querry, ref strError);
      if (!(text != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form historyreminderSettings.deleteHistory", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.checkedListBox1 = new CheckedListBox();
      this.btnSave = new GlassButton();
      this.SuspendLayout();
      this.checkedListBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new Point(12, 79);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new Size(327, 514);
      this.checkedListBox1.TabIndex = 0;
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSave.GlowColor = Color.White;
      ((ButtonBase) this.btnSave).Image = (Image) Resources.SAVE;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(167, 9);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(172, 59);
      ((Control) this.btnSave).TabIndex = 1;
      ((Control) this.btnSave).Text = "&SAVE";
      ((ButtonBase) this.btnSave).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(347, 616);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.checkedListBox1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = nameof (FormHistoryReminderSettings);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormHistoryReminderSettings);
      this.Load += new EventHandler(this.FormHistoryReminderSettings_Load);
      this.ResumeLayout(false);
    }
  }
}
