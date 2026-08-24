

using Glass;
using PawnManagement.Classes.JewelleryClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace PawnManagement.JewelleryForms
{
  public class FormItemNamesAddEdit : Form
  {
    private string formType = "";
    private string itemCode = "";
    private IContainer components = (IContainer) null;
    private TextBox tbxItemName;
    private Label lblPurity;
    private Label lblItemCode;
    private Label lblItemName;
    private Label lblItemType;
    private GlassButton btnSave;
    private Panel panel3;
    private Panel panel2;
    private Label lblStoneCharge;
    private Panel panel1;
    private Label lblHeading;
    private TextBox tbxPurchasePrice;
    private Label lblPurchasePrice;
    private TextBox tbxHallMark;
    private TextBox tbxCGst;
    private Label lblCGst;
    private Label lblHallMark;
    private TextBox tbxMakingCharge;
    private Label lblMakingCharge;
    private TextBox tbxMelting;
    private TextBox tbxWastage;
    private Label lblWastage;
    private Label lblMelting;
    private TextBox tbxItemCode;
    private ComboBox cbItemType;
    private TextBox tbxIGst;
    private Label lblIGst;
    private TextBox tbxSGst;
    private Label lblSGst;
    private ComboBox cbPurity;
    private ComboBox cbMakingCharge;
    private ComboBox cbStoneCharge;
    private TextBox tbxStoneCharge;
    private TextBox tbxSellingPrice;
    private Label lblSellingPrice;
    private TextBox tbxPurchasePurity;
    private Label lblPurchasePurity;
    private Label lblMrp;
    private TextBox tbxMrp;

    public FormItemNamesAddEdit() => this.InitializeComponent();

    public FormItemNamesAddEdit(string formTYPE)
    {
      this.formType = formTYPE;
      this.InitializeComponent();
    }

    public FormItemNamesAddEdit(string formTYPE, string itemCODE)
    {
      this.formType = formTYPE;
      this.itemCode = itemCODE;
      this.InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
        this.Close();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void FormItemNamesAddEdit_Load(object sender, EventArgs e)
    {
      this.Assign((Control) this);
      if (this.formType == "ADD")
      {
        ((Control) this.btnSave).Text = "&ADD";
        this.lblHeading.Text = "ADD";
      }
      else if (this.formType == "EDIT")
      {
        DataTable itemsBasedOnItemCode = ItemNamesMasterClass.getAllTheItemsBasedOnItemCode(this.itemCode);
        if (itemsBasedOnItemCode != null && itemsBasedOnItemCode.Rows.Count > 0)
        {
          this.tbxItemCode.Text = this.itemCode;
          this.tbxItemName.Text = itemsBasedOnItemCode.Rows[0]["ItemName"].ToString();
          this.cbItemType.Text = itemsBasedOnItemCode.Rows[0]["ItemType"].ToString();
          this.tbxPurchasePurity.Text = itemsBasedOnItemCode.Rows[0]["PurchasePurity"].ToString();
          this.cbPurity.Text = itemsBasedOnItemCode.Rows[0]["Purity"].ToString();
          this.tbxMelting.Text = itemsBasedOnItemCode.Rows[0]["Melting"].ToString();
          this.tbxWastage.Text = itemsBasedOnItemCode.Rows[0]["Wastage"].ToString();
          this.cbStoneCharge.Text = itemsBasedOnItemCode.Rows[0]["StoneChargeType"].ToString();
          this.tbxStoneCharge.Text = itemsBasedOnItemCode.Rows[0]["StoneCharge"].ToString();
          this.cbMakingCharge.Text = itemsBasedOnItemCode.Rows[0]["MakingChargeType"].ToString();
          this.tbxMakingCharge.Text = itemsBasedOnItemCode.Rows[0]["MakingCharge"].ToString();
          this.tbxHallMark.Text = itemsBasedOnItemCode.Rows[0]["HallMark"].ToString();
          this.tbxCGst.Text = itemsBasedOnItemCode.Rows[0]["CGst"].ToString();
          this.tbxSGst.Text = itemsBasedOnItemCode.Rows[0]["SGst"].ToString();
          this.tbxIGst.Text = itemsBasedOnItemCode.Rows[0]["IGst"].ToString();
          this.tbxPurchasePrice.Text = itemsBasedOnItemCode.Rows[0]["PurchasePrice"].ToString();
          this.tbxSellingPrice.Text = itemsBasedOnItemCode.Rows[0]["SellingPrice"].ToString();
          ((Control) this.btnSave).Text = "&UPDATE";
          this.lblHeading.Text = "EDIT";
          this.tbxItemCode.Enabled = false;
        }
      }
      else
        ((Control) this.btnSave).Enabled = false;
      List<string> stringList1 = new List<string>();
      this.cbItemType.Items.AddRange((object[]) ItemTypesClass.getAllTheItemTypes().ToArray());
      List<string> stringList2 = new List<string>();
      this.cbPurity.Items.AddRange((object[]) PurityMasterClass.getAllThePurity().ToArray());
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

    private void comboBoX_Enter(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.GreenYellow;

    private void comboBox_Leave(object sender, EventArgs e) => (sender as ComboBox).BackColor = Color.White;

    private void tbxAcceptOnlyInteger(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b')
        return;
      e.Handled = true;
    }

    private void tbxAcceptNoINPUT(object sender, KeyPressEventArgs e) => e.Handled = true;

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

    private bool checkIfAllTheEntriesMade()
    {
      switch (ItemTypesClass.getTypeBasedOnItemType(this.cbItemType.Text))
      {
        case "LIVE RATE":
          return this.checkIfAllTheEntriesAreMadeLiveRate();
        case "PER GRAM":
          return this.checkIfAllTheEntriesAreMadePerGram();
        case "MRP":
          return this.checkIfAllTheEntriesAreMadeMRP();
        default:
          return false;
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.checkIfAllTheEntriesMade())
        return;
      if (this.formType == "ADD")
      {
        if (!ItemNamesMasterClass.checkIfItemCodeAlreadyExists(this.tbxItemCode.Text))
        {
          if (!ItemNamesMasterClass.checkIfItemNameAlreadyExists(this.tbxItemName.Text))
          {
            ItemNamesMasterClass.addItem(this.tbxItemCode.Text, this.cbItemType.Text, this.tbxItemName.Text, double.Parse(this.tbxPurchasePurity.Text), this.cbPurity.Text, double.Parse(this.tbxMelting.Text), double.Parse(this.tbxWastage.Text), this.cbStoneCharge.Text, double.Parse(this.tbxStoneCharge.Text), this.cbMakingCharge.Text, double.Parse(this.tbxMakingCharge.Text), double.Parse(this.tbxHallMark.Text), double.Parse(this.tbxCGst.Text), double.Parse(this.tbxSGst.Text), double.Parse(this.tbxIGst.Text), double.Parse(this.tbxPurchasePrice.Text), double.Parse(this.tbxSellingPrice.Text), double.Parse(this.tbxMrp.Text), FormMain.username, DateTime.Now, FormMain.username, DateTime.Now);
            this.Close();
          }
          else
            this.tbxItemName.Select();
        }
        else
          this.tbxItemCode.Select();
      }
      else if (this.formType == "EDIT")
      {
        if (ItemNamesMasterClass.checkIfItemCodeAlreadyExists(this.tbxItemCode.Text))
        {
          if (!ItemNamesMasterClass.checkIfItemNameAlreadyExistsExceptThisItemCode(this.tbxItemName.Text, this.tbxItemCode.Text))
          {
            ItemNamesMasterClass.editItem(this.tbxItemCode.Text, this.cbItemType.Text, this.tbxItemName.Text, double.Parse(this.tbxPurchasePurity.Text), this.cbPurity.Text, double.Parse(this.tbxMelting.Text), double.Parse(this.tbxWastage.Text), this.cbStoneCharge.Text, double.Parse(this.tbxStoneCharge.Text), this.cbMakingCharge.Text, double.Parse(this.tbxMakingCharge.Text), double.Parse(this.tbxHallMark.Text), double.Parse(this.tbxCGst.Text), double.Parse(this.tbxSGst.Text), double.Parse(this.tbxIGst.Text), double.Parse(this.tbxPurchasePrice.Text), double.Parse(this.tbxSellingPrice.Text), double.Parse(this.tbxMrp.Text), FormMain.username, DateTime.Now);
            this.Close();
          }
          else
            this.tbxItemName.Select();
        }
        else
        {
          int num = (int) MessageBox.Show("Error While updating");
          this.Close();
        }
      }
    }

    private void tbxAccepDate_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if (char.IsDigit(keyChar) || keyChar == '\b' || keyChar == '/')
        return;
      e.Handled = true;
    }

    private void tbxItemCode_Validating(object sender, CancelEventArgs e)
    {
      if (ItemNamesMasterClass.checkIfItemCodeAlreadyExists(this.tbxItemCode.Text))
        this.tbxItemCode.ForeColor = Color.Red;
      else
        this.tbxItemCode.ForeColor = Color.Blue;
    }

    private void tbxItemName_Validating(object sender, CancelEventArgs e)
    {
      if (this.formType == "ADD")
      {
        if (ItemNamesMasterClass.checkIfItemNameAlreadyExists(this.tbxItemName.Text))
          this.tbxItemName.ForeColor = Color.Red;
        else
          this.tbxItemName.ForeColor = Color.Blue;
      }
      else
      {
        if (!(this.formType == "EDIT"))
          return;
        if (ItemNamesMasterClass.checkIfItemNameAlreadyExistsExceptThisItemCode(this.tbxItemName.Text, this.tbxItemCode.Text))
          this.tbxItemName.ForeColor = Color.Red;
        else
          this.tbxItemName.ForeColor = Color.Blue;
      }
    }

    private void cbPurity_SelectedIndexChanged(object sender, EventArgs e) => this.tbxMelting.Text = PurityMasterClass.getTheMeltingForThisPurity(this.cbPurity.Text).ToString();

    private void label9_Click(object sender, EventArgs e)
    {
    }

    private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (ItemTypesClass.getTypeBasedOnItemType(this.cbItemType.Text))
      {
        case "LIVE RATE":
          this.lblPurchasePrice.Enabled = false;
          this.tbxPurchasePrice.Enabled = false;
          this.lblSellingPrice.Enabled = false;
          this.tbxSellingPrice.Enabled = false;
          this.lblMrp.Enabled = false;
          this.tbxMrp.Enabled = false;
          this.lblWastage.Enabled = true;
          this.tbxWastage.Enabled = true;
          this.lblStoneCharge.Enabled = true;
          this.tbxStoneCharge.Enabled = true;
          this.cbStoneCharge.Enabled = true;
          this.lblMakingCharge.Enabled = true;
          this.tbxMakingCharge.Enabled = true;
          this.cbMakingCharge.Enabled = true;
          this.lblHallMark.Enabled = true;
          this.tbxHallMark.Enabled = true;
          this.lblPurchasePurity.Enabled = true;
          this.tbxPurchasePurity.Enabled = true;
          this.lblPurity.Enabled = true;
          this.cbPurity.Enabled = true;
          this.lblMelting.Enabled = true;
          this.tbxMelting.Enabled = true;
          break;
        case "PER GRAM":
          this.lblWastage.Enabled = false;
          this.tbxWastage.Enabled = false;
          this.lblStoneCharge.Enabled = false;
          this.tbxStoneCharge.Enabled = false;
          this.cbStoneCharge.Enabled = false;
          this.lblMakingCharge.Enabled = false;
          this.tbxMakingCharge.Enabled = false;
          this.cbMakingCharge.Enabled = false;
          this.lblHallMark.Enabled = false;
          this.tbxHallMark.Enabled = false;
          this.lblPurchasePrice.Enabled = true;
          this.tbxPurchasePrice.Enabled = true;
          this.lblSellingPrice.Enabled = true;
          this.tbxSellingPrice.Enabled = true;
          this.lblMrp.Enabled = false;
          this.tbxMrp.Enabled = false;
          this.lblPurchasePurity.Enabled = true;
          this.tbxPurchasePurity.Enabled = true;
          this.lblPurity.Enabled = true;
          this.cbPurity.Enabled = true;
          this.lblMelting.Enabled = true;
          this.tbxMelting.Enabled = true;
          break;
        case "MRP":
          this.lblWastage.Enabled = false;
          this.tbxWastage.Enabled = false;
          this.lblStoneCharge.Enabled = false;
          this.tbxStoneCharge.Enabled = false;
          this.cbStoneCharge.Enabled = false;
          this.lblMakingCharge.Enabled = false;
          this.tbxMakingCharge.Enabled = false;
          this.cbMakingCharge.Enabled = false;
          this.lblHallMark.Enabled = false;
          this.tbxHallMark.Enabled = false;
          this.lblPurchasePurity.Enabled = false;
          this.tbxPurchasePurity.Enabled = false;
          this.lblPurity.Enabled = false;
          this.cbPurity.Enabled = false;
          this.lblMelting.Enabled = false;
          this.tbxMelting.Enabled = false;
          this.lblPurchasePrice.Enabled = true;
          this.tbxPurchasePrice.Enabled = true;
          this.lblSellingPrice.Enabled = true;
          this.tbxSellingPrice.Enabled = true;
          this.lblMrp.Enabled = true;
          this.tbxMrp.Enabled = true;
          break;
      }
    }

    private void cbStoneCharge_Enter(object sender, EventArgs e)
    {
      if (!(this.cbStoneCharge.Text == ""))
        return;
      this.cbStoneCharge.SelectedIndex = 0;
    }

    private void cbMakingCharge_Enter(object sender, EventArgs e)
    {
      if (!(this.cbMakingCharge.Text == ""))
        return;
      this.cbMakingCharge.SelectedIndex = 0;
    }

    private void cbItemType_Enter(object sender, EventArgs e)
    {
      if (!(this.cbItemType.Text == ""))
        return;
      this.cbItemType.SelectedIndex = 0;
    }

    private bool checkIfAllTheEntriesAreMadeLiveRate()
    {
      if (this.tbxItemCode.Text.Trim() != "")
      {
        this.lblItemCode.ForeColor = Color.Black;
        if (this.cbItemType.Text.Trim() != "" && this.cbItemType.Items.Contains((object) this.cbItemType.Text))
        {
          this.lblItemType.ForeColor = Color.Black;
          if (this.tbxItemName.Text.Trim() != "")
          {
            this.lblItemName.ForeColor = Color.Black;
            if (this.cbPurity.Text.Trim() != "")
            {
              this.lblPurity.ForeColor = Color.Black;
              if (this.cbStoneCharge.Text.Trim() != "")
              {
                this.lblStoneCharge.ForeColor = Color.Black;
                if (this.cbMakingCharge.Text.Trim() != "")
                {
                  this.lblMakingCharge.ForeColor = Color.Black;
                  if (this.tbxStoneCharge.Text.Trim() != "")
                  {
                    this.lblStoneCharge.ForeColor = Color.Black;
                    if (this.tbxMelting.Text.Trim() != "")
                    {
                      this.lblMelting.ForeColor = Color.Black;
                      if (this.tbxWastage.Text.Trim() != "")
                      {
                        this.lblWastage.ForeColor = Color.Black;
                        if (this.tbxMakingCharge.Text.Trim() != "")
                        {
                          this.lblMakingCharge.ForeColor = Color.Black;
                          if (this.tbxHallMark.Text.Trim() != "")
                          {
                            this.lblHallMark.ForeColor = Color.Black;
                            if (this.tbxCGst.Text.Trim() != "")
                            {
                              this.lblCGst.ForeColor = Color.Black;
                              if (this.tbxSGst.Text.Trim() != "")
                              {
                                this.lblSGst.ForeColor = Color.Black;
                                if (this.tbxIGst.Text.Trim() != "")
                                {
                                  this.lblIGst.ForeColor = Color.Black;
                                  return true;
                                }
                                this.tbxIGst.Select();
                                this.lblIGst.ForeColor = Color.Red;
                                return false;
                              }
                              this.tbxSGst.Select();
                              this.lblSGst.ForeColor = Color.Red;
                              return false;
                            }
                            this.tbxCGst.Select();
                            this.lblCGst.ForeColor = Color.Red;
                            return false;
                          }
                          this.tbxHallMark.Select();
                          this.lblHallMark.ForeColor = Color.Red;
                          return false;
                        }
                        this.tbxMakingCharge.Select();
                        this.lblMakingCharge.ForeColor = Color.Red;
                        return false;
                      }
                      this.tbxWastage.Select();
                      this.lblWastage.ForeColor = Color.Red;
                      return false;
                    }
                    this.tbxMelting.Select();
                    this.lblMelting.ForeColor = Color.Red;
                    return false;
                  }
                  this.tbxStoneCharge.Select();
                  this.lblStoneCharge.ForeColor = Color.Red;
                  return false;
                }
                this.cbMakingCharge.Select();
                this.lblMakingCharge.ForeColor = Color.Red;
                return false;
              }
              this.cbStoneCharge.Select();
              this.lblStoneCharge.ForeColor = Color.Red;
              return false;
            }
            this.cbPurity.Select();
            this.lblPurity.ForeColor = Color.Red;
            return false;
          }
          this.tbxItemName.Select();
          this.lblItemName.ForeColor = Color.Red;
          return false;
        }
        this.cbItemType.Select();
        this.lblItemType.ForeColor = Color.Red;
        return false;
      }
      this.tbxItemCode.Select();
      this.lblItemCode.ForeColor = Color.Red;
      return false;
    }

    private bool checkIfAllTheEntriesAreMadePerGram()
    {
      if (this.tbxItemCode.Text.Trim() != "")
      {
        this.lblItemCode.ForeColor = Color.Black;
        if (this.cbItemType.Text.Trim() != "")
        {
          this.lblItemType.ForeColor = Color.Black;
          if (this.tbxItemName.Text.Trim() != "")
          {
            this.lblItemName.ForeColor = Color.Black;
            if (this.cbPurity.Text.Trim() != "")
            {
              this.lblPurity.ForeColor = Color.Black;
              if (this.tbxMelting.Text.Trim() != "")
              {
                this.lblMelting.ForeColor = Color.Black;
                if (this.tbxCGst.Text.Trim() != "")
                {
                  this.lblCGst.ForeColor = Color.Black;
                  if (this.tbxSGst.Text.Trim() != "")
                  {
                    this.lblSGst.ForeColor = Color.Black;
                    if (this.tbxIGst.Text.Trim() != "")
                    {
                      this.lblIGst.ForeColor = Color.Black;
                      if (this.tbxPurchasePrice.Text.Trim() != "")
                      {
                        this.lblPurchasePrice.ForeColor = Color.Black;
                        if (this.tbxSellingPrice.Text.Trim() != "")
                        {
                          this.lblSellingPrice.ForeColor = Color.Black;
                          return true;
                        }
                        this.tbxSellingPrice.Select();
                        this.lblSellingPrice.ForeColor = Color.Red;
                        return false;
                      }
                      this.tbxPurchasePrice.Select();
                      this.lblPurchasePrice.ForeColor = Color.Red;
                      return false;
                    }
                    this.tbxIGst.Select();
                    this.lblIGst.ForeColor = Color.Red;
                    return false;
                  }
                  this.tbxSGst.Select();
                  this.lblSGst.ForeColor = Color.Red;
                  return false;
                }
                this.tbxCGst.Select();
                this.lblCGst.ForeColor = Color.Red;
                return false;
              }
              this.tbxMelting.Select();
              this.lblMelting.ForeColor = Color.Red;
              return false;
            }
            this.cbPurity.Select();
            this.lblPurity.ForeColor = Color.Red;
            return false;
          }
          this.tbxItemName.Select();
          this.lblItemName.ForeColor = Color.Red;
          return false;
        }
        this.cbItemType.Select();
        this.lblItemType.ForeColor = Color.Red;
        return false;
      }
      this.tbxItemCode.Select();
      this.lblItemCode.ForeColor = Color.Red;
      return false;
    }

    private void tbxPurchasePurity_TextChanged(object sender, EventArgs e)
    {
      if (!((sender as TextBox).Text.Trim() == ""))
        return;
      (sender as TextBox).Text = "0";
    }

    private void cbItemType_Validating(object sender, CancelEventArgs e)
    {
      if (!this.cbItemType.Items.Contains((object) this.cbItemType.Text))
        this.cbItemType.Select();
      switch (ItemTypesClass.getTypeBasedOnItemType(this.cbItemType.Text))
      {
        case "LIVE RATE":
          this.lblPurchasePrice.Enabled = false;
          this.tbxPurchasePrice.Enabled = false;
          this.lblSellingPrice.Enabled = false;
          this.tbxSellingPrice.Enabled = false;
          this.lblMrp.Enabled = false;
          this.tbxMrp.Enabled = false;
          this.lblWastage.Enabled = true;
          this.tbxWastage.Enabled = true;
          this.lblStoneCharge.Enabled = true;
          this.tbxStoneCharge.Enabled = true;
          this.cbStoneCharge.Enabled = true;
          this.lblMakingCharge.Enabled = true;
          this.tbxMakingCharge.Enabled = true;
          this.cbMakingCharge.Enabled = true;
          this.lblHallMark.Enabled = true;
          this.tbxHallMark.Enabled = true;
          this.lblPurchasePurity.Enabled = true;
          this.tbxPurchasePurity.Enabled = true;
          this.lblPurity.Enabled = true;
          this.cbPurity.Enabled = true;
          this.lblMelting.Enabled = true;
          this.tbxMelting.Enabled = true;
          break;
        case "PER GRAM":
          this.lblWastage.Enabled = false;
          this.tbxWastage.Enabled = false;
          this.lblStoneCharge.Enabled = false;
          this.tbxStoneCharge.Enabled = false;
          this.cbStoneCharge.Enabled = false;
          this.lblMakingCharge.Enabled = false;
          this.tbxMakingCharge.Enabled = false;
          this.cbMakingCharge.Enabled = false;
          this.lblHallMark.Enabled = false;
          this.tbxHallMark.Enabled = false;
          this.lblPurchasePrice.Enabled = true;
          this.tbxPurchasePrice.Enabled = true;
          this.lblSellingPrice.Enabled = true;
          this.tbxSellingPrice.Enabled = true;
          this.lblMrp.Enabled = false;
          this.tbxMrp.Enabled = false;
          this.lblPurchasePurity.Enabled = true;
          this.tbxPurchasePurity.Enabled = true;
          this.lblPurity.Enabled = true;
          this.cbPurity.Enabled = true;
          this.lblMelting.Enabled = true;
          this.tbxMelting.Enabled = true;
          break;
        case "MRP":
          this.lblWastage.Enabled = false;
          this.tbxWastage.Enabled = false;
          this.lblStoneCharge.Enabled = false;
          this.tbxStoneCharge.Enabled = false;
          this.cbStoneCharge.Enabled = false;
          this.lblMakingCharge.Enabled = false;
          this.tbxMakingCharge.Enabled = false;
          this.cbMakingCharge.Enabled = false;
          this.lblHallMark.Enabled = false;
          this.tbxHallMark.Enabled = false;
          this.lblPurchasePurity.Enabled = false;
          this.tbxPurchasePurity.Enabled = false;
          this.lblPurity.Enabled = false;
          this.cbPurity.Enabled = false;
          this.lblMelting.Enabled = false;
          this.tbxMelting.Enabled = false;
          this.lblPurchasePrice.Enabled = true;
          this.tbxPurchasePrice.Enabled = true;
          this.lblSellingPrice.Enabled = true;
          this.tbxSellingPrice.Enabled = true;
          this.lblMrp.Enabled = true;
          this.tbxMrp.Enabled = true;
          break;
      }
    }

    private void cbPurity_Validating(object sender, CancelEventArgs e)
    {
      if (this.cbPurity.Items.Contains((object) this.cbPurity.Text))
        return;
      this.cbPurity.Select();
    }

    private void cbStoneCharge_Validating(object sender, CancelEventArgs e)
    {
      if ((sender as ComboBox).Items.Contains((object) (sender as ComboBox).Text))
        return;
      (sender as ComboBox).Select();
    }

    private void cbMakingCharge_Validating(object sender, CancelEventArgs e)
    {
      if ((sender as ComboBox).Items.Contains((object) (sender as ComboBox).Text))
        return;
      (sender as ComboBox).Select();
    }

    private void tbxCGst_TextChanged(object sender, EventArgs e)
    {
      if ((sender as TextBox).Text.Trim() == "")
        (sender as TextBox).Text = "0";
      this.tbxSGst.Text = this.tbxCGst.Text;
      this.tbxIGst.Text = (double.Parse(this.tbxCGst.Text) + double.Parse(this.tbxSGst.Text)).ToString();
    }

    private void tbxSGst_TextChanged(object sender, EventArgs e)
    {
      if ((sender as TextBox).Text.Trim() == "")
        (sender as TextBox).Text = "0";
      this.tbxCGst.Text = this.tbxSGst.Text;
      this.tbxIGst.Text = (double.Parse(this.tbxCGst.Text) + double.Parse(this.tbxSGst.Text)).ToString();
    }

    private bool checkIfAllTheEntriesAreMadeMRP()
    {
      if (this.tbxItemCode.Text.Trim() != "")
      {
        this.lblItemCode.ForeColor = Color.Black;
        if (this.cbItemType.Text.Trim() != "")
        {
          this.lblItemType.ForeColor = Color.Black;
          if (this.tbxItemName.Text.Trim() != "")
          {
            this.lblItemName.ForeColor = Color.Black;
            if (this.tbxCGst.Text.Trim() != "")
            {
              this.lblCGst.ForeColor = Color.Black;
              if (this.tbxSGst.Text.Trim() != "")
              {
                this.lblSGst.ForeColor = Color.Black;
                if (this.tbxIGst.Text.Trim() != "")
                {
                  this.lblIGst.ForeColor = Color.Black;
                  if (this.tbxPurchasePrice.Text.Trim() != "")
                  {
                    this.lblPurchasePrice.ForeColor = Color.Black;
                    if (this.tbxSellingPrice.Text.Trim() != "")
                    {
                      this.lblSellingPrice.ForeColor = Color.Black;
                      if (this.tbxMrp.Text.Trim() != "")
                      {
                        this.lblMrp.ForeColor = Color.Black;
                        return true;
                      }
                      this.tbxMrp.Select();
                      this.lblMrp.ForeColor = Color.Red;
                      return false;
                    }
                    this.tbxSellingPrice.Select();
                    this.lblSellingPrice.ForeColor = Color.Red;
                    return false;
                  }
                  this.tbxPurchasePrice.Select();
                  this.lblPurchasePrice.ForeColor = Color.Red;
                  return false;
                }
                this.tbxIGst.Select();
                this.lblIGst.ForeColor = Color.Red;
                return false;
              }
              this.tbxSGst.Select();
              this.lblSGst.ForeColor = Color.Red;
              return false;
            }
            this.tbxCGst.Select();
            this.lblCGst.ForeColor = Color.Red;
            return false;
          }
          this.tbxItemName.Select();
          this.lblItemName.ForeColor = Color.Red;
          return false;
        }
        this.cbItemType.Select();
        this.lblItemType.ForeColor = Color.Red;
        return false;
      }
      this.tbxItemCode.Select();
      this.lblItemCode.ForeColor = Color.Red;
      return false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tbxItemName = new TextBox();
      this.lblPurity = new Label();
      this.lblItemCode = new Label();
      this.lblItemName = new Label();
      this.lblItemType = new Label();
      this.btnSave = new GlassButton();
      this.panel3 = new Panel();
      this.panel2 = new Panel();
      this.lblMrp = new Label();
      this.tbxMrp = new TextBox();
      this.tbxPurchasePurity = new TextBox();
      this.lblPurchasePurity = new Label();
      this.tbxSellingPrice = new TextBox();
      this.lblSellingPrice = new Label();
      this.cbMakingCharge = new ComboBox();
      this.cbStoneCharge = new ComboBox();
      this.cbPurity = new ComboBox();
      this.tbxIGst = new TextBox();
      this.lblIGst = new Label();
      this.tbxSGst = new TextBox();
      this.lblSGst = new Label();
      this.cbItemType = new ComboBox();
      this.tbxPurchasePrice = new TextBox();
      this.lblPurchasePrice = new Label();
      this.tbxHallMark = new TextBox();
      this.tbxCGst = new TextBox();
      this.lblCGst = new Label();
      this.lblHallMark = new Label();
      this.tbxMakingCharge = new TextBox();
      this.lblMakingCharge = new Label();
      this.tbxMelting = new TextBox();
      this.tbxWastage = new TextBox();
      this.lblWastage = new Label();
      this.lblMelting = new Label();
      this.tbxItemCode = new TextBox();
      this.tbxStoneCharge = new TextBox();
      this.lblStoneCharge = new Label();
      this.panel1 = new Panel();
      this.lblHeading = new Label();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tbxItemName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxItemName.Location = new Point(247, 87);
      this.tbxItemName.MaxLength = 50;
      this.tbxItemName.Name = "tbxItemName";
      this.tbxItemName.Size = new Size(297, 31);
      this.tbxItemName.TabIndex = 2;
      this.tbxItemName.Validating += new CancelEventHandler(this.tbxItemName_Validating);
      this.lblPurity.AutoSize = true;
      this.lblPurity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPurity.ForeColor = Color.DarkBlue;
      this.lblPurity.Location = new Point(152, 158);
      this.lblPurity.Name = "lblPurity";
      this.lblPurity.Size = new Size(89, 25);
      this.lblPurity.TabIndex = 21;
      this.lblPurity.Text = "PURITY";
      this.lblItemCode.AutoSize = true;
      this.lblItemCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblItemCode.ForeColor = Color.DarkBlue;
      this.lblItemCode.Location = new Point(113, 56);
      this.lblItemCode.Name = "lblItemCode";
      this.lblItemCode.Size = new Size(128, 25);
      this.lblItemCode.TabIndex = 19;
      this.lblItemCode.Text = "ITEM CODE";
      this.lblItemName.AutoSize = true;
      this.lblItemName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblItemName.ForeColor = Color.DarkBlue;
      this.lblItemName.Location = new Point(112, 90);
      this.lblItemName.Name = "lblItemName";
      this.lblItemName.Size = new Size(129, 25);
      this.lblItemName.TabIndex = 20;
      this.lblItemName.Text = "ITEM NAME";
      this.lblItemType.AutoSize = true;
      this.lblItemType.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblItemType.ForeColor = Color.DarkBlue;
      this.lblItemType.Location = new Point(117, 22);
      this.lblItemType.Name = "lblItemType";
      this.lblItemType.Size = new Size(124, 25);
      this.lblItemType.TabIndex = 18;
      this.lblItemType.Text = "ITEM TYPE";
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
      ((Control) this.btnSave).Size = new Size(559, 35);
      ((Control) this.btnSave).TabIndex = 0;
      ((Control) this.btnSave).Text = "&ADD";
      ((Control) this.btnSave).Click += new EventHandler(this.btnSave_Click);
      this.panel3.Anchor = AnchorStyles.None;
      this.panel3.BackColor = Color.WhiteSmoke;
      this.panel3.BorderStyle = BorderStyle.FixedSingle;
      this.panel3.Controls.Add((Control) this.btnSave);
      this.panel3.Location = new Point(15, 630);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(561, 37);
      this.panel3.TabIndex = 5;
      this.panel2.Anchor = AnchorStyles.None;
      this.panel2.BorderStyle = BorderStyle.FixedSingle;
      this.panel2.Controls.Add((Control) this.lblMrp);
      this.panel2.Controls.Add((Control) this.tbxMrp);
      this.panel2.Controls.Add((Control) this.tbxPurchasePurity);
      this.panel2.Controls.Add((Control) this.lblPurchasePurity);
      this.panel2.Controls.Add((Control) this.tbxSellingPrice);
      this.panel2.Controls.Add((Control) this.lblSellingPrice);
      this.panel2.Controls.Add((Control) this.cbMakingCharge);
      this.panel2.Controls.Add((Control) this.cbStoneCharge);
      this.panel2.Controls.Add((Control) this.cbPurity);
      this.panel2.Controls.Add((Control) this.tbxIGst);
      this.panel2.Controls.Add((Control) this.lblIGst);
      this.panel2.Controls.Add((Control) this.tbxSGst);
      this.panel2.Controls.Add((Control) this.lblSGst);
      this.panel2.Controls.Add((Control) this.cbItemType);
      this.panel2.Controls.Add((Control) this.tbxPurchasePrice);
      this.panel2.Controls.Add((Control) this.lblPurchasePrice);
      this.panel2.Controls.Add((Control) this.tbxHallMark);
      this.panel2.Controls.Add((Control) this.tbxCGst);
      this.panel2.Controls.Add((Control) this.lblCGst);
      this.panel2.Controls.Add((Control) this.lblHallMark);
      this.panel2.Controls.Add((Control) this.tbxMakingCharge);
      this.panel2.Controls.Add((Control) this.lblMakingCharge);
      this.panel2.Controls.Add((Control) this.tbxMelting);
      this.panel2.Controls.Add((Control) this.tbxWastage);
      this.panel2.Controls.Add((Control) this.lblWastage);
      this.panel2.Controls.Add((Control) this.lblMelting);
      this.panel2.Controls.Add((Control) this.tbxItemCode);
      this.panel2.Controls.Add((Control) this.tbxStoneCharge);
      this.panel2.Controls.Add((Control) this.lblStoneCharge);
      this.panel2.Controls.Add((Control) this.tbxItemName);
      this.panel2.Controls.Add((Control) this.lblPurity);
      this.panel2.Controls.Add((Control) this.lblItemCode);
      this.panel2.Controls.Add((Control) this.lblItemName);
      this.panel2.Controls.Add((Control) this.lblItemType);
      this.panel2.Location = new Point(15, 53);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(561, 587);
      this.panel2.TabIndex = 1;
      this.lblMrp.AutoSize = true;
      this.lblMrp.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMrp.ForeColor = Color.DarkBlue;
      this.lblMrp.Location = new Point(181, 533);
      this.lblMrp.Name = "lblMrp";
      this.lblMrp.Size = new Size(59, 25);
      this.lblMrp.TabIndex = 31;
      this.lblMrp.Text = "MRP";
      this.tbxMrp.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxMrp.Location = new Point(247, 530);
      this.tbxMrp.MaxLength = 14;
      this.tbxMrp.Name = "tbxMrp";
      this.tbxMrp.Size = new Size(297, 31);
      this.tbxMrp.TabIndex = 17;
      this.tbxMrp.Text = "0";
      this.tbxMrp.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxMrp.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxPurchasePurity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxPurchasePurity.Location = new Point(247, 121);
      this.tbxPurchasePurity.MaxLength = 14;
      this.tbxPurchasePurity.Name = "tbxPurchasePurity";
      this.tbxPurchasePurity.Size = new Size(297, 31);
      this.tbxPurchasePurity.TabIndex = 3;
      this.tbxPurchasePurity.Text = "0";
      this.tbxPurchasePurity.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxPurchasePurity.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblPurchasePurity.AutoSize = true;
      this.lblPurchasePurity.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPurchasePurity.ForeColor = Color.DarkBlue;
      this.lblPurchasePurity.Location = new Point(30, 124);
      this.lblPurchasePurity.Name = "lblPurchasePurity";
      this.lblPurchasePurity.Size = new Size(211, 25);
      this.lblPurchasePurity.TabIndex = 20;
      this.lblPurchasePurity.Text = "PURCHASE PURITY";
      this.tbxSellingPrice.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxSellingPrice.Location = new Point(247, 496);
      this.tbxSellingPrice.MaxLength = 14;
      this.tbxSellingPrice.Name = "tbxSellingPrice";
      this.tbxSellingPrice.Size = new Size(297, 31);
      this.tbxSellingPrice.TabIndex = 16;
      this.tbxSellingPrice.Text = "0";
      this.tbxSellingPrice.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxSellingPrice.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblSellingPrice.AutoSize = true;
      this.lblSellingPrice.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSellingPrice.ForeColor = Color.DarkBlue;
      this.lblSellingPrice.Location = new Point(72, 498);
      this.lblSellingPrice.Name = "lblSellingPrice";
      this.lblSellingPrice.Size = new Size(169, 25);
      this.lblSellingPrice.TabIndex = 29;
      this.lblSellingPrice.Text = "SELLING PRICE";
      this.cbMakingCharge.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbMakingCharge.FormattingEnabled = true;
      this.cbMakingCharge.Items.AddRange(new object[2]
      {
        (object) "PER GRAM",
        (object) "FLAT"
      });
      this.cbMakingCharge.Location = new Point(248, 292);
      this.cbMakingCharge.Name = "cbMakingCharge";
      this.cbMakingCharge.Size = new Size(161, 32);
      this.cbMakingCharge.TabIndex = 9;
      this.cbMakingCharge.Enter += new EventHandler(this.cbMakingCharge_Enter);
      this.cbMakingCharge.Validating += new CancelEventHandler(this.cbMakingCharge_Validating);
      this.cbStoneCharge.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbStoneCharge.FormattingEnabled = true;
      this.cbStoneCharge.Items.AddRange(new object[2]
      {
        (object) "PER STONE",
        (object) "FLAT"
      });
      this.cbStoneCharge.Location = new Point(247, 257);
      this.cbStoneCharge.Name = "cbStoneCharge";
      this.cbStoneCharge.Size = new Size(161, 32);
      this.cbStoneCharge.TabIndex = 7;
      this.cbStoneCharge.Enter += new EventHandler(this.cbStoneCharge_Enter);
      this.cbStoneCharge.Validating += new CancelEventHandler(this.cbStoneCharge_Validating);
      this.cbPurity.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbPurity.FormattingEnabled = true;
      this.cbPurity.Location = new Point(247, 155);
      this.cbPurity.Name = "cbPurity";
      this.cbPurity.Size = new Size(297, 32);
      this.cbPurity.TabIndex = 4;
      this.cbPurity.SelectedIndexChanged += new EventHandler(this.cbPurity_SelectedIndexChanged);
      this.cbPurity.Validating += new CancelEventHandler(this.cbPurity_Validating);
      this.tbxIGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxIGst.Location = new Point(247, 428);
      this.tbxIGst.MaxLength = 14;
      this.tbxIGst.Name = "tbxIGst";
      this.tbxIGst.Size = new Size(297, 31);
      this.tbxIGst.TabIndex = 14;
      this.tbxIGst.Text = "0";
      this.tbxIGst.TextChanged += new EventHandler(this.tbxCGst_TextChanged);
      this.tbxIGst.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblIGst.AutoSize = true;
      this.lblIGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblIGst.ForeColor = Color.DarkBlue;
      this.lblIGst.Location = new Point(181, 430);
      this.lblIGst.Name = "lblIGst";
      this.lblIGst.Size = new Size(60, 25);
      this.lblIGst.TabIndex = 26;
      this.lblIGst.Text = "IGST";
      this.tbxSGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxSGst.Location = new Point(247, 394);
      this.tbxSGst.MaxLength = 14;
      this.tbxSGst.Name = "tbxSGst";
      this.tbxSGst.Size = new Size(297, 31);
      this.tbxSGst.TabIndex = 13;
      this.tbxSGst.Text = "0";
      this.tbxSGst.TextChanged += new EventHandler(this.tbxSGst_TextChanged);
      this.tbxSGst.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblSGst.AutoSize = true;
      this.lblSGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSGst.ForeColor = Color.DarkBlue;
      this.lblSGst.Location = new Point(172, 396);
      this.lblSGst.Name = "lblSGst";
      this.lblSGst.Size = new Size(69, 25);
      this.lblSGst.TabIndex = 25;
      this.lblSGst.Text = "SGST";
      this.cbItemType.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbItemType.FormattingEnabled = true;
      this.cbItemType.Location = new Point(247, 18);
      this.cbItemType.Name = "cbItemType";
      this.cbItemType.Size = new Size(297, 32);
      this.cbItemType.TabIndex = 0;
      this.cbItemType.SelectedIndexChanged += new EventHandler(this.cbItemType_SelectedIndexChanged);
      this.cbItemType.Enter += new EventHandler(this.cbItemType_Enter);
      this.cbItemType.Validating += new CancelEventHandler(this.cbItemType_Validating);
      this.tbxPurchasePrice.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxPurchasePrice.Location = new Point(247, 462);
      this.tbxPurchasePrice.MaxLength = 14;
      this.tbxPurchasePrice.Name = "tbxPurchasePrice";
      this.tbxPurchasePrice.Size = new Size(297, 31);
      this.tbxPurchasePrice.TabIndex = 15;
      this.tbxPurchasePrice.Text = "0";
      this.tbxPurchasePrice.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxPurchasePrice.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblPurchasePrice.AutoSize = true;
      this.lblPurchasePrice.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPurchasePrice.ForeColor = Color.DarkBlue;
      this.lblPurchasePrice.Location = new Point(44, 464);
      this.lblPurchasePrice.Name = "lblPurchasePrice";
      this.lblPurchasePrice.Size = new Size(197, 25);
      this.lblPurchasePrice.TabIndex = 27;
      this.lblPurchasePrice.Text = "PURCHASE PRICE";
      this.lblPurchasePrice.Click += new EventHandler(this.label9_Click);
      this.tbxHallMark.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxHallMark.Location = new Point(247, 326);
      this.tbxHallMark.MaxLength = 14;
      this.tbxHallMark.Name = "tbxHallMark";
      this.tbxHallMark.Size = new Size(297, 31);
      this.tbxHallMark.TabIndex = 11;
      this.tbxHallMark.Text = "0";
      this.tbxHallMark.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxHallMark.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.tbxCGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxCGst.Location = new Point(247, 360);
      this.tbxCGst.MaxLength = 14;
      this.tbxCGst.Name = "tbxCGst";
      this.tbxCGst.Size = new Size(297, 31);
      this.tbxCGst.TabIndex = 12;
      this.tbxCGst.Text = "0";
      this.tbxCGst.TextChanged += new EventHandler(this.tbxCGst_TextChanged);
      this.tbxCGst.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblCGst.AutoSize = true;
      this.lblCGst.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblCGst.ForeColor = Color.DarkBlue;
      this.lblCGst.Location = new Point(171, 362);
      this.lblCGst.Name = "lblCGst";
      this.lblCGst.Size = new Size(70, 25);
      this.lblCGst.TabIndex = 24;
      this.lblCGst.Text = "CGST";
      this.lblHallMark.AutoSize = true;
      this.lblHallMark.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHallMark.ForeColor = Color.DarkBlue;
      this.lblHallMark.Location = new Point(109, 328);
      this.lblHallMark.Name = "lblHallMark";
      this.lblHallMark.Size = new Size(132, 25);
      this.lblHallMark.TabIndex = 23;
      this.lblHallMark.Text = "HALL MARK";
      this.tbxMakingCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxMakingCharge.Location = new Point(414, 292);
      this.tbxMakingCharge.MaxLength = 14;
      this.tbxMakingCharge.Name = "tbxMakingCharge";
      this.tbxMakingCharge.Size = new Size(130, 31);
      this.tbxMakingCharge.TabIndex = 10;
      this.tbxMakingCharge.Text = "0";
      this.tbxMakingCharge.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxMakingCharge.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblMakingCharge.AutoSize = true;
      this.lblMakingCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMakingCharge.ForeColor = Color.DarkBlue;
      this.lblMakingCharge.Location = new Point(52, 294);
      this.lblMakingCharge.Name = "lblMakingCharge";
      this.lblMakingCharge.Size = new Size(189, 25);
      this.lblMakingCharge.TabIndex = 22;
      this.lblMakingCharge.Text = "MAKING CHARGE";
      this.tbxMelting.Enabled = false;
      this.tbxMelting.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxMelting.Location = new Point(247, 190);
      this.tbxMelting.MaxLength = 14;
      this.tbxMelting.Name = "tbxMelting";
      this.tbxMelting.Size = new Size(297, 31);
      this.tbxMelting.TabIndex = 5;
      this.tbxMelting.Text = "0";
      this.tbxMelting.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxWastage.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxWastage.Location = new Point(247, 224);
      this.tbxWastage.MaxLength = 14;
      this.tbxWastage.Name = "tbxWastage";
      this.tbxWastage.Size = new Size(297, 31);
      this.tbxWastage.TabIndex = 6;
      this.tbxWastage.Text = "0";
      this.tbxWastage.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxWastage.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblWastage.AutoSize = true;
      this.lblWastage.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblWastage.ForeColor = Color.DarkBlue;
      this.lblWastage.Location = new Point(124, 226);
      this.lblWastage.Name = "lblWastage";
      this.lblWastage.Size = new Size(117, 25);
      this.lblWastage.TabIndex = 20;
      this.lblWastage.Text = "WASTAGE";
      this.lblMelting.AutoSize = true;
      this.lblMelting.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMelting.ForeColor = Color.DarkBlue;
      this.lblMelting.Location = new Point(136, 192);
      this.lblMelting.Name = "lblMelting";
      this.lblMelting.Size = new Size(105, 25);
      this.lblMelting.TabIndex = 19;
      this.lblMelting.Text = "MELTING";
      this.tbxItemCode.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tbxItemCode.Location = new Point(247, 53);
      this.tbxItemCode.MaxLength = 50;
      this.tbxItemCode.Name = "tbxItemCode";
      this.tbxItemCode.Size = new Size(297, 31);
      this.tbxItemCode.TabIndex = 1;
      this.tbxItemCode.Validating += new CancelEventHandler(this.tbxItemCode_Validating);
      this.tbxStoneCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
      this.tbxStoneCharge.Location = new Point(414, 258);
      this.tbxStoneCharge.MaxLength = 14;
      this.tbxStoneCharge.Name = "tbxStoneCharge";
      this.tbxStoneCharge.Size = new Size(130, 31);
      this.tbxStoneCharge.TabIndex = 8;
      this.tbxStoneCharge.Text = "0";
      this.tbxStoneCharge.TextChanged += new EventHandler(this.tbxPurchasePurity_TextChanged);
      this.tbxStoneCharge.KeyPress += new KeyPressEventHandler(this.tbxAcceptDecimal);
      this.lblStoneCharge.AutoSize = true;
      this.lblStoneCharge.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblStoneCharge.ForeColor = Color.DarkBlue;
      this.lblStoneCharge.Location = new Point(62, 260);
      this.lblStoneCharge.Name = "lblStoneCharge";
      this.lblStoneCharge.Size = new Size(179, 25);
      this.lblStoneCharge.TabIndex = 21;
      this.lblStoneCharge.Text = "STONE CHARGE";
      this.panel1.Anchor = AnchorStyles.None;
      this.panel1.BackColor = Color.LightGray;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.lblHeading);
      this.panel1.Location = new Point(15, 20);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(561, 35);
      this.panel1.TabIndex = 0;
      this.lblHeading.Anchor = AnchorStyles.Top;
      this.lblHeading.AutoSize = true;
      this.lblHeading.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblHeading.Location = new Point(266, 5);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(52, 24);
      this.lblHeading.TabIndex = 0;
      this.lblHeading.Text = "ADD";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(590, 678);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormItemNamesAddEdit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Item Names Add Edit";
      this.Load += new EventHandler(this.FormItemNamesAddEdit_Load);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
