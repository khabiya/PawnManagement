
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ConnectionstringatRuntime
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private TextBox txtServer;
    private TextBox txtDatabase;
    private Label label2;
    private Button button1;
    private Button button2;

    public Form1() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        this.updateConfigFile(this.txtDatabase.Text);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ConfigurationManager.ConnectionStrings["con"].ToString() + ".This is invalid connection", "Incorrect server/Database");
      }
    }

    public void updateConfigFile(string con)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
      foreach (XmlElement xmlElement in (XmlNode) xmlDocument.DocumentElement)
      {
        if (xmlElement.Name == "connectionStrings")
        {
          xmlElement.FirstChild.Attributes[1].Value = con;
          int num = (int) MessageBox.Show("successfully updated" + xmlElement.FirstChild.Attributes[1].Value.ToString());
        }
      }
      xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
      foreach (XmlElement xmlElement in (XmlNode) xmlDocument.DocumentElement)
      {
        if (xmlElement.Name == "connectionStrings")
          this.txtServer.Text = xmlElement.FirstChild.Attributes[1].Value.ToString();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      if (folderBrowserDialog.SelectedPath.Count<char>() == 3)
        this.txtDatabase.Text = folderBrowserDialog.SelectedPath;
      else
        this.txtDatabase.Text = folderBrowserDialog.SelectedPath.ToString() + "\\";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.txtServer = new TextBox();
      this.txtDatabase = new TextBox();
      this.label2 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(-1, 34);
      this.label1.Name = "label1";
      this.label1.Size = new Size(115, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Present server location";
      this.txtServer.Location = new Point(117, 31);
      this.txtServer.Name = "txtServer";
      this.txtServer.Size = new Size(877, 20);
      this.txtServer.TabIndex = 1;
      this.txtDatabase.Location = new Point(117, 57);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new Size(796, 20);
      this.txtDatabase.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(0, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(88, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Enter server path";
      this.button1.Location = new Point(117, 83);
      this.button1.Name = "button1";
      this.button1.Size = new Size(131, 28);
      this.button1.TabIndex = 4;
      this.button1.Text = "Update";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(919, 54);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 6;
      this.button2.Text = "Browse";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1006, 123);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.txtDatabase);
      this.Controls.Add((Control) this.txtServer);
      this.Controls.Add((Control) this.label1);
      this.Name = nameof (Form1);
      this.Text = "Change Working Directory";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
