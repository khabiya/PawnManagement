
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class FormCreateXmlSchema : Form
  {
    private IContainer components = (IContainer) null;
    private Button button1;

    public FormCreateXmlSchema() => this.InitializeComponent();

    private void Form10_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      DataTable salesDetailsTable = SalesDetailsClass.getCompleteSalesDetailsTable("BillNumber");
      salesDetailsTable.Columns.Add("HsnCode", typeof (string));
      salesDetailsTable.TableName = "tblSalesDetails";
      salesDetailsTable.WriteXmlSchema("tblSalesDetails.xml");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.SuspendLayout();
      this.button1.Location = new Point(62, 115);
      this.button1.Name = "button1";
      this.button1.Size = new Size(288, 102);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1056, 609);
      this.Controls.Add((Control) this.button1);
      this.Name = "Form10";
      this.Text = "Form10";
      this.Load += new EventHandler(this.Form10_Load);
      this.ResumeLayout(false);
    }
  }
}
