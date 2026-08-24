
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Jewellery;
using PawnManagement.Classes.JewelleryClasses;
using PawnManagement.Classes.PawnManagementClasses;
using Square;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.JewelleryForms
{
  public class FormDuplicateBill : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private CrystalReportViewer crystalReportViewer1;
    private SquareButton squareButton1;
    private TextBox textBox1;
    private ComboBox cbCompanyCode;

    public FormDuplicateBill() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void squareButton1_Click(object sender, EventArgs e)
    {
      ReportDocument reportDocument = new ReportDocument();
      this.crystalReportViewer1.ReportSource = (object) FormDuplicateBill.getPledgeReportDocument("", this.textBox1.Text, this.cbCompanyCode.Text, Application.StartupPath + "\\Reports\\SalesInvoice\\asdf.rpt");
      ((Control) this.crystalReportViewer1).Show();
    }

    public static ReportDocument getPledgeReportDocument(
      string defaultPrintFormat,
      string BillNumber,
      string ShopCode,
      string filePath)
    {
      ReportDocument pledgeReportDocument = new ReportDocument();
      DataTable dataTable = new DataTable();
      if (SalesClass.checkIfBillNumberAlreadyExists(BillNumber, ShopCode))
      {
        DataTable bill1 = SalesClass.getBill(BillNumber, ShopCode);
        DataTable bill2 = SalesDetailsClass.getBill(BillNumber, ShopCode);
        DataTable companyDetails = CompanyDetailsClass.getCompanyDetails(ShopCode);
        if (bill1 != null && bill1.Rows.Count > 0)
        {
          DataTable customerDetails = CustomersClass.getCustomerDetails(bill1.Rows[0]["CustomerCode"].ToString());
          if (bill2 != null && bill2.Rows.Count > 0)
          {
            try
            {
              pledgeReportDocument.Load(filePath);
              pledgeReportDocument.SetDataSource(bill1);
              pledgeReportDocument.Subreports[0].SetDataSource(companyDetails);
              pledgeReportDocument.Subreports[1].SetDataSource(customerDetails);
              pledgeReportDocument.Subreports[2].SetDataSource(bill2);
              return pledgeReportDocument;
            }
            catch (Exception ex)
            {
              PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
              throw;
            }
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Bill Number Does not exist");
        }
      }
      return pledgeReportDocument;
    }

    private void FormDuplicateBill_Load(object sender, EventArgs e)
    {
      List<string> stringList = new List<string>();
      this.cbCompanyCode.Items.AddRange((object[]) CompanyDetailsClass.getCompanyNames().ToArray());
      this.cbCompanyCode.SelectedIndex = 0;
      ((Button) this.squareButton1).PerformClick();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
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
      this.panel1 = new Panel();
      this.textBox1 = new TextBox();
      this.cbCompanyCode = new ComboBox();
      this.squareButton1 = new SquareButton();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Dock = DockStyle.Fill;
      ((Control) this.crystalReportViewer1).Location = new Point(0, 36);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(1008, 595);
      ((Control) this.crystalReportViewer1).TabIndex = 5;
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Controls.Add((Control) this.cbCompanyCode);
      this.panel1.Controls.Add((Control) this.squareButton1);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1008, 36);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.textBox1.Location = new Point(511, 7);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 2;
      this.textBox1.Text = "3";
      this.cbCompanyCode.FormattingEnabled = true;
      this.cbCompanyCode.Location = new Point(383, 7);
      this.cbCompanyCode.Name = "cbCompanyCode";
      this.cbCompanyCode.Size = new Size(121, 21);
      this.cbCompanyCode.TabIndex = 1;
      this.squareButton1.BackColor = Color.LightBlue;
      this.squareButton1.FadeOnFocus = true;
      this.squareButton1.ForeColor = Color.MediumBlue;
      this.squareButton1.ForeColorOnFocus = Color.Red;
      this.squareButton1.ForeColorOnLeave = Color.MediumBlue;
      this.squareButton1.GlowColor = Color.White;
      this.squareButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.squareButton1).Location = new Point(8, 7);
      ((Control) this.squareButton1).Name = "squareButton1";
      this.squareButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.squareButton1.ShineColor = Color.Transparent;
      ((Control) this.squareButton1).Size = new Size(106, 23);
      ((Control) this.squareButton1).TabIndex = 0;
      ((Control) this.squareButton1).Text = "&Show";
      ((Control) this.squareButton1).Click += new EventHandler(this.squareButton1_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 631);
      this.Controls.Add((Control) this.crystalReportViewer1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormDuplicateBill);
      this.Text = nameof (FormDuplicateBill);
      this.Load += new EventHandler(this.FormDuplicateBill_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
