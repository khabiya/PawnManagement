

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
  public class tblBankMasterTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblBankMasterTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblBankMaster",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "BankCode",
            "BankCode"
          },
          {
            "BankName",
            "BankName"
          },
          {
            "Branch",
            "Branch"
          },
          {
            "IfscCode",
            "IfscCode"
          },
          {
            "PhoneNumber1",
            "PhoneNumber1"
          },
          {
            "PhoneNumber2",
            "PhoneNumber2"
          },
          {
            "LedgerCode",
            "LedgerCode"
          },
          {
            "VoucherCode",
            "VoucherCode"
          },
          {
            "LedgerCodeInterest",
            "LedgerCodeInterest"
          },
          {
            "VoucherCodeInterest",
            "VoucherCodeInterest"
          },
          {
            "Active",
            "Active"
          },
          {
            "Type",
            "Type"
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
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblBankMaster` WHERE (((? = 1 AND `ID` IS NULL) OR (`ID` = ?)) AND (`BankCode` = ?) AND ((? = 1 AND `BankName` IS NULL) OR (`BankName` = ?)) AND ((? = 1 AND `Branch` IS NULL) OR (`Branch` = ?)) AND ((? = 1 AND `IfscCode` IS NULL) OR (`IfscCode` = ?)) AND ((? = 1 AND `PhoneNumber1` IS NULL) OR (`PhoneNumber1` = ?)) AND ((? = 1 AND `PhoneNumber2` IS NULL) OR (`PhoneNumber2` = ?)) AND ((? = 1 AND `LedgerCode` IS NULL) OR (`LedgerCode` = ?)) AND ((? = 1 AND `VoucherCode` IS NULL) OR (`VoucherCode` = ?)) AND ((? = 1 AND `LedgerCodeInterest` IS NULL) OR (`LedgerCodeInterest` = ?)) AND ((? = 1 AND `VoucherCodeInterest` IS NULL) OR (`VoucherCodeInterest` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Branch", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IfscCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblBankMaster` (`BankCode`, `BankName`, `Branch`, `IfscCode`, `PhoneNumber1`, `PhoneNumber2`, `LedgerCode`, `VoucherCode`, `LedgerCodeInterest`, `VoucherCodeInterest`, `Active`, `Type`, `CreatedBy`, `CreatedOn`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblBankMaster` SET `BankCode` = ?, `BankName` = ?, `Branch` = ?, `IfscCode` = ?, `PhoneNumber1` = ?, `PhoneNumber2` = ?, `LedgerCode` = ?, `VoucherCode` = ?, `LedgerCodeInterest` = ?, `VoucherCodeInterest` = ?, `Active` = ?, `Type` = ?, `CreatedBy` = ?, `CreatedOn` = ? WHERE (((? = 1 AND `ID` IS NULL) OR (`ID` = ?)) AND (`BankCode` = ?) AND ((? = 1 AND `BankName` IS NULL) OR (`BankName` = ?)) AND ((? = 1 AND `Branch` IS NULL) OR (`Branch` = ?)) AND ((? = 1 AND `IfscCode` IS NULL) OR (`IfscCode` = ?)) AND ((? = 1 AND `PhoneNumber1` IS NULL) OR (`PhoneNumber1` = ?)) AND ((? = 1 AND `PhoneNumber2` IS NULL) OR (`PhoneNumber2` = ?)) AND ((? = 1 AND `LedgerCode` IS NULL) OR (`LedgerCode` = ?)) AND ((? = 1 AND `VoucherCode` IS NULL) OR (`VoucherCode` = ?)) AND ((? = 1 AND `LedgerCodeInterest` IS NULL) OR (`LedgerCodeInterest` = ?)) AND ((? = 1 AND `VoucherCodeInterest` IS NULL) OR (`VoucherCodeInterest` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Branch", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IfscCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, BankCode, BankName, Branch, IfscCode, PhoneNumber1, PhoneNumber2, LedgerCode, VoucherCode, LedgerCodeInterest, VoucherCodeInterest, Active, Type, CreatedBy, CreatedOn FROM tblBankMaster";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblBankMasterDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblBankMasterDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblBankMasterDataTable data = new pawnmanagementDataSet1.tblBankMasterDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblBankMasterDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblBankMaster");

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
      string Original_BankCode,
      string Original_BankName,
      string Original_Branch,
      string Original_IfscCode,
      string Original_PhoneNumber1,
      string Original_PhoneNumber2,
      string Original_LedgerCode,
      string Original_VoucherCode,
      string Original_LedgerCodeInterest,
      string Original_VoucherCodeInterest,
      int? Original_Active,
      string Original_Type,
      string Original_CreatedBy,
      string Original_CreatedOn)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) 0;
      this.Adapter.DeleteCommand.Parameters[1].Value = (object) Original_ID;
      if (Original_BankCode == null)
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_BankCode;
      if (Original_BankName == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_BankName;
      }
      if (Original_Branch == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Branch;
      }
      if (Original_IfscCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_IfscCode;
      }
      if (Original_PhoneNumber1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_PhoneNumber1;
      }
      if (Original_PhoneNumber2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_PhoneNumber2;
      }
      if (Original_LedgerCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_LedgerCode;
      }
      if (Original_VoucherCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_VoucherCode;
      }
      if (Original_LedgerCodeInterest == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_LedgerCodeInterest;
      }
      if (Original_VoucherCodeInterest == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_VoucherCodeInterest;
      }
      if (Original_Active.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_Active.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_Type == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_Type;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_CreatedOn;
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
      string BankCode,
      string BankName,
      string Branch,
      string IfscCode,
      string PhoneNumber1,
      string PhoneNumber2,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterest,
      int? Active,
      string Type,
      string CreatedBy,
      string CreatedOn)
    {
      if (BankCode == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) BankCode;
      if (BankName == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BankName;
      if (Branch == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Branch;
      if (IfscCode == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) IfscCode;
      if (PhoneNumber1 == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) PhoneNumber1;
      if (PhoneNumber2 == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) PhoneNumber2;
      if (LedgerCode == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) LedgerCode;
      if (VoucherCode == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) VoucherCode;
      if (LedgerCodeInterest == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) LedgerCodeInterest;
      if (VoucherCodeInterest == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) VoucherCodeInterest;
      if (Active.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Active.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Type == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Type;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) CreatedOn;
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
      string BankCode,
      string BankName,
      string Branch,
      string IfscCode,
      string PhoneNumber1,
      string PhoneNumber2,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterest,
      int? Active,
      string Type,
      string CreatedBy,
      string CreatedOn,
      int Original_ID,
      string Original_BankCode,
      string Original_BankName,
      string Original_Branch,
      string Original_IfscCode,
      string Original_PhoneNumber1,
      string Original_PhoneNumber2,
      string Original_LedgerCode,
      string Original_VoucherCode,
      string Original_LedgerCodeInterest,
      string Original_VoucherCodeInterest,
      int? Original_Active,
      string Original_Type,
      string Original_CreatedBy,
      string Original_CreatedOn)
    {
      if (BankCode == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) BankCode;
      if (BankName == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) BankName;
      if (Branch == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Branch;
      if (IfscCode == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) IfscCode;
      if (PhoneNumber1 == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) PhoneNumber1;
      if (PhoneNumber2 == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) PhoneNumber2;
      if (LedgerCode == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) LedgerCode;
      if (VoucherCode == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) VoucherCode;
      if (LedgerCodeInterest == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) LedgerCodeInterest;
      if (VoucherCodeInterest == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) VoucherCodeInterest;
      if (Active.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Active.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Type == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Type;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) CreatedOn;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) 0;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_ID;
      if (Original_BankCode == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) Original_BankCode;
      if (Original_BankName == null)
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_BankName;
      }
      if (Original_Branch == null)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_Branch;
      }
      if (Original_IfscCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_IfscCode;
      }
      if (Original_PhoneNumber1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_PhoneNumber1;
      }
      if (Original_PhoneNumber2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_PhoneNumber2;
      }
      if (Original_LedgerCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_LedgerCode;
      }
      if (Original_VoucherCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_VoucherCode;
      }
      if (Original_LedgerCodeInterest == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_LedgerCodeInterest;
      }
      if (Original_VoucherCodeInterest == null)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_VoucherCodeInterest;
      }
      if (Original_Active.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_Active.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      if (Original_Type == null)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_Type;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_CreatedOn;
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

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      string BankName,
      string Branch,
      string IfscCode,
      string PhoneNumber1,
      string PhoneNumber2,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterest,
      int? Active,
      string Type,
      string CreatedBy,
      string CreatedOn,
      int Original_ID,
      string Original_BankCode,
      string Original_BankName,
      string Original_Branch,
      string Original_IfscCode,
      string Original_PhoneNumber1,
      string Original_PhoneNumber2,
      string Original_LedgerCode,
      string Original_VoucherCode,
      string Original_LedgerCodeInterest,
      string Original_VoucherCodeInterest,
      int? Original_Active,
      string Original_Type,
      string Original_CreatedBy,
      string Original_CreatedOn)
    {
      return this.Update(Original_BankCode, BankName, Branch, IfscCode, PhoneNumber1, PhoneNumber2, LedgerCode, VoucherCode, LedgerCodeInterest, VoucherCodeInterest, Active, Type, CreatedBy, CreatedOn, Original_ID, Original_BankCode, Original_BankName, Original_Branch, Original_IfscCode, Original_PhoneNumber1, Original_PhoneNumber2, Original_LedgerCode, Original_VoucherCode, Original_LedgerCodeInterest, Original_VoucherCodeInterest, Original_Active, Original_Type, Original_CreatedBy, Original_CreatedOn);
    }
  }
}
