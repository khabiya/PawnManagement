

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Classes;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormDuplicateRedemptionBill : Form
  {
    private string billNumber = string.Empty;
    private List<string> lstAddress = new List<string>();
    private ReportDocument rd = new ReportDocument();
    private ReportDocument subreport = new ReportDocument();
    private IContainer components = (IContainer) null;
    private TextBox tbxBillNumber;
    private Panel panel1;
    private HeaderPanel headerPanel6;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel7;
    private ComboBox cbShopCodes;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private GlassButton glassButton2;
    private GlassButton btnShow;
    private CrystalReportViewer crystalReportViewer1;
    private TableLayoutPanel tableLayoutPanel1;
    private HeaderPanel headerPanel1;
    private ComboBox cbEmpty;
    private GlassButton glassButton1;
    private GlassButton glassButton5;

    public FormDuplicateRedemptionBill() => this.InitializeComponent();

    public FormDuplicateRedemptionBill(string billNUMBER)
    {
      this.billNumber = billNUMBER;
      this.InitializeComponent();
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

    private void FormDuplicateRedemptionBill_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
        this.tbxBillNumber.MaxLength = 7;
      this.getShopCodes();
      this.cbShopCodes.Text = ((ToolStrip) this.MdiParent.Controls["toolStrip1"]).Items["tscbShopCode"].Text;
      PawnManagementClass.formatButtonBlue(ref this.glassButton2);
      this.cbShopCodes.Select();
      if (!(this.billNumber != ""))
        return;
      this.tbxBillNumber.Text = this.billNumber;
      ((Button) this.btnShow).PerformClick();
    }

    private void cbShopCodes_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCodes.Items.Contains((object) this.cbShopCodes.Text))
      {
        this.getBillNumbers(this.cbShopCodes.Text);
        this.tbxBillNumber.Text = RedemptionClass.getMaxRedemptionNumber(this.cbShopCodes.Text);
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
        this.tbxBillNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        this.tbxBillNumber.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
      }
      else
        this.cbShopCodes.Select();
    }

    private void getBillNumbers(string shopCode)
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct BillNumber from tblRedemption where shopcode = @ShopCode";
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
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          int index = 0;
          this.lstAddress.Clear();
          for (; index < dataTable2.Rows.Count; ++index)
            this.lstAddress.Add(dataTable2.Rows[index]["BillNumber"].ToString());
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form duplicateBill.getBillNumbers()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.cbEmpty.Text.Trim() == "YES")
      {
        this.rd = PawnManagementClass.getEmptyRedemptionBill1(this.cbShopCodes.Text);
        int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
      }
      else
      {
        this.rd = this.getRedemptionBill(this.tbxBillNumber.Text, this.cbShopCodes.Text);
        if (this.rd != null)
        {
          int num = (int) new FormCrystalReportViewer(this.rd).ShowDialog();
        }
      }
    }

    private ReportDocument getRedemptionBill(string BillNumber, string ShopCode)
    {
      this.rd = PawnManagementClass.getRedemptionBill(BillNumber, ShopCode);
      return this.rd;
    }

    private ReportDocument getRedemptionBillsumma(string BillNumber, string ShopCode)
    {
      ReportDocument redemptionBillsumma = new ReportDocument();
      string strError = "";
      string my_querry = "select * from tblRedemption where BillNumber = @BillNumber and shopcode = @ShopCode";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Enter Valid BillNumber");
        return redemptionBillsumma;
      }
      if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        DataTable pledgeRecord = this.getPledgeRecord(dataTable2.Rows[0]["PledgeBillNumber"].ToString(), ShopCode);
        if (pledgeRecord != null && pledgeRecord.Rows.Count > 0)
        {
          dataTable2.Columns.Add("CustomerName", typeof (string));
          dataTable2.Columns.Add("Articles", typeof (string));
          dataTable2.Rows[0]["CustomerName"] = (object) pledgeRecord.Rows[0]["CustomerName"].ToString();
          dataTable2.Rows[0]["Articles"] = (object) pledgeRecord.Rows[0]["Articles"].ToString();
        }
        dataTable2.Columns.Add("customerImagePath", typeof (string));
        dataTable2.Columns.Add("ReleasedByImagePath", typeof (string));
        dataTable2.Rows[0]["CustomerImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable2.Rows[0]["customercode"].ToString() + ".png");
        if (File.Exists(FormMain.startUpPath + "\\Photos\\Released By\\" + dataTable2.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable2.Rows[0][nameof (ShopCode)].ToString() + ".png"))
          dataTable2.Rows[0]["ReleasedByImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\Released By\\" + dataTable2.Rows[0][nameof (BillNumber)].ToString() + " " + dataTable2.Rows[0][nameof (ShopCode)].ToString() + ".png");
        else
          dataTable2.Rows[0]["ReleasedByImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\" + dataTable2.Rows[0]["customercode"].ToString() + ".png");
      }
      DataTable shopDetails = PawnManagementClass.getShopDetails(ShopCode);
      shopDetails.Rows[0]["GaneshjiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\GANESHJI.png");
      shopDetails.Rows[0]["LakshmijiImagePath"] = (object) (FormMain.startUpPath + "\\Photos\\LAKSHMI.jpg");
      redemptionBillsumma.Load("Reports\\RedemptionBill\\ReportRedemptionBill1.rpt");
      redemptionBillsumma.SetDataSource(dataTable2);
      redemptionBillsumma.Subreports[0].SetDataSource(shopDetails);
      redemptionBillsumma.PrintOptions.PaperSize = PaperSize.PaperA5;
      redemptionBillsumma.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
      return redemptionBillsumma;
    }

    private DataTable getPledgeRecord(string BillNumber, string ShopCode)
    {
      string strError = "";
      string my_querry = "select * from tblpLEDGE where shopcode = @ShopCode and BillNumber = @BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter(nameof (ShopCode), (object) ShopCode));
      parameters.Add(new OleDbParameter(nameof (BillNumber), (object) BillNumber));
      DataTable dataTable = new DataTable();
      return SQLHelper.GetDataTable(my_querry, parameters, ref strError);
    }

    private void CREATEXMLFILE()
    {
      string strError = "";
      string my_querry = "select * from tblRedemption";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) this.tbxBillNumber.Text));
      parameters.Add(new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      dataTable2.Columns.Add("CustomerName", typeof (string));
      dataTable2.Columns.Add("Articles", typeof (string));
      dataTable2.Columns.Add("CustomerImagePath", typeof (string));
      dataTable2.Columns.Add("ReleasedByImagePath", typeof (string));
      dataTable2.TableName = "RedemptionBill";
      dataTable2.WriteXmlSchema(Application.StartupPath + "\\Reports\\RedemptionBill\\RedemptionBill.xml");
    }

    private void tbxBillNumber_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        switch (FormMain.BillNumberSeries)
        {
          case "SINGLE":
            if (PawnManagementClass.validateBillNumber((sender as TextBox).Text))
              break;
            (sender as TextBox).Select();
            (sender as TextBox).Select(2, (sender as TextBox).Text.Length);
            break;
          case "DOUBLE":
            if (!PawnManagementClass.validateBillNumberDouble((sender as TextBox).Text))
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
      }
    }

    private void cbShopCodes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxBillNumber.Select();
    }

    private void tbxBillNumber_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnShow).Select();
    }

    private void glassButton2_Click(object sender, EventArgs e)
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
      this.panel1 = new Panel();
      this.headerPanel6 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxBillNumber = new TextBox();
      this.headerPanel7 = new HeaderPanel();
      this.cbShopCodes = new ComboBox();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.btnShow = new GlassButton();
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton5 = new GlassButton();
      this.cbEmpty = new ComboBox();
      this.panel1.SuspendLayout();
      ((Control) this.headerPanel6).SuspendLayout();
      ((Control) this.headerPanel7).SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.headerPanel1);
      this.panel1.Controls.Add((Control) this.headerPanel6);
      this.panel1.Controls.Add((Control) this.headerPanel7);
      this.panel1.Controls.Add((Control) this.glassButton2);
      this.panel1.Controls.Add((Control) this.btnShow);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 53);
      this.panel1.TabIndex = 8;
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
      ((Control) this.headerPanel6).Location = new Point(267, 4);
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
      ((Control) this.glassButton3).Location = new Point(-154, 513);
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
      ((Control) this.glassButton4).Location = new Point(-20, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
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
      this.tbxBillNumber.KeyDown += new KeyEventHandler(this.tbxBillNumber_KeyDown);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      this.tbxBillNumber.Validating += new CancelEventHandler(this.tbxBillNumber_Validating);
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
      ((Control) this.headerPanel7).Location = new Point(3, 4);
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
      ((Control) this.glassButton8).Location = new Point(-51, 513);
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
      ((Control) this.glassButton9).Location = new Point(83, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.PRINT;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(736, 9);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 32);
      ((Control) this.glassButton2).TabIndex = 9;
      ((Control) this.glassButton2).Text = "&PRINT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.btnShow.BackColor = Color.LightBlue;
      this.btnShow.FadeOnFocus = true;
      this.btnShow.ForeColor = Color.MediumBlue;
      this.btnShow.ForeColorOnFocus = Color.Red;
      this.btnShow.ForeColorOnLeave = Color.MediumBlue;
      this.btnShow.GlowColor = Color.White;
      ((ButtonBase) this.btnShow).Image = (Image) Resources.SEARCHGLASS2525;
      this.btnShow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnShow).Location = new Point(600, 9);
      ((Control) this.btnShow).Name = "btnShow";
      this.btnShow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnShow.ShineColor = Color.Transparent;
      ((Control) this.btnShow).Size = new Size(128, 32);
      ((Control) this.btnShow).TabIndex = 8;
      ((Control) this.btnShow).Text = "&SHOW";
      ((ButtonBase) this.btnShow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnShow).Click += new EventHandler(this.glassButton1_Click);
      this.crystalReportViewer1.ActiveViewIndex = -1;
      ((UserControl) this.crystalReportViewer1).BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.crystalReportViewer1).Cursor = Cursors.Default;
      ((Control) this.crystalReportViewer1).Dock = DockStyle.Fill;
      ((Control) this.crystalReportViewer1).Location = new Point(3, 62);
      ((Control) this.crystalReportViewer1).Name = "crystalReportViewer1";
      ((Control) this.crystalReportViewer1).Size = new Size(1002, 557);
      ((Control) this.crystalReportViewer1).TabIndex = 4;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.crystalReportViewer1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.646302f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90.3537f));
      this.tableLayoutPanel1.Size = new Size(1008, 622);
      this.tableLayoutPanel1.TabIndex = 10;
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
      this.headerPanel1.CaptionText = "EMPTY";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.cbEmpty);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(433, 3);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(161, 47);
      ((Control) this.headerPanel1).TabIndex = 84;
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
      ((Control) this.glassButton1).Location = new Point(-156, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(-22, 512);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(123, 37);
      ((Control) this.glassButton5).TabIndex = 1;
      ((Control) this.glassButton5).Text = "&EXIT";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.cbEmpty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbEmpty.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbEmpty.BackColor = Color.AliceBlue;
      this.cbEmpty.Dock = DockStyle.Fill;
      this.cbEmpty.DropDownWidth = 600;
      this.cbEmpty.FormattingEnabled = true;
      this.cbEmpty.Items.AddRange(new object[2]
      {
        (object) "YES",
        (object) "NO"
      });
      this.cbEmpty.Location = new Point(0, 0);
      this.cbEmpty.Name = "cbEmpty";
      this.cbEmpty.Size = new Size(159, 23);
      this.cbEmpty.TabIndex = 25;
      this.cbEmpty.Text = "NO";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormDuplicateRedemptionBill);
      this.Text = nameof (FormDuplicateRedemptionBill);
      this.Load += new EventHandler(this.FormDuplicateRedemptionBill_Load);
      this.panel1.ResumeLayout(false);
      ((Control) this.headerPanel6).ResumeLayout(false);
      ((Control) this.headerPanel6).PerformLayout();
      ((Control) this.headerPanel7).ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
