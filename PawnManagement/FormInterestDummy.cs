
using ExportToExcel11;
using Glass;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormInterestDummy : Form
  {
    private string oldValues;
    private string newValues;
    private DataTable dtrefreshGrid = new DataTable();
    private IContainer components = (IContainer) null;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ComboBox cbType;
    private TextBox tbxFromAmount;
    private TextBox tbxToAmount;
    private TextBox tbxInterest;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox tbxChit;
    private DataGridView dataGridView1;
    private GlassButton btnAddEdit;
    private Label label6;
    private TextBox textBox1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem1;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label label5;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormInterestDummy() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Interest_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatButtonBlue(ref this.btnAddEdit);
      this.refreshGrid();
      this.dataGridView1.Columns["FromAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView1.Columns["ToAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void refreshGrid()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select * from tblInterestDummy", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form interest.refresGrid", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the articles details  .\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dtrefreshGrid;
      this.dataGridView1.Columns["SerialNumber"].Visible = false;
    }

    public static string getInterestRate(string type, string Amount)
    {
      string strError = "";
      string my_querry = "select * from tblInterestDummy where Type=@Type";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Type", (object) type));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form interestdummy.getInterestrate", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching interest" + strError);
      }
      else
      {
        try
        {
          if (dataTable2 == null || dataTable2.Rows.Count <= 0)
            return "0";
          for (int index = 0; index < dataTable2.Rows.Count; ++index)
          {
            if (double.Parse(dataTable2.Rows[index]["FromAmount"].ToString()) < double.Parse(Amount) && double.Parse(dataTable2.Rows[index]["ToAmount"].ToString()) >= double.Parse(Amount))
              return dataTable2.Rows[index]["Interest"].ToString();
          }
        }
        catch (Exception ex)
        {
          PawnManagementClass.InsertIntoException("form pledge.getInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
          throw;
        }
      }
      return "0";
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        PawnManagementClass.InsertIntoHistory("INTEREST DELETE", "Interest entry deleted", "Values are Type =" + this.dataGridView1.Rows[rowIndex].Cells["Type"].Value.ToString() + ",\n FromAmount=" + this.dataGridView1.Rows[rowIndex].Cells["FromAmount"].Value.ToString() + ",\n ToAmount=" + this.dataGridView1.Rows[rowIndex].Cells["ToAmount"].Value.ToString() + ",\n Interest=" + this.dataGridView1.Rows[rowIndex].Cells["Interest"].Value.ToString() + ",\n Chit=" + this.dataGridView1.Rows[rowIndex].Cells["Chit"].Value.ToString(), "", FormMain.username, DateTime.Now.ToString());
        if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
        {
          string strError = "";
          if (SQLHelper.RunCommand("Delete from tblInterestDummy where SerialNumber =@ID", new List<OleDbParameter>()
          {
            new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["SerialNumber"].Value.ToString())
          }, ref strError) != "Done")
          {
            PawnManagementClass.InsertIntoException("form interest.deelteToolStripMenuItem_Click", strError, FormMain.username, DateTime.Now.ToString());
            int num = (int) MessageBox.Show("Error in deleting" + strError);
          }
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form interest.deleteToolStripMenuItem_Click outer exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
      }
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (rowIndex >= 0)
        {
          this.cbType.Text = this.dataGridView1.Rows[rowIndex].Cells["Type"].Value.ToString();
          this.tbxFromAmount.Text = this.dataGridView1.Rows[rowIndex].Cells["FromAmount"].Value.ToString();
          this.tbxToAmount.Text = this.dataGridView1.Rows[rowIndex].Cells["ToAmount"].Value.ToString();
          this.tbxInterest.Text = this.dataGridView1.Rows[rowIndex].Cells["Interest"].Value.ToString();
          this.tbxChit.Text = this.dataGridView1.Rows[rowIndex].Cells["Chit"].Value.ToString();
          this.textBox1.Text = this.dataGridView1.Rows[rowIndex].Cells["symboltodisplay"].Value.ToString();
          this.oldValues = "Old Values are Type =" + this.cbType.Text.Trim().ToString() + ",\n FromAmount=" + this.tbxFromAmount.Text.Trim().ToString() + ",\n ToAmount=" + this.tbxToAmount.Text.Trim().ToString() + ",\n Interest=" + this.tbxInterest.Text.Trim().ToString() + ",\n Chit=" + this.tbxChit.Text.Trim().ToString() + ",\n SymbolToDisplay = " + this.textBox1.Text.Trim().ToString();
          ((Control) this.btnAddEdit).Text = "UPDATE";
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form interest.editToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        DateTime now;
        if (((Control) this.btnAddEdit).Text == "UPDATE")
        {
          this.newValues = "New Values are Type =" + this.cbType.Text.Trim().ToString() + ",\n FromAmount=" + this.tbxFromAmount.Text.Trim().ToString() + ",\n ToAmount=" + this.tbxToAmount.Text.Trim().ToString() + ",\n Interest=" + this.tbxInterest.Text.Trim().ToString() + ",\n Chit=" + this.tbxChit.Text.Trim().ToString() + ",\n SymbolToDisplay = " + this.textBox1.Text.Trim().ToString();
          string oldValues = this.oldValues;
          string newValues = this.newValues;
          string username = FormMain.username;
          now = DateTime.Now;
          string PerformedOn = now.ToString();
          PawnManagementClass.InsertIntoHistory("INTEREST EDIT", "InTerest entry edited", oldValues, newValues, username, PerformedOn);
          this.editInterest();
          if (this.cbType.Items.Count > 0)
            this.cbType.SelectedIndex = 0;
          this.tbxFromAmount.Text = "";
          this.tbxToAmount.Text = "";
          this.tbxInterest.Text = "";
          this.tbxChit.Text = "";
        }
        if (((Control) this.btnAddEdit).Text == "ADD")
        {
          string Newvalues = "Type =" + this.cbType.Text.Trim().ToString() + ",\n FromAmount=" + this.tbxFromAmount.Text.Trim().ToString() + ",\n ToAmount=" + this.tbxToAmount.Text.Trim().ToString() + ",\n Interest=" + this.tbxInterest.Text.Trim().ToString() + ",\n Chit=" + this.tbxChit.Text.Trim().ToString() + ",\n SymbolToDisplay = " + this.textBox1.Text.Trim().ToString();
          string username = FormMain.username;
          now = DateTime.Now;
          string PerformedOn = now.ToString();
          PawnManagementClass.InsertIntoHistory("INTEREST ADD", "New interest entry added", "", Newvalues, username, PerformedOn);
          this.addInterest();
          if (this.cbType.Items.Count > 0)
            this.cbType.SelectedIndex = 0;
          this.tbxFromAmount.Text = "";
          this.tbxToAmount.Text = "";
          this.tbxInterest.Text = "";
          this.tbxChit.Text = "";
          this.refreshGrid();
        }
        ((Control) this.btnAddEdit).Text = "ADD";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form interest.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void editInterest()
    {
      try
      {
        if (this.dataGridView1.Rows == null || this.dataGridView1.Rows.Count <= 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        string strError = "";
        if (SQLHelper.RunCommand("Update tblInterestDummy set Type=@Type,FromAmount=@FromAmount,ToAmount=@ToAmount,Chit =@Chit,Interest=@Interest,SymbolToDisplay=@SymbolToDisplay where SerialNumber =@SerialNumber", new List<OleDbParameter>()
        {
          new OleDbParameter("Type", (object) this.cbType.Text.ToString()),
          new OleDbParameter("FromAmount", (object) this.tbxFromAmount.Text.ToString()),
          new OleDbParameter("ToAmount", (object) this.tbxToAmount.Text.ToString()),
          new OleDbParameter("Chit", (object) this.tbxChit.Text.ToString()),
          new OleDbParameter("Interest", (object) this.tbxInterest.Text.ToString()),
          new OleDbParameter("SymbolToDisplay", (object) this.textBox1.Text.Trim().ToString()),
          new OleDbParameter("SerialNumber", (object) int.Parse(this.dataGridView1.Rows[rowIndex].Cells["SerialNumber"].Value.ToString()))
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("FormInterest.editInterest", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in editing" + strError);
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form interest.editInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void addInterest()
    {
      try
      {
        string strError = "";
        if (!(SQLHelper.RunCommand("insert into tblInterestDummy(Type,FromAmount,ToAmount,Chit,Interest,SymbolToDisplay) values(@Type,@FromAmount,@ToAmount,@Chit,@Interest,@SymbolToDisplay)", new List<OleDbParameter>()
        {
          new OleDbParameter("Type", (object) this.cbType.Text.ToString()),
          new OleDbParameter("FromAmount", (object) this.tbxFromAmount.Text.ToString()),
          new OleDbParameter("ToAmount", (object) this.tbxToAmount.Text.ToString()),
          new OleDbParameter("Chit", (object) this.tbxChit.Text.ToString()),
          new OleDbParameter("Interest", (object) this.tbxInterest.Text.ToString()),
          new OleDbParameter("SymbolToDisplay", (object) this.textBox1.Text.Trim().ToString())
        }, ref strError) != "Done"))
          return;
        PawnManagementClass.InsertIntoException("form Interest.addInterest", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding" + strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form interest.addInterest", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxFromAmount_KeyPress_1(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void tbxFromAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void exportToExcelToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      Rectangle cellBounds = e.CellBounds;
      using (Pen pen = new Pen(Color.Firebrick, 0.5f))
      {
        pen.Alignment = PenAlignment.Center;
        pen.DashStyle = DashStyle.Solid;
        if (e.Row == (sender as TableLayoutPanel).RowCount - 1)
          --cellBounds.Height;
        if (e.Column == (sender as TableLayoutPanel).ColumnCount - 1)
          --cellBounds.Width;
        e.Graphics.DrawRectangle(pen, cellBounds);
      }
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      Rectangle cellBounds = e.CellBounds;
      using (Pen pen = new Pen(Color.Blue, 0.1f))
      {
        pen.Alignment = PenAlignment.Center;
        if (e.Row == (sender as TableLayoutPanel).RowCount - 1)
          --cellBounds.Height;
        if (e.Column == (sender as TableLayoutPanel).ColumnCount - 1)
          --cellBounds.Width;
        e.Graphics.DrawRectangle(pen, cellBounds);
      }
    }

    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
      this.dataGridView1.Columns["FromAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.dataGridView1.Columns["ToAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void exportToExcelOption2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
          CreateExcelFile.CreateExcelDocument((sourceControl as DataGridView).DataSource as DataTable, folderBrowserDialog.SelectedPath + "\\" + (sourceControl as DataGridView).Name + ".xlsx");
      }
    }

    private void label2_Click(object sender, EventArgs e)
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
      this.components = (IContainer) new System.ComponentModel.Container();
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem1 = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.cbType = new ComboBox();
      this.tbxFromAmount = new TextBox();
      this.tbxToAmount = new TextBox();
      this.tbxInterest = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.tbxChit = new TextBox();
      this.btnAddEdit = new GlassButton();
      this.label6 = new Label();
      this.textBox1 = new TextBox();
      this.label5 = new Label();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.BackgroundColor = Color.Ivory;
      this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = Color.PeachPuff;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = Color.DarkBlue;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.ColumnHeadersHeight = 40;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.GridColor = Color.Chocolate;
      this.dataGridView1.Location = new Point(10, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.Ivory;
      this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Teal;
      this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
      this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(690, 285);
      this.dataGridView1.TabIndex = 13;
      this.dataGridView1.Paint += new PaintEventHandler(this.dataGridView1_Paint);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.deleteToolStripMenuItem,
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem1,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new Size(194, 22);
      this.deleteToolStripMenuItem.Text = "DELETE";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem1.Name = "exportToExcelToolStripMenuItem1";
      this.exportToExcelToolStripMenuItem1.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem1.Text = "Export to excel";
      this.exportToExcelToolStripMenuItem1.Click += new EventHandler(this.exportToExcelToolStripMenuItem1_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.cbType.BackColor = Color.Cornsilk;
      this.cbType.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[3]
      {
        (object) "GOLD",
        (object) "SILVER",
        (object) "OTHERS"
      });
      this.cbType.Location = new Point(224, 313);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(227, 31);
      this.cbType.TabIndex = 0;
      this.tbxFromAmount.BackColor = Color.Cornsilk;
      this.tbxFromAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxFromAmount.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxFromAmount.Location = new Point(224, 354);
      this.tbxFromAmount.Name = "tbxFromAmount";
      this.tbxFromAmount.Size = new Size(227, 31);
      this.tbxFromAmount.TabIndex = 1;
      this.tbxFromAmount.KeyPress += new KeyPressEventHandler(this.tbxFromAmount_KeyPress_1);
      this.tbxToAmount.BackColor = Color.Cornsilk;
      this.tbxToAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxToAmount.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxToAmount.Location = new Point(224, 395);
      this.tbxToAmount.Name = "tbxToAmount";
      this.tbxToAmount.Size = new Size(227, 31);
      this.tbxToAmount.TabIndex = 2;
      this.tbxToAmount.KeyPress += new KeyPressEventHandler(this.tbxFromAmount_KeyPress_1);
      this.tbxInterest.BackColor = Color.Cornsilk;
      this.tbxInterest.BorderStyle = BorderStyle.FixedSingle;
      this.tbxInterest.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxInterest.Location = new Point(224, 436);
      this.tbxInterest.Name = "tbxInterest";
      this.tbxInterest.Size = new Size(227, 31);
      this.tbxInterest.TabIndex = 3;
      this.tbxInterest.KeyPress += new KeyPressEventHandler(this.tbxFromAmount_KeyPress_1);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(156, 317);
      this.label1.Name = "label1";
      this.label1.Size = new Size(56, 21);
      this.label1.TabIndex = 7;
      this.label1.Text = "TYPE";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(61, 358);
      this.label2.Name = "label2";
      this.label2.Size = new Size(151, 21);
      this.label2.TabIndex = 8;
      this.label2.Text = "FROM AMOUNT";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(88, 399);
      this.label3.Name = "label3";
      this.label3.Size = new Size(124, 21);
      this.label3.TabIndex = 9;
      this.label3.Text = "TO AMOUNT";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(115, 440);
      this.label4.Name = "label4";
      this.label4.Size = new Size(97, 21);
      this.label4.TabIndex = 10;
      this.label4.Text = "INTEREST";
      this.tbxChit.BackColor = Color.Cornsilk;
      this.tbxChit.BorderStyle = BorderStyle.FixedSingle;
      this.tbxChit.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxChit.Location = new Point(224, 477);
      this.tbxChit.Name = "tbxChit";
      this.tbxChit.Size = new Size(227, 31);
      this.tbxChit.TabIndex = 4;
      this.tbxChit.KeyPress += new KeyPressEventHandler(this.tbxFromAmount_KeyPress_1);
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(224, 555);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(227, 41);
      ((Control) this.btnAddEdit).TabIndex = 6;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(15, 522);
      this.label6.Name = "label6";
      this.label6.Size = new Size(197, 21);
      this.label6.TabIndex = 12;
      this.label6.Text = "SYMBOL TO DISPLAY";
      this.textBox1.BackColor = Color.Cornsilk;
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(224, 518);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(227, 31);
      this.textBox1.TabIndex = 5;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Rockwell", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(158, 481);
      this.label5.Name = "label5";
      this.label5.Size = new Size(54, 21);
      this.label5.TabIndex = 11;
      this.label5.Text = "CHIT";
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "export to excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Cornsilk;
      this.ClientSize = new Size(721, 599);
      this.Controls.Add((Control) this.btnAddEdit);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.tbxChit);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.tbxInterest);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.tbxToAmount);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.tbxFromAmount);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.cbType);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.dataGridView1);
      this.ForeColor = SystemColors.HotTrack;
      this.MaximizeBox = false;
      this.Name = nameof (FormInterestDummy);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Interest";
      this.Load += new EventHandler(this.Interest_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
