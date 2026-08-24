

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
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
  public class FormRedemptionReports : Form
  {
    private string formType = "";
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private DataTable dtRedemptionReports = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton24;
    private GlassButton glassButton25;
    private TextBox tbxInterest;
    private HeaderPanel headerPanel13;
    private GlassButton glassButton26;
    private GlassButton glassButton27;
    private TextBox tbxAmount;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private TextBox tbxTotal;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private TextBox tbxNumberOfBills;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private ComboBox comboBox1;
    private GlassButton glassButton1;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxFromDate;
    private ToolStripMenuItem uNDORedemptionToolStripMenuItem;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private HeaderPanel headerPanel12;
    private RadioButton rbDesc;
    private GlassButton glassButton22;
    private GlassButton glassButton23;
    private RadioButton rbAsc;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton20;
    private GlassButton glassButton21;
    private ComboBox cbSortBy;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton18;
    private GlassButton glassButton19;
    private ComboBox cbType;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private TextBox tbxSearch;
    private HeaderPanel headerPanel9;
    private RadioButton rbSeperate;
    private GlassButton glassButton16;
    private RadioButton rbJoin;
    private GlassButton glassButton17;
    private CheckBox cbAddress2;
    private CheckBox cbMobileNumber;
    private CheckBox cbName;
    private CheckBox cbAddress1;
    private CheckBox cbPincode;
    private CheckBox cbLocation;
    private CheckBox cbCode;
    private CheckBox cbCity;
    private CheckBox cbNo;
    private CheckBox cbAlterateNumber;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormRedemptionReports(string FORMTYPE)
    {
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    public string getQuery()
    {
      string strError = "";
      string my_querry = "SELECT * from tblOrder where FormName = @FormName";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("FormName", (object) "RedemptionReports")
      }, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        return " t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16";
      }
      return dataTable2 != null && dataTable2.Rows.Count > 0 && ((dataTable2.Rows[0]["ColumnOrder"] == null ? 1 : 0) | (dataTable2.Rows[0]["ColumnOrder"] == null ? 0 : (dataTable2.Rows[0]["ColumnOrder"].ToString() == "" ? 1 : 0))) == 0 ? dataTable2.Rows[0]["ColumnOrder"].ToString() : " t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16";
    }

    private void btnShow_Click(object sender, EventArgs e) => this.getRedemptionReports();

    private string getSortOrder()
    {
      if (this.cbSortBy.Text == "BILL NUMBER")
        return "t.BillNumber";
      if (this.cbSortBy.Text == "CUSTOMER CODE")
        return "t.customercode,t.BillNumber";
      if (this.cbSortBy.Text == "AMOUNT")
        return "t.amount";
      if (this.cbSortBy.Text == "SHOP CODE")
        return "t.shopCode";
      return this.cbSortBy.Text == "TYPE" ? "p.type,p.amount" : "";
    }

    private void refreshGrid(string query)
    {
      if (!(this.tbxFromDate.Text.Trim().ToString() != "") || !(this.tbxToDate.Text.Trim().ToString() != "") || !PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim().ToString()) || !PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.Trim().ToString()) || !(DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()) <= DateTime.Parse(this.tbxToDate.Text.Trim().ToString())))
        return;
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.cbShopCodes.Text != "")
        parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("FromDate", (object) DateTime.Parse(this.tbxFromDate.Text).ToString("dd/MM/yyyy")));
      List<OleDbParameter> oleDbParameterList = parameters;
      DateTime now = DateTime.Parse(this.tbxToDate.Text);
      OleDbParameter oleDbParameter = new OleDbParameter("ToDate", (object) now.ToString("dd/MM/yyyy"));
      oleDbParameterList.Add(oleDbParameter);
      if (this.tbxSearch.Text.Trim() != "")
      {
        parameters.Add(new OleDbParameter("BillNumber", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("BillDate", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("PledgeBillNumber", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("Cname", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("PledgeDate", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("Amount", (object) ("%" + this.tbxSearch.Text + "%")));
      }
      this.dtRedemptionReports = SQLHelper.GetDataTable(query, parameters, ref strError);
      if (strError != "")
      {
        string MessageAnDStackTrace = strError;
        string username = FormMain.username;
        now = DateTime.Now;
        string CreatedOn = now.ToString();
        PawnManagementClass.InsertIntoException("form interest.refresGrid", MessageAnDStackTrace, username, CreatedOn);
        int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dtRedemptionReports;
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private string getNameAndADdress()
    {
      if (this.rbSeperate.Checked)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this.cbCode.Checked)
          stringBuilder.Append("t.cid,");
        if (this.cbName.Checked)
          stringBuilder.Append("t.cname,");
        if (this.cbNo.Checked)
          stringBuilder.Append("t.cno,");
        if (this.cbAddress1.Checked)
          stringBuilder.Append("t.caddr1,");
        if (this.cbAddress2.Checked)
          stringBuilder.Append("t.caddr2,");
        if (this.cbLocation.Checked)
          stringBuilder.Append("t.caddr3,");
        if (this.cbCity.Checked)
          stringBuilder.Append("t.ccity,");
        if (this.cbPincode.Checked)
          stringBuilder.Append("t.cpincode,");
        if (this.cbMobileNumber.Checked)
          stringBuilder.Append("t.cphone as phoneNumber,");
        if (this.cbPincode.Checked)
          stringBuilder.Append("t.ccell,");
        return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
      }
      if (!this.rbJoin.Checked)
        return "";
      StringBuilder stringBuilder1 = new StringBuilder();
      if (this.cbCode.Checked)
        stringBuilder1.Append("t.cid+' '+");
      if (this.cbName.Checked)
        stringBuilder1.Append("t.cname+' '+");
      if (this.cbNo.Checked)
        stringBuilder1.Append("t.cno+' '+");
      if (this.cbAddress1.Checked)
        stringBuilder1.Append("t.caddr1+' '+");
      if (this.cbAddress2.Checked)
        stringBuilder1.Append("t.caddr2+' '+");
      if (this.cbLocation.Checked)
        stringBuilder1.Append("t.caddr3+' '+");
      if (this.cbCity.Checked)
        stringBuilder1.Append("t.ccity+' '+");
      if (this.cbPincode.Checked)
        stringBuilder1.Append("t.cpincode+' '+");
      if (this.cbMobileNumber.Checked)
        stringBuilder1.Append("t.cphone+' '+");
      if (this.cbPincode.Checked)
        stringBuilder1.Append("t.ccell+' '+");
      if (stringBuilder1.Length > 4)
      {
        stringBuilder1.Remove(stringBuilder1.Length - 5, 5);
        stringBuilder1.Append(" as CName,");
      }
      return stringBuilder1.ToString().Substring(0, stringBuilder1.Length - 1);
    }

    private void getRedemptionReports()
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        {
          string newValue = "p.articles";
          string str1 = "";
          string str2 = "";
          DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
          if (articlesSettings.Rows[0]["RedemptionReportsScreen"] != null)
            newValue = "p." + articlesSettings.Rows[0]["RedemptionReportsScreen"].ToString() + " as Articles ";
          if (this.cbShopCodes.Text != "")
            str1 = "shopcode = @ShopCode and ";
          if (this.cbType.Text.Trim() != "")
            str2 = " where p.type in ('" + this.cbType.Text + "') ";
          if (this.tbxSearch.Text.Trim() != "")
            str2 = !(str2 == "") ? str2 + " and  ((t.billnumber like @BillNumber)  or (t.billdate like @BillDate) or (t.pledgebillnumber like @PledgeBillNumber) or (t.cname like @Cname)  or (t.pledgedate like @PledgeDate) or (t.Amount like @Amount))" : str2 + " where  ((t.billnumber like @BillNumber)  or (t.billdate like @BillDate) or (t.pledgebillnumber like @PledgeBillNumber) or (t.cname like @Cname)  or (t.pledgedate like @PledgeDate) or (t.Amount like @Amount) )";
          string str3 = !this.rbAsc.Checked ? "DEsc" : "Asc";
          if (this.cbSortBy.Text != "")
            str2 = str2 + " order by " + this.getSortOrder() + " " + str3 + " ";
          string nameAndAddress = this.getNameAndADdress();
          this.refreshGrid("SELECT " + this.getQuery().Replace("NameAndAddress", nameAndAddress).Replace("articles", newValue) + " from(select r.shopcode,r.billnumber,r.billdate,r.pledgebillnumber,r.customercode,c.cid,c.cno,c.cname,c.caddr1,c.caddr2,c.caddr3,c.CCity,c.Cpincode,c.cphone,c.ccell,r.pledgedate,r.amount,r.temp1 as rateofinterest,r.temp2 as interest,r.InterestLess,r.noticecharge,r.othercharge,r.deductions,r.temp3 as finalinterest,r.temp4 as totalredemptionamount,r.noofmonths,r.noofmonths16,r.interest16,r.redemptionamount16, r.createdon,r.createdby from tblredemption r left join tblcustomers c on r.customercode = c.cid where  " + str1 + " (billdate >= @FromDate and billdate <= @ToDate)) as t left join tblpledge p on t.pledgebillnumber = p.billnumber and t.shopcode = p.shopcode " + str2 + " ");
        }
        else
          this.tbxToDate.Select();
      }
      else
        this.tbxFromDate.Select();
    }

    private void FormRedemptionReports_Load(object sender, EventArgs e)
    {
      this.cbShopCodes.Select();
      this.getShopCodes();
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      if (this.formType == "TODAY")
      {
        this.tbxFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      }
      else
      {
        DataTable redemptionRecord = PawnManagementClass.getOldestRedemptionRecord();
        if (redemptionRecord != null && redemptionRecord.Rows.Count > 0)
          this.tbxFromDate.Text = DateTime.Parse(redemptionRecord.Rows[0]["billdate"].ToString()).ToString("dd/MM/yyyy");
        this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      }
      this.comboBox1.Text = File.ReadAllLines("Reports\\RedemptionReports\\LastUsed.txt")[0].ToString();
      this.cbSortBy.SelectedIndex = 1;
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\RedemptionReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void getRedemptionReportTypes()
    {
      string strError = "";
      string my_querry = "SELECT * from tblprintsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          if (row["RedemptionReportPrintFormats"].ToString() != "")
            this.comboBox1.Items.Add((object) row["RedemptionReportPrintFormats"].ToString());
        }
      }
    }

    private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        num1 += double.Parse(row.Cells["amount"].Value.ToString());
        num2 += double.Parse(row.Cells["FinalInterest"].Value.ToString());
        num3 += double.Parse(row.Cells["TotalRedemptionAmount"].Value.ToString());
      }
      this.tbxNumberOfBills.Text = this.dataGridView1.Rows.Count.ToString();
      this.tbxAmount.Text = num1.ToString();
      this.tbxInterest.Text = num2.ToString();
      this.tbxTotal.Text = num3.ToString();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      ReportDocument RD = new ReportDocument();
      RD.Load(this.comboBox1.Text.Trim());
      RD.SetDataSource(this.dtRedemptionReports);
      RD.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
      RD.PrintOptions.PaperSize = PaperSize.PaperA4;
      int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
      File.WriteAllText("Reports\\\\RedemptionReports\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.DisplayedCells)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Redemption Reports").ShowDialog();
    }

    private void tbxFromDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (!(this.tbxFromDate.Text != "") || e.KeyCode != Keys.Return)
        return;
      this.tbxToDate.Select();
    }

    private void tbxFromDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
        return;
      this.tbxFromDate.Select();
    }

    private void tbxToDate_Validating(object sender, CancelEventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        return;
      this.tbxToDate.Select();
    }

    private void uNDORedemptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (DialogResult.Yes == MessageBox.Show("Are you sure you want to undo the redemption", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand))
      {
        string RedemptionBillNumber = this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
        string PledgeBillNumber = this.dataGridView1.Rows[rowIndex].Cells["PledgeBillNumber"].Value.ToString();
        FormRedemptionReports.UndoRedemption(this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString(), RedemptionBillNumber, PledgeBillNumber);
        this.getRedemptionReports();
      }
    }

    public static string UndoRedemption(
      string ShopCode,
      string RedemptionBillNumber,
      string PledgeBillNumber)
    {
      DataTable voucherNumberAndDate = VoucherClass.getVoucherNumberAndDate(RedemptionBillNumber + " RedemptionBillNumber " + ShopCode);
      if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
      {
        voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
        if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()).ToShortDateString()))
        {
          RedemptionClass.deleteFromRedemptionTable(RedemptionBillNumber, ShopCode);
          PawnManagement.Classes.PawnManagementClasses.PledgeClass.UndoRedemptionInPledgeTable(PledgeBillNumber, ShopCode);
          if (PawnManagementClass.getRokadAutoEntrySettings())
            VoucherClass.deleteFromVoucherTable(RedemptionBillNumber, ShopCode);
          if (File.Exists(FormMain.startUpPath + "Photos\\released by\\" + RedemptionBillNumber + " " + ShopCode + ".png"))
            File.Delete(FormMain.startUpPath + "Photos\\released by\\" + RedemptionBillNumber + " " + ShopCode + ".png");
          PawnManagementClass.InsertIntoHistory("REDEMPTION DELETE", "Redemption Bill Number" + RedemptionBillNumber + "against pledgeBillNumber " + PledgeBillNumber + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
          return "Done";
        }
        int num = (int) MessageBox.Show("Rokad finished for this date...Cannot undo");
        return "";
      }
      PawnManagement.Classes.PawnManagementClasses.PledgeClass.UndoRedemptionInPledgeTable(PledgeBillNumber, ShopCode);
      return RedemptionClass.deleteFromRedemptionTable(RedemptionBillNumber, ShopCode);
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFromDate.Select();
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (!(this.cbShopCodes.Text != "") || this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
        return;
      this.cbShopCodes.Select();
    }

    private void tbxSearch_TextChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void cbShopCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == ""))
        return;
      this.getRedemptionReports();
    }

    private void tbxFromDate_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxFromDate.Text.Length != 10 || !PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.getRedemptionReports();
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxToDate.Text.Length != 10 || !PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.getRedemptionReports();
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void rbAsc_CheckedChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void rbDesc_CheckedChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "customercode")
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "pledgebillnumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["PledgeBillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "billnumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string REDEMPTIONBILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (REDEMPTIONBILLNUMBER != "")
          new FormViewRedemptionBillNew(REDEMPTIONBILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void cbCode_CheckedChanged(object sender, EventArgs e) => this.getRedemptionReports();

    private void changeColumnOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormColumnOrder("RedemptionReports").ShowDialog();
      this.Close();
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.uNDORedemptionToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton24 = new GlassButton();
      this.glassButton25 = new GlassButton();
      this.tbxInterest = new TextBox();
      this.headerPanel13 = new HeaderPanel();
      this.glassButton26 = new GlassButton();
      this.glassButton27 = new GlassButton();
      this.tbxAmount = new TextBox();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.tbxTotal = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.tbxNumberOfBills = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.tbxToDate = new TextBox();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.headerPanel12 = new HeaderPanel();
      this.rbDesc = new RadioButton();
      this.glassButton22 = new GlassButton();
      this.glassButton23 = new GlassButton();
      this.rbAsc = new RadioButton();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton20 = new GlassButton();
      this.glassButton21 = new GlassButton();
      this.cbSortBy = new ComboBox();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton18 = new GlassButton();
      this.glassButton19 = new GlassButton();
      this.cbType = new ComboBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.tbxSearch = new TextBox();
      this.headerPanel9 = new HeaderPanel();
      this.rbSeperate = new RadioButton();
      this.glassButton16 = new GlassButton();
      this.rbJoin = new RadioButton();
      this.glassButton17 = new GlassButton();
      this.cbAddress2 = new CheckBox();
      this.cbMobileNumber = new CheckBox();
      this.cbName = new CheckBox();
      this.cbAddress1 = new CheckBox();
      this.cbPincode = new CheckBox();
      this.cbLocation = new CheckBox();
      this.cbCode = new CheckBox();
      this.cbCity = new CheckBox();
      this.cbNo = new CheckBox();
      this.cbAlterateNumber = new CheckBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel13).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel12).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel9).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.PowderBlue;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeight = 40;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(4, 114);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1000, 454);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.uNDORedemptionToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(198, 158);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(197, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(197, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(197, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.uNDORedemptionToolStripMenuItem.Name = "uNDORedemptionToolStripMenuItem";
      this.uNDORedemptionToolStripMenuItem.Size = new Size(197, 22);
      this.uNDORedemptionToolStripMenuItem.Text = "UNDO Redemption";
      this.uNDORedemptionToolStripMenuItem.Click += new EventHandler(this.uNDORedemptionToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(197, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(197, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option 2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel2.CaptionText = "INTEREST";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton25);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxInterest);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(643, 574);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(150, 58);
      ((Control) this.headerPanel2).TabIndex = 82;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.glassButton24).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton24.BackColor = Color.LightBlue;
      this.glassButton24.FadeOnFocus = true;
      ((Control) this.glassButton24).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton24.ForeColor = Color.MediumBlue;
      this.glassButton24.ForeColorOnFocus = Color.Red;
      this.glassButton24.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton24.GlowColor = Color.White;
      ((ButtonBase) this.glassButton24).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton24.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton24).Location = new Point(-145, 513);
      ((Control) this.glassButton24).Name = "glassButton24";
      this.glassButton24.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton24.ShineColor = Color.Transparent;
      ((Control) this.glassButton24).Size = new Size(128, 35);
      ((Control) this.glassButton24).TabIndex = 0;
      ((Control) this.glassButton24).Text = "&SAVE";
      ((ButtonBase) this.glassButton24).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton25).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton25.BackColor = Color.LightBlue;
      this.glassButton25.FadeOnFocus = true;
      ((Control) this.glassButton25).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton25.ForeColor = Color.MediumBlue;
      this.glassButton25.ForeColorOnFocus = Color.Red;
      this.glassButton25.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton25.GlowColor = Color.White;
      this.glassButton25.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton25).Location = new Point(-11, 512);
      ((Control) this.glassButton25).Name = "glassButton25";
      this.glassButton25.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton25.ShineColor = Color.Transparent;
      ((Control) this.glassButton25).Size = new Size(123, 37);
      ((Control) this.glassButton25).TabIndex = 1;
      ((Control) this.glassButton25).Text = "&EXIT";
      ((ButtonBase) this.glassButton25).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxInterest.BackColor = Color.AliceBlue;
      this.tbxInterest.BorderStyle = BorderStyle.None;
      this.tbxInterest.Dock = DockStyle.Fill;
      this.tbxInterest.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.Location = new Point(0, 0);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(148, 31);
      this.tbxInterest.TabIndex = 26;
      this.tbxInterest.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel13).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel13).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel13).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel13).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel13.BorderColor = SystemColors.HotTrack;
      this.headerPanel13.BorderStyle = BorderStyles.Single;
      this.headerPanel13.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel13.CaptionEndColor = Color.AliceBlue;
      this.headerPanel13.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.CaptionHeight = 22;
      this.headerPanel13.CaptionPosition = CaptionPositions.Top;
      this.headerPanel13.CaptionText = "AMOUNT";
      this.headerPanel13.CaptionVisible = true;
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton26);
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton27);
      ((Control) this.headerPanel13).Controls.Add((Control) this.tbxAmount);
      ((Control) this.headerPanel13).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel13).ForeColor = Color.DarkBlue;
      this.headerPanel13.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.GradientEnd = SystemColors.ControlLight;
      this.headerPanel13.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).Location = new Point(487, 574);
      ((Control) this.headerPanel13).Name = "headerPanel13";
      this.headerPanel13.PanelIcon = (Icon) null;
      this.headerPanel13.PanelIconVisible = false;
      ((Control) this.headerPanel13).Size = new Size(150, 58);
      ((Control) this.headerPanel13).TabIndex = 81;
      this.headerPanel13.TextAntialias = true;
      ((Control) this.glassButton26).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton26.BackColor = Color.LightBlue;
      this.glassButton26.FadeOnFocus = true;
      ((Control) this.glassButton26).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton26.ForeColor = Color.MediumBlue;
      this.glassButton26.ForeColorOnFocus = Color.Red;
      this.glassButton26.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton26.GlowColor = Color.White;
      ((ButtonBase) this.glassButton26).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton26.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton26).Location = new Point(-145, 513);
      ((Control) this.glassButton26).Name = "glassButton26";
      this.glassButton26.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton26.ShineColor = Color.Transparent;
      ((Control) this.glassButton26).Size = new Size(128, 35);
      ((Control) this.glassButton26).TabIndex = 0;
      ((Control) this.glassButton26).Text = "&SAVE";
      ((ButtonBase) this.glassButton26).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton27).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton27.BackColor = Color.LightBlue;
      this.glassButton27.FadeOnFocus = true;
      ((Control) this.glassButton27).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton27.ForeColor = Color.MediumBlue;
      this.glassButton27.ForeColorOnFocus = Color.Red;
      this.glassButton27.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton27.GlowColor = Color.White;
      this.glassButton27.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton27).Location = new Point(-11, 512);
      ((Control) this.glassButton27).Name = "glassButton27";
      this.glassButton27.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton27.ShineColor = Color.Transparent;
      ((Control) this.glassButton27).Size = new Size(123, 37);
      ((Control) this.glassButton27).TabIndex = 1;
      ((Control) this.glassButton27).Text = "&EXIT";
      ((ButtonBase) this.glassButton27).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxAmount.BackColor = Color.AliceBlue;
      this.tbxAmount.BorderStyle = BorderStyle.None;
      this.tbxAmount.Dock = DockStyle.Fill;
      this.tbxAmount.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxAmount.Location = new Point(0, 0);
      this.tbxAmount.Name = "tbxAmount";
      this.tbxAmount.Size = new Size(148, 31);
      this.tbxAmount.TabIndex = 25;
      this.tbxAmount.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel5.CaptionText = "TOTAL";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxTotal);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(798, 574);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(206, 58);
      ((Control) this.headerPanel5).TabIndex = 80;
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
      this.tbxTotal.BackColor = Color.AliceBlue;
      this.tbxTotal.BorderStyle = BorderStyle.None;
      this.tbxTotal.Dock = DockStyle.Fill;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.Location = new Point(0, 0);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(204, 31);
      this.tbxTotal.TabIndex = 26;
      this.tbxTotal.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
      this.headerPanel4.CaptionText = "NUMBER OF BILLS";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxNumberOfBills);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(331, 574);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(150, 58);
      ((Control) this.headerPanel4).TabIndex = 79;
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
      ((Control) this.glassButton6).Location = new Point(-143, 513);
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
      ((Control) this.glassButton7).Location = new Point(-9, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNumberOfBills.BackColor = Color.AliceBlue;
      this.tbxNumberOfBills.BorderStyle = BorderStyle.None;
      this.tbxNumberOfBills.Dock = DockStyle.Fill;
      this.tbxNumberOfBills.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfBills.Location = new Point(0, 0);
      this.tbxNumberOfBills.Name = "tbxNumberOfBills";
      this.tbxNumberOfBills.Size = new Size(148, 31);
      this.tbxNumberOfBills.TabIndex = 25;
      this.tbxNumberOfBills.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(5, 574);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(320, 58);
      ((Control) this.headerPanel3).TabIndex = 78;
      this.headerPanel3.TextAntialias = true;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      ((ButtonBase) this.glassButton4).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(27, 513);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(128, 35);
      ((Control) this.glassButton4).TabIndex = 0;
      ((Control) this.glassButton4).Text = "&SAVE";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(161, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(248, 23);
      this.comboBox1.TabIndex = 23;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(252, 4);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(61, 26);
      ((Control) this.glassButton1).TabIndex = 24;
      ((Control) this.glassButton1).Text = "&PRINT";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.btnPrint_Click);
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
      this.headerPanel1.CaptionText = "TO DATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(531, 4);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(119, 50);
      ((Control) this.headerPanel1).TabIndex = 78;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(-176, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 0;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(-42, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToDate.BackColor = Color.AliceBlue;
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Fill;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(0, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(117, 24);
      this.tbxToDate.TabIndex = 26;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.tbxToDate.Validating += new CancelEventHandler(this.tbxToDate_Validating);
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
      this.headerPanel6.CaptionText = "FROM DATE";
      this.headerPanel6.CaptionVisible = true;
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton10);
      ((Control) this.headerPanel6).Controls.Add((Control) this.glassButton11);
      ((Control) this.headerPanel6).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.headerPanel6).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel6).ForeColor = Color.DarkBlue;
      this.headerPanel6.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel6.GradientEnd = SystemColors.ControlLight;
      this.headerPanel6.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel6).Location = new Point(409, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(119, 50);
      ((Control) this.headerPanel6).TabIndex = 77;
      this.headerPanel6.TextAntialias = true;
      ((Control) this.glassButton10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton10.BackColor = Color.LightBlue;
      this.glassButton10.FadeOnFocus = true;
      ((Control) this.glassButton10).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton10.ForeColor = Color.MediumBlue;
      this.glassButton10.ForeColorOnFocus = Color.Red;
      this.glassButton10.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton10.GlowColor = Color.White;
      ((ButtonBase) this.glassButton10).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton10.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton10).Location = new Point(-176, 513);
      ((Control) this.glassButton10).Name = "glassButton10";
      this.glassButton10.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton10.ShineColor = Color.Transparent;
      ((Control) this.glassButton10).Size = new Size(128, 35);
      ((Control) this.glassButton10).TabIndex = 0;
      ((Control) this.glassButton10).Text = "&SAVE";
      ((ButtonBase) this.glassButton10).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton11.BackColor = Color.LightBlue;
      this.glassButton11.FadeOnFocus = true;
      ((Control) this.glassButton11).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton11.ForeColor = Color.MediumBlue;
      this.glassButton11.ForeColorOnFocus = Color.Red;
      this.glassButton11.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton11.GlowColor = Color.White;
      this.glassButton11.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton11).Location = new Point(-42, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxFromDate.BackColor = Color.AliceBlue;
      this.tbxFromDate.BorderStyle = BorderStyle.None;
      this.tbxFromDate.Dock = DockStyle.Fill;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(0, 0);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(117, 24);
      this.tbxFromDate.TabIndex = 26;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxFromDate_KeyDown);
      this.tbxFromDate.Validating += new CancelEventHandler(this.tbxFromDate_Validating);
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(3, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(209, 50);
      ((Control) this.headerPanel7).TabIndex = 83;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(207, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.cbShopCodes_SelectedIndexChanged);
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
      this.cbShopCodes.Validating += new CancelEventHandler(this.cbShopCodes_Validating);
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      ((ButtonBase) this.glassButton12).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(-96, 513);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(128, 35);
      ((Control) this.glassButton12).TabIndex = 0;
      ((Control) this.glassButton12).Text = "&SAVE";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(38, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel12).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel12).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel12.BorderColor = SystemColors.HotTrack;
      this.headerPanel12.BorderStyle = BorderStyles.Single;
      this.headerPanel12.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel12.CaptionEndColor = Color.AliceBlue;
      this.headerPanel12.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.CaptionHeight = 22;
      this.headerPanel12.CaptionPosition = CaptionPositions.Top;
      this.headerPanel12.CaptionText = "SORT ORDER";
      this.headerPanel12.CaptionVisible = true;
      ((Control) this.headerPanel12).Controls.Add((Control) this.rbDesc);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton22);
      ((Control) this.headerPanel12).Controls.Add((Control) this.glassButton23);
      ((Control) this.headerPanel12).Controls.Add((Control) this.rbAsc);
      ((Control) this.headerPanel12).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel12).ForeColor = Color.DarkBlue;
      this.headerPanel12.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel12.GradientEnd = Color.AliceBlue;
      this.headerPanel12.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel12).Location = new Point(879, 3);
      ((Control) this.headerPanel12).Name = "headerPanel12";
      this.headerPanel12.PanelIcon = (Icon) null;
      this.headerPanel12.PanelIconVisible = false;
      ((Control) this.headerPanel12).Size = new Size(123, 51);
      ((Control) this.headerPanel12).TabIndex = 84;
      this.headerPanel12.TextAntialias = true;
      this.rbDesc.AutoSize = true;
      this.rbDesc.BackColor = Color.Transparent;
      this.rbDesc.Location = new Point(62, 5);
      this.rbDesc.Name = "rbDesc";
      this.rbDesc.Size = new Size(51, 19);
      this.rbDesc.TabIndex = 31;
      this.rbDesc.TabStop = true;
      this.rbDesc.Text = "Desc";
      this.rbDesc.UseVisualStyleBackColor = false;
      this.rbDesc.CheckedChanged += new EventHandler(this.rbDesc_CheckedChanged);
      ((Control) this.glassButton22).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton22.BackColor = Color.LightBlue;
      this.glassButton22.FadeOnFocus = true;
      ((Control) this.glassButton22).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton22.ForeColor = Color.MediumBlue;
      this.glassButton22.ForeColorOnFocus = Color.Red;
      this.glassButton22.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton22.GlowColor = Color.White;
      ((ButtonBase) this.glassButton22).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton22.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton22).Location = new Point(-172, 513);
      ((Control) this.glassButton22).Name = "glassButton22";
      this.glassButton22.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton22.ShineColor = Color.Transparent;
      ((Control) this.glassButton22).Size = new Size(128, 35);
      ((Control) this.glassButton22).TabIndex = 0;
      ((Control) this.glassButton22).Text = "&SAVE";
      ((ButtonBase) this.glassButton22).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton23).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton23.BackColor = Color.LightBlue;
      this.glassButton23.FadeOnFocus = true;
      ((Control) this.glassButton23).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton23.ForeColor = Color.MediumBlue;
      this.glassButton23.ForeColorOnFocus = Color.Red;
      this.glassButton23.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton23.GlowColor = Color.White;
      this.glassButton23.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton23).Location = new Point(-38, 512);
      ((Control) this.glassButton23).Name = "glassButton23";
      this.glassButton23.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton23.ShineColor = Color.Transparent;
      ((Control) this.glassButton23).Size = new Size(123, 37);
      ((Control) this.glassButton23).TabIndex = 1;
      ((Control) this.glassButton23).Text = "&EXIT";
      ((ButtonBase) this.glassButton23).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.rbAsc.AutoSize = true;
      this.rbAsc.BackColor = Color.Transparent;
      this.rbAsc.Checked = true;
      this.rbAsc.Location = new Point(13, 5);
      this.rbAsc.Name = "rbAsc";
      this.rbAsc.Size = new Size(44, 19);
      this.rbAsc.TabIndex = 30;
      this.rbAsc.TabStop = true;
      this.rbAsc.Text = "Asc";
      this.rbAsc.UseVisualStyleBackColor = false;
      this.rbAsc.CheckedChanged += new EventHandler(this.rbAsc_CheckedChanged);
      ((Control) this.headerPanel11).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel11).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel11).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel11).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel11.BorderColor = SystemColors.HotTrack;
      this.headerPanel11.BorderStyle = BorderStyles.Single;
      this.headerPanel11.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel11.CaptionEndColor = Color.AliceBlue;
      this.headerPanel11.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.CaptionHeight = 22;
      this.headerPanel11.CaptionPosition = CaptionPositions.Top;
      this.headerPanel11.CaptionText = "SORT BY";
      this.headerPanel11.CaptionVisible = true;
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton20);
      ((Control) this.headerPanel11).Controls.Add((Control) this.glassButton21);
      ((Control) this.headerPanel11).Controls.Add((Control) this.cbSortBy);
      ((Control) this.headerPanel11).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel11).ForeColor = Color.DarkBlue;
      this.headerPanel11.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel11.GradientEnd = SystemColors.ControlLight;
      this.headerPanel11.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel11).Location = new Point(766, 3);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(110, 51);
      ((Control) this.headerPanel11).TabIndex = 86;
      this.headerPanel11.TextAntialias = true;
      ((Control) this.glassButton20).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton20.BackColor = Color.LightBlue;
      this.glassButton20.FadeOnFocus = true;
      ((Control) this.glassButton20).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton20.ForeColor = Color.MediumBlue;
      this.glassButton20.ForeColorOnFocus = Color.Red;
      this.glassButton20.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton20.GlowColor = Color.White;
      ((ButtonBase) this.glassButton20).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton20.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton20).Location = new Point(-191, 513);
      ((Control) this.glassButton20).Name = "glassButton20";
      this.glassButton20.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton20.ShineColor = Color.Transparent;
      ((Control) this.glassButton20).Size = new Size(128, 35);
      ((Control) this.glassButton20).TabIndex = 0;
      ((Control) this.glassButton20).Text = "&SAVE";
      ((ButtonBase) this.glassButton20).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton21).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton21.BackColor = Color.LightBlue;
      this.glassButton21.FadeOnFocus = true;
      ((Control) this.glassButton21).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton21.ForeColor = Color.MediumBlue;
      this.glassButton21.ForeColorOnFocus = Color.Red;
      this.glassButton21.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton21.GlowColor = Color.White;
      this.glassButton21.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton21).Location = new Point(-57, 512);
      ((Control) this.glassButton21).Name = "glassButton21";
      this.glassButton21.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton21.ShineColor = Color.Transparent;
      ((Control) this.glassButton21).Size = new Size(123, 37);
      ((Control) this.glassButton21).TabIndex = 1;
      ((Control) this.glassButton21).Text = "&EXIT";
      ((ButtonBase) this.glassButton21).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbSortBy.BackColor = Color.AliceBlue;
      this.cbSortBy.Dock = DockStyle.Fill;
      this.cbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbSortBy.FlatStyle = FlatStyle.Popup;
      this.cbSortBy.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbSortBy.FormattingEnabled = true;
      this.cbSortBy.Items.AddRange(new object[5]
      {
        (object) "SHOP CODE",
        (object) "BILL NUMBER",
        (object) "AMOUNT",
        (object) "CUSTOMER CODE",
        (object) "TYPE"
      });
      this.cbSortBy.Location = new Point(0, 0);
      this.cbSortBy.Name = "cbSortBy";
      this.cbSortBy.Size = new Size(108, 24);
      this.cbSortBy.TabIndex = 0;
      this.cbSortBy.SelectedIndexChanged += new EventHandler(this.cbSortBy_SelectedIndexChanged);
      ((Control) this.headerPanel10).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel10).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel10).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel10).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel10.BorderColor = SystemColors.HotTrack;
      this.headerPanel10.BorderStyle = BorderStyles.Single;
      this.headerPanel10.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel10.CaptionEndColor = Color.AliceBlue;
      this.headerPanel10.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.CaptionHeight = 22;
      this.headerPanel10.CaptionPosition = CaptionPositions.Top;
      this.headerPanel10.CaptionText = "TYPE";
      this.headerPanel10.CaptionVisible = true;
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel10).Controls.Add((Control) this.glassButton19);
      ((Control) this.headerPanel10).Controls.Add((Control) this.cbType);
      ((Control) this.headerPanel10).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel10).ForeColor = Color.DarkBlue;
      this.headerPanel10.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel10.GradientEnd = SystemColors.ControlLight;
      this.headerPanel10.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel10).Location = new Point(653, 3);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(110, 51);
      ((Control) this.headerPanel10).TabIndex = 87;
      this.headerPanel10.TextAntialias = true;
      ((Control) this.glassButton18).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton18.BackColor = Color.LightBlue;
      this.glassButton18.FadeOnFocus = true;
      ((Control) this.glassButton18).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton18.ForeColor = Color.MediumBlue;
      this.glassButton18.ForeColorOnFocus = Color.Red;
      this.glassButton18.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton18.GlowColor = Color.White;
      ((ButtonBase) this.glassButton18).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton18.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton18).Location = new Point(-191, 513);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(128, 35);
      ((Control) this.glassButton18).TabIndex = 0;
      ((Control) this.glassButton18).Text = "&SAVE";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton19).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton19.BackColor = Color.LightBlue;
      this.glassButton19.FadeOnFocus = true;
      ((Control) this.glassButton19).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton19.ForeColor = Color.MediumBlue;
      this.glassButton19.ForeColorOnFocus = Color.Red;
      this.glassButton19.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton19.GlowColor = Color.White;
      this.glassButton19.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton19).Location = new Point(-57, 512);
      ((Control) this.glassButton19).Name = "glassButton19";
      this.glassButton19.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton19.ShineColor = Color.Transparent;
      ((Control) this.glassButton19).Size = new Size(123, 37);
      ((Control) this.glassButton19).TabIndex = 1;
      ((Control) this.glassButton19).Text = "&EXIT";
      ((ButtonBase) this.glassButton19).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbType.BackColor = Color.AliceBlue;
      this.cbType.Dock = DockStyle.Fill;
      this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbType.FlatStyle = FlatStyle.Popup;
      this.cbType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[4]
      {
        (object) "",
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(0, 0);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(108, 24);
      this.cbType.TabIndex = 0;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
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
      this.headerPanel8.CaptionText = "SEARCH";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxSearch);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(217, 3);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(189, 51);
      ((Control) this.headerPanel8).TabIndex = 85;
      this.headerPanel8.TextAntialias = true;
      ((Control) this.glassButton14).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton14.BackColor = Color.LightBlue;
      this.glassButton14.FadeOnFocus = true;
      ((Control) this.glassButton14).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton14.ForeColor = Color.MediumBlue;
      this.glassButton14.ForeColorOnFocus = Color.Red;
      this.glassButton14.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton14.GlowColor = Color.White;
      ((ButtonBase) this.glassButton14).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton14.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton14).Location = new Point(-108, 513);
      ((Control) this.glassButton14).Name = "glassButton14";
      this.glassButton14.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton14.ShineColor = Color.Transparent;
      ((Control) this.glassButton14).Size = new Size(128, 35);
      ((Control) this.glassButton14).TabIndex = 0;
      ((Control) this.glassButton14).Text = "&SAVE";
      ((ButtonBase) this.glassButton14).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton15).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton15.BackColor = Color.LightBlue;
      this.glassButton15.FadeOnFocus = true;
      ((Control) this.glassButton15).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton15.ForeColor = Color.MediumBlue;
      this.glassButton15.ForeColorOnFocus = Color.Red;
      this.glassButton15.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton15.GlowColor = Color.White;
      this.glassButton15.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton15).Location = new Point(26, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSearch.BackColor = Color.AliceBlue;
      this.tbxSearch.BorderStyle = BorderStyle.None;
      this.tbxSearch.Dock = DockStyle.Fill;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(0, 0);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(187, 24);
      this.tbxSearch.TabIndex = 26;
      this.tbxSearch.TextAlign = HorizontalAlignment.Center;
      this.tbxSearch.TextChanged += new EventHandler(this.tbxSearch_TextChanged);
      ((Control) this.headerPanel9).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel9).BackColor = Color.AliceBlue;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.HotTrack;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel9.CaptionEndColor = Color.AliceBlue;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "Name and Address should include";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.rbSeperate);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel9).Controls.Add((Control) this.rbJoin);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbAddress2);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbMobileNumber);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbName);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbAddress1);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbPincode);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbLocation);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbCode);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbCity);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbNo);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbAlterateNumber);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = Color.Azure;
      this.headerPanel9.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel9).Location = new Point(1, 60);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(1001, 51);
      ((Control) this.headerPanel9).TabIndex = 88;
      this.headerPanel9.TextAntialias = true;
      this.rbSeperate.Anchor = AnchorStyles.Top;
      this.rbSeperate.AutoSize = true;
      this.rbSeperate.BackColor = Color.Transparent;
      this.rbSeperate.Location = new Point(877, 6);
      this.rbSeperate.Name = "rbSeperate";
      this.rbSeperate.Size = new Size(71, 19);
      this.rbSeperate.TabIndex = 1;
      this.rbSeperate.TabStop = true;
      this.rbSeperate.Text = "Seperate";
      this.rbSeperate.UseVisualStyleBackColor = false;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      ((ButtonBase) this.glassButton16).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(708, 513);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(128, 35);
      ((Control) this.glassButton16).TabIndex = 0;
      ((Control) this.glassButton16).Text = "&SAVE";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.rbJoin.Anchor = AnchorStyles.Top;
      this.rbJoin.AutoSize = true;
      this.rbJoin.BackColor = Color.Transparent;
      this.rbJoin.Checked = true;
      this.rbJoin.Location = new Point(821, 6);
      this.rbJoin.Name = "rbJoin";
      this.rbJoin.Size = new Size(47, 19);
      this.rbJoin.TabIndex = 0;
      this.rbJoin.TabStop = true;
      this.rbJoin.Text = "Join";
      this.rbJoin.UseVisualStyleBackColor = false;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(842, 512);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(123, 37);
      ((Control) this.glassButton17).TabIndex = 1;
      ((Control) this.glassButton17).Text = "&EXIT";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbAddress2.Anchor = AnchorStyles.Top;
      this.cbAddress2.AutoSize = true;
      this.cbAddress2.BackColor = Color.Transparent;
      this.cbAddress2.Location = new Point(285, 6);
      this.cbAddress2.Name = "cbAddress2";
      this.cbAddress2.Size = new Size(75, 19);
      this.cbAddress2.TabIndex = 11;
      this.cbAddress2.Text = "Address2";
      this.cbAddress2.UseVisualStyleBackColor = false;
      this.cbAddress2.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbMobileNumber.Anchor = AnchorStyles.Top;
      this.cbMobileNumber.AutoSize = true;
      this.cbMobileNumber.BackColor = Color.Transparent;
      this.cbMobileNumber.Location = new Point(583, 6);
      this.cbMobileNumber.Name = "cbMobileNumber";
      this.cbMobileNumber.Size = new Size(110, 19);
      this.cbMobileNumber.TabIndex = 15;
      this.cbMobileNumber.Text = "Mobile Number";
      this.cbMobileNumber.UseVisualStyleBackColor = false;
      this.cbMobileNumber.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbName.Anchor = AnchorStyles.Top;
      this.cbName.AutoSize = true;
      this.cbName.BackColor = Color.Transparent;
      this.cbName.Checked = true;
      this.cbName.CheckState = CheckState.Checked;
      this.cbName.Location = new Point(134, 6);
      this.cbName.Name = "cbName";
      this.cbName.Size = new Size(58, 19);
      this.cbName.TabIndex = 8;
      this.cbName.Text = "Name";
      this.cbName.UseVisualStyleBackColor = false;
      this.cbName.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbAddress1.Anchor = AnchorStyles.Top;
      this.cbAddress1.AutoSize = true;
      this.cbAddress1.BackColor = Color.Transparent;
      this.cbAddress1.Location = new Point(201, 6);
      this.cbAddress1.Name = "cbAddress1";
      this.cbAddress1.Size = new Size(73, 19);
      this.cbAddress1.TabIndex = 10;
      this.cbAddress1.Text = "Address1";
      this.cbAddress1.UseVisualStyleBackColor = false;
      this.cbAddress1.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbPincode.Anchor = AnchorStyles.Top;
      this.cbPincode.AutoSize = true;
      this.cbPincode.BackColor = Color.Transparent;
      this.cbPincode.Location = new Point(505, 6);
      this.cbPincode.Name = "cbPincode";
      this.cbPincode.Size = new Size(69, 19);
      this.cbPincode.TabIndex = 14;
      this.cbPincode.Text = "Pincode";
      this.cbPincode.UseVisualStyleBackColor = false;
      this.cbPincode.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbLocation.Anchor = AnchorStyles.Top;
      this.cbLocation.AutoSize = true;
      this.cbLocation.BackColor = Color.Transparent;
      this.cbLocation.Location = new Point(369, 6);
      this.cbLocation.Name = "cbLocation";
      this.cbLocation.Size = new Size(72, 19);
      this.cbLocation.TabIndex = 12;
      this.cbLocation.Text = "Location";
      this.cbLocation.UseVisualStyleBackColor = false;
      this.cbLocation.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbCode.Anchor = AnchorStyles.Top;
      this.cbCode.AutoSize = true;
      this.cbCode.BackColor = Color.Transparent;
      this.cbCode.Location = new Point(21, 6);
      this.cbCode.Name = "cbCode";
      this.cbCode.Size = new Size(53, 19);
      this.cbCode.TabIndex = 7;
      this.cbCode.Text = "Code";
      this.cbCode.UseVisualStyleBackColor = false;
      this.cbCode.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbCity.Anchor = AnchorStyles.Top;
      this.cbCity.AutoSize = true;
      this.cbCity.BackColor = Color.Transparent;
      this.cbCity.Location = new Point(450, 6);
      this.cbCity.Name = "cbCity";
      this.cbCity.Size = new Size(46, 19);
      this.cbCity.TabIndex = 13;
      this.cbCity.Text = "City";
      this.cbCity.UseVisualStyleBackColor = false;
      this.cbCity.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbNo.Anchor = AnchorStyles.Top;
      this.cbNo.AutoSize = true;
      this.cbNo.BackColor = Color.Transparent;
      this.cbNo.Location = new Point(83, 6);
      this.cbNo.Name = "cbNo";
      this.cbNo.Size = new Size(42, 19);
      this.cbNo.TabIndex = 9;
      this.cbNo.Text = "No";
      this.cbNo.UseVisualStyleBackColor = false;
      this.cbNo.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbAlterateNumber.Anchor = AnchorStyles.Top;
      this.cbAlterateNumber.AutoSize = true;
      this.cbAlterateNumber.BackColor = Color.Transparent;
      this.cbAlterateNumber.Location = new Point(702, 6);
      this.cbAlterateNumber.Name = "cbAlterateNumber";
      this.cbAlterateNumber.Size = new Size(121, 19);
      this.cbAlterateNumber.TabIndex = 16;
      this.cbAlterateNumber.Text = "Alternate Number";
      this.cbAlterateNumber.UseVisualStyleBackColor = false;
      this.cbAlterateNumber.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.headerPanel9);
      this.Controls.Add((Control) this.headerPanel12);
      this.Controls.Add((Control) this.headerPanel11);
      this.Controls.Add((Control) this.headerPanel10);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel13);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormRedemptionReports);
      this.Text = nameof (FormRedemptionReports);
      this.Load += new EventHandler(this.FormRedemptionReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel13).ResumeLayout(false);
      ((Control) this.headerPanel13).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel12).ResumeLayout(false);
      ((Control) this.headerPanel12).PerformLayout();
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel9).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
