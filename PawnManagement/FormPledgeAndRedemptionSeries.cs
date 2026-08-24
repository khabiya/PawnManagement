

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormPledgeAndRedemptionSeries : Form
  {
    private Image imagesColHeader = Image.FromFile("Photos\\Resources\\LIGHTBLUEFADEDOWN.jpg");
    private IContainer components = (IContainer) null;
    private DataGridView dataGridView1;
    private TextBox tbxPledgeSeries;
    private TextBox tbxRedemptionSeries;
    private GlassButton glassButton1;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton6;
    private GlassButton glassButton7;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton2;
    private GlassButton glassButton3;

    [DllImport("user32.dll")]
    internal static extern short GetKeyState(int keyCode);

    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    public FormPledgeAndRedemptionSeries() => this.InitializeComponent();

    private void refreshGrid()
    {
      string strError = "";
      string my_querry = "select * from tblPledgeBillNumberSeries where active = '1'";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, ref strError);
      if (strError != "")
      {
        int num = (int) MessageBox.Show("Error in retrieving bill number" + strError);
      }
      else
        this.dataGridView1.DataSource = (object) dataTable2;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormPledgeAndRedemptionSeries_Load(object sender, EventArgs e)
    {
      if (FormMain.BillNumberSeries == "DOUBLE")
      {
        this.tbxPledgeSeries.MaxLength = 2;
        this.tbxRedemptionSeries.MaxLength = 2;
      }
      this.refreshGrid();
      PawnManagementClass.formatDataGridViewBluePledge(ref this.dataGridView1);
      PawnManagementClass.formatButtonControl(ref this.glassButton1);
      if (FormPledgeAndRedemptionSeries.GetKeyState(20) == (short) 0)
        this.PressKeyboardButton(Keys.Capital);
      if (FormPledgeAndRedemptionSeries.GetKeyState(144) != (short) 0)
        return;
      this.PressKeyboardButton(Keys.NumLock);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      this.tbxPledgeSeries.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["CurrentSeries"].Value.ToString();
      this.tbxRedemptionSeries.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["RedemptionCurrentSeries"].Value.ToString();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      if (!(this.tbxPledgeSeries.Text != "") || !(this.tbxRedemptionSeries.Text != ""))
        return;
      switch (FormMain.BillNumberSeries)
      {
        case "SINGLE":
          char c1 = this.tbxPledgeSeries.Text[0];
          char c2 = this.tbxRedemptionSeries.Text[0];
          if (c1 == '0' | char.IsUpper(c1))
          {
            if (c2 == '0' | char.IsUpper(c2))
            {
              this.update();
              break;
            }
            this.tbxRedemptionSeries.Select();
            break;
          }
          this.tbxPledgeSeries.Select();
          break;
        case "DOUBLE":
          if (this.tbxPledgeSeries.Text.Count<char>() == 2 && this.tbxRedemptionSeries.Text.Count<char>() == 2)
          {
            char c3 = this.tbxPledgeSeries.Text[0];
            char c4 = this.tbxPledgeSeries.Text[1];
            char c5 = this.tbxRedemptionSeries.Text[0];
            char c6 = this.tbxRedemptionSeries.Text[1];
            if (char.IsUpper(c3) && char.IsUpper(c4))
            {
              if (char.IsUpper(c5) && char.IsUpper(c6))
                this.update();
              else
                this.tbxRedemptionSeries.Select();
            }
            else
              this.tbxPledgeSeries.Select();
          }
          break;
      }
      this.refreshGrid();
    }

    private void update()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblPledgeBillNumberSeries set CurrentSeries = @CurrentSeries,RedemptionCurrentSeries = @RedemptionCurrentSeries where ID = @ID", new List<OleDbParameter>()
      {
        new OleDbParameter("CurrentSeries", (object) this.tbxPledgeSeries.Text.Trim().ToString()),
        new OleDbParameter("RedemptionCurrentSeries", (object) this.tbxRedemptionSeries.Text.Trim().ToString()),
        new OleDbParameter("ID", (object) int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString()))
      }, ref strError) != "Done"))
        return;
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private void tbxRedemptionSeries_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(!char.IsUpper(e.KeyChar) & e.KeyChar != '\b' & e.KeyChar != '0'))
        return;
      e.Handled = true;
    }

    private void PressKeyboardButton(Keys keyCode)
    {
      FormPledgeAndRedemptionSeries.keybd_event((byte) keyCode, (byte) 69, 1U, 0);
      FormPledgeAndRedemptionSeries.keybd_event((byte) keyCode, (byte) 69, 3U, 0);
    }

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex != -1)
        return;
      e.Graphics.DrawImage(this.imagesColHeader, e.CellBounds);
      e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
      e.Handled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridView1 = new DataGridView();
      this.tbxPledgeSeries = new TextBox();
      this.tbxRedemptionSeries = new TextBox();
      this.glassButton1 = new GlassButton();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton6 = new GlassButton();
      this.glassButton7 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton2 = new GlassButton();
      this.glassButton3 = new GlassButton();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(29, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(679, 281);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      this.tbxPledgeSeries.BackColor = Color.AliceBlue;
      this.tbxPledgeSeries.BorderStyle = BorderStyle.None;
      this.tbxPledgeSeries.Dock = DockStyle.Fill;
      this.tbxPledgeSeries.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeSeries.Location = new Point(0, 0);
      this.tbxPledgeSeries.MaxLength = 1;
      this.tbxPledgeSeries.Name = "tbxPledgeSeries";
      this.tbxPledgeSeries.Size = new Size(215, 28);
      this.tbxPledgeSeries.TabIndex = 1;
      this.tbxPledgeSeries.TextAlign = HorizontalAlignment.Center;
      this.tbxPledgeSeries.KeyPress += new KeyPressEventHandler(this.tbxRedemptionSeries_KeyPress);
      this.tbxRedemptionSeries.BackColor = Color.AliceBlue;
      this.tbxRedemptionSeries.BorderStyle = BorderStyle.None;
      this.tbxRedemptionSeries.Dock = DockStyle.Fill;
      this.tbxRedemptionSeries.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxRedemptionSeries.Location = new Point(0, 0);
      this.tbxRedemptionSeries.MaxLength = 1;
      this.tbxRedemptionSeries.Name = "tbxRedemptionSeries";
      this.tbxRedemptionSeries.Size = new Size(215, 28);
      this.tbxRedemptionSeries.TabIndex = 2;
      this.tbxRedemptionSeries.TextAlign = HorizontalAlignment.Center;
      this.tbxRedemptionSeries.KeyPress += new KeyPressEventHandler(this.tbxRedemptionSeries_KeyPress);
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).Image = (Image) Resources.SAVE;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(495, 297);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(217, 55);
      ((Control) this.glassButton1).TabIndex = 5;
      ((Control) this.glassButton1).Text = "&Update";
      ((ButtonBase) this.glassButton1).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel4.CaptionEndColor = Color.AliceBlue;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "PLEDGE BILL NUMBER SERIES";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton7);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxPledgeSeries);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.GradientEnd = SystemColors.ControlLight;
      this.headerPanel4.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel4).Location = new Point(29, 297);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(217, 55);
      ((Control) this.headerPanel4).TabIndex = 76;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      ((ButtonBase) this.glassButton6).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(-82, 513);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(128, 35);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&SAVE";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton7).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton7.BackColor = Color.LightBlue;
      this.glassButton7.FadeOnFocus = true;
      ((Control) this.glassButton7).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton7.ForeColor = Color.MediumBlue;
      this.glassButton7.ForeColorOnFocus = Color.Red;
      this.glassButton7.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton7.GlowColor = Color.White;
      this.glassButton7.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton7).Location = new Point(52, 512);
      ((Control) this.glassButton7).Name = "glassButton7";
      this.glassButton7.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton7.ShineColor = Color.Transparent;
      ((Control) this.glassButton7).Size = new Size(123, 37);
      ((Control) this.glassButton7).TabIndex = 0;
      ((Control) this.glassButton7).Text = "&EXIT";
      ((ButtonBase) this.glassButton7).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImage = (Image) Resources.background_gradient_blue1;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.PowderBlue;
      this.headerPanel1.CaptionEndColor = Color.AliceBlue;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "REDEMPTION BILL NUMBER SERIES";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxRedemptionSeries);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.GradientEnd = SystemColors.ControlLight;
      this.headerPanel1.GradientStart = SystemColors.ControlLightLight;
      ((Control) this.headerPanel1).Location = new Point(262, 297);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(217, 55);
      ((Control) this.headerPanel1).TabIndex = 77;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      ((ButtonBase) this.glassButton2).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(-84, 513);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(128, 35);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&SAVE";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(50, 512);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(123, 37);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&EXIT";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.AliceBlue;
      this.ClientSize = new Size(728, 365);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.glassButton1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.headerPanel4);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormPledgeAndRedemptionSeries);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (FormPledgeAndRedemptionSeries);
      this.Load += new EventHandler(this.FormPledgeAndRedemptionSeries_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
