

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
  public class tblPledgeTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblPledgeTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblPledge",
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
            "BillDate",
            "BillDate"
          },
          {
            "CustomerCode",
            "CustomerCode"
          },
          {
            "CustomerName",
            "CustomerName"
          },
          {
            "DoorNumber",
            "DoorNumber"
          },
          {
            "Addr1",
            "Addr1"
          },
          {
            "Addr2",
            "Addr2"
          },
          {
            "Addr3",
            "Addr3"
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
            "PhoneNumber",
            "PhoneNumber"
          },
          {
            "AmountInWords",
            "AmountInWords"
          },
          {
            "CustomerImagePath",
            "CustomerImagePath"
          },
          {
            "Type",
            "Type"
          },
          {
            "GrossWeight",
            "GrossWeight"
          },
          {
            "Deduction",
            "Deduction"
          },
          {
            "NetWeight",
            "NetWeight"
          },
          {
            "PureWeight",
            "PureWeight"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "PresentValue",
            "PresentValue"
          },
          {
            "OldBillNumber",
            "OldBillNumber"
          },
          {
            "Reminder",
            "Reminder"
          },
          {
            "temp1",
            "temp1"
          },
          {
            "InterestRateDisplaySymbol",
            "InterestRateDisplaySymbol"
          },
          {
            "Redeemed",
            "Redeemed"
          },
          {
            "NoOfMonths",
            "NoOfMonths"
          },
          {
            "InterestLess",
            "InterestLess"
          },
          {
            "temp2",
            "temp2"
          },
          {
            "NoticeCharge",
            "NoticeCharge"
          },
          {
            "OtherCharges",
            "OtherCharges"
          },
          {
            "Discount",
            "Discount"
          },
          {
            "temp3",
            "temp3"
          },
          {
            "temp4",
            "temp4"
          },
          {
            "RedemptionDate",
            "RedemptionDate"
          },
          {
            "AuctionDate",
            "AuctionDate"
          },
          {
            "NoOfMonths16",
            "NoOfMonths16"
          },
          {
            "Interest16",
            "Interest16"
          },
          {
            "RedemptionAmount16",
            "RedemptionAmount16"
          },
          {
            "BankCode",
            "BankCode"
          },
          {
            "BankSerialNumber",
            "BankSerialNumber"
          },
          {
            "PledgeCreatedBy",
            "PledgeCreatedBy"
          },
          {
            "PledgeCreatedOn",
            "PledgeCreatedOn"
          },
          {
            "RedeemedBy",
            "RedeemedBy"
          },
          {
            "RedeemedOn",
            "RedeemedOn"
          },
          {
            "tokenprinted",
            "tokenprinted"
          },
          {
            "temp5",
            "temp5"
          },
          {
            "ArticlesWithoutHr",
            "ArticlesWithoutHr"
          },
          {
            "ArticlesWithHr",
            "ArticlesWithHr"
          },
          {
            "PledgeArticlesCombined",
            "PledgeArticlesCombined"
          },
          {
            "ShopCode",
            "ShopCode"
          },
          {
            "InterestType",
            "InterestType"
          },
          {
            "Articles",
            "Articles"
          },
          {
            "StockCheckedOn",
            "StockCheckedOn"
          },
          {
            "StockCheckedBy",
            "StockCheckedBy"
          },
          {
            "BilledBy",
            "BilledBy"
          },
          {
            "RedemptionBillNumber",
            "RedemptionBillNumber"
          },
          {
            "AuctionAmount",
            "AuctionAmount"
          },
          {
            "kdisNumber",
            "kdisNumber"
          },
          {
            "PurchasedBy",
            "PurchasedBy"
          },
          {
            "AuctionedBy",
            "AuctionedBy"
          },
          {
            "Vault",
            "Vault"
          },
          {
            "IntimationLetterSent",
            "IntimationLetterSent"
          },
          {
            "IntimationLetterSentOn",
            "IntimationLetterSentOn"
          },
          {
            "AuctionLetterSent",
            "AuctionLetterSent"
          },
          {
            "AuctionLetterSentOn",
            "AuctionLetterSentOn"
          },
          {
            "IntimationLetterPostalId",
            "IntimationLetterPostalId"
          },
          {
            "AuctionLetterPostalId",
            "AuctionLetterPostalId"
          },
          {
            "IntimationLetterReceivedBy",
            "IntimationLetterReceivedBy"
          },
          {
            "AuctionLetterReceivedBy",
            "AuctionLetterReceivedBy"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblPledge` WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `CustomerName` IS NULL) OR (`CustomerName` = ?)) AND ((? = 1 AND `DoorNumber` IS NULL) OR (`DoorNumber` = ?)) AND ((? = 1 AND `Addr1` IS NULL) OR (`Addr1` = ?)) AND ((? = 1 AND `Addr2` IS NULL) OR (`Addr2` = ?)) AND ((? = 1 AND `Addr3` IS NULL) OR (`Addr3` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `PhoneNumber` IS NULL) OR (`PhoneNumber` = ?)) AND ((? = 1 AND `AmountInWords` IS NULL) OR (`AmountInWords` = ?)) AND ((? = 1 AND `CustomerImagePath` IS NULL) OR (`CustomerImagePath` = ?)) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `Deduction` IS NULL) OR (`Deduction` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `PureWeight` IS NULL) OR (`PureWeight` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `PresentValue` IS NULL) OR (`PresentValue` = ?)) AND ((? = 1 AND `OldBillNumber` IS NULL) OR (`OldBillNumber` = ?)) AND ((? = 1 AND `Reminder` IS NULL) OR (`Reminder` = ?)) AND ((? = 1 AND `temp1` IS NULL) OR (`temp1` = ?)) AND ((? = 1 AND `InterestRateDisplaySymbol` IS NULL) OR (`InterestRateDisplaySymbol` = ?)) AND ((? = 1 AND `Redeemed` IS NULL) OR (`Redeemed` = ?)) AND ((? = 1 AND `NoOfMonths` IS NULL) OR (`NoOfMonths` = ?)) AND ((? = 1 AND `InterestLess` IS NULL) OR (`InterestLess` = ?)) AND ((? = 1 AND `temp2` IS NULL) OR (`temp2` = ?)) AND ((? = 1 AND `NoticeCharge` IS NULL) OR (`NoticeCharge` = ?)) AND ((? = 1 AND `OtherCharges` IS NULL) OR (`OtherCharges` = ?)) AND ((? = 1 AND `Discount` IS NULL) OR (`Discount` = ?)) AND ((? = 1 AND `temp3` IS NULL) OR (`temp3` = ?)) AND ((? = 1 AND `temp4` IS NULL) OR (`temp4` = ?)) AND ((? = 1 AND `RedemptionDate` IS NULL) OR (`RedemptionDate` = ?)) AND ((? = 1 AND `AuctionDate` IS NULL) OR (`AuctionDate` = ?)) AND ((? = 1 AND `NoOfMonths16` IS NULL) OR (`NoOfMonths16` = ?)) AND ((? = 1 AND `Interest16` IS NULL) OR (`Interest16` = ?)) AND ((? = 1 AND `RedemptionAmount16` IS NULL) OR (`RedemptionAmount16` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `BankSerialNumber` IS NULL) OR (`BankSerialNumber` = ?)) AND ((? = 1 AND `PledgeCreatedBy` IS NULL) OR (`PledgeCreatedBy` = ?)) AND ((? = 1 AND `PledgeCreatedOn` IS NULL) OR (`PledgeCreatedOn` = ?)) AND ((? = 1 AND `RedeemedBy` IS NULL) OR (`RedeemedBy` = ?)) AND ((? = 1 AND `RedeemedOn` IS NULL) OR (`RedeemedOn` = ?)) AND ((? = 1 AND `tokenprinted` IS NULL) OR (`tokenprinted` = ?)) AND ((? = 1 AND `temp5` IS NULL) OR (`temp5` = ?)) AND ((? = 1 AND `PledgeArticlesCombined` IS NULL) OR (`PledgeArticlesCombined` = ?)) AND ((? = 1 AND `ShopCode` IS NULL) OR (`ShopCode` = ?)) AND ((? = 1 AND `InterestType` IS NULL) OR (`InterestType` = ?)) AND ((? = 1 AND `StockCheckedOn` IS NULL) OR (`StockCheckedOn` = ?)) AND ((? = 1 AND `StockCheckedBy` IS NULL) OR (`StockCheckedBy` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)) AND ((? = 1 AND `RedemptionBillNumber` IS NULL) OR (`RedemptionBillNumber` = ?)) AND ((? = 1 AND `AuctionAmount` IS NULL) OR (`AuctionAmount` = ?)) AND ((? = 1 AND `kdisNumber` IS NULL) OR (`kdisNumber` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `AuctionedBy` IS NULL) OR (`AuctionedBy` = ?)) AND ((? = 1 AND `Vault` IS NULL) OR (`Vault` = ?)) AND ((? = 1 AND `AuctionLetterPostalId` IS NULL) OR (`AuctionLetterPostalId` = ?)) AND ((? = 1 AND `AuctionLetterReceivedBy` IS NULL) OR (`AuctionLetterReceivedBy` = ?)) AND ((? = 1 AND `AuctionLetterSent` IS NULL) OR (`AuctionLetterSent` = ?)) AND ((? = 1 AND `AuctionLetterSentOn` IS NULL) OR (`AuctionLetterSentOn` = ?)) AND ((? = 1 AND `IntimationLetterPostalId` IS NULL) OR (`IntimationLetterPostalId` = ?)) AND ((? = 1 AND `IntimationLetterReceivedBy` IS NULL) OR (`IntimationLetterReceivedBy` = ?)) AND ((? = 1 AND `IntimationLetterSent` IS NULL) OR (`IntimationLetterSent` = ?)) AND ((? = 1 AND `IntimationLetterSentOn` IS NULL) OR (`IntimationLetterSentOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CustomerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DoorNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Addr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Addr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Addr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Addr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Addr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Addr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AmountInWords", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AmountInWords", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CustomerImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Deduction", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Deduction", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PureWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_OldBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_OldBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Reminder", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Reminder", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_temp1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_temp1", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestRateDisplaySymbol", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestRateDisplaySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Redeemed", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Redeemed", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_temp2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_temp2", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_temp3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_temp3", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_temp4", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_temp4", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NoOfMonths16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NoOfMonths16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Interest16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Interest16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionAmount16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionAmount16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankSerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankSerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeCreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeCreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeCreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeCreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedeemedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedeemedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedeemedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedeemedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_tokenprinted", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_tokenprinted", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_temp5", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_temp5", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeArticlesCombined", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeArticlesCombined", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ShopCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StockCheckedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StockCheckedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_StockCheckedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_StockCheckedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_kdisNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_kdisNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Vault", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Vault", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterPostalId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterReceivedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterSent", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterSentOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterPostalId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterReceivedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterSent", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterSentOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblPledge` (`BillNumber`, `BillDate`, `CustomerCode`, `CustomerName`, `DoorNumber`, `Addr1`, `Addr2`, `Addr3`, `City`, `Pincode`, `PhoneNumber`, `AmountInWords`, `CustomerImagePath`, `Type`, `GrossWeight`, `Deduction`, `NetWeight`, `PureWeight`, `Amount`, `PresentValue`, `OldBillNumber`, `Reminder`, `temp1`, `InterestRateDisplaySymbol`, `Redeemed`, `NoOfMonths`, `InterestLess`, `temp2`, `NoticeCharge`, `OtherCharges`, `Discount`, `temp3`, `temp4`, `RedemptionDate`, `AuctionDate`, `NoOfMonths16`, `Interest16`, `RedemptionAmount16`, `BankCode`, `BankSerialNumber`, `PledgeCreatedBy`, `PledgeCreatedOn`, `RedeemedBy`, `RedeemedOn`, `tokenprinted`, `temp5`, `ArticlesWithoutHr`, `ArticlesWithHr`, `PledgeArticlesCombined`, `ShopCode`, `InterestType`, `Articles`, `StockCheckedOn`, `StockCheckedBy`, `BilledBy`, `RedemptionBillNumber`, `AuctionAmount`, `kdisNumber`, `PurchasedBy`, `AuctionedBy`, `Vault`, `AuctionLetterPostalId`, `AuctionLetterReceivedBy`, `AuctionLetterSent`, `AuctionLetterSentOn`, `IntimationLetterPostalId`, `IntimationLetterReceivedBy`, `IntimationLetterSent`, `IntimationLetterSentOn`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Addr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Addr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Addr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AmountInWords", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Deduction", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OldBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Reminder", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp1", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestRateDisplaySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Redeemed", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp2", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp3", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp4", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoOfMonths16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Interest16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionAmount16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankSerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeCreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeCreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedeemedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedeemedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("tokenprinted", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp5", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ArticlesWithoutHr", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArticlesWithoutHr", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ArticlesWithHr", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArticlesWithHr", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeArticlesCombined", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Articles", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Articles", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StockCheckedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("StockCheckedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("kdisNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Vault", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AuctionLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IntimationLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IntimationLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IntimationLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("IntimationLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblPledge` SET `BillNumber` = ?, `BillDate` = ?, `CustomerCode` = ?, `CustomerName` = ?, `DoorNumber` = ?, `Addr1` = ?, `Addr2` = ?, `Addr3` = ?, `City` = ?, `Pincode` = ?, `PhoneNumber` = ?, `AmountInWords` = ?, `CustomerImagePath` = ?, `Type` = ?, `GrossWeight` = ?, `Deduction` = ?, `NetWeight` = ?, `PureWeight` = ?, `Amount` = ?, `PresentValue` = ?, `OldBillNumber` = ?, `Reminder` = ?, `temp1` = ?, `InterestRateDisplaySymbol` = ?, `Redeemed` = ?, `NoOfMonths` = ?, `InterestLess` = ?, `temp2` = ?, `NoticeCharge` = ?, `OtherCharges` = ?, `Discount` = ?, `temp3` = ?, `temp4` = ?, `RedemptionDate` = ?, `AuctionDate` = ?, `NoOfMonths16` = ?, `Interest16` = ?, `RedemptionAmount16` = ?, `BankCode` = ?, `BankSerialNumber` = ?, `PledgeCreatedBy` = ?, `PledgeCreatedOn` = ?, `RedeemedBy` = ?, `RedeemedOn` = ?, `tokenprinted` = ?, `temp5` = ?, `ArticlesWithoutHr` = ?, `ArticlesWithHr` = ?, `PledgeArticlesCombined` = ?, `ShopCode` = ?, `InterestType` = ?, `Articles` = ?, `StockCheckedOn` = ?, `StockCheckedBy` = ?, `BilledBy` = ?, `RedemptionBillNumber` = ?, `AuctionAmount` = ?, `kdisNumber` = ?, `PurchasedBy` = ?, `AuctionedBy` = ?, `Vault` = ?, `AuctionLetterPostalId` = ?, `AuctionLetterReceivedBy` = ?, `AuctionLetterSent` = ?, `AuctionLetterSentOn` = ?, `IntimationLetterPostalId` = ?, `IntimationLetterReceivedBy` = ?, `IntimationLetterSent` = ?, `IntimationLetterSentOn` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `BillNumber` IS NULL) OR (`BillNumber` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `CustomerCode` IS NULL) OR (`CustomerCode` = ?)) AND ((? = 1 AND `CustomerName` IS NULL) OR (`CustomerName` = ?)) AND ((? = 1 AND `DoorNumber` IS NULL) OR (`DoorNumber` = ?)) AND ((? = 1 AND `Addr1` IS NULL) OR (`Addr1` = ?)) AND ((? = 1 AND `Addr2` IS NULL) OR (`Addr2` = ?)) AND ((? = 1 AND `Addr3` IS NULL) OR (`Addr3` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `PhoneNumber` IS NULL) OR (`PhoneNumber` = ?)) AND ((? = 1 AND `AmountInWords` IS NULL) OR (`AmountInWords` = ?)) AND ((? = 1 AND `CustomerImagePath` IS NULL) OR (`CustomerImagePath` = ?)) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `GrossWeight` IS NULL) OR (`GrossWeight` = ?)) AND ((? = 1 AND `Deduction` IS NULL) OR (`Deduction` = ?)) AND ((? = 1 AND `NetWeight` IS NULL) OR (`NetWeight` = ?)) AND ((? = 1 AND `PureWeight` IS NULL) OR (`PureWeight` = ?)) AND ((? = 1 AND `Amount` IS NULL) OR (`Amount` = ?)) AND ((? = 1 AND `PresentValue` IS NULL) OR (`PresentValue` = ?)) AND ((? = 1 AND `OldBillNumber` IS NULL) OR (`OldBillNumber` = ?)) AND ((? = 1 AND `Reminder` IS NULL) OR (`Reminder` = ?)) AND ((? = 1 AND `temp1` IS NULL) OR (`temp1` = ?)) AND ((? = 1 AND `InterestRateDisplaySymbol` IS NULL) OR (`InterestRateDisplaySymbol` = ?)) AND ((? = 1 AND `Redeemed` IS NULL) OR (`Redeemed` = ?)) AND ((? = 1 AND `NoOfMonths` IS NULL) OR (`NoOfMonths` = ?)) AND ((? = 1 AND `InterestLess` IS NULL) OR (`InterestLess` = ?)) AND ((? = 1 AND `temp2` IS NULL) OR (`temp2` = ?)) AND ((? = 1 AND `NoticeCharge` IS NULL) OR (`NoticeCharge` = ?)) AND ((? = 1 AND `OtherCharges` IS NULL) OR (`OtherCharges` = ?)) AND ((? = 1 AND `Discount` IS NULL) OR (`Discount` = ?)) AND ((? = 1 AND `temp3` IS NULL) OR (`temp3` = ?)) AND ((? = 1 AND `temp4` IS NULL) OR (`temp4` = ?)) AND ((? = 1 AND `RedemptionDate` IS NULL) OR (`RedemptionDate` = ?)) AND ((? = 1 AND `AuctionDate` IS NULL) OR (`AuctionDate` = ?)) AND ((? = 1 AND `NoOfMonths16` IS NULL) OR (`NoOfMonths16` = ?)) AND ((? = 1 AND `Interest16` IS NULL) OR (`Interest16` = ?)) AND ((? = 1 AND `RedemptionAmount16` IS NULL) OR (`RedemptionAmount16` = ?)) AND ((? = 1 AND `BankCode` IS NULL) OR (`BankCode` = ?)) AND ((? = 1 AND `BankSerialNumber` IS NULL) OR (`BankSerialNumber` = ?)) AND ((? = 1 AND `PledgeCreatedBy` IS NULL) OR (`PledgeCreatedBy` = ?)) AND ((? = 1 AND `PledgeCreatedOn` IS NULL) OR (`PledgeCreatedOn` = ?)) AND ((? = 1 AND `RedeemedBy` IS NULL) OR (`RedeemedBy` = ?)) AND ((? = 1 AND `RedeemedOn` IS NULL) OR (`RedeemedOn` = ?)) AND ((? = 1 AND `tokenprinted` IS NULL) OR (`tokenprinted` = ?)) AND ((? = 1 AND `temp5` IS NULL) OR (`temp5` = ?)) AND ((? = 1 AND `PledgeArticlesCombined` IS NULL) OR (`PledgeArticlesCombined` = ?)) AND ((? = 1 AND `ShopCode` IS NULL) OR (`ShopCode` = ?)) AND ((? = 1 AND `InterestType` IS NULL) OR (`InterestType` = ?)) AND ((? = 1 AND `StockCheckedOn` IS NULL) OR (`StockCheckedOn` = ?)) AND ((? = 1 AND `StockCheckedBy` IS NULL) OR (`StockCheckedBy` = ?)) AND ((? = 1 AND `BilledBy` IS NULL) OR (`BilledBy` = ?)) AND ((? = 1 AND `RedemptionBillNumber` IS NULL) OR (`RedemptionBillNumber` = ?)) AND ((? = 1 AND `AuctionAmount` IS NULL) OR (`AuctionAmount` = ?)) AND ((? = 1 AND `kdisNumber` IS NULL) OR (`kdisNumber` = ?)) AND ((? = 1 AND `PurchasedBy` IS NULL) OR (`PurchasedBy` = ?)) AND ((? = 1 AND `AuctionedBy` IS NULL) OR (`AuctionedBy` = ?)) AND ((? = 1 AND `Vault` IS NULL) OR (`Vault` = ?)) AND ((? = 1 AND `AuctionLetterPostalId` IS NULL) OR (`AuctionLetterPostalId` = ?)) AND ((? = 1 AND `AuctionLetterReceivedBy` IS NULL) OR (`AuctionLetterReceivedBy` = ?)) AND ((? = 1 AND `AuctionLetterSent` IS NULL) OR (`AuctionLetterSent` = ?)) AND ((? = 1 AND `AuctionLetterSentOn` IS NULL) OR (`AuctionLetterSentOn` = ?)) AND ((? = 1 AND `IntimationLetterPostalId` IS NULL) OR (`IntimationLetterPostalId` = ?)) AND ((? = 1 AND `IntimationLetterReceivedBy` IS NULL) OR (`IntimationLetterReceivedBy` = ?)) AND ((? = 1 AND `IntimationLetterSent` IS NULL) OR (`IntimationLetterSent` = ?)) AND ((? = 1 AND `IntimationLetterSentOn` IS NULL) OR (`IntimationLetterSentOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CustomerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Addr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Addr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Addr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AmountInWords", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CustomerImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("GrossWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Deduction", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NetWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("OldBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Reminder", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("temp1", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestRateDisplaySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Redeemed", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("temp2", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("temp3", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("temp4", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NoOfMonths16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Interest16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionAmount16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankSerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeCreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeCreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedeemedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedeemedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("tokenprinted", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("temp5", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ArticlesWithoutHr", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArticlesWithoutHr", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ArticlesWithHr", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArticlesWithHr", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeArticlesCombined", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Articles", OleDbType.LongVarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Articles", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StockCheckedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("StockCheckedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("kdisNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Vault", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AuctionLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IntimationLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IntimationLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IntimationLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IntimationLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CustomerName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DoorNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Addr1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Addr1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Addr2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Addr2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Addr3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Addr3", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Addr3", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AmountInWords", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AmountInWords", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AmountInWords", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CustomerImagePath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CustomerImagePath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerImagePath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_GrossWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_GrossWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "GrossWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Deduction", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Deduction", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NetWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NetWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NetWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PureWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PureWeight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Amount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PresentValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PresentValue", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_OldBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_OldBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OldBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Reminder", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Reminder", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Reminder", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_temp1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_temp1", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestRateDisplaySymbol", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestRateDisplaySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestRateDisplaySymbol", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Redeemed", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Redeemed", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Redeemed", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NoOfMonths", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_temp2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_temp2", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NoticeCharge", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_OtherCharges", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharges", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Discount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Discount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_temp3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_temp3", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_temp4", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_temp4", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NoOfMonths16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NoOfMonths16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Interest16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Interest16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionAmount16", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionAmount16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankSerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankSerialNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankSerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeCreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeCreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeCreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeCreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeCreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedeemedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedeemedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedeemedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedeemedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedeemedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_tokenprinted", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_tokenprinted", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "tokenprinted", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_temp5", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_temp5", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp5", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeArticlesCombined", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeArticlesCombined", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeArticlesCombined", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ShopCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestType", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestType", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestType", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StockCheckedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StockCheckedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_StockCheckedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_StockCheckedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "StockCheckedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BilledBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionAmount", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_kdisNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_kdisNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "kdisNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurchasedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurchasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurchasedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Vault", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Vault", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Vault", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterPostalId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterPostalId", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterReceivedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterReceivedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterSent", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSent", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AuctionLetterSentOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AuctionLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AuctionLetterSentOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterPostalId", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterPostalId", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterPostalId", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterReceivedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterReceivedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterReceivedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterSent", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterSent", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSent", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_IntimationLetterSentOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_IntimationLetterSentOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IntimationLetterSentOn", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, BillNumber, BillDate, CustomerCode, CustomerName, DoorNumber, Addr1, Addr2, Addr3, City, Pincode, PhoneNumber, AmountInWords, CustomerImagePath, Type, GrossWeight, Deduction, NetWeight, PureWeight, Amount, PresentValue, OldBillNumber, Reminder, temp1, InterestRateDisplaySymbol, Redeemed, NoOfMonths, InterestLess, temp2, NoticeCharge, OtherCharges, Discount, temp3, temp4, RedemptionDate, AuctionDate, NoOfMonths16, Interest16, RedemptionAmount16, BankCode, BankSerialNumber, PledgeCreatedBy, PledgeCreatedOn, RedeemedBy, RedeemedOn, tokenprinted, temp5, ArticlesWithoutHr, ArticlesWithHr, PledgeArticlesCombined, ShopCode, InterestType, Articles, StockCheckedOn, StockCheckedBy, BilledBy, RedemptionBillNumber, AuctionAmount, kdisNumber, PurchasedBy, AuctionedBy, Vault, AuctionLetterPostalId, AuctionLetterReceivedBy, AuctionLetterSent, AuctionLetterSentOn, IntimationLetterPostalId, IntimationLetterReceivedBy, IntimationLetterSent, IntimationLetterSentOn FROM tblPledge";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblPledgeDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblPledgeDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblPledgeDataTable data = new pawnmanagementDataSet1.tblPledgeDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblPledgeDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblPledge");

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
      DateTime? Original_BillDate,
      string Original_CustomerCode,
      string Original_CustomerName,
      string Original_DoorNumber,
      string Original_Addr1,
      string Original_Addr2,
      string Original_Addr3,
      string Original_City,
      string Original_Pincode,
      string Original_PhoneNumber,
      string Original_AmountInWords,
      string Original_CustomerImagePath,
      string Original_Type,
      string Original_GrossWeight,
      string Original_Deduction,
      string Original_NetWeight,
      double? Original_PureWeight,
      int? Original_Amount,
      int? Original_PresentValue,
      string Original_OldBillNumber,
      string Original_Reminder,
      double? Original_temp1,
      string Original_InterestRateDisplaySymbol,
      string Original_Redeemed,
      int? Original_NoOfMonths,
      int? Original_InterestLess,
      double? Original_temp2,
      int? Original_NoticeCharge,
      int? Original_OtherCharges,
      int? Original_Discount,
      double? Original_temp3,
      double? Original_temp4,
      DateTime? Original_RedemptionDate,
      DateTime? Original_AuctionDate,
      string Original_NoOfMonths16,
      string Original_Interest16,
      string Original_RedemptionAmount16,
      string Original_BankCode,
      string Original_BankSerialNumber,
      string Original_PledgeCreatedBy,
      string Original_PledgeCreatedOn,
      string Original_RedeemedBy,
      string Original_RedeemedOn,
      string Original_tokenprinted,
      double? Original_temp5,
      string Original_PledgeArticlesCombined,
      string Original_ShopCode,
      string Original_InterestType,
      DateTime? Original_StockCheckedOn,
      string Original_StockCheckedBy,
      string Original_BilledBy,
      string Original_RedemptionBillNumber,
      double? Original_AuctionAmount,
      string Original_kdisNumber,
      string Original_PurchasedBy,
      string Original_AuctionedBy,
      string Original_Vault,
      string Original_AuctionLetterPostalId,
      string Original_AuctionLetterReceivedBy,
      string Original_AuctionLetterSent,
      DateTime? Original_AuctionLetterSentOn,
      string Original_IntimationLetterPostalId,
      string Original_IntimationLetterReceivedBy,
      string Original_IntimationLetterSent,
      DateTime? Original_IntimationLetterSentOn)
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
      if (Original_CustomerName == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_CustomerName;
      }
      if (Original_DoorNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_DoorNumber;
      }
      if (Original_Addr1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Addr1;
      }
      if (Original_Addr2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_Addr2;
      }
      if (Original_Addr3 == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_Addr3;
      }
      if (Original_City == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_Pincode;
      }
      if (Original_PhoneNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_PhoneNumber;
      }
      if (Original_AmountInWords == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_AmountInWords;
      }
      if (Original_CustomerImagePath == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_CustomerImagePath;
      }
      if (Original_Type == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_Type;
      }
      if (Original_GrossWeight == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_GrossWeight;
      }
      if (Original_Deduction == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_Deduction;
      }
      if (Original_NetWeight == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_NetWeight;
      }
      if (Original_PureWeight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_PureWeight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      if (Original_PresentValue.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) Original_PresentValue.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      if (Original_OldBillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[41].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[42].Value = (object) Original_OldBillNumber;
      }
      if (Original_Reminder == null)
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[43].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[44].Value = (object) Original_Reminder;
      }
      if (Original_temp1.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) Original_temp1.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[45].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      if (Original_InterestRateDisplaySymbol == null)
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[47].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[48].Value = (object) Original_InterestRateDisplaySymbol;
      }
      if (Original_Redeemed == null)
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[49].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[50].Value = (object) Original_Redeemed;
      }
      if (Original_NoOfMonths.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) Original_NoOfMonths.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[51].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      if (Original_InterestLess.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[53].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[54].Value = (object) Original_InterestLess.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[53].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      if (Original_temp2.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[55].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[56].Value = (object) Original_temp2.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[55].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[56].Value = (object) DBNull.Value;
      }
      if (Original_NoticeCharge.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[57].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[58].Value = (object) Original_NoticeCharge.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[57].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[58].Value = (object) DBNull.Value;
      }
      if (Original_OtherCharges.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[59].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[60].Value = (object) Original_OtherCharges.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[59].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[60].Value = (object) DBNull.Value;
      }
      if (Original_Discount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[61].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[62].Value = (object) Original_Discount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[61].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[62].Value = (object) DBNull.Value;
      }
      if (Original_temp3.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[63].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[64].Value = (object) Original_temp3.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[63].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[64].Value = (object) DBNull.Value;
      }
      if (Original_temp4.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[65].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[66].Value = (object) Original_temp4.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[65].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[66].Value = (object) DBNull.Value;
      }
      if (Original_RedemptionDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[67].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[68].Value = (object) Original_RedemptionDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[67].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[68].Value = (object) DBNull.Value;
      }
      if (Original_AuctionDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[69].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[70].Value = (object) Original_AuctionDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[69].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[70].Value = (object) DBNull.Value;
      }
      if (Original_NoOfMonths16 == null)
      {
        this.Adapter.DeleteCommand.Parameters[71].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[72].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[71].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[72].Value = (object) Original_NoOfMonths16;
      }
      if (Original_Interest16 == null)
      {
        this.Adapter.DeleteCommand.Parameters[73].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[74].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[73].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[74].Value = (object) Original_Interest16;
      }
      if (Original_RedemptionAmount16 == null)
      {
        this.Adapter.DeleteCommand.Parameters[75].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[76].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[75].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[76].Value = (object) Original_RedemptionAmount16;
      }
      if (Original_BankCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[77].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[78].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[77].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[78].Value = (object) Original_BankCode;
      }
      if (Original_BankSerialNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[79].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[80].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[79].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[80].Value = (object) Original_BankSerialNumber;
      }
      if (Original_PledgeCreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[81].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[82].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[81].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[82].Value = (object) Original_PledgeCreatedBy;
      }
      if (Original_PledgeCreatedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[83].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[84].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[83].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[84].Value = (object) Original_PledgeCreatedOn;
      }
      if (Original_RedeemedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[85].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[86].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[85].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[86].Value = (object) Original_RedeemedBy;
      }
      if (Original_RedeemedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[87].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[88].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[87].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[88].Value = (object) Original_RedeemedOn;
      }
      if (Original_tokenprinted == null)
      {
        this.Adapter.DeleteCommand.Parameters[89].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[90].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[89].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[90].Value = (object) Original_tokenprinted;
      }
      if (Original_temp5.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[91].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[92].Value = (object) Original_temp5.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[91].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[92].Value = (object) DBNull.Value;
      }
      if (Original_PledgeArticlesCombined == null)
      {
        this.Adapter.DeleteCommand.Parameters[93].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[94].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[93].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[94].Value = (object) Original_PledgeArticlesCombined;
      }
      if (Original_ShopCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[95].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[96].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[95].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[96].Value = (object) Original_ShopCode;
      }
      if (Original_InterestType == null)
      {
        this.Adapter.DeleteCommand.Parameters[97].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[98].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[97].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[98].Value = (object) Original_InterestType;
      }
      if (Original_StockCheckedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[99].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[100].Value = (object) Original_StockCheckedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[99].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[100].Value = (object) DBNull.Value;
      }
      if (Original_StockCheckedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[101].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[102].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[101].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[102].Value = (object) Original_StockCheckedBy;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[103].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[104].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[103].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[104].Value = (object) Original_BilledBy;
      }
      if (Original_RedemptionBillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[105].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[106].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[105].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[106].Value = (object) Original_RedemptionBillNumber;
      }
      if (Original_AuctionAmount.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[107].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[108].Value = (object) Original_AuctionAmount.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[107].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[108].Value = (object) DBNull.Value;
      }
      if (Original_kdisNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[109].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[110].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[109].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[110].Value = (object) Original_kdisNumber;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[111].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[112].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[111].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[112].Value = (object) Original_PurchasedBy;
      }
      if (Original_AuctionedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[113].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[114].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[113].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[114].Value = (object) Original_AuctionedBy;
      }
      if (Original_Vault == null)
      {
        this.Adapter.DeleteCommand.Parameters[115].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[116].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[115].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[116].Value = (object) Original_Vault;
      }
      if (Original_AuctionLetterPostalId == null)
      {
        this.Adapter.DeleteCommand.Parameters[117].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[118].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[117].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[118].Value = (object) Original_AuctionLetterPostalId;
      }
      if (Original_AuctionLetterReceivedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[119].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[120].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[119].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[120].Value = (object) Original_AuctionLetterReceivedBy;
      }
      if (Original_AuctionLetterSent == null)
      {
        this.Adapter.DeleteCommand.Parameters[121].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[122].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[121].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[122].Value = (object) Original_AuctionLetterSent;
      }
      if (Original_AuctionLetterSentOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[123].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[124].Value = (object) Original_AuctionLetterSentOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[123].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[124].Value = (object) DBNull.Value;
      }
      if (Original_IntimationLetterPostalId == null)
      {
        this.Adapter.DeleteCommand.Parameters[125].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[126].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[125].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[126].Value = (object) Original_IntimationLetterPostalId;
      }
      if (Original_IntimationLetterReceivedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[(int) sbyte.MaxValue].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[128].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[(int) sbyte.MaxValue].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[128].Value = (object) Original_IntimationLetterReceivedBy;
      }
      if (Original_IntimationLetterSent == null)
      {
        this.Adapter.DeleteCommand.Parameters[129].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[130].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[129].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[130].Value = (object) Original_IntimationLetterSent;
      }
      if (Original_IntimationLetterSentOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[131].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[132].Value = (object) Original_IntimationLetterSentOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[131].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[132].Value = (object) DBNull.Value;
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
      DateTime? BillDate,
      string CustomerCode,
      string CustomerName,
      string DoorNumber,
      string Addr1,
      string Addr2,
      string Addr3,
      string City,
      string Pincode,
      string PhoneNumber,
      string AmountInWords,
      string CustomerImagePath,
      string Type,
      string GrossWeight,
      string Deduction,
      string NetWeight,
      double? PureWeight,
      int? Amount,
      int? PresentValue,
      string OldBillNumber,
      string Reminder,
      double? temp1,
      string InterestRateDisplaySymbol,
      string Redeemed,
      int? NoOfMonths,
      int? InterestLess,
      double? temp2,
      int? NoticeCharge,
      int? OtherCharges,
      int? Discount,
      double? temp3,
      double? temp4,
      DateTime? RedemptionDate,
      DateTime? AuctionDate,
      string NoOfMonths16,
      string Interest16,
      string RedemptionAmount16,
      string BankCode,
      string BankSerialNumber,
      string PledgeCreatedBy,
      string PledgeCreatedOn,
      string RedeemedBy,
      string RedeemedOn,
      string tokenprinted,
      double? temp5,
      string ArticlesWithoutHr,
      string ArticlesWithHr,
      string PledgeArticlesCombined,
      string ShopCode,
      string InterestType,
      string Articles,
      DateTime? StockCheckedOn,
      string StockCheckedBy,
      string BilledBy,
      string RedemptionBillNumber,
      double? AuctionAmount,
      string kdisNumber,
      string PurchasedBy,
      string AuctionedBy,
      string Vault,
      string AuctionLetterPostalId,
      string AuctionLetterReceivedBy,
      string AuctionLetterSent,
      DateTime? AuctionLetterSentOn,
      string IntimationLetterPostalId,
      string IntimationLetterReceivedBy,
      string IntimationLetterSent,
      DateTime? IntimationLetterSentOn)
    {
      if (BillNumber == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) BillNumber;
      if (BillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) CustomerCode;
      if (CustomerName == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) CustomerName;
      if (DoorNumber == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DoorNumber;
      if (Addr1 == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Addr1;
      if (Addr2 == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Addr2;
      if (Addr3 == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Addr3;
      if (City == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) City;
      if (Pincode == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Pincode;
      if (PhoneNumber == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) PhoneNumber;
      if (AmountInWords == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) AmountInWords;
      if (CustomerImagePath == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) CustomerImagePath;
      if (Type == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) Type;
      if (GrossWeight == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) GrossWeight;
      if (Deduction == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) Deduction;
      if (NetWeight == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) NetWeight;
      if (PureWeight.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) PureWeight.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) Amount.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (PresentValue.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) PresentValue.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (OldBillNumber == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) OldBillNumber;
      if (Reminder == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) Reminder;
      if (temp1.HasValue)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) temp1.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      if (InterestRateDisplaySymbol == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) InterestRateDisplaySymbol;
      if (Redeemed == null)
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[24].Value = (object) Redeemed;
      if (NoOfMonths.HasValue)
        this.Adapter.InsertCommand.Parameters[25].Value = (object) NoOfMonths.Value;
      else
        this.Adapter.InsertCommand.Parameters[25].Value = (object) DBNull.Value;
      if (InterestLess.HasValue)
        this.Adapter.InsertCommand.Parameters[26].Value = (object) InterestLess.Value;
      else
        this.Adapter.InsertCommand.Parameters[26].Value = (object) DBNull.Value;
      if (temp2.HasValue)
        this.Adapter.InsertCommand.Parameters[27].Value = (object) temp2.Value;
      else
        this.Adapter.InsertCommand.Parameters[27].Value = (object) DBNull.Value;
      if (NoticeCharge.HasValue)
        this.Adapter.InsertCommand.Parameters[28].Value = (object) NoticeCharge.Value;
      else
        this.Adapter.InsertCommand.Parameters[28].Value = (object) DBNull.Value;
      if (OtherCharges.HasValue)
        this.Adapter.InsertCommand.Parameters[29].Value = (object) OtherCharges.Value;
      else
        this.Adapter.InsertCommand.Parameters[29].Value = (object) DBNull.Value;
      if (Discount.HasValue)
        this.Adapter.InsertCommand.Parameters[30].Value = (object) Discount.Value;
      else
        this.Adapter.InsertCommand.Parameters[30].Value = (object) DBNull.Value;
      if (temp3.HasValue)
        this.Adapter.InsertCommand.Parameters[31].Value = (object) temp3.Value;
      else
        this.Adapter.InsertCommand.Parameters[31].Value = (object) DBNull.Value;
      if (temp4.HasValue)
        this.Adapter.InsertCommand.Parameters[32].Value = (object) temp4.Value;
      else
        this.Adapter.InsertCommand.Parameters[32].Value = (object) DBNull.Value;
      if (RedemptionDate.HasValue)
        this.Adapter.InsertCommand.Parameters[33].Value = (object) RedemptionDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[33].Value = (object) DBNull.Value;
      if (AuctionDate.HasValue)
        this.Adapter.InsertCommand.Parameters[34].Value = (object) AuctionDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[34].Value = (object) DBNull.Value;
      if (NoOfMonths16 == null)
        this.Adapter.InsertCommand.Parameters[35].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[35].Value = (object) NoOfMonths16;
      if (Interest16 == null)
        this.Adapter.InsertCommand.Parameters[36].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[36].Value = (object) Interest16;
      if (RedemptionAmount16 == null)
        this.Adapter.InsertCommand.Parameters[37].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[37].Value = (object) RedemptionAmount16;
      if (BankCode == null)
        this.Adapter.InsertCommand.Parameters[38].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[38].Value = (object) BankCode;
      if (BankSerialNumber == null)
        this.Adapter.InsertCommand.Parameters[39].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[39].Value = (object) BankSerialNumber;
      if (PledgeCreatedBy == null)
        this.Adapter.InsertCommand.Parameters[40].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[40].Value = (object) PledgeCreatedBy;
      if (PledgeCreatedOn == null)
        this.Adapter.InsertCommand.Parameters[41].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[41].Value = (object) PledgeCreatedOn;
      if (RedeemedBy == null)
        this.Adapter.InsertCommand.Parameters[42].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[42].Value = (object) RedeemedBy;
      if (RedeemedOn == null)
        this.Adapter.InsertCommand.Parameters[43].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[43].Value = (object) RedeemedOn;
      if (tokenprinted == null)
        this.Adapter.InsertCommand.Parameters[44].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[44].Value = (object) tokenprinted;
      if (temp5.HasValue)
        this.Adapter.InsertCommand.Parameters[45].Value = (object) temp5.Value;
      else
        this.Adapter.InsertCommand.Parameters[45].Value = (object) DBNull.Value;
      if (ArticlesWithoutHr == null)
        this.Adapter.InsertCommand.Parameters[46].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[46].Value = (object) ArticlesWithoutHr;
      if (ArticlesWithHr == null)
        this.Adapter.InsertCommand.Parameters[47].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[47].Value = (object) ArticlesWithHr;
      if (PledgeArticlesCombined == null)
        this.Adapter.InsertCommand.Parameters[48].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[48].Value = (object) PledgeArticlesCombined;
      if (ShopCode == null)
        this.Adapter.InsertCommand.Parameters[49].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[49].Value = (object) ShopCode;
      if (InterestType == null)
        this.Adapter.InsertCommand.Parameters[50].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[50].Value = (object) InterestType;
      if (Articles == null)
        this.Adapter.InsertCommand.Parameters[51].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[51].Value = (object) Articles;
      if (StockCheckedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[52].Value = (object) StockCheckedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[52].Value = (object) DBNull.Value;
      if (StockCheckedBy == null)
        this.Adapter.InsertCommand.Parameters[53].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[53].Value = (object) StockCheckedBy;
      if (BilledBy == null)
        this.Adapter.InsertCommand.Parameters[54].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[54].Value = (object) BilledBy;
      if (RedemptionBillNumber == null)
        this.Adapter.InsertCommand.Parameters[55].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[55].Value = (object) RedemptionBillNumber;
      if (AuctionAmount.HasValue)
        this.Adapter.InsertCommand.Parameters[56].Value = (object) AuctionAmount.Value;
      else
        this.Adapter.InsertCommand.Parameters[56].Value = (object) DBNull.Value;
      if (kdisNumber == null)
        this.Adapter.InsertCommand.Parameters[57].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[57].Value = (object) kdisNumber;
      if (PurchasedBy == null)
        this.Adapter.InsertCommand.Parameters[58].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[58].Value = (object) PurchasedBy;
      if (AuctionedBy == null)
        this.Adapter.InsertCommand.Parameters[59].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[59].Value = (object) AuctionedBy;
      if (Vault == null)
        this.Adapter.InsertCommand.Parameters[60].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[60].Value = (object) Vault;
      if (AuctionLetterPostalId == null)
        this.Adapter.InsertCommand.Parameters[61].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[61].Value = (object) AuctionLetterPostalId;
      if (AuctionLetterReceivedBy == null)
        this.Adapter.InsertCommand.Parameters[62].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[62].Value = (object) AuctionLetterReceivedBy;
      if (AuctionLetterSent == null)
        this.Adapter.InsertCommand.Parameters[63].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[63].Value = (object) AuctionLetterSent;
      if (AuctionLetterSentOn.HasValue)
        this.Adapter.InsertCommand.Parameters[64].Value = (object) AuctionLetterSentOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[64].Value = (object) DBNull.Value;
      if (IntimationLetterPostalId == null)
        this.Adapter.InsertCommand.Parameters[65].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[65].Value = (object) IntimationLetterPostalId;
      if (IntimationLetterReceivedBy == null)
        this.Adapter.InsertCommand.Parameters[66].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[66].Value = (object) IntimationLetterReceivedBy;
      if (IntimationLetterSent == null)
        this.Adapter.InsertCommand.Parameters[67].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[67].Value = (object) IntimationLetterSent;
      if (IntimationLetterSentOn.HasValue)
        this.Adapter.InsertCommand.Parameters[68].Value = (object) IntimationLetterSentOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[68].Value = (object) DBNull.Value;
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
      DateTime? BillDate,
      string CustomerCode,
      string CustomerName,
      string DoorNumber,
      string Addr1,
      string Addr2,
      string Addr3,
      string City,
      string Pincode,
      string PhoneNumber,
      string AmountInWords,
      string CustomerImagePath,
      string Type,
      string GrossWeight,
      string Deduction,
      string NetWeight,
      double? PureWeight,
      int? Amount,
      int? PresentValue,
      string OldBillNumber,
      string Reminder,
      double? temp1,
      string InterestRateDisplaySymbol,
      string Redeemed,
      int? NoOfMonths,
      int? InterestLess,
      double? temp2,
      int? NoticeCharge,
      int? OtherCharges,
      int? Discount,
      double? temp3,
      double? temp4,
      DateTime? RedemptionDate,
      DateTime? AuctionDate,
      string NoOfMonths16,
      string Interest16,
      string RedemptionAmount16,
      string BankCode,
      string BankSerialNumber,
      string PledgeCreatedBy,
      string PledgeCreatedOn,
      string RedeemedBy,
      string RedeemedOn,
      string tokenprinted,
      double? temp5,
      string ArticlesWithoutHr,
      string ArticlesWithHr,
      string PledgeArticlesCombined,
      string ShopCode,
      string InterestType,
      string Articles,
      DateTime? StockCheckedOn,
      string StockCheckedBy,
      string BilledBy,
      string RedemptionBillNumber,
      double? AuctionAmount,
      string kdisNumber,
      string PurchasedBy,
      string AuctionedBy,
      string Vault,
      string AuctionLetterPostalId,
      string AuctionLetterReceivedBy,
      string AuctionLetterSent,
      DateTime? AuctionLetterSentOn,
      string IntimationLetterPostalId,
      string IntimationLetterReceivedBy,
      string IntimationLetterSent,
      DateTime? IntimationLetterSentOn,
      int Original_ID,
      string Original_BillNumber,
      DateTime? Original_BillDate,
      string Original_CustomerCode,
      string Original_CustomerName,
      string Original_DoorNumber,
      string Original_Addr1,
      string Original_Addr2,
      string Original_Addr3,
      string Original_City,
      string Original_Pincode,
      string Original_PhoneNumber,
      string Original_AmountInWords,
      string Original_CustomerImagePath,
      string Original_Type,
      string Original_GrossWeight,
      string Original_Deduction,
      string Original_NetWeight,
      double? Original_PureWeight,
      int? Original_Amount,
      int? Original_PresentValue,
      string Original_OldBillNumber,
      string Original_Reminder,
      double? Original_temp1,
      string Original_InterestRateDisplaySymbol,
      string Original_Redeemed,
      int? Original_NoOfMonths,
      int? Original_InterestLess,
      double? Original_temp2,
      int? Original_NoticeCharge,
      int? Original_OtherCharges,
      int? Original_Discount,
      double? Original_temp3,
      double? Original_temp4,
      DateTime? Original_RedemptionDate,
      DateTime? Original_AuctionDate,
      string Original_NoOfMonths16,
      string Original_Interest16,
      string Original_RedemptionAmount16,
      string Original_BankCode,
      string Original_BankSerialNumber,
      string Original_PledgeCreatedBy,
      string Original_PledgeCreatedOn,
      string Original_RedeemedBy,
      string Original_RedeemedOn,
      string Original_tokenprinted,
      double? Original_temp5,
      string Original_PledgeArticlesCombined,
      string Original_ShopCode,
      string Original_InterestType,
      DateTime? Original_StockCheckedOn,
      string Original_StockCheckedBy,
      string Original_BilledBy,
      string Original_RedemptionBillNumber,
      double? Original_AuctionAmount,
      string Original_kdisNumber,
      string Original_PurchasedBy,
      string Original_AuctionedBy,
      string Original_Vault,
      string Original_AuctionLetterPostalId,
      string Original_AuctionLetterReceivedBy,
      string Original_AuctionLetterSent,
      DateTime? Original_AuctionLetterSentOn,
      string Original_IntimationLetterPostalId,
      string Original_IntimationLetterReceivedBy,
      string Original_IntimationLetterSent,
      DateTime? Original_IntimationLetterSentOn)
    {
      if (BillNumber == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) BillNumber;
      if (BillDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) BillDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (CustomerCode == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) CustomerCode;
      if (CustomerName == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) CustomerName;
      if (DoorNumber == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DoorNumber;
      if (Addr1 == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Addr1;
      if (Addr2 == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Addr2;
      if (Addr3 == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Addr3;
      if (City == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) City;
      if (Pincode == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Pincode;
      if (PhoneNumber == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) PhoneNumber;
      if (AmountInWords == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) AmountInWords;
      if (CustomerImagePath == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) CustomerImagePath;
      if (Type == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Type;
      if (GrossWeight == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) GrossWeight;
      if (Deduction == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Deduction;
      if (NetWeight == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) NetWeight;
      if (PureWeight.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) PureWeight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (Amount.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Amount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      if (PresentValue.HasValue)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) PresentValue.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      if (OldBillNumber == null)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) OldBillNumber;
      if (Reminder == null)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Reminder;
      if (temp1.HasValue)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) temp1.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      if (InterestRateDisplaySymbol == null)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) InterestRateDisplaySymbol;
      if (Redeemed == null)
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Redeemed;
      if (NoOfMonths.HasValue)
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) NoOfMonths.Value;
      else
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      if (InterestLess.HasValue)
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) InterestLess.Value;
      else
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      if (temp2.HasValue)
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) temp2.Value;
      else
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      if (NoticeCharge.HasValue)
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) NoticeCharge.Value;
      else
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      if (OtherCharges.HasValue)
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) OtherCharges.Value;
      else
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      if (Discount.HasValue)
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Discount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      if (temp3.HasValue)
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) temp3.Value;
      else
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      if (temp4.HasValue)
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) temp4.Value;
      else
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      if (RedemptionDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) RedemptionDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      if (AuctionDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) AuctionDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      if (NoOfMonths16 == null)
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) NoOfMonths16;
      if (Interest16 == null)
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Interest16;
      if (RedemptionAmount16 == null)
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) RedemptionAmount16;
      if (BankCode == null)
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) BankCode;
      if (BankSerialNumber == null)
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) BankSerialNumber;
      if (PledgeCreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) PledgeCreatedBy;
      if (PledgeCreatedOn == null)
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) PledgeCreatedOn;
      if (RedeemedBy == null)
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) RedeemedBy;
      if (RedeemedOn == null)
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) RedeemedOn;
      if (tokenprinted == null)
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) tokenprinted;
      if (temp5.HasValue)
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) temp5.Value;
      else
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      if (ArticlesWithoutHr == null)
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) ArticlesWithoutHr;
      if (ArticlesWithHr == null)
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) ArticlesWithHr;
      if (PledgeArticlesCombined == null)
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) PledgeArticlesCombined;
      if (ShopCode == null)
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) ShopCode;
      if (InterestType == null)
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) InterestType;
      if (Articles == null)
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) Articles;
      if (StockCheckedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) StockCheckedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      if (StockCheckedBy == null)
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) StockCheckedBy;
      if (BilledBy == null)
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) BilledBy;
      if (RedemptionBillNumber == null)
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) RedemptionBillNumber;
      if (AuctionAmount.HasValue)
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) AuctionAmount.Value;
      else
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) DBNull.Value;
      if (kdisNumber == null)
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) kdisNumber;
      if (PurchasedBy == null)
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) PurchasedBy;
      if (AuctionedBy == null)
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) AuctionedBy;
      if (Vault == null)
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) Vault;
      if (AuctionLetterPostalId == null)
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[61].Value = (object) AuctionLetterPostalId;
      if (AuctionLetterReceivedBy == null)
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) AuctionLetterReceivedBy;
      if (AuctionLetterSent == null)
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[63].Value = (object) AuctionLetterSent;
      if (AuctionLetterSentOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) AuctionLetterSentOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[64].Value = (object) DBNull.Value;
      if (IntimationLetterPostalId == null)
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[65].Value = (object) IntimationLetterPostalId;
      if (IntimationLetterReceivedBy == null)
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[66].Value = (object) IntimationLetterReceivedBy;
      if (IntimationLetterSent == null)
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[67].Value = (object) IntimationLetterSent;
      if (IntimationLetterSentOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) IntimationLetterSentOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[68].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[69].Value = (object) Original_ID;
      if (Original_BillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[70].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[71].Value = (object) Original_BillNumber;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[72].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[73].Value = (object) DBNull.Value;
      }
      if (Original_CustomerCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[74].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[75].Value = (object) Original_CustomerCode;
      }
      if (Original_CustomerName == null)
      {
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[76].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[77].Value = (object) Original_CustomerName;
      }
      if (Original_DoorNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[79].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[78].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[79].Value = (object) Original_DoorNumber;
      }
      if (Original_Addr1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[80].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[81].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[80].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[81].Value = (object) Original_Addr1;
      }
      if (Original_Addr2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[82].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[83].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[82].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[83].Value = (object) Original_Addr2;
      }
      if (Original_Addr3 == null)
      {
        this.Adapter.UpdateCommand.Parameters[84].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[85].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[84].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[85].Value = (object) Original_Addr3;
      }
      if (Original_City == null)
      {
        this.Adapter.UpdateCommand.Parameters[86].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[87].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[86].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[87].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.UpdateCommand.Parameters[88].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[89].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[88].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[89].Value = (object) Original_Pincode;
      }
      if (Original_PhoneNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[90].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[91].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[90].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[91].Value = (object) Original_PhoneNumber;
      }
      if (Original_AmountInWords == null)
      {
        this.Adapter.UpdateCommand.Parameters[92].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[93].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[92].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[93].Value = (object) Original_AmountInWords;
      }
      if (Original_CustomerImagePath == null)
      {
        this.Adapter.UpdateCommand.Parameters[94].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[95].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[94].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[95].Value = (object) Original_CustomerImagePath;
      }
      if (Original_Type == null)
      {
        this.Adapter.UpdateCommand.Parameters[96].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[97].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[96].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[97].Value = (object) Original_Type;
      }
      if (Original_GrossWeight == null)
      {
        this.Adapter.UpdateCommand.Parameters[98].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[99].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[98].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[99].Value = (object) Original_GrossWeight;
      }
      if (Original_Deduction == null)
      {
        this.Adapter.UpdateCommand.Parameters[100].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[101].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[100].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[101].Value = (object) Original_Deduction;
      }
      if (Original_NetWeight == null)
      {
        this.Adapter.UpdateCommand.Parameters[102].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[103].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[102].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[103].Value = (object) Original_NetWeight;
      }
      if (Original_PureWeight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[104].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[105].Value = (object) Original_PureWeight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[104].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[105].Value = (object) DBNull.Value;
      }
      if (Original_Amount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[106].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[107].Value = (object) Original_Amount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[106].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[107].Value = (object) DBNull.Value;
      }
      if (Original_PresentValue.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[108].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[109].Value = (object) Original_PresentValue.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[108].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[109].Value = (object) DBNull.Value;
      }
      if (Original_OldBillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[110].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[111].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[110].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[111].Value = (object) Original_OldBillNumber;
      }
      if (Original_Reminder == null)
      {
        this.Adapter.UpdateCommand.Parameters[112].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[113].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[112].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[113].Value = (object) Original_Reminder;
      }
      if (Original_temp1.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[114].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[115].Value = (object) Original_temp1.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[114].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[115].Value = (object) DBNull.Value;
      }
      if (Original_InterestRateDisplaySymbol == null)
      {
        this.Adapter.UpdateCommand.Parameters[116].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[117].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[116].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[117].Value = (object) Original_InterestRateDisplaySymbol;
      }
      if (Original_Redeemed == null)
      {
        this.Adapter.UpdateCommand.Parameters[118].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[119].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[118].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[119].Value = (object) Original_Redeemed;
      }
      if (Original_NoOfMonths.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[120].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[121].Value = (object) Original_NoOfMonths.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[120].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[121].Value = (object) DBNull.Value;
      }
      if (Original_InterestLess.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[122].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[123].Value = (object) Original_InterestLess.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[122].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[123].Value = (object) DBNull.Value;
      }
      if (Original_temp2.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[124].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[125].Value = (object) Original_temp2.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[124].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[125].Value = (object) DBNull.Value;
      }
      if (Original_NoticeCharge.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[126].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[(int) sbyte.MaxValue].Value = (object) Original_NoticeCharge.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[126].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[(int) sbyte.MaxValue].Value = (object) DBNull.Value;
      }
      if (Original_OtherCharges.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[128].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[129].Value = (object) Original_OtherCharges.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[128].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[129].Value = (object) DBNull.Value;
      }
      if (Original_Discount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[130].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[131].Value = (object) Original_Discount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[130].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[131].Value = (object) DBNull.Value;
      }
      if (Original_temp3.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[132].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[133].Value = (object) Original_temp3.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[132].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[133].Value = (object) DBNull.Value;
      }
      if (Original_temp4.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[134].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[135].Value = (object) Original_temp4.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[134].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[135].Value = (object) DBNull.Value;
      }
      if (Original_RedemptionDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[136].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[137].Value = (object) Original_RedemptionDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[136].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[137].Value = (object) DBNull.Value;
      }
      if (Original_AuctionDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[138].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[139].Value = (object) Original_AuctionDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[138].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[139].Value = (object) DBNull.Value;
      }
      if (Original_NoOfMonths16 == null)
      {
        this.Adapter.UpdateCommand.Parameters[140].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[141].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[140].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[141].Value = (object) Original_NoOfMonths16;
      }
      if (Original_Interest16 == null)
      {
        this.Adapter.UpdateCommand.Parameters[142].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[143].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[142].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[143].Value = (object) Original_Interest16;
      }
      if (Original_RedemptionAmount16 == null)
      {
        this.Adapter.UpdateCommand.Parameters[144].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[145].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[144].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[145].Value = (object) Original_RedemptionAmount16;
      }
      if (Original_BankCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[146].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[147].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[146].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[147].Value = (object) Original_BankCode;
      }
      if (Original_BankSerialNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[148].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[149].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[148].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[149].Value = (object) Original_BankSerialNumber;
      }
      if (Original_PledgeCreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[150].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[151].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[150].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[151].Value = (object) Original_PledgeCreatedBy;
      }
      if (Original_PledgeCreatedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[152].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[153].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[152].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[153].Value = (object) Original_PledgeCreatedOn;
      }
      if (Original_RedeemedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[154].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[155].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[154].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[155].Value = (object) Original_RedeemedBy;
      }
      if (Original_RedeemedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[156].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[157].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[156].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[157].Value = (object) Original_RedeemedOn;
      }
      if (Original_tokenprinted == null)
      {
        this.Adapter.UpdateCommand.Parameters[158].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[159].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[158].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[159].Value = (object) Original_tokenprinted;
      }
      if (Original_temp5.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[160].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[161].Value = (object) Original_temp5.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[160].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[161].Value = (object) DBNull.Value;
      }
      if (Original_PledgeArticlesCombined == null)
      {
        this.Adapter.UpdateCommand.Parameters[162].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[163].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[162].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[163].Value = (object) Original_PledgeArticlesCombined;
      }
      if (Original_ShopCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[164].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[165].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[164].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[165].Value = (object) Original_ShopCode;
      }
      if (Original_InterestType == null)
      {
        this.Adapter.UpdateCommand.Parameters[166].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[167].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[166].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[167].Value = (object) Original_InterestType;
      }
      if (Original_StockCheckedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[168].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[169].Value = (object) Original_StockCheckedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[168].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[169].Value = (object) DBNull.Value;
      }
      if (Original_StockCheckedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[170].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[171].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[170].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[171].Value = (object) Original_StockCheckedBy;
      }
      if (Original_BilledBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[172].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[173].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[172].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[173].Value = (object) Original_BilledBy;
      }
      if (Original_RedemptionBillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[174].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[175].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[174].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[175].Value = (object) Original_RedemptionBillNumber;
      }
      if (Original_AuctionAmount.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[176].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[177].Value = (object) Original_AuctionAmount.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[176].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[177].Value = (object) DBNull.Value;
      }
      if (Original_kdisNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[178].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[179].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[178].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[179].Value = (object) Original_kdisNumber;
      }
      if (Original_PurchasedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[180].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[181].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[180].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[181].Value = (object) Original_PurchasedBy;
      }
      if (Original_AuctionedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[182].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[183].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[182].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[183].Value = (object) Original_AuctionedBy;
      }
      if (Original_Vault == null)
      {
        this.Adapter.UpdateCommand.Parameters[184].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[185].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[184].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[185].Value = (object) Original_Vault;
      }
      if (Original_AuctionLetterPostalId == null)
      {
        this.Adapter.UpdateCommand.Parameters[186].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[187].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[186].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[187].Value = (object) Original_AuctionLetterPostalId;
      }
      if (Original_AuctionLetterReceivedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[188].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[189].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[188].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[189].Value = (object) Original_AuctionLetterReceivedBy;
      }
      if (Original_AuctionLetterSent == null)
      {
        this.Adapter.UpdateCommand.Parameters[190].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[191].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[190].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[191].Value = (object) Original_AuctionLetterSent;
      }
      if (Original_AuctionLetterSentOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[192].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[193].Value = (object) Original_AuctionLetterSentOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[192].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[193].Value = (object) DBNull.Value;
      }
      if (Original_IntimationLetterPostalId == null)
      {
        this.Adapter.UpdateCommand.Parameters[194].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[195].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[194].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[195].Value = (object) Original_IntimationLetterPostalId;
      }
      if (Original_IntimationLetterReceivedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[196].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[197].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[196].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[197].Value = (object) Original_IntimationLetterReceivedBy;
      }
      if (Original_IntimationLetterSent == null)
      {
        this.Adapter.UpdateCommand.Parameters[198].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[199].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[198].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[199].Value = (object) Original_IntimationLetterSent;
      }
      if (Original_IntimationLetterSentOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[200].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[201].Value = (object) Original_IntimationLetterSentOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[200].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[201].Value = (object) DBNull.Value;
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
