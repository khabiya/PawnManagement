

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
  public class tblShopDetailsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblShopDetailsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblShopDetails",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "ShopName",
            "ShopName"
          },
          {
            "ShopNameTamil",
            "ShopNameTamil"
          },
          {
            "Proprietor",
            "Proprietor"
          },
          {
            "Address1",
            "Address1"
          },
          {
            "Address2",
            "Address2"
          },
          {
            "Location",
            "Location"
          },
          {
            "City",
            "City"
          },
          {
            "Pincode",
            "Pincode"
          },
          {
            "PblNumber",
            "PblNumber"
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
            "RateOfInterest",
            "RateOfInterest"
          },
          {
            "GaneshjiImagePath",
            "GaneshjiImagePath"
          },
          {
            "LakshmijiImagePath",
            "LakshmijiImagePath"
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
            "ShopCode",
            "ShopCode"
          },
          {
            "Active",
            "Active"
          },
          {
            "Hidden",
            "Hidden"
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
            "VoucherCodeInterestGirvi",
            "VoucherCodeInterestGirvi"
          },
          {
            "VoucherCodeInterestChoot",
            "VoucherCodeInterestChoot"
          },
          {
            "DefaultShop",
            "DefaultShop"
          },
          {
            "BilledBy",
            "BilledBy"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblShopDetails` WHERE ((`ID` = ?) AND ((? = 1 AND `ShopName` IS NULL) OR (`ShopName` = ?)) AND ((? = 1 AND `ShopNameTamil` IS NULL) OR (`ShopNameTamil` = ?)) AND ((? = 1 AND `Proprietor` IS NULL) OR (`Proprietor` = ?)) AND ((? = 1 AND `Address1` IS NULL) OR (`Address1` = ?)) AND ((? = 1 AND `Address2` IS NULL) OR (`Address2` = ?)) AND ((? = 1 AND `Location` IS NULL) OR (`Location` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `PblNumber` IS NULL) OR (`PblNumber` = ?)) AND ((? = 1 AND `PhoneNumber1` IS NULL) OR (`PhoneNumber1` = ?)) AND ((? = 1 AND `PhoneNumber2` IS NULL) OR (`PhoneNumber2` = ?)) AND ((? = 1 AND `RateOfInterest` IS NULL) OR (`RateOfInterest` = ?)) AND ((? = 1 AND `GaneshjiImagePath` IS NULL) OR (`GaneshjiImagePath` = ?)) AND ((? = 1 AND `LakshmijiImagePath` IS NULL) OR (`LakshmijiImagePath` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `ShopCode` IS NULL) OR (`ShopCode` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `Hidden` IS NULL) OR (`Hidden` = ?)) AND ((? = 1 AND `LedgerCode` IS NULL) OR (`LedgerCode` = ?)) AND ((? = 1 AND `VoucherCode` IS NULL) OR (`VoucherCode` = ?)) AND ((? = 1 AND `LedgerCodeInterest` IS NULL) OR (`LedgerCodeInterest` = ?)) AND ((? = 1 AND `VoucherCodeInterestGirvi` IS NULL) OR (`VoucherCodeInterestGirvi` = ?)) AND ((? = 1 AND `VoucherCodeInterestChoot` IS NULL) OR (`VoucherCodeInterestChoot` = ?)) AND ((? = 1 AND `DefaultShop` IS NULL) OR (`DefaultShop` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ShopName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ShopName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ShopNameTamil", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ShopNameTamil", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Proprietor", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Proprietor", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Address1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Address2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Location", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PblNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PblNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RateOfInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RateOfInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GaneshjiImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GaneshjiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LakshmijiImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LakshmijiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ShopCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Hidden", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Hidden", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterestGirvi", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterestGirvi", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterestChoot", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterestChoot", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DefaultShop", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DefaultShop", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblShopDetails` (`ShopName`, `ShopNameTamil`, `Proprietor`, `Address1`, `Address2`, `Location`, `City`, `Pincode`, `PblNumber`, `PhoneNumber1`, `PhoneNumber2`, `RateOfInterest`, `GaneshjiImagePath`, `LakshmijiImagePath`, `CreatedBy`, `CreatedOn`, `ShopCode`, `Active`, `Hidden`, `LedgerCode`, `VoucherCode`, `LedgerCodeInterest`, `VoucherCodeInterestGirvi`, `VoucherCodeInterestChoot`, `DefaultShop`, `BilledBy`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ShopName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ShopNameTamil", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Proprietor", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PblNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RateOfInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GaneshjiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LakshmijiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Hidden", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterestGirvi", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterestChoot", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DefaultShop", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblShopDetails` SET `ShopName` = ?, `ShopNameTamil` = ?, `Proprietor` = ?, `Address1` = ?, `Address2` = ?, `Location` = ?, `City` = ?, `Pincode` = ?, `PblNumber` = ?, `PhoneNumber1` = ?, `PhoneNumber2` = ?, `RateOfInterest` = ?, `GaneshjiImagePath` = ?, `LakshmijiImagePath` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `ShopCode` = ?, `Active` = ?, `Hidden` = ?, `LedgerCode` = ?, `VoucherCode` = ?, `LedgerCodeInterest` = ?, `VoucherCodeInterestGirvi` = ?, `VoucherCodeInterestChoot` = ?, `DefaultShop` = ?, `BilledBy` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `ShopName` IS NULL) OR (`ShopName` = ?)) AND ((? = 1 AND `ShopNameTamil` IS NULL) OR (`ShopNameTamil` = ?)) AND ((? = 1 AND `Proprietor` IS NULL) OR (`Proprietor` = ?)) AND ((? = 1 AND `Address1` IS NULL) OR (`Address1` = ?)) AND ((? = 1 AND `Address2` IS NULL) OR (`Address2` = ?)) AND ((? = 1 AND `Location` IS NULL) OR (`Location` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `PblNumber` IS NULL) OR (`PblNumber` = ?)) AND ((? = 1 AND `PhoneNumber1` IS NULL) OR (`PhoneNumber1` = ?)) AND ((? = 1 AND `PhoneNumber2` IS NULL) OR (`PhoneNumber2` = ?)) AND ((? = 1 AND `RateOfInterest` IS NULL) OR (`RateOfInterest` = ?)) AND ((? = 1 AND `GaneshjiImagePath` IS NULL) OR (`GaneshjiImagePath` = ?)) AND ((? = 1 AND `LakshmijiImagePath` IS NULL) OR (`LakshmijiImagePath` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `ShopCode` IS NULL) OR (`ShopCode` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)) AND ((? = 1 AND `Hidden` IS NULL) OR (`Hidden` = ?)) AND ((? = 1 AND `LedgerCode` IS NULL) OR (`LedgerCode` = ?)) AND ((? = 1 AND `VoucherCode` IS NULL) OR (`VoucherCode` = ?)) AND ((? = 1 AND `LedgerCodeInterest` IS NULL) OR (`LedgerCodeInterest` = ?)) AND ((? = 1 AND `VoucherCodeInterestGirvi` IS NULL) OR (`VoucherCodeInterestGirvi` = ?)) AND ((? = 1 AND `VoucherCodeInterestChoot` IS NULL) OR (`VoucherCodeInterestChoot` = ?)) AND ((? = 1 AND `DefaultShop` IS NULL) OR (`DefaultShop` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ShopName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ShopNameTamil", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Proprietor", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PblNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RateOfInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GaneshjiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LakshmijiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Hidden", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterestGirvi", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("VoucherCodeInterestChoot", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DefaultShop", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ShopName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ShopName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ShopNameTamil", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ShopNameTamil", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopNameTamil", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Proprietor", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Proprietor", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proprietor", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Address1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Address2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Location", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PblNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PblNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PblNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RateOfInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RateOfInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RateOfInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GaneshjiImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GaneshjiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GaneshjiImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LakshmijiImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LakshmijiImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LakshmijiImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ShopCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Hidden", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Hidden", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Hidden", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LedgerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoucherCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerCodeInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LedgerCodeInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerCodeInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterestGirvi", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterestGirvi", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestGirvi", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_VoucherCodeInterestChoot", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_VoucherCodeInterestChoot", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "VoucherCodeInterestChoot", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DefaultShop", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DefaultShop", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultShop", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, ShopName, ShopNameTamil, Proprietor, Address1, Address2, Location, City, Pincode, PblNumber, PhoneNumber1, PhoneNumber2, RateOfInterest, GaneshjiImagePath, LakshmijiImagePath, CreatedBy, CreatedOn, ShopCode, Active, Hidden, LedgerCode, VoucherCode, LedgerCodeInterest, VoucherCodeInterestGirvi, VoucherCodeInterestChoot, DefaultShop, BilledBy FROM tblShopDetails";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblShopDetailsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblShopDetailsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblShopDetailsDataTable data = new pawnmanagementDataSet1.tblShopDetailsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblShopDetailsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblShopDetails");

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
      string Original_ShopName,
      string Original_ShopNameTamil,
      string Original_Proprietor,
      string Original_Address1,
      string Original_Address2,
      string Original_Location,
      string Original_City,
      string Original_Pincode,
      string Original_PblNumber,
      string Original_PhoneNumber1,
      string Original_PhoneNumber2,
      string Original_RateOfInterest,
      string Original_GaneshjiImagePath,
      string Original_LakshmijiImagePath,
      string Original_CreatedBy,
      string Original_CreatedOn,
      string Original_ShopCode,
      string Original_Active,
      string Original_Hidden,
      string Original_LedgerCode,
      string Original_VoucherCode,
      string Original_LedgerCodeInterest,
      string Original_VoucherCodeInterestGirvi,
      string Original_VoucherCodeInterestChoot,
      string Original_DefaultShop,
      string Original_BilledBy)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_ShopName == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_ShopName;
      }
      if (Original_ShopNameTamil == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_ShopNameTamil;
      }
      if (Original_Proprietor == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Proprietor;
      }
      if (Original_Address1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Address1;
      }
      if (Original_Address2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Address2;
      }
      if (Original_Location == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Location;
      }
      if (Original_City == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_Pincode;
      }
      if (Original_PblNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_PblNumber;
      }
      if (Original_PhoneNumber1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_PhoneNumber1;
      }
      if (Original_PhoneNumber2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_PhoneNumber2;
      }
      if (Original_RateOfInterest == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_RateOfInterest;
      }
      if (Original_GaneshjiImagePath == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_GaneshjiImagePath;
      }
      if (Original_LakshmijiImagePath == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_LakshmijiImagePath;
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
      if (Original_CreatedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_CreatedOn;
      }
      if (Original_ShopCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_ShopCode;
      }
      if (Original_Active == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_Active;
      }
      if (Original_Hidden == null)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_Hidden;
      }
      if (Original_LedgerCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) Original_LedgerCode;
      }
      if (Original_VoucherCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) Original_VoucherCode;
      }
      if (Original_LedgerCodeInterest == null)
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) Original_LedgerCodeInterest;
      }
      if (Original_VoucherCodeInterestGirvi == null)
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) Original_VoucherCodeInterestGirvi;
      }
      if (Original_VoucherCodeInterestChoot == null)
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) Original_VoucherCodeInterestChoot;
      }
      if (Original_DefaultShop == null)
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) Original_DefaultShop;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) Original_BilledBy;
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
      string ShopName,
      string ShopNameTamil,
      string Proprietor,
      string Address1,
      string Address2,
      string Location,
      string City,
      string Pincode,
      string PblNumber,
      string PhoneNumber1,
      string PhoneNumber2,
      string RateOfInterest,
      string GaneshjiImagePath,
      string LakshmijiImagePath,
      string CreatedBy,
      string CreatedOn,
      string ShopCode,
      string Active,
      string Hidden,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterestGirvi,
      string VoucherCodeInterestChoot,
      string DefaultShop,
      string BilledBy)
    {
      if (ShopName == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) ShopName;
      if (ShopNameTamil == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) ShopNameTamil;
      if (Proprietor == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Proprietor;
      if (Address1 == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Address1;
      if (Address2 == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Address2;
      if (Location == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Location;
      if (City == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) City;
      if (Pincode == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Pincode;
      if (PblNumber == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) PblNumber;
      if (PhoneNumber1 == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) PhoneNumber1;
      if (PhoneNumber2 == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) PhoneNumber2;
      if (RateOfInterest == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) RateOfInterest;
      if (GaneshjiImagePath == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) GaneshjiImagePath;
      if (LakshmijiImagePath == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) LakshmijiImagePath;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) CreatedOn;
      if (ShopCode == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) ShopCode;
      if (Active == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) Active;
      if (Hidden == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) Hidden;
      if (LedgerCode == null)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) LedgerCode;
      if (VoucherCode == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) VoucherCode;
      if (LedgerCodeInterest == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) LedgerCodeInterest;
      if (VoucherCodeInterestGirvi == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) VoucherCodeInterestGirvi;
      if (VoucherCodeInterestChoot == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) VoucherCodeInterestChoot;
      if (DefaultShop == null)
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DefaultShop;
      if (BilledBy == null)
        this.Adapter.InsertCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[25].Value = (object) BilledBy;
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
      string ShopName,
      string ShopNameTamil,
      string Proprietor,
      string Address1,
      string Address2,
      string Location,
      string City,
      string Pincode,
      string PblNumber,
      string PhoneNumber1,
      string PhoneNumber2,
      string RateOfInterest,
      string GaneshjiImagePath,
      string LakshmijiImagePath,
      string CreatedBy,
      string CreatedOn,
      string ShopCode,
      string Active,
      string Hidden,
      string LedgerCode,
      string VoucherCode,
      string LedgerCodeInterest,
      string VoucherCodeInterestGirvi,
      string VoucherCodeInterestChoot,
      string DefaultShop,
      string BilledBy,
      int Original_ID,
      string Original_ShopName,
      string Original_ShopNameTamil,
      string Original_Proprietor,
      string Original_Address1,
      string Original_Address2,
      string Original_Location,
      string Original_City,
      string Original_Pincode,
      string Original_PblNumber,
      string Original_PhoneNumber1,
      string Original_PhoneNumber2,
      string Original_RateOfInterest,
      string Original_GaneshjiImagePath,
      string Original_LakshmijiImagePath,
      string Original_CreatedBy,
      string Original_CreatedOn,
      string Original_ShopCode,
      string Original_Active,
      string Original_Hidden,
      string Original_LedgerCode,
      string Original_VoucherCode,
      string Original_LedgerCodeInterest,
      string Original_VoucherCodeInterestGirvi,
      string Original_VoucherCodeInterestChoot,
      string Original_DefaultShop,
      string Original_BilledBy)
    {
      if (ShopName == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) ShopName;
      if (ShopNameTamil == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) ShopNameTamil;
      if (Proprietor == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Proprietor;
      if (Address1 == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Address1;
      if (Address2 == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Address2;
      if (Location == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Location;
      if (City == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) City;
      if (Pincode == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Pincode;
      if (PblNumber == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) PblNumber;
      if (PhoneNumber1 == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) PhoneNumber1;
      if (PhoneNumber2 == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) PhoneNumber2;
      if (RateOfInterest == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) RateOfInterest;
      if (GaneshjiImagePath == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) GaneshjiImagePath;
      if (LakshmijiImagePath == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) LakshmijiImagePath;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) CreatedOn;
      if (ShopCode == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) ShopCode;
      if (Active == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) Active;
      if (Hidden == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Hidden;
      if (LedgerCode == null)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) LedgerCode;
      if (VoucherCode == null)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) VoucherCode;
      if (LedgerCodeInterest == null)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) LedgerCodeInterest;
      if (VoucherCodeInterestGirvi == null)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) VoucherCodeInterestGirvi;
      if (VoucherCodeInterestChoot == null)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) VoucherCodeInterestChoot;
      if (DefaultShop == null)
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DefaultShop;
      if (BilledBy == null)
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) BilledBy;
      this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_ID;
      if (Original_ShopName == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_ShopName;
      }
      if (Original_ShopNameTamil == null)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_ShopNameTamil;
      }
      if (Original_Proprietor == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_Proprietor;
      }
      if (Original_Address1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_Address1;
      }
      if (Original_Address2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_Address2;
      }
      if (Original_Location == null)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_Location;
      }
      if (Original_City == null)
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_Pincode;
      }
      if (Original_PblNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) Original_PblNumber;
      }
      if (Original_PhoneNumber1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) Original_PhoneNumber1;
      }
      if (Original_PhoneNumber2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) Original_PhoneNumber2;
      }
      if (Original_RateOfInterest == null)
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) Original_RateOfInterest;
      }
      if (Original_GaneshjiImagePath == null)
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) Original_GaneshjiImagePath;
      }
      if (Original_LakshmijiImagePath == null)
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) Original_LakshmijiImagePath;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) Original_CreatedOn;
      }
      if (Original_ShopCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) Original_ShopCode;
      }
      if (Original_Active == null)
      {
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) Original_Active;
      }
      if (Original_Hidden == null)
      {
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) Original_Hidden;
      }
      if (Original_LedgerCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) Original_LedgerCode;
      }
      if (Original_VoucherCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) Original_VoucherCode;
      }
      if (Original_LedgerCodeInterest == null)
      {
        this.Adapter.UpdateCommand.Parameters[69].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[69].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) Original_LedgerCodeInterest;
      }
      if (Original_VoucherCodeInterestGirvi == null)
      {
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) Original_VoucherCodeInterestGirvi;
      }
      if (Original_VoucherCodeInterestChoot == null)
      {
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) Original_VoucherCodeInterestChoot;
      }
      if (Original_DefaultShop == null)
      {
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) Original_DefaultShop;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) Original_BilledBy;
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
