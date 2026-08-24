

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormChangeRokadDate : Form
  {
    private string rokadDate = "";
    private IContainer components = (IContainer) null;
    private GlassButton btnChange;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxCurrentRokadDate;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxNewRokadDate;

    public FormChangeRokadDate() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormChangeRokadDate_Load(object sender, EventArgs e)
    {
      try
      {
        this.tbxNewRokadDate.Select();
        this.rokadDate = PawnManagementClass.getRokadDate();
        this.rokadDate = !(this.rokadDate == "") ? DateTime.Parse(this.rokadDate).ToString("dd/MM/yyyy") : DateTime.Now.ToString("dd/MM/yyyy");
        this.tbxCurrentRokadDate.Text = this.rokadDate;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formchangedrokaddate.formchangerokaddate_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      if (this.tbxNewRokadDate.Text != "" && PawnManagementClass.checkForValidateDate(this.tbxNewRokadDate.Text))
      {
        if (DateTime.Parse(this.tbxNewRokadDate.Text.Trim().ToString()) > DateTime.Parse(this.rokadDate))
        {
          if (!PawnManagementClass.checkIfRokadFinishedOrNot(this.tbxNewRokadDate.Text.Trim().ToString()))
          {
            this.changeRokadDateInRokadDetailsTable();
            this.changeRokadInVouchersTable();
          }
          else
          {
            int num1 = (int) MessageBox.Show("Rokad already  finished for this date");
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show(" RokadDate canno tbe lesss than todays date");
        }
      }
      else
      {
        int num3 = (int) MessageBox.Show("Invalid RokadDate");
      }
    }

    private void changeRokadDateInRokadDetailsTable()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblRokaddetails set rokadDate = @NewrokadDate where rokadDate = @oldrokaddate", new List<OleDbParameter>()
      {
        new OleDbParameter("NewrokadDate", (object) DateTime.Parse(this.tbxNewRokadDate.Text.Trim().ToString()).ToString("dd/MM/yyyy")),
        new OleDbParameter("oldrokaddate", (object) DateTime.Parse(this.tbxCurrentRokadDate.Text.Trim().ToString()).ToString("dd/MM/yyyy"))
      }, ref strError) == "Done")
      {
        int num1 = (int) MessageBox.Show("RokadDate successffully updated");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error while updating RokadDate");
        PawnManagementClass.InsertIntoException("form changerokaddate.changerokaddateinrokaddetailstable()", strError, FormMain.username, DateTime.Now.ToString());
      }
    }

    private void changeRokadInVouchersTable()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblVouchers set VoucherDate = @NewVoucherDate where voucherdate  = @oldvoucherdate", new List<OleDbParameter>()
      {
        new OleDbParameter("NewVoucherDate", (object) DateTime.Parse(this.tbxNewRokadDate.Text.Trim().ToString()).ToString("dd/MM/yyyy")),
        new OleDbParameter("oldvoucherdate", (object) DateTime.Parse(this.tbxCurrentRokadDate.Text.Trim().ToString()).ToString("dd/MM/yyyy"))
      }, ref strError) == "Done")
      {
        int num1 = (int) MessageBox.Show("RokadDate successffully updated");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error while updating RokadDate");
        PawnManagementClass.InsertIntoException("form changerokaddate.changerokadinvoucherstable", strError, FormMain.username, DateTime.Now.ToString());
      }
    }

    private void tbxNewRokadDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnChange).Select();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnChange = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxCurrentRokadDate = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxNewRokadDate = new TextBox();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      this.btnChange.BackColor = Color.LightBlue;
      this.btnChange.FadeOnFocus = true;
      ((Control) this.btnChange).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnChange.ForeColor = Color.MediumBlue;
      this.btnChange.ForeColorOnFocus = Color.Red;
      this.btnChange.ForeColorOnLeave = Color.RoyalBlue;
      this.btnChange.GlowColor = Color.White;
      this.btnChange.InnerBorderColor = Color.Transparent;
      ((Control) this.btnChange).Location = new Point(11, 132);
      ((Control) this.btnChange).Name = "btnChange";
      this.btnChange.OuterBorderColor = Color.MediumSlateBlue;
      this.btnChange.ShineColor = Color.Transparent;
      ((Control) this.btnChange).Size = new Size(238, 41);
      ((Control) this.btnChange).TabIndex = 3;
      ((Control) this.btnChange).Text = "&Change";
      ((Control) this.btnChange).Click += new EventHandler(this.btnChange_Click);
      ((Control) this.headerPanel4).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.ControlDark;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = SystemColors.Control;
      this.headerPanel4.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "CURRENT ROKAD DATE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxCurrentRokadDate);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(12, 12);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(237, 55);
      ((Control) this.headerPanel4).TabIndex = 77;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      ((ButtonBase) this.glassButton6).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(-60, 513);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(128, 35);
      ((Control) this.glassButton6).TabIndex = 0;
      ((Control) this.glassButton6).Text = "&SAVE";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(74, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxCurrentRokadDate.BackColor = SystemColors.ButtonHighlight;
      this.tbxCurrentRokadDate.BorderStyle = BorderStyle.None;
      this.tbxCurrentRokadDate.Dock = DockStyle.Fill;
      this.tbxCurrentRokadDate.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCurrentRokadDate.Location = new Point(0, 0);
      this.tbxCurrentRokadDate.Name = "tbxCurrentRokadDate";
      this.tbxCurrentRokadDate.Size = new Size(235, 31);
      this.tbxCurrentRokadDate.TabIndex = 25;
      this.tbxCurrentRokadDate.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel1).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.ControlDark;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = SystemColors.Control;
      this.headerPanel1.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "NEW ROKAD DATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNewRokadDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(11, 72);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(237, 55);
      ((Control) this.headerPanel1).TabIndex = 78;
      this.headerPanel1.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(-62, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
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
      ((Control) this.glassButton2).Location = new Point(72, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNewRokadDate.BackColor = SystemColors.ButtonHighlight;
      this.tbxNewRokadDate.BorderStyle = BorderStyle.None;
      this.tbxNewRokadDate.Dock = DockStyle.Fill;
      this.tbxNewRokadDate.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNewRokadDate.Location = new Point(0, 0);
      this.tbxNewRokadDate.Name = "tbxNewRokadDate";
      this.tbxNewRokadDate.Size = new Size(235, 31);
      this.tbxNewRokadDate.TabIndex = 25;
      this.tbxNewRokadDate.TextAlign = HorizontalAlignment.Center;
      this.tbxNewRokadDate.KeyDown += new KeyEventHandler(this.tbxNewRokadDate_KeyDown);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(264, 181);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.btnChange);
      this.Name = nameof (FormChangeRokadDate);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Change Rokad Date";
      this.Load += new EventHandler(this.FormChangeRokadDate_Load);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
