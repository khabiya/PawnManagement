

using ExportToExcel11;
using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormSmsMessages : Form
  {
    private ResourceManager LocRM = new ResourceManager("PawnManagement.WinFormStrings", typeof (FormLoginOld).Assembly);
    private DataTable dtrefreshGrid = new DataTable();
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private RichTextBox rtbMessageText;
    private GlassButton btnAddEdit;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private TextBox tbxMessageType;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private HeaderPanel headerPanel3;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private TextBox tbxDefault;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label7;
    private Panel panel3;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton8;
    private GlassButton glassButton9;
    private TextBox tbxMessageLength;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;

    public FormSmsMessages() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormSmsMessages_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      PawnManagementClass.formatButtonBlue(ref this.btnAddEdit);
    }

    private void refreshGrid()
    {
      string strError = "";
      this.dtrefreshGrid = SQLHelper.GetDataTable("select * from tblMessage", ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("FormSmsMessages.refreshgrid()", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in fetching the Messages from  the Message table.\n" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) this.dtrefreshGrid;
      this.dataGridView1.Columns["ID"].Visible = false;
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
      {
        string strError = "";
        if (SQLHelper.RunCommand("Delete from tblMessage where ID =@ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString())
        }, ref strError) != "Done")
        {
          PawnManagementClass.InsertIntoException("FormSmsMessage.deletetroolstripmenuitem_click", strError, FormMain.username, DateTime.Now.ToString());
          int num = (int) MessageBox.Show("Error in deleting row in tblMessage" + strError);
        }
      }
      this.refreshGrid();
    }

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          this.tbxMessageType.Text = this.dataGridView1.Rows[rowIndex].Cells["MessageType"].Value.ToString();
          this.tbxDefault.Text = this.dataGridView1.Rows[rowIndex].Cells["DefaultValue"].Value.ToString();
          this.rtbMessageText.Text = this.dataGridView1.Rows[rowIndex].Cells["MessageText"].Value.ToString();
          ((Control) this.btnAddEdit).Text = "UPDATE";
        }
        else
        {
          int num = (int) MessageBox.Show("Table is empty");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form smsMessages.editToolStripMenuItem", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (((Control) this.btnAddEdit).Text == "UPDATE" && this.tbxMessageType.Text.Trim() != "" && this.tbxDefault.Text.Trim() != "" && this.rtbMessageText.Text.Trim() != "")
        {
          this.editInterest();
          this.reset();
          this.refreshGrid();
        }
        if (((Control) this.btnAddEdit).Text == "ADD" && this.tbxMessageType.Text.Trim() != "" && this.tbxDefault.Text.Trim() != "" && this.rtbMessageText.Text.Trim() != "")
        {
          this.addInterest();
          this.reset();
          this.refreshGrid();
        }
        ((Control) this.btnAddEdit).Text = "ADD";
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form smsMessages.btnAddEdit", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void reset()
    {
      this.tbxMessageType.Text = "";
      this.rtbMessageText.Text = "";
    }

    private void editInterest()
    {
      int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
      string strError = "";
      if (SQLHelper.RunCommand("Update tblMessage set MessageType=@MessageType,MessageText = @MessageText,DefaultValue = @Default  where ID = @ID", new List<OleDbParameter>()
      {
        new OleDbParameter("MessageType", (object) this.tbxMessageType.Text.ToString()),
        new OleDbParameter("MessageText", (object) this.rtbMessageText.Text.ToString()),
        new OleDbParameter("Default", (object) this.tbxDefault.Text.ToString()),
        new OleDbParameter("ID", (object) int.Parse(this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString()))
      }, ref strError) != "Done")
      {
        PawnManagementClass.InsertIntoException("form sms message.editInterest", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in editing" + strError);
      }
      this.refreshGrid();
    }

    private void addInterest()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblMessage(MessageType,MessageText,DefaultValue) values(@MessageType,@MessageText,@Default)", new List<OleDbParameter>()
      {
        new OleDbParameter("MessageType", (object) this.tbxMessageType.Text.ToString()),
        new OleDbParameter("MessageText", (object) this.rtbMessageText.Text.ToString()),
        new OleDbParameter("Default", (object) this.tbxDefault.Text.ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form sms messages.addInterest", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void rtbMessageText_TextChanged(object sender, EventArgs e) => this.tbxMessageLength.Text = this.rtbMessageText.Text.Length.ToString() + "/" + (this.rtbMessageText.Text.Length > 160 ? (object) "320" : (object) "160") + " chars - " + (this.rtbMessageText.Text.Length > 160 ? (object) "2" : (object) "1") + " message";

    private void tbxDefault_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'Y' || e.KeyChar == 'N' || e.KeyChar == '\b')
        return;
      e.Handled = true;
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
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

    private void tbxInterestPending_TextChanged(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      Brush brush = (Brush) new LinearGradientBrush(e.CellBounds, Color.PowderBlue, Color.LightCyan, LinearGradientMode.Vertical);
      e.Graphics.FillRectangle(brush, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.rtbMessageText = new RichTextBox();
      this.btnAddEdit = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.tbxMessageType = new TextBox();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.headerPanel3 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.tbxDefault = new TextBox();
      this.panel1 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.panel3 = new Panel();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton8 = new GlassButton();
      this.glassButton9 = new GlassButton();
      this.tbxMessageLength = new TextBox();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      ((Control) this.headerPanel3).SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((Control) this.headerPanel4).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(3, 132);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(988, 432);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 136);
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.eDITToolStripMenuItem.Click += new EventHandler(this.eDITToolStripMenuItem_Click);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.dELETEToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to  Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.rtbMessageText.BackColor = Color.AliceBlue;
      this.rtbMessageText.BorderStyle = BorderStyle.None;
      this.rtbMessageText.Dock = DockStyle.Fill;
      this.rtbMessageText.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rtbMessageText.ForeColor = Color.DarkBlue;
      this.rtbMessageText.Location = new Point(0, 0);
      this.rtbMessageText.MaxLength = 320;
      this.rtbMessageText.Name = "rtbMessageText";
      this.rtbMessageText.Size = new Size(558, 98);
      this.rtbMessageText.TabIndex = 2;
      this.rtbMessageText.Text = "";
      this.rtbMessageText.TextChanged += new EventHandler(this.rtbMessageText_TextChanged);
      ((Control) this.btnAddEdit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddEdit.BackColor = Color.LightBlue;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.White;
      ((ButtonBase) this.btnAddEdit).Image = (Image) PawnManagement.Properties.Resources.plus;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(806, 67);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(180, 54);
      ((Control) this.btnAddEdit).TabIndex = 7;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "MESSAGE TYPE";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxMessageType);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(570, 4);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(419, 58);
      ((Control) this.headerPanel1).TabIndex = 78;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(122, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(256, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxMessageType.BackColor = Color.AliceBlue;
      this.tbxMessageType.BorderStyle = BorderStyle.None;
      this.tbxMessageType.Dock = DockStyle.Fill;
      this.tbxMessageType.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMessageType.ForeColor = Color.DarkBlue;
      this.tbxMessageType.Location = new Point(0, 0);
      this.tbxMessageType.Name = "tbxMessageType";
      this.tbxMessageType.Size = new Size(417, 31);
      this.tbxMessageType.TabIndex = 37;
      this.tbxMessageType.TextChanged += new EventHandler(this.tbxInterestPending_TextChanged);
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel2.CaptionEndColor = Color.AliceBlue;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "MESSAGE TEXT";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.rtbMessageText);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.GradientEnd = SystemColors.ControlLight;
      this.headerPanel2.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel2).Location = new Point(6, 4);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(560, 122);
      ((Control) this.headerPanel2).TabIndex = 79;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      ((ButtonBase) this.glassButton3).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(261, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(395, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel3).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel3).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel3).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel3.BorderColor = SystemColors.HotTrack;
      this.headerPanel3.BorderStyle = BorderStyles.Single;
      this.headerPanel3.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel3.CaptionEndColor = Color.AliceBlue;
      this.headerPanel3.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.CaptionHeight = 22;
      this.headerPanel3.CaptionPosition = CaptionPositions.Top;
      this.headerPanel3.CaptionText = "DEFAULT";
      this.headerPanel3.CaptionVisible = true;
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel3).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel3).Controls.Add((Control) this.tbxDefault);
      ((Control) this.headerPanel3).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel3).ForeColor = Color.DarkBlue;
      this.headerPanel3.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel3.GradientEnd = SystemColors.ControlLight;
      this.headerPanel3.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel3).Location = new Point(726, 71);
      ((Control) this.headerPanel3).Name = "headerPanel3";
      this.headerPanel3.PanelIcon = (Icon) null;
      this.headerPanel3.PanelIconVisible = false;
      ((Control) this.headerPanel3).Size = new Size(73, 58);
      ((Control) this.headerPanel3).TabIndex = 79;
      this.headerPanel3.TextAntialias = true;
      ((Control) this.headerPanel3).Visible = false;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      ((ButtonBase) this.glassButton5).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(-226, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 0;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(-92, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxDefault.BackColor = Color.AliceBlue;
      this.tbxDefault.BorderStyle = BorderStyle.None;
      this.tbxDefault.Dock = DockStyle.Fill;
      this.tbxDefault.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDefault.Location = new Point(0, 0);
      this.tbxDefault.Name = "tbxDefault";
      this.tbxDefault.Size = new Size(71, 31);
      this.tbxDefault.TabIndex = 37;
      this.tbxDefault.Text = "N";
      this.panel1.Anchor = AnchorStyles.Top;
      this.panel1.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1002, 626);
      this.panel1.TabIndex = 80;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.146965f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.85303f));
      this.tableLayoutPanel1.Size = new Size(1002, 626);
      this.tableLayoutPanel1.TabIndex = 80;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) PawnManagement.Properties.Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(996, 45);
      this.panel2.TabIndex = 9;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(383, 6);
      this.label7.Name = "label7";
      this.label7.Size = new Size(204, 29);
      this.label7.TabIndex = 10;
      this.label7.Text = "SMS MESSAGES";
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.headerPanel4);
      this.panel3.Controls.Add((Control) this.btnAddEdit);
      this.panel3.Controls.Add((Control) this.headerPanel1);
      this.panel3.Controls.Add((Control) this.headerPanel2);
      this.panel3.Controls.Add((Control) this.dataGridView1);
      this.panel3.Controls.Add((Control) this.headerPanel3);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.Location = new Point(3, 54);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(996, 569);
      this.panel3.TabIndex = 11;
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImage = (Image) PawnManagement.Properties.Resources.background_gradient_blue1;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel4.CaptionEndColor = Color.AliceBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "MESSAGE LENGTH";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton8);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton9);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxMessageLength);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(571, 67);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(228, 50);
      ((Control) this.headerPanel4).TabIndex = 79;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton8).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton8.BackColor = Color.LightBlue;
      this.glassButton8.FadeOnFocus = true;
      ((Control) this.glassButton8).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton8.ForeColor = Color.MediumBlue;
      this.glassButton8.ForeColorOnFocus = Color.Red;
      this.glassButton8.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton8.GlowColor = Color.White;
      ((ButtonBase) this.glassButton8).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton8.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton8).Location = new Point(-71, 513);
      ((Control) this.glassButton8).Name = "glassButton8";
      this.glassButton8.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton8.ShineColor = Color.Transparent;
      ((Control) this.glassButton8).Size = new Size(128, 35);
      ((Control) this.glassButton8).TabIndex = 0;
      ((Control) this.glassButton8).Text = "&SAVE";
      ((ButtonBase) this.glassButton8).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton9).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton9.BackColor = Color.LightBlue;
      this.glassButton9.FadeOnFocus = true;
      ((Control) this.glassButton9).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton9.ForeColor = Color.MediumBlue;
      this.glassButton9.ForeColorOnFocus = Color.Red;
      this.glassButton9.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton9.GlowColor = Color.White;
      this.glassButton9.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton9).Location = new Point(63, 512);
      ((Control) this.glassButton9).Name = "glassButton9";
      this.glassButton9.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton9.ShineColor = Color.Transparent;
      ((Control) this.glassButton9).Size = new Size(123, 37);
      ((Control) this.glassButton9).TabIndex = 1;
      ((Control) this.glassButton9).Text = "&EXIT";
      ((ButtonBase) this.glassButton9).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxMessageLength.BackColor = Color.AliceBlue;
      this.tbxMessageLength.BorderStyle = BorderStyle.None;
      this.tbxMessageLength.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxMessageLength.ForeColor = Color.DarkBlue;
      this.tbxMessageLength.Location = new Point(0, 3);
      this.tbxMessageLength.Name = "tbxMessageLength";
      this.tbxMessageLength.Size = new Size(228, 19);
      this.tbxMessageLength.TabIndex = 37;
      this.tbxMessageLength.TextAlign = HorizontalAlignment.Center;
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.MintCream;
      this.ClientSize = new Size(1008, 626);
      this.Controls.Add((Control) this.panel1);
      this.ForeColor = Color.Black;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormSmsMessages);
      this.Text = nameof (FormSmsMessages);
      this.Load += new EventHandler(this.FormSmsMessages_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel3).ResumeLayout(false);
      ((Control) this.headerPanel3).PerformLayout();
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
