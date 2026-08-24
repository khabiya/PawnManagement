
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
  public class FormItemTypesAddEdit : Form
  {
    private string formType = "";
    private string itemType = "";
    private IContainer components = (IContainer) null;
    private Label lblRateType;
    private Label lblItemType;
    private Label lblMetal;
    private Label lblType;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private TextBox tbxHsnCode;
    private Label lblHsnCode;
    private Panel panel1;
    private Label lblHeading;
    private TextBox tbxItemType;
    private Label label5;
    private ComboBox cbRateType;
    private ComboBox cbType;
    private ComboBox cbMetal;

    public FormItemTypesAddEdit() => this.InitializeComponent();

    public FormItemTypesAddEdit(string formTYPE)
    {
      this.formType = formTYPE;
      this.InitializeComponent();
    }

    private void FormItemTypesAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable typesBasedOnItemType = ItemTypesClass.getAllTheItemTypesBasedOnItemType(this.itemType);
        if (typesBasedOnItemType != null && typesBasedOnItemType.Rows.Count > 0)
        {
          this.tbxItemType.Text = this.itemType;
          this.tbxItemType.Enabled = false;
          this.cbType.Text = typesBasedOnItemType.Rows[0]["Type"].ToString();
          this.cbMetal.Text = typesBasedOnItemType.Rows[0]["Metal"].ToString();
          this.cbRateType.Text = typesBasedOnItemType.Rows[0]["RateType"].ToString();
          this.tbxHsnCode.Text = typesBasedOnItemType.Rows[0]["HsnCode"].ToString();
          ((Control) this.btnSave).Text = "&UPDATE";
          this.lblHeading.Text = "EDIT";
        }
      }
      else
        ((Control) this.btnSave).Enabled = false;
      List<string> stringList = new List<string>();
      this.cbMetal.Items.AddRange((object[]) MetalMaster.getAllTheMetals().ToArray());
      this.cbMetal.Items.Add((object) "NA");
    }

    public FormItemTypesAddEdit(string formTYPE, string ItemTYPE)
    {
      this.formType = formTYPE;
      this.itemType = ItemTYPE;
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

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.checkIfAllTheEntriesAreMade())
        return;
      if (this.formType == "ADD")
      {
        if (!ItemTypesClass.checkIfItemTypeAlreadyExists(this.tbxItemType.Text))
        {
          ItemTypesClass.addItemType(this.tbxItemType.Text, this.cbType.Text, this.cbMetal.Text, this.cbRateType.Text, this.tbxHsnCode.Text, FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
          this.Close();
        }
        else
          this.tbxItemType.Select();
      }
      else if (this.formType == "EDIT")
      {
        ItemTypesClass.editItemType(this.tbxItemType.Text, this.cbType.Text, this.cbMetal.Text, this.cbRateType.Text, this.tbxHsnCode.Text, FormMain.username, DateTime.Now);
        this.Close();
      }
    }

    private void tbxItemType_Validating(object sender, CancelEventArgs e)
    {
      if (ItemTypesClass.checkIfItemTypeAlreadyExists(this.tbxItemType.Text))
      {
        this.tbxItemType.Select();
        this.tbxItemType.ForeColor = Color.Red;
      }
      else
        this.tbxItemType.ForeColor = Color.Blue;
    }

    private void label5_Click(object sender, EventArgs e) => this.Close();

    private void cbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbType.Text == "MRP")
        this.cbRateType.Text = "MRP";
      else
        this.cbRateType.Text = "PER GRAM";
    }

    private void cbType_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbType.Items.Contains((object) this.cbType.Text))
        return;
      this.cbType.Select();
    }

    private void cbMetal_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbMetal.Items.Contains((object) this.cbMetal.Text))
        return;
      this.cbMetal.Select();
    }

    private void cbRateType_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbRateType.Items.Contains((object) this.cbRateType.Text))
        return;
      this.cbRateType.Select();
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.tbxItemType.Text.Trim() != "")
      {
        this.lblItemType.ForeColor = Color.Black;
        if (this.cbType.Text.Trim() != "" && this.cbType.Items.Contains((object) this.cbType.Text))
        {
          this.lblType.ForeColor = Color.Black;
          if (this.cbMetal.Text.Trim() != "" && this.cbMetal.Items.Contains((object) this.cbMetal.Text))
          {
            this.lblMetal.ForeColor = Color.Black;
            if (this.cbRateType.Text.Trim() != "" && this.cbRateType.Items.Contains((object) this.cbRateType.Text))
            {
              this.lblRateType.ForeColor = Color.Black;
              if (this.tbxHsnCode.Text.Trim() != "")
              {
                this.lblHsnCode.ForeColor = Color.Black;
                return true;
              }
              this.tbxHsnCode.Select();
              this.lblHsnCode.ForeColor = Color.Red;
              return false;
            }
            this.cbRateType.Select();
            this.lblRateType.ForeColor = Color.Red;
            return false;
          }
          this.cbMetal.Select();
          this.lblMetal.ForeColor = Color.Red;
          return false;
        }
        this.cbType.Select();
        this.lblType.ForeColor = Color.Red;
        return false;
      }
      this.tbxItemType.Select();
      this.lblItemType.ForeColor = Color.Red;
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
      this.lblRateType = new Label();
      this.lblItemType = new Label();
      this.lblMetal = new Label();
      this.lblType = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.cbMetal = new ComboBox();
      this.cbRateType = new ComboBox();
      this.cbType = new ComboBox();
      this.tbxItemType = new TextBox();
      this.tbxHsnCode = new TextBox();
      this.lblHsnCode = new Label();
      this.panel1 = new Panel();
      this.label5 = new Label();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.lblRateType.AutoSize = true;
      this.lblRateType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.lblRateType.ForeColor = Color.Black;
      this.lblRateType.Location = new Point(23, 121);
      this.lblRateType.Name = "lblRateType";
      this.lblRateType.Size = new Size(139, 25);
      this.lblRateType.TabIndex = 8;
      this.lblRateType.Text = "RATE TYPE";
      this.lblItemType.AutoSize = true;
      this.lblItemType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.lblItemType.ForeColor = Color.Black;
      this.lblItemType.Location = new Point(29, 16);
      this.lblItemType.Name = "lblItemType";
      this.lblItemType.Size = new Size(133, 25);
      this.lblItemType.TabIndex = 5;
      this.lblItemType.Text = "ITEM TYPE";
      this.lblMetal.AutoSize = true;
      this.lblMetal.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.lblMetal.ForeColor = Color.Black;
      this.lblMetal.Location = new Point(74, 86);
      this.lblMetal.Name = "lblMetal";
      this.lblMetal.Size = new Size(88, 25);
      this.lblMetal.TabIndex = 7;
      this.lblMetal.Text = "METAL";
      this.lblType.AutoSize = true;
      this.lblType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.lblType.ForeColor = Color.Black;
      this.lblType.Location = new Point(90, 52);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(72, 25);
      this.lblType.TabIndex = 6;
      this.lblType.Text = "TYPE";
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
      this.panel3.Location = new Point(40, 250);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 37);
      this.panel3.TabIndex = 5;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.cbMetal);
      this.panel2.Controls.Add((Control) this.cbRateType);
      this.panel2.Controls.Add((Control) this.cbType);
      this.panel2.Controls.Add((Control) this.tbxItemType);
      this.panel2.Controls.Add((Control) this.tbxHsnCode);
      this.panel2.Controls.Add((Control) this.lblHsnCode);
      this.panel2.Controls.Add((Control) this.lblRateType);
      this.panel2.Controls.Add((Control) this.lblItemType);
      this.panel2.Controls.Add((Control) this.lblMetal);
      this.panel2.Controls.Add((Control) this.lblType);
      this.panel2.Location = new Point(40, 59);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 196);
      this.panel2.TabIndex = 0;
      this.cbMetal.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMetal.FormattingEnabled = true;
      this.cbMetal.Location = new Point(170, 82);
      this.cbMetal.Name = "cbMetal";
      this.cbMetal.Size = new Size(239, 32);
      this.cbMetal.TabIndex = 2;
      this.cbMetal.Validating += new CancelEventHandler(this.cbMetal_Validating);
      this.cbRateType.Enabled = false;
      this.cbRateType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbRateType.FormattingEnabled = true;
      this.cbRateType.Items.AddRange(new object[2]
      {
        (object) "PER GRAM",
        (object) "MRP"
      });
      this.cbRateType.Location = new Point(170, 117);
      this.cbRateType.Name = "cbRateType";
      this.cbRateType.Size = new Size(239, 32);
      this.cbRateType.TabIndex = 3;
      this.cbRateType.Validating += new CancelEventHandler(this.cbRateType_Validating);
      this.cbType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[3]
      {
        (object) "LIVE RATE",
        (object) "PER GRAM",
        (object) "MRP"
      });
      this.cbType.Location = new Point(170, 47);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(239, 32);
      this.cbType.TabIndex = 1;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
      this.cbType.Validating += new CancelEventHandler(this.cbType_Validating);
      this.tbxItemType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxItemType.Location = new Point(170, 12);
      this.tbxItemType.MaxLength = 50;
      this.tbxItemType.Name = "tbxItemType";
      this.tbxItemType.Size = new Size(239, 31);
      this.tbxItemType.TabIndex = 0;
      this.tbxItemType.Validating += new CancelEventHandler(this.tbxItemType_Validating);
      this.tbxHsnCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxHsnCode.Location = new Point(170, 151);
      this.tbxHsnCode.MaxLength = 10;
      this.tbxHsnCode.Name = "tbxHsnCode";
      this.tbxHsnCode.Size = new Size(239, 31);
      this.tbxHsnCode.TabIndex = 4;
      this.lblHsnCode.AutoSize = true;
      this.lblHsnCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.lblHsnCode.ForeColor = Color.Black;
      this.lblHsnCode.Location = new Point(32, 155);
      this.lblHsnCode.Name = "lblHsnCode";
      this.lblHsnCode.Size = new Size(130, 25);
      this.lblHsnCode.TabIndex = 9;
      this.lblHsnCode.Text = "HSN CODE";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(40, 26);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(439, 35);
      this.panel1.TabIndex = 1;
      this.label5.Anchor = AnchorStyles.Top;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(371, 4);
      this.label5.Name = "label5";
      this.label5.Size = new Size(63, 24);
      this.label5.TabIndex = 1;
      this.label5.Text = "&Close";
      this.label5.Click += new EventHandler(this.label5_Click);
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
      this.ClientSize = new Size(519, 322);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormItemTypesAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Item Types Add Edit";
      this.Load += new EventHandler(this.FormItemTypesAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
