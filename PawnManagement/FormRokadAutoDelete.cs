

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
  public class FormRokadAutoDelete : Form
  {
    private IContainer components = (IContainer) null;
    private ComboBox comboBox1;
    private Label label1;
    private GlassButton btnBackUpNow;
    private GlassButton glassButton2;
    private TextBox textBox1;
    private CheckBox checkBox1;

    public FormRokadAutoDelete() => this.InitializeComponent();

    private void btnBackUpNow_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes != MessageBox.Show("Delete Rokad till " + DateTime.Parse(PawnManagementClass.getRokadDate()).ToString("dd/MM/yyyy") + " ?", "Delete rokad", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
        return;
      DateTime dateTime = DateTime.Parse(PawnManagementClass.getRokadDate());
      dateTime = dateTime.AddDays(-1.0);
      this.deleteFromtblVouchers(dateTime.ToString("dd/MM/yyyy"));
      this.deleteFromtblRokadDetails(DateTime.Parse(PawnManagementClass.getRokadDate()).AddDays(-1.0).ToString("dd/MM/yyyy"));
    }

    private void deleteFromtblVouchers(string deleteRokadBefore)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Delete from tblvouchers where voucherdate <= @voucherdate", new List<OleDbParameter>()
      {
        new OleDbParameter("voucherdate", (object) deleteRokadBefore)
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Rokad Successfullly Deleted till " + deleteRokadBefore);
    }

    private void deleteFromtblRokadDetails(string deleteRokadBefore)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Delete from tblRokadDetails where RokadDate <= @voucherdate", new List<OleDbParameter>()
      {
        new OleDbParameter("voucherdate", (object) deleteRokadBefore)
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Rokad Successfullly Deleted till " + deleteRokadBefore);
    }

    private void FormRokadAutoDelete_Load(object sender, EventArgs e)
    {
      this.comboBox1.SelectedIndex = 0;
      this.refreshGrid();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void refreshGrid()
    {
      try
      {
        DataTable autoDeleteRokad = PawnManagementClass.getAutoDeleteRokad();
        if (autoDeleteRokad == null || autoDeleteRokad.Rows.Count <= 0)
          return;
        this.textBox1.Text = autoDeleteRokad.Rows[0]["AutoDeleteRokad"].ToString();
        this.checkBox1.Checked = autoDeleteRokad.Rows[0]["prompt"].ToString().Equals("Y");
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form rokadAutoDelete.refreshGrid()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update tblAutoDeleteRokad set AutoDeleteRokad= @AutoDeleteRokad,prompt = @prompt", new List<OleDbParameter>()
      {
        new OleDbParameter("AutoDeleteRokad", (object) this.textBox1.Text.Trim().ToString()),
        new OleDbParameter("prompt", this.checkBox1.Checked ? (object) "Y" : (object) "N")
      }, ref strError) == "Done"))
        return;
      int num = (int) MessageBox.Show("Successfullly Updated");
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => this.textBox1.Text = this.comboBox1.Text;

    private void FormRokadAutoDelete_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
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
      this.comboBox1 = new ComboBox();
      this.label1 = new Label();
      this.btnBackUpNow = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.textBox1 = new TextBox();
      this.checkBox1 = new CheckBox();
      this.SuspendLayout();
      this.comboBox1.BackColor = SystemColors.HighlightText;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.Popup;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.ForeColor = SystemColors.MenuHighlight;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[4]
      {
        (object) "DAILY",
        (object) "WEEKLY",
        (object) "MONTHLY",
        (object) "NEVER"
      });
      this.comboBox1.Location = new Point(43, 82);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(316, 32);
      this.comboBox1.TabIndex = 1;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(39, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(167, 24);
      this.label1.TabIndex = 16;
      this.label1.Text = "Auto Delete Rokad";
      this.btnBackUpNow.BackColor = Color.LightBlue;
      this.btnBackUpNow.FadeOnFocus = true;
      ((Control) this.btnBackUpNow).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBackUpNow.ForeColor = Color.MediumBlue;
      this.btnBackUpNow.ForeColorOnFocus = Color.Red;
      this.btnBackUpNow.ForeColorOnLeave = Color.RoyalBlue;
      this.btnBackUpNow.GlowColor = Color.White;
      ((ButtonBase) this.btnBackUpNow).Image = (Image) Resources.delete;
      this.btnBackUpNow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnBackUpNow).Location = new Point(43, 187);
      ((Control) this.btnBackUpNow).Name = "btnBackUpNow";
      this.btnBackUpNow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnBackUpNow.ShineColor = Color.Transparent;
      ((Control) this.btnBackUpNow).Size = new Size(316, 51);
      ((Control) this.btnBackUpNow).TabIndex = 3;
      ((Control) this.btnBackUpNow).Text = "&Delete Now";
      ((ButtonBase) this.btnBackUpNow).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnBackUpNow).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnBackUpNow).Click += new EventHandler(this.btnBackUpNow_Click);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.SAVE;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(43, 123);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(316, 51);
      ((Control) this.glassButton2).TabIndex = 2;
      ((Control) this.glassButton2).Text = "&Save";
      ((ButtonBase) this.glassButton2).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.textBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(43, 45);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(316, 31);
      this.textBox1.TabIndex = 0;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox1.Location = new Point(260, 7);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(99, 29);
      this.checkBox1.TabIndex = 18;
      this.checkBox1.Text = "Prompt";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(386, 257);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.btnBackUpNow);
      this.Controls.Add((Control) this.glassButton2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = nameof (FormRokadAutoDelete);
      this.Text = nameof (FormRokadAutoDelete);
      this.Load += new EventHandler(this.FormRokadAutoDelete_Load);
      this.KeyDown += new KeyEventHandler(this.FormRokadAutoDelete_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
