

using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormMenusettin : Form
  {
    private List<string> MenuItems = new List<string>();
    private IContainer components = (IContainer) null;
    private Label label1;
    private GlassButton glassButton3;
    private GlassButton glassButton2;
    private TextBox tbxMemberId;
    private GlassButton glassButton1;
    private CheckedListBox checkedListBox1;
    private Panel panel2;
    private ComboBox cbMenuSettingOnOrOff;
    private ComboBox cbMemberType;

    public FormMenusettin() => this.InitializeComponent();

    public FormMenusettin(List<string> menuitems)
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

    private void FormMenusettin_Load(object sender, EventArgs e)
    {
      try
      {
        this.cbMenuSettingOnOrOff.Text = FormMain.strMenuSetting;
        if (!(FormMain.strMenuSetting == "ON"))
          return;
        List<string> stringList = new List<string>();
        this.cbMemberType.Items.AddRange((object[]) MemberTypesMasterClass.getAllTheMemberTypes().ToArray());
        foreach (object menuItem in this.MenuItems)
          this.checkedListBox1.Items.Add(menuItem);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.FormSettings_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void mainLoad(object sender, WaitWindowEventArgs e)
    {
      foreach (string menuItem in (ListBox.ObjectCollection) this.checkedListBox1.Items)
      {
        if (this.checkedListBox1.CheckedItems.Contains((object) menuItem))
          this.insertMenuItems(menuItem);
      }
      int num = (int) MessageBox.Show("Successfully saved");
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      try
      {
        SettingsClass.UpdateMenusetting(this.cbMenuSettingOnOrOff.Text);
        FormMain.strMenuSetting = this.cbMenuSettingOnOrOff.Text;
        ((Control) this.glassButton1).Enabled = false;
        if (!(this.tbxMemberId.Text.Trim() != ""))
          return;
        if (this.tbxMemberId.Text.Trim().Equals("1"))
          this.selectAll();
        this.deleteMenuItems();
        foreach (string menuItem in (ListBox.ObjectCollection) this.checkedListBox1.Items)
        {
          if (this.checkedListBox1.CheckedItems.Contains((object) menuItem))
            this.insertMenuItems(menuItem);
        }
        ((Control) this.glassButton1).Enabled = true;
        int num = (int) MessageBox.Show("Successfully saved");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

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

    private void deleteMenuItems()
    {
      List<string> stringList = new List<string>();
      DateTime now;
      try
      {
        string strError = "";
        string my_querry = "select * from tblMenuSettings";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("form Settings.getMenuItems", MessageAnDStackTrace, username, CreatedOn);
          int num = (int) MessageBox.Show(strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            row["menuitems"] = (object) PawnManagementClass.decrypt(row["menuitems"].ToString());
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          {
            if (row["menuitems"].ToString()[0].ToString() == this.tbxMemberId.Text)
              stringList.Add(row["ID"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.getMenuItems", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      foreach (string str in stringList)
      {
        string strError = "";
        string text = SQLHelper.RunCommand("delete from tblMenuSettings where Id = @Id", new List<OleDbParameter>()
        {
          new OleDbParameter("Id", (object) str)
        }, ref strError);
        if (!(text == "Done"))
        {
          string MessageAnDStackTrace = strError;
          string username = FormMain.username;
          now = DateTime.Now;
          string CreatedOn = now.ToString();
          PawnManagementClass.InsertIntoException("form settings.deletemenuitems", MessageAnDStackTrace, username, CreatedOn);
          int num = (int) MessageBox.Show(text);
        }
      }
    }

    private void insertMenuItems(string menuItem)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblMenuSettings (menuItems) values(@menuItems)", new List<OleDbParameter>()
      {
        new OleDbParameter("menuItems", (object) PawnManagementClass.encrypt(this.tbxMemberId.Text + menuItem))
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("formSettings.insertMenuItems(string menuItem)", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void getMenuItems()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblMenuSettings";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
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
            foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              row["menuitems"] = (object) PawnManagementClass.decrypt(row["menuitems"].ToString());
            foreach (string str in (ListBox.ObjectCollection) this.checkedListBox1.Items)
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              {
                if (row.Field<string>("menuitems").Equals(this.tbxMemberId.Text + str.ToString()))
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

    private void getMemberId()
    {
      try
      {
        this.tbxMemberId.Text = MemberTypesMasterClass.getMemberIdForThisType(this.cbMemberType.Text);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form settings.getMemeberType", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.checkedListBox1.Items.Count; ++index)
        this.checkedListBox1.SetItemChecked(index, true);
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.checkedListBox1.Items.Count; ++index)
        this.checkedListBox1.SetItemChecked(index, false);
    }

    private void cbMemberType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.getMemberId();
      this.getMenuItems();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormMenusettin));
      this.label1 = new Label();
      this.glassButton3 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxMemberId = new TextBox();
      this.glassButton1 = new GlassButton();
      this.checkedListBox1 = new CheckedListBox();
      this.panel2 = new Panel();
      this.cbMenuSettingOnOrOff = new ComboBox();
      this.cbMemberType = new ComboBox();
      this.SuspendLayout();
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(113, 638);
      this.label1.Name = "label1";
      this.label1.Size = new Size(129, 24);
      this.label1.TabIndex = 10;
      this.label1.Text = "Member Type";
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(81, 579);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(75, 23);
      ((Control) this.glassButton3).TabIndex = 12;
      ((Control) this.glassButton3).Text = "UnSelect All";
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(0, 579);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(75, 23);
      ((Control) this.glassButton2).TabIndex = 11;
      ((Control) this.glassButton2).Text = "Select All";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.tbxMemberId.Anchor = AnchorStyles.Top;
      this.tbxMemberId.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxMemberId.Location = new Point(473, 633);
      this.tbxMemberId.Name = "tbxMemberId";
      this.tbxMemberId.ReadOnly = true;
      this.tbxMemberId.Size = new Size(41, 29);
      this.tbxMemberId.TabIndex = 8;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(564, 622);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(93, 40);
      ((Control) this.glassButton1).TabIndex = 9;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.checkedListBox1.Anchor = AnchorStyles.Top;
      this.checkedListBox1.CheckOnClick = true;
      this.checkedListBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkedListBox1.ForeColor = Color.RoyalBlue;
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new Point(0, 65);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new Size(657, 508);
      this.checkedListBox1.TabIndex = 7;
      this.checkedListBox1.TabStop = false;
      this.checkedListBox1.ThreeDCheckBoxes = true;
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(657, 66);
      this.panel2.TabIndex = 13;
      this.cbMenuSettingOnOrOff.Anchor = AnchorStyles.Top;
      this.cbMenuSettingOnOrOff.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbMenuSettingOnOrOff.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMenuSettingOnOrOff.ForeColor = Color.RoyalBlue;
      this.cbMenuSettingOnOrOff.FormattingEnabled = true;
      this.cbMenuSettingOnOrOff.Items.AddRange(new object[2]
      {
        (object) "ON",
        (object) "OFF"
      });
      this.cbMenuSettingOnOrOff.Location = new Point(3, 630);
      this.cbMenuSettingOnOrOff.Name = "cbMenuSettingOnOrOff";
      this.cbMenuSettingOnOrOff.Size = new Size(104, 32);
      this.cbMenuSettingOnOrOff.TabIndex = 14;
      this.cbMemberType.Anchor = AnchorStyles.Top;
      this.cbMemberType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbMemberType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMemberType.ForeColor = Color.RoyalBlue;
      this.cbMemberType.FormattingEnabled = true;
      this.cbMemberType.Location = new Point(248, 630);
      this.cbMemberType.Name = "cbMemberType";
      this.cbMemberType.Size = new Size(219, 32);
      this.cbMemberType.TabIndex = 15;
      this.cbMemberType.SelectedIndexChanged += new EventHandler(this.cbMemberType_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(657, 674);
      this.Controls.Add((Control) this.cbMemberType);
      this.Controls.Add((Control) this.cbMenuSettingOnOrOff);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.glassButton3);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.tbxMemberId);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.checkedListBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormMenusettin);
      this.Text = nameof (FormMenusettin);
      this.Load += new EventHandler(this.FormMenusettin_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
