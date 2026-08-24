

using Glass;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormAdminTools : Form
  {
    private string defaultLiense = "";
    private IContainer components = (IContainer) null;
    private GlassButton glassButton2;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private GlassButton btnBillNumberSeriesSetting;
    private GlassButton btnOpenDeviceManager;
    private GlassButton btnChangeBillNumberSeries;
    private GlassButton btnErrorFinder;

    public FormAdminTools(string defaultLIcenseee)
    {
      this.defaultLiense = defaultLIcenseee;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
    }

    private void glassButton2_Click(object sender, EventArgs e) => new FormUpdate().Show();

    private void btnChangeBillNumberSeries_Click(object sender, EventArgs e)
    {
      int num = (int) new FormBillNumberSeriesSettings().ShowDialog();
    }

    private void glassButton4_Click(object sender, EventArgs e)
    {
    }

    private void glassButton5_Click(object sender, EventArgs e) => new FormCreatePureWeight().Show();

    private void glassButton6_Click(object sender, EventArgs e)
    {
      int num = (int) new FormTestingDataGridView().ShowDialog();
    }

    private void FormAdminTools_Load(object sender, EventArgs e)
    {
    }

    private void glassButton7_Click(object sender, EventArgs e)
    {
      string strError1 = "";
      DataTable dataTable = SQLHelper.GetDataTable("select count(*) as counttt from tblredemption", ref strError1);
      if (dataTable != null && dataTable.Rows.Count > 0)
      {
        int num1 = (int) MessageBox.Show("Number of rows in redemption table " + dataTable.Rows[0]["counttt"].ToString());
      }
      string strError2 = "";
      int num2 = (int) MessageBox.Show("Number of rows affected " + SQLHelper.RunCommandAndReturnNumberOfRowsAffected("UPDATE tblpledge INNER JOIN tblRedemption ON tblpledge.billNumber=tblredemption.pledgebillnumber and tblpledge.shopcode  = tblredemption.shopcode SET tblpledge.redemptionbillnumber = tblredemption.billnumber", ref strError2));
    }

    private void btnOpenDeviceManager_Click(object sender, EventArgs e) => Process.Start("devmgmt.msc");

    private void btnChangeBillNumberSeries_Click_1(object sender, EventArgs e)
    {
    }

    private void btnErrorFinder_Click(object sender, EventArgs e)
    {
      int num = (int) new FormErrorFinder().ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.glassButton2 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.btnBillNumberSeriesSetting = new GlassButton();
      this.btnOpenDeviceManager = new GlassButton();
      this.btnChangeBillNumberSeries = new GlassButton();
      this.btnErrorFinder = new GlassButton();
      this.SuspendLayout();
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(12, 12);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(227, 33);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "Update shopcode";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(12, 51);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(227, 33);
      ((Control) this.glassButton5).TabIndex = 4;
      ((Control) this.glassButton5).Text = "pure weight";
      ((Control) this.glassButton5).Click += new EventHandler(this.glassButton5_Click);
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(853, 12);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(143, 33);
      ((Control) this.glassButton6).TabIndex = 5;
      ((Control) this.glassButton6).Text = "testing font";
      ((Control) this.glassButton6).Click += new EventHandler(this.glassButton6_Click);
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(12, 90);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(227, 33);
      ((Control) this.glassButton7).TabIndex = 6;
      ((Control) this.glassButton7).Text = "update redemption bill number";
      ((Control) this.glassButton7).Click += new EventHandler(this.glassButton7_Click);
      this.btnBillNumberSeriesSetting.BackColor = Color.LightBlue;
      this.btnBillNumberSeriesSetting.FadeOnFocus = true;
      this.btnBillNumberSeriesSetting.ForeColor = Color.MediumBlue;
      this.btnBillNumberSeriesSetting.ForeColorOnFocus = Color.Red;
      this.btnBillNumberSeriesSetting.ForeColorOnLeave = Color.MediumBlue;
      this.btnBillNumberSeriesSetting.GlowColor = Color.White;
      this.btnBillNumberSeriesSetting.InnerBorderColor = Color.Transparent;
      ((Control) this.btnBillNumberSeriesSetting).Location = new Point(12, 129);
      ((Control) this.btnBillNumberSeriesSetting).Name = "btnBillNumberSeriesSetting";
      this.btnBillNumberSeriesSetting.OuterBorderColor = Color.MediumSlateBlue;
      this.btnBillNumberSeriesSetting.ShineColor = Color.Transparent;
      ((Control) this.btnBillNumberSeriesSetting).Size = new Size(227, 33);
      ((Control) this.btnBillNumberSeriesSetting).TabIndex = 7;
      ((Control) this.btnBillNumberSeriesSetting).Text = "bill number series setting";
      ((Control) this.btnBillNumberSeriesSetting).Click += new EventHandler(this.btnChangeBillNumberSeries_Click);
      this.btnOpenDeviceManager.BackColor = Color.LightBlue;
      this.btnOpenDeviceManager.FadeOnFocus = true;
      this.btnOpenDeviceManager.ForeColor = Color.MediumBlue;
      this.btnOpenDeviceManager.ForeColorOnFocus = Color.Red;
      this.btnOpenDeviceManager.ForeColorOnLeave = Color.MediumBlue;
      this.btnOpenDeviceManager.GlowColor = Color.White;
      this.btnOpenDeviceManager.InnerBorderColor = Color.Transparent;
      ((Control) this.btnOpenDeviceManager).Location = new Point(13, 169);
      ((Control) this.btnOpenDeviceManager).Name = "btnOpenDeviceManager";
      this.btnOpenDeviceManager.OuterBorderColor = Color.MediumSlateBlue;
      this.btnOpenDeviceManager.ShineColor = Color.Transparent;
      ((Control) this.btnOpenDeviceManager).Size = new Size(226, 45);
      ((Control) this.btnOpenDeviceManager).TabIndex = 8;
      ((Control) this.btnOpenDeviceManager).Text = "Device Manager";
      ((Control) this.btnOpenDeviceManager).Click += new EventHandler(this.btnOpenDeviceManager_Click);
      this.btnChangeBillNumberSeries.BackColor = Color.LightBlue;
      this.btnChangeBillNumberSeries.FadeOnFocus = true;
      this.btnChangeBillNumberSeries.ForeColor = Color.MediumBlue;
      this.btnChangeBillNumberSeries.ForeColorOnFocus = Color.Red;
      this.btnChangeBillNumberSeries.ForeColorOnLeave = Color.MediumBlue;
      this.btnChangeBillNumberSeries.GlowColor = Color.White;
      this.btnChangeBillNumberSeries.InnerBorderColor = Color.Transparent;
      ((Control) this.btnChangeBillNumberSeries).Location = new Point(13, 220);
      ((Control) this.btnChangeBillNumberSeries).Name = "btnChangeBillNumberSeries";
      this.btnChangeBillNumberSeries.OuterBorderColor = Color.MediumSlateBlue;
      this.btnChangeBillNumberSeries.ShineColor = Color.Transparent;
      ((Control) this.btnChangeBillNumberSeries).Size = new Size(226, 45);
      ((Control) this.btnChangeBillNumberSeries).TabIndex = 9;
      ((Control) this.btnChangeBillNumberSeries).Text = "Change BillNumber series";
      ((Control) this.btnChangeBillNumberSeries).Click += new EventHandler(this.btnChangeBillNumberSeries_Click_1);
      this.btnErrorFinder.BackColor = Color.LightBlue;
      this.btnErrorFinder.FadeOnFocus = true;
      this.btnErrorFinder.ForeColor = Color.MediumBlue;
      this.btnErrorFinder.ForeColorOnFocus = Color.Red;
      this.btnErrorFinder.ForeColorOnLeave = Color.MediumBlue;
      this.btnErrorFinder.GlowColor = Color.White;
      this.btnErrorFinder.InnerBorderColor = Color.Transparent;
      ((Control) this.btnErrorFinder).Location = new Point(12, 271);
      ((Control) this.btnErrorFinder).Name = "btnErrorFinder";
      this.btnErrorFinder.OuterBorderColor = Color.MediumSlateBlue;
      this.btnErrorFinder.ShineColor = Color.Transparent;
      ((Control) this.btnErrorFinder).Size = new Size(226, 45);
      ((Control) this.btnErrorFinder).TabIndex = 10;
      ((Control) this.btnErrorFinder).Text = "FORM ERROR FINDER";
      ((Control) this.btnErrorFinder).Click += new EventHandler(this.btnErrorFinder_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.btnErrorFinder);
      this.Controls.Add((Control) this.btnChangeBillNumberSeries);
      this.Controls.Add((Control) this.btnOpenDeviceManager);
      this.Controls.Add((Control) this.btnBillNumberSeriesSetting);
      this.Controls.Add((Control) this.glassButton7);
      this.Controls.Add((Control) this.glassButton6);
      this.Controls.Add((Control) this.glassButton5);
      this.Controls.Add((Control) this.glassButton2);
      this.Name = nameof (FormAdminTools);
      this.Text = nameof (FormAdminTools);
      this.Load += new EventHandler(this.FormAdminTools_Load);
      this.ResumeLayout(false);
    }
  }
}
