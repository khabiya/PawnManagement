
using Glass;
using PawnManagement.Classes.JewelleryClasses;
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.JewelleryForms
{
  public class FormItemTypeMaster : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private Panel panel1;
    private GlassButton btnEdit;
    private GlassButton btnClose;
    private GlassButton btnAdd;
    private Label label1;
    private GlassButton btnDelete;
    private Panel panel2;

    public FormItemTypeMaster() => this.InitializeComponent();

    private void FormItemTypeMaster_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      ((Control) this.btnAdd).Select();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void refreshGrid()
    {
      DataTable dataTable = new DataTable();
      this.dataGridView1.DataSource = (object) ItemTypesClass.getCompleteItemTypeTable();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormItemTypesAddEdit("ADD").ShowDialog();
      this.refreshGrid();
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      string ItemTYPE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ItemType"].Value.ToString();
      if (ItemTYPE.Trim() != "")
      {
        int num = (int) new FormItemTypesAddEdit("EDIT", ItemTYPE).ShowDialog();
        this.refreshGrid();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      string ItemType = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ItemType"].Value.ToString();
      if (ItemType != "" && DialogResult.Yes == MessageBox.Show("Delete ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        ItemTypesClass.deleteItemType(ItemType);
        this.refreshGrid();
      }
    }

    private void btn_MouseHover(object sender, EventArgs e) => (sender as GlassButton).BackColor = Color.DarkBlue;

    private void btn_MouseLeave(object sender, EventArgs e) => (sender as GlassButton).BackColor = Color.WhiteSmoke;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridView1 = new DataGridView();
      this.panel1 = new Panel();
      this.btnEdit = new GlassButton();
      this.btnClose = new GlassButton();
      this.btnAdd = new GlassButton();
      this.label1 = new Label();
      this.btnDelete = new GlassButton();
      this.panel2 = new Panel();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.BackgroundColor = Color.White;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeight = 35;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(976, 465);
      this.dataGridView1.TabIndex = 0;
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.btnEdit);
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(978, 40);
      this.panel1.TabIndex = 9;
      ((Control) this.btnEdit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEdit.BackColor = Color.WhiteSmoke;
      this.btnEdit.FadeOnFocus = true;
      this.btnEdit.ForeColor = Color.MediumBlue;
      this.btnEdit.ForeColorOnFocus = Color.Red;
      this.btnEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnEdit.GlowColor = Color.White;
      this.btnEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnEdit).Location = new Point(699, 3);
      ((Control) this.btnEdit).Name = "btnEdit";
      this.btnEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnEdit.ShineColor = Color.Transparent;
      ((Control) this.btnEdit).Size = new Size(87, 30);
      ((Control) this.btnEdit).TabIndex = 1;
      ((Control) this.btnEdit).Text = "&EDIT";
      ((Control) this.btnEdit).Click += new EventHandler(this.btnEdit_Click);
      ((Control) this.btnEdit).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnEdit).MouseHover += new EventHandler(this.btn_MouseHover);
      ((Control) this.btnClose).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnClose.BackColor = Color.WhiteSmoke;
      this.btnClose.FadeOnFocus = true;
      this.btnClose.ForeColor = Color.MediumBlue;
      this.btnClose.ForeColorOnFocus = Color.Red;
      this.btnClose.ForeColorOnLeave = Color.MediumBlue;
      this.btnClose.GlowColor = Color.White;
      this.btnClose.InnerBorderColor = Color.Transparent;
      ((Control) this.btnClose).Location = new Point(885, 3);
      ((Control) this.btnClose).Name = "btnClose";
      this.btnClose.OuterBorderColor = Color.MediumSlateBlue;
      this.btnClose.ShineColor = Color.Transparent;
      ((Control) this.btnClose).Size = new Size(87, 30);
      ((Control) this.btnClose).TabIndex = 0;
      ((Control) this.btnClose).Text = "&CLOSE";
      ((Control) this.btnClose).Click += new EventHandler(this.btnClose_Click);
      ((Control) this.btnClose).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnClose).MouseHover += new EventHandler(this.btn_MouseHover);
      ((Control) this.btnAdd).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.BackColor = Color.WhiteSmoke;
      this.btnAdd.FadeOnFocus = true;
      this.btnAdd.ForeColor = Color.MediumBlue;
      this.btnAdd.ForeColorOnFocus = Color.Red;
      this.btnAdd.ForeColorOnLeave = Color.MediumBlue;
      this.btnAdd.GlowColor = Color.White;
      this.btnAdd.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAdd).Location = new Point(606, 3);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.Transparent;
      ((Control) this.btnAdd).Size = new Size(87, 30);
      ((Control) this.btnAdd).TabIndex = 0;
      ((Control) this.btnAdd).Text = "&ADD";
      ((Control) this.btnAdd).Click += new EventHandler(this.btnAdd_Click);
      ((Control) this.btnAdd).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnAdd).MouseHover += new EventHandler(this.btn_MouseHover);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(6, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(249, 25);
      this.label1.TabIndex = 1;
      this.label1.Text = "ITEM TYPES MASTER";
      ((Control) this.btnDelete).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.BackColor = Color.WhiteSmoke;
      this.btnDelete.FadeOnFocus = true;
      this.btnDelete.ForeColor = Color.MediumBlue;
      this.btnDelete.ForeColorOnFocus = Color.Red;
      this.btnDelete.ForeColorOnLeave = Color.MediumBlue;
      this.btnDelete.GlowColor = Color.White;
      this.btnDelete.InnerBorderColor = Color.Transparent;
      ((Control) this.btnDelete).Location = new Point(792, 3);
      ((Control) this.btnDelete).Name = "btnDelete";
      this.btnDelete.OuterBorderColor = Color.MediumSlateBlue;
      this.btnDelete.ShineColor = Color.Transparent;
      ((Control) this.btnDelete).Size = new Size(87, 30);
      ((Control) this.btnDelete).TabIndex = 2;
      ((Control) this.btnDelete).Text = "&DELETE";
      ((Control) this.btnDelete).Click += new EventHandler(this.btnDelete_Click);
      ((Control) this.btnDelete).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnDelete).MouseHover += new EventHandler(this.btn_MouseHover);
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Location = new Point(3, 38);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(978, 467);
      this.panel2.TabIndex = 10;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(984, 508);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.Name = nameof (FormItemTypeMaster);
      this.Text = nameof (FormItemTypeMaster);
      this.Load += new EventHandler(this.FormItemTypeMaster_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
