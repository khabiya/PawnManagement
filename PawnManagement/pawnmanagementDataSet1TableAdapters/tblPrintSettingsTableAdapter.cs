
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
  public class tblPrintSettingsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblPrintSettingsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblPrintSettings",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "PrintFormats",
            "PrintFormats"
          },
          {
            "PrintFormatsDefaultValue",
            "PrintFormatsDefaultValue"
          },
          {
            "RokadPrintFormats",
            "RokadPrintFormats"
          },
          {
            "TokenPrintFormats",
            "TokenPrintFormats"
          },
          {
            "NoticePrintFormats",
            "NoticePrintFormats"
          },
          {
            "LedgerPrintFormats",
            "LedgerPrintFormats"
          },
          {
            "PledgeReportPrintFormats",
            "PledgeReportPrintFormats"
          },
          {
            "RedemptionReportPrintFormats",
            "RedemptionReportPrintFormats"
          },
          {
            "printprompt",
            "printprompt"
          },
          {
            "jewelphotoprompt",
            "jewelphotoprompt"
          },
          {
            "HistoryReminderPrompt",
            "HistoryReminderPrompt"
          },
          {
            "BankRenewalReminderPrompt",
            "BankRenewalReminderPrompt"
          },
          {
            "BankPledgeToBeReleasedTodayPrompt",
            "BankPledgeToBeReleasedTodayPrompt"
          },
          {
            "PendingGirviTotalPrompt",
            "PendingGirviTotalPrompt"
          },
          {
            "AutoFillAmount",
            "AutoFillAmount"
          },
          {
            "PrintFormatsCustomerCopy",
            "PrintFormatsCustomerCopy"
          },
          {
            "PrintFormatsCustomerCopyDefaultValue",
            "PrintFormatsCustomerCopyDefaultValue"
          },
          {
            "RedemptionBillPrintFormats",
            "RedemptionBillPrintFormats"
          },
          {
            "RedemptionBillPrintFormatsDefaultValue",
            "RedemptionBillPrintFormatsDefaultValue"
          },
          {
            "RedemptionBillPrintPrompt",
            "RedemptionBillPrintPrompt"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblPrintSettings` WHERE ((`ID` = ?) AND ((? = 1 AND `PrintFormats` IS NULL) OR (`PrintFormats` = ?)) AND ((? = 1 AND `PrintFormatsDefaultValue` IS NULL) OR (`PrintFormatsDefaultValue` = ?)) AND ((? = 1 AND `RokadPrintFormats` IS NULL) OR (`RokadPrintFormats` = ?)) AND ((? = 1 AND `TokenPrintFormats` IS NULL) OR (`TokenPrintFormats` = ?)) AND ((? = 1 AND `NoticePrintFormats` IS NULL) OR (`NoticePrintFormats` = ?)) AND ((? = 1 AND `LedgerPrintFormats` IS NULL) OR (`LedgerPrintFormats` = ?)) AND ((? = 1 AND `PledgeReportPrintFormats` IS NULL) OR (`PledgeReportPrintFormats` = ?)) AND ((? = 1 AND `RedemptionReportPrintFormats` IS NULL) OR (`RedemptionReportPrintFormats` = ?)) AND ((? = 1 AND `printprompt` IS NULL) OR (`printprompt` = ?)) AND ((? = 1 AND `jewelphotoprompt` IS NULL) OR (`jewelphotoprompt` = ?)) AND ((? = 1 AND `HistoryReminderPrompt` IS NULL) OR (`HistoryReminderPrompt` = ?)) AND ((? = 1 AND `BankRenewalReminderPrompt` IS NULL) OR (`BankRenewalReminderPrompt` = ?)) AND ((? = 1 AND `BankPledgeToBeReleasedTodayPrompt` IS NULL) OR (`BankPledgeToBeReleasedTodayPrompt` = ?)) AND ((? = 1 AND `PendingGirviTotalPrompt` IS NULL) OR (`PendingGirviTotalPrompt` = ?)) AND ((? = 1 AND `AutoFillAmount` IS NULL) OR (`AutoFillAmount` = ?)) AND ((? = 1 AND `PrintFormatsCustomerCopy` IS NULL) OR (`PrintFormatsCustomerCopy` = ?)) AND ((? = 1 AND `PrintFormatsCustomerCopyDefaultValue` IS NULL) OR (`PrintFormatsCustomerCopyDefaultValue` = ?)) AND ((? = 1 AND `RedemptionBillPrintFormats` IS NULL) OR (`RedemptionBillPrintFormats` = ?)) AND ((? = 1 AND `RedemptionBillPrintFormatsDefaultValue` IS NULL) OR (`RedemptionBillPrintFormatsDefaultValue` = ?)) AND ((? = 1 AND `RedemptionBillPrintPrompt` IS NULL) OR (`RedemptionBillPrintPrompt` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RokadPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RokadPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TokenPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TokenPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NoticePrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NoticePrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LedgerPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeReportPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionReportPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_printprompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_printprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_jewelphotoprompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_jewelphotoprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_HistoryReminderPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_HistoryReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankRenewalReminderPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankRenewalReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BankPledgeToBeReleasedTodayPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BankPledgeToBeReleasedTodayPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PendingGirviTotalPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PendingGirviTotalPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AutoFillAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AutoFillAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsCustomerCopy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsCustomerCopy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsCustomerCopyDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsCustomerCopyDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintFormatsDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblPrintSettings` (`PrintFormats`, `PrintFormatsDefaultValue`, `RokadPrintFormats`, `TokenPrintFormats`, `NoticePrintFormats`, `LedgerPrintFormats`, `PledgeReportPrintFormats`, `RedemptionReportPrintFormats`, `printprompt`, `jewelphotoprompt`, `HistoryReminderPrompt`, `BankRenewalReminderPrompt`, `BankPledgeToBeReleasedTodayPrompt`, `PendingGirviTotalPrompt`, `AutoFillAmount`, `PrintFormatsCustomerCopy`, `PrintFormatsCustomerCopyDefaultValue`, `RedemptionBillPrintFormats`, `RedemptionBillPrintFormatsDefaultValue`, `RedemptionBillPrintPrompt`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RokadPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TokenPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoticePrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LedgerPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("printprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("jewelphotoprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("HistoryReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankRenewalReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BankPledgeToBeReleasedTodayPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PendingGirviTotalPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AutoFillAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PrintFormatsCustomerCopy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PrintFormatsCustomerCopyDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblPrintSettings` SET `PrintFormats` = ?, `PrintFormatsDefaultValue` = ?, `RokadPrintFormats` = ?, `TokenPrintFormats` = ?, `NoticePrintFormats` = ?, `LedgerPrintFormats` = ?, `PledgeReportPrintFormats` = ?, `RedemptionReportPrintFormats` = ?, `printprompt` = ?, `jewelphotoprompt` = ?, `HistoryReminderPrompt` = ?, `BankRenewalReminderPrompt` = ?, `BankPledgeToBeReleasedTodayPrompt` = ?, `PendingGirviTotalPrompt` = ?, `AutoFillAmount` = ?, `PrintFormatsCustomerCopy` = ?, `PrintFormatsCustomerCopyDefaultValue` = ?, `RedemptionBillPrintFormats` = ?, `RedemptionBillPrintFormatsDefaultValue` = ?, `RedemptionBillPrintPrompt` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `PrintFormats` IS NULL) OR (`PrintFormats` = ?)) AND ((? = 1 AND `PrintFormatsDefaultValue` IS NULL) OR (`PrintFormatsDefaultValue` = ?)) AND ((? = 1 AND `RokadPrintFormats` IS NULL) OR (`RokadPrintFormats` = ?)) AND ((? = 1 AND `TokenPrintFormats` IS NULL) OR (`TokenPrintFormats` = ?)) AND ((? = 1 AND `NoticePrintFormats` IS NULL) OR (`NoticePrintFormats` = ?)) AND ((? = 1 AND `LedgerPrintFormats` IS NULL) OR (`LedgerPrintFormats` = ?)) AND ((? = 1 AND `PledgeReportPrintFormats` IS NULL) OR (`PledgeReportPrintFormats` = ?)) AND ((? = 1 AND `RedemptionReportPrintFormats` IS NULL) OR (`RedemptionReportPrintFormats` = ?)) AND ((? = 1 AND `printprompt` IS NULL) OR (`printprompt` = ?)) AND ((? = 1 AND `jewelphotoprompt` IS NULL) OR (`jewelphotoprompt` = ?)) AND ((? = 1 AND `HistoryReminderPrompt` IS NULL) OR (`HistoryReminderPrompt` = ?)) AND ((? = 1 AND `BankRenewalReminderPrompt` IS NULL) OR (`BankRenewalReminderPrompt` = ?)) AND ((? = 1 AND `BankPledgeToBeReleasedTodayPrompt` IS NULL) OR (`BankPledgeToBeReleasedTodayPrompt` = ?)) AND ((? = 1 AND `PendingGirviTotalPrompt` IS NULL) OR (`PendingGirviTotalPrompt` = ?)) AND ((? = 1 AND `AutoFillAmount` IS NULL) OR (`AutoFillAmount` = ?)) AND ((? = 1 AND `PrintFormatsCustomerCopy` IS NULL) OR (`PrintFormatsCustomerCopy` = ?)) AND ((? = 1 AND `PrintFormatsCustomerCopyDefaultValue` IS NULL) OR (`PrintFormatsCustomerCopyDefaultValue` = ?)) AND ((? = 1 AND `RedemptionBillPrintFormats` IS NULL) OR (`RedemptionBillPrintFormats` = ?)) AND ((? = 1 AND `RedemptionBillPrintFormatsDefaultValue` IS NULL) OR (`RedemptionBillPrintFormatsDefaultValue` = ?)) AND ((? = 1 AND `RedemptionBillPrintPrompt` IS NULL) OR (`RedemptionBillPrintPrompt` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RokadPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TokenPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NoticePrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LedgerPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("printprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("jewelphotoprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("HistoryReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankRenewalReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BankPledgeToBeReleasedTodayPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PendingGirviTotalPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AutoFillAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PrintFormatsCustomerCopy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PrintFormatsCustomerCopyDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RedemptionBillPrintPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RokadPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RokadPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TokenPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TokenPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TokenPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NoticePrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NoticePrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticePrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LedgerPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LedgerPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LedgerPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeReportPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeReportPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionReportPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionReportPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionReportPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_printprompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_printprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "printprompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_jewelphotoprompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_jewelphotoprompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "jewelphotoprompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_HistoryReminderPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_HistoryReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HistoryReminderPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankRenewalReminderPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankRenewalReminderPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankRenewalReminderPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BankPledgeToBeReleasedTodayPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BankPledgeToBeReleasedTodayPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BankPledgeToBeReleasedTodayPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PendingGirviTotalPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PendingGirviTotalPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PendingGirviTotalPrompt", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AutoFillAmount", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AutoFillAmount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoFillAmount", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsCustomerCopy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsCustomerCopy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PrintFormatsCustomerCopyDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PrintFormatsCustomerCopyDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PrintFormatsCustomerCopyDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintFormats", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintFormats", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormats", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintFormatsDefaultValue", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintFormatsDefaultValue", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintFormatsDefaultValue", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RedemptionBillPrintPrompt", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RedemptionBillPrintPrompt", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionBillPrintPrompt", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, PrintFormats, PrintFormatsDefaultValue, RokadPrintFormats, TokenPrintFormats, NoticePrintFormats, LedgerPrintFormats, PledgeReportPrintFormats, RedemptionReportPrintFormats, printprompt, jewelphotoprompt, HistoryReminderPrompt, BankRenewalReminderPrompt, BankPledgeToBeReleasedTodayPrompt, PendingGirviTotalPrompt, AutoFillAmount, PrintFormatsCustomerCopy, PrintFormatsCustomerCopyDefaultValue, RedemptionBillPrintFormats, RedemptionBillPrintFormatsDefaultValue, RedemptionBillPrintPrompt FROM tblPrintSettings";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblPrintSettingsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblPrintSettingsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblPrintSettingsDataTable data = new pawnmanagementDataSet1.tblPrintSettingsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblPrintSettingsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblPrintSettings");

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
      string Original_PrintFormats,
      string Original_PrintFormatsDefaultValue,
      string Original_RokadPrintFormats,
      string Original_TokenPrintFormats,
      string Original_NoticePrintFormats,
      string Original_LedgerPrintFormats,
      string Original_PledgeReportPrintFormats,
      string Original_RedemptionReportPrintFormats,
      string Original_printprompt,
      string Original_jewelphotoprompt,
      string Original_HistoryReminderPrompt,
      string Original_BankRenewalReminderPrompt,
      string Original_BankPledgeToBeReleasedTodayPrompt,
      string Original_PendingGirviTotalPrompt,
      string Original_AutoFillAmount,
      string Original_PrintFormatsCustomerCopy,
      string Original_PrintFormatsCustomerCopyDefaultValue,
      string Original_RedemptionBillPrintFormats,
      string Original_RedemptionBillPrintFormatsDefaultValue,
      string Original_RedemptionBillPrintPrompt)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_PrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_PrintFormats;
      }
      if (Original_PrintFormatsDefaultValue == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_PrintFormatsDefaultValue;
      }
      if (Original_RokadPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_RokadPrintFormats;
      }
      if (Original_TokenPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_TokenPrintFormats;
      }
      if (Original_NoticePrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_NoticePrintFormats;
      }
      if (Original_LedgerPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_LedgerPrintFormats;
      }
      if (Original_PledgeReportPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_PledgeReportPrintFormats;
      }
      if (Original_RedemptionReportPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_RedemptionReportPrintFormats;
      }
      if (Original_printprompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_printprompt;
      }
      if (Original_jewelphotoprompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_jewelphotoprompt;
      }
      if (Original_HistoryReminderPrompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_HistoryReminderPrompt;
      }
      if (Original_BankRenewalReminderPrompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_BankRenewalReminderPrompt;
      }
      if (Original_BankPledgeToBeReleasedTodayPrompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_BankPledgeToBeReleasedTodayPrompt;
      }
      if (Original_PendingGirviTotalPrompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_PendingGirviTotalPrompt;
      }
      if (Original_AutoFillAmount == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_AutoFillAmount;
      }
      if (Original_PrintFormatsCustomerCopy == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_PrintFormatsCustomerCopy;
      }
      if (Original_PrintFormatsCustomerCopyDefaultValue == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_PrintFormatsCustomerCopyDefaultValue;
      }
      if (Original_RedemptionBillPrintFormats == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_RedemptionBillPrintFormats;
      }
      if (Original_RedemptionBillPrintFormatsDefaultValue == null)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_RedemptionBillPrintFormatsDefaultValue;
      }
      if (Original_RedemptionBillPrintPrompt == null)
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[39].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[40].Value = (object) Original_RedemptionBillPrintPrompt;
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
      string PrintFormats,
      string PrintFormatsDefaultValue,
      string RokadPrintFormats,
      string TokenPrintFormats,
      string NoticePrintFormats,
      string LedgerPrintFormats,
      string PledgeReportPrintFormats,
      string RedemptionReportPrintFormats,
      string printprompt,
      string jewelphotoprompt,
      string HistoryReminderPrompt,
      string BankRenewalReminderPrompt,
      string BankPledgeToBeReleasedTodayPrompt,
      string PendingGirviTotalPrompt,
      string AutoFillAmount,
      string PrintFormatsCustomerCopy,
      string PrintFormatsCustomerCopyDefaultValue,
      string RedemptionBillPrintFormats,
      string RedemptionBillPrintFormatsDefaultValue,
      string RedemptionBillPrintPrompt)
    {
      if (PrintFormats == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) PrintFormats;
      if (PrintFormatsDefaultValue == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) PrintFormatsDefaultValue;
      if (RokadPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) RokadPrintFormats;
      if (TokenPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) TokenPrintFormats;
      if (NoticePrintFormats == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) NoticePrintFormats;
      if (LedgerPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) LedgerPrintFormats;
      if (PledgeReportPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) PledgeReportPrintFormats;
      if (RedemptionReportPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) RedemptionReportPrintFormats;
      if (printprompt == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) printprompt;
      if (jewelphotoprompt == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) jewelphotoprompt;
      if (HistoryReminderPrompt == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) HistoryReminderPrompt;
      if (BankRenewalReminderPrompt == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) BankRenewalReminderPrompt;
      if (BankPledgeToBeReleasedTodayPrompt == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) BankPledgeToBeReleasedTodayPrompt;
      if (PendingGirviTotalPrompt == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) PendingGirviTotalPrompt;
      if (AutoFillAmount == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) AutoFillAmount;
      if (PrintFormatsCustomerCopy == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) PrintFormatsCustomerCopy;
      if (PrintFormatsCustomerCopyDefaultValue == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) PrintFormatsCustomerCopyDefaultValue;
      if (RedemptionBillPrintFormats == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) RedemptionBillPrintFormats;
      if (RedemptionBillPrintFormatsDefaultValue == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) RedemptionBillPrintFormatsDefaultValue;
      if (RedemptionBillPrintPrompt == null)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) RedemptionBillPrintPrompt;
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
      string PrintFormats,
      string PrintFormatsDefaultValue,
      string RokadPrintFormats,
      string TokenPrintFormats,
      string NoticePrintFormats,
      string LedgerPrintFormats,
      string PledgeReportPrintFormats,
      string RedemptionReportPrintFormats,
      string printprompt,
      string jewelphotoprompt,
      string HistoryReminderPrompt,
      string BankRenewalReminderPrompt,
      string BankPledgeToBeReleasedTodayPrompt,
      string PendingGirviTotalPrompt,
      string AutoFillAmount,
      string PrintFormatsCustomerCopy,
      string PrintFormatsCustomerCopyDefaultValue,
      string RedemptionBillPrintFormats,
      string RedemptionBillPrintFormatsDefaultValue,
      string RedemptionBillPrintPrompt,
      int Original_ID,
      string Original_PrintFormats,
      string Original_PrintFormatsDefaultValue,
      string Original_RokadPrintFormats,
      string Original_TokenPrintFormats,
      string Original_NoticePrintFormats,
      string Original_LedgerPrintFormats,
      string Original_PledgeReportPrintFormats,
      string Original_RedemptionReportPrintFormats,
      string Original_printprompt,
      string Original_jewelphotoprompt,
      string Original_HistoryReminderPrompt,
      string Original_BankRenewalReminderPrompt,
      string Original_BankPledgeToBeReleasedTodayPrompt,
      string Original_PendingGirviTotalPrompt,
      string Original_AutoFillAmount,
      string Original_PrintFormatsCustomerCopy,
      string Original_PrintFormatsCustomerCopyDefaultValue,
      string Original_RedemptionBillPrintFormats,
      string Original_RedemptionBillPrintFormatsDefaultValue,
      string Original_RedemptionBillPrintPrompt)
    {
      if (PrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) PrintFormats;
      if (PrintFormatsDefaultValue == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) PrintFormatsDefaultValue;
      if (RokadPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) RokadPrintFormats;
      if (TokenPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) TokenPrintFormats;
      if (NoticePrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) NoticePrintFormats;
      if (LedgerPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) LedgerPrintFormats;
      if (PledgeReportPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) PledgeReportPrintFormats;
      if (RedemptionReportPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) RedemptionReportPrintFormats;
      if (printprompt == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) printprompt;
      if (jewelphotoprompt == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) jewelphotoprompt;
      if (HistoryReminderPrompt == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) HistoryReminderPrompt;
      if (BankRenewalReminderPrompt == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) BankRenewalReminderPrompt;
      if (BankPledgeToBeReleasedTodayPrompt == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) BankPledgeToBeReleasedTodayPrompt;
      if (PendingGirviTotalPrompt == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) PendingGirviTotalPrompt;
      if (AutoFillAmount == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) AutoFillAmount;
      if (PrintFormatsCustomerCopy == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) PrintFormatsCustomerCopy;
      if (PrintFormatsCustomerCopyDefaultValue == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) PrintFormatsCustomerCopyDefaultValue;
      if (RedemptionBillPrintFormats == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) RedemptionBillPrintFormats;
      if (RedemptionBillPrintFormatsDefaultValue == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) RedemptionBillPrintFormatsDefaultValue;
      if (RedemptionBillPrintPrompt == null)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) RedemptionBillPrintPrompt;
      this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_ID;
      if (Original_PrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_PrintFormats;
      }
      if (Original_PrintFormatsDefaultValue == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_PrintFormatsDefaultValue;
      }
      if (Original_RokadPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_RokadPrintFormats;
      }
      if (Original_TokenPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_TokenPrintFormats;
      }
      if (Original_NoticePrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_NoticePrintFormats;
      }
      if (Original_LedgerPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_LedgerPrintFormats;
      }
      if (Original_PledgeReportPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_PledgeReportPrintFormats;
      }
      if (Original_RedemptionReportPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_RedemptionReportPrintFormats;
      }
      if (Original_printprompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_printprompt;
      }
      if (Original_jewelphotoprompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) Original_jewelphotoprompt;
      }
      if (Original_HistoryReminderPrompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_HistoryReminderPrompt;
      }
      if (Original_BankRenewalReminderPrompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) Original_BankRenewalReminderPrompt;
      }
      if (Original_BankPledgeToBeReleasedTodayPrompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) Original_BankPledgeToBeReleasedTodayPrompt;
      }
      if (Original_PendingGirviTotalPrompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) Original_PendingGirviTotalPrompt;
      }
      if (Original_AutoFillAmount == null)
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) Original_AutoFillAmount;
      }
      if (Original_PrintFormatsCustomerCopy == null)
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) Original_PrintFormatsCustomerCopy;
      }
      if (Original_PrintFormatsCustomerCopyDefaultValue == null)
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) Original_PrintFormatsCustomerCopyDefaultValue;
      }
      if (Original_RedemptionBillPrintFormats == null)
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) Original_RedemptionBillPrintFormats;
      }
      if (Original_RedemptionBillPrintFormatsDefaultValue == null)
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[58].Value = (object) Original_RedemptionBillPrintFormatsDefaultValue;
      }
      if (Original_RedemptionBillPrintPrompt == null)
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[59].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[60].Value = (object) Original_RedemptionBillPrintPrompt;
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
