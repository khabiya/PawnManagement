
using ExportToExcel11;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Chit
{
  public class FormChitMaster : Form
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Button btnClose;
    private Button btnDelete;
    private Button btnAdd;
    private Button btnEdit;
    private DataGridView dataGridView1;

    public FormChitMaster() => this.InitializeComponent();

    private void FormChitMaster_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewBlue(ref this.dataGridView1);
      this.Assign((Control) this);
    }

    private void refreshGrid() => this.dataGridView1.DataSource = (object) BillerClass.getCompleteBillerTable("BillerName");

    private void Assign(Control control)
    {
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
      {
        if (control1 is TextBox)
        {
          TextBox textBox = (TextBox) control1;
          textBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
          textBox.Enter += new EventHandler(this.textBox_Enter);
          textBox.Leave += new EventHandler(this.textBox_Leave);
        }
        else
          this.Assign(control1);
      }
    }

    private void SELECTNEXTCONTROL(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
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

    private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0 || !(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString().Trim() != ""))
          ;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.editToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows != null && this.dataGridView1.Rows.Count > 1)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            BillerClass.deleteBiller("ID", this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString());
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot Delete All the Billers...Atleast one Biller need to be active");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master deletetoolStripMentuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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

    private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      int num = (int) new FormDataGridView((DataTable) ((DataGridView) owner.SourceControl).DataSource, "LICENSE MASTER").ShowDialog();
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e) => ExportToExcel.exportToExcel(this.dataGridView1, "Biller Details", FormMain.username);

    private void setAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1.Rows.Count > 0)
      {
        string strError1 = "";
        if (!(SQLHelper.RunCommand("Update tblBiller set DefaultValue='Y' where ID = @ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString())
        }, ref strError1) == "Done"))
        {
          int num1 = (int) MessageBox.Show("Error in updating" + strError1);
        }
        string strError2 = "";
        if (!(SQLHelper.RunCommand("Update tblBiller set DefaultValue ='N' where ID <> @ID", new List<OleDbParameter>()
        {
          new OleDbParameter("ID", (object) this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString())
        }, ref strError2) == "Done"))
        {
          int num2 = (int) MessageBox.Show("Error in updating" + strError2);
        }
      }
      this.refreshGrid();
    }

    private void glassButton1_Click_1(object sender, EventArgs e)
    {
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
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

    private void btnAdd_Click(object sender, EventArgs e)
    {
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0 || !(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString().Trim() != ""))
          ;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.editToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1.Rows != null && this.dataGridView1.Rows.Count > 1)
        {
          int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
          if (DialogResult.Yes == MessageBox.Show("Are you sure???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            BillerClass.deleteBiller("ID", this.dataGridView1.Rows[rowIndex].Cells["ID"].Value.ToString());
        }
        else
        {
          int num = (int) MessageBox.Show("Cannot Delete All the Billers...Atleast one Biller need to be active");
        }
        this.refreshGrid();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master deletetoolStripMentuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormChitMaster));
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      this.btnClose = new Button();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.btnEdit = new Button();
      this.dataGridView1 = new DataGridView();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(724, 71);
      this.panel1.TabIndex = 0;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Controls.Add((Control) this.panel3);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(0, 71);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(724, 389);
      this.panel2.TabIndex = 1;
      this.panel3.Controls.Add((Control) this.btnClose);
      this.panel3.Controls.Add((Control) this.btnDelete);
      this.panel3.Controls.Add((Control) this.btnAdd);
      this.panel3.Controls.Add((Control) this.btnEdit);
      this.panel3.Dock = DockStyle.Bottom;
      this.panel3.Location = new Point(0, 315);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(724, 74);
      this.panel3.TabIndex = 1;
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
      this.btnClose.Location = new Point(530, 12);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(159, 51);
      this.btnClose.TabIndex = 25;
      this.btnClose.Text = "       &Close(F4)";
      this.btnClose.TextAlign = ContentAlignment.MiddleRight;
      this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnClose.UseVisualStyleBackColor = false;
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
      this.btnDelete.Location = new Point(354, 12);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(171, 51);
      this.btnDelete.TabIndex = 24;
      this.btnDelete.Text = "       &Delete(F3)";
      this.btnDelete.TextAlign = ContentAlignment.MiddleRight;
      this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnDelete.UseVisualStyleBackColor = false;
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
      this.btnAdd.Location = new Point(38, 12);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(159, 51);
      this.btnAdd.TabIndex = 22;
      this.btnAdd.Text = "       &Add(F1)";
      this.btnAdd.TextAlign = ContentAlignment.MiddleRight;
      this.btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
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
      this.btnEdit.Location = new Point(201, 12);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new Size(147, 51);
      this.btnEdit.TabIndex = 23;
      this.btnEdit.Text = "       &Edit(F2)";
      this.btnEdit.TextAlign = ContentAlignment.MiddleRight;
      this.btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnEdit.UseVisualStyleBackColor = false;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(724, 315);
      this.dataGridView1.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(724, 460);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormChitMaster);
      this.Text = nameof (FormChitMaster);
      this.Load += new EventHandler(this.FormChitMaster_Load);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
