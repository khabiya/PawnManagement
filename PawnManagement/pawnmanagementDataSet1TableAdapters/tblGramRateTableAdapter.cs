
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
  public class tblGramRateTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblGramRateTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblGramRate",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "Type",
            "Type"
          },
          {
            "PureRate",
            "PureRate"
          },
          {
            "KachaRate",
            "KachaRate"
          },
          {
            "BoardRate",
            "BoardRate"
          },
          {
            "PledgeRate",
            "PledgeRate"
          },
          {
            "SaleRate",
            "SaleRate"
          },
          {
            "Deduction",
            "Deduction"
          },
          {
            "DefaultPurity",
            "DefaultPurity"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblGramRate` WHERE ((`ID` = ?) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `PureRate` IS NULL) OR (`PureRate` = ?)) AND ((? = 1 AND `KachaRate` IS NULL) OR (`KachaRate` = ?)) AND ((? = 1 AND `BoardRate` IS NULL) OR (`BoardRate` = ?)) AND ((? = 1 AND `PledgeRate` IS NULL) OR (`PledgeRate` = ?)) AND ((? = 1 AND `SaleRate` IS NULL) OR (`SaleRate` = ?)) AND ((? = 1 AND `Deduction` IS NULL) OR (`Deduction` = ?)) AND ((? = 1 AND `DefaultPurity` IS NULL) OR (`DefaultPurity` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Deduction", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Deduction", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblGramRate` (`Type`, `PureRate`, `KachaRate`, `BoardRate`, `PledgeRate`, `SaleRate`, `Deduction`, `DefaultPurity`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Deduction", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblGramRate` SET `Type` = ?, `PureRate` = ?, `KachaRate` = ?, `BoardRate` = ?, `PledgeRate` = ?, `SaleRate` = ?, `Deduction` = ?, `DefaultPurity` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `Type` IS NULL) OR (`Type` = ?)) AND ((? = 1 AND `PureRate` IS NULL) OR (`PureRate` = ?)) AND ((? = 1 AND `KachaRate` IS NULL) OR (`KachaRate` = ?)) AND ((? = 1 AND `BoardRate` IS NULL) OR (`BoardRate` = ?)) AND ((? = 1 AND `PledgeRate` IS NULL) OR (`PledgeRate` = ?)) AND ((? = 1 AND `SaleRate` IS NULL) OR (`SaleRate` = ?)) AND ((? = 1 AND `Deduction` IS NULL) OR (`Deduction` = ?)) AND ((? = 1 AND `DefaultPurity` IS NULL) OR (`DefaultPurity` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Deduction", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Type", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Type", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Type", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PureRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PureRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_KachaRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KachaRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BoardRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoardRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PledgeRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SaleRate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SaleRate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Deduction", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Deduction", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deduction", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DefaultPurity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultPurity", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, Type, PureRate, KachaRate, BoardRate, PledgeRate, SaleRate, Deduction, DefaultPurity FROM tblGramRate";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblGramRateDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblGramRateDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblGramRateDataTable data = new pawnmanagementDataSet1.tblGramRateDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblGramRateDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblGramRate");

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
      string Original_Type,
      int? Original_PureRate,
      int? Original_KachaRate,
      int? Original_BoardRate,
      int? Original_PledgeRate,
      int? Original_SaleRate,
      double? Original_Deduction,
      int? Original_DefaultPurity)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_Type == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_Type;
      }
      if (Original_PureRate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_PureRate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      if (Original_KachaRate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_KachaRate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      if (Original_BoardRate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_BoardRate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      if (Original_PledgeRate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_PledgeRate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      if (Original_SaleRate.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_SaleRate.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_Deduction.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_Deduction.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      if (Original_DefaultPurity.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_DefaultPurity.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
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
      string Type,
      int? PureRate,
      int? KachaRate,
      int? BoardRate,
      int? PledgeRate,
      int? SaleRate,
      double? Deduction,
      int? DefaultPurity)
    {
      if (Type == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) Type;
      if (PureRate.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) PureRate.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (KachaRate.HasValue)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) KachaRate.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      if (BoardRate.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) BoardRate.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      if (PledgeRate.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) PledgeRate.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      if (SaleRate.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) SaleRate.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Deduction.HasValue)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Deduction.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      if (DefaultPurity.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DefaultPurity.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
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
      string Type,
      int? PureRate,
      int? KachaRate,
      int? BoardRate,
      int? PledgeRate,
      int? SaleRate,
      double? Deduction,
      int? DefaultPurity,
      int Original_ID,
      string Original_Type,
      int? Original_PureRate,
      int? Original_KachaRate,
      int? Original_BoardRate,
      int? Original_PledgeRate,
      int? Original_SaleRate,
      double? Original_Deduction,
      int? Original_DefaultPurity)
    {
      if (Type == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) Type;
      if (PureRate.HasValue)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) PureRate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      if (KachaRate.HasValue)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) KachaRate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      if (BoardRate.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) BoardRate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      if (PledgeRate.HasValue)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) PledgeRate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      if (SaleRate.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) SaleRate.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Deduction.HasValue)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Deduction.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      if (DefaultPurity.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DefaultPurity.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Original_ID;
      if (Original_Type == null)
      {
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Original_Type;
      }
      if (Original_PureRate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_PureRate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      if (Original_KachaRate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Original_KachaRate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      if (Original_BoardRate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) Original_BoardRate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      if (Original_PledgeRate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_PledgeRate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      if (Original_SaleRate.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_SaleRate.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      if (Original_Deduction.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_Deduction.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      if (Original_DefaultPurity.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_DefaultPurity.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
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
