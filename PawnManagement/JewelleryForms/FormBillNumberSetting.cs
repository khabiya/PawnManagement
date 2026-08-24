
using Glass;
using Jewellery;
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.JewelleryForms
{
  public class FormBillNumberSetting : Form
  {
    private IContainer components = (IContainer) null;
    private Label label6;
    private TextBox tbxSerialLetter;
    private Label label1;
    private ComboBox cbSerialLetterType;
    private TextBox tbxRange;
    private Label label2;
    private GlassButton btnSave;
    private Label label3;
    private ComboBox cbShopCode;
    private Label label4;
    private ComboBox cbFormType;

    public FormBillNumberSetting() => this.InitializeComponent();

    private void cbShopCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.cbSerialLetterType.Text = "";
      this.tbxSerialLetter.Text = "";
      this.tbxRange.Text = "";
    }

    private void cbShopCode_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.cbSerialLetterType.Select();
    }

    private void cbShopCode_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbShopCode.Items.Contains((object) this.cbShopCode.Text))
        return;
      this.cbShopCode.Select();
    }

    private void FormBillNumberSetting_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      List<string> stringList = new List<string>();
      this.cbShopCode.Items.AddRange((object[]) CompanyDetailsClass.getCompanyNames().ToArray());
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

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAcceptOnlyCapitalLetters(object sender, KeyPressEventArgs e)
    {
      if (this.cbSerialLetterType.Text != "NO SERIAL LETTER")
      {
        if (this.cbSerialLetterType.Text == "SINGLE LETTER")
        {
          char keyChar = e.KeyChar;
          if (!char.IsUpper(keyChar) && keyChar != '\b')
            e.Handled = true;
          else if (this.tbxSerialLetter.Text.Length >= 1 && keyChar != '\b')
            e.Handled = true;
        }
        else
        {
          if (!(this.cbSerialLetterType.Text == "DOUBLE LETTER"))
            return;
          char keyChar = e.KeyChar;
          if (!char.IsUpper(keyChar) && keyChar != '\b')
            e.Handled = true;
          else if (this.tbxSerialLetter.Text.Length >= 2 && keyChar != '\b')
            e.Handled = true;
        }
      }
      else
      {
        if (e.KeyChar == '\b')
          return;
        e.Handled = true;
      }
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

    private void comboBoX_Enter(object sender, EventArgs e)
    {
      ComboBox comboBox = sender as ComboBox;
      comboBox.BackColor = Color.Black;
      comboBox.ForeColor = Color.Yellow;
    }

    private void comboBox_Leave(object sender, EventArgs e)
    {
      ComboBox comboBox = sender as ComboBox;
      comboBox.BackColor = Color.White;
      comboBox.ForeColor = Color.DarkBlue;
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
      int num = (int) MessageBox.Show(BillNumberSeriesClass.editBillNumberSettings(this.cbShopCode.Text, this.cbFormType.Text, this.cbSerialLetterType.Text, this.tbxSerialLetter.Text, double.Parse(this.tbxRange.Text), FormMain.username, DateTime.Now));
    }

    private bool checkIfAllTheEntriesAreMade()
    {
      if (this.cbShopCode.Text != "")
      {
        if (this.cbFormType.Text != "")
        {
          if (this.cbSerialLetterType.Text != "")
          {
            if (this.tbxRange.Text != "")
            {
              if (this.cbSerialLetterType.Text != "NO SERIAL LETTER")
              {
                if (this.tbxSerialLetter.Text != "")
                {
                  if (this.cbSerialLetterType.Text == "SINGLE LETTER")
                  {
                    if (this.tbxSerialLetter.Text.Count<char>() == 1)
                    {
                      if (double.Parse(this.tbxRange.Text) >= 10000.0)
                        return !(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER") != "") || double.Parse(this.tbxRange.Text) >= double.Parse(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER"));
                      this.tbxRange.Select();
                      return false;
                    }
                    this.tbxSerialLetter.Select();
                    return false;
                  }
                  if (this.cbSerialLetterType.Text == "DOUBLE LETTER")
                  {
                    if (this.tbxSerialLetter.Text.Count<char>() == 2)
                    {
                      if (double.Parse(this.tbxRange.Text) >= 10000.0)
                        return !(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER") != "") || double.Parse(this.tbxRange.Text) >= double.Parse(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER"));
                      this.tbxRange.Select();
                      return false;
                    }
                    this.tbxSerialLetter.Select();
                    return false;
                  }
                  this.cbSerialLetterType.Select();
                  return false;
                }
                this.tbxSerialLetter.Select();
                return false;
              }
              if (this.cbSerialLetterType.Text == "NO SERIAL LETTER")
              {
                if (this.tbxSerialLetter.Text.Count<char>() == 0)
                {
                  if (double.Parse(this.tbxRange.Text) >= 1000000.0)
                    return !(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER") != "") || double.Parse(this.tbxRange.Text) >= double.Parse(BillNumberSeriesClass.getRangeForThisCompany(this.cbShopCode.Text, "INVOICE NUMBER"));
                  this.tbxRange.Select();
                  return false;
                }
                this.tbxSerialLetter.Select();
                return false;
              }
              this.cbSerialLetterType.Select();
              return false;
            }
            this.tbxRange.Select();
            return false;
          }
          this.cbSerialLetterType.Select();
          return false;
        }
        this.cbFormType.Select();
        return false;
      }
      this.cbShopCode.Select();
      return false;
    }

    private void cbFormType_SelectedIndexChanged(object sender, EventArgs e)
    {
      DataTable basedOnThisColumn = BillNumberSeriesClass.getAllTheRecordsBasedOnThisColumn("CompanyCode", "FormType", this.cbShopCode.Text, this.cbFormType.Text);
      if (basedOnThisColumn == null || basedOnThisColumn.Rows.Count <= 0)
        return;
      if (basedOnThisColumn.Rows[0]["SerialType"] != null && basedOnThisColumn.Rows[0]["serialType"].ToString() != "")
      {
        DataTable completeSalesTable = SalesClass.getCompleteSalesTable("BillNumber", this.cbShopCode.Text);
        if (completeSalesTable != null && completeSalesTable.Rows.Count > 0)
          this.cbSerialLetterType.Enabled = false;
      }
      this.cbSerialLetterType.Text = basedOnThisColumn.Rows[0]["SerialType"].ToString();
      this.tbxSerialLetter.Text = basedOnThisColumn.Rows[0]["SerialLetter"].ToString();
      this.tbxRange.Text = basedOnThisColumn.Rows[0]["Range"].ToString();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label6 = new Label();
      this.tbxSerialLetter = new TextBox();
      this.label1 = new Label();
      this.cbSerialLetterType = new ComboBox();
      this.tbxRange = new TextBox();
      this.label2 = new Label();
      this.btnSave = new GlassButton();
      this.label3 = new Label();
      this.cbShopCode = new ComboBox();
      this.label4 = new Label();
      this.cbFormType = new ComboBox();
      this.SuspendLayout();
      this.label6.AutoSize = true;
      this.label6.Location = new Point(46, 108);
      this.label6.Name = "label6";
      this.label6.Size = new Size(90, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "SERIAL LETTER";
      this.tbxSerialLetter.CharacterCasing = CharacterCasing.Upper;
      this.tbxSerialLetter.Location = new Point(141, 104);
      this.tbxSerialLetter.MaxLength = 2;
      this.tbxSerialLetter.Name = "tbxSerialLetter";
      this.tbxSerialLetter.Size = new Size(121, 20);
      this.tbxSerialLetter.TabIndex = 3;
      this.tbxSerialLetter.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyCapitalLetters);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(11, 132);
      this.label1.Name = "label1";
      this.label1.Size = new Size(125, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "BILL MAXIMUM RANGE";
      this.cbSerialLetterType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbSerialLetterType.FlatStyle = FlatStyle.System;
      this.cbSerialLetterType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbSerialLetterType.FormattingEnabled = true;
      this.cbSerialLetterType.ItemHeight = 16;
      this.cbSerialLetterType.Items.AddRange(new object[3]
      {
        (object) "NO SERIAL LETTER",
        (object) "SINGLE LETTER",
        (object) "DOUBLE LETTER"
      });
      this.cbSerialLetterType.Location = new Point(141, 73);
      this.cbSerialLetterType.Name = "cbSerialLetterType";
      this.cbSerialLetterType.Size = new Size(121, 24);
      this.cbSerialLetterType.TabIndex = 2;
      this.tbxRange.Location = new Point(141, 129);
      this.tbxRange.MaxLength = 8;
      this.tbxRange.Name = "tbxRange";
      this.tbxRange.Size = new Size(121, 20);
      this.tbxRange.TabIndex = 4;
      this.tbxRange.KeyPress += new KeyPressEventHandler(this.tbxAcceptOnlyInteger);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(91, 78);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "SERIAL";
      this.btnSave.BackColor = Color.LightBlue;
      this.btnSave.FadeOnFocus = true;
      ((Control) this.btnSave).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSave.ForeColor = Color.MediumBlue;
      this.btnSave.ForeColorOnFocus = Color.Red;
      this.btnSave.ForeColorOnLeave = Color.MediumBlue;
      this.btnSave.GlowColor = Color.White;
      this.btnSave.InnerBorderColor = Color.Transparent;
      ((Control) this.btnSave).Location = new Point(141, 155);
      ((Control) this.btnSave).Name = "btnSave";
      this.btnSave.OuterBorderColor = Color.MediumSlateBlue;
      this.btnSave.ShineColor = Color.Transparent;
      ((Control) this.btnSave).Size = new Size(121, 33);
      ((Control) this.btnSave).TabIndex = 5;
      ((Control) this.btnSave).Text = "SAVE";
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(40, 18);
      this.label3.Name = "label3";
      this.label3.Size = new Size(96, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "SELECT LICENSE";
      this.cbShopCode.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cbShopCode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbShopCode.FlatStyle = FlatStyle.System;
      this.cbShopCode.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbShopCode.FormattingEnabled = true;
      this.cbShopCode.ItemHeight = 16;
      this.cbShopCode.Location = new Point(141, 12);
      this.cbShopCode.Name = "cbShopCode";
      this.cbShopCode.Size = new Size(121, 24);
      this.cbShopCode.TabIndex = 0;
      this.cbShopCode.SelectedIndexChanged += new EventHandler(this.cbShopCode_SelectedIndexChanged);
      this.cbShopCode.KeyDown += new KeyEventHandler(this.cbShopCode_KeyDown);
      this.cbShopCode.Validating += new CancelEventHandler(this.cbShopCode_Validating);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(67, 47);
      this.label4.Name = "label4";
      this.label4.Size = new Size(69, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "FORM TYPE";
      this.cbFormType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbFormType.FlatStyle = FlatStyle.System;
      this.cbFormType.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbFormType.FormattingEnabled = true;
      this.cbFormType.ItemHeight = 16;
      this.cbFormType.Items.AddRange(new object[1]
      {
        (object) "INVOICE NUMBER"
      });
      this.cbFormType.Location = new Point(141, 42);
      this.cbFormType.Name = "cbFormType";
      this.cbFormType.Size = new Size(121, 24);
      this.cbFormType.TabIndex = 1;
      this.cbFormType.SelectedIndexChanged += new EventHandler(this.cbFormType_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(284, 202);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.cbFormType);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.cbShopCode);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.tbxRange);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.cbSerialLetterType);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.tbxSerialLetter);
      this.Name = nameof (FormBillNumberSetting);
      this.Text = "BILL NUMBER SETTING";
      this.Load += new EventHandler(this.FormBillNumberSetting_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
