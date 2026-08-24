

using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormRokadDateSelect : Form
  {
    private IContainer components = (IContainer) null;
    private GlassButton btnGenerate;
    private TextBox tbxFromDate;
    private TextBox tbxToDate;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label7;
    private Panel panel3;
    private Label label2;
    private Label label1;
    private Panel panel1;

    public FormRokadDateSelect() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormRokadDateSelect_Load(object sender, EventArgs e)
    {
      this.setFromDateAndToDate();
      this.tbxFromDate.Select();
    }

    private void setFromDateAndToDate()
    {
      string strError1 = "";
      DataTable dataTable1 = SQLHelper.GetDataTable("select * from tblRokadDetails order by rokadDate", new List<OleDbParameter>(), ref strError1);
      if (strError1 != "")
      {
        PawnManagementClass.InsertIntoException("Form rokaddateselect.serfrodmdateandtodate()", strError1, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form rokaddateselect.serfrodmdateandtodate()\n" + strError1);
      }
      else if (dataTable1 != null && dataTable1.Rows.Count > 0)
        this.tbxFromDate.Text = DateTime.Parse(dataTable1.Rows[0]["rokaddate"].ToString()).ToString("dd/MM/yyyy");
      string strError2 = "";
      DataTable dataTable2 = SQLHelper.GetDataTable("select * from tblRokadDetails  where rokadfinished = 'Y' order by rokadDate desc", new List<OleDbParameter>(), ref strError2);
      if (strError2 != "")
      {
        PawnManagementClass.InsertIntoException("Form rokaddateselect.serfrodmdateandtodate() 2", strError2, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form rokaddateselect.serfrodmdateandtodate() 2 \n" + strError2);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.tbxToDate.Text = DateTime.Parse(dataTable2.Rows[0]["rokaddate"].ToString()).ToString("dd/MM/yyyy");
    }

    private void tbxFromDate_TextChanged(object sender, EventArgs e) => this.tbxToDate.Text = this.tbxFromDate.Text;

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text.ToString()) && PawnManagementClass.checkForValidateDate(this.tbxToDate.Text.ToString()))
      {
        DateTime dateTime = DateTime.Parse(this.tbxFromDate.Text.Trim().ToString());
        if (dateTime.Equals(DateTime.Parse(this.tbxToDate.Text.Trim().ToString())))
        {
          if (this.checkIfRokadFinishedForThatDate(this.tbxFromDate.Text.Trim().ToString()))
          {
            FormRokad formRokad = new FormRokad(DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()), "singleDay");
            formRokad.MdiParent = this.MdiParent;
            formRokad.Show();
          }
          else
          {
            int num1 = (int) MessageBox.Show("Rokad Not there for this date");
          }
        }
        else
        {
          dateTime = DateTime.Parse(this.tbxFromDate.Text.Trim().ToString());
          if (dateTime.Equals(DateTime.Parse(this.tbxToDate.Text.Trim().ToString())))
            return;
          if (DateTime.Parse(this.tbxFromDate.Text.Trim()) <= DateTime.Parse(this.tbxToDate.Text.Trim().ToString()))
          {
            if (this.checkIfRokadFinishedForThatDate(this.tbxFromDate.Text.Trim().ToString(), this.tbxToDate.Text.Trim().ToString()))
            {
              int num2 = (int) new FormRokad(DateTime.Parse(this.tbxFromDate.Text.Trim().ToString()), DateTime.Parse(this.tbxToDate.Text.Trim().ToString()), "betweenDays").ShowDialog();
            }
            else
            {
              int num3 = (int) MessageBox.Show("Rokad Not there for this date");
            }
          }
          else
          {
            int num4 = (int) MessageBox.Show("From Date must be smaller than to date");
          }
        }
      }
      else
        this.tbxFromDate.Select();
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

    private bool checkIfRokadFinishedForThatDate(string rokadDate)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where RokadDate = @RokadDate";
      parameters.Add(new OleDbParameter("RokadDate", (object) rokadDate));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form tblVouchers.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching data from table vouchers.\n" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["RokadFinished"].ToString() == "Y")
        return true;
      return false;
    }

    private void tbxFromDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void panel3_Paint(object sender, PaintEventArgs e)
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
      this.btnGenerate = new GlassButton();
      this.tbxFromDate = new TextBox();
      this.tbxToDate = new TextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.label2 = new Label();
      this.label1 = new Label();
      this.panel1 = new Panel();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.btnGenerate.BackColor = Color.LightBlue;
      this.btnGenerate.FadeOnFocus = true;
      ((Control) this.btnGenerate).Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnGenerate.ForeColor = Color.MediumBlue;
      this.btnGenerate.ForeColorOnFocus = Color.Red;
      this.btnGenerate.ForeColorOnLeave = Color.RoyalBlue;
      this.btnGenerate.GlowColor = Color.White;
      ((ButtonBase) this.btnGenerate).Image = (Image) Resources.SEARCHGLASS2525;
      this.btnGenerate.InnerBorderColor = Color.Transparent;
      ((Control) this.btnGenerate).Location = new Point(219, 136);
      ((Control) this.btnGenerate).Name = "btnGenerate";
      this.btnGenerate.OuterBorderColor = Color.MediumSlateBlue;
      this.btnGenerate.ShineColor = Color.Transparent;
      ((Control) this.btnGenerate).Size = new Size(173, 36);
      ((Control) this.btnGenerate).TabIndex = 0;
      ((Control) this.btnGenerate).Text = "&SHOW";
      ((ButtonBase) this.btnGenerate).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnGenerate).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnGenerate).Click += new EventHandler(this.btnGenerate_Click);
      this.tbxFromDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromDate.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(260, 27);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(225, 37);
      this.tbxFromDate.TabIndex = 1;
      this.tbxFromDate.TextChanged += new EventHandler(this.tbxFromDate_TextChanged);
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxFromDate_KeyDown);
      this.tbxToDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToDate.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(260, 80);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(225, 37);
      this.tbxToDate.TabIndex = 2;
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.tableLayoutPanel1.Anchor = AnchorStyles.None;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 0);
      this.tableLayoutPanel1.Location = new Point(240, 203);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 79.81651f));
      this.tableLayoutPanel1.Size = new Size(608, 211);
      this.tableLayoutPanel1.TabIndex = 12;
      this.tableLayoutPanel1.Paint += new PaintEventHandler(this.tableLayoutPanel1_Paint);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkBlue;
      this.label7.Location = new Point(174, 19);
      this.label7.Name = "label7";
      this.label7.Size = new Size(256, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "ENTER ROKAD DATE";
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImage = (Image) Resources.blueborder;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.tbxToDate);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Controls.Add((Control) this.tbxFromDate);
      this.panel3.Controls.Add((Control) this.btnGenerate);
      this.panel3.Location = new Point(3, 3);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(602, 205);
      this.panel3.TabIndex = 11;
      this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(157, 87);
      this.label2.Name = "label2";
      this.label2.Size = new Size(95, 25);
      this.label2.TabIndex = 8;
      this.label2.Text = "To Date";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(133, 33);
      this.label1.Name = "label1";
      this.label1.Size = new Size(121, 25);
      this.label1.TabIndex = 7;
      this.label1.Text = "From Date";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.AliceBlue;
      this.panel1.BackgroundImage = (Image) Resources.blueborder;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Location = new Point(240, 154);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(608, 60);
      this.panel1.TabIndex = 12;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(1060, 519);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormRokadDateSelect);
      this.Text = nameof (FormRokadDateSelect);
      this.Load += new EventHandler(this.FormRokadDateSelect_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
