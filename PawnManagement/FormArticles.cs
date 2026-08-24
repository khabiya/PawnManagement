

using ExportToExcel11;
using Glass;
using PawnManagement.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormArticles : Form
  {
    private IContainer components = (IContainer) null;
    private TabControl tcArticles;
    private TabPage tpAddArticles;
    private TabPage tpDeleteArticles;
    private TextBox tbxAddArticles;
    private TextBox tbxDeleteArticles;
    private DataGridView dataGridView2;
    private TabControl tcArticlesDescription;
    private TabPage tpAddArticlesDesription;
    private TextBox tbxAddAritlcesDescription;
    private TabPage tabPage2;
    private TextBox tbxDeleteArticlesDescription;
    private DataGridViewCheckBoxColumn Mark;
    private GlassButton btnAddArticles;
    private GlassButton btnDeleteArticles;
    private GlassButton btnAddArticlesDescription;
    private GlassButton btnDelete;
    private DataGridView dataGridView1;
    private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel4;
    private Panel panel3;
    private Panel panel2;
    private Panel panel1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem1;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem1;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem1;

    public FormArticles() => this.InitializeComponent();

    private void refreshGrid()
    {
      try
      {
        string strError = "";
        string my_querry = "select Article from tblArticles";
        DataTable dataTable = new DataTable();
        this.dataGridView1.DataSource = (object) SQLHelper.GetDataTable(my_querry, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.refreshgrid", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void refreshGrid1()
    {
      try
      {
        string strError = "";
        string my_querry = "select ArticlesDescription from tblArticlesDescription";
        DataTable dataTable = new DataTable();
        this.dataGridView2.DataSource = (object) SQLHelper.GetDataTable(my_querry, ref strError);
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.refreshgrid1", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void Articles_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      this.refreshGrid1();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView2);
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.Columns[0].FillWeight = 10f;
      this.dataGridView2.Columns[0].FillWeight = 10f;
      this.tbxAddArticles.Select();
    }

    private string checkArticle()
    {
      string strError = "";
      string my_querry = "select * from tblArticles where Article = @Article";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("Article", (object) this.tbxAddArticles.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return "no";
      int num = (int) MessageBox.Show("Article already exists");
      return "yes";
    }

    private string checkArticle1()
    {
      string strError = "";
      string my_querry = "select * from tblArticlesDescription where ArticlesDescription = @ArticlesDescription";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("ArticlesDescription", (object) this.tbxAddAritlcesDescription.Text.Trim().ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return "no";
      int num = (int) MessageBox.Show("ArticleDescription already exists");
      return "yes";
    }

    private void insertIntoArticles()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblArticles(Article) values(@article)", new List<OleDbParameter>()
      {
        new OleDbParameter("article", (object) this.tbxAddArticles.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      int num = (int) MessageBox.Show("form articles.insertintoarticles()" + strError);
      PawnManagementClass.InsertIntoException("form articles.inserIntoArticles", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void insertIntoArticles1()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblArticlesDescription(ArticlesDescription) values(@ArticlesDescription)", new List<OleDbParameter>()
      {
        new OleDbParameter("ArticlesDescription", (object) this.tbxAddAritlcesDescription.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      int num = (int) MessageBox.Show("form insertintoarticles1()" + strError);
      PawnManagementClass.InsertIntoException("form articles.inserIntoArticles1", strError, FormMain.username, DateTime.Now.ToString());
    }

    private void btnAddArticles_Click(object sender, EventArgs e)
    {
      if (this.tbxAddArticles.Text.Trim() != "")
      {
        if (this.checkArticle().Equals("no"))
        {
          this.insertIntoArticles();
          this.tbxAddArticles.ResetText();
          this.refreshGrid();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Please type an Article");
      }
      this.tbxAddArticles.Select();
    }

    private void btnAddArticlesDescription_Click(object sender, EventArgs e)
    {
      if (this.tbxAddAritlcesDescription.Text.Trim() != "")
      {
        if (this.checkArticle1().Equals("no"))
        {
          this.insertIntoArticles1();
          this.tbxAddAritlcesDescription.ResetText();
          this.refreshGrid1();
          this.tbxAddAritlcesDescription.Select();
        }
        this.tbxAddAritlcesDescription.Select();
      }
      else
      {
        int num = (int) MessageBox.Show("Please type an ArticleDescription");
      }
      this.tbxAddAritlcesDescription.Select();
    }

    private void tbxDeleteArticles_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select Article from tblArticles where Article like '%" + this.tbxDeleteArticles.Text.Trim().ToString() + "%'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form articles.tbxdeletearticles_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching articles from articles table" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    private void tbxDeleteArticlesDescription_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select ArticlesDescription from tblArticlesDescription where ArticlesDescription like '%" + this.tbxDeleteArticlesDescription.Text.Trim().ToString() + "%'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form articles.tbxdeletearticlesdescription_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching articles description from articles description table" + strError);
      }
      else
        this.dataGridView2.DataSource = (object) dataTable2;
    }

    private void btnDeleteArticles_Click(object sender, EventArgs e)
    {
      try
      {
        if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
        {
          foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
          {
            if (row.Cells[0].Value != null && bool.Parse(row.Cells[0].Value.ToString()))
            {
              string strError = "";
              if (!(SQLHelper.RunCommand("Delete from tblArticles where Article =@Article", new List<OleDbParameter>()
              {
                new OleDbParameter("Article", (object) row.Cells[1].Value.ToString())
              }, ref strError) == "Done"))
              {
                int num = (int) MessageBox.Show("Error in deleting" + strError);
                PawnManagementClass.InsertIntoException("form articles.btndeletearticles_click", strError, FormMain.username, DateTime.Now.ToString());
              }
            }
          }
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.btnDeleteArticles_clicked", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnDeleteArticlesDescription_Click(object sender, EventArgs e)
    {
      try
      {
        if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
        {
          foreach (DataGridViewRow row in (IEnumerable) this.dataGridView2.Rows)
          {
            if (row.Cells[0].Value != null && bool.Parse(row.Cells[0].Value.ToString()))
            {
              string strError = "";
              if (!(SQLHelper.RunCommand("Delete from tblArticlesDescription where ArticlesDescription =@ArticlesDescription", new List<OleDbParameter>()
              {
                new OleDbParameter("ArticlesDescription", (object) row.Cells[1].Value.ToString())
              }, ref strError) == "Done"))
              {
                int num = (int) MessageBox.Show("Error in deleting" + strError);
                PawnManagementClass.InsertIntoException("form articles.btndeletearticlesescription_click", strError, FormMain.username, DateTime.Now.ToString());
              }
            }
          }
        }
        this.refreshGrid1();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form articles.btnDeleteArticlesdescription_clicked", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxAddArticles_KeyUp(object sender, KeyEventArgs e)
    {
      if (!(this.tbxAddArticles.Text != "") || e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddArticles).Focus();
    }

    private void tbxAddAritlcesDescription_KeyUp(object sender, KeyEventArgs e)
    {
      if (!(this.tbxAddAritlcesDescription.Text != "") || e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddArticlesDescription).Focus();
    }

    private void btnAddArticles_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxAddArticles.Select();
    }

    private void FormArticles_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.F3)
        return;
      ((Control) this.btnAddArticles).Focus();
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

    private void wrapToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "ARTICLES").ShowDialog();
    }

    private void viewFullScreenToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "ARTICLES DESCRIPTION").ShowDialog();
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

    private void exportToExcelOption2ToolStripMenuItem1_Click(object sender, EventArgs e)
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormArticles));
      this.tcArticles = new TabControl();
      this.tpAddArticles = new TabPage();
      this.btnAddArticles = new GlassButton();
      this.tbxAddArticles = new TextBox();
      this.tpDeleteArticles = new TabPage();
      this.btnDeleteArticles = new GlassButton();
      this.tbxDeleteArticles = new TextBox();
      this.dataGridView2 = new DataGridView();
      this.Mark = new DataGridViewCheckBoxColumn();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.wrapToolStripMenuItem1 = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem1 = new ToolStripMenuItem();
      this.tcArticlesDescription = new TabControl();
      this.tpAddArticlesDesription = new TabPage();
      this.btnAddArticlesDescription = new GlassButton();
      this.tbxAddAritlcesDescription = new TextBox();
      this.tabPage2 = new TabPage();
      this.btnDelete = new GlassButton();
      this.tbxDeleteArticlesDescription = new TextBox();
      this.dataGridView1 = new DataGridView();
      this.dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel4 = new Panel();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.panel1 = new Panel();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem1 = new ToolStripMenuItem();
      this.tcArticles.SuspendLayout();
      this.tpAddArticles.SuspendLayout();
      this.tpDeleteArticles.SuspendLayout();
      ((ISupportInitialize) this.dataGridView2).BeginInit();
      this.contextMenuStrip2.SuspendLayout();
      this.tcArticlesDescription.SuspendLayout();
      this.tpAddArticlesDesription.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tcArticles.Controls.Add((Control) this.tpAddArticles);
      this.tcArticles.Controls.Add((Control) this.tpDeleteArticles);
      this.tcArticles.Dock = DockStyle.Fill;
      this.tcArticles.Location = new Point(0, 0);
      this.tcArticles.Name = "tcArticles";
      this.tcArticles.SelectedIndex = 0;
      this.tcArticles.Size = new Size(498, 141);
      this.tcArticles.TabIndex = 0;
      this.tpAddArticles.Controls.Add((Control) this.btnAddArticles);
      this.tpAddArticles.Controls.Add((Control) this.tbxAddArticles);
      this.tpAddArticles.Location = new Point(4, 22);
      this.tpAddArticles.Name = "tpAddArticles";
      this.tpAddArticles.Padding = new Padding(3);
      this.tpAddArticles.Size = new Size(490, 115);
      this.tpAddArticles.TabIndex = 0;
      this.tpAddArticles.Text = "ADD ARTICLES";
      this.tpAddArticles.UseVisualStyleBackColor = true;
      this.btnAddArticles.BackColor = Color.White;
      this.btnAddArticles.FadeOnFocus = true;
      this.btnAddArticles.ForeColor = Color.Black;
      this.btnAddArticles.ForeColorOnFocus = Color.Red;
      this.btnAddArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddArticles.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnAddArticles).Image = (Image) componentResourceManager.GetObject("btnAddArticles.Image");
      this.btnAddArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddArticles).Location = new Point(114, 55);
      ((Control) this.btnAddArticles).Name = "btnAddArticles";
      this.btnAddArticles.OuterBorderColor = Color.MistyRose;
      this.btnAddArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticles).Size = new Size(217, 45);
      ((Control) this.btnAddArticles).TabIndex = 2;
      ((Control) this.btnAddArticles).Text = "ADD ARTICLES";
      ((ButtonBase) this.btnAddArticles).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticles).Click += new EventHandler(this.btnAddArticles_Click);
      ((Control) this.btnAddArticles).KeyDown += new KeyEventHandler(this.btnAddArticles_KeyDown);
      this.tbxAddArticles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddArticles.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddArticles.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddArticles.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddArticles.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddArticles.Location = new Point(16, 11);
      this.tbxAddArticles.Name = "tbxAddArticles";
      this.tbxAddArticles.Size = new Size(468, 31);
      this.tbxAddArticles.TabIndex = 0;
      this.tbxAddArticles.KeyUp += new KeyEventHandler(this.tbxAddArticles_KeyUp);
      this.tpDeleteArticles.Controls.Add((Control) this.btnDeleteArticles);
      this.tpDeleteArticles.Controls.Add((Control) this.tbxDeleteArticles);
      this.tpDeleteArticles.Location = new Point(4, 22);
      this.tpDeleteArticles.Name = "tpDeleteArticles";
      this.tpDeleteArticles.Padding = new Padding(3);
      this.tpDeleteArticles.Size = new Size(490, 115);
      this.tpDeleteArticles.TabIndex = 1;
      this.tpDeleteArticles.Text = "DELETE";
      this.tpDeleteArticles.UseVisualStyleBackColor = true;
      this.btnDeleteArticles.BackColor = Color.White;
      this.btnDeleteArticles.FadeOnFocus = true;
      ((Control) this.btnDeleteArticles).Font = new Font("Comic Sans MS", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDeleteArticles.ForeColor = Color.RoyalBlue;
      this.btnDeleteArticles.ForeColorOnFocus = Color.Red;
      this.btnDeleteArticles.ForeColorOnLeave = Color.RoyalBlue;
      this.btnDeleteArticles.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnDeleteArticles).Image = (Image) Resources.deletesymboll;
      this.btnDeleteArticles.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnDeleteArticles).Location = new Point(129, 56);
      ((Control) this.btnDeleteArticles).Name = "btnDeleteArticles";
      this.btnDeleteArticles.OuterBorderColor = Color.MistyRose;
      this.btnDeleteArticles.ShineColor = Color.MistyRose;
      ((Control) this.btnDeleteArticles).Size = new Size(199, 53);
      ((Control) this.btnDeleteArticles).TabIndex = 3;
      ((Control) this.btnDeleteArticles).Text = "DELETE";
      ((ButtonBase) this.btnDeleteArticles).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnDeleteArticles).Click += new EventHandler(this.btnDeleteArticles_Click);
      this.tbxDeleteArticles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxDeleteArticles.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeleteArticles.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeleteArticles.Location = new Point(6, 11);
      this.tbxDeleteArticles.Name = "tbxDeleteArticles";
      this.tbxDeleteArticles.Size = new Size(478, 38);
      this.tbxDeleteArticles.TabIndex = 0;
      this.tbxDeleteArticles.TextChanged += new EventHandler(this.tbxDeleteArticles_TextChanged);
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Columns.AddRange((DataGridViewColumn) this.Mark);
      this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
      this.dataGridView2.Dock = DockStyle.Fill;
      this.dataGridView2.EnableHeadersVisualStyles = false;
      this.dataGridView2.Location = new Point(0, 0);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new Size(498, 483);
      this.dataGridView2.TabIndex = 2;
      this.Mark.FillWeight = 20f;
      this.Mark.HeaderText = "Select";
      this.Mark.Name = "Mark";
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.wrapToolStripMenuItem1,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem1,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem1
      });
      this.contextMenuStrip2.Name = "contextMenuStrip1";
      this.contextMenuStrip2.Size = new Size(197, 114);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(159, 22);
      this.toolStripMenuItem1.Text = "Export to Excel";
      this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
      this.wrapToolStripMenuItem1.Name = "wrapToolStripMenuItem1";
      this.wrapToolStripMenuItem1.Size = new Size(159, 22);
      this.wrapToolStripMenuItem1.Text = "wrap";
      this.wrapToolStripMenuItem1.Click += new EventHandler(this.wrapToolStripMenuItem1_Click);
      this.viewFullScreenToolStripMenuItem1.Name = "viewFullScreenToolStripMenuItem1";
      this.viewFullScreenToolStripMenuItem1.Size = new Size(159, 22);
      this.viewFullScreenToolStripMenuItem1.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem1.Click += new EventHandler(this.viewFullScreenToolStripMenuItem1_Click);
      this.tcArticlesDescription.Controls.Add((Control) this.tpAddArticlesDesription);
      this.tcArticlesDescription.Controls.Add((Control) this.tabPage2);
      this.tcArticlesDescription.Dock = DockStyle.Fill;
      this.tcArticlesDescription.Location = new Point(0, 0);
      this.tcArticlesDescription.Name = "tcArticlesDescription";
      this.tcArticlesDescription.SelectedIndex = 0;
      this.tcArticlesDescription.Size = new Size(498, 141);
      this.tcArticlesDescription.TabIndex = 3;
      this.tpAddArticlesDesription.Controls.Add((Control) this.btnAddArticlesDescription);
      this.tpAddArticlesDesription.Controls.Add((Control) this.tbxAddAritlcesDescription);
      this.tpAddArticlesDesription.Location = new Point(4, 22);
      this.tpAddArticlesDesription.Name = "tpAddArticlesDesription";
      this.tpAddArticlesDesription.Padding = new Padding(3);
      this.tpAddArticlesDesription.Size = new Size(490, 115);
      this.tpAddArticlesDesription.TabIndex = 0;
      this.tpAddArticlesDesription.Text = "ADD ARTICLES DESCRIPTION";
      this.tpAddArticlesDesription.UseVisualStyleBackColor = true;
      this.btnAddArticlesDescription.BackColor = Color.White;
      this.btnAddArticlesDescription.FadeOnFocus = true;
      this.btnAddArticlesDescription.ForeColor = Color.Black;
      this.btnAddArticlesDescription.ForeColorOnFocus = Color.Red;
      this.btnAddArticlesDescription.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddArticlesDescription.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnAddArticlesDescription).Image = (Image) componentResourceManager.GetObject("btnAddArticlesDescription.Image");
      this.btnAddArticlesDescription.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddArticlesDescription).Location = new Point(126, 55);
      ((Control) this.btnAddArticlesDescription).Name = "btnAddArticlesDescription";
      this.btnAddArticlesDescription.OuterBorderColor = Color.MistyRose;
      this.btnAddArticlesDescription.ShineColor = Color.MistyRose;
      ((Control) this.btnAddArticlesDescription).Size = new Size(217, 45);
      ((Control) this.btnAddArticlesDescription).TabIndex = 3;
      ((Control) this.btnAddArticlesDescription).Text = "ADD ARTICLES &DESCRIPTION";
      ((ButtonBase) this.btnAddArticlesDescription).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddArticlesDescription).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddArticlesDescription).Click += new EventHandler(this.btnAddArticlesDescription_Click);
      this.tbxAddAritlcesDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxAddAritlcesDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
      this.tbxAddAritlcesDescription.BorderStyle = BorderStyle.FixedSingle;
      this.tbxAddAritlcesDescription.CharacterCasing = CharacterCasing.Upper;
      this.tbxAddAritlcesDescription.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxAddAritlcesDescription.Location = new Point(6, 9);
      this.tbxAddAritlcesDescription.Name = "tbxAddAritlcesDescription";
      this.tbxAddAritlcesDescription.Size = new Size(478, 31);
      this.tbxAddAritlcesDescription.TabIndex = 0;
      this.tbxAddAritlcesDescription.KeyUp += new KeyEventHandler(this.tbxAddAritlcesDescription_KeyUp);
      this.tabPage2.Controls.Add((Control) this.btnDelete);
      this.tabPage2.Controls.Add((Control) this.tbxDeleteArticlesDescription);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(490, 115);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "DELETE";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.btnDelete.BackColor = Color.White;
      this.btnDelete.FadeOnFocus = true;
      ((Control) this.btnDelete).Font = new Font("Comic Sans MS", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDelete.ForeColor = Color.RoyalBlue;
      this.btnDelete.ForeColorOnFocus = Color.Red;
      this.btnDelete.ForeColorOnLeave = Color.RoyalBlue;
      this.btnDelete.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnDelete).Image = (Image) Resources.deletesymboll;
      this.btnDelete.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnDelete).Location = new Point(144, 55);
      ((Control) this.btnDelete).Name = "btnDelete";
      this.btnDelete.OuterBorderColor = Color.MistyRose;
      this.btnDelete.ShineColor = Color.MistyRose;
      ((Control) this.btnDelete).Size = new Size(217, 54);
      ((Control) this.btnDelete).TabIndex = 4;
      ((Control) this.btnDelete).Text = "DELETE";
      ((ButtonBase) this.btnDelete).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnDelete).Click += new EventHandler(this.btnDeleteArticlesDescription_Click);
      this.tbxDeleteArticlesDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxDeleteArticlesDescription.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeleteArticlesDescription.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDeleteArticlesDescription.Location = new Point(6, 11);
      this.tbxDeleteArticlesDescription.Name = "tbxDeleteArticlesDescription";
      this.tbxDeleteArticlesDescription.Size = new Size(478, 38);
      this.tbxDeleteArticlesDescription.TabIndex = 0;
      this.tbxDeleteArticlesDescription.TextChanged += new EventHandler(this.tbxDeleteArticlesDescription_TextChanged);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn1);
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(498, 483);
      this.dataGridView1.TabIndex = 4;
      this.dataGridViewCheckBoxColumn1.FillWeight = 20f;
      this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
      this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(197, 92);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(196, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(196, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(196, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel4, 1, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.27044f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.72956f));
      this.tableLayoutPanel1.Size = new Size(1008, 636);
      this.tableLayoutPanel1.TabIndex = 5;
      this.panel4.Controls.Add((Control) this.dataGridView2);
      this.panel4.Dock = DockStyle.Fill;
      this.panel4.Location = new Point(507, 150);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(498, 483);
      this.panel4.TabIndex = 3;
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 150);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(498, 483);
      this.panel3.TabIndex = 2;
      this.panel2.Controls.Add((Control) this.tcArticlesDescription);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(507, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(498, 141);
      this.panel2.TabIndex = 1;
      this.panel1.Controls.Add((Control) this.tcArticles);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(498, 141);
      this.panel1.TabIndex = 0;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(196, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel Option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.exportToExcelOption2ToolStripMenuItem1.Name = "exportToExcelOption2ToolStripMenuItem1";
      this.exportToExcelOption2ToolStripMenuItem1.Size = new Size(196, 22);
      this.exportToExcelOption2ToolStripMenuItem1.Text = "Export to Excel Option2";
      this.exportToExcelOption2ToolStripMenuItem1.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem1_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(1008, 636);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.ForeColor = Color.Navy;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.Name = nameof (FormArticles);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Articles";
      this.Load += new EventHandler(this.Articles_Load);
      this.KeyDown += new KeyEventHandler(this.FormArticles_KeyDown);
      this.tcArticles.ResumeLayout(false);
      this.tpAddArticles.ResumeLayout(false);
      this.tpAddArticles.PerformLayout();
      this.tpDeleteArticles.ResumeLayout(false);
      this.tpDeleteArticles.PerformLayout();
      ((ISupportInitialize) this.dataGridView2).EndInit();
      this.contextMenuStrip2.ResumeLayout(false);
      this.tcArticlesDescription.ResumeLayout(false);
      this.tpAddArticlesDesription.ResumeLayout(false);
      this.tpAddArticlesDesription.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
