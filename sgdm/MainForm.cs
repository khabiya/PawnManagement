

using PawnManagement;
using SecuGen.FDxSDKPro.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace sgdm
{
  public class MainForm : Form
  {
    private SGFingerPrintManager m_FPM;
    private bool boolLedOn = false;
    private int m_ImageWidth;
    private int m_ImageHeight;
    private byte[] m_RegMin1;
    private byte[] m_RegMin2;
    private byte[] m_VrfMin;
    private byte[] mREGISTER;
    private byte[] mREGISTER2;
    private byte[] mVERIFY;
    private SGFPMDeviceList[] m_DevList;
    private System.ComponentModel.Container components = (System.ComponentModel.Container) null;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private PictureBox pictureBox1;
    private Label label1;
    private ComboBox comboBoxDeviceName;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Button BtnCapture1;
    private Button BtnCapture2;
    private Button BtnCapture3;
    private PictureBox pictureBoxR2;
    private PictureBox pictureBoxV1;
    private PictureBox pictureBoxR1;
    private GroupBox groupBox3;
    private TextBox textBrightness;
    private TextBox textGain;
    private TextBox textContrast;
    private Label label12;
    private Label label11;
    private Label label10;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label13;
    private GroupBox groupBox4;
    private Button ConfigBtn;
    private TextBox textImgQuality;
    private ComboBox comboBox1;
    private GroupBox groupBox6;
    private Label label4;
    private Label label14;
    private ComboBox comboBoxSecuLevel_V;
    private ComboBox comboBoxSecuLevel_R;
    private Button GetBtn;
    private TextBox textDeviceID;
    private TextBox textSerialNum;
    private TextBox textImageWidth;
    private TextBox textImageHeight;
    private TextBox textImageDPI;
    private ProgressBar progressBar_R1;
    private ProgressBar progressBar_R2;
    private ProgressBar progressBar_V1;
    private Label label15;
    private Label label16;
    private TextBox textTimeout;
    private Button BtnRegister;
    private Button BtnVerify;
    internal GroupBox GroupBox8;
    internal Button SetBrightnessBtn;
    private TextBox textFWVersion;
    private Button GetLiveImageBtn;
    private Button GetImageBtn;
    internal NumericUpDown BrightnessUpDown;
    private CheckBox CheckBoxAutoOn;
    private Button EnumerateBtn;
    private Button OpenDeviceBtn;
    private TextBox tbxCustomerCode;
    private TabPage tabPage4;
    private Button button2;
    private PictureBox pictureBox3;
    private PictureBox pictureBox2;
    private Button button1;
    private Button button3;
    private TextBox tbxCustomerCodeVerify;
    private Label StatusBar;

    public MainForm() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tabControl1 = new TabControl();
      this.tabPage2 = new TabPage();
      this.tbxCustomerCode = new TextBox();
      this.CheckBoxAutoOn = new CheckBox();
      this.GroupBox8 = new GroupBox();
      this.BrightnessUpDown = new NumericUpDown();
      this.SetBrightnessBtn = new Button();
      this.ConfigBtn = new Button();
      this.groupBox4 = new GroupBox();
      this.textTimeout = new TextBox();
      this.label16 = new Label();
      this.label15 = new Label();
      this.textImgQuality = new TextBox();
      this.GetLiveImageBtn = new Button();
      this.GetImageBtn = new Button();
      this.pictureBox1 = new PictureBox();
      this.tabPage3 = new TabPage();
      this.BtnVerify = new Button();
      this.BtnRegister = new Button();
      this.groupBox6 = new GroupBox();
      this.comboBoxSecuLevel_V = new ComboBox();
      this.label14 = new Label();
      this.label4 = new Label();
      this.comboBoxSecuLevel_R = new ComboBox();
      this.groupBox2 = new GroupBox();
      this.progressBar_V1 = new ProgressBar();
      this.pictureBoxV1 = new PictureBox();
      this.BtnCapture3 = new Button();
      this.comboBox1 = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.progressBar_R2 = new ProgressBar();
      this.progressBar_R1 = new ProgressBar();
      this.pictureBoxR2 = new PictureBox();
      this.pictureBoxR1 = new PictureBox();
      this.BtnCapture1 = new Button();
      this.BtnCapture2 = new Button();
      this.tabPage1 = new TabPage();
      this.GetBtn = new Button();
      this.groupBox3 = new GroupBox();
      this.textImageDPI = new TextBox();
      this.textImageHeight = new TextBox();
      this.textImageWidth = new TextBox();
      this.textSerialNum = new TextBox();
      this.textFWVersion = new TextBox();
      this.textDeviceID = new TextBox();
      this.textBrightness = new TextBox();
      this.textGain = new TextBox();
      this.textContrast = new TextBox();
      this.label12 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label13 = new Label();
      this.tabPage4 = new TabPage();
      this.button3 = new Button();
      this.button2 = new Button();
      this.pictureBox3 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.button1 = new Button();
      this.comboBoxDeviceName = new ComboBox();
      this.label1 = new Label();
      this.StatusBar = new Label();
      this.EnumerateBtn = new Button();
      this.OpenDeviceBtn = new Button();
      this.tbxCustomerCodeVerify = new TextBox();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.GroupBox8.SuspendLayout();
      this.BrightnessUpDown.BeginInit();
      this.groupBox4.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.tabPage3.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.pictureBoxV1).BeginInit();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.pictureBoxR2).BeginInit();
      ((ISupportInitialize) this.pictureBoxR1).BeginInit();
      this.tabPage1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage4);
      this.tabControl1.Location = new Point(0, 40);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(416, 404);
      this.tabControl1.TabIndex = 0;
      this.tabPage2.Controls.Add((Control) this.tbxCustomerCode);
      this.tabPage2.Controls.Add((Control) this.CheckBoxAutoOn);
      this.tabPage2.Controls.Add((Control) this.GroupBox8);
      this.tabPage2.Controls.Add((Control) this.ConfigBtn);
      this.tabPage2.Controls.Add((Control) this.groupBox4);
      this.tabPage2.Controls.Add((Control) this.GetLiveImageBtn);
      this.tabPage2.Controls.Add((Control) this.GetImageBtn);
      this.tabPage2.Controls.Add((Control) this.pictureBox1);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new Size(408, 378);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "  Image  ";
      this.tbxCustomerCode.Location = new Point(280, 351);
      this.tbxCustomerCode.Name = "tbxCustomerCode";
      this.tbxCustomerCode.Size = new Size(120, 20);
      this.tbxCustomerCode.TabIndex = 20;
      this.CheckBoxAutoOn.Enabled = false;
      this.CheckBoxAutoOn.Location = new Point(12, 356);
      this.CheckBoxAutoOn.Name = "CheckBoxAutoOn";
      this.CheckBoxAutoOn.Size = new Size(248, 16);
      this.CheckBoxAutoOn.TabIndex = 19;
      this.CheckBoxAutoOn.Text = "Enable AutoOn Event (FDU03, FDU04)";
      this.CheckBoxAutoOn.CheckedChanged += new EventHandler(this.CheckBoxAutoOn_CheckedChanged);
      this.GroupBox8.Controls.Add((Control) this.BrightnessUpDown);
      this.GroupBox8.Controls.Add((Control) this.SetBrightnessBtn);
      this.GroupBox8.Location = new Point(280, 200);
      this.GroupBox8.Name = "GroupBox8";
      this.GroupBox8.Size = new Size(120, 148);
      this.GroupBox8.TabIndex = 18;
      this.GroupBox8.TabStop = false;
      this.GroupBox8.Text = "Brightness";
      this.BrightnessUpDown.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.BrightnessUpDown.Location = new Point(8, 24);
      this.BrightnessUpDown.Name = "BrightnessUpDown";
      this.BrightnessUpDown.Size = new Size(44, 20);
      this.BrightnessUpDown.TabIndex = 20;
      this.BrightnessUpDown.Value = new Decimal(new int[4]
      {
        70,
        0,
        0,
        0
      });
      this.SetBrightnessBtn.Location = new Point(56, 24);
      this.SetBrightnessBtn.Name = "SetBrightnessBtn";
      this.SetBrightnessBtn.Size = new Size(56, 20);
      this.SetBrightnessBtn.TabIndex = 19;
      this.SetBrightnessBtn.Text = "Apply";
      this.SetBrightnessBtn.Click += new EventHandler(this.SetBrightnessBtn_Click);
      this.ConfigBtn.BackColor = SystemColors.ActiveBorder;
      this.ConfigBtn.Location = new Point(324, 12);
      this.ConfigBtn.Name = "ConfigBtn";
      this.ConfigBtn.Size = new Size(76, 24);
      this.ConfigBtn.TabIndex = 12;
      this.ConfigBtn.Text = "Config...";
      this.ConfigBtn.UseVisualStyleBackColor = false;
      this.ConfigBtn.Click += new EventHandler(this.ConfigBtn_Click);
      this.groupBox4.Controls.Add((Control) this.textTimeout);
      this.groupBox4.Controls.Add((Control) this.label16);
      this.groupBox4.Controls.Add((Control) this.label15);
      this.groupBox4.Controls.Add((Control) this.textImgQuality);
      this.groupBox4.Location = new Point(280, 52);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(120, 140);
      this.groupBox4.TabIndex = 11;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "LiveCapture";
      this.textTimeout.Location = new Point(8, 80);
      this.textTimeout.Name = "textTimeout";
      this.textTimeout.Size = new Size(88, 20);
      this.textTimeout.TabIndex = 18;
      this.textTimeout.Text = "10000";
      this.label16.Location = new Point(8, 64);
      this.label16.Name = "label16";
      this.label16.Size = new Size(96, 24);
      this.label16.TabIndex = 17;
      this.label16.Text = "Capture Timeout";
      this.label15.Location = new Point(8, 20);
      this.label15.Name = "label15";
      this.label15.Size = new Size(96, 16);
      this.label15.TabIndex = 16;
      this.label15.Text = "Image Quality:";
      this.textImgQuality.Location = new Point(8, 36);
      this.textImgQuality.MaxLength = 3;
      this.textImgQuality.Name = "textImgQuality";
      this.textImgQuality.Size = new Size(88, 20);
      this.textImgQuality.TabIndex = 15;
      this.textImgQuality.Text = "50";
      this.GetLiveImageBtn.BackColor = SystemColors.ActiveBorder;
      this.GetLiveImageBtn.Location = new Point(100, 12);
      this.GetLiveImageBtn.Name = "GetLiveImageBtn";
      this.GetLiveImageBtn.Size = new Size(76, 24);
      this.GetLiveImageBtn.TabIndex = 8;
      this.GetLiveImageBtn.Text = "LiveCapture";
      this.GetLiveImageBtn.UseVisualStyleBackColor = false;
      this.GetLiveImageBtn.Click += new EventHandler(this.GetLiveImageBtn_Click);
      this.GetImageBtn.BackColor = SystemColors.ActiveBorder;
      this.GetImageBtn.Location = new Point(12, 12);
      this.GetImageBtn.Name = "GetImageBtn";
      this.GetImageBtn.Size = new Size(76, 24);
      this.GetImageBtn.TabIndex = 7;
      this.GetImageBtn.Text = "Capture";
      this.GetImageBtn.UseVisualStyleBackColor = false;
      this.GetImageBtn.Click += new EventHandler(this.GetImageBtn_Click);
      this.pictureBox1.BackColor = SystemColors.ControlLight;
      this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBox1.Location = new Point(8, 48);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(260, 300);
      this.pictureBox1.TabIndex = 5;
      this.pictureBox1.TabStop = false;
      this.tabPage3.Controls.Add((Control) this.BtnVerify);
      this.tabPage3.Controls.Add((Control) this.BtnRegister);
      this.tabPage3.Controls.Add((Control) this.groupBox6);
      this.tabPage3.Controls.Add((Control) this.groupBox2);
      this.tabPage3.Controls.Add((Control) this.groupBox1);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(408, 378);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Register/Verify";
      this.BtnVerify.BackColor = SystemColors.Desktop;
      this.BtnVerify.ForeColor = SystemColors.HighlightText;
      this.BtnVerify.ImageAlign = ContentAlignment.MiddleLeft;
      this.BtnVerify.Location = new Point(280, 308);
      this.BtnVerify.Name = "BtnVerify";
      this.BtnVerify.Size = new Size(108, 23);
      this.BtnVerify.TabIndex = 34;
      this.BtnVerify.Text = "Verify";
      this.BtnVerify.UseVisualStyleBackColor = false;
      this.BtnVerify.Click += new EventHandler(this.BtnVerify_Click);
      this.BtnRegister.BackColor = SystemColors.Desktop;
      this.BtnRegister.ForeColor = SystemColors.HighlightText;
      this.BtnRegister.Location = new Point(52, 308);
      this.BtnRegister.Name = "BtnRegister";
      this.BtnRegister.Size = new Size(132, 23);
      this.BtnRegister.TabIndex = 33;
      this.BtnRegister.Text = "Register";
      this.BtnRegister.UseVisualStyleBackColor = false;
      this.BtnRegister.Click += new EventHandler(this.BtnRegister_Click);
      this.groupBox6.Controls.Add((Control) this.comboBoxSecuLevel_V);
      this.groupBox6.Controls.Add((Control) this.label14);
      this.groupBox6.Controls.Add((Control) this.label4);
      this.groupBox6.Controls.Add((Control) this.comboBoxSecuLevel_R);
      this.groupBox6.Location = new Point(8, 8);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(392, 56);
      this.groupBox6.TabIndex = 30;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Security Level";
      this.comboBoxSecuLevel_V.Items.AddRange(new object[9]
      {
        (object) "LOWEST",
        (object) "LOWER",
        (object) "LOW",
        (object) "BELOW_NORMAL",
        (object) "NORMAL",
        (object) "ABOVE_NORMAL",
        (object) "HIGH",
        (object) "HIGHER",
        (object) "HIGHEST"
      });
      this.comboBoxSecuLevel_V.Location = new Point(272, 24);
      this.comboBoxSecuLevel_V.Name = "comboBoxSecuLevel_V";
      this.comboBoxSecuLevel_V.Size = new Size(112, 21);
      this.comboBoxSecuLevel_V.TabIndex = 24;
      this.comboBoxSecuLevel_V.Text = "NORMAL";
      this.label14.Location = new Point(208, 24);
      this.label14.Name = "label14";
      this.label14.Size = new Size(64, 24);
      this.label14.TabIndex = 23;
      this.label14.Text = "Verification";
      this.label4.Location = new Point(8, 24);
      this.label4.Name = "label4";
      this.label4.Size = new Size(72, 24);
      this.label4.TabIndex = 22;
      this.label4.Text = "Registration";
      this.comboBoxSecuLevel_R.Items.AddRange(new object[9]
      {
        (object) "LOWEST",
        (object) "LOWER",
        (object) "LOW",
        (object) "BELOW_NORMAL",
        (object) "NORMAL",
        (object) "ABOVE_NORMAL",
        (object) "HIGH",
        (object) "HIGHER",
        (object) "HIGHEST"
      });
      this.comboBoxSecuLevel_R.Location = new Point(80, 24);
      this.comboBoxSecuLevel_R.Name = "comboBoxSecuLevel_R";
      this.comboBoxSecuLevel_R.Size = new Size(112, 21);
      this.comboBoxSecuLevel_R.TabIndex = 21;
      this.comboBoxSecuLevel_R.Text = "NORMAL";
      this.groupBox2.Controls.Add((Control) this.progressBar_V1);
      this.groupBox2.Controls.Add((Control) this.pictureBoxV1);
      this.groupBox2.Controls.Add((Control) this.BtnCapture3);
      this.groupBox2.Controls.Add((Control) this.comboBox1);
      this.groupBox2.Location = new Point(264, 76);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(136, 220);
      this.groupBox2.TabIndex = 29;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Verification";
      this.progressBar_V1.Location = new Point(16, 152);
      this.progressBar_V1.Name = "progressBar_V1";
      this.progressBar_V1.Size = new Size(104, 12);
      this.progressBar_V1.TabIndex = 31;
      this.pictureBoxV1.BackColor = SystemColors.Window;
      this.pictureBoxV1.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBoxV1.Location = new Point(16, 24);
      this.pictureBoxV1.Name = "pictureBoxV1";
      this.pictureBoxV1.Size = new Size(104, 128);
      this.pictureBoxV1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBoxV1.TabIndex = 29;
      this.pictureBoxV1.TabStop = false;
      this.BtnCapture3.BackColor = SystemColors.ActiveBorder;
      this.BtnCapture3.Location = new Point(16, 176);
      this.BtnCapture3.Name = "BtnCapture3";
      this.BtnCapture3.Size = new Size(104, 23);
      this.BtnCapture3.TabIndex = 27;
      this.BtnCapture3.Text = "Capture V1";
      this.BtnCapture3.UseVisualStyleBackColor = false;
      this.BtnCapture3.Click += new EventHandler(this.BtnCapture3_Click);
      this.comboBox1.Items.AddRange(new object[9]
      {
        (object) "LOWEST",
        (object) "LOWER",
        (object) "LOW",
        (object) "BELOW_NORMAL",
        (object) "NORMAL",
        (object) "ABOVE_NORMAL",
        (object) "HIGH",
        (object) "HIGHER",
        (object) "HIGHEST"
      });
      this.comboBox1.Location = new Point(48, -40);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(88, 21);
      this.comboBox1.TabIndex = 30;
      this.comboBox1.Text = "NORMAL";
      this.groupBox1.BackColor = SystemColors.ControlLight;
      this.groupBox1.Controls.Add((Control) this.progressBar_R2);
      this.groupBox1.Controls.Add((Control) this.progressBar_R1);
      this.groupBox1.Controls.Add((Control) this.pictureBoxR2);
      this.groupBox1.Controls.Add((Control) this.pictureBoxR1);
      this.groupBox1.Controls.Add((Control) this.BtnCapture1);
      this.groupBox1.Controls.Add((Control) this.BtnCapture2);
      this.groupBox1.Location = new Point(8, 76);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(244, 220);
      this.groupBox1.TabIndex = 28;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Registration";
      this.progressBar_R2.Location = new Point(128, 152);
      this.progressBar_R2.Name = "progressBar_R2";
      this.progressBar_R2.Size = new Size(104, 12);
      this.progressBar_R2.TabIndex = 29;
      this.progressBar_R1.Location = new Point(8, 152);
      this.progressBar_R1.Name = "progressBar_R1";
      this.progressBar_R1.Size = new Size(104, 12);
      this.progressBar_R1.TabIndex = 28;
      this.pictureBoxR2.BackColor = SystemColors.Window;
      this.pictureBoxR2.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBoxR2.Location = new Point(128, 24);
      this.pictureBoxR2.Name = "pictureBoxR2";
      this.pictureBoxR2.Size = new Size(104, 128);
      this.pictureBoxR2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBoxR2.TabIndex = 27;
      this.pictureBoxR2.TabStop = false;
      this.pictureBoxR1.BackColor = SystemColors.Window;
      this.pictureBoxR1.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBoxR1.Location = new Point(8, 24);
      this.pictureBoxR1.Name = "pictureBoxR1";
      this.pictureBoxR1.Size = new Size(104, 128);
      this.pictureBoxR1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBoxR1.TabIndex = 26;
      this.pictureBoxR1.TabStop = false;
      this.BtnCapture1.BackColor = SystemColors.ActiveBorder;
      this.BtnCapture1.Location = new Point(8, 176);
      this.BtnCapture1.Name = "BtnCapture1";
      this.BtnCapture1.Size = new Size(104, 23);
      this.BtnCapture1.TabIndex = 23;
      this.BtnCapture1.Text = "Capture R1";
      this.BtnCapture1.UseVisualStyleBackColor = false;
      this.BtnCapture1.Click += new EventHandler(this.BtnCapture1_Click);
      this.BtnCapture2.BackColor = SystemColors.ActiveBorder;
      this.BtnCapture2.Location = new Point(128, 176);
      this.BtnCapture2.Name = "BtnCapture2";
      this.BtnCapture2.Size = new Size(104, 23);
      this.BtnCapture2.TabIndex = 24;
      this.BtnCapture2.Text = "Capture R2";
      this.BtnCapture2.UseVisualStyleBackColor = false;
      this.BtnCapture2.Click += new EventHandler(this.BtnCapture2_Click);
      this.tabPage1.Controls.Add((Control) this.GetBtn);
      this.tabPage1.Controls.Add((Control) this.groupBox3);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new Size(408, 378);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "DeviceInfo";
      this.GetBtn.BackColor = SystemColors.ActiveBorder;
      this.GetBtn.Location = new Point(288, 16);
      this.GetBtn.Name = "GetBtn";
      this.GetBtn.Size = new Size(96, 24);
      this.GetBtn.TabIndex = 43;
      this.GetBtn.Text = "Get";
      this.GetBtn.UseVisualStyleBackColor = false;
      this.GetBtn.Click += new EventHandler(this.GetBtn_Click);
      this.groupBox3.Controls.Add((Control) this.textImageDPI);
      this.groupBox3.Controls.Add((Control) this.textImageHeight);
      this.groupBox3.Controls.Add((Control) this.textImageWidth);
      this.groupBox3.Controls.Add((Control) this.textSerialNum);
      this.groupBox3.Controls.Add((Control) this.textFWVersion);
      this.groupBox3.Controls.Add((Control) this.textDeviceID);
      this.groupBox3.Controls.Add((Control) this.textBrightness);
      this.groupBox3.Controls.Add((Control) this.textGain);
      this.groupBox3.Controls.Add((Control) this.textContrast);
      this.groupBox3.Controls.Add((Control) this.label12);
      this.groupBox3.Controls.Add((Control) this.label11);
      this.groupBox3.Controls.Add((Control) this.label10);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Controls.Add((Control) this.label8);
      this.groupBox3.Controls.Add((Control) this.label7);
      this.groupBox3.Controls.Add((Control) this.label6);
      this.groupBox3.Controls.Add((Control) this.label5);
      this.groupBox3.Controls.Add((Control) this.label13);
      this.groupBox3.Location = new Point(8, 8);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(264, 248);
      this.groupBox3.TabIndex = 41;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "DeviceInfo";
      this.textImageDPI.Enabled = false;
      this.textImageDPI.Location = new Point(96, 144);
      this.textImageDPI.Name = "textImageDPI";
      this.textImageDPI.Size = new Size(152, 20);
      this.textImageDPI.TabIndex = 66;
      this.textImageHeight.Enabled = false;
      this.textImageHeight.Location = new Point(96, 120);
      this.textImageHeight.Name = "textImageHeight";
      this.textImageHeight.Size = new Size(152, 20);
      this.textImageHeight.TabIndex = 65;
      this.textImageWidth.Enabled = false;
      this.textImageWidth.Location = new Point(96, 96);
      this.textImageWidth.Name = "textImageWidth";
      this.textImageWidth.Size = new Size(152, 20);
      this.textImageWidth.TabIndex = 64;
      this.textSerialNum.Enabled = false;
      this.textSerialNum.Location = new Point(96, 72);
      this.textSerialNum.Name = "textSerialNum";
      this.textSerialNum.Size = new Size(152, 20);
      this.textSerialNum.TabIndex = 63;
      this.textFWVersion.Enabled = false;
      this.textFWVersion.Location = new Point(96, 48);
      this.textFWVersion.Name = "textFWVersion";
      this.textFWVersion.Size = new Size(152, 20);
      this.textFWVersion.TabIndex = 62;
      this.textDeviceID.Enabled = false;
      this.textDeviceID.Location = new Point(96, 24);
      this.textDeviceID.Name = "textDeviceID";
      this.textDeviceID.Size = new Size(152, 20);
      this.textDeviceID.TabIndex = 61;
      this.textBrightness.Enabled = false;
      this.textBrightness.Location = new Point(96, 168);
      this.textBrightness.Name = "textBrightness";
      this.textBrightness.Size = new Size(152, 20);
      this.textBrightness.TabIndex = 58;
      this.textGain.Enabled = false;
      this.textGain.Location = new Point(96, 216);
      this.textGain.Name = "textGain";
      this.textGain.Size = new Size(152, 20);
      this.textGain.TabIndex = 57;
      this.textContrast.Enabled = false;
      this.textContrast.Location = new Point(96, 192);
      this.textContrast.Name = "textContrast";
      this.textContrast.Size = new Size(152, 20);
      this.textContrast.TabIndex = 56;
      this.label12.Location = new Point(16, 216);
      this.label12.Name = "label12";
      this.label12.Size = new Size(72, 16);
      this.label12.TabIndex = 55;
      this.label12.Text = "Gain";
      this.label12.TextAlign = ContentAlignment.MiddleLeft;
      this.label11.Location = new Point(16, 192);
      this.label11.Name = "label11";
      this.label11.Size = new Size(72, 16);
      this.label11.TabIndex = 54;
      this.label11.Text = "Contrast";
      this.label11.TextAlign = ContentAlignment.MiddleLeft;
      this.label10.Location = new Point(16, 168);
      this.label10.Name = "label10";
      this.label10.Size = new Size(72, 16);
      this.label10.TabIndex = 53;
      this.label10.Text = "Brightness";
      this.label10.TextAlign = ContentAlignment.MiddleLeft;
      this.label9.Location = new Point(16, 144);
      this.label9.Name = "label9";
      this.label9.Size = new Size(72, 16);
      this.label9.TabIndex = 51;
      this.label9.Text = "Image DPI";
      this.label9.TextAlign = ContentAlignment.MiddleLeft;
      this.label8.Location = new Point(16, 72);
      this.label8.Name = "label8";
      this.label8.Size = new Size(72, 16);
      this.label8.TabIndex = 49;
      this.label8.Text = "Serial #";
      this.label8.TextAlign = ContentAlignment.MiddleLeft;
      this.label7.Location = new Point(16, 48);
      this.label7.Name = "label7";
      this.label7.Size = new Size(72, 16);
      this.label7.TabIndex = 47;
      this.label7.Text = "F/W Version";
      this.label7.TextAlign = ContentAlignment.MiddleLeft;
      this.label6.Location = new Point(16, 120);
      this.label6.Name = "label6";
      this.label6.Size = new Size(72, 16);
      this.label6.TabIndex = 45;
      this.label6.Text = "Image Height";
      this.label6.TextAlign = ContentAlignment.MiddleLeft;
      this.label5.Location = new Point(16, 96);
      this.label5.Name = "label5";
      this.label5.Size = new Size(72, 16);
      this.label5.TabIndex = 43;
      this.label5.Text = "Image Width";
      this.label5.TextAlign = ContentAlignment.MiddleLeft;
      this.label13.Location = new Point(16, 24);
      this.label13.Name = "label13";
      this.label13.Size = new Size(72, 16);
      this.label13.TabIndex = 41;
      this.label13.Text = "Device ID";
      this.label13.TextAlign = ContentAlignment.MiddleLeft;
      this.tabPage4.Controls.Add((Control) this.tbxCustomerCodeVerify);
      this.tabPage4.Controls.Add((Control) this.button3);
      this.tabPage4.Controls.Add((Control) this.button2);
      this.tabPage4.Controls.Add((Control) this.pictureBox3);
      this.tabPage4.Controls.Add((Control) this.pictureBox2);
      this.tabPage4.Controls.Add((Control) this.button1);
      this.tabPage4.Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new Padding(3);
      this.tabPage4.Size = new Size(408, 378);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "tabPage4";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.button3.BackColor = SystemColors.ActiveBorder;
      this.button3.Location = new Point(227, 256);
      this.button3.Name = "button3";
      this.button3.Size = new Size(76, 24);
      this.button3.TabIndex = 12;
      this.button3.Text = "get";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button2.BackColor = SystemColors.ActiveBorder;
      this.button2.Location = new Point(227, 348);
      this.button2.Name = "button2";
      this.button2.Size = new Size(76, 24);
      this.button2.TabIndex = 11;
      this.button2.Text = "verify";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.pictureBox3.BackColor = SystemColors.ControlLight;
      this.pictureBox3.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBox3.Location = new Point(192, 72);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(157, 161);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 10;
      this.pictureBox3.TabStop = false;
      this.pictureBox2.BackColor = SystemColors.ControlLight;
      this.pictureBox2.BorderStyle = BorderStyle.Fixed3D;
      this.pictureBox2.Location = new Point(8, 72);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(157, 161);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 9;
      this.pictureBox2.TabStop = false;
      this.button1.BackColor = SystemColors.ActiveBorder;
      this.button1.Location = new Point(43, 256);
      this.button1.Name = "button1";
      this.button1.Size = new Size(76, 24);
      this.button1.TabIndex = 8;
      this.button1.Text = "Capture";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.comboBoxDeviceName.Location = new Point(84, 8);
      this.comboBoxDeviceName.Name = "comboBoxDeviceName";
      this.comboBoxDeviceName.Size = new Size(152, 21);
      this.comboBoxDeviceName.TabIndex = 1;
      this.label1.Location = new Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 24);
      this.label1.TabIndex = 3;
      this.label1.Text = "Device Name";
      this.StatusBar.BorderStyle = BorderStyle.Fixed3D;
      this.StatusBar.Dock = DockStyle.Bottom;
      this.StatusBar.ForeColor = SystemColors.Highlight;
      this.StatusBar.Location = new Point(0, 457);
      this.StatusBar.Name = "StatusBar";
      this.StatusBar.Size = new Size(416, 24);
      this.StatusBar.TabIndex = 7;
      this.StatusBar.Text = "Click Init Button";
      this.EnumerateBtn.BackColor = SystemColors.ActiveBorder;
      this.EnumerateBtn.Location = new Point(332, 8);
      this.EnumerateBtn.Name = "EnumerateBtn";
      this.EnumerateBtn.Size = new Size(72, 24);
      this.EnumerateBtn.TabIndex = 8;
      this.EnumerateBtn.Text = "Enumerate";
      this.EnumerateBtn.UseVisualStyleBackColor = false;
      this.EnumerateBtn.Click += new EventHandler(this.EnumerateBtn_Click);
      this.OpenDeviceBtn.BackColor = SystemColors.ActiveBorder;
      this.OpenDeviceBtn.Location = new Point(248, 8);
      this.OpenDeviceBtn.Name = "OpenDeviceBtn";
      this.OpenDeviceBtn.Size = new Size(72, 24);
      this.OpenDeviceBtn.TabIndex = 9;
      this.OpenDeviceBtn.Text = "Init";
      this.OpenDeviceBtn.UseVisualStyleBackColor = false;
      this.OpenDeviceBtn.Click += new EventHandler(this.OpenDeviceBtn_Click);
      this.tbxCustomerCodeVerify.Location = new Point(192, 296);
      this.tbxCustomerCodeVerify.Name = "tbxCustomerCodeVerify";
      this.tbxCustomerCodeVerify.Size = new Size(100, 20);
      this.tbxCustomerCodeVerify.TabIndex = 13;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(416, 481);
      this.Controls.Add((Control) this.OpenDeviceBtn);
      this.Controls.Add((Control) this.EnumerateBtn);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBoxDeviceName);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.StatusBar);
      this.Name = nameof (MainForm);
      this.Text = "Matching C# Sample";
      this.Load += new EventHandler(this.MainForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.GroupBox8.ResumeLayout(false);
      this.BrightnessUpDown.EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.tabPage3.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBoxV1).EndInit();
      this.groupBox1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBoxR2).EndInit();
      ((ISupportInitialize) this.pictureBoxR1).EndInit();
      this.tabPage1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
    }

    [STAThread]
    private static void Main() => Application.Run((Form) new MainForm());

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.boolLedOn = false;
      this.m_RegMin1 = new byte[400];
      this.m_RegMin2 = new byte[400];
      this.m_VrfMin = new byte[400];
      this.mREGISTER = new byte[400];
      this.mREGISTER2 = new byte[400];
      this.comboBoxSecuLevel_R.SelectedIndex = 4;
      this.comboBoxSecuLevel_V.SelectedIndex = 3;
      this.EnableButtons(false);
      this.m_FPM = new SGFingerPrintManager();
      this.EnumerateBtn_Click(sender, e);
      this.tbxCustomerCode.Text = DateTime.Now.ToString();
      this.OpenDeviceBtn.PerformClick();
    }

    private void save(string fingerprint, string customerId)
    {
      string strError = "";
      string text = SQLHelper.RunCommand("update tblCustomers set FingerPrint  = @FingerPrint where CID=@CID", new List<OleDbParameter>()
      {
        new OleDbParameter("FingerPrint", (object) fingerprint),
        new OleDbParameter("CID", (object) customerId)
      }, ref strError);
      if (text.Equals("Done"))
      {
        int num1 = (int) MessageBox.Show("Customer Edited successfully");
      }
      else
      {
        int num2 = (int) MessageBox.Show(text);
      }
    }

    private void EnumerateBtn_Click(object sender, EventArgs e)
    {
      this.comboBoxDeviceName.Items.Clear();
      this.m_FPM.EnumerateDevice();
      this.m_DevList = new SGFPMDeviceList[this.m_FPM.NumberOfDevice];
      for (int nDevs = 0; nDevs < this.m_FPM.NumberOfDevice; ++nDevs)
      {
        this.m_DevList[nDevs] = new SGFPMDeviceList();
        this.m_FPM.GetEnumDeviceInfo(nDevs, this.m_DevList[nDevs]);
        this.comboBoxDeviceName.Items.Add((object) (this.m_DevList[nDevs].DevName.ToString() + " : " + (object) this.m_DevList[nDevs].DevID));
      }
      if (this.comboBoxDeviceName.Items.Count <= 0)
        return;
      this.comboBoxDeviceName.Items.Add((object) "Auto Selection");
      this.comboBoxDeviceName.SelectedIndex = 0;
    }

    private void OpenDeviceBtn_Click(object sender, EventArgs e)
    {
      if (this.m_FPM.NumberOfDevice == 0)
        return;
      int count = this.comboBoxDeviceName.Items.Count;
      int selectedIndex = this.comboBoxDeviceName.SelectedIndex;
      SGFPMDeviceName devName;
      int devId;
      if (selectedIndex == count - 1)
      {
        devName = SGFPMDeviceName.DEV_AUTO;
        devId = 597;
      }
      else
      {
        devName = this.m_DevList[selectedIndex].DevName;
        devId = this.m_DevList[selectedIndex].DevID;
      }
      this.m_FPM.Init(devName);
      int iError = this.m_FPM.OpenDevice(devId);
      this.CheckBoxAutoOn.Enabled = false;
      if (iError == 0)
      {
        this.GetBtn_Click(sender, e);
        this.StatusBar.Text = "Initialization Success";
        this.EnableButtons(true);
        if (devName != SGFPMDeviceName.DEV_FDU03 && devName != SGFPMDeviceName.DEV_FDU04)
          return;
        this.CheckBoxAutoOn.Enabled = true;
      }
      else
        this.DisplayError("OpenDevice()", iError);
    }

    private void LedBtn_Click(object sender, EventArgs e)
    {
      this.boolLedOn = !this.boolLedOn;
      this.m_FPM.SetLedOn(this.boolLedOn);
    }

    private void ConfigBtn_Click(object sender, EventArgs e) => this.m_FPM.Configure((int) this.Handle);

    private void GetImageBtn_Click(object sender, EventArgs e)
    {
      int tickCount = Environment.TickCount;
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int image = this.m_FPM.GetImage(numArray);
      if (image == 0)
      {
        int num = Environment.TickCount - tickCount;
        this.DrawImage(numArray, this.pictureBox1);
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        this.m_FPM.CreateTemplate(numArray, this.m_RegMin1);
        this.save(Encoding.ASCII.GetString(this.m_RegMin1), this.tbxCustomerCode.Text);
        this.StatusBar.Text = "Capture Time : " + (object) num + " ms";
      }
      else
        this.DisplayError("GetImage()", image);
    }

    public Image byteArrayToImage(byte[] byteArrayIn) => Image.FromStream((Stream) new MemoryStream(byteArrayIn));

    private void GetLiveImageBtn_Click(object sender, EventArgs e)
    {
      int int32_1 = Convert.ToInt32(this.textTimeout.Text);
      int int32_2 = Convert.ToInt32(this.textImgQuality.Text);
      byte[] buffer = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int tickCount = Environment.TickCount;
      int imageEx = this.m_FPM.GetImageEx(buffer, int32_1, this.pictureBox1.Handle.ToInt32(), int32_2);
      if (imageEx == 0)
        this.StatusBar.Text = "Capture Time : " + (object) (Environment.TickCount - tickCount) + "millisec";
      else
        this.DisplayError("GetLiveImageEx()", imageEx);
    }

    private void BtnCapture1_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int quality = 0;
      int image = this.m_FPM.GetImage(numArray);
      this.m_FPM.GetImageQuality(this.m_ImageWidth, this.m_ImageHeight, numArray, ref quality);
      this.progressBar_R1.Value = quality;
      if (image == 0)
      {
        this.DrawImage(numArray, this.pictureBoxR1);
        int template = this.m_FPM.CreateTemplate(numArray, this.m_RegMin1);
        if (template == 0)
          this.StatusBar.Text = "First image is captured";
        else
          this.DisplayError("CreateTemplate()", template);
      }
      else
        this.DisplayError("GetImage()", image);
    }

    private void BtnCapture2_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int quality = 0;
      int image = this.m_FPM.GetImage(numArray);
      this.m_FPM.GetImageQuality(this.m_ImageWidth, this.m_ImageHeight, numArray, ref quality);
      this.progressBar_R2.Value = quality;
      if (image == 0)
      {
        this.DrawImage(numArray, this.pictureBoxR2);
        int template = this.m_FPM.CreateTemplate(numArray, this.m_RegMin2);
        if (template == 0)
          this.StatusBar.Text = "Second image is captured";
        else
          this.DisplayError("CreateTemplate()", template);
      }
      else
        this.DisplayError("GetImage()", image);
    }

    private void BtnCapture3_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int quality = 0;
      int image = this.m_FPM.GetImage(numArray);
      this.m_FPM.GetImageQuality(this.m_ImageWidth, this.m_ImageHeight, numArray, ref quality);
      this.progressBar_V1.Value = quality;
      if (image == 0)
      {
        this.DrawImage(numArray, this.pictureBoxV1);
        int template = this.m_FPM.CreateTemplate((SGFPMFingerInfo) null, numArray, this.m_VrfMin);
        if (template == 0)
          this.StatusBar.Text = "Image for verification is captured";
        else
          this.DisplayError("CreateTemplate()", template);
      }
      else
        this.DisplayError("GetImage()", image);
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
      bool matched = false;
      int score = 0;
      this.m_FPM.MatchTemplate(this.m_RegMin1, this.m_RegMin2, (SGFPMSecurityLevel) this.comboBoxSecuLevel_R.SelectedIndex, ref matched);
      int matchingScore = this.m_FPM.GetMatchingScore(this.m_RegMin1, this.m_RegMin2, ref score);
      if (matchingScore == 0)
      {
        if (matched)
          this.StatusBar.Text = "Registration Success, Matching Score: " + (object) score;
        else
          this.StatusBar.Text = "Registration Failed";
      }
      else
        this.DisplayError("GetMatchingScore()", matchingScore);
    }

    private void BtnVerify_Click(object sender, EventArgs e)
    {
      bool matched1 = false;
      bool matched2 = false;
      SGFPMSecurityLevel selectedIndex = (SGFPMSecurityLevel) this.comboBoxSecuLevel_V.SelectedIndex;
      this.m_FPM.MatchTemplate(this.m_RegMin1, this.m_VrfMin, selectedIndex, ref matched1);
      int iError = this.m_FPM.MatchTemplate(this.m_RegMin2, this.m_VrfMin, selectedIndex, ref matched2);
      if (iError == 0)
      {
        if (matched1 & matched2)
          this.StatusBar.Text = "Verification Success";
        else
          this.StatusBar.Text = "Verification Failed";
      }
      else
        this.DisplayError("MatchTemplate()", iError);
    }

    private void GetBtn_Click(object sender, EventArgs e)
    {
      SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
      if (this.m_FPM.GetDeviceInfo(pInfo) != 0)
        return;
      this.m_ImageWidth = pInfo.ImageWidth;
      this.m_ImageHeight = pInfo.ImageHeight;
      this.textDeviceID.Text = Convert.ToString(pInfo.DeviceID);
      this.textImageDPI.Text = Convert.ToString(pInfo.ImageDPI);
      this.textFWVersion.Text = Convert.ToString(pInfo.FWVersion, 16);
      this.textSerialNum.Text = new ASCIIEncoding().GetString(pInfo.DeviceSN);
      this.textImageHeight.Text = Convert.ToString(pInfo.ImageHeight);
      this.textImageWidth.Text = Convert.ToString(pInfo.ImageWidth);
      this.textBrightness.Text = Convert.ToString(pInfo.Brightness);
      this.textContrast.Text = Convert.ToString(pInfo.Contrast);
      this.textGain.Text = Convert.ToString(pInfo.Gain);
      this.BrightnessUpDown.Value = (Decimal) pInfo.Brightness;
    }

    private void SetBrightnessBtn_Click(object sender, EventArgs e)
    {
      int iError = this.m_FPM.SetBrightness((int) this.BrightnessUpDown.Value);
      if (iError == 0)
      {
        this.StatusBar.Text = "SetBrightness success";
        this.GetBtn_Click(sender, e);
      }
      else
        this.DisplayError("SetBrightness()", iError);
    }

    private void CheckBoxAutoOn_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckBoxAutoOn.Checked)
        this.m_FPM.EnableAutoOnEvent(true, (int) this.Handle);
      else
        this.m_FPM.EnableAutoOnEvent(false, 0);
    }

    protected override void WndProc(ref Message message)
    {
      if (message.Msg == 33024)
      {
        if (message.WParam.ToInt32() == 1)
          this.StatusBar.Text = "Device Message: Finger On";
        else if (message.WParam.ToInt32() == 0)
          this.StatusBar.Text = "Device Message: Finger Off";
      }
      base.WndProc(ref message);
    }

    private void DrawImage(byte[] imgData, PictureBox picBox)
    {
      Bitmap bitmap = new Bitmap(this.m_ImageWidth, this.m_ImageHeight);
      picBox.Image = (Image) bitmap;
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          int num = (int) imgData[y * this.m_ImageWidth + x];
          bitmap.SetPixel(x, y, Color.FromArgb(num, num, num));
        }
      }
      picBox.Refresh();
    }

    private void EnableButtons(bool enable)
    {
      this.ConfigBtn.Enabled = enable;
      this.GetImageBtn.Enabled = enable;
      this.GetLiveImageBtn.Enabled = enable;
      this.BtnCapture1.Enabled = enable;
      this.BtnCapture2.Enabled = enable;
      this.BtnCapture3.Enabled = enable;
      this.BtnRegister.Enabled = enable;
      this.BtnVerify.Enabled = enable;
      this.GetBtn.Enabled = enable;
      this.SetBrightnessBtn.Enabled = enable;
    }

    private void DisplayError(string funcName, int iError)
    {
      string str = "";
      switch (iError)
      {
        case 0:
          str = "Error none";
          break;
        case 1:
          str = "Can not create object";
          break;
        case 2:
          str = "Function Failed";
          break;
        case 3:
          str = "Invalid Parameter";
          break;
        case 4:
          str = "Not used function";
          break;
        case 5:
          str = "Can not create object";
          break;
        case 6:
          str = "Can not load device driver";
          break;
        case 7:
          str = "Can not load sgfpamx.dll";
          break;
        case 51:
          str = "Can not load driver kernel file";
          break;
        case 52:
          str = "Failed to initialize the device";
          break;
        case 53:
          str = "Data transmission is not good";
          break;
        case 54:
          str = "Time out";
          break;
        case 55:
          str = "Device not found";
          break;
        case 56:
          str = "Can not load driver file";
          break;
        case 57:
          str = "Wrong Image";
          break;
        case 58:
          str = "Lack of USB Bandwith";
          break;
        case 59:
          str = "Device is already opened";
          break;
        case 60:
          str = "Device serial number error";
          break;
        case 61:
          str = "Unsupported device";
          break;
        case 101:
          str = "The number of minutiae is too small";
          break;
        case 102:
          str = "Template is invalid";
          break;
        case 103:
          str = "1st template is invalid";
          break;
        case 104:
          str = "2nd template is invalid";
          break;
        case 105:
          str = "Minutiae extraction failed";
          break;
        case 106:
          str = "Matching failed";
          break;
      }
      this.StatusBar.Text = funcName + " Error # " + (object) iError + " :" + str;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      int quality = 0;
      int image = this.m_FPM.GetImage(numArray);
      this.m_FPM.GetImageQuality(this.m_ImageWidth, this.m_ImageHeight, numArray, ref quality);
      this.progressBar_R1.Value = quality;
      if (image == 0)
      {
        this.DrawImage(numArray, this.pictureBox2);
        int template = this.m_FPM.CreateTemplate(numArray, this.mREGISTER);
        if (template == 0)
          this.StatusBar.Text = "First image is captured";
        else
          this.DisplayError("CreateTemplate()", template);
      }
      else
        this.DisplayError("GetImage()", image);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      bool matched = false;
      int iError = this.m_FPM.MatchTemplate(this.mREGISTER, this.mREGISTER2, (SGFPMSecurityLevel) this.comboBoxSecuLevel_V.SelectedIndex, ref matched);
      if (iError == 0)
      {
        if (matched)
          this.StatusBar.Text = "Verification Success";
        else
          this.StatusBar.Text = "Verification Failed";
      }
      else
        this.DisplayError("MatchTemplate()", iError);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[this.m_ImageWidth * this.m_ImageHeight];
      string strError = "";
      string my_querry = "Select * from tblCustomers ";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
      {
        string s = row["fingerprint"].ToString();
        if (s != null && s != "")
        {
          this.mREGISTER2 = Encoding.ASCII.GetBytes(s);
          if (this.verify())
          {
            int num = (int) MessageBox.Show(row["cid"].ToString());
            break;
          }
        }
      }
    }

    private bool verify()
    {
      bool matched = false;
      int iError = this.m_FPM.MatchTemplate(this.mREGISTER, this.mREGISTER2, (SGFPMSecurityLevel) this.comboBoxSecuLevel_V.SelectedIndex, ref matched);
      if (iError == 0)
      {
        if (!matched)
          return false;
        this.StatusBar.Text = "Verification Success";
        return true;
      }
      this.DisplayError("MatchTemplate()", iError);
      return false;
    }

    private string getFingerprint(string customerCode)
    {
      string strError = "";
      string my_querry = "Select * from tblCustomers where CID like @cid";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("CID", (object) customerCode));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      return dataTable2 != null && dataTable2.Rows.Count > 0 ? dataTable2.Rows[0]["fingerprint"].ToString() : "";
    }

    public byte[] imageToByteArray(Image imageIn)
    {
      MemoryStream memoryStream = new MemoryStream();
      imageIn.Save((Stream) memoryStream, ImageFormat.Bmp);
      return memoryStream.ToArray();
    }
  }
}
