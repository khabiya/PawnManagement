

using CrystalDecisions.CrystalReports.Engine;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
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
  public class FormPledgeReports : Form
  {
    private string type = "";
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private DataTable dtpledgeReports = new DataTable();
    private bool loadFinished = false;
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxTotal;
    private TextBox tbxNumberOfBills;
    private ComboBox cbReleased;
    private GlassButton glassButton1;
    private ComboBox comboBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private CheckBox cbCode;
    private CheckBox cbName;
    private CheckBox cbAddress1;
    private CheckBox cbNo;
    private CheckBox cbPincode;
    private CheckBox cbCity;
    private CheckBox cbLocation;
    private CheckBox cbAddress2;
    private CheckBox cbAlterateNumber;
    private CheckBox cbMobileNumber;
    private RadioButton rbSeperate;
    private RadioButton rbJoin;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private RadioButton rbDesc;
    private RadioButton rbAsc;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxFromDate;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton12;
    private GlassButton glassButton13;
    private TextBox tbxSearch;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel9;
    private GlassButton glassButton16;
    private GlassButton glassButton17;
    private HeaderPanel headerPanel10;
    private GlassButton glassButton18;
    private GlassButton glassButton19;
    private ComboBox cbType;
    private HeaderPanel headerPanel11;
    private GlassButton glassButton20;
    private GlassButton glassButton21;
    private ComboBox cbSortBy;
    private HeaderPanel headerPanel12;
    private GlassButton glassButton22;
    private GlassButton glassButton23;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton24;
    private GlassButton glassButton25;
    private TextBox tbxNetWeightSilver;
    private HeaderPanel headerPanel13;
    private GlassButton glassButton26;
    private GlassButton glassButton27;
    private TextBox tbxNetWeightGold;
    private HeaderPanel headerPanel14;
    private ComboBox cbShopCodes;
    private GlassButton glassButton28;
    private GlassButton glassButton29;
    private ToolStripMenuItem dELETEPledgeToolStripMenuItem;
    private ToolStripMenuItem fillWeightToolStripMenuItem;
    private ToolStripMenuItem withPasswordToolStripMenuItem;
    private ToolStripMenuItem withoutPasswordToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;

    public FormPledgeReports() => this.InitializeComponent();

    public FormPledgeReports(string TYPE)
    {
      this.type = TYPE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPledgeReports_Load(object sender, EventArgs e)
    {
      if (this.cbReleased.Items.Count == 3)
        this.cbReleased.SelectedIndex = 2;
      PawnManagementClass.formatDataGridViewBluePledgeAutoWrapRow(ref this.dataGridView1);
      this.dataGridView1.GridColor = Color.PowderBlue;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
      if (this.type == "today")
      {
        this.tbxFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      }
      else if (this.type == "PLEDGEEXPIRINGTODAY")
      {
        DateTime dateTime = DateTime.Now.AddYears(-1);
        this.tbxFromDate.Text = dateTime.ToString("dd/MM/yyyy");
        this.tbxToDate.Text = dateTime.ToString("dd/MM/yyyy");
      }
      else if (this.type == "PLEDGEEXPIRINGTHISMONTH")
      {
        DateTime dateTime = DateTime.Now.AddYears(-1);
        TextBox tbxFromDate = this.tbxFromDate;
        object[] objArray1 = new object[5]
        {
          (object) 1,
          (object) "/",
          null,
          null,
          null
        };
        DateTime now = DateTime.Now;
        objArray1[2] = (object) now.Month;
        objArray1[3] = (object) "/";
        objArray1[4] = (object) dateTime.Year;
        string str1 = string.Concat(objArray1);
        tbxFromDate.Text = str1;
        string str2 = "";
        now = DateTime.Now;
        if (now.Month == 2)
          str2 = "28";
        now = DateTime.Now;
        int num1 = now.Month == 1 ? 1 : 0;
        now = DateTime.Now;
        int num2 = now.Month == 3 ? 1 : 0;
        int num3 = num1 | num2;
        now = DateTime.Now;
        int num4 = now.Month == 5 ? 1 : 0;
        int num5 = num3 | num4;
        now = DateTime.Now;
        int num6 = now.Month == 7 ? 1 : 0;
        int num7 = num5 | num6;
        now = DateTime.Now;
        int num8 = now.Month == 8 ? 1 : 0;
        int num9 = num7 | num8;
        now = DateTime.Now;
        int num10 = now.Month == 10 ? 1 : 0;
        int num11 = num9 | num10;
        now = DateTime.Now;
        int num12 = now.Month == 12 ? 1 : 0;
        if ((num11 | num12) != 0)
          str2 = "31";
        now = DateTime.Now;
        int num13 = now.Month == 4 ? 1 : 0;
        now = DateTime.Now;
        int num14 = now.Month == 6 ? 1 : 0;
        int num15 = num13 | num14;
        now = DateTime.Now;
        int num16 = now.Month == 9 ? 1 : 0;
        int num17 = num15 | num16;
        now = DateTime.Now;
        int num18 = now.Month == 11 ? 1 : 0;
        if ((num17 | num18) != 0)
          str2 = "30";
        TextBox tbxToDate = this.tbxToDate;
        object[] objArray2 = new object[5]
        {
          (object) str2,
          (object) "/",
          null,
          null,
          null
        };
        now = DateTime.Now;
        objArray2[2] = (object) now.Month;
        objArray2[3] = (object) "/";
        objArray2[4] = (object) dateTime.Year;
        string str3 = string.Concat(objArray2);
        tbxToDate.Text = str3;
      }
      else
      {
        DataTable unredeemedPledgeRecord = PawnManagementClass.getOldestUnredeemedPledgeRecord();
        if (unredeemedPledgeRecord != null && unredeemedPledgeRecord.Rows.Count > 0)
          this.tbxFromDate.Text = DateTime.Parse(unredeemedPledgeRecord.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
        this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      }
      this.tbxFromDate.Select();
      this.getPledgeReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\PledgeReports\\LastUsed.txt")[0].ToString();
      this.getShopCodes();
      this.cbShopCodes.Text = "";
      if (this.cbSortBy.Items.Count > 0)
        this.cbSortBy.SelectedIndex = 1;
      this.loadFinished = true;
      this.refreshGrid(this.buildQuery());
    }

    private void getPledgeReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\PledgeReports\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void refreshGrid(string query)
    {
      if (!this.loadFinished)
        return;
      try
      {
        string strError = "";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        if (this.cbShopCodes.Text != "")
          parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
        if (this.tbxFromDate.Text.Trim().ToString() != "" && this.tbxToDate.Text.Trim().ToString() != "" && PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim().ToString()) && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.Trim().ToString()) && DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()) <= DateTime.Parse(this.tbxToDate.Text.Trim().ToString()))
        {
          parameters.Add(new OleDbParameter("FromDate", (object) DateTime.Parse(this.tbxFromDate.Text).ToString("dd/MM/yyyy")));
          parameters.Add(new OleDbParameter("ToDate", (object) DateTime.Parse(this.tbxToDate.Text).ToString("dd/MM/yyyy")));
        }
        parameters.Add(new OleDbParameter("searchNameAndAddress", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("searchBillDate", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("searchBillNumber", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("searchAmount", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("searchArticles", (object) ("%" + this.tbxSearch.Text + "%")));
        parameters.Add(new OleDbParameter("searchNetWeight", (object) ("%" + this.tbxSearch.Text + "%")));
        this.dtpledgeReports = SQLHelper.GetDataTable(query, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form interest.refresGrid", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
        }
        else
        {
          if (this.dtpledgeReports != null && this.dtpledgeReports.Rows.Count > 0)
            WaitWindow.Show(new EventHandler<WaitWindowEventArgs>(this.decrypting));
          this.dataGridView1.DataSource = (object) this.dtpledgeReports;
        }
        this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        this.dataGridView1.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        this.dataGridView1.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        this.dataGridView1.Columns["InterestRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        this.dataGridView1.Columns["bILLnUMBER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
        if (this.cbReleased.Text == "N")
        {
          this.dataGridView1.Columns["ShopCode"].FillWeight = 186f;
          this.dataGridView1.Columns["BillNumber"].FillWeight = 115f;
          this.dataGridView1.Columns["OldBillNumber"].FillWeight = 162f;
          this.dataGridView1.Columns["BillDate"].FillWeight = 148f;
          this.dataGridView1.Columns["CustomerCode"].FillWeight = 81f;
          this.dataGridView1.Columns["NameAndAddress"].FillWeight = 512f;
          this.dataGridView1.Columns["Amount"].FillWeight = 131f;
          this.dataGridView1.Columns["PresentValue"].FillWeight = (float) sbyte.MaxValue;
          this.dataGridView1.Columns["NetWeight"].FillWeight = 115f;
          this.dataGridView1.Columns["InterestRate"].FillWeight = 56f;
          this.dataGridView1.Columns["Type"].FillWeight = 82f;
          this.dataGridView1.Columns["Articles"].FillWeight = 413f;
          this.dataGridView1.Columns["BankCode"].FillWeight = 115f;
          this.dataGridView1.Columns["BankSerialNumber"].FillWeight = 47f;
          this.dataGridView1.Columns["Redeemed"].Visible = false;
          this.dataGridView1.Columns["RedemptionAmount"].Visible = false;
          this.dataGridView1.Columns["RedemptionDate"].Visible = false;
          this.dataGridView1.Columns["FinalInterest"].Visible = false;
        }
        else
        {
          this.dataGridView1.Columns["ShopCode"].FillWeight = 186f;
          this.dataGridView1.Columns["BillNumber"].FillWeight = 115f;
          this.dataGridView1.Columns["OldBillNumber"].FillWeight = 162f;
          this.dataGridView1.Columns["BillDate"].FillWeight = 170f;
          this.dataGridView1.Columns["CustomerCode"].FillWeight = 81f;
          this.dataGridView1.Columns["NameAndAddress"].FillWeight = 300f;
          this.dataGridView1.Columns["Amount"].FillWeight = 131f;
          this.dataGridView1.Columns["PresentValue"].FillWeight = (float) sbyte.MaxValue;
          this.dataGridView1.Columns["NetWeight"].FillWeight = 115f;
          this.dataGridView1.Columns["InterestRate"].FillWeight = 56f;
          this.dataGridView1.Columns["Type"].FillWeight = 82f;
          this.dataGridView1.Columns["Articles"].FillWeight = 250f;
          this.dataGridView1.Columns["BankCode"].FillWeight = 115f;
          this.dataGridView1.Columns["BankSerialNumber"].FillWeight = 47f;
          this.dataGridView1.Columns["Redeemed"].FillWeight = 20f;
          this.dataGridView1.Columns["RedemptionAmount"].FillWeight = 100f;
          this.dataGridView1.Columns["RedemptionDate"].FillWeight = 170f;
          this.dataGridView1.Columns["FinalInterest"].FillWeight = 100f;
          this.dataGridView1.Columns["Redeemed"].Visible = true;
          this.dataGridView1.Columns["RedemptionAmount"].Visible = true;
          this.dataGridView1.Columns["RedemptionDate"].Visible = true;
          this.dataGridView1.Columns["FinalInterest"].Visible = true;
        }
        if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
        {
          foreach (string columnName in OrderClass.getcolumnsToHide("PledgeReports"))
          {
            if (this.dataGridView1.Columns.Contains(columnName))
              this.dataGridView1.Columns[columnName].Visible = false;
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void decrypting(object sender, WaitWindowEventArgs e)
    {
      if (!(FormMain.memberType == "ak"))
        return;
      foreach (DataRow row in (InternalDataCollectionBase) this.dtpledgeReports.Rows)
      {
        if (row["redeemed"].ToString() == "Y" | row["redeemed"].ToString() == "A")
        {
          row["interestrate"] = (object) PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0]["RateOfInterest"].ToString();
          row["FinalInterest"] = (object) "0";
          row["RedemptionAmount"] = (object) "0";
        }
        else
        {
          row["interestrate"] = (object) PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0]["RateofINterest"].ToString();
          row["FinalInterest"] = (object) "0";
          row["RedemptionAmount"] = (object) "0";
        }
      }
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
      this.refreshGrid(this.buildQuery());
      if (this.dataGridView1.Columns.Count <= 0)
        return;
      this.dataGridView1.Columns["interestrate"].Visible = true;
      this.dataGridView1.Columns["finalinterest"].Visible = true;
      this.dataGridView1.Columns["redemptionamount"].Visible = true;
    }

    private string buildQuery()
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      if (this.cbReleased.Text != "")
        str1 = " p2.redeemed = '" + this.cbReleased.Text.Trim().ToString() + "'";
      if (this.tbxFromDate.Text.Trim().ToString() != "" && this.tbxToDate.Text.Trim().ToString() != "" && PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.Trim().ToString()) && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.Trim().ToString()) && DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()) <= DateTime.Parse(this.tbxToDate.Text.Trim().ToString()))
        str1 = !(str1 != "") ? str1 + " (p2.Billdate >= @FromDate and p2.Billdate <= @ToDate)" : str1 + " and (p2.Billdate >= @FromDate and p2.Billdate <= @ToDate)";
      if (this.cbType.Text != "")
        str1 = !(str1 != "") ? str1 + " p2.type in('" + this.cbType.Text + "') " : str1 + " and p2.type in('" + this.cbType.Text + "') ";
      if (this.tbxSearch.Text.Trim().ToString() != "")
        str2 = " where t1.nameandaddress like @searchNameAndAddress OR t1.BillDate like @searchBillDate OR t1.BillNumber like @searchBillNumber OR t1.amount like @searchAmount OR t1.articles like @searchArticles or t1.netweight like @searchNetWeight";
      if (str1 != "")
        str1 = " where " + str1;
      string nameAndAddress = this.getNameAndADdress();
      string str4 = this.getSortOrder();
      string str5 = !this.rbAsc.Checked ? "DEsc" : "Asc";
      if (str4 != "")
        str4 = "order by " + str4 + " " + str5;
      if (this.cbShopCodes.Text != "")
        str3 = " where shopCode = @ShopCode ";
      string str6 = "p." + FormMain.PledgeReportsScreen + " as Articles";
      string newValue = "p2." + FormMain.PledgeReportsScreen + " as Articles";
      return "select * from (SELECT " + OrderClass.getColumnOrderForPledgeReportsScreen().Replace("nameAndAddress", nameAndAddress).Replace("articles", newValue) + " FROM  (SELECT p.ShopCode,p.BillNumber, p.oldBillNumber,p.PhoneNumber, p.BillDate, p.CustomerCode, p.amount, p.PresentValue, p.NetWeight, p.temp1 as InterestRate, p.TYPE, p.Redeemed," + str6 + ",p.temp3 as FinalInterest,p.temp4 as RedemptionAmount,p.RedemptionDate,p.Redeemed,p.BankCode,p.BankSerialNumber FROM tblPledge AS p  " + str3 + ")  AS p2 LEFT JOIN tblcustomers AS c ON p2.customercode=c.cid " + str1 + str4 + " ) as t1 " + str2;
    }

    private string getSortOrder()
    {
      if (this.cbSortBy.Text == "BILL NUMBER")
        return "p2.BillNumber";
      if (this.cbSortBy.Text == "CUSTOMER CODE")
        return "p2.customercode ";
      if (this.cbSortBy.Text == "AMOUNT")
        return "p2.amount";
      if (this.cbSortBy.Text == "NETWEIGHT")
        return "p2.netweight";
      if (this.cbSortBy.Text == "SHOP CODE")
        return "p2.shopCode";
      if (this.cbSortBy.Text == "TYPE")
        return "p2.type,p2.amount";
      return this.cbSortBy.Text == "BILL DATE" ? "p2.BillDate " : "";
    }

    private string getNameAndADdress()
    {
      if (this.rbSeperate.Checked)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this.cbCode.Checked)
          stringBuilder.Append("c.cid,");
        if (this.cbName.Checked)
          stringBuilder.Append("c.cname as NameAndAddress,");
        if (this.cbNo.Checked)
          stringBuilder.Append("c.cno,");
        if (this.cbAddress1.Checked)
          stringBuilder.Append("c.caddr1,");
        if (this.cbAddress2.Checked)
          stringBuilder.Append("c.caddr2,");
        if (this.cbLocation.Checked)
          stringBuilder.Append("c.caddr3,");
        if (this.cbCity.Checked)
          stringBuilder.Append("c.ccity,");
        if (this.cbPincode.Checked)
          stringBuilder.Append("c.cpincode,");
        if (this.cbMobileNumber.Checked)
          stringBuilder.Append("c.cphone as phoneNumber,");
        if (this.cbPincode.Checked)
          stringBuilder.Append("c.ccell,");
        return stringBuilder.ToString();
      }
      if (!this.rbJoin.Checked)
        return "";
      StringBuilder stringBuilder1 = new StringBuilder();
      if (this.cbCode.Checked)
        stringBuilder1.Append("c.cid+' '+");
      if (this.cbName.Checked)
        stringBuilder1.Append("c.cname+' '+");
      if (this.cbNo.Checked)
        stringBuilder1.Append("c.cno+' '+");
      if (this.cbAddress1.Checked)
        stringBuilder1.Append("c.caddr1+' '+");
      if (this.cbAddress2.Checked)
        stringBuilder1.Append("c.caddr2+' '+");
      if (this.cbLocation.Checked)
        stringBuilder1.Append("c.caddr3+' '+");
      if (this.cbCity.Checked)
        stringBuilder1.Append("c.ccity+' '+");
      if (this.cbPincode.Checked)
        stringBuilder1.Append("c.cpincode+' '+");
      if (this.cbMobileNumber.Checked)
        stringBuilder1.Append("c.cphone+' '+");
      if (this.cbPincode.Checked)
        stringBuilder1.Append("c.ccell+' '+");
      if (stringBuilder1.Length > 4)
      {
        stringBuilder1.Remove(stringBuilder1.Length - 5, 5);
        stringBuilder1.Append(" as [NameAndAddress] ");
      }
      return stringBuilder1.ToString();
    }

    private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
      {
        num1 += double.Parse(row.Cells["amount"].Value.ToString());
        if (row.Cells["type"].Value.ToString() == "GOLD")
          num2 += double.Parse(row.Cells["netweight"].Value.ToString());
        if (row.Cells["type"].Value.ToString() == "SILVER")
          num3 += double.Parse(row.Cells["netweight"].Value.ToString());
      }
      this.tbxNumberOfBills.Text = this.dataGridView1.Rows.Count.ToString();
      this.tbxTotal.Text = num1.ToString("F");
      this.tbxNetWeightGold.Text = num2.ToString("F");
      this.tbxNetWeightSilver.Text = num3.ToString("F");
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.comboBox1.Text != "")
      {
        if (this.comboBox1.Items.Contains((object) this.comboBox1.Text))
        {
          this.dtpledgeReports.TableName = "PledgeReports";
          this.dtpledgeReports.WriteXmlSchema(this.dtpledgeReports.TableName + ".xml");
          ReportDocument RD = new ReportDocument();
          RD.Load(this.comboBox1.Text);
          RD.SetDataSource((DataTable) this.dataGridView1.DataSource);
          int num = (int) new FormCrystalReportViewer(RD).ShowDialog();
          File.WriteAllText("Reports\\\\PledgeReports\\\\LastUsed.txt", this.comboBox1.Text);
        }
        else
          this.comboBox1.Select();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please select a report format");
      }
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
      else if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void cbAlterateNumber_Click(object sender, EventArgs e)
    {
      if (this.cbCode.Checked || this.cbName.Checked || this.cbNo.Checked || this.cbAddress1.Checked || this.cbAddress2.Checked || this.cbLocation.Checked || this.cbCity.Checked || this.cbPincode.Checked || this.cbMobileNumber.Checked || this.cbPincode.Checked)
        return;
      this.cbName.Checked = true;
    }

    private void rbSeperate_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "PLEDGE REPORTS").ShowDialog();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void comboBox1_Click(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxFromDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxToDate.Select();
    }

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxSearch.Select();
    }

    private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbReleased.Select();
    }

    private void cbReleased_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbType.Select();
    }

    private void cbType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbSortBy.Select();
    }

    private void cbSortBy_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.rbAsc.Select();
    }

    private void rbAsc_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void rbDesc_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void dELETEPledgeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null)
        return;
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      string BillNumber = this.dataGridView1.Rows[rowIndex].Cells["BillNumber"].Value.ToString();
      string ShopCode = this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString();
      string str = this.dataGridView1.Rows[rowIndex].Cells["redeemed"].Value.ToString();
      this.dataGridView1.Rows[rowIndex].Cells["BillDate"].Value.ToString();
      if (str == "N")
      {
        DataTable voucherNumberAndDate = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
        if (voucherNumberAndDate != null && voucherNumberAndDate.Rows.Count > 0)
        {
          voucherNumberAndDate.Rows[0]["voucherNumber"].ToString();
          if (!PawnManagementClass.checkIfRokadFinished(voucherNumberAndDate.Rows[0]["voucherDate"].ToString()))
          {
            if (DialogResult.Yes == MessageBox.Show("Delete Pledge BillNumber : " + BillNumber + "?", "Delete Pledge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
              this.deleteFromVoucherTable(BillNumber, ShopCode);
              this.SHOW();
            }
          }
          else
          {
            int num = (int) MessageBox.Show("Cannot Delete as Rokad has been finished for this date");
          }
        }
        else if (DialogResult.Yes == MessageBox.Show("Delete Pledge?", "Delete Pledge", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
        {
          this.deleteFromPledgeAndPledgeArticlesTable(BillNumber, ShopCode);
          this.SHOW();
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Cannot Be deleted..Already Released");
      }
    }

    private void deleteFromPledgeAndPledgeArticlesTable(string BillNumber, string ShopCode)
    {
      string strError1 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledge where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError1) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError1);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError1, FormMain.username, DateTime.Now.ToString());
      }
      string strError2 = "";
      if (!(SQLHelper.RunCommand("Delete from tblpledgearticles where BillNumber = @BillNumber and ShopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError2) == "Done"))
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError2);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError2, FormMain.username, DateTime.Now.ToString());
      }
      string strError3 = "";
      if (SQLHelper.RunCommand("Delete from tblInterestReceived where BillNumber = @BillNumber AND shopCode = @ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber),
        new OleDbParameter(nameof (ShopCode), (object) ShopCode)
      }, ref strError3) != "Done")
      {
        int num = (int) MessageBox.Show("Error in deleting" + strError3);
        PawnManagementClass.InsertIntoException("form deletepledge.btnsave_click", strError3, FormMain.username, DateTime.Now.ToString());
      }
      PawnManagementClass.InsertIntoHistory("PLEDGE DELETE", BillNumber + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
    }

    private void deleteFromVoucherTable(string BillNumber, string ShopCode)
    {
      DataTable voucherNumberAndDate1 = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      if (voucherNumberAndDate1 == null || voucherNumberAndDate1.Rows.Count <= 0)
        return;
      DataTable voucherNumberAndDate2 = this.getVoucherNumberAndDate(BillNumber + " PledgeBillNumber " + ShopCode);
      string str1 = voucherNumberAndDate2.Rows[0]["voucherNumber"].ToString();
      string s1 = voucherNumberAndDate2.Rows[0]["voucherDate"].ToString();
      DateTime now = DateTime.Parse(s1);
      if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
      {
        string strError = "";
        if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Active", (object) "0"),
          new OleDbParameter("VoucherNumber", (object) str1)
        }, ref strError) == "Done")
        {
          string ActionDetails = "VOUCHER NUMBER " + str1 + " Date " + s1 + " deleted";
          string username = FormMain.username;
          now = DateTime.Now;
          string PerformedOn = now.ToString();
          PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
      DataTable voucherNumberAndDate3 = this.getVoucherNumberAndDate(BillNumber + " INTEREST GIRVI " + ShopCode);
      if (voucherNumberAndDate3 != null && voucherNumberAndDate3.Rows.Count > 0)
      {
        string str2 = voucherNumberAndDate3.Rows[0]["voucherNumber"].ToString();
        string s2 = voucherNumberAndDate3.Rows[0]["voucherDate"].ToString();
        now = DateTime.Parse(s2);
        if (!PawnManagementClass.checkIfRokadFinished(now.ToShortDateString()))
        {
          string strError = "";
          if (SQLHelper.RunCommand("update tblVouchers set Active = @Active where VoucherNumber = @VoucherNumber", new List<OleDbParameter>()
          {
            new OleDbParameter("Active", (object) "0"),
            new OleDbParameter("VoucherNumber", (object) str2)
          }, ref strError) == "Done")
          {
            string ActionDetails = "VOUCHER NUMBER " + str2 + " Date " + s2 + " deleted";
            string username = FormMain.username;
            now = DateTime.Now;
            string PerformedOn = now.ToString();
            PawnManagementClass.InsertIntoHistory("VOUCHER DELETE", ActionDetails, "", "", username, PerformedOn);
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
        }
      }
    }

    private DataTable getVoucherNumberAndDate(string VoucherDescription)
    {
      string strError = "";
      string my_querry = "select * from tblVouchers where VoucherDescription=@VoucherDescription AND active = '1'";
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

    private void tbxFromDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
        return;
      this.SHOW();
    }

    private void SHOW()
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        return;
      this.refreshGrid(this.buildQuery());
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        return;
      this.SHOW();
    }

    private void tbxSearch_TextChanged(object sender, EventArgs e)
    {
      if (!(this.tbxSearch.Text != ""))
        return;
      this.SHOW();
    }

    private void cbReleased_SelectedIndexChanged(object sender, EventArgs e) => this.SHOW();

    private void cbType_SelectedIndexChanged(object sender, EventArgs e) => this.SHOW();

    private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e) => this.SHOW();

    private void rbDesc_CheckedChanged(object sender, EventArgs e) => this.SHOW();

    private void rbAsc_CheckedChanged(object sender, EventArgs e) => this.SHOW();

    private void cbShopCodes_TextChanged(object sender, EventArgs e)
    {
      if (!(this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text) | this.cbShopCodes.Text == ""))
        return;
      this.SHOW();
    }

    private void cbCode_CheckedChanged(object sender, EventArgs e) => this.SHOW();

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.CurrentCell == null || this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode")
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
        {
          int num = (int) new FormCustomerNew(CUSTOMERCODE).ShowDialog();
        }
      }
      else if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
      else if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "OldBillNumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string str1 = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["OldBillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (str1 != "" && str1.Contains("["))
        {
          string str2 = str1.Substring(0, str1.IndexOf("["));
          switch (FormMain.BillNumberSeries)
          {
            case "SINGLE":
              if (PawnManagementClass.validateBillNumber(str2))
              {
                new FormViewPledgeBillNew(str2, SHOPCODE, num.ToString()).Show();
                break;
              }
              break;
            case "DOUBLE":
              if (PawnManagementClass.validateBillNumberDouble(str2))
                new FormViewPledgeBillNew(str2, SHOPCODE, num.ToString()).Show();
              break;
          }
        }
      }
    }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.Columns[e.ColumnIndex].Name == "BillNumber" | this.dataGridView1.Columns[e.ColumnIndex].Name == "CustomerCode" | this.dataGridView1.Columns[e.ColumnIndex].Name == "OldBillNumber")
        this.dataGridView1.Cursor = Cursors.Hand;
      else
        this.dataGridView1.Cursor = Cursors.Default;
    }

    private void fillWeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewColumn column in (BaseCollection) this.dataGridView1.Columns)
      {
        int num = (int) MessageBox.Show(column.Name + "-" + column.FillWeight.ToString());
      }
    }

    private void withoutPasswordToolStripMenuItem_Click(object sender, EventArgs e)
    {
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

    private void changeColumnOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormColumnOrder("PledgeReports").ShowDialog();
      this.Close();
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.withPasswordToolStripMenuItem = new ToolStripMenuItem();
      this.withoutPasswordToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEPledgeToolStripMenuItem = new ToolStripMenuItem();
      this.fillWeightToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.tbxTotal = new TextBox();
      this.tbxNumberOfBills = new TextBox();
      this.cbReleased = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.cbCode = new CheckBox();
      this.cbName = new CheckBox();
      this.cbAddress1 = new CheckBox();
      this.cbNo = new CheckBox();
      this.cbPincode = new CheckBox();
      this.cbCity = new CheckBox();
      this.cbLocation = new CheckBox();
      this.cbAddress2 = new CheckBox();
      this.cbAlterateNumber = new CheckBox();
      this.cbMobileNumber = new CheckBox();
      this.rbDesc = new RadioButton();
      this.rbAsc = new RadioButton();
      this.rbSeperate = new RadioButton();
      this.rbJoin = new RadioButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.glassButton12 = new GlassButton();
      this.glassButton13 = new GlassButton();
      this.tbxSearch = new TextBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.tbxToDate = new TextBox();
      this.headerPanel9 = new HeaderPanel();
      this.glassButton16 = new GlassButton();
      this.glassButton17 = new GlassButton();
      this.headerPanel10 = new HeaderPanel();
      this.glassButton18 = new GlassButton();
      this.glassButton19 = new GlassButton();
      this.cbType = new ComboBox();
      this.headerPanel11 = new HeaderPanel();
      this.glassButton20 = new GlassButton();
      this.glassButton21 = new GlassButton();
      this.cbSortBy = new ComboBox();
      this.headerPanel12 = new HeaderPanel();
      this.glassButton22 = new GlassButton();
      this.glassButton23 = new GlassButton();
      this.headerPanel14 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton28 = new GlassButton();
      this.glassButton29 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton24 = new GlassButton();
      this.glassButton25 = new GlassButton();
      this.tbxNetWeightSilver = new TextBox();
      this.headerPanel13 = new HeaderPanel();
      this.glassButton26 = new GlassButton();
      this.glassButton27 = new GlassButton();
      this.tbxNetWeightGold = new TextBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel9).SuspendLayout();
      ((Control) this.headerPanel10).SuspendLayout();
      ((Control) this.headerPanel11).SuspendLayout();
      ((Control) this.headerPanel12).SuspendLayout();
      ((Control) this.headerPanel14).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel13).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
      gridViewCellStyle.BackColor = SystemColors.Window;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.ControlText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.Location = new Point(4, 115);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1000, 450);
      this.dataGridView1.TabIndex = 17;
      this.dataGridView1.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.dELETEPledgeToolStripMenuItem,
        (ToolStripItem) this.fillWeightToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(197, 158);
      this.exportToExcelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.withPasswordToolStripMenuItem,
        (ToolStripItem) this.withoutPasswordToolStripMenuItem
      });
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(196, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.withPasswordToolStripMenuItem.Name = "withPasswordToolStripMenuItem";
      this.withPasswordToolStripMenuItem.Size = new Size(170, 22);
      this.withPasswordToolStripMenuItem.Text = "With password";
      this.withoutPasswordToolStripMenuItem.Name = "withoutPasswordToolStripMenuItem";
      this.withoutPasswordToolStripMenuItem.Size = new Size(170, 22);
      this.withoutPasswordToolStripMenuItem.Text = "Without password";
      this.withoutPasswordToolStripMenuItem.Click += new EventHandler(this.withoutPasswordToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(196, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(196, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.dELETEPledgeToolStripMenuItem.Name = "dELETEPledgeToolStripMenuItem";
      this.dELETEPledgeToolStripMenuItem.Size = new Size(196, 22);
      this.dELETEPledgeToolStripMenuItem.Text = "DELETE pledge";
      this.dELETEPledgeToolStripMenuItem.Click += new EventHandler(this.dELETEPledgeToolStripMenuItem_Click);
      this.fillWeightToolStripMenuItem.Name = "fillWeightToolStripMenuItem";
      this.fillWeightToolStripMenuItem.Size = new Size(196, 22);
      this.fillWeightToolStripMenuItem.Text = "Fill Weight";
      this.fillWeightToolStripMenuItem.Click += new EventHandler(this.fillWeightToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(196, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel Option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(196, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change Column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      this.tbxTotal.BackColor = Color.AliceBlue;
      this.tbxTotal.BorderStyle = BorderStyle.None;
      this.tbxTotal.Dock = DockStyle.Fill;
      this.tbxTotal.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotal.Location = new Point(0, 0);
      this.tbxTotal.Name = "tbxTotal";
      this.tbxTotal.Size = new Size(204, 31);
      this.tbxTotal.TabIndex = 26;
      this.tbxTotal.TextAlign = HorizontalAlignment.Center;
      this.tbxNumberOfBills.BackColor = Color.AliceBlue;
      this.tbxNumberOfBills.BorderStyle = BorderStyle.None;
      this.tbxNumberOfBills.Dock = DockStyle.Fill;
      this.tbxNumberOfBills.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNumberOfBills.Location = new Point(0, 0);
      this.tbxNumberOfBills.Name = "tbxNumberOfBills";
      this.tbxNumberOfBills.Size = new Size(148, 31);
      this.tbxNumberOfBills.TabIndex = 25;
      this.tbxNumberOfBills.TextAlign = HorizontalAlignment.Center;
      this.cbReleased.BackColor = Color.AliceBlue;
      this.cbReleased.Dock = DockStyle.Fill;
      this.cbReleased.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbReleased.FlatStyle = FlatStyle.Popup;
      this.cbReleased.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbReleased.FormattingEnabled = true;
      this.cbReleased.Items.AddRange(new object[3]
      {
        (object) "",
        (object) "Y",
        (object) "N"
      });
      this.cbReleased.Location = new Point(0, 0);
      this.cbReleased.Name = "cbReleased";
      this.cbReleased.Size = new Size(108, 24);
      this.cbReleased.TabIndex = 0;
      this.cbReleased.SelectedIndexChanged += new EventHandler(this.cbReleased_SelectedIndexChanged);
      this.cbReleased.KeyDown += new KeyEventHandler(this.cbReleased_KeyDown);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(254, 4);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(61, 26);
      ((Control) this.glassButton1).TabIndex = 24;
      ((Control) this.glassButton1).Text = "&PRINT";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox1.BackColor = Color.AliceBlue;
      this.comboBox1.DropDownWidth = 600;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(3, 6);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(250, 23);
      this.comboBox1.TabIndex = 23;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.comboBox1.Click += new EventHandler(this.comboBox1_Click);
      this.comboBox1.KeyPress += new KeyPressEventHandler(this.comboBox1_KeyPress);
      this.cbCode.Anchor = AnchorStyles.Top;
      this.cbCode.AutoSize = true;
      this.cbCode.BackColor = Color.Transparent;
      this.cbCode.Location = new Point(22, 6);
      this.cbCode.Name = "cbCode";
      this.cbCode.Size = new Size(53, 19);
      this.cbCode.TabIndex = 7;
      this.cbCode.Text = "Code";
      this.cbCode.UseVisualStyleBackColor = false;
      this.cbCode.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbCode.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbName.Anchor = AnchorStyles.Top;
      this.cbName.AutoSize = true;
      this.cbName.BackColor = Color.Transparent;
      this.cbName.Checked = true;
      this.cbName.CheckState = CheckState.Checked;
      this.cbName.Location = new Point(135, 6);
      this.cbName.Name = "cbName";
      this.cbName.Size = new Size(58, 19);
      this.cbName.TabIndex = 8;
      this.cbName.Text = "Name";
      this.cbName.UseVisualStyleBackColor = false;
      this.cbName.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbName.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbAddress1.Anchor = AnchorStyles.Top;
      this.cbAddress1.AutoSize = true;
      this.cbAddress1.BackColor = Color.Transparent;
      this.cbAddress1.Location = new Point(202, 6);
      this.cbAddress1.Name = "cbAddress1";
      this.cbAddress1.Size = new Size(73, 19);
      this.cbAddress1.TabIndex = 10;
      this.cbAddress1.Text = "Address1";
      this.cbAddress1.UseVisualStyleBackColor = false;
      this.cbAddress1.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbAddress1.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbNo.Anchor = AnchorStyles.Top;
      this.cbNo.AutoSize = true;
      this.cbNo.BackColor = Color.Transparent;
      this.cbNo.Location = new Point(84, 6);
      this.cbNo.Name = "cbNo";
      this.cbNo.Size = new Size(42, 19);
      this.cbNo.TabIndex = 9;
      this.cbNo.Text = "No";
      this.cbNo.UseVisualStyleBackColor = false;
      this.cbNo.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbNo.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbPincode.Anchor = AnchorStyles.Top;
      this.cbPincode.AutoSize = true;
      this.cbPincode.BackColor = Color.Transparent;
      this.cbPincode.Location = new Point(506, 6);
      this.cbPincode.Name = "cbPincode";
      this.cbPincode.Size = new Size(69, 19);
      this.cbPincode.TabIndex = 14;
      this.cbPincode.Text = "Pincode";
      this.cbPincode.UseVisualStyleBackColor = false;
      this.cbPincode.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbPincode.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbCity.Anchor = AnchorStyles.Top;
      this.cbCity.AutoSize = true;
      this.cbCity.BackColor = Color.Transparent;
      this.cbCity.Location = new Point(451, 6);
      this.cbCity.Name = "cbCity";
      this.cbCity.Size = new Size(46, 19);
      this.cbCity.TabIndex = 13;
      this.cbCity.Text = "City";
      this.cbCity.UseVisualStyleBackColor = false;
      this.cbCity.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbCity.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbLocation.Anchor = AnchorStyles.Top;
      this.cbLocation.AutoSize = true;
      this.cbLocation.BackColor = Color.Transparent;
      this.cbLocation.Location = new Point(370, 6);
      this.cbLocation.Name = "cbLocation";
      this.cbLocation.Size = new Size(72, 19);
      this.cbLocation.TabIndex = 12;
      this.cbLocation.Text = "Location";
      this.cbLocation.UseVisualStyleBackColor = false;
      this.cbLocation.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbLocation.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbAddress2.Anchor = AnchorStyles.Top;
      this.cbAddress2.AutoSize = true;
      this.cbAddress2.BackColor = Color.Transparent;
      this.cbAddress2.Location = new Point(286, 6);
      this.cbAddress2.Name = "cbAddress2";
      this.cbAddress2.Size = new Size(75, 19);
      this.cbAddress2.TabIndex = 11;
      this.cbAddress2.Text = "Address2";
      this.cbAddress2.UseVisualStyleBackColor = false;
      this.cbAddress2.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbAddress2.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbAlterateNumber.Anchor = AnchorStyles.Top;
      this.cbAlterateNumber.AutoSize = true;
      this.cbAlterateNumber.BackColor = Color.Transparent;
      this.cbAlterateNumber.Location = new Point(703, 6);
      this.cbAlterateNumber.Name = "cbAlterateNumber";
      this.cbAlterateNumber.Size = new Size(121, 19);
      this.cbAlterateNumber.TabIndex = 16;
      this.cbAlterateNumber.Text = "Alternate Number";
      this.cbAlterateNumber.UseVisualStyleBackColor = false;
      this.cbAlterateNumber.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbAlterateNumber.Click += new EventHandler(this.cbAlterateNumber_Click);
      this.cbMobileNumber.Anchor = AnchorStyles.Top;
      this.cbMobileNumber.AutoSize = true;
      this.cbMobileNumber.BackColor = Color.Transparent;
      this.cbMobileNumber.Location = new Point(584, 6);
      this.cbMobileNumber.Name = "cbMobileNumber";
      this.cbMobileNumber.Size = new Size(110, 19);
      this.cbMobileNumber.TabIndex = 15;
      this.cbMobileNumber.Text = "Mobile Number";
      this.cbMobileNumber.UseVisualStyleBackColor = false;
      this.cbMobileNumber.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.cbMobileNumber.Click += new EventHandler(this.cbAlterateNumber_Click);
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
      this.rbDesc.KeyDown += new KeyEventHandler(this.rbDesc_KeyDown);
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
      this.rbAsc.KeyDown += new KeyEventHandler(this.rbAsc_KeyDown);
      this.rbSeperate.Anchor = AnchorStyles.Top;
      this.rbSeperate.AutoSize = true;
      this.rbSeperate.BackColor = Color.Transparent;
      this.rbSeperate.Location = new Point(878, 6);
      this.rbSeperate.Name = "rbSeperate";
      this.rbSeperate.Size = new Size(71, 19);
      this.rbSeperate.TabIndex = 1;
      this.rbSeperate.TabStop = true;
      this.rbSeperate.Text = "Seperate";
      this.rbSeperate.UseVisualStyleBackColor = false;
      this.rbSeperate.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      this.rbJoin.Anchor = AnchorStyles.Top;
      this.rbJoin.AutoSize = true;
      this.rbJoin.BackColor = Color.Transparent;
      this.rbJoin.Checked = true;
      this.rbJoin.Location = new Point(822, 6);
      this.rbJoin.Name = "rbJoin";
      this.rbJoin.Size = new Size(47, 19);
      this.rbJoin.TabIndex = 0;
      this.rbJoin.TabStop = true;
      this.rbJoin.Text = "Join";
      this.rbJoin.UseVisualStyleBackColor = false;
      this.rbJoin.CheckedChanged += new EventHandler(this.cbCode_CheckedChanged);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.AliceBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "Name and Address should include";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.rbSeperate);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.rbJoin);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbAddress2);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbMobileNumber);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbName);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbAddress1);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbPincode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbLocation);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbCode);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbCity);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbNo);
      ((Control) this.headerPanel2).Controls.Add((Control) this.cbAlterateNumber);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(3, 61);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(1001, 51);
      ((Control) this.headerPanel2).TabIndex = 72;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton2).Location = new Point(710, 513);
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
      ((Control) this.glassButton3).Location = new Point(844, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel3).Location = new Point(4, 571);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(320, 58);
      ((Control) this.headerPanel3).TabIndex = 73;
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
      ((Control) this.glassButton4).Location = new Point(29, 513);
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
      ((Control) this.glassButton5).Location = new Point(163, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel4).Location = new Point(641, 571);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(150, 58);
      ((Control) this.headerPanel4).TabIndex = 74;
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
      ((Control) this.glassButton6).Location = new Point(-141, 513);
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
      ((Control) this.glassButton7).Location = new Point(-7, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel5).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel5).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel5).Location = new Point(797, 571);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(206, 58);
      ((Control) this.headerPanel5).TabIndex = 75;
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
      ((Control) this.glassButton8).Location = new Point(-85, 513);
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
      ((Control) this.glassButton9).Location = new Point(49, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel6).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel6).Location = new Point(5, 4);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(110, 51);
      ((Control) this.headerPanel6).TabIndex = 76;
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
      ((Control) this.glassButton10).Location = new Point(-183, 513);
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
      ((Control) this.glassButton11).Location = new Point(-49, 512);
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
      this.tbxFromDate.Size = new Size(108, 24);
      this.tbxFromDate.TabIndex = 26;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxFromDate_KeyDown);
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel7.CaptionEndColor = Color.AliceBlue;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "SEARCH";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxSearch);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(241, 4);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(110, 51);
      ((Control) this.headerPanel7).TabIndex = 77;
      this.headerPanel7.TextAntialias = true;
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
      ((Control) this.glassButton12).Location = new Point(-185, 513);
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
      ((Control) this.glassButton13).Location = new Point(-51, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSearch.BackColor = Color.AliceBlue;
      this.tbxSearch.BorderStyle = BorderStyle.None;
      this.tbxSearch.Dock = DockStyle.Fill;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(0, 0);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(108, 24);
      this.tbxSearch.TabIndex = 26;
      this.tbxSearch.TextAlign = HorizontalAlignment.Center;
      this.tbxSearch.TextChanged += new EventHandler(this.tbxSearch_TextChanged);
      this.tbxSearch.KeyDown += new KeyEventHandler(this.tbxSearch_KeyDown);
      ((Control) this.headerPanel8).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel8).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel8.BorderColor = SystemColors.HotTrack;
      this.headerPanel8.BorderStyle = BorderStyles.Single;
      this.headerPanel8.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel8.CaptionEndColor = Color.AliceBlue;
      this.headerPanel8.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.CaptionHeight = 22;
      this.headerPanel8.CaptionPosition = CaptionPositions.Top;
      this.headerPanel8.CaptionText = "TO DATE";
      this.headerPanel8.CaptionVisible = true;
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton14);
      ((Control) this.headerPanel8).Controls.Add((Control) this.glassButton15);
      ((Control) this.headerPanel8).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel8).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel8).ForeColor = Color.DarkBlue;
      this.headerPanel8.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel8.GradientEnd = SystemColors.ControlLight;
      this.headerPanel8.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel8).Location = new Point(123, 4);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(110, 51);
      ((Control) this.headerPanel8).TabIndex = 77;
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
      ((Control) this.glassButton14).Location = new Point(-185, 513);
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
      ((Control) this.glassButton15).Location = new Point(-51, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxToDate.BackColor = Color.AliceBlue;
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Fill;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(0, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(108, 24);
      this.tbxToDate.TabIndex = 26;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      ((Control) this.headerPanel9).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel9).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel9.BorderColor = SystemColors.HotTrack;
      this.headerPanel9.BorderStyle = BorderStyles.Single;
      this.headerPanel9.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel9.CaptionEndColor = Color.AliceBlue;
      this.headerPanel9.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.CaptionHeight = 22;
      this.headerPanel9.CaptionPosition = CaptionPositions.Top;
      this.headerPanel9.CaptionText = "RELEASED";
      this.headerPanel9.CaptionVisible = true;
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel9).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel9).Controls.Add((Control) this.cbReleased);
      ((Control) this.headerPanel9).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel9).ForeColor = Color.DarkBlue;
      this.headerPanel9.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel9.GradientEnd = SystemColors.ControlLight;
      this.headerPanel9.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel9).Location = new Point(359, 4);
      ((Control) this.headerPanel9).Name = "headerPanel9";
      this.headerPanel9.PanelIcon = (Icon) null;
      this.headerPanel9.PanelIconVisible = false;
      ((Control) this.headerPanel9).Size = new Size(110, 51);
      ((Control) this.headerPanel9).TabIndex = 78;
      this.headerPanel9.TextAntialias = true;
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
      ((Control) this.glassButton16).Location = new Point(-187, 513);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(128, 35);
      ((Control) this.glassButton16).TabIndex = 0;
      ((Control) this.glassButton16).Text = "&SAVE";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton17).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton17.BackColor = Color.LightBlue;
      this.glassButton17.FadeOnFocus = true;
      ((Control) this.glassButton17).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton17.ForeColor = Color.MediumBlue;
      this.glassButton17.ForeColorOnFocus = Color.Red;
      this.glassButton17.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton17.GlowColor = Color.White;
      this.glassButton17.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton17).Location = new Point(-53, 512);
      ((Control) this.glassButton17).Name = "glassButton17";
      this.glassButton17.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton17.ShineColor = Color.Transparent;
      ((Control) this.glassButton17).Size = new Size(123, 37);
      ((Control) this.glassButton17).TabIndex = 1;
      ((Control) this.glassButton17).Text = "&EXIT";
      ((ButtonBase) this.glassButton17).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel10).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel10).Location = new Point(477, 4);
      ((Control) this.headerPanel10).Name = "headerPanel10";
      this.headerPanel10.PanelIcon = (Icon) null;
      this.headerPanel10.PanelIconVisible = false;
      ((Control) this.headerPanel10).Size = new Size(110, 51);
      ((Control) this.headerPanel10).TabIndex = 79;
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
      ((Control) this.glassButton18).Location = new Point(-189, 513);
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
      ((Control) this.glassButton19).Location = new Point(-55, 512);
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
      this.cbType.KeyDown += new KeyEventHandler(this.cbType_KeyDown);
      ((Control) this.headerPanel11).BackColor = Color.PowderBlue;
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
      ((Control) this.headerPanel11).Location = new Point(595, 4);
      ((Control) this.headerPanel11).Name = "headerPanel11";
      this.headerPanel11.PanelIcon = (Icon) null;
      this.headerPanel11.PanelIconVisible = false;
      ((Control) this.headerPanel11).Size = new Size(110, 51);
      ((Control) this.headerPanel11).TabIndex = 79;
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
      ((Control) this.glassButton20).Location = new Point(-189, 513);
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
      ((Control) this.glassButton21).Location = new Point(-55, 512);
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
      this.cbSortBy.Items.AddRange(new object[7]
      {
        (object) "SHOP CODE",
        (object) "BILL NUMBER",
        (object) "BILL DATE",
        (object) "AMOUNT",
        (object) "CUSTOMER CODE",
        (object) "NET WEIGHT",
        (object) "TYPE"
      });
      this.cbSortBy.Location = new Point(0, 0);
      this.cbSortBy.Name = "cbSortBy";
      this.cbSortBy.Size = new Size(108, 24);
      this.cbSortBy.TabIndex = 0;
      this.cbSortBy.SelectedIndexChanged += new EventHandler(this.cbSortBy_SelectedIndexChanged);
      this.cbSortBy.KeyDown += new KeyEventHandler(this.cbSortBy_KeyDown);
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
      ((Control) this.headerPanel12).Location = new Point(713, 4);
      ((Control) this.headerPanel12).Name = "headerPanel12";
      this.headerPanel12.PanelIcon = (Icon) null;
      this.headerPanel12.PanelIconVisible = false;
      ((Control) this.headerPanel12).Size = new Size(110, 51);
      ((Control) this.headerPanel12).TabIndex = 75;
      this.headerPanel12.TextAntialias = true;
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
      ((Control) this.glassButton22).Location = new Point(-183, 513);
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
      ((Control) this.glassButton23).Location = new Point(-49, 512);
      ((Control) this.glassButton23).Name = "glassButton23";
      this.glassButton23.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton23.ShineColor = Color.Transparent;
      ((Control) this.glassButton23).Size = new Size(123, 37);
      ((Control) this.glassButton23).TabIndex = 1;
      ((Control) this.glassButton23).Text = "&EXIT";
      ((ButtonBase) this.glassButton23).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel14).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel14).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel14).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel14.BorderColor = SystemColors.HotTrack;
      this.headerPanel14.BorderStyle = BorderStyles.Single;
      this.headerPanel14.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel14.CaptionEndColor = Color.AliceBlue;
      this.headerPanel14.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.CaptionHeight = 22;
      this.headerPanel14.CaptionPosition = CaptionPositions.Top;
      this.headerPanel14.CaptionText = "SELECT LICENSE";
      this.headerPanel14.CaptionVisible = true;
      ((Control) this.headerPanel14).Controls.Add((Control) this.cbShopCodes);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton28);
      ((Control) this.headerPanel14).Controls.Add((Control) this.glassButton29);
      ((Control) this.headerPanel14).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel14).ForeColor = Color.DarkBlue;
      this.headerPanel14.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel14.GradientEnd = SystemColors.ControlLight;
      this.headerPanel14.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel14).Location = new Point(831, 4);
      ((Control) this.headerPanel14).Name = "headerPanel14";
      this.headerPanel14.PanelIcon = (Icon) null;
      this.headerPanel14.PanelIconVisible = false;
      ((Control) this.headerPanel14).Size = new Size(173, 51);
      ((Control) this.headerPanel14).TabIndex = 84;
      this.headerPanel14.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(171, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
      ((Control) this.glassButton28).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton28.BackColor = Color.LightBlue;
      this.glassButton28.FadeOnFocus = true;
      ((Control) this.glassButton28).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton28.ForeColor = Color.MediumBlue;
      this.glassButton28.ForeColorOnFocus = Color.Red;
      this.glassButton28.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton28.GlowColor = Color.White;
      ((ButtonBase) this.glassButton28).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton28.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton28).Location = new Point(-136, 513);
      ((Control) this.glassButton28).Name = "glassButton28";
      this.glassButton28.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton28.ShineColor = Color.Transparent;
      ((Control) this.glassButton28).Size = new Size(128, 35);
      ((Control) this.glassButton28).TabIndex = 0;
      ((Control) this.glassButton28).Text = "&SAVE";
      ((ButtonBase) this.glassButton28).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton29).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton29.BackColor = Color.LightBlue;
      this.glassButton29.FadeOnFocus = true;
      ((Control) this.glassButton29).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton29.ForeColor = Color.MediumBlue;
      this.glassButton29.ForeColorOnFocus = Color.Red;
      this.glassButton29.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton29.GlowColor = Color.White;
      this.glassButton29.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton29).Location = new Point(-2, 512);
      ((Control) this.glassButton29).Name = "glassButton29";
      this.glassButton29.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton29.ShineColor = Color.Transparent;
      ((Control) this.glassButton29).Size = new Size(123, 37);
      ((Control) this.glassButton29).TabIndex = 1;
      ((Control) this.glassButton29).Text = "&EXIT";
      ((ButtonBase) this.glassButton29).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "NET WEIGHT - SILVER";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton24);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton25);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxNetWeightSilver);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(485, 571);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(150, 58);
      ((Control) this.headerPanel1).TabIndex = 77;
      this.headerPanel1.TextAntialias = true;
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
      ((Control) this.glassButton24).Location = new Point(-143, 513);
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
      ((Control) this.glassButton25).Location = new Point(-9, 512);
      ((Control) this.glassButton25).Name = "glassButton25";
      this.glassButton25.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton25.ShineColor = Color.Transparent;
      ((Control) this.glassButton25).Size = new Size(123, 37);
      ((Control) this.glassButton25).TabIndex = 1;
      ((Control) this.glassButton25).Text = "&EXIT";
      ((ButtonBase) this.glassButton25).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNetWeightSilver.BackColor = Color.AliceBlue;
      this.tbxNetWeightSilver.BorderStyle = BorderStyle.None;
      this.tbxNetWeightSilver.Dock = DockStyle.Fill;
      this.tbxNetWeightSilver.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeightSilver.Location = new Point(0, 0);
      this.tbxNetWeightSilver.Name = "tbxNetWeightSilver";
      this.tbxNetWeightSilver.Size = new Size(148, 31);
      this.tbxNetWeightSilver.TabIndex = 26;
      this.tbxNetWeightSilver.TextAlign = HorizontalAlignment.Center;
      ((Control) this.headerPanel13).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((Control) this.headerPanel13).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel13).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel13.BorderColor = SystemColors.HotTrack;
      this.headerPanel13.BorderStyle = BorderStyles.Single;
      this.headerPanel13.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel13.CaptionEndColor = Color.AliceBlue;
      this.headerPanel13.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.CaptionHeight = 22;
      this.headerPanel13.CaptionPosition = CaptionPositions.Top;
      this.headerPanel13.CaptionText = "NET WEIGHT - GOLD";
      this.headerPanel13.CaptionVisible = true;
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton26);
      ((Control) this.headerPanel13).Controls.Add((Control) this.glassButton27);
      ((Control) this.headerPanel13).Controls.Add((Control) this.tbxNetWeightGold);
      ((Control) this.headerPanel13).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel13).ForeColor = Color.DarkBlue;
      this.headerPanel13.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel13.GradientEnd = SystemColors.ControlLight;
      this.headerPanel13.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel13).Location = new Point(329, 571);
      ((Control) this.headerPanel13).Name = "headerPanel13";
      this.headerPanel13.PanelIcon = (Icon) null;
      this.headerPanel13.PanelIconVisible = false;
      ((Control) this.headerPanel13).Size = new Size(150, 58);
      ((Control) this.headerPanel13).TabIndex = 76;
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
      ((Control) this.glassButton26).Location = new Point(-143, 513);
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
      ((Control) this.glassButton27).Location = new Point(-9, 512);
      ((Control) this.glassButton27).Name = "glassButton27";
      this.glassButton27.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton27.ShineColor = Color.Transparent;
      ((Control) this.glassButton27).Size = new Size(123, 37);
      ((Control) this.glassButton27).TabIndex = 1;
      ((Control) this.glassButton27).Text = "&EXIT";
      ((ButtonBase) this.glassButton27).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxNetWeightGold.BackColor = Color.AliceBlue;
      this.tbxNetWeightGold.BorderStyle = BorderStyle.None;
      this.tbxNetWeightGold.Dock = DockStyle.Fill;
      this.tbxNetWeightGold.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNetWeightGold.Location = new Point(0, 0);
      this.tbxNetWeightGold.Name = "tbxNetWeightGold";
      this.tbxNetWeightGold.Size = new Size(148, 31);
      this.tbxNetWeightGold.TabIndex = 25;
      this.tbxNetWeightGold.TextAlign = HorizontalAlignment.Center;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel14);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel12);
      this.Controls.Add((Control) this.headerPanel11);
      this.Controls.Add((Control) this.headerPanel10);
      this.Controls.Add((Control) this.headerPanel9);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel13);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.dataGridView1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormPledgeReports);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormPledgeReports);
      this.Load += new EventHandler(this.FormPledgeReports_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel9).ResumeLayout(false);
      ((Control) this.headerPanel10).ResumeLayout(false);
      ((Control) this.headerPanel11).ResumeLayout(false);
      ((Control) this.headerPanel12).ResumeLayout(false);
      ((Control) this.headerPanel12).PerformLayout();
      ((Control) this.headerPanel14).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel13).ResumeLayout(false);
      ((Control) this.headerPanel13).PerformLayout();
      this.ResumeLayout(false);
    }

    public class DataRowComparer : IComparer
    {
      private ListSortDirection direction;
      private int columnIndex;

      public DataRowComparer(int columnIndex, ListSortDirection direction)
      {
        this.columnIndex = columnIndex;
        this.direction = direction;
      }

      public int Compare(object x, object y)
      {
        DataRow dataRow1 = (DataRow) x;
        DataRow dataRow2 = (DataRow) y;
        return string.Compare(dataRow1[this.columnIndex].ToString(), dataRow2[this.columnIndex].ToString()) * (this.direction == ListSortDirection.Ascending ? 1 : -1);
      }
    }
  }
}
