
using ExportToExcel11;
using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormShopDetailss : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private string oldValues;
    private string newValues;
    private string ShopCode = "";
    private IContainer components = (IContainer) null;
    private Panel panel2;
    private Label label7;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem dELETEToolStripMenuItem;
    private ToolStripMenuItem eDITToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem viewFullScreenToolStripMenuItem;
    private ToolStripMenuItem setAsDefaultToolStripMenuItem;
    private ToolStripMenuItem tsmiMarkAsHidden;
    private ToolStripMenuItem tsmiUnMarkAsHidden;
    private ToolStripMenuItem exportToExcelOption2ToolStripMenuItem;
    private Button btnClose;
    private Button btnDelete;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnSetAsDEfault;
    private Panel panel1;

    public FormShopDetailss()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    private void refreshGrid() => this.dataGridView1.DataSource = (object) ShopDetailsClass.getTheseColumnsFromShopDetails("SHOPCODE", "SHOPNAME", "PROPRIETOR");

    private string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["VOUCHERCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
    }

    private void tbxVoucherCodeIntChoot_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "LICENSE MASTER").ShowDialog();
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

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "LICENSE Master", FormMain.username);

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ClassStyle |= 131072;
        return createParams;
      }
    }

    private void tbxAcceptDecimal(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        switch (control1)
        {
          case TextBox _:
            TextBox textBox = (TextBox) control1;
            textBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
            textBox.Enter += new EventHandler(this.textBox_Enter);
            textBox.Leave += new EventHandler(this.textBox_Leave);
            break;
          case Button _:
            Button button = (Button) control1;
            button.Enter += new EventHandler(this.btn_Enter);
            button.Leave += new EventHandler(this.btn_Leave);
            button.MouseEnter += new EventHandler(this.btn_MouseEnter);
            button.MouseLeave += new EventHandler(this.btn_MouseLeave);
            break;
          default:
            this.Assign(control1);
            break;
        }
      }
    }

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void textBox_Enter(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.Black;
      textBox.ForeColor = Color.Yellow;
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
      TextBox textBox = sender as TextBox;
      textBox.BackColor = Color.White;
      textBox.ForeColor = Color.DarkBlue;
    }

    private void FormShopDetailss_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      this.Assign((Control) this);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormShopDetailsAddEdit("ADD", "").ShowDialog();
      this.refreshGrid();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        if (this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString().Trim() != "")
        {
          int num = (int) new FormShopDetailsAddEdit("EDIT", this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString()).ShowDialog();
          this.refreshGrid();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.editToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void btn_Enter(object sender, EventArgs e) => (sender as Button).BackColor = Color.NavajoWhite;

    private void btn_Leave(object sender, EventArgs e) => (sender as Button).BackColor = Color.Transparent;

    private void btn_MouseEnter(object sender, EventArgs e) => (sender as Button).BackColor = Color.NavajoWhite;

    private void btn_MouseLeave(object sender, EventArgs e) => (sender as Button).BackColor = Color.Transparent;

    private void btnSetAsDefault_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0 && this.dataGridView1.CurrentCell != null)
        ShopDetailsClass.setAsDefaul(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString());
      this.refreshGrid();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows != null && this.dataGridView1.Rows.Count > 1 && this.dataGridView1.CurrentCell != null)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          if (!PawnManagement.Classes.PawnManagementClasses.PledgeClass.checkIfShopCodeUsedInPledge(this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString()))
          {
            if (!RedemptionClass.checkIfShopCodeUsedInRedemption(this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString()) && DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
              ShopDetailsClass.deleteShopCode(this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString());
              PawnManagementClass.InsertIntoHistory("LICENSE MASTER DELETE", "LICense entry " + this.dataGridView1.Rows[rowIndex].Cells["ShopCode"].Value.ToString() + "deleted", "", "", FormMain.username, DateTime.Now.ToString());
            }
          }
          else
          {
            int num = (int) MessageBox.Show("Shop Code Already in Use...Cannot be deleted");
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Cannot Delete All the license...Atleast one license need to be active");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master deletetoolStripMentuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
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
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormShopDetailss));
      this.panel2 = new Panel();
      this.label7 = new Label();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.dELETEToolStripMenuItem = new ToolStripMenuItem();
      this.eDITToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.viewFullScreenToolStripMenuItem = new ToolStripMenuItem();
      this.setAsDefaultToolStripMenuItem = new ToolStripMenuItem();
      this.tsmiMarkAsHidden = new ToolStripMenuItem();
      this.tsmiUnMarkAsHidden = new ToolStripMenuItem();
      this.exportToExcelOption2ToolStripMenuItem = new ToolStripMenuItem();
      this.btnClose = new Button();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.btnEdit = new Button();
      this.btnSetAsDEfault = new Button();
      this.panel1 = new Panel();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(831, 52);
      this.panel2.TabIndex = 0;
      this.label7.Anchor = AnchorStyles.Top;
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkSlateBlue;
      this.label7.Location = new Point(245, 5);
      this.label7.Name = "label7";
      this.label7.Size = new Size(294, 37);
      this.label7.TabIndex = 0;
      this.label7.Text = "LICENSE MASTER";
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dataGridView1.BackgroundColor = Color.Honeydew;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.Azure;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeight = 50;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(0, 47);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(831, 488);
      this.dataGridView1.TabIndex = 1;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.dELETEToolStripMenuItem,
        (ToolStripItem) this.eDITToolStripMenuItem,
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem,
        (ToolStripItem) this.viewFullScreenToolStripMenuItem,
        (ToolStripItem) this.setAsDefaultToolStripMenuItem,
        (ToolStripItem) this.tsmiMarkAsHidden,
        (ToolStripItem) this.tsmiUnMarkAsHidden,
        (ToolStripItem) this.exportToExcelOption2ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(195, 202);
      this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
      this.dELETEToolStripMenuItem.Size = new Size(194, 22);
      this.dELETEToolStripMenuItem.Text = "DELETE";
      this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
      this.eDITToolStripMenuItem.Size = new Size(194, 22);
      this.eDITToolStripMenuItem.Text = "EDIT";
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export  To Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(194, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.viewFullScreenToolStripMenuItem.Name = "viewFullScreenToolStripMenuItem";
      this.viewFullScreenToolStripMenuItem.Size = new Size(194, 22);
      this.viewFullScreenToolStripMenuItem.Text = "View Full Screen";
      this.viewFullScreenToolStripMenuItem.Click += new EventHandler(this.viewFullScreenToolStripMenuItem_Click);
      this.setAsDefaultToolStripMenuItem.Name = "setAsDefaultToolStripMenuItem";
      this.setAsDefaultToolStripMenuItem.Size = new Size(194, 22);
      this.setAsDefaultToolStripMenuItem.Text = "Set As Default";
      this.tsmiMarkAsHidden.Name = "tsmiMarkAsHidden";
      this.tsmiMarkAsHidden.Size = new Size(194, 22);
      this.tsmiMarkAsHidden.Text = "Mark As Hidden";
      this.tsmiUnMarkAsHidden.Name = "tsmiUnMarkAsHidden";
      this.tsmiUnMarkAsHidden.Size = new Size(194, 22);
      this.tsmiUnMarkAsHidden.Text = "UnMark As Hidden";
      this.exportToExcelOption2ToolStripMenuItem.Name = "exportToExcelOption2ToolStripMenuItem";
      this.exportToExcelOption2ToolStripMenuItem.Size = new Size(194, 22);
      this.exportToExcelOption2ToolStripMenuItem.Text = "Export to Excel option2";
      this.exportToExcelOption2ToolStripMenuItem.Click += new EventHandler(this.exportToExcelOption2ToolStripMenuItem_Click);
      this.btnClose.Anchor = AnchorStyles.Bottom;
      this.btnClose.BackColor = Color.Transparent;
      this.btnClose.FlatAppearance.BorderColor = Color.Black;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnClose.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnClose.FlatStyle = FlatStyle.Popup;
      this.btnClose.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnClose.ForeColor = Color.Black;
      this.btnClose.Image = (Image) componentResourceManager.GetObject("btnClose.Image");
      this.btnClose.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnClose.Location = new Point(663, 7);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(159, 51);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "       &Close";
      this.btnClose.TextAlign = ContentAlignment.MiddleRight;
      this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.btnDelete.Anchor = AnchorStyles.Bottom;
      this.btnDelete.BackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.BorderColor = Color.Black;
      this.btnDelete.FlatAppearance.BorderSize = 0;
      this.btnDelete.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnDelete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnDelete.FlatStyle = FlatStyle.Popup;
      this.btnDelete.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDelete.ForeColor = Color.Black;
      this.btnDelete.Image = (Image) componentResourceManager.GetObject("btnDelete.Image");
      this.btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnDelete.Location = new Point(334, 7);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(159, 51);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "       &Delete";
      this.btnDelete.TextAlign = ContentAlignment.MiddleRight;
      this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
      this.btnAdd.Anchor = AnchorStyles.Bottom;
      this.btnAdd.BackColor = Color.Transparent;
      this.btnAdd.FlatAppearance.BorderColor = Color.Black;
      this.btnAdd.FlatAppearance.BorderSize = 0;
      this.btnAdd.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnAdd.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnAdd.FlatStyle = FlatStyle.Popup;
      this.btnAdd.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAdd.ForeColor = Color.Black;
      this.btnAdd.Image = (Image) componentResourceManager.GetObject("btnAdd.Image");
      this.btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAdd.Location = new Point(6, 7);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(159, 51);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "       &Add";
      this.btnAdd.TextAlign = ContentAlignment.MiddleRight;
      this.btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
      this.btnEdit.Anchor = AnchorStyles.Bottom;
      this.btnEdit.BackColor = Color.Transparent;
      this.btnEdit.FlatAppearance.BorderColor = Color.Black;
      this.btnEdit.FlatAppearance.BorderSize = 0;
      this.btnEdit.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnEdit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnEdit.FlatStyle = FlatStyle.Popup;
      this.btnEdit.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnEdit.ForeColor = Color.Black;
      this.btnEdit.Image = (Image) componentResourceManager.GetObject("btnEdit.Image");
      this.btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnEdit.Location = new Point(169, 7);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new Size(159, 51);
      this.btnEdit.TabIndex = 3;
      this.btnEdit.Text = "       &Edit";
      this.btnEdit.TextAlign = ContentAlignment.MiddleRight;
      this.btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnEdit.UseVisualStyleBackColor = false;
      this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
      this.btnSetAsDEfault.Anchor = AnchorStyles.Bottom;
      this.btnSetAsDEfault.BackColor = Color.Transparent;
      this.btnSetAsDEfault.FlatAppearance.BorderColor = Color.Black;
      this.btnSetAsDEfault.FlatAppearance.BorderSize = 0;
      this.btnSetAsDEfault.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.btnSetAsDEfault.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
      this.btnSetAsDEfault.FlatStyle = FlatStyle.Popup;
      this.btnSetAsDEfault.Font = new Font("Century Gothic", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSetAsDEfault.ForeColor = Color.Black;
      this.btnSetAsDEfault.Image = (Image) componentResourceManager.GetObject("btnSetAsDEfault.Image");
      this.btnSetAsDEfault.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSetAsDEfault.Location = new Point(499, 7);
      this.btnSetAsDEfault.Name = "btnSetAsDEfault";
      this.btnSetAsDEfault.Size = new Size(159, 51);
      this.btnSetAsDEfault.TabIndex = 5;
      this.btnSetAsDEfault.Text = "       &Set As Default";
      this.btnSetAsDEfault.TextAlign = ContentAlignment.MiddleRight;
      this.btnSetAsDEfault.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnSetAsDEfault.UseVisualStyleBackColor = false;
      this.btnSetAsDEfault.Click += new EventHandler(this.btnSetAsDefault_Click);
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Controls.Add((Control) this.btnEdit);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.btnSetAsDEfault);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 533);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(831, 67);
      this.panel1.TabIndex = 7;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(831, 600);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormShopDetailss);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormShopDetailss);
      this.Load += new EventHandler(this.FormShopDetailss_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
