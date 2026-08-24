
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
  public class FormUpdate : Form
  {
    private IContainer components = (IContainer) null;
    private RichTextBox richTextBox1;
    private TextBox textBox1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;

    public FormUpdate() => this.InitializeComponent();

    private void btnRunQuery_Click(object sender, EventArgs e)
    {
    }

    private void FormUpdate_Load(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      List<string> stringList = new List<string>();
      string strError = "";
      string my_querry = "select * from tblBankpledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form VocherAdd.gettblLedger", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving ledgertable" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          stringList.Add(row["BankBillNumber"].ToString());
      }
      foreach (string BankBillNumber in stringList)
        this.updateBankPledgeBillNumbers(BankBillNumber);
    }

    public void updateBankPledgeBillNumbers(string BankBillNumber)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblbankpledge set pledgebillnumbers = @PledgeBillNumbers where BankBillNumber = @BankBillNumber", new List<OleDbParameter>()
      {
        new OleDbParameter("PledgeBillNumbers", (object) this.getPledgeBillNumbers(BankBillNumber)),
        new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
      }, ref strError) == "Done"))
        ;
    }

    private string getPledgeBillNumbers(string BankBillNumber)
    {
      try
      {
        string strError = "";
        string my_querry = "select * from tblBankPledgePledgeBills where BankBillNumber = @BankBillNumber";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
        {
          new OleDbParameter(nameof (BankBillNumber), (object) BankBillNumber)
        }, ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("form VocherAdd.gettblLedger", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in retrieving ledgertable" + strError);
        }
        else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        {
          string pledgeBillNumbers = "";
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          {
            if (pledgeBillNumbers != "")
              pledgeBillNumbers += "  ";
            pledgeBillNumbers = pledgeBillNumbers + "[" + row["ShopCode"].ToString() + " " + row["PledgeBillNumber"].ToString() + " " + row["CustomerName"].ToString() + "]";
          }
          return pledgeBillNumbers;
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form AddVoucher.gettblledgertype", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      return "";
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Are you sure", " asdf", MessageBoxButtons.YesNo))
        return;
      string strError = "";
      string my_querry = "select * from tblpledge";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form VocherAdd.gettblLedger", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving ledgertable" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          this.updateTablePledgeWithArticles(row["BillNumber"].ToString(), this.getArticles(row["BillNumber"].ToString()));
      }
    }

    private void updateTablePledgeWithArticles(string strPledgeBillNumber, string strArticles)
    {
      string strError = "";
      SQLHelper.RunCommand("update tblPledge set  Articles = @Articles,ArticlesWithHr = @ArticlesWithHr,ArticlesWithoutHr = @ArticlesWithoutHr where BillNumber = @BillNumber ", new List<OleDbParameter>()
      {
        new OleDbParameter("Articles", (object) strArticles),
        new OleDbParameter("ArticlesWithHr", (object) strArticles),
        new OleDbParameter("ArticlesWithoutHr", (object) strArticles),
        new OleDbParameter("BillNumber", (object) strPledgeBillNumber)
      }, ref strError);
    }

    private string getArticles(string BillNumber)
    {
      string strError = "";
      string my_querry = "select * from tblpledgeArticles where BillNumber = @BillNumber";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (BillNumber), (object) BillNumber)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form VocherAdd.gettblLedger", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving ledgertable" + strError);
      }
      else if (dataTable2 != null & dataTable2.Rows.Count > 0)
      {
        string articles = "";
        foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
        {
          string str1 = ((row["Articles"] == null ? 1 : 0) | (row["Articles"] == null ? 0 : (row["Articles"].ToString() == "" ? 1 : 0))) != 0 ? "" : row["Articles"].ToString();
          string str2 = ((row["ArticlesDescription"] == null ? 1 : 0) | (row["ArticlesDescription"].ToString() == null ? 0 : (row["ArticlesDescription"].ToString() == "" ? 1 : 0))) != 0 ? "" : row["ArticlesDescription"].ToString();
          string str3 = ((row["Num"] == null ? 1 : 0) | (row["Num"] == null ? 0 : (row["Num"].ToString() == "" ? 1 : 0))) != 0 ? "" : row["Num"].ToString();
          if (articles == "")
            articles = articles + str1 + "(" + str2 + ")-" + str3;
          else
            articles = articles + "," + str1 + "(" + str2 + ")-" + str3;
        }
        return articles;
      }
      return "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.richTextBox1 = new RichTextBox();
      this.textBox1 = new TextBox();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.SuspendLayout();
      this.richTextBox1.Location = new Point(13, 13);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(993, 96);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      this.textBox1.Location = new Point(13, 117);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(221, 20);
      this.textBox1.TabIndex = 9;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(610, 307);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(346, 36);
      ((Control) this.glassButton1).TabIndex = 10;
      ((Control) this.glassButton1).Text = "Update Bank pledge bils";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(610, 349);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(346, 34);
      ((Control) this.glassButton2).TabIndex = 11;
      ((Control) this.glassButton2).Text = "Update articles from  pledge articles combined";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.richTextBox1);
      this.Name = nameof (FormUpdate);
      this.Text = nameof (FormUpdate);
      this.Load += new EventHandler(this.FormUpdate_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
