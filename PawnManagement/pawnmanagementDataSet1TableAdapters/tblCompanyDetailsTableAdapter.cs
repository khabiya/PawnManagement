
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
  public class tblCompanyDetailsTableAdapter : Component
  {
    private OleDbDataAdapter _adapter;
    private OleDbConnection _connection;
    private OleDbTransaction _transaction;
    private OleDbCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public tblCompanyDetailsTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblCompanyDetails",
        ColumnMappings = {
          {
            "ID",
            "ID"
          },
          {
            "CompanyCode",
            "CompanyCode"
          },
          {
            "CompanyName",
            "CompanyName"
          },
          {
            "MailingName",
            "MailingName"
          },
          {
            "DoorNumber",
            "DoorNumber"
          },
          {
            "Address1",
            "Address1"
          },
          {
            "Address2",
            "Address2"
          },
          {
            "Location",
            "Location"
          },
          {
            "City",
            "City"
          },
          {
            "Pincode",
            "Pincode"
          },
          {
            "State",
            "State"
          },
          {
            "Country",
            "Country"
          },
          {
            "PhoneNumber",
            "PhoneNumber"
          },
          {
            "AlternateNumber",
            "AlternateNumber"
          },
          {
            "FaxNumber",
            "FaxNumber"
          },
          {
            "Email",
            "Email"
          },
          {
            "Website",
            "Website"
          },
          {
            "CurrencySymbol",
            "CurrencySymbol"
          },
          {
            "NumberOfDecimalPlaces",
            "NumberOfDecimalPlaces"
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
          },
          {
            "EditedOn",
            "EditedOn"
          },
          {
            "DefaultCompany",
            "DefaultCompany"
          }
        }
      });
      this._adapter.DeleteCommand = new OleDbCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM `tblCompanyDetails` WHERE ((`ID` = ?) AND ((? = 1 AND `CompanyCode` IS NULL) OR (`CompanyCode` = ?)) AND ((? = 1 AND `CompanyName` IS NULL) OR (`CompanyName` = ?)) AND ((? = 1 AND `MailingName` IS NULL) OR (`MailingName` = ?)) AND ((? = 1 AND `DoorNumber` IS NULL) OR (`DoorNumber` = ?)) AND ((? = 1 AND `Address1` IS NULL) OR (`Address1` = ?)) AND ((? = 1 AND `Address2` IS NULL) OR (`Address2` = ?)) AND ((? = 1 AND `Location` IS NULL) OR (`Location` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `State` IS NULL) OR (`State` = ?)) AND ((? = 1 AND `Country` IS NULL) OR (`Country` = ?)) AND ((? = 1 AND `PhoneNumber` IS NULL) OR (`PhoneNumber` = ?)) AND ((? = 1 AND `AlternateNumber` IS NULL) OR (`AlternateNumber` = ?)) AND ((? = 1 AND `FaxNumber` IS NULL) OR (`FaxNumber` = ?)) AND ((? = 1 AND `Email` IS NULL) OR (`Email` = ?)) AND ((? = 1 AND `Website` IS NULL) OR (`Website` = ?)) AND ((? = 1 AND `CurrencySymbol` IS NULL) OR (`CurrencySymbol` = ?)) AND ((? = 1 AND `NumberOfDecimalPlaces` IS NULL) OR (`NumberOfDecimalPlaces` = ?)))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CompanyCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_MailingName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_MailingName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_DoorNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Address1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Address2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Location", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_State", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Country", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Country", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_AlternateNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_AlternateNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_FaxNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_FaxNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Email", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Email", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_Website", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_Website", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_CurrencySymbol", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_CurrencySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Original, false, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("IsNull_NumberOfDecimalPlaces", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Original, true, (object) null));
      this._adapter.DeleteCommand.Parameters.Add(new OleDbParameter("Original_NumberOfDecimalPlaces", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Original, false, (object) null));
      this._adapter.InsertCommand = new OleDbCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO `tblCompanyDetails` (`CompanyCode`, `CompanyName`, `MailingName`, `DoorNumber`, `Address1`, `Address2`, `Location`, `City`, `Pincode`, `State`, `Country`, `PhoneNumber`, `AlternateNumber`, `FaxNumber`, `Email`, `Website`, `CurrencySymbol`, `NumberOfDecimalPlaces`, `CreatedBy`, `CreatedOn`, `EditedBy`, `EditedOn`, `DefaultCompany`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CompanyCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("MailingName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Country", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("AlternateNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("FaxNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Email", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("Website", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CurrencySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("NumberOfDecimalPlaces", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("CreatedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CreatedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedBy", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedBy", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("EditedOn", OleDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EditedOn", DataRowVersion.Current, false, (object) null));
      this._adapter.InsertCommand.Parameters.Add(new OleDbParameter("DefaultCompany", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DefaultCompany", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand = new OleDbCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE `tblCompanyDetails` SET `CompanyCode` = ?, `CompanyName` = ?, `MailingName` = ?, `DoorNumber` = ?, `Address1` = ?, `Address2` = ?, `Location` = ?, `City` = ?, `Pincode` = ?, `State` = ?, `Country` = ?, `PhoneNumber` = ?, `AlternateNumber` = ?, `FaxNumber` = ?, `Email` = ?, `Website` = ?, `CurrencySymbol` = ?, `NumberOfDecimalPlaces` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `CompanyCode` IS NULL) OR (`CompanyCode` = ?)) AND ((? = 1 AND `CompanyName` IS NULL) OR (`CompanyName` = ?)) AND ((? = 1 AND `MailingName` IS NULL) OR (`MailingName` = ?)) AND ((? = 1 AND `DoorNumber` IS NULL) OR (`DoorNumber` = ?)) AND ((? = 1 AND `Address1` IS NULL) OR (`Address1` = ?)) AND ((? = 1 AND `Address2` IS NULL) OR (`Address2` = ?)) AND ((? = 1 AND `Location` IS NULL) OR (`Location` = ?)) AND ((? = 1 AND `City` IS NULL) OR (`City` = ?)) AND ((? = 1 AND `Pincode` IS NULL) OR (`Pincode` = ?)) AND ((? = 1 AND `State` IS NULL) OR (`State` = ?)) AND ((? = 1 AND `Country` IS NULL) OR (`Country` = ?)) AND ((? = 1 AND `PhoneNumber` IS NULL) OR (`PhoneNumber` = ?)) AND ((? = 1 AND `AlternateNumber` IS NULL) OR (`AlternateNumber` = ?)) AND ((? = 1 AND `FaxNumber` IS NULL) OR (`FaxNumber` = ?)) AND ((? = 1 AND `Email` IS NULL) OR (`Email` = ?)) AND ((? = 1 AND `Website` IS NULL) OR (`Website` = ?)) AND ((? = 1 AND `CurrencySymbol` IS NULL) OR (`CurrencySymbol` = ?)) AND ((? = 1 AND `NumberOfDecimalPlaces` IS NULL) OR (`NumberOfDecimalPlaces` = ?)))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CompanyCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("MailingName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Country", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("AlternateNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("FaxNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Email", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Website", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("CurrencySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("NumberOfDecimalPlaces", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Current, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_ID", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyCode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CompanyCode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyCode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CompanyName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CompanyName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CompanyName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_MailingName", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_MailingName", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MailingName", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_DoorNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_DoorNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DoorNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Address1", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Address1", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address1", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Address2", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Address2", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Address2", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Location", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Location", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Location", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_City", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_City", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "City", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Pincode", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Pincode", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Pincode", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_State", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_State", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "State", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Country", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Country", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Country", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_PhoneNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_PhoneNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "PhoneNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_AlternateNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_AlternateNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "AlternateNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_FaxNumber", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_FaxNumber", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FaxNumber", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Email", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Email", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_Website", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_Website", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Website", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_CurrencySymbol", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_CurrencySymbol", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CurrencySymbol", DataRowVersion.Original, false, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("IsNull_NumberOfDecimalPlaces", OleDbType.Integer, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Original, true, (object) null));
      this._adapter.UpdateCommand.Parameters.Add(new OleDbParameter("Original_NumberOfDecimalPlaces", OleDbType.VarWChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NumberOfDecimalPlaces", DataRowVersion.Original, false, (object) null));
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
      this._commandCollection[0].CommandText = "SELECT ID, CompanyCode, CompanyName, MailingName, DoorNumber, Address1, Address2, Location, City, Pincode, State, Country, PhoneNumber, AlternateNumber, FaxNumber, Email, Website, CurrencySymbol, NumberOfDecimalPlaces, CreatedBy, CreatedOn, EditedBy, EditedOn, DefaultCompany FROM tblCompanyDetails";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      pawnmanagementDataSet1.tblCompanyDetailsDataTable dataTable)
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
    public virtual pawnmanagementDataSet1.tblCompanyDetailsDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      pawnmanagementDataSet1.tblCompanyDetailsDataTable data = new pawnmanagementDataSet1.tblCompanyDetailsDataTable();
      this.Adapter.Fill((DataTable) data);
      return data;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      pawnmanagementDataSet1.tblCompanyDetailsDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(pawnmanagementDataSet1 dataSet) => this.Adapter.Update((DataSet) dataSet, "tblCompanyDetails");

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
      string Original_CompanyCode,
      string Original_CompanyName,
      string Original_MailingName,
      string Original_DoorNumber,
      string Original_Address1,
      string Original_Address2,
      string Original_Location,
      string Original_City,
      string Original_Pincode,
      string Original_State,
      string Original_Country,
      string Original_PhoneNumber,
      string Original_AlternateNumber,
      string Original_FaxNumber,
      string Original_Email,
      string Original_Website,
      string Original_CurrencySymbol,
      string Original_NumberOfDecimalPlaces)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_ID;
      if (Original_CompanyCode == null)
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[1].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[2].Value = (object) Original_CompanyCode;
      }
      if (Original_CompanyName == null)
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[3].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[4].Value = (object) Original_CompanyName;
      }
      if (Original_MailingName == null)
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[5].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[6].Value = (object) Original_MailingName;
      }
      if (Original_DoorNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[7].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[8].Value = (object) Original_DoorNumber;
      }
      if (Original_Address1 == null)
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[9].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[10].Value = (object) Original_Address1;
      }
      if (Original_Address2 == null)
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[11].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[12].Value = (object) Original_Address2;
      }
      if (Original_Location == null)
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[13].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[14].Value = (object) Original_Location;
      }
      if (Original_City == null)
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[15].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[16].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[17].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[18].Value = (object) Original_Pincode;
      }
      if (Original_State == null)
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[19].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[20].Value = (object) Original_State;
      }
      if (Original_Country == null)
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[21].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[22].Value = (object) Original_Country;
      }
      if (Original_PhoneNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[23].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[24].Value = (object) Original_PhoneNumber;
      }
      if (Original_AlternateNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[25].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[26].Value = (object) Original_AlternateNumber;
      }
      if (Original_FaxNumber == null)
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[27].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[28].Value = (object) Original_FaxNumber;
      }
      if (Original_Email == null)
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[29].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[30].Value = (object) Original_Email;
      }
      if (Original_Website == null)
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[31].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[32].Value = (object) Original_Website;
      }
      if (Original_CurrencySymbol == null)
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[33].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[34].Value = (object) Original_CurrencySymbol;
      }
      if (Original_NumberOfDecimalPlaces == null)
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 1;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.DeleteCommand.Parameters[35].Value = (object) 0;
        this.Adapter.DeleteCommand.Parameters[36].Value = (object) Original_NumberOfDecimalPlaces;
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
      string CompanyCode,
      string CompanyName,
      string MailingName,
      string DoorNumber,
      string Address1,
      string Address2,
      string Location,
      string City,
      string Pincode,
      string State,
      string Country,
      string PhoneNumber,
      string AlternateNumber,
      string FaxNumber,
      string Email,
      string Website,
      string CurrencySymbol,
      string NumberOfDecimalPlaces,
      string CreatedBy,
      DateTime? CreatedOn,
      string EditedBy,
      DateTime? EditedOn,
      string DefaultCompany)
    {
      if (CompanyCode == null)
        this.Adapter.InsertCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[0].Value = (object) CompanyCode;
      if (CompanyName == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) CompanyName;
      if (MailingName == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) MailingName;
      if (DoorNumber == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DoorNumber;
      if (Address1 == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Address1;
      if (Address2 == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Address2;
      if (Location == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Location;
      if (City == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) City;
      if (Pincode == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Pincode;
      if (State == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) State;
      if (Country == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Country;
      if (PhoneNumber == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) PhoneNumber;
      if (AlternateNumber == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) AlternateNumber;
      if (FaxNumber == null)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) FaxNumber;
      if (Email == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) Email;
      if (Website == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) Website;
      if (CurrencySymbol == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) CurrencySymbol;
      if (NumberOfDecimalPlaces == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) NumberOfDecimalPlaces;
      if (CreatedBy == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) CreatedBy;
      if (CreatedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) CreatedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (EditedBy == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) EditedBy;
      if (EditedOn.HasValue)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) EditedOn.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      if (DefaultCompany == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DefaultCompany;
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
      string CompanyCode,
      string CompanyName,
      string MailingName,
      string DoorNumber,
      string Address1,
      string Address2,
      string Location,
      string City,
      string Pincode,
      string State,
      string Country,
      string PhoneNumber,
      string AlternateNumber,
      string FaxNumber,
      string Email,
      string Website,
      string CurrencySymbol,
      string NumberOfDecimalPlaces,
      int Original_ID,
      string Original_CompanyCode,
      string Original_CompanyName,
      string Original_MailingName,
      string Original_DoorNumber,
      string Original_Address1,
      string Original_Address2,
      string Original_Location,
      string Original_City,
      string Original_Pincode,
      string Original_State,
      string Original_Country,
      string Original_PhoneNumber,
      string Original_AlternateNumber,
      string Original_FaxNumber,
      string Original_Email,
      string Original_Website,
      string Original_CurrencySymbol,
      string Original_NumberOfDecimalPlaces)
    {
      if (CompanyCode == null)
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[0].Value = (object) CompanyCode;
      if (CompanyName == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) CompanyName;
      if (MailingName == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) MailingName;
      if (DoorNumber == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DoorNumber;
      if (Address1 == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Address1;
      if (Address2 == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Address2;
      if (Location == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Location;
      if (City == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) City;
      if (Pincode == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Pincode;
      if (State == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) State;
      if (Country == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Country;
      if (PhoneNumber == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) PhoneNumber;
      if (AlternateNumber == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) AlternateNumber;
      if (FaxNumber == null)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) FaxNumber;
      if (Email == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Email;
      if (Website == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Website;
      if (CurrencySymbol == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) CurrencySymbol;
      if (NumberOfDecimalPlaces == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) NumberOfDecimalPlaces;
      this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_ID;
      if (Original_CompanyCode == null)
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) Original_CompanyCode;
      }
      if (Original_CompanyName == null)
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Original_CompanyName;
      }
      if (Original_MailingName == null)
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_MailingName;
      }
      if (Original_DoorNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) Original_DoorNumber;
      }
      if (Original_Address1 == null)
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) Original_Address1;
      }
      if (Original_Address2 == null)
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) Original_Address2;
      }
      if (Original_Location == null)
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) Original_Location;
      }
      if (Original_City == null)
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_City;
      }
      if (Original_Pincode == null)
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[35].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[36].Value = (object) Original_Pincode;
      }
      if (Original_State == null)
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[37].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[38].Value = (object) Original_State;
      }
      if (Original_Country == null)
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[39].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[40].Value = (object) Original_Country;
      }
      if (Original_PhoneNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[41].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[42].Value = (object) Original_PhoneNumber;
      }
      if (Original_AlternateNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[43].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[44].Value = (object) Original_AlternateNumber;
      }
      if (Original_FaxNumber == null)
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[45].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[46].Value = (object) Original_FaxNumber;
      }
      if (Original_Email == null)
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[47].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[48].Value = (object) Original_Email;
      }
      if (Original_Website == null)
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[49].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[50].Value = (object) Original_Website;
      }
      if (Original_CurrencySymbol == null)
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[51].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[52].Value = (object) Original_CurrencySymbol;
      }
      if (Original_NumberOfDecimalPlaces == null)
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 1;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) DBNull.Value;
      }
      else
      {
        this.Adapter.UpdateCommand.Parameters[53].Value = (object) 0;
        this.Adapter.UpdateCommand.Parameters[54].Value = (object) Original_NumberOfDecimalPlaces;
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
