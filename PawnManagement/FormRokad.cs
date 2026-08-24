
using ControlTreeView;
using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormRokad : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\bluelight.jpg");
    private string adminPassword = "";
    private DataTable dtNovaeLedger = new DataTable();
    private DataTable dtJammaLedger = new DataTable();
    private DataTable dtMainVouchers = new DataTable();
    private DateTime rokadDate;
    private DateTime fromDate;
    private DateTime toDate;
    private bool clickedOnce = false;
    private string formType = "";
    private IContainer components = (IContainer) null;
    private PrintDialog printDialog1;
    private ColouredTextBox te;
    private TextBox msdnColouredTextBox1;
    private TextBox msdnColouredTextBox2;
    private TextBox textBox1;
    private TextBox msdnColouredTextBox3;
    private CTreeView ctvNovae;
    private CTreeView ctvJamma;
    private TextBox tbxNovae;
    private TextBox tbxJamma;
    private TextBox tbxCash;
    private TextBox tbxOpeningBalance;
    private TextBox tbxRokadDate;
    private GlassButton btnAddEntry;
    private ContextMenuStrip cmsDataGridView;
    private ComboBox comboBox1;
    private GlassButton btnFinishRokad;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ContextMenuStrip cmsTextBoxJamma;
    private ToolStripMenuItem toolStripMenuItem1;
    private ContextMenuStrip cmsTextBoxNovae;
    private ToolStripMenuItem toolStripMenuItem3;
    private TableLayoutPanel tableLayoutPanel1;
    private CheckBox chbExpandFully;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private GlassButton glassButton1;
    private ContextMenuStrip cmsJamma;
    private ToolStripMenuItem toolStripMenuItem2;
    private ContextMenuStrip cmsNovae;
    private ToolStripMenuItem toolStripMenuItem4;
    private GlassButton glassButton2;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private HeaderPanel headerPanel5;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormRokad() => this.InitializeComponent();

    public FormRokad(DateTime ROKADDATE, string FORMTYPE)
    {
      this.rokadDate = ROKADDATE;
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    public FormRokad(DateTime FROM, DateTime TO, string FORMTYPE)
    {
      this.fromDate = FROM;
      this.toDate = TO;
      this.formType = FORMTYPE;
      this.InitializeComponent();
    }

    private void refreshGridNovae()
    {
      string strError = "";
      string my_querry = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.formType == "singleDay")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode,sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'novae' and voucherdate = @voucherDate and active = '1' group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("VoucherDate", (object) this.rokadDate));
      }
      if (this.formType == "currentDay")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode,sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'novae' and voucherdate = @voucherDate  and active  = '1' group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("VoucherDate", (object) this.rokadDate));
      }
      if (this.formType == "betweenDays")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode , sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'novae' and ( voucherdate >= @date1 and voucherdate <= @date2) and active = '1'  group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("date1", (object) this.fromDate));
        parameters.Add(new OleDbParameter("date2", (object) this.toDate));
      }
      this.dtNovaeLedger = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    private void refreshGridJamma()
    {
      string strError = "";
      string my_querry = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      if (this.formType == "singleDay")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode,sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'jamma' and voucherdate = @voucherDate and active = '1' group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("VoucherDate", (object) this.rokadDate));
      }
      if (this.formType == "currentDay")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode,sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'jamma' and voucherdate = @voucherDate and active = '1' group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("VoucherDate", (object) this.rokadDate));
      }
      if (this.formType == "betweenDays")
      {
        my_querry = "select t1.ledgercode,t1.novaesum,t2.ledgertype,t2.ledgertypeinhindi  from  (SELECT ledgercode ,sum(amount) as novaesum FROM tblvouchers WHERE jammaornovae = 'jamma' and ( voucherdate >= @date1 and voucherdate <= @date2) and active = '1' group by ledgercode) as t1 left join tblledgerr t2  on t1.ledgercode = t2.ledgercode";
        parameters.Add(new OleDbParameter("date1", (object) this.fromDate));
        parameters.Add(new OleDbParameter("date2", (object) this.toDate));
      }
      this.dtJammaLedger = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    private void loadForm()
    {
      if (this.formType == "singleDay")
      {
        this.tbxRokadDate.Text = this.rokadDate.ToString("dd/MM/yyyy");
        this.refreshGridJamma();
        this.refreshGridNovae();
        this.tbxOpeningBalance.Text = RokadDetailsClass.getOpeningBalance(this.rokadDate);
        ((Control) this.btnFinishRokad).Visible = false;
        ((Control) this.btnAddEntry).Visible = false;
        this.tbxOpeningBalance.ReadOnly = true;
        this.cmsDataGridView.Enabled = true;
        this.cmsTextBoxJamma.Enabled = false;
        this.cmsTextBoxNovae.Enabled = false;
      }
      else if (this.formType == "betweenDays")
      {
        this.chbExpandFully.Visible = true;
        this.chbExpandFully.Checked = false;
        this.tbxRokadDate.Text = this.fromDate.ToString("dd/MM/yyyy") + " - " + this.toDate.ToString("dd/MM/yyyy");
        this.refreshGridJamma();
        this.refreshGridNovae();
        RokadDetailsClass.getOpeningBalance(this.fromDate, this.toDate);
        ((Control) this.btnFinishRokad).Visible = false;
        ((Control) this.btnAddEntry).Visible = false;
        this.tbxOpeningBalance.ReadOnly = true;
        this.cmsDataGridView.Enabled = true;
        this.eDITToolStripMenuItem.Enabled = false;
        this.cmsTextBoxJamma.Enabled = false;
        this.cmsTextBoxNovae.Enabled = false;
      }
      if (!(this.formType == "currentDay"))
        return;
      this.tbxRokadDate.Text = this.rokadDate.ToString("dd/MM/yyyy");
      this.refreshGridJamma();
      this.refreshGridNovae();
      this.tbxOpeningBalance.Text = RokadDetailsClass.getOpeningBalance(this.rokadDate);
    }

    private void Form2_Load_1(object sender, EventArgs e)
    {
      this.loadForm();
      if (this.comboBox1.Items.Count <= 0)
        return;
      this.comboBox1.SelectedIndex = 0;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getJammaForbetweenDays()
    {
      try
      {
        if (this.dtJammaLedger == null || this.dtJammaLedger.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) this.dtJammaLedger.Rows)
          ((Collection<CTreeNode>) this.ctvJamma.Nodes).Add(new CTreeNode((Control) new TextBox()));
        int index1 = 0;
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvJamma.Nodes)
        {
          node.Control.Name = this.dtJammaLedger.Rows[index1]["LedgerCode"].ToString();
          if (this.comboBox1.Text == "ENGLISH")
          {
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
            node.Control.Text = this.dtJammaLedger.Rows[index1]["novaesum"].ToString() + " - " + this.dtJammaLedger.Rows[index1]["LedgerType"].ToString();
          }
          if (this.comboBox1.Text == "HINDI")
          {
            node.Control.Text = this.dtJammaLedger.Rows[index1]["novaesum"].ToString() + " - " + this.dtJammaLedger.Rows[index1]["LedgerTypeInHindi"].ToString();
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          }
          node.Control.Size = new Size(453, 37);
          ((TextBoxBase) node.Control).BorderStyle = BorderStyle.FixedSingle;
          node.Control.ForeColor = Color.RoyalBlue;
          ++index1;
        }
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvJamma.Nodes)
        {
          DataTable mainVouchers = VoucherClass.getMainVouchers(node.Control.Name, "jamma", this.fromDate, this.toDate);
          if (mainVouchers != null)
          {
            int index2 = 0;
            foreach (DataRow row in (InternalDataCollectionBase) mainVouchers.Rows)
            {
              ((Collection<CTreeNode>) node.Nodes).Add(new CTreeNode((Control) new TextBox()));
              TextBox control = (TextBox) ((Collection<CTreeNode>) node.Nodes)[index2].Control;
              string str1 = row["amount"].ToString();
              DateTime dateTime = DateTime.Parse(row["voucherdate"].ToString());
              string str2 = dateTime.ToString("dd/MM/yyyy");
              string str3 = str1 + " - " + str2;
              control.Text = str3;
              ((Collection<CTreeNode>) node.Nodes)[index2].Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
              ((Collection<CTreeNode>) node.Nodes)[index2].Control.Size = new Size(453, 37);
              if (this.chbExpandFully.Checked)
              {
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes).Add(new CTreeNode((Control) new DataGridView()));
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).EnableHeadersVisualStyles = false;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersHeight = 35;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).RowHeadersVisible = false;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).RowsDefaultCellStyle.Font = new Font("cambria", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).GridColor = Color.FromKnownColor(KnownColor.Control);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).BackgroundColor = Color.FromKnownColor(KnownColor.Control);
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.Size = new Size(580, 150);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DataTable dataTable = new DataTable();
                string name = node.Control.Name;
                dateTime = DateTime.Parse(row["voucherdate"].ToString());
                string voucherdate = dateTime.ToString("dd/MM/yyyy");
                DataTable vouchersSingleDay = VoucherClass.getVouchersSingleDay(name, voucherdate, "jamma");
                if (vouchersSingleDay != null)
                  ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).DataSource = (object) vouchersSingleDay;
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.Height = this.GetDataGridViewHeight((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control);
              }
              ++index2;
            }
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokad.getjammaforbetweendays", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getNovaeForbetweenDays()
    {
      try
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dtNovaeLedger.Rows)
          ((Collection<CTreeNode>) this.ctvNovae.Nodes).Add(new CTreeNode((Control) new TextBox()));
        int index1 = 0;
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvNovae.Nodes)
        {
          node.Control.Name = this.dtNovaeLedger.Rows[index1]["LedgerCode"].ToString();
          if (this.comboBox1.Text == "ENGLISH")
          {
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
            node.Control.Text = this.dtNovaeLedger.Rows[index1]["novaesum"].ToString() + " - " + this.dtNovaeLedger.Rows[index1]["LedgerType"].ToString();
          }
          if (this.comboBox1.Text == "HINDI")
          {
            node.Control.Text = this.dtNovaeLedger.Rows[index1]["novaesum"].ToString() + " - " + this.dtNovaeLedger.Rows[index1]["LedgerTypeInHindi"].ToString();
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          }
          node.Control.Size = new Size(453, 37);
          ((TextBoxBase) node.Control).BorderStyle = BorderStyle.FixedSingle;
          node.Control.ForeColor = Color.RoyalBlue;
          ++index1;
        }
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvNovae.Nodes)
        {
          DataTable mainVouchers = VoucherClass.getMainVouchers(node.Control.Name, "novae", this.fromDate, this.toDate);
          if (mainVouchers != null)
          {
            int index2 = 0;
            foreach (DataRow row in (InternalDataCollectionBase) mainVouchers.Rows)
            {
              ((Collection<CTreeNode>) node.Nodes).Add(new CTreeNode((Control) new TextBox()));
              TextBox control = (TextBox) ((Collection<CTreeNode>) node.Nodes)[index2].Control;
              string str1 = row["amount"].ToString();
              DateTime dateTime = DateTime.Parse(row["voucherdate"].ToString());
              string str2 = dateTime.ToString("dd/MM/yyyy");
              string str3 = str1 + " - " + str2;
              control.Text = str3;
              ((Collection<CTreeNode>) node.Nodes)[index2].Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
              ((Collection<CTreeNode>) node.Nodes)[index2].Control.Size = new Size(453, 37);
              if (this.chbExpandFully.Checked)
              {
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes).Add(new CTreeNode((Control) new DataGridView()));
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).EnableHeadersVisualStyles = false;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersHeight = 35;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).RowHeadersVisible = false;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).RowsDefaultCellStyle.Font = new Font("cambria", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).GridColor = Color.FromKnownColor(KnownColor.Control);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).BackgroundColor = Color.FromKnownColor(KnownColor.Control);
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.Size = new Size(580, 150);
                ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DataTable dataTable = new DataTable();
                string name = node.Control.Name;
                dateTime = DateTime.Parse(row["voucherdate"].ToString());
                string voucherdate = dateTime.ToString("dd/MM/yyyy");
                DataTable vouchersSingleDay = VoucherClass.getVouchersSingleDay(name, voucherdate, "novae");
                if (vouchersSingleDay != null)
                  ((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control).DataSource = (object) vouchersSingleDay;
                ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control.Height = this.GetDataGridViewHeight((DataGridView) ((Collection<CTreeNode>) ((Collection<CTreeNode>) node.Nodes)[index2].Nodes)[0].Control);
              }
              ++index2;
            }
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokad.getnovaeforbetweendays", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getNovaeForSingleDay()
    {
      try
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dtNovaeLedger.Rows)
          ((Collection<CTreeNode>) this.ctvNovae.Nodes).Add(new CTreeNode((Control) new TextBox()));
        int index = 0;
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvNovae.Nodes)
        {
          node.Control.Name = this.dtNovaeLedger.Rows[index]["LedgerCode"].ToString();
          if (this.comboBox1.Text == "ENGLISH")
          {
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
            node.Control.Text = this.dtNovaeLedger.Rows[index]["novaesum"].ToString() + " - " + this.dtNovaeLedger.Rows[index]["LedgerType"].ToString();
          }
          if (this.comboBox1.Text == "HINDI")
          {
            node.Control.Text = this.dtNovaeLedger.Rows[index]["novaesum"].ToString() + " - " + this.dtNovaeLedger.Rows[index]["LedgerTypeInHindi"].ToString();
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          }
          node.Control.Size = new Size(453, 37);
          ((TextBoxBase) node.Control).BorderStyle = BorderStyle.FixedSingle;
          node.Control.ForeColor = Color.RoyalBlue;
          node.Control.ContextMenuStrip = this.cmsTextBoxNovae;
          ++index;
        }
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvNovae.Nodes)
        {
          DataTable vouchers = VoucherClass.getVouchers(this.formType, node.Control.Name.ToString(), this.rokadDate.ToString("dd/MM/yyyy"), "novae", this.fromDate, this.toDate);
          ((Collection<CTreeNode>) node.Nodes).Add(new CTreeNode((Control) new DataGridView()));
          ((Collection<CTreeNode>) node.Nodes)[0].Control.ContextMenuStrip = this.cmsDataGridView;
          ((Collection<CTreeNode>) node.Nodes)[0].Control.ForeColor = Color.Black;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).EnableHeadersVisualStyles = false;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersHeight = 35;
          ((Collection<CTreeNode>) node.Nodes)[0].Control.Size = new Size(580, 150);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
          {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.MintCream,
            Font = new Font("Comic Sans MS", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
            ForeColor = Color.Navy,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
          };
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).RowHeadersVisible = false;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).RowsDefaultCellStyle.Font = new Font("cambria", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).GridColor = Color.FromKnownColor(KnownColor.PowderBlue);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
          if (vouchers != null)
            ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).DataSource = (object) vouchers;
          ((Collection<CTreeNode>) node.Nodes)[0].Control.Height = this.GetDataGridViewHeight((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formm rokad.getnovaeforsingleday", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getJammaForSingleDay()
    {
      try
      {
        foreach (DataRow row in (InternalDataCollectionBase) this.dtJammaLedger.Rows)
          ((Collection<CTreeNode>) this.ctvJamma.Nodes).Add(new CTreeNode((Control) new TextBox()));
        int index = 0;
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvJamma.Nodes)
        {
          node.Control.Name = this.dtJammaLedger.Rows[index]["LedgerCode"].ToString();
          if (this.comboBox1.Text == "ENGLISH")
          {
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
            node.Control.Text = this.dtJammaLedger.Rows[index]["novaesum"].ToString().Trim() + " - " + this.dtJammaLedger.Rows[index]["LedgerType"].ToString();
          }
          if (this.comboBox1.Text == "HINDI")
          {
            node.Control.Text = this.dtJammaLedger.Rows[index]["novaesum"].ToString() + " - " + this.dtJammaLedger.Rows[index]["LedgerTypeInHindi"].ToString();
            node.Control.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          }
          node.Control.Size = new Size(453, 37);
          ((TextBoxBase) node.Control).BorderStyle = BorderStyle.FixedSingle;
          node.Control.ForeColor = Color.RoyalBlue;
          node.Control.ContextMenuStrip = this.cmsTextBoxJamma;
          ++index;
        }
        foreach (CTreeNode node in (Collection<CTreeNode>) this.ctvJamma.Nodes)
        {
          DataTable vouchers = VoucherClass.getVouchers(this.formType, node.Control.Name.ToString(), this.rokadDate.ToString("dd/MM/yyyy"), "jamma", this.fromDate, this.toDate);
          ((Collection<CTreeNode>) node.Nodes).Add(new CTreeNode((Control) new DataGridView()));
          ((Collection<CTreeNode>) node.Nodes)[0].Control.ContextMenuStrip = this.cmsDataGridView;
          ((Collection<CTreeNode>) node.Nodes)[0].Control.ForeColor = Color.Black;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).EnableHeadersVisualStyles = false;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersHeight = 35;
          ((Collection<CTreeNode>) node.Nodes)[0].Control.Size = new Size(580, 150);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
          {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.MintCream,
            Font = new Font("Comic Sans MS", 12.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0),
            ForeColor = Color.Navy,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
          };
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).RowHeadersVisible = false;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.MintCream);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).RowsDefaultCellStyle.Font = new Font("cambria", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).GridColor = Color.FromKnownColor(KnownColor.PowderBlue);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).BackgroundColor = Color.FromKnownColor(KnownColor.Azure);
          ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
          if (vouchers != null)
          {
            ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).DataSource = (object) vouchers;
            ((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control).Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          }
          ((Collection<CTreeNode>) node.Nodes)[0].Control.Height = this.GetDataGridViewHeight((DataGridView) ((Collection<CTreeNode>) node.Nodes)[0].Control);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formm rokad.get jamma for singleday", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex == -1)
      {
        e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
        e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
        e.Handled = true;
      }
      if (e.RowIndex != 0)
        return;
      e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.show();

    private void show()
    {
      if (((this.dtJammaLedger == null ? 0 : (this.dtJammaLedger.Rows.Count > 0 ? 1 : 0)) | (this.dtNovaeLedger == null ? 0 : (this.dtNovaeLedger.Rows.Count > 0 ? 1 : 0))) != 0)
      {
        double num;
        if (this.formType == "singleDay")
        {
          ((Collection<CTreeNode>) this.ctvJamma.Nodes).Clear();
          ((Collection<CTreeNode>) this.ctvNovae.Nodes).Clear();
          this.getJammaForSingleDay();
          this.getNovaeForSingleDay();
          DataTable rokadDetails = RokadDetailsClass.getRokadDetails(this.rokadDate);
          if (rokadDetails != null && rokadDetails.Rows.Count > 0)
          {
            this.tbxJamma.Text = double.Parse(rokadDetails.Rows[0]["Jammasideclosing"].ToString()).ToString("F");
            this.tbxNovae.Text = double.Parse(rokadDetails.Rows[0]["Novaesideclosing"].ToString()).ToString("F");
            TextBox tbxCash = this.tbxCash;
            num = double.Parse(rokadDetails.Rows[0]["Cash"].ToString());
            string str = num.ToString("F");
            tbxCash.Text = str;
          }
        }
        if (this.formType == "currentDay")
        {
          ((Collection<CTreeNode>) this.ctvJamma.Nodes).Clear();
          ((Collection<CTreeNode>) this.ctvNovae.Nodes).Clear();
          this.clickedOnce = true;
          this.getJammaForSingleDay();
          this.getNovaeForSingleDay();
          TextBox tbxJamma = this.tbxJamma;
          num = double.Parse(VoucherClass.getTotalJammaSum(this.formType, this.rokadDate, this.rokadDate, this.rokadDate)) + double.Parse(this.tbxOpeningBalance.Text.Trim().ToString());
          string str1 = num.ToString("F");
          tbxJamma.Text = str1;
          TextBox tbxCash = this.tbxCash;
          num = double.Parse(this.tbxJamma.Text.Trim().ToString()) - double.Parse(VoucherClass.getTotalNovaeSum(this.formType, this.rokadDate, this.rokadDate, this.rokadDate));
          string str2 = num.ToString("F");
          tbxCash.Text = str2;
          TextBox tbxNovae = this.tbxNovae;
          num = double.Parse(VoucherClass.getTotalNovaeSum(this.formType, this.rokadDate, this.rokadDate, this.rokadDate)) + double.Parse(this.tbxCash.Text.Trim().ToString());
          string str3 = num.ToString("F");
          tbxNovae.Text = str3;
        }
        else if (this.formType == "betweenDays")
        {
          ((Collection<CTreeNode>) this.ctvJamma.Nodes).Clear();
          ((Collection<CTreeNode>) this.ctvNovae.Nodes).Clear();
          this.clickedOnce = true;
          this.getJammaForbetweenDays();
          this.getNovaeForbetweenDays();
          TextBox tbxJamma = this.tbxJamma;
          num = Math.Round(double.Parse(VoucherClass.getTotalJammaSum(this.formType, this.rokadDate, this.fromDate, this.toDate)) + double.Parse(this.tbxOpeningBalance.Text.Trim().ToString()));
          string str4 = num.ToString("F");
          tbxJamma.Text = str4;
          TextBox tbxCash = this.tbxCash;
          num = double.Parse(this.tbxJamma.Text.Trim().ToString()) - double.Parse(VoucherClass.getTotalNovaeSum(this.formType, this.rokadDate, this.fromDate, this.toDate));
          string str5 = num.ToString("F");
          tbxCash.Text = str5;
          TextBox tbxNovae = this.tbxNovae;
          num = Math.Round(double.Parse(VoucherClass.getTotalNovaeSum(this.formType, this.rokadDate, this.fromDate, this.toDate)) + double.Parse(this.tbxCash.Text.Trim().ToString()));
          string str6 = num.ToString("F");
          tbxNovae.Text = str6;
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("No records");
      }
      this.ctvJamma.CollapseAll();
      this.ctvNovae.CollapseAll();
    }

    private int GetDataGridViewHeight(DataGridView dataGridView) => (dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0) + dataGridView.Rows.OfType<DataGridViewRow>().Where<DataGridViewRow>((System.Func<DataGridViewRow, bool>) (r => r.Visible)).Sum<DataGridViewRow>((System.Func<DataGridViewRow, int>) (r => r.Height));

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
      int num = (int) new FormVoucher("ADDVOUCHER", "", "", "JAMMA").ShowDialog();
      this.loadForm();
      this.show();
    }

    private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void glassButton4_Click(object sender, EventArgs e)
    {
      if (!(this.tbxOpeningBalance.Text.Trim().ToString() != "") || !(this.tbxCash.Text.Trim().ToString() != "") || !(this.tbxJamma.Text.Trim().ToString() != "") || !(this.tbxNovae.Text.Trim().ToString() != ""))
        return;
      if (this.tbxJamma.Text == this.tbxNovae.Text && double.Parse(this.tbxCash.Text.Trim().ToString()) >= 0.0)
      {
        if (this.checkForCurrentDay().ToString() != "" && this.checkForCurrentDay() != "noCurrent" && DateTime.Parse(this.checkForCurrentDay()).ToString("dd/MM/yyyy") == this.rokadDate.ToString("dd/MM/yyyy"))
        {
          if (DateTime.Now.ToString("dd/MM/yyyy") == this.rokadDate.ToString("dd/MM/yyyy"))
          {
            if (DialogResult.Yes == MessageBox.Show("Finish  Rokad... Are you sure??", "FINISH ROKAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
              this.updateRokadDetails();
          }
          else if (6 == (int) MessageBox.Show("Today DAte: " + DateTime.Now.ToShortDateString() + "\nRokad Date:" + this.rokadDate.ToShortDateString() + "\n Are you sure??", "FINISH ROKAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            this.updateRokadDetails();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Rokad Not matching...Reecheck");
      }
    }

    private void updateRokadDetails()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update  tblRokadDetails set OpeningBalance = @OpeningBalance,Cash = @Cash,JammaSideClosing=@JammaSideClosing,NovaeSideClosing=@NovaeSideClosing,RokadFinished= @RokadFinished,CurrentDay = @CurrentDay,RokadFinishedTime=@RokadFinishedTime,CreatedOn = @CreatedOn,CreatedBy = @CreatedBy,CreatedTime = @CreatedTime where RokadDate = @RokadDate", new List<OleDbParameter>()
      {
        new OleDbParameter("OpeningBalance", (object) this.tbxOpeningBalance.Text.Trim().ToString()),
        new OleDbParameter("Cash", (object) this.tbxCash.Text.Trim().ToString()),
        new OleDbParameter("JammaSideClosing", (object) this.tbxJamma.Text.Trim().ToString()),
        new OleDbParameter("NovaeSideClosing", (object) this.tbxNovae.Text.Trim().ToString()),
        new OleDbParameter("RokadFinished", (object) "Y"),
        new OleDbParameter("CurrentDay", (object) "N"),
        new OleDbParameter("RokadFinishedTime", (object) DateTime.Now.ToShortTimeString()),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedTime", (object) DateTime.Now.ToShortTimeString()),
        new OleDbParameter("RokadDate", (object) this.rokadDate.ToString("dd/MM/yyyy"))
      }, ref strError) == "Done")
      {
        int num1 = (int) new FormNewRokadDateSelect(this.rokadDate.AddDays(1.0).ToString("dd/MM/yyyy"), this.tbxCash.Text.Trim().ToString()).ShowDialog();
        if (DialogResult.Yes != MessageBox.Show("do you want to print?", "Print Rokad?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
          return;
        int num2 = (int) new FormPrintRokad(this.tbxRokadDate.Text.ToString()).ShowDialog();
      }
      else
      {
        int num = (int) MessageBox.Show("Error ... Try from beginning");
      }
    }

    private string checkForCurrentDay()
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblrokaddetails where CurrentDay = 'Y'";
        DataTable dataTable1 = new DataTable();
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form rokad.checkforcurrentday", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form rokad.checkforcurrentday" + strError);
        }
        else
          return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["RokadDate"].ToString() : "noCurrent";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokad.checkforcurrentday", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private void tbxJamma_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Edit voucher number -" + (sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["vouchernumber"].Value.ToString(), "Edit ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        string str = VoucherMasterClass.getledgerCode((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["voucherCode"].Value.ToString());
        if ((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["voucherCode"].Value.ToString() == "G1")
        {
          if ((sourceControl as DataGridView).Parent.Name.ToString() == "ctvJamma")
          {
            int num1 = (int) MessageBox.Show("Pledge Amount Cannot be edited");
          }
        }
        else if (str != "")
        {
          if (str == "B1" | str == "G1" | str == "B2")
          {
            if (DialogResult.Yes == MessageBox.Show("It is not safe to edit the entry directly in rokad..Please change it in the Pledger or Bank Entry.Do you Still want to continue", "edit voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
              int num2 = (int) new FormVoucher("EDITVOUCHER", (sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["vouchernumber"].Value.ToString()).ShowDialog();
            }
          }
          else if (PawnManagementClass.checkIfRokadFinished(DateTime.Parse((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["voucherDate"].Value.ToString()).ToString("dd/MM/yyyy")))
          {
            int num3 = (int) new FormEditVoucher((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["vouchernumber"].Value.ToString()).ShowDialog();
          }
          else
          {
            int num4 = (int) new FormVoucher("EDITVOUCHER", (sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["vouchernumber"].Value.ToString()).ShowDialog();
          }
        }
        this.loadForm();
        this.show();
      }
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Add new entry  ??", "ADD ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        int num = (int) new FormVoucher("ADDVOUCHER", "", (sourceControl as TextBox).Name, "JAMMA").ShowDialog();
        this.loadForm();
        this.show();
      }
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Add new entry  ??", "ADD ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        int num = (int) new FormVoucher("ADDVOUCHER", "", (sourceControl as TextBox).Name, "NOVAE").ShowDialog();
        this.loadForm();
        this.show();
      }
    }

    private void ctvJamma_Paint(object sender, PaintEventArgs e)
    {
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
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void tbxOpeningBalance_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void btnPrint_Click(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click_2(object sender, EventArgs e)
    {
      int num = (int) new FormVoucher("ADDVOUCHER", "", "", "NOVAE").ShowDialog();
      this.loadForm();
      this.show();
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      int num = (int) new FormVoucher("ADDVOUCHER", "", "", "JAMMA").ShowDialog();
      this.loadForm();
      this.show();
    }

    private void toolStripMenuItem4_Click(object sender, EventArgs e)
    {
      int num = (int) new FormVoucher("ADDVOUCHER", "", "", "NOVAE").ShowDialog();
      this.loadForm();
      this.show();
    }

    private void tbxOpeningBalance_TextChanged(object sender, EventArgs e)
    {
    }

    private void tbxOpeningBalance_Validating(object sender, CancelEventArgs e)
    {
    }

    private void glassButton2_Click(object sender, EventArgs e) => new FormMoneyCalculator().Show();

    private void tbxCash_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) sourceControl).DataSource, sourceControl.Name.ToString()).ShowDialog();
    }

    private void chbExpandFully_CheckStateChanged(object sender, EventArgs e) => this.show();

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => this.show();

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

    private void glassButton7_Click(object sender, EventArgs e) => Process.Start("calc");

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Delete????", "Delete??  Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) || !(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (!PawnManagementClass.checkIfRokadFinished(DateTime.Parse((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["voucherDate"].Value.ToString()).ToString("dd/MM/yyyy")))
      {
        if (VoucherMasterClass.DELETEVOUCHER((sourceControl as DataGridView).Rows[(sourceControl as DataGridView).CurrentCell.RowIndex].Cells["voucherNumber"].Value.ToString()) == "Done")
        {
          int num1 = (int) MessageBox.Show("successfully deleted");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Rokad Already Finished for this date...Cannot be Deleted");
      }
      this.loadForm();
      this.show();
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
      this.ctvNovae = new CTreeView();
      this.cmsNovae = new ContextMenuStrip(this.components);
      this.toolStripMenuItem4 = new ToolStripMenuItem();
      this.ctvJamma = new CTreeView();
      this.cmsJamma = new ContextMenuStrip(this.components);
      this.toolStripMenuItem2 = new ToolStripMenuItem();
      this.tbxNovae = new TextBox();
      this.tbxJamma = new TextBox();
      this.tbxCash = new TextBox();
      this.tbxOpeningBalance = new TextBox();
      this.tbxRokadDate = new TextBox();
      this.cmsDataGridView = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.comboBox1 = new ComboBox();
      this.btnFinishRokad = new GlassButton();
      this.cmsTextBoxJamma = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.cmsTextBoxNovae = new ContextMenuStrip(this.components);
      this.toolStripMenuItem3 = new ToolStripMenuItem();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.chbExpandFully = new CheckBox();
      this.btnAddEntry = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.headerPanel5 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.cmsNovae.SuspendLayout();
      this.cmsJamma.SuspendLayout();
      this.cmsDataGridView.SuspendLayout();
      this.cmsTextBoxJamma.SuspendLayout();
      this.cmsTextBoxNovae.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((Control) this.headerPanel5).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      ((Control) this.ctvNovae).BackColor = Color.Azure;
      ((Panel) this.ctvNovae).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.ctvNovae).ContextMenuStrip = this.cmsNovae;
      ((Control) this.ctvNovae).Dock = DockStyle.Fill;
      this.ctvNovae.DrawStyle = CTreeViewDrawStyle.LinearTree;
      this.ctvNovae.IndentDepth = 20;
      ((Control) this.ctvNovae).Location = new Point(504, 3);
      ((Control) this.ctvNovae).Name = "ctvNovae";
      ((Control) this.ctvNovae).Size = new Size(495, 489);
      ((Control) this.ctvNovae).TabIndex = 1;
      this.cmsNovae.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem4
      });
      this.cmsNovae.Name = "contextMenuStrip1";
      this.cmsNovae.Size = new Size(99, 26);
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(98, 22);
      this.toolStripMenuItem4.Text = "ADD";
      this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem4_Click);
      ((Control) this.ctvJamma).BackColor = Color.Azure;
      ((Panel) this.ctvJamma).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.ctvJamma).ContextMenuStrip = this.cmsJamma;
      ((Control) this.ctvJamma).Dock = DockStyle.Fill;
      this.ctvJamma.DrawStyle = CTreeViewDrawStyle.LinearTree;
      ((Control) this.ctvJamma).ForeColor = Color.Maroon;
      this.ctvJamma.IndentDepth = 20;
      ((Control) this.ctvJamma).Location = new Point(3, 3);
      ((Control) this.ctvJamma).Name = "ctvJamma";
      ((Control) this.ctvJamma).Size = new Size(495, 489);
      ((Control) this.ctvJamma).TabIndex = 0;
      ((Control) this.ctvJamma).Paint += new PaintEventHandler(this.ctvJamma_Paint);
      this.cmsJamma.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem2
      });
      this.cmsJamma.Name = "contextMenuStrip1";
      this.cmsJamma.Size = new Size(99, 26);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(98, 22);
      this.toolStripMenuItem2.Text = "ADD";
      this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
      this.tbxNovae.Anchor = AnchorStyles.Bottom;
      this.tbxNovae.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNovae.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNovae.Location = new Point(649, 557);
      this.tbxNovae.Name = "tbxNovae";
      this.tbxNovae.Size = new Size(216, 31);
      this.tbxNovae.TabIndex = 4;
      this.tbxNovae.TextAlign = HorizontalAlignment.Center;
      this.tbxNovae.KeyPress += new KeyPressEventHandler(this.tbxJamma_KeyPress);
      this.tbxJamma.Anchor = AnchorStyles.Bottom;
      this.tbxJamma.BorderStyle = BorderStyle.FixedSingle;
      this.tbxJamma.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxJamma.Location = new Point(146, 555);
      this.tbxJamma.Name = "tbxJamma";
      this.tbxJamma.Size = new Size(216, 31);
      this.tbxJamma.TabIndex = 3;
      this.tbxJamma.TextAlign = HorizontalAlignment.Center;
      this.tbxJamma.KeyPress += new KeyPressEventHandler(this.tbxJamma_KeyPress);
      this.tbxCash.BackColor = Color.AliceBlue;
      this.tbxCash.BorderStyle = BorderStyle.None;
      this.tbxCash.Dock = DockStyle.Fill;
      this.tbxCash.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCash.Location = new Point(0, 0);
      this.tbxCash.Name = "tbxCash";
      this.tbxCash.Size = new Size(257, 28);
      this.tbxCash.TabIndex = 2;
      this.tbxCash.Text = "0";
      this.tbxCash.TextAlign = HorizontalAlignment.Center;
      this.tbxCash.KeyPress += new KeyPressEventHandler(this.tbxCash_KeyPress);
      this.tbxOpeningBalance.BackColor = Color.AliceBlue;
      this.tbxOpeningBalance.BorderStyle = BorderStyle.None;
      this.tbxOpeningBalance.Dock = DockStyle.Fill;
      this.tbxOpeningBalance.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOpeningBalance.Location = new Point(0, 0);
      this.tbxOpeningBalance.Name = "tbxOpeningBalance";
      this.tbxOpeningBalance.Size = new Size(258, 28);
      this.tbxOpeningBalance.TabIndex = 0;
      this.tbxOpeningBalance.Text = "0";
      this.tbxOpeningBalance.TextAlign = HorizontalAlignment.Center;
      this.tbxOpeningBalance.TextChanged += new EventHandler(this.tbxOpeningBalance_TextChanged);
      this.tbxOpeningBalance.KeyPress += new KeyPressEventHandler(this.tbxOpeningBalance_KeyPress);
      this.tbxOpeningBalance.Validating += new CancelEventHandler(this.tbxOpeningBalance_Validating);
      this.tbxRokadDate.Anchor = AnchorStyles.Top;
      this.tbxRokadDate.BackColor = Color.AliceBlue;
      this.tbxRokadDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRokadDate.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRokadDate.Location = new Point(348, 11);
      this.tbxRokadDate.Name = "tbxRokadDate";
      this.tbxRokadDate.Size = new Size(342, 37);
      this.tbxRokadDate.TabIndex = 1;
      this.tbxRokadDate.TextAlign = HorizontalAlignment.Center;
      this.cmsDataGridView.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.cmsDataGridView.Name = "contextMenuStrip1";
      this.cmsDataGridView.Size = new Size(195, 136);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export  to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.dELETEToolStripMenuItem.Image = (Image) Resources.delete;
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.dELETEToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.comboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.Popup;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "ENGLISH",
        (object) "HINDI"
      });
      this.comboBox1.Location = new Point(240, 604);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(151, 33);
      this.comboBox1.TabIndex = 6;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      ((Control) this.btnFinishRokad).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnFinishRokad.BackColor = Color.LightBlue;
      this.btnFinishRokad.FadeOnFocus = true;
      this.btnFinishRokad.ForeColor = Color.MediumBlue;
      this.btnFinishRokad.ForeColorOnFocus = Color.Red;
      this.btnFinishRokad.ForeColorOnLeave = Color.RoyalBlue;
      this.btnFinishRokad.GlowColor = Color.White;
      this.btnFinishRokad.InnerBorderColor = Color.Transparent;
      ((Control) this.btnFinishRokad).Location = new Point(805, 603);
      ((Control) this.btnFinishRokad).Name = "btnFinishRokad";
      this.btnFinishRokad.OuterBorderColor = Color.MediumSlateBlue;
      this.btnFinishRokad.ShineColor = Color.Transparent;
      ((Control) this.btnFinishRokad).Size = new Size(191, 34);
      ((Control) this.btnFinishRokad).TabIndex = 9;
      ((Control) this.btnFinishRokad).Text = "&FINISH ROKAD";
      ((Control) this.btnFinishRokad).Click += new EventHandler(this.glassButton4_Click);
      this.cmsTextBoxJamma.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem1
      });
      this.cmsTextBoxJamma.Name = "contextMenuStrip1";
      this.cmsTextBoxJamma.Size = new Size(99, 26);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(98, 22);
      this.toolStripMenuItem1.Text = "ADD";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.cmsTextBoxNovae.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripMenuItem3
      });
      this.cmsTextBoxNovae.Name = "contextMenuStrip1";
      this.cmsTextBoxNovae.Size = new Size(99, 26);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(98, 22);
      this.toolStripMenuItem3.Text = "ADD";
      this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.ctvJamma, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.ctvNovae, 1, 0);
      this.tableLayoutPanel1.Location = new Point(3, 56);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(1002, 495);
      this.tableLayoutPanel1.TabIndex = 16;
      this.chbExpandFully.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chbExpandFully.AutoSize = true;
      this.chbExpandFully.Checked = true;
      this.chbExpandFully.CheckState = CheckState.Checked;
      this.chbExpandFully.Location = new Point(144, 612);
      this.chbExpandFully.Name = "chbExpandFully";
      this.chbExpandFully.Size = new Size(86, 17);
      this.chbExpandFully.TabIndex = 5;
      this.chbExpandFully.Text = "Expand Fully";
      this.chbExpandFully.UseVisualStyleBackColor = true;
      this.chbExpandFully.Visible = false;
      this.chbExpandFully.CheckStateChanged += new EventHandler(this.chbExpandFully_CheckStateChanged);
      ((Control) this.btnAddEntry).Anchor = AnchorStyles.Bottom;
      this.btnAddEntry.BackColor = Color.LightBlue;
      this.btnAddEntry.FadeOnFocus = true;
      this.btnAddEntry.ForeColor = Color.MediumBlue;
      this.btnAddEntry.ForeColorOnFocus = Color.Red;
      this.btnAddEntry.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEntry.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEntry).Image = (Image) Resources.plus;
      this.btnAddEntry.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEntry).Location = new Point(12, 555);
      ((Control) this.btnAddEntry).Name = "btnAddEntry";
      this.btnAddEntry.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEntry.ShineColor = Color.Transparent;
      ((Control) this.btnAddEntry).Size = new Size(121, 34);
      ((Control) this.btnAddEntry).TabIndex = 8;
      ((Control) this.btnAddEntry).Text = "ADD &JAMMA ENTRY";
      ((ButtonBase) this.btnAddEntry).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEntry).Click += new EventHandler(this.glassButton1_Click_1);
      ((Control) this.glassButton1).Anchor = AnchorStyles.Bottom;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.plus;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(880, 555);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(121, 34);
      ((Control) this.glassButton1).TabIndex = 17;
      ((Control) this.glassButton1).Text = "ADD &NOVAE ENTRY";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click_2);
      ((Control) this.glassButton2).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(595, 603);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(191, 34);
      ((Control) this.glassButton2).TabIndex = 18;
      ((Control) this.glassButton2).Text = "&DENOMINATION";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
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
      this.headerPanel5.CaptionText = "OPENING BALANCE";
      this.headerPanel5.CaptionVisible = true;
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel5).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel5).Controls.Add((Control) this.tbxOpeningBalance);
      ((Control) this.headerPanel5).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel5).ForeColor = Color.DarkBlue;
      this.headerPanel5.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel5.GradientEnd = SystemColors.ControlLight;
      this.headerPanel5.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel5).Location = new Point(4, 3);
      ((Control) this.headerPanel5).Name = "headerPanel5";
      this.headerPanel5.PanelIcon = (Icon) null;
      this.headerPanel5.PanelIconVisible = false;
      ((Control) this.headerPanel5).Size = new Size(260, 50);
      ((Control) this.headerPanel5).TabIndex = 80;
      this.headerPanel5.TextAntialias = true;
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
      ((Control) this.glassButton3).Location = new Point(-47, 513);
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
      ((Control) this.glassButton4).Location = new Point(87, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.headerPanel1.CaptionText = "CASH";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxCash);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(744, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(259, 50);
      ((Control) this.headerPanel1).TabIndex = 81;
      this.headerPanel1.TextAntialias = true;
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
      ((Control) this.glassButton5).Location = new Point(-48, 513);
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
      ((Control) this.glassButton6).Location = new Point(86, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(398, 603);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(191, 34);
      ((Control) this.glassButton7).TabIndex = 82;
      ((Control) this.glassButton7).Text = "&Calculator";
      ((Control) this.glassButton7).Click += new EventHandler(this.glassButton7_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Azure;
      this.ClientSize = new Size(1008, 646);
      this.Controls.Add((Control) this.glassButton7);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel5);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.chbExpandFully);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.btnFinishRokad);
      this.Controls.Add((Control) this.btnAddEntry);
      this.Controls.Add((Control) this.tbxRokadDate);
      this.Controls.Add((Control) this.tbxJamma);
      this.Controls.Add((Control) this.tbxNovae);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.Name = nameof (FormRokad);
      this.ShowInTaskbar = false;
      this.Load += new EventHandler(this.Form2_Load_1);
      this.cmsNovae.ResumeLayout(false);
      this.cmsJamma.ResumeLayout(false);
      this.cmsDataGridView.ResumeLayout(false);
      this.cmsTextBoxJamma.ResumeLayout(false);
      this.cmsTextBoxNovae.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((Control) this.headerPanel5).ResumeLayout(false);
      ((Control) this.headerPanel5).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
