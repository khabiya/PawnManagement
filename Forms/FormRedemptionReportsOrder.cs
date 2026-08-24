

using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormRedemptionReportsOrder : Form
  {
    private IContainer components = (IContainer) null;
    private ListBox listBox1;
    private Panel panel1;
    private Label label9;
    private Label label7;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private GlassButton glassButton2;
    private GlassButton glassButton1;
    private GlassButton btnAddArticles;

    public FormRedemptionReportsOrder() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.listBox1.Items.Count <= 0)
        return;
      int selectedIndex = this.listBox1.SelectedIndex;
      if (selectedIndex > 0)
      {
        string str1 = this.listBox1.SelectedItem.ToString();
        string str2 = this.listBox1.Items[selectedIndex - 1].ToString();
        this.listBox1.Items[selectedIndex] = (object) str2;
        this.listBox1.Items[selectedIndex - 1] = (object) str1;
        this.listBox1.SelectedIndex = selectedIndex - 1;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.listBox1.Items.Count <= 0 || this.listBox1.SelectedItems.Count <= 0)
        return;
      int selectedIndex = this.listBox1.SelectedIndex;
      if (selectedIndex < this.listBox1.Items.Count - 1)
      {
        string str1 = this.listBox1.SelectedItem.ToString();
        string str2 = this.listBox1.Items[selectedIndex + 1].ToString();
        this.listBox1.Items[selectedIndex] = (object) str2;
        this.listBox1.Items[selectedIndex + 1] = (object) str1;
        this.listBox1.SelectedIndex = selectedIndex + 1;
      }
    }

    private void FormOrder_Load(object sender, EventArgs e) => this.getListItems();

    private void getListItems()
    {
      string strError = "";
      string my_querry = "select * from tblOrder where FormName = @FormName";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("FormName", (object) "RedemptionReports"));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpayment.getPaymentSum", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form form partpayment.getPaymentSum" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        string str1 = "";
        if (dataTable2.Rows[0]["ColumnOrder"] != null)
          str1 = dataTable2.Rows[0]["ColumnOrder"].ToString();
        if (str1 == "")
          str1 = " t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16";
        string str2 = str1;
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
          this.listBox1.Items.Add((object) str3.Trim());
      }
      else
        this.insertIntotblOrder("RedemptionReports", "t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16");
    }

    private void insertIntotblOrder(string FormName, string ColumnOrder)
    {
      string strError = "";
      SQLHelper.RunCommand("insert into tblOrder(FormName,ColumnOrder) values(@FormName,@ColumnOrder)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FormName), (object) FormName),
        new OleDbParameter(nameof (ColumnOrder), (object) ColumnOrder)
      }, ref strError);
    }

    private void button3_Click(object sender, EventArgs e) => this.save(this.getQuery());

    public string getQuery()
    {
      string str1 = "";
      foreach (string str2 in this.listBox1.Items)
        str1 = str1 + "," + str2;
      return str1.Substring(1);
    }

    private void save(string strColumnOrder)
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblOrder set ColumnOrder = @ColumnOrder", new List<OleDbParameter>()
      {
        new OleDbParameter("ColumnOrder", (object) strColumnOrder)
      }, ref strError) == "Done")
      {
        int num1 = (int) MessageBox.Show("successfully Updated");
      }
      else
      {
        PawnManagementClass.InsertIntoException("form Rdemption.deleteFromPledgeTable", strError, FormMain.username, DateTime.Now.ToString());
        int num2 = (int) MessageBox.Show("Error in deleting from pledge table" + strError);
      }
    }

    private void label9_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.listBox1 = new ListBox();
      this.panel1 = new Panel();
      this.label9 = new Label();
      this.label7 = new Label();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.glassButton2 = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.btnAddArticles = new GlassButton();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.listBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 20;
      this.listBox1.Location = new Point(5, 8);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(203, 524);
      this.listBox1.TabIndex = 1;
      this.panel1.BackColor = Color.Firebrick;
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(217, 32);
      this.panel1.TabIndex = 9;
      this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label9.AutoSize = true;
      this.label9.Cursor = Cursors.Hand;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Cornsilk;
      this.label9.Location = new Point(168, 7);
      this.label9.Name = "label9";
      this.label9.Size = new Size(44, 15);
      this.label9.TabIndex = 11;
      this.label9.Text = "[Close]";
      this.label9.Click += new EventHandler(this.label9_Click);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.White;
      this.label7.Location = new Point(3, 9);
      this.label7.Name = "label7";
      this.label7.Size = new Size(102, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "Column Order";
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(223, 622);
      this.tableLayoutPanel1.TabIndex = 11;
      this.panel2.Controls.Add((Control) this.glassButton2);
      this.panel2.Controls.Add((Control) this.glassButton1);
      this.panel2.Controls.Add((Control) this.btnAddArticles);
      this.panel2.Controls.Add((Control) this.listBox1);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 41);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(217, 578);
      this.panel2.TabIndex = 11;
      this.glassButton2.BackColor = Color.White;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.Black;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.LightPink;
      this.glassButton2.InnerBorderColor = Color.Firebrick;
      ((Control) this.glassButton2).Location = new Point(61, 538);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MistyRose;
      this.glassButton2.ShineColor = Color.MistyRose;
      ((Control) this.glassButton2).Size = new Size(74, 30);
      ((Control) this.glassButton2).TabIndex = 7;
      ((Control) this.glassButton2).Text = "&Down";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.button2_Click);
      this.glassButton1.BackColor = Color.White;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.Black;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.LightPink;
      this.glassButton1.InnerBorderColor = Color.Firebrick;
      ((Control) this.glassButton1).Location = new Point(141, 538);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MistyRose;
      this.glassButton1.ShineColor = Color.MistyRose;
      ((Control) this.glassButton1).Size = new Size(67, 30);
      ((Control) this.glassButton1).TabIndex = 6;
      ((Control) this.glassButton1).Text = "&Save";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.button3_Click);
      this.btnAddArticles.BackColor = Color.White;
      this.btnAddArticles.FadeOnFocus = true;
      ((Control) this.btnAddArticles).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddArticles.ForeColor = Color.Black;
      this.btnAddArticles.ForeColorOnFocus = Color.Red;
      this.btnAddArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddArticles.GlowColor = Color.LightPink;
      this.btnAddArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddArticles).Location = new Point(6, 538);
      ((Control) this.btnAddArticles).Name = "btnAddArticles";
      this.btnAddArticles.OuterBorderColor = Color.MistyRose;
      this.btnAddArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticles).Size = new Size(49, 30);
      ((Control) this.btnAddArticles).TabIndex = 5;
      ((Control) this.btnAddArticles).Text = "&Up";
      ((ButtonBase) this.btnAddArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticles).Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Cornsilk;
      this.ClientSize = new Size(223, 622);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "FormOrder";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "FormOrder";
      this.Load += new EventHandler(this.FormOrder_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
