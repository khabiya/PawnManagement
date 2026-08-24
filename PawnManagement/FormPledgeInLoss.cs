

using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
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
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPledgeInLoss : Form
  {
    private bool smsclickedOnce = false;
    private DataTable dtPledgeInLoss = new DataTable();
    private DataTable dtLOAD = new DataTable();
    private DataTable dt = new DataTable();
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\lightbluefadedown.jpg");
    private string salePriceGold;
    private string salePriceSilver;
    private IContainer components = (IContainer) null;
    private DataGridView dgvNotice;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem callToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem selectAllToolStripMenuItem;
    private ToolStripMenuItem unSelectALLToolStripMenuItem;
    private ToolStripMenuItem sENDSMSToolStripMenuItem;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private TextBox tbxFromDate;
    private HeaderPanel headerPanel8;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxSilverSaleRate;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxGoldSaleRate;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private TextBox tbxRateOfInterest;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn colType;
    private DataGridViewTextBoxColumn colSalePrice;
    private DataGridViewTextBoxColumn colWeight;
    private DataGridViewTextBoxColumn colTotalSalePrice;
    private DataGridViewTextBoxColumn colAmountPlusInterest;
    private DataGridViewTextBoxColumn colLosss;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private DataGridViewCheckBoxColumn select;
    private DataGridViewTextBoxColumn ShopCode;
    private DataGridViewTextBoxColumn colPhoneNumber;
    private DataGridViewTextBoxColumn pledgeBillNumber;
    private DataGridViewTextBoxColumn pledgeBillDate;
    private DataGridViewTextBoxColumn customerCode;
    private DataGridViewTextBoxColumn nameAndAddress;
    private DataGridViewTextBoxColumn netWeight;
    private DataGridViewTextBoxColumn amount;
    private DataGridViewTextBoxColumn value;
    private DataGridViewTextBoxColumn Articles;
    private DataGridViewTextBoxColumn InterestRate;
    private DataGridViewTextBoxColumn interest;
    private DataGridViewTextBoxColumn interestPlusPrincipal;
    private DataGridViewTextBoxColumn saleRate;
    private DataGridViewTextBoxColumn perGram;
    private DataGridViewTextBoxColumn type;
    private DataGridViewTextBoxColumn colLoss;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormPledgeInLoss() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPledgeInLoss_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      PawnManagementClass.formatDataGridViewControl9(ref this.dgvNotice);
      PawnManagementClass.formatDataGridViewControl9(ref this.dataGridView1);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvNotice.DefaultCellStyle.ForeColor = Color.Black;
      this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
      this.dgvNotice.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
      DataTable unredeemedPledgeRecord = PawnManagementClass.getOldestUnredeemedPledgeRecord();
      DateTime now;
      if (unredeemedPledgeRecord != null && unredeemedPledgeRecord.Rows.Count > 0)
      {
        this.tbxFromDate.Text = DateTime.Parse(unredeemedPledgeRecord.Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      }
      else
      {
        TextBox tbxFromDate = this.tbxFromDate;
        now = DateTime.Now;
        string str = now.ToString("dd/MM/yyyy");
        tbxFromDate.Text = str;
      }
      TextBox tbxToDate = this.tbxToDate;
      now = DateTime.Now;
      string str1 = now.ToString("dd/MM/yyyy");
      tbxToDate.Text = str1;
      this.salePriceGold = double.Parse(PawnManagementClass.getSaleRate("GOLD")).ToString();
      this.salePriceSilver = double.Parse(PawnManagementClass.getSaleRate("SILVER")).ToString();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void checkForPledgeInLoss()
    {
      try
      {
        this.select.FillWeight = 28f;
        this.pledgeBillNumber.FillWeight = 53f;
        this.pledgeBillDate.FillWeight = 84f;
        this.customerCode.FillWeight = 50f;
        this.nameAndAddress.FillWeight = 280f;
        this.amount.FillWeight = 65f;
        this.value.FillWeight = 65f;
        this.Articles.FillWeight = 230f;
        this.netWeight.FillWeight = 60f;
        this.InterestRate.FillWeight = 25f;
        this.interest.FillWeight = 50f;
        this.interestPlusPrincipal.FillWeight = 70f;
        this.perGram.FillWeight = 61f;
        this.loaddataGridView();
        this.getTotal();
        for (int index = 0; index < this.dgvNotice.RowCount; ++index)
          this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
        this.setColours();
        this.deletePledgeNotInLoss();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form DashBoard.checkForPledgeInLoss", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void setColours()
    {
      try
      {
        for (int index = 0; index < this.dgvNotice.RowCount; ++index)
        {
          if (this.dgvNotice.Rows[index].Cells["Type"].Value.ToString().Equals("GOLD"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(this.salePriceGold))
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
            else
              this.dgvNotice.Rows[index].Selected = true;
          }
          else if (this.dgvNotice.Rows[index].Cells["Type"].Value.ToString().Equals("SILVER"))
          {
            if (double.Parse(this.dgvNotice.Rows[index].Cells["perGram"].Value.ToString()) > double.Parse(this.salePriceSilver))
              this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
            else
              this.dgvNotice.Rows[index].Selected = true;
          }
          else if (this.dgvNotice.Rows[index].Cells["Type"].Value.ToString().Equals("OTHERS"))
            this.dgvNotice.Rows[index].Selected = true;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form DashBoard.setColours", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void deletePledgeNotInLoss()
    {
      try
      {
        foreach (DataGridViewRow selectedRow in (BaseCollection) this.dgvNotice.SelectedRows)
        {
          if (!selectedRow.IsNewRow)
            this.dgvNotice.Rows.Remove(selectedRow);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form DashBoard.deletePledgeNotInLoss", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(ex.Message + ex.StackTrace);
      }
    }

    private void getTotal()
    {
      try
      {
        for (int index = 0; index < this.dgvNotice.RowCount; ++index)
        {
          DateTime.Parse(this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value.ToString());
          int num = PawnManagementClass.getNumberOfMonths(DateTime.Parse(this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value.ToString()), DateTime.Today) - 1;
          if (num != -1)
          {
            this.dgvNotice.Rows[index].Cells["interest"].Value = !(FormMain.memberType == "ak") ? (!(this.tbxRateOfInterest.Text == "") ? (object) (int.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * int.Parse(this.tbxRateOfInterest.Text.Trim()) * num / 1200) : (object) (int.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * int.Parse(this.dgvNotice.Rows[index].Cells["InterestRate"].Value.ToString()) * num / 1200)) : (object) (int.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) * int.Parse(PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0].Field<string>("RateOfInterest").ToString()) * num / 1200);
            this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value = (object) (int.Parse(this.dgvNotice.Rows[index].Cells["amount"].Value.ToString()) + int.Parse(this.dgvNotice.Rows[index].Cells["interest"].Value.ToString()));
            this.dgvNotice.Rows[index].Cells["perGram"].Value = (object) Math.Round((double) int.Parse(this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value.ToString()) / double.Parse(this.dgvNotice.Rows[index].Cells["netWeight"].Value.ToString()));
            if (this.dgvNotice.Rows[index].Cells["type"].Value.ToString() == "GOLD")
            {
              this.dgvNotice.Rows[index].Cells["saleRate"].Value = (object) ((double) int.Parse(this.salePriceGold) * double.Parse(this.dgvNotice.Rows[index].Cells["netWeight"].Value.ToString()));
              this.dgvNotice.Rows[index].Cells["colLoss"].Value = (object) (double.Parse(this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value.ToString()) - (double) int.Parse(this.salePriceGold) * double.Parse(this.dgvNotice.Rows[index].Cells["netWeight"].Value.ToString()));
            }
            if (this.dgvNotice.Rows[index].Cells["type"].Value.ToString() == "SILVER")
            {
              this.dgvNotice.Rows[index].Cells["saleRate"].Value = (object) ((double) int.Parse(this.salePriceSilver) * double.Parse(this.dgvNotice.Rows[index].Cells["netWeight"].Value.ToString()));
              this.dgvNotice.Rows[index].Cells["colLoss"].Value = (object) (double.Parse(this.dgvNotice.Rows[index].Cells["interestPlusPrincipal"].Value.ToString()) - (double) int.Parse(this.salePriceSilver) * double.Parse(this.dgvNotice.Rows[index].Cells["netWeight"].Value.ToString()));
            }
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form PLEDGEINLOSS.getTotal", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void loaddataGridView()
    {
      string strError = "";
      string str1 = "";
      string str2 = "";
      DataTable articlesSettings = PawnManagementClass.getArticlesSettings();
      if (articlesSettings.Rows[0]["PledgeInLossScreen"] != null)
        str1 = "p." + articlesSettings.Rows[0]["PledgeInLossScreen"].ToString() + " as Articles";
      if (this.cbShopCodes.Text != "")
        str2 = " where shopCode = @ShopCode";
      string my_querry = "SELECT p.ShopCode,p.BillNumber, p.BillDate, p.CustomerCode,c.cphone as phonenumber, c.cname+' '+c.cno+'  '+c.caddr1+'  '+c.caddr2 +'  '+c.caddr3 as NameAndAddress, p.amount, p.PresentValue, p.NetWeight, p.InterestRate, p.TYPE, p.articles FROM( SELECT p.ShopCode,p.BillNumber,p.PhoneNumber, p.BillDate, p.CustomerCode, p.amount, p.PresentValue, p.NetWeight, p.temp1 as InterestRate, p.TYPE,p.Redeemed ," + str1 + " FROM tblPledge AS p " + str2 + ") AS p LEFT JOIN tblcustomers AS c ON p.customercode=c.cid where  (p.redeemed = 'N') and (p.Billdate >= @BillDate1 and p.Billdate <= @BillDate2) order by p.customercode,p.amount";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.cbShopCodes.Text != "")
        parameters.Add(new OleDbParameter("shopCode", (object) this.cbShopCodes.Text));
      parameters.Add(new OleDbParameter("BillDate1", (object) this.tbxFromDate.Text));
      parameters.Add(new OleDbParameter("BillDate2", (object) this.tbxToDate.Text));
      this.dtLOAD = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in fetching the customer pledge details.\n" + strError);
        PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        try
        {
          int count = this.dtLOAD.Rows.Count;
          this.dgvNotice.Rows.Clear();
          if (this.dtLOAD.Rows.Count > 0)
          {
            this.dgvNotice.Rows.Add(this.dtLOAD.Rows.Count);
            for (int index = 0; index < this.dtLOAD.Rows.Count; ++index)
            {
              this.dgvNotice.Rows[index].Cells["pledgeBillNumber"].Value = (object) this.dtLOAD.Rows[index]["BillNumber"].ToString();
              this.dgvNotice.Rows[index].Cells["pledgeBillDate"].Value = (object) DateTime.Parse(this.dtLOAD.Rows[index]["BillDate"].ToString()).ToString("dd/MM/yyyy");
              this.dgvNotice.Rows[index].Cells["CustomerCode"].Value = (object) this.dtLOAD.Rows[index]["CustomerCode"].ToString();
              this.dgvNotice.Rows[index].Cells["netweight"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["NetWeight"].ToString());
              this.dgvNotice.Rows[index].Cells["amount"].Value = (object) double.Parse(this.dtLOAD.Rows[index]["amount"].ToString());
              this.dgvNotice.Rows[index].Cells["value"].Value = (object) this.dtLOAD.Rows[index]["presentValue"].ToString();
              this.dgvNotice.Rows[index].Cells["nameAndAddress"].Value = (object) this.dtLOAD.Rows[index]["NameAndAddress"].ToString();
              this.dgvNotice.Rows[index].Cells["InterestRate"].Value = (object) this.dtLOAD.Rows[index]["InterestRate"].ToString();
              this.dgvNotice.Rows[index].Cells["type"].Value = (object) this.dtLOAD.Rows[index]["Type"].ToString();
              this.dgvNotice.Rows[index].Cells["Articles"].Value = (object) this.dtLOAD.Rows[index]["Articles"].ToString();
              this.dgvNotice.Rows[index].Cells["colPhoneNumber"].Value = (object) this.dtLOAD.Rows[index]["PhoneNumber"].ToString();
              this.dgvNotice.Rows[index].Cells["ShopCode"].Value = (object) this.dtLOAD.Rows[index]["ShopCode"].ToString();
            }
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form notice.loaddatagridview()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void decrypting(object sender, WaitWindowEventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      try
      {
        FormSendSMS formSendSms = new FormSendSMS();
        List<string> FieldToBind = new List<string>();
        FieldToBind.Add("PhoneNumber");
        FieldToBind.Add("CustomerCode");
        FieldToBind.Add("CustomerNameAndAddress");
        if (!this.smsclickedOnce)
        {
          this.getDatatabledt();
          this.smsclickedOnce = true;
        }
        this.getdatatabledtdata();
        formSendSms.LoadNotice(this.dt, "CustomerCode", "PhoneNumber", FieldToBind);
        int num = (int) formSendSms.ShowDialog();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form dash board.btnSendSmsPledgeInLoss_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getdatatabledtdata()
    {
      int num = 0;
      this.dt.Clear();
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["select"].Value != null && bool.Parse(row.Cells["select"].Value.ToString()) && row.Cells["COLPhoneNumber"].Value.ToString().Length == 10 && this.IsDigitsOnly(row.Cells["COLPhoneNumber"].Value.ToString()) && !this.checkIfDataTableAlreadyContains(row.Cells["CustomerCode"].Value.ToString()))
        {
          ++num;
          this.dt.Rows.Add((object) row.Cells["colPhoneNumber"].Value.ToString(), (object) row.Cells["customercode"].Value.ToString(), (object) row.Cells["NameAndAddress"].Value.ToString());
        }
      }
    }

    private bool checkIfDataTableAlreadyContains(string customerCode)
    {
      foreach (DataRow row in (InternalDataCollectionBase) this.dt.Rows)
      {
        if (row["customercode"].ToString() == customerCode)
          return true;
      }
      return false;
    }

    private void getDatatabledt()
    {
      this.dt.Columns.Add("PhoneNumber", typeof (string));
      this.dt.Columns.Add("CustomerCode", typeof (string));
      this.dt.Columns.Add("CustomerNameAndAddress", typeof (string));
    }

    private bool IsDigitsOnly(string str)
    {
      if (str == "")
        return false;
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void btnShow_Click(object sender, EventArgs e) => this.SHOW();

    private void SHOW()
    {
      if (!PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text) || !PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
        return;
      if (this.tbxGoldSaleRate.Text != "")
      {
        this.salePriceGold = this.tbxGoldSaleRate.Text;
        this.salePriceSilver = double.Parse(PawnManagementClass.getSaleRate("SILVER")).ToString();
      }
      double num;
      if (this.tbxSilverSaleRate.Text != "")
      {
        num = double.Parse(PawnManagementClass.getSaleRate("GOLD"));
        this.salePriceGold = num.ToString();
        this.salePriceSilver = this.tbxSilverSaleRate.Text;
      }
      if (this.tbxGoldSaleRate.Text != "" && this.tbxSilverSaleRate.Text != "")
      {
        this.salePriceGold = this.tbxGoldSaleRate.Text;
        this.salePriceSilver = this.tbxSilverSaleRate.Text;
      }
      if (this.tbxGoldSaleRate.Text == "" && this.tbxSilverSaleRate.Text == "")
      {
        num = double.Parse(PawnManagementClass.getSaleRate("SILVER"));
        this.salePriceSilver = num.ToString();
        num = double.Parse(PawnManagementClass.getSaleRate("GOLD"));
        this.salePriceGold = num.ToString();
      }
      this.checkForPledgeInLoss();
      this.getTotalLoss();
      this.dgvNotice.Columns["Amount"].ValueType = typeof (double);
    }

    private void getTotalLoss()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      double num5 = 0.0;
      double num6 = 0.0;
      double num7 = 0.0;
      double num8 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvNotice.Rows)
      {
        if (row.Cells["type"].Value.ToString() == "GOLD")
        {
          num4 += double.Parse(row.Cells["netweight"].Value.ToString());
          num1 += double.Parse(row.Cells["amount"].Value.ToString());
          num2 += double.Parse(row.Cells["interest"].Value.ToString());
          num3 += double.Parse(row.Cells["colloss"].Value.ToString());
        }
        if (row.Cells["type"].Value.ToString() == "SILVER")
        {
          num8 += double.Parse(row.Cells["netweight"].Value.ToString());
          num5 += double.Parse(row.Cells["amount"].Value.ToString());
          num6 += double.Parse(row.Cells["interest"].Value.ToString());
          num7 += double.Parse(row.Cells["colloss"].Value.ToString());
        }
      }
      this.dataGridView1.Rows.Add(2);
      this.dataGridView1.Rows[0].Cells["colWeight"].Value = (object) num4.ToString("F");
      this.dataGridView1.Rows[1].Cells["colWeight"].Value = (object) num8.ToString("F");
      this.dataGridView1.Rows[0].Cells["colType"].Value = (object) "GOLD";
      this.dataGridView1.Rows[1].Cells["colType"].Value = (object) "SILVER";
      this.dataGridView1.Rows[2].Cells["colType"].Value = (object) "TOTAL";
      this.dataGridView1.Rows[0].Cells["colSalePrice"].Value = (object) this.salePriceGold;
      this.dataGridView1.Rows[1].Cells["colSalePrice"].Value = (object) this.salePriceSilver;
      DataGridViewCell cell1 = this.dataGridView1.Rows[0].Cells["colTotalSalePrice"];
      double num9 = num4 * double.Parse(this.salePriceGold);
      string str1 = num9.ToString();
      cell1.Value = (object) str1;
      DataGridViewCell cell2 = this.dataGridView1.Rows[1].Cells["colTotalSalePrice"];
      num9 = num8 * double.Parse(this.salePriceSilver);
      string str2 = num9.ToString();
      cell2.Value = (object) str2;
      DataGridViewCell cell3 = this.dataGridView1.Rows[0].Cells["colAmountPlusInterest"];
      num9 = num1 + num2;
      string str3 = num9.ToString("F");
      cell3.Value = (object) str3;
      DataGridViewCell cell4 = this.dataGridView1.Rows[1].Cells["colAmountPlusInterest"];
      num9 = num5 + num6;
      string str4 = num9.ToString("F");
      cell4.Value = (object) str4;
      this.dataGridView1.Rows[0].Cells["colLosss"].Value = (object) num3.ToString("F");
      this.dataGridView1.Rows[1].Cells["colLosss"].Value = (object) num7.ToString("F");
      DataGridViewCell cell5 = this.dataGridView1.Rows[2].Cells["colLosss"];
      num9 = num3 + num7;
      string str5 = num9.ToString("F");
      cell5.Value = (object) str5;
    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      int rowCount = this.dgvNotice.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) true;
    }

    private void btnUnselectAll_Click(object sender, EventArgs e)
    {
      int rowCount = this.dgvNotice.RowCount;
      for (int index = 0; index < rowCount; ++index)
        this.dgvNotice.Rows[index].Cells["select"].Value = (object) false;
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void callToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new FormCall(this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["COLPHONENUMBER"].Value.ToString()).ShowDialog();
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (this.dgvNotice.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        this.dgvNotice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        this.dgvNotice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

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

    private void tbxGoldSaleRate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void dgvNotice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Pledge in Loss").ShowDialog();
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    private void tbxFromDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.SHOW();
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e)
    {
      if (!PawnManagementClass.checkForValidateDate((sender as TextBox).Text))
        return;
      this.SHOW();
    }

    private void tbxGoldSaleRate_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void tbxSilverSaleRate_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void tbxRateOfInterest_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void cbShopCodes_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0)
        return;
      if (this.dgvNotice.CurrentCell.OwningColumn.HeaderText == "ID")
      {
        string CUSTOMERCODE = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dgvNotice.CurrentCell.OwningColumn.HeaderText == "NO")
      {
        double num = (double) (this.dgvNotice.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["pledgeBillNumber"].Value.ToString();
        string SHOPCODE = this.dgvNotice.Rows[this.dgvNotice.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
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

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvNotice.Rows.Count <= 0 || this.dgvNotice.Columns.Count <= 0)
        return;
      if (this.dgvNotice.Columns[e.ColumnIndex].HeaderText == "NO" | this.dgvNotice.Columns[e.ColumnIndex].HeaderText == "ID")
        this.dgvNotice.Cursor = Cursors.Hand;
      else
        this.dgvNotice.Cursor = Cursors.Default;
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
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle16 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle17 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle18 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle19 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle20 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle21 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle22 = new DataGridViewCellStyle();
      this.dgvNotice = new DataGridView();
      this.select = new DataGridViewCheckBoxColumn();
      this.ShopCode = new DataGridViewTextBoxColumn();
      this.colPhoneNumber = new DataGridViewTextBoxColumn();
      this.pledgeBillNumber = new DataGridViewTextBoxColumn();
      this.pledgeBillDate = new DataGridViewTextBoxColumn();
      this.customerCode = new DataGridViewTextBoxColumn();
      this.nameAndAddress = new DataGridViewTextBoxColumn();
      this.netWeight = new DataGridViewTextBoxColumn();
      this.amount = new DataGridViewTextBoxColumn();
      this.value = new DataGridViewTextBoxColumn();
      this.Articles = new DataGridViewTextBoxColumn();
      this.InterestRate = new DataGridViewTextBoxColumn();
      this.interest = new DataGridViewTextBoxColumn();
      this.interestPlusPrincipal = new DataGridViewTextBoxColumn();
      this.saleRate = new DataGridViewTextBoxColumn();
      this.perGram = new DataGridViewTextBoxColumn();
      this.type = new DataGridViewTextBoxColumn();
      this.colLoss = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.callToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new ToolStripMenuItem();
      this.unSelectALLToolStripMenuItem = new ToolStripMenuItem();
      this.sENDSMSToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.headerPanel8 = new HeaderPanel();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.tbxToDate = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxSilverSaleRate = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxGoldSaleRate = new TextBox();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxRateOfInterest = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.dataGridView1 = new DataGridView();
      this.colType = new DataGridViewTextBoxColumn();
      this.colSalePrice = new DataGridViewTextBoxColumn();
      this.colWeight = new DataGridViewTextBoxColumn();
      this.colTotalSalePrice = new DataGridViewTextBoxColumn();
      this.colAmountPlusInterest = new DataGridViewTextBoxColumn();
      this.colLosss = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dgvNotice).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel8).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dgvNotice.AllowUserToAddRows = false;
      this.dgvNotice.AllowUserToOrderColumns = true;
      this.dgvNotice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvNotice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvNotice.BackgroundColor = Color.White;
      this.dgvNotice.BorderStyle = BorderStyle.Fixed3D;
      this.dgvNotice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      this.dgvNotice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.PaleTurquoise;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.MediumBlue;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvNotice.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvNotice.ColumnHeadersHeight = 40;
      this.dgvNotice.Columns.AddRange((DataGridViewColumn) this.select, (DataGridViewColumn) this.ShopCode, (DataGridViewColumn) this.colPhoneNumber, (DataGridViewColumn) this.pledgeBillNumber, (DataGridViewColumn) this.pledgeBillDate, (DataGridViewColumn) this.customerCode, (DataGridViewColumn) this.nameAndAddress, (DataGridViewColumn) this.netWeight, (DataGridViewColumn) this.amount, (DataGridViewColumn) this.value, (DataGridViewColumn) this.Articles, (DataGridViewColumn) this.InterestRate, (DataGridViewColumn) this.interest, (DataGridViewColumn) this.interestPlusPrincipal, (DataGridViewColumn) this.saleRate, (DataGridViewColumn) this.perGram, (DataGridViewColumn) this.type, (DataGridViewColumn) this.colLoss);
      this.dgvNotice.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.ControlLightLight;
      gridViewCellStyle2.Font = new Font("Cambria Math", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.Black;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvNotice.DefaultCellStyle = gridViewCellStyle2;
      this.dgvNotice.EnableHeadersVisualStyles = false;
      this.dgvNotice.GridColor = Color.Lavender;
      this.dgvNotice.Location = new Point(2, 61);
      this.dgvNotice.Name = "dgvNotice";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Info;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = Color.Black;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dgvNotice.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dgvNotice.RowHeadersVisible = false;
      this.dgvNotice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvNotice.Size = new Size(1003, 430);
      this.dgvNotice.TabIndex = 21;
      this.dgvNotice.TabStop = false;
      this.dgvNotice.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dgvNotice.CellMouseEnter += new DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
      this.dgvNotice.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvNotice_CellPainting);
      this.select.HeaderText = "tick";
      this.select.Name = "select";
      this.select.Resizable = DataGridViewTriState.True;
      this.select.SortMode = DataGridViewColumnSortMode.Automatic;
      this.ShopCode.HeaderText = "ShopCode";
      this.ShopCode.Name = "ShopCode";
      this.ShopCode.Visible = false;
      this.colPhoneNumber.HeaderText = "PhoneNumber";
      this.colPhoneNumber.Name = "colPhoneNumber";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.pledgeBillNumber.DefaultCellStyle = gridViewCellStyle4;
      this.pledgeBillNumber.FillWeight = 10f;
      this.pledgeBillNumber.HeaderText = "NO";
      this.pledgeBillNumber.MaxInputLength = 6;
      this.pledgeBillNumber.Name = "pledgeBillNumber";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.pledgeBillDate.DefaultCellStyle = gridViewCellStyle5;
      this.pledgeBillDate.FillWeight = 10f;
      this.pledgeBillDate.HeaderText = "Bill Date";
      this.pledgeBillDate.Name = "pledgeBillDate";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.customerCode.DefaultCellStyle = gridViewCellStyle6;
      this.customerCode.HeaderText = "ID";
      this.customerCode.Name = "customerCode";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.nameAndAddress.DefaultCellStyle = gridViewCellStyle7;
      this.nameAndAddress.HeaderText = "NAME AND ADDRESS";
      this.nameAndAddress.Name = "nameAndAddress";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.netWeight.DefaultCellStyle = gridViewCellStyle8;
      this.netWeight.HeaderText = "Wt";
      this.netWeight.Name = "netWeight";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.amount.DefaultCellStyle = gridViewCellStyle9;
      this.amount.HeaderText = "Amount";
      this.amount.Name = "amount";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.value.DefaultCellStyle = gridViewCellStyle10;
      this.value.HeaderText = "Value";
      this.value.Name = "value";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.Articles.DefaultCellStyle = gridViewCellStyle11;
      this.Articles.HeaderText = "Articles";
      this.Articles.Name = "Articles";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.InterestRate.DefaultCellStyle = gridViewCellStyle12;
      this.InterestRate.HeaderText = "INTEREST RATE";
      this.InterestRate.Name = "InterestRate";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.interest.DefaultCellStyle = gridViewCellStyle13;
      this.interest.HeaderText = "INTEREST";
      this.interest.Name = "interest";
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.interestPlusPrincipal.DefaultCellStyle = gridViewCellStyle14;
      this.interestPlusPrincipal.HeaderText = "AMOUNT + INTEREST";
      this.interestPlusPrincipal.Name = "interestPlusPrincipal";
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.saleRate.DefaultCellStyle = gridViewCellStyle15;
      this.saleRate.HeaderText = "Sale Rate";
      this.saleRate.Name = "saleRate";
      gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.perGram.DefaultCellStyle = gridViewCellStyle16;
      this.perGram.HeaderText = "Sale Rate Per Gram";
      this.perGram.Name = "perGram";
      this.type.HeaderText = "Type";
      this.type.Name = "type";
      gridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colLoss.DefaultCellStyle = gridViewCellStyle17;
      this.colLoss.HeaderText = "LOSS";
      this.colLoss.Name = "colLoss";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.callToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.selectAllToolStripMenuItem,
        (ToolStripItem) this.unSelectALLToolStripMenuItem,
        (ToolStripItem) this.sENDSMSToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 180);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.callToolStripMenuItem.Name = "callToolStripMenuItem";
      this.callToolStripMenuItem.Size = new Size(194, 22);
      this.callToolStripMenuItem.Text = "Call";
      this.callToolStripMenuItem.Click += new EventHandler(this.callToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Visible = false;
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new Size(194, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new EventHandler(this.btnSelectAll_Click);
      this.unSelectALLToolStripMenuItem.Name = "unSelectALLToolStripMenuItem";
      this.unSelectALLToolStripMenuItem.Size = new Size(194, 22);
      this.unSelectALLToolStripMenuItem.Text = "UnSelect ALL";
      this.unSelectALLToolStripMenuItem.Click += new EventHandler(this.btnUnselectAll_Click);
      this.sENDSMSToolStripMenuItem.Name = "sENDSMSToolStripMenuItem";
      this.sENDSMSToolStripMenuItem.Size = new Size(194, 22);
      this.sENDSMSToolStripMenuItem.Text = "SEND SMS";
      this.sENDSMSToolStripMenuItem.Click += new EventHandler(this.glassButton1_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      ((Control) this.headerPanel6).Anchor = AnchorStyles.Top;
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
      ((Control) this.headerPanel6).Location = new Point(8, 6);
      ((Control) this.headerPanel6).Name = "headerPanel6";
      this.headerPanel6.PanelIcon = (Icon) null;
      this.headerPanel6.PanelIconVisible = false;
      ((Control) this.headerPanel6).Size = new Size(137, 49);
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
      ((Control) this.glassButton10).Location = new Point(-158, 513);
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
      ((Control) this.glassButton11).Location = new Point(-24, 512);
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
      this.tbxFromDate.Size = new Size(135, 24);
      this.tbxFromDate.TabIndex = 26;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      ((Control) this.headerPanel8).Anchor = AnchorStyles.Top;
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
      ((Control) this.headerPanel8).Location = new Point(153, 6);
      ((Control) this.headerPanel8).Name = "headerPanel8";
      this.headerPanel8.PanelIcon = (Icon) null;
      this.headerPanel8.PanelIconVisible = false;
      ((Control) this.headerPanel8).Size = new Size(137, 49);
      ((Control) this.headerPanel8).TabIndex = 78;
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
      ((Control) this.glassButton14).Location = new Point(-160, 513);
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
      ((Control) this.glassButton15).Location = new Point(-26, 512);
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
      this.tbxToDate.Size = new Size(135, 24);
      this.tbxToDate.TabIndex = 26;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top;
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
      this.headerPanel1.CaptionText = "SILVER SALE RATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxSilverSaleRate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(443, 6);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(137, 49);
      ((Control) this.headerPanel1).TabIndex = 80;
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
      ((Control) this.glassButton1).Location = new Point(-162, 513);
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
      ((Control) this.glassButton2).Location = new Point(-28, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxSilverSaleRate.BackColor = Color.AliceBlue;
      this.tbxSilverSaleRate.BorderStyle = BorderStyle.None;
      this.tbxSilverSaleRate.Dock = DockStyle.Fill;
      this.tbxSilverSaleRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSilverSaleRate.Location = new Point(0, 0);
      this.tbxSilverSaleRate.Name = "tbxSilverSaleRate";
      this.tbxSilverSaleRate.Size = new Size(135, 24);
      this.tbxSilverSaleRate.TabIndex = 26;
      this.tbxSilverSaleRate.TextAlign = HorizontalAlignment.Center;
      this.tbxSilverSaleRate.TextChanged += new EventHandler(this.tbxSilverSaleRate_TextChanged);
      this.tbxSilverSaleRate.KeyPress += new KeyPressEventHandler(this.tbxGoldSaleRate_KeyPress);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top;
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
      this.headerPanel2.CaptionText = "GOLD SALE RATE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxGoldSaleRate);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(298, 6);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(137, 49);
      ((Control) this.headerPanel2).TabIndex = 79;
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
      ((Control) this.glassButton3).Location = new Point(-160, 513);
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
      ((Control) this.glassButton4).Location = new Point(-26, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxGoldSaleRate.BackColor = Color.AliceBlue;
      this.tbxGoldSaleRate.BorderStyle = BorderStyle.None;
      this.tbxGoldSaleRate.Dock = DockStyle.Fill;
      this.tbxGoldSaleRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxGoldSaleRate.Location = new Point(0, 0);
      this.tbxGoldSaleRate.Name = "tbxGoldSaleRate";
      this.tbxGoldSaleRate.Size = new Size(135, 24);
      this.tbxGoldSaleRate.TabIndex = 26;
      this.tbxGoldSaleRate.TextAlign = HorizontalAlignment.Center;
      this.tbxGoldSaleRate.TextChanged += new EventHandler(this.tbxGoldSaleRate_TextChanged);
      this.tbxGoldSaleRate.KeyPress += new KeyPressEventHandler(this.tbxGoldSaleRate_KeyPress);
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top;
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
      this.headerPanel3.CaptionText = "RATE OF INTEREST";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxRateOfInterest);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(588, 6);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(137, 49);
      ((Control) this.headerPanel3).TabIndex = 81;
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
      ((Control) this.glassButton5).Location = new Point(-164, 513);
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
      ((Control) this.glassButton6).Location = new Point(-30, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxRateOfInterest.BackColor = Color.AliceBlue;
      this.tbxRateOfInterest.BorderStyle = BorderStyle.None;
      this.tbxRateOfInterest.Dock = DockStyle.Fill;
      this.tbxRateOfInterest.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRateOfInterest.Location = new Point(0, 0);
      this.tbxRateOfInterest.Name = "tbxRateOfInterest";
      this.tbxRateOfInterest.Size = new Size(135, 24);
      this.tbxRateOfInterest.TabIndex = 26;
      this.tbxRateOfInterest.TextAlign = HorizontalAlignment.Center;
      this.tbxRateOfInterest.TextChanged += new EventHandler(this.tbxRateOfInterest_TextChanged);
      this.tbxRateOfInterest.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
      ((Control) this.headerPanel7).Anchor = AnchorStyles.Top;
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
      ((Control) this.headerPanel7).Location = new Point(733, 6);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(272, 49);
      ((Control) this.headerPanel7).TabIndex = 84;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.Dock = DockStyle.Fill;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 0);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(270, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.TextChanged += new EventHandler(this.cbShopCodes_TextChanged);
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
      ((Control) this.glassButton8).Location = new Point(-37, 513);
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
      ((Control) this.glassButton9).Location = new Point(97, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colType, (DataGridViewColumn) this.colSalePrice, (DataGridViewColumn) this.colWeight, (DataGridViewColumn) this.colTotalSalePrice, (DataGridViewColumn) this.colAmountPlusInterest, (DataGridViewColumn) this.colLosss);
      this.dataGridView1.Location = new Point(2, 497);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(1003, 113);
      this.dataGridView1.TabIndex = 45;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.colType.HeaderText = "TYPE";
      this.colType.Name = "colType";
      gridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colSalePrice.DefaultCellStyle = gridViewCellStyle18;
      this.colSalePrice.HeaderText = "SALE PRICE";
      this.colSalePrice.Name = "colSalePrice";
      gridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colWeight.DefaultCellStyle = gridViewCellStyle19;
      this.colWeight.HeaderText = "WEIGHT";
      this.colWeight.Name = "colWeight";
      gridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colTotalSalePrice.DefaultCellStyle = gridViewCellStyle20;
      this.colTotalSalePrice.HeaderText = "TOTAL SALE PRICE";
      this.colTotalSalePrice.Name = "colTotalSalePrice";
      gridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colAmountPlusInterest.DefaultCellStyle = gridViewCellStyle21;
      this.colAmountPlusInterest.HeaderText = "AMOUNT PLUS INTEREST";
      this.colAmountPlusInterest.Name = "colAmountPlusInterest";
      gridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colLosss.DefaultCellStyle = gridViewCellStyle22;
      this.colLosss.HeaderText = "LOSS";
      this.colLosss.Name = "colLosss";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 612);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.headerPanel6);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.headerPanel8);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.dgvNotice);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormPledgeInLoss);
      this.Text = nameof (FormPledgeInLoss);
      this.Load += new EventHandler(this.FormPledgeInLoss_Load);
      ((ISupportInitialize) this.dgvNotice).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel8).ResumeLayout(false);
      ((Control) this.headerPanel8).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
