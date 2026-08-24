

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
  public class tblSettingsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblSettingsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblSettings",
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
            "LoginScreenPictureBoxPath",
            "LoginScreenPictureBoxPath"
          },
          {
            "Lang",
            "Lang"
          },
          {
            "MainScreenPictureBoxPath",
            "MainScreenPictureBoxPath"
          },
          {
            "WithIndividualWeight",
            "WithIndividualWeight"
          },
          {
            "InterestSetting",
            "InterestSetting"
          },
          {
            "ValueAutoAdjustSetting",
            "ValueAutoAdjustSetting"
          },
          {
            "BillNumberSeries",
            "BillNumberSeries"
          },
          {
            "BillDate",
            "BillDate"
          },
          {
            "AdminPassword",
            "AdminPassword"
          },
          {
            "MaintainOldestBillNumber",
            "MaintainOldestBillNumber"
          },
          {
            "ReduceFirstMonthInterest",
            "ReduceFirstMonthInterest"
          },
          {
            "UseFingerPrint",
            "UseFingerPrint"
          },
          {
            "AutoOnFingerPrint",
            "AutoOnFingerPrint"
          },
          {
            "MainFormFullScreen",
            "MainFormFullScreen"
          },
          {
            "PledgeScreenSimple",
            "PledgeScreenSimple"
          },
          {
            "RememberUsernameAndPassword",
            "RememberUsernameAndPassword"
          },
          {
            "RemindIfNameAndAddressSame",
            "RemindIfNameAndAddressSame"
          },
          {
            "RemindIfNameAddressAndDoorNumberSame",
            "RemindIfNameAddressAndDoorNumberSame"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblSettings` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `LoginScreenPictureBoxPath` IS NULL) OR (`LoginScreenPictureBoxPath` = ?)) AND ((? = 1 AND `Lang` IS NULL) OR (`Lang` = ?)) AND ((? = 1 AND `MainScreenPictureBoxPath` IS NULL) OR (`MainScreenPictureBoxPath` = ?)) AND ((? = 1 AND `WithIndividualWeight` IS NULL) OR (`WithIndividualWeight` = ?)) AND ((? = 1 AND `InterestSetting` IS NULL) OR (`InterestSetting` = ?)) AND ((? = 1 AND `ValueAutoAdjustSetting` IS NULL) OR (`ValueAutoAdjustSetting` = ?)) AND ((? = 1 AND `BillNumberSeries` IS NULL) OR (`BillNumberSeries` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `AdminPassword` IS NULL) OR (`AdminPassword` = ?)) AND ((? = 1 AND `MaintainOldestBillNumber` IS NULL) OR (`MaintainOldestBillNumber` = ?)) AND ((? = 1 AND `ReduceFirstMonthInterest` IS NULL) OR (`ReduceFirstMonthInterest` = ?)) AND ((? = 1 AND `UseFingerPrint` IS NULL) OR (`UseFingerPrint` = ?)) AND ((? = 1 AND `AutoOnFingerPrint` IS NULL) OR (`AutoOnFingerPrint` = ?)) AND ((? = 1 AND `MainFormFullScreen` IS NULL) OR (`MainFormFullScreen` = ?)) AND ((? = 1 AND `PledgeScreenSimple` IS NULL) OR (`PledgeScreenSimple` = ?)) AND ((? = 1 AND `RememberUsernameAndPassword` IS NULL) OR (`RememberUsernameAndPassword` = ?)) AND ((? = 1 AND `RemindIfNameAddressAndDoorNumberSame` IS NULL) OR (`RemindIfNameAddressAndDoorNumberSame` = ?)) AND ((? = 1 AND `RemindIfNameAndAddressSame` IS NULL) OR (`RemindIfNameAndAddressSame` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LoginScreenPictureBoxPath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LoginScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Lang", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Lang", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MainScreenPictureBoxPath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MainScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_WithIndividualWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_WithIndividualWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_InterestSetting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_InterestSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ValueAutoAdjustSetting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ValueAutoAdjustSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumberSeries", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillNumberSeries", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AdminPassword", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AdminPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MaintainOldestBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MaintainOldestBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ReduceFirstMonthInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ReduceFirstMonthInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_UseFingerPrint", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_UseFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AutoOnFingerPrint", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AutoOnFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MainFormFullScreen", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MainFormFullScreen", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeScreenSimple", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeScreenSimple", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RememberUsernameAndPassword", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RememberUsernameAndPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RemindIfNameAddressAndDoorNumberSame", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RemindIfNameAddressAndDoorNumberSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RemindIfNameAndAddressSame", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RemindIfNameAndAddressSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblSettings` (`SerialNumber`, `LoginScreenPictureBoxPath`, `Lang`, `MainScreenPictureBoxPath`, `WithIndividualWeight`, `InterestSetting`, `ValueAutoAdjustSetting`, `BillNumberSeries`, `BillDate`, `AdminPassword`, `MaintainOldestBillNumber`, `ReduceFirstMonthInterest`, `UseFingerPrint`, `AutoOnFingerPrint`, `MainFormFullScreen`, `PledgeScreenSimple`, `RememberUsernameAndPassword`, `RemindIfNameAddressAndDoorNumberSame`, `RemindIfNameAndAddressSame`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LoginScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Lang", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MainScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("WithIndividualWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ValueAutoAdjustSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumberSeries", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AdminPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MaintainOldestBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ReduceFirstMonthInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("UseFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AutoOnFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MainFormFullScreen", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeScreenSimple", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RememberUsernameAndPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RemindIfNameAddressAndDoorNumberSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RemindIfNameAndAddressSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblSettings` SET `SerialNumber` = ?, `LoginScreenPictureBoxPath` = ?, `Lang` = ?, `MainScreenPictureBoxPath` = ?, `WithIndividualWeight` = ?, `InterestSetting` = ?, `ValueAutoAdjustSetting` = ?, `BillNumberSeries` = ?, `BillDate` = ?, `AdminPassword` = ?, `MaintainOldestBillNumber` = ?, `ReduceFirstMonthInterest` = ?, `UseFingerPrint` = ?, `AutoOnFingerPrint` = ?, `MainFormFullScreen` = ?, `PledgeScreenSimple` = ?, `RememberUsernameAndPassword` = ?, `RemindIfNameAddressAndDoorNumberSame` = ?, `RemindIfNameAndAddressSame` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `LoginScreenPictureBoxPath` IS NULL) OR (`LoginScreenPictureBoxPath` = ?)) AND ((? = 1 AND `Lang` IS NULL) OR (`Lang` = ?)) AND ((? = 1 AND `MainScreenPictureBoxPath` IS NULL) OR (`MainScreenPictureBoxPath` = ?)) AND ((? = 1 AND `WithIndividualWeight` IS NULL) OR (`WithIndividualWeight` = ?)) AND ((? = 1 AND `InterestSetting` IS NULL) OR (`InterestSetting` = ?)) AND ((? = 1 AND `ValueAutoAdjustSetting` IS NULL) OR (`ValueAutoAdjustSetting` = ?)) AND ((? = 1 AND `BillNumberSeries` IS NULL) OR (`BillNumberSeries` = ?)) AND ((? = 1 AND `BillDate` IS NULL) OR (`BillDate` = ?)) AND ((? = 1 AND `AdminPassword` IS NULL) OR (`AdminPassword` = ?)) AND ((? = 1 AND `MaintainOldestBillNumber` IS NULL) OR (`MaintainOldestBillNumber` = ?)) AND ((? = 1 AND `ReduceFirstMonthInterest` IS NULL) OR (`ReduceFirstMonthInterest` = ?)) AND ((? = 1 AND `UseFingerPrint` IS NULL) OR (`UseFingerPrint` = ?)) AND ((? = 1 AND `AutoOnFingerPrint` IS NULL) OR (`AutoOnFingerPrint` = ?)) AND ((? = 1 AND `MainFormFullScreen` IS NULL) OR (`MainFormFullScreen` = ?)) AND ((? = 1 AND `PledgeScreenSimple` IS NULL) OR (`PledgeScreenSimple` = ?)) AND ((? = 1 AND `RememberUsernameAndPassword` IS NULL) OR (`RememberUsernameAndPassword` = ?)) AND ((? = 1 AND `RemindIfNameAddressAndDoorNumberSame` IS NULL) OR (`RemindIfNameAddressAndDoorNumberSame` = ?)) AND ((? = 1 AND `RemindIfNameAndAddressSame` IS NULL) OR (`RemindIfNameAndAddressSame` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LoginScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Lang", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MainScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("WithIndividualWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("InterestSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ValueAutoAdjustSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillNumberSeries", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AdminPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MaintainOldestBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ReduceFirstMonthInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("UseFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AutoOnFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MainFormFullScreen", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeScreenSimple", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RememberUsernameAndPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RemindIfNameAddressAndDoorNumberSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RemindIfNameAndAddressSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LoginScreenPictureBoxPath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LoginScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LoginScreenPictureBoxPath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Lang", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Lang", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lang", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MainScreenPictureBoxPath", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MainScreenPictureBoxPath", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainScreenPictureBoxPath", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_WithIndividualWeight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_WithIndividualWeight", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WithIndividualWeight", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_InterestSetting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_InterestSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestSetting", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ValueAutoAdjustSetting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ValueAutoAdjustSetting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ValueAutoAdjustSetting", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillNumberSeries", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillNumberSeries", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumberSeries", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BillDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AdminPassword", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AdminPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AdminPassword", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MaintainOldestBillNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MaintainOldestBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaintainOldestBillNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ReduceFirstMonthInterest", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ReduceFirstMonthInterest", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReduceFirstMonthInterest", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_UseFingerPrint", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_UseFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UseFingerPrint", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AutoOnFingerPrint", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AutoOnFingerPrint", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AutoOnFingerPrint", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MainFormFullScreen", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MainFormFullScreen", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MainFormFullScreen", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeScreenSimple", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeScreenSimple", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeScreenSimple", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RememberUsernameAndPassword", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RememberUsernameAndPassword", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RememberUsernameAndPassword", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RemindIfNameAddressAndDoorNumberSame", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RemindIfNameAddressAndDoorNumberSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAddressAndDoorNumberSame", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RemindIfNameAndAddressSame", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RemindIfNameAndAddressSame", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RemindIfNameAndAddressSame", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, LoginScreenPictureBoxPath, Lang, MainScreenPictureBoxPath, WithIndividualWeight, InterestSetting, ValueAutoAdjustSetting, BillNumberSeries, BillDate, AdminPassword, MaintainOldestBillNumber, ReduceFirstMonthInterest, UseFingerPrint, AutoOnFingerPrint, MainFormFullScreen, PledgeScreenSimple, RememberUsernameAndPassword, RemindIfNameAddressAndDoorNumberSame, RemindIfNameAndAddressSame FROM tblSettings";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblSettingsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblSettingsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblSettingsDataTable data = new pawnmanagementDataSet1.tblSettingsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblSettingsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblSettings");

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
      string Original_LoginScreenPictureBoxPath,
      string Original_Lang,
      string Original_MainScreenPictureBoxPath,
      string Original_WithIndividualWeight,
      string Original_InterestSetting,
      string Original_ValueAutoAdjustSetting,
      string Original_BillNumberSeries,
      DateTime? Original_BillDate,
      string Original_AdminPassword,
      string Original_MaintainOldestBillNumber,
      string Original_ReduceFirstMonthInterest,
      string Original_UseFingerPrint,
      string Original_AutoOnFingerPrint,
      string Original_MainFormFullScreen,
      string Original_PledgeScreenSimple,
      string Original_RememberUsernameAndPassword,
      string Original_RemindIfNameAddressAndDoorNumberSame,
      string Original_RemindIfNameAndAddressSame)
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
      if (Original_LoginScreenPictureBoxPath == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_LoginScreenPictureBoxPath;
      }
      if (Original_Lang == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Lang;
      }
      if (Original_MainScreenPictureBoxPath == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_MainScreenPictureBoxPath;
      }
      if (Original_WithIndividualWeight == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_WithIndividualWeight;
      }
      if (Original_InterestSetting == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_InterestSetting;
      }
      if (Original_ValueAutoAdjustSetting == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_ValueAutoAdjustSetting;
      }
      if (Original_BillNumberSeries == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_BillNumberSeries;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_AdminPassword == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_AdminPassword;
      }
      if (Original_MaintainOldestBillNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_MaintainOldestBillNumber;
      }
      if (Original_ReduceFirstMonthInterest == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_ReduceFirstMonthInterest;
      }
      if (Original_UseFingerPrint == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_UseFingerPrint;
      }
      if (Original_AutoOnFingerPrint == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_AutoOnFingerPrint;
      }
      if (Original_MainFormFullScreen == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_MainFormFullScreen;
      }
      if (Original_PledgeScreenSimple == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_PledgeScreenSimple;
      }
      if (Original_RememberUsernameAndPassword == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_RememberUsernameAndPassword;
      }
      if (Original_RemindIfNameAddressAndDoorNumberSame == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_RemindIfNameAddressAndDoorNumberSame;
      }
      if (Original_RemindIfNameAndAddressSame == null)
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[37].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[38].Value = (object) Original_RemindIfNameAndAddressSame;
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
      string LoginScreenPictureBoxPath,
      string Lang,
      string MainScreenPictureBoxPath,
      string WithIndividualWeight,
      string InterestSetting,
      string ValueAutoAdjustSetting,
      string BillNumberSeries,
      DateTime? BillDate,
      string AdminPassword,
      string MaintainOldestBillNumber,
      string ReduceFirstMonthInterest,
      string UseFingerPrint,
      string AutoOnFingerPrint,
      string MainFormFullScreen,
      string PledgeScreenSimple,
      string RememberUsernameAndPassword,
      string RemindIfNameAddressAndDoorNumberSame,
      string RemindIfNameAndAddressSame)
    {
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (LoginScreenPictureBoxPath == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) LoginScreenPictureBoxPath;
      if (Lang == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Lang;
      if (MainScreenPictureBoxPath == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) MainScreenPictureBoxPath;
      if (WithIndividualWeight == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) WithIndividualWeight;
      if (InterestSetting == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) InterestSetting;
      if (ValueAutoAdjustSetting == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) ValueAutoAdjustSetting;
      if (BillNumberSeries == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) BillNumberSeries;
      if (BillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) BillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (AdminPassword == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) AdminPassword;
      if (MaintainOldestBillNumber == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) MaintainOldestBillNumber;
      if (ReduceFirstMonthInterest == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) ReduceFirstMonthInterest;
      if (UseFingerPrint == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) UseFingerPrint;
      if (AutoOnFingerPrint == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) AutoOnFingerPrint;
      if (MainFormFullScreen == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) MainFormFullScreen;
      if (PledgeScreenSimple == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) PledgeScreenSimple;
      if (RememberUsernameAndPassword == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) RememberUsernameAndPassword;
      if (RemindIfNameAddressAndDoorNumberSame == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) RemindIfNameAddressAndDoorNumberSame;
      if (RemindIfNameAndAddressSame == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) RemindIfNameAndAddressSame;
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
      string LoginScreenPictureBoxPath,
      string Lang,
      string MainScreenPictureBoxPath,
      string WithIndividualWeight,
      string InterestSetting,
      string ValueAutoAdjustSetting,
      string BillNumberSeries,
      DateTime? BillDate,
      string AdminPassword,
      string MaintainOldestBillNumber,
      string ReduceFirstMonthInterest,
      string UseFingerPrint,
      string AutoOnFingerPrint,
      string MainFormFullScreen,
      string PledgeScreenSimple,
      string RememberUsernameAndPassword,
      string RemindIfNameAddressAndDoorNumberSame,
      string RemindIfNameAndAddressSame,
      int Original_ID,
      int? Original_SerialNumber,
      string Original_LoginScreenPictureBoxPath,
      string Original_Lang,
      string Original_MainScreenPictureBoxPath,
      string Original_WithIndividualWeight,
      string Original_InterestSetting,
      string Original_ValueAutoAdjustSetting,
      string Original_BillNumberSeries,
      DateTime? Original_BillDate,
      string Original_AdminPassword,
      string Original_MaintainOldestBillNumber,
      string Original_ReduceFirstMonthInterest,
      string Original_UseFingerPrint,
      string Original_AutoOnFingerPrint,
      string Original_MainFormFullScreen,
      string Original_PledgeScreenSimple,
      string Original_RememberUsernameAndPassword,
      string Original_RemindIfNameAddressAndDoorNumberSame,
      string Original_RemindIfNameAndAddressSame)
    {
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (LoginScreenPictureBoxPath == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) LoginScreenPictureBoxPath;
      if (Lang == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Lang;
      if (MainScreenPictureBoxPath == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) MainScreenPictureBoxPath;
      if (WithIndividualWeight == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) WithIndividualWeight;
      if (InterestSetting == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) InterestSetting;
      if (ValueAutoAdjustSetting == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) ValueAutoAdjustSetting;
      if (BillNumberSeries == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) BillNumberSeries;
      if (BillDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) BillDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (AdminPassword == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) AdminPassword;
      if (MaintainOldestBillNumber == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) MaintainOldestBillNumber;
      if (ReduceFirstMonthInterest == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) ReduceFirstMonthInterest;
      if (UseFingerPrint == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) UseFingerPrint;
      if (AutoOnFingerPrint == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) AutoOnFingerPrint;
      if (MainFormFullScreen == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) MainFormFullScreen;
      if (PledgeScreenSimple == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) PledgeScreenSimple;
      if (RememberUsernameAndPassword == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) RememberUsernameAndPassword;
      if (RemindIfNameAddressAndDoorNumberSame == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) RemindIfNameAddressAndDoorNumberSame;
      if (RemindIfNameAndAddressSame == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) RemindIfNameAndAddressSame;
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
      if (Original_LoginScreenPictureBoxPath == null)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_LoginScreenPictureBoxPath;
      }
      if (Original_Lang == null)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_Lang;
      }
      if (Original_MainScreenPictureBoxPath == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_MainScreenPictureBoxPath;
      }
      if (Original_WithIndividualWeight == null)
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_WithIndividualWeight;
      }
      if (Original_InterestSetting == null)
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) Original_InterestSetting;
      }
      if (Original_ValueAutoAdjustSetting == null)
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) Original_ValueAutoAdjustSetting;
      }
      if (Original_BillNumberSeries == null)
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) Original_BillNumberSeries;
      }
      if (Original_BillDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) Original_BillDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) DBNull.Value;
      }
      if (Original_AdminPassword == null)
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) Original_AdminPassword;
      }
      if (Original_MaintainOldestBillNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) Original_MaintainOldestBillNumber;
      }
      if (Original_ReduceFirstMonthInterest == null)
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) Original_ReduceFirstMonthInterest;
      }
      if (Original_UseFingerPrint == null)
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) Original_UseFingerPrint;
      }
      if (Original_AutoOnFingerPrint == null)
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) Original_AutoOnFingerPrint;
      }
      if (Original_MainFormFullScreen == null)
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) Original_MainFormFullScreen;
      }
      if (Original_PledgeScreenSimple == null)
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) Original_PledgeScreenSimple;
      }
      if (Original_RememberUsernameAndPassword == null)
      {
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) Original_RememberUsernameAndPassword;
      }
      if (Original_RemindIfNameAddressAndDoorNumberSame == null)
      {
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[55].Value = (object) Original_RemindIfNameAddressAndDoorNumberSame;
      }
      if (Original_RemindIfNameAndAddressSame == null)
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[56].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[57].Value = (object) Original_RemindIfNameAndAddressSame;
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
