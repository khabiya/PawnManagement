

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
  public class tblStockTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblStockTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblStock",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "ItemCode",
            "ItemCode"
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
            "PurchasedBy",
            "PurchasedBy"
          },
          {
            "PurchasedOn",
            "PurchasedOn"
          },
          {
            "FinYearCode",
            "FinYearCode"
          },
          {
            "CompanyName",
            "CompanyName"
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
          },
          {
            "SerialNumber",
            "SerialNumber"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblStock` WHERE ((`ID` = ?) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `PurchasedFrom` IS NULL) OR (`PurchasedFrom` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `PurchasedOn` IS NULL) OR (`PurchasedOn` = ?)) AND ((? = 1 AND `FinYearCode` IS NULL) OR (`FinYearCode` = ?)) AND ((? = 1 AND `CompanyName` IS NULL) OR (`CompanyName` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedFrom", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_FinYearCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_FinYearCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblStock` (`ItemCode`, `Quantity`, `PurchasedFrom`, `PurchasedBy`, `PurchasedOn`, `FinYearCode`, `CompanyName`, `EditedBy`, `EditedOn`, `CreatedBy`, `CreatedOn`, `SerialNumber`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FinYearCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblStock` SET `ItemCode` = ?, `Quantity` = ?, `PurchasedFrom` = ?, `PurchasedBy` = ?, `PurchasedOn` = ?, `FinYearCode` = ?, `CompanyName` = ?, `EditedBy` = ?, `EditedOn` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `SerialNumber` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `ItemCode` IS NULL) OR (`ItemCode` = ?)) AND ((? = 1 AND `Quantity` IS NULL) OR (`Quantity` = ?)) AND ((? = 1 AND `PurchasedFrom` IS NULL) OR (`PurchasedFrom` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `PurchasedOn` IS NULL) OR (`PurchasedOn` = ?)) AND ((? = 1 AND `FinYearCode` IS NULL) OR (`FinYearCode` = ?)) AND ((? = 1 AND `CompanyName` IS NULL) OR (`CompanyName` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FinYearCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Quantity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Quantity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quantity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedFrom", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedFrom", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedFrom", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_FinYearCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_FinYearCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FinYearCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, ItemCode, Quantity, PurchasedFrom, PurchasedBy, PurchasedOn, FinYearCode, CompanyName, EditedBy, EditedOn, CreatedBy, CreatedOn, SerialNumber FROM tblStock";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(pawnmanagementDataSet1.tblStockDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblStockDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblStockDataTable data = new pawnmanagementDataSet1.tblStockDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1.tblStockDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblStock");

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
      string Original_ItemCode,
      double? Original_Quantity,
      string Original_PurchasedFrom,
      string Original_PurchasedBy,
      DateTime? Original_PurchasedOn,
      string Original_FinYearCode,
      string Original_CompanyName,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      double? Original_SerialNumber)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_ItemCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_ItemCode;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedFrom == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_PurchasedFrom;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_PurchasedBy;
      }
      if (Original_PurchasedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_PurchasedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      if (Original_FinYearCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_FinYearCode;
      }
      if (Original_CompanyName == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_CompanyName;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_CreatedBy;
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
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
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
      string ItemCode,
      double? Quantity,
      string PurchasedFrom,
      string PurchasedBy,
      DateTime? PurchasedOn,
      string FinYearCode,
      string CompanyName,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn,
      double? SerialNumber)
    {
      if (ItemCode == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) ItemCode;
      if (Quantity.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) Quantity.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (PurchasedFrom == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) PurchasedFrom;
      if (PurchasedBy == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) PurchasedBy;
      if (PurchasedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) PurchasedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      if (FinYearCode == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) FinYearCode;
      if (CompanyName == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) CompanyName;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
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
      string ItemCode,
      double? Quantity,
      string PurchasedFrom,
      string PurchasedBy,
      DateTime? PurchasedOn,
      string FinYearCode,
      string CompanyName,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn,
      double? SerialNumber,
      int Original_ID,
      string Original_ItemCode,
      double? Original_Quantity,
      string Original_PurchasedFrom,
      string Original_PurchasedBy,
      DateTime? Original_PurchasedOn,
      string Original_FinYearCode,
      string Original_CompanyName,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      double? Original_SerialNumber)
    {
      if (ItemCode == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) ItemCode;
      if (Quantity.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) Quantity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (PurchasedFrom == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) PurchasedFrom;
      if (PurchasedBy == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) PurchasedBy;
      if (PurchasedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) PurchasedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      if (FinYearCode == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) FinYearCode;
      if (CompanyName == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) CompanyName;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) EditedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_ID;
      if (Original_ItemCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Original_ItemCode;
      }
      if (Original_Quantity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) Original_Quantity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_PurchasedFrom == null)
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_PurchasedFrom;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_PurchasedBy;
      }
      if (Original_PurchasedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_PurchasedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_FinYearCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_FinYearCode;
      }
      if (Original_CompanyName == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_CompanyName;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
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
