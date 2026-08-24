

using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormMemberTypesAddEdit : Form
  {
    private string FormType = "";
    private string id = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxMemberType;
    private Label label1;
    private Label label2;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private ComboBox cbMemberId;
    private Panel panel1;
    private Label lblHeading;

    public FormMemberTypesAddEdit() => this.InitializeComponent();

    public FormMemberTypesAddEdit(string FormTYPE)
    {
      this.FormType = FormTYPE;
      this.InitializeComponent();
    }

    public FormMemberTypesAddEdit(string FormTYPE, string ID)
    {
      this.FormType = FormTYPE;
      this.id = ID;
      this.InitializeComponent();
    }

    private void FormMemberTypesAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.FormType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
        this.cbMemberId.Text = MemberTypesMasterClass.getMaxMemberId().ToString();
      }
      else if (this.FormType == "EDIT")
      {
        DataTable dataTableForThisId = MemberTypesMasterClass.getMemberTypeDataTableForThisId(this.id);
        if (dataTableForThisId == null || dataTableForThisId.Rows.Count <= 0)
          return;
        this.tbxMemberType.Text = dataTableForThisId.Rows[0]["MemberType"].ToString();
        this.cbMemberId.Text = this.id;
        this.cbMemberId.Enabled = false;
        ((Control) this.btnSave).Text = "&UPDATE";
        this.lblHeading.Text = "EDIT";
      }
      else
        ((Control) this.btnSave).Enabled = false;
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
      if (!this.checkIfAllTheEntriesAreMade())
        return;
      if (this.FormType == "ADD")
      {
        MemberTypesMasterClass.addMemberType(this.cbMemberId.Text, this.tbxMemberType.Text);
        this.Close();
      }
      else if (this.FormType == "EDIT")
      {
        MemberTypesMasterClass.editMemberType(this.cbMemberId.Text, this.tbxMemberType.Text);
        this.Close();
      }
    }

    private void cbMemberId_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxMemberType.Select();
    }

    private void cbMemberId_Validating(object sender, CancelEventArgs e)
    {
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.cbMemberId.Text.Trim() != "")
      {
        if (this.tbxMemberType.Text.Trim() != "")
        {
          if (this.FormType == "ADD")
          {
            if (MemberTypesMasterClass.checkIfMemberIdAlreadyExists(this.cbMemberId.Text))
            {
              int num = (int) MessageBox.Show("Member ID already exists.Retry");
              this.cbMemberId.Select();
              return false;
            }
            if (!MemberTypesMasterClass.checkIfMemberTypeAlreadyExists(this.tbxMemberType.Text))
              return true;
            int num1 = (int) MessageBox.Show("MemberType already exists Retry");
            this.tbxMemberType.Select();
            return false;
          }
          if (!(this.FormType == "EDIT"))
            return false;
          if (!MemberTypesMasterClass.checkIfMemberTypeAlreadyExists(this.tbxMemberType.Text))
            return true;
          int num2 = (int) MessageBox.Show("MemberType already exists Retry");
          this.tbxMemberType.Select();
          return false;
        }
        this.tbxMemberType.Select();
        return false;
      }
      this.cbMemberId.Select();
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
      this.tbxMemberType = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.cbMemberId = new ComboBox();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxMemberType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMemberType.Location = new Point(197, 49);
      this.tbxMemberType.MaxLength = 7;
      this.tbxMemberType.Name = "tbxMemberType";
      this.tbxMemberType.Size = new Size(212, 31);
      this.tbxMemberType.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(69, 17);
      this.label1.Name = "label1";
      this.label1.Size = new Size(122, 25);
      this.label1.TabIndex = 6;
      this.label1.Text = "Member Id";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(41, 53);
      this.label2.Name = "label2";
      this.label2.Size = new Size(155, 25);
      this.label2.TabIndex = 7;
      this.label2.Text = "Member Type";
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
      ((Control) this.btnSave).TabIndex = 5;
      ((Control) this.btnSave).Text = "&ADD";
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnSave);
      this.panel3.Location = new Point(9, 140);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 37);
      this.panel3.TabIndex = 5;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbMemberId);
      this.panel2.Controls.Add((Control) this.tbxMemberType);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Location = new Point(9, 45);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 96);
      this.panel2.TabIndex = 4;
      this.cbMemberId.Enabled = false;
      this.cbMemberId.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbMemberId.FormattingEnabled = true;
      this.cbMemberId.Location = new Point(197, 13);
      this.cbMemberId.Name = "cbMemberId";
      this.cbMemberId.Size = new Size(212, 33);
      this.cbMemberId.TabIndex = 0;
      this.cbMemberId.KeyDown += new KeyEventHandler(this.cbMemberId_KeyDown);
      this.cbMemberId.Validating += new CancelEventHandler(this.cbMemberId_Validating);
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(9, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(439, 35);
      this.panel1.TabIndex = 3;
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
      this.ClientSize = new Size(461, 187);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormMemberTypesAddEdit);
      this.Text = nameof (FormMemberTypesAddEdit);
      this.Load += new EventHandler(this.FormMemberTypesAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
