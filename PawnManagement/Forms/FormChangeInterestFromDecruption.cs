
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PawnManagement.Forms
{
  public class FormChangeInterestFromDecruption : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;

    public FormChangeInterestFromDecruption() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridView1 = new DataGridView();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(984, 244);
      this.dataGridView1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 622);
      this.Controls.Add((Control) this.dataGridView1);
      this.Name = nameof (FormChangeInterestFromDecruption);
      this.Text = nameof (FormChangeInterestFromDecruption);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
