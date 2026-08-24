
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormCrystalReportViewer : Form
  {
    private ReportDocument rd = new ReportDocument();
    private string path;
    private DataTable dt = new DataTable();
    private DataTable dtSubReport1 = new DataTable();
    private PaperSize paperSize;
    private PaperOrientation paperOritentation;
    private IContainer components = (IContainer) null;
    private CrystalReportViewer crystalReportViewer1;
    private Button button1;

    public FormCrystalReportViewer(
      string Path,
      DataTable Dt,
      PaperSize paperSIZE,
      PaperOrientation paperORIENTATION)
    {
      this.InitializeComponent();
      this.path = Path;
      this.dt = Dt;
      this.paperSize = paperSIZE;
      this.paperOritentation = paperORIENTATION;
    }

    public FormCrystalReportViewer(string Path, DataTable Dt, DataTable DTSUBREPORT)
    {
      this.InitializeComponent();
      this.path = Path;
      this.dt = Dt;
      this.dtSubReport1 = DTSUBREPORT;
    }

    public FormCrystalReportViewer(ReportDocument RD)
    {
      this.InitializeComponent();
      this.rd = RD;
    }

    public FormCrystalReportViewer(
      ReportDocument RD,
      PaperOrientation paperORIENTATION,
      PaperSize paperSIZE)
    {
      this.paperOritentation = paperORIENTATION;
      this.paperSize = paperSIZE;
      this.InitializeComponent();
      this.rd = RD;
    }

    public FormCrystalReportViewer() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void CrystalReportViewer_Load(object sender, EventArgs e)
    {
      try
      {
        this.crystalReportViewer1.ReportSource = (object) this.rd;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form crystalreportviewer.crystalReportViewr_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void crystalReportViewer1_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
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
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.button1 = new Button();
      this.SuspendLayout();
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Dock = DockStyle.Fill;
      ((Control) this.crystalReportViewer1).Location = new Point(0, 0);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(1070, 728);
      ((Control) this.crystalReportViewer1).TabIndex = 0;
      ((UserControl) this.crystalReportViewer1).Load += new EventHandler(this.crystalReportViewer1_Load);
      this.button1.Location = new Point(934, 12);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1070, 728);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.crystalReportViewer1);
      this.Name = nameof (FormCrystalReportViewer);
      this.Text = "CrystallllllllReportViewer";
      this.Load += new EventHandler(this.CrystalReportViewer_Load);
      this.ResumeLayout(false);
    }
  }
}
