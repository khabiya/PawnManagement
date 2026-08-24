

using Glass;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.Forms
{
  public class FormBillerAddEDit : Form
  {
    private string formType = "";
    private string billerName = "";
    private string Id = "";
    private IContainer components = (IContainer) null;
    private Label lblHeading;
    private Panel panel2;
    private Panel panel3;
    private ToolStripMenuItem wrapToolStripMenuItem;
    private ToolStripMenuItem exportToExcelToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private Panel panel1;
    private Label label4;
    private ComboBox cbUserType;
    private GlassButton glassButton1;
    private PictureBox pictureBox1;
    private TextBox tbxName;
    private TextBox tbxPhoneNumber;
    private Label label3;
    private TextBox tbxDetails;
    private Label label2;
    private Label label1;
    private GlassButton btnAddEdit;
    private Label label5;

    public FormBillerAddEDit(string FORMTYPE, string BILLERNAME, string ID)
    {
      this.formType = FORMTYPE;
      this.billerName = BILLERNAME;
      this.Id = ID;
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

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void getPicture(string Name)
    {
      try
      {
        if (File.Exists(FormMain.startUpPath + "photos\\biller\\" + Name + ".png"))
        {
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "photos\\biller\\" + Name + ".png", FileMode.Open, FileAccess.Read))
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
        }
        else
        {
          if (!File.Exists(FormMain.startUpPath + "photos\\nophoto.png"))
            return;
          using (FileStream fileStream = new FileStream(FormMain.startUpPath + "photos\\nophoto.png", FileMode.Open, FileAccess.Read))
            this.pictureBox1.Image = Image.FromStream((Stream) fileStream);
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form main.getpicture second exception", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.checkEntries())
        {
          if (((Control) this.btnAddEdit).Text == "&UPDATE")
          {
            if (this.tbxName.Text.Trim() == this.billerName)
            {
              this.editBillerDetails();
              this.tbxName.Select();
              this.tbxName.ReadOnly = false;
              ((Control) this.btnAddEdit).Text = "&ADD";
            }
            else if (this.checkDuplicateBillerName())
            {
              this.editBillerDetails();
              this.tbxName.Select();
              this.tbxName.ReadOnly = false;
              ((Control) this.btnAddEdit).Text = "&ADD";
            }
            else
            {
              int num = (int) MessageBox.Show(this.tbxName.Text + " already taken");
              this.tbxName.Select();
            }
          }
          else
          {
            if (!(((Control) this.btnAddEdit).Text == "&ADD"))
              return;
            if (this.checkDuplicateBillerName())
            {
              this.addBillerDetails();
              this.tbxName.Select();
            }
            else
            {
              int num = (int) MessageBox.Show(this.tbxName.Text + " already taken");
              this.tbxName.Select();
            }
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("Fill all the details");
        }
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form License master.btnAddEdit_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private bool checkDuplicateBillerName()
    {
      string strError = "";
      string my_querry = "select * from tblbiller where billername = @billername";
      List<OleDbParameter> parameters = new List<OleDbParameter>();
      parameters.Add(new OleDbParameter("billername", (object) this.tbxName.Text.ToString()));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, parameters, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form Shop Details.checkduplicateshopname", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in Adding checkduplicateshopname" + strError);
        return false;
      }
      return dataTable2 == null || dataTable2.Rows.Count <= 0;
    }

    private void addBillerDetails()
    {
      string MessageAnDStackTrace = BillerClass.addBiller(this.tbxName.Text.Trim(), this.tbxDetails.Text.Trim(), this.tbxPhoneNumber.Text.Trim(), this.cbUserType.Text.Trim(), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
      if (MessageAnDStackTrace != "Done")
      {
        PawnManagementClass.InsertIntoException("form shop details.addShopDetails()", MessageAnDStackTrace, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form shop details.addShopDetails()" + MessageAnDStackTrace);
      }
      this.reset();
    }

    public void editBillerDetails()
    {
      string MessageAnDStackTrace = BillerClass.editBiller(this.tbxName.Text.Trim(), this.tbxDetails.Text.Trim(), this.tbxPhoneNumber.Text.Trim(), this.cbUserType.Text, this.Id, FormMain.username, DateTime.Now);
      if (MessageAnDStackTrace == "Done")
      {
        int num = (int) MessageBox.Show("successfullly updated");
        this.reset();
      }
      else
      {
        PawnManagementClass.InsertIntoException("form ShopDetails.updateShopDetails", MessageAnDStackTrace, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("Error in updating" + MessageAnDStackTrace);
      }
    }

    private void FormBillerAddEDit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnAddEdit).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable basedOnThisColumn = BillerClass.getAllTheRecordsBasedOnThisColumn("ID", this.Id);
        if (basedOnThisColumn == null || basedOnThisColumn.Rows.Count <= 0)
          return;
        this.tbxName.Text = basedOnThisColumn.Rows[0]["bILLERName"].ToString();
        this.tbxDetails.Text = basedOnThisColumn.Rows[0]["bILLERDetails"].ToString();
        this.tbxPhoneNumber.Text = basedOnThisColumn.Rows[0]["BILLERPhoneNumber"].ToString();
        this.cbUserType.Text = basedOnThisColumn.Rows[0]["UserType"].ToString();
        ((Control) this.btnAddEdit).Text = "&UPDATE";
        this.lblHeading.Text = "EDIT";
      }
      else
        ((Control) this.btnAddEdit).Enabled = false;
    }

    private bool checkEntries()
    {
      if (this.tbxName.Text.Trim() != "")
      {
        if (this.tbxDetails.Text.Trim() != "")
        {
          if (this.tbxPhoneNumber.Text.Trim() != "")
          {
            if (this.cbUserType.Text != "")
              return true;
            this.cbUserType.Select();
            return false;
          }
          this.tbxPhoneNumber.Select();
          return false;
        }
        this.tbxDetails.Select();
        return false;
      }
      this.tbxName.Select();
      return false;
    }

    private void reset()
    {
      this.tbxName.Text = "";
      this.tbxDetails.Text = "";
      this.tbxPhoneNumber.Text = "";
      this.pictureBox1.Image = (Image) null;
    }

    private void glassButton1_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.tbxName.Text.Trim() != "")
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";
          openFileDialog.Title = "Select the picture";
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            if (openFileDialog.CheckFileExists)
            {
              string destFileName = FormMain.startUpPath + "Photos\\biller\\" + this.tbxName.Text.Trim() + ".png";
              File.Copy(openFileDialog.FileName, destFileName, true);
              this.getPicture(this.tbxName.Text);
            }
            else
            {
              int num = (int) MessageBox.Show("file does not exist");
            }
          }
          ((Control) this.btnAddEdit).Select();
        }
        else
          this.tbxName.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("form login.changeImaggeToolStripMenuItem_Click", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
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
      this.lblHeading = new Label();
      this.panel2 = new Panel();
      this.label4 = new Label();
      this.cbUserType = new ComboBox();
      this.glassButton1 = new GlassButton();
      this.pictureBox1 = new PictureBox();
      this.tbxName = new TextBox();
      this.tbxPhoneNumber = new TextBox();
      this.label3 = new Label();
      this.tbxDetails = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.panel3 = new Panel();
      this.btnAddEdit = new GlassButton();
      this.wrapToolStripMenuItem = new ToolStripMenuItem();
      this.exportToExcelToolStripMenuItem = new ToolStripMenuItem();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.panel1 = new Panel();
      this.label5 = new Label();
      this.panel2.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel3.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(183, 8);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(178, 24);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "BILLER ADD EDIT";
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.cbUserType);
      this.panel2.Controls.Add((Control) this.glassButton1);
      this.panel2.Controls.Add((Control) this.pictureBox1);
      this.panel2.Controls.Add((Control) this.tbxName);
      this.panel2.Controls.Add((Control) this.tbxPhoneNumber);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.tbxDetails);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Location = new Point(15, 58);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(522, 335);
      this.panel2.TabIndex = 0;
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.DarkBlue;
      this.label4.Location = new Point(53, 148);
      this.label4.Name = "label4";
      this.label4.Size = new Size(101, 26);
      this.label4.TabIndex = 8;
      this.label4.Text = "User Type";
      this.cbUserType.BackColor = Color.White;
      this.cbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbUserType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbUserType.FormattingEnabled = true;
      this.cbUserType.Items.AddRange(new object[3]
      {
        (object) "OWNER",
        (object) "STAFF",
        (object) "SALES PERSON"
      });
      this.cbUserType.Location = new Point(160, 145);
      this.cbUserType.Name = "cbUserType";
      this.cbUserType.Size = new Size(316, 33);
      this.cbUserType.TabIndex = 3;
      this.glassButton1.BackColor = Color.LightBlue;
      this.glassButton1.FadeOnFocus = true;
      ((Control) this.glassButton1).Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.glassButton1.ForeColor = Color.MediumBlue;
      this.glassButton1.ForeColorOnFocus = Color.Red;
      this.glassButton1.ForeColorOnLeave = Color.MediumBlue;
      this.glassButton1.GlowColor = Color.White;
      this.glassButton1.InnerBorderColor = Color.Transparent;
      ((Control) this.glassButton1).Location = new Point(353, 293);
      ((Control) this.glassButton1).Name = "glassButton1";
      this.glassButton1.OuterBorderColor = Color.MediumSlateBlue;
      this.glassButton1.ShineColor = Color.Transparent;
      ((Control) this.glassButton1).Size = new Size(123, 26);
      ((Control) this.glassButton1).TabIndex = 4;
      ((Control) this.glassButton1).Text = "&Change";
      ((ButtonBase) this.glassButton1).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.glassButton1).Click += new EventHandler(this.glassButton1_Click);
      this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox1.Location = new Point(160, 184);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(316, 103);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 22;
      this.pictureBox1.TabStop = false;
      this.tbxName.BorderStyle = BorderStyle.FixedSingle;
      this.tbxName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxName.Location = new Point(159, 18);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new Size(317, 31);
      this.tbxName.TabIndex = 0;
      this.tbxName.TextAlign = HorizontalAlignment.Center;
      this.tbxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
      this.tbxPhoneNumber.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxPhoneNumber.Location = new Point(160, 102);
      this.tbxPhoneNumber.Name = "tbxPhoneNumber";
      this.tbxPhoneNumber.Size = new Size(317, 31);
      this.tbxPhoneNumber.TabIndex = 2;
      this.tbxPhoneNumber.TextAlign = HorizontalAlignment.Center;
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.DarkBlue;
      this.label3.Location = new Point(15, 104);
      this.label3.Name = "label3";
      this.label3.Size = new Size(141, 26);
      this.label3.TabIndex = 7;
      this.label3.Text = "PhoneNumber";
      this.tbxDetails.BorderStyle = BorderStyle.FixedSingle;
      this.tbxDetails.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxDetails.Location = new Point(160, 59);
      this.tbxDetails.Name = "tbxDetails";
      this.tbxDetails.Size = new Size(317, 31);
      this.tbxDetails.TabIndex = 1;
      this.tbxDetails.TextAlign = HorizontalAlignment.Center;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.DarkBlue;
      this.label2.Location = new Point(82, 62);
      this.label2.Name = "label2";
      this.label2.Size = new Size(74, 26);
      this.label2.TabIndex = 6;
      this.label2.Text = "Details";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkBlue;
      this.label1.Location = new Point(92, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(64, 26);
      this.label1.TabIndex = 5;
      this.label1.Text = "Name";
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnAddEdit);
      this.panel3.Location = new Point(15, 391);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(522, 46);
      this.panel3.TabIndex = 24;
      this.btnAddEdit.BackColor = Color.LightBlue;
      ((Control) this.btnAddEdit).Dock = DockStyle.Fill;
      this.btnAddEdit.FadeOnFocus = true;
      ((Control) this.btnAddEdit).Font = new Font("Comic Sans MS", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAddEdit.ForeColor = Color.MediumBlue;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.MediumBlue;
      this.btnAddEdit.GlowColor = Color.White;
      this.btnAddEdit.InnerBorderColor = Color.Transparent;
      ((Control) this.btnAddEdit).Location = new Point(0, 0);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MediumSlateBlue;
      this.btnAddEdit.ShineColor = Color.Transparent;
      ((Control) this.btnAddEdit).Size = new Size(520, 44);
      ((Control) this.btnAddEdit).TabIndex = 0;
      ((Control) this.btnAddEdit).Text = "&ADD";
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
      this.wrapToolStripMenuItem.Size = new Size(150, 22);
      this.wrapToolStripMenuItem.Text = "Wrap";
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new Size(150, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.exportToExcelToolStripMenuItem,
        (ToolStripItem) this.wrapToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(151, 48);
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(15, 16);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(522, 51);
      this.panel1.TabIndex = 1;
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Candara", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.DarkBlue;
      this.label5.Location = new Point(53, 188);
      this.label5.Name = "label5";
      this.label5.Size = new Size(97, 26);
      this.label5.TabIndex = 23;
      this.label5.Text = "Signature";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(557, 456);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (FormBillerAddEDit);
      this.Text = nameof (FormBillerAddEDit);
      this.Load += new EventHandler(this.FormBillerAddEDit_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel3.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
