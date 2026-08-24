
using Glass;
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormCall : Form
  {
    private DateTime callStartTime;
    private string strADBLocation = "C:\\adb\\adb.exe";
    private string phoneNumber = "";
    private IContainer components = (IContainer) null;
    private GlassButton glassButton1;
    private GlassButton btnEndCall;
    private TextBox textBox1;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private Label label2;
    private System.Windows.Forms.Timer timer1;
    private GlassButton glassButton2;

    public FormCall() => this.InitializeComponent();

    public FormCall(string phoneNumbeR)
    {
      this.phoneNumber = phoneNumbeR;
      this.InitializeComponent();
    }

    private void FormCall_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatButtonBlue(ref this.glassButton1);
      PawnManagementClass.formatButtonRed(ref this.btnEndCall);
      this.textBox1.Text = this.phoneNumber;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (this.IsDigitsOnly(this.textBox1.Text) && this.textBox1.Text.Length == 10)
      {
        this.call(this.textBox1.Text.ToString());
      }
      else
      {
        int num = (int) MessageBox.Show("Invalid Phone Number");
      }
    }

    private bool IsDigitsOnly(string str)
    {
      foreach (char ch in str)
      {
        if (ch < '0' || ch > '9')
          return false;
      }
      return true;
    }

    private void call(string PHONENUMBER)
    {
      try
      {
        if (MessageBox.Show("Are you sure you want to call", "Call?", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        this.timer1.Start();
        this.callStartTime = DateTime.Now;
        StringBuilder stringBuilder = new StringBuilder();
        string str1 = PHONENUMBER;
        stringBuilder.Append(" shell am start -n com.javacodegeeks.android.RameshPawnSmsCenter/com.javacodegeeks.android.RameshPawnSmsCenter.MainActivity -e act call -e number " + str1);
        ProcessStartInfo processStartInfo1 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
        processStartInfo1.CreateNoWindow = true;
        processStartInfo1.RedirectStandardOutput = true;
        processStartInfo1.RedirectStandardError = true;
        processStartInfo1.UseShellExecute = false;
        Process process1 = new Process();
        process1.StartInfo = processStartInfo1;
        StringBuilder output = new StringBuilder();
        StringBuilder error = new StringBuilder();
        process1.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
        process1.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
        process1.Start();
        process1.BeginOutputReadLine();
        process1.BeginErrorReadLine();
        process1.WaitForExit();
        process1.Close();
        string str2 = error.ToString();
        string str3 = output.ToString();
        process1.Dispose();
        int num1 = 2;
        bool SmsSent = false;
        bool errorShown = false;
        for (; !str3.Contains("device") && num1 > 0; --num1)
        {
          ProcessStartInfo processStartInfo2 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
          processStartInfo2.CreateNoWindow = true;
          processStartInfo2.RedirectStandardOutput = true;
          processStartInfo2.RedirectStandardError = true;
          processStartInfo2.UseShellExecute = false;
          Process process2 = new Process();
          process2.StartInfo = processStartInfo2;
          output = new StringBuilder();
          error = new StringBuilder();
          process2.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process2.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process2.Start();
          process2.BeginOutputReadLine();
          process2.BeginErrorReadLine();
          process2.WaitForExit();
          process2.Close();
          str2 = error.ToString();
          str3 = output.ToString();
          process2.Dispose();
          Thread.Sleep(2000);
        }
        if (num1 <= 0)
        {
          int num2 = (int) MessageBox.Show("Make sure an Android device is connected.", "Unable to Call");
        }
        else
        {
          ProcessStartInfo processStartInfo3 = new ProcessStartInfo(" " + this.strADBLocation + " ", " shell pm clear com.javacodegeeks.android.RameshPawnSmsCenter");
          processStartInfo3.CreateNoWindow = true;
          processStartInfo3.RedirectStandardOutput = true;
          processStartInfo3.RedirectStandardError = true;
          processStartInfo3.UseShellExecute = false;
          Process process3 = new Process();
          process3.StartInfo = processStartInfo3;
          output = new StringBuilder();
          error = new StringBuilder();
          process3.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process3.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process3.Start();
          process3.BeginOutputReadLine();
          process3.BeginErrorReadLine();
          process3.WaitForExit();
          process3.Close();
          str2 = error.ToString();
          string str4 = output.ToString();
          process3.Dispose();
          ProcessStartInfo processStartInfo4 = new ProcessStartInfo(" " + this.strADBLocation + " ", stringBuilder.ToString());
          processStartInfo4.CreateNoWindow = false;
          processStartInfo4.RedirectStandardOutput = true;
          processStartInfo4.RedirectStandardError = true;
          processStartInfo4.UseShellExecute = false;
          Process process4 = new Process();
          process4.StartInfo = processStartInfo4;
          output = new StringBuilder();
          error = new StringBuilder();
          process4.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (SmsSent)
              return;
            SmsSent = true;
            output.Append(ef.Data);
          });
          process4.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (errorShown)
              return;
            errorShown = true;
            if (ef.Data != null)
            {
              error.Append(ef.Data);
              int num3 = (int) MessageBox.Show("Call Error" + ef.Data);
            }
          });
          process4.Start();
          process4.BeginOutputReadLine();
          process4.BeginErrorReadLine();
          process4.WaitForExit();
          process4.Close();
          str2 = error.ToString();
          str4 = output.ToString();
          process4.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form call.call(string phonenumber)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void endCall()
    {
      try
      {
        if (MessageBox.Show("Are you sure you want to End Call", " End Call?", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(" shell am start -n com.javacodegeeks.android.RameshPawnSmsCenter/com.javacodegeeks.android.RameshPawnSmsCenter.MainActivity -e act end ");
        ProcessStartInfo processStartInfo1 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
        processStartInfo1.CreateNoWindow = true;
        processStartInfo1.RedirectStandardOutput = true;
        processStartInfo1.RedirectStandardError = true;
        processStartInfo1.UseShellExecute = false;
        Process process1 = new Process();
        process1.StartInfo = processStartInfo1;
        StringBuilder output = new StringBuilder();
        StringBuilder error = new StringBuilder();
        process1.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
        process1.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
        process1.Start();
        process1.BeginOutputReadLine();
        process1.BeginErrorReadLine();
        process1.WaitForExit();
        process1.Close();
        string str1 = error.ToString();
        string str2 = output.ToString();
        process1.Dispose();
        int num1 = 2;
        bool SmsSent = false;
        bool errorShown = false;
        for (; !str2.Contains("device") && num1 > 0; --num1)
        {
          ProcessStartInfo processStartInfo2 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
          processStartInfo2.CreateNoWindow = true;
          processStartInfo2.RedirectStandardOutput = true;
          processStartInfo2.RedirectStandardError = true;
          processStartInfo2.UseShellExecute = false;
          Process process2 = new Process();
          process2.StartInfo = processStartInfo2;
          output = new StringBuilder();
          error = new StringBuilder();
          process2.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process2.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process2.Start();
          process2.BeginOutputReadLine();
          process2.BeginErrorReadLine();
          process2.WaitForExit();
          process2.Close();
          str1 = error.ToString();
          str2 = output.ToString();
          process2.Dispose();
          Thread.Sleep(10000);
        }
        if (num1 <= 0)
        {
          int num2 = (int) MessageBox.Show("Make sure an Android device is connected.", "Unable to EndCall");
        }
        else
        {
          ProcessStartInfo processStartInfo3 = new ProcessStartInfo(" " + this.strADBLocation + " ", " shell pm clear com.javacodegeeks.android.RameshPawnSmsCenter");
          processStartInfo3.CreateNoWindow = true;
          processStartInfo3.RedirectStandardOutput = true;
          processStartInfo3.RedirectStandardError = true;
          processStartInfo3.UseShellExecute = false;
          Process process3 = new Process();
          process3.StartInfo = processStartInfo3;
          output = new StringBuilder();
          error = new StringBuilder();
          process3.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process3.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process3.Start();
          process3.BeginOutputReadLine();
          process3.BeginErrorReadLine();
          process3.WaitForExit();
          process3.Close();
          str1 = error.ToString();
          string str3 = output.ToString();
          process3.Dispose();
          ProcessStartInfo processStartInfo4 = new ProcessStartInfo(" " + this.strADBLocation + " ", stringBuilder.ToString());
          processStartInfo4.CreateNoWindow = false;
          processStartInfo4.RedirectStandardOutput = true;
          processStartInfo4.RedirectStandardError = true;
          processStartInfo4.UseShellExecute = false;
          Process process4 = new Process();
          process4.StartInfo = processStartInfo4;
          output = new StringBuilder();
          error = new StringBuilder();
          process4.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (SmsSent)
              return;
            SmsSent = true;
            output.Append(ef.Data);
          });
          process4.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (errorShown)
              return;
            errorShown = true;
            if (ef.Data != null)
            {
              error.Append(ef.Data);
              int num3 = (int) MessageBox.Show("End Call Error" + ef.Data);
            }
          });
          process4.Start();
          process4.BeginOutputReadLine();
          process4.BeginErrorReadLine();
          process4.WaitForExit();
          process4.Close();
          str1 = error.ToString();
          str3 = output.ToString();
          process4.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form call.endCall", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnEndCall_Click(object sender, EventArgs e)
    {
      this.endCall();
      this.timer1.Stop();
    }

    private void textBox1_TextChanged(object sender, EventArgs e) => this.label1.Text = this.textBox1.Text.Length.ToString();

    private void timer1_Tick(object sender, EventArgs e)
    {
      Label label2 = this.label2;
      double num = Math.Floor(DateTime.Now.Subtract(this.callStartTime).TotalSeconds / 60.0);
      string str1 = num.ToString();
      num = Math.Round(DateTime.Now.Subtract(this.callStartTime).TotalSeconds % 60.0);
      string str2 = num.ToString();
      string str3 = str1 + ":" + str2;
      label2.Text = str3;
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.Close();

    private void connect(string ipAddress)
    {
      try
      {
        if (MessageBox.Show("Are you sure you want to call", "Call?", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        this.timer1.Start();
        this.callStartTime = DateTime.Now;
        new StringBuilder().Append(" shell am start -n com.javacodegeeks.android.RameshPawnSmsCenter/com.javacodegeeks.android.RameshPawnSmsCenter.MainActivity -e act call -e number " + this.phoneNumber);
        ProcessStartInfo processStartInfo1 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
        processStartInfo1.CreateNoWindow = true;
        processStartInfo1.RedirectStandardOutput = true;
        processStartInfo1.RedirectStandardError = true;
        processStartInfo1.UseShellExecute = false;
        Process process1 = new Process();
        process1.StartInfo = processStartInfo1;
        StringBuilder output = new StringBuilder();
        StringBuilder error = new StringBuilder();
        process1.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
        process1.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
        process1.Start();
        process1.BeginOutputReadLine();
        process1.BeginErrorReadLine();
        process1.WaitForExit();
        process1.Close();
        string str1 = error.ToString();
        string str2 = output.ToString();
        process1.Dispose();
        int num1 = 2;
        bool SmsSent = false;
        bool errorShown = false;
        for (; !str2.Contains("device") && num1 > 0; --num1)
        {
          ProcessStartInfo processStartInfo2 = new ProcessStartInfo(" " + this.strADBLocation + " ", "get-state");
          processStartInfo2.CreateNoWindow = true;
          processStartInfo2.RedirectStandardOutput = true;
          processStartInfo2.RedirectStandardError = true;
          processStartInfo2.UseShellExecute = false;
          Process process2 = new Process();
          process2.StartInfo = processStartInfo2;
          output = new StringBuilder();
          error = new StringBuilder();
          process2.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process2.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process2.Start();
          process2.BeginOutputReadLine();
          process2.BeginErrorReadLine();
          process2.WaitForExit();
          process2.Close();
          str1 = error.ToString();
          str2 = output.ToString();
          process2.Dispose();
          Thread.Sleep(2000);
        }
        if (num1 <= 0)
        {
          int num2 = (int) MessageBox.Show("Make sure an Android device is connected.", "Unable to Call");
        }
        else
        {
          ProcessStartInfo processStartInfo3 = new ProcessStartInfo(" " + this.strADBLocation + " ", " shell pm clear com.javacodegeeks.android.RameshPawnSmsCenter");
          processStartInfo3.CreateNoWindow = true;
          processStartInfo3.RedirectStandardOutput = true;
          processStartInfo3.RedirectStandardError = true;
          processStartInfo3.UseShellExecute = false;
          Process process3 = new Process();
          process3.StartInfo = processStartInfo3;
          output = new StringBuilder();
          error = new StringBuilder();
          process3.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) => output.Append(ef.Data));
          process3.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) => error.Append(ef.Data));
          process3.Start();
          process3.BeginOutputReadLine();
          process3.BeginErrorReadLine();
          process3.WaitForExit();
          process3.Close();
          str1 = error.ToString();
          string str3 = output.ToString();
          process3.Dispose();
          ProcessStartInfo processStartInfo4 = new ProcessStartInfo(" " + this.strADBLocation + " ", "adb connect 192.168.1.102");
          processStartInfo4.CreateNoWindow = false;
          processStartInfo4.RedirectStandardOutput = true;
          processStartInfo4.RedirectStandardError = true;
          processStartInfo4.UseShellExecute = false;
          Process process4 = new Process();
          process4.StartInfo = processStartInfo4;
          output = new StringBuilder();
          error = new StringBuilder();
          process4.OutputDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (SmsSent)
              return;
            SmsSent = true;
            output.Append(ef.Data);
          });
          process4.ErrorDataReceived += (DataReceivedEventHandler) ((o, ef) =>
          {
            if (errorShown)
              return;
            errorShown = true;
            if (ef.Data != null)
            {
              error.Append(ef.Data);
              int num3 = (int) MessageBox.Show("Call Error" + ef.Data);
            }
          });
          process4.Start();
          process4.BeginOutputReadLine();
          process4.BeginErrorReadLine();
          process4.WaitForExit();
          process4.Close();
          str1 = error.ToString();
          str3 = output.ToString();
          process4.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form call.call(string phonenumber)", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void button1_Click(object sender, EventArgs e)
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
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.btnEndCall = new GlassButton();
      this.glassButton1 = new GlassButton();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.glassButton2 = new GlassButton();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.label2 = new Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Location = new Point(58, 17);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(377, 34);
      this.textBox1.TabIndex = 2;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(441, 25);
      this.label1.Name = "label1";
      this.label1.Size = new Size(24, 26);
      this.label1.TabIndex = 3;
      this.label1.Text = "0";
      this.btnEndCall.BackColor = Color.LightBlue;
      this.btnEndCall.FadeOnFocus = true;
      this.btnEndCall.ForeColor = Color.MediumBlue;
      this.btnEndCall.ForeColorOnFocus = Color.Red;
      this.btnEndCall.ForeColorOnLeave = Color.RoyalBlue;
      this.btnEndCall.GlowColor = Color.White;
      ((ButtonBase) this.btnEndCall).Image = (Image) Resources.deletesymboll;
      this.btnEndCall.InnerBorderColor = Color.Transparent;
      ((Control) this.btnEndCall).Location = new Point(261, 70);
      ((Control) this.btnEndCall).Name = "btnEndCall";
      this.btnEndCall.OuterBorderColor = Color.MediumSlateBlue;
      this.btnEndCall.ShineColor = Color.Transparent;
      ((Control) this.btnEndCall).Size = new Size(203, 85);
      ((Control) this.btnEndCall).TabIndex = 1;
      ((Control) this.btnEndCall).Text = "&END CALL";
      ((ButtonBase) this.btnEndCall).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnEndCall).Click += new EventHandler(this.btnEndCall_Click);
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.callbutton;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.MiddleLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(60, 70);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(195, 85);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&CALL";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.36364f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 79.63636f));
      this.tableLayoutPanel1.Size = new Size(539, 275);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.glassButton2);
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(533, 50);
      this.panel2.TabIndex = 9;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(489, 8);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(39, 32);
      ((Control) this.glassButton2).TabIndex = 5;
      ((Control) this.glassButton2).Text = "&X";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(236, 8);
      this.label7.Name = "label7";
      this.label7.Size = new Size(71, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "CALL";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.textBox1);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Controls.Add((Control) this.glassButton1);
      this.panel3.Controls.Add((Control) this.btnEndCall);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 59);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(533, 213);
      this.panel3.TabIndex = 11;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Comic Sans MS", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(237, 167);
      this.label2.Name = "label2";
      this.label2.Size = new Size(35, 40);
      this.label2.TabIndex = 4;
      this.label2.Text = "0";
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(539, 275);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Font = new Font("Comic Sans MS", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(6);
      this.MaximizeBox = false;
      this.Name = nameof (FormCall);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormCall);
      this.Load += new EventHandler(this.FormCall_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
