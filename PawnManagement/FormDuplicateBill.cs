

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormDuplicateBill : Form
  {
    private List<string> lstAddress = new List<string>();
    private string billNumber = string.Empty;
    private string shopCode = string.Empty;
    private ReportDocument rdDuplicateBill = new ReportDocument();
    private ReportDocument subreport = new ReportDocument();
    private IContainer components = (IContainer) null;
    private TextBox tbxBillNumber;
    private CrystalReportViewer crystalReportViewer1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private GlassButton btnShow;
    private GlassButton btnPrint;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel1;
    private RadioButton rbCustomerCopy;
    private RadioButton rbOfficeCopy;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private RadioButton rbEmpty;

    public FormDuplicateBill() => this.InitializeComponent();

    public FormDuplicateBill(string billNUMBER, string shopCODE)
    {
      this.billNumber = billNUMBER;
      this.shopCode = shopCODE;
      this.InitializeComponent();
    }

    private void getBillNumbers(string shopCode)
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblPledge where shopcode = @ShopCode";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter("ShopCode", (object) shopCode)
        }, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving BillNumbers" + strError);
          PawnManagementClass.InsertIntoException("Form Duplicate Bill print", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.lstAddress.Add(row["BillNumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form duplicateBill.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.rbOfficeCopy.Focus();
    }

    private void printPledge()
    {
      try
      {
        string defaultPrintFormat = !this.rbOfficeCopy.Checked ? (!this.rbCustomerCopy.Checked ? FormDuplicateBill.getDefaultPrintFormatCustomerCopy() : FormDuplicateBill.getDefaultPrintFormatCustomerCopy()) : FormPrintSettings.getDefaultPrintFormat();
        string filePath = !this.rbOfficeCopy.Checked ? (!this.rbCustomerCopy.Checked ? "Reports\\PledgeBill\\" + FormDuplicateBill.getDefaultPrintFormatCustomerCopy() : "Reports\\PledgeBill\\" + FormDuplicateBill.getDefaultPrintFormatCustomerCopy()) : "Reports\\PledgeBill\\" + defaultPrintFormat;
        this.rdDuplicateBill = !this.rbEmpty.Checked ? FormDuplicateBill.getPledgeReportDocument(defaultPrintFormat, this.tbxBillNumber.Text.Trim().ToString(), this.cbShopCodes.Text.Trim(), filePath) : FormDuplicateBill.getEmptyPledgeReportDocument(defaultPrintFormat, this.cbShopCodes.Text.Trim(), filePath);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form pledge.printPledge", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      this.crystalReportViewer1.ReportSource = (object) this.rdDuplicateBill;
      ((Control) this.crystalReportViewer1).Show();
    }

    public static ReportDocument getPledgeReportDocument(
      string defaultPrintFormat,
      string BillNumber,
      string ShopCode,
      string filePath)
    {
      ReportDocument pledgeReportDocument = new ReportDocument();
      if (defaultPrintFormat.Contains("All"))
      {
        if (defaultPrintFormat.Contains("A4"))
        {
          string strError = "";
          string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber = @BillNumber AND shopcode = @ShopCode";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
          parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            int num1 = (int) MessageBox.Show("Enter Valid BillNumber");
          }
          else if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            dataTable2.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable2.Rows[0]["customercode"].ToString() + ".png");
            if (defaultPrintFormat.Contains("Jewel") | defaultPrintFormat.Contains("jewel"))
            {
              dataTable2.Columns.Add("JewelImagePath");
              dataTable2.Rows[0]["JewelImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Jewels\\" + dataTable2.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable2.Rows[0][nameof (ShopCode)].ToString() + ".png");
            }
            DataTable shopDetails1 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable shopDetails2 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable articles = FormDuplicateBill.getArticles(BillNumber, ShopCode);
            shopDetails1.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
            shopDetails1.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
            shopDetails2.Rows[0]["BilledBy"] = (object) (FormMain.startUpPath + "\\PHOTOS\\BILLER\\" + dataTable2.Rows[0]["BilledBy"] + ".png");
            try
            {
              pledgeReportDocument.Load(filePath);
              pledgeReportDocument.SetDataSource(dataTable2);
              pledgeReportDocument.Subreports["SrShopDetails.rpt"].SetDataSource(shopDetails1);
              pledgeReportDocument.Subreports["SrShopDetailss.rpt"].SetDataSource(shopDetails1);
              pledgeReportDocument.Subreports["SrSignature.rpt"].SetDataSource(shopDetails2);
              pledgeReportDocument.Subreports["SrSignaturee.rpt"].SetDataSource(shopDetails2);
              pledgeReportDocument.Subreports["SrArticles"].SetDataSource(articles);
              pledgeReportDocument.Subreports["SrArticless"].SetDataSource(articles);
              pledgeReportDocument.PrintOptions.PaperOrientation = !filePath.Contains("Landscape") ? PaperOrientation.Portrait : PaperOrientation.Landscape;
              return pledgeReportDocument;
            }
            catch (Exception ex)
            {
              PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
              throw;
            }
          }
          else
          {
            int num2 = (int) MessageBox.Show("Bill Number Does not exist");
          }
        }
        else
        {
          string strError = "";
          string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber = @BillNumber AND shopcode = @ShopCode";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
          parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
          DataTable dataTable3 = new DataTable();
          DataTable dataTable4 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            int num3 = (int) MessageBox.Show("Enter Valid BillNumber");
          }
          else if (dataTable4 != null && dataTable4.Rows.Count > 0)
          {
            dataTable4.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable4.Rows[0]["customercode"].ToString() + ".png");
            if (defaultPrintFormat.Contains("Jewel") | defaultPrintFormat.Contains("jewel"))
            {
              dataTable4.Columns.Add("JewelImagePath");
              dataTable4.Rows[0]["JewelImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Jewels\\" + dataTable4.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable4.Rows[0][nameof (ShopCode)].ToString() + ".png");
            }
            DataTable shopDetails3 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable shopDetails4 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable articles = FormDuplicateBill.getArticles(BillNumber, ShopCode);
            shopDetails3.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
            shopDetails3.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
            shopDetails4.Rows[0]["BilledBy"] = (object) (FormMain.startUpPath + "\\PHOTOS\\BILLER\\" + dataTable4.Rows[0]["BilledBy"] + ".png");
            try
            {
              pledgeReportDocument.Load(filePath);
              pledgeReportDocument.SetDataSource(dataTable4);
              pledgeReportDocument.Subreports["SrShopDetails.rpt"].SetDataSource(shopDetails3);
              pledgeReportDocument.Subreports["SrSignature.rpt"].SetDataSource(shopDetails4);
              pledgeReportDocument.Subreports["SrArticles"].SetDataSource(articles);
              pledgeReportDocument.PrintOptions.PaperOrientation = !filePath.Contains("Landscape") ? PaperOrientation.Portrait : PaperOrientation.Landscape;
              return pledgeReportDocument;
            }
            catch (Exception ex)
            {
              PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
              throw;
            }
          }
          else
          {
            int num4 = (int) MessageBox.Show("Bill Number Does not exist");
          }
        }
      }
      if (defaultPrintFormat.Contains("OnlyText"))
      {
        if (defaultPrintFormat.Contains("A4"))
        {
          string strError = "";
          string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber = @BillNumber AND shopcode = @ShopCode";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
          parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
          DataTable dataTable5 = new DataTable();
          DataTable dataTable6 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            int num5 = (int) MessageBox.Show("Enter Valid BillNumber");
          }
          else if (dataTable6 != null && dataTable6.Rows.Count > 0)
          {
            dataTable6.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable6.Rows[0]["customercode"].ToString() + ".png");
            if (defaultPrintFormat.Contains("Jewel") | defaultPrintFormat.Contains("jewel"))
            {
              dataTable6.Columns.Add("JewelImagePath");
              dataTable6.Rows[0]["JewelImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Jewels\\" + dataTable6.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable6.Rows[0][nameof (ShopCode)].ToString() + ".png");
            }
            DataTable shopDetails5 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable shopDetails6 = PawnManagementClass.getShopDetails(ShopCode);
            DataTable articles = FormDuplicateBill.getArticles(BillNumber, ShopCode);
            shopDetails5.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
            shopDetails5.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
            shopDetails6.Rows[0]["BilledBy"] = (object) (FormMain.startUpPath + "\\PHOTOS\\BILLER\\" + dataTable6.Rows[0]["BilledBy"] + ".png");
            try
            {
              pledgeReportDocument.Load(filePath);
              pledgeReportDocument.SetDataSource(dataTable6);
              pledgeReportDocument.Subreports["SrSignature.rpt"].SetDataSource(shopDetails6);
              pledgeReportDocument.Subreports["SrSignaturee.rpt"].SetDataSource(shopDetails6);
              pledgeReportDocument.Subreports["SrArticles"].SetDataSource(articles);
              pledgeReportDocument.Subreports["SrArticless"].SetDataSource(articles);
              pledgeReportDocument.PrintOptions.PaperOrientation = !filePath.Contains("Landscape") ? PaperOrientation.Portrait : PaperOrientation.Landscape;
              return pledgeReportDocument;
            }
            catch (Exception ex)
            {
              PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
              throw;
            }
          }
          else
          {
            int num6 = (int) MessageBox.Show("Bill Number Does not exist");
          }
        }
        else
        {
          string strError = "";
          string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where BillNumber = @BillNumber and shopcode = @ShopCode";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
          parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
          DataTable dataTable7 = new DataTable();
          DataTable dataTable8 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
          if (strError != "")
          {
            int num7 = (int) MessageBox.Show("Enter Valid BillNumber");
          }
          else if (dataTable8 != null && dataTable8.Rows.Count > 0)
          {
            dataTable8.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable8.Rows[0]["customercode"].ToString() + ".png");
            if (defaultPrintFormat.Contains("Jewel") | defaultPrintFormat.Contains("jewel"))
            {
              dataTable8.Columns.Add("JewelImagePath");
              dataTable8.Rows[0]["JewelImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Jewels\\" + dataTable8.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable8.Rows[0][nameof (ShopCode)].ToString() + ".png");
            }
            DataTable articles = FormDuplicateBill.getArticles(BillNumber, ShopCode);
            DataTable shopDetails = PawnManagementClass.getShopDetails(ShopCode);
            shopDetails.Rows[0]["BilledBy"] = (object) (FormMain.startUpPath + "\\PHOTOS\\BILLER\\" + dataTable8.Rows[0]["BilledBy"] + ".png");
            try
            {
              pledgeReportDocument.Load(filePath);
              pledgeReportDocument.SetDataSource(dataTable8);
              pledgeReportDocument.Subreports["SrArticles"].SetDataSource(articles);
              pledgeReportDocument.Subreports["SrSignature.rpt"].SetDataSource(shopDetails);
              pledgeReportDocument.PrintOptions.PaperOrientation = !filePath.Contains("Landscape") ? PaperOrientation.Portrait : PaperOrientation.Landscape;
              return pledgeReportDocument;
            }
            catch (Exception ex)
            {
              PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
              throw;
            }
          }
          else
          {
            int num8 = (int) MessageBox.Show("Bill Number does not exists");
          }
        }
      }
      return pledgeReportDocument;
    }

    public static ReportDocument getEmptyPledgeReportDocument(
      string defaultPrintFormat,
      string ShopCode,
      string filePath)
    {
      ReportDocument pledgeReportDocument = new ReportDocument();
      if (defaultPrintFormat.Contains("All"))
      {
        string strError = "";
        string my_querry = "select *, temp1 as interestrate,temp2 as interest,temp3 as finalinterest,temp4 as redemptionamount from tblpledge where shopcode = @ShopCode";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          int num1 = (int) MessageBox.Show("Enter Valid BillNumber");
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          dataTable2.Rows.Clear();
          dataTable2.Rows.Add();
          dataTable2.Rows[0]["CustomerImagePath"] = (object) "";
          DataTable shopDetails1 = PawnManagementClass.getShopDetails(ShopCode);
          DataTable shopDetails2 = PawnManagementClass.getShopDetails(ShopCode);
          DataTable emptyArticles = ArticlesClass.getEmptyArticles(ShopCode);
          shopDetails1.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
          shopDetails1.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
          try
          {
            pledgeReportDocument.Load(filePath);
            pledgeReportDocument.SetDataSource(dataTable2);
            pledgeReportDocument.Subreports["SrShopDetails.rpt"].SetDataSource(shopDetails1);
            pledgeReportDocument.Subreports["SrSignature.rpt"].SetDataSource(shopDetails2);
            pledgeReportDocument.Subreports["SrArticles"].SetDataSource(emptyArticles);
            pledgeReportDocument.PrintOptions.PaperOrientation = !filePath.Contains("Landscape") ? PaperOrientation.Portrait : PaperOrientation.Landscape;
            return pledgeReportDocument;
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("form pledge.printreport", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            throw;
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Bill Number Does not exist");
        }
      }
      return pledgeReportDocument;
    }

    public static string getDefaultPrintFormatCustomerCopy()
    {
      string strError = "";
      string my_querry = "select * from tblPLEDGEprintSettings where PrintFormatsCustomerCopyDefaultValue = @PrintFormatsCustomerCopyDefaultValue";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("PrintFormatsCustomerCopyDefaultValue", (object) "Y"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form printsettings.getprintsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form printsettings.getprintsettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0]["PrintFormats"].ToString();
      return "";
    }

    public static DataTable getArticles(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblPledgeArticles where BillNumber = @BillNumber AND shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form duplicateBill.getArticles()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form duplicateBill.getArticles()" + strError);
      }
      return dataTable2;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.printPledge();
      ((Control) this.btnPrint).Focus();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormDuplicateBill_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxBillNumber.MaxLength = 7;
      this.getShopCodes();
      if (this.MdiParent != null)
        this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      PawnManagementClass.formatButtonBlue(ref this.btnPrint);
      this.cbShopCodes.Select();
      if (!(this.billNumber != ""))
        return;
      this.cbShopCodes.Text = this.shopCode;
      this.tbxBillNumber.Text = this.billNumber;
      ((Button) this.btnShow).PerformClick();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
            {
              if (this.checkIfBillNumberExists())
                break;
              (sender as TextBox).Select();
              break;
            }
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
            {
              if (!this.checkIfBillNumberExists())
                (sender as TextBox).Select();
            }
            else
            {
              (sender as TextBox).Select();
              (sender as TextBox).Select(3, (sender as TextBox).Text.Length);
            }
            break;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form oldpledge.tbxBillNumber_Leave", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        this.tbxBillNumber.ResetText();
        this.tbxBillNumber.Select();
        this.Refresh();
      }
    }

    private bool checkIfBillNumberExists()
    {
      string strError = "";
      string my_querry = "select BillNumber from tblPledge where BillNumber=@BillNumber AND shopCode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text.Trim().ToString()));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  pledge.tbxBillNumber_TextChanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in checking Bill number already exists or not.\n" + strError);
        return false;
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0;
    }

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (!char.IsLetter(e.KeyChar) || !PawnManagementClass.stringContainALetter((sender as TextBox).Text))
              break;
            e.Handled = true;
            break;
          }
          e.Handled = true;
          break;
        case "DOUBLE":
          if (char.IsLetterOrDigit(e.KeyChar) | e.KeyChar == '\b')
          {
            if (e.KeyChar == ' ')
              e.Handled = true;
            if (char.IsLetter(e.KeyChar) && PawnManagementClass.stringContainsHowManyLetter((sender as TextBox).Text) >= 2)
              e.Handled = true;
            if ((sender as TextBox).Text.Length < 2 && char.IsDigit(e.KeyChar))
              e.Handled = true;
          }
          else
            e.Handled = true;
          break;
      }
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Print?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      this.rdDuplicateBill.PrintToPrinter(1, true, 1, 1);
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillNumber.Select();
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.getBillNumbers(this.cbShopCodes.Text);
        this.tbxBillNumber.Text = PledgeClass.getMaxBillNumber(this.cbShopCodes.Text);
        if (FormMain.BillNumberSeries == "SINGLE")
        {
          this.tbxBillNumber.Select();
          this.tbxBillNumber.Select(2, this.tbxBillNumber.Text.Length);
        }
        else
        {
          this.tbxBillNumber.Select();
          this.tbxBillNumber.Select(3, this.tbxBillNumber.Text.Length);
        }
        this.tbxBillNumber.Select();
        this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxBillNumber.AutoCompleteCustomSource.Clear();
        this.tbxBillNumber.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
      }
      else
        this.cbShopCodes.Select();
    }

    private void rbOfficeCopy_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnShow).Select();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxBillNumber = new TextBox();
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.panel1 = new Panel();
      this.headerPanel1 = new HeaderPanel();
      this.rbEmpty = new RadioButton();
      this.rbCustomerCopy = new RadioButton();
      this.rbOfficeCopy = new RadioButton();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.btnPrint = new GlassButton();
      this.btnShow = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.tbxBillNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxBillNumber.BackColor = Color.AliceBlue;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.CharacterCasing = CharacterCasing.Upper;
      this.tbxBillNumber.Dock = DockStyle.Fill;
      this.tbxBillNumber.Font = new Font("Lucida Fax", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(0, 0);
      this.tbxBillNumber.MaxLength = 6;
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(159, 23);
      this.tbxBillNumber.TabIndex = 0;
      this.tbxBillNumber.TextAlign = HorizontalAlignment.Center;
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.Validating += new CancelEventHandler(this.textBox1_Validating);
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Dock = DockStyle.Fill;
      ((Control) this.crystalReportViewer1).Location = new Point(3, 61);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(1002, 568);
      ((Control) this.crystalReportViewer1).TabIndex = 4;
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.btnPrint);
      this.panel1.Controls.Add((Control) this.btnShow);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 52);
      this.panel1.TabIndex = 8;
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
      this.headerPanel1.CaptionText = "SELECT";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.rbEmpty);
      ((Control) this.headerPanel1).Controls.Add((Control) this.rbCustomerCopy);
      ((Control) this.headerPanel1).Controls.Add((Control) this.rbOfficeCopy);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(434, 2);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(294, 47);
      ((Control) this.headerPanel1).TabIndex = 84;
      this.headerPanel1.TextAntialias = true;
      this.rbEmpty.AutoSize = true;
      this.rbEmpty.BackColor = Color.Transparent;
      this.rbEmpty.Location = new Point(212, 2);
      this.rbEmpty.Name = "rbEmpty";
      this.rbEmpty.Size = new Size(59, 19);
      this.rbEmpty.TabIndex = 4;
      this.rbEmpty.Text = "Empty";
      this.rbEmpty.UseVisualStyleBackColor = false;
      this.rbCustomerCopy.AutoSize = true;
      this.rbCustomerCopy.BackColor = Color.Transparent;
      this.rbCustomerCopy.Checked = true;
      this.rbCustomerCopy.Location = new Point(103, 2);
      this.rbCustomerCopy.Name = "rbCustomerCopy";
      this.rbCustomerCopy.Size = new Size(103, 19);
      this.rbCustomerCopy.TabIndex = 3;
      this.rbCustomerCopy.TabStop = true;
      this.rbCustomerCopy.Text = "CustomerCopy";
      this.rbCustomerCopy.UseVisualStyleBackColor = false;
      this.rbCustomerCopy.KeyDown += new KeyEventHandler(this.rbOfficeCopy_KeyDown);
      this.rbOfficeCopy.AutoSize = true;
      this.rbOfficeCopy.BackColor = Color.Transparent;
      this.rbOfficeCopy.Location = new Point(7, 1);
      this.rbOfficeCopy.Name = "rbOfficeCopy";
      this.rbOfficeCopy.Size = new Size(87, 19);
      this.rbOfficeCopy.TabIndex = 2;
      this.rbOfficeCopy.Text = "Office Copy";
      this.rbOfficeCopy.UseVisualStyleBackColor = false;
      this.rbOfficeCopy.KeyDown += new KeyEventHandler(this.rbOfficeCopy_KeyDown);
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      ((ButtonBase) this.glassButton5).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(-19, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 0;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(115, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel6).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel6).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel6.BorderColor = SystemColors.HotTrack;
      this.headerPanel6.BorderStyle = BorderStyles.Single;
      this.headerPanel6.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel6.CaptionEndColor = Color.AliceBlue;
      this.headerPanel6.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.CaptionHeight = 22;
      this.headerPanel6.CaptionPosition = CaptionPositions.Top;
      this.headerPanel6.CaptionText = "BILL NUMBER";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(269, 3);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(161, 47);
      ((Control) this.headerPanel6).TabIndex = 83;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      ((ButtonBase) this.glassButton3).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(-150, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(-16, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "SELECT LICENSE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(5, 3);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(258, 47);
      ((Control) this.headerPanel7).TabIndex = 82;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(256, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      ((ButtonBase) this.glassButton8).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(-47, 513);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(128, 35);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&SAVE";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(87, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.MediumBlue;
      this.btnPrint.GlowColor = Color.White;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(868, 17);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(128, 32);
      ((Control) this.btnPrint).TabIndex = 9;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((ButtonBase) this.btnPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrint).Click += new EventHandler(this.glassButton2_Click);
      this.btnShow.BackColor = Color.LightBlue;
      this.btnShow.FadeOnFocus = true;
      this.btnShow.ForeColor = Color.MediumBlue;
      this.btnShow.ForeColorOnFocus = Color.Red;
      this.btnShow.ForeColorOnLeave = Color.MediumBlue;
      this.btnShow.GlowColor = Color.White;
      ((ButtonBase) this.btnShow).Image = (Image) Resources.SEARCHGLASS2525;
      this.btnShow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnShow).Location = new Point(734, 17);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(128, 32);
      ((Control) this.btnShow).TabIndex = 8;
      ((Control) this.btnShow).Text = "&SHOW";
      ((ButtonBase) this.btnShow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnShow).Click += new EventHandler(this.button1_Click);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.crystalReportViewer1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.335443f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90.66456f));
      this.tableLayoutPanel1.Size = new Size(1008, 632);
      this.tableLayoutPanel1.TabIndex = 9;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormDuplicateBill);
      this.Text = "Print Duplicate Bill";
      this.Load += new EventHandler(this.FormDuplicateBill_Load);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
