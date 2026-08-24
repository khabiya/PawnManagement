
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
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormReplaceDuplicateAddress : Form
  {
    private List<string> lstAddress = new List<string>();
    private List<string> lstAddress2 = new List<string>();
    private IContainer components = (IContainer) null;
    private HeaderPanel headerPanel1;
    private Label label2;
    private Label label1;
    private GlassButton glassButton1;
    private TextBox textBox2;
    private TextBox textBox1;

    public FormReplaceDuplicateAddress() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormReplaceDuplicateAddress_Load(object sender, EventArgs e)
    {
      this.getAddress();
      this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.textBox1.AutoCompleteCustomSource.AddRange(this.lstAddress.ToArray());
      this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.textBox2.AutoCompleteCustomSource.AddRange(this.lstAddress2.ToArray());
    }

    private void getAddress()
    {
      try
      {
        string strError = "";
        string my_querry = "Select distinct CAddr1 from tblCustomers";
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
        if (strError != "")
        {
          int num = (int) MessageBox.Show("Error in retrieving address" + strError);
          PawnManagementClass.InsertIntoException("Form AddCustomer.getAddress() innerException", strError, FormMain.username, DateTime.Now.ToString());
        }
        else
        {
          this.lstAddress.Clear();
          this.lstAddress2.Clear();
          foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
          {
            this.lstAddress.Add(row["CAddr1"].ToString());
            this.lstAddress2.Add(row["CAddr1"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form  addcustomer.getaddress()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      string strError1 = "";
      if (SQLHelper.RunCommand("update tblCustomers set CAddr1 = @CAddr1 where CAddr1 = @CAddr2", new List<OleDbParameter>()
      {
        new OleDbParameter("CAddr1", (object) this.textBox2.Text),
        new OleDbParameter("CAddr2", (object) this.textBox1.Text)
      }, ref strError1) == "Done")
      {
        int num1 = (int) MessageBox.Show("Successfully updated in customer tables");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error while updating");
      }
      string strError2 = "";
      if (SQLHelper.RunCommand("update tblPledge set Addr1 = @Addr1 where Addr1 = @Addr2", new List<OleDbParameter>()
      {
        new OleDbParameter("Addr1", (object) this.textBox2.Text),
        new OleDbParameter("Addr2", (object) this.textBox1.Text)
      }, ref strError2) == "Done")
      {
        int num3 = (int) MessageBox.Show("Successfully updated in pledge table");
      }
      else
      {
        int num4 = (int) MessageBox.Show("Error while updating");
      }
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.headerPanel1 = new HeaderPanel();
      this.label2 = new Label();
      this.label1 = new Label();
      this.glassButton1 = new GlassButton();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      ((Control) this.headerPanel1).Anchor = AnchorStyles.None;
      this.headerPanel1.BorderColor = SystemColors.ActiveCaption;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.MidnightBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Horizontal;
      this.headerPanel1.CaptionHeight = 33;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "Find and Replace Addr1";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.label2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.label1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.textBox2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.textBox1);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.White;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.PowderBlue;
      this.headerPanel1.GradientStart = Color.AliceBlue;
      ((Control) this.headerPanel1).Location = new Point(254, 75);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = true;
      ((Control) this.headerPanel1).Size = new Size(485, 227);
      ((Control) this.headerPanel1).TabIndex = 0;
      this.headerPanel1.TextAntialias = true;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(54, 82);
      this.label2.Name = "label2";
      this.label2.Size = new Size(53, 21);
      this.label2.TabIndex = 4;
      this.label2.Text = "Addr2";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(52, 29);
      this.label1.Name = "label1";
      this.label1.Size = new Size(53, 21);
      this.label1.TabIndex = 3;
      this.label1.Text = "Addr1";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(197, 130);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(137, 34);
      ((Control) this.glassButton1).TabIndex = 2;
      ((Control) this.glassButton1).Text = "&REPLACE";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.textBox2.Location = new Point(110, 77);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(335, 33);
      this.textBox2.TabIndex = 1;
      this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.textBox1.Location = new Point(110, 24);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(335, 33);
      this.textBox1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormReplaceDuplicateAddress);
      this.Text = nameof (FormReplaceDuplicateAddress);
      this.Load += new EventHandler(this.FormReplaceDuplicateAddress_Load);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
