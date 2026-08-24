

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
  public class tblSalesDetailsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblSalesDetailsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblSalesDetails",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "BillNumber",
            "BillNumber"
          },
          {
            "SerialNumber",
            "SerialNumber"
          },
          {
            "ItemCode",
            "ItemCode"
          },
          {
            "ItemName",
            "ItemName"
          },
          {
            "Description",
            "Description"
          },
          {
            "Quantity",
            "Quantity"
          },
          {
            "GrossWeight",
            "GrossWeight"
          },
          {
            "StoneWeight",
            "StoneWeight"
          },
          {
            "NetWeight",
            "NetWeight"
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
            "StoneCharge",
            "StoneCharge"
          },
          {
            "HallMark",
            "HallMark"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "Gst",
            "Gst"
          },
          {
            "GstAmount",
            "GstAmount"
          },
          {
            "TotalAmount",
            "TotalAmount"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblSalesDetails` WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `StoneWeight` IS NULL) OR (`StoneWeight` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `Wastage` IS NULL) OR (`Wastage` = ?)) AND ((? = 1 AND `MakingCharge` IS NULL) OR (`MakingCharge` = ?)) AND ((? = 1 AND `StoneCharge` IS NULL) OR (`StoneCharge` = ?)) AND ((? = 1 AND `HallMark` IS NULL) OR (`HallMark` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `Gst` IS NULL) OR (`Gst` = ?)) AND ((? = 1 AND `GstAmount` IS NULL) OR (`GstAmount` = ?)) AND ((? = 1 AND `TotalAmount` IS NULL) OR (`TotalAmount` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StoneWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StoneWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Wastage", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MakingCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StoneCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_HallMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Gst", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GstAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TotalAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblSalesDetails` (`BillNumber`, `SerialNumber`, `ItemCode`, `ItemName`, `Description`, `Quantity`, `GrossWeight`, `StoneWeight`, `NetWeight`, `Wastage`, `MakingCharge`, `StoneCharge`, `HallMark`, `Amount`, `Gst`, `GstAmount`, `TotalAmount`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblSalesDetails` SET `BillNumber` = ?, `SerialNumber` = ?, `ItemCode` = ?, `ItemName` = ?, `Description` = ?, `Quantity` = ?, `GrossWeight` = ?, `StoneWeight` = ?, `NetWeight` = ?, `Wastage` = ?, `MakingCharge` = ?, `StoneCharge` = ?, `HallMark` = ?, `Amount` = ?, `Gst` = ?, `GstAmount` = ?, `TotalAmount` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `StoneWeight` IS NULL) OR (`StoneWeight` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `Wastage` IS NULL) OR (`Wastage` = ?)) AND ((? = 1 AND `MakingCharge` IS NULL) OR (`MakingCharge` = ?)) AND ((? = 1 AND `StoneCharge` IS NULL) OR (`StoneCharge` = ?)) AND ((? = 1 AND `HallMark` IS NULL) OR (`HallMark` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `Gst` IS NULL) OR (`Gst` = ?)) AND ((? = 1 AND `GstAmount` IS NULL) OR (`GstAmount` = ?)) AND ((? = 1 AND `TotalAmount` IS NULL) OR (`TotalAmount` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StoneWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StoneWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StoneWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Wastage", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MakingCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StoneCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_HallMark", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Gst", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Gst", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gst", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GstAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TotalAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, BillNumber, SerialNumber, ItemCode, ItemName, Description, Quantity, GrossWeight, StoneWeight, NetWeight, Wastage, MakingCharge, StoneCharge, HallMark, Amount, Gst, GstAmount, TotalAmount FROM tblSalesDetails";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblSalesDetailsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblSalesDetailsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblSalesDetailsDataTable data = new pawnmanagementDataSet1.tblSalesDetailsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblSalesDetailsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblSalesDetails");

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
      string Original_BillNumber,
      double? Original_SerialNumber,
      string Original_ItemCode,
      string Original_ItemName,
      string Original_Description,
      double? Original_Quantity,
      double? Original_GrossWeight,
      double? Original_StoneWeight,
      double? Original_NetWeight,
      double? Original_Wastage,
      double? Original_MakingCharge,
      double? Original_StoneCharge,
      double? Original_HallMark,
      double? Original_Amount,
      double? Original_Gst,
      double? Original_GstAmount,
      double? Original_TotalAmount)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_BillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_BillNumber;
      }
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_ItemCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_ItemCode;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_ItemName;
      }
      if (Original_Description == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Description;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_GrossWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_GrossWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      if (Original_StoneWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_StoneWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_NetWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_NetWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_Wastage.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_Wastage.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_MakingCharge.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_MakingCharge.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_StoneCharge.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_StoneCharge.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      if (Original_HallMark.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_HallMark.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      if (Original_Gst.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_Gst.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_GstAmount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_GstAmount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      if (Original_TotalAmount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_TotalAmount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
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
      string BillNumber,
      double? SerialNumber,
      string ItemCode,
      string ItemName,
      string Description,
      double? Quantity,
      double? GrossWeight,
      double? StoneWeight,
      double? NetWeight,
      double? Wastage,
      double? MakingCharge,
      double? StoneCharge,
      double? HallMark,
      double? Amount,
      double? Gst,
      double? GstAmount,
      double? TotalAmount)
    {
      if (BillNumber == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) BillNumber;
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (ItemCode == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) ItemCode;
      if (ItemName == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) ItemName;
      if (Description == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Description;
      if (Quantity.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Quantity.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (GrossWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) GrossWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      if (StoneWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) StoneWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (NetWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) NetWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Wastage.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Wastage.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (MakingCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) MakingCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (StoneCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) StoneCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (HallMark.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) HallMark.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) Amount.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Gst.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) Gst.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (GstAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) GstAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (TotalAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) TotalAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
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
      string BillNumber,
      double? SerialNumber,
      string ItemCode,
      string ItemName,
      string Description,
      double? Quantity,
      double? GrossWeight,
      double? StoneWeight,
      double? NetWeight,
      double? Wastage,
      double? MakingCharge,
      double? StoneCharge,
      double? HallMark,
      double? Amount,
      double? Gst,
      double? GstAmount,
      double? TotalAmount,
      int Original_ID,
      string Original_BillNumber,
      double? Original_SerialNumber,
      string Original_ItemCode,
      string Original_ItemName,
      string Original_Description,
      double? Original_Quantity,
      double? Original_GrossWeight,
      double? Original_StoneWeight,
      double? Original_NetWeight,
      double? Original_Wastage,
      double? Original_MakingCharge,
      double? Original_StoneCharge,
      double? Original_HallMark,
      double? Original_Amount,
      double? Original_Gst,
      double? Original_GstAmount,
      double? Original_TotalAmount)
    {
      if (BillNumber == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) BillNumber;
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (ItemCode == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) ItemCode;
      if (ItemName == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) ItemName;
      if (Description == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Description;
      if (Quantity.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Quantity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (GrossWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) GrossWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      if (StoneWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) StoneWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (NetWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) NetWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Wastage.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Wastage.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (MakingCharge.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) MakingCharge.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (StoneCharge.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) StoneCharge.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (HallMark.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) HallMark.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Amount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Gst.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Gst.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      if (GstAmount.HasValue)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) GstAmount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      if (TotalAmount.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) TotalAmount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_ID;
      if (Original_BillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_BillNumber;
      }
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      if (Original_ItemCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_ItemCode;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_ItemName;
      }
      if (Original_Description == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_Description;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      if (Original_GrossWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_GrossWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      if (Original_StoneWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_StoneWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      if (Original_NetWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_NetWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      if (Original_Wastage.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_Wastage.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      if (Original_MakingCharge.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_MakingCharge.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      if (Original_StoneCharge.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) Original_StoneCharge.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      }
      if (Original_HallMark.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) Original_HallMark.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      }
      if (Original_Gst.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) Original_Gst.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      }
      if (Original_GstAmount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) Original_GstAmount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      }
      if (Original_TotalAmount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) Original_TotalAmount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
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
