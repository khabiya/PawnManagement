

using Glass;
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormMoneyCalculator : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label lblHeading;
    private GlassButton glassButton2;
    private Panel panel3;
    private Label label12;
    private Label label11;
    private Label label10;
    private TextBox tbxTotalAmount;
    private TextBox tbxNotes;
    private TextBox tbxCoins;
    private TextBox tbx100Amount;
    private TextBox tbx5Amount;
    private TextBox tbx2Amount;
    private TextBox tbx1Amount;
    private TextBox tbx1000Amount;
    private TextBox tbx50Amount;
    private TextBox tbx20Amount;
    private TextBox tbx10Amount;
    private TextBox tbx500Amount;
    private TextBox tbx100;
    private TextBox tbx5;
    private Label label7;
    private TextBox tbx2;
    private Label label8;
    private TextBox tbx1;
    private Label label9;
    private TextBox tbx1000;
    private TextBox tbx50;
    private Label label6;
    private TextBox tbx20;
    private Label label5;
    private TextBox tbx10;
    private Label label4;
    private Label label3;
    private TextBox tbx500;
    private Label label2;
    private Label label1;
    private TextBox tbx2000Amount;
    private TextBox tbx2000;
    private Label label13;
    private TextBox tbx200Amount;
    private TextBox tbx200;
    private Label label14;

    public FormMoneyCalculator() => this.InitializeComponent();

    private void tbx100Amount_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormMoneyCalculator_Load(object sender, EventArgs e)
    {
      this.tbx2000.Select();
      this.tbx2000.Text = "0";
    }

    private void glassButton2_Click(object sender, EventArgs e) => this.Close();

    private void tbx100_TextChanged(object sender, EventArgs e) => this.calculateSum();

    private void calculateSum()
    {
      this.tbx2000Amount.Text = (double.Parse(this.tbx2000.Text.Trim() == "" ? "0" : this.tbx2000.Text) * 2000.0).ToString();
      this.tbx1000Amount.Text = (double.Parse(this.tbx1000.Text.Trim() == "" ? "0" : this.tbx1000.Text) * 1000.0).ToString();
      this.tbx500Amount.Text = (double.Parse(this.tbx500.Text.Trim() == "" ? "0" : this.tbx500.Text) * 500.0).ToString();
      this.tbx200Amount.Text = (double.Parse(this.tbx200.Text.Trim() == "" ? "0" : this.tbx200.Text) * 200.0).ToString();
      this.tbx100Amount.Text = (double.Parse(this.tbx100.Text.Trim() == "" ? "0" : this.tbx100.Text) * 100.0).ToString();
      this.tbx50Amount.Text = (double.Parse(this.tbx50.Text.Trim() == "" ? "0" : this.tbx50.Text) * 50.0).ToString();
      this.tbx20Amount.Text = (double.Parse(this.tbx20.Text.Trim() == "" ? "0" : this.tbx20.Text) * 20.0).ToString();
      this.tbx10Amount.Text = (double.Parse(this.tbx10.Text.Trim() == "" ? "0" : this.tbx10.Text) * 10.0).ToString();
      this.tbx5Amount.Text = (double.Parse(this.tbx5.Text.Trim() == "" ? "0" : this.tbx5.Text) * 5.0).ToString();
      this.tbx2Amount.Text = (double.Parse(this.tbx2.Text.Trim() == "" ? "0" : this.tbx2.Text) * 2.0).ToString();
      this.tbx1Amount.Text = (double.Parse(this.tbx1.Text.Trim() == "" ? "0" : this.tbx1.Text) * 1.0).ToString();
      this.tbxNotes.Text = (double.Parse(this.tbx2000Amount.Text) + double.Parse(this.tbx1000Amount.Text) + double.Parse(this.tbx500Amount.Text) + double.Parse(this.tbx200Amount.Text) + double.Parse(this.tbx100Amount.Text) + double.Parse(this.tbx50Amount.Text) + double.Parse(this.tbx20Amount.Text) + double.Parse(this.tbx10Amount.Text)).ToString();
      this.tbxCoins.Text = (double.Parse(this.tbx5Amount.Text) + double.Parse(this.tbx2Amount.Text) + double.Parse(this.tbx1Amount.Text)).ToString();
      this.tbxTotalAmount.Text = (double.Parse(this.tbxNotes.Text) + double.Parse(this.tbxCoins.Text)).ToString();
    }

    private void tbx1000_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Up)
      {
        this.SelectNextControl(this.ActiveControl, false, true, true, true);
      }
      else
      {
        if (e.KeyCode != Keys.Down)
          return;
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      }
    }

    private void tbx1000_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void panel3_Paint(object sender, PaintEventArgs e)
    {
    }

    private void tbx1000_KeyDown_1(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down)
        return;
      this.SelectNextControl(this.ActiveControl, true, true, true, true);
    }

    private void tbx1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Up)
        return;
      this.SelectNextControl(this.ActiveControl, false, true, true, true);
    }

    private void tbx1000_Enter(object sender, EventArgs e) => (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

    private void FormMoneyCalculator_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult.Yes == MessageBox.Show("Exit ? Are you sure", "Exit ? Are you sure", MessageBoxButtons.YesNo))
        return;
      e.Cancel = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      this.lblHeading = new Label();
      this.glassButton2 = new GlassButton();
      this.panel3 = new Panel();
      this.tbx200Amount = new TextBox();
      this.tbx200 = new TextBox();
      this.label14 = new Label();
      this.tbx2000Amount = new TextBox();
      this.tbx2000 = new TextBox();
      this.label13 = new Label();
      this.label12 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.tbxTotalAmount = new TextBox();
      this.tbxNotes = new TextBox();
      this.tbxCoins = new TextBox();
      this.tbx100Amount = new TextBox();
      this.tbx5Amount = new TextBox();
      this.tbx2Amount = new TextBox();
      this.tbx1Amount = new TextBox();
      this.tbx1000Amount = new TextBox();
      this.tbx50Amount = new TextBox();
      this.tbx20Amount = new TextBox();
      this.tbx10Amount = new TextBox();
      this.tbx500Amount = new TextBox();
      this.tbx100 = new TextBox();
      this.tbx5 = new TextBox();
      this.label7 = new Label();
      this.tbx2 = new TextBox();
      this.label8 = new Label();
      this.tbx1 = new TextBox();
      this.label9 = new Label();
      this.tbx1000 = new TextBox();
      this.tbx50 = new TextBox();
      this.label6 = new Label();
      this.tbx20 = new TextBox();
      this.label5 = new Label();
      this.tbx10 = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.tbx500 = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.03509f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85.96491f));
      this.tableLayoutPanel1.Size = new Size(424, 600);
      this.tableLayoutPanel1.TabIndex = 0;
      this.panel2.BackColor = Color.White;
      this.panel2.BackgroundImage = (Image) Resources.CHANGEINTERESTBACKGOUND;
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblHeading);
      this.panel2.Controls.Add((Control) this.glassButton2);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(418, 78);
      this.panel2.TabIndex = 1;
      this.lblHeading.AutoSize = true;
      this.lblHeading.BackColor = Color.Transparent;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.ForeColor = Color.Black;
      this.lblHeading.Location = new Point(103, 22);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(201, 29);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "DENOMINATION";
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.Crimson;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).Image = (Image) Resources.EXIT;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(356, 7);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(57, 54);
      ((Control) this.glassButton2).TabIndex = 1;
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Click += new EventHandler(this.glassButton2_Click);
      this.panel3.BackColor = Color.AliceBlue;
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.tbx200Amount);
      this.panel3.Controls.Add((Control) this.tbx200);
      this.panel3.Controls.Add((Control) this.label14);
      this.panel3.Controls.Add((Control) this.tbx2000Amount);
      this.panel3.Controls.Add((Control) this.tbx2000);
      this.panel3.Controls.Add((Control) this.label13);
      this.panel3.Controls.Add((Control) this.label12);
      this.panel3.Controls.Add((Control) this.label11);
      this.panel3.Controls.Add((Control) this.label10);
      this.panel3.Controls.Add((Control) this.tbxTotalAmount);
      this.panel3.Controls.Add((Control) this.tbxNotes);
      this.panel3.Controls.Add((Control) this.tbxCoins);
      this.panel3.Controls.Add((Control) this.tbx100Amount);
      this.panel3.Controls.Add((Control) this.tbx5Amount);
      this.panel3.Controls.Add((Control) this.tbx2Amount);
      this.panel3.Controls.Add((Control) this.tbx1Amount);
      this.panel3.Controls.Add((Control) this.tbx1000Amount);
      this.panel3.Controls.Add((Control) this.tbx50Amount);
      this.panel3.Controls.Add((Control) this.tbx20Amount);
      this.panel3.Controls.Add((Control) this.tbx10Amount);
      this.panel3.Controls.Add((Control) this.tbx500Amount);
      this.panel3.Controls.Add((Control) this.tbx100);
      this.panel3.Controls.Add((Control) this.tbx5);
      this.panel3.Controls.Add((Control) this.label7);
      this.panel3.Controls.Add((Control) this.tbx2);
      this.panel3.Controls.Add((Control) this.label8);
      this.panel3.Controls.Add((Control) this.tbx1);
      this.panel3.Controls.Add((Control) this.label9);
      this.panel3.Controls.Add((Control) this.tbx1000);
      this.panel3.Controls.Add((Control) this.tbx50);
      this.panel3.Controls.Add((Control) this.label6);
      this.panel3.Controls.Add((Control) this.tbx20);
      this.panel3.Controls.Add((Control) this.label5);
      this.panel3.Controls.Add((Control) this.tbx10);
      this.panel3.Controls.Add((Control) this.label4);
      this.panel3.Controls.Add((Control) this.label3);
      this.panel3.Controls.Add((Control) this.tbx500);
      this.panel3.Controls.Add((Control) this.label2);
      this.panel3.Controls.Add((Control) this.label1);
      this.panel3.Dock = DockStyle.Fill;
      this.panel3.ForeColor = Color.IndianRed;
      this.panel3.Location = new Point(3, 87);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(418, 510);
      this.panel3.TabIndex = 0;
      this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
      this.tbx200Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx200Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx200Amount.Location = new Point(197, 110);
      this.tbx200Amount.Name = "tbx200Amount";
      this.tbx200Amount.Size = new Size(203, 31);
      this.tbx200Amount.TabIndex = 14;
      this.tbx200Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx200Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx200.BorderStyle = BorderStyle.FixedSingle;
      this.tbx200.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx200.Location = new Point(84, 110);
      this.tbx200.Name = "tbx200";
      this.tbx200.Size = new Size(110, 31);
      this.tbx200.TabIndex = 3;
      this.tbx200.TextAlign = HorizontalAlignment.Right;
      this.tbx200.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx200.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx200.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx200.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Transparent;
      this.label14.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label14.ForeColor = Color.DarkBlue;
      this.label14.Location = new Point(29, 113);
      this.label14.Name = "label14";
      this.label14.Size = new Size(51, 25);
      this.label14.TabIndex = 38;
      this.label14.Text = "200";
      this.tbx2000Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx2000Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx2000Amount.Location = new Point(197, 6);
      this.tbx2000Amount.Name = "tbx2000Amount";
      this.tbx2000Amount.Size = new Size(203, 31);
      this.tbx2000Amount.TabIndex = 11;
      this.tbx2000Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx2000Amount.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx2000Amount.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.tbx2000.BorderStyle = BorderStyle.FixedSingle;
      this.tbx2000.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx2000.Location = new Point(84, 6);
      this.tbx2000.Name = "tbx2000";
      this.tbx2000.Size = new Size(110, 31);
      this.tbx2000.TabIndex = 0;
      this.tbx2000.TextAlign = HorizontalAlignment.Right;
      this.tbx2000.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx2000.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx2000.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown_1);
      this.tbx2000.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Transparent;
      this.label13.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.ForeColor = Color.DarkBlue;
      this.label13.Location = new Point(16, 9);
      this.label13.Name = "label13";
      this.label13.Size = new Size(64, 25);
      this.label13.TabIndex = 35;
      this.label13.Text = "2000";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.DarkBlue;
      this.label12.Location = new Point(106, 432);
      this.label12.Name = "label12";
      this.label12.Size = new Size(82, 25);
      this.label12.TabIndex = 31;
      this.label12.Text = "COINS";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.DarkBlue;
      this.label11.Location = new Point(103, 471);
      this.label11.Name = "label11";
      this.label11.Size = new Size(85, 25);
      this.label11.TabIndex = 32;
      this.label11.Text = "TOTAL";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkBlue;
      this.label10.Location = new Point(99, 395);
      this.label10.Name = "label10";
      this.label10.Size = new Size(89, 25);
      this.label10.TabIndex = 30;
      this.label10.Text = "NOTES";
      this.label10.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbxTotalAmount.BorderStyle = BorderStyle.FixedSingle;
      this.tbxTotalAmount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxTotalAmount.Location = new Point(197, 466);
      this.tbxTotalAmount.Name = "tbxTotalAmount";
      this.tbxTotalAmount.Size = new Size(203, 31);
      this.tbxTotalAmount.TabIndex = 24;
      this.tbxTotalAmount.TextAlign = HorizontalAlignment.Right;
      this.tbxTotalAmount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbxNotes.BorderStyle = BorderStyle.FixedSingle;
      this.tbxNotes.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxNotes.Location = new Point(197, 392);
      this.tbxNotes.Name = "tbxNotes";
      this.tbxNotes.Size = new Size(203, 31);
      this.tbxNotes.TabIndex = 22;
      this.tbxNotes.TextAlign = HorizontalAlignment.Right;
      this.tbxNotes.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbxCoins.BorderStyle = BorderStyle.FixedSingle;
      this.tbxCoins.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxCoins.Location = new Point(197, 429);
      this.tbxCoins.Name = "tbxCoins";
      this.tbxCoins.Size = new Size(203, 31);
      this.tbxCoins.TabIndex = 23;
      this.tbxCoins.TextAlign = HorizontalAlignment.Right;
      this.tbxCoins.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx100Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx100Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx100Amount.Location = new Point(197, 145);
      this.tbx100Amount.Name = "tbx100Amount";
      this.tbx100Amount.Size = new Size(203, 31);
      this.tbx100Amount.TabIndex = 15;
      this.tbx100Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx100Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx5Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx5Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx5Amount.Location = new Point(197, 285);
      this.tbx5Amount.Name = "tbx5Amount";
      this.tbx5Amount.Size = new Size(203, 31);
      this.tbx5Amount.TabIndex = 19;
      this.tbx5Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx5Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx2Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx2Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx2Amount.Location = new Point(197, 320);
      this.tbx2Amount.Name = "tbx2Amount";
      this.tbx2Amount.Size = new Size(203, 31);
      this.tbx2Amount.TabIndex = 20;
      this.tbx2Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx2Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx1Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx1Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx1Amount.Location = new Point(197, 355);
      this.tbx1Amount.Name = "tbx1Amount";
      this.tbx1Amount.Size = new Size(203, 31);
      this.tbx1Amount.TabIndex = 21;
      this.tbx1Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx1Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx1000Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx1000Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx1000Amount.Location = new Point(197, 41);
      this.tbx1000Amount.Name = "tbx1000Amount";
      this.tbx1000Amount.Size = new Size(203, 31);
      this.tbx1000Amount.TabIndex = 12;
      this.tbx1000Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx1000Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx50Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx50Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx50Amount.Location = new Point(197, 180);
      this.tbx50Amount.Name = "tbx50Amount";
      this.tbx50Amount.Size = new Size(203, 31);
      this.tbx50Amount.TabIndex = 16;
      this.tbx50Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx50Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx20Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx20Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx20Amount.Location = new Point(197, 215);
      this.tbx20Amount.Name = "tbx20Amount";
      this.tbx20Amount.Size = new Size(203, 31);
      this.tbx20Amount.TabIndex = 17;
      this.tbx20Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx20Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx10Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx10Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx10Amount.Location = new Point(197, 250);
      this.tbx10Amount.Name = "tbx10Amount";
      this.tbx10Amount.Size = new Size(203, 31);
      this.tbx10Amount.TabIndex = 18;
      this.tbx10Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx10Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx500Amount.BorderStyle = BorderStyle.FixedSingle;
      this.tbx500Amount.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx500Amount.Location = new Point(197, 76);
      this.tbx500Amount.Name = "tbx500Amount";
      this.tbx500Amount.Size = new Size(203, 31);
      this.tbx500Amount.TabIndex = 13;
      this.tbx500Amount.TextAlign = HorizontalAlignment.Right;
      this.tbx500Amount.KeyPress += new KeyPressEventHandler(this.tbx100Amount_KeyPress);
      this.tbx100.BorderStyle = BorderStyle.FixedSingle;
      this.tbx100.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx100.Location = new Point(84, 145);
      this.tbx100.Name = "tbx100";
      this.tbx100.Size = new Size(110, 31);
      this.tbx100.TabIndex = 4;
      this.tbx100.TextAlign = HorizontalAlignment.Right;
      this.tbx100.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx100.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx100.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx100.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.tbx5.BorderStyle = BorderStyle.FixedSingle;
      this.tbx5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx5.Location = new Point(84, 285);
      this.tbx5.Name = "tbx5";
      this.tbx5.Size = new Size(110, 31);
      this.tbx5.TabIndex = 8;
      this.tbx5.TextAlign = HorizontalAlignment.Right;
      this.tbx5.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx5.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx5.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx5.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.DarkBlue;
      this.label7.Location = new Point(55, 358);
      this.label7.Name = "label7";
      this.label7.Size = new Size(25, 25);
      this.label7.TabIndex = 29;
      this.label7.Text = "1";
      this.tbx2.BorderStyle = BorderStyle.FixedSingle;
      this.tbx2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx2.Location = new Point(84, 320);
      this.tbx2.Name = "tbx2";
      this.tbx2.Size = new Size(110, 31);
      this.tbx2.TabIndex = 9;
      this.tbx2.TextAlign = HorizontalAlignment.Right;
      this.tbx2.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx2.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx2.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx2.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkBlue;
      this.label8.Location = new Point(55, 323);
      this.label8.Name = "label8";
      this.label8.Size = new Size(25, 25);
      this.label8.TabIndex = 28;
      this.label8.Text = "2";
      this.tbx1.BorderStyle = BorderStyle.FixedSingle;
      this.tbx1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx1.Location = new Point(84, 355);
      this.tbx1.Name = "tbx1";
      this.tbx1.Size = new Size(110, 31);
      this.tbx1.TabIndex = 10;
      this.tbx1.TextAlign = HorizontalAlignment.Right;
      this.tbx1.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx1.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx1.KeyDown += new KeyEventHandler(this.tbx1_KeyDown);
      this.tbx1.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.DarkBlue;
      this.label9.Location = new Point(55, 288);
      this.label9.Name = "label9";
      this.label9.Size = new Size(25, 25);
      this.label9.TabIndex = 27;
      this.label9.Text = "5";
      this.tbx1000.BorderStyle = BorderStyle.FixedSingle;
      this.tbx1000.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx1000.Location = new Point(84, 41);
      this.tbx1000.Name = "tbx1000";
      this.tbx1000.Size = new Size(110, 31);
      this.tbx1000.TabIndex = 1;
      this.tbx1000.TextAlign = HorizontalAlignment.Right;
      this.tbx1000.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx1000.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx1000.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx1000.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.tbx50.BorderStyle = BorderStyle.FixedSingle;
      this.tbx50.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx50.Location = new Point(84, 180);
      this.tbx50.Name = "tbx50";
      this.tbx50.Size = new Size(110, 31);
      this.tbx50.TabIndex = 5;
      this.tbx50.TextAlign = HorizontalAlignment.Right;
      this.tbx50.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx50.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx50.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx50.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(42, 253);
      this.label6.Name = "label6";
      this.label6.Size = new Size(38, 25);
      this.label6.TabIndex = 26;
      this.label6.Text = "10";
      this.tbx20.BorderStyle = BorderStyle.FixedSingle;
      this.tbx20.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx20.Location = new Point(84, 215);
      this.tbx20.Name = "tbx20";
      this.tbx20.Size = new Size(110, 31);
      this.tbx20.TabIndex = 6;
      this.tbx20.TextAlign = HorizontalAlignment.Right;
      this.tbx20.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx20.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx20.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx20.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(42, 218);
      this.label5.Name = "label5";
      this.label5.Size = new Size(38, 25);
      this.label5.TabIndex = 25;
      this.label5.Text = "20";
      this.tbx10.BorderStyle = BorderStyle.FixedSingle;
      this.tbx10.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx10.Location = new Point(84, 250);
      this.tbx10.Name = "tbx10";
      this.tbx10.Size = new Size(110, 31);
      this.tbx10.TabIndex = 7;
      this.tbx10.TextAlign = HorizontalAlignment.Right;
      this.tbx10.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx10.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx10.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx10.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(42, 183);
      this.label4.Name = "label4";
      this.label4.Size = new Size(38, 25);
      this.label4.TabIndex = 24;
      this.label4.Text = "50";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(29, 148);
      this.label3.Name = "label3";
      this.label3.Size = new Size(51, 25);
      this.label3.TabIndex = 23;
      this.label3.Text = "100";
      this.tbx500.BorderStyle = BorderStyle.FixedSingle;
      this.tbx500.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbx500.Location = new Point(84, 76);
      this.tbx500.Name = "tbx500";
      this.tbx500.Size = new Size(110, 31);
      this.tbx500.TabIndex = 2;
      this.tbx500.TextAlign = HorizontalAlignment.Right;
      this.tbx500.TextChanged += new EventHandler(this.tbx100_TextChanged);
      this.tbx500.Enter += new EventHandler(this.tbx1000_Enter);
      this.tbx500.KeyDown += new KeyEventHandler(this.tbx1000_KeyDown);
      this.tbx500.KeyPress += new KeyPressEventHandler(this.tbx1000_KeyPress);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(29, 79);
      this.label2.Name = "label2";
      this.label2.Size = new Size(51, 25);
      this.label2.TabIndex = 22;
      this.label2.Text = "500";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(16, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(64, 25);
      this.label1.TabIndex = 21;
      this.label1.Text = "1000";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(424, 600);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormMoneyCalculator);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormMoneyCalculator);
      this.FormClosing += new FormClosingEventHandler(this.FormMoneyCalculator_FormClosing);
      this.Load += new EventHandler(this.FormMoneyCalculator_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
