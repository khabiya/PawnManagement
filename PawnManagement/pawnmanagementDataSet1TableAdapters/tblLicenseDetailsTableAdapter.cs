
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
  public class tblLicenseDetailsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblLicenseDetailsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblLicenseDetails",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "LicensedTo",
            "LicensedTo"
          },
          {
            "SoftwareInstallationDate",
            "SoftwareInstallationDate"
          },
          {
            "SoftwareExpiresOn",
            "SoftwareExpiresOn"
          },
          {
            "LastUpdatedOn",
            "LastUpdatedOn"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblLicenseDetails` WHERE ((`ID` = ?) AND ((? = 1 AND `LicensedTo` IS NULL) OR (`LicensedTo` = ?)) AND ((? = 1 AND `SoftwareInstallationDate` IS NULL) OR (`SoftwareInstallationDate` = ?)) AND ((? = 1 AND `SoftwareExpiresOn` IS NULL) OR (`SoftwareExpiresOn` = ?)) AND ((? = 1 AND `LastUpdatedOn` IS NULL) OR (`LastUpdatedOn` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LicensedTo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LicensedTo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SoftwareInstallationDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SoftwareInstallationDate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_SoftwareExpiresOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_SoftwareExpiresOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_LastUpdatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_LastUpdatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblLicenseDetails` (`LicensedTo`, `SoftwareInstallationDate`, `SoftwareExpiresOn`, `LastUpdatedOn`) VALUES (?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LicensedTo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SoftwareInstallationDate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("SoftwareExpiresOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("LastUpdatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblLicenseDetails` SET `LicensedTo` = ?, `SoftwareInstallationDate` = ?, `SoftwareExpiresOn` = ?, `LastUpdatedOn` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `LicensedTo` IS NULL) OR (`LicensedTo` = ?)) AND ((? = 1 AND `SoftwareInstallationDate` IS NULL) OR (`SoftwareInstallationDate` = ?)) AND ((? = 1 AND `SoftwareExpiresOn` IS NULL) OR (`SoftwareExpiresOn` = ?)) AND ((? = 1 AND `LastUpdatedOn` IS NULL) OR (`LastUpdatedOn` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LicensedTo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SoftwareInstallationDate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("SoftwareExpiresOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("LastUpdatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LicensedTo", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LicensedTo", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LicensedTo", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SoftwareInstallationDate", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SoftwareInstallationDate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareInstallationDate", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_SoftwareExpiresOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_SoftwareExpiresOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SoftwareExpiresOn", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_LastUpdatedOn", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_LastUpdatedOn", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastUpdatedOn", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, LicensedTo, SoftwareInstallationDate, SoftwareExpiresOn, LastUpdatedOn FROM tblLicenseDetails";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblLicenseDetailsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblLicenseDetailsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblLicenseDetailsDataTable data = new pawnmanagementDataSet1.tblLicenseDetailsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblLicenseDetailsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblLicenseDetails");

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
      string Original_LicensedTo,
      string Original_SoftwareInstallationDate,
      string Original_SoftwareExpiresOn,
      string Original_LastUpdatedOn)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_LicensedTo == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_LicensedTo;
      }
      if (Original_SoftwareInstallationDate == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_SoftwareInstallationDate;
      }
      if (Original_SoftwareExpiresOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_SoftwareExpiresOn;
      }
      if (Original_LastUpdatedOn == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_LastUpdatedOn;
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
      string LicensedTo,
      string SoftwareInstallationDate,
      string SoftwareExpiresOn,
      string LastUpdatedOn)
    {
      if (LicensedTo == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) LicensedTo;
      if (SoftwareInstallationDate == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) SoftwareInstallationDate;
      if (SoftwareExpiresOn == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) SoftwareExpiresOn;
      if (LastUpdatedOn == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) LastUpdatedOn;
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
      string LicensedTo,
      string SoftwareInstallationDate,
      string SoftwareExpiresOn,
      string LastUpdatedOn,
      int Original_ID,
      string Original_LicensedTo,
      string Original_SoftwareInstallationDate,
      string Original_SoftwareExpiresOn,
      string Original_LastUpdatedOn)
    {
      if (LicensedTo == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) LicensedTo;
      if (SoftwareInstallationDate == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) SoftwareInstallationDate;
      if (SoftwareExpiresOn == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) SoftwareExpiresOn;
      if (LastUpdatedOn == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) LastUpdatedOn;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) Original_ID;
      if (Original_LicensedTo == null)
      {
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Original_LicensedTo;
      }
      if (Original_SoftwareInstallationDate == null)
      {
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Original_SoftwareInstallationDate;
      }
      if (Original_SoftwareExpiresOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Original_SoftwareExpiresOn;
      }
      if (Original_LastUpdatedOn == null)
      {
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_LastUpdatedOn;
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
