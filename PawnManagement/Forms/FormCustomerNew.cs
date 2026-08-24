
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
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormCustomerNew : Form
  {
    private string CustomerCode = "";
    private DataTable dtCustomerDetails = new DataTable();
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private HeaderPanel headerPanel12;
    private GlassButton glassButton23;
    private GlassButton glassButton24;
    private TextBox tbxAverageOfNoOfMonthsForRelease;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton21;
    private GlassButton glassButton22;
    private TextBox tbxNumberOfTimesReleaseExceededTwelveMonths;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton19;
    private GlassButton glassButton20;
    private TextBox tbxNotes;
    private PictureBox pictureBox1;
    private PictureBox pictureBox4;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton17;
    private GlassButton glassButton18;
    private TextBox tbxAlternateContact;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton15;
    private GlassButton glassButton16;
    private TextBox tbxContactNo;
    private HeaderPanel headerPanel7;
    private RichTextBox richTextBox1;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private TextBox tbxCustomerCode;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton9;
    private GlassButton glassButton10;
    private TextBox tbxName;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton7;
    private GlassButton glassButton8;
    private PictureBox picProfilePhoto;
    private PictureBox pictureBox5;
    private PictureBox pictureBox3;

    public FormCustomerNew() => this.InitializeComponent();

    public FormCustomerNew(string CUSTOMERCODE)
    {
      this.CustomerCode = CUSTOMERCODE;
      this.InitializeComponent();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
      if (this.tbxContactNo.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxContactNo.Text) && this.tbxContactNo.Text.Count<char>() == 10)
      {
        int num1 = (int) new FormCall(this.tbxContactNo.Text.ToString()).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      if (this.tbxContactNo.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxContactNo.Text) && this.tbxContactNo.Text.Count<char>() == 10)
      {
        FormSendSMS formSendSms = new FormSendSMS();
        formSendSms.LoadNotice(this.dtCustomerDetails, "cid", "CPhone", new List<string>()
        {
          "cid",
          "CPhone",
          "CName"
        });
        int num = (int) formSendSms.ShowDialog();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      if (this.tbxAlternateContact.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxAlternateContact.Text) && this.tbxAlternateContact.Text.Count<char>() == 10)
      {
        int num1 = (int) new FormCall(this.tbxAlternateContact.Text.ToString()).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (this.tbxAlternateContact.Text != "" && PawnManagementClass.IsDigitsOnly(this.tbxAlternateContact.Text) && this.tbxAlternateContact.Text.Count<char>() == 10)
      {
        FormSendSMS formSendSms = new FormSendSMS();
        formSendSms.LoadNotice(this.dtCustomerDetails, "cid", "CCell", new List<string>()
        {
          "cid",
          "CPhone",
          "CName"
        });
        int num = (int) formSendSms.ShowDialog();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Invalid Mobile Number");
      }
    }

    private void tbxCustomerCode_TextChanged(object sender, EventArgs e) => this.getCustomerDetails(this.CustomerCode);

    private void getCustomerDetails(string customerCode)
    {
      try
      {
        string strError = "";
        this.dtCustomerDetails = SQLHelper.GetDataTable("Select * from tblcustomers where cid = @cid", new List<OleDbParameter>()
        {
          new OleDbParameter("cid", (object) customerCode)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails(string customecode)", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form customerPledgeDetails.getCustomerDetails(string customecode)" + strError);
        }
        else
        {
          this.tbxName.Text = this.dtCustomerDetails.Rows[0].Field<string>("CName");
          this.richTextBox1.Text = this.dtCustomerDetails.Rows[0].Field<string>("Cno") + " " + this.dtCustomerDetails.Rows[0].Field<string>("CAddr1") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CAddr2") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CAddr3") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CCity") + "\n" + this.dtCustomerDetails.Rows[0].Field<string>("CPinCode");
          this.tbxContactNo.Text = this.dtCustomerDetails.Rows[0].Field<string>("CPhone");
          this.tbxAlternateContact.Text = this.dtCustomerDetails.Rows[0].Field<string>("CCell");
          this.tbxNotes.Text = this.dtCustomerDetails.Rows[0].Field<string>("CNotes");
        }
        this.tbxAverageOfNoOfMonthsForRelease.Text = PawnManagementClass.averageOfNumberOfMonthsForRelease(this.tbxCustomerCode.Text.Trim().ToString());
        this.tbxNumberOfTimesReleaseExceededTwelveMonths.Text = PawnManagementClass.numberOfTimesReleaseExceededTwelveMonths(this.tbxCustomerCode.Text.Trim().ToString());
        if (File.Exists(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\" + this.tbxCustomerCode.Text.Trim().ToString() + ".png", FileMode.Open, FileAccess.Read))
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
            this.picProfilePhoto.Image = Image.FromStream((Stream) fileStream);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form customerPledgeDetails.getCustomerDetails(string customecode) outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormCustomerNew_Load(object sender, EventArgs e) => this.tbxCustomerCode.Text = this.CustomerCode;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel1 = new Panel();
      this.headerPanel12 = new HeaderPanel();
      this.glassButton23 = new GlassButton();
      this.glassButton24 = new GlassButton();
      this.tbxAverageOfNoOfMonthsForRelease = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.richTextBox1 = new RichTextBox();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tbxCustomerCode = new TextBox();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton21 = new GlassButton();
      this.glassButton22 = new GlassButton();
      this.tbxNumberOfTimesReleaseExceededTwelveMonths = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton9 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.tbxName = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton7 = new GlassButton();
      this.glassButton8 = new GlassButton();
      this.picProfilePhoto = new PictureBox();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton19 = new GlassButton();
      this.glassButton20 = new GlassButton();
      this.tbxNotes = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton15 = new GlassButton();
      this.glassButton16 = new GlassButton();
      this.tbxContactNo = new TextBox();
      this.pictureBox5 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.headerPanel9 = new HeaderPanel();
      this.glassButton17 = new GlassButton();
      this.glassButton18 = new GlassButton();
      this.tbxAlternateContact = new TextBox();
      this.pictureBox3 = new PictureBox();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel12).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((ISupportInitialize) this.picProfilePhoto).BeginInit();
      ((Control) this.headerPanel10).SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((Control) this.headerPanel8).SuspendLayout();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((Control) this.headerPanel9).SuspendLayout();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.headerPanel12);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.headerPanel11);
      this.panel1.Controls.Add((Control) this.headerPanel5);
      this.panel1.Controls.Add((Control) this.headerPanel4);
      this.panel1.Controls.Add((Control) this.headerPanel10);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.headerPanel8);
      this.panel1.Controls.Add((Control) this.pictureBox5);
      this.panel1.Controls.Add((Control) this.pictureBox4);
      this.panel1.Controls.Add((Control) this.headerPanel9);
      this.panel1.Controls.Add((Control) this.pictureBox3);
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(582, 400);
      this.panel1.TabIndex = 2;
      ((Control) this.headerPanel12).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel12).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel12.BorderColor = SystemColors.ControlDark;
      this.headerPanel12.BorderStyle = BorderStyles.Single;
      this.headerPanel12.CaptionBeginColor = SystemColors.Control;
      this.headerPanel12.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel12.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.CaptionHeight = 22;
      this.headerPanel12.CaptionPosition = CaptionPositions.Top;
      this.headerPanel12.CaptionText = "Avg of no of months for release";
      this.headerPanel12.CaptionVisible = true;
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton23);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel12).Controls.Add((Control) this.tbxAverageOfNoOfMonthsForRelease);
      ((Control) this.headerPanel12).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel12).ForeColor = Color.DarkBlue;
      this.headerPanel12.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.GradientEnd = SystemColors.ControlLight;
      this.headerPanel12.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel12).Location = new Point(279, 187);
      ((Control) this.headerPanel12).Name = "headerPanel12";
      this.headerPanel12.PanelIcon = (Icon) null;
      this.headerPanel12.PanelIconVisible = false;
      ((Control) this.headerPanel12).Size = new Size(298, 49);
      ((Control) this.headerPanel12).TabIndex = 92;
      this.headerPanel12.TextAntialias = true;
      ((Control) this.glassButton23).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton23.BackColor = Color.LightBlue;
      this.glassButton23.FadeOnFocus = true;
      ((Control) this.glassButton23).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton23.ForeColor = Color.MediumBlue;
      this.glassButton23.ForeColorOnFocus = Color.Red;
      this.glassButton23.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton23.GlowColor = Color.White;
      ((ButtonBase) this.glassButton23).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton23.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton23).Location = new Point(-17, 513);
      ((Control) this.glassButton23).Name = "glassButton23";
      this.glassButton23.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton23.ShineColor = Color.Transparent;
      ((Control) this.glassButton23).Size = new Size(128, 35);
      ((Control) this.glassButton23).TabIndex = 0;
      ((Control) this.glassButton23).Text = "&SAVE";
      ((ButtonBase) this.glassButton23).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton24).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton24.BackColor = Color.LightBlue;
      this.glassButton24.FadeOnFocus = true;
      ((Control) this.glassButton24).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton24.ForeColor = Color.MediumBlue;
      this.glassButton24.ForeColorOnFocus = Color.Red;
      this.glassButton24.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton24.GlowColor = Color.White;
      this.glassButton24.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton24).Location = new Point(117, 512);
      ((Control) this.glassButton24).Name = "glassButton24";
      this.glassButton24.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton24.ShineColor = Color.Transparent;
      ((Control) this.glassButton24).Size = new Size(123, 37);
      ((Control) this.glassButton24).TabIndex = 1;
      ((Control) this.glassButton24).Text = "&EXIT";
      ((ButtonBase) this.glassButton24).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAverageOfNoOfMonthsForRelease.BorderStyle = BorderStyle.None;
      this.tbxAverageOfNoOfMonthsForRelease.Dock = DockStyle.Fill;
      this.tbxAverageOfNoOfMonthsForRelease.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAverageOfNoOfMonthsForRelease.Location = new Point(0, 0);
      this.tbxAverageOfNoOfMonthsForRelease.Name = "tbxAverageOfNoOfMonthsForRelease";
      this.tbxAverageOfNoOfMonthsForRelease.Size = new Size(296, 24);
      this.tbxAverageOfNoOfMonthsForRelease.TabIndex = 6;
      this.tbxAverageOfNoOfMonthsForRelease.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel7).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.ControlDark;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = SystemColors.Control;
      this.headerPanel7.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "ADDRESS";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.richTextBox1);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(279, 7);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(298, 121);
      ((Control) this.headerPanel7).TabIndex = 84;
      this.headerPanel7.TextAntialias = true;
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Location = new Point(0, 0);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(296, 97);
      this.richTextBox1.TabIndex = 2;
      this.richTextBox1.Text = "";
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      ((ButtonBase) this.glassButton13).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(-15, 513);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(128, 35);
      ((Control) this.glassButton13).TabIndex = 0;
      ((Control) this.glassButton13).Text = "&SAVE";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(119, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 1;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.ControlDark;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = SystemColors.Control;
      this.headerPanel6.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "CUSTOMER CODE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxCustomerCode);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(3, 7);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(273, 49);
      ((Control) this.headerPanel6).TabIndex = 83;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton11.BackColor = Color.LightBlue;
      this.glassButton11.FadeOnFocus = true;
      ((Control) this.glassButton11).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton11.ForeColor = Color.MediumBlue;
      this.glassButton11.ForeColorOnFocus = Color.Red;
      this.glassButton11.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton11.GlowColor = Color.White;
      ((ButtonBase) this.glassButton11).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton11.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton11).Location = new Point(-38, 513);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(128, 35);
      ((Control) this.glassButton11).TabIndex = 0;
      ((Control) this.glassButton11).Text = "&SAVE";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(96, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxCustomerCode.BorderStyle = BorderStyle.None;
      this.tbxCustomerCode.Dock = DockStyle.Fill;
      this.tbxCustomerCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCustomerCode.Location = new Point(0, 0);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(271, 24);
      this.tbxCustomerCode.TabIndex = 6;
      this.tbxCustomerCode.TextAlign = HorizontalAlignment.Center;
      this.tbxCustomerCode.TextChanged += new EventHandler(this.tbxCustomerCode_TextChanged);
      ((Control) this.headerPanel11).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.ControlDark;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = SystemColors.Control;
      this.headerPanel11.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel11.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "NO OF TIMES RELEASE > 12 MNTHS";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton22);
      ((Control) this.headerPanel11).Controls.Add((Control) this.tbxNumberOfTimesReleaseExceededTwelveMonths);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = SystemColors.ControlLight;
      this.headerPanel11.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).Location = new Point(279, 242);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(298, 49);
      ((Control) this.headerPanel11).TabIndex = 91;
      this.headerPanel11.TextAntialias = true;
      ((Control) this.glassButton21).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton21.BackColor = Color.LightBlue;
      this.glassButton21.FadeOnFocus = true;
      ((Control) this.glassButton21).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton21.ForeColor = Color.MediumBlue;
      this.glassButton21.ForeColorOnFocus = Color.Red;
      this.glassButton21.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton21.GlowColor = Color.White;
      ((ButtonBase) this.glassButton21).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton21.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton21).Location = new Point(-17, 513);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(128, 35);
      ((Control) this.glassButton21).TabIndex = 0;
      ((Control) this.glassButton21).Text = "&SAVE";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton22).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton22.BackColor = Color.LightBlue;
      this.glassButton22.FadeOnFocus = true;
      ((Control) this.glassButton22).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton22.ForeColor = Color.MediumBlue;
      this.glassButton22.ForeColorOnFocus = Color.Red;
      this.glassButton22.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton22.GlowColor = Color.White;
      this.glassButton22.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton22).Location = new Point(117, 512);
      ((Control) this.glassButton22).Name = "glassButton22";
      this.glassButton22.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton22.ShineColor = Color.Transparent;
      ((Control) this.glassButton22).Size = new Size(123, 37);
      ((Control) this.glassButton22).TabIndex = 1;
      ((Control) this.glassButton22).Text = "&EXIT";
      ((ButtonBase) this.glassButton22).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.BorderStyle = BorderStyle.None;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Dock = DockStyle.Fill;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Location = new Point(0, 0);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Name = "tbxNumberOfTimesReleaseExceededTwelveMonths";
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.Size = new Size(296, 24);
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.TabIndex = 6;
      this.tbxNumberOfTimesReleaseExceededTwelveMonths.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel5).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.ControlDark;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = SystemColors.Control;
      this.headerPanel5.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "NAME";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxName);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(5, 343);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(270, 50);
      ((Control) this.headerPanel5).TabIndex = 82;
      this.headerPanel5.TextAntialias = true;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      ((ButtonBase) this.glassButton9).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(-39, 513);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(128, 35);
      ((Control) this.glassButton9).TabIndex = 0;
      ((Control) this.glassButton9).Text = "&SAVE";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(95, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 1;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxName.BorderStyle = BorderStyle.None;
      this.tbxName.Dock = DockStyle.Fill;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(0, 0);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(268, 24);
      this.tbxName.TabIndex = 9;
      ((Control) this.headerPanel4).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.ControlDark;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = SystemColors.Control;
      this.headerPanel4.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "PHOTO";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel4).Controls.Add((Control) this.picProfilePhoto);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(4, 59);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(272, 282);
      ((Control) this.headerPanel4).TabIndex = 81;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      ((ButtonBase) this.glassButton7).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(-35, 513);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(128, 35);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&SAVE";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(99, 512);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(123, 37);
      ((Control) this.glassButton8).TabIndex = 1;
      ((Control) this.glassButton8).Text = "&EXIT";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.picProfilePhoto.Dock = DockStyle.Fill;
      this.picProfilePhoto.Location = new Point(0, 0);
      this.picProfilePhoto.Name = "picProfilePhoto";
      this.picProfilePhoto.Size = new Size(270, 258);
      this.picProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picProfilePhoto.TabIndex = 68;
      this.picProfilePhoto.TabStop = false;
      ((Control) this.headerPanel10).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.ControlDark;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = SystemColors.Control;
      this.headerPanel10.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "REMINDER";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel10).Controls.Add((Control) this.tbxNotes);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = SystemColors.ControlLight;
      this.headerPanel10.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).Location = new Point(279, 133);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(298, 49);
      ((Control) this.headerPanel10).TabIndex = 90;
      this.headerPanel10.TextAntialias = true;
      ((Control) this.glassButton19).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      ((Control) this.glassButton19).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      ((ButtonBase) this.glassButton19).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(-15, 513);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(128, 35);
      ((Control) this.glassButton19).TabIndex = 0;
      ((Control) this.glassButton19).Text = "&SAVE";
      ((ButtonBase) this.glassButton19).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton20).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton20.BackColor = Color.LightBlue;
      this.glassButton20.FadeOnFocus = true;
      ((Control) this.glassButton20).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton20.ForeColor = Color.MediumBlue;
      this.glassButton20.ForeColorOnFocus = Color.Red;
      this.glassButton20.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton20.GlowColor = Color.White;
      this.glassButton20.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton20).Location = new Point(119, 512);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(123, 37);
      ((Control) this.glassButton20).TabIndex = 1;
      ((Control) this.glassButton20).Text = "&EXIT";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNotes.BorderStyle = BorderStyle.None;
      this.tbxNotes.Dock = DockStyle.Fill;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(0, 0);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(296, 24);
      this.tbxNotes.TabIndex = 6;
      this.pictureBox1.Image = (Image) Resources.message;
      this.pictureBox1.Location = new Point(467, 349);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(53, 46);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 89;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      ((Control) this.headerPanel8).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.ControlDark;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = SystemColors.Control;
      this.headerPanel8.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "PHONE NUMBER";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxContactNo);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(281, 296);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(180, 48);
      ((Control) this.headerPanel8).TabIndex = 85;
      this.headerPanel8.TextAntialias = true;
      ((Control) this.glassButton15).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton15.BackColor = Color.LightBlue;
      this.glassButton15.FadeOnFocus = true;
      ((Control) this.glassButton15).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton15.ForeColor = Color.MediumBlue;
      this.glassButton15.ForeColorOnFocus = Color.Red;
      this.glassButton15.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton15.GlowColor = Color.White;
      ((ButtonBase) this.glassButton15).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton15.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton15).Location = new Point(-133, 513);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(128, 35);
      ((Control) this.glassButton15).TabIndex = 0;
      ((Control) this.glassButton15).Text = "&SAVE";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(1, 512);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(123, 37);
      ((Control) this.glassButton16).TabIndex = 1;
      ((Control) this.glassButton16).Text = "&EXIT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxContactNo.BorderStyle = BorderStyle.None;
      this.tbxContactNo.CharacterCasing = CharacterCasing.Upper;
      this.tbxContactNo.Dock = DockStyle.Fill;
      this.tbxContactNo.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxContactNo.Location = new Point(0, 0);
      this.tbxContactNo.Name = "tbxContactNo";
      this.tbxContactNo.Size = new Size(178, 22);
      this.tbxContactNo.TabIndex = 57;
      this.tbxContactNo.TextAlign = HorizontalAlignment.Center;
      this.pictureBox5.Image = (Image) Resources.message;
      this.pictureBox5.Location = new Point(467, 298);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(53, 46);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 58;
      this.pictureBox5.TabStop = false;
      this.pictureBox5.Click += new EventHandler(this.pictureBox5_Click);
      this.pictureBox4.Image = (Image) Resources.callbutton;
      this.pictureBox4.Location = new Point(526, 349);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(48, 46);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox4.TabIndex = 88;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Click += new EventHandler(this.pictureBox4_Click);
      ((Control) this.headerPanel9).BackColor = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.ControlDark;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = SystemColors.Control;
      this.headerPanel9.CaptionEndColor = SystemColors.ButtonFace;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "ALTERNATE NUMBER";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel9).Controls.Add((Control) this.tbxAlternateContact);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = SystemColors.ControlLight;
      this.headerPanel9.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).Location = new Point(281, 349);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(181, 46);
      ((Control) this.headerPanel9).TabIndex = 86;
      this.headerPanel9.TextAntialias = true;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      ((ButtonBase) this.glassButton17).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(-134, 513);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(128, 35);
      ((Control) this.glassButton17).TabIndex = 0;
      ((Control) this.glassButton17).Text = "&SAVE";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(0, 512);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(123, 37);
      ((Control) this.glassButton18).TabIndex = 1;
      ((Control) this.glassButton18).Text = "&EXIT";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAlternateContact.BorderStyle = BorderStyle.None;
      this.tbxAlternateContact.CharacterCasing = CharacterCasing.Upper;
      this.tbxAlternateContact.Dock = DockStyle.Fill;
      this.tbxAlternateContact.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAlternateContact.Location = new Point(0, 0);
      this.tbxAlternateContact.Name = "tbxAlternateContact";
      this.tbxAlternateContact.Size = new Size(179, 22);
      this.tbxAlternateContact.TabIndex = 57;
      this.tbxAlternateContact.TextAlign = HorizontalAlignment.Center;
      this.pictureBox3.Image = (Image) Resources.callbutton;
      this.pictureBox3.Location = new Point(526, 298);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(48, 46);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 45;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Click += new EventHandler(this.pictureBox3_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(585, 405);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormCustomerNew);
      this.Text = nameof (FormCustomerNew);
      this.Load += new EventHandler(this.FormCustomerNew_Load);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel12).ResumeLayout(false);
      ((Control) this.headerPanel12).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel11).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((ISupportInitialize) this.picProfilePhoto).EndInit();
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel10).PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel9).PerformLayout();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      this.ResumeLayout(false);
    }
  }
}
