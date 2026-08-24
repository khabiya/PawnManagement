

using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Testing
{
  public class FormUpdateDtabase : Form
  {
    private List<string> columns = new List<string>();
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private Panel panel4;
    private ListBox listBox1;
    private Panel panel3;
    private Panel panel2;
    private Label label1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem updateToolStripMenuItem;
    private ListBox listBox3;
    private ListBox listBox5;
    private ListBox listBox4;
    private GlassButton btnUpdateAll;
    private ListBox listBox2;
    private TableLayoutPanel tableLayoutPanel1;
    private GlassButton btnCreateTables;
    private GlassButton btnDropColumnOne;

    public FormUpdateDtabase() => this.InitializeComponent();

    private void Form2_Load(object sender, EventArgs e)
    {
      ((Control) this.btnCreateTables).Focus();
      DataTable dataTable1 = new DataTable();
      DataTable tableNamesUpdate = this.getTableNamesUpdate();
      if (tableNamesUpdate != null && tableNamesUpdate.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) tableNamesUpdate.Rows)
        {
          if (row["TABLE_NAME"].ToString().Contains("TBL") | row["TABLE_NAME"].ToString().Contains("tbl"))
            this.listBox1.Items.Add((object) row["TABLE_NAME"].ToString());
        }
      }
      DataTable dataTable2 = new DataTable();
      DataTable tableNameS = PawnManagementClass.getTableNameS();
      if (tableNameS == null || tableNameS.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) tableNameS.Rows)
      {
        if (row["TABLE_NAME"].ToString().Contains("TBL") | row["TABLE_NAME"].ToString().Contains("tbl"))
          this.listBox2.Items.Add((object) row["TABLE_NAME"].ToString());
      }
    }

    private DataTable getTableNamesUpdate()
    {
      string strError = "";
      return SQLHelper.getTableNamesUpdate(ref strError);
    }

    private void refreshGrid(string strTableName)
    {
      string strError = "";
      Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
      Dictionary<string, string> dictionary2 = this.getDictionary(this.getTable(strTableName));
      string my_querry = "select * from " + strTableName;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form add customer.checkIfcustomerAlreadyAdded" + strError);
      }
      else
      {
        this.columns.Clear();
        foreach (DataColumn column in (InternalDataCollectionBase) dataTable2.Columns)
          this.columns.Add(column.ColumnName);
        foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
        {
          if (!this.check(this.columns.ToArray(), keyValuePair.Key.ToString()))
          {
            this.listBox4.Items.Add((object) (keyValuePair.Key.ToString() + "  " + keyValuePair.Value.ToString() + "  ADDDDDING"));
            if (keyValuePair.Key.ToString() == "ColumnOrder")
              this.addColumn(strTableName, keyValuePair.Key.ToString(), "Memo");
            else if (keyValuePair.Key.ToString() == "FingerPrint")
              this.addColumn(strTableName, keyValuePair.Key.ToString(), "Memo");
            else
              this.addColumn(strTableName, keyValuePair.Key.ToString(), this.getDataType(keyValuePair.Value.ToString()));
          }
          else
            this.listBox3.Items.Add((object) (keyValuePair.Key.ToString() + "  ALREADY EXISTS"));
        }
      }
    }

    private void AlterTable(DataTable dt1)
    {
      DataTable dataTable = new DataTable();
      foreach (DataRow row in (InternalDataCollectionBase) dt1.Rows)
      {
        if (this.getDatatypeof(row["TableName"].ToString(), row["ColumnName"].ToString()) == row["PreviousDataType"].ToString())
        {
          string strError = "";
          if (SQLHelper.RunCommand("alter table " + row["TableName"].ToString() + "   alter column " + row["ColumnName"] + " " + row["NewDataType"].ToString(), ref strError) == "Done")
            this.listBox5.Items.Add((object) (row["TableName"].ToString() + row["ColumnName"] + " " + row["NewDataType"].ToString() + " ALTERED"));
          else
            this.listBox5.Items.Add((object) (row["TableName"].ToString() + row["ColumnName"] + " " + row["NewDataType"].ToString() + "NOT ALTERED"));
        }
      }
    }

    private string getDataType(string str)
    {
      switch (str)
      {
        case "System.Int32":
          return "Integer";
        case "System.DateTime":
          return "DateTime";
        case "System.Double":
          return "Double";
        case "System.String":
          return "Text(255)";
        default:
          return "";
      }
    }

    private bool check(string[] strArray, string str)
    {
      foreach (string str1 in strArray)
      {
        if (string.Equals(str1, str, StringComparison.OrdinalIgnoreCase))
          return true;
      }
      return false;
    }

    private Dictionary<string, string> getDictionary(DataTable dt)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns)
        dictionary.Add(column.ColumnName, column.DataType.ToString());
      return dictionary;
    }

    private string getDatatypeof(string TableName, string columnName)
    {
      string strError = "";
      string my_querry = "select * from " + TableName;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      return dataTable2 != null ? this.getDataType(dataTable2.Columns[columnName].DataType.ToString()) : "";
    }

    private DataTable getTable(string strTableName)
    {
      string strError = "";
      return SQLHelper.GetDataTableForUpdate("select * from " + strTableName, ref strError);
    }

    private void addColumn(string TableName, string ColumnName, string Datatype)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("alter table " + TableName + "   add column " + ColumnName + " " + Datatype, ref strError) != "Done"))
        return;
      this.listBox5.Items.Add((object) (TableName + " " + ColumnName + " " + Datatype + " not added"));
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.listBox3.Items.Clear();
      this.listBox4.Items.Clear();
      this.refreshGrid(this.listBox1.SelectedItem.ToString());
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void btnUpdateAll_Click(object sender, EventArgs e)
    {
      foreach (string strTableName in this.listBox1.Items)
      {
        if (this.listBox2.Items.Contains((object) strTableName))
        {
          this.listBox3.Items.Add((object) strTableName);
          this.listBox4.Items.Add((object) strTableName);
          this.refreshGrid(strTableName);
        }
      }
      this.AlterTable(new DataTable()
      {
        Columns = {
          "TableName",
          "ColumnName",
          "PreviousDataType",
          "NewDataType"
        },
        Rows = {
          new object[4]
          {
            (object) "tblRedemption",
            (object) "NoticeCharge",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "OtherCharge",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "Deductions",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "NoOfMonths",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "NoOfMonths16",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "Interest16",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblRedemption",
            (object) "RedemptionAmount16",
            (object) "Text(255)",
            (object) "Number"
          },
          new object[4]
          {
            (object) "tblPledge",
            (object) "PledgeCreatedOn",
            (object) "Text(255)",
            (object) "DateTime"
          }
        }
      });
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      foreach (string strTableName in this.listBox1.Items)
      {
        if (!this.listBox2.Items.Contains((object) strTableName))
          this.createTable(strTableName);
      }
    }

    private void createTable(string strTableName)
    {
      string strError = "";
      SQLHelper.RunCommand("create table " + strTableName + "(ID AutoIncrement)", ref strError);
    }

    private void dropColumn(string TableName, string ColumnName, string Datatype)
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("alter table " + TableName + "   drop column " + ColumnName + " text", ref strError) == "Done"))
        return;
      this.listBox5.Items.Add((object) (TableName + " " + ColumnName + " " + Datatype + "  Removed"));
    }

    private void btnDropColumnOne_Click(object sender, EventArgs e)
    {
      foreach (string str in this.listBox2.Items)
      {
        if (this.checkIfTableContainsAField(str, "columnone"))
          this.dropColumn(str, "columnone", "Text");
      }
    }

    private bool checkIfTableContainsAField(string tableName, string columnName)
    {
      string strError = "";
      string my_querry = "select * from " + tableName;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form add customer.checkIfCustomerAlreadyAdded", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in form add customer.checkIfcustomerAlreadyAdded" + strError);
      }
      else if (dataTable2 != null)
      {
        foreach (DataColumn column in (InternalDataCollectionBase) dataTable2.Columns)
        {
          if (column.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
            return true;
        }
        return false;
      }
      return false;
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
      this.panel1 = new Panel();
      this.panel3 = new Panel();
      this.btnDropColumnOne = new GlassButton();
      this.btnCreateTables = new GlassButton();
      this.btnUpdateAll = new GlassButton();
      this.panel4 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.listBox1 = new ListBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.updateToolStripMenuItem = new ToolStripMenuItem();
      this.listBox5 = new ListBox();
      this.listBox2 = new ListBox();
      this.listBox4 = new ListBox();
      this.listBox3 = new ListBox();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.panel3);
      this.panel1.Controls.Add((Control) this.panel4);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1008, 632);
      this.panel1.TabIndex = 1;
      this.panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel3.BackgroundImage = (Image) Resources.lightblueCentergradient;
      this.panel3.Controls.Add((Control) this.btnDropColumnOne);
      this.panel3.Controls.Add((Control) this.btnCreateTables);
      this.panel3.Controls.Add((Control) this.btnUpdateAll);
      this.panel3.Location = new Point(0, 599);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(1008, 32);
      this.panel3.TabIndex = 1;
      this.btnDropColumnOne.BackColor = Color.LightBlue;
      this.btnDropColumnOne.FadeOnFocus = true;
      this.btnDropColumnOne.ForeColor = Color.MediumBlue;
      this.btnDropColumnOne.ForeColorOnFocus = Color.Red;
      this.btnDropColumnOne.ForeColorOnLeave = Color.MediumBlue;
      this.btnDropColumnOne.GlowColor = Color.White;
      this.btnDropColumnOne.InnerBorderColor = Color.Transparent;
      ((Control) this.btnDropColumnOne).Location = new Point(512, 3);
      ((Control) this.btnDropColumnOne).Name = "btnDropColumnOne";
      this.btnDropColumnOne.OuterBorderColor = Color.MediumSlateBlue;
      this.btnDropColumnOne.ShineColor = Color.Transparent;
      ((Control) this.btnDropColumnOne).Size = new Size(151, 23);
      ((Control) this.btnDropColumnOne).TabIndex = 2;
      ((Control) this.btnDropColumnOne).Text = "Drop Column One";
      ((Control) this.btnDropColumnOne).Visible = false;
      ((Control) this.btnDropColumnOne).Click += new EventHandler(this.btnDropColumnOne_Click);
      this.btnCreateTables.BackColor = Color.LightBlue;
      this.btnCreateTables.FadeOnFocus = true;
      this.btnCreateTables.ForeColor = Color.MediumBlue;
      this.btnCreateTables.ForeColorOnFocus = Color.Red;
      this.btnCreateTables.ForeColorOnLeave = Color.MediumBlue;
      this.btnCreateTables.GlowColor = Color.White;
      this.btnCreateTables.InnerBorderColor = Color.Transparent;
      ((Control) this.btnCreateTables).Location = new Point(210, 3);
      ((Control) this.btnCreateTables).Name = "btnCreateTables";
      this.btnCreateTables.OuterBorderColor = Color.MediumSlateBlue;
      this.btnCreateTables.ShineColor = Color.Transparent;
      ((Control) this.btnCreateTables).Size = new Size(151, 23);
      ((Control) this.btnCreateTables).TabIndex = 1;
      ((Control) this.btnCreateTables).Text = "Create Tables";
      ((Control) this.btnCreateTables).Click += new EventHandler(this.glassButton1_Click);
      this.btnUpdateAll.BackColor = Color.LightBlue;
      this.btnUpdateAll.FadeOnFocus = true;
      this.btnUpdateAll.ForeColor = Color.MediumBlue;
      this.btnUpdateAll.ForeColorOnFocus = Color.Red;
      this.btnUpdateAll.ForeColorOnLeave = Color.MediumBlue;
      this.btnUpdateAll.GlowColor = Color.White;
      this.btnUpdateAll.InnerBorderColor = Color.Transparent;
      ((Control) this.btnUpdateAll).Location = new Point(361, 3);
      ((Control) this.btnUpdateAll).Name = "btnUpdateAll";
      this.btnUpdateAll.OuterBorderColor = Color.MediumSlateBlue;
      this.btnUpdateAll.ShineColor = Color.Transparent;
      ((Control) this.btnUpdateAll).Size = new Size(151, 23);
      ((Control) this.btnUpdateAll).TabIndex = 0;
      ((Control) this.btnUpdateAll).Text = "Update All";
      ((Control) this.btnUpdateAll).Click += new EventHandler(this.btnUpdateAll_Click);
      this.panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel4.BackgroundImage = (Image) Resources.background_gradient_blue1;
      this.panel4.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel4.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel4.Location = new Point(1, 42);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(1007, 565);
      this.panel4.TabIndex = 2;
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox5, 4, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox2, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox4, 3, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox3, 2, 0);
      this.tableLayoutPanel1.Location = new Point(7, 5);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(997, 555);
      this.tableLayoutPanel1.TabIndex = 10;
      this.listBox1.BackColor = Color.MintCream;
      this.listBox1.BorderStyle = BorderStyle.None;
      this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(3, 3);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(193, 549);
      this.listBox1.TabIndex = 2;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.updateToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(112, 26);
      this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
      this.updateToolStripMenuItem.Size = new Size(111, 22);
      this.updateToolStripMenuItem.Text = "update";
      this.updateToolStripMenuItem.Click += new EventHandler(this.updateToolStripMenuItem_Click);
      this.listBox5.BackColor = Color.MintCream;
      this.listBox5.BorderStyle = BorderStyle.None;
      this.listBox5.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox5.Dock = DockStyle.Fill;
      this.listBox5.FormattingEnabled = true;
      this.listBox5.Location = new Point(799, 3);
      this.listBox5.Name = "listBox5";
      this.listBox5.Size = new Size(195, 549);
      this.listBox5.TabIndex = 8;
      this.listBox2.BackColor = Color.MintCream;
      this.listBox2.BorderStyle = BorderStyle.None;
      this.listBox2.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox2.Dock = DockStyle.Fill;
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new Point(202, 3);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new Size(193, 549);
      this.listBox2.TabIndex = 9;
      this.listBox4.BackColor = Color.MintCream;
      this.listBox4.BorderStyle = BorderStyle.None;
      this.listBox4.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox4.Dock = DockStyle.Fill;
      this.listBox4.FormattingEnabled = true;
      this.listBox4.Location = new Point(600, 3);
      this.listBox4.Name = "listBox4";
      this.listBox4.Size = new Size(193, 549);
      this.listBox4.TabIndex = 7;
      this.listBox3.BackColor = Color.MintCream;
      this.listBox3.BorderStyle = BorderStyle.None;
      this.listBox3.ContextMenuStrip = this.contextMenuStrip1;
      this.listBox3.Dock = DockStyle.Fill;
      this.listBox3.FormattingEnabled = true;
      this.listBox3.Location = new Point(401, 3);
      this.listBox3.Name = "listBox3";
      this.listBox3.Size = new Size(193, 549);
      this.listBox3.TabIndex = 6;
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1008, 41);
      this.panel2.TabIndex = 0;
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.HotTrack;
      this.label1.Location = new Point(403, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(215, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "DATABASE UPDATE";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormUpdateDtabase);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Form2";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.Form2_Load);
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
