
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
  public class FormInactivityMonitor : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private GlassButton glassButton1;
    private ComboBox comboBox1;
    private TextBox textBox1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private GlassButton glassButton2;

    public FormInactivityMonitor() => this.InitializeComponent();

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.comboBox1.Text != "" && this.textBox1.Text.Trim() != "")
      {
        this.saveInactivityMonitorSettings();
      }
      else
      {
        int num = (int) MessageBox.Show("Enter time interval");
      }
    }

    private void saveInactivityMonitorSettings()
    {
      string strError = "";
      string text = SQLHelper.RunCommand("update tblMonitor set Inactivity = @Inactivity,MonitorInterval=@MonitorInterval ", new List<OleDbParameter>()
      {
        new OleDbParameter("Inactivity", (object) this.comboBox1.Text),
        new OleDbParameter("MonitorInterval", (object) (this.textBox1.Text + "000"))
      }, ref strError);
      if (text.Equals("Done"))
      {
        int num1 = (int) MessageBox.Show("Successfully saved");
      }
      else
      {
        PawnManagementClass.InsertIntoException("form inactivityMonitor.saveInactivityMonitorsettings", strError, FormMain.username, DateTime.Now.ToString());
        int num2 = (int) MessageBox.Show(text);
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormInactivityMonitor_Load(object sender, EventArgs e) => this.getMonitorVAlues();

    private void getMonitorVAlues()
    {
      try
      {
        string strError = "";
        DataTable dataTable = SQLHelper.GetDataTable("select * from tblMonitor", ref strError);
        if (strError != "")
        {
          PawnManagementClass.InsertIntoException("Form inactivitymonitor.getmotiorevalues()", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("form inactivitymonitor.getmonitorvalues()" + strError);
        }
        else if (dataTable != null && dataTable.Rows.Count > 0)
        {
          this.comboBox1.Text = dataTable.Rows[0]["inactivity"].ToString();
          this.textBox1.Text = (double.Parse(dataTable.Rows[0]["MonitorInterval"].ToString()) / 1000.0).ToString();
        }
        else
        {
          int num1 = (int) MessageBox.Show("monitor values not set");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form LoginDetails populateMemberId", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
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
      this.label2 = new Label();
      this.glassButton1 = new GlassButton();
      this.comboBox1 = new ComboBox();
      this.textBox1 = new TextBox();
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
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(107, 46);
      this.label1.Name = "label1";
      this.label1.Size = new Size(194, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "InActivity Monitor";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(124, 102);
      this.label2.Name = "label2";
      this.label2.Size = new Size(177, 25);
      this.label2.TabIndex = 1;
      this.label2.Text = "Time (Seconds)";
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.SAVE;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(448, 26);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(180, 62);
      ((Control) this.glassButton1).TabIndex = 2;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.Popup;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "ON",
        (object) "OFF"
      });
      this.comboBox1.Location = new Point(307, 43);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(121, 33);
      this.comboBox1.TabIndex = 3;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(307, 99);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(121, 31);
      this.textBox1.TabIndex = 4;
      this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
      this.panel1.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(660, 240);
      this.panel1.TabIndex = 14;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.24752f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.75247f));
      this.tableLayoutPanel1.Size = new Size(660, 240);
      this.tableLayoutPanel1.TabIndex = 11;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(654, 54);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(191, 5);
      this.label7.Name = "label7";
      this.label7.Size = new Size(265, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "INACTIVITY MONITOR";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.glassButton2);
      this.panel3.Controls.Add((Control) this.textBox1);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.comboBox1);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 63);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(654, 174);
      this.panel3.TabIndex = 11;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.EXIT;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(448, 99);
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
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(660, 240);
      this.Controls.Add((Control) this.panel1);
      this.ForeColor = Color.RoyalBlue;
      this.Name = nameof (FormInactivityMonitor);
      this.Text = nameof (FormInactivityMonitor);
      this.Load += new EventHandler(this.FormInactivityMonitor_Load);
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
