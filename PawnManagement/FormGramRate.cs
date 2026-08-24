
using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement
{
  public class FormGramRate : Form
  {
    private string oldValues;
    private string newValues;
    private IContainer components = (IContainer) null;
    private TextBox tbxKachaRate;
    private TextBox tbxPledgeRate;
    private TextBox tbxSaleRate;
    private Label label3;
    private Label label5;
    private Label label6;
    private Label label7;
    private TextBox tbxDeduction;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private Label label8;
    private TextBox tbxDefaultPurity;
    private Panel panel3;
    private GlassButton btnSave;
    private Panel panel2;
    private ComboBox cbType;
    private Panel panel1;
    private Label lblHeading;
    private Label label1;
    private LinkLabel linkLabel1;

    public FormGramRate() => this.InitializeComponent();

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

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (this.checkIfAllTheItemsAreAdded() && GramRateClass.UpdateGramRate(this.tbxKachaRate.Text.Trim(), this.tbxPledgeRate.Text.Trim(), this.tbxSaleRate.Text.Trim(), this.tbxDeduction.Text.Trim(), this.tbxDefaultPurity.Text.Trim(), this.cbType.Text) == "Done")
      {
        int num = (int) MessageBox.Show("Successfully updated");
      }
      this.cbType.Select();
    }

    private bool checkIfAllTheItemsAreAdded()
    {
      if (this.cbType.Text != "" && this.cbType.Items.Contains((object) this.cbType.Text))
      {
        if (this.tbxKachaRate.Text != "")
        {
          if (this.tbxSaleRate.Text != "")
          {
            if (this.tbxPledgeRate.Text != "")
            {
              if (this.tbxDeduction.Text != "")
              {
                if (this.tbxDefaultPurity.Text != "")
                  return true;
                this.tbxDefaultPurity.Select();
                return false;
              }
              this.tbxDeduction.Select();
              return false;
            }
            this.tbxPledgeRate.Select();
            return false;
          }
          this.tbxSaleRate.Select();
          return false;
        }
        this.tbxKachaRate.Select();
        return false;
      }
      this.cbType.Select();
      return false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void GramRate_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.cbType.Items.Count > 0)
        this.cbType.SelectedIndex = 0;
      this.cbType.Select();
    }

    private void tbxPureRate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if (DialogResult.Yes == MessageBox.Show("Export to Excell", "Are you sure ??", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        ExportToExcel.exportToExcel(sourceControl as DataGridView, (sourceControl as DataGridView).Name, FormMain.username);
    }

    private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!(sender is ToolStripItem toolStripItem) || !(toolStripItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
      if ((sourceControl as DataGridView).AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      else
        (sourceControl as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void tbxDefaultPurity_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void cbMetalType_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbType.Items.Contains((object) this.cbType.Text))
        return;
      this.cbType.Select();
    }

    private void cbType_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.tbxKachaRate.Select();
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.cbType.Items.Contains((object) this.cbType.Text))
        return;
      DataTable recordForThisType = GramRateClass.getRecordForThisType(this.cbType.Text);
      if (recordForThisType != null && recordForThisType.Rows.Count > 0)
      {
        this.tbxKachaRate.Text = recordForThisType.Rows[0]["KachaRate"].ToString();
        this.tbxSaleRate.Text = recordForThisType.Rows[0]["SaleRate"].ToString();
        this.tbxPledgeRate.Text = recordForThisType.Rows[0]["PledgeRate"].ToString();
        this.tbxDeduction.Text = recordForThisType.Rows[0]["Deduction"].ToString();
        this.tbxDefaultPurity.Text = recordForThisType.Rows[0]["DefaultPurity"].ToString();
      }
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    private void tbxDefaultPurity_TextChanged(object sender, EventArgs e)
    {
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
      this.tbxKachaRate = new TextBox();
      this.tbxPledgeRate = new TextBox();
      this.tbxSaleRate = new TextBox();
      this.label3 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.tbxDeduction = new TextBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.label8 = new Label();
      this.tbxDefaultPurity = new TextBox();
      this.panel3 = new Panel();
      this.btnSave = new GlassButton();
      this.panel2 = new Panel();
      this.label1 = new Label();
      this.cbType = new ComboBox();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.linkLabel1 = new LinkLabel();
      this.contextMenuStrip1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxKachaRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxKachaRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxKachaRate.Location = new Point(152, 63);
      this.tbxKachaRate.Name = "tbxKachaRate";
      this.tbxKachaRate.Size = new Size(263, 31);
      this.tbxKachaRate.TabIndex = 1;
      this.tbxKachaRate.KeyPress += new KeyPressEventHandler(this.tbxPureRate_KeyPress);
      this.tbxPledgeRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPledgeRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeRate.Location = new Point(152, 100);
      this.tbxPledgeRate.Name = "tbxPledgeRate";
      this.tbxPledgeRate.Size = new Size(263, 31);
      this.tbxPledgeRate.TabIndex = 2;
      this.tbxPledgeRate.KeyPress += new KeyPressEventHandler(this.tbxPureRate_KeyPress);
      this.tbxSaleRate.BorderStyle = BorderStyle.FixedSingle;
      this.tbxSaleRate.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxSaleRate.Location = new Point(152, 137);
      this.tbxSaleRate.Name = "tbxSaleRate";
      this.tbxSaleRate.Size = new Size(263, 31);
      this.tbxSaleRate.TabIndex = 3;
      this.tbxSaleRate.KeyPress += new KeyPressEventHandler(this.tbxPureRate_KeyPress);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(39, 70);
      this.label3.Name = "label3";
      this.label3.Size = new Size(103, 16);
      this.label3.TabIndex = 7;
      this.label3.Text = "KACHA RATE";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(29, 107);
      this.label5.Name = "label5";
      this.label5.Size = new Size(113, 16);
      this.label5.TabIndex = 8;
      this.label5.Text = "PLEDGE RATE";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(51, 144);
      this.label6.Name = "label6";
      this.label6.Size = new Size(91, 16);
      this.label6.TabIndex = 9;
      this.label6.Text = "SALE RATE";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(45, 181);
      this.label7.Name = "label7";
      this.label7.Size = new Size(97, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "DEDUCTION";
      this.tbxDeduction.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDeduction.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDeduction.Location = new Point(152, 174);
      this.tbxDeduction.Name = "tbxDeduction";
      this.tbxDeduction.Size = new Size(263, 31);
      this.tbxDeduction.TabIndex = 4;
      this.tbxDeduction.KeyPress += new KeyPressEventHandler(this.tbxPureRate_KeyPress);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(151, 48);
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(150, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.exportToExcelToolStripMenuItem.Click += new EventHandler(this.exportToExcelToolStripMenuItem_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(150, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.wrapToolStripMenuItem.Click += new EventHandler(this.wrapToolStripMenuItem_Click);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(5, 218);
      this.label8.Name = "label8";
      this.label8.Size = new Size(137, 16);
      this.label8.TabIndex = 11;
      this.label8.Text = "DEFAULT PURITY";
      this.tbxDefaultPurity.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDefaultPurity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxDefaultPurity.Location = new Point(152, 211);
      this.tbxDefaultPurity.MaxLength = 3;
      this.tbxDefaultPurity.Name = "tbxDefaultPurity";
      this.tbxDefaultPurity.Size = new Size(263, 31);
      this.tbxDefaultPurity.TabIndex = 5;
      this.tbxDefaultPurity.TextChanged += new EventHandler(this.tbxDefaultPurity_TextChanged);
      this.tbxDefaultPurity.KeyPress += new KeyPressEventHandler(this.tbxDefaultPurity_KeyPress);
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnSave);
      this.panel3.Location = new Point(8, 316);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(439, 42);
      this.panel3.TabIndex = 21;
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
      ((Control) this.btnSave).Size = new Size(437, 40);
      ((Control) this.btnSave).TabIndex = 0;
      ((Control) this.btnSave).Text = "&UPDATE";
      ((Control) this.btnSave).Click += new EventHandler(this.btnUpdate_Click);
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.cbType);
      this.panel2.Controls.Add((Control) this.tbxKachaRate);
      this.panel2.Controls.Add((Control) this.tbxPledgeRate);
      this.panel2.Controls.Add((Control) this.label8);
      this.panel2.Controls.Add((Control) this.tbxSaleRate);
      this.panel2.Controls.Add((Control) this.label7);
      this.panel2.Controls.Add((Control) this.tbxDefaultPurity);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.tbxDeduction);
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Location = new Point(8, 46);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(439, 280);
      this.panel2.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(94, 32);
      this.label1.Name = "label1";
      this.label1.Size = new Size(48, 16);
      this.label1.TabIndex = 6;
      this.label1.Text = "TYPE";
      this.cbType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cbType.FormattingEnabled = true;
      this.cbType.Items.AddRange(new object[2]
      {
        (object) "GOLD",
        (object) "SILVER"
      });
      this.cbType.Location = new Point(152, 24);
      this.cbType.Name = "cbType";
      this.cbType.Size = new Size(263, 33);
      this.cbType.TabIndex = 0;
      this.cbType.SelectedIndexChanged += new EventHandler(this.cbType_SelectedIndexChanged);
      this.cbType.KeyDown += new KeyEventHandler(this.cbType_KeyDown);
      this.cbType.Validating += new CancelEventHandler(this.cbMetalType_Validating);
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(8, 13);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(439, 35);
      this.panel1.TabIndex = 0;
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(104, 5);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(234, 24);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "GRAM RATE - per gram";
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(371, 9);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(60, 13);
      this.linkLabel1.TabIndex = 2;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Close(ESC)";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(456, 370);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.Name = nameof (FormGramRate);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "GramRate";
      this.Load += new EventHandler(this.GramRate_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
