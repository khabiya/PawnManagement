

using Glass;
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.JewelleryForms
{
  public class FormRateAddEdit : Form
  {
    private string formType = "";
    private string id = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxPureRate;
    private TextBox tbxKachaRate;
    private TextBox tbxBoardRate;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private ComboBox cbMetalType;
    private TextBox tbxDate;
    private Label label6;
    private Panel panel1;
    private Label lblHeading;

    public FormRateAddEdit() => this.InitializeComponent();

    public FormRateAddEdit(string formTYPE)
    {
      this.formType = formTYPE;
      this.InitializeComponent();
    }

    public FormRateAddEdit(string formTYPE, string ID)
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

    private void FormRateAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable ratesForThisId = RateClass.getRatesForThisID(this.id);
        if (ratesForThisId != null && ratesForThisId.Rows.Count > 0)
        {
          this.cbMetalType.Text = ratesForThisId.Rows[0]["MetalType"].ToString();
          this.tbxPureRate.Text = ratesForThisId.Rows[0]["PureRate"].ToString();
          this.tbxKachaRate.Text = ratesForThisId.Rows[0]["KachaRate"].ToString();
          this.tbxBoardRate.Text = ratesForThisId.Rows[0]["BoardRate"].ToString();
          this.tbxDate.Text = DateTime.Parse(ratesForThisId.Rows[0]["RateDate"].ToString()).ToString("dd/MM/yyyy");
          ((Control) this.btnSave).Text = "&UPDATE";
          this.lblHeading.Text = "EDIT";
        }
      }
      else
        ((Control) this.btnSave).Enabled = false;
      List<string> stringList = new List<string>();
      this.cbMetalType.Items.AddRange((object[]) MetalMaster.getAllTheMetals().ToArray());
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

    private void cbMetalType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxPureRate.Select();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.checkIfAllTheEntriesAreMade())
        return;
      if (this.formType == "ADD")
      {
        RateClass.addRate(this.cbMetalType.Text, double.Parse(this.tbxPureRate.Text), double.Parse(this.tbxKachaRate.Text), double.Parse(this.tbxBoardRate.Text), DateTime.Parse(this.tbxDate.Text), DateTime.Parse(this.tbxDate.Text), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
        this.Close();
      }
      else if (this.formType == "EDIT")
      {
        RateClass.editRate(this.id, this.cbMetalType.Text, double.Parse(this.tbxPureRate.Text), double.Parse(this.tbxKachaRate.Text), double.Parse(this.tbxBoardRate.Text), DateTime.Parse(this.tbxDate.Text), DateTime.Parse(this.tbxDate.Text), FormMain.username, DateTime.Now);
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
      if (this.cbMetalType.Text.Trim() != "" && this.cbMetalType.Items.Contains((object) this.cbMetalType.Text))
      {
        if (this.tbxPureRate.Text.Trim() != "")
        {
          if (this.tbxKachaRate.Text.Trim() != "")
          {
            if (this.tbxBoardRate.Text.Trim() != "")
            {
              if (this.tbxDate.Text.Trim() != "" && PawnManagementClass.checkForValidateDate(this.tbxDate.Text))
                return true;
              this.tbxDate.Select();
              return false;
            }
            this.tbxBoardRate.Select();
            return false;
          }
          this.tbxKachaRate.Select();
          return false;
        }
        this.tbxPureRate.Select();
        return false;
      }
      this.cbMetalType.Select();
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
      this.tbxPureRate = new TextBox();
      this.tbxKachaRate = new TextBox();
      this.tbxBoardRate = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.cbMetalType = new ComboBox();
      this.tbxDate = new TextBox();
      this.label6 = new Label();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxPureRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPureRate.Location = new Point(170, 49);
      this.tbxPureRate.MaxLength = 7;
      this.tbxPureRate.Name = "tbxPureRate";
      this.tbxPureRate.Size = new Size(239, 31);
      this.tbxPureRate.TabIndex = 1;
      this.tbxPureRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxKachaRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxKachaRate.Location = new Point(170, 83);
      this.tbxKachaRate.MaxLength = 7;
      this.tbxKachaRate.Name = "tbxKachaRate";
      this.tbxKachaRate.Size = new Size(239, 31);
      this.tbxKachaRate.TabIndex = 2;
      this.tbxKachaRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxBoardRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxBoardRate.Location = new Point(170, 117);
      this.tbxBoardRate.MaxLength = 7;
      this.tbxBoardRate.Name = "tbxBoardRate";
      this.tbxBoardRate.Size = new Size(239, 31);
      this.tbxBoardRate.TabIndex = 3;
      this.tbxBoardRate.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(35, 18);
      this.label1.Name = "label1";
      this.label1.Size = new Size(129, 25);
      this.label1.TabIndex = 6;
      this.label1.Text = "Metal Type";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(47, 53);
      this.label2.Name = "label2";
      this.label2.Size = new Size(117, 25);
      this.label2.TabIndex = 7;
      this.label2.Text = "Pure Rate";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(37, 88);
      this.label3.Name = "label3";
      this.label3.Size = new Size((int) sbyte.MaxValue, 25);
      this.label3.TabIndex = 8;
      this.label3.Text = "KachaRate";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(41, 123);
      this.label4.Name = "label4";
      this.label4.Size = new Size(123, 25);
      this.label4.TabIndex = 9;
      this.label4.Text = "BoardRate";
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
      this.panel3.Location = new Point(15, 240);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 37);
      this.panel3.TabIndex = 2;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbMetalType);
      this.panel2.Controls.Add((Control) this.tbxDate);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.tbxPureRate);
      this.panel2.Controls.Add((Control) this.tbxKachaRate);
      this.panel2.Controls.Add((Control) this.tbxBoardRate);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Location = new Point(15, 49);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 196);
      this.panel2.TabIndex = 1;
      this.cbMetalType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbMetalType.FormattingEnabled = true;
      this.cbMetalType.Location = new Point(170, 13);
      this.cbMetalType.Name = "cbMetalType";
      this.cbMetalType.Size = new Size(239, 33);
      this.cbMetalType.TabIndex = 0;
      this.cbMetalType.KeyDown += new KeyEventHandler(this.cbMetalType_KeyDown);
      this.tbxDate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxDate.Location = new Point(170, 151);
      this.tbxDate.MaxLength = 10;
      this.tbxDate.Name = "tbxDate";
      this.tbxDate.Size = new Size(239, 31);
      this.tbxDate.TabIndex = 4;
      this.tbxDate.KeyPress += new KeyPressEventHandler(this.tbxAccepDate_KeyPress);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(103, 158);
      this.label6.Name = "label6";
      this.label6.Size = new Size(61, 25);
      this.label6.TabIndex = 10;
      this.label6.Text = "Date";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(15, 16);
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
      this.ClientSize = new Size(475, 293);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormRateAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Rate Master - ADD or EDIT";
      this.Load += new EventHandler(this.FormRateAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
