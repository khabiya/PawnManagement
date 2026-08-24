

using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormLoginAddEdit : Form
  {
    private string formType = "";
    private string LoginId = "";
    private string Id = "";
    private IContainer components = (IContainer) null;
    private Label lblHeading;
    private Panel panel2;
    private GlassButton btnAddEdit;
    private Panel panel3;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private Panel panel1;
    private ComboBox cbMemberType;
    private TextBox tbxMemberId;
    private TextBox tbxUsername;
    private TextBox tbxPassword;
    private Label lbl_member_Type;
    private Label lbl_member_Id;
    private Label lbl_password;
    private Label lbl_username;
    private LinkLabel linkLabel1;

    public FormLoginAddEdit() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public FormLoginAddEdit(string FORMTYPE, string LOGINID, string ID)
    {
      this.formType = FORMTYPE;
      this.LoginId = LOGINID;
      this.Id = ID;
      this.InitializeComponent();
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

    private void tbxAcceptNoInput(object sender, KeyPressEventArgs e) => e.Handled = true;

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
      try
      {
        if (this.checkEntries())
        {
          if (((Control) this.btnAddEdit).Text == "&UPDATE")
          {
            if (this.tbxUsername.Text.Trim() == this.LoginId)
            {
              this.editLogin();
              this.tbxUsername.Select();
              this.tbxUsername.ReadOnly = false;
              ((Control) this.btnAddEdit).Text = "&ADD";
            }
          }
          else if (((Control) this.btnAddEdit).Text == "&ADD")
          {
            if (!LoginClass.checkIfUserNameAlreadyExists(this.tbxUsername.Text))
            {
              this.addLogin();
              this.tbxUsername.Select();
            }
            else
            {
              int num = (int) MessageBox.Show(this.tbxUsername.Text + " already taken");
              this.tbxUsername.Select();
            }
          }
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
      this.Close();
    }

    private bool checkEntries()
    {
      if (this.tbxUsername.Text != "")
      {
        if (this.tbxPassword.Text != "")
        {
          if (this.cbMemberType.Text != "" && MemberTypesMasterClass.checkIfMemberTypeAlreadyExists(this.cbMemberType.Text))
          {
            if (this.tbxMemberId.Text != "")
              return true;
            this.cbMemberType.Select();
            return false;
          }
          this.cbMemberType.Select();
          return false;
        }
        this.tbxPassword.Select();
        return false;
      }
      this.tbxUsername.Select();
      return false;
    }

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
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

    private void FormLoginAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnAddEdit).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable basedOnThisColumn = LoginClass.getAllTheRecordsBasedOnThisColumn("UserName", this.LoginId);
        if (basedOnThisColumn != null && basedOnThisColumn.Rows.Count > 0)
        {
          this.tbxUsername.Text = basedOnThisColumn.Rows[0]["UserName"].ToString();
          this.tbxUsername.Enabled = false;
          this.tbxPassword.Text = PawnManagementClass.decrypt(basedOnThisColumn.Rows[0]["Pwd"].ToString()).Substring(1);
          this.tbxMemberId.Text = PawnManagementClass.decrypt(basedOnThisColumn.Rows[0]["Pwd"].ToString())[0].ToString();
          this.cbMemberType.Text = MemberTypesMasterClass.getMemberTypeForThisId(this.tbxMemberId.Text);
          ((Control) this.btnAddEdit).Text = "&UPDATE";
          this.lblHeading.Text = "EDIT";
        }
      }
      else
        ((Control) this.btnAddEdit).Enabled = false;
      List<string> stringList = new List<string>();
      this.cbMemberType.Items.AddRange((object[]) MemberTypesMasterClass.getAllTheMemberTypes().ToArray());
    }

    private void addLogin()
    {
      string str = LoginClass.addLogin(this.tbxUsername.Text, this.tbxPassword.Text, this.tbxMemberId.Text, "N", FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
      if (str != "Done")
      {
        PawnManagementClass.InsertIntoException("form login details", str, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show(str);
      }
      this.reset();
    }

    private void reset()
    {
      this.tbxUsername.Text = string.Empty;
      this.tbxPassword.Text = string.Empty;
      this.cbMemberType.Text = string.Empty;
      this.tbxMemberId.Text = string.Empty;
    }

    private void editLogin()
    {
      string MessageAnDStackTrace = LoginClass.editLogin(this.tbxUsername.Text, this.tbxPassword.Text, this.tbxMemberId.Text, "N", FormMain.username, DateTime.Now);
      if (MessageAnDStackTrace == "Done")
      {
        int num = (int) MessageBox.Show("successfullly updated");
        this.reset();
      }
      else
      {
        PawnManagementClass.InsertIntoException("form ShopDetails.updateShopDetails", MessageAnDStackTrace, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in updating" + MessageAnDStackTrace);
      }
    }

    private void cbMemberType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddEdit).Select();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void tbxUsername_Validating(object sender, CancelEventArgs e)
    {
      if (!LoginClass.checkIfUserNameAlreadyExists(this.tbxUsername.Text))
        return;
      this.tbxUsername.Select();
      int num = (int) MessageBox.Show("UserName already Exists");
    }

    private void cbMemberType_SelectedValueChanged(object sender, EventArgs e) => this.tbxMemberId.Text = MemberTypesMasterClass.getMemberIdForThisType(this.cbMemberType.Text);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.lblHeading = new Label();
      this.panel2 = new Panel();
      this.cbMemberType = new ComboBox();
      this.tbxMemberId = new TextBox();
      this.tbxUsername = new TextBox();
      this.tbxPassword = new TextBox();
      this.lbl_member_Type = new Label();
      this.lbl_member_Id = new Label();
      this.lbl_password = new Label();
      this.lbl_username = new Label();
      this.btnAddEdit = new GlassButton();
      this.panel3 = new Panel();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.panel1 = new Panel();
      this.linkLabel1 = new LinkLabel();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(69, 5);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(275, 24);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "LOGIN DETAILS - ADD/EDIT";
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbMemberType);
      this.panel2.Controls.Add((Control) this.tbxMemberId);
      this.panel2.Controls.Add((Control) this.tbxUsername);
      this.panel2.Controls.Add((Control) this.tbxPassword);
      this.panel2.Controls.Add((Control) this.lbl_member_Type);
      this.panel2.Controls.Add((Control) this.lbl_member_Id);
      this.panel2.Controls.Add((Control) this.lbl_password);
      this.panel2.Controls.Add((Control) this.lbl_username);
      this.panel2.Location = new Point(1, 36);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 199);
      this.panel2.TabIndex = 0;
      this.cbMemberType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbMemberType.FormattingEnabled = true;
      this.cbMemberType.Location = new Point(164, 103);
      this.cbMemberType.Name = "cbMemberType";
      this.cbMemberType.Size = new Size(260, 33);
      this.cbMemberType.TabIndex = 2;
      this.cbMemberType.SelectedValueChanged += new EventHandler(this.cbMemberType_SelectedValueChanged);
      this.cbMemberType.KeyDown += new KeyEventHandler(this.cbMemberType_KeyDown);
      this.tbxMemberId.BorderStyle = BorderStyle.FixedSingle;
      this.tbxMemberId.Enabled = false;
      this.tbxMemberId.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxMemberId.Location = new Point(164, 148);
      this.tbxMemberId.Name = "tbxMemberId";
      this.tbxMemberId.Size = new Size(260, 31);
      this.tbxMemberId.TabIndex = 3;
      this.tbxMemberId.KeyPress += new KeyPressEventHandler(this.tbxAcceptNoInput);
      this.tbxUsername.BorderStyle = BorderStyle.FixedSingle;
      this.tbxUsername.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxUsername.Location = new Point(164, 14);
      this.tbxUsername.Name = "tbxUsername";
      this.tbxUsername.Size = new Size(260, 31);
      this.tbxUsername.TabIndex = 0;
      this.tbxUsername.Validating += new CancelEventHandler(this.tbxUsername_Validating);
      this.tbxPassword.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPassword.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPassword.Location = new Point(164, 57);
      this.tbxPassword.Name = "tbxPassword";
      this.tbxPassword.Size = new Size(260, 31);
      this.tbxPassword.TabIndex = 1;
      this.lbl_member_Type.AutoSize = true;
      this.lbl_member_Type.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl_member_Type.Location = new Point(12, 107);
      this.lbl_member_Type.Name = "lbl_member_Type";
      this.lbl_member_Type.Size = new Size(155, 25);
      this.lbl_member_Type.TabIndex = 7;
      this.lbl_member_Type.Text = "Member Type";
      this.lbl_member_Id.AutoSize = true;
      this.lbl_member_Id.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl_member_Id.Location = new Point(12, 152);
      this.lbl_member_Id.Name = "lbl_member_Id";
      this.lbl_member_Id.Size = new Size(122, 25);
      this.lbl_member_Id.TabIndex = 6;
      this.lbl_member_Id.Text = "Member Id";
      this.lbl_password.AutoSize = true;
      this.lbl_password.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl_password.Location = new Point(12, 57);
      this.lbl_password.Name = "lbl_password";
      this.lbl_password.Size = new Size(114, 25);
      this.lbl_password.TabIndex = 5;
      this.lbl_password.Text = "Password";
      this.lbl_username.AutoSize = true;
      this.lbl_username.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl_username.Location = new Point(12, 14);
      this.lbl_username.Name = "lbl_username";
      this.lbl_username.Size = new Size(118, 25);
      this.lbl_username.TabIndex = 4;
      this.lbl_username.Text = "Username";
      this.btnAddEdit.BackColor = Color.Gainsboro;
      ((Control) this.btnAddEdit).Dock = DockStyle.Fill;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnAddEdit.GlowColor = Color.White;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(0, 0);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.Transparent;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(437, 40);
      ((Control) this.btnAddEdit).TabIndex = 0;
      ((Control) this.btnAddEdit).Text = "&UPDATE";
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnSave_Click);
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnAddEdit);
      this.panel3.Location = new Point(1, 233);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 42);
      this.panel3.TabIndex = 24;
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(150, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(150, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(151, 48);
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(1, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(439, 35);
      this.panel1.TabIndex = 1;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(370, 9);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(60, 13);
      this.linkLabel1.TabIndex = 1;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Close(ESC)";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(443, 276);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormLoginAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormLoginAddEdit);
      this.Load += new EventHandler(this.FormLoginAddEdit_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
