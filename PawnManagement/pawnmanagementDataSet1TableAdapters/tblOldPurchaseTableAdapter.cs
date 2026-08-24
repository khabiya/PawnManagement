// Decompiled with JetBrains decompiler
// Type: PawnManagement.pawnmanagementDataSet1TableAdapters.tblOldPurchaseTableAdapter
// Assembly: PawnManagement, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF38565-09F5-4945-B63E-4A76BB004257
// Assembly location: E:\Ramesh Pawn Soft\Pawnstar\Release\PawnManagement.exe

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
  public class tblOldPurchaseTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblOldPurchaseTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblOldPurchase",
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
            "BillDate",
            "BillDate"
          },
          {
            "CustomerCode",
            "CustomerCode"
          },
          {
            "Metal",
            "Metal"
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
            "GrossWeight",
            "GrossWeight"
          },
          {
            "Dirt",
            "Dirt"
          },
          {
            "Arakku",
            "Arakku"
          },
          {
            "StoneOrEnamel",
            "StoneOrEnamel"
          },
          {
            "NetWeight",
            "NetWeight"
          },
          {
            "Purity",
            "Purity"
          },
          {
            "PureWeight",
            "PureWeight"
          },
          {
            "Rate",
            "Rate"
          },
          {
            "Amount",
            "Amount"
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
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblOldPurchase` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `Metal` IS NULL) OR (`Metal` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `Dirt` IS NULL) OR (`Dirt` = ?)) AND ((? = 1 AND `Arakku` IS NULL) OR (`Arakku` = ?)) AND ((? = 1 AND `StoneOrEnamel` IS NULL) OR (`StoneOrEnamel` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `Purity` IS NULL) OR (`Purity` = ?)) AND ((? = 1 AND `PureWeight` IS NULL) OR (`PureWeight` = ?)) AND ((? = 1 AND `Rate` IS NULL) OR (`Rate` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Metal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Dirt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Dirt", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Arakku", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Arakku", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StoneOrEnamel", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StoneOrEnamel", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Purity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Purity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PureWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Rate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Rate", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
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
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblOldPurchase` (`SerialNumber`, `BillDate`, `CustomerCode`, `Metal`, `ItemName`, `Description`, `GrossWeight`, `Dirt`, `Arakku`, `StoneOrEnamel`, `NetWeight`, `Purity`, `PureWeight`, `Rate`, `Amount`, `EditedBy`, `EditedOn`, `CreatedBy`, `CreatedOn`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Dirt", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Arakku", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneOrEnamel", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Purity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Rate", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblOldPurchase` SET `SerialNumber` = ?, `BillDate` = ?, `CustomerCode` = ?, `Metal` = ?, `ItemName` = ?, `Description` = ?, `GrossWeight` = ?, `Dirt` = ?, `Arakku` = ?, `StoneOrEnamel` = ?, `NetWeight` = ?, `Purity` = ?, `PureWeight` = ?, `Rate` = ?, `Amount` = ?, `EditedBy` = ?, `EditedOn` = ?, `CreatedBy` = ?, `CreatedOn` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `Metal` IS NULL) OR (`Metal` = ?)) AND ((? = 1 AND `ItemName` IS NULL) OR (`ItemName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `Dirt` IS NULL) OR (`Dirt` = ?)) AND ((? = 1 AND `Arakku` IS NULL) OR (`Arakku` = ?)) AND ((? = 1 AND `StoneOrEnamel` IS NULL) OR (`StoneOrEnamel` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `Purity` IS NULL) OR (`Purity` = ?)) AND ((? = 1 AND `PureWeight` IS NULL) OR (`PureWeight` = ?)) AND ((? = 1 AND `Rate` IS NULL) OR (`Rate` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Dirt", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Arakku", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StoneOrEnamel", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Purity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Rate", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Metal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ItemName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Dirt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Dirt", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Dirt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Arakku", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Arakku", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Arakku", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StoneOrEnamel", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StoneOrEnamel", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneOrEnamel", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Purity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Purity", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PureWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Rate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Rate", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Rate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, BillDate, CustomerCode, Metal, ItemName, Description, GrossWeight, Dirt, Arakku, StoneOrEnamel, NetWeight, Purity, PureWeight, Rate, Amount, EditedBy, EditedOn, CreatedBy, CreatedOn FROM tblOldPurchase";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblOldPurchaseDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblOldPurchaseDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblOldPurchaseDataTable data = new pawnmanagementDataSet1.tblOldPurchaseDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblOldPurchaseDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblOldPurchase");

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
      double? Original_SerialNumber,
      DateTime? Original_BillDate,
      string Original_CustomerCode,
      string Original_Metal,
      string Original_ItemName,
      string Original_Description,
      double? Original_GrossWeight,
      double? Original_Dirt,
      double? Original_Arakku,
      double? Original_StoneOrEnamel,
      double? Original_NetWeight,
      double? Original_Purity,
      double? Original_PureWeight,
      double? Original_Rate,
      double? Original_Amount,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_CustomerCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_CustomerCode;
      }
      if (Original_Metal == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Metal;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_ItemName;
      }
      if (Original_Description == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Description;
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
      if (Original_Dirt.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_Dirt.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_Arakku.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_Arakku.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_StoneOrEnamel.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_StoneOrEnamel.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_NetWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_NetWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_Purity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_Purity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      if (Original_PureWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_PureWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      if (Original_Rate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_Rate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
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
      double? SerialNumber,
      DateTime? BillDate,
      string CustomerCode,
      string Metal,
      string ItemName,
      string Description,
      double? GrossWeight,
      double? Dirt,
      double? Arakku,
      double? StoneOrEnamel,
      double? NetWeight,
      double? Purity,
      double? PureWeight,
      double? Rate,
      double? Amount,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn)
    {
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) CustomerCode;
      if (Metal == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Metal;
      if (ItemName == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) ItemName;
      if (Description == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Description;
      if (GrossWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) GrossWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      if (Dirt.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Dirt.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (Arakku.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Arakku.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (StoneOrEnamel.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) StoneOrEnamel.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (NetWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) NetWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Purity.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Purity.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (PureWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) PureWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Rate.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) Rate.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) Amount.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
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
      double? SerialNumber,
      DateTime? BillDate,
      string CustomerCode,
      string Metal,
      string ItemName,
      string Description,
      double? GrossWeight,
      double? Dirt,
      double? Arakku,
      double? StoneOrEnamel,
      double? NetWeight,
      double? Purity,
      double? PureWeight,
      double? Rate,
      double? Amount,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn,
      int Original_ID,
      double? Original_SerialNumber,
      DateTime? Original_BillDate,
      string Original_CustomerCode,
      string Original_Metal,
      string Original_ItemName,
      string Original_Description,
      double? Original_GrossWeight,
      double? Original_Dirt,
      double? Original_Arakku,
      double? Original_StoneOrEnamel,
      double? Original_NetWeight,
      double? Original_Purity,
      double? Original_PureWeight,
      double? Original_Rate,
      double? Original_Amount,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
    {
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BillDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) BillDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) CustomerCode;
      if (Metal == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Metal;
      if (ItemName == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) ItemName;
      if (Description == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Description;
      if (GrossWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) GrossWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      if (Dirt.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Dirt.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (Arakku.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Arakku.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (StoneOrEnamel.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) StoneOrEnamel.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (NetWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) NetWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Purity.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Purity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (PureWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) PureWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Rate.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Rate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Amount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) EditedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_ID;
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
      if (Original_BillDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      if (Original_CustomerCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_CustomerCode;
      }
      if (Original_Metal == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_Metal;
      }
      if (Original_ItemName == null)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_ItemName;
      }
      if (Original_Description == null)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_Description;
      }
      if (Original_GrossWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_GrossWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      if (Original_Dirt.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_Dirt.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      if (Original_Arakku.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_Arakku.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      if (Original_StoneOrEnamel.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_StoneOrEnamel.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      if (Original_NetWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) Original_NetWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      }
      if (Original_Purity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) Original_Purity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      }
      if (Original_PureWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) Original_PureWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      }
      if (Original_Rate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) Original_Rate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) DBNull.Value;
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
