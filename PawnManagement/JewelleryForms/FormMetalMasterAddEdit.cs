
using Glass;
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.JewelleryForms
{
  public class FormMetalMasterAddEdit : Form
  {
    private string formType = "";
    private string id = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxMetal;
    private TextBox tbxShortName;
    private Label label4;
    private Label label3;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private TextBox tbxDescription;
    private Label label6;
    private Panel panel1;
    private Label lblHeading;

    private void FormMetalMasterAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable basedOnThisColumn = MetalMaster.getAllTheRecordsBasedOnThisColumn("Metal", this.id);
        if (basedOnThisColumn == null || basedOnThisColumn.Rows.Count <= 0)
          return;
        this.tbxMetal.Text = basedOnThisColumn.Rows[0]["Metal"].ToString();
        this.tbxShortName.Text = basedOnThisColumn.Rows[0]["ShortName"].ToString();
        this.tbxDescription.Text = basedOnThisColumn.Rows[0]["Description"].ToString();
        ((Control) this.btnSave).Text = "&UPDATE";
        this.lblHeading.Text = "EDIT";
        this.tbxMetal.Enabled = false;
      }
      else
        ((Control) this.btnSave).Enabled = false;
    }

    public FormMetalMasterAddEdit() => this.InitializeComponent();

    public FormMetalMasterAddEdit(string formTYPE)
    {
      this.formType = formTYPE;
      this.InitializeComponent();
    }

    public FormMetalMasterAddEdit(string formTYPE, string ID)
    {
      this.formType = formTYPE;
      this.id = ID;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

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

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
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

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (this.formType == "ADD")
      {
        if (!this.checkIfAllTheEntriesAreMade())
          return;
        if (!MetalMaster.checkIfMetalAlreadyExists(this.tbxMetal.Text))
        {
          MetalMaster.addMetalMaster(this.tbxMetal.Text, this.tbxShortName.Text, this.tbxDescription.Text, FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
          this.Close();
        }
        else
        {
          this.tbxMetal.Select();
          this.tbxMetal.ForeColor = Color.Red;
        }
      }
      else
      {
        if (!(this.formType == "EDIT") || !this.checkIfAllTheEntriesAreMade())
          return;
        MetalMaster.editMetalMaster(this.tbxMetal.Text, this.tbxShortName.Text, this.tbxDescription.Text, FormMain.username, DateTime.Now);
        this.Close();
      }
    }

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.tbxMetal.Text.Trim() != "")
      {
        if (this.tbxShortName.Text.Trim() != "")
        {
          if (this.tbxDescription.Text.Trim() != "")
            return true;
          this.tbxDescription.Select();
          return false;
        }
        this.tbxShortName.Select();
        return false;
      }
      this.tbxMetal.Select();
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
      this.tbxMetal = new TextBox();
      this.tbxShortName = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.tbxDescription = new TextBox();
      this.label6 = new Label();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxMetal.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxMetal.Location = new Point(169, 24);
      this.tbxMetal.MaxLength = 7;
      this.tbxMetal.Name = "tbxMetal";
      this.tbxMetal.Size = new Size(239, 31);
      this.tbxMetal.TabIndex = 0;
      this.tbxShortName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxShortName.Location = new Point(169, 58);
      this.tbxShortName.MaxLength = 7;
      this.tbxShortName.Name = "tbxShortName";
      this.tbxShortName.Size = new Size(239, 31);
      this.tbxShortName.TabIndex = 1;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(35, 61);
      this.label4.Name = "label4";
      this.label4.Size = new Size(128, 25);
      this.label4.TabIndex = 4;
      this.label4.Text = "ShortName";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(93, 27);
      this.label3.Name = "label3";
      this.label3.Size = new Size(70, 25);
      this.label3.TabIndex = 3;
      this.label3.Text = "Metal";
      this.btnSave.BackColor = Color.Gainsboro;
      ((Control) this.btnSave).Dock = DockStyle.Fill;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.MediumBlue;
      this.btnSave.GlowColor = Color.White;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(0, 0);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.Transparent;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(437, 35);
      ((Control) this.btnSave).TabIndex = 0;
      ((Control) this.btnSave).Text = "&ADD";
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnSave);
      this.panel3.Location = new Point(18, 188);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 37);
      this.panel3.TabIndex = 5;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.tbxDescription);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.tbxMetal);
      this.panel2.Controls.Add((Control) this.tbxShortName);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Location = new Point(18, 47);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 146);
      this.panel2.TabIndex = 1;
      this.tbxDescription.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxDescription.Location = new Point(169, 92);
      this.tbxDescription.MaxLength = 10;
      this.tbxDescription.Name = "tbxDescription";
      this.tbxDescription.Size = new Size(239, 31);
      this.tbxDescription.TabIndex = 2;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(32, 94);
      this.label6.Name = "label6";
      this.label6.Size = new Size(131, 25);
      this.label6.TabIndex = 5;
      this.label6.Text = "Description";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.Gray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(18, 14);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(439, 35);
      this.panel1.TabIndex = 0;
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(193, 5);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(52, 24);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "ADD";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(475, 249);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormMetalMasterAddEdit);
      this.Text = nameof (FormMetalMasterAddEdit);
      this.Load += new EventHandler(this.FormMetalMasterAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
