
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
  public class tblRedemptionTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblRedemptionTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblRedemption",
        ColumnMappings = {
          {
            "BillNumber",
            "BillNumber"
          },
          {
            "BillDate",
            "BillDate"
          },
          {
            "PledgeBillNumber",
            "PledgeBillNumber"
          },
          {
            "CustomerCode",
            "CustomerCode"
          },
          {
            "PledgeDate",
            "PledgeDate"
          },
          {
            "Amount",
            "Amount"
          },
          {
            "temp1",
            "temp1"
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
            "OtherCharge",
            "OtherCharge"
          },
          {
            "Deductions",
            "Deductions"
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
            "NoOfMonths",
            "NoOfMonths"
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
            "CreatedOn",
            "CreatedOn"
          },
          {
            "CreatedBy",
            "CreatedBy"
          },
          {
            "ShopCode",
            "ShopCode"
          },
          {
            "ReleasedBy",
            "ReleasedBy"
          },
          {
            "BilledBy",
            "BilledBy"
          }
        }
      });
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblRedemption` (`BillNumber`, `BillDate`, `PledgeBillNumber`, `CustomerCode`, `PledgeDate`, `Amount`, `temp1`, `InterestLess`, `temp2`, `NoticeCharge`, `OtherCharge`, `Deductions`, `temp3`, `temp4`, `NoOfMonths`, `NoOfMonths16`, `Interest16`, `RedemptionAmount16`, `CreatedOn`, `CreatedBy`, `ShopCode`, `ReleasedBy`, `BilledBy`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BillDate", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BillDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeBillNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeBillNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CustomerCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CustomerCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PledgeDate", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PledgeDate", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Amount", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Amount", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("InterestLess", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "InterestLess", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoticeCharge", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoticeCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("OtherCharge", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OtherCharge", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Deductions", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Deductions", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp3", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp3", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("temp4", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "temp4", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoOfMonths", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NoOfMonths16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoOfMonths16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Interest16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Interest16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("RedemptionAmount16", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RedemptionAmount16", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ShopCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ShopCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("ReleasedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReleasedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("BilledBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "BilledBy", DataRowVersion.Current, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT BillNumber, BillDate, PledgeBillNumber, CustomerCode, PledgeDate, Amount, temp1, InterestLess, temp2, NoticeCharge, OtherCharge, Deductions, temp3, temp4, NoOfMonths, NoOfMonths16, Interest16, RedemptionAmount16, CreatedOn, CreatedBy, ShopCode, ReleasedBy, BilledBy FROM tblRedemption";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblRedemptionDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblRedemptionDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblRedemptionDataTable data = new pawnmanagementDataSet1.tblRedemptionDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblRedemptionDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRedemption");

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
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public virtual int Insert(
      string BillNumber,
      DateTime? BillDate,
      string PledgeBillNumber,
      string CustomerCode,
      string PledgeDate,
      string Amount,
      int? temp1,
      int? InterestLess,
      int? temp2,
      string NoticeCharge,
      string OtherCharge,
      string Deductions,
      int? temp3,
      int? temp4,
      string NoOfMonths,
      string NoOfMonths16,
      string Interest16,
      string RedemptionAmount16,
      DateTime? CreatedOn,
      string CreatedBy,
      string ShopCode,
      string ReleasedBy,
      string BilledBy)
    {
      if (BillNumber == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) BillNumber;
      if (BillDate.HasValue)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) BillDate.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      if (PledgeBillNumber == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) PledgeBillNumber;
      if (CustomerCode == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) CustomerCode;
      if (PledgeDate == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) PledgeDate;
      if (Amount == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Amount;
      if (temp1.HasValue)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) temp1.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      if (InterestLess.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) InterestLess.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (temp2.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) temp2.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (NoticeCharge == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) NoticeCharge;
      if (OtherCharge == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) OtherCharge;
      if (Deductions == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Deductions;
      if (temp3.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) temp3.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (temp4.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) temp4.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (NoOfMonths == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) NoOfMonths;
      if (NoOfMonths16 == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) NoOfMonths16;
      if (Interest16 == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) Interest16;
      if (RedemptionAmount16 == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) RedemptionAmount16;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) CreatedBy;
      if (ShopCode == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) ShopCode;
      if (ReleasedBy == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) ReleasedBy;
      if (BilledBy == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) BilledBy;
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
  }
}
