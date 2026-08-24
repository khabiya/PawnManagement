
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormColumnOrder : Form
  {
    public static string FormType = "";
    private IContainer components = (IContainer) null;
    private Panel panel2;
    private GlassButton glassButton2;
    private GlassButton glassButton1;
    private GlassButton btnAddArticles;
    private Panel panel1;
    private Label label9;
    private Label label7;
    private TableLayoutPanel tableLayoutPanel1;
    private GlassButton glassButton3;
    private CheckedListBox listBox1;

    public FormColumnOrder(string formtype)
    {
      FormColumnOrder.FormType = formtype;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void label9_Click(object sender, EventArgs e) => this.Close();

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

    private void getListItems(string strListItems)
    {
      string strError = "";
      string my_querry = "select * from tblOrder where FormName = @FormName";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("FormName", (object) FormColumnOrder.FormType));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form partpayment.getPaymentSum", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving data form form partpayment.getPaymentSum" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        this.listBox1.Items.Clear();
        string str = "";
        if (dataTable2.Rows[0]["ColumnOrder"] != null)
          str = dataTable2.Rows[0]["ColumnOrder"].ToString();
        if (str == "")
          str = strListItems;
        string[] strArray = str.Split(',');
        for (int index = 0; index < strArray.Length; ++index)
        {
          this.listBox1.Items.Add((object) strArray[index].Trim());
          this.listBox1.SetItemCheckState(index, CheckState.Checked);
        }
      }
      else
      {
        string ColumnOrder = strListItems;
        this.insertIntotblOrder(FormColumnOrder.FormType, ColumnOrder);
      }
    }

    private void refreshListItems(string strListItems)
    {
      this.listBox1.Items.Clear();
      string[] strArray = strListItems.Split(',');
      for (int index = 0; index < strArray.Length; ++index)
      {
        this.listBox1.Items.Add((object) strArray[index].Trim());
        this.listBox1.SetItemCheckState(index, CheckState.Checked);
      }
    }

    private void button3_Click(object sender, EventArgs e) => this.save(this.getQuery(), this.getColumnsToHide());

    private void insertIntotblOrder(string FormName, string ColumnOrder)
    {
      string strError = "";
      SQLHelper.RunCommand("insert into tblOrder(FormName,ColumnOrder) values(@FormName,@ColumnOrder)", new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (FormName), (object) FormName),
        new OleDbParameter(nameof (ColumnOrder), (object) ColumnOrder)
      }, ref strError);
    }

    public string getQuery()
    {
      string str1 = "";
      foreach (string str2 in (ListBox.ObjectCollection) this.listBox1.Items)
        str1 = str1 + "," + str2;
      return str1.Substring(1);
    }

    public string getColumnsToHide()
    {
      string str = "";
      foreach (object obj in (ListBox.ObjectCollection) this.listBox1.Items)
      {
        if (!this.listBox1.CheckedItems.Contains(obj))
        {
          int num = obj.ToString().IndexOf('.');
          if (num != 0)
          {
            int startIndex = num + 1;
            str = str + "," + obj.ToString().Substring(startIndex);
          }
          else
          {
            int startIndex = obj.ToString().IndexOf(" as ");
            str = str + "," + obj.ToString().Substring(startIndex);
          }
        }
      }
      return str == "" ? str : str.Substring(1);
    }

    private void save(string strColumnOrder, string strColumnsToHide)
    {
      string strError = "";
      if (!OrderClass.checkIfFormNameExists(FormColumnOrder.FormType))
        return;
      if (SQLHelper.RunCommand("update tblOrder set ColumnOrder = @ColumnOrder,HideColumns = @HideColumns WHERE FormName = @FormName", new List<OleDbParameter>()
      {
        new OleDbParameter("ColumnOrder", (object) strColumnOrder),
        new OleDbParameter("HideColumns", (object) strColumnsToHide),
        new OleDbParameter("FormName", (object) FormColumnOrder.FormType)
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

    private void UncheckTheHiddenColumns()
    {
      foreach (string str in OrderClass.getcolumnsToHide(FormColumnOrder.FormType))
      {
        for (int index = 0; index < this.listBox1.Items.Count; ++index)
        {
          int startIndex = this.listBox1.Items[index].ToString().IndexOf('.');
          if (startIndex != 0)
            ++startIndex;
          if (this.listBox1.Items[index].ToString().Substring(startIndex) == str)
            this.listBox1.SetItemCheckState(index, CheckState.Unchecked);
        }
      }
    }

    private void FormViewCustomerOrder_Load(object sender, EventArgs e)
    {
      switch (FormColumnOrder.FormType)
      {
        case "RedemptionReports":
          this.getListItems(" t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16");
          break;
        case "PledgeReports":
          this.getListItems("p2.ShopCode,p2.BillNumber,p2.OldBillNumber, p2.BillDate, p2.CustomerCode,nameAndAddress,p2.amount, p2.PresentValue, p2.NetWeight, p2.InterestRate, p2.TYPE, articles,p2.BankCode,p2.BankSerialNumber,p2.redeemed,p2.FinalInterest,p2.RedemptionAmount,p2.RedemptionDate");
          this.UncheckTheHiddenColumns();
          break;
        case "ViewCustomer":
          this.getListItems(" p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber,p.articles,p.PresentValue ,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.CustomerCode,p.customername as nameandaddress,P.PHONENUMBER,p.type");
          break;
        case "PledgeScreenPendingPledge":
          this.getListItems(" BillNumber,BillDate,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight, articles,BankCode,BankSerialNumber,SHOPCODE,customerCode,customername as nameAndAddress,type");
          this.UncheckTheHiddenColumns();
          break;
        case "LedgerScreen1":
          this.getListItems("p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,RedemptionAmount16 as RedemptionAmount,REdemptionDate,RedemptionBillNumber");
          break;
        case "LedgerScreen2":
          this.getListItems("p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,temp4 as RedemptionAmount,REdemptionDate,RedemptionBillNumber");
          break;
        case "PledgeBookScreen1":
          this.getListItems("p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight, articles ,p.Redeemed,p.redemptionamount16 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber,p.AuctionDate,p.AuctionAmount");
          this.UncheckTheHiddenColumns();
          break;
        case "PledgeBookScreen2":
          this.getListItems("p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight, articles ,p.Redeemed,p.temp4 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber,p.AuctionDate,p.AuctionAmount");
          this.UncheckTheHiddenColumns();
          break;
        case "PledgeScreenAll":
          this.getListItems(" BillNumber,BillDate,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight, articles,BankCode,BankSerialNumber,SHOPCODE,customerCode,customername as nameAndAddress,type,Redeemed,temp2 as Interest,temp3 as FinalInterest,temp4 as RedemptionAmount");
          this.UncheckTheHiddenColumns();
          break;
      }
    }

    private void glassButton3_Click(object sender, EventArgs e)
    {
      switch (FormColumnOrder.FormType)
      {
        case "RedemptionReports":
          this.save(" t.shopcode,t.billnumber,t.billdate,t.pledgebillnumber,t.customercode, NameAndAddress ,t.pledgedate,t.amount,p.grossweight,p.deduction,p.netweight, articles ,t.rateofinterest,t.interest,t.InterestLess,t.noticecharge,t.othercharge,t.deductions,t.finalinterest,t.totalredemptionamount,t.noofmonths,t.noofmonths16,t.interest16,t.redemptionamount16", "");
          break;
        case "PledgeReports":
          this.getListItems("p2.ShopCode,p2.BillNumber,p2.OldBillNumber, p2.BillDate, p2.CustomerCode,nameAndAddress,p2.amount, p2.PresentValue, p2.NetWeight, p2.InterestRate, p2.TYPE, articles,p2.BankCode,p2.BankSerialNumber,p2.redeemed,p2.FinalInterest,p2.RedemptionAmount,p2.RedemptionDate");
          this.UncheckTheHiddenColumns();
          break;
        case "ViewCustomer":
          this.save(" p.shopCode,p.BillNumber,p.BillDate,p.Amount,p.BankCode,p.BankSerialNumber,p.articles,p.PresentValue ,p.GrossWeight,p.Deduction,p.NetWeight,p.temp1 as InterestRate,p.CustomerCode,p.customername as nameandaddress,P.PHONENUMBER,p.type", "");
          break;
        case "PledgeScreenPendingPledge":
          this.save(" BillNumber,BillDate,Amount,temp1 as interestrate,PresentValue,GrossWeight,Deduction,NetWeight, articles,BankCode,BankSerialNumber,SHOPCODE,customerCode,customername as nameAndAddress,type,IntimationLetterSent,IntimationLetterSentOn,IntimationLetterPostalId,AuctionLetterSent,AuctionLetterSentOn,AuctionLetterPostalId", "");
          break;
        case "LedgerScreen1":
          this.save("p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,RedemptionAmount16 as RedemptionAmount,REdemptionDate,RedemptionBillNumber", "");
          break;
        case "LedgerScreen2":
          this.save("p.shopcode,p.BillNumber,p.OldBillNumber,p.BillDate,p.CustomerCode,nameAndAddress, p.Amount,p.PresentValue,p.NetWeight,articles,temp4 as RedemptionAmount,REdemptionDate,RedemptionBillNumber", "");
          break;
        case "PledgeBookScreen1":
          this.refreshListItems("p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight, articles ,p.Redeemed,p.redemptionamount16 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber,p.AuctionDate,p.AuctionAmount");
          this.UncheckTheHiddenColumns();
          break;
        case "PledgeBookScreen2":
          this.refreshListItems("p.shopCode,p.BillNumber,p.BillDate, nameAndAddress , p.Amount,p.PresentValue,p.NetWeight, articles ,p.Redeemed,p.temp4 as [Redemption Amount],p.RedemptionDate,p.RedemptionBillNumber,p.AuctionDate,p.AuctionAmount");
          this.UncheckTheHiddenColumns();
          break;
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
      this.panel2 = new Panel();
      this.glassButton3 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.btnAddArticles = new GlassButton();
      this.panel1 = new Panel();
      this.label9 = new Label();
      this.label7 = new Label();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.listBox1 = new CheckedListBox();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.panel2.BackColor = Color.Ivory;
      this.panel2.Controls.Add((Control) this.listBox1);
      this.panel2.Controls.Add((Control) this.glassButton3);
      this.panel2.Controls.Add((Control) this.glassButton2);
      this.panel2.Controls.Add((Control) this.glassButton1);
      this.panel2.Controls.Add((Control) this.btnAddArticles);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 41);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(307, 572);
      this.panel2.TabIndex = 11;
      this.glassButton3.BackColor = Color.White;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.Black;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.LightPink;
      this.glassButton3.InnerBorderColor = Color.Firebrick;
      ((Control) this.glassButton3).Location = new Point(9, 538);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MistyRose;
      this.glassButton3.ShineColor = Color.MistyRose;
      ((Control) this.glassButton3).Size = new Size(82, 30);
      ((Control) this.glassButton3).TabIndex = 8;
      ((Control) this.glassButton3).Text = "&Refresh";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Click += new EventHandler(this.glassButton3_Click);
      this.glassButton2.BackColor = Color.White;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.Black;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.LightPink;
      this.glassButton2.InnerBorderColor = Color.Firebrick;
      ((Control) this.glassButton2).Location = new Point(149, 538);
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
      ((Control) this.glassButton1).Location = new Point(226, 538);
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
      ((Control) this.btnAddArticles).Location = new Point(97, 538);
      ((Control) this.btnAddArticles).Name = "btnAddArticles";
      this.btnAddArticles.OuterBorderColor = Color.MistyRose;
      this.btnAddArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticles).Size = new Size(49, 30);
      ((Control) this.btnAddArticles).TabIndex = 5;
      ((Control) this.btnAddArticles).Text = "&Up";
      ((ButtonBase) this.btnAddArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticles).Click += new EventHandler(this.button1_Click);
      this.panel1.BackColor = Color.Firebrick;
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(307, 32);
      this.panel1.TabIndex = 9;
      this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label9.AutoSize = true;
      this.label9.Cursor = Cursors.Hand;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Cornsilk;
      this.label9.Location = new Point(258, 7);
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
      this.tableLayoutPanel1.Size = new Size(313, 616);
      this.tableLayoutPanel1.TabIndex = 14;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(9, 8);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(284, 514);
      this.listBox1.TabIndex = 9;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(313, 616);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormColumnOrder);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormColumnOrder);
      this.Load += new EventHandler(this.FormViewCustomerOrder_Load);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
