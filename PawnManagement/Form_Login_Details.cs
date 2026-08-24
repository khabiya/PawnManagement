

using PawnManagement.Classes.PawnManagementClasses;
using PawnManagement.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement
{
  public class Form_Login_Details : Form
  {
    private string oldValues;
    private string newValues;
    private IContainer components = (IContainer) null;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnClose;
    private Panel panel2;
    private Panel panel1;
    private DataGridView dataGridView1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem managePermissionsToolStripMenuItem;

    public Form_Login_Details()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
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
          case ComboBox _:
            ComboBox comboBox = (ComboBox) control1;
            comboBox.KeyDown += new KeyEventHandler(this.SELECTNEXTCONTROL);
            comboBox.Enter += new EventHandler(this.comboBoX_Enter);
            comboBox.Leave += new EventHandler(this.comboBox_Leave);
            break;
          default:
            this.Assign(control1);
            break;
        }
      }
    }

    private void comboBoX_Enter(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.GreenYellow;

    private void comboBox_Leave(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.White;

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
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

    private void Form1_Load(object sender, EventArgs e)
    {
      PawnManagementClass.formatDataGridViewControl(ref this.dataGridView1);
      this.Assign((Control) this);
      this.refreshGrid();
    }

    private void refreshGrid()
    {
      DataTable completeLoginTable = LoginClass.getCompleteLoginTable("UserName");
      if (completeLoginTable != null && completeLoginTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) completeLoginTable.Rows)
          row["Pwd"] = (object) PawnManagementClass.decrypt(row["Pwd"].ToString()).Substring(1);
      }
      this.dataGridView1.DataSource = (object) completeLoginTable;
      this.dataGridView1.Columns["MemberId"].Visible = false;
      this.dataGridView1.Columns["Active"].Visible = false;
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

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new FormLoginAddEdit("ADD", "", "").ShowDialog();
      this.refreshGrid();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
          return;
        int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
        string ID = this.dataGridView1.Rows[rowIndex].Cells["UserName"].Value.ToString();
        if (ID.Trim() != "")
        {
          int num = (int) new FormLoginAddEdit("EDIT", this.dataGridView1.Rows[rowIndex].Cells["UserName"].Value.ToString(), ID).ShowDialog();
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

    private void managePermissionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 == null || this.dataGridView1.Rows.Count <= 0 || this.dataGridView1.CurrentRow == null)
        return;
      FormLoginPermission formLoginPermission = new FormLoginPermission();
      FormLoginPermission.strLoginName = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["username"].Value.ToString();
      int num = (int) formLoginPermission.ShowDialog();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0 && this.dataGridView1.CurrentCell != null && this.dataGridView1.CurrentCell.RowIndex >= 0)
      {
        if (this.dataGridView1.Rows.Count > 1)
        {
          string strVAlue = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["UserName"].Value.ToString();
          if (strVAlue != "")
          {
            if (DialogResult.Yes != MessageBox.Show("Delete ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
              return;
            LoginClass.deleteLogin("UserName", strVAlue);
            this.refreshGrid();
          }
          else
          {
            int num = (int) MessageBox.Show("Select any rows");
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Create another login before deleting all the login");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("No Row selected . Select any row");
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form_Login_Details));
      this.btnAdd = new Button();
      this.btnEdit = new Button();
      this.btnDelete = new Button();
      this.btnClose = new Button();
      this.panel2 = new Panel();
      this.panel1 = new Panel();
      this.dataGridView1 = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.managePermissionsToolStripMenuItem = new ToolStripMenuItem();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
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
      this.btnAdd.Location = new Point(3, 4);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(159, 51);
      this.btnAdd.TabIndex = 18;
      this.btnAdd.Text = "       &Add";
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
      this.btnEdit.Location = new Point(166, 4);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new Size(159, 51);
      this.btnEdit.TabIndex = 19;
      this.btnEdit.Text = "       &Edit";
      this.btnEdit.TextAlign = ContentAlignment.MiddleRight;
      this.btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnEdit.UseVisualStyleBackColor = false;
      this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
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
      this.btnDelete.Location = new Point(331, 4);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(159, 51);
      this.btnDelete.TabIndex = 20;
      this.btnDelete.Text = "       &Delete";
      this.btnDelete.TextAlign = ContentAlignment.MiddleRight;
      this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
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
      this.btnClose.Location = new Point(495, 4);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(159, 51);
      this.btnClose.TabIndex = 21;
      this.btnClose.Text = "       &Close";
      this.btnClose.TextAlign = ContentAlignment.MiddleRight;
      this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Dock = DockStyle.Top;
      this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(658, 66);
      this.panel2.TabIndex = 0;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.btnClose);
      this.panel1.Controls.Add((Control) this.btnDelete);
      this.panel1.Controls.Add((Control) this.btnAdd);
      this.panel1.Controls.Add((Control) this.btnEdit);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 573);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(658, 60);
      this.panel1.TabIndex = 24;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridView1.Location = new Point(0, 65);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(658, 510);
      this.dataGridView1.TabIndex = 0;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.managePermissionsToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(184, 26);
      this.managePermissionsToolStripMenuItem.Name = "managePermissionsToolStripMenuItem";
      this.managePermissionsToolStripMenuItem.Size = new Size(183, 22);
      this.managePermissionsToolStripMenuItem.Text = "Manage Permissions";
      this.managePermissionsToolStripMenuItem.Click += new EventHandler(this.managePermissionsToolStripMenuItem_Click);
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.WhiteSmoke;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(658, 633);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panel2);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.Name = nameof (Form_Login_Details);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Login Details";
      this.Load += new EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
