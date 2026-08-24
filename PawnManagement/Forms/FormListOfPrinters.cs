
using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormListOfPrinters : Form
  {
    private IContainer components = (IContainer) null;
    private ListBox listBox1;
    private ListBox listBox2;

    public FormListOfPrinters() => this.InitializeComponent();

    private void FormListOfPrinters_Load(object sender, EventArgs e)
    {
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * from Win32_Printer").Get())
      {
        object propertyValue1 = managementBaseObject.GetPropertyValue("Name");
        object propertyValue2 = managementBaseObject.GetPropertyValue("Status");
        object propertyValue3 = managementBaseObject.GetPropertyValue("Default");
        object propertyValue4 = managementBaseObject.GetPropertyValue("Network");
        this.listBox1.Items.Add((object) (propertyValue1.ToString() + propertyValue2 + propertyValue3 + propertyValue4));
        this.listBox2.Items.Add((object) propertyValue1.ToString());
        Console.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}", new object[4]
        {
          propertyValue1,
          propertyValue2,
          propertyValue3,
          propertyValue4
        });
      }
    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
    }

    private void listBox2_SelectedIndexChanged(object sender, EventArgs e) => myPrinters.SetDefaultPrinter(this.listBox2.SelectedItem.ToString());

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.listBox1 = new ListBox();
      this.listBox2 = new ListBox();
      this.SuspendLayout();
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(71, 57);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(591, 329);
      this.listBox1.TabIndex = 0;
      this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new Point(668, 57);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new Size(261, 329);
      this.listBox2.TabIndex = 1;
      this.listBox2.SelectedIndexChanged += new EventHandler(this.listBox2_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(944, 450);
      this.Controls.Add((Control) this.listBox2);
      this.Controls.Add((Control) this.listBox1);
      this.Name = nameof (FormListOfPrinters);
      this.Text = nameof (FormListOfPrinters);
      this.Load += new EventHandler(this.FormListOfPrinters_Load);
      this.ResumeLayout(false);
    }
  }
}
