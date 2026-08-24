

using Glass;
using PawnManagement;
using PawnManagement.Classes.PawnManagementClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Rokad.FORMS
{
  public class FormLedgerMasterAddUpdate : Form
  {
    private string oldLedgerType = "";
    private string ledgerCode = "";
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private Panel panel2;
    private Label label9;
    private Label label7;
    private Label label3;
    private Label label2;
    private ComboBox comboBox1;
    private Label label1;
    private TextBox tbxLedgerTypeInHindi;
    private Label label4;
    private TextBox tbxLedgerType;
    private TextBox tbxLedgerCode;
    private GlassButton btnAddEdit;

    public FormLedgerMasterAddUpdate(string LEDGERCODE)
    {
      this.ledgerCode = LEDGERCODE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormLedgerMasterAddUpdate_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (!(this.ledgerCode != ""))
        return;
      DataTable rowFromAledgerCode = LedgerMaster.getDataRowFromALedgerCode(this.ledgerCode);
      if (rowFromAledgerCode != null && rowFromAledgerCode.Rows.Count > 0)
      {
        this.tbxLedgerType.Text = rowFromAledgerCode.Rows[0]["LedgerType"].ToString();
        this.tbxLedgerTypeInHindi.Text = rowFromAledgerCode.Rows[0]["LedgerTypeInHindi"].ToString();
        this.comboBox1.Text = rowFromAledgerCode.Rows[0]["JammaOrNovae"].ToString();
        this.tbxLedgerCode.Text = this.ledgerCode;
        ((Control) this.btnAddEdit).Text = "UPDATE";
        this.oldLedgerType = this.tbxLedgerType.Text;
      }
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

    private void btnAddEdit_Click(object sender, EventArgs e)
    {
      char ch;
      if (((Control) this.btnAddEdit).Text == "UPDATE")
      {
        if (((!(this.oldLedgerType != this.tbxLedgerType.Text.Trim().ToString()) ? 0 : (!this.checkifLedgerTypeAlreadyExists(this.tbxLedgerType.Text.Trim().ToString()) ? 1 : 0)) | (this.oldLedgerType == this.tbxLedgerType.Text.Trim().ToString() ? 1 : 0)) != 0)
        {
          if (this.tbxLedgerType.Text.Trim().ToString() != "" && this.comboBox1.Text.Trim().ToString() != "" && this.tbxLedgerCode.Text.Trim().ToString() != "")
          {
            if ((int) this.tbxLedgerCode.Text[0] == (int) this.tbxLedgerType.Text[0])
            {
              if (DialogResult.Yes == MessageBox.Show("Are you sure", "EDIT", MessageBoxButtons.YesNo))
              {
                this.editLedgerDetails();
                this.tbxLedgerType.Text = "";
                this.tbxLedgerCode.Text = "";
                this.tbxLedgerTypeInHindi.Text = "";
              }
            }
            else
            {
              ch = this.tbxLedgerCode.Text[0];
              int num = (int) MessageBox.Show("LedgerType should Begin with " + ch.ToString());
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show("Fill all the data");
          }
        }
        else
        {
          int num2 = (int) MessageBox.Show("Ledger type already exists");
        }
      }
      if (((Control) this.btnAddEdit).Text == "ADD")
      {
        if (!this.checkifLedgerTypeAlreadyExists(this.tbxLedgerType.Text.Trim().ToString()))
        {
          if (this.tbxLedgerType.Text.Trim().ToString() != "" && this.comboBox1.Text.Trim().ToString() != "" && this.tbxLedgerCode.Text.Trim().ToString() != "")
          {
            if ((int) this.tbxLedgerCode.Text[0] == (int) this.tbxLedgerType.Text[0])
            {
              if (DialogResult.Yes == MessageBox.Show("Are you sure", "ADD", MessageBoxButtons.YesNo))
              {
                this.addLedgerDetails();
                this.tbxLedgerType.Text = "";
                this.tbxLedgerCode.Text = "";
                this.tbxLedgerTypeInHindi.Text = "";
              }
            }
            else
            {
              ch = this.tbxLedgerCode.Text[0];
              int num3 = (int) MessageBox.Show("LedgerType should Begin with " + ch.ToString());
            }
          }
          else
          {
            int num4 = (int) MessageBox.Show("Fill all the data");
          }
        }
        else
        {
          int num5 = (int) MessageBox.Show("Ledger Type alraeady Exists..Duplicate types cannot be created");
        }
      }
      ((Control) this.btnAddEdit).Text = "ADD";
    }

    private void addLedgerDetails()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("insert into tblLedgerr(LedgerCode,LedgerType,jammaornovae,LedgerTypeInHindi,Deletable,CreatedBy,CreatedOn) values(@LedgerCode,@LedgerType,@jammaornovae,@LedgerTypeInHindi,@Deletable,@CreatedBy,@CreatedOn)", new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString()),
        new OleDbParameter("LedgerType", (object) this.tbxLedgerType.Text.Trim().ToString()),
        new OleDbParameter("jammaornovae", (object) this.comboBox1.Text.Trim().ToString()),
        new OleDbParameter("LedgerTypeInHindi", (object) this.tbxLedgerTypeInHindi.Text.Trim().ToString()),
        new OleDbParameter("Deletable", (object) "Y"),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy"))
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form ledgerDetails.addledgerdetails()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in Adding" + strError);
    }

    private void editLedgerDetails()
    {
      string strError = "";
      if (!(SQLHelper.RunCommand("Update tblLedgerr set LedgerType=@LedgerType,jammaornovae = @jammaornovae,Deletable = @Deletable,LedgerTypeInHindi = @LedgerTypeInHindi,CreatedBy = @CreatedBy,CreatedOn = @CreatedOn where Ledgercode = @LedgerCode", new List<OleDbParameter>()
      {
        new OleDbParameter("LedgerType", (object) this.tbxLedgerType.Text.Trim().ToString()),
        new OleDbParameter("jammaornovae", (object) this.comboBox1.Text.Trim().ToString()),
        new OleDbParameter("Deletable", (object) "Y"),
        new OleDbParameter("LedgerTypeInHindi", (object) this.tbxLedgerTypeInHindi.Text.Trim().ToString()),
        new OleDbParameter("CreatedBy", (object) FormMain.username),
        new OleDbParameter("CreatedOn", (object) DateTime.Now.ToString("dd/MM/yyyy")),
        new OleDbParameter("LedgerCode", (object) this.tbxLedgerCode.Text.Trim().ToString())
      }, ref strError) != "Done"))
        return;
      PawnManagementClass.InsertIntoException("form ledggerDetails.editLedgerdetails()", strError, FormMain.username, DateTime.Now.ToString());
      int num = (int) MessageBox.Show("Error in editing" + strError);
    }

    private bool checkifLedgerTypeAlreadyExists(string LedgerType)
    {
      string strError = "";
      string my_querry = "select * from tblLedgerr where LedgerType = @LedgerType";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = SQLHelper.GetDataTable(my_querry, new List<OleDbParameter>()
      {
        new OleDbParameter(nameof (LedgerType), (object) LedgerType)
      }, ref strError);
      if (strError != "")
      {
        PawnManagementClass.InsertIntoException("form  ledgerDetails..checkifledgetypealreadyExists", strError, FormMain.username, DateTime.Now.ToString());
        int num = (int) MessageBox.Show("form  ledgerDetails..checkifledgetypealreadyExists \n" + strError);
      }
      else if (dataTable2 != null && dataTable2.Rows.Count > 0)
        return true;
      return false;
    }

    private void tbxLedgerType_Validating(object sender, CancelEventArgs e)
    {
      if (!(((Control) this.btnAddEdit).Text == "ADD"))
        return;
      try
      {
        if (this.tbxLedgerType.Text.Trim() != "")
        {
          char ch = this.tbxLedgerType.Text.Trim()[0];
          string strError = "";
          DataTable dataTable = SQLHelper.GetDataTable("select * from tblLedgerr where LedgerCode like '" + ch.ToString() + "%' order by CreatedOn desc", ref strError);
          if (strError != "")
            PawnManagementClass.InsertIntoException("form LedgerDetails.tbxLedgerTyp_validating", strError, FormMain.username, DateTime.Now.ToString());
          if (dataTable != null)
          {
            if (dataTable.Rows.Count > 0)
              this.tbxLedgerCode.Text = ch.ToString() + this.NextCustomerCode(dataTable);
            else
              this.tbxLedgerCode.Text = ch.ToString() + "1";
          }
          else
          {
            int num = (int) MessageBox.Show("Error while setting voucherCode Restart - " + strError);
          }
        }
        else
          this.tbxLedgerType.Select();
      }
      catch (Exception ex)
      {
        PawnManagementClass.InsertIntoException("Form LedgerDetails.tbxLedgerType_validating", ex.Message + ex.StackTrace, FormMain.username, DateTime.Now.ToString());
        throw;
      }
    }

    private string NextCustomerCode(DataTable dtCustomerId)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      if (dtCustomerId != null && dtCustomerId.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dtCustomerId.Rows)
          intList.Add(int.Parse(row["ledgerCODE"].ToString().Substring(1)));
        foreach (int num2 in intList)
        {
          if (num2 > num1)
            num1 = num2;
        }
      }
      return (num1 + 1).ToString();
    }

    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      ((Control) this.btnAddEdit).Select();
    }

    private void label9_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormLedgerMasterAddUpdate));
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.btnAddEdit = new GlassButton();
      this.label3 = new Label();
      this.label2 = new Label();
      this.comboBox1 = new ComboBox();
      this.label1 = new Label();
      this.tbxLedgerTypeInHindi = new TextBox();
      this.label4 = new Label();
      this.tbxLedgerType = new TextBox();
      this.tbxLedgerCode = new TextBox();
      this.label9 = new Label();
      this.label7 = new Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = Color.Firebrick;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.label9);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(571, 264);
      this.panel1.TabIndex = 11;
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.BackColor = Color.Ivory;
      this.panel2.Controls.Add((Control) this.btnAddEdit);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.comboBox1);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.tbxLedgerTypeInHindi);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.tbxLedgerType);
      this.panel2.Controls.Add((Control) this.tbxLedgerCode);
      this.panel2.Location = new Point(2, 28);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(564, 232);
      this.panel2.TabIndex = 0;
      ((Control) this.btnAddEdit).Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddEdit.BackColor = Color.White;
      this.btnAddEdit.FadeOnFocus = true;
      this.btnAddEdit.ForeColor = Color.Black;
      this.btnAddEdit.ForeColorOnFocus = Color.Red;
      this.btnAddEdit.ForeColorOnLeave = Color.RoyalBlue;
      this.btnAddEdit.GlowColor = Color.LightPink;
      ((ButtonBase) this.btnAddEdit).Image = (Image) componentResourceManager.GetObject("btnAddEdit.Image");
      this.btnAddEdit.InnerBorderColor = Color.Firebrick;
      ((Control) this.btnAddEdit).Location = new Point(277, 178);
      ((Control) this.btnAddEdit).Name = "btnAddEdit";
      this.btnAddEdit.OuterBorderColor = Color.MistyRose;
      this.btnAddEdit.ShineColor = Color.MistyRose;
      ((Control) this.btnAddEdit).Size = new Size(199, 45);
      ((Control) this.btnAddEdit).TabIndex = 3;
      ((Control) this.btnAddEdit).Text = "ADD";
      ((ButtonBase) this.btnAddEdit).TextAlign = ContentAlignment.MiddleRight;
      ((ButtonBase) this.btnAddEdit).TextImageRelation = TextImageRelation.ImageBeforeText;
      ((Control) this.btnAddEdit).Click += new EventHandler(this.btnAddEdit_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(56, 130);
      this.label3.Name = "label3";
      this.label3.Size = new Size(174, 25);
      this.label3.TabIndex = 8;
      this.label3.Text = "Jamma or Novae";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(19, 90);
      this.label2.Name = "label2";
      this.label2.Size = new Size(211, 25);
      this.label2.TabIndex = 7;
      this.label2.Text = "Ledger Type in Hindi";
      this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.comboBox1.BackColor = Color.Linen;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.System;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "JAMMA",
        (object) "NOVAE",
        (object) "JAMMANOVAE"
      });
      this.comboBox1.Location = new Point(236, (int) sbyte.MaxValue);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(316, 32);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.KeyDown += new KeyEventHandler(this.comboBox1_KeyDown);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(92, 52);
      this.label1.Name = "label1";
      this.label1.Size = new Size(141, 25);
      this.label1.TabIndex = 6;
      this.label1.Text = "LedgeR Type";
      this.tbxLedgerTypeInHindi.BackColor = Color.Linen;
      this.tbxLedgerTypeInHindi.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerTypeInHindi.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerTypeInHindi.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerTypeInHindi.Location = new Point(236, 90);
      this.tbxLedgerTypeInHindi.Margin = new Padding(4, 5, 4, 5);
      this.tbxLedgerTypeInHindi.Name = "tbxLedgerTypeInHindi";
      this.tbxLedgerTypeInHindi.Size = new Size(316, 29);
      this.tbxLedgerTypeInHindi.TabIndex = 1;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(94, 15);
      this.label4.Name = "label4";
      this.label4.Size = new Size(136, 25);
      this.label4.TabIndex = 5;
      this.label4.Text = "Ledger Code";
      this.tbxLedgerType.BackColor = Color.Linen;
      this.tbxLedgerType.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerType.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerType.Location = new Point(236, 53);
      this.tbxLedgerType.Margin = new Padding(4, 5, 4, 5);
      this.tbxLedgerType.Name = "tbxLedgerType";
      this.tbxLedgerType.Size = new Size(316, 29);
      this.tbxLedgerType.TabIndex = 0;
      this.tbxLedgerType.Validating += new CancelEventHandler(this.tbxLedgerType_Validating);
      this.tbxLedgerCode.BackColor = Color.Linen;
      this.tbxLedgerCode.BorderStyle = BorderStyle.FixedSingle;
      this.tbxLedgerCode.CharacterCasing = CharacterCasing.Upper;
      this.tbxLedgerCode.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tbxLedgerCode.Location = new Point(236, 16);
      this.tbxLedgerCode.Margin = new Padding(4, 5, 4, 5);
      this.tbxLedgerCode.Name = "tbxLedgerCode";
      this.tbxLedgerCode.ReadOnly = true;
      this.tbxLedgerCode.Size = new Size(316, 29);
      this.tbxLedgerCode.TabIndex = 4;
      this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label9.AutoSize = true;
      this.label9.Cursor = Cursors.Hand;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.Cornsilk;
      this.label9.Location = new Point(517, 6);
      this.label9.Name = "label9";
      this.label9.Size = new Size(44, 15);
      this.label9.TabIndex = 1;
      this.label9.Text = "[Close]";
      this.label9.Click += new EventHandler(this.label9_Click);
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.White;
      this.label7.Location = new Point(3, 6);
      this.label7.Name = "label7";
      this.label7.Size = new Size(181, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "LEDGER MASTER - ADD";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(571, 264);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormLedgerMasterAddUpdate);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "ADD/UPDATE";
      this.Load += new EventHandler(this.FormLedgerMasterAddUpdate_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
