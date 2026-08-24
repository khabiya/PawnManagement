

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
  public class FormLedger : Form
  {
    private bool loadFinished = false;
    private DataTable dtSms = new DataTable();
    private ReportDocument rd = new ReportDocument();
    private DataTable dtLedger = new DataTable();
    private bool ledgerprinted = false;
    private DataTable dt = new DataTable();
    private IContainer components = (IContainer) null;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private ComboBox cbLedgerType;
    private GlassButton btnPrint;
    private HeaderPanel headerPanel7;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private HeaderPanel hpFromDate;
    private GlassButton glassButton10;
    private GlassButton glassButton11;
    private HeaderPanel hpToDate;
    private GlassButton glassButton14;
    private GlassButton glassButton15;
    private DataGridView dataGridView1;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private CheckBox cbAddress2;
    private CheckBox cbMobileNumber;
    private CheckBox cbName;
    private CheckBox cbAddress1;
    private CheckBox cbPincode;
    private CheckBox cbLocation;
    private CheckBox cbCode;
    private CheckBox cbCity;
    private CheckBox cbNo;
    private ComboBox cbShopCodes;
    private TextBox tbxFromDate;
    private TextBox tbxToDate;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem changeColumnOrderToolStripMenuItem;
    private HeaderPanel hpToBillNumber;
    private TextBox tbxToBillNumber;
    private GlassButton glassButton1;
    private GlassButton glassButton6;
    private HeaderPanel hpFromBillNumber;
    private TextBox tbxFromBillNumber;
    private GlassButton glassButton7;
    private GlassButton glassButton12;
    private HeaderPanel headerPanel5;
    private ComboBox cbFilterBy;
    private GlassButton glassButton13;
    private GlassButton glassButton16;
    private HeaderPanel headerPanel1;
    private ComboBox cbType;
    private GlassButton glassButton17;
    private GlassButton glassButton18;

    public FormLedger() => this.InitializeComponent();

    private void getLedger(DateTime d1, DateTime d2, string typeOfLedger)
    {
      if (!this.loadFinished)
        return;
      string strError = "";
      string newValue = "p." + FormMain.LedgerScreen + " as Articles";
      string my_querry = "select * from( select  " + "p.shopcode, p.BillNumber, p.OldBillNumber, p.BillDate, p.CustomerCode, nameAndAddress, p.Amount, p.PresentValue, p.NetWeight, articles, RedemptionAmount16 & AuctionAmount  AS RedemptionAmount, CVDate(IIF(REdemptionDate & AuctionDate is Null, Null, DateValue(REdemptionDate & AuctionDate)))  as RedemptionDate, RedemptionBillNumber".Replace("nameAndAddress", this.getNameAndADdress()).Replace("articles", newValue) + " from tblPledge p where shopcode = @ShopCode ) as np where np.BillDate between @d1 and  @d2 order By np.BillNumber";
      DataTable dataTable = new DataTable();
      this.dtLedger = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Shopcode", (object) this.cbShopCodes.Text),
        new OleDbParameter(nameof (d1), (object) d1.ToString("dd/MM/yyyy")),
        new OleDbParameter(nameof (d1), (object) d2.ToString("dd/MM/yyyy"))
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form ledger.getLedger()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the pledge details  .\n" + strError);
      }
      else
      {
        this.dataGridView1.DataSource = (object) this.dtLedger;
        if (this.cbShopCodes.Items.Count == 1 | this.cbShopCodes.Text != "")
          this.dataGridView1.Columns["shopcode"].Visible = false;
      }
    }

    private void getLedger(string strFromBillNumber, string strToBillNumber, string typeOfLedger)
    {
      if (!this.loadFinished)
        return;
      string strError = "";
      string newValue = "p." + FormMain.LedgerScreen + " as Articles";
      string nameAndAddress = this.getNameAndADdress();
      string my_querry = "select * from( select  " + (!(typeOfLedger == "1") ? OrderClass.getColumnOrderForLedgerScreen2() : OrderClass.getColumnOrderForLedgerScreen1()).Replace("nameAndAddress", nameAndAddress).Replace("articles", newValue) + " from tblPledge p where shopcode = @ShopCode ) as np where np.BillNumber between @d1 and  @d2 order By np.BillNumber";
      DataTable dataTable = new DataTable();
      this.dtLedger = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter("Shopcode", (object) this.cbShopCodes.Text),
        new OleDbParameter("d1", (object) strFromBillNumber),
        new OleDbParameter("d2", (object) strToBillNumber)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form ledger.getLedger()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the pledge details  .\n" + strError);
      }
      else
      {
        this.dataGridView1.DataSource = (object) this.dtLedger;
        if (this.cbShopCodes.Items.Count == 1 | this.cbShopCodes.Text != "")
          this.dataGridView1.Columns["shopcode"].Visible = false;
      }
    }

    private void alignDataGridView()
    {
      try
      {
        if (!this.loadFinished)
          return;
        this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView1.Columns["PresentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridView1.Columns["NetWeight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form ledgger.aligndatagridview", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void Ledger_Load(object sender, EventArgs e)
    {
      this.SuspendLayout();
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      this.dataGridView1.GridColor = Color.PowderBlue;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
      this.dtSms.Columns.Add("cid");
      this.dtSms.Columns.Add("cname");
      this.dtSms.Columns.Add("cphone");
      this.getReportTypes();
      if (this.cbLedgerType.Items.Count > 0)
        this.cbLedgerType.SelectedIndex = 0;
      this.tbxToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      this.cbLedgerType.Text = File.ReadAllLines("Reports\\Ledger\\LastUsed.txt")[0].ToString();
      this.loadFinished = true;
      this.tbxFromDate.Text = DateTime.Parse(PawnManagementClass.getOldestPledgeRecord().Rows[0]["BillDate"].ToString()).ToString("dd/MM/yyyy");
      this.tbxFromDate.Select();
      this.ResumeLayout();
    }

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Ledger\\\\", "*.rpt"))
        this.cbLedgerType.Items.Add(file);
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getLedgerType()
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
          if (row["LedgerPrintFormats"].ToString() != "")
            this.cbLedgerType.Items.Add((object) row["LedgerPrintFormats"].ToString());
        }
      }
    }

    private void button1_Click(object sender, EventArgs e) => this.SHOW();

    private void SHOW()
    {
      try
      {
        if (this.cbFilterBy.Text == "DATE")
        {
          if (this.tbxFromDate.Text.Trim().Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
          {
            if (this.tbxToDate.Text.Trim().Length == 10 && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
            {
              this.getLedger(DateTime.Parse(this.tbxFromDate.Text), DateTime.Parse(this.tbxToDate.Text), this.cbType.Text);
              this.alignDataGridView();
            }
            else
            {
              this.dataGridView1.DataSource = (object) null;
              this.tbxToDate.Select();
            }
          }
          else
          {
            this.dataGridView1.DataSource = (object) null;
            this.tbxFromDate.Select();
          }
        }
        else
        {
          if (!(this.cbFilterBy.Text == "BILL NUMBER"))
            return;
          if (((!(FormMain.BillNumberSeries == "SINGLE") ? 0 : (PawnManagementClass.validateBillNumber(this.tbxFromBillNumber.Text) ? 1 : 0)) | (!(FormMain.BillNumberSeries == "DOUBLE") ? 0 : (PawnManagementClass.validateBillNumberDouble(this.tbxFromBillNumber.Text) ? 1 : 0))) != 0)
          {
            if (((!(FormMain.BillNumberSeries == "SINGLE") ? 0 : (PawnManagementClass.validateBillNumber(this.tbxToBillNumber.Text) ? 1 : 0)) | (!(FormMain.BillNumberSeries == "DOUBLE") ? 0 : (PawnManagementClass.validateBillNumberDouble(this.tbxToBillNumber.Text) ? 1 : 0))) != 0)
            {
              this.getLedger(this.tbxFromBillNumber.Text, this.tbxToBillNumber.Text, this.cbType.Text);
              this.alignDataGridView();
            }
            else
            {
              this.dataGridView1.DataSource = (object) null;
              this.tbxToBillNumber.Select();
            }
          }
          else
          {
            this.dataGridView1.DataSource = (object) null;
            this.tbxFromBillNumber.Select();
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private void button1_Click_1(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "pledgeBook", FormMain.username);

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.ledgerprinted)
        {
          this.dt.Columns.Add("BillNumber", typeof (string));
          this.dt.Columns.Add("OldBillNumber", typeof (string));
          this.dt.Columns.Add("BillDate", typeof (DateTime));
          this.dt.Columns.Add("CustomerNameAndAddress", typeof (string));
          this.dt.Columns.Add("Amount", typeof (string));
          this.dt.Columns.Add("NetWeight", typeof (string));
          this.dt.Columns.Add("PresentValue", typeof (string));
          this.dt.Columns.Add("Articles", typeof (string));
          this.dt.Columns.Add("PblNumber", typeof (string));
          this.dt.Columns.Add("RedemptionAmount", typeof (string));
          this.dt.Columns.Add("RedemptionDate", typeof (string));
          this.dt.Columns.Add("RedemptionBillNumber", typeof (string));
          this.ledgerprinted = true;
        }
        string str1 = PawnManagementClass.getShopDetails(this.cbShopCodes.Text).Rows[0]["pblNumber"].ToString();
        this.dt.Rows.Clear();
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          string str2 = row.Cells["RedemptionDate"].Value == null || !(row.Cells["RedemptionDate"].Value.ToString() != "") ? "" : DateTime.Parse(row.Cells["RedemptionDate"].Value.ToString()).ToString("dd/MM/yyyy");
          this.dt.Rows.Add((object) row.Cells["BillNumber"].Value.ToString(), (object) row.Cells["OldBillNumber"].Value.ToString(), (object) DateTime.Parse(row.Cells["BillDate"].Value.ToString()), (object) row.Cells["NameAndAddress"].Value.ToString(), (object) row.Cells["Amount"].Value.ToString(), (object) row.Cells["NetWeight"].Value.ToString(), (object) row.Cells["PresentValue"].Value.ToString(), (object) row.Cells["Articles"].Value.ToString(), (object) str1, (object) row.Cells["RedemptionAmount"].Value.ToString(), (object) str2, (object) row.Cells["RedemptionBillNumber"].Value.ToString());
        }
        ReportDocument RD = new ReportDocument();
        RD.Load(this.cbLedgerType.Text);
        RD.SetDataSource(this.dt);
        this.dt.TableName = "Ledger";
        this.dt.WriteXmlSchema(this.dt.TableName + ".xml");
        PaperOrientation paperORIENTATION = PaperOrientation.Landscape;
        PaperSize paperSIZE = PaperSize.PaperA4;
        new FormCrystalReportViewer(RD, paperORIENTATION, paperSIZE).Show();
        File.WriteAllText("Reports\\\\Ledger\\\\LastUsed.txt", this.cbLedgerType.Text);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form ledger.button3_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
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

    private void callToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["phonenumber"].Value.ToString() != ""))
        return;
      int num = (int) new FormCall(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["phonenumber"].Value.ToString()).ShowDialog();
    }

    private void smsToAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormSendSMS formSendSms = new FormSendSMS();
      formSendSms.LoadNotice(this.dtLedger, "cid", "cphone", new List<string>()
      {
        "Cid",
        "CPhone",
        "CName"
      });
      int num = (int) formSendSms.ShowDialog();
    }

    private void smsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cphone"].Value.ToString() != ""))
        return;
      FormSendSMS formSendSms = new FormSendSMS();
      List<string> FieldToBind = new List<string>();
      this.dtSms.Rows.Clear();
      this.dtSms.Rows.Add((object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString(), (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Customer Name And Address"].Value.ToString(), (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["cphone"].Value.ToString());
      FieldToBind.Add("Cid");
      FieldToBind.Add("CPhone");
      FieldToBind.Add("CName");
      formSendSms.LoadNotice(this.dtSms, "cid", "cphone", FieldToBind);
      int num = (int) formSendSms.ShowDialog();
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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "Ledger").ShowDialog();
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxFromDate.Select();
    }

    private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
    {
    }

    private void checkBoxClicked(object sender, EventArgs e)
    {
      if (this.cbCode.Checked || this.cbName.Checked || this.cbNo.Checked || this.cbAddress1.Checked || this.cbAddress2.Checked || this.cbLocation.Checked || this.cbCity.Checked || this.cbPincode.Checked || this.cbMobileNumber.Checked)
        return;
      this.cbName.Checked = true;
    }

    private string getNameAndADdress()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.cbCode.Checked)
        stringBuilder.Append("CustomerCode+' '+");
      if (this.cbName.Checked)
        stringBuilder.Append("CustomerName+' '+");
      if (this.cbNo.Checked)
        stringBuilder.Append("DoorNumber+' '+");
      if (this.cbAddress1.Checked)
        stringBuilder.Append("Addr1+' '+");
      if (this.cbAddress2.Checked)
        stringBuilder.Append("Addr2+' '+");
      if (this.cbLocation.Checked)
        stringBuilder.Append("Addr3+' '+");
      if (this.cbCity.Checked)
        stringBuilder.Append("City+' '+");
      if (this.cbPincode.Checked)
        stringBuilder.Append("Pincode+' '+");
      if (this.cbMobileNumber.Checked)
        stringBuilder.Append("PhoneNumber+' '+");
      if (stringBuilder.Length > 4)
      {
        stringBuilder.Remove(stringBuilder.Length - 5, 5);
        stringBuilder.Append(" as [NameAndAddress] ");
      }
      return stringBuilder.ToString();
    }

    private void tbxFromDate_TextChanged_1(object sender, EventArgs e) => this.SHOW();

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
      int num = (int) new FormColumnOrder("LedgerScreen").ShowDialog();
      this.Close();
    }

    private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbFilterBy.Text == "BILL NUMBER")
      {
        ((Control) this.hpFromDate).Visible = false;
        ((Control) this.hpToDate).Visible = false;
        ((Control) this.hpFromBillNumber).Visible = true;
        ((Control) this.hpToBillNumber).Visible = true;
        this.SHOW();
      }
      else
      {
        if (!(this.cbFilterBy.Text == "DATE"))
          return;
        ((Control) this.hpFromBillNumber).Visible = false;
        ((Control) this.hpToBillNumber).Visible = false;
        ((Control) this.hpFromDate).Visible = true;
        ((Control) this.hpToDate).Visible = true;
        this.SHOW();
      }
    }

    private void tbxToBillNumber_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void tbxFromBillNumber_TextChanged(object sender, EventArgs e) => this.SHOW();

    private void cbType_SelectedIndexChanged(object sender, EventArgs e) => this.SHOW();

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
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.changeColumnOrderToolStripMenuItem = new ToolStripMenuItem();
      this.hpFromDate = new HeaderPanel();
      this.tbxFromDate = new TextBox();
      this.glassButton10 = new GlassButton();
      this.glassButton11 = new GlassButton();
      this.hpToDate = new HeaderPanel();
      this.tbxToDate = new TextBox();
      this.glassButton14 = new GlassButton();
      this.glassButton15 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.cbLedgerType = new ComboBox();
      this.btnPrint = new GlassButton();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.dataGridView1 = new DataGridView();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.cbAddress2 = new CheckBox();
      this.cbMobileNumber = new CheckBox();
      this.cbName = new CheckBox();
      this.cbAddress1 = new CheckBox();
      this.cbPincode = new CheckBox();
      this.cbLocation = new CheckBox();
      this.cbCode = new CheckBox();
      this.cbCity = new CheckBox();
      this.cbNo = new CheckBox();
      this.hpToBillNumber = new HeaderPanel();
      this.tbxToBillNumber = new TextBox();
      this.glassButton1 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.hpFromBillNumber = new HeaderPanel();
      this.tbxFromBillNumber = new TextBox();
      this.glassButton7 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.cbFilterBy = new ComboBox();
      this.glassButton13 = new GlassButton();
      this.glassButton16 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.cbType = new ComboBox();
      this.glassButton17 = new GlassButton();
      this.glassButton18 = new GlassButton();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.hpFromDate).SuspendLayout();
      ((Control) this.hpToDate).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.hpToBillNumber).SuspendLayout();
      ((Control) this.hpFromBillNumber).SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem,
        (ToolStripItem) this.changeColumnOrderToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 114);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.changeColumnOrderToolStripMenuItem.Name = "changeColumnOrderToolStripMenuItem";
      this.changeColumnOrderToolStripMenuItem.Size = new Size(194, 22);
      this.changeColumnOrderToolStripMenuItem.Text = "Change Column Order";
      this.changeColumnOrderToolStripMenuItem.Click += new EventHandler(this.changeColumnOrderToolStripMenuItem_Click);
      ((Control) this.hpFromDate).BackColor = Color.PowderBlue;
      ((Control) this.hpFromDate).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpFromDate).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpFromDate.BorderColor = SystemColors.HotTrack;
      this.hpFromDate.BorderStyle = BorderStyles.Single;
      this.hpFromDate.CaptionBeginColor = Color.PowderBlue;
      this.hpFromDate.CaptionEndColor = Color.AliceBlue;
      this.hpFromDate.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpFromDate.CaptionHeight = 22;
      this.hpFromDate.CaptionPosition = CaptionPositions.Top;
      this.hpFromDate.CaptionText = "FROM DATE";
      this.hpFromDate.CaptionVisible = true;
      ((Control) this.hpFromDate).Controls.Add((Control) this.tbxFromDate);
      ((Control) this.hpFromDate).Controls.Add((Control) this.glassButton10);
      ((Control) this.hpFromDate).Controls.Add((Control) this.glassButton11);
      ((Control) this.hpFromDate).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpFromDate).ForeColor = Color.DarkBlue;
      this.hpFromDate.GradientDirection = LinearGradientMode.Vertical;
      this.hpFromDate.GradientEnd = SystemColors.ControlLight;
      this.hpFromDate.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpFromDate).Location = new Point(437, 3);
      ((Control) this.hpFromDate).Name = "hpFromDate";
      this.hpFromDate.PanelIcon = (Icon) null;
      this.hpFromDate.PanelIconVisible = false;
      ((Control) this.hpFromDate).Size = new Size(136, 58);
      ((Control) this.hpFromDate).TabIndex = 91;
      this.hpFromDate.TextAntialias = true;
      this.tbxFromDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxFromDate.BackColor = Color.Azure;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(4, 3);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size((int) sbyte.MaxValue, 29);
      this.tbxFromDate.TabIndex = 2;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged_1);
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
      ((Control) this.glassButton10).Location = new Point(-159, 513);
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
      ((Control) this.glassButton11).Location = new Point(-25, 512);
      ((Control) this.glassButton11).Name = "glassButton11";
      this.glassButton11.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton11.ShineColor = Color.Transparent;
      ((Control) this.glassButton11).Size = new Size(123, 37);
      ((Control) this.glassButton11).TabIndex = 1;
      ((Control) this.glassButton11).Text = "&EXIT";
      ((ButtonBase) this.glassButton11).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.hpToDate).BackColor = Color.PowderBlue;
      ((Control) this.hpToDate).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpToDate).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpToDate.BorderColor = SystemColors.HotTrack;
      this.hpToDate.BorderStyle = BorderStyles.Single;
      this.hpToDate.CaptionBeginColor = Color.PowderBlue;
      this.hpToDate.CaptionEndColor = Color.AliceBlue;
      this.hpToDate.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpToDate.CaptionHeight = 22;
      this.hpToDate.CaptionPosition = CaptionPositions.Top;
      this.hpToDate.CaptionText = "TO DATE";
      this.hpToDate.CaptionVisible = true;
      ((Control) this.hpToDate).Controls.Add((Control) this.tbxToDate);
      ((Control) this.hpToDate).Controls.Add((Control) this.glassButton14);
      ((Control) this.hpToDate).Controls.Add((Control) this.glassButton15);
      ((Control) this.hpToDate).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpToDate).ForeColor = Color.DarkBlue;
      this.hpToDate.GradientDirection = LinearGradientMode.Vertical;
      this.hpToDate.GradientEnd = SystemColors.ControlLight;
      this.hpToDate.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpToDate).Location = new Point(581, 3);
      ((Control) this.hpToDate).Name = "hpToDate";
      this.hpToDate.PanelIcon = (Icon) null;
      this.hpToDate.PanelIconVisible = false;
      ((Control) this.hpToDate).Size = new Size(136, 58);
      ((Control) this.hpToDate).TabIndex = 92;
      this.hpToDate.TextAntialias = true;
      this.tbxToDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxToDate.BackColor = Color.Azure;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(4, 3);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size((int) sbyte.MaxValue, 29);
      this.tbxToDate.TabIndex = 3;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged_1);
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
      ((Control) this.glassButton14).Location = new Point(-161, 513);
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
      ((Control) this.glassButton15).Location = new Point(-27, 512);
      ((Control) this.glassButton15).Name = "glassButton15";
      this.glassButton15.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton15.ShineColor = Color.Transparent;
      ((Control) this.glassButton15).Size = new Size(123, 37);
      ((Control) this.glassButton15).TabIndex = 1;
      ((Control) this.glassButton15).Text = "&EXIT";
      ((ButtonBase) this.glassButton15).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.headerPanel3).Controls.Add((Control) this.cbLedgerType);
      ((Control) this.headerPanel3).Controls.Add((Control) this.btnPrint);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = Color.Azure;
      this.headerPanel3.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel3).Location = new Point(694, 64);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(311, 52);
      ((Control) this.headerPanel3).TabIndex = 90;
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
      ((Control) this.glassButton4).Location = new Point(16, 513);
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
      ((Control) this.glassButton5).Location = new Point(150, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbLedgerType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbLedgerType.BackColor = Color.AliceBlue;
      this.cbLedgerType.DropDownWidth = 600;
      this.cbLedgerType.FormattingEnabled = true;
      this.cbLedgerType.Location = new Point(3, 3);
      this.cbLedgerType.Name = "cbLedgerType";
      this.cbLedgerType.Size = new Size(237, 23);
      this.cbLedgerType.TabIndex = 23;
      ((Control) this.btnPrint).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrint.BackColor = Color.LightBlue;
      this.btnPrint.FadeOnFocus = true;
      ((Control) this.btnPrint).Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnPrint.ForeColor = Color.MediumBlue;
      this.btnPrint.ForeColorOnFocus = Color.Red;
      this.btnPrint.ForeColorOnLeave = Color.RoyalBlue;
      this.btnPrint.GlowColor = Color.White;
      this.btnPrint.InnerBorderColor = Color.Transparent;
      ((Control) this.btnPrint).Location = new Point(241, 1);
      ((Control) this.btnPrint).Name = "btnPrint";
      this.btnPrint.OuterBorderColor = Color.MediumSlateBlue;
      this.btnPrint.ShineColor = Color.Transparent;
      ((Control) this.btnPrint).Size = new Size(65, 26);
      ((Control) this.btnPrint).TabIndex = 24;
      ((Control) this.btnPrint).Text = "&PRINT";
      ((ButtonBase) this.btnPrint).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnPrint).Click += new EventHandler(this.button3_Click);
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
      ((Control) this.headerPanel7).Size = new Size(267, 58);
      ((Control) this.headerPanel7).TabIndex = 89;
      this.headerPanel7.TextAntialias = true;
      this.cbShopCodes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbShopCodes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbShopCodes.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(0, 6);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(265, 23);
      this.cbShopCodes.TabIndex = 24;
      this.cbShopCodes.SelectedIndexChanged += new EventHandler(this.button1_Click);
      this.cbShopCodes.KeyDown += new KeyEventHandler(this.cbShopCodes_KeyDown);
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
      ((Control) this.glassButton8).Location = new Point(-44, 513);
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
      ((Control) this.glassButton9).Location = new Point(90, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.Location = new Point(3, 120);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(1002, 515);
      this.dataGridView1.TabIndex = 1;
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
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton2);
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
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = Color.Azure;
      this.headerPanel2.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel2).Location = new Point(4, 64);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(686, 52);
      ((Control) this.headerPanel2).TabIndex = 73;
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
      ((Control) this.glassButton2).Location = new Point(393, 513);
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
      ((Control) this.glassButton3).Location = new Point(527, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbAddress2.AutoSize = true;
      this.cbAddress2.BackColor = Color.Transparent;
      this.cbAddress2.Checked = true;
      this.cbAddress2.CheckState = CheckState.Checked;
      this.cbAddress2.Location = new Point(271, 6);
      this.cbAddress2.Name = "cbAddress2";
      this.cbAddress2.Size = new Size(75, 19);
      this.cbAddress2.TabIndex = 11;
      this.cbAddress2.Text = "Address2";
      this.cbAddress2.UseVisualStyleBackColor = false;
      this.cbAddress2.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbMobileNumber.AutoSize = true;
      this.cbMobileNumber.BackColor = Color.Transparent;
      this.cbMobileNumber.Location = new Point(569, 6);
      this.cbMobileNumber.Name = "cbMobileNumber";
      this.cbMobileNumber.Size = new Size(110, 19);
      this.cbMobileNumber.TabIndex = 15;
      this.cbMobileNumber.Text = "Mobile Number";
      this.cbMobileNumber.UseVisualStyleBackColor = false;
      this.cbMobileNumber.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbName.AutoSize = true;
      this.cbName.BackColor = Color.Transparent;
      this.cbName.Checked = true;
      this.cbName.CheckState = CheckState.Checked;
      this.cbName.Location = new Point(120, 6);
      this.cbName.Name = "cbName";
      this.cbName.Size = new Size(58, 19);
      this.cbName.TabIndex = 8;
      this.cbName.Text = "Name";
      this.cbName.UseVisualStyleBackColor = false;
      this.cbName.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbAddress1.AutoSize = true;
      this.cbAddress1.BackColor = Color.Transparent;
      this.cbAddress1.Checked = true;
      this.cbAddress1.CheckState = CheckState.Checked;
      this.cbAddress1.Location = new Point(187, 6);
      this.cbAddress1.Name = "cbAddress1";
      this.cbAddress1.Size = new Size(73, 19);
      this.cbAddress1.TabIndex = 10;
      this.cbAddress1.Text = "Address1";
      this.cbAddress1.UseVisualStyleBackColor = false;
      this.cbAddress1.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbAddress1.Click += new EventHandler(this.checkBoxClicked);
      this.cbPincode.AutoSize = true;
      this.cbPincode.BackColor = Color.Transparent;
      this.cbPincode.Checked = true;
      this.cbPincode.CheckState = CheckState.Checked;
      this.cbPincode.Location = new Point(491, 6);
      this.cbPincode.Name = "cbPincode";
      this.cbPincode.Size = new Size(69, 19);
      this.cbPincode.TabIndex = 14;
      this.cbPincode.Text = "Pincode";
      this.cbPincode.UseVisualStyleBackColor = false;
      this.cbPincode.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbLocation.AutoSize = true;
      this.cbLocation.BackColor = Color.Transparent;
      this.cbLocation.Checked = true;
      this.cbLocation.CheckState = CheckState.Checked;
      this.cbLocation.Location = new Point(355, 6);
      this.cbLocation.Name = "cbLocation";
      this.cbLocation.Size = new Size(72, 19);
      this.cbLocation.TabIndex = 12;
      this.cbLocation.Text = "Location";
      this.cbLocation.UseVisualStyleBackColor = false;
      this.cbLocation.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbCode.AutoSize = true;
      this.cbCode.BackColor = Color.Transparent;
      this.cbCode.Location = new Point(7, 6);
      this.cbCode.Name = "cbCode";
      this.cbCode.Size = new Size(53, 19);
      this.cbCode.TabIndex = 7;
      this.cbCode.Text = "Code";
      this.cbCode.UseVisualStyleBackColor = false;
      this.cbCode.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbCity.AutoSize = true;
      this.cbCity.BackColor = Color.Transparent;
      this.cbCity.Checked = true;
      this.cbCity.CheckState = CheckState.Checked;
      this.cbCity.Location = new Point(436, 6);
      this.cbCity.Name = "cbCity";
      this.cbCity.Size = new Size(46, 19);
      this.cbCity.TabIndex = 13;
      this.cbCity.Text = "City";
      this.cbCity.UseVisualStyleBackColor = false;
      this.cbCity.CheckedChanged += new EventHandler(this.button1_Click);
      this.cbNo.AutoSize = true;
      this.cbNo.BackColor = Color.Transparent;
      this.cbNo.Checked = true;
      this.cbNo.CheckState = CheckState.Checked;
      this.cbNo.Location = new Point(69, 6);
      this.cbNo.Name = "cbNo";
      this.cbNo.Size = new Size(42, 19);
      this.cbNo.TabIndex = 9;
      this.cbNo.Text = "No";
      this.cbNo.UseVisualStyleBackColor = false;
      this.cbNo.CheckedChanged += new EventHandler(this.button1_Click);
      ((Control) this.hpToBillNumber).BackColor = Color.PowderBlue;
      ((Control) this.hpToBillNumber).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpToBillNumber).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpToBillNumber.BorderColor = SystemColors.HotTrack;
      this.hpToBillNumber.BorderStyle = BorderStyles.Single;
      this.hpToBillNumber.CaptionBeginColor = Color.PowderBlue;
      this.hpToBillNumber.CaptionEndColor = Color.AliceBlue;
      this.hpToBillNumber.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpToBillNumber.CaptionHeight = 22;
      this.hpToBillNumber.CaptionPosition = CaptionPositions.Top;
      this.hpToBillNumber.CaptionText = "TO BILL NUMBER";
      this.hpToBillNumber.CaptionVisible = true;
      ((Control) this.hpToBillNumber).Controls.Add((Control) this.tbxToBillNumber);
      ((Control) this.hpToBillNumber).Controls.Add((Control) this.glassButton1);
      ((Control) this.hpToBillNumber).Controls.Add((Control) this.glassButton6);
      ((Control) this.hpToBillNumber).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpToBillNumber).ForeColor = Color.DarkBlue;
      this.hpToBillNumber.GradientDirection = LinearGradientMode.Vertical;
      this.hpToBillNumber.GradientEnd = SystemColors.ControlLight;
      this.hpToBillNumber.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpToBillNumber).Location = new Point(580, 3);
      ((Control) this.hpToBillNumber).Name = "hpToBillNumber";
      this.hpToBillNumber.PanelIcon = (Icon) null;
      this.hpToBillNumber.PanelIconVisible = false;
      ((Control) this.hpToBillNumber).Size = new Size(136, 58);
      ((Control) this.hpToBillNumber).TabIndex = 94;
      this.hpToBillNumber.TextAntialias = true;
      this.tbxToBillNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxToBillNumber.BackColor = Color.Azure;
      this.tbxToBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToBillNumber.Location = new Point(4, 3);
      this.tbxToBillNumber.Name = "tbxToBillNumber";
      this.tbxToBillNumber.Size = new Size(125, 29);
      this.tbxToBillNumber.TabIndex = 3;
      this.tbxToBillNumber.TextChanged += new EventHandler(this.tbxToBillNumber_TextChanged);
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
      ((Control) this.glassButton1).Location = new Point(-163, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(-29, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.hpFromBillNumber).BackColor = Color.PowderBlue;
      ((Control) this.hpFromBillNumber).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.hpFromBillNumber).BackgroundImageLayout = ImageLayout.Stretch;
      this.hpFromBillNumber.BorderColor = SystemColors.HotTrack;
      this.hpFromBillNumber.BorderStyle = BorderStyles.Single;
      this.hpFromBillNumber.CaptionBeginColor = Color.PowderBlue;
      this.hpFromBillNumber.CaptionEndColor = Color.AliceBlue;
      this.hpFromBillNumber.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.hpFromBillNumber.CaptionHeight = 22;
      this.hpFromBillNumber.CaptionPosition = CaptionPositions.Top;
      this.hpFromBillNumber.CaptionText = "FROM BILL NUMBER";
      this.hpFromBillNumber.CaptionVisible = true;
      ((Control) this.hpFromBillNumber).Controls.Add((Control) this.tbxFromBillNumber);
      ((Control) this.hpFromBillNumber).Controls.Add((Control) this.glassButton7);
      ((Control) this.hpFromBillNumber).Controls.Add((Control) this.glassButton12);
      ((Control) this.hpFromBillNumber).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.hpFromBillNumber).ForeColor = Color.DarkBlue;
      this.hpFromBillNumber.GradientDirection = LinearGradientMode.Vertical;
      this.hpFromBillNumber.GradientEnd = SystemColors.ControlLight;
      this.hpFromBillNumber.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.hpFromBillNumber).Location = new Point(436, 3);
      ((Control) this.hpFromBillNumber).Name = "hpFromBillNumber";
      this.hpFromBillNumber.PanelIcon = (Icon) null;
      this.hpFromBillNumber.PanelIconVisible = false;
      ((Control) this.hpFromBillNumber).Size = new Size(136, 58);
      ((Control) this.hpFromBillNumber).TabIndex = 93;
      this.hpFromBillNumber.TextAntialias = true;
      this.tbxFromBillNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxFromBillNumber.BackColor = Color.Azure;
      this.tbxFromBillNumber.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromBillNumber.Location = new Point(4, 3);
      this.tbxFromBillNumber.Name = "tbxFromBillNumber";
      this.tbxFromBillNumber.Size = new Size(125, 29);
      this.tbxFromBillNumber.TabIndex = 2;
      this.tbxFromBillNumber.TextChanged += new EventHandler(this.tbxFromBillNumber_TextChanged);
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
      ((Control) this.glassButton7).Location = new Point(-161, 513);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(128, 35);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&SAVE";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton12).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton12.BackColor = Color.LightBlue;
      this.glassButton12.FadeOnFocus = true;
      ((Control) this.glassButton12).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton12.ForeColor = Color.MediumBlue;
      this.glassButton12.ForeColorOnFocus = Color.Red;
      this.glassButton12.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton12.GlowColor = Color.White;
      this.glassButton12.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton12).Location = new Point(-27, 512);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(123, 37);
      ((Control) this.glassButton12).TabIndex = 1;
      ((Control) this.glassButton12).Text = "&EXIT";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel5.CaptionText = "FILTER BY";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.cbFilterBy);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton16);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(276, 3);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(155, 58);
      ((Control) this.headerPanel5).TabIndex = 95;
      this.headerPanel5.TextAntialias = true;
      this.cbFilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbFilterBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbFilterBy.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbFilterBy.BackColor = Color.AliceBlue;
      this.cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbFilterBy.DropDownWidth = 600;
      this.cbFilterBy.Font = new Font("Arial Rounded MT Bold", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbFilterBy.FormattingEnabled = true;
      this.cbFilterBy.Items.AddRange(new object[2]
      {
        (object) "DATE",
        (object) "BILL NUMBER"
      });
      this.cbFilterBy.Location = new Point(3, 4);
      this.cbFilterBy.Name = "cbFilterBy";
      this.cbFilterBy.Size = new Size(148, 26);
      this.cbFilterBy.TabIndex = 24;
      this.cbFilterBy.SelectedIndexChanged += new EventHandler(this.cbFilterBy_SelectedIndexChanged);
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
      ((Control) this.glassButton13).Location = new Point(-158, 513);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(128, 35);
      ((Control) this.glassButton13).TabIndex = 0;
      ((Control) this.glassButton13).Text = "&SAVE";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton16).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton16.BackColor = Color.LightBlue;
      this.glassButton16.FadeOnFocus = true;
      ((Control) this.glassButton16).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton16.ForeColor = Color.MediumBlue;
      this.glassButton16.ForeColorOnFocus = Color.Red;
      this.glassButton16.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton16.GlowColor = Color.White;
      this.glassButton16.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton16).Location = new Point(-24, 512);
      ((Control) this.glassButton16).Name = "glassButton16";
      this.glassButton16.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton16.ShineColor = Color.Transparent;
      ((Control) this.glassButton16).Size = new Size(123, 37);
      ((Control) this.glassButton16).TabIndex = 1;
      ((Control) this.glassButton16).Text = "&EXIT";
      ((ButtonBase) this.glassButton16).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel1.CaptionText = "TYPE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbType);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton17);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton18);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(719, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(155, 58);
      ((Control) this.headerPanel1).TabIndex = 96;
      this.headerPanel1.TextAntialias = true;
      this.cbType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cbType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbType.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbType.BackColor = Color.AliceBlue;
      this.cbType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbType.DropDownWidth = 600;
      this.cbType.Font = new Font("Arial Rounded MT Bold", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[2]
      {
        (object) "1",
        (object) "2"
      });
      this.cbType.Location = new Point(3, 4);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(146, 26);
      this.cbType.TabIndex = 24;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
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
      ((Control) this.glassButton17).Location = new Point(-160, 513);
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
      ((Control) this.glassButton18).Location = new Point(-26, 512);
      ((Control) this.glassButton18).Name = "glassButton18";
      this.glassButton18.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton18.ShineColor = Color.Transparent;
      ((Control) this.glassButton18).Size = new Size(123, 37);
      ((Control) this.glassButton18).TabIndex = 1;
      ((Control) this.glassButton18).Text = "&EXIT";
      ((ButtonBase) this.glassButton18).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.hpToBillNumber);
      this.Controls.Add((Control) this.hpFromBillNumber);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.hpToDate);
      this.Controls.Add((Control) this.hpFromDate);
      this.Controls.Add((Control) this.headerPanel7);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormLedger);
      this.Text = "Ledger";
      this.Load += new EventHandler(this.Ledger_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.hpFromDate).ResumeLayout(false);
      ((Control) this.hpFromDate).PerformLayout();
      ((Control) this.hpToDate).ResumeLayout(false);
      ((Control) this.hpToDate).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      ((Control) this.hpToBillNumber).ResumeLayout(false);
      ((Control) this.hpToBillNumber).PerformLayout();
      ((Control) this.hpFromBillNumber).ResumeLayout(false);
      ((Control) this.hpFromBillNumber).PerformLayout();
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
