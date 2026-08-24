
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
  public class FormItemNamesMaster : Form
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
    private Label label2;
    private TextBox tbxSearch;

    public FormItemNamesMaster() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Escape:
          this.Close();
          break;
        case Keys.Down:
          if (FormItemNamesMaster.FindFocusedControl((Control) this) == this.btnAdd | FormItemNamesMaster.FindFocusedControl((Control) this) == this.btnEdit | FormItemNamesMaster.FindFocusedControl((Control) this) == this.btnDelete | FormItemNamesMaster.FindFocusedControl((Control) this) == this.btnClose && this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
          {
            this.dataGridView1.Rows[0].Selected = true;
            this.dataGridView1.Select();
            break;
          }
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormItemNamesMaster_Load(object sender, EventArgs e)
    {
      this.refreshGrid();
      ((Control) this.btnAdd).Select();
      this.dataGridView1.ClearSelection();
    }

    public static Control FindFocusedControl(Control control)
    {
      for (IContainerControl containerControl = control as IContainerControl; containerControl != null; containerControl = control as IContainerControl)
        control = containerControl.ActiveControl;
      return control;
    }

    private void refreshGrid()
    {
      DataTable dataTable = new DataTable();
      this.dataGridView1.DataSource = (object) ItemNamesMasterClass.getCompleteItemNamesTable();
      this.dataGridView1.ClearSelection();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormItemNamesAddEdit("ADD").ShowDialog();
      this.refreshGrid();
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      string itemCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();
      if (itemCODE.Trim() != "")
      {
        int num = (int) new FormItemNamesAddEdit("EDIT", itemCODE).ShowDialog();
        this.refreshGrid();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
        return;
      string ItemCode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ItemCode"].Value.ToString();
      if (ItemCode != "" && DialogResult.Yes == MessageBox.Show("Delete ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
      {
        ItemNamesMasterClass.deleteItemCode(ItemCode);
        this.refreshGrid();
      }
    }

    private void btn_MouseHover(object sender, EventArgs e) => (sender as GlassButton).BackColor = Color.DarkBlue;

    private void btn_MouseLeave(object sender, EventArgs e) => (sender as GlassButton).BackColor = Color.WhiteSmoke;

    private void btnAdd_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0)
        return;
      this.dataGridView1.Rows[0].Selected = true;
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        ((Button) this.btnEdit).PerformClick();
      }
      else
      {
        if (e.KeyCode != Keys.Up || this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentRow == null || this.dataGridView1.CurrentRow.Index != 0)
          return;
        ((Control) this.btnAdd).Select();
        this.dataGridView1.ClearSelection();
      }
    }

    private void btnAdd_KeyUp(object sender, KeyEventArgs e)
    {
    }

    private void FormItemNamesMaster_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void tbxSearch_TextChanged(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      this.dataGridView1.DataSource = (object) ItemNamesMasterClass.getAllTheItemsBasedOnTheSearch(this.tbxSearch.Text);
    }

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
      this.label2 = new Label();
      this.tbxSearch = new TextBox();
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
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackgroundImage = (Image) Resources.GREYGRADIENTHORIZONTAL;
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.tbxSearch);
      this.panel1.Controls.Add((Control) this.btnEdit);
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(978, 40);
      this.panel1.TabIndex = 0;
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(346, 10);
      this.label2.Name = "label2";
      this.label2.Size = new Size(70, 16);
      this.label2.TabIndex = 6;
      this.label2.Text = "SEARCH";
      this.tbxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.tbxSearch.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSearch.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxSearch.Location = new Point(424, 5);
      this.tbxSearch.Name = "tbxSearch";
      this.tbxSearch.Size = new Size(176, 26);
      this.tbxSearch.TabIndex = 5;
      this.tbxSearch.TextChanged += new EventHandler(this.tbxSearch_TextChanged);
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
      ((Control) this.btnEdit).KeyDown += new KeyEventHandler(this.btnAdd_KeyDown);
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
      ((Control) this.btnClose).TabIndex = 3;
      ((Control) this.btnClose).Text = "&CLOSE";
      ((Control) this.btnClose).Click += new EventHandler(this.btnClose_Click);
      ((Control) this.btnClose).KeyDown += new KeyEventHandler(this.btnAdd_KeyDown);
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
      ((Control) this.btnAdd).KeyDown += new KeyEventHandler(this.btnAdd_KeyDown);
      ((Control) this.btnAdd).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnAdd).MouseHover += new EventHandler(this.btn_MouseHover);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(6, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(261, 25);
      this.label1.TabIndex = 4;
      this.label1.Text = "ITEM NAMES  MASTER";
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
      ((Control) this.btnDelete).KeyDown += new KeyEventHandler(this.btnAdd_KeyDown);
      ((Control) this.btnDelete).MouseLeave += new EventHandler(this.btn_MouseLeave);
      ((Control) this.btnDelete).MouseHover += new EventHandler(this.btn_MouseHover);
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.dataGridView1);
      this.panel2.Location = new Point(3, 38);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(978, 467);
      this.panel2.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(984, 508);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.KeyPreview = true;
      this.Name = nameof (FormItemNamesMaster);
      this.Text = "ItemNamesMaster";
      this.Load += new EventHandler(this.FormItemNamesMaster_Load);
      this.KeyDown += new KeyEventHandler(this.FormItemNamesMaster_KeyDown);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
