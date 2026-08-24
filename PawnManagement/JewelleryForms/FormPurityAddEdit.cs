

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
  public class FormPurityAddEdit : Form
  {
    private string formType = "";
    private string Purity = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxPurity;
    private TextBox tbxPurityLabel;
    private Label label4;
    private Label label3;
    private Label label2;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private TextBox tbxMelting;
    private Label label6;
    private Panel panel1;
    private Label lblHeading;
    private ComboBox cbMetal;

    public FormPurityAddEdit() => this.InitializeComponent();

    private void FormPurityAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable basedOnThisColumn = PurityMasterClass.getAllTheRecordsBasedOnThisColumn("Purity", this.Purity);
        if (basedOnThisColumn != null && basedOnThisColumn.Rows.Count > 0)
        {
          this.tbxPurity.Text = this.Purity;
          this.cbMetal.Text = basedOnThisColumn.Rows[0]["Metal"].ToString();
          this.tbxPurityLabel.Text = basedOnThisColumn.Rows[0]["PurityLabel"].ToString();
          this.tbxMelting.Text = basedOnThisColumn.Rows[0]["Melting"].ToString();
          ((Control) this.btnSave).Text = "&UPDATE";
          this.lblHeading.Text = "EDIT";
          this.tbxPurity.Enabled = false;
        }
      }
      else
        ((Control) this.btnSave).Enabled = false;
      List<string> stringList = new List<string>();
      this.cbMetal.Items.AddRange((object[]) MetalMaster.getAllTheMetals().ToArray());
    }

    public FormPurityAddEdit(string formTYPE)
    {
      this.formType = formTYPE;
      this.InitializeComponent();
    }

    public FormPurityAddEdit(string formTYPE, string ID)
    {
      this.formType = formTYPE;
      this.Purity = ID;
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
      if (this.formType == "ADD")
      {
        if (!PurityMasterClass.checkIfPurityAlreadyExists(this.tbxPurity.Text))
        {
          PurityMasterClass.addPurity(this.cbMetal.Text, this.tbxPurity.Text, this.tbxPurityLabel.Text, double.Parse(this.tbxMelting.Text), "Y", FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
          this.Close();
        }
        else
        {
          this.tbxPurity.ForeColor = Color.Red;
          this.tbxPurity.Select();
        }
      }
      else if (this.formType == "EDIT")
      {
        PurityMasterClass.editPurity(this.cbMetal.Text, this.Purity, this.tbxPurityLabel.Text, double.Parse(this.tbxMelting.Text), "Y", FormMain.username, DateTime.Now);
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

    private void cbMetal_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbMetal.Items.Contains((object) this.cbMetal.Text))
        return;
      this.cbMetal.Select();
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.cbMetal.Text.Trim() != "" && this.cbMetal.Items.Contains((object) this.cbMetal.Text))
      {
        if (this.tbxPurity.Text.Trim() != "")
        {
          if (this.tbxPurityLabel.Text.Trim() != "")
          {
            if (this.tbxMelting.Text.Trim() != "" && this.tbxMelting.Text != "" && double.Parse(this.tbxMelting.Text) >= 0.0)
              return true;
            this.tbxMelting.Select();
            return false;
          }
          this.tbxPurityLabel.Select();
          return false;
        }
        this.tbxPurity.Select();
        return false;
      }
      this.cbMetal.Select();
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
      this.tbxPurity = new TextBox();
      this.tbxPurityLabel = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.cbMetal = new ComboBox();
      this.tbxMelting = new TextBox();
      this.label6 = new Label();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxPurity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxPurity.Location = new Point(182, 49);
      this.tbxPurity.MaxLength = 50;
      this.tbxPurity.Name = "tbxPurity";
      this.tbxPurity.Size = new Size(239, 31);
      this.tbxPurity.TabIndex = 1;
      this.tbxPurityLabel.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxPurityLabel.Location = new Point(182, 83);
      this.tbxPurityLabel.MaxLength = 50;
      this.tbxPurityLabel.Name = "tbxPurityLabel";
      this.tbxPurityLabel.Size = new Size(239, 31);
      this.tbxPurityLabel.TabIndex = 2;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(5, 87);
      this.label4.Name = "label4";
      this.label4.Size = new Size(173, 25);
      this.label4.TabIndex = 6;
      this.label4.Text = "PURITY LABEL";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(83, 52);
      this.label3.Name = "label3";
      this.label3.Size = new Size(95, 25);
      this.label3.TabIndex = 5;
      this.label3.Text = "PURITY";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(90, 17);
      this.label2.Name = "label2";
      this.label2.Size = new Size(88, 25);
      this.label2.TabIndex = 4;
      this.label2.Text = "METAL";
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
      this.panel3.Location = new Point(6, 200);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 37);
      this.panel3.TabIndex = 5;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbMetal);
      this.panel2.Controls.Add((Control) this.tbxMelting);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.tbxPurity);
      this.panel2.Controls.Add((Control) this.tbxPurityLabel);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Location = new Point(6, 38);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 164);
      this.panel2.TabIndex = 1;
      this.cbMetal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cbMetal.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbMetal.BackColor = Color.White;
      this.cbMetal.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMetal.FormattingEnabled = true;
      this.cbMetal.Location = new Point(182, 11);
      this.cbMetal.Name = "cbMetal";
      this.cbMetal.Size = new Size(239, 32);
      this.cbMetal.TabIndex = 0;
      this.cbMetal.Validating += new CancelEventHandler(this.cbMetal_Validating);
      this.tbxMelting.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxMelting.Location = new Point(182, 117);
      this.tbxMelting.MaxLength = 50;
      this.tbxMelting.Name = "tbxMelting";
      this.tbxMelting.Size = new Size(239, 31);
      this.tbxMelting.TabIndex = 3;
      this.tbxMelting.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(66, 118);
      this.label6.Name = "label6";
      this.label6.Size = new Size(112, 25);
      this.label6.TabIndex = 7;
      this.label6.Text = "MELTING";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(6, 5);
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
      this.ClientSize = new Size(450, 243);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormPurityAddEdit);
      this.Text = "Purity Add Edit";
      this.Load += new EventHandler(this.FormPurityAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
