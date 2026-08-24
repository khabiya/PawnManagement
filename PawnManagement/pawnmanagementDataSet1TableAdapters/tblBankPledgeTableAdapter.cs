

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
  public class tblBankPledgeTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblBankPledgeTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblBankPledge",
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
            "BankCode",
            "BankCode"
          },
          {
            "Bankname",
            "Bankname"
          },
          {
            "Branch",
            "Branch"
          },
          {
            "BankBillNumber",
            "BankBillNumber"
          },
          {
            "BankBillDate",
            "BankBillDate"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "InterestRate",
            "InterestRate"
          },
          {
            "InterestType",
            "InterestType"
          },
          {
            "Interest",
            "Interest"
          },
          {
            "RedemptionAmount",
            "RedemptionAmount"
          },
          {
            "RedemptionDate",
            "RedemptionDate"
          },
          {
            "Released",
            "Released"
          },
          {
            "Active",
            "Active"
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
            "PledgeBillNumbers",
            "PledgeBillNumbers"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblBankPledge` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `Bankname` IS NULL) OR (`Bankname` = ?)) AND ((? = 1 AND `Branch` IS NULL) OR (`Branch` = ?)) AND ((? = 1 AND `BankBillNumber` IS NULL) OR (`BankBillNumber` = ?)) AND ((? = 1 AND `BankBillDate` IS NULL) OR (`BankBillDate` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `InterestRate` IS NULL) OR (`InterestRate` = ?)) AND ((? = 1 AND `InterestType` IS NULL) OR (`InterestType` = ?)) AND ((? = 1 AND `Interest` IS NULL) OR (`Interest` = ?)) AND ((? = 1 AND `RedemptionAmount` IS NULL) OR (`RedemptionAmount` = ?)) AND ((? = 1 AND `RedemptionDate` IS NULL) OR (`RedemptionDate` = ?)) AND ((? = 1 AND `Released` IS NULL) OR (`Released` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `PledgeBillNumbers` IS NULL) OR (`PledgeBillNumbers` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Bankname", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Bankname", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Branch", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankBillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankBillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Interest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Interest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Released", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Released", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeBillNumbers", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeBillNumbers", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblBankPledge` (`SerialNumber`, `BankCode`, `Bankname`, `Branch`, `BankBillNumber`, `BankBillDate`, `Amount`, `InterestRate`, `InterestType`, `Interest`, `RedemptionAmount`, `RedemptionDate`, `Released`, `Active`, `CreatedBy`, `CreatedOn`, `PledgeBillNumbers`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Bankname", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankBillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Interest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Released", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeBillNumbers", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblBankPledge` SET `SerialNumber` = ?, `BankCode` = ?, `Bankname` = ?, `Branch` = ?, `BankBillNumber` = ?, `BankBillDate` = ?, `Amount` = ?, `InterestRate` = ?, `InterestType` = ?, `Interest` = ?, `RedemptionAmount` = ?, `RedemptionDate` = ?, `Released` = ?, `Active` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `PledgeBillNumbers` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `Bankname` IS NULL) OR (`Bankname` = ?)) AND ((? = 1 AND `Branch` IS NULL) OR (`Branch` = ?)) AND ((? = 1 AND `BankBillNumber` IS NULL) OR (`BankBillNumber` = ?)) AND ((? = 1 AND `BankBillDate` IS NULL) OR (`BankBillDate` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `InterestRate` IS NULL) OR (`InterestRate` = ?)) AND ((? = 1 AND `InterestType` IS NULL) OR (`InterestType` = ?)) AND ((? = 1 AND `Interest` IS NULL) OR (`Interest` = ?)) AND ((? = 1 AND `RedemptionAmount` IS NULL) OR (`RedemptionAmount` = ?)) AND ((? = 1 AND `RedemptionDate` IS NULL) OR (`RedemptionDate` = ?)) AND ((? = 1 AND `Released` IS NULL) OR (`Released` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `PledgeBillNumbers` IS NULL) OR (`PledgeBillNumbers` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Bankname", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankBillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Interest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Released", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeBillNumbers", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Bankname", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Bankname", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Bankname", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Branch", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Branch", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Branch", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankBillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankBillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankBillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestRate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Interest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Interest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Released", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Released", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Released", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeBillNumbers", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeBillNumbers", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumbers", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, BankCode, Bankname, Branch, BankBillNumber, BankBillDate, Amount, InterestRate, InterestType, Interest, RedemptionAmount, RedemptionDate, Released, Active, CreatedBy, CreatedOn, PledgeBillNumbers FROM tblBankPledge";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblBankPledgeDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblBankPledgeDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblBankPledgeDataTable data = new pawnmanagementDataSet1.tblBankPledgeDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblBankPledgeDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblBankPledge");

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
      int? Original_SerialNumber,
      string Original_BankCode,
      string Original_Bankname,
      string Original_Branch,
      string Original_BankBillNumber,
      DateTime? Original_BankBillDate,
      string Original_Amount,
      string Original_InterestRate,
      string Original_InterestType,
      string Original_Interest,
      string Original_RedemptionAmount,
      DateTime? Original_RedemptionDate,
      string Original_Released,
      int? Original_Active,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_PledgeBillNumbers)
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
      if (Original_BankCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_BankCode;
      }
      if (Original_Bankname == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Bankname;
      }
      if (Original_Branch == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Branch;
      }
      if (Original_BankBillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_BankBillNumber;
      }
      if (Original_BankBillDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_BankBillDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_Amount == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_Amount;
      }
      if (Original_InterestRate == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_InterestRate;
      }
      if (Original_InterestType == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_InterestType;
      }
      if (Original_Interest == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_Interest;
      }
      if (Original_RedemptionAmount == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_RedemptionAmount;
      }
      if (Original_RedemptionDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_RedemptionDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      if (Original_Released == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_Released;
      }
      if (Original_Active.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_Active.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      if (Original_PledgeBillNumbers == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_PledgeBillNumbers;
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
      int? SerialNumber,
      string BankCode,
      string Bankname,
      string Branch,
      string BankBillNumber,
      DateTime? BankBillDate,
      string Amount,
      string InterestRate,
      string InterestType,
      string Interest,
      string RedemptionAmount,
      DateTime? RedemptionDate,
      string Released,
      int? Active,
      string CreatedBy,
      DateTime? CreatedOn,
      string PledgeBillNumbers)
    {
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BankCode == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BankCode;
      if (Bankname == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Bankname;
      if (Branch == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Branch;
      if (BankBillNumber == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) BankBillNumber;
      if (BankBillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) BankBillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Amount == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Amount;
      if (InterestRate == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) InterestRate;
      if (InterestType == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) InterestType;
      if (Interest == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Interest;
      if (RedemptionAmount == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) RedemptionAmount;
      if (RedemptionDate.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) RedemptionDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Released == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) Released;
      if (Active.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) Active.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (PledgeBillNumbers == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) PledgeBillNumbers;
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
      int? SerialNumber,
      string BankCode,
      string Bankname,
      string Branch,
      string BankBillNumber,
      DateTime? BankBillDate,
      string Amount,
      string InterestRate,
      string InterestType,
      string Interest,
      string RedemptionAmount,
      DateTime? RedemptionDate,
      string Released,
      int? Active,
      string CreatedBy,
      DateTime? CreatedOn,
      string PledgeBillNumbers,
      int Original_ID,
      int? Original_SerialNumber,
      string Original_BankCode,
      string Original_Bankname,
      string Original_Branch,
      string Original_BankBillNumber,
      DateTime? Original_BankBillDate,
      string Original_Amount,
      string Original_InterestRate,
      string Original_InterestType,
      string Original_Interest,
      string Original_RedemptionAmount,
      DateTime? Original_RedemptionDate,
      string Original_Released,
      int? Original_Active,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_PledgeBillNumbers)
    {
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BankCode == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) BankCode;
      if (Bankname == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Bankname;
      if (Branch == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Branch;
      if (BankBillNumber == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) BankBillNumber;
      if (BankBillDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) BankBillDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Amount == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Amount;
      if (InterestRate == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) InterestRate;
      if (InterestType == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) InterestType;
      if (Interest == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Interest;
      if (RedemptionAmount == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) RedemptionAmount;
      if (RedemptionDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) RedemptionDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Released == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Released;
      if (Active.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Active.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      if (PledgeBillNumbers == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) PledgeBillNumbers;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_ID;
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      if (Original_BankCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_BankCode;
      }
      if (Original_Bankname == null)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_Bankname;
      }
      if (Original_Branch == null)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_Branch;
      }
      if (Original_BankBillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_BankBillNumber;
      }
      if (Original_BankBillDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_BankBillDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      if (Original_Amount == null)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_Amount;
      }
      if (Original_InterestRate == null)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_InterestRate;
      }
      if (Original_InterestType == null)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_InterestType;
      }
      if (Original_Interest == null)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_Interest;
      }
      if (Original_RedemptionAmount == null)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_RedemptionAmount;
      }
      if (Original_RedemptionDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) Original_RedemptionDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      }
      if (Original_Released == null)
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) Original_Released;
      }
      if (Original_Active.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) Original_Active.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      }
      if (Original_PledgeBillNumbers == null)
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) Original_PledgeBillNumbers;
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
