

using PawnManagement.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;

namespace PawnManagement.pawnmanagementDataSet1TableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class tblPurchaseTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblPurchaseTableAdapter() => this.ClearBeforeFill = true;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected internal OleDbDataAdapter Adapter
    {
      get
      {
        if (this._adapter == null)
          this.InitAdapter();
        return this._adapter;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal OleDbConnection Connection
    {
      get
      {
        if (this._connection == null)
          this.InitConnection();
        return this._connection;
      }
      set
      {
        this._connection = value;
        if (this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Connection = value;
        if (this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Connection = value;
        if (this.Adapter.UpdateCommand != null)
          this.Adapter.UpdateCommand.Connection = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
        {
          if (this.CommandCollection[index] != null)
            this.CommandCollection[index].Connection = value;
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal OleDbTransaction Transaction
    {
      get => this._transaction;
      set
      {
        this._transaction = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
          this.CommandCollection[index].Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Transaction = this._transaction;
        if (this.Adapter == null || this.Adapter.UpdateCommand == null)
          return;
        this.Adapter.UpdateCommand.Transaction = this._transaction;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected OleDbCommand[] CommandCollection
    {
      get
      {
        if (this._commandCollection == null)
          this.InitCommandCollection();
        return this._commandCollection;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public bool ClearBeforeFill
    {
      get => this._clearBeforeFill;
      set => this._clearBeforeFill = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitAdapter()
    {
      this._adapter = new OleDbDataAdapter();
      this._adapter.TableMappings.Add((object) new DataTableMapping()
      {
        SourceTable = "Table",
        DataSetTable = "tblPurchase",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "SerialNumber",
            "SerialNumber"
          },
          {
            "PurchaseType",
            "PurchaseType"
          },
          {
            "ItemType",
            "ItemType"
          },
          {
            "Quantity",
            "Quantity"
          },
          {
            "PurchasedFrom",
            "PurchasedFrom"
          },
          {
            "InvoiceNumber",
            "InvoiceNumber"
          },
          {
            "PurchasedBy",
            "PurchasedBy"
          },
          {
            "Price",
            "Price"
          },
          {
            "BillType",
            "BillType"
          },
          {
            "EditedBy",
            "EditedBy"
          },
          {
            "EditedOn",
            "EditedOn"
          },
          {
            "CreatedBy",
            "CreatedBy"
          },
          {
            "CreatedOn",
            "CreatedOn"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblPurchase` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `PurchaseType` IS NULL) OR (`PurchaseType` = ?)) AND ((? = 1 AND `ItemType` IS NULL) OR (`ItemType` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `PurchasedFrom` IS NULL) OR (`PurchasedFrom` = ?)) AND ((? = 1 AND `InvoiceNumber` IS NULL) OR (`InvoiceNumber` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `Price` IS NULL) OR (`Price` = ?)) AND ((? = 1 AND `BillType` IS NULL) OR (`BillType` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchaseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchaseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedFrom", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InvoiceNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InvoiceNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Price", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblPurchase` (`SerialNumber`, `PurchaseType`, `ItemType`, `Quantity`, `PurchasedFrom`, `InvoiceNumber`, `PurchasedBy`, `Price`, `BillType`, `EditedBy`, `EditedOn`, `CreatedBy`, `CreatedOn`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchaseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InvoiceNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblPurchase` SET `SerialNumber` = ?, `PurchaseType` = ?, `ItemType` = ?, `Quantity` = ?, `PurchasedFrom` = ?, `InvoiceNumber` = ?, `PurchasedBy` = ?, `Price` = ?, `BillType` = ?, `EditedBy` = ?, `EditedOn` = ?, `CreatedBy` = ?, `CreatedOn` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `PurchaseType` IS NULL) OR (`PurchaseType` = ?)) AND ((? = 1 AND `ItemType` IS NULL) OR (`ItemType` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `PurchasedFrom` IS NULL) OR (`PurchasedFrom` = ?)) AND ((? = 1 AND `InvoiceNumber` IS NULL) OR (`InvoiceNumber` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `Price` IS NULL) OR (`Price` = ?)) AND ((? = 1 AND `BillType` IS NULL) OR (`BillType` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchaseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InvoiceNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchaseType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchaseType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchaseType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedFrom", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InvoiceNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InvoiceNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InvoiceNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Price", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitConnection()
    {
      this._connection = new OleDbConnection();
      this._connection.ConnectionString = Settings.Default.pawnmanagementConnectionString2;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new OleDbCommand[1];
      this._commandCollection[0] = new OleDbCommand();
      this._commandCollection[0].Connection = this.Connection;
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, PurchaseType, ItemType, Quantity, PurchasedFrom, InvoiceNumber, PurchasedBy, Price, BillType, EditedBy, EditedOn, CreatedBy, CreatedOn FROM tblPurchase";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblPurchaseDataTable dataTable)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual pawnmanagementDataSet1.tblPurchaseDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblPurchaseDataTable data = new pawnmanagementDataSet1.tblPurchaseDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblPurchaseDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblPurchase");

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow dataRow) => this.Adapter.Update(new DataRow[1]
    {
      dataRow
    });

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow[] dataRows) => this.Adapter.Update(dataRows);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public virtual int Delete(
      int Original_ID,
      string Original_SerialNumber,
      string Original_PurchaseType,
      string Original_ItemType,
      double? Original_Quantity,
      string Original_PurchasedFrom,
      double? Original_InvoiceNumber,
      string Original_PurchasedBy,
      double? Original_Price,
      string Original_BillType,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_SerialNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_SerialNumber;
      }
      if (Original_PurchaseType == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_PurchaseType;
      }
      if (Original_ItemType == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_ItemType;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedFrom == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_PurchasedFrom;
      }
      if (Original_InvoiceNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_InvoiceNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_PurchasedBy;
      }
      if (Original_Price.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_Price.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_BillType == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_BillType;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
      if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.DeleteCommand.Connection.Open();
      try
      {
        return this.Adapter.DeleteCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.DeleteCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public virtual int Insert(
      string SerialNumber,
      string PurchaseType,
      string ItemType,
      double? Quantity,
      string PurchasedFrom,
      double? InvoiceNumber,
      string PurchasedBy,
      double? Price,
      string BillType,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn)
    {
      if (SerialNumber == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber;
      if (PurchaseType == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) PurchaseType;
      if (ItemType == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) ItemType;
      if (Quantity.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Quantity.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      if (PurchasedFrom == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) PurchasedFrom;
      if (InvoiceNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) InvoiceNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (PurchasedBy == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) PurchasedBy;
      if (Price.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Price.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (BillType == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) BillType;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      ConnectionState state = this.Adapter.InsertCommand.Connection.State;
      if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.InsertCommand.Connection.Open();
      try
      {
        return this.Adapter.InsertCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.InsertCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      string SerialNumber,
      string PurchaseType,
      string ItemType,
      double? Quantity,
      string PurchasedFrom,
      double? InvoiceNumber,
      string PurchasedBy,
      double? Price,
      string BillType,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn,
      int Original_ID,
      string Original_SerialNumber,
      string Original_PurchaseType,
      string Original_ItemType,
      double? Original_Quantity,
      string Original_PurchasedFrom,
      double? Original_InvoiceNumber,
      string Original_PurchasedBy,
      double? Original_Price,
      string Original_BillType,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
    {
      if (SerialNumber == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber;
      if (PurchaseType == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) PurchaseType;
      if (ItemType == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) ItemType;
      if (Quantity.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Quantity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      if (PurchasedFrom == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) PurchasedFrom;
      if (InvoiceNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) InvoiceNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (PurchasedBy == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) PurchasedBy;
      if (Price.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Price.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (BillType == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) BillType;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) EditedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_ID;
      if (Original_SerialNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_SerialNumber;
      }
      if (Original_PurchaseType == null)
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_PurchaseType;
      }
      if (Original_ItemType == null)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_ItemType;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedFrom == null)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_PurchasedFrom;
      }
      if (Original_InvoiceNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_InvoiceNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_PurchasedBy;
      }
      if (Original_Price.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_Price.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      if (Original_BillType == null)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_BillType;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
      if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.UpdateCommand.Connection.Open();
      try
      {
        return this.Adapter.UpdateCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.UpdateCommand.Connection.Close();
      }
    }
  }
}
