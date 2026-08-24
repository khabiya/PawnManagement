
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
  public class tblRokadDetailsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblRokadDetailsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblRokadDetails",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "RokadDate",
            "RokadDate"
          },
          {
            "OpeningBalance",
            "OpeningBalance"
          },
          {
            "Cash",
            "Cash"
          },
          {
            "JammaSideClosing",
            "JammaSideClosing"
          },
          {
            "NovaeSideClosing",
            "NovaeSideClosing"
          },
          {
            "RokadFinished",
            "RokadFinished"
          },
          {
            "CurrentDay",
            "CurrentDay"
          },
          {
            "RokadFinishedTime",
            "RokadFinishedTime"
          },
          {
            "CreatedOn",
            "CreatedOn"
          },
          {
            "CreatedBy",
            "CreatedBy"
          },
          {
            "CreatedTime",
            "CreatedTime"
          },
          {
            "Active",
            "Active"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblRokadDetails` WHERE ((`ID` = ?) AND ((? = 1 AND `RokadDate` IS NULL) OR (`RokadDate` = ?)) AND ((? = 1 AND `OpeningBalance` IS NULL) OR (`OpeningBalance` = ?)) AND ((? = 1 AND `Cash` IS NULL) OR (`Cash` = ?)) AND ((? = 1 AND `JammaSideClosing` IS NULL) OR (`JammaSideClosing` = ?)) AND ((? = 1 AND `NovaeSideClosing` IS NULL) OR (`NovaeSideClosing` = ?)) AND ((? = 1 AND `RokadFinished` IS NULL) OR (`RokadFinished` = ?)) AND ((? = 1 AND `CurrentDay` IS NULL) OR (`CurrentDay` = ?)) AND ((? = 1 AND `RokadFinishedTime` IS NULL) OR (`RokadFinishedTime` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedTime` IS NULL) OR (`CreatedTime` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RokadDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RokadDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_OpeningBalance", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_OpeningBalance", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Cash", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Cash", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_JammaSideClosing", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_JammaSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NovaeSideClosing", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NovaeSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RokadFinished", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RokadFinished", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CurrentDay", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CurrentDay", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_RokadFinishedTime", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_RokadFinishedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedTime", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblRokadDetails` (`RokadDate`, `OpeningBalance`, `Cash`, `JammaSideClosing`, `NovaeSideClosing`, `RokadFinished`, `CurrentDay`, `RokadFinishedTime`, `CreatedOn`, `CreatedBy`, `CreatedTime`, `Active`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RokadDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OpeningBalance", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Cash", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("JammaSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NovaeSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RokadFinished", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CurrentDay", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RokadFinishedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblRokadDetails` SET `RokadDate` = ?, `OpeningBalance` = ?, `Cash` = ?, `JammaSideClosing` = ?, `NovaeSideClosing` = ?, `RokadFinished` = ?, `CurrentDay` = ?, `RokadFinishedTime` = ?, `CreatedOn` = ?, `CreatedBy` = ?, `CreatedTime` = ?, `Active` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `RokadDate` IS NULL) OR (`RokadDate` = ?)) AND ((? = 1 AND `OpeningBalance` IS NULL) OR (`OpeningBalance` = ?)) AND ((? = 1 AND `Cash` IS NULL) OR (`Cash` = ?)) AND ((? = 1 AND `JammaSideClosing` IS NULL) OR (`JammaSideClosing` = ?)) AND ((? = 1 AND `NovaeSideClosing` IS NULL) OR (`NovaeSideClosing` = ?)) AND ((? = 1 AND `RokadFinished` IS NULL) OR (`RokadFinished` = ?)) AND ((? = 1 AND `CurrentDay` IS NULL) OR (`CurrentDay` = ?)) AND ((? = 1 AND `RokadFinishedTime` IS NULL) OR (`RokadFinishedTime` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedTime` IS NULL) OR (`CreatedTime` = ?)) AND ((? = 1 AND `Active` IS NULL) OR (`Active` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RokadDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("OpeningBalance", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Cash", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("JammaSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NovaeSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RokadFinished", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CurrentDay", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("RokadFinishedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RokadDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RokadDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_OpeningBalance", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_OpeningBalance", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OpeningBalance", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Cash", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Cash", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cash", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_JammaSideClosing", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_JammaSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "JammaSideClosing", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NovaeSideClosing", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NovaeSideClosing", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NovaeSideClosing", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RokadFinished", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RokadFinished", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinished", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CurrentDay", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CurrentDay", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrentDay", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_RokadFinishedTime", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_RokadFinishedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RokadFinishedTime", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedTime", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedTime", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedTime", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Active", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Active", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Active", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, RokadDate, OpeningBalance, Cash, JammaSideClosing, NovaeSideClosing, RokadFinished, CurrentDay, RokadFinishedTime, CreatedOn, CreatedBy, CreatedTime, Active FROM tblRokadDetails";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblRokadDetailsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblRokadDetailsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblRokadDetailsDataTable data = new pawnmanagementDataSet1.tblRokadDetailsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblRokadDetailsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRokadDetails");

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
      DateTime? Original_RokadDate,
      string Original_OpeningBalance,
      string Original_Cash,
      string Original_JammaSideClosing,
      string Original_NovaeSideClosing,
      string Original_RokadFinished,
      string Original_CurrentDay,
      DateTime? Original_RokadFinishedTime,
      DateTime? Original_CreatedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedTime,
      string Original_Active)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_RokadDate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_RokadDate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      if (Original_OpeningBalance == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_OpeningBalance;
      }
      if (Original_Cash == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_Cash;
      }
      if (Original_JammaSideClosing == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_JammaSideClosing;
      }
      if (Original_NovaeSideClosing == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_NovaeSideClosing;
      }
      if (Original_RokadFinished == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_RokadFinished;
      }
      if (Original_CurrentDay == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_CurrentDay;
      }
      if (Original_RokadFinishedTime.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_RokadFinishedTime.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedTime.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_CreatedTime.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_Active == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_Active;
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
      DateTime? RokadDate,
      string OpeningBalance,
      string Cash,
      string JammaSideClosing,
      string NovaeSideClosing,
      string RokadFinished,
      string CurrentDay,
      DateTime? RokadFinishedTime,
      DateTime? CreatedOn,
      string CreatedBy,
      DateTime? CreatedTime,
      string Active)
    {
      if (RokadDate.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) RokadDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (OpeningBalance == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) OpeningBalance;
      if (Cash == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Cash;
      if (JammaSideClosing == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) JammaSideClosing;
      if (NovaeSideClosing == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) NovaeSideClosing;
      if (RokadFinished == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) RokadFinished;
      if (CurrentDay == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) CurrentDay;
      if (RokadFinishedTime.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) RokadFinishedTime.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) CreatedBy;
      if (CreatedTime.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) CreatedTime.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Active == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Active;
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
      DateTime? RokadDate,
      string OpeningBalance,
      string Cash,
      string JammaSideClosing,
      string NovaeSideClosing,
      string RokadFinished,
      string CurrentDay,
      DateTime? RokadFinishedTime,
      DateTime? CreatedOn,
      string CreatedBy,
      DateTime? CreatedTime,
      string Active,
      int Original_ID,
      DateTime? Original_RokadDate,
      string Original_OpeningBalance,
      string Original_Cash,
      string Original_JammaSideClosing,
      string Original_NovaeSideClosing,
      string Original_RokadFinished,
      string Original_CurrentDay,
      DateTime? Original_RokadFinishedTime,
      DateTime? Original_CreatedOn,
      string Original_CreatedBy,
      DateTime? Original_CreatedTime,
      string Original_Active)
    {
      if (RokadDate.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) RokadDate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (OpeningBalance == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) OpeningBalance;
      if (Cash == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Cash;
      if (JammaSideClosing == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) JammaSideClosing;
      if (NovaeSideClosing == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) NovaeSideClosing;
      if (RokadFinished == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) RokadFinished;
      if (CurrentDay == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) CurrentDay;
      if (RokadFinishedTime.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) RokadFinishedTime.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (CreatedOn.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) CreatedOn.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) CreatedBy;
      if (CreatedTime.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) CreatedTime.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Active == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Active;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_ID;
      if (Original_RokadDate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Original_RokadDate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      if (Original_OpeningBalance == null)
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) Original_OpeningBalance;
      }
      if (Original_Cash == null)
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_Cash;
      }
      if (Original_JammaSideClosing == null)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_JammaSideClosing;
      }
      if (Original_NovaeSideClosing == null)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_NovaeSideClosing;
      }
      if (Original_RokadFinished == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_RokadFinished;
      }
      if (Original_CurrentDay == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_CurrentDay;
      }
      if (Original_RokadFinishedTime.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_RokadFinishedTime.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      if (Original_CreatedOn.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_CreatedOn.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedTime.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_CreatedTime.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      if (Original_Active == null)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_Active;
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
