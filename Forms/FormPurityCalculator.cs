

using CustomDataGridViewNamespace;
using PawnManagement.Classes;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormPurityCalculator : Form
  {
    private int count = 0;
    public static string strInitialWeight = "";
    public static string strFinalWeight = "0";
    private IContainer components = (IContainer) null;
    private CustomDataGridView dgvPureWeightCalculator;
    private CustomDataGridView customDataGridView2;
    private Label label1;
    private DataGridViewTextBoxColumn colSerialNumber;
    private DataGridViewTextBoxColumn colPurity;
    private DataGridViewTextBoxColumn colWeight;
    private DataGridViewTextBoxColumn colPureWeight;
    private DataGridViewTextBoxColumn colSerialTotal;
    private DataGridViewComboBoxColumn colPurityTotal;
    private DataGridViewTextBoxColumn colWeightTotal;
    private DataGridViewTextBoxColumn colPureWeightTotal;

    public FormPurityCalculator() => this.InitializeComponent();

    private void FormPurityCalculator_Load(object sender, EventArgs e)
    {
    }

    private void dgvPureWeightCalculator_CellClick(object sender, DataGridViewCellEventArgs e) => ((DataGridView) this.dgvPureWeightCalculator).EditMode = DataGridViewEditMode.EditOnEnter;

    private void dgvPureWeightCalculator_EditingControlShowing(
      object sender,
      DataGridViewEditingControlShowingEventArgs e)
    {
      if (!(e.Control is DataGridViewTextBoxEditingControl))
        return;
      if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.OwningColumn.Name == "colSerialNumber")
      {
        e.Control.Text = (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex + 1).ToString();
        e.Control.Enter -= new EventHandler(this.colSerialNumber_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colSerialNumber_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colSerialNumber_Validating);
        e.Control.Enter -= new EventHandler(this.colPurity_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPUrity_Validating);
        e.Control.Enter -= new EventHandler(this.colGrossWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Enter -= new EventHandler(this.colPureWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPureWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.colGroWeight_KeyDown);
        e.Control.Enter += new EventHandler(this.colSerialNumber_Enter);
        e.Control.KeyPress += new KeyPressEventHandler(this.colSerialNumber_KeyPress);
        e.Control.Validating += new CancelEventHandler(this.colSerialNumber_Validating);
      }
      else if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.OwningColumn.Name == "colPurity")
      {
        e.Control.Enter -= new EventHandler(this.colSerialNumber_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colSerialNumber_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colSerialNumber_Validating);
        e.Control.Enter -= new EventHandler(this.colPurity_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPUrity_Validating);
        e.Control.Enter -= new EventHandler(this.colGrossWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Enter -= new EventHandler(this.colPureWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPureWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.colGroWeight_KeyDown);
        e.Control.Enter += new EventHandler(this.colPurity_Enter);
        e.Control.KeyPress += new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating += new CancelEventHandler(this.colPUrity_Validating);
      }
      else if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.OwningColumn.Name == "colWeight")
      {
        e.Control.Enter -= new EventHandler(this.colSerialNumber_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colSerialNumber_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colSerialNumber_Validating);
        e.Control.Enter -= new EventHandler(this.colPurity_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPUrity_Validating);
        e.Control.Enter -= new EventHandler(this.colGrossWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Enter -= new EventHandler(this.colPureWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPureWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.colGroWeight_KeyDown);
        e.Control.Enter += new EventHandler(this.colGrossWeight_Enter);
        e.Control.KeyPress += new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.KeyDown += new KeyEventHandler(this.colGroWeight_KeyDown);
        e.Control.Validating += new CancelEventHandler(this.colGrossWeight_Validating);
      }
      else if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.OwningColumn.Name == "colPureWeight")
      {
        e.Control.Enter -= new EventHandler(this.colSerialNumber_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colSerialNumber_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colSerialNumber_Validating);
        e.Control.Enter -= new EventHandler(this.colPurity_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPurity_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPUrity_Validating);
        e.Control.Enter -= new EventHandler(this.colGrossWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colGrossWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colGrossWeight_Validating);
        e.Control.Enter -= new EventHandler(this.colPureWeight_Enter);
        e.Control.KeyPress -= new KeyPressEventHandler(this.colPureWeight_KeyPress);
        e.Control.Validating -= new CancelEventHandler(this.colPureWeight_Validating);
        e.Control.KeyDown -= new KeyEventHandler(this.colGroWeight_KeyDown);
        e.Control.Enter += new EventHandler(this.colPureWeight_Enter);
        e.Control.KeyPress += new KeyPressEventHandler(this.colPureWeight_KeyPress);
        e.Control.Validating += new CancelEventHandler(this.colPureWeight_Validating);
      }
    }

    private void colGroWeight_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void colSerialNumber_Enter(object sender, EventArgs e)
    {
    }

    private void colSerialNumber_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void colSerialNumber_Validating(object sender, CancelEventArgs e)
    {
      ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex + 1).ToString();
      ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.White;
      ((DataGridView) this.dgvPureWeightCalculator).CommitEdit(DataGridViewDataErrorContexts.Commit);
      if (this.dgvPureWeightCalculator != null && ((DataGridView) this.dgvPureWeightCalculator).Rows.Count > 0)
      {
        int index = ((DataGridView) this.dgvPureWeightCalculator).CurrentRow.Index;
        if (index == 0 && ((((DataGridView) this.dgvPureWeightCalculator).Rows[index].Cells["colWeight"].Value == null ? 1 : 0) | (((DataGridView) this.dgvPureWeightCalculator).Rows[index].Cells["colWeight"].Value == null ? 0 : (((DataGridView) this.dgvPureWeightCalculator).Rows[index].Cells["colWeight"].Value.ToString() == "" ? 1 : 0))) != 0)
          ((DataGridView) this.dgvPureWeightCalculator).Rows[index].Cells["colWeight"].Value = (object) FormPurityCalculator.strInitialWeight;
      }
      ((DataGridView) this.dgvPureWeightCalculator).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void colGrossWeight_Enter(object sender, EventArgs e)
    {
    }

    private void colGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void colGrossWeight_Validating(object sender, CancelEventArgs e)
    {
      if (((((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colWeight"].Value == null ? 1 : 0) | (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colWeight"].Value == null ? 0 : (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colWeight"].Value.ToString() == "" | FormPurityCalculator.stringContainALetter(((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colWeight"].Value.ToString()) ? 1 : 0))) != 0)
      {
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) "0";
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.Red;
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell = ((DataGridView) this.dgvPureWeightCalculator)[2, ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex];
      }
      else if (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colWeight"].Value.ToString() == "0")
      {
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.Red;
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell = ((DataGridView) this.dgvPureWeightCalculator)[2, ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex];
      }
      else
      {
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) Math.Round(double.Parse(((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString()), 3);
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) StringFunctionsClass.appendZeroes(((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString());
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.White;
      }
      this.changePureWeight();
      this.changeGrandTotal();
    }

    private void colPurity_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (!char.IsDigit(keyChar) && keyChar != '\b' && keyChar != '.')
        e.Handled = true;
      if (e.KeyChar != '.' || (sender as TextBox).Text.IndexOf('.') <= -1)
        return;
      e.Handled = true;
    }

    private void colPurity_Enter(object sender, EventArgs e)
    {
    }

    private void colPUrity_Validating(object sender, CancelEventArgs e)
    {
      if (((((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colPurity"].Value == null ? 1 : 0) | (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colPurity"].Value == null ? 0 : (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colPurity"].Value.ToString() == "" | FormPurityCalculator.stringContainALetter(((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colPurity"].Value.ToString()) ? 1 : 0))) != 0)
      {
        if ((sender as TextBox).Text == "")
        {
          if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex == 0)
            ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) "91";
          else
            ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) GramRateClass.getDefaultPurity("GOLD");
          ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.White;
        }
      }
      else if (((DataGridView) this.dgvPureWeightCalculator).Rows[((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex].Cells["colPurity"].Value.ToString() == "0")
      {
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.Red;
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell = ((DataGridView) this.dgvPureWeightCalculator)[1, ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex];
      }
      else
      {
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) Math.Round(double.Parse(((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString()), 3);
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value = (object) StringFunctionsClass.appendZeroes(((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString());
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.White;
      }
      ((DataGridView) this.dgvPureWeightCalculator).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void colPureWeight_Enter(object sender, EventArgs e)
    {
      this.changePureWeight();
      this.changeGrandTotal();
      ((DataGridView) this.dgvPureWeightCalculator).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void colPureWeight_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void colPureWeight_Validating(object sender, CancelEventArgs e)
    {
      if (((((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value == null ? 1 : 0) | (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value == null ? 0 : (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString().Trim() == "" ? 1 : 0))) != 0)
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.Red;
      else if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString() == "0" | double.Parse(((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Value.ToString()) == 0.0)
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.Red;
      else
        ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.White;
    }

    private void changePureWeight()
    {
      int rowIndex = ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.RowIndex;
      if (((DataGridView) this.dgvPureWeightCalculator).Rows[rowIndex].Cells["colWeight"].Value == null || ((DataGridView) this.dgvPureWeightCalculator).Rows[rowIndex].Cells["colpURITY"].Value == null)
        return;
      ((DataGridView) this.dgvPureWeightCalculator).Rows[rowIndex].Cells["colPureWeight"].Value = (object) Math.Round(double.Parse(((DataGridView) this.dgvPureWeightCalculator).Rows[rowIndex].Cells["colWeight"].Value.ToString()) * double.Parse(((DataGridView) this.dgvPureWeightCalculator).Rows[rowIndex].Cells["colPurity"].Value.ToString()) / 100.0, 3).ToString();
    }

    private void changeGrandTotal()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      foreach (DataGridViewRow row in (IEnumerable) ((DataGridView) this.dgvPureWeightCalculator).Rows)
      {
        if (((row.Cells["colPureWeight"].Value == null ? 1 : 0) | (row.Cells["colPureWeight"].Value == null ? 0 : (row.Cells["colPureWeight"].Value.ToString().Trim() == "" ? 1 : 0))) == 0)
          num1 += double.Parse(row.Cells["colPureWeight"].Value.ToString());
        if (((row.Cells["colWeight"].Value == null ? 1 : 0) | (row.Cells["colWeight"].Value == null ? 0 : (row.Cells["colWeight"].Value.ToString().Trim() == "" ? 1 : 0))) == 0)
          num2 += double.Parse(row.Cells["colweight"].Value.ToString());
      }
      if (((DataGridView) this.customDataGridView2).Rows.Count < 1)
        ((DataGridView) this.customDataGridView2).Rows.Add();
      ((DataGridView) this.customDataGridView2).Rows[0].Cells["colWeightTotal"].Value = (object) num2.ToString();
      ((DataGridView) this.customDataGridView2).Rows[0].Cells["colPureWeightTotal"].Value = (object) (FormPurityCalculator.strFinalWeight = num1.ToString());
    }

    private void dgvPureWeightCalculator_Enter(object sender, EventArgs e)
    {
      if (((DataGridView) this.dgvPureWeightCalculator).Rows.Count < 1)
        ((DataGridView) this.dgvPureWeightCalculator).Rows.Add();
      ((DataGridView) this.dgvPureWeightCalculator).EditMode = DataGridViewEditMode.EditOnEnter;
    }

    public static bool stringContainALetter(string s)
    {
      foreach (char c in s)
      {
        if (char.IsLetter(c))
          return true;
      }
      return false;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void glassButton1_Click(object sender, EventArgs e) => ((DataGridView) this.dgvPureWeightCalculator).Rows.Add();

    private void button1_Click(object sender, EventArgs e) => ((Control) this.dgvPureWeightCalculator).Select();

    private void dgvPureWeightCalculator_CurrentCellChanged(object sender, EventArgs e)
    {
      if (((DataGridView) this.dgvPureWeightCalculator).CurrentCell == null)
        return;
      ((DataGridView) this.dgvPureWeightCalculator).CurrentCell.Style.BackColor = Color.PapayaWhip;
    }

    private void FormPurityCalculator_FormClosing(object sender, FormClosingEventArgs e)
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
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      this.label1 = new Label();
      this.dgvPureWeightCalculator = new CustomDataGridView();
      this.colSerialNumber = new DataGridViewTextBoxColumn();
      this.colPurity = new DataGridViewTextBoxColumn();
      this.colWeight = new DataGridViewTextBoxColumn();
      this.colPureWeight = new DataGridViewTextBoxColumn();
      this.customDataGridView2 = new CustomDataGridView();
      this.colSerialTotal = new DataGridViewTextBoxColumn();
      this.colPurityTotal = new DataGridViewComboBoxColumn();
      this.colWeightTotal = new DataGridViewTextBoxColumn();
      this.colPureWeightTotal = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dgvPureWeightCalculator).BeginInit();
      ((ISupportInitialize) this.customDataGridView2).BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(177, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(306, 31);
      this.label1.TabIndex = 2;
      this.label1.Text = "PURITY CALCULATOR";
      ((DataGridView) this.dgvPureWeightCalculator).AllowUserToAddRows = false;
      ((DataGridView) this.dgvPureWeightCalculator).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      ((DataGridView) this.dgvPureWeightCalculator).BorderStyle = BorderStyle.None;
      ((DataGridView) this.dgvPureWeightCalculator).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = SystemColors.ControlDark;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      ((DataGridView) this.dgvPureWeightCalculator).ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      ((DataGridView) this.dgvPureWeightCalculator).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      ((DataGridView) this.dgvPureWeightCalculator).Columns.AddRange((DataGridViewColumn) this.colSerialNumber, (DataGridViewColumn) this.colPurity, (DataGridViewColumn) this.colWeight, (DataGridViewColumn) this.colPureWeight);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      ((DataGridView) this.dgvPureWeightCalculator).DefaultCellStyle = gridViewCellStyle2;
      ((DataGridView) this.dgvPureWeightCalculator).EditMode = DataGridViewEditMode.EditOnEnter;
      ((DataGridView) this.dgvPureWeightCalculator).GridColor = SystemColors.Control;
      ((Control) this.dgvPureWeightCalculator).Location = new Point(5, 43);
      ((Control) this.dgvPureWeightCalculator).Name = "dgvPureWeightCalculator";
      ((DataGridView) this.dgvPureWeightCalculator).RowHeadersVisible = false;
      ((Control) this.dgvPureWeightCalculator).Size = new Size(629, 229);
      ((Control) this.dgvPureWeightCalculator).TabIndex = 0;
      ((DataGridView) this.dgvPureWeightCalculator).CellClick += new DataGridViewCellEventHandler(this.dgvPureWeightCalculator_CellClick);
      ((DataGridView) this.dgvPureWeightCalculator).CurrentCellChanged += new EventHandler(this.dgvPureWeightCalculator_CurrentCellChanged);
      ((DataGridView) this.dgvPureWeightCalculator).EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvPureWeightCalculator_EditingControlShowing);
      ((Control) this.dgvPureWeightCalculator).Enter += new EventHandler(this.dgvPureWeightCalculator_Enter);
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.colSerialNumber.DefaultCellStyle = gridViewCellStyle3;
      this.colSerialNumber.FillWeight = 20f;
      this.colSerialNumber.HeaderText = "SLNO";
      this.colSerialNumber.Name = "colSerialNumber";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colPurity.DefaultCellStyle = gridViewCellStyle4;
      this.colPurity.FillWeight = 20f;
      this.colPurity.HeaderText = "PURITY";
      this.colPurity.Name = "colPurity";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colWeight.DefaultCellStyle = gridViewCellStyle5;
      this.colWeight.FillWeight = 30f;
      this.colWeight.HeaderText = "WEIGHT";
      this.colWeight.Name = "colWeight";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colPureWeight.DefaultCellStyle = gridViewCellStyle6;
      this.colPureWeight.FillWeight = 30f;
      this.colPureWeight.HeaderText = "PUREWEIGHT";
      this.colPureWeight.Name = "colPureWeight";
      ((DataGridView) this.customDataGridView2).AllowUserToAddRows = false;
      ((DataGridView) this.customDataGridView2).AllowUserToDeleteRows = false;
      ((Control) this.customDataGridView2).Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((DataGridView) this.customDataGridView2).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      ((DataGridView) this.customDataGridView2).BackgroundColor = SystemColors.Control;
      ((DataGridView) this.customDataGridView2).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      ((DataGridView) this.customDataGridView2).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      ((DataGridView) this.customDataGridView2).ColumnHeadersVisible = false;
      ((DataGridView) this.customDataGridView2).Columns.AddRange((DataGridViewColumn) this.colSerialTotal, (DataGridViewColumn) this.colPurityTotal, (DataGridViewColumn) this.colWeightTotal, (DataGridViewColumn) this.colPureWeightTotal);
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle7.BackColor = SystemColors.Window;
      gridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = SystemColors.ControlText;
      gridViewCellStyle7.SelectionBackColor = SystemColors.ControlLightLight;
      gridViewCellStyle7.SelectionForeColor = SystemColors.Desktop;
      gridViewCellStyle7.WrapMode = DataGridViewTriState.False;
      ((DataGridView) this.customDataGridView2).DefaultCellStyle = gridViewCellStyle7;
      ((DataGridView) this.customDataGridView2).EditMode = DataGridViewEditMode.EditOnEnter;
      ((Control) this.customDataGridView2).Location = new Point(5, 272);
      ((Control) this.customDataGridView2).Name = "customDataGridView2";
      ((DataGridView) this.customDataGridView2).ReadOnly = true;
      ((DataGridView) this.customDataGridView2).RowHeadersVisible = false;
      ((DataGridView) this.customDataGridView2).RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      ((DataGridView) this.customDataGridView2).RowTemplate.Height = 35;
      ((DataGridView) this.customDataGridView2).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      ((Control) this.customDataGridView2).Size = new Size(629, 40);
      ((Control) this.customDataGridView2).TabIndex = 1;
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.colSerialTotal.DefaultCellStyle = gridViewCellStyle8;
      this.colSerialTotal.FillWeight = 20f;
      this.colSerialTotal.HeaderText = "Sl.No";
      this.colSerialTotal.Name = "colSerialTotal";
      this.colSerialTotal.ReadOnly = true;
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.colPurityTotal.DefaultCellStyle = gridViewCellStyle9;
      this.colPurityTotal.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
      this.colPurityTotal.FillWeight = 20f;
      this.colPurityTotal.FlatStyle = FlatStyle.Flat;
      this.colPurityTotal.HeaderText = "Type";
      this.colPurityTotal.Items.AddRange((object) "1.BILL", (object) "2.JAMMA", (object) "3.KACHA", (object) "4.CHEQUE", (object) "5.KACHA RETURN", (object) "6.TAX", (object) "7.BYAAJ");
      this.colPurityTotal.Name = "colPurityTotal";
      this.colPurityTotal.ReadOnly = true;
      this.colPurityTotal.Resizable = DataGridViewTriState.True;
      this.colPurityTotal.SortMode = DataGridViewColumnSortMode.Automatic;
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colWeightTotal.DefaultCellStyle = gridViewCellStyle10;
      this.colWeightTotal.FillWeight = 30f;
      this.colWeightTotal.HeaderText = "Amount";
      this.colWeightTotal.Name = "colWeightTotal";
      this.colWeightTotal.ReadOnly = true;
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.colPureWeightTotal.DefaultCellStyle = gridViewCellStyle11;
      this.colPureWeightTotal.FillWeight = 30f;
      this.colPureWeightTotal.HeaderText = "CD";
      this.colPureWeightTotal.Name = "colPureWeightTotal";
      this.colPureWeightTotal.ReadOnly = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.DimGray;
      this.ClientSize = new Size(640, 316);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.dgvPureWeightCalculator);
      this.Controls.Add((Control) this.customDataGridView2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormPurityCalculator);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "PurityCalculator";
      this.Load += new EventHandler(this.FormPurityCalculator_Load);
      ((ISupportInitialize) this.dgvPureWeightCalculator).EndInit();
      ((ISupportInitialize) this.customDataGridView2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
