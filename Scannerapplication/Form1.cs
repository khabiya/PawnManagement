
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WIATest;

namespace Scannerapplication
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    private Button showImages;
    private Splitter splitter1;
    private Panel pnl_capture;
    private PictureBox pic_scan;
    private ListBox lbDevices;
    private Button btn_scan;

    public Form1() => this.InitializeComponent();

    private void btn_scan_Click(object sender, EventArgs e)
    {
      try
      {
        foreach (object device in WIAScanner.GetDevices())
          this.lbDevices.Items.Add(device);
        if (this.lbDevices.Items.Count == 0)
        {
          int num = (int) MessageBox.Show("You do not have any WIA devices.");
          this.Close();
        }
        else
          this.lbDevices.SelectedIndex = 0;
        foreach (Image image in WIAScanner.Scan((string) this.lbDevices.SelectedItem))
        {
          this.pic_scan.Image = image;
          this.pic_scan.Show();
          this.pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
          image.Save("D:\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void Home_SizeChanged(object sender, EventArgs e)
    {
      int height = this.Size.Height - 153;
      this.pic_scan.Size = new Size(height - 150, height);
    }

    private void Form1_Load(object sender, EventArgs e)
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
      this.showImages = new Button();
      this.splitter1 = new Splitter();
      this.pnl_capture = new Panel();
      this.pic_scan = new PictureBox();
      this.lbDevices = new ListBox();
      this.btn_scan = new Button();
      this.pnl_capture.SuspendLayout();
      ((ISupportInitialize) this.pic_scan).BeginInit();
      this.SuspendLayout();
      this.showImages.Location = new Point(242, 216);
      this.showImages.Name = "showImages";
      this.showImages.Size = new Size(85, 23);
      this.showImages.TabIndex = 5;
      this.showImages.Text = "Show Images";
      this.showImages.UseVisualStyleBackColor = true;
      this.showImages.Visible = false;
      this.splitter1.Dock = DockStyle.Top;
      this.splitter1.Location = new Point(0, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(787, 3);
      this.splitter1.TabIndex = 38;
      this.splitter1.TabStop = false;
      this.pnl_capture.BackColor = Color.Transparent;
      this.pnl_capture.Controls.Add((Control) this.pic_scan);
      this.pnl_capture.Controls.Add((Control) this.lbDevices);
      this.pnl_capture.Controls.Add((Control) this.btn_scan);
      this.pnl_capture.Dock = DockStyle.Fill;
      this.pnl_capture.Location = new Point(0, 3);
      this.pnl_capture.Name = "pnl_capture";
      this.pnl_capture.Size = new Size(787, 712);
      this.pnl_capture.TabIndex = 39;
      this.pic_scan.BackColor = Color.White;
      this.pic_scan.Location = new Point(165, 21);
      this.pic_scan.Name = "pic_scan";
      this.pic_scan.Size = new Size(450, 600);
      this.pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pic_scan.TabIndex = 6;
      this.pic_scan.TabStop = false;
      this.pic_scan.Visible = false;
      this.lbDevices.FormattingEnabled = true;
      this.lbDevices.Location = new Point(21, 53);
      this.lbDevices.Name = "lbDevices";
      this.lbDevices.Size = new Size(120, 30);
      this.lbDevices.TabIndex = 5;
      this.lbDevices.Visible = false;
      this.btn_scan.ForeColor = SystemColors.ActiveCaptionText;
      this.btn_scan.Location = new Point(21, 17);
      this.btn_scan.Name = "btn_scan";
      this.btn_scan.Size = new Size(75, 30);
      this.btn_scan.TabIndex = 4;
      this.btn_scan.Text = "Scan";
      this.btn_scan.UseVisualStyleBackColor = true;
      this.btn_scan.Click += new EventHandler(this.btn_scan_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(787, 715);
      this.Controls.Add((Control) this.pnl_capture);
      this.Controls.Add((Control) this.splitter1);
      this.ForeColor = SystemColors.ControlLightLight;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Home";
      this.Load += new EventHandler(this.Form1_Load);
      this.SizeChanged += new EventHandler(this.Home_SizeChanged);
      this.pnl_capture.ResumeLayout(false);
      ((ISupportInitialize) this.pic_scan).EndInit();
      this.ResumeLayout(false);
    }
  }
}
