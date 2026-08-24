

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
  public class FormRate : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private Panel panel2;
    private Panel panel1;
    private Label label1;
    private GlassButton btnClose;
    private GlassButton btnEdit;
    private GlassButton btnAdd;
    private GlassButton btnDelete;

    public FormRate() => this.InitializeComponent();

    private void refreshGrid()
    {
      DataTable dataTable = new DataTable();
      this.dataGridView1.DataSource = (object) RateClass.getCompleteRateTable();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormRate_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      ((Control) this.btnAdd).Select();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormRateAddEdit("ADD").ShowDialog();
      this.refreshGrid();
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      int num = (int) new FormRateAddEdit("EDIT", this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString()).ShowDialog();
      this.refreshGrid();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      string ID = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
      if (ID != "" && DialogResult.Yes == MessageBox.Show("Delete ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        RateClass.deleteRate(ID);
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
      this.panel2 = new Panel();
      this.panel1 = new Panel();
      this.btnEdit = new GlassButton();
      this.btnClose = new GlassButton();
      this.btnAdd = new GlassButton();
      this.label1 = new Label();
      this.btnDelete = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
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
      this.dataGridView1.Size = new Size(976, 469);
      this.dataGridView1.TabIndex = 0;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Location = new Point(5, 40);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(978, 471);
      this.panel2.TabIndex = 6;
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.btnEdit);
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Location = new Point(5, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(977, 40);
      this.panel1.TabIndex = 0;
      ((Control) this.btnEdit).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEdit.BackColor = Color.WhiteSmoke;
      this.btnEdit.FadeOnFocus = true;
      this.btnEdit.ForeColor = Color.MediumBlue;
      this.btnEdit.ForeColorOnFocus = Color.Red;
      this.btnEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnEdit.GlowColor = Color.White;
      this.btnEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnEdit).Location = new Point(698, 3);
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
      ((Control) this.btnClose).Location = new Point(884, 3);
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
      ((Control) this.btnAdd).Location = new Point(605, 3);
      ((Control) this.btnAdd).Name = "btnAdd";
      this.btnAdd.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAdd.ShineColor = Color.Transparent;
      ((Control) this.btnAdd).Size = new Size(87, 30);
      ((Control) this.btnAdd).TabIndex = 0;
      ((Control) this.btnAdd).Text = "&ADD";
      ((Control) this.btnAdd).Click += new EventHandler(this.btnAdd_Click);
      ((Control) this.btnAdd).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnAdd).MouseHover += new EventHandler(this.btn_MouseHover);
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(6, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(173, 25);
      this.label1.TabIndex = 1;
      this.label1.Text = "RATE MASTER";
      ((Control) this.btnDelete).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.BackColor = Color.WhiteSmoke;
      this.btnDelete.FadeOnFocus = true;
      this.btnDelete.ForeColor = Color.MediumBlue;
      this.btnDelete.ForeColorOnFocus = Color.Red;
      this.btnDelete.ForeColorOnLeave = Color.MediumBlue;
      this.btnDelete.GlowColor = Color.White;
      this.btnDelete.InnerBorderColor = Color.Transparent;
      ((Control) this.btnDelete).Location = new Point(791, 3);
      ((Control) this.btnDelete).Name = "btnDelete";
      this.btnDelete.OuterBorderColor = Color.MediumSlateBlue;
      this.btnDelete.ShineColor = Color.Transparent;
      ((Control) this.btnDelete).Size = new Size(87, 30);
      ((Control) this.btnDelete).TabIndex = 2;
      ((Control) this.btnDelete).Text = "&DELETE";
      ((Control) this.btnDelete).Click += new EventHandler(this.btnDelete_Click);
      ((Control) this.btnDelete).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnDelete).MouseHover += new EventHandler(this.btn_MouseHover);
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(984, 508);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (FormRate);
      this.Text = "RATE MASTER";
      this.Load += new EventHandler(this.FormRate_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
