

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapterManager")]
  public class TableAdapterManager : Component
  {
    private TableAdapterManager.UpdateOrderOption _updateOrder;
    private Paste_ErrorsTableAdapter _paste_ErrorsTableAdapter;
    private tblArticlesTableAdapter _tblArticlesTableAdapter;
    private tblArticlesDescriptionTableAdapter _tblArticlesDescriptionTableAdapter;
    private tblArticlesSettingsTableAdapter _tblArticlesSettingsTableAdapter;
    private tblAutoDeleteRokadTableAdapter _tblAutoDeleteRokadTableAdapter;
    private tblBackUpTableAdapter _tblBackUpTableAdapter;
    private tblBankMasterTableAdapter _tblBankMasterTableAdapter;
    private tblBankPledgeTableAdapter _tblBankPledgeTableAdapter;
    private tblBankPledgePledgeBillsTableAdapter _tblBankPledgePledgeBillsTableAdapter;
    private tblBillerTableAdapter _tblBillerTableAdapter;
    private tblColoursTableAdapter _tblColoursTableAdapter;
    private tblCompanyDetailsTableAdapter _tblCompanyDetailsTableAdapter;
    private tblCustomersTableAdapter _tblCustomersTableAdapter;
    private tblDatesTableAdapter _tblDatesTableAdapter;
    private tblExceptionsTableAdapter _tblExceptionsTableAdapter;
    private tblGramRateTableAdapter _tblGramRateTableAdapter;
    private tblHistoryTableAdapter _tblHistoryTableAdapter;
    private tblhistoryReminderTableAdapter _tblhistoryReminderTableAdapter;
    private TBLIMAGETableAdapter _tBLIMAGETableAdapter;
    private tblInterestTableAdapter _tblInterestTableAdapter;
    private tblInterestDummyTableAdapter _tblInterestDummyTableAdapter;
    private tblInterestReceivedTableAdapter _tblInterestReceivedTableAdapter;
    private tblInterestSettingTableAdapter _tblInterestSettingTableAdapter;
    private tblKhaathoTableAdapter _tblKhaathoTableAdapter;
    private tblLedgerrTableAdapter _tblLedgerrTableAdapter;
    private tblLoginTableAdapter _tblLoginTableAdapter;
    private tblMemberTypeTableAdapter _tblMemberTypeTableAdapter;
    private tblMenuSettingsTableAdapter _tblMenuSettingsTableAdapter;
    private tblMessageTableAdapter _tblMessageTableAdapter;
    private tblmonitorTableAdapter _tblmonitorTableAdapter;
    private tblOrderTableAdapter _tblOrderTableAdapter;
    private tblPincodeTableAdapter _tblPincodeTableAdapter;
    private tblPledgeTableAdapter _tblPledgeTableAdapter;
    private tblPledgeArticlesTableAdapter _tblPledgeArticlesTableAdapter;
    private tblPledgeArticlesCombinedTableAdapter _tblPledgeArticlesCombinedTableAdapter;
    private tblPledgeBillNumberSeriesTableAdapter _tblPledgeBillNumberSeriesTableAdapter;
    private tblPledgePrintSettingsTableAdapter _tblPledgePrintSettingsTableAdapter;
    private tblPrintSettingsTableAdapter _tblPrintSettingsTableAdapter;
    private tblRedemptionTableAdapter _tblRedemptionTableAdapter;
    private tblRedemptionPrintSettingsTableAdapter _tblRedemptionPrintSettingsTableAdapter;
    private tblReminderTableAdapter _tblReminderTableAdapter;
    private tblRokadDetailsTableAdapter _tblRokadDetailsTableAdapter;
    private tblSentSmsTableAdapter _tblSentSmsTableAdapter;
    private tblSettingsTableAdapter _tblSettingsTableAdapter;
    private tblShopDetailsTableAdapter _tblShopDetailsTableAdapter;
    private tbltable1TableAdapter _tbltable1TableAdapter;
    private tblUdhrathTableAdapter _tblUdhrathTableAdapter;
    private tblVersionTableAdapter _tblVersionTableAdapter;
    private tblVoucherMasterTableAdapter _tblVoucherMasterTableAdapter;
    private tblVouchersTableAdapter _tblVouchersTableAdapter;
    private tblRateTableAdapter _tblRateTableAdapter;
    private tblItemNamesTableAdapter _tblItemNamesTableAdapter;
    private Paste_Errors1TableAdapter _paste_Errors1TableAdapter;
    private tblItemTypeTableAdapter _tblItemTypeTableAdapter;
    private tblPurchaseTableAdapter _tblPurchaseTableAdapter;
    private tblSalesTableAdapter _tblSalesTableAdapter;
    private tblInterestCalculationSettingsTableAdapter _tblInterestCalculationSettingsTableAdapter;
    private tblLicenseDetailsTableAdapter _tblLicenseDetailsTableAdapter;
    private tblMetalMasterTableAdapter _tblMetalMasterTableAdapter;
    private tblPurityMasterTableAdapter _tblPurityMasterTableAdapter;
    private Paste_Errors2TableAdapter _paste_Errors2TableAdapter;
    private tblArticlesJewelleryTableAdapter _tblArticlesJewelleryTableAdapter;
    private tblBoxTableAdapter _tblBoxTableAdapter;
    private tblDenominationTableAdapter _tblDenominationTableAdapter;
    private tblFinancialYearsTableAdapter _tblFinancialYearsTableAdapter;
    private tblOldPurchaseTableAdapter _tblOldPurchaseTableAdapter;
    private tblOpeningStockTableAdapter _tblOpeningStockTableAdapter;
    private tblPaymentsTableAdapter _tblPaymentsTableAdapter;
    private tblSalesDetailsTableAdapter _tblSalesDetailsTableAdapter;
    private tblStockTableAdapter _tblStockTableAdapter;
    private Paste_Errors3TableAdapter _paste_Errors3TableAdapter;
    private Paste_Errors4TableAdapter _paste_Errors4TableAdapter;
    private Paste_Errors5TableAdapter _paste_Errors5TableAdapter;
    private tblBillNumberSettingsTableAdapter _tblBillNumberSettingsTableAdapter;
    private Paste_Errors6TableAdapter _paste_Errors6TableAdapter;
    private Paste_Errors7TableAdapter _paste_Errors7TableAdapter;
    private tblBankDetailsTableAdapter _tblBankDetailsTableAdapter;
    private bool _backupDataSetBeforeUpdate;
    private IDbConnection _connection;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public TableAdapterManager.UpdateOrderOption UpdateOrder
    {
      get => this._updateOrder;
      set => this._updateOrder = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_ErrorsTableAdapter Paste_ErrorsTableAdapter
    {
      get => this._paste_ErrorsTableAdapter;
      set => this._paste_ErrorsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblArticlesTableAdapter tblArticlesTableAdapter
    {
      get => this._tblArticlesTableAdapter;
      set => this._tblArticlesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblArticlesDescriptionTableAdapter tblArticlesDescriptionTableAdapter
    {
      get => this._tblArticlesDescriptionTableAdapter;
      set => this._tblArticlesDescriptionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblArticlesSettingsTableAdapter tblArticlesSettingsTableAdapter
    {
      get => this._tblArticlesSettingsTableAdapter;
      set => this._tblArticlesSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblAutoDeleteRokadTableAdapter tblAutoDeleteRokadTableAdapter
    {
      get => this._tblAutoDeleteRokadTableAdapter;
      set => this._tblAutoDeleteRokadTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBackUpTableAdapter tblBackUpTableAdapter
    {
      get => this._tblBackUpTableAdapter;
      set => this._tblBackUpTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBankMasterTableAdapter tblBankMasterTableAdapter
    {
      get => this._tblBankMasterTableAdapter;
      set => this._tblBankMasterTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBankPledgeTableAdapter tblBankPledgeTableAdapter
    {
      get => this._tblBankPledgeTableAdapter;
      set => this._tblBankPledgeTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBankPledgePledgeBillsTableAdapter tblBankPledgePledgeBillsTableAdapter
    {
      get => this._tblBankPledgePledgeBillsTableAdapter;
      set => this._tblBankPledgePledgeBillsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBillerTableAdapter tblBillerTableAdapter
    {
      get => this._tblBillerTableAdapter;
      set => this._tblBillerTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblColoursTableAdapter tblColoursTableAdapter
    {
      get => this._tblColoursTableAdapter;
      set => this._tblColoursTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCompanyDetailsTableAdapter tblCompanyDetailsTableAdapter
    {
      get => this._tblCompanyDetailsTableAdapter;
      set => this._tblCompanyDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCustomersTableAdapter tblCustomersTableAdapter
    {
      get => this._tblCustomersTableAdapter;
      set => this._tblCustomersTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDatesTableAdapter tblDatesTableAdapter
    {
      get => this._tblDatesTableAdapter;
      set => this._tblDatesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblExceptionsTableAdapter tblExceptionsTableAdapter
    {
      get => this._tblExceptionsTableAdapter;
      set => this._tblExceptionsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblGramRateTableAdapter tblGramRateTableAdapter
    {
      get => this._tblGramRateTableAdapter;
      set => this._tblGramRateTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblHistoryTableAdapter tblHistoryTableAdapter
    {
      get => this._tblHistoryTableAdapter;
      set => this._tblHistoryTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblhistoryReminderTableAdapter tblhistoryReminderTableAdapter
    {
      get => this._tblhistoryReminderTableAdapter;
      set => this._tblhistoryReminderTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public TBLIMAGETableAdapter TBLIMAGETableAdapter
    {
      get => this._tBLIMAGETableAdapter;
      set => this._tBLIMAGETableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInterestTableAdapter tblInterestTableAdapter
    {
      get => this._tblInterestTableAdapter;
      set => this._tblInterestTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInterestDummyTableAdapter tblInterestDummyTableAdapter
    {
      get => this._tblInterestDummyTableAdapter;
      set => this._tblInterestDummyTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInterestReceivedTableAdapter tblInterestReceivedTableAdapter
    {
      get => this._tblInterestReceivedTableAdapter;
      set => this._tblInterestReceivedTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInterestSettingTableAdapter tblInterestSettingTableAdapter
    {
      get => this._tblInterestSettingTableAdapter;
      set => this._tblInterestSettingTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblKhaathoTableAdapter tblKhaathoTableAdapter
    {
      get => this._tblKhaathoTableAdapter;
      set => this._tblKhaathoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblLedgerrTableAdapter tblLedgerrTableAdapter
    {
      get => this._tblLedgerrTableAdapter;
      set => this._tblLedgerrTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblLoginTableAdapter tblLoginTableAdapter
    {
      get => this._tblLoginTableAdapter;
      set => this._tblLoginTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMemberTypeTableAdapter tblMemberTypeTableAdapter
    {
      get => this._tblMemberTypeTableAdapter;
      set => this._tblMemberTypeTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMenuSettingsTableAdapter tblMenuSettingsTableAdapter
    {
      get => this._tblMenuSettingsTableAdapter;
      set => this._tblMenuSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMessageTableAdapter tblMessageTableAdapter
    {
      get => this._tblMessageTableAdapter;
      set => this._tblMessageTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblmonitorTableAdapter tblmonitorTableAdapter
    {
      get => this._tblmonitorTableAdapter;
      set => this._tblmonitorTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrderTableAdapter tblOrderTableAdapter
    {
      get => this._tblOrderTableAdapter;
      set => this._tblOrderTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPincodeTableAdapter tblPincodeTableAdapter
    {
      get => this._tblPincodeTableAdapter;
      set => this._tblPincodeTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPledgeTableAdapter tblPledgeTableAdapter
    {
      get => this._tblPledgeTableAdapter;
      set => this._tblPledgeTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPledgeArticlesTableAdapter tblPledgeArticlesTableAdapter
    {
      get => this._tblPledgeArticlesTableAdapter;
      set => this._tblPledgeArticlesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPledgeArticlesCombinedTableAdapter tblPledgeArticlesCombinedTableAdapter
    {
      get => this._tblPledgeArticlesCombinedTableAdapter;
      set => this._tblPledgeArticlesCombinedTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPledgeBillNumberSeriesTableAdapter tblPledgeBillNumberSeriesTableAdapter
    {
      get => this._tblPledgeBillNumberSeriesTableAdapter;
      set => this._tblPledgeBillNumberSeriesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPledgePrintSettingsTableAdapter tblPledgePrintSettingsTableAdapter
    {
      get => this._tblPledgePrintSettingsTableAdapter;
      set => this._tblPledgePrintSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPrintSettingsTableAdapter tblPrintSettingsTableAdapter
    {
      get => this._tblPrintSettingsTableAdapter;
      set => this._tblPrintSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRedemptionTableAdapter tblRedemptionTableAdapter
    {
      get => this._tblRedemptionTableAdapter;
      set => this._tblRedemptionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRedemptionPrintSettingsTableAdapter tblRedemptionPrintSettingsTableAdapter
    {
      get => this._tblRedemptionPrintSettingsTableAdapter;
      set => this._tblRedemptionPrintSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblReminderTableAdapter tblReminderTableAdapter
    {
      get => this._tblReminderTableAdapter;
      set => this._tblReminderTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRokadDetailsTableAdapter tblRokadDetailsTableAdapter
    {
      get => this._tblRokadDetailsTableAdapter;
      set => this._tblRokadDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSentSmsTableAdapter tblSentSmsTableAdapter
    {
      get => this._tblSentSmsTableAdapter;
      set => this._tblSentSmsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSettingsTableAdapter tblSettingsTableAdapter
    {
      get => this._tblSettingsTableAdapter;
      set => this._tblSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblShopDetailsTableAdapter tblShopDetailsTableAdapter
    {
      get => this._tblShopDetailsTableAdapter;
      set => this._tblShopDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tbltable1TableAdapter tbltable1TableAdapter
    {
      get => this._tbltable1TableAdapter;
      set => this._tbltable1TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblUdhrathTableAdapter tblUdhrathTableAdapter
    {
      get => this._tblUdhrathTableAdapter;
      set => this._tblUdhrathTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVersionTableAdapter tblVersionTableAdapter
    {
      get => this._tblVersionTableAdapter;
      set => this._tblVersionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVoucherMasterTableAdapter tblVoucherMasterTableAdapter
    {
      get => this._tblVoucherMasterTableAdapter;
      set => this._tblVoucherMasterTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVouchersTableAdapter tblVouchersTableAdapter
    {
      get => this._tblVouchersTableAdapter;
      set => this._tblVouchersTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRateTableAdapter tblRateTableAdapter
    {
      get => this._tblRateTableAdapter;
      set => this._tblRateTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblItemNamesTableAdapter tblItemNamesTableAdapter
    {
      get => this._tblItemNamesTableAdapter;
      set => this._tblItemNamesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors1TableAdapter Paste_Errors1TableAdapter
    {
      get => this._paste_Errors1TableAdapter;
      set => this._paste_Errors1TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblItemTypeTableAdapter tblItemTypeTableAdapter
    {
      get => this._tblItemTypeTableAdapter;
      set => this._tblItemTypeTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPurchaseTableAdapter tblPurchaseTableAdapter
    {
      get => this._tblPurchaseTableAdapter;
      set => this._tblPurchaseTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSalesTableAdapter tblSalesTableAdapter
    {
      get => this._tblSalesTableAdapter;
      set => this._tblSalesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInterestCalculationSettingsTableAdapter tblInterestCalculationSettingsTableAdapter
    {
      get => this._tblInterestCalculationSettingsTableAdapter;
      set => this._tblInterestCalculationSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblLicenseDetailsTableAdapter tblLicenseDetailsTableAdapter
    {
      get => this._tblLicenseDetailsTableAdapter;
      set => this._tblLicenseDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMetalMasterTableAdapter tblMetalMasterTableAdapter
    {
      get => this._tblMetalMasterTableAdapter;
      set => this._tblMetalMasterTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPurityMasterTableAdapter tblPurityMasterTableAdapter
    {
      get => this._tblPurityMasterTableAdapter;
      set => this._tblPurityMasterTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors2TableAdapter Paste_Errors2TableAdapter
    {
      get => this._paste_Errors2TableAdapter;
      set => this._paste_Errors2TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblArticlesJewelleryTableAdapter tblArticlesJewelleryTableAdapter
    {
      get => this._tblArticlesJewelleryTableAdapter;
      set => this._tblArticlesJewelleryTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBoxTableAdapter tblBoxTableAdapter
    {
      get => this._tblBoxTableAdapter;
      set => this._tblBoxTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDenominationTableAdapter tblDenominationTableAdapter
    {
      get => this._tblDenominationTableAdapter;
      set => this._tblDenominationTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFinancialYearsTableAdapter tblFinancialYearsTableAdapter
    {
      get => this._tblFinancialYearsTableAdapter;
      set => this._tblFinancialYearsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOldPurchaseTableAdapter tblOldPurchaseTableAdapter
    {
      get => this._tblOldPurchaseTableAdapter;
      set => this._tblOldPurchaseTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOpeningStockTableAdapter tblOpeningStockTableAdapter
    {
      get => this._tblOpeningStockTableAdapter;
      set => this._tblOpeningStockTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPaymentsTableAdapter tblPaymentsTableAdapter
    {
      get => this._tblPaymentsTableAdapter;
      set => this._tblPaymentsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSalesDetailsTableAdapter tblSalesDetailsTableAdapter
    {
      get => this._tblSalesDetailsTableAdapter;
      set => this._tblSalesDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblStockTableAdapter tblStockTableAdapter
    {
      get => this._tblStockTableAdapter;
      set => this._tblStockTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors3TableAdapter Paste_Errors3TableAdapter
    {
      get => this._paste_Errors3TableAdapter;
      set => this._paste_Errors3TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors4TableAdapter Paste_Errors4TableAdapter
    {
      get => this._paste_Errors4TableAdapter;
      set => this._paste_Errors4TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors5TableAdapter Paste_Errors5TableAdapter
    {
      get => this._paste_Errors5TableAdapter;
      set => this._paste_Errors5TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBillNumberSettingsTableAdapter tblBillNumberSettingsTableAdapter
    {
      get => this._tblBillNumberSettingsTableAdapter;
      set => this._tblBillNumberSettingsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors6TableAdapter Paste_Errors6TableAdapter
    {
      get => this._paste_Errors6TableAdapter;
      set => this._paste_Errors6TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Paste_Errors7TableAdapter Paste_Errors7TableAdapter
    {
      get => this._paste_Errors7TableAdapter;
      set => this._paste_Errors7TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBankDetailsTableAdapter tblBankDetailsTableAdapter
    {
      get => this._tblBankDetailsTableAdapter;
      set => this._tblBankDetailsTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public bool BackupDataSetBeforeUpdate
    {
      get => this._backupDataSetBeforeUpdate;
      set => this._backupDataSetBeforeUpdate = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    public IDbConnection Connection
    {
      get
      {
        if (this._connection != null)
          return this._connection;
        if (this._paste_ErrorsTableAdapter != null && this._paste_ErrorsTableAdapter.Connection != null)
          return (IDbConnection) this._paste_ErrorsTableAdapter.Connection;
        if (this._tblArticlesTableAdapter != null && this._tblArticlesTableAdapter.Connection != null)
          return (IDbConnection) this._tblArticlesTableAdapter.Connection;
        if (this._tblArticlesDescriptionTableAdapter != null && this._tblArticlesDescriptionTableAdapter.Connection != null)
          return (IDbConnection) this._tblArticlesDescriptionTableAdapter.Connection;
        if (this._tblArticlesSettingsTableAdapter != null && this._tblArticlesSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblArticlesSettingsTableAdapter.Connection;
        if (this._tblAutoDeleteRokadTableAdapter != null && this._tblAutoDeleteRokadTableAdapter.Connection != null)
          return (IDbConnection) this._tblAutoDeleteRokadTableAdapter.Connection;
        if (this._tblBackUpTableAdapter != null && this._tblBackUpTableAdapter.Connection != null)
          return (IDbConnection) this._tblBackUpTableAdapter.Connection;
        if (this._tblBankMasterTableAdapter != null && this._tblBankMasterTableAdapter.Connection != null)
          return (IDbConnection) this._tblBankMasterTableAdapter.Connection;
        if (this._tblBankPledgeTableAdapter != null && this._tblBankPledgeTableAdapter.Connection != null)
          return (IDbConnection) this._tblBankPledgeTableAdapter.Connection;
        if (this._tblBankPledgePledgeBillsTableAdapter != null && this._tblBankPledgePledgeBillsTableAdapter.Connection != null)
          return (IDbConnection) this._tblBankPledgePledgeBillsTableAdapter.Connection;
        if (this._tblBillerTableAdapter != null && this._tblBillerTableAdapter.Connection != null)
          return (IDbConnection) this._tblBillerTableAdapter.Connection;
        if (this._tblColoursTableAdapter != null && this._tblColoursTableAdapter.Connection != null)
          return (IDbConnection) this._tblColoursTableAdapter.Connection;
        if (this._tblCompanyDetailsTableAdapter != null && this._tblCompanyDetailsTableAdapter.Connection != null)
          return (IDbConnection) this._tblCompanyDetailsTableAdapter.Connection;
        if (this._tblCustomersTableAdapter != null && this._tblCustomersTableAdapter.Connection != null)
          return (IDbConnection) this._tblCustomersTableAdapter.Connection;
        if (this._tblDatesTableAdapter != null && this._tblDatesTableAdapter.Connection != null)
          return (IDbConnection) this._tblDatesTableAdapter.Connection;
        if (this._tblExceptionsTableAdapter != null && this._tblExceptionsTableAdapter.Connection != null)
          return (IDbConnection) this._tblExceptionsTableAdapter.Connection;
        if (this._tblGramRateTableAdapter != null && this._tblGramRateTableAdapter.Connection != null)
          return (IDbConnection) this._tblGramRateTableAdapter.Connection;
        if (this._tblHistoryTableAdapter != null && this._tblHistoryTableAdapter.Connection != null)
          return (IDbConnection) this._tblHistoryTableAdapter.Connection;
        if (this._tblhistoryReminderTableAdapter != null && this._tblhistoryReminderTableAdapter.Connection != null)
          return (IDbConnection) this._tblhistoryReminderTableAdapter.Connection;
        if (this._tBLIMAGETableAdapter != null && this._tBLIMAGETableAdapter.Connection != null)
          return (IDbConnection) this._tBLIMAGETableAdapter.Connection;
        if (this._tblInterestTableAdapter != null && this._tblInterestTableAdapter.Connection != null)
          return (IDbConnection) this._tblInterestTableAdapter.Connection;
        if (this._tblInterestDummyTableAdapter != null && this._tblInterestDummyTableAdapter.Connection != null)
          return (IDbConnection) this._tblInterestDummyTableAdapter.Connection;
        if (this._tblInterestReceivedTableAdapter != null && this._tblInterestReceivedTableAdapter.Connection != null)
          return (IDbConnection) this._tblInterestReceivedTableAdapter.Connection;
        if (this._tblInterestSettingTableAdapter != null && this._tblInterestSettingTableAdapter.Connection != null)
          return (IDbConnection) this._tblInterestSettingTableAdapter.Connection;
        if (this._tblKhaathoTableAdapter != null && this._tblKhaathoTableAdapter.Connection != null)
          return (IDbConnection) this._tblKhaathoTableAdapter.Connection;
        if (this._tblLedgerrTableAdapter != null && this._tblLedgerrTableAdapter.Connection != null)
          return (IDbConnection) this._tblLedgerrTableAdapter.Connection;
        if (this._tblLoginTableAdapter != null && this._tblLoginTableAdapter.Connection != null)
          return (IDbConnection) this._tblLoginTableAdapter.Connection;
        if (this._tblMemberTypeTableAdapter != null && this._tblMemberTypeTableAdapter.Connection != null)
          return (IDbConnection) this._tblMemberTypeTableAdapter.Connection;
        if (this._tblMenuSettingsTableAdapter != null && this._tblMenuSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblMenuSettingsTableAdapter.Connection;
        if (this._tblMessageTableAdapter != null && this._tblMessageTableAdapter.Connection != null)
          return (IDbConnection) this._tblMessageTableAdapter.Connection;
        if (this._tblmonitorTableAdapter != null && this._tblmonitorTableAdapter.Connection != null)
          return (IDbConnection) this._tblmonitorTableAdapter.Connection;
        if (this._tblOrderTableAdapter != null && this._tblOrderTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrderTableAdapter.Connection;
        if (this._tblPincodeTableAdapter != null && this._tblPincodeTableAdapter.Connection != null)
          return (IDbConnection) this._tblPincodeTableAdapter.Connection;
        if (this._tblPledgeTableAdapter != null && this._tblPledgeTableAdapter.Connection != null)
          return (IDbConnection) this._tblPledgeTableAdapter.Connection;
        if (this._tblPledgeArticlesTableAdapter != null && this._tblPledgeArticlesTableAdapter.Connection != null)
          return (IDbConnection) this._tblPledgeArticlesTableAdapter.Connection;
        if (this._tblPledgeArticlesCombinedTableAdapter != null && this._tblPledgeArticlesCombinedTableAdapter.Connection != null)
          return (IDbConnection) this._tblPledgeArticlesCombinedTableAdapter.Connection;
        if (this._tblPledgeBillNumberSeriesTableAdapter != null && this._tblPledgeBillNumberSeriesTableAdapter.Connection != null)
          return (IDbConnection) this._tblPledgeBillNumberSeriesTableAdapter.Connection;
        if (this._tblPledgePrintSettingsTableAdapter != null && this._tblPledgePrintSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblPledgePrintSettingsTableAdapter.Connection;
        if (this._tblPrintSettingsTableAdapter != null && this._tblPrintSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblPrintSettingsTableAdapter.Connection;
        if (this._tblRedemptionTableAdapter != null && this._tblRedemptionTableAdapter.Connection != null)
          return (IDbConnection) this._tblRedemptionTableAdapter.Connection;
        if (this._tblRedemptionPrintSettingsTableAdapter != null && this._tblRedemptionPrintSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblRedemptionPrintSettingsTableAdapter.Connection;
        if (this._tblReminderTableAdapter != null && this._tblReminderTableAdapter.Connection != null)
          return (IDbConnection) this._tblReminderTableAdapter.Connection;
        if (this._tblRokadDetailsTableAdapter != null && this._tblRokadDetailsTableAdapter.Connection != null)
          return (IDbConnection) this._tblRokadDetailsTableAdapter.Connection;
        if (this._tblSentSmsTableAdapter != null && this._tblSentSmsTableAdapter.Connection != null)
          return (IDbConnection) this._tblSentSmsTableAdapter.Connection;
        if (this._tblSettingsTableAdapter != null && this._tblSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblSettingsTableAdapter.Connection;
        if (this._tblShopDetailsTableAdapter != null && this._tblShopDetailsTableAdapter.Connection != null)
          return (IDbConnection) this._tblShopDetailsTableAdapter.Connection;
        if (this._tbltable1TableAdapter != null && this._tbltable1TableAdapter.Connection != null)
          return (IDbConnection) this._tbltable1TableAdapter.Connection;
        if (this._tblUdhrathTableAdapter != null && this._tblUdhrathTableAdapter.Connection != null)
          return (IDbConnection) this._tblUdhrathTableAdapter.Connection;
        if (this._tblVersionTableAdapter != null && this._tblVersionTableAdapter.Connection != null)
          return (IDbConnection) this._tblVersionTableAdapter.Connection;
        if (this._tblVoucherMasterTableAdapter != null && this._tblVoucherMasterTableAdapter.Connection != null)
          return (IDbConnection) this._tblVoucherMasterTableAdapter.Connection;
        if (this._tblVouchersTableAdapter != null && this._tblVouchersTableAdapter.Connection != null)
          return (IDbConnection) this._tblVouchersTableAdapter.Connection;
        if (this._tblRateTableAdapter != null && this._tblRateTableAdapter.Connection != null)
          return (IDbConnection) this._tblRateTableAdapter.Connection;
        if (this._tblItemNamesTableAdapter != null && this._tblItemNamesTableAdapter.Connection != null)
          return (IDbConnection) this._tblItemNamesTableAdapter.Connection;
        if (this._paste_Errors1TableAdapter != null && this._paste_Errors1TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors1TableAdapter.Connection;
        if (this._tblItemTypeTableAdapter != null && this._tblItemTypeTableAdapter.Connection != null)
          return (IDbConnection) this._tblItemTypeTableAdapter.Connection;
        if (this._tblPurchaseTableAdapter != null && this._tblPurchaseTableAdapter.Connection != null)
          return (IDbConnection) this._tblPurchaseTableAdapter.Connection;
        if (this._tblSalesTableAdapter != null && this._tblSalesTableAdapter.Connection != null)
          return (IDbConnection) this._tblSalesTableAdapter.Connection;
        if (this._tblInterestCalculationSettingsTableAdapter != null && this._tblInterestCalculationSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblInterestCalculationSettingsTableAdapter.Connection;
        if (this._tblLicenseDetailsTableAdapter != null && this._tblLicenseDetailsTableAdapter.Connection != null)
          return (IDbConnection) this._tblLicenseDetailsTableAdapter.Connection;
        if (this._tblMetalMasterTableAdapter != null && this._tblMetalMasterTableAdapter.Connection != null)
          return (IDbConnection) this._tblMetalMasterTableAdapter.Connection;
        if (this._tblPurityMasterTableAdapter != null && this._tblPurityMasterTableAdapter.Connection != null)
          return (IDbConnection) this._tblPurityMasterTableAdapter.Connection;
        if (this._paste_Errors2TableAdapter != null && this._paste_Errors2TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors2TableAdapter.Connection;
        if (this._tblArticlesJewelleryTableAdapter != null && this._tblArticlesJewelleryTableAdapter.Connection != null)
          return (IDbConnection) this._tblArticlesJewelleryTableAdapter.Connection;
        if (this._tblBoxTableAdapter != null && this._tblBoxTableAdapter.Connection != null)
          return (IDbConnection) this._tblBoxTableAdapter.Connection;
        if (this._tblDenominationTableAdapter != null && this._tblDenominationTableAdapter.Connection != null)
          return (IDbConnection) this._tblDenominationTableAdapter.Connection;
        if (this._tblFinancialYearsTableAdapter != null && this._tblFinancialYearsTableAdapter.Connection != null)
          return (IDbConnection) this._tblFinancialYearsTableAdapter.Connection;
        if (this._tblOldPurchaseTableAdapter != null && this._tblOldPurchaseTableAdapter.Connection != null)
          return (IDbConnection) this._tblOldPurchaseTableAdapter.Connection;
        if (this._tblOpeningStockTableAdapter != null && this._tblOpeningStockTableAdapter.Connection != null)
          return (IDbConnection) this._tblOpeningStockTableAdapter.Connection;
        if (this._tblPaymentsTableAdapter != null && this._tblPaymentsTableAdapter.Connection != null)
          return (IDbConnection) this._tblPaymentsTableAdapter.Connection;
        if (this._tblSalesDetailsTableAdapter != null && this._tblSalesDetailsTableAdapter.Connection != null)
          return (IDbConnection) this._tblSalesDetailsTableAdapter.Connection;
        if (this._tblStockTableAdapter != null && this._tblStockTableAdapter.Connection != null)
          return (IDbConnection) this._tblStockTableAdapter.Connection;
        if (this._paste_Errors3TableAdapter != null && this._paste_Errors3TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors3TableAdapter.Connection;
        if (this._paste_Errors4TableAdapter != null && this._paste_Errors4TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors4TableAdapter.Connection;
        if (this._paste_Errors5TableAdapter != null && this._paste_Errors5TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors5TableAdapter.Connection;
        if (this._tblBillNumberSettingsTableAdapter != null && this._tblBillNumberSettingsTableAdapter.Connection != null)
          return (IDbConnection) this._tblBillNumberSettingsTableAdapter.Connection;
        if (this._paste_Errors6TableAdapter != null && this._paste_Errors6TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors6TableAdapter.Connection;
        if (this._paste_Errors7TableAdapter != null && this._paste_Errors7TableAdapter.Connection != null)
          return (IDbConnection) this._paste_Errors7TableAdapter.Connection;
        return this._tblBankDetailsTableAdapter != null && this._tblBankDetailsTableAdapter.Connection != null ? (IDbConnection) this._tblBankDetailsTableAdapter.Connection : (IDbConnection) null;
      }
      set => this._connection = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    public int TableAdapterInstanceCount
    {
      get
      {
        int adapterInstanceCount = 0;
        if (this._paste_ErrorsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblArticlesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblArticlesDescriptionTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblArticlesSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblAutoDeleteRokadTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBackUpTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBankMasterTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBankPledgeTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBankPledgePledgeBillsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBillerTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblColoursTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblCompanyDetailsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblCustomersTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblDatesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblExceptionsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblGramRateTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblHistoryTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblhistoryReminderTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tBLIMAGETableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblInterestTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblInterestDummyTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblInterestReceivedTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblInterestSettingTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblKhaathoTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblLedgerrTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblLoginTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblMemberTypeTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblMenuSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblMessageTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblmonitorTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblOrderTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPincodeTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPledgeTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPledgeArticlesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPledgeArticlesCombinedTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPledgeBillNumberSeriesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPledgePrintSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPrintSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblRedemptionTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblRedemptionPrintSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblReminderTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblRokadDetailsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblSentSmsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblShopDetailsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tbltable1TableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblUdhrathTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblVersionTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblVoucherMasterTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblVouchersTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblRateTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblItemNamesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors1TableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblItemTypeTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPurchaseTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblSalesTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblInterestCalculationSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblLicenseDetailsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblMetalMasterTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPurityMasterTableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors2TableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblArticlesJewelleryTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBoxTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblDenominationTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblFinancialYearsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblOldPurchaseTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblOpeningStockTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblPaymentsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblSalesDetailsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblStockTableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors3TableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors4TableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors5TableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBillNumberSettingsTableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors6TableAdapter != null)
          ++adapterInstanceCount;
        if (this._paste_Errors7TableAdapter != null)
          ++adapterInstanceCount;
        if (this._tblBankDetailsTableAdapter != null)
          ++adapterInstanceCount;
        return adapterInstanceCount;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private int UpdateUpdatedRows(
      pawnmanagementDataSet1 dataSet,
      List<DataRow> allChangedRows,
      List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._paste_ErrorsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_ErrorsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPurchaseTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPurchase.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPurchaseTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblItemTypeTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblItemType.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblItemTypeTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors1TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors1.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors1TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblItemNamesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblItemNames.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblItemNamesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRateTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRate.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRateTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVouchersTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVouchers.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVouchersTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVoucherMasterTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVoucherMaster.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVoucherMasterTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVersionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVersion.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVersionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblUdhrathTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblUdhrath.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblUdhrathTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tbltable1TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tbltable1.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tbltable1TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblShopDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblShopDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblShopDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSentSmsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSentSms.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSentSmsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRokadDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRokadDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRokadDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblReminderTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblReminder.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblReminderTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSalesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSales.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSalesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInterestCalculationSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInterestCalculationSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInterestCalculationSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblLicenseDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblLicenseDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblLicenseDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMetalMasterTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMetalMaster.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMetalMasterTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors6TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors6.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors6TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBillNumberSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBillNumberSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBillNumberSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors5TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors5.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors5TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors4TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors4.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors4TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors3TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors3.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors3TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblStockTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblStock.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblStockTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSalesDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSalesDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSalesDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRedemptionPrintSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRedemptionPrintSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRedemptionPrintSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPaymentsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPayments.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPaymentsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOldPurchaseTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOldPurchase.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOldPurchaseTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFinancialYearsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFinancialYears.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFinancialYearsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDenominationTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDenomination.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDenominationTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBoxTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBox.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBoxTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblArticlesJewelleryTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblArticlesJewellery.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblArticlesJewelleryTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors2TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors2.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors2TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPurityMasterTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPurityMaster.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPurityMasterTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOpeningStockTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOpeningStock.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOpeningStockTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._paste_Errors7TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Paste_Errors7.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._paste_Errors7TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRedemptionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRedemption.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRedemptionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPledgePrintSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPledgePrintSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPledgePrintSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblGramRateTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblGramRate.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblGramRateTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblExceptionsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblExceptions.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblExceptionsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDatesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDates.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDatesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCustomersTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCustomers.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCustomersTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCompanyDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCompanyDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCompanyDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblColoursTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblColours.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblColoursTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBillerTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBiller.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBillerTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBankPledgePledgeBillsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBankPledgePledgeBills.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBankPledgePledgeBillsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBankPledgeTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBankPledge.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBankPledgeTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBankMasterTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBankMaster.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBankMasterTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBackUpTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBackUp.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBackUpTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblAutoDeleteRokadTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblAutoDeleteRokad.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblAutoDeleteRokadTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblArticlesSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblArticlesSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblArticlesSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblArticlesDescriptionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblArticlesDescription.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblArticlesDescriptionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblArticlesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblArticles.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblArticlesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblHistoryTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblHistory.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblHistoryTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblhistoryReminderTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblhistoryReminder.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblhistoryReminderTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tBLIMAGETableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.TBLIMAGE.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tBLIMAGETableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInterestTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInterest.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInterestTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPledgeBillNumberSeriesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPledgeBillNumberSeries.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPledgeBillNumberSeriesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPledgeArticlesCombinedTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPledgeArticlesCombined.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPledgeArticlesCombinedTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPledgeArticlesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPledgeArticles.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPledgeArticlesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPledgeTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPledge.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPledgeTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPincodeTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPincode.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPincodeTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrderTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrder.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrderTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblmonitorTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblmonitor.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblmonitorTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPrintSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPrintSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPrintSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMessageTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMessage.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMessageTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMemberTypeTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMemberType.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMemberTypeTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblLoginTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblLogin.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblLoginTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblLedgerrTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblLedgerr.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblLedgerrTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblKhaathoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblKhaatho.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblKhaathoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInterestSettingTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInterestSetting.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInterestSettingTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInterestReceivedTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInterestReceived.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInterestReceivedTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInterestDummyTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInterestDummy.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInterestDummyTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMenuSettingsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMenuSettings.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMenuSettingsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBankDetailsTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBankDetails.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBankDetailsTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private int UpdateInsertedRows(pawnmanagementDataSet1 dataSet, List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._paste_ErrorsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_ErrorsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPurchaseTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPurchase.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPurchaseTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblItemTypeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblItemType.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblItemTypeTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors1TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors1.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors1TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblItemNamesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblItemNames.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblItemNamesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRateTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRate.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRateTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVouchersTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVouchers.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVouchersTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVoucherMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVoucherMaster.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVoucherMasterTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVersionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVersion.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVersionTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblUdhrathTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblUdhrath.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblUdhrathTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tbltable1TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tbltable1.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tbltable1TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblShopDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblShopDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblShopDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSentSmsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSentSms.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSentSmsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRokadDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRokadDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRokadDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblReminderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblReminder.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblReminderTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSalesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSales.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSalesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestCalculationSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestCalculationSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestCalculationSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLicenseDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLicenseDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLicenseDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMetalMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMetalMaster.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMetalMasterTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors6TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors6.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors6TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBillNumberSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBillNumberSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBillNumberSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors5TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors5.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors5TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors4TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors4.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors4TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors3TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors3.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors3TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblStockTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblStock.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblStockTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSalesDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSalesDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSalesDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRedemptionPrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRedemptionPrintSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRedemptionPrintSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPaymentsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPayments.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPaymentsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOldPurchaseTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOldPurchase.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOldPurchaseTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblFinancialYearsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblFinancialYears.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblFinancialYearsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblDenominationTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblDenomination.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblDenominationTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBoxTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBox.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBoxTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesJewelleryTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesJewellery.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesJewelleryTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors2TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors2.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors2TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPurityMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPurityMaster.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPurityMasterTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOpeningStockTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOpeningStock.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOpeningStockTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors7TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors7.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors7TableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRedemptionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRedemption.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRedemptionTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgePrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgePrintSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgePrintSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblGramRateTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblGramRate.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblGramRateTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblExceptionsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblExceptions.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblExceptionsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblDatesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblDates.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblDatesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblCustomersTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblCustomers.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblCustomersTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblCompanyDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblCompanyDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblCompanyDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblColoursTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblColours.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblColoursTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBillerTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBiller.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBillerTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankPledgePledgeBillsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankPledgePledgeBills.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankPledgePledgeBillsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankPledgeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankPledge.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankPledgeTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankMaster.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankMasterTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBackUpTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBackUp.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBackUpTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblAutoDeleteRokadTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblAutoDeleteRokad.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblAutoDeleteRokadTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesDescriptionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesDescription.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesDescriptionTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticles.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblHistoryTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblHistory.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblHistoryTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblhistoryReminderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblhistoryReminder.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblhistoryReminderTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tBLIMAGETableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.TBLIMAGE.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tBLIMAGETableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterest.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeBillNumberSeriesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeBillNumberSeries.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeBillNumberSeriesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeArticlesCombinedTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeArticlesCombined.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeArticlesCombinedTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeArticlesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeArticles.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeArticlesTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledge.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPincodeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPincode.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPincodeTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOrderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOrder.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOrderTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblmonitorTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblmonitor.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblmonitorTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPrintSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPrintSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMessageTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMessage.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMessageTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMemberTypeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMemberType.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMemberTypeTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLoginTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLogin.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLoginTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLedgerrTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLedgerr.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLedgerrTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblKhaathoTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblKhaatho.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblKhaathoTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestSettingTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestSetting.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestSettingTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestReceivedTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestReceived.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestReceivedTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestDummyTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestDummy.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestDummyTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMenuSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMenuSettings.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMenuSettingsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankDetails.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankDetailsTableAdapter.Update(dataRowArray);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private int UpdateDeletedRows(pawnmanagementDataSet1 dataSet, List<DataRow> allChangedRows)
    {
      int num = 0;
      if (this._tblBankDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMenuSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMenuSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMenuSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestDummyTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestDummy.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestDummyTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestReceivedTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestReceived.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestReceivedTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestSettingTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestSetting.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestSettingTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblKhaathoTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblKhaatho.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblKhaathoTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLedgerrTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLedgerr.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLedgerrTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLoginTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLogin.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLoginTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMemberTypeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMemberType.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMemberTypeTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMessageTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMessage.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMessageTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPrintSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPrintSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblmonitorTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblmonitor.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblmonitorTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOrderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOrder.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOrderTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPincodeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPincode.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPincodeTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledge.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeArticlesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeArticles.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeArticlesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeArticlesCombinedTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeArticlesCombined.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeArticlesCombinedTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgeBillNumberSeriesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgeBillNumberSeries.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgeBillNumberSeriesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterest.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tBLIMAGETableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.TBLIMAGE.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tBLIMAGETableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblhistoryReminderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblhistoryReminder.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblhistoryReminderTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblHistoryTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblHistory.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblHistoryTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticles.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesDescriptionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesDescription.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesDescriptionTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblAutoDeleteRokadTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblAutoDeleteRokad.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblAutoDeleteRokadTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBackUpTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBackUp.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBackUpTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankMaster.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankMasterTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankPledgeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankPledge.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankPledgeTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBankPledgePledgeBillsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBankPledgePledgeBills.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBankPledgePledgeBillsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBillerTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBiller.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBillerTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblColoursTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblColours.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblColoursTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblCompanyDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblCompanyDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblCompanyDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblCustomersTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblCustomers.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblCustomersTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblDatesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblDates.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblDatesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblExceptionsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblExceptions.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblExceptionsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblGramRateTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblGramRate.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblGramRateTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPledgePrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPledgePrintSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPledgePrintSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRedemptionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRedemption.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRedemptionTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors7TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors7.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors7TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOpeningStockTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOpeningStock.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOpeningStockTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPurityMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPurityMaster.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPurityMasterTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors2TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors2.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors2TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblArticlesJewelleryTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblArticlesJewellery.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblArticlesJewelleryTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBoxTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBox.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBoxTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblDenominationTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblDenomination.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblDenominationTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblFinancialYearsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblFinancialYears.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblFinancialYearsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblOldPurchaseTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblOldPurchase.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblOldPurchaseTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPaymentsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPayments.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPaymentsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRedemptionPrintSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRedemptionPrintSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRedemptionPrintSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSalesDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSalesDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSalesDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblStockTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblStock.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblStockTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors3TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors3.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors3TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors4TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors4.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors4TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors5TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors5.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors5TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblBillNumberSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblBillNumberSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblBillNumberSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors6TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors6.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors6TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblMetalMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblMetalMaster.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblMetalMasterTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblLicenseDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblLicenseDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblLicenseDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblInterestCalculationSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblInterestCalculationSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblInterestCalculationSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSalesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSales.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSalesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblReminderTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblReminder.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblReminderTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRokadDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRokadDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRokadDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSentSmsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSentSms.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSentSmsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblSettingsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblSettings.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblSettingsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblShopDetailsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblShopDetails.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblShopDetailsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tbltable1TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tbltable1.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tbltable1TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblUdhrathTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblUdhrath.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblUdhrathTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVersionTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVersion.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVersionTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVoucherMasterTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVoucherMaster.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVoucherMasterTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblVouchersTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblVouchers.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblVouchersTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblRateTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblRate.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblRateTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblItemNamesTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblItemNames.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblItemNamesTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_Errors1TableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors1.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_Errors1TableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblItemTypeTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblItemType.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblItemTypeTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._tblPurchaseTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.tblPurchase.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._tblPurchaseTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      if (this._paste_ErrorsTableAdapter != null)
      {
        DataRow[] dataRowArray = dataSet.Paste_Errors.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRowArray != null && dataRowArray.Length != 0)
        {
          num += this._paste_ErrorsTableAdapter.Update(dataRowArray);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRowArray);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
    {
      if (updatedRows == null || updatedRows.Length < 1 || allAddedRows == null || allAddedRows.Count < 1)
        return updatedRows;
      List<DataRow> dataRowList = new List<DataRow>();
      for (int index = 0; index < updatedRows.Length; ++index)
      {
        DataRow updatedRow = updatedRows[index];
        if (!allAddedRows.Contains(updatedRow))
          dataRowList.Add(updatedRow);
      }
      return dataRowList.ToArray();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public virtual int UpdateAll(pawnmanagementDataSet1 dataSet)
    {
      if (dataSet == null)
        throw new ArgumentNullException(nameof (dataSet));
      if (!dataSet.HasChanges())
        return 0;
      if (this._paste_ErrorsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_ErrorsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblArticlesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblArticlesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblArticlesDescriptionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblArticlesDescriptionTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblArticlesSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblArticlesSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblAutoDeleteRokadTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblAutoDeleteRokadTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBackUpTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBackUpTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBankMasterTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBankMasterTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBankPledgeTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBankPledgeTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBankPledgePledgeBillsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBankPledgePledgeBillsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBillerTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBillerTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblColoursTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblColoursTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblCompanyDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCompanyDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblCustomersTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCustomersTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblDatesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDatesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblExceptionsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblExceptionsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblGramRateTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblGramRateTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblHistoryTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblHistoryTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblhistoryReminderTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblhistoryReminderTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tBLIMAGETableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tBLIMAGETableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblInterestTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInterestTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblInterestDummyTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInterestDummyTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblInterestReceivedTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInterestReceivedTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblInterestSettingTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInterestSettingTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblKhaathoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblKhaathoTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblLedgerrTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblLedgerrTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblLoginTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblLoginTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblMemberTypeTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMemberTypeTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblMenuSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMenuSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblMessageTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMessageTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblmonitorTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblmonitorTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblOrderTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrderTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPincodeTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPincodeTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPledgeTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPledgeTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPledgeArticlesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPledgeArticlesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPledgeArticlesCombinedTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPledgeArticlesCombinedTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPledgeBillNumberSeriesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPledgeBillNumberSeriesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPledgePrintSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPledgePrintSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPrintSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPrintSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblRedemptionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRedemptionTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblRedemptionPrintSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRedemptionPrintSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblReminderTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblReminderTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblRokadDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRokadDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblSentSmsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSentSmsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblShopDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblShopDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tbltable1TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tbltable1TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblUdhrathTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblUdhrathTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblVersionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVersionTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblVoucherMasterTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVoucherMasterTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblVouchersTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVouchersTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblRateTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRateTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblItemNamesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblItemNamesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors1TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors1TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblItemTypeTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblItemTypeTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPurchaseTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPurchaseTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblSalesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSalesTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblInterestCalculationSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInterestCalculationSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblLicenseDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblLicenseDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblMetalMasterTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMetalMasterTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPurityMasterTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPurityMasterTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors2TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors2TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblArticlesJewelleryTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblArticlesJewelleryTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBoxTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBoxTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblDenominationTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDenominationTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblFinancialYearsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFinancialYearsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblOldPurchaseTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOldPurchaseTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblOpeningStockTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOpeningStockTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblPaymentsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPaymentsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblSalesDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSalesDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblStockTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblStockTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors3TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors3TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors4TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors4TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors5TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors5TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBillNumberSettingsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBillNumberSettingsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors6TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors6TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._paste_Errors7TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._paste_Errors7TableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      if (this._tblBankDetailsTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBankDetailsTableAdapter.Connection))
        throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
      IDbConnection connection = this.Connection;
      if (connection == null)
        throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
      bool flag = false;
      if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
        connection.Close();
      if (connection.State == ConnectionState.Closed)
      {
        connection.Open();
        flag = true;
      }
      IDbTransaction dbTransaction = connection.BeginTransaction();
      if (dbTransaction == null)
        throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
      List<DataRow> allChangedRows = new List<DataRow>();
      List<DataRow> allAddedRows = new List<DataRow>();
      List<DataAdapter> dataAdapterList = new List<DataAdapter>();
      Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
      int num = 0;
      DataSet dataSet1 = (DataSet) null;
      if (this.BackupDataSetBeforeUpdate)
      {
        dataSet1 = new DataSet();
        dataSet1.Merge((DataSet) dataSet);
      }
      try
      {
        if (this._paste_ErrorsTableAdapter != null)
        {
          dictionary.Add((object) this._paste_ErrorsTableAdapter, (IDbConnection) this._paste_ErrorsTableAdapter.Connection);
          this._paste_ErrorsTableAdapter.Connection = (OleDbConnection) connection;
          this._paste_ErrorsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_ErrorsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_ErrorsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_ErrorsTableAdapter.Adapter);
          }
        }
        if (this._tblArticlesTableAdapter != null)
        {
          dictionary.Add((object) this._tblArticlesTableAdapter, (IDbConnection) this._tblArticlesTableAdapter.Connection);
          this._tblArticlesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblArticlesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblArticlesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblArticlesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblArticlesTableAdapter.Adapter);
          }
        }
        if (this._tblArticlesDescriptionTableAdapter != null)
        {
          dictionary.Add((object) this._tblArticlesDescriptionTableAdapter, (IDbConnection) this._tblArticlesDescriptionTableAdapter.Connection);
          this._tblArticlesDescriptionTableAdapter.Connection = (OleDbConnection) connection;
          this._tblArticlesDescriptionTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblArticlesDescriptionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblArticlesDescriptionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblArticlesDescriptionTableAdapter.Adapter);
          }
        }
        if (this._tblArticlesSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblArticlesSettingsTableAdapter, (IDbConnection) this._tblArticlesSettingsTableAdapter.Connection);
          this._tblArticlesSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblArticlesSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblArticlesSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblArticlesSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblArticlesSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblAutoDeleteRokadTableAdapter != null)
        {
          dictionary.Add((object) this._tblAutoDeleteRokadTableAdapter, (IDbConnection) this._tblAutoDeleteRokadTableAdapter.Connection);
          this._tblAutoDeleteRokadTableAdapter.Connection = (OleDbConnection) connection;
          this._tblAutoDeleteRokadTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblAutoDeleteRokadTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblAutoDeleteRokadTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblAutoDeleteRokadTableAdapter.Adapter);
          }
        }
        if (this._tblBackUpTableAdapter != null)
        {
          dictionary.Add((object) this._tblBackUpTableAdapter, (IDbConnection) this._tblBackUpTableAdapter.Connection);
          this._tblBackUpTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBackUpTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBackUpTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBackUpTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBackUpTableAdapter.Adapter);
          }
        }
        if (this._tblBankMasterTableAdapter != null)
        {
          dictionary.Add((object) this._tblBankMasterTableAdapter, (IDbConnection) this._tblBankMasterTableAdapter.Connection);
          this._tblBankMasterTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBankMasterTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBankMasterTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBankMasterTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBankMasterTableAdapter.Adapter);
          }
        }
        if (this._tblBankPledgeTableAdapter != null)
        {
          dictionary.Add((object) this._tblBankPledgeTableAdapter, (IDbConnection) this._tblBankPledgeTableAdapter.Connection);
          this._tblBankPledgeTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBankPledgeTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBankPledgeTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBankPledgeTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBankPledgeTableAdapter.Adapter);
          }
        }
        if (this._tblBankPledgePledgeBillsTableAdapter != null)
        {
          dictionary.Add((object) this._tblBankPledgePledgeBillsTableAdapter, (IDbConnection) this._tblBankPledgePledgeBillsTableAdapter.Connection);
          this._tblBankPledgePledgeBillsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBankPledgePledgeBillsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBankPledgePledgeBillsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBankPledgePledgeBillsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBankPledgePledgeBillsTableAdapter.Adapter);
          }
        }
        if (this._tblBillerTableAdapter != null)
        {
          dictionary.Add((object) this._tblBillerTableAdapter, (IDbConnection) this._tblBillerTableAdapter.Connection);
          this._tblBillerTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBillerTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBillerTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBillerTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBillerTableAdapter.Adapter);
          }
        }
        if (this._tblColoursTableAdapter != null)
        {
          dictionary.Add((object) this._tblColoursTableAdapter, (IDbConnection) this._tblColoursTableAdapter.Connection);
          this._tblColoursTableAdapter.Connection = (OleDbConnection) connection;
          this._tblColoursTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblColoursTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblColoursTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblColoursTableAdapter.Adapter);
          }
        }
        if (this._tblCompanyDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblCompanyDetailsTableAdapter, (IDbConnection) this._tblCompanyDetailsTableAdapter.Connection);
          this._tblCompanyDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblCompanyDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblCompanyDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCompanyDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCompanyDetailsTableAdapter.Adapter);
          }
        }
        if (this._tblCustomersTableAdapter != null)
        {
          dictionary.Add((object) this._tblCustomersTableAdapter, (IDbConnection) this._tblCustomersTableAdapter.Connection);
          this._tblCustomersTableAdapter.Connection = (OleDbConnection) connection;
          this._tblCustomersTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblCustomersTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCustomersTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCustomersTableAdapter.Adapter);
          }
        }
        if (this._tblDatesTableAdapter != null)
        {
          dictionary.Add((object) this._tblDatesTableAdapter, (IDbConnection) this._tblDatesTableAdapter.Connection);
          this._tblDatesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblDatesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblDatesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDatesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDatesTableAdapter.Adapter);
          }
        }
        if (this._tblExceptionsTableAdapter != null)
        {
          dictionary.Add((object) this._tblExceptionsTableAdapter, (IDbConnection) this._tblExceptionsTableAdapter.Connection);
          this._tblExceptionsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblExceptionsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblExceptionsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblExceptionsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblExceptionsTableAdapter.Adapter);
          }
        }
        if (this._tblGramRateTableAdapter != null)
        {
          dictionary.Add((object) this._tblGramRateTableAdapter, (IDbConnection) this._tblGramRateTableAdapter.Connection);
          this._tblGramRateTableAdapter.Connection = (OleDbConnection) connection;
          this._tblGramRateTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblGramRateTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblGramRateTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblGramRateTableAdapter.Adapter);
          }
        }
        if (this._tblHistoryTableAdapter != null)
        {
          dictionary.Add((object) this._tblHistoryTableAdapter, (IDbConnection) this._tblHistoryTableAdapter.Connection);
          this._tblHistoryTableAdapter.Connection = (OleDbConnection) connection;
          this._tblHistoryTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblHistoryTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblHistoryTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblHistoryTableAdapter.Adapter);
          }
        }
        if (this._tblhistoryReminderTableAdapter != null)
        {
          dictionary.Add((object) this._tblhistoryReminderTableAdapter, (IDbConnection) this._tblhistoryReminderTableAdapter.Connection);
          this._tblhistoryReminderTableAdapter.Connection = (OleDbConnection) connection;
          this._tblhistoryReminderTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblhistoryReminderTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblhistoryReminderTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblhistoryReminderTableAdapter.Adapter);
          }
        }
        if (this._tBLIMAGETableAdapter != null)
        {
          dictionary.Add((object) this._tBLIMAGETableAdapter, (IDbConnection) this._tBLIMAGETableAdapter.Connection);
          this._tBLIMAGETableAdapter.Connection = (OleDbConnection) connection;
          this._tBLIMAGETableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tBLIMAGETableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tBLIMAGETableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tBLIMAGETableAdapter.Adapter);
          }
        }
        if (this._tblInterestTableAdapter != null)
        {
          dictionary.Add((object) this._tblInterestTableAdapter, (IDbConnection) this._tblInterestTableAdapter.Connection);
          this._tblInterestTableAdapter.Connection = (OleDbConnection) connection;
          this._tblInterestTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblInterestTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInterestTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInterestTableAdapter.Adapter);
          }
        }
        if (this._tblInterestDummyTableAdapter != null)
        {
          dictionary.Add((object) this._tblInterestDummyTableAdapter, (IDbConnection) this._tblInterestDummyTableAdapter.Connection);
          this._tblInterestDummyTableAdapter.Connection = (OleDbConnection) connection;
          this._tblInterestDummyTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblInterestDummyTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInterestDummyTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInterestDummyTableAdapter.Adapter);
          }
        }
        if (this._tblInterestReceivedTableAdapter != null)
        {
          dictionary.Add((object) this._tblInterestReceivedTableAdapter, (IDbConnection) this._tblInterestReceivedTableAdapter.Connection);
          this._tblInterestReceivedTableAdapter.Connection = (OleDbConnection) connection;
          this._tblInterestReceivedTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblInterestReceivedTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInterestReceivedTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInterestReceivedTableAdapter.Adapter);
          }
        }
        if (this._tblInterestSettingTableAdapter != null)
        {
          dictionary.Add((object) this._tblInterestSettingTableAdapter, (IDbConnection) this._tblInterestSettingTableAdapter.Connection);
          this._tblInterestSettingTableAdapter.Connection = (OleDbConnection) connection;
          this._tblInterestSettingTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblInterestSettingTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInterestSettingTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInterestSettingTableAdapter.Adapter);
          }
        }
        if (this._tblKhaathoTableAdapter != null)
        {
          dictionary.Add((object) this._tblKhaathoTableAdapter, (IDbConnection) this._tblKhaathoTableAdapter.Connection);
          this._tblKhaathoTableAdapter.Connection = (OleDbConnection) connection;
          this._tblKhaathoTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblKhaathoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblKhaathoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblKhaathoTableAdapter.Adapter);
          }
        }
        if (this._tblLedgerrTableAdapter != null)
        {
          dictionary.Add((object) this._tblLedgerrTableAdapter, (IDbConnection) this._tblLedgerrTableAdapter.Connection);
          this._tblLedgerrTableAdapter.Connection = (OleDbConnection) connection;
          this._tblLedgerrTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblLedgerrTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblLedgerrTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblLedgerrTableAdapter.Adapter);
          }
        }
        if (this._tblLoginTableAdapter != null)
        {
          dictionary.Add((object) this._tblLoginTableAdapter, (IDbConnection) this._tblLoginTableAdapter.Connection);
          this._tblLoginTableAdapter.Connection = (OleDbConnection) connection;
          this._tblLoginTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblLoginTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblLoginTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblLoginTableAdapter.Adapter);
          }
        }
        if (this._tblMemberTypeTableAdapter != null)
        {
          dictionary.Add((object) this._tblMemberTypeTableAdapter, (IDbConnection) this._tblMemberTypeTableAdapter.Connection);
          this._tblMemberTypeTableAdapter.Connection = (OleDbConnection) connection;
          this._tblMemberTypeTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblMemberTypeTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMemberTypeTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMemberTypeTableAdapter.Adapter);
          }
        }
        if (this._tblMenuSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblMenuSettingsTableAdapter, (IDbConnection) this._tblMenuSettingsTableAdapter.Connection);
          this._tblMenuSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblMenuSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblMenuSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMenuSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMenuSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblMessageTableAdapter != null)
        {
          dictionary.Add((object) this._tblMessageTableAdapter, (IDbConnection) this._tblMessageTableAdapter.Connection);
          this._tblMessageTableAdapter.Connection = (OleDbConnection) connection;
          this._tblMessageTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblMessageTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMessageTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMessageTableAdapter.Adapter);
          }
        }
        if (this._tblmonitorTableAdapter != null)
        {
          dictionary.Add((object) this._tblmonitorTableAdapter, (IDbConnection) this._tblmonitorTableAdapter.Connection);
          this._tblmonitorTableAdapter.Connection = (OleDbConnection) connection;
          this._tblmonitorTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblmonitorTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblmonitorTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblmonitorTableAdapter.Adapter);
          }
        }
        if (this._tblOrderTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrderTableAdapter, (IDbConnection) this._tblOrderTableAdapter.Connection);
          this._tblOrderTableAdapter.Connection = (OleDbConnection) connection;
          this._tblOrderTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblOrderTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrderTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrderTableAdapter.Adapter);
          }
        }
        if (this._tblPincodeTableAdapter != null)
        {
          dictionary.Add((object) this._tblPincodeTableAdapter, (IDbConnection) this._tblPincodeTableAdapter.Connection);
          this._tblPincodeTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPincodeTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPincodeTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPincodeTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPincodeTableAdapter.Adapter);
          }
        }
        if (this._tblPledgeTableAdapter != null)
        {
          dictionary.Add((object) this._tblPledgeTableAdapter, (IDbConnection) this._tblPledgeTableAdapter.Connection);
          this._tblPledgeTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPledgeTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPledgeTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPledgeTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPledgeTableAdapter.Adapter);
          }
        }
        if (this._tblPledgeArticlesTableAdapter != null)
        {
          dictionary.Add((object) this._tblPledgeArticlesTableAdapter, (IDbConnection) this._tblPledgeArticlesTableAdapter.Connection);
          this._tblPledgeArticlesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPledgeArticlesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPledgeArticlesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPledgeArticlesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPledgeArticlesTableAdapter.Adapter);
          }
        }
        if (this._tblPledgeArticlesCombinedTableAdapter != null)
        {
          dictionary.Add((object) this._tblPledgeArticlesCombinedTableAdapter, (IDbConnection) this._tblPledgeArticlesCombinedTableAdapter.Connection);
          this._tblPledgeArticlesCombinedTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPledgeArticlesCombinedTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPledgeArticlesCombinedTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPledgeArticlesCombinedTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPledgeArticlesCombinedTableAdapter.Adapter);
          }
        }
        if (this._tblPledgeBillNumberSeriesTableAdapter != null)
        {
          dictionary.Add((object) this._tblPledgeBillNumberSeriesTableAdapter, (IDbConnection) this._tblPledgeBillNumberSeriesTableAdapter.Connection);
          this._tblPledgeBillNumberSeriesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPledgeBillNumberSeriesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPledgeBillNumberSeriesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPledgeBillNumberSeriesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPledgeBillNumberSeriesTableAdapter.Adapter);
          }
        }
        if (this._tblPledgePrintSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblPledgePrintSettingsTableAdapter, (IDbConnection) this._tblPledgePrintSettingsTableAdapter.Connection);
          this._tblPledgePrintSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPledgePrintSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPledgePrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPledgePrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPledgePrintSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblPrintSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblPrintSettingsTableAdapter, (IDbConnection) this._tblPrintSettingsTableAdapter.Connection);
          this._tblPrintSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPrintSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPrintSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblRedemptionTableAdapter != null)
        {
          dictionary.Add((object) this._tblRedemptionTableAdapter, (IDbConnection) this._tblRedemptionTableAdapter.Connection);
          this._tblRedemptionTableAdapter.Connection = (OleDbConnection) connection;
          this._tblRedemptionTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblRedemptionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRedemptionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRedemptionTableAdapter.Adapter);
          }
        }
        if (this._tblRedemptionPrintSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblRedemptionPrintSettingsTableAdapter, (IDbConnection) this._tblRedemptionPrintSettingsTableAdapter.Connection);
          this._tblRedemptionPrintSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblRedemptionPrintSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblRedemptionPrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRedemptionPrintSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRedemptionPrintSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblReminderTableAdapter != null)
        {
          dictionary.Add((object) this._tblReminderTableAdapter, (IDbConnection) this._tblReminderTableAdapter.Connection);
          this._tblReminderTableAdapter.Connection = (OleDbConnection) connection;
          this._tblReminderTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblReminderTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblReminderTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblReminderTableAdapter.Adapter);
          }
        }
        if (this._tblRokadDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblRokadDetailsTableAdapter, (IDbConnection) this._tblRokadDetailsTableAdapter.Connection);
          this._tblRokadDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblRokadDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblRokadDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRokadDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRokadDetailsTableAdapter.Adapter);
          }
        }
        if (this._tblSentSmsTableAdapter != null)
        {
          dictionary.Add((object) this._tblSentSmsTableAdapter, (IDbConnection) this._tblSentSmsTableAdapter.Connection);
          this._tblSentSmsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblSentSmsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblSentSmsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSentSmsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSentSmsTableAdapter.Adapter);
          }
        }
        if (this._tblSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblSettingsTableAdapter, (IDbConnection) this._tblSettingsTableAdapter.Connection);
          this._tblSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblShopDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblShopDetailsTableAdapter, (IDbConnection) this._tblShopDetailsTableAdapter.Connection);
          this._tblShopDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblShopDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblShopDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblShopDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblShopDetailsTableAdapter.Adapter);
          }
        }
        if (this._tbltable1TableAdapter != null)
        {
          dictionary.Add((object) this._tbltable1TableAdapter, (IDbConnection) this._tbltable1TableAdapter.Connection);
          this._tbltable1TableAdapter.Connection = (OleDbConnection) connection;
          this._tbltable1TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tbltable1TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tbltable1TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tbltable1TableAdapter.Adapter);
          }
        }
        if (this._tblUdhrathTableAdapter != null)
        {
          dictionary.Add((object) this._tblUdhrathTableAdapter, (IDbConnection) this._tblUdhrathTableAdapter.Connection);
          this._tblUdhrathTableAdapter.Connection = (OleDbConnection) connection;
          this._tblUdhrathTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblUdhrathTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblUdhrathTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblUdhrathTableAdapter.Adapter);
          }
        }
        if (this._tblVersionTableAdapter != null)
        {
          dictionary.Add((object) this._tblVersionTableAdapter, (IDbConnection) this._tblVersionTableAdapter.Connection);
          this._tblVersionTableAdapter.Connection = (OleDbConnection) connection;
          this._tblVersionTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblVersionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVersionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVersionTableAdapter.Adapter);
          }
        }
        if (this._tblVoucherMasterTableAdapter != null)
        {
          dictionary.Add((object) this._tblVoucherMasterTableAdapter, (IDbConnection) this._tblVoucherMasterTableAdapter.Connection);
          this._tblVoucherMasterTableAdapter.Connection = (OleDbConnection) connection;
          this._tblVoucherMasterTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblVoucherMasterTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVoucherMasterTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVoucherMasterTableAdapter.Adapter);
          }
        }
        if (this._tblVouchersTableAdapter != null)
        {
          dictionary.Add((object) this._tblVouchersTableAdapter, (IDbConnection) this._tblVouchersTableAdapter.Connection);
          this._tblVouchersTableAdapter.Connection = (OleDbConnection) connection;
          this._tblVouchersTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblVouchersTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVouchersTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVouchersTableAdapter.Adapter);
          }
        }
        if (this._tblRateTableAdapter != null)
        {
          dictionary.Add((object) this._tblRateTableAdapter, (IDbConnection) this._tblRateTableAdapter.Connection);
          this._tblRateTableAdapter.Connection = (OleDbConnection) connection;
          this._tblRateTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblRateTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRateTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRateTableAdapter.Adapter);
          }
        }
        if (this._tblItemNamesTableAdapter != null)
        {
          dictionary.Add((object) this._tblItemNamesTableAdapter, (IDbConnection) this._tblItemNamesTableAdapter.Connection);
          this._tblItemNamesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblItemNamesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblItemNamesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblItemNamesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblItemNamesTableAdapter.Adapter);
          }
        }
        if (this._paste_Errors1TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors1TableAdapter, (IDbConnection) this._paste_Errors1TableAdapter.Connection);
          this._paste_Errors1TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors1TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors1TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors1TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors1TableAdapter.Adapter);
          }
        }
        if (this._tblItemTypeTableAdapter != null)
        {
          dictionary.Add((object) this._tblItemTypeTableAdapter, (IDbConnection) this._tblItemTypeTableAdapter.Connection);
          this._tblItemTypeTableAdapter.Connection = (OleDbConnection) connection;
          this._tblItemTypeTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblItemTypeTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblItemTypeTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblItemTypeTableAdapter.Adapter);
          }
        }
        if (this._tblPurchaseTableAdapter != null)
        {
          dictionary.Add((object) this._tblPurchaseTableAdapter, (IDbConnection) this._tblPurchaseTableAdapter.Connection);
          this._tblPurchaseTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPurchaseTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPurchaseTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPurchaseTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPurchaseTableAdapter.Adapter);
          }
        }
        if (this._tblSalesTableAdapter != null)
        {
          dictionary.Add((object) this._tblSalesTableAdapter, (IDbConnection) this._tblSalesTableAdapter.Connection);
          this._tblSalesTableAdapter.Connection = (OleDbConnection) connection;
          this._tblSalesTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblSalesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSalesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSalesTableAdapter.Adapter);
          }
        }
        if (this._tblInterestCalculationSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblInterestCalculationSettingsTableAdapter, (IDbConnection) this._tblInterestCalculationSettingsTableAdapter.Connection);
          this._tblInterestCalculationSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblInterestCalculationSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblInterestCalculationSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInterestCalculationSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInterestCalculationSettingsTableAdapter.Adapter);
          }
        }
        if (this._tblLicenseDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblLicenseDetailsTableAdapter, (IDbConnection) this._tblLicenseDetailsTableAdapter.Connection);
          this._tblLicenseDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblLicenseDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblLicenseDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblLicenseDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblLicenseDetailsTableAdapter.Adapter);
          }
        }
        if (this._tblMetalMasterTableAdapter != null)
        {
          dictionary.Add((object) this._tblMetalMasterTableAdapter, (IDbConnection) this._tblMetalMasterTableAdapter.Connection);
          this._tblMetalMasterTableAdapter.Connection = (OleDbConnection) connection;
          this._tblMetalMasterTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblMetalMasterTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMetalMasterTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMetalMasterTableAdapter.Adapter);
          }
        }
        if (this._tblPurityMasterTableAdapter != null)
        {
          dictionary.Add((object) this._tblPurityMasterTableAdapter, (IDbConnection) this._tblPurityMasterTableAdapter.Connection);
          this._tblPurityMasterTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPurityMasterTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPurityMasterTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPurityMasterTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPurityMasterTableAdapter.Adapter);
          }
        }
        if (this._paste_Errors2TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors2TableAdapter, (IDbConnection) this._paste_Errors2TableAdapter.Connection);
          this._paste_Errors2TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors2TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors2TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors2TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors2TableAdapter.Adapter);
          }
        }
        if (this._tblArticlesJewelleryTableAdapter != null)
        {
          dictionary.Add((object) this._tblArticlesJewelleryTableAdapter, (IDbConnection) this._tblArticlesJewelleryTableAdapter.Connection);
          this._tblArticlesJewelleryTableAdapter.Connection = (OleDbConnection) connection;
          this._tblArticlesJewelleryTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblArticlesJewelleryTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblArticlesJewelleryTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblArticlesJewelleryTableAdapter.Adapter);
          }
        }
        if (this._tblBoxTableAdapter != null)
        {
          dictionary.Add((object) this._tblBoxTableAdapter, (IDbConnection) this._tblBoxTableAdapter.Connection);
          this._tblBoxTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBoxTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBoxTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBoxTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBoxTableAdapter.Adapter);
          }
        }
        if (this._tblDenominationTableAdapter != null)
        {
          dictionary.Add((object) this._tblDenominationTableAdapter, (IDbConnection) this._tblDenominationTableAdapter.Connection);
          this._tblDenominationTableAdapter.Connection = (OleDbConnection) connection;
          this._tblDenominationTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblDenominationTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDenominationTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDenominationTableAdapter.Adapter);
          }
        }
        if (this._tblFinancialYearsTableAdapter != null)
        {
          dictionary.Add((object) this._tblFinancialYearsTableAdapter, (IDbConnection) this._tblFinancialYearsTableAdapter.Connection);
          this._tblFinancialYearsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblFinancialYearsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblFinancialYearsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFinancialYearsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFinancialYearsTableAdapter.Adapter);
          }
        }
        if (this._tblOldPurchaseTableAdapter != null)
        {
          dictionary.Add((object) this._tblOldPurchaseTableAdapter, (IDbConnection) this._tblOldPurchaseTableAdapter.Connection);
          this._tblOldPurchaseTableAdapter.Connection = (OleDbConnection) connection;
          this._tblOldPurchaseTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblOldPurchaseTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOldPurchaseTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOldPurchaseTableAdapter.Adapter);
          }
        }
        if (this._tblOpeningStockTableAdapter != null)
        {
          dictionary.Add((object) this._tblOpeningStockTableAdapter, (IDbConnection) this._tblOpeningStockTableAdapter.Connection);
          this._tblOpeningStockTableAdapter.Connection = (OleDbConnection) connection;
          this._tblOpeningStockTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblOpeningStockTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOpeningStockTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOpeningStockTableAdapter.Adapter);
          }
        }
        if (this._tblPaymentsTableAdapter != null)
        {
          dictionary.Add((object) this._tblPaymentsTableAdapter, (IDbConnection) this._tblPaymentsTableAdapter.Connection);
          this._tblPaymentsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblPaymentsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblPaymentsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPaymentsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPaymentsTableAdapter.Adapter);
          }
        }
        if (this._tblSalesDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblSalesDetailsTableAdapter, (IDbConnection) this._tblSalesDetailsTableAdapter.Connection);
          this._tblSalesDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblSalesDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblSalesDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSalesDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSalesDetailsTableAdapter.Adapter);
          }
        }
        if (this._tblStockTableAdapter != null)
        {
          dictionary.Add((object) this._tblStockTableAdapter, (IDbConnection) this._tblStockTableAdapter.Connection);
          this._tblStockTableAdapter.Connection = (OleDbConnection) connection;
          this._tblStockTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblStockTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblStockTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblStockTableAdapter.Adapter);
          }
        }
        if (this._paste_Errors3TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors3TableAdapter, (IDbConnection) this._paste_Errors3TableAdapter.Connection);
          this._paste_Errors3TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors3TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors3TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors3TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors3TableAdapter.Adapter);
          }
        }
        if (this._paste_Errors4TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors4TableAdapter, (IDbConnection) this._paste_Errors4TableAdapter.Connection);
          this._paste_Errors4TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors4TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors4TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors4TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors4TableAdapter.Adapter);
          }
        }
        if (this._paste_Errors5TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors5TableAdapter, (IDbConnection) this._paste_Errors5TableAdapter.Connection);
          this._paste_Errors5TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors5TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors5TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors5TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors5TableAdapter.Adapter);
          }
        }
        if (this._tblBillNumberSettingsTableAdapter != null)
        {
          dictionary.Add((object) this._tblBillNumberSettingsTableAdapter, (IDbConnection) this._tblBillNumberSettingsTableAdapter.Connection);
          this._tblBillNumberSettingsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBillNumberSettingsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBillNumberSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBillNumberSettingsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBillNumberSettingsTableAdapter.Adapter);
          }
        }
        if (this._paste_Errors6TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors6TableAdapter, (IDbConnection) this._paste_Errors6TableAdapter.Connection);
          this._paste_Errors6TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors6TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors6TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors6TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors6TableAdapter.Adapter);
          }
        }
        if (this._paste_Errors7TableAdapter != null)
        {
          dictionary.Add((object) this._paste_Errors7TableAdapter, (IDbConnection) this._paste_Errors7TableAdapter.Connection);
          this._paste_Errors7TableAdapter.Connection = (OleDbConnection) connection;
          this._paste_Errors7TableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._paste_Errors7TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._paste_Errors7TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._paste_Errors7TableAdapter.Adapter);
          }
        }
        if (this._tblBankDetailsTableAdapter != null)
        {
          dictionary.Add((object) this._tblBankDetailsTableAdapter, (IDbConnection) this._tblBankDetailsTableAdapter.Connection);
          this._tblBankDetailsTableAdapter.Connection = (OleDbConnection) connection;
          this._tblBankDetailsTableAdapter.Transaction = (OleDbTransaction) dbTransaction;
          if (this._tblBankDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBankDetailsTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBankDetailsTableAdapter.Adapter);
          }
        }
        if (this.UpdateOrder == TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
        {
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
        }
        else
        {
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
        }
        num += this.UpdateDeletedRows(dataSet, allChangedRows);
        dbTransaction.Commit();
        if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
        if (0 < allChangedRows.Count)
        {
          DataRow[] array = new DataRow[allChangedRows.Count];
          allChangedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
      }
      catch (Exception ex)
      {
        dbTransaction.Rollback();
        if (this.BackupDataSetBeforeUpdate)
        {
          dataSet.Clear();
          dataSet.Merge(dataSet1);
        }
        else if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
          {
            DataRow dataRow = array[index];
            dataRow.AcceptChanges();
            dataRow.SetAdded();
          }
        }
        throw ex;
      }
      finally
      {
        if (flag)
          connection.Close();
        if (this._paste_ErrorsTableAdapter != null)
        {
          this._paste_ErrorsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_ErrorsTableAdapter];
          this._paste_ErrorsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblArticlesTableAdapter != null)
        {
          this._tblArticlesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblArticlesTableAdapter];
          this._tblArticlesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblArticlesDescriptionTableAdapter != null)
        {
          this._tblArticlesDescriptionTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblArticlesDescriptionTableAdapter];
          this._tblArticlesDescriptionTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblArticlesSettingsTableAdapter != null)
        {
          this._tblArticlesSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblArticlesSettingsTableAdapter];
          this._tblArticlesSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblAutoDeleteRokadTableAdapter != null)
        {
          this._tblAutoDeleteRokadTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblAutoDeleteRokadTableAdapter];
          this._tblAutoDeleteRokadTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBackUpTableAdapter != null)
        {
          this._tblBackUpTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBackUpTableAdapter];
          this._tblBackUpTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBankMasterTableAdapter != null)
        {
          this._tblBankMasterTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBankMasterTableAdapter];
          this._tblBankMasterTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBankPledgeTableAdapter != null)
        {
          this._tblBankPledgeTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBankPledgeTableAdapter];
          this._tblBankPledgeTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBankPledgePledgeBillsTableAdapter != null)
        {
          this._tblBankPledgePledgeBillsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBankPledgePledgeBillsTableAdapter];
          this._tblBankPledgePledgeBillsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBillerTableAdapter != null)
        {
          this._tblBillerTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBillerTableAdapter];
          this._tblBillerTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblColoursTableAdapter != null)
        {
          this._tblColoursTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblColoursTableAdapter];
          this._tblColoursTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblCompanyDetailsTableAdapter != null)
        {
          this._tblCompanyDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblCompanyDetailsTableAdapter];
          this._tblCompanyDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblCustomersTableAdapter != null)
        {
          this._tblCustomersTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblCustomersTableAdapter];
          this._tblCustomersTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblDatesTableAdapter != null)
        {
          this._tblDatesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblDatesTableAdapter];
          this._tblDatesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblExceptionsTableAdapter != null)
        {
          this._tblExceptionsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblExceptionsTableAdapter];
          this._tblExceptionsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblGramRateTableAdapter != null)
        {
          this._tblGramRateTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblGramRateTableAdapter];
          this._tblGramRateTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblHistoryTableAdapter != null)
        {
          this._tblHistoryTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblHistoryTableAdapter];
          this._tblHistoryTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblhistoryReminderTableAdapter != null)
        {
          this._tblhistoryReminderTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblhistoryReminderTableAdapter];
          this._tblhistoryReminderTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tBLIMAGETableAdapter != null)
        {
          this._tBLIMAGETableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tBLIMAGETableAdapter];
          this._tBLIMAGETableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblInterestTableAdapter != null)
        {
          this._tblInterestTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblInterestTableAdapter];
          this._tblInterestTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblInterestDummyTableAdapter != null)
        {
          this._tblInterestDummyTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblInterestDummyTableAdapter];
          this._tblInterestDummyTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblInterestReceivedTableAdapter != null)
        {
          this._tblInterestReceivedTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblInterestReceivedTableAdapter];
          this._tblInterestReceivedTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblInterestSettingTableAdapter != null)
        {
          this._tblInterestSettingTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblInterestSettingTableAdapter];
          this._tblInterestSettingTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblKhaathoTableAdapter != null)
        {
          this._tblKhaathoTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblKhaathoTableAdapter];
          this._tblKhaathoTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblLedgerrTableAdapter != null)
        {
          this._tblLedgerrTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblLedgerrTableAdapter];
          this._tblLedgerrTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblLoginTableAdapter != null)
        {
          this._tblLoginTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblLoginTableAdapter];
          this._tblLoginTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblMemberTypeTableAdapter != null)
        {
          this._tblMemberTypeTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblMemberTypeTableAdapter];
          this._tblMemberTypeTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblMenuSettingsTableAdapter != null)
        {
          this._tblMenuSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblMenuSettingsTableAdapter];
          this._tblMenuSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblMessageTableAdapter != null)
        {
          this._tblMessageTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblMessageTableAdapter];
          this._tblMessageTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblmonitorTableAdapter != null)
        {
          this._tblmonitorTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblmonitorTableAdapter];
          this._tblmonitorTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblOrderTableAdapter != null)
        {
          this._tblOrderTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblOrderTableAdapter];
          this._tblOrderTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPincodeTableAdapter != null)
        {
          this._tblPincodeTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPincodeTableAdapter];
          this._tblPincodeTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPledgeTableAdapter != null)
        {
          this._tblPledgeTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPledgeTableAdapter];
          this._tblPledgeTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPledgeArticlesTableAdapter != null)
        {
          this._tblPledgeArticlesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPledgeArticlesTableAdapter];
          this._tblPledgeArticlesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPledgeArticlesCombinedTableAdapter != null)
        {
          this._tblPledgeArticlesCombinedTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPledgeArticlesCombinedTableAdapter];
          this._tblPledgeArticlesCombinedTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPledgeBillNumberSeriesTableAdapter != null)
        {
          this._tblPledgeBillNumberSeriesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPledgeBillNumberSeriesTableAdapter];
          this._tblPledgeBillNumberSeriesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPledgePrintSettingsTableAdapter != null)
        {
          this._tblPledgePrintSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPledgePrintSettingsTableAdapter];
          this._tblPledgePrintSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPrintSettingsTableAdapter != null)
        {
          this._tblPrintSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPrintSettingsTableAdapter];
          this._tblPrintSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblRedemptionTableAdapter != null)
        {
          this._tblRedemptionTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblRedemptionTableAdapter];
          this._tblRedemptionTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblRedemptionPrintSettingsTableAdapter != null)
        {
          this._tblRedemptionPrintSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblRedemptionPrintSettingsTableAdapter];
          this._tblRedemptionPrintSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblReminderTableAdapter != null)
        {
          this._tblReminderTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblReminderTableAdapter];
          this._tblReminderTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblRokadDetailsTableAdapter != null)
        {
          this._tblRokadDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblRokadDetailsTableAdapter];
          this._tblRokadDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblSentSmsTableAdapter != null)
        {
          this._tblSentSmsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblSentSmsTableAdapter];
          this._tblSentSmsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblSettingsTableAdapter != null)
        {
          this._tblSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblSettingsTableAdapter];
          this._tblSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblShopDetailsTableAdapter != null)
        {
          this._tblShopDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblShopDetailsTableAdapter];
          this._tblShopDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tbltable1TableAdapter != null)
        {
          this._tbltable1TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tbltable1TableAdapter];
          this._tbltable1TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblUdhrathTableAdapter != null)
        {
          this._tblUdhrathTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblUdhrathTableAdapter];
          this._tblUdhrathTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblVersionTableAdapter != null)
        {
          this._tblVersionTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblVersionTableAdapter];
          this._tblVersionTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblVoucherMasterTableAdapter != null)
        {
          this._tblVoucherMasterTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblVoucherMasterTableAdapter];
          this._tblVoucherMasterTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblVouchersTableAdapter != null)
        {
          this._tblVouchersTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblVouchersTableAdapter];
          this._tblVouchersTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblRateTableAdapter != null)
        {
          this._tblRateTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblRateTableAdapter];
          this._tblRateTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblItemNamesTableAdapter != null)
        {
          this._tblItemNamesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblItemNamesTableAdapter];
          this._tblItemNamesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors1TableAdapter != null)
        {
          this._paste_Errors1TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors1TableAdapter];
          this._paste_Errors1TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblItemTypeTableAdapter != null)
        {
          this._tblItemTypeTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblItemTypeTableAdapter];
          this._tblItemTypeTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPurchaseTableAdapter != null)
        {
          this._tblPurchaseTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPurchaseTableAdapter];
          this._tblPurchaseTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblSalesTableAdapter != null)
        {
          this._tblSalesTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblSalesTableAdapter];
          this._tblSalesTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblInterestCalculationSettingsTableAdapter != null)
        {
          this._tblInterestCalculationSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblInterestCalculationSettingsTableAdapter];
          this._tblInterestCalculationSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblLicenseDetailsTableAdapter != null)
        {
          this._tblLicenseDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblLicenseDetailsTableAdapter];
          this._tblLicenseDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblMetalMasterTableAdapter != null)
        {
          this._tblMetalMasterTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblMetalMasterTableAdapter];
          this._tblMetalMasterTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPurityMasterTableAdapter != null)
        {
          this._tblPurityMasterTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPurityMasterTableAdapter];
          this._tblPurityMasterTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors2TableAdapter != null)
        {
          this._paste_Errors2TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors2TableAdapter];
          this._paste_Errors2TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblArticlesJewelleryTableAdapter != null)
        {
          this._tblArticlesJewelleryTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblArticlesJewelleryTableAdapter];
          this._tblArticlesJewelleryTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBoxTableAdapter != null)
        {
          this._tblBoxTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBoxTableAdapter];
          this._tblBoxTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblDenominationTableAdapter != null)
        {
          this._tblDenominationTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblDenominationTableAdapter];
          this._tblDenominationTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblFinancialYearsTableAdapter != null)
        {
          this._tblFinancialYearsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblFinancialYearsTableAdapter];
          this._tblFinancialYearsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblOldPurchaseTableAdapter != null)
        {
          this._tblOldPurchaseTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblOldPurchaseTableAdapter];
          this._tblOldPurchaseTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblOpeningStockTableAdapter != null)
        {
          this._tblOpeningStockTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblOpeningStockTableAdapter];
          this._tblOpeningStockTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblPaymentsTableAdapter != null)
        {
          this._tblPaymentsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblPaymentsTableAdapter];
          this._tblPaymentsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblSalesDetailsTableAdapter != null)
        {
          this._tblSalesDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblSalesDetailsTableAdapter];
          this._tblSalesDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblStockTableAdapter != null)
        {
          this._tblStockTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblStockTableAdapter];
          this._tblStockTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors3TableAdapter != null)
        {
          this._paste_Errors3TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors3TableAdapter];
          this._paste_Errors3TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors4TableAdapter != null)
        {
          this._paste_Errors4TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors4TableAdapter];
          this._paste_Errors4TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors5TableAdapter != null)
        {
          this._paste_Errors5TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors5TableAdapter];
          this._paste_Errors5TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBillNumberSettingsTableAdapter != null)
        {
          this._tblBillNumberSettingsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBillNumberSettingsTableAdapter];
          this._tblBillNumberSettingsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors6TableAdapter != null)
        {
          this._paste_Errors6TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors6TableAdapter];
          this._paste_Errors6TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._paste_Errors7TableAdapter != null)
        {
          this._paste_Errors7TableAdapter.Connection = (OleDbConnection) dictionary[(object) this._paste_Errors7TableAdapter];
          this._paste_Errors7TableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (this._tblBankDetailsTableAdapter != null)
        {
          this._tblBankDetailsTableAdapter.Connection = (OleDbConnection) dictionary[(object) this._tblBankDetailsTableAdapter];
          this._tblBankDetailsTableAdapter.Transaction = (OleDbTransaction) null;
        }
        if (0 < dataAdapterList.Count)
        {
          DataAdapter[] array = new DataAdapter[dataAdapterList.Count];
          dataAdapterList.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChangesDuringUpdate = true;
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected virtual void SortSelfReferenceRows(
      DataRow[] rows,
      DataRelation relation,
      bool childFirst)
    {
      Array.Sort<DataRow>(rows, (IComparer<DataRow>) new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection) => this._connection != null || this.Connection == null || inputConnection == null || string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public enum UpdateOrderOption
    {
      InsertUpdateDelete,
      UpdateInsertDelete,
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private class SelfReferenceComparer : IComparer<DataRow>
    {
      private DataRelation _relation;
      private int _childFirst;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal SelfReferenceComparer(DataRelation relation, bool childFirst)
      {
        this._relation = relation;
        if (childFirst)
          this._childFirst = -1;
        else
          this._childFirst = 1;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      private DataRow GetRoot(DataRow row, out int distance)
      {
        DataRow root = row;
        distance = 0;
        IDictionary<DataRow, DataRow> dictionary = (IDictionary<DataRow, DataRow>) new Dictionary<DataRow, DataRow>();
        dictionary[row] = row;
        for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Default); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default))
        {
          ++distance;
          root = parentRow;
          dictionary[parentRow] = parentRow;
        }
        if (distance == 0)
        {
          dictionary.Clear();
          dictionary[row] = row;
          for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Original); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original))
          {
            ++distance;
            root = parentRow;
            dictionary[parentRow] = parentRow;
          }
        }
        return root;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int Compare(DataRow row1, DataRow row2)
      {
        if (row1 == row2)
          return 0;
        if (row1 == null)
          return -1;
        if (row2 == null)
          return 1;
        int distance1 = 0;
        DataRow root1 = this.GetRoot(row1, out distance1);
        int distance2 = 0;
        DataRow root2 = this.GetRoot(row2, out distance2);
        if (root1 == root2)
          return this._childFirst * distance1.CompareTo(distance2);
        return root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2) ? -1 : 1;
      }
    }
  }
}
