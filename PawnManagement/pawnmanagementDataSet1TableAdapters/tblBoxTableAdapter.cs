

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
  public class tblBoxTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblBoxTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblBox",
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
            "BoxCode",
            "BoxCode"
          },
          {
            "BoxName",
            "BoxName"
          },
          {
            "Description",
            "Description"
          },
          {
            "Weight",
            "Weight"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblBox` WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BoxCode` IS NULL) OR (`BoxCode` = ?)) AND ((? = 1 AND `BoxName` IS NULL) OR (`BoxName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `Weight` IS NULL) OR (`Weight` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BoxCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BoxCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BoxName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BoxName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Weight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Weight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblBox` (`SerialNumber`, `BoxCode`, `BoxName`, `Description`, `Weight`) VALUES (?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BoxCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BoxName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Weight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblBox` SET `SerialNumber` = ?, `BoxCode` = ?, `BoxName` = ?, `Description` = ?, `Weight` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `SerialNumber` IS NULL) OR (`SerialNumber` = ?)) AND ((? = 1 AND `BoxCode` IS NULL) OR (`BoxCode` = ?)) AND ((? = 1 AND `BoxName` IS NULL) OR (`BoxName` = ?)) AND ((? = 1 AND `Description` IS NULL) OR (`Description` = ?)) AND ((? = 1 AND `Weight` IS NULL) OR (`Weight` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BoxCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BoxName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Weight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SerialNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SerialNumber", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SerialNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BoxCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BoxCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BoxName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BoxName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BoxName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Description", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Description", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Description", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Weight", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Weight", OleDbType.Double, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weight", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, SerialNumber, BoxCode, BoxName, Description, Weight FROM tblBox";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(pawnmanagementDataSet1.tblBoxDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblBoxDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblBoxDataTable data = new pawnmanagementDataSet1.tblBoxDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1.tblBoxDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblBox");

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
      string Original_BoxCode,
      string Original_BoxName,
      string Original_Description,
      double? Original_Weight)
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
      if (Original_BoxCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_BoxCode;
      }
      if (Original_BoxName == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_BoxName;
      }
      if (Original_Description == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Description;
      }
      if (Original_Weight.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Weight.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
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
      string BoxCode,
      string BoxName,
      string Description,
      double? Weight)
    {
      if (SerialNumber.HasValue)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BoxCode == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BoxCode;
      if (BoxName == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) BoxName;
      if (Description == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Description;
      if (Weight.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Weight.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
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
      string BoxCode,
      string BoxName,
      string Description,
      double? Weight,
      int Original_ID,
      double? Original_SerialNumber,
      string Original_BoxCode,
      string Original_BoxName,
      string Original_Description,
      double? Original_Weight)
    {
      if (SerialNumber.HasValue)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) SerialNumber.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      if (BoxCode == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) BoxCode;
      if (BoxName == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) BoxName;
      if (Description == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Description;
      if (Weight.HasValue)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Weight.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) Original_ID;
      if (Original_SerialNumber.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Original_SerialNumber.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      }
      if (Original_BoxCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Original_BoxCode;
      }
      if (Original_BoxName == null)
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Original_BoxName;
      }
      if (Original_Description == null)
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_Description;
      }
      if (Original_Weight.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_Weight.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
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
