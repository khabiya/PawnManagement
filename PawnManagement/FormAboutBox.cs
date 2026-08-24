
using PawnManagement.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormAboutBox : Form
  {
    private IContainer components = (IContainer) null;
    private PictureBox pictureBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label8;
    private Panel panel1;
    private Label label7;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel2;
    private Label label9;

    public FormAboutBox() => this.InitializeComponent();

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormAboutBox_Load(object sender, EventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.pictureBox1 = new PictureBox();
      this.panel1 = new Panel();
      this.label9 = new Label();
      this.label7 = new Label();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel2 = new Panel();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Firebrick;
      this.label1.Location = new Point(223, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(122, 29);
      this.label1.TabIndex = 1;
      this.label1.Text = "Pawn Star";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(225, 49);
      this.label2.Name = "label2";
      this.label2.Size = new Size(178, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Pawn Management Software";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(225, 74);
      this.label3.Name = "label3";
      this.label3.Size = new Size(94, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Version 1.0.0.0";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(225, 101);
      this.label4.Name = "label4";
      this.label4.Size = new Size(139, 16);
      this.label4.TabIndex = 4;
      this.label4.Text = "CopyRights Protected";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(225, 128);
      this.label5.Name = "label5";
      this.label5.Size = new Size(186, 16);
      this.label5.TabIndex = 5;
      this.label5.Text = "Designed and Developed By,";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.DarkBlue;
      this.label6.Location = new Point(225, 155);
      this.label6.Name = "label6";
      this.label6.Size = new Size(236, 16);
      this.label6.TabIndex = 6;
      this.label6.Text = "B.Ramesh Kumar s/o Bhikaram.P(late)";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.DarkBlue;
      this.label8.Location = new Point(225, 183);
      this.label8.Name = "label8";
      this.label8.Size = new Size(236, 16);
      this.label8.TabIndex = 8;
      this.label8.Text = "Mathaji Technologies,Pallikaranai. Ph:";
      this.pictureBox1.Image = (Image) Resources.star;
      this.pictureBox1.Location = new Point(13, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(206, 238);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.panel1.BackColor = Color.Firebrick;
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(615, 30);
      this.panel1.TabIndex = 9;
      this.label9.AutoSize = true;
      this.label9.Cursor = Cursors.Hand;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Cornsilk;
      this.label9.Location = new Point(571, 7);
      this.label9.Name = "label9";
      this.label9.Size = new Size(44, 15);
      this.label9.TabIndex = 11;
      this.label9.Text = "[Close]";
      this.label9.Click += new EventHandler(this.glassButton1_Click);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.White;
      this.label7.Location = new Point(3, 9);
      this.label7.Name = "label7";
      this.label7.Size = new Size(48, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "About";
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.04482f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.95518f));
      this.tableLayoutPanel1.Size = new Size(621, 307);
      this.tableLayoutPanel1.TabIndex = 10;
      this.panel2.Controls.Add((Control) this.pictureBox1);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.label8);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(3, 39);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(615, 265);
      this.panel2.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.Info;
      this.ClientSize = new Size(621, 307);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormAboutBox);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormAboutBox);
      this.Load += new EventHandler(this.FormAboutBox_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
