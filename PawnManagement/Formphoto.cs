

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class Formphoto : Form
  {
    private string photoPath;
    private IContainer components = (IContainer) null;
    private PictureBox pictureBox1;

    public Formphoto(string PhotoPath)
    {
      this.photoPath = PhotoPath;
      this.InitializeComponent();
    }

    private void photo_Load(object sender, EventArgs e) => this.getPicture(this.photoPath);

    private void getPicture(string photoPath)
    {
      try
      {
        if (File.Exists(photoPath))
        {
          using (FileStream fileStream = new FileStream(photoPath, FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else if (File.Exists(FormMain.startUpPath + "Photos\\noPhoto.png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\noPhoto.png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form photo.getPicture.getPicture(string photoPath", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
      }
    }

    private void photo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      this.Close();
    }

    private void pictureBox1_MouseLeave(object sender, EventArgs e) => this.Close();

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
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
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Dock = DockStyle.Fill;
      this.pictureBox1.Location = new Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(853, 628);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseLeave += new EventHandler(this.pictureBox1_MouseLeave);
      this.pictureBox1.MouseUp += new MouseEventHandler(this.pictureBox1_MouseUp);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(853, 628);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Formphoto);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "photo";
      this.Load += new EventHandler(this.photo_Load);
      this.KeyDown += new KeyEventHandler(this.photo_KeyDown);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
