

using Glass;
using KIS.Controls;
using KIS.Controls.Windows;
using PawnManagement.Forms;
using PawnManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PawnManagement
{
  public class FormJewelPhoto : Form
  {
    private string BillNumber = "";
    private string ShopCode = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxPledgeBillNumber;
    private GlassButton btnTakePhoto;
    private PictureBox pictureBox1;
    private DataGridView dataGridView1;
    private TextBox tbxBillNumber;
    private HeaderPanel headerPanel4;
    private GlassButton glassButton5;
    private GlassButton glassButton6;
    private HeaderPanel headerPanel1;
    private GlassButton glassButton1;
    private GlassButton glassButton2;
    private HeaderPanel headerPanel2;
    private GlassButton glassButton3;
    private GlassButton glassButton4;
    private TextBox tbxShopCode;

    public FormJewelPhoto() => this.InitializeComponent();

    public FormJewelPhoto(string BILLNumber, string SHOPCODE)
    {
      this.BillNumber = BILLNumber;
      this.ShopCode = SHOPCODE;
      this.InitializeComponent();
    }

    private void tbxPledgeBillNumber_TextChanged(object sender, EventArgs e)
    {
      string strError = "";
      string my_querry = "select  ShopCode,BillNumber,BillDate,Amount,NetWeight,CustomerCode,CustomerName,DoorNumber,Addr1,Addr2,Addr3 from tblPledge where BillNumber like @BillNumber";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("BillNumber", (object) (this.tbxPledgeBillNumber.Text.Trim().ToString() + "%")));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form jewelphoto.tbxpledgeBilNumber_textchanged", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in retrieving the pledge details" + strError);
      }
      else
      {
        this.dataGridView1.Visible = true;
        this.dataGridView1.DataSource = (object) dataTable2;
      }
      if (!(this.tbxPledgeBillNumber.Text == ""))
        return;
      this.dataGridView1.Visible = false;
    }

    private void btnTakePhoto_Click(object sender, EventArgs e)
    {
      if (!(this.tbxBillNumber.Text != ""))
        return;
      int num = (int) new FormCamera(this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text, "jewelPhoto").ShowDialog();
      PawnManagementClass.InsertIntoHistory("JEWEL PHOTO", "JEWEL PHOTO TAKEN FOR BILL NUMBER " + this.tbxBillNumber.Text.Trim().ToString(), "", "", FormMain.username, DateTime.Now.ToString());
    }

    private void FormJewelPhoto_Load(object sender, EventArgs e)
    {
      this.tbxPledgeBillNumber.Text = this.BillNumber;
      this.tbxBillNumber.Text = this.BillNumber;
      this.tbxShopCode.Text = this.ShopCode;
      if (this.BillNumber == "")
        this.tbxPledgeBillNumber.Select();
      else
        ((Control) this.btnTakePhoto).Focus();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void tbxPledgeBillNumber_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Down || !(this.dataGridView1 != null & this.dataGridView1.Rows.Count > 0))
          return;
        this.dataGridView1.Rows[0].Selected = true;
        this.dataGridView1.Focus();
        this.dataGridView1.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("formjewelPhoto.tbxPledgeBillNumber", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        this.tbxBillNumber.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      if (e.KeyCode != Keys.Escape)
        return;
      this.dataGridView1.Visible = false;
    }

    private void FormJewelPhoto_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png"))
          return;
        using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png", FileMode.Open, FileAccess.Read))
        {
          this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
          fileStream.Dispose();
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form jewel photo.formjewwelphoto_mourseEntter", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
      if (!(e.KeyCode == Keys.Up | e.KeyCode == Keys.Down))
        return;
      int index = this.dataGridView1.CurrentRow.Index;
      this.tbxShopCode.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
      this.tbxBillNumber.Text = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else
          this.pictureBox1.Image = this.pictureBox1.ErrorImage;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form jewelphoto.tbxbilnumber_textchainged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void tbxBillNumber_TextChanged(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
      int num = (int) new Formphoto(FormMain.startUpPath + "photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + ".png").ShowDialog();
    }

    private void tbxBillNumber_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void FormJewelPhoto_Shown(object sender, EventArgs e)
    {
      try
      {
        if (this.BillNumber == "")
          this.tbxPledgeBillNumber.Select();
        else
          ((Control) this.btnTakePhoto).Focus();
        if (File.Exists(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
        }
        else
          this.pictureBox1.Image = this.pictureBox1.ErrorImage;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form jewelphoto.tbxbilnumber_textchainged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void FormJewelPhoto_Activated(object sender, EventArgs e)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "Photos\\jewels\\" + this.tbxBillNumber.Text.Trim().ToString() + " " + this.tbxShopCode.Text + ".png", FileMode.Open, FileAccess.Read))
          {
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
            fileStream.Dispose();
          }
          ((Control) this.btnTakePhoto).Focus();
        }
        else
          this.pictureBox1.Image = this.pictureBox1.ErrorImage;
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form jewelphoto.tbxbilnumber_textchainged", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0 || !(this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode"))
        return;
      string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
      if (CUSTOMERCODE != "")
        new FormCustomerNew(CUSTOMERCODE).Show();
    }

    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dataGridView1.Rows.Count <= 0)
        return;
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "CustomerCode")
      {
        string CUSTOMERCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["customercode"].Value.ToString();
        if (CUSTOMERCODE != "")
          new FormCustomerNew(CUSTOMERCODE).Show();
      }
      if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "BillNumber")
      {
        double num = (double) (this.dataGridView1.Location.Y + this.dataGridView1.Size.Width);
        string BILLNUMBER = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["BillNumber"].Value.ToString();
        string SHOPCODE = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ShopCode"].Value.ToString();
        if (BILLNUMBER != "")
          new FormViewPledgeBillNew(BILLNUMBER, SHOPCODE, num.ToString()).Show();
      }
    }

    private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      this.tbxPledgeBillNumber = new TextBox();
      this.btnTakePhoto = new GlassButton();
      this.pictureBox1 = new PictureBox();
      this.dataGridView1 = new DataGridView();
      this.tbxBillNumber = new TextBox();
      this.headerPanel4 = new HeaderPanel();
      this.glassButton5 = new GlassButton();
      this.glassButton6 = new GlassButton();
      this.headerPanel1 = new HeaderPanel();
      this.glassButton1 = new GlassButton();
      this.glassButton2 = new GlassButton();
      this.headerPanel2 = new HeaderPanel();
      this.glassButton3 = new GlassButton();
      this.glassButton4 = new GlassButton();
      this.tbxShopCode = new TextBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((Control) this.headerPanel4).SuspendLayout();
      ((Control) this.headerPanel1).SuspendLayout();
      ((Control) this.headerPanel2).SuspendLayout();
      this.SuspendLayout();
      this.tbxPledgeBillNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxPledgeBillNumber.BackColor = Color.Ivory;
      this.tbxPledgeBillNumber.BorderStyle = BorderStyle.None;
      this.tbxPledgeBillNumber.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPledgeBillNumber.Location = new Point(3, 3);
      this.tbxPledgeBillNumber.Name = "tbxPledgeBillNumber";
      this.tbxPledgeBillNumber.Size = new Size(651, 28);
      this.tbxPledgeBillNumber.TabIndex = 0;
      this.tbxPledgeBillNumber.TextChanged += new EventHandler(this.tbxPledgeBillNumber_TextChanged);
      this.tbxPledgeBillNumber.KeyUp += new KeyEventHandler(this.tbxPledgeBillNumber_KeyUp);
      ((Control) this.btnTakePhoto).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnTakePhoto.BackColor = Color.LightBlue;
      this.btnTakePhoto.FadeOnFocus = true;
      ((Control) this.btnTakePhoto).Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnTakePhoto.ForeColor = Color.MediumBlue;
      this.btnTakePhoto.ForeColorOnFocus = Color.Red;
      this.btnTakePhoto.ForeColorOnLeave = Color.RoyalBlue;
      this.btnTakePhoto.GlowColor = Color.White;
      ((ButtonBase) this.btnTakePhoto).Image = (Image) Resources.camera2;
      this.btnTakePhoto.InnerBorderColor = Color.Transparent;
      ((Control) this.btnTakePhoto).Location = new Point(677, 484);
      ((Control) this.btnTakePhoto).Name = "btnTakePhoto";
      this.btnTakePhoto.OuterBorderColor = Color.MediumSlateBlue;
      this.btnTakePhoto.ShineColor = Color.Transparent;
      ((Control) this.btnTakePhoto).Size = new Size(321, 60);
      ((Control) this.btnTakePhoto).TabIndex = 2;
      ((Control) this.btnTakePhoto).Text = "&TAKE PHOTO";
      ((ButtonBase) this.btnTakePhoto).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnTakePhoto).Click += new EventHandler(this.btnTakePhoto_Click);
      this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox1.ErrorImage = (Image) null;
      this.pictureBox1.Location = new Point(672, 6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(330, 342);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox1.DoubleClick += new EventHandler(this.pictureBox1_DoubleClick);
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle.BackColor = Color.NavajoWhite;
      gridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = Color.Firebrick;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.ColumnHeadersHeight = 40;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.Location = new Point(7, 71);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(659, 558);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView_CellClick);
      this.dataGridView1.KeyDown += new KeyEventHandler(this.dataGridView1_KeyDown);
      this.dataGridView1.KeyUp += new KeyEventHandler(this.dataGridView1_KeyUp);
      this.tbxBillNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxBillNumber.BackColor = Color.Ivory;
      this.tbxBillNumber.BorderStyle = BorderStyle.None;
      this.tbxBillNumber.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxBillNumber.Location = new Point(4, 3);
      this.tbxBillNumber.Name = "tbxBillNumber";
      this.tbxBillNumber.Size = new Size(321, 33);
      this.tbxBillNumber.TabIndex = 1;
      this.tbxBillNumber.TextChanged += new EventHandler(this.tbxBillNumber_TextChanged);
      this.tbxBillNumber.KeyPress += new KeyPressEventHandler(this.tbxBillNumber_KeyPress);
      ((Control) this.headerPanel4).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      ((Control) this.headerPanel4).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel4).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel4.BorderColor = SystemColors.HotTrack;
      this.headerPanel4.BorderStyle = BorderStyles.Single;
      this.headerPanel4.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel4.CaptionEndColor = Color.PeachPuff;
      this.headerPanel4.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel4.CaptionHeight = 22;
      this.headerPanel4.CaptionPosition = CaptionPositions.Top;
      this.headerPanel4.CaptionText = "SEARCH BILL NUMBER";
      this.headerPanel4.CaptionVisible = true;
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton5);
      ((Control) this.headerPanel4).Controls.Add((Control) this.glassButton6);
      ((Control) this.headerPanel4).Controls.Add((Control) this.tbxPledgeBillNumber);
      ((Control) this.headerPanel4).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel4).ForeColor = Color.DarkBlue;
      this.headerPanel4.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel4.GradientEnd = Color.Ivory;
      this.headerPanel4.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel4).Location = new Point(7, 6);
      ((Control) this.headerPanel4).Name = "headerPanel4";
      this.headerPanel4.PanelIcon = (Icon) null;
      this.headerPanel4.PanelIconVisible = false;
      ((Control) this.headerPanel4).Size = new Size(659, 59);
      ((Control) this.headerPanel4).TabIndex = 71;
      this.headerPanel4.TextAntialias = true;
      ((Control) this.glassButton5).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton5.BackColor = Color.LightBlue;
      this.glassButton5.FadeOnFocus = true;
      ((Control) this.glassButton5).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton5.ForeColor = Color.MediumBlue;
      this.glassButton5.ForeColorOnFocus = Color.Red;
      this.glassButton5.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton5.GlowColor = Color.White;
      ((ButtonBase) this.glassButton5).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton5.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton5).Location = new Point(368, 513);
      ((Control) this.glassButton5).Name = "glassButton5";
      this.glassButton5.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton5.ShineColor = Color.Transparent;
      ((Control) this.glassButton5).Size = new Size(128, 35);
      ((Control) this.glassButton5).TabIndex = 0;
      ((Control) this.glassButton5).Text = "&SAVE";
      ((ButtonBase) this.glassButton5).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton6).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton6.BackColor = Color.LightBlue;
      this.glassButton6.FadeOnFocus = true;
      ((Control) this.glassButton6).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton6.ForeColor = Color.MediumBlue;
      this.glassButton6.ForeColorOnFocus = Color.Red;
      this.glassButton6.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton6.GlowColor = Color.White;
      this.glassButton6.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton6).Location = new Point(502, 512);
      ((Control) this.glassButton6).Name = "glassButton6";
      this.glassButton6.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton6.ShineColor = Color.Transparent;
      ((Control) this.glassButton6).Size = new Size(123, 37);
      ((Control) this.glassButton6).TabIndex = 1;
      ((Control) this.glassButton6).Text = "&EXIT";
      ((ButtonBase) this.glassButton6).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel1).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel1).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel1.BorderColor = SystemColors.HotTrack;
      this.headerPanel1.BorderStyle = BorderStyles.Single;
      this.headerPanel1.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel1.CaptionEndColor = Color.PeachPuff;
      this.headerPanel1.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel1.CaptionHeight = 22;
      this.headerPanel1.CaptionPosition = CaptionPositions.Top;
      this.headerPanel1.CaptionText = "BILL NUMBER";
      this.headerPanel1.CaptionVisible = true;
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton1);
      ((Control) this.headerPanel1).Controls.Add((Control) this.glassButton2);
      ((Control) this.headerPanel1).Controls.Add((Control) this.tbxBillNumber);
      ((Control) this.headerPanel1).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel1).ForeColor = Color.DarkBlue;
      this.headerPanel1.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel1.GradientEnd = Color.Ivory;
      this.headerPanel1.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel1).Location = new Point(672, 419);
      ((Control) this.headerPanel1).Name = "headerPanel1";
      this.headerPanel1.PanelIcon = (Icon) null;
      this.headerPanel1.PanelIconVisible = false;
      ((Control) this.headerPanel1).Size = new Size(330, 59);
      ((Control) this.headerPanel1).TabIndex = 72;
      this.headerPanel1.TextAntialias = true;
      ((Control) this.glassButton1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton1.GlowColor = Color.White;
      ((ButtonBase) this.glassButton1).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(37, 513);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(128, 35);
      ((Control) this.glassButton1).TabIndex = 0;
      ((Control) this.glassButton1).Text = "&SAVE";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton2.BackColor = Color.LightBlue;
      this.glassButton2.FadeOnFocus = true;
      ((Control) this.glassButton2).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton2.ForeColor = Color.MediumBlue;
      this.glassButton2.ForeColorOnFocus = Color.Red;
      this.glassButton2.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton2.GlowColor = Color.White;
      this.glassButton2.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton2).Location = new Point(171, 512);
      ((Control) this.glassButton2).Name = "glassButton2";
      this.glassButton2.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton2.ShineColor = Color.Transparent;
      ((Control) this.glassButton2).Size = new Size(123, 37);
      ((Control) this.glassButton2).TabIndex = 1;
      ((Control) this.glassButton2).Text = "&EXIT";
      ((ButtonBase) this.glassButton2).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.headerPanel2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((Control) this.headerPanel2).BackColor = Color.PowderBlue;
      ((Control) this.headerPanel2).BackgroundImageLayout = ImageLayout.Stretch;
      this.headerPanel2.BorderColor = SystemColors.HotTrack;
      this.headerPanel2.BorderStyle = BorderStyles.Single;
      this.headerPanel2.CaptionBeginColor = Color.SandyBrown;
      this.headerPanel2.CaptionEndColor = Color.PeachPuff;
      this.headerPanel2.CaptionGradientDirection = LinearGradientMode.Vertical;
      this.headerPanel2.CaptionHeight = 22;
      this.headerPanel2.CaptionPosition = CaptionPositions.Top;
      this.headerPanel2.CaptionText = "SHOP CODE";
      this.headerPanel2.CaptionVisible = true;
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton3);
      ((Control) this.headerPanel2).Controls.Add((Control) this.glassButton4);
      ((Control) this.headerPanel2).Controls.Add((Control) this.tbxShopCode);
      ((Control) this.headerPanel2).Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      ((Control) this.headerPanel2).ForeColor = Color.DarkBlue;
      this.headerPanel2.GradientDirection = LinearGradientMode.ForwardDiagonal;
      this.headerPanel2.GradientEnd = Color.Ivory;
      this.headerPanel2.GradientStart = Color.LightYellow;
      ((Control) this.headerPanel2).Location = new Point(672, 354);
      ((Control) this.headerPanel2).Name = "headerPanel2";
      this.headerPanel2.PanelIcon = (Icon) null;
      this.headerPanel2.PanelIconVisible = false;
      ((Control) this.headerPanel2).Size = new Size(330, 59);
      ((Control) this.headerPanel2).TabIndex = 73;
      this.headerPanel2.TextAntialias = true;
      ((Control) this.glassButton3).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton3.BackColor = Color.LightBlue;
      this.glassButton3.FadeOnFocus = true;
      ((Control) this.glassButton3).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton3.ForeColor = Color.MediumBlue;
      this.glassButton3.ForeColorOnFocus = Color.Red;
      this.glassButton3.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton3.GlowColor = Color.White;
      ((ButtonBase) this.glassButton3).ImageAlign = ContentAlignment.TopLeft;
      this.glassButton3.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton3).Location = new Point(35, 513);
      ((Control) this.glassButton3).Name = "glassButton3";
      this.glassButton3.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton3.ShineColor = Color.Transparent;
      ((Control) this.glassButton3).Size = new Size(128, 35);
      ((Control) this.glassButton3).TabIndex = 0;
      ((Control) this.glassButton3).Text = "&SAVE";
      ((ButtonBase) this.glassButton3).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton4).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.glassButton4.BackColor = Color.LightBlue;
      this.glassButton4.FadeOnFocus = true;
      ((Control) this.glassButton4).Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton4.ForeColor = Color.MediumBlue;
      this.glassButton4.ForeColorOnFocus = Color.Red;
      this.glassButton4.ForeColorOnLeave = Color.RoyalBlue;
      this.glassButton4.GlowColor = Color.White;
      this.glassButton4.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton4).Location = new Point(169, 512);
      ((Control) this.glassButton4).Name = "glassButton4";
      this.glassButton4.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton4.ShineColor = Color.Transparent;
      ((Control) this.glassButton4).Size = new Size(123, 37);
      ((Control) this.glassButton4).TabIndex = 1;
      ((Control) this.glassButton4).Text = "&EXIT";
      ((ButtonBase) this.glassButton4).TextImageRelation = TextImageRelation.ImageBeforeText;
      this.tbxShopCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tbxShopCode.BackColor = Color.Ivory;
      this.tbxShopCode.BorderStyle = BorderStyle.None;
      this.tbxShopCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxShopCode.Location = new Point(5, 7);
      this.tbxShopCode.Name = "tbxShopCode";
      this.tbxShopCode.Size = new Size(319, 22);
      this.tbxShopCode.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.OldLace;
      this.ClientSize = new Size(1008, 632);
      this.Controls.Add((Control) this.headerPanel2);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.headerPanel1);
      this.Controls.Add((Control) this.headerPanel4);
      this.Controls.Add((Control) this.btnTakePhoto);
      this.ForeColor = SystemColors.HotTrack;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (FormJewelPhoto);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (FormJewelPhoto);
      this.Activated += new EventHandler(this.FormJewelPhoto_Activated);
      this.Load += new EventHandler(this.FormJewelPhoto_Load);
      this.Shown += new EventHandler(this.FormJewelPhoto_Shown);
      this.MouseEnter += new EventHandler(this.FormJewelPhoto_MouseEnter);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((Control) this.headerPanel4).ResumeLayout(false);
      ((Control) this.headerPanel4).PerformLayout();
      ((Control) this.headerPanel1).ResumeLayout(false);
      ((Control) this.headerPanel1).PerformLayout();
      ((Control) this.headerPanel2).ResumeLayout(false);
      ((Control) this.headerPanel2).PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
