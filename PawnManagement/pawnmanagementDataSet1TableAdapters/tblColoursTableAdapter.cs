
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
  public class tblColoursTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblColoursTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblColours",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "FormName",
            "FormName"
          },
          {
            "ForeColour",
            "ForeColour"
          },
          {
            "BackColour",
            "BackColour"
          },
          {
            "ButtonForeColour",
            "ButtonForeColour"
          },
          {
            "ButtonBackColour",
            "ButtonBackColour"
          },
          {
            "TextBoxForeColour",
            "TextBoxForeColour"
          },
          {
            "TextBoxBackColour",
            "TextBoxBackColour"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblColours` WHERE ((`ID` = ?) AND ((? = 1 AND `FormName` IS NULL) OR (`FormName` = ?)) AND ((? = 1 AND `ForeColour` IS NULL) OR (`ForeColour` = ?)) AND ((? = 1 AND `BackColour` IS NULL) OR (`BackColour` = ?)) AND ((? = 1 AND `ButtonForeColour` IS NULL) OR (`ButtonForeColour` = ?)) AND ((? = 1 AND `ButtonBackColour` IS NULL) OR (`ButtonBackColour` = ?)) AND ((? = 1 AND `TextBoxForeColour` IS NULL) OR (`TextBoxForeColour` = ?)) AND ((? = 1 AND `TextBoxBackColour` IS NULL) OR (`TextBoxBackColour` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_FormName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_FormName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_BackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_BackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_ButtonBackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ButtonBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TextBoxForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TextBoxForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_TextBoxBackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_TextBoxBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblColours` (`FormName`, `ForeColour`, `BackColour`, `ButtonForeColour`, `ButtonBackColour`, `TextBoxForeColour`, `TextBoxBackColour`) VALUES (?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FormName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ButtonBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TextBoxForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("TextBoxBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblColours` SET `FormName` = ?, `ForeColour` = ?, `BackColour` = ?, `ButtonForeColour` = ?, `ButtonBackColour` = ?, `TextBoxForeColour` = ?, `TextBoxBackColour` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `FormName` IS NULL) OR (`FormName` = ?)) AND ((? = 1 AND `ForeColour` IS NULL) OR (`ForeColour` = ?)) AND ((? = 1 AND `BackColour` IS NULL) OR (`BackColour` = ?)) AND ((? = 1 AND `ButtonForeColour` IS NULL) OR (`ButtonForeColour` = ?)) AND ((? = 1 AND `ButtonBackColour` IS NULL) OR (`ButtonBackColour` = ?)) AND ((? = 1 AND `TextBoxForeColour` IS NULL) OR (`TextBoxForeColour` = ?)) AND ((? = 1 AND `TextBoxBackColour` IS NULL) OR (`TextBoxBackColour` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FormName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("BackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("ButtonBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TextBoxForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("TextBoxBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_FormName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_FormName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_BackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_BackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BackColour", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ButtonForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_ButtonBackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ButtonBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ButtonBackColour", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TextBoxForeColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TextBoxForeColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxForeColour", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_TextBoxBackColour", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_TextBoxBackColour", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TextBoxBackColour", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, FormName, ForeColour, BackColour, ButtonForeColour, ButtonBackColour, TextBoxForeColour, TextBoxBackColour FROM tblColours";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblColoursDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblColoursDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblColoursDataTable data = new pawnmanagementDataSet1.tblColoursDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblColoursDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblColours");

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
      string Original_FormName,
      string Original_ForeColour,
      string Original_BackColour,
      int? Original_ButtonForeColour,
      string Original_ButtonBackColour,
      string Original_TextBoxForeColour,
      string Original_TextBoxBackColour)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_FormName == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_FormName;
      }
      if (Original_ForeColour == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_ForeColour;
      }
      if (Original_BackColour == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_BackColour;
      }
      if (Original_ButtonForeColour.HasValue)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_ButtonForeColour.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      if (Original_ButtonBackColour == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_ButtonBackColour;
      }
      if (Original_TextBoxForeColour == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_TextBoxForeColour;
      }
      if (Original_TextBoxBackColour == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_TextBoxBackColour;
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
      string FormName,
      string ForeColour,
      string BackColour,
      int? ButtonForeColour,
      string ButtonBackColour,
      string TextBoxForeColour,
      string TextBoxBackColour)
    {
      if (FormName == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) FormName;
      if (ForeColour == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) ForeColour;
      if (BackColour == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) BackColour;
      if (ButtonForeColour.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) ButtonForeColour.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      if (ButtonBackColour == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) ButtonBackColour;
      if (TextBoxForeColour == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) TextBoxForeColour;
      if (TextBoxBackColour == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) TextBoxBackColour;
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
      string FormName,
      string ForeColour,
      string BackColour,
      int? ButtonForeColour,
      string ButtonBackColour,
      string TextBoxForeColour,
      string TextBoxBackColour,
      int Original_ID,
      string Original_FormName,
      string Original_ForeColour,
      string Original_BackColour,
      int? Original_ButtonForeColour,
      string Original_ButtonBackColour,
      string Original_TextBoxForeColour,
      string Original_TextBoxBackColour)
    {
      if (FormName == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) FormName;
      if (ForeColour == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) ForeColour;
      if (BackColour == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) BackColour;
      if (ButtonForeColour.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) ButtonForeColour.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      if (ButtonBackColour == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) ButtonBackColour;
      if (TextBoxForeColour == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) TextBoxForeColour;
      if (TextBoxBackColour == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) TextBoxBackColour;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Original_ID;
      if (Original_FormName == null)
      {
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Original_FormName;
      }
      if (Original_ForeColour == null)
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Original_ForeColour;
      }
      if (Original_BackColour == null)
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_BackColour;
      }
      if (Original_ButtonForeColour.HasValue)
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_ButtonForeColour.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      }
      if (Original_ButtonBackColour == null)
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_ButtonBackColour;
      }
      if (Original_TextBoxForeColour == null)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_TextBoxForeColour;
      }
      if (Original_TextBoxBackColour == null)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_TextBoxBackColour;
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
