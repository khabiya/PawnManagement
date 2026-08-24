

using Glass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormAutoBackUp : Form
  {
    private string oldBackUpPath = "";
    private IContainer components = (IContainer) null;
    private TextBox textBox1;
    private GlassButton btnBackUpPath;
    private GlassButton glassButton2;
    private GlassButton btnBackUpNow;
    private Label label1;
    private ComboBox comboBox1;

    public FormAutoBackUp() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormAutoBackUp_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.comboBox1.Items.Count > 0)
          this.comboBox1.SelectedIndex = 0;
        this.getAutoBackUp();
        PawnManagementClass.formatButtonBlue(ref this.btnBackUpPath);
        PawnManagementClass.formatButtonBlue(ref this.glassButton2);
        PawnManagementClass.formatButtonControl(ref this.btnBackUpNow);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form autobackup.formautobackup_Load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getAutoBackUp()
    {
      string strError = "";
      string my_querry = "select * from tblBackUp";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form autobackup.getautobackup", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form autobackup.getautobackup.getautobackup" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            this.textBox1.Text = dataTable2.Rows[0].Field<string>("BackUpPath");
            this.comboBox1.Text = dataTable2.Rows[0].Field<string>("BackUpMode");
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form autobackup.getautobackup", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void btnBackUpPath_Click(object sender, EventArgs e)
    {
      try
      {
        this.oldBackUpPath = this.textBox1.Text.Trim().ToString();
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        if (folderBrowserDialog.SelectedPath.Count<char>() == 3)
          this.textBox1.Text = folderBrowserDialog.SelectedPath;
        else
          this.textBox1.Text = folderBrowserDialog.SelectedPath.ToString() + "\\";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form auto backup.btnbackuppath", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void glassButton2_Click(object sender, EventArgs e)
    {
      string strError = "";
      if (SQLHelper.RunCommand("update tblBackUp set BackUpPath = @BackUpPath,BackUpMode = @BackUpMode", new List<OleDbParameter>()
      {
        new OleDbParameter("BackUpPath", (object) this.textBox1.Text.Trim().ToString()),
        new OleDbParameter("BackUpMode", (object) this.comboBox1.Text.Trim().ToString())
      }, ref strError) != "Done")
      {
        int num = (int) MessageBox.Show("Error in Adding" + strError);
        PawnManagementClass.InsertIntoException("form autobackup.glassbutton2_click", strError, FormMain.username, DateTime.Now.ToString());
      }
      else
      {
        int num1 = (int) MessageBox.Show("Back Up path successfully changed");
      }
      PawnManagementClass.InsertIntoHistory("BACKUP PATH CHANGED", "Back up Path changed", this.oldBackUpPath, this.textBox1.Text.Trim().ToString(), FormMain.username, DateTime.Now.ToString());
      this.deleteFromOldBackUpLocation();
    }

    private void deleteFromOldBackUpLocation()
    {
      if (!File.Exists(this.oldBackUpPath + "\\PawnManagement.accdb"))
        return;
      File.Delete(this.oldBackUpPath + "\\PawnManagement.accdb");
    }

    private void btnBackUpNow_Click(object sender, EventArgs e)
    {
      try
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        if (File.Exists("PawnManagement.accdb"))
        {
          try
          {
            if (Directory.Exists(folderBrowserDialog.SelectedPath))
              Directory.CreateDirectory(folderBrowserDialog.SelectedPath + "\\" + DateTime.Now.ToLongDateString());
            string sourceFileName = FormMain.startUpPath + "\\PawnManagement.accdb";
            string selectedPath = folderBrowserDialog.SelectedPath;
            DateTime now = DateTime.Now;
            string longDateString = now.ToLongDateString();
            string destFileName = selectedPath + "\\" + longDateString + "\\PawnManagement.accdb";
            File.Copy(sourceFileName, destFileName, true);
            string strError = "";
            string my_querry = "update tblBackUp set LastBackUpDate = @LastBackUpDate";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            List<OleDbParameter> oleDbParameterList = parameters;
            now = DateTime.Now;
            OleDbParameter oleDbParameter = new OleDbParameter("LastBackUpDate", (object) now.ToString("dd/MM/yyyy"));
            oleDbParameterList.Add(oleDbParameter);
            if (SQLHelper.RunCommand(my_querry, parameters, ref strError) != "Done")
            {
              int num1 = (int) MessageBox.Show("Error in Adding" + strError);
            }
            else
            {
              int num2 = (int) MessageBox.Show("Backup successfull");
            }
          }
          catch (Exception ex)
          {
            PawnManagementClass.InsertIntoException("formautobackup.btnbackupnow_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
            throw;
          }
        }
        else
        {
          int num3 = (int) MessageBox.Show("Database missing");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formautobackup.btnbackupnow_click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\u001E' || e.KeyChar == '\u001F')
        return;
      e.Handled = true;
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
      this.btnBackUpPath = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.btnBackUpNow = new GlassButton();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.SuspendLayout();
      this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(54, 64);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(316, 29);
      this.textBox1.TabIndex = 0;
      this.btnBackUpPath.BackColor = Color.LightBlue;
      this.btnBackUpPath.FadeOnFocus = true;
      ((Control) this.btnBackUpPath).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBackUpPath.ForeColor = Color.MediumBlue;
      this.btnBackUpPath.ForeColorOnFocus = Color.Red;
      this.btnBackUpPath.ForeColorOnLeave = Color.MediumBlue;
      this.btnBackUpPath.GlowColor = Color.White;
      this.btnBackUpPath.InnerBorderColor = Color.Transparent;
      ((Control) this.btnBackUpPath).Location = new Point(54, 154);
      ((Control) this.btnBackUpPath).Name = "btnBackUpPath";
      this.btnBackUpPath.OuterBorderColor = Color.MediumSlateBlue;
      this.btnBackUpPath.ShineColor = Color.Transparent;
      ((Control) this.btnBackUpPath).Size = new Size(138, 51);
      ((Control) this.btnBackUpPath).TabIndex = 2;
      ((Control) this.btnBackUpPath).Text = "&Backup Path";
      ((Control) this.btnBackUpPath).Click += new EventHandler(this.btnBackUpPath_Click);
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(232, 154);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(138, 51);
      ((Control) this.glassButton2).TabIndex = 3;
      ((Control) this.glassButton2).Text = "&Save";
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.btnBackUpNow.BackColor = Color.LightBlue;
      this.btnBackUpNow.FadeOnFocus = true;
      ((Control) this.btnBackUpNow).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBackUpNow.ForeColor = Color.MediumBlue;
      this.btnBackUpNow.ForeColorOnFocus = Color.Red;
      this.btnBackUpNow.ForeColorOnLeave = Color.MediumBlue;
      this.btnBackUpNow.GlowColor = Color.White;
      this.btnBackUpNow.InnerBorderColor = Color.Transparent;
      ((Control) this.btnBackUpNow).Location = new Point(54, 223);
      ((Control) this.btnBackUpNow).Name = "btnBackUpNow";
      this.btnBackUpNow.OuterBorderColor = Color.MediumSlateBlue;
      this.btnBackUpNow.ShineColor = Color.Transparent;
      ((Control) this.btnBackUpNow).Size = new Size(316, 51);
      ((Control) this.btnBackUpNow).TabIndex = 4;
      ((Control) this.btnBackUpNow).Text = "Back up &Now";
      ((Control) this.btnBackUpNow).Click += new EventHandler(this.btnBackUpNow_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(50, 29);
      this.label1.Name = "label1";
      this.label1.Size = new Size(116, 24);
      this.label1.TabIndex = 5;
      this.label1.Text = "BackUp path";
      this.comboBox1.BackColor = SystemColors.HighlightText;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.ForeColor = SystemColors.MenuHighlight;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "DAILY",
        (object) "WEEKLY",
        (object) "MONTHLY"
      });
      this.comboBox1.Location = new Point(54, 109);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(316, 32);
      this.comboBox1.TabIndex = 1;
      this.comboBox1.KeyPress += new KeyPressEventHandler(this.comboBox1_KeyPress);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(415, 287);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.btnBackUpNow);
      this.Controls.Add((Control) this.glassButton2);
      this.Controls.Add((Control) this.btnBackUpPath);
      this.Controls.Add((Control) this.textBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = nameof (FormAutoBackUp);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormAutoBackUp);
      this.Load += new EventHandler(this.FormAutoBackUp_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
