

using CSharpCustomPanelControl;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormErrorFinder : Form
  {
    public static string BillNumberSeries = "";
    private IContainer components = (IContainer) null;
    private ListBox listBox1;
    private CustomPanel customPanel1;
    private DataGridView dataGridView1;
    private ListBox listBox2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem scanToolStripMenuItem;

    public FormErrorFinder() => this.InitializeComponent();

    private void FormErrorFinder_Load(object sender, EventArgs e)
    {
      FormErrorFinder.BillNumberSeries = PawnManagementClass.getBillNumberSEriesSEttings();
      DataTable tableNameS = PawnManagementClass.getTableNameS();
      if (tableNameS == null || tableNameS.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) tableNameS.Rows)
      {
        if (row["TABLE_NAME"].ToString().Contains("TBL") | row["TABLE_NAME"].ToString().Contains("tbl"))
          this.listBox1.Items.Add((object) row["TABLE_NAME"].ToString());
      }
    }

    private void listBox1_Click(object sender, EventArgs e)
    {
      if (this.listBox1.Items.Count <= 0 || this.listBox1.SelectedIndex < 0)
        return;
      this.dataGridView1.DataSource = (object) PawnManagementClass.getDataTable(this.listBox1.SelectedItem.ToString());
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void scanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.listBox1.Items.Count <= 0 || this.listBox1.SelectedIndex < 0)
        return;
      string str = this.listBox1.SelectedItem.ToString();
      this.processTable(PawnManagementClass.getDataTable(str), str);
    }

    private void processTableNew(DataTable dt, string TableName)
    {
      foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns)
        this.getNullValues(TableName, column.ColumnName);
    }

    public DataTable getNullValues(string TableName, string ColumnName) => SQLHelper.GetDataTable("SELECT * FROM " + TableName + " WHERE " + ColumnName + " = '' OR " + ColumnName + " IS NULL");

    private void processTable(DataTable dt, string TableName)
    {
      if (!TableName.Equals("tblcustomers", StringComparison.OrdinalIgnoreCase))
        return;
      string str1 = "";
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        if (row["CID"] == null)
          str1 += row["ID"].ToString();
      }
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = "";
      string str8 = "";
      string str9 = "";
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        string str10 = row["CID"].ToString();
        string str11 = row["CID"].ToString().Substring(1);
        string str12 = row["CName"].ToString();
        string str13 = row["CAddr1"].ToString();
        string str14 = row["CAddr3"].ToString();
        string str15 = row["ccity"].ToString();
        string str16 = row["cpincode"].ToString();
        if (!char.IsLetter(str10[0]))
          str2 = str2 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (!char.IsUpper(str10[0]))
          str3 = str3 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (!PawnManagementClass.IsDigitsOnly(str11))
          str4 = str4 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (str12.Trim() == "")
          str5 = str5 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (str13.Trim() == "")
          str6 = str6 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (str14.Trim() == "")
          str7 = str7 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (str15.Trim() == "")
          str8 = str8 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
        if (str16.Trim() == "")
          str9 = str9 + "  (" + row["ID"].ToString() + " - " + row["CID"].ToString() + ")" + Environment.NewLine;
      }
      File.AppendAllText("ErrorsScan.txt", "cid with small letters or numbers starting" + Environment.NewLine + str3 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "cid without letter" + Environment.NewLine + str2 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "cid with alphates in second place" + Environment.NewLine + str4 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "Customers with Empty names" + Environment.NewLine + str5 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "Customers with Empty Addr1" + Environment.NewLine + str6 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "Customers with Empty Addr3(Location)" + Environment.NewLine + str7 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "Customers with Empty City" + Environment.NewLine + str8 + Environment.NewLine);
      File.AppendAllText("ErrorsScan.txt", "Customers with Empty Pincode" + Environment.NewLine + str9 + Environment.NewLine);
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
      this.listBox1 = new ListBox();
      this.customPanel1 = new CustomPanel();
      this.listBox2 = new ListBox();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.scanToolStripMenuItem = new ToolStripMenuItem();
      ((Control) this.customPanel1).SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.listBox1.BackColor = SystemColors.Info;
      this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(3, 3);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(167, 615);
      this.listBox1.TabIndex = 3;
      this.listBox1.Click += new EventHandler(this.listBox1_Click);
      this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.customPanel1.BackColor = SystemColors.Info;
      this.customPanel1.BackColor2 = SystemColors.Info;
      this.customPanel1.BorderColor = Color.Sienna;
      this.customPanel1.BorderStyle = BorderStyle.FixedSingle;
      ((Control) this.customPanel1).Controls.Add((Control) this.listBox2);
      ((Control) this.customPanel1).Controls.Add((Control) this.dataGridView1);
      ((Control) this.customPanel1).Controls.Add((Control) this.listBox1);
      this.customPanel1.Curvature = 1;
      ((Control) this.customPanel1).Dock = DockStyle.Fill;
      this.customPanel1.GradientMode = LinearGradientMode.ForwardDiagonal;
      ((Control) this.customPanel1).Location = new Point(0, 0);
      ((Control) this.customPanel1).Name = "customPanel1";
      ((Control) this.customPanel1).Size = new Size(1008, 622);
      ((Control) this.customPanel1).TabIndex = 4;
      this.listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.listBox2.BackColor = SystemColors.Info;
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new Point(837, 4);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new Size(167, 615);
      this.listBox2.TabIndex = 5;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(171, 3);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(665, 616);
      this.dataGridView1.TabIndex = 4;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.scanToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(153, 48);
      this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
      this.scanToolStripMenuItem.Size = new Size(152, 22);
      this.scanToolStripMenuItem.Text = "Scan";
      this.scanToolStripMenuItem.Click += new EventHandler(this.scanToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.customPanel1);
      this.Name = nameof (FormErrorFinder);
      this.Text = nameof (FormErrorFinder);
      this.Load += new EventHandler(this.FormErrorFinder_Load);
      ((Control) this.customPanel1).ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
