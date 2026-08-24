

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
  public class FormChangeInterest : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox tbxFromAmount;
    private TextBox tbxToAmount;
    private TextBox tbxInterestRate;
    private ComboBox cbType;
    private TextBox tbxToDate;
    private TextBox tbxFromDate;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private GlassButton glassButton1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private GlassButton glassButton2;
    private Label label8;
    private ComboBox cbShopCodes;

    public FormChangeInterest() => this.InitializeComponent();

    private void getShopCodes()
    {
      foreach (DataRow row in (InternalDataCollectionBase) PawnManagementClass.getShopCodes().Rows)
        this.cbShopCodes.Items.Add((object) row["ShopCode"].ToString());
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!this.checkForValidation() || DialogResult.Yes != MessageBox.Show("Are you sure ", "Update Interest?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
        return;
      this.updateInterest();
      this.Close();
    }

    private void updateInterest()
    {
      string strError = "";
      string str = SQLHelper.RunCommand("update tblPledge set TEMP1 = @InterestRate where (BillDate >= @FromDate and BillDate <= @ToDate) and type = @Type and (amount > @FromAmount and amount <= @ToAmount) and redeemed = 'N'  and shopCode=@ShopCode", new List<OleDbParameter>()
      {
        new OleDbParameter("InterestRate", (object) this.tbxInterestRate.Text.Trim().ToString()),
        new OleDbParameter("FromDate", (object) this.tbxFromDate.Text.Trim().ToString()),
        new OleDbParameter("ToDate", (object) this.tbxToDate.Text.Trim().ToString()),
        new OleDbParameter("Type", (object) this.cbType.Text.Trim().ToString()),
        new OleDbParameter("FromAmount", (object) this.tbxFromAmount.Text.Trim().ToString()),
        new OleDbParameter("ToAmount", (object) this.tbxToAmount.Text.Trim().ToString()),
        new OleDbParameter("ShopCode", (object) this.cbShopCodes.Text)
      }, ref strError);
      if (str != "Done")
      {
        int num = (int) MessageBox.Show("Error IN UPDATING interest " + strError);
        PawnManagementClass.InsertIntoException("form changeinterest.updateinterest", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        if (!(str == "Done"))
          return;
        PawnManagementClass.InsertIntoHistory("Interest Change", "Interest changed", "", "from " + this.tbxFromDate.Text + " to date: " + this.tbxToDate.Text + " type = " + this.cbType.Text + " from amount:" + this.tbxFromAmount.Text + " to amount: " + this.tbxToAmount.Text + "InterestRate :" + this.tbxInterestRate.Text, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Successfully updated");
      }
    }

    private bool checkForValidation()
    {
      if (this.cbShopCodes.Text.Trim() != "")
      {
        if (PawnManagementClass.checkForValidateDate(this.tbxFromDate.Text))
        {
          if (PawnManagementClass.checkForValidateDate(this.tbxToDate.Text))
          {
            if (DateTime.Parse(this.tbxToDate.Text).Subtract(DateTime.Parse(this.tbxFromDate.Text)).Days > 0)
            {
              if (this.cbType.Text != "")
              {
                if (this.tbxFromAmount.Text != "" && (double) float.Parse(this.tbxFromAmount.Text) > 0.0)
                {
                  if (this.tbxToAmount.Text != "" && (double) float.Parse(this.tbxToAmount.Text) > (double) float.Parse(this.tbxFromAmount.Text))
                  {
                    if (this.tbxInterestRate.Text != "" && (double) float.Parse(this.tbxInterestRate.Text) > 0.0)
                      return true;
                    this.tbxInterestRate.Select();
                  }
                  else
                    this.tbxToAmount.Select();
                }
                else
                  this.tbxFromAmount.Select();
              }
              else
                this.cbType.Select();
            }
            else
              this.tbxToDate.Select();
          }
          else
            this.tbxToDate.Select();
        }
        else
          this.tbxFromDate.Select();
      }
      else
        this.cbShopCodes.Select();
      return false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormChangeInterest_Load(object sender, EventArgs e)
    {
      this.getShopCodes();
      if (this.cbShopCodes.Items.Count > 0)
        this.cbShopCodes.SelectedIndex = 0;
      this.cbShopCodes.Text = PawnManagementClass.getDefaultLicenseCode();
      if (this.cbType.Items.Count <= 0)
        return;
      this.cbType.SelectedIndex = 0;
    }

    private void cbType_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void tbxFromAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxToAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxInterestRate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxToDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.Close();

    private void cbShopCodes_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxFromAmount = new TextBox();
      this.tbxToAmount = new TextBox();
      this.tbxInterestRate = new TextBox();
      this.cbType = new ComboBox();
      this.tbxToDate = new TextBox();
      this.tbxFromDate = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.glassButton1 = new GlassButton();
      this.panel1 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.label8 = new Label();
      this.cbShopCodes = new ComboBox();
      this.glassButton2 = new GlassButton();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.tbxFromAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromAmount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromAmount.Location = new Point(198, 175);
      this.tbxFromAmount.Name = "tbxFromAmount";
      this.tbxFromAmount.Size = new Size(237, 31);
      this.tbxFromAmount.TabIndex = 3;
      this.tbxFromAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxFromAmount.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.tbxFromAmount.KeyPress += new KeyPressEventHandler(this.tbxFromAmount_KeyPress);
      this.tbxToAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToAmount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToAmount.Location = new Point(198, 218);
      this.tbxToAmount.Name = "tbxToAmount";
      this.tbxToAmount.Size = new Size(237, 31);
      this.tbxToAmount.TabIndex = 4;
      this.tbxToAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxToAmount.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.tbxToAmount.KeyPress += new KeyPressEventHandler(this.tbxToAmount_KeyPress);
      this.tbxInterestRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterestRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxInterestRate.Location = new Point(197, 263);
      this.tbxInterestRate.Name = "tbxInterestRate";
      this.tbxInterestRate.Size = new Size(237, 31);
      this.tbxInterestRate.TabIndex = 5;
      this.tbxInterestRate.TextAlign = HorizontalAlignment.Right;
      this.tbxInterestRate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.tbxInterestRate.KeyPress += new KeyPressEventHandler(this.tbxInterestRate_KeyPress);
      this.cbType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[3]
      {
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(198, 130);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(236, 33);
      this.cbType.TabIndex = 2;
      this.cbType.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.cbType.KeyPress += new KeyPressEventHandler(this.cbType_KeyPress);
      this.tbxToDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxToDate.Location = new Point(198, 92);
      this.tbxToDate.Name = "tbxToDate";
      this.tbxToDate.Size = new Size(237, 31);
      this.tbxToDate.TabIndex = 1;
      this.tbxToDate.TextAlign = HorizontalAlignment.Center;
      this.tbxToDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.tbxFromDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxFromDate.Location = new Point(197, 51);
      this.tbxFromDate.Name = "tbxFromDate";
      this.tbxFromDate.Size = new Size(237, 31);
      this.tbxFromDate.TabIndex = 0;
      this.tbxFromDate.TextAlign = HorizontalAlignment.Center;
      this.tbxFromDate.KeyDown += new KeyEventHandler(this.tbxToDate_KeyDown);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(85, 53);
      this.label1.Name = "label1";
      this.label1.Size = new Size(106, 26);
      this.label1.TabIndex = 7;
      this.label1.Text = "From Date";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(109, 95);
      this.label2.Name = "label2";
      this.label2.Size = new Size(82, 26);
      this.label2.TabIndex = 8;
      this.label2.Text = "To Date";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(136, 135);
      this.label3.Name = "label3";
      this.label3.Size = new Size(55, 26);
      this.label3.TabIndex = 9;
      this.label3.Text = "Type";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(40, 177);
      this.label4.Name = "label4";
      this.label4.Size = new Size(151, 26);
      this.label4.TabIndex = 10;
      this.label4.Text = "From Amount >";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(53, 221);
      this.label5.Name = "label5";
      this.label5.Size = new Size(138, 26);
      this.label5.TabIndex = 11;
      this.label5.Text = "To Amount <=";
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(108, 266);
      this.label6.Name = "label6";
      this.label6.Size = new Size(83, 26);
      this.label6.TabIndex = 12;
      this.label6.Text = "Interest";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.reset;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(446, 19);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(180, 54);
      ((Control) this.glassButton1).TabIndex = 6;
      ((Control) this.glassButton1).Text = "&Update";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.panel1.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(650, 382);
      this.panel1.TabIndex = 13;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.59627f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85.40372f));
      this.tableLayoutPanel1.Size = new Size(650, 382);
      this.tableLayoutPanel1.TabIndex = 11;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(644, 49);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(191, 6);
      this.label7.Name = "label7";
      this.label7.Size = new Size(241, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "CHANGE INTEREST";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.label8);
      this.panel3.Controls.Add((Control) this.cbShopCodes);
      this.panel3.Controls.Add((Control) this.glassButton2);
      this.panel3.Controls.Add((Control) this.tbxFromDate);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.tbxFromAmount);
      this.panel3.Controls.Add((Control) this.label6);
      this.panel3.Controls.Add((Control) this.tbxToAmount);
      this.panel3.Controls.Add((Control) this.label5);
      this.panel3.Controls.Add((Control) this.tbxInterestRate);
      this.panel3.Controls.Add((Control) this.label4);
      this.panel3.Controls.Add((Control) this.cbType);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Controls.Add((Control) this.tbxToDate);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 58);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(644, 321);
      this.panel3.TabIndex = 11;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkBlue;
      this.label8.Location = new Point(53, 16);
      this.label8.Name = "label8";
      this.label8.Size = new Size(138, 26);
      this.label8.TabIndex = 26;
      this.label8.Text = "Select License";
      this.cbShopCodes.BackColor = Color.AliceBlue;
      this.cbShopCodes.DropDownWidth = 600;
      this.cbShopCodes.FormattingEnabled = true;
      this.cbShopCodes.Location = new Point(197, 19);
      this.cbShopCodes.Name = "cbShopCodes";
      this.cbShopCodes.Size = new Size(238, 21);
      this.cbShopCodes.TabIndex = 25;
      this.cbShopCodes.KeyPress += new KeyPressEventHandler(this.cbShopCodes_KeyPress);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.EXIT;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(446, 87);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(180, 54);
      ((Control) this.glassButton2).TabIndex = 13;
      ((Control) this.glassButton2).Text = "&Exit";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.White;
      this.ClientSize = new Size(650, 382);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (FormChangeInterest);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormChangeInterest);
      this.Load += new EventHandler(this.FormChangeInterest_Load);
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
