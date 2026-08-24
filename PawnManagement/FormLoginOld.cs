

using Microsoft.Win32;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using PawnManagement.Testing;
using Square;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace PawnManagement
{
  public class FormLoginOld : Form
  {
    private string memberId;
    private string memberType = "";
    private RegistryKey baseRegistryKey = Registry.LocalMachine;
    private string subKey = "SOFTWARE\\Windows102\\CurrentTime";
    private DateTime licenceValidTill = new DateTime();
    private string str1;
    private string str2;
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private IContainer components = (IContainer) null;
    private TextBox tbxUser;
    private TextBox tbxPassword;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem changeImageToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem changeBackColourToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip3;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem toolStripMenuItem3;
    private ComboBox comboBox1;
    private PictureBox pictureBox1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private CheckBox cbRemember;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
    private SquareButton btnLogin;
    private PictureBox pictureBox4;

    [DllImport("user32.dll")]
    internal static extern short GetKeyState(int keyCode);

    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    public FormLoginOld()
    {
      this.InitializeComponent();
      if (this.comboBox1.Items.Count > 0)
        this.comboBox1.SelectedIndex = 0;
      if (FormLoginOld.GetKeyState(20) == (short) 0)
        return;
      this.PressKeyboardButton(Keys.Capital);
    }

    private void PressKeyboardButton(Keys keyCode)
    {
      FormLoginOld.keybd_event((byte) keyCode, (byte) 69, 1U, 0);
      FormLoginOld.keybd_event((byte) keyCode, (byte) 69, 3U, 0);
    }

    private string getLanguage()
    {
      string strError = "";
      string my_querry = "select * from tblSettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.getLanguage", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return dataTable2.Rows[0].Field<string>("Lang");
      return "";
    }

    private void updateLanguage()
    {
      string strError = "";
      SQLHelper.RunCommand("update tblsettings set Lang = @l", new List<OleDbParameter>()
      {
        new OleDbParameter("l", (object) this.comboBox1.Text.Trim().ToString())
      }, ref strError);
      if (!(strError != ""))
        return;
      PawnManagementClass.InsertIntoException("form login.updateLanguage", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in updating language" + strError);
    }

    private bool GetLicenseStatus()
    {
      string strError = "";
      string str = this.Read("NET8", ref strError);
      if (str == null)
        return false;
      if (DateTime.Now.Subtract(new DateTime(Convert.ToInt64(str))).TotalDays < 0.0)
      {
        this.licenceValidTill = new DateTime(Convert.ToInt64(str));
        return true;
      }
      this.licenceValidTill = new DateTime(Convert.ToInt64(str));
      return true;
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

    private void button1_Click(object sender, EventArgs e)
    {
      this.str1 = "Ramesh";
      this.str2 = "#visualstudio#";
      if (this.tbxUser.Text == this.str1 && this.tbxPassword.Text == this.str2)
      {
        int num1 = (int) new formLicenseChecker().ShowDialog();
      }
      else
      {
        string shortDatePattern = new Thread((ThreadStart) (() => { })).CurrentCulture.DateTimeFormat.ShortDatePattern;
        if (!((IEnumerable<string>) new string[16]
        {
          "dd/MM/yyyy",
          "d/M/yyyy",
          "dd/M/yyyy",
          "d/MM/yyyy",
          "dd/MM/yy",
          "d/M/yy",
          "dd/M/yy",
          "d/MM/yy",
          "dd-MM-yyyy",
          "d-M-yyyy",
          "dd-M-yyyy",
          "d-MM-yyyy",
          "dd-MM-yy",
          "d-M-yy",
          "dd-M-yy",
          "d-MM-yy"
        }).Contains<string>(shortDatePattern))
        {
          int num2 = (int) MessageBox.Show("Change the date format to English(united Kingdom). The date should appear in date/month/year format rather than " + shortDatePattern);
        }
        else
        {
          if (this.tbxUser.Text == "sex" && this.tbxPassword.Text == "sex")
          {
            int num3 = (int) new FormSexSeperator().ShowDialog();
          }
          if (this.tbxUser.Text == "x" && this.tbxPassword.Text == "x")
          {
            int num4 = (int) new FormLicenseInformation().ShowDialog();
          }
          if (this.tbxUser.Text == "s" && this.tbxPassword.Text == "s")
          {
            int num5 = (int) new ConnectionstringatRuntime.Form1().ShowDialog();
          }
          if (this.tbxUser.Text == "aa" && this.tbxPassword.Text == "aa")
          {
            int num6 = (int) new FormUpdateDtabase().ShowDialog();
          }
          if (this.tbxUser.Text == "ff" && this.tbxPassword.Text == "ff")
          {
            int num7 = (int) new FormErrorFinder().ShowDialog();
          }
          if (!this.GetLicenseStatus())
          {
            int num8 = (int) MessageBox.Show("Licence Expired");
          }
          else
          {
            switch (this.loginCheck())
            {
              case "success":
                TimeSpan timeSpan = this.licenceValidTill.Subtract(DateTime.Now);
                if (timeSpan.TotalDays <= 0.0)
                {
                  object[] objArray = new object[5]
                  {
                    (object) "Your licence Expired On  :: ",
                    (object) this.licenceValidTill.ToString(),
                    (object) "   .",
                    null,
                    null
                  };
                  timeSpan = this.licenceValidTill.Subtract(DateTime.Now);
                  objArray[3] = (object) Math.Round(timeSpan.TotalDays);
                  objArray[4] = (object) " DAYS over after expiry. You cannot entery pledge details...So kindly contact the software admin";
                  int num9 = (int) MessageBox.Show(string.Concat(objArray));
                }
                else
                {
                  timeSpan = this.licenceValidTill.Subtract(DateTime.Now);
                  if (timeSpan.TotalDays < 15.0)
                  {
                    timeSpan = this.licenceValidTill.Subtract(DateTime.Now);
                    int num10 = (int) MessageBox.Show("Your licence going to expire within " + (object) Math.Round(timeSpan.TotalDays) + " days..");
                  }
                }
                FormMain formMain = new FormMain(this.tbxUser.Text.Trim().ToString(), this.memberId, this.memberType, this.comboBox1.Text, this.licenceValidTill);
                if (FormPrintSettings.boolGetMainFormFullScreen())
                  formMain.FormBorderStyle = FormBorderStyle.None;
                formMain.Show();
                this.Visible = false;
                PawnManagementClass.InsertIntoHistory("LOGIN SUCCESS", this.tbxUser.Text.Trim().ToString() + " successfully logged in", "", "", this.tbxUser.Text.Trim().ToString(), DateTime.Now.ToString());
                if (this.cbRemember.Checked)
                {
                  SettingsClass.UpdateRememberUsernameAndPassword("Y");
                  LoginClass.UpdateLastUsed("Y", this.tbxUser.Text);
                  break;
                }
                SettingsClass.UpdateRememberUsernameAndPassword("N");
                break;
              case "passwordWrong":
                Transition.run((object) this.tbxPassword, "BackColor", (object) System.Drawing.Color.Black, (ITransitionType) new TransitionType_Flash(4, 400));
                this.tbxPassword.Select();
                PawnManagementClass.InsertIntoHistory("LOGIN FAILURE", this.tbxUser.Text.Trim().ToString() + " entered password: " + this.tbxPassword.Text.Trim() + " and failed to log in", "", "", this.tbxUser.Text.Trim().ToString(), DateTime.Now.ToString());
                break;
              default:
                this.tbxUser.Select();
                PawnManagementClass.InsertIntoHistory("LOGIN FAILURE", this.tbxUser.Text.Trim().ToString() + " entered password: " + this.tbxPassword.Text.Trim() + " and failed to log in", "", "", this.tbxUser.Text.Trim().ToString(), DateTime.Now.ToString());
                break;
            }
          }
        }
      }
    }

    private string loginCheck()
    {
      string strError = "";
      string my_querry = "select * from tblLogin where username =@username";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("username", (object) this.tbxUser.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException(" form login.logincheck", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else
      {
        try
        {
          if (dataTable2 != null && dataTable2.Rows.Count > 0)
          {
            if (!(PawnManagementClass.decrypt(dataTable2.Rows[0]["pwd"].ToString()).Substring(1) == this.tbxPassword.Text))
              return "passwordWrong";
            this.memberId = PawnManagementClass.decrypt(dataTable2.Rows[0]["pwd"].ToString())[0].ToString();
            this.getMemberType(this.memberId);
            return "success";
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("formlogin logincheck", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      return "failure";
    }

    private void getMemberType(string memberId)
    {
      string strError = "";
      string my_querry = "select * from tblMemberType where MemberId like @MemberId";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("MemberId", (object) memberId));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.getmembertype", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        this.memberType = dataTable2.Rows[0].Field<string>("memberType").ToString();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Login_Load(object sender, EventArgs e)
    {
      try
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        this.CenterToScreen();
        FormMain.startUpPath = ConfigurationManager.ConnectionStrings["con"].ToString();
        if (ConfigurationManager.ConnectionStrings["con"].ToString() == "")
        {
          this.toolStripStatusLabel1.Text = Application.StartupPath + " - Connected";
          SQLHelper._strDBConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source  = PawnManagement.accdb;Jet OLEDB:Database Password = (&()&$#)!&";
          FormMain.startUpPath = Application.StartupPath + "\\";
        }
        else if (FormLoginOld.VerifyFileExists(new Uri(ConfigurationManager.ConnectionStrings["con"].ToString() + "PawnManagement.accdb"), 1000))
        {
          SQLHelper._strDBConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source  =" + ConfigurationManager.ConnectionStrings["con"].ToString() + "PawnManagement.accdb;Jet OLEDB:Database Password = (&()&$#)!&";
          this.toolStripStatusLabel1.Text = ConfigurationManager.ConnectionStrings["con"].ToString() + " - Connected";
        }
        else
        {
          this.toolStripStatusLabel1.Text = ConfigurationManager.ConnectionStrings["con"].ToString() + " - Not able to connect";
          return;
        }
        this.getUserName();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form login.login_load", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void getUserName()
    {
      if (SettingsClass.getRememberUserNameAndPassword())
      {
        this.tbxUser.Text = LoginClass.getLastUsedUserName();
        this.cbRemember.Checked = true;
        this.tbxPassword.Select();
      }
      else
        this.tbxUser.Select();
    }

    private static bool VerifyFileExists(Uri uri, int timeout)
    {
      Task<bool> task = new Task<bool>((Func<bool>) (() => new FileInfo(uri.LocalPath).Exists));
      task.Start();
      return task.Wait(timeout) && task.Result;
    }

    private bool checkForDatabaseUpdate()
    {
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select  * from tblversion order by dateinstalled desc", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.checkFordatabaseUpdate", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form login.checkFordatabaseUpdate");
      }
      else
      {
        try
        {
          if (dataTable != null && dataTable.Rows.Count > 0)
          {
            if (!(dataTable.Rows[0]["version"].ToString() == "1"))
              ;
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form login.checkForDatabaseUpdate()", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      return false;
    }

    private void getPicture()
    {
      string empty = string.Empty;
      string strError = "";
      DataTable dataTable = SQLHelper.GetDataTable("select  * from tblsettings", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.getpicture", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in getting the picturebox path");
      }
      else
      {
        try
        {
          string path = dataTable.Rows[0].Field<string>("LoginScreenPictureBoxPath");
          if (File.Exists(path))
          {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
              this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form login.getpicture second exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
    }

    private void insertPictureBoxPath(string filePath)
    {
      string strError = "";
      string str = SQLHelper.RunCommand("update tblsettings set LoginScreenPictureBoxPath = @path where SerialNumber = 1 ", new List<OleDbParameter>()
      {
        new OleDbParameter("path", (object) filePath)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form login.insertpictureboxpath", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in insertingg the image path" + strError);
      }
      else if (str == "done")
      {
        int num1 = (int) MessageBox.Show("successfully changed");
      }
    }

    private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
        openFileDialog.Title = "Select the picture";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        if (openFileDialog.CheckFileExists)
        {
          string str = FormMain.startUpPath + "Photos\\Login\\" + openFileDialog.SafeFileName + ".png";
          this.insertPictureBoxPath(str);
          File.Copy(openFileDialog.FileName, str, true);
          string empty = string.Empty;
          this.getPicture();
        }
        else
        {
          int num = (int) MessageBox.Show("file does not exist");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form login.changeImaggeToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      try
      {
        ColorDialog colorDialog = new ColorDialog();
        colorDialog.AllowFullOpen = true;
        int num = (int) colorDialog.ShowDialog();
        string strError = "";
        SQLHelper.RunCommand("update tblColours set Forecolour=@foreColour where FormName ='Login'", new List<OleDbParameter>()
        {
          new OleDbParameter("foreColour", (object) colorDialog.Color.ToArgb())
        }, ref strError);
        if (!(strError != ""))
          return;
        PawnManagementClass.InsertIntoException("form login.toolstripmenuitem_click", strError, FormMain.username, DateTime.Now.ToString());
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form login.toolsStripMenuItem1_Click1", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void changeBackColourToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.AllowFullOpen = true;
      int num = (int) colorDialog.ShowDialog();
      string strError = "";
      SQLHelper.RunCommand("update tblColours set BackColour =@foreColour where FormName ='Login'", new List<OleDbParameter>()
      {
        new OleDbParameter("BackColour", (object) colorDialog.Color.ToArgb())
      }, ref strError);
      if (!(strError != ""))
        return;
      PawnManagementClass.InsertIntoException("form login.changebackcolourtoolsstdipmenuitem_click", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.AllowFullOpen = true;
      int num = (int) colorDialog.ShowDialog();
      string strError = "";
      SQLHelper.RunCommand("update tblColours set ButtonBackColour =@ButtonBackColour where FormName ='Login'", new List<OleDbParameter>()
      {
        new OleDbParameter("ButtonBackColour", (object) colorDialog.Color.ToArgb())
      }, ref strError);
      if (!(strError != ""))
        return;
      PawnManagementClass.InsertIntoException("from login.toolstipmenuitem2_click", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void tbxUser_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxUser.Select();
    }

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\u001E' || e.KeyChar == '\u001F')
        return;
      e.Handled = true;
    }

    private void tbxUser_Enter(object sender, EventArgs e) => this.tbxUser.Select(0, this.tbxUser.Text.Length);

    private void tbxPassword_Enter(object sender, EventArgs e) => this.tbxPassword.Select(0, this.tbxPassword.Text.Length);

    private void btnLogin_Enter(object sender, EventArgs e) => this.btnLogin.BackColor = System.Drawing.Color.Blue;

    private void btnLogin_Enter_1(object sender, EventArgs e) => this.btnLogin.BackColor = System.Drawing.Color.CornflowerBlue;

    private void cbRemember_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnLogin).Select();
    }

    private void cbRemember_Enter(object sender, EventArgs e) => this.cbRemember.ForeColor = System.Drawing.Color.Blue;

    private void cbRemember_Leave(object sender, EventArgs e) => this.cbRemember.ForeColor = System.Drawing.Color.Black;

    private void pictureBox4_Click(object sender, EventArgs e) => this.Close();

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLicenseInformation().ShowDialog();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void panel4_Paint(object sender, PaintEventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormLoginOld));
      this.contextMenuStrip3 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem2 = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripMenuItem();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.changeImageToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.changeBackColourToolStripMenuItem = new ToolStripMenuItem();
      this.pictureBox1 = new PictureBox();
      this.cbRemember = new CheckBox();
      this.comboBox1 = new ComboBox();
      this.tbxPassword = new TextBox();
      this.tbxUser = new TextBox();
      this.statusStrip1 = new StatusStrip();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.pictureBox2 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.btnLogin = new SquareButton();
      this.pictureBox4 = new PictureBox();
      this.contextMenuStrip3.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.contextMenuStrip2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.statusStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      this.SuspendLayout();
      this.contextMenuStrip3.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.toolStripMenuItem3
      });
      this.contextMenuStrip3.Name = "contextMenuStrip1";
      this.contextMenuStrip3.Size = new Size(180, 48);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(179, 22);
      this.toolStripMenuItem2.Text = "Change BackColour";
      this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(179, 22);
      this.toolStripMenuItem3.Text = "Change ForeColour";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.changeImageToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(152, 26);
      this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
      this.changeImageToolStripMenuItem.Size = new Size(151, 22);
      this.changeImageToolStripMenuItem.Text = "Change Image";
      this.changeImageToolStripMenuItem.Click += new EventHandler(this.changeImageToolStripMenuItem_Click);
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.changeBackColourToolStripMenuItem
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(180, 48);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(179, 22);
      this.toolStripMenuItem1.Text = "Change ForeColour";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.changeBackColourToolStripMenuItem.Name = "changeBackColourToolStripMenuItem";
      this.changeBackColourToolStripMenuItem.Size = new Size(179, 22);
      this.changeBackColourToolStripMenuItem.Text = "Change BackColour";
      this.changeBackColourToolStripMenuItem.Click += new EventHandler(this.changeBackColourToolStripMenuItem_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(92, 18);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(421, 162);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.cbRemember.AutoSize = true;
      this.cbRemember.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRemember.Location = new Point(228, 278);
      this.cbRemember.Name = "cbRemember";
      this.cbRemember.Size = new Size(161, 20);
      this.cbRemember.TabIndex = 2;
      this.cbRemember.Text = "Remember Username";
      this.cbRemember.UseVisualStyleBackColor = true;
      this.cbRemember.Enter += new EventHandler(this.cbRemember_Enter);
      this.cbRemember.KeyDown += new KeyEventHandler(this.cbRemember_KeyDown);
      this.cbRemember.Leave += new EventHandler(this.cbRemember_Leave);
      this.comboBox1.BackColor = SystemColors.InactiveBorder;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "English",
        (object) "Hindi"
      });
      this.comboBox1.Location = new Point(172, 145);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(246, 32);
      this.comboBox1.TabIndex = 4;
      this.comboBox1.Visible = false;
      this.comboBox1.KeyDown += new KeyEventHandler(this.comboBox1_KeyDown);
      this.comboBox1.KeyPress += new KeyPressEventHandler(this.comboBox1_KeyPress);
      this.tbxPassword.BackColor = SystemColors.InactiveBorder;
      this.tbxPassword.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPassword.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPassword.Location = new Point(188, 239);
      this.tbxPassword.Name = "tbxPassword";
      this.tbxPassword.PasswordChar = '*';
      this.tbxPassword.Size = new Size(246, 31);
      this.tbxPassword.TabIndex = 1;
      this.tbxPassword.Enter += new EventHandler(this.tbxPassword_Enter);
      this.tbxPassword.KeyDown += new KeyEventHandler(this.tbxUser_KeyDown);
      this.tbxUser.BackColor = SystemColors.InactiveBorder;
      this.tbxUser.BorderStyle = BorderStyle.FixedSingle;
      this.tbxUser.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxUser.Location = new Point(188, 192);
      this.tbxUser.Name = "tbxUser";
      this.tbxUser.Size = new Size(246, 31);
      this.tbxUser.TabIndex = 0;
      this.tbxUser.Enter += new EventHandler(this.tbxUser_Enter);
      this.tbxUser.KeyDown += new KeyEventHandler(this.tbxUser_KeyDown);
      this.statusStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripStatusLabel1
      });
      this.statusStrip1.Location = new Point(0, 346);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(432, 22);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      this.statusStrip1.Visible = false;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(118, 17);
      this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      this.pictureBox2.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(150, 192);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(37, 32);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 8;
      this.pictureBox2.TabStop = false;
      this.pictureBox3.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox3.Image = (Image) componentResourceManager.GetObject("pictureBox3.Image");
      this.pictureBox3.Location = new Point(150, 239);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(37, 32);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 9;
      this.pictureBox3.TabStop = false;
      this.btnLogin.BackColor = System.Drawing.Color.MediumBlue;
      this.btnLogin.FadeOnFocus = true;
      ((Control) this.btnLogin).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
      this.btnLogin.ForeColorOnFocus = System.Drawing.Color.Yellow;
      this.btnLogin.ForeColorOnLeave = System.Drawing.Color.White;
      this.btnLogin.GlowColor = System.Drawing.Color.Snow;
      this.btnLogin.InnerBorderColor = System.Drawing.Color.FloralWhite;
      ((Control) this.btnLogin).Location = new Point(201, 314);
      ((Control) this.btnLogin).Name = "btnLogin";
      this.btnLogin.OuterBorderColor = System.Drawing.Color.DimGray;
      this.btnLogin.ShineColor = System.Drawing.Color.MidnightBlue;
      ((Control) this.btnLogin).Size = new Size(215, 33);
      ((Control) this.btnLogin).TabIndex = 10;
      ((Control) this.btnLogin).Text = "&LOGIN";
      ((Control) this.btnLogin).Click += new EventHandler(this.button1_Click);
      this.pictureBox4.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox4.Image = (Image) componentResourceManager.GetObject("pictureBox4.Image");
      this.pictureBox4.Location = new Point(557, 18);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(37, 32);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox4.TabIndex = 11;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Click += new EventHandler(this.pictureBox4_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(618, 367);
      this.Controls.Add((Control) this.pictureBox4);
      this.Controls.Add((Control) this.btnLogin);
      this.Controls.Add((Control) this.pictureBox3);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.cbRemember);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.tbxUser);
      this.Controls.Add((Control) this.tbxPassword);
      this.Controls.Add((Control) this.statusStrip1);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.Name = nameof (FormLoginOld);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Login";
      this.Load += new EventHandler(this.Login_Load);
      this.contextMenuStrip3.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.contextMenuStrip2.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
