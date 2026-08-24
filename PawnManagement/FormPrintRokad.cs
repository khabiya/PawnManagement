
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPrintRokad : Form
  {
    private ReportDocument rd = new ReportDocument();
    private DataTable dtrefreshGrid = new DataTable();
    private string rokadDate = "";
    private IContainer components = (IContainer) null;
    private CrystalReportViewer crystalReportViewer1;
    private ComboBox comboBox1;
    private TextBox tbxToDate;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton4;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private ListBox listBox1;
    private GlassButton glassButton13;
    private GlassButton glassButton12;
    private TextBox tbxDate;
    private HeaderPanel headerPanel7;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton1;
    private GlassButton glassButton7;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem fromToolStripMenuItem;
    private ToolStripMenuItem toToolStripMenuItem;

    public FormPrintRokad() => this.InitializeComponent();

    public FormPrintRokad(string ROkADDATE)
    {
      this.rokadDate = ROkADDATE;
      this.InitializeComponent();
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.getRokad();

    private void getRokad()
    {
      if (this.tbxToDate.Text == "")
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxDate.Text))
        {
          if (!PawnManagementClass.checkIfRokadFinished(this.tbxDate.Text))
            return;
          this.printRokad(DateTime.Parse(this.tbxDate.Text));
        }
        else
        {
          this.tbxDate.Select();
          this.tbxDate.ForeColor = Color.Red;
        }
      }
      else if (PawnManagementClass.checkForValidateDate(this.tbxDate.Text.Trim().ToString()))
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.Trim().ToString()))
        {
          if (this.checkIfRokadFinishedForThatDate(this.tbxDate.Text.Trim().ToString(), this.tbxToDate.Text.Trim().ToString()))
          {
            this.printRokadBetween(DateTime.Parse(this.tbxDate.Text.Trim()), DateTime.Parse(this.tbxToDate.Text.Trim()));
          }
          else
          {
            int num = (int) MessageBox.Show("Check rokad Date");
            this.crystalReportViewer1.ReportSource = (object) null;
          }
        }
        else
        {
          this.tbxToDate.Select();
          this.tbxToDate.ForeColor = Color.Red;
        }
      }
      else
      {
        this.tbxDate.Select();
        this.tbxDate.ForeColor = Color.Red;
      }
    }

    private void printRokad(DateTime d1)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = new DataTable();
      DataTable dataTable4;
      try
      {
        string strError = "";
        dataTable4 = SQLHelper.GetDataTable("select * from tblRokadDetails where rokaddate = @rokaddate", new List<OleDbParameter>()
        {
          new OleDbParameter("rokaddate", (object) d1.ToString("dd/MM/yyyy"))
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      DataTable dataTable5;
      try
      {
        string strError = "";
        dataTable5 = SQLHelper.GetDataTable("select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1' and jammaornovae = 'jamma' and voucherdate = @VoucherDate) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by vouchernumber", new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate", (object) d1.ToString("dd/MM/yyyy"))
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      DataTable dataTable6;
      try
      {
        string strError = "";
        dataTable6 = SQLHelper.GetDataTable("select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1' and jammaornovae = 'novae' and voucherdate = @VoucherDate) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by vouchernumber", new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate", (object) d1.ToString("dd/MM/yyyy"))
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      this.rd.Load(this.comboBox1.Text);
      this.rd.SetDataSource(dataTable4);
      this.rd.Subreports["ReportBalanceSheetJamma.rpt"].SetDataSource(dataTable5);
      this.rd.Subreports["ReportBalanceSheetNovae.rpt"].SetDataSource(dataTable6);
      this.crystalReportViewer1.ReportSource = (object) this.rd;
      ((Control) this.crystalReportViewer1).Show();
    }

    private void printRokadBetween(DateTime d1, DateTime d2)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = new DataTable();
      DataTable dataTable4;
      try
      {
        dataTable4 = new DataTable()
        {
          Columns = {
            {
              "RokadDate",
              typeof (DateTime)
            },
            {
              "OpeningBalance",
              typeof (string)
            },
            {
              "Cash",
              typeof (string)
            }
          },
          Rows = {
            new object[0]
          }
        };
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      DataTable dataTable5;
      try
      {
        string strError = "";
        dataTable5 = SQLHelper.GetDataTable("select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1' and jammaornovae = 'jamma' and voucherdate between @VoucherDate1 and @VoucherDate2) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by vouchernumber", new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate1", (object) d1),
          new OleDbParameter("VoucherDate2", (object) d2)
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      DataTable dataTable6;
      try
      {
        string strError = "";
        dataTable6 = SQLHelper.GetDataTable("select t3.voucherdate,t3.vouchernumber,t3.vouchercode,t3.vouchername,t3.voucherdescription,t3.amount,t3.ledgercode,t4.ledgertype,t4.ledgertypeinhindi from (select t1.voucherdate,t1.vouchernumber,t1.vouchercode,t2.vouchername,t1.voucherdescription,t1.ledgercode,t1.amount from tblvouchers t1 left join tblVoucherMaster t2 on t1.vouchercode = t2.vouchercode where t1.active = '1' and jammaornovae = 'novae' and voucherdate between @VoucherDate1 and @VoucherDate2) as t3 left join tblledgerr t4 on t3.ledgercode = t4.ledgercode order by vouchernumber", new List<OleDbParameter>()
        {
          new OleDbParameter("VoucherDate1", (object) d1),
          new OleDbParameter("VoucherDate2", (object) d2)
        }, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form printRokad.glassButton1_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      this.rd.Load(this.comboBox1.Text);
      this.rd.SetDataSource(dataTable4);
      this.rd.Subreports["ReportBalanceSheetJamma.rpt"].SetDataSource(dataTable5);
      this.rd.Subreports["ReportBalanceSheetNovae.rpt"].SetDataSource(dataTable6);
      this.crystalReportViewer1.ReportSource = (object) this.rd;
      ((Control) this.crystalReportViewer1).Show();
    }

    private bool checkIfRokadFinishedForThatDate(string fromDate, string toDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where RokadDate >= @fromDate and rokaddate <= @toDate order by rokadDate";
      parameters.Add(new OleDbParameter(nameof (fromDate), (object) fromDate));
      parameters.Add(new OleDbParameter(nameof (toDate), (object) toDate));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form tblVouchers.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching data from table vouchers.\n" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row["RokadFinished"].ToString() != "Y")
            return false;
        }
        return true;
      }
      return false;
    }

    private string getOpeningBalance(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form printrokad.getopeneingbalance", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form print rokad .getopeneingbalance \n" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        return dataTable.Rows[0]["OpeningBalance"].ToString();
      return "0";
    }

    private string getCashBalance(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form printrokad.getopeneingbalance", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form printrokad.getopeneingbalance \n" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        return dataTable.Rows[0]["Cash"].ToString();
      return "0";
    }

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPrintRokad_Load(object sender, EventArgs e)
    {
      this.getReportTypes();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      this.comboBox1.Text = File.ReadAllLines("Reports\\Rokad\\LastUsed.txt")[0].ToString();
      this.refresh();
      this.tbxDate.Select();
      if (!(this.rokadDate != ""))
        return;
      this.tbxDate.Text = this.rokadDate;
      this.tbxToDate.Text = this.rokadDate;
    }

    private void refresh()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select * from tblRokadDetails where RokadFinished = 'Y' order by RokadDate", ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("refreshGrid() Error in fetching the ledgerr details .\n" + strError);
      }
      else if (this.dtrefreshGrid != null && this.dtrefreshGrid.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dtrefreshGrid.Rows)
          this.listBox1.Items.Add((object) DateTime.Parse(row["RokadDate"].ToString()).ToString("dd/MM/yyyy"));
      }
    }

    private void getReportTypes()
    {
      foreach (object file in Directory.GetFiles("Reports\\\\Rokad\\\\", "*.rpt"))
        this.comboBox1.Items.Add(file);
    }

    private void getRokadPrintFormats()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select * from tblprintsettings", ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("form printRokad.getrokadprintformats" + strError);
        PawnManagementClass.InsertIntoException("form printRokad.getrokadprintformats", strError, FormMain.username, DateTime.Now.ToString());
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row["rokadPrintformats"].ToString() != "")
            this.comboBox1.Items.Add((object) row["rokadPrintformats"].ToString());
        }
      }
    }

    private void comboBox1_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void tbxDate_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return || !PawnManagementClass.checkForValidateDate(this.tbxDate.Text))
        return;
      this.tbxToDate.Select();
    }

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.comboBox1.Focus();
    }

    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.glassButton2).Focus();
    }

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void glassButton6_Click(object sender, EventArgs e)
    {
      this.crystalReportViewer1.PrintReport();
      File.WriteAllText("Reports\\\\Rokad\\\\LastUsed.txt", this.comboBox1.Text);
    }

    private void listBox1_Click(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tbxDate.Text.Length == 10)
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxDate.Text))
        {
          this.tbxDate.ForeColor = Color.Black;
          if (this.tbxToDate.Text.Length == 10)
          {
            if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
            {
              this.tbxToDate.ForeColor = Color.Black;
              this.getRokad();
            }
            else
            {
              this.tbxToDate.ForeColor = Color.Red;
              this.tbxToDate.Select();
            }
          }
          else
          {
            this.tbxToDate.ForeColor = Color.Red;
            this.tbxToDate.Select();
          }
        }
        else
        {
          this.tbxDate.ForeColor = Color.Red;
          this.tbxDate.Select();
        }
      }
      else
      {
        this.tbxDate.ForeColor = Color.Red;
        this.tbxDate.Select();
      }
    }

    private void tbxToDate_TextChanged(object sender, EventArgs e)
    {
      if (this.tbxDate.Text.Length == 10)
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxDate.Text))
        {
          this.tbxDate.ForeColor = Color.Black;
          if (this.tbxToDate.Text.Length == 10)
          {
            if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
            {
              this.tbxToDate.ForeColor = Color.Black;
              this.getRokad();
            }
            else
            {
              this.tbxToDate.ForeColor = Color.Red;
              this.tbxToDate.Select();
            }
          }
          else
          {
            this.tbxToDate.ForeColor = Color.Red;
            this.tbxToDate.Select();
          }
        }
        else
        {
          this.tbxDate.ForeColor = Color.Red;
          this.tbxDate.Select();
        }
      }
      else
      {
        this.tbxDate.ForeColor = Color.Red;
        this.tbxDate.Select();
      }
    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
    }

    private void fromToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.tbxDate.Text = DateTime.Parse(this.listBox1.SelectedItem.ToString()).ToString("dd/MM/yyyy");
      this.tbxToDate.Text = DateTime.Parse(this.listBox1.SelectedItem.ToString()).ToString("dd/MM/yyyy");
      this.getRokad();
    }

    private void toToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.tbxToDate.Text = DateTime.Parse(this.listBox1.SelectedItem.ToString()).ToString("dd/MM/yyyy");
      this.getRokad();
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
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.comboBox1 = new ComboBox();
      this.tbxToDate = new TextBox();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton4 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.listBox1 = new ListBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.fromToolStripMenuItem = new ToolStripMenuItem();
      this.toToolStripMenuItem = new ToolStripMenuItem();
      this.glassButton13 = new GlassButton();
      this.glassButton12 = new GlassButton();
      this.tbxDate = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton7 = new GlassButton();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.SuspendLayout();
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((Control) this.crystalReportViewer1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Location = new Point(174, 63);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(831, 567);
      ((Control) this.crystalReportViewer1).TabIndex = 4;
      this.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
      this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.comboBox1.BackColor = SystemColors.Control;
      this.comboBox1.Dock = DockStyle.Fill;
      this.comboBox1.DropDownWidth = 700;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(0, 0);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(381, 24);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.comboBox1.KeyDown += new KeyEventHandler(this.comboBox1_KeyDown);
      this.comboBox1.KeyPress += new KeyPressEventHandler(this.comboBox1_KeyPress);
      this.comboBox1.KeyUp += new KeyEventHandler(this.comboBox1_KeyUp);
      this.tbxToDate.BorderStyle = BorderStyle.None;
      this.tbxToDate.Dock = DockStyle.Fill;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(0, 0);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(158, 24);
      this.tbxToDate.TabIndex = 1;
      this.tbxToDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = SystemColors.ControlLight;
      this.headerPanel1.CaptionEndColor = SystemColors.Info;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "TO  DATE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxToDate);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(341, 6);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(160, 51);
      ((Control) this.headerPanel1).TabIndex = 79;
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
      ((Control) this.glassButton2).Location = new Point(-139, 513);
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
      ((Control) this.glassButton3).Location = new Point(-5, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 1;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.Desktop;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = SystemColors.Control;
      this.headerPanel2.CaptionEndColor = SystemColors.Control;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "SELECT FORMAT";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel2).Controls.Add((Control) this.comboBox1);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(507, 6);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(383, 51);
      ((Control) this.headerPanel2).TabIndex = 80;
      this.headerPanel2.TextAntialias = true;
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
      ((Control) this.glassButton4).Location = new Point(82, 513);
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
      ((Control) this.glassButton5).Location = new Point(216, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.DarkBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(896, 6);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(109, 51);
      ((Control) this.glassButton6).TabIndex = 81;
      ((Control) this.glassButton6).Text = "&Print";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Click += new EventHandler(this.glassButton6_Click);
      this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 24;
      this.listBox1.Location = new Point(0, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(162, 600);
      this.listBox1.TabIndex = 0;
      this.listBox1.Click += new EventHandler(this.listBox1_Click);
      this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.fromToolStripMenuItem,
        (ToolStripItem) this.toToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(103, 48);
      this.fromToolStripMenuItem.Name = "fromToolStripMenuItem";
      this.fromToolStripMenuItem.Size = new Size(102, 22);
      this.fromToolStripMenuItem.Text = "From";
      this.fromToolStripMenuItem.Click += new EventHandler(this.fromToolStripMenuItem_Click);
      this.toToolStripMenuItem.Name = "toToolStripMenuItem";
      this.toToolStripMenuItem.Size = new Size(102, 22);
      this.toToolStripMenuItem.Text = "To";
      this.toToolStripMenuItem.Click += new EventHandler(this.toToolStripMenuItem_Click);
      ((Control) this.glassButton13).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton13.BackColor = Color.LightBlue;
      this.glassButton13.FadeOnFocus = true;
      ((Control) this.glassButton13).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton13.ForeColor = Color.MediumBlue;
      this.glassButton13.ForeColorOnFocus = Color.Red;
      this.glassButton13.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton13.GlowColor = Color.White;
      this.glassButton13.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton13).Location = new Point(-5, 512);
      ((Control) this.glassButton13).Name = "glassButton13";
      this.glassButton13.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton13.ShineColor = Color.Transparent;
      ((Control) this.glassButton13).Size = new Size(123, 37);
      ((Control) this.glassButton13).TabIndex = 1;
      ((Control) this.glassButton13).Text = "&EXIT";
      ((ButtonBase) this.glassButton13).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      ((Control) this.glassButton12).Location = new Point(-139, 513);
      ((Control) this.glassButton12).Name = "glassButton12";
      this.glassButton12.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton12.ShineColor = Color.Transparent;
      ((Control) this.glassButton12).Size = new Size(128, 35);
      ((Control) this.glassButton12).TabIndex = 0;
      ((Control) this.glassButton12).Text = "&SAVE";
      ((ButtonBase) this.glassButton12).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxDate.BorderStyle = BorderStyle.None;
      this.tbxDate.Dock = DockStyle.Fill;
      this.tbxDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDate.Location = new Point(0, 0);
      this.tbxDate.Name = "tbxDate";
      this.tbxDate.Size = new Size(158, 24);
      this.tbxDate.TabIndex = 0;
      this.tbxDate.TextChanged += new EventHandler(this.tbxToDate_TextChanged);
      this.tbxDate.KeyUp += new KeyEventHandler(this.tbxDate_KeyUp);
      ((Control) this.headerPanel7).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel7).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel7.BorderColor = SystemColors.HotTrack;
      this.headerPanel7.BorderStyle = BorderStyles.Single;
      this.headerPanel7.CaptionBeginColor = SystemColors.ButtonFace;
      this.headerPanel7.CaptionEndColor = SystemColors.ButtonHighlight;
      this.headerPanel7.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.CaptionHeight = 22;
      this.headerPanel7.CaptionPosition = CaptionPositions.Top;
      this.headerPanel7.CaptionText = "FROM  DATE";
      this.headerPanel7.CaptionVisible = true;
      ((Control) this.headerPanel7).Controls.Add((Control) this.tbxDate);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton12);
      ((Control) this.headerPanel7).Controls.Add((Control) this.glassButton13);
      ((Control) this.headerPanel7).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel7).ForeColor = Color.DarkBlue;
      this.headerPanel7.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel7.GradientEnd = SystemColors.ControlLight;
      this.headerPanel7.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel7).Location = new Point(175, 6);
      ((Control) this.headerPanel7).Name = "headerPanel7";
      this.headerPanel7.PanelIcon = (Icon) null;
      this.headerPanel7.PanelIconVisible = false;
      ((Control) this.headerPanel7).Size = new Size(160, 51);
      ((Control) this.headerPanel7).TabIndex = 78;
      this.headerPanel7.TextAntialias = true;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = SystemColors.ButtonFace;
      this.headerPanel3.CaptionEndColor = SystemColors.ButtonHighlight;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "FROM  DATE";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.listBox1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(6, 6);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(164, 624);
      ((Control) this.headerPanel3).TabIndex = 83;
      this.headerPanel3.TextAntialias = true;
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
      ((Control) this.glassButton1).Location = new Point(-137, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(-3, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 1;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel3);
      this.Controls.Add((Control) this.glassButton6);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel7);
      this.Controls.Add((Control) this.crystalReportViewer1);
      this.Name = nameof (FormPrintRokad);
      this.Text = nameof (FormPrintRokad);
      this.Load += new EventHandler(this.FormPrintRokad_Load);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel7).ResumeLayout(false);
      ((Control) this.headerPanel7).PerformLayout();
      ((Control) this.headerPanel3).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
