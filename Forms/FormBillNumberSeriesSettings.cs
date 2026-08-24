

using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormBillNumberSeriesSettings : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private ComboBox cbType;
    private Label label3;

    public FormBillNumberSeriesSettings() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormBillNumberSeriesSettings_Load(object sender, EventArgs e) => this.getBillNumberSEriesSEttings();

    private void getBillNumberSEriesSEttings()
    {
      string strError = "";
      string my_querry = "select * from tblsettings";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("form billnumberseriessettings.getbillnumberseriessettings  " + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
      {
        if (dataTable2.Rows[0]["BillNumberSeries"] != null)
        {
          if (dataTable2.Rows[0]["BillNumberSeries"].ToString() != "")
            this.cbType.Text = dataTable2.Rows[0]["BillNumberSeries"].ToString();
          else
            this.cbType.Text = "SINGLE";
        }
        else
          this.cbType.Text = "SINGLE";
      }
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e) => this.setbILLnUMBERseRIES();

    private void setbILLnUMBERseRIES()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("update  tblSettings set BillNumberSeries= @BillNumberSeries", new List<OleDbParameter>()
      {
        new OleDbParameter("BillNumberSeries", (object) this.cbType.Text)
      }, ref strError) != "Done"))
        ;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.cbType = new ComboBox();
      this.label3 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.4898f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75.5102f));
      this.tableLayoutPanel1.Size = new Size(672, 196);
      this.tableLayoutPanel1.TabIndex = 12;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(666, 42);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(135, 6);
      this.label7.Name = "label7";
      this.label7.Size = new Size(392, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "BILL NUMBER SERIES SETTINGS";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.cbType);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 51);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(666, 142);
      this.panel3.TabIndex = 11;
      this.cbType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[2]
      {
        (object) "SINGLE",
        (object) "DOUBLE"
      });
      this.cbType.Location = new Point(206, 55);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(236, 33);
      this.cbType.TabIndex = 2;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(209, 27);
      this.label3.Name = "label3";
      this.label3.Size = new Size(233, 25);
      this.label3.TabIndex = 9;
      this.label3.Text = "SINGLE OR DOUBLE";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(672, 196);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Name = nameof (FormBillNumberSeriesSettings);
      this.Text = nameof (FormBillNumberSeriesSettings);
      this.Load += new EventHandler(this.FormBillNumberSeriesSettings_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
