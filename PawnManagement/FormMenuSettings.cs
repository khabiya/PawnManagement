

using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormMenuSettings : Form
  {
    private List<string> MenuItems = new List<string>();
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private IContainer components = (IContainer) null;
    private CheckedListBox checkedListBox1;
    private ComboBox comboBox1;
    private GlassButton glassButton1;
    private TextBox textBox1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private Label label1;

    public FormMenuSettings()
    {
      this.InitializeComponent();
      Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
    }

    public FormMenuSettings(List<string> menuitems)
    {
      this.MenuItems = menuitems;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormSettings_Load(object sender, EventArgs e)
    {
      try
      {
        this.populateMemberId();
        if (this.comboBox1.Items.Count > 0)
          this.comboBox1.SelectedIndex = 0;
        PawnManagementClass.formatButtonBlue(ref this.glassButton1);
        PawnManagementClass.formatButtonBlue(ref this.glassButton2);
        PawnManagementClass.formatButtonBlue(ref this.glassButton3);
        foreach (object menuItem in this.MenuItems)
          this.checkedListBox1.Items.Add(menuItem);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.FormSettings_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      try
      {
        if (!(this.comboBox1.Text.Trim() != ""))
          return;
        if (this.comboBox1.Text.Trim().Equals("1"))
          this.selectAll();
        this.deleteMenuItems();
        foreach (string menuItem in (ListBox.ObjectCollection) this.checkedListBox1.Items)
        {
          if (this.checkedListBox1.CheckedItems.Contains((object) menuItem))
            this.insertMenuItems(menuItem);
        }
        int num = (int) MessageBox.Show("Successfully saved");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void insertMenuItems(string menuItem)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblMenuSettings (menuItems) values(@menuItems)", new List<OleDbParameter>()
      {
        new OleDbParameter("menuItems", (object) menuItem)
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("formSettings.insertMenuItems(string menuItem)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void deleteMenuItems()
    {
      string strError = "";
      string text = SQLHelper.RunCommand("delete from tblMenuSettings where MemberId = @MemberId", new List<OleDbParameter>()
      {
        new OleDbParameter("MemberId", (object) this.comboBox1.Text.Trim().ToString())
      }, ref strError);
      if (text == "Done")
        return;
      PawnManagementClass.InsertIntoException("form settings.deletemenuitems", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show(text);
    }

    public void populateMemberId()
    {
      try
      {
        string strError = "";
        DataTable dataTable = SQLHelper.GetDataTable("select * from tblMemberType", ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("formSettings.populateMemberId", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show(strError);
        }
        else
        {
          int count = dataTable.Rows.Count;
          for (int index = 0; index < count; ++index)
            this.comboBox1.Items.Add((object) dataTable.Rows[index].Field<string>("MemberId"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formSettings.populateMemberId", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
      this.getMemberType();
      this.getMenuItems();
    }

    private void getMenuItems()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblMenuSettings where MemberId like @MemberId";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("MemberId", (object) this.comboBox1.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Settings.getMenuItems", strError, FormMain.username, DateTime.Now.ToString());
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
                if (row.Field<string>("menuitems").Equals(str.ToString()))
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
        PawnManagementClass.InsertIntoException("form settings.getMenuItems", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getMemberType()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblMemberType where MemberId like @MemberId";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter("MemberId", (object) this.comboBox1.Text.Trim().ToString()));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form Settings.getMemberType", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show(strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          this.textBox1.Text = dataTable2.Rows[0].Field<string>("memberType").ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.getMemeberType", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.selectAll();

    private void selectAll()
    {
      try
      {
        int count = this.checkedListBox1.Items.Count;
        for (int index = 0; index < count; ++index)
          this.checkedListBox1.SetItemChecked(index, true);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.selectall", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      try
      {
        int count = this.checkedListBox1.Items.Count;
        for (int index = 0; index < count; ++index)
          this.checkedListBox1.SetItemChecked(index, false);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.glassButton3_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void checkedListBox1_Click(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
      this.checkedListBox1 = new CheckedListBox();
      this.comboBox1 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.textBox1 = new TextBox();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.label1 = new Label();
      this.SuspendLayout();
      this.checkedListBox1.CheckOnClick = true;
      this.checkedListBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkedListBox1.ForeColor = Color.RoyalBlue;
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new Point(33, 63);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new Size(629, 532);
      this.checkedListBox1.TabIndex = 0;
      this.checkedListBox1.TabStop = false;
      this.checkedListBox1.ThreeDCheckBoxes = true;
      this.checkedListBox1.Click += new EventHandler(this.checkedListBox1_Click);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.ForeColor = Color.RoyalBlue;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(168, 16);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(74, 32);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.comboBox1.SelectedValueChanged += new EventHandler(this.comboBox1_SelectedValueChanged);
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(566, 15);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(93, 40);
      ((Control) this.glassButton1).TabIndex = 2;
      ((Control) this.glassButton1).Text = "SAVE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(318, 21);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(233, 29);
      this.textBox1.TabIndex = 1;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(32, 599);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(75, 23);
      ((Control) this.glassButton2).TabIndex = 4;
      ((Control) this.glassButton2).Text = "Select All";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(113, 599);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(75, 23);
      ((Control) this.glassButton3).TabIndex = 5;
      ((Control) this.glassButton3).Text = "UnSelect All";
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(33, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(129, 24);
      this.label1.TabIndex = 3;
      this.label1.Text = "Member Type";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(682, 632);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.glassButton3);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.checkedListBox1);
      this.ForeColor = Color.RoyalBlue;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormMenuSettings);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Menu Settings";
      this.Load += new EventHandler(this.FormSettings_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
