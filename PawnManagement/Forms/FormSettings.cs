

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormSettings : Form
  {
    private IContainer components = (IContainer) null;
    private HeaderPanel headerPanel14;
    private CheckBox cbRemindIfNameAndAddressSame;
    private GlassButton glassButton31;
    private GlassButton glassButton32;
    private HeaderPanel headerPanel1;
    private CheckBox cbRemindIfNameAddressAndDoorNumberSame;
    private GlassButton glassButton1;
    private GlassButton glassButton2;

    public FormSettings() => this.InitializeComponent();

    private void FormSettings_Load(object sender, EventArgs e) => this.gettblSettings();

    private void gettblSettings()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
        PawnManagementClass.InsertIntoException("form main.getIndividualWeight", strError, FormMain.username, DateTime.Now.ToString());
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.cbRemindIfNameAndAddressSame.Checked = dataTable2.Rows[0]["RemindIfNameAndAddressSame"] != null && dataTable2.Rows[0]["RemindIfNameAndAddressSame"].ToString() == "Y";
        this.cbRemindIfNameAddressAndDoorNumberSame.Checked = dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"] != null && dataTable2.Rows[0]["RemindIfNameAddressAndDoorNumberSame"].ToString() == "Y";
      }
    }

    private void cbReduceFirstMonthInterest_CheckedChanged(object sender, EventArgs e) => this.changeSettingsNameAndAddress();

    private void changeSettingsNameAndAddress()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set RemindIfNameAndAddressSame= @RemindIfNameAndAddressSame", new List<OleDbParameter>()
      {
        new OleDbParameter("RemindIfNameAndAddressSame", this.cbRemindIfNameAndAddressSame.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form billnumberseriessettings.setbillnumberseries()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void changeSettingsNameAndAddressAndDoorNumber()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set RemindIfNameAddressAndDoorNumberSame= @RemindIfNameAddressAndDoorNumberSame", new List<OleDbParameter>()
      {
        new OleDbParameter("RemindIfNameAddressAndDoorNumberSame", this.cbRemindIfNameAddressAndDoorNumberSame.Checked ? (object) "Y" : (object) "N")
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form billnumberseriessettings.setbillnumberseries()", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void cbRemindIfNameAddressAndDoorNumberSame_CheckedChanged(object sender, EventArgs e) => this.changeSettingsNameAndAddressAndDoorNumber();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.headerPanel14 = new HeaderPanel();
      this.cbRemindIfNameAndAddressSame = new CheckBox();
      this.glassButton31 = new GlassButton();
      this.glassButton32 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.cbRemindIfNameAddressAndDoorNumberSame = new CheckBox();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      ((Control) this.headerPanel14).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      ((Control) this.headerPanel14).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel14).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel14).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel14.BorderColor = SystemColors.HotTrack;
      this.headerPanel14.BorderStyle = BorderStyles.Single;
      this.headerPanel14.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel14.CaptionEndColor = Color.AliceBlue;
      this.headerPanel14.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.CaptionHeight = 22;
      this.headerPanel14.CaptionPosition = CaptionPositions.Top;
      this.headerPanel14.CaptionText = "REDUCE FIRST MONTH INTEREST?";
      this.headerPanel14.CaptionVisible = true;
      ((Control) this.headerPanel14).Controls.Add((Control) this.cbRemindIfNameAndAddressSame);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton31);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton32);
      ((Control) this.headerPanel14).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel14).ForeColor = Color.DarkBlue;
      this.headerPanel14.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.GradientEnd = SystemColors.ControlLight;
      this.headerPanel14.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel14).Location = new Point(12, 12);
      ((Control) this.headerPanel14).Name = "headerPanel14";
      this.headerPanel14.PanelIcon = (Icon) null;
      this.headerPanel14.PanelIconVisible = false;
      ((Control) this.headerPanel14).Size = new Size(376, 59);
      ((Control) this.headerPanel14).TabIndex = 87;
      this.headerPanel14.TextAntialias = true;
      this.cbRemindIfNameAndAddressSame.AutoSize = true;
      this.cbRemindIfNameAndAddressSame.BackColor = Color.Transparent;
      this.cbRemindIfNameAndAddressSame.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRemindIfNameAndAddressSame.Location = new Point(5, 8);
      this.cbRemindIfNameAndAddressSame.Name = "cbRemindIfNameAndAddressSame";
      this.cbRemindIfNameAndAddressSame.Size = new Size(260, 21);
      this.cbRemindIfNameAndAddressSame.TabIndex = 20;
      this.cbRemindIfNameAndAddressSame.Text = "Remind If Name And Address Same?";
      this.cbRemindIfNameAndAddressSame.UseVisualStyleBackColor = false;
      this.cbRemindIfNameAndAddressSame.CheckedChanged += new EventHandler(this.cbReduceFirstMonthInterest_CheckedChanged);
      ((Control) this.glassButton31).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton31.BackColor = Color.LightBlue;
      this.glassButton31.FadeOnFocus = true;
      ((Control) this.glassButton31).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton31.ForeColor = Color.MediumBlue;
      this.glassButton31.ForeColorOnFocus = Color.Red;
      this.glassButton31.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton31.GlowColor = Color.White;
      ((ButtonBase) this.glassButton31).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton31.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton31).Location = new Point(71, 513);
      ((Control) this.glassButton31).Name = "glassButton31";
      this.glassButton31.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton31.ShineColor = Color.Transparent;
      ((Control) this.glassButton31).Size = new Size(128, 35);
      ((Control) this.glassButton31).TabIndex = 1;
      ((Control) this.glassButton31).Text = "&SAVE";
      ((ButtonBase) this.glassButton31).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton32).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton32.BackColor = Color.LightBlue;
      this.glassButton32.FadeOnFocus = true;
      ((Control) this.glassButton32).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton32.ForeColor = Color.MediumBlue;
      this.glassButton32.ForeColorOnFocus = Color.Red;
      this.glassButton32.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton32.GlowColor = Color.White;
      this.glassButton32.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton32).Location = new Point(205, 512);
      ((Control) this.glassButton32).Name = "glassButton32";
      this.glassButton32.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton32.ShineColor = Color.Transparent;
      ((Control) this.glassButton32).Size = new Size(123, 37);
      ((Control) this.glassButton32).TabIndex = 0;
      ((Control) this.glassButton32).Text = "&EXIT";
      ((ButtonBase) this.glassButton32).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "REDUCE FIRST MONTH INTEREST?";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbRemindIfNameAddressAndDoorNumberSame);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(12, 77);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(376, 59);
      ((Control) this.headerPanel1).TabIndex = 88;
      this.headerPanel1.TextAntialias = true;
      this.cbRemindIfNameAddressAndDoorNumberSame.AutoSize = true;
      this.cbRemindIfNameAddressAndDoorNumberSame.BackColor = Color.Transparent;
      this.cbRemindIfNameAddressAndDoorNumberSame.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRemindIfNameAddressAndDoorNumberSame.Location = new Point(5, 8);
      this.cbRemindIfNameAddressAndDoorNumberSame.Name = "cbRemindIfNameAddressAndDoorNumberSame";
      this.cbRemindIfNameAddressAndDoorNumberSame.Size = new Size(345, 21);
      this.cbRemindIfNameAddressAndDoorNumberSame.TabIndex = 20;
      this.cbRemindIfNameAddressAndDoorNumberSame.Text = "Remind If Name Address And DoorNumber Same?";
      this.cbRemindIfNameAddressAndDoorNumberSame.UseVisualStyleBackColor = false;
      this.cbRemindIfNameAddressAndDoorNumberSame.CheckedChanged += new EventHandler(this.cbRemindIfNameAddressAndDoorNumberSame_CheckedChanged);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(69, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 1;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(203, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(403, 155);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel14);
      this.Name = nameof (FormSettings);
      this.Text = "Customer SEttings";
      this.Load += new EventHandler(this.FormSettings_Load);
      ((Control) this.headerPanel14).ResumeLayout(false);
      ((Control) this.headerPanel14).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
