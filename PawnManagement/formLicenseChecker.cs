

using Glass;
using Microsoft.Win32;
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class formLicenseChecker : Form
  {
    private RegistryKey baseRegistryKey = Registry.LocalMachine;
    private string subKey = "SOFTWARE\\Windows102\\CurrentTime";
    private readonly string adminPwd = "#september12345#";
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label lblLicenseStatus;
    private Label label2;
    private DateTimePicker dateTimePicker1;
    private Label label3;
    private TextBox textBox1;
    private Label lblStatus;
    private GlassButton glassButton1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private GlassButton glassButton2;

    public formLicenseChecker()
    {
      this.InitializeComponent();
      this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
      this.lblStatus.Text = "";
      this.GetLicenseStatus();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!this.textBox1.Text.Equals(this.adminPwd))
        return;
      string strError = "";
      if (this.Write("NET8", (object) this.dateTimePicker1.Value.Ticks, ref strError))
        this.lblStatus.Text = "New license activated till : " + this.dateTimePicker1.Text;
      else
        this.lblStatus.Text = "An error occurred while activating license. Please make sure you have administrator rights";
    }

    private void GetLicenseStatus()
    {
      string strError = "";
      string str = this.Read("NET8", ref strError);
      if (str == null)
        this.lblLicenseStatus.Text = "License not activated";
      else
        this.lblLicenseStatus.Text = "License activated till " + new DateTime(Convert.ToInt64(str)).ToString("dd/MM/yyyy");
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public string Read(string KeyName, ref string strError)
    {
      RegistryKey registryKey = this.baseRegistryKey.OpenSubKey(this.subKey);
      if (registryKey == null)
        return (string) null;
      try
      {
        return (string) registryKey.GetValue(KeyName.ToUpper());
      }
      catch (Exception ex)
      {
        strError = ex.Message;
        return (string) null;
      }
    }

    public bool Write(string KeyName, object Value, ref string strError)
    {
      try
      {
        this.baseRegistryKey.CreateSubKey(this.subKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue(KeyName.ToUpper(), Value);
        return true;
      }
      catch (Exception ex)
      {
        strError = ex.Message;
        return false;
      }
    }

    private void formLicenseChecker_Load(object sender, EventArgs e)
    {
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.lblLicenseStatus = new Label();
      this.label2 = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.label3 = new Label();
      this.textBox1 = new TextBox();
      this.lblStatus = new Label();
      this.glassButton1 = new GlassButton();
      this.panel1 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.glassButton2 = new GlassButton();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.MediumBlue;
      this.label1.Location = new Point(70, 41);
      this.label1.Name = "label1";
      this.label1.Size = new Size(173, 20);
      this.label1.TabIndex = 5;
      this.label1.Text = "Current License Info";
      this.lblLicenseStatus.AutoSize = true;
      this.lblLicenseStatus.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLicenseStatus.ForeColor = System.Drawing.Color.MediumBlue;
      this.lblLicenseStatus.Location = new Point(249, 41);
      this.lblLicenseStatus.Name = "lblLicenseStatus";
      this.lblLicenseStatus.Size = new Size(57, 20);
      this.lblLicenseStatus.TabIndex = 0;
      this.lblLicenseStatus.Text = "label2";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.MediumBlue;
      this.label2.Location = new Point(38, 70);
      this.label2.Name = "label2";
      this.label2.Size = new Size(205, 20);
      this.label2.TabIndex = 6;
      this.label2.Text = "Reactivate License untill";
      this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new Point(249, 64);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(156, 26);
      this.dateTimePicker1.TabIndex = 1;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.MediumBlue;
      this.label3.Location = new Point(43, 102);
      this.label3.Name = "label3";
      this.label3.Size = new Size(200, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Retype admin password";
      this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(249, 96);
      this.textBox1.Name = "textBox1";
      this.textBox1.PasswordChar = '#';
      this.textBox1.Size = new Size(156, 26);
      this.textBox1.TabIndex = 2;
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblStatus.ForeColor = System.Drawing.Color.MediumBlue;
      this.lblStatus.Location = new Point(163, 137);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(80, 20);
      this.lblStatus.TabIndex = 4;
      this.lblStatus.Text = "lblStatus";
      this.glassButton1.BackColor = System.Drawing.Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = System.Drawing.Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = System.Drawing.Color.Red;
      this.glassButton1.ForeColorOnLeave = System.Drawing.Color.MediumBlue;
      this.glassButton1.GlowColor = System.Drawing.Color.White;
      this.glassButton1.InnerBorderColor = System.Drawing.Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(74, 190);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = System.Drawing.Color.MediumSlateBlue;
      this.glassButton1.ShineColor = System.Drawing.Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(180, 54);
      ((Control) this.glassButton1).TabIndex = 3;
      ((Control) this.glassButton1).Text = "&ACTIVATE";
      ((Control) this.glassButton1).Click += new EventHandler(this.button1_Click);
      this.panel1.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(687, 349);
      this.panel1.TabIndex = 8;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.09363f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.90636f));
      this.tableLayoutPanel1.Size = new Size(687, 349);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(681, 81);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = System.Drawing.Color.Black;
      this.label7.Location = new Point(210, 18);
      this.label7.Name = "label7";
      this.label7.Size = new Size(221, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "LICENSE MASTER";
      this.panel3.BackColor = System.Drawing.Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.glassButton2);
      this.panel3.Controls.Add((Control) this.lblStatus);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.textBox1);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Controls.Add((Control) this.lblLicenseStatus);
      this.panel3.Controls.Add((Control) this.dateTimePicker1);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 90);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(681, 256);
      this.panel3.TabIndex = 11;
      this.glassButton2.BackColor = System.Drawing.Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = System.Drawing.Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = System.Drawing.Color.Red;
      this.glassButton2.ForeColorOnLeave = System.Drawing.Color.MediumBlue;
      this.glassButton2.GlowColor = System.Drawing.Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.EXIT;
      this.glassButton2.InnerBorderColor = System.Drawing.Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(260, 190);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = System.Drawing.Color.MediumSlateBlue;
      this.glassButton2.ShineColor = System.Drawing.Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(180, 54);
      ((Control) this.glassButton2).TabIndex = 13;
      ((Control) this.glassButton2).Text = "&Exit";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(687, 349);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (formLicenseChecker);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "License Master";
      this.Load += new EventHandler(this.formLicenseChecker_Load);
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
