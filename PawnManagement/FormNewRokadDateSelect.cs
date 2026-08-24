

using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormNewRokadDateSelect : Form
  {
    private string openingBalance = "";
    private string newRokadDate = "";
    private IContainer components = (IContainer) null;
    private TextBox textBox1;
    private GlassButton glassButton1;
    private DateTimePicker dateTimePicker1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;

    public FormNewRokadDateSelect() => this.InitializeComponent();

    public FormNewRokadDateSelect(string NEWROKADDATE, string OPENINGBALANCE)
    {
      this.newRokadDate = NEWROKADDATE;
      this.openingBalance = OPENINGBALANCE;
      this.InitializeComponent();
    }

    private void FormNewRokadDateSelect_Load(object sender, EventArgs e) => this.textBox1.Text = this.newRokadDate;

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (DateTime.Parse(this.textBox1.Text.Trim().ToString()) >= DateTime.Parse(this.newRokadDate))
      {
        this.insertNewRokadDate(this.textBox1.Text.Trim().ToString());
        this.Close();
      }
      else
      {
        int num = (int) MessageBox.Show("Invalid date");
      }
    }

    private void insertNewRokadDate(string newRokadDate)
    {
      string strError = "";
      if (SQLHelper.RunCommand("insert into tblRokadDetails(RokadDate,OpeningBalance,CurrentDay) values(@RokadDate,@OpeningBalance,@CurrentDay)", new List<OleDbParameter>()
      {
        new OleDbParameter("RokadDate", (object) this.textBox1.Text.Trim().ToString()),
        new OleDbParameter("OpeningBalance", (object) this.openingBalance),
        new OleDbParameter("CurrentDay", (object) "Y")
      }, ref strError) == "Done")
      {
        int num1 = (int) MessageBox.Show("Successfully Updated");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error ... Try from beginning");
      }
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => this.textBox1.Text = this.dateTimePicker1.Value.ToString("dd/MM/yyyy");

    private void FormNewRokadDateSelect_FormClosing(object sender, FormClosingEventArgs e)
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
      this.textBox1 = new TextBox();
      this.glassButton1 = new GlassButton();
      this.dateTimePicker1 = new DateTimePicker();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(128, 71);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(194, 29);
      this.textBox1.TabIndex = 1;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(158, 106);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(143, 36);
      ((Control) this.glassButton1).TabIndex = 3;
      ((Control) this.glassButton1).Text = "OK";
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dateTimePicker1.Format = DateTimePickerFormat.Short;
      this.dateTimePicker1.Location = new Point(328, 69);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(14, 31);
      this.dateTimePicker1.TabIndex = 4;
      this.dateTimePicker1.ValueChanged += new EventHandler(this.dateTimePicker1_ValueChanged);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.93356f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.06644f));
      this.tableLayoutPanel1.Size = new Size(460, 301);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(454, 54);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(118, 11);
      this.label7.Name = "label7";
      this.label7.Size = new Size(239, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "SELECT NEW DATE";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.dateTimePicker1);
      this.panel3.Controls.Add((Control) this.textBox1);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 63);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(454, 235);
      this.panel3.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(460, 301);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.Name = nameof (FormNewRokadDateSelect);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormNewRokadDateSelect);
      this.FormClosing += new FormClosingEventHandler(this.FormNewRokadDateSelect_FormClosing);
      this.Load += new EventHandler(this.FormNewRokadDateSelect_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
