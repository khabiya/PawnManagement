
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
  public class tblPurityMasterTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblPurityMasterTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblPurityMaster",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "Metal",
            "Metal"
          },
          {
            "Purity",
            "Purity"
          },
          {
            "PurityLabel",
            "PurityLabel"
          },
          {
            "Melting",
            "Melting"
          },
          {
            "Deletable",
            "Deletable"
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
            "EditedBy",
            "EditedBy"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblPurityMaster` WHERE ((`ID` = ?) AND ((? = 1 AND `Metal` IS NULL) OR (`Metal` = ?)) AND ((? = 1 AND `Purity` IS NULL) OR (`Purity` = ?)) AND ((? = 1 AND `PurityLabel` IS NULL) OR (`PurityLabel` = ?)) AND ((? = 1 AND `Melting` IS NULL) OR (`Melting` = ?)) AND ((? = 1 AND `Deletable` IS NULL) OR (`Deletable` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Metal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Purity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Purity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PurityLabel", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PurityLabel", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Melting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Melting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Deletable", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Deletable", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblPurityMaster` (`Metal`, `Purity`, `PurityLabel`, `Melting`, `Deletable`, `EditedOn`, `CreatedBy`, `CreatedOn`, `EditedBy`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Purity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PurityLabel", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Melting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Deletable", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblPurityMaster` SET `Metal` = ?, `Purity` = ?, `PurityLabel` = ?, `Melting` = ?, `Deletable` = ?, `EditedOn` = ?, `CreatedBy` = ?, `CreatedOn` = ?, `EditedBy` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `Metal` IS NULL) OR (`Metal` = ?)) AND ((? = 1 AND `Purity` IS NULL) OR (`Purity` = ?)) AND ((? = 1 AND `PurityLabel` IS NULL) OR (`PurityLabel` = ?)) AND ((? = 1 AND `Melting` IS NULL) OR (`Melting` = ?)) AND ((? = 1 AND `Deletable` IS NULL) OR (`Deletable` = ?)) AND ((? = 1 AND `EditedOn` IS NULL) OR (`EditedOn` = ?)) AND ((? = 1 AND `CreatedBy` IS NULL) OR (`CreatedBy` = ?)) AND ((? = 1 AND `CreatedOn` IS NULL) OR (`CreatedOn` = ?)) AND ((? = 1 AND `EditedBy` IS NULL) OR (`EditedBy` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Purity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PurityLabel", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Melting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Deletable", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Metal", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Metal", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Metal", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Purity", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Purity", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Purity", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PurityLabel", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PurityLabel", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PurityLabel", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Melting", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Melting", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Melting", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Deletable", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Deletable", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deletable", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CreatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CreatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_EditedBy", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, Metal, Purity, PurityLabel, Melting, Deletable, EditedOn, CreatedBy, CreatedOn, EditedBy FROM tblPurityMaster";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblPurityMasterDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblPurityMasterDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblPurityMasterDataTable data = new pawnmanagementDataSet1.tblPurityMasterDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblPurityMasterDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblPurityMaster");

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
      string Original_Metal,
      string Original_Purity,
      string Original_PurityLabel,
      string Original_Melting,
      string Original_Deletable,
      string Original_EditedOn,
      string Original_CreatedBy,
      string Original_CreatedOn,
      string Original_EditedBy)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_Metal == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_Metal;
      }
      if (Original_Purity == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_Purity;
      }
      if (Original_PurityLabel == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_PurityLabel;
      }
      if (Original_Melting == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_Melting;
      }
      if (Original_Deletable == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Deletable;
      }
      if (Original_EditedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_EditedOn;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_CreatedOn;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_EditedBy;
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
      string Metal,
      string Purity,
      string PurityLabel,
      string Melting,
      string Deletable,
      string EditedOn,
      string CreatedBy,
      string CreatedOn,
      string EditedBy)
    {
      if (Metal == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) Metal;
      if (Purity == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) Purity;
      if (PurityLabel == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) PurityLabel;
      if (Melting == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Melting;
      if (Deletable == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Deletable;
      if (EditedOn == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) EditedOn;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) CreatedOn;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) EditedBy;
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
      string Metal,
      string Purity,
      string PurityLabel,
      string Melting,
      string Deletable,
      string EditedOn,
      string CreatedBy,
      string CreatedOn,
      string EditedBy,
      int Original_ID,
      string Original_Metal,
      string Original_Purity,
      string Original_PurityLabel,
      string Original_Melting,
      string Original_Deletable,
      string Original_EditedOn,
      string Original_CreatedBy,
      string Original_CreatedOn,
      string Original_EditedBy)
    {
      if (Metal == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) Metal;
      if (Purity == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) Purity;
      if (PurityLabel == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) PurityLabel;
      if (Melting == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Melting;
      if (Deletable == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Deletable;
      if (EditedOn == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) EditedOn;
      if (CreatedBy == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) CreatedBy;
      if (CreatedOn == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) CreatedOn;
      if (EditedBy == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) EditedBy;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Original_ID;
      if (Original_Metal == null)
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Original_Metal;
      }
      if (Original_Purity == null)
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_Purity;
      }
      if (Original_PurityLabel == null)
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Original_PurityLabel;
      }
      if (Original_Melting == null)
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_Melting;
      }
      if (Original_Deletable == null)
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_Deletable;
      }
      if (Original_EditedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Original_EditedOn;
      }
      if (Original_CreatedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) Original_CreatedBy;
      }
      if (Original_CreatedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) Original_CreatedOn;
      }
      if (Original_EditedBy == null)
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) Original_EditedBy;
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
