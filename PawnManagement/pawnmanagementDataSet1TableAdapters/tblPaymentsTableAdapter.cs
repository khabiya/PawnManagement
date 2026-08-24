

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
  public class tblPaymentsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblPaymentsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblPayments",
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
            "PaymentSerialNumber",
            "PaymentSerialNumber"
          },
          {
            "PaymentMode",
            "PaymentMode"
          },
          {
            "DiscountVoucherName",
            "DiscountVoucherName"
          },
          {
            "BankName",
            "BankName"
          },
          {
            "ChequeNumber",
            "ChequeNumber"
          },
          {
            "PayerName",
            "PayerName"
          },
          {
            "AccountNumber",
            "AccountNumber"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "ChequeDated",
            "ChequeDated"
          },
          {
            "ExpiresOn",
            "ExpiresOn"
          },
          {
            "IfscCode",
            "IfscCode"
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
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblPayments` WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `PaymentSerialNumber` IS NULL) OR (`PaymentSerialNumber` = ?)) AND ((? = 1 AND `PaymentMode` IS NULL) OR (`PaymentMode` = ?)) AND ((? = 1 AND `DiscountVoucherName` IS NULL) OR (`DiscountVoucherName` = ?)) AND ((? = 1 AND `BankName` IS NULL) OR (`BankName` = ?)) AND ((? = 1 AND `ChequeNumber` IS NULL) OR (`ChequeNumber` = ?)) AND ((? = 1 AND `PayerName` IS NULL) OR (`PayerName` = ?)) AND ((? = 1 AND `AccountNumber` IS NULL) OR (`AccountNumber` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `ChequeDated` IS NULL) OR (`ChequeDated` = ?)) AND ((? = 1 AND `ExpiresOn` IS NULL) OR (`ExpiresOn` = ?)) AND ((? = 1 AND `IfscCode` IS NULL) OR (`IfscCode` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PaymentSerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PaymentSerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PaymentMode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PaymentMode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DiscountVoucherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DiscountVoucherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ChequeNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ChequeNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PayerName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PayerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AccountNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AccountNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ChequeDated", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ChequeDated", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ExpiresOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ExpiresOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IfscCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, false, (object) null));
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
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblPayments` (`BillNumber`, `PaymentSerialNumber`, `PaymentMode`, `DiscountVoucherName`, `BankName`, `ChequeNumber`, `PayerName`, `AccountNumber`, `Amount`, `ChequeDated`, `ExpiresOn`, `IfscCode`, `EditedBy`, `EditedOn`, `CreatedBy`, `CreatedOn`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PaymentSerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PaymentMode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DiscountVoucherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ChequeNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PayerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AccountNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ChequeDated", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ExpiresOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblPayments` SET `BillNumber` = ?, `PaymentSerialNumber` = ?, `PaymentMode` = ?, `DiscountVoucherName` = ?, `BankName` = ?, `ChequeNumber` = ?, `PayerName` = ?, `AccountNumber` = ?, `Amount` = ?, `ChequeDated` = ?, `ExpiresOn` = ?, `IfscCode` = ?, `EditedBy` = ?, `EditedOn` = ?, `CreatedBy` = ?, `CreatedOn` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `PaymentSerialNumber` IS NULL) OR (`PaymentSerialNumber` = ?)) AND ((? = 1 AND `PaymentMode` IS NULL) OR (`PaymentMode` = ?)) AND ((? = 1 AND `DiscountVoucherName` IS NULL) OR (`DiscountVoucherName` = ?)) AND ((? = 1 AND `BankName` IS NULL) OR (`BankName` = ?)) AND ((? = 1 AND `ChequeNumber` IS NULL) OR (`ChequeNumber` = ?)) AND ((? = 1 AND `PayerName` IS NULL) OR (`PayerName` = ?)) AND ((? = 1 AND `AccountNumber` IS NULL) OR (`AccountNumber` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `ChequeDated` IS NULL) OR (`ChequeDated` = ?)) AND ((? = 1 AND `ExpiresOn` IS NULL) OR (`ExpiresOn` = ?)) AND ((? = 1 AND `IfscCode` IS NULL) OR (`IfscCode` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PaymentSerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PaymentMode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DiscountVoucherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ChequeNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PayerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AccountNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ChequeDated", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ExpiresOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PaymentSerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PaymentSerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentSerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PaymentMode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PaymentMode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PaymentMode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DiscountVoucherName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DiscountVoucherName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiscountVoucherName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ChequeNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ChequeNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PayerName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PayerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PayerName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AccountNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AccountNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AccountNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ChequeDated", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ChequeDated", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ChequeDated", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ExpiresOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ExpiresOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ExpiresOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IfscCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IfscCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IfscCode", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, BillNumber, PaymentSerialNumber, PaymentMode, DiscountVoucherName, BankName, ChequeNumber, PayerName, AccountNumber, Amount, ChequeDated, ExpiresOn, IfscCode, EditedBy, EditedOn, CreatedBy, CreatedOn FROM tblPayments";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblPaymentsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblPaymentsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblPaymentsDataTable data = new pawnmanagementDataSet1.tblPaymentsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblPaymentsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblPayments");

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
      double? Original_PaymentSerialNumber,
      string Original_PaymentMode,
      string Original_DiscountVoucherName,
      string Original_BankName,
      string Original_ChequeNumber,
      string Original_PayerName,
      string Original_AccountNumber,
      double? Original_Amount,
      DateTime? Original_ChequeDated,
      DateTime? Original_ExpiresOn,
      string Original_IfscCode,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
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
      if (Original_PaymentSerialNumber.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_PaymentSerialNumber.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_PaymentMode == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_PaymentMode;
      }
      if (Original_DiscountVoucherName == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_DiscountVoucherName;
      }
      if (Original_BankName == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_BankName;
      }
      if (Original_ChequeNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_ChequeNumber;
      }
      if (Original_PayerName == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_PayerName;
      }
      if (Original_AccountNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_AccountNumber;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_ChequeDated.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_ChequeDated.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_ExpiresOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_ExpiresOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_IfscCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_IfscCode;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_EditedOn.Value;
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
      double? PaymentSerialNumber,
      string PaymentMode,
      string DiscountVoucherName,
      string BankName,
      string ChequeNumber,
      string PayerName,
      string AccountNumber,
      double? Amount,
      DateTime? ChequeDated,
      DateTime? ExpiresOn,
      string IfscCode,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn)
    {
      if (BillNumber == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) BillNumber;
      if (PaymentSerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) PaymentSerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (PaymentMode == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) PaymentMode;
      if (DiscountVoucherName == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DiscountVoucherName;
      if (BankName == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) BankName;
      if (ChequeNumber == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) ChequeNumber;
      if (PayerName == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) PayerName;
      if (AccountNumber == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) AccountNumber;
      if (Amount.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Amount.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (ChequeDated.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) ChequeDated.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (ExpiresOn.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) ExpiresOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (IfscCode == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) IfscCode;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) EditedOn.Value;
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
      double? PaymentSerialNumber,
      string PaymentMode,
      string DiscountVoucherName,
      string BankName,
      string ChequeNumber,
      string PayerName,
      string AccountNumber,
      double? Amount,
      DateTime? ChequeDated,
      DateTime? ExpiresOn,
      string IfscCode,
      string EditedBy,
      DateTime? EditedOn,
      string CreatedBy,
      DateTime? CreatedOn,
      int Original_ID,
      string Original_BillNumber,
      double? Original_PaymentSerialNumber,
      string Original_PaymentMode,
      string Original_DiscountVoucherName,
      string Original_BankName,
      string Original_ChequeNumber,
      string Original_PayerName,
      string Original_AccountNumber,
      double? Original_Amount,
      DateTime? Original_ChequeDated,
      DateTime? Original_ExpiresOn,
      string Original_IfscCode,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn)
    {
      if (BillNumber == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) BillNumber;
      if (PaymentSerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) PaymentSerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (PaymentMode == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) PaymentMode;
      if (DiscountVoucherName == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DiscountVoucherName;
      if (BankName == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) BankName;
      if (ChequeNumber == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) ChequeNumber;
      if (PayerName == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) PayerName;
      if (AccountNumber == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) AccountNumber;
      if (Amount.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Amount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (ChequeDated.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) ChequeDated.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (ExpiresOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) ExpiresOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (IfscCode == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) IfscCode;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) EditedOn.Value;
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
      this.Adapter.UpdateCommand.Parameters[16].Value = (object) Original_ID;
      if (Original_BillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_BillNumber;
      }
      if (Original_PaymentSerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_PaymentSerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_PaymentMode == null)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_PaymentMode;
      }
      if (Original_DiscountVoucherName == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_DiscountVoucherName;
      }
      if (Original_BankName == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_BankName;
      }
      if (Original_ChequeNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_ChequeNumber;
      }
      if (Original_PayerName == null)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_PayerName;
      }
      if (Original_AccountNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_AccountNumber;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      if (Original_ChequeDated.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_ChequeDated.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      if (Original_ExpiresOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_ExpiresOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      if (Original_IfscCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) Original_IfscCode;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
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
