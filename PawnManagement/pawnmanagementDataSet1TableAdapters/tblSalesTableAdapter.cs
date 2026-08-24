

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
  public class tblSalesTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblSalesTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblSales",
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
            "BillType",
            "BillType"
          },
          {
            "BillNumber",
            "BillNumber"
          },
          {
            "LocationOfCounter",
            "LocationOfCounter"
          },
          {
            "BilledBy",
            "BilledBy"
          },
          {
            "SalesPerson",
            "SalesPerson"
          },
          {
            "CustomerCode",
            "CustomerCode"
          },
          {
            "TotalAmount",
            "TotalAmount"
          },
          {
            "TotalGstAmount",
            "TotalGstAmount"
          },
          {
            "GrandTotal",
            "GrandTotal"
          },
          {
            "Discount",
            "Discount"
          },
          {
            "RoundOff",
            "RoundOff"
          },
          {
            "OldPurchase",
            "OldPurchase"
          },
          {
            "NetPayable",
            "NetPayable"
          },
          {
            "AmountReceived",
            "AmountReceived"
          },
          {
            "Balance",
            "Balance"
          },
          {
            "CommitDate",
            "CommitDate"
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
            "ItemType",
            "ItemType"
          },
          {
            "ItemName",
            "ItemName"
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
            "CoverWeight",
            "CoverWeight"
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
            "GstPerCent",
            "GstPerCent"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "GstTaxAmount",
            "GstTaxAmount"
          },
          {
            "CompanyCode",
            "CompanyCode"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblSales` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `AmountReceived` IS NULL) OR (`AmountReceived` = ?)) AND ((? = 1 AND `Balance` IS NULL) OR (`Balance` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `BillType` IS NULL) OR (`BillType` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)) AND ((? = 1 AND `CommitDate` IS NULL) OR (`CommitDate` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `Discount` IS NULL) OR (`Discount` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `GrandTotal` IS NULL) OR (`GrandTotal` = ?)) AND ((? = 1 AND `LocationOfCounter` IS NULL) OR (`LocationOfCounter` = ?)) AND ((? = 1 AND `NetPayable` IS NULL) OR (`NetPayable` = ?)) AND ((? = 1 AND `OldPurchase` IS NULL) OR (`OldPurchase` = ?)) AND ((? = 1 AND `RoundOff` IS NULL) OR (`RoundOff` = ?)) AND ((? = 1 AND `SalesPerson` IS NULL) OR (`SalesPerson` = ?)) AND ((? = 1 AND `TotalAmount` IS NULL) OR (`TotalAmount` = ?)) AND ((? = 1 AND `TotalGstAmount` IS NULL) OR (`TotalGstAmount` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AmountReceived", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AmountReceived", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Balance", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Balance", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CommitDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CommitDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Discount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GrandTotal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GrandTotal", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LocationOfCounter", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LocationOfCounter", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NetPayable", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NetPayable", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_OldPurchase", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_OldPurchase", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RoundOff", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RoundOff", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SalesPerson", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SalesPerson", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TotalAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TotalGstAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TotalGstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblSales` (`SerialNumber`, `AmountReceived`, `Balance`, `BillDate`, `BillNumber`, `BillType`, `BilledBy`, `CommitDate`, `CreatedBy`, `CreatedOn`, `CustomerCode`, `Discount`, `EditedBy`, `EditedOn`, `GrandTotal`, `LocationOfCounter`, `NetPayable`, `OldPurchase`, `RoundOff`, `SalesPerson`, `TotalAmount`, `TotalGstAmount`, `Amount`, `CompanyCode`, `CoverWeight`, `GrossWeight`, `GstPerCent`, `GstTaxAmount`, `HallMark`, `ItemName`, `ItemType`, `MakingCharge`, `NetWeight`, `StoneCharge`, `StoneWeight`, `Wastage`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AmountReceived", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Balance", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CommitDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Discount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GrandTotal", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LocationOfCounter", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NetPayable", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OldPurchase", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RoundOff", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SalesPerson", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TotalGstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CompanyCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CoverWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CoverWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GstPerCent", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstPerCent", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GstTaxAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GstTaxAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("HallMark", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HallMark", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ItemType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ItemType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MakingCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MakingCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneCharge", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StoneWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StoneWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Wastage", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Wastage", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblSales` SET `SerialNumber` = ?, `AmountReceived` = ?, `Balance` = ?, `BillDate` = ?, `BillNumber` = ?, `BillType` = ?, `BilledBy` = ?, `CommitDate` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `CustomerCode` = ?, `Discount` = ?, `EditedBy` = ?, `EditedOn` = ?, `GrandTotal` = ?, `LocationOfCounter` = ?, `NetPayable` = ?, `OldPurchase` = ?, `RoundOff` = ?, `SalesPerson` = ?, `TotalAmount` = ?, `TotalGstAmount` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `AmountReceived` IS NULL) OR (`AmountReceived` = ?)) AND ((? = 1 AND `Balance` IS NULL) OR (`Balance` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `BillType` IS NULL) OR (`BillType` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)) AND ((? = 1 AND `CommitDate` IS NULL) OR (`CommitDate` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `Discount` IS NULL) OR (`Discount` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `GrandTotal` IS NULL) OR (`GrandTotal` = ?)) AND ((? = 1 AND `LocationOfCounter` IS NULL) OR (`LocationOfCounter` = ?)) AND ((? = 1 AND `NetPayable` IS NULL) OR (`NetPayable` = ?)) AND ((? = 1 AND `OldPurchase` IS NULL) OR (`OldPurchase` = ?)) AND ((? = 1 AND `RoundOff` IS NULL) OR (`RoundOff` = ?)) AND ((? = 1 AND `SalesPerson` IS NULL) OR (`SalesPerson` = ?)) AND ((? = 1 AND `TotalAmount` IS NULL) OR (`TotalAmount` = ?)) AND ((? = 1 AND `TotalGstAmount` IS NULL) OR (`TotalGstAmount` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AmountReceived", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Balance", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CommitDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Discount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GrandTotal", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LocationOfCounter", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NetPayable", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("OldPurchase", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RoundOff", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SalesPerson", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TotalGstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AmountReceived", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AmountReceived", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountReceived", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Balance", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Balance", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Balance", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CommitDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CommitDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CommitDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Discount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GrandTotal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GrandTotal", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrandTotal", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LocationOfCounter", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LocationOfCounter", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LocationOfCounter", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NetPayable", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NetPayable", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetPayable", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_OldPurchase", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_OldPurchase", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldPurchase", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RoundOff", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RoundOff", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RoundOff", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SalesPerson", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SalesPerson", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SalesPerson", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TotalAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TotalAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TotalGstAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TotalGstAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TotalGstAmount", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, AmountReceived, Balance, BillDate, BillNumber, BillType, BilledBy, CommitDate, CreatedBy, CreatedOn, CustomerCode, Discount, EditedBy, EditedOn, GrandTotal, LocationOfCounter, NetPayable, OldPurchase, RoundOff, SalesPerson, TotalAmount, TotalGstAmount, Amount, CompanyCode, CoverWeight, GrossWeight, GstPerCent, GstTaxAmount, HallMark, ItemName, ItemType, MakingCharge, NetWeight, StoneCharge, StoneWeight, Wastage FROM tblSales";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(pawnmanagementDataSet1.tblSalesDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblSalesDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblSalesDataTable data = new pawnmanagementDataSet1.tblSalesDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1.tblSalesDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblSales");

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
      double? Original_AmountReceived,
      double? Original_Balance,
      DateTime? Original_BillDate,
      string Original_BillNumber,
      string Original_BillType,
      string Original_BilledBy,
      DateTime? Original_CommitDate,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_CustomerCode,
      double? Original_Discount,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      double? Original_GrandTotal,
      string Original_LocationOfCounter,
      double? Original_NetPayable,
      double? Original_OldPurchase,
      double? Original_RoundOff,
      string Original_SalesPerson,
      double? Original_TotalAmount,
      double? Original_TotalGstAmount)
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
      if (Original_AmountReceived.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_AmountReceived.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_Balance.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Balance.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      if (Original_BillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_BillNumber;
      }
      if (Original_BillType == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_BillType;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_BilledBy;
      }
      if (Original_CommitDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_CommitDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_CustomerCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_CustomerCode;
      }
      if (Original_Discount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_Discount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
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
      if (Original_GrandTotal.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_GrandTotal.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_LocationOfCounter == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_LocationOfCounter;
      }
      if (Original_NetPayable.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_NetPayable.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      if (Original_OldPurchase.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_OldPurchase.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      if (Original_RoundOff.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_RoundOff.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      if (Original_SalesPerson == null)
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) Original_SalesPerson;
      }
      if (Original_TotalAmount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) Original_TotalAmount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      if (Original_TotalGstAmount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) Original_TotalGstAmount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) DBNull.Value;
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
      double? AmountReceived,
      double? Balance,
      DateTime? BillDate,
      string BillNumber,
      string BillType,
      string BilledBy,
      DateTime? CommitDate,
      string CreatedBy,
      DateTime? CreatedOn,
      string CustomerCode,
      double? Discount,
      string EditedBy,
      DateTime? EditedOn,
      double? GrandTotal,
      string LocationOfCounter,
      double? NetPayable,
      double? OldPurchase,
      double? RoundOff,
      string SalesPerson,
      double? TotalAmount,
      double? TotalGstAmount,
      double? Amount,
      string CompanyCode,
      double? CoverWeight,
      double? GrossWeight,
      double? GstPerCent,
      double? GstTaxAmount,
      double? HallMark,
      string ItemName,
      string ItemType,
      double? MakingCharge,
      double? NetWeight,
      double? StoneCharge,
      double? StoneWeight,
      double? Wastage)
    {
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (AmountReceived.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) AmountReceived.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (Balance.HasValue)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Balance.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      if (BillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) BillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      if (BillNumber == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) BillNumber;
      if (BillType == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) BillType;
      if (BilledBy == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) BilledBy;
      if (CommitDate.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) CommitDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) CustomerCode;
      if (Discount.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Discount.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (GrandTotal.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) GrandTotal.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (LocationOfCounter == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) LocationOfCounter;
      if (NetPayable.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) NetPayable.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (OldPurchase.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) OldPurchase.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (RoundOff.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) RoundOff.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (SalesPerson == null)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) SalesPerson;
      if (TotalAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) TotalAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      if (TotalGstAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) TotalGstAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) Amount.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      if (CompanyCode == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) CompanyCode;
      if (CoverWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[24].Value = (object) CoverWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DBNull.Value;
      if (GrossWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[25].Value = (object) GrossWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[25].Value = (object) DBNull.Value;
      if (GstPerCent.HasValue)
        this.Adapter.InsertCommand.Parameters[26].Value = (object) GstPerCent.Value;
      else
        this.Adapter.InsertCommand.Parameters[26].Value = (object) DBNull.Value;
      if (GstTaxAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[27].Value = (object) GstTaxAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[27].Value = (object) DBNull.Value;
      if (HallMark.HasValue)
        this.Adapter.InsertCommand.Parameters[28].Value = (object) HallMark.Value;
      else
        this.Adapter.InsertCommand.Parameters[28].Value = (object) DBNull.Value;
      if (ItemName == null)
        this.Adapter.InsertCommand.Parameters[29].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[29].Value = (object) ItemName;
      if (ItemType == null)
        this.Adapter.InsertCommand.Parameters[30].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[30].Value = (object) ItemType;
      if (MakingCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[31].Value = (object) MakingCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[31].Value = (object) DBNull.Value;
      if (NetWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[32].Value = (object) NetWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[32].Value = (object) DBNull.Value;
      if (StoneCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[33].Value = (object) StoneCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[33].Value = (object) DBNull.Value;
      if (StoneWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[34].Value = (object) StoneWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[34].Value = (object) DBNull.Value;
      if (Wastage.HasValue)
        this.Adapter.InsertCommand.Parameters[35].Value = (object) Wastage.Value;
      else
        this.Adapter.InsertCommand.Parameters[35].Value = (object) DBNull.Value;
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
      double? AmountReceived,
      double? Balance,
      DateTime? BillDate,
      string BillNumber,
      string BillType,
      string BilledBy,
      DateTime? CommitDate,
      string CreatedBy,
      DateTime? CreatedOn,
      string CustomerCode,
      double? Discount,
      string EditedBy,
      DateTime? EditedOn,
      double? GrandTotal,
      string LocationOfCounter,
      double? NetPayable,
      double? OldPurchase,
      double? RoundOff,
      string SalesPerson,
      double? TotalAmount,
      double? TotalGstAmount,
      int Original_ID,
      double? Original_SerialNumber,
      double? Original_AmountReceived,
      double? Original_Balance,
      DateTime? Original_BillDate,
      string Original_BillNumber,
      string Original_BillType,
      string Original_BilledBy,
      DateTime? Original_CommitDate,
      string Original_CreatedBy,
      DateTime? Original_CreatedOn,
      string Original_CustomerCode,
      double? Original_Discount,
      string Original_EditedBy,
      DateTime? Original_EditedOn,
      double? Original_GrandTotal,
      string Original_LocationOfCounter,
      double? Original_NetPayable,
      double? Original_OldPurchase,
      double? Original_RoundOff,
      string Original_SalesPerson,
      double? Original_TotalAmount,
      double? Original_TotalGstAmount)
    {
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (AmountReceived.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) AmountReceived.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (Balance.HasValue)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Balance.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      if (BillDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) BillDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      if (BillNumber == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) BillNumber;
      if (BillType == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) BillType;
      if (BilledBy == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) BilledBy;
      if (CommitDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) CommitDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) CustomerCode;
      if (Discount.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Discount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) EditedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (GrandTotal.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) GrandTotal.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      if (LocationOfCounter == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) LocationOfCounter;
      if (NetPayable.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) NetPayable.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      if (OldPurchase.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) OldPurchase.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (RoundOff.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) RoundOff.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      if (SalesPerson == null)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) SalesPerson;
      if (TotalAmount.HasValue)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) TotalAmount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      if (TotalGstAmount.HasValue)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) TotalGstAmount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_ID;
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      if (Original_AmountReceived.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_AmountReceived.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      if (Original_Balance.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_Balance.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_BillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_BillNumber;
      }
      if (Original_BillType == null)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_BillType;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_BilledBy;
      }
      if (Original_CommitDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_CommitDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
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
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      if (Original_CustomerCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) Original_CustomerCode;
      }
      if (Original_Discount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) Original_Discount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) Original_EditedBy;
      }
      if (Original_EditedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) Original_EditedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      if (Original_GrandTotal.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) Original_GrandTotal.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      if (Original_LocationOfCounter == null)
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) Original_LocationOfCounter;
      }
      if (Original_NetPayable.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) Original_NetPayable.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) DBNull.Value;
      }
      if (Original_OldPurchase.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) Original_OldPurchase.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) DBNull.Value;
      }
      if (Original_RoundOff.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) Original_RoundOff.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) DBNull.Value;
      }
      if (Original_SalesPerson == null)
      {
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) Original_SalesPerson;
      }
      if (Original_TotalAmount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) Original_TotalAmount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) DBNull.Value;
      }
      if (Original_TotalGstAmount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) Original_TotalGstAmount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) DBNull.Value;
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
