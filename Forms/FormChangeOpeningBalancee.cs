
using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormChangeOpeningBalancee : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private TextBox tbxNewOpeningBalance;
    private Label label3;
    private TextBox tbxRokadDate;
    private TextBox tbxOldOpeningBalance;
    private Label label2;
    private Label label1;
    private GlassButton btnFinishRokad;

    public FormChangeOpeningBalancee() => this.InitializeComponent();

    private void panel3_Paint(object sender, PaintEventArgs e)
    {
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void getOpeningBalance(DateTime d1)
    {
      string strError = "";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      string my_querry = "select * from tblRokadDetails where rokadDate = @rokadDate";
      parameters.Add(new OleDbParameter("rokadDate", (object) d1.ToString("dd/MM/yyyy")));
      DataTable dataTable = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("Form rokad.getopeneingbalance", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Form rokad.getopeneingbalance \n" + strError);
      }
      else if (dataTable != null && dataTable.Rows.Count > 0)
        this.tbxOldOpeningBalance.Text = dataTable.Rows[0]["OpeningBalance"].ToString();
    }

    private void tbxAcceptDecimal(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void FormChangeOpeningBalancee_Load(object sender, EventArgs e)
    {
      DateTime d1 = DateTime.Parse((!(PawnManagementClass.getRokadDate() != "") ? (object) DateTime.Now.ToString("dd/MM/yyyy") : (object) PawnManagementClass.getRokadDate()).ToString());
      this.tbxRokadDate.Text = d1.ToShortDateString();
      this.getOpeningBalance(d1);
    }

    private void tbxOldOpeningBalance_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void btnFinishRokad_Click(object sender, EventArgs e)
    {
      if (PawnManagementClass.checkForValidateDate(this.tbxRokadDate.Text))
      {
        if (this.tbxNewOpeningBalance.Text != "")
        {
          if (double.Parse(this.tbxNewOpeningBalance.Text) <= 0.0)
            return;
          this.changeOpeningBalance();
        }
        else
          this.tbxNewOpeningBalance.Select();
      }
      else
        this.tbxRokadDate.Select();
    }

    private void changeOpeningBalance()
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblRokadDetails set OpeningBalance= @OpeningBalance where rokaddate = @RokadDate", new List<OleDbParameter>()
      {
        new OleDbParameter("OpeningBalance", (object) this.tbxNewOpeningBalance.Text),
        new OleDbParameter("RokadDate", (object) this.tbxRokadDate.Text)
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form change opening balance.changeopeinigbalance()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form change opening balance.changeopeinigbalance()           ---" + strError);
      }
      else
      {
        int num1 = (int) MessageBox.Show("openingBalance changed successfully");
      }
    }

    private void tbxRokadDate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxNewOpeningBalance.Select();
    }

    private void tbxNewOpeningBalance_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnFinishRokad).Select();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.btnFinishRokad = new GlassButton();
      this.tbxNewOpeningBalance = new TextBox();
      this.label3 = new Label();
      this.tbxRokadDate = new TextBox();
      this.tbxOldOpeningBalance = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.86689f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.1331f));
      this.tableLayoutPanel1.Size = new Size(580, 293);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(574, 60);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(119, 13);
      this.label7.Name = "label7";
      this.label7.Size = new Size(347, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "CHANGE OPENING BALANCE";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnFinishRokad);
      this.panel3.Controls.Add((Control) this.tbxNewOpeningBalance);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Controls.Add((Control) this.tbxRokadDate);
      this.panel3.Controls.Add((Control) this.tbxOldOpeningBalance);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 69);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(574, 221);
      this.panel3.TabIndex = 11;
      this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
      ((Control) this.btnFinishRokad).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnFinishRokad.BackColor = Color.LightBlue;
      this.btnFinishRokad.FadeOnFocus = true;
      this.btnFinishRokad.ForeColor = Color.MediumBlue;
      this.btnFinishRokad.ForeColorOnFocus = Color.Red;
      this.btnFinishRokad.ForeColorOnLeave = Color.RoyalBlue;
      this.btnFinishRokad.GlowColor = Color.White;
      this.btnFinishRokad.InnerBorderColor = Color.Transparent;
      ((Control) this.btnFinishRokad).Location = new Point(192, 159);
      ((Control) this.btnFinishRokad).Name = "btnFinishRokad";
      this.btnFinishRokad.OuterBorderColor = Color.MediumSlateBlue;
      this.btnFinishRokad.ShineColor = Color.Transparent;
      ((Control) this.btnFinishRokad).Size = new Size(191, 34);
      ((Control) this.btnFinishRokad).TabIndex = 11;
      ((Control) this.btnFinishRokad).Text = "&CHANGE";
      ((Control) this.btnFinishRokad).Click += new EventHandler(this.btnFinishRokad_Click);
      this.tbxNewOpeningBalance.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNewOpeningBalance.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNewOpeningBalance.Location = new Point(299, 101);
      this.tbxNewOpeningBalance.Name = "tbxNewOpeningBalance";
      this.tbxNewOpeningBalance.Size = new Size(237, 31);
      this.tbxNewOpeningBalance.TabIndex = 9;
      this.tbxNewOpeningBalance.KeyDown += new KeyEventHandler(this.tbxNewOpeningBalance_KeyDown);
      this.tbxNewOpeningBalance.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(8, 104);
      this.label3.Name = "label3";
      this.label3.Size = new Size(285, 25);
      this.label3.TabIndex = 10;
      this.label3.Text = "NEW OPENING BALANCE";
      this.tbxRokadDate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxRokadDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxRokadDate.Location = new Point(299, 9);
      this.tbxRokadDate.Name = "tbxRokadDate";
      this.tbxRokadDate.Size = new Size(237, 31);
      this.tbxRokadDate.TabIndex = 0;
      this.tbxRokadDate.KeyDown += new KeyEventHandler(this.tbxRokadDate_KeyDown);
      this.tbxRokadDate.KeyPress += new KeyPressEventHandler(this.tbxOldOpeningBalance_KeyPress);
      this.tbxOldOpeningBalance.BorderStyle = BorderStyle.FixedSingle;
      this.tbxOldOpeningBalance.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxOldOpeningBalance.Location = new Point(299, 55);
      this.tbxOldOpeningBalance.Name = "tbxOldOpeningBalance";
      this.tbxOldOpeningBalance.Size = new Size(237, 31);
      this.tbxOldOpeningBalance.TabIndex = 1;
      this.tbxOldOpeningBalance.KeyDown += new KeyEventHandler(this.tbxRokadDate_KeyDown);
      this.tbxOldOpeningBalance.KeyPress += new KeyPressEventHandler(this.tbxOldOpeningBalance_KeyPress);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(67, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(226, 25);
      this.label2.TabIndex = 8;
      this.label2.Text = "OPENING BALANCE";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(135, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(158, 25);
      this.label1.TabIndex = 7;
      this.label1.Text = "ROKAD DATE";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(580, 293);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormChangeOpeningBalancee);
      this.Text = nameof (FormChangeOpeningBalancee);
      this.Load += new EventHandler(this.FormChangeOpeningBalancee_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
