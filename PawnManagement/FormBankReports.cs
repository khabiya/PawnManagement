
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormBankReports : Form
  {
    private bool smsclickedOnce = false;
    private DataTable dtReport = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ComboBox cbReleasedOrNot;
    private ComboBox cbBankCode;
    private ComboBox cbMonthly;
    private Label label2;
    private ComboBox cbYearly;
    private Label lblNumberOfRecords;
    private TextBox tbxAmountPending;
    private DataGridViewTextBoxColumn InterestPayable;
    private GlassButton btnPrint;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private TableLayoutPanel tableLayoutPanel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label lblRowsCount;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxTotalAmountPending;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxInterestPending;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private ComboBox comboBox1;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton15;
    private GlassButton glassButton16;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton13;
    private GlassButton glassButton14;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton11;
    private GlassButton glassButton12;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton7;
    private GlassButton glassButton10;
    private ToolStripMenuItem undoRedemptionToolStripMenuItem;
    private ToolStripMenuItem undoRedemptionToolStripMenuItem1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormBankReports() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormBankReports_Load(object sender, EventArgs e)
    {
      try
      {
        this.InterestPayable.DisplayIndex = 0;
        this.InterestPayable.HeaderText = "INTEREST PAYABLE";
        PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
        this.getBankCode();
        this.refreshGrid();
        for (int index = 0; index < 100; ++index)
          this.cbYearly.Items.Add((object) (DateTime.Now.Year - 10 + index));
        if (this.cbYearly.Items.Count > 0)
          this.cbYearly.SelectedIndex = 0;
        if (this.cbBankCode.Items.Count > 0)
          this.cbBankCode.SelectedIndex = 0;
        if (this.cbReleasedOrNot.Items.Count > 0)
          this.cbReleasedOrNot.SelectedIndex = 0;
        if (this.cbMonthly.Items.Count > 0)
          this.cbMonthly.SelectedIndex = 12;
        this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView1.Columns["InterestRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView1.Columns["Interest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView1.Columns["RedemptionAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.getReportTypes();
        if (this.comboBox1.Items.Count > 0)
          this.comboBox1.SelectedIndex = 0;
        this.comboBox1.Text = File.ReadAllLines("Reports\\BankReports\\LastUsed.txt")[0].ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("FormBankReports.FormBankReports_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\BankReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void getBankCode()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankMaster where Active = 1 and type = 'BANK'";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("Form BankReports.getbankCode", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving BankPledge" + strError);
        }
        else
        {
          this.cbBankCode.Items.Clear();
          this.cbBankCode.Items.Add((object) "ALL");
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
            this.cbBankCode.Items.Add((object) row.Field<string>("BankCode"));
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("FormBankReports.getBankCode", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblBankPledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormbankReports.refreshGrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the data from tblBankPledge .\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
      this.dataGridView1.Columns["ID"].Visible = false;
    }

    private void refreshGrid(string Query)
    {
      try
      {
        string strError = "";
        string my_querry = Query;
        DataTable dataTable1 = new DataTable();
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        if (this.cbBankCode.Text.Trim() != "ALL")
          parameters.Add(new OleDbParameter("BankCode", (object) this.cbBankCode.Text.Trim().ToString()));
        if (this.cbReleasedOrNot.Text.Trim().ToString() != "ALL" | this.cbReleasedOrNot.Text.Trim().ToString() != "PLEDGED")
        {
          if (this.cbReleasedOrNot.Text == "RELEASED")
            parameters.Add(new OleDbParameter("Released", (object) "Y"));
          if (this.cbReleasedOrNot.Text == "PENDING")
            parameters.Add(new OleDbParameter("Released", (object) "N"));
        }
        if (this.cbMonthly.Text.Trim().ToString() != "ALL")
        {
          if (this.cbReleasedOrNot.Text == "RELEASED" && this.cbYearly.Text.Trim() != "ALL")
          {
            parameters.Add(new OleDbParameter("month2", (object) (this.cbMonthly.SelectedIndex + 1)));
            parameters.Add(new OleDbParameter("year2", (object) this.cbYearly.Text.Trim().ToString()));
          }
          if (this.cbReleasedOrNot.Text == "RELEASED" && this.cbYearly.Text.Trim() == "ALL")
            parameters.Add(new OleDbParameter("month2", (object) (this.cbMonthly.SelectedIndex + 1)));
          if (this.cbReleasedOrNot.Text == "PLEDGED" | this.cbReleasedOrNot.Text == "PENDING" && this.cbYearly.Text.Trim() != "ALL")
          {
            parameters.Add(new OleDbParameter("month1", (object) (this.cbMonthly.SelectedIndex + 1)));
            parameters.Add(new OleDbParameter("year1", (object) this.cbYearly.Text.Trim().ToString()));
          }
          if (this.cbReleasedOrNot.Text == "PLEDGED" | this.cbReleasedOrNot.Text == "PENDING" && this.cbYearly.Text.Trim() == "ALL")
            parameters.Add(new OleDbParameter("month1", (object) (this.cbMonthly.SelectedIndex + 1)));
          if (this.cbReleasedOrNot.Text == "ALL" && this.cbYearly.Text.Trim() != "ALL")
          {
            parameters.Add(new OleDbParameter("month1", (object) (this.cbMonthly.SelectedIndex + 1)));
            parameters.Add(new OleDbParameter("month2", (object) (this.cbMonthly.SelectedIndex + 1)));
            parameters.Add(new OleDbParameter("year1", (object) this.cbYearly.Text.Trim().ToString()));
            parameters.Add(new OleDbParameter("year2", (object) this.cbYearly.Text.Trim().ToString()));
          }
          if (this.cbReleasedOrNot.Text == "ALL" && this.cbYearly.Text.Trim() == "ALL")
          {
            parameters.Add(new OleDbParameter("month1", (object) (this.cbMonthly.SelectedIndex + 1)));
            parameters.Add(new OleDbParameter("month2", (object) (this.cbMonthly.SelectedIndex + 1)));
          }
        }
        else if (this.cbYearly.Text.Trim() != "ALL")
        {
          parameters.Add(new OleDbParameter("year1", (object) this.cbYearly.Text.Trim().ToString()));
          parameters.Add(new OleDbParameter("year2", (object) this.cbYearly.Text.Trim().ToString()));
        }
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("Form BankReports.refreshGrid(string qyery)", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the data from tblBankPledge .\n" + strError);
        }
        else
          this.dataGridView1.DataSource = (object) dataTable2;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form Bankreports.refreshgrid(string query) outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      try
      {
        if (!(this.cbBankCode.Text.Trim().ToString() != "") || !(this.cbReleasedOrNot.Text.Trim().ToString() != "") || !(this.cbMonthly.Text.Trim().ToString() != ""))
          return;
        StringBuilder stringBuilder = new StringBuilder();
        string str1 = "(select tbp.SerialNumber,tbp.BankCode,tbp.Bankname,tbp.branch,tbp.bankbillnumber,tbp.bankbilldate,tbp.amount,tbp.PledgeBillNumbers,tbp.interestrate,tbp.interesttype,tbp.interest,tbp.redemptionamount,tbp.redemptiondate,tbp.released ";
        if (this.cbBankCode.Text != "ALL")
          stringBuilder.Append("BankCode = @BankCode");
        else
          stringBuilder.Append("");
        if (this.cbReleasedOrNot.Text.Trim().ToString() != "ALL" & this.cbReleasedOrNot.Text.Trim().ToString() != "PLEDGED")
        {
          if (stringBuilder.ToString() != "")
            stringBuilder.Append(" and Released = @Released ");
          else
            stringBuilder.Append(" Released = @Released ");
        }
        else
          stringBuilder.Append("");
        string str2 = "";
        if (this.cbMonthly.Text.Trim().ToString() != "ALL")
        {
          if (this.cbReleasedOrNot.Text == "RELEASED")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
            {
              str2 = str1 + ",month(redemptiondate) as mrd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and mrd = @month2");
              else
                stringBuilder.Append(" mrd = @month2");
            }
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",month(redemptiondate) as mrd , year(redemptiondate) as yrd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and mrd = @month2");
              else
                stringBuilder.Append(" mrd = @month2");
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and  yrd = @year2");
              else
                stringBuilder.Append(" yrd = @year2");
            }
          }
          if (this.cbReleasedOrNot.Text == "PLEDGED" | this.cbReleasedOrNot.Text == "PENDING")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
            {
              str2 = str1 + ",month(bankbilldate) as mbbd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and mbbd = @month1 ");
              else
                stringBuilder.Append("  mbbd = @month1");
            }
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",month(bankbilldate) as mbbd  ,year(bankbilldate) as ybbd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and mbbd = @month1 ");
              else
                stringBuilder.Append("  mbbd = @month1");
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and ybbd = @year1 ");
              else
                stringBuilder.Append(" ybbd = @year1 ");
            }
          }
          if (this.cbReleasedOrNot.Text == "ALL")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
            {
              str2 = str1 + ",month(bankbilldate) as mbbd, month(redemptiondate) as mrd  from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and( mbbd = @month1 or  mrd = @month2)");
              else
                stringBuilder.Append(" ( mbbd = @month1 or  mrd = @month2)");
            }
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",month(bankbilldate) as mbbd, month(redemptiondate) as mrd ,year(bankbilldate) as ybbd, year(redemptiondate) as yrd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and( mbbd = @month1 or  mrd = @month2)");
              else
                stringBuilder.Append(" ( mbbd = @month1 or  mrd = @month2)");
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and (ybbd = @year1 or yrd = @year2)");
              else
                stringBuilder.Append(" (ybbd = @year1 or yrd = @year2)");
            }
          }
        }
        else
        {
          if (this.cbReleasedOrNot.Text == "RELEASED")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
              str2 = str1 + "from tblbankpledge tbp)";
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",year(redemptiondate) as yrd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and  yrd = @year2");
              else
                stringBuilder.Append(" yrd = @year2");
            }
          }
          if (this.cbReleasedOrNot.Text == "PLEDGED" | this.cbReleasedOrNot.Text == "PENDING")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
              str2 = str1 + "from tblbankpledge tbp)";
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",year(bankbilldate) as ybbd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and ybbd = @year1 ");
              else
                stringBuilder.Append(" ybbd = @year1 ");
            }
          }
          if (this.cbReleasedOrNot.Text == "ALL")
          {
            if (this.cbYearly.Text.Trim().ToString() == "ALL")
              str2 = str1 + "from tblbankpledge tbp)";
            if (this.cbYearly.Text.Trim().ToString() != "ALL")
            {
              str2 = str1 + ",year(bankbilldate) as ybbd , year(redemptiondate) as yrd from tblbankpledge tbp)";
              if (stringBuilder.ToString() != "")
                stringBuilder.Append(" and (ybbd = @year1 or yrd = @year2)");
              else
                stringBuilder.Append(" (ybbd = @year1 or yrd = @year2)");
            }
          }
        }
        string str3;
        if (((this.cbBankCode.Text != "ALL" ? 1 : 0) | (!(this.cbReleasedOrNot.Text.Trim() != "ALL") ? 0 : (this.cbReleasedOrNot.Text.Trim() != "PLEDGED" ? 1 : 0)) | (this.cbMonthly.Text != "ALL" ? 1 : 0) | (this.cbYearly.Text != "ALL" ? 1 : 0)) != 0)
          str3 = "select * from " + str2 + " where " + (object) stringBuilder;
        else
          str3 = "select * from " + str2 + (object) stringBuilder;
        if (this.cbReleasedOrNot.Text == "PLEDGED" | this.cbReleasedOrNot.Text == "PENDING")
          str3 += " ORDER BY BANKBILLDATE,SerialNumber";
        if (this.cbReleasedOrNot.Text == "RELEASED")
          str3 += " ORDER BY REDEMPTIONDATE";
        if (this.cbReleasedOrNot.Text == "ALL")
          str3 += " ORDER BY BANKBILLDATE,REDEMPTIONDATE";
        this.refreshGrid(str3.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form bankReports.glassbutton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void reset()
    {
      this.tbxAmountPending.Text = "";
      this.tbxInterestPending.Text = "";
      this.tbxTotalAmountPending.Text = "";
    }

    private void dataGridView1_DataBindingComplete(
      object sender,
      DataGridViewBindingCompleteEventArgs e)
    {
      if (this.cbReleasedOrNot.Text != "PENDING")
        this.InterestPayable.Visible = false;
      if (this.cbReleasedOrNot.Text == "PENDING")
        this.getTotalPending();
      else if (this.cbReleasedOrNot.Text == "RELEASED")
      {
        this.tbxAmountPending.Text = "";
        this.tbxInterestPending.Text = "";
        this.tbxTotalAmountPending.Text = "";
        this.getTotalReleased();
      }
      else
        this.reset();
    }

    private void getTotalPending()
    {
      try
      {
        this.dataGridView1.Columns["InterestPayable"].Visible = true;
        double num1 = 0.0;
        double num2 = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          double numberOfMonths = (double) PawnManagementClass.getNumberOfMonths(DateTime.Parse((row.Cells["BankBillDate"].Value == null || row.Cells["BankBillDate"].Value != null && row.Cells["BankBillDate"].Value.ToString() == "" ? DateTime.Parse("") : DateTime.Parse(row.Cells["BankBillDate"].Value.ToString())).ToString("dd/MM/yyyy")), DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")));
          double num3;
          if (row.Cells["InterestType"].Value.ToString().Equals("SIMPLE INTEREST"))
          {
            DataGridViewCell cell = row.Cells["InterestPayable"];
            num3 = Math.Round(double.Parse(row.Cells["Amount"].Value.ToString()) * numberOfMonths * double.Parse(row.Cells["InterestRate"].Value.ToString()) / 1200.0);
            string str = num3.ToString();
            cell.Value = (object) str;
          }
          if (row.Cells["InterestType"].Value.ToString().Equals("COMPOUND INTEREST YEARLY"))
          {
            DataGridViewCell cell = row.Cells["InterestPayable"];
            num3 = Math.Round(PawnManagementClass.calculateCompundInterest(double.Parse(row.Cells["Amount"].Value.ToString()), numberOfMonths, double.Parse(row.Cells["InterestRate"].Value.ToString())));
            string str = num3.ToString();
            cell.Value = (object) str;
          }
          if (row.Cells["InterestType"].Value.ToString().Equals("COMPOUND INTEREST MONTHLY"))
          {
            DataGridViewCell cell = row.Cells["InterestPayable"];
            num3 = Math.Round(PawnManagementClass.calculatePeriodicCompundInterest(double.Parse(row.Cells["Amount"].Value.ToString()), numberOfMonths, double.Parse(row.Cells["InterestRate"].Value.ToString()), 12.0));
            string str = num3.ToString();
            cell.Value = (object) str;
          }
        }
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          num1 += row.Cells["Amount"].Value == null || row.Cells["Amount"].Value != null && row.Cells["Amount"].Value.ToString() == "" ? 0.0 : double.Parse(row.Cells["Amount"].Value.ToString());
          num2 += row.Cells["InterestPayable"].Value == null || row.Cells["InterestPayable"].Value != null && row.Cells["InterestPayable"].Value.ToString() == "" ? 0.0 : double.Parse(row.Cells["InterestPayable"].Value.ToString());
        }
        this.tbxAmountPending.Text = num1.ToString("F");
        this.tbxInterestPending.Text = num2.ToString("F");
        this.tbxTotalAmountPending.Text = (num1 + num2).ToString("F");
        this.lblNumberOfRecords.Text = this.dataGridView1.Rows.Count.ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form bankReports.getTotalPending", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getTotalReleased()
    {
      try
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          num1 += row.Cells["Amount"].Value == null || row.Cells["Amount"].Value != null && row.Cells["Amount"].Value.ToString() == "" ? 0.0 : double.Parse(row.Cells["Amount"].Value.ToString());
          num2 += row.Cells["Interest"].Value == null || row.Cells["Interest"].Value != null && row.Cells["Interest"].Value.ToString() == "" ? 0.0 : double.Parse(row.Cells["Interest"].Value.ToString());
          num3 += row.Cells["RedemptionAmount"].Value == null || row.Cells["RedemptionAmount"].Value != null && row.Cells["RedemptionAmount"].Value.ToString() == "" ? 0.0 : double.Parse(row.Cells["RedemptionAmount"].Value.ToString());
        }
        this.tbxAmountPending.Text = num1.ToString();
        this.tbxInterestPending.Text = num2.ToString();
        this.tbxTotalAmountPending.Text = num3.ToString();
        this.lblNumberOfRecords.Text = this.dataGridView1.Rows.Count.ToString();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form BankReports.getTotalReleased", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getDatatabledt()
    {
      this.dtReport.Columns.Add("SerialNumber", typeof (string));
      this.dtReport.Columns.Add("BankCode", typeof (string));
      this.dtReport.Columns.Add("BankName", typeof (string));
      this.dtReport.Columns.Add("BankBranch", typeof (string));
      this.dtReport.Columns.Add("BankBillNumber", typeof (string));
      this.dtReport.Columns.Add("BankBillDate", typeof (string));
      this.dtReport.Columns.Add("Amount", typeof (int));
      this.dtReport.Columns.Add("InterestRate", typeof (double));
      this.dtReport.Columns.Add("InterestType", typeof (string));
      this.dtReport.Columns.Add("Interest", typeof (double));
      this.dtReport.Columns.Add("RedemptionAmount", typeof (double));
      this.dtReport.Columns.Add("RedemptionDate", typeof (string));
      this.dtReport.Columns.Add("Released", typeof (string));
      this.dtReport.Columns.Add("PledgeBillNumbers", typeof (string));
    }

    private void getdatatabledtdata()
    {
      try
      {
        this.dtReport.Rows.Clear();
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          string str1 = row.Cells["SerialNumber"].Value == null ? "" : row.Cells["SerialNumber"].Value.ToString();
          string str2 = row.Cells["BankCode"].Value == null ? "" : row.Cells["BankCode"].Value.ToString();
          string str3 = row.Cells["BankName"].Value == null ? "" : row.Cells["BankName"].Value.ToString();
          string str4 = row.Cells["Branch"].Value == null ? "" : row.Cells["Branch"].Value.ToString();
          string str5 = row.Cells["BankBillNumber"].Value == null ? "" : row.Cells["BankBillNumber"].Value.ToString();
          DateTime dateTime;
          string str6;
          if (row.Cells["BankBillDate"].Value != null)
          {
            dateTime = DateTime.Parse(row.Cells["BankBillDate"].Value.ToString());
            str6 = dateTime.ToString("dd/MM/yyyy");
          }
          else
            str6 = "";
          string str7 = str6;
          int num1 = row.Cells["Amount"].Value == null ? 0 : int.Parse(row.Cells["Amount"].Value.ToString());
          double num2 = row.Cells["InterestRate"].Value == null ? 0.0 : Math.Round(double.Parse(row.Cells["InterestRate"].Value.ToString()));
          string str8 = row.Cells["InterestType"].Value == null ? "" : row.Cells["InterestType"].Value.ToString();
          double num3 = ((row.Cells["Interest"].Value == null ? 1 : 0) | (row.Cells["Interest"].Value == null ? 0 : (row.Cells["Interest"].Value.ToString().Equals("") ? 1 : 0))) != 0 ? 0.0 : Math.Round(double.Parse(row.Cells["Interest"].Value.ToString()), 2);
          double num4 = ((row.Cells["RedemptionAmount"].Value == null ? 1 : 0) | (row.Cells["RedemptionAmount"].Value == null ? 0 : (row.Cells["RedemptionAmount"].Value.ToString().Equals("") ? 1 : 0))) != 0 ? 0.0 : Math.Round(double.Parse(row.Cells["RedemptionAmount"].Value.ToString()));
          string str9;
          if (((row.Cells["RedemptionDate"].Value == null ? 1 : 0) | (row.Cells["RedemptionDate"].Value == null ? 0 : (row.Cells["RedemptionDate"].Value.ToString().Equals("") ? 1 : 0))) == 0)
          {
            dateTime = DateTime.Parse(row.Cells["RedemptionDate"].Value.ToString());
            str9 = dateTime.ToString("dd/MM/yyyy");
          }
          else
            str9 = "";
          string str10 = str9;
          string str11 = row.Cells["Released"].Value == null ? "" : row.Cells["Released"].Value.ToString();
          string str12 = row.Cells["PledgeBillNumbers"].Value == null ? "" : row.Cells["PledgeBillNumbers"].Value.ToString();
          this.dtReport.Rows.Add((object) str1, (object) str2, (object) str3, (object) str4, (object) str5, (object) str7, (object) num1, (object) num2, (object) str8, (object) num3, (object) num4, (object) str10, (object) str11, (object) str12);
        }
        this.dtReport.TableName = "BankReports";
        this.dtReport.WriteXmlSchema("Reports\\BankReports\\BankReports.xml");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("getDatatabledtDAta", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.smsclickedOnce)
        {
          this.getDatatabledt();
          this.smsclickedOnce = true;
        }
        this.getdatatabledtdata();
        ReportDocument RD = new ReportDocument();
        RD.Load(this.comboBox1.Text);
        RD.SetDataSource(this.dtReport);
        RD.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
        RD.PrintOptions.PaperSize = PaperSize.PaperA4;
        int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
        PawnManagementClass.InsertIntoHistory("BANK REPORTS PRINT", "Bank report printed", "", "", FormMain.username, DateTime.Now.ToString());
        File.WriteAllText("Reports\\\\BankReports\\\\LastUsed.txt", this.comboBox1.Text);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formbankreports.btnPrint_Cllick", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
      if (this.dataGridView1.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void glassButton2_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "BankReports", FormMain.username);

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "BankReports", FormMain.username);

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void panel3_Paint(object sender, PaintEventArgs e)
    {
    }

    private void dataGridView1_DataSourceChanged(object sender, EventArgs e) => this.lblRowsCount.Text = this.dataGridView1.Rows.Count.ToString();

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void cbBankCode_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void DeleteBankPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      string BankBillNumber = this.dataGridView1.Rows[rowIndex].Cells["BankBillNumber"].Value.ToString();
      string str = this.dataGridView1.Rows[rowIndex].Cells["SerialNumber"].Value.ToString();
      if (this.DeleteFromtblBankPledge(BankBillNumber))
      {
        DataTable dataTable = new DataTable();
        DataTable forBankBillNumber = BankPledgePledgeBillsClass.getPledgeBillsForBankBillNumber(BankBillNumber);
        if (forBankBillNumber != null && forBankBillNumber.Rows.Count > 0)
        {
          foreach (DataRow row in (InternalDataCollectionBase) forBankBillNumber.Rows)
            PawnManagement.Classes.PawnManagementClasses.PledgeClass.ResetBankCodeAndBankSerialNumberInPledgeTable(row["PledgeBillNumber"].ToString(), row["ShopCode"].ToString());
        }
        if (this.getRokadAutoEntrySettings())
        {
          DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(str + "," + BankBillNumber);
          if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
          {
            voucherNumberAndDate.Rows[0]["voucherDate"].ToString();
            string voucherNumber = voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
            if (voucherNumber != "")
              VoucherClass.DeleteVoucherNumber(voucherNumber);
          }
        }
        this.refreshGrid();
      }
    }

    private bool DeleteFromtblBankPledge(string BankBillNumber)
    {
      string strError = "";
      if (SQLHelper.RunCommandWithReturnDoneIfRowsAffectedGreaterThanZero("Delete from tblBankPledge where BankBillNumber=@BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError) == "Done")
        return true;
      PawnManagementClass.InsertIntoException("Form bankRedemption", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Bank redemption" + strError);
      return false;
    }

    private DataTable getVoucherNumberAndDate(string VoucherDescription)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherDescription=@VoucherDescription and active = '1'";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (VoucherDescription), (object) VoucherDescription));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledgeedit.getVoucherName(string voucherdescription)", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledgeedit.getVoucherName(string voucherdescription)" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
            return dataTable2;
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledgeEdit.getInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      return dataTable2;
    }

    private bool getRokadAutoEntrySettings()
    {
      string strError = "";
      string my_querry = "select * from tblAutodeleterokad";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form pledge.getrokadautoentrysettings", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form pledge.getrokadautoentrysettings");
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0 && !dataTable2.Rows[0]["autoentry"].ToString().Equals("Y"))
        return false;
      return true;
    }

    private void exportToExcelOption2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
          CreateExcelFile.CreateExcelDocument((sourceControl as DataGridView).DataSource as DataTable, folderBrowserDialog.SelectedPath + "\\" + (sourceControl as DataGridView).Name + ".xlsx");
      }
    }

    private void undoRedemptionToolStripMenuItem1_Click(object sender, EventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.dataGridView1 = new DataGridView();
      this.InterestPayable = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.undoRedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.undoRedemptionToolStripMenuItem1 = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.cbReleasedOrNot = new ComboBox();
      this.cbBankCode = new ComboBox();
      this.cbMonthly = new ComboBox();
      this.label2 = new Label();
      this.cbYearly = new ComboBox();
      this.lblNumberOfRecords = new Label();
      this.tbxAmountPending = new TextBox();
      this.btnPrint = new GlassButton();
      this.panel1 = new Panel();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxTotalAmountPending = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxInterestPending = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.lblRowsCount = new Label();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton15 = new GlassButton();
      this.glassButton16 = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton13 = new GlassButton();
      this.glassButton14 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton11 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton7 = new GlassButton();
      this.glassButton10 = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.InterestPayable);
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1000, 486);
      this.dataGridView1.TabIndex = 8;
      this.dataGridView1.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
      this.InterestPayable.HeaderText = "InterestPayable";
      this.InterestPayable.Name = "InterestPayable";
      this.InterestPayable.ReadOnly = true;
      this.InterestPayable.Visible = false;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.undoRedemptionToolStripMenuItem,
        (ToolStripItem) this.undoRedemptionToolStripMenuItem1,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.undoRedemptionToolStripMenuItem.Name = "undoRedemptionToolStripMenuItem";
      this.undoRedemptionToolStripMenuItem.Size = new Size(194, 22);
      this.undoRedemptionToolStripMenuItem.Text = "Delete Pledge";
      this.undoRedemptionToolStripMenuItem.Click += new EventHandler(this.DeleteBankPledgeToolStripMenuItem_Click);
      this.undoRedemptionToolStripMenuItem1.Name = "undoRedemptionToolStripMenuItem1";
      this.undoRedemptionToolStripMenuItem1.Size = new Size(194, 22);
      this.undoRedemptionToolStripMenuItem1.Text = "Undo Redemption";
      this.undoRedemptionToolStripMenuItem1.Click += new EventHandler(this.undoRedemptionToolStripMenuItem1_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.cbReleasedOrNot.BackColor = Color.AliceBlue;
      this.cbReleasedOrNot.Dock = DockStyle.Fill;
      this.cbReleasedOrNot.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbReleasedOrNot.FormattingEnabled = true;
      this.cbReleasedOrNot.Items.AddRange(new object[4]
      {
        (object) "PENDING",
        (object) "PLEDGED",
        (object) "RELEASED",
        (object) "ALL"
      });
      this.cbReleasedOrNot.Location = new Point(0, 0);
      this.cbReleasedOrNot.Name = "cbReleasedOrNot";
      this.cbReleasedOrNot.Size = new Size(204, 32);
      this.cbReleasedOrNot.TabIndex = 17;
      this.cbReleasedOrNot.SelectedIndexChanged += new EventHandler(this.glassButton1_Click);
      this.cbReleasedOrNot.KeyPress += new KeyPressEventHandler(this.cbBankCode_KeyPress);
      this.cbBankCode.BackColor = Color.AliceBlue;
      this.cbBankCode.Dock = DockStyle.Fill;
      this.cbBankCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbBankCode.FormattingEnabled = true;
      this.cbBankCode.Location = new Point(0, 0);
      this.cbBankCode.Name = "cbBankCode";
      this.cbBankCode.Size = new Size(357, 32);
      this.cbBankCode.TabIndex = 18;
      this.cbBankCode.SelectedIndexChanged += new EventHandler(this.glassButton1_Click);
      this.cbBankCode.KeyPress += new KeyPressEventHandler(this.cbBankCode_KeyPress);
      this.cbMonthly.BackColor = Color.AliceBlue;
      this.cbMonthly.Dock = DockStyle.Fill;
      this.cbMonthly.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMonthly.FormattingEnabled = true;
      this.cbMonthly.Items.AddRange(new object[13]
      {
        (object) "JANUARY",
        (object) "FEBRUARY",
        (object) "MARCH",
        (object) "APRIL",
        (object) "MAY",
        (object) "JUNE",
        (object) "JULY",
        (object) "AUGUST",
        (object) "SEPTEMBER",
        (object) "OCTOBER",
        (object) "NOVERMBER",
        (object) "DECEMBER",
        (object) "ALL"
      });
      this.cbMonthly.Location = new Point(0, 0);
      this.cbMonthly.Name = "cbMonthly";
      this.cbMonthly.Size = new Size(204, 32);
      this.cbMonthly.TabIndex = 19;
      this.cbMonthly.SelectedIndexChanged += new EventHandler(this.glassButton1_Click);
      this.cbMonthly.KeyPress += new KeyPressEventHandler(this.cbBankCode_KeyPress);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(506, 19);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 24);
      this.label2.TabIndex = 22;
      this.cbYearly.BackColor = Color.AliceBlue;
      this.cbYearly.Dock = DockStyle.Fill;
      this.cbYearly.DropDownHeight = 200;
      this.cbYearly.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbYearly.FormattingEnabled = true;
      this.cbYearly.IntegralHeight = false;
      this.cbYearly.Items.AddRange(new object[1]
      {
        (object) "ALL"
      });
      this.cbYearly.Location = new Point(0, 0);
      this.cbYearly.Name = "cbYearly";
      this.cbYearly.Size = new Size(204, 32);
      this.cbYearly.TabIndex = 24;
      this.cbYearly.SelectedIndexChanged += new EventHandler(this.glassButton1_Click);
      this.cbYearly.KeyPress += new KeyPressEventHandler(this.cbBankCode_KeyPress);
      this.lblNumberOfRecords.AutoSize = true;
      this.lblNumberOfRecords.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblNumberOfRecords.Location = new Point(1307, 488);
      this.lblNumberOfRecords.Name = "lblNumberOfRecords";
      this.lblNumberOfRecords.Size = new Size(16, 24);
      this.lblNumberOfRecords.TabIndex = 32;
      this.lblNumberOfRecords.Text = " ";
      this.tbxAmountPending.BackColor = Color.AliceBlue;
      this.tbxAmountPending.BorderStyle = BorderStyle.None;
      this.tbxAmountPending.Dock = DockStyle.Fill;
      this.tbxAmountPending.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAmountPending.Location = new Point(0, 0);
      this.tbxAmountPending.Name = "tbxAmountPending";
      this.tbxAmountPending.Size = new Size(204, 31);
      this.tbxAmountPending.TabIndex = 37;
      this.tbxAmountPending.TextAlign = HorizontalAlignment.Right;
      ((Control) this.btnPrint).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrint.GlowColor = Color.White;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(292, 6);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(58, 24);
      ((Control) this.btnPrint).TabIndex = 39;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((Control) this.btnPrint).Click += new EventHandler(this.btnPrint_Click);
      this.panel1.Controls.Add((Control) this.headerPanel3);
      this.panel1.Controls.Add((Control) this.headerPanel2);
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Controls.Add((Control) this.headerPanel5);
      this.panel1.Controls.Add((Control) this.lblRowsCount);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 564);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1000, 67);
      this.panel1.TabIndex = 40;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel3.CaptionEndColor = Color.AliceBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "PRINT";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.btnPrint);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(3, 6);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(355, 58);
      ((Control) this.headerPanel3).TabIndex = 79;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton5).Location = new Point(62, 513);
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
      ((Control) this.glassButton6).Location = new Point(196, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(283, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "TOTAL";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxTotalAmountPending);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(791, 6);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(206, 58);
      ((Control) this.headerPanel2).TabIndex = 78;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-89, 513);
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
      ((Control) this.glassButton4).Location = new Point(45, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxTotalAmountPending.BackColor = Color.AliceBlue;
      this.tbxTotalAmountPending.BorderStyle = BorderStyle.None;
      this.tbxTotalAmountPending.Dock = DockStyle.Fill;
      this.tbxTotalAmountPending.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmountPending.Location = new Point(0, 0);
      this.tbxTotalAmountPending.Name = "tbxTotalAmountPending";
      this.tbxTotalAmountPending.Size = new Size(204, 31);
      this.tbxTotalAmountPending.TabIndex = 37;
      this.tbxTotalAmountPending.TextAlign = HorizontalAlignment.Right;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel1.CaptionText = "INTEREST";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxInterestPending);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(577, 6);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(206, 58);
      ((Control) this.headerPanel1).TabIndex = 77;
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
      ((Control) this.glassButton1).Location = new Point(-89, 513);
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
      ((Control) this.glassButton2).Location = new Point(45, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxInterestPending.BackColor = Color.AliceBlue;
      this.tbxInterestPending.BorderStyle = BorderStyle.None;
      this.tbxInterestPending.Dock = DockStyle.Fill;
      this.tbxInterestPending.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestPending.Location = new Point(0, 0);
      this.tbxInterestPending.Name = "tbxInterestPending";
      this.tbxInterestPending.Size = new Size(204, 31);
      this.tbxInterestPending.TabIndex = 37;
      this.tbxInterestPending.TextAlign = HorizontalAlignment.Right;
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel5).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel5).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel5.BorderColor = SystemColors.HotTrack;
      this.headerPanel5.BorderStyle = BorderStyles.Single;
      this.headerPanel5.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel5.CaptionEndColor = Color.AliceBlue;
      this.headerPanel5.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.CaptionHeight = 22;
      this.headerPanel5.CaptionPosition = CaptionPositions.Top;
      this.headerPanel5.CaptionText = "AMOUNT";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxAmountPending);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(363, 6);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(206, 58);
      ((Control) this.headerPanel5).TabIndex = 76;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton8).Location = new Point(-87, 513);
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
      ((Control) this.glassButton9).Location = new Point(47, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.lblRowsCount.AutoSize = true;
      this.lblRowsCount.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblRowsCount.Location = new Point(927, 91);
      this.lblRowsCount.Name = "lblRowsCount";
      this.lblRowsCount.Size = new Size(0, 24);
      this.lblRowsCount.TabIndex = 40;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 72);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1000, 486);
      this.panel2.TabIndex = 41;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.headerPanel8);
      this.panel3.Controls.Add((Control) this.headerPanel7);
      this.panel3.Controls.Add((Control) this.headerPanel6);
      this.panel3.Controls.Add((Control) this.headerPanel4);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 3);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1000, 63);
      this.panel3.TabIndex = 42;
      this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "YEAR";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel8).Controls.Add((Control) this.cbYearly);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(789, 2);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(206, 58);
      ((Control) this.headerPanel8).TabIndex = 78;
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
      ((Control) this.glassButton15).Location = new Point(-91, 513);
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
      ((Control) this.glassButton16).Location = new Point(43, 512);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(123, 37);
      ((Control) this.glassButton16).TabIndex = 1;
      ((Control) this.glassButton16).Text = "&EXIT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel7.CaptionText = "MONTH";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel7).Controls.Add((Control) this.cbMonthly);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(577, 2);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(206, 58);
      ((Control) this.headerPanel7).TabIndex = 78;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton13).Location = new Point(-91, 513);
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
      ((Control) this.glassButton14).Location = new Point(43, 512);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(123, 37);
      ((Control) this.glassButton14).TabIndex = 1;
      ((Control) this.glassButton14).Text = "&EXIT";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
      this.headerPanel6.CaptionText = "PENDING OR RELEASED";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel6).Controls.Add((Control) this.cbReleasedOrNot);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(366, 2);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(206, 58);
      ((Control) this.headerPanel6).TabIndex = 78;
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
      ((Control) this.glassButton11).Location = new Point(-91, 513);
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
      ((Control) this.glassButton12).Location = new Point(43, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel4.CaptionEndColor = Color.AliceBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "BANK CODE";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel4).Controls.Add((Control) this.cbBankCode);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(2, 2);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(359, 58);
      ((Control) this.headerPanel4).TabIndex = 77;
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
      ((Control) this.glassButton7).Location = new Point(64, 513);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(128, 35);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&SAVE";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(198, 512);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(123, 37);
      ((Control) this.glassButton10).TabIndex = 1;
      ((Control) this.glassButton10).Text = "&EXIT";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 2);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(1, 1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.88328f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.60252f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.33859f));
      this.tableLayoutPanel1.Size = new Size(1006, 634);
      this.tableLayoutPanel1.TabIndex = 43;
      this.tableLayoutPanel1.Paint += new PaintEventHandler(this.tableLayoutPanel1_Paint);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.lblNumberOfRecords);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormBankReports);
      this.Padding = new Padding(1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormBankReports);
      this.Load += new EventHandler(this.FormBankReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
