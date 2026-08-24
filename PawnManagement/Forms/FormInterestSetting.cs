
using CSharpCustomPanelControl;
using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormInterestSetting : Form
  {
    private IContainer components = (IContainer) null;
    private CustomPanel customPanel4;
    private CustomPanel customPanel1;
    private ComboBox cbPledgeScreen;
    private ComboBox cbViewCustomerScreen;
    private CustomPanel customPanel2;
    private ComboBox cbNoticeScreen;
    private CustomPanel customPanel3;
    private ComboBox cbNoticeScreenInteestType;
    private CustomPanel customPanel5;
    private ComboBox cbViewCustomerScreenInterestType;
    private CustomPanel customPanel6;
    private ComboBox cbPledgeScreenInterestType;
    private CustomPanel customPanel9;
    private Label label5;
    private CustomPanel customPanel10;
    private Label label3;
    private CustomPanel customPanel11;
    private Label label4;
    private CustomPanel customPanel12;
    private Label label6;
    private LinkLabel linkLabel1;
    private CustomPanel customPanel13;
    private Label label2;
    private CustomPanel customPanel14;
    private Label label1;
    private CustomPanel customPanel15;
    private GlassButton btnSave;
    private GlassButton glassButton1;

    public FormInterestSetting() => this.InitializeComponent();

    private void FormInterestSetting_Load(object sender, EventArgs e) => this.refreshGrid();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblInterestSetting";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Articlessettings.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form articlessettings.refreshgrid()");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["ViewCustomerScreen"] != null && dataTable2.Rows[0]["ViewCustomerScreen"].ToString() != "")
          this.cbViewCustomerScreen.Text = dataTable2.Rows[0]["ViewCustomerScreen"].ToString();
        if (dataTable2.Rows[0]["PledgeScreen"] != null && dataTable2.Rows[0]["PledgeScreen"].ToString() != "")
          this.cbPledgeScreen.Text = dataTable2.Rows[0]["PledgeScreen"].ToString();
        if (dataTable2.Rows[0]["NoticeScreen"] != null && dataTable2.Rows[0]["NoticeScreen"].ToString() != "")
          this.cbNoticeScreen.Text = dataTable2.Rows[0]["NoticeScreen"].ToString();
        if (dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"] != null && dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"].ToString() != "")
          this.cbViewCustomerScreenInterestType.Text = dataTable2.Rows[0]["ViewCustomerScreenSimpleOrCompound"].ToString();
        if (dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"] != null && dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"].ToString() != "")
          this.cbPledgeScreenInterestType.Text = dataTable2.Rows[0]["PledgeScreenSimpleOrCompound"].ToString();
        if (dataTable2.Rows[0]["NoticeScreenSimpleOrCompound"] != null && dataTable2.Rows[0]["NoticeScreenSimpleOrCompound"].ToString() != "")
          this.cbNoticeScreenInteestType.Text = dataTable2.Rows[0]["NoticeScreenSimpleOrCompound"].ToString();
      }
      else
        this.insertIntoTableInterestSettings();
    }

    private void insertIntoTableInterestSettings()
    {
      string strError = "";
      string str = SQLHelper.RunCommand("Insert into tblInterestSetting(ViewCustomerScreen,PledgeScreen,NoticeScreen,ViewCustomerScreenSimpleOrCompound,PledgeScreenSimpleOrCompound,NoticeScreenSimpleOrCompound) values(@ViewCustomerScreen,@PledgeScreen,@NoticeScreen,@ViewCustomerScreenSimpleOrCompound,@PledgeScreenSimpleOrCompound,@NoticeScreenSimpleOrCompound)", new List<OleDbParameter>()
      {
        new OleDbParameter("ViewCustomerScreen", (object) "Interest Setting"),
        new OleDbParameter("PledgeScreen", (object) "Interest Setting"),
        new OleDbParameter("NoticeScreen", (object) "Interest Setting"),
        new OleDbParameter("ViewCustomerScreenSimpleOrCompound", (object) "SIMPLE"),
        new OleDbParameter("PledgeScreenSimpleOrCompound", (object) "SIMPLE"),
        new OleDbParameter("NoticeScreenSimpleOrCompound", (object) "SIMPLE")
      }, ref strError);
      if (!(str != "Done"))
        return;
      int num = (int) MessageBox.Show("Error while updating" + str);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!(this.cbNoticeScreen.Text != "") || !(this.cbPledgeScreen.Text != "") || !(this.cbViewCustomerScreen.Text != "") || !(this.cbNoticeScreenInteestType.Text != "") || !(this.cbPledgeScreenInterestType.Text != "") || !(this.cbViewCustomerScreenInterestType.Text != ""))
        return;
      if (this.cbViewCustomerScreen.Items.Contains((object) this.cbViewCustomerScreen.Text))
      {
        if (this.cbPledgeScreen.Items.Contains((object) this.cbPledgeScreen.Text))
        {
          if (this.cbNoticeScreen.Items.Contains((object) this.cbNoticeScreen.Text))
          {
            if (this.cbViewCustomerScreenInterestType.Items.Contains((object) this.cbViewCustomerScreenInterestType.Text))
            {
              if (this.cbPledgeScreenInterestType.Items.Contains((object) this.cbPledgeScreenInterestType.Text))
              {
                if (this.cbNoticeScreenInteestType.Items.Contains((object) this.cbNoticeScreenInteestType.Text))
                {
                  string strError = "";
                  if (SQLHelper.RunCommand("update tblInterestSEtting set ViewCustomerScreen = @ViewCustomerScreen,PledgeScreen = @PledgeScreen,NoticeScreen = @NoticeScreen,ViewCustomerScreenSimpleOrCompound = @ViewCustomerScreenSimpleOrCompound,PledgeScreenSimpleOrCompound = @PledgeScreenSimpleOrCompound,NoticeScreenSimpleOrCompound = @NoticeScreenSimpleOrCompound", new List<OleDbParameter>()
                  {
                    new OleDbParameter("ViewCustomerScreen", (object) this.cbViewCustomerScreen.Text),
                    new OleDbParameter("PledgeScreen", (object) this.cbPledgeScreen.Text),
                    new OleDbParameter("NoticeScreen", (object) this.cbNoticeScreen.Text),
                    new OleDbParameter("ViewCustomerScreenSimpleOrCompound", (object) this.cbViewCustomerScreenInterestType.Text),
                    new OleDbParameter("PledgeScreenSimpleOrCompound", (object) this.cbPledgeScreenInterestType.Text),
                    new OleDbParameter("NoticeScreenSimpleOrCompound", (object) this.cbNoticeScreenInteestType.Text)
                  }, ref strError) == "Done")
                  {
                    int num1 = (int) MessageBox.Show("SUCCESSFULLY UPDATED");
                  }
                  else
                  {
                    int num2 = (int) MessageBox.Show("Error while updaing");
                  }
                }
                else
                  this.cbNoticeScreenInteestType.Select();
              }
              else
                this.cbPledgeScreenInterestType.Select();
            }
            else
              this.cbViewCustomerScreenInterestType.Select();
          }
          else
            this.cbNoticeScreen.Select();
        }
        else
          this.cbPledgeScreen.Select();
      }
      else
        this.cbViewCustomerScreen.Select();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void glassButton1_Click_1(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.customPanel4 = new CustomPanel();
      this.cbViewCustomerScreen = new ComboBox();
      this.customPanel1 = new CustomPanel();
      this.cbPledgeScreen = new ComboBox();
      this.customPanel2 = new CustomPanel();
      this.cbNoticeScreen = new ComboBox();
      this.customPanel3 = new CustomPanel();
      this.cbNoticeScreenInteestType = new ComboBox();
      this.customPanel5 = new CustomPanel();
      this.cbViewCustomerScreenInterestType = new ComboBox();
      this.customPanel6 = new CustomPanel();
      this.cbPledgeScreenInterestType = new ComboBox();
      this.customPanel9 = new CustomPanel();
      this.linkLabel1 = new LinkLabel();
      this.label5 = new Label();
      this.customPanel10 = new CustomPanel();
      this.label3 = new Label();
      this.customPanel11 = new CustomPanel();
      this.label4 = new Label();
      this.customPanel12 = new CustomPanel();
      this.label6 = new Label();
      this.customPanel13 = new CustomPanel();
      this.label2 = new Label();
      this.customPanel14 = new CustomPanel();
      this.label1 = new Label();
      this.customPanel15 = new CustomPanel();
      this.btnSave = new GlassButton();
      this.glassButton1 = new GlassButton();
      ((Control) this.customPanel4).SuspendLayout();
      ((Control) this.customPanel1).SuspendLayout();
      ((Control) this.customPanel2).SuspendLayout();
      ((Control) this.customPanel3).SuspendLayout();
      ((Control) this.customPanel5).SuspendLayout();
      ((Control) this.customPanel6).SuspendLayout();
      ((Control) this.customPanel9).SuspendLayout();
      ((Control) this.customPanel10).SuspendLayout();
      ((Control) this.customPanel11).SuspendLayout();
      ((Control) this.customPanel12).SuspendLayout();
      ((Control) this.customPanel13).SuspendLayout();
      ((Control) this.customPanel14).SuspendLayout();
      this.SuspendLayout();
      this.customPanel4.BackColor = SystemColors.Info;
      this.customPanel4.BackColor2 = SystemColors.Info;
      this.customPanel4.BorderColor = Color.Sienna;
      this.customPanel4.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel4).Controls.Add((Control) this.cbViewCustomerScreen);
      this.customPanel4.Curvature = 1;
      this.customPanel4.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel4).Location = new Point(237, 165);
      ((Control) this.customPanel4).Name = "customPanel4";
      ((Control) this.customPanel4).Size = new Size(301, 54);
      ((Control) this.customPanel4).TabIndex = 3;
      this.cbViewCustomerScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbViewCustomerScreen.BackColor = SystemColors.Info;
      this.cbViewCustomerScreen.FlatStyle = FlatStyle.Flat;
      this.cbViewCustomerScreen.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbViewCustomerScreen.FormattingEnabled = true;
      this.cbViewCustomerScreen.Items.AddRange(new object[2]
      {
        (object) "Interest Setting",
        (object) "INTEREST SETTING"
      });
      this.cbViewCustomerScreen.Location = new Point(31, 9);
      this.cbViewCustomerScreen.Name = "cbViewCustomerScreen";
      this.cbViewCustomerScreen.Size = new Size(250, 32);
      this.cbViewCustomerScreen.TabIndex = 2;
      this.customPanel1.BackColor = SystemColors.Info;
      this.customPanel1.BackColor2 = SystemColors.Info;
      this.customPanel1.BorderColor = Color.Sienna;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.cbPledgeScreen);
      this.customPanel1.Curvature = 1;
      this.customPanel1.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(237, 114);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(301, 54);
      ((Control) this.customPanel1).TabIndex = 2;
      this.cbPledgeScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbPledgeScreen.BackColor = SystemColors.Info;
      this.cbPledgeScreen.FlatStyle = FlatStyle.Flat;
      this.cbPledgeScreen.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPledgeScreen.FormattingEnabled = true;
      this.cbPledgeScreen.Items.AddRange(new object[2]
      {
        (object) "Interest Setting",
        (object) "INTEREST SETTING"
      });
      this.cbPledgeScreen.Location = new Point(31, 9);
      this.cbPledgeScreen.Name = "cbPledgeScreen";
      this.cbPledgeScreen.Size = new Size(250, 32);
      this.cbPledgeScreen.TabIndex = 1;
      this.customPanel2.BackColor = SystemColors.Info;
      this.customPanel2.BackColor2 = SystemColors.Info;
      this.customPanel2.BorderColor = Color.Sienna;
      this.customPanel2.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel2).Controls.Add((Control) this.cbNoticeScreen);
      this.customPanel2.Curvature = 1;
      this.customPanel2.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel2).Location = new Point(237, 217);
      ((Control) this.customPanel2).Name = "customPanel2";
      ((Control) this.customPanel2).Size = new Size(301, 54);
      ((Control) this.customPanel2).TabIndex = 4;
      this.cbNoticeScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbNoticeScreen.BackColor = SystemColors.Info;
      this.cbNoticeScreen.FlatStyle = FlatStyle.Flat;
      this.cbNoticeScreen.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeScreen.FormattingEnabled = true;
      this.cbNoticeScreen.Items.AddRange(new object[2]
      {
        (object) "Interest Setting",
        (object) "INTEREST SETTING"
      });
      this.cbNoticeScreen.Location = new Point(31, 9);
      this.cbNoticeScreen.Name = "cbNoticeScreen";
      this.cbNoticeScreen.Size = new Size(250, 32);
      this.cbNoticeScreen.TabIndex = 2;
      this.customPanel3.BackColor = SystemColors.Info;
      this.customPanel3.BackColor2 = SystemColors.Info;
      this.customPanel3.BorderColor = Color.Sienna;
      this.customPanel3.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel3).Controls.Add((Control) this.cbNoticeScreenInteestType);
      this.customPanel3.Curvature = 1;
      this.customPanel3.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel3).Location = new Point(531, 217);
      ((Control) this.customPanel3).Name = "customPanel3";
      ((Control) this.customPanel3).Size = new Size(301, 54);
      ((Control) this.customPanel3).TabIndex = 7;
      this.cbNoticeScreenInteestType.Anchor = AnchorStyles.None;
      this.cbNoticeScreenInteestType.BackColor = SystemColors.Info;
      this.cbNoticeScreenInteestType.FlatStyle = FlatStyle.Flat;
      this.cbNoticeScreenInteestType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbNoticeScreenInteestType.FormattingEnabled = true;
      this.cbNoticeScreenInteestType.Items.AddRange(new object[2]
      {
        (object) "SIMPLE",
        (object) "COMPOUND"
      });
      this.cbNoticeScreenInteestType.Location = new Point(28, 9);
      this.cbNoticeScreenInteestType.Name = "cbNoticeScreenInteestType";
      this.cbNoticeScreenInteestType.Size = new Size(250, 32);
      this.cbNoticeScreenInteestType.TabIndex = 2;
      this.customPanel5.BackColor = SystemColors.Info;
      this.customPanel5.BackColor2 = SystemColors.Info;
      this.customPanel5.BorderColor = Color.Sienna;
      this.customPanel5.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel5).Controls.Add((Control) this.cbViewCustomerScreenInterestType);
      this.customPanel5.Curvature = 1;
      this.customPanel5.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel5).Location = new Point(531, 165);
      ((Control) this.customPanel5).Name = "customPanel5";
      ((Control) this.customPanel5).Size = new Size(301, 54);
      ((Control) this.customPanel5).TabIndex = 6;
      this.cbViewCustomerScreenInterestType.Anchor = AnchorStyles.None;
      this.cbViewCustomerScreenInterestType.BackColor = SystemColors.Info;
      this.cbViewCustomerScreenInterestType.FlatStyle = FlatStyle.Flat;
      this.cbViewCustomerScreenInterestType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbViewCustomerScreenInterestType.FormattingEnabled = true;
      this.cbViewCustomerScreenInterestType.Items.AddRange(new object[2]
      {
        (object) "SIMPLE",
        (object) "COMPOUND"
      });
      this.cbViewCustomerScreenInterestType.Location = new Point(28, 9);
      this.cbViewCustomerScreenInterestType.Name = "cbViewCustomerScreenInterestType";
      this.cbViewCustomerScreenInterestType.Size = new Size(250, 32);
      this.cbViewCustomerScreenInterestType.TabIndex = 2;
      this.customPanel6.BackColor = SystemColors.Info;
      this.customPanel6.BackColor2 = SystemColors.Info;
      this.customPanel6.BorderColor = Color.Sienna;
      this.customPanel6.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel6).Controls.Add((Control) this.cbPledgeScreenInterestType);
      this.customPanel6.Curvature = 1;
      this.customPanel6.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel6).Location = new Point(531, 114);
      ((Control) this.customPanel6).Name = "customPanel6";
      ((Control) this.customPanel6).Size = new Size(301, 54);
      ((Control) this.customPanel6).TabIndex = 5;
      this.cbPledgeScreenInterestType.Anchor = AnchorStyles.None;
      this.cbPledgeScreenInterestType.BackColor = SystemColors.Info;
      this.cbPledgeScreenInterestType.FlatStyle = FlatStyle.Flat;
      this.cbPledgeScreenInterestType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPledgeScreenInterestType.FormattingEnabled = true;
      this.cbPledgeScreenInterestType.Items.AddRange(new object[2]
      {
        (object) "SIMPLE",
        (object) "COMPOUND"
      });
      this.cbPledgeScreenInterestType.Location = new Point(28, 9);
      this.cbPledgeScreenInterestType.Name = "cbPledgeScreenInterestType";
      this.cbPledgeScreenInterestType.Size = new Size(250, 32);
      this.cbPledgeScreenInterestType.TabIndex = 1;
      this.customPanel9.BackColor = SystemColors.Info;
      this.customPanel9.BackColor2 = SystemColors.Info;
      this.customPanel9.BorderColor = Color.Sienna;
      this.customPanel9.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel9).Controls.Add((Control) this.linkLabel1);
      ((Control) this.customPanel9).Controls.Add((Control) this.label5);
      this.customPanel9.Curvature = 5;
      this.customPanel9.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel9).Location = new Point(12, 14);
      ((Control) this.customPanel9).Name = "customPanel9";
      ((Control) this.customPanel9).Size = new Size(820, 54);
      ((Control) this.customPanel9).TabIndex = 8;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(765, 20);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(42, 13);
      this.linkLabel1.TabIndex = 1;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "&CLOSE";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(293, 10);
      this.label5.Name = "label5";
      this.label5.Size = new Size(225, 25);
      this.label5.TabIndex = 0;
      this.label5.Text = "INTEREST SETTINGS";
      this.customPanel10.BackColor = SystemColors.Info;
      this.customPanel10.BackColor2 = SystemColors.Info;
      this.customPanel10.BorderColor = Color.Sienna;
      this.customPanel10.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel10).Controls.Add((Control) this.label3);
      this.customPanel10.Curvature = 1;
      this.customPanel10.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel10).Location = new Point(12, 218);
      ((Control) this.customPanel10).Name = "customPanel10";
      ((Control) this.customPanel10).Size = new Size(226, 54);
      ((Control) this.customPanel10).TabIndex = 13;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(13, 13);
      this.label3.Name = "label3";
      this.label3.Size = new Size(147, 25);
      this.label3.TabIndex = 2;
      this.label3.Text = "Notice Screen";
      this.customPanel11.BackColor = SystemColors.Info;
      this.customPanel11.BackColor2 = SystemColors.Info;
      this.customPanel11.BorderColor = Color.Sienna;
      this.customPanel11.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel11).Controls.Add((Control) this.label4);
      this.customPanel11.Curvature = 1;
      this.customPanel11.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel11).Location = new Point(12, 166);
      ((Control) this.customPanel11).Name = "customPanel11";
      ((Control) this.customPanel11).Size = new Size(226, 54);
      ((Control) this.customPanel11).TabIndex = 12;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(8, 13);
      this.label4.Name = "label4";
      this.label4.Size = new Size(218, 25);
      this.label4.TabIndex = 2;
      this.label4.Text = "ViewCustomerScreen";
      this.customPanel12.BackColor = SystemColors.Info;
      this.customPanel12.BackColor2 = SystemColors.Info;
      this.customPanel12.BorderColor = Color.Sienna;
      this.customPanel12.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel12).Controls.Add((Control) this.label6);
      this.customPanel12.Curvature = 1;
      this.customPanel12.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel12).Location = new Point(12, 114);
      ((Control) this.customPanel12).Name = "customPanel12";
      ((Control) this.customPanel12).Size = new Size(226, 54);
      ((Control) this.customPanel12).TabIndex = 11;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(9, 13);
      this.label6.Name = "label6";
      this.label6.Size = new Size(147, 25);
      this.label6.TabIndex = 0;
      this.label6.Text = "PledgeScreen";
      this.customPanel13.BackColor = SystemColors.Info;
      this.customPanel13.BackColor2 = SystemColors.Info;
      this.customPanel13.BorderColor = Color.Sienna;
      this.customPanel13.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel13).Controls.Add((Control) this.label2);
      this.customPanel13.Curvature = 1;
      this.customPanel13.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel13).Location = new Point(531, 61);
      ((Control) this.customPanel13).Name = "customPanel13";
      ((Control) this.customPanel13).Size = new Size(301, 54);
      ((Control) this.customPanel13).TabIndex = 15;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(72, 10);
      this.label2.Name = "label2";
      this.label2.Size = new Size(136, 25);
      this.label2.TabIndex = 18;
      this.label2.Text = "CALCULATE";
      this.customPanel14.BackColor = SystemColors.Info;
      this.customPanel14.BackColor2 = SystemColors.Info;
      this.customPanel14.BorderColor = Color.Sienna;
      this.customPanel14.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel14).Controls.Add((Control) this.label1);
      this.customPanel14.Curvature = 1;
      this.customPanel14.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel14).Location = new Point(237, 61);
      ((Control) this.customPanel14).Name = "customPanel14";
      ((Control) this.customPanel14).Size = new Size(301, 54);
      ((Control) this.customPanel14).TabIndex = 14;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(91, 14);
      this.label1.Name = "label1";
      this.label1.Size = new Size(101, 25);
      this.label1.TabIndex = 17;
      this.label1.Text = "DISPLAY";
      this.customPanel15.BackColor = SystemColors.Info;
      this.customPanel15.BackColor2 = SystemColors.Info;
      this.customPanel15.BorderColor = Color.Sienna;
      this.customPanel15.BorderStyle = BorderStyle.FixedSingle;
      this.customPanel15.Curvature = 1;
      this.customPanel15.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel15).Location = new Point(12, 61);
      ((Control) this.customPanel15).Name = "customPanel15";
      ((Control) this.customPanel15).Size = new Size(226, 54);
      ((Control) this.customPanel15).TabIndex = 16;
      ((Control) this.btnSave).Anchor = AnchorStyles.None;
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.RoyalBlue;
      this.btnSave.GlowColor = Color.White;
      ((ButtonBase) this.btnSave).ImageAlign = ContentAlignment.TopLeft;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(533, 277);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(144, 35);
      ((Control) this.btnSave).TabIndex = 17;
      ((Control) this.btnSave).Text = "&SAVE";
      ((ButtonBase) this.btnSave).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnSave).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.glassButton1).Anchor = AnchorStyles.None;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(688, 277);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(144, 35);
      ((Control) this.glassButton1).TabIndex = 18;
      ((Control) this.glassButton1).Text = "&EXIT";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click_1);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LemonChiffon;
      this.ClientSize = new Size(849, 358);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.customPanel13);
      this.Controls.Add((Control) this.customPanel14);
      this.Controls.Add((Control) this.customPanel15);
      this.Controls.Add((Control) this.customPanel9);
      this.Controls.Add((Control) this.customPanel6);
      this.Controls.Add((Control) this.customPanel1);
      this.Controls.Add((Control) this.customPanel5);
      this.Controls.Add((Control) this.customPanel4);
      this.Controls.Add((Control) this.customPanel3);
      this.Controls.Add((Control) this.customPanel2);
      this.Controls.Add((Control) this.customPanel12);
      this.Controls.Add((Control) this.customPanel10);
      this.Controls.Add((Control) this.customPanel11);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormInterestSetting);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "InterestSetting";
      this.Load += new EventHandler(this.FormInterestSetting_Load);
      ((Control) this.customPanel4).ResumeLayout(false);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((Control) this.customPanel2).ResumeLayout(false);
      ((Control) this.customPanel3).ResumeLayout(false);
      ((Control) this.customPanel5).ResumeLayout(false);
      ((Control) this.customPanel6).ResumeLayout(false);
      ((Control) this.customPanel9).ResumeLayout(false);
      ((Control) this.customPanel9).PerformLayout();
      ((Control) this.customPanel10).ResumeLayout(false);
      ((Control) this.customPanel10).PerformLayout();
      ((Control) this.customPanel11).ResumeLayout(false);
      ((Control) this.customPanel11).PerformLayout();
      ((Control) this.customPanel12).ResumeLayout(false);
      ((Control) this.customPanel12).PerformLayout();
      ((Control) this.customPanel13).ResumeLayout(false);
      ((Control) this.customPanel13).PerformLayout();
      ((Control) this.customPanel14).ResumeLayout(false);
      ((Control) this.customPanel14).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
