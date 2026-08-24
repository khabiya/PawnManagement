
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
  public class tblItemNamesTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblItemNamesTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblItemNames",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "ItemType",
            "ItemType"
          },
          {
            "ItemName",
            "ItemName"
          },
          {
            "PurchasePurity",
            "PurchasePurity"
          },
          {
            "StoneCharge",
            "StoneCharge"
          },
          {
            "Melting",
            "Melting"
          },
          {
            "Wastage",
            "Wastage"
          },
          {
            "MakingCharge",
            "MakingCharge"
          },
          {
            "HallMark",
            "HallMark"
          },
          {
            "CreatedOn",
            "CreatedOn"
          },
          {
            "CreatedBy",
            "CreatedBy"
          },
          {
            "EditedOn",
            "EditedOn"
          },
          {
            "EditedBy",
            "EditedBy"
          },
          {
            "ItemCode",
            "ItemCode"
          },
          {
            "Purity",
            "Purity"
          },
          {
            "StoneChargeType",
            "StoneChargeType"
          },
          {
            "MakingChargeType",
            "MakingChargeType"
          },
          {
            "CGst",
            "CGst"
          },
          {
            "SGst",
            "SGst"
          },
          {
            "IGst",
            "IGst"
          },
          {
            "PurchasePrice",
            "PurchasePrice"
          },
          {
            "SellingPrice",
            "SellingPrice"
          },
          {
            "Mrp",
            "Mrp"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblItemNames` WHERE ((`ID` = ?) AND ((? = 1 AND `ItemType` IS NULL) OR (`ItemType` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `PurchasePurity` IS NULL) OR (`PurchasePurity` = ?)) AND ((? = 1 AND `StoneCharge` IS NULL) OR (`StoneCharge` = ?)) AND ((? = 1 AND `Melting` IS NULL) OR (`Melting` = ?)) AND ((? = 1 AND `Wastage` IS NULL) OR (`Wastage` = ?)) AND ((? = 1 AND `MakingCharge` IS NULL) OR (`MakingCharge` = ?)) AND ((? = 1 AND `HallMark` IS NULL) OR (`HallMark` = ?)) AND ((? = 1 AND `Gst` IS NULL) OR (`Gst` = ?)) AND ((? = 1 AND `Price` IS NULL) OR (`Price` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasePurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasePurity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StoneCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Melting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Melting", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Wastage", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MakingCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_HallMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Gst", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Price", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblItemNames` (`ItemType`, `ItemName`, `PurchasePurity`, `StoneCharge`, `Melting`, `Wastage`, `MakingCharge`, `HallMark`, `CreatedOn`, `CreatedBy`, `EditedOn`, `EditedBy`, `ItemCode`, `CGst`, `IGst`, `MakingChargeType`, `PurchasePrice`, `Purity`, `SGst`, `SellingPrice`, `StoneChargeType`, `Mrp`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasePurity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Melting", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CGst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CGst", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IGst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IGst", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MakingChargeType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingChargeType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasePrice", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePrice", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Purity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SGst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SGst", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SellingPrice", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SellingPrice", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneChargeType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneChargeType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Mrp", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Mrp", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblItemNames` SET `ItemType` = ?, `ItemName` = ?, `PurchasePurity` = ?, `StoneCharge` = ?, `Melting` = ?, `Wastage` = ?, `MakingCharge` = ?, `HallMark` = ?, `Gst` = ?, `Price` = ?, `CreatedOn` = ?, `CreatedBy` = ?, `EditedOn` = ?, `EditedBy` = ?, `ItemCode` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `ItemType` IS NULL) OR (`ItemType` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `PurchasePurity` IS NULL) OR (`PurchasePurity` = ?)) AND ((? = 1 AND `StoneCharge` IS NULL) OR (`StoneCharge` = ?)) AND ((? = 1 AND `Melting` IS NULL) OR (`Melting` = ?)) AND ((? = 1 AND `Wastage` IS NULL) OR (`Wastage` = ?)) AND ((? = 1 AND `MakingCharge` IS NULL) OR (`MakingCharge` = ?)) AND ((? = 1 AND `HallMark` IS NULL) OR (`HallMark` = ?)) AND ((? = 1 AND `Gst` IS NULL) OR (`Gst` = ?)) AND ((? = 1 AND `Price` IS NULL) OR (`Price` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasePurity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Melting", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasePurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasePurity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasePurity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StoneCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Melting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Melting", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Wastage", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MakingCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_HallMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Gst", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Price", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Price", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Price", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, ItemType, ItemName, PurchasePurity, StoneCharge, Melting, Wastage, MakingCharge, HallMark, Gst, CreatedOn, CreatedBy, EditedOn, EditedBy, ItemCode, CGst, IGst, MakingChargeType, PurchasePrice, Purity, SGst, SellingPrice, StoneChargeType, Mrp FROM tblItemNames";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblItemNamesDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblItemNamesDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblItemNamesDataTable data = new pawnmanagementDataSet1.tblItemNamesDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblItemNamesDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblItemNames");

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
      string Original_ItemType,
      string Original_ItemName,
      double? Original_PurchasePurity,
      double? Original_StoneCharge,
      double? Original_Melting,
      double? Original_Wastage,
      double? Original_MakingCharge,
      double? Original_HallMark,
      double? Original_Gst,
      double? Original_Price,
      DateTime? Original_CreatedOn,
      string Original_CreatedBy,
      DateTime? Original_EditedOn,
      string Original_EditedBy,
      string Original_ItemCode)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_ItemType == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_ItemType;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_ItemName;
      }
      if (Original_PurchasePurity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_PurchasePurity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      if (Original_StoneCharge.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_StoneCharge.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      if (Original_Melting.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Melting.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      if (Original_Wastage.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Wastage.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_MakingCharge.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_MakingCharge.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      if (Original_HallMark.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_HallMark.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_Gst.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_Gst.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_Price.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_Price.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_CreatedOn.Value;
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
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_EditedBy;
      }
      if (Original_ItemCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_ItemCode;
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
      string ItemType,
      string ItemName,
      double? PurchasePurity,
      double? StoneCharge,
      double? Melting,
      double? Wastage,
      double? MakingCharge,
      double? HallMark,
      DateTime? CreatedOn,
      string CreatedBy,
      DateTime? EditedOn,
      string EditedBy,
      string ItemCode,
      double? CGst,
      double? IGst,
      string MakingChargeType,
      double? PurchasePrice,
      string Purity,
      double? SGst,
      double? SellingPrice,
      string StoneChargeType,
      double? Mrp)
    {
      if (ItemType == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) ItemType;
      if (ItemName == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) ItemName;
      if (PurchasePurity.HasValue)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) PurchasePurity.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      if (StoneCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) StoneCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      if (Melting.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Melting.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      if (Wastage.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Wastage.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (MakingCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) MakingCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      if (HallMark.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) HallMark.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) CreatedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) EditedBy;
      if (ItemCode == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) ItemCode;
      if (CGst.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) CGst.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (IGst.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) IGst.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (MakingChargeType == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) MakingChargeType;
      if (PurchasePrice.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) PurchasePrice.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (Purity == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) Purity;
      if (SGst.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) SGst.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (SellingPrice.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) SellingPrice.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (StoneChargeType == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) StoneChargeType;
      if (Mrp.HasValue)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) Mrp.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
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
      string ItemType,
      string ItemName,
      double? PurchasePurity,
      double? StoneCharge,
      double? Melting,
      double? Wastage,
      double? MakingCharge,
      double? HallMark,
      double? Gst,
      double? Price,
      DateTime? CreatedOn,
      string CreatedBy,
      DateTime? EditedOn,
      string EditedBy,
      string ItemCode,
      int Original_ID,
      string Original_ItemType,
      string Original_ItemName,
      double? Original_PurchasePurity,
      double? Original_StoneCharge,
      double? Original_Melting,
      double? Original_Wastage,
      double? Original_MakingCharge,
      double? Original_HallMark,
      double? Original_Gst,
      double? Original_Price,
      DateTime? Original_CreatedOn,
      string Original_CreatedBy,
      DateTime? Original_EditedOn,
      string Original_EditedBy,
      string Original_ItemCode)
    {
      if (ItemType == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) ItemType;
      if (ItemName == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) ItemName;
      if (PurchasePurity.HasValue)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) PurchasePurity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      if (StoneCharge.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) StoneCharge.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      if (Melting.HasValue)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Melting.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      if (Wastage.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Wastage.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (MakingCharge.HasValue)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) MakingCharge.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      if (HallMark.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) HallMark.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (Gst.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Gst.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Price.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Price.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) CreatedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) EditedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) EditedBy;
      if (ItemCode == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) ItemCode;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_ID;
      if (Original_ItemType == null)
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_ItemType;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_ItemName;
      }
      if (Original_PurchasePurity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_PurchasePurity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      if (Original_StoneCharge.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_StoneCharge.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      if (Original_Melting.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_Melting.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      if (Original_Wastage.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_Wastage.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      if (Original_MakingCharge.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_MakingCharge.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      if (Original_HallMark.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_HallMark.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      if (Original_Gst.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_Gst.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      if (Original_Price.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_Price.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_CreatedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) Original_EditedBy;
      }
      if (Original_ItemCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) Original_ItemCode;
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
