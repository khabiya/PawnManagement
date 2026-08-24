
using Square;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormPledgeErorr : Form
  {
    private DataTable dtPledge = new DataTable();
    private IContainer components = (IContainer) null;
    private SquareButton squareButton1;

    public FormPledgeErorr() => this.InitializeComponent();

    private void squareButton1_Click(object sender, EventArgs e)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = "";
      string str8 = "";
      string str9 = "";
      string str10 = "";
      string str11 = "";
      string str12 = "";
      string str13 = "";
      string str14 = "";
      string str15 = "";
      string str16 = "";
      string str17 = "";
      string str18 = "";
      string str19 = "";
      foreach (DataRow row in (InternalDataCollectionBase) this.dtPledge.Rows)
      {
        if (row["BillNumber"] == null)
          str1 = str1 + row["ID"].ToString() + Environment.NewLine;
        if (row["BillNumber"] != null && row["BillNumber"].ToString().Trim() == "")
          str2 = str2 + row["ID"].ToString() + Environment.NewLine;
        if (((row["BillDate"] == null ? 1 : 0) | (row["BillDate"] == null ? 0 : (row["BillDate"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str3 = str3 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["CustomerCode"] == null ? 1 : 0) | (row["CustomerCode"] == null ? 0 : (row["CustomerCode"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str4 = str4 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["CustomerName"] == null ? 1 : 0) | (row["CustomerName"] == null ? 0 : (row["CustomerName"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str5 = str5 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["AmountInWords"] == null ? 1 : 0) | (row["AmountInWords"] == null ? 0 : (row["AmountInWords"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str6 = str6 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["Type"] == null ? 1 : 0) | (row["Type"] == null ? 0 : (row["Type"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str7 = str7 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["GrossWeight"] == null ? 1 : 0) | (row["GrossWeight"] == null ? 0 : (row["GrossWeight"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str8 = str8 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["Deduction"] == null ? 1 : 0) | (row["Deduction"] == null ? 0 : (row["Deduction"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str9 = str9 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["NetWeight"] == null ? 1 : 0) | (row["NetWeight"] == null ? 0 : (row["NetWeight"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str10 = str10 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["PureWeight"] == null ? 1 : 0) | (row["PureWEight"] == null ? 0 : (row["PureWeight"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str11 = str11 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["Amount"] == null ? 1 : 0) | (row["Amount"] == null ? 0 : (row["Amount"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str12 = str12 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["PresentValue"] == null ? 1 : 0) | (row["PresentValue"] == null ? 0 : (row["PresentValue"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str14 = str14 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["temp1"] == null ? 1 : 0) | (row["temp1"] == null ? 0 : (row["temp1"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str13 = str13 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["Redeemed"] == null ? 1 : 0) | (row["Redeemed"] == null ? 0 : (row["Redeemed"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str15 = str15 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["temp5"] == null ? 1 : 0) | (row["temp5"] == null ? 0 : (row["temp5"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str19 = str19 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["Articles"] == null ? 1 : 0) | (row["Articles"] == null ? 0 : (row["Articles"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str16 = str16 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["ArticlesWithoutHr"] == null ? 1 : 0) | (row["ArticlesWithoutHr"] == null ? 0 : (row["ArticlesWithoutHr"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str17 = str17 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
        if (((row["ArticlesWithHr"] == null ? 1 : 0) | (row["ArticlesWithHr"] == null ? 0 : (row["ArticlesWithHr"].ToString().Trim() == "" ? 1 : 0))) != 0)
          str18 = str18 + row["ID"].ToString() + " - " + row["BillNumber"].ToString() + Environment.NewLine;
      }
      File.AppendAllText("ErrorsScan.txt", " Rows With BillNumber Null" + Environment.NewLine + str1 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With BillNumber Empty" + Environment.NewLine + str2 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With BillDate Empty" + Environment.NewLine + str3 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With CustomerCode Empty" + Environment.NewLine + str4 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With CustomerName empty" + Environment.NewLine + str5 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With AmountInWords Empty" + Environment.NewLine + str6 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With Type Empty" + Environment.NewLine + str7 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With GrossWEight Empty" + Environment.NewLine + str8 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With Deduction Empty" + Environment.NewLine + str9 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With NetWEight Empty" + Environment.NewLine + str10 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With Amount Empty" + Environment.NewLine + str12 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With PresentValue Empty" + Environment.NewLine + str14 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With Redeemed Empty" + Environment.NewLine + str15 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With Articles Empty" + Environment.NewLine + str16 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With temp1 Empty" + Environment.NewLine + str13 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With ArticlesWithtoutHr Empty" + Environment.NewLine + str17 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With ArticlesWithHr Empty" + Environment.NewLine + str18 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With PureWeight Empty" + Environment.NewLine + str11 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", " Rows With temp5 Empty" + Environment.NewLine + str19 + Environment.NewLine);
    }

    private void FormPledgeErorr_Load(object sender, EventArgs e) => this.dtPledge = PawnManagementClass.getDataTable("tblPledge");

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.squareButton1 = new SquareButton();
      this.SuspendLayout();
      this.squareButton1.BackColor = Color.LightBlue;
      this.squareButton1.FadeOnFocus = true;
      this.squareButton1.ForeColor = Color.MediumBlue;
      this.squareButton1.ForeColorOnFocus = Color.Red;
      this.squareButton1.ForeColorOnLeave = Color.MediumBlue;
      this.squareButton1.GlowColor = Color.White;
      this.squareButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.squareButton1).Location = new Point(790, 43);
      ((Control) this.squareButton1).Name = "squareButton1";
      this.squareButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.squareButton1.ShineColor = Color.Transparent;
      ((Control) this.squareButton1).Size = new Size(75, 23);
      ((Control) this.squareButton1).TabIndex = 0;
      ((Control) this.squareButton1).Text = "squareButton1";
      ((Control) this.squareButton1).Click += new EventHandler(this.squareButton1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 631);
      this.Controls.Add((Control) this.squareButton1);
      this.Name = nameof (FormPledgeErorr);
      this.Text = nameof (FormPledgeErorr);
      this.Load += new EventHandler(this.FormPledgeErorr_Load);
      this.ResumeLayout(false);
    }
  }
}
