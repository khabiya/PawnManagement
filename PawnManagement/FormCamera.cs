
using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Touchless.Vision.Camera;
using Touchless.Vision.Contracts;

namespace PawnManagement
{
  public class FormCamera : Form
  {
    private string filepath = string.Empty;
    private string mode = "";
    private string registerNumber = "";
    private CameraFrameSource _frameSource;
    private static Bitmap _latestFrame;
    private IContainer components = (IContainer) null;
    private PictureBox pictureBoxDisplay;
    private ComboBox comboBoxCameras;
    private GlassButton btnConfig;
    private Panel panel1;
    private Label label1;
    private Button btnClose;
    private Button btnSave;
    private Button btnStart;
    private Button btnStop;
    private Panel panel2;
    private Panel panel3;

    public FormCamera(string regNumber, string str)
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.registerNumber = regNumber;
      this.mode = str;
    }

    public FormCamera(string regNumber, string strMode, string strFilePath)
    {
      this.InitializeComponent();
      this.registerNumber = regNumber;
      this.mode = strMode;
      this.filepath = strFilePath;
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        return createParams;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      else if (keyData != Keys.Up)
        ;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        if (control1 is Button)
        {
          Button button = (Button) control1;
          button.Enter += new EventHandler(this.btn_Enter);
          button.Leave += new EventHandler(this.btn_Leave);
          button.MouseEnter += new EventHandler(this.btn_MouseEnter);
          button.MouseLeave += new EventHandler(this.btn_MouseLeave);
        }
        else
          this.Assign(control1);
      }
    }

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void btn_Enter(object sender, EventArgs e) => (sender as Button).BackColor = Color.GreenYellow;

    private void btn_Leave(object sender, EventArgs e) => (sender as Button).BackColor = Color.Transparent;

    private void btn_MouseEnter(object sender, EventArgs e) => (sender as Button).BackColor = Color.GreenYellow;

    private void btn_MouseLeave(object sender, EventArgs e) => (sender as Button).BackColor = Color.Transparent;

    public static Control FindFocusedControl(Control control)
    {
      for (IContainerControl containerControl = control as IContainerControl; containerControl != null; containerControl = control as IContainerControl)
        control = containerControl.ActiveControl;
      return control;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      if (this.DesignMode)
        return;
      this.comboBoxCameras.Items.Clear();
      foreach (object availableCamera in (IEnumerable<Touchless.Vision.Camera.Camera>) CameraService.AvailableCameras)
        this.comboBoxCameras.Items.Add(availableCamera);
      if (this.comboBoxCameras.Items.Count > 0)
        this.comboBoxCameras.SelectedIndex = 0;
      this.Assign((Control) this);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => this.thrashOldCamera();

    private void startCapturing()
    {
      try
      {
        this.setFrameSource(new CameraFrameSource((Touchless.Vision.Camera.Camera) this.comboBoxCameras.SelectedItem));
        this._frameSource.Camera.CaptureWidth = 640;
        this._frameSource.Camera.CaptureHeight = 480;
        this._frameSource.Camera.Fps = 20;
        this._frameSource.NewFrame += new Action<IFrameSource, Frame, double>(this.OnImageCaptured);
        this.pictureBoxDisplay.Paint += new PaintEventHandler(this.drawLatestImage);
        this._frameSource.StartFrameCapture();
      }
      catch (Exception ex)
      {
        this.comboBoxCameras.Text = "Select A Camera";
        int num = (int) MessageBox.Show(ex.Message);
        throw;
      }
    }

    private void drawLatestImage(object sender, PaintEventArgs e)
    {
      if (FormCamera._latestFrame == null)
        return;
      e.Graphics.DrawImage((Image) FormCamera._latestFrame, 0, 0, FormCamera._latestFrame.Width, FormCamera._latestFrame.Height);
    }

    public void OnImageCaptured(IFrameSource frameSource, Frame frame, double fps)
    {
      FormCamera._latestFrame = frame.Image;
      this.pictureBoxDisplay.Invalidate();
    }

    private void setFrameSource(CameraFrameSource cameraFrameSource)
    {
      if (this._frameSource == cameraFrameSource)
        return;
      this._frameSource = cameraFrameSource;
    }

    private void thrashOldCamera()
    {
      if (this._frameSource == null || FormCamera._latestFrame == null)
        return;
      this._frameSource.NewFrame -= new Action<IFrameSource, Frame, double>(this.OnImageCaptured);
      this._frameSource.Camera.Dispose();
      this.setFrameSource((CameraFrameSource) null);
      this.pictureBoxDisplay.Paint -= new PaintEventHandler(this.drawLatestImage);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Image image = (Image) FormCamera._latestFrame.Clone();
      try
      {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
          saveFileDialog.Filter = "*.bmp|*.bmp";
          if (this.mode == "customerPhoto")
            this.filepath = "Photos\\temp\\" + this.registerNumber + ".png";
          if (this.mode == "proofPhoto")
            this.filepath = "Photos\\OthersFront\\" + this.registerNumber + ".png";
          if (this.mode == "jewelPhoto")
            this.filepath = "Photos\\jewels\\" + this.registerNumber + ".png";
          if (this.mode == "releasedByPhoto")
            this.filepath = "Photos\\released By\\" + this.registerNumber + ".png";
          image.Save(FormMain.startUpPath + this.filepath);
          int num = (int) MessageBox.Show(FormMain.startUpPath + this.filepath);
        }
        image.Dispose();
        this.btnClose.Focus();
      }
      catch (Exception ex)
      {
        image.Dispose();
        int num = (int) MessageBox.Show(ex.Message + (object) ex.Data);
        throw;
      }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (this._frameSource != null && this._frameSource.Camera == this.comboBoxCameras.SelectedItem)
        return;
      this.thrashOldCamera();
      this.startCapturing();
      this.btnStop.Focus();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      try
      {
        this.thrashOldCamera();
        this.btnSave.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message + " stack trace" + ex.StackTrace + "Srouce" + ex.Source);
        throw;
      }
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
      if (this._frameSource == null)
        return;
      this._frameSource.Camera.ShowPropertiesDialog();
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void FormCamera_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
        this.btnStart.PerformClick();
      else if (e.KeyCode == Keys.F2)
        this.btnStop.PerformClick();
      else if (e.KeyCode == Keys.F3)
      {
        this.btnSave.PerformClick();
      }
      else
      {
        if (e.KeyCode != Keys.F4)
          return;
        this.btnClose.PerformClick();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormCamera));
      this.pictureBoxDisplay = new PictureBox();
      this.comboBoxCameras = new ComboBox();
      this.btnConfig = new GlassButton();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.btnClose = new Button();
      this.btnSave = new Button();
      this.btnStart = new Button();
      this.btnStop = new Button();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      ((ISupportInitialize) this.pictureBoxDisplay).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.pictureBoxDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pictureBoxDisplay.BackColor = Color.WhiteSmoke;
      this.pictureBoxDisplay.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBoxDisplay.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBoxDisplay.Location = new Point(0, 41);
      this.pictureBoxDisplay.Name = "pictureBoxDisplay";
      this.pictureBoxDisplay.Size = new Size(671, 480);
      this.pictureBoxDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBoxDisplay.TabIndex = 13;
      this.pictureBoxDisplay.TabStop = false;
      this.comboBoxCameras.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.comboBoxCameras.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxCameras.FormattingEnabled = true;
      this.comboBoxCameras.Location = new Point(219, 11);
      this.comboBoxCameras.Name = "comboBoxCameras";
      this.comboBoxCameras.Size = new Size(331, 21);
      this.comboBoxCameras.TabIndex = 0;
      ((Control) this.btnConfig).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnConfig.BackColor = Color.LightBlue;
      this.btnConfig.FadeOnFocus = true;
      this.btnConfig.ForeColor = Color.MediumBlue;
      this.btnConfig.ForeColorOnFocus = Color.Red;
      this.btnConfig.ForeColorOnLeave = Color.RoyalBlue;
      this.btnConfig.GlowColor = Color.White;
      this.btnConfig.InnerBorderColor = Color.Transparent;
      ((Control) this.btnConfig).Location = new Point(554, 9);
      ((Control) this.btnConfig).Name = "btnConfig";
      this.btnConfig.OuterBorderColor = Color.MediumSlateBlue;
      this.btnConfig.ShineColor = Color.Transparent;
      ((Control) this.btnConfig).Size = new Size(112, 23);
      ((Control) this.btnConfig).TabIndex = 1;
      ((Control) this.btnConfig).Text = "Configuration";
      ((Control) this.btnConfig).Click += new EventHandler(this.btnConfig_Click);
      this.panel1.BackColor = Color.White;
      this.panel1.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.comboBoxCameras);
      this.panel1.Controls.Add((Control) this.btnConfig);
      this.panel1.Location = new Point(0, 517);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(671, 41);
      this.panel1.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(4, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(209, 25);
      this.label1.TabIndex = 2;
      this.label1.Text = "SELECT CAMERA - ";
      this.btnClose.Anchor = AnchorStyles.Bottom;
      this.btnClose.BackColor = Color.Transparent;
      this.btnClose.FlatAppearance.BorderColor = Color.Black;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnClose.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnClose.FlatStyle = FlatStyle.Popup;
      this.btnClose.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnClose.ForeColor = Color.Black;
      this.btnClose.Image = (Image) componentResourceManager.GetObject("btnClose.Image");
      this.btnClose.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnClose.Location = new Point(504, 12);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(159, 51);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "    &Close(F4)";
      this.btnClose.TextAlign = ContentAlignment.MiddleRight;
      this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.btnClose.Enter += new EventHandler(this.btn_Enter);
      this.btnClose.Leave += new EventHandler(this.btn_Leave);
      this.btnClose.MouseEnter += new EventHandler(this.btn_MouseEnter);
      this.btnClose.MouseLeave += new EventHandler(this.btn_MouseLeave);
      this.btnSave.Anchor = AnchorStyles.Bottom;
      this.btnSave.BackColor = Color.Transparent;
      this.btnSave.FlatAppearance.BorderColor = Color.Black;
      this.btnSave.FlatAppearance.BorderSize = 0;
      this.btnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnSave.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnSave.FlatStyle = FlatStyle.Popup;
      this.btnSave.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.Black;
      this.btnSave.Image = (Image) componentResourceManager.GetObject("btnSave.Image");
      this.btnSave.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSave.Location = new Point(334, 12);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(164, 51);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "    &Save";
      this.btnSave.TextAlign = ContentAlignment.MiddleRight;
      this.btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.btnSave.Enter += new EventHandler(this.btn_Enter);
      this.btnSave.Leave += new EventHandler(this.btn_Leave);
      this.btnSave.MouseEnter += new EventHandler(this.btn_MouseEnter);
      this.btnSave.MouseLeave += new EventHandler(this.btn_MouseLeave);
      this.btnStart.Anchor = AnchorStyles.Bottom;
      this.btnStart.BackColor = Color.Transparent;
      this.btnStart.FlatAppearance.BorderColor = Color.Black;
      this.btnStart.FlatAppearance.BorderSize = 0;
      this.btnStart.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnStart.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnStart.FlatStyle = FlatStyle.Popup;
      this.btnStart.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnStart.ForeColor = Color.Black;
      this.btnStart.Image = (Image) componentResourceManager.GetObject("btnStart.Image");
      this.btnStart.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnStart.Location = new Point(6, 12);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new Size(159, 51);
      this.btnStart.TabIndex = 0;
      this.btnStart.Text = "    Start";
      this.btnStart.TextAlign = ContentAlignment.MiddleRight;
      this.btnStart.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnStart.UseVisualStyleBackColor = false;
      this.btnStart.Click += new EventHandler(this.btnStart_Click);
      this.btnStart.Enter += new EventHandler(this.btn_Enter);
      this.btnStart.Leave += new EventHandler(this.btn_Leave);
      this.btnStart.MouseEnter += new EventHandler(this.btn_MouseEnter);
      this.btnStart.MouseLeave += new EventHandler(this.btn_MouseLeave);
      this.btnStop.Anchor = AnchorStyles.Bottom;
      this.btnStop.BackColor = Color.Transparent;
      this.btnStop.FlatAppearance.BorderColor = Color.Black;
      this.btnStop.FlatAppearance.BorderSize = 0;
      this.btnStop.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnStop.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnStop.FlatStyle = FlatStyle.Popup;
      this.btnStop.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnStop.ForeColor = Color.Black;
      this.btnStop.Image = (Image) componentResourceManager.GetObject("btnStop.Image");
      this.btnStop.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnStop.Location = new Point(169, 12);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new Size(159, 51);
      this.btnStop.TabIndex = 1;
      this.btnStop.Text = "    Stop";
      this.btnStop.TextAlign = ContentAlignment.MiddleRight;
      this.btnStop.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnStop.UseVisualStyleBackColor = false;
      this.btnStop.Click += new EventHandler(this.btnStop_Click);
      this.btnStop.Enter += new EventHandler(this.btn_Enter);
      this.btnStop.Leave += new EventHandler(this.btn_Leave);
      this.btnStop.MouseEnter += new EventHandler(this.btn_MouseEnter);
      this.btnStop.MouseLeave += new EventHandler(this.btn_MouseLeave);
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.btnStop);
      this.panel2.Controls.Add((Control) this.btnClose);
      this.panel2.Controls.Add((Control) this.btnStart);
      this.panel2.Controls.Add((Control) this.btnSave);
      this.panel2.Dock = DockStyle.Bottom;
      this.panel2.Location = new Point(0, 556);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(671, 72);
      this.panel2.TabIndex = 0;
      this.panel3.BackColor = Color.White;
      this.panel3.BackgroundImage = (Image) componentResourceManager.GetObject("panel3.BackgroundImage");
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Dock = DockStyle.Top;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(671, 41);
      this.panel3.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.WhiteSmoke;
      this.ClientSize = new Size(671, 628);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.pictureBoxDisplay);
      this.Controls.Add((Control) this.panel2);
      this.ForeColor = Color.CornflowerBlue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.KeyPreview = true;
      this.MinimumSize = new Size(640, 520);
      this.Name = nameof (FormCamera);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "WebCam Demo";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new EventHandler(this.MainForm_Load);
      this.KeyDown += new KeyEventHandler(this.FormCamera_KeyDown);
      ((ISupportInitialize) this.pictureBoxDisplay).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
